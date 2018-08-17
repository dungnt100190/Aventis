using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.FAMOZ.PSCDServices;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung.ZH
{
    public class CtlIkSollstellung : KiSS4.Gui.KissUserControl
    {
        #region Fields
        private int FilterUserID = 0;
        private bool HasRights = false;
        private KiSS4.Gui.KissButton btnBarbeleg;
        private KiSS4.Gui.KissButton btnDeselect;
        private KiSS4.Gui.KissButton btnError;
        private KiSS4.Gui.KissButton btnMonatszahlen;
        private KiSS4.Gui.KissButton btnSelect;
        private KiSS4.Gui.KissButton btnStart2;
        private KiSS4.Gui.KissButton btnStorno;
        private KiSS4.Gui.KissButton btnUndo2;
        private DevExpress.XtraGrid.Columns.GridColumn colBeguenstigtName;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchgBelegDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchgBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchgBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchgDetailKonto;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchgDetailText;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchgKontoNR;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchgStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchgTV;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchgText;
        private DevExpress.XtraGrid.Columns.GridColumn colBuvhgHV;
        private DevExpress.XtraGrid.Columns.GridColumn colErledigt;
        private DevExpress.XtraGrid.Columns.GridColumn colFehler;
        private DevExpress.XtraGrid.Columns.GridColumn colForderung;
        private DevExpress.XtraGrid.Columns.GridColumn colGebDat;
        private DevExpress.XtraGrid.Columns.GridColumn colGlaeubiger;
        private DevExpress.XtraGrid.Columns.GridColumn colIntVerrechnung_ALBV;
        private DevExpress.XtraGrid.Columns.GridColumn colIntVerrechnung_ALV;
        private DevExpress.XtraGrid.Columns.GridColumn colIntVerrechnung_KiZu;
        private DevExpress.XtraGrid.Columns.GridColumn colIntern;
        private DevExpress.XtraGrid.Columns.GridColumn colIstBarzahlung;
        private DevExpress.XtraGrid.Columns.GridColumn colIstGesendet;
        private DevExpress.XtraGrid.Columns.GridColumn colIstSelektiert;
        private DevExpress.XtraGrid.Columns.GridColumn colMA;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldner;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungAn;
        private DevExpress.XtraGrid.Columns.GridColumn colZusatzBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colZusatzzahlungAn;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlGotoFall ctlGotoFall1;
        private KiSS4.Gui.KissTextEdit edtFallNr;
        private KiSS4.Gui.KissMemoEdit edtFehler;
        private KiSS4.Gui.KissRadioGroup edtFilterMonat;
        private KiSS4.Gui.KissRadioGroup edtFilterStatus;
        private KiSS4.Gui.KissRadioGroup edtFilterTyp;
        private KiSS4.Gui.KissButtonEdit edtFilterUser;
        private KiSS4.Gui.KissDateEdit edtSollstellungsMonat;
        private KiSS4.Gui.KissRadioGroup edtUser;
        private KiSS4.Gui.KissLookUpEdit edtValuta;
        private KiSS4.Gui.KissGrid grdBuchung;
        private KiSS4.Gui.KissGrid grdListe;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwBuchung;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwListe;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel lblLetzteSollStellung;
        private KiSS4.Gui.KissLabel lblProgress;
        private KiSS4.Gui.KissLabel lblProgress2;
        private KiSS4.Gui.KissLabel lblSelInkassoTyp;
        private KiSS4.Gui.KissLabel lblSollstellungsMonat;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblValuta;
        private ModulID modul;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitle;
        private KiSS4.DB.SqlQuery qryKbBuchung;
        private KiSS4.DB.SqlQuery qryListe;
        private KiSS4.DB.SqlQuery qryValuta;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repedtImages;
        private KiSS4.Gui.KissTabControlEx tabSollstellung;
        private SharpLibrary.WinControls.TabPageEx tbpListen;
        private KissButton btnMonatszahlen_AuchAbgeschlossene;
        private DevExpress.XtraGrid.Columns.GridColumn colIkRechtstitelID;
        private DevExpress.XtraGrid.Columns.GridColumn colEinmalig;
        private SharpLibrary.WinControls.TabPageEx tbpSollstellung;

        #endregion

        #region Constructors

        public CtlIkSollstellung(ModulID Modul)
            : this()
        {
            this.modul = Modul;
        }

        public CtlIkSollstellung()
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkSollstellung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.tabSollstellung = new KiSS4.Gui.KissTabControlEx();
            this.tbpListen = new SharpLibrary.WinControls.TabPageEx();
            this.btnStorno = new KiSS4.Gui.KissButton();
            this.edtFehler = new KiSS4.Gui.KissMemoEdit();
            this.qryKbBuchung = new KiSS4.DB.SqlQuery(this.components);
            this.btnBarbeleg = new KiSS4.Gui.KissButton();
            this.edtValuta = new KiSS4.Gui.KissLookUpEdit();
            this.qryValuta = new KiSS4.DB.SqlQuery(this.components);
            this.ctlGotoFall1 = new KiSS4.Common.CtlGotoFall();
            this.qryListe = new KiSS4.DB.SqlQuery(this.components);
            this.grdBuchung = new KiSS4.Gui.KissGrid();
            this.gvwBuchung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBuchgBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchgBelegDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchgDetailText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchgBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchgKontoNR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchgDetailKonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuvhgHV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchgTV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeguenstigtName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchgStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repedtImages = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colBuchgText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFehler = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntern = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.lblValuta = new KiSS4.Gui.KissLabel();
            this.btnDeselect = new KiSS4.Gui.KissButton();
            this.btnSelect = new KiSS4.Gui.KissButton();
            this.btnError = new KiSS4.Gui.KissButton();
            this.btnUndo2 = new KiSS4.Gui.KissButton();
            this.btnStart2 = new KiSS4.Gui.KissButton();
            this.grdListe = new KiSS4.Gui.KissGrid();
            this.gvwListe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIstSelektiert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlaeubiger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGebDat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForderung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntVerrechnung_ALBV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntVerrechnung_ALV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntVerrechnung_KiZu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungAn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZusatzBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZusatzzahlungAn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErledigt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIstGesendet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIstBarzahlung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkRechtstitelID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinmalig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbpSollstellung = new SharpLibrary.WinControls.TabPageEx();
            this.btnMonatszahlen_AuchAbgeschlossene = new KiSS4.Gui.KissButton();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.edtFallNr = new KiSS4.Gui.KissTextEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.edtFilterUser = new KiSS4.Gui.KissButtonEdit();
            this.edtUser = new KiSS4.Gui.KissRadioGroup(this.components);
            this.lblSollstellungsMonat = new KiSS4.Gui.KissLabel();
            this.edtSollstellungsMonat = new KiSS4.Gui.KissDateEdit();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.edtFilterStatus = new KiSS4.Gui.KissRadioGroup(this.components);
            this.edtFilterMonat = new KiSS4.Gui.KissRadioGroup(this.components);
            this.lblProgress2 = new KiSS4.Gui.KissLabel();
            this.lblSelInkassoTyp = new KiSS4.Gui.KissLabel();
            this.lblProgress = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.lblLetzteSollStellung = new KiSS4.Gui.KissLabel();
            this.btnMonatszahlen = new KiSS4.Gui.KissButton();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.edtFilterTyp = new KiSS4.Gui.KissRadioGroup(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.tabSollstellung.SuspendLayout();
            this.tbpListen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtFehler.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValuta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryValuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repedtImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwListe)).BeginInit();
            this.tbpSollstellung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollstellungsMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollstellungsMonat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterMonat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgress2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelInkassoTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzteSollStellung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterTyp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitle);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 24);
            this.panel1.TabIndex = 30;
            // 
            // picTitle
            // 
            this.picTitle.Location = new System.Drawing.Point(5, 5);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(16, 16);
            this.picTitle.TabIndex = 293;
            this.picTitle.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Sollstellung ALBV, ÜbH, KKBB, Zahllauf ALV";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // tabSollstellung
            // 
            this.tabSollstellung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSollstellung.Controls.Add(this.tbpListen);
            this.tabSollstellung.Controls.Add(this.tbpSollstellung);
            this.tabSollstellung.Location = new System.Drawing.Point(0, 45);
            this.tabSollstellung.Name = "tabSollstellung";
            this.tabSollstellung.ShowFixedWidthTooltip = true;
            this.tabSollstellung.Size = new System.Drawing.Size(873, 448);
            this.tabSollstellung.TabIndex = 33;
            this.tabSollstellung.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tbpSollstellung,
            this.tbpListen});
            this.tabSollstellung.TabsLineColor = System.Drawing.Color.Black;
            this.tabSollstellung.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabSollstellung.Text = "kissTabControlEx1";
            this.tabSollstellung.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabSollstellung_SelectedTabChanging);
            this.tabSollstellung.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            this.tabSollstellung.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabSollstellung_SelectedTabChanged);
            // 
            // tbpListen
            // 
            this.tbpListen.Controls.Add(this.btnStorno);
            this.tbpListen.Controls.Add(this.edtFehler);
            this.tbpListen.Controls.Add(this.btnBarbeleg);
            this.tbpListen.Controls.Add(this.edtValuta);
            this.tbpListen.Controls.Add(this.ctlGotoFall1);
            this.tbpListen.Controls.Add(this.grdBuchung);
            this.tbpListen.Controls.Add(this.kissLabel8);
            this.tbpListen.Controls.Add(this.lblValuta);
            this.tbpListen.Controls.Add(this.btnDeselect);
            this.tbpListen.Controls.Add(this.btnSelect);
            this.tbpListen.Controls.Add(this.btnError);
            this.tbpListen.Controls.Add(this.btnUndo2);
            this.tbpListen.Controls.Add(this.btnStart2);
            this.tbpListen.Controls.Add(this.grdListe);
            this.tbpListen.Location = new System.Drawing.Point(6, 6);
            this.tbpListen.Name = "tbpListen";
            this.tbpListen.Size = new System.Drawing.Size(861, 410);
            this.tbpListen.TabIndex = 2;
            this.tbpListen.Title = "Listen";
            // 
            // btnStorno
            // 
            this.btnStorno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStorno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStorno.Location = new System.Drawing.Point(317, 348);
            this.btnStorno.Name = "btnStorno";
            this.btnStorno.Size = new System.Drawing.Size(106, 24);
            this.btnStorno.TabIndex = 111;
            this.btnStorno.Text = "alle stornieren";
            this.btnStorno.UseCompatibleTextRendering = true;
            this.btnStorno.UseVisualStyleBackColor = false;
            this.btnStorno.Click += new System.EventHandler(this.btnStorno_Click);
            this.btnStorno.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // edtFehler
            // 
            this.edtFehler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFehler.DataMember = "PscdFehlermeldung";
            this.edtFehler.DataSource = this.qryKbBuchung;
            this.edtFehler.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFehler.Location = new System.Drawing.Point(556, 348);
            this.edtFehler.Name = "edtFehler";
            this.edtFehler.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFehler.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFehler.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFehler.Properties.Appearance.Options.UseBackColor = true;
            this.edtFehler.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFehler.Properties.Appearance.Options.UseFont = true;
            this.edtFehler.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFehler.Properties.ReadOnly = true;
            this.edtFehler.Size = new System.Drawing.Size(302, 57);
            this.edtFehler.TabIndex = 110;
            this.edtFehler.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // qryKbBuchung
            // 
            this.qryKbBuchung.HostControl = this;
            this.qryKbBuchung.SelectStatement = resources.GetString("qryKbBuchung.SelectStatement");
            this.qryKbBuchung.PositionChanged += new System.EventHandler(this.qryKbBuchung_PositionChanged);
            this.qryKbBuchung.AfterFill += new System.EventHandler(this.qryKbBuchung_AfterFill);
            // 
            // btnBarbeleg
            // 
            this.btnBarbeleg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBarbeleg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBarbeleg.Location = new System.Drawing.Point(317, 381);
            this.btnBarbeleg.Name = "btnBarbeleg";
            this.btnBarbeleg.Size = new System.Drawing.Size(106, 24);
            this.btnBarbeleg.TabIndex = 109;
            this.btnBarbeleg.Text = "Barbeleg";
            this.btnBarbeleg.UseCompatibleTextRendering = true;
            this.btnBarbeleg.UseVisualStyleBackColor = false;
            this.btnBarbeleg.Click += new System.EventHandler(this.btnBarbeleg_Click);
            this.btnBarbeleg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // edtValuta
            // 
            this.edtValuta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtValuta.Location = new System.Drawing.Point(194, 348);
            this.edtValuta.Name = "edtValuta";
            this.edtValuta.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValuta.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValuta.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValuta.Properties.Appearance.Options.UseBackColor = true;
            this.edtValuta.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValuta.Properties.Appearance.Options.UseFont = true;
            this.edtValuta.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtValuta.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtValuta.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtValuta.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtValuta.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtValuta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtValuta.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValuta.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Datum", "Datum", 20, DevExpress.Utils.FormatType.DateTime, "dd.MM.yyyy", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtValuta.Properties.DataSource = this.qryValuta;
            this.edtValuta.Properties.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.edtValuta.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtValuta.Properties.DisplayMember = "Datum";
            this.edtValuta.Properties.EditFormat.FormatString = "dd.MM.yyyy";
            this.edtValuta.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtValuta.Properties.NullText = "";
            this.edtValuta.Properties.ShowFooter = false;
            this.edtValuta.Properties.ShowHeader = false;
            this.edtValuta.Properties.ValueMember = "Datum";
            this.edtValuta.Size = new System.Drawing.Size(117, 24);
            this.edtValuta.TabIndex = 108;
            this.edtValuta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // qryValuta
            // 
            this.qryValuta.HostControl = this;
            this.qryValuta.SelectStatement = resources.GetString("qryValuta.SelectStatement");
            // 
            // ctlGotoFall1
            // 
            this.ctlGotoFall1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFall1.BaPersonID = ((object)(resources.GetObject("ctlGotoFall1.BaPersonID")));
            this.ctlGotoFall1.DataMember = "FallPersonID";
            this.ctlGotoFall1.DataSource = this.qryListe;
            this.ctlGotoFall1.Location = new System.Drawing.Point(77, 381);
            this.ctlGotoFall1.Name = "ctlGotoFall1";
            this.ctlGotoFall1.Size = new System.Drawing.Size(113, 24);
            this.ctlGotoFall1.TabIndex = 107;
            // 
            // qryListe
            // 
            this.qryListe.BatchUpdate = true;
            this.qryListe.CanUpdate = true;
            this.qryListe.FillTimeOut = 300;
            this.qryListe.HostControl = this;
            this.qryListe.SelectStatement = resources.GetString("qryListe.SelectStatement");
            this.qryListe.PositionChanged += new System.EventHandler(this.qryListe_PositionChanged);
            this.qryListe.AfterFill += new System.EventHandler(this.qryListe_AfterFill);
            // 
            // grdBuchung
            // 
            this.grdBuchung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBuchung.DataSource = this.qryKbBuchung;
            this.grdBuchung.EmbeddedNavigator.Name = "";
            this.grdBuchung.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdBuchung.Location = new System.Drawing.Point(0, 174);
            this.grdBuchung.MainView = this.gvwBuchung;
            this.grdBuchung.Name = "grdBuchung";
            this.grdBuchung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repedtImages});
            this.grdBuchung.Size = new System.Drawing.Size(861, 151);
            this.grdBuchung.TabIndex = 106;
            this.grdBuchung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwBuchung});
            this.grdBuchung.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // gvwBuchung
            // 
            this.gvwBuchung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvwBuchung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwBuchung.Appearance.Empty.Options.UseBackColor = true;
            this.gvwBuchung.Appearance.Empty.Options.UseFont = true;
            this.gvwBuchung.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gvwBuchung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwBuchung.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gvwBuchung.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvwBuchung.Appearance.EvenRow.Options.UseFont = true;
            this.gvwBuchung.Appearance.EvenRow.Options.UseForeColor = true;
            this.gvwBuchung.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.gvwBuchung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwBuchung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gvwBuchung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvwBuchung.Appearance.FocusedCell.Options.UseFont = true;
            this.gvwBuchung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvwBuchung.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvwBuchung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwBuchung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gvwBuchung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvwBuchung.Appearance.FocusedRow.Options.UseFont = true;
            this.gvwBuchung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvwBuchung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwBuchung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvwBuchung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwBuchung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwBuchung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwBuchung.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvwBuchung.Appearance.GroupRow.Options.UseFont = true;
            this.gvwBuchung.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvwBuchung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvwBuchung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvwBuchung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwBuchung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvwBuchung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvwBuchung.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvwBuchung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvwBuchung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwBuchung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwBuchung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvwBuchung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvwBuchung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvwBuchung.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gvwBuchung.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvwBuchung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwBuchung.Appearance.OddRow.Options.UseFont = true;
            this.gvwBuchung.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.gvwBuchung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwBuchung.Appearance.Row.Options.UseBackColor = true;
            this.gvwBuchung.Appearance.Row.Options.UseFont = true;
            this.gvwBuchung.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvwBuchung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwBuchung.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gvwBuchung.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvwBuchung.Appearance.SelectedRow.Options.UseFont = true;
            this.gvwBuchung.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvwBuchung.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.gvwBuchung.Appearance.VertLine.Options.UseBackColor = true;
            this.gvwBuchung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvwBuchung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBuchgBelegNr,
            this.colBuchgBelegDatum,
            this.colBuchgDetailText,
            this.colBuchgBetrag,
            this.colBuchgKontoNR,
            this.colBuchgDetailKonto,
            this.colBuvhgHV,
            this.colBuchgTV,
            this.colBeguenstigtName,
            this.colBuchgStatus,
            this.colBuchgText,
            this.colFehler,
            this.colIntern});
            this.gvwBuchung.GridControl = this.grdBuchung;
            this.gvwBuchung.Name = "gvwBuchung";
            this.gvwBuchung.OptionsCustomization.AllowFilter = false;
            this.gvwBuchung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvwBuchung.OptionsNavigation.AutoFocusNewRow = true;
            this.gvwBuchung.OptionsView.ColumnAutoWidth = false;
            this.gvwBuchung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvwBuchung.OptionsView.ShowGroupPanel = false;
            // 
            // colBuchgBelegNr
            // 
            this.colBuchgBelegNr.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchgBelegNr.AppearanceCell.Options.UseBackColor = true;
            this.colBuchgBelegNr.Caption = "Beleg";
            this.colBuchgBelegNr.FieldName = "BelegNr";
            this.colBuchgBelegNr.Name = "colBuchgBelegNr";
            this.colBuchgBelegNr.OptionsColumn.AllowEdit = false;
            this.colBuchgBelegNr.Visible = true;
            this.colBuchgBelegNr.VisibleIndex = 0;
            // 
            // colBuchgBelegDatum
            // 
            this.colBuchgBelegDatum.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchgBelegDatum.AppearanceCell.Options.UseBackColor = true;
            this.colBuchgBelegDatum.Caption = "Datum";
            this.colBuchgBelegDatum.DisplayFormat.FormatString = "yyyy.MM";
            this.colBuchgBelegDatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colBuchgBelegDatum.FieldName = "BelegDatum";
            this.colBuchgBelegDatum.Name = "colBuchgBelegDatum";
            this.colBuchgBelegDatum.OptionsColumn.AllowEdit = false;
            this.colBuchgBelegDatum.Visible = true;
            this.colBuchgBelegDatum.VisibleIndex = 2;
            this.colBuchgBelegDatum.Width = 57;
            // 
            // colBuchgDetailText
            // 
            this.colBuchgDetailText.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchgDetailText.AppearanceCell.Options.UseBackColor = true;
            this.colBuchgDetailText.Caption = "Detailtext";
            this.colBuchgDetailText.FieldName = "DetailText";
            this.colBuchgDetailText.Name = "colBuchgDetailText";
            this.colBuchgDetailText.OptionsColumn.AllowEdit = false;
            this.colBuchgDetailText.Visible = true;
            this.colBuchgDetailText.VisibleIndex = 1;
            this.colBuchgDetailText.Width = 294;
            // 
            // colBuchgBetrag
            // 
            this.colBuchgBetrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchgBetrag.AppearanceCell.Options.UseBackColor = true;
            this.colBuchgBetrag.AppearanceHeader.Options.UseTextOptions = true;
            this.colBuchgBetrag.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBuchgBetrag.Caption = "Betrag";
            this.colBuchgBetrag.DisplayFormat.FormatString = "N2";
            this.colBuchgBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBuchgBetrag.FieldName = "Betrag";
            this.colBuchgBetrag.Name = "colBuchgBetrag";
            this.colBuchgBetrag.OptionsColumn.AllowEdit = false;
            this.colBuchgBetrag.Visible = true;
            this.colBuchgBetrag.VisibleIndex = 3;
            this.colBuchgBetrag.Width = 74;
            // 
            // colBuchgKontoNR
            // 
            this.colBuchgKontoNR.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchgKontoNR.AppearanceCell.Options.UseBackColor = true;
            this.colBuchgKontoNR.Caption = "Konto";
            this.colBuchgKontoNR.FieldName = "KontoNr";
            this.colBuchgKontoNR.Name = "colBuchgKontoNR";
            this.colBuchgKontoNR.OptionsColumn.AllowEdit = false;
            this.colBuchgKontoNR.Visible = true;
            this.colBuchgKontoNR.VisibleIndex = 4;
            // 
            // colBuchgDetailKonto
            // 
            this.colBuchgDetailKonto.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchgDetailKonto.AppearanceCell.Options.UseBackColor = true;
            this.colBuchgDetailKonto.Caption = "Detailkonto";
            this.colBuchgDetailKonto.FieldName = "DetailKonto";
            this.colBuchgDetailKonto.Name = "colBuchgDetailKonto";
            this.colBuchgDetailKonto.OptionsColumn.AllowEdit = false;
            this.colBuchgDetailKonto.Visible = true;
            this.colBuchgDetailKonto.VisibleIndex = 5;
            this.colBuchgDetailKonto.Width = 79;
            // 
            // colBuvhgHV
            // 
            this.colBuvhgHV.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuvhgHV.AppearanceCell.Options.UseBackColor = true;
            this.colBuvhgHV.Caption = "Hauptv.";
            this.colBuvhgHV.FieldName = "Hauptvorgang";
            this.colBuvhgHV.Name = "colBuvhgHV";
            this.colBuvhgHV.OptionsColumn.AllowEdit = false;
            this.colBuvhgHV.Visible = true;
            this.colBuvhgHV.VisibleIndex = 6;
            this.colBuvhgHV.Width = 53;
            // 
            // colBuchgTV
            // 
            this.colBuchgTV.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchgTV.AppearanceCell.Options.UseBackColor = true;
            this.colBuchgTV.Caption = "Teilv.";
            this.colBuchgTV.FieldName = "Teilvorgang";
            this.colBuchgTV.Name = "colBuchgTV";
            this.colBuchgTV.OptionsColumn.AllowEdit = false;
            this.colBuchgTV.Visible = true;
            this.colBuchgTV.VisibleIndex = 7;
            this.colBuchgTV.Width = 43;
            // 
            // colBeguenstigtName
            // 
            this.colBeguenstigtName.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBeguenstigtName.AppearanceCell.Options.UseBackColor = true;
            this.colBeguenstigtName.Caption = "Begünstigte/r";
            this.colBeguenstigtName.FieldName = "BeguenstigtName";
            this.colBeguenstigtName.Name = "colBeguenstigtName";
            this.colBeguenstigtName.OptionsColumn.AllowEdit = false;
            this.colBeguenstigtName.Visible = true;
            this.colBeguenstigtName.VisibleIndex = 9;
            this.colBeguenstigtName.Width = 150;
            // 
            // colBuchgStatus
            // 
            this.colBuchgStatus.Caption = "Stat.";
            this.colBuchgStatus.ColumnEdit = this.repedtImages;
            this.colBuchgStatus.FieldName = "KbBuchungStatusCode";
            this.colBuchgStatus.Name = "colBuchgStatus";
            this.colBuchgStatus.OptionsColumn.AllowEdit = false;
            this.colBuchgStatus.Visible = true;
            this.colBuchgStatus.VisibleIndex = 11;
            this.colBuchgStatus.Width = 35;
            // 
            // repedtImages
            // 
            this.repedtImages.AutoHeight = false;
            this.repedtImages.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repedtImages.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repedtImages.Name = "repedtImages";
            // 
            // colBuchgText
            // 
            this.colBuchgText.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchgText.AppearanceCell.Options.UseBackColor = true;
            this.colBuchgText.Caption = "Mitteilung";
            this.colBuchgText.FieldName = "Text";
            this.colBuchgText.Name = "colBuchgText";
            this.colBuchgText.OptionsColumn.AllowEdit = false;
            this.colBuchgText.Visible = true;
            this.colBuchgText.VisibleIndex = 10;
            this.colBuchgText.Width = 149;
            // 
            // colFehler
            // 
            this.colFehler.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colFehler.AppearanceCell.Options.UseBackColor = true;
            this.colFehler.Caption = "PSCD Fehler";
            this.colFehler.FieldName = "PscdFehlermeldung";
            this.colFehler.Name = "colFehler";
            this.colFehler.Visible = true;
            this.colFehler.VisibleIndex = 12;
            this.colFehler.Width = 260;
            // 
            // colIntern
            // 
            this.colIntern.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colIntern.AppearanceCell.Options.UseBackColor = true;
            this.colIntern.AppearanceHeader.Options.UseTextOptions = true;
            this.colIntern.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIntern.Caption = "Int.";
            this.colIntern.FieldName = "Intern";
            this.colIntern.Name = "colIntern";
            this.colIntern.OptionsColumn.AllowEdit = false;
            this.colIntern.Visible = true;
            this.colIntern.VisibleIndex = 8;
            this.colIntern.Width = 45;
            // 
            // kissLabel8
            // 
            this.kissLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel8.DataMember = "IkPositionID";
            this.kissLabel8.DataSource = this.qryListe;
            this.kissLabel8.Location = new System.Drawing.Point(1, 386);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(70, 24);
            this.kissLabel8.TabIndex = 105;
            this.kissLabel8.UseCompatibleTextRendering = true;
            // 
            // lblValuta
            // 
            this.lblValuta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblValuta.Location = new System.Drawing.Point(113, 348);
            this.lblValuta.Name = "lblValuta";
            this.lblValuta.Size = new System.Drawing.Size(77, 24);
            this.lblValuta.TabIndex = 100;
            this.lblValuta.Text = "Valutadatum";
            this.lblValuta.UseCompatibleTextRendering = true;
            // 
            // btnDeselect
            // 
            this.btnDeselect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeselect.Location = new System.Drawing.Point(57, 348);
            this.btnDeselect.Name = "btnDeselect";
            this.btnDeselect.Size = new System.Drawing.Size(46, 24);
            this.btnDeselect.TabIndex = 94;
            this.btnDeselect.Text = "alle -";
            this.btnDeselect.UseCompatibleTextRendering = true;
            this.btnDeselect.UseVisualStyleBackColor = false;
            this.btnDeselect.Click += new System.EventHandler(this.btnDeselect_Click);
            this.btnDeselect.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Location = new System.Drawing.Point(3, 348);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(48, 24);
            this.btnSelect.TabIndex = 93;
            this.btnSelect.Text = "alle +";
            this.btnSelect.UseCompatibleTextRendering = true;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            this.btnSelect.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // btnError
            // 
            this.btnError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnError.Location = new System.Drawing.Point(429, 381);
            this.btnError.Name = "btnError";
            this.btnError.Size = new System.Drawing.Size(106, 24);
            this.btnError.TabIndex = 92;
            this.btnError.Text = "Fehler beheben";
            this.btnError.UseCompatibleTextRendering = true;
            this.btnError.UseVisualStyleBackColor = false;
            this.btnError.Click += new System.EventHandler(this.btnError_Click);
            this.btnError.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // btnUndo2
            // 
            this.btnUndo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUndo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo2.Location = new System.Drawing.Point(429, 348);
            this.btnUndo2.Name = "btnUndo2";
            this.btnUndo2.Size = new System.Drawing.Size(106, 24);
            this.btnUndo2.TabIndex = 91;
            this.btnUndo2.Text = "Rückgängig";
            this.btnUndo2.UseCompatibleTextRendering = true;
            this.btnUndo2.UseVisualStyleBackColor = false;
            this.btnUndo2.Click += new System.EventHandler(this.btnUndo2_Click);
            this.btnUndo2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // btnStart2
            // 
            this.btnStart2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart2.Location = new System.Drawing.Point(194, 381);
            this.btnStart2.Name = "btnStart2";
            this.btnStart2.Size = new System.Drawing.Size(117, 24);
            this.btnStart2.TabIndex = 90;
            this.btnStart2.Text = "Start Verarbeitung";
            this.btnStart2.UseCompatibleTextRendering = true;
            this.btnStart2.UseVisualStyleBackColor = false;
            this.btnStart2.Click += new System.EventHandler(this.btnStart2_Click);
            this.btnStart2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // grdListe
            // 
            this.grdListe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdListe.DataSource = this.qryListe;
            this.grdListe.EmbeddedNavigator.Name = "";
            this.grdListe.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdListe.Location = new System.Drawing.Point(0, 0);
            this.grdListe.MainView = this.gvwListe;
            this.grdListe.Name = "grdListe";
            this.grdListe.Size = new System.Drawing.Size(861, 168);
            this.grdListe.TabIndex = 0;
            this.grdListe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwListe});
            this.grdListe.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // gvwListe
            // 
            this.gvwListe.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvwListe.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwListe.Appearance.Empty.Options.UseBackColor = true;
            this.gvwListe.Appearance.Empty.Options.UseFont = true;
            this.gvwListe.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gvwListe.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwListe.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gvwListe.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvwListe.Appearance.EvenRow.Options.UseFont = true;
            this.gvwListe.Appearance.EvenRow.Options.UseForeColor = true;
            this.gvwListe.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.gvwListe.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwListe.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gvwListe.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvwListe.Appearance.FocusedCell.Options.UseFont = true;
            this.gvwListe.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvwListe.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvwListe.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwListe.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gvwListe.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvwListe.Appearance.FocusedRow.Options.UseFont = true;
            this.gvwListe.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvwListe.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwListe.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvwListe.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwListe.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwListe.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwListe.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvwListe.Appearance.GroupRow.Options.UseFont = true;
            this.gvwListe.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvwListe.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvwListe.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvwListe.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwListe.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvwListe.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvwListe.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvwListe.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvwListe.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwListe.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwListe.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvwListe.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvwListe.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvwListe.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gvwListe.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvwListe.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwListe.Appearance.OddRow.Options.UseFont = true;
            this.gvwListe.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.gvwListe.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwListe.Appearance.Row.Options.UseBackColor = true;
            this.gvwListe.Appearance.Row.Options.UseFont = true;
            this.gvwListe.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvwListe.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwListe.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gvwListe.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvwListe.Appearance.SelectedRow.Options.UseFont = true;
            this.gvwListe.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvwListe.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.gvwListe.Appearance.VertLine.Options.UseBackColor = true;
            this.gvwListe.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvwListe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIstSelektiert,
            this.colMA,
            this.colMonatJahr,
            this.colGlaeubiger,
            this.colGebDat,
            this.colSchuldner,
            this.colForderung,
            this.colBetrag,
            this.colZahlBetrag,
            this.colIntVerrechnung_ALBV,
            this.colIntVerrechnung_ALV,
            this.colIntVerrechnung_KiZu,
            this.colZahlungAn,
            this.colZusatzBetrag,
            this.colZusatzzahlungAn,
            this.colErledigt,
            this.colIstGesendet,
            this.colIstBarzahlung,
            this.colIkRechtstitelID,
            this.colEinmalig});
            this.gvwListe.GridControl = this.grdListe;
            this.gvwListe.Name = "gvwListe";
            this.gvwListe.OptionsCustomization.AllowFilter = false;
            this.gvwListe.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvwListe.OptionsNavigation.AutoFocusNewRow = true;
            this.gvwListe.OptionsView.ColumnAutoWidth = false;
            this.gvwListe.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvwListe.OptionsView.ShowGroupPanel = false;
            this.gvwListe.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvwListe_CustomDrawCell);
            // 
            // colIstSelektiert
            // 
            this.colIstSelektiert.AppearanceCell.BackColor = System.Drawing.Color.AliceBlue;
            this.colIstSelektiert.AppearanceCell.Options.UseBackColor = true;
            this.colIstSelektiert.Caption = "sel.";
            this.colIstSelektiert.FieldName = "IstSelektiert";
            this.colIstSelektiert.Name = "colIstSelektiert";
            this.colIstSelektiert.Visible = true;
            this.colIstSelektiert.VisibleIndex = 0;
            this.colIstSelektiert.Width = 36;
            // 
            // colMA
            // 
            this.colMA.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colMA.AppearanceCell.Options.UseBackColor = true;
            this.colMA.Caption = "MA";
            this.colMA.FieldName = "Username";
            this.colMA.Name = "colMA";
            this.colMA.OptionsColumn.AllowEdit = false;
            this.colMA.Visible = true;
            this.colMA.VisibleIndex = 1;
            this.colMA.Width = 91;
            // 
            // colMonatJahr
            // 
            this.colMonatJahr.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colMonatJahr.AppearanceCell.Options.UseBackColor = true;
            this.colMonatJahr.Caption = "Monat";
            this.colMonatJahr.DisplayFormat.FormatString = "yyyy.MM";
            this.colMonatJahr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colMonatJahr.FieldName = "Datum";
            this.colMonatJahr.Name = "colMonatJahr";
            this.colMonatJahr.OptionsColumn.AllowEdit = false;
            this.colMonatJahr.Visible = true;
            this.colMonatJahr.VisibleIndex = 2;
            this.colMonatJahr.Width = 73;
            // 
            // colGlaeubiger
            // 
            this.colGlaeubiger.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colGlaeubiger.AppearanceCell.Options.UseBackColor = true;
            this.colGlaeubiger.Caption = "Gläubiger";
            this.colGlaeubiger.FieldName = "Glaubiger";
            this.colGlaeubiger.Name = "colGlaeubiger";
            this.colGlaeubiger.OptionsColumn.AllowEdit = false;
            this.colGlaeubiger.Visible = true;
            this.colGlaeubiger.VisibleIndex = 3;
            this.colGlaeubiger.Width = 165;
            // 
            // colGebDat
            // 
            this.colGebDat.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colGebDat.AppearanceCell.Options.UseBackColor = true;
            this.colGebDat.Caption = "Geb.Datum";
            this.colGebDat.FieldName = "Geburtsdatum";
            this.colGebDat.Name = "colGebDat";
            this.colGebDat.OptionsColumn.AllowEdit = false;
            this.colGebDat.Visible = true;
            this.colGebDat.VisibleIndex = 4;
            this.colGebDat.Width = 74;
            // 
            // colSchuldner
            // 
            this.colSchuldner.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colSchuldner.AppearanceCell.Options.UseBackColor = true;
            this.colSchuldner.Caption = "Schuldner";
            this.colSchuldner.FieldName = "Schuldner";
            this.colSchuldner.Name = "colSchuldner";
            this.colSchuldner.OptionsColumn.AllowEdit = false;
            this.colSchuldner.Visible = true;
            this.colSchuldner.VisibleIndex = 5;
            this.colSchuldner.Width = 108;
            // 
            // colForderung
            // 
            this.colForderung.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colForderung.AppearanceCell.Options.UseBackColor = true;
            this.colForderung.Caption = "Forderungs Art";
            this.colForderung.FieldName = "ForderungTitel";
            this.colForderung.Name = "colForderung";
            this.colForderung.OptionsColumn.AllowEdit = false;
            this.colForderung.Visible = true;
            this.colForderung.VisibleIndex = 6;
            this.colForderung.Width = 115;
            // 
            // colBetrag
            // 
            this.colBetrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBetrag.AppearanceCell.Options.UseBackColor = true;
            this.colBetrag.AppearanceHeader.Options.UseTextOptions = true;
            this.colBetrag.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 7;
            this.colBetrag.Width = 70;
            // 
            // colZahlBetrag
            // 
            this.colZahlBetrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colZahlBetrag.AppearanceCell.Options.UseBackColor = true;
            this.colZahlBetrag.AppearanceHeader.Options.UseTextOptions = true;
            this.colZahlBetrag.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colZahlBetrag.Caption = "Zahlung";
            this.colZahlBetrag.DisplayFormat.FormatString = "N2";
            this.colZahlBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colZahlBetrag.FieldName = "ZahlBetrag";
            this.colZahlBetrag.GroupFormat.FormatString = "N2";
            this.colZahlBetrag.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colZahlBetrag.Name = "colZahlBetrag";
            this.colZahlBetrag.OptionsColumn.AllowEdit = false;
            this.colZahlBetrag.Visible = true;
            this.colZahlBetrag.VisibleIndex = 8;
            // 
            // colIntVerrechnung_ALBV
            // 
            this.colIntVerrechnung_ALBV.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colIntVerrechnung_ALBV.AppearanceCell.Options.UseBackColor = true;
            this.colIntVerrechnung_ALBV.AppearanceHeader.Options.UseTextOptions = true;
            this.colIntVerrechnung_ALBV.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIntVerrechnung_ALBV.Caption = "WH";
            this.colIntVerrechnung_ALBV.FieldName = "IntVerrechnung_ALBV";
            this.colIntVerrechnung_ALBV.Name = "colIntVerrechnung_ALBV";
            this.colIntVerrechnung_ALBV.OptionsColumn.AllowEdit = false;
            this.colIntVerrechnung_ALBV.Visible = true;
            this.colIntVerrechnung_ALBV.VisibleIndex = 9;
            this.colIntVerrechnung_ALBV.Width = 45;
            // 
            // colIntVerrechnung_ALV
            // 
            this.colIntVerrechnung_ALV.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colIntVerrechnung_ALV.AppearanceCell.Options.UseBackColor = true;
            this.colIntVerrechnung_ALV.AppearanceHeader.Options.UseTextOptions = true;
            this.colIntVerrechnung_ALV.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIntVerrechnung_ALV.Caption = "WH ALV";
            this.colIntVerrechnung_ALV.FieldName = "IntVerrechnung_ALV";
            this.colIntVerrechnung_ALV.Name = "colIntVerrechnung_ALV";
            this.colIntVerrechnung_ALV.OptionsColumn.AllowEdit = false;
            this.colIntVerrechnung_ALV.Visible = true;
            this.colIntVerrechnung_ALV.VisibleIndex = 10;
            this.colIntVerrechnung_ALV.Width = 45;
            // 
            // colIntVerrechnung_KiZu
            // 
            this.colIntVerrechnung_KiZu.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colIntVerrechnung_KiZu.AppearanceCell.Options.UseBackColor = true;
            this.colIntVerrechnung_KiZu.AppearanceHeader.Options.UseTextOptions = true;
            this.colIntVerrechnung_KiZu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIntVerrechnung_KiZu.Caption = "WH KiZu";
            this.colIntVerrechnung_KiZu.FieldName = "IntVerrechnung_KiZu";
            this.colIntVerrechnung_KiZu.Name = "colIntVerrechnung_KiZu";
            this.colIntVerrechnung_KiZu.OptionsColumn.AllowEdit = false;
            this.colIntVerrechnung_KiZu.Visible = true;
            this.colIntVerrechnung_KiZu.VisibleIndex = 11;
            this.colIntVerrechnung_KiZu.Width = 45;
            // 
            // colZahlungAn
            // 
            this.colZahlungAn.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colZahlungAn.AppearanceCell.Options.UseBackColor = true;
            this.colZahlungAn.Caption = "Zahlung an";
            this.colZahlungAn.FieldName = "ZahlungAn";
            this.colZahlungAn.Name = "colZahlungAn";
            this.colZahlungAn.OptionsColumn.AllowEdit = false;
            this.colZahlungAn.Visible = true;
            this.colZahlungAn.VisibleIndex = 12;
            this.colZahlungAn.Width = 120;
            // 
            // colZusatzBetrag
            // 
            this.colZusatzBetrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colZusatzBetrag.AppearanceCell.Options.UseBackColor = true;
            this.colZusatzBetrag.Caption = "Zusatzbetrag";
            this.colZusatzBetrag.DisplayFormat.FormatString = "N2";
            this.colZusatzBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colZusatzBetrag.FieldName = "ZusatzBetrag";
            this.colZusatzBetrag.Name = "colZusatzBetrag";
            this.colZusatzBetrag.OptionsColumn.AllowEdit = false;
            this.colZusatzBetrag.Visible = true;
            this.colZusatzBetrag.VisibleIndex = 13;
            // 
            // colZusatzzahlungAn
            // 
            this.colZusatzzahlungAn.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colZusatzzahlungAn.AppearanceCell.Options.UseBackColor = true;
            this.colZusatzzahlungAn.Caption = "Zusatzzahlung an";
            this.colZusatzzahlungAn.FieldName = "ZusatzzahlungAn";
            this.colZusatzzahlungAn.Name = "colZusatzzahlungAn";
            this.colZusatzzahlungAn.OptionsColumn.AllowEdit = false;
            this.colZusatzzahlungAn.Visible = true;
            this.colZusatzzahlungAn.VisibleIndex = 14;
            // 
            // colErledigt
            // 
            this.colErledigt.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colErledigt.AppearanceCell.Options.UseBackColor = true;
            this.colErledigt.Caption = "verb.";
            this.colErledigt.FieldName = "ErledigterMonat";
            this.colErledigt.Name = "colErledigt";
            this.colErledigt.Visible = true;
            this.colErledigt.VisibleIndex = 15;
            this.colErledigt.Width = 40;
            // 
            // colIstGesendet
            // 
            this.colIstGesendet.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colIstGesendet.AppearanceCell.Options.UseBackColor = true;
            this.colIstGesendet.Caption = "bez.";
            this.colIstGesendet.FieldName = "IstGesendet";
            this.colIstGesendet.Name = "colIstGesendet";
            this.colIstGesendet.OptionsColumn.AllowEdit = false;
            this.colIstGesendet.Visible = true;
            this.colIstGesendet.VisibleIndex = 16;
            this.colIstGesendet.Width = 40;
            // 
            // colIstBarzahlung
            // 
            this.colIstBarzahlung.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colIstBarzahlung.AppearanceCell.Options.UseBackColor = true;
            this.colIstBarzahlung.AppearanceHeader.Options.UseTextOptions = true;
            this.colIstBarzahlung.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIstBarzahlung.Caption = "bar";
            this.colIstBarzahlung.FieldName = "IstBarzahlung";
            this.colIstBarzahlung.Name = "colIstBarzahlung";
            this.colIstBarzahlung.OptionsColumn.AllowEdit = false;
            this.colIstBarzahlung.Visible = true;
            this.colIstBarzahlung.VisibleIndex = 17;
            this.colIstBarzahlung.Width = 45;
            // 
            // colIkRechtstitelID
            // 
            this.colIkRechtstitelID.Caption = "IkRechtstitelID";
            this.colIkRechtstitelID.FieldName = "IkRechtstitelID";
            this.colIkRechtstitelID.Name = "colIkRechtstitelID";
            // 
            // colEinmalig
            // 
            this.colEinmalig.Caption = "Einmalig";
            this.colEinmalig.FieldName = "Einmalig";
            this.colEinmalig.Name = "colEinmalig";
            // 
            // tbpSollstellung
            // 
            this.tbpSollstellung.Controls.Add(this.btnMonatszahlen_AuchAbgeschlossene);
            this.tbpSollstellung.Controls.Add(this.kissLabel2);
            this.tbpSollstellung.Controls.Add(this.edtFallNr);
            this.tbpSollstellung.Controls.Add(this.kissLabel1);
            this.tbpSollstellung.Controls.Add(this.edtFilterUser);
            this.tbpSollstellung.Controls.Add(this.edtUser);
            this.tbpSollstellung.Controls.Add(this.lblSollstellungsMonat);
            this.tbpSollstellung.Controls.Add(this.edtSollstellungsMonat);
            this.tbpSollstellung.Controls.Add(this.kissLabel7);
            this.tbpSollstellung.Controls.Add(this.edtFilterStatus);
            this.tbpSollstellung.Controls.Add(this.edtFilterMonat);
            this.tbpSollstellung.Controls.Add(this.lblProgress2);
            this.tbpSollstellung.Controls.Add(this.lblSelInkassoTyp);
            this.tbpSollstellung.Controls.Add(this.lblProgress);
            this.tbpSollstellung.Controls.Add(this.kissLabel3);
            this.tbpSollstellung.Controls.Add(this.lblLetzteSollStellung);
            this.tbpSollstellung.Controls.Add(this.btnMonatszahlen);
            this.tbpSollstellung.Controls.Add(this.kissLabel4);
            this.tbpSollstellung.Controls.Add(this.edtFilterTyp);
            this.tbpSollstellung.Location = new System.Drawing.Point(6, 6);
            this.tbpSollstellung.Name = "tbpSollstellung";
            this.tbpSollstellung.Size = new System.Drawing.Size(861, 410);
            this.tbpSollstellung.TabIndex = 1;
            this.tbpSollstellung.Title = "Sollstellung";
            // 
            // btnMonatszahlen_AuchAbgeschlossene
            // 
            this.btnMonatszahlen_AuchAbgeschlossene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMonatszahlen_AuchAbgeschlossene.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatszahlen_AuchAbgeschlossene.Location = new System.Drawing.Point(618, 40);
            this.btnMonatszahlen_AuchAbgeschlossene.Name = "btnMonatszahlen_AuchAbgeschlossene";
            this.btnMonatszahlen_AuchAbgeschlossene.Size = new System.Drawing.Size(240, 24);
            this.btnMonatszahlen_AuchAbgeschlossene.TabIndex = 109;
            this.btnMonatszahlen_AuchAbgeschlossene.Text = "neu berechnen (auch abgeschlossene)";
            this.btnMonatszahlen_AuchAbgeschlossene.UseCompatibleTextRendering = true;
            this.btnMonatszahlen_AuchAbgeschlossene.UseVisualStyleBackColor = false;
            this.btnMonatszahlen_AuchAbgeschlossene.Click += new System.EventHandler(this.btnMonatszahlen_AuchAbgeschlossene_Click);
            this.btnMonatszahlen_AuchAbgeschlossene.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // kissLabel2
            // 
            this.kissLabel2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel2.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel2.Location = new System.Drawing.Point(377, 224);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(251, 89);
            this.kissLabel2.TabIndex = 108;
            this.kissLabel2.Text = resources.GetString("kissLabel2.Text");
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // edtFallNr
            // 
            this.edtFallNr.Location = new System.Drawing.Point(221, 164);
            this.edtFallNr.Name = "edtFallNr";
            this.edtFallNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFallNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFallNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFallNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtFallNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFallNr.Properties.Appearance.Options.UseFont = true;
            this.edtFallNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFallNr.Size = new System.Drawing.Size(141, 24);
            this.edtFallNr.TabIndex = 107;
            this.edtFallNr.EditValueChanged += new System.EventHandler(this.edtFallNr_EditValueChanged);
            this.edtFallNr.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(221, 133);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(141, 24);
            this.kissLabel1.TabIndex = 106;
            this.kissLabel1.Text = "nach Fall-Nr. suchen";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // edtFilterUser
            // 
            this.edtFilterUser.Location = new System.Drawing.Point(332, 15);
            this.edtFilterUser.LookupSQL = "select DisplayText from vwUser\r\nwhere DisplayText = {0}\r\n";
            this.edtFilterUser.Name = "edtFilterUser";
            this.edtFilterUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilterUser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilterUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilterUser.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterUser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilterUser.Properties.Appearance.Options.UseFont = true;
            this.edtFilterUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtFilterUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtFilterUser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFilterUser.Size = new System.Drawing.Size(140, 24);
            this.edtFilterUser.TabIndex = 105;
            this.edtFilterUser.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtFilterUser_UserModifiedFld);
            this.edtFilterUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // edtUser
            // 
            this.edtUser.EditValue = "1";
            this.edtUser.Location = new System.Drawing.Point(221, 47);
            this.edtUser.Name = "edtUser";
            this.edtUser.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtUser.Properties.Appearance.Options.UseBackColor = true;
            this.edtUser.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.edtUser.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtUser.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Nach Mitarbeiter filtern"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("9", "Alle Mitarbeiter anzeigen")});
            this.edtUser.Size = new System.Drawing.Size(251, 50);
            this.edtUser.TabIndex = 102;
            this.edtUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // lblSollstellungsMonat
            // 
            this.lblSollstellungsMonat.Location = new System.Drawing.Point(8, 15);
            this.lblSollstellungsMonat.Name = "lblSollstellungsMonat";
            this.lblSollstellungsMonat.Size = new System.Drawing.Size(80, 24);
            this.lblSollstellungsMonat.TabIndex = 101;
            this.lblSollstellungsMonat.Text = "Selektion Monat";
            this.lblSollstellungsMonat.UseCompatibleTextRendering = true;
            // 
            // edtSollstellungsMonat
            // 
            this.edtSollstellungsMonat.EditValue = null;
            this.edtSollstellungsMonat.Location = new System.Drawing.Point(109, 15);
            this.edtSollstellungsMonat.Name = "edtSollstellungsMonat";
            this.edtSollstellungsMonat.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSollstellungsMonat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollstellungsMonat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollstellungsMonat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollstellungsMonat.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollstellungsMonat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollstellungsMonat.Properties.Appearance.Options.UseFont = true;
            this.edtSollstellungsMonat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSollstellungsMonat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSollstellungsMonat.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSollstellungsMonat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSollstellungsMonat.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtSollstellungsMonat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtSollstellungsMonat.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtSollstellungsMonat.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtSollstellungsMonat.Properties.Mask.EditMask = "MM.yyyy";
            this.edtSollstellungsMonat.Properties.ShowToday = false;
            this.edtSollstellungsMonat.Size = new System.Drawing.Size(84, 24);
            this.edtSollstellungsMonat.TabIndex = 100;
            this.edtSollstellungsMonat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // kissLabel7
            // 
            this.kissLabel7.Location = new System.Drawing.Point(221, 197);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(121, 24);
            this.kissLabel7.TabIndex = 99;
            this.kissLabel7.Text = "Selektion Status";
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // edtFilterStatus
            // 
            this.edtFilterStatus.EditValue = "1";
            this.edtFilterStatus.Location = new System.Drawing.Point(221, 224);
            this.edtFilterStatus.Name = "edtFilterStatus";
            this.edtFilterStatus.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtFilterStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterStatus.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.edtFilterStatus.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtFilterStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "nur unverbuchte Daten"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "nur verbuchte Daten"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3", "nur fehlerhafte Daten"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("9", "alle Daten")});
            this.edtFilterStatus.Size = new System.Drawing.Size(141, 90);
            this.edtFilterStatus.TabIndex = 98;
            this.edtFilterStatus.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // edtFilterMonat
            // 
            this.edtFilterMonat.EditValue = "2";
            this.edtFilterMonat.Location = new System.Drawing.Point(8, 47);
            this.edtFilterMonat.Name = "edtFilterMonat";
            this.edtFilterMonat.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtFilterMonat.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterMonat.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.edtFilterMonat.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtFilterMonat.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "alle für diesen Monat"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "alle für und vor diesem Monat")});
            this.edtFilterMonat.Size = new System.Drawing.Size(185, 50);
            this.edtFilterMonat.TabIndex = 96;
            this.edtFilterMonat.EditValueChanged += new System.EventHandler(this.edtFilterMonat_EditValueChanged);
            this.edtFilterMonat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // lblProgress2
            // 
            this.lblProgress2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress2.Location = new System.Drawing.Point(618, 106);
            this.lblProgress2.Name = "lblProgress2";
            this.lblProgress2.Size = new System.Drawing.Size(240, 24);
            this.lblProgress2.TabIndex = 95;
            this.lblProgress2.Text = "";
            this.lblProgress2.UseCompatibleTextRendering = true;
            // 
            // lblSelInkassoTyp
            // 
            this.lblSelInkassoTyp.Location = new System.Drawing.Point(8, 132);
            this.lblSelInkassoTyp.Name = "lblSelInkassoTyp";
            this.lblSelInkassoTyp.Size = new System.Drawing.Size(124, 24);
            this.lblSelInkassoTyp.TabIndex = 94;
            this.lblSelInkassoTyp.Text = "Selektion Inkassotyp";
            this.lblSelInkassoTyp.UseCompatibleTextRendering = true;
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.Location = new System.Drawing.Point(618, 74);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(240, 24);
            this.lblProgress.TabIndex = 93;
            this.lblProgress.Text = "0 /  0";
            this.lblProgress.UseCompatibleTextRendering = true;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(378, 106);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(213, 24);
            this.kissLabel3.TabIndex = 92;
            this.kissLabel3.Text = "zuletzt erstellte Sollstellung";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // lblLetzteSollStellung
            // 
            this.lblLetzteSollStellung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLetzteSollStellung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblLetzteSollStellung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblLetzteSollStellung.Location = new System.Drawing.Point(378, 130);
            this.lblLetzteSollStellung.Name = "lblLetzteSollStellung";
            this.lblLetzteSollStellung.Size = new System.Drawing.Size(480, 61);
            this.lblLetzteSollStellung.TabIndex = 91;
            this.lblLetzteSollStellung.Text = "Sollstellung";
            this.lblLetzteSollStellung.UseCompatibleTextRendering = true;
            // 
            // btnMonatszahlen
            // 
            this.btnMonatszahlen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMonatszahlen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatszahlen.Location = new System.Drawing.Point(618, 10);
            this.btnMonatszahlen.Name = "btnMonatszahlen";
            this.btnMonatszahlen.Size = new System.Drawing.Size(240, 24);
            this.btnMonatszahlen.TabIndex = 90;
            this.btnMonatszahlen.Text = "neu berechnen (monatlich)";
            this.btnMonatszahlen.UseCompatibleTextRendering = true;
            this.btnMonatszahlen.UseVisualStyleBackColor = false;
            this.btnMonatszahlen.Click += new System.EventHandler(this.btnMonatszahlen_Click);
            this.btnMonatszahlen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(221, 15);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(121, 24);
            this.kissLabel4.TabIndex = 86;
            this.kissLabel4.Text = "Selektion Mitarbeiter";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // edtFilterTyp
            // 
            this.edtFilterTyp.EditValue = "6";
            this.edtFilterTyp.Location = new System.Drawing.Point(8, 164);
            this.edtFilterTyp.Name = "edtFilterTyp";
            this.edtFilterTyp.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtFilterTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterTyp.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.edtFilterTyp.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtFilterTyp.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "ALBV Auszahlung/ Forderung"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "ÜbH Auszahlung"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3", "KKBB Auszahlung"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("4", "ALV Forderung"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("5", "einmalige Forderungen"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("7", "einmalige Zahlungen"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("6", "alle")});
            this.edtFilterTyp.Size = new System.Drawing.Size(187, 150);
            this.edtFilterTyp.TabIndex = 8;
            this.edtFilterTyp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            // 
            // CtlIkSollstellung
            // 
            this.ActiveSQLQuery = this.qryListe;
            this.Controls.Add(this.tabSollstellung);
            this.Controls.Add(this.panel1);
            this.Name = "CtlIkSollstellung";
            this.Size = new System.Drawing.Size(876, 493);
            this.Load += new System.EventHandler(this.CtlIkSollstellung_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtlIkSollstellung_KeyUp);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.tabSollstellung.ResumeLayout(false);
            this.tbpListen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtFehler.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValuta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryValuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repedtImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwListe)).EndInit();
            this.tbpSollstellung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollstellungsMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollstellungsMonat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterMonat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgress2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelInkassoTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzteSollStellung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterTyp.Properties)).EndInit();
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

        #region Private Methods

        private void CtlIkSollstellung_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (tabSollstellung.SelectedTabIndex == 1)
                    tabSollstellung.SelectedTabIndex = 0;
                else
                    tabSollstellung.SelectedTabIndex = 1;
            }
        }

        private void CtlIkSollstellung_Load(object sender, System.EventArgs e)
        {
            // 11.12.2008 : sozheo : Valutadatum immer grösser gleich HEUTE

            edtSollstellungsMonat.DateTime = DateTime.Today;

            FilterUserID = Session.User.UserID;
            SqlQuery qry = DBUtil.OpenSQL(
                "select DisplayText from dbo.vwUser where UserID = {0}",
                Session.User.UserID
            );
            edtFilterUser.EditValue = Utils.ConvertToString(qry["DisplayText"]);

            //Buchungsstati laden
            repedtImages.SmallImages = KissImageList.SmallImageList;

            SqlQuery qryStati = DBUtil.OpenSQL(@"
                select Code, Text, Value1 from dbo.XLOVCode WITH (READUNCOMMITTED) 
                where LOVName = 'KbBuchungsStatus' order by SortKey"
            );
            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repedtImages.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    row["Text"].ToString(),
                    (int)row["Code"],
                    KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))
                ));
            }

            if (modul == ModulID.I)
            {
                // A Sollstellung
                HasRights = DBUtil.UserHasRight("CtlIkSollstellung_A");
                lblTitel.Text = "Sollstellung Alimente";
                qryValuta.SelectStatement = @"SELECT Datum FROM dbo.fnIkZahlungslaufValuta(GETDATE())";
            }
            else
            {
                // W Sollstellung
                HasRights = DBUtil.UserHasRight("CtlIkSollstellung_W");
                lblTitel.Text = "Sollstellung Wirtschaftshilfe";
                lblSelInkassoTyp.Visible = false;
                edtFilterTyp.Visible = false;
                btnBarbeleg.Visible = false;
                qryValuta.SelectStatement = @"SELECT Datum FROM dbo.fnIkZahlungslaufValuta(GETDATE())";
            }

            edtValuta.EditMode = HasRights ? EditModeType.Normal : EditModeType.ReadOnly;
            btnSelect.Enabled = HasRights;
            btnDeselect.Enabled = HasRights;

            edtFilterMonat_EditValueChanged(null, null);
        }

        private void QryListeOpen()
        {

            // 15.08.2008 : sozheo : Jetzt kommen auch einmalige Forderungen ohne Glb.
            // 14.10.2008 : sozheo : SQL optimiert
            // 30.10.2008 : sozheo : neu Filtern: stornierte, einmaligen Forderungen nicht anzeigen
            // 15.01.2009 : sozheo : Performance optimiert
            // 22.03.2009 : sozheo : ModuID korrigiert

            int Jahr = edtSollstellungsMonat.DateTime.Year;
            int Monat = edtSollstellungsMonat.DateTime.Month;
            int ModulID = 0;
            if (modul == Gui.ModulID.I)
                // A Sollstellung
                ModulID = 4;
            else
                // W Sollstellung
                ModulID = 3;

            string Statmt = string.Format(
                "exec dbo.spIkSollstellung {0}, {1}, {2}, {3}, {4}, '{5}', '{6}', '{7}', {8}",
                Jahr, Monat,
                ModulID, // A-Modul
                ((Utils.ConvertToString(edtUser.EditValue) == "1") ? FilterUserID.ToString() : "0"),  // User
                ((edtFallNr.Text != "") ? edtFallNr.Text : "0"), // Suchen nach Fall-Nummer
                Utils.ConvertToString(edtFilterMonat.EditValue), // Filter Monat
                Utils.ConvertToString(edtFilterTyp.EditValue), // FilterTyp
                Utils.ConvertToString(edtFilterStatus.EditValue), // FilterStatus
                true  // inkl. Zusatzangaben
            );
            qryListe.Fill(Statmt);
        }

        private void SetFilterChoices()
        {
            string OldValue = Utils.ConvertToString(edtFilterStatus.EditValue);
            edtFilterStatus.Properties.Items.Clear();

            DevExpress.XtraEditors.Controls.RadioGroupItem item1 = new DevExpress.XtraEditors.Controls.RadioGroupItem();
            item1.Description = "nur unverbuchte Daten";
            item1.Value = "1";
            edtFilterStatus.Properties.Items.Add(item1);

            DevExpress.XtraEditors.Controls.RadioGroupItem item3 = new DevExpress.XtraEditors.Controls.RadioGroupItem();
            item3.Description = "nur fehlerhafte Daten";
            item3.Value = "3";
            edtFilterStatus.Properties.Items.Add(item3);

            if (Utils.ConvertToString(edtFilterMonat.EditValue) == "1" || Utils.ConvertToString(edtFallNr.EditValue) != "")
            {
                DevExpress.XtraEditors.Controls.RadioGroupItem item2 = new DevExpress.XtraEditors.Controls.RadioGroupItem();
                item2.Description = "nur verbuchte Daten";
                item2.Value = "2";
                edtFilterStatus.Properties.Items.Add(item2);

                DevExpress.XtraEditors.Controls.RadioGroupItem item9 = new DevExpress.XtraEditors.Controls.RadioGroupItem();
                item9.Description = "alle Daten";
                item9.Value = "9";
                edtFilterStatus.Properties.Items.Add(item9);

                edtFilterStatus.EditValue = OldValue;
                edtFilterStatus.Height = 90;
            }
            else
            {
                if (OldValue == "2" || OldValue == "9") edtFilterStatus.EditValue = "1";
                edtFilterStatus.Height = 50;
            }
        }

        private void ShowLastAction()
        {
            // 14.10.2008 : sozheo : SQL optimiert

            SqlQuery qry = DBUtil.OpenSQL(@"
                select top 1 F.Jahr, F.Monat from dbo.IkPosition F WITH (READUNCOMMITTED)
                where Exists(
                  select top 1 K.KbBuchungID from dbo.KbBuchung K WITH (READUNCOMMITTED)
                  where K.IkPositionID = F.IkPositionID)
                order by F.Jahr desc, F.Monat desc"
            );

            if (qry.Count == 0)
            {
                lblLetzteSollStellung.Text = "keine Sollstellung gefunden";
            }
            else
            {
                DateTime dt = Convert.ToDateTime("01." + qry["Monat"].ToString() + "." + qry["Jahr"].ToString());
                lblLetzteSollStellung.Text = "Letzte Sollstellung für " + dt.ToString("MMMM yyyy");
            }
        }

        private void btnBarbeleg_Click(object sender, System.EventArgs e)
        {
            int Anz = 0;
            int PCode = 0;
            foreach (System.Data.DataRow row in qryListe.DataTable.Rows)
            {
                PCode = Utils.ConvertToInt(row["FaProzessCode"]);
                if (
                    Utils.ConvertToBool(row["IstSelektiert"], false) &&
                    !Utils.ConvertToBool(row["ErledigterMonat"], true) &&
                    !Utils.ConvertToBool(row["IntVerrechnung_ALBV"], true) &&
                    (PCode == 405 || PCode == 406 || PCode == 407) &&
                    Utils.ConvertToDecimal(row["ZahlBetrag"]) > 0
                )
                {
                    Anz += 1;
                    break;
                }
            }
            if (Anz == 0)
            {
                KissMsg.ShowInfo("Es sind keine Zeilen selektiert, welche bar bezahlt werden können.");
                return;
            }

            bool DataIsGenerated = false;
            bool CreateWasOK = false;
            int intAnzahl = 0;
            string ErrorText = "";

            foreach (System.Data.DataRow row in qryListe.DataTable.Rows)
            {
                PCode = Utils.ConvertToInt(row["FaProzessCode"]);
                if (
                    Utils.ConvertToBool(row["IstSelektiert"], false) &&
                    !Utils.ConvertToBool(row["ErledigterMonat"], true) &&
                    !Utils.ConvertToBool(row["IntVerrechnung_ALBV"], true) &&
                    (PCode == 405 || PCode == 406 || PCode == 407) &&
                    Utils.ConvertToDecimal(row["ZahlBetrag"]) > 0
                )
                {
                    try
                    {
                        DBUtil.ThrowExceptionOnOpenTransaction();
                        Session.BeginTransaction();
                        DataIsGenerated = false;
                        SqlQuery qry = DBUtil.OpenSQL(string.Format(@"
                            EXEC dbo.spIkSollstellung_KbBuchung_Create {0}, '{1}', {2}, {3}",
                            Utils.ConvertToInt(row["IkPositionID"]),
                            DateTime.Today.ToString("yyyyMMdd"),
                            Session.User.UserID,
                            1
                        ));
                        CreateWasOK = (Utils.ConvertToInt(qry["HasErrors"]) == 0);
                        if (!CreateWasOK)
                            ErrorText = Utils.ConvertToString(qry["ErrorText"]);
                        else
                            intAnzahl += 1;

                        if (CreateWasOK)
                        {
                            Session.Commit();
                            DataIsGenerated = true;
                        }
                        else
                        {
                            Session.Rollback();
                            KissMsg.ShowInfo(ErrorText);
                        }
                    }
                    catch (Exception ex)
                    {
                        if(Session.Transaction != null)
                            Session.Rollback();
                        KissMsg.ShowInfo(ex.Message);
                    }
                    if (!DataIsGenerated) break;
                }
            }

            if (DataIsGenerated)
            {
                KissMsg.ShowInfo(string.Format("Es wurde(n) {0} Barbeleg(e) erstellt.", intAnzahl.ToString()));
                ShowLastAction();
                QryListeOpen();
            }
        }

        private void btnDeselect_Click(object sender, System.EventArgs e)
        {
            foreach (System.Data.DataRow row in qryListe.DataTable.Rows)
            {
                row["IstSelektiert"] = false;
            }
        }

        private void btnError_Click(object sender, System.EventArgs e)
        {
            if (qryKbBuchung.Count == 0) return;

            string PscdMsg = Utils.ConvertToString(qryKbBuchung["PscdFehlermeldung"]);
            string Msg = "";
            if (PscdMsg.StartsWith("Keine ESR-Referenznummer angegeben für"))
            {
                // Korrektur des Fehlers:
                // Keine ESR-Referenznummer angegeben für Nettobeleg mit ID 2780
                // Keine ESR-Referenznummer angegeben für Alim-Nettobeleg mit ID 2922
                if (!KissMsg.ShowQuestion(
                    "Die Zahlungsweg-Informationen werden nun korrigiert.\r\n" +
                    "Haben Sie den Zahlungsweg bereits korrigiert?")) return;

                SqlQuery qry = DBUtil.OpenSQL(@"
                    DECLARE @Result INT
                    EXEC @Result = dbo.spIkSollstellung_KbBuchung_Update {0}
                    SELECT Result = @Result",
                    qryKbBuchung["KbBuchungID"]
                );

                int ECode = Utils.ConvertToInt(qry["Result"]);
                if (ECode == -1) Msg =
                    "Ungültiger Parameter KbBuchungID.";
                if (ECode == -2) Msg =
                    "Der Status dieser Buchung ist nicht fehlerhaft.\r\n";
                if (ECode == -3) Msg =
                    "Die Korrektur dieses Fehlers ist noch nicht programmiert.\r\n";
                if (ECode == -4) Msg =
                    "Ungültiger Parameter KbBuchungID: Position konnte nicht gefunden werden.";
                if (ECode == -5) Msg =
                    "Ungültiger Parameter KbBuchungID: Rechtstitel konnte nicht gefunden werden.";
                if (ECode == -6) Msg =
                    "Der Zahlungsweg konnte nicht gefunden werden (ev. Unterstützungsfall).\r\n" +
                    "Korrigieren Sie zuerst den Zahlunsgweg beim Gläubiger.";
                if (ECode == -7) Msg =
                    "Es konnten keine notwendigen Korrekturen angewendet werden.\r\n" +
                    "Offenbar wurde der Zahlungsweg noch nicht angepasst.";
            }
            else
            {
                KissMsg.ShowInfo("Die Korrektur dieses Fehlers ist noch nicht programmiert.");
                return;
            }

            if (Msg != "")
            {
                Msg = "Fehler beim Korrigieren:\r\n" + Msg;
                KissMsg.ShowInfo(Msg);
            }
            else
            {
                KissMsg.ShowInfo(string.Format("Der Fehler\r\n'{0}'\r\nwurde behoben.", PscdMsg));
                // Daten neu anzeigen:
                qryKbBuchung.Fill(Utils.ConvertToInt(qryListe["IkPositionID"]));
            }
        }

        private void btnMonatszahlen_Click(object sender, System.EventArgs e)
        {
            MonatszahlenNeuRechnen(true);
        }

        private void MonatszahlenNeuRechnen(bool ohneAbgeschlosseneLeistungen)
        {
            string strTotal = "";
            int intAnzahl = 0;
            int AnzErrors = 0;
            int AnzSuccess = 0;
            int ReturnNr = 0;
            DateTime zeitStart = DateTime.Now;
            DateTime zeitEnde = DateTime.Now;
            lblProgress.Text = "";

            string modulFilterRTI = (modul == ModulID.I) ?
                // A Sollstellung
                "405,406,407" :
                // W Sollstellung
                "0";
            string modulFilterLST = (modul == ModulID.I) ?
                // A Sollstellung
                "408,409,410" :
                // W Sollstellung
                "301,302,304";

            try
            {
                string sqlFilter = ohneAbgeschlosseneLeistungen ? "and L.DatumBis IS NULL" : "";
                SqlQuery qryAll = DBUtil.OpenSQL(string.Format(@"
                    select distinct R.FaLeistungID from dbo.IkRechtstitel R WITH (READUNCOMMITTED)
                    left outer join dbo.FaLeistung L WITH (READUNCOMMITTED) on L.FaLeistungID = R.FaLeistungID
                    where L.FaProzessCode in ({0}) {2}
                    UNION ALL
                    select L.FaLeistungID from dbo.FaLeistung L WITH (READUNCOMMITTED)
                    where L.FaProzessCode in ({1}) {2}",
                    modulFilterRTI,
                    modulFilterLST,
                    sqlFilter
                ));

                strTotal = qryAll.Count.ToString();
                foreach (System.Data.DataRow row in qryAll.DataTable.Rows)
                {
                    // Progress anzeigen
                    intAnzahl += 1;
                    lblProgress.Text = intAnzahl.ToString() + " von " + strTotal;
                    lblProgress.Refresh();

                    SqlQuery qry = DBUtil.OpenSQL(@"
                        DECLARE @Result INT
                        EXEC @Result = dbo.spIkMonatszahlen_DetailAll {0}, 1
                        SELECT Result = @Result",
                        row["FaLeistungID"]
                    );

                    ReturnNr = Utils.ConvertToInt(qry["Result"]);
                    if (ReturnNr < 0) AnzErrors += 1; else AnzSuccess += 1;
                }
                zeitEnde = DateTime.Now;
            }
            catch (Exception ex)
            {
                zeitEnde = DateTime.Now;
                KissMsg.ShowInfo(ex.Message);
                return;
            }

            TimeSpan ts = zeitEnde - zeitStart;
            lblProgress2.Text = ts.ToString();

            KissMsg.ShowInfo(
                "Berechnung der Monatszahlen beendet.\r\n" +
                string.Format("{0} Rechtstitel/Leistungen erstellt oder korrigiert.\r\n", strTotal) +
                string.Format("{0} erfolgreich, {1} fehlerhaft.", AnzSuccess.ToString(), AnzErrors.ToString())
            );
        }

        private void btnSelect_Click(object sender, System.EventArgs e)
        {
            foreach (System.Data.DataRow row in qryListe.DataTable.Rows)
            {
                row["IstSelektiert"] = true;
            }
        }

        private void btnStart2_Click(object sender, System.EventArgs e)
        {
            int Anz = 0;
            foreach (System.Data.DataRow row in qryListe.DataTable.Rows)
                if ((bool)row["IstSelektiert"] && (!(bool)row["ErledigterMonat"]))
                {
                    Anz += 1;
                    break;
                }
            if (Anz == 0)
            {
                KissMsg.ShowInfo("Es sind keine Zeilen selektiert, welche verbucht werden können.");
                return;
            }

            bool DataIsGenerated = false;

            if (edtSollstellungsMonat.EditValue.ToString() == "")
            {
                KissMsg.ShowInfo("Der Sollstellungsmonat darf nicht leer bleiben.");
                return;
            }

            if (DBUtil.IsEmpty(edtValuta.EditValue) || edtValuta.EditValue.ToString() == "")
            {
                KissMsg.ShowInfo("Das Valutadatum darf nicht leer bleiben.");
                return;
            }

            DateTime SollStellg = (DateTime)edtSollstellungsMonat.EditValue;
            int Monat = SollStellg.Month;
            int Jahr = SollStellg.Year;

            bool CreateWasOK = false;
            int intAnzahl = 0;
            string ErrorText = "";
            try
            {
                DBUtil.ThrowExceptionOnOpenTransaction();
                Session.BeginTransaction();
                foreach (System.Data.DataRow row in qryListe.DataTable.Rows)
                {
                    if ((bool)row["IstSelektiert"] && (!(bool)row["ErledigterMonat"]))
                    {
                        SqlQuery qry = DBUtil.OpenSQL(string.Format(@"
                        EXEC dbo.spIkSollstellung_KbBuchung_Create {0}, '{1}', {2}, {3}",
                            Utils.ConvertToInt(row["IkPositionID"]),
                            ((DateTime)edtValuta.EditValue).ToString("yyyyMMdd"),
                            Session.User.UserID,
                            0
                        ));
                        CreateWasOK = (Utils.ConvertToInt(qry["HasErrors"]) == 0);
                        if (!CreateWasOK)
                        {
                            ErrorText = Utils.ConvertToString(qry["ErrorText"]);
                            break;
                        }
                        intAnzahl += Utils.ConvertToInt(qry["AnzahlErstellt"]);
                    }
                }
                if (CreateWasOK)
                {
                    Session.Commit();
                    DataIsGenerated = true;
                    KissMsg.ShowInfo(string.Format("Es wurde(n) {0} Buchung(en) erstellt.", intAnzahl.ToString()));
                }
                else
                {
                    if(Session.Transaction != null)
                        Session.Rollback();
                    KissMsg.ShowInfo(ErrorText);
                }
            }
            catch (Exception ex)
            {
                if(Session.Transaction != null)
                    Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }

            if (DataIsGenerated)
            {
                ShowLastAction();
                QryListeOpen();
            }
        }

        private void btnStorno_Click(object sender, System.EventArgs e)
        {
            // 31.07.2008 : sozheo : neu mit Transaktion
            // 04.08.2008 : sozheo : neu ohne SP spKbBuchung_StornoAll
            // 25.02.2009 : sozseo : neu werden die Stornierten Buchungen in der Tabelle KbBuchungStorno gespeichert,
            //                       und der Webservice-Call ist neu mit StornoDatum (=Today)

            if (!KissMsg.ShowQuestion("Wollen Sie diese Buchung wirklich stornieren?")) return;

            // Kontrolle an PSCD, ob storniert werden darf
            int[] iArray = new int[qryKbBuchung.Count];
            string buchungIDs = "";

            int idx = 0;
            foreach (System.Data.DataRow row in qryKbBuchung.DataTable.Rows)
            {
                iArray[idx] = Utils.ConvertToInt(row["KbBuchungID"]);
                buchungIDs = (buchungIDs == "") ? iArray[idx].ToString() : buchungIDs + ", " + iArray[idx].ToString();
                idx += 1;
            }

            if (buchungIDs == "")
            {
                // Keine Buchungen gefunden, es kann nichts storniert werden
                KissMsg.ShowInfo("Es existieren keine Buchungen, welche storniert werden können.");
                return;
            }

            try
            {
                // PSCD Storno
                try
                {
                    // Zuerst erstellen wir neue Storno-Einträge in der Tabelle KbBuchungStorno
                    DBUtil.ThrowExceptionOnOpenTransaction();
                    Session.BeginTransaction();

                    // Alle selektierten in der Storno-Tabelle zufügen (falls sie nicht schon existieren)
                    DB.DBUtil.ExecSQLThrowingException(@"
                    INSERT INTO dbo.KbBuchungStorno
                    (KbBuchungID, StornierungVermerktUserID, StornierungVermerktDatum)
                    (
                        SELECT BUC.KbBuchungID, {0}, {1} FROM dbo.KbBuchung BUC
                            LEFT JOIN dbo.KbBuchungStorno STO ON STO.KbBuchungID = BUC.KbBuchungID
                        WHERE BUC.KbBuchungID IN (" + buchungIDs + @")
                                AND STO.KbBuchungID IS NULL		-- Es gibt noch keine Storno-Eintrag für diesen Beleg
                    )
                    ", Session.User.UserID, DateTime.Now);

                    Session.Commit();
                }
                catch (Exception ex2)
                {
                    if (Session.Transaction != null)
                    {
                        Session.Rollback();
                    }

                    KissMsg.ShowError(
                        "Fehler beim Speichern der Stornovorgänge in der Kiss-DB.\r\n" +
                        "Der Storno-Vorgang wurde nicht ausgeführt. Fehlermeldung: \r\n\r\n" +
                        ex2.Message, ex2);
                    return;
                }

                // StornoDatum = Tagesdatum
                PSCDInterface.StornoNettoBelege(iArray, DateTime.Today);
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
                return;
            }

            DBUtil.ExecSQL("EXEC dbo.spIkMonatszahlen_DetailLeistung {0}, {1}, {2}",
                qryListe["FaLeistungID"],
                qryListe["Jahr"],
                qryListe["Monat"]
            );

            KissMsg.ShowInfo("Die ganze Position wurde storniert.");
            ShowLastAction();
            QryListeOpen();
        }

        private void btnUndo2_Click(object sender, System.EventArgs e)
        {
            int Anz = 0;
            foreach (System.Data.DataRow row in qryListe.DataTable.Rows)
                if (((bool)row["IstSelektiert"]) && ((bool)row["ErledigterMonat"]) && (!(bool)row["IstGesendet"]))
                {
                    Anz += 1;
                    break;
                }
            if (Anz == 0)
            {
                KissMsg.ShowInfo("Es sind keine Zeilen selektiert, welche rückgängig gemacht werden können.");
                return;
            }

            if (!KissMsg.ShowQuestion("Wollen Sie die selektierten Zeilen wirklich rückgängig machen?"))
                return;

            DateTime SollStellg = (DateTime)edtSollstellungsMonat.EditValue;
            int Monat = SollStellg.Month;
            int Jahr = SollStellg.Year;

            string ErrorText = "";
            bool UndoWasOk = false;
            int intAnzahl = 0;

            try
            {
                foreach (System.Data.DataRow row in qryListe.DataTable.Rows)
                    if (((bool)row["IstSelektiert"]) && ((bool)row["ErledigterMonat"]) && (!(bool)row["IstGesendet"]))
                    {
                        SqlQuery qry = DBUtil.OpenSQL(string.Format(@"
                        EXEC dbo.spIkSollstellung_KbBuchung_Undo {0}",
                            Utils.ConvertToInt(row["IkPositionID"])
                        ));
                        UndoWasOk = (Utils.ConvertToInt(qry["HasErrors"]) == 0);
                        if (!UndoWasOk)
                        {
                            ErrorText = Utils.ConvertToString(qry["ErrorText"]);
                            break;
                        }
                        intAnzahl += Utils.ConvertToInt(qry["UndoCount"]);
                    }

                if (!UndoWasOk)
                {
                    KissMsg.ShowInfo(ErrorText);
                    return;
                }
                else
                {
                    KissMsg.ShowInfo(string.Format(
                        "Es wurde(n) {0} Buchung(en) rückgängig gemacht.",
                        intAnzahl.ToString()
                    ));
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
                return;
            }
            ShowLastAction();
            QryListeOpen();
        }

        private void edtFallNr_EditValueChanged(object sender, System.EventArgs e)
        {
            if (!edtFallNr.UserModified) return;
            SetFilterChoices();
        }

        private void edtFilterMonat_EditValueChanged(object sender, System.EventArgs e)
        {
            SetFilterChoices();
        }

        private void edtFilterUser_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtFilterUser.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "";
                }
                else
                {
                    FilterUserID = 0;
                    edtFilterUser.EditValue = "";
                    edtFilterUser.ToolTip = "";
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT UserID$ = UserID,
                  DisplayText$ = DisplayText,
                  [Kürzel] = LogonName,
                  [Mitarbeiter/in] = NameVorname,
                  [Org.Einheit] = OrgUnit,
                  LogonNameVornameOrgUnit$ = LogonNameVornameOrgUnit
                FROM dbo.vwUser
                WHERE ( DisplayText LIKE '%' + {0} + '%' or  {0} IS NULL)
                  AND UserID IN (select distinct UserID from dbo.FaLeistung WITH (READUNCOMMITTED) where ModulID in (3,4))
                ORDER BY NameVorname",
                SearchString,
                e.ButtonClicked, null, null, null
            );

            if (!e.Cancel)
            {
                FilterUserID = Utils.ConvertToInt(dlg[0]);
                edtFilterUser.EditValue = Utils.ConvertToString(dlg[1]);
                edtFilterUser.ToolTip = Utils.ConvertToString(dlg[1]);
            }
        }

        private void gvwListe_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gvwListe.FocusedRowHandle == e.RowHandle) return;

            if (e.Column.FieldName == "IstSelektiert")
            {
                e.Appearance.BackColor = Color.AliceBlue;
                //e.Appearance.ForeColor = Color.Black;
            }
            else if (e.RowHandle != gvwListe.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.BlanchedAlmond;
                //e.Appearance.ForeColor = Color.Black;
            }

            // 05.07.2009 : sozheo : Umbau neues Konzept, altes Konzept in grau
            int rtID = Utils.ConvertToInt(gvwListe.GetRowCellValue(e.RowHandle, gvwListe.Columns["IkRechtstitelID"]));
            bool istEinmalig = Utils.ConvertToBool(gvwListe.GetRowCellValue(e.RowHandle, gvwListe.Columns["Einmalig"]));
            e.Appearance.ForeColor = (rtID > 0 && !istEinmalig) ? Color.Gray : Color.Black;
        }

        private void qryKbBuchung_AfterFill(object sender, System.EventArgs e)
        {
            if (qryKbBuchung.Count == 0) qryKbBuchung_PositionChanged(sender, e);
        }

        private void qryKbBuchung_PositionChanged(object sender, System.EventArgs e)
        {
            // 05.08.2008 : sozheo : Storno auch sichtbar, wenn nicht Filter = verbuchte

            int FCode = Utils.ConvertToInt(qryKbBuchung["IkForderungArtCode"]);
            btnError.Enabled = (
                HasRights &&
                qryKbBuchung.Count > 0 &&
                (FCode == 10 || FCode == 11 || FCode == 12) &&
                (
                    Utils.ConvertToString(qryKbBuchung["PscdFehlermeldung"]).StartsWith("Keine ESR-Referenznummer angegeben für")
                )
            );
        }

        private void qryListe_AfterFill(object sender, System.EventArgs e)
        {
            if (qryListe.Count == 0) qryListe_PositionChanged(sender, e);
        }

        private void qryListe_PositionChanged(object sender, System.EventArgs e)
        {
            // Starten nur, wenn es Datensätze gibt:
            btnStart2.Enabled = (HasRights && qryListe.Count > 0);

            // Rückgängig nur, wenn der Datensartz verbucht ist, aber noch nicht ans PSCD gesendet ist:
            btnUndo2.Enabled = (
                HasRights &&
                qryListe.Count > 0 &&
                Utils.ConvertToBool(qryListe["ErledigterMonat"], false) &&
                !Utils.ConvertToBool(qryListe["IstGesendet"], true)
            );

            // Starten nur, wenn es Datensätze gibt:
            btnBarbeleg.Enabled = (HasRights && qryListe.Count > 0);

            // Buchungen  anzeigen
            qryKbBuchung.Fill(Utils.ConvertToInt(qryListe["IkPositionID"]));

            // Button stornieren einstellen
            btnStorno.Enabled = (
                HasRights &&
                qryListe.Count > 0 &&
                qryKbBuchung.Count > 0 &&
                Utils.ConvertToBool(qryListe["TotalStornoIstMoeglich"], false) &&
                Utils.ConvertToBool(qryListe["ErledigterMonat"], false)
            );
        }

        private void tabSollstellung_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (tabSollstellung.SelectedTabIndex == 0) return;

            QryListeOpen();

            qryValuta.Fill(edtSollstellungsMonat.DateTime.Year, edtSollstellungsMonat.DateTime.Month);
            edtValuta.Properties.DropDownRows = 7;
        }

        private void tabSollstellung_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
            if (tabSollstellung.SelectedTabIndex == 1) return;

            if (DBUtil.IsEmpty(edtSollstellungsMonat.EditValue))
            {
                KissMsg.ShowInfo("Wählen Sie zuerst den Verarbeitungsmonat.");
                e.Cancel = true;
            }

            try
            {
                if (!DBUtil.IsEmpty(edtFallNr.EditValue))
                {
                    int FNr = Convert.ToInt32(Utils.ConvertToString(edtFallNr.EditValue));
                }
            }
            catch
            {
                KissMsg.ShowInfo("Die Fallnummer darf nur Zahlen enthalten.");
                e.Cancel = true;
            }
        }

        #endregion

        private void btnMonatszahlen_AuchAbgeschlossene_Click(object sender, EventArgs e)
        {
            MonatszahlenNeuRechnen(false);
        }
    }
}