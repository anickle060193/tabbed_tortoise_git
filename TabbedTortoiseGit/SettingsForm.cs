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
        private readonly CommonOpenFileDialog _folderDialog;

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
                return UsedGitActions.Items.Cast<String>().ToList();
            }

            set
            {
                foreach( String action in value )
                {
                    if( TortoiseGit.ACTIONS.ContainsKey( action ) )
                    {
                        if( UnusedGitActions.Items.Contains( action ) )
                        {
                            UnusedGitActions.Items.Remove( action );
                        }

                        if( !UsedGitActions.Items.Contains( action ) )
                        {
                            UsedGitActions.Items.Add( action );
                        }
                    }
                }
            }
        }

        public static bool ShowSettingsDialog()
        {
            SettingsForm f = new SettingsForm();
            if( Settings.Default.DefaultRepos != null )
            {
                f.DefaultRepos = Settings.Default.DefaultRepos.ToArray();
            }
            f.RetainLogsOnClose = Settings.Default.RetainLogsOnClose;
            f.MaxRecentRepos = Settings.Default.MaxRecentRepos;
            if( Settings.Default.TabContextMenuGitActions != null )
            {
                f.TabContextMenuGitActions = Settings.Default.TabContextMenuGitActions;
            }

            if( f.ShowDialog() == DialogResult.OK )
            {
                Settings.Default.DefaultRepos = f.DefaultRepos.ToList();
                Settings.Default.RetainLogsOnClose = f.RetainLogsOnClose;
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

        public SettingsForm()
        {
            InitializeComponent();

            _folderDialog = new CommonOpenFileDialog();
            _folderDialog.IsFolderPicker = true;

            this.AddDefaultRepo.Click += AddDefaultRepo_Click;
            this.RemoveDefaultRepo.Click += RemoveDefaultRepo_Click;

            this.DefaultReposList.SelectedValueChanged += DefaultReposList_SelectedValueChanged;

            this.UnusedGitActions.Items.AddRange( TortoiseGit.ACTIONS.Keys.ToArray() );

            this.UnusedGitActions.AllowDrop = true;
            this.UnusedGitActions.MouseDown += GitActions_MouseDown;
            this.UnusedGitActions.DragOver += GitActions_DragOver;
            this.UnusedGitActions.DragDrop += GitActions_DragDrop;

            this.UsedGitActions.AllowDrop = true;
            this.UsedGitActions.MouseDown += GitActions_MouseDown;
            this.UsedGitActions.DragOver += GitActions_DragOver;
            this.UsedGitActions.DragDrop += GitActions_DragDrop;
        }

        private ListBox _fromListBox;
        private int _fromIndex;

        private void GitActions_MouseDown( object sender, MouseEventArgs e )
        {
            ListBox listBox = (ListBox)sender;

            if( listBox.Items.Count == 0 )
            {
                return;
            }

            int index = listBox.IndexFromPoint( e.Location );
            if( index >= 0 )
            {
                _fromListBox = listBox;
                _fromIndex = index;
                String s = (String)listBox.Items[ index ];

                DoDragDrop( s, DragDropEffects.Move );
            }
        }

        private void GitActions_DragOver( object sender, DragEventArgs e )
        {
            if( e.Data.GetDataPresent( DataFormats.StringFormat ) )
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void GitActions_DragDrop( object sender, DragEventArgs e )
        {
            ListBox listBox = (ListBox)sender;

            if( e.Data.GetDataPresent( DataFormats.StringFormat ) )
            {
                String s = (String)e.Data.GetData( DataFormats.StringFormat );
                _fromListBox.Items.RemoveAt( _fromIndex );
                if( listBox.Items.Count == 0 )
                {
                    listBox.Items.Add( s );
                }
                else
                {
                    Point clientPoint = listBox.PointToClient( new Point( e.X, e.Y ) );
                    int index = listBox.IndexFromPoint( clientPoint );
                    if( index < 0 )
                    {
                        listBox.Items.Insert( listBox.Items.Count, s );
                    }
                    else
                    {
                        listBox.Items.Insert( index, s );
                    }
                }
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
