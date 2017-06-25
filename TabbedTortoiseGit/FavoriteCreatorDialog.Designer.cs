namespace TabbedTortoiseGit
{
    partial class FavoriteCreatorDialog
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
            this.FavoriteColorDialog = new System.Windows.Forms.ColorDialog();
            this.ChangeFavoriteColorButton = new System.Windows.Forms.Button();
            this.FavoriteNameText = new System.Windows.Forms.TextBox();
            this.Ok = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.FavoriteNameLabel = new System.Windows.Forms.Label();
            this.ReferencesListBox = new System.Windows.Forms.ListBox();
            this.ReferencesGroup = new System.Windows.Forms.GroupBox();
            this.SelectReferencesButton = new System.Windows.Forms.Button();
            this.RemoveReferencesButton = new System.Windows.Forms.Button();
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ReferencesGroup.SuspendLayout();
            this.TableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // FavoriteColorDialog
            // 
            this.FavoriteColorDialog.AnyColor = true;
            // 
            // ChangeFavoriteColorButton
            // 
            this.ChangeFavoriteColorButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ChangeFavoriteColorButton.Location = new System.Drawing.Point(3, 154);
            this.ChangeFavoriteColorButton.Name = "ChangeFavoriteColorButton";
            this.ChangeFavoriteColorButton.Size = new System.Drawing.Size(30, 30);
            this.ChangeFavoriteColorButton.TabIndex = 1;
            this.ChangeFavoriteColorButton.UseVisualStyleBackColor = false;
            // 
            // FavoriteNameText
            // 
            this.FavoriteNameText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayout.SetColumnSpan(this.FavoriteNameText, 2);
            this.FavoriteNameText.Location = new System.Drawing.Point(88, 3);
            this.FavoriteNameText.Name = "FavoriteNameText";
            this.FavoriteNameText.Size = new System.Drawing.Size(244, 20);
            this.FavoriteNameText.TabIndex = 0;
            // 
            // Ok
            // 
            this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok.Location = new System.Drawing.Point(176, 161);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 2;
            this.Ok.Text = "OK";
            this.Ok.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(257, 161);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // FavoriteNameLabel
            // 
            this.FavoriteNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FavoriteNameLabel.AutoSize = true;
            this.FavoriteNameLabel.Location = new System.Drawing.Point(3, 6);
            this.FavoriteNameLabel.Name = "FavoriteNameLabel";
            this.FavoriteNameLabel.Size = new System.Drawing.Size(79, 13);
            this.FavoriteNameLabel.TabIndex = 4;
            this.FavoriteNameLabel.Text = "Favorite Name:";
            // 
            // ReferencesListBox
            // 
            this.ReferencesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReferencesListBox.FormattingEnabled = true;
            this.ReferencesListBox.IntegralHeight = false;
            this.ReferencesListBox.Location = new System.Drawing.Point(6, 19);
            this.ReferencesListBox.Name = "ReferencesListBox";
            this.ReferencesListBox.Size = new System.Drawing.Size(317, 65);
            this.ReferencesListBox.TabIndex = 1;
            // 
            // ReferencesGroup
            // 
            this.TableLayout.SetColumnSpan(this.ReferencesGroup, 3);
            this.ReferencesGroup.Controls.Add(this.SelectReferencesButton);
            this.ReferencesGroup.Controls.Add(this.RemoveReferencesButton);
            this.ReferencesGroup.Controls.Add(this.ReferencesListBox);
            this.ReferencesGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferencesGroup.Location = new System.Drawing.Point(3, 29);
            this.ReferencesGroup.Name = "ReferencesGroup";
            this.ReferencesGroup.Size = new System.Drawing.Size(329, 119);
            this.ReferencesGroup.TabIndex = 5;
            this.ReferencesGroup.TabStop = false;
            this.ReferencesGroup.Text = "References";
            // 
            // SelectReferencesButton
            // 
            this.SelectReferencesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectReferencesButton.Location = new System.Drawing.Point(218, 90);
            this.SelectReferencesButton.Name = "SelectReferencesButton";
            this.SelectReferencesButton.Size = new System.Drawing.Size(105, 23);
            this.SelectReferencesButton.TabIndex = 4;
            this.SelectReferencesButton.Text = "Select References";
            this.SelectReferencesButton.UseVisualStyleBackColor = true;
            // 
            // RemoveReferencesButton
            // 
            this.RemoveReferencesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveReferencesButton.Location = new System.Drawing.Point(6, 90);
            this.RemoveReferencesButton.Name = "RemoveReferencesButton";
            this.RemoveReferencesButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveReferencesButton.TabIndex = 3;
            this.RemoveReferencesButton.Text = "Remove";
            this.RemoveReferencesButton.UseVisualStyleBackColor = true;
            // 
            // TableLayout
            // 
            this.TableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayout.AutoSize = true;
            this.TableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayout.ColumnCount = 3;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout.Controls.Add(this.FavoriteNameLabel, 0, 0);
            this.TableLayout.Controls.Add(this.Ok, 1, 2);
            this.TableLayout.Controls.Add(this.Cancel, 2, 2);
            this.TableLayout.Controls.Add(this.ReferencesGroup, 0, 1);
            this.TableLayout.Controls.Add(this.FavoriteNameText, 1, 0);
            this.TableLayout.Controls.Add(this.ChangeFavoriteColorButton, 0, 2);
            this.TableLayout.Location = new System.Drawing.Point(12, 12);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 3;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayout.Size = new System.Drawing.Size(335, 187);
            this.TableLayout.TabIndex = 6;
            // 
            // FavoriteCreatorDialog
            // 
            this.AcceptButton = this.Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(359, 211);
            this.Controls.Add(this.TableLayout);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(270, 250);
            this.Name = "FavoriteCreatorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Favorite Creator";
            this.ReferencesGroup.ResumeLayout(false);
            this.TableLayout.ResumeLayout(false);
            this.TableLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog FavoriteColorDialog;
        private System.Windows.Forms.Button ChangeFavoriteColorButton;
        private System.Windows.Forms.TextBox FavoriteNameText;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label FavoriteNameLabel;
        private System.Windows.Forms.ListBox ReferencesListBox;
        private System.Windows.Forms.GroupBox ReferencesGroup;
        private System.Windows.Forms.Button RemoveReferencesButton;
        private System.Windows.Forms.Button SelectReferencesButton;
        private System.Windows.Forms.TableLayoutPanel TableLayout;
    }
}