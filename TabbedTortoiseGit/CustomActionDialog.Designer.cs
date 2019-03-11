namespace TabbedTortoiseGit
{
    partial class CustomActionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomActionDialog));
            this.NameLabel = new System.Windows.Forms.Label();
            this.ProgramLabel = new System.Windows.Forms.Label();
            this.ActionName = new System.Windows.Forms.TextBox();
            this.Program = new System.Windows.Forms.TextBox();
            this.ArgumentsLabel = new System.Windows.Forms.Label();
            this.Arguments = new System.Windows.Forms.TextBox();
            this.ProgramBrowse = new System.Windows.Forms.Button();
            this.Ok = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.MacroLabel = new System.Windows.Forms.Label();
            this.ProgramBrowseDialog = new System.Windows.Forms.OpenFileDialog();
            this.WorkingDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RefreshLogAfter = new System.Windows.Forms.CheckBox();
            this.ShowProgressDialog = new System.Windows.Forms.CheckBox();
            this.CreateNoWindow = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 15);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name:";
            // 
            // ProgramLabel
            // 
            this.ProgramLabel.AutoSize = true;
            this.ProgramLabel.Location = new System.Drawing.Point(12, 43);
            this.ProgramLabel.Name = "ProgramLabel";
            this.ProgramLabel.Size = new System.Drawing.Size(49, 13);
            this.ProgramLabel.TabIndex = 1;
            this.ProgramLabel.Text = "Program:";
            // 
            // ActionName
            // 
            this.ActionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ActionName.Location = new System.Drawing.Point(113, 12);
            this.ActionName.Name = "ActionName";
            this.ActionName.Size = new System.Drawing.Size(314, 20);
            this.ActionName.TabIndex = 2;
            // 
            // Program
            // 
            this.Program.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Program.Location = new System.Drawing.Point(113, 40);
            this.Program.Name = "Program";
            this.Program.Size = new System.Drawing.Size(283, 20);
            this.Program.TabIndex = 3;
            // 
            // ArgumentsLabel
            // 
            this.ArgumentsLabel.AutoSize = true;
            this.ArgumentsLabel.Location = new System.Drawing.Point(12, 70);
            this.ArgumentsLabel.Name = "ArgumentsLabel";
            this.ArgumentsLabel.Size = new System.Drawing.Size(60, 13);
            this.ArgumentsLabel.TabIndex = 4;
            this.ArgumentsLabel.Text = "Arguments:";
            // 
            // Arguments
            // 
            this.Arguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Arguments.Location = new System.Drawing.Point(113, 67);
            this.Arguments.Name = "Arguments";
            this.Arguments.Size = new System.Drawing.Size(314, 20);
            this.Arguments.TabIndex = 5;
            // 
            // ProgramBrowse
            // 
            this.ProgramBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgramBrowse.Location = new System.Drawing.Point(402, 38);
            this.ProgramBrowse.Name = "ProgramBrowse";
            this.ProgramBrowse.Size = new System.Drawing.Size(25, 23);
            this.ProgramBrowse.TabIndex = 7;
            this.ProgramBrowse.Text = "...";
            this.ProgramBrowse.UseVisualStyleBackColor = true;
            this.ProgramBrowse.Click += new System.EventHandler(this.ProgramBrowse_Click);
            // 
            // Ok
            // 
            this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok.Location = new System.Drawing.Point(271, 236);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 8;
            this.Ok.Text = "OK";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(352, 236);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // MacroLabel
            // 
            this.MacroLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MacroLabel.Location = new System.Drawing.Point(15, 116);
            this.MacroLabel.Name = "MacroLabel";
            this.MacroLabel.Size = new System.Drawing.Size(412, 71);
            this.MacroLabel.TabIndex = 10;
            this.MacroLabel.Text = resources.GetString("MacroLabel.Text");
            // 
            // ProgramBrowseDialog
            // 
            this.ProgramBrowseDialog.FileName = "Program";
            this.ProgramBrowseDialog.InitialDirectory = "C:\\";
            // 
            // WorkingDirectory
            // 
            this.WorkingDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkingDirectory.Location = new System.Drawing.Point(113, 93);
            this.WorkingDirectory.Name = "WorkingDirectory";
            this.WorkingDirectory.Size = new System.Drawing.Size(314, 20);
            this.WorkingDirectory.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Working Directory:";
            // 
            // RefreshLogAfter
            // 
            this.RefreshLogAfter.AutoSize = true;
            this.RefreshLogAfter.Location = new System.Drawing.Point(12, 190);
            this.RefreshLogAfter.Name = "RefreshLogAfter";
            this.RefreshLogAfter.Size = new System.Drawing.Size(187, 17);
            this.RefreshLogAfter.TabIndex = 13;
            this.RefreshLogAfter.Text = "Refresh log after action completes";
            this.RefreshLogAfter.UseVisualStyleBackColor = true;
            // 
            // ShowProgressDialog
            // 
            this.ShowProgressDialog.AutoSize = true;
            this.ShowProgressDialog.Location = new System.Drawing.Point(12, 213);
            this.ShowProgressDialog.Name = "ShowProgressDialog";
            this.ShowProgressDialog.Size = new System.Drawing.Size(127, 17);
            this.ShowProgressDialog.TabIndex = 14;
            this.ShowProgressDialog.Text = "Show progress dialog";
            this.ShowProgressDialog.UseVisualStyleBackColor = true;
            // 
            // CreateNoWindow
            // 
            this.CreateNoWindow.AutoSize = true;
            this.CreateNoWindow.Location = new System.Drawing.Point(12, 236);
            this.CreateNoWindow.Name = "CreateNoWindow";
            this.CreateNoWindow.Size = new System.Drawing.Size(204, 17);
            this.CreateNoWindow.TabIndex = 15;
            this.CreateNoWindow.Text = "Do not create a window for the action";
            this.CreateNoWindow.UseVisualStyleBackColor = true;
            // 
            // CustomActionDialog
            // 
            this.AcceptButton = this.Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(439, 271);
            this.Controls.Add(this.CreateNoWindow);
            this.Controls.Add(this.ShowProgressDialog);
            this.Controls.Add(this.RefreshLogAfter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WorkingDirectory);
            this.Controls.Add(this.MacroLabel);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.ProgramBrowse);
            this.Controls.Add(this.Arguments);
            this.Controls.Add(this.ArgumentsLabel);
            this.Controls.Add(this.Program);
            this.Controls.Add(this.ActionName);
            this.Controls.Add(this.ProgramLabel);
            this.Controls.Add(this.NameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CustomActionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Action";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label ProgramLabel;
        private System.Windows.Forms.TextBox ActionName;
        private System.Windows.Forms.TextBox Program;
        private System.Windows.Forms.Label ArgumentsLabel;
        private System.Windows.Forms.TextBox Arguments;
        private System.Windows.Forms.Button ProgramBrowse;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label MacroLabel;
        private System.Windows.Forms.OpenFileDialog ProgramBrowseDialog;
        private System.Windows.Forms.TextBox WorkingDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox RefreshLogAfter;
        private System.Windows.Forms.CheckBox ShowProgressDialog;
        private System.Windows.Forms.CheckBox CreateNoWindow;
    }
}