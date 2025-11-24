namespace TabbedTortoiseGit
{
    partial class FavoriteReposDirectoryCreatorDialog
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
            FavoriteColorDialog = new System.Windows.Forms.ColorDialog();
            ChangeFavoriteColorButton = new System.Windows.Forms.Button();
            FavoriteNameText = new System.Windows.Forms.TextBox();
            Ok = new System.Windows.Forms.Button();
            Cancel = new System.Windows.Forms.Button();
            FavoriteNameLabel = new System.Windows.Forms.Label();
            BrowseButton = new System.Windows.Forms.Button();
            FavoriteDirectoryText = new System.Windows.Forms.TextBox();
            FavoriteDirectoryLabel = new System.Windows.Forms.Label();
            favoriteReposFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            SuspendLayout();
            // 
            // FavoriteColorDialog
            // 
            FavoriteColorDialog.AnyColor = true;
            // 
            // ChangeFavoriteColorButton
            // 
            ChangeFavoriteColorButton.Location = new System.Drawing.Point( 14, 77 );
            ChangeFavoriteColorButton.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ChangeFavoriteColorButton.Name = "ChangeFavoriteColorButton";
            ChangeFavoriteColorButton.Size = new System.Drawing.Size( 35, 35 );
            ChangeFavoriteColorButton.TabIndex = 3;
            ChangeFavoriteColorButton.UseVisualStyleBackColor = false;
            // 
            // FavoriteNameText
            // 
            FavoriteNameText.Anchor =   System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            FavoriteNameText.Location = new System.Drawing.Point( 66, 44 );
            FavoriteNameText.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            FavoriteNameText.Name = "FavoriteNameText";
            FavoriteNameText.Size = new System.Drawing.Size( 420, 23 );
            FavoriteNameText.TabIndex = 2;
            // 
            // Ok
            // 
            Ok.Anchor =  System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Right ;
            Ok.Location = new System.Drawing.Point( 306, 85 );
            Ok.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Ok.Name = "Ok";
            Ok.Size = new System.Drawing.Size( 88, 27 );
            Ok.TabIndex = 4;
            Ok.Text = "OK";
            Ok.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            Cancel.Anchor =  System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Right ;
            Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Cancel.Location = new System.Drawing.Point( 400, 85 );
            Cancel.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Cancel.Name = "Cancel";
            Cancel.Size = new System.Drawing.Size( 88, 27 );
            Cancel.TabIndex = 5;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            // 
            // FavoriteNameLabel
            // 
            FavoriteNameLabel.AutoSize = true;
            FavoriteNameLabel.Location = new System.Drawing.Point( 14, 47 );
            FavoriteNameLabel.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            FavoriteNameLabel.Name = "FavoriteNameLabel";
            FavoriteNameLabel.Size = new System.Drawing.Size( 42, 15 );
            FavoriteNameLabel.TabIndex = 4;
            FavoriteNameLabel.Text = "Name:";
            // 
            // BrowseButton
            // 
            BrowseButton.Anchor =  System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Right ;
            BrowseButton.Location = new System.Drawing.Point( 458, 13 );
            BrowseButton.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new System.Drawing.Size( 29, 24 );
            BrowseButton.TabIndex = 1;
            BrowseButton.Text = "...";
            BrowseButton.UseVisualStyleBackColor = true;
            // 
            // FavoriteDirectoryText
            // 
            FavoriteDirectoryText.Anchor =   System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            FavoriteDirectoryText.Location = new System.Drawing.Point( 66, 14 );
            FavoriteDirectoryText.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            FavoriteDirectoryText.Name = "FavoriteDirectoryText";
            FavoriteDirectoryText.Size = new System.Drawing.Size( 384, 23 );
            FavoriteDirectoryText.TabIndex = 0;
            // 
            // FavoriteDirectoryLabel
            // 
            FavoriteDirectoryLabel.AutoSize = true;
            FavoriteDirectoryLabel.Location = new System.Drawing.Point( 14, 17 );
            FavoriteDirectoryLabel.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            FavoriteDirectoryLabel.Name = "FavoriteDirectoryLabel";
            FavoriteDirectoryLabel.Size = new System.Drawing.Size( 43, 15 );
            FavoriteDirectoryLabel.TabIndex = 8;
            FavoriteDirectoryLabel.Text = "Folder:";
            // 
            // FavoriteReposDirectoryCreatorDialog
            // 
            AcceptButton = Ok;
            AutoScaleDimensions = new System.Drawing.SizeF( 7F, 15F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = Cancel;
            ClientSize = new System.Drawing.Size( 502, 123 );
            Controls.Add( FavoriteDirectoryLabel );
            Controls.Add( FavoriteDirectoryText );
            Controls.Add( BrowseButton );
            Controls.Add( FavoriteNameLabel );
            Controls.Add( FavoriteNameText );
            Controls.Add( Ok );
            Controls.Add( Cancel );
            Controls.Add( ChangeFavoriteColorButton );
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FavoriteReposDirectoryCreatorDialog";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Favorite Repos Folder";
            ResumeLayout( false );
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog FavoriteColorDialog;
        private System.Windows.Forms.Button ChangeFavoriteColorButton;
        private System.Windows.Forms.TextBox FavoriteNameText;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label FavoriteNameLabel;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox FavoriteDirectoryText;
        private System.Windows.Forms.Label FavoriteDirectoryLabel;
        private System.Windows.Forms.FolderBrowserDialog favoriteReposFolderDialog;
    }
}