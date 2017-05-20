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
            if( Settings.Default.DefaultRepos != null )
            {
                f.DefaultRepos = Settings.Default.DefaultRepos.ToArray();
            }
            f.RetainLogsOnClose = Settings.Default.RetainLogsOnClose;
            f.ConfirmOnClose = Settings.Default.ConfirmOnClose;
            f.MaxRecentRepos = Settings.Default.MaxRecentRepos;
            if( Settings.Default.TabContextMenuGitActions != null )
            {
                f.TabContextMenuGitActions = Settings.Default.TabContextMenuGitActions;
            }

            if( f.ShowDialog() == DialogResult.OK )
            {
                Settings.Default.DefaultRepos = f.DefaultRepos.ToList();
                Settings.Default.RetainLogsOnClose = f.RetainLogsOnClose;
                Settings.Default.ConfirmOnClose = f.ConfirmOnClose;
                Settings.Default.MaxRecentRepos = f.MaxRecentRepos;
                if( Settings.Default.RecentRepos != null )
                {
                    Settings.Default.RecentRepos = Settings.Default.RecentRepos.Take( Settings.Default.MaxRecentRepos ).ToList();
                }
                Settings.Default.TabContextMenuGitActions = f.TabContextMenuGitActions;
                Settings.Default.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public String[] DefaultRepos
        {
            get
            {
                return DefaultReposList.Items.Cast<String>().ToArray();
            }

            set
            {
                DefaultReposList.Items.Clear();
                DefaultReposList.Items.AddRange( value );
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

        public SettingsForm()
        {
            InitializeComponent();

            _folderDialog = new CommonOpenFileDialog();
            _folderDialog.IsFolderPicker = true;

            this.AddDefaultRepo.Click += AddDefaultRepo_Click;
            this.RemoveDefaultRepo.Click += RemoveDefaultRepo_Click;

            this.DefaultReposList.SelectedValueChanged += DefaultReposList_SelectedValueChanged;

            this.GitActionsCheckList.Items.AddRange( TortoiseGit.ACTIONS.Keys.ToArray() );

            var helper = new CheckListDragDrophelper( GitActionsCheckList );
        }

        class CheckListDragDrophelper : DragDropHelper<CheckedListBox, String>
        {
            public CheckListDragDrophelper( params CheckedListBox[] checkLists ) : base( checkLists )
            {
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

            protected override void SwapItems( CheckedListBox dragParent, string dragItem, int dragItemIndex, CheckedListBox pointedParent, string pointedItem, int pointedItemIndex )
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

        private void AddDefaultRepo_Click( object sender, EventArgs e )
        {
            if( _folderDialog.ShowDialog() == CommonFileDialogResult.Ok )
            {
                String path = _folderDialog.FileName;
                if( Git.IsRepo( path ) )
                {
                    DefaultReposList.Items.Add( path );
                }
                else
                {
                    MessageBox.Show( "Directory is not a Git repo.", "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        private void RemoveDefaultRepo_Click( object sender, EventArgs e )
        {
            foreach( String defaultRepo in this.DefaultReposList.SelectedItems.Cast<String>().ToArray() )
            {
                this.DefaultReposList.Items.Remove( defaultRepo );
            }
        }

        private void DefaultReposList_SelectedValueChanged( object sender, EventArgs e )
        {
            UpdateDefaultReposActions();
        }

        private void UpdateDefaultReposActions()
        {
            if( this.DefaultReposList.SelectedItems.Count != 0 )
            {
                RemoveDefaultRepo.Enabled = true;
            }
            else
            {
                RemoveDefaultRepo.Enabled = false;
            }
        }
    }
}
