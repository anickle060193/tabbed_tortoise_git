using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabbedTortoiseGit
{
    public partial class FastSubmoduleUpdateForm : Form
    {
        class SubmoduleRow
        {
            public Submodule Submodule { get; private set; }
            public String Name { get; private set; }
            public int Progress { get; set; }
            public bool Checked { get; set; }

            public SubmoduleRow( Submodule s )
            {
                Submodule = s;
                Name = Submodule.Name;
                Progress = 0;
                Checked = false;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        public String Repo { get; private set; }

        private readonly Repository _repo;
        private readonly List<SubmoduleRow> _rows;

        public FastSubmoduleUpdateForm( String repo )
        {
            InitializeComponent();

            Repo = repo;
            _repo = new Repository( repo );

            _rows = new List<SubmoduleRow>();
            foreach( Submodule s in _repo.Submodules )
            {
                SubmoduleRow row = new SubmoduleRow( s );
                _rows.Add( row );
                SubmoduleCheckList.Items.Add( row );
            }

            SetChecked( true );


            Cancel.Click += ( sender, e ) => this.Close();
            UpdateSubmodulesButton.Click += UpdateSubmodulesButton_Click;
            SelectAllSubmodules.Click += ( sender, e ) => SetChecked( true );
            SelectNoneSubmodules.Click += ( sender, e ) => SetChecked( false );

            this.Disposed += ( sender, e ) => _repo.Dispose();
        }

        private void UpdateSubmodulesButton_Click( object sender, EventArgs e )
        {
            UpdateSubmodulesButton.Enabled = false;
            UpdateSubmodules();
        }

        private void SetChecked( bool value )
        {
            for( int i = 0; i < SubmoduleCheckList.Items.Count; i++ )
            {
                SubmoduleCheckList.SetItemChecked( i, value );
            }
        }

        private void UpdateSubmodules()
        {
            if( SubmoduleCheckList.CheckedItems.Count > 0 )
            {
                this.Close();
                var processes = SubmoduleCheckList.CheckedItems.Cast<SubmoduleRow>().Select( row => UpdateSubmodule( Repo, row.Submodule.Path ) );
                ProcessProgressForm.ShowProgress( Repo + " - Fast Submodule Update", "Submodule Update Completed", processes );
            }
        }

        public Process UpdateSubmodule( String repoPath, String submodulePath )
        {
            Process p = new Process();
            p.StartInfo.FileName = "git.exe";
            p.StartInfo.Arguments = "submodule update --init --recursive --force -- \"{0}\"".XFormat( submodulePath );
            p.StartInfo.WorkingDirectory = repoPath;
            return p;
        }
    }
}
