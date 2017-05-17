namespace TabbedTortoiseGit
{
    partial class CloseConfirmationDialog
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
            this.ClosingConfirmationLabel = new System.Windows.Forms.Label();
            this.DontAskAgainCheck = new System.Windows.Forms.CheckBox();
            this.No = new System.Windows.Forms.Button();
            this.Yes = new System.Windows.Forms.Button();
            this.Background = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ClosingConfirmationLabel
            // 
            this.ClosingConfirmationLabel.AutoSize = true;
            this.ClosingConfirmationLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClosingConfirmationLabel.Location = new System.Drawing.Point(12, 12);
            this.ClosingConfirmationLabel.Name = "ClosingConfirmationLabel";
            this.ClosingConfirmationLabel.Size = new System.Drawing.Size(149, 13);
            this.ClosingConfirmationLabel.TabIndex = 0;
            this.ClosingConfirmationLabel.Text = "Are you sure you want to exit?";
            // 
            // DontAskAgainCheck
            // 
            this.DontAskAgainCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DontAskAgainCheck.AutoSize = true;
            this.DontAskAgainCheck.Location = new System.Drawing.Point(12, 69);
            this.DontAskAgainCheck.Name = "DontAskAgainCheck";
            this.DontAskAgainCheck.Size = new System.Drawing.Size(103, 17);
            this.DontAskAgainCheck.TabIndex = 1;
            this.DontAskAgainCheck.Text = "Don\'t ask again.";
            this.DontAskAgainCheck.UseVisualStyleBackColor = false;
            // 
            // No
            // 
            this.No.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.No.DialogResult = System.Windows.Forms.DialogResult.No;
            this.No.Location = new System.Drawing.Point(272, 65);
            this.No.Name = "No";
            this.No.Size = new System.Drawing.Size(75, 23);
            this.No.TabIndex = 3;
            this.No.Text = "No";
            this.No.UseVisualStyleBackColor = true;
            // 
            // Yes
            // 
            this.Yes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Yes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Yes.Location = new System.Drawing.Point(191, 65);
            this.Yes.Name = "Yes";
            this.Yes.Size = new System.Drawing.Size(75, 23);
            this.Yes.TabIndex = 4;
            this.Yes.Text = "Yes";
            this.Yes.UseVisualStyleBackColor = true;
            // 
            // Background
            // 
            this.Background.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Background.Dock = System.Windows.Forms.DockStyle.Top;
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(359, 55);
            this.Background.TabIndex = 5;
            // 
            // CloseConfirmationDialog
            // 
            this.AcceptButton = this.Yes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 100);
            this.Controls.Add(this.Yes);
            this.Controls.Add(this.No);
            this.Controls.Add(this.DontAskAgainCheck);
            this.Controls.Add(this.ClosingConfirmationLabel);
            this.Controls.Add(this.Background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CloseConfirmationDialog";
            this.Text = "Tabbed TortoiseGit";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ClosingConfirmationLabel;
        private System.Windows.Forms.CheckBox DontAskAgainCheck;
        private System.Windows.Forms.Button No;
        private System.Windows.Forms.Button Yes;
        private System.Windows.Forms.Panel Background;
    }
}