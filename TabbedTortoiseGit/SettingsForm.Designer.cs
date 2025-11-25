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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            StartupReposList = new ListBox();
            AddDefaultRepo = new Button();
            OK = new Button();
            Cancel = new Button();
            RemoveDefaultRepo = new Button();
            OpenStartupReposOnReOpenCheck = new CheckBox();
            RunOnStartupCheck = new CheckBox();
            ConfirmOnCloseCheck = new CheckBox();
            MaxRecentReposNumeric = new NumericUpDown();
            MaxRecentReposLabel = new Label();
            GitActionsLabel = new Label();
            GitActionsCheckList = new CheckedListBox();
            SettingsToolTip = new ToolTip( components );
            SettingsTabs = new TabControl();
            KeyboardShortcutsPage = new TabPage();
            KeyBoardShortcutsTableLayout = new TableLayoutPanel();
            StartupReposTab = new TabPage();
            GitActionsTab = new TabPage();
            GitActionsOptionsGroup = new GroupBox();
            ConfirmFasterFetchCheck = new CheckBox();
            CustomActionsTab = new TabPage();
            EditCustomAction = new Button();
            RemoveCustomAction = new Button();
            CreateCustomAction = new Button();
            CustomActionsDataGridView = new DataGridView();
            CustomActionNameColumn = new DataGridViewTextBoxColumn();
            CustomActionProgramColumn = new DataGridViewTextBoxColumn();
            CustomActionArgumentsColumn = new DataGridViewTextBoxColumn();
            WorkingDirectory = new DataGridViewTextBoxColumn();
            RefreshLogAfter = new DataGridViewCheckBoxColumn();
            ShowProgressDialog = new DataGridViewCheckBoxColumn();
            CreateNoWindow = new DataGridViewCheckBoxColumn();
            DisplaySettingsTab = new TabPage();
            repoNameReplacersGroup = new GroupBox();
            repoNameReplacersPanel = new Panel();
            repoNameReplacersHelperLabel = new Label();
            repoNameReplacersGridView = new DataGridView();
            repoNameReplacersGridViewPatternColumn = new DataGridViewTextBoxColumn();
            repoNameReplacersGridViewReplacementColumn = new DataGridViewTextBoxColumn();
            repoNameReplacersBindingSource = new BindingSource( components );
            HideReferencesDisplayCheck = new CheckBox();
            ResetNormalTabFontButton = new Button();
            ChangeNormalTabFontButton = new Button();
            NormalTabFontGroup = new GroupBox();
            NormalTabFontSample = new Label();
            CheckForModifiedTabsIntervalLabel = new Label();
            CheckForModifiedTabsIntervalNumeric = new NumericUpDown();
            IndicateModifiedTabsCheck = new CheckBox();
            ResetModifiedTabFontButton = new Button();
            ChangeModifiedTabFontButton = new Button();
            ModifiedTabFontGroup = new GroupBox();
            ModifiedTabFontSample = new Label();
            OtherSettingsTab = new TabPage();
            TortoiseGitProcExeLocationBrowse = new Button();
            TortoiseGitProcExeLocationText = new TextBox();
            TortoiseGitProcExeLocationLabel = new Label();
            ShowChangelogOnUpdateCheck = new CheckBox();
            CheckTortoiseGitOnPathCheck = new CheckBox();
            CloseWindowOnLastTabClosedCheck = new CheckBox();
            CloseToSystemTrayCheck = new CheckBox();
            DeveloperSettingsPage = new TabPage();
            ShowHitTestCheck = new CheckBox();
            ModifiedTabFontDialog = new FontDialog();
            NormalTabFontDialog = new FontDialog();
            TortoiseGitProcExeLocationDialog = new OpenFileDialog();
            folderDialog = new FolderBrowserDialog();
            restoreSettingsButton = new Button();
            ( (System.ComponentModel.ISupportInitialize)MaxRecentReposNumeric ).BeginInit();
            SettingsTabs.SuspendLayout();
            KeyboardShortcutsPage.SuspendLayout();
            StartupReposTab.SuspendLayout();
            GitActionsTab.SuspendLayout();
            GitActionsOptionsGroup.SuspendLayout();
            CustomActionsTab.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)CustomActionsDataGridView ).BeginInit();
            DisplaySettingsTab.SuspendLayout();
            repoNameReplacersGroup.SuspendLayout();
            repoNameReplacersPanel.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)repoNameReplacersGridView ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)repoNameReplacersBindingSource ).BeginInit();
            NormalTabFontGroup.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)CheckForModifiedTabsIntervalNumeric ).BeginInit();
            ModifiedTabFontGroup.SuspendLayout();
            OtherSettingsTab.SuspendLayout();
            DeveloperSettingsPage.SuspendLayout();
            SuspendLayout();
            // 
            // StartupReposList
            // 
            StartupReposList.Anchor =    AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            StartupReposList.FormattingEnabled = true;
            StartupReposList.IntegralHeight = false;
            StartupReposList.Location = new System.Drawing.Point( 7, 7 );
            StartupReposList.Margin = new Padding( 4, 3, 4, 3 );
            StartupReposList.Name = "StartupReposList";
            StartupReposList.SelectionMode = SelectionMode.MultiSimple;
            StartupReposList.Size = new System.Drawing.Size( 748, 398 );
            StartupReposList.TabIndex = 1;
            // 
            // AddDefaultRepo
            // 
            AddDefaultRepo.Anchor =  AnchorStyles.Bottom  |  AnchorStyles.Left ;
            AddDefaultRepo.Location = new System.Drawing.Point( 114, 411 );
            AddDefaultRepo.Margin = new Padding( 4, 3, 4, 3 );
            AddDefaultRepo.Name = "AddDefaultRepo";
            AddDefaultRepo.Size = new System.Drawing.Size( 99, 27 );
            AddDefaultRepo.TabIndex = 2;
            AddDefaultRepo.Text = "Add Repo";
            AddDefaultRepo.UseVisualStyleBackColor = true;
            // 
            // OK
            // 
            OK.Anchor =  AnchorStyles.Bottom  |  AnchorStyles.Right ;
            OK.DialogResult = DialogResult.OK;
            OK.Location = new System.Drawing.Point( 602, 517 );
            OK.Margin = new Padding( 4, 3, 4, 3 );
            OK.Name = "OK";
            OK.Size = new System.Drawing.Size( 88, 27 );
            OK.TabIndex = 3;
            OK.Text = "OK";
            OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            Cancel.Anchor =  AnchorStyles.Bottom  |  AnchorStyles.Right ;
            Cancel.DialogResult = DialogResult.Cancel;
            Cancel.Location = new System.Drawing.Point( 698, 517 );
            Cancel.Margin = new Padding( 4, 3, 4, 3 );
            Cancel.Name = "Cancel";
            Cancel.Size = new System.Drawing.Size( 88, 27 );
            Cancel.TabIndex = 4;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            // 
            // RemoveDefaultRepo
            // 
            RemoveDefaultRepo.Anchor =  AnchorStyles.Bottom  |  AnchorStyles.Left ;
            RemoveDefaultRepo.Location = new System.Drawing.Point( 8, 411 );
            RemoveDefaultRepo.Margin = new Padding( 4, 3, 4, 3 );
            RemoveDefaultRepo.Name = "RemoveDefaultRepo";
            RemoveDefaultRepo.Size = new System.Drawing.Size( 99, 27 );
            RemoveDefaultRepo.TabIndex = 5;
            RemoveDefaultRepo.Text = "Remove Repo";
            RemoveDefaultRepo.UseVisualStyleBackColor = true;
            // 
            // OpenStartupReposOnReOpenCheck
            // 
            OpenStartupReposOnReOpenCheck.Anchor =  AnchorStyles.Bottom  |  AnchorStyles.Left ;
            OpenStartupReposOnReOpenCheck.AutoSize = true;
            OpenStartupReposOnReOpenCheck.Location = new System.Drawing.Point( 8, 446 );
            OpenStartupReposOnReOpenCheck.Margin = new Padding( 4, 3, 4, 3 );
            OpenStartupReposOnReOpenCheck.Name = "OpenStartupReposOnReOpenCheck";
            OpenStartupReposOnReOpenCheck.Size = new System.Drawing.Size( 301, 19 );
            OpenStartupReposOnReOpenCheck.TabIndex = 6;
            OpenStartupReposOnReOpenCheck.Text = "Open Startup Repos when re-opened from Task Tray";
            SettingsToolTip.SetToolTip( OpenStartupReposOnReOpenCheck, "Only valid when \"Retain Logs on Close\" is disabled." );
            OpenStartupReposOnReOpenCheck.UseVisualStyleBackColor = true;
            // 
            // RunOnStartupCheck
            // 
            RunOnStartupCheck.AutoSize = true;
            RunOnStartupCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            RunOnStartupCheck.Location = new System.Drawing.Point( 7, 147 );
            RunOnStartupCheck.Margin = new Padding( 4, 3, 4, 3 );
            RunOnStartupCheck.Name = "RunOnStartupCheck";
            RunOnStartupCheck.Size = new System.Drawing.Size( 107, 19 );
            RunOnStartupCheck.TabIndex = 11;
            RunOnStartupCheck.Text = "Run on startup:";
            RunOnStartupCheck.UseVisualStyleBackColor = true;
            // 
            // ConfirmOnCloseCheck
            // 
            ConfirmOnCloseCheck.AutoSize = true;
            ConfirmOnCloseCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            ConfirmOnCloseCheck.Location = new System.Drawing.Point( 7, 67 );
            ConfirmOnCloseCheck.Margin = new Padding( 4, 3, 4, 3 );
            ConfirmOnCloseCheck.Name = "ConfirmOnCloseCheck";
            ConfirmOnCloseCheck.Size = new System.Drawing.Size( 149, 19 );
            ConfirmOnCloseCheck.TabIndex = 10;
            ConfirmOnCloseCheck.Text = "Prompt Before Closing:";
            ConfirmOnCloseCheck.UseVisualStyleBackColor = true;
            // 
            // MaxRecentReposNumeric
            // 
            MaxRecentReposNumeric.Location = new System.Drawing.Point( 116, 37 );
            MaxRecentReposNumeric.Margin = new Padding( 4, 3, 4, 3 );
            MaxRecentReposNumeric.Minimum = new decimal( new int[] { 1, 0, 0, 0 } );
            MaxRecentReposNumeric.Name = "MaxRecentReposNumeric";
            MaxRecentReposNumeric.Size = new System.Drawing.Size( 51, 23 );
            MaxRecentReposNumeric.TabIndex = 9;
            MaxRecentReposNumeric.Value = new decimal( new int[] { 1, 0, 0, 0 } );
            // 
            // MaxRecentReposLabel
            // 
            MaxRecentReposLabel.AutoSize = true;
            MaxRecentReposLabel.Location = new System.Drawing.Point( 7, 39 );
            MaxRecentReposLabel.Margin = new Padding( 4, 0, 4, 0 );
            MaxRecentReposLabel.Name = "MaxRecentReposLabel";
            MaxRecentReposLabel.Size = new System.Drawing.Size( 106, 15 );
            MaxRecentReposLabel.TabIndex = 8;
            MaxRecentReposLabel.Text = "Max Recent Repos:";
            // 
            // GitActionsLabel
            // 
            GitActionsLabel.Anchor =  AnchorStyles.Bottom  |  AnchorStyles.Left ;
            GitActionsLabel.AutoSize = true;
            GitActionsLabel.Location = new System.Drawing.Point( 7, 392 );
            GitActionsLabel.Margin = new Padding( 4, 0, 4, 0 );
            GitActionsLabel.Name = "GitActionsLabel";
            GitActionsLabel.Size = new System.Drawing.Size( 313, 15 );
            GitActionsLabel.TabIndex = 1;
            GitActionsLabel.Text = "Note: Drag and drop items to change context menu order.";
            // 
            // GitActionsCheckList
            // 
            GitActionsCheckList.Anchor =    AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            GitActionsCheckList.FormattingEnabled = true;
            GitActionsCheckList.IntegralHeight = false;
            GitActionsCheckList.Location = new System.Drawing.Point( 7, 7 );
            GitActionsCheckList.Margin = new Padding( 4, 3, 4, 3 );
            GitActionsCheckList.Name = "GitActionsCheckList";
            GitActionsCheckList.Size = new System.Drawing.Size( 748, 382 );
            GitActionsCheckList.TabIndex = 0;
            SettingsToolTip.SetToolTip( GitActionsCheckList, "Only valid when \"Retain Logs on Close\" is disabled.\r\n" );
            // 
            // SettingsTabs
            // 
            SettingsTabs.Anchor =    AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            SettingsTabs.Controls.Add( KeyboardShortcutsPage );
            SettingsTabs.Controls.Add( StartupReposTab );
            SettingsTabs.Controls.Add( GitActionsTab );
            SettingsTabs.Controls.Add( CustomActionsTab );
            SettingsTabs.Controls.Add( DisplaySettingsTab );
            SettingsTabs.Controls.Add( OtherSettingsTab );
            SettingsTabs.Controls.Add( DeveloperSettingsPage );
            SettingsTabs.Location = new System.Drawing.Point( 13, 12 );
            SettingsTabs.Margin = new Padding( 4, 3, 4, 3 );
            SettingsTabs.Name = "SettingsTabs";
            SettingsTabs.SelectedIndex = 0;
            SettingsTabs.Size = new System.Drawing.Size( 773, 499 );
            SettingsTabs.TabIndex = 12;
            // 
            // KeyboardShortcutsPage
            // 
            KeyboardShortcutsPage.AutoScroll = true;
            KeyboardShortcutsPage.Controls.Add( KeyBoardShortcutsTableLayout );
            KeyboardShortcutsPage.Location = new System.Drawing.Point( 4, 24 );
            KeyboardShortcutsPage.Margin = new Padding( 4, 3, 4, 3 );
            KeyboardShortcutsPage.Name = "KeyboardShortcutsPage";
            KeyboardShortcutsPage.Padding = new Padding( 4, 3, 4, 3 );
            KeyboardShortcutsPage.Size = new System.Drawing.Size( 765, 471 );
            KeyboardShortcutsPage.TabIndex = 5;
            KeyboardShortcutsPage.Text = "Keyboard Shortcuts";
            KeyboardShortcutsPage.UseVisualStyleBackColor = true;
            // 
            // KeyBoardShortcutsTableLayout
            // 
            KeyBoardShortcutsTableLayout.AutoSize = true;
            KeyBoardShortcutsTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            KeyBoardShortcutsTableLayout.ColumnCount = 2;
            KeyBoardShortcutsTableLayout.ColumnStyles.Add( new ColumnStyle() );
            KeyBoardShortcutsTableLayout.ColumnStyles.Add( new ColumnStyle( SizeType.Percent, 100F ) );
            KeyBoardShortcutsTableLayout.Dock = DockStyle.Top;
            KeyBoardShortcutsTableLayout.Location = new System.Drawing.Point( 4, 3 );
            KeyBoardShortcutsTableLayout.Margin = new Padding( 4, 3, 4, 3 );
            KeyBoardShortcutsTableLayout.Name = "KeyBoardShortcutsTableLayout";
            KeyBoardShortcutsTableLayout.RowCount = 1;
            KeyBoardShortcutsTableLayout.RowStyles.Add( new RowStyle() );
            KeyBoardShortcutsTableLayout.RowStyles.Add( new RowStyle( SizeType.Absolute, 1F ) );
            KeyBoardShortcutsTableLayout.RowStyles.Add( new RowStyle( SizeType.Absolute, 1F ) );
            KeyBoardShortcutsTableLayout.RowStyles.Add( new RowStyle( SizeType.Absolute, 1F ) );
            KeyBoardShortcutsTableLayout.RowStyles.Add( new RowStyle( SizeType.Absolute, 1F ) );
            KeyBoardShortcutsTableLayout.RowStyles.Add( new RowStyle( SizeType.Absolute, 1F ) );
            KeyBoardShortcutsTableLayout.Size = new System.Drawing.Size( 757, 0 );
            KeyBoardShortcutsTableLayout.TabIndex = 2;
            // 
            // StartupReposTab
            // 
            StartupReposTab.Controls.Add( OpenStartupReposOnReOpenCheck );
            StartupReposTab.Controls.Add( StartupReposList );
            StartupReposTab.Controls.Add( AddDefaultRepo );
            StartupReposTab.Controls.Add( RemoveDefaultRepo );
            StartupReposTab.Location = new System.Drawing.Point( 4, 24 );
            StartupReposTab.Margin = new Padding( 4, 3, 4, 3 );
            StartupReposTab.Name = "StartupReposTab";
            StartupReposTab.Padding = new Padding( 4, 3, 4, 3 );
            StartupReposTab.Size = new System.Drawing.Size( 765, 471 );
            StartupReposTab.TabIndex = 0;
            StartupReposTab.Text = "Startup Repos";
            StartupReposTab.UseVisualStyleBackColor = true;
            // 
            // GitActionsTab
            // 
            GitActionsTab.Controls.Add( GitActionsOptionsGroup );
            GitActionsTab.Controls.Add( GitActionsLabel );
            GitActionsTab.Controls.Add( GitActionsCheckList );
            GitActionsTab.Location = new System.Drawing.Point( 4, 24 );
            GitActionsTab.Margin = new Padding( 4, 3, 4, 3 );
            GitActionsTab.Name = "GitActionsTab";
            GitActionsTab.Padding = new Padding( 4, 3, 4, 3 );
            GitActionsTab.Size = new System.Drawing.Size( 765, 471 );
            GitActionsTab.TabIndex = 1;
            GitActionsTab.Text = "Git Actions";
            GitActionsTab.UseVisualStyleBackColor = true;
            // 
            // GitActionsOptionsGroup
            // 
            GitActionsOptionsGroup.Anchor =   AnchorStyles.Bottom  |  AnchorStyles.Left   |  AnchorStyles.Right ;
            GitActionsOptionsGroup.Controls.Add( ConfirmFasterFetchCheck );
            GitActionsOptionsGroup.Location = new System.Drawing.Point( 8, 410 );
            GitActionsOptionsGroup.Margin = new Padding( 4, 3, 4, 3 );
            GitActionsOptionsGroup.Name = "GitActionsOptionsGroup";
            GitActionsOptionsGroup.Padding = new Padding( 4, 3, 4, 3 );
            GitActionsOptionsGroup.Size = new System.Drawing.Size( 749, 55 );
            GitActionsOptionsGroup.TabIndex = 3;
            GitActionsOptionsGroup.TabStop = false;
            GitActionsOptionsGroup.Text = "Git Actions Options";
            // 
            // ConfirmFasterFetchCheck
            // 
            ConfirmFasterFetchCheck.AutoSize = true;
            ConfirmFasterFetchCheck.Location = new System.Drawing.Point( 7, 23 );
            ConfirmFasterFetchCheck.Margin = new Padding( 4, 3, 4, 3 );
            ConfirmFasterFetchCheck.Name = "ConfirmFasterFetchCheck";
            ConfirmFasterFetchCheck.Size = new System.Drawing.Size( 173, 19 );
            ConfirmFasterFetchCheck.TabIndex = 2;
            ConfirmFasterFetchCheck.Text = "Confirm before Faster Fetch";
            ConfirmFasterFetchCheck.UseVisualStyleBackColor = true;
            // 
            // CustomActionsTab
            // 
            CustomActionsTab.Controls.Add( EditCustomAction );
            CustomActionsTab.Controls.Add( RemoveCustomAction );
            CustomActionsTab.Controls.Add( CreateCustomAction );
            CustomActionsTab.Controls.Add( CustomActionsDataGridView );
            CustomActionsTab.Location = new System.Drawing.Point( 4, 24 );
            CustomActionsTab.Margin = new Padding( 4, 3, 4, 3 );
            CustomActionsTab.Name = "CustomActionsTab";
            CustomActionsTab.Padding = new Padding( 4, 3, 4, 3 );
            CustomActionsTab.Size = new System.Drawing.Size( 765, 471 );
            CustomActionsTab.TabIndex = 6;
            CustomActionsTab.Text = "Custom Actions";
            CustomActionsTab.UseVisualStyleBackColor = true;
            // 
            // EditCustomAction
            // 
            EditCustomAction.Anchor =  AnchorStyles.Bottom  |  AnchorStyles.Left ;
            EditCustomAction.Enabled = false;
            EditCustomAction.Location = new System.Drawing.Point( 126, 438 );
            EditCustomAction.Margin = new Padding( 4, 3, 4, 3 );
            EditCustomAction.Name = "EditCustomAction";
            EditCustomAction.Size = new System.Drawing.Size( 111, 27 );
            EditCustomAction.TabIndex = 3;
            EditCustomAction.Text = "Edit Action";
            EditCustomAction.UseVisualStyleBackColor = true;
            EditCustomAction.Click +=  EditCustomAction_Click ;
            // 
            // RemoveCustomAction
            // 
            RemoveCustomAction.Anchor =  AnchorStyles.Bottom  |  AnchorStyles.Left ;
            RemoveCustomAction.Enabled = false;
            RemoveCustomAction.Location = new System.Drawing.Point( 244, 438 );
            RemoveCustomAction.Margin = new Padding( 4, 3, 4, 3 );
            RemoveCustomAction.Name = "RemoveCustomAction";
            RemoveCustomAction.Size = new System.Drawing.Size( 111, 27 );
            RemoveCustomAction.TabIndex = 2;
            RemoveCustomAction.Text = "Remove Action";
            RemoveCustomAction.UseVisualStyleBackColor = true;
            RemoveCustomAction.Click +=  RemoveCustomAction_Click ;
            // 
            // CreateCustomAction
            // 
            CreateCustomAction.Anchor =  AnchorStyles.Bottom  |  AnchorStyles.Left ;
            CreateCustomAction.Location = new System.Drawing.Point( 8, 438 );
            CreateCustomAction.Margin = new Padding( 4, 3, 4, 3 );
            CreateCustomAction.Name = "CreateCustomAction";
            CreateCustomAction.Size = new System.Drawing.Size( 111, 27 );
            CreateCustomAction.TabIndex = 1;
            CreateCustomAction.Text = "Create Action";
            CreateCustomAction.UseVisualStyleBackColor = true;
            CreateCustomAction.Click +=  CreateCustomAction_Click ;
            // 
            // CustomActionsDataGridView
            // 
            CustomActionsDataGridView.AllowUserToAddRows = false;
            CustomActionsDataGridView.AllowUserToDeleteRows = false;
            CustomActionsDataGridView.AllowUserToResizeRows = false;
            CustomActionsDataGridView.Anchor =    AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            CustomActionsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            CustomActionsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "Segoe UI", 9F );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            CustomActionsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            CustomActionsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomActionsDataGridView.Columns.AddRange( new DataGridViewColumn[] { CustomActionNameColumn, CustomActionProgramColumn, CustomActionArgumentsColumn, WorkingDirectory, RefreshLogAfter, ShowProgressDialog, CreateNoWindow } );
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font( "Segoe UI", 9F );
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            CustomActionsDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            CustomActionsDataGridView.Location = new System.Drawing.Point( 7, 7 );
            CustomActionsDataGridView.Margin = new Padding( 4, 3, 4, 3 );
            CustomActionsDataGridView.MultiSelect = false;
            CustomActionsDataGridView.Name = "CustomActionsDataGridView";
            CustomActionsDataGridView.ReadOnly = true;
            CustomActionsDataGridView.RowHeadersVisible = false;
            CustomActionsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CustomActionsDataGridView.Size = new System.Drawing.Size( 749, 425 );
            CustomActionsDataGridView.TabIndex = 0;
            CustomActionsDataGridView.SelectionChanged +=  CustomActionsDataGridView_SelectionChanged ;
            // 
            // CustomActionNameColumn
            // 
            CustomActionNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            CustomActionNameColumn.DataPropertyName = "Name";
            CustomActionNameColumn.HeaderText = "Name";
            CustomActionNameColumn.Name = "CustomActionNameColumn";
            CustomActionNameColumn.ReadOnly = true;
            CustomActionNameColumn.Width = 64;
            // 
            // CustomActionProgramColumn
            // 
            CustomActionProgramColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            CustomActionProgramColumn.DataPropertyName = "Program";
            CustomActionProgramColumn.HeaderText = "Program";
            CustomActionProgramColumn.Name = "CustomActionProgramColumn";
            CustomActionProgramColumn.ReadOnly = true;
            CustomActionProgramColumn.Width = 78;
            // 
            // CustomActionArgumentsColumn
            // 
            CustomActionArgumentsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            CustomActionArgumentsColumn.DataPropertyName = "Arguments";
            CustomActionArgumentsColumn.HeaderText = "Arguments";
            CustomActionArgumentsColumn.Name = "CustomActionArgumentsColumn";
            CustomActionArgumentsColumn.ReadOnly = true;
            CustomActionArgumentsColumn.Width = 91;
            // 
            // WorkingDirectory
            // 
            WorkingDirectory.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            WorkingDirectory.DataPropertyName = "WorkingDirectory";
            WorkingDirectory.HeaderText = "Working Directory";
            WorkingDirectory.Name = "WorkingDirectory";
            WorkingDirectory.ReadOnly = true;
            WorkingDirectory.Width = 117;
            // 
            // RefreshLogAfter
            // 
            RefreshLogAfter.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            RefreshLogAfter.DataPropertyName = "RefreshLogAfter";
            RefreshLogAfter.HeaderText = "Refresh Log After";
            RefreshLogAfter.Name = "RefreshLogAfter";
            RefreshLogAfter.ReadOnly = true;
            RefreshLogAfter.Resizable = DataGridViewTriState.False;
            RefreshLogAfter.Width = 70;
            // 
            // ShowProgressDialog
            // 
            ShowProgressDialog.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ShowProgressDialog.DataPropertyName = "ShowProgressDialog";
            ShowProgressDialog.HeaderText = "Show Progress Dialog";
            ShowProgressDialog.Name = "ShowProgressDialog";
            ShowProgressDialog.ReadOnly = true;
            ShowProgressDialog.Resizable = DataGridViewTriState.False;
            ShowProgressDialog.Width = 114;
            // 
            // CreateNoWindow
            // 
            CreateNoWindow.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            CreateNoWindow.DataPropertyName = "CreateNoWindow";
            CreateNoWindow.HeaderText = "Create No Window";
            CreateNoWindow.Name = "CreateNoWindow";
            CreateNoWindow.ReadOnly = true;
            CreateNoWindow.Resizable = DataGridViewTriState.False;
            CreateNoWindow.Width = 102;
            // 
            // DisplaySettingsTab
            // 
            DisplaySettingsTab.Controls.Add( repoNameReplacersGroup );
            DisplaySettingsTab.Controls.Add( HideReferencesDisplayCheck );
            DisplaySettingsTab.Controls.Add( ResetNormalTabFontButton );
            DisplaySettingsTab.Controls.Add( ChangeNormalTabFontButton );
            DisplaySettingsTab.Controls.Add( NormalTabFontGroup );
            DisplaySettingsTab.Controls.Add( CheckForModifiedTabsIntervalLabel );
            DisplaySettingsTab.Controls.Add( CheckForModifiedTabsIntervalNumeric );
            DisplaySettingsTab.Controls.Add( IndicateModifiedTabsCheck );
            DisplaySettingsTab.Controls.Add( ResetModifiedTabFontButton );
            DisplaySettingsTab.Controls.Add( ChangeModifiedTabFontButton );
            DisplaySettingsTab.Controls.Add( ModifiedTabFontGroup );
            DisplaySettingsTab.Location = new System.Drawing.Point( 4, 24 );
            DisplaySettingsTab.Margin = new Padding( 4, 3, 4, 3 );
            DisplaySettingsTab.Name = "DisplaySettingsTab";
            DisplaySettingsTab.Padding = new Padding( 4, 3, 4, 3 );
            DisplaySettingsTab.Size = new System.Drawing.Size( 765, 471 );
            DisplaySettingsTab.TabIndex = 4;
            DisplaySettingsTab.Text = "Display";
            DisplaySettingsTab.UseVisualStyleBackColor = true;
            // 
            // repoNameReplacersGroup
            // 
            repoNameReplacersGroup.Anchor =    AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            repoNameReplacersGroup.Controls.Add( repoNameReplacersPanel );
            repoNameReplacersGroup.Location = new System.Drawing.Point( 7, 307 );
            repoNameReplacersGroup.Name = "repoNameReplacersGroup";
            repoNameReplacersGroup.Size = new System.Drawing.Size( 751, 158 );
            repoNameReplacersGroup.TabIndex = 12;
            repoNameReplacersGroup.TabStop = false;
            repoNameReplacersGroup.Text = "Repo Name Tab Display";
            // 
            // repoNameReplacersPanel
            // 
            repoNameReplacersPanel.Controls.Add( repoNameReplacersHelperLabel );
            repoNameReplacersPanel.Controls.Add( repoNameReplacersGridView );
            repoNameReplacersPanel.Dock = DockStyle.Fill;
            repoNameReplacersPanel.Location = new System.Drawing.Point( 3, 19 );
            repoNameReplacersPanel.Name = "repoNameReplacersPanel";
            repoNameReplacersPanel.Size = new System.Drawing.Size( 745, 136 );
            repoNameReplacersPanel.TabIndex = 0;
            // 
            // repoNameReplacersHelperLabel
            // 
            repoNameReplacersHelperLabel.Anchor =  AnchorStyles.Bottom  |  AnchorStyles.Left ;
            repoNameReplacersHelperLabel.AutoSize = true;
            repoNameReplacersHelperLabel.Location = new System.Drawing.Point( 3, 121 );
            repoNameReplacersHelperLabel.Name = "repoNameReplacersHelperLabel";
            repoNameReplacersHelperLabel.Size = new System.Drawing.Size( 460, 15 );
            repoNameReplacersHelperLabel.TabIndex = 12;
            repoNameReplacersHelperLabel.Text = "Note: These values are used to replace parts of the repo folder path for the tab display.";
            // 
            // repoNameReplacersGridView
            // 
            repoNameReplacersGridView.AllowUserToResizeRows = false;
            repoNameReplacersGridView.Anchor =    AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            repoNameReplacersGridView.AutoGenerateColumns = false;
            repoNameReplacersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font( "Segoe UI", 9F );
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            repoNameReplacersGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            repoNameReplacersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            repoNameReplacersGridView.Columns.AddRange( new DataGridViewColumn[] { repoNameReplacersGridViewPatternColumn, repoNameReplacersGridViewReplacementColumn } );
            repoNameReplacersGridView.DataSource = repoNameReplacersBindingSource;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font( "Segoe UI", 9F );
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            repoNameReplacersGridView.DefaultCellStyle = dataGridViewCellStyle4;
            repoNameReplacersGridView.Location = new System.Drawing.Point( 3, 3 );
            repoNameReplacersGridView.Name = "repoNameReplacersGridView";
            repoNameReplacersGridView.Size = new System.Drawing.Size( 739, 115 );
            repoNameReplacersGridView.TabIndex = 11;
            // 
            // repoNameReplacersGridViewPatternColumn
            // 
            repoNameReplacersGridViewPatternColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            repoNameReplacersGridViewPatternColumn.DataPropertyName = "Pattern";
            repoNameReplacersGridViewPatternColumn.HeaderText = "Pattern";
            repoNameReplacersGridViewPatternColumn.Name = "repoNameReplacersGridViewPatternColumn";
            repoNameReplacersGridViewPatternColumn.ToolTipText = "Regex pattern text to match against repo folder path for tab name display.";
            // 
            // repoNameReplacersGridViewReplacementColumn
            // 
            repoNameReplacersGridViewReplacementColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            repoNameReplacersGridViewReplacementColumn.DataPropertyName = "Replacement";
            repoNameReplacersGridViewReplacementColumn.HeaderText = "Replacement";
            repoNameReplacersGridViewReplacementColumn.Name = "repoNameReplacersGridViewReplacementColumn";
            repoNameReplacersGridViewReplacementColumn.ToolTipText = "Replacement text for tab name display.";
            // 
            // repoNameReplacersBindingSource
            // 
            repoNameReplacersBindingSource.DataSource = typeof( RepoNameReplacer );
            // 
            // HideReferencesDisplayCheck
            // 
            HideReferencesDisplayCheck.AutoSize = true;
            HideReferencesDisplayCheck.Location = new System.Drawing.Point( 7, 282 );
            HideReferencesDisplayCheck.Margin = new Padding( 4, 3, 4, 3 );
            HideReferencesDisplayCheck.Name = "HideReferencesDisplayCheck";
            HideReferencesDisplayCheck.Size = new System.Drawing.Size( 148, 19 );
            HideReferencesDisplayCheck.TabIndex = 10;
            HideReferencesDisplayCheck.Text = "Hide references display";
            HideReferencesDisplayCheck.UseVisualStyleBackColor = true;
            // 
            // ResetNormalTabFontButton
            // 
            ResetNormalTabFontButton.Anchor =  AnchorStyles.Top  |  AnchorStyles.Right ;
            ResetNormalTabFontButton.Location = new System.Drawing.Point( 574, 82 );
            ResetNormalTabFontButton.Margin = new Padding( 4, 3, 4, 3 );
            ResetNormalTabFontButton.Name = "ResetNormalTabFontButton";
            ResetNormalTabFontButton.Size = new System.Drawing.Size( 88, 27 );
            ResetNormalTabFontButton.TabIndex = 8;
            ResetNormalTabFontButton.Text = "Reset";
            ResetNormalTabFontButton.UseVisualStyleBackColor = true;
            // 
            // ChangeNormalTabFontButton
            // 
            ChangeNormalTabFontButton.Anchor =  AnchorStyles.Top  |  AnchorStyles.Right ;
            ChangeNormalTabFontButton.Location = new System.Drawing.Point( 668, 82 );
            ChangeNormalTabFontButton.Margin = new Padding( 4, 3, 4, 3 );
            ChangeNormalTabFontButton.Name = "ChangeNormalTabFontButton";
            ChangeNormalTabFontButton.Size = new System.Drawing.Size( 88, 27 );
            ChangeNormalTabFontButton.TabIndex = 7;
            ChangeNormalTabFontButton.Text = "Change";
            ChangeNormalTabFontButton.UseVisualStyleBackColor = true;
            // 
            // NormalTabFontGroup
            // 
            NormalTabFontGroup.Anchor =   AnchorStyles.Top  |  AnchorStyles.Left   |  AnchorStyles.Right ;
            NormalTabFontGroup.Controls.Add( NormalTabFontSample );
            NormalTabFontGroup.Location = new System.Drawing.Point( 7, 7 );
            NormalTabFontGroup.Margin = new Padding( 4, 3, 4, 3 );
            NormalTabFontGroup.Name = "NormalTabFontGroup";
            NormalTabFontGroup.Padding = new Padding( 4, 3, 4, 3 );
            NormalTabFontGroup.Size = new System.Drawing.Size( 749, 68 );
            NormalTabFontGroup.TabIndex = 6;
            NormalTabFontGroup.TabStop = false;
            NormalTabFontGroup.Text = "Normal Tab Font";
            // 
            // NormalTabFontSample
            // 
            NormalTabFontSample.AutoEllipsis = true;
            NormalTabFontSample.Dock = DockStyle.Fill;
            NormalTabFontSample.Location = new System.Drawing.Point( 4, 19 );
            NormalTabFontSample.Margin = new Padding( 4, 0, 4, 0 );
            NormalTabFontSample.Name = "NormalTabFontSample";
            NormalTabFontSample.Size = new System.Drawing.Size( 741, 46 );
            NormalTabFontSample.TabIndex = 0;
            NormalTabFontSample.Text = "C:\\sample\\font.git";
            NormalTabFontSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CheckForModifiedTabsIntervalLabel
            // 
            CheckForModifiedTabsIntervalLabel.AutoSize = true;
            CheckForModifiedTabsIntervalLabel.Location = new System.Drawing.Point( 9, 145 );
            CheckForModifiedTabsIntervalLabel.Margin = new Padding( 4, 0, 4, 0 );
            CheckForModifiedTabsIntervalLabel.Name = "CheckForModifiedTabsIntervalLabel";
            CheckForModifiedTabsIntervalLabel.Size = new System.Drawing.Size( 258, 15 );
            CheckForModifiedTabsIntervalLabel.TabIndex = 5;
            CheckForModifiedTabsIntervalLabel.Text = "Check for Modified Tabs Interval (milliseconds):";
            // 
            // CheckForModifiedTabsIntervalNumeric
            // 
            CheckForModifiedTabsIntervalNumeric.Increment = new decimal( new int[] { 500, 0, 0, 0 } );
            CheckForModifiedTabsIntervalNumeric.Location = new System.Drawing.Point( 275, 143 );
            CheckForModifiedTabsIntervalNumeric.Margin = new Padding( 4, 3, 4, 3 );
            CheckForModifiedTabsIntervalNumeric.Maximum = new decimal( new int[] { 100000, 0, 0, 0 } );
            CheckForModifiedTabsIntervalNumeric.Minimum = new decimal( new int[] { 1000, 0, 0, 0 } );
            CheckForModifiedTabsIntervalNumeric.Name = "CheckForModifiedTabsIntervalNumeric";
            CheckForModifiedTabsIntervalNumeric.Size = new System.Drawing.Size( 85, 23 );
            CheckForModifiedTabsIntervalNumeric.TabIndex = 4;
            CheckForModifiedTabsIntervalNumeric.Value = new decimal( new int[] { 1000, 0, 0, 0 } );
            // 
            // IndicateModifiedTabsCheck
            // 
            IndicateModifiedTabsCheck.AutoSize = true;
            IndicateModifiedTabsCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            IndicateModifiedTabsCheck.Location = new System.Drawing.Point( 7, 122 );
            IndicateModifiedTabsCheck.Margin = new Padding( 4, 3, 4, 3 );
            IndicateModifiedTabsCheck.Name = "IndicateModifiedTabsCheck";
            IndicateModifiedTabsCheck.Size = new System.Drawing.Size( 146, 19 );
            IndicateModifiedTabsCheck.TabIndex = 3;
            IndicateModifiedTabsCheck.Text = "Indicate Modified Tabs";
            IndicateModifiedTabsCheck.UseVisualStyleBackColor = true;
            // 
            // ResetModifiedTabFontButton
            // 
            ResetModifiedTabFontButton.Anchor =  AnchorStyles.Top  |  AnchorStyles.Right ;
            ResetModifiedTabFontButton.Location = new System.Drawing.Point( 574, 248 );
            ResetModifiedTabFontButton.Margin = new Padding( 4, 3, 4, 3 );
            ResetModifiedTabFontButton.Name = "ResetModifiedTabFontButton";
            ResetModifiedTabFontButton.Size = new System.Drawing.Size( 88, 27 );
            ResetModifiedTabFontButton.TabIndex = 2;
            ResetModifiedTabFontButton.Text = "Reset";
            ResetModifiedTabFontButton.UseVisualStyleBackColor = true;
            // 
            // ChangeModifiedTabFontButton
            // 
            ChangeModifiedTabFontButton.Anchor =  AnchorStyles.Top  |  AnchorStyles.Right ;
            ChangeModifiedTabFontButton.Location = new System.Drawing.Point( 668, 248 );
            ChangeModifiedTabFontButton.Margin = new Padding( 4, 3, 4, 3 );
            ChangeModifiedTabFontButton.Name = "ChangeModifiedTabFontButton";
            ChangeModifiedTabFontButton.Size = new System.Drawing.Size( 88, 27 );
            ChangeModifiedTabFontButton.TabIndex = 1;
            ChangeModifiedTabFontButton.Text = "Change";
            ChangeModifiedTabFontButton.UseVisualStyleBackColor = true;
            // 
            // ModifiedTabFontGroup
            // 
            ModifiedTabFontGroup.Anchor =   AnchorStyles.Top  |  AnchorStyles.Left   |  AnchorStyles.Right ;
            ModifiedTabFontGroup.Controls.Add( ModifiedTabFontSample );
            ModifiedTabFontGroup.Location = new System.Drawing.Point( 7, 173 );
            ModifiedTabFontGroup.Margin = new Padding( 4, 3, 4, 3 );
            ModifiedTabFontGroup.Name = "ModifiedTabFontGroup";
            ModifiedTabFontGroup.Padding = new Padding( 4, 3, 4, 3 );
            ModifiedTabFontGroup.Size = new System.Drawing.Size( 745, 68 );
            ModifiedTabFontGroup.TabIndex = 0;
            ModifiedTabFontGroup.TabStop = false;
            ModifiedTabFontGroup.Text = "Modified Tab Font";
            // 
            // ModifiedTabFontSample
            // 
            ModifiedTabFontSample.AutoEllipsis = true;
            ModifiedTabFontSample.Dock = DockStyle.Fill;
            ModifiedTabFontSample.Location = new System.Drawing.Point( 4, 19 );
            ModifiedTabFontSample.Margin = new Padding( 4, 0, 4, 0 );
            ModifiedTabFontSample.Name = "ModifiedTabFontSample";
            ModifiedTabFontSample.Size = new System.Drawing.Size( 737, 46 );
            ModifiedTabFontSample.TabIndex = 0;
            ModifiedTabFontSample.Text = "C:\\sample\\font.git";
            ModifiedTabFontSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OtherSettingsTab
            // 
            OtherSettingsTab.Controls.Add( TortoiseGitProcExeLocationBrowse );
            OtherSettingsTab.Controls.Add( TortoiseGitProcExeLocationText );
            OtherSettingsTab.Controls.Add( TortoiseGitProcExeLocationLabel );
            OtherSettingsTab.Controls.Add( ShowChangelogOnUpdateCheck );
            OtherSettingsTab.Controls.Add( CheckTortoiseGitOnPathCheck );
            OtherSettingsTab.Controls.Add( CloseWindowOnLastTabClosedCheck );
            OtherSettingsTab.Controls.Add( CloseToSystemTrayCheck );
            OtherSettingsTab.Controls.Add( RunOnStartupCheck );
            OtherSettingsTab.Controls.Add( ConfirmOnCloseCheck );
            OtherSettingsTab.Controls.Add( MaxRecentReposLabel );
            OtherSettingsTab.Controls.Add( MaxRecentReposNumeric );
            OtherSettingsTab.Location = new System.Drawing.Point( 4, 24 );
            OtherSettingsTab.Margin = new Padding( 4, 3, 4, 3 );
            OtherSettingsTab.Name = "OtherSettingsTab";
            OtherSettingsTab.Padding = new Padding( 4, 3, 4, 3 );
            OtherSettingsTab.Size = new System.Drawing.Size( 765, 471 );
            OtherSettingsTab.TabIndex = 2;
            OtherSettingsTab.Text = "Other";
            OtherSettingsTab.UseVisualStyleBackColor = true;
            // 
            // TortoiseGitProcExeLocationBrowse
            // 
            TortoiseGitProcExeLocationBrowse.Anchor =  AnchorStyles.Top  |  AnchorStyles.Right ;
            TortoiseGitProcExeLocationBrowse.Location = new System.Drawing.Point( 668, 6 );
            TortoiseGitProcExeLocationBrowse.Margin = new Padding( 4, 3, 4, 3 );
            TortoiseGitProcExeLocationBrowse.Name = "TortoiseGitProcExeLocationBrowse";
            TortoiseGitProcExeLocationBrowse.Size = new System.Drawing.Size( 88, 27 );
            TortoiseGitProcExeLocationBrowse.TabIndex = 18;
            TortoiseGitProcExeLocationBrowse.Text = "Browse";
            TortoiseGitProcExeLocationBrowse.UseVisualStyleBackColor = true;
            // 
            // TortoiseGitProcExeLocationText
            // 
            TortoiseGitProcExeLocationText.Anchor =   AnchorStyles.Top  |  AnchorStyles.Left   |  AnchorStyles.Right ;
            TortoiseGitProcExeLocationText.Location = new System.Drawing.Point( 175, 7 );
            TortoiseGitProcExeLocationText.Margin = new Padding( 4, 3, 4, 3 );
            TortoiseGitProcExeLocationText.Name = "TortoiseGitProcExeLocationText";
            TortoiseGitProcExeLocationText.Size = new System.Drawing.Size( 486, 23 );
            TortoiseGitProcExeLocationText.TabIndex = 17;
            // 
            // TortoiseGitProcExeLocationLabel
            // 
            TortoiseGitProcExeLocationLabel.AutoSize = true;
            TortoiseGitProcExeLocationLabel.Location = new System.Drawing.Point( 7, 10 );
            TortoiseGitProcExeLocationLabel.Margin = new Padding( 4, 0, 4, 0 );
            TortoiseGitProcExeLocationLabel.Name = "TortoiseGitProcExeLocationLabel";
            TortoiseGitProcExeLocationLabel.Size = new System.Drawing.Size( 160, 15 );
            TortoiseGitProcExeLocationLabel.TabIndex = 16;
            TortoiseGitProcExeLocationLabel.Text = "TortoiseGitProc.exe Location:";
            // 
            // ShowChangelogOnUpdateCheck
            // 
            ShowChangelogOnUpdateCheck.AutoSize = true;
            ShowChangelogOnUpdateCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            ShowChangelogOnUpdateCheck.Location = new System.Drawing.Point( 7, 200 );
            ShowChangelogOnUpdateCheck.Margin = new Padding( 4, 3, 4, 3 );
            ShowChangelogOnUpdateCheck.Name = "ShowChangelogOnUpdateCheck";
            ShowChangelogOnUpdateCheck.Size = new System.Drawing.Size( 174, 19 );
            ShowChangelogOnUpdateCheck.TabIndex = 15;
            ShowChangelogOnUpdateCheck.Text = "Show changelog on update:";
            ShowChangelogOnUpdateCheck.UseVisualStyleBackColor = true;
            // 
            // CheckTortoiseGitOnPathCheck
            // 
            CheckTortoiseGitOnPathCheck.AutoSize = true;
            CheckTortoiseGitOnPathCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            CheckTortoiseGitOnPathCheck.Location = new System.Drawing.Point( 7, 173 );
            CheckTortoiseGitOnPathCheck.Margin = new Padding( 4, 3, 4, 3 );
            CheckTortoiseGitOnPathCheck.Name = "CheckTortoiseGitOnPathCheck";
            CheckTortoiseGitOnPathCheck.Size = new System.Drawing.Size( 256, 19 );
            CheckTortoiseGitOnPathCheck.TabIndex = 14;
            CheckTortoiseGitOnPathCheck.Text = "Check if TortoiseGit is accessible on startup:";
            CheckTortoiseGitOnPathCheck.UseVisualStyleBackColor = true;
            // 
            // CloseWindowOnLastTabClosedCheck
            // 
            CloseWindowOnLastTabClosedCheck.AutoSize = true;
            CloseWindowOnLastTabClosedCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            CloseWindowOnLastTabClosedCheck.Location = new System.Drawing.Point( 7, 93 );
            CloseWindowOnLastTabClosedCheck.Margin = new Padding( 4, 3, 4, 3 );
            CloseWindowOnLastTabClosedCheck.Name = "CloseWindowOnLastTabClosedCheck";
            CloseWindowOnLastTabClosedCheck.Size = new System.Drawing.Size( 204, 19 );
            CloseWindowOnLastTabClosedCheck.TabIndex = 13;
            CloseWindowOnLastTabClosedCheck.Text = "Close Window on Last Tab Closed";
            CloseWindowOnLastTabClosedCheck.UseVisualStyleBackColor = true;
            // 
            // CloseToSystemTrayCheck
            // 
            CloseToSystemTrayCheck.AutoSize = true;
            CloseToSystemTrayCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            CloseToSystemTrayCheck.Location = new System.Drawing.Point( 7, 120 );
            CloseToSystemTrayCheck.Margin = new Padding( 4, 3, 4, 3 );
            CloseToSystemTrayCheck.Name = "CloseToSystemTrayCheck";
            CloseToSystemTrayCheck.Size = new System.Drawing.Size( 135, 19 );
            CloseToSystemTrayCheck.TabIndex = 12;
            CloseToSystemTrayCheck.Text = "Close to System Tray";
            CloseToSystemTrayCheck.UseVisualStyleBackColor = true;
            // 
            // DeveloperSettingsPage
            // 
            DeveloperSettingsPage.Controls.Add( ShowHitTestCheck );
            DeveloperSettingsPage.Location = new System.Drawing.Point( 4, 24 );
            DeveloperSettingsPage.Margin = new Padding( 4, 3, 4, 3 );
            DeveloperSettingsPage.Name = "DeveloperSettingsPage";
            DeveloperSettingsPage.Padding = new Padding( 4, 3, 4, 3 );
            DeveloperSettingsPage.Size = new System.Drawing.Size( 765, 471 );
            DeveloperSettingsPage.TabIndex = 3;
            DeveloperSettingsPage.Text = "Developer Settings";
            DeveloperSettingsPage.UseVisualStyleBackColor = true;
            // 
            // ShowHitTestCheck
            // 
            ShowHitTestCheck.AutoSize = true;
            ShowHitTestCheck.Location = new System.Drawing.Point( 7, 7 );
            ShowHitTestCheck.Margin = new Padding( 4, 3, 4, 3 );
            ShowHitTestCheck.Name = "ShowHitTestCheck";
            ShowHitTestCheck.Size = new System.Drawing.Size( 98, 19 );
            ShowHitTestCheck.TabIndex = 0;
            ShowHitTestCheck.Text = "Show Hit Test";
            ShowHitTestCheck.UseVisualStyleBackColor = true;
            // 
            // ModifiedTabFontDialog
            // 
            ModifiedTabFontDialog.AllowScriptChange = false;
            ModifiedTabFontDialog.FontMustExist = true;
            ModifiedTabFontDialog.ShowColor = true;
            // 
            // NormalTabFontDialog
            // 
            NormalTabFontDialog.AllowScriptChange = false;
            NormalTabFontDialog.FontMustExist = true;
            NormalTabFontDialog.ShowColor = true;
            // 
            // TortoiseGitProcExeLocationDialog
            // 
            TortoiseGitProcExeLocationDialog.FileName = "TortoiseGitProc.exe";
            // 
            // restoreSettingsButton
            // 
            restoreSettingsButton.Anchor =  AnchorStyles.Bottom  |  AnchorStyles.Left ;
            restoreSettingsButton.Location = new System.Drawing.Point( 12, 517 );
            restoreSettingsButton.Name = "restoreSettingsButton";
            restoreSettingsButton.Size = new System.Drawing.Size( 120, 27 );
            restoreSettingsButton.TabIndex = 13;
            restoreSettingsButton.Text = "Restore Settings";
            restoreSettingsButton.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AcceptButton = OK;
            AutoScaleDimensions = new System.Drawing.SizeF( 96F, 96F );
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = Cancel;
            ClientSize = new System.Drawing.Size( 799, 556 );
            Controls.Add( restoreSettingsButton );
            Controls.Add( SettingsTabs );
            Controls.Add( Cancel );
            Controls.Add( OK );
            KeyPreview = true;
            Margin = new Padding( 4, 3, 4, 3 );
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size( 581, 456 );
            Name = "SettingsForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            ( (System.ComponentModel.ISupportInitialize)MaxRecentReposNumeric ).EndInit();
            SettingsTabs.ResumeLayout( false );
            KeyboardShortcutsPage.ResumeLayout( false );
            KeyboardShortcutsPage.PerformLayout();
            StartupReposTab.ResumeLayout( false );
            StartupReposTab.PerformLayout();
            GitActionsTab.ResumeLayout( false );
            GitActionsTab.PerformLayout();
            GitActionsOptionsGroup.ResumeLayout( false );
            GitActionsOptionsGroup.PerformLayout();
            CustomActionsTab.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)CustomActionsDataGridView ).EndInit();
            DisplaySettingsTab.ResumeLayout( false );
            DisplaySettingsTab.PerformLayout();
            repoNameReplacersGroup.ResumeLayout( false );
            repoNameReplacersPanel.ResumeLayout( false );
            repoNameReplacersPanel.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)repoNameReplacersGridView ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)repoNameReplacersBindingSource ).EndInit();
            NormalTabFontGroup.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize)CheckForModifiedTabsIntervalNumeric ).EndInit();
            ModifiedTabFontGroup.ResumeLayout( false );
            OtherSettingsTab.ResumeLayout( false );
            OtherSettingsTab.PerformLayout();
            DeveloperSettingsPage.ResumeLayout( false );
            DeveloperSettingsPage.PerformLayout();
            ResumeLayout( false );

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
        private CheckBox ShowChangelogOnUpdateCheck;
        private CheckBox HideReferencesDisplayCheck;
        private Button TortoiseGitProcExeLocationBrowse;
        private TextBox TortoiseGitProcExeLocationText;
        private Label TortoiseGitProcExeLocationLabel;
        private OpenFileDialog TortoiseGitProcExeLocationDialog;
        private FolderBrowserDialog folderDialog;
        private Button restoreSettingsButton;
        private DataGridView repoNameReplacersGridView;
        private BindingSource repoNameReplacersBindingSource;
        private GroupBox repoNameReplacersGroup;
        private Label repoNameReplacersHelperLabel;
        private DataGridViewTextBoxColumn repoNameReplacersGridViewPatternColumn;
        private DataGridViewTextBoxColumn repoNameReplacersGridViewReplacementColumn;
        private Panel repoNameReplacersPanel;
    }
}