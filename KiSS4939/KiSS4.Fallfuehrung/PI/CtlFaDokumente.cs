using System;
using System.Collections.Generic;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung.PI
{
    /// <summary>
    /// Control, used to manage documents of clients
    /// </summary>
    public class CtlFaDokumente : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private Dictionary<int, int> _baInstitutionKontaktIdOfBookmarkDlgToFaDokID;
        private int _baPersonID = -1;
        private string _benutzerMLText = "";
        private bool _hasAdressatChanged = false;
        private bool _hasAutorChanged = false;
        private string _institutionMLText = "";
        private string _personMLText = "";
        private string _userFullName = "";
        private DevExpress.XtraGrid.Columns.GridColumn colAdressat;
        private DevExpress.XtraGrid.Columns.GridColumn colAutor;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDienstleistung;
        private DevExpress.XtraGrid.Columns.GridColumn colStichworte;
        private DevExpress.XtraGrid.Columns.GridColumn colThemen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissButtonEdit edtAdressat;
        private KiSS4.Gui.KissButtonEdit edtAutor;
        private KiSS4.Gui.KissCheckedLookupEdit edtBetroffeneLebensbereiche;
        private KiSS4.Gui.KissDateEdit edtDatum;
        private KiSS4.Gui.KissLookUpEdit edtDienstleistung;
        private KiSS4.Dokument.XDokument edtDokument;
        private KiSS4.Gui.KissTextEdit edtStichwort;
        private KiSS4.Gui.KissGrid grdDokumente;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDokumente;
        private KiSS4.Gui.KissLabel lblAdressat;
        private KiSS4.Gui.KissLabel lblAdressatOhneInstStamm;
        private KiSS4.Gui.KissLabel lblAutor;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBetroffeneLebensbereiche;
        private KiSS4.Gui.KissLabel lblDatum;
        private KiSS4.Gui.KissLabel lblDienstleistung;
        private KiSS4.Gui.KissLabel lblDokument;
        private KiSS4.Gui.KissLabel lblStichworte;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissMemoEdit memAdressat;
        private KiSS4.Gui.KissMemoEdit memBemerkungen;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaDokumente;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFaDokumente"/> class.
        /// </summary>
        public CtlFaDokumente()
        {
            InitializeComponent();

            // init with default values
            Init(null, null, -1);

            // request userfullname
            _userFullName = Convert.ToString(DBUtil.ExecuteScalarSQL(@"
                SELECT dbo.fnGetLastFirstName({0}, NULL, NULL)", Session.User.UserID));

            // request ML-Values
            _benutzerMLText = KissMsg.GetMLMessage(this.Name, "BenutzerInDialog", "Benutzer");
            _personMLText = KissMsg.GetMLMessage(this.Name, "PersonInDialog", "Person");
            _institutionMLText = KissMsg.GetMLMessage(this.Name, "InstitutionInDialog", "Institution");
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaDokumente));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdDokumente = new KiSS4.Gui.KissGrid();
            this.qryFaDokumente = new KiSS4.DB.SqlQuery(this.components);
            this.grvDokumente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienstleistung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdressat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichworte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThemen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.edtDatum = new KiSS4.Gui.KissDateEdit();
            this.lblDienstleistung = new KiSS4.Gui.KissLabel();
            this.edtDienstleistung = new KiSS4.Gui.KissLookUpEdit();
            this.lblAutor = new KiSS4.Gui.KissLabel();
            this.edtAutor = new KiSS4.Gui.KissButtonEdit();
            this.lblAdressat = new KiSS4.Gui.KissLabel();
            this.edtAdressat = new KiSS4.Gui.KissButtonEdit();
            this.lblAdressatOhneInstStamm = new KiSS4.Gui.KissLabel();
            this.memAdressat = new KiSS4.Gui.KissMemoEdit();
            this.lblStichworte = new KiSS4.Gui.KissLabel();
            this.edtStichwort = new KiSS4.Gui.KissTextEdit();
            this.lblDokument = new KiSS4.Gui.KissLabel();
            this.edtDokument = new KiSS4.Dokument.XDokument();
            this.lblBetroffeneLebensbereiche = new KiSS4.Gui.KissLabel();
            this.edtBetroffeneLebensbereiche = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.memBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDokumente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDienstleistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAutor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressatOhneInstStamm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAdressat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichworte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetroffeneLebensbereiche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetroffeneLebensbereiche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungen.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.lblTitel.Size = new System.Drawing.Size(697, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Dokumente";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // grdDokumente
            //
            this.grdDokumente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDokumente.DataSource = this.qryFaDokumente;
            //
            //
            //
            this.grdDokumente.EmbeddedNavigator.Name = "";
            this.grdDokumente.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdDokumente.Location = new System.Drawing.Point(3, 29);
            this.grdDokumente.MainView = this.grvDokumente;
            this.grdDokumente.Name = "grdDokumente";
            this.grdDokumente.SelectLastPosition = true;
            this.grdDokumente.Size = new System.Drawing.Size(733, 239);
            this.grdDokumente.TabIndex = 1;
            this.grdDokumente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDokumente});
            //
            // qryFaDokumente
            //
            this.qryFaDokumente.CanDelete = true;
            this.qryFaDokumente.CanInsert = true;
            this.qryFaDokumente.CanUpdate = true;
            this.qryFaDokumente.HostControl = this;
            this.qryFaDokumente.IsIdentityInsert = false;
            this.qryFaDokumente.TableName = "FaDokumente";
            this.qryFaDokumente.AfterInsert += new System.EventHandler(this.qryFaDokumente_AfterInsert);
            this.qryFaDokumente.AfterPost += new System.EventHandler(this.qryFaDokumente_AfterPost);
            this.qryFaDokumente.BeforePost += new System.EventHandler(this.qryFaDokumente_BeforePost);
            this.qryFaDokumente.PositionChanged += new System.EventHandler(this.qryFaDokumente_PositionChanged);
            //
            // grvDokumente
            //
            this.grvDokumente.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDokumente.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokumente.Appearance.Empty.Options.UseBackColor = true;
            this.grvDokumente.Appearance.Empty.Options.UseFont = true;
            this.grvDokumente.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokumente.Appearance.EvenRow.Options.UseFont = true;
            this.grvDokumente.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDokumente.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokumente.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvDokumente.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDokumente.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDokumente.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDokumente.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDokumente.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokumente.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDokumente.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDokumente.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDokumente.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDokumente.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDokumente.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDokumente.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvDokumente.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvDokumente.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDokumente.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDokumente.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDokumente.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDokumente.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDokumente.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDokumente.Appearance.GroupRow.Options.UseFont = true;
            this.grvDokumente.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDokumente.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvDokumente.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvDokumente.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDokumente.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDokumente.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDokumente.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDokumente.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvDokumente.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokumente.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDokumente.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDokumente.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDokumente.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDokumente.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvDokumente.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDokumente.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokumente.Appearance.OddRow.Options.UseFont = true;
            this.grvDokumente.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDokumente.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokumente.Appearance.Row.Options.UseBackColor = true;
            this.grvDokumente.Appearance.Row.Options.UseFont = true;
            this.grvDokumente.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokumente.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDokumente.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvDokumente.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDokumente.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvDokumente.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colAutor,
            this.colDienstleistung,
            this.colAdressat,
            this.colStichworte,
            this.colThemen});
            this.grvDokumente.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvDokumente.GridControl = this.grdDokumente;
            this.grvDokumente.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvDokumente.Name = "grvDokumente";
            this.grvDokumente.OptionsBehavior.Editable = false;
            this.grvDokumente.OptionsCustomization.AllowFilter = false;
            this.grvDokumente.OptionsFilter.AllowFilterEditor = false;
            this.grvDokumente.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvDokumente.OptionsNavigation.AutoFocusNewRow = true;
            this.grvDokumente.OptionsNavigation.UseTabKey = false;
            this.grvDokumente.OptionsView.ColumnAutoWidth = false;
            this.grvDokumente.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDokumente.OptionsView.ShowGroupPanel = false;
            this.grvDokumente.OptionsView.ShowIndicator = false;
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
            this.colAutor.Caption = "Autor";
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
            // colAdressat
            //
            this.colAdressat.Caption = "Adressat";
            this.colAdressat.FieldName = "AdressatCol";
            this.colAdressat.Name = "colAdressat";
            this.colAdressat.Visible = true;
            this.colAdressat.VisibleIndex = 3;
            this.colAdressat.Width = 130;
            //
            // colStichworte
            //
            this.colStichworte.Caption = "Stichwort(e)";
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
            // lblDatum
            //
            this.lblDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatum.Location = new System.Drawing.Point(7, 274);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(84, 24);
            this.lblDatum.TabIndex = 2;
            this.lblDatum.Text = "Datum";
            this.lblDatum.UseCompatibleTextRendering = true;
            //
            // edtDatum
            //
            this.edtDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatum.DataMember = "Datum";
            this.edtDatum.DataSource = this.qryFaDokumente;
            this.edtDatum.EditValue = null;
            this.edtDatum.Location = new System.Drawing.Point(97, 274);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatum.Properties.ShowToday = false;
            this.edtDatum.Size = new System.Drawing.Size(90, 24);
            this.edtDatum.TabIndex = 3;
            //
            // lblDienstleistung
            //
            this.lblDienstleistung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDienstleistung.Location = new System.Drawing.Point(7, 304);
            this.lblDienstleistung.Name = "lblDienstleistung";
            this.lblDienstleistung.Size = new System.Drawing.Size(84, 24);
            this.lblDienstleistung.TabIndex = 4;
            this.lblDienstleistung.Text = "Dienstleistung";
            this.lblDienstleistung.UseCompatibleTextRendering = true;
            //
            // edtDienstleistung
            //
            this.edtDienstleistung.AllowNull = false;
            this.edtDienstleistung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDienstleistung.DataMember = "DienstleistungCode";
            this.edtDienstleistung.DataSource = this.qryFaDokumente;
            this.edtDienstleistung.Location = new System.Drawing.Point(97, 304);
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
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtDienstleistung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtDienstleistung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDienstleistung.Properties.NullText = "";
            this.edtDienstleistung.Properties.ShowFooter = false;
            this.edtDienstleistung.Properties.ShowHeader = false;
            this.edtDienstleistung.Size = new System.Drawing.Size(376, 24);
            this.edtDienstleistung.TabIndex = 5;
            //
            // lblAutor
            //
            this.lblAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAutor.Location = new System.Drawing.Point(7, 334);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(84, 24);
            this.lblAutor.TabIndex = 6;
            this.lblAutor.Text = "Autor/in";
            this.lblAutor.UseCompatibleTextRendering = true;
            //
            // edtAutor
            //
            this.edtAutor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAutor.DataMember = "Autor";
            this.edtAutor.DataSource = this.qryFaDokumente;
            this.edtAutor.Location = new System.Drawing.Point(97, 334);
            this.edtAutor.Name = "edtAutor";
            this.edtAutor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAutor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAutor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAutor.Properties.Appearance.Options.UseBackColor = true;
            this.edtAutor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAutor.Properties.Appearance.Options.UseFont = true;
            this.edtAutor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtAutor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtAutor.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAutor.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtAutor.Size = new System.Drawing.Size(376, 24);
            this.edtAutor.TabIndex = 7;
            this.edtAutor.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtAutor_UserModifiedFld);
            this.edtAutor.EditValueChanged += new System.EventHandler(this.edtAutor_EditValueChanged);
            //
            // lblAdressat
            //
            this.lblAdressat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdressat.Location = new System.Drawing.Point(7, 364);
            this.lblAdressat.Name = "lblAdressat";
            this.lblAdressat.Size = new System.Drawing.Size(84, 24);
            this.lblAdressat.TabIndex = 8;
            this.lblAdressat.Text = "Adressat";
            this.lblAdressat.UseCompatibleTextRendering = true;
            //
            // edtAdressat
            //
            this.edtAdressat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAdressat.DataMember = "Adressat";
            this.edtAdressat.DataSource = this.qryFaDokumente;
            this.edtAdressat.Location = new System.Drawing.Point(97, 364);
            this.edtAdressat.Name = "edtAdressat";
            this.edtAdressat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdressat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdressat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdressat.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdressat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdressat.Properties.Appearance.Options.UseFont = true;
            this.edtAdressat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtAdressat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtAdressat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAdressat.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtAdressat.Size = new System.Drawing.Size(376, 24);
            this.edtAdressat.TabIndex = 9;
            this.edtAdressat.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtAdressat_UserModifiedFld);
            this.edtAdressat.EditValueChanged += new System.EventHandler(this.edtAdressat_EditValueChanged);
            //
            // lblAdressatOhneInstStamm
            //
            this.lblAdressatOhneInstStamm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdressatOhneInstStamm.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAdressatOhneInstStamm.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAdressatOhneInstStamm.Location = new System.Drawing.Point(7, 394);
            this.lblAdressatOhneInstStamm.Name = "lblAdressatOhneInstStamm";
            this.lblAdressatOhneInstStamm.Size = new System.Drawing.Size(84, 45);
            this.lblAdressatOhneInstStamm.TabIndex = 10;
            this.lblAdressatOhneInstStamm.Text = "Adressat\r\n(wenn nicht aus Inst.Stamm)";
            this.lblAdressatOhneInstStamm.UseCompatibleTextRendering = true;
            //
            // memAdressat
            //
            this.memAdressat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memAdressat.DataMember = "AdressatText";
            this.memAdressat.DataSource = this.qryFaDokumente;
            this.memAdressat.Location = new System.Drawing.Point(97, 394);
            this.memAdressat.Name = "memAdressat";
            this.memAdressat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memAdressat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memAdressat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memAdressat.Properties.Appearance.Options.UseBackColor = true;
            this.memAdressat.Properties.Appearance.Options.UseBorderColor = true;
            this.memAdressat.Properties.Appearance.Options.UseFont = true;
            this.memAdressat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memAdressat.Size = new System.Drawing.Size(376, 45);
            this.memAdressat.TabIndex = 11;
            //
            // lblStichworte
            //
            this.lblStichworte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStichworte.Location = new System.Drawing.Point(7, 445);
            this.lblStichworte.Name = "lblStichworte";
            this.lblStichworte.Size = new System.Drawing.Size(84, 24);
            this.lblStichworte.TabIndex = 12;
            this.lblStichworte.Text = "Stichwort(e)";
            this.lblStichworte.UseCompatibleTextRendering = true;
            //
            // edtStichwort
            //
            this.edtStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStichwort.DataMember = "Stichworte";
            this.edtStichwort.DataSource = this.qryFaDokumente;
            this.edtStichwort.Location = new System.Drawing.Point(97, 445);
            this.edtStichwort.Name = "edtStichwort";
            this.edtStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichwort.Size = new System.Drawing.Size(376, 24);
            this.edtStichwort.TabIndex = 13;
            //
            // lblDokument
            //
            this.lblDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDokument.Location = new System.Drawing.Point(7, 475);
            this.lblDokument.Name = "lblDokument";
            this.lblDokument.Size = new System.Drawing.Size(84, 24);
            this.lblDokument.TabIndex = 14;
            this.lblDokument.Text = "Dokument";
            this.lblDokument.UseCompatibleTextRendering = true;
            //
            // edtDokument
            //
            this.edtDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDokument.Context = "FA_Dokumente";
            this.edtDokument.DataMember = "DokumentDocID";
            this.edtDokument.DataSource = this.qryFaDokumente;
            this.edtDokument.Location = new System.Drawing.Point(97, 475);
            this.edtDokument.Name = "edtDokument";
            this.edtDokument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDokument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokument.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokument.Properties.Appearance.Options.UseFont = true;
            this.edtDokument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDokument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument importieren")});
            this.edtDokument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokument.Properties.ReadOnly = true;
            this.edtDokument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDokument.Size = new System.Drawing.Size(141, 24);
            this.edtDokument.TabIndex = 15;
            //
            // lblBetroffeneLebensbereiche
            //
            this.lblBetroffeneLebensbereiche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBetroffeneLebensbereiche.Location = new System.Drawing.Point(505, 274);
            this.lblBetroffeneLebensbereiche.Name = "lblBetroffeneLebensbereiche";
            this.lblBetroffeneLebensbereiche.Size = new System.Drawing.Size(213, 24);
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
            this.edtBetroffeneLebensbereiche.DataSource = this.qryFaDokumente;
            this.edtBetroffeneLebensbereiche.Location = new System.Drawing.Point(505, 301);
            this.edtBetroffeneLebensbereiche.LOVName = "FaLebensbereich";
            this.edtBetroffeneLebensbereiche.Name = "edtBetroffeneLebensbereiche";
            this.edtBetroffeneLebensbereiche.Size = new System.Drawing.Size(213, 284);
            this.edtBetroffeneLebensbereiche.TabIndex = 17;
            //
            // lblBemerkungen
            //
            this.lblBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkungen.Location = new System.Drawing.Point(7, 505);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(84, 24);
            this.lblBemerkungen.TabIndex = 18;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            //
            // memBemerkungen
            //
            this.memBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memBemerkungen.DataMember = "Bemerkungen";
            this.memBemerkungen.DataSource = this.qryFaDokumente;
            this.memBemerkungen.Location = new System.Drawing.Point(98, 505);
            this.memBemerkungen.Name = "memBemerkungen";
            this.memBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.memBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkungen.Size = new System.Drawing.Size(375, 80);
            this.memBemerkungen.TabIndex = 19;
            //
            // CtlFaDokumente
            //
            this.ActiveSQLQuery = this.qryFaDokumente;
            this.Controls.Add(this.memBemerkungen);
            this.Controls.Add(this.lblBemerkungen);
            this.Controls.Add(this.edtBetroffeneLebensbereiche);
            this.Controls.Add(this.lblBetroffeneLebensbereiche);
            this.Controls.Add(this.edtDokument);
            this.Controls.Add(this.lblDokument);
            this.Controls.Add(this.edtStichwort);
            this.Controls.Add(this.lblStichworte);
            this.Controls.Add(this.memAdressat);
            this.Controls.Add(this.lblAdressatOhneInstStamm);
            this.Controls.Add(this.edtAdressat);
            this.Controls.Add(this.lblAdressat);
            this.Controls.Add(this.edtAutor);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.edtDienstleistung);
            this.Controls.Add(this.lblDienstleistung);
            this.Controls.Add(this.edtDatum);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.grdDokumente);
            this.Controls.Add(this.panTitel);
            this.Name = "CtlFaDokumente";
            this.Size = new System.Drawing.Size(739, 596);
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDokumente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDienstleistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAutor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressatOhneInstStamm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAdressat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichworte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetroffeneLebensbereiche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetroffeneLebensbereiche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungen.Properties)).EndInit();
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

        private void edtAdressat_EditValueChanged(object sender, EventArgs e)
        {
            // set data has changed (needed for validation)
            _hasAdressatChanged = true;
        }

        private void edtAdressat_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogAutorAdressat(sender, e);
        }

        private void edtAutor_EditValueChanged(object sender, EventArgs e)
        {
            // set data has changed (needed for validation)
            _hasAutorChanged = true;
        }

        private void edtAutor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogAutorAdressat(sender, e);
        }

        private void qryFaDokumente_AfterInsert(object sender, EventArgs e)
        {
            // apply person id
            qryFaDokumente["BaPersonID"] = _baPersonID;

            // apply default values
            qryFaDokumente["Autor"] = _userFullName;
            qryFaDokumente["AutorID"] = Session.User.UserID;
            qryFaDokumente["AutorAdressTypCode"] = 1; // User

            // set focus
            edtDatum.Focus();
        }

        private void qryFaDokumente_AfterPost(object sender, EventArgs e)
        {
            // apply lookup fields
            qryFaDokumente["Dienstleistung"] = edtDienstleistung.Text;
            qryFaDokumente["Themen"] = edtBetroffeneLebensbereiche.GetDisplayText(Convert.ToString(edtBetroffeneLebensbereiche.EditValue));
        }

        private void qryFaDokumente_BeforePost(object sender, EventArgs e)
        {
            // validate must fields
            DBUtil.CheckNotNullField(edtDatum, lblDatum.Text);
            DBUtil.CheckNotNullField(edtDienstleistung, lblDienstleistung.Text);
            DBUtil.CheckNotNullField(edtAutor, lblAutor.Text);

            // validate buttonedits
            if (_hasAutorChanged && !DialogAutorAdressat(edtAutor, new UserModifiedFldEventArgs(false, false)))
            {
                // invalid Autor
                edtAutor.Focus();
                throw new KissCancelException();
            }
            if (_hasAdressatChanged && !DialogAutorAdressat(edtAdressat, new UserModifiedFldEventArgs(false, false)))
            {
                // invalid Adressat
                edtAdressat.Focus();
                throw new KissCancelException();
            }

            // address (optically only)
            if (DBUtil.IsEmpty(qryFaDokumente["Adressat"]))
            {
                // try to apply text from memo if any available
                qryFaDokumente["AdressatCol"] = DBUtil.IsEmpty(qryFaDokumente["AdressatText"]) ? DBNull.Value : qryFaDokumente["AdressatText"];
            }

            // reset flags
            ResetChangedFlags();
            ResetBookmarkDlgVar();
        }

        private void qryFaDokumente_PositionChanged(object sender, EventArgs e)
        {
            // reset flag to ensure not changed only due to position switched
            ResetChangedFlags();
            ResetBookmarkDlgVar();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "FADOKUMENTEID":
                    return qryFaDokumente[DBO.FaDokumente.FaDokumenteID];

                case "BAPERSONID":
                    return _baPersonID;

                case "BAINSTITUTIONKONTAKTID":
                    return GetBaInstitutionKontaktID();
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int baPersonID)
        {
            // validate
            if (baPersonID < 1)
            {
                // do not continue
                qryFaDokumente.CanInsert = false;
                qryFaDokumente.CanUpdate = false;
                qryFaDokumente.CanDelete = false;

                // handle editmode of controls
                qryFaDokumente.EnableBoundFields(qryFaDokumente.CanUpdate);
                return;
            }

            // allow changes
            qryFaDokumente.CanInsert = true;
            qryFaDokumente.CanUpdate = true;
            qryFaDokumente.CanDelete = true;

            // apply values
            _baPersonID = baPersonID;
            picTitel.Image = titleImage;
            lblTitel.Text = titleName;

            /*
            INFO:
            FaDokumentAdressTyp 1 Benutzer
            FaDokumentAdressTyp 2 Klient/in
            FaDokumentAdressTyp 3 Institution
            */

            // fill data (!!! remember to change dbo.fnFaGetJournal, too on Autor changes !!!)
            qryFaDokumente.Fill(@"
                DECLARE @BaPersonID INT
                DECLARE @LanguageCode INT

                SET @BaPersonID = {0}
                SET @LanguageCode = ISNULL({1}, 1)

                SELECT DOK.*,
                       Autor = CASE WHEN AutorAdressTypCode = 1 THEN (SELECT dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName)
                                                                      FROM dbo.XUser USR WITH (READUNCOMMITTED)
                                                                      WHERE USR.UserID = DOK.AutorID)
                                    WHEN AutorAdressTypCode = 2 THEN (SELECT dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname)
                                                                      FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
                                                                      WHERE PRS.BaPersonID = DOK.AutorID)
                                    WHEN AutorAdressTypCode = 3 THEN (SELECT ISNULL(INS.Name, '') + ISNULL(', ' + ADR.Zusatz, '') + ISNULL(', ' + ADR.Ort, '')
                                                                      FROM dbo.BaInstitution INS WITH (READUNCOMMITTED)
                                                                        LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaInstitutionID = INS.BaInstitutionID AND
                                                                                                                              ADR.DatumVon <= GETDATE() AND
                                                                                                                              (ADR.DatumBis IS NULL OR ADR.DatumBis >= GETDATE())
                                                                      WHERE INS.BaInstitutionID = DOK.AutorID)
                                    ELSE NULL
                       END,
                       Dienstleistung = dbo.fnGetLOVMLText('FaModulDienstleistungen', DOK.DienstleistungCode, @LanguageCode),
                       AdressatCol = CASE WHEN AdressatAdressTypCode = 1 THEN (SELECT dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName)
                                                                               FROM dbo.XUser USR WITH (READUNCOMMITTED)
                                                                               WHERE USR.UserID = DOK.AdressatID)
                                          WHEN AdressatAdressTypCode = 2 THEN (SELECT dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname)
                                                                               FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
                                                                               WHERE PRS.BaPersonID = DOK.AdressatID)
                                          WHEN AdressatAdressTypCode = 3 THEN (SELECT ISNULL(INS.Name, '') + ISNULL(', ' + ADR.Zusatz, '') + ISNULL(', ' + ADR.Ort, '')
                                                                               FROM dbo.BaInstitution INS WITH (READUNCOMMITTED)
                                                                                 LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaInstitutionID = INS.BaInstitutionID AND
                                                                                                                                       ADR.DatumVon <= GETDATE() AND
                                                                                                                                       (ADR.DatumBis IS NULL OR ADR.DatumBis >= GETDATE())
                                                                               WHERE INS.BaInstitutionID = DOK.AdressatID)
                                          ELSE AdressatText
                                     END,
                       Adressat = CASE WHEN AdressatAdressTypCode = 1 THEN (SELECT dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName)
                                                                            FROM dbo.XUser USR WITH (READUNCOMMITTED)
                                                                            WHERE USR.UserID = DOK.AdressatID)
                                       WHEN AdressatAdressTypCode = 2 THEN (SELECT dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname)
                                                                            FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
                                                                            WHERE PRS.BaPersonID = DOK.AdressatID)
                                       WHEN AdressatAdressTypCode = 3 THEN (SELECT ISNULL(INS.Name, '') + ISNULL(', ' + ADR.Zusatz, '') + ISNULL(', ' + ADR.Ort, '')
                                                                            FROM dbo.BaInstitution INS WITH (READUNCOMMITTED)
                                                                              LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.BaInstitutionID = INS.BaInstitutionID AND
                                                                                                                                    ADR.DatumVon <= GETDATE() AND
                                                                                                                                    (ADR.DatumBis IS NULL OR ADR.DatumBis >= GETDATE())
                                                                            WHERE INS.BaInstitutionID = DOK.AdressatID)
                                       ELSE NULL
                                  END,
                       Themen = dbo.fnLOVMLColumnListe('FaLebensbereich', DOK.ThemenCodes, NULL, @LanguageCode)
                FROM dbo.FaDokumente DOK WITH (READUNCOMMITTED)
                WHERE DOK.BaPersonID = @BaPersonID
                ORDER BY DOK.Datum, DienstleistungCode ASC;", baPersonID, Session.User.LanguageCode);

            // select last row
            qryFaDokumente.Last();

            // insert new entry if not yet any entry found
            if (qryFaDokumente.CanInsert && qryFaDokumente.Count < 1)
            {
                //qryFaDokumente.Insert(null);
            }

            // reset flags
            ResetChangedFlags();
            ResetBookmarkDlgVar();
        }

        /// <summary>
        /// Reset flags for changed Autor and Adressat
        /// </summary>
        public void ResetChangedFlags()
        {
            _hasAutorChanged = false;
            _hasAdressatChanged = false;
        }

        #endregion

        #region Private Methods

        private bool DialogAutorAdressat(object sender, UserModifiedFldEventArgs e)
        {
            try
            {
                // convert control
                KissButtonEdit edit = (KissButtonEdit)sender;

                // check if data can be altered
                if (!qryFaDokumente.CanUpdate || qryFaDokumente.Count < 1 || edit.EditMode == EditModeType.ReadOnly)
                {
                    // do nothing
                    return true;
                }

                // prepare search string
                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edit.EditValue))
                {
                    // prepare for database search
                    searchString = edit.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
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
                        // check control
                        if (edit == edtAdressat)
                        {
                            qryFaDokumente["AdressatID"] = DBNull.Value;
                            qryFaDokumente["AdressatAdressTypCode"] = DBNull.Value;
                            qryFaDokumente["Adressat"] = DBNull.Value;
                            qryFaDokumente["AdressatCol"] = DBUtil.IsEmpty(qryFaDokumente["AdressatText"]) ? DBNull.Value : qryFaDokumente["AdressatText"];
                            return true;
                        }

                        if (edit == edtAutor)
                        {
                            qryFaDokumente["AutorID"] = DBNull.Value;
                            qryFaDokumente["AutorAdressTypCode"] = DBNull.Value;
                            qryFaDokumente["Autor"] = DBNull.Value;
                            return true;
                        }

                        // wrong field
                        throw new Exception("Wrong data field, cannot proceed.");
                    }
                }

                /*
                INFO:
                FaDokumentAdressTyp 1 Benutzer
                FaDokumentAdressTyp 2 Klient/in
                FaDokumentAdressTyp 3 Institution
                */

                KissLookupDialog dlg = new KissLookupDialog();

                e.Cancel = !dlg.SearchData(string.Format(@"
                    DECLARE @SearchValue VARCHAR(255);
                    DECLARE @BaPersonID INT;
                    DECLARE @UserID INT;

                    SET @BaPersonID = {0};
                    SET @SearchValue = N'{1}';
                    SET @UserID = {2};

                    -- prepeare search string
                    SET @SearchValue = REPLACE(@SearchValue, ' ', '%');
                    SET @SearchValue = REPLACE(@SearchValue, ',', '%');
                    SET @SearchValue = @SearchValue + '%';

                    -- Users:
                    SELECT ID$      = USR.UserID,
                         Text$    = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName),
                         TypCode$ = 1,
                         Typ      = '{3}',
                         Name     = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) + ISNULL(' ('+USR.LogonName+')', ''),
                         Strasse  = NULL,
                         Ort      = NULL
                    FROM dbo.XUser                                      USR WITH (READUNCOMMITTED)
                      INNER JOIN dbo.fnDlgMitarbeiterSuchenKGS(@UserID) DMS ON DMS.UserID$ = USR.UserID
                    WHERE dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) LIKE @SearchValue
                      AND dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) <> ''

                    UNION ALL

                    -- Persons:
                    SELECT DISTINCT
                         ID$      = PRS.BaPersonID,
                         Text$    = PRS.NameVorname,
                         TypCode$ = 2,
                         Typ      = '{4}',
                         Name     = PRS.NameVorname,
                         Strasse  = PRS.WohnsitzStrasseHausNr,
                         Ort      = PRS.WohnsitzPLZOrt
                    FROM dbo.fnGetCantonsOrgUnitsPersons(@UserID, 0, @SearchValue) DLG
                      INNER JOIN dbo.vwPerson                        PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = DLG.BaPersonID
                    WHERE PRS.NameVorname LIKE @SearchValue
                    AND PRS.NameVorname <> ''

                    UNION ALL

                    -- Institutions:
                    SELECT ID$      = INS.BaInstitutionID,
                           Text$    = dbo.fnGetLastFirstName(NULL, INS.Name, INS.Zusatz) + ISNULL(', ' + INS.Ort, ''),
                           TypCode$ = 3,
                           Typ      = '{5}',
                           Name     = dbo.fnGetLastFirstName(NULL, INS.Name, INS.Zusatz),
                           Strasse  = INS.StrasseHausNr,
                           Ort      = INS.PLZOrt
                    FROM dbo.vwInstitution                              INS WITH (READUNCOMMITTED)
                      INNER JOIN dbo.XOrgUnit                           ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = INS.OrgUnitID
                      INNER JOIN dbo.fnGetInstStammUserORGList(@UserID) ISU                        ON ISU.OrgUnitID = ORG.OrgUnitID
                    WHERE ISNULL(INS.Aktiv, 0) = 1         -- only active ones
                      AND (dbo.fnGetLastFirstName(NULL, INS.Name, INS.Zusatz) + ISNULL(', ' + INS.Ort, '')) LIKE '%' + @SearchValue
                      AND dbo.fnGetLastFirstName(NULL, INS.Name, INS.Zusatz) <> ''
                    ORDER BY Name ASC, Typ ASC;", _baPersonID,
                                                  searchString,
                                                  Session.User.UserID,
                                                  _benutzerMLText,
                                                  _personMLText,
                                                  _institutionMLText),
                    searchString, e.ButtonClicked, null, null, null);

                if (!e.Cancel)
                {
                    // check control
                    if (edit == edtAdressat)
                    {
                        // Adressat, apply new value
                        qryFaDokumente["AdressatID"] = dlg["ID$"];
                        qryFaDokumente["AdressatAdressTypCode"] = dlg["TypCode$"];
                        qryFaDokumente["Adressat"] = dlg["Text$"];
                        qryFaDokumente["AdressatCol"] = dlg["Text$"];

                        // reset flag
                        _hasAdressatChanged = false;
                    }
                    else if (edit == edtAutor)
                    {
                        // Autor, apply new value
                        qryFaDokumente["AutorID"] = dlg["ID$"];
                        qryFaDokumente["AutorAdressTypCode"] = dlg["TypCode$"];
                        qryFaDokumente["Autor"] = dlg["Text$"];

                        // reset flag
                        _hasAutorChanged = false;
                    }
                    else
                    {
                        // wrong field
                        throw new Exception("Wrong data field, cannot proceed.");
                    }

                    // success
                    return true;
                }

                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorIKissUserModified", "Fehler bei der Verarbeitung.", ex);
                return false;
            }
        }

        private int GetBaInstitutionKontaktID()
        {
            var faDokumenteID = DBUtil.IsEmpty(qryFaDokumente[DBO.FaDokumente.FaDokumenteID]) ? -1 : Convert.ToInt32(qryFaDokumente[DBO.FaDokumente.FaDokumenteID]);

            if (faDokumenteID < 1)
            {
                ResetBookmarkDlgVar();
                return -1;
            }

            // if we have id cached, we return it directly (there are multiple calls, for each single bookmark in document one call)
            if (GetBookmarkDlgBaInstitutionKontaktID(faDokumenteID) > 0)
            {
                return GetBookmarkDlgBaInstitutionKontaktID(faDokumenteID);
            }

            var qryContactPersons = DBUtil.OpenSQL(@"
                SELECT FCN.BaInstitutionID,
                       FCN.BaPersonID_Betrifft,
                       FCN.BaInstitutionKontaktID
                FROM dbo.fnFaDokumentAdressatKontaktperson({0}) FCN;", faDokumenteID);

            if (qryContactPersons.IsEmpty)
            {
                ResetBookmarkDlgVar();
                return -1;
            }

            if (qryContactPersons.Count == 1)
            {
                SetBookmarkDlgVar(faDokumenteID, Convert.ToInt32(qryContactPersons["BaInstitutionKontaktID"]));
                return GetBookmarkDlgBaInstitutionKontaktID(faDokumenteID);
            }

            // we need to show dialog because of multiple candidates
            try
            {
                var dlg = new KissLookupDialog(KissMsg.GetMLMessage(Name, "SelectContactPersonDlgForBookmarks_v01", "Kontaktperson auswählen:"));

                if (dlg.SearchData(string.Format(@"
                    SELECT BaInstitutionID$          = FCN.BaInstitutionID,
                           BaPersonID_Betrifft$      = FCN.BaPersonID_Betrifft,
                           BaInstitutionKontaktID$   = FCN.BaInstitutionKontaktID,
                           --
                           [Institution, Fachperson] = INS.NameVorname,
                           [Betrifft Person]         = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
                           [Kontaktperson]           = dbo.fnGetLastFirstName(NULL, INK.Name, INK.Vorname)
                    FROM dbo.fnFaDokumentAdressatKontaktperson({0}) FCN
                      INNER JOIN dbo.vwInstitution                  INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = FCN.BaInstitutionID
                      INNER JOIN dbo.BaPerson                       PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FCN.BaPersonID_Betrifft
                      INNER JOIN dbo.BaInstitutionKontakt           INK WITH (READUNCOMMITTED) ON INK.BaInstitutionKontaktID = FCN.BaInstitutionKontaktID;", faDokumenteID), null, true))
                {
                    SetBookmarkDlgVar(faDokumenteID, Convert.ToInt32(dlg["BaInstitutionKontaktID$"]));
                    return GetBookmarkDlgBaInstitutionKontaktID(faDokumenteID);
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorGettingBaInstitutionKontaktID", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }

            // in case of error or no selection
            ResetBookmarkDlgVar();
            return -1;
        }

        private int GetBookmarkDlgBaInstitutionKontaktID(int faDokumenteID)
        {
            if (_baInstitutionKontaktIdOfBookmarkDlgToFaDokID == null || !_baInstitutionKontaktIdOfBookmarkDlgToFaDokID.ContainsKey(faDokumenteID))
            {
                return -1;
            }

            return _baInstitutionKontaktIdOfBookmarkDlgToFaDokID[faDokumenteID];
        }

        private void ResetBookmarkDlgVar()
        {
            _baInstitutionKontaktIdOfBookmarkDlgToFaDokID = new Dictionary<int, int>(1);
        }

        private void SetBookmarkDlgVar(int faDokumenteID, int baInstitutionKontaktID)
        {
            ResetBookmarkDlgVar();
            _baInstitutionKontaktIdOfBookmarkDlgToFaDokID.Add(faDokumenteID, baInstitutionKontaktID);
        }

        #endregion

        #endregion
    }
}