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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( TabbedTortoiseGitForm ) );
            FavoritesMenuStrip = new System.Windows.Forms.MenuStrip();
            NewTabContextMenu = new System.Windows.Forms.ContextMenuStrip( components );
            TabContextMenu = new System.Windows.Forms.ContextMenuStrip( components );
            OpenRepoLocationTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            AddToFavoritesRepoTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            OpenWithReferencesRepoTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            DuplicateRepoTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            CloseRepoTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            FavoriteRepoContextMenu = new System.Windows.Forms.ContextMenuStrip( components );
            OpenFavoriteRepoLocationContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            OpenFavoriteWithReferencesContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            EditFavoriteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            RemoveFavoriteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            OptionsContextMenu = new System.Windows.Forms.ContextMenuStrip( components );
            OpenRepoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            RecentReposMenu = new System.Windows.Forms.ToolStripMenuItem();
            OptionsMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            FavoritesManagerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ShowDebugLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            FavoritesMenuContextMenu = new System.Windows.Forms.ContextMenuStrip( components );
            ShowFavoritesManagerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            FavoritesFolderContextMenu = new System.Windows.Forms.ContextMenuStrip( components );
            EditFavoriteFolderContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            RemoveFavoriteFolderContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ModifiedRepoCheckBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            StatusStrip = new System.Windows.Forms.StatusStrip();
            SubmodulesToolStripDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            ToolStripSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            BackgroundFasterFetch = new System.Windows.Forms.ToolStripButton();
            BackgroundFasterFetchProgress = new System.Windows.Forms.ToolStripProgressBar();
            FavoriteReposDirectoryContextMenu = new System.Windows.Forms.ContextMenuStrip( components );
            OpenFavoriteReposDirectoryLocationContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            FavoriteReposDirectoryContextMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            EditFavoriteReposDirectoryContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            RemoveFavoriteReposDirectoryContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ReferencesListBoxReferenceContextMenu = new System.Windows.Forms.ContextMenuStrip( components );
            ReferenceContextMenuOpenLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            SplitLayout = new System.Windows.Forms.SplitContainer();
            ReferencesSplitLayout = new System.Windows.Forms.SplitContainer();
            ReferencesTreeView = new System.Windows.Forms.TreeView();
            ReferencesListBox = new System.Windows.Forms.ListBox();
            ReferencesFilter = new System.Windows.Forms.TextBox();
            LogTabs = new Tabs.TabControl();
            folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            TabContextMenu.SuspendLayout();
            FavoriteRepoContextMenu.SuspendLayout();
            OptionsContextMenu.SuspendLayout();
            FavoritesMenuContextMenu.SuspendLayout();
            FavoritesFolderContextMenu.SuspendLayout();
            StatusStrip.SuspendLayout();
            FavoriteReposDirectoryContextMenu.SuspendLayout();
            ReferencesListBoxReferenceContextMenu.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)SplitLayout ).BeginInit();
            SplitLayout.Panel1.SuspendLayout();
            SplitLayout.Panel2.SuspendLayout();
            SplitLayout.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)ReferencesSplitLayout ).BeginInit();
            ReferencesSplitLayout.Panel1.SuspendLayout();
            ReferencesSplitLayout.Panel2.SuspendLayout();
            ReferencesSplitLayout.SuspendLayout();
            SuspendLayout();
            // 
            // FavoritesMenuStrip
            // 
            FavoritesMenuStrip.BackColor = System.Drawing.Color.White;
            FavoritesMenuStrip.Location = new System.Drawing.Point( 0, 0 );
            FavoritesMenuStrip.Name = "FavoritesMenuStrip";
            FavoritesMenuStrip.Padding = new System.Windows.Forms.Padding( 7, 2, 0, 2 );
            FavoritesMenuStrip.ShowItemToolTips = true;
            FavoritesMenuStrip.Size = new System.Drawing.Size( 751, 24 );
            FavoritesMenuStrip.TabIndex = 1;
            // 
            // NewTabContextMenu
            // 
            NewTabContextMenu.Name = "NewTabContextMenu";
            NewTabContextMenu.Size = new System.Drawing.Size( 61, 4 );
            // 
            // TabContextMenu
            // 
            TabContextMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] { OpenRepoLocationTabMenuItem, AddToFavoritesRepoTabMenuItem, OpenWithReferencesRepoTabMenuItem, DuplicateRepoTabMenuItem, CloseRepoTabMenuItem } );
            TabContextMenu.Name = "TabContextMenu";
            TabContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            TabContextMenu.Size = new System.Drawing.Size( 190, 114 );
            // 
            // OpenRepoLocationTabMenuItem
            // 
            OpenRepoLocationTabMenuItem.Name = "OpenRepoLocationTabMenuItem";
            OpenRepoLocationTabMenuItem.Size = new System.Drawing.Size( 189, 22 );
            OpenRepoLocationTabMenuItem.Text = "Open Repo Location";
            // 
            // AddToFavoritesRepoTabMenuItem
            // 
            AddToFavoritesRepoTabMenuItem.Name = "AddToFavoritesRepoTabMenuItem";
            AddToFavoritesRepoTabMenuItem.Size = new System.Drawing.Size( 189, 22 );
            AddToFavoritesRepoTabMenuItem.Text = "Add to Favorites";
            // 
            // OpenWithReferencesRepoTabMenuItem
            // 
            OpenWithReferencesRepoTabMenuItem.Name = "OpenWithReferencesRepoTabMenuItem";
            OpenWithReferencesRepoTabMenuItem.Size = new System.Drawing.Size( 189, 22 );
            OpenWithReferencesRepoTabMenuItem.Text = "Open with References";
            // 
            // DuplicateRepoTabMenuItem
            // 
            DuplicateRepoTabMenuItem.Name = "DuplicateRepoTabMenuItem";
            DuplicateRepoTabMenuItem.Size = new System.Drawing.Size( 189, 22 );
            DuplicateRepoTabMenuItem.Text = "Duplicate";
            // 
            // CloseRepoTabMenuItem
            // 
            CloseRepoTabMenuItem.Name = "CloseRepoTabMenuItem";
            CloseRepoTabMenuItem.Size = new System.Drawing.Size( 189, 22 );
            CloseRepoTabMenuItem.Text = "Close";
            // 
            // FavoriteRepoContextMenu
            // 
            FavoriteRepoContextMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] { OpenFavoriteRepoLocationContextMenuItem, OpenFavoriteWithReferencesContextMenuItem, EditFavoriteContextMenuItem, RemoveFavoriteContextMenuItem } );
            FavoriteRepoContextMenu.Name = "FavoriteRepoContextMenu";
            FavoriteRepoContextMenu.Size = new System.Drawing.Size( 190, 92 );
            // 
            // OpenFavoriteRepoLocationContextMenuItem
            // 
            OpenFavoriteRepoLocationContextMenuItem.Name = "OpenFavoriteRepoLocationContextMenuItem";
            OpenFavoriteRepoLocationContextMenuItem.Size = new System.Drawing.Size( 189, 22 );
            OpenFavoriteRepoLocationContextMenuItem.Text = "Open Repo Location";
            // 
            // OpenFavoriteWithReferencesContextMenuItem
            // 
            OpenFavoriteWithReferencesContextMenuItem.Name = "OpenFavoriteWithReferencesContextMenuItem";
            OpenFavoriteWithReferencesContextMenuItem.Size = new System.Drawing.Size( 189, 22 );
            OpenFavoriteWithReferencesContextMenuItem.Text = "Open with References";
            // 
            // EditFavoriteContextMenuItem
            // 
            EditFavoriteContextMenuItem.Name = "EditFavoriteContextMenuItem";
            EditFavoriteContextMenuItem.Size = new System.Drawing.Size( 189, 22 );
            EditFavoriteContextMenuItem.Text = "Edit Favorite";
            // 
            // RemoveFavoriteContextMenuItem
            // 
            RemoveFavoriteContextMenuItem.Name = "RemoveFavoriteContextMenuItem";
            RemoveFavoriteContextMenuItem.Size = new System.Drawing.Size( 189, 22 );
            RemoveFavoriteContextMenuItem.Text = "Remove Favorite";
            // 
            // OptionsContextMenu
            // 
            OptionsContextMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] { OpenRepoMenuItem, RecentReposMenu, OptionsMenuSeparator, FavoritesManagerMenuItem, SettingsMenuItem, ShowDebugLogMenuItem, AboutMenuItem, ExitMenuItem } );
            OptionsContextMenu.Name = "OptionsContextMenu";
            OptionsContextMenu.Size = new System.Drawing.Size( 172, 164 );
            // 
            // OpenRepoMenuItem
            // 
            OpenRepoMenuItem.Name = "OpenRepoMenuItem";
            OpenRepoMenuItem.Size = new System.Drawing.Size( 171, 22 );
            OpenRepoMenuItem.Text = "Open Repo";
            // 
            // RecentReposMenu
            // 
            RecentReposMenu.Enabled = false;
            RecentReposMenu.Name = "RecentReposMenu";
            RecentReposMenu.Size = new System.Drawing.Size( 171, 22 );
            RecentReposMenu.Text = "Recent Repos";
            // 
            // OptionsMenuSeparator
            // 
            OptionsMenuSeparator.Name = "OptionsMenuSeparator";
            OptionsMenuSeparator.Size = new System.Drawing.Size( 168, 6 );
            // 
            // FavoritesManagerMenuItem
            // 
            FavoritesManagerMenuItem.Name = "FavoritesManagerMenuItem";
            FavoritesManagerMenuItem.Size = new System.Drawing.Size( 171, 22 );
            FavoritesManagerMenuItem.Text = "Favorites Manager";
            // 
            // SettingsMenuItem
            // 
            SettingsMenuItem.Name = "SettingsMenuItem";
            SettingsMenuItem.Size = new System.Drawing.Size( 171, 22 );
            SettingsMenuItem.Text = "Settings";
            // 
            // ShowDebugLogMenuItem
            // 
            ShowDebugLogMenuItem.Name = "ShowDebugLogMenuItem";
            ShowDebugLogMenuItem.Size = new System.Drawing.Size( 171, 22 );
            ShowDebugLogMenuItem.Text = "Show Debug Log";
            // 
            // AboutMenuItem
            // 
            AboutMenuItem.Name = "AboutMenuItem";
            AboutMenuItem.Size = new System.Drawing.Size( 171, 22 );
            AboutMenuItem.Text = "About";
            // 
            // ExitMenuItem
            // 
            ExitMenuItem.Name = "ExitMenuItem";
            ExitMenuItem.Size = new System.Drawing.Size( 171, 22 );
            ExitMenuItem.Text = "Exit";
            // 
            // FavoritesMenuContextMenu
            // 
            FavoritesMenuContextMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] { ShowFavoritesManagerMenuItem } );
            FavoritesMenuContextMenu.Name = "FavoritesMenuContextMenu";
            FavoritesMenuContextMenu.Size = new System.Drawing.Size( 204, 26 );
            // 
            // ShowFavoritesManagerMenuItem
            // 
            ShowFavoritesManagerMenuItem.Name = "ShowFavoritesManagerMenuItem";
            ShowFavoritesManagerMenuItem.Size = new System.Drawing.Size( 203, 22 );
            ShowFavoritesManagerMenuItem.Text = "Show Favorites Manager";
            // 
            // FavoritesFolderContextMenu
            // 
            FavoritesFolderContextMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] { EditFavoriteFolderContextMenuItem, RemoveFavoriteFolderContextMenuItem } );
            FavoritesFolderContextMenu.Name = "FavoritesFolderContextMenu";
            FavoritesFolderContextMenu.Size = new System.Drawing.Size( 199, 48 );
            // 
            // EditFavoriteFolderContextMenuItem
            // 
            EditFavoriteFolderContextMenuItem.Name = "EditFavoriteFolderContextMenuItem";
            EditFavoriteFolderContextMenuItem.Size = new System.Drawing.Size( 198, 22 );
            EditFavoriteFolderContextMenuItem.Text = "Edit Favorite Folder";
            // 
            // RemoveFavoriteFolderContextMenuItem
            // 
            RemoveFavoriteFolderContextMenuItem.Name = "RemoveFavoriteFolderContextMenuItem";
            RemoveFavoriteFolderContextMenuItem.Size = new System.Drawing.Size( 198, 22 );
            RemoveFavoriteFolderContextMenuItem.Text = "Remove Favorite Folder";
            // 
            // StatusStrip
            // 
            StatusStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] { SubmodulesToolStripDropDown, ToolStripSpacer, BackgroundFasterFetch, BackgroundFasterFetchProgress } );
            StatusStrip.Location = new System.Drawing.Point( 0, 513 );
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Padding = new System.Windows.Forms.Padding( 1, 0, 16, 0 );
            StatusStrip.Size = new System.Drawing.Size( 546, 24 );
            StatusStrip.TabIndex = 6;
            // 
            // SubmodulesToolStripDropDown
            // 
            SubmodulesToolStripDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            SubmodulesToolStripDropDown.Enabled = false;
            SubmodulesToolStripDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            SubmodulesToolStripDropDown.Name = "SubmodulesToolStripDropDown";
            SubmodulesToolStripDropDown.Size = new System.Drawing.Size( 86, 22 );
            SubmodulesToolStripDropDown.Text = "Submodules";
            // 
            // ToolStripSpacer
            // 
            ToolStripSpacer.Name = "ToolStripSpacer";
            ToolStripSpacer.Size = new System.Drawing.Size( 301, 19 );
            ToolStripSpacer.Spring = true;
            // 
            // BackgroundFasterFetch
            // 
            BackgroundFasterFetch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            BackgroundFasterFetch.Enabled = false;
            BackgroundFasterFetch.Image = (System.Drawing.Image)resources.GetObject( "BackgroundFasterFetch.Image" );
            BackgroundFasterFetch.ImageTransparentColor = System.Drawing.Color.Magenta;
            BackgroundFasterFetch.Name = "BackgroundFasterFetch";
            BackgroundFasterFetch.Size = new System.Drawing.Size( 23, 22 );
            BackgroundFasterFetch.Text = "Background Faster Fetch";
            // 
            // BackgroundFasterFetchProgress
            // 
            BackgroundFasterFetchProgress.Enabled = false;
            BackgroundFasterFetchProgress.Name = "BackgroundFasterFetchProgress";
            BackgroundFasterFetchProgress.Size = new System.Drawing.Size( 117, 18 );
            // 
            // FavoriteReposDirectoryContextMenu
            // 
            FavoriteReposDirectoryContextMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] { OpenFavoriteReposDirectoryLocationContextMenuItem, FavoriteReposDirectoryContextMenuSeparator, EditFavoriteReposDirectoryContextMenuItem, RemoveFavoriteReposDirectoryContextMenuItem } );
            FavoriteReposDirectoryContextMenu.Name = "FavoriteReposDirectoryContextMenu";
            FavoriteReposDirectoryContextMenu.Size = new System.Drawing.Size( 163, 76 );
            // 
            // OpenFavoriteReposDirectoryLocationContextMenuItem
            // 
            OpenFavoriteReposDirectoryLocationContextMenuItem.Name = "OpenFavoriteReposDirectoryLocationContextMenuItem";
            OpenFavoriteReposDirectoryLocationContextMenuItem.Size = new System.Drawing.Size( 162, 22 );
            OpenFavoriteReposDirectoryLocationContextMenuItem.Text = "Open Directory";
            // 
            // FavoriteReposDirectoryContextMenuSeparator
            // 
            FavoriteReposDirectoryContextMenuSeparator.Name = "FavoriteReposDirectoryContextMenuSeparator";
            FavoriteReposDirectoryContextMenuSeparator.Size = new System.Drawing.Size( 159, 6 );
            // 
            // EditFavoriteReposDirectoryContextMenuItem
            // 
            EditFavoriteReposDirectoryContextMenuItem.Name = "EditFavoriteReposDirectoryContextMenuItem";
            EditFavoriteReposDirectoryContextMenuItem.Size = new System.Drawing.Size( 162, 22 );
            EditFavoriteReposDirectoryContextMenuItem.Text = "Edit Favorite";
            // 
            // RemoveFavoriteReposDirectoryContextMenuItem
            // 
            RemoveFavoriteReposDirectoryContextMenuItem.Name = "RemoveFavoriteReposDirectoryContextMenuItem";
            RemoveFavoriteReposDirectoryContextMenuItem.Size = new System.Drawing.Size( 162, 22 );
            RemoveFavoriteReposDirectoryContextMenuItem.Text = "Remove Favorite";
            // 
            // ReferencesListBoxReferenceContextMenu
            // 
            ReferencesListBoxReferenceContextMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] { ReferenceContextMenuOpenLogMenuItem } );
            ReferencesListBoxReferenceContextMenu.Name = "ReferencesTreeViewReferenceContextMenu";
            ReferencesListBoxReferenceContextMenu.Size = new System.Drawing.Size( 127, 26 );
            // 
            // ReferenceContextMenuOpenLogMenuItem
            // 
            ReferenceContextMenuOpenLogMenuItem.Name = "ReferenceContextMenuOpenLogMenuItem";
            ReferenceContextMenuOpenLogMenuItem.Size = new System.Drawing.Size( 126, 22 );
            ReferenceContextMenuOpenLogMenuItem.Text = "Open Log";
            // 
            // SplitLayout
            // 
            SplitLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            SplitLayout.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            SplitLayout.Location = new System.Drawing.Point( 0, 24 );
            SplitLayout.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            SplitLayout.Name = "SplitLayout";
            // 
            // SplitLayout.Panel1
            // 
            SplitLayout.Panel1.Controls.Add( ReferencesSplitLayout );
            // 
            // SplitLayout.Panel2
            // 
            SplitLayout.Panel2.Controls.Add( LogTabs );
            SplitLayout.Panel2.Controls.Add( StatusStrip );
            SplitLayout.Size = new System.Drawing.Size( 751, 537 );
            SplitLayout.SplitterDistance = 200;
            SplitLayout.SplitterWidth = 5;
            SplitLayout.TabIndex = 8;
            // 
            // ReferencesSplitLayout
            // 
            ReferencesSplitLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            ReferencesSplitLayout.Location = new System.Drawing.Point( 0, 0 );
            ReferencesSplitLayout.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ReferencesSplitLayout.Name = "ReferencesSplitLayout";
            ReferencesSplitLayout.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ReferencesSplitLayout.Panel1
            // 
            ReferencesSplitLayout.Panel1.Controls.Add( ReferencesTreeView );
            // 
            // ReferencesSplitLayout.Panel2
            // 
            ReferencesSplitLayout.Panel2.Controls.Add( ReferencesListBox );
            ReferencesSplitLayout.Panel2.Controls.Add( ReferencesFilter );
            ReferencesSplitLayout.Size = new System.Drawing.Size( 200, 537 );
            ReferencesSplitLayout.SplitterDistance = 241;
            ReferencesSplitLayout.SplitterWidth = 5;
            ReferencesSplitLayout.TabIndex = 9;
            // 
            // ReferencesTreeView
            // 
            ReferencesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            ReferencesTreeView.HideSelection = false;
            ReferencesTreeView.Location = new System.Drawing.Point( 0, 0 );
            ReferencesTreeView.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ReferencesTreeView.Name = "ReferencesTreeView";
            ReferencesTreeView.Size = new System.Drawing.Size( 200, 241 );
            ReferencesTreeView.TabIndex = 7;
            // 
            // ReferencesListBox
            // 
            ReferencesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            ReferencesListBox.FormatString = "long";
            ReferencesListBox.FormattingEnabled = true;
            ReferencesListBox.HorizontalScrollbar = true;
            ReferencesListBox.IntegralHeight = false;
            ReferencesListBox.Location = new System.Drawing.Point( 0, 23 );
            ReferencesListBox.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ReferencesListBox.Name = "ReferencesListBox";
            ReferencesListBox.Size = new System.Drawing.Size( 200, 268 );
            ReferencesListBox.TabIndex = 8;
            // 
            // ReferencesFilter
            // 
            ReferencesFilter.Dock = System.Windows.Forms.DockStyle.Top;
            ReferencesFilter.Location = new System.Drawing.Point( 0, 0 );
            ReferencesFilter.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ReferencesFilter.Name = "ReferencesFilter";
            ReferencesFilter.Size = new System.Drawing.Size( 200, 23 );
            ReferencesFilter.TabIndex = 9;
            // 
            // LogTabs
            // 
            LogTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            LogTabs.Location = new System.Drawing.Point( 0, 0 );
            LogTabs.Name = "LogTabs";
            LogTabs.NewTabContextMenu = NewTabContextMenu;
            LogTabs.OptionsMenu = OptionsContextMenu;
            LogTabs.Size = new System.Drawing.Size( 546, 513 );
            LogTabs.TabContextMenu = TabContextMenu;
            LogTabs.TabIndex = 3;
            // 
            // TabbedTortoiseGitForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF( 96F, 96F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size( 751, 561 );
            Controls.Add( SplitLayout );
            Controls.Add( FavoritesMenuStrip );
            MainMenuStrip = FavoritesMenuStrip;
            Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            MinimumSize = new System.Drawing.Size( 767, 600 );
            Name = "TabbedTortoiseGitForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Tabbed TortoiseGit";
            TabContextMenu.ResumeLayout( false );
            FavoriteRepoContextMenu.ResumeLayout( false );
            OptionsContextMenu.ResumeLayout( false );
            FavoritesMenuContextMenu.ResumeLayout( false );
            FavoritesFolderContextMenu.ResumeLayout( false );
            StatusStrip.ResumeLayout( false );
            StatusStrip.PerformLayout();
            FavoriteReposDirectoryContextMenu.ResumeLayout( false );
            ReferencesListBoxReferenceContextMenu.ResumeLayout( false );
            SplitLayout.Panel1.ResumeLayout( false );
            SplitLayout.Panel2.ResumeLayout( false );
            SplitLayout.Panel2.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)SplitLayout ).EndInit();
            SplitLayout.ResumeLayout( false );
            ReferencesSplitLayout.Panel1.ResumeLayout( false );
            ReferencesSplitLayout.Panel2.ResumeLayout( false );
            ReferencesSplitLayout.Panel2.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)ReferencesSplitLayout ).EndInit();
            ReferencesSplitLayout.ResumeLayout( false );
            ResumeLayout( false );
            PerformLayout();

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
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
    }
}

