using System.Windows.Forms;

namespace TabbedTortoiseGit
{
    partial class SettingsForm
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
            this.StartupReposList = new System.Windows.Forms.ListBox();
            this.AddDefaultRepo = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.RemoveDefaultRepo = new System.Windows.Forms.Button();
            this.OpenStartupReposOnReOpenCheck = new System.Windows.Forms.CheckBox();
            this.RunOnStartupCheck = new System.Windows.Forms.CheckBox();
            this.ConfirmOnCloseCheck = new System.Windows.Forms.CheckBox();
            this.MaxRecentReposNumeric = new System.Windows.Forms.NumericUpDown();
            this.MaxRecentReposLabel = new System.Windows.Forms.Label();
            this.GitActionsLabel = new System.Windows.Forms.Label();
            this.GitActionsCheckList = new System.Windows.Forms.CheckedListBox();
            this.SettingsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SettingsTabs = new System.Windows.Forms.TabControl();
            this.KeyboardShortcutsPage = new System.Windows.Forms.TabPage();
            this.KeyBoardShortcutsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.StartupReposTab = new System.Windows.Forms.TabPage();
            this.GitActionsTab = new System.Windows.Forms.TabPage();
            this.GitActionsOptionsGroup = new System.Windows.Forms.GroupBox();
            this.ConfirmFasterFetchCheck = new System.Windows.Forms.CheckBox();
            this.CustomActionsTab = new System.Windows.Forms.TabPage();
            this.EditCustomAction = new System.Windows.Forms.Button();
            this.RemoveCustomAction = new System.Windows.Forms.Button();
            this.CreateCustomAction = new System.Windows.Forms.Button();
            this.CustomActionsDataGridView = new System.Windows.Forms.DataGridView();
            this.CustomActionNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomActionProgramColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomActionArgumentsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkingDirectory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefreshLogAfter = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ShowProgressDialog = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CreateNoWindow = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DisplaySettingsTab = new System.Windows.Forms.TabPage();
            this.ResetNormalTabFontButton = new System.Windows.Forms.Button();
            this.ChangeNormalTabFontButton = new System.Windows.Forms.Button();
            this.NormalTabFontGroup = new System.Windows.Forms.GroupBox();
            this.NormalTabFontSample = new System.Windows.Forms.Label();
            this.CheckForModifiedTabsIntervalLabel = new System.Windows.Forms.Label();
            this.CheckForModifiedTabsIntervalNumeric = new System.Windows.Forms.NumericUpDown();
            this.IndicateModifiedTabsCheck = new System.Windows.Forms.CheckBox();
            this.ResetModifiedTabFontButton = new System.Windows.Forms.Button();
            this.ChangeModifiedTabFontButton = new System.Windows.Forms.Button();
            this.ModifiedTabFontGroup = new System.Windows.Forms.GroupBox();
            this.ModifiedTabFontSample = new System.Windows.Forms.Label();
            this.OtherSettingsTab = new System.Windows.Forms.TabPage();
            this.CloseWindowOnLastTabClosedCheck = new System.Windows.Forms.CheckBox();
            this.CloseToSystemTrayCheck = new System.Windows.Forms.CheckBox();
            this.DeveloperSettingsPage = new System.Windows.Forms.TabPage();
            this.ShowHitTestCheck = new System.Windows.Forms.CheckBox();
            this.ModifiedTabFontDialog = new System.Windows.Forms.FontDialog();
            this.NormalTabFontDialog = new System.Windows.Forms.FontDialog();
            this.CheckTortoiseGitOnPathCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.MaxRecentReposNumeric)).BeginInit();
            this.SettingsTabs.SuspendLayout();
            this.KeyboardShortcutsPage.SuspendLayout();
            this.StartupReposTab.SuspendLayout();
            this.GitActionsTab.SuspendLayout();
            this.GitActionsOptionsGroup.SuspendLayout();
            this.CustomActionsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomActionsDataGridView)).BeginInit();
            this.DisplaySettingsTab.SuspendLayout();
            this.NormalTabFontGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckForModifiedTabsIntervalNumeric)).BeginInit();
            this.ModifiedTabFontGroup.SuspendLayout();
            this.OtherSettingsTab.SuspendLayout();
            this.DeveloperSettingsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartupReposList
            // 
            this.StartupReposList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartupReposList.FormattingEnabled = true;
            this.StartupReposList.IntegralHeight = false;
            this.StartupReposList.Location = new System.Drawing.Point(6, 6);
            this.StartupReposList.Name = "StartupReposList";
            this.StartupReposList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.StartupReposList.Size = new System.Drawing.Size(589, 264);
            this.StartupReposList.TabIndex = 1;
            // 
            // AddDefaultRepo
            // 
            this.AddDefaultRepo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddDefaultRepo.Location = new System.Drawing.Point(97, 276);
            this.AddDefaultRepo.Name = "AddDefaultRepo";
            this.AddDefaultRepo.Size = new System.Drawing.Size(85, 23);
            this.AddDefaultRepo.TabIndex = 2;
            this.AddDefaultRepo.Text = "Add Repo";
            this.AddDefaultRepo.UseVisualStyleBackColor = true;
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(566, 376);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 3;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(647, 376);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // RemoveDefaultRepo
            // 
            this.RemoveDefaultRepo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveDefaultRepo.Location = new System.Drawing.Point(6, 276);
            this.RemoveDefaultRepo.Name = "RemoveDefaultRepo";
            this.RemoveDefaultRepo.Size = new System.Drawing.Size(85, 23);
            this.RemoveDefaultRepo.TabIndex = 5;
            this.RemoveDefaultRepo.Text = "Remove Repo";
            this.RemoveDefaultRepo.UseVisualStyleBackColor = true;
            // 
            // OpenStartupReposOnReOpenCheck
            // 
            this.OpenStartupReposOnReOpenCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OpenStartupReposOnReOpenCheck.AutoSize = true;
            this.OpenStartupReposOnReOpenCheck.Location = new System.Drawing.Point(6, 305);
            this.OpenStartupReposOnReOpenCheck.Name = "OpenStartupReposOnReOpenCheck";
            this.OpenStartupReposOnReOpenCheck.Size = new System.Drawing.Size(277, 17);
            this.OpenStartupReposOnReOpenCheck.TabIndex = 6;
            this.OpenStartupReposOnReOpenCheck.Text = "Open Startup Repos when re-opened from Task Tray";
            this.SettingsToolTip.SetToolTip(this.OpenStartupReposOnReOpenCheck, "Only valid when \"Retain Logs on Close\" is disabled.");
            this.OpenStartupReposOnReOpenCheck.UseVisualStyleBackColor = true;
            // 
            // RunOnStartupCheck
            // 
            this.RunOnStartupCheck.AutoSize = true;
            this.RunOnStartupCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RunOnStartupCheck.Location = new System.Drawing.Point(6, 101);
            this.RunOnStartupCheck.Name = "RunOnStartupCheck";
            this.RunOnStartupCheck.Size = new System.Drawing.Size(99, 17);
            this.RunOnStartupCheck.TabIndex = 11;
            this.RunOnStartupCheck.Text = "Run on startup:";
            this.RunOnStartupCheck.UseVisualStyleBackColor = true;
            // 
            // ConfirmOnCloseCheck
            // 
            this.ConfirmOnCloseCheck.AutoSize = true;
            this.ConfirmOnCloseCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ConfirmOnCloseCheck.Location = new System.Drawing.Point(6, 32);
            this.ConfirmOnCloseCheck.Name = "ConfirmOnCloseCheck";
            this.ConfirmOnCloseCheck.Size = new System.Drawing.Size(133, 17);
            this.ConfirmOnCloseCheck.TabIndex = 10;
            this.ConfirmOnCloseCheck.Text = "Prompt Before Closing:";
            this.ConfirmOnCloseCheck.UseVisualStyleBackColor = true;
            // 
            // MaxRecentReposNumeric
            // 
            this.MaxRecentReposNumeric.Location = new System.Drawing.Point(114, 6);
            this.MaxRecentReposNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxRecentReposNumeric.Name = "MaxRecentReposNumeric";
            this.MaxRecentReposNumeric.Size = new System.Drawing.Size(44, 20);
            this.MaxRecentReposNumeric.TabIndex = 9;
            this.MaxRecentReposNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MaxRecentReposLabel
            // 
            this.MaxRecentReposLabel.AutoSize = true;
            this.MaxRecentReposLabel.Location = new System.Drawing.Point(6, 6);
            this.MaxRecentReposLabel.Name = "MaxRecentReposLabel";
            this.MaxRecentReposLabel.Size = new System.Drawing.Size(102, 13);
            this.MaxRecentReposLabel.TabIndex = 8;
            this.MaxRecentReposLabel.Text = "Max Recent Repos:";
            // 
            // GitActionsLabel
            // 
            this.GitActionsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GitActionsLabel.AutoSize = true;
            this.GitActionsLabel.Location = new System.Drawing.Point(6, 262);
            this.GitActionsLabel.Name = "GitActionsLabel";
            this.GitActionsLabel.Size = new System.Drawing.Size(279, 13);
            this.GitActionsLabel.TabIndex = 1;
            this.GitActionsLabel.Text = "Note: Drag and drop items to change context menu order.";
            // 
            // GitActionsCheckList
            // 
            this.GitActionsCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GitActionsCheckList.FormattingEnabled = true;
            this.GitActionsCheckList.IntegralHeight = false;
            this.GitActionsCheckList.Location = new System.Drawing.Point(6, 6);
            this.GitActionsCheckList.Name = "GitActionsCheckList";
            this.GitActionsCheckList.Size = new System.Drawing.Size(590, 253);
            this.GitActionsCheckList.TabIndex = 0;
            this.SettingsToolTip.SetToolTip(this.GitActionsCheckList, "Only valid when \"Retain Logs on Close\" is disabled.\r\n");
            // 
            // SettingsTabs
            // 
            this.SettingsTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsTabs.Controls.Add(this.KeyboardShortcutsPage);
            this.SettingsTabs.Controls.Add(this.StartupReposTab);
            this.SettingsTabs.Controls.Add(this.GitActionsTab);
            this.SettingsTabs.Controls.Add(this.CustomActionsTab);
            this.SettingsTabs.Controls.Add(this.DisplaySettingsTab);
            this.SettingsTabs.Controls.Add(this.OtherSettingsTab);
            this.SettingsTabs.Controls.Add(this.DeveloperSettingsPage);
            this.SettingsTabs.Location = new System.Drawing.Point(12, 12);
            this.SettingsTabs.Name = "SettingsTabs";
            this.SettingsTabs.SelectedIndex = 0;
            this.SettingsTabs.Size = new System.Drawing.Size(710, 358);
            this.SettingsTabs.TabIndex = 12;
            // 
            // KeyboardShortcutsPage
            // 
            this.KeyboardShortcutsPage.AutoScroll = true;
            this.KeyboardShortcutsPage.Controls.Add(this.KeyBoardShortcutsTableLayout);
            this.KeyboardShortcutsPage.Location = new System.Drawing.Point(4, 22);
            this.KeyboardShortcutsPage.Name = "KeyboardShortcutsPage";
            this.KeyboardShortcutsPage.Padding = new System.Windows.Forms.Padding(3);
            this.KeyboardShortcutsPage.Size = new System.Drawing.Size(702, 332);
            this.KeyboardShortcutsPage.TabIndex = 5;
            this.KeyboardShortcutsPage.Text = "Keyboard Shortcuts";
            this.KeyboardShortcutsPage.UseVisualStyleBackColor = true;
            // 
            // KeyBoardShortcutsTableLayout
            // 
            this.KeyBoardShortcutsTableLayout.AutoSize = true;
            this.KeyBoardShortcutsTableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.KeyBoardShortcutsTableLayout.ColumnCount = 2;
            this.KeyBoardShortcutsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.KeyBoardShortcutsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.KeyBoardShortcutsTableLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.KeyBoardShortcutsTableLayout.Location = new System.Drawing.Point(3, 3);
            this.KeyBoardShortcutsTableLayout.Name = "KeyBoardShortcutsTableLayout";
            this.KeyBoardShortcutsTableLayout.RowCount = 1;
            this.KeyBoardShortcutsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.KeyBoardShortcutsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.KeyBoardShortcutsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.KeyBoardShortcutsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.KeyBoardShortcutsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.KeyBoardShortcutsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.KeyBoardShortcutsTableLayout.Size = new System.Drawing.Size(696, 0);
            this.KeyBoardShortcutsTableLayout.TabIndex = 2;
            // 
            // StartupReposTab
            // 
            this.StartupReposTab.Controls.Add(this.OpenStartupReposOnReOpenCheck);
            this.StartupReposTab.Controls.Add(this.StartupReposList);
            this.StartupReposTab.Controls.Add(this.AddDefaultRepo);
            this.StartupReposTab.Controls.Add(this.RemoveDefaultRepo);
            this.StartupReposTab.Location = new System.Drawing.Point(4, 22);
            this.StartupReposTab.Name = "StartupReposTab";
            this.StartupReposTab.Padding = new System.Windows.Forms.Padding(3);
            this.StartupReposTab.Size = new System.Drawing.Size(702, 332);
            this.StartupReposTab.TabIndex = 0;
            this.StartupReposTab.Text = "Startup Repos";
            this.StartupReposTab.UseVisualStyleBackColor = true;
            // 
            // GitActionsTab
            // 
            this.GitActionsTab.Controls.Add(this.GitActionsOptionsGroup);
            this.GitActionsTab.Controls.Add(this.GitActionsLabel);
            this.GitActionsTab.Controls.Add(this.GitActionsCheckList);
            this.GitActionsTab.Location = new System.Drawing.Point(4, 22);
            this.GitActionsTab.Name = "GitActionsTab";
            this.GitActionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.GitActionsTab.Size = new System.Drawing.Size(702, 332);
            this.GitActionsTab.TabIndex = 1;
            this.GitActionsTab.Text = "Git Actions";
            this.GitActionsTab.UseVisualStyleBackColor = true;
            // 
            // GitActionsOptionsGroup
            // 
            this.GitActionsOptionsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GitActionsOptionsGroup.Controls.Add(this.ConfirmFasterFetchCheck);
            this.GitActionsOptionsGroup.Location = new System.Drawing.Point(6, 278);
            this.GitActionsOptionsGroup.Name = "GitActionsOptionsGroup";
            this.GitActionsOptionsGroup.Size = new System.Drawing.Size(590, 48);
            this.GitActionsOptionsGroup.TabIndex = 3;
            this.GitActionsOptionsGroup.TabStop = false;
            this.GitActionsOptionsGroup.Text = "Git Actions Options";
            // 
            // ConfirmFasterFetchCheck
            // 
            this.ConfirmFasterFetchCheck.AutoSize = true;
            this.ConfirmFasterFetchCheck.Location = new System.Drawing.Point(6, 20);
            this.ConfirmFasterFetchCheck.Name = "ConfirmFasterFetchCheck";
            this.ConfirmFasterFetchCheck.Size = new System.Drawing.Size(156, 17);
            this.ConfirmFasterFetchCheck.TabIndex = 2;
            this.ConfirmFasterFetchCheck.Text = "Confirm before Faster Fetch";
            this.ConfirmFasterFetchCheck.UseVisualStyleBackColor = true;
            // 
            // CustomActionsTab
            // 
            this.CustomActionsTab.Controls.Add(this.EditCustomAction);
            this.CustomActionsTab.Controls.Add(this.RemoveCustomAction);
            this.CustomActionsTab.Controls.Add(this.CreateCustomAction);
            this.CustomActionsTab.Controls.Add(this.CustomActionsDataGridView);
            this.CustomActionsTab.Location = new System.Drawing.Point(4, 22);
            this.CustomActionsTab.Name = "CustomActionsTab";
            this.CustomActionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.CustomActionsTab.Size = new System.Drawing.Size(702, 332);
            this.CustomActionsTab.TabIndex = 6;
            this.CustomActionsTab.Text = "Custom Actions";
            this.CustomActionsTab.UseVisualStyleBackColor = true;
            // 
            // EditCustomAction
            // 
            this.EditCustomAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditCustomAction.Enabled = false;
            this.EditCustomAction.Location = new System.Drawing.Point(107, 303);
            this.EditCustomAction.Name = "EditCustomAction";
            this.EditCustomAction.Size = new System.Drawing.Size(95, 23);
            this.EditCustomAction.TabIndex = 3;
            this.EditCustomAction.Text = "Edit Action";
            this.EditCustomAction.UseVisualStyleBackColor = true;
            this.EditCustomAction.Click += new System.EventHandler(this.EditCustomAction_Click);
            // 
            // RemoveCustomAction
            // 
            this.RemoveCustomAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveCustomAction.Enabled = false;
            this.RemoveCustomAction.Location = new System.Drawing.Point(208, 303);
            this.RemoveCustomAction.Name = "RemoveCustomAction";
            this.RemoveCustomAction.Size = new System.Drawing.Size(95, 23);
            this.RemoveCustomAction.TabIndex = 2;
            this.RemoveCustomAction.Text = "Remove Action";
            this.RemoveCustomAction.UseVisualStyleBackColor = true;
            this.RemoveCustomAction.Click += new System.EventHandler(this.RemoveCustomAction_Click);
            // 
            // CreateCustomAction
            // 
            this.CreateCustomAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreateCustomAction.Location = new System.Drawing.Point(6, 303);
            this.CreateCustomAction.Name = "CreateCustomAction";
            this.CreateCustomAction.Size = new System.Drawing.Size(95, 23);
            this.CreateCustomAction.TabIndex = 1;
            this.CreateCustomAction.Text = "Create Action";
            this.CreateCustomAction.UseVisualStyleBackColor = true;
            this.CreateCustomAction.Click += new System.EventHandler(this.CreateCustomAction_Click);
            // 
            // CustomActionsDataGridView
            // 
            this.CustomActionsDataGridView.AllowUserToAddRows = false;
            this.CustomActionsDataGridView.AllowUserToDeleteRows = false;
            this.CustomActionsDataGridView.AllowUserToResizeRows = false;
            this.CustomActionsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomActionsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.CustomActionsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.CustomActionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomActionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomActionNameColumn,
            this.CustomActionProgramColumn,
            this.CustomActionArgumentsColumn,
            this.WorkingDirectory,
            this.RefreshLogAfter,
            this.ShowProgressDialog,
            this.CreateNoWindow});
            this.CustomActionsDataGridView.Location = new System.Drawing.Point(6, 6);
            this.CustomActionsDataGridView.MultiSelect = false;
            this.CustomActionsDataGridView.Name = "CustomActionsDataGridView";
            this.CustomActionsDataGridView.ReadOnly = true;
            this.CustomActionsDataGridView.RowHeadersVisible = false;
            this.CustomActionsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomActionsDataGridView.Size = new System.Drawing.Size(690, 291);
            this.CustomActionsDataGridView.TabIndex = 0;
            this.CustomActionsDataGridView.SelectionChanged += new System.EventHandler(this.CustomActionsDataGridView_SelectionChanged);
            // 
            // CustomActionNameColumn
            // 
            this.CustomActionNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CustomActionNameColumn.DataPropertyName = "Name";
            this.CustomActionNameColumn.HeaderText = "Name";
            this.CustomActionNameColumn.Name = "CustomActionNameColumn";
            this.CustomActionNameColumn.ReadOnly = true;
            this.CustomActionNameColumn.Width = 60;
            // 
            // CustomActionProgramColumn
            // 
            this.CustomActionProgramColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CustomActionProgramColumn.DataPropertyName = "Program";
            this.CustomActionProgramColumn.HeaderText = "Program";
            this.CustomActionProgramColumn.Name = "CustomActionProgramColumn";
            this.CustomActionProgramColumn.ReadOnly = true;
            this.CustomActionProgramColumn.Width = 71;
            // 
            // CustomActionArgumentsColumn
            // 
            this.CustomActionArgumentsColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CustomActionArgumentsColumn.DataPropertyName = "Arguments";
            this.CustomActionArgumentsColumn.HeaderText = "Arguments";
            this.CustomActionArgumentsColumn.Name = "CustomActionArgumentsColumn";
            this.CustomActionArgumentsColumn.ReadOnly = true;
            this.CustomActionArgumentsColumn.Width = 82;
            // 
            // WorkingDirectory
            // 
            this.WorkingDirectory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.WorkingDirectory.DataPropertyName = "WorkingDirectory";
            this.WorkingDirectory.HeaderText = "Working Directory";
            this.WorkingDirectory.Name = "WorkingDirectory";
            this.WorkingDirectory.ReadOnly = true;
            this.WorkingDirectory.Width = 107;
            // 
            // RefreshLogAfter
            // 
            this.RefreshLogAfter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RefreshLogAfter.DataPropertyName = "RefreshLogAfter";
            this.RefreshLogAfter.HeaderText = "Refresh Log After";
            this.RefreshLogAfter.Name = "RefreshLogAfter";
            this.RefreshLogAfter.ReadOnly = true;
            this.RefreshLogAfter.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RefreshLogAfter.Width = 67;
            // 
            // ShowProgressDialog
            // 
            this.ShowProgressDialog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ShowProgressDialog.DataPropertyName = "ShowProgressDialog";
            this.ShowProgressDialog.HeaderText = "Show Progress Dialog";
            this.ShowProgressDialog.Name = "ShowProgressDialog";
            this.ShowProgressDialog.ReadOnly = true;
            this.ShowProgressDialog.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ShowProgressDialog.Width = 105;
            // 
            // CreateNoWindow
            // 
            this.CreateNoWindow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CreateNoWindow.DataPropertyName = "CreateNoWindow";
            this.CreateNoWindow.HeaderText = "Create No Window";
            this.CreateNoWindow.Name = "CreateNoWindow";
            this.CreateNoWindow.ReadOnly = true;
            this.CreateNoWindow.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CreateNoWindow.Width = 93;
            // 
            // DisplaySettingsTab
            // 
            this.DisplaySettingsTab.Controls.Add(this.ResetNormalTabFontButton);
            this.DisplaySettingsTab.Controls.Add(this.ChangeNormalTabFontButton);
            this.DisplaySettingsTab.Controls.Add(this.NormalTabFontGroup);
            this.DisplaySettingsTab.Controls.Add(this.CheckForModifiedTabsIntervalLabel);
            this.DisplaySettingsTab.Controls.Add(this.CheckForModifiedTabsIntervalNumeric);
            this.DisplaySettingsTab.Controls.Add(this.IndicateModifiedTabsCheck);
            this.DisplaySettingsTab.Controls.Add(this.ResetModifiedTabFontButton);
            this.DisplaySettingsTab.Controls.Add(this.ChangeModifiedTabFontButton);
            this.DisplaySettingsTab.Controls.Add(this.ModifiedTabFontGroup);
            this.DisplaySettingsTab.Location = new System.Drawing.Point(4, 22);
            this.DisplaySettingsTab.Name = "DisplaySettingsTab";
            this.DisplaySettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.DisplaySettingsTab.Size = new System.Drawing.Size(702, 332);
            this.DisplaySettingsTab.TabIndex = 4;
            this.DisplaySettingsTab.Text = "Display";
            this.DisplaySettingsTab.UseVisualStyleBackColor = true;
            // 
            // ResetNormalTabFontButton
            // 
            this.ResetNormalTabFontButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetNormalTabFontButton.Location = new System.Drawing.Point(436, 71);
            this.ResetNormalTabFontButton.Name = "ResetNormalTabFontButton";
            this.ResetNormalTabFontButton.Size = new System.Drawing.Size(75, 23);
            this.ResetNormalTabFontButton.TabIndex = 8;
            this.ResetNormalTabFontButton.Text = "Reset";
            this.ResetNormalTabFontButton.UseVisualStyleBackColor = true;
            // 
            // ChangeNormalTabFontButton
            // 
            this.ChangeNormalTabFontButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeNormalTabFontButton.Location = new System.Drawing.Point(517, 71);
            this.ChangeNormalTabFontButton.Name = "ChangeNormalTabFontButton";
            this.ChangeNormalTabFontButton.Size = new System.Drawing.Size(75, 23);
            this.ChangeNormalTabFontButton.TabIndex = 7;
            this.ChangeNormalTabFontButton.Text = "Change";
            this.ChangeNormalTabFontButton.UseVisualStyleBackColor = true;
            // 
            // NormalTabFontGroup
            // 
            this.NormalTabFontGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NormalTabFontGroup.Controls.Add(this.NormalTabFontSample);
            this.NormalTabFontGroup.Location = new System.Drawing.Point(6, 6);
            this.NormalTabFontGroup.Name = "NormalTabFontGroup";
            this.NormalTabFontGroup.Size = new System.Drawing.Size(586, 59);
            this.NormalTabFontGroup.TabIndex = 6;
            this.NormalTabFontGroup.TabStop = false;
            this.NormalTabFontGroup.Text = "Normal Tab Font";
            // 
            // NormalTabFontSample
            // 
            this.NormalTabFontSample.AutoEllipsis = true;
            this.NormalTabFontSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NormalTabFontSample.Location = new System.Drawing.Point(3, 16);
            this.NormalTabFontSample.Name = "NormalTabFontSample";
            this.NormalTabFontSample.Size = new System.Drawing.Size(580, 40);
            this.NormalTabFontSample.TabIndex = 0;
            this.NormalTabFontSample.Text = "C:\\sample\\font.git";
            this.NormalTabFontSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CheckForModifiedTabsIntervalLabel
            // 
            this.CheckForModifiedTabsIntervalLabel.AutoSize = true;
            this.CheckForModifiedTabsIntervalLabel.Location = new System.Drawing.Point(8, 126);
            this.CheckForModifiedTabsIntervalLabel.Name = "CheckForModifiedTabsIntervalLabel";
            this.CheckForModifiedTabsIntervalLabel.Size = new System.Drawing.Size(229, 13);
            this.CheckForModifiedTabsIntervalLabel.TabIndex = 5;
            this.CheckForModifiedTabsIntervalLabel.Text = "Check for Modified Tabs Interval (milliseconds):";
            // 
            // CheckForModifiedTabsIntervalNumeric
            // 
            this.CheckForModifiedTabsIntervalNumeric.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.CheckForModifiedTabsIntervalNumeric.Location = new System.Drawing.Point(245, 123);
            this.CheckForModifiedTabsIntervalNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.CheckForModifiedTabsIntervalNumeric.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.CheckForModifiedTabsIntervalNumeric.Name = "CheckForModifiedTabsIntervalNumeric";
            this.CheckForModifiedTabsIntervalNumeric.Size = new System.Drawing.Size(73, 20);
            this.CheckForModifiedTabsIntervalNumeric.TabIndex = 4;
            this.CheckForModifiedTabsIntervalNumeric.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // IndicateModifiedTabsCheck
            // 
            this.IndicateModifiedTabsCheck.AutoSize = true;
            this.IndicateModifiedTabsCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IndicateModifiedTabsCheck.Location = new System.Drawing.Point(6, 106);
            this.IndicateModifiedTabsCheck.Name = "IndicateModifiedTabsCheck";
            this.IndicateModifiedTabsCheck.Size = new System.Drawing.Size(134, 17);
            this.IndicateModifiedTabsCheck.TabIndex = 3;
            this.IndicateModifiedTabsCheck.Text = "Indicate Modified Tabs";
            this.IndicateModifiedTabsCheck.UseVisualStyleBackColor = true;
            // 
            // ResetModifiedTabFontButton
            // 
            this.ResetModifiedTabFontButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetModifiedTabFontButton.Location = new System.Drawing.Point(436, 215);
            this.ResetModifiedTabFontButton.Name = "ResetModifiedTabFontButton";
            this.ResetModifiedTabFontButton.Size = new System.Drawing.Size(75, 23);
            this.ResetModifiedTabFontButton.TabIndex = 2;
            this.ResetModifiedTabFontButton.Text = "Reset";
            this.ResetModifiedTabFontButton.UseVisualStyleBackColor = true;
            // 
            // ChangeModifiedTabFontButton
            // 
            this.ChangeModifiedTabFontButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeModifiedTabFontButton.Location = new System.Drawing.Point(517, 215);
            this.ChangeModifiedTabFontButton.Name = "ChangeModifiedTabFontButton";
            this.ChangeModifiedTabFontButton.Size = new System.Drawing.Size(75, 23);
            this.ChangeModifiedTabFontButton.TabIndex = 1;
            this.ChangeModifiedTabFontButton.Text = "Change";
            this.ChangeModifiedTabFontButton.UseVisualStyleBackColor = true;
            // 
            // ModifiedTabFontGroup
            // 
            this.ModifiedTabFontGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModifiedTabFontGroup.Controls.Add(this.ModifiedTabFontSample);
            this.ModifiedTabFontGroup.Location = new System.Drawing.Point(6, 150);
            this.ModifiedTabFontGroup.Name = "ModifiedTabFontGroup";
            this.ModifiedTabFontGroup.Size = new System.Drawing.Size(586, 59);
            this.ModifiedTabFontGroup.TabIndex = 0;
            this.ModifiedTabFontGroup.TabStop = false;
            this.ModifiedTabFontGroup.Text = "Modified Tab Font";
            // 
            // ModifiedTabFontSample
            // 
            this.ModifiedTabFontSample.AutoEllipsis = true;
            this.ModifiedTabFontSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModifiedTabFontSample.Location = new System.Drawing.Point(3, 16);
            this.ModifiedTabFontSample.Name = "ModifiedTabFontSample";
            this.ModifiedTabFontSample.Size = new System.Drawing.Size(580, 40);
            this.ModifiedTabFontSample.TabIndex = 0;
            this.ModifiedTabFontSample.Text = "C:\\sample\\font.git";
            this.ModifiedTabFontSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OtherSettingsTab
            // 
            this.OtherSettingsTab.Controls.Add(this.CheckTortoiseGitOnPathCheck);
            this.OtherSettingsTab.Controls.Add(this.CloseWindowOnLastTabClosedCheck);
            this.OtherSettingsTab.Controls.Add(this.CloseToSystemTrayCheck);
            this.OtherSettingsTab.Controls.Add(this.RunOnStartupCheck);
            this.OtherSettingsTab.Controls.Add(this.ConfirmOnCloseCheck);
            this.OtherSettingsTab.Controls.Add(this.MaxRecentReposLabel);
            this.OtherSettingsTab.Controls.Add(this.MaxRecentReposNumeric);
            this.OtherSettingsTab.Location = new System.Drawing.Point(4, 22);
            this.OtherSettingsTab.Name = "OtherSettingsTab";
            this.OtherSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.OtherSettingsTab.Size = new System.Drawing.Size(702, 332);
            this.OtherSettingsTab.TabIndex = 2;
            this.OtherSettingsTab.Text = "Other";
            this.OtherSettingsTab.UseVisualStyleBackColor = true;
            // 
            // CloseWindowOnLastTabClosedCheck
            // 
            this.CloseWindowOnLastTabClosedCheck.AutoSize = true;
            this.CloseWindowOnLastTabClosedCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseWindowOnLastTabClosedCheck.Location = new System.Drawing.Point(6, 55);
            this.CloseWindowOnLastTabClosedCheck.Name = "CloseWindowOnLastTabClosedCheck";
            this.CloseWindowOnLastTabClosedCheck.Size = new System.Drawing.Size(189, 17);
            this.CloseWindowOnLastTabClosedCheck.TabIndex = 13;
            this.CloseWindowOnLastTabClosedCheck.Text = "Close Window on Last Tab Closed";
            this.CloseWindowOnLastTabClosedCheck.UseVisualStyleBackColor = true;
            // 
            // CloseToSystemTrayCheck
            // 
            this.CloseToSystemTrayCheck.AutoSize = true;
            this.CloseToSystemTrayCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseToSystemTrayCheck.Location = new System.Drawing.Point(6, 78);
            this.CloseToSystemTrayCheck.Name = "CloseToSystemTrayCheck";
            this.CloseToSystemTrayCheck.Size = new System.Drawing.Size(125, 17);
            this.CloseToSystemTrayCheck.TabIndex = 12;
            this.CloseToSystemTrayCheck.Text = "Close to System Tray";
            this.CloseToSystemTrayCheck.UseVisualStyleBackColor = true;
            // 
            // DeveloperSettingsPage
            // 
            this.DeveloperSettingsPage.Controls.Add(this.ShowHitTestCheck);
            this.DeveloperSettingsPage.Location = new System.Drawing.Point(4, 22);
            this.DeveloperSettingsPage.Name = "DeveloperSettingsPage";
            this.DeveloperSettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.DeveloperSettingsPage.Size = new System.Drawing.Size(702, 332);
            this.DeveloperSettingsPage.TabIndex = 3;
            this.DeveloperSettingsPage.Text = "Developer Settings";
            this.DeveloperSettingsPage.UseVisualStyleBackColor = true;
            // 
            // ShowHitTestCheck
            // 
            this.ShowHitTestCheck.AutoSize = true;
            this.ShowHitTestCheck.Location = new System.Drawing.Point(6, 6);
            this.ShowHitTestCheck.Name = "ShowHitTestCheck";
            this.ShowHitTestCheck.Size = new System.Drawing.Size(93, 17);
            this.ShowHitTestCheck.TabIndex = 0;
            this.ShowHitTestCheck.Text = "Show Hit Test";
            this.ShowHitTestCheck.UseVisualStyleBackColor = true;
            // 
            // ModifiedTabFontDialog
            // 
            this.ModifiedTabFontDialog.AllowScriptChange = false;
            this.ModifiedTabFontDialog.FontMustExist = true;
            this.ModifiedTabFontDialog.ShowColor = true;
            // 
            // NormalTabFontDialog
            // 
            this.NormalTabFontDialog.AllowScriptChange = false;
            this.NormalTabFontDialog.FontMustExist = true;
            this.NormalTabFontDialog.ShowColor = true;
            // 
            // CheckTortoiseGitOnPathCheck
            // 
            this.CheckTortoiseGitOnPathCheck.AutoSize = true;
            this.CheckTortoiseGitOnPathCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckTortoiseGitOnPathCheck.Location = new System.Drawing.Point(6, 124);
            this.CheckTortoiseGitOnPathCheck.Name = "CheckTortoiseGitOnPathCheck";
            this.CheckTortoiseGitOnPathCheck.Size = new System.Drawing.Size(235, 17);
            this.CheckTortoiseGitOnPathCheck.TabIndex = 14;
            this.CheckTortoiseGitOnPathCheck.Text = "Check if TortoiseGit is accessible on startup:";
            this.CheckTortoiseGitOnPathCheck.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.SettingsTabs);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.MaxRecentReposNumeric)).EndInit();
            this.SettingsTabs.ResumeLayout(false);
            this.KeyboardShortcutsPage.ResumeLayout(false);
            this.KeyboardShortcutsPage.PerformLayout();
            this.StartupReposTab.ResumeLayout(false);
            this.StartupReposTab.PerformLayout();
            this.GitActionsTab.ResumeLayout(false);
            this.GitActionsTab.PerformLayout();
            this.GitActionsOptionsGroup.ResumeLayout(false);
            this.GitActionsOptionsGroup.PerformLayout();
            this.CustomActionsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustomActionsDataGridView)).EndInit();
            this.DisplaySettingsTab.ResumeLayout(false);
            this.DisplaySettingsTab.PerformLayout();
            this.NormalTabFontGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CheckForModifiedTabsIntervalNumeric)).EndInit();
            this.ModifiedTabFontGroup.ResumeLayout(false);
            this.OtherSettingsTab.ResumeLayout(false);
            this.OtherSettingsTab.PerformLayout();
            this.DeveloperSettingsPage.ResumeLayout(false);
            this.DeveloperSettingsPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox StartupReposList;
        private System.Windows.Forms.Button AddDefaultRepo;
        private Button OK;
        private Button Cancel;
        private Button RemoveDefaultRepo;
        private NumericUpDown MaxRecentReposNumeric;
        private Label MaxRecentReposLabel;
        private CheckBox ConfirmOnCloseCheck;
        private CheckedListBox GitActionsCheckList;
        private Label GitActionsLabel;
        private CheckBox RunOnStartupCheck;
        private CheckBox OpenStartupReposOnReOpenCheck;
        private ToolTip SettingsToolTip;
        private TabControl SettingsTabs;
        private TabPage StartupReposTab;
        private TabPage GitActionsTab;
        private TabPage OtherSettingsTab;
        private TabPage DeveloperSettingsPage;
        private CheckBox ShowHitTestCheck;
        private CheckBox CloseToSystemTrayCheck;
        private TabPage DisplaySettingsTab;
        private FontDialog ModifiedTabFontDialog;
        private GroupBox ModifiedTabFontGroup;
        private Button ChangeModifiedTabFontButton;
        private Label ModifiedTabFontSample;
        private Button ResetModifiedTabFontButton;
        private CheckBox IndicateModifiedTabsCheck;
        private Label CheckForModifiedTabsIntervalLabel;
        private NumericUpDown CheckForModifiedTabsIntervalNumeric;
        private CheckBox CloseWindowOnLastTabClosedCheck;
        private TabPage KeyboardShortcutsPage;
        private TableLayoutPanel KeyBoardShortcutsTableLayout;
        private Button ResetNormalTabFontButton;
        private Button ChangeNormalTabFontButton;
        private GroupBox NormalTabFontGroup;
        private Label NormalTabFontSample;
        private FontDialog NormalTabFontDialog;
        private GroupBox GitActionsOptionsGroup;
        private CheckBox ConfirmFasterFetchCheck;
        private TabPage CustomActionsTab;
        private DataGridView CustomActionsDataGridView;
        private Button EditCustomAction;
        private Button RemoveCustomAction;
        private Button CreateCustomAction;
        private DataGridViewTextBoxColumn CustomActionNameColumn;
        private DataGridViewTextBoxColumn CustomActionProgramColumn;
        private DataGridViewTextBoxColumn CustomActionArgumentsColumn;
        private DataGridViewTextBoxColumn WorkingDirectory;
        private DataGridViewCheckBoxColumn RefreshLogAfter;
        private DataGridViewCheckBoxColumn ShowProgressDialog;
        private DataGridViewCheckBoxColumn CreateNoWindow;
        private CheckBox CheckTortoiseGitOnPathCheck;
    }
}