namespace TVSeriesCompanion.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.tVSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtitlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.dbPage = new System.Windows.Forms.TabPage();
            this.tvSeriesListFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.searchPage = new System.Windows.Forms.TabPage();
            this.searchTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchResultsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.upcomingPage = new System.Windows.Forms.TabPage();
            this.upcomingFolwPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.nextToSeeLabel = new System.Windows.Forms.Label();
            this.nextAiredLabel = new System.Windows.Forms.Label();
            this.middleFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.serialTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.rightDescriptionPanel = new System.Windows.Forms.TableLayoutPanel();
            this.overviewLabel = new System.Windows.Forms.Label();
            this.watchFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.seasonTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.rightFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.seasonLabel = new System.Windows.Forms.Label();
            this.episodesTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.mainTableLayout.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.dbPage.SuspendLayout();
            this.searchPage.SuspendLayout();
            this.searchTableLayout.SuspendLayout();
            this.upcomingPage.SuspendLayout();
            this.upcomingFolwPanel.SuspendLayout();
            this.middleFlowPanel.SuspendLayout();
            this.serialTablePanel.SuspendLayout();
            this.rightFlowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayout
            // 
            this.mainTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTableLayout.ColumnCount = 3;
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 375F));
            this.mainTableLayout.Controls.Add(this.mainMenu, 0, 0);
            this.mainTableLayout.Controls.Add(this.tabControl, 0, 1);
            this.mainTableLayout.Controls.Add(this.middleFlowPanel, 1, 1);
            this.mainTableLayout.Controls.Add(this.rightFlowPanel, 2, 1);
            this.mainTableLayout.Controls.Add(this.statusLabel, 0, 2);
            this.mainTableLayout.Location = new System.Drawing.Point(-1, 1);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.RowCount = 3;
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayout.Size = new System.Drawing.Size(1043, 519);
            this.mainTableLayout.TabIndex = 3;
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tVSeriesToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.MinimumSize = new System.Drawing.Size(240, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mainMenu.Size = new System.Drawing.Size(250, 20);
            this.mainMenu.TabIndex = 13;
            this.mainMenu.Text = "mainMenu";
            // 
            // tVSeriesToolStripMenuItem
            // 
            this.tVSeriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteCurrentToolStripMenuItem,
            this.deleteAllToolStripMenuItem,
            this.updateCurrentToolStripMenuItem,
            this.updateAllToolStripMenuItem});
            this.tVSeriesToolStripMenuItem.Name = "tVSeriesToolStripMenuItem";
            this.tVSeriesToolStripMenuItem.Size = new System.Drawing.Size(66, 16);
            this.tVSeriesToolStripMenuItem.Text = "TV Series";
            // 
            // deleteCurrentToolStripMenuItem
            // 
            this.deleteCurrentToolStripMenuItem.Name = "deleteCurrentToolStripMenuItem";
            this.deleteCurrentToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.deleteCurrentToolStripMenuItem.Text = "Delete current";
            this.deleteCurrentToolStripMenuItem.Click += new System.EventHandler(this.deleteCurrentToolStripMenuItem_Click);
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.deleteAllToolStripMenuItem.Text = "Delete all";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.deleteAllToolStripMenuItem_Click);
            // 
            // updateCurrentToolStripMenuItem
            // 
            this.updateCurrentToolStripMenuItem.Name = "updateCurrentToolStripMenuItem";
            this.updateCurrentToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.updateCurrentToolStripMenuItem.Text = "Update current";
            this.updateCurrentToolStripMenuItem.Click += new System.EventHandler(this.updateCurrentToolStripMenuItem_Click);
            // 
            // updateAllToolStripMenuItem
            // 
            this.updateAllToolStripMenuItem.Name = "updateAllToolStripMenuItem";
            this.updateAllToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.updateAllToolStripMenuItem.Text = "Update all";
            this.updateAllToolStripMenuItem.Click += new System.EventHandler(this.updateAllToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subtitlesToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 16);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // subtitlesToolStripMenuItem
            // 
            this.subtitlesToolStripMenuItem.Enabled = false;
            this.subtitlesToolStripMenuItem.Name = "subtitlesToolStripMenuItem";
            this.subtitlesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.subtitlesToolStripMenuItem.Text = "Subtitles";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.AllowDrop = true;
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.dbPage);
            this.tabControl.Controls.Add(this.searchPage);
            this.tabControl.Controls.Add(this.upcomingPage);
            this.tabControl.Location = new System.Drawing.Point(3, 23);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(244, 473);
            this.tabControl.TabIndex = 12;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // dbPage
            // 
            this.dbPage.Controls.Add(this.tvSeriesListFlowLayout);
            this.dbPage.Location = new System.Drawing.Point(4, 22);
            this.dbPage.Name = "dbPage";
            this.dbPage.Padding = new System.Windows.Forms.Padding(3);
            this.dbPage.Size = new System.Drawing.Size(236, 447);
            this.dbPage.TabIndex = 0;
            this.dbPage.Text = "TV Series";
            this.dbPage.UseVisualStyleBackColor = true;
            // 
            // tvSeriesListFlowLayout
            // 
            this.tvSeriesListFlowLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvSeriesListFlowLayout.AutoScroll = true;
            this.tvSeriesListFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.tvSeriesListFlowLayout.Location = new System.Drawing.Point(3, 3);
            this.tvSeriesListFlowLayout.Name = "tvSeriesListFlowLayout";
            this.tvSeriesListFlowLayout.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.tvSeriesListFlowLayout.Size = new System.Drawing.Size(233, 461);
            this.tvSeriesListFlowLayout.TabIndex = 2;
            this.tvSeriesListFlowLayout.WrapContents = false;
            // 
            // searchPage
            // 
            this.searchPage.Controls.Add(this.searchTableLayout);
            this.searchPage.Location = new System.Drawing.Point(4, 22);
            this.searchPage.Name = "searchPage";
            this.searchPage.Padding = new System.Windows.Forms.Padding(3);
            this.searchPage.Size = new System.Drawing.Size(236, 447);
            this.searchPage.TabIndex = 1;
            this.searchPage.Text = "Search";
            this.searchPage.UseVisualStyleBackColor = true;
            // 
            // searchTableLayout
            // 
            this.searchTableLayout.AutoSize = true;
            this.searchTableLayout.ColumnCount = 1;
            this.searchTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.searchTableLayout.Controls.Add(this.searchTextBox, 0, 0);
            this.searchTableLayout.Controls.Add(this.searchResultsTableLayout, 0, 1);
            this.searchTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchTableLayout.Location = new System.Drawing.Point(3, 3);
            this.searchTableLayout.Name = "searchTableLayout";
            this.searchTableLayout.RowCount = 2;
            this.searchTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.searchTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.searchTableLayout.Size = new System.Drawing.Size(230, 441);
            this.searchTableLayout.TabIndex = 0;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.BackColor = this.mainTableLayout.BackColor;
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.Location = new System.Drawing.Point(3, 3);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(224, 20);
            this.searchTextBox.TabIndex = 1;
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // searchResultsTableLayout
            // 
            this.searchResultsTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchResultsTableLayout.AutoSize = true;
            this.searchResultsTableLayout.ColumnCount = 3;
            this.searchResultsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.searchResultsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.searchResultsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.searchResultsTableLayout.Location = new System.Drawing.Point(3, 33);
            this.searchResultsTableLayout.Name = "searchResultsTableLayout";
            this.searchResultsTableLayout.RowCount = 1;
            this.searchResultsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.searchResultsTableLayout.Size = new System.Drawing.Size(224, 30);
            this.searchResultsTableLayout.TabIndex = 2;
            // 
            // upcomingPage
            // 
            this.upcomingPage.Controls.Add(this.upcomingFolwPanel);
            this.upcomingPage.Location = new System.Drawing.Point(4, 22);
            this.upcomingPage.Name = "upcomingPage";
            this.upcomingPage.Padding = new System.Windows.Forms.Padding(3);
            this.upcomingPage.Size = new System.Drawing.Size(236, 447);
            this.upcomingPage.TabIndex = 2;
            this.upcomingPage.Text = "Upcoming";
            this.upcomingPage.UseVisualStyleBackColor = true;
            // 
            // upcomingFolwPanel
            // 
            this.upcomingFolwPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.upcomingFolwPanel.AutoScroll = true;
            this.upcomingFolwPanel.Controls.Add(this.nextToSeeLabel);
            this.upcomingFolwPanel.Controls.Add(this.nextAiredLabel);
            this.upcomingFolwPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.upcomingFolwPanel.Location = new System.Drawing.Point(0, 0);
            this.upcomingFolwPanel.Name = "upcomingFolwPanel";
            this.upcomingFolwPanel.Size = new System.Drawing.Size(233, 465);
            this.upcomingFolwPanel.TabIndex = 1;
            this.upcomingFolwPanel.WrapContents = false;
            // 
            // nextToSeeLabel
            // 
            this.nextToSeeLabel.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextToSeeLabel.Location = new System.Drawing.Point(3, 0);
            this.nextToSeeLabel.Name = "nextToSeeLabel";
            this.nextToSeeLabel.Size = new System.Drawing.Size(200, 25);
            this.nextToSeeLabel.TabIndex = 0;
            this.nextToSeeLabel.Text = "You may have missed...";
            // 
            // nextAiredLabel
            // 
            this.nextAiredLabel.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextAiredLabel.Location = new System.Drawing.Point(3, 25);
            this.nextAiredLabel.Name = "nextAiredLabel";
            this.nextAiredLabel.Size = new System.Drawing.Size(200, 25);
            this.nextAiredLabel.TabIndex = 6;
            this.nextAiredLabel.Text = "Next aired";
            // 
            // middleFlowPanel
            // 
            this.middleFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.middleFlowPanel.AutoScroll = true;
            this.middleFlowPanel.Controls.Add(this.serialTablePanel);
            this.middleFlowPanel.Controls.Add(this.overviewLabel);
            this.middleFlowPanel.Controls.Add(this.watchFlowPanel);
            this.middleFlowPanel.Controls.Add(this.seasonTableLayout);
            this.middleFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.middleFlowPanel.Location = new System.Drawing.Point(253, 23);
            this.middleFlowPanel.MinimumSize = new System.Drawing.Size(400, 0);
            this.middleFlowPanel.Name = "middleFlowPanel";
            this.middleFlowPanel.Size = new System.Drawing.Size(412, 473);
            this.middleFlowPanel.TabIndex = 3;
            this.middleFlowPanel.WrapContents = false;
            this.middleFlowPanel.MouseEnter += new System.EventHandler(this.flowPanel_Enter);
            // 
            // serialTablePanel
            // 
            this.serialTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serialTablePanel.AutoScroll = true;
            this.serialTablePanel.ColumnCount = 2;
            this.serialTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.serialTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.serialTablePanel.Controls.Add(this.rightDescriptionPanel, 1, 0);
            this.serialTablePanel.Location = new System.Drawing.Point(3, 3);
            this.serialTablePanel.Name = "serialTablePanel";
            this.serialTablePanel.RowCount = 1;
            this.serialTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 269F));
            this.serialTablePanel.Size = new System.Drawing.Size(200, 269);
            this.serialTablePanel.TabIndex = 2;
            // 
            // rightDescriptionPanel
            // 
            this.rightDescriptionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightDescriptionPanel.ColumnCount = 1;
            this.rightDescriptionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rightDescriptionPanel.Location = new System.Drawing.Point(203, 3);
            this.rightDescriptionPanel.Name = "rightDescriptionPanel";
            this.rightDescriptionPanel.RowCount = 7;
            this.rightDescriptionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rightDescriptionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.rightDescriptionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.rightDescriptionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.rightDescriptionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.rightDescriptionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66611F));
            this.rightDescriptionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66945F));
            this.rightDescriptionPanel.Size = new System.Drawing.Size(1, 263);
            this.rightDescriptionPanel.TabIndex = 0;
            // 
            // overviewLabel
            // 
            this.overviewLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overviewLabel.AutoSize = true;
            this.overviewLabel.Location = new System.Drawing.Point(3, 275);
            this.overviewLabel.Name = "overviewLabel";
            this.overviewLabel.Size = new System.Drawing.Size(200, 13);
            this.overviewLabel.TabIndex = 1;
            // 
            // watchFlowPanel
            // 
            this.watchFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.watchFlowPanel.AutoSize = true;
            this.watchFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.watchFlowPanel.Location = new System.Drawing.Point(3, 291);
            this.watchFlowPanel.Name = "watchFlowPanel";
            this.watchFlowPanel.Size = new System.Drawing.Size(200, 0);
            this.watchFlowPanel.TabIndex = 2;
            // 
            // seasonTableLayout
            // 
            this.seasonTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seasonTableLayout.AutoSize = true;
            this.seasonTableLayout.ColumnCount = 4;
            this.seasonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.seasonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.seasonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.seasonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.seasonTableLayout.Location = new System.Drawing.Point(3, 297);
            this.seasonTableLayout.Name = "seasonTableLayout";
            this.seasonTableLayout.Size = new System.Drawing.Size(200, 0);
            this.seasonTableLayout.TabIndex = 3;
            // 
            // rightFlowPanel
            // 
            this.rightFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightFlowPanel.AutoScroll = true;
            this.rightFlowPanel.AutoSize = true;
            this.rightFlowPanel.Controls.Add(this.seasonLabel);
            this.rightFlowPanel.Controls.Add(this.episodesTableLayout);
            this.rightFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.rightFlowPanel.Location = new System.Drawing.Point(671, 23);
            this.rightFlowPanel.Name = "rightFlowPanel";
            this.rightFlowPanel.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.rightFlowPanel.Size = new System.Drawing.Size(369, 473);
            this.rightFlowPanel.TabIndex = 4;
            this.rightFlowPanel.WrapContents = false;
            this.rightFlowPanel.MouseEnter += new System.EventHandler(this.flowPanel_Enter);
            // 
            // seasonLabel
            // 
            this.seasonLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seasonLabel.BackColor = System.Drawing.SystemColors.Control;
            this.seasonLabel.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.seasonLabel.Location = new System.Drawing.Point(3, 0);
            this.seasonLabel.Name = "seasonLabel";
            this.seasonLabel.Size = new System.Drawing.Size(200, 23);
            this.seasonLabel.TabIndex = 0;
            this.seasonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // episodesTableLayout
            // 
            this.episodesTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.episodesTableLayout.AutoSize = true;
            this.episodesTableLayout.ColumnCount = 4;
            this.episodesTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.episodesTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.episodesTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.episodesTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.episodesTableLayout.Location = new System.Drawing.Point(3, 26);
            this.episodesTableLayout.Name = "episodesTableLayout";
            this.episodesTableLayout.Size = new System.Drawing.Size(200, 0);
            this.episodesTableLayout.TabIndex = 1;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.Location = new System.Drawing.Point(3, 499);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(244, 20);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "Ready";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 519);
            this.Controls.Add(this.mainTableLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainFrame";
            this.Text = "TV Series Companion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrame_Closing);
            this.Shown += new System.EventHandler(this.MainFrame_Shown);
            this.mainTableLayout.ResumeLayout(false);
            this.mainTableLayout.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.dbPage.ResumeLayout(false);
            this.searchPage.ResumeLayout(false);
            this.searchPage.PerformLayout();
            this.searchTableLayout.ResumeLayout(false);
            this.searchTableLayout.PerformLayout();
            this.upcomingPage.ResumeLayout(false);
            this.upcomingFolwPanel.ResumeLayout(false);
            this.middleFlowPanel.ResumeLayout(false);
            this.middleFlowPanel.PerformLayout();
            this.serialTablePanel.ResumeLayout(false);
            this.rightFlowPanel.ResumeLayout(false);
            this.rightFlowPanel.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayout;
        private System.Windows.Forms.FlowLayoutPanel middleFlowPanel;
        private System.Windows.Forms.TableLayoutPanel serialTablePanel;
        private System.Windows.Forms.TableLayoutPanel rightDescriptionPanel;
        private System.Windows.Forms.Label overviewLabel;
        private System.Windows.Forms.FlowLayoutPanel watchFlowPanel;
        private System.Windows.Forms.TableLayoutPanel seasonTableLayout;
        private System.Windows.Forms.FlowLayoutPanel rightFlowPanel;
        private System.Windows.Forms.Label seasonLabel;
        private System.Windows.Forms.TableLayoutPanel episodesTableLayout;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage dbPage;
        private System.Windows.Forms.FlowLayoutPanel tvSeriesListFlowLayout;
        private System.Windows.Forms.TabPage searchPage;
        private System.Windows.Forms.TableLayoutPanel searchTableLayout;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TableLayoutPanel searchResultsTableLayout;
        private System.Windows.Forms.TabPage upcomingPage;
        private System.Windows.Forms.FlowLayoutPanel upcomingFolwPanel;
        private System.Windows.Forms.Label nextToSeeLabel;
        private System.Windows.Forms.Label nextAiredLabel;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem tVSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subtitlesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;




    }
}