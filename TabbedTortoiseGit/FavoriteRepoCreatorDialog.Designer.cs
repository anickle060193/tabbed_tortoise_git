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
            this.favoriteRepoDialog = new System.Windows.Forms.FolderBrowserDialog();
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
            this.ChangeFavoriteColorButton.Location = new System.Drawing.Point(14, 302);
            this.ChangeFavoriteColorButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ChangeFavoriteColorButton.Name = "ChangeFavoriteColorButton";
            this.ChangeFavoriteColorButton.Size = new System.Drawing.Size(35, 35);
            this.ChangeFavoriteColorButton.TabIndex = 4;
            this.ChangeFavoriteColorButton.UseVisualStyleBackColor = false;
            // 
            // FavoriteNameText
            // 
            this.FavoriteNameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FavoriteNameText.Location = new System.Drawing.Point(65, 46);
            this.FavoriteNameText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FavoriteNameText.Name = "FavoriteNameText";
            this.FavoriteNameText.Size = new System.Drawing.Size(426, 23);
            this.FavoriteNameText.TabIndex = 2;
            // 
            // Ok
            // 
            this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok.Location = new System.Drawing.Point(310, 310);
            this.Ok.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(88, 27);
            this.Ok.TabIndex = 5;
            this.Ok.Text = "OK";
            this.Ok.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(405, 310);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(88, 27);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // FavoriteNameLabel
            // 
            this.FavoriteNameLabel.AutoSize = true;
            this.FavoriteNameLabel.Location = new System.Drawing.Point(14, 50);
            this.FavoriteNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FavoriteNameLabel.Name = "FavoriteNameLabel";
            this.FavoriteNameLabel.Size = new System.Drawing.Size(42, 15);
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
            this.ReferencesListBox.ItemHeight = 15;
            this.ReferencesListBox.Location = new System.Drawing.Point(7, 22);
            this.ReferencesListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ReferencesListBox.Name = "ReferencesListBox";
            this.ReferencesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ReferencesListBox.Size = new System.Drawing.Size(464, 156);
            this.ReferencesListBox.TabIndex = 0;
            // 
            // ReferencesGroup
            // 
            this.ReferencesGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReferencesGroup.Controls.Add(this.SelectReferencesButton);
            this.ReferencesGroup.Controls.Add(this.RemoveReferencesButton);
            this.ReferencesGroup.Controls.Add(this.ReferencesListBox);
            this.ReferencesGroup.Location = new System.Drawing.Point(14, 76);
            this.ReferencesGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ReferencesGroup.Name = "ReferencesGroup";
            this.ReferencesGroup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ReferencesGroup.Size = new System.Drawing.Size(478, 219);
            this.ReferencesGroup.TabIndex = 3;
            this.ReferencesGroup.TabStop = false;
            this.ReferencesGroup.Text = "References";
            // 
            // SelectReferencesButton
            // 
            this.SelectReferencesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectReferencesButton.Location = new System.Drawing.Point(349, 186);
            this.SelectReferencesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SelectReferencesButton.Name = "SelectReferencesButton";
            this.SelectReferencesButton.Size = new System.Drawing.Size(122, 27);
            this.SelectReferencesButton.TabIndex = 1;
            this.SelectReferencesButton.Text = "Select References";
            this.SelectReferencesButton.UseVisualStyleBackColor = true;
            // 
            // RemoveReferencesButton
            // 
            this.RemoveReferencesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveReferencesButton.Location = new System.Drawing.Point(7, 186);
            this.RemoveReferencesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RemoveReferencesButton.Name = "RemoveReferencesButton";
            this.RemoveReferencesButton.Size = new System.Drawing.Size(88, 27);
            this.RemoveReferencesButton.TabIndex = 2;
            this.RemoveReferencesButton.Text = "Remove";
            this.RemoveReferencesButton.UseVisualStyleBackColor = true;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseButton.Location = new System.Drawing.Point(463, 13);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(29, 24);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            // 
            // FavoriteRepoText
            // 
            this.FavoriteRepoText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FavoriteRepoText.Location = new System.Drawing.Point(65, 14);
            this.FavoriteRepoText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FavoriteRepoText.Name = "FavoriteRepoText";
            this.FavoriteRepoText.Size = new System.Drawing.Size(391, 23);
            this.FavoriteRepoText.TabIndex = 0;
            // 
            // FavoriteRepoLabel
            // 
            this.FavoriteRepoLabel.AutoSize = true;
            this.FavoriteRepoLabel.Location = new System.Drawing.Point(14, 17);
            this.FavoriteRepoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FavoriteRepoLabel.Name = "FavoriteRepoLabel";
            this.FavoriteRepoLabel.Size = new System.Drawing.Size(37, 15);
            this.FavoriteRepoLabel.TabIndex = 8;
            this.FavoriteRepoLabel.Text = "Repo:";
            // 
            // FavoriteRepoCreatorDialog
            // 
            this.AcceptButton = this.Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(506, 351);
            this.Controls.Add(this.FavoriteRepoLabel);
            this.Controls.Add(this.FavoriteRepoText);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.FavoriteNameLabel);
            this.Controls.Add(this.FavoriteNameText);
            this.Controls.Add(this.ReferencesGroup);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.ChangeFavoriteColorButton);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(312, 282);
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
        private System.Windows.Forms.FolderBrowserDialog favoriteRepoDialog;
    }
}