using System;
using System.ComponentModel;
using KiSS4.DB;

namespace KiSS4.Basis
{
    public class CtlBaPersonWV : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Public Fields

        public KiSS4.Gui.KissMemoEdit edtBemerkung;
        public KiSS4.Gui.KissLookUpEdit edtBezugsgroesse;
        public KiSS4.Gui.KissDateEdit edtDatumBis;
        public KiSS4.Gui.KissDateEdit edtDatumVon;
        public KiSS4.Gui.KissTextEdit edtHeimatKantonNr;
        public KiSS4.Gui.KissTextEdit edtKantonKuerzel;
        public KiSS4.Gui.KissLookUpEdit edtStatusCode;
        public KiSS4.Gui.KissTextEdit edtWohnKantonNr;
        public KiSS4.DB.SqlQuery qryBaWVCode;

        #endregion

        #region Private Fields

        private int baPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colBezug;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatkanton;
        private DevExpress.XtraGrid.Columns.GridColumn colSKZNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissCheckEdit edtAuslandCH;
        private KiSS4.Gui.KissGrid grdBaWVCode;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaWVCode;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBezugsgroesse;
        private KiSS4.Gui.KissLabel lblBis;
        private KiSS4.Gui.KissLabel lblGueltigVon;
        private KiSS4.Gui.KissLabel lblKuerzel;
        private KiSS4.Gui.KissLabel lblNrHeimat;
        private KiSS4.Gui.KissLabel lblNrWohnkanton;
        private KiSS4.Gui.KissLabel lblStatus;
        private KiSS4.Gui.KissLabel lblWV;
        private KiSS4.DB.SqlQuery qryStatus;

        #endregion

        #endregion

        #region Constructors

        public CtlBaPersonWV()
        {
            this.InitializeComponent();

            // default property values
            AutoSetRights = true;

            colBezug.ColumnEdit = grdBaWVCode.GetLOVLookUpEdit("BaWVCode");
            colStatus.ColumnEdit = grdBaWVCode.GetLOVLookUpEdit("BaWVStatus");

            // Rechte der Qry setzen
            SetRights();
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaPersonWV));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblWV = new KiSS4.Gui.KissLabel();
            this.grdBaWVCode = new KiSS4.Gui.KissGrid();
            this.qryBaWVCode = new KiSS4.DB.SqlQuery(this.components);
            this.grvBaWVCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezug = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSKZNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatkanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblBezugsgroesse = new KiSS4.Gui.KissLabel();
            this.edtBezugsgroesse = new KiSS4.Gui.KissLookUpEdit();
            this.lblGueltigVon = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblBis = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblNrHeimat = new KiSS4.Gui.KissLabel();
            this.edtHeimatKantonNr = new KiSS4.Gui.KissTextEdit();
            this.lblNrWohnkanton = new KiSS4.Gui.KissLabel();
            this.edtWohnKantonNr = new KiSS4.Gui.KissTextEdit();
            this.lblKuerzel = new KiSS4.Gui.KissLabel();
            this.edtKantonKuerzel = new KiSS4.Gui.KissTextEdit();
            this.edtAuslandCH = new KiSS4.Gui.KissCheckEdit();
            this.lblStatus = new KiSS4.Gui.KissLabel();
            this.edtStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.qryStatus = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblWV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaWVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaWVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaWVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezugsgroesse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezugsgroesse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezugsgroesse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNrHeimat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatKantonNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNrWohnkanton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnKantonNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKuerzel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKantonKuerzel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuslandCH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryStatus)).BeginInit();
            this.SuspendLayout();
            //
            // lblWV
            //
            this.lblWV.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblWV.Location = new System.Drawing.Point(3, 6);
            this.lblWV.Name = "lblWV";
            this.lblWV.Size = new System.Drawing.Size(699, 16);
            this.lblWV.TabIndex = 0;
            this.lblWV.Text = "WV";
            this.lblWV.UseCompatibleTextRendering = true;
            //
            // grdBaWVCode
            //
            this.grdBaWVCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBaWVCode.DataSource = this.qryBaWVCode;
            this.grdBaWVCode.EmbeddedNavigator.Name = "kissGrid4.EmbeddedNavigator";
            this.grdBaWVCode.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaWVCode.Location = new System.Drawing.Point(3, 25);
            this.grdBaWVCode.MainView = this.grvBaWVCode;
            this.grdBaWVCode.Name = "grdBaWVCode";
            this.grdBaWVCode.Size = new System.Drawing.Size(699, 102);
            this.grdBaWVCode.TabIndex = 1;
            this.grdBaWVCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaWVCode});
            //
            // qryBaWVCode
            //
            this.qryBaWVCode.CanDelete = true;
            this.qryBaWVCode.CanInsert = true;
            this.qryBaWVCode.CanUpdate = true;
            this.qryBaWVCode.HostControl = this;
            this.qryBaWVCode.SelectStatement = "SELECT *\r\nFROM dbo.BaWVCode WITH (READUNCOMMITTED)\r\nWHERE BaPersonID = {0}";
            this.qryBaWVCode.TableName = "BaWVCode";
            this.qryBaWVCode.BeforePost += new System.EventHandler(this.qryBaWVCode_BeforePost);
            this.qryBaWVCode.AfterInsert += new System.EventHandler(this.qryBaWVCode_AfterInsert);
            this.qryBaWVCode.BeforeDeleteQuestion += new System.EventHandler(this.qryBaWVCode_BeforeDeleteQuestion);
            //
            // grvBaWVCode
            //
            this.grvBaWVCode.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaWVCode.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.Empty.Options.UseFont = true;
            this.grvBaWVCode.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaWVCode.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaWVCode.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaWVCode.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaWVCode.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaWVCode.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaWVCode.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaWVCode.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaWVCode.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaWVCode.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaWVCode.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaWVCode.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaWVCode.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaWVCode.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaWVCode.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaWVCode.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaWVCode.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaWVCode.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaWVCode.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaWVCode.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaWVCode.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaWVCode.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.OddRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaWVCode.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.Row.Options.UseBackColor = true;
            this.grvBaWVCode.Appearance.Row.Options.UseFont = true;
            this.grvBaWVCode.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaWVCode.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaWVCode.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaWVCode.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaWVCode.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaWVCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatumVon,
            this.colDatumBis,
            this.colBezug,
            this.colSKZNummer,
            this.colHeimatkanton,
            this.colStatus});
            this.grvBaWVCode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaWVCode.GridControl = this.grdBaWVCode;
            this.grvBaWVCode.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBaWVCode.Name = "grvBaWVCode";
            this.grvBaWVCode.OptionsBehavior.Editable = false;
            this.grvBaWVCode.OptionsCustomization.AllowFilter = false;
            this.grvBaWVCode.OptionsFilter.AllowFilterEditor = false;
            this.grvBaWVCode.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaWVCode.OptionsMenu.EnableColumnMenu = false;
            this.grvBaWVCode.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaWVCode.OptionsNavigation.UseTabKey = false;
            this.grvBaWVCode.OptionsView.ColumnAutoWidth = false;
            this.grvBaWVCode.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaWVCode.OptionsView.ShowGroupPanel = false;
            this.grvBaWVCode.OptionsView.ShowIndicator = false;
            //
            // colDatumVon
            //
            this.colDatumVon.Caption = "ab";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            this.colDatumVon.Width = 83;
            //
            // colDatumBis
            //
            this.colDatumBis.Caption = "bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 1;
            //
            // colBezug
            //
            this.colBezug.Caption = "Bezugsgrösse";
            this.colBezug.FieldName = "BaWVCode";
            this.colBezug.Name = "colBezug";
            this.colBezug.Visible = true;
            this.colBezug.VisibleIndex = 2;
            this.colBezug.Width = 145;
            //
            // colSKZNummer
            //
            this.colSKZNummer.Caption = "Nummer Kanton";
            this.colSKZNummer.FieldName = "WohnKantonNr";
            this.colSKZNummer.Name = "colSKZNummer";
            this.colSKZNummer.Visible = true;
            this.colSKZNummer.VisibleIndex = 3;
            this.colSKZNummer.Width = 146;
            //
            // colHeimatkanton
            //
            this.colHeimatkanton.Caption = "Nummer Heimatkanton";
            this.colHeimatkanton.FieldName = "HeimatKantonNr";
            this.colHeimatkanton.Name = "colHeimatkanton";
            this.colHeimatkanton.Visible = true;
            this.colHeimatkanton.VisibleIndex = 4;
            this.colHeimatkanton.Width = 147;
            //
            // colStatus
            //
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "StatusCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;
            //
            // lblBezugsgroesse
            //
            this.lblBezugsgroesse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBezugsgroesse.Location = new System.Drawing.Point(6, 142);
            this.lblBezugsgroesse.Name = "lblBezugsgroesse";
            this.lblBezugsgroesse.Size = new System.Drawing.Size(158, 24);
            this.lblBezugsgroesse.TabIndex = 2;
            this.lblBezugsgroesse.Text = "Bezugsgrösse";
            this.lblBezugsgroesse.UseCompatibleTextRendering = true;
            //
            // edtBezugsgroesse
            //
            this.edtBezugsgroesse.AllowNull = false;
            this.edtBezugsgroesse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBezugsgroesse.DataMember = "BaWVCode";
            this.edtBezugsgroesse.DataSource = this.qryBaWVCode;
            this.edtBezugsgroesse.Location = new System.Drawing.Point(170, 142);
            this.edtBezugsgroesse.LOVName = "BaWVCode";
            this.edtBezugsgroesse.Name = "edtBezugsgroesse";
            this.edtBezugsgroesse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBezugsgroesse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBezugsgroesse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBezugsgroesse.Properties.Appearance.Options.UseBackColor = true;
            this.edtBezugsgroesse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBezugsgroesse.Properties.Appearance.Options.UseFont = true;
            this.edtBezugsgroesse.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBezugsgroesse.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBezugsgroesse.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBezugsgroesse.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBezugsgroesse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBezugsgroesse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBezugsgroesse.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBezugsgroesse.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBezugsgroesse.Properties.DisplayMember = "Text";
            this.edtBezugsgroesse.Properties.Name = "kissLookUpEdit5.Properties";
            this.edtBezugsgroesse.Properties.NullText = "";
            this.edtBezugsgroesse.Properties.ShowFooter = false;
            this.edtBezugsgroesse.Properties.ShowHeader = false;
            this.edtBezugsgroesse.Properties.ValueMember = "Code";
            this.edtBezugsgroesse.Size = new System.Drawing.Size(516, 24);
            this.edtBezugsgroesse.TabIndex = 3;
            //
            // lblGueltigVon
            //
            this.lblGueltigVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGueltigVon.Location = new System.Drawing.Point(6, 172);
            this.lblGueltigVon.Name = "lblGueltigVon";
            this.lblGueltigVon.Size = new System.Drawing.Size(158, 24);
            this.lblGueltigVon.TabIndex = 4;
            this.lblGueltigVon.Text = "Gültig ab";
            this.lblGueltigVon.UseCompatibleTextRendering = true;
            //
            // edtDatumVon
            //
            this.edtDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryBaWVCode;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(170, 172);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.Name = "kissDateEdit8.Properties";
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 5;
            //
            // lblBis
            //
            this.lblBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBis.Location = new System.Drawing.Point(276, 172);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(24, 24);
            this.lblBis.TabIndex = 6;
            this.lblBis.Text = "bis";
            this.lblBis.UseCompatibleTextRendering = true;
            //
            // edtDatumBis
            //
            this.edtDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryBaWVCode;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(306, 172);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.Name = "kissDateEdit9.Properties";
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 7;
            //
            // lblNrHeimat
            //
            this.lblNrHeimat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNrHeimat.Location = new System.Drawing.Point(6, 202);
            this.lblNrHeimat.Name = "lblNrHeimat";
            this.lblNrHeimat.Size = new System.Drawing.Size(158, 24);
            this.lblNrHeimat.TabIndex = 8;
            this.lblNrHeimat.Text = "Personen Nr. Heimatkanton";
            this.lblNrHeimat.UseCompatibleTextRendering = true;
            //
            // edtHeimatKantonNr
            //
            this.edtHeimatKantonNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtHeimatKantonNr.DataMember = "HeimatKantonNr";
            this.edtHeimatKantonNr.DataSource = this.qryBaWVCode;
            this.edtHeimatKantonNr.Location = new System.Drawing.Point(170, 202);
            this.edtHeimatKantonNr.Name = "edtHeimatKantonNr";
            this.edtHeimatKantonNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHeimatKantonNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHeimatKantonNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHeimatKantonNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtHeimatKantonNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHeimatKantonNr.Properties.Appearance.Options.UseFont = true;
            this.edtHeimatKantonNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHeimatKantonNr.Size = new System.Drawing.Size(236, 24);
            this.edtHeimatKantonNr.TabIndex = 9;
            //
            // lblNrWohnkanton
            //
            this.lblNrWohnkanton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNrWohnkanton.Location = new System.Drawing.Point(6, 232);
            this.lblNrWohnkanton.Name = "lblNrWohnkanton";
            this.lblNrWohnkanton.Size = new System.Drawing.Size(158, 24);
            this.lblNrWohnkanton.TabIndex = 10;
            this.lblNrWohnkanton.Text = "Personen Nr. Wohnkanton";
            this.lblNrWohnkanton.UseCompatibleTextRendering = true;
            //
            // edtWohnKantonNr
            //
            this.edtWohnKantonNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtWohnKantonNr.DataMember = "WohnKantonNr";
            this.edtWohnKantonNr.DataSource = this.qryBaWVCode;
            this.edtWohnKantonNr.Location = new System.Drawing.Point(170, 232);
            this.edtWohnKantonNr.Name = "edtWohnKantonNr";
            this.edtWohnKantonNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWohnKantonNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnKantonNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnKantonNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnKantonNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnKantonNr.Properties.Appearance.Options.UseFont = true;
            this.edtWohnKantonNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWohnKantonNr.Size = new System.Drawing.Size(236, 24);
            this.edtWohnKantonNr.TabIndex = 11;
            //
            // lblKuerzel
            //
            this.lblKuerzel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKuerzel.Location = new System.Drawing.Point(6, 262);
            this.lblKuerzel.Name = "lblKuerzel";
            this.lblKuerzel.Size = new System.Drawing.Size(158, 24);
            this.lblKuerzel.TabIndex = 12;
            this.lblKuerzel.Text = "Kanton Kürzel";
            this.lblKuerzel.UseCompatibleTextRendering = true;
            //
            // edtKantonKuerzel
            //
            this.edtKantonKuerzel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKantonKuerzel.DataMember = "KantonKuerzel";
            this.edtKantonKuerzel.DataSource = this.qryBaWVCode;
            this.edtKantonKuerzel.Location = new System.Drawing.Point(170, 262);
            this.edtKantonKuerzel.Name = "edtKantonKuerzel";
            this.edtKantonKuerzel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKantonKuerzel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKantonKuerzel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKantonKuerzel.Properties.Appearance.Options.UseBackColor = true;
            this.edtKantonKuerzel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKantonKuerzel.Properties.Appearance.Options.UseFont = true;
            this.edtKantonKuerzel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKantonKuerzel.Size = new System.Drawing.Size(236, 24);
            this.edtKantonKuerzel.TabIndex = 13;
            //
            // edtAuslandCH
            //
            this.edtAuslandCH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAuslandCH.DataMember = "Auslandschweizer";
            this.edtAuslandCH.DataSource = this.qryBaWVCode;
            this.edtAuslandCH.Location = new System.Drawing.Point(170, 292);
            this.edtAuslandCH.Name = "edtAuslandCH";
            this.edtAuslandCH.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtAuslandCH.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuslandCH.Properties.Caption = "Auslandschweizer";
            this.edtAuslandCH.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.edtAuslandCH.Size = new System.Drawing.Size(236, 19);
            this.edtAuslandCH.TabIndex = 14;
            //
            // lblStatus
            //
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.Location = new System.Drawing.Point(426, 172);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(74, 24);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Status";
            this.lblStatus.UseCompatibleTextRendering = true;
            //
            // edtStatusCode
            //
            this.edtStatusCode.AllowNull = false;
            this.edtStatusCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtStatusCode.DataMember = "StatusCode";
            this.edtStatusCode.DataSource = this.qryBaWVCode;
            this.edtStatusCode.Location = new System.Drawing.Point(506, 172);
            this.edtStatusCode.LOVName = "BaWVStatus";
            this.edtStatusCode.Name = "edtStatusCode";
            this.edtStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtStatusCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtStatusCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtStatusCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtStatusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStatusCode.Properties.NullText = "";
            this.edtStatusCode.Properties.ShowFooter = false;
            this.edtStatusCode.Properties.ShowHeader = false;
            this.edtStatusCode.Size = new System.Drawing.Size(180, 24);
            this.edtStatusCode.TabIndex = 16;
            //
            // lblBemerkung
            //
            this.lblBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung.Location = new System.Drawing.Point(426, 202);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(74, 24);
            this.lblBemerkung.TabIndex = 17;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            //
            // edtBemerkung
            //
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBaWVCode;
            this.edtBemerkung.Location = new System.Drawing.Point(506, 202);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(180, 109);
            this.edtBemerkung.TabIndex = 18;
            //
            // qryStatus
            //
            this.qryStatus.HostControl = this;
            this.qryStatus.SelectStatement = resources.GetString("qryStatus.SelectStatement");
            //
            // CtlBaPersonWV
            //
            this.ActiveSQLQuery = this.qryBaWVCode;
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.edtStatusCode);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.edtAuslandCH);
            this.Controls.Add(this.edtKantonKuerzel);
            this.Controls.Add(this.lblKuerzel);
            this.Controls.Add(this.edtWohnKantonNr);
            this.Controls.Add(this.lblNrWohnkanton);
            this.Controls.Add(this.edtHeimatKantonNr);
            this.Controls.Add(this.lblNrHeimat);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.lblBis);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.lblGueltigVon);
            this.Controls.Add(this.edtBezugsgroesse);
            this.Controls.Add(this.lblBezugsgroesse);
            this.Controls.Add(this.grdBaWVCode);
            this.Controls.Add(this.lblWV);
            this.Name = "CtlBaPersonWV";
            this.Size = new System.Drawing.Size(705, 323);
            ((System.ComponentModel.ISupportInitialize)(this.lblWV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaWVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaWVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaWVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezugsgroesse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezugsgroesse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezugsgroesse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNrHeimat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatKantonNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNrWohnkanton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnKantonNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKuerzel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKantonKuerzel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuslandCH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryStatus)).EndInit();
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

        #region Properties

        /// <summary>
        /// Get and set if rights will be handled automatically
        /// </summary>
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Get and set if rights will be handled automatically")]
        public bool AutoSetRights
        {
            get;
            set;
        }

        public int BaPersonID
        {
            set
            {
                this.baPersonID = value;
                qryBaWVCode.Fill(value);

                // apply rights
                SetRights();

                if (qryBaWVCode.Count == 0 && qryBaWVCode.CanInsert)
                {
                    qryBaWVCode.Insert();
                }
            }
            get
            {
                return this.baPersonID;
            }
        }

        private bool CanInsertWVCode
        {
            get
            {
                qryStatus.Fill(this.BaPersonID, qryBaWVCode["DatumVon"], qryBaWVCode["DatumBis"], qryBaWVCode["BaWVCodeID"]);
                return (bool)qryStatus["CanInsert"];
            }
        }

        private bool CanUpdateWVCode
        {
            get
            {
                qryStatus.Fill(this.BaPersonID, qryBaWVCode["DatumVon"], qryBaWVCode["DatumBis"], qryBaWVCode["BaWVCodeID"]);
                return qryBaWVCode.Row.RowState == System.Data.DataRowState.Added || (bool)qryStatus["CanUpdate"];
            }
        }

        #endregion

        #region EventHandlers

        private void qryBaWVCode_AfterInsert(object sender, System.EventArgs e)
        {
            // set default values
            qryBaWVCode["BaPersonID"] = baPersonID;

            // Das VON-Datum um einen Tag erhöhen, ausgehend von den bestehenden Datensätzen
            qryStatus.Fill(this.BaPersonID, qryBaWVCode["DatumVon"], qryBaWVCode["DatumBis"], qryBaWVCode["BaWVCodeID"]);
            if (!DBUtil.IsEmpty(qryStatus["LastDateTo"]))
                qryBaWVCode["DatumVon"] = ((DateTime)qryStatus["LastDateTo"]).AddDays(1);

            // TODO
            // Was ist hier falsch: aud BSS-Master gibt es dieses Feld nicht
            //qryBaWVCode["BaWVStatusCode"] = 1; // gültig
            qryBaWVCode["StatusCode"] = 1; // gültig

            // activate
            this.Activate();
        }

        private void qryBaWVCode_BeforeDeleteQuestion(object sender, System.EventArgs e)
        {
            // check if current entry has already an id
            if (DBUtil.IsEmpty(qryBaWVCode["BaWVCodeID"]))
            {
                // no more check, entry has no id
                return;
            }

            // check if current entry can be deleted because of existing entries in KbWVEinzelposten
            Int32 countExistingWEP = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT COUNT(1)
                    FROM dbo.KbWVEinzelposten WEP WITH (READUNCOMMITTED)
                    WHERE WEP.BaWVCodeID = {0}", qryBaWVCode["BaWVCodeID"]));

            if (countExistingWEP > 0)
            {
                // show info and cancel delete
                KissMsg.ShowInfo("CtlBaPersonWV", "CannotDeleteExistingWVEinzelposten", "Dieser Eintrag kann nicht mehr gelöscht werden, da bereits erzeugte Einzelposten davon abhängen. Stattdessen sollte der Status 'Verfallen' verwendet werden.");
                throw new KissCancelException();
            }
        }

        private void qryBaWVCode_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDatumVon, lblGueltigVon.Text);
        }

        #endregion

        #region Methods

        #region Public Methods

        /*
        private DateTime LastDateTo
        {
            get
            {
                qryStatus.Fill(this.BaPersonID, qryBaWVCode["DatumVon"], qryBaWVCode["DatumBis"], qryBaWVCode["BaWVCodeID"]);
                if (DBUtil.IsEmpty(qryStatus["LastDateTo"]))
                    return null;
                else
                    return (DateTime)qryStatus["LastDateTo"];
            }
        }
        */

        public void Activate()
        {
            edtDatumVon.Focus();
        }

        public void SetRights()
        {
            // check if need to set rights automatically
            if (!AutoSetRights)
            {
                return;
            }

            // apply rights
            qryBaWVCode.ApplyUserRights();

            // setup controls
            qryBaWVCode.EnableBoundFields();
        }

        /// <summary>
        /// Set rights manually and disable AutoSetRights
        /// </summary>
        /// <param name="canInsertUpdateDelete"><c>True</c> if user can insert, update and delete address records, otherwise <c>False</c></param>
        public void SetRights(bool canInsertUpdateDelete)
        {
            SetRights(canInsertUpdateDelete, canInsertUpdateDelete, canInsertUpdateDelete);
        }

        /// <summary>
        /// Set rights manually and disable AutoSetRights
        /// </summary>
        /// <param name="canInsert"><c>True</c> if user can insert new address records, otherwise <c>False</c></param>
        /// <param name="canUpdate"><c>True</c> if user can update existing address records, otherwise <c>False</c></param>
        /// <param name="canDelete"><c>True</c> if user can delete existing address records, otherwise <c>False</c></param>
        public void SetRights(bool canInsert, bool canUpdate, bool canDelete)
        {
            // disable auto-set-rights
            AutoSetRights = false;

            // setup queries
            qryBaWVCode.CanInsert = canInsert;
            qryBaWVCode.CanUpdate = canUpdate;
            qryBaWVCode.CanDelete = canDelete;

            // setup controls
            qryBaWVCode.EnableBoundFields();
        }

        #endregion

        #endregion
    }
}