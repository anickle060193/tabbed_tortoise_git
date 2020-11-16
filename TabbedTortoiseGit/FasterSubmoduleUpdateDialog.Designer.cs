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
            this.SubmodulesGroupBox = new System.Windows.Forms.GroupBox();
            this.SubmodulesModifiedOnly = new System.Windows.Forms.RadioButton();
            this.SubmodulesAll = new System.Windows.Forms.RadioButton();
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.InitCheck = new System.Windows.Forms.CheckBox();
            this.RecursiveCheck = new System.Windows.Forms.CheckBox();
            this.MaxProcessCountLabel = new System.Windows.Forms.Label();
            this.ForceCheck = new System.Windows.Forms.CheckBox();
            this.MaxProcessCountNumeric = new System.Windows.Forms.NumericUpDown();
            this.UpdateSubmodulesButton = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.TreatUninitializedSubmodulesAsModifiedCheck = new System.Windows.Forms.CheckBox();
            this.SubmodulesGroupBox.SuspendLayout();
            this.OptionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxProcessCountNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // SubmodulesGroupBox
            // 
            this.SubmodulesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmodulesGroupBox.Controls.Add(this.SubmodulesModifiedOnly);
            this.SubmodulesGroupBox.Controls.Add(this.SubmodulesAll);
            this.SubmodulesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.SubmodulesGroupBox.Name = "SubmodulesGroupBox";
            this.SubmodulesGroupBox.Size = new System.Drawing.Size(245, 46);
            this.SubmodulesGroupBox.TabIndex = 0;
            this.SubmodulesGroupBox.TabStop = false;
            this.SubmodulesGroupBox.Text = "Submodules";
            // 
            // SubmodulesModifiedOnly
            // 
            this.SubmodulesModifiedOnly.AutoSize = true;
            this.SubmodulesModifiedOnly.Location = new System.Drawing.Point(48, 19);
            this.SubmodulesModifiedOnly.Name = "SubmodulesModifiedOnly";
            this.SubmodulesModifiedOnly.Size = new System.Drawing.Size(89, 17);
            this.SubmodulesModifiedOnly.TabIndex = 1;
            this.SubmodulesModifiedOnly.TabStop = true;
            this.SubmodulesModifiedOnly.Text = "Modified Only";
            this.SubmodulesModifiedOnly.UseVisualStyleBackColor = true;
            // 
            // SubmodulesAll
            // 
            this.SubmodulesAll.AutoSize = true;
            this.SubmodulesAll.Location = new System.Drawing.Point(6, 19);
            this.SubmodulesAll.Name = "SubmodulesAll";
            this.SubmodulesAll.Size = new System.Drawing.Size(36, 17);
            this.SubmodulesAll.TabIndex = 0;
            this.SubmodulesAll.TabStop = true;
            this.SubmodulesAll.Text = "All";
            this.SubmodulesAll.UseVisualStyleBackColor = true;
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsGroupBox.Controls.Add(this.TreatUninitializedSubmodulesAsModifiedCheck);
            this.OptionsGroupBox.Controls.Add(this.InitCheck);
            this.OptionsGroupBox.Controls.Add(this.RecursiveCheck);
            this.OptionsGroupBox.Controls.Add(this.MaxProcessCountLabel);
            this.OptionsGroupBox.Controls.Add(this.ForceCheck);
            this.OptionsGroupBox.Controls.Add(this.MaxProcessCountNumeric);
            this.OptionsGroupBox.Location = new System.Drawing.Point(12, 64);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Size = new System.Drawing.Size(245, 93);
            this.OptionsGroupBox.TabIndex = 1;
            this.OptionsGroupBox.TabStop = false;
            this.OptionsGroupBox.Text = "Options";
            // 
            // InitCheck
            // 
            this.InitCheck.AutoSize = true;
            this.InitCheck.Checked = true;
            this.InitCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.InitCheck.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InitCheck.Location = new System.Drawing.Point(6, 19);
            this.InitCheck.Name = "InitCheck";
            this.InitCheck.Size = new System.Drawing.Size(62, 17);
            this.InitCheck.TabIndex = 13;
            this.InitCheck.Text = "--init";
            this.InitCheck.UseVisualStyleBackColor = true;
            // 
            // RecursiveCheck
            // 
            this.RecursiveCheck.AutoSize = true;
            this.RecursiveCheck.Checked = true;
            this.RecursiveCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RecursiveCheck.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecursiveCheck.Location = new System.Drawing.Point(74, 19);
            this.RecursiveCheck.Name = "RecursiveCheck";
            this.RecursiveCheck.Size = new System.Drawing.Size(92, 17);
            this.RecursiveCheck.TabIndex = 14;
            this.RecursiveCheck.Text = "--recursive";
            this.RecursiveCheck.UseVisualStyleBackColor = true;
            // 
            // MaxProcessCountLabel
            // 
            this.MaxProcessCountLabel.AutoSize = true;
            this.MaxProcessCountLabel.Location = new System.Drawing.Point(6, 44);
            this.MaxProcessCountLabel.Name = "MaxProcessCountLabel";
            this.MaxProcessCountLabel.Size = new System.Drawing.Size(82, 13);
            this.MaxProcessCountLabel.TabIndex = 17;
            this.MaxProcessCountLabel.Text = "Max Processes:";
            // 
            // ForceCheck
            // 
            this.ForceCheck.AutoSize = true;
            this.ForceCheck.Checked = true;
            this.ForceCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ForceCheck.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForceCheck.Location = new System.Drawing.Point(172, 19);
            this.ForceCheck.Name = "ForceCheck";
            this.ForceCheck.Size = new System.Drawing.Size(68, 17);
            this.ForceCheck.TabIndex = 15;
            this.ForceCheck.Text = "--force";
            this.ForceCheck.UseVisualStyleBackColor = true;
            // 
            // MaxProcessCountNumeric
            // 
            this.MaxProcessCountNumeric.Location = new System.Drawing.Point(94, 42);
            this.MaxProcessCountNumeric.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.MaxProcessCountNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxProcessCountNumeric.Name = "MaxProcessCountNumeric";
            this.MaxProcessCountNumeric.Size = new System.Drawing.Size(42, 20);
            this.MaxProcessCountNumeric.TabIndex = 16;
            this.MaxProcessCountNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // UpdateSubmodulesButton
            // 
            this.UpdateSubmodulesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateSubmodulesButton.Location = new System.Drawing.Point(50, 163);
            this.UpdateSubmodulesButton.Name = "UpdateSubmodulesButton";
            this.UpdateSubmodulesButton.Size = new System.Drawing.Size(126, 23);
            this.UpdateSubmodulesButton.TabIndex = 2;
            this.UpdateSubmodulesButton.Text = "Update Submodules";
            this.UpdateSubmodulesButton.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(182, 163);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // TreatUninitializedSubmodulesAsModifiedCheck
            // 
            this.TreatUninitializedSubmodulesAsModifiedCheck.AutoSize = true;
            this.TreatUninitializedSubmodulesAsModifiedCheck.Location = new System.Drawing.Point(6, 68);
            this.TreatUninitializedSubmodulesAsModifiedCheck.Name = "TreatUninitializedSubmodulesAsModifiedCheck";
            this.TreatUninitializedSubmodulesAsModifiedCheck.Size = new System.Drawing.Size(223, 17);
            this.TreatUninitializedSubmodulesAsModifiedCheck.TabIndex = 18;
            this.TreatUninitializedSubmodulesAsModifiedCheck.Text = "Treat uninitialized submodules as modified";
            this.TreatUninitializedSubmodulesAsModifiedCheck.UseVisualStyleBackColor = true;
            // 
            // FasterSubmoduleUpdateDialog
            // 
            this.AcceptButton = this.UpdateSubmodulesButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(269, 198);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.UpdateSubmodulesButton);
            this.Controls.Add(this.OptionsGroupBox);
            this.Controls.Add(this.SubmodulesGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FasterSubmoduleUpdateDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faster Submodule Update";
            this.SubmodulesGroupBox.ResumeLayout(false);
            this.SubmodulesGroupBox.PerformLayout();
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxProcessCountNumeric)).EndInit();
            this.ResumeLayout(false);

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