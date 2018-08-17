using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    public class CtlFallZugriff : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlFallZugriff";

        #endregion

        #region Private Fields

        private Dictionary<int, string> _dummyDict;
        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnRemove;
        private KissButton btnRemoveAll;
        private KissButton btnSelectAll;
        private KissButton btnSelectNone;
        private KiSS4.Gui.KissButton btnSetOwner;
        private DevExpress.XtraGrid.Columns.GridColumn colAuswahl;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colFehlermledung;
        private DevExpress.XtraGrid.Columns.GridColumn colIcon;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colMA;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKuerzel;
        private DevExpress.XtraGrid.Columns.GridColumn colMutieren;
        private DevExpress.XtraGrid.Columns.GridColumn colOrgUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colProzess;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUser2;
        private DevExpress.XtraGrid.Columns.GridColumn colUserGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn colZugeteiltDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colZugeteiltDatumVon;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtFilter;
        private KiSS4.Gui.KissTextEdit edtOwnerMA;
        private KiSS4.Gui.KissTextEdit edtSucheKlient;
        private KiSS4.Gui.KissTextEdit edtSucheMA;
        private KiSS4.Gui.KissTextEdit edtSucheMAKuerzel;
        private KiSS4.Gui.KissCheckEdit edtSucheNurAktive;
        private KiSS4.Gui.KissLookUpEdit edtSucheProzess;
        private KiSS4.Gui.KissGrid grdFaLeistung;
        private KiSS4.Gui.KissGrid grdVerfuegbar;
        private KiSS4.Gui.KissGrid grdZugeteilt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFaLeistung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZugeteilt;
        private KiSS4.Gui.KissLabel lblFilter;
        private KissLabel lblGewaehlteZeilen;
        private KiSS4.Gui.KissLabel lblMABesitzrecht;
        private KiSS4.Gui.KissLabel lblSucheKlient;
        private KiSS4.Gui.KissLabel lblSucheMA;
        private KiSS4.Gui.KissLabel lblSucheMAKuerzel;
        private KiSS4.Gui.KissLabel lblSucheProzess;
        private System.Windows.Forms.Panel panBottom;
        private Panel panTop;

        /// <summary>
        /// Do not update details (e.g. if selecting all rows)
        /// </summary>
        private bool PreventUpdateDetails = false;

        private KiSS4.DB.SqlQuery qryFaLeistung;
        private KiSS4.DB.SqlQuery qryVerfuegbar;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repItemIcon;
        private ToolTip ttpFallZugriff;

        #endregion

        #endregion

        #region Constructors

        public CtlFallZugriff()
        {
            this.InitializeComponent();

            // reset empty text
            this.repItemIcon.NullText = " "; // do not display "No Image"
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFallZugriff));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panBottom = new System.Windows.Forms.Panel();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.grdZugeteilt = new KiSS4.Gui.KissGrid();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.grvZugeteilt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMutieren = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZugeteiltDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZugeteiltDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.edtOwnerMA = new KiSS4.Gui.KissTextEdit();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery(this.components);
            this.btnSetOwner = new KiSS4.Gui.KissButton();
            this.lblMABesitzrecht = new KiSS4.Gui.KissLabel();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            this.lblFilter = new KiSS4.Gui.KissLabel();
            this.grdVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
            this.grvVerfuegbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdFaLeistung = new KiSS4.Gui.KissGrid();
            this.grvFaLeistung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAuswahl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIcon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemIcon = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colProzess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAKuerzel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFehlermledung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheKlient = new KiSS4.Gui.KissLabel();
            this.edtSucheKlient = new KiSS4.Gui.KissTextEdit();
            this.lblSucheProzess = new KiSS4.Gui.KissLabel();
            this.edtSucheProzess = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheMA = new KiSS4.Gui.KissLabel();
            this.edtSucheMA = new KiSS4.Gui.KissTextEdit();
            this.lblSucheMAKuerzel = new KiSS4.Gui.KissLabel();
            this.edtSucheMAKuerzel = new KiSS4.Gui.KissTextEdit();
            this.edtSucheNurAktive = new KiSS4.Gui.KissCheckEdit();
            this.panTop = new System.Windows.Forms.Panel();
            this.btnSelectNone = new KiSS4.Gui.KissButton();
            this.btnSelectAll = new KiSS4.Gui.KissButton();
            this.lblGewaehlteZeilen = new KiSS4.Gui.KissLabel();
            this.ttpFallZugriff = new System.Windows.Forms.ToolTip(this.components);
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOwnerMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMABesitzrecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheProzess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheProzess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheProzess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMAKuerzel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMAKuerzel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNurAktive.Properties)).BeginInit();
            this.panTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblGewaehlteZeilen)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(726, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(750, 324);
            this.tabControlSearch.TabIndex = 1;
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdFaLeistung);
            this.tpgListe.Controls.Add(this.panTop);
            this.tpgListe.Size = new System.Drawing.Size(738, 286);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSucheNurAktive);
            this.tpgSuchen.Controls.Add(this.edtSucheMAKuerzel);
            this.tpgSuchen.Controls.Add(this.lblSucheMAKuerzel);
            this.tpgSuchen.Controls.Add(this.edtSucheMA);
            this.tpgSuchen.Controls.Add(this.lblSucheMA);
            this.tpgSuchen.Controls.Add(this.edtSucheProzess);
            this.tpgSuchen.Controls.Add(this.lblSucheProzess);
            this.tpgSuchen.Controls.Add(this.edtSucheKlient);
            this.tpgSuchen.Controls.Add(this.lblSucheKlient);
            this.tpgSuchen.Size = new System.Drawing.Size(738, 286);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheProzess, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheProzess, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMAKuerzel, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMAKuerzel, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheNurAktive, 0);
            //
            // panBottom
            //
            this.panBottom.Controls.Add(this.btnRemoveAll);
            this.panBottom.Controls.Add(this.btnRemove);
            this.panBottom.Controls.Add(this.grdZugeteilt);
            this.panBottom.Controls.Add(this.btnAdd);
            this.panBottom.Controls.Add(this.edtOwnerMA);
            this.panBottom.Controls.Add(this.btnSetOwner);
            this.panBottom.Controls.Add(this.lblMABesitzrecht);
            this.panBottom.Controls.Add(this.edtFilter);
            this.panBottom.Controls.Add(this.lblFilter);
            this.panBottom.Controls.Add(this.grdVerfuegbar);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 324);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(750, 226);
            this.panBottom.TabIndex = 0;
            //
            // btnRemoveAll
            //
            this.btnRemoveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(287, 151);
            this.btnRemoveAll.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 9;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            //
            // btnRemove
            //
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(287, 121);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            //
            // grdZugeteilt
            //
            this.grdZugeteilt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grdZugeteilt.DataSource = this.qryZugeteilt;
            //
            //
            //
            this.grdZugeteilt.EmbeddedNavigator.Name = "";
            this.grdZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdZugeteilt.Location = new System.Drawing.Point(322, 62);
            this.grdZugeteilt.MainView = this.grvZugeteilt;
            this.grdZugeteilt.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.grdZugeteilt.Name = "grdZugeteilt";
            this.grdZugeteilt.Size = new System.Drawing.Size(421, 158);
            this.grdZugeteilt.TabIndex = 7;
            this.grdZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZugeteilt});
            this.grdZugeteilt.DoubleClick += new System.EventHandler(this.grdZugeteilt_DoubleClick);
            //
            // qryZugeteilt
            //
            this.qryZugeteilt.CanUpdate = true;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.TableName = "FaLeistungZugriff";
            this.qryZugeteilt.BeforePost += new System.EventHandler(this.qryZugeteilt_BeforePost);
            this.qryZugeteilt.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryZugeteilt_ColumnChanged);
            //
            // grvZugeteilt
            //
            this.grvZugeteilt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZugeteilt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Empty.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Empty.Options.UseFont = true;
            this.grvZugeteilt.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.EvenRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugeteilt.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugeteilt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZugeteilt.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZugeteilt.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZugeteilt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvZugeteilt.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvZugeteilt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.OddRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.OddRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Row.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Row.Options.UseFont = true;
            this.grvZugeteilt.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvZugeteilt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZugeteilt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZugeteilt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUser,
            this.colMutieren,
            this.colZugeteiltDatumVon,
            this.colZugeteiltDatumBis});
            this.grvZugeteilt.GridControl = this.grdZugeteilt;
            this.grvZugeteilt.Name = "grvZugeteilt";
            this.grvZugeteilt.OptionsCustomization.AllowFilter = false;
            this.grvZugeteilt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZugeteilt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZugeteilt.OptionsView.ColumnAutoWidth = false;
            this.grvZugeteilt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZugeteilt.OptionsView.ShowGroupPanel = false;
            //
            // colUser
            //
            this.colUser.Caption = "MA mit Gastrecht";
            this.colUser.FieldName = "UserName";
            this.colUser.Name = "colUser";
            this.colUser.OptionsColumn.AllowEdit = false;
            this.colUser.OptionsColumn.ReadOnly = true;
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 0;
            this.colUser.Width = 185;
            //
            // colMutieren
            //
            this.colMutieren.Caption = "Mutieren";
            this.colMutieren.FieldName = "DarfMutieren";
            this.colMutieren.Name = "colMutieren";
            this.colMutieren.Visible = true;
            this.colMutieren.VisibleIndex = 1;
            this.colMutieren.Width = 65;
            //
            // colZugeteiltDatumVon
            //
            this.colZugeteiltDatumVon.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colZugeteiltDatumVon.AppearanceCell.Options.UseBackColor = true;
            this.colZugeteiltDatumVon.Caption = "DatumVon";
            this.colZugeteiltDatumVon.FieldName = "DatumVon";
            this.colZugeteiltDatumVon.Name = "colZugeteiltDatumVon";
            this.colZugeteiltDatumVon.OptionsColumn.AllowEdit = false;
            this.colZugeteiltDatumVon.OptionsColumn.AllowFocus = false;
            this.colZugeteiltDatumVon.Visible = true;
            this.colZugeteiltDatumVon.VisibleIndex = 2;
            //
            // colZugeteiltDatumBis
            //
            this.colZugeteiltDatumBis.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colZugeteiltDatumBis.AppearanceCell.Options.UseBackColor = true;
            this.colZugeteiltDatumBis.Caption = "DatumBis";
            this.colZugeteiltDatumBis.FieldName = "DatumBis";
            this.colZugeteiltDatumBis.Name = "colZugeteiltDatumBis";
            this.colZugeteiltDatumBis.OptionsColumn.AllowEdit = false;
            this.colZugeteiltDatumBis.OptionsColumn.AllowFocus = false;
            this.colZugeteiltDatumBis.Visible = true;
            this.colZugeteiltDatumBis.VisibleIndex = 3;
            //
            // btnAdd
            //
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(287, 91);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // edtOwnerMA
            //
            this.edtOwnerMA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtOwnerMA.DataMember = "MA";
            this.edtOwnerMA.DataSource = this.qryFaLeistung;
            this.edtOwnerMA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtOwnerMA.Location = new System.Drawing.Point(322, 31);
            this.edtOwnerMA.Name = "edtOwnerMA";
            this.edtOwnerMA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtOwnerMA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOwnerMA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOwnerMA.Properties.Appearance.Options.UseBackColor = true;
            this.edtOwnerMA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOwnerMA.Properties.Appearance.Options.UseFont = true;
            this.edtOwnerMA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOwnerMA.Properties.ReadOnly = true;
            this.edtOwnerMA.Size = new System.Drawing.Size(421, 24);
            this.edtOwnerMA.TabIndex = 5;
            //
            // qryFaLeistung
            //
            this.qryFaLeistung.CanUpdate = true;
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.SelectStatement = resources.GetString("qryFaLeistung.SelectStatement");
            this.qryFaLeistung.TableName = "FaLeistung";
            this.qryFaLeistung.AfterFill += new System.EventHandler(this.qryFaLeistung_AfterFill);
            this.qryFaLeistung.BeforePost += new System.EventHandler(this.qryFaLeistung_BeforePost);
            this.qryFaLeistung.PositionChanged += new System.EventHandler(this.qryFaLeistung_PositionChanged);
            //
            // btnSetOwner
            //
            this.btnSetOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetOwner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetOwner.IconID = 13;
            this.btnSetOwner.Location = new System.Drawing.Point(287, 31);
            this.btnSetOwner.Margin = new System.Windows.Forms.Padding(10, 30, 10, 3);
            this.btnSetOwner.Name = "btnSetOwner";
            this.btnSetOwner.Size = new System.Drawing.Size(28, 24);
            this.btnSetOwner.TabIndex = 4;
            this.btnSetOwner.UseCompatibleTextRendering = true;
            this.btnSetOwner.UseVisualStyleBackColor = false;
            this.btnSetOwner.Click += new System.EventHandler(this.btnSetOwner_Click);
            //
            // lblMABesitzrecht
            //
            this.lblMABesitzrecht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMABesitzrecht.Location = new System.Drawing.Point(322, 4);
            this.lblMABesitzrecht.Name = "lblMABesitzrecht";
            this.lblMABesitzrecht.Size = new System.Drawing.Size(421, 24);
            this.lblMABesitzrecht.TabIndex = 3;
            this.lblMABesitzrecht.Text = "MA mit Besitzerrechten";
            this.lblMABesitzrecht.UseCompatibleTextRendering = true;
            //
            // edtFilter
            //
            this.edtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFilter.Location = new System.Drawing.Point(67, 196);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter.Size = new System.Drawing.Size(216, 24);
            this.edtFilter.TabIndex = 2;
            this.edtFilter.EditValueChanged += new System.EventHandler(this.edtFilter_EditValueChanged);
            //
            // lblFilter
            //
            this.lblFilter.Location = new System.Drawing.Point(7, 196);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(54, 24);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "Filter";
            this.lblFilter.UseCompatibleTextRendering = true;
            //
            // grdVerfuegbar
            //
            this.grdVerfuegbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVerfuegbar.DataSource = this.qryVerfuegbar;
            //
            //
            //
            this.grdVerfuegbar.EmbeddedNavigator.Name = "";
            this.grdVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVerfuegbar.Location = new System.Drawing.Point(7, 4);
            this.grdVerfuegbar.MainView = this.grvVerfuegbar;
            this.grdVerfuegbar.Margin = new System.Windows.Forms.Padding(4);
            this.grdVerfuegbar.Name = "grdVerfuegbar";
            this.grdVerfuegbar.Size = new System.Drawing.Size(276, 185);
            this.grdVerfuegbar.TabIndex = 0;
            this.grdVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVerfuegbar});
            this.grdVerfuegbar.DoubleClick += new System.EventHandler(this.grdVerfuegbar_DoubleClick);
            this.grdVerfuegbar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdVerfuegbar_KeyPress);
            //
            // qryVerfuegbar
            //
            this.qryVerfuegbar.HostControl = this;
            this.qryVerfuegbar.TableName = "XUser";
            //
            // grvVerfuegbar
            //
            this.grvVerfuegbar.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVerfuegbar.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.Empty.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.Empty.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.EvenRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerfuegbar.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerfuegbar.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfuegbar.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfuegbar.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerfuegbar.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVerfuegbar.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVerfuegbar.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfuegbar.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.OddRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVerfuegbar.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.Row.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.Row.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfuegbar.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVerfuegbar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVerfuegbar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUser2,
            this.colOrgUnit,
            this.colUserGroupID});
            this.grvVerfuegbar.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVerfuegbar.GridControl = this.grdVerfuegbar;
            this.grvVerfuegbar.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvVerfuegbar.Name = "grvVerfuegbar";
            this.grvVerfuegbar.OptionsBehavior.Editable = false;
            this.grvVerfuegbar.OptionsCustomization.AllowFilter = false;
            this.grvVerfuegbar.OptionsFilter.AllowFilterEditor = false;
            this.grvVerfuegbar.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVerfuegbar.OptionsMenu.EnableColumnMenu = false;
            this.grvVerfuegbar.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVerfuegbar.OptionsNavigation.UseTabKey = false;
            this.grvVerfuegbar.OptionsSelection.MultiSelect = true;
            this.grvVerfuegbar.OptionsView.ColumnAutoWidth = false;
            this.grvVerfuegbar.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVerfuegbar.OptionsView.ShowGroupPanel = false;
            this.grvVerfuegbar.OptionsView.ShowIndicator = false;
            //
            // colUser2
            //
            this.colUser2.Caption = "Mitarbeiter/in";
            this.colUser2.FieldName = "UserName";
            this.colUser2.Name = "colUser2";
            this.colUser2.Visible = true;
            this.colUser2.VisibleIndex = 0;
            this.colUser2.Width = 225;
            //
            // colOrgUnit
            //
            this.colOrgUnit.Caption = "Abteilung";
            this.colOrgUnit.FieldName = "Abteilung";
            this.colOrgUnit.Name = "colOrgUnit";
            this.colOrgUnit.Visible = true;
            this.colOrgUnit.VisibleIndex = 1;
            this.colOrgUnit.Width = 120;
            //
            // colUserGroupID
            //
            this.colUserGroupID.Caption = "-";
            this.colUserGroupID.FieldName = "UserID";
            this.colUserGroupID.Name = "colUserGroupID";
            //
            // grdFaLeistung
            //
            this.grdFaLeistung.DataSource = this.qryFaLeistung;
            this.grdFaLeistung.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdFaLeistung.EmbeddedNavigator.Name = "";
            this.grdFaLeistung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdFaLeistung.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdFaLeistung.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdFaLeistung.Location = new System.Drawing.Point(0, 32);
            this.grdFaLeistung.MainView = this.grvFaLeistung;
            this.grdFaLeistung.Name = "grdFaLeistung";
            this.grdFaLeistung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemIcon});
            this.grdFaLeistung.Size = new System.Drawing.Size(738, 254);
            this.grdFaLeistung.TabIndex = 0;
            this.grdFaLeistung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFaLeistung});
            //
            // grvFaLeistung
            //
            this.grvFaLeistung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFaLeistung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.Empty.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.Empty.Options.UseFont = true;
            this.grvFaLeistung.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFaLeistung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.EvenRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFaLeistung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvFaLeistung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFaLeistung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFaLeistung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFaLeistung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaLeistung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaLeistung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFaLeistung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaLeistung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.GroupRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFaLeistung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFaLeistung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFaLeistung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFaLeistung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFaLeistung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFaLeistung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaLeistung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvFaLeistung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.OddRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFaLeistung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.Row.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.Row.Options.UseFont = true;
            this.grvFaLeistung.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFaLeistung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFaLeistung.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvFaLeistung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFaLeistung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFaLeistung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAuswahl,
            this.colKlient,
            this.colIcon,
            this.colProzess,
            this.colMA,
            this.colMAKuerzel,
            this.colDatumVon,
            this.colDatumBis,
            this.colFehlermledung});
            this.grvFaLeistung.GridControl = this.grdFaLeistung;
            this.grvFaLeistung.Name = "grvFaLeistung";
            this.grvFaLeistung.OptionsCustomization.AllowFilter = false;
            this.grvFaLeistung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFaLeistung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFaLeistung.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvFaLeistung.OptionsView.ColumnAutoWidth = false;
            this.grvFaLeistung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFaLeistung.OptionsView.ShowGroupPanel = false;
            this.grvFaLeistung.LostFocus += new System.EventHandler(this.grvFaLeistung_LostFocus);
            //
            // colAuswahl
            //
            this.colAuswahl.Caption = "Auswahl";
            this.colAuswahl.FieldName = "Auswahl";
            this.colAuswahl.Name = "colAuswahl";
            this.colAuswahl.Visible = true;
            this.colAuswahl.VisibleIndex = 0;
            this.colAuswahl.Width = 60;
            //
            // colKlient
            //
            this.colKlient.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKlient.AppearanceCell.Options.UseBackColor = true;
            this.colKlient.Caption = "Klient/in";
            this.colKlient.FieldName = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.OptionsColumn.AllowEdit = false;
            this.colKlient.OptionsColumn.AllowFocus = false;
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 1;
            this.colKlient.Width = 200;
            //
            // colIcon
            //
            this.colIcon.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colIcon.AppearanceCell.Options.UseBackColor = true;
            this.colIcon.ColumnEdit = this.repItemIcon;
            this.colIcon.FieldName = "Icon";
            this.colIcon.Name = "colIcon";
            this.colIcon.OptionsColumn.AllowEdit = false;
            this.colIcon.OptionsColumn.AllowFocus = false;
            this.colIcon.Visible = true;
            this.colIcon.VisibleIndex = 2;
            this.colIcon.Width = 22;
            //
            // repItemIcon
            //
            this.repItemIcon.CustomHeight = 16;
            this.repItemIcon.Name = "repItemIcon";
            this.repItemIcon.NullText = "No Image";
            this.repItemIcon.ReadOnly = true;
            //
            // colProzess
            //
            this.colProzess.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colProzess.AppearanceCell.Options.UseBackColor = true;
            this.colProzess.Caption = "Prozess";
            this.colProzess.FieldName = "Prozess";
            this.colProzess.Name = "colProzess";
            this.colProzess.OptionsColumn.AllowEdit = false;
            this.colProzess.OptionsColumn.AllowFocus = false;
            this.colProzess.Visible = true;
            this.colProzess.VisibleIndex = 3;
            this.colProzess.Width = 120;
            //
            // colMA
            //
            this.colMA.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colMA.AppearanceCell.Options.UseBackColor = true;
            this.colMA.Caption = "MA";
            this.colMA.FieldName = "MA";
            this.colMA.Name = "colMA";
            this.colMA.OptionsColumn.AllowEdit = false;
            this.colMA.OptionsColumn.AllowFocus = false;
            this.colMA.Visible = true;
            this.colMA.VisibleIndex = 4;
            this.colMA.Width = 150;
            //
            // colMAKuerzel
            //
            this.colMAKuerzel.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colMAKuerzel.AppearanceCell.Options.UseBackColor = true;
            this.colMAKuerzel.Caption = "Kürzel";
            this.colMAKuerzel.FieldName = "MAKuerzel";
            this.colMAKuerzel.Name = "colMAKuerzel";
            this.colMAKuerzel.OptionsColumn.AllowEdit = false;
            this.colMAKuerzel.OptionsColumn.AllowFocus = false;
            this.colMAKuerzel.Visible = true;
            this.colMAKuerzel.VisibleIndex = 5;
            this.colMAKuerzel.Width = 65;
            //
            // colDatumVon
            //
            this.colDatumVon.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDatumVon.AppearanceCell.Options.UseBackColor = true;
            this.colDatumVon.Caption = "Datum von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.OptionsColumn.AllowEdit = false;
            this.colDatumVon.OptionsColumn.AllowFocus = false;
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 6;
            this.colDatumVon.Width = 80;
            //
            // colDatumBis
            //
            this.colDatumBis.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDatumBis.AppearanceCell.Options.UseBackColor = true;
            this.colDatumBis.Caption = "Datum bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.OptionsColumn.AllowEdit = false;
            this.colDatumBis.OptionsColumn.AllowFocus = false;
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 7;
            this.colDatumBis.Width = 80;
            //
            // colFehlermledung
            //
            this.colFehlermledung.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colFehlermledung.AppearanceCell.Options.UseBackColor = true;
            this.colFehlermledung.Caption = "Fehlermeldung";
            this.colFehlermledung.Name = "colFehlermledung";
            this.colFehlermledung.OptionsColumn.AllowEdit = false;
            this.colFehlermledung.OptionsColumn.AllowFocus = false;
            this.colFehlermledung.Visible = true;
            this.colFehlermledung.VisibleIndex = 8;
            //
            // lblSucheKlient
            //
            this.lblSucheKlient.ForeColor = System.Drawing.Color.Black;
            this.lblSucheKlient.Location = new System.Drawing.Point(8, 44);
            this.lblSucheKlient.Name = "lblSucheKlient";
            this.lblSucheKlient.Size = new System.Drawing.Size(97, 24);
            this.lblSucheKlient.TabIndex = 1;
            this.lblSucheKlient.Text = "Klient/in";
            this.lblSucheKlient.UseCompatibleTextRendering = true;
            //
            // edtSucheKlient
            //
            this.edtSucheKlient.EditValue = "";
            this.edtSucheKlient.Location = new System.Drawing.Point(111, 44);
            this.edtSucheKlient.Name = "edtSucheKlient";
            this.edtSucheKlient.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKlient.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSucheKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseForeColor = true;
            this.edtSucheKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheKlient.Size = new System.Drawing.Size(239, 24);
            this.edtSucheKlient.TabIndex = 2;
            //
            // lblSucheProzess
            //
            this.lblSucheProzess.ForeColor = System.Drawing.Color.Black;
            this.lblSucheProzess.Location = new System.Drawing.Point(8, 74);
            this.lblSucheProzess.Name = "lblSucheProzess";
            this.lblSucheProzess.Size = new System.Drawing.Size(97, 24);
            this.lblSucheProzess.TabIndex = 3;
            this.lblSucheProzess.Text = "Prozess";
            this.lblSucheProzess.UseCompatibleTextRendering = true;
            //
            // edtSucheProzess
            //
            this.edtSucheProzess.Location = new System.Drawing.Point(111, 74);
            this.edtSucheProzess.LOVFilter = "ModulID > 1 AND ModulTree = 1";
            this.edtSucheProzess.LOVFilterWhereAppend = true;
            this.edtSucheProzess.LOVName = "Modul";
            this.edtSucheProzess.Name = "edtSucheProzess";
            this.edtSucheProzess.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheProzess.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheProzess.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheProzess.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheProzess.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheProzess.Properties.Appearance.Options.UseFont = true;
            this.edtSucheProzess.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheProzess.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheProzess.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheProzess.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheProzess.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheProzess.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheProzess.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheProzess.Properties.NullText = "";
            this.edtSucheProzess.Properties.ShowFooter = false;
            this.edtSucheProzess.Properties.ShowHeader = false;
            this.edtSucheProzess.Size = new System.Drawing.Size(239, 24);
            this.edtSucheProzess.TabIndex = 4;
            //
            // lblSucheMA
            //
            this.lblSucheMA.ForeColor = System.Drawing.Color.Black;
            this.lblSucheMA.Location = new System.Drawing.Point(8, 104);
            this.lblSucheMA.Name = "lblSucheMA";
            this.lblSucheMA.Size = new System.Drawing.Size(97, 24);
            this.lblSucheMA.TabIndex = 5;
            this.lblSucheMA.Text = "MA";
            this.lblSucheMA.UseCompatibleTextRendering = true;
            //
            // edtSucheMA
            //
            this.edtSucheMA.EditValue = "";
            this.edtSucheMA.Location = new System.Drawing.Point(111, 104);
            this.edtSucheMA.Name = "edtSucheMA";
            this.edtSucheMA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMA.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSucheMA.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMA.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMA.Properties.Appearance.Options.UseForeColor = true;
            this.edtSucheMA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheMA.Size = new System.Drawing.Size(239, 24);
            this.edtSucheMA.TabIndex = 6;
            //
            // lblSucheMAKuerzel
            //
            this.lblSucheMAKuerzel.ForeColor = System.Drawing.Color.Black;
            this.lblSucheMAKuerzel.Location = new System.Drawing.Point(8, 134);
            this.lblSucheMAKuerzel.Name = "lblSucheMAKuerzel";
            this.lblSucheMAKuerzel.Size = new System.Drawing.Size(97, 24);
            this.lblSucheMAKuerzel.TabIndex = 7;
            this.lblSucheMAKuerzel.Text = "MA Kürzel";
            this.lblSucheMAKuerzel.UseCompatibleTextRendering = true;
            //
            // edtSucheMAKuerzel
            //
            this.edtSucheMAKuerzel.EditValue = "";
            this.edtSucheMAKuerzel.Location = new System.Drawing.Point(111, 134);
            this.edtSucheMAKuerzel.Name = "edtSucheMAKuerzel";
            this.edtSucheMAKuerzel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMAKuerzel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMAKuerzel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMAKuerzel.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSucheMAKuerzel.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMAKuerzel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMAKuerzel.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMAKuerzel.Properties.Appearance.Options.UseForeColor = true;
            this.edtSucheMAKuerzel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheMAKuerzel.Size = new System.Drawing.Size(107, 24);
            this.edtSucheMAKuerzel.TabIndex = 8;
            //
            // edtSucheNurAktive
            //
            this.edtSucheNurAktive.EditValue = false;
            this.edtSucheNurAktive.Location = new System.Drawing.Point(111, 164);
            this.edtSucheNurAktive.Name = "edtSucheNurAktive";
            this.edtSucheNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSucheNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheNurAktive.Properties.Caption = "nur aktive Prozesse";
            this.edtSucheNurAktive.Size = new System.Drawing.Size(239, 19);
            this.edtSucheNurAktive.TabIndex = 9;
            //
            // panTop
            //
            this.panTop.Controls.Add(this.btnSelectNone);
            this.panTop.Controls.Add(this.btnSelectAll);
            this.panTop.Controls.Add(this.lblGewaehlteZeilen);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(738, 32);
            this.panTop.TabIndex = 0;
            //
            // btnSelectNone
            //
            this.btnSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectNone.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectNone.Image")));
            this.btnSelectNone.Location = new System.Drawing.Point(37, 4);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(24, 24);
            this.btnSelectNone.TabIndex = 1;
            this.btnSelectNone.UseVisualStyleBackColor = false;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            //
            // btnSelectAll
            //
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.Location = new System.Drawing.Point(7, 4);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(24, 24);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            //
            // lblGewaehlteZeilen
            //
            this.lblGewaehlteZeilen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGewaehlteZeilen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblGewaehlteZeilen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblGewaehlteZeilen.Location = new System.Drawing.Point(489, 4);
            this.lblGewaehlteZeilen.Name = "lblGewaehlteZeilen";
            this.lblGewaehlteZeilen.Size = new System.Drawing.Size(240, 24);
            this.lblGewaehlteZeilen.TabIndex = 2;
            this.lblGewaehlteZeilen.Text = "Ausgewählte Zeilen: <Anzahl>";
            this.lblGewaehlteZeilen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGewaehlteZeilen.UseCompatibleTextRendering = true;
            //
            // CtlFallZugriff
            //
            this.ActiveSQLQuery = this.qryFaLeistung;
            this.Controls.Add(this.panBottom);
            this.Name = "CtlFallZugriff";
            this.Size = new System.Drawing.Size(750, 550);
            this.Load += new System.EventHandler(this.CtlFallZugriff_Load);
            this.Controls.SetChildIndex(this.panBottom, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOwnerMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMABesitzrecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheProzess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheProzess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheProzess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMAKuerzel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMAKuerzel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNurAktive.Properties)).EndInit();
            this.panTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblGewaehlteZeilen)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            // validate first
            if (!btnAdd.Enabled || qryFaLeistung.Count < 1 || qryVerfuegbar.Count < 1 || !qryZugeteilt.Post())
            {
                return;
            }

            // get all rows the user selected
            int[] RowHandles = grdVerfuegbar.View.GetSelectedRows();
            if (RowHandles == null || RowHandles.Length < 1)
            {
                return;
            }

            // get selected ids
            string selectedIDs = "";
            Hashtable htSelectedIDs = this.GetSelectedIDs(out selectedIDs, out _dummyDict);
            DateTime datumVon = FallUtil.GetFaLeistungZugriffNewDatumVon();
            DateTime datumBis = FallUtil.GetFaLeistungZugriffNewDatumBis();

            // add all rows the user selected to all selected items
            foreach (int RowHandle in RowHandles)
            {
                int userID = Convert.ToInt32(grdVerfuegbar.View.GetRowCellValue(RowHandle, grdVerfuegbar.View.Columns["UserID"]));

                // loop selected users and loop selected items
                foreach (object faLeistungID in htSelectedIDs.Keys)
                {
                    FallUtil.GastrechtHinzufuegen(
                        userID, //Userid
                        Convert.ToInt32(faLeistungID), //FaLeistungId
                        false, // Darf mutieren.
                        datumVon, //DatumVon
                        datumBis, //DatumBis
                        false); //checkExistsFaLeistungIDUserID nicht nötig : Tabelle mit Constraint geschützt und UseCase muss abgedeckt sein
                }
            }

            // refresh changed data
            this.RefreshDisplay(htSelectedIDs);

            // refresh list
            DisplayAccessUsers();

            // clear filter and set focus
            edtFilter.EditValue = null;
            edtFilter.Focus();
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            if (!btnRemove.Enabled || qryFaLeistung.Count < 1 || qryZugeteilt.Count < 1)
            {
                return;
            }

            // get selected ids
            string selectedIDs = "";
            Hashtable htSelectedIDs = this.GetSelectedIDs(out selectedIDs, out _dummyDict);

            //Fall : Diese Zuständigkeiten waren bis heute gültig : DatumBis setzen. Diese Datensätze werden protokolliert.
            DBUtil.ExecSQL(string.Format(@"
                    UPDATE FaLeistungZugriff
                    SET DatumBis = dbo.fnDateSerial(YEAR(GETDATE()),MONTH(GETDATE()),DAY(GETDATE()))
                    WHERE FaLeistungID IN ({0})
                    AND UserID = {1}
                    AND DatumVon <= dbo.fnDateSerial(YEAR(GETDATE()),MONTH(GETDATE()),DAY(GETDATE()))",
                    selectedIDs,
                    qryZugeteilt["UserID"]));

            //Fall : Diese Zuständigkeiten waren noch nicht gültig, es mach kein Sinn Zustängkeiten zu behalten, die nie gültig war. Die Datensätze werden dann gelöscht.
            DBUtil.ExecSQL(string.Format(@"
                    DELETE
                    FROM FaLeistungZugriff
                    WHERE 1=1
                    AND FaLeistungID IN ({0})
                    AND UserID = {1}
                    AND DatumVon > dbo.fnDateSerial(YEAR(GETDATE()),MONTH(GETDATE()),DAY(GETDATE()))",
                    selectedIDs,
                    qryZugeteilt["UserID"]
                    ));

            // refresh changed data
            this.RefreshDisplay(htSelectedIDs);

            // refresh list
            DisplayAccessUsers();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (!btnRemoveAll.Enabled || qryFaLeistung.Count < 1 || qryZugeteilt.Count < 1)
            {
                return;
            }

            // get all users that are displayed
            string userIDs = "";

            foreach (DataRow row in qryZugeteilt.DataTable.Rows)
            {
                // add to string
                if (!userIDs.Equals(""))
                {
                    userIDs += ",";
                }

                userIDs += Convert.ToString(row["UserID"]);
            }

            // get selected ids
            string selectedIDs = "";
            Hashtable htSelectedIDs = this.GetSelectedIDs(out selectedIDs, out _dummyDict);

            //Fall : Diese Zuständigkeiten waren bis heute gültig : DatumBis setzen. Diese Datensätze werden protokolliert.
            DBUtil.ExecSQL(string.Format(@"
                    UPDATE FaLeistungZugriff
                    SET DatumBis = dbo.fnDateSerial(YEAR(GETDATE()),MONTH(GETDATE()),DAY(GETDATE()))
                    WHERE FaLeistungID IN ({0})
                    AND UserID IN ({1})
                    AND DatumVon <= dbo.fnDateSerial(YEAR(GETDATE()),MONTH(GETDATE()),DAY(GETDATE()))",
                    selectedIDs,
                    userIDs));

            //Fall : Diese Zuständigkeiten waren noch nicht gültig, es mach kein Sinn Zustängkeiten zu behalten, die nie gültig war. Die Datensätze werden dann gelöscht.
            DBUtil.ExecSQL(string.Format(@"
                    DELETE
                    FROM FaLeistungZugriff
                    WHERE 1=1
                    AND FaLeistungID IN ({0})
                    AND UserID IN ({1})
                    AND DatumVon > dbo.fnDateSerial(YEAR(GETDATE()),MONTH(GETDATE()),DAY(GETDATE()))",
                    selectedIDs,
                    userIDs
                    ));

            // refresh changed data
            this.RefreshDisplay(htSelectedIDs);

            // refresh list
            DisplayAccessUsers();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            // store last cursor
            Cursor lastCursor = Cursor.Current;

            try
            {
                // check if any row is available
                if (qryFaLeistung.Count < 1)
                {
                    // no row, do not continue
                    return;
                }

                // prevent update details
                this.PreventUpdateDetails = true;

                // save pending changes
                qryZugeteilt.Post();

                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // remove selection of all items to prevent hidden selection on grouping
                btnSelectNone_Click(this, EventArgs.Empty);

                // define vars
                int rowHandle = 0;
                int previousRowHandle = -999999;
                int counter = 0;

                // check if any row is selected
                if (this.grvFaLeistung.GetSelectedRows().Length < 1)
                {
                    // no row selected, select first row if none is selected
                    this.grvFaLeistung.MoveFirst();
                }

                // get handle of user's selection
                int selectedRowHandle = this.grvFaLeistung.GetSelectedRows()[0];

                // select first row to loop from top to bottom
                this.grvFaLeistung.MoveFirst();

                // apply rowhandle
                rowHandle = this.grvFaLeistung.GetSelectedRows()[0];

                // loop through rows and update flags for visible items
                while (previousRowHandle != rowHandle)
                {
                    // check if row is visible (0=group visible, 1=datarow visible, <0 = not visible)
                    if (rowHandle >= 0 && this.grvFaLeistung.IsRowVisible(rowHandle) == DevExpress.XtraGrid.Views.Grid.RowVisibleState.Visible)
                    {
                        // select this row
                        this.grvFaLeistung.SetRowCellValue(rowHandle, colAuswahl, true);
                    }

                    // move next value
                    grvFaLeistung.MoveNext();

                    // update gui to prevent hanging
                    if (counter % 500 == 0)
                    {
                        ApplicationFacade.DoEvents();
                        counter = 0;
                    }

                    counter++;

                    // apply rowhandle
                    previousRowHandle = rowHandle;
                    rowHandle = this.grvFaLeistung.GetSelectedRows()[0];
                }

                // reselect last selected row (View.SelectRow() does not work...)
                bool foundSelectedRow = false;
                this.grvFaLeistung.MoveFirst();

                while (!foundSelectedRow)
                {
                    // get handle of selected row
                    rowHandle = this.grvFaLeistung.GetSelectedRows()[0];

                    // check if row was the row the user selected before clicking the button
                    foundSelectedRow = rowHandle == selectedRowHandle;

                    // check if found or move to next row
                    if (!foundSelectedRow)
                    {
                        this.grvFaLeistung.MoveNext();
                    }

                    // update gui to prevent hanging
                    if (counter % 100 == 0)
                    {
                        ApplicationFacade.DoEvents();
                        counter = 0;
                    }

                    counter++;
                }
            }
            catch (Exception ex)
            {
                // show general message
                KissMsg.ShowError(CLASSNAME, "ErrorSelectingItems", "Es ist ein Fehler beim Auswählen der Leistungen aufgetreten.", ex);
            }
            finally
            {
                // set last cursor
                Cursor.Current = lastCursor;

                // allow update details
                this.PreventUpdateDetails = false;

                // update counter label
                this.UpdateCounter();

                // update display user
                this.DisplayAccessUsers();

                // set focus
                this.grdFaLeistung.Focus();
            }
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            // store last cursor
            Cursor lastCursor = Cursor.Current;

            // loop through all items and remove selection
            try
            {
                // save pending changes
                qryZugeteilt.Post();

                // setup cursor
                Cursor.Current = Cursors.WaitCursor;

                // remove selection
                foreach (DataRow row in qryFaLeistung.DataTable.Rows)
                {
                    row["Auswahl"] = 0;
                }

                // check if row is selected
                if (this.grvFaLeistung.GetSelectedRows().Length > 0)
                {
                    // update selected row to have proper display for selection
                    this.grvFaLeistung.RefreshRow(this.grvFaLeistung.GetSelectedRows()[0]);
                }
            }
            catch (Exception ex)
            {
                // show general message
                KissMsg.ShowError(CLASSNAME, "ErrorUnSelectingItems", "Es ist ein Fehler beim Aufheben der Auswahl der Leistungen aufgetreten.", ex);
            }
            finally
            {
                // set last cursor
                Cursor.Current = lastCursor;

                // update counter label
                this.UpdateCounter();

                // set focus
                this.grdFaLeistung.Focus();
            }
        }

        private void btnSetOwner_Click(object sender, System.EventArgs e)
        {
            if (qryVerfuegbar.Count < 1 || qryFaLeistung.Count < 1)
            {
                return;
            }

            // get selected ids
            string selectedIDs = "";
            Dictionary<int, string> leistungIdsOrderedByUserId = new Dictionary<int, string>();
            Hashtable htSelectedIDs = GetSelectedIDs(out selectedIDs, out leistungIdsOrderedByUserId);

            // check if any item is selected
            if (htSelectedIDs.Count < 1)
            {
                KissMsg.ShowInfo(CLASSNAME, "NoItemSelected", "Es muss zuerst eine Leistung ausgewählt werden.");
                return;
            }

            int newUser = Convert.ToInt32(qryVerfuegbar["UserID"]);

            //Pendenzen umhaengen: Nur offene Pendezen mit altem SAR als Empfaenger werden umgehängt
            //prüfen ob unerledigte Pendenzen existieren, die umgehaengt werden muessen
            //taskstatuscode 3 = erledigt
            int countUnerledigte = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
            SELECT COUNT(*)
            FROM dbo.XTask WITH(READUNCOMMITTED)
            WHERE FaLeistungID  IN ( SELECT Splitvalue FROM dbo.fnSplitStringToValues( {0} , ',', 1) )
            AND TaskStatusCode <> 3", selectedIDs);

            if (countUnerledigte > 0 && DBUtil.GetConfigBool(@"System\Pendenzen\Pendenzenverwaltung\FragenVorWechselLV", false))
            {
                // breche ab, wenn Frage mit nein beantwortet wird
                if (!KissMsg.ShowQuestion(CLASSNAME, "DlgWechselLeistungsverantwortung", FallUtil.LV_WECHSEL_PENDENZEN_FRAGE))
                {
                    return;
                }
            }

            Utils.InsertFaLeistungUserHist(selectedIDs);

            // update all items within selection
            DBUtil.ExecSQL(string.Format(@"
                    UPDATE FaLeistung
                    SET UserID = {0}, Modifier = '{1}', Modified = GetDate()
                    WHERE FaLeistungID IN ({2})", newUser, DBUtil.GetDBRowCreatorModifier(), selectedIDs));

            int numberNewAssignedTasks = 0;
            foreach (KeyValuePair<int, string> leistungIdCsv in leistungIdsOrderedByUserId)
            {
                numberNewAssignedTasks += Utils.AssignPendingTasksToNewReceiver(newUser, leistungIdCsv.Key, leistungIdCsv.Value);
            }

            if (numberNewAssignedTasks == 1)
            {
                KissMsg.ShowInfo(CLASSNAME, "OneInfoTaskMoved", "1 offene Pendenz wurde neu zugewiesen.", numberNewAssignedTasks);
            }
            else if (numberNewAssignedTasks > 1)
            {
                KissMsg.ShowInfo(CLASSNAME, "InfoTaskMoved", "{0} offene Pendenzen wurden neu zugewiesen.", numberNewAssignedTasks);
            }

            // refresh changed data
            this.RefreshDisplay(htSelectedIDs);
        }

        private void CtlFallZugriff_Load(object sender, System.EventArgs e)
        {
            // setup tooltiptexts
            this.ttpFallZugriff.SetToolTip(this.btnSelectAll, KissMsg.GetMLMessage(CLASSNAME, "ToolTipBtnSelectAll", "Alle sichtbaren Leistungen auswählen (nicht sichtbare Leistungen werden nicht ausgewählt)"));
            this.ttpFallZugriff.SetToolTip(this.btnSelectNone, KissMsg.GetMLMessage(CLASSNAME, "ToolTipBtnSelectNone", "Auswahl aufheben"));

            // remove delete question to prevent asking
            qryZugeteilt.DeleteQuestion = "";

            // select search tab
            this.NewSearch();

            // update counter label
            this.UpdateCounter();

            SetupGrid();
        }

        private void edtFilter_EditValueChanged(object sender, System.EventArgs e)
        {
            qryVerfuegbar.DataTable.DefaultView.RowFilter = string.Format("UserName LIKE '%{0}%'", edtFilter.EditValue);
        }

        private void grdVerfuegbar_DoubleClick(object sender, System.EventArgs e)
        {
            btnAdd.PerformClick();
        }

        private void grdVerfuegbar_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar < 'A' || e.KeyChar > 'z')
            {
                return;
            }

            for (int i = 0; i < qryVerfuegbar.Count; i++)
            {
                string UserName = qryVerfuegbar.DataTable.Rows[i]["UserName"].ToString();
                if (UserName.ToUpper().StartsWith(e.KeyChar.ToString().ToUpper()))
                {
                    qryVerfuegbar.Position = i;
                    e.Handled = true;
                    return;
                }
            }
        }

        private void grdZugeteilt_DoubleClick(object sender, System.EventArgs e)
        {
            btnRemove.PerformClick();
        }

        private void grvFaLeistung_LostFocus(object sender, EventArgs e)
        {
            // update counter label
            this.UpdateCounter();

            // update display of detail grids
            this.DisplayAccessUsers();
        }

        private void qryFaLeistung_AfterFill(object sender, EventArgs e)
        {
            // update counter label
            this.UpdateCounter();

            // update display of detail grids
            this.DisplayAccessUsers();
        }

        private void qryFaLeistung_BeforePost(object sender, System.EventArgs e)
        {
            // check if need to do action
            if (this.PreventUpdateDetails)
            {
                // discard changes
                qryFaLeistung.RowModified = false;
                qryFaLeistung.Row.AcceptChanges();
                return;
            }

            //save pending changes
            qryZugeteilt.Post();
        }

        private void qryFaLeistung_PositionChanged(object sender, System.EventArgs e)
        {
            // check if need to do action
            if (this.PreventUpdateDetails)
            {
                // do nothing
                return;
            }

            // update counter label
            this.UpdateCounter();

            // udpate display
            DisplayAccessUsers();
        }

        private void qryZugeteilt_BeforePost(object sender, EventArgs e)
        {
            // update for all selected items
            // get selected ids
            string selectedIDs = "";
            GetSelectedIDs(out selectedIDs, out _dummyDict);

            DBUtil.ExecSQL(string.Format(@"
                    UPDATE FaLeistungZugriff
                    SET DarfMutieren = {0}
                    WHERE 1=1
                    AND FaLeistungID IN ({1})
                    AND UserID = {2}
                    AND DatumBis > dbo.fnDateSerial(YEAR(GETDATE()),MONTH(GETDATE()),DAY(GETDATE())) ",
                    Convert.ToInt32(qryZugeteilt["DarfMutieren"]),
                    selectedIDs,
                    qryZugeteilt["UserID"]));

            // discard changes
            qryZugeteilt.RowModified = false;
            qryZugeteilt.Row.AcceptChanges();
        }

        private void qryZugeteilt_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            qryFaLeistung.RowModified = true;
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // set focus
            this.edtSucheKlient.Focus();
        }

        protected override void RunSearch()
        {
            // validate search
            if (DBUtil.IsEmpty(edtSucheKlient.EditValue) &&
                DBUtil.IsEmpty(edtSucheProzess.EditValue) &&
                DBUtil.IsEmpty(edtSucheMA.EditValue) &&
                DBUtil.IsEmpty(edtSucheMAKuerzel.EditValue))
            {
                KissMsg.ShowInfo(CLASSNAME, "Min1Suchfeld", "Mindestens ein Suchfeld muss ausgefüllt sein");

                // set focus
                this.edtSucheKlient.Focus();

                // do not continue
                throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME, "MissingValueCannotContinueWithSearching", "Missing value(s), cannot continue with searching.", KissMsgCode.MsgError));
            }

            // replace values where necessary
            edtSucheKlient.Text = edtSucheKlient.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
            edtSucheMA.Text = edtSucheMA.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
            edtSucheMAKuerzel.Text = edtSucheMAKuerzel.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void DisplayAccessUsers()
        {
            try
            {
                // check if need to do action
                if (this.PreventUpdateDetails)
                {
                    // do nothing
                    return;
                }

                // first save pending changes
                if (!qryZugeteilt.Post())
                {
                    return;
                }

                // get selected ids
                string selectedIDs = "";
                Hashtable htSelectedIDs = this.GetSelectedIDs(out selectedIDs, out _dummyDict);
                int firstFaLeistungID = -1;

                // check if we have at least one id
                if (htSelectedIDs.Count < 1)
                {
                    // fill with empty data
                    qryVerfuegbar.Fill(@"
                            SELECT  UserID = -1,
                                    UserName = 'none',
                                    Abteilung = 'none'
                            WHERE 1 = 2");

                    qryZugeteilt.Fill(@"
                            SELECT  UserID = -1,
                                    FaLeistungID = -1,
                                    DarfMutieren = CONVERT(BIT, 0),
                                    UserName = 'none',
                                    DatumVon = dbo.fnDateOf(GETDATE()),
                                    DatumBis = dbo.fnDateOf(GETDATE())
                            WHERE 1 = 2");

                    // done with filling
                    return;
                }

                // get only first faleistungid in hashtable (is there an easier way??)
                foreach (object faLeistungID in htSelectedIDs.Keys)
                {
                    firstFaLeistungID = Convert.ToInt32(faLeistungID);
                    break;
                }

                // candidates of all selected ids (nur diejenigen benutzer, welche in keinen der gewählten leistungen gastrecht haben)
                qryVerfuegbar.Fill(string.Format(@"
                    SELECT UserID = USR.UserID,
                           UserName = USR.Lastname + ISNULL(', ' + USR.Firstname, '') + ' (' + USR.LogonName + ')',
                           Abteilung = ORG.ItemName
                    FROM XUser USR
                      LEFT JOIN FaLeistungZugriff FAZ ON FAZ.UserID = USR.UserID AND FAZ.FaLeistungID IN ({0})
                                    AND FAZ.DatumBis > dbo.fnDateOf(GETDATE())
                                    AND FAZ.DatumVon < DATEADD(MONTH, CONVERT(INT,dbo.fnXConfig('System\Allgemein\GastrechtAnzahlMonate',GETDATE())), dbo.fnDateOf(GETDATE()))
                      INNER JOIN XOrgUnit_User OUU ON OUU.UserID = USR.UserID AND OUU.OrgUnitMemberCode = 2 -- member only
                      INNER JOIN XOrgUnit ORG ON ORG.OrgUnitID = OUU.OrgUnitID
                    WHERE FAZ.FaLeistungID IS NULL
                    ORDER BY UserName", selectedIDs));

                // selected items of all selected ids (nur diejenigen benutzer, welche in allen gewählten leistungen gastrecht haben)
                qryZugeteilt.Fill(string.Format(@"
                    SELECT FLZ.UserID,
                           FLZ.FaLeistungID,
                           DarfMutieren =  CONVERT(BIT, (SELECT CASE WHEN MAX(CONVERT(INT, ISNULL(SUB.DarfMutieren, 0))) <> MIN(CONVERT(INT, ISNULL(SUB.DarfMutieren, 0))) THEN NULL
                                                                     ELSE MAX(CONVERT(INT, ISNULL(SUB.DarfMutieren, 0)))
                                                                END
                                                         FROM FaLeistungZugriff SUB
                                                         WHERE SUB.UserID = USR.UserID
                                                            AND SUB.FaLeistungID IN ({0})
                                                            AND ISNULL(SUB.DatumBis,'99991231') > dbo.fnDateSerial(YEAR(GETDATE()),MONTH(GETDATE()),DAY(GETDATE())))),
                           UserName = USR.Lastname + ISNULL(', ' + USR.Firstname, '') + ' (' + USR.LogonName + ')',
                           DatumVon = FLZ.DatumVon,
                           DatumBis = FLZ.DatumBis
                    FROM XUser USR
                      INNER JOIN FaLeistungZugriff FLZ ON FLZ.UserID = USR.UserID AND FLZ.FaLeistungID = {1}
                    WHERE USR.UserID IN (SELECT LZ2.UserID
                                         FROM   FaLeistungZugriff LZ2
                                         WHERE  LZ2.FaLeistungID IN ({0}) AND
                                                {2} = (SELECT COUNT(DISTINCT LZ3.FaLeistungID)
                                                       FROM FaLeistungZugriff LZ3
                                                       WHERE LZ3.FaLeistungID IN ({0})
                                                       AND LZ3.UserID = LZ2.UserID
                                                       AND ISNULL(LZ3.DatumBis,'99991231') > dbo.fnDateSerial(YEAR(GETDATE()),MONTH(GETDATE()),DAY(GETDATE())))
                                         GROUP BY LZ2.UserID)
                    AND ISNULL(FLZ.DatumBis,'99991231') > dbo.fnDateSerial(YEAR(GETDATE()),MONTH(GETDATE()),DAY(GETDATE()))
                    ORDER BY UserName", selectedIDs, firstFaLeistungID, htSelectedIDs.Count));

                // set or remove databinding depending on selected rows
                if (htSelectedIDs.Count > 1 || (htSelectedIDs.Count == 1 && !htSelectedIDs.ContainsKey(qryFaLeistung["FaLeistungID"])))
                {
                    // do not display owner name due to confusing data
                    edtOwnerMA.DataMember = "Empty";
                }
                else
                {
                    // display owner name for single selected row
                    edtOwnerMA.DataMember = "MA";
                }

                // refresh binding due to changed datamember
                qryFaLeistung.BindControls();
                qryFaLeistung.RefreshDisplay();
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError(CLASSNAME, "ErrorDisplayAccessUsers", "Fehler beim Laden der zugehörigen Daten.", ex);
            }
        }

        private Hashtable GetSelectedIDs()
        {
            string selectedIDs = "";
            return this.GetSelectedIDs(out selectedIDs, out _dummyDict);
        }

        private Hashtable GetSelectedIDs(out string selectedFaLeistungIDs, out Dictionary<int, string> orderedIDs)
        {
            // init vars
            selectedFaLeistungIDs = "";
            Hashtable htSelectedIDs = new Hashtable();
            orderedIDs = new Dictionary<int, string>();
            int userId;
            string faLeistungId;

            // loop through items and count selected items
            foreach (DataRow row in qryFaLeistung.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Auswahl"]) && Convert.ToBoolean(row["Auswahl"]) && !DBUtil.IsEmpty(row["FaLeistungID"]))
                {
                    faLeistungId = Convert.ToString(row["FaLeistungID"]);
                    // add to string
                    if (!selectedFaLeistungIDs.Equals(""))
                    {
                        selectedFaLeistungIDs += ",";
                    }
                    selectedFaLeistungIDs += faLeistungId;

                    userId = Convert.ToInt32(row["UserID"]);

                    if (orderedIDs.ContainsKey(userId))
                    {
                        orderedIDs[userId] = orderedIDs[userId] + "," + faLeistungId;
                    }
                    else
                    {
                        orderedIDs.Add(userId, faLeistungId);
                    }

                    // add to hashtable (key = faleistungid, value = null)
                    htSelectedIDs.Add(Convert.ToInt32(row["FaLeistungID"]), null);
                }
            }

            // check if we have any item selected in grid
            if (selectedFaLeistungIDs.Equals("") && !DBUtil.IsEmpty(qryFaLeistung["FaLeistungID"]))
            {
                // no id selected, get current focused row id (as it was before multiselection was implemented)
                selectedFaLeistungIDs = Convert.ToString(qryFaLeistung["FaLeistungID"]);

                // add to hashtable (key = faleistungid, value = null)
                htSelectedIDs.Add(Convert.ToInt32(qryFaLeistung["FaLeistungID"]), null);
            }

            // check if there are some FaRelation-entries with CascadeUpdate
            var htWithCascadeUpdate = new Hashtable(htSelectedIDs);
            foreach (var htId in htSelectedIDs.Keys)
            {
                var id = Convert.ToInt32(htId);
                // Bei verknüpften Leistungen die andere auch updaten falls CascadeDelete = true ist
                var cascadeUpdateFaLeistung =
                    Convert.ToBoolean(
                        DBUtil.ExecuteScalarSQL(
                            @"SELECT CascadeUpdate
                              FROM dbo.FaRelation WITH(READUNCOMMITTED)
                              WHERE FaLeistungID1 = {0}
                                 OR FaLeistungID2 = {0}",
                            id));

                if (cascadeUpdateFaLeistung)
                {
                    // andere FaLeistung holen
                    var id2 = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT FaLeistungID = CASE
                                                                                                WHEN FaLeistungID1 = {1} THEN FaLeistungID2
                                                                                                ELSE FaLeistungID1
                                                                                              END
                                                                        FROM dbo.FaRelation WITH (READUNCOMMITTED)
                                                                        WHERE FaLeistungID1 = {1}
                                                                        OR FaLeistungID2 = {1};",
                        Convert.ToInt32(qryVerfuegbar["UserID"]),
                        id));
                    if (!htWithCascadeUpdate.Contains(id2))
                    {
                        selectedFaLeistungIDs += ("," + id2);
                        htWithCascadeUpdate.Add(id2, null);
                    }
                }
            }

            htSelectedIDs = htWithCascadeUpdate;

            // return values
            return htSelectedIDs;
        }

        private void RefreshDisplay(Hashtable htSelectedIDs)
        {
            // discard changes and refresh data
            qryFaLeistung.RowModified = false;
            qryFaLeistung.Row.AcceptChanges();

            qryFaLeistung.Refresh();

            // reselect ids
            this.ReselectIDs(htSelectedIDs);
        }

        private void ReselectIDs(Hashtable htSelectedIDs)
        {
            // validate first (if we just have one row selected, we do NOT reselect item!)
            if (htSelectedIDs == null || htSelectedIDs.Count < 2)
            {
                // do nothing
                return;
            }

            // loop through items and reselect selected items
            foreach (DataRow row in qryFaLeistung.DataTable.Rows)
            {
                if (htSelectedIDs.ContainsKey(row["FaLeistungID"]))
                {
                    row["Auswahl"] = 1;
                }
            }

            // update label
            this.UpdateCounter();
        }

        private void SetupGrid()
        {
            if (GuiConfig.Theme == GuiConfig.KissTheme.KissBlue)
            {
                grdFaLeistung.SetColumnEditable(colAuswahl, true);
                grdFaLeistung.SetColumnEditable(colKlient, false);
                grdFaLeistung.SetColumnEditable(colIcon, false);
                grdFaLeistung.SetColumnEditable(colProzess, false);
                grdFaLeistung.SetColumnEditable(colMA, false);
                grdFaLeistung.SetColumnEditable(colMAKuerzel, false);
                grdFaLeistung.SetColumnEditable(colDatumVon, false);
                grdFaLeistung.SetColumnEditable(colDatumBis, false);
                grdFaLeistung.SetColumnEditable(colFehlermledung, false);
            }
        }

        private void UpdateCounter()
        {
            // check if need to do action
            if (this.PreventUpdateDetails)
            {
                // do nothing
                return;
            }

            // init counter
            int countItems = 0;

            // loop through items and count selected items
            foreach (DataRow row in qryFaLeistung.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Auswahl"]) && Convert.ToBoolean(row["Auswahl"]))
                {
                    countItems++;
                }
            }

            // update label
            this.lblGewaehlteZeilen.Text = KissMsg.GetMLMessage(CLASSNAME, "AmountSelectedItems", "{0} von {1} Leistungen ausgewählt", KissMsgCode.MsgInfo, countItems, qryFaLeistung.Count);
        }

        #endregion

        #endregion
    }
}