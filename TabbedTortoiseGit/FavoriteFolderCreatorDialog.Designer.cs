namespace TabbedTortoiseGit
{
    partial class FavoriteFolderCreatorDialog
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
            this.SuspendLayout();
            // 
            // FavoriteColorDialog
            // 
            this.FavoriteColorDialog.AnyColor = true;
            // 
            // ChangeFavoriteColorButton
            // 
            this.ChangeFavoriteColorButton.Location = new System.Drawing.Point(15, 38);
            this.ChangeFavoriteColorButton.Name = "ChangeFavoriteColorButton";
            this.ChangeFavoriteColorButton.Size = new System.Drawing.Size(30, 30);
            this.ChangeFavoriteColorButton.TabIndex = 1;
            this.ChangeFavoriteColorButton.UseVisualStyleBackColor = false;
            // 
            // FavoriteNameText
            // 
            this.FavoriteNameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FavoriteNameText.Location = new System.Drawing.Point(97, 12);
            this.FavoriteNameText.Name = "FavoriteNameText";
            this.FavoriteNameText.Size = new System.Drawing.Size(325, 20);
            this.FavoriteNameText.TabIndex = 0;
            // 
            // Ok
            // 
            this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok.Location = new System.Drawing.Point(266, 45);
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
            this.Cancel.Location = new System.Drawing.Point(347, 45);
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
            this.FavoriteNameLabel.Size = new System.Drawing.Size(79, 13);
            this.FavoriteNameLabel.TabIndex = 4;
            this.FavoriteNameLabel.Text = "Favorite Name:";
            // 
            // FavoriteFolderCreatorDialog
            // 
            this.AcceptButton = this.Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(434, 76);
            this.Controls.Add(this.FavoriteNameLabel);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.FavoriteNameText);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.ChangeFavoriteColorButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FavoriteFolderCreatorDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Favorite Creator";
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
    }
}