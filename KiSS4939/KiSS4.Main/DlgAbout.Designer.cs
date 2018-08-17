namespace KiSS4.Main
{
    partial class DlgAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgAbout));
            this.picKiSSLogo = new System.Windows.Forms.PictureBox();
            this.edtAboutKiSS = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblAboutTeam = new System.Windows.Forms.Label();
            this.panAboutTeam = new System.Windows.Forms.Panel();
            this.tmrEnlargeShrink = new System.Windows.Forms.Timer(this.components);
            this.tmrScrollingLabel = new System.Windows.Forms.Timer(this.components);
            this.lblOwnerLink = new System.Windows.Forms.LinkLabel();
            this.tabSystemInfo = new KiSS4.Gui.KissTabControlEx();
            this.tpgAbout = new SharpLibrary.WinControls.TabPageEx();
            this.btnCopyAbout = new System.Windows.Forms.Button();
            this.tpgDatabase = new SharpLibrary.WinControls.TabPageEx();
            this.btnCopyDatabase = new System.Windows.Forms.Button();
            this.edtAboutDatabase = new System.Windows.Forms.RichTextBox();
            this.tpgDatabaseVersions = new SharpLibrary.WinControls.TabPageEx();
            this.lblDatabaseVersionsCount = new KiSS4.Gui.KissLabel();
            this.grdDatabaseVersions = new System.Windows.Forms.DataGridView();
            this.btnDatabaseVersionShowChanges = new System.Windows.Forms.Button();
            this.btnCopyDatabaseVersion = new System.Windows.Forms.Button();
            this.lblDatabaseVersionsInfo = new KiSS4.Gui.KissLabel();
            this.tpgAvailableAssemblies = new SharpLibrary.WinControls.TabPageEx();
            this.lblAvailableAssembliesCount = new KiSS4.Gui.KissLabel();
            this.grdAvailableAssemblies = new System.Windows.Forms.DataGridView();
            this.btnRefreshAvailableAssemblies = new System.Windows.Forms.Button();
            this.btnCopyAvailableAssemblies = new System.Windows.Forms.Button();
            this.lblAvailableAssembliesInfo = new KiSS4.Gui.KissLabel();
            this.tpgMemory = new SharpLibrary.WinControls.TabPageEx();
            this.lblMemoryCount = new KiSS4.Gui.KissLabel();
            this.lblMemoryLoadedAssemblies = new KiSS4.Gui.KissLabel();
            this.grdLoadedModules = new System.Windows.Forms.DataGridView();
            this.btnRefreshMemoryInfo = new System.Windows.Forms.Button();
            this.btnClearCache = new System.Windows.Forms.Button();
            this.btnGarbageCollector = new System.Windows.Forms.Button();
            this.btnCopyMemoryInfo = new System.Windows.Forms.Button();
            this.edtMemoryInfo = new System.Windows.Forms.RichTextBox();
            this.tpgTempFiles = new SharpLibrary.WinControls.TabPageEx();
            this.btnRefreshTempFiles = new System.Windows.Forms.Button();
            this.btnCopyTempFilePath = new System.Windows.Forms.Button();
            this.btnViewTempFile = new System.Windows.Forms.Button();
            this.grdTempFiles = new System.Windows.Forms.DataGridView();
            this.ttpAbout = new System.Windows.Forms.ToolTip(this.components);
            this.qryDatabaseVersions = new KiSS4.DB.SqlQuery(this.components);
            this.btnCleanTempFiles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picKiSSLogo)).BeginInit();
            this.panAboutTeam.SuspendLayout();
            this.tabSystemInfo.SuspendLayout();
            this.tpgAbout.SuspendLayout();
            this.tpgDatabase.SuspendLayout();
            this.tpgDatabaseVersions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatabaseVersionsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatabaseVersions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatabaseVersionsInfo)).BeginInit();
            this.tpgAvailableAssemblies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAvailableAssembliesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAvailableAssemblies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAvailableAssembliesInfo)).BeginInit();
            this.tpgMemory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblMemoryCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMemoryLoadedAssemblies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoadedModules)).BeginInit();
            this.tpgTempFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTempFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDatabaseVersions)).BeginInit();
            this.SuspendLayout();
            // 
            // picKiSSLogo
            // 
            this.picKiSSLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picKiSSLogo.Image = ((System.Drawing.Image)(resources.GetObject("picKiSSLogo.Image")));
            this.picKiSSLogo.Location = new System.Drawing.Point(12, 12);
            this.picKiSSLogo.Name = "picKiSSLogo";
            this.picKiSSLogo.Size = new System.Drawing.Size(114, 32);
            this.picKiSSLogo.TabIndex = 2;
            this.picKiSSLogo.TabStop = false;
            this.picKiSSLogo.Click += new System.EventHandler(this.picKiSSLogo_Click);
            // 
            // edtAboutKiSS
            // 
            this.edtAboutKiSS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAboutKiSS.BackColor = System.Drawing.Color.White;
            this.edtAboutKiSS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edtAboutKiSS.Cursor = System.Windows.Forms.Cursors.Default;
            this.edtAboutKiSS.Location = new System.Drawing.Point(6, 6);
            this.edtAboutKiSS.Name = "edtAboutKiSS";
            this.edtAboutKiSS.ReadOnly = true;
            this.edtAboutKiSS.Size = new System.Drawing.Size(526, 429);
            this.edtAboutKiSS.TabIndex = 0;
            this.edtAboutKiSS.TabStop = false;
            this.edtAboutKiSS.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(264, 521);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 26);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&OK";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblAboutTeam
            // 
            this.lblAboutTeam.AutoSize = true;
            this.lblAboutTeam.Location = new System.Drawing.Point(0, 0);
            this.lblAboutTeam.Name = "lblAboutTeam";
            this.lblAboutTeam.Size = new System.Drawing.Size(203, 15);
            this.lblAboutTeam.TabIndex = 0;
            this.lblAboutTeam.Text = "<Scrolling-Team-Label (Autosized)>";
            this.lblAboutTeam.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panAboutTeam
            // 
            this.panAboutTeam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panAboutTeam.Controls.Add(this.lblAboutTeam);
            this.panAboutTeam.Location = new System.Drawing.Point(6, 462);
            this.panAboutTeam.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.panAboutTeam.Name = "panAboutTeam";
            this.panAboutTeam.Size = new System.Drawing.Size(526, 4);
            this.panAboutTeam.TabIndex = 1;
            // 
            // tmrEnlargeShrink
            // 
            this.tmrEnlargeShrink.Interval = 50;
            this.tmrEnlargeShrink.Tick += new System.EventHandler(this.tmrEnlargeShrink_Tick);
            // 
            // tmrScrollingLabel
            // 
            this.tmrScrollingLabel.Interval = 250;
            this.tmrScrollingLabel.Tick += new System.EventHandler(this.tmrScrollingLabel_Tick);
            // 
            // lblOwnerLink
            // 
            this.lblOwnerLink.ActiveLinkColor = System.Drawing.Color.Teal;
            this.lblOwnerLink.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblOwnerLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblOwnerLink.LinkColor = System.Drawing.SystemColors.ControlText;
            this.lblOwnerLink.Location = new System.Drawing.Point(12, 50);
            this.lblOwnerLink.Name = "lblOwnerLink";
            this.lblOwnerLink.Size = new System.Drawing.Size(114, 17);
            this.lblOwnerLink.TabIndex = 1;
            this.lblOwnerLink.TabStop = true;
            this.lblOwnerLink.Text = "www.diartis.ch";
            this.lblOwnerLink.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblOwnerLink.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.lblOwnerLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblOwnerLink_LinkClicked);
            // 
            // tabSystemInfo
            // 
            this.tabSystemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSystemInfo.Controls.Add(this.tpgAbout);
            this.tabSystemInfo.Controls.Add(this.tpgDatabase);
            this.tabSystemInfo.Controls.Add(this.tpgDatabaseVersions);
            this.tabSystemInfo.Controls.Add(this.tpgAvailableAssemblies);
            this.tabSystemInfo.Controls.Add(this.tpgMemory);
            this.tabSystemInfo.Controls.Add(this.tpgTempFiles);
            this.tabSystemInfo.FirstTabMargin = 4;
            this.tabSystemInfo.Location = new System.Drawing.Point(132, 7);
            this.tabSystemInfo.Name = "tabSystemInfo";
            this.tabSystemInfo.ShowClose = false;
            this.tabSystemInfo.ShowFixedWidthTooltip = true;
            this.tabSystemInfo.Size = new System.Drawing.Size(550, 508);
            this.tabSystemInfo.TabIndex = 2;
            this.tabSystemInfo.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgAbout,
            this.tpgDatabase,
            this.tpgDatabaseVersions,
            this.tpgAvailableAssemblies,
            this.tpgMemory,
            this.tpgTempFiles});
            this.tabSystemInfo.TabsLineColor = System.Drawing.Color.Black;
            this.tabSystemInfo.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabSystemInfo.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabSystemInfo.VerticalMargin = 3;
            this.tabSystemInfo.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabSystemInfo_SelectedTabChanged);
            // 
            // tpgAbout
            // 
            this.tpgAbout.Controls.Add(this.btnCopyAbout);
            this.tpgAbout.Controls.Add(this.edtAboutKiSS);
            this.tpgAbout.Controls.Add(this.panAboutTeam);
            this.tpgAbout.Location = new System.Drawing.Point(6, 30);
            this.tpgAbout.Name = "tpgAbout";
            this.tpgAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tpgAbout.Size = new System.Drawing.Size(538, 472);
            this.tpgAbout.TabIndex = 0;
            this.tpgAbout.Title = "Ü&ber";
            // 
            // btnCopyAbout
            // 
            this.btnCopyAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyAbout.Image")));
            this.btnCopyAbout.Location = new System.Drawing.Point(506, 441);
            this.btnCopyAbout.Name = "btnCopyAbout";
            this.btnCopyAbout.Size = new System.Drawing.Size(26, 26);
            this.btnCopyAbout.TabIndex = 2;
            this.btnCopyAbout.UseVisualStyleBackColor = true;
            this.btnCopyAbout.Click += new System.EventHandler(this.btnCopyAbout_Click);
            // 
            // tpgDatabase
            // 
            this.tpgDatabase.Controls.Add(this.btnCopyDatabase);
            this.tpgDatabase.Controls.Add(this.edtAboutDatabase);
            this.tpgDatabase.Location = new System.Drawing.Point(6, 30);
            this.tpgDatabase.Name = "tpgDatabase";
            this.tpgDatabase.Size = new System.Drawing.Size(538, 472);
            this.tpgDatabase.TabIndex = 3;
            this.tpgDatabase.Title = "&Datenbank";
            // 
            // btnCopyDatabase
            // 
            this.btnCopyDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyDatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyDatabase.Image")));
            this.btnCopyDatabase.Location = new System.Drawing.Point(506, 441);
            this.btnCopyDatabase.Name = "btnCopyDatabase";
            this.btnCopyDatabase.Size = new System.Drawing.Size(26, 26);
            this.btnCopyDatabase.TabIndex = 1;
            this.btnCopyDatabase.UseVisualStyleBackColor = true;
            this.btnCopyDatabase.Click += new System.EventHandler(this.btnCopyDatabase_Click);
            // 
            // edtAboutDatabase
            // 
            this.edtAboutDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAboutDatabase.BackColor = System.Drawing.Color.White;
            this.edtAboutDatabase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edtAboutDatabase.Cursor = System.Windows.Forms.Cursors.Default;
            this.edtAboutDatabase.Location = new System.Drawing.Point(6, 6);
            this.edtAboutDatabase.Name = "edtAboutDatabase";
            this.edtAboutDatabase.ReadOnly = true;
            this.edtAboutDatabase.Size = new System.Drawing.Size(526, 429);
            this.edtAboutDatabase.TabIndex = 0;
            this.edtAboutDatabase.TabStop = false;
            this.edtAboutDatabase.Text = "";
            // 
            // tpgDatabaseVersions
            // 
            this.tpgDatabaseVersions.Controls.Add(this.lblDatabaseVersionsCount);
            this.tpgDatabaseVersions.Controls.Add(this.grdDatabaseVersions);
            this.tpgDatabaseVersions.Controls.Add(this.btnDatabaseVersionShowChanges);
            this.tpgDatabaseVersions.Controls.Add(this.btnCopyDatabaseVersion);
            this.tpgDatabaseVersions.Controls.Add(this.lblDatabaseVersionsInfo);
            this.tpgDatabaseVersions.Location = new System.Drawing.Point(6, 30);
            this.tpgDatabaseVersions.Name = "tpgDatabaseVersions";
            this.tpgDatabaseVersions.Size = new System.Drawing.Size(538, 472);
            this.tpgDatabaseVersions.TabIndex = 4;
            this.tpgDatabaseVersions.Title = "Datenbank-&Versionen";
            // 
            // lblDatabaseVersionsCount
            // 
            this.lblDatabaseVersionsCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDatabaseVersionsCount.Location = new System.Drawing.Point(6, 441);
            this.lblDatabaseVersionsCount.Name = "lblDatabaseVersionsCount";
            this.lblDatabaseVersionsCount.Size = new System.Drawing.Size(462, 24);
            this.lblDatabaseVersionsCount.TabIndex = 2;
            this.lblDatabaseVersionsCount.Text = "Anzahl Einträge: <Count>";
            // 
            // grdDatabaseVersions
            // 
            this.grdDatabaseVersions.AllowUserToAddRows = false;
            this.grdDatabaseVersions.AllowUserToDeleteRows = false;
            this.grdDatabaseVersions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDatabaseVersions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdDatabaseVersions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDatabaseVersions.Location = new System.Drawing.Point(6, 29);
            this.grdDatabaseVersions.Name = "grdDatabaseVersions";
            this.grdDatabaseVersions.ReadOnly = true;
            this.grdDatabaseVersions.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdDatabaseVersions.RowHeadersWidth = 20;
            this.grdDatabaseVersions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdDatabaseVersions.RowTemplate.Height = 20;
            this.grdDatabaseVersions.RowTemplate.ReadOnly = true;
            this.grdDatabaseVersions.ShowEditingIcon = false;
            this.grdDatabaseVersions.Size = new System.Drawing.Size(526, 406);
            this.grdDatabaseVersions.TabIndex = 1;
            // 
            // btnDatabaseVersionShowChanges
            // 
            this.btnDatabaseVersionShowChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDatabaseVersionShowChanges.Image = ((System.Drawing.Image)(resources.GetObject("btnDatabaseVersionShowChanges.Image")));
            this.btnDatabaseVersionShowChanges.Location = new System.Drawing.Point(506, 441);
            this.btnDatabaseVersionShowChanges.Name = "btnDatabaseVersionShowChanges";
            this.btnDatabaseVersionShowChanges.Size = new System.Drawing.Size(26, 26);
            this.btnDatabaseVersionShowChanges.TabIndex = 4;
            this.btnDatabaseVersionShowChanges.UseVisualStyleBackColor = true;
            this.btnDatabaseVersionShowChanges.Click += new System.EventHandler(this.btnDatabaseVersionShowChanges_Click);
            // 
            // btnCopyDatabaseVersion
            // 
            this.btnCopyDatabaseVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyDatabaseVersion.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyDatabaseVersion.Image")));
            this.btnCopyDatabaseVersion.Location = new System.Drawing.Point(474, 441);
            this.btnCopyDatabaseVersion.Name = "btnCopyDatabaseVersion";
            this.btnCopyDatabaseVersion.Size = new System.Drawing.Size(26, 26);
            this.btnCopyDatabaseVersion.TabIndex = 3;
            this.btnCopyDatabaseVersion.UseVisualStyleBackColor = true;
            this.btnCopyDatabaseVersion.Click += new System.EventHandler(this.btnCopyDatabaseVersion_Click);
            // 
            // lblDatabaseVersionsInfo
            // 
            this.lblDatabaseVersionsInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDatabaseVersionsInfo.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblDatabaseVersionsInfo.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblDatabaseVersionsInfo.Location = new System.Drawing.Point(6, 6);
            this.lblDatabaseVersionsInfo.Name = "lblDatabaseVersionsInfo";
            this.lblDatabaseVersionsInfo.Size = new System.Drawing.Size(526, 20);
            this.lblDatabaseVersionsInfo.TabIndex = 0;
            this.lblDatabaseVersionsInfo.Text = "Hier werden die gespeicherten Datenbank-Versionen angezeigt:";
            // 
            // tpgAvailableAssemblies
            // 
            this.tpgAvailableAssemblies.Controls.Add(this.lblAvailableAssembliesCount);
            this.tpgAvailableAssemblies.Controls.Add(this.grdAvailableAssemblies);
            this.tpgAvailableAssemblies.Controls.Add(this.btnRefreshAvailableAssemblies);
            this.tpgAvailableAssemblies.Controls.Add(this.btnCopyAvailableAssemblies);
            this.tpgAvailableAssemblies.Controls.Add(this.lblAvailableAssembliesInfo);
            this.tpgAvailableAssemblies.Location = new System.Drawing.Point(6, 30);
            this.tpgAvailableAssemblies.Name = "tpgAvailableAssemblies";
            this.tpgAvailableAssemblies.Padding = new System.Windows.Forms.Padding(3);
            this.tpgAvailableAssemblies.Size = new System.Drawing.Size(538, 472);
            this.tpgAvailableAssemblies.TabIndex = 0;
            this.tpgAvailableAssemblies.Title = "&Assemblies";
            // 
            // lblAvailableAssembliesCount
            // 
            this.lblAvailableAssembliesCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvailableAssembliesCount.Location = new System.Drawing.Point(6, 441);
            this.lblAvailableAssembliesCount.Name = "lblAvailableAssembliesCount";
            this.lblAvailableAssembliesCount.Size = new System.Drawing.Size(462, 24);
            this.lblAvailableAssembliesCount.TabIndex = 2;
            this.lblAvailableAssembliesCount.Text = "Anzahl Assemblies: <Count>";
            // 
            // grdAvailableAssemblies
            // 
            this.grdAvailableAssemblies.AllowUserToAddRows = false;
            this.grdAvailableAssemblies.AllowUserToDeleteRows = false;
            this.grdAvailableAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAvailableAssemblies.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdAvailableAssemblies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAvailableAssemblies.Location = new System.Drawing.Point(6, 41);
            this.grdAvailableAssemblies.Name = "grdAvailableAssemblies";
            this.grdAvailableAssemblies.ReadOnly = true;
            this.grdAvailableAssemblies.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdAvailableAssemblies.RowHeadersWidth = 20;
            this.grdAvailableAssemblies.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdAvailableAssemblies.RowTemplate.Height = 20;
            this.grdAvailableAssemblies.RowTemplate.ReadOnly = true;
            this.grdAvailableAssemblies.ShowEditingIcon = false;
            this.grdAvailableAssemblies.Size = new System.Drawing.Size(526, 394);
            this.grdAvailableAssemblies.TabIndex = 1;
            // 
            // btnRefreshAvailableAssemblies
            // 
            this.btnRefreshAvailableAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshAvailableAssemblies.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshAvailableAssemblies.Image")));
            this.btnRefreshAvailableAssemblies.Location = new System.Drawing.Point(506, 441);
            this.btnRefreshAvailableAssemblies.Name = "btnRefreshAvailableAssemblies";
            this.btnRefreshAvailableAssemblies.Size = new System.Drawing.Size(26, 26);
            this.btnRefreshAvailableAssemblies.TabIndex = 4;
            this.btnRefreshAvailableAssemblies.UseVisualStyleBackColor = true;
            this.btnRefreshAvailableAssemblies.Click += new System.EventHandler(this.btnRefreshAvailableAssemblies_Click);
            // 
            // btnCopyAvailableAssemblies
            // 
            this.btnCopyAvailableAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyAvailableAssemblies.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyAvailableAssemblies.Image")));
            this.btnCopyAvailableAssemblies.Location = new System.Drawing.Point(474, 441);
            this.btnCopyAvailableAssemblies.Name = "btnCopyAvailableAssemblies";
            this.btnCopyAvailableAssemblies.Size = new System.Drawing.Size(26, 26);
            this.btnCopyAvailableAssemblies.TabIndex = 3;
            this.btnCopyAvailableAssemblies.UseVisualStyleBackColor = true;
            this.btnCopyAvailableAssemblies.Click += new System.EventHandler(this.btnCopyAvailableAssemblies_Click);
            // 
            // lblAvailableAssembliesInfo
            // 
            this.lblAvailableAssembliesInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvailableAssembliesInfo.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblAvailableAssembliesInfo.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAvailableAssembliesInfo.Location = new System.Drawing.Point(6, 6);
            this.lblAvailableAssembliesInfo.Name = "lblAvailableAssembliesInfo";
            this.lblAvailableAssembliesInfo.Size = new System.Drawing.Size(526, 32);
            this.lblAvailableAssembliesInfo.TabIndex = 0;
            this.lblAvailableAssembliesInfo.Text = "Hier werden die im Anwendungsverzeichnis vorhandenen .NET Assemblies mit Versions" +
    "informationen angezeigt:";
            // 
            // tpgMemory
            // 
            this.tpgMemory.Controls.Add(this.lblMemoryCount);
            this.tpgMemory.Controls.Add(this.lblMemoryLoadedAssemblies);
            this.tpgMemory.Controls.Add(this.grdLoadedModules);
            this.tpgMemory.Controls.Add(this.btnRefreshMemoryInfo);
            this.tpgMemory.Controls.Add(this.btnClearCache);
            this.tpgMemory.Controls.Add(this.btnGarbageCollector);
            this.tpgMemory.Controls.Add(this.btnCopyMemoryInfo);
            this.tpgMemory.Controls.Add(this.edtMemoryInfo);
            this.tpgMemory.Location = new System.Drawing.Point(6, 30);
            this.tpgMemory.Name = "tpgMemory";
            this.tpgMemory.Padding = new System.Windows.Forms.Padding(3);
            this.tpgMemory.Size = new System.Drawing.Size(538, 472);
            this.tpgMemory.TabIndex = 2;
            this.tpgMemory.Title = "&Speicher";
            // 
            // lblMemoryCount
            // 
            this.lblMemoryCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMemoryCount.Location = new System.Drawing.Point(6, 441);
            this.lblMemoryCount.Name = "lblMemoryCount";
            this.lblMemoryCount.Size = new System.Drawing.Size(398, 24);
            this.lblMemoryCount.TabIndex = 3;
            this.lblMemoryCount.Text = "Anzahl geladener Module/Assemblies: <Count>";
            // 
            // lblMemoryLoadedAssemblies
            // 
            this.lblMemoryLoadedAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMemoryLoadedAssemblies.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblMemoryLoadedAssemblies.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblMemoryLoadedAssemblies.Location = new System.Drawing.Point(3, 93);
            this.lblMemoryLoadedAssemblies.Name = "lblMemoryLoadedAssemblies";
            this.lblMemoryLoadedAssemblies.Size = new System.Drawing.Size(529, 19);
            this.lblMemoryLoadedAssemblies.TabIndex = 1;
            this.lblMemoryLoadedAssemblies.Text = "Hier werden die zurzeit geladenen Module (M) und Assemblies (A) angezeigt:";
            // 
            // grdLoadedModules
            // 
            this.grdLoadedModules.AllowUserToAddRows = false;
            this.grdLoadedModules.AllowUserToDeleteRows = false;
            this.grdLoadedModules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLoadedModules.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdLoadedModules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLoadedModules.Location = new System.Drawing.Point(6, 115);
            this.grdLoadedModules.Name = "grdLoadedModules";
            this.grdLoadedModules.ReadOnly = true;
            this.grdLoadedModules.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdLoadedModules.RowHeadersWidth = 20;
            this.grdLoadedModules.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdLoadedModules.RowTemplate.Height = 20;
            this.grdLoadedModules.RowTemplate.ReadOnly = true;
            this.grdLoadedModules.ShowEditingIcon = false;
            this.grdLoadedModules.Size = new System.Drawing.Size(526, 320);
            this.grdLoadedModules.TabIndex = 2;
            // 
            // btnRefreshMemoryInfo
            // 
            this.btnRefreshMemoryInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshMemoryInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshMemoryInfo.Image")));
            this.btnRefreshMemoryInfo.Location = new System.Drawing.Point(506, 441);
            this.btnRefreshMemoryInfo.Name = "btnRefreshMemoryInfo";
            this.btnRefreshMemoryInfo.Size = new System.Drawing.Size(26, 26);
            this.btnRefreshMemoryInfo.TabIndex = 7;
            this.btnRefreshMemoryInfo.UseVisualStyleBackColor = true;
            this.btnRefreshMemoryInfo.Click += new System.EventHandler(this.btnRefreshMemoryInfo_Click);
            // 
            // btnClearCache
            // 
            this.btnClearCache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearCache.Image = ((System.Drawing.Image)(resources.GetObject("btnClearCache.Image")));
            this.btnClearCache.Location = new System.Drawing.Point(442, 441);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(26, 26);
            this.btnClearCache.TabIndex = 5;
            this.btnClearCache.UseVisualStyleBackColor = true;
            this.btnClearCache.Click += new System.EventHandler(this.btnClearCache_Click);
            // 
            // btnGarbageCollector
            // 
            this.btnGarbageCollector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGarbageCollector.Image = ((System.Drawing.Image)(resources.GetObject("btnGarbageCollector.Image")));
            this.btnGarbageCollector.Location = new System.Drawing.Point(410, 441);
            this.btnGarbageCollector.Name = "btnGarbageCollector";
            this.btnGarbageCollector.Size = new System.Drawing.Size(26, 26);
            this.btnGarbageCollector.TabIndex = 4;
            this.btnGarbageCollector.UseVisualStyleBackColor = true;
            this.btnGarbageCollector.Click += new System.EventHandler(this.btnGarbageCollector_Click);
            // 
            // btnCopyMemoryInfo
            // 
            this.btnCopyMemoryInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyMemoryInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyMemoryInfo.Image")));
            this.btnCopyMemoryInfo.Location = new System.Drawing.Point(474, 441);
            this.btnCopyMemoryInfo.Name = "btnCopyMemoryInfo";
            this.btnCopyMemoryInfo.Size = new System.Drawing.Size(26, 26);
            this.btnCopyMemoryInfo.TabIndex = 6;
            this.btnCopyMemoryInfo.UseVisualStyleBackColor = true;
            this.btnCopyMemoryInfo.Click += new System.EventHandler(this.btnCopyMemoryInfo_Click);
            // 
            // edtMemoryInfo
            // 
            this.edtMemoryInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMemoryInfo.BackColor = System.Drawing.Color.White;
            this.edtMemoryInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edtMemoryInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.edtMemoryInfo.Location = new System.Drawing.Point(6, 6);
            this.edtMemoryInfo.Name = "edtMemoryInfo";
            this.edtMemoryInfo.ReadOnly = true;
            this.edtMemoryInfo.Size = new System.Drawing.Size(526, 84);
            this.edtMemoryInfo.TabIndex = 0;
            this.edtMemoryInfo.TabStop = false;
            this.edtMemoryInfo.Text = "";
            // 
            // tpgTempFiles
            // 
            this.tpgTempFiles.Controls.Add(this.btnCleanTempFiles);
            this.tpgTempFiles.Controls.Add(this.btnRefreshTempFiles);
            this.tpgTempFiles.Controls.Add(this.btnCopyTempFilePath);
            this.tpgTempFiles.Controls.Add(this.btnViewTempFile);
            this.tpgTempFiles.Controls.Add(this.grdTempFiles);
            this.tpgTempFiles.Location = new System.Drawing.Point(6, 30);
            this.tpgTempFiles.Name = "tpgTempFiles";
            this.tpgTempFiles.Size = new System.Drawing.Size(538, 472);
            this.tpgTempFiles.TabIndex = 5;
            this.tpgTempFiles.Title = "Temp Files";
            // 
            // btnRefreshTempFiles
            // 
            this.btnRefreshTempFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshTempFiles.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshTempFiles.Image")));
            this.btnRefreshTempFiles.Location = new System.Drawing.Point(477, 443);
            this.btnRefreshTempFiles.Name = "btnRefreshTempFiles";
            this.btnRefreshTempFiles.Size = new System.Drawing.Size(26, 26);
            this.btnRefreshTempFiles.TabIndex = 3;
            this.btnRefreshTempFiles.UseVisualStyleBackColor = true;
            this.btnRefreshTempFiles.Click += new System.EventHandler(this.btnRefreshTempFiles_Click);
            // 
            // btnCopyTempFilePath
            // 
            this.btnCopyTempFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyTempFilePath.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyTempFilePath.Image")));
            this.btnCopyTempFilePath.Location = new System.Drawing.Point(445, 443);
            this.btnCopyTempFilePath.Name = "btnCopyTempFilePath";
            this.btnCopyTempFilePath.Size = new System.Drawing.Size(26, 26);
            this.btnCopyTempFilePath.TabIndex = 2;
            this.btnCopyTempFilePath.UseVisualStyleBackColor = true;
            this.btnCopyTempFilePath.Click += new System.EventHandler(this.btnCopyTempFilePath_Click);
            // 
            // btnViewTempFile
            // 
            this.btnViewTempFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewTempFile.Image = ((System.Drawing.Image)(resources.GetObject("btnViewTempFile.Image")));
            this.btnViewTempFile.Location = new System.Drawing.Point(413, 443);
            this.btnViewTempFile.Name = "btnViewTempFile";
            this.btnViewTempFile.Size = new System.Drawing.Size(26, 26);
            this.btnViewTempFile.TabIndex = 1;
            this.btnViewTempFile.UseVisualStyleBackColor = true;
            this.btnViewTempFile.Click += new System.EventHandler(this.btnViewTempFile_Click);
            // 
            // grdTempFiles
            // 
            this.grdTempFiles.AllowUserToAddRows = false;
            this.grdTempFiles.AllowUserToDeleteRows = false;
            this.grdTempFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTempFiles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdTempFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTempFiles.Location = new System.Drawing.Point(3, 3);
            this.grdTempFiles.Name = "grdTempFiles";
            this.grdTempFiles.ReadOnly = true;
            this.grdTempFiles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdTempFiles.RowHeadersWidth = 20;
            this.grdTempFiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdTempFiles.RowTemplate.Height = 20;
            this.grdTempFiles.RowTemplate.ReadOnly = true;
            this.grdTempFiles.ShowEditingIcon = false;
            this.grdTempFiles.Size = new System.Drawing.Size(532, 434);
            this.grdTempFiles.TabIndex = 0;
            this.grdTempFiles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTempFiles_CellDoubleClick);
            // 
            // qryDatabaseVersions
            // 
            this.qryDatabaseVersions.AutoApplyUserRights = false;
            this.qryDatabaseVersions.HostControl = this;
            this.qryDatabaseVersions.TableName = "XDBVersion";
            // 
            // btnCleanTempFiles
            // 
            this.btnCleanTempFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCleanTempFiles.Image = ((System.Drawing.Image)(resources.GetObject("btnCleanTempFiles.Image")));
            this.btnCleanTempFiles.Location = new System.Drawing.Point(509, 443);
            this.btnCleanTempFiles.Name = "btnCleanTempFiles";
            this.btnCleanTempFiles.Size = new System.Drawing.Size(26, 26);
            this.btnCleanTempFiles.TabIndex = 4;
            this.btnCleanTempFiles.UseVisualStyleBackColor = true;
            this.btnCleanTempFiles.Click += new System.EventHandler(this.btnCleanTempFiles_Click);
            // 
            // DlgAbout
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(694, 556);
            this.Controls.Add(this.lblOwnerLink);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.picKiSSLogo);
            this.Controls.Add(this.tabSystemInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DlgAbout";
            this.Text = "Über";
            this.Resize += new System.EventHandler(this.DlgAbout_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picKiSSLogo)).EndInit();
            this.panAboutTeam.ResumeLayout(false);
            this.panAboutTeam.PerformLayout();
            this.tabSystemInfo.ResumeLayout(false);
            this.tpgAbout.ResumeLayout(false);
            this.tpgDatabase.ResumeLayout(false);
            this.tpgDatabaseVersions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblDatabaseVersionsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatabaseVersions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatabaseVersionsInfo)).EndInit();
            this.tpgAvailableAssemblies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAvailableAssembliesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAvailableAssemblies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAvailableAssembliesInfo)).EndInit();
            this.tpgMemory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblMemoryCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMemoryLoadedAssemblies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLoadedModules)).EndInit();
            this.tpgTempFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTempFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDatabaseVersions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picKiSSLogo;
        private System.Windows.Forms.RichTextBox edtAboutKiSS;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblAboutTeam;
        private System.Windows.Forms.Panel panAboutTeam;
        private System.Windows.Forms.Timer tmrEnlargeShrink;
        private System.Windows.Forms.Timer tmrScrollingLabel;
        private System.Windows.Forms.LinkLabel lblOwnerLink;
        private KiSS4.Gui.KissTabControlEx tabSystemInfo;
        private SharpLibrary.WinControls.TabPageEx tpgAbout;
        private SharpLibrary.WinControls.TabPageEx tpgAvailableAssemblies;
        private SharpLibrary.WinControls.TabPageEx tpgMemory;
        private KiSS4.Gui.KissLabel lblAvailableAssembliesInfo;
        private System.Windows.Forms.DataGridView grdAvailableAssemblies;
        private System.Windows.Forms.Button btnCopyAvailableAssemblies;
        private System.Windows.Forms.Button btnRefreshAvailableAssemblies;
        private System.Windows.Forms.Button btnCopyAbout;
        private System.Windows.Forms.RichTextBox edtMemoryInfo;
        private System.Windows.Forms.Button btnRefreshMemoryInfo;
        private System.Windows.Forms.Button btnCopyMemoryInfo;
        private System.Windows.Forms.DataGridView grdLoadedModules;
        private KiSS4.Gui.KissLabel lblMemoryLoadedAssemblies;
        private KiSS4.Gui.KissLabel lblMemoryCount;
        private KiSS4.Gui.KissLabel lblAvailableAssembliesCount;
        private System.Windows.Forms.Button btnGarbageCollector;
        private System.Windows.Forms.Button btnClearCache;
        private System.Windows.Forms.ToolTip ttpAbout;
        private SharpLibrary.WinControls.TabPageEx tpgDatabase;
        private System.Windows.Forms.Button btnCopyDatabase;
        private System.Windows.Forms.RichTextBox edtAboutDatabase;
        private SharpLibrary.WinControls.TabPageEx tpgDatabaseVersions;
        private KiSS4.Gui.KissLabel lblDatabaseVersionsCount;
        private System.Windows.Forms.DataGridView grdDatabaseVersions;
        private System.Windows.Forms.Button btnCopyDatabaseVersion;
        private KiSS4.Gui.KissLabel lblDatabaseVersionsInfo;
        private KiSS4.DB.SqlQuery qryDatabaseVersions;
        private System.Windows.Forms.Button btnDatabaseVersionShowChanges;
        private SharpLibrary.WinControls.TabPageEx tpgTempFiles;
        private System.Windows.Forms.DataGridView grdTempFiles;
        private System.Windows.Forms.Button btnCopyTempFilePath;
        private System.Windows.Forms.Button btnViewTempFile;
        private System.Windows.Forms.Button btnRefreshTempFiles;
        private System.Windows.Forms.Button btnCleanTempFiles;
    }
}