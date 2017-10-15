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
            this.components = new System.ComponentModel.Container();
            this.Cancel = new System.Windows.Forms.Button();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.Output = new System.Windows.Forms.RichTextBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.ElapsedTimeLabel = new System.Windows.Forms.Label();
            this.ElapsedTime = new System.Windows.Forms.Label();
            this.ElapsedUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(697, 346);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Output
            // 
            this.Output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Output.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Output.Location = new System.Drawing.Point(12, 41);
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Size = new System.Drawing.Size(760, 299);
            this.Output.TabIndex = 2;
            this.Output.Text = "";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(12, 12);
            this.ProgressBar.Maximum = 0;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(760, 23);
            this.ProgressBar.Step = 1;
            this.ProgressBar.TabIndex = 3;
            // 
            // ElapsedTimeLabel
            // 
            this.ElapsedTimeLabel.AutoSize = true;
            this.ElapsedTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElapsedTimeLabel.Location = new System.Drawing.Point(12, 351);
            this.ElapsedTimeLabel.Name = "ElapsedTimeLabel";
            this.ElapsedTimeLabel.Size = new System.Drawing.Size(87, 13);
            this.ElapsedTimeLabel.TabIndex = 4;
            this.ElapsedTimeLabel.Text = "Elapsed Time:";
            // 
            // ElapsedTime
            // 
            this.ElapsedTime.AutoSize = true;
            this.ElapsedTime.Location = new System.Drawing.Point(97, 351);
            this.ElapsedTime.Name = "ElapsedTime";
            this.ElapsedTime.Size = new System.Drawing.Size(49, 13);
            this.ElapsedTime.TabIndex = 5;
            this.ElapsedTime.Text = "00:00.00";
            // 
            // ElapsedUpdateTimer
            // 
            this.ElapsedUpdateTimer.Interval = 50;
            // 
            // ProcessProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(784, 381);
            this.Controls.Add(this.ElapsedTime);
            this.Controls.Add(this.ElapsedTimeLabel);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.Cancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 150);
            this.Name = "ProcessProgressDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress";
            this.ResumeLayout(false);
            this.PerformLayout();

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