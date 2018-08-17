using System;
using System.Data;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;
using KiSS4.Common;

namespace KiSS4.Sostat
{
    public class CtlBfsImport : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        private const string CLASSNAME = "ctlBFSImport";

        private KiSS4.Gui.KissButton btnImport;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colFaLeistungID;
        private DevExpress.XtraGrid.Columns.GridColumn colJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistungsart;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlGotoFall ctlGotoFall;
        private KiSS4.Gui.KissButtonEdit edtBaPersonIDX;
        private KiSS4.Gui.KissCalcEdit edtErhebungsjahrX;
        private KiSS4.Gui.KissCheckedLookupEdit edtLeistungsartX;
        private KiSS4.Gui.KissButtonEdit edtSARX;
        private KissLookUpEdit edtSektionX;
        private KiSS4.Gui.KissGrid grdFaLeistung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFaLeistung;
        private KiSS4.Gui.KissLabel lblBaPersonIDX;
        private KiSS4.Gui.KissLabel lblCounter;
        private KiSS4.Gui.KissLabel lblErhebungsjahrX;
        private KiSS4.Gui.KissLabel lblLeistungsart;
        private KiSS4.Gui.KissLabel lblSARX;
        private KissLabel lblSektion;
        private System.Windows.Forms.Panel panel1;
        private KiSS4.DB.SqlQuery qryFaLeistung;
        private SqlQuery qrySektion;

        #endregion

        #endregion

        #region Constructors

        public CtlBfsImport()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdFaLeistung = new KiSS4.Gui.KissGrid();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery();
            this.grvFaLeistung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaLeistungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistungsart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCounter = new KiSS4.Gui.KissLabel();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.btnImport = new KiSS4.Gui.KissButton();
            this.lblErhebungsjahrX = new KiSS4.Gui.KissLabel();
            this.lblSARX = new KiSS4.Gui.KissLabel();
            this.lblBaPersonIDX = new KiSS4.Gui.KissLabel();
            this.lblLeistungsart = new KiSS4.Gui.KissLabel();
            this.edtErhebungsjahrX = new KiSS4.Gui.KissCalcEdit();
            this.edtSARX = new KiSS4.Gui.KissButtonEdit();
            this.edtBaPersonIDX = new KiSS4.Gui.KissButtonEdit();
            this.edtLeistungsartX = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblSektion = new KiSS4.Gui.KissLabel();
            this.edtSektionX = new KiSS4.Gui.KissLookUpEdit();
            this.qrySektion = new KiSS4.DB.SqlQuery();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaLeistung)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErhebungsjahrX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSARX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonIDX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErhebungsjahrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSARX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIDX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungsartX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektionX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySektion)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(776, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(800, 500);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdFaLeistung);
            this.tpgListe.Controls.Add(this.panel1);
            this.tpgListe.Size = new System.Drawing.Size(788, 462);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblSektion);
            this.tpgSuchen.Controls.Add(this.edtSektionX);
            this.tpgSuchen.Controls.Add(this.edtLeistungsartX);
            this.tpgSuchen.Controls.Add(this.edtBaPersonIDX);
            this.tpgSuchen.Controls.Add(this.edtSARX);
            this.tpgSuchen.Controls.Add(this.edtErhebungsjahrX);
            this.tpgSuchen.Controls.Add(this.lblLeistungsart);
            this.tpgSuchen.Controls.Add(this.lblBaPersonIDX);
            this.tpgSuchen.Controls.Add(this.lblSARX);
            this.tpgSuchen.Controls.Add(this.lblErhebungsjahrX);
            this.tpgSuchen.Size = new System.Drawing.Size(788, 462);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblErhebungsjahrX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSARX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBaPersonIDX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblLeistungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtErhebungsjahrX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSARX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonIDX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtLeistungsartX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSektionX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSektion, 0);
            // 
            // grdFaLeistung
            // 
            this.grdFaLeistung.DataSource = this.qryFaLeistung;
            this.grdFaLeistung.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdFaLeistung.EmbeddedNavigator.Name = "";
            this.grdFaLeistung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFaLeistung.Location = new System.Drawing.Point(0, 0);
            this.grdFaLeistung.MainView = this.grvFaLeistung;
            this.grdFaLeistung.Name = "grdFaLeistung";
            this.grdFaLeistung.Size = new System.Drawing.Size(788, 428);
            this.grdFaLeistung.TabIndex = 0;
            this.grdFaLeistung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFaLeistung});
            // 
            // qryFaLeistung
            // 
            this.qryFaLeistung.FillTimeOut = 3000;
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.SelectStatement = "SELECT NULL\r\n\r\n";
            // 
            // grvFaLeistung
            // 
            this.grvFaLeistung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFaLeistung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.Empty.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.Empty.Options.UseFont = true;
            this.grvFaLeistung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.EvenRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFaLeistung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFaLeistung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFaLeistung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFaLeistung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
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
            this.grvFaLeistung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFaLeistung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaLeistung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFaLeistung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFaLeistung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.OddRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFaLeistung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.Row.Options.UseBackColor = true;
            this.grvFaLeistung.Appearance.Row.Options.UseFont = true;
            this.grvFaLeistung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFaLeistung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFaLeistung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFaLeistung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFaLeistung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colJahr,
            this.colFaLeistungID,
            this.colKlient,
            this.colLeistungsart,
            this.colDatumVon,
            this.colDatumBis});
            this.grvFaLeistung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFaLeistung.GridControl = this.grdFaLeistung;
            this.grvFaLeistung.Name = "grvFaLeistung";
            this.grvFaLeistung.OptionsBehavior.Editable = false;
            this.grvFaLeistung.OptionsCustomization.AllowFilter = false;
            this.grvFaLeistung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFaLeistung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFaLeistung.OptionsNavigation.UseTabKey = false;
            this.grvFaLeistung.OptionsView.ColumnAutoWidth = false;
            this.grvFaLeistung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFaLeistung.OptionsView.ShowGroupPanel = false;
            this.grvFaLeistung.OptionsView.ShowIndicator = false;
            // 
            // colJahr
            // 
            this.colJahr.Caption = "Jahr";
            this.colJahr.FieldName = "Jahr";
            this.colJahr.Name = "colJahr";
            this.colJahr.Visible = true;
            this.colJahr.VisibleIndex = 0;
            this.colJahr.Width = 51;
            // 
            // colFaLeistungID
            // 
            this.colFaLeistungID.Caption = "Leistungs-Nr.";
            this.colFaLeistungID.FieldName = "FaLeistungID";
            this.colFaLeistungID.Name = "colFaLeistungID";
            this.colFaLeistungID.Visible = true;
            this.colFaLeistungID.VisibleIndex = 1;
            this.colFaLeistungID.Width = 105;
            // 
            // colKlient
            // 
            this.colKlient.Caption = "Klient/in";
            this.colKlient.FieldName = "Person";
            this.colKlient.Name = "colKlient";
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 2;
            this.colKlient.Width = 156;
            // 
            // colLeistungsart
            // 
            this.colLeistungsart.Caption = "Leistungsart";
            this.colLeistungsart.FieldName = "Leistungsart";
            this.colLeistungsart.Name = "colLeistungsart";
            this.colLeistungsart.Visible = true;
            this.colLeistungsart.VisibleIndex = 3;
            this.colLeistungsart.Width = 166;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Datum von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 4;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "Datum bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCounter);
            this.panel1.Controls.Add(this.ctlGotoFall);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 428);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 34);
            this.panel1.TabIndex = 1;
            // 
            // lblCounter
            // 
            this.lblCounter.Location = new System.Drawing.Point(234, 6);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(187, 24);
            this.lblCounter.TabIndex = 363;
            this.lblCounter.Text = "Anzahl Einträge: <count>";
            this.lblCounter.UseCompatibleTextRendering = true;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.ActiveSQLQuery = this.qryFaLeistung;
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.DataSource = this.qryFaLeistung;
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 6);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(210, 24);
            this.ctlGotoFall.TabIndex = 362;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(689, 6);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(96, 24);
            this.btnImport.TabIndex = 361;
            this.btnImport.Text = "&Import";
            this.btnImport.UseCompatibleTextRendering = true;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblErhebungsjahrX
            // 
            this.lblErhebungsjahrX.Location = new System.Drawing.Point(5, 60);
            this.lblErhebungsjahrX.Name = "lblErhebungsjahrX";
            this.lblErhebungsjahrX.Size = new System.Drawing.Size(82, 24);
            this.lblErhebungsjahrX.TabIndex = 11;
            this.lblErhebungsjahrX.Text = "Jahr";
            this.lblErhebungsjahrX.UseCompatibleTextRendering = true;
            // 
            // lblSARX
            // 
            this.lblSARX.Location = new System.Drawing.Point(5, 90);
            this.lblSARX.Name = "lblSARX";
            this.lblSARX.Size = new System.Drawing.Size(82, 24);
            this.lblSARX.TabIndex = 12;
            this.lblSARX.Text = "Mitarbeiter/-in";
            this.lblSARX.UseCompatibleTextRendering = true;
            // 
            // lblBaPersonIDX
            // 
            this.lblBaPersonIDX.Location = new System.Drawing.Point(5, 123);
            this.lblBaPersonIDX.Name = "lblBaPersonIDX";
            this.lblBaPersonIDX.Size = new System.Drawing.Size(82, 24);
            this.lblBaPersonIDX.TabIndex = 14;
            this.lblBaPersonIDX.Text = "Klient";
            this.lblBaPersonIDX.UseCompatibleTextRendering = true;
            // 
            // lblLeistungsart
            // 
            this.lblLeistungsart.Location = new System.Drawing.Point(3, 189);
            this.lblLeistungsart.Name = "lblLeistungsart";
            this.lblLeistungsart.Size = new System.Drawing.Size(100, 23);
            this.lblLeistungsart.TabIndex = 15;
            this.lblLeistungsart.Text = "Leistungsart";
            this.lblLeistungsart.UseCompatibleTextRendering = true;
            // 
            // edtErhebungsjahrX
            // 
            this.edtErhebungsjahrX.Location = new System.Drawing.Point(93, 59);
            this.edtErhebungsjahrX.Name = "edtErhebungsjahrX";
            this.edtErhebungsjahrX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErhebungsjahrX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErhebungsjahrX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErhebungsjahrX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErhebungsjahrX.Properties.Appearance.Options.UseBackColor = true;
            this.edtErhebungsjahrX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErhebungsjahrX.Properties.Appearance.Options.UseFont = true;
            this.edtErhebungsjahrX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErhebungsjahrX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErhebungsjahrX.Properties.Mask.EditMask = "####";
            this.edtErhebungsjahrX.Size = new System.Drawing.Size(100, 24);
            this.edtErhebungsjahrX.TabIndex = 16;
            // 
            // edtSARX
            // 
            this.edtSARX.Location = new System.Drawing.Point(93, 89);
            this.edtSARX.Name = "edtSARX";
            this.edtSARX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSARX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSARX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSARX.Properties.Appearance.Options.UseBackColor = true;
            this.edtSARX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSARX.Properties.Appearance.Options.UseFont = true;
            this.edtSARX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSARX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSARX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSARX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSARX.Size = new System.Drawing.Size(237, 24);
            this.edtSARX.TabIndex = 17;
            this.edtSARX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSARX_UserModifiedFld);
            // 
            // edtBaPersonIDX
            // 
            this.edtBaPersonIDX.Location = new System.Drawing.Point(93, 122);
            this.edtBaPersonIDX.Name = "edtBaPersonIDX";
            this.edtBaPersonIDX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonIDX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonIDX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonIDX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonIDX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonIDX.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonIDX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBaPersonIDX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBaPersonIDX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonIDX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBaPersonIDX.Size = new System.Drawing.Size(237, 24);
            this.edtBaPersonIDX.TabIndex = 19;
            this.edtBaPersonIDX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPersonIDX_UserModifiedFld);
            // 
            // edtLeistungsartX
            // 
            this.edtLeistungsartX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.edtLeistungsartX.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtLeistungsartX.Appearance.Options.UseBackColor = true;
            this.edtLeistungsartX.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtLeistungsartX.CheckOnClick = true;
            this.edtLeistungsartX.Location = new System.Drawing.Point(93, 189);
            this.edtLeistungsartX.LookupSQL = "SELECT Code, Text\r\nFROM BFSLOVCode\r\nWHERE LOVName = \'BFSLeistungsart\'";
            this.edtLeistungsartX.Name = "edtLeistungsartX";
            this.edtLeistungsartX.Size = new System.Drawing.Size(259, 246);
            this.edtLeistungsartX.TabIndex = 20;
            // 
            // lblSektion
            // 
            this.lblSektion.Location = new System.Drawing.Point(5, 152);
            this.lblSektion.Name = "lblSektion";
            this.lblSektion.Size = new System.Drawing.Size(69, 24);
            this.lblSektion.TabIndex = 148;
            this.lblSektion.Text = "Sektion/Team";
            this.lblSektion.UseCompatibleTextRendering = true;
            // 
            // edtSektionX
            // 
            this.edtSektionX.Location = new System.Drawing.Point(94, 152);
            this.edtSektionX.Name = "edtSektionX";
            this.edtSektionX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSektionX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSektionX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSektionX.Properties.Appearance.Options.UseBackColor = true;
            this.edtSektionX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSektionX.Properties.Appearance.Options.UseFont = true;
            this.edtSektionX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSektionX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSektionX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSektionX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSektionX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSektionX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSektionX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSektionX.Properties.NullText = "";
            this.edtSektionX.Properties.ShowFooter = false;
            this.edtSektionX.Properties.ShowHeader = false;
            this.edtSektionX.Size = new System.Drawing.Size(236, 24);
            this.edtSektionX.TabIndex = 147;
            // 
            // qrySektion
            // 
            this.qrySektion.HostControl = this;
            this.qrySektion.SelectStatement = "SELECT \r\n   Text = ItemName,   \r\n   Code = OrgUnitID\r\nFROM XOrgUnit\r\nUNION\r\nSELEC" +
    "T\r\n   TEXT = \'\',\r\n   Code = null\r\nORDER BY Text";
            // 
            // CtlBfsImport
            // 
            this.ActiveSQLQuery = this.qryFaLeistung;
            this.Name = "CtlBfsImport";
            this.Load += new System.EventHandler(this.CtlBfsImport_Load);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaLeistung)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErhebungsjahrX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSARX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonIDX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErhebungsjahrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSARX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIDX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungsartX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektionX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySektion)).EndInit();
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

        private void btnImport_Click(object sender, System.EventArgs e)
        {
            // Alle angezeigten Zeilen importieren
            DlgProgressLog.Show
            (
                "Fortschritt: Sostat - Import",
                700, 300,
                new ProgressEventHandler(StartImport),
                new ProgressEventHandler(EndImport),
                Session.MainForm
            );
        }

        private void CtlBfsImport_Load(object sender, System.EventArgs e)
        {
            // Anzeige im Gitter erstellen
            colLeistungsart.ColumnEdit = grdFaLeistung.GetLOVLookUpEdit(DBUtil.OpenSQL(@"
                SELECT  Code, Text = Text
                FROM dbo.BFSLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'BFSLeistungsart'"
            ));

            // Auswahl der Sektionen erstellen
            qrySektion.Fill();
            edtSektionX.LoadQuery(qrySektion);
            edtSektionX.ItemIndex = 0;

            // Register Neue Suche aktivieren
            this.NewSearch();
        }
        private void edtBaPersonIDX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            // Suchen nach Klienten
            string SearchString = edtBaPersonIDX.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    // damit auch etwas zur Auswahl angezeigt wird, wenn das Suchfeld leer ist
                    SearchString = "%";
                }
                else
                {
                    // zurücksetzen der vorhergehenden Auswahl, 
                    // wenn das Suchfeld leer ist und es ohne anzuklicken verlassen wird
                    edtBaPersonIDX.EditValue = null;
                    edtBaPersonIDX.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PersonSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                // wenn die Auswahl gemacht wurde
                edtBaPersonIDX.EditValue = dlg["Name"];
                edtBaPersonIDX.LookupID = dlg["BaPersonID"];
            }
        }

        private void edtSARX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            // Suchen nach Mitarbeitern
            string SearchString = edtSARX.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    // damit auch etwas zur Auswahl angezeigt wird, wenn das Suchfeld leer ist
                    SearchString = "%";
                }
                else
                {
                    // zurücksetzen der vorhergehenden Auswahl, 
                    // wenn das Suchfeld leer ist und es ohne anzuklicken verlassen wird
                    edtSARX.EditValue = null;
                    edtSARX.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                // wenn die Auswahl gemacht wurde
                edtSARX.EditValue = dlg["Name"];
                edtSARX.LookupID = dlg["UserID"];
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            // Suche ausführen
            base.NewSearch();

            // Erhebungsjahr aus Konfiguration holen, Default: aktuelles Jahr
            this.edtErhebungsjahrX.Text = DBUtil.GetConfigValue(@"System\Sostat\Erhebungsjahr", DateTime.Now.Year).ToString();
        }

        protected override void RunSearch()
        {
            // Ein Jahr muss immer gewählt sein
            if (DBUtil.IsEmpty(edtErhebungsjahrX.EditValue))
            {
                KissMsg.ShowInfo(KissMsg.GetMLMessage(
                    CLASSNAME,
                    "BFSKatalogImportJahrFehlt",
                    "Dossiers können nur erzeugt werden, wenn ein Jahr definiert ist.\r\n" +
                    "Geben Sie zuerst ein Jahr ein (z.B. 2010)."
                ));
                throw new KissCancelException();
            }


            // ID Katalogversion holen
            SqlQuery sqlKat = DBUtil.OpenSQL(
                "select KatVersID = dbo.fnBFSGetKatalogVersion({0})",
                edtErhebungsjahrX.EditValue
            );
            int versID = Utils.ConvertToInt(sqlKat["KatVersID"]);

            if (versID < 1)
            {
                // es soll kein Export möglich sein, wenn keine Katalogversion vorhanden ist
                string msg = KissMsg.GetMLMessage(
                    CLASSNAME,
                    "KatalogVersionFehltV01",
                    "Die BFS-Katalogversion für das Jahr {0} fehlt.\r\n" +
                    "Sie können für dieses Jahr keine Importe erstellen.\r\n" +
                    "Wenden Sie sich an Ihren Datenbankadministrator."
                );
                KissMsg.ShowInfo(string.Format(msg, edtErhebungsjahrX.EditValue.ToString()));
                throw new KissCancelException();
            }

            // Suche ausführen
            base.RunSearch();
            qryFaLeistung.Fill
            (
                "exec dbo.spBFSGetImportDossiers {0}, {1}, {2}, {3}, {4}",
                edtErhebungsjahrX.EditValue,
                edtSARX.LookupID,
                edtBaPersonIDX.LookupID,
                edtLeistungsartX.EditValue,
                edtSektionX.EditValue
            );

            // Anzahl Zeilen anzeigen
            lblCounter.Text = String.Format("Anzahl Einträge: {0}", qryFaLeistung.Count);
            btnImport.Enabled = (qryFaLeistung.Count > 0);
        }

        #endregion

        #region Private Methods

        private void EndImport()
        {
            // nothing to do yet
        }

        private void StartImport()
        {
            if (!KissMsg.ShowQuestion(
                CLASSNAME,
                "FrageDatenNeuImportieren",
                "Wollen Sie die Daten neu importieren?\r\n" +
                "Sämtlichen manuell erfassten Daten (im SOSTAT-Modul) der angezeigten Dossiers gehen dabei verloren!")
            )
            {
                DlgProgressLog.AddLine("Import abgebrochen");
                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
            else
            {
                int i = 1;
                bool deleteAllStichtagDossiers = false;

                if (!DBUtil.IsEmpty(edtErhebungsjahrX.EditValue) &&
                    DBUtil.IsEmpty(edtSARX.EditValue) &&
                    DBUtil.IsEmpty(edtBaPersonIDX.EditValue) &&
                    DBUtil.IsEmpty(edtSektionX.EditValue) &&
                    DBUtil.IsEmpty(edtLeistungsartX.EditValue))
                {
                    // Nur das Jahr wurde ausgefüllt, d.h. wir können nachfragen, ob alle Stichtag-Dossiers des gewählten Jahrs gelöscht werden sollen
                    if (KissMsg.ShowQuestion(string.Format("Sollen alle Stichtagsdossiers für das Jahr {0} zusammen gelöscht werden? Falls nein, werden die ausgewählten Dossiers einzeln gelöscht, was sehr lange gehen kann.", edtErhebungsjahrX.EditValue), true))
                    {
                        // Alle Stichtags-Dossiers des gewählten Jahrs zusammen löschen
                        deleteAllStichtagDossiers = true;
                    }
                }

                if (deleteAllStichtagDossiers)
                {
                    // Optimiertes Löschen aller Stichtagsdossiers des gewählten Jahres
                    DlgProgressLog.AddLine(string.Format("Alle Stichtagsdossiers des Jahrs {0} löschen (Timeout bei 2 Stunden)...", edtErhebungsjahrX.EditValue));

                    // 2 Std Min Timeout
                    DBUtil.ExecSQL(7200, "EXEC dbo.spBFSDossier_Delete {0}, null, null, null", edtErhebungsjahrX.EditValue);
                }
                else
                {
                    // Einzelnes Löschen der selektieren Dossiers

                    // Zuerst alle bestehenden Fälle mit den Selektionskriterien löschen
                    foreach (DataRow row in qryFaLeistung.DataTable.Rows)
                    {
                        if (DlgProgressLog.CancellledByUser)
                        {
                            return;
                        }

                        DlgProgressLog.AddLine(string.Format("Fall {0}, löschen: {1}", i++, row["Person"]));

                        DBUtil.ExecSQL(
                            "EXEC dbo.spBFSDossier_Delete {0}, {1}, {2}, {3}",
                            row["Jahr"],
                            row["BaPersonID"],
                            row["Leistungsart"],
                            row["FaLeistungID"]
                        );
                    }
                }

                DlgProgressLog.AddLine("Löschen abgeschlossen");

                // Erst jetzt neue Dossiers anlegen
                i = 1;
                foreach (DataRow row in qryFaLeistung.DataTable.Rows)
                {
                    if (DlgProgressLog.CancellledByUser)
                    {
                        return;
                    }

                    DlgProgressLog.AddLine(string.Format("Fall {0}, erstellen: {1}", i++, row["Person"]));

                    DBUtil.ExecSQL(300,
                        "EXEC dbo.spBFSDossier_Create {0}, {1}, {2}, {3}, {4}, {5}, 1, {6}", // 1: Stichtag
                        row["Jahr"],
                        row["FaLeistungID"],
                        row["BaPersonID"],
                        row["ModulID"],
                        row["DatumVon"],
                        row["DatumBis"],
                        row["LaufNr"]
                    );
                }

                // Import abschliessen
                DlgProgressLog.AddLine("Import abgeschlossen");
                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
        }

        #endregion

        #endregion
    }
}