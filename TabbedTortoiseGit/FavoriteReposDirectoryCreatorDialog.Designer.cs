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
            this.FavoriteColorDialog = new System.Windows.Forms.ColorDialog();
            this.ChangeFavoriteColorButton = new System.Windows.Forms.Button();
            this.FavoriteNameText = new System.Windows.Forms.TextBox();
            this.Ok = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.FavoriteNameLabel = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.FavoriteDirectoryText = new System.Windows.Forms.TextBox();
            this.FavoriteDirectoryLabel = new System.Windows.Forms.Label();
            this.favoriteReposFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // FavoriteColorDialog
            // 
            this.FavoriteColorDialog.AnyColor = true;
            // 
            // ChangeFavoriteColorButton
            // 
            this.ChangeFavoriteColorButton.Location = new System.Drawing.Point(14, 77);
            this.ChangeFavoriteColorButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ChangeFavoriteColorButton.Name = "ChangeFavoriteColorButton";
            this.ChangeFavoriteColorButton.Size = new System.Drawing.Size(35, 35);
            this.ChangeFavoriteColorButton.TabIndex = 3;
            this.ChangeFavoriteColorButton.UseVisualStyleBackColor = false;
            // 
            // FavoriteNameText
            // 
            this.FavoriteNameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FavoriteNameText.Location = new System.Drawing.Point(66, 44);
            this.FavoriteNameText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FavoriteNameText.Name = "FavoriteNameText";
            this.FavoriteNameText.Size = new System.Drawing.Size(420, 23);
            this.FavoriteNameText.TabIndex = 2;
            // 
            // Ok
            // 
            this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok.Location = new System.Drawing.Point(306, 85);
            this.Ok.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(88, 27);
            this.Ok.TabIndex = 4;
            this.Ok.Text = "OK";
            this.Ok.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(400, 85);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(88, 27);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // FavoriteNameLabel
            // 
            this.FavoriteNameLabel.AutoSize = true;
            this.FavoriteNameLabel.Location = new System.Drawing.Point(14, 47);
            this.FavoriteNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FavoriteNameLabel.Name = "FavoriteNameLabel";
            this.FavoriteNameLabel.Size = new System.Drawing.Size(42, 15);
            this.FavoriteNameLabel.TabIndex = 4;
            this.FavoriteNameLabel.Text = "Name:";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseButton.Location = new System.Drawing.Point(458, 13);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(29, 24);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            // 
            // FavoriteDirectoryText
            // 
            this.FavoriteDirectoryText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FavoriteDirectoryText.Location = new System.Drawing.Point(66, 14);
            this.FavoriteDirectoryText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FavoriteDirectoryText.Name = "FavoriteDirectoryText";
            this.FavoriteDirectoryText.Size = new System.Drawing.Size(384, 23);
            this.FavoriteDirectoryText.TabIndex = 0;
            // 
            // FavoriteDirectoryLabel
            // 
            this.FavoriteDirectoryLabel.AutoSize = true;
            this.FavoriteDirectoryLabel.Location = new System.Drawing.Point(14, 17);
            this.FavoriteDirectoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FavoriteDirectoryLabel.Name = "FavoriteDirectoryLabel";
            this.FavoriteDirectoryLabel.Size = new System.Drawing.Size(43, 15);
            this.FavoriteDirectoryLabel.TabIndex = 8;
            this.FavoriteDirectoryLabel.Text = "Folder:";
            // 
            // FavoriteReposDirectoryCreatorDialog
            // 
            this.AcceptButton = this.Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(502, 123);
            this.Controls.Add(this.FavoriteDirectoryLabel);
            this.Controls.Add(this.FavoriteDirectoryText);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.FavoriteNameLabel);
            this.Controls.Add(this.FavoriteNameText);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.ChangeFavoriteColorButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FavoriteReposDirectoryCreatorDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Favorite Repos Folder";
            this.ResumeLayout(false);
            this.PerformLayout();

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