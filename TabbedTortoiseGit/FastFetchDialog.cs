using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    public partial class FastFetchDialog : Form
    {
        public static void FastFetch( String repo )
        {
            FastFetchDialog f = new FastFetchDialog( repo );
            f.ShowDialog();
        }

        public String Repo { get; private set; }

        private FastFetchDialog( String repo )
        {
            InitializeComponent();
            UpdateFromSettings();

            this.Icon = Resources.TortoiseIcon;

            Repo = repo;
            this.Text = "{0} - {1}".XFormat( repo, this.Text );

            TagsCheck.CheckedChanged += TagsCheck_CheckedChanged;
            PruneCheck.CheckedChanged += PruneCheck_CheckedChanged;
            MaxProcessesNumeric.ValueChanged += MaxProcessesNumeric_ValueChanged;

            Ok.Click += Ok_Click;
            Cancel.Click += Cancel_Click;
        }

        private void TagsCheck_CheckedChanged( object sender, EventArgs e )
        {
            Settings.Default.FastFetchTagsChecked = TagsCheck.Checked;
            Settings.Default.Save();
        }

        private void PruneCheck_CheckedChanged( object sender, EventArgs e )
        {
            Settings.Default.FastFetchPruneChecked = PruneCheck.Checked;
            Settings.Default.Save();
        }

        private void MaxProcessesNumeric_ValueChanged( object sender, EventArgs e )
        {
            Settings.Default.FastFetchMaxProcesses = (int)MaxProcessesNumeric.Value;
            Settings.Default.Save();
        }

        private void Cancel_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void Ok_Click( object sender, EventArgs e )
        {
            Fetch();
        }

        private void UpdateFromSettings()
        {
            TagsCheck.Checked = Settings.Default.FastFetchTagsChecked;
            PruneCheck.Checked = Settings.Default.FastFetchPruneChecked;
            MaxProcessesNumeric.Value = Settings.Default.FastFetchMaxProcesses;
        }

        private Process CreateFetchProcess( String path, bool tags, bool prune, bool isSubmodule )
        {
            StringBuilder args = new StringBuilder( "fetch " );

            if( tags )
            {
                args.Append( "--tags " );
            }

            if( prune )
            {
                args.Append( "--prune " );
            }

            if( isSubmodule )
            {
                args.Append( "--recurse-submodules=yes " );
            }
            else
            {
                args.Append( "--recurse-submodules=no " );
            }

            Process p = new Process();
            p.StartInfo.FileName = "git.exe";
            p.StartInfo.Arguments = args.ToString();
            p.StartInfo.WorkingDirectory = path;
            return p;
        }

        private void Fetch()
        {
            bool tags = TagsCheck.Checked;
            bool prune = PruneCheck.Checked;
            int maxProcesses = (int)MaxProcessesNumeric.Value;

            List<Process> fetchProcesses = new List<Process>();
            fetchProcesses.Add( CreateFetchProcess( Repo, tags, prune, false ) );

            using( Repository r = new Repository( Repo ) )
            {
                foreach( Submodule submodule in r.Submodules )
                {
                    String submodulePath = Path.Combine( Repo, submodule.Path );
                    Process p = CreateFetchProcess( submodulePath, tags, prune, true );
                    fetchProcesses.Add( p );
                }
            }

            this.Close();
            ProcessProgressForm.ShowProgress( "Fast Fetch", "Fast Fetch Completed", fetchProcesses, maxProcesses );
        }
    }
}
