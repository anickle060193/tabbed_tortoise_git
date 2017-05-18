namespace TabbedTortoiseGit
{
    partial class FastSubmoduleUpdateForm
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
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.Location = new System.Drawing.Point(307, 301);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // UpdateSubmodulesButton
            // 
            this.UpdateSubmodulesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateSubmodulesButton.Location = new System.Drawing.Point(187, 301);
            this.UpdateSubmodulesButton.Name = "UpdateSubmodulesButton";
            this.UpdateSubmodulesButton.Size = new System.Drawing.Size(114, 23);
            this.UpdateSubmodulesButton.TabIndex = 2;
            this.UpdateSubmodulesButton.Text = "Update Submodules";
            this.UpdateSubmodulesButton.UseVisualStyleBackColor = true;
            // 
            // SelectAllSubmodules
            // 
            this.SelectAllSubmodules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectAllSubmodules.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SelectAllSubmodules.Location = new System.Drawing.Point(93, 301);
            this.SelectAllSubmodules.Name = "SelectAllSubmodules";
            this.SelectAllSubmodules.Size = new System.Drawing.Size(75, 23);
            this.SelectAllSubmodules.TabIndex = 4;
            this.SelectAllSubmodules.Text = "Select All";
            this.SelectAllSubmodules.UseVisualStyleBackColor = true;
            // 
            // SelectNoneSubmodules
            // 
            this.SelectNoneSubmodules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectNoneSubmodules.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SelectNoneSubmodules.Location = new System.Drawing.Point(12, 301);
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
            this.SubmoduleCheckList.Size = new System.Drawing.Size(370, 283);
            this.SubmoduleCheckList.TabIndex = 6;
            // 
            // FastSubmoduleUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(394, 336);
            this.Controls.Add(this.SubmoduleCheckList);
            this.Controls.Add(this.SelectNoneSubmodules);
            this.Controls.Add(this.SelectAllSubmodules);
            this.Controls.Add(this.UpdateSubmodulesButton);
            this.Controls.Add(this.Cancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 200);
            this.Name = "FastSubmoduleUpdateForm";
            this.ShowInTaskbar = false;
            this.Text = "Fast Submodule Update";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button UpdateSubmodulesButton;
        private System.Windows.Forms.Button SelectAllSubmodules;
        private System.Windows.Forms.Button SelectNoneSubmodules;
        private System.Windows.Forms.CheckedListBox SubmoduleCheckList;
    }
}