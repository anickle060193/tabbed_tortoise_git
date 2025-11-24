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
            components = new System.ComponentModel.Container();
            FavoritesTree = new System.Windows.Forms.TreeView();
            FavoritesTreeImageList = new System.Windows.Forms.ImageList( components );
            FavoritesContextMenu = new System.Windows.Forms.ContextMenuStrip( components );
            AddFavoritesFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            FavoritesContextMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            AddRepoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            AddReposDirectoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            FavoritesContextMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            EditFavoriteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            FavoritesContextMenuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            RemoveFavoriteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            Cancel = new System.Windows.Forms.Button();
            Ok = new System.Windows.Forms.Button();
            FavoritesContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // FavoritesTree
            // 
            FavoritesTree.Anchor =    System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Bottom   |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            FavoritesTree.HideSelection = false;
            FavoritesTree.ImageIndex = 0;
            FavoritesTree.ImageList = FavoritesTreeImageList;
            FavoritesTree.Location = new System.Drawing.Point( 14, 14 );
            FavoritesTree.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            FavoritesTree.Name = "FavoritesTree";
            FavoritesTree.SelectedImageIndex = 0;
            FavoritesTree.ShowPlusMinus = false;
            FavoritesTree.ShowRootLines = false;
            FavoritesTree.Size = new System.Drawing.Size( 303, 355 );
            FavoritesTree.TabIndex = 0;
            // 
            // FavoritesTreeImageList
            // 
            FavoritesTreeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            FavoritesTreeImageList.ImageSize = new System.Drawing.Size( 16, 16 );
            FavoritesTreeImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FavoritesContextMenu
            // 
            FavoritesContextMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] { AddFavoritesFolderMenuItem, FavoritesContextMenuSeparator1, AddRepoMenuItem, AddReposDirectoryMenuItem, FavoritesContextMenuSeparator2, EditFavoriteMenuItem, FavoritesContextMenuSeparator3, RemoveFavoriteMenuItem } );
            FavoritesContextMenu.Name = "FavoritesTreeViewContextMenu";
            FavoritesContextMenu.Size = new System.Drawing.Size( 183, 132 );
            // 
            // AddFavoritesFolderMenuItem
            // 
            AddFavoritesFolderMenuItem.Name = "AddFavoritesFolderMenuItem";
            AddFavoritesFolderMenuItem.Size = new System.Drawing.Size( 182, 22 );
            AddFavoritesFolderMenuItem.Text = "Add Favorites Folder";
            // 
            // FavoritesContextMenuSeparator1
            // 
            FavoritesContextMenuSeparator1.Name = "FavoritesContextMenuSeparator1";
            FavoritesContextMenuSeparator1.Size = new System.Drawing.Size( 179, 6 );
            // 
            // AddRepoMenuItem
            // 
            AddRepoMenuItem.Name = "AddRepoMenuItem";
            AddRepoMenuItem.Size = new System.Drawing.Size( 182, 22 );
            AddRepoMenuItem.Text = "Add Repo";
            // 
            // AddReposDirectoryMenuItem
            // 
            AddReposDirectoryMenuItem.Name = "AddReposDirectoryMenuItem";
            AddReposDirectoryMenuItem.Size = new System.Drawing.Size( 182, 22 );
            AddReposDirectoryMenuItem.Text = "Add Repos Directory";
            // 
            // FavoritesContextMenuSeparator2
            // 
            FavoritesContextMenuSeparator2.Name = "FavoritesContextMenuSeparator2";
            FavoritesContextMenuSeparator2.Size = new System.Drawing.Size( 179, 6 );
            // 
            // EditFavoriteMenuItem
            // 
            EditFavoriteMenuItem.Name = "EditFavoriteMenuItem";
            EditFavoriteMenuItem.Size = new System.Drawing.Size( 182, 22 );
            EditFavoriteMenuItem.Text = "Edit";
            // 
            // FavoritesContextMenuSeparator3
            // 
            FavoritesContextMenuSeparator3.Name = "FavoritesContextMenuSeparator3";
            FavoritesContextMenuSeparator3.Size = new System.Drawing.Size( 179, 6 );
            // 
            // RemoveFavoriteMenuItem
            // 
            RemoveFavoriteMenuItem.Name = "RemoveFavoriteMenuItem";
            RemoveFavoriteMenuItem.Size = new System.Drawing.Size( 182, 22 );
            RemoveFavoriteMenuItem.Text = "Remove";
            // 
            // Cancel
            // 
            Cancel.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Cancel.Location = new System.Drawing.Point( 230, 376 );
            Cancel.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Cancel.Name = "Cancel";
            Cancel.Size = new System.Drawing.Size( 88, 27 );
            Cancel.TabIndex = 1;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            // 
            // Ok
            // 
            Ok.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            Ok.Location = new System.Drawing.Point( 135, 376 );
            Ok.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Ok.Name = "Ok";
            Ok.Size = new System.Drawing.Size( 88, 27 );
            Ok.TabIndex = 2;
            Ok.Text = "OK";
            Ok.UseVisualStyleBackColor = true;
            // 
            // FavoritesManagerDialog
            // 
            AcceptButton = Ok;
            AutoScaleDimensions = new System.Drawing.SizeF( 7F, 15F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = Cancel;
            ClientSize = new System.Drawing.Size( 331, 417 );
            Controls.Add( FavoritesTree );
            Controls.Add( Ok );
            Controls.Add( Cancel );
            Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            MinimumSize = new System.Drawing.Size( 347, 340 );
            Name = "FavoritesManagerDialog";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Favorites Manager";
            FavoritesContextMenu.ResumeLayout( false );
            ResumeLayout( false );

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