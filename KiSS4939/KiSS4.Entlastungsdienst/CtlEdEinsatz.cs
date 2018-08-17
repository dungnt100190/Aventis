using System;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Windows.Forms;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common.PI;

namespace KiSS4.Entlastungsdienst
{
    public class CtlEdEinsatz : KiSS4.Common.KissSearchUserControl
    {
        #region Enumerations

        /// <summary>
        /// The access mode for accessing control. Control acts differently depending on given mode.
        /// </summary>
        public enum AccessMode
        {
            Leistung,
            Person,
            User
        }

        #endregion

        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private int _baPersonID = -1;
        private AccessMode _currentAccessMode;
        private DateTime _datumBis = DateTime.MaxValue.Date;
        private DateTime _datumVon = DateTime.MinValue.Date;
        private int _faLeistungID = -1;
        private bool _isInCopyProcess = false; // flag to save if currently within copying (btnKopie)
        private int _origPanBottomHeight = -1;
        private SqlQuery _qryMADetails = null;
        private int _typEd = -1;
        private int _userID = -1;
        private KiSS4.Gui.KissButton btnInfoMitarbeiter;
        private KiSS4.Gui.KissButton btnKopie;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colEdEinsatzID;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colMitarbeiter;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colVon;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlGotoFall ctlGotoFallED;
        private KiSS4.Dokument.XWordBericht docBestaetigung;
        private KiSS4.Gui.KissDateEdit edtBeginnDatum;
        private KiSS4.Gui.KissTimeEdit edtBeginnZeit;
        private KiSS4.Gui.KissMemoEdit edtBemerkungen;
        private KiSS4.Gui.KissDateEdit edtEndeDatum;
        private KiSS4.Gui.KissTimeEdit edtEndeZeit;
        private KiSS4.Gui.KissTextEdit edtKlient;
        private KiSS4.Gui.KissLookUpEdit edtMitarbeiter;
        private KiSS4.Gui.KissTextEdit edtMitarbeiterInfo;
        private KiSS4.Gui.KissTextEdit edtMitarbeiterTelefon;
        private KiSS4.Gui.KissLookUpEdit edtStatus;
        private KiSS4.Gui.KissDateEdit edtSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtSucheMitarbeiter;
        private KiSS4.Gui.KissLookUpEdit edtSucheStatus;
        private KiSS4.Gui.KissLookUpEdit edtSucheTyp;
        private KiSS4.Gui.KissLookUpEdit edtTyp;
        private KiSS4.Gui.KissGrid grdEinsaetze;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEinsaetze;
        private KiSS4.Gui.KissLabel lblBeginn;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblEnde;
        private KiSS4.Gui.KissLabel lblKlient;
        private KiSS4.Gui.KissLabel lblMitarbeiter;
        private KiSS4.Gui.KissLabel lblMitarbeiterTelefon;
        private KiSS4.Gui.KissLabel lblStatus;
        private KiSS4.Gui.KissLabel lblSucheDatumBis;
        private KiSS4.Gui.KissLabel lblSucheDatumVon;
        private KiSS4.Gui.KissLabel lblSucheMitarbeiter;
        private KiSS4.Gui.KissLabel lblSucheStatus;
        private KiSS4.Gui.KissLabel lblSucheTyp;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblTyp;
        private System.Windows.Forms.Panel panBottom;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryEdEinsatz;

        #endregion

        #endregion

        #region Constructors

        public CtlEdEinsatz()
        {
            
            // init controls/components
            this.InitializeComponent();

            // logging
            logger.Debug("enter");

            // set original height of panBottom
            this._origPanBottomHeight = panBottom.Height;

            // attach event
            edtBeginnDatum.LostFocus += edtBeginnDatum_LostFocus;

            // init with default values
            this.Init(null, null, -1, false);

            // debug:
            //this.Init("something", null, AccessMode.Person, -1, false, -1, -1);

            // logging
            logger.Debug("done");
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlEdEinsatz));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdEinsaetze = new KiSS4.Gui.KissGrid();
            this.qryEdEinsatz = new KiSS4.DB.SqlQuery(this.components);
            this.grvEinsaetze = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEdEinsatzID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMitarbeiter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheTyp = new KiSS4.Gui.KissLabel();
            this.edtSucheTyp = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheStatus = new KiSS4.Gui.KissLabel();
            this.edtSucheStatus = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtSucheMitarbeiter = new KiSS4.Gui.KissLookUpEdit();
            this.panBottom = new System.Windows.Forms.Panel();
            this.btnKopie = new KiSS4.Gui.KissButton();
            this.docBestaetigung = new KiSS4.Dokument.XWordBericht();
            this.edtBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.ctlGotoFallED = new KiSS4.Common.CtlGotoFall();
            this.edtKlient = new KiSS4.Gui.KissTextEdit();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.edtMitarbeiterTelefon = new KiSS4.Gui.KissTextEdit();
            this.lblMitarbeiterTelefon = new KiSS4.Gui.KissLabel();
            this.btnInfoMitarbeiter = new KiSS4.Gui.KissButton();
            this.edtMitarbeiter = new KiSS4.Gui.KissLookUpEdit();
            this.edtMitarbeiterInfo = new KiSS4.Gui.KissTextEdit();
            this.lblMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtStatus = new KiSS4.Gui.KissLookUpEdit();
            this.lblStatus = new KiSS4.Gui.KissLabel();
            this.edtTyp = new KiSS4.Gui.KissLookUpEdit();
            this.lblTyp = new KiSS4.Gui.KissLabel();
            this.edtEndeZeit = new KiSS4.Gui.KissTimeEdit();
            this.edtEndeDatum = new KiSS4.Gui.KissDateEdit();
            this.lblEnde = new KiSS4.Gui.KissLabel();
            this.edtBeginnZeit = new KiSS4.Gui.KissTimeEdit();
            this.edtBeginnDatum = new KiSS4.Gui.KissDateEdit();
            this.lblBeginn = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEinsaetze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEdEinsatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEinsaetze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).BeginInit();
            this.panBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitarbeiterTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiterTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitarbeiter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitarbeiterInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndeZeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndeDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEnde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeginnZeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeginnDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeginn)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(698, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.FixedWidth = 500;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 30);
            this.tabControlSearch.ShowClose = false;
            this.tabControlSearch.Size = new System.Drawing.Size(722, 346);
            this.tabControlSearch.TabBaseColor = System.Drawing.Color.Transparent;
            this.tabControlSearch.TabIndex = 1;
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdEinsaetze);
            this.tpgListe.ImageIndex = 0;
            this.tpgListe.SelectedImageIndex = 1;
            this.tpgListe.Size = new System.Drawing.Size(710, 308);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.lblSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.edtSucheStatus);
            this.tpgSuchen.Controls.Add(this.lblSucheStatus);
            this.tpgSuchen.Controls.Add(this.edtSucheTyp);
            this.tpgSuchen.Controls.Add(this.lblSucheTyp);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumVon);
            this.tpgSuchen.ImageIndex = 0;
            this.tpgSuchen.SelectedImageIndex = 1;
            this.tpgSuchen.Size = new System.Drawing.Size(710, 308);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMitarbeiter, 0);
            // 
            // panTitel
            // 
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(722, 30);
            this.panTitel.TabIndex = 0;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 1;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(550, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Einsätze";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // grdEinsaetze
            // 
            this.grdEinsaetze.DataSource = this.qryEdEinsatz;
            this.grdEinsaetze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEinsaetze.EmbeddedNavigator.Name = "";
            this.grdEinsaetze.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdEinsaetze.Location = new System.Drawing.Point(0, 0);
            this.grdEinsaetze.MainView = this.grvEinsaetze;
            this.grdEinsaetze.Name = "grdEinsaetze";
            this.grdEinsaetze.Size = new System.Drawing.Size(710, 308);
            this.grdEinsaetze.TabIndex = 58;
            this.grdEinsaetze.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEinsaetze});
            // 
            // qryEdEinsatz
            // 
            this.qryEdEinsatz.HostControl = this;
            this.qryEdEinsatz.TableName = "EdEinsatz";
            this.qryEdEinsatz.BeforePost += new System.EventHandler(this.qryEdEinsatz_BeforePost);
            this.qryEdEinsatz.AfterFill += new System.EventHandler(this.qryEdEinsatz_AfterFill);
            this.qryEdEinsatz.AfterInsert += new System.EventHandler(this.qryEdEinsatz_AfterInsert);
            this.qryEdEinsatz.AfterPost += new System.EventHandler(this.qryEdEinsatz_AfterPost);
            // 
            // grvEinsaetze
            // 
            this.grvEinsaetze.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvEinsaetze.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsaetze.Appearance.Empty.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.Empty.Options.UseFont = true;
            this.grvEinsaetze.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsaetze.Appearance.EvenRow.Options.UseFont = true;
            this.grvEinsaetze.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEinsaetze.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsaetze.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvEinsaetze.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.FocusedCell.Options.UseFont = true;
            this.grvEinsaetze.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvEinsaetze.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEinsaetze.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsaetze.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvEinsaetze.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.FocusedRow.Options.UseFont = true;
            this.grvEinsaetze.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvEinsaetze.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEinsaetze.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEinsaetze.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEinsaetze.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEinsaetze.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.GroupRow.Options.UseFont = true;
            this.grvEinsaetze.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvEinsaetze.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvEinsaetze.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvEinsaetze.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEinsaetze.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvEinsaetze.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvEinsaetze.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvEinsaetze.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsaetze.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEinsaetze.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvEinsaetze.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvEinsaetze.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvEinsaetze.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsaetze.Appearance.OddRow.Options.UseFont = true;
            this.grvEinsaetze.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvEinsaetze.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsaetze.Appearance.Row.Options.UseBackColor = true;
            this.grvEinsaetze.Appearance.Row.Options.UseFont = true;
            this.grvEinsaetze.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEinsaetze.Appearance.SelectedRow.Options.UseFont = true;
            this.grvEinsaetze.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvEinsaetze.Appearance.VertLine.Options.UseBackColor = true;
            this.grvEinsaetze.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvEinsaetze.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEdEinsatzID,
            this.colDatum,
            this.colVon,
            this.colTyp,
            this.colKlient,
            this.colMitarbeiter,
            this.colStatus,
            this.colBemerkungen});
            this.grvEinsaetze.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvEinsaetze.GridControl = this.grdEinsaetze;
            this.grvEinsaetze.Name = "grvEinsaetze";
            this.grvEinsaetze.OptionsBehavior.Editable = false;
            this.grvEinsaetze.OptionsCustomization.AllowFilter = false;
            this.grvEinsaetze.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvEinsaetze.OptionsNavigation.AutoFocusNewRow = true;
            this.grvEinsaetze.OptionsNavigation.UseTabKey = false;
            this.grvEinsaetze.OptionsView.ColumnAutoWidth = false;
            this.grvEinsaetze.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvEinsaetze.OptionsView.ShowGroupPanel = false;
            this.grvEinsaetze.OptionsView.ShowIndicator = false;
            // 
            // colEdEinsatzID
            // 
            this.colEdEinsatzID.Caption = "EdEinsatzID";
            this.colEdEinsatzID.FieldName = "EdEinsatzID";
            this.colEdEinsatzID.Name = "colEdEinsatzID";
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Beginn";
            this.colDatum.DisplayFormat.FormatString = "g";
            this.colDatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatum.FieldName = "Beginn";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 105;
            // 
            // colVon
            // 
            this.colVon.Caption = "Ende";
            this.colVon.DisplayFormat.FormatString = "g";
            this.colVon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colVon.FieldName = "Ende";
            this.colVon.Name = "colVon";
            this.colVon.Visible = true;
            this.colVon.VisibleIndex = 1;
            this.colVon.Width = 105;
            // 
            // colTyp
            // 
            this.colTyp.Caption = "Typ ED";
            this.colTyp.FieldName = "Typ";
            this.colTyp.Name = "colTyp";
            this.colTyp.Visible = true;
            this.colTyp.VisibleIndex = 2;
            this.colTyp.Width = 120;
            // 
            // colKlient
            // 
            this.colKlient.Caption = "Klient/in";
            this.colKlient.FieldName = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 3;
            this.colKlient.Width = 180;
            // 
            // colMitarbeiter
            // 
            this.colMitarbeiter.Caption = "Mitarbeiter/in";
            this.colMitarbeiter.FieldName = "Mitarbeiter";
            this.colMitarbeiter.Name = "colMitarbeiter";
            this.colMitarbeiter.Visible = true;
            this.colMitarbeiter.VisibleIndex = 4;
            this.colMitarbeiter.Width = 180;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;
            this.colStatus.Width = 110;
            // 
            // colBemerkungen
            // 
            this.colBemerkungen.Caption = "Bemerkungen";
            this.colBemerkungen.FieldName = "Bemerkungen";
            this.colBemerkungen.Name = "colBemerkungen";
            this.colBemerkungen.Visible = true;
            this.colBemerkungen.VisibleIndex = 6;
            this.colBemerkungen.Width = 200;
            // 
            // lblSucheDatumVon
            // 
            this.lblSucheDatumVon.Location = new System.Drawing.Point(31, 40);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(89, 24);
            this.lblSucheDatumVon.TabIndex = 1;
            this.lblSucheDatumVon.Text = "Datum";
            this.lblSucheDatumVon.UseCompatibleTextRendering = true;
            // 
            // edtSucheDatumVon
            // 
            this.edtSucheDatumVon.EditValue = null;
            this.edtSucheDatumVon.Location = new System.Drawing.Point(126, 40);
            this.edtSucheDatumVon.Name = "edtSucheDatumVon";
            this.edtSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumVon.Properties.ShowToday = false;
            this.edtSucheDatumVon.Size = new System.Drawing.Size(95, 24);
            this.edtSucheDatumVon.TabIndex = 2;
            // 
            // lblSucheDatumBis
            // 
            this.lblSucheDatumBis.Location = new System.Drawing.Point(227, 40);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(33, 24);
            this.lblSucheDatumBis.TabIndex = 3;
            this.lblSucheDatumBis.Text = "bis";
            this.lblSucheDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtSucheDatumBis
            // 
            this.edtSucheDatumBis.EditValue = null;
            this.edtSucheDatumBis.Location = new System.Drawing.Point(266, 40);
            this.edtSucheDatumBis.Name = "edtSucheDatumBis";
            this.edtSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumBis.Properties.ShowToday = false;
            this.edtSucheDatumBis.Size = new System.Drawing.Size(95, 24);
            this.edtSucheDatumBis.TabIndex = 4;
            // 
            // lblSucheTyp
            // 
            this.lblSucheTyp.Location = new System.Drawing.Point(31, 70);
            this.lblSucheTyp.Name = "lblSucheTyp";
            this.lblSucheTyp.Size = new System.Drawing.Size(89, 24);
            this.lblSucheTyp.TabIndex = 5;
            this.lblSucheTyp.Text = "Typ ED";
            this.lblSucheTyp.UseCompatibleTextRendering = true;
            // 
            // edtSucheTyp
            // 
            this.edtSucheTyp.Location = new System.Drawing.Point(126, 70);
            this.edtSucheTyp.LOVName = "EdTyp";
            this.edtSucheTyp.Name = "edtSucheTyp";
            this.edtSucheTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTyp.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtSucheTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtSucheTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTyp.Properties.NullText = "";
            this.edtSucheTyp.Properties.ShowFooter = false;
            this.edtSucheTyp.Properties.ShowHeader = false;
            this.edtSucheTyp.Size = new System.Drawing.Size(235, 24);
            this.edtSucheTyp.TabIndex = 6;
            // 
            // lblSucheStatus
            // 
            this.lblSucheStatus.Location = new System.Drawing.Point(31, 100);
            this.lblSucheStatus.Name = "lblSucheStatus";
            this.lblSucheStatus.Size = new System.Drawing.Size(89, 24);
            this.lblSucheStatus.TabIndex = 7;
            this.lblSucheStatus.Text = "Status";
            this.lblSucheStatus.UseCompatibleTextRendering = true;
            // 
            // edtSucheStatus
            // 
            this.edtSucheStatus.Location = new System.Drawing.Point(126, 100);
            this.edtSucheStatus.LOVName = "EdEinsatzStatus";
            this.edtSucheStatus.Name = "edtSucheStatus";
            this.edtSucheStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStatus.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSucheStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSucheStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheStatus.Properties.NullText = "";
            this.edtSucheStatus.Properties.ShowFooter = false;
            this.edtSucheStatus.Properties.ShowHeader = false;
            this.edtSucheStatus.Size = new System.Drawing.Size(235, 24);
            this.edtSucheStatus.TabIndex = 8;
            // 
            // lblSucheMitarbeiter
            // 
            this.lblSucheMitarbeiter.Location = new System.Drawing.Point(31, 130);
            this.lblSucheMitarbeiter.Name = "lblSucheMitarbeiter";
            this.lblSucheMitarbeiter.Size = new System.Drawing.Size(89, 24);
            this.lblSucheMitarbeiter.TabIndex = 9;
            this.lblSucheMitarbeiter.Text = "Mitarbeiter/in";
            this.lblSucheMitarbeiter.UseCompatibleTextRendering = true;
            // 
            // edtSucheMitarbeiter
            // 
            this.edtSucheMitarbeiter.Location = new System.Drawing.Point(126, 130);
            this.edtSucheMitarbeiter.Name = "edtSucheMitarbeiter";
            this.edtSucheMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSucheMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMitarbeiter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheMitarbeiter.Properties.DisplayMember = "Text";
            this.edtSucheMitarbeiter.Properties.NullText = "";
            this.edtSucheMitarbeiter.Properties.ShowFooter = false;
            this.edtSucheMitarbeiter.Properties.ShowHeader = false;
            this.edtSucheMitarbeiter.Properties.ValueMember = "Code";
            this.edtSucheMitarbeiter.Size = new System.Drawing.Size(235, 24);
            this.edtSucheMitarbeiter.TabIndex = 10;
            // 
            // panBottom
            // 
            this.panBottom.Controls.Add(this.btnKopie);
            this.panBottom.Controls.Add(this.docBestaetigung);
            this.panBottom.Controls.Add(this.edtBemerkungen);
            this.panBottom.Controls.Add(this.lblBemerkungen);
            this.panBottom.Controls.Add(this.ctlGotoFallED);
            this.panBottom.Controls.Add(this.edtKlient);
            this.panBottom.Controls.Add(this.lblKlient);
            this.panBottom.Controls.Add(this.edtMitarbeiterTelefon);
            this.panBottom.Controls.Add(this.lblMitarbeiterTelefon);
            this.panBottom.Controls.Add(this.btnInfoMitarbeiter);
            this.panBottom.Controls.Add(this.edtMitarbeiter);
            this.panBottom.Controls.Add(this.edtMitarbeiterInfo);
            this.panBottom.Controls.Add(this.lblMitarbeiter);
            this.panBottom.Controls.Add(this.edtStatus);
            this.panBottom.Controls.Add(this.lblStatus);
            this.panBottom.Controls.Add(this.edtTyp);
            this.panBottom.Controls.Add(this.lblTyp);
            this.panBottom.Controls.Add(this.edtEndeZeit);
            this.panBottom.Controls.Add(this.edtEndeDatum);
            this.panBottom.Controls.Add(this.lblEnde);
            this.panBottom.Controls.Add(this.edtBeginnZeit);
            this.panBottom.Controls.Add(this.edtBeginnDatum);
            this.panBottom.Controls.Add(this.lblBeginn);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 376);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(722, 220);
            this.panBottom.TabIndex = 2;
            // 
            // btnKopie
            // 
            this.btnKopie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKopie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKopie.Location = new System.Drawing.Point(610, 186);
            this.btnKopie.Name = "btnKopie";
            this.btnKopie.Size = new System.Drawing.Size(103, 24);
            this.btnKopie.TabIndex = 22;
            this.btnKopie.Text = "&Kopie";
            this.btnKopie.UseCompatibleTextRendering = true;
            this.btnKopie.UseVisualStyleBackColor = false;
            this.btnKopie.Click += new System.EventHandler(this.btnKopie_Click);
            // 
            // docBestaetigung
            // 
            this.docBestaetigung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.docBestaetigung.Context = "ED_Einsatz_Bestaetigung";
            this.docBestaetigung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docBestaetigung.Image = ((System.Drawing.Image)(resources.GetObject("docBestaetigung.Image")));
            this.docBestaetigung.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.docBestaetigung.Location = new System.Drawing.Point(610, 9);
            this.docBestaetigung.Name = "docBestaetigung";
            this.docBestaetigung.Size = new System.Drawing.Size(103, 24);
            this.docBestaetigung.TabIndex = 21;
            this.docBestaetigung.Text = "Bestäti&gung";
            this.docBestaetigung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.docBestaetigung.UseCompatibleTextRendering = true;
            this.docBestaetigung.UseVisualStyleBackColor = false;
            // 
            // edtBemerkungen
            // 
            this.edtBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkungen.DataMember = "Bemerkungen";
            this.edtBemerkungen.DataSource = this.qryEdEinsatz;
            this.edtBemerkungen.Location = new System.Drawing.Point(105, 129);
            this.edtBemerkungen.Name = "edtBemerkungen";
            this.edtBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungen.Size = new System.Drawing.Size(608, 51);
            this.edtBemerkungen.TabIndex = 20;
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Location = new System.Drawing.Point(9, 129);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(90, 24);
            this.lblBemerkungen.TabIndex = 19;
            this.lblBemerkungen.Text = "Bemerkung";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            // 
            // ctlGotoFallED
            // 
            this.ctlGotoFallED.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlGotoFallED.BaPersonID = ((object)(resources.GetObject("ctlGotoFallED.BaPersonID")));
            this.ctlGotoFallED.DataMember = "BaPersonID";
            this.ctlGotoFallED.DataSource = this.qryEdEinsatz;
            this.ctlGotoFallED.DisplayModules = "6";
            this.ctlGotoFallED.Location = new System.Drawing.Point(687, 99);
            this.ctlGotoFallED.Name = "ctlGotoFallED";
            this.ctlGotoFallED.Size = new System.Drawing.Size(26, 24);
            this.ctlGotoFallED.TabIndex = 18;
            // 
            // edtKlient
            // 
            this.edtKlient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKlient.DataMember = "Klient";
            this.edtKlient.DataSource = this.qryEdEinsatz;
            this.edtKlient.EditMode = KiSS4.Gui.EditModeType.ReadOnly;
            this.edtKlient.Location = new System.Drawing.Point(440, 99);
            this.edtKlient.Name = "edtKlient";
            this.edtKlient.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlient.Properties.Appearance.Options.UseFont = true;
            this.edtKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlient.Properties.ReadOnly = true;
            this.edtKlient.Size = new System.Drawing.Size(241, 24);
            this.edtKlient.TabIndex = 17;
            this.edtKlient.TabStop = false;
            // 
            // lblKlient
            // 
            this.lblKlient.Location = new System.Drawing.Point(345, 99);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(89, 24);
            this.lblKlient.TabIndex = 16;
            this.lblKlient.Text = "Klient/in";
            this.lblKlient.UseCompatibleTextRendering = true;
            // 
            // edtMitarbeiterTelefon
            // 
            this.edtMitarbeiterTelefon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMitarbeiterTelefon.DataMember = "MitarbeiterTelefon";
            this.edtMitarbeiterTelefon.DataSource = this.qryEdEinsatz;
            this.edtMitarbeiterTelefon.EditMode = KiSS4.Gui.EditModeType.ReadOnly;
            this.edtMitarbeiterTelefon.Location = new System.Drawing.Point(440, 69);
            this.edtMitarbeiterTelefon.Name = "edtMitarbeiterTelefon";
            this.edtMitarbeiterTelefon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMitarbeiterTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitarbeiterTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitarbeiterTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitarbeiterTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitarbeiterTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtMitarbeiterTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitarbeiterTelefon.Properties.ReadOnly = true;
            this.edtMitarbeiterTelefon.Size = new System.Drawing.Size(273, 24);
            this.edtMitarbeiterTelefon.TabIndex = 15;
            this.edtMitarbeiterTelefon.TabStop = false;
            // 
            // lblMitarbeiterTelefon
            // 
            this.lblMitarbeiterTelefon.Location = new System.Drawing.Point(345, 69);
            this.lblMitarbeiterTelefon.Name = "lblMitarbeiterTelefon";
            this.lblMitarbeiterTelefon.Size = new System.Drawing.Size(89, 24);
            this.lblMitarbeiterTelefon.TabIndex = 14;
            this.lblMitarbeiterTelefon.Text = "Telefon";
            this.lblMitarbeiterTelefon.UseCompatibleTextRendering = true;
            // 
            // btnInfoMitarbeiter
            // 
            this.btnInfoMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInfoMitarbeiter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoMitarbeiter.IconID = 5004;
            this.btnInfoMitarbeiter.Location = new System.Drawing.Point(687, 39);
            this.btnInfoMitarbeiter.Name = "btnInfoMitarbeiter";
            this.btnInfoMitarbeiter.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btnInfoMitarbeiter.Size = new System.Drawing.Size(26, 24);
            this.btnInfoMitarbeiter.TabIndex = 13;
            this.btnInfoMitarbeiter.UseCompatibleTextRendering = true;
            this.btnInfoMitarbeiter.UseVisualStyleBackColor = false;
            this.btnInfoMitarbeiter.Click += new System.EventHandler(this.btnInfoMitarbeiter_Click);
            // 
            // edtMitarbeiter
            // 
            this.edtMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMitarbeiter.DataMember = "XUser_EdEinsatzvereinbarungID";
            this.edtMitarbeiter.DataSource = this.qryEdEinsatz;
            this.edtMitarbeiter.Location = new System.Drawing.Point(440, 39);
            this.edtMitarbeiter.Name = "edtMitarbeiter";
            this.edtMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.edtMitarbeiter.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtMitarbeiter.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitarbeiter.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtMitarbeiter.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMitarbeiter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtMitarbeiter.Properties.DisplayMember = "Text";
            this.edtMitarbeiter.Properties.NullText = "";
            this.edtMitarbeiter.Properties.ShowFooter = false;
            this.edtMitarbeiter.Properties.ShowHeader = false;
            this.edtMitarbeiter.Properties.ValueMember = "Code";
            this.edtMitarbeiter.Size = new System.Drawing.Size(241, 24);
            this.edtMitarbeiter.TabIndex = 12;
            this.edtMitarbeiter.EditValueChanged += new System.EventHandler(this.edtMitarbeiter_EditValueChanged);
            // 
            // edtMitarbeiterInfo
            // 
            this.edtMitarbeiterInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMitarbeiterInfo.DataMember = "Mitarbeiter";
            this.edtMitarbeiterInfo.DataSource = this.qryEdEinsatz;
            this.edtMitarbeiterInfo.EditMode = KiSS4.Gui.EditModeType.ReadOnly;
            this.edtMitarbeiterInfo.Location = new System.Drawing.Point(440, 39);
            this.edtMitarbeiterInfo.Name = "edtMitarbeiterInfo";
            this.edtMitarbeiterInfo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMitarbeiterInfo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitarbeiterInfo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitarbeiterInfo.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitarbeiterInfo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitarbeiterInfo.Properties.Appearance.Options.UseFont = true;
            this.edtMitarbeiterInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitarbeiterInfo.Properties.ReadOnly = true;
            this.edtMitarbeiterInfo.Size = new System.Drawing.Size(100, 24);
            this.edtMitarbeiterInfo.TabIndex = 11;
            // 
            // lblMitarbeiter
            // 
            this.lblMitarbeiter.Location = new System.Drawing.Point(345, 39);
            this.lblMitarbeiter.Name = "lblMitarbeiter";
            this.lblMitarbeiter.Size = new System.Drawing.Size(89, 24);
            this.lblMitarbeiter.TabIndex = 10;
            this.lblMitarbeiter.Text = "Mitarbeiter/in";
            this.lblMitarbeiter.UseCompatibleTextRendering = true;
            // 
            // edtStatus
            // 
            this.edtStatus.DataMember = "StatusCode";
            this.edtStatus.DataSource = this.qryEdEinsatz;
            this.edtStatus.Location = new System.Drawing.Point(105, 99);
            this.edtStatus.LOVName = "EdEinsatzStatus";
            this.edtStatus.Name = "edtStatus";
            this.edtStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatus.Properties.Appearance.Options.UseFont = true;
            this.edtStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStatus.Properties.NullText = "";
            this.edtStatus.Properties.ShowFooter = false;
            this.edtStatus.Properties.ShowHeader = false;
            this.edtStatus.Size = new System.Drawing.Size(205, 24);
            this.edtStatus.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(9, 99);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(90, 24);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status";
            this.lblStatus.UseCompatibleTextRendering = true;
            // 
            // edtTyp
            // 
            this.edtTyp.AllowNull = false;
            this.edtTyp.DataMember = "TypCode";
            this.edtTyp.DataSource = this.qryEdEinsatz;
            this.edtTyp.Location = new System.Drawing.Point(105, 69);
            this.edtTyp.LOVName = "EdTyp";
            this.edtTyp.Name = "edtTyp";
            this.edtTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTyp.Properties.Appearance.Options.UseFont = true;
            this.edtTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTyp.Properties.NullText = "";
            this.edtTyp.Properties.ShowFooter = false;
            this.edtTyp.Properties.ShowHeader = false;
            this.edtTyp.Size = new System.Drawing.Size(205, 24);
            this.edtTyp.TabIndex = 7;
            // 
            // lblTyp
            // 
            this.lblTyp.Location = new System.Drawing.Point(9, 69);
            this.lblTyp.Name = "lblTyp";
            this.lblTyp.Size = new System.Drawing.Size(90, 24);
            this.lblTyp.TabIndex = 6;
            this.lblTyp.Text = "Typ ED";
            this.lblTyp.UseCompatibleTextRendering = true;
            // 
            // edtEndeZeit
            // 
            this.edtEndeZeit.DataMember = "EndeZeit";
            this.edtEndeZeit.DataSource = this.qryEdEinsatz;
            this.edtEndeZeit.EditValue = null;
            this.edtEndeZeit.Location = new System.Drawing.Point(206, 39);
            this.edtEndeZeit.Name = "edtEndeZeit";
            this.edtEndeZeit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEndeZeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEndeZeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEndeZeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEndeZeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtEndeZeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEndeZeit.Properties.Appearance.Options.UseFont = true;
            this.edtEndeZeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtEndeZeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtEndeZeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEndeZeit.Properties.DisplayFormat.FormatString = "t";
            this.edtEndeZeit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtEndeZeit.Properties.EditFormat.FormatString = "t";
            this.edtEndeZeit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtEndeZeit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.edtEndeZeit.Properties.Mask.EditMask = "t";
            this.edtEndeZeit.Size = new System.Drawing.Size(64, 24);
            this.edtEndeZeit.TabIndex = 5;
            this.edtEndeZeit.Modified += new System.EventHandler(this.edtBeginnEnde_Modified);
            // 
            // edtEndeDatum
            // 
            this.edtEndeDatum.DataMember = "EndeDatum";
            this.edtEndeDatum.DataSource = this.qryEdEinsatz;
            this.edtEndeDatum.EditValue = null;
            this.edtEndeDatum.Location = new System.Drawing.Point(105, 39);
            this.edtEndeDatum.Name = "edtEndeDatum";
            this.edtEndeDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEndeDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEndeDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEndeDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEndeDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtEndeDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEndeDatum.Properties.Appearance.Options.UseFont = true;
            this.edtEndeDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtEndeDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEndeDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtEndeDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEndeDatum.Properties.ShowToday = false;
            this.edtEndeDatum.Size = new System.Drawing.Size(95, 24);
            this.edtEndeDatum.TabIndex = 4;
            this.edtEndeDatum.Modified += new System.EventHandler(this.edtBeginnEnde_Modified);
            // 
            // lblEnde
            // 
            this.lblEnde.Location = new System.Drawing.Point(9, 39);
            this.lblEnde.Name = "lblEnde";
            this.lblEnde.Size = new System.Drawing.Size(90, 24);
            this.lblEnde.TabIndex = 3;
            this.lblEnde.Text = "Ende";
            this.lblEnde.UseCompatibleTextRendering = true;
            // 
            // edtBeginnZeit
            // 
            this.edtBeginnZeit.DataMember = "BeginnZeit";
            this.edtBeginnZeit.DataSource = this.qryEdEinsatz;
            this.edtBeginnZeit.EditValue = null;
            this.edtBeginnZeit.Location = new System.Drawing.Point(206, 9);
            this.edtBeginnZeit.Name = "edtBeginnZeit";
            this.edtBeginnZeit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBeginnZeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBeginnZeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeginnZeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeginnZeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeginnZeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeginnZeit.Properties.Appearance.Options.UseFont = true;
            this.edtBeginnZeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtBeginnZeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtBeginnZeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBeginnZeit.Properties.DisplayFormat.FormatString = "t";
            this.edtBeginnZeit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtBeginnZeit.Properties.EditFormat.FormatString = "t";
            this.edtBeginnZeit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtBeginnZeit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.edtBeginnZeit.Properties.Mask.EditMask = "t";
            this.edtBeginnZeit.Size = new System.Drawing.Size(64, 24);
            this.edtBeginnZeit.TabIndex = 2;
            this.edtBeginnZeit.Modified += new System.EventHandler(this.edtBeginnEnde_Modified);
            // 
            // edtBeginnDatum
            // 
            this.edtBeginnDatum.DataMember = "BeginnDatum";
            this.edtBeginnDatum.DataSource = this.qryEdEinsatz;
            this.edtBeginnDatum.EditValue = null;
            this.edtBeginnDatum.Location = new System.Drawing.Point(105, 9);
            this.edtBeginnDatum.Name = "edtBeginnDatum";
            this.edtBeginnDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBeginnDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBeginnDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeginnDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeginnDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeginnDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeginnDatum.Properties.Appearance.Options.UseFont = true;
            this.edtBeginnDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtBeginnDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBeginnDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtBeginnDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBeginnDatum.Properties.ShowToday = false;
            this.edtBeginnDatum.Size = new System.Drawing.Size(95, 24);
            this.edtBeginnDatum.TabIndex = 1;
            this.edtBeginnDatum.Modified += new System.EventHandler(this.edtBeginnEnde_Modified);
            // 
            // lblBeginn
            // 
            this.lblBeginn.Location = new System.Drawing.Point(9, 9);
            this.lblBeginn.Name = "lblBeginn";
            this.lblBeginn.Size = new System.Drawing.Size(90, 24);
            this.lblBeginn.TabIndex = 0;
            this.lblBeginn.Text = "Beginn";
            this.lblBeginn.UseCompatibleTextRendering = true;
            // 
            // CtlEdEinsatz
            // 
            this.ActiveSQLQuery = this.qryEdEinsatz;
            this.AutoRefresh = false;
            this.Controls.Add(this.panTitel);
            this.Controls.Add(this.panBottom);
            this.Name = "CtlEdEinsatz";
            this.Size = new System.Drawing.Size(722, 596);
            this.Controls.SetChildIndex(this.panBottom, 0);
            this.Controls.SetChildIndex(this.panTitel, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEinsaetze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEdEinsatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEinsaetze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).EndInit();
            this.panBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitarbeiterTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiterTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitarbeiterInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndeZeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndeDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEnde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeginnZeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeginnDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeginn)).EndInit();
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

        private void btnInfoMitarbeiter_Click(object sender, System.EventArgs e)
        {
            // logging
            logger.Debug("enter");

            // validate if any data can be displayed
            if (DBUtil.IsEmpty(qryEdEinsatz["UserID"]))
            {
                // logging
                logger.Debug("no user selected, cancel");

                // no data selected
                KissMsg.ShowInfo("CtlEdEinsatz", "NoUserSelected", "Es ist kein/e Mitarbeiter/in ausgewählt. Das Anzeigen der Details ist nicht möglich.");
                return;
            }

            // find EdMitarbeiterID of given user
            SqlQuery qryEdMitarbeiter = DBUtil.OpenSQL(@"
                    SELECT TOP 1
                           EDM.EdMitarbeiterID
                    FROM dbo.EdMitarbeiter EDM WITH (READUNCOMMITTED)
                    WHERE EDM.UserID = {0}", Convert.ToInt32(qryEdEinsatz["UserID"]));

            // check if call is valid
            if (qryEdMitarbeiter.Count < 1 || DBUtil.IsEmpty(qryEdMitarbeiter["EdMitarbeiterID"]))
            {
                // no data selected
                KissMsg.ShowInfo("CtlEdEinsatz", "NoUserFoundToJumpTo", "Der/die gewünschte Mitarbeiter/in ist beim Entlastungsdienst nicht eingetragen. Das Anzeigen der Details ist nicht möglich.");
                return;
            }

            // jump to selected EdMitarbeiterID
            FormController.OpenForm(FrmMitarbeiterverwaltung.FormControllerTarget_Mitarbeiterverwaltung, 
                                    "Action", FrmMitarbeiterverwaltung.FormControllerAction_JumpToMitarbeiter, 
                                    "EdMitarbeiterID", qryEdMitarbeiter["EdMitarbeiterID"]);

            // logging
            logger.Debug("done");
        }

        private void btnKopie_Click(object sender, System.EventArgs e)
        {
            // logging
            logger.Debug("enter");

            // VALIDATE IF ALLOWED:
            // copy is only allowed if not locked
            if (!qryEdEinsatz.CanInsert || !qryEdEinsatz.CanUpdate)
            {
                // logging
                logger.Debug("cannot insert/update, cancel");

                // do nothing
                btnKopie.Enabled = false;
                return;
            }

            // ensure valid data
            if (!qryEdEinsatz.Post() || qryEdEinsatz.Count < 1)
            {
                return;
            }

            // DO IT:
            Cursor currentCursor = Cursor.Current;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // set flag
                this._isInCopyProcess = true;

                // show dialog to let the user select the dates he want to create copies to
                DlgMehrfacheintrag dlg = new DlgMehrfacheintrag();

                // allow sat/sun
                dlg.AllowSaturdaySunday = true;

                // show dialog and check if user clicked ok-button
                if (dlg.ShowDialog(this) != DialogResult.OK)
                {
                    // not ok-button clicked - do not continue
                    return;
                }

                // SPECIFIC HANDLING:
                // get current dates
                DateTime datumBeginn = Convert.ToDateTime(qryEdEinsatz["Beginn"]);
                DateTime datumEnde = Convert.ToDateTime(qryEdEinsatz["Ende"]);

                // calculate difference
                TimeSpan timeSpanBeginnEnde = datumEnde.Subtract(datumBeginn);	// end - beginn to have positive delta

                // logging
                logger.Debug(String.Format("datumBeginn='{0}', datumEnde='{1}', timeSpanBeginnEnde='{2}'", datumBeginn, datumEnde, timeSpanBeginnEnde));

                // GO ON:
                // get selected dates from dialog
                DateTime[] selectedDates = dlg.GetSelectedDates();

                // validate
                if (selectedDates == null || selectedDates.Length < 1)
                {
                    // do not continue
                    return;
                }

                // loop through array
                for (Int32 i = 0; i < selectedDates.Length; i++)
                {
                    // copy each value into a new row
                    System.Data.DataRow newRow = qryEdEinsatz.DataTable.NewRow();

                    foreach (System.Data.DataColumn col in qryEdEinsatz.DataTable.Columns)
                    {
                        if (!col.AutoIncrement)
                        {
                            newRow[col.ColumnName] = qryEdEinsatz.Row[col.ColumnName];
                        }
                    }

                    // CONTINUE
                    // setup new beginn-date with new-date-part and old-hours/minutes/seconds-part
                    DateTime newBeginn = new DateTime(selectedDates[i].Year, selectedDates[i].Month, selectedDates[i].Day, datumBeginn.Hour, datumBeginn.Minute, datumBeginn.Second);

                    // modify copied values, apply calculated values
                    newRow["Beginn"] = newBeginn;
                    newRow["Ende"] = newBeginn.Add(timeSpanBeginnEnde); 	// add amount of time to end, to have proper end-date calulated depending on start with same delta

                    // if empty, leave it empty, otherwise apply code 'geplant'
                    if (!DBUtil.IsEmpty(newRow["StatusCode"]))
                    {
                        // not empty, apply 'geplant'
                        newRow["StatusCode"] = 1;									// reset to 'geplant' (EdEinsatzStatus: 1=geplant)
                    }

                    // logging
                    logger.Debug(String.Format("newRow['Beginn']='{0}', newRow['Ende']='{1}'", newRow["Beginn"], newRow["Ende"]));

                    // add new row to query and save data
                    qryEdEinsatz.RowModified = false;		// somehow he thinks, he has changed the current row...
                    qryEdEinsatz.DataTable.Rows.Add(newRow);
                    qryEdEinsatz.RowModified = true;

                    if (!qryEdEinsatz.Post())
                    {
                        throw new Exception("Post has failed, data could not be inserted.");
                    }
                }
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError("CtlEdEinsatz", "ErrorCopyEntryToNewDate", "Es ist ein Fehler beim Kopieren der Einträge aufgetreten.", ex);
            }
            finally
            {
                // refresh query
                qryEdEinsatz.Refresh();

                // reset flag
                this._isInCopyProcess = false;

                // set focus
                edtBeginnDatum.Focus();

                // reset cursor
                this.Cursor = currentCursor;
            }

            // logging
            logger.Debug("done");
        }

        private void edtBeginnDatum_LostFocus(object sender, EventArgs e)
        {
            // update default value if neccessary
            this.SetDefaultValueEndeDatum();
        }

        private void edtBeginnEnde_Modified(object sender, EventArgs e)
        {
            // logging
            logger.Debug("enter");

            // check if user can change value
            if (qryEdEinsatz.CanUpdate)
            {
                // set row modified to ensure values will be saved even without leaving control
                qryEdEinsatz.RowModified = true;
            }

            // logging
            logger.Debug("done");
        }

        private void edtMitarbeiter_EditValueChanged(object sender, System.EventArgs e)
        {
            // logging
            logger.Debug("enter");

            // only if we have a valid datasource
            if (!qryEdEinsatz.CanUpdate || this.edtMitarbeiter.Properties.DataSource == null || this._qryMADetails == null || this._qryMADetails.Count < 1)
            {
                // logging
                logger.Debug("locked, cancel");

                // do nothing
                return;
            }

            // check if empty and found
            if (DBUtil.IsEmpty(edtMitarbeiter.EditValue) || !this._qryMADetails.Find(String.Format("Code = {0}", edtMitarbeiter.EditValue)))
            {
                // logging
                logger.Debug("nothing selected or not found");

                // manualy reset value because of some strange behaviour in databinding
                qryEdEinsatz[edtMitarbeiter.DataMember] = DBNull.Value;

                // reset display fields
                qryEdEinsatz["UserID"] = DBNull.Value;
                qryEdEinsatz["Mitarbeiter"] = DBNull.Value;
                qryEdEinsatz["MitarbeiterTelefon"] = DBNull.Value;
            }
            else
            {
                // logging
                logger.Debug(String.Format("apply values to component: QryMADetails - UserID='{0}', Text='{1}', Code='{2}', Telefon='{3}'", this._qryMADetails["UserID"], this._qryMADetails["Text"], this._qryMADetails["Code"], this._qryMADetails["Telefon"]));

                // manualy set value because of some strange behaviour in databinding
                qryEdEinsatz[edtMitarbeiter.DataMember] = edtMitarbeiter.EditValue;

                // apply display-only fields depending on selected value
                qryEdEinsatz["UserID"] = this._qryMADetails["UserID"];
                qryEdEinsatz["Mitarbeiter"] = this._qryMADetails["Text"];
                qryEdEinsatz["MitarbeiterTelefon"] = this._qryMADetails["Telefon"];
            }

            // check current mode
            if (qryEdEinsatz.Row.RowState == DataRowState.Added)
            {
                // store current DatumBis to reapply after refresh if removed
                Object endeDatum = edtEndeDatum.EditValue;

                // update binding, due to some strange behaviour not everytime binding does update control-text
                qryEdEinsatz.RefreshDisplay();

                // reapply if there was a date and now its gone
                if (!DBUtil.IsEmpty(endeDatum) && DBUtil.IsEmpty(edtEndeDatum.EditValue))
                {
                    edtEndeDatum.EditValue = endeDatum;

                    // logging
                    logger.Debug("reapplied date to end-date control");
                }
            }
            else
            {
                // only update binding, due to some strange behaviour not everytime binding does update control-text
                qryEdEinsatz.RefreshDisplay();
            }

            // logging
            logger.Debug("done");
        }

        private void qryEdEinsatz_AfterFill(object sender, System.EventArgs e)
        {
            // select last row
            qryEdEinsatz.Last();
        }

        private void qryEdEinsatz_AfterInsert(object sender, System.EventArgs e)
        {
            // logging
            logger.Debug("enter");

            // apply person id
            qryEdEinsatz["FaLeistungID"] = this._faLeistungID;

            // apply default values
            qryEdEinsatz["TypCode"] = 1;		// Entlastungsdienst

            // creator of row (if changed)
            qryEdEinsatz["Creator"] = DBUtil.GetDBRowCreatorModifier();

            // set focus
            edtBeginnDatum.Focus();

            // logging
            logger.Debug("done");
        }

        private void qryEdEinsatz_AfterPost(object sender, System.EventArgs e)
        {
            // logging
            logger.Debug("enter");

            // apply lookup fields
            qryEdEinsatz["Typ"] = edtTyp.Text;
            qryEdEinsatz["Status"] = edtStatus.Text;

            // logging
            logger.Debug("done");
        }

        private void qryEdEinsatz_BeforePost(object sender, System.EventArgs e)
        {
            // logging
            logger.Debug("enter");
            logger.DebugFormat("BeginDate='{0}', BeginTime='{1}', EndDate='{2}', EndTime='{3}'", edtBeginnDatum.EditValue, edtBeginnZeit.EditValue, edtEndeDatum.EditValue, edtEndeZeit.EditValue);

            // check accessmode
            if (this._currentAccessMode != AccessMode.Leistung)
            {
                // show error
                KissMsg.ShowError("CtlEdEinsatz", "InvalidAccessMode", "Die Daten können nicht gespeichert werden, das Verändern der Daten in diesem Zugriffsmodus ist nicht zulässig.");

                // cancel
                throw new KissCancelException();
            }

            // CHECK IF NOT MULTICOPY
            if (!this._isInCopyProcess)
            {
                // validate must-fields
                DBUtil.CheckNotNullField(edtBeginnDatum, lblBeginn.Text);
                DBUtil.CheckNotNullField(edtBeginnZeit, lblBeginn.Text);
                DBUtil.CheckNotNullField(edtEndeDatum, lblEnde.Text);
                DBUtil.CheckNotNullField(edtEndeZeit, lblEnde.Text);
                DBUtil.CheckNotNullField(edtTyp, lblTyp.Text);
                DBUtil.CheckNotNullField(edtMitarbeiter, lblMitarbeiter.Text);

                // check if we have a userid (required for later validation)
                if (DBUtil.IsEmpty(qryEdEinsatz["UserID"]) || Convert.ToInt32(qryEdEinsatz["UserID"]) < 1)
                {
                    // show error
                    KissMsg.ShowError("CtlEdEinsatz", "InvalidUserIDOnPost", "Ausnahmefehler: Es ist keine UserID definiert, der Datensatz kann nicht gespeichert werden.");

                    // do not continue
                    return;
                }

                // create Beginn and Ende DateTime
                qryEdEinsatz["Beginn"] = FaUtils.CombineDateTime(edtBeginnDatum.DateTime, edtBeginnZeit.Time);
                qryEdEinsatz["Ende"] = FaUtils.CombineDateTime(edtEndeDatum.DateTime, edtEndeZeit.Time);
            }

            // we have a ZeitVon and ZeitBis, validate if Bis > Von
            if (Convert.ToDateTime(qryEdEinsatz["Beginn"]) >= Convert.ToDateTime(qryEdEinsatz["Ende"]))
            {
                // invalid range
                throw new KissInfoException(KissMsg.GetMLMessage("CtlEdEinsatz", "InvalidTimeOrder_v01", "Der Wert 'Ende' ist ungültig - er darf nicht kleiner oder gleich 'Beginn' sein."), (Control)edtEndeZeit);
            }

            // validate if range is not yet in use
            if (!Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"SELECT dbo.fnEdEinsatzIsTimeRangeValid({0}, {1}, {2}, {3})", Convert.ToInt32(qryEdEinsatz["UserID"]), qryEdEinsatz["Beginn"], qryEdEinsatz["Ende"], qryEdEinsatz["EdEinsatzID"])))
            {
                // range already in use, show warning
                KissMsg.ShowInfo("CtlEdEinsatz", "UserDateTimeRangeAlreadyInUse_v05", "Hinweis:{0}Die angegebene Zeitspanne wurde für den/die gewählten Mitarbeiter/in und Zeitspanne '{1:g} - {2:g}' bereits verwendet.{0}{0}Die Daten werden aber trotzdem gespeichert.", 0, 0, Environment.NewLine, Convert.ToDateTime(qryEdEinsatz["Beginn"]), Convert.ToDateTime(qryEdEinsatz["Ende"]));
            }

            // logging
            logger.Debug("done");
        }

        #endregion

        #region Methods

        #region Public Methods

        public override Object GetContextValue(String fieldName)
        {
            // logging
            logger.Debug("call");
            logger.DebugFormat("fieldName='{0}'", fieldName);

            switch (fieldName.ToUpper())
            {
                case "EDEINSATZID":
                    // check if we have an entry
                    if (qryEdEinsatz.Count < 1)
                    {
                        return -1;
                    }

                    return qryEdEinsatz["EdEinsatzID"];

                case "EDEINSATZVEREINBARUNGID":
                    // get id of EdEinsatzvereinbarung with same FaLeistungID (FaLeistungID depends on AccessMode)
                    return FaUtils.GetEdEinsatzvereinbarungID(Convert.ToInt32(this.GetContextValue("FaLeistungID")));

                case "FALEISTUNGID":
                    // depending on current access mode
                    if (this._currentAccessMode == AccessMode.Leistung)
                    {
                        // get leistung from Init()-parameter
                        return this._faLeistungID;
                    }
                    else
                    {
                        // get data from current entry
                        return DBUtil.IsEmpty(qryEdEinsatz["FaLeistungID"]) ? -1 : Convert.ToInt32(qryEdEinsatz["FaLeistungID"]);
                    }

                case "BAPERSONID":
                    // check if we have an entry
                    if (qryEdEinsatz.Count < 1)
                    {
                        return -1;
                    }

                    return qryEdEinsatz["BaPersonID"];

                case "USERIDOFED":
                    if (this._currentAccessMode == AccessMode.User)
                    {
                        // logging
                        logger.Debug(String.Format("USERIDOFED: get from filter (UserID='{0}')", this._userID));

                        // get ed-user from filter
                        return this._userID;
                    }
                    else
                    {
                        // get current selected ed-user
                        if (DBUtil.IsEmpty(qryEdEinsatz["UserID"]))
                        {
                            // logging
                            logger.Debug("USERIDOFED: get from query (UserID='-1')");

                            // no ed-user selected
                            return -1;
                        }
                        else
                        {
                            // logging
                            logger.Debug(String.Format("USERIDOFED: get from query (UserID='{0}')", qryEdEinsatz["UserID"]));

                            // return current selected ed-user
                            return Convert.ToInt32(qryEdEinsatz["UserID"]);
                        }
                    }

                case "SELECTEDIDLIST":
                    // check if we have any data
                    if (qryEdEinsatz.Count > 0)
                    {
                        // init var
                        String idList = "";

                        // loop shown entries and get id from each line
                        for (Int32 i = 0; i < grvEinsaetze.DataRowCount; i++)
                        {
                            if (idList.Length > 0)
                            {
                                idList += ",";
                            }

                            idList += grvEinsaetze.GetRowCellValue(i, colEdEinsatzID).ToString();
                        }

                        // logging
                        logger.DebugFormat("SELECTEDIDLIST: idList='{0}'", idList);

                        // done, return ids as csv
                        return idList;
                    }
                    else
                    {
                        // no entry found ("-1" in order to have something to convert to int in stored procedure)
                        return "-1";
                    }

                case "SEARCHDATUMVON":
                    // init var
                    String returnDateFrom = String.Empty;

                    // depending on current access mode
                    if (this._currentAccessMode == AccessMode.Leistung)
                    {
                        // check if we have a search-date and return value
                        if (!DBUtil.IsEmpty(edtSucheDatumVon.EditValue))
                        {
                            returnDateFrom = String.Format("{0:d}", Convert.ToDateTime(edtSucheDatumVon.EditValue));
                        }
                    }
                    else
                    {
                        // return search-date from Init()-parameter
                        if (this._datumVon > SqlDateTime.MinValue.Value)
                        {
                            returnDateFrom = String.Format("{0:d}", this._datumVon);
                        }
                    }

                    // add "von" if we have a return date
                    if (!String.IsNullOrEmpty(returnDateFrom))
                    {
                        // we have a valid value
                        //return String.Format("{0} {1}", KissMsg.GetMLMessage("CtlEdEinsatz", "SearchDateFromPrefix", "von"), returnDateFrom);
                        return returnDateFrom;
                    }

                    // return no-value-string
                    return "-";

                case "SEARCHDATUMBIS":
                    // init var
                    String returnDateTo = String.Empty;

                    // depending on current access mode
                    if (this._currentAccessMode == AccessMode.Leistung)
                    {
                        // check if we have a search-date and return value
                        if (!DBUtil.IsEmpty(edtSucheDatumBis.EditValue))
                        {
                            returnDateTo = String.Format("{0:d}", Convert.ToDateTime(edtSucheDatumBis.EditValue));
                        }
                    }
                    else
                    {
                        // return search-date from Init()-parameter
                        if (this._datumBis < SqlDateTime.MaxValue.Value)
                        {
                            returnDateTo = String.Format("{0:d}", this._datumBis);
                        }
                    }

                    // add "bis" if we have a return date
                    if (!String.IsNullOrEmpty(returnDateTo))
                    {
                        // we have a valid value
                        //return String.Format("{0} {1}", KissMsg.GetMLMessage("CtlEdEinsatz", "SearchDateToPrefix", "bis"), returnDateTo);
                        return returnDateTo;
                    }

                    // return no-value-string
                    return "-";

                case "SEARCHTYPED":
                    // depending on current access mode
                    if (this._currentAccessMode == AccessMode.Leistung)
                    {
                        // check if we have a search-type and return value
                        return DBUtil.IsEmpty(edtSucheTyp.EditValue) ? -1 : Convert.ToInt32(edtSucheTyp.EditValue);
                    }
                    else
                    {
                        // return search-value from Init()-parameter
                        return this._typEd;
                    }
            }

            // let base do stuff
            return base.GetContextValue(fieldName);
        }

        // default access, used in AKV
        public void Init(String titleName, Image titleImage, Int32 faLeistungID, Boolean isLeistungClosed)
        {
            // logging
            logger.Debug("enter (default access)");

            // call Leistung-mode
            this.Init(titleName, titleImage, AccessMode.Leistung, faLeistungID, isLeistungClosed,
                      -1, -1, DateTime.MinValue, DateTime.MaxValue, -1);

            // logging
            logger.Debug("done (default access)");
        }

        // the access mode decides which data will be displayed and the layout will be changed
        public void Init(String titleName, Image titleImage, AccessMode accessMode, Int32 faLeistungID, Boolean isLeistungClosed,
            Int32 baPersonID, Int32 userID, DateTime datumVon, DateTime datumBis, Int32 typEd)
        {
            // logging
            logger.Debug("enter");
            logger.DebugFormat("accessMode='{0}', faLeistungID='{1}', isLeistungClosed='{2}', baPersonID='{3}', userID='{4}', datumVon='{5}', datumBis='{6}', typEd='{7}'",
                               accessMode, faLeistungID, isLeistungClosed, baPersonID, userID, datumVon, datumBis, typEd);

            // validate
            if (accessMode == AccessMode.Leistung && faLeistungID < 1)
            {
                // logging
                logger.Debug("invalid id, cancel");

                // do not continue
                qryEdEinsatz.CanUpdate = false;
                qryEdEinsatz.EnableBoundFields(qryEdEinsatz.CanUpdate);
                return;
            }

            // allow changes
            if (accessMode == AccessMode.Leistung && !isLeistungClosed)
            {
                // update is allowed
                qryEdEinsatz.CanInsert = true;
                qryEdEinsatz.CanUpdate = true;
                qryEdEinsatz.CanDelete = true;
            }
            else
            {
                // everything is locked here
                qryEdEinsatz.CanInsert = false;
                qryEdEinsatz.CanUpdate = false;
                qryEdEinsatz.CanDelete = false;
            }

            // apply values
            this._currentAccessMode = accessMode;
            this._faLeistungID = faLeistungID;

            this._baPersonID = baPersonID;
            this._userID = userID;
            this._datumVon = FaUtils.CorrectDateTimeToSqlDateTime(datumVon);
            this._datumBis = FaUtils.CorrectDateTimeToSqlDateTime(datumBis);
            this._typEd = typEd;

            this.picTitel.Image = titleImage;
            this.lblTitel.Text = titleName;

            // set sql-statement
            qryEdEinsatz.SelectStatement = this.GetSQLStatement();

            // logging
            logger.Debug(String.Format("SelectStatement='{0}'", qryEdEinsatz.SelectStatement));

            // depending on current access mode, we search or fill query
            if (accessMode == AccessMode.Leistung)
            {
                // do new search and run search
                this.NewSearch();
                this.tabControlSearch.SelectTab(this.tpgListe);

                // insert new entry if not yet any entry found
                if (qryEdEinsatz.CanUpdate && qryEdEinsatz.Count < 1)
                {
                    qryEdEinsatz.Insert(null);
                }
            }
            else
            {
                // fill data
                qryEdEinsatz.Fill();
            }

            // setup button
            btnKopie.Enabled = qryEdEinsatz.CanInsert;	// copy is only allowed if user can insert new entries

            // setup gui
            this.SetupGUIDependingOnAccessMode();

            // setup MA-lookupedits
            this.ApplyMitarbeiterLookUps();

            // logging
            logger.Debug("done");
        }

        public override bool OnSaveData()
        {
            // logging
            logger.Debug("call");

            // check if user can change something
            if (qryEdEinsatz.CanUpdate && qryEdEinsatz.RowModified)
            {
                // logging
                logger.DebugFormat("before: BeginDate='{0}', BeginTime='{1}', EndDate='{2}', EndTime='{3}'", edtBeginnDatum.EditValue, edtBeginnZeit.EditValue, edtEndeDatum.EditValue, edtEndeZeit.EditValue);

                // HACK: call DoValidate due to lost-changes-problem otherwise (see #4980)
                // do validate on controls to apply possibly changed values
                edtBeginnDatum.DoValidate();
                edtBeginnZeit.DoValidate();
                edtEndeDatum.DoValidate();
                edtEndeZeit.DoValidate();

                // logging
                logger.DebugFormat("after: BeginDate='{0}', BeginTime='{1}', EndDate='{2}', EndTime='{3}'", edtBeginnDatum.EditValue, edtBeginnZeit.EditValue, edtEndeDatum.EditValue, edtEndeZeit.EditValue);
            }

            // let base do stuff
            return base.OnSaveData();
        }

        public override void OnSearch()
        {
            // logging
            logger.Debug("enter");

            // search is only allowed if in AccessMode.Leistung
            if (this._currentAccessMode != AccessMode.Leistung)
            {
                // do nothing
                return;
            }

            // otherwise, let base do stuff
            base.OnSearch();

            // logging
            logger.Debug("done");
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            // logging
            logger.Debug("enter");

            // let base do stuff
            base.NewSearch();

            // focus
            this.edtSucheDatumVon.Focus();

            // logging
            logger.Debug("done");
        }

        protected override void RunSearch()
        {
            // logging
            logger.Debug("enter");

            // let base do stuff
            base.RunSearch();

            // logging
            logger.Debug("done");
        }

        #endregion

        #region Private Methods

        private void ApplyMitarbeiterLookUps()
        {
            // logging
            logger.Debug("enter");

            // check current accessmode
            if (this._currentAccessMode != AccessMode.Leistung)
            {
                // logging
                logger.Debug("not AccessMode.Leistung, cancel");

                // do nothing if not Leistung
                return;
            }

            // init controls
            this.edtMitarbeiter.Properties.DataSource = null;
            this.edtSucheMitarbeiter.Properties.DataSource = null;

            // get KS orgunits
            SqlQuery qryMA = DBUtil.OpenSQL(@"
                    DECLARE @FaLeistungID INT
                    DECLARE @LanguageCode INT

                    SET @FaLeistungID = {0}
                    SET @LanguageCode = {1}

                    SELECT [Code]    = NULL,
                           [Text]    = '',
                           [UserID]  = NULL,
                           [Telefon] = NULL

                    UNION

                    SELECT [Code]    = UEV.XUser_EdEinsatzvereinbarungID,
                           [Text]    = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
                           [UserID]  = UEV.UserID,
                           [Telefon] = dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 0, @LanguageCode)
                    FROM dbo.EdEinsatzvereinbarung EVB WITH (READUNCOMMITTED)
                      INNER JOIN dbo.XUser_EdEinsatzvereinbarung UEV WITH (READUNCOMMITTED) ON EVB.EdEinsatzvereinbarungID = UEV.EdEinsatzvereinbarungID
                    WHERE EVB.FaLeistungID = @FaLeistungID
                    ORDER BY [Text], [Code]", this._faLeistungID, Session.User.LanguageCode);

            // setup edtMitarbeiter
            this.edtMitarbeiter.Properties.DropDownRows = Math.Min(qryMA.Count, 7);
            this.edtMitarbeiter.Properties.DataSource = qryMA;

            // setup edtSucheMitarbeiter
            this.edtSucheMitarbeiter.Properties.DropDownRows = Math.Min(qryMA.Count, 7);
            this.edtSucheMitarbeiter.Properties.DataSource = qryMA;

            // apply field
            this._qryMADetails = qryMA;

            // logging
            logger.Debug("done");
        }

        

        

        private String GetSQLStatement()
        {
            // logging
            logger.Debug("call");

            // prepare vars for sql-statement
            String sqlStatement = String.Format(@"
                    DECLARE @LanguageCode INT
                    SET @LanguageCode = ISNULL({0}, 1)

                    SELECT EDE.*,
                           BeginnDatum        = EDE.Beginn,
                           BeginnZeit         = EDE.Beginn,
                           EndeDatum          = EDE.Ende,
                           EndeZeit           = EDE.Ende,
                           Typ                = dbo.fnGetLOVMLText('EdTyp', EDE.TypCode, @LanguageCode),
                           Status             = dbo.fnGetLOVMLText('EdEinsatzStatus', EDE.StatusCode, @LanguageCode),
                           UserID             = UEV.UserID,
                           Mitarbeiter        = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
                           MitarbeiterTelefon = dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 0, @LanguageCode),
                           BaPersonID         = LEI.BaPersonID,
                           Klient             = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ISNULL(' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')', '')
                    FROM dbo.EdEinsatz EDE WITH (READUNCOMMITTED)
                      INNER JOIN dbo.FaLeistung                  LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = EDE.FaLeistungID
                      INNER JOIN dbo.XUser_EdEinsatzvereinbarung UEV WITH (READUNCOMMITTED) ON EDE.XUser_EdEinsatzvereinbarungID = UEV.XUser_EdEinsatzvereinbarungID
                      INNER JOIN dbo.BaPerson                    PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID", Session.User.LanguageCode);

            String sqlWhere = String.Empty;

            // set sql-statement where clause depending on current accessmode
            switch (this._currentAccessMode)
            {
                case AccessMode.Leistung:   // leistung
                    // logging
                    logger.Debug("AccessMode.Leistung");

                    // create where
                    sqlWhere = String.Format(@"
                            WHERE LEI.FaLeistungID = {0}", this._faLeistungID);

                    // append search-criteria
                    sqlWhere += @"
                            --- AND dbo.fnDateOf(EDE.Beginn) >= {edtSucheDatumVon}
                            --- AND dbo.fnDateOf(EDE.Ende)   <= {edtSucheDatumBis}
                            --- AND EDE.TypCode               = {edtSucheTyp}
                            --- AND EDE.StatusCode            = {edtSucheStatus}
                            --- AND UEV.UserID                = {edtSucheMitarbeiter.LookupID}";
                    break;

                case AccessMode.Person:     // person
                    // logging
                    logger.Debug("AccessMode.Person");

                    // create where
                    sqlWhere = String.Format(@"
                            WHERE LEI.BaPersonID = {0} AND
                                  dbo.fnDateOf(EDE.Beginn) >= {1} AND
                                  dbo.fnDateOf(EDE.Ende)   <= {2} AND
                                  ({3} < 0 OR EDE.TypCode = {3})", this._baPersonID, DBUtil.SqlLiteral(this._datumVon), DBUtil.SqlLiteral(this._datumBis), this._typEd);
                    break;

                case AccessMode.User:       // user
                    // logging
                    logger.Debug("AccessMode.User");

                    // create where
                    sqlWhere = String.Format(@"
                            WHERE UEV.UserID = {0} AND
                                  dbo.fnDateOf(EDE.Beginn) >= {1} AND
                                  dbo.fnDateOf(EDE.Ende)   <= {2} AND
                                  ({3} < 0 OR EDE.TypCode = {3})", this._userID, DBUtil.SqlLiteral(this._datumVon), DBUtil.SqlLiteral(this._datumBis), this._typEd);
                    break;

                default:
                    // this access mode is not supported
                    throw new NotImplementedException("The given AccessMode is not supported and therefore cannot be handled.");
            }

            // combine select with where and order by, return sql
            return String.Format(@"
                    {0}
                    {1}
                    ORDER BY Klient, EDE.Beginn, EDE.Ende", sqlStatement, sqlWhere);
        }

        private void SetDefaultValueEndeDatum()
        {
            // logging
            logger.Debug("enter");

            // only if we can and should apply value
            if (!qryEdEinsatz.CanUpdate || DBUtil.IsEmpty(edtBeginnDatum.EditValue) || !DBUtil.IsEmpty(edtEndeDatum.EditValue))
            {
                // logging
                logger.Debug("nothing to do, cancel");

                // do nothing
                return;
            }

            // logger
            logger.Debug(String.Format("apply value: BeginnDatum='{0}', BeginnDatum.EditValue='{1}', EndeDatum.EditValue='{2}'", qryEdEinsatz[edtBeginnDatum.DataMember], edtBeginnDatum.EditValue, edtEndeDatum.EditValue));

            // apply value from Beginn to empty Ende date
            edtEndeDatum.EditValue = edtBeginnDatum.EditValue;

            // logging
            logger.Debug("done");
        }

        private void SetupGUIDependingOnAccessMode()
        {
            // logging
            logger.Debug("enter");

            // if access mode is Leistung, we do show/hide other controls than in other access modes
            if (this._currentAccessMode == AccessMode.Leistung)
            {
                // hide column
                colKlient.VisibleIndex = -1;

                // hide Klient
                lblKlient.Visible = false;
                edtKlient.Visible = false;
                ctlGotoFallED.Visible = false;

                // show/hide Mitarbeiter-info-controls
                edtMitarbeiter.Visible = true;
                edtMitarbeiterInfo.Visible = false;

                // do not continue
                return;
            }

            // hide top panel
            panTitel.Visible = false;

            // other modes, disable copy-functionality
            btnKopie.Visible = false;

            // shrink bottom-panel (h=t1+h1+d, where d=h-(t2+h2) and h=height of panBottom; 1=comment, 2=copy-btn)
            panBottom.Height = (edtBemerkungen.Top + edtBemerkungen.Height) + (this._origPanBottomHeight - (btnKopie.Top + btnKopie.Height));

            // setup tabcontrol and tabpages
            this.tabControlSearch.TabsLocation = SharpLibrary.WinControls.TabsLocation.Right;
            this.tabControlSearch.VerticalMargin = 0;
            this.tabControlSearch.FlatStyleSelectedTabBorderColor = this.BackColor;
            this.tabControlSearch.FlatStyleSelectedTabColor = this.BackColor;
            this.tabControlSearch.TextColor = this.BackColor;

            this.tpgSuchen.HideTab = true;

            // show/hide Mitarbeiter-info-controls
            edtMitarbeiter.Visible = false;
            edtMitarbeiterInfo.Visible = true;

            edtMitarbeiterInfo.Top = edtMitarbeiter.Top;
            edtMitarbeiterInfo.Left = edtMitarbeiter.Left;
            edtMitarbeiterInfo.Width = edtMitarbeiter.Width;
            edtMitarbeiterInfo.Anchor = edtMitarbeiter.Anchor;

            // logging
            logger.Debug("done");
        }

        #endregion

        #endregion
    }
}