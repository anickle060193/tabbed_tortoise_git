using Common;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            Settings.Default.PropertyChanged += Settings_PropertyChanged;

            this.Load += TabbedTortoiseGitForm_Load;
            this.Shown += TabbedTortoiseGitForm_Shown;
            this.DragOver += TabbedTortoiseGitForm_DragOver;
            this.DragDrop += TabbedTortoiseGitForm_DragDrop;
            this.ResizeEnd += TabbedTortoiseGitForm_ResizeEnd;
            this.FormClosing += TabbedTortoiseGitForm_FormClosing;

            SplitLayout.SplitterMoved += SplitLayout_SplitterMoved;

            LogTabs.NewTabClick += LogTabs_NewTabClick;
            LogTabs.TabAdded += LogTabs_TabAdded;
            LogTabs.TabRemoved += LogTabs_TabRemoved;
            LogTabs.TabClosed += LogTabs_TabClosed;
            LogTabs.TabPulledOut += LogTabs_TabPulledOut;
            LogTabs.SelectedTabChanged += LogTabs_SelectedTabChanged;
            LogTabs.DragOver += TabbedTortoiseGitForm_DragOver;
            LogTabs.DragDrop += TabbedTortoiseGitForm_DragDrop;

            FavoritesMenuStrip.MouseClick += FavoritesMenuStrip_MouseClick;
            FavoriteRepoContextMenu.Closed += FavoriteItemContextMenu_Closed;
            FavoritesFolderContextMenu.Closed += FavoriteItemContextMenu_Closed;
            FavoriteReposDirectoryContextMenu.Closed += FavoriteItemContextMenu_Closed;

            OpenFavoriteRepoLocationContextMenuItem.Click += OpenFavoriteRepoLocationContextMenuItem_Click;
            OpenFavoriteReposDirectoryLocationContextMenuItem.Click += OpenFavoriteRepoLocationContextMenuItem_Click;

            OpenFavoriteWithReferencesContextMenuItem.Click += OpenFavoriteWithReferencesContextMenuItem_Click;

            EditFavoriteContextMenuItem.Click += EditFavoriteContextMenuItem_Click;
            EditFavoriteFolderContextMenuItem.Click += EditFavoriteContextMenuItem_Click;
            EditFavoriteReposDirectoryContextMenuItem.Click += EditFavoriteContextMenuItem_Click;

            RemoveFavoriteContextMenuItem.Click += RemoveFavoriteItemContextMenuItem_Click;
            RemoveFavoriteFolderContextMenuItem.Click += RemoveFavoriteItemContextMenuItem_Click;
            RemoveFavoriteReposDirectoryContextMenuItem.Click += RemoveFavoriteItemContextMenuItem_Click;

            ShowFavoritesManagerMenuItem.Click += ShowFavoritesManagerMenuItem_Click;

            OpenRepoMenuItem.Click += OpenRepoMenuItem_Click;
            FavoritesManagerMenuItem.Click += ShowFavoritesManagerMenuItem_Click;
            SettingsMenuItem.Click += SettingsMenuItem_Click;
            ShowDebugLogMenuItem.Click += ShowDebugLogMenuItem_Click;
            AboutMenuItem.Click += AboutMenuItem_Click;
            ExitMenuItem.Click += ExitMenuItem_Click;

            OpenRepoLocationTabMenuItem.Click += OpenRepoLocationTabMenuItem_Click;
            AddToFavoritesRepoTabMenuItem.Click += AddToFavoritesRepoTabMenuItem_Click;
            OpenWithReferencesRepoTabMenuItem.Click += OpenWithReferencesRepoTabMenuItem_Click;
            DuplicateRepoTabMenuItem.Click += DuplicateRepoTabMenuItem_Click;
            CloseRepoTabMenuItem.Click += CloseRepoTabMenuItem_Click;

            BackgroundFasterFetch.Click += BackgroundFasterFetch_Click;
            BackgroundFasterFetchProgress.Click += BackgroundFasterFetchProgress_Click;

            ReferencesTreeView.AfterSelect += ReferencesTreeView_AfterSelect;

            ReferencesFilter.TextChanged += ReferencesFilter_TextChanged;
            ReferencesListBox.MouseDoubleClick += ReferencesListBox_MouseDoubleClick;
            ReferencesListBox.MouseUp += ReferencesListBox_MouseUp;

            ReferenceContextMenuOpenLogMenuItem.Click += ReferencesListBoxReferenceContextMenu_Click;

            ModifiedRepoCheckBackgroundWorker.DoWork += ModifiedRepoCheckBackgroundWorker_DoWork;
        }

        private async void Settings_PropertyChanged( object? sender, PropertyChangedEventArgs e )
        {
            if( e.PropertyName == nameof( Settings.Default.SplitLayoutSplitterDistance )
             || e.PropertyName == nameof( Settings.Default.HideReferencesDisplay ) )
            {
                UpdateUiLayoutFromSettings();
            }
            else if( e.PropertyName == nameof( Settings.Default.DeveloperSettingsEnabled ) )
            {
                UpdateHitTestFromSettings();
            }
            else if( e.PropertyName == nameof( Settings.Default.ShowHitTest ) )
            {
                UpdateHitTestFromSettings();
            }
            else if( e.PropertyName == nameof( Settings.Default.IndicateModifiedTabs )
                  || e.PropertyName == nameof( Settings.Default.ModifiedTabFont )
                  || e.PropertyName == nameof( Settings.Default.ModifiedTabFontColor )
                  || e.PropertyName == nameof( Settings.Default.NormalTabFont )
                  || e.PropertyName == nameof( Settings.Default.NormalTabFontColor ) )
            {
                UpdateModifiedTabsStatusFromSettings();
            }
            else if( e.PropertyName == nameof( Settings.Default.RecentRepos ) )
            {
                UpdateRecentReposFromSettings();
            }
            else if( e.PropertyName == nameof( Settings.Default.TabContextMenuGitActions )
                  || e.PropertyName == nameof( Settings.Default.CustomActionsString ) )
            {
                UpdateRepoContextMenusFromSettings();
            }
            else if( e.PropertyName == nameof( Settings.Default.FavoriteReposJsonString ) )
            {
                await UpdateFavoriteReposFromSettings();
            }
            else
            {
                LOG.Debug( $"{nameof( Settings_PropertyChanged )} - Unhandled setting change: {e.PropertyName}" );
            }
        }

        private async void TabbedTortoiseGitForm_Load( object? sender, EventArgs e )
        {
            await UpdateFromSettings( true );
        }

        private async void TabbedTortoiseGitForm_Shown( object? sender, EventArgs e )
        {
            LOG.Debug( $"{nameof( TabbedTortoiseGitForm_Shown )}" );

            if( !_skipUpdateCheck )
            {
                DateTime lastUpdatePromptTime = Settings.Default.LastUpdatePromptTime;
                DateTime now = DateTime.Now;
                TimeSpan difference = now - lastUpdatePromptTime;
                LOG.Debug( $"{nameof( TabbedTortoiseGitForm_Shown )} - Last Update Prompt Time: {lastUpdatePromptTime} - Now: {now} - Difference: {difference}" );
                if( difference >= TimeSpan.FromDays( 1 ) )
                {
                    Version? newestVersion = await TTG.IsUpToDate();
                    if( newestVersion != null )
                    {
                        LOG.Debug( $"Newest Version: {newestVersion}" );

                        if( DialogResult.Yes == MessageBox.Show( $"Version {newestVersion} of Tabbed TortoiseGit is available. Update now?\n\nNote: This will exit Tabbed TortoiseGit.", "New Update", MessageBoxButtons.YesNo ) )
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

            if( Settings.Default.CheckTortoiseGitOnPath )
            {
                if( !( await GitAction.CanAccessTortoiseGit() ) )
                {
                    using ConfirmationDialog dialog = new ConfirmationDialog( "Cannot access TortoiseGit", "TortoiseGit does not appear to be on PATH (this will prevent Tabbed TortoiseGit from being able to open logs). Update PATH environment variable to include directory for TortoiseGitProc.exe." );
                    if( dialog.ShowDialog() == DialogResult.OK )
                    {
                        if( dialog.DoNotAskAgain )
                        {
                            Settings.Default.CheckTortoiseGitOnPath = false;
                            Settings.Default.Save();
                        }
                    }
                }
            }

            if( _showStartUpRepos )
            {
                await OpenStartupRepos();
            }

            if( Settings.Default.ShouldShowChangelog )
            {
                Settings.Default.ShouldShowChangelog = false;

                if( Settings.Default.ShowChangelogOnUpdate )
                {
                    ChangelogDialog.ShowChangelog();
                }
            }
        }

        private void TabbedTortoiseGitForm_DragOver( object? sender, DragEventArgs e )
        {
            if( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                if( e.Data.GetData( DataFormats.FileDrop ) is String[] files )
                {
                    foreach( String file in files )
                    {
                        if( Directory.Exists( file ) && Git.IsInRepo( file ) )
                        {
                            e.Effect = DragDropEffects.Copy;
                        }
                    }
                }
            }
        }

        private async void TabbedTortoiseGitForm_DragDrop( object? sender, DragEventArgs e )
        {
            if( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                if( e.Data.GetData( DataFormats.FileDrop ) is String[] files )
                {
                    foreach( String file in files )
                    {
                        if( Directory.Exists( file ) && Git.IsInRepo( file ) )
                        {
                            await OpenLog( file );
                            e.Effect = DragDropEffects.Copy;
                        }
                    }
                }
            }
        }

        private void TabbedTortoiseGitForm_ResizeEnd( object? sender, EventArgs e )
        {
            SaveWindowState();
        }

        private void TabbedTortoiseGitForm_FormClosing( object? sender, FormClosingEventArgs e )
        {
            LOG.Debug( $"{nameof( TabbedTortoiseGitForm_FormClosing )} - Reason: {e.CloseReason}" );

            if( e.CloseReason == CloseReason.UserClosing )
            {
                if( !this.ConfirmClose() )
                {
                    LOG.Debug( $"{nameof( TabbedTortoiseGitForm_FormClosing )} - Cancelled on confirm close" );
                    e.Cancel = true;
                    return;
                }
            }

            LogTabs.TabRemoved -= LogTabs_TabRemoved;
            LogTabs.TabClosed -= LogTabs_TabClosed;

            RemoveAllLogs();
            SaveWindowState();
        }

        private void SplitLayout_SplitterMoved( object? sender, SplitterEventArgs e )
        {
            Settings.Default.SplitLayoutSplitterDistance = SplitLayout.SplitterDistance;
            Settings.Default.Save();
        }

        private async void LogTabs_NewTabClick( object? sender, EventArgs e )
        {
            await FindRepo();
        }

        private void LogTabs_TabAdded( object? sender, TabAddedEventArgs e )
        {
            LOG.Debug( $"{nameof( LogTabs_TabAdded )} - Tab: {e.Tab}" );

            RegisterExistingTab( e.Tab );
        }

        private void LogTabs_TabRemoved( object? sender, TabRemovedEventArgs e )
        {
            LOG.Debug( $"{nameof( LogTabs_TabRemoved )} - Tab: {e.Tab}" );

            this.RemoveLogProcess( e.Tab.Controller().Process, false );

            CheckIfLastTab();
        }

        private void LogTabs_TabClosed( object? sender, TabClosedEventArgs e )
        {
            LOG.Debug( nameof( LogTabs_TabClosed ) );

            CloseTab( e.Tab );
        }

        private void LogTabs_TabPulledOut( object? sender, TabPulledOutEventArgs e )
        {
            ProgramForm.Instance.CreateNewFromTab( e.Tab, e.Location );
        }

        private async void LogTabs_SelectedTabChanged( object? sender, EventArgs e )
        {
            if( LogTabs.SelectedTab != null )
            {
                this.Text = LogTabs.SelectedTab.Text + " - Tabbed TortoiseGit";
            }
            else
            {
                this.Text = "Tabbed TortoiseGit";
            }

            UpdateIcon();

            await UpdateReferencesTreeView();

            UpdateToolStripFasterFetch();
            await UpdateToolStripSubmodules();
        }

        private async void FavoriteRepoMenuItem_Click( object? sender, EventArgs e )
        {
            if( sender is not ToolStripItem item
             || item.Tag is not Favorite favorite )
            {
                return;
            }

            if( favorite is FavoriteRepo repo )
            {
                await OpenLog( repo.Repo, repo.References );
            }
            else if( favorite is FavoriteReposDirectoryRepo subrepo )
            {
                await OpenLog( subrepo.Repo );
            }
        }

        private void FavoritesMenuStrip_MouseClick( object? sender, MouseEventArgs e )
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

        private async void FavoriteMenuItem_MouseUp( object? sender, MouseEventArgs e )
        {
            if( sender is not ToolStripMenuItem favoriteMenuItem
             || favoriteMenuItem.Tag is not Favorite favorite )
            {
                return;
            }

            if( e.Button == MouseButtons.Right )
            {
                Point p = new Point( e.X + favoriteMenuItem.Bounds.X, e.Y + favoriteMenuItem.Bounds.Y );

                ContextMenuStrip favoriteContextMenu;
                if( favorite is FavoriteFolder )
                {
                    favoriteContextMenu = FavoritesFolderContextMenu;
                }
                else if( favorite is FavoriteRepo )
                {
                    favoriteContextMenu = FavoriteRepoContextMenu;

                    EditFavoriteContextMenuItem.Visible = true;
                    RemoveFavoriteContextMenuItem.Visible = true;
                }
                else if( favorite is FavoriteReposDirectoryRepo )
                {
                    favoriteContextMenu = FavoriteRepoContextMenu;

                    EditFavoriteContextMenuItem.Visible = false;
                    RemoveFavoriteContextMenuItem.Visible = false;
                }
                else if( favorite is FavoriteReposDirectory )
                {
                    favoriteContextMenu = FavoriteReposDirectoryContextMenu;
                }
                else
                {
                    return;
                }

                _favoriteContextMenuOpen = true;
                favoriteContextMenu.Tag = favorite;
                favoriteContextMenu.Show( favoriteMenuItem.Owner, p );
            }
            else if( e.Button == MouseButtons.Middle )
            {
                await OpenFavoriteRepos( favorite );
            }
        }

        private void FavoriteMenuItemDropDown_Closing( object? sender, ToolStripDropDownClosingEventArgs e )
        {
            if( _favoriteContextMenuOpen )
            {
                e.Cancel = true;
            }
        }

        private void FavoriteItemContextMenu_Closed( object? sender, ToolStripDropDownClosedEventArgs e )
        {
            _favoriteContextMenuOpen = false;
            CloseDropDowns( FavoritesMenuStrip.Items );
        }

        private void OpenFavoriteRepoLocationContextMenuItem_Click( object? sender, EventArgs e )
        {
            if( sender is not ToolStripMenuItem contextMenuItem
             || contextMenuItem.Owner.Tag is not Favorite favorite )
            {
                return;
            }

            String location;
            if( favorite is FavoriteRepo repo )
            {
                location = repo.Repo;
            }
            else if( favorite is FavoriteReposDirectory dir )
            {
                location = dir.Directory;
            }
            else if( favorite is FavoriteReposDirectoryRepo subrepo )
            {
                location = subrepo.Repo;
            }
            else
            {
                return;
            }

            Util.OpenInExplorer( location );
        }

        private async void OpenFavoriteWithReferencesContextMenuItem_Click( object? sender, EventArgs e )
        {
            if( sender is not ToolStripMenuItem contextMenuItem
             || contextMenuItem.Owner.Tag is not Favorite favorite )
            {
                return;
            }

            String repo;
            if( favorite is FavoriteRepo r )
            {
                repo = r.Repo;
            }
            else if( favorite is FavoriteReposDirectoryRepo subrepo )
            {
                repo = subrepo.Repo;
            }
            else
            {
                return;
            }

            using ReferencesDialog dialog = new ReferencesDialog( repo );
            if( dialog.ShowDialog() == DialogResult.OK )
            {
                await OpenLog( repo, dialog.SelectedReferences );
            }
        }

        private async void GitCommandFavoriteContextMenuItem_Click( object? sender, EventArgs e )
        {
            if( sender is not ToolStripMenuItem contextMenuItem
             || contextMenuItem.Owner.Tag is not Favorite favorite
             || contextMenuItem.Tag is not GitActionFunc gitActionFunc )
            {
                return;
            }

            String repo;
            if( favorite is FavoriteRepo r )
            {
                repo = r.Repo;
            }
            else if( favorite is FavoriteReposDirectoryRepo subrepo )
            {
                repo = subrepo.Repo;
            }
            else
            {
                return;
            }

            await gitActionFunc.Invoke( repo );
        }

        private async void CustomActionFavoriteContextMenuItem_Click( object? sender, EventArgs e )
        {
            if( sender is not ToolStripMenuItem contextMenuItem
             || contextMenuItem.Owner.Tag is not Favorite favorite
             || contextMenuItem.Tag is not CustomAction customAction )
            {
                return;
            }

            String repo;
            if( favorite is FavoriteRepo r )
            {
                repo = r.Repo;
            }
            else if( favorite is FavoriteReposDirectoryRepo subrepo )
            {
                repo = subrepo.Repo;
            }
            else
            {
                return;
            }

            await RunCustomAction( null, customAction, repo );
        }

        private void EditFavoriteContextMenuItem_Click( object? sender, EventArgs e )
        {
            if( _favoriteRepos is null )
            {
                LOG.Error( $"{nameof( EditFavoriteContextMenuItem_Click )} - Favorite repos is null" );
                return;
            }

            if( sender is not ToolStripMenuItem contextMenuItem
             || contextMenuItem.Owner.Tag is not Favorite favorite )
            {
                return;
            }

            Favorite? newFavorite = null;
            if( favorite is FavoriteFolder folder )
            {
                using FavoriteFolderCreatorDialog dialog = FavoriteFolderCreatorDialog.FromFavoriteFolder( folder );
                if( dialog.ShowDialog() == DialogResult.OK )
                {
                    newFavorite = dialog.ToFavoriteFolder();
                }
            }
            else if( favorite is FavoriteRepo repo )
            {
                using FavoriteRepoCreatorDialog dialog = FavoriteRepoCreatorDialog.FromFavoriteRepo( repo );
                if( dialog.ShowDialog() == DialogResult.OK )
                {
                    newFavorite = dialog.ToFavoriteRepo();
                }
            }
            else if( favorite is FavoriteReposDirectory directory )
            {
                using FavoriteReposDirectoryCreatorDialog dialog = FavoriteReposDirectoryCreatorDialog.FromFavoriteReposDirectory( directory );
                if( dialog.ShowDialog() == DialogResult.OK )
                {
                    newFavorite = dialog.ToFavoriteReposDirectory();
                }
            }
            else
            {
                LOG.Error( $"{nameof( EditFavoriteContextMenuItem_Click )} - Unknown favorite type: {favorite}" );
            }

            if( newFavorite != null )
            {
                if( !_favoriteRepos.Replace( favorite, newFavorite ) )
                {
                    LOG.Error( $"{nameof( EditFavoriteContextMenuItem_Click )} - Failed to replace old favorite: {favorite} - {newFavorite}" );
                    return;
                }

                Settings.Default.FavoriteRepos = _favoriteRepos!;
                Settings.Default.Save();
            }
        }

        private void RemoveFavoriteItemContextMenuItem_Click( object? sender, EventArgs e )
        {
            if( sender is not ToolStripMenuItem contextMenuItem
             || contextMenuItem.Owner.Tag is not Favorite favorite )
            {
                return;
            }

            RemoveFavorite( favorite );
        }

        private void ShowFavoritesManagerMenuItem_Click( object? sender, EventArgs e )
        {
            FavoritesManagerDialog.ShowFavoritesManager();
        }

        private async void OpenRepoMenuItem_Click( object? sender, EventArgs e )
        {
            await FindRepo();
        }

        private void SettingsMenuItem_Click( object? sender, EventArgs e )
        {
             SettingsForm.ShowSettingsDialog();
        }

        private void ShowDebugLogMenuItem_Click( object? sender, EventArgs e )
        {
            FileAppender? rootAppender = ( (Hierarchy)LogManager.GetRepository() ).Root.Appenders.OfType<FileAppender>().FirstOrDefault();
            if( rootAppender != null )
            {
                Util.OpenInExplorer( rootAppender.File );
            }
        }

        private void AboutMenuItem_Click( object? sender, EventArgs e )
        {
            AboutBox.ShowAbout();
        }

        private void ExitMenuItem_Click( object? sender, EventArgs e )
        {
            this.Close();
        }

        private async void RecentRepoMenuItem_Click( object? sender, EventArgs e )
        {
            if( sender is not ToolStripItem item )
            {
                return;
            }

            await OpenLog( item.Text );
        }

        private void OpenRepoLocationTabMenuItem_Click( object? sender, EventArgs e )
        {
            Util.OpenInExplorer( LogTabs.SelectedTab!.Controller().RepoItem );
        }

        private void AddToFavoritesRepoTabMenuItem_Click( object? sender, EventArgs e )
        {
            TabControllerTag tag = LogTabs.SelectedTab!.Controller();

            AddFavoriteRepo( tag.RepoItem );
        }

        private async void OpenWithReferencesRepoTabMenuItem_Click( object? sender, EventArgs e )
        {
            TabControllerTag tag = LogTabs.SelectedTab!.Controller();
            String repo = Git.GetBaseRepoDirectoryOrError( tag.RepoItem );

            using ReferencesDialog dialog = new ReferencesDialog( repo );
            if( dialog.ShowDialog() == DialogResult.OK )
            {
                await OpenLog( tag.RepoItem, dialog.SelectedReferences );
            }
        }

        private async void DuplicateRepoTabMenuItem_Click( object? sender, EventArgs e )
        {
            await DuplicateTab( LogTabs.SelectedTab! );
        }

        private void CloseRepoTabMenuItem_Click( object? sender, EventArgs e )
        {
            LOG.Debug( nameof( CloseRepoTabMenuItem_Click ) );
            CloseTab( LogTabs.SelectedTab! );
        }

        private async void GitCommandTabMenuItem_Click( object? sender, EventArgs e )
        {
            if( sender is not ToolStripItem c
             || c.Tag is not GitActionFunc gitActionFunc )
            {
                return;
            }

            TabControllerTag tag = LogTabs.SelectedTab!.Controller();
            await RunGitAction( tag, gitActionFunc );
        }

        private async void CustomActionTabMenuItem_Click( object? sender, EventArgs e )
        {
            if( sender is not ToolStripItem c
             || c.Tag is not CustomAction customAction )
            {
                return;
            }

            TabControllerTag tag = LogTabs.SelectedTab!.Controller();

            await RunCustomAction( tag, customAction, tag.RepoItem );
        }

        private async void ModifiedRepoCheckBackgroundWorker_DoWork( object? sender, DoWorkEventArgs e )
        {
            while( true )
            {
                for( int i = 0; i < LogTabs.TabCount; i++ )
                {
                    if( !Settings.Default.IndicateModifiedTabs )
                    {
                        return;
                    }

                    TabControllerTag tag = LogTabs.Tabs[ i ].Controller();

                    tag.Modified = await Git.IsModified( tag.RepoItem );
                }

                if( !Settings.Default.IndicateModifiedTabs )
                {
                    return;
                }

                Thread.Sleep( Settings.Default.CheckForModifiedTabsInterval );
            }
        }

        private void BackgroundFasterFetch_Click( object? sender, EventArgs e )
        {
            TabControllerTag? controller = this.LogTabs.SelectedTab?.Controller();
            if( controller != null )
            {
                if( controller.BackgroundFasterFetchDialog?.Completed == true )
                {
                    controller.BackgroundFasterFetchDialog.Close();
                    controller.BackgroundFasterFetchDialog = null;
                }

                if( controller.BackgroundFasterFetchDialog != null )
                {
                    return;
                }

                String repo = Git.GetBaseRepoDirectoryOrError( controller.RepoItem );

                ProgressDialog dialog = FastFetchDialog.PrepareBackgroundFasterFetch( repo );
                controller.BackgroundFasterFetchDialog = dialog;

                dialog.ProgressCompleted += delegate ( object? sender2, EventArgs e2 )
                {
                    if( !controller.Process.HasExited )
                    {
                        Native.SendKeyDown( controller.Process.MainWindowHandle, Keys.F5 );
                    }

                    if( !dialog.Visible )
                    {
                        dialog.Close();
                    }
                };

                dialog.FormClosed += delegate ( object? sender2, FormClosedEventArgs e2 )
                {
                    controller.BackgroundFasterFetchDialog = null;

                    UpdateToolStripFasterFetch();
                };

                dialog.ProgressChanged += BackgroundFasterFetchDialog_ProgressChanged;
                dialog.ProgressCompleted += BackgroundFasterFetchDialog_ProgressChanged;

                dialog.DoProgress();

                UpdateToolStripFasterFetch();
            }
        }

        private void BackgroundFasterFetchProgress_Click( object? sender, EventArgs e )
        {
            this.LogTabs.SelectedTab?.Controller().BackgroundFasterFetchDialog?.Show();
        }

        private void ReferencesTreeView_AfterSelect( object? sender, TreeViewEventArgs e )
        {
            UpdateReferencesListBox();
        }

        private void ReferencesFilter_TextChanged( object? sender, EventArgs e )
        {
            UpdateReferencesListBox();
        }

        private async void ReferencesListBox_MouseDoubleClick( object? sender, MouseEventArgs e )
        {
            TabControllerTag? controller = this.LogTabs.SelectedTab?.Controller();
            if( controller == null )
            {
                return;
            }

            DisplayReference reference = (DisplayReference)ReferencesListBox.SelectedItem;

            await OpenLog( controller.RepoItem, new[] { reference.Reference } );
        }

        private void ReferencesListBox_MouseUp( object? sender, MouseEventArgs e )
        {
            ReferencesListBox.SelectedIndex = ReferencesListBox.IndexFromPoint( e.Location );

            if( e.Button != MouseButtons.Right )
            {
                return;
            }

            DisplayReference reference = (DisplayReference)ReferencesListBox.SelectedItem;

            ReferencesListBoxReferenceContextMenu.Tag = reference.Reference;
            ReferencesListBoxReferenceContextMenu.Show( ReferencesListBox, e.X, e.Y );
        }

        private async void ReferencesListBoxReferenceContextMenu_Click( object? sender, EventArgs e )
        {
            TabControllerTag? controller = this.LogTabs.SelectedTab?.Controller();
            if( controller == null )
            {
                return;
            }

            String? reference = (String?)ReferencesListBoxReferenceContextMenu.Tag;
            if( reference == null )
            {
                return;
            }

            await OpenLog( controller.RepoItem, new [] { reference } );
        }

        private void BackgroundFasterFetchDialog_ProgressChanged( object? sender, EventArgs e )
        {
            TabControllerTag? controller = this.LogTabs.SelectedTab?.Controller();
            if( controller != null )
            {
                ProgressDialog? dialog = sender as ProgressDialog;

                if( dialog == controller.BackgroundFasterFetchDialog )
                {
                    UpdateToolStripFasterFetch();
                }
            }
        }

        private async void SubmoduleToolStripDropDownItem_Click( object? sender, EventArgs e )
        {
            if( ( sender as ToolStripItem )?.Tag is String submodule )
            {
                await OpenLog( submodule );
            }
        }
    }
}
