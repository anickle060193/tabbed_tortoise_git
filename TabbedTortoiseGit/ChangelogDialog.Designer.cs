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
            OkButton = new System.Windows.Forms.Button();
            ShowChangelogOnUpdateCheck = new System.Windows.Forms.CheckBox();
            ChangelogText = new System.Windows.Forms.RichTextBox();
            SuspendLayout();
            // 
            // OkButton
            // 
            OkButton.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            OkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            OkButton.Location = new System.Drawing.Point( 696, 549 );
            OkButton.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            OkButton.Name = "OkButton";
            OkButton.Size = new System.Drawing.Size( 88, 27 );
            OkButton.TabIndex = 1;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            // 
            // ShowChangelogOnUpdateCheck
            // 
            ShowChangelogOnUpdateCheck.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left ;
            ShowChangelogOnUpdateCheck.AutoSize = true;
            ShowChangelogOnUpdateCheck.Location = new System.Drawing.Point( 14, 555 );
            ShowChangelogOnUpdateCheck.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ShowChangelogOnUpdateCheck.Name = "ShowChangelogOnUpdateCheck";
            ShowChangelogOnUpdateCheck.Size = new System.Drawing.Size( 171, 19 );
            ShowChangelogOnUpdateCheck.TabIndex = 2;
            ShowChangelogOnUpdateCheck.Text = "Show changelog on update";
            ShowChangelogOnUpdateCheck.UseVisualStyleBackColor = true;
            // 
            // ChangelogText
            // 
            ChangelogText.Anchor =    System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Bottom   |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            ChangelogText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ChangelogText.Location = new System.Drawing.Point( 14, 14 );
            ChangelogText.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ChangelogText.Name = "ChangelogText";
            ChangelogText.ReadOnly = true;
            ChangelogText.Size = new System.Drawing.Size( 770, 528 );
            ChangelogText.TabIndex = 3;
            ChangelogText.Text = "";
            // 
            // ChangelogDialog
            // 
            AcceptButton = OkButton;
            AutoScaleDimensions = new System.Drawing.SizeF( 7F, 15F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = OkButton;
            ClientSize = new System.Drawing.Size( 798, 590 );
            Controls.Add( ChangelogText );
            Controls.Add( ShowChangelogOnUpdateCheck );
            Controls.Add( OkButton );
            Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size( 318, 196 );
            Name = "ChangelogDialog";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Changelog";
            ResumeLayout( false );
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.CheckBox ShowChangelogOnUpdateCheck;
        private System.Windows.Forms.RichTextBox ChangelogText;
    }
}