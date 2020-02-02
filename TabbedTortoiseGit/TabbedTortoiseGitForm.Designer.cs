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
            this.EditFavoriteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.EditFavoriteFolderContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveFavoriteFolderContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifiedRepoCheckBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.SubmodulesToolStripDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.BackgroundFasterFetch = new System.Windows.Forms.ToolStripButton();
            this.BackgroundFasterFetchProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.FavoriteReposDirectoryContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenFavoriteReposDirectoryLocationContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FavoriteReposDirectoryContextMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.EditFavoriteReposDirectoryContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveFavoriteReposDirectoryContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReferencesListBoxReferenceContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ReferenceContextMenuOpenLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SplitLayout = new System.Windows.Forms.SplitContainer();
            this.ReferencesSplitLayout = new System.Windows.Forms.SplitContainer();
            this.ReferencesTreeView = new System.Windows.Forms.TreeView();
            this.ReferencesListBox = new System.Windows.Forms.ListBox();
            this.ReferencesFilter = new System.Windows.Forms.TextBox();
            this.LogTabs = new Tabs.TabControl();
            this.TabContextMenu.SuspendLayout();
            this.FavoriteRepoContextMenu.SuspendLayout();
            this.OptionsContextMenu.SuspendLayout();
            this.FavoritesMenuContextMenu.SuspendLayout();
            this.FavoritesFolderContextMenu.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.FavoriteReposDirectoryContextMenu.SuspendLayout();
            this.ReferencesListBoxReferenceContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitLayout)).BeginInit();
            this.SplitLayout.Panel1.SuspendLayout();
            this.SplitLayout.Panel2.SuspendLayout();
            this.SplitLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReferencesSplitLayout)).BeginInit();
            this.ReferencesSplitLayout.Panel1.SuspendLayout();
            this.ReferencesSplitLayout.Panel2.SuspendLayout();
            this.ReferencesSplitLayout.SuspendLayout();
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
            this.FavoriteRepoContextMenu.Size = new System.Drawing.Size(190, 92);
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
            // EditFavoriteContextMenuItem
            // 
            this.EditFavoriteContextMenuItem.Name = "EditFavoriteContextMenuItem";
            this.EditFavoriteContextMenuItem.Size = new System.Drawing.Size(189, 22);
            this.EditFavoriteContextMenuItem.Text = "Edit Favorite";
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
            this.EditFavoriteFolderContextMenuItem,
            this.RemoveFavoriteFolderContextMenuItem});
            this.FavoritesFolderContextMenu.Name = "FavoritesFolderContextMenu";
            this.FavoritesFolderContextMenu.Size = new System.Drawing.Size(199, 48);
            // 
            // EditFavoriteFolderContextMenuItem
            // 
            this.EditFavoriteFolderContextMenuItem.Name = "EditFavoriteFolderContextMenuItem";
            this.EditFavoriteFolderContextMenuItem.Size = new System.Drawing.Size(198, 22);
            this.EditFavoriteFolderContextMenuItem.Text = "Edit Favorite Folder";
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
            this.StatusStrip.Location = new System.Drawing.Point(0, 440);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(440, 22);
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
            this.ToolStripSpacer.Size = new System.Drawing.Size(214, 17);
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
            // FavoriteReposDirectoryContextMenu
            // 
            this.FavoriteReposDirectoryContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFavoriteReposDirectoryLocationContextMenuItem,
            this.FavoriteReposDirectoryContextMenuSeparator,
            this.EditFavoriteReposDirectoryContextMenuItem,
            this.RemoveFavoriteReposDirectoryContextMenuItem});
            this.FavoriteReposDirectoryContextMenu.Name = "FavoriteReposDirectoryContextMenu";
            this.FavoriteReposDirectoryContextMenu.Size = new System.Drawing.Size(163, 76);
            // 
            // OpenFavoriteReposDirectoryLocationContextMenuItem
            // 
            this.OpenFavoriteReposDirectoryLocationContextMenuItem.Name = "OpenFavoriteReposDirectoryLocationContextMenuItem";
            this.OpenFavoriteReposDirectoryLocationContextMenuItem.Size = new System.Drawing.Size(162, 22);
            this.OpenFavoriteReposDirectoryLocationContextMenuItem.Text = "Open Directory";
            // 
            // FavoriteReposDirectoryContextMenuSeparator
            // 
            this.FavoriteReposDirectoryContextMenuSeparator.Name = "FavoriteReposDirectoryContextMenuSeparator";
            this.FavoriteReposDirectoryContextMenuSeparator.Size = new System.Drawing.Size(159, 6);
            // 
            // EditFavoriteReposDirectoryContextMenuItem
            // 
            this.EditFavoriteReposDirectoryContextMenuItem.Name = "EditFavoriteReposDirectoryContextMenuItem";
            this.EditFavoriteReposDirectoryContextMenuItem.Size = new System.Drawing.Size(162, 22);
            this.EditFavoriteReposDirectoryContextMenuItem.Text = "Edit Favorite";
            // 
            // RemoveFavoriteReposDirectoryContextMenuItem
            // 
            this.RemoveFavoriteReposDirectoryContextMenuItem.Name = "RemoveFavoriteReposDirectoryContextMenuItem";
            this.RemoveFavoriteReposDirectoryContextMenuItem.Size = new System.Drawing.Size(162, 22);
            this.RemoveFavoriteReposDirectoryContextMenuItem.Text = "Remove Favorite";
            // 
            // ReferencesListBoxReferenceContextMenu
            // 
            this.ReferencesListBoxReferenceContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReferenceContextMenuOpenLogMenuItem});
            this.ReferencesListBoxReferenceContextMenu.Name = "ReferencesTreeViewReferenceContextMenu";
            this.ReferencesListBoxReferenceContextMenu.Size = new System.Drawing.Size(127, 26);
            // 
            // ReferenceContextMenuOpenLogMenuItem
            // 
            this.ReferenceContextMenuOpenLogMenuItem.Name = "ReferenceContextMenuOpenLogMenuItem";
            this.ReferenceContextMenuOpenLogMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ReferenceContextMenuOpenLogMenuItem.Text = "Open Log";
            // 
            // SplitLayout
            // 
            this.SplitLayout.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::TabbedTortoiseGit.Properties.Settings.Default, "SplitLayoutSplitterDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SplitLayout.DataBindings.Add(new System.Windows.Forms.Binding("Panel1Collapsed", global::TabbedTortoiseGit.Properties.Settings.Default, "HideReferencesDisplay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SplitLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitLayout.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitLayout.Location = new System.Drawing.Point(0, 24);
            this.SplitLayout.Name = "SplitLayout";
            // 
            // SplitLayout.Panel1
            // 
            this.SplitLayout.Panel1.Controls.Add(this.ReferencesSplitLayout);
            this.SplitLayout.Panel1Collapsed = global::TabbedTortoiseGit.Properties.Settings.Default.HideReferencesDisplay;
            // 
            // SplitLayout.Panel2
            // 
            this.SplitLayout.Panel2.Controls.Add(this.LogTabs);
            this.SplitLayout.Panel2.Controls.Add(this.StatusStrip);
            this.SplitLayout.Size = new System.Drawing.Size(644, 462);
            this.SplitLayout.SplitterDistance = global::TabbedTortoiseGit.Properties.Settings.Default.SplitLayoutSplitterDistance;
            this.SplitLayout.TabIndex = 8;
            // 
            // ReferencesSplitLayout
            // 
            this.ReferencesSplitLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferencesSplitLayout.Location = new System.Drawing.Point(0, 0);
            this.ReferencesSplitLayout.Name = "ReferencesSplitLayout";
            this.ReferencesSplitLayout.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ReferencesSplitLayout.Panel1
            // 
            this.ReferencesSplitLayout.Panel1.Controls.Add(this.ReferencesTreeView);
            // 
            // ReferencesSplitLayout.Panel2
            // 
            this.ReferencesSplitLayout.Panel2.Controls.Add(this.ReferencesListBox);
            this.ReferencesSplitLayout.Panel2.Controls.Add(this.ReferencesFilter);
            this.ReferencesSplitLayout.Size = new System.Drawing.Size(200, 462);
            this.ReferencesSplitLayout.SplitterDistance = 208;
            this.ReferencesSplitLayout.TabIndex = 9;
            // 
            // ReferencesTreeView
            // 
            this.ReferencesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferencesTreeView.HideSelection = false;
            this.ReferencesTreeView.Location = new System.Drawing.Point(0, 0);
            this.ReferencesTreeView.Name = "ReferencesTreeView";
            this.ReferencesTreeView.Size = new System.Drawing.Size(200, 208);
            this.ReferencesTreeView.TabIndex = 7;
            // 
            // ReferencesListBox
            // 
            this.ReferencesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferencesListBox.FormatString = "long";
            this.ReferencesListBox.FormattingEnabled = true;
            this.ReferencesListBox.IntegralHeight = false;
            this.ReferencesListBox.Location = new System.Drawing.Point(0, 20);
            this.ReferencesListBox.Name = "ReferencesListBox";
            this.ReferencesListBox.Size = new System.Drawing.Size(200, 230);
            this.ReferencesListBox.TabIndex = 8;
            // 
            // ReferencesFilter
            // 
            this.ReferencesFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.ReferencesFilter.Location = new System.Drawing.Point(0, 0);
            this.ReferencesFilter.Name = "ReferencesFilter";
            this.ReferencesFilter.Size = new System.Drawing.Size(200, 20);
            this.ReferencesFilter.TabIndex = 9;
            // 
            // LogTabs
            // 
            this.LogTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTabs.Location = new System.Drawing.Point(0, 0);
            this.LogTabs.Name = "LogTabs";
            this.LogTabs.NewTabContextMenu = this.NewTabContextMenu;
            this.LogTabs.OptionsMenu = this.OptionsContextMenu;
            this.LogTabs.Size = new System.Drawing.Size(440, 440);
            this.LogTabs.TabContextMenu = this.TabContextMenu;
            this.LogTabs.TabIndex = 3;
            // 
            // TabbedTortoiseGitForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 486);
            this.Controls.Add(this.SplitLayout);
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
            this.FavoriteReposDirectoryContextMenu.ResumeLayout(false);
            this.ReferencesListBoxReferenceContextMenu.ResumeLayout(false);
            this.SplitLayout.Panel1.ResumeLayout(false);
            this.SplitLayout.Panel2.ResumeLayout(false);
            this.SplitLayout.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitLayout)).EndInit();
            this.SplitLayout.ResumeLayout(false);
            this.ReferencesSplitLayout.Panel1.ResumeLayout(false);
            this.ReferencesSplitLayout.Panel2.ResumeLayout(false);
            this.ReferencesSplitLayout.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReferencesSplitLayout)).EndInit();
            this.ReferencesSplitLayout.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip FavoriteReposDirectoryContextMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenFavoriteReposDirectoryLocationContextMenuItem;
        private System.Windows.Forms.ToolStripSeparator FavoriteReposDirectoryContextMenuSeparator;
        private System.Windows.Forms.ToolStripMenuItem EditFavoriteReposDirectoryContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveFavoriteReposDirectoryContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditFavoriteFolderContextMenuItem;
        private System.Windows.Forms.TreeView ReferencesTreeView;
        private System.Windows.Forms.SplitContainer SplitLayout;
        private System.Windows.Forms.ContextMenuStrip ReferencesListBoxReferenceContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ReferenceContextMenuOpenLogMenuItem;
        private System.Windows.Forms.ListBox ReferencesListBox;
        private System.Windows.Forms.SplitContainer ReferencesSplitLayout;
        private System.Windows.Forms.TextBox ReferencesFilter;
    }
}

