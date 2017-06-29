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
            this.Cancel = new System.Windows.Forms.Button();
            this.UpdateSubmodulesButton = new System.Windows.Forms.Button();
            this.SelectAllSubmodules = new System.Windows.Forms.Button();
            this.SelectNoneSubmodules = new System.Windows.Forms.Button();
            this.SubmoduleCheckList = new System.Windows.Forms.CheckedListBox();
            this.InitCheck = new System.Windows.Forms.CheckBox();
            this.RecursiveCheck = new System.Windows.Forms.CheckBox();
            this.ForceCheck = new System.Windows.Forms.CheckBox();
            this.SelectModifiedSubmodules = new System.Windows.Forms.Button();
            this.MaxProcessCountNumeric = new System.Windows.Forms.NumericUpDown();
            this.MaxProcessCountLabel = new System.Windows.Forms.Label();
            this.ShowModifiedSubmodulesOnlyCheck = new System.Windows.Forms.CheckBox();
            this.SubmoduleUpdateOptionsGroup = new System.Windows.Forms.GroupBox();
            this.CheckModifiedSubmodulesByDefaultCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.MaxProcessCountNumeric)).BeginInit();
            this.SubmoduleUpdateOptionsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(377, 406);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // UpdateSubmodulesButton
            // 
            this.UpdateSubmodulesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateSubmodulesButton.Enabled = false;
            this.UpdateSubmodulesButton.Location = new System.Drawing.Point(257, 406);
            this.UpdateSubmodulesButton.Name = "UpdateSubmodulesButton";
            this.UpdateSubmodulesButton.Size = new System.Drawing.Size(114, 23);
            this.UpdateSubmodulesButton.TabIndex = 2;
            this.UpdateSubmodulesButton.Text = "Update Submodules";
            this.UpdateSubmodulesButton.UseVisualStyleBackColor = true;
            // 
            // SelectAllSubmodules
            // 
            this.SelectAllSubmodules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectAllSubmodules.Location = new System.Drawing.Point(12, 327);
            this.SelectAllSubmodules.Name = "SelectAllSubmodules";
            this.SelectAllSubmodules.Size = new System.Drawing.Size(75, 23);
            this.SelectAllSubmodules.TabIndex = 4;
            this.SelectAllSubmodules.Text = "Select All";
            this.SelectAllSubmodules.UseVisualStyleBackColor = true;
            // 
            // SelectNoneSubmodules
            // 
            this.SelectNoneSubmodules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectNoneSubmodules.Location = new System.Drawing.Point(93, 327);
            this.SelectNoneSubmodules.Name = "SelectNoneSubmodules";
            this.SelectNoneSubmodules.Size = new System.Drawing.Size(75, 23);
            this.SelectNoneSubmodules.TabIndex = 5;
            this.SelectNoneSubmodules.Text = "Select None";
            this.SelectNoneSubmodules.UseVisualStyleBackColor = true;
            // 
            // SubmoduleCheckList
            // 
            this.SubmoduleCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmoduleCheckList.CheckOnClick = true;
            this.SubmoduleCheckList.FormattingEnabled = true;
            this.SubmoduleCheckList.IntegralHeight = false;
            this.SubmoduleCheckList.Location = new System.Drawing.Point(12, 12);
            this.SubmoduleCheckList.Name = "SubmoduleCheckList";
            this.SubmoduleCheckList.Size = new System.Drawing.Size(440, 309);
            this.SubmoduleCheckList.TabIndex = 6;
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
            this.InitCheck.TabIndex = 7;
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
            this.RecursiveCheck.TabIndex = 8;
            this.RecursiveCheck.Text = "--recursive";
            this.RecursiveCheck.UseVisualStyleBackColor = true;
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
            this.ForceCheck.TabIndex = 9;
            this.ForceCheck.Text = "--force";
            this.ForceCheck.UseVisualStyleBackColor = true;
            // 
            // SelectModifiedSubmodules
            // 
            this.SelectModifiedSubmodules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectModifiedSubmodules.Enabled = false;
            this.SelectModifiedSubmodules.Location = new System.Drawing.Point(12, 354);
            this.SelectModifiedSubmodules.Name = "SelectModifiedSubmodules";
            this.SelectModifiedSubmodules.Size = new System.Drawing.Size(156, 23);
            this.SelectModifiedSubmodules.TabIndex = 10;
            this.SelectModifiedSubmodules.Text = "Getting submodule status...";
            this.SelectModifiedSubmodules.UseVisualStyleBackColor = true;
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
            this.MaxProcessCountNumeric.TabIndex = 11;
            this.MaxProcessCountNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MaxProcessCountLabel
            // 
            this.MaxProcessCountLabel.AutoSize = true;
            this.MaxProcessCountLabel.Location = new System.Drawing.Point(6, 44);
            this.MaxProcessCountLabel.Name = "MaxProcessCountLabel";
            this.MaxProcessCountLabel.Size = new System.Drawing.Size(82, 13);
            this.MaxProcessCountLabel.TabIndex = 12;
            this.MaxProcessCountLabel.Text = "Max Processes:";
            // 
            // ShowModifiedSubmodulesOnlyCheck
            // 
            this.ShowModifiedSubmodulesOnlyCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowModifiedSubmodulesOnlyCheck.AutoSize = true;
            this.ShowModifiedSubmodulesOnlyCheck.Enabled = false;
            this.ShowModifiedSubmodulesOnlyCheck.Location = new System.Drawing.Point(12, 383);
            this.ShowModifiedSubmodulesOnlyCheck.Name = "ShowModifiedSubmodulesOnlyCheck";
            this.ShowModifiedSubmodulesOnlyCheck.Size = new System.Drawing.Size(181, 17);
            this.ShowModifiedSubmodulesOnlyCheck.TabIndex = 13;
            this.ShowModifiedSubmodulesOnlyCheck.Text = "Show Only Modified Submodules";
            this.ShowModifiedSubmodulesOnlyCheck.UseVisualStyleBackColor = true;
            // 
            // SubmoduleUpdateOptionsGroup
            // 
            this.SubmoduleUpdateOptionsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmoduleUpdateOptionsGroup.Controls.Add(this.InitCheck);
            this.SubmoduleUpdateOptionsGroup.Controls.Add(this.RecursiveCheck);
            this.SubmoduleUpdateOptionsGroup.Controls.Add(this.MaxProcessCountLabel);
            this.SubmoduleUpdateOptionsGroup.Controls.Add(this.ForceCheck);
            this.SubmoduleUpdateOptionsGroup.Controls.Add(this.MaxProcessCountNumeric);
            this.SubmoduleUpdateOptionsGroup.Location = new System.Drawing.Point(206, 327);
            this.SubmoduleUpdateOptionsGroup.Name = "SubmoduleUpdateOptionsGroup";
            this.SubmoduleUpdateOptionsGroup.Size = new System.Drawing.Size(246, 73);
            this.SubmoduleUpdateOptionsGroup.TabIndex = 14;
            this.SubmoduleUpdateOptionsGroup.TabStop = false;
            this.SubmoduleUpdateOptionsGroup.Text = "Submodule Update Options";
            // 
            // CheckModifiedSubmodulesByDefaultCheck
            // 
            this.CheckModifiedSubmodulesByDefaultCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckModifiedSubmodulesByDefaultCheck.AutoSize = true;
            this.CheckModifiedSubmodulesByDefaultCheck.Location = new System.Drawing.Point(12, 406);
            this.CheckModifiedSubmodulesByDefaultCheck.Name = "CheckModifiedSubmodulesByDefaultCheck";
            this.CheckModifiedSubmodulesByDefaultCheck.Size = new System.Drawing.Size(213, 17);
            this.CheckModifiedSubmodulesByDefaultCheck.TabIndex = 15;
            this.CheckModifiedSubmodulesByDefaultCheck.Text = "Check Modified Submodules By Default";
            this.CheckModifiedSubmodulesByDefaultCheck.UseVisualStyleBackColor = true;
            // 
            // FastSubmoduleUpdateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(464, 441);
            this.Controls.Add(this.CheckModifiedSubmodulesByDefaultCheck);
            this.Controls.Add(this.SubmoduleUpdateOptionsGroup);
            this.Controls.Add(this.ShowModifiedSubmodulesOnlyCheck);
            this.Controls.Add(this.SelectModifiedSubmodules);
            this.Controls.Add(this.SubmoduleCheckList);
            this.Controls.Add(this.SelectNoneSubmodules);
            this.Controls.Add(this.SelectAllSubmodules);
            this.Controls.Add(this.UpdateSubmodulesButton);
            this.Controls.Add(this.Cancel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(480, 1000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 300);
            this.Name = "FastSubmoduleUpdateDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fast Submodule Update";
            ((System.ComponentModel.ISupportInitialize)(this.MaxProcessCountNumeric)).EndInit();
            this.SubmoduleUpdateOptionsGroup.ResumeLayout(false);
            this.SubmoduleUpdateOptionsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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