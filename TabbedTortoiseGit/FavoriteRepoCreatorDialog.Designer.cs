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
            FavoriteColorDialog = new System.Windows.Forms.ColorDialog();
            ChangeFavoriteColorButton = new System.Windows.Forms.Button();
            FavoriteNameText = new System.Windows.Forms.TextBox();
            Ok = new System.Windows.Forms.Button();
            Cancel = new System.Windows.Forms.Button();
            FavoriteNameLabel = new System.Windows.Forms.Label();
            ReferencesListBox = new System.Windows.Forms.ListBox();
            ReferencesGroup = new System.Windows.Forms.GroupBox();
            SelectReferencesButton = new System.Windows.Forms.Button();
            RemoveReferencesButton = new System.Windows.Forms.Button();
            BrowseButton = new System.Windows.Forms.Button();
            FavoriteRepoText = new System.Windows.Forms.TextBox();
            FavoriteRepoLabel = new System.Windows.Forms.Label();
            favoriteRepoDialog = new System.Windows.Forms.FolderBrowserDialog();
            ReferencesGroup.SuspendLayout();
            SuspendLayout();
            // 
            // FavoriteColorDialog
            // 
            FavoriteColorDialog.AnyColor = true;
            // 
            // ChangeFavoriteColorButton
            // 
            ChangeFavoriteColorButton.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left ;
            ChangeFavoriteColorButton.Location = new System.Drawing.Point( 14, 302 );
            ChangeFavoriteColorButton.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ChangeFavoriteColorButton.Name = "ChangeFavoriteColorButton";
            ChangeFavoriteColorButton.Size = new System.Drawing.Size( 35, 35 );
            ChangeFavoriteColorButton.TabIndex = 4;
            ChangeFavoriteColorButton.UseVisualStyleBackColor = false;
            // 
            // FavoriteNameText
            // 
            FavoriteNameText.Anchor =   System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            FavoriteNameText.Location = new System.Drawing.Point( 65, 46 );
            FavoriteNameText.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            FavoriteNameText.Name = "FavoriteNameText";
            FavoriteNameText.Size = new System.Drawing.Size( 426, 23 );
            FavoriteNameText.TabIndex = 2;
            // 
            // Ok
            // 
            Ok.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            Ok.Location = new System.Drawing.Point( 310, 310 );
            Ok.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Ok.Name = "Ok";
            Ok.Size = new System.Drawing.Size( 88, 27 );
            Ok.TabIndex = 5;
            Ok.Text = "OK";
            Ok.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            Cancel.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Cancel.Location = new System.Drawing.Point( 405, 310 );
            Cancel.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Cancel.Name = "Cancel";
            Cancel.Size = new System.Drawing.Size( 88, 27 );
            Cancel.TabIndex = 6;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            // 
            // FavoriteNameLabel
            // 
            FavoriteNameLabel.AutoSize = true;
            FavoriteNameLabel.Location = new System.Drawing.Point( 14, 50 );
            FavoriteNameLabel.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            FavoriteNameLabel.Name = "FavoriteNameLabel";
            FavoriteNameLabel.Size = new System.Drawing.Size( 42, 15 );
            FavoriteNameLabel.TabIndex = 4;
            FavoriteNameLabel.Text = "Name:";
            // 
            // ReferencesListBox
            // 
            ReferencesListBox.Anchor =    System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Bottom   |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            ReferencesListBox.FormattingEnabled = true;
            ReferencesListBox.IntegralHeight = false;
            ReferencesListBox.Location = new System.Drawing.Point( 7, 22 );
            ReferencesListBox.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ReferencesListBox.Name = "ReferencesListBox";
            ReferencesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            ReferencesListBox.Size = new System.Drawing.Size( 464, 156 );
            ReferencesListBox.TabIndex = 0;
            // 
            // ReferencesGroup
            // 
            ReferencesGroup.Anchor =    System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Bottom   |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            ReferencesGroup.Controls.Add( SelectReferencesButton );
            ReferencesGroup.Controls.Add( RemoveReferencesButton );
            ReferencesGroup.Controls.Add( ReferencesListBox );
            ReferencesGroup.Location = new System.Drawing.Point( 14, 76 );
            ReferencesGroup.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ReferencesGroup.Name = "ReferencesGroup";
            ReferencesGroup.Padding = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ReferencesGroup.Size = new System.Drawing.Size( 478, 219 );
            ReferencesGroup.TabIndex = 3;
            ReferencesGroup.TabStop = false;
            ReferencesGroup.Text = "References";
            // 
            // SelectReferencesButton
            // 
            SelectReferencesButton.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            SelectReferencesButton.Location = new System.Drawing.Point( 349, 186 );
            SelectReferencesButton.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            SelectReferencesButton.Name = "SelectReferencesButton";
            SelectReferencesButton.Size = new System.Drawing.Size( 122, 27 );
            SelectReferencesButton.TabIndex = 1;
            SelectReferencesButton.Text = "Select References";
            SelectReferencesButton.UseVisualStyleBackColor = true;
            // 
            // RemoveReferencesButton
            // 
            RemoveReferencesButton.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left ;
            RemoveReferencesButton.Location = new System.Drawing.Point( 7, 186 );
            RemoveReferencesButton.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            RemoveReferencesButton.Name = "RemoveReferencesButton";
            RemoveReferencesButton.Size = new System.Drawing.Size( 88, 27 );
            RemoveReferencesButton.TabIndex = 2;
            RemoveReferencesButton.Text = "Remove";
            RemoveReferencesButton.UseVisualStyleBackColor = true;
            // 
            // BrowseButton
            // 
            BrowseButton.Anchor =  System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Right ;
            BrowseButton.Location = new System.Drawing.Point( 463, 13 );
            BrowseButton.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new System.Drawing.Size( 29, 24 );
            BrowseButton.TabIndex = 1;
            BrowseButton.Text = "...";
            BrowseButton.UseVisualStyleBackColor = true;
            // 
            // FavoriteRepoText
            // 
            FavoriteRepoText.Anchor =   System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            FavoriteRepoText.Location = new System.Drawing.Point( 65, 14 );
            FavoriteRepoText.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            FavoriteRepoText.Name = "FavoriteRepoText";
            FavoriteRepoText.Size = new System.Drawing.Size( 391, 23 );
            FavoriteRepoText.TabIndex = 0;
            // 
            // FavoriteRepoLabel
            // 
            FavoriteRepoLabel.AutoSize = true;
            FavoriteRepoLabel.Location = new System.Drawing.Point( 14, 17 );
            FavoriteRepoLabel.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            FavoriteRepoLabel.Name = "FavoriteRepoLabel";
            FavoriteRepoLabel.Size = new System.Drawing.Size( 37, 15 );
            FavoriteRepoLabel.TabIndex = 8;
            FavoriteRepoLabel.Text = "Repo:";
            // 
            // FavoriteRepoCreatorDialog
            // 
            AcceptButton = Ok;
            AutoScaleDimensions = new System.Drawing.SizeF( 7F, 15F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = Cancel;
            ClientSize = new System.Drawing.Size( 506, 351 );
            Controls.Add( FavoriteRepoLabel );
            Controls.Add( FavoriteRepoText );
            Controls.Add( BrowseButton );
            Controls.Add( FavoriteNameLabel );
            Controls.Add( FavoriteNameText );
            Controls.Add( ReferencesGroup );
            Controls.Add( Ok );
            Controls.Add( Cancel );
            Controls.Add( ChangeFavoriteColorButton );
            Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size( 312, 282 );
            Name = "FavoriteRepoCreatorDialog";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Favorite Repo";
            ReferencesGroup.ResumeLayout( false );
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