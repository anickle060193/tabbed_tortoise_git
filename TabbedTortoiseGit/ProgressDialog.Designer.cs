namespace TabbedTortoiseGit
{
    partial class ProgressDialog
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
            components = new System.ComponentModel.Container();
            Cancel = new System.Windows.Forms.Button();
            Worker = new System.ComponentModel.BackgroundWorker();
            Output = new System.Windows.Forms.RichTextBox();
            ProgressBar = new System.Windows.Forms.ProgressBar();
            ElapsedTimeLabel = new System.Windows.Forms.Label();
            ElapsedTime = new System.Windows.Forms.Label();
            ElapsedUpdateTimer = new System.Windows.Forms.Timer( components );
            SuspendLayout();
            // 
            // Cancel
            // 
            Cancel.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Cancel.Location = new System.Drawing.Point( 813, 399 );
            Cancel.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Cancel.Name = "Cancel";
            Cancel.Size = new System.Drawing.Size( 88, 27 );
            Cancel.TabIndex = 1;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            // 
            // Output
            // 
            Output.Anchor =    System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Bottom   |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            Output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Output.Font = new System.Drawing.Font( "Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0 );
            Output.Location = new System.Drawing.Point( 14, 47 );
            Output.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Output.Name = "Output";
            Output.ReadOnly = true;
            Output.Size = new System.Drawing.Size( 886, 344 );
            Output.TabIndex = 2;
            Output.Text = "";
            // 
            // ProgressBar
            // 
            ProgressBar.Location = new System.Drawing.Point( 14, 14 );
            ProgressBar.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ProgressBar.Maximum = 0;
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new System.Drawing.Size( 887, 27 );
            ProgressBar.Step = 1;
            ProgressBar.TabIndex = 3;
            // 
            // ElapsedTimeLabel
            // 
            ElapsedTimeLabel.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left ;
            ElapsedTimeLabel.AutoSize = true;
            ElapsedTimeLabel.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0 );
            ElapsedTimeLabel.Location = new System.Drawing.Point( 14, 405 );
            ElapsedTimeLabel.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            ElapsedTimeLabel.Name = "ElapsedTimeLabel";
            ElapsedTimeLabel.Size = new System.Drawing.Size( 87, 13 );
            ElapsedTimeLabel.TabIndex = 4;
            ElapsedTimeLabel.Text = "Elapsed Time:";
            // 
            // ElapsedTime
            // 
            ElapsedTime.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left ;
            ElapsedTime.AutoSize = true;
            ElapsedTime.Location = new System.Drawing.Point( 122, 405 );
            ElapsedTime.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            ElapsedTime.Name = "ElapsedTime";
            ElapsedTime.Size = new System.Drawing.Size( 49, 15 );
            ElapsedTime.TabIndex = 5;
            ElapsedTime.Text = "00:00.00";
            // 
            // ElapsedUpdateTimer
            // 
            ElapsedUpdateTimer.Interval = 50;
            // 
            // ProgressDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF( 7F, 15F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = Cancel;
            ClientSize = new System.Drawing.Size( 915, 440 );
            Controls.Add( ElapsedTime );
            Controls.Add( ElapsedTimeLabel );
            Controls.Add( ProgressBar );
            Controls.Add( Output );
            Controls.Add( Cancel );
            Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size( 289, 167 );
            Name = "ProgressDialog";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Progress";
            ResumeLayout( false );
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Cancel;
        private System.ComponentModel.BackgroundWorker Worker;
        private System.Windows.Forms.RichTextBox Output;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label ElapsedTimeLabel;
        private System.Windows.Forms.Label ElapsedTime;
        private System.Windows.Forms.Timer ElapsedUpdateTimer;
    }
}