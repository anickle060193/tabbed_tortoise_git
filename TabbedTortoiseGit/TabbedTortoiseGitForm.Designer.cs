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
            this.OpenRepoLocationTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FavoriteRepoTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseRepoTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogTabs = new TabbedTortoiseGit.ExtendedTabControl();
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
            this.OptionsMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.OptionsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OptionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenRepoMenuItem,
            this.RecentReposMenu,
            this.OptionsMenuSeparator1,
            this.SettingsMenuItem,
            this.AboutMenuItem,
            this.ExitMenuItem});
            this.OptionsMenu.Image = global::TabbedTortoiseGit.Properties.Resources.MoreVert;
            this.OptionsMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.Size = new System.Drawing.Size(26, 20);
            this.OptionsMenu.Text = "Options";
            // 
            // OpenRepoMenuItem
            // 
            this.OpenRepoMenuItem.Name = "OpenRepoMenuItem";
            this.OpenRepoMenuItem.Size = new System.Drawing.Size(145, 22);
            this.OpenRepoMenuItem.Text = "Open Repo";
            // 
            // RecentReposMenu
            // 
            this.RecentReposMenu.Enabled = false;
            this.RecentReposMenu.Name = "RecentReposMenu";
            this.RecentReposMenu.Size = new System.Drawing.Size(145, 22);
            this.RecentReposMenu.Text = "Recent Repos";
            // 
            // OptionsMenuSeparator1
            // 
            this.OptionsMenuSeparator1.Name = "OptionsMenuSeparator1";
            this.OptionsMenuSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Size = new System.Drawing.Size(145, 22);
            this.SettingsMenuItem.Text = "Settings";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(145, 22);
            this.AboutMenuItem.Text = "About";
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(145, 22);
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
            this.OpenRepoLocationTabMenuItem,
            this.FavoriteRepoTabMenuItem,
            this.CloseRepoTabMenuItem});
            this.TabContextMenu.Name = "TabContextMenu";
            this.TabContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.TabContextMenu.Size = new System.Drawing.Size(183, 92);
            // 
            // OpenRepoLocationTabMenuItem
            // 
            this.OpenRepoLocationTabMenuItem.Image = global::TabbedTortoiseGit.Properties.Resources.OpenLocation;
            this.OpenRepoLocationTabMenuItem.Name = "OpenRepoLocationTabMenuItem";
            this.OpenRepoLocationTabMenuItem.Size = new System.Drawing.Size(182, 22);
            this.OpenRepoLocationTabMenuItem.Text = "Open Repo Location";
            // 
            // FavoriteRepoTabMenuItem
            // 
            this.FavoriteRepoTabMenuItem.Name = "FavoriteRepoTabMenuItem";
            this.FavoriteRepoTabMenuItem.Size = new System.Drawing.Size(182, 22);
            this.FavoriteRepoTabMenuItem.Text = "Favorite Repo";
            // 
            // CloseRepoTabMenuItem
            // 
            this.CloseRepoTabMenuItem.Name = "CloseRepoTabMenuItem";
            this.CloseRepoTabMenuItem.Size = new System.Drawing.Size(182, 22);
            this.CloseRepoTabMenuItem.Text = "Close";
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
        private System.Windows.Forms.ToolStripMenuItem OpenRepoLocationTabMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FavoriteRepoTabMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseRepoTabMenuItem;
    }
}

