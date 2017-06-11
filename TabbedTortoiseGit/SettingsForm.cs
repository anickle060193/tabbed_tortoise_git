using Common;
using LibGit2Sharp;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    public partial class SettingsForm : Form
    {
        public static bool ShowSettingsDialog()
        {
            SettingsForm f = new SettingsForm();

            f.StartupRepos = Settings.Default.StartupRepos.ToArray();
            f.OpenStartupReposOnReOpen = Settings.Default.OpenStartupReposOnReOpen;

            f.TabContextMenuGitActions = Settings.Default.TabContextMenuGitActions;
            f.CheckModifiedSubmodulesByDefault = Settings.Default.FastSubmoduleUpdateCheckModifiedSubmodulesByDefault;

            f.IndicateModifiedTabs = Settings.Default.IndicateModifiedTabs;
            f.CheckForModifiedTabsInterval = Settings.Default.CheckForModifiedTabsInterval;
            f.ModifiedTabFont = Settings.Default.ModifiedTabFont;
            f.ModifiedTabFontColor = Settings.Default.ModifiedTabFontColor;

            f.RetainLogsOnClose = Settings.Default.RetainLogsOnClose;
            f.MaxRecentRepos = Settings.Default.MaxRecentRepos;
            f.ConfirmOnClose = Settings.Default.ConfirmOnClose;
            f.CloseWindowOnLastTabClosed = Settings.Default.CloseWindowOnLastTabClosed;
            f.CloseToSystemTray = Settings.Default.CloseToSystemTray;
            f.RunOnStartup = TTG.RunOnStartup;

            f.DeveloperSettingsEnabled = Settings.Default.DeveloperSettingsEnabled;
            f.ShowHitTest = Settings.Default.ShowHitTest;
            f.FavoritesMenuStripInTabControl = Settings.Default.FavoritesMenuStripInTabControl;

            if( f.ShowDialog() == DialogResult.OK )
            {
                Settings.Default.StartupRepos = f.StartupRepos.ToList();
                Settings.Default.OpenStartupReposOnReOpen = f.OpenStartupReposOnReOpen;

                Settings.Default.TabContextMenuGitActions = f.TabContextMenuGitActions;
                Settings.Default.FastSubmoduleUpdateCheckModifiedSubmodulesByDefault = f.CheckModifiedSubmodulesByDefault;

                Settings.Default.CheckForModifiedTabsInterval = f.CheckForModifiedTabsInterval;
                Settings.Default.IndicateModifiedTabs = f.IndicateModifiedTabs;
                Settings.Default.ModifiedTabFont = f.ModifiedTabFont;
                Settings.Default.ModifiedTabFontColor = f.ModifiedTabFontColor;

                Settings.Default.RetainLogsOnClose = f.RetainLogsOnClose;
                Settings.Default.MaxRecentRepos = f.MaxRecentRepos;
                Settings.Default.RecentRepos = Settings.Default.RecentRepos.Take( Settings.Default.MaxRecentRepos ).ToList();
                Settings.Default.ConfirmOnClose = f.ConfirmOnClose;
                Settings.Default.CloseWindowOnLastTabClosed = f.CloseWindowOnLastTabClosed;
                Settings.Default.CloseToSystemTray = f.CloseToSystemTray;
                TTG.RunOnStartup = f.RunOnStartup;

                Settings.Default.DeveloperSettingsEnabled = f.DeveloperSettingsEnabled;
                Settings.Default.ShowHitTest = f.ShowHitTest;
                Settings.Default.FavoritesMenuStripInTabControl = f.FavoritesMenuStripInTabControl;

                Settings.Default.Save();

                return true;
            }
            else
            {
                return false;
            }
        }

        public String[] StartupRepos
        {
            get
            {
                return StartupReposList.Items.Cast<String>().ToArray();
            }

            set
            {
                StartupReposList.Items.Clear();
                StartupReposList.Items.AddRange( value );
            }
        }

        public bool OpenStartupReposOnReOpen
        {
            get
            {
                return OpenStartupReposOnReOpenCheck.Checked;
            }

            set
            {
                OpenStartupReposOnReOpenCheck.Checked = value;
            }
        }

        public List<String> TabContextMenuGitActions
        {
            get
            {
                return GitActionsCheckList.CheckedItems.Cast<String>().ToList();
            }

            set
            {
                for( int i = 0; i < GitActionsCheckList.Items.Count; i++ )
                {
                    GitActionsCheckList.SetItemChecked( i, false );
                }
                foreach( String action in value.Reverse<String>() )
                {
                    if( TortoiseGit.ACTIONS.ContainsKey( action ) )
                    {
                        GitActionsCheckList.Items.Remove( action );
                        GitActionsCheckList.Items.Insert( 0, action );
                        int index = GitActionsCheckList.Items.IndexOf( action );
                        GitActionsCheckList.SetItemChecked( index, true );
                    }
                }
            }
        }

        public bool CheckModifiedSubmodulesByDefault
        {
            get
            {
                return CheckModifiedSubmodulesByDefaultCheck.Checked;
            }

            set
            {
                CheckModifiedSubmodulesByDefaultCheck.Checked = value;
            }
        }

        public int CheckForModifiedTabsInterval
        {
            get
            {
                return (int)CheckForModifiedTabsIntervalNumeric.Value;
            }

            set
            {
                CheckForModifiedTabsIntervalNumeric.Value = value;
            }
        }

        public bool IndicateModifiedTabs
        {
            get
            {
                return IndicateModifiedTabsCheck.Checked;
            }

            set
            {
                IndicateModifiedTabsCheck.Checked = value;
            }
        }

        public Font ModifiedTabFont
        {
            get
            {
                return ModifiedTabFontSample.Font;
            }

            set
            {
                ModifiedTabFontSample.Font = value;
            }
        }

        public Color ModifiedTabFontColor
        {
            get
            {
                return ModifiedTabFontSample.ForeColor;
            }

            set
            {
                ModifiedTabFontSample.ForeColor = value;
            }
        }

        public bool RetainLogsOnClose
        {
            get
            {
                return RetainLogsOnCloseCheck.Checked;
            }

            set
            {
                RetainLogsOnCloseCheck.Checked = value;
            }
        }

        public int MaxRecentRepos
        {
            get
            {
                return (int)MaxRecentReposNumeric.Value;
            }

            set
            {
                MaxRecentReposNumeric.Value = value;
            }
        }

        public bool ConfirmOnClose
        {
            get
            {
                return ConfirmOnCloseCheck.Checked;
            }

            set
            {
                ConfirmOnCloseCheck.Checked = value;
            }
        }

        public bool CloseWindowOnLastTabClosed
        {
            get
            {
                return CloseWindowOnLastTabClosedCheck.Checked;
            }

            set
            {
                CloseWindowOnLastTabClosedCheck.Checked = value;
            }
        }

        public bool CloseToSystemTray
        {
            get
            {
                return CloseToSystemTrayCheck.Checked;
            }

            set
            {
                CloseToSystemTrayCheck.Checked = value; 
            }
        }

        public bool RunOnStartup
        {
            get
            {
                return RunOnStartupCheck.Checked;
            }

            set
            {
                RunOnStartupCheck.Checked = value;
            }
        }

        public bool DeveloperSettingsEnabled
        {
            get
            {
                return DeveloperSettingsPage.Parent != null;
            }

            set
            {
                if( value )
                {
                    if( DeveloperSettingsPage.Parent == null )
                    {
                        DeveloperSettingsPage.Parent = SettingsTabs;
                    }
                }
                else
                {
                    if( DeveloperSettingsPage.Parent != null )
                    {
                        DeveloperSettingsPage.Parent = null;
                    }
                }
            }
        }

        public bool ShowHitTest
        {
            get
            {
                return ShowHitTestCheck.Checked;
            }

            set
            {
                ShowHitTestCheck.Checked = value;
            }
        }

        public bool FavoritesMenuStripInTabControl
        {
            get
            {
                return FavoritesMenuStripInTabControlCheck.Checked;
            }

            set
            {
                FavoritesMenuStripInTabControlCheck.Checked = value;
            }
        }

        private readonly CommonOpenFileDialog _folderDialog;
        private readonly CheckListDragDrophelper _dragDropHelper;

        public SettingsForm()
        {
            InitializeComponent();

            _folderDialog = new CommonOpenFileDialog();
            _folderDialog.IsFolderPicker = true;

            this.KeyPress += SettingsForm_KeyPress;

            this.AddDefaultRepo.Click += AddDefaultRepo_Click;
            this.RemoveDefaultRepo.Click += RemoveDefaultRepo_Click;

            this.StartupReposList.SelectedValueChanged += DefaultReposList_SelectedValueChanged;

            this.GitActionsCheckList.Items.AddRange( TortoiseGit.ACTIONS.Keys.ToArray() );

            this.ResetModifiedTabFontButton.Click += ResetModifiedTabFontButton_Click;
            this.ChangeModifiedTabFontButton.Click += ChangeModifiedTabFontButton_Click;

            _dragDropHelper = new CheckListDragDrophelper();
            _dragDropHelper.AddControl( GitActionsCheckList );
        }

        private static readonly String CHEAT_CODE = "developer";
        private Queue<char> _cheatCode = new Queue<char>();

        private void SettingsForm_KeyPress( object sender, KeyPressEventArgs e )
        {
            _cheatCode.Enqueue( e.KeyChar );
            while( _cheatCode.Count > CHEAT_CODE.Length )
            {
                _cheatCode.Dequeue();
            }
            if( String.Join( "", _cheatCode ) == CHEAT_CODE )
            {
                this.DeveloperSettingsEnabled = !this.DeveloperSettingsEnabled;
            }
        }

        private void AddDefaultRepo_Click( object sender, EventArgs e )
        {
            if( _folderDialog.ShowDialog() == CommonFileDialogResult.Ok )
            {
                String path = _folderDialog.FileName;
                if( Git.IsRepo( path ) )
                {
                    StartupReposList.Items.Add( path );
                }
                else
                {
                    MessageBox.Show( "Directory is not a Git repo.", "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        private void RemoveDefaultRepo_Click( object sender, EventArgs e )
        {
            foreach( String defaultRepo in this.StartupReposList.SelectedItems.Cast<String>().ToArray() )
            {
                this.StartupReposList.Items.Remove( defaultRepo );
            }
        }

        private void DefaultReposList_SelectedValueChanged( object sender, EventArgs e )
        {
            UpdateDefaultReposActions();
        }

        private void ResetModifiedTabFontButton_Click( object sender, EventArgs e )
        {
            this.ModifiedTabFont = Settings.Default.DefaultModifiedTabFont;
            this.ModifiedTabFontColor = Settings.Default.DefaultModifiedTabFontColor;
        }

        private void ChangeModifiedTabFontButton_Click( object sender, EventArgs e )
        {
            ModifiedTabFontDialog.Font = this.ModifiedTabFont;
            ModifiedTabFontDialog.Color = this.ModifiedTabFontColor;
            if( ModifiedTabFontDialog.ShowDialog() == DialogResult.OK )
            {
                this.ModifiedTabFont = ModifiedTabFontDialog.Font;
                this.ModifiedTabFontColor = ModifiedTabFontDialog.Color;
            }
        }

        private void UpdateDefaultReposActions()
        {
            if( this.StartupReposList.SelectedItems.Count != 0 )
            {
                RemoveDefaultRepo.Enabled = true;
            }
            else
            {
                RemoveDefaultRepo.Enabled = false;
            }
        }

        class CheckListDragDrophelper : DragDropHelper<CheckedListBox, String>
        {
            public CheckListDragDrophelper()
            {
                AllowReSwap = true;
            }

            protected override bool AllowDrag( CheckedListBox parent, string item, int index )
            {
                return true;
            }

            protected override bool GetItemFromPoint( CheckedListBox parent, Point p, out String item, out int itemIndex )
            {
                int index = parent.IndexFromPoint( p );
                if( index != CheckedListBox.NoMatches )
                {
                    item = (String)parent.Items[ index ];
                    itemIndex = index;
                    return true;
                }
                else
                {
                    item = null;
                    itemIndex = -1;
                    return false;
                }
            }

            protected override bool SwapItems( CheckedListBox dragParent, string dragItem, int dragItemIndex, CheckedListBox pointedParent, string pointedItem, int pointedItemIndex )
            {
                bool dragItemChecked = dragParent.GetItemChecked( dragItemIndex );
                bool pointedItemChecked = pointedParent.GetItemChecked( pointedItemIndex );

                dragParent.Items[ dragItemIndex ] = pointedItem;
                dragParent.SetItemChecked( dragItemIndex, pointedItemChecked );
                dragParent.SetSelected( dragItemIndex, false );

                pointedParent.Items[ pointedItemIndex ] = dragItem;
                pointedParent.SetItemChecked( pointedItemIndex, dragItemChecked );
                pointedParent.SetSelected( pointedItemIndex, true );

                return true;
            }
        }
    }
}
