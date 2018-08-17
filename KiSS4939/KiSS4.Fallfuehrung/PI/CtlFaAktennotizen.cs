using System;
using System.Drawing;

using Kiss.Interfaces.UI;

using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung.PI
{
    /// <summary>
    /// Class for managing Aktennotizen
    /// </summary>
    public class CtlFaAktennotizen : Common.KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID = -1;
        private bool _hasAutorChanged = false;
        private bool _queryCanUpdateDelete = false;
        private string _userFullName = "";
        private DevExpress.XtraGrid.Columns.GridColumn colAutor;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDienstleistung;
        private DevExpress.XtraGrid.Columns.GridColumn colFaAktennotizenID;
        private DevExpress.XtraGrid.Columns.GridColumn colKontaktArt;
        private DevExpress.XtraGrid.Columns.GridColumn colStichworte;
        private DevExpress.XtraGrid.Columns.GridColumn colThemen;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Dokument.KissDocumentButton docDokumente;
        private KiSS4.Gui.KissButtonEdit edtAutor;
        private KiSS4.Gui.KissCheckedLookupEdit edtBeteiligte;
        private KiSS4.Gui.KissCheckedLookupEdit edtBetroffeneLebensbereiche;
        private KiSS4.Gui.KissDateEdit edtDatum;
        private KiSS4.Gui.KissLookUpEdit edtDienstleistung;
        private KiSS4.Gui.KissLookUpEdit edtKontaktArt;
        private KiSS4.Gui.KissTextEdit edtStichworte;
        private KiSS4.Gui.KissTextEdit edtSucheAutor;
        private KiSS4.Gui.KissDateEdit edtSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtSucheDienstleistung;
        private KiSS4.Gui.KissTextEdit edtSucheInhalt;
        private KiSS4.Gui.KissTextEdit edtSucheStichworte;
        private KiSS4.Gui.KissGrid grdAktennotizen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAktennotizen;
        private KiSS4.Gui.KissLabel lblAutor;
        private KiSS4.Gui.KissLabel lblBeteiligte;
        private KiSS4.Gui.KissLabel lblBetroffeneLebensbereiche;
        private KiSS4.Gui.KissLabel lblDatum;
        private KiSS4.Gui.KissLabel lblDienstleistung;
        private KiSS4.Gui.KissLabel lblInhalt;
        private KiSS4.Gui.KissLabel lblKontaktArt;
        private KiSS4.Gui.KissLabel lblStichworte;
        private KiSS4.Gui.KissLabel lblSucheAutor;
        private KiSS4.Gui.KissLabel lblSucheDatumBis;
        private KiSS4.Gui.KissLabel lblSucheDatumVon;
        private KiSS4.Gui.KissLabel lblSucheDienstleistung;
        private KiSS4.Gui.KissLabel lblSucheInhalt;
        private KiSS4.Gui.KissLabel lblSucheStichworte;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissRTFEdit memInhalt;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaAktennotizen;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, creates a new instance of control
        /// </summary>
        public CtlFaAktennotizen()
        {
            InitializeComponent();

            // init with default values
            Init(null, null, -1);

            // request userfullname
            _userFullName = Convert.ToString(DBUtil.ExecuteScalarSQL(@"
                SELECT dbo.fnGetLastFirstName({0}, NULL, NULL)", Session.User.UserID));

            FaUtils.SetBeteiligtePersonenInstitutionenCheckedLookupEdit(ref edtBeteiligte);
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaAktennotizen));
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdAktennotizen = new KiSS4.Gui.KissGrid();
            this.qryFaAktennotizen = new KiSS4.DB.SqlQuery(this.components);
            this.grvAktennotizen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFaAktennotizenID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienstleistung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontaktArt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichworte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThemen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheAutor = new KiSS4.Gui.KissLabel();
            this.edtSucheAutor = new KiSS4.Gui.KissTextEdit();
            this.lblSucheStichworte = new KiSS4.Gui.KissLabel();
            this.edtSucheStichworte = new KiSS4.Gui.KissTextEdit();
            this.lblSucheInhalt = new KiSS4.Gui.KissLabel();
            this.edtSucheInhalt = new KiSS4.Gui.KissTextEdit();
            this.lblSucheDienstleistung = new KiSS4.Gui.KissLabel();
            this.edtSucheDienstleistung = new KiSS4.Gui.KissLookUpEdit();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.edtDatum = new KiSS4.Gui.KissDateEdit();
            this.lblDienstleistung = new KiSS4.Gui.KissLabel();
            this.edtDienstleistung = new KiSS4.Gui.KissLookUpEdit();
            this.lblKontaktArt = new KiSS4.Gui.KissLabel();
            this.edtKontaktArt = new KiSS4.Gui.KissLookUpEdit();
            this.lblAutor = new KiSS4.Gui.KissLabel();
            this.edtAutor = new KiSS4.Gui.KissButtonEdit();
            this.lblStichworte = new KiSS4.Gui.KissLabel();
            this.edtStichworte = new KiSS4.Gui.KissTextEdit();
            this.lblInhalt = new KiSS4.Gui.KissLabel();
            this.memInhalt = new KiSS4.Gui.KissRTFEdit();
            this.lblBeteiligte = new KiSS4.Gui.KissLabel();
            this.edtBeteiligte = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblBetroffeneLebensbereiche = new KiSS4.Gui.KissLabel();
            this.edtBetroffeneLebensbereiche = new KiSS4.Gui.KissCheckedLookupEdit();
            this.docDokumente = new KiSS4.Dokument.KissDocumentButton();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAktennotizen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaAktennotizen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAktennotizen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAutor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStichworte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStichworte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheInhalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheInhalt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDienstleistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDienstleistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDienstleistung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDienstleistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktArt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAutor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichworte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichworte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInhalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeteiligte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeteiligte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetroffeneLebensbereiche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetroffeneLebensbereiche)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(715, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Location = new System.Drawing.Point(0, 29);
            this.tabControlSearch.Size = new System.Drawing.Size(739, 215);
            this.tabControlSearch.TabIndex = 1;
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdAktennotizen);
            this.tpgListe.Size = new System.Drawing.Size(727, 177);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSucheDienstleistung);
            this.tpgSuchen.Controls.Add(this.lblSucheDienstleistung);
            this.tpgSuchen.Controls.Add(this.edtSucheInhalt);
            this.tpgSuchen.Controls.Add(this.lblSucheInhalt);
            this.tpgSuchen.Controls.Add(this.edtSucheStichworte);
            this.tpgSuchen.Controls.Add(this.lblSucheStichworte);
            this.tpgSuchen.Controls.Add(this.edtSucheAutor);
            this.tpgSuchen.Controls.Add(this.lblSucheAutor);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumVon);
            this.tpgSuchen.Size = new System.Drawing.Size(727, 177);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheAutor, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAutor, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheStichworte, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStichworte, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheInhalt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheInhalt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDienstleistung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDienstleistung, 0);
            //
            // panTitel
            //
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(739, 30);
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
            this.lblTitel.Size = new System.Drawing.Size(587, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Aktennotizen";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // grdAktennotizen
            //
            this.grdAktennotizen.DataSource = this.qryFaAktennotizen;
            this.grdAktennotizen.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdAktennotizen.EmbeddedNavigator.Name = "";
            this.grdAktennotizen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAktennotizen.Location = new System.Drawing.Point(0, 0);
            this.grdAktennotizen.MainView = this.grvAktennotizen;
            this.grdAktennotizen.Name = "grdAktennotizen";
            this.grdAktennotizen.SelectLastPosition = true;
            this.grdAktennotizen.Size = new System.Drawing.Size(727, 177);
            this.grdAktennotizen.TabIndex = 0;
            this.grdAktennotizen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAktennotizen});
            //
            // qryFaAktennotizen
            //
            this.qryFaAktennotizen.CanDelete = true;
            this.qryFaAktennotizen.CanInsert = true;
            this.qryFaAktennotizen.CanUpdate = true;
            this.qryFaAktennotizen.HostControl = this;
            this.qryFaAktennotizen.IsIdentityInsert = false;
            this.qryFaAktennotizen.SelectStatement = resources.GetString("qryFaAktennotizen.SelectStatement");
            this.qryFaAktennotizen.TableName = "FaAktennotizen";
            this.qryFaAktennotizen.AfterFill += new System.EventHandler(this.qryFaAktennotizen_AfterFill);
            this.qryFaAktennotizen.AfterInsert += new System.EventHandler(this.qryFaAktennotizen_AfterInsert);
            this.qryFaAktennotizen.AfterPost += new System.EventHandler(this.qryFaAktennotizen_AfterPost);
            this.qryFaAktennotizen.BeforePost += new System.EventHandler(this.qryFaAktennotizen_BeforePost);
            this.qryFaAktennotizen.PositionChanged += new System.EventHandler(this.qryFaAktennotizen_PositionChanged);
            //
            // grvAktennotizen
            //
            this.grvAktennotizen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAktennotizen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAktennotizen.Appearance.Empty.Options.UseBackColor = true;
            this.grvAktennotizen.Appearance.Empty.Options.UseFont = true;
            this.grvAktennotizen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAktennotizen.Appearance.EvenRow.Options.UseFont = true;
            this.grvAktennotizen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAktennotizen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAktennotizen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAktennotizen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAktennotizen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAktennotizen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAktennotizen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAktennotizen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAktennotizen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAktennotizen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAktennotizen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAktennotizen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAktennotizen.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAktennotizen.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAktennotizen.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvAktennotizen.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvAktennotizen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAktennotizen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAktennotizen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAktennotizen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAktennotizen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAktennotizen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAktennotizen.Appearance.GroupRow.Options.UseFont = true;
            this.grvAktennotizen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAktennotizen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAktennotizen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAktennotizen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAktennotizen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAktennotizen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAktennotizen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAktennotizen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAktennotizen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAktennotizen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAktennotizen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAktennotizen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAktennotizen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAktennotizen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAktennotizen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAktennotizen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAktennotizen.Appearance.OddRow.Options.UseFont = true;
            this.grvAktennotizen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAktennotizen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAktennotizen.Appearance.Row.Options.UseBackColor = true;
            this.grvAktennotizen.Appearance.Row.Options.UseFont = true;
            this.grvAktennotizen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAktennotizen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAktennotizen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAktennotizen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAktennotizen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAktennotizen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFaAktennotizenID,
            this.colDatum,
            this.colAutor,
            this.colDienstleistung,
            this.colKontaktArt,
            this.colStichworte,
            this.colThemen});
            this.grvAktennotizen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAktennotizen.GridControl = this.grdAktennotizen;
            this.grvAktennotizen.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvAktennotizen.Name = "grvAktennotizen";
            this.grvAktennotizen.OptionsBehavior.Editable = false;
            this.grvAktennotizen.OptionsCustomization.AllowFilter = false;
            this.grvAktennotizen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAktennotizen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAktennotizen.OptionsNavigation.UseTabKey = false;
            this.grvAktennotizen.OptionsView.ColumnAutoWidth = false;
            this.grvAktennotizen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAktennotizen.OptionsView.ShowGroupPanel = false;
            this.grvAktennotizen.OptionsView.ShowIndicator = false;
            //
            // colFaAktennotizenID
            //
            this.colFaAktennotizenID.Caption = "FaAktennotizenID";
            this.colFaAktennotizenID.FieldName = "FaAktennotizenID";
            this.colFaAktennotizenID.Name = "colFaAktennotizenID";
            //
            // colDatum
            //
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 80;
            //
            // colAutor
            //
            this.colAutor.Caption = "Autor/in";
            this.colAutor.FieldName = "Autor";
            this.colAutor.Name = "colAutor";
            this.colAutor.Visible = true;
            this.colAutor.VisibleIndex = 1;
            this.colAutor.Width = 130;
            //
            // colDienstleistung
            //
            this.colDienstleistung.Caption = "Dienstleistung";
            this.colDienstleistung.FieldName = "Dienstleistung";
            this.colDienstleistung.Name = "colDienstleistung";
            this.colDienstleistung.Visible = true;
            this.colDienstleistung.VisibleIndex = 2;
            this.colDienstleistung.Width = 130;
            //
            // colKontaktArt
            //
            this.colKontaktArt.Caption = "Kontaktart";
            this.colKontaktArt.FieldName = "KontaktArt";
            this.colKontaktArt.Name = "colKontaktArt";
            this.colKontaktArt.Visible = true;
            this.colKontaktArt.VisibleIndex = 3;
            this.colKontaktArt.Width = 130;
            //
            // colStichworte
            //
            this.colStichworte.Caption = "Stichworte";
            this.colStichworte.FieldName = "Stichworte";
            this.colStichworte.Name = "colStichworte";
            this.colStichworte.Visible = true;
            this.colStichworte.VisibleIndex = 4;
            this.colStichworte.Width = 190;
            //
            // colThemen
            //
            this.colThemen.Caption = "Themen";
            this.colThemen.FieldName = "Themen";
            this.colThemen.Name = "colThemen";
            this.colThemen.Visible = true;
            this.colThemen.VisibleIndex = 5;
            this.colThemen.Width = 190;
            //
            // lblSucheDatumVon
            //
            this.lblSucheDatumVon.Location = new System.Drawing.Point(8, 36);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(89, 24);
            this.lblSucheDatumVon.TabIndex = 1;
            this.lblSucheDatumVon.Text = "Datum";
            this.lblSucheDatumVon.UseCompatibleTextRendering = true;
            //
            // edtSucheDatumVon
            //
            this.edtSucheDatumVon.EditValue = null;
            this.edtSucheDatumVon.Location = new System.Drawing.Point(103, 36);
            this.edtSucheDatumVon.Name = "edtSucheDatumVon";
            this.edtSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumVon.Properties.ShowToday = false;
            this.edtSucheDatumVon.Size = new System.Drawing.Size(101, 24);
            this.edtSucheDatumVon.TabIndex = 2;
            //
            // lblSucheDatumBis
            //
            this.lblSucheDatumBis.Location = new System.Drawing.Point(210, 36);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(34, 24);
            this.lblSucheDatumBis.TabIndex = 3;
            this.lblSucheDatumBis.Text = "bis";
            this.lblSucheDatumBis.UseCompatibleTextRendering = true;
            //
            // edtSucheDatumBis
            //
            this.edtSucheDatumBis.EditValue = null;
            this.edtSucheDatumBis.Location = new System.Drawing.Point(250, 36);
            this.edtSucheDatumBis.Name = "edtSucheDatumBis";
            this.edtSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumBis.Properties.ShowToday = false;
            this.edtSucheDatumBis.Size = new System.Drawing.Size(101, 24);
            this.edtSucheDatumBis.TabIndex = 4;
            //
            // lblSucheAutor
            //
            this.lblSucheAutor.Location = new System.Drawing.Point(8, 96);
            this.lblSucheAutor.Name = "lblSucheAutor";
            this.lblSucheAutor.Size = new System.Drawing.Size(89, 24);
            this.lblSucheAutor.TabIndex = 5;
            this.lblSucheAutor.Text = "Autor/in";
            this.lblSucheAutor.UseCompatibleTextRendering = true;
            //
            // edtSucheAutor
            //
            this.edtSucheAutor.Location = new System.Drawing.Point(103, 96);
            this.edtSucheAutor.Name = "edtSucheAutor";
            this.edtSucheAutor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAutor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAutor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAutor.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAutor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAutor.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAutor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheAutor.Size = new System.Drawing.Size(248, 24);
            this.edtSucheAutor.TabIndex = 6;
            //
            // lblSucheStichworte
            //
            this.lblSucheStichworte.Location = new System.Drawing.Point(373, 36);
            this.lblSucheStichworte.Name = "lblSucheStichworte";
            this.lblSucheStichworte.Size = new System.Drawing.Size(89, 24);
            this.lblSucheStichworte.TabIndex = 7;
            this.lblSucheStichworte.Text = "Stichwort(e)";
            this.lblSucheStichworte.UseCompatibleTextRendering = true;
            //
            // edtSucheStichworte
            //
            this.edtSucheStichworte.Location = new System.Drawing.Point(468, 36);
            this.edtSucheStichworte.Name = "edtSucheStichworte";
            this.edtSucheStichworte.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStichworte.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStichworte.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStichworte.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStichworte.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStichworte.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStichworte.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheStichworte.Size = new System.Drawing.Size(248, 24);
            this.edtSucheStichworte.TabIndex = 8;
            //
            // lblSucheInhalt
            //
            this.lblSucheInhalt.Location = new System.Drawing.Point(373, 66);
            this.lblSucheInhalt.Name = "lblSucheInhalt";
            this.lblSucheInhalt.Size = new System.Drawing.Size(89, 24);
            this.lblSucheInhalt.TabIndex = 9;
            this.lblSucheInhalt.Text = "Inhalt";
            this.lblSucheInhalt.UseCompatibleTextRendering = true;
            //
            // edtSucheInhalt
            //
            this.edtSucheInhalt.Location = new System.Drawing.Point(468, 66);
            this.edtSucheInhalt.Name = "edtSucheInhalt";
            this.edtSucheInhalt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheInhalt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheInhalt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheInhalt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheInhalt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheInhalt.Properties.Appearance.Options.UseFont = true;
            this.edtSucheInhalt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheInhalt.Size = new System.Drawing.Size(248, 24);
            this.edtSucheInhalt.TabIndex = 10;
            //
            // lblSucheDienstleistung
            //
            this.lblSucheDienstleistung.Location = new System.Drawing.Point(8, 66);
            this.lblSucheDienstleistung.Name = "lblSucheDienstleistung";
            this.lblSucheDienstleistung.Size = new System.Drawing.Size(89, 24);
            this.lblSucheDienstleistung.TabIndex = 11;
            this.lblSucheDienstleistung.Text = "Dienstleistung";
            this.lblSucheDienstleistung.UseCompatibleTextRendering = true;
            //
            // edtSucheDienstleistung
            //
            this.edtSucheDienstleistung.Location = new System.Drawing.Point(103, 66);
            this.edtSucheDienstleistung.LOVName = "FaModulDienstleistungen";
            this.edtSucheDienstleistung.Name = "edtSucheDienstleistung";
            this.edtSucheDienstleistung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDienstleistung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDienstleistung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDienstleistung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDienstleistung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDienstleistung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDienstleistung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheDienstleistung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDienstleistung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheDienstleistung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheDienstleistung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheDienstleistung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheDienstleistung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDienstleistung.Properties.NullText = "";
            this.edtSucheDienstleistung.Properties.ShowFooter = false;
            this.edtSucheDienstleistung.Properties.ShowHeader = false;
            this.edtSucheDienstleistung.Size = new System.Drawing.Size(248, 24);
            this.edtSucheDienstleistung.TabIndex = 12;
            //
            // lblDatum
            //
            this.lblDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatum.Location = new System.Drawing.Point(6, 250);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(89, 24);
            this.lblDatum.TabIndex = 2;
            this.lblDatum.Text = "Datum";
            this.lblDatum.UseCompatibleTextRendering = true;
            //
            // edtDatum
            //
            this.edtDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatum.DataMember = "Datum";
            this.edtDatum.DataSource = this.qryFaAktennotizen;
            this.edtDatum.EditValue = null;
            this.edtDatum.Location = new System.Drawing.Point(101, 250);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatum.Properties.ShowToday = false;
            this.edtDatum.Size = new System.Drawing.Size(111, 24);
            this.edtDatum.TabIndex = 3;
            //
            // lblDienstleistung
            //
            this.lblDienstleistung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDienstleistung.Location = new System.Drawing.Point(6, 280);
            this.lblDienstleistung.Name = "lblDienstleistung";
            this.lblDienstleistung.Size = new System.Drawing.Size(89, 24);
            this.lblDienstleistung.TabIndex = 4;
            this.lblDienstleistung.Text = "Dienstleistung";
            this.lblDienstleistung.UseCompatibleTextRendering = true;
            //
            // edtDienstleistung
            //
            this.edtDienstleistung.AllowNull = false;
            this.edtDienstleistung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDienstleistung.DataMember = "DienstleistungCode";
            this.edtDienstleistung.DataSource = this.qryFaAktennotizen;
            this.edtDienstleistung.Location = new System.Drawing.Point(101, 280);
            this.edtDienstleistung.LOVName = "FaModulDienstleistungen";
            this.edtDienstleistung.Name = "edtDienstleistung";
            this.edtDienstleistung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDienstleistung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDienstleistung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDienstleistung.Properties.Appearance.Options.UseBackColor = true;
            this.edtDienstleistung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDienstleistung.Properties.Appearance.Options.UseFont = true;
            this.edtDienstleistung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDienstleistung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDienstleistung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDienstleistung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDienstleistung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDienstleistung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDienstleistung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDienstleistung.Properties.NullText = "";
            this.edtDienstleistung.Properties.ShowFooter = false;
            this.edtDienstleistung.Properties.ShowHeader = false;
            this.edtDienstleistung.Size = new System.Drawing.Size(250, 24);
            this.edtDienstleistung.TabIndex = 5;
            //
            // lblKontaktArt
            //
            this.lblKontaktArt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKontaktArt.Location = new System.Drawing.Point(6, 310);
            this.lblKontaktArt.Name = "lblKontaktArt";
            this.lblKontaktArt.Size = new System.Drawing.Size(89, 24);
            this.lblKontaktArt.TabIndex = 6;
            this.lblKontaktArt.Text = "Kontaktart";
            this.lblKontaktArt.UseCompatibleTextRendering = true;
            //
            // edtKontaktArt
            //
            this.edtKontaktArt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKontaktArt.DataMember = "KontaktArtCode";
            this.edtKontaktArt.DataSource = this.qryFaAktennotizen;
            this.edtKontaktArt.Location = new System.Drawing.Point(101, 310);
            this.edtKontaktArt.LOVName = "FaKontaktart";
            this.edtKontaktArt.Name = "edtKontaktArt";
            this.edtKontaktArt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktArt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktArt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktArt.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktArt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktArt.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktArt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKontaktArt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktArt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKontaktArt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKontaktArt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtKontaktArt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtKontaktArt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontaktArt.Properties.NullText = "";
            this.edtKontaktArt.Properties.ShowFooter = false;
            this.edtKontaktArt.Properties.ShowHeader = false;
            this.edtKontaktArt.Size = new System.Drawing.Size(250, 24);
            this.edtKontaktArt.TabIndex = 7;
            //
            // lblAutor
            //
            this.lblAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAutor.Location = new System.Drawing.Point(6, 340);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(89, 24);
            this.lblAutor.TabIndex = 8;
            this.lblAutor.Text = "Autor/in";
            this.lblAutor.UseCompatibleTextRendering = true;
            //
            // edtAutor
            //
            this.edtAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAutor.DataMember = "Autor";
            this.edtAutor.DataSource = this.qryFaAktennotizen;
            this.edtAutor.Location = new System.Drawing.Point(101, 340);
            this.edtAutor.Name = "edtAutor";
            this.edtAutor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAutor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAutor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAutor.Properties.Appearance.Options.UseBackColor = true;
            this.edtAutor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAutor.Properties.Appearance.Options.UseFont = true;
            this.edtAutor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtAutor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtAutor.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAutor.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtAutor.Size = new System.Drawing.Size(250, 24);
            this.edtAutor.TabIndex = 9;
            this.edtAutor.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtAutor_UserModifiedFld);
            this.edtAutor.EditValueChanged += new System.EventHandler(this.edtAutor_EditValueChanged);
            //
            // lblStichworte
            //
            this.lblStichworte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStichworte.Location = new System.Drawing.Point(6, 370);
            this.lblStichworte.Name = "lblStichworte";
            this.lblStichworte.Size = new System.Drawing.Size(89, 24);
            this.lblStichworte.TabIndex = 10;
            this.lblStichworte.Text = "Stichwort(e)";
            this.lblStichworte.UseCompatibleTextRendering = true;
            //
            // edtStichworte
            //
            this.edtStichworte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStichworte.DataMember = "Stichworte";
            this.edtStichworte.DataSource = this.qryFaAktennotizen;
            this.edtStichworte.Location = new System.Drawing.Point(101, 370);
            this.edtStichworte.Name = "edtStichworte";
            this.edtStichworte.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichworte.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichworte.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichworte.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichworte.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichworte.Properties.Appearance.Options.UseFont = true;
            this.edtStichworte.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichworte.Properties.MaxLength = 100;
            this.edtStichworte.Size = new System.Drawing.Size(402, 24);
            this.edtStichworte.TabIndex = 11;
            //
            // lblInhalt
            //
            this.lblInhalt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInhalt.Location = new System.Drawing.Point(6, 400);
            this.lblInhalt.Name = "lblInhalt";
            this.lblInhalt.Size = new System.Drawing.Size(89, 24);
            this.lblInhalt.TabIndex = 12;
            this.lblInhalt.Text = "Inhalt";
            this.lblInhalt.UseCompatibleTextRendering = true;
            //
            // memInhalt
            //
            this.memInhalt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memInhalt.BackColor = System.Drawing.Color.White;
            this.memInhalt.DataMember = "Inhalt";
            this.memInhalt.DataSource = this.qryFaAktennotizen;
            this.memInhalt.Font = new System.Drawing.Font("Arial", 10F);
            this.memInhalt.Location = new System.Drawing.Point(101, 400);
            this.memInhalt.Name = "memInhalt";
            this.memInhalt.Size = new System.Drawing.Size(402, 187);
            this.memInhalt.TabIndex = 13;
            //
            // lblBeteiligte
            //
            this.lblBeteiligte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBeteiligte.Location = new System.Drawing.Point(521, 250);
            this.lblBeteiligte.Name = "lblBeteiligte";
            this.lblBeteiligte.Size = new System.Drawing.Size(211, 24);
            this.lblBeteiligte.TabIndex = 14;
            this.lblBeteiligte.Text = "Beteiligte Personen und Institutionen";
            this.lblBeteiligte.UseCompatibleTextRendering = true;
            //
            // edtBeteiligte
            //
            this.edtBeteiligte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBeteiligte.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBeteiligte.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeteiligte.Appearance.Options.UseBackColor = true;
            this.edtBeteiligte.Appearance.Options.UseBorderColor = true;
            this.edtBeteiligte.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtBeteiligte.CheckOnClick = true;
            this.edtBeteiligte.DataMember = "BeteiligtePersonen";
            this.edtBeteiligte.DataSource = this.qryFaAktennotizen;
            this.edtBeteiligte.Location = new System.Drawing.Point(521, 277);
            this.edtBeteiligte.Name = "edtBeteiligte";
            this.edtBeteiligte.Size = new System.Drawing.Size(211, 87);
            this.edtBeteiligte.TabIndex = 15;
            //
            // lblBetroffeneLebensbereiche
            //
            this.lblBetroffeneLebensbereiche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBetroffeneLebensbereiche.Location = new System.Drawing.Point(521, 370);
            this.lblBetroffeneLebensbereiche.Name = "lblBetroffeneLebensbereiche";
            this.lblBetroffeneLebensbereiche.Size = new System.Drawing.Size(211, 24);
            this.lblBetroffeneLebensbereiche.TabIndex = 16;
            this.lblBetroffeneLebensbereiche.Text = "Betroffene Lebensbereiche";
            this.lblBetroffeneLebensbereiche.UseCompatibleTextRendering = true;
            //
            // edtBetroffeneLebensbereiche
            //
            this.edtBetroffeneLebensbereiche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBetroffeneLebensbereiche.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetroffeneLebensbereiche.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetroffeneLebensbereiche.Appearance.Options.UseBackColor = true;
            this.edtBetroffeneLebensbereiche.Appearance.Options.UseBorderColor = true;
            this.edtBetroffeneLebensbereiche.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtBetroffeneLebensbereiche.CheckOnClick = true;
            this.edtBetroffeneLebensbereiche.DataMember = "ThemenCodes";
            this.edtBetroffeneLebensbereiche.DataSource = this.qryFaAktennotizen;
            this.edtBetroffeneLebensbereiche.Location = new System.Drawing.Point(521, 400);
            this.edtBetroffeneLebensbereiche.LOVName = "FaLebensbereich";
            this.edtBetroffeneLebensbereiche.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtBetroffeneLebensbereiche.Name = "edtBetroffeneLebensbereiche";
            this.edtBetroffeneLebensbereiche.Size = new System.Drawing.Size(211, 187);
            this.edtBetroffeneLebensbereiche.TabIndex = 17;
            //
            // docDokumente
            //
            this.docDokumente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.docDokumente.Context = "FA_Aktenotizen";
            this.docDokumente.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.docDokumente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docDokumente.Image = ((System.Drawing.Image)(resources.GetObject("docDokumente.Image")));
            this.docDokumente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.docDokumente.Location = new System.Drawing.Point(628, 3);
            this.docDokumente.Name = "docDokumente";
            this.docDokumente.Size = new System.Drawing.Size(108, 24);
            this.docDokumente.TabIndex = 18;
            this.docDokumente.Text = "Dokumente";
            this.docDokumente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.docDokumente.UseCompatibleTextRendering = true;
            this.docDokumente.UseVisualStyleBackColor = false;
            //
            // CtlFaAktennotizen
            //
            this.ActiveSQLQuery = this.qryFaAktennotizen;
            this.Controls.Add(this.docDokumente);
            this.Controls.Add(this.edtBetroffeneLebensbereiche);
            this.Controls.Add(this.lblBetroffeneLebensbereiche);
            this.Controls.Add(this.edtBeteiligte);
            this.Controls.Add(this.lblBeteiligte);
            this.Controls.Add(this.memInhalt);
            this.Controls.Add(this.lblInhalt);
            this.Controls.Add(this.edtStichworte);
            this.Controls.Add(this.lblStichworte);
            this.Controls.Add(this.edtAutor);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.edtKontaktArt);
            this.Controls.Add(this.lblKontaktArt);
            this.Controls.Add(this.edtDienstleistung);
            this.Controls.Add(this.lblDienstleistung);
            this.Controls.Add(this.edtDatum);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.panTitel);
            this.Name = "CtlFaAktennotizen";
            this.Size = new System.Drawing.Size(739, 596);
            this.Load += new System.EventHandler(this.CtlFaAktennotizen_Load);
            this.Controls.SetChildIndex(this.panTitel, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.lblDatum, 0);
            this.Controls.SetChildIndex(this.edtDatum, 0);
            this.Controls.SetChildIndex(this.lblDienstleistung, 0);
            this.Controls.SetChildIndex(this.edtDienstleistung, 0);
            this.Controls.SetChildIndex(this.lblKontaktArt, 0);
            this.Controls.SetChildIndex(this.edtKontaktArt, 0);
            this.Controls.SetChildIndex(this.lblAutor, 0);
            this.Controls.SetChildIndex(this.edtAutor, 0);
            this.Controls.SetChildIndex(this.lblStichworte, 0);
            this.Controls.SetChildIndex(this.edtStichworte, 0);
            this.Controls.SetChildIndex(this.lblInhalt, 0);
            this.Controls.SetChildIndex(this.memInhalt, 0);
            this.Controls.SetChildIndex(this.lblBeteiligte, 0);
            this.Controls.SetChildIndex(this.edtBeteiligte, 0);
            this.Controls.SetChildIndex(this.lblBetroffeneLebensbereiche, 0);
            this.Controls.SetChildIndex(this.edtBetroffeneLebensbereiche, 0);
            this.Controls.SetChildIndex(this.docDokumente, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAktennotizen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaAktennotizen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAktennotizen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAutor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStichworte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStichworte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheInhalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheInhalt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDienstleistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDienstleistung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDienstleistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDienstleistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktArt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAutor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichworte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichworte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInhalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeteiligte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeteiligte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetroffeneLebensbereiche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetroffeneLebensbereiche)).EndInit();
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

        private void CtlFaAktennotizen_Load(object sender, System.EventArgs e)
        {
            // update enabled/disabled
            UpdateEnabledMode();
        }

        private void edtAutor_EditValueChanged(object sender, System.EventArgs e)
        {
            // data has changed
            _hasAutorChanged = true;
        }

        private void edtAutor_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogAutor(sender, e);
        }

        private void qryFaAktennotizen_AfterFill(object sender, System.EventArgs e)
        {
            // update enabled/disabled
            UpdateEnabledMode();

            // fill Beteiligte Personen und Institutionen
            UpdateBeteiligtePersonenInstitutionen();
        }

        private void qryFaAktennotizen_AfterInsert(object sender, System.EventArgs e)
        {
            // apply person id
            qryFaAktennotizen["BaPersonID"] = _baPersonID;

            // apply default values
            qryFaAktennotizen["Autor"] = this._userFullName;
            qryFaAktennotizen["UserID"] = Session.User.UserID;

            // set focus
            edtDatum.Focus();
        }

        private void qryFaAktennotizen_AfterPost(object sender, System.EventArgs e)
        {
            // apply lookup fields
            qryFaAktennotizen["KontaktArt"] = edtKontaktArt.Text;
            qryFaAktennotizen["Dienstleistung"] = edtDienstleistung.Text;
            qryFaAktennotizen["Themen"] = edtBetroffeneLebensbereiche.GetDisplayText(Convert.ToString(edtBetroffeneLebensbereiche.EditValue));
        }

        private void qryFaAktennotizen_BeforePost(object sender, System.EventArgs e)
        {
            // validate must fields
            DBUtil.CheckNotNullField(edtDatum, lblDatum.Text);
            DBUtil.CheckNotNullField(edtDienstleistung, lblDienstleistung.Text);
            DBUtil.CheckNotNullField(edtAutor, lblAutor.Text);

            // validate buttonedits
            if (this._hasAutorChanged && !this.DialogAutor(this, new UserModifiedFldEventArgs(false, false)))
            {
                // invalid Autor
                edtAutor.Focus();
                throw new KissCancelException();
            }

            // reset flags
            _hasAutorChanged = false;
        }

        private void qryFaAktennotizen_PositionChanged(object sender, System.EventArgs e)
        {
            // update enabled/disabled
            UpdateEnabledMode();

            // fill Beteiligte Personen und Institutionen
            UpdateBeteiligtePersonenInstitutionen();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Get the desired context value for given parameter
        /// </summary>
        /// <param name="FieldName">The fieldname to get context value for</param>
        /// <returns>The value found if any found</returns>
        public override object GetContextValue(String fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "FAAKTENNOTIZENID":
                    return qryFaAktennotizen["FaAktennotizenID"];

                case "BAPERSONID":
                    return this._baPersonID;

                case "LANGUAGECODE":
                    return Session.User.LanguageCode;

                case "SELECTEDIDLIST":
                    // check if we have any data
                    if (qryFaAktennotizen.Count > 0)
                    {
                        // init var
                        String idList = "";

                        // loop shown entries and get id from each line
                        for (Int32 i = 0; i < grvAktennotizen.DataRowCount; i++)
                        {
                            if (idList.Length > 0)
                            {
                                idList += ",";
                            }

                            idList += grvAktennotizen.GetRowCellValue(i, colFaAktennotizenID).ToString();
                        }

                        // done, return ids as csv
                        return idList;
                    }
                    else
                    {
                        // no entry found
                        return "NULL";
                    }

                case "SEARCHVALUES":
                    // init var
                    String searchValues = "";

                    // DatumVon-DatumBis
                    if (!DBUtil.IsEmpty(edtSucheDatumVon.Text) && !DBUtil.IsEmpty(edtSucheDatumBis.Text))
                    {
                        searchValues = AppendSearchValue(searchValues, String.Format("{0} - {1}", edtSucheDatumVon.Text, edtSucheDatumBis.Text), KissMsg.GetMLMessage("CtlFaAktennotizen", "ContextSearchValuesDatum", "Datum"));
                    }
                    else
                    {
                        searchValues = AppendSearchValue(searchValues, edtSucheDatumVon.Text, lblSucheDatumVon.Text);
                        searchValues = AppendSearchValue(searchValues, edtSucheDatumBis.Text, lblSucheDatumBis.Text);
                    }

                    // other search values
                    searchValues = AppendSearchValue(searchValues, edtSucheDienstleistung.Text, lblSucheDienstleistung.Text);
                    searchValues = AppendSearchValue(searchValues, edtSucheAutor.Text, lblSucheAutor.Text);
                    searchValues = AppendSearchValue(searchValues, edtSucheStichworte.Text, lblSucheStichworte.Text);
                    searchValues = AppendSearchValue(searchValues, edtSucheInhalt.Text, lblSucheInhalt.Text);

                    // check if any defined
                    if (DBUtil.IsEmpty(searchValues))
                    {
                        return "-";
                    }

                    // return defined values
                    return searchValues;
            }

            return base.GetContextValue(fieldName);
        }

        /// <summary>
        /// Init the control for person
        /// </summary>
        /// <param name="titleName">The title text to apply</param>
        /// <param name="titleImage">The title image to apply</param>
        /// <param name="baPersonID">The id of the person to use for data</param>
        public void Init(string titleName, Image titleImage, int baPersonID)
        {
            // validate
            if (baPersonID < 1)
            {
                // do not continue
                qryFaAktennotizen.CanInsert = false;
                qryFaAktennotizen.CanUpdate = false;
                qryFaAktennotizen.CanDelete = false;

                // setup field
                _queryCanUpdateDelete = false;

                // handle editmode of controls
                qryFaAktennotizen.EnableBoundFields(qryFaAktennotizen.CanUpdate);
                return;
            }

            // allow changes
            qryFaAktennotizen.CanInsert = true;
            qryFaAktennotizen.CanUpdate = true;
            qryFaAktennotizen.CanDelete = true;

            // apply values
            _baPersonID = baPersonID;
            picTitel.Image = titleImage;
            lblTitel.Text = titleName;

            // new search
            NewSearch();
            tabControlSearch.SelectTab(tpgListe);

            // select last row
            qryFaAktennotizen.Last();

            // setup field
            _queryCanUpdateDelete = true;

            // reset flags
            _hasAutorChanged = false;
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // focus
            this.edtSucheDatumVon.Focus();
        }

        protected override void RunSearch()
        {
            // replace search parameters
            Object[] parameters = new Object[] { this._baPersonID, Session.User.LanguageCode };
            this.kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private String AppendSearchValue(String searchValues, String fieldContent, String fieldLabel)
        {
            // check if value is set
            if (DBUtil.IsEmpty(fieldContent))
            {
                // no content defined, return given value
                return searchValues;
            }

            // check if need to append ","
            if (!DBUtil.IsEmpty(searchValues))
            {
                searchValues += ", ";
            }

            // append value
            searchValues += String.Format("{0} = '{1}'", fieldLabel, fieldContent);

            // done, return value
            return searchValues;
        }

        private bool DialogAutor(Object sender, UserModifiedFldEventArgs e)
        {
            try
            {
                // check if data can be altered
                if (!qryFaAktennotizen.CanUpdate || qryFaAktennotizen.Count < 1 || edtAutor.EditMode == EditModeType.ReadOnly)
                {
                    // do nothing
                    return true;
                }

                // prepare search string
                String searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edtAutor.EditValue))
                {
                    // prepare for database search
                    searchString = edtAutor.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        qryFaAktennotizen["UserID"] = DBNull.Value;
                        qryFaAktennotizen["Autor"] = DBNull.Value;
                        return true;
                    }
                }

                // Mitarbeiter_Suchen()
                KissLookupDialog dlg = new KissLookupDialog();

                e.Cancel = !dlg.SearchData(String.Format(@"
                    SELECT USR.*
                    FROM dbo.fnDlgMitarbeiterSuchenKGS({0}) USR
                    WHERE USR.Name LIKE '{1}%'", Session.User.UserID, searchString), searchString, e.ButtonClicked, null, null, null);

                if (!e.Cancel)
                {
                    // apply new value
                    qryFaAktennotizen["UserID"] = dlg["UserID$"];
                    qryFaAktennotizen["Autor"] = dlg["Name"];

                    // reset flags
                    this._hasAutorChanged = false;

                    // success
                    return true;
                }
                else
                {
                    // canceled or error
                    return false;
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlFaAktennotizen", "ErrorIKissUserModified", "Fehler bei der Verarbeitung.", ex);
                return false;
            }
        }

        /// <summary>
        /// Refresh list of "Beteiligte Personen und Institutionen"
        /// </summary>
        private void UpdateBeteiligtePersonenInstitutionen()
        {
            // fill Beteiligte Personen und Institutionen
            edtBeteiligte.LookupSQL = string.Format(@"
                SELECT FCN.*
                FROM dbo.fnFaGetBeteiligtePersonenInstitutionen({0}, {1}) FCN;", DBUtil.SqlLiteral(_baPersonID), DBUtil.SqlLiteral(qryFaAktennotizen[edtBeteiligte.DataMember]));

            // set check-states from current edit-value
            edtBeteiligte.EditValue = DBUtil.IsEmpty(qryFaAktennotizen[edtBeteiligte.DataMember]) ? null : Convert.ToString(qryFaAktennotizen[edtBeteiligte.DataMember]);
        }

        private void UpdateEnabledMode()
        {
            // check if we have any data
            if (qryFaAktennotizen.Count < 1)
            {
                // do nothing change
                return;
            }

            // depending on selected value, the user can update or cannot update values
            qryFaAktennotizen.CanUpdate = this._queryCanUpdateDelete && (DBUtil.IsEmpty(qryFaAktennotizen["Schreibgeschuetzt"]) || !Convert.ToBoolean(qryFaAktennotizen["Schreibgeschuetzt"]));
            qryFaAktennotizen.CanDelete = qryFaAktennotizen.CanUpdate;

            // handle editmode of controls
            qryFaAktennotizen.EnableBoundFields(qryFaAktennotizen.CanUpdate);
        }

        #endregion

        #endregion
    }
}