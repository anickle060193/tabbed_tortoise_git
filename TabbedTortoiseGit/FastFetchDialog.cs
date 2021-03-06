﻿using Common;
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
        public String Repo { get; private set; }

        public FastFetchDialog( String repo )
        {
            InitializeComponent();
            UpdateFromSettings();

            this.Icon = Resources.TortoiseIcon;

            Repo = repo;
            this.Text = $"{repo} - {this.Text}";

            TagsCheck.CheckedChanged += TagsCheck_CheckedChanged;
            PruneCheck.CheckedChanged += PruneCheck_CheckedChanged;
            ShowProgressCheck.CheckedChanged += ShowProgressCheck_CheckedChanged;
            MaxProcessesNumeric.ValueChanged += MaxProcessesNumeric_ValueChanged;

            Ok.Click += Ok_Click;
            Cancel.Click += Cancel_Click;
        }

        private void TagsCheck_CheckedChanged( object? sender, EventArgs e )
        {
            Settings.Default.FastFetchTagsChecked = TagsCheck.Checked;
            Settings.Default.Save();
        }

        private void PruneCheck_CheckedChanged( object? sender, EventArgs e )
        {
            Settings.Default.FastFetchPruneChecked = PruneCheck.Checked;
            Settings.Default.Save();
        }

        private void ShowProgressCheck_CheckedChanged( object? sender, EventArgs e )
        {
            Settings.Default.FastFetchShowProgress = ShowProgressCheck.Checked;
            Settings.Default.Save();
        }

        private void MaxProcessesNumeric_ValueChanged( object? sender, EventArgs e )
        {
            Settings.Default.FastFetchMaxProcesses = (int)MaxProcessesNumeric.Value;
            Settings.Default.Save();
        }

        private void Cancel_Click( object? sender, EventArgs e )
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void Ok_Click( object? sender, EventArgs e )
        {
            await Fetch();
        }

        private void UpdateFromSettings()
        {
            TagsCheck.Checked = Settings.Default.FastFetchTagsChecked;
            PruneCheck.Checked = Settings.Default.FastFetchPruneChecked;
            ShowProgressCheck.Checked = Settings.Default.FastFetchShowProgress;
            MaxProcessesNumeric.Value = Settings.Default.FastFetchMaxProcesses;
        }

        private static ProcessProgressTask CreateFetchTask( String path, bool tags, bool prune, bool progress, bool isSubmodule )
        {
            StringBuilder args = new StringBuilder( "fetch " );

            if( progress )
            {
                args.Append( "--progress " );
            }

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
            return new ProcessProgressTask( p, true );
        }

        private async Task Fetch()
        {
            this.Hide();

            bool tags = TagsCheck.Checked;
            bool prune = PruneCheck.Checked;
            bool progress = ShowProgressCheck.Checked;
            int maxProcesses = (int)MaxProcessesNumeric.Value;

            await FastFetchDialog.Fetch( this.Text, "Fast Fetch Completed", Repo, tags, prune, progress, maxProcesses );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private static ProgressDialog PrepareFetch( String title, String completedText, String repo, bool tags, bool prune, bool progress, int maxProcesses )
        {
            ProgressDialog dialog = new ProgressDialog()
            {
                Title = title,
                CompletedText = completedText,
                MaxTasks = maxProcesses,
                ErrorTextColor = Color.Black
            };

            dialog.AddTask( CreateFetchTask( repo, tags, prune, progress, false ) );
            dialog.AddTask( new FetchSubmodulesProgressTask( repo, tags, prune, progress ) );

            return dialog;
        }

        private static Task Fetch( String title, String completedText, String repo, bool tags, bool prune, bool progress, int maxProcesses )
        {
            ProgressDialog dialog = FastFetchDialog.PrepareFetch( title, completedText, repo, tags, prune, progress, maxProcesses );

            dialog.Show();
            dialog.DoProgress();

            return dialog.WaitForClose();
        }

        public static async Task<bool> FasterFetch( String repo )
        {
            if( Settings.Default.ConfirmFasterFetch )
            {
                using ConfirmationDialog dialog = new ConfirmationDialog( "Faster Fetch", "Faster Fetch uses settings previously configured in the Fast Fetch dialog.\n\nDo you want to continue?" );
                if( dialog.ShowDialog() == DialogResult.Yes )
                {
                    if( dialog.DoNotAskAgain )
                    {
                        Settings.Default.ConfirmFasterFetch = false;
                        Settings.Default.Save();
                    }
                }
                else
                {
                    return false;
                }
            }

            bool tags = Settings.Default.FastFetchTagsChecked;
            bool prune = Settings.Default.FastFetchPruneChecked;
            bool progress = Settings.Default.FastFetchShowProgress;
            int maxProcesses = Settings.Default.FastFetchMaxProcesses;

            await FastFetchDialog.Fetch( repo + " - " + "Faster Fetch", "Faster Fetch Completed", repo, tags, prune, progress, maxProcesses );
            return true;
        }

        public static ProgressDialog PrepareBackgroundFasterFetch( String repo )
        {
            bool tags = Settings.Default.FastFetchTagsChecked;
            bool prune = Settings.Default.FastFetchPruneChecked;
            bool progress = Settings.Default.FastFetchShowProgress;
            int maxProcesses = Settings.Default.FastFetchMaxProcesses;

            return FastFetchDialog.PrepareFetch( repo + " - " + "Faster Fetch", "Faster Fetch Completed", repo, tags, prune, progress, maxProcesses );
        }

        class FetchSubmodulesProgressTask : RetrieveSubmodulesProgressTask
        {
            public bool Tags { get; private set; }
            public bool Prune { get; private set; }
            public bool Progress { get; private set; }

            public FetchSubmodulesProgressTask( String repo, bool tags, bool prune, bool progress ) : base( repo, false, false )
            {
                this.Tags = tags;
                this.Prune = prune;
                this.Progress = progress;
            }

            protected override ProcessProgressTask GetTaskForSubmodule( string submodule )
            {
                String submodulePath = Path.GetFullPath( Path.Combine( this.Repo, submodule ) );
                return CreateFetchTask( submodulePath, this.Tags, this.Prune, this.Progress, true );
            }
        }
    }
}
