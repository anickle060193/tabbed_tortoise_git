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
            this.FindRepoDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.NewTabContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogTabs = new TabbedTortoiseGit.ExtendedTabControl();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.NotifyIconContextMenu.SuspendLayout();
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
            this.RecentReposMenu});
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.Size = new System.Drawing.Size(61, 20);
            this.OptionsMenu.Text = "Options";
            // 
            // OpenRepoMenuItem
            // 
            this.OpenRepoMenuItem.Name = "OpenRepoMenuItem";
            this.OpenRepoMenuItem.Size = new System.Drawing.Size(145, 22);
            this.OpenRepoMenuItem.Text = "Open";
            // 
            // RecentReposMenu
            // 
            this.RecentReposMenu.Enabled = false;
            this.RecentReposMenu.Name = "RecentReposMenu";
            this.RecentReposMenu.Size = new System.Drawing.Size(145, 22);
            this.RecentReposMenu.Text = "Recent Repos";
            // 
            // FindRepoDialog
            // 
            this.FindRepoDialog.ShowNewFolderButton = false;
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
            this.OpenMenuItem,
            this.ExitMenuItem});
            this.NotifyIconContextMenu.Name = "NotifyIconContextMenu";
            this.NotifyIconContextMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ExitMenuItem.Text = "Exit";
            // 
            // LogTabs
            // 
            this.LogTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTabs.Location = new System.Drawing.Point(0, 24);
            this.LogTabs.Name = "LogTabs";
            this.LogTabs.NewTabContextMenu = this.NewTabContextMenu;
            this.LogTabs.SelectedIndex = 0;
            this.LogTabs.Size = new System.Drawing.Size(644, 462);
            this.LogTabs.TabIndex = 0;
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.Size = new System.Drawing.Size(152, 22);
            this.OpenMenuItem.Text = "Open";
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
            this.Text = "Tabbed Tortoise Git";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.NotifyIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExtendedTabControl LogTabs;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenRepoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RecentReposMenu;
        private System.Windows.Forms.FolderBrowserDialog FindRepoDialog;
        private System.Windows.Forms.ContextMenuStrip NewTabContextMenu;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip NotifyIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
    }
}

