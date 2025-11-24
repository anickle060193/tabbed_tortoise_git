namespace TabbedTortoiseGit
{
    partial class FasterSubmoduleUpdateDialog
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
            SubmodulesGroupBox = new System.Windows.Forms.GroupBox();
            SubmodulesModifiedOnly = new System.Windows.Forms.RadioButton();
            SubmodulesAll = new System.Windows.Forms.RadioButton();
            OptionsGroupBox = new System.Windows.Forms.GroupBox();
            TreatUninitializedSubmodulesAsModifiedCheck = new System.Windows.Forms.CheckBox();
            InitCheck = new System.Windows.Forms.CheckBox();
            RecursiveCheck = new System.Windows.Forms.CheckBox();
            MaxProcessCountLabel = new System.Windows.Forms.Label();
            ForceCheck = new System.Windows.Forms.CheckBox();
            MaxProcessCountNumeric = new System.Windows.Forms.NumericUpDown();
            UpdateSubmodulesButton = new System.Windows.Forms.Button();
            Cancel = new System.Windows.Forms.Button();
            SubmodulesGroupBox.SuspendLayout();
            OptionsGroupBox.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)MaxProcessCountNumeric ).BeginInit();
            SuspendLayout();
            // 
            // SubmodulesGroupBox
            // 
            SubmodulesGroupBox.Anchor =   System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            SubmodulesGroupBox.Controls.Add( SubmodulesModifiedOnly );
            SubmodulesGroupBox.Controls.Add( SubmodulesAll );
            SubmodulesGroupBox.Location = new System.Drawing.Point( 14, 14 );
            SubmodulesGroupBox.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            SubmodulesGroupBox.Name = "SubmodulesGroupBox";
            SubmodulesGroupBox.Padding = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            SubmodulesGroupBox.Size = new System.Drawing.Size( 286, 53 );
            SubmodulesGroupBox.TabIndex = 0;
            SubmodulesGroupBox.TabStop = false;
            SubmodulesGroupBox.Text = "Submodules";
            // 
            // SubmodulesModifiedOnly
            // 
            SubmodulesModifiedOnly.AutoSize = true;
            SubmodulesModifiedOnly.Location = new System.Drawing.Point( 56, 22 );
            SubmodulesModifiedOnly.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            SubmodulesModifiedOnly.Name = "SubmodulesModifiedOnly";
            SubmodulesModifiedOnly.Size = new System.Drawing.Size( 101, 19 );
            SubmodulesModifiedOnly.TabIndex = 1;
            SubmodulesModifiedOnly.TabStop = true;
            SubmodulesModifiedOnly.Text = "Modified Only";
            SubmodulesModifiedOnly.UseVisualStyleBackColor = true;
            // 
            // SubmodulesAll
            // 
            SubmodulesAll.AutoSize = true;
            SubmodulesAll.Location = new System.Drawing.Point( 7, 22 );
            SubmodulesAll.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            SubmodulesAll.Name = "SubmodulesAll";
            SubmodulesAll.Size = new System.Drawing.Size( 39, 19 );
            SubmodulesAll.TabIndex = 0;
            SubmodulesAll.TabStop = true;
            SubmodulesAll.Text = "All";
            SubmodulesAll.UseVisualStyleBackColor = true;
            // 
            // OptionsGroupBox
            // 
            OptionsGroupBox.Anchor =    System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Bottom   |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            OptionsGroupBox.Controls.Add( TreatUninitializedSubmodulesAsModifiedCheck );
            OptionsGroupBox.Controls.Add( InitCheck );
            OptionsGroupBox.Controls.Add( RecursiveCheck );
            OptionsGroupBox.Controls.Add( MaxProcessCountLabel );
            OptionsGroupBox.Controls.Add( ForceCheck );
            OptionsGroupBox.Controls.Add( MaxProcessCountNumeric );
            OptionsGroupBox.Location = new System.Drawing.Point( 14, 74 );
            OptionsGroupBox.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            OptionsGroupBox.Name = "OptionsGroupBox";
            OptionsGroupBox.Padding = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            OptionsGroupBox.Size = new System.Drawing.Size( 286, 107 );
            OptionsGroupBox.TabIndex = 1;
            OptionsGroupBox.TabStop = false;
            OptionsGroupBox.Text = "Options";
            // 
            // TreatUninitializedSubmodulesAsModifiedCheck
            // 
            TreatUninitializedSubmodulesAsModifiedCheck.AutoSize = true;
            TreatUninitializedSubmodulesAsModifiedCheck.Location = new System.Drawing.Point( 7, 78 );
            TreatUninitializedSubmodulesAsModifiedCheck.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            TreatUninitializedSubmodulesAsModifiedCheck.Name = "TreatUninitializedSubmodulesAsModifiedCheck";
            TreatUninitializedSubmodulesAsModifiedCheck.Size = new System.Drawing.Size( 252, 19 );
            TreatUninitializedSubmodulesAsModifiedCheck.TabIndex = 18;
            TreatUninitializedSubmodulesAsModifiedCheck.Text = "Treat uninitialized submodules as modified";
            TreatUninitializedSubmodulesAsModifiedCheck.UseVisualStyleBackColor = true;
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
            InitCheck.TabIndex = 13;
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
            RecursiveCheck.TabIndex = 14;
            RecursiveCheck.Text = "--recursive";
            RecursiveCheck.UseVisualStyleBackColor = true;
            // 
            // MaxProcessCountLabel
            // 
            MaxProcessCountLabel.AutoSize = true;
            MaxProcessCountLabel.Location = new System.Drawing.Point( 7, 51 );
            MaxProcessCountLabel.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            MaxProcessCountLabel.Name = "MaxProcessCountLabel";
            MaxProcessCountLabel.Size = new System.Drawing.Size( 86, 15 );
            MaxProcessCountLabel.TabIndex = 17;
            MaxProcessCountLabel.Text = "Max Processes:";
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
            ForceCheck.TabIndex = 15;
            ForceCheck.Text = "--force";
            ForceCheck.UseVisualStyleBackColor = true;
            // 
            // MaxProcessCountNumeric
            // 
            MaxProcessCountNumeric.Location = new System.Drawing.Point( 110, 48 );
            MaxProcessCountNumeric.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            MaxProcessCountNumeric.Maximum = new decimal( new int[] { 64, 0, 0, 0 } );
            MaxProcessCountNumeric.Minimum = new decimal( new int[] { 1, 0, 0, 0 } );
            MaxProcessCountNumeric.Name = "MaxProcessCountNumeric";
            MaxProcessCountNumeric.Size = new System.Drawing.Size( 49, 23 );
            MaxProcessCountNumeric.TabIndex = 16;
            MaxProcessCountNumeric.Value = new decimal( new int[] { 1, 0, 0, 0 } );
            // 
            // UpdateSubmodulesButton
            // 
            UpdateSubmodulesButton.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            UpdateSubmodulesButton.Location = new System.Drawing.Point( 58, 188 );
            UpdateSubmodulesButton.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            UpdateSubmodulesButton.Name = "UpdateSubmodulesButton";
            UpdateSubmodulesButton.Size = new System.Drawing.Size( 147, 27 );
            UpdateSubmodulesButton.TabIndex = 2;
            UpdateSubmodulesButton.Text = "Update Submodules";
            UpdateSubmodulesButton.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            Cancel.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Cancel.Location = new System.Drawing.Point( 212, 188 );
            Cancel.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Cancel.Name = "Cancel";
            Cancel.Size = new System.Drawing.Size( 88, 27 );
            Cancel.TabIndex = 3;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            // 
            // FasterSubmoduleUpdateDialog
            // 
            AcceptButton = UpdateSubmodulesButton;
            AutoScaleDimensions = new System.Drawing.SizeF( 7F, 15F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = Cancel;
            ClientSize = new System.Drawing.Size( 314, 228 );
            Controls.Add( Cancel );
            Controls.Add( UpdateSubmodulesButton );
            Controls.Add( OptionsGroupBox );
            Controls.Add( SubmodulesGroupBox );
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FasterSubmoduleUpdateDialog";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Faster Submodule Update";
            SubmodulesGroupBox.ResumeLayout( false );
            SubmodulesGroupBox.PerformLayout();
            OptionsGroupBox.ResumeLayout( false );
            OptionsGroupBox.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)MaxProcessCountNumeric ).EndInit();
            ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.GroupBox SubmodulesGroupBox;
        private System.Windows.Forms.RadioButton SubmodulesAll;
        private System.Windows.Forms.RadioButton SubmodulesModifiedOnly;
        private System.Windows.Forms.GroupBox OptionsGroupBox;
        private System.Windows.Forms.Button UpdateSubmodulesButton;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.CheckBox InitCheck;
        private System.Windows.Forms.CheckBox RecursiveCheck;
        private System.Windows.Forms.Label MaxProcessCountLabel;
        private System.Windows.Forms.CheckBox ForceCheck;
        private System.Windows.Forms.NumericUpDown MaxProcessCountNumeric;
        private System.Windows.Forms.CheckBox TreatUninitializedSubmodulesAsModifiedCheck;
    }
}