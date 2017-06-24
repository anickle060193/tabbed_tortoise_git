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
            this.FavoritesTree = new System.Windows.Forms.TreeView();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.FavoritesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CreateFavoritesFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveFavoritesFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFavoriteFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveFavoriteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cancel = new System.Windows.Forms.Button();
            this.Ok = new System.Windows.Forms.Button();
            this.FavoritesList = new System.Windows.Forms.ListView();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.FindFavoriteFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.AddFavoriteFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FavoritesContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // FavoritesTree
            // 
            this.FavoritesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FavoritesTree.HideSelection = false;
            this.FavoritesTree.ImageIndex = 0;
            this.FavoritesTree.ImageList = this.ImageList;
            this.FavoritesTree.Location = new System.Drawing.Point(0, 0);
            this.FavoritesTree.Name = "FavoritesTree";
            this.FavoritesTree.SelectedImageIndex = 0;
            this.FavoritesTree.ShowPlusMinus = false;
            this.FavoritesTree.ShowRootLines = false;
            this.FavoritesTree.Size = new System.Drawing.Size(203, 328);
            this.FavoritesTree.TabIndex = 0;
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "File");
            this.ImageList.Images.SetKeyName(1, "Folder");
            this.ImageList.Images.SetKeyName(2, "FolderFolder");
            // 
            // FavoritesContextMenu
            // 
            this.FavoritesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateFavoritesFolderMenuItem,
            this.RemoveFavoritesFolderMenuItem,
            this.AddFavoriteFileMenuItem,
            this.AddFavoriteFolderMenuItem,
            this.RemoveFavoriteMenuItem});
            this.FavoritesContextMenu.Name = "FavoritesTreeViewContextMenu";
            this.FavoritesContextMenu.Size = new System.Drawing.Size(178, 136);
            // 
            // CreateFavoritesFolderMenuItem
            // 
            this.CreateFavoritesFolderMenuItem.Name = "CreateFavoritesFolderMenuItem";
            this.CreateFavoritesFolderMenuItem.Size = new System.Drawing.Size(177, 22);
            this.CreateFavoritesFolderMenuItem.Text = "Create Folder";
            // 
            // RemoveFavoritesFolderMenuItem
            // 
            this.RemoveFavoritesFolderMenuItem.Name = "RemoveFavoritesFolderMenuItem";
            this.RemoveFavoritesFolderMenuItem.Size = new System.Drawing.Size(177, 22);
            this.RemoveFavoritesFolderMenuItem.Text = "Remove Folder";
            // 
            // AddFavoriteFileMenuItem
            // 
            this.AddFavoriteFileMenuItem.Name = "AddFavoriteFileMenuItem";
            this.AddFavoriteFileMenuItem.Size = new System.Drawing.Size(177, 22);
            this.AddFavoriteFileMenuItem.Text = "Add Favorite File";
            // 
            // RemoveFavoriteMenuItem
            // 
            this.RemoveFavoriteMenuItem.Name = "RemoveFavoriteMenuItem";
            this.RemoveFavoriteMenuItem.Size = new System.Drawing.Size(177, 22);
            this.RemoveFavoriteMenuItem.Text = "Remove Favorite";
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
            this.Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            this.SplitContainer.Panel1.Controls.Add(this.FavoritesTree);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.FavoritesList);
            this.SplitContainer.Size = new System.Drawing.Size(530, 328);
            this.SplitContainer.SplitterDistance = 203;
            this.SplitContainer.TabIndex = 4;
            // 
            // FindFavoriteFileDialog
            // 
            this.FindFavoriteFileDialog.AddExtension = false;
            this.FindFavoriteFileDialog.Title = "Select Favorite File:";
            // 
            // AddFavoriteFolderMenuItem
            // 
            this.AddFavoriteFolderMenuItem.Name = "AddFavoriteFolderMenuItem";
            this.AddFavoriteFolderMenuItem.Size = new System.Drawing.Size(177, 22);
            this.AddFavoriteFolderMenuItem.Text = "Add Favorite Folder";
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
            this.FavoritesContextMenu.ResumeLayout(false);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView FavoritesTree;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.ListView FavoritesList;
        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.ContextMenuStrip FavoritesContextMenu;
        private System.Windows.Forms.ToolStripMenuItem CreateFavoritesFolderMenuItem;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.ToolStripMenuItem RemoveFavoritesFolderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddFavoriteFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveFavoriteMenuItem;
        private System.Windows.Forms.OpenFileDialog FindFavoriteFileDialog;
        private System.Windows.Forms.ToolStripMenuItem AddFavoriteFolderMenuItem;
    }
}