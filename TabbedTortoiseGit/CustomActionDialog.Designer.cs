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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( CustomActionDialog ) );
            NameLabel = new System.Windows.Forms.Label();
            ProgramLabel = new System.Windows.Forms.Label();
            ActionName = new System.Windows.Forms.TextBox();
            Program = new System.Windows.Forms.TextBox();
            ArgumentsLabel = new System.Windows.Forms.Label();
            Arguments = new System.Windows.Forms.TextBox();
            ProgramBrowse = new System.Windows.Forms.Button();
            Ok = new System.Windows.Forms.Button();
            Cancel = new System.Windows.Forms.Button();
            MacroLabel = new System.Windows.Forms.Label();
            ProgramBrowseDialog = new System.Windows.Forms.OpenFileDialog();
            WorkingDirectory = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            RefreshLogAfter = new System.Windows.Forms.CheckBox();
            ShowProgressDialog = new System.Windows.Forms.CheckBox();
            CreateNoWindow = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new System.Drawing.Point( 13, 15 );
            NameLabel.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new System.Drawing.Size( 42, 15 );
            NameLabel.TabIndex = 0;
            NameLabel.Text = "Name:";
            // 
            // ProgramLabel
            // 
            ProgramLabel.AutoSize = true;
            ProgramLabel.Location = new System.Drawing.Point( 13, 47 );
            ProgramLabel.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            ProgramLabel.Name = "ProgramLabel";
            ProgramLabel.Size = new System.Drawing.Size( 56, 15 );
            ProgramLabel.TabIndex = 1;
            ProgramLabel.Text = "Program:";
            // 
            // ActionName
            // 
            ActionName.Anchor =   System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            ActionName.Location = new System.Drawing.Point( 127, 12 );
            ActionName.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ActionName.Name = "ActionName";
            ActionName.Size = new System.Drawing.Size( 483, 23 );
            ActionName.TabIndex = 2;
            // 
            // Program
            // 
            Program.Anchor =   System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            Program.Location = new System.Drawing.Point( 127, 44 );
            Program.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Program.Name = "Program";
            Program.Size = new System.Drawing.Size( 447, 23 );
            Program.TabIndex = 3;
            // 
            // ArgumentsLabel
            // 
            ArgumentsLabel.AutoSize = true;
            ArgumentsLabel.Location = new System.Drawing.Point( 13, 76 );
            ArgumentsLabel.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            ArgumentsLabel.Name = "ArgumentsLabel";
            ArgumentsLabel.Size = new System.Drawing.Size( 69, 15 );
            ArgumentsLabel.TabIndex = 4;
            ArgumentsLabel.Text = "Arguments:";
            // 
            // Arguments
            // 
            Arguments.Anchor =   System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            Arguments.Location = new System.Drawing.Point( 127, 73 );
            Arguments.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Arguments.Name = "Arguments";
            Arguments.Size = new System.Drawing.Size( 481, 23 );
            Arguments.TabIndex = 5;
            // 
            // ProgramBrowse
            // 
            ProgramBrowse.Anchor =  System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Right ;
            ProgramBrowse.Location = new System.Drawing.Point( 579, 41 );
            ProgramBrowse.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ProgramBrowse.Name = "ProgramBrowse";
            ProgramBrowse.Size = new System.Drawing.Size( 29, 27 );
            ProgramBrowse.TabIndex = 7;
            ProgramBrowse.Text = "...";
            ProgramBrowse.UseVisualStyleBackColor = true;
            ProgramBrowse.Click +=  ProgramBrowse_Click ;
            // 
            // Ok
            // 
            Ok.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            Ok.Location = new System.Drawing.Point( 426, 282 );
            Ok.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Ok.Name = "Ok";
            Ok.Size = new System.Drawing.Size( 88, 27 );
            Ok.TabIndex = 8;
            Ok.Text = "OK";
            Ok.UseVisualStyleBackColor = true;
            Ok.Click +=  Ok_Click ;
            // 
            // Cancel
            // 
            Cancel.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Cancel.Location = new System.Drawing.Point( 522, 282 );
            Cancel.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Cancel.Name = "Cancel";
            Cancel.Size = new System.Drawing.Size( 88, 27 );
            Cancel.TabIndex = 9;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            // 
            // MacroLabel
            // 
            MacroLabel.Anchor =    System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Bottom   |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            MacroLabel.Location = new System.Drawing.Point( 13, 132 );
            MacroLabel.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            MacroLabel.Name = "MacroLabel";
            MacroLabel.Size = new System.Drawing.Size( 597, 90 );
            MacroLabel.TabIndex = 10;
            MacroLabel.Text = resources.GetString( "MacroLabel.Text" );
            // 
            // ProgramBrowseDialog
            // 
            ProgramBrowseDialog.FileName = "Program";
            ProgramBrowseDialog.InitialDirectory = "C:\\";
            // 
            // WorkingDirectory
            // 
            WorkingDirectory.Anchor =   System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            WorkingDirectory.Location = new System.Drawing.Point( 127, 102 );
            WorkingDirectory.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            WorkingDirectory.Name = "WorkingDirectory";
            WorkingDirectory.Size = new System.Drawing.Size( 483, 23 );
            WorkingDirectory.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point( 13, 105 );
            label1.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size( 106, 15 );
            label1.TabIndex = 12;
            label1.Text = "Working Directory:";
            // 
            // RefreshLogAfter
            // 
            RefreshLogAfter.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left ;
            RefreshLogAfter.AutoSize = true;
            RefreshLogAfter.Location = new System.Drawing.Point( 13, 232 );
            RefreshLogAfter.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            RefreshLogAfter.Name = "RefreshLogAfter";
            RefreshLogAfter.Size = new System.Drawing.Size( 206, 19 );
            RefreshLogAfter.TabIndex = 13;
            RefreshLogAfter.Text = "Refresh log after action completes";
            RefreshLogAfter.UseVisualStyleBackColor = true;
            // 
            // ShowProgressDialog
            // 
            ShowProgressDialog.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left ;
            ShowProgressDialog.AutoSize = true;
            ShowProgressDialog.Location = new System.Drawing.Point( 13, 257 );
            ShowProgressDialog.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ShowProgressDialog.Name = "ShowProgressDialog";
            ShowProgressDialog.Size = new System.Drawing.Size( 139, 19 );
            ShowProgressDialog.TabIndex = 14;
            ShowProgressDialog.Text = "Show progress dialog";
            ShowProgressDialog.UseVisualStyleBackColor = true;
            // 
            // CreateNoWindow
            // 
            CreateNoWindow.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left ;
            CreateNoWindow.AutoSize = true;
            CreateNoWindow.Location = new System.Drawing.Point( 13, 282 );
            CreateNoWindow.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            CreateNoWindow.Name = "CreateNoWindow";
            CreateNoWindow.Size = new System.Drawing.Size( 225, 19 );
            CreateNoWindow.TabIndex = 15;
            CreateNoWindow.Text = "Do not create a window for the action";
            CreateNoWindow.UseVisualStyleBackColor = true;
            // 
            // CustomActionDialog
            // 
            AcceptButton = Ok;
            AutoScaleDimensions = new System.Drawing.SizeF( 96F, 96F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            CancelButton = Cancel;
            ClientSize = new System.Drawing.Size( 623, 321 );
            Controls.Add( CreateNoWindow );
            Controls.Add( ShowProgressDialog );
            Controls.Add( RefreshLogAfter );
            Controls.Add( label1 );
            Controls.Add( WorkingDirectory );
            Controls.Add( MacroLabel );
            Controls.Add( Cancel );
            Controls.Add( Ok );
            Controls.Add( ProgramBrowse );
            Controls.Add( Arguments );
            Controls.Add( ArgumentsLabel );
            Controls.Add( Program );
            Controls.Add( ActionName );
            Controls.Add( ProgramLabel );
            Controls.Add( NameLabel );
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomActionDialog";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Custom Action";
            ResumeLayout( false );
            PerformLayout();

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