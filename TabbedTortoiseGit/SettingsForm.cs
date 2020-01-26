#nullable enable

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
            using SettingsForm f = new SettingsForm
            {
                KeyboardShortcuts = Settings.Default.KeyboardShortcuts,

                StartupRepos = Settings.Default.StartupRepos.ToArray(),
                OpenStartupReposOnReOpen = Settings.Default.OpenStartupReposOnReOpen,

                TabContextMenuGitActions = Settings.Default.TabContextMenuGitActions,
                ConfirmFasterFetch = Settings.Default.ConfirmFasterFetch,

                CustomActions = Settings.Default.CustomActions,

                NormalTabFont = Settings.Default.NormalTabFont,
                NormalTabFontColor = Settings.Default.NormalTabFontColor,
                IndicateModifiedTabs = Settings.Default.IndicateModifiedTabs,
                CheckForModifiedTabsInterval = Settings.Default.CheckForModifiedTabsInterval,
                ModifiedTabFont = Settings.Default.ModifiedTabFont,
                ModifiedTabFontColor = Settings.Default.ModifiedTabFontColor,
                HideReferencesDisplay = Settings.Default.HideReferencesDisplay,

                MaxRecentRepos = Settings.Default.MaxRecentRepos,
                ConfirmOnClose = Settings.Default.ConfirmOnClose,
                CloseWindowOnLastTabClosed = Settings.Default.CloseWindowOnLastTabClosed,
                CloseToSystemTray = Settings.Default.CloseToSystemTray,
                RunOnStartup = TTG.RunOnStartup,
                CheckTortoiseGitOnPath = Settings.Default.CheckTortoiseGitOnPath,
                ShowChangelogOnUpdate = Settings.Default.ShowChangelogOnUpdate,

                DeveloperSettingsEnabled = Settings.Default.DeveloperSettingsEnabled,
                ShowHitTest = Settings.Default.ShowHitTest
            };

            if( f.ShowDialog() == DialogResult.OK )
            {
                Settings.Default.KeyboardShortcuts = f.KeyboardShortcuts;

                Settings.Default.StartupRepos = f.StartupRepos.ToList();
                Settings.Default.OpenStartupReposOnReOpen = f.OpenStartupReposOnReOpen;

                Settings.Default.TabContextMenuGitActions = f.TabContextMenuGitActions;
                Settings.Default.ConfirmFasterFetch = f.ConfirmFasterFetch;

                Settings.Default.CustomActions = f.CustomActions;

                Settings.Default.NormalTabFont = f.NormalTabFont;
                Settings.Default.NormalTabFontColor = f.NormalTabFontColor;
                Settings.Default.CheckForModifiedTabsInterval = f.CheckForModifiedTabsInterval;
                Settings.Default.IndicateModifiedTabs = f.IndicateModifiedTabs;
                Settings.Default.ModifiedTabFont = f.ModifiedTabFont;
                Settings.Default.ModifiedTabFontColor = f.ModifiedTabFontColor;
                Settings.Default.HideReferencesDisplay = f.HideReferencesDisplay;

                Settings.Default.MaxRecentRepos = f.MaxRecentRepos;
                Settings.Default.RecentRepos = Settings.Default.RecentRepos.Take( Settings.Default.MaxRecentRepos ).ToList();
                Settings.Default.ConfirmOnClose = f.ConfirmOnClose;
                Settings.Default.CloseWindowOnLastTabClosed = f.CloseWindowOnLastTabClosed;
                Settings.Default.CloseToSystemTray = f.CloseToSystemTray;
                TTG.RunOnStartup = f.RunOnStartup;
                Settings.Default.CheckTortoiseGitOnPath = f.CheckTortoiseGitOnPath;
                Settings.Default.ShowChangelogOnUpdate = f.ShowChangelogOnUpdate;

                Settings.Default.DeveloperSettingsEnabled = f.DeveloperSettingsEnabled;
                Settings.Default.ShowHitTest = f.ShowHitTest;

                Settings.Default.Save();

                return true;
            }
            else
            {
                return false;
            }
        }

        public Dictionary<KeyboardShortcuts, Shortcut> KeyboardShortcuts
        {
            get
            {
                return _shortcutTextboxes.ToDictionary( pair => pair.Key, pair => (Shortcut)pair.Value.Tag );
            }

            set
            {
                foreach( KeyboardShortcuts keyboardShortcut in Enum.GetValues( typeof( KeyboardShortcuts ) ) )
                {
                    if( value.TryGetValue( keyboardShortcut, out Shortcut shortcut ) )
                    {
                        UpdateShortcutTextBox( _shortcutTextboxes[ keyboardShortcut ], shortcut );
                    }
                }
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
                    if( GitAction.ACTIONS.ContainsKey( action ) )
                    {
                        GitActionsCheckList.Items.Remove( action );
                        GitActionsCheckList.Items.Insert( 0, action );
                        int index = GitActionsCheckList.Items.IndexOf( action );
                        GitActionsCheckList.SetItemChecked( index, true );
                    }
                }
            }
        }

        public bool ConfirmFasterFetch
        {
            get
            {
                return ConfirmFasterFetchCheck.Checked;
            }

            set
            {
                ConfirmFasterFetchCheck.Checked = value;
            }
        }

        public List<CustomAction> CustomActions
        {
            get
            {
                return new List<CustomAction>( _customActions );
            }

            set
            {
                _customActions.Clear();

                if( value != null )
                {
                    foreach( CustomAction action in value )
                    {
                        _customActions.Add( action );
                    }
                }
            }
        }

        public Font NormalTabFont
        {
            get
            {
                return NormalTabFontSample.Font;
            }

            set
            {
                NormalTabFontSample.Font = value;
            }
        }

        public Color NormalTabFontColor
        {
            get
            {
                return NormalTabFontSample.ForeColor;
            }

            set
            {
                NormalTabFontSample.ForeColor = value;
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

        public bool HideReferencesDisplay
        {
            get
            {
                return HideReferencesDisplayCheck.Checked;
            }

            set
            {
                HideReferencesDisplayCheck.Checked = value;
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

        public bool CheckTortoiseGitOnPath
        {
            get { return CheckTortoiseGitOnPathCheck.Checked; }
            set { CheckTortoiseGitOnPathCheck.Checked = value; }
        }

        public bool ShowChangelogOnUpdate
        {
            get { return ShowChangelogOnUpdateCheck.Checked; }
            set { ShowChangelogOnUpdateCheck.Checked = value; }
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

        private readonly CommonOpenFileDialog _folderDialog;
        private readonly CheckListDragDrophelper _dragDropHelper;
        private readonly Dictionary<KeyboardShortcuts, TextBox> _shortcutTextboxes = new Dictionary<KeyboardShortcuts, TextBox>();
        private readonly BindingList<CustomAction> _customActions = new BindingList<CustomAction>();

        public SettingsForm()
        {
            InitializeComponent();

            this.Icon = Resources.TortoiseIcon;

            _folderDialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };

            this.KeyPress += SettingsForm_KeyPress;

            this.AddDefaultRepo.Click += AddDefaultRepo_Click;
            this.RemoveDefaultRepo.Click += RemoveDefaultRepo_Click;

            this.StartupReposList.SelectedValueChanged += DefaultReposList_SelectedValueChanged;

            this.GitActionsCheckList.Items.AddRange( GitAction.ACTIONS.Keys.ToArray() );

            this.ResetNormalTabFontButton.Click += ResetNormalTabFontButton_Click;
            this.ChangeNormalTabFontButton.Click += ChangeNormalTabFontButton_Click;

            this.ResetModifiedTabFontButton.Click += ResetModifiedTabFontButton_Click;
            this.ChangeModifiedTabFontButton.Click += ChangeModifiedTabFontButton_Click;

            _dragDropHelper = new CheckListDragDrophelper();
            _dragDropHelper.AddControl( GitActionsCheckList );

            KeyBoardShortcutsTableLayout.RowStyles.Clear();

            foreach( KeyboardShortcuts keyboardShortcut in Enum.GetValues( typeof( KeyboardShortcuts ) ) )
            {
                Label shortcutLabel = new Label()
                {
                    Anchor = AnchorStyles.Left,
                    AutoSize = true,
                    Text = keyboardShortcut.GetDescription()
                };

                TextBox shortcutText = new TextBox()
                {
                    AcceptsTab = true,
                    Anchor = AnchorStyles.Left,
                    Width = 180,
                    ReadOnly = true,
                    ShortcutsEnabled = false,
                    TabStop = false
                };

                shortcutText.Enter += ShortcutText_Enter;
                shortcutText.PreviewKeyDown += ShortcutTextBox_PreviewKeyDown;
                shortcutText.KeyDown += ShortcutText_KeyDown;
                _shortcutTextboxes.Add( keyboardShortcut, shortcutText );

                KeyBoardShortcutsTableLayout.RowStyles.Add( new RowStyle( SizeType.AutoSize ) );

                KeyBoardShortcutsTableLayout.Controls.Add( shortcutLabel );
                KeyBoardShortcutsTableLayout.Controls.Add( shortcutText );
            }

            KeyBoardShortcutsTableLayout.RowStyles.Add( new RowStyle( SizeType.Percent, 1.0f ) );
            KeyBoardShortcutsTableLayout.RowCount++;

            CustomActionsDataGridView.AutoGenerateColumns = false;
            CustomActionsDataGridView.DataSource = _customActions;
        }

        protected override bool ProcessTabKey( bool forward )
        {
            if( _shortcutTextboxes.Values.Contains( this.ActiveControl ) )
            {
                return true;
            }
            else
            {
                return base.ProcessTabKey( forward );
            }
        }

        private void ShortcutText_Enter( object sender, EventArgs e )
        {
            TextBox shortcutText = (TextBox)sender;

            UpdateShortcutTextBox( shortcutText, Shortcut.Empty );
        }

        private void ShortcutTextBox_PreviewKeyDown( object sender, PreviewKeyDownEventArgs e )
        {
            TextBox shortcutText = (TextBox)sender;

            Shortcut shortcut = Shortcut.FromKeyEventArgs( e );
            UpdateShortcutTextBox( shortcutText, shortcut );
        }

        private void ShortcutText_KeyDown( object sender, KeyEventArgs e )
        {
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void UpdateShortcutTextBox( TextBox textbox, Shortcut shortcut )
        {
            textbox.Tag = shortcut;
            textbox.Text = shortcut?.Text;
            textbox.SelectionStart = textbox.TextLength;
        }

        private static readonly String CHEAT_CODE = "developer";
        private readonly Queue<char> _cheatCode = new Queue<char>();

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
                if( Git.IsInRepo( path ) )
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

        private void ResetNormalTabFontButton_Click( object sender, EventArgs e )
        {
            this.NormalTabFont = SystemFonts.DefaultFont;
            this.NormalTabFontColor = SystemColors.ControlText;
        }

        private void ChangeNormalTabFontButton_Click( object sender, EventArgs e )
        {
            NormalTabFontDialog.Font = this.NormalTabFont;
            NormalTabFontDialog.Color = this.NormalTabFontColor;
            if( NormalTabFontDialog.ShowDialog() == DialogResult.OK )
            {
                this.NormalTabFont = NormalTabFontDialog.Font;
                this.NormalTabFontColor = NormalTabFontDialog.Color;
            }
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
            protected override bool AllowDrag( CheckedListBox parent, string item, int index )
            {
                return true;
            }

            protected override bool GetItemFromPoint( CheckedListBox parent, Point p, out String? item, out int itemIndex )
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

            protected override bool AllowDrop( CheckedListBox dragParent, string dragItem, int dragItemIndex, CheckedListBox pointedParent, string pointedItem, int pointedItemIndex )
            {
                return true;
            }

            protected override void MoveItem( CheckedListBox dragParent, string dragItem, int dragItemIndex, CheckedListBox pointedParent, string pointedItem, int pointedItemIndex )
            {
                bool dragItemChecked = dragParent.GetItemChecked( dragItemIndex );
                bool pointedItemChecked = pointedParent.GetItemChecked( pointedItemIndex );

                dragParent.Items[ dragItemIndex ] = pointedItem;
                dragParent.SetItemChecked( dragItemIndex, pointedItemChecked );
                dragParent.SetSelected( dragItemIndex, false );

                pointedParent.Items[ pointedItemIndex ] = dragItem;
                pointedParent.SetItemChecked( pointedItemIndex, dragItemChecked );
                pointedParent.SetSelected( pointedItemIndex, true );
            }
        }

        private void CustomActionsDataGridView_SelectionChanged( object sender, EventArgs e )
        {
            if( CustomActionsDataGridView.SelectedRows.Count > 0 )
            {
                EditCustomAction.Enabled = true;
                RemoveCustomAction.Enabled = true;
            }
            else
            {
                EditCustomAction.Enabled = false;
                RemoveCustomAction.Enabled = false;
            }
        }

        private void CreateCustomAction_Click( object sender, EventArgs e )
        {
            using CustomActionDialog dialog = new CustomActionDialog();
            if( dialog.ShowDialog() == DialogResult.OK )
            {
                if( dialog.CustomAction != null )
                {
                    _customActions.Add( dialog.CustomAction );
                }
            }
        }

        private void EditCustomAction_Click( object sender, EventArgs e )
        {
            if( CustomActionsDataGridView.SelectedRows.Count > 0 )
            {
                DataGridViewRow row = CustomActionsDataGridView.SelectedRows[ 0 ];

                using CustomActionDialog dialog = new CustomActionDialog
                {
                    CustomAction = row.DataBoundItem as CustomAction
                };
                if( dialog.ShowDialog() == DialogResult.OK )
                {
                    if( dialog.CustomAction != null )
                    {
                        _customActions[ row.Index ] = dialog.CustomAction;
                    }
                }
            }
        }

        private void RemoveCustomAction_Click( object sender, EventArgs e )
        {
            if( CustomActionsDataGridView.SelectedRows.Count > 0 )
            {
                DataGridViewRow row = CustomActionsDataGridView.SelectedRows[ 0 ];

                _customActions.RemoveAt( row.Index );
            }
        }
    }
}
