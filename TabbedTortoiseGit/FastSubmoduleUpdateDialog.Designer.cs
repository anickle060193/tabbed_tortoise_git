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
            this.Cancel.Location = new System.Drawing.Point(440, 468);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(88, 27);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // UpdateSubmodulesButton
            // 
            this.UpdateSubmodulesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateSubmodulesButton.Enabled = false;
            this.UpdateSubmodulesButton.Location = new System.Drawing.Point(300, 468);
            this.UpdateSubmodulesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.UpdateSubmodulesButton.Name = "UpdateSubmodulesButton";
            this.UpdateSubmodulesButton.Size = new System.Drawing.Size(133, 27);
            this.UpdateSubmodulesButton.TabIndex = 2;
            this.UpdateSubmodulesButton.Text = "Update Submodules";
            this.UpdateSubmodulesButton.UseVisualStyleBackColor = true;
            // 
            // SelectAllSubmodules
            // 
            this.SelectAllSubmodules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectAllSubmodules.Location = new System.Drawing.Point(14, 377);
            this.SelectAllSubmodules.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SelectAllSubmodules.Name = "SelectAllSubmodules";
            this.SelectAllSubmodules.Size = new System.Drawing.Size(88, 27);
            this.SelectAllSubmodules.TabIndex = 4;
            this.SelectAllSubmodules.Text = "Select All";
            this.SelectAllSubmodules.UseVisualStyleBackColor = true;
            // 
            // SelectNoneSubmodules
            // 
            this.SelectNoneSubmodules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectNoneSubmodules.Location = new System.Drawing.Point(108, 377);
            this.SelectNoneSubmodules.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SelectNoneSubmodules.Name = "SelectNoneSubmodules";
            this.SelectNoneSubmodules.Size = new System.Drawing.Size(88, 27);
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
            this.SubmoduleCheckList.Location = new System.Drawing.Point(14, 14);
            this.SubmoduleCheckList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SubmoduleCheckList.Name = "SubmoduleCheckList";
            this.SubmoduleCheckList.Size = new System.Drawing.Size(513, 356);
            this.SubmoduleCheckList.TabIndex = 6;
            // 
            // InitCheck
            // 
            this.InitCheck.AutoSize = true;
            this.InitCheck.Checked = true;
            this.InitCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.InitCheck.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InitCheck.Location = new System.Drawing.Point(7, 22);
            this.InitCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
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
            this.RecursiveCheck.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RecursiveCheck.Location = new System.Drawing.Point(86, 22);
            this.RecursiveCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
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
            this.ForceCheck.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForceCheck.Location = new System.Drawing.Point(201, 22);
            this.ForceCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
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
            this.SelectModifiedSubmodules.Location = new System.Drawing.Point(14, 408);
            this.SelectModifiedSubmodules.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SelectModifiedSubmodules.Name = "SelectModifiedSubmodules";
            this.SelectModifiedSubmodules.Size = new System.Drawing.Size(182, 27);
            this.SelectModifiedSubmodules.TabIndex = 10;
            this.SelectModifiedSubmodules.Text = "Getting submodule status...";
            this.SelectModifiedSubmodules.UseVisualStyleBackColor = true;
            // 
            // MaxProcessCountNumeric
            // 
            this.MaxProcessCountNumeric.Location = new System.Drawing.Point(110, 48);
            this.MaxProcessCountNumeric.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaxProcessCountNumeric.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.MaxProcessCountNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxProcessCountNumeric.Name = "MaxProcessCountNumeric";
            this.MaxProcessCountNumeric.Size = new System.Drawing.Size(49, 23);
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
            this.MaxProcessCountLabel.Location = new System.Drawing.Point(7, 51);
            this.MaxProcessCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxProcessCountLabel.Name = "MaxProcessCountLabel";
            this.MaxProcessCountLabel.Size = new System.Drawing.Size(87, 15);
            this.MaxProcessCountLabel.TabIndex = 12;
            this.MaxProcessCountLabel.Text = "Max Processes:";
            // 
            // ShowModifiedSubmodulesOnlyCheck
            // 
            this.ShowModifiedSubmodulesOnlyCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowModifiedSubmodulesOnlyCheck.AutoSize = true;
            this.ShowModifiedSubmodulesOnlyCheck.Enabled = false;
            this.ShowModifiedSubmodulesOnlyCheck.Location = new System.Drawing.Point(14, 443);
            this.ShowModifiedSubmodulesOnlyCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ShowModifiedSubmodulesOnlyCheck.Name = "ShowModifiedSubmodulesOnlyCheck";
            this.ShowModifiedSubmodulesOnlyCheck.Size = new System.Drawing.Size(203, 19);
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
            this.SubmoduleUpdateOptionsGroup.Location = new System.Drawing.Point(240, 377);
            this.SubmoduleUpdateOptionsGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SubmoduleUpdateOptionsGroup.Name = "SubmoduleUpdateOptionsGroup";
            this.SubmoduleUpdateOptionsGroup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SubmoduleUpdateOptionsGroup.Size = new System.Drawing.Size(287, 84);
            this.SubmoduleUpdateOptionsGroup.TabIndex = 14;
            this.SubmoduleUpdateOptionsGroup.TabStop = false;
            this.SubmoduleUpdateOptionsGroup.Text = "Submodule Update Options";
            // 
            // CheckModifiedSubmodulesByDefaultCheck
            // 
            this.CheckModifiedSubmodulesByDefaultCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckModifiedSubmodulesByDefaultCheck.AutoSize = true;
            this.CheckModifiedSubmodulesByDefaultCheck.Location = new System.Drawing.Point(14, 469);
            this.CheckModifiedSubmodulesByDefaultCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CheckModifiedSubmodulesByDefaultCheck.Name = "CheckModifiedSubmodulesByDefaultCheck";
            this.CheckModifiedSubmodulesByDefaultCheck.Size = new System.Drawing.Size(236, 19);
            this.CheckModifiedSubmodulesByDefaultCheck.TabIndex = 15;
            this.CheckModifiedSubmodulesByDefaultCheck.Text = "Check Modified Submodules By Default";
            this.CheckModifiedSubmodulesByDefaultCheck.UseVisualStyleBackColor = true;
            // 
            // FastSubmoduleUpdateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(541, 509);
            this.Controls.Add(this.CheckModifiedSubmodulesByDefaultCheck);
            this.Controls.Add(this.SubmoduleUpdateOptionsGroup);
            this.Controls.Add(this.ShowModifiedSubmodulesOnlyCheck);
            this.Controls.Add(this.SelectModifiedSubmodules);
            this.Controls.Add(this.SubmoduleCheckList);
            this.Controls.Add(this.SelectNoneSubmodules);
            this.Controls.Add(this.SelectAllSubmodules);
            this.Controls.Add(this.UpdateSubmodulesButton);
            this.Controls.Add(this.Cancel);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(557, 1148);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(557, 340);
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