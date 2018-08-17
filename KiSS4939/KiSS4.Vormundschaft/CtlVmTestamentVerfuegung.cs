using System.Drawing;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for CtlVmTestamentVerfuegung.
    /// </summary>
    public class CtlVmTestamentVerfuegung : KissUserControl
    {
        private DevExpress.XtraGrid.Columns.GridColumn colEroeffnungsDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colVerfuegungsDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colVerfuegungText;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtABOnachherCode;
        private KiSS4.Gui.KissTextEdit edtABOnachherText;
        private KiSS4.Gui.KissLookUpEdit edtABOvorherCode;
        private KiSS4.Gui.KissTextEdit edtABOvorherText;
        private KiSS4.Gui.KissCalcEdit edtAnzSeiten;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtEingangsDatum;
        private KiSS4.Gui.KissDateEdit edtEroeffnungsDatum;
        private KiSS4.Gui.KissLookUpEdit edtTestamentsformCode;
        private KiSS4.Gui.KissDateEdit edtVerfuegungsDatum;
        private KiSS4.Gui.KissTextEdit edtVerfuegungText;
        private KiSS4.Gui.KissCheckEdit edtVerschlossen;
        private KiSS4.Gui.KissGrid grdVmTestamentVerfuegung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVmTestamentVerfuegung;
        private KiSS4.Gui.KissLabel lblABOnachherCode;
        private KiSS4.Gui.KissLabel lblABOvorherCode;
        private KiSS4.Gui.KissLabel lblAnzSeiten;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblEingangsDatum;
        private KiSS4.Gui.KissLabel lblEroeffnungsDatum;
        private KiSS4.Gui.KissLabel lblTestamentsformCode;
        private System.Windows.Forms.Label lblTitel;
        private KiSS4.Gui.KissLabel lblVerfuegungsDatum;
        private KiSS4.Gui.KissLabel lblVerfuegungText;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryVmTestamentVerfuegung;
        private int VmTestamentID = 0;

        public CtlVmTestamentVerfuegung()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        public void Init(string TitleName, Image TitleImage, int VmTestamentID)
        {
            this.lblTitel.Text = TitleName;
            this.picTitel.Image = TitleImage;
            this.VmTestamentID = VmTestamentID;

            qryVmTestamentVerfuegung.Fill(@"
				select *
				from   VmTestamentVerfuegung
				where  VmTestamentID = {0}
				order by EingangsDatum",
                VmTestamentID);
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmTestamentVerfuegung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryVmTestamentVerfuegung = new KiSS4.DB.SqlQuery(this.components);
            this.lblTitel = new System.Windows.Forms.Label();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.grdVmTestamentVerfuegung = new KiSS4.Gui.KissGrid();
            this.grvVmTestamentVerfuegung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVerfuegungsDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEroeffnungsDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerfuegungText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblVerfuegungText = new KiSS4.Gui.KissLabel();
            this.lblEingangsDatum = new KiSS4.Gui.KissLabel();
            this.edtEingangsDatum = new KiSS4.Gui.KissDateEdit();
            this.edtVerfuegungText = new KiSS4.Gui.KissTextEdit();
            this.edtVerfuegungsDatum = new KiSS4.Gui.KissDateEdit();
            this.lblVerfuegungsDatum = new KiSS4.Gui.KissLabel();
            this.edtEroeffnungsDatum = new KiSS4.Gui.KissDateEdit();
            this.lblEroeffnungsDatum = new KiSS4.Gui.KissLabel();
            this.edtVerschlossen = new KiSS4.Gui.KissCheckEdit();
            this.edtTestamentsformCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblTestamentsformCode = new KiSS4.Gui.KissLabel();
            this.lblAnzSeiten = new KiSS4.Gui.KissLabel();
            this.lblABOvorherCode = new KiSS4.Gui.KissLabel();
            this.edtABOvorherCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtAnzSeiten = new KiSS4.Gui.KissCalcEdit();
            this.edtABOnachherCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblABOnachherCode = new KiSS4.Gui.KissLabel();
            this.edtABOvorherText = new KiSS4.Gui.KissTextEdit();
            this.edtABOnachherText = new KiSS4.Gui.KissTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmTestamentVerfuegung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmTestamentVerfuegung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmTestamentVerfuegung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerfuegungText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEingangsDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEingangsDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerfuegungText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerfuegungsDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerfuegungsDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungsDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerschlossen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTestamentsformCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTestamentsformCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTestamentsformCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzSeiten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblABOvorherCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtABOvorherCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtABOvorherCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzSeiten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtABOnachherCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtABOnachherCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblABOnachherCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtABOvorherText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtABOnachherText.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // qryVmTestamentVerfuegung
            //
            this.qryVmTestamentVerfuegung.CanDelete = true;
            this.qryVmTestamentVerfuegung.CanInsert = true;
            this.qryVmTestamentVerfuegung.CanUpdate = true;
            this.qryVmTestamentVerfuegung.HostControl = this;
            this.qryVmTestamentVerfuegung.TableName = "VmTestamentVerfuegung";
            this.qryVmTestamentVerfuegung.BeforePost += new System.EventHandler(this.qryVmTestamentVerfuegung_BeforePost);
            this.qryVmTestamentVerfuegung.AfterInsert += new System.EventHandler(this.qryVmTestamentVerfuegung_AfterInsert);
            //
            // lblTitel
            //
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 13;
            this.lblTitel.Text = "Titel";
            //
            // picTitel
            //
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(10, 9);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(25, 20);
            this.picTitel.TabIndex = 12;
            this.picTitel.TabStop = false;
            //
            // grdVmTestamentVerfuegung
            //
            this.grdVmTestamentVerfuegung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdVmTestamentVerfuegung.DataSource = this.qryVmTestamentVerfuegung;
            this.grdVmTestamentVerfuegung.EmbeddedNavigator.Name = "";
            this.grdVmTestamentVerfuegung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVmTestamentVerfuegung.Location = new System.Drawing.Point(5, 38);
            this.grdVmTestamentVerfuegung.MainView = this.grvVmTestamentVerfuegung;
            this.grdVmTestamentVerfuegung.Name = "grdVmTestamentVerfuegung";
            this.grdVmTestamentVerfuegung.Size = new System.Drawing.Size(688, 163);
            this.grdVmTestamentVerfuegung.TabIndex = 0;
            this.grdVmTestamentVerfuegung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVmTestamentVerfuegung});
            //
            // grvVmTestamentVerfuegung
            //
            this.grvVmTestamentVerfuegung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVmTestamentVerfuegung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmTestamentVerfuegung.Appearance.Empty.Options.UseBackColor = true;
            this.grvVmTestamentVerfuegung.Appearance.Empty.Options.UseFont = true;
            this.grvVmTestamentVerfuegung.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvVmTestamentVerfuegung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmTestamentVerfuegung.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvVmTestamentVerfuegung.Appearance.EvenRow.Options.UseFont = true;
            this.grvVmTestamentVerfuegung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmTestamentVerfuegung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmTestamentVerfuegung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVmTestamentVerfuegung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVmTestamentVerfuegung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVmTestamentVerfuegung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVmTestamentVerfuegung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmTestamentVerfuegung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmTestamentVerfuegung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVmTestamentVerfuegung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVmTestamentVerfuegung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVmTestamentVerfuegung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVmTestamentVerfuegung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmTestamentVerfuegung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVmTestamentVerfuegung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmTestamentVerfuegung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmTestamentVerfuegung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmTestamentVerfuegung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVmTestamentVerfuegung.Appearance.GroupRow.Options.UseFont = true;
            this.grvVmTestamentVerfuegung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVmTestamentVerfuegung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVmTestamentVerfuegung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVmTestamentVerfuegung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmTestamentVerfuegung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVmTestamentVerfuegung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVmTestamentVerfuegung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVmTestamentVerfuegung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVmTestamentVerfuegung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmTestamentVerfuegung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmTestamentVerfuegung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVmTestamentVerfuegung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVmTestamentVerfuegung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVmTestamentVerfuegung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmTestamentVerfuegung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVmTestamentVerfuegung.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvVmTestamentVerfuegung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmTestamentVerfuegung.Appearance.OddRow.Options.UseBackColor = true;
            this.grvVmTestamentVerfuegung.Appearance.OddRow.Options.UseFont = true;
            this.grvVmTestamentVerfuegung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVmTestamentVerfuegung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmTestamentVerfuegung.Appearance.Row.Options.UseBackColor = true;
            this.grvVmTestamentVerfuegung.Appearance.Row.Options.UseFont = true;
            this.grvVmTestamentVerfuegung.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvVmTestamentVerfuegung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmTestamentVerfuegung.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvVmTestamentVerfuegung.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvVmTestamentVerfuegung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVmTestamentVerfuegung.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvVmTestamentVerfuegung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmTestamentVerfuegung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVmTestamentVerfuegung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVmTestamentVerfuegung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVerfuegungsDatum,
            this.colEroeffnungsDatum,
            this.colVerfuegungText});
            this.grvVmTestamentVerfuegung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVmTestamentVerfuegung.GridControl = this.grdVmTestamentVerfuegung;
            this.grvVmTestamentVerfuegung.Name = "grvVmTestamentVerfuegung";
            this.grvVmTestamentVerfuegung.OptionsBehavior.Editable = false;
            this.grvVmTestamentVerfuegung.OptionsCustomization.AllowFilter = false;
            this.grvVmTestamentVerfuegung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVmTestamentVerfuegung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVmTestamentVerfuegung.OptionsNavigation.UseTabKey = false;
            this.grvVmTestamentVerfuegung.OptionsView.ColumnAutoWidth = false;
            this.grvVmTestamentVerfuegung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVmTestamentVerfuegung.OptionsView.ShowGroupPanel = false;
            this.grvVmTestamentVerfuegung.OptionsView.ShowIndicator = false;
            //
            // colVerfuegungsDatum
            //
            this.colVerfuegungsDatum.Caption = "Verfügung";
            this.colVerfuegungsDatum.FieldName = "VerfuegungsDatum";
            this.colVerfuegungsDatum.Name = "colVerfuegungsDatum";
            this.colVerfuegungsDatum.Visible = true;
            this.colVerfuegungsDatum.VisibleIndex = 0;
            this.colVerfuegungsDatum.Width = 72;
            //
            // colEroeffnungsDatum
            //
            this.colEroeffnungsDatum.Caption = "Eröffnung";
            this.colEroeffnungsDatum.FieldName = "EroeffnungsDatum";
            this.colEroeffnungsDatum.Name = "colEroeffnungsDatum";
            this.colEroeffnungsDatum.Visible = true;
            this.colEroeffnungsDatum.VisibleIndex = 1;
            //
            // colVerfuegungText
            //
            this.colVerfuegungText.Caption = "Text";
            this.colVerfuegungText.FieldName = "VerfuegungText";
            this.colVerfuegungText.Name = "colVerfuegungText";
            this.colVerfuegungText.OptionsColumn.AllowEdit = false;
            this.colVerfuegungText.OptionsColumn.ReadOnly = true;
            this.colVerfuegungText.Visible = true;
            this.colVerfuegungText.VisibleIndex = 2;
            this.colVerfuegungText.Width = 520;
            //
            // edtBemerkung
            //
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryVmTestamentVerfuegung;
            this.edtBemerkung.Location = new System.Drawing.Point(90, 412);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(604, 90);
            this.edtBemerkung.TabIndex = 14;
            //
            // lblBemerkung
            //
            this.lblBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung.Location = new System.Drawing.Point(5, 412);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(60, 24);
            this.lblBemerkung.TabIndex = 148;
            this.lblBemerkung.Text = "Bemerkung";
            //
            // lblVerfuegungText
            //
            this.lblVerfuegungText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVerfuegungText.Location = new System.Drawing.Point(5, 382);
            this.lblVerfuegungText.Name = "lblVerfuegungText";
            this.lblVerfuegungText.Size = new System.Drawing.Size(60, 24);
            this.lblVerfuegungText.TabIndex = 149;
            this.lblVerfuegungText.Text = "Text";
            //
            // lblEingangsDatum
            //
            this.lblEingangsDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEingangsDatum.Location = new System.Drawing.Point(5, 212);
            this.lblEingangsDatum.Name = "lblEingangsDatum";
            this.lblEingangsDatum.Size = new System.Drawing.Size(60, 24);
            this.lblEingangsDatum.TabIndex = 150;
            this.lblEingangsDatum.Text = "Eingang";
            //
            // edtEingangsDatum
            //
            this.edtEingangsDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEingangsDatum.DataMember = "EingangsDatum";
            this.edtEingangsDatum.DataSource = this.qryVmTestamentVerfuegung;
            this.edtEingangsDatum.EditValue = null;
            this.edtEingangsDatum.Location = new System.Drawing.Point(90, 212);
            this.edtEingangsDatum.Name = "edtEingangsDatum";
            this.edtEingangsDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEingangsDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEingangsDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEingangsDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEingangsDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtEingangsDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEingangsDatum.Properties.Appearance.Options.UseFont = true;
            this.edtEingangsDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtEingangsDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEingangsDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtEingangsDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEingangsDatum.Properties.ShowToday = false;
            this.edtEingangsDatum.Size = new System.Drawing.Size(90, 24);
            this.edtEingangsDatum.TabIndex = 1;
            //
            // edtVerfuegungText
            //
            this.edtVerfuegungText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVerfuegungText.DataMember = "VerfuegungText";
            this.edtVerfuegungText.DataSource = this.qryVmTestamentVerfuegung;
            this.edtVerfuegungText.Location = new System.Drawing.Point(90, 382);
            this.edtVerfuegungText.Name = "edtVerfuegungText";
            this.edtVerfuegungText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerfuegungText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerfuegungText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerfuegungText.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerfuegungText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerfuegungText.Properties.Appearance.Options.UseFont = true;
            this.edtVerfuegungText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVerfuegungText.Size = new System.Drawing.Size(604, 24);
            this.edtVerfuegungText.TabIndex = 13;
            //
            // edtVerfuegungsDatum
            //
            this.edtVerfuegungsDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVerfuegungsDatum.DataMember = "VerfuegungsDatum";
            this.edtVerfuegungsDatum.DataSource = this.qryVmTestamentVerfuegung;
            this.edtVerfuegungsDatum.EditValue = null;
            this.edtVerfuegungsDatum.Location = new System.Drawing.Point(90, 242);
            this.edtVerfuegungsDatum.Name = "edtVerfuegungsDatum";
            this.edtVerfuegungsDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerfuegungsDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerfuegungsDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerfuegungsDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerfuegungsDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerfuegungsDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerfuegungsDatum.Properties.Appearance.Options.UseFont = true;
            this.edtVerfuegungsDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtVerfuegungsDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerfuegungsDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtVerfuegungsDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerfuegungsDatum.Properties.ShowToday = false;
            this.edtVerfuegungsDatum.Size = new System.Drawing.Size(90, 24);
            this.edtVerfuegungsDatum.TabIndex = 2;
            //
            // lblVerfuegungsDatum
            //
            this.lblVerfuegungsDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVerfuegungsDatum.Location = new System.Drawing.Point(5, 242);
            this.lblVerfuegungsDatum.Name = "lblVerfuegungsDatum";
            this.lblVerfuegungsDatum.Size = new System.Drawing.Size(60, 24);
            this.lblVerfuegungsDatum.TabIndex = 152;
            this.lblVerfuegungsDatum.Text = "Verfügung";
            //
            // edtEroeffnungsDatum
            //
            this.edtEroeffnungsDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEroeffnungsDatum.DataMember = "EroeffnungsDatum";
            this.edtEroeffnungsDatum.DataSource = this.qryVmTestamentVerfuegung;
            this.edtEroeffnungsDatum.EditValue = null;
            this.edtEroeffnungsDatum.Location = new System.Drawing.Point(90, 272);
            this.edtEroeffnungsDatum.Name = "edtEroeffnungsDatum";
            this.edtEroeffnungsDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEroeffnungsDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungsDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungsDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungsDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungsDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungsDatum.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungsDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtEroeffnungsDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnungsDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtEroeffnungsDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungsDatum.Properties.ShowToday = false;
            this.edtEroeffnungsDatum.Size = new System.Drawing.Size(90, 24);
            this.edtEroeffnungsDatum.TabIndex = 3;
            //
            // lblEroeffnungsDatum
            //
            this.lblEroeffnungsDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEroeffnungsDatum.Location = new System.Drawing.Point(5, 272);
            this.lblEroeffnungsDatum.Name = "lblEroeffnungsDatum";
            this.lblEroeffnungsDatum.Size = new System.Drawing.Size(60, 24);
            this.lblEroeffnungsDatum.TabIndex = 154;
            this.lblEroeffnungsDatum.Text = "Eröffnung";
            //
            // edtVerschlossen
            //
            this.edtVerschlossen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVerschlossen.DataMember = "Verschlossen";
            this.edtVerschlossen.DataSource = this.qryVmTestamentVerfuegung;
            this.edtVerschlossen.Location = new System.Drawing.Point(306, 337);
            this.edtVerschlossen.Name = "edtVerschlossen";
            this.edtVerschlossen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtVerschlossen.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerschlossen.Properties.Caption = "verschlossen";
            this.edtVerschlossen.Size = new System.Drawing.Size(96, 19);
            this.edtVerschlossen.TabIndex = 12;
            //
            // edtTestamentsformCode
            //
            this.edtTestamentsformCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTestamentsformCode.DataMember = "TestamentsformCode";
            this.edtTestamentsformCode.DataSource = this.qryVmTestamentVerfuegung;
            this.edtTestamentsformCode.Location = new System.Drawing.Point(306, 242);
            this.edtTestamentsformCode.LOVName = "VmTestamentsform";
            this.edtTestamentsformCode.Name = "edtTestamentsformCode";
            this.edtTestamentsformCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTestamentsformCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTestamentsformCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTestamentsformCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtTestamentsformCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTestamentsformCode.Properties.Appearance.Options.UseFont = true;
            this.edtTestamentsformCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTestamentsformCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTestamentsformCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTestamentsformCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTestamentsformCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtTestamentsformCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtTestamentsformCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTestamentsformCode.Properties.NullText = "";
            this.edtTestamentsformCode.Properties.ShowFooter = false;
            this.edtTestamentsformCode.Properties.ShowHeader = false;
            this.edtTestamentsformCode.Size = new System.Drawing.Size(198, 24);
            this.edtTestamentsformCode.TabIndex = 7;
            //
            // lblTestamentsformCode
            //
            this.lblTestamentsformCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTestamentsformCode.Location = new System.Drawing.Point(201, 242);
            this.lblTestamentsformCode.Name = "lblTestamentsformCode";
            this.lblTestamentsformCode.Size = new System.Drawing.Size(85, 24);
            this.lblTestamentsformCode.TabIndex = 157;
            this.lblTestamentsformCode.Text = "Testamentsform";
            //
            // lblAnzSeiten
            //
            this.lblAnzSeiten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnzSeiten.Location = new System.Drawing.Point(201, 212);
            this.lblAnzSeiten.Name = "lblAnzSeiten";
            this.lblAnzSeiten.Size = new System.Drawing.Size(85, 24);
            this.lblAnzSeiten.TabIndex = 158;
            this.lblAnzSeiten.Text = "Anz. Seiten";
            //
            // lblABOvorherCode
            //
            this.lblABOvorherCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblABOvorherCode.Location = new System.Drawing.Point(201, 272);
            this.lblABOvorherCode.Name = "lblABOvorherCode";
            this.lblABOvorherCode.Size = new System.Drawing.Size(102, 24);
            this.lblABOvorherCode.TabIndex = 159;
            this.lblABOvorherCode.Text = "ABO vorher";
            //
            // edtABOvorherCode
            //
            this.edtABOvorherCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtABOvorherCode.DataMember = "ABOvorherCode";
            this.edtABOvorherCode.DataSource = this.qryVmTestamentVerfuegung;
            this.edtABOvorherCode.Location = new System.Drawing.Point(306, 272);
            this.edtABOvorherCode.LOVName = "VmAufbeahrungsort";
            this.edtABOvorherCode.Name = "edtABOvorherCode";
            this.edtABOvorherCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtABOvorherCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtABOvorherCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtABOvorherCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtABOvorherCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtABOvorherCode.Properties.Appearance.Options.UseFont = true;
            this.edtABOvorherCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtABOvorherCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtABOvorherCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtABOvorherCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtABOvorherCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtABOvorherCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtABOvorherCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtABOvorherCode.Properties.NullText = "";
            this.edtABOvorherCode.Properties.ShowFooter = false;
            this.edtABOvorherCode.Properties.ShowHeader = false;
            this.edtABOvorherCode.Size = new System.Drawing.Size(198, 24);
            this.edtABOvorherCode.TabIndex = 8;
            //
            // edtAnzSeiten
            //
            this.edtAnzSeiten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAnzSeiten.DataMember = "AnzSeiten";
            this.edtAnzSeiten.DataSource = this.qryVmTestamentVerfuegung;
            this.edtAnzSeiten.Location = new System.Drawing.Point(306, 212);
            this.edtAnzSeiten.Name = "edtAnzSeiten";
            this.edtAnzSeiten.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnzSeiten.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnzSeiten.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnzSeiten.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnzSeiten.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnzSeiten.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnzSeiten.Properties.Appearance.Options.UseFont = true;
            this.edtAnzSeiten.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnzSeiten.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnzSeiten.Size = new System.Drawing.Size(41, 24);
            this.edtAnzSeiten.TabIndex = 6;
            //
            // edtABOnachherCode
            //
            this.edtABOnachherCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtABOnachherCode.DataMember = "ABOnachherCode";
            this.edtABOnachherCode.DataSource = this.qryVmTestamentVerfuegung;
            this.edtABOnachherCode.Location = new System.Drawing.Point(306, 302);
            this.edtABOnachherCode.LOVName = "VmAufbeahrungsort";
            this.edtABOnachherCode.Name = "edtABOnachherCode";
            this.edtABOnachherCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtABOnachherCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtABOnachherCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtABOnachherCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtABOnachherCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtABOnachherCode.Properties.Appearance.Options.UseFont = true;
            this.edtABOnachherCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtABOnachherCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtABOnachherCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtABOnachherCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtABOnachherCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtABOnachherCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtABOnachherCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtABOnachherCode.Properties.NullText = "";
            this.edtABOnachherCode.Properties.ShowFooter = false;
            this.edtABOnachherCode.Properties.ShowHeader = false;
            this.edtABOnachherCode.Size = new System.Drawing.Size(198, 24);
            this.edtABOnachherCode.TabIndex = 10;
            //
            // lblABOnachherCode
            //
            this.lblABOnachherCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblABOnachherCode.Location = new System.Drawing.Point(201, 302);
            this.lblABOnachherCode.Name = "lblABOnachherCode";
            this.lblABOnachherCode.Size = new System.Drawing.Size(102, 24);
            this.lblABOnachherCode.TabIndex = 161;
            this.lblABOnachherCode.Text = "ABO nachher";
            //
            // edtABOvorherText
            //
            this.edtABOvorherText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtABOvorherText.DataMember = "ABOvorherText";
            this.edtABOvorherText.DataSource = this.qryVmTestamentVerfuegung;
            this.edtABOvorherText.Location = new System.Drawing.Point(514, 272);
            this.edtABOvorherText.Name = "edtABOvorherText";
            this.edtABOvorherText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtABOvorherText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtABOvorherText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtABOvorherText.Properties.Appearance.Options.UseBackColor = true;
            this.edtABOvorherText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtABOvorherText.Properties.Appearance.Options.UseFont = true;
            this.edtABOvorherText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtABOvorherText.Size = new System.Drawing.Size(180, 24);
            this.edtABOvorherText.TabIndex = 9;
            //
            // edtABOnachherText
            //
            this.edtABOnachherText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtABOnachherText.DataMember = "ABOnachherText";
            this.edtABOnachherText.DataSource = this.qryVmTestamentVerfuegung;
            this.edtABOnachherText.Location = new System.Drawing.Point(514, 302);
            this.edtABOnachherText.Name = "edtABOnachherText";
            this.edtABOnachherText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtABOnachherText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtABOnachherText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtABOnachherText.Properties.Appearance.Options.UseBackColor = true;
            this.edtABOnachherText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtABOnachherText.Properties.Appearance.Options.UseFont = true;
            this.edtABOnachherText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtABOnachherText.Size = new System.Drawing.Size(180, 24);
            this.edtABOnachherText.TabIndex = 11;
            //
            // CtlVmTestamentVerfuegung
            //
            this.ActiveSQLQuery = this.qryVmTestamentVerfuegung;

            this.Controls.Add(this.edtABOnachherText);
            this.Controls.Add(this.edtABOvorherText);
            this.Controls.Add(this.edtABOnachherCode);
            this.Controls.Add(this.lblABOnachherCode);
            this.Controls.Add(this.edtAnzSeiten);
            this.Controls.Add(this.edtABOvorherCode);
            this.Controls.Add(this.lblABOvorherCode);
            this.Controls.Add(this.lblAnzSeiten);
            this.Controls.Add(this.lblTestamentsformCode);
            this.Controls.Add(this.edtTestamentsformCode);
            this.Controls.Add(this.edtVerschlossen);
            this.Controls.Add(this.edtEroeffnungsDatum);
            this.Controls.Add(this.lblEroeffnungsDatum);
            this.Controls.Add(this.edtVerfuegungsDatum);
            this.Controls.Add(this.lblVerfuegungsDatum);
            this.Controls.Add(this.edtVerfuegungText);
            this.Controls.Add(this.edtEingangsDatum);
            this.Controls.Add(this.lblEingangsDatum);
            this.Controls.Add(this.lblVerfuegungText);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.grdVmTestamentVerfuegung);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlVmTestamentVerfuegung";
            this.Size = new System.Drawing.Size(708, 512);
            ((System.ComponentModel.ISupportInitialize)(this.qryVmTestamentVerfuegung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmTestamentVerfuegung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmTestamentVerfuegung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerfuegungText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEingangsDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEingangsDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerfuegungText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerfuegungsDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerfuegungsDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungsDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerschlossen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTestamentsformCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTestamentsformCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTestamentsformCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzSeiten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblABOvorherCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtABOvorherCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtABOvorherCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzSeiten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtABOnachherCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtABOnachherCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblABOnachherCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtABOvorherText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtABOnachherText.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private void qryVmTestamentVerfuegung_AfterInsert(object sender, System.EventArgs e)
        {
            qryVmTestamentVerfuegung["VmTestamentID"] = VmTestamentID;
            edtEingangsDatum.Focus();
        }

        private void qryVmTestamentVerfuegung_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtEingangsDatum, lblEingangsDatum.Text);
        }
    }
}