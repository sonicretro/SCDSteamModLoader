namespace SCDSteamModManager
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
			this.components = new System.ComponentModel.Container();
			this.saveButton = new System.Windows.Forms.Button();
			this.saveAndPlayButton = new System.Windows.Forms.Button();
			this.installButton = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.configureModButton = new System.Windows.Forms.Button();
			this.modBottomButton = new System.Windows.Forms.Button();
			this.modTopButton = new System.Windows.Forms.Button();
			this.buttonNewMod = new System.Windows.Forms.Button();
			this.buttonRefreshModList = new System.Windows.Forms.Button();
			this.modDescription = new System.Windows.Forms.Label();
			this.modDownButton = new System.Windows.Forms.Button();
			this.modUpButton = new System.Windows.Forms.Button();
			this.modListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.installURLHandlerButton = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.buttonCheckForUpdates = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.checkUpdateModsStartup = new System.Windows.Forms.CheckBox();
			this.numericUpdateFrequency = new System.Windows.Forms.NumericUpDown();
			this.comboUpdateFrequency = new System.Windows.Forms.ComboBox();
			this.checkUpdateStartup = new System.Windows.Forms.CheckBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.modContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.verifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.forceUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.developerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.generateManifestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpdateFrequency)).BeginInit();
			this.modContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.saveButton.Location = new System.Drawing.Point(87, 370);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 22);
			this.saveButton.TabIndex = 102;
			this.saveButton.Text = "&Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// saveAndPlayButton
			// 
			this.saveAndPlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.saveAndPlayButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.saveAndPlayButton.Location = new System.Drawing.Point(3, 370);
			this.saveAndPlayButton.Name = "saveAndPlayButton";
			this.saveAndPlayButton.Size = new System.Drawing.Size(78, 22);
			this.saveAndPlayButton.TabIndex = 101;
			this.saveAndPlayButton.Text = "Save && &Play";
			this.saveAndPlayButton.UseVisualStyleBackColor = true;
			this.saveAndPlayButton.Click += new System.EventHandler(this.saveAndPlayButton_Click);
			// 
			// installButton
			// 
			this.installButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.installButton.AutoSize = true;
			this.installButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.installButton.Location = new System.Drawing.Point(168, 370);
			this.installButton.Name = "installButton";
			this.installButton.Size = new System.Drawing.Size(80, 22);
			this.installButton.TabIndex = 103;
			this.installButton.Text = "Install loader";
			this.installButton.UseVisualStyleBackColor = true;
			this.installButton.Click += new System.EventHandler(this.installButton_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(386, 364);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.configureModButton);
			this.tabPage1.Controls.Add(this.modBottomButton);
			this.tabPage1.Controls.Add(this.modTopButton);
			this.tabPage1.Controls.Add(this.buttonNewMod);
			this.tabPage1.Controls.Add(this.buttonRefreshModList);
			this.tabPage1.Controls.Add(this.modDescription);
			this.tabPage1.Controls.Add(this.modDownButton);
			this.tabPage1.Controls.Add(this.modUpButton);
			this.tabPage1.Controls.Add(this.modListView);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(378, 338);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Mods";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// configureModButton
			// 
			this.configureModButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.configureModButton.Enabled = false;
			this.configureModButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.configureModButton.Location = new System.Drawing.Point(87, 223);
			this.configureModButton.Name = "configureModButton";
			this.configureModButton.Size = new System.Drawing.Size(75, 23);
			this.configureModButton.TabIndex = 18;
			this.configureModButton.Text = "Configure...";
			this.configureModButton.UseVisualStyleBackColor = true;
			this.configureModButton.Click += new System.EventHandler(this.configureModButton_Click);
			// 
			// modBottomButton
			// 
			this.modBottomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.modBottomButton.AutoSize = true;
			this.modBottomButton.Enabled = false;
			this.modBottomButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.modBottomButton.Location = new System.Drawing.Point(344, 90);
			this.modBottomButton.Name = "modBottomButton";
			this.modBottomButton.Size = new System.Drawing.Size(28, 22);
			this.modBottomButton.TabIndex = 17;
			this.modBottomButton.Text = "⤓";
			this.modBottomButton.UseVisualStyleBackColor = true;
			this.modBottomButton.Click += new System.EventHandler(this.modBottomButton_Click);
			// 
			// modTopButton
			// 
			this.modTopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.modTopButton.AutoSize = true;
			this.modTopButton.Enabled = false;
			this.modTopButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.modTopButton.Location = new System.Drawing.Point(344, 6);
			this.modTopButton.Name = "modTopButton";
			this.modTopButton.Size = new System.Drawing.Size(28, 22);
			this.modTopButton.TabIndex = 16;
			this.modTopButton.Text = "⤒";
			this.modTopButton.UseVisualStyleBackColor = true;
			this.modTopButton.Click += new System.EventHandler(this.modTopButton_Click);
			// 
			// buttonNewMod
			// 
			this.buttonNewMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonNewMod.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonNewMod.Location = new System.Drawing.Point(268, 223);
			this.buttonNewMod.Name = "buttonNewMod";
			this.buttonNewMod.Size = new System.Drawing.Size(75, 23);
			this.buttonNewMod.TabIndex = 14;
			this.buttonNewMod.Text = "&New...";
			this.buttonNewMod.UseVisualStyleBackColor = true;
			this.buttonNewMod.Click += new System.EventHandler(this.buttonNewMod_Click);
			// 
			// buttonRefreshModList
			// 
			this.buttonRefreshModList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRefreshModList.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonRefreshModList.Location = new System.Drawing.Point(6, 223);
			this.buttonRefreshModList.Name = "buttonRefreshModList";
			this.buttonRefreshModList.Size = new System.Drawing.Size(75, 23);
			this.buttonRefreshModList.TabIndex = 13;
			this.buttonRefreshModList.Text = "&Refresh";
			this.buttonRefreshModList.UseVisualStyleBackColor = true;
			this.buttonRefreshModList.Click += new System.EventHandler(this.buttonRefreshModList_Click);
			// 
			// modDescription
			// 
			this.modDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.modDescription.Location = new System.Drawing.Point(6, 252);
			this.modDescription.Name = "modDescription";
			this.modDescription.Size = new System.Drawing.Size(366, 36);
			this.modDescription.TabIndex = 15;
			this.modDescription.Text = "Description: No mod selected.";
			// 
			// modDownButton
			// 
			this.modDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.modDownButton.AutoSize = true;
			this.modDownButton.Enabled = false;
			this.modDownButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.modDownButton.Location = new System.Drawing.Point(344, 62);
			this.modDownButton.Name = "modDownButton";
			this.modDownButton.Size = new System.Drawing.Size(28, 22);
			this.modDownButton.TabIndex = 12;
			this.modDownButton.Text = "↓";
			this.modDownButton.UseVisualStyleBackColor = true;
			this.modDownButton.Click += new System.EventHandler(this.modDownButton_Click);
			// 
			// modUpButton
			// 
			this.modUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.modUpButton.AutoSize = true;
			this.modUpButton.Enabled = false;
			this.modUpButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.modUpButton.Location = new System.Drawing.Point(344, 34);
			this.modUpButton.Name = "modUpButton";
			this.modUpButton.Size = new System.Drawing.Size(28, 22);
			this.modUpButton.TabIndex = 11;
			this.modUpButton.Text = "↑";
			this.modUpButton.UseVisualStyleBackColor = true;
			this.modUpButton.Click += new System.EventHandler(this.modUpButton_Click);
			// 
			// modListView
			// 
			this.modListView.AllowDrop = true;
			this.modListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.modListView.CheckBoxes = true;
			this.modListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.modListView.FullRowSelect = true;
			this.modListView.HideSelection = false;
			this.modListView.Location = new System.Drawing.Point(6, 6);
			this.modListView.Name = "modListView";
			this.modListView.Size = new System.Drawing.Size(337, 211);
			this.modListView.TabIndex = 10;
			this.modListView.UseCompatibleStateImageBehavior = false;
			this.modListView.View = System.Windows.Forms.View.Details;
			this.modListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.modListView_ItemDrag);
			this.modListView.SelectedIndexChanged += new System.EventHandler(this.modListView_SelectedIndexChanged);
			this.modListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.modListView_DragDrop);
			this.modListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.modListView_DragEnter);
			this.modListView.DragOver += new System.Windows.Forms.DragEventHandler(this.modListView_DragOver);
			this.modListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.modListView_MouseClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 154;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Author";
			this.columnHeader2.Width = 113;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Version";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.installURLHandlerButton);
			this.tabPage4.Controls.Add(this.groupBox4);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(378, 338);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Options";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// installURLHandlerButton
			// 
			this.installURLHandlerButton.AutoSize = true;
			this.installURLHandlerButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.installURLHandlerButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.installURLHandlerButton.Location = new System.Drawing.Point(6, 102);
			this.installURLHandlerButton.Name = "installURLHandlerButton";
			this.installURLHandlerButton.Size = new System.Drawing.Size(113, 22);
			this.installURLHandlerButton.TabIndex = 4;
			this.installURLHandlerButton.Text = "Install URL Handler";
			this.installURLHandlerButton.UseVisualStyleBackColor = true;
			this.installURLHandlerButton.Click += new System.EventHandler(this.installURLHandlerButton_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.buttonCheckForUpdates);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.checkUpdateModsStartup);
			this.groupBox4.Controls.Add(this.numericUpdateFrequency);
			this.groupBox4.Controls.Add(this.comboUpdateFrequency);
			this.groupBox4.Controls.Add(this.checkUpdateStartup);
			this.groupBox4.Location = new System.Drawing.Point(6, 6);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(366, 90);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Updates";
			// 
			// buttonCheckForUpdates
			// 
			this.buttonCheckForUpdates.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonCheckForUpdates.Location = new System.Drawing.Point(259, 55);
			this.buttonCheckForUpdates.Name = "buttonCheckForUpdates";
			this.buttonCheckForUpdates.Size = new System.Drawing.Size(75, 23);
			this.buttonCheckForUpdates.TabIndex = 5;
			this.buttonCheckForUpdates.Text = "Check Now";
			this.buttonCheckForUpdates.UseVisualStyleBackColor = true;
			this.buttonCheckForUpdates.Click += new System.EventHandler(this.buttonCheckForUpdates_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Frequency:";
			// 
			// checkUpdateModsStartup
			// 
			this.checkUpdateModsStartup.AutoSize = true;
			this.checkUpdateModsStartup.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkUpdateModsStartup.Location = new System.Drawing.Point(133, 19);
			this.checkUpdateModsStartup.Name = "checkUpdateModsStartup";
			this.checkUpdateModsStartup.Size = new System.Drawing.Size(141, 18);
			this.checkUpdateModsStartup.TabIndex = 1;
			this.checkUpdateModsStartup.Text = "Check mods on startup";
			this.checkUpdateModsStartup.UseVisualStyleBackColor = true;
			// 
			// numericUpdateFrequency
			// 
			this.numericUpdateFrequency.Location = new System.Drawing.Point(133, 57);
			this.numericUpdateFrequency.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpdateFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpdateFrequency.Name = "numericUpdateFrequency";
			this.numericUpdateFrequency.Size = new System.Drawing.Size(120, 20);
			this.numericUpdateFrequency.TabIndex = 4;
			this.numericUpdateFrequency.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// comboUpdateFrequency
			// 
			this.comboUpdateFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboUpdateFrequency.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.comboUpdateFrequency.FormattingEnabled = true;
			this.comboUpdateFrequency.Items.AddRange(new object[] {
            "Always",
            "Hours",
            "Days",
            "Weeks"});
			this.comboUpdateFrequency.Location = new System.Drawing.Point(6, 56);
			this.comboUpdateFrequency.Name = "comboUpdateFrequency";
			this.comboUpdateFrequency.Size = new System.Drawing.Size(121, 21);
			this.comboUpdateFrequency.TabIndex = 3;
			this.comboUpdateFrequency.SelectedIndexChanged += new System.EventHandler(this.comboUpdateFrequency_SelectedIndexChanged);
			// 
			// checkUpdateStartup
			// 
			this.checkUpdateStartup.AutoSize = true;
			this.checkUpdateStartup.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkUpdateStartup.Location = new System.Drawing.Point(6, 19);
			this.checkUpdateStartup.Name = "checkUpdateStartup";
			this.checkUpdateStartup.Size = new System.Drawing.Size(113, 18);
			this.checkUpdateStartup.TabIndex = 0;
			this.checkUpdateStartup.Text = "Check on startup";
			this.checkUpdateStartup.UseVisualStyleBackColor = true;
			// 
			// modContextMenu
			// 
			this.modContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.toolStripMenuItem1,
            this.checkForUpdatesToolStripMenuItem,
            this.verifyToolStripMenuItem,
            this.forceUpdateToolStripMenuItem,
            this.uninstallToolStripMenuItem,
            this.toolStripMenuItem3,
            this.developerToolStripMenuItem});
			this.modContextMenu.Name = "modContextMenu";
			this.modContextMenu.Size = new System.Drawing.Size(171, 148);
			// 
			// openFolderToolStripMenuItem
			// 
			this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
			this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.openFolderToolStripMenuItem.Text = "Open folder";
			this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(167, 6);
			// 
			// checkForUpdatesToolStripMenuItem
			// 
			this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
			this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.checkForUpdatesToolStripMenuItem.Text = "Check for updates";
			this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
			// 
			// verifyToolStripMenuItem
			// 
			this.verifyToolStripMenuItem.Name = "verifyToolStripMenuItem";
			this.verifyToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.verifyToolStripMenuItem.Text = "Verify integrity";
			this.verifyToolStripMenuItem.Click += new System.EventHandler(this.verifyToolStripMenuItem_Click);
			// 
			// forceUpdateToolStripMenuItem
			// 
			this.forceUpdateToolStripMenuItem.Name = "forceUpdateToolStripMenuItem";
			this.forceUpdateToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.forceUpdateToolStripMenuItem.Text = "Force update";
			this.forceUpdateToolStripMenuItem.Click += new System.EventHandler(this.forceUpdateToolStripMenuItem_Click);
			// 
			// uninstallToolStripMenuItem
			// 
			this.uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
			this.uninstallToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.uninstallToolStripMenuItem.Text = "Uninstall";
			this.uninstallToolStripMenuItem.Click += new System.EventHandler(this.uninstallToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(167, 6);
			// 
			// developerToolStripMenuItem
			// 
			this.developerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateManifestToolStripMenuItem});
			this.developerToolStripMenuItem.Name = "developerToolStripMenuItem";
			this.developerToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.developerToolStripMenuItem.Text = "Developer";
			// 
			// generateManifestToolStripMenuItem
			// 
			this.generateManifestToolStripMenuItem.Name = "generateManifestToolStripMenuItem";
			this.generateManifestToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.generateManifestToolStripMenuItem.Text = "Generate manifest";
			this.generateManifestToolStripMenuItem.Click += new System.EventHandler(this.generateManifestToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 409);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.installButton);
			this.Controls.Add(this.saveAndPlayButton);
			this.Controls.Add(this.saveButton);
			this.MinimumSize = new System.Drawing.Size(400, 400);
			this.Name = "MainForm";
			this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Sonic R Mod Manager";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpdateFrequency)).EndInit();
			this.modContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button saveAndPlayButton;
		private System.Windows.Forms.Button installButton;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Button configureModButton;
		private System.Windows.Forms.Button modBottomButton;
		private System.Windows.Forms.Button modTopButton;
		private System.Windows.Forms.Button buttonNewMod;
		private System.Windows.Forms.Button buttonRefreshModList;
		private System.Windows.Forms.Label modDescription;
		private System.Windows.Forms.Button modDownButton;
		private System.Windows.Forms.Button modUpButton;
		private System.Windows.Forms.ListView modListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ContextMenuStrip modContextMenu;
		private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem verifyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem forceUpdateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uninstallToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem developerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem generateManifestToolStripMenuItem;
		private System.Windows.Forms.Button installURLHandlerButton;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button buttonCheckForUpdates;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox checkUpdateModsStartup;
		private System.Windows.Forms.NumericUpDown numericUpdateFrequency;
		private System.Windows.Forms.ComboBox comboUpdateFrequency;
		private System.Windows.Forms.CheckBox checkUpdateStartup;
	}
}