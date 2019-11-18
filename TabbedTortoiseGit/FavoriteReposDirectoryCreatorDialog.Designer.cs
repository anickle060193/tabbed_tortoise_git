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
            this.SuspendLayout();
            // 
            // FavoriteColorDialog
            // 
            this.FavoriteColorDialog.AnyColor = true;
            // 
            // ChangeFavoriteColorButton
            // 
            this.ChangeFavoriteColorButton.Location = new System.Drawing.Point(12, 67);
            this.ChangeFavoriteColorButton.Name = "ChangeFavoriteColorButton";
            this.ChangeFavoriteColorButton.Size = new System.Drawing.Size(30, 30);
            this.ChangeFavoriteColorButton.TabIndex = 1;
            this.ChangeFavoriteColorButton.UseVisualStyleBackColor = false;
            // 
            // FavoriteNameText
            // 
            this.FavoriteNameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FavoriteNameText.Location = new System.Drawing.Point(57, 12);
            this.FavoriteNameText.Name = "FavoriteNameText";
            this.FavoriteNameText.Size = new System.Drawing.Size(361, 20);
            this.FavoriteNameText.TabIndex = 0;
            // 
            // Ok
            // 
            this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok.Location = new System.Drawing.Point(262, 74);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 2;
            this.Ok.Text = "OK";
            this.Ok.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(343, 74);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // FavoriteNameLabel
            // 
            this.FavoriteNameLabel.AutoSize = true;
            this.FavoriteNameLabel.Location = new System.Drawing.Point(12, 15);
            this.FavoriteNameLabel.Name = "FavoriteNameLabel";
            this.FavoriteNameLabel.Size = new System.Drawing.Size(38, 13);
            this.FavoriteNameLabel.TabIndex = 4;
            this.FavoriteNameLabel.Text = "Name:";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseButton.Location = new System.Drawing.Point(393, 38);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(25, 23);
            this.BrowseButton.TabIndex = 6;
            this.BrowseButton.Text = "...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            // 
            // FavoriteDirectoryText
            // 
            this.FavoriteDirectoryText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FavoriteDirectoryText.Location = new System.Drawing.Point(57, 40);
            this.FavoriteDirectoryText.Name = "FavoriteDirectoryText";
            this.FavoriteDirectoryText.Size = new System.Drawing.Size(330, 20);
            this.FavoriteDirectoryText.TabIndex = 7;
            // 
            // FavoriteDirectoryLabel
            // 
            this.FavoriteDirectoryLabel.AutoSize = true;
            this.FavoriteDirectoryLabel.Location = new System.Drawing.Point(12, 43);
            this.FavoriteDirectoryLabel.Name = "FavoriteDirectoryLabel";
            this.FavoriteDirectoryLabel.Size = new System.Drawing.Size(39, 13);
            this.FavoriteDirectoryLabel.TabIndex = 8;
            this.FavoriteDirectoryLabel.Text = "Folder:";
            // 
            // FavoriteReposFolderCreatorDialog
            // 
            this.AcceptButton = this.Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(430, 107);
            this.Controls.Add(this.FavoriteDirectoryLabel);
            this.Controls.Add(this.FavoriteDirectoryText);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.FavoriteNameLabel);
            this.Controls.Add(this.FavoriteNameText);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.ChangeFavoriteColorButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FavoriteReposFolderCreatorDialog";
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
    }
}