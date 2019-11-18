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
            this.AddFavoritesFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FavoritesContextMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddRepoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddReposDirectoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FavoritesContextMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.EditFavoriteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FavoritesContextMenuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.RemoveFavoriteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cancel = new System.Windows.Forms.Button();
            this.Ok = new System.Windows.Forms.Button();
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
            this.AddFavoritesFolderMenuItem,
            this.FavoritesContextMenuSeparator1,
            this.AddRepoMenuItem,
            this.AddReposDirectoryMenuItem,
            this.FavoritesContextMenuSeparator2,
            this.EditFavoriteMenuItem,
            this.FavoritesContextMenuSeparator3,
            this.RemoveFavoriteMenuItem});
            this.FavoritesContextMenu.Name = "FavoritesTreeViewContextMenu";
            this.FavoritesContextMenu.Size = new System.Drawing.Size(183, 154);
            // 
            // AddFavoritesFolderMenuItem
            // 
            this.AddFavoritesFolderMenuItem.Name = "AddFavoritesFolderMenuItem";
            this.AddFavoritesFolderMenuItem.Size = new System.Drawing.Size(182, 22);
            this.AddFavoritesFolderMenuItem.Text = "Add Favorites Folder";
            // 
            // FavoritesContextMenuSeparator1
            // 
            this.FavoritesContextMenuSeparator1.Name = "FavoritesContextMenuSeparator1";
            this.FavoritesContextMenuSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // AddRepoMenuItem
            // 
            this.AddRepoMenuItem.Name = "AddRepoMenuItem";
            this.AddRepoMenuItem.Size = new System.Drawing.Size(182, 22);
            this.AddRepoMenuItem.Text = "Add Repo";
            // 
            // AddReposDirectoryMenuItem
            // 
            this.AddReposDirectoryMenuItem.Name = "AddReposDirectoryMenuItem";
            this.AddReposDirectoryMenuItem.Size = new System.Drawing.Size(182, 22);
            this.AddReposDirectoryMenuItem.Text = "Add Repos Directory";
            // 
            // FavoritesContextMenuSeparator2
            // 
            this.FavoritesContextMenuSeparator2.Name = "FavoritesContextMenuSeparator2";
            this.FavoritesContextMenuSeparator2.Size = new System.Drawing.Size(179, 6);
            // 
            // EditFavoriteMenuItem
            // 
            this.EditFavoriteMenuItem.Name = "EditFavoriteMenuItem";
            this.EditFavoriteMenuItem.Size = new System.Drawing.Size(182, 22);
            this.EditFavoriteMenuItem.Text = "Edit";
            // 
            // FavoritesContextMenuSeparator3
            // 
            this.FavoritesContextMenuSeparator3.Name = "FavoritesContextMenuSeparator3";
            this.FavoritesContextMenuSeparator3.Size = new System.Drawing.Size(179, 6);
            // 
            // RemoveFavoriteMenuItem
            // 
            this.RemoveFavoriteMenuItem.Name = "RemoveFavoriteMenuItem";
            this.RemoveFavoriteMenuItem.Size = new System.Drawing.Size(182, 22);
            this.RemoveFavoriteMenuItem.Text = "Remove";
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
        private System.Windows.Forms.ToolStripMenuItem AddFavoritesFolderMenuItem;
        private System.Windows.Forms.ImageList FavoritesTreeImageList;
        private System.Windows.Forms.ToolStripMenuItem AddRepoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveFavoriteMenuItem;
        private System.Windows.Forms.ToolStripSeparator FavoritesContextMenuSeparator1;
        private System.Windows.Forms.ToolStripSeparator FavoritesContextMenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem EditFavoriteMenuItem;
        private System.Windows.Forms.ToolStripSeparator FavoritesContextMenuSeparator3;
        private System.Windows.Forms.ToolStripMenuItem AddReposDirectoryMenuItem;
    }
}