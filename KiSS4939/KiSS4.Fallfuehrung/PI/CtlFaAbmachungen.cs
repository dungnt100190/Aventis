using System;
using System.Drawing;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung.PI
{
    public class CtlFaAbmachungen : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonID = -1;
        private bool _hasAutorChanged = false;
        private string _userFullName = "";
        private KiSS4.Gui.KissCheckEdit chkFaDokAbmErledi;
        private DevExpress.XtraGrid.Columns.GridColumn colAutor;
        private DevExpress.XtraGrid.Columns.GridColumn colDienstleistung;
        private DevExpress.XtraGrid.Columns.GridColumn colErledigt;
        private DevExpress.XtraGrid.Columns.GridColumn colErstellung;
        private DevExpress.XtraGrid.Columns.GridColumn colStichworte;
        private DevExpress.XtraGrid.Columns.GridColumn colTermin;
        private DevExpress.XtraGrid.Columns.GridColumn colThemen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissButtonEdit edtAutor;
        private KiSS4.Gui.KissCheckedLookupEdit edtBeteiligte;
        private KiSS4.Gui.KissCheckedLookupEdit edtBetroffeneLebensbereiche;
        private KiSS4.Gui.KissDateEdit edtDatumErstellung;
        private KiSS4.Gui.KissLookUpEdit edtDienstleistung;
        private KiSS4.Gui.KissDateEdit edtPerDatumTermin;
        private KiSS4.Gui.KissTextEdit edtStichworte;
        private KiSS4.Gui.KissGrid grdAbmachungen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAbmachungen;
        private KiSS4.Gui.KissLabel lblAutor;
        private KiSS4.Gui.KissLabel lblBeteiligte;
        private KiSS4.Gui.KissLabel lblBetroffeneLebensbereiche;
        private KiSS4.Gui.KissLabel lblDatumErstellung;
        private KiSS4.Gui.KissLabel lblDienstleistung;
        private KiSS4.Gui.KissLabel lblPerDatumTermin;
        private KiSS4.Gui.KissLabel lblStichworte;
        private KiSS4.Gui.KissLabel lblText;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissMemoEdit memText;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaAbmachungen;

        #endregion

        #endregion

        #region Constructors

        public CtlFaAbmachungen()
        {
            InitializeComponent();

            // init with default values
            Init(null, null, -1);

            // request userfullname
            _userFullName = Convert.ToString(DBUtil.ExecuteScalarSQL(@"SELECT dbo.fnGetLastFirstName({0}, NULL, NULL)", Session.User.UserID));

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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaAbmachungen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdAbmachungen = new KiSS4.Gui.KissGrid();
            this.qryFaAbmachungen = new KiSS4.DB.SqlQuery(this.components);
            this.grvAbmachungen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colErstellung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTermin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErledigt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienstleistung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichworte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThemen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblDatumErstellung = new KiSS4.Gui.KissLabel();
            this.edtDatumErstellung = new KiSS4.Gui.KissDateEdit();
            this.lblPerDatumTermin = new KiSS4.Gui.KissLabel();
            this.edtPerDatumTermin = new KiSS4.Gui.KissDateEdit();
            this.chkFaDokAbmErledi = new KiSS4.Gui.KissCheckEdit();
            this.lblDienstleistung = new KiSS4.Gui.KissLabel();
            this.edtDienstleistung = new KiSS4.Gui.KissLookUpEdit();
            this.lblAutor = new KiSS4.Gui.KissLabel();
            this.edtAutor = new KiSS4.Gui.KissButtonEdit();
            this.lblStichworte = new KiSS4.Gui.KissLabel();
            this.edtStichworte = new KiSS4.Gui.KissTextEdit();
            this.lblText = new KiSS4.Gui.KissLabel();
            this.memText = new KiSS4.Gui.KissMemoEdit();
            this.lblBeteiligte = new KiSS4.Gui.KissLabel();
            this.edtBeteiligte = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblBetroffeneLebensbereiche = new KiSS4.Gui.KissLabel();
            this.edtBetroffeneLebensbereiche = new KiSS4.Gui.KissCheckedLookupEdit();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAbmachungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaAbmachungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAbmachungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumErstellung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumErstellung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPerDatumTermin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerDatumTermin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFaDokAbmErledi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDienstleistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAutor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichworte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichworte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeteiligte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeteiligte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetroffeneLebensbereiche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetroffeneLebensbereiche)).BeginInit();
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
            this.lblTitel.Text = "Abmachungen";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // grdAbmachungen
            //
            this.grdAbmachungen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAbmachungen.DataSource = this.qryFaAbmachungen;
            //
            //
            //
            this.grdAbmachungen.EmbeddedNavigator.Name = "";
            this.grdAbmachungen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAbmachungen.Location = new System.Drawing.Point(3, 29);
            this.grdAbmachungen.MainView = this.grvAbmachungen;
            this.grdAbmachungen.Name = "grdAbmachungen";
            this.grdAbmachungen.SelectLastPosition = true;
            this.grdAbmachungen.Size = new System.Drawing.Size(733, 217);
            this.grdAbmachungen.TabIndex = 1;
            this.grdAbmachungen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAbmachungen});
            //
            // qryFaAbmachungen
            //
            this.qryFaAbmachungen.HostControl = this;
            this.qryFaAbmachungen.IsIdentityInsert = false;
            this.qryFaAbmachungen.TableName = "FaAbmachungen";
            this.qryFaAbmachungen.AfterFill += new System.EventHandler(this.qryFaAbmachungen_AfterFill);
            this.qryFaAbmachungen.AfterInsert += new System.EventHandler(this.qryFaAbmachungen_AfterInsert);
            this.qryFaAbmachungen.AfterPost += new System.EventHandler(this.qryFaAbmachungen_AfterPost);
            this.qryFaAbmachungen.BeforePost += new System.EventHandler(this.qryFaAbmachungen_BeforePost);
            this.qryFaAbmachungen.PositionChanged += new System.EventHandler(this.qryFaAbmachungen_PositionChanged);
            //
            // grvAbmachungen
            //
            this.grvAbmachungen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAbmachungen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbmachungen.Appearance.Empty.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.Empty.Options.UseFont = true;
            this.grvAbmachungen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbmachungen.Appearance.EvenRow.Options.UseFont = true;
            this.grvAbmachungen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAbmachungen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbmachungen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAbmachungen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAbmachungen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAbmachungen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAbmachungen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbmachungen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAbmachungen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAbmachungen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAbmachungen.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAbmachungen.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAbmachungen.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvAbmachungen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAbmachungen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAbmachungen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAbmachungen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAbmachungen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.GroupRow.Options.UseFont = true;
            this.grvAbmachungen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAbmachungen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAbmachungen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAbmachungen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAbmachungen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAbmachungen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAbmachungen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAbmachungen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbmachungen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAbmachungen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAbmachungen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAbmachungen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAbmachungen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbmachungen.Appearance.OddRow.Options.UseFont = true;
            this.grvAbmachungen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAbmachungen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbmachungen.Appearance.Row.Options.UseBackColor = true;
            this.grvAbmachungen.Appearance.Row.Options.UseFont = true;
            this.grvAbmachungen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbmachungen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAbmachungen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAbmachungen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAbmachungen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAbmachungen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colErstellung,
            this.colTermin,
            this.colErledigt,
            this.colAutor,
            this.colDienstleistung,
            this.colStichworte,
            this.colThemen});
            this.grvAbmachungen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAbmachungen.GridControl = this.grdAbmachungen;
            this.grvAbmachungen.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvAbmachungen.Name = "grvAbmachungen";
            this.grvAbmachungen.OptionsBehavior.Editable = false;
            this.grvAbmachungen.OptionsCustomization.AllowFilter = false;
            this.grvAbmachungen.OptionsFilter.AllowFilterEditor = false;
            this.grvAbmachungen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAbmachungen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAbmachungen.OptionsNavigation.UseTabKey = false;
            this.grvAbmachungen.OptionsView.ColumnAutoWidth = false;
            this.grvAbmachungen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAbmachungen.OptionsView.ShowGroupPanel = false;
            this.grvAbmachungen.OptionsView.ShowIndicator = false;
            //
            // colErstellung
            //
            this.colErstellung.Caption = "Erstellung";
            this.colErstellung.FieldName = "Erstellung";
            this.colErstellung.Name = "colErstellung";
            this.colErstellung.Visible = true;
            this.colErstellung.VisibleIndex = 0;
            this.colErstellung.Width = 80;
            //
            // colTermin
            //
            this.colTermin.Caption = "Termin";
            this.colTermin.FieldName = "PerDatum";
            this.colTermin.Name = "colTermin";
            this.colTermin.Visible = true;
            this.colTermin.VisibleIndex = 1;
            this.colTermin.Width = 80;
            //
            // colErledigt
            //
            this.colErledigt.Caption = "Erledigt";
            this.colErledigt.FieldName = "Erledigt";
            this.colErledigt.Name = "colErledigt";
            this.colErledigt.Visible = true;
            this.colErledigt.VisibleIndex = 2;
            this.colErledigt.Width = 54;
            //
            // colAutor
            //
            this.colAutor.Caption = "Autor";
            this.colAutor.FieldName = "Autor";
            this.colAutor.Name = "colAutor";
            this.colAutor.Visible = true;
            this.colAutor.VisibleIndex = 3;
            this.colAutor.Width = 130;
            //
            // colDienstleistung
            //
            this.colDienstleistung.Caption = "Dienstleistung";
            this.colDienstleistung.FieldName = "Dienstleistung";
            this.colDienstleistung.Name = "colDienstleistung";
            this.colDienstleistung.Visible = true;
            this.colDienstleistung.VisibleIndex = 4;
            this.colDienstleistung.Width = 130;
            //
            // colStichworte
            //
            this.colStichworte.Caption = "Stichworte";
            this.colStichworte.FieldName = "Stichworte";
            this.colStichworte.Name = "colStichworte";
            this.colStichworte.Visible = true;
            this.colStichworte.VisibleIndex = 5;
            this.colStichworte.Width = 190;
            //
            // colThemen
            //
            this.colThemen.Caption = "Themen";
            this.colThemen.FieldName = "Themen";
            this.colThemen.Name = "colThemen";
            this.colThemen.Visible = true;
            this.colThemen.VisibleIndex = 6;
            this.colThemen.Width = 190;
            //
            // lblDatumErstellung
            //
            this.lblDatumErstellung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatumErstellung.Location = new System.Drawing.Point(13, 252);
            this.lblDatumErstellung.Name = "lblDatumErstellung";
            this.lblDatumErstellung.Size = new System.Drawing.Size(124, 24);
            this.lblDatumErstellung.TabIndex = 2;
            this.lblDatumErstellung.Text = "Datum Erstellung";
            this.lblDatumErstellung.UseCompatibleTextRendering = true;
            //
            // edtDatumErstellung
            //
            this.edtDatumErstellung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumErstellung.DataMember = "Erstellung";
            this.edtDatumErstellung.DataSource = this.qryFaAbmachungen;
            this.edtDatumErstellung.EditValue = null;
            this.edtDatumErstellung.Location = new System.Drawing.Point(143, 252);
            this.edtDatumErstellung.Name = "edtDatumErstellung";
            this.edtDatumErstellung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumErstellung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumErstellung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumErstellung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumErstellung.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumErstellung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumErstellung.Properties.Appearance.Options.UseFont = true;
            this.edtDatumErstellung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumErstellung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumErstellung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumErstellung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumErstellung.Properties.ShowToday = false;
            this.edtDatumErstellung.Size = new System.Drawing.Size(100, 24);
            this.edtDatumErstellung.TabIndex = 3;
            //
            // lblPerDatumTermin
            //
            this.lblPerDatumTermin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPerDatumTermin.Location = new System.Drawing.Point(13, 282);
            this.lblPerDatumTermin.Name = "lblPerDatumTermin";
            this.lblPerDatumTermin.Size = new System.Drawing.Size(124, 24);
            this.lblPerDatumTermin.TabIndex = 4;
            this.lblPerDatumTermin.Text = "Per Datum (Termin)";
            this.lblPerDatumTermin.UseCompatibleTextRendering = true;
            //
            // edtPerDatumTermin
            //
            this.edtPerDatumTermin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPerDatumTermin.DataMember = "PerDatum";
            this.edtPerDatumTermin.DataSource = this.qryFaAbmachungen;
            this.edtPerDatumTermin.EditValue = null;
            this.edtPerDatumTermin.Location = new System.Drawing.Point(143, 282);
            this.edtPerDatumTermin.Name = "edtPerDatumTermin";
            this.edtPerDatumTermin.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPerDatumTermin.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPerDatumTermin.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPerDatumTermin.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPerDatumTermin.Properties.Appearance.Options.UseBackColor = true;
            this.edtPerDatumTermin.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPerDatumTermin.Properties.Appearance.Options.UseFont = true;
            this.edtPerDatumTermin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtPerDatumTermin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtPerDatumTermin.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtPerDatumTermin.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPerDatumTermin.Properties.ShowToday = false;
            this.edtPerDatumTermin.Size = new System.Drawing.Size(100, 24);
            this.edtPerDatumTermin.TabIndex = 5;
            //
            // chkFaDokAbmErledi
            //
            this.chkFaDokAbmErledi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkFaDokAbmErledi.DataMember = "Erledigt";
            this.chkFaDokAbmErledi.DataSource = this.qryFaAbmachungen;
            this.chkFaDokAbmErledi.Location = new System.Drawing.Point(260, 285);
            this.chkFaDokAbmErledi.Name = "chkFaDokAbmErledi";
            this.chkFaDokAbmErledi.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkFaDokAbmErledi.Properties.Appearance.Options.UseBackColor = true;
            this.chkFaDokAbmErledi.Properties.Caption = "Erledigt";
            this.chkFaDokAbmErledi.Size = new System.Drawing.Size(155, 19);
            this.chkFaDokAbmErledi.TabIndex = 6;
            //
            // lblDienstleistung
            //
            this.lblDienstleistung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDienstleistung.Location = new System.Drawing.Point(13, 312);
            this.lblDienstleistung.Name = "lblDienstleistung";
            this.lblDienstleistung.Size = new System.Drawing.Size(124, 24);
            this.lblDienstleistung.TabIndex = 7;
            this.lblDienstleistung.Text = "Dienstleistung";
            this.lblDienstleistung.UseCompatibleTextRendering = true;
            //
            // edtDienstleistung
            //
            this.edtDienstleistung.AllowNull = false;
            this.edtDienstleistung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDienstleistung.DataMember = "DienstleistungCode";
            this.edtDienstleistung.DataSource = this.qryFaAbmachungen;
            this.edtDienstleistung.Location = new System.Drawing.Point(143, 312);
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
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDienstleistung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDienstleistung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDienstleistung.Properties.NullText = "";
            this.edtDienstleistung.Properties.ShowFooter = false;
            this.edtDienstleistung.Properties.ShowHeader = false;
            this.edtDienstleistung.Size = new System.Drawing.Size(272, 24);
            this.edtDienstleistung.TabIndex = 8;
            //
            // lblAutor
            //
            this.lblAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAutor.Location = new System.Drawing.Point(13, 342);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(124, 24);
            this.lblAutor.TabIndex = 9;
            this.lblAutor.Text = "Autor/in";
            this.lblAutor.UseCompatibleTextRendering = true;
            //
            // edtAutor
            //
            this.edtAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAutor.DataMember = "Autor";
            this.edtAutor.DataSource = this.qryFaAbmachungen;
            this.edtAutor.Location = new System.Drawing.Point(143, 342);
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
            this.edtAutor.Size = new System.Drawing.Size(272, 24);
            this.edtAutor.TabIndex = 10;
            this.edtAutor.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtAutor_UserModifiedFld);
            this.edtAutor.EditValueChanged += new System.EventHandler(this.edtAutor_EditValueChanged);
            //
            // lblStichworte
            //
            this.lblStichworte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStichworte.Location = new System.Drawing.Point(13, 372);
            this.lblStichworte.Name = "lblStichworte";
            this.lblStichworte.Size = new System.Drawing.Size(124, 24);
            this.lblStichworte.TabIndex = 11;
            this.lblStichworte.Text = "Stichwort(e)";
            this.lblStichworte.UseCompatibleTextRendering = true;
            //
            // edtStichworte
            //
            this.edtStichworte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStichworte.DataMember = "Stichworte";
            this.edtStichworte.DataSource = this.qryFaAbmachungen;
            this.edtStichworte.Location = new System.Drawing.Point(143, 372);
            this.edtStichworte.Name = "edtStichworte";
            this.edtStichworte.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichworte.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichworte.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichworte.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichworte.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichworte.Properties.Appearance.Options.UseFont = true;
            this.edtStichworte.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichworte.Size = new System.Drawing.Size(356, 24);
            this.edtStichworte.TabIndex = 12;
            //
            // lblText
            //
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblText.Location = new System.Drawing.Point(13, 402);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(124, 24);
            this.lblText.TabIndex = 13;
            this.lblText.Text = "Text";
            this.lblText.UseCompatibleTextRendering = true;
            //
            // memText
            //
            this.memText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memText.DataMember = "Text";
            this.memText.DataSource = this.qryFaAbmachungen;
            this.memText.Location = new System.Drawing.Point(143, 402);
            this.memText.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.memText.Name = "memText";
            this.memText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memText.Properties.Appearance.Options.UseBackColor = true;
            this.memText.Properties.Appearance.Options.UseBorderColor = true;
            this.memText.Properties.Appearance.Options.UseFont = true;
            this.memText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memText.Size = new System.Drawing.Size(356, 185);
            this.memText.TabIndex = 14;
            //
            // lblBeteiligte
            //
            this.lblBeteiligte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBeteiligte.Location = new System.Drawing.Point(518, 252);
            this.lblBeteiligte.Name = "lblBeteiligte";
            this.lblBeteiligte.Size = new System.Drawing.Size(211, 24);
            this.lblBeteiligte.TabIndex = 15;
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
            this.edtBeteiligte.DataSource = this.qryFaAbmachungen;
            this.edtBeteiligte.Location = new System.Drawing.Point(518, 279);
            this.edtBeteiligte.Name = "edtBeteiligte";
            this.edtBeteiligte.Size = new System.Drawing.Size(211, 87);
            this.edtBeteiligte.TabIndex = 16;
            //
            // lblBetroffeneLebensbereiche
            //
            this.lblBetroffeneLebensbereiche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBetroffeneLebensbereiche.Location = new System.Drawing.Point(518, 372);
            this.lblBetroffeneLebensbereiche.Name = "lblBetroffeneLebensbereiche";
            this.lblBetroffeneLebensbereiche.Size = new System.Drawing.Size(211, 24);
            this.lblBetroffeneLebensbereiche.TabIndex = 17;
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
            this.edtBetroffeneLebensbereiche.DataSource = this.qryFaAbmachungen;
            this.edtBetroffeneLebensbereiche.Location = new System.Drawing.Point(518, 399);
            this.edtBetroffeneLebensbereiche.LOVName = "FaLebensbereich";
            this.edtBetroffeneLebensbereiche.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtBetroffeneLebensbereiche.Name = "edtBetroffeneLebensbereiche";
            this.edtBetroffeneLebensbereiche.Size = new System.Drawing.Size(211, 188);
            this.edtBetroffeneLebensbereiche.TabIndex = 18;
            //
            // CtlFaAbmachungen
            //
            this.ActiveSQLQuery = this.qryFaAbmachungen;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.edtBetroffeneLebensbereiche);
            this.Controls.Add(this.lblBetroffeneLebensbereiche);
            this.Controls.Add(this.edtBeteiligte);
            this.Controls.Add(this.lblBeteiligte);
            this.Controls.Add(this.memText);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.edtStichworte);
            this.Controls.Add(this.lblStichworte);
            this.Controls.Add(this.edtAutor);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.edtDienstleistung);
            this.Controls.Add(this.lblDienstleistung);
            this.Controls.Add(this.chkFaDokAbmErledi);
            this.Controls.Add(this.edtPerDatumTermin);
            this.Controls.Add(this.lblPerDatumTermin);
            this.Controls.Add(this.edtDatumErstellung);
            this.Controls.Add(this.lblDatumErstellung);
            this.Controls.Add(this.grdAbmachungen);
            this.Controls.Add(this.panTitel);
            this.Name = "CtlFaAbmachungen";
            this.Size = new System.Drawing.Size(739, 596);
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAbmachungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaAbmachungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAbmachungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumErstellung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumErstellung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPerDatumTermin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerDatumTermin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFaDokAbmErledi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDienstleistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAutor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichworte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichworte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memText.Properties)).EndInit();
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

        private void edtAutor_EditValueChanged(object sender, System.EventArgs e)
        {
            // data has changed
            this._hasAutorChanged = true;
        }

        private void edtAutor_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            e.Cancel = !this.DialogAutor(sender, e);
        }

        private void qryFaAbmachungen_AfterFill(object sender, EventArgs e)
        {
            // fill Beteiligte Personen und Institutionen
            UpdateBeteiligtePersonenInstitutionen();
        }

        private void qryFaAbmachungen_AfterInsert(object sender, System.EventArgs e)
        {
            // apply person id
            qryFaAbmachungen["BaPersonID"] = _baPersonID;

            // apply default values
            qryFaAbmachungen["Autor"] = this._userFullName;
            qryFaAbmachungen["UserID"] = Session.User.UserID;
            qryFaAbmachungen["Erstellung"] = DateTime.Now;

            // set focus
            edtDatumErstellung.Focus();
        }

        private void qryFaAbmachungen_AfterPost(object sender, System.EventArgs e)
        {
            // apply lookup fields
            qryFaAbmachungen["Dienstleistung"] = edtDienstleistung.Text;
            qryFaAbmachungen["Themen"] = edtBetroffeneLebensbereiche.GetDisplayText(Convert.ToString(edtBetroffeneLebensbereiche.EditValue));
        }

        private void qryFaAbmachungen_BeforePost(object sender, System.EventArgs e)
        {
            // validate must fields
            DBUtil.CheckNotNullField(edtDatumErstellung, lblDatumErstellung.Text);
            DBUtil.CheckNotNullField(edtPerDatumTermin, lblPerDatumTermin.Text);
            DBUtil.CheckNotNullField(edtDienstleistung, lblDienstleistung.Text);

            // validate buttonedits
            if (this._hasAutorChanged && !this.DialogAutor(this, new UserModifiedFldEventArgs(false, false)))
            {
                // invalid Autor
                edtAutor.Focus();
                throw new KissCancelException();
            }

            // reset flags
            this._hasAutorChanged = false;

            // validate dates
            if (Convert.ToDateTime(qryFaAbmachungen["PerDatum"]) <= Convert.ToDateTime(qryFaAbmachungen["Erstellung"]))
            {
                // invalid range
                edtPerDatumTermin.Focus();
                throw new KissInfoException(KissMsg.GetMLMessage("CtlFaAbmachungen", "InvalidDateOrder", "Das Datum 'Per Datum' ist ungültig - es muss grösser als 'Erstellung - {0}' sein.", KissMsgCode.MsgInfo, Convert.ToDateTime(qryFaAbmachungen["Erstellung"]).ToString("dd.MM.yyyy")), (Control)edtPerDatumTermin);
            }
        }

        private void qryFaAbmachungen_PositionChanged(object sender, EventArgs e)
        {
            // do update list
            UpdateBeteiligtePersonenInstitutionen();
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string titleName, Image titleImage, int baPersonID)
        {
            // validate
            if (baPersonID < 1)
            {
                // do not continue
                qryFaAbmachungen.CanInsert = false;
                qryFaAbmachungen.CanUpdate = false;
                qryFaAbmachungen.CanDelete = false;

                // handle editmode of controls
                qryFaAbmachungen.EnableBoundFields(qryFaAbmachungen.CanUpdate);
                return;
            }

            // allow changes
            qryFaAbmachungen.CanInsert = true;
            qryFaAbmachungen.CanUpdate = true;
            qryFaAbmachungen.CanDelete = true;

            // apply values
            _baPersonID = baPersonID;
            picTitel.Image = titleImage;
            lblTitel.Text = titleName;

            // fill data
            qryFaAbmachungen.Fill(@"
                DECLARE @BaPersonID INT
                DECLARE @LanguageCode INT

                SET @BaPersonID = {0}
                SET @LanguageCode = ISNULL({1}, 1)

                SELECT ABM.*,
                        Autor = dbo.fnGetLastFirstName(ABM.UserID, NULL, NULL),
                        Dienstleistung = dbo.fnGetLOVMLText('FaModulDienstleistungen', ABM.DienstleistungCode, @LanguageCode),
                        Themen = dbo.fnLOVMLColumnListe('FaLebensbereich', ABM.ThemenCodes, NULL, @LanguageCode)
                FROM dbo.FaAbmachungen ABM WITH (READUNCOMMITTED)
                WHERE ABM.BaPersonID = @BaPersonID
                ORDER BY ABM.Erstellung ASC, ABM.PerDatum ASC, ABM.Erledigt ASC;", baPersonID, Session.User.LanguageCode);

            // select last row
            qryFaAbmachungen.Last();

            // insert new entry if not yet any entry found
            if (qryFaAbmachungen.CanInsert && qryFaAbmachungen.Count < 1)
            {
                //qryFaAbmachungen.Insert(null);
            }

            // reset flags
            _hasAutorChanged = false;
        }

        #endregion

        #region Private Methods

        private Boolean DialogAutor(Object sender, UserModifiedFldEventArgs e)
        {
            try
            {
                // check if data can be altered
                if (!qryFaAbmachungen.CanUpdate || qryFaAbmachungen.Count < 1 || edtAutor.EditMode == EditModeType.ReadOnly)
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
                        qryFaAbmachungen["UserID"] = DBNull.Value;
                        qryFaAbmachungen["Autor"] = DBNull.Value;
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
                    qryFaAbmachungen["UserID"] = dlg["UserID$"];
                    qryFaAbmachungen["Autor"] = dlg["Name"];

                    // reset flags
                    _hasAutorChanged = false;

                    // success
                    return true;
                }

                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlFaAbmachungen", "ErrorIKissUserModified", "Fehler bei der Verarbeitung.", ex);
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
                FROM dbo.fnFaGetBeteiligtePersonenInstitutionen({0}, {1}) FCN;",
                DBUtil.SqlLiteral(_baPersonID),
                DBUtil.SqlLiteral(qryFaAbmachungen[edtBeteiligte.DataMember]));

            // set check-states from current edit-value
            edtBeteiligte.EditValue = DBUtil.IsEmpty(qryFaAbmachungen[edtBeteiligte.DataMember]) ? null : Convert.ToString(qryFaAbmachungen[edtBeteiligte.DataMember]);
        }

        #endregion

        #endregion
    }
}