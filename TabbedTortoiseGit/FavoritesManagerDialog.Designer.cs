namespace TabbedTortoiseGit
{
    partial class FavoritesManagerDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavoritesManagerDialog));
            this.FavoritesTreeView = new System.Windows.Forms.TreeView();
            this.FavoritesTreeViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cancel = new System.Windows.Forms.Button();
            this.Ok = new System.Windows.Forms.Button();
            this.FavoritesList = new System.Windows.Forms.ListView();
            this.FavoritesListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddFavoriteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.FavoritesTreeViewItemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RemoveFavoritesTreeViewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FavoritesListItemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RemoveFavoritesListItemMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FavoritesTreeViewContextMenu.SuspendLayout();
            this.FavoritesListContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.FavoritesTreeViewItemContextMenu.SuspendLayout();
            this.FavoritesListItemContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // FavoritesTreeView
            // 
            this.FavoritesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FavoritesTreeView.ImageIndex = 0;
            this.FavoritesTreeView.ImageList = this.ImageList;
            this.FavoritesTreeView.Location = new System.Drawing.Point(0, 0);
            this.FavoritesTreeView.Name = "FavoritesTreeView";
            this.FavoritesTreeView.SelectedImageIndex = 0;
            this.FavoritesTreeView.Size = new System.Drawing.Size(203, 328);
            this.FavoritesTreeView.TabIndex = 0;
            // 
            // FavoritesTreeViewContextMenu
            // 
            this.FavoritesTreeViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFolderMenuItem});
            this.FavoritesTreeViewContextMenu.Name = "FavoritesTreeViewContextMenu";
            this.FavoritesTreeViewContextMenu.Size = new System.Drawing.Size(133, 26);
            // 
            // AddFolderMenuItem
            // 
            this.AddFolderMenuItem.Name = "AddFolderMenuItem";
            this.AddFolderMenuItem.Size = new System.Drawing.Size(132, 22);
            this.AddFolderMenuItem.Text = "Add Folder";
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(467, 346);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Ok
            // 
            this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok.Location = new System.Drawing.Point(386, 346);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 2;
            this.Ok.Text = "OK";
            this.Ok.UseVisualStyleBackColor = true;
            // 
            // FavoritesList
            // 
            this.FavoritesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FavoritesList.LabelWrap = false;
            this.FavoritesList.Location = new System.Drawing.Point(0, 0);
            this.FavoritesList.MultiSelect = false;
            this.FavoritesList.Name = "FavoritesList";
            this.FavoritesList.ShowGroups = false;
            this.FavoritesList.Size = new System.Drawing.Size(323, 328);
            this.FavoritesList.SmallImageList = this.ImageList;
            this.FavoritesList.TabIndex = 3;
            this.FavoritesList.UseCompatibleStateImageBehavior = false;
            this.FavoritesList.View = System.Windows.Forms.View.List;
            // 
            // FavoritesListContextMenu
            // 
            this.FavoritesListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFavoriteMenuItem});
            this.FavoritesListContextMenu.Name = "FavoritesListContextMenu";
            this.FavoritesListContextMenu.Size = new System.Drawing.Size(142, 26);
            // 
            // AddFavoriteMenuItem
            // 
            this.AddFavoriteMenuItem.Name = "AddFavoriteMenuItem";
            this.AddFavoriteMenuItem.Size = new System.Drawing.Size(141, 22);
            this.AddFavoriteMenuItem.Text = "Add Favorite";
            // 
            // SplitContainer
            // 
            this.SplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer.Location = new System.Drawing.Point(12, 12);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.FavoritesTreeView);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.FavoritesList);
            this.SplitContainer.Size = new System.Drawing.Size(530, 328);
            this.SplitContainer.SplitterDistance = 203;
            this.SplitContainer.TabIndex = 4;
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "File");
            this.ImageList.Images.SetKeyName(1, "Folder");
            this.ImageList.Images.SetKeyName(2, "FolderFolder");
            // 
            // FavoritesTreeViewItemContextMenu
            // 
            this.FavoritesTreeViewItemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveFavoritesTreeViewItem});
            this.FavoritesTreeViewItemContextMenu.Name = "FavoritesTreeViewItemContextMenu";
            this.FavoritesTreeViewItemContextMenu.Size = new System.Drawing.Size(118, 26);
            // 
            // RemoveFavoritesTreeViewItem
            // 
            this.RemoveFavoritesTreeViewItem.Name = "RemoveFavoritesTreeViewItem";
            this.RemoveFavoritesTreeViewItem.Size = new System.Drawing.Size(117, 22);
            this.RemoveFavoritesTreeViewItem.Text = "Remove";
            // 
            // FavoritesListItemContextMenu
            // 
            this.FavoritesListItemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveFavoritesListItemMenuItem});
            this.FavoritesListItemContextMenu.Name = "FavoritesListItemContextMenu";
            this.FavoritesListItemContextMenu.Size = new System.Drawing.Size(163, 26);
            // 
            // RemoveFavoritesListItemMenuItem
            // 
            this.RemoveFavoritesListItemMenuItem.Name = "RemoveFavoritesListItemMenuItem";
            this.RemoveFavoritesListItemMenuItem.Size = new System.Drawing.Size(162, 22);
            this.RemoveFavoritesListItemMenuItem.Text = "Remove Favorite";
            // 
            // FavoritesManagerDialog
            // 
            this.AcceptButton = this.Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(554, 381);
            this.Controls.Add(this.SplitContainer);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Cancel);
            this.Name = "FavoritesManagerDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Favorites Manager";
            this.FavoritesTreeViewContextMenu.ResumeLayout(false);
            this.FavoritesListContextMenu.ResumeLayout(false);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.FavoritesTreeViewItemContextMenu.ResumeLayout(false);
            this.FavoritesListItemContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView FavoritesTreeView;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.ListView FavoritesList;
        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.ContextMenuStrip FavoritesTreeViewContextMenu;
        private System.Windows.Forms.ContextMenuStrip FavoritesListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem AddFolderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddFavoriteMenuItem;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.ContextMenuStrip FavoritesTreeViewItemContextMenu;
        private System.Windows.Forms.ToolStripMenuItem RemoveFavoritesTreeViewItem;
        private System.Windows.Forms.ContextMenuStrip FavoritesListItemContextMenu;
        private System.Windows.Forms.ToolStripMenuItem RemoveFavoritesListItemMenuItem;
    }
}