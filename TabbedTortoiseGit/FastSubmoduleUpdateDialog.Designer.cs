namespace TabbedTortoiseGit
{
    partial class FastSubmoduleUpdateDialog
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
            Cancel = new System.Windows.Forms.Button();
            UpdateSubmodulesButton = new System.Windows.Forms.Button();
            SelectAllSubmodules = new System.Windows.Forms.Button();
            SelectNoneSubmodules = new System.Windows.Forms.Button();
            SubmoduleCheckList = new System.Windows.Forms.CheckedListBox();
            InitCheck = new System.Windows.Forms.CheckBox();
            RecursiveCheck = new System.Windows.Forms.CheckBox();
            ForceCheck = new System.Windows.Forms.CheckBox();
            SelectModifiedSubmodules = new System.Windows.Forms.Button();
            MaxProcessCountNumeric = new System.Windows.Forms.NumericUpDown();
            MaxProcessCountLabel = new System.Windows.Forms.Label();
            ShowModifiedSubmodulesOnlyCheck = new System.Windows.Forms.CheckBox();
            SubmoduleUpdateOptionsGroup = new System.Windows.Forms.GroupBox();
            CheckModifiedSubmodulesByDefaultCheck = new System.Windows.Forms.CheckBox();
            ( (System.ComponentModel.ISupportInitialize)MaxProcessCountNumeric ).BeginInit();
            SubmoduleUpdateOptionsGroup.SuspendLayout();
            SuspendLayout();
            // 
            // Cancel
            // 
            Cancel.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Cancel.Location = new System.Drawing.Point( 440, 468 );
            Cancel.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Cancel.Name = "Cancel";
            Cancel.Size = new System.Drawing.Size( 88, 27 );
            Cancel.TabIndex = 1;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            // 
            // UpdateSubmodulesButton
            // 
            UpdateSubmodulesButton.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            UpdateSubmodulesButton.Enabled = false;
            UpdateSubmodulesButton.Location = new System.Drawing.Point( 300, 468 );
            UpdateSubmodulesButton.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            UpdateSubmodulesButton.Name = "UpdateSubmodulesButton";
            UpdateSubmodulesButton.Size = new System.Drawing.Size( 133, 27 );
            UpdateSubmodulesButton.TabIndex = 2;
            UpdateSubmodulesButton.Text = "Update Submodules";
            UpdateSubmodulesButton.UseVisualStyleBackColor = true;
            // 
            // SelectAllSubmodules
            // 
            SelectAllSubmodules.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left ;
            SelectAllSubmodules.Location = new System.Drawing.Point( 14, 377 );
            SelectAllSubmodules.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            SelectAllSubmodules.Name = "SelectAllSubmodules";
            SelectAllSubmodules.Size = new System.Drawing.Size( 88, 27 );
            SelectAllSubmodules.TabIndex = 4;
            SelectAllSubmodules.Text = "Select All";
            SelectAllSubmodules.UseVisualStyleBackColor = true;
            // 
            // SelectNoneSubmodules
            // 
            SelectNoneSubmodules.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left ;
            SelectNoneSubmodules.Location = new System.Drawing.Point( 108, 377 );
            SelectNoneSubmodules.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            SelectNoneSubmodules.Name = "SelectNoneSubmodules";
            SelectNoneSubmodules.Size = new System.Drawing.Size( 88, 27 );
            SelectNoneSubmodules.TabIndex = 5;
            SelectNoneSubmodules.Text = "Select None";
            SelectNoneSubmodules.UseVisualStyleBackColor = true;
            // 
            // SubmoduleCheckList
            // 
            SubmoduleCheckList.Anchor =    System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Bottom   |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            SubmoduleCheckList.CheckOnClick = true;
            SubmoduleCheckList.FormattingEnabled = true;
            SubmoduleCheckList.IntegralHeight = false;
            SubmoduleCheckList.Location = new System.Drawing.Point( 14, 14 );
            SubmoduleCheckList.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            SubmoduleCheckList.Name = "SubmoduleCheckList";
            SubmoduleCheckList.Size = new System.Drawing.Size( 513, 356 );
            SubmoduleCheckList.TabIndex = 6;
            // 
            // InitCheck
            // 
            InitCheck.AutoSize = true;
            InitCheck.Checked = true;
            InitCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            InitCheck.Font = new System.Drawing.Font( "Consolas", 8.25F );
            InitCheck.Location = new System.Drawing.Point( 7, 22 );
            InitCheck.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            InitCheck.Name = "InitCheck";
            InitCheck.Size = new System.Drawing.Size( 62, 17 );
            InitCheck.TabIndex = 7;
            InitCheck.Text = "--init";
            InitCheck.UseVisualStyleBackColor = true;
            // 
            // RecursiveCheck
            // 
            RecursiveCheck.AutoSize = true;
            RecursiveCheck.Checked = true;
            RecursiveCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            RecursiveCheck.Font = new System.Drawing.Font( "Consolas", 8.25F );
            RecursiveCheck.Location = new System.Drawing.Point( 86, 22 );
            RecursiveCheck.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            RecursiveCheck.Name = "RecursiveCheck";
            RecursiveCheck.Size = new System.Drawing.Size( 92, 17 );
            RecursiveCheck.TabIndex = 8;
            RecursiveCheck.Text = "--recursive";
            RecursiveCheck.UseVisualStyleBackColor = true;
            // 
            // ForceCheck
            // 
            ForceCheck.AutoSize = true;
            ForceCheck.Checked = true;
            ForceCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            ForceCheck.Font = new System.Drawing.Font( "Consolas", 8.25F );
            ForceCheck.Location = new System.Drawing.Point( 201, 22 );
            ForceCheck.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ForceCheck.Name = "ForceCheck";
            ForceCheck.Size = new System.Drawing.Size( 68, 17 );
            ForceCheck.TabIndex = 9;
            ForceCheck.Text = "--force";
            ForceCheck.UseVisualStyleBackColor = true;
            // 
            // SelectModifiedSubmodules
            // 
            SelectModifiedSubmodules.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left ;
            SelectModifiedSubmodules.Enabled = false;
            SelectModifiedSubmodules.Location = new System.Drawing.Point( 14, 408 );
            SelectModifiedSubmodules.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            SelectModifiedSubmodules.Name = "SelectModifiedSubmodules";
            SelectModifiedSubmodules.Size = new System.Drawing.Size( 182, 27 );
            SelectModifiedSubmodules.TabIndex = 10;
            SelectModifiedSubmodules.Text = "Getting submodule status...";
            SelectModifiedSubmodules.UseVisualStyleBackColor = true;
            // 
            // MaxProcessCountNumeric
            // 
            MaxProcessCountNumeric.Location = new System.Drawing.Point( 110, 48 );
            MaxProcessCountNumeric.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            MaxProcessCountNumeric.Maximum = new decimal( new int[] { 64, 0, 0, 0 } );
            MaxProcessCountNumeric.Minimum = new decimal( new int[] { 1, 0, 0, 0 } );
            MaxProcessCountNumeric.Name = "MaxProcessCountNumeric";
            MaxProcessCountNumeric.Size = new System.Drawing.Size( 49, 23 );
            MaxProcessCountNumeric.TabIndex = 11;
            MaxProcessCountNumeric.Value = new decimal( new int[] { 1, 0, 0, 0 } );
            // 
            // MaxProcessCountLabel
            // 
            MaxProcessCountLabel.AutoSize = true;
            MaxProcessCountLabel.Location = new System.Drawing.Point( 7, 51 );
            MaxProcessCountLabel.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            MaxProcessCountLabel.Name = "MaxProcessCountLabel";
            MaxProcessCountLabel.Size = new System.Drawing.Size( 86, 15 );
            MaxProcessCountLabel.TabIndex = 12;
            MaxProcessCountLabel.Text = "Max Processes:";
            // 
            // ShowModifiedSubmodulesOnlyCheck
            // 
            ShowModifiedSubmodulesOnlyCheck.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left ;
            ShowModifiedSubmodulesOnlyCheck.AutoSize = true;
            ShowModifiedSubmodulesOnlyCheck.Enabled = false;
            ShowModifiedSubmodulesOnlyCheck.Location = new System.Drawing.Point( 14, 443 );
            ShowModifiedSubmodulesOnlyCheck.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ShowModifiedSubmodulesOnlyCheck.Name = "ShowModifiedSubmodulesOnlyCheck";
            ShowModifiedSubmodulesOnlyCheck.Size = new System.Drawing.Size( 203, 19 );
            ShowModifiedSubmodulesOnlyCheck.TabIndex = 13;
            ShowModifiedSubmodulesOnlyCheck.Text = "Show Only Modified Submodules";
            ShowModifiedSubmodulesOnlyCheck.UseVisualStyleBackColor = true;
            // 
            // SubmoduleUpdateOptionsGroup
            // 
            SubmoduleUpdateOptionsGroup.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            SubmoduleUpdateOptionsGroup.Controls.Add( InitCheck );
            SubmoduleUpdateOptionsGroup.Controls.Add( RecursiveCheck );
            SubmoduleUpdateOptionsGroup.Controls.Add( MaxProcessCountLabel );
            SubmoduleUpdateOptionsGroup.Controls.Add( ForceCheck );
            SubmoduleUpdateOptionsGroup.Controls.Add( MaxProcessCountNumeric );
            SubmoduleUpdateOptionsGroup.Location = new System.Drawing.Point( 240, 377 );
            SubmoduleUpdateOptionsGroup.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            SubmoduleUpdateOptionsGroup.Name = "SubmoduleUpdateOptionsGroup";
            SubmoduleUpdateOptionsGroup.Padding = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            SubmoduleUpdateOptionsGroup.Size = new System.Drawing.Size( 287, 84 );
            SubmoduleUpdateOptionsGroup.TabIndex = 14;
            SubmoduleUpdateOptionsGroup.TabStop = false;
            SubmoduleUpdateOptionsGroup.Text = "Submodule Update Options";
            // 
            // CheckModifiedSubmodulesByDefaultCheck
            // 
            CheckModifiedSubmodulesByDefaultCheck.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left ;
            CheckModifiedSubmodulesByDefaultCheck.AutoSize = true;
            CheckModifiedSubmodulesByDefaultCheck.Location = new System.Drawing.Point( 14, 469 );
            CheckModifiedSubmodulesByDefaultCheck.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            CheckModifiedSubmodulesByDefaultCheck.Name = "CheckModifiedSubmodulesByDefaultCheck";
            CheckModifiedSubmodulesByDefaultCheck.Size = new System.Drawing.Size( 236, 19 );
            CheckModifiedSubmodulesByDefaultCheck.TabIndex = 15;
            CheckModifiedSubmodulesByDefaultCheck.Text = "Check Modified Submodules By Default";
            CheckModifiedSubmodulesByDefaultCheck.UseVisualStyleBackColor = true;
            // 
            // FastSubmoduleUpdateDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF( 7F, 15F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = Cancel;
            ClientSize = new System.Drawing.Size( 541, 509 );
            Controls.Add( CheckModifiedSubmodulesByDefaultCheck );
            Controls.Add( SubmoduleUpdateOptionsGroup );
            Controls.Add( ShowModifiedSubmodulesOnlyCheck );
            Controls.Add( SelectModifiedSubmodules );
            Controls.Add( SubmoduleCheckList );
            Controls.Add( SelectNoneSubmodules );
            Controls.Add( SelectAllSubmodules );
            Controls.Add( UpdateSubmodulesButton );
            Controls.Add( Cancel );
            Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size( 557, 1148 );
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size( 557, 340 );
            Name = "FastSubmoduleUpdateDialog";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Fast Submodule Update";
            ( (System.ComponentModel.ISupportInitialize)MaxProcessCountNumeric ).EndInit();
            SubmoduleUpdateOptionsGroup.ResumeLayout( false );
            SubmoduleUpdateOptionsGroup.PerformLayout();
            ResumeLayout( false );
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button UpdateSubmodulesButton;
        private System.Windows.Forms.Button SelectAllSubmodules;
        private System.Windows.Forms.Button SelectNoneSubmodules;
        private System.Windows.Forms.CheckedListBox SubmoduleCheckList;
        private System.Windows.Forms.CheckBox InitCheck;
        private System.Windows.Forms.CheckBox RecursiveCheck;
        private System.Windows.Forms.CheckBox ForceCheck;
        private System.Windows.Forms.Button SelectModifiedSubmodules;
        private System.Windows.Forms.NumericUpDown MaxProcessCountNumeric;
        private System.Windows.Forms.Label MaxProcessCountLabel;
        private System.Windows.Forms.CheckBox ShowModifiedSubmodulesOnlyCheck;
        private System.Windows.Forms.GroupBox SubmoduleUpdateOptionsGroup;
        private System.Windows.Forms.CheckBox CheckModifiedSubmodulesByDefaultCheck;
    }
}