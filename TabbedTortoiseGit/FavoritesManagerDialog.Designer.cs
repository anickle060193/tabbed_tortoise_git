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
            this.FavoritesTree = new System.Windows.Forms.TreeView();
            this.FavoritesTreeImageList = new System.Windows.Forms.ImageList(this.components);
            this.FavoritesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CreateFavoritesFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FavoritesContextMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddFavoriteFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFavoriteFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FavoritesContextMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.EditFavoriteItemMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FavoritesContextMenuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.RemoveFavoriteItemMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cancel = new System.Windows.Forms.Button();
            this.Ok = new System.Windows.Forms.Button();
            this.FindFavoriteFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.FavoritesContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // FavoritesTree
            // 
            this.FavoritesTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FavoritesTree.HideSelection = false;
            this.FavoritesTree.ImageIndex = 0;
            this.FavoritesTree.ImageList = this.FavoritesTreeImageList;
            this.FavoritesTree.Location = new System.Drawing.Point(12, 12);
            this.FavoritesTree.Name = "FavoritesTree";
            this.FavoritesTree.SelectedImageIndex = 0;
            this.FavoritesTree.ShowPlusMinus = false;
            this.FavoritesTree.ShowRootLines = false;
            this.FavoritesTree.Size = new System.Drawing.Size(260, 308);
            this.FavoritesTree.TabIndex = 0;
            // 
            // FavoritesTreeImageList
            // 
            this.FavoritesTreeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.FavoritesTreeImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.FavoritesTreeImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FavoritesContextMenu
            // 
            this.FavoritesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateFavoritesFolderMenuItem,
            this.FavoritesContextMenuSeparator1,
            this.AddFavoriteFileMenuItem,
            this.AddFavoriteFolderMenuItem,
            this.FavoritesContextMenuSeparator2,
            this.EditFavoriteItemMenuItem,
            this.FavoritesContextMenuSeparator3,
            this.RemoveFavoriteItemMenuItem});
            this.FavoritesContextMenu.Name = "FavoritesTreeViewContextMenu";
            this.FavoritesContextMenu.Size = new System.Drawing.Size(178, 132);
            // 
            // CreateFavoritesFolderMenuItem
            // 
            this.CreateFavoritesFolderMenuItem.Name = "CreateFavoritesFolderMenuItem";
            this.CreateFavoritesFolderMenuItem.Size = new System.Drawing.Size(177, 22);
            this.CreateFavoritesFolderMenuItem.Text = "Create Folder";
            // 
            // FavoritesContextMenuSeparator1
            // 
            this.FavoritesContextMenuSeparator1.Name = "FavoritesContextMenuSeparator1";
            this.FavoritesContextMenuSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // AddFavoriteFileMenuItem
            // 
            this.AddFavoriteFileMenuItem.Name = "AddFavoriteFileMenuItem";
            this.AddFavoriteFileMenuItem.Size = new System.Drawing.Size(177, 22);
            this.AddFavoriteFileMenuItem.Text = "Add Favorite File";
            // 
            // AddFavoriteFolderMenuItem
            // 
            this.AddFavoriteFolderMenuItem.Name = "AddFavoriteFolderMenuItem";
            this.AddFavoriteFolderMenuItem.Size = new System.Drawing.Size(177, 22);
            this.AddFavoriteFolderMenuItem.Text = "Add Favorite Folder";
            // 
            // FavoritesContextMenuSeparator2
            // 
            this.FavoritesContextMenuSeparator2.Name = "FavoritesContextMenuSeparator2";
            this.FavoritesContextMenuSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // EditFavoriteItemMenuItem
            // 
            this.EditFavoriteItemMenuItem.Name = "EditFavoriteItemMenuItem";
            this.EditFavoriteItemMenuItem.Size = new System.Drawing.Size(177, 22);
            this.EditFavoriteItemMenuItem.Text = "Edit";
            // 
            // FavoritesContextMenuSeparator3
            // 
            this.FavoritesContextMenuSeparator3.Name = "FavoritesContextMenuSeparator3";
            this.FavoritesContextMenuSeparator3.Size = new System.Drawing.Size(174, 6);
            // 
            // RemoveFavoriteItemMenuItem
            // 
            this.RemoveFavoriteItemMenuItem.Name = "RemoveFavoriteItemMenuItem";
            this.RemoveFavoriteItemMenuItem.Size = new System.Drawing.Size(177, 22);
            this.RemoveFavoriteItemMenuItem.Text = "Remove";
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(197, 326);
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
            this.Ok.Location = new System.Drawing.Point(116, 326);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 2;
            this.Ok.Text = "OK";
            this.Ok.UseVisualStyleBackColor = true;
            // 
            // FindFavoriteFileDialog
            // 
            this.FindFavoriteFileDialog.AddExtension = false;
            this.FindFavoriteFileDialog.Title = "Select Favorite File:";
            // 
            // FavoritesManagerDialog
            // 
            this.AcceptButton = this.Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.FavoritesTree);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Cancel);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FavoritesManagerDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Favorites Manager";
            this.FavoritesContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView FavoritesTree;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.ContextMenuStrip FavoritesContextMenu;
        private System.Windows.Forms.ToolStripMenuItem CreateFavoritesFolderMenuItem;
        private System.Windows.Forms.ImageList FavoritesTreeImageList;
        private System.Windows.Forms.ToolStripMenuItem AddFavoriteFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveFavoriteItemMenuItem;
        private System.Windows.Forms.OpenFileDialog FindFavoriteFileDialog;
        private System.Windows.Forms.ToolStripMenuItem AddFavoriteFolderMenuItem;
        private System.Windows.Forms.ToolStripSeparator FavoritesContextMenuSeparator1;
        private System.Windows.Forms.ToolStripSeparator FavoritesContextMenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem EditFavoriteItemMenuItem;
        private System.Windows.Forms.ToolStripSeparator FavoritesContextMenuSeparator3;
    }
}