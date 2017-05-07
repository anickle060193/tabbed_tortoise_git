namespace TabbedTortoiseGit
{
    partial class TabbedTortoiseGitForm
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
            this.LogTabs = new TabbedTortoiseGit.ExtendedTabControl();
            this.SuspendLayout();
            // 
            // LogTabs
            // 
            this.LogTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTabs.Location = new System.Drawing.Point(0, 0);
            this.LogTabs.Name = "LogTabs";
            this.LogTabs.SelectedIndex = 0;
            this.LogTabs.Size = new System.Drawing.Size(644, 461);
            this.LogTabs.TabIndex = 0;
            this.LogTabs.NewTabClicked += new System.EventHandler(this.LogTabs_NewTabClicked);
            this.LogTabs.TabClosed += new System.EventHandler<TabbedTortoiseGit.TabClosedEventArgs>(this.LogTabs_TabClosed);
            this.LogTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.LogTabs_Selected);
            // 
            // TabbedTortoiseGitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 461);
            this.Controls.Add(this.LogTabs);
            this.MinimumSize = new System.Drawing.Size(660, 500);
            this.Name = "TabbedTortoiseGitForm";
            this.Text = "Tabbed Tortoise Git";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TabbedTortoiseGitForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private ExtendedTabControl LogTabs;
    }
}

