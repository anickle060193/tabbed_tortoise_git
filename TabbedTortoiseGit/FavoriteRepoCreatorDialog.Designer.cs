namespace TabbedTortoiseGit
{
    partial class FavoriteRepoCreatorDialog
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
            this.ReferencesListBox = new System.Windows.Forms.ListBox();
            this.ReferencesGroup = new System.Windows.Forms.GroupBox();
            this.SelectReferencesButton = new System.Windows.Forms.Button();
            this.RemoveReferencesButton = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.FavoriteRepoText = new System.Windows.Forms.TextBox();
            this.FavoriteRepoLabel = new System.Windows.Forms.Label();
            this.ReferencesGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // FavoriteColorDialog
            // 
            this.FavoriteColorDialog.AnyColor = true;
            // 
            // ChangeFavoriteColorButton
            // 
            this.ChangeFavoriteColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChangeFavoriteColorButton.Location = new System.Drawing.Point(12, 262);
            this.ChangeFavoriteColorButton.Name = "ChangeFavoriteColorButton";
            this.ChangeFavoriteColorButton.Size = new System.Drawing.Size(30, 30);
            this.ChangeFavoriteColorButton.TabIndex = 1;
            this.ChangeFavoriteColorButton.UseVisualStyleBackColor = false;
            // 
            // FavoriteNameText
            // 
            this.FavoriteNameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FavoriteNameText.Location = new System.Drawing.Point(56, 12);
            this.FavoriteNameText.Name = "FavoriteNameText";
            this.FavoriteNameText.Size = new System.Drawing.Size(366, 20);
            this.FavoriteNameText.TabIndex = 0;
            // 
            // Ok
            // 
            this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok.Location = new System.Drawing.Point(266, 269);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 2;
            this.Ok.Text = "OK";
            this.Ok.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(347, 269);
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
            // ReferencesListBox
            // 
            this.ReferencesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReferencesListBox.FormattingEnabled = true;
            this.ReferencesListBox.IntegralHeight = false;
            this.ReferencesListBox.Location = new System.Drawing.Point(6, 19);
            this.ReferencesListBox.Name = "ReferencesListBox";
            this.ReferencesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ReferencesListBox.Size = new System.Drawing.Size(398, 136);
            this.ReferencesListBox.TabIndex = 1;
            // 
            // ReferencesGroup
            // 
            this.ReferencesGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReferencesGroup.Controls.Add(this.SelectReferencesButton);
            this.ReferencesGroup.Controls.Add(this.RemoveReferencesButton);
            this.ReferencesGroup.Controls.Add(this.ReferencesListBox);
            this.ReferencesGroup.Location = new System.Drawing.Point(12, 66);
            this.ReferencesGroup.Name = "ReferencesGroup";
            this.ReferencesGroup.Size = new System.Drawing.Size(410, 190);
            this.ReferencesGroup.TabIndex = 5;
            this.ReferencesGroup.TabStop = false;
            this.ReferencesGroup.Text = "References";
            // 
            // SelectReferencesButton
            // 
            this.SelectReferencesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectReferencesButton.Location = new System.Drawing.Point(299, 161);
            this.SelectReferencesButton.Name = "SelectReferencesButton";
            this.SelectReferencesButton.Size = new System.Drawing.Size(105, 23);
            this.SelectReferencesButton.TabIndex = 4;
            this.SelectReferencesButton.Text = "Select References";
            this.SelectReferencesButton.UseVisualStyleBackColor = true;
            // 
            // RemoveReferencesButton
            // 
            this.RemoveReferencesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveReferencesButton.Location = new System.Drawing.Point(6, 161);
            this.RemoveReferencesButton.Name = "RemoveReferencesButton";
            this.RemoveReferencesButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveReferencesButton.TabIndex = 3;
            this.RemoveReferencesButton.Text = "Remove";
            this.RemoveReferencesButton.UseVisualStyleBackColor = true;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseButton.Location = new System.Drawing.Point(397, 38);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(25, 23);
            this.BrowseButton.TabIndex = 6;
            this.BrowseButton.Text = "...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            // 
            // FavoriteRepoText
            // 
            this.FavoriteRepoText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FavoriteRepoText.Location = new System.Drawing.Point(56, 40);
            this.FavoriteRepoText.Name = "FavoriteRepoText";
            this.FavoriteRepoText.Size = new System.Drawing.Size(335, 20);
            this.FavoriteRepoText.TabIndex = 7;
            // 
            // FavoriteRepoLabel
            // 
            this.FavoriteRepoLabel.AutoSize = true;
            this.FavoriteRepoLabel.Location = new System.Drawing.Point(12, 43);
            this.FavoriteRepoLabel.Name = "FavoriteRepoLabel";
            this.FavoriteRepoLabel.Size = new System.Drawing.Size(36, 13);
            this.FavoriteRepoLabel.TabIndex = 8;
            this.FavoriteRepoLabel.Text = "Repo:";
            // 
            // FavoriteRepoCreatorDialog
            // 
            this.AcceptButton = this.Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(434, 304);
            this.Controls.Add(this.FavoriteRepoLabel);
            this.Controls.Add(this.FavoriteRepoText);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.FavoriteNameLabel);
            this.Controls.Add(this.FavoriteNameText);
            this.Controls.Add(this.ReferencesGroup);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.ChangeFavoriteColorButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(270, 250);
            this.Name = "FavoriteRepoCreatorDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Favorite Repo";
            this.ReferencesGroup.ResumeLayout(false);
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
        private System.Windows.Forms.ListBox ReferencesListBox;
        private System.Windows.Forms.GroupBox ReferencesGroup;
        private System.Windows.Forms.Button RemoveReferencesButton;
        private System.Windows.Forms.Button SelectReferencesButton;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox FavoriteRepoText;
        private System.Windows.Forms.Label FavoriteRepoLabel;
    }
}