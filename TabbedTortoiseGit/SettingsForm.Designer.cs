using System.Windows.Forms;

namespace TabbedTortoiseGit
{
    partial class SettingsForm
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
            this.DefaultReposList = new System.Windows.Forms.ListBox();
            this.AddDefaultRepo = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.RemoveDefaultRepo = new System.Windows.Forms.Button();
            this.DefaultReposGroup = new System.Windows.Forms.GroupBox();
            this.DefaultReposNote = new System.Windows.Forms.Label();
            this.RetainLogsOnCloseCheck = new System.Windows.Forms.CheckBox();
            this.OtherSettingsGroup = new System.Windows.Forms.GroupBox();
            this.ConfirmOnCloseCheck = new System.Windows.Forms.CheckBox();
            this.MaxRecentReposNumeric = new System.Windows.Forms.NumericUpDown();
            this.MaxRecentReposLabel = new System.Windows.Forms.Label();
            this.TabContextMenuGitActionsGroup = new System.Windows.Forms.GroupBox();
            this.GitActionsCheckList = new System.Windows.Forms.CheckedListBox();
            this.GitActionsLabel = new System.Windows.Forms.Label();
            this.DefaultReposGroup.SuspendLayout();
            this.OtherSettingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxRecentReposNumeric)).BeginInit();
            this.TabContextMenuGitActionsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // DefaultReposList
            // 
            this.DefaultReposList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DefaultReposList.FormattingEnabled = true;
            this.DefaultReposList.IntegralHeight = false;
            this.DefaultReposList.Location = new System.Drawing.Point(6, 19);
            this.DefaultReposList.Name = "DefaultReposList";
            this.DefaultReposList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.DefaultReposList.Size = new System.Drawing.Size(368, 99);
            this.DefaultReposList.TabIndex = 1;
            // 
            // AddDefaultRepo
            // 
            this.AddDefaultRepo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddDefaultRepo.Location = new System.Drawing.Point(97, 124);
            this.AddDefaultRepo.Name = "AddDefaultRepo";
            this.AddDefaultRepo.Size = new System.Drawing.Size(85, 23);
            this.AddDefaultRepo.TabIndex = 2;
            this.AddDefaultRepo.Text = "Add Repo";
            this.AddDefaultRepo.UseVisualStyleBackColor = true;
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(236, 479);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 3;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(317, 479);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // RemoveDefaultRepo
            // 
            this.RemoveDefaultRepo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveDefaultRepo.Location = new System.Drawing.Point(6, 124);
            this.RemoveDefaultRepo.Name = "RemoveDefaultRepo";
            this.RemoveDefaultRepo.Size = new System.Drawing.Size(85, 23);
            this.RemoveDefaultRepo.TabIndex = 5;
            this.RemoveDefaultRepo.Text = "Remove Repo";
            this.RemoveDefaultRepo.UseVisualStyleBackColor = true;
            // 
            // DefaultReposGroup
            // 
            this.DefaultReposGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DefaultReposGroup.Controls.Add(this.DefaultReposNote);
            this.DefaultReposGroup.Controls.Add(this.DefaultReposList);
            this.DefaultReposGroup.Controls.Add(this.RemoveDefaultRepo);
            this.DefaultReposGroup.Controls.Add(this.AddDefaultRepo);
            this.DefaultReposGroup.Location = new System.Drawing.Point(12, 12);
            this.DefaultReposGroup.Name = "DefaultReposGroup";
            this.DefaultReposGroup.Size = new System.Drawing.Size(380, 169);
            this.DefaultReposGroup.TabIndex = 6;
            this.DefaultReposGroup.TabStop = false;
            this.DefaultReposGroup.Text = "Default Repos";
            // 
            // DefaultReposNote
            // 
            this.DefaultReposNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DefaultReposNote.AutoSize = true;
            this.DefaultReposNote.Location = new System.Drawing.Point(6, 150);
            this.DefaultReposNote.Name = "DefaultReposNote";
            this.DefaultReposNote.Size = new System.Drawing.Size(364, 13);
            this.DefaultReposNote.TabIndex = 6;
            this.DefaultReposNote.Text = "Note: Default repos are opened when Tabbed TortoiseGit is initially opened.";
            // 
            // RetainLogsOnCloseCheck
            // 
            this.RetainLogsOnCloseCheck.AutoSize = true;
            this.RetainLogsOnCloseCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RetainLogsOnCloseCheck.Location = new System.Drawing.Point(6, 19);
            this.RetainLogsOnCloseCheck.Name = "RetainLogsOnCloseCheck";
            this.RetainLogsOnCloseCheck.Size = new System.Drawing.Size(130, 17);
            this.RetainLogsOnCloseCheck.TabIndex = 7;
            this.RetainLogsOnCloseCheck.Text = "Retain Logs on Close:";
            this.RetainLogsOnCloseCheck.UseVisualStyleBackColor = true;
            // 
            // OtherSettingsGroup
            // 
            this.OtherSettingsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OtherSettingsGroup.Controls.Add(this.ConfirmOnCloseCheck);
            this.OtherSettingsGroup.Controls.Add(this.MaxRecentReposNumeric);
            this.OtherSettingsGroup.Controls.Add(this.MaxRecentReposLabel);
            this.OtherSettingsGroup.Controls.Add(this.RetainLogsOnCloseCheck);
            this.OtherSettingsGroup.Location = new System.Drawing.Point(12, 187);
            this.OtherSettingsGroup.Name = "OtherSettingsGroup";
            this.OtherSettingsGroup.Size = new System.Drawing.Size(380, 95);
            this.OtherSettingsGroup.TabIndex = 8;
            this.OtherSettingsGroup.TabStop = false;
            this.OtherSettingsGroup.Text = "Other Settings";
            // 
            // ConfirmOnCloseCheck
            // 
            this.ConfirmOnCloseCheck.AutoSize = true;
            this.ConfirmOnCloseCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ConfirmOnCloseCheck.Location = new System.Drawing.Point(6, 68);
            this.ConfirmOnCloseCheck.Name = "ConfirmOnCloseCheck";
            this.ConfirmOnCloseCheck.Size = new System.Drawing.Size(133, 17);
            this.ConfirmOnCloseCheck.TabIndex = 10;
            this.ConfirmOnCloseCheck.Text = "Prompt Before Closing:";
            this.ConfirmOnCloseCheck.UseVisualStyleBackColor = true;
            // 
            // MaxRecentReposNumeric
            // 
            this.MaxRecentReposNumeric.Location = new System.Drawing.Point(115, 42);
            this.MaxRecentReposNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxRecentReposNumeric.Name = "MaxRecentReposNumeric";
            this.MaxRecentReposNumeric.Size = new System.Drawing.Size(44, 20);
            this.MaxRecentReposNumeric.TabIndex = 9;
            this.MaxRecentReposNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MaxRecentReposLabel
            // 
            this.MaxRecentReposLabel.AutoSize = true;
            this.MaxRecentReposLabel.Location = new System.Drawing.Point(7, 44);
            this.MaxRecentReposLabel.Name = "MaxRecentReposLabel";
            this.MaxRecentReposLabel.Size = new System.Drawing.Size(102, 13);
            this.MaxRecentReposLabel.TabIndex = 8;
            this.MaxRecentReposLabel.Text = "Max Recent Repos:";
            // 
            // TabContextMenuGitActionsGroup
            // 
            this.TabContextMenuGitActionsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabContextMenuGitActionsGroup.Controls.Add(this.GitActionsLabel);
            this.TabContextMenuGitActionsGroup.Controls.Add(this.GitActionsCheckList);
            this.TabContextMenuGitActionsGroup.Location = new System.Drawing.Point(12, 288);
            this.TabContextMenuGitActionsGroup.Name = "TabContextMenuGitActionsGroup";
            this.TabContextMenuGitActionsGroup.Size = new System.Drawing.Size(380, 182);
            this.TabContextMenuGitActionsGroup.TabIndex = 11;
            this.TabContextMenuGitActionsGroup.TabStop = false;
            this.TabContextMenuGitActionsGroup.Text = "Tab Context Menu Git Actions";
            // 
            // GitActionsCheckList
            // 
            this.GitActionsCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GitActionsCheckList.CheckOnClick = true;
            this.GitActionsCheckList.FormattingEnabled = true;
            this.GitActionsCheckList.IntegralHeight = false;
            this.GitActionsCheckList.Location = new System.Drawing.Point(6, 19);
            this.GitActionsCheckList.Name = "GitActionsCheckList";
            this.GitActionsCheckList.Size = new System.Drawing.Size(368, 144);
            this.GitActionsCheckList.TabIndex = 0;
            // 
            // GitActionsLabel
            // 
            this.GitActionsLabel.AutoSize = true;
            this.GitActionsLabel.Location = new System.Drawing.Point(7, 166);
            this.GitActionsLabel.Name = "GitActionsLabel";
            this.GitActionsLabel.Size = new System.Drawing.Size(279, 13);
            this.GitActionsLabel.TabIndex = 1;
            this.GitActionsLabel.Text = "Note: Drag and drop items to change context menu order.";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(404, 514);
            this.Controls.Add(this.TabContextMenuGitActionsGroup);
            this.Controls.Add(this.OtherSettingsGroup);
            this.Controls.Add(this.DefaultReposGroup);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(420, 220);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.DefaultReposGroup.ResumeLayout(false);
            this.DefaultReposGroup.PerformLayout();
            this.OtherSettingsGroup.ResumeLayout(false);
            this.OtherSettingsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxRecentReposNumeric)).EndInit();
            this.TabContextMenuGitActionsGroup.ResumeLayout(false);
            this.TabContextMenuGitActionsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox DefaultReposList;
        private System.Windows.Forms.Button AddDefaultRepo;
        private Button OK;
        private Button Cancel;
        private Button RemoveDefaultRepo;
        private GroupBox DefaultReposGroup;
        private Label DefaultReposNote;
        private CheckBox RetainLogsOnCloseCheck;
        private GroupBox OtherSettingsGroup;
        private NumericUpDown MaxRecentReposNumeric;
        private Label MaxRecentReposLabel;
        private GroupBox TabContextMenuGitActionsGroup;
        private CheckBox ConfirmOnCloseCheck;
        private CheckedListBox GitActionsCheckList;
        private Label GitActionsLabel;
    }
}