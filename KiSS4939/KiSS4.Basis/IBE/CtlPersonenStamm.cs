using System;
using System.Text;
using System.Windows.Forms;

using KiSS.DBScheme;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis.IBE
{
    /// <summary>
    /// Search within persons and clients
    /// </summary>
    public class CtlPersonenStamm : KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnFallInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colAHVNr;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colFT;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colHaushaltVersicherungsNr;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitaet;
        private DevExpress.XtraGrid.Columns.GridColumn colNr;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colVersichertenNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Basis.IBE.CtlBaPerson ctlBaPerson;
        private KiSS4.Common.CtlGotoFall ctlGotoFall;
        private KiSS4.Gui.KissTextEdit edtAHVNummer;
        private KiSS4.Gui.KissCalcEdit edtBaPersonID;
        private KiSS4.Gui.KissCheckEdit edtFT;
        private KiSS4.Gui.KissDateEdit edtGeburtBis;
        private KiSS4.Gui.KissDateEdit edtGeburtVon;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissLookUpEdit edtNationalitaet;
        private KiSS4.Gui.KissTextEdit edtNNummer;
        private KiSS4.Gui.KissTextEdit edtOrt;
        private KiSS4.Gui.KissTextEdit edtPLZ;
        private KiSS4.Gui.KissTextEdit edtStrasse;
        private KissTextEdit edtSucheHaushaltVersicherungsNr;
        private KissTextEdit edtSucheVersichertenNummer;
        private KiSS4.Gui.KissTextEdit edtVorname;
        private KiSS4.Gui.KissGrid grdBaPerson;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaPerson;
        private KiSS4.Gui.KissLabel kissLabel1;
        private System.Windows.Forms.Label lblAnzahlDatensaetze;
        private System.Windows.Forms.Label lblRowCount;
        private KiSS4.Gui.KissLabel lblSucheAHVNummer;
        private KiSS4.Gui.KissLabel lblSucheBaPersonID;
        private KiSS4.Gui.KissLabel lblSucheGeburtBis;
        private KiSS4.Gui.KissLabel lblSucheGeburtsdatum;
        private KissLabel lblSucheHaushaltVersicherungsNr;
        private KiSS4.Gui.KissLabel lblSucheName;
        private KiSS4.Gui.KissLabel lblSucheNationalitaet;
        private KiSS4.Gui.KissLabel lblSuchePlzOrt;
        private KiSS4.Gui.KissLabel lblSucheStrasse;
        private KissLabel lblSucheVersichertenNummer;
        private KiSS4.Gui.KissLabel lblSucheVorname;
        private System.Windows.Forms.Panel pnlDemographie;
        private KiSS4.DB.SqlQuery qryBaPerson;
        private string qryBaPerson_SelectStatement = string.Empty;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlPersonenStamm"/> class.
        /// </summary>
        public CtlPersonenStamm()
        {
            // init control
            this.InitializeComponent();

            // init BaPerson-control
            ctlBaPerson.Init(null, KissImageList.GetSmallImage(133), 0, 0, false);

            // select search-tab to start with search
            this.tabControlSearch.SelectTab(tpgSuchen);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlPersonenStamm));
            this.components = new System.ComponentModel.Container();
            this.grdBaPerson = new KiSS4.Gui.KissGrid();
            this.qryBaPerson = new KiSS4.DB.SqlQuery();
            this.grvBaPerson = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitaet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHVNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersichertenNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaushaltVersicherungsNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.edtVorname = new KiSS4.Gui.KissTextEdit();
            this.edtStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtPLZ = new KiSS4.Gui.KissTextEdit();
            this.edtOrt = new KiSS4.Gui.KissTextEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissCalcEdit();
            this.edtGeburtVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheGeburtBis = new KiSS4.Gui.KissLabel();
            this.edtNationalitaet = new KiSS4.Gui.KissLookUpEdit();
            this.edtAHVNummer = new KiSS4.Gui.KissTextEdit();
            this.edtFT = new KiSS4.Gui.KissCheckEdit();
            this.lblSucheVorname = new KiSS4.Gui.KissLabel();
            this.lblSucheNationalitaet = new KiSS4.Gui.KissLabel();
            this.lblSucheAHVNummer = new KiSS4.Gui.KissLabel();
            this.lblSucheGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.lblSuchePlzOrt = new KiSS4.Gui.KissLabel();
            this.lblSucheStrasse = new KiSS4.Gui.KissLabel();
            this.edtGeburtBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheBaPersonID = new KiSS4.Gui.KissLabel();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.edtNNummer = new KiSS4.Gui.KissTextEdit();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.btnFallInfo = new KiSS4.Gui.KissButton();
            this.lblAnzahlDatensaetze = new System.Windows.Forms.Label();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.pnlDemographie = new System.Windows.Forms.Panel();
            this.ctlBaPerson = new KiSS4.Basis.IBE.CtlBaPerson();
            this.edtSucheVersichertenNummer = new KiSS4.Gui.KissTextEdit();
            this.lblSucheVersichertenNummer = new KiSS4.Gui.KissLabel();
            this.lblSucheHaushaltVersicherungsNr = new KiSS4.Gui.KissLabel();
            this.edtSucheHaushaltVersicherungsNr = new KiSS4.Gui.KissTextEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAHVNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePlzOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNNummer.Properties)).BeginInit();
            this.pnlDemographie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVersichertenNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVersichertenNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheHaushaltVersicherungsNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheHaushaltVersicherungsNr.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(960, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Size = new System.Drawing.Size(984, 230);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdBaPerson);
            this.tpgListe.Size = new System.Drawing.Size(972, 192);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSucheHaushaltVersicherungsNr);
            this.tpgSuchen.Controls.Add(this.lblSucheHaushaltVersicherungsNr);
            this.tpgSuchen.Controls.Add(this.edtNNummer);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Controls.Add(this.lblSucheBaPersonID);
            this.tpgSuchen.Controls.Add(this.edtGeburtBis);
            this.tpgSuchen.Controls.Add(this.lblSucheStrasse);
            this.tpgSuchen.Controls.Add(this.lblSuchePlzOrt);
            this.tpgSuchen.Controls.Add(this.lblSucheGeburtsdatum);
            this.tpgSuchen.Controls.Add(this.lblSucheVersichertenNummer);
            this.tpgSuchen.Controls.Add(this.lblSucheAHVNummer);
            this.tpgSuchen.Controls.Add(this.lblSucheNationalitaet);
            this.tpgSuchen.Controls.Add(this.lblSucheVorname);
            this.tpgSuchen.Controls.Add(this.edtFT);
            this.tpgSuchen.Controls.Add(this.edtSucheVersichertenNummer);
            this.tpgSuchen.Controls.Add(this.edtAHVNummer);
            this.tpgSuchen.Controls.Add(this.edtNationalitaet);
            this.tpgSuchen.Controls.Add(this.lblSucheGeburtBis);
            this.tpgSuchen.Controls.Add(this.edtGeburtVon);
            this.tpgSuchen.Controls.Add(this.edtBaPersonID);
            this.tpgSuchen.Controls.Add(this.edtOrt);
            this.tpgSuchen.Controls.Add(this.edtPLZ);
            this.tpgSuchen.Controls.Add(this.edtStrasse);
            this.tpgSuchen.Controls.Add(this.edtVorname);
            this.tpgSuchen.Controls.Add(this.edtName);
            this.tpgSuchen.Size = new System.Drawing.Size(972, 192);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPLZ, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGeburtVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGeburtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNationalitaet, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAHVNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheVersichertenNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFT, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheNationalitaet, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheAHVNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVersichertenNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGeburtsdatum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchePlzOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGeburtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheHaushaltVersicherungsNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheHaushaltVersicherungsNr, 0);
            //
            // grdBaPerson
            //
            this.grdBaPerson.DataSource = this.qryBaPerson;
            this.grdBaPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdBaPerson.EmbeddedNavigator.Name = "";
            this.grdBaPerson.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaPerson.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdBaPerson.Location = new System.Drawing.Point(0, 0);
            this.grdBaPerson.MainView = this.grvBaPerson;
            this.grdBaPerson.Name = "grdBaPerson";
            this.grdBaPerson.Size = new System.Drawing.Size(972, 192);
            this.grdBaPerson.TabIndex = 4;
            this.grdBaPerson.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaPerson});
            //
            // qryBaPerson
            //
            this.qryBaPerson.CanDelete = true;
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.TableName = "BaPerson";
            this.qryBaPerson.AfterFill += new System.EventHandler(this.qryBaPerson_AfterFill);
            this.qryBaPerson.BeforeDeleteQuestion += new System.EventHandler(this.qryBaPerson_BeforeDeleteQuestion);
            this.qryBaPerson.BeforeDelete += new System.EventHandler(this.qryBaPerson_BeforeDelete);
            this.qryBaPerson.AfterDelete += new System.EventHandler(this.qryBaPerson_AfterDelete);
            this.qryBaPerson.PositionChanged += new System.EventHandler(this.qryBaPerson_PositionChanged);
            //
            // grvBaPerson
            //
            this.grvBaPerson.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaPerson.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.Empty.Options.UseFont = true;
            this.grvBaPerson.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvBaPerson.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaPerson.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaPerson.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaPerson.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaPerson.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaPerson.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaPerson.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaPerson.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaPerson.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaPerson.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaPerson.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaPerson.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaPerson.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaPerson.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaPerson.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaPerson.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaPerson.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaPerson.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaPerson.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaPerson.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaPerson.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaPerson.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvBaPerson.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.OddRow.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.OddRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaPerson.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.Row.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.Row.Options.UseFont = true;
            this.grvBaPerson.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvBaPerson.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvBaPerson.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvBaPerson.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaPerson.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaPerson.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaPerson.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFT,
            this.colNr,
            this.colName,
            this.colVorname,
            this.colStrasse,
            this.colOrt,
            this.colGeschlecht,
            this.colAlter,
            this.colGeburtsdatum,
            this.colNationalitaet,
            this.colAHVNr,
            this.colVersichertenNummer,
            this.colHaushaltVersicherungsNr});
            this.grvBaPerson.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaPerson.GridControl = this.grdBaPerson;
            this.grvBaPerson.Name = "grvBaPerson";
            this.grvBaPerson.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grvBaPerson.OptionsBehavior.Editable = false;
            this.grvBaPerson.OptionsCustomization.AllowFilter = false;
            this.grvBaPerson.OptionsCustomization.AllowGroup = false;
            this.grvBaPerson.OptionsFilter.AllowFilterEditor = false;
            this.grvBaPerson.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaPerson.OptionsMenu.EnableColumnMenu = false;
            this.grvBaPerson.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaPerson.OptionsNavigation.AutoMoveRowFocus = false;
            this.grvBaPerson.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvBaPerson.OptionsNavigation.UseTabKey = false;
            this.grvBaPerson.OptionsPrint.AutoWidth = false;
            this.grvBaPerson.OptionsPrint.UsePrintStyles = true;
            this.grvBaPerson.OptionsView.ColumnAutoWidth = false;
            this.grvBaPerson.OptionsView.ShowDetailButtons = false;
            this.grvBaPerson.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaPerson.OptionsView.ShowGroupPanel = false;
            this.grvBaPerson.OptionsView.ShowIndicator = false;
            //
            // colFT
            //
            this.colFT.Caption = "FT";
            this.colFT.FieldName = "HasCase";
            this.colFT.Name = "colFT";
            this.colFT.Visible = true;
            this.colFT.VisibleIndex = 0;
            this.colFT.Width = 26;
            //
            // colNr
            //
            this.colNr.AppearanceCell.Options.UseTextOptions = true;
            this.colNr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colNr.Caption = "Nr";
            this.colNr.FieldName = "BaPersonID";
            this.colNr.Name = "colNr";
            this.colNr.Visible = true;
            this.colNr.VisibleIndex = 1;
            this.colNr.Width = 63;
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 131;
            //
            // colVorname
            //
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Vorname";
            this.colVorname.Name = "colVorname";
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 3;
            this.colVorname.Width = 90;
            //
            // colStrasse
            //
            this.colStrasse.Caption = "Strasse";
            this.colStrasse.FieldName = "WohnsitzStrasseHausNr";
            this.colStrasse.Name = "colStrasse";
            this.colStrasse.Visible = true;
            this.colStrasse.VisibleIndex = 4;
            this.colStrasse.Width = 146;
            //
            // colOrt
            //
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "WohnsitzPLZOrt";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 5;
            this.colOrt.Width = 132;
            //
            // colGeschlecht
            //
            this.colGeschlecht.AppearanceCell.Options.UseTextOptions = true;
            this.colGeschlecht.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGeschlecht.Caption = "m/w";
            this.colGeschlecht.FieldName = "Geschlecht";
            this.colGeschlecht.Name = "colGeschlecht";
            this.colGeschlecht.Visible = true;
            this.colGeschlecht.VisibleIndex = 6;
            this.colGeschlecht.Width = 34;
            //
            // colAlter
            //
            this.colAlter.AppearanceCell.Options.UseTextOptions = true;
            this.colAlter.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAlter.Caption = "Alter";
            this.colAlter.FieldName = "Alter";
            this.colAlter.Name = "colAlter";
            this.colAlter.Visible = true;
            this.colAlter.VisibleIndex = 7;
            this.colAlter.Width = 38;
            //
            // colGeburtsdatum
            //
            this.colGeburtsdatum.Caption = "Geburt";
            this.colGeburtsdatum.FieldName = "Geburtsdatum";
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            this.colGeburtsdatum.Visible = true;
            this.colGeburtsdatum.VisibleIndex = 8;
            //
            // colNationalitaet
            //
            this.colNationalitaet.Caption = "Nationalität";
            this.colNationalitaet.FieldName = "Nationalitaet";
            this.colNationalitaet.Name = "colNationalitaet";
            this.colNationalitaet.Visible = true;
            this.colNationalitaet.VisibleIndex = 9;
            this.colNationalitaet.Width = 97;
            //
            // colAHVNr
            //
            this.colAHVNr.Caption = "AHV-Nr.";
            this.colAHVNr.FieldName = "AHVNummer";
            this.colAHVNr.Name = "colAHVNr";
            this.colAHVNr.Visible = true;
            this.colAHVNr.VisibleIndex = 10;
            this.colAHVNr.Width = 100;
            //
            // colVersichertenNummer
            //
            this.colVersichertenNummer.Caption = "Versicherten-Nr.";
            this.colVersichertenNummer.FieldName = "Versichertennummer";
            this.colVersichertenNummer.Name = "colVersichertenNummer";
            this.colVersichertenNummer.Visible = true;
            this.colVersichertenNummer.VisibleIndex = 11;
            this.colVersichertenNummer.Width = 120;
            //
            // colHaushaltVersicherungsNr
            //
            this.colHaushaltVersicherungsNr.Caption = "Haushaltversicherung-Nr.";
            this.colHaushaltVersicherungsNr.FieldName = "HaushaltVersicherungsNummer";
            this.colHaushaltVersicherungsNr.Name = "colHaushaltVersicherungsNr";
            this.colHaushaltVersicherungsNr.Visible = true;
            this.colHaushaltVersicherungsNr.VisibleIndex = 12;
            //
            // edtName
            //
            this.edtName.EditValue = "";
            this.edtName.Location = new System.Drawing.Point(101, 40);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(206, 24);
            this.edtName.TabIndex = 2;
            //
            // edtVorname
            //
            this.edtVorname.EditValue = "";
            this.edtVorname.Location = new System.Drawing.Point(101, 70);
            this.edtVorname.Name = "edtVorname";
            this.edtVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorname.Properties.Appearance.Options.UseFont = true;
            this.edtVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorname.Size = new System.Drawing.Size(206, 24);
            this.edtVorname.TabIndex = 4;
            //
            // edtStrasse
            //
            this.edtStrasse.EditValue = "";
            this.edtStrasse.Location = new System.Drawing.Point(101, 100);
            this.edtStrasse.Name = "edtStrasse";
            this.edtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasse.Size = new System.Drawing.Size(206, 24);
            this.edtStrasse.TabIndex = 6;
            //
            // edtPLZ
            //
            this.edtPLZ.EditValue = "";
            this.edtPLZ.Location = new System.Drawing.Point(101, 130);
            this.edtPLZ.Name = "edtPLZ";
            this.edtPLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseFont = true;
            this.edtPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPLZ.Size = new System.Drawing.Size(56, 24);
            this.edtPLZ.TabIndex = 8;
            //
            // edtOrt
            //
            this.edtOrt.EditValue = "";
            this.edtOrt.Location = new System.Drawing.Point(156, 130);
            this.edtOrt.Name = "edtOrt";
            this.edtOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrt.Properties.Appearance.Options.UseFont = true;
            this.edtOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrt.Size = new System.Drawing.Size(151, 24);
            this.edtOrt.TabIndex = 9;
            //
            // edtBaPersonID
            //
            this.edtBaPersonID.Location = new System.Drawing.Point(408, 40);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Size = new System.Drawing.Size(95, 24);
            this.edtBaPersonID.TabIndex = 12;
            //
            // edtGeburtVon
            //
            this.edtGeburtVon.EditValue = null;
            this.edtGeburtVon.Location = new System.Drawing.Point(408, 70);
            this.edtGeburtVon.Name = "edtGeburtVon";
            this.edtGeburtVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtVon.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtGeburtVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtGeburtVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtVon.Properties.ShowToday = false;
            this.edtGeburtVon.Size = new System.Drawing.Size(95, 24);
            this.edtGeburtVon.TabIndex = 16;
            //
            // lblSucheGeburtBis
            //
            this.lblSucheGeburtBis.Location = new System.Drawing.Point(511, 70);
            this.lblSucheGeburtBis.Name = "lblSucheGeburtBis";
            this.lblSucheGeburtBis.Size = new System.Drawing.Size(32, 24);
            this.lblSucheGeburtBis.TabIndex = 17;
            this.lblSucheGeburtBis.Text = "bis";
            this.lblSucheGeburtBis.UseCompatibleTextRendering = true;
            //
            // edtNationalitaet
            //
            this.edtNationalitaet.Location = new System.Drawing.Point(408, 100);
            this.edtNationalitaet.LOVName = "BaLand";
            this.edtNationalitaet.Name = "edtNationalitaet";
            this.edtNationalitaet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNationalitaet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNationalitaet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaet.Properties.Appearance.Options.UseBackColor = true;
            this.edtNationalitaet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNationalitaet.Properties.Appearance.Options.UseFont = true;
            this.edtNationalitaet.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtNationalitaet.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaet.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtNationalitaet.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtNationalitaet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtNationalitaet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtNationalitaet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNationalitaet.Properties.NullText = "";
            this.edtNationalitaet.Properties.ShowFooter = false;
            this.edtNationalitaet.Properties.ShowHeader = false;
            this.edtNationalitaet.Size = new System.Drawing.Size(235, 24);
            this.edtNationalitaet.TabIndex = 20;
            //
            // edtAHVNummer
            //
            this.edtAHVNummer.Location = new System.Drawing.Point(766, 40);
            this.edtAHVNummer.Name = "edtAHVNummer";
            this.edtAHVNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAHVNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHVNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseFont = true;
            this.edtAHVNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHVNummer.Size = new System.Drawing.Size(135, 24);
            this.edtAHVNummer.TabIndex = 22;
            //
            // edtFT
            //
            this.edtFT.EditValue = false;
            this.edtFT.Location = new System.Drawing.Point(101, 160);
            this.edtFT.Name = "edtFT";
            this.edtFT.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtFT.Properties.Appearance.Options.UseBackColor = true;
            this.edtFT.Properties.Caption = "nur Fallträger";
            this.edtFT.Size = new System.Drawing.Size(90, 19);
            this.edtFT.TabIndex = 10;
            //
            // lblSucheVorname
            //
            this.lblSucheVorname.Location = new System.Drawing.Point(30, 70);
            this.lblSucheVorname.Name = "lblSucheVorname";
            this.lblSucheVorname.Size = new System.Drawing.Size(65, 24);
            this.lblSucheVorname.TabIndex = 3;
            this.lblSucheVorname.Text = "Vorname";
            this.lblSucheVorname.UseCompatibleTextRendering = true;
            //
            // lblSucheNationalitaet
            //
            this.lblSucheNationalitaet.Location = new System.Drawing.Point(324, 100);
            this.lblSucheNationalitaet.Name = "lblSucheNationalitaet";
            this.lblSucheNationalitaet.Size = new System.Drawing.Size(78, 24);
            this.lblSucheNationalitaet.TabIndex = 19;
            this.lblSucheNationalitaet.Text = "Nationalität";
            this.lblSucheNationalitaet.UseCompatibleTextRendering = true;
            //
            // lblSucheAHVNummer
            //
            this.lblSucheAHVNummer.Location = new System.Drawing.Point(660, 40);
            this.lblSucheAHVNummer.Name = "lblSucheAHVNummer";
            this.lblSucheAHVNummer.Size = new System.Drawing.Size(100, 24);
            this.lblSucheAHVNummer.TabIndex = 21;
            this.lblSucheAHVNummer.Text = "AHV-Nr.";
            this.lblSucheAHVNummer.UseCompatibleTextRendering = true;
            //
            // lblSucheGeburtsdatum
            //
            this.lblSucheGeburtsdatum.Location = new System.Drawing.Point(324, 70);
            this.lblSucheGeburtsdatum.Name = "lblSucheGeburtsdatum";
            this.lblSucheGeburtsdatum.Size = new System.Drawing.Size(78, 24);
            this.lblSucheGeburtsdatum.TabIndex = 15;
            this.lblSucheGeburtsdatum.Text = "Geburt";
            this.lblSucheGeburtsdatum.UseCompatibleTextRendering = true;
            //
            // lblSuchePlzOrt
            //
            this.lblSuchePlzOrt.Location = new System.Drawing.Point(30, 130);
            this.lblSuchePlzOrt.Name = "lblSuchePlzOrt";
            this.lblSuchePlzOrt.Size = new System.Drawing.Size(65, 24);
            this.lblSuchePlzOrt.TabIndex = 7;
            this.lblSuchePlzOrt.Text = "PLZ / Ort";
            this.lblSuchePlzOrt.UseCompatibleTextRendering = true;
            //
            // lblSucheStrasse
            //
            this.lblSucheStrasse.Location = new System.Drawing.Point(30, 100);
            this.lblSucheStrasse.Name = "lblSucheStrasse";
            this.lblSucheStrasse.Size = new System.Drawing.Size(65, 24);
            this.lblSucheStrasse.TabIndex = 5;
            this.lblSucheStrasse.Text = "Strasse";
            this.lblSucheStrasse.UseCompatibleTextRendering = true;
            //
            // edtGeburtBis
            //
            this.edtGeburtBis.EditValue = null;
            this.edtGeburtBis.Location = new System.Drawing.Point(549, 70);
            this.edtGeburtBis.Name = "edtGeburtBis";
            this.edtGeburtBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtBis.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGeburtBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGeburtBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtBis.Properties.ShowToday = false;
            this.edtGeburtBis.Size = new System.Drawing.Size(94, 24);
            this.edtGeburtBis.TabIndex = 18;
            //
            // lblSucheBaPersonID
            //
            this.lblSucheBaPersonID.Location = new System.Drawing.Point(324, 40);
            this.lblSucheBaPersonID.Name = "lblSucheBaPersonID";
            this.lblSucheBaPersonID.Size = new System.Drawing.Size(78, 24);
            this.lblSucheBaPersonID.TabIndex = 11;
            this.lblSucheBaPersonID.Text = "Personen-Nr.";
            this.lblSucheBaPersonID.UseCompatibleTextRendering = true;
            //
            // lblSucheName
            //
            this.lblSucheName.Location = new System.Drawing.Point(30, 40);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(65, 24);
            this.lblSucheName.TabIndex = 1;
            this.lblSucheName.Text = "Name";
            this.lblSucheName.UseCompatibleTextRendering = true;
            //
            // kissLabel1
            //
            this.kissLabel1.Location = new System.Drawing.Point(511, 40);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(32, 24);
            this.kissLabel1.TabIndex = 13;
            this.kissLabel1.Text = "N-Nr.";
            this.kissLabel1.UseCompatibleTextRendering = true;
            //
            // edtNNummer
            //
            this.edtNNummer.Location = new System.Drawing.Point(549, 40);
            this.edtNNummer.Name = "edtNNummer";
            this.edtNNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtNNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNNummer.Properties.Appearance.Options.UseFont = true;
            this.edtNNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNNummer.Size = new System.Drawing.Size(94, 24);
            this.edtNNummer.TabIndex = 14;
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.BaPersonID = ((object)(resources.GetObject("ctlGotoFall.BaPersonID")));
            this.ctlGotoFall.DataMember = "BaPersonID";
            this.ctlGotoFall.DataSource = this.qryBaPerson;
            this.ctlGotoFall.Location = new System.Drawing.Point(185, 216);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(126, 24);
            this.ctlGotoFall.TabIndex = 1;
            //
            // btnFallInfo
            //
            this.btnFallInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFallInfo.Location = new System.Drawing.Point(317, 216);
            this.btnFallInfo.Name = "btnFallInfo";
            this.btnFallInfo.Size = new System.Drawing.Size(63, 24);
            this.btnFallInfo.TabIndex = 2;
            this.btnFallInfo.Text = "Fallinfo";
            this.btnFallInfo.UseCompatibleTextRendering = true;
            this.btnFallInfo.UseVisualStyleBackColor = false;
            this.btnFallInfo.Click += new System.EventHandler(this.btnFallInfo_Click);
            //
            // lblAnzahlDatensaetze
            //
            this.lblAnzahlDatensaetze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnzahlDatensaetze.AutoSize = true;
            this.lblAnzahlDatensaetze.Location = new System.Drawing.Point(834, 221);
            this.lblAnzahlDatensaetze.Name = "lblAnzahlDatensaetze";
            this.lblAnzahlDatensaetze.Size = new System.Drawing.Size(102, 17);
            this.lblAnzahlDatensaetze.TabIndex = 3;
            this.lblAnzahlDatensaetze.Text = "Anzahl Datensätze:";
            this.lblAnzahlDatensaetze.UseCompatibleTextRendering = true;
            //
            // lblRowCount
            //
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblRowCount.Location = new System.Drawing.Point(940, 221);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(48, 17);
            this.lblRowCount.TabIndex = 4;
            this.lblRowCount.Text = "0";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblRowCount.UseCompatibleTextRendering = true;
            //
            // pnlDemographie
            //
            this.pnlDemographie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDemographie.Controls.Add(this.ctlBaPerson);
            this.pnlDemographie.Location = new System.Drawing.Point(8, 244);
            this.pnlDemographie.Name = "pnlDemographie";
            this.pnlDemographie.Size = new System.Drawing.Size(984, 313);
            this.pnlDemographie.TabIndex = 14;
            //
            // ctlBaPerson
            //
            this.ctlBaPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlBaPerson.BaPersonID = 0;
            this.ctlBaPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlBaPerson.Location = new System.Drawing.Point(0, 0);
            this.ctlBaPerson.Name = "ctlBaPerson";
            this.ctlBaPerson.Size = new System.Drawing.Size(984, 313);
            this.ctlBaPerson.TabIndex = 0;
            //
            // edtSucheVersichertenNummer
            //
            this.edtSucheVersichertenNummer.Location = new System.Drawing.Point(766, 70);
            this.edtSucheVersichertenNummer.Name = "edtSucheVersichertenNummer";
            this.edtSucheVersichertenNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVersichertenNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVersichertenNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVersichertenNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVersichertenNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVersichertenNummer.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVersichertenNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVersichertenNummer.Size = new System.Drawing.Size(135, 24);
            this.edtSucheVersichertenNummer.TabIndex = 24;
            //
            // lblSucheVersichertenNummer
            //
            this.lblSucheVersichertenNummer.Location = new System.Drawing.Point(660, 70);
            this.lblSucheVersichertenNummer.Name = "lblSucheVersichertenNummer";
            this.lblSucheVersichertenNummer.Size = new System.Drawing.Size(100, 24);
            this.lblSucheVersichertenNummer.TabIndex = 23;
            this.lblSucheVersichertenNummer.Text = "Versichertennr.";
            this.lblSucheVersichertenNummer.UseCompatibleTextRendering = true;
            //
            // lblSucheHaushaltVersicherungsNr
            //
            this.lblSucheHaushaltVersicherungsNr.Location = new System.Drawing.Point(660, 100);
            this.lblSucheHaushaltVersicherungsNr.Name = "lblSucheHaushaltVersicherungsNr";
            this.lblSucheHaushaltVersicherungsNr.Size = new System.Drawing.Size(100, 24);
            this.lblSucheHaushaltVersicherungsNr.TabIndex = 25;
            this.lblSucheHaushaltVersicherungsNr.Text = "Haushaltvers.Nr";
            this.lblSucheHaushaltVersicherungsNr.UseCompatibleTextRendering = true;
            //
            // edtSucheHaushaltVersicherungsNr
            //
            this.edtSucheHaushaltVersicherungsNr.Location = new System.Drawing.Point(766, 100);
            this.edtSucheHaushaltVersicherungsNr.Name = "edtSucheHaushaltVersicherungsNr";
            this.edtSucheHaushaltVersicherungsNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheHaushaltVersicherungsNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheHaushaltVersicherungsNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheHaushaltVersicherungsNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheHaushaltVersicherungsNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheHaushaltVersicherungsNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheHaushaltVersicherungsNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheHaushaltVersicherungsNr.Size = new System.Drawing.Size(135, 24);
            this.edtSucheHaushaltVersicherungsNr.TabIndex = 26;
            //
            // CtlPersonenStamm
            //
            this.ActiveSQLQuery = this.qryBaPerson;
            this.ClientSize = new System.Drawing.Size(1004, 569);
            this.Controls.Add(this.pnlDemographie);
            this.Controls.Add(this.lblRowCount);
            this.Controls.Add(this.lblAnzahlDatensaetze);
            this.Controls.Add(this.btnFallInfo);
            this.Controls.Add(this.ctlGotoFall);
            this.Name = "CtlPersonenStamm";
            this.Text = "Personen-Stamm";
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.Controls.SetChildIndex(this.btnFallInfo, 0);
            this.Controls.SetChildIndex(this.lblAnzahlDatensaetze, 0);
            this.Controls.SetChildIndex(this.lblRowCount, 0);
            this.Controls.SetChildIndex(this.pnlDemographie, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAHVNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePlzOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNNummer.Properties)).EndInit();
            this.pnlDemographie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVersichertenNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVersichertenNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheHaushaltVersicherungsNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheHaushaltVersicherungsNr.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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

        private void btnFallInfo_Click(object sender, System.EventArgs e)
        {
            try
            {
                int BaPersonID = Utils.ConvertToInt(qryBaPerson["BaPersonID"]);
                FormController.ShowDialogOnMain("FrmFallInfo", BaPersonID, true);
            }
            catch { }
        }

        private void qryBaPerson_AfterDelete(object sender, EventArgs e)
        {
            Session.Commit();
        }

        private void qryBaPerson_AfterFill(object sender, System.EventArgs e)
        {
            // refresh details
            qryBaPerson_PositionChanged(sender, e);

            // set counter
            lblRowCount.Text = Convert.ToString(qryBaPerson.Count);
        }

        private void qryBaPerson_BeforeDelete(object sender, EventArgs e)
        {
            DBUtil.NewHistoryVersion();

            Session.BeginTransaction();

            DeleteDependencies();
        }

        private void qryBaPerson_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            CheckDependencies();
        }

        private void qryBaPerson_PositionChanged(object sender, System.EventArgs e)
        {
            ctlBaPerson.OpenData(Utils.ConvertToInt(qryBaPerson["BaPersonID"]));

            // Wenn kein Fall, dann Schalter FallInfo inaktiv:
            btnFallInfo.Enabled = (qryBaPerson.Count > 0 && (bool)qryBaPerson["HasCase"]);
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            if (!qryBaPerson.Post())
                return false;

            // action depending
            switch (parameters["Action"] as string)
            {
                case "ShowPerson":
                case "JumpToPath":
                    // Show Fall with person, modulcode and optional personname
                    NewSearch();
                    edtBaPersonID.EditValue = parameters["BaPersonID"];
                    RunSearch();
                    tabControlSearch.SelectTab(tpgListe);
                    return true;
            }

            // did not understand message
            return base.ReceiveMessage(parameters);
        }

        /// <summary>
        /// Handle messages from FormController
        /// </summary>
        /// <param name="param">Specific messages as key/value pair for current form</param>
        /// <returns>Specified object that has to be returned to sender</returns>
        public override object ReturnMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param.Count < 1)
            {
                // by default, nothing to do
                return null;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "GetJumpToPath":
                    System.Collections.Specialized.HybridDictionary dic = new System.Collections.Specialized.HybridDictionary();
                    dic["ClassName"] = "FrmPersonenStamm";
                    dic["BaPersonID"] = qryBaPerson["BaPersonID"];
                    return dic;
            }

            // did not understand message
            return base.ReturnMessage(param);
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // set focus
            edtVorname.Focus();
        }

        protected override void RunSearch()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                StringBuilder sql = new StringBuilder(@"
                    SELECT PRS.BaPersonID,
                           PRS.Name,
                           PRS.Vorname,
                           PRS.WohnsitzStrasseHausNr,
                           PRS.WohnsitzPLZOrt,
                           Geschlecht = CASE PRS.GeschlechtCode WHEN 1 THEN 'm'
                                                                WHEN 2 THEN 'w'
                                                                ELSE NULL
                                        END,
                           [Alter] = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())),
                           PRS.Geburtsdatum,
                           PRS.Nationalitaet,
                           PRS.AHVNummer,
                           PRS.Versichertennummer,
                           PRS.HaushaltVersicherungsNummer,
                           PRS.Modifier,
                           PRS.Modified,
                           HasCase = CONVERT(BIT, CASE WHEN EXISTS(SELECT TOP 1 1
                                                                   FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                                                                   WHERE LEI.BaPersonID = PRS.BaPersonID) THEN 1
                                                       ELSE 0
                                                  END)
                    FROM dbo.vwPerson PRS WITH (READUNCOMMITTED)
                    WHERE 1 = 1 ");

                if (Utils.ConvertToString(edtName.EditValue) != "")
                {
                    sql.AppendFormat("AND PRS.Name LIKE {0} + '%' ", DBUtil.SqlLiteral(edtName.EditValue));
                }

                if (Utils.ConvertToString(edtVorname.EditValue) != "")
                {
                    sql.AppendFormat("AND PRS.Vorname LIKE {0} + '%' ", DBUtil.SqlLiteral(edtVorname.EditValue));
                }

                if (Utils.ConvertToString(edtStrasse.EditValue) != "")
                {
                    sql.AppendFormat("AND PRS.WohnsitzStrasse LIKE {0} + '%' ", DBUtil.SqlLiteral(edtStrasse.EditValue));
                }

                if (Utils.ConvertToString(edtPLZ.EditValue) != "")
                {
                    sql.AppendFormat("AND PRS.WohnsitzPLZ LIKE {0} + '%' ", DBUtil.SqlLiteral(edtPLZ.EditValue));
                }

                if (Utils.ConvertToString(edtOrt.EditValue) != "")
                {
                    sql.AppendFormat("AND PRS.WohnsitzOrt LIKE {0} + '%' ", DBUtil.SqlLiteral(edtOrt.EditValue));
                }

                if (edtFT.Checked)
                {
                    sql.Append("AND EXISTS(SELECT TOP 1 1 FROM dbo.FaLeistung LEI WHERE LEI.BaPersonID = PRS.BaPersonID) ");
                }

                if (!DBUtil.IsEmpty(edtBaPersonID.EditValue))
                {
                    sql.AppendFormat("AND PRS.BaPersonID = {0} ", edtBaPersonID.EditValue);
                }

                if (!DBUtil.IsEmpty(edtGeburtVon.EditValue))
                {
                    sql.AppendFormat("AND PRS.Geburtsdatum >= dbo.fnDateOf({0}) ", DBUtil.SqlLiteral(edtGeburtVon.EditValue));
                }

                if (!DBUtil.IsEmpty(edtGeburtBis.EditValue))
                {
                    sql.AppendFormat("AND PRS.Geburtsdatum <= dbo.fnDateOf({0}) ", DBUtil.SqlLiteral(edtGeburtBis.EditValue));
                }

                if (Utils.ConvertToInt(edtNationalitaet.EditValue) != 0)
                {
                    sql.AppendFormat("AND PRS.NationalitaetCode = {0} ", edtNationalitaet.EditValue);
                }

                if (Utils.ConvertToString(edtAHVNummer.EditValue) != "")
                {
                    sql.AppendFormat("AND PRS.AHVNummer LIKE {0} + '%' ", DBUtil.SqlLiteral(edtAHVNummer.EditValue));
                }

                if (Utils.ConvertToString(edtSucheVersichertenNummer.EditValue) != "")
                {
                    sql.AppendFormat("AND PRS.VersichertenNummer LIKE {0} + '%' ", DBUtil.SqlLiteral(edtSucheVersichertenNummer.EditValue));
                }

                if (Utils.ConvertToString(edtNNummer.EditValue) != "")
                {
                    sql.AppendFormat("AND PRS.NNummer LIKE {0} + '%' ", DBUtil.SqlLiteral(edtNNummer.EditValue));
                }

                if (Utils.ConvertToString(edtSucheHaushaltVersicherungsNr.EditValue) != "")
                {
                    sql.AppendFormat("AND PRS.HaushaltVersicherungsNummer LIKE {0} + '%' ", DBUtil.SqlLiteral(edtSucheHaushaltVersicherungsNr.EditValue));
                }

                sql.Append("ORDER BY PRS.Name, PRS.BaPersonID");

                qryBaPerson.Fill(sql.ToString());
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #region Private Methods

        private void CheckDependencies()
        {
            // Es können verschiedenste Abhängigkeiten existieren.
            // Wir prüfen zumindest diejenigen auf der gleichen Maske: Zahlungsverbindung
            int count = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.BaZahlungsweg WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0}",
                qryBaPerson["BaPersonID"]);

            if (count > 0)
            {
                // Zurzeit werden in SqlQuery.OnBeforeDelete() sämtliche Exceptions geschluckt. Deshalb muss die Fehlermeldung hier
                // mittels KissMsg angezeigt werden. Sollte dies mal refactored werden, so dass auftretende KissCancelExceptions
                // nicht mehr geschluckt und angezeigt werden, muss dieses KissMsg.ShowInfo entfernt werden.
                KissMsg.ShowInfo("Person kann nicht gelöscht werden. Es existieren noch Zahlungsverbindungen.");

                throw new KissCancelException("Person kann nicht gelöscht werden. Es existieren noch Zahlungsverbindungen.");
            }

            count = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.BaKopfquote WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0}",
                qryBaPerson["BaPersonID"]);

            if (count > 0)
            {
                KissMsg.ShowInfo("Person kann nicht gelöscht werden. Es existieren noch Einträge in Kopfquote.");

                throw new KissCancelException("Person kann nicht gelöscht werden. Es existieren noch Einträge in Kopfquote.");
            }

            // Zusätzlich werden noch Leistungen und Pendenzen geprüft,
            // da die Wahrscheinlichkeit dieser Abhängigkeiten hoch ist
            count = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0}",
                qryBaPerson["BaPersonID"]);

            if (count > 0)
            {
                KissMsg.ShowInfo("Person kann nicht gelöscht werden. Es existiert noch eine Leistung.");

                throw new KissCancelException("Person kann nicht gelöscht werden. Es existiert noch eine Leistung.");
            }

            count = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.XTask WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0}
                  AND NOT (TaskSenderCode = 4   -- Newod
                        OR TaskStatusCode = 3); -- Erledigt",
                qryBaPerson["BaPersonID"]);

            if (count > 0)
            {
                KissMsg.ShowInfo("Person kann nicht gelöscht werden. Es existieren noch Pendenzen.");

                throw new KissCancelException("Person kann nicht gelöscht werden. Es existieren noch Pendenzen.");
            }
        }

        private void DeleteDependencies()
        {
            // Pendenzen löschen
            DBUtil.ExecuteScalarSQL(@"
                DELETE FROM dbo.XTask
                WHERE BaPersonID = {0}",
                qryBaPerson[DBO.BaPerson.BaPersonID]);

            // Verknüpfung mit Kostenstelle löschen
            DBUtil.ExecuteScalarSQL(@"
                DELETE FROM dbo.KbKostenstelle_BaPerson
                WHERE BaPersonID = {0}",
                qryBaPerson[DBO.BaPerson.BaPersonID]);

            // Verknüpfung mit Mietvertrag löschen
            DBUtil.ExecuteScalarSQL(@"
                DELETE FROM dbo.BaMietvertrag
                WHERE BaPersonID = {0}",
                qryBaPerson[DBO.BaPerson.BaPersonID]);
        }

        #endregion

        #endregion
    }
}