namespace TabbedTortoiseGit
{
    partial class FastFetchDialog
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
            this.OptionsGroup = new System.Windows.Forms.GroupBox();
            this.ShowProgressCheck = new System.Windows.Forms.CheckBox();
            this.MaxProcessesNumeric = new System.Windows.Forms.NumericUpDown();
            this.MaxProcessesLabel = new System.Windows.Forms.Label();
            this.PruneCheck = new System.Windows.Forms.CheckBox();
            this.TagsCheck = new System.Windows.Forms.CheckBox();
            this.Ok = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.OptionsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxProcessesNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // OptionsGroup
            // 
            this.OptionsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsGroup.Controls.Add(this.ShowProgressCheck);
            this.OptionsGroup.Controls.Add(this.MaxProcessesNumeric);
            this.OptionsGroup.Controls.Add(this.MaxProcessesLabel);
            this.OptionsGroup.Controls.Add(this.PruneCheck);
            this.OptionsGroup.Controls.Add(this.TagsCheck);
            this.OptionsGroup.Location = new System.Drawing.Point(12, 12);
            this.OptionsGroup.Name = "OptionsGroup";
            this.OptionsGroup.Size = new System.Drawing.Size(260, 72);
            this.OptionsGroup.TabIndex = 0;
            this.OptionsGroup.TabStop = false;
            this.OptionsGroup.Text = "Options";
            // 
            // ShowProgressCheck
            // 
            this.ShowProgressCheck.AutoSize = true;
            this.ShowProgressCheck.Location = new System.Drawing.Point(127, 19);
            this.ShowProgressCheck.Name = "ShowProgressCheck";
            this.ShowProgressCheck.Size = new System.Drawing.Size(97, 17);
            this.ShowProgressCheck.TabIndex = 4;
            this.ShowProgressCheck.Text = "Show Progress";
            this.ShowProgressCheck.UseVisualStyleBackColor = true;
            // 
            // MaxProcessesNumeric
            // 
            this.MaxProcessesNumeric.Location = new System.Drawing.Point(212, 41);
            this.MaxProcessesNumeric.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.MaxProcessesNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxProcessesNumeric.Name = "MaxProcessesNumeric";
            this.MaxProcessesNumeric.Size = new System.Drawing.Size(42, 20);
            this.MaxProcessesNumeric.TabIndex = 3;
            this.MaxProcessesNumeric.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // MaxProcessesLabel
            // 
            this.MaxProcessesLabel.AutoSize = true;
            this.MaxProcessesLabel.Location = new System.Drawing.Point(124, 43);
            this.MaxProcessesLabel.Name = "MaxProcessesLabel";
            this.MaxProcessesLabel.Size = new System.Drawing.Size(82, 13);
            this.MaxProcessesLabel.TabIndex = 2;
            this.MaxProcessesLabel.Text = "Max Processes:";
            // 
            // PruneCheck
            // 
            this.PruneCheck.AutoSize = true;
            this.PruneCheck.Location = new System.Drawing.Point(6, 42);
            this.PruneCheck.Name = "PruneCheck";
            this.PruneCheck.Size = new System.Drawing.Size(54, 17);
            this.PruneCheck.TabIndex = 1;
            this.PruneCheck.Text = "Prune";
            this.PruneCheck.UseVisualStyleBackColor = true;
            // 
            // TagsCheck
            // 
            this.TagsCheck.AutoSize = true;
            this.TagsCheck.Location = new System.Drawing.Point(6, 19);
            this.TagsCheck.Name = "TagsCheck";
            this.TagsCheck.Size = new System.Drawing.Size(50, 17);
            this.TagsCheck.TabIndex = 0;
            this.TagsCheck.Text = "Tags";
            this.TagsCheck.UseVisualStyleBackColor = true;
            // 
            // Ok
            // 
            this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok.Location = new System.Drawing.Point(116, 92);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 1;
            this.Ok.Text = "OK";
            this.Ok.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(197, 92);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // FastFetchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 127);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.OptionsGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FastFetchDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fast Fetch";
            this.OptionsGroup.ResumeLayout(false);
            this.OptionsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxProcessesNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox OptionsGroup;
        private System.Windows.Forms.CheckBox PruneCheck;
        private System.Windows.Forms.CheckBox TagsCheck;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.NumericUpDown MaxProcessesNumeric;
        private System.Windows.Forms.Label MaxProcessesLabel;
        private System.Windows.Forms.CheckBox ShowProgressCheck;
    }
}