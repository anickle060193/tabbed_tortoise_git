namespace TabbedTortoiseGit
{
    partial class ReferencesDialog
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
            this.ReferencesTreeView = new System.Windows.Forms.TreeView();
            this.OuterSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ReferencesTreeTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ReferencesLabel = new System.Windows.Forms.Label();
            this.InnerSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ReferencesListTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ReferencesFilterLabel = new System.Windows.Forms.Label();
            this.ReferencesListBox = new System.Windows.Forms.ListBox();
            this.ReferencesFilterText = new System.Windows.Forms.TextBox();
            this.AddSelectedReferencesButton = new System.Windows.Forms.Button();
            this.SelectedReferencesTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SelectedReferencesListBox = new System.Windows.Forms.ListBox();
            this.SelectedReferencesLabel = new System.Windows.Forms.Label();
            this.RemoveSelectedReferencesButton = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Ok = new System.Windows.Forms.Button();
            this.AddCurrentBranchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OuterSplitContainer)).BeginInit();
            this.OuterSplitContainer.Panel1.SuspendLayout();
            this.OuterSplitContainer.Panel2.SuspendLayout();
            this.OuterSplitContainer.SuspendLayout();
            this.ReferencesTreeTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InnerSplitContainer)).BeginInit();
            this.InnerSplitContainer.Panel1.SuspendLayout();
            this.InnerSplitContainer.Panel2.SuspendLayout();
            this.InnerSplitContainer.SuspendLayout();
            this.ReferencesListTableLayout.SuspendLayout();
            this.SelectedReferencesTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReferencesTreeView
            // 
            this.ReferencesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferencesTreeView.Location = new System.Drawing.Point(3, 27);
            this.ReferencesTreeView.Name = "ReferencesTreeView";
            this.ReferencesTreeView.Size = new System.Drawing.Size(175, 378);
            this.ReferencesTreeView.TabIndex = 0;
            // 
            // OuterSplitContainer
            // 
            this.OuterSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OuterSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.OuterSplitContainer.Location = new System.Drawing.Point(12, 12);
            this.OuterSplitContainer.Name = "OuterSplitContainer";
            // 
            // OuterSplitContainer.Panel1
            // 
            this.OuterSplitContainer.Panel1.Controls.Add(this.ReferencesTreeTableLayout);
            // 
            // OuterSplitContainer.Panel2
            // 
            this.OuterSplitContainer.Panel2.Controls.Add(this.InnerSplitContainer);
            this.OuterSplitContainer.Size = new System.Drawing.Size(960, 408);
            this.OuterSplitContainer.SplitterDistance = 181;
            this.OuterSplitContainer.TabIndex = 1;
            // 
            // ReferencesTreeTableLayout
            // 
            this.ReferencesTreeTableLayout.ColumnCount = 1;
            this.ReferencesTreeTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ReferencesTreeTableLayout.Controls.Add(this.ReferencesTreeView, 0, 1);
            this.ReferencesTreeTableLayout.Controls.Add(this.ReferencesLabel, 0, 0);
            this.ReferencesTreeTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferencesTreeTableLayout.Location = new System.Drawing.Point(0, 0);
            this.ReferencesTreeTableLayout.Name = "ReferencesTreeTableLayout";
            this.ReferencesTreeTableLayout.RowCount = 2;
            this.ReferencesTreeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.ReferencesTreeTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ReferencesTreeTableLayout.Size = new System.Drawing.Size(181, 408);
            this.ReferencesTreeTableLayout.TabIndex = 4;
            // 
            // ReferencesLabel
            // 
            this.ReferencesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ReferencesLabel.AutoSize = true;
            this.ReferencesLabel.Location = new System.Drawing.Point(3, 5);
            this.ReferencesLabel.Name = "ReferencesLabel";
            this.ReferencesLabel.Size = new System.Drawing.Size(62, 13);
            this.ReferencesLabel.TabIndex = 4;
            this.ReferencesLabel.Text = "References";
            // 
            // InnerSplitContainer
            // 
            this.InnerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InnerSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.InnerSplitContainer.Name = "InnerSplitContainer";
            // 
            // InnerSplitContainer.Panel1
            // 
            this.InnerSplitContainer.Panel1.Controls.Add(this.ReferencesListTableLayout);
            // 
            // InnerSplitContainer.Panel2
            // 
            this.InnerSplitContainer.Panel2.Controls.Add(this.SelectedReferencesTableLayout);
            this.InnerSplitContainer.Size = new System.Drawing.Size(775, 408);
            this.InnerSplitContainer.SplitterDistance = 425;
            this.InnerSplitContainer.TabIndex = 0;
            // 
            // ReferencesListTableLayout
            // 
            this.ReferencesListTableLayout.ColumnCount = 2;
            this.ReferencesListTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ReferencesListTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ReferencesListTableLayout.Controls.Add(this.ReferencesFilterLabel, 0, 0);
            this.ReferencesListTableLayout.Controls.Add(this.ReferencesListBox, 0, 1);
            this.ReferencesListTableLayout.Controls.Add(this.ReferencesFilterText, 1, 0);
            this.ReferencesListTableLayout.Controls.Add(this.AddSelectedReferencesButton, 0, 2);
            this.ReferencesListTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferencesListTableLayout.Location = new System.Drawing.Point(0, 0);
            this.ReferencesListTableLayout.Name = "ReferencesListTableLayout";
            this.ReferencesListTableLayout.RowCount = 3;
            this.ReferencesListTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.ReferencesListTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ReferencesListTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ReferencesListTableLayout.Size = new System.Drawing.Size(425, 408);
            this.ReferencesListTableLayout.TabIndex = 1;
            // 
            // ReferencesFilterLabel
            // 
            this.ReferencesFilterLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ReferencesFilterLabel.AutoSize = true;
            this.ReferencesFilterLabel.Location = new System.Drawing.Point(3, 5);
            this.ReferencesFilterLabel.Name = "ReferencesFilterLabel";
            this.ReferencesFilterLabel.Size = new System.Drawing.Size(32, 13);
            this.ReferencesFilterLabel.TabIndex = 5;
            this.ReferencesFilterLabel.Text = "Filter:";
            // 
            // ReferencesListBox
            // 
            this.ReferencesListTableLayout.SetColumnSpan(this.ReferencesListBox, 2);
            this.ReferencesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferencesListBox.FormattingEnabled = true;
            this.ReferencesListBox.HorizontalScrollbar = true;
            this.ReferencesListBox.IntegralHeight = false;
            this.ReferencesListBox.Location = new System.Drawing.Point(3, 27);
            this.ReferencesListBox.Name = "ReferencesListBox";
            this.ReferencesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ReferencesListBox.Size = new System.Drawing.Size(419, 346);
            this.ReferencesListBox.TabIndex = 0;
            // 
            // ReferencesFilterText
            // 
            this.ReferencesFilterText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ReferencesFilterText.Location = new System.Drawing.Point(41, 3);
            this.ReferencesFilterText.Name = "ReferencesFilterText";
            this.ReferencesFilterText.Size = new System.Drawing.Size(381, 20);
            this.ReferencesFilterText.TabIndex = 6;
            // 
            // AddSelectedReferencesButton
            // 
            this.AddSelectedReferencesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ReferencesListTableLayout.SetColumnSpan(this.AddSelectedReferencesButton, 2);
            this.AddSelectedReferencesButton.Location = new System.Drawing.Point(3, 379);
            this.AddSelectedReferencesButton.Name = "AddSelectedReferencesButton";
            this.AddSelectedReferencesButton.Size = new System.Drawing.Size(419, 26);
            this.AddSelectedReferencesButton.TabIndex = 7;
            this.AddSelectedReferencesButton.Text = "Add Selected References";
            this.AddSelectedReferencesButton.UseVisualStyleBackColor = true;
            // 
            // SelectedReferencesTableLayout
            // 
            this.SelectedReferencesTableLayout.ColumnCount = 1;
            this.SelectedReferencesTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SelectedReferencesTableLayout.Controls.Add(this.SelectedReferencesListBox, 0, 1);
            this.SelectedReferencesTableLayout.Controls.Add(this.SelectedReferencesLabel, 0, 0);
            this.SelectedReferencesTableLayout.Controls.Add(this.RemoveSelectedReferencesButton, 0, 2);
            this.SelectedReferencesTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectedReferencesTableLayout.Location = new System.Drawing.Point(0, 0);
            this.SelectedReferencesTableLayout.Name = "SelectedReferencesTableLayout";
            this.SelectedReferencesTableLayout.RowCount = 3;
            this.SelectedReferencesTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.SelectedReferencesTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SelectedReferencesTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SelectedReferencesTableLayout.Size = new System.Drawing.Size(346, 408);
            this.SelectedReferencesTableLayout.TabIndex = 4;
            // 
            // SelectedReferencesListBox
            // 
            this.SelectedReferencesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectedReferencesListBox.FormatString = "long";
            this.SelectedReferencesListBox.FormattingEnabled = true;
            this.SelectedReferencesListBox.HorizontalScrollbar = true;
            this.SelectedReferencesListBox.IntegralHeight = false;
            this.SelectedReferencesListBox.Location = new System.Drawing.Point(3, 27);
            this.SelectedReferencesListBox.Name = "SelectedReferencesListBox";
            this.SelectedReferencesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.SelectedReferencesListBox.Size = new System.Drawing.Size(340, 346);
            this.SelectedReferencesListBox.TabIndex = 1;
            // 
            // SelectedReferencesLabel
            // 
            this.SelectedReferencesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SelectedReferencesLabel.AutoSize = true;
            this.SelectedReferencesLabel.Location = new System.Drawing.Point(3, 5);
            this.SelectedReferencesLabel.Name = "SelectedReferencesLabel";
            this.SelectedReferencesLabel.Size = new System.Drawing.Size(107, 13);
            this.SelectedReferencesLabel.TabIndex = 2;
            this.SelectedReferencesLabel.Text = "Selected References";
            // 
            // RemoveSelectedReferencesButton
            // 
            this.RemoveSelectedReferencesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveSelectedReferencesButton.Location = new System.Drawing.Point(3, 379);
            this.RemoveSelectedReferencesButton.Name = "RemoveSelectedReferencesButton";
            this.RemoveSelectedReferencesButton.Size = new System.Drawing.Size(340, 26);
            this.RemoveSelectedReferencesButton.TabIndex = 3;
            this.RemoveSelectedReferencesButton.Text = "Remove Selected References";
            this.RemoveSelectedReferencesButton.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(897, 426);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Ok
            // 
            this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok.Location = new System.Drawing.Point(816, 426);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 3;
            this.Ok.Text = "OK";
            this.Ok.UseVisualStyleBackColor = true;
            // 
            // AddCurrentBranchButton
            // 
            this.AddCurrentBranchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddCurrentBranchButton.Location = new System.Drawing.Point(15, 426);
            this.AddCurrentBranchButton.Name = "AddCurrentBranchButton";
            this.AddCurrentBranchButton.Size = new System.Drawing.Size(175, 23);
            this.AddCurrentBranchButton.TabIndex = 8;
            this.AddCurrentBranchButton.Text = "Add Current Branch";
            this.AddCurrentBranchButton.UseVisualStyleBackColor = true;
            // 
            // ReferencesDialog
            // 
            this.AcceptButton = this.Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.AddCurrentBranchButton);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OuterSplitContainer);
            this.Name = "ReferencesDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select References";
            this.OuterSplitContainer.Panel1.ResumeLayout(false);
            this.OuterSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OuterSplitContainer)).EndInit();
            this.OuterSplitContainer.ResumeLayout(false);
            this.ReferencesTreeTableLayout.ResumeLayout(false);
            this.ReferencesTreeTableLayout.PerformLayout();
            this.InnerSplitContainer.Panel1.ResumeLayout(false);
            this.InnerSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InnerSplitContainer)).EndInit();
            this.InnerSplitContainer.ResumeLayout(false);
            this.ReferencesListTableLayout.ResumeLayout(false);
            this.ReferencesListTableLayout.PerformLayout();
            this.SelectedReferencesTableLayout.ResumeLayout(false);
            this.SelectedReferencesTableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView ReferencesTreeView;
        private System.Windows.Forms.SplitContainer OuterSplitContainer;
        private System.Windows.Forms.SplitContainer InnerSplitContainer;
        private System.Windows.Forms.ListBox ReferencesListBox;
        private System.Windows.Forms.ListBox SelectedReferencesListBox;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.TableLayoutPanel ReferencesListTableLayout;
        private System.Windows.Forms.Label ReferencesFilterLabel;
        private System.Windows.Forms.TextBox ReferencesFilterText;
        private System.Windows.Forms.Label ReferencesLabel;
        private System.Windows.Forms.Label SelectedReferencesLabel;
        private System.Windows.Forms.TableLayoutPanel ReferencesTreeTableLayout;
        private System.Windows.Forms.TableLayoutPanel SelectedReferencesTableLayout;
        private System.Windows.Forms.Button AddSelectedReferencesButton;
        private System.Windows.Forms.Button RemoveSelectedReferencesButton;
        private System.Windows.Forms.Button AddCurrentBranchButton;
    }
}