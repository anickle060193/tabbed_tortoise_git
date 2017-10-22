using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;
using System.Configuration;
using Microsoft.WindowsAPICodePack.Dialogs;
using LibGit2Sharp;
using Newtonsoft.Json;
using log4net;
using log4net.Config;
using Tabs;
using System.IO;
using System.Collections.Immutable;

namespace TabbedTortoiseGit
{
    public partial class TabbedTortoiseGitForm : Form
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( TabbedTortoiseGitForm ) );

        private static readonly ImmutableDictionary<KeyboardShortcuts, GitActionFunc> KEYBOARD_SHORTCUT_ACTIONS = new Dictionary<KeyboardShortcuts, GitActionFunc>()
        {
            { KeyboardShortcuts.Commit,                 GitAction.Commit                },
            { KeyboardShortcuts.FastFetch,              GitAction.FastFetch             },
            { KeyboardShortcuts.FasterFetch,            GitAction.FasterFetch           },
            { KeyboardShortcuts.FastSubmoduleUpdate,    GitAction.FastSubmoduleUpdate   },
            { KeyboardShortcuts.FasterSubmoduleUpdate,  GitAction.FasterSubmoduleUpdate },
            { KeyboardShortcuts.Fetch,                  GitAction.Fetch                 },
            { KeyboardShortcuts.Pull,                   GitAction.Pull                  },
            { KeyboardShortcuts.Push,                   GitAction.Push                  },
            { KeyboardShortcuts.Rebase,                 GitAction.Rebase                },
            { KeyboardShortcuts.SubmoduleUpdate,        GitAction.SubmoduleUpdate       },
            { KeyboardShortcuts.SwitchCheckout,         GitAction.Switch                }
        }.ToImmutableDictionary();

        private static readonly Keys[] FORWARD_KEYS = new[]
        {
            Keys.F5,
            Keys.Up,
            Keys.Down
        };

        private readonly Dictionary<int, TabControllerTag> _tags = new Dictionary<int, TabControllerTag>();
        private readonly CommonOpenFileDialog _folderDialog;
        private readonly bool _showStartUpRepos;
        private readonly Point _createdAtPoint;
        private readonly Stack<String> _closedRepos = new Stack<String>();

        private TreeNode<FavoriteRepo> _favoriteRepos;

        private bool _favoriteContextMenuOpen;

        public TabbedTortoiseGitForm( bool showStartUpRepos, Point createdAtPoint )
        {
            LOG.DebugFormat( "Constructor - Show Start-up Repos: {0}", showStartUpRepos );

            InitializeComponent();
            InitializeEventHandlers();

            _showStartUpRepos = showStartUpRepos;
            _createdAtPoint = createdAtPoint;

            _folderDialog = new CommonOpenFileDialog();
            _folderDialog.IsFolderPicker = true;

            this.Icon = Resources.TortoiseIcon;

            UpdateFromSettings( true );
        }

        protected override void OnHandleCreated( EventArgs e )
        {
            base.OnHandleCreated( e );

            KeyboardShortcutsManager.Instance.AddHandle( this.Handle );
        }

        protected override void DestroyHandle()
        {
            KeyboardShortcutsManager.Instance.RemoveHandle( this.Handle );

            base.DestroyHandle();
        }

        protected override bool ProcessCmdKey( ref Message msg, Keys keyData )
        {
            if( FORWARD_KEYS.Any( k => keyData == k ) )
            {
                TabControllerTag tag = LogTabs.SelectedTab?.Controller();
                if( tag != null )
                {
                    Native.SetForegroundWindow( tag.Process.MainWindowHandle );
                    Native.SendKeyDown( tag.Process.MainWindowHandle, keyData );
                    return true;
                }
            }

            return base.ProcessCmdKey( ref msg, keyData );
        }

        private void UpdateFromSettings( bool updateWindowState )
        {
            if( updateWindowState )
            {
                if( !Settings.Default.Size.IsEmpty )
                {
                    this.Size = Settings.Default.Size;
                    this.CenterToScreen();
                }

                if( !_createdAtPoint.IsEmpty )
                {
                    this.StartPosition = FormStartPosition.Manual;

                    Rectangle formBounds = this.Bounds;
                    Rectangle tabBounds = LogTabs.RectangleToScreen( LogTabs.GetTabRect( 0 ) );
                    int tabX = tabBounds.Left - formBounds.Left;
                    int tabY = tabBounds.Top - formBounds.Top;

                    int x = _createdAtPoint.X - tabX - tabBounds.Width / 2;
                    int y = _createdAtPoint.Y - tabY - tabBounds.Height / 2;
                    this.Location = new Point( x, y );
                }

                if( Settings.Default.Maximized )
                {
                    this.WindowState = FormWindowState.Maximized;
                }
            }

            if( Settings.Default.DeveloperSettingsEnabled )
            {
                LogTabs.ShowHitTest = Settings.Default.ShowHitTest;
            }
            else
            {
                LogTabs.ShowHitTest = false;
            }

            if( Settings.Default.IndicateModifiedTabs
             && !ModifiedRepoCheckBackgroundWorker.IsBusy )
            {
                ModifiedRepoCheckBackgroundWorker.RunWorkerAsync();
            }

            lock( _tags )
            {
                foreach( TabControllerTag tag in _tags.Values )
                {
                    tag.UpdateTabDisplay();
                    tag.UpdateIcon();
                }
            }

            UpdateRecentReposFromSettings();
            UpdateRepoContextMenusFromSettings();
            UpdateFavoriteReposFromSettings();
        }

        private void UpdateRecentReposFromSettings()
        {
            NewTabContextMenu.SuspendLayout();

            RecentReposMenu.DropDownItems.Clear();
            NewTabContextMenu.Items.Clear();

            foreach( String repo in Settings.Default.RecentRepos )
            {
                RecentReposMenu.DropDownItems.Add( repo ).Click += RecentRepoMenuItem_Click;
                NewTabContextMenu.Items.Add( repo ).Click += RecentRepoMenuItem_Click;
            }

            RecentReposMenu.Enabled = RecentReposMenu.HasDropDownItems;
            NewTabContextMenu.Enabled = NewTabContextMenu.Items.Count != 0;

            NewTabContextMenu.ResumeLayout();
        }

        private void UpdateRepoContextMenusFromSettings()
        {
            TabContextMenu.SuspendLayout();
            FavoriteRepoContextMenu.SuspendLayout();

            TabContextMenu.Items.Clear();
            TabContextMenu.Items.Add( OpenRepoLocationTabMenuItem );
            TabContextMenu.Items.Add( AddToFavoritesRepoTabMenuItem );

            FavoriteRepoContextMenu.Items.Clear();
            FavoriteRepoContextMenu.Items.Add( OpenFavoriteRepoLocationContextMenuItem );

            List<GitAction> actions = Settings.Default.TabContextMenuGitActions
                                                    .Where( action => GitAction.ACTIONS.ContainsKey( action ) )
                                                    .Select( action => GitAction.ACTIONS[ action ] ).ToList();
            if( actions.Count > 0 )
            {
                TabContextMenu.Items.Add( "-" );

                FavoriteRepoContextMenu.Items.Add( "-" );

                foreach( GitAction action in actions )
                {
                    ToolStripItem tabMenuItem = TabContextMenu.Items.Add( action.Name, action.Icon );
                    tabMenuItem.Click += GitCommandTabMenuItem_Click;
                    tabMenuItem.Tag = action.Func;

                    ToolStripItem favoriteMenuItem = FavoriteRepoContextMenu.Items.Add( action.Name, action.Icon );
                    favoriteMenuItem.Click += GitCommandFavoriteContextMenuItem_Click;
                    favoriteMenuItem.Tag = action.Func;
                }
            }

            TabContextMenu.Items.Add( "-" );
            TabContextMenu.Items.Add( CloseRepoTabMenuItem );

            FavoriteRepoContextMenu.Items.Add( "-" );
            FavoriteRepoContextMenu.Items.Add( RemoveFavoriteContextMenuItem );

            TabContextMenu.ResumeLayout();
            FavoriteRepoContextMenu.ResumeLayout();
        }

        private void UpdateFavoriteReposFromSettings()
        {
            FavoritesMenuStrip.SuspendLayout();

            FavoritesMenuStrip.Items.Clear();

            _favoriteRepos = Settings.Default.FavoriteRepos;

            CreateFavoritesMenu( _favoriteRepos, FavoritesMenuStrip.Items );

            FavoritesMenuStrip.ResumeLayout();

            foreach( Tab tab in LogTabs.Tabs )
            {
                tab.Controller().UpdateIcon();
            }

            UpdateIcon();
        }

        private void CreateFavoritesMenu( TreeNode<FavoriteRepo> favorites, ToolStripItemCollection menuItems )
        {
            foreach( TreeNode<FavoriteRepo> favorite in favorites.Children )
            {
                ToolStripMenuItem item = new ToolStripMenuItem( favorite.Value.Name );
                item.ToolTipText = favorite.Value.Repo;
                Bitmap icon;
                if( favorite.Value.IsFavoriteFolder )
                {
                    icon = Resources.FolderFolder;
                }
                else if( favorite.Value.IsDirectory )
                {
                    icon = Resources.Folder;
                    item.Click += FavoriteRepoMenuItem_Click;
                }
                else
                {
                    icon = Resources.File;
                    item.Click += FavoriteRepoMenuItem_Click;
                }
                item.Image = Util.ColorBitmap( icon, favorite.Value.Color );
                item.Tag = favorite;
                item.MouseUp += FavoriteMenuItem_MouseUp;
                item.DropDown.Closing += FavoriteMenuItemDropDown_Closing;

                menuItems.Add( item );

                CreateFavoritesMenu( favorite, item.DropDownItems );
            }
        }

        private void AddToRecentRepos( String path )
        {
            String repo = Git.GetBaseRepoDirectory( path );
            if( repo == null )
            {
                LOG.ErrorFormat( "Failed to add recent repo - Path: {0}", path );
                return;
            }

            if( Settings.Default.RecentRepos.Contains( repo ) )
            {
                Settings.Default.RecentRepos.Remove( repo );
            }
            Settings.Default.RecentRepos.Insert( 0, repo );

            int maxRecentRepos = Settings.Default.MaxRecentRepos;
            if( Settings.Default.RecentRepos.Count > maxRecentRepos )
            {
                Settings.Default.RecentRepos.RemoveRange( maxRecentRepos, Settings.Default.RecentRepos.Count - maxRecentRepos );
            }

            Settings.Default.Save();
            UpdateRecentReposFromSettings();
        }

        private FavoriteRepo FindFavorite( String repo )
        {
            foreach( TreeNode<FavoriteRepo> favorite in Settings.Default.FavoriteRepos.BreadthFirst )
            {
                if( favorite.Value.Repo == repo )
                {
                    return favorite.Value;
                }
            }
            return null;
        }

        private void AddFavoriteRepo( String path )
        {
            if( !Git.IsInRepo( path ) )
            {
                LOG.ErrorFormat( "Failed to add favorite repo: {0}", path );
                return;
            }

            FavoriteCreatorDialog dialog = new FavoriteCreatorDialog( false )
            {
                FavoriteRepo = path
            };
            if( dialog.ShowDialog() == DialogResult.OK )
            {
                _favoriteRepos.Add( dialog.ToFavoriteRepo() );

                Settings.Default.FavoriteRepos = _favoriteRepos;
                Settings.Default.Save();

                UpdateFavoriteReposFromSettings();
            }
        }

        private void RemoveFavorite( TreeNode<FavoriteRepo> favorite )
        {
            favorite.Parent.Remove( favorite );
            Settings.Default.FavoriteRepos = _favoriteRepos;
            Settings.Default.Save();

            UpdateFavoriteReposFromSettings();
        }

        private async Task OpenLog( String path, IEnumerable<String> references = null )
        {
            AddToRecentRepos( path );

            Process p = GitAction.Log( path, references );
            await AddNewLogProcess( p, path );
        }

        internal async void HandleKeyboardShortcut( KeyboardShortcuts keyboardShortcut )
        {
            LOG.DebugFormat( "HandleKeyboardShortcut - KeyboardShortcut: {0}", keyboardShortcut );

            if( keyboardShortcut == KeyboardShortcuts.NewTab )
            {
                await FindRepo();
            }
            else if( keyboardShortcut == KeyboardShortcuts.NextTab )
            {
                LogTabs.NextTab();
            }
            else if( keyboardShortcut == KeyboardShortcuts.PreviousTab )
            {
                LogTabs.PreviousTab();
            }
            else if( keyboardShortcut == KeyboardShortcuts.CloseTab )
            {
                CloseTab( LogTabs.SelectedTab );
            }
            else if( keyboardShortcut == KeyboardShortcuts.ReopenClosedTab )
            {
                if( _closedRepos.Count > 0 )
                {
                    String repo = _closedRepos.Pop();

                    LOG.DebugFormat( "HotKey - Reopen Closed Tab - Reopening: {0}", repo );

                    await OpenLog( repo );
                }
            }
            else if( KEYBOARD_SHORTCUT_ACTIONS.ContainsKey( keyboardShortcut ) )
            {
                TabControllerTag tag = LogTabs.SelectedTab.Controller();
                GitActionFunc gitActionFunc = KEYBOARD_SHORTCUT_ACTIONS[ keyboardShortcut ];

                await RunGitAction( tag, gitActionFunc );
            }
            else
            {
                LOG.ErrorFormat( "Unhandled keyboard shortcut - KeyboardShortcut: {0}", keyboardShortcut );
            }
        }

        internal void AddExistingTab( Tab tab )
        {
            LOG.DebugFormat( "AddExistingTab - Tab: {0}", tab );

            TabControllerTag tag = tab.Controller();

            if( this.OwnsLogProcess( tag.Process ) )
            {
                LOG.ErrorFormat( "AddExistingTab - Already own process - PID: {0}", tag.Process.Id );
                return;
            }

            LogTabs.Tabs.Add( tab );
            LogTabs.SelectedTab = tab;
        }

        internal async Task AddNewLogProcess( Process p, String path )
        {
            TabControllerTag tag;
            lock( _tags )
            {
                LOG.DebugFormat( "AddNewLogProcess - Path: {0} - PID: {1}", path, p.Id );
                if( this.OwnsLogProcess( p ) )
                {
                    LOG.DebugFormat( "AddNewLogProcess - Process already under control - Path: {0} - PID: {1}", path, p.Id );
                    return;
                }

                tag = TabControllerTag.CreateController( p, path );
                _tags.Add( tag.Process.Id, tag );
            }

            await tag.WaitForStartup();

            KeyboardShortcutsManager.Instance.AddHandle( tag.Process.MainWindowHandle );

            LogTabs.Tabs.Add( tag.Tab );
            LogTabs.SelectedTab = tag.Tab;

            ShowMe();
        }

        private void RegisterExistingTab( Tab tab )
        {
            LOG.DebugFormat( "RegisterExistingTab - Tab: {0}", tab );

            TabControllerTag tag = tab.Controller();

            if( this.OwnsLogProcess( tag.Process ) )
            {
                LOG.ErrorFormat( "RegisterExistingTab - Already own process - PID: {0}", tag.Process.Id );
                return;
            }

            lock( _tags )
            {
                _tags.Add( tag.Process.Id, tag );
            }

            ShowMe();
        }

        private void RemoveLogProcess( Process p, bool killProcess )
        {
            LOG.DebugFormat( "RemoveLogProcess - PID: {0} - Kill Process: {1}", p.Id, killProcess );

            lock( _tags )
            {
                if( !this.OwnsLogProcess( p ) )
                {
                    LOG.ErrorFormat( "Attempting to remove log not under control - Process ID: {0}", p.Id );
                    return;
                }

                TabControllerTag tag = _tags[ p.Id ];

                _tags.Remove( p.Id );

                tag.Tab.Parent = null;

                if( killProcess )
                {
                    _closedRepos.Push( tag.RepoItem );

                    KeyboardShortcutsManager.Instance.RemoveHandle( p.MainWindowHandle );

                    tag.Close();
                }
            }
        }

        private void RemoveAllLogs()
        {
            lock( _tags )
            {
                LOG.DebugFormat( "RemoveAllLogs - Count: {0}", _tags.Count );

                while( _tags.Count > 0 )
                {
                    RemoveLogProcess( _tags.Values.First().Process, true );
                }
            }
        }

        private void CloseTab( Tab tab )
        {
            TabControllerTag t = tab.Controller();

            LOG.DebugFormat( "Close Tab - Repo: {0} - ID: {1}", t.RepoItem, t.Process.Id );

            RemoveLogProcess( t.Process, true );

            CheckIfLastTab();
        }

        private void CheckIfLastTab()
        {
            if( LogTabs.TabCount == 0
             && Settings.Default.CloseWindowOnLastTabClosed )
            {
                LOG.Debug( "CheckIfLastTab - Closing window after last tab closed" );
                this.Close();
            }
        }

        internal bool OwnsLogProcess( Process logProcess )
        {
            lock( _tags )
            {
                return _tags.ContainsKey( logProcess.Id );
            }
        }

        private async Task FindRepo()
        {
            LOG.Debug( "FindRepo" );

            if( _folderDialog.ShowDialog() == CommonFileDialogResult.Ok )
            {
                String path = _folderDialog.FileName;
                if( !Git.IsInRepo( path ) )
                {
                    LOG.DebugFormat( "FindRepo - Invalid repo: {0}", path );
                    MessageBox.Show( "Directory is not a git repo!", "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
                else
                {
                    LOG.DebugFormat( "FindRepo - Opening repo: {0}", path );
                    await OpenLog( path );
                }
            }
        }

        private void ShowMe()
        {
            this.Show();
            if( this.WindowState == FormWindowState.Minimized )
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.BringToFront();
        }

        private async Task OpenStartupRepos()
        {
            LOG.Debug( nameof( OpenStartupRepos ) );

            foreach( String repo in Settings.Default.StartupRepos )
            {
                if( Git.IsInRepo( repo ) )
                {
                    await OpenLog( repo );
                }
            }
        }

        private async Task OpenFavoriteRepos( TreeNode<FavoriteRepo> favoriteFolder )
        {
            foreach( TreeNode<FavoriteRepo> favorite in favoriteFolder.BreadthFirst.Where( f => !f.Value.IsFavoriteFolder ) )
            {
                await OpenLog( favorite.Value.Repo );
            }
        }

        private void SaveWindowState()
        {
            if( this.WindowState == FormWindowState.Maximized )
            {
                Settings.Default.Maximized = true;
                Settings.Default.Size = this.RestoreBounds.Size;
            }
            else if( this.WindowState == FormWindowState.Minimized )
            {
                Settings.Default.Maximized = false;
                Settings.Default.Size = this.RestoreBounds.Size;
            }
            else
            {
                Settings.Default.Maximized = false;
                Settings.Default.Size = this.Size;
            }

            Settings.Default.Save();
        }

        private bool ConfirmClose()
        {
            if( !this.Visible )
            {
                return true;
            }
            else if( _tags.Count == 0 )
            {
                return true;
            }
            else if( Settings.Default.ConfirmOnClose )
            {
                TaskDialog confirmationDialog = new TaskDialog()
                {
                    StandardButtons = TaskDialogStandardButtons.Yes | TaskDialogStandardButtons.No,
                    Text = "Are you sure you want to exit?",
                    Caption = "Tabbed TortoiseGit",
                    FooterCheckBoxText = "Do not ask me again",
                    FooterCheckBoxChecked = false
                };
                if( confirmationDialog.Show() == TaskDialogResult.Yes )
                {
                    if( confirmationDialog.FooterCheckBoxChecked ?? false )
                    {
                        Settings.Default.ConfirmOnClose = false;
                        Settings.Default.Save();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private void CloseDropDowns( ToolStripItemCollection menuItems )
        {
            foreach( ToolStripDropDownItem dropDownItem in menuItems.OfType<ToolStripDropDownItem>() )
            {
                dropDownItem.HideDropDown();
                CloseDropDowns( dropDownItem.DropDownItems );
            }
        }

        private void UpdateIcon()
        {
            String repo = LogTabs.SelectedTab?.Controller().RepoItem;
            if( repo == null )
            {
                this.Icon = Resources.TortoiseIcon;
                return;
            }

            FavoriteRepo favorite = FindFavorite( repo );
            if( favorite == null
             || favorite.Color == Color.Black )
            {
                this.Icon = Resources.TortoiseIcon;
                return;
            }

            using( Bitmap shell = Resources.TortoiseShell )
            using( Bitmap coloredShell = Util.ColorBitmap( shell, favorite.Color ) )
            using( Bitmap background = Resources.TortoiseBody )
            using( Graphics g = Graphics.FromImage( background ) )
            {
                g.DrawImage( coloredShell, 0, 0 );
                this.Icon = background.ToIcon();
            }
        }

        private async Task RunGitAction( TabControllerTag tag, GitActionFunc gitActionFunc )
        {
            if( await gitActionFunc.Invoke( tag.RepoItem ) )
            {
                if( !tag.Process.HasExited )
                {
                    Native.SendKeyDown( tag.Process.MainWindowHandle, Keys.F5 );
                }
            }
        }
    }
}
