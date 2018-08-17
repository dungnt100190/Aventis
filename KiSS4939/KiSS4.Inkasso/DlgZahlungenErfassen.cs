using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Inkasso
{
    public class DlgZahlungenErfassen : KiSS4.Gui.KissDialog
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly Color CLR_GREEN = Color.DarkSeaGreen;
        private readonly Color CLR_RED = Color.Salmon;

        #endregion

        #region Private Fields

        private int _baPersonID;
        private int _baPersonIDSchuldner;
        private int _faLeistungID;
        private bool _ikSummeOk = false;
        private int _kbOpAusgleichID;
        private bool _klibuIntegriert;
        private bool _opSummeOk = false;
        private KiSS4.Gui.KissButton btnAusgleich;
        private KiSS4.Gui.KissButton btnAusgleichAufheben;
        private KiSS4.Gui.KissButton btnCancel;
        private DevExpress.XtraGrid.Columns.GridColumn colAusgleich;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBetreibung;
        private DevExpress.XtraGrid.Columns.GridColumn colBetreibungNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumForderung;
        private DevExpress.XtraGrid.Columns.GridColumn colForderung;
        private DevExpress.XtraGrid.Columns.GridColumn colGlaeubiger;
        private DevExpress.XtraGrid.Columns.GridColumn colHaben;
        private DevExpress.XtraGrid.Columns.GridColumn colIkAusgleich;
        private DevExpress.XtraGrid.Columns.GridColumn colIkBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colIkRestbetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colIkTeilbetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colOffen;
        private DevExpress.XtraGrid.Columns.GridColumn colTeilbetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungseingangAusgeglichen;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungseingangBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungseingangDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungseingangDebitor;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungseingangKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungseingangKonto;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungseingangSAR;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissDateEdit dateVerbuchung;
        private KiSS4.Gui.KissCalcEdit edtBelegNr;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissTextEdit edtBuchungstext;
        private KiSS4.Gui.KissDateEdit edtEingang;
        private KiSS4.Gui.KissTextEdit edtFilterSAR;
        private KiSS4.Gui.KissLookUpEdit edtForderungsart;
        private KiSS4.Gui.KissCalcEdit edtIkRestbetrag;
        private KiSS4.Gui.KissCalcEdit edtOpRestbetrag;
        private KiSS4.Gui.KissGrid grdAusgleichOp;
        private KiSS4.Gui.KissGrid grdIkAusgleich;
        private KiSS4.Gui.KissGrid grdZahlungseingang;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private KiSS4.Gui.KissGroupBox groupBox1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBetreibung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvForderung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZahlungseingang;
        private Hashtable htTeilbetrag = new Hashtable();
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissTextEdit kissTextEdit2;
        private KiSS4.Gui.KissTextEdit kissTextEdit3;
        private KiSS4.Gui.KissLabel lblBelegNr;
        private KiSS4.Gui.KissLabel lblBemerkungenAZF;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBuchungstext;
        private KiSS4.Gui.KissLabel lblEingang;
        private KiSS4.Gui.KissLabel lblForderungsart;
        private KiSS4.Gui.KissLabel lblIkRestbetrag;
        private KiSS4.Gui.KissLabel lblRestbetrag;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblVerbuchung;
        private System.Windows.Forms.Panel panBetreibung;
        private System.Windows.Forms.Panel panEingang;
        private System.Windows.Forms.Panel panForderung;
        private System.Windows.Forms.Panel panZahlung;
        private KiSS4.DB.SqlQuery qryIkAusgleich;
        private KiSS4.DB.SqlQuery qryIkForderungBetrag;
        private KiSS4.DB.SqlQuery qryKbZahlungseingang;
        private KiSS4.DB.SqlQuery qryOpAusgleich;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit6;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private KiSS4.Gui.KissTabControlEx tabEingangZahlung;
        private KiSS4.Gui.KissTabControlEx tabVerteilung;
        private SharpLibrary.WinControls.TabPageEx tpgEingang;
        private SharpLibrary.WinControls.TabPageEx tpgVerteilungBetreibungen;
        private SharpLibrary.WinControls.TabPageEx tpgVerteilungForderungen;
        private SharpLibrary.WinControls.TabPageEx tpgZahlungen;

        #endregion

        #endregion

        #region Constructors

        public DlgZahlungenErfassen(int baPersonID, int faLeistungID)
            : this(baPersonID, faLeistungID, 0)
        {
        }

        public DlgZahlungenErfassen(int baPersonID, int faLeistungID, int kbOpAusgleichID)
            : this()
        {
            _baPersonID = baPersonID;
            _faLeistungID = faLeistungID;
            _kbOpAusgleichID = kbOpAusgleichID;

            _baPersonIDSchuldner = Utils.ConvertToInt(DBUtil.ExecuteScalarSQL(@"
                SELECT BaPersonID
                FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                WHERE FaLeistungID = {0}",
                _faLeistungID));
        }

        public DlgZahlungenErfassen()
        {
            this.InitializeComponent();

            string klibuConfig = (string)DBUtil.GetConfigValue(@"System\KliBu\KliBuSys", null);

            if (!string.IsNullOrEmpty(klibuConfig) && klibuConfig.ToUpper() == "INTEGRIERT")
            {
                _klibuIntegriert = true;
            }
            else
            {
                _klibuIntegriert = false;
            }
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgZahlungenErfassen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtEingang = new KiSS4.Gui.KissDateEdit();
            this.qryKbZahlungseingang = new KiSS4.DB.SqlQuery(this.components);
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.groupBox1 = new KiSS4.Gui.KissGroupBox();
            this.edtFilterSAR = new KiSS4.Gui.KissTextEdit();
            this.lblForderungsart = new KiSS4.Gui.KissLabel();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.edtForderungsart = new KiSS4.Gui.KissLookUpEdit();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.dateVerbuchung = new KiSS4.Gui.KissDateEdit();
            this.lblEingang = new KiSS4.Gui.KissLabel();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.lblVerbuchung = new KiSS4.Gui.KissLabel();
            this.tabEingangZahlung = new KiSS4.Gui.KissTabControlEx();
            this.tpgZahlungen = new SharpLibrary.WinControls.TabPageEx();
            this.panZahlung = new System.Windows.Forms.Panel();
            this.btnAusgleichAufheben = new KiSS4.Gui.KissButton();
            this.btnAusgleich = new KiSS4.Gui.KissButton();
            this.tabVerteilung = new KiSS4.Gui.KissTabControlEx();
            this.tpgVerteilungBetreibungen = new SharpLibrary.WinControls.TabPageEx();
            this.panBetreibung = new System.Windows.Forms.Panel();
            this.edtIkRestbetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblIkRestbetrag = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissTextEdit3 = new KiSS4.Gui.KissTextEdit();
            this.grdIkAusgleich = new KiSS4.Gui.KissGrid();
            this.qryIkAusgleich = new KiSS4.DB.SqlQuery(this.components);
            this.grvBetreibung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetreibungNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetreibung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkRestbetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkAusgleich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colIkTeilbetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tpgVerteilungForderungen = new SharpLibrary.WinControls.TabPageEx();
            this.panForderung = new System.Windows.Forms.Panel();
            this.edtOpRestbetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblRestbetrag = new KiSS4.Gui.KissLabel();
            this.lblBemerkungenAZF = new KiSS4.Gui.KissLabel();
            this.kissTextEdit2 = new KiSS4.Gui.KissTextEdit();
            this.grdAusgleichOp = new KiSS4.Gui.KissGrid();
            this.qryOpAusgleich = new KiSS4.DB.SqlQuery(this.components);
            this.grvForderung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumForderung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlaeubiger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForderung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOffen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusgleich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colTeilbetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tpgEingang = new SharpLibrary.WinControls.TabPageEx();
            this.panEingang = new System.Windows.Forms.Panel();
            this.grdZahlungseingang = new KiSS4.Gui.KissGrid();
            this.grvZahlungseingang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colZahlungseingangDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungseingangKonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungseingangKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungseingangDebitor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungseingangBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungseingangAusgeglichen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungseingangSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblBelegNr = new KiSS4.Gui.KissLabel();
            this.edtBelegNr = new KiSS4.Gui.KissCalcEdit();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryIkForderungBetrag = new KiSS4.DB.SqlQuery(this.components);
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEingang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbZahlungseingang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblForderungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateVerbuchung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEingang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerbuchung)).BeginInit();
            this.tabEingangZahlung.SuspendLayout();
            this.tpgZahlungen.SuspendLayout();
            this.panZahlung.SuspendLayout();
            this.tabVerteilung.SuspendLayout();
            this.tpgVerteilungBetreibungen.SuspendLayout();
            this.panBetreibung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRestbetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkRestbetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIkAusgleich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkAusgleich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBetreibung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            this.tpgVerteilungForderungen.SuspendLayout();
            this.panForderung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtOpRestbetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRestbetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungenAZF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAusgleichOp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryOpAusgleich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvForderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.tpgEingang.SuspendLayout();
            this.panEingang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdZahlungseingang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZahlungseingang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkForderungBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // edtEingang
            // 
            this.edtEingang.DataMember = "Datum";
            this.edtEingang.DataSource = this.qryKbZahlungseingang;
            this.edtEingang.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEingang.EditValue = null;
            this.edtEingang.Location = new System.Drawing.Point(88, 8);
            this.edtEingang.Name = "edtEingang";
            this.edtEingang.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEingang.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEingang.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEingang.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEingang.Properties.Appearance.Options.UseBackColor = true;
            this.edtEingang.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEingang.Properties.Appearance.Options.UseFont = true;
            this.edtEingang.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtEingang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEingang.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtEingang.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEingang.Properties.Name = "dateEingang.Properties";
            this.edtEingang.Properties.ReadOnly = true;
            this.edtEingang.Properties.ShowToday = false;
            this.edtEingang.Size = new System.Drawing.Size(96, 24);
            this.edtEingang.TabIndex = 0;
            // 
            // qryKbZahlungseingang
            // 
            this.qryKbZahlungseingang.CanUpdate = true;
            this.qryKbZahlungseingang.HostControl = this;
            this.qryKbZahlungseingang.SelectStatement = resources.GetString("qryKbZahlungseingang.SelectStatement");
            this.qryKbZahlungseingang.TableName = "KbZahlungseingang";
            this.qryKbZahlungseingang.PositionChanged += new System.EventHandler(this.qryKbZahlungseingang_PositionChanged);
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryKbZahlungseingang;
            this.edtBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetrag.Location = new System.Drawing.Point(88, 38);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.Appearance.Options.UseTextOptions = true;
            this.edtBetrag.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.Mask.EditMask = "N2";
            this.edtBetrag.Properties.Name = "calcBetrag.Properties";
            this.edtBetrag.Properties.ReadOnly = true;
            this.edtBetrag.Size = new System.Drawing.Size(96, 24);
            this.edtBetrag.TabIndex = 1;
            // 
            // edtBuchungstext
            // 
            this.edtBuchungstext.Location = new System.Drawing.Point(88, 68);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Size = new System.Drawing.Size(319, 24);
            this.edtBuchungstext.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edtFilterSAR);
            this.groupBox1.Controls.Add(this.lblForderungsart);
            this.groupBox1.Controls.Add(this.lblSAR);
            this.groupBox1.Controls.Add(this.edtForderungsart);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox1.Location = new System.Drawing.Point(431, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 84);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // edtFilterSAR
            // 
            this.edtFilterSAR.Location = new System.Drawing.Point(88, 20);
            this.edtFilterSAR.Name = "edtFilterSAR";
            this.edtFilterSAR.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilterSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilterSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilterSAR.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilterSAR.Properties.Appearance.Options.UseFont = true;
            this.edtFilterSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilterSAR.Size = new System.Drawing.Size(219, 24);
            this.edtFilterSAR.TabIndex = 28;
            this.edtFilterSAR.EditValueChanged += new System.EventHandler(this.edtFilterSAR_EditValueChanged);
            // 
            // lblForderungsart
            // 
            this.lblForderungsart.Location = new System.Drawing.Point(6, 50);
            this.lblForderungsart.Name = "lblForderungsart";
            this.lblForderungsart.Size = new System.Drawing.Size(76, 24);
            this.lblForderungsart.TabIndex = 27;
            this.lblForderungsart.Text = "Forderungsart";
            this.lblForderungsart.UseCompatibleTextRendering = true;
            this.lblForderungsart.Visible = false;
            // 
            // lblSAR
            // 
            this.lblSAR.Location = new System.Drawing.Point(6, 20);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(64, 24);
            this.lblSAR.TabIndex = 25;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            // 
            // edtForderungsart
            // 
            this.edtForderungsart.Location = new System.Drawing.Point(88, 50);
            this.edtForderungsart.Name = "edtForderungsart";
            this.edtForderungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtForderungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtForderungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtForderungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtForderungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtForderungsart.Properties.Appearance.Options.UseFont = true;
            this.edtForderungsart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtForderungsart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtForderungsart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtForderungsart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtForderungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtForderungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtForderungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtForderungsart.Properties.NullText = "";
            this.edtForderungsart.Properties.ShowFooter = false;
            this.edtForderungsart.Properties.ShowHeader = false;
            this.edtForderungsart.Size = new System.Drawing.Size(219, 24);
            this.edtForderungsart.TabIndex = 1;
            this.edtForderungsart.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(768, 521);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Schliessen";
            this.btnCancel.UseCompatibleTextRendering = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // dateVerbuchung
            // 
            this.dateVerbuchung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.dateVerbuchung.EditValue = null;
            this.dateVerbuchung.Location = new System.Drawing.Point(310, 8);
            this.dateVerbuchung.Name = "dateVerbuchung";
            this.dateVerbuchung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateVerbuchung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dateVerbuchung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dateVerbuchung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dateVerbuchung.Properties.Appearance.Options.UseBackColor = true;
            this.dateVerbuchung.Properties.Appearance.Options.UseBorderColor = true;
            this.dateVerbuchung.Properties.Appearance.Options.UseFont = true;
            this.dateVerbuchung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.dateVerbuchung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dateVerbuchung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.dateVerbuchung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dateVerbuchung.Properties.Name = "dateVerbuchung.Properties";
            this.dateVerbuchung.Properties.ReadOnly = true;
            this.dateVerbuchung.Properties.ShowToday = false;
            this.dateVerbuchung.Size = new System.Drawing.Size(96, 24);
            this.dateVerbuchung.TabIndex = 7;
            // 
            // lblEingang
            // 
            this.lblEingang.Location = new System.Drawing.Point(8, 8);
            this.lblEingang.Name = "lblEingang";
            this.lblEingang.Size = new System.Drawing.Size(80, 24);
            this.lblEingang.TabIndex = 9;
            this.lblEingang.Text = "Eingang";
            this.lblEingang.UseCompatibleTextRendering = true;
            // 
            // lblBetrag
            // 
            this.lblBetrag.Location = new System.Drawing.Point(8, 38);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(80, 24);
            this.lblBetrag.TabIndex = 10;
            this.lblBetrag.Text = "Betrag";
            this.lblBetrag.UseCompatibleTextRendering = true;
            // 
            // lblBuchungstext
            // 
            this.lblBuchungstext.Location = new System.Drawing.Point(8, 65);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(80, 24);
            this.lblBuchungstext.TabIndex = 11;
            this.lblBuchungstext.Text = "Buchungstext";
            this.lblBuchungstext.UseCompatibleTextRendering = true;
            // 
            // lblVerbuchung
            // 
            this.lblVerbuchung.Location = new System.Drawing.Point(238, 8);
            this.lblVerbuchung.Name = "lblVerbuchung";
            this.lblVerbuchung.Size = new System.Drawing.Size(72, 24);
            this.lblVerbuchung.TabIndex = 12;
            this.lblVerbuchung.Text = "Verbuchung";
            this.lblVerbuchung.UseCompatibleTextRendering = true;
            // 
            // tabEingangZahlung
            // 
            this.tabEingangZahlung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEingangZahlung.Controls.Add(this.tpgZahlungen);
            this.tabEingangZahlung.Controls.Add(this.tpgEingang);
            this.tabEingangZahlung.Location = new System.Drawing.Point(8, 98);
            this.tabEingangZahlung.Name = "tabEingangZahlung";
            this.tabEingangZahlung.SelectedTabIndex = 1;
            this.tabEingangZahlung.ShowFixedWidthTooltip = true;
            this.tabEingangZahlung.Size = new System.Drawing.Size(880, 417);
            this.tabEingangZahlung.TabIndex = 14;
            this.tabEingangZahlung.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgEingang,
            this.tpgZahlungen});
            this.tabEingangZahlung.TabsLineColor = System.Drawing.Color.Black;
            this.tabEingangZahlung.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabEingangZahlung.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            // 
            // tpgZahlungen
            // 
            this.tpgZahlungen.Controls.Add(this.panZahlung);
            this.tpgZahlungen.Location = new System.Drawing.Point(6, 32);
            this.tpgZahlungen.Name = "tpgZahlungen";
            this.tpgZahlungen.Size = new System.Drawing.Size(868, 379);
            this.tpgZahlungen.TabIndex = 1;
            this.tpgZahlungen.Title = "Zahlungen";
            // 
            // panZahlung
            // 
            this.panZahlung.Controls.Add(this.btnAusgleichAufheben);
            this.panZahlung.Controls.Add(this.btnAusgleich);
            this.panZahlung.Controls.Add(this.tabVerteilung);
            this.panZahlung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panZahlung.Location = new System.Drawing.Point(0, 0);
            this.panZahlung.Name = "panZahlung";
            this.panZahlung.Size = new System.Drawing.Size(868, 379);
            this.panZahlung.TabIndex = 0;
            // 
            // btnAusgleichAufheben
            // 
            this.btnAusgleichAufheben.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAusgleichAufheben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAusgleichAufheben.Location = new System.Drawing.Point(587, 350);
            this.btnAusgleichAufheben.Name = "btnAusgleichAufheben";
            this.btnAusgleichAufheben.Size = new System.Drawing.Size(136, 24);
            this.btnAusgleichAufheben.TabIndex = 13;
            this.btnAusgleichAufheben.Text = "Ausgleich aufheben";
            this.btnAusgleichAufheben.UseCompatibleTextRendering = true;
            this.btnAusgleichAufheben.UseVisualStyleBackColor = false;
            this.btnAusgleichAufheben.Click += new System.EventHandler(this.btnAusgleichAufheben_Click);
            // 
            // btnAusgleich
            // 
            this.btnAusgleich.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAusgleich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAusgleich.Location = new System.Drawing.Point(729, 350);
            this.btnAusgleich.Name = "btnAusgleich";
            this.btnAusgleich.Size = new System.Drawing.Size(136, 24);
            this.btnAusgleich.TabIndex = 12;
            this.btnAusgleich.Text = "Ausgleich speichern";
            this.btnAusgleich.UseCompatibleTextRendering = true;
            this.btnAusgleich.UseVisualStyleBackColor = false;
            this.btnAusgleich.Click += new System.EventHandler(this.btnAusgleich_Click);
            // 
            // tabVerteilung
            // 
            this.tabVerteilung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabVerteilung.Controls.Add(this.tpgVerteilungBetreibungen);
            this.tabVerteilung.Controls.Add(this.tpgVerteilungForderungen);
            this.tabVerteilung.Location = new System.Drawing.Point(0, 3);
            this.tabVerteilung.Name = "tabVerteilung";
            this.tabVerteilung.ShowFixedWidthTooltip = true;
            this.tabVerteilung.Size = new System.Drawing.Size(866, 344);
            this.tabVerteilung.TabIndex = 5;
            this.tabVerteilung.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgVerteilungForderungen,
            this.tpgVerteilungBetreibungen});
            this.tabVerteilung.TabsLineColor = System.Drawing.Color.Black;
            this.tabVerteilung.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabVerteilung.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            // 
            // tpgVerteilungBetreibungen
            // 
            this.tpgVerteilungBetreibungen.Controls.Add(this.panBetreibung);
            this.tpgVerteilungBetreibungen.Location = new System.Drawing.Point(6, 32);
            this.tpgVerteilungBetreibungen.Name = "tpgVerteilungBetreibungen";
            this.tpgVerteilungBetreibungen.Size = new System.Drawing.Size(854, 306);
            this.tpgVerteilungBetreibungen.TabIndex = 1;
            this.tpgVerteilungBetreibungen.Title = "Verteilung auf Betreibungen";
            // 
            // panBetreibung
            // 
            this.panBetreibung.Controls.Add(this.edtIkRestbetrag);
            this.panBetreibung.Controls.Add(this.lblIkRestbetrag);
            this.panBetreibung.Controls.Add(this.kissLabel1);
            this.panBetreibung.Controls.Add(this.kissTextEdit3);
            this.panBetreibung.Controls.Add(this.grdIkAusgleich);
            this.panBetreibung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBetreibung.Location = new System.Drawing.Point(0, 0);
            this.panBetreibung.Name = "panBetreibung";
            this.panBetreibung.Size = new System.Drawing.Size(854, 306);
            this.panBetreibung.TabIndex = 0;
            // 
            // edtIkRestbetrag
            // 
            this.edtIkRestbetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtIkRestbetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtIkRestbetrag.Location = new System.Drawing.Point(768, 279);
            this.edtIkRestbetrag.Name = "edtIkRestbetrag";
            this.edtIkRestbetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIkRestbetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtIkRestbetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkRestbetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkRestbetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkRestbetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkRestbetrag.Properties.Appearance.Options.UseFont = true;
            this.edtIkRestbetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIkRestbetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkRestbetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtIkRestbetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtIkRestbetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtIkRestbetrag.Properties.ReadOnly = true;
            this.edtIkRestbetrag.Size = new System.Drawing.Size(78, 24);
            this.edtIkRestbetrag.TabIndex = 296;
            // 
            // lblIkRestbetrag
            // 
            this.lblIkRestbetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIkRestbetrag.Location = new System.Drawing.Point(690, 278);
            this.lblIkRestbetrag.Name = "lblIkRestbetrag";
            this.lblIkRestbetrag.Size = new System.Drawing.Size(72, 24);
            this.lblIkRestbetrag.TabIndex = 295;
            this.lblIkRestbetrag.Text = "Restbetrag";
            this.lblIkRestbetrag.UseCompatibleTextRendering = true;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel1.Location = new System.Drawing.Point(2, 277);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(72, 24);
            this.kissLabel1.TabIndex = 294;
            this.kissLabel1.Text = "Bemerkungen";
            this.kissLabel1.UseCompatibleTextRendering = true;
            this.kissLabel1.Visible = false;
            // 
            // kissTextEdit3
            // 
            this.kissTextEdit3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit3.Location = new System.Drawing.Point(80, 279);
            this.kissTextEdit3.Name = "kissTextEdit3";
            this.kissTextEdit3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissTextEdit3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit3.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit3.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit3.Size = new System.Drawing.Size(434, 24);
            this.kissTextEdit3.TabIndex = 1;
            this.kissTextEdit3.Visible = false;
            // 
            // grdIkAusgleich
            // 
            this.grdIkAusgleich.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdIkAusgleich.DataSource = this.qryIkAusgleich;
            // 
            // 
            // 
            this.grdIkAusgleich.EmbeddedNavigator.Name = "";
            this.grdIkAusgleich.Location = new System.Drawing.Point(5, 8);
            this.grdIkAusgleich.MainView = this.grvBetreibung;
            this.grdIkAusgleich.Name = "grdIkAusgleich";
            this.grdIkAusgleich.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit5,
            this.repositoryItemTextEdit2});
            this.grdIkAusgleich.Size = new System.Drawing.Size(841, 265);
            this.grdIkAusgleich.TabIndex = 0;
            this.grdIkAusgleich.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBetreibung});
            // 
            // qryIkAusgleich
            // 
            this.qryIkAusgleich.BatchUpdate = true;
            this.qryIkAusgleich.CanDelete = true;
            this.qryIkAusgleich.CanInsert = true;
            this.qryIkAusgleich.CanUpdate = true;
            this.qryIkAusgleich.HostControl = this;
            this.qryIkAusgleich.PositionChanged += new System.EventHandler(this.qryIkAusgleich_PositionChanged);
            // 
            // grvBetreibung
            // 
            this.grvBetreibung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBetreibung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetreibung.Appearance.Empty.Options.UseBackColor = true;
            this.grvBetreibung.Appearance.Empty.Options.UseFont = true;
            this.grvBetreibung.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvBetreibung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetreibung.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvBetreibung.Appearance.EvenRow.Options.UseFont = true;
            this.grvBetreibung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetreibung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvBetreibung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetreibung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvBetreibung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBetreibung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBetreibung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBetreibung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetreibung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBetreibung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBetreibung.Appearance.GroupRow.Options.UseFont = true;
            this.grvBetreibung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBetreibung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBetreibung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBetreibung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetreibung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBetreibung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBetreibung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBetreibung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetreibung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBetreibung.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvBetreibung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBetreibung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetreibung.Appearance.OddRow.Options.UseFont = true;
            this.grvBetreibung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetreibung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBetreibung.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvBetreibung.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvBetreibung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBetreibung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBetreibung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colBetreibungNummer,
            this.colBetreibung,
            this.colIkBetrag,
            this.colIkRestbetrag,
            this.colIkAusgleich,
            this.colIkTeilbetrag});
            this.grvBetreibung.GridControl = this.grdIkAusgleich;
            this.grvBetreibung.Name = "grvBetreibung";
            this.grvBetreibung.OptionsCustomization.AllowFilter = false;
            this.grvBetreibung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBetreibung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBetreibung.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvBetreibung.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvBetreibung.OptionsSelection.UseIndicatorForSelection = false;
            this.grvBetreibung.OptionsView.ColumnAutoWidth = false;
            this.grvBetreibung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBetreibung.OptionsView.ShowGroupPanel = false;
            this.grvBetreibung.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridColumn1.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn1.Caption = "Datum";
            this.gridColumn1.FieldName = "BetreibungAm";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // colBetreibungNummer
            // 
            this.colBetreibungNummer.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBetreibungNummer.AppearanceCell.Options.UseBackColor = true;
            this.colBetreibungNummer.Caption = "Nummer";
            this.colBetreibungNummer.FieldName = "Nummer";
            this.colBetreibungNummer.Name = "colBetreibungNummer";
            this.colBetreibungNummer.OptionsColumn.AllowEdit = false;
            this.colBetreibungNummer.Visible = true;
            this.colBetreibungNummer.VisibleIndex = 1;
            this.colBetreibungNummer.Width = 123;
            // 
            // colBetreibung
            // 
            this.colBetreibung.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBetreibung.AppearanceCell.Options.UseBackColor = true;
            this.colBetreibung.Caption = "Betreibung";
            this.colBetreibung.FieldName = "Betreibung";
            this.colBetreibung.Name = "colBetreibung";
            this.colBetreibung.OptionsColumn.AllowEdit = false;
            this.colBetreibung.Visible = true;
            this.colBetreibung.VisibleIndex = 2;
            this.colBetreibung.Width = 275;
            // 
            // colIkBetrag
            // 
            this.colIkBetrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colIkBetrag.AppearanceCell.Options.UseBackColor = true;
            this.colIkBetrag.Caption = "Betrag";
            this.colIkBetrag.DisplayFormat.FormatString = "n2";
            this.colIkBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIkBetrag.FieldName = "Betrag";
            this.colIkBetrag.Name = "colIkBetrag";
            this.colIkBetrag.OptionsColumn.AllowEdit = false;
            this.colIkBetrag.Visible = true;
            this.colIkBetrag.VisibleIndex = 3;
            this.colIkBetrag.Width = 70;
            // 
            // colIkRestbetrag
            // 
            this.colIkRestbetrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colIkRestbetrag.AppearanceCell.Options.UseBackColor = true;
            this.colIkRestbetrag.Caption = "Offen";
            this.colIkRestbetrag.DisplayFormat.FormatString = "n2";
            this.colIkRestbetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIkRestbetrag.FieldName = "RestBetrag";
            this.colIkRestbetrag.Name = "colIkRestbetrag";
            this.colIkRestbetrag.OptionsColumn.AllowEdit = false;
            this.colIkRestbetrag.Visible = true;
            this.colIkRestbetrag.VisibleIndex = 4;
            this.colIkRestbetrag.Width = 70;
            // 
            // colIkAusgleich
            // 
            this.colIkAusgleich.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colIkAusgleich.AppearanceCell.Options.UseBackColor = true;
            this.colIkAusgleich.ColumnEdit = this.repositoryItemButtonEdit5;
            this.colIkAusgleich.Name = "colIkAusgleich";
            this.colIkAusgleich.Visible = true;
            this.colIkAusgleich.VisibleIndex = 5;
            this.colIkAusgleich.Width = 23;
            // 
            // repositoryItemButtonEdit5
            // 
            this.repositoryItemButtonEdit5.AutoHeight = false;
            this.repositoryItemButtonEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right)});
            this.repositoryItemButtonEdit5.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.repositoryItemButtonEdit5.Name = "repositoryItemButtonEdit5";
            this.repositoryItemButtonEdit5.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // colIkTeilbetrag
            // 
            this.colIkTeilbetrag.Caption = "Ausgl.Betr.";
            this.colIkTeilbetrag.ColumnEdit = this.repositoryItemTextEdit2;
            this.colIkTeilbetrag.DisplayFormat.FormatString = "n2";
            this.colIkTeilbetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIkTeilbetrag.FieldName = "AusglBetrag";
            this.colIkTeilbetrag.Name = "colIkTeilbetrag";
            this.colIkTeilbetrag.Visible = true;
            this.colIkTeilbetrag.VisibleIndex = 6;
            this.colIkTeilbetrag.Width = 74;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // tpgVerteilungForderungen
            // 
            this.tpgVerteilungForderungen.Controls.Add(this.panForderung);
            this.tpgVerteilungForderungen.Location = new System.Drawing.Point(6, 32);
            this.tpgVerteilungForderungen.Name = "tpgVerteilungForderungen";
            this.tpgVerteilungForderungen.Size = new System.Drawing.Size(854, 306);
            this.tpgVerteilungForderungen.TabIndex = 0;
            this.tpgVerteilungForderungen.Title = "Verteilung auf Forderungen";
            // 
            // panForderung
            // 
            this.panForderung.Controls.Add(this.edtOpRestbetrag);
            this.panForderung.Controls.Add(this.lblRestbetrag);
            this.panForderung.Controls.Add(this.lblBemerkungenAZF);
            this.panForderung.Controls.Add(this.kissTextEdit2);
            this.panForderung.Controls.Add(this.grdAusgleichOp);
            this.panForderung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panForderung.Location = new System.Drawing.Point(0, 0);
            this.panForderung.Name = "panForderung";
            this.panForderung.Size = new System.Drawing.Size(854, 306);
            this.panForderung.TabIndex = 0;
            // 
            // edtOpRestbetrag
            // 
            this.edtOpRestbetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtOpRestbetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtOpRestbetrag.Location = new System.Drawing.Point(768, 279);
            this.edtOpRestbetrag.Name = "edtOpRestbetrag";
            this.edtOpRestbetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtOpRestbetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtOpRestbetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOpRestbetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOpRestbetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtOpRestbetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOpRestbetrag.Properties.Appearance.Options.UseFont = true;
            this.edtOpRestbetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOpRestbetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtOpRestbetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtOpRestbetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtOpRestbetrag.Properties.EditFormat.FormatString = "N2";
            this.edtOpRestbetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtOpRestbetrag.Properties.Mask.EditMask = "N2";
            this.edtOpRestbetrag.Properties.ReadOnly = true;
            this.edtOpRestbetrag.Size = new System.Drawing.Size(78, 24);
            this.edtOpRestbetrag.TabIndex = 11;
            // 
            // lblRestbetrag
            // 
            this.lblRestbetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRestbetrag.Location = new System.Drawing.Point(690, 278);
            this.lblRestbetrag.Name = "lblRestbetrag";
            this.lblRestbetrag.Size = new System.Drawing.Size(72, 24);
            this.lblRestbetrag.TabIndex = 10;
            this.lblRestbetrag.Text = "Restbetrag";
            this.lblRestbetrag.UseCompatibleTextRendering = true;
            // 
            // lblBemerkungenAZF
            // 
            this.lblBemerkungenAZF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkungenAZF.Location = new System.Drawing.Point(2, 277);
            this.lblBemerkungenAZF.Name = "lblBemerkungenAZF";
            this.lblBemerkungenAZF.Size = new System.Drawing.Size(72, 24);
            this.lblBemerkungenAZF.TabIndex = 10;
            this.lblBemerkungenAZF.Text = "Bemerkungen";
            this.lblBemerkungenAZF.UseCompatibleTextRendering = true;
            this.lblBemerkungenAZF.Visible = false;
            // 
            // kissTextEdit2
            // 
            this.kissTextEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit2.Location = new System.Drawing.Point(80, 279);
            this.kissTextEdit2.Name = "kissTextEdit2";
            this.kissTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissTextEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit2.Size = new System.Drawing.Size(434, 24);
            this.kissTextEdit2.TabIndex = 1;
            this.kissTextEdit2.Visible = false;
            // 
            // grdAusgleichOp
            // 
            this.grdAusgleichOp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAusgleichOp.DataSource = this.qryOpAusgleich;
            // 
            // 
            // 
            this.grdAusgleichOp.EmbeddedNavigator.Name = "";
            this.grdAusgleichOp.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdAusgleichOp.Location = new System.Drawing.Point(5, 8);
            this.grdAusgleichOp.MainView = this.grvForderung;
            this.grdAusgleichOp.Name = "grdAusgleichOp";
            this.grdAusgleichOp.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit6,
            this.repositoryItemTextEdit1});
            this.grdAusgleichOp.Size = new System.Drawing.Size(841, 265);
            this.grdAusgleichOp.TabIndex = 0;
            this.grdAusgleichOp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvForderung});
            // 
            // qryOpAusgleich
            // 
            this.qryOpAusgleich.BatchUpdate = true;
            this.qryOpAusgleich.CanDelete = true;
            this.qryOpAusgleich.CanInsert = true;
            this.qryOpAusgleich.CanUpdate = true;
            this.qryOpAusgleich.HostControl = this;
            this.qryOpAusgleich.PositionChanged += new System.EventHandler(this.qryOpAusgleich_PositionChanged);
            // 
            // grvForderung
            // 
            this.grvForderung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvForderung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvForderung.Appearance.Empty.Options.UseBackColor = true;
            this.grvForderung.Appearance.Empty.Options.UseFont = true;
            this.grvForderung.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvForderung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvForderung.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvForderung.Appearance.EvenRow.Options.UseFont = true;
            this.grvForderung.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvForderung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvForderung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvForderung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvForderung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvForderung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvForderung.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvForderung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvForderung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvForderung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvForderung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvForderung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvForderung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvForderung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvForderung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvForderung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvForderung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvForderung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvForderung.Appearance.GroupRow.Options.UseFont = true;
            this.grvForderung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvForderung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvForderung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvForderung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvForderung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvForderung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvForderung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvForderung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvForderung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvForderung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvForderung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvForderung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvForderung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvForderung.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvForderung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvForderung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvForderung.Appearance.OddRow.Options.UseFont = true;
            this.grvForderung.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvForderung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvForderung.Appearance.Row.Options.UseBackColor = true;
            this.grvForderung.Appearance.Row.Options.UseFont = true;
            this.grvForderung.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvForderung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvForderung.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvForderung.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvForderung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvForderung.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvForderung.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvForderung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvForderung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvForderung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colDatumForderung,
            this.colHaben,
            this.colGlaeubiger,
            this.colForderung,
            this.colBetrag,
            this.colOffen,
            this.colAusgleich,
            this.colTeilbetrag});
            this.grvForderung.GridControl = this.grdAusgleichOp;
            this.grvForderung.Name = "grvForderung";
            this.grvForderung.OptionsCustomization.AllowFilter = false;
            this.grvForderung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvForderung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvForderung.OptionsView.ColumnAutoWidth = false;
            this.grvForderung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvForderung.OptionsView.ShowGroupPanel = false;
            // 
            // colDatum
            // 
            this.colDatum.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDatum.AppearanceCell.Options.UseBackColor = true;
            this.colDatum.Caption = "Fällig am";
            this.colDatum.FieldName = "Valuta";
            this.colDatum.Name = "colDatum";
            this.colDatum.OptionsColumn.AllowEdit = false;
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            // 
            // colDatumForderung
            // 
            this.colDatumForderung.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDatumForderung.AppearanceCell.Options.UseBackColor = true;
            this.colDatumForderung.Caption = "Datum Forderung";
            this.colDatumForderung.FieldName = "DatumForderung";
            this.colDatumForderung.Name = "colDatumForderung";
            this.colDatumForderung.OptionsColumn.AllowEdit = false;
            this.colDatumForderung.Visible = true;
            this.colDatumForderung.VisibleIndex = 1;
            // 
            // colHaben
            // 
            this.colHaben.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colHaben.AppearanceCell.Options.UseBackColor = true;
            this.colHaben.Caption = "KOA";
            this.colHaben.FieldName = "Haben";
            this.colHaben.Name = "colHaben";
            this.colHaben.OptionsColumn.AllowEdit = false;
            this.colHaben.OptionsColumn.AllowFocus = false;
            this.colHaben.OptionsColumn.ReadOnly = true;
            this.colHaben.Visible = true;
            this.colHaben.VisibleIndex = 2;
            this.colHaben.Width = 53;
            // 
            // colGlaeubiger
            // 
            this.colGlaeubiger.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colGlaeubiger.AppearanceCell.Options.UseBackColor = true;
            this.colGlaeubiger.Caption = "Gläubiger";
            this.colGlaeubiger.FieldName = "Debitor";
            this.colGlaeubiger.Name = "colGlaeubiger";
            this.colGlaeubiger.OptionsColumn.AllowEdit = false;
            this.colGlaeubiger.Visible = true;
            this.colGlaeubiger.VisibleIndex = 3;
            this.colGlaeubiger.Width = 123;
            // 
            // colForderung
            // 
            this.colForderung.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colForderung.AppearanceCell.Options.UseBackColor = true;
            this.colForderung.Caption = "Text";
            this.colForderung.FieldName = "Text";
            this.colForderung.Name = "colForderung";
            this.colForderung.OptionsColumn.AllowEdit = false;
            this.colForderung.Visible = true;
            this.colForderung.VisibleIndex = 4;
            this.colForderung.Width = 224;
            // 
            // colBetrag
            // 
            this.colBetrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBetrag.AppearanceCell.Options.UseBackColor = true;
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 5;
            this.colBetrag.Width = 70;
            // 
            // colOffen
            // 
            this.colOffen.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colOffen.AppearanceCell.Options.UseBackColor = true;
            this.colOffen.Caption = "Offen";
            this.colOffen.DisplayFormat.FormatString = "n2";
            this.colOffen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOffen.FieldName = "RestBetrag";
            this.colOffen.Name = "colOffen";
            this.colOffen.OptionsColumn.AllowEdit = false;
            this.colOffen.Visible = true;
            this.colOffen.VisibleIndex = 6;
            this.colOffen.Width = 70;
            // 
            // colAusgleich
            // 
            this.colAusgleich.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colAusgleich.AppearanceCell.Options.UseBackColor = true;
            this.colAusgleich.ColumnEdit = this.repositoryItemButtonEdit6;
            this.colAusgleich.Name = "colAusgleich";
            this.colAusgleich.Visible = true;
            this.colAusgleich.VisibleIndex = 7;
            this.colAusgleich.Width = 23;
            // 
            // repositoryItemButtonEdit6
            // 
            this.repositoryItemButtonEdit6.AutoHeight = false;
            this.repositoryItemButtonEdit6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right)});
            this.repositoryItemButtonEdit6.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.repositoryItemButtonEdit6.Name = "repositoryItemButtonEdit6";
            this.repositoryItemButtonEdit6.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // colTeilbetrag
            // 
            this.colTeilbetrag.Caption = "Ausgl.Betr.";
            this.colTeilbetrag.ColumnEdit = this.repositoryItemTextEdit1;
            this.colTeilbetrag.DisplayFormat.FormatString = "n2";
            this.colTeilbetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTeilbetrag.FieldName = "AusglBetrag";
            this.colTeilbetrag.Name = "colTeilbetrag";
            this.colTeilbetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colTeilbetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colTeilbetrag.Visible = true;
            this.colTeilbetrag.VisibleIndex = 8;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "N2";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "N2";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // tpgEingang
            // 
            this.tpgEingang.Controls.Add(this.panEingang);
            this.tpgEingang.Location = new System.Drawing.Point(6, 32);
            this.tpgEingang.Name = "tpgEingang";
            this.tpgEingang.Size = new System.Drawing.Size(868, 379);
            this.tpgEingang.TabIndex = 0;
            this.tpgEingang.Title = "Zahlungseingänge";
            // 
            // panEingang
            // 
            this.panEingang.Controls.Add(this.grdZahlungseingang);
            this.panEingang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panEingang.Location = new System.Drawing.Point(0, 0);
            this.panEingang.Name = "panEingang";
            this.panEingang.Size = new System.Drawing.Size(868, 379);
            this.panEingang.TabIndex = 0;
            // 
            // grdZahlungseingang
            // 
            this.grdZahlungseingang.DataSource = this.qryKbZahlungseingang;
            this.grdZahlungseingang.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdZahlungseingang.EmbeddedNavigator.Name = "";
            this.grdZahlungseingang.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZahlungseingang.Location = new System.Drawing.Point(0, 0);
            this.grdZahlungseingang.MainView = this.grvZahlungseingang;
            this.grdZahlungseingang.Name = "grdZahlungseingang";
            this.grdZahlungseingang.Size = new System.Drawing.Size(868, 379);
            this.grdZahlungseingang.TabIndex = 2;
            this.grdZahlungseingang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZahlungseingang});
            // 
            // grvZahlungseingang
            // 
            this.grvZahlungseingang.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZahlungseingang.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.Empty.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.Empty.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.EvenRow.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZahlungseingang.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZahlungseingang.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZahlungseingang.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZahlungseingang.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZahlungseingang.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZahlungseingang.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZahlungseingang.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZahlungseingang.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZahlungseingang.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZahlungseingang.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.GroupRow.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZahlungseingang.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZahlungseingang.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZahlungseingang.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZahlungseingang.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZahlungseingang.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZahlungseingang.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZahlungseingang.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZahlungseingang.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZahlungseingang.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.OddRow.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZahlungseingang.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.Row.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.Row.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZahlungseingang.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZahlungseingang.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZahlungseingang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colZahlungseingangDatum,
            this.colZahlungseingangKonto,
            this.colZahlungseingangKlient,
            this.colZahlungseingangDebitor,
            this.colZahlungseingangBetrag,
            this.colZahlungseingangAusgeglichen,
            this.colZahlungseingangSAR});
            this.grvZahlungseingang.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZahlungseingang.GridControl = this.grdZahlungseingang;
            this.grvZahlungseingang.Name = "grvZahlungseingang";
            this.grvZahlungseingang.OptionsBehavior.Editable = false;
            this.grvZahlungseingang.OptionsCustomization.AllowFilter = false;
            this.grvZahlungseingang.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZahlungseingang.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZahlungseingang.OptionsNavigation.UseTabKey = false;
            this.grvZahlungseingang.OptionsView.ColumnAutoWidth = false;
            this.grvZahlungseingang.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZahlungseingang.OptionsView.ShowGroupPanel = false;
            this.grvZahlungseingang.OptionsView.ShowIndicator = false;
            // 
            // colZahlungseingangDatum
            // 
            this.colZahlungseingangDatum.Caption = "Datum";
            this.colZahlungseingangDatum.FieldName = "Datum";
            this.colZahlungseingangDatum.Name = "colZahlungseingangDatum";
            this.colZahlungseingangDatum.Visible = true;
            this.colZahlungseingangDatum.VisibleIndex = 0;
            // 
            // colZahlungseingangKonto
            // 
            this.colZahlungseingangKonto.Caption = "Konto";
            this.colZahlungseingangKonto.FieldName = "KontoNr";
            this.colZahlungseingangKonto.Name = "colZahlungseingangKonto";
            this.colZahlungseingangKonto.Visible = true;
            this.colZahlungseingangKonto.VisibleIndex = 2;
            this.colZahlungseingangKonto.Width = 108;
            // 
            // colZahlungseingangKlient
            // 
            this.colZahlungseingangKlient.Caption = "Klient";
            this.colZahlungseingangKlient.FieldName = "Klient";
            this.colZahlungseingangKlient.Name = "colZahlungseingangKlient";
            this.colZahlungseingangKlient.Visible = true;
            this.colZahlungseingangKlient.VisibleIndex = 4;
            this.colZahlungseingangKlient.Width = 150;
            // 
            // colZahlungseingangDebitor
            // 
            this.colZahlungseingangDebitor.Caption = "Debitor";
            this.colZahlungseingangDebitor.FieldName = "Debitor";
            this.colZahlungseingangDebitor.Name = "colZahlungseingangDebitor";
            this.colZahlungseingangDebitor.Visible = true;
            this.colZahlungseingangDebitor.VisibleIndex = 3;
            this.colZahlungseingangDebitor.Width = 210;
            // 
            // colZahlungseingangBetrag
            // 
            this.colZahlungseingangBetrag.Caption = "Betrag";
            this.colZahlungseingangBetrag.DisplayFormat.FormatString = "n2";
            this.colZahlungseingangBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colZahlungseingangBetrag.FieldName = "Betrag";
            this.colZahlungseingangBetrag.Name = "colZahlungseingangBetrag";
            this.colZahlungseingangBetrag.Visible = true;
            this.colZahlungseingangBetrag.VisibleIndex = 1;
            this.colZahlungseingangBetrag.Width = 60;
            // 
            // colZahlungseingangAusgeglichen
            // 
            this.colZahlungseingangAusgeglichen.Caption = "ausg.";
            this.colZahlungseingangAusgeglichen.FieldName = "EingangAusgeglichen";
            this.colZahlungseingangAusgeglichen.Name = "colZahlungseingangAusgeglichen";
            this.colZahlungseingangAusgeglichen.Visible = true;
            this.colZahlungseingangAusgeglichen.VisibleIndex = 5;
            this.colZahlungseingangAusgeglichen.Width = 41;
            // 
            // colZahlungseingangSAR
            // 
            this.colZahlungseingangSAR.Caption = "SAR";
            this.colZahlungseingangSAR.FieldName = "SAR";
            this.colZahlungseingangSAR.Name = "colZahlungseingangSAR";
            this.colZahlungseingangSAR.Visible = true;
            this.colZahlungseingangSAR.VisibleIndex = 6;
            this.colZahlungseingangSAR.Width = 120;
            // 
            // lblBelegNr
            // 
            this.lblBelegNr.Location = new System.Drawing.Point(238, 38);
            this.lblBelegNr.Name = "lblBelegNr";
            this.lblBelegNr.Size = new System.Drawing.Size(50, 24);
            this.lblBelegNr.TabIndex = 73;
            this.lblBelegNr.Text = "Beleg-Nr.";
            this.lblBelegNr.UseCompatibleTextRendering = true;
            // 
            // edtBelegNr
            // 
            this.edtBelegNr.DataMember = "BelegNr";
            this.edtBelegNr.DataSource = this.qryKbZahlungseingang;
            this.edtBelegNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBelegNr.Location = new System.Drawing.Point(310, 38);
            this.edtBelegNr.Name = "edtBelegNr";
            this.edtBelegNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBelegNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegNr.Properties.Appearance.Options.UseFont = true;
            this.edtBelegNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBelegNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBelegNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBelegNr.Properties.ReadOnly = true;
            this.edtBelegNr.Size = new System.Drawing.Size(97, 24);
            this.edtBelegNr.TabIndex = 74;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridColumn14.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn14.Caption = "Datum";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 0;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridColumn15.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn15.Caption = "Gläubiger";
            this.gridColumn15.FieldName = "Glaeubiger";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 1;
            this.gridColumn15.Width = 123;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridColumn16.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn16.Caption = "Forderung";
            this.gridColumn16.FieldName = "Forderung";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 2;
            this.gridColumn16.Width = 275;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridColumn17.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn17.Caption = "Betrag";
            this.gridColumn17.FieldName = "Betrag";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 3;
            this.gridColumn17.Width = 70;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridColumn18.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn18.Caption = "Offen";
            this.gridColumn18.FieldName = "offen";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 4;
            this.gridColumn18.Width = 70;
            // 
            // gridColumn19
            // 
            this.gridColumn19.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridColumn19.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn19.ColumnEdit = this.repositoryItemButtonEdit4;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 5;
            this.gridColumn19.Width = 23;
            // 
            // repositoryItemButtonEdit4
            // 
            this.repositoryItemButtonEdit4.AutoHeight = false;
            this.repositoryItemButtonEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right)});
            this.repositoryItemButtonEdit4.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.repositoryItemButtonEdit4.Name = "repositoryItemButtonEdit4";
            this.repositoryItemButtonEdit4.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Teilbetrag";
            this.gridColumn20.FieldName = "Teilbetrag";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 6;
            this.gridColumn20.Width = 70;
            // 
            // gridView4
            // 
            this.gridView4.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView4.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.Empty.Options.UseBackColor = true;
            this.gridView4.Appearance.Empty.Options.UseFont = true;
            this.gridView4.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView4.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView4.Appearance.EvenRow.Options.UseFont = true;
            this.gridView4.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView4.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView4.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView4.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView4.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView4.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView4.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView4.Appearance.GroupRow.Options.UseFont = true;
            this.gridView4.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView4.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView4.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView4.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView4.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView4.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView4.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView4.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gridView4.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView4.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.OddRow.Options.UseFont = true;
            this.gridView4.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView4.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.gridView4.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20});
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsCustomization.AllowFilter = false;
            this.gridView4.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView4.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView4.OptionsSelection.UseIndicatorForSelection = false;
            this.gridView4.OptionsView.ColumnAutoWidth = false;
            this.gridView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowIndicator = false;
            // 
            // qryIkForderungBetrag
            // 
            this.qryIkForderungBetrag.BatchUpdate = true;
            this.qryIkForderungBetrag.CanUpdate = true;
            this.qryIkForderungBetrag.HostControl = this;
            this.qryIkForderungBetrag.SelectStatement = resources.GetString("qryIkForderungBetrag.SelectStatement");
            this.qryIkForderungBetrag.TableName = "IkForderung";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right)});
            this.repositoryItemButtonEdit1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right)});
            this.repositoryItemButtonEdit2.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // DlgZahlungenErfassen
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(894, 548);
            this.Controls.Add(this.edtBelegNr);
            this.Controls.Add(this.lblBelegNr);
            this.Controls.Add(this.tabEingangZahlung);
            this.Controls.Add(this.lblVerbuchung);
            this.Controls.Add(this.lblBuchungstext);
            this.Controls.Add(this.lblBetrag);
            this.Controls.Add(this.lblEingang);
            this.Controls.Add(this.dateVerbuchung);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.edtBuchungstext);
            this.Controls.Add(this.edtBetrag);
            this.Controls.Add(this.edtEingang);
            this.Name = "DlgZahlungenErfassen";
            this.Text = "Zahlung erfassen";
            this.Load += new System.EventHandler(this.DlgZahlungenErfassen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edtEingang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbZahlungseingang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblForderungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateVerbuchung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEingang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerbuchung)).EndInit();
            this.tabEingangZahlung.ResumeLayout(false);
            this.tpgZahlungen.ResumeLayout(false);
            this.panZahlung.ResumeLayout(false);
            this.tabVerteilung.ResumeLayout(false);
            this.tpgVerteilungBetreibungen.ResumeLayout(false);
            this.panBetreibung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRestbetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkRestbetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIkAusgleich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkAusgleich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBetreibung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            this.tpgVerteilungForderungen.ResumeLayout(false);
            this.panForderung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtOpRestbetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRestbetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungenAZF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAusgleichOp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryOpAusgleich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvForderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.tpgEingang.ResumeLayout(false);
            this.panEingang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdZahlungseingang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZahlungseingang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkForderungBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
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

        private void DlgZahlungenErfassen_Load(object sender, System.EventArgs e)
        {
            repositoryItemTextEdit1.EditValueChanging += opAusgleichBetrag_EditValueChanging;
            repositoryItemButtonEdit6.Click += opBetragUebernehmen_ButtonClick;

            repositoryItemTextEdit2.EditValueChanging += ikAusgleichBetrag_EditValueChanging;
            repositoryItemButtonEdit5.Click += ikBetragUebernehmen_ButtonClick;

            tabEingangZahlung.SelectedTabIndex = tpgEingang.TabIndex;

            btnAusgleichAufheben.Location = btnAusgleich.Location;

            FillQryZahlungseingang();
        }

        private void btnAusgleichAufheben_Click(object sender, System.EventArgs e)
        {
            if (!KissMsg.ShowQuestion("Soll die Buchung des Zahlungseingangs und deren Ausgleichsinformationen gelöscht werden?"))
            {
                return;
            }

            Session.BeginTransaction();
            try
            {
                SqlQuery qry = DBUtil.OpenSQL(@"
                   SELECT PER.PeriodeStatusCode, PER.PeriodeBis, BUC.KbBuchungstatusCode, EIN.Ausgeglichen
                   FROM   KbPeriode               PER
                     INNER JOIN KbBuchung         BUC ON BUC.KbPeriodeID = PER.KbPeriodeID
                     INNER JOIN KbZahlungseingang EIN ON EIN.KbZahlungseingangID = BUC.KbZahlungseingangID
                   WHERE BUC.KbZahlungseingangID = {0}",
                    qryKbZahlungseingang["KbZahlungseingangID"]);

                if ((bool)qry["Ausgeglichen"])
                {
                    throw new KissErrorException("Die Zahlung wurde bereits definitv ausgeglichen!");
                }
                /*
                Periodenprüfung temporär ausgehebelt
                --> für Übergangszeit notwendig!
                if((int)qry["PeriodeStatusCode"] != 1)
                {
                    KissMsg.ShowInfo("Die zur Zahlung gehörende Periode ist nicht mehr aktiv!");
                    Session.Rollback();
                    return;
                }
                */

                DBUtil.ExecuteScalarSQLThrowingException(@"
                    DECLARE @OP TABLE (KbBuchungID int, TotAusgleichBetrag money)
                    DECLARE @Ik TABLE (IkBetreibungID int, TotAusgleichBetrag money)

                    INSERT @OP (KbBuchungID)
                    SELECT AUS.OpBuchungID
                    FROM   KbOpAusgleich   AUS
                      INNER JOIN KbBuchung BUC ON BUC.KbBuchungID = AUS.AusgleichBuchungID
                    WHERE  BUC.KbZahlungseingangID = {0}

                    DELETE AUS
                    FROM   KbOpAusgleich   AUS
                      INNER JOIN KbBuchung BUC ON BUC.KbBuchungID = AUS.AusgleichBuchungID
                    WHERE  BUC.KbZahlungseingangID = {0}

                    INSERT @Ik (IkBetreibungID)
                    SELECT AUS.IkBetreibungID
                    FROM IkBetreibungAusgleich AUS
                      INNER JOIN KbBuchung     BUC ON BUC.KbBuchungID = AUS.AusgleichBuchungID
                    WHERE BUC.KbZahlungseingangID = {0}

                    DELETE AUS
                    FROM   IkBetreibungAusgleich AUS
                      INNER JOIN KbBuchung       BUC ON BUC.KbBuchungID = AUS.AusgleichBuchungID
                    WHERE  BUC.KbZahlungseingangID = {0}

                    DELETE KbBuchung
                    WHERE  KbZahlungseingangID = {0}

                    UPDATE @OP
                    SET    TotAusgleichBetrag = IsNull((SELECT SUM(Betrag) FROM KbOpAusgleich WHERE OpBuchungID = KbBuchungID),0)

                    UPDATE BUC
                    SET    KbBuchungStatusCode = 13 -- zurück auf verbuchtCASE
                                                 --WHEN OP.TotAusgleichBetrag = 0 THEN 2            -- freigegeben (grün)
                                                 --WHEN OP.TotAusgleichBetrag >= BUC.Betrag THEN 6  -- ausgeglichen
                                                 --ELSE 10                                          -- teilausgeglichen
                                                 --END
                    FROM   KbBuchung  BUC
                      INNER JOIN @OP  OP ON OP.KbBuchungID = BUC.KbBuchungID

                    UPDATE BET
                    SET    IkBetreibungStatusCode = 2 --Betreibungsverfahren laufend
                    FROM   IkBetreibung BET
                      INNER JOIN @Ik    IK ON IK.IkBetreibungID = BET.IkBetreibungID

                    exec dbo.spKbRecycleBelegNr {1}, 1, {2}, {3}",
                    qryKbZahlungseingang["KbZahlungseingangID"],
                    qryKbZahlungseingang["KbPeriodeID"],
                    qryKbZahlungseingang["KontoNr"],
                    qryKbZahlungseingang["BelegNr"]);

                if (_klibuIntegriert)
                {
                    qryKbZahlungseingang["BaPersonID"] = DBNull.Value;// Zahlungseingang zurücksetzen
                }

                qryKbZahlungseingang["BelegNr"] = DBNull.Value;
                qryKbZahlungseingang.Post();
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message);
                return;
            }

            KissMsg.ShowInfo("Der Ausgleich wurde erfolgreich aufgehoben");

            if (_kbOpAusgleichID <= 0)
            {
                qryKbZahlungseingang.Refresh();
            }
            else
            {
                int kbZahlungseingangID = (int)qryKbZahlungseingang[DBO.KbZahlungseingang.KbZahlungseingangID];
                _kbOpAusgleichID = 0;

                FillQryZahlungseingang();
                qryKbZahlungseingang.Find("KbZahlungseingangID = " + kbZahlungseingangID.ToString());
                tabEingangZahlung.SelectTab(tpgEingang);
            }
        }

        private void btnAusgleich_Click(object sender, System.EventArgs e)
        {
            int[] kgBuchungIDs = UpdateOpSum();

            try
            {
                DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext.Text);
            }
            catch (KissInfoException infoEx)
            {
                infoEx.ShowMessage();
                return;
            }

            if (!btnAusgleich.Enabled)
            {
                KissMsg.ShowInfo(KissMsg.GetMLMessage("DlgZahlungenErfassen", "AusgleichNichtMöglich", "Ausgleich nicht möglich: Total der auszugleichenden Beträge stimmt nicht mit Zahlungseingang überein"));
                return;
            }

            Session.BeginTransaction();
            try
            {
                int? kbPeriodeID = (int?)DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT TOP 1 KbPeriodeID
                    FROM dbo.KbPeriode WITH (READUNCOMMITTED)
                    WHERE KbMandantID = 1 /*für BSS KbMandantID 1: Klibu*/
                      -- Während übergangsphase wird nicht geprüft! AND PeriodeStatusCode = 1 /*offen*/
                      AND dbo.fnDateOf({0}) BETWEEN PeriodeVon AND PeriodeBis
                    ORDER BY PeriodeVon",
                    qryKbZahlungseingang["Datum"]) as int?;

                if (!kbPeriodeID.HasValue)
                {
                    throw new KissErrorException(
                        KissMsg.GetMLMessage(
                          "DlgZahlungenErfassen",
                          "KeineOffenePeriode",
                          "Es existiert keine aktive Buchungsperiode für das Datum {0:dd.MM.yyyy}",
                          KissMsgCode.MsgError,
                          qryKbZahlungseingang["Datum"]
                        )
                    );
                }

                //GegenKonto bestimmen (Ticket 3020 --> rausgefunden: falsches Konto! Muss Konto von Zahlungseingang sein!)
                object postKontoNr = qryKbZahlungseingang["KontoNr"]; // DBUtil.ExecuteScalarSQLThrowingException(@"SELECT KontoNr FROM KbKonto WHERE REPLACE(REPLACE(',' + KbKontoartCodes + ',', ',', ','), ' ', ',') LIKE '%,50,%' AND KbPeriodeID = {0}", kbPeriodeID.Value);
                // Debitorenkonto bestimmen
                object debitorKontoNr = DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT KontoNr
                    FROM dbo.KbKonto WITH (READUNCOMMITTED)
                    WHERE REPLACE(REPLACE(',' + KbKontoartCodes + ',', ',', ','), ' ', ',') LIKE '%,20,%'
                      AND KbPeriodeID = {0}",
                    kbPeriodeID.Value
                );

                // Buchungstext bestimmen
                string text = edtBuchungstext.Text;

                // nächste BelegNr holen
                int naechsteBelegNr = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                    EXEC dbo.spKbGetBelegNr {0}, 1, {1}", //KbBelegkreis	1	Aktivkonto
                    (int)kbPeriodeID.Value,
                    qryKbZahlungseingang["KontoNr"] as string
                );
                int? kbBelegKreisId = KliBuUtil.GetKbBelegKreisId(kbPeriodeID.Value, 1, qryKbZahlungseingang["KontoNr"] as string);

                System.Diagnostics.Debug.WriteLine("naechsteBelegNr: " + naechsteBelegNr as string);

                // Gegenbuchung erstellen
                int ausgleichKgBuchungID = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                    INSERT INTO KbBuchung (KbPeriodeID, KbBuchungTypCode, KbZahlungseingangID, BelegDatum, ValutaDatum, SollKtoNr, HabenKtoNr, Betrag, Text, ErstelltDatum, BelegNr, KbBelegKreisID, ErstelltUserID)
                    VALUES ({0}, 4, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11})
                    SELECT CAST(SCOPE_IDENTITY() AS int)",
                    kbPeriodeID.Value,
                    qryKbZahlungseingang["KbZahlungseingangID"],
                    qryKbZahlungseingang["Datum"],
                    qryKbZahlungseingang["Datum"],
                    postKontoNr,
                    debitorKontoNr,
                    qryKbZahlungseingang["Betrag"],
                    text,
                    DateTime.Now,
                    naechsteBelegNr,
                    kbBelegKreisId,
                    Session.User.UserID);

                System.Diagnostics.Debug.WriteLine("ausgleichKgBuchungID: " + ausgleichKgBuchungID as string);

                foreach (DataRow row in qryOpAusgleich.DataTable.Rows)
                {
                    decimal? ausglBetrag = row["AusglBetrag"] as decimal?;
                    if (ausglBetrag.HasValue && ausglBetrag > 0m)
                    {
                        DBUtil.ExecuteScalarSQLThrowingException(@"
                            INSERT INTO KbOpAusgleich (OpBuchungID, AusgleichBuchungID, Betrag)
                            VALUES ({0},{1},{2})

                            DECLARE @TotAusgleichBetrag MONEY
                            SELECT @TotAusgleichBetrag = SUM(Betrag)
                            FROM   KbOpAusgleich
                            WHERE  OpBuchungID = {0}

                            UPDATE KbBuchung
                            SET    KbBuchungStatusCode = CASE WHEN @TotAusgleichBetrag >= Betrag THEN 6 ELSE 10 END
                            WHERE  KbBuchungID = {0}",
                            row["KbBuchungID"],
                            ausgleichKgBuchungID,
                            row["AusglBetrag"]);
                    }
                }

                foreach (DataRow row in qryIkAusgleich.DataTable.Rows)
                {
                    decimal? ausglBetrag = row["AusglBetrag"] as decimal?;
                    if (ausglBetrag.HasValue && ausglBetrag > 0m)
                    {
                        DBUtil.ExecuteScalarSQLThrowingException(@"
                            INSERT INTO IkBetreibungAusgleich (IkBetreibungID, AusgleichBuchungID, Betrag)
                            VALUES ({0},{1},{2})

                            DECLARE @TotAusgleichBetrag MONEY
                            SELECT @TotAusgleichBetrag = SUM(Betrag)
                            FROM   IkBetreibungAusgleich
                            WHERE  IkBetreibungID = {0}

                            UPDATE IkBetreibung
                            SET    IkBetreibungStatusCode = CASE WHEN @TotAusgleichBetrag >= BetreibungBetrag THEN 3 ELSE IkBetreibungStatusCode END --3: Abgeschlossen und bezahlt
                            WHERE  IkBetreibungID = {0}",
                            row["IkBetreibungID"],
                            ausgleichKgBuchungID,
                            row["AusglBetrag"]);
                    }
                }

                qryKbZahlungseingang["BaPersonID"] = _baPersonIDSchuldner; //beim speichern schuldner auf Zahlungseingang speichern
                qryKbZahlungseingang["ZugeteiltUserID"] = Session.User.UserID;//beim speichern ZugeteiltUserID auf Zahlungseingang speichern

                if (!qryKbZahlungseingang.Post())
                {
                    throw new KissErrorException("Zahlungseingang konnte nicht verändert werden.");
                }

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message);
                return;
            }

            KissMsg.ShowInfo(KissMsg.GetMLMessage("DlgZahlungenErfassen", "AugleichErfolgreich", "Der Ausgleich wurde erfolgreich gespeichert"));

            int nextKbZahlungseingangID = 0;
            try
            {
                int nextRowHandle = grvZahlungseingang.GetNextVisibleRow(grvZahlungseingang.FocusedRowHandle);
                if (nextRowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    nextKbZahlungseingangID = (int)grvZahlungseingang.GetRowCellValue(nextRowHandle, "KbZahlungseingangID");
                }
            }
            catch (Exception ex2)
            {
                KissMsg.ShowError("Positionierung auf nächsten Zahlungseingang\r\n\r\n" + ex2.Message);
            }

            qryKbZahlungseingang.Refresh();
            qryKbZahlungseingang.Find("KbZahlungseingangID = " + nextKbZahlungseingangID.ToString());
        }

        private void edtFilterSAR_EditValueChanged(object sender, System.EventArgs e)
        {
            if (DBUtil.IsEmpty(edtFilterSAR.EditValue))
            {
                qryKbZahlungseingang.DataTable.DefaultView.RowFilter = null;
            }
            else
            {
                var kbZahlungseingangId = qryKbZahlungseingang[DBO.KbZahlungseingang.KbZahlungseingangID] as int?;
                qryKbZahlungseingang.DataTable.DefaultView.RowFilter = string.Format("SAR LIKE '%{0}%'", edtFilterSAR.Text);

                if (kbZahlungseingangId != qryKbZahlungseingang[DBO.KbZahlungseingang.KbZahlungseingangID] as int?)
                {
                    FillQryAusgleiche();
                }
            }
        }

        private void ikAusgleichBetrag_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((bool)qryKbZahlungseingang["Ausgeglichen"])
                return;

            qryIkAusgleich["AusglBetrag"] = e.NewValue;
            UpdateIkSum();
        }

        private void ikBetragUebernehmen_ButtonClick(object sender, EventArgs e)
        {
            decimal summe = decimal.Zero;
            foreach (DataRow row in qryIkAusgleich.DataTable.Rows)
            {
                decimal? ausglBetrag = row["AusglBetrag"] as decimal?;
                if (ausglBetrag.HasValue)
                {
                    summe += ausglBetrag.Value;
                }
            }

            decimal restBetrag = (decimal)qryIkAusgleich["RestBetrag"];
            decimal totalBetrag = (decimal)qryKbZahlungseingang["Betrag"];
            qryIkAusgleich["AusglBetrag"] = Math.Max(Math.Min(restBetrag, totalBetrag - summe), 0m);
            UpdateIkSum();
        }

        private void opAusgleichBetrag_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((bool)qryKbZahlungseingang["Ausgeglichen"])
                return;

            qryOpAusgleich["AusglBetrag"] = e.NewValue;
            UpdateOpSum();
        }

        private void opBetragUebernehmen_ButtonClick(object sender, EventArgs e)
        {
            decimal summe = decimal.Zero;
            foreach (DataRow row in qryOpAusgleich.DataTable.Rows)
            {
                decimal? ausglBetrag = row["AusglBetrag"] as decimal?;
                if (ausglBetrag.HasValue)
                {
                    summe += ausglBetrag.Value;
                }
            }

            decimal restBetrag = (decimal)qryOpAusgleich["RestBetrag"];
            decimal totalBetrag = (decimal)qryKbZahlungseingang["Betrag"];
            qryOpAusgleich["AusglBetrag"] = Math.Max(Math.Min(restBetrag, totalBetrag - summe), 0m);
            UpdateOpSum();
        }

        private void qryIkAusgleich_PositionChanged(object sender, System.EventArgs e)
        {
            if (!(bool)qryKbZahlungseingang["Ausgeglichen"])
            {
                UpdateIkSum();
            }
        }

        private void qryKbZahlungseingang_PositionChanged(object sender, System.EventArgs e)
        {
            FillQryAusgleiche();
        }

        private void qryOpAusgleich_PositionChanged(object sender, System.EventArgs e)
        {
            if (!(bool)qryKbZahlungseingang["Ausgeglichen"])
            {
                UpdateOpSum();
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void FillQryAusgleiche()
        {
            if (qryKbZahlungseingang.IsEmpty)
            {
                return;
            }

            if ((bool)qryKbZahlungseingang["EingangAusgeglichen"])
            {
                grdAusgleichOp.DataSource = null;

                // Bereits ausgeglichener Zahlungseingang
                qryOpAusgleich.Fill(@"
                    --alle bereits zugewiesenen Posten
                    select KbBuchungID = BUC2.KbBuchungID,
                           Valuta      = BUC2.ValutaDatum,
                           DatumForderung = POS.Datum,
                           Haben       = BUC2.HabenKtoNr,
                           Text        = BUC2.Text, --'div', --isNull(KOA.BuchungsText, BUC2.Text),
                           Betrag      = BUC2.Betrag,
                           RestBetrag  = (SELECT BUC2.Betrag - SUM(Betrag) FROM KbOpAusgleich WHERE OPBuchungID = AUS.OpBuchungID),
                           AusglBetrag = AUS.Betrag,
                           AUS.OpBuchungID,
                           AUS.AusgleichBuchungID,
                           SortKey = 1,
                           Debitor = DBP.NameVorname
                    FROM  KbZahlungseingang         ZEI
                      INNER JOIN KbBuchung          BUC  ON BUC.KbZahlungseingangID = ZEI.KbZahlungseingangID
                      INNER JOIN KbOpAusgleich      AUS  ON AUS.AusgleichBuchungID = BUC.KbBuchungID
                      INNER JOIN KbBuchung          BUC2 ON BUC2.KbBuchungID = AUS.OpBuchungID
                      LEFT  JOIN IkPosition         POS  ON POS.IkPositionID = BUC2.IkPositionID
                      LEFT  JOIN vwPerson           DBP  ON DBP.BaPersonID = POS.BaPersonID -- Gläubiger!
                    WHERE ZEI.KbZahlungseingangID = {0}
                    ORDER BY SortKey, Valuta",
                    qryKbZahlungseingang["KbZahlungseingangID"]);

                grdAusgleichOp.GridStyle = GridStyleType.ReadOnly;
                grvForderung.OptionsView.ShowFooter = true;
                edtOpRestbetrag.Visible = false;
                lblRestbetrag.Visible = false;
                colAusgleich.VisibleIndex = -1;
                grdAusgleichOp.DataSource = qryOpAusgleich;

                // Dasselbe für Betreibungen
                qryIkAusgleich.Fill(@"
                    --alle bereits zugewiesenen Posten
                    SELECT IkBetreibungID       = BET.IkBetreibungID,
                           BetreibungAm         = BET.BetreibungAm,
                           Betrag               = BET.BetreibungBetrag,
                           RestBetrag           = IsNull((select BET.BetreibungBetrag - sum(Betrag) from IkBetreibungAusgleich where IkBetreibungID = BET.IkBetreibungID), BET.BetreibungBetrag),
                           AusglBetrag          = AUS.Betrag,
                           OpIkBetreibungID     = null,
                           Nummer               = BetreibungNummer,
                           AusgleichKbBuchungID = null,
                           SortKey = 1
                    FROM   KbZahlungseingang                ZEI
                      INNER JOIN KbBuchung             BUC ON BUC.KbZahlungseingangID = ZEI.KbZahlungseingangID
                      INNER JOIN IkBetreibungAusgleich AUS ON AUS.AusgleichBuchungID = BUC.KbBuchungID
                      INNER JOIN IkBetreibung          BET ON BET.IkBetreibungID = AUS.IkBetreibungID
                      LEFT  JOIN IkRechtstitel         RET ON RET.IkRechtstitelID = BET.IkRechtstitelID
                    WHERE  ZEI.KbZahlungseingangID = {0}
                    order by SortKey, BetreibungAm",
                    qryKbZahlungseingang["KbZahlungseingangID"]);

                grdIkAusgleich.GridStyle = GridStyleType.ReadOnly;
                edtIkRestbetrag.Visible = false;
                lblIkRestbetrag.Visible = false;
                colIkAusgleich.VisibleIndex = -1;
                btnAusgleich.Visible = false;
                btnAusgleichAufheben.Visible = true;
            }
            else
            {
                // Offener Zahlungseingang
                qryOpAusgleich.Fill(@"
                    SELECT KbBuchungID = BUC.KbBuchungID,
                           Valuta      = BUC.ValutaDatum,
                           DatumForderung = POS.Datum,
                           Haben       = isNull(BUC.HabenKtoNr, KOA.KontoNr),
                           Text        = isNull(KOA.BuchungsText, BUC.Text),
                           Betrag      = BUC.Betrag,
                           RestBetrag  = IsNull((select BUC.Betrag - sum(Betrag) from KbOpAusgleich where OPBuchungID = BUC.KbBuchungID), BUC.Betrag),
                           AusglBetrag = CAST( 0 as money ),
                           OpBuchungID = null,
                           AusgleichBuchungID = null,
                           SortKey = 0,
                           Debitor = DBP.NameVorname
                    FROM KbBuchung             BUC
                      LEFT  JOIN KbBuchungKostenart KOA ON KOA.KbBuchungID = BUC.KbBuchungID
                      INNER JOIN IkPosition    POS  ON POS.IkPositionID = BUC.IkPositionID
                      LEFT  JOIN IkRechtstitel IRT  ON IRT.IkRechtstitelID = POS.IkRechtstitelID
                      LEFT  JOIN vwPerson      DBP  ON DBP.BaPersonID = POS.BaPersonID -- Gläubiger!
                    WHERE BUC.FaLeistungID = {0} -- (IRT.FaLeistungID = {0} OR BUC.FaLeistungID ={0})
                      AND BUC.HabenKtoNr IS NULL
                      AND BUC.KbBuchungStatusCode IN (10,13)-- OP
                      AND (IsNull((SELECT BUC.Betrag - SUM(Betrag) FROM KbOpAusgleich WHERE OPBuchungID = BUC.KbBuchungID), BUC.Betrag)) <> 0
                    ORDER BY SortKey, Valuta",
                    _faLeistungID,
                    _baPersonID);

                grdAusgleichOp.GridStyle = GridStyleType.Editable;
                grvForderung.OptionsView.ShowFooter = false;
                colAusgleich.VisibleIndex = 6;
                edtOpRestbetrag.Visible = true;
                lblRestbetrag.Visible = true;

                // Dasselbe für Betreibungen
                qryIkAusgleich.Fill(@"
                    SELECT IkBetreibungID     = BET.IkBetreibungID,
                           BetreibungAm       = BET.BetreibungAm,
                           Betrag             = BET.BetreibungBetrag,
                           RestBetrag         = IsNull((select BET.BetreibungBetrag - sum(Betrag) from IkBetreibungAusgleich where IkBetreibungID = BET.IkBetreibungID), BET.BetreibungBetrag),
                           AusglBetrag        = CAST( 0 as money ),
                           OpIkBetreibungID   = null,
                           AusgleichBuchungID = null,
                           Nummer             = BetreibungNummer,
                           SortKey            = 0
                    FROM IkBetreibung             BET
                      LEFT  JOIN IkRechtstitel    RET ON RET.IkRechtstitelID = BET.IkRechtstitelID
                      LEFT  JOIN FaLeistung       LEI ON LEI.FaLeistungID = IsNull(RET.FaLeistungID, BET.FaLeistungID)
                    WHERE {1} = isNull(RET.FaLeistungID, LEI.FaLeistungID)
                       AND BET.IkBetreibungStatusCode = 2 -- Betreibungsverfahren laufend
                       AND (IsNull((select BET.BetreibungBetrag - sum(Betrag) from IkBetreibungAusgleich where IkBetreibungID = BET.IkBetreibungID), BET.BetreibungBetrag)) <> 0
                    ORDER BY SortKey, BET.BetreibungAm",
                    _baPersonID,
                    _faLeistungID);
                grdIkAusgleich.GridStyle = GridStyleType.Editable;
                colIkAusgleich.VisibleIndex = 6;
                edtIkRestbetrag.Visible = true;
                lblIkRestbetrag.Visible = true;
                btnAusgleich.Visible = true;
                btnAusgleichAufheben.Visible = false;
                UpdateOpSum();
                UpdateIkSum();
            }
        }

        private void FillQryZahlungseingang()
        {
            qryKbZahlungseingang.Fill(_baPersonID, _baPersonIDSchuldner, _kbOpAusgleichID);

            if (_kbOpAusgleichID <= 0)
            {
                edtFilterSAR.EditValue = string.Format("{0}, {1}", Session.User.LastName, Session.User.FirstName);
                edtBuchungstext.EditValue = (string)DBUtil.ExecuteScalarSQL(@"SELECT 'Zahlung '+ NameVorname FROM vwPerson WHERE BaPersonID = {0}", _baPersonIDSchuldner);
                edtBuchungstext.EditMode = EditModeType.Normal;
            }
            else
            {
                edtBuchungstext.EditValue = qryKbZahlungseingang["Text"];
                edtBuchungstext.EditMode = EditModeType.ReadOnly;
            }
        }

        private int[] UpdateIkSum()
        {
            qryIkAusgleich.EndCurrentEdit();
            List<int> ikBetreibungIDs = new List<int>();
            decimal summe = decimal.Zero;
            foreach (DataRow row in qryIkAusgleich.DataTable.Rows)
            {
                decimal? ausglBetrag = row["AusglBetrag"] as decimal?;
                if (ausglBetrag.HasValue)
                {
                    if (ausglBetrag.Value < 0m)
                    {
                        row["AusglBetrag"] = 0m;
                        ausglBetrag = 0m;
                    }

                    summe += ausglBetrag.Value;
                    if (ausglBetrag.Value > 0m)
                    {
                        ikBetreibungIDs.Add((int)row["IkBetreibungID"]);
                    }
                }
            }

            decimal? betragSoll = qryKbZahlungseingang["Betrag"] as decimal?;
            if (!betragSoll.HasValue)
            {
                betragSoll = 0m;
            }

            edtIkRestbetrag.EditValue = betragSoll - summe;

            _ikSummeOk = (betragSoll >= summe);
            btnAusgleich.Enabled = _opSummeOk && _ikSummeOk && !(bool)qryKbZahlungseingang["Ausgeglichen"];
            edtIkRestbetrag.BackColor = btnAusgleich.Enabled ? CLR_GREEN : CLR_RED;
            return ikBetreibungIDs.ToArray();
        }

        private int[] UpdateOpSum()
        {
            qryOpAusgleich.EndCurrentEdit();
            List<int> kbBuchungIDs = new List<int>();
            decimal summe = decimal.Zero;
            foreach (DataRow row in qryOpAusgleich.DataTable.Rows)
            {
                decimal? ausglBetrag = row["AusglBetrag"] as decimal?;
                if (ausglBetrag.HasValue)
                {
                    if (ausglBetrag.Value < 0m)
                    {
                        row["AusglBetrag"] = 0m;
                        ausglBetrag = 0m;
                    }

                    summe += ausglBetrag.Value;
                    if (ausglBetrag.Value > 0m)
                    {
                        kbBuchungIDs.Add((int)row["KbBuchungID"]);
                    }
                }
            }

            decimal? betragSoll = qryKbZahlungseingang["Betrag"] as decimal?;
            if (!betragSoll.HasValue)
            {
                betragSoll = 0m;
            }

            edtOpRestbetrag.EditValue = betragSoll - summe;

            _opSummeOk = (betragSoll == summe);
            btnAusgleich.Enabled = _opSummeOk && _ikSummeOk && !(bool)qryKbZahlungseingang["Ausgeglichen"];
            edtOpRestbetrag.BackColor = btnAusgleich.Enabled ? CLR_GREEN : CLR_RED;
            return kbBuchungIDs.ToArray();
        }

        #endregion

        #endregion
    }
}