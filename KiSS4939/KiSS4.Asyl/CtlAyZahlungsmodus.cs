using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Asyl
{
    /// <summary>
    /// Summary description for CtlZahlungsmodus.
    /// </summary>
    public class CtlAyZahlungsmodus : KissUserControl
    {
        #region Fields

        #region Public Fields

        public KiSS4.Common.CtlZahlungsweg ctlZahlungsweg;

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly int _faLeistungId;

        #endregion

        #region Private Fields

        private KiSS4.Gui.KissCheckEdit chkImVormonat;
        private KiSS4.Gui.KissCheckEdit chkShowAll;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colKbAuszahlungsArtCode;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colNameZahlungsmodus;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.MonthCalendar edtCalendar;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtKbAuszahlungsArtCode;
        private KiSS4.Gui.KissTextEdit edtNameZahlungsmodus;
        private KiSS4.Common.KissReferenzNrEdit edtReferenzNummer;
        private KiSS4.Gui.KissCalcEdit edtTagImMonat1;
        private KiSS4.Gui.KissCalcEdit edtTagImMonat2;
        private KiSS4.Gui.KissGrid grdBgZahlungsmodus;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgZahlungsmodus;
        private KiSS4.Gui.KissLabel lblBerechnungsart;
        private KiSS4.Gui.KissLabel lblBerechnungsart_false;
        private KiSS4.Gui.KissLabel lblBerechnungsart_true;
        private KiSS4.Gui.KissLabel lblDatumRichtwert;
        private KiSS4.Gui.KissLabel lblDesAkteullenMonats;
        private KiSS4.Gui.KissLabel lblGueltikeit;
        private KiSS4.Gui.KissLabel lblGueltikeitBis;
        private KiSS4.Gui.KissLabel lblJeweilsAm;
        private KiSS4.Gui.KissLabel lblKbAuszahlungsArtCode;
        private KiSS4.Gui.KissLabel lblNameZahlungsmodus;
        private KiSS4.Gui.KissLabel lblReferenzNummer;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblUndAm;
        private KiSS4.Gui.KissRadioGroup optBerechnungsart;
        private KiSS4.Gui.KissRadioGroup optPeriode;
        private System.Windows.Forms.Panel panCalendar;
        private System.Windows.Forms.Panel panFill;
        private System.Windows.Forms.Panel panMonatlich;
        private System.Windows.Forms.Panel panRight;
        private System.Windows.Forms.Panel panTag1;
        private System.Windows.Forms.Panel panTag2;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBgZahlungsmodus;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private SharpLibrary.WinControls.TabPageEx tabKreditor;
        private SharpLibrary.WinControls.TabPageEx tabPeriodizitaet;
        private KiSS4.Gui.KissTabControlEx xTabControl1;

        #endregion

        #endregion

        #region Constructors

        public CtlAyZahlungsmodus()
        {
            InitializeComponent();
        }

        public CtlAyZahlungsmodus(Image titelImage, string titelText, int faLeistungId)
            : this()
        {
            picTitel.Image = titelImage;
            lblTitel.Text = titelText;

            colKbAuszahlungsArtCode.ColumnEdit = grdBgZahlungsmodus.GetLOVLookUpEdit((SqlQuery)edtKbAuszahlungsArtCode.Properties.DataSource);

            qryBgZahlungsmodus.Fill(faLeistungId);

            _faLeistungId = faLeistungId;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAyZahlungsmodus));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            qryBgZahlungsmodus = new KiSS4.DB.SqlQuery(components);
            grdBgZahlungsmodus = new KiSS4.Gui.KissGrid();
            grvBgZahlungsmodus = new DevExpress.XtraGrid.Views.Grid.GridView();
            colNameZahlungsmodus = new DevExpress.XtraGrid.Columns.GridColumn();
            colKbAuszahlungsArtCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            colAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            edtKbAuszahlungsArtCode = new KiSS4.Gui.KissLookUpEdit();
            lblNameZahlungsmodus = new KiSS4.Gui.KissLabel();
            lblKbAuszahlungsArtCode = new KiSS4.Gui.KissLabel();
            edtNameZahlungsmodus = new KiSS4.Gui.KissTextEdit();
            lblTitel = new KiSS4.Gui.KissLabel();
            xTabControl1 = new KiSS4.Gui.KissTabControlEx();
            tabKreditor = new SharpLibrary.WinControls.TabPageEx();
            ctlZahlungsweg = new KiSS4.Common.CtlZahlungsweg();
            lblReferenzNummer = new KiSS4.Gui.KissLabel();
            edtReferenzNummer = new KiSS4.Common.KissReferenzNrEdit(components);
            tabPeriodizitaet = new SharpLibrary.WinControls.TabPageEx();
            panFill = new System.Windows.Forms.Panel();
            panCalendar = new System.Windows.Forms.Panel();
            lblBerechnungsart_false = new KiSS4.Gui.KissLabel();
            lblBerechnungsart_true = new KiSS4.Gui.KissLabel();
            lblBerechnungsart = new KiSS4.Gui.KissLabel();
            optBerechnungsart = new KiSS4.Gui.KissRadioGroup(components);
            edtCalendar = new System.Windows.Forms.MonthCalendar();
            panMonatlich = new System.Windows.Forms.Panel();
            panTag2 = new System.Windows.Forms.Panel();
            lblDesAkteullenMonats = new KiSS4.Gui.KissLabel();
            lblUndAm = new KiSS4.Gui.KissLabel();
            edtTagImMonat2 = new KiSS4.Gui.KissCalcEdit();
            panTag1 = new System.Windows.Forms.Panel();
            chkImVormonat = new KiSS4.Gui.KissCheckEdit();
            lblJeweilsAm = new KiSS4.Gui.KissLabel();
            edtTagImMonat1 = new KiSS4.Gui.KissCalcEdit();
            lblDatumRichtwert = new KiSS4.Gui.KissLabel();
            optPeriode = new KiSS4.Gui.KissRadioGroup(components);
            panRight = new System.Windows.Forms.Panel();
            picTitel = new System.Windows.Forms.PictureBox();
            edtDatumVon = new KiSS4.Gui.KissDateEdit();
            edtDatumBis = new KiSS4.Gui.KissDateEdit();
            lblGueltikeit = new KiSS4.Gui.KissLabel();
            lblGueltikeitBis = new KiSS4.Gui.KissLabel();
            chkShowAll = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(qryBgZahlungsmodus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(grdBgZahlungsmodus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(grvBgZahlungsmodus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(edtKbAuszahlungsArtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(edtKbAuszahlungsArtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lblNameZahlungsmodus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lblKbAuszahlungsArtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(edtNameZahlungsmodus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lblTitel)).BeginInit();
            xTabControl1.SuspendLayout();
            tabKreditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(lblReferenzNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(edtReferenzNummer.Properties)).BeginInit();
            tabPeriodizitaet.SuspendLayout();
            panFill.SuspendLayout();
            panCalendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(lblBerechnungsart_false)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lblBerechnungsart_true)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lblBerechnungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(optBerechnungsart.Properties)).BeginInit();
            panMonatlich.SuspendLayout();
            panTag2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(lblDesAkteullenMonats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lblUndAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(edtTagImMonat2.Properties)).BeginInit();
            panTag1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(chkImVormonat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lblJeweilsAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(edtTagImMonat1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lblDatumRichtwert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(optPeriode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lblGueltikeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lblGueltikeitBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(chkShowAll.Properties)).BeginInit();
            SuspendLayout();
            //
            // qryBgZahlungsmodus
            //
            qryBgZahlungsmodus.CanDelete = true;
            qryBgZahlungsmodus.CanInsert = true;
            qryBgZahlungsmodus.CanUpdate = true;
            qryBgZahlungsmodus.HostControl = this;
            qryBgZahlungsmodus.SelectStatement = resources.GetString("qryBgZahlungsmodus.SelectStatement");
            qryBgZahlungsmodus.TableName = "BgZahlungsmodus";
            qryBgZahlungsmodus.AfterFill += new System.EventHandler(qryBgZahlungsmodus_AfterFill);
            qryBgZahlungsmodus.AfterInsert += new System.EventHandler(qryBgZahlungsmodus_AfterInsert);
            qryBgZahlungsmodus.BeforePost += new System.EventHandler(qryBgZahlungsmodus_BeforePost);
            qryBgZahlungsmodus.AfterPost += new System.EventHandler(qryBgZahlungsmodus_AfterPost);
            qryBgZahlungsmodus.PositionChanged += new System.EventHandler(qryBgZahlungsmodus_PositionChanged);
            //
            // grdBgZahlungsmodus
            //
            grdBgZahlungsmodus.DataSource = qryBgZahlungsmodus;
            //
            //
            //
            grdBgZahlungsmodus.EmbeddedNavigator.Name = "";
            grdBgZahlungsmodus.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            grdBgZahlungsmodus.Location = new System.Drawing.Point(8, 32);
            grdBgZahlungsmodus.MainView = grvBgZahlungsmodus;
            grdBgZahlungsmodus.Name = "grdBgZahlungsmodus";
            grdBgZahlungsmodus.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            repositoryItemCheckEdit1});
            grdBgZahlungsmodus.Size = new System.Drawing.Size(664, 176);
            grdBgZahlungsmodus.TabIndex = 1;
            grdBgZahlungsmodus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            grvBgZahlungsmodus});
            //
            // grvBgZahlungsmodus
            //
            grvBgZahlungsmodus.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            grvBgZahlungsmodus.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            grvBgZahlungsmodus.Appearance.Empty.Options.UseBackColor = true;
            grvBgZahlungsmodus.Appearance.Empty.Options.UseFont = true;
            grvBgZahlungsmodus.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            grvBgZahlungsmodus.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            grvBgZahlungsmodus.Appearance.EvenRow.Options.UseBackColor = true;
            grvBgZahlungsmodus.Appearance.EvenRow.Options.UseFont = true;
            grvBgZahlungsmodus.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            grvBgZahlungsmodus.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            grvBgZahlungsmodus.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            grvBgZahlungsmodus.Appearance.FocusedCell.Options.UseBackColor = true;
            grvBgZahlungsmodus.Appearance.FocusedCell.Options.UseFont = true;
            grvBgZahlungsmodus.Appearance.FocusedCell.Options.UseForeColor = true;
            grvBgZahlungsmodus.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            grvBgZahlungsmodus.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            grvBgZahlungsmodus.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            grvBgZahlungsmodus.Appearance.FocusedRow.Options.UseBackColor = true;
            grvBgZahlungsmodus.Appearance.FocusedRow.Options.UseFont = true;
            grvBgZahlungsmodus.Appearance.FocusedRow.Options.UseForeColor = true;
            grvBgZahlungsmodus.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            grvBgZahlungsmodus.Appearance.GroupPanel.Options.UseBackColor = true;
            grvBgZahlungsmodus.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            grvBgZahlungsmodus.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            grvBgZahlungsmodus.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            grvBgZahlungsmodus.Appearance.GroupRow.Options.UseBackColor = true;
            grvBgZahlungsmodus.Appearance.GroupRow.Options.UseFont = true;
            grvBgZahlungsmodus.Appearance.GroupRow.Options.UseForeColor = true;
            grvBgZahlungsmodus.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            grvBgZahlungsmodus.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            grvBgZahlungsmodus.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            grvBgZahlungsmodus.Appearance.HeaderPanel.Options.UseBackColor = true;
            grvBgZahlungsmodus.Appearance.HeaderPanel.Options.UseBorderColor = true;
            grvBgZahlungsmodus.Appearance.HeaderPanel.Options.UseFont = true;
            grvBgZahlungsmodus.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            grvBgZahlungsmodus.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            grvBgZahlungsmodus.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            grvBgZahlungsmodus.Appearance.HideSelectionRow.Options.UseBackColor = true;
            grvBgZahlungsmodus.Appearance.HideSelectionRow.Options.UseFont = true;
            grvBgZahlungsmodus.Appearance.HideSelectionRow.Options.UseForeColor = true;
            grvBgZahlungsmodus.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            grvBgZahlungsmodus.Appearance.HorzLine.Options.UseBackColor = true;
            grvBgZahlungsmodus.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            grvBgZahlungsmodus.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            grvBgZahlungsmodus.Appearance.OddRow.Options.UseBackColor = true;
            grvBgZahlungsmodus.Appearance.OddRow.Options.UseFont = true;
            grvBgZahlungsmodus.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            grvBgZahlungsmodus.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            grvBgZahlungsmodus.Appearance.Row.Options.UseBackColor = true;
            grvBgZahlungsmodus.Appearance.Row.Options.UseFont = true;
            grvBgZahlungsmodus.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            grvBgZahlungsmodus.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            grvBgZahlungsmodus.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            grvBgZahlungsmodus.Appearance.SelectedRow.Options.UseBackColor = true;
            grvBgZahlungsmodus.Appearance.SelectedRow.Options.UseFont = true;
            grvBgZahlungsmodus.Appearance.SelectedRow.Options.UseForeColor = true;
            grvBgZahlungsmodus.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            grvBgZahlungsmodus.Appearance.VertLine.Options.UseBackColor = true;
            grvBgZahlungsmodus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            grvBgZahlungsmodus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colNameZahlungsmodus,
            colKbAuszahlungsArtCode,
            colKreditor,
            colAktiv});
            grvBgZahlungsmodus.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            grvBgZahlungsmodus.GridControl = grdBgZahlungsmodus;
            grvBgZahlungsmodus.Name = "grvBgZahlungsmodus";
            grvBgZahlungsmodus.OptionsBehavior.Editable = false;
            grvBgZahlungsmodus.OptionsCustomization.AllowFilter = false;
            grvBgZahlungsmodus.OptionsFilter.AllowFilterEditor = false;
            grvBgZahlungsmodus.OptionsFilter.UseNewCustomFilterDialog = true;
            grvBgZahlungsmodus.OptionsMenu.EnableColumnMenu = false;
            grvBgZahlungsmodus.OptionsNavigation.AutoFocusNewRow = true;
            grvBgZahlungsmodus.OptionsNavigation.UseTabKey = false;
            grvBgZahlungsmodus.OptionsView.ColumnAutoWidth = false;
            grvBgZahlungsmodus.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            grvBgZahlungsmodus.OptionsView.ShowGroupPanel = false;
            grvBgZahlungsmodus.OptionsView.ShowIndicator = false;
            //
            // colNameZahlungsmodus
            //
            colNameZahlungsmodus.Caption = "Name";
            colNameZahlungsmodus.FieldName = "NameZahlungsmodus";
            colNameZahlungsmodus.Name = "colNameZahlungsmodus";
            colNameZahlungsmodus.Visible = true;
            colNameZahlungsmodus.VisibleIndex = 0;
            colNameZahlungsmodus.Width = 221;
            //
            // colKbAuszahlungsArtCode
            //
            colKbAuszahlungsArtCode.Caption = "Zahlungsart";
            colKbAuszahlungsArtCode.FieldName = "KbAuszahlungsArtCode";
            colKbAuszahlungsArtCode.Name = "colKbAuszahlungsArtCode";
            colKbAuszahlungsArtCode.Visible = true;
            colKbAuszahlungsArtCode.VisibleIndex = 1;
            colKbAuszahlungsArtCode.Width = 181;
            //
            // colKreditor
            //
            colKreditor.Caption = "Kreditor";
            colKreditor.FieldName = "Kreditor";
            colKreditor.Name = "colKreditor";
            colKreditor.Visible = true;
            colKreditor.VisibleIndex = 2;
            colKreditor.Width = 200;
            //
            // colAktiv
            //
            colAktiv.Caption = "Aktiv";
            colAktiv.ColumnEdit = repositoryItemCheckEdit1;
            colAktiv.FieldName = "Aktiv";
            colAktiv.Name = "colAktiv";
            colAktiv.Visible = true;
            colAktiv.VisibleIndex = 3;
            colAktiv.Width = 40;
            //
            // repositoryItemCheckEdit1
            //
            repositoryItemCheckEdit1.AutoHeight = false;
            repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            //
            // edtKbAuszahlungsArtCode
            //
            edtKbAuszahlungsArtCode.DataMember = "KbAuszahlungsArtCode";
            edtKbAuszahlungsArtCode.DataSource = qryBgZahlungsmodus;
            edtKbAuszahlungsArtCode.Location = new System.Drawing.Point(160, 239);
            edtKbAuszahlungsArtCode.LOVFilter = "%A%";
            edtKbAuszahlungsArtCode.LOVName = "KbAuszahlungsArt";
            edtKbAuszahlungsArtCode.Name = "edtKbAuszahlungsArtCode";
            edtKbAuszahlungsArtCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            edtKbAuszahlungsArtCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            edtKbAuszahlungsArtCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            edtKbAuszahlungsArtCode.Properties.Appearance.Options.UseBackColor = true;
            edtKbAuszahlungsArtCode.Properties.Appearance.Options.UseBorderColor = true;
            edtKbAuszahlungsArtCode.Properties.Appearance.Options.UseFont = true;
            edtKbAuszahlungsArtCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            edtKbAuszahlungsArtCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            edtKbAuszahlungsArtCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            edtKbAuszahlungsArtCode.Properties.AppearanceDropDown.Options.UseFont = true;
            edtKbAuszahlungsArtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            edtKbAuszahlungsArtCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            edtKbAuszahlungsArtCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            edtKbAuszahlungsArtCode.Properties.DisplayMember = "Text";
            edtKbAuszahlungsArtCode.Properties.NullText = "";
            edtKbAuszahlungsArtCode.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            edtKbAuszahlungsArtCode.Properties.ShowFooter = false;
            edtKbAuszahlungsArtCode.Properties.ShowHeader = false;
            edtKbAuszahlungsArtCode.Properties.ValueMember = "Code";
            edtKbAuszahlungsArtCode.Size = new System.Drawing.Size(512, 24);
            edtKbAuszahlungsArtCode.TabIndex = 5;
            edtKbAuszahlungsArtCode.EditValueChanged += new System.EventHandler(edtKbAuszahlungsArtCode_EditValueChanged);
            //
            // lblNameZahlungsmodus
            //
            lblNameZahlungsmodus.Location = new System.Drawing.Point(16, 216);
            lblNameZahlungsmodus.Name = "lblNameZahlungsmodus";
            lblNameZahlungsmodus.Size = new System.Drawing.Size(112, 24);
            lblNameZahlungsmodus.TabIndex = 2;
            lblNameZahlungsmodus.Text = "Zahlungsmodus";
            //
            // lblKbAuszahlungsArtCode
            //
            lblKbAuszahlungsArtCode.Location = new System.Drawing.Point(16, 239);
            lblKbAuszahlungsArtCode.Name = "lblKbAuszahlungsArtCode";
            lblKbAuszahlungsArtCode.Size = new System.Drawing.Size(112, 24);
            lblKbAuszahlungsArtCode.TabIndex = 4;
            lblKbAuszahlungsArtCode.Text = "Zahlungsart";
            //
            // edtNameZahlungsmodus
            //
            edtNameZahlungsmodus.DataMember = "NameZahlungsmodus";
            edtNameZahlungsmodus.DataSource = qryBgZahlungsmodus;
            edtNameZahlungsmodus.Location = new System.Drawing.Point(160, 216);
            edtNameZahlungsmodus.Name = "edtNameZahlungsmodus";
            edtNameZahlungsmodus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            edtNameZahlungsmodus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            edtNameZahlungsmodus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            edtNameZahlungsmodus.Properties.Appearance.Options.UseBackColor = true;
            edtNameZahlungsmodus.Properties.Appearance.Options.UseBorderColor = true;
            edtNameZahlungsmodus.Properties.Appearance.Options.UseFont = true;
            edtNameZahlungsmodus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            edtNameZahlungsmodus.Size = new System.Drawing.Size(512, 24);
            edtNameZahlungsmodus.TabIndex = 3;
            //
            // lblTitel
            //
            lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            lblTitel.Location = new System.Drawing.Point(32, 8);
            lblTitel.Name = "lblTitel";
            lblTitel.Size = new System.Drawing.Size(640, 16);
            lblTitel.TabIndex = 0;
            lblTitel.Text = "Zahlungsmodus";
            //
            // xTabControl1
            //
            xTabControl1.Controls.Add(tabKreditor);
            xTabControl1.Controls.Add(tabPeriodizitaet);
            xTabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            xTabControl1.Location = new System.Drawing.Point(8, 296);
            xTabControl1.Name = "xTabControl1";
            xTabControl1.ShowFixedWidthTooltip = true;
            xTabControl1.Size = new System.Drawing.Size(664, 216);
            xTabControl1.TabIndex = 6;
            xTabControl1.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            tabKreditor,
            tabPeriodizitaet});
            xTabControl1.TabsLineColor = System.Drawing.Color.Black;
            xTabControl1.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            xTabControl1.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            xTabControl1.Text = "xTabControl1";
            //
            // tabKreditor
            //
            tabKreditor.Controls.Add(ctlZahlungsweg);
            tabKreditor.Controls.Add(lblReferenzNummer);
            tabKreditor.Controls.Add(edtReferenzNummer);
            tabKreditor.Location = new System.Drawing.Point(6, 32);
            tabKreditor.Name = "tabKreditor";
            tabKreditor.Size = new System.Drawing.Size(652, 178);
            tabKreditor.TabIndex = 0;
            tabKreditor.Title = "Kreditor und Zahlungsweg";
            //
            // ctlZahlungsweg
            //
            ctlZahlungsweg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            ctlZahlungsweg.DataMember = "BaZahlungswegID";
            ctlZahlungsweg.DataSource = qryBgZahlungsmodus;
            ctlZahlungsweg.Location = new System.Drawing.Point(16, 16);
            ctlZahlungsweg.Modul = KiSS4.Gui.ModulID.A;
            ctlZahlungsweg.Name = "ctlZahlungsweg";
            ctlZahlungsweg.Size = new System.Drawing.Size(616, 112);
            ctlZahlungsweg.TabIndex = 10;
            ctlZahlungsweg.BaZahlungswegIDChanged += new System.EventHandler(ctlZahlungsweg_ZahlungswegIDChanged);
            //
            // lblReferenzNummer
            //
            lblReferenzNummer.Location = new System.Drawing.Point(16, 136);
            lblReferenzNummer.Name = "lblReferenzNummer";
            lblReferenzNummer.Size = new System.Drawing.Size(128, 24);
            lblReferenzNummer.TabIndex = 7;
            lblReferenzNummer.Text = "Referenznummer";
            //
            // edtReferenzNummer
            //
            edtReferenzNummer.DataMember = "ReferenzNummer";
            edtReferenzNummer.DataSource = qryBgZahlungsmodus;
            edtReferenzNummer.Location = new System.Drawing.Point(152, 136);
            edtReferenzNummer.Name = "edtReferenzNummer";
            edtReferenzNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            edtReferenzNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            edtReferenzNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            edtReferenzNummer.Properties.Appearance.Options.UseBackColor = true;
            edtReferenzNummer.Properties.Appearance.Options.UseBorderColor = true;
            edtReferenzNummer.Properties.Appearance.Options.UseFont = true;
            edtReferenzNummer.Properties.Appearance.Options.UseTextOptions = true;
            edtReferenzNummer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            edtReferenzNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            edtReferenzNummer.Size = new System.Drawing.Size(480, 24);
            edtReferenzNummer.TabIndex = 8;
            //
            // tabPeriodizitaet
            //
            tabPeriodizitaet.Controls.Add(panFill);
            tabPeriodizitaet.Controls.Add(panRight);
            tabPeriodizitaet.Location = new System.Drawing.Point(6, 32);
            tabPeriodizitaet.Name = "tabPeriodizitaet";
            tabPeriodizitaet.Size = new System.Drawing.Size(652, 178);
            tabPeriodizitaet.TabIndex = 1;
            tabPeriodizitaet.Title = "Periodizität";
            //
            // panFill
            //
            panFill.Controls.Add(panCalendar);
            panFill.Controls.Add(panMonatlich);
            panFill.Controls.Add(optPeriode);
            panFill.Dock = System.Windows.Forms.DockStyle.Fill;
            panFill.Location = new System.Drawing.Point(32, 0);
            panFill.Name = "panFill";
            panFill.Size = new System.Drawing.Size(620, 178);
            panFill.TabIndex = 5;
            //
            // panCalendar
            //
            panCalendar.Controls.Add(lblBerechnungsart_false);
            panCalendar.Controls.Add(lblBerechnungsart_true);
            panCalendar.Controls.Add(lblBerechnungsart);
            panCalendar.Controls.Add(optBerechnungsart);
            panCalendar.Controls.Add(edtCalendar);
            panCalendar.Dock = System.Windows.Forms.DockStyle.Top;
            panCalendar.Location = new System.Drawing.Point(0, 88);
            panCalendar.Name = "panCalendar";
            panCalendar.Size = new System.Drawing.Size(620, 160);
            panCalendar.TabIndex = 6;
            //
            // lblBerechnungsart_false
            //
            lblBerechnungsart_false.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            lblBerechnungsart_false.Location = new System.Drawing.Point(250, 117);
            lblBerechnungsart_false.Name = "lblBerechnungsart_false";
            lblBerechnungsart_false.Size = new System.Drawing.Size(232, 16);
            lblBerechnungsart_false.TabIndex = 4;
            lblBerechnungsart_false.Text = "nächsten Termin rsp. Monatsende";
            //
            // lblBerechnungsart_true
            //
            lblBerechnungsart_true.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            lblBerechnungsart_true.Location = new System.Drawing.Point(248, 72);
            lblBerechnungsart_true.Name = "lblBerechnungsart_true";
            lblBerechnungsart_true.Size = new System.Drawing.Size(232, 16);
            lblBerechnungsart_true.TabIndex = 3;
            lblBerechnungsart_true.Text = "Zahlungsmodus geteilt durch Anzahl Termine";
            //
            // lblBerechnungsart
            //
            lblBerechnungsart.Location = new System.Drawing.Point(232, 24);
            lblBerechnungsart.Name = "lblBerechnungsart";
            lblBerechnungsart.Size = new System.Drawing.Size(256, 24);
            lblBerechnungsart.TabIndex = 2;
            lblBerechnungsart.Text = "Berechnungsart der einzelnen Auszahlungen:";
            //
            // optBerechnungsart
            //
            optBerechnungsart.DataMember = "BetragGleich";
            optBerechnungsart.DataSource = qryBgZahlungsmodus;
            optBerechnungsart.Location = new System.Drawing.Point(232, 40);
            optBerechnungsart.Name = "optBerechnungsart";
            optBerechnungsart.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            optBerechnungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            optBerechnungsart.Properties.Appearance.Options.UseBackColor = true;
            optBerechnungsart.Properties.Appearance.Options.UseFont = true;
            optBerechnungsart.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            optBerechnungsart.Properties.AppearanceDisabled.Options.UseBackColor = true;
            optBerechnungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            optBerechnungsart.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Monatlicher Gesamtbetrag für diesen"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Proportional zur Anzahl Tage bis zum")});
            optBerechnungsart.Size = new System.Drawing.Size(248, 96);
            optBerechnungsart.TabIndex = 1;
            //
            // edtCalendar
            //
            edtCalendar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            edtCalendar.Location = new System.Drawing.Point(8, 0);
            edtCalendar.Name = "edtCalendar";
            edtCalendar.ShowToday = false;
            edtCalendar.ShowTodayCircle = false;
            edtCalendar.TabIndex = 0;
            edtCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(edtCalendar_DateSelected);
            //
            // panMonatlich
            //
            panMonatlich.Controls.Add(panTag2);
            panMonatlich.Controls.Add(panTag1);
            panMonatlich.Controls.Add(lblDatumRichtwert);
            panMonatlich.Dock = System.Windows.Forms.DockStyle.Top;
            panMonatlich.Location = new System.Drawing.Point(0, 24);
            panMonatlich.Name = "panMonatlich";
            panMonatlich.Size = new System.Drawing.Size(620, 64);
            panMonatlich.TabIndex = 5;
            //
            // panTag2
            //
            panTag2.Controls.Add(lblDesAkteullenMonats);
            panTag2.Controls.Add(lblUndAm);
            panTag2.Controls.Add(edtTagImMonat2);
            panTag2.Dock = System.Windows.Forms.DockStyle.Top;
            panTag2.Location = new System.Drawing.Point(0, 24);
            panTag2.Name = "panTag2";
            panTag2.Size = new System.Drawing.Size(620, 24);
            panTag2.TabIndex = 4;
            //
            // lblDesAkteullenMonats
            //
            lblDesAkteullenMonats.Location = new System.Drawing.Point(136, 0);
            lblDesAkteullenMonats.Name = "lblDesAkteullenMonats";
            lblDesAkteullenMonats.Size = new System.Drawing.Size(144, 24);
            lblDesAkteullenMonats.TabIndex = 2;
            lblDesAkteullenMonats.Text = "des aktuellen Monats";
            //
            // lblUndAm
            //
            lblUndAm.Location = new System.Drawing.Point(8, 0);
            lblUndAm.Name = "lblUndAm";
            lblUndAm.Size = new System.Drawing.Size(64, 24);
            lblUndAm.TabIndex = 1;
            lblUndAm.Text = "und am";
            lblUndAm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // edtTagImMonat2
            //
            edtTagImMonat2.DataMember = "TagImMonat_2";
            edtTagImMonat2.DataSource = qryBgZahlungsmodus;
            edtTagImMonat2.Location = new System.Drawing.Point(72, 0);
            edtTagImMonat2.Name = "edtTagImMonat2";
            edtTagImMonat2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            edtTagImMonat2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            edtTagImMonat2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            edtTagImMonat2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            edtTagImMonat2.Properties.Appearance.Options.UseBackColor = true;
            edtTagImMonat2.Properties.Appearance.Options.UseBorderColor = true;
            edtTagImMonat2.Properties.Appearance.Options.UseFont = true;
            edtTagImMonat2.Properties.Appearance.Options.UseTextOptions = true;
            edtTagImMonat2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            edtTagImMonat2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            edtTagImMonat2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            edtTagImMonat2.Properties.DisplayFormat.FormatString = "n0";
            edtTagImMonat2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            edtTagImMonat2.Properties.EditFormat.FormatString = "n0";
            edtTagImMonat2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            edtTagImMonat2.Size = new System.Drawing.Size(56, 24);
            edtTagImMonat2.TabIndex = 0;
            //
            // panTag1
            //
            panTag1.Controls.Add(chkImVormonat);
            panTag1.Controls.Add(lblJeweilsAm);
            panTag1.Controls.Add(edtTagImMonat1);
            panTag1.Dock = System.Windows.Forms.DockStyle.Top;
            panTag1.Location = new System.Drawing.Point(0, 0);
            panTag1.Name = "panTag1";
            panTag1.Size = new System.Drawing.Size(620, 24);
            panTag1.TabIndex = 3;
            //
            // chkImVormonat
            //
            chkImVormonat.DataMember = "ImVormonat";
            chkImVormonat.DataSource = qryBgZahlungsmodus;
            chkImVormonat.Location = new System.Drawing.Point(136, 3);
            chkImVormonat.Name = "chkImVormonat";
            chkImVormonat.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            chkImVormonat.Properties.Appearance.Options.UseBackColor = true;
            chkImVormonat.Properties.Caption = "des Vormonats";
            chkImVormonat.Size = new System.Drawing.Size(144, 21);
            chkImVormonat.TabIndex = 2;
            //
            // lblJeweilsAm
            //
            lblJeweilsAm.Location = new System.Drawing.Point(8, 0);
            lblJeweilsAm.Name = "lblJeweilsAm";
            lblJeweilsAm.Size = new System.Drawing.Size(64, 24);
            lblJeweilsAm.TabIndex = 1;
            lblJeweilsAm.Text = "jeweils am";
            lblJeweilsAm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // edtTagImMonat1
            //
            edtTagImMonat1.DataMember = "TagImMonat";
            edtTagImMonat1.DataSource = qryBgZahlungsmodus;
            edtTagImMonat1.Location = new System.Drawing.Point(72, 0);
            edtTagImMonat1.Name = "edtTagImMonat1";
            edtTagImMonat1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            edtTagImMonat1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            edtTagImMonat1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            edtTagImMonat1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            edtTagImMonat1.Properties.Appearance.Options.UseBackColor = true;
            edtTagImMonat1.Properties.Appearance.Options.UseBorderColor = true;
            edtTagImMonat1.Properties.Appearance.Options.UseFont = true;
            edtTagImMonat1.Properties.Appearance.Options.UseTextOptions = true;
            edtTagImMonat1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            edtTagImMonat1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            edtTagImMonat1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            edtTagImMonat1.Properties.DisplayFormat.FormatString = "n0";
            edtTagImMonat1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            edtTagImMonat1.Properties.EditFormat.FormatString = "n0";
            edtTagImMonat1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            edtTagImMonat1.Size = new System.Drawing.Size(56, 24);
            edtTagImMonat1.TabIndex = 0;
            //
            // lblDatumRichtwert
            //
            lblDatumRichtwert.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            lblDatumRichtwert.Location = new System.Drawing.Point(72, 48);
            lblDatumRichtwert.Name = "lblDatumRichtwert";
            lblDatumRichtwert.Size = new System.Drawing.Size(216, 16);
            lblDatumRichtwert.TabIndex = 5;
            lblDatumRichtwert.Text = "Diese Monatstage sind Richtwerte!";
            //
            // optPeriode
            //
            optPeriode.DataMember = "Periodizitaet";
            optPeriode.DataSource = qryBgZahlungsmodus;
            optPeriode.Dock = System.Windows.Forms.DockStyle.Top;
            optPeriode.Location = new System.Drawing.Point(0, 0);
            optPeriode.Name = "optPeriode";
            optPeriode.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            optPeriode.Properties.Appearance.Options.UseBackColor = true;
            optPeriode.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            optPeriode.Properties.AppearanceDisabled.Options.UseBackColor = true;
            optPeriode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            optPeriode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "1x pro Monat"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "2x pro Monat"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Individuell")});
            optPeriode.Size = new System.Drawing.Size(620, 24);
            optPeriode.TabIndex = 4;
            optPeriode.EditValueChanged += new System.EventHandler(optPeriode_EditValueChanged);
            //
            // panRight
            //
            panRight.Dock = System.Windows.Forms.DockStyle.Left;
            panRight.Location = new System.Drawing.Point(0, 0);
            panRight.Name = "panRight";
            panRight.Size = new System.Drawing.Size(32, 178);
            panRight.TabIndex = 4;
            //
            // picTitel
            //
            picTitel.Location = new System.Drawing.Point(8, 8);
            picTitel.Name = "picTitel";
            picTitel.Size = new System.Drawing.Size(16, 16);
            picTitel.TabIndex = 55;
            picTitel.TabStop = false;
            //
            // edtDatumVon
            //
            edtDatumVon.DataMember = "DatumVon";
            edtDatumVon.DataSource = qryBgZahlungsmodus;
            edtDatumVon.EditValue = null;
            edtDatumVon.Location = new System.Drawing.Point(160, 262);
            edtDatumVon.Name = "edtDatumVon";
            edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            edtDatumVon.Properties.Appearance.Options.UseFont = true;
            edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            edtDatumVon.Properties.ShowToday = false;
            edtDatumVon.Size = new System.Drawing.Size(112, 24);
            edtDatumVon.TabIndex = 56;
            //
            // edtDatumBis
            //
            edtDatumBis.DataMember = "DatumBis";
            edtDatumBis.DataSource = qryBgZahlungsmodus;
            edtDatumBis.EditValue = null;
            edtDatumBis.Location = new System.Drawing.Point(312, 262);
            edtDatumBis.Name = "edtDatumBis";
            edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            edtDatumBis.Properties.Appearance.Options.UseFont = true;
            edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            edtDatumBis.Properties.ShowToday = false;
            edtDatumBis.Size = new System.Drawing.Size(112, 24);
            edtDatumBis.TabIndex = 57;
            //
            // lblGueltikeit
            //
            lblGueltikeit.Location = new System.Drawing.Point(16, 262);
            lblGueltikeit.Name = "lblGueltikeit";
            lblGueltikeit.Size = new System.Drawing.Size(112, 24);
            lblGueltikeit.TabIndex = 58;
            lblGueltikeit.Text = "Gültigkeit";
            //
            // lblGueltikeitBis
            //
            lblGueltikeitBis.Location = new System.Drawing.Point(280, 262);
            lblGueltikeitBis.Name = "lblGueltikeitBis";
            lblGueltikeitBis.Size = new System.Drawing.Size(24, 24);
            lblGueltikeitBis.TabIndex = 59;
            lblGueltikeitBis.Text = "bis";
            //
            // chkShowAll
            //
            chkShowAll.EditValue = false;
            chkShowAll.Location = new System.Drawing.Point(584, 8);
            chkShowAll.Name = "chkShowAll";
            chkShowAll.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            chkShowAll.Properties.Appearance.Options.UseBackColor = true;
            chkShowAll.Properties.Caption = "Alle anzeigen";
            chkShowAll.Size = new System.Drawing.Size(96, 21);
            chkShowAll.TabIndex = 82;
            chkShowAll.EditValueChanged += new System.EventHandler(chkShowAll_EditValueChanged);
            //
            // CtlAyZahlungsmodus
            //
            ActiveSQLQuery = qryBgZahlungsmodus;
            Controls.Add(chkShowAll);
            Controls.Add(lblGueltikeit);
            Controls.Add(edtDatumBis);
            Controls.Add(edtDatumVon);
            Controls.Add(picTitel);
            Controls.Add(xTabControl1);
            Controls.Add(lblTitel);
            Controls.Add(edtNameZahlungsmodus);
            Controls.Add(lblKbAuszahlungsArtCode);
            Controls.Add(lblNameZahlungsmodus);
            Controls.Add(edtKbAuszahlungsArtCode);
            Controls.Add(grdBgZahlungsmodus);
            Controls.Add(lblGueltikeitBis);
            Name = "CtlAyZahlungsmodus";
            Size = new System.Drawing.Size(680, 520);
            Load += new System.EventHandler(CtlAyZahlungsmodus_Load);
            ((System.ComponentModel.ISupportInitialize)(qryBgZahlungsmodus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(grdBgZahlungsmodus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(grvBgZahlungsmodus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(edtKbAuszahlungsArtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(edtKbAuszahlungsArtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lblNameZahlungsmodus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lblKbAuszahlungsArtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(edtNameZahlungsmodus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lblTitel)).EndInit();
            xTabControl1.ResumeLayout(false);
            tabKreditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(lblReferenzNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(edtReferenzNummer.Properties)).EndInit();
            tabPeriodizitaet.ResumeLayout(false);
            panFill.ResumeLayout(false);
            panCalendar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(lblBerechnungsart_false)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lblBerechnungsart_true)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lblBerechnungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(optBerechnungsart.Properties)).EndInit();
            panMonatlich.ResumeLayout(false);
            panTag2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(lblDesAkteullenMonats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lblUndAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(edtTagImMonat2.Properties)).EndInit();
            panTag1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(chkImVormonat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lblJeweilsAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(edtTagImMonat1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lblDatumRichtwert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(optPeriode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lblGueltikeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lblGueltikeitBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(chkShowAll.Properties)).EndInit();
            ResumeLayout(false);
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
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        private void chkShowAll_EditValueChanged(object sender, EventArgs e)
        {
            if ((bool)chkShowAll.EditValue)
                qryBgZahlungsmodus.DataTable.DefaultView.RowFilter = "";
            else
                qryBgZahlungsmodus.DataTable.DefaultView.RowFilter = "Aktiv = 1 OR BgZahlungsmodusID IS NULL";
        }

        private void CtlAyZahlungsmodus_Load(object sender, EventArgs e)
        {
            chkShowAll_EditValueChanged(sender, EventArgs.Empty);
        }

        private void ctlZahlungsweg_ZahlungswegIDChanged(object sender, EventArgs e)
        {
            if (qryBgZahlungsmodus.Count == 0) return;

            if (!qryBgZahlungsmodus["BaZahlungswegID"].Equals(ctlZahlungsweg.BaZahlungswegID))
            {
                qryBgZahlungsmodus["BaZahlungswegID"] = ctlZahlungsweg.BaZahlungswegID;
                qryBgZahlungsmodus["ReferenzNummer"] = ctlZahlungsweg.ReferenzNummer;

                qryBgZahlungsmodus.RefreshDisplay();
            }
        }

        private void edtCalendar_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
        {
            qryBgZahlungsmodus.RowModified = true;

            try
            {
                if (edtCalendar.BoldedDates.Any(dt => dt.Equals(e.Start)))
                {
                    edtCalendar.RemoveBoldedDate(e.Start);
                    return;
                }
                edtCalendar.AddBoldedDate(e.Start);
            }
            finally
            {
                edtCalendar.BeginInvoke(new MethodInvoker(() => edtCalendar.UpdateBoldedDates()));
            }
        }

        private void edtKbAuszahlungsArtCode_EditValueChanged(object sender, EventArgs e)
        {
            int kbAuszahlungsArtCode = 101;
            bool grdBgZahlungsmodusContainsFocus = grdBgZahlungsmodus.ContainsFocus;

            int? auszahlungsArtCode;
            if (sender == qryBgZahlungsmodus || sender is System.Windows.Forms.CurrencyManager)
            {
                auszahlungsArtCode = qryBgZahlungsmodus[edtKbAuszahlungsArtCode.DataMember] as int?;
            }
            else
            {
                auszahlungsArtCode = edtKbAuszahlungsArtCode.EditValue as int?;
            }
            if (auszahlungsArtCode.HasValue)
            {
                kbAuszahlungsArtCode = auszahlungsArtCode.Value;
            }

            if (kbAuszahlungsArtCode == 103 ||  // bar via Kasse
                kbAuszahlungsArtCode == 104)    // Check
            {
                tabKreditor.Enabled = false;
                xTabControl1.SelectedTabIndex = xTabControl1.TabPages.IndexOf(tabPeriodizitaet);
            }
            else
            {
                tabKreditor.Enabled = true;
                xTabControl1.SelectedTabIndex = xTabControl1.TabPages.IndexOf(tabKreditor);
            }

            if (grdBgZahlungsmodusContainsFocus)
            {
                grdBgZahlungsmodus.Focus();
            }
        }

        private void optPeriode_EditValueChanged(object sender, EventArgs e)
        {
            int periodizitaet = 0;

            int? period;
            if (sender == ActiveSQLQuery || sender is System.Windows.Forms.CurrencyManager)
            {
                period = ActiveSQLQuery[optPeriode.DataMember] as int?;
            }
            else
            {
                period = optPeriode.EditValue as int?;
            }

            if (period.HasValue)
            {
                periodizitaet = period.Value;
            }

            switch (periodizitaet)
            {
                case 1:
                    panMonatlich.Visible = true;
                    panTag2.Visible = false;
                    panCalendar.Visible = false;
                    break;

                case 2:
                    panMonatlich.Visible = true;
                    panTag2.Visible = true;
                    panCalendar.Visible = false;
                    break;

                case 3:
                    panMonatlich.Visible = false;
                    panCalendar.Visible = true;
                    break;
            }
        }

        private void qryBgZahlungsmodus_AfterFill(object sender, EventArgs e)
        {
            chkShowAll_EditValueChanged(sender, EventArgs.Empty);
        }

        private void qryBgZahlungsmodus_AfterInsert(object sender, EventArgs e)
        {
            qryBgZahlungsmodus["FaLeistungID"] = _faLeistungId;
            qryBgZahlungsmodus["Aktiv"] = true;

            // Auzahlungstermin setzen
            int termin = Convert.ToInt32(DBUtil.GetConfigValue(@"System\Asyl\Zahlungsmodus_Termin", -24));
            qryBgZahlungsmodus["Periodizitaet"] = 1;
            qryBgZahlungsmodus["TagImMonat"] = Math.Abs(termin);
            qryBgZahlungsmodus["ImVormonat"] = termin < 0;

            qryBgZahlungsmodus["BetragGleich"] = true;

            edtNameZahlungsmodus.Focus();
        }

        private void qryBgZahlungsmodus_AfterPost(object sender, EventArgs e)
        {
            try
            {
                switch ((int)ActiveSQLQuery[optPeriode.DataMember])
                {
                    case 1:
                        if (qryBgZahlungsmodus["ShZahlungsmodusTerminID_2"] != DBNull.Value)
                        {
                            DBUtil.ExecSQLThrowingException(
                                "DELETE FROM dbo.BgZahlungsmodusTermin WHERE BgZahlungsmodusTerminID = {0}"
                                , qryBgZahlungsmodus["ShZahlungsmodusTerminID_2"]);

                            qryBgZahlungsmodus["ShZahlungsmodusTerminID_2"] = DBNull.Value;
                        }

                        #region Update BgZahlungsmodusTerminID

                        if (qryBgZahlungsmodus["BgZahlungsmodusTerminID"] == DBNull.Value)
                            qryBgZahlungsmodus["BgZahlungsmodusTerminID"] = DBUtil.ExecuteScalarSQL(@"
                                INSERT INTO dbo.BgZahlungsmodusTermin(BgZahlungsmodusID, TagImMonat, ImVormonat, nMonatlich) VALUES ({0}, {1}, IsNull({2}, 0), 1)
                                SELECT @@IDENTITY "
                                , qryBgZahlungsmodus["BgZahlungsmodusID"]
                                , qryBgZahlungsmodus["TagImMonat"]
                                , qryBgZahlungsmodus["ImVormonat"]);
                        else
                            DBUtil.ExecSQLThrowingException(
                                "UPDATE dbo.BgZahlungsmodusTermin SET TagImMonat = {1}, ImVormonat = IsNull({2}, 0), nMonatlich = 1 WHERE BgZahlungsmodusTerminID = {0}"
                                , qryBgZahlungsmodus["BgZahlungsmodusTerminID"]
                                , qryBgZahlungsmodus["TagImMonat"]
                                , qryBgZahlungsmodus["ImVormonat"]);

                        #endregion

                        DBUtil.ExecSQLThrowingException(@"
                            DELETE FROM dbo.BgZahlungsmodusTermin
                            WHERE BgZahlungsmodusID = {0} AND Datum IS NOT NULL"
                            , qryBgZahlungsmodus["BgZahlungsmodusID"]);
                        break;

                    case 2:

                        #region Update BgZahlungsmodusTerminID

                        if (qryBgZahlungsmodus["BgZahlungsmodusTerminID"] == DBNull.Value)
                            qryBgZahlungsmodus["BgZahlungsmodusTerminID"] = DBUtil.ExecuteScalarSQL(@"
                                INSERT INTO dbo.BgZahlungsmodusTermin(BgZahlungsmodusID, TagImMonat, ImVormonat, nMonatlich) VALUES ({0}, {1}, IsNull({2}, 0), 2)
                                SELECT @@IDENTITY "
                                , qryBgZahlungsmodus["BgZahlungsmodusID"]
                                , qryBgZahlungsmodus["TagImMonat"]
                                , qryBgZahlungsmodus["ImVormonat"]);
                        else
                            DBUtil.ExecSQLThrowingException(
                                "UPDATE dbo.BgZahlungsmodusTermin SET TagImMonat = {1}, ImVormonat = IsNull({2}, 0), nMonatlich = 2 WHERE BgZahlungsmodusTerminID = {0}"
                                , qryBgZahlungsmodus["BgZahlungsmodusTerminID"]
                                , qryBgZahlungsmodus["TagImMonat"]
                                , qryBgZahlungsmodus["ImVormonat"]);

                        #endregion

                        #region Update BgZahlungsmodusTerminID 2

                        if (qryBgZahlungsmodus["ShZahlungsmodusTerminID_2"] == DBNull.Value)
                            qryBgZahlungsmodus["ShZahlungsmodusTerminID_2"] = DBUtil.ExecuteScalarSQL(@"
                                INSERT INTO dbo.BgZahlungsmodusTermin(BgZahlungsmodusID, TagImMonat, ImVormonat, nMonatlich) VALUES ({0}, {1}, 0, 2)
                                SELECT @@IDENTITY "
                                , qryBgZahlungsmodus["BgZahlungsmodusID"]
                                , qryBgZahlungsmodus["TagImMonat_2"]);
                        else
                            DBUtil.ExecSQLThrowingException(
                                "UPDATE dbo.BgZahlungsmodusTermin SET TagImMonat = {1}, ImVormonat = 0, nMonatlich = 2 WHERE BgZahlungsmodusTerminID = {0}"
                                , qryBgZahlungsmodus["ShZahlungsmodusTerminID_2"]
                                , qryBgZahlungsmodus["TagImMonat_2"]);

                        #endregion

                        DBUtil.ExecSQLThrowingException(@"
                            DELETE FROM dbo.BgZahlungsmodusTermin
                            WHERE BgZahlungsmodusID = {0} AND Datum IS NOT NULL"
                            , qryBgZahlungsmodus["BgZahlungsmodusID"]);
                        break;

                    case 3:
                        DBUtil.ExecSQLThrowingException(
                            "DELETE FROM dbo.BgZahlungsmodusTermin WHERE BgZahlungsmodusID = {0} AND Datum IS NULL"
                            , qryBgZahlungsmodus["BgZahlungsmodusID"]);

                        qryBgZahlungsmodus["BgZahlungsmodusTerminID"] = DBNull.Value;
                        qryBgZahlungsmodus["ShZahlungsmodusTerminID_2"] = DBNull.Value;

                        var alDates = new ArrayList();

                        foreach (DateTime dt in edtCalendar.BoldedDates)
                        {
                            DBUtil.ExecSQLThrowingException(@"
                                IF NOT EXISTS (SELECT * FROM dbo.BgZahlungsmodusTermin WHERE BgZahlungsmodusID = {0} AND Datum = {1}) BEGIN
                                  INSERT INTO dbo.BgZahlungsmodusTermin(BgZahlungsmodusID, Datum) VALUES ({0}, {1})
                                END"
                                , qryBgZahlungsmodus["BgZahlungsmodusID"]
                                , dt);

                            alDates.Add(DBUtil.SqlLiteral(dt, true));
                        }

                        DBUtil.ExecSQLThrowingException(
                            string.Format(@"
                                DELETE FROM dbo.BgZahlungsmodusTermin
                                WHERE BgZahlungsmodusID = {0}
                                  AND Datum NOT IN ({1})",
                                "{0}",
                                string.Join(", ", (string[])alDates.ToArray(typeof(string)))),
                            qryBgZahlungsmodus["BgZahlungsmodusID"]);

                        DBUtil.ExecSQLThrowingException(
                            "UPDATE dbo.BgZahlungsmodusTermin SET BetragGleich = {1} WHERE BgZahlungsmodusID = {0}"
                            , qryBgZahlungsmodus["BgZahlungsmodusID"]
                            , qryBgZahlungsmodus["BetragGleich"]);
                        break;
                }

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void qryBgZahlungsmodus_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtNameZahlungsmodus, lblNameZahlungsmodus.Text);

            DBUtil.CheckNotNullField(edtKbAuszahlungsArtCode, lblKbAuszahlungsArtCode.Text);
            if ((int)qryBgZahlungsmodus["KbAuszahlungsArtCode"] == 101)  // Kreditor, direkt zur Buchhaltung
            {
                DBUtil.CheckNotNullField(ctlZahlungsweg, tabKreditor.Title);
            }
            DBUtil.CheckNotNullField(optPeriode, tabPeriodizitaet.Title);
            switch ((int)ActiveSQLQuery[optPeriode.DataMember])
            {
                case 1:
                    DBUtil.CheckNotNullField(edtTagImMonat1, KissMsg.GetMLMessage("CtlAyZahlungsmodus", "Monatstag1", "Monatstag 1"));
                    if ((int)qryBgZahlungsmodus["TagImMonat"] < 1 || (int)qryBgZahlungsmodus["TagImMonat"] > 31)
                        throw new KissInfoException(KissMsg.GetMLMessage("CtlAyZahlungsmodus", "WertNichtZulaessig1", "Das Feld '{0}' enthält einen nicht zulässigen Wert !", KissMsgCode.MsgInfo, "Monatstag 1"), edtTagImMonat1);
                    break;

                case 2:
                    DBUtil.CheckNotNullField(edtTagImMonat2, KissMsg.GetMLMessage("CtlAyZahlungsmodus", "Monatstag2", "Monatstag 2"));
                    if ((int)qryBgZahlungsmodus["TagImMonat_2"] < 1 || (int)qryBgZahlungsmodus["TagImMonat_2"] > 31)
                        throw new KissInfoException(KissMsg.GetMLMessage("CtlAyZahlungsmodus", "WertNichtZulaessig2", "Das Feld '{0}' enthält einen nicht zulässigen Wert !", KissMsgCode.MsgInfo, "Monatstag 2"), edtTagImMonat2);
                    goto case 1;

                case 3:
                    if (edtCalendar.BoldedDates.Length == 0)
                        throw new KissInfoException(KissMsg.GetMLMessage("CtlAyZahlungsmodus", "Min1Auszahlungstermin", "Es muss mindestens ein Auszahlungstermin markiert sein!", KissMsgCode.MsgInfo), edtCalendar);
                    break;
            }

            if (!(bool)qryBgZahlungsmodus["KontoKlient"] &&
                (int)qryBgZahlungsmodus["KbAuszahlungsArtCode"] == 103 ||  // bar via Kasse
                (int)qryBgZahlungsmodus["KbAuszahlungsArtCode"] == 104)    // Check
                qryBgZahlungsmodus["BaZahlungswegID"] = DBNull.Value;

            if (DBUtil.IsEmpty(qryBgZahlungsmodus["BaZahlungswegID"]))
                qryBgZahlungsmodus["ReferenzNummer"] = DBNull.Value;

            if (!DBUtil.IsEmpty(qryBgZahlungsmodus["ReferenzNummer"]) &&
                !edtReferenzNummer.ValidateReferenzNummer(ctlZahlungsweg.EsrTeilnehmer))
            {
                edtReferenzNummer.Focus();
                throw new KissCancelException();
            }

            Session.BeginTransaction();

            try
            {
                // Update ESR in BgAuszahlungPerson
                if (!DBUtil.IsEmpty(qryBgZahlungsmodus["BgZahlungsmodusID"]) && (
                    qryBgZahlungsmodus.ColumnModified("KbAuszahlungsArtCode")
                    || qryBgZahlungsmodus.ColumnModified("BaZahlungswegID")
                    || qryBgZahlungsmodus.ColumnModified("ReferenzNummer")))
                {
                    DBUtil.ExecSQLThrowingException(@"
                        UPDATE STZ
                          SET KbAuszahlungsArtCode = {2},
                            BaZahlungswegID = {3},
                            ReferenzNummer = {4}
                        FROM dbo.BgFinanzplan                SFP
                          INNER JOIN dbo.BgBudget            BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
                          INNER JOIN dbo.BgPosition          BPO ON BPO.BgBudgetID = BBG.BgBudgetID
                          INNER JOIN dbo.BgAuszahlungPerson  STZ ON STZ.BgPositionID = BPO.BgPositionID
                          INNER JOIN dbo.BgZahlungsmodus     SZM ON SZM.BgZahlungsmodusID = STZ.BgZahlungsmodusID AND SZM.KbAuszahlungsArtCode = STZ.KbAuszahlungsArtCode
                        WHERE SFP.FaLeistungID = {0} AND (BBG.MasterBudget = 1 OR BBG.BgBewilligungStatusCode < 5) AND STZ.BgZahlungsmodusID = {1}
                          AND IsNull(STZ.BaZahlungswegID, -1) = IsNull(SZM.BaZahlungswegID, -1) AND IsNull(STZ.ReferenzNummer, '') = IsNull(SZM.ReferenzNummer, '')"
                        , qryBgZahlungsmodus["FaLeistungID"], qryBgZahlungsmodus["BgZahlungsmodusID"]
                        , qryBgZahlungsmodus["KbAuszahlungsArtCode"], qryBgZahlungsmodus["BaZahlungswegID"], qryBgZahlungsmodus["ReferenzNummer"]);
                }
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                throw new KissCancelException();
            }
        }

        private void qryBgZahlungsmodus_PositionChanged(object sender, EventArgs e)
        {
            optPeriode_EditValueChanged(sender, EventArgs.Empty);
            edtKbAuszahlungsArtCode_EditValueChanged(sender, EventArgs.Empty);

            // Read Zahlungstermine from Database
            edtCalendar.MinDate = DBUtil.IsEmpty(qryBgZahlungsmodus["DatumVon"]) ? DateTime.MinValue : Convert.ToDateTime(qryBgZahlungsmodus["DatumVon"]);

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT Datum
                FROM dbo.BgZahlungsmodusTermin
                WHERE BgZahlungsmodusID = {0} AND Datum IS NOT NULL"
                , qryBgZahlungsmodus["BgZahlungsmodusID"]);

            edtCalendar.BoldedDates = null;
            foreach (DataRow row in qry.DataTable.Rows)
            {
                edtCalendar.AddBoldedDate((DateTime)row[0]);
            }
            edtCalendar.UpdateBoldedDates();
            qryBgZahlungsmodus.RefreshDisplay();
        }

        #endregion
    }
}