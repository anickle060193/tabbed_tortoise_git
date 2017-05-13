namespace TabbedTortoiseGit
{
    partial class TabbedTortoiseGitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.OptionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenRepoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RecentReposMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewTabContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenNotifyIconMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitNotifyIconMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenRepoLocationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabContextMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.CommitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FetchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PullMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SwitchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PushMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RebaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SubmoduleUpdateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogTabs = new TabbedTortoiseGit.ExtendedTabControl();
            this.SyncMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.NotifyIconContextMenu.SuspendLayout();
            this.TabContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionsMenu});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(644, 24);
            this.MenuStrip.TabIndex = 1;
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenRepoMenuItem,
            this.RecentReposMenu,
            this.OptionsMenuSeparator1,
            this.SettingsMenuItem,
            this.AboutMenuItem,
            this.ExitMenuItem});
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.Size = new System.Drawing.Size(61, 20);
            this.OptionsMenu.Text = "Options";
            // 
            // OpenRepoMenuItem
            // 
            this.OpenRepoMenuItem.Name = "OpenRepoMenuItem";
            this.OpenRepoMenuItem.Size = new System.Drawing.Size(152, 22);
            this.OpenRepoMenuItem.Text = "Open Repo";
            // 
            // RecentReposMenu
            // 
            this.RecentReposMenu.Enabled = false;
            this.RecentReposMenu.Name = "RecentReposMenu";
            this.RecentReposMenu.Size = new System.Drawing.Size(152, 22);
            this.RecentReposMenu.Text = "Recent Repos";
            // 
            // OptionsMenuSeparator1
            // 
            this.OptionsMenuSeparator1.Name = "OptionsMenuSeparator1";
            this.OptionsMenuSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SettingsMenuItem.Text = "Settings";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AboutMenuItem.Text = "About";
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ExitMenuItem.Text = "Exit";
            // 
            // NewTabContextMenu
            // 
            this.NewTabContextMenu.Name = "NewTabContextMenu";
            this.NewTabContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.NotifyIconContextMenu;
            this.NotifyIcon.Text = "Tabbed TortoiseGit";
            this.NotifyIcon.Visible = true;
            // 
            // NotifyIconContextMenu
            // 
            this.NotifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenNotifyIconMenuItem,
            this.ExitNotifyIconMenuItem});
            this.NotifyIconContextMenu.Name = "NotifyIconContextMenu";
            this.NotifyIconContextMenu.Size = new System.Drawing.Size(104, 48);
            // 
            // OpenNotifyIconMenuItem
            // 
            this.OpenNotifyIconMenuItem.Name = "OpenNotifyIconMenuItem";
            this.OpenNotifyIconMenuItem.Size = new System.Drawing.Size(103, 22);
            this.OpenNotifyIconMenuItem.Text = "Open";
            // 
            // ExitNotifyIconMenuItem
            // 
            this.ExitNotifyIconMenuItem.Name = "ExitNotifyIconMenuItem";
            this.ExitNotifyIconMenuItem.Size = new System.Drawing.Size(103, 22);
            this.ExitNotifyIconMenuItem.Text = "Exit";
            // 
            // TabContextMenu
            // 
            this.TabContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenRepoLocationMenuItem,
            this.TabContextMenuSeparator,
            this.CommitMenuItem,
            this.FetchMenuItem,
            this.PullMenuItem,
            this.SwitchMenuItem,
            this.PushMenuItem,
            this.RebaseMenuItem,
            this.SyncMenuItem,
            this.SubmoduleUpdateMenuItem});
            this.TabContextMenu.Name = "TabContextMenu";
            this.TabContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.TabContextMenu.Size = new System.Drawing.Size(183, 230);
            // 
            // OpenRepoLocationMenuItem
            // 
            this.OpenRepoLocationMenuItem.Image = global::TabbedTortoiseGit.Properties.Resources.OpenLocation;
            this.OpenRepoLocationMenuItem.Name = "OpenRepoLocationMenuItem";
            this.OpenRepoLocationMenuItem.Size = new System.Drawing.Size(182, 22);
            this.OpenRepoLocationMenuItem.Text = "Open Repo Location";
            // 
            // TabContextMenuSeparator
            // 
            this.TabContextMenuSeparator.Name = "TabContextMenuSeparator";
            this.TabContextMenuSeparator.Size = new System.Drawing.Size(179, 6);
            // 
            // CommitMenuItem
            // 
            this.CommitMenuItem.Image = global::TabbedTortoiseGit.Properties.Resources.Commit;
            this.CommitMenuItem.Name = "CommitMenuItem";
            this.CommitMenuItem.Size = new System.Drawing.Size(182, 22);
            this.CommitMenuItem.Text = "Commit";
            // 
            // FetchMenuItem
            // 
            this.FetchMenuItem.Image = global::TabbedTortoiseGit.Properties.Resources.Fetch;
            this.FetchMenuItem.Name = "FetchMenuItem";
            this.FetchMenuItem.Size = new System.Drawing.Size(182, 22);
            this.FetchMenuItem.Text = "Fetch";
            // 
            // PullMenuItem
            // 
            this.PullMenuItem.Image = global::TabbedTortoiseGit.Properties.Resources.Pull;
            this.PullMenuItem.Name = "PullMenuItem";
            this.PullMenuItem.Size = new System.Drawing.Size(182, 22);
            this.PullMenuItem.Text = "Pull";
            // 
            // SwitchMenuItem
            // 
            this.SwitchMenuItem.Image = global::TabbedTortoiseGit.Properties.Resources.Switch;
            this.SwitchMenuItem.Name = "SwitchMenuItem";
            this.SwitchMenuItem.Size = new System.Drawing.Size(182, 22);
            this.SwitchMenuItem.Text = "Switch/Checkout";
            // 
            // PushMenuItem
            // 
            this.PushMenuItem.Image = global::TabbedTortoiseGit.Properties.Resources.Push;
            this.PushMenuItem.Name = "PushMenuItem";
            this.PushMenuItem.Size = new System.Drawing.Size(182, 22);
            this.PushMenuItem.Text = "Push";
            // 
            // RebaseMenuItem
            // 
            this.RebaseMenuItem.Image = global::TabbedTortoiseGit.Properties.Resources.Rebase;
            this.RebaseMenuItem.Name = "RebaseMenuItem";
            this.RebaseMenuItem.Size = new System.Drawing.Size(182, 22);
            this.RebaseMenuItem.Text = "Rebase";
            // 
            // SubmoduleUpdateMenuItem
            // 
            this.SubmoduleUpdateMenuItem.Image = global::TabbedTortoiseGit.Properties.Resources.SubmoduleUpdate;
            this.SubmoduleUpdateMenuItem.Name = "SubmoduleUpdateMenuItem";
            this.SubmoduleUpdateMenuItem.Size = new System.Drawing.Size(182, 22);
            this.SubmoduleUpdateMenuItem.Text = "Submodule Update";
            // 
            // LogTabs
            // 
            this.LogTabs.AllowDrop = true;
            this.LogTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTabs.Location = new System.Drawing.Point(0, 24);
            this.LogTabs.Name = "LogTabs";
            this.LogTabs.NewTabContextMenu = this.NewTabContextMenu;
            this.LogTabs.SelectedIndex = 0;
            this.LogTabs.Size = new System.Drawing.Size(644, 462);
            this.LogTabs.TabContextMenu = this.TabContextMenu;
            this.LogTabs.TabIndex = 0;
            // 
            // SyncMenuItem
            // 
            this.SyncMenuItem.Image = global::TabbedTortoiseGit.Properties.Resources.Sync;
            this.SyncMenuItem.Name = "SyncMenuItem";
            this.SyncMenuItem.Size = new System.Drawing.Size(182, 22);
            this.SyncMenuItem.Text = "Sync";
            // 
            // TabbedTortoiseGitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 486);
            this.Controls.Add(this.LogTabs);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(660, 525);
            this.Name = "TabbedTortoiseGitForm";
            this.Text = "Tabbed TortoiseGit";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.NotifyIconContextMenu.ResumeLayout(false);
            this.TabContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExtendedTabControl LogTabs;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenRepoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RecentReposMenu;
        private System.Windows.Forms.ContextMenuStrip NewTabContextMenu;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip NotifyIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ExitNotifyIconMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenNotifyIconMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItem;
        private System.Windows.Forms.ToolStripSeparator OptionsMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.ContextMenuStrip TabContextMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenRepoLocationMenuItem;
        private System.Windows.Forms.ToolStripSeparator TabContextMenuSeparator;
        private System.Windows.Forms.ToolStripMenuItem CommitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FetchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PullMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SwitchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PushMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RebaseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SubmoduleUpdateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SyncMenuItem;
    }
}

