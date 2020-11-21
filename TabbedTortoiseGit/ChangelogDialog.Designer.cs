namespace TabbedTortoiseGit
{
    partial class ChangelogDialog
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
            this.OkButton = new System.Windows.Forms.Button();
            this.ShowChangelogOnUpdateCheck = new System.Windows.Forms.CheckBox();
            this.ChangelogText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OkButton.Location = new System.Drawing.Point(696, 549);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(88, 27);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // ShowChangelogOnUpdateCheck
            // 
            this.ShowChangelogOnUpdateCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowChangelogOnUpdateCheck.AutoSize = true;
            this.ShowChangelogOnUpdateCheck.Location = new System.Drawing.Point(14, 555);
            this.ShowChangelogOnUpdateCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ShowChangelogOnUpdateCheck.Name = "ShowChangelogOnUpdateCheck";
            this.ShowChangelogOnUpdateCheck.Size = new System.Drawing.Size(171, 19);
            this.ShowChangelogOnUpdateCheck.TabIndex = 2;
            this.ShowChangelogOnUpdateCheck.Text = "Show changelog on update";
            this.ShowChangelogOnUpdateCheck.UseVisualStyleBackColor = true;
            // 
            // ChangelogText
            // 
            this.ChangelogText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangelogText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChangelogText.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChangelogText.Location = new System.Drawing.Point(14, 14);
            this.ChangelogText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ChangelogText.Name = "ChangelogText";
            this.ChangelogText.ReadOnly = true;
            this.ChangelogText.Size = new System.Drawing.Size(770, 528);
            this.ChangelogText.TabIndex = 3;
            this.ChangelogText.Text = "";
            // 
            // ChangelogDialog
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.OkButton;
            this.ClientSize = new System.Drawing.Size(798, 590);
            this.Controls.Add(this.ChangelogText);
            this.Controls.Add(this.ShowChangelogOnUpdateCheck);
            this.Controls.Add(this.OkButton);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(318, 196);
            this.Name = "ChangelogDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Changelog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.CheckBox ShowChangelogOnUpdateCheck;
        private System.Windows.Forms.RichTextBox ChangelogText;
    }
}