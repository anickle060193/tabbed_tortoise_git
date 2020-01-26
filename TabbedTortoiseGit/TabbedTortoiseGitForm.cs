#nullable enable

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
            { KeyboardShortcuts.SwitchCheckout,         GitAction.Switch                },
            { KeyboardShortcuts.Diff,                   GitAction.Diff                  },
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
        private readonly bool _skipUpdateCheck;
        private readonly Point? _createdAtPoint;
        private readonly Stack<String> _closedRepos = new Stack<String>();

        private FavoriteFolder? _favoriteRepos;

        private bool _favoriteContextMenuOpen;

        public TabbedTortoiseGitForm( bool showStartUpRepos, bool skipUpdateCheck, Point? createdAtPoint )
        {
            LOG.Debug( $"Constructor - Show Start-up Repos: {showStartUpRepos}" );

            InitializeComponent();
            InitializeEventHandlers();

            _showStartUpRepos = showStartUpRepos;
            _skipUpdateCheck = skipUpdateCheck;
            _createdAtPoint = createdAtPoint;

            _folderDialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };

            this.Icon = Resources.TortoiseIcon;

            ReferencesFilter.SetPlaceholder( "References filter" );
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
                TabControllerTag? tag = LogTabs.SelectedTab?.Controller();
                if( tag != null )
                {
                    Native.SetForegroundWindow( tag.Process.MainWindowHandle );
                    Native.SendKeyDown( tag.Process.MainWindowHandle, keyData );
                    return true;
                }
            }

            return base.ProcessCmdKey( ref msg, keyData );
        }

        private async Task UpdateFromSettings( bool updateWindowState )
        {
            if( updateWindowState )
            {
                UpdateWindowStateFromSettings();
            }

            UpdateHitTestFromSettings();

            UpdateModifiedTabsStatusFromSettings();

            UpdateRecentReposFromSettings();
            UpdateRepoContextMenusFromSettings();
            await UpdateFavoriteReposFromSettings();
        }

        private void UpdateWindowStateFromSettings()
        {
            if( !Settings.Default.Size.IsEmpty )
            {
                this.Size = Settings.Default.Size;
                this.CenterToScreen();
            }

            if( _createdAtPoint is Point p )
            {
                this.StartPosition = FormStartPosition.Manual;

                Rectangle formBounds = this.Bounds;
                Rectangle tabBounds = LogTabs.RectangleToScreen( LogTabs.GetTabRect( 0 ) );
                int tabX = tabBounds.Left - formBounds.Left;
                int tabY = tabBounds.Top - formBounds.Top;

                int x = p.X - tabX - tabBounds.Width / 2;
                int y = p.Y - tabY - tabBounds.Height / 2;
                this.Location = new Point( x, y );
            }

            if( Settings.Default.Maximized )
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void UpdateHitTestFromSettings()
        {
            if( Settings.Default.DeveloperSettingsEnabled )
            {
                LogTabs.ShowHitTest = Settings.Default.ShowHitTest;
            }
            else
            {
                LogTabs.ShowHitTest = false;
            }
        }

        private void UpdateModifiedTabsStatusFromSettings()
        {
            lock( _tags )
            {
                foreach( TabControllerTag tag in _tags.Values )
                {
                    tag.UpdateTabDisplay();
                }
            }

            if( Settings.Default.IndicateModifiedTabs
             && !ModifiedRepoCheckBackgroundWorker.IsBusy )
            {
                ModifiedRepoCheckBackgroundWorker.RunWorkerAsync();
            }
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
            TabContextMenu.Items.Add( OpenWithReferencesRepoTabMenuItem );
            TabContextMenu.Items.Add( DuplicateRepoTabMenuItem );

            FavoriteRepoContextMenu.Items.Clear();
            FavoriteRepoContextMenu.Items.Add( OpenFavoriteRepoLocationContextMenuItem );
            FavoriteRepoContextMenu.Items.Add( OpenFavoriteWithReferencesContextMenuItem );

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

            List<CustomAction> customActions = Settings.Default.CustomActions;
            if( customActions.Count > 0 )
            {
                TabContextMenu.Items.Add( "-" );

                FavoriteRepoContextMenu.Items.Add( "-" );

                foreach( CustomAction customAction in customActions )
                {
                    ToolStripItem tabMenuItem = TabContextMenu.Items.Add( customAction.Name );
                    tabMenuItem.Click += CustomActionTabMenuItem_Click;
                    tabMenuItem.Tag = customAction;

                    ToolStripItem favoriteMenuItem = FavoriteRepoContextMenu.Items.Add( customAction.Name );
                    favoriteMenuItem.Click += CustomActionFavoriteContextMenuItem_Click;
                    favoriteMenuItem.Tag = customAction;
                }
            }

            TabContextMenu.Items.Add( "-" );
            TabContextMenu.Items.Add( CloseRepoTabMenuItem );

            FavoriteRepoContextMenu.Items.Add( "-" );
            FavoriteRepoContextMenu.Items.Add( EditFavoriteContextMenuItem );
            FavoriteRepoContextMenu.Items.Add( RemoveFavoriteContextMenuItem );

            TabContextMenu.ResumeLayout();
            FavoriteRepoContextMenu.ResumeLayout();
        }

        private async Task UpdateFavoriteReposFromSettings()
        {
            _favoriteRepos = Settings.Default.FavoriteRepos;

            lock( _tags )
            {
                foreach( TabControllerTag tag in _tags.Values )
                {
                    tag.UpdateIcon();
                }
            }

            List<ToolStripItem> items = new List<ToolStripItem>();

            await CreateFavoritesMenu( _favoriteRepos.Children, items );

            FavoritesMenuStrip.SuspendLayout();

            FavoritesMenuStrip.Items.Clear();
            FavoritesMenuStrip.Items.AddRange( items.ToArray() );

            FavoritesMenuStrip.Visible = items.Count > 0;

            FavoritesMenuStrip.ResumeLayout();

            foreach( Tab tab in LogTabs.Tabs )
            {
                tab.Controller().UpdateIcon();
            }

            UpdateIcon();
        }

        private async Task CreateFavoritesMenu( IEnumerable<Favorite> favorites, System.Collections.IList menuItems )
        {
            foreach( Favorite favorite in favorites )
            {
                ToolStripMenuItem item = new ToolStripMenuItem( favorite.Name );
                Bitmap icon;

                if( favorite is FavoriteFolder folder )
                {
                    icon = Resources.FolderFolder;
                }
                else if( favorite is FavoriteRepo repo )
                {
                    item.ToolTipText = repo.Repo;

                    if( repo.IsDirectory )
                    {
                        icon = Resources.Folder;
                        item.Click += FavoriteRepoMenuItem_Click;
                    }
                    else
                    {
                        icon = Resources.File;
                        item.Click += FavoriteRepoMenuItem_Click;
                    }
                }
                else if( favorite is FavoriteReposDirectory directory )
                {
                    item.ToolTipText = directory.Directory;

                    icon = Resources.SymLink;
                }
                else if( favorite is FavoriteReposDirectoryRepo subrepo )
                {
                    item.ToolTipText = subrepo.Repo;

                    icon = Resources.Folder;
                    item.Click += FavoriteRepoMenuItem_Click;
                }
                else
                {
                    throw new ArgumentException( $"Unknown favorite type: {favorite}" );
                }

                item.Image = Util.ColorBitmap( icon, favorite.Color );
                item.Tag = favorite;
                item.MouseUp += FavoriteMenuItem_MouseUp;
                item.DropDown.Closing += FavoriteMenuItemDropDown_Closing;

                menuItems.Add( item );

                if( favorite is FavoriteFolder f )
                {
                    await CreateFavoritesMenu( f.Children, item.DropDownItems );
                }
                else if( favorite is FavoriteReposDirectory d )
                {
                    await CreateFavoritesMenu( await Task.Run( () => d.GetDirectoryRepos() ), item.DropDownItems );
                }
            }
        }

        private void AddToRecentRepos( String path )
        {
            String? repo = Git.GetBaseRepoDirectory( path );
            if( repo == null )
            {
                LOG.Error( $"Failed to add recent repo - Path: {path}" );
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
        }

        private void AddFavoriteRepo( String path )
        {
            if( _favoriteRepos is null )
            {
                LOG.Error( $"{nameof( AddFavoriteRepo )} - {nameof( _favoriteRepos )} has not been initialized" );
                return;
            }

            if( !Git.IsInRepo( path ) )
            {
                LOG.Error( $"{nameof( AddFavoriteRepo )} - Failed to add favorite repo: {path}" );
                return;
            }

            using FavoriteRepoCreatorDialog dialog = FavoriteRepoCreatorDialog.FromRepo( path );
            if( dialog.ShowDialog() == DialogResult.OK )
            {
                _favoriteRepos.Children.Add( dialog.ToFavoriteRepo() );

                Settings.Default.FavoriteRepos = _favoriteRepos;
                Settings.Default.Save();
            }
        }

        private void RemoveFavorite( Favorite favorite )
        {
            _favoriteRepos?.Remove( favorite );
            Settings.Default.FavoriteRepos = _favoriteRepos!;
            Settings.Default.Save();
        }

        private async Task OpenLog( String path, IEnumerable<String>? references = null )
        {
            AddToRecentRepos( path );

            Process p = GitAction.Log( path, references );
            await AddNewLogProcess( p, path );
        }

        internal async void HandleKeyboardShortcut( KeyboardShortcuts keyboardShortcut )
        {
            LOG.Debug( $"{nameof( HandleKeyboardShortcut )} - KeyboardShortcut: {keyboardShortcut}" );

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
            else if( keyboardShortcut == KeyboardShortcuts.DuplicateTab )
            {
                if( LogTabs.SelectedTab is Tab selectedTab )
                {
                    await DuplicateTab( selectedTab );
                }
            }
            else if( keyboardShortcut == KeyboardShortcuts.CloseTab )
            {
                if( LogTabs.SelectedTab is Tab selectedTab )
                {
                    CloseTab( selectedTab );
                }
            }
            else if( keyboardShortcut == KeyboardShortcuts.ReopenClosedTab )
            {
                if( _closedRepos.Count > 0 )
                {
                    String repo = _closedRepos.Pop();

                    LOG.Debug( $"HotKey - Reopen Closed Tab - Reopening: {repo}" );

                    await OpenLog( repo );
                }
            }
            else if( KEYBOARD_SHORTCUT_ACTIONS.ContainsKey( keyboardShortcut ) )
            {
                if( LogTabs.SelectedTab?.Controller() is TabControllerTag tag )
                {
                    GitActionFunc gitActionFunc = KEYBOARD_SHORTCUT_ACTIONS[ keyboardShortcut ];

                    await RunGitAction( tag, gitActionFunc );
                }
            }
            else
            {
                LOG.Error( $"Unhandled keyboard shortcut - KeyboardShortcut: {keyboardShortcut}" );
            }
        }

        internal void AddExistingTab( Tab tab )
        {
            LOG.Debug( $"{nameof( AddExistingTab )} - Tab: {tab}" );

            TabControllerTag tag = tab.Controller();

            if( this.OwnsLogProcess( tag.Process ) )
            {
                LOG.Error( $"{nameof( AddExistingTab )} - Already own process - PID: {tag.Process.Id}" );
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
                LOG.Debug( $"{nameof( AddNewLogProcess )} - Path: {path} - PID: {p.Id}" );
                if( this.OwnsLogProcess( p ) )
                {
                    LOG.Debug( $"{nameof( AddNewLogProcess )} - Process already under control - Path: {path} - PID: {p.Id}" );
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
            LOG.Debug( $"{nameof( RegisterExistingTab )} - Tab: {tab}" );

            TabControllerTag tag = tab.Controller();

            if( this.OwnsLogProcess( tag.Process ) )
            {
                LOG.Error( $"{nameof( RegisterExistingTab )} - Already own process - PID: {tag.Process.Id}" );
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
            LOG.Debug( $"{nameof( RemoveLogProcess )} - PID: {p.Id} - Kill Process: {killProcess}" );

            lock( _tags )
            {
                if( !this.OwnsLogProcess( p ) )
                {
                    LOG.Error( $"Attempting to remove log not under control - Process ID: {p.Id}" );
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
                LOG.Debug( $"{nameof( RemoveAllLogs )} - Count: {_tags.Count}" );

                while( _tags.Count > 0 )
                {
                    RemoveLogProcess( _tags.Values.First().Process, true );
                }
            }
        }

        private async Task DuplicateTab( Tab tab )
        {
            TabControllerTag tag = tab.Controller();

            await OpenLog( tag.RepoItem );
        }

        private void CloseTab( Tab tab )
        {
            TabControllerTag t = tab.Controller();

            LOG.Debug( $"{nameof( CloseTab )} - Repo: {t.RepoItem} - ID: {t.Process.Id}" );

            RemoveLogProcess( t.Process, true );

            CheckIfLastTab();
        }

        private void CheckIfLastTab()
        {
            if( LogTabs.TabCount == 0
             && Settings.Default.CloseWindowOnLastTabClosed )
            {
                LOG.Debug( $"{nameof( CheckIfLastTab )} - Closing window after last tab closed" );
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
            LOG.Debug( nameof( FindRepo ) );

            if( _folderDialog.ShowDialog() == CommonFileDialogResult.Ok )
            {
                String path = _folderDialog.FileName;
                if( !Git.IsInRepo( path ) )
                {
                    LOG.Debug( $"{nameof( FindRepo )} - Invalid repo: {path}" );
                    MessageBox.Show( "Directory is not a git repo!", "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
                else
                {
                    LOG.Debug( $"{nameof( FindRepo )} - Opening repo: {path}" );
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

        private async Task OpenFavoriteRepos( Favorite favorite )
        {
            if( favorite is FavoriteRepo repo )
            {
                await OpenLog( repo.Repo );
            }
            else if( favorite is FavoriteFolder folder )
            {
                foreach( Favorite child in folder.Children )
                {
                    await OpenFavoriteRepos( child );
                }
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
                using TaskDialog confirmationDialog = new TaskDialog()
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
            TabControllerTag? tag = LogTabs.SelectedTab?.Controller();
            if( tag == null )
            {
                this.Icon = Resources.TortoiseIcon;
                return;
            }

            if( tag.Color == Color.Black )
            {
                this.Icon = Resources.TortoiseIcon;
                return;
            }

            using Bitmap shell = Resources.TortoiseShell;
            using Bitmap coloredShell = Util.ColorBitmap( shell, tag.Color );
            using Bitmap background = Resources.TortoiseBody;
            using Graphics g = Graphics.FromImage( background );
            g.DrawImage( coloredShell, 0, 0 );
            this.Icon = background.ToIcon();
        }

        private async Task UpdateToolStripSubmodules()
        {
            TabControllerTag? currentTab = LogTabs.SelectedTab?.Controller();

            if( currentTab == null )
            {
                SubmodulesToolStripDropDown.Enabled = false;
                SubmodulesToolStripDropDown.DropDownItems.Clear();
            }
            else
            {
                String repo = currentTab.RepoItem;

                SubmodulesToolStripDropDown.Enabled = false;
                SubmodulesToolStripDropDown.DropDownItems.Clear();

                if( currentTab.Submodules != null )
                {
                    if( currentTab.Submodules.Count > 0 )
                    {
                        SubmodulesToolStripDropDown.Enabled = true;
                        SubmodulesToolStripDropDown.DropDownItems.Clear();

                        var menus = new Dictionary<Tuple<int, String>, ToolStripMenuItem>();

                        foreach( String submodule in currentTab.Submodules )
                        {
                            String[] path = submodule.Split( new [] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar } );

                            var parent = SubmodulesToolStripDropDown.DropDownItems;
                            for( int i = 0; i < path.Length - 1; i++ )
                            {
                                var key = Tuple.Create( i, path[ i ] );
                                if( !menus.TryGetValue( key, out ToolStripMenuItem item ) )
                                {
                                    item = new ToolStripMenuItem( path[ i ] );
                                    menus[ key ] = item;
                                    parent.Add( item );
                                }
                                parent = item.DropDownItems;
                            }

                            ToolStripItem dropDownItem = parent.Add( path[ path.Length - 1 ] );
                            dropDownItem.Tag = Path.GetFullPath( Path.Combine( repo, submodule ) );
                            dropDownItem.Click += SubmoduleToolStripDropDownItem_Click;
                        }
                    }
                }
                else if( !currentTab.LoadingSubmodules )
                {
                    await currentTab.LoadSubmodules();

                    if( currentTab == LogTabs.SelectedTab?.Controller() )
                    {
                        await UpdateToolStripSubmodules();
                    }
                }
            }
        }

        private void UpdateToolStripFasterFetch()
        {
            TabControllerTag? currentTab = LogTabs.SelectedTab?.Controller();

            if( currentTab == null )
            {
                BackgroundFasterFetch.Enabled = false;

                BackgroundFasterFetchProgress.Enabled = false;
                BackgroundFasterFetchProgress.Maximum = 0;
                BackgroundFasterFetchProgress.Value = 0;
            }
            else
            {
                if( currentTab.BackgroundFasterFetchDialog is null )
                {
                    BackgroundFasterFetch.Enabled = true;
                
                    BackgroundFasterFetchProgress.Enabled = false;
                    BackgroundFasterFetchProgress.Maximum = 0;
                    BackgroundFasterFetchProgress.Value = 0;
                }
                else
                {
                    BackgroundFasterFetch.Enabled = currentTab.BackgroundFasterFetchDialog.Completed;

                    BackgroundFasterFetchProgress.Enabled = true;
                    BackgroundFasterFetchProgress.Maximum = currentTab.BackgroundFasterFetchDialog.TotalTaskCount;

                    if( currentTab.BackgroundFasterFetchDialog.TotalTaskCount > 1
                     && currentTab.BackgroundFasterFetchDialog.CompletedTaskCount == 0 )
                    {
                        BackgroundFasterFetchProgress.Value = 1;
                    }
                    else
                    {
                        BackgroundFasterFetchProgress.Value = currentTab.BackgroundFasterFetchDialog.CompletedTaskCount;
                    }
                }
            }
        }

        private class DisplayReference : IFormattable, IComparable<DisplayReference>
        {
            public String Reference { get; private set; }
            public String ShortReference { get; private set; }

            public DisplayReference( String reference, String shortReference )
            {
                Reference = reference;
                ShortReference = shortReference;
            }

            public override String ToString()
            {
                return ShortReference;
            }

            public string ToString( String format, IFormatProvider formatProvider )
            {
                if( format == "long" )
                {
                    return Reference;
                }
                else
                {
                    return ShortReference;
                }
            }

            public int CompareTo( DisplayReference other )
            {
                return String.Compare( this.Reference, other?.Reference );
            }
        }

        private void UpdateReferencesTreeView()
        {
            TabControllerTag? currentTab = LogTabs.SelectedTab?.Controller();

            ReferencesTreeView.BeginUpdate();

            ReferencesTreeView.Nodes.Clear();

            if( currentTab != null )
            {
                using( Repository repository = new Repository( Git.GetBaseRepoDirectory( currentTab.RepoItem ) ) )
                {
                    foreach( Reference r in repository.Refs )
                    {
                        String[] splitRef = r.CanonicalName.Split( '/' );
                        AddReferencesTreeViewReference( r.CanonicalName, splitRef, 0, ReferencesTreeView.Nodes );
                    }
                }

                if( ReferencesTreeView.Nodes.Count > 0 )
                {
                    TreeNode firstNode = ReferencesTreeView.Nodes[ 0 ];
                    firstNode.Expand();
                    ReferencesTreeView.SelectedNode = firstNode;
                }
            }

            ReferencesTreeView.EndUpdate();
        }

        private void AddReferencesTreeViewReference( String reference, String[] splitRef, int index, TreeNodeCollection parentNodes )
        {
            String splitRefPart = splitRef[ index ];
            TreeNode node = parentNodes.Find( splitRefPart, false ).FirstOrDefault();
            if( node == null )
            {
                node = parentNodes.Add( splitRefPart, splitRefPart );
                node.Tag = new List<DisplayReference>();
            }

            List<DisplayReference> refs = (List<DisplayReference>)node.Tag;
            DisplayReference displayRef = new DisplayReference( reference, String.Join( "/", splitRef, index + 1, splitRef.Length - index - 1 ) );
            refs.Add( displayRef );

            if( index + 1 < splitRef.Length - 1 )
            {
                AddReferencesTreeViewReference( reference, splitRef, index + 1, node.Nodes );
            }
        }

        private void UpdateReferencesListBox()
        {
            TreeNode? selectedNode = ReferencesTreeView.SelectedNode;

            ReferencesListBox.BeginUpdate();

            ReferencesListBox.Items.Clear();

            if( selectedNode != null )
            {
                IEnumerable<DisplayReference> references = (IEnumerable<DisplayReference>)selectedNode.Tag;

                String filter = ReferencesFilter.Text;
                if( !String.IsNullOrWhiteSpace( filter ) )
                {
                    String[] filters = filter.Split();
                    references = references.Where( ( reference ) => filters.All( ( f ) => reference.Reference.IndexOf( f, StringComparison.OrdinalIgnoreCase ) != -1 ) );
                }

                ReferencesListBox.Items.AddRange( references.ToArray() );
            }

            ReferencesListBox.EndUpdate();
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

        private void RunCustomAction( TabControllerTag? tag, CustomAction customAction, String repoItem )
        {
            LOG.Debug( $"{nameof( RunCustomAction )} - Action: {customAction} - Repo: {repoItem}" );

            String filename = repoItem;
            String directory;
            if( Directory.Exists( repoItem ) )
            {
                directory = repoItem;
            }
            else
            {
                directory = Path.GetDirectoryName( filename );
            }
            String repo = Git.GetBaseRepoDirectoryOrError( repoItem );

            String program = customAction.Program;
            String arguments = customAction.Arguments.Replace( "%f", filename ).Replace( "%d", directory ).Replace( "%r", repo );
            String workingDirectory = customAction.WorkingDirectory.Replace( "%f", filename ).Replace( "%d", directory ).Replace( "%r", repo );

            if( Path.IsPathRooted( program )
             && !File.Exists( program ) )
            {
                MessageBox.Show( $"Program file does not exist: \"{program}\"", "Invalid Program", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }
            else if( !Directory.Exists( workingDirectory ) )
            {
                MessageBox.Show( $"Working directory does not exist: \"{workingDirectory}\"", "Invalid Working Directory", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }


            LOG.Debug( $"{nameof( RunCustomAction )} - Running - Program: {program} - Arguments: {arguments} - Working Directory: {workingDirectory} - Refresh Log After: {customAction.RefreshLogAfter} - Show Progress Dialog: {customAction.ShowProgressDialog} - Create No Window: {customAction.CreateNoWindow}" );
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = program;
                p.StartInfo.Arguments = arguments;
                p.StartInfo.WorkingDirectory = workingDirectory;

                if( customAction.CreateNoWindow )
                {
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.StartInfo.CreateNoWindow = true;
                }

                if( customAction.ShowProgressDialog )
                {
                    ProgressDialog dialog = new ProgressDialog();
                    dialog.AddTask( new ProcessProgressTask( p, true ) );

                    if( tag != null
                     && customAction.RefreshLogAfter )
                    {
                        dialog.FormClosed += delegate ( Object sender, FormClosedEventArgs e )
                        {
                            if( !tag.Process.HasExited )
                            {
                                Native.SendKeyDown( tag.Process.MainWindowHandle, Keys.F5 );
                            }
                        };
                    }

                    dialog.Show();
                    dialog.DoProgress();
                }
                else
                {
                    if( tag != null
                     && customAction.RefreshLogAfter )
                    {
                        p.Exited += delegate ( Object sender, EventArgs e )
                        {
                            if( !tag.Process.HasExited )
                            {
                                Native.SendKeyDown( tag.Process.MainWindowHandle, Keys.F5 );
                            }
                        };
                    }

                    p.Start();
                }
            }
            catch( Exception e )
            {
                LOG.Error( "Failed to run Custom Action: {program} {arguments}", e );
                MessageBox.Show( $"The following error occurred while attempting to run Custom Action: {program} {arguments}\n{e}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }
    }
}
