using System;
using System.Data;
using System.Drawing;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaQJVereinbarung.
    /// </summary>
    public class CtlKaQJVereinbarung : KissUserControl
    {
        private int actPosition = -1;
        private int BaPersonID = 0;
        private DevExpress.XtraGrid.Columns.GridColumn colAbmachungen;
        private DevExpress.XtraGrid.Columns.GridColumn colDauer;
        private DevExpress.XtraGrid.Columns.GridColumn colErfuellt;
        private DevExpress.XtraGrid.Columns.GridColumn colErstelltAm;
        private DevExpress.XtraGrid.Columns.GridColumn colVer;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit datErstelltAm;
        private KiSS4.Gui.KissLookUpEdit ddlDauer;
        private KiSS4.Dokument.XDokument docErnennungsurkunde;
        private int FaLeistungID = 0;
        private KiSS4.Gui.KissGrid grdVereinbarung;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVereinbarung;
        private KiSS4.Gui.KissLabel lblAbmachungen;
        private System.Windows.Forms.Label lblDauer;
        private System.Windows.Forms.Label lblErfuellt;
        private System.Windows.Forms.Label lblErstelltAm;
        private KiSS4.Gui.KissLabel lblGrundZiel;
        private System.Windows.Forms.Label lblTitel;
        private KiSS4.Gui.KissMemoEdit memAbmachungen;
        private KiSS4.Gui.KissMemoEdit memGrundZiel;
        private System.Windows.Forms.PictureBox picTitle;
        private KiSS4.DB.SqlQuery qryVereinbarung;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private KiSS4.Gui.KissRadioGroup rgErfuellt;
        private KiSS4.Gui.KissRadioGroup rgVereinbarung;

        public CtlKaQJVereinbarung()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "BAPERSONID":
                    return DBUtil.ExecuteScalarSQL(@"SELECT BaPersonID FROM FaLeistung WHERE FaLeistungID = {0}", this.FaLeistungID);

                case "FALEISTUNGID":
                    return this.FaLeistungID;

                case "KAQJVEREINBARUNGID":
                    return qryVereinbarung["KaQJVereinbarungID"];

                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL("select UserID from FaLeistung where FaLeistungID = {0}", FaLeistungID);
            }

            return base.GetContextValue(FieldName);
        }

        public void Init(string TitleName, Image TitleImage, int FaLeistungID, int BaPersonID)
        {
            this.lblTitel.Text = TitleName;
            this.picTitle.Image = TitleImage;
            this.FaLeistungID = FaLeistungID;
            this.BaPersonID = BaPersonID;

            this.colDauer.ColumnEdit = grdVereinbarung.GetLOVLookUpEdit("KaQjVereinbDauer");
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaQJVereinbarung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdVereinbarung = new KiSS4.Gui.KissGrid();
            this.qryVereinbarung = new KiSS4.DB.SqlQuery(this.components);
            this.gvVereinbarung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colErstelltAm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDauer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfuellt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colAbmachungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colVer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new System.Windows.Forms.Label();
            this.rgVereinbarung = new KiSS4.Gui.KissRadioGroup(this.components);
            this.lblErstelltAm = new System.Windows.Forms.Label();
            this.rgErfuellt = new KiSS4.Gui.KissRadioGroup(this.components);
            this.lblDauer = new System.Windows.Forms.Label();
            this.lblErfuellt = new System.Windows.Forms.Label();
            this.datErstelltAm = new KiSS4.Gui.KissDateEdit();
            this.ddlDauer = new KiSS4.Gui.KissLookUpEdit();
            this.memGrundZiel = new KiSS4.Gui.KissMemoEdit();
            this.lblGrundZiel = new KiSS4.Gui.KissLabel();
            this.memAbmachungen = new KiSS4.Gui.KissMemoEdit();
            this.lblAbmachungen = new KiSS4.Gui.KissLabel();
            this.docErnennungsurkunde = new KiSS4.Dokument.XDokument();
            ((System.ComponentModel.ISupportInitialize)(this.grdVereinbarung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVereinbarung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVereinbarung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgVereinbarung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgVereinbarung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgErfuellt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgErfuellt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datErstelltAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDauer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDauer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memGrundZiel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundZiel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAbmachungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbmachungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docErnennungsurkunde.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdVereinbarung
            // 
            this.grdVereinbarung.DataSource = this.qryVereinbarung;
            // 
            // 
            // 
            this.grdVereinbarung.EmbeddedNavigator.Name = "";
            this.grdVereinbarung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVereinbarung.Location = new System.Drawing.Point(5, 43);
            this.grdVereinbarung.MainView = this.gvVereinbarung;
            this.grdVereinbarung.Name = "grdVereinbarung";
            this.grdVereinbarung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1});
            this.grdVereinbarung.Size = new System.Drawing.Size(747, 145);
            this.grdVereinbarung.TabIndex = 7;
            this.grdVereinbarung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvVereinbarung});
            // 
            // qryVereinbarung
            // 
            this.qryVereinbarung.CanDelete = true;
            this.qryVereinbarung.CanInsert = true;
            this.qryVereinbarung.CanUpdate = true;
            this.qryVereinbarung.HostControl = this;
            this.qryVereinbarung.IsIdentityInsert = false;
            this.qryVereinbarung.TableName = "KaQJVereinbarung";
            this.qryVereinbarung.AfterInsert += new System.EventHandler(this.qryVereinbarung_AfterInsert);
            this.qryVereinbarung.AfterPost += new System.EventHandler(this.qryVereinbarung_AfterPost);
            this.qryVereinbarung.BeforePost += new System.EventHandler(this.qryVereinbarung_BeforePost);
            // 
            // gvVereinbarung
            // 
            this.gvVereinbarung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvVereinbarung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvVereinbarung.Appearance.Empty.Options.UseBackColor = true;
            this.gvVereinbarung.Appearance.Empty.Options.UseFont = true;
            this.gvVereinbarung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvVereinbarung.Appearance.EvenRow.Options.UseFont = true;
            this.gvVereinbarung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvVereinbarung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvVereinbarung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvVereinbarung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvVereinbarung.Appearance.FocusedCell.Options.UseFont = true;
            this.gvVereinbarung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvVereinbarung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvVereinbarung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvVereinbarung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvVereinbarung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvVereinbarung.Appearance.FocusedRow.Options.UseFont = true;
            this.gvVereinbarung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvVereinbarung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gvVereinbarung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gvVereinbarung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gvVereinbarung.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gvVereinbarung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvVereinbarung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvVereinbarung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvVereinbarung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvVereinbarung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvVereinbarung.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvVereinbarung.Appearance.GroupRow.Options.UseFont = true;
            this.gvVereinbarung.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvVereinbarung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvVereinbarung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvVereinbarung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvVereinbarung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvVereinbarung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvVereinbarung.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvVereinbarung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvVereinbarung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvVereinbarung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvVereinbarung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvVereinbarung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvVereinbarung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvVereinbarung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvVereinbarung.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvVereinbarung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvVereinbarung.Appearance.OddRow.Options.UseFont = true;
            this.gvVereinbarung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvVereinbarung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvVereinbarung.Appearance.Row.Options.UseBackColor = true;
            this.gvVereinbarung.Appearance.Row.Options.UseFont = true;
            this.gvVereinbarung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvVereinbarung.Appearance.SelectedRow.Options.UseFont = true;
            this.gvVereinbarung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvVereinbarung.Appearance.VertLine.Options.UseBackColor = true;
            this.gvVereinbarung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvVereinbarung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colErstelltAm,
            this.colDauer,
            this.colErfuellt,
            this.colAbmachungen,
            this.colVer});
            this.gvVereinbarung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvVereinbarung.GridControl = this.grdVereinbarung;
            this.gvVereinbarung.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvVereinbarung.Name = "gvVereinbarung";
            this.gvVereinbarung.OptionsBehavior.Editable = false;
            this.gvVereinbarung.OptionsCustomization.AllowFilter = false;
            this.gvVereinbarung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvVereinbarung.OptionsNavigation.AutoFocusNewRow = true;
            this.gvVereinbarung.OptionsNavigation.UseTabKey = false;
            this.gvVereinbarung.OptionsView.ColumnAutoWidth = false;
            this.gvVereinbarung.OptionsView.RowAutoHeight = true;
            this.gvVereinbarung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvVereinbarung.OptionsView.ShowGroupPanel = false;
            this.gvVereinbarung.OptionsView.ShowIndicator = false;
            this.gvVereinbarung.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvVereinbarung_RowCellStyle);
            // 
            // colErstelltAm
            // 
            this.colErstelltAm.Caption = "erstellt am";
            this.colErstelltAm.FieldName = "ErstelltAm";
            this.colErstelltAm.Name = "colErstelltAm";
            this.colErstelltAm.Visible = true;
            this.colErstelltAm.VisibleIndex = 0;
            this.colErstelltAm.Width = 80;
            // 
            // colDauer
            // 
            this.colDauer.Caption = "Dauer";
            this.colDauer.FieldName = "DauerCode";
            this.colDauer.Name = "colDauer";
            this.colDauer.Visible = true;
            this.colDauer.VisibleIndex = 1;
            this.colDauer.Width = 80;
            // 
            // colErfuellt
            // 
            this.colErfuellt.Caption = "erfüllt";
            this.colErfuellt.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colErfuellt.FieldName = "Erfuellt";
            this.colErfuellt.Name = "colErfuellt";
            this.colErfuellt.OptionsColumn.AllowEdit = false;
            this.colErfuellt.OptionsColumn.ReadOnly = true;
            this.colErfuellt.Visible = true;
            this.colErfuellt.VisibleIndex = 2;
            this.colErfuellt.Width = 50;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colAbmachungen
            // 
            this.colAbmachungen.Caption = "Abmachungen";
            this.colAbmachungen.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colAbmachungen.FieldName = "Abmachungen";
            this.colAbmachungen.Name = "colAbmachungen";
            this.colAbmachungen.Visible = true;
            this.colAbmachungen.VisibleIndex = 3;
            this.colAbmachungen.Width = 500;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.ReadOnly = true;
            // 
            // colVer
            // 
            this.colVer.Caption = "Vereinbarung";
            this.colVer.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colVer.FieldName = "Vereinbarung";
            this.colVer.Name = "colVer";
            // 
            // picTitle
            // 
            this.picTitle.Image = ((System.Drawing.Image)(resources.GetObject("picTitle.Image")));
            this.picTitle.Location = new System.Drawing.Point(10, 9);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(25, 20);
            this.picTitle.TabIndex = 17;
            this.picTitle.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 18;
            this.lblTitel.Text = "Titel";
            // 
            // rgVereinbarung
            // 
            this.rgVereinbarung.DataMember = "Ver";
            this.rgVereinbarung.DataSource = this.qryVereinbarung;
            this.rgVereinbarung.EditValue = "";
            this.rgVereinbarung.Location = new System.Drawing.Point(10, 195);
            this.rgVereinbarung.LookupSQL = null;
            this.rgVereinbarung.LOVFilter = null;
            this.rgVereinbarung.LOVName = null;
            this.rgVereinbarung.Name = "rgVereinbarung";
            this.rgVereinbarung.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgVereinbarung.Properties.Appearance.Options.UseBackColor = true;
            this.rgVereinbarung.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.rgVereinbarung.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.rgVereinbarung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgVereinbarung.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "gelbe Vereinbarung"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "rote Vereinbarung")});
            this.rgVereinbarung.Size = new System.Drawing.Size(307, 30);
            this.rgVereinbarung.TabIndex = 0;
            // 
            // lblErstelltAm
            // 
            this.lblErstelltAm.Location = new System.Drawing.Point(5, 230);
            this.lblErstelltAm.Name = "lblErstelltAm";
            this.lblErstelltAm.Size = new System.Drawing.Size(74, 24);
            this.lblErstelltAm.TabIndex = 20;
            this.lblErstelltAm.Text = "erstellt am";
            this.lblErstelltAm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rgErfuellt
            // 
            this.rgErfuellt.DataMember = "Erf";
            this.rgErfuellt.DataSource = this.qryVereinbarung;
            this.rgErfuellt.EditValue = "";
            this.rgErfuellt.Location = new System.Drawing.Point(100, 290);
            this.rgErfuellt.LookupSQL = null;
            this.rgErfuellt.LOVFilter = null;
            this.rgErfuellt.LOVName = null;
            this.rgErfuellt.Name = "rgErfuellt";
            this.rgErfuellt.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgErfuellt.Properties.Appearance.Options.UseBackColor = true;
            this.rgErfuellt.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.rgErfuellt.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.rgErfuellt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgErfuellt.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Ja"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "Nein")});
            this.rgErfuellt.Size = new System.Drawing.Size(117, 30);
            this.rgErfuellt.TabIndex = 3;
            // 
            // lblDauer
            // 
            this.lblDauer.Location = new System.Drawing.Point(5, 260);
            this.lblDauer.Name = "lblDauer";
            this.lblDauer.Size = new System.Drawing.Size(60, 24);
            this.lblDauer.TabIndex = 22;
            this.lblDauer.Text = "Dauer";
            this.lblDauer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblErfuellt
            // 
            this.lblErfuellt.Location = new System.Drawing.Point(5, 290);
            this.lblErfuellt.Name = "lblErfuellt";
            this.lblErfuellt.Size = new System.Drawing.Size(60, 24);
            this.lblErfuellt.TabIndex = 23;
            this.lblErfuellt.Text = "erfüllt";
            this.lblErfuellt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // datErstelltAm
            // 
            this.datErstelltAm.DataMember = "ErstelltAm";
            this.datErstelltAm.DataSource = this.qryVereinbarung;
            this.datErstelltAm.EditValue = null;
            this.datErstelltAm.Location = new System.Drawing.Point(100, 230);
            this.datErstelltAm.Name = "datErstelltAm";
            this.datErstelltAm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datErstelltAm.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datErstelltAm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datErstelltAm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datErstelltAm.Properties.Appearance.Options.UseBackColor = true;
            this.datErstelltAm.Properties.Appearance.Options.UseBorderColor = true;
            this.datErstelltAm.Properties.Appearance.Options.UseFont = true;
            this.datErstelltAm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.datErstelltAm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datErstelltAm.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.datErstelltAm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datErstelltAm.Properties.ShowToday = false;
            this.datErstelltAm.Size = new System.Drawing.Size(89, 24);
            this.datErstelltAm.TabIndex = 1;
            // 
            // ddlDauer
            // 
            this.ddlDauer.DataMember = "DauerCode";
            this.ddlDauer.DataSource = this.qryVereinbarung;
            this.ddlDauer.Location = new System.Drawing.Point(100, 260);
            this.ddlDauer.LOVName = "KaQjVereinbDauer";
            this.ddlDauer.Name = "ddlDauer";
            this.ddlDauer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlDauer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlDauer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlDauer.Properties.Appearance.Options.UseBackColor = true;
            this.ddlDauer.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlDauer.Properties.Appearance.Options.UseFont = true;
            this.ddlDauer.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlDauer.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlDauer.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlDauer.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlDauer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.ddlDauer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.ddlDauer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlDauer.Properties.NullText = "";
            this.ddlDauer.Properties.ShowFooter = false;
            this.ddlDauer.Properties.ShowHeader = false;
            this.ddlDauer.Size = new System.Drawing.Size(183, 24);
            this.ddlDauer.TabIndex = 2;
            // 
            // memGrundZiel
            // 
            this.memGrundZiel.DataMember = "GrundZiel";
            this.memGrundZiel.DataSource = this.qryVereinbarung;
            this.memGrundZiel.Location = new System.Drawing.Point(100, 325);
            this.memGrundZiel.Name = "memGrundZiel";
            this.memGrundZiel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memGrundZiel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memGrundZiel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memGrundZiel.Properties.Appearance.Options.UseBackColor = true;
            this.memGrundZiel.Properties.Appearance.Options.UseBorderColor = true;
            this.memGrundZiel.Properties.Appearance.Options.UseFont = true;
            this.memGrundZiel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memGrundZiel.Size = new System.Drawing.Size(547, 80);
            this.memGrundZiel.TabIndex = 4;
            // 
            // lblGrundZiel
            // 
            this.lblGrundZiel.ForeColor = System.Drawing.Color.Black;
            this.lblGrundZiel.Location = new System.Drawing.Point(5, 330);
            this.lblGrundZiel.Name = "lblGrundZiel";
            this.lblGrundZiel.Size = new System.Drawing.Size(110, 24);
            this.lblGrundZiel.TabIndex = 568;
            this.lblGrundZiel.Text = "Grund / Ziel";
            this.lblGrundZiel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // memAbmachungen
            // 
            this.memAbmachungen.DataMember = "Abmachungen";
            this.memAbmachungen.DataSource = this.qryVereinbarung;
            this.memAbmachungen.Location = new System.Drawing.Point(100, 420);
            this.memAbmachungen.Name = "memAbmachungen";
            this.memAbmachungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memAbmachungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memAbmachungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memAbmachungen.Properties.Appearance.Options.UseBackColor = true;
            this.memAbmachungen.Properties.Appearance.Options.UseBorderColor = true;
            this.memAbmachungen.Properties.Appearance.Options.UseFont = true;
            this.memAbmachungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memAbmachungen.Size = new System.Drawing.Size(547, 80);
            this.memAbmachungen.TabIndex = 5;
            // 
            // lblAbmachungen
            // 
            this.lblAbmachungen.ForeColor = System.Drawing.Color.Black;
            this.lblAbmachungen.Location = new System.Drawing.Point(5, 420);
            this.lblAbmachungen.Name = "lblAbmachungen";
            this.lblAbmachungen.Size = new System.Drawing.Size(82, 24);
            this.lblAbmachungen.TabIndex = 570;
            this.lblAbmachungen.Text = "Abmachungen";
            this.lblAbmachungen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // docErnennungsurkunde
            // 
            this.docErnennungsurkunde.Context = "KaQJVereinbarung";
            this.docErnennungsurkunde.DataMember = "VereinbarungDokID";
            this.docErnennungsurkunde.DataSource = this.qryVereinbarung;
            this.docErnennungsurkunde.Location = new System.Drawing.Point(100, 510);
            this.docErnennungsurkunde.Name = "docErnennungsurkunde";
            this.docErnennungsurkunde.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docErnennungsurkunde.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docErnennungsurkunde.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docErnennungsurkunde.Properties.Appearance.Options.UseBackColor = true;
            this.docErnennungsurkunde.Properties.Appearance.Options.UseBorderColor = true;
            this.docErnennungsurkunde.Properties.Appearance.Options.UseFont = true;
            this.docErnennungsurkunde.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docErnennungsurkunde.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docErnennungsurkunde.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.docErnennungsurkunde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docErnennungsurkunde.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docErnennungsurkunde.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docErnennungsurkunde.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docErnennungsurkunde.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument importieren")});
            this.docErnennungsurkunde.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docErnennungsurkunde.Properties.ReadOnly = true;
            this.docErnennungsurkunde.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docErnennungsurkunde.Size = new System.Drawing.Size(115, 24);
            this.docErnennungsurkunde.TabIndex = 6;
            // 
            // CtlKaQJVereinbarung
            // 
            this.ActiveSQLQuery = this.qryVereinbarung;
            this.AutoScroll = true;
            this.Controls.Add(this.docErnennungsurkunde);
            this.Controls.Add(this.memAbmachungen);
            this.Controls.Add(this.lblAbmachungen);
            this.Controls.Add(this.memGrundZiel);
            this.Controls.Add(this.lblGrundZiel);
            this.Controls.Add(this.ddlDauer);
            this.Controls.Add(this.datErstelltAm);
            this.Controls.Add(this.lblErfuellt);
            this.Controls.Add(this.rgErfuellt);
            this.Controls.Add(this.lblDauer);
            this.Controls.Add(this.rgVereinbarung);
            this.Controls.Add(this.lblErstelltAm);
            this.Controls.Add(this.grdVereinbarung);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlKaQJVereinbarung";
            this.Size = new System.Drawing.Size(759, 544);
            this.Load += new System.EventHandler(this.CtlKaQJVereinbarung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVereinbarung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVereinbarung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVereinbarung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgVereinbarung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgVereinbarung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgErfuellt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgErfuellt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datErstelltAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDauer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDauer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memGrundZiel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundZiel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAbmachungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbmachungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docErnennungsurkunde.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void CtlKaQJVereinbarung_Load(object sender, System.EventArgs e)
        {
            SetEditMode();
            FillVereinbarung();
        }

        private void FillVereinbarung()
        {
            qryVereinbarung.Fill(@"
				SELECT  KAV.*,
						Ver = CASE WHEN KAV.Vereinbarung = 1 THEN '1' ELSE CASE WHEN KAV.Vereinbarung = 0 THEN '0' ELSE null END END,
						Erf = CASE WHEN KAV.Erfuellt = 1 THEN '1' ELSE CASE WHEN KAV.Erfuellt = 0 THEN '0' ELSE null END END
				FROM KaQJVereinbarung KAV
				WHERE KAV.FaLeistungID = {0}
				    AND (KAV.SichtbarSDFlag = {1} OR KAV.SichtbarSDFlag = 1)
				ORDER BY KAV.ErstelltAm DESC",
                FaLeistungID, Session.User.IsUserKA ? 0 : 1);
        }

        private void gvVereinbarung_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            e.Appearance.Options.Reset();

            if (e.RowHandle == this.gvVereinbarung.FocusedRowHandle)
            {
                //e.CellStyle = this.grdVereinbarung.Styles["SelectedRow"];
                e.Appearance.BackColor = KaUtil.ColSelectedBackColor;
                e.Appearance.ForeColor = KaUtil.ColSelectedForeColor;
                e.Appearance.Options.UseBackColor = true;
                e.Appearance.Options.UseFont = true;
                e.Appearance.Options.UseForeColor = true;
                e.Appearance.Options.UseImage = true;
            }
            else
            {
                if (this.gvVereinbarung.GetRowCellValue(e.RowHandle, this.colVer) == System.DBNull.Value)
                {
                    //e.CellStyle = this.grdVereinbarung.Styles["ReadOnly"];
                    e.Appearance.BackColor = KaUtil.ColReadOnly;
                    e.Appearance.Options.UseBackColor = true;
                }
                else if (Convert.ToInt32(this.gvVereinbarung.GetRowCellValue(e.RowHandle, this.colVer)) == 1)
                {
                    //e.CellStyle = this.grdVereinbarung.Styles["gelbVerein"];
                    e.Appearance.BackColor = KaUtil.ColYellow;
                    e.Appearance.Options.UseBackColor = true;
                }
                else if (Convert.ToInt32(this.gvVereinbarung.GetRowCellValue(e.RowHandle, this.colVer)) == 0)
                {
                    //e.CellStyle = this.grdVereinbarung.Styles["rotVerein"];
                    e.Appearance.BackColor = KaUtil.ColRed;
                    e.Appearance.Options.UseBackColor = true;
                }
            }
        }

        private void qryVereinbarung_AfterInsert(object sender, System.EventArgs e)
        {
            qryVereinbarung["FaLeistungID"] = this.FaLeistungID;
            qryVereinbarung["SichtbarSDFlag"] = KaUtil.IsVisibleSD(this.BaPersonID);
        }

        private void qryVereinbarung_AfterPost(object sender, System.EventArgs e)
        {
            FillVereinbarung();
            qryVereinbarung.Position = actPosition;
        }

        private void qryVereinbarung_BeforePost(object sender, System.EventArgs e)
        {
            if (!DBUtil.IsEmpty(rgErfuellt.EditValue))
            {
                if (this.rgErfuellt.EditValue.ToString().Equals("1"))
                    qryVereinbarung["Erfuellt"] = true;
                else
                    qryVereinbarung["Erfuellt"] = false;
            }

            if (!DBUtil.IsEmpty(rgVereinbarung.EditValue))
            {
                if (this.rgVereinbarung.EditValue.ToString().Equals("1"))
                    qryVereinbarung["Vereinbarung"] = true;
                else
                    qryVereinbarung["Vereinbarung"] = false;
            }

            if (qryVereinbarung.Row.RowState == DataRowState.Added)
            {
                actPosition = 0;
            }
            else
            {
                actPosition = qryVereinbarung.Position;
            }
        }

        private void SetEditMode()
        {
            DBUtil.ApplyFallRightsToSqlQuery(this.FaLeistungID, qryVereinbarung);
            DBUtil.ApplyUserRightsToSqlQuery("CtlKaQJVereinbarung", qryVereinbarung);
            qryVereinbarung.EnableBoundFields();
        }
    }
}