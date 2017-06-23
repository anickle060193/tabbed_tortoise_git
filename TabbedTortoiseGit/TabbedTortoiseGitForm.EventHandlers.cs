using Common;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;
using Tabs;

namespace TabbedTortoiseGit
{
    partial class TabbedTortoiseGitForm
    {
        private void InitializeEventHandlers()
        {
            this.Shown += TabbedTortoiseGitForm_Shown;
            this.VisibleChanged += TabbedTortoiseGitForm_VisibleChanged;
            this.DragOver += TabbedTortoiseGitForm_DragOver;
            this.DragDrop += TabbedTortoiseGitForm_DragDrop;
            this.ResizeEnd += TabbedTortoiseGitForm_ResizeEnd;
            this.FormClosing += TabbedTortoiseGitForm_FormClosing;

            LogTabs.NewTabClick += LogTabs_NewTabClick;
            LogTabs.TabClosed += LogTabs_TabClosed;
            LogTabs.SelectedIndexChanged += LogTabs_SelectedIndexChanged;
            LogTabs.DragOver += TabbedTortoiseGitForm_DragOver;
            LogTabs.DragDrop += TabbedTortoiseGitForm_DragDrop;

            FavoritesMenuStrip.MouseClick += FavoritesMenuStrip_MouseClick;
            FavoritesFolderContextMenu.Closed += FavoriteItemContextMenu_Closed;
            FavoriteRepoContextMenu.Closed += FavoriteItemContextMenu_Closed;
            OpenFavoriteRepoLocationContextMenuItem.Click += OpenFavoriteRepoLocationContextMenuItem_Click;
            RemoveFavoriteContextMenuItem.Click += RemoveFavoriteItemContextMenuItem_Click;
            RemoveFavoriteFolderContextMenuItem.Click += RemoveFavoriteItemContextMenuItem_Click;

            ShowFavoritesManagerMenuItem.Click += ShowFavoritesManagerMenuItem_Click;

            OpenRepoMenuItem.Click += OpenRepoMenuItem_Click;
            FavoritesManagerMenuItem.Click += ShowFavoritesManagerMenuItem_Click;
            SettingsMenuItem.Click += SettingsMenuItem_Click;
            AboutMenuItem.Click += AboutMenuItem_Click;
            ExitMenuItem.Click += ExitMenuItem_Click;

            OpenRepoLocationTabMenuItem.Click += OpenRepoLocationTabMenuItem_Click;
            AddToFavoritesRepoTabMenuItem.Click += AddToFavoritesRepoTabMenuItem_Click;
            CloseRepoTabMenuItem.Click += CloseRepoTabMenuItem_Click;

            CheckForModifiedTabsTimer.Tick += CheckForModifiedTabsTimer_Tick;
        }

        private async void TabbedTortoiseGitForm_Shown( object sender, EventArgs e )
        {
            if( _showStartUpRepos )
            {
                await OpenStartupRepos();
            }
        }

        private async void TabbedTortoiseGitForm_VisibleChanged( object sender, EventArgs e )
        {
            LOG.DebugFormat( "Visible Changed - Visible: {0}", this.Visible );
            if( this.Visible )
            {
                DateTime lastUpdatePromptTime = Settings.Default.LastUpdatePromptTime;
                DateTime now = DateTime.Now;
                TimeSpan difference = now - lastUpdatePromptTime;
                var inject = new {
                    lastUpdatePromptTime = lastUpdatePromptTime,
                    now = now,
                    difference = difference
                };
                LOG.DebugInject( "Visible Changed - Last Update Prompt Time: {lastUpdatePromptTime} - Now: {now} - Difference: {difference}", inject );
                if( difference >= TimeSpan.FromDays( 1 ) )
                {
                    Version newestVersion = await TTG.IsUpToDate();
                    if( newestVersion != null )
                    {
                        LOG.DebugFormat( "Newest Version: {0}", newestVersion );

                        if( DialogResult.Yes == MessageBox.Show( "A new version of Tabbed TortoiseGit is available. Update now?\n\nNote: This will exit Tabbed TortoiseGit.", "New Update", MessageBoxButtons.YesNo ) )
                        {
                            LOG.Debug( "Update Prompt: Yes" );
                            Settings.Default.LastUpdatePromptTime = DateTime.MinValue;
                            Settings.Default.Save();

                            if( await TTG.UpdateApplication( newestVersion ) )
                            {
                                LOG.Debug( "Update - Exiting Application" );
                                Application.Exit();
                            }
                            else
                            {
                                LOG.Debug( "Update - Error occurred" );
                                MessageBox.Show( "There was an error updating Tabbed TortoiseGit. Try again later." );
                            }
                        }
                        else
                        {
                            LOG.Debug( "Update Prompt: No" );
                            Settings.Default.LastUpdatePromptTime = now;
                            Settings.Default.Save();

                            MessageBox.Show( "To update Tabbed TortoiseGit at a later date, go to Options->About and click Update.", "New Update", MessageBoxButtons.OK );
                        }
                    }
                }
            }
        }

        private void TabbedTortoiseGitForm_DragOver( object sender, DragEventArgs e )
        {
            if( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                String[] files = e.Data.GetData( DataFormats.FileDrop ) as String[];
                if( files != null )
                {
                    foreach( String file in files )
                    {
                        if( Directory.Exists( file ) && Git.IsRepo( file ) )
                        {
                            e.Effect = DragDropEffects.Copy;
                        }
                    }
                }
            }
        }

        private async void TabbedTortoiseGitForm_DragDrop( object sender, DragEventArgs e )
        {
            if( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                String[] files = e.Data.GetData( DataFormats.FileDrop ) as String[];
                if( files != null )
                {
                    foreach( String file in files )
                    {
                        if( Directory.Exists( file ) && Git.IsRepo( file ) )
                        {
                            await OpenLog( file );
                            e.Effect = DragDropEffects.Copy;
                        }
                    }
                }
            }
        }

        private void TabbedTortoiseGitForm_ResizeEnd( object sender, EventArgs e )
        {
            SaveWindowState();
        }

        private void TabbedTortoiseGitForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            LOG.DebugFormat( "FormClosing - Reason: {0}", e.CloseReason );

            if( e.CloseReason == CloseReason.UserClosing )
            {
                if( !this.ConfirmClose() )
                {
                    LOG.Debug( "FormClosing - Cancelled on confirm close" );
                    e.Cancel = true;
                    return;
                }
            }

            RemoveAllLogs();
            SaveWindowState();
        }

        private void Process_Exited( object sender, EventArgs e )
        {
            Process p = (Process)sender;

            LOG.DebugFormat( "Process Exited - ID: {0}", p.Id );

            this.UiBeginInvoke( (Action<Process>)RemoveLog, p );
        }

        private async void LogTabs_NewTabClick( object sender, EventArgs e )
        {
            await FindRepo();
        }

        private void LogTabs_TabClosed( object sender, TabClosedEventArgs e )
        {
            LOG.Debug( "Tab Closed" );
            CloseTab( e.Tab );
        }

        private void LogTabs_SelectedIndexChanged( object sender, EventArgs e )
        {
            if( LogTabs.SelectedTab != null )
            {
                this.Text = LogTabs.SelectedTab.Text + " - Tabbed TortoiseGit";
            }
            else
            {
                this.Text = "Tabbed TortoiseGit";
            }
        }

        private void Tab_Resize( object sender, EventArgs e )
        {
            if( this.WindowState != FormWindowState.Minimized )
            {
                Tab t = (Tab)sender;
                TabTag tag = (TabTag)t.Tag;
                ResizeTab( tag.Process, t );
            }
        }

        private async void FavoritedRepoMenuItem_Click( object sender, EventArgs e )
        {
            ToolStripItem item = (ToolStripItem)sender;
            TreeNode<FavoriteRepo> favorite = (TreeNode<FavoriteRepo>)item.Tag;
            await OpenLog( favorite.Value.Repo );
        }

        private void FavoritesMenuStrip_MouseClick( object sender, MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Right )
            {
                ToolStripItem favoriteItem = FavoritesMenuStrip.GetItemAt( e.Location );
                if( favoriteItem == null )
                {
                    FavoritesMenuContextMenu.Show( FavoritesMenuStrip, e.Location );
                }
            }
        }

        private async void FavoriteMenuItem_MouseUp( object sender, MouseEventArgs e )
        {
            ToolStripMenuItem favoriteMenuItem = (ToolStripMenuItem)sender;
            TreeNode<FavoriteRepo> favorite = (TreeNode<FavoriteRepo>)favoriteMenuItem.Tag;

            if( e.Button == MouseButtons.Right )
            {
                Point p = new Point( e.X + favoriteMenuItem.Bounds.X, e.Y + favoriteMenuItem.Bounds.Y );

                ContextMenuStrip favoriteContextMenu;
                if( favorite.Value.IsFavoriteFolder )
                {
                    favoriteContextMenu = FavoritesFolderContextMenu;
                }
                else
                {
                    favoriteContextMenu = FavoriteRepoContextMenu;
                }

                _favoriteContextMenuOpen = true;
                favoriteContextMenu.Tag = favorite;
                favoriteContextMenu.Show( favoriteMenuItem.Owner, p );
            }
            else if( e.Button == MouseButtons.Middle )
            {
                if( favorite.Value.IsFavoriteFolder )
                {
                    await OpenFavoriteRepos( favorite );
                }
            }
        }

        private void FavoriteMenuItemDropDown_Closing( object sender, ToolStripDropDownClosingEventArgs e )
        {
            if( _favoriteContextMenuOpen )
            {
                e.Cancel = true;
            }
        }

        private void FavoriteItemContextMenu_Closed( object sender, ToolStripDropDownClosedEventArgs e )
        {
            _favoriteContextMenuOpen = false;
            CloseDropDowns( FavoritesMenuStrip.Items );
        }

        private void OpenFavoriteRepoLocationContextMenuItem_Click( object sender, EventArgs e )
        {
            ToolStripMenuItem contextMenuItem = (ToolStripMenuItem)sender;
            ToolStrip contextMenu = contextMenuItem.Owner;

            TreeNode<FavoriteRepo> favorite = (TreeNode<FavoriteRepo>)contextMenu.Tag;
            Util.OpenInExplorer( favorite.Value.Repo );
        }

        private async void GitCommandFavoriteContextMenuItem_Click( object sender, EventArgs e )
        {
            ToolStripMenuItem contextMenuItem = (ToolStripMenuItem)sender;
            ToolStrip contextMenu = contextMenuItem.Owner;

            TreeNode<FavoriteRepo> favorite = (TreeNode<FavoriteRepo>)contextMenu.Tag;
            TortoiseGitCommandFunc gitCommandFunc = (TortoiseGitCommandFunc)contextMenuItem.Tag;

            await gitCommandFunc.Invoke( favorite.Value.Repo );
        }

        private void RemoveFavoriteItemContextMenuItem_Click( object sender, EventArgs e )
        {
            ToolStripMenuItem contextMenuItem = (ToolStripMenuItem)sender;
            ToolStrip contextMenu = contextMenuItem.Owner;

            TreeNode<FavoriteRepo> favorite = (TreeNode<FavoriteRepo>)contextMenu.Tag;
            RemoveFavorite( favorite );
        }

        private void ShowFavoritesManagerMenuItem_Click( object sender, EventArgs e )
        {
            if( FavoritesManagerDialog.ShowFavoritesManager() )
            {
                UpdateFavoriteReposFromSettings();
            }
        }

        private async void OpenRepoMenuItem_Click( object sender, EventArgs e )
        {
            await FindRepo();
        }

        private void SettingsMenuItem_Click( object sender, EventArgs e )
        {
            if( SettingsForm.ShowSettingsDialog() )
            {
                UpdateFromSettings( false );
            }
        }

        private void AboutMenuItem_Click( object sender, EventArgs e )
        {
            AboutBox.ShowAbout();
        }

        private void ExitMenuItem_Click( object sender, EventArgs e )
        {
            if( this.ConfirmClose() )
            {
                this.Close();
            }
        }

        private async void RecentRepoMenuItem_Click( object sender, EventArgs e )
        {
            ToolStripItem item = (ToolStripItem)sender;
            await OpenLog( item.Text );
        }

        private void OpenRepoLocationTabMenuItem_Click( object sender, EventArgs e )
        {
            TabTag t = (TabTag)LogTabs.SelectedTab.Tag;
            Util.OpenInExplorer( t.Repo );
        }

        private void AddToFavoritesRepoTabMenuItem_Click( object sender, EventArgs e )
        {
            TabTag t = (TabTag)LogTabs.SelectedTab.Tag;

            bool added = false;
            String name = null;
            while( !added )
            {
                name = InputDialog.ShowInput( "Favorite Repo Name", "Name for \"{0}\"".XFormat( t.Repo ), name );
                if( name == null )
                {
                    break;
                }
                else if( !String.IsNullOrWhiteSpace( name ) )
                {
                    AddFavoriteRepo( name, t.Repo );
                    added = true;
                }
            }
        }

        private void CloseRepoTabMenuItem_Click( object sender, EventArgs e )
        {
            LOG.Debug( "Tab Menu Item - Close Repo Click" );
            CloseTab( LogTabs.SelectedTab );
        }

        private async void GitCommandTabMenuItem_Click( object sender, EventArgs e )
        {
            ToolStripItem c = (ToolStripItem)sender;
            TortoiseGitCommandFunc gitCommandFunc = (TortoiseGitCommandFunc)c.Tag;

            TabTag tag = (TabTag)LogTabs.SelectedTab.Tag;
            await gitCommandFunc.Invoke( tag.Repo );
            Native.SendKeyDown( tag.Process.MainWindowHandle, Keys.F5 );
        }

        private async void CheckForModifiedTabsTimer_Tick( object sender, EventArgs e )
        {
            if( _checkForModifiedTabsSemaphore.WaitOne( 0 ) )
            {
                try
                {
                    for( int i = 0; i < LogTabs.TabCount; i++ )
                    {
                        Tab tab = LogTabs.Tabs[ i ];
                        TabTag tag = (TabTag)tab.Tag;

                        tag.Modified = await Git.IsModified( tag.Repo );

                        UpdateTabDisplay( tab );
                    }
                }
                finally
                {
                    _checkForModifiedTabsSemaphore.Release();
                }
            }
        }

        private async void NewTabHotKey_HotKeyPressed( object sender, EventArgs e )
        {
            LOG.Debug( "HotKey - New Tab" );
            await FindRepo();
        }

        private void NextTabHotKey_HotKeyPressed( object sender, EventArgs e )
        {
            LOG.Debug( "HotKey - Next Tab" );
            LogTabs.NextTab();
        }

        private void PreviousTabHotKey_HotKeyPressed( object sender, EventArgs e )
        {
            LOG.Debug( "HotKey - Previous Tab" );
            LogTabs.PreviousTab();
        }

        private void CloseTabHotKey_HotKeyPressed( object sender, EventArgs e )
        {
            LOG.Debug( "HotKey - Close Tab" );
            CloseTab( LogTabs.SelectedTab );
        }

        private async void ReopenClosedTabHotKey_HotKeyPressed( object sender, EventArgs e )
        {
            LOG.Debug( "HotKey - Reopen Closed Tab" );
            if( _closedRepos.Count > 0 )
            {
                String repo = _closedRepos.Pop();

                LOG.DebugFormat( "HotKey - Reopen Closed Tab - Reopening: {0}", repo );

                await OpenLog( repo );
            }
        }
    }
}
