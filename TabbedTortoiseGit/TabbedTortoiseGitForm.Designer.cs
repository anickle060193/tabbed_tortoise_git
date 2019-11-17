﻿namespace TabbedTortoiseGit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabbedTortoiseGitForm));
            this.FavoritesMenuStrip = new System.Windows.Forms.MenuStrip();
            this.NewTabContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TabContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenRepoLocationTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToFavoritesRepoTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenWithReferencesRepoTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DuplicateRepoTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseRepoTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FavoriteRepoContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenFavoriteRepoLocationContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFavoriteWithReferencesContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveFavoriteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenRepoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RecentReposMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.FavoritesManagerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowDebugLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FavoritesMenuContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowFavoritesManagerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FavoritesFolderContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RemoveFavoriteFolderContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifiedRepoCheckBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.SubmodulesToolStripDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.BackgroundFasterFetch = new System.Windows.Forms.ToolStripButton();
            this.BackgroundFasterFetchProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.LogTabs = new Tabs.TabControl();
            this.EditFavoriteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabContextMenu.SuspendLayout();
            this.FavoriteRepoContextMenu.SuspendLayout();
            this.OptionsContextMenu.SuspendLayout();
            this.FavoritesMenuContextMenu.SuspendLayout();
            this.FavoritesFolderContextMenu.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // FavoritesMenuStrip
            // 
            this.FavoritesMenuStrip.BackColor = System.Drawing.Color.White;
            this.FavoritesMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.FavoritesMenuStrip.Name = "FavoritesMenuStrip";
            this.FavoritesMenuStrip.ShowItemToolTips = true;
            this.FavoritesMenuStrip.Size = new System.Drawing.Size(644, 24);
            this.FavoritesMenuStrip.TabIndex = 1;
            // 
            // NewTabContextMenu
            // 
            this.NewTabContextMenu.Name = "NewTabContextMenu";
            this.NewTabContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // TabContextMenu
            // 
            this.TabContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenRepoLocationTabMenuItem,
            this.AddToFavoritesRepoTabMenuItem,
            this.OpenWithReferencesRepoTabMenuItem,
            this.DuplicateRepoTabMenuItem,
            this.CloseRepoTabMenuItem});
            this.TabContextMenu.Name = "TabContextMenu";
            this.TabContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.TabContextMenu.Size = new System.Drawing.Size(190, 114);
            // 
            // OpenRepoLocationTabMenuItem
            // 
            this.OpenRepoLocationTabMenuItem.Image = global::TabbedTortoiseGit.Properties.Resources.OpenLocation;
            this.OpenRepoLocationTabMenuItem.Name = "OpenRepoLocationTabMenuItem";
            this.OpenRepoLocationTabMenuItem.Size = new System.Drawing.Size(189, 22);
            this.OpenRepoLocationTabMenuItem.Text = "Open Repo Location";
            // 
            // AddToFavoritesRepoTabMenuItem
            // 
            this.AddToFavoritesRepoTabMenuItem.Name = "AddToFavoritesRepoTabMenuItem";
            this.AddToFavoritesRepoTabMenuItem.Size = new System.Drawing.Size(189, 22);
            this.AddToFavoritesRepoTabMenuItem.Text = "Add to Favorites";
            // 
            // OpenWithReferencesRepoTabMenuItem
            // 
            this.OpenWithReferencesRepoTabMenuItem.Name = "OpenWithReferencesRepoTabMenuItem";
            this.OpenWithReferencesRepoTabMenuItem.Size = new System.Drawing.Size(189, 22);
            this.OpenWithReferencesRepoTabMenuItem.Text = "Open with References";
            // 
            // DuplicateRepoTabMenuItem
            // 
            this.DuplicateRepoTabMenuItem.Name = "DuplicateRepoTabMenuItem";
            this.DuplicateRepoTabMenuItem.Size = new System.Drawing.Size(189, 22);
            this.DuplicateRepoTabMenuItem.Text = "Duplicate";
            // 
            // CloseRepoTabMenuItem
            // 
            this.CloseRepoTabMenuItem.Name = "CloseRepoTabMenuItem";
            this.CloseRepoTabMenuItem.Size = new System.Drawing.Size(189, 22);
            this.CloseRepoTabMenuItem.Text = "Close";
            // 
            // FavoriteRepoContextMenu
            // 
            this.FavoriteRepoContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFavoriteRepoLocationContextMenuItem,
            this.OpenFavoriteWithReferencesContextMenuItem,
            this.EditFavoriteContextMenuItem,
            this.RemoveFavoriteContextMenuItem});
            this.FavoriteRepoContextMenu.Name = "FavoriteRepoContextMenu";
            this.FavoriteRepoContextMenu.Size = new System.Drawing.Size(190, 114);
            // 
            // OpenFavoriteRepoLocationContextMenuItem
            // 
            this.OpenFavoriteRepoLocationContextMenuItem.Image = global::TabbedTortoiseGit.Properties.Resources.OpenLocation;
            this.OpenFavoriteRepoLocationContextMenuItem.Name = "OpenFavoriteRepoLocationContextMenuItem";
            this.OpenFavoriteRepoLocationContextMenuItem.Size = new System.Drawing.Size(189, 22);
            this.OpenFavoriteRepoLocationContextMenuItem.Text = "Open Repo Location";
            // 
            // OpenFavoriteWithReferencesContextMenuItem
            // 
            this.OpenFavoriteWithReferencesContextMenuItem.Name = "OpenFavoriteWithReferencesContextMenuItem";
            this.OpenFavoriteWithReferencesContextMenuItem.Size = new System.Drawing.Size(189, 22);
            this.OpenFavoriteWithReferencesContextMenuItem.Text = "Open with References";
            // 
            // RemoveFavoriteContextMenuItem
            // 
            this.RemoveFavoriteContextMenuItem.Name = "RemoveFavoriteContextMenuItem";
            this.RemoveFavoriteContextMenuItem.Size = new System.Drawing.Size(189, 22);
            this.RemoveFavoriteContextMenuItem.Text = "Remove Favorite";
            // 
            // OptionsContextMenu
            // 
            this.OptionsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenRepoMenuItem,
            this.RecentReposMenu,
            this.OptionsMenuSeparator,
            this.FavoritesManagerMenuItem,
            this.SettingsMenuItem,
            this.ShowDebugLogMenuItem,
            this.AboutMenuItem,
            this.ExitMenuItem});
            this.OptionsContextMenu.Name = "OptionsContextMenu";
            this.OptionsContextMenu.Size = new System.Drawing.Size(172, 164);
            // 
            // OpenRepoMenuItem
            // 
            this.OpenRepoMenuItem.Name = "OpenRepoMenuItem";
            this.OpenRepoMenuItem.Size = new System.Drawing.Size(171, 22);
            this.OpenRepoMenuItem.Text = "Open Repo";
            // 
            // RecentReposMenu
            // 
            this.RecentReposMenu.Enabled = false;
            this.RecentReposMenu.Name = "RecentReposMenu";
            this.RecentReposMenu.Size = new System.Drawing.Size(171, 22);
            this.RecentReposMenu.Text = "Recent Repos";
            // 
            // OptionsMenuSeparator
            // 
            this.OptionsMenuSeparator.Name = "OptionsMenuSeparator";
            this.OptionsMenuSeparator.Size = new System.Drawing.Size(168, 6);
            // 
            // FavoritesManagerMenuItem
            // 
            this.FavoritesManagerMenuItem.Name = "FavoritesManagerMenuItem";
            this.FavoritesManagerMenuItem.Size = new System.Drawing.Size(171, 22);
            this.FavoritesManagerMenuItem.Text = "Favorites Manager";
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Size = new System.Drawing.Size(171, 22);
            this.SettingsMenuItem.Text = "Settings";
            // 
            // ShowDebugLogMenuItem
            // 
            this.ShowDebugLogMenuItem.Name = "ShowDebugLogMenuItem";
            this.ShowDebugLogMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ShowDebugLogMenuItem.Text = "Show Debug Log";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(171, 22);
            this.AboutMenuItem.Text = "About";
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ExitMenuItem.Text = "Exit";
            // 
            // FavoritesMenuContextMenu
            // 
            this.FavoritesMenuContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowFavoritesManagerMenuItem});
            this.FavoritesMenuContextMenu.Name = "FavoritesMenuContextMenu";
            this.FavoritesMenuContextMenu.Size = new System.Drawing.Size(204, 26);
            // 
            // ShowFavoritesManagerMenuItem
            // 
            this.ShowFavoritesManagerMenuItem.Name = "ShowFavoritesManagerMenuItem";
            this.ShowFavoritesManagerMenuItem.Size = new System.Drawing.Size(203, 22);
            this.ShowFavoritesManagerMenuItem.Text = "Show Favorites Manager";
            // 
            // FavoritesFolderContextMenu
            // 
            this.FavoritesFolderContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveFavoriteFolderContextMenuItem});
            this.FavoritesFolderContextMenu.Name = "FavoritesFolderContextMenu";
            this.FavoritesFolderContextMenu.Size = new System.Drawing.Size(199, 26);
            // 
            // RemoveFavoriteFolderContextMenuItem
            // 
            this.RemoveFavoriteFolderContextMenuItem.Name = "RemoveFavoriteFolderContextMenuItem";
            this.RemoveFavoriteFolderContextMenuItem.Size = new System.Drawing.Size(198, 22);
            this.RemoveFavoriteFolderContextMenuItem.Text = "Remove Favorite Folder";
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubmodulesToolStripDropDown,
            this.ToolStripSpacer,
            this.BackgroundFasterFetch,
            this.BackgroundFasterFetchProgress});
            this.StatusStrip.Location = new System.Drawing.Point(0, 464);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(644, 22);
            this.StatusStrip.TabIndex = 6;
            // 
            // SubmodulesToolStripDropDown
            // 
            this.SubmodulesToolStripDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SubmodulesToolStripDropDown.Enabled = false;
            this.SubmodulesToolStripDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SubmodulesToolStripDropDown.Name = "SubmodulesToolStripDropDown";
            this.SubmodulesToolStripDropDown.Size = new System.Drawing.Size(86, 20);
            this.SubmodulesToolStripDropDown.Text = "Submodules";
            // 
            // ToolStripSpacer
            // 
            this.ToolStripSpacer.Name = "ToolStripSpacer";
            this.ToolStripSpacer.Size = new System.Drawing.Size(418, 17);
            this.ToolStripSpacer.Spring = true;
            // 
            // BackgroundFasterFetch
            // 
            this.BackgroundFasterFetch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BackgroundFasterFetch.Enabled = false;
            this.BackgroundFasterFetch.Image = ((System.Drawing.Image)(resources.GetObject("BackgroundFasterFetch.Image")));
            this.BackgroundFasterFetch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BackgroundFasterFetch.Name = "BackgroundFasterFetch";
            this.BackgroundFasterFetch.Size = new System.Drawing.Size(23, 20);
            this.BackgroundFasterFetch.Text = "Background Faster Fetch";
            // 
            // BackgroundFasterFetchProgress
            // 
            this.BackgroundFasterFetchProgress.Enabled = false;
            this.BackgroundFasterFetchProgress.Name = "BackgroundFasterFetchProgress";
            this.BackgroundFasterFetchProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // LogTabs
            // 
            this.LogTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTabs.Location = new System.Drawing.Point(0, 24);
            this.LogTabs.Name = "LogTabs";
            this.LogTabs.NewTabContextMenu = this.NewTabContextMenu;
            this.LogTabs.OptionsMenu = this.OptionsContextMenu;
            this.LogTabs.Size = new System.Drawing.Size(644, 440);
            this.LogTabs.TabContextMenu = this.TabContextMenu;
            this.LogTabs.TabIndex = 3;
            // 
            // EditFavoriteContextMenuItem
            // 
            this.EditFavoriteContextMenuItem.Name = "EditFavoriteContextMenuItem";
            this.EditFavoriteContextMenuItem.Size = new System.Drawing.Size(189, 22);
            this.EditFavoriteContextMenuItem.Text = "Edit Favorite";
            // 
            // TabbedTortoiseGitForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 486);
            this.Controls.Add(this.LogTabs);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.FavoritesMenuStrip);
            this.MainMenuStrip = this.FavoritesMenuStrip;
            this.MinimumSize = new System.Drawing.Size(660, 525);
            this.Name = "TabbedTortoiseGitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tabbed TortoiseGit";
            this.TabContextMenu.ResumeLayout(false);
            this.FavoriteRepoContextMenu.ResumeLayout(false);
            this.OptionsContextMenu.ResumeLayout(false);
            this.FavoritesMenuContextMenu.ResumeLayout(false);
            this.FavoritesFolderContextMenu.ResumeLayout(false);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip FavoritesMenuStrip;
        private System.Windows.Forms.ContextMenuStrip NewTabContextMenu;
        private System.Windows.Forms.ContextMenuStrip TabContextMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenRepoLocationTabMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddToFavoritesRepoTabMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseRepoTabMenuItem;
        private Tabs.TabControl LogTabs;
        private System.Windows.Forms.ContextMenuStrip FavoriteRepoContextMenu;
        private System.Windows.Forms.ToolStripMenuItem RemoveFavoriteContextMenuItem;
        private System.Windows.Forms.ContextMenuStrip OptionsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenRepoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RecentReposMenu;
        private System.Windows.Forms.ToolStripSeparator OptionsMenuSeparator;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ContextMenuStrip FavoritesMenuContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ShowFavoritesManagerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FavoritesManagerMenuItem;
        private System.Windows.Forms.ContextMenuStrip FavoritesFolderContextMenu;
        private System.Windows.Forms.ToolStripMenuItem RemoveFavoriteFolderContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFavoriteRepoLocationContextMenuItem;
        private System.ComponentModel.BackgroundWorker ModifiedRepoCheckBackgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem ShowDebugLogMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DuplicateRepoTabMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenWithReferencesRepoTabMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFavoriteWithReferencesContextMenuItem;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripDropDownButton SubmodulesToolStripDropDown;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripSpacer;
        private System.Windows.Forms.ToolStripButton BackgroundFasterFetch;
        private System.Windows.Forms.ToolStripProgressBar BackgroundFasterFetchProgress;
        private System.Windows.Forms.ToolStripMenuItem EditFavoriteContextMenuItem;
    }
}

