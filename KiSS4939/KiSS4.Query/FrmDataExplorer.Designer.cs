using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Query
{
    partial class FrmDataExplorer
    {
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataExplorer));
            this.panelTree = new System.Windows.Forms.Panel();
            this.btnCollapseAll = new KiSS4.Gui.KissButton();
            this.btnExpandAll = new KiSS4.Gui.KissButton();
            this.tabTree = new KiSS4.Gui.KissTabControlEx();
            this.tabAlleAbfragen = new SharpLibrary.WinControls.TabPageEx();
            this.treDataExplorer = new KiSS4.Gui.KissTree();
            this.colItemName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tabFavorites = new SharpLibrary.WinControls.TabPageEx();
            this.treFavorites = new KiSS4.Gui.KissTree();
            this.colFavorites = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panDetail = new System.Windows.Forms.Panel();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelTree.SuspendLayout();
            this.tabTree.SuspendLayout();
            this.tabAlleAbfragen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treDataExplorer)).BeginInit();
            this.tabFavorites.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treFavorites)).BeginInit();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTree
            // 
            this.panelTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panelTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTree.Controls.Add(this.btnCollapseAll);
            this.panelTree.Controls.Add(this.btnExpandAll);
            this.panelTree.Controls.Add(this.tabTree);
            this.panelTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTree.Location = new System.Drawing.Point(0, 0);
            this.panelTree.Name = "panelTree";
            this.panelTree.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.panelTree.Size = new System.Drawing.Size(255, 528);
            this.panelTree.TabIndex = 0;
            // 
            // btnCollapseAll
            // 
            this.btnCollapseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollapseAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapseAll.Image")));
            this.btnCollapseAll.Location = new System.Drawing.Point(225, 498);
            this.btnCollapseAll.Margin = new System.Windows.Forms.Padding(3, 3, 6, 0);
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.Size = new System.Drawing.Size(24, 24);
            this.btnCollapseAll.TabIndex = 2;
            this.btnCollapseAll.UseVisualStyleBackColor = false;
            this.btnCollapseAll.Click += new System.EventHandler(this.btnCollapseAll_Click);
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpandAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("btnExpandAll.Image")));
            this.btnExpandAll.Location = new System.Drawing.Point(195, 498);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(24, 24);
            this.btnExpandAll.TabIndex = 1;
            this.btnExpandAll.UseVisualStyleBackColor = false;
            this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
            // 
            // tabTree
            // 
            this.tabTree.Controls.Add(this.tabAlleAbfragen);
            this.tabTree.Controls.Add(this.tabFavorites);
            this.tabTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTree.Location = new System.Drawing.Point(0, 0);
            this.tabTree.Name = "tabTree";
            this.tabTree.ShowFixedWidthTooltip = true;
            this.tabTree.Size = new System.Drawing.Size(253, 520);
            this.tabTree.TabIndex = 0;
            this.tabTree.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabAlleAbfragen,
            this.tabFavorites});
            this.tabTree.TabsLineColor = System.Drawing.Color.Black;
            this.tabTree.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabTree.TabStop = false;
            this.tabTree.Text = "xTabControl1";
            // 
            // tabAlleAbfragen
            // 
            this.tabAlleAbfragen.Controls.Add(this.treDataExplorer);
            this.tabAlleAbfragen.Location = new System.Drawing.Point(6, 6);
            this.tabAlleAbfragen.Name = "tabAlleAbfragen";
            this.tabAlleAbfragen.Size = new System.Drawing.Size(241, 482);
            this.tabAlleAbfragen.TabIndex = 0;
            this.tabAlleAbfragen.Title = "alle Abfragen";
            // 
            // treDataExplorer
            // 
            this.treDataExplorer.AllowSortTree = true;
            this.treDataExplorer.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treDataExplorer.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treDataExplorer.Appearance.Empty.Options.UseBackColor = true;
            this.treDataExplorer.Appearance.Empty.Options.UseForeColor = true;
            this.treDataExplorer.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treDataExplorer.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDataExplorer.Appearance.EvenRow.Options.UseBackColor = true;
            this.treDataExplorer.Appearance.EvenRow.Options.UseForeColor = true;
            this.treDataExplorer.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(190)))), ((int)(((byte)(90)))));
            this.treDataExplorer.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDataExplorer.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treDataExplorer.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treDataExplorer.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(190)))), ((int)(((byte)(90)))));
            this.treDataExplorer.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDataExplorer.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treDataExplorer.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treDataExplorer.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treDataExplorer.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treDataExplorer.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDataExplorer.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treDataExplorer.Appearance.FooterPanel.Options.UseFont = true;
            this.treDataExplorer.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treDataExplorer.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treDataExplorer.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treDataExplorer.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDataExplorer.Appearance.GroupButton.Options.UseBackColor = true;
            this.treDataExplorer.Appearance.GroupButton.Options.UseFont = true;
            this.treDataExplorer.Appearance.GroupButton.Options.UseForeColor = true;
            this.treDataExplorer.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treDataExplorer.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDataExplorer.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treDataExplorer.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treDataExplorer.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treDataExplorer.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treDataExplorer.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDataExplorer.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treDataExplorer.Appearance.HeaderPanel.Options.UseFont = true;
            this.treDataExplorer.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treDataExplorer.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.treDataExplorer.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treDataExplorer.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.treDataExplorer.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treDataExplorer.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treDataExplorer.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treDataExplorer.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treDataExplorer.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treDataExplorer.Appearance.HorzLine.Options.UseBackColor = true;
            this.treDataExplorer.Appearance.HorzLine.Options.UseForeColor = true;
            this.treDataExplorer.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treDataExplorer.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treDataExplorer.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDataExplorer.Appearance.OddRow.Options.UseBackColor = true;
            this.treDataExplorer.Appearance.OddRow.Options.UseFont = true;
            this.treDataExplorer.Appearance.OddRow.Options.UseForeColor = true;
            this.treDataExplorer.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treDataExplorer.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treDataExplorer.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDataExplorer.Appearance.Preview.Options.UseBackColor = true;
            this.treDataExplorer.Appearance.Preview.Options.UseFont = true;
            this.treDataExplorer.Appearance.Preview.Options.UseForeColor = true;
            this.treDataExplorer.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treDataExplorer.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treDataExplorer.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDataExplorer.Appearance.Row.Options.UseBackColor = true;
            this.treDataExplorer.Appearance.Row.Options.UseFont = true;
            this.treDataExplorer.Appearance.Row.Options.UseForeColor = true;
            this.treDataExplorer.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(190)))), ((int)(((byte)(90)))));
            this.treDataExplorer.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDataExplorer.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treDataExplorer.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treDataExplorer.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treDataExplorer.Appearance.TreeLine.Options.UseBackColor = true;
            this.treDataExplorer.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treDataExplorer.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treDataExplorer.Appearance.VertLine.Options.UseBackColor = true;
            this.treDataExplorer.Appearance.VertLine.Options.UseForeColor = true;
            this.treDataExplorer.Appearance.VertLine.Options.UseTextOptions = true;
            this.treDataExplorer.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treDataExplorer.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colItemName});
            this.treDataExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treDataExplorer.ImageIndexFieldName = "IconID";
            this.treDataExplorer.KeyFieldName = "TreeId";
            this.treDataExplorer.Location = new System.Drawing.Point(0, 0);
            this.treDataExplorer.Name = "treDataExplorer";
            this.treDataExplorer.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treDataExplorer.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treDataExplorer.OptionsBehavior.Editable = false;
            this.treDataExplorer.OptionsBehavior.KeepSelectedOnClick = false;
            this.treDataExplorer.OptionsBehavior.MoveOnEdit = false;
            this.treDataExplorer.OptionsBehavior.ShowToolTips = false;
            this.treDataExplorer.OptionsBehavior.SmartMouseHover = false;
            this.treDataExplorer.OptionsMenu.EnableColumnMenu = false;
            this.treDataExplorer.OptionsMenu.EnableFooterMenu = false;
            this.treDataExplorer.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treDataExplorer.OptionsView.AutoWidth = false;
            this.treDataExplorer.OptionsView.EnableAppearanceEvenRow = true;
            this.treDataExplorer.OptionsView.EnableAppearanceOddRow = true;
            this.treDataExplorer.OptionsView.ShowIndicator = false;
            this.treDataExplorer.OptionsView.ShowVertLines = false;
            this.treDataExplorer.ParentFieldName = "ParentTreeId";
            this.treDataExplorer.RootValue = "-1";
            this.treDataExplorer.Size = new System.Drawing.Size(241, 482);
            this.treDataExplorer.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.treDataExplorer.TabIndex = 0;
            this.treDataExplorer.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.treDataExplorer_BeforeFocusNode);
            this.treDataExplorer.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treDataExplorer_AfterFocusNode);
            this.treDataExplorer.SizeChanged += new System.EventHandler(this.treDataExplorer_SizeChanged);
            // 
            // colItemName
            // 
            this.colItemName.Caption = "Alle Abfragen";
            this.colItemName.FieldName = "Caption";
            this.colItemName.MinWidth = 27;
            this.colItemName.Name = "colItemName";
            this.colItemName.VisibleIndex = 0;
            this.colItemName.Width = 229;
            // 
            // tabFavorites
            // 
            this.tabFavorites.Controls.Add(this.treFavorites);
            this.tabFavorites.Location = new System.Drawing.Point(6, 6);
            this.tabFavorites.Name = "tabFavorites";
            this.tabFavorites.Size = new System.Drawing.Size(241, 482);
            this.tabFavorites.TabIndex = 1;
            this.tabFavorites.Title = "Favoriten";
            this.tabFavorites.Visible = false;
            // 
            // treFavorites
            // 
            this.treFavorites.AllowSortTree = true;
            this.treFavorites.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treFavorites.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treFavorites.Appearance.Empty.Options.UseBackColor = true;
            this.treFavorites.Appearance.Empty.Options.UseForeColor = true;
            this.treFavorites.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treFavorites.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.EvenRow.Options.UseBackColor = true;
            this.treFavorites.Appearance.EvenRow.Options.UseForeColor = true;
            this.treFavorites.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(190)))), ((int)(((byte)(90)))));
            this.treFavorites.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treFavorites.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treFavorites.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(190)))), ((int)(((byte)(90)))));
            this.treFavorites.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treFavorites.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treFavorites.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treFavorites.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFavorites.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treFavorites.Appearance.FooterPanel.Options.UseFont = true;
            this.treFavorites.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treFavorites.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treFavorites.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treFavorites.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.GroupButton.Options.UseBackColor = true;
            this.treFavorites.Appearance.GroupButton.Options.UseFont = true;
            this.treFavorites.Appearance.GroupButton.Options.UseForeColor = true;
            this.treFavorites.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treFavorites.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treFavorites.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treFavorites.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treFavorites.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treFavorites.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treFavorites.Appearance.HeaderPanel.Options.UseFont = true;
            this.treFavorites.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treFavorites.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.treFavorites.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFavorites.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.treFavorites.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treFavorites.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treFavorites.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treFavorites.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treFavorites.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treFavorites.Appearance.HorzLine.Options.UseBackColor = true;
            this.treFavorites.Appearance.HorzLine.Options.UseForeColor = true;
            this.treFavorites.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treFavorites.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFavorites.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.OddRow.Options.UseBackColor = true;
            this.treFavorites.Appearance.OddRow.Options.UseFont = true;
            this.treFavorites.Appearance.OddRow.Options.UseForeColor = true;
            this.treFavorites.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treFavorites.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFavorites.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.Preview.Options.UseBackColor = true;
            this.treFavorites.Appearance.Preview.Options.UseFont = true;
            this.treFavorites.Appearance.Preview.Options.UseForeColor = true;
            this.treFavorites.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treFavorites.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFavorites.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.Row.Options.UseBackColor = true;
            this.treFavorites.Appearance.Row.Options.UseFont = true;
            this.treFavorites.Appearance.Row.Options.UseForeColor = true;
            this.treFavorites.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(190)))), ((int)(((byte)(90)))));
            this.treFavorites.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treFavorites.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treFavorites.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treFavorites.Appearance.TreeLine.Options.UseBackColor = true;
            this.treFavorites.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treFavorites.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treFavorites.Appearance.VertLine.Options.UseBackColor = true;
            this.treFavorites.Appearance.VertLine.Options.UseForeColor = true;
            this.treFavorites.Appearance.VertLine.Options.UseTextOptions = true;
            this.treFavorites.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treFavorites.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colFavorites});
            this.treFavorites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treFavorites.ImageIndexFieldName = "IconID";
            this.treFavorites.KeyFieldName = "XExplorerViewID";
            this.treFavorites.Location = new System.Drawing.Point(0, 0);
            this.treFavorites.Name = "treFavorites";
            this.treFavorites.BeginUnboundLoad();
            this.treFavorites.AppendNode(new object[] {
            "meine Klienten"}, -1, 2, 2, -1);
            this.treFavorites.AppendNode(new object[] {
            "Zahnarzt-SIL"}, -1, 2, 2, -1);
            this.treFavorites.AppendNode(new object[] {
            "Berichtsaufforderung Gasser"}, -1, 2, 2, -1);
            this.treFavorites.AppendNode(new object[] {
            "meine Fallbelastung"}, -1, 2, 2, -1);
            this.treFavorites.EndUnboundLoad();
            this.treFavorites.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treFavorites.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treFavorites.OptionsBehavior.Editable = false;
            this.treFavorites.OptionsBehavior.KeepSelectedOnClick = false;
            this.treFavorites.OptionsBehavior.MoveOnEdit = false;
            this.treFavorites.OptionsBehavior.ShowToolTips = false;
            this.treFavorites.OptionsBehavior.SmartMouseHover = false;
            this.treFavorites.OptionsMenu.EnableColumnMenu = false;
            this.treFavorites.OptionsMenu.EnableFooterMenu = false;
            this.treFavorites.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treFavorites.OptionsView.AutoWidth = false;
            this.treFavorites.OptionsView.EnableAppearanceEvenRow = true;
            this.treFavorites.OptionsView.EnableAppearanceOddRow = true;
            this.treFavorites.OptionsView.ShowIndicator = false;
            this.treFavorites.OptionsView.ShowRoot = false;
            this.treFavorites.OptionsView.ShowVertLines = false;
            this.treFavorites.RootValue = "-1";
            this.treFavorites.Size = new System.Drawing.Size(241, 482);
            this.treFavorites.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.treFavorites.TabIndex = 1;
            // 
            // colFavorites
            // 
            this.colFavorites.Caption = "Favoriten";
            this.colFavorites.FieldName = "Favoriten";
            this.colFavorites.MinWidth = 27;
            this.colFavorites.Name = "colFavorites";
            this.colFavorites.VisibleIndex = 0;
            this.colFavorites.Width = 229;
            // 
            // panDetail
            // 
            this.panDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetail.Location = new System.Drawing.Point(263, 31);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(787, 497);
            this.panDetail.TabIndex = 1;
            // 
            // splitter
            // 
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.panelTree;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(255, 0);
            this.splitter.Name = "splitter";
            this.splitter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitter.TabIndex = 8;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // panTitel
            // 
            this.panTitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panTitel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTitel.Controls.Add(this.picTitle);
            this.panTitel.Controls.Add(this.lblTitle);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(263, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(787, 31);
            this.panTitel.TabIndex = 2;
            // 
            // picTitle
            // 
            this.picTitle.Location = new System.Drawing.Point(10, 2);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(24, 26);
            this.picTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTitle.TabIndex = 0;
            this.picTitle.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(42, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(732, 27);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Titel";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Visible = false;
            // 
            // FrmDataExplorer
            // 
            this.ClientSize = new System.Drawing.Size(1050, 528);
            this.Controls.Add(this.panDetail);
            this.Controls.Add(this.panTitel);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.panelTree);
            this.Name = "FrmDataExplorer";
            this.Text = "Daten-Explorer";
            this.Load += new System.EventHandler(this.frmDataExplorer_Load);
            this.panelTree.ResumeLayout(false);
            this.tabTree.ResumeLayout(false);
            this.tabAlleAbfragen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treDataExplorer)).EndInit();
            this.tabFavorites.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treFavorites)).EndInit();
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private KiSS4.Gui.KissTree treDataExplorer;
        private KiSS4.Gui.KissTree treFavorites;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colItemName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFavorites;
        private System.Windows.Forms.Panel panelTree;
        private KiSS4.Gui.KissTabControlEx tabTree;
        private System.Windows.Forms.Panel panDetail;
        private SharpLibrary.WinControls.TabPageEx tabAlleAbfragen;
        private SharpLibrary.WinControls.TabPageEx tabFavorites;
        private KiSS4.Gui.KissSplitterCollapsible splitter;
        protected System.Windows.Forms.Panel panTitel;
        protected System.Windows.Forms.PictureBox picTitle;
        private KiSS4.Gui.KissButton btnExpandAll;
        private KiSS4.Gui.KissButton btnCollapseAll;
        protected System.Windows.Forms.Label lblTitle;
    }
}
