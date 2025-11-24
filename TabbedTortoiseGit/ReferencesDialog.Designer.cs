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
            ReferencesTreeView = new System.Windows.Forms.TreeView();
            OuterSplitContainer = new System.Windows.Forms.SplitContainer();
            ReferencesTreeTableLayout = new System.Windows.Forms.TableLayoutPanel();
            ReferencesLabel = new System.Windows.Forms.Label();
            InnerSplitContainer = new System.Windows.Forms.SplitContainer();
            ReferencesListTableLayout = new System.Windows.Forms.TableLayoutPanel();
            ReferencesFilterLabel = new System.Windows.Forms.Label();
            ReferencesListBox = new System.Windows.Forms.ListBox();
            ReferencesFilterText = new System.Windows.Forms.TextBox();
            AddSelectedReferencesButton = new System.Windows.Forms.Button();
            SelectedReferencesTableLayout = new System.Windows.Forms.TableLayoutPanel();
            SelectedReferencesListBox = new System.Windows.Forms.ListBox();
            SelectedReferencesLabel = new System.Windows.Forms.Label();
            RemoveSelectedReferencesButton = new System.Windows.Forms.Button();
            Cancel = new System.Windows.Forms.Button();
            Ok = new System.Windows.Forms.Button();
            AddCurrentBranchButton = new System.Windows.Forms.Button();
            ( (System.ComponentModel.ISupportInitialize)OuterSplitContainer ).BeginInit();
            OuterSplitContainer.Panel1.SuspendLayout();
            OuterSplitContainer.Panel2.SuspendLayout();
            OuterSplitContainer.SuspendLayout();
            ReferencesTreeTableLayout.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)InnerSplitContainer ).BeginInit();
            InnerSplitContainer.Panel1.SuspendLayout();
            InnerSplitContainer.Panel2.SuspendLayout();
            InnerSplitContainer.SuspendLayout();
            ReferencesListTableLayout.SuspendLayout();
            SelectedReferencesTableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // ReferencesTreeView
            // 
            ReferencesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            ReferencesTreeView.Location = new System.Drawing.Point( 4, 31 );
            ReferencesTreeView.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ReferencesTreeView.Name = "ReferencesTreeView";
            ReferencesTreeView.Size = new System.Drawing.Size( 203, 437 );
            ReferencesTreeView.TabIndex = 0;
            // 
            // OuterSplitContainer
            // 
            OuterSplitContainer.Anchor =    System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Bottom   |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            OuterSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            OuterSplitContainer.Location = new System.Drawing.Point( 14, 14 );
            OuterSplitContainer.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            OuterSplitContainer.Name = "OuterSplitContainer";
            // 
            // OuterSplitContainer.Panel1
            // 
            OuterSplitContainer.Panel1.Controls.Add( ReferencesTreeTableLayout );
            // 
            // OuterSplitContainer.Panel2
            // 
            OuterSplitContainer.Panel2.Controls.Add( InnerSplitContainer );
            OuterSplitContainer.Size = new System.Drawing.Size( 1120, 471 );
            OuterSplitContainer.SplitterDistance = 211;
            OuterSplitContainer.SplitterWidth = 5;
            OuterSplitContainer.TabIndex = 1;
            // 
            // ReferencesTreeTableLayout
            // 
            ReferencesTreeTableLayout.ColumnCount = 1;
            ReferencesTreeTableLayout.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
            ReferencesTreeTableLayout.Controls.Add( ReferencesTreeView, 0, 1 );
            ReferencesTreeTableLayout.Controls.Add( ReferencesLabel, 0, 0 );
            ReferencesTreeTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            ReferencesTreeTableLayout.Location = new System.Drawing.Point( 0, 0 );
            ReferencesTreeTableLayout.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ReferencesTreeTableLayout.Name = "ReferencesTreeTableLayout";
            ReferencesTreeTableLayout.RowCount = 2;
            ReferencesTreeTableLayout.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 28F ) );
            ReferencesTreeTableLayout.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
            ReferencesTreeTableLayout.Size = new System.Drawing.Size( 211, 471 );
            ReferencesTreeTableLayout.TabIndex = 4;
            // 
            // ReferencesLabel
            // 
            ReferencesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            ReferencesLabel.AutoSize = true;
            ReferencesLabel.Location = new System.Drawing.Point( 4, 6 );
            ReferencesLabel.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            ReferencesLabel.Name = "ReferencesLabel";
            ReferencesLabel.Size = new System.Drawing.Size( 64, 15 );
            ReferencesLabel.TabIndex = 4;
            ReferencesLabel.Text = "References";
            // 
            // InnerSplitContainer
            // 
            InnerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            InnerSplitContainer.Location = new System.Drawing.Point( 0, 0 );
            InnerSplitContainer.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            InnerSplitContainer.Name = "InnerSplitContainer";
            // 
            // InnerSplitContainer.Panel1
            // 
            InnerSplitContainer.Panel1.Controls.Add( ReferencesListTableLayout );
            // 
            // InnerSplitContainer.Panel2
            // 
            InnerSplitContainer.Panel2.Controls.Add( SelectedReferencesTableLayout );
            InnerSplitContainer.Size = new System.Drawing.Size( 904, 471 );
            InnerSplitContainer.SplitterDistance = 495;
            InnerSplitContainer.SplitterWidth = 5;
            InnerSplitContainer.TabIndex = 0;
            // 
            // ReferencesListTableLayout
            // 
            ReferencesListTableLayout.ColumnCount = 2;
            ReferencesListTableLayout.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
            ReferencesListTableLayout.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
            ReferencesListTableLayout.Controls.Add( ReferencesFilterLabel, 0, 0 );
            ReferencesListTableLayout.Controls.Add( ReferencesListBox, 0, 1 );
            ReferencesListTableLayout.Controls.Add( ReferencesFilterText, 1, 0 );
            ReferencesListTableLayout.Controls.Add( AddSelectedReferencesButton, 0, 2 );
            ReferencesListTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            ReferencesListTableLayout.Location = new System.Drawing.Point( 0, 0 );
            ReferencesListTableLayout.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ReferencesListTableLayout.Name = "ReferencesListTableLayout";
            ReferencesListTableLayout.RowCount = 3;
            ReferencesListTableLayout.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 28F ) );
            ReferencesListTableLayout.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
            ReferencesListTableLayout.RowStyles.Add( new System.Windows.Forms.RowStyle() );
            ReferencesListTableLayout.Size = new System.Drawing.Size( 495, 471 );
            ReferencesListTableLayout.TabIndex = 1;
            // 
            // ReferencesFilterLabel
            // 
            ReferencesFilterLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            ReferencesFilterLabel.AutoSize = true;
            ReferencesFilterLabel.Location = new System.Drawing.Point( 4, 6 );
            ReferencesFilterLabel.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            ReferencesFilterLabel.Name = "ReferencesFilterLabel";
            ReferencesFilterLabel.Size = new System.Drawing.Size( 36, 15 );
            ReferencesFilterLabel.TabIndex = 5;
            ReferencesFilterLabel.Text = "Filter:";
            // 
            // ReferencesListBox
            // 
            ReferencesListTableLayout.SetColumnSpan( ReferencesListBox, 2 );
            ReferencesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            ReferencesListBox.FormattingEnabled = true;
            ReferencesListBox.HorizontalScrollbar = true;
            ReferencesListBox.IntegralHeight = false;
            ReferencesListBox.Location = new System.Drawing.Point( 4, 31 );
            ReferencesListBox.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ReferencesListBox.Name = "ReferencesListBox";
            ReferencesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            ReferencesListBox.Size = new System.Drawing.Size( 487, 401 );
            ReferencesListBox.TabIndex = 0;
            // 
            // ReferencesFilterText
            // 
            ReferencesFilterText.Anchor =  System.Windows.Forms.AnchorStyles.Left  |  System.Windows.Forms.AnchorStyles.Right ;
            ReferencesFilterText.Location = new System.Drawing.Point( 48, 3 );
            ReferencesFilterText.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            ReferencesFilterText.Name = "ReferencesFilterText";
            ReferencesFilterText.Size = new System.Drawing.Size( 443, 23 );
            ReferencesFilterText.TabIndex = 6;
            // 
            // AddSelectedReferencesButton
            // 
            AddSelectedReferencesButton.Anchor =  System.Windows.Forms.AnchorStyles.Left  |  System.Windows.Forms.AnchorStyles.Right ;
            ReferencesListTableLayout.SetColumnSpan( AddSelectedReferencesButton, 2 );
            AddSelectedReferencesButton.Location = new System.Drawing.Point( 4, 438 );
            AddSelectedReferencesButton.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            AddSelectedReferencesButton.Name = "AddSelectedReferencesButton";
            AddSelectedReferencesButton.Size = new System.Drawing.Size( 487, 30 );
            AddSelectedReferencesButton.TabIndex = 7;
            AddSelectedReferencesButton.Text = "Add Selected References";
            AddSelectedReferencesButton.UseVisualStyleBackColor = true;
            // 
            // SelectedReferencesTableLayout
            // 
            SelectedReferencesTableLayout.ColumnCount = 1;
            SelectedReferencesTableLayout.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
            SelectedReferencesTableLayout.Controls.Add( SelectedReferencesListBox, 0, 1 );
            SelectedReferencesTableLayout.Controls.Add( SelectedReferencesLabel, 0, 0 );
            SelectedReferencesTableLayout.Controls.Add( RemoveSelectedReferencesButton, 0, 2 );
            SelectedReferencesTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            SelectedReferencesTableLayout.Location = new System.Drawing.Point( 0, 0 );
            SelectedReferencesTableLayout.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            SelectedReferencesTableLayout.Name = "SelectedReferencesTableLayout";
            SelectedReferencesTableLayout.RowCount = 3;
            SelectedReferencesTableLayout.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 28F ) );
            SelectedReferencesTableLayout.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
            SelectedReferencesTableLayout.RowStyles.Add( new System.Windows.Forms.RowStyle() );
            SelectedReferencesTableLayout.Size = new System.Drawing.Size( 404, 471 );
            SelectedReferencesTableLayout.TabIndex = 4;
            // 
            // SelectedReferencesListBox
            // 
            SelectedReferencesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            SelectedReferencesListBox.FormatString = "long";
            SelectedReferencesListBox.FormattingEnabled = true;
            SelectedReferencesListBox.HorizontalScrollbar = true;
            SelectedReferencesListBox.IntegralHeight = false;
            SelectedReferencesListBox.Location = new System.Drawing.Point( 4, 31 );
            SelectedReferencesListBox.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            SelectedReferencesListBox.Name = "SelectedReferencesListBox";
            SelectedReferencesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            SelectedReferencesListBox.Size = new System.Drawing.Size( 396, 401 );
            SelectedReferencesListBox.TabIndex = 1;
            // 
            // SelectedReferencesLabel
            // 
            SelectedReferencesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            SelectedReferencesLabel.AutoSize = true;
            SelectedReferencesLabel.Location = new System.Drawing.Point( 4, 6 );
            SelectedReferencesLabel.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            SelectedReferencesLabel.Name = "SelectedReferencesLabel";
            SelectedReferencesLabel.Size = new System.Drawing.Size( 111, 15 );
            SelectedReferencesLabel.TabIndex = 2;
            SelectedReferencesLabel.Text = "Selected References";
            // 
            // RemoveSelectedReferencesButton
            // 
            RemoveSelectedReferencesButton.Anchor =  System.Windows.Forms.AnchorStyles.Left  |  System.Windows.Forms.AnchorStyles.Right ;
            RemoveSelectedReferencesButton.Location = new System.Drawing.Point( 4, 438 );
            RemoveSelectedReferencesButton.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            RemoveSelectedReferencesButton.Name = "RemoveSelectedReferencesButton";
            RemoveSelectedReferencesButton.Size = new System.Drawing.Size( 396, 30 );
            RemoveSelectedReferencesButton.TabIndex = 3;
            RemoveSelectedReferencesButton.Text = "Remove Selected References";
            RemoveSelectedReferencesButton.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            Cancel.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Cancel.Location = new System.Drawing.Point( 1046, 492 );
            Cancel.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Cancel.Name = "Cancel";
            Cancel.Size = new System.Drawing.Size( 88, 27 );
            Cancel.TabIndex = 2;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            // 
            // Ok
            // 
            Ok.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            Ok.Location = new System.Drawing.Point( 952, 492 );
            Ok.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Ok.Name = "Ok";
            Ok.Size = new System.Drawing.Size( 88, 27 );
            Ok.TabIndex = 3;
            Ok.Text = "OK";
            Ok.UseVisualStyleBackColor = true;
            // 
            // AddCurrentBranchButton
            // 
            AddCurrentBranchButton.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left ;
            AddCurrentBranchButton.Location = new System.Drawing.Point( 18, 492 );
            AddCurrentBranchButton.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            AddCurrentBranchButton.Name = "AddCurrentBranchButton";
            AddCurrentBranchButton.Size = new System.Drawing.Size( 204, 27 );
            AddCurrentBranchButton.TabIndex = 8;
            AddCurrentBranchButton.Text = "Add Current Branch";
            AddCurrentBranchButton.UseVisualStyleBackColor = true;
            // 
            // ReferencesDialog
            // 
            AcceptButton = Ok;
            AutoScaleDimensions = new System.Drawing.SizeF( 7F, 15F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = Cancel;
            ClientSize = new System.Drawing.Size( 1148, 532 );
            Controls.Add( AddCurrentBranchButton );
            Controls.Add( Ok );
            Controls.Add( Cancel );
            Controls.Add( OuterSplitContainer );
            Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            Name = "ReferencesDialog";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Select References";
            OuterSplitContainer.Panel1.ResumeLayout( false );
            OuterSplitContainer.Panel2.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)OuterSplitContainer ).EndInit();
            OuterSplitContainer.ResumeLayout( false );
            ReferencesTreeTableLayout.ResumeLayout( false );
            ReferencesTreeTableLayout.PerformLayout();
            InnerSplitContainer.Panel1.ResumeLayout( false );
            InnerSplitContainer.Panel2.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)InnerSplitContainer ).EndInit();
            InnerSplitContainer.ResumeLayout( false );
            ReferencesListTableLayout.ResumeLayout( false );
            ReferencesListTableLayout.PerformLayout();
            SelectedReferencesTableLayout.ResumeLayout( false );
            SelectedReferencesTableLayout.PerformLayout();
            ResumeLayout( false );

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