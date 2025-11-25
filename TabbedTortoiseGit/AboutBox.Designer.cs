namespace TabbedTortoiseGit
{
    partial class AboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            TableLayout = new System.Windows.Forms.TableLayoutPanel();
            AttributionsText = new System.Windows.Forms.TextBox();
            Logo = new System.Windows.Forms.PictureBox();
            ProductNameLabel = new System.Windows.Forms.Label();
            DescriptionText = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            ViewGithub = new System.Windows.Forms.Button();
            OK = new System.Windows.Forms.Button();
            ChangelogButton = new System.Windows.Forms.Button();
            VersionTableLayout = new System.Windows.Forms.TableLayoutPanel();
            VersionLabel = new System.Windows.Forms.Label();
            UpdateButton = new System.Windows.Forms.Button();
            UpdateCheckLabel = new System.Windows.Forms.Label();
            TableLayout.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)Logo ).BeginInit();
            ButtonLayout.SuspendLayout();
            VersionTableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayout
            // 
            TableLayout.ColumnCount = 2;
            TableLayout.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 40F ) );
            TableLayout.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 60F ) );
            TableLayout.Controls.Add( AttributionsText, 1, 5 );
            TableLayout.Controls.Add( Logo, 0, 0 );
            TableLayout.Controls.Add( ProductNameLabel, 1, 0 );
            TableLayout.Controls.Add( DescriptionText, 1, 3 );
            TableLayout.Controls.Add( label2, 1, 4 );
            TableLayout.Controls.Add( label1, 1, 2 );
            TableLayout.Controls.Add( ButtonLayout, 1, 6 );
            TableLayout.Controls.Add( VersionTableLayout, 1, 1 );
            TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            TableLayout.Location = new System.Drawing.Point( 10, 10 );
            TableLayout.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            TableLayout.Name = "TableLayout";
            TableLayout.RowCount = 7;
            TableLayout.RowStyles.Add( new System.Windows.Forms.RowStyle() );
            TableLayout.RowStyles.Add( new System.Windows.Forms.RowStyle() );
            TableLayout.RowStyles.Add( new System.Windows.Forms.RowStyle() );
            TableLayout.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 40F ) );
            TableLayout.RowStyles.Add( new System.Windows.Forms.RowStyle() );
            TableLayout.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 60F ) );
            TableLayout.RowStyles.Add( new System.Windows.Forms.RowStyle() );
            TableLayout.Size = new System.Drawing.Size( 746, 307 );
            TableLayout.TabIndex = 0;
            // 
            // AttributionsText
            // 
            AttributionsText.Dock = System.Windows.Forms.DockStyle.Fill;
            AttributionsText.Location = new System.Drawing.Point( 305, 164 );
            AttributionsText.Margin = new System.Windows.Forms.Padding( 7, 3, 4, 3 );
            AttributionsText.Multiline = true;
            AttributionsText.Name = "AttributionsText";
            AttributionsText.ReadOnly = true;
            AttributionsText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            AttributionsText.Size = new System.Drawing.Size( 437, 104 );
            AttributionsText.TabIndex = 25;
            AttributionsText.TabStop = false;
            AttributionsText.Text = "Git log functionality provided by TortoiseGit\r\n\r\nTurtle icon made by Freepik from FlatIcon licensed by Creative Commons BY 3.0\r\n\r\nGit action Octicons created by GitHub.";
            // 
            // Logo
            // 
            Logo.Dock = System.Windows.Forms.DockStyle.Fill;
            Logo.Image = Properties.Resources.Tortoise;
            Logo.InitialImage = null;
            Logo.Location = new System.Drawing.Point( 4, 3 );
            Logo.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Logo.Name = "Logo";
            TableLayout.SetRowSpan( Logo, 7 );
            Logo.Size = new System.Drawing.Size( 290, 301 );
            Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            Logo.TabIndex = 12;
            Logo.TabStop = false;
            // 
            // ProductNameLabel
            // 
            ProductNameLabel.AutoSize = true;
            ProductNameLabel.Font = new System.Drawing.Font( "Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0 );
            ProductNameLabel.Location = new System.Drawing.Point( 305, 0 );
            ProductNameLabel.Margin = new System.Windows.Forms.Padding( 7, 0, 4, 0 );
            ProductNameLabel.Name = "ProductNameLabel";
            ProductNameLabel.Size = new System.Drawing.Size( 148, 25 );
            ProductNameLabel.TabIndex = 19;
            ProductNameLabel.Text = "Product Name";
            ProductNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DescriptionText
            // 
            DescriptionText.Dock = System.Windows.Forms.DockStyle.Fill;
            DescriptionText.Location = new System.Drawing.Point( 305, 76 );
            DescriptionText.Margin = new System.Windows.Forms.Padding( 7, 3, 4, 3 );
            DescriptionText.Multiline = true;
            DescriptionText.Name = "DescriptionText";
            DescriptionText.ReadOnly = true;
            DescriptionText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            DescriptionText.Size = new System.Drawing.Size( 437, 67 );
            DescriptionText.TabIndex = 23;
            DescriptionText.TabStop = false;
            DescriptionText.Text = "Description";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point( 302, 146 );
            label2.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size( 73, 15 );
            label2.TabIndex = 27;
            label2.Text = "Attributions:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point( 302, 58 );
            label1.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size( 70, 15 );
            label1.TabIndex = 26;
            label1.Text = "Description:";
            // 
            // ButtonLayout
            // 
            ButtonLayout.AutoSize = true;
            ButtonLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ButtonLayout.ColumnCount = 3;
            ButtonLayout.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
            ButtonLayout.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
            ButtonLayout.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
            ButtonLayout.Controls.Add( ViewGithub, 0, 0 );
            ButtonLayout.Controls.Add( OK, 2, 0 );
            ButtonLayout.Controls.Add( ChangelogButton, 1, 0 );
            ButtonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            ButtonLayout.Location = new System.Drawing.Point( 298, 271 );
            ButtonLayout.Margin = new System.Windows.Forms.Padding( 0 );
            ButtonLayout.Name = "ButtonLayout";
            ButtonLayout.RowCount = 1;
            ButtonLayout.RowStyles.Add( new System.Windows.Forms.RowStyle() );
            ButtonLayout.Size = new System.Drawing.Size( 448, 36 );
            ButtonLayout.TabIndex = 28;
            // 
            // ViewGithub
            // 
            ViewGithub.AutoSize = true;
            ViewGithub.Location = new System.Drawing.Point( 4, 3 );
            ViewGithub.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ViewGithub.Name = "ViewGithub";
            ViewGithub.Size = new System.Drawing.Size( 94, 29 );
            ViewGithub.TabIndex = 25;
            ViewGithub.Text = "View Github";
            ViewGithub.UseVisualStyleBackColor = true;
            // 
            // OK
            // 
            OK.Anchor =  System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Right ;
            OK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            OK.Location = new System.Drawing.Point( 356, 3 );
            OK.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            OK.Name = "OK";
            OK.Size = new System.Drawing.Size( 88, 27 );
            OK.TabIndex = 24;
            OK.Text = "&OK";
            // 
            // ChangelogButton
            // 
            ChangelogButton.Location = new System.Drawing.Point( 106, 3 );
            ChangelogButton.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ChangelogButton.Name = "ChangelogButton";
            ChangelogButton.Size = new System.Drawing.Size( 88, 27 );
            ChangelogButton.TabIndex = 26;
            ChangelogButton.Text = "Changelog";
            ChangelogButton.UseVisualStyleBackColor = true;
            // 
            // VersionTableLayout
            // 
            VersionTableLayout.AutoSize = true;
            VersionTableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            VersionTableLayout.ColumnCount = 3;
            VersionTableLayout.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
            VersionTableLayout.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
            VersionTableLayout.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
            VersionTableLayout.Controls.Add( VersionLabel, 0, 0 );
            VersionTableLayout.Controls.Add( UpdateButton, 2, 0 );
            VersionTableLayout.Controls.Add( UpdateCheckLabel, 1, 0 );
            VersionTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            VersionTableLayout.Location = new System.Drawing.Point( 298, 25 );
            VersionTableLayout.Margin = new System.Windows.Forms.Padding( 0 );
            VersionTableLayout.Name = "VersionTableLayout";
            VersionTableLayout.RowCount = 1;
            VersionTableLayout.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
            VersionTableLayout.Size = new System.Drawing.Size( 448, 33 );
            VersionTableLayout.TabIndex = 29;
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.Dock = System.Windows.Forms.DockStyle.Left;
            VersionLabel.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0 );
            VersionLabel.Location = new System.Drawing.Point( 7, 0 );
            VersionLabel.Margin = new System.Windows.Forms.Padding( 7, 0, 4, 0 );
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new System.Drawing.Size( 63, 33 );
            VersionLabel.TabIndex = 0;
            VersionLabel.Text = "Version";
            VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UpdateButton
            // 
            UpdateButton.Anchor =  System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Right ;
            UpdateButton.Enabled = false;
            UpdateButton.Location = new System.Drawing.Point( 356, 3 );
            UpdateButton.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new System.Drawing.Size( 88, 27 );
            UpdateButton.TabIndex = 1;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            // 
            // UpdateCheckLabel
            // 
            UpdateCheckLabel.AutoSize = true;
            UpdateCheckLabel.Dock = System.Windows.Forms.DockStyle.Right;
            UpdateCheckLabel.Location = new System.Drawing.Point( 188, 0 );
            UpdateCheckLabel.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            UpdateCheckLabel.Name = "UpdateCheckLabel";
            UpdateCheckLabel.Size = new System.Drawing.Size( 160, 33 );
            UpdateCheckLabel.TabIndex = 2;
            UpdateCheckLabel.Text = "Checking for newer version...";
            UpdateCheckLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AboutBox
            // 
            AcceptButton = OK;
            AutoScaleDimensions = new System.Drawing.SizeF( 96F, 96F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            CancelButton = OK;
            ClientSize = new System.Drawing.Size( 766, 327 );
            Controls.Add( TableLayout );
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutBox";
            Padding = new System.Windows.Forms.Padding( 10 );
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "About";
            TableLayout.ResumeLayout( false );
            TableLayout.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)Logo ).EndInit();
            ButtonLayout.ResumeLayout( false );
            ButtonLayout.PerformLayout();
            VersionTableLayout.ResumeLayout( false );
            VersionTableLayout.PerformLayout();
            ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayout;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label ProductNameLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.TextBox DescriptionText;
        private System.Windows.Forms.TextBox AttributionsText;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel ButtonLayout;
        private System.Windows.Forms.Button ViewGithub;
        private System.Windows.Forms.TableLayoutPanel VersionTableLayout;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Label UpdateCheckLabel;
        private System.Windows.Forms.Button ChangelogButton;
    }
}
