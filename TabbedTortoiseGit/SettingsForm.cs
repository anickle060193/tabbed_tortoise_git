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
            f.RetainLogsOnClose = Settings.Default.RetainLogsOnClose;
            f.ConfirmOnClose = Settings.Default.ConfirmOnClose;
            f.MaxRecentRepos = Settings.Default.MaxRecentRepos;
            f.TabContextMenuGitActions = Settings.Default.TabContextMenuGitActions;
            f.RunOnStartup = TTG.RunOnStartup;

            if( f.ShowDialog() == DialogResult.OK )
            {
                Settings.Default.StartupRepos = f.StartupRepos.ToList();
                Settings.Default.OpenStartupReposOnReOpen = f.OpenStartupReposOnReOpen;
                Settings.Default.RetainLogsOnClose = f.RetainLogsOnClose;
                Settings.Default.ConfirmOnClose = f.ConfirmOnClose;
                Settings.Default.MaxRecentRepos = f.MaxRecentRepos;
                Settings.Default.RecentRepos = Settings.Default.RecentRepos.Take( Settings.Default.MaxRecentRepos ).ToList();
                Settings.Default.TabContextMenuGitActions = f.TabContextMenuGitActions;
                Settings.Default.Save();

                TTG.RunOnStartup = f.RunOnStartup;
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

        private readonly CommonOpenFileDialog _folderDialog;
        private readonly CheckListDragDrophelper _dragDropHelper;

        public SettingsForm()
        {
            InitializeComponent();

            _folderDialog = new CommonOpenFileDialog();
            _folderDialog.IsFolderPicker = true;

            this.AddDefaultRepo.Click += AddDefaultRepo_Click;
            this.RemoveDefaultRepo.Click += RemoveDefaultRepo_Click;

            this.StartupReposList.SelectedValueChanged += DefaultReposList_SelectedValueChanged;

            this.GitActionsCheckList.Items.AddRange( TortoiseGit.ACTIONS.Keys.ToArray() );

            _dragDropHelper = new CheckListDragDrophelper();
            _dragDropHelper.AddControl( GitActionsCheckList );
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
