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
            this.ActionName.Location = new System.Drawing.Point(78, 12);
            this.ActionName.Name = "ActionName";
            this.ActionName.Size = new System.Drawing.Size(348, 20);
            this.ActionName.TabIndex = 2;
            this.ActionName.TextChanged += new System.EventHandler(this.ActionName_TextChanged);
            // 
            // Program
            // 
            this.Program.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Program.Location = new System.Drawing.Point(78, 40);
            this.Program.Name = "Program";
            this.Program.Size = new System.Drawing.Size(317, 20);
            this.Program.TabIndex = 3;
            this.Program.TextChanged += new System.EventHandler(this.Program_TextChanged);
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
            this.Arguments.Location = new System.Drawing.Point(78, 67);
            this.Arguments.Name = "Arguments";
            this.Arguments.Size = new System.Drawing.Size(348, 20);
            this.Arguments.TabIndex = 5;
            // 
            // ProgramBrowse
            // 
            this.ProgramBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgramBrowse.Location = new System.Drawing.Point(401, 38);
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
            this.Ok.Location = new System.Drawing.Point(270, 165);
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
            this.Cancel.Location = new System.Drawing.Point(351, 165);
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
            this.MacroLabel.Location = new System.Drawing.Point(75, 90);
            this.MacroLabel.Name = "MacroLabel";
            this.MacroLabel.Size = new System.Drawing.Size(351, 71);
            this.MacroLabel.TabIndex = 10;
            this.MacroLabel.Text = resources.GetString("MacroLabel.Text");
            // 
            // ProgramBrowseDialog
            // 
            this.ProgramBrowseDialog.FileName = "Program";
            this.ProgramBrowseDialog.InitialDirectory = "C:\\";
            // 
            // CustomActionDialog
            // 
            this.AcceptButton = this.Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(438, 200);
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
    }
}