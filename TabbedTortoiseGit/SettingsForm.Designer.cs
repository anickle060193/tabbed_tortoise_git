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
            this.RetainLogsOnCloseCheck = new System.Windows.Forms.CheckBox();
            this.RunOnStartupCheck = new System.Windows.Forms.CheckBox();
            this.ConfirmOnCloseCheck = new System.Windows.Forms.CheckBox();
            this.MaxRecentReposNumeric = new System.Windows.Forms.NumericUpDown();
            this.MaxRecentReposLabel = new System.Windows.Forms.Label();
            this.GitActionsLabel = new System.Windows.Forms.Label();
            this.GitActionsCheckList = new System.Windows.Forms.CheckedListBox();
            this.SettingsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SettingsTabs = new System.Windows.Forms.TabControl();
            this.KeyboardShortcutsPage = new System.Windows.Forms.TabPage();
            this.KeyBoardShortcutsTableLayouut = new System.Windows.Forms.TableLayoutPanel();
            this.NextTabShortcutLabel = new System.Windows.Forms.Label();
            this.NextTabShortcutText = new System.Windows.Forms.TextBox();
            this.NewTabShortcutLabel = new System.Windows.Forms.Label();
            this.NewTabShortcutText = new System.Windows.Forms.TextBox();
            this.PreviousTabShortcutLabel = new System.Windows.Forms.Label();
            this.CloseTabShortcutLabel = new System.Windows.Forms.Label();
            this.PreviousTabShortcutText = new System.Windows.Forms.TextBox();
            this.CloseTabShortcutText = new System.Windows.Forms.TextBox();
            this.ReopenClosedTabShortcutLabel = new System.Windows.Forms.Label();
            this.ReopenClosedTabShortcutText = new System.Windows.Forms.TextBox();
            this.StartupReposTab = new System.Windows.Forms.TabPage();
            this.GitActionsTab = new System.Windows.Forms.TabPage();
            this.DisplaySettingsTab = new System.Windows.Forms.TabPage();
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
            this.NormalTabFontGroup = new System.Windows.Forms.GroupBox();
            this.NormalTabFontSample = new System.Windows.Forms.Label();
            this.ResetNormalTabFontButton = new System.Windows.Forms.Button();
            this.ChangeNormalTabFontButton = new System.Windows.Forms.Button();
            this.NormalTabFontDialog = new System.Windows.Forms.FontDialog();
            ((System.ComponentModel.ISupportInitialize)(this.MaxRecentReposNumeric)).BeginInit();
            this.SettingsTabs.SuspendLayout();
            this.KeyboardShortcutsPage.SuspendLayout();
            this.KeyBoardShortcutsTableLayouut.SuspendLayout();
            this.StartupReposTab.SuspendLayout();
            this.GitActionsTab.SuspendLayout();
            this.DisplaySettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckForModifiedTabsIntervalNumeric)).BeginInit();
            this.ModifiedTabFontGroup.SuspendLayout();
            this.OtherSettingsTab.SuspendLayout();
            this.DeveloperSettingsPage.SuspendLayout();
            this.NormalTabFontGroup.SuspendLayout();
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
            this.StartupReposList.Size = new System.Drawing.Size(443, 218);
            this.StartupReposList.TabIndex = 1;
            // 
            // AddDefaultRepo
            // 
            this.AddDefaultRepo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddDefaultRepo.Location = new System.Drawing.Point(97, 230);
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
            this.OK.Location = new System.Drawing.Point(316, 326);
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
            this.Cancel.Location = new System.Drawing.Point(397, 326);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // RemoveDefaultRepo
            // 
            this.RemoveDefaultRepo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveDefaultRepo.Location = new System.Drawing.Point(6, 230);
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
            this.OpenStartupReposOnReOpenCheck.Location = new System.Drawing.Point(6, 259);
            this.OpenStartupReposOnReOpenCheck.Name = "OpenStartupReposOnReOpenCheck";
            this.OpenStartupReposOnReOpenCheck.Size = new System.Drawing.Size(277, 17);
            this.OpenStartupReposOnReOpenCheck.TabIndex = 6;
            this.OpenStartupReposOnReOpenCheck.Text = "Open Startup Repos when re-opened from Task Tray";
            this.SettingsToolTip.SetToolTip(this.OpenStartupReposOnReOpenCheck, "Only valid when \"Retain Logs on Close\" is disabled.");
            this.OpenStartupReposOnReOpenCheck.UseVisualStyleBackColor = true;
            // 
            // RetainLogsOnCloseCheck
            // 
            this.RetainLogsOnCloseCheck.AutoSize = true;
            this.RetainLogsOnCloseCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RetainLogsOnCloseCheck.Location = new System.Drawing.Point(6, 6);
            this.RetainLogsOnCloseCheck.Name = "RetainLogsOnCloseCheck";
            this.RetainLogsOnCloseCheck.Size = new System.Drawing.Size(130, 17);
            this.RetainLogsOnCloseCheck.TabIndex = 7;
            this.RetainLogsOnCloseCheck.Text = "Retain Logs on Close:";
            this.RetainLogsOnCloseCheck.UseVisualStyleBackColor = true;
            // 
            // RunOnStartupCheck
            // 
            this.RunOnStartupCheck.AutoSize = true;
            this.RunOnStartupCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RunOnStartupCheck.Location = new System.Drawing.Point(6, 124);
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
            this.ConfirmOnCloseCheck.Location = new System.Drawing.Point(6, 55);
            this.ConfirmOnCloseCheck.Name = "ConfirmOnCloseCheck";
            this.ConfirmOnCloseCheck.Size = new System.Drawing.Size(133, 17);
            this.ConfirmOnCloseCheck.TabIndex = 10;
            this.ConfirmOnCloseCheck.Text = "Prompt Before Closing:";
            this.ConfirmOnCloseCheck.UseVisualStyleBackColor = true;
            // 
            // MaxRecentReposNumeric
            // 
            this.MaxRecentReposNumeric.Location = new System.Drawing.Point(115, 29);
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
            this.MaxRecentReposLabel.Location = new System.Drawing.Point(7, 31);
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
            this.GitActionsCheckList.Size = new System.Drawing.Size(440, 253);
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
            this.SettingsTabs.Controls.Add(this.DisplaySettingsTab);
            this.SettingsTabs.Controls.Add(this.OtherSettingsTab);
            this.SettingsTabs.Controls.Add(this.DeveloperSettingsPage);
            this.SettingsTabs.Location = new System.Drawing.Point(12, 12);
            this.SettingsTabs.Name = "SettingsTabs";
            this.SettingsTabs.SelectedIndex = 0;
            this.SettingsTabs.Size = new System.Drawing.Size(460, 308);
            this.SettingsTabs.TabIndex = 12;
            // 
            // KeyboardShortcutsPage
            // 
            this.KeyboardShortcutsPage.Controls.Add(this.KeyBoardShortcutsTableLayouut);
            this.KeyboardShortcutsPage.Location = new System.Drawing.Point(4, 22);
            this.KeyboardShortcutsPage.Name = "KeyboardShortcutsPage";
            this.KeyboardShortcutsPage.Padding = new System.Windows.Forms.Padding(3);
            this.KeyboardShortcutsPage.Size = new System.Drawing.Size(452, 282);
            this.KeyboardShortcutsPage.TabIndex = 5;
            this.KeyboardShortcutsPage.Text = "Keyboard Shortcuts";
            this.KeyboardShortcutsPage.UseVisualStyleBackColor = true;
            // 
            // KeyBoardShortcutsTableLayouut
            // 
            this.KeyBoardShortcutsTableLayouut.ColumnCount = 2;
            this.KeyBoardShortcutsTableLayouut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.KeyBoardShortcutsTableLayouut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.KeyBoardShortcutsTableLayouut.Controls.Add(this.NextTabShortcutLabel, 0, 1);
            this.KeyBoardShortcutsTableLayouut.Controls.Add(this.NextTabShortcutText, 0, 1);
            this.KeyBoardShortcutsTableLayouut.Controls.Add(this.NewTabShortcutLabel, 0, 0);
            this.KeyBoardShortcutsTableLayouut.Controls.Add(this.NewTabShortcutText, 1, 0);
            this.KeyBoardShortcutsTableLayouut.Controls.Add(this.PreviousTabShortcutLabel, 0, 2);
            this.KeyBoardShortcutsTableLayouut.Controls.Add(this.CloseTabShortcutLabel, 0, 3);
            this.KeyBoardShortcutsTableLayouut.Controls.Add(this.PreviousTabShortcutText, 1, 2);
            this.KeyBoardShortcutsTableLayouut.Controls.Add(this.CloseTabShortcutText, 1, 3);
            this.KeyBoardShortcutsTableLayouut.Controls.Add(this.ReopenClosedTabShortcutLabel, 0, 4);
            this.KeyBoardShortcutsTableLayouut.Controls.Add(this.ReopenClosedTabShortcutText, 1, 4);
            this.KeyBoardShortcutsTableLayouut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeyBoardShortcutsTableLayouut.Location = new System.Drawing.Point(3, 3);
            this.KeyBoardShortcutsTableLayouut.Name = "KeyBoardShortcutsTableLayouut";
            this.KeyBoardShortcutsTableLayouut.RowCount = 6;
            this.KeyBoardShortcutsTableLayouut.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.KeyBoardShortcutsTableLayouut.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.KeyBoardShortcutsTableLayouut.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.KeyBoardShortcutsTableLayouut.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.KeyBoardShortcutsTableLayouut.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.KeyBoardShortcutsTableLayouut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.KeyBoardShortcutsTableLayouut.Size = new System.Drawing.Size(446, 276);
            this.KeyBoardShortcutsTableLayouut.TabIndex = 2;
            // 
            // NextTabShortcutLabel
            // 
            this.NextTabShortcutLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NextTabShortcutLabel.AutoSize = true;
            this.NextTabShortcutLabel.Location = new System.Drawing.Point(3, 32);
            this.NextTabShortcutLabel.Name = "NextTabShortcutLabel";
            this.NextTabShortcutLabel.Size = new System.Drawing.Size(54, 13);
            this.NextTabShortcutLabel.TabIndex = 3;
            this.NextTabShortcutLabel.Text = "Next Tab:";
            // 
            // NextTabShortcutText
            // 
            this.NextTabShortcutText.AcceptsTab = true;
            this.NextTabShortcutText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NextTabShortcutText.Location = new System.Drawing.Point(114, 29);
            this.NextTabShortcutText.Name = "NextTabShortcutText";
            this.NextTabShortcutText.ReadOnly = true;
            this.NextTabShortcutText.ShortcutsEnabled = false;
            this.NextTabShortcutText.Size = new System.Drawing.Size(200, 20);
            this.NextTabShortcutText.TabIndex = 2;
            this.NextTabShortcutText.TabStop = false;
            this.NextTabShortcutText.WordWrap = false;
            // 
            // NewTabShortcutLabel
            // 
            this.NewTabShortcutLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NewTabShortcutLabel.AutoSize = true;
            this.NewTabShortcutLabel.Location = new System.Drawing.Point(3, 6);
            this.NewTabShortcutLabel.Name = "NewTabShortcutLabel";
            this.NewTabShortcutLabel.Size = new System.Drawing.Size(54, 13);
            this.NewTabShortcutLabel.TabIndex = 0;
            this.NewTabShortcutLabel.Text = "New Tab:";
            // 
            // NewTabShortcutText
            // 
            this.NewTabShortcutText.AcceptsTab = true;
            this.NewTabShortcutText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NewTabShortcutText.Location = new System.Drawing.Point(114, 3);
            this.NewTabShortcutText.Name = "NewTabShortcutText";
            this.NewTabShortcutText.ReadOnly = true;
            this.NewTabShortcutText.ShortcutsEnabled = false;
            this.NewTabShortcutText.Size = new System.Drawing.Size(200, 20);
            this.NewTabShortcutText.TabIndex = 1;
            this.NewTabShortcutText.TabStop = false;
            this.NewTabShortcutText.WordWrap = false;
            // 
            // PreviousTabShortcutLabel
            // 
            this.PreviousTabShortcutLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PreviousTabShortcutLabel.AutoSize = true;
            this.PreviousTabShortcutLabel.Location = new System.Drawing.Point(3, 58);
            this.PreviousTabShortcutLabel.Name = "PreviousTabShortcutLabel";
            this.PreviousTabShortcutLabel.Size = new System.Drawing.Size(73, 13);
            this.PreviousTabShortcutLabel.TabIndex = 4;
            this.PreviousTabShortcutLabel.Text = "Previous Tab:";
            // 
            // CloseTabShortcutLabel
            // 
            this.CloseTabShortcutLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CloseTabShortcutLabel.AutoSize = true;
            this.CloseTabShortcutLabel.Location = new System.Drawing.Point(3, 84);
            this.CloseTabShortcutLabel.Name = "CloseTabShortcutLabel";
            this.CloseTabShortcutLabel.Size = new System.Drawing.Size(58, 13);
            this.CloseTabShortcutLabel.TabIndex = 5;
            this.CloseTabShortcutLabel.Text = "Close Tab:";
            // 
            // PreviousTabShortcutText
            // 
            this.PreviousTabShortcutText.AcceptsTab = true;
            this.PreviousTabShortcutText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PreviousTabShortcutText.Location = new System.Drawing.Point(114, 55);
            this.PreviousTabShortcutText.Name = "PreviousTabShortcutText";
            this.PreviousTabShortcutText.ReadOnly = true;
            this.PreviousTabShortcutText.ShortcutsEnabled = false;
            this.PreviousTabShortcutText.Size = new System.Drawing.Size(200, 20);
            this.PreviousTabShortcutText.TabIndex = 7;
            this.PreviousTabShortcutText.TabStop = false;
            this.PreviousTabShortcutText.WordWrap = false;
            // 
            // CloseTabShortcutText
            // 
            this.CloseTabShortcutText.AcceptsTab = true;
            this.CloseTabShortcutText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CloseTabShortcutText.Location = new System.Drawing.Point(114, 81);
            this.CloseTabShortcutText.Name = "CloseTabShortcutText";
            this.CloseTabShortcutText.ReadOnly = true;
            this.CloseTabShortcutText.ShortcutsEnabled = false;
            this.CloseTabShortcutText.Size = new System.Drawing.Size(200, 20);
            this.CloseTabShortcutText.TabIndex = 8;
            this.CloseTabShortcutText.TabStop = false;
            this.CloseTabShortcutText.WordWrap = false;
            // 
            // ReopenClosedTabShortcutLabel
            // 
            this.ReopenClosedTabShortcutLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ReopenClosedTabShortcutLabel.AutoSize = true;
            this.ReopenClosedTabShortcutLabel.Location = new System.Drawing.Point(3, 110);
            this.ReopenClosedTabShortcutLabel.Name = "ReopenClosedTabShortcutLabel";
            this.ReopenClosedTabShortcutLabel.Size = new System.Drawing.Size(105, 13);
            this.ReopenClosedTabShortcutLabel.TabIndex = 9;
            this.ReopenClosedTabShortcutLabel.Text = "Reopen Closed Tab:";
            // 
            // ReopenClosedTabShortcutText
            // 
            this.ReopenClosedTabShortcutText.AcceptsTab = true;
            this.ReopenClosedTabShortcutText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ReopenClosedTabShortcutText.Location = new System.Drawing.Point(114, 107);
            this.ReopenClosedTabShortcutText.Name = "ReopenClosedTabShortcutText";
            this.ReopenClosedTabShortcutText.ReadOnly = true;
            this.ReopenClosedTabShortcutText.ShortcutsEnabled = false;
            this.ReopenClosedTabShortcutText.Size = new System.Drawing.Size(200, 20);
            this.ReopenClosedTabShortcutText.TabIndex = 10;
            this.ReopenClosedTabShortcutText.TabStop = false;
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
            this.StartupReposTab.Size = new System.Drawing.Size(452, 282);
            this.StartupReposTab.TabIndex = 0;
            this.StartupReposTab.Text = "Startup Repos";
            this.StartupReposTab.UseVisualStyleBackColor = true;
            // 
            // GitActionsTab
            // 
            this.GitActionsTab.Controls.Add(this.GitActionsLabel);
            this.GitActionsTab.Controls.Add(this.GitActionsCheckList);
            this.GitActionsTab.Location = new System.Drawing.Point(4, 22);
            this.GitActionsTab.Name = "GitActionsTab";
            this.GitActionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.GitActionsTab.Size = new System.Drawing.Size(452, 282);
            this.GitActionsTab.TabIndex = 1;
            this.GitActionsTab.Text = "Git Actions";
            this.GitActionsTab.UseVisualStyleBackColor = true;
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
            this.DisplaySettingsTab.Size = new System.Drawing.Size(452, 282);
            this.DisplaySettingsTab.TabIndex = 4;
            this.DisplaySettingsTab.Text = "Display";
            this.DisplaySettingsTab.UseVisualStyleBackColor = true;
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
            this.ResetModifiedTabFontButton.Location = new System.Drawing.Point(290, 215);
            this.ResetModifiedTabFontButton.Name = "ResetModifiedTabFontButton";
            this.ResetModifiedTabFontButton.Size = new System.Drawing.Size(75, 23);
            this.ResetModifiedTabFontButton.TabIndex = 2;
            this.ResetModifiedTabFontButton.Text = "Reset";
            this.ResetModifiedTabFontButton.UseVisualStyleBackColor = true;
            // 
            // ChangeModifiedTabFontButton
            // 
            this.ChangeModifiedTabFontButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeModifiedTabFontButton.Location = new System.Drawing.Point(371, 215);
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
            this.ModifiedTabFontGroup.Size = new System.Drawing.Size(440, 59);
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
            this.ModifiedTabFontSample.Size = new System.Drawing.Size(434, 40);
            this.ModifiedTabFontSample.TabIndex = 0;
            this.ModifiedTabFontSample.Text = "C:\\sample\\font.git";
            this.ModifiedTabFontSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OtherSettingsTab
            // 
            this.OtherSettingsTab.Controls.Add(this.CloseWindowOnLastTabClosedCheck);
            this.OtherSettingsTab.Controls.Add(this.CloseToSystemTrayCheck);
            this.OtherSettingsTab.Controls.Add(this.RunOnStartupCheck);
            this.OtherSettingsTab.Controls.Add(this.RetainLogsOnCloseCheck);
            this.OtherSettingsTab.Controls.Add(this.ConfirmOnCloseCheck);
            this.OtherSettingsTab.Controls.Add(this.MaxRecentReposLabel);
            this.OtherSettingsTab.Controls.Add(this.MaxRecentReposNumeric);
            this.OtherSettingsTab.Location = new System.Drawing.Point(4, 22);
            this.OtherSettingsTab.Name = "OtherSettingsTab";
            this.OtherSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.OtherSettingsTab.Size = new System.Drawing.Size(452, 282);
            this.OtherSettingsTab.TabIndex = 2;
            this.OtherSettingsTab.Text = "Other";
            this.OtherSettingsTab.UseVisualStyleBackColor = true;
            // 
            // CloseWindowOnLastTabClosedCheck
            // 
            this.CloseWindowOnLastTabClosedCheck.AutoSize = true;
            this.CloseWindowOnLastTabClosedCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseWindowOnLastTabClosedCheck.Location = new System.Drawing.Point(6, 78);
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
            this.CloseToSystemTrayCheck.Location = new System.Drawing.Point(6, 101);
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
            this.DeveloperSettingsPage.Size = new System.Drawing.Size(452, 282);
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
            // NormalTabFontGroup
            // 
            this.NormalTabFontGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NormalTabFontGroup.Controls.Add(this.NormalTabFontSample);
            this.NormalTabFontGroup.Location = new System.Drawing.Point(6, 6);
            this.NormalTabFontGroup.Name = "NormalTabFontGroup";
            this.NormalTabFontGroup.Size = new System.Drawing.Size(440, 59);
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
            this.NormalTabFontSample.Size = new System.Drawing.Size(434, 40);
            this.NormalTabFontSample.TabIndex = 0;
            this.NormalTabFontSample.Text = "C:\\sample\\font.git";
            this.NormalTabFontSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResetNormalTabFontButton
            // 
            this.ResetNormalTabFontButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetNormalTabFontButton.Location = new System.Drawing.Point(290, 71);
            this.ResetNormalTabFontButton.Name = "ResetNormalTabFontButton";
            this.ResetNormalTabFontButton.Size = new System.Drawing.Size(75, 23);
            this.ResetNormalTabFontButton.TabIndex = 8;
            this.ResetNormalTabFontButton.Text = "Reset";
            this.ResetNormalTabFontButton.UseVisualStyleBackColor = true;
            // 
            // ChangeNormalTabFontButton
            // 
            this.ChangeNormalTabFontButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeNormalTabFontButton.Location = new System.Drawing.Point(371, 71);
            this.ChangeNormalTabFontButton.Name = "ChangeNormalTabFontButton";
            this.ChangeNormalTabFontButton.Size = new System.Drawing.Size(75, 23);
            this.ChangeNormalTabFontButton.TabIndex = 7;
            this.ChangeNormalTabFontButton.Text = "Change";
            this.ChangeNormalTabFontButton.UseVisualStyleBackColor = true;
            // 
            // NormalTabFontDialog
            // 
            this.NormalTabFontDialog.AllowScriptChange = false;
            this.NormalTabFontDialog.FontMustExist = true;
            this.NormalTabFontDialog.ShowColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.SettingsTabs);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.MaxRecentReposNumeric)).EndInit();
            this.SettingsTabs.ResumeLayout(false);
            this.KeyboardShortcutsPage.ResumeLayout(false);
            this.KeyBoardShortcutsTableLayouut.ResumeLayout(false);
            this.KeyBoardShortcutsTableLayouut.PerformLayout();
            this.StartupReposTab.ResumeLayout(false);
            this.StartupReposTab.PerformLayout();
            this.GitActionsTab.ResumeLayout(false);
            this.GitActionsTab.PerformLayout();
            this.DisplaySettingsTab.ResumeLayout(false);
            this.DisplaySettingsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckForModifiedTabsIntervalNumeric)).EndInit();
            this.ModifiedTabFontGroup.ResumeLayout(false);
            this.OtherSettingsTab.ResumeLayout(false);
            this.OtherSettingsTab.PerformLayout();
            this.DeveloperSettingsPage.ResumeLayout(false);
            this.DeveloperSettingsPage.PerformLayout();
            this.NormalTabFontGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox StartupReposList;
        private System.Windows.Forms.Button AddDefaultRepo;
        private Button OK;
        private Button Cancel;
        private Button RemoveDefaultRepo;
        private CheckBox RetainLogsOnCloseCheck;
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
        private TableLayoutPanel KeyBoardShortcutsTableLayouut;
        private Label NewTabShortcutLabel;
        private TextBox NewTabShortcutText;
        private Label NextTabShortcutLabel;
        private TextBox NextTabShortcutText;
        private Label PreviousTabShortcutLabel;
        private Label CloseTabShortcutLabel;
        private TextBox PreviousTabShortcutText;
        private TextBox CloseTabShortcutText;
        private Label ReopenClosedTabShortcutLabel;
        private TextBox ReopenClosedTabShortcutText;
        private Button ResetNormalTabFontButton;
        private Button ChangeNormalTabFontButton;
        private GroupBox NormalTabFontGroup;
        private Label NormalTabFontSample;
        private FontDialog NormalTabFontDialog;
    }
}