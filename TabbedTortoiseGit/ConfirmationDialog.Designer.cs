
namespace TabbedTortoiseGit
{
    partial class ConfirmationDialog
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
            actionsPanel = new System.Windows.Forms.Panel();
            yesButton = new System.Windows.Forms.Button();
            noButton = new System.Windows.Forms.Button();
            doNotAskAgainCheckBox = new System.Windows.Forms.CheckBox();
            messageLabel = new System.Windows.Forms.Label();
            actionsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // actionsPanel
            // 
            actionsPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            actionsPanel.Controls.Add( yesButton );
            actionsPanel.Controls.Add( noButton );
            actionsPanel.Controls.Add( doNotAskAgainCheckBox );
            actionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            actionsPanel.Location = new System.Drawing.Point( 0, 84 );
            actionsPanel.Name = "actionsPanel";
            actionsPanel.Size = new System.Drawing.Size( 379, 47 );
            actionsPanel.TabIndex = 0;
            // 
            // yesButton
            // 
            yesButton.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            yesButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            yesButton.Location = new System.Drawing.Point( 211, 12 );
            yesButton.Name = "yesButton";
            yesButton.Size = new System.Drawing.Size( 75, 23 );
            yesButton.TabIndex = 2;
            yesButton.Text = "Yes";
            yesButton.UseVisualStyleBackColor = true;
            // 
            // noButton
            // 
            noButton.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            noButton.DialogResult = System.Windows.Forms.DialogResult.No;
            noButton.Location = new System.Drawing.Point( 292, 12 );
            noButton.Name = "noButton";
            noButton.Size = new System.Drawing.Size( 75, 23 );
            noButton.TabIndex = 1;
            noButton.Text = "No";
            noButton.UseVisualStyleBackColor = true;
            // 
            // doNotAskAgainCheckBox
            // 
            doNotAskAgainCheckBox.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left ;
            doNotAskAgainCheckBox.AutoSize = true;
            doNotAskAgainCheckBox.Location = new System.Drawing.Point( 12, 15 );
            doNotAskAgainCheckBox.Name = "doNotAskAgainCheckBox";
            doNotAskAgainCheckBox.Size = new System.Drawing.Size( 134, 19 );
            doNotAskAgainCheckBox.TabIndex = 0;
            doNotAskAgainCheckBox.Text = "Do not ask me again";
            doNotAskAgainCheckBox.UseVisualStyleBackColor = true;
            // 
            // messageLabel
            // 
            messageLabel.Location = new System.Drawing.Point( 12, 9 );
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new System.Drawing.Size( 355, 72 );
            messageLabel.TabIndex = 1;
            messageLabel.Text = "Message";
            messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConfirmationDialog
            // 
            AcceptButton = yesButton;
            AutoScaleDimensions = new System.Drawing.SizeF( 96F, 96F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            CancelButton = noButton;
            ClientSize = new System.Drawing.Size( 379, 131 );
            ControlBox = false;
            Controls.Add( messageLabel );
            Controls.Add( actionsPanel );
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConfirmationDialog";
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Title";
            actionsPanel.ResumeLayout( false );
            actionsPanel.PerformLayout();
            ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel actionsPanel;
        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.CheckBox doNotAskAgainCheckBox;
        private System.Windows.Forms.Label messageLabel;
    }
}