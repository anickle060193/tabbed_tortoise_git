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
            OptionsGroup = new System.Windows.Forms.GroupBox();
            ShowProgressCheck = new System.Windows.Forms.CheckBox();
            MaxProcessesNumeric = new System.Windows.Forms.NumericUpDown();
            MaxProcessesLabel = new System.Windows.Forms.Label();
            PruneCheck = new System.Windows.Forms.CheckBox();
            TagsCheck = new System.Windows.Forms.CheckBox();
            Ok = new System.Windows.Forms.Button();
            Cancel = new System.Windows.Forms.Button();
            OptionsGroup.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)MaxProcessesNumeric ).BeginInit();
            SuspendLayout();
            // 
            // OptionsGroup
            // 
            OptionsGroup.Anchor =   System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            OptionsGroup.Controls.Add( ShowProgressCheck );
            OptionsGroup.Controls.Add( MaxProcessesNumeric );
            OptionsGroup.Controls.Add( MaxProcessesLabel );
            OptionsGroup.Controls.Add( PruneCheck );
            OptionsGroup.Controls.Add( TagsCheck );
            OptionsGroup.Location = new System.Drawing.Point( 14, 14 );
            OptionsGroup.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            OptionsGroup.Name = "OptionsGroup";
            OptionsGroup.Padding = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            OptionsGroup.Size = new System.Drawing.Size( 303, 83 );
            OptionsGroup.TabIndex = 0;
            OptionsGroup.TabStop = false;
            OptionsGroup.Text = "Options";
            // 
            // ShowProgressCheck
            // 
            ShowProgressCheck.AutoSize = true;
            ShowProgressCheck.Location = new System.Drawing.Point( 148, 22 );
            ShowProgressCheck.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ShowProgressCheck.Name = "ShowProgressCheck";
            ShowProgressCheck.Size = new System.Drawing.Size( 103, 19 );
            ShowProgressCheck.TabIndex = 4;
            ShowProgressCheck.Text = "Show Progress";
            ShowProgressCheck.UseVisualStyleBackColor = true;
            // 
            // MaxProcessesNumeric
            // 
            MaxProcessesNumeric.Location = new System.Drawing.Point( 247, 47 );
            MaxProcessesNumeric.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            MaxProcessesNumeric.Maximum = new decimal( new int[] { 64, 0, 0, 0 } );
            MaxProcessesNumeric.Minimum = new decimal( new int[] { 1, 0, 0, 0 } );
            MaxProcessesNumeric.Name = "MaxProcessesNumeric";
            MaxProcessesNumeric.Size = new System.Drawing.Size( 49, 23 );
            MaxProcessesNumeric.TabIndex = 3;
            MaxProcessesNumeric.Value = new decimal( new int[] { 1, 0, 0, 0 } );
            // 
            // MaxProcessesLabel
            // 
            MaxProcessesLabel.AutoSize = true;
            MaxProcessesLabel.Location = new System.Drawing.Point( 145, 50 );
            MaxProcessesLabel.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            MaxProcessesLabel.Name = "MaxProcessesLabel";
            MaxProcessesLabel.Size = new System.Drawing.Size( 86, 15 );
            MaxProcessesLabel.TabIndex = 2;
            MaxProcessesLabel.Text = "Max Processes:";
            // 
            // PruneCheck
            // 
            PruneCheck.AutoSize = true;
            PruneCheck.Location = new System.Drawing.Point( 7, 48 );
            PruneCheck.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            PruneCheck.Name = "PruneCheck";
            PruneCheck.Size = new System.Drawing.Size( 57, 19 );
            PruneCheck.TabIndex = 1;
            PruneCheck.Text = "Prune";
            PruneCheck.UseVisualStyleBackColor = true;
            // 
            // TagsCheck
            // 
            TagsCheck.AutoSize = true;
            TagsCheck.Location = new System.Drawing.Point( 7, 22 );
            TagsCheck.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            TagsCheck.Name = "TagsCheck";
            TagsCheck.Size = new System.Drawing.Size( 50, 19 );
            TagsCheck.TabIndex = 0;
            TagsCheck.Text = "Tags";
            TagsCheck.UseVisualStyleBackColor = true;
            // 
            // Ok
            // 
            Ok.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            Ok.Location = new System.Drawing.Point( 135, 106 );
            Ok.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Ok.Name = "Ok";
            Ok.Size = new System.Drawing.Size( 88, 27 );
            Ok.TabIndex = 1;
            Ok.Text = "OK";
            Ok.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            Cancel.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Cancel.Location = new System.Drawing.Point( 230, 106 );
            Cancel.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Cancel.Name = "Cancel";
            Cancel.Size = new System.Drawing.Size( 88, 27 );
            Cancel.TabIndex = 2;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            // 
            // FastFetchDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF( 7F, 15F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size( 331, 147 );
            Controls.Add( Cancel );
            Controls.Add( Ok );
            Controls.Add( OptionsGroup );
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FastFetchDialog";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Fast Fetch";
            OptionsGroup.ResumeLayout( false );
            OptionsGroup.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)MaxProcessesNumeric ).EndInit();
            ResumeLayout( false );

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