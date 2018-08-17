using System;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public class CtlKaVermittlungEinsatzplatzSuchen : CtlKaEinsatzplaetzeDetail
    {
        #region Fields

        #region Private Fields

        private int _baPersonId = -1;
        private int _faLeistungId = -1;
        private int _prsPhase = -1;
        private int _vermVorschlagId = -1;
        private KiSS4.Gui.KissButton btnInfoPerson;
        private KiSS4.Gui.KissButton btnZuweisen;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colAnmeldung;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrieb;
        private DevExpress.XtraGrid.Columns.GridColumn colBezeichnung;
        private DevExpress.XtraGrid.Columns.GridColumn colBranche;
        private DevExpress.XtraGrid.Columns.GridColumn colFreiAb;
        private DevExpress.XtraGrid.Columns.GridColumn colFreiesPensum;
        private DevExpress.XtraGrid.Columns.GridColumn colKAProgramm;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissButtonEdit edtBaPerson;
        private KiSS4.Gui.KissTextEdit edtFahrausweisKategorie;
        private KiSS4.Gui.KissCheckedLookupEdit edtKaBranche;
        private KiSS4.Gui.KissButtonEdit edtSucheBetrieb;
        private KiSS4.Gui.KissLookUpEdit edtSucheEinsatzplatzGeschlecht;
        private KiSS4.Gui.KissLookUpEdit edtSucheKaProgramm;
        private KiSS4.Gui.KissLookUpEdit edtSucheLehrberuf;
        private KiSS4.Gui.KissTextEdit edtSucheNrBezeichnung;
        private KiSS4.Gui.KissGrid grdEinsatzplatz;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEinsatzplatz;
        private KiSS4.Gui.KissLabel lblPerson;
        private KiSS4.Gui.KissLabel lblSucheBetrieb;
        private KiSS4.Gui.KissLabel lblSucheBranche;
        private KiSS4.Gui.KissLabel lblSucheGeschlecht;
        private KiSS4.Gui.KissLabel lblSucheKaProgramm;
        private KiSS4.Gui.KissLabel lblSucheLehrberuf;
        private KiSS4.Gui.KissLabel lblSucheNrBezeichnung;
        private KiSS4.Gui.KissLabel lblZuweisungEinsatzplatz;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlZuweisung;

        #endregion

        #endregion

        #region Constructors

        public CtlKaVermittlungEinsatzplatzSuchen()
        {
            InitializeComponent();

            tpgListe.Title = "Liste";
            tpgSuchen.Title = "Suchen";

            IsReadOnly = true;

            tabControlSearch.SelectedTabIndex = 1;
            colKAProgramm.ColumnEdit = grdEinsatzplatz.GetLOVLookUpEdit("KaVermittlungProgramm");
            colBranche.ColumnEdit = grdEinsatzplatz.GetLOVLookUpEdit("KaBranche");

            qryKaEinsatzplatz_PositionChanged(null, null);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaVermittlungEinsatzplatzSuchen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdEinsatzplatz = new KiSS4.Gui.KissGrid();
            this.grvEinsatzplatz = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranche = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreiAb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreiesPensum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnmeldung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrieb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAProgramm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheBranche = new KiSS4.Gui.KissLabel();
            this.edtKaBranche = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblSucheNrBezeichnung = new KiSS4.Gui.KissLabel();
            this.lblSucheBetrieb = new KiSS4.Gui.KissLabel();
            this.lblSucheKaProgramm = new KiSS4.Gui.KissLabel();
            this.lblSucheLehrberuf = new KiSS4.Gui.KissLabel();
            this.lblSucheGeschlecht = new KiSS4.Gui.KissLabel();
            this.edtSucheNrBezeichnung = new KiSS4.Gui.KissTextEdit();
            this.edtSucheEinsatzplatzGeschlecht = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheKaProgramm = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheLehrberuf = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheBetrieb = new KiSS4.Gui.KissButtonEdit();
            this.edtFahrausweisKategorie = new KiSS4.Gui.KissTextEdit();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlZuweisung = new System.Windows.Forms.Panel();
            this.lblZuweisungEinsatzplatz = new KiSS4.Gui.KissLabel();
            this.btnZuweisen = new KiSS4.Gui.KissButton();
            this.btnInfoPerson = new KiSS4.Gui.KissButton();
            this.edtBaPerson = new KiSS4.Gui.KissButtonEdit();
            this.lblPerson = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaVermittlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaKontaktperson)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBranche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaBranche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNrBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetrieb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKaProgramm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLehrberuf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNrBezeichnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinsatzplatzGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinsatzplatzGeschlecht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKaProgramm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKaProgramm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLehrberuf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLehrberuf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetrieb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFahrausweisKategorie.Properties)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlZuweisung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblZuweisungEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPerson)).BeginInit();
            this.SuspendLayout();
            //
            // tabBottom
            //
            this.tabBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabBottom.Location = new System.Drawing.Point(0, 255);
            this.tabBottom.Size = new System.Drawing.Size(809, 306);
            this.tabBottom.TabIndex = 1;
            //
            // qryKaEinsatzplatz
            //
            this.qryKaEinsatzplatz.SelectStatement = resources.GetString("qryKaEinsatzplatz.SelectStatement");
            this.qryKaEinsatzplatz.PositionChanged += new System.EventHandler(this.qryKaEinsatzplatz_PositionChanged);
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(785, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(809, 255);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdEinsatzplatz);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Size = new System.Drawing.Size(797, 217);
            this.tpgListe.Title = "tpgListe";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSucheBetrieb);
            this.tpgSuchen.Controls.Add(this.edtSucheLehrberuf);
            this.tpgSuchen.Controls.Add(this.edtSucheKaProgramm);
            this.tpgSuchen.Controls.Add(this.edtSucheEinsatzplatzGeschlecht);
            this.tpgSuchen.Controls.Add(this.edtSucheNrBezeichnung);
            this.tpgSuchen.Controls.Add(this.lblSucheGeschlecht);
            this.tpgSuchen.Controls.Add(this.lblSucheLehrberuf);
            this.tpgSuchen.Controls.Add(this.lblSucheKaProgramm);
            this.tpgSuchen.Controls.Add(this.lblSucheBetrieb);
            this.tpgSuchen.Controls.Add(this.lblSucheNrBezeichnung);
            this.tpgSuchen.Controls.Add(this.edtKaBranche);
            this.tpgSuchen.Controls.Add(this.lblSucheBranche);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Size = new System.Drawing.Size(797, 217);
            this.tpgSuchen.Title = "tpgSuchen";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBranche, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKaBranche, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheNrBezeichnung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBetrieb, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKaProgramm, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheLehrberuf, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGeschlecht, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheNrBezeichnung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheEinsatzplatzGeschlecht, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKaProgramm, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheLehrberuf, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBetrieb, 0);
            //
            // grdEinsatzplatz
            //
            this.grdEinsatzplatz.DataSource = this.qryKaEinsatzplatz;
            this.grdEinsatzplatz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEinsatzplatz.EmbeddedNavigator.Name = "";
            this.grdEinsatzplatz.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdEinsatzplatz.Location = new System.Drawing.Point(0, 0);
            this.grdEinsatzplatz.MainView = this.grvEinsatzplatz;
            this.grdEinsatzplatz.Name = "grdEinsatzplatz";
            this.grdEinsatzplatz.Size = new System.Drawing.Size(797, 217);
            this.grdEinsatzplatz.TabIndex = 1;
            this.grdEinsatzplatz.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEinsatzplatz});
            //
            // grvEinsatzplatz
            //
            this.grvEinsatzplatz.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvEinsatzplatz.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsatzplatz.Appearance.Empty.Options.UseBackColor = true;
            this.grvEinsatzplatz.Appearance.Empty.Options.UseFont = true;
            this.grvEinsatzplatz.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsatzplatz.Appearance.EvenRow.Options.UseFont = true;
            this.grvEinsatzplatz.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEinsatzplatz.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsatzplatz.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvEinsatzplatz.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvEinsatzplatz.Appearance.FocusedCell.Options.UseFont = true;
            this.grvEinsatzplatz.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvEinsatzplatz.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEinsatzplatz.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsatzplatz.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvEinsatzplatz.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvEinsatzplatz.Appearance.FocusedRow.Options.UseFont = true;
            this.grvEinsatzplatz.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvEinsatzplatz.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEinsatzplatz.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvEinsatzplatz.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEinsatzplatz.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEinsatzplatz.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEinsatzplatz.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvEinsatzplatz.Appearance.GroupRow.Options.UseFont = true;
            this.grvEinsatzplatz.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvEinsatzplatz.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvEinsatzplatz.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvEinsatzplatz.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEinsatzplatz.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvEinsatzplatz.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvEinsatzplatz.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvEinsatzplatz.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvEinsatzplatz.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsatzplatz.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEinsatzplatz.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvEinsatzplatz.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvEinsatzplatz.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvEinsatzplatz.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvEinsatzplatz.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvEinsatzplatz.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsatzplatz.Appearance.OddRow.Options.UseFont = true;
            this.grvEinsatzplatz.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvEinsatzplatz.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsatzplatz.Appearance.Row.Options.UseBackColor = true;
            this.grvEinsatzplatz.Appearance.Row.Options.UseFont = true;
            this.grvEinsatzplatz.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsatzplatz.Appearance.SelectedRow.Options.UseFont = true;
            this.grvEinsatzplatz.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvEinsatzplatz.Appearance.VertLine.Options.UseBackColor = true;
            this.grvEinsatzplatz.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvEinsatzplatz.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAktiv,
            this.colBezeichnung,
            this.colBranche,
            this.colFreiAb,
            this.colFreiesPensum,
            this.colAnmeldung,
            this.colBetrieb,
            this.colKAProgramm});
            this.grvEinsatzplatz.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvEinsatzplatz.GridControl = this.grdEinsatzplatz;
            this.grvEinsatzplatz.Name = "grvEinsatzplatz";
            this.grvEinsatzplatz.OptionsBehavior.Editable = false;
            this.grvEinsatzplatz.OptionsCustomization.AllowFilter = false;
            this.grvEinsatzplatz.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvEinsatzplatz.OptionsNavigation.AutoFocusNewRow = true;
            this.grvEinsatzplatz.OptionsNavigation.UseTabKey = false;
            this.grvEinsatzplatz.OptionsView.ColumnAutoWidth = false;
            this.grvEinsatzplatz.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvEinsatzplatz.OptionsView.ShowGroupPanel = false;
            this.grvEinsatzplatz.OptionsView.ShowIndicator = false;
            //
            // colAktiv
            //
            this.colAktiv.Caption = "Aktiv";
            this.colAktiv.FieldName = "Aktiv";
            this.colAktiv.Name = "colAktiv";
            this.colAktiv.Visible = true;
            this.colAktiv.VisibleIndex = 0;
            this.colAktiv.Width = 41;
            //
            // colBezeichnung
            //
            this.colBezeichnung.Caption = "Bezeichnung";
            this.colBezeichnung.FieldName = "Bezeichnung";
            this.colBezeichnung.Name = "colBezeichnung";
            this.colBezeichnung.Visible = true;
            this.colBezeichnung.VisibleIndex = 1;
            this.colBezeichnung.Width = 169;
            //
            // colBranche
            //
            this.colBranche.Caption = "Branche";
            this.colBranche.FieldName = "BrancheCode";
            this.colBranche.Name = "colBranche";
            this.colBranche.Visible = true;
            this.colBranche.VisibleIndex = 2;
            this.colBranche.Width = 148;
            //
            // colFreiAb
            //
            this.colFreiAb.Caption = "frei ab";
            this.colFreiAb.FieldName = "FreiAb";
            this.colFreiAb.Name = "colFreiAb";
            this.colFreiAb.Visible = true;
            this.colFreiAb.VisibleIndex = 3;
            //
            // colFreiesPensum
            //
            this.colFreiesPensum.Caption = "aktuell freie %";
            this.colFreiesPensum.FieldName = "FreiesPensum";
            this.colFreiesPensum.Name = "colFreiesPensum";
            this.colFreiesPensum.Visible = true;
            this.colFreiesPensum.VisibleIndex = 4;
            this.colFreiesPensum.Width = 95;
            //
            // colAnmeldung
            //
            this.colAnmeldung.Caption = "Anmeldungen";
            this.colAnmeldung.FieldName = "Anmeldungen";
            this.colAnmeldung.Name = "colAnmeldung";
            this.colAnmeldung.Visible = true;
            this.colAnmeldung.VisibleIndex = 5;
            this.colAnmeldung.Width = 92;
            //
            // colBetrieb
            //
            this.colBetrieb.Caption = "Betrieb";
            this.colBetrieb.FieldName = "BetName";
            this.colBetrieb.Name = "colBetrieb";
            this.colBetrieb.Visible = true;
            this.colBetrieb.VisibleIndex = 6;
            this.colBetrieb.Width = 170;
            //
            // colKAProgramm
            //
            this.colKAProgramm.Caption = "KA-Programm";
            this.colKAProgramm.FieldName = "KaProgrammCode";
            this.colKAProgramm.Name = "colKAProgramm";
            this.colKAProgramm.Visible = true;
            this.colKAProgramm.VisibleIndex = 7;
            this.colKAProgramm.Width = 170;
            //
            // lblSucheBranche
            //
            this.lblSucheBranche.Location = new System.Drawing.Point(418, 40);
            this.lblSucheBranche.Name = "lblSucheBranche";
            this.lblSucheBranche.Size = new System.Drawing.Size(56, 24);
            this.lblSucheBranche.TabIndex = 16;
            this.lblSucheBranche.Text = "Branche";
            this.lblSucheBranche.UseCompatibleTextRendering = true;
            //
            // edtKaBranche
            //
            this.edtKaBranche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKaBranche.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtKaBranche.Appearance.Options.UseBackColor = true;
            this.edtKaBranche.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtKaBranche.CheckOnClick = true;
            this.edtKaBranche.Location = new System.Drawing.Point(493, 40);
            this.edtKaBranche.LOVName = "KaBranche";
            this.edtKaBranche.Name = "edtKaBranche";
            this.edtKaBranche.Size = new System.Drawing.Size(272, 144);
            this.edtKaBranche.TabIndex = 30;
            //
            // lblSucheNrBezeichnung
            //
            this.lblSucheNrBezeichnung.Location = new System.Drawing.Point(19, 40);
            this.lblSucheNrBezeichnung.Name = "lblSucheNrBezeichnung";
            this.lblSucheNrBezeichnung.Size = new System.Drawing.Size(94, 24);
            this.lblSucheNrBezeichnung.TabIndex = 18;
            this.lblSucheNrBezeichnung.Text = "Nr./Bezeichnung";
            this.lblSucheNrBezeichnung.UseCompatibleTextRendering = true;
            //
            // lblSucheBetrieb
            //
            this.lblSucheBetrieb.Location = new System.Drawing.Point(19, 70);
            this.lblSucheBetrieb.Name = "lblSucheBetrieb";
            this.lblSucheBetrieb.Size = new System.Drawing.Size(83, 24);
            this.lblSucheBetrieb.TabIndex = 19;
            this.lblSucheBetrieb.Text = "Betrieb";
            this.lblSucheBetrieb.UseCompatibleTextRendering = true;
            //
            // lblSucheKaProgramm
            //
            this.lblSucheKaProgramm.Location = new System.Drawing.Point(19, 100);
            this.lblSucheKaProgramm.Name = "lblSucheKaProgramm";
            this.lblSucheKaProgramm.Size = new System.Drawing.Size(83, 24);
            this.lblSucheKaProgramm.TabIndex = 21;
            this.lblSucheKaProgramm.Text = "KA-Programm";
            this.lblSucheKaProgramm.UseCompatibleTextRendering = true;
            //
            // lblSucheLehrberuf
            //
            this.lblSucheLehrberuf.Location = new System.Drawing.Point(19, 130);
            this.lblSucheLehrberuf.Name = "lblSucheLehrberuf";
            this.lblSucheLehrberuf.Size = new System.Drawing.Size(83, 24);
            this.lblSucheLehrberuf.TabIndex = 23;
            this.lblSucheLehrberuf.Text = "Lehrberuf";
            this.lblSucheLehrberuf.UseCompatibleTextRendering = true;
            //
            // lblSucheGeschlecht
            //
            this.lblSucheGeschlecht.Location = new System.Drawing.Point(19, 160);
            this.lblSucheGeschlecht.Name = "lblSucheGeschlecht";
            this.lblSucheGeschlecht.Size = new System.Drawing.Size(83, 24);
            this.lblSucheGeschlecht.TabIndex = 24;
            this.lblSucheGeschlecht.Text = "Geschlecht";
            this.lblSucheGeschlecht.UseCompatibleTextRendering = true;
            //
            // edtSucheNrBezeichnung
            //
            this.edtSucheNrBezeichnung.Location = new System.Drawing.Point(119, 39);
            this.edtSucheNrBezeichnung.Name = "edtSucheNrBezeichnung";
            this.edtSucheNrBezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheNrBezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheNrBezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheNrBezeichnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheNrBezeichnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheNrBezeichnung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheNrBezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheNrBezeichnung.Size = new System.Drawing.Size(255, 24);
            this.edtSucheNrBezeichnung.TabIndex = 25;
            //
            // edtSucheEinsatzplatzGeschlecht
            //
            this.edtSucheEinsatzplatzGeschlecht.Location = new System.Drawing.Point(119, 160);
            this.edtSucheEinsatzplatzGeschlecht.LOVName = "KaEinsatzplatzGeschlecht";
            this.edtSucheEinsatzplatzGeschlecht.Name = "edtSucheEinsatzplatzGeschlecht";
            this.edtSucheEinsatzplatzGeschlecht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheEinsatzplatzGeschlecht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheEinsatzplatzGeschlecht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheEinsatzplatzGeschlecht.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheEinsatzplatzGeschlecht.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheEinsatzplatzGeschlecht.Properties.Appearance.Options.UseFont = true;
            this.edtSucheEinsatzplatzGeschlecht.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheEinsatzplatzGeschlecht.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheEinsatzplatzGeschlecht.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheEinsatzplatzGeschlecht.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheEinsatzplatzGeschlecht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheEinsatzplatzGeschlecht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheEinsatzplatzGeschlecht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheEinsatzplatzGeschlecht.Properties.NullText = "";
            this.edtSucheEinsatzplatzGeschlecht.Properties.ShowFooter = false;
            this.edtSucheEinsatzplatzGeschlecht.Properties.ShowHeader = false;
            this.edtSucheEinsatzplatzGeschlecht.Size = new System.Drawing.Size(255, 24);
            this.edtSucheEinsatzplatzGeschlecht.TabIndex = 29;
            //
            // edtSucheKaProgramm
            //
            this.edtSucheKaProgramm.AllowNull = false;
            this.edtSucheKaProgramm.Location = new System.Drawing.Point(119, 100);
            this.edtSucheKaProgramm.LOVName = "KaVermittlungProgramm";
            this.edtSucheKaProgramm.Name = "edtSucheKaProgramm";
            this.edtSucheKaProgramm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtSucheKaProgramm.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKaProgramm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKaProgramm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKaProgramm.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKaProgramm.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKaProgramm.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKaProgramm.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheKaProgramm.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKaProgramm.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheKaProgramm.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheKaProgramm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheKaProgramm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheKaProgramm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKaProgramm.Properties.NullText = "";
            this.edtSucheKaProgramm.Properties.ShowFooter = false;
            this.edtSucheKaProgramm.Properties.ShowHeader = false;
            this.edtSucheKaProgramm.Size = new System.Drawing.Size(255, 24);
            this.edtSucheKaProgramm.TabIndex = 27;
            //
            // edtSucheLehrberuf
            //
            this.edtSucheLehrberuf.Location = new System.Drawing.Point(119, 130);
            this.edtSucheLehrberuf.LOVName = "KaLehrberuf";
            this.edtSucheLehrberuf.Name = "edtSucheLehrberuf";
            this.edtSucheLehrberuf.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheLehrberuf.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheLehrberuf.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheLehrberuf.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheLehrberuf.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheLehrberuf.Properties.Appearance.Options.UseFont = true;
            this.edtSucheLehrberuf.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheLehrberuf.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheLehrberuf.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheLehrberuf.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheLehrberuf.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheLehrberuf.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheLehrberuf.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheLehrberuf.Properties.NullText = "";
            this.edtSucheLehrberuf.Properties.ShowFooter = false;
            this.edtSucheLehrberuf.Properties.ShowHeader = false;
            this.edtSucheLehrberuf.Size = new System.Drawing.Size(255, 24);
            this.edtSucheLehrberuf.TabIndex = 28;
            //
            // edtSucheBetrieb
            //
            this.edtSucheBetrieb.Location = new System.Drawing.Point(119, 70);
            this.edtSucheBetrieb.Name = "edtSucheBetrieb";
            this.edtSucheBetrieb.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBetrieb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBetrieb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBetrieb.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBetrieb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBetrieb.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBetrieb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheBetrieb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheBetrieb.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBetrieb.Size = new System.Drawing.Size(255, 24);
            this.edtSucheBetrieb.TabIndex = 26;
            this.edtSucheBetrieb.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheBetrieb_UserModifiedFld);
            //
            // edtFahrausweisKategorie
            //
            this.edtFahrausweisKategorie.DataMember = "FuehrerausweisKategorie";
            this.edtFahrausweisKategorie.DataSource = this.qryKaEinsatzplatz;
            this.edtFahrausweisKategorie.Location = new System.Drawing.Point(135, 36);
            this.edtFahrausweisKategorie.Name = "edtFahrausweisKategorie";
            this.edtFahrausweisKategorie.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFahrausweisKategorie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFahrausweisKategorie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFahrausweisKategorie.Properties.Appearance.Options.UseBackColor = true;
            this.edtFahrausweisKategorie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFahrausweisKategorie.Properties.Appearance.Options.UseFont = true;
            this.edtFahrausweisKategorie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFahrausweisKategorie.Size = new System.Drawing.Size(201, 24);
            this.edtFahrausweisKategorie.TabIndex = 2;
            //
            // pnlBottom
            //
            this.pnlBottom.Controls.Add(this.pnlZuweisung);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 561);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(809, 44);
            this.pnlBottom.TabIndex = 2;
            //
            // pnlZuweisung
            //
            this.pnlZuweisung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlZuweisung.Controls.Add(this.lblZuweisungEinsatzplatz);
            this.pnlZuweisung.Controls.Add(this.btnZuweisen);
            this.pnlZuweisung.Controls.Add(this.btnInfoPerson);
            this.pnlZuweisung.Controls.Add(this.edtBaPerson);
            this.pnlZuweisung.Controls.Add(this.lblPerson);
            this.pnlZuweisung.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlZuweisung.Location = new System.Drawing.Point(0, 0);
            this.pnlZuweisung.Name = "pnlZuweisung";
            this.pnlZuweisung.Size = new System.Drawing.Size(809, 42);
            this.pnlZuweisung.TabIndex = 15;
            //
            // lblZuweisungEinsatzplatz
            //
            this.lblZuweisungEinsatzplatz.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblZuweisungEinsatzplatz.Location = new System.Drawing.Point(8, 10);
            this.lblZuweisungEinsatzplatz.Name = "lblZuweisungEinsatzplatz";
            this.lblZuweisungEinsatzplatz.Size = new System.Drawing.Size(80, 16);
            this.lblZuweisungEinsatzplatz.TabIndex = 10;
            this.lblZuweisungEinsatzplatz.Text = "Zuweisung";
            this.lblZuweisungEinsatzplatz.UseCompatibleTextRendering = true;
            //
            // btnZuweisen
            //
            this.btnZuweisen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZuweisen.Location = new System.Drawing.Point(612, 7);
            this.btnZuweisen.Name = "btnZuweisen";
            this.btnZuweisen.Size = new System.Drawing.Size(76, 24);
            this.btnZuweisen.TabIndex = 8;
            this.btnZuweisen.Text = "Zuweisen";
            this.btnZuweisen.UseCompatibleTextRendering = true;
            this.btnZuweisen.UseVisualStyleBackColor = false;
            this.btnZuweisen.Click += new System.EventHandler(this.btnZuweisen_Click);
            //
            // btnInfoPerson
            //
            this.btnInfoPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoPerson.Location = new System.Drawing.Point(498, 7);
            this.btnInfoPerson.Name = "btnInfoPerson";
            this.btnInfoPerson.Size = new System.Drawing.Size(108, 24);
            this.btnInfoPerson.TabIndex = 7;
            this.btnInfoPerson.Text = "Info zur Person";
            this.btnInfoPerson.UseCompatibleTextRendering = true;
            this.btnInfoPerson.UseVisualStyleBackColor = false;
            this.btnInfoPerson.Click += new System.EventHandler(this.btnInfoPerson_Click);
            //
            // edtBaPerson
            //
            this.edtBaPerson.Location = new System.Drawing.Point(169, 7);
            this.edtBaPerson.Name = "edtBaPerson";
            this.edtBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBaPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBaPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPerson.Size = new System.Drawing.Size(322, 24);
            this.edtBaPerson.TabIndex = 6;
            this.edtBaPerson.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPerson_UserModifiedFld);
            //
            // lblPerson
            //
            this.lblPerson.Location = new System.Drawing.Point(111, 7);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(45, 24);
            this.lblPerson.TabIndex = 1;
            this.lblPerson.Text = "Person";
            this.lblPerson.UseCompatibleTextRendering = true;
            //
            // CtlKaVermittlungEinsatzplatzSuchen
            //
            this.Controls.Add(this.pnlBottom);
            this.Name = "CtlKaVermittlungEinsatzplatzSuchen";
            this.Size = new System.Drawing.Size(809, 605);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.tabBottom, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Load += new EventHandler(CtlKaVermittlungEinsatzplatzSuchen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryKaVermittlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaKontaktperson)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBranche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaBranche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNrBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBetrieb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKaProgramm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLehrberuf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNrBezeichnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinsatzplatzGeschlecht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinsatzplatzGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKaProgramm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKaProgramm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLehrberuf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLehrberuf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBetrieb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFahrausweisKategorie.Properties)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlZuweisung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblZuweisungEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPerson)).EndInit();
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

        private void btnInfoPerson_Click(object sender, EventArgs e)
        {
            CtlKaVerlauf.JumpToPath(edtBaPerson.LookupID as int?);
        }

        private void btnZuweisen_Click(object sender, EventArgs e)
        {
            _vermVorschlagId = -1;

            if (DBUtil.IsEmpty(qryKaEinsatzplatz["KaEinsatzplatzID"]))
            {
                KissMsg.ShowInfo("CtlKaVermittlungEinsatzplatzSuchen", "EinsatzplatzIDLeer", "Es ist kein Einsatzplatz selektiert!");
                return;
            }

            if (_baPersonId == -1)
            {
                KissMsg.ShowInfo("CtlKaVermittlungEinsatzplatzSuchen", "PersonIDLeer", "Es ist keine Person selektiert!");
                return;
            }

            if (Convert.ToInt32(qryKaEinsatzplatz["selPhase"]) != _prsPhase)
            {
                KissMsg.ShowInfo("CtlKaVermittlungEinsatzplatzSuchen", "PhasenNichtIdentisch", "Selektierte Phase stimmt nicht mit\r\nPhase der ausgewählten Person überein!");
                return;
            }

            try
            {
                _vermVorschlagId = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"INSERT INTO KaVermittlungVorschlag
                        (KaEinsatzplatzID, FaLeistungID, SichtbarSDFlag, VorschlagErfasst)
                        VALUES ({0}, {1}, {2}, GetDate())
                        SELECT SCOPE_IDENTITY()",
                                    qryKaEinsatzplatz["KaEinsatzplatzID"], _faLeistungId, KaUtil.IsVisibleSD(_baPersonId)));

                DBUtil.ExecSQL(@"INSERT INTO KaVermittlungEinsatz (KaVermittlungVorschlagID) VALUES ({0})", _vermVorschlagId);

                switch (Utils.ConvertToInt(qryKaEinsatzplatz["KaProgrammCode"]))
                {
                    case 1:
                        // Inizio
                        FormController.OpenForm("FrmFall", "Action", "JumpToVermittlung", "BaPersonID", _baPersonId, "ModulID", 7, "FieldName", "ClassName", "FieldValue", "CtlKaInizioEinsaetze", "KaVermittlungVorschlagID", _vermVorschlagId);
                        break;

                    case 2:
                        // Qualifizierung Jugend
                        FormController.OpenForm("FrmFall", "Action", "JumpToVermittlung", "BaPersonID", _baPersonId, "ModulID", 7, "FieldName", "ClassName", "FieldValue", "CtlKaQJExterneEinsaetze", "KaVermittlungVorschlagID", _vermVorschlagId);
                        break;

                    case 3:
                        // Vermittlung BI
                        FormController.OpenForm("FrmFall", "Action", "JumpToVermittlung", "BaPersonID", _baPersonId, "ModulID", 7, "FieldName", "ClassName", "FieldValue", "CtlKaVermittlungBIBIPStellenBI", "KaVermittlungVorschlagID", _vermVorschlagId);
                        break;

                    case 4:
                        // Vermittlung BIP
                        FormController.OpenForm("FrmFall", "Action", "JumpToVermittlung", "BaPersonID", _baPersonId, "ModulID", 7, "FieldName", "ClassName", "FieldValue", "CtlKaVermittlungBIBIPEinsaetzeBIP", "KaVermittlungVorschlagID", _vermVorschlagId);
                        break;

                    case 5:
                        // Vermittlung SI
                        FormController.OpenForm("FrmFall", "Action", "JumpToVermittlung", "BaPersonID", _baPersonId, "ModulID", 7, "FieldName", "ClassName", "FieldValue", "CtlKaVermittlungSIEinsaetze", "KaVermittlungVorschlagID", _vermVorschlagId);
                        break;

                    case 8:
                        // Jobtimal
                        FormController.OpenForm("FrmFall", "Action", "JumpToVermittlung", "BaPersonID", _baPersonId, "ModulID", 7, "FieldName", "ClassName", "FieldValue", "CtlKaVermittlungJobtimalEinsaetze", "KaVermittlungVorschlagID", _vermVorschlagId);
                        break;
                }
            }
            catch { }
        }

        private void CtlKaVermittlungEinsatzplatzSuchen_Load(object sender, EventArgs e)
        {
            edtSucheKaProgramm.SelectFirstItem();
        }

        private void edtBaPerson_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            btnZuweisen.Enabled = false;
            btnInfoPerson.Enabled = false;
            _baPersonId = -1;
            _faLeistungId = -1;
            _prsPhase = -1;

            string searchString = edtBaPerson.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtBaPerson.EditValue = null;
                    edtBaPerson.LookupID = null;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(
                string.Format(@"
                    SELECT BaPersonID$ = PRS.BaPersonID,
                           FaLeistungID$ = LEI.FaLeistungID,
                           KlientIn = NameVorname,
                           Phase$ = LOV.Value3
                    FROM dbo.FaLeistung      LEI WITH(READUNCOMMITTED)
                      LEFT JOIN dbo.vwPerson PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
                      LEFT JOIN dbo.XLOVCode LOV WITH(READUNCOMMITTED) ON LOV.LOVName = 'KaVermittlungProgramm'
                  		                                              AND LOV.Code = {0}
                    WHERE NameVorname like {{0}} + '%'
                      AND LEI.FaProzessCode = LOV.Value3
                      AND DatumBis IS NULL
                    ORDER BY NameVorname;",
                    qryKaEinsatzplatz["KaProgrammCode"]),
                searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtBaPerson.EditValue = dlg[2];
                edtBaPerson.LookupID = dlg[0];

                _baPersonId = Convert.ToInt32(dlg[0]);
                _faLeistungId = Convert.ToInt32(dlg[1]);
                _prsPhase = Convert.ToInt32(dlg[3]);
                btnZuweisen.Enabled = DBUtil.UserHasRight("CtlKaVermittlungEinsatzplatzSuchen", "UI");
                btnInfoPerson.Enabled = true;
            }
        }

        private void edtSucheBetrieb_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtSucheBetrieb.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtSucheBetrieb.EditValue = null;
                    edtSucheBetrieb.LookupID = null;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$                 = BET.KaBetriebID,
                     Betrieb             = BET.BetriebName,
                     Adresse             = IsNull(ADR.PLZ, '') + IsNull(' ' + ADR.Ort, '') + IsNull(', ' + ADR.Strasse, '') + IsNull(' ' + ADR.HausNr, '')
              FROM   KaBetrieb BET
                     inner join BaAdresse ADR on ADR.KaBetriebID = BET.KaBetriebID
                                               and GetDate() between isNull(ADR.DatumVon, GetDate()) and isNull(ADR.DatumBis, GetDate())
              WHERE  BET.BetriebName LIKE '%' + {0} + '%'
              ORDER BY BET.BetriebName",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtSucheBetrieb.EditValue = dlg[1];
                edtSucheBetrieb.LookupID = dlg[0];
            }
        }

        private void qryKaEinsatzplatz_PositionChanged(object sender, EventArgs e)
        {
            if (qryKaEinsatzplatz.Count > 0)
            {
                edtBaPerson.EditMode = EditModeType.Normal;
            }
            else
            {
                edtBaPerson.EditMode = EditModeType.ReadOnly;
                btnZuweisen.Enabled = false;
                btnInfoPerson.Enabled = false;
                edtBaPerson.EditValue = null;
                edtBaPerson.LookupID = null;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "OpenSearch":
                    if (!param.Contains("BrancheCodes")) param["BrancheCodes"] = "-1";
                    if (!param.Contains("LehrberufCode")) param["LehrberufCode"] = -1;

                    ActiveSQLQuery = qryKaEinsatzplatz;
                    tabControlSearch.SelectedTabIndex = 1;
                    tabBottom.SelectedTabIndex = 0;

                    if (!param["BrancheCodes"].ToString().Equals("-1"))
                    {
                        edtKaBranche.EditValue = param["BrancheCodes"].ToString();
                    }

                    if (Convert.ToInt32(param["LehrberufCode"]) > 0)
                    {
                        edtSucheLehrberuf.EditValue = param["LehrberufCode"];
                    }

                    return true;
            }

            // did not understand message
            return false;
        }

        #endregion

        #endregion
    }
}