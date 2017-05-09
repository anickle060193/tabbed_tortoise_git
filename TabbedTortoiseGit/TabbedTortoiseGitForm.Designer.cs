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
            this.LogTabs = new TabbedTortoiseGit.ExtendedTabControl();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.OptionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenRepoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RecentReposMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FindRepoDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogTabs
            // 
            this.LogTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTabs.Location = new System.Drawing.Point(0, 24);
            this.LogTabs.Name = "LogTabs";
            this.LogTabs.SelectedIndex = 0;
            this.LogTabs.Size = new System.Drawing.Size(644, 437);
            this.LogTabs.TabIndex = 0;
            this.LogTabs.NewTabClicked += new System.EventHandler(this.LogTabs_NewTabClicked);
            this.LogTabs.TabClosed += new System.EventHandler<TabbedTortoiseGit.TabClosedEventArgs>(this.LogTabs_TabClosed);
            this.LogTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.LogTabs_Selected);
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionsMenu});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(644, 24);
            this.Menu.TabIndex = 1;
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
            this.OpenRepoMenuItem.Click += new System.EventHandler(this.OpenRepoMenuItem_Click);
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
            // TabbedTortoiseGitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 461);
            this.Controls.Add(this.LogTabs);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.MinimumSize = new System.Drawing.Size(660, 500);
            this.Name = "TabbedTortoiseGitForm";
            this.Text = "Tabbed Tortoise Git";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TabbedTortoiseGitForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TabbedTortoiseGitForm_FormClosed);
            this.Load += new System.EventHandler(this.TabbedTortoiseGitForm_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExtendedTabControl LogTabs;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenRepoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RecentReposMenu;
        private System.Windows.Forms.FolderBrowserDialog FindRepoDialog;
    }
}

