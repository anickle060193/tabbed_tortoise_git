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
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.AttributionsText = new System.Windows.Forms.TextBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.ProductNameLabel = new System.Windows.Forms.Label();
            this.DescriptionText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.OpenDebugLog = new System.Windows.Forms.Button();
            this.ViewGithub = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.VersionTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.UpdateCheckLabel = new System.Windows.Forms.Label();
            this.TableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.ButtonLayout.SuspendLayout();
            this.VersionTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayout
            // 
            this.TableLayout.ColumnCount = 2;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.TableLayout.Controls.Add(this.AttributionsText, 1, 5);
            this.TableLayout.Controls.Add(this.Logo, 0, 0);
            this.TableLayout.Controls.Add(this.ProductNameLabel, 1, 0);
            this.TableLayout.Controls.Add(this.DescriptionText, 1, 3);
            this.TableLayout.Controls.Add(this.label2, 1, 4);
            this.TableLayout.Controls.Add(this.label1, 1, 2);
            this.TableLayout.Controls.Add(this.ButtonLayout, 1, 6);
            this.TableLayout.Controls.Add(this.VersionTableLayout, 1, 1);
            this.TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout.Location = new System.Drawing.Point(9, 9);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 7;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.Size = new System.Drawing.Size(639, 265);
            this.TableLayout.TabIndex = 0;
            // 
            // AttributionsText
            // 
            this.AttributionsText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AttributionsText.Location = new System.Drawing.Point(261, 145);
            this.AttributionsText.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.AttributionsText.Multiline = true;
            this.AttributionsText.Name = "AttributionsText";
            this.AttributionsText.ReadOnly = true;
            this.AttributionsText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AttributionsText.Size = new System.Drawing.Size(375, 87);
            this.AttributionsText.TabIndex = 25;
            this.AttributionsText.TabStop = false;
            this.AttributionsText.Text = "Git log functionality provided by TortoiseGit\r\n\r\nTurtle icon made by Freepik from" +
    " FlatIcon licensed by Creative Commons BY 3.0\r\n\r\nGit action Octicons created by " +
    "GitHub.";
            // 
            // Logo
            // 
            this.Logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Logo.Image = global::TabbedTortoiseGit.Properties.Resources.Tortoise;
            this.Logo.InitialImage = null;
            this.Logo.Location = new System.Drawing.Point(3, 3);
            this.Logo.Name = "Logo";
            this.TableLayout.SetRowSpan(this.Logo, 7);
            this.Logo.Size = new System.Drawing.Size(249, 259);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 12;
            this.Logo.TabStop = false;
            // 
            // ProductNameLabel
            // 
            this.ProductNameLabel.AutoSize = true;
            this.ProductNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductNameLabel.Location = new System.Drawing.Point(261, 0);
            this.ProductNameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.ProductNameLabel.Name = "ProductNameLabel";
            this.ProductNameLabel.Size = new System.Drawing.Size(148, 25);
            this.ProductNameLabel.TabIndex = 19;
            this.ProductNameLabel.Text = "Product Name";
            this.ProductNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DescriptionText
            // 
            this.DescriptionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionText.Location = new System.Drawing.Point(261, 70);
            this.DescriptionText.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.DescriptionText.Multiline = true;
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.ReadOnly = true;
            this.DescriptionText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescriptionText.Size = new System.Drawing.Size(375, 56);
            this.DescriptionText.TabIndex = 23;
            this.DescriptionText.TabStop = false;
            this.DescriptionText.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Attributions:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Description:";
            // 
            // ButtonLayout
            // 
            this.ButtonLayout.AutoSize = true;
            this.ButtonLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonLayout.ColumnCount = 3;
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ButtonLayout.Controls.Add(this.OpenDebugLog, 1, 0);
            this.ButtonLayout.Controls.Add(this.ViewGithub, 0, 0);
            this.ButtonLayout.Controls.Add(this.OK, 2, 0);
            this.ButtonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLayout.Location = new System.Drawing.Point(255, 235);
            this.ButtonLayout.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonLayout.Name = "ButtonLayout";
            this.ButtonLayout.RowCount = 1;
            this.ButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ButtonLayout.Size = new System.Drawing.Size(384, 30);
            this.ButtonLayout.TabIndex = 28;
            // 
            // OpenDebugLog
            // 
            this.OpenDebugLog.AutoSize = true;
            this.OpenDebugLog.Location = new System.Drawing.Point(84, 3);
            this.OpenDebugLog.Name = "OpenDebugLog";
            this.OpenDebugLog.Size = new System.Drawing.Size(99, 23);
            this.OpenDebugLog.TabIndex = 26;
            this.OpenDebugLog.Text = "Open Debug Log";
            this.OpenDebugLog.UseVisualStyleBackColor = true;
            // 
            // ViewGithub
            // 
            this.ViewGithub.AutoSize = true;
            this.ViewGithub.Location = new System.Drawing.Point(3, 3);
            this.ViewGithub.Name = "ViewGithub";
            this.ViewGithub.Size = new System.Drawing.Size(75, 23);
            this.ViewGithub.TabIndex = 25;
            this.ViewGithub.Text = "View Github";
            this.ViewGithub.UseVisualStyleBackColor = true;
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OK.Location = new System.Drawing.Point(306, 3);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 24;
            this.OK.Text = "&OK";
            // 
            // VersionTableLayout
            // 
            this.VersionTableLayout.AutoSize = true;
            this.VersionTableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.VersionTableLayout.ColumnCount = 3;
            this.VersionTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.VersionTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.VersionTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.VersionTableLayout.Controls.Add(this.VersionLabel, 0, 0);
            this.VersionTableLayout.Controls.Add(this.UpdateButton, 2, 0);
            this.VersionTableLayout.Controls.Add(this.UpdateCheckLabel, 1, 0);
            this.VersionTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VersionTableLayout.Location = new System.Drawing.Point(255, 25);
            this.VersionTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.VersionTableLayout.Name = "VersionTableLayout";
            this.VersionTableLayout.RowCount = 1;
            this.VersionTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.VersionTableLayout.Size = new System.Drawing.Size(384, 29);
            this.VersionTableLayout.TabIndex = 29;
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.VersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel.Location = new System.Drawing.Point(6, 0);
            this.VersionLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(63, 29);
            this.VersionLabel.TabIndex = 0;
            this.VersionLabel.Text = "Version";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateButton.Enabled = false;
            this.UpdateButton.Location = new System.Drawing.Point(306, 3);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 1;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            // 
            // UpdateCheckLabel
            // 
            this.UpdateCheckLabel.AutoSize = true;
            this.UpdateCheckLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.UpdateCheckLabel.Location = new System.Drawing.Point(155, 0);
            this.UpdateCheckLabel.Name = "UpdateCheckLabel";
            this.UpdateCheckLabel.Size = new System.Drawing.Size(145, 29);
            this.UpdateCheckLabel.TabIndex = 2;
            this.UpdateCheckLabel.Text = "Checking for newer version...";
            this.UpdateCheckLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AboutBox
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.OK;
            this.ClientSize = new System.Drawing.Size(657, 283);
            this.Controls.Add(this.TableLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.TableLayout.ResumeLayout(false);
            this.TableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ButtonLayout.ResumeLayout(false);
            this.ButtonLayout.PerformLayout();
            this.VersionTableLayout.ResumeLayout(false);
            this.VersionTableLayout.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button OpenDebugLog;
        private System.Windows.Forms.Button ViewGithub;
        private System.Windows.Forms.TableLayoutPanel VersionTableLayout;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Label UpdateCheckLabel;
    }
}
