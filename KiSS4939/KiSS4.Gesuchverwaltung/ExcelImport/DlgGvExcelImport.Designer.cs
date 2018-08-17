namespace KiSS4.Gesuchverwaltung.ExcelImport
{
    partial class DlgGvExcelImport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgGvExcelImport));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panMain = new System.Windows.Forms.TableLayoutPanel();
            this.grdPersonenExcel = new KiSS4.Gui.KissGrid();
            this.qryPersonExcel = new KiSS4.DB.SqlQuery();
            this.grvPersonenExcel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colExcelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExcelVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExcelVersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExcelGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExcelBeziehung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExcelOk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cedExcelOk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colNeuBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdPersonenKiss = new KiSS4.Gui.KissGrid();
            this.qryPersonKiss = new KiSS4.DB.SqlQuery();
            this.grvPersonenKiss = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKissName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKissVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKissVersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKissGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKissBeziehung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblPersonenExcel = new KiSS4.Gui.KissLabel();
            this.lblPersonenKiss = new KiSS4.Gui.KissLabel();
            this.panBottom = new System.Windows.Forms.TableLayoutPanel();
            this.panDetailsExcel = new System.Windows.Forms.Panel();
            this.edtExcelHausNr = new KiSS4.Gui.KissTextEdit();
            this.lblExcelStrasseNr = new KiSS4.Gui.KissLabel();
            this.edtExcelStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtExcelVersNr = new KiSS4.Gui.KissVersichertenNrEdit();
            this.edtExcelZahlweg = new KiSS4.Gui.KissMemoEdit();
            this.lblExcelZahlweg = new KiSS4.Gui.KissLabel();
            this.lblPlzOrtKanton = new KiSS4.Gui.KissLabel();
            this.edtExcelPlzOrt = new KiSS4.Common.KissPLZOrt();
            this.edtExcelBeziehung = new KiSS4.Gui.KissLookUpEdit();
            this.edtExcelGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            this.panExcelNameVorname = new System.Windows.Forms.TableLayoutPanel();
            this.edtExcelName = new KiSS4.Gui.KissTextEdit();
            this.edtExcelVorname = new KiSS4.Gui.KissTextEdit();
            this.lblExcelBeziehung = new KiSS4.Gui.KissLabel();
            this.lblExcelGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.lblExcelVersNr = new KiSS4.Gui.KissLabel();
            this.lblNameVorname = new KiSS4.Gui.KissLabel();
            this.panCenter = new System.Windows.Forms.Panel();
            this.grpKriterium = new KiSS4.Gui.KissGroupBox();
            this.btnSuche = new KiSS4.Gui.KissButton();
            this.edtKriteriumOrt = new KiSS4.Gui.KissCheckEdit();
            this.edtKriteriumPlz = new KiSS4.Gui.KissCheckEdit();
            this.edtKriteriumStrasse = new KiSS4.Gui.KissCheckEdit();
            this.edtKriteriumVersNr = new KiSS4.Gui.KissCheckEdit();
            this.edtKriteriumVorname = new KiSS4.Gui.KissCheckEdit();
            this.edtKriteriumName = new KiSS4.Gui.KissCheckEdit();
            this.btnNeuAnlegen = new KiSS4.Gui.KissButton();
            this.btnZuweisen = new KiSS4.Gui.KissButton();
            this.panDetailsKiss = new System.Windows.Forms.Panel();
            this.edtKissHausNr = new KiSS4.Gui.KissTextEdit();
            this.lblKissStrasseNr = new KiSS4.Gui.KissLabel();
            this.edtKissStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtKissVersNr = new KiSS4.Gui.KissVersichertenNrEdit();
            this.edtKissBeziehung = new KiSS4.Gui.KissTextEdit();
            this.lblKissPlzOrtKanton = new KiSS4.Gui.KissLabel();
            this.edtKissPlzOrt = new KiSS4.Common.KissPLZOrt();
            this.edtKissGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            this.panKissNameVorname = new System.Windows.Forms.TableLayoutPanel();
            this.edtKissName = new KiSS4.Gui.KissTextEdit();
            this.edtKissVorname = new KiSS4.Gui.KissTextEdit();
            this.lblKissBeziehung = new KiSS4.Gui.KissLabel();
            this.lblKissGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.lblKissVersNr = new KiSS4.Gui.KissLabel();
            this.lblKissNameVorname = new KiSS4.Gui.KissLabel();
            this.btnOk = new KiSS4.Gui.KissButton();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            this.panMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonenExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPersonExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPersonenExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cedExcelOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonenKiss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPersonKiss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPersonenKiss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonenExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonenKiss)).BeginInit();
            this.panBottom.SuspendLayout();
            this.panDetailsExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExcelStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelZahlweg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExcelZahlweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzOrtKanton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelBeziehung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelBeziehung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelGeburtsdatum.Properties)).BeginInit();
            this.panExcelNameVorname.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExcelBeziehung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExcelGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExcelVersNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameVorname)).BeginInit();
            this.panCenter.SuspendLayout();
            this.grpKriterium.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriteriumOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriteriumPlz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriteriumStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriteriumVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriteriumVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriteriumName.Properties)).BeginInit();
            this.panDetailsKiss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKissHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKissStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKissStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKissVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKissBeziehung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKissPlzOrtKanton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKissGeburtsdatum.Properties)).BeginInit();
            this.panKissNameVorname.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKissName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKissVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKissBeziehung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKissGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKissVersNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKissNameVorname)).BeginInit();
            this.SuspendLayout();
            // 
            // panMain
            // 
            this.panMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panMain.ColumnCount = 2;
            this.panMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panMain.Controls.Add(this.grdPersonenExcel, 0, 1);
            this.panMain.Controls.Add(this.grdPersonenKiss, 1, 1);
            this.panMain.Controls.Add(this.lblPersonenExcel, 0, 0);
            this.panMain.Controls.Add(this.lblPersonenKiss, 1, 0);
            this.panMain.Controls.Add(this.panBottom, 0, 2);
            this.panMain.Location = new System.Drawing.Point(12, 12);
            this.panMain.Name = "panMain";
            this.panMain.RowCount = 3;
            this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.panMain.Size = new System.Drawing.Size(960, 538);
            this.panMain.TabIndex = 0;
            // 
            // grdPersonenExcel
            // 
            this.grdPersonenExcel.DataSource = this.qryPersonExcel;
            this.grdPersonenExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdPersonenExcel.EmbeddedNavigator.Name = "";
            this.grdPersonenExcel.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdPersonenExcel.Location = new System.Drawing.Point(3, 28);
            this.grdPersonenExcel.MainView = this.grvPersonenExcel;
            this.grdPersonenExcel.Name = "grdPersonenExcel";
            this.grdPersonenExcel.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cedExcelOk});
            this.grdPersonenExcel.Size = new System.Drawing.Size(474, 247);
            this.grdPersonenExcel.TabIndex = 1;
            this.grdPersonenExcel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPersonenExcel});
            // 
            // qryPersonExcel
            // 
            this.qryPersonExcel.AutoApplyUserRights = false;
            this.qryPersonExcel.CanDelete = true;
            this.qryPersonExcel.CanInsert = true;
            this.qryPersonExcel.CanUpdate = true;
            this.qryPersonExcel.HostControl = this;
            this.qryPersonExcel.PositionChanging += new System.EventHandler(this.qryPersonExcel_PositionChanging);
            // 
            // grvPersonenExcel
            // 
            this.grvPersonenExcel.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvPersonenExcel.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonenExcel.Appearance.Empty.Options.UseBackColor = true;
            this.grvPersonenExcel.Appearance.Empty.Options.UseFont = true;
            this.grvPersonenExcel.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonenExcel.Appearance.EvenRow.Options.UseFont = true;
            this.grvPersonenExcel.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPersonenExcel.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonenExcel.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvPersonenExcel.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvPersonenExcel.Appearance.FocusedCell.Options.UseFont = true;
            this.grvPersonenExcel.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvPersonenExcel.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPersonenExcel.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonenExcel.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvPersonenExcel.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvPersonenExcel.Appearance.FocusedRow.Options.UseFont = true;
            this.grvPersonenExcel.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvPersonenExcel.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPersonenExcel.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvPersonenExcel.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPersonenExcel.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPersonenExcel.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPersonenExcel.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvPersonenExcel.Appearance.GroupRow.Options.UseFont = true;
            this.grvPersonenExcel.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvPersonenExcel.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvPersonenExcel.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvPersonenExcel.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPersonenExcel.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvPersonenExcel.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvPersonenExcel.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPersonenExcel.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvPersonenExcel.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonenExcel.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPersonenExcel.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPersonenExcel.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvPersonenExcel.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvPersonenExcel.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvPersonenExcel.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvPersonenExcel.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonenExcel.Appearance.OddRow.Options.UseFont = true;
            this.grvPersonenExcel.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPersonenExcel.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonenExcel.Appearance.Row.Options.UseBackColor = true;
            this.grvPersonenExcel.Appearance.Row.Options.UseFont = true;
            this.grvPersonenExcel.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonenExcel.Appearance.SelectedRow.Options.UseFont = true;
            this.grvPersonenExcel.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvPersonenExcel.Appearance.VertLine.Options.UseBackColor = true;
            this.grvPersonenExcel.BestFitMaxRowCount = 1000;
            this.grvPersonenExcel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvPersonenExcel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colExcelName,
            this.colExcelVorname,
            this.colExcelVersNr,
            this.colExcelGeburtsdatum,
            this.colExcelBeziehung,
            this.colExcelOk,
            this.colNeuBaPersonID});
            this.grvPersonenExcel.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvPersonenExcel.GridControl = this.grdPersonenExcel;
            this.grvPersonenExcel.Name = "grvPersonenExcel";
            this.grvPersonenExcel.OptionsBehavior.Editable = false;
            this.grvPersonenExcel.OptionsCustomization.AllowFilter = false;
            this.grvPersonenExcel.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPersonenExcel.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPersonenExcel.OptionsNavigation.UseTabKey = false;
            this.grvPersonenExcel.OptionsView.ColumnAutoWidth = false;
            this.grvPersonenExcel.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPersonenExcel.OptionsView.ShowGroupPanel = false;
            this.grvPersonenExcel.OptionsView.ShowIndicator = false;
            // 
            // colExcelName
            // 
            this.colExcelName.Caption = "Name";
            this.colExcelName.Name = "colExcelName";
            this.colExcelName.Visible = true;
            this.colExcelName.VisibleIndex = 0;
            // 
            // colExcelVorname
            // 
            this.colExcelVorname.Caption = "Vorname";
            this.colExcelVorname.Name = "colExcelVorname";
            this.colExcelVorname.Visible = true;
            this.colExcelVorname.VisibleIndex = 1;
            // 
            // colExcelVersNr
            // 
            this.colExcelVersNr.Caption = "Vers.-Nr.";
            this.colExcelVersNr.Name = "colExcelVersNr";
            this.colExcelVersNr.Visible = true;
            this.colExcelVersNr.VisibleIndex = 2;
            // 
            // colExcelGeburtsdatum
            // 
            this.colExcelGeburtsdatum.Caption = "Geburtsdatum";
            this.colExcelGeburtsdatum.Name = "colExcelGeburtsdatum";
            this.colExcelGeburtsdatum.Visible = true;
            this.colExcelGeburtsdatum.VisibleIndex = 3;
            // 
            // colExcelBeziehung
            // 
            this.colExcelBeziehung.Caption = "Klient/Beziehung";
            this.colExcelBeziehung.Name = "colExcelBeziehung";
            this.colExcelBeziehung.Visible = true;
            this.colExcelBeziehung.VisibleIndex = 4;
            // 
            // colExcelOk
            // 
            this.colExcelOk.Caption = "OK";
            this.colExcelOk.ColumnEdit = this.cedExcelOk;
            this.colExcelOk.Name = "colExcelOk";
            this.colExcelOk.Visible = true;
            this.colExcelOk.VisibleIndex = 5;
            this.colExcelOk.Width = 39;
            // 
            // cedExcelOk
            // 
            this.cedExcelOk.AutoHeight = false;
            this.cedExcelOk.Name = "cedExcelOk";
            this.cedExcelOk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colNeuBaPersonID
            // 
            this.colNeuBaPersonID.Caption = "Neu/Personen-Nr.";
            this.colNeuBaPersonID.Name = "colNeuBaPersonID";
            this.colNeuBaPersonID.Visible = true;
            this.colNeuBaPersonID.VisibleIndex = 6;
            // 
            // grdPersonenKiss
            // 
            this.grdPersonenKiss.DataSource = this.qryPersonKiss;
            this.grdPersonenKiss.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdPersonenKiss.EmbeddedNavigator.Name = "";
            this.grdPersonenKiss.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdPersonenKiss.Location = new System.Drawing.Point(483, 28);
            this.grdPersonenKiss.MainView = this.grvPersonenKiss;
            this.grdPersonenKiss.Name = "grdPersonenKiss";
            this.grdPersonenKiss.Size = new System.Drawing.Size(474, 247);
            this.grdPersonenKiss.TabIndex = 3;
            this.grdPersonenKiss.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPersonenKiss});
            // 
            // qryPersonKiss
            // 
            this.qryPersonKiss.HostControl = this;
            // 
            // grvPersonenKiss
            // 
            this.grvPersonenKiss.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvPersonenKiss.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonenKiss.Appearance.Empty.Options.UseBackColor = true;
            this.grvPersonenKiss.Appearance.Empty.Options.UseFont = true;
            this.grvPersonenKiss.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonenKiss.Appearance.EvenRow.Options.UseFont = true;
            this.grvPersonenKiss.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPersonenKiss.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonenKiss.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvPersonenKiss.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvPersonenKiss.Appearance.FocusedCell.Options.UseFont = true;
            this.grvPersonenKiss.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvPersonenKiss.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPersonenKiss.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonenKiss.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvPersonenKiss.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvPersonenKiss.Appearance.FocusedRow.Options.UseFont = true;
            this.grvPersonenKiss.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvPersonenKiss.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPersonenKiss.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvPersonenKiss.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPersonenKiss.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPersonenKiss.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPersonenKiss.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvPersonenKiss.Appearance.GroupRow.Options.UseFont = true;
            this.grvPersonenKiss.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvPersonenKiss.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvPersonenKiss.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvPersonenKiss.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPersonenKiss.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvPersonenKiss.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvPersonenKiss.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPersonenKiss.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvPersonenKiss.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonenKiss.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPersonenKiss.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPersonenKiss.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvPersonenKiss.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvPersonenKiss.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvPersonenKiss.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvPersonenKiss.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonenKiss.Appearance.OddRow.Options.UseFont = true;
            this.grvPersonenKiss.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPersonenKiss.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonenKiss.Appearance.Row.Options.UseBackColor = true;
            this.grvPersonenKiss.Appearance.Row.Options.UseFont = true;
            this.grvPersonenKiss.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonenKiss.Appearance.SelectedRow.Options.UseFont = true;
            this.grvPersonenKiss.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvPersonenKiss.Appearance.VertLine.Options.UseBackColor = true;
            this.grvPersonenKiss.BestFitMaxRowCount = 1000;
            this.grvPersonenKiss.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvPersonenKiss.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKissName,
            this.colKissVorname,
            this.colKissVersNr,
            this.colKissGeburtsdatum,
            this.colKissBeziehung});
            this.grvPersonenKiss.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvPersonenKiss.GridControl = this.grdPersonenKiss;
            this.grvPersonenKiss.Name = "grvPersonenKiss";
            this.grvPersonenKiss.OptionsBehavior.Editable = false;
            this.grvPersonenKiss.OptionsCustomization.AllowFilter = false;
            this.grvPersonenKiss.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPersonenKiss.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPersonenKiss.OptionsNavigation.UseTabKey = false;
            this.grvPersonenKiss.OptionsView.ColumnAutoWidth = false;
            this.grvPersonenKiss.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPersonenKiss.OptionsView.ShowGroupPanel = false;
            this.grvPersonenKiss.OptionsView.ShowIndicator = false;
            // 
            // colKissName
            // 
            this.colKissName.Caption = "Name";
            this.colKissName.Name = "colKissName";
            this.colKissName.Visible = true;
            this.colKissName.VisibleIndex = 0;
            // 
            // colKissVorname
            // 
            this.colKissVorname.Caption = "Vorname";
            this.colKissVorname.Name = "colKissVorname";
            this.colKissVorname.Visible = true;
            this.colKissVorname.VisibleIndex = 1;
            // 
            // colKissVersNr
            // 
            this.colKissVersNr.Caption = "Vers.-Nr.";
            this.colKissVersNr.Name = "colKissVersNr";
            this.colKissVersNr.Visible = true;
            this.colKissVersNr.VisibleIndex = 2;
            // 
            // colKissGeburtsdatum
            // 
            this.colKissGeburtsdatum.Caption = "Geburtsdatum";
            this.colKissGeburtsdatum.Name = "colKissGeburtsdatum";
            this.colKissGeburtsdatum.Visible = true;
            this.colKissGeburtsdatum.VisibleIndex = 3;
            // 
            // colKissBeziehung
            // 
            this.colKissBeziehung.Caption = "Beziehung";
            this.colKissBeziehung.Name = "colKissBeziehung";
            this.colKissBeziehung.Visible = true;
            this.colKissBeziehung.VisibleIndex = 4;
            // 
            // lblPersonenExcel
            // 
            this.lblPersonenExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonenExcel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblPersonenExcel.Location = new System.Drawing.Point(3, 0);
            this.lblPersonenExcel.Name = "lblPersonenExcel";
            this.lblPersonenExcel.Size = new System.Drawing.Size(474, 16);
            this.lblPersonenExcel.TabIndex = 0;
            this.lblPersonenExcel.Text = "Personen Excel-Datei";
            // 
            // lblPersonenKiss
            // 
            this.lblPersonenKiss.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonenKiss.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblPersonenKiss.Location = new System.Drawing.Point(483, 0);
            this.lblPersonenKiss.Name = "lblPersonenKiss";
            this.lblPersonenKiss.Size = new System.Drawing.Size(474, 16);
            this.lblPersonenKiss.TabIndex = 2;
            this.lblPersonenKiss.Text = "Personen in KiSS-Personenstamm";
            // 
            // panBottom
            // 
            this.panBottom.ColumnCount = 3;
            this.panMain.SetColumnSpan(this.panBottom, 2);
            this.panBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panBottom.Controls.Add(this.panDetailsExcel, 0, 0);
            this.panBottom.Controls.Add(this.panCenter, 1, 0);
            this.panBottom.Controls.Add(this.panDetailsKiss, 2, 0);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBottom.Location = new System.Drawing.Point(0, 278);
            this.panBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panBottom.Name = "panBottom";
            this.panBottom.RowCount = 1;
            this.panBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panBottom.Size = new System.Drawing.Size(960, 260);
            this.panBottom.TabIndex = 4;
            // 
            // panDetailsExcel
            // 
            this.panDetailsExcel.Controls.Add(this.edtExcelHausNr);
            this.panDetailsExcel.Controls.Add(this.lblExcelStrasseNr);
            this.panDetailsExcel.Controls.Add(this.edtExcelStrasse);
            this.panDetailsExcel.Controls.Add(this.edtExcelVersNr);
            this.panDetailsExcel.Controls.Add(this.edtExcelZahlweg);
            this.panDetailsExcel.Controls.Add(this.lblExcelZahlweg);
            this.panDetailsExcel.Controls.Add(this.lblPlzOrtKanton);
            this.panDetailsExcel.Controls.Add(this.edtExcelPlzOrt);
            this.panDetailsExcel.Controls.Add(this.edtExcelBeziehung);
            this.panDetailsExcel.Controls.Add(this.edtExcelGeburtsdatum);
            this.panDetailsExcel.Controls.Add(this.panExcelNameVorname);
            this.panDetailsExcel.Controls.Add(this.lblExcelBeziehung);
            this.panDetailsExcel.Controls.Add(this.lblExcelGeburtsdatum);
            this.panDetailsExcel.Controls.Add(this.lblExcelVersNr);
            this.panDetailsExcel.Controls.Add(this.lblNameVorname);
            this.panDetailsExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetailsExcel.Location = new System.Drawing.Point(0, 0);
            this.panDetailsExcel.Margin = new System.Windows.Forms.Padding(0);
            this.panDetailsExcel.Name = "panDetailsExcel";
            this.panDetailsExcel.Size = new System.Drawing.Size(414, 326);
            this.panDetailsExcel.TabIndex = 0;
            // 
            // edtExcelHausNr
            // 
            this.edtExcelHausNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtExcelHausNr.DataSource = this.qryPersonExcel;
            this.edtExcelHausNr.Location = new System.Drawing.Point(361, 123);
            this.edtExcelHausNr.Name = "edtExcelHausNr";
            this.edtExcelHausNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExcelHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExcelHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExcelHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtExcelHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExcelHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtExcelHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtExcelHausNr.Size = new System.Drawing.Size(50, 24);
            this.edtExcelHausNr.TabIndex = 10;
            // 
            // lblExcelStrasseNr
            // 
            this.lblExcelStrasseNr.Location = new System.Drawing.Point(0, 123);
            this.lblExcelStrasseNr.Name = "lblExcelStrasseNr";
            this.lblExcelStrasseNr.Size = new System.Drawing.Size(100, 24);
            this.lblExcelStrasseNr.TabIndex = 8;
            this.lblExcelStrasseNr.Text = "Strasse, Nr.";
            // 
            // edtExcelStrasse
            // 
            this.edtExcelStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtExcelStrasse.DataSource = this.qryPersonExcel;
            this.edtExcelStrasse.Location = new System.Drawing.Point(106, 123);
            this.edtExcelStrasse.Name = "edtExcelStrasse";
            this.edtExcelStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExcelStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExcelStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExcelStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtExcelStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExcelStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtExcelStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtExcelStrasse.Size = new System.Drawing.Size(249, 24);
            this.edtExcelStrasse.TabIndex = 9;
            // 
            // edtExcelVersNr
            // 
            this.edtExcelVersNr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtExcelVersNr.DataSource = this.qryPersonExcel;
            this.edtExcelVersNr.Location = new System.Drawing.Point(106, 33);
            this.edtExcelVersNr.Name = "edtExcelVersNr";
            this.edtExcelVersNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtExcelVersNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExcelVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExcelVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExcelVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtExcelVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExcelVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtExcelVersNr.Properties.Appearance.Options.UseTextOptions = true;
            this.edtExcelVersNr.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtExcelVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtExcelVersNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtExcelVersNr.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtExcelVersNr.Properties.DisplayFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtExcelVersNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtExcelVersNr.Properties.EditFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtExcelVersNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtExcelVersNr.Properties.Mask.EditMask = "000\\.0000\\.0000\\.00";
            this.edtExcelVersNr.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtExcelVersNr.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtExcelVersNr.Properties.MaxLength = 13;
            this.edtExcelVersNr.Properties.Precision = 0;
            this.edtExcelVersNr.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtExcelVersNr.Size = new System.Drawing.Size(305, 24);
            this.edtExcelVersNr.TabIndex = 3;
            this.edtExcelVersNr.EditValueChanged += new System.EventHandler(this.edtExcelVersNr_EditValueChanged);
            // 
            // edtExcelZahlweg
            // 
            this.edtExcelZahlweg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtExcelZahlweg.DataSource = this.qryPersonExcel;
            this.edtExcelZahlweg.Location = new System.Drawing.Point(106, 183);
            this.edtExcelZahlweg.Name = "edtExcelZahlweg";
            this.edtExcelZahlweg.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExcelZahlweg.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExcelZahlweg.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExcelZahlweg.Properties.Appearance.Options.UseBackColor = true;
            this.edtExcelZahlweg.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExcelZahlweg.Properties.Appearance.Options.UseFont = true;
            this.edtExcelZahlweg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtExcelZahlweg.Size = new System.Drawing.Size(305, 77);
            this.edtExcelZahlweg.TabIndex = 14;
            // 
            // lblExcelZahlweg
            // 
            this.lblExcelZahlweg.Location = new System.Drawing.Point(0, 183);
            this.lblExcelZahlweg.Name = "lblExcelZahlweg";
            this.lblExcelZahlweg.Size = new System.Drawing.Size(100, 24);
            this.lblExcelZahlweg.TabIndex = 13;
            this.lblExcelZahlweg.Text = "Zahlweg";
            // 
            // lblPlzOrtKanton
            // 
            this.lblPlzOrtKanton.Location = new System.Drawing.Point(0, 153);
            this.lblPlzOrtKanton.Name = "lblPlzOrtKanton";
            this.lblPlzOrtKanton.Size = new System.Drawing.Size(100, 24);
            this.lblPlzOrtKanton.TabIndex = 11;
            this.lblPlzOrtKanton.Text = "PLZ, Ort, Kanton";
            // 
            // edtExcelPlzOrt
            // 
            this.edtExcelPlzOrt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtExcelPlzOrt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtExcelPlzOrt.DataSource = this.qryPersonExcel;
            this.edtExcelPlzOrt.Location = new System.Drawing.Point(106, 153);
            this.edtExcelPlzOrt.Name = "edtExcelPlzOrt";
            this.edtExcelPlzOrt.ShowLand = false;
            this.edtExcelPlzOrt.Size = new System.Drawing.Size(305, 24);
            this.edtExcelPlzOrt.TabIndex = 12;
            // 
            // edtExcelBeziehung
            // 
            this.edtExcelBeziehung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtExcelBeziehung.DataSource = this.qryPersonExcel;
            this.edtExcelBeziehung.Location = new System.Drawing.Point(106, 93);
            this.edtExcelBeziehung.Name = "edtExcelBeziehung";
            this.edtExcelBeziehung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExcelBeziehung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExcelBeziehung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExcelBeziehung.Properties.Appearance.Options.UseBackColor = true;
            this.edtExcelBeziehung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExcelBeziehung.Properties.Appearance.Options.UseFont = true;
            this.edtExcelBeziehung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtExcelBeziehung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtExcelBeziehung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtExcelBeziehung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtExcelBeziehung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtExcelBeziehung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtExcelBeziehung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtExcelBeziehung.Properties.NullText = "";
            this.edtExcelBeziehung.Properties.ShowFooter = false;
            this.edtExcelBeziehung.Properties.ShowHeader = false;
            this.edtExcelBeziehung.Size = new System.Drawing.Size(305, 24);
            this.edtExcelBeziehung.TabIndex = 7;
            // 
            // edtExcelGeburtsdatum
            // 
            this.edtExcelGeburtsdatum.DataSource = this.qryPersonExcel;
            this.edtExcelGeburtsdatum.EditValue = null;
            this.edtExcelGeburtsdatum.Location = new System.Drawing.Point(106, 63);
            this.edtExcelGeburtsdatum.Name = "edtExcelGeburtsdatum";
            this.edtExcelGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtExcelGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExcelGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExcelGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExcelGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtExcelGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExcelGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtExcelGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtExcelGeburtsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtExcelGeburtsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtExcelGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtExcelGeburtsdatum.Properties.ShowToday = false;
            this.edtExcelGeburtsdatum.Size = new System.Drawing.Size(100, 24);
            this.edtExcelGeburtsdatum.TabIndex = 5;
            // 
            // panExcelNameVorname
            // 
            this.panExcelNameVorname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panExcelNameVorname.ColumnCount = 2;
            this.panExcelNameVorname.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panExcelNameVorname.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panExcelNameVorname.Controls.Add(this.edtExcelName, 0, 0);
            this.panExcelNameVorname.Controls.Add(this.edtExcelVorname, 1, 0);
            this.panExcelNameVorname.Location = new System.Drawing.Point(106, 3);
            this.panExcelNameVorname.Name = "panExcelNameVorname";
            this.panExcelNameVorname.RowCount = 1;
            this.panExcelNameVorname.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panExcelNameVorname.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panExcelNameVorname.Size = new System.Drawing.Size(305, 24);
            this.panExcelNameVorname.TabIndex = 1;
            // 
            // edtExcelName
            // 
            this.edtExcelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtExcelName.DataSource = this.qryPersonExcel;
            this.edtExcelName.Location = new System.Drawing.Point(0, 0);
            this.edtExcelName.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.edtExcelName.Name = "edtExcelName";
            this.edtExcelName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExcelName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExcelName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExcelName.Properties.Appearance.Options.UseBackColor = true;
            this.edtExcelName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExcelName.Properties.Appearance.Options.UseFont = true;
            this.edtExcelName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtExcelName.Size = new System.Drawing.Size(149, 24);
            this.edtExcelName.TabIndex = 0;
            // 
            // edtExcelVorname
            // 
            this.edtExcelVorname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtExcelVorname.DataSource = this.qryPersonExcel;
            this.edtExcelVorname.Location = new System.Drawing.Point(155, 0);
            this.edtExcelVorname.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.edtExcelVorname.Name = "edtExcelVorname";
            this.edtExcelVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExcelVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExcelVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExcelVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtExcelVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExcelVorname.Properties.Appearance.Options.UseFont = true;
            this.edtExcelVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtExcelVorname.Size = new System.Drawing.Size(150, 24);
            this.edtExcelVorname.TabIndex = 1;
            // 
            // lblExcelBeziehung
            // 
            this.lblExcelBeziehung.Location = new System.Drawing.Point(0, 93);
            this.lblExcelBeziehung.Name = "lblExcelBeziehung";
            this.lblExcelBeziehung.Size = new System.Drawing.Size(100, 24);
            this.lblExcelBeziehung.TabIndex = 6;
            this.lblExcelBeziehung.Text = "Klient/Beziehung";
            // 
            // lblExcelGeburtsdatum
            // 
            this.lblExcelGeburtsdatum.Location = new System.Drawing.Point(0, 63);
            this.lblExcelGeburtsdatum.Name = "lblExcelGeburtsdatum";
            this.lblExcelGeburtsdatum.Size = new System.Drawing.Size(100, 24);
            this.lblExcelGeburtsdatum.TabIndex = 4;
            this.lblExcelGeburtsdatum.Text = "Geburtsdatum";
            // 
            // lblExcelVersNr
            // 
            this.lblExcelVersNr.Location = new System.Drawing.Point(0, 33);
            this.lblExcelVersNr.Name = "lblExcelVersNr";
            this.lblExcelVersNr.Size = new System.Drawing.Size(100, 24);
            this.lblExcelVersNr.TabIndex = 2;
            this.lblExcelVersNr.Text = "Vers.-Nr.";
            // 
            // lblNameVorname
            // 
            this.lblNameVorname.Location = new System.Drawing.Point(0, 3);
            this.lblNameVorname.Name = "lblNameVorname";
            this.lblNameVorname.Size = new System.Drawing.Size(100, 24);
            this.lblNameVorname.TabIndex = 0;
            this.lblNameVorname.Text = "Name, Vorname";
            // 
            // panCenter
            // 
            this.panCenter.Controls.Add(this.grpKriterium);
            this.panCenter.Controls.Add(this.btnNeuAnlegen);
            this.panCenter.Controls.Add(this.btnZuweisen);
            this.panCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panCenter.Location = new System.Drawing.Point(414, 0);
            this.panCenter.Margin = new System.Windows.Forms.Padding(0);
            this.panCenter.Name = "panCenter";
            this.panCenter.Size = new System.Drawing.Size(131, 326);
            this.panCenter.TabIndex = 1;
            // 
            // grpKriterium
            // 
            this.grpKriterium.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpKriterium.Controls.Add(this.btnSuche);
            this.grpKriterium.Controls.Add(this.edtKriteriumOrt);
            this.grpKriterium.Controls.Add(this.edtKriteriumPlz);
            this.grpKriterium.Controls.Add(this.edtKriteriumStrasse);
            this.grpKriterium.Controls.Add(this.edtKriteriumVersNr);
            this.grpKriterium.Controls.Add(this.edtKriteriumVorname);
            this.grpKriterium.Controls.Add(this.edtKriteriumName);
            this.grpKriterium.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpKriterium.Location = new System.Drawing.Point(3, 63);
            this.grpKriterium.Name = "grpKriterium";
            this.grpKriterium.Size = new System.Drawing.Size(125, 197);
            this.grpKriterium.TabIndex = 2;
            this.grpKriterium.TabStop = false;
            this.grpKriterium.Text = "Kriterium";
            // 
            // btnSuche
            // 
            this.btnSuche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuche.Location = new System.Drawing.Point(29, 167);
            this.btnSuche.Name = "btnSuche";
            this.btnSuche.Size = new System.Drawing.Size(90, 24);
            this.btnSuche.TabIndex = 6;
            this.btnSuche.Text = "Suche";
            this.btnSuche.UseVisualStyleBackColor = false;
            this.btnSuche.Click += new System.EventHandler(this.btnSuche_Click);
            // 
            // edtKriteriumOrt
            // 
            this.edtKriteriumOrt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKriteriumOrt.EditValue = false;
            this.edtKriteriumOrt.Location = new System.Drawing.Point(6, 145);
            this.edtKriteriumOrt.Name = "edtKriteriumOrt";
            this.edtKriteriumOrt.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtKriteriumOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtKriteriumOrt.Properties.Caption = "Ort";
            this.edtKriteriumOrt.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.edtKriteriumOrt.Size = new System.Drawing.Size(113, 19);
            this.edtKriteriumOrt.TabIndex = 5;
            // 
            // edtKriteriumPlz
            // 
            this.edtKriteriumPlz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKriteriumPlz.EditValue = false;
            this.edtKriteriumPlz.Location = new System.Drawing.Point(6, 120);
            this.edtKriteriumPlz.Name = "edtKriteriumPlz";
            this.edtKriteriumPlz.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtKriteriumPlz.Properties.Appearance.Options.UseBackColor = true;
            this.edtKriteriumPlz.Properties.Caption = "PLZ";
            this.edtKriteriumPlz.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.edtKriteriumPlz.Size = new System.Drawing.Size(113, 19);
            this.edtKriteriumPlz.TabIndex = 4;
            // 
            // edtKriteriumStrasse
            // 
            this.edtKriteriumStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKriteriumStrasse.EditValue = false;
            this.edtKriteriumStrasse.Location = new System.Drawing.Point(6, 95);
            this.edtKriteriumStrasse.Name = "edtKriteriumStrasse";
            this.edtKriteriumStrasse.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtKriteriumStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtKriteriumStrasse.Properties.Caption = "Strasse";
            this.edtKriteriumStrasse.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.edtKriteriumStrasse.Size = new System.Drawing.Size(113, 19);
            this.edtKriteriumStrasse.TabIndex = 3;
            // 
            // edtKriteriumVersNr
            // 
            this.edtKriteriumVersNr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKriteriumVersNr.EditValue = true;
            this.edtKriteriumVersNr.Location = new System.Drawing.Point(6, 70);
            this.edtKriteriumVersNr.Name = "edtKriteriumVersNr";
            this.edtKriteriumVersNr.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtKriteriumVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKriteriumVersNr.Properties.Caption = "Vers.-Nr.";
            this.edtKriteriumVersNr.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.edtKriteriumVersNr.Size = new System.Drawing.Size(113, 19);
            this.edtKriteriumVersNr.TabIndex = 2;
            // 
            // edtKriteriumVorname
            // 
            this.edtKriteriumVorname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKriteriumVorname.EditValue = false;
            this.edtKriteriumVorname.Location = new System.Drawing.Point(6, 45);
            this.edtKriteriumVorname.Name = "edtKriteriumVorname";
            this.edtKriteriumVorname.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtKriteriumVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtKriteriumVorname.Properties.Caption = "Vorname";
            this.edtKriteriumVorname.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.edtKriteriumVorname.Size = new System.Drawing.Size(113, 19);
            this.edtKriteriumVorname.TabIndex = 1;
            // 
            // edtKriteriumName
            // 
            this.edtKriteriumName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKriteriumName.EditValue = false;
            this.edtKriteriumName.Location = new System.Drawing.Point(6, 20);
            this.edtKriteriumName.Name = "edtKriteriumName";
            this.edtKriteriumName.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtKriteriumName.Properties.Appearance.Options.UseBackColor = true;
            this.edtKriteriumName.Properties.Caption = "Name";
            this.edtKriteriumName.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.edtKriteriumName.Size = new System.Drawing.Size(113, 19);
            this.edtKriteriumName.TabIndex = 0;
            // 
            // btnNeuAnlegen
            // 
            this.btnNeuAnlegen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeuAnlegen.Location = new System.Drawing.Point(3, 33);
            this.btnNeuAnlegen.Name = "btnNeuAnlegen";
            this.btnNeuAnlegen.Size = new System.Drawing.Size(125, 24);
            this.btnNeuAnlegen.TabIndex = 1;
            this.btnNeuAnlegen.Text = "Neu anlegen >";
            this.btnNeuAnlegen.UseVisualStyleBackColor = false;
            this.btnNeuAnlegen.Click += new System.EventHandler(this.btnNeuAnlegen_Click);
            // 
            // btnZuweisen
            // 
            this.btnZuweisen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZuweisen.Location = new System.Drawing.Point(3, 3);
            this.btnZuweisen.Name = "btnZuweisen";
            this.btnZuweisen.Size = new System.Drawing.Size(125, 24);
            this.btnZuweisen.TabIndex = 0;
            this.btnZuweisen.Text = "Zuweisen >";
            this.btnZuweisen.UseVisualStyleBackColor = false;
            this.btnZuweisen.Click += new System.EventHandler(this.btnZuweisen_Click);
            // 
            // panDetailsKiss
            // 
            this.panDetailsKiss.Controls.Add(this.edtKissHausNr);
            this.panDetailsKiss.Controls.Add(this.lblKissStrasseNr);
            this.panDetailsKiss.Controls.Add(this.edtKissStrasse);
            this.panDetailsKiss.Controls.Add(this.edtKissVersNr);
            this.panDetailsKiss.Controls.Add(this.edtKissBeziehung);
            this.panDetailsKiss.Controls.Add(this.lblKissPlzOrtKanton);
            this.panDetailsKiss.Controls.Add(this.edtKissPlzOrt);
            this.panDetailsKiss.Controls.Add(this.edtKissGeburtsdatum);
            this.panDetailsKiss.Controls.Add(this.panKissNameVorname);
            this.panDetailsKiss.Controls.Add(this.lblKissBeziehung);
            this.panDetailsKiss.Controls.Add(this.lblKissGeburtsdatum);
            this.panDetailsKiss.Controls.Add(this.lblKissVersNr);
            this.panDetailsKiss.Controls.Add(this.lblKissNameVorname);
            this.panDetailsKiss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetailsKiss.Location = new System.Drawing.Point(545, 0);
            this.panDetailsKiss.Margin = new System.Windows.Forms.Padding(0);
            this.panDetailsKiss.Name = "panDetailsKiss";
            this.panDetailsKiss.Size = new System.Drawing.Size(415, 326);
            this.panDetailsKiss.TabIndex = 2;
            // 
            // edtKissHausNr
            // 
            this.edtKissHausNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKissHausNr.DataSource = this.qryPersonKiss;
            this.edtKissHausNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKissHausNr.Location = new System.Drawing.Point(362, 123);
            this.edtKissHausNr.Name = "edtKissHausNr";
            this.edtKissHausNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKissHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKissHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKissHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKissHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKissHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtKissHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKissHausNr.Properties.ReadOnly = true;
            this.edtKissHausNr.Size = new System.Drawing.Size(50, 24);
            this.edtKissHausNr.TabIndex = 10;
            // 
            // lblKissStrasseNr
            // 
            this.lblKissStrasseNr.Location = new System.Drawing.Point(3, 123);
            this.lblKissStrasseNr.Name = "lblKissStrasseNr";
            this.lblKissStrasseNr.Size = new System.Drawing.Size(100, 24);
            this.lblKissStrasseNr.TabIndex = 8;
            this.lblKissStrasseNr.Text = "Strasse, Nr.";
            // 
            // edtKissStrasse
            // 
            this.edtKissStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKissStrasse.DataSource = this.qryPersonKiss;
            this.edtKissStrasse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKissStrasse.Location = new System.Drawing.Point(109, 123);
            this.edtKissStrasse.Name = "edtKissStrasse";
            this.edtKissStrasse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKissStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKissStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKissStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtKissStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKissStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtKissStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKissStrasse.Properties.ReadOnly = true;
            this.edtKissStrasse.Size = new System.Drawing.Size(247, 24);
            this.edtKissStrasse.TabIndex = 9;
            // 
            // edtKissVersNr
            // 
            this.edtKissVersNr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKissVersNr.DataSource = this.qryPersonKiss;
            this.edtKissVersNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKissVersNr.Location = new System.Drawing.Point(109, 33);
            this.edtKissVersNr.Name = "edtKissVersNr";
            this.edtKissVersNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKissVersNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKissVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKissVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKissVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKissVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKissVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtKissVersNr.Properties.Appearance.Options.UseTextOptions = true;
            this.edtKissVersNr.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtKissVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKissVersNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKissVersNr.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtKissVersNr.Properties.DisplayFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtKissVersNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtKissVersNr.Properties.EditFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtKissVersNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtKissVersNr.Properties.Mask.EditMask = "000\\.0000\\.0000\\.00";
            this.edtKissVersNr.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtKissVersNr.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtKissVersNr.Properties.MaxLength = 13;
            this.edtKissVersNr.Properties.Precision = 0;
            this.edtKissVersNr.Properties.ReadOnly = true;
            this.edtKissVersNr.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtKissVersNr.Size = new System.Drawing.Size(303, 24);
            this.edtKissVersNr.TabIndex = 3;
            // 
            // edtKissBeziehung
            // 
            this.edtKissBeziehung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKissBeziehung.DataSource = this.qryPersonKiss;
            this.edtKissBeziehung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKissBeziehung.Location = new System.Drawing.Point(109, 93);
            this.edtKissBeziehung.Name = "edtKissBeziehung";
            this.edtKissBeziehung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKissBeziehung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKissBeziehung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKissBeziehung.Properties.Appearance.Options.UseBackColor = true;
            this.edtKissBeziehung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKissBeziehung.Properties.Appearance.Options.UseFont = true;
            this.edtKissBeziehung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKissBeziehung.Properties.ReadOnly = true;
            this.edtKissBeziehung.Size = new System.Drawing.Size(303, 24);
            this.edtKissBeziehung.TabIndex = 7;
            // 
            // lblKissPlzOrtKanton
            // 
            this.lblKissPlzOrtKanton.Location = new System.Drawing.Point(3, 153);
            this.lblKissPlzOrtKanton.Name = "lblKissPlzOrtKanton";
            this.lblKissPlzOrtKanton.Size = new System.Drawing.Size(100, 24);
            this.lblKissPlzOrtKanton.TabIndex = 11;
            this.lblKissPlzOrtKanton.Text = "PLZ, Ort, Kanton";
            // 
            // edtKissPlzOrt
            // 
            this.edtKissPlzOrt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKissPlzOrt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKissPlzOrt.DataSource = this.qryPersonKiss;
            this.edtKissPlzOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKissPlzOrt.Location = new System.Drawing.Point(109, 153);
            this.edtKissPlzOrt.Name = "edtKissPlzOrt";
            this.edtKissPlzOrt.ShowLand = false;
            this.edtKissPlzOrt.Size = new System.Drawing.Size(303, 24);
            this.edtKissPlzOrt.TabIndex = 12;
            // 
            // edtKissGeburtsdatum
            // 
            this.edtKissGeburtsdatum.DataSource = this.qryPersonKiss;
            this.edtKissGeburtsdatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKissGeburtsdatum.EditValue = null;
            this.edtKissGeburtsdatum.Location = new System.Drawing.Point(109, 63);
            this.edtKissGeburtsdatum.Name = "edtKissGeburtsdatum";
            this.edtKissGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKissGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKissGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKissGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKissGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtKissGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKissGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtKissGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtKissGeburtsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtKissGeburtsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtKissGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKissGeburtsdatum.Properties.ReadOnly = true;
            this.edtKissGeburtsdatum.Properties.ShowToday = false;
            this.edtKissGeburtsdatum.Size = new System.Drawing.Size(100, 24);
            this.edtKissGeburtsdatum.TabIndex = 5;
            // 
            // panKissNameVorname
            // 
            this.panKissNameVorname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panKissNameVorname.ColumnCount = 2;
            this.panKissNameVorname.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panKissNameVorname.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panKissNameVorname.Controls.Add(this.edtKissName, 0, 0);
            this.panKissNameVorname.Controls.Add(this.edtKissVorname, 1, 0);
            this.panKissNameVorname.Location = new System.Drawing.Point(109, 3);
            this.panKissNameVorname.Name = "panKissNameVorname";
            this.panKissNameVorname.RowCount = 1;
            this.panKissNameVorname.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panKissNameVorname.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panKissNameVorname.Size = new System.Drawing.Size(303, 24);
            this.panKissNameVorname.TabIndex = 1;
            // 
            // edtKissName
            // 
            this.edtKissName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKissName.DataSource = this.qryPersonKiss;
            this.edtKissName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKissName.Location = new System.Drawing.Point(0, 0);
            this.edtKissName.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.edtKissName.Name = "edtKissName";
            this.edtKissName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKissName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKissName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKissName.Properties.Appearance.Options.UseBackColor = true;
            this.edtKissName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKissName.Properties.Appearance.Options.UseFont = true;
            this.edtKissName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKissName.Properties.ReadOnly = true;
            this.edtKissName.Size = new System.Drawing.Size(148, 24);
            this.edtKissName.TabIndex = 0;
            // 
            // edtKissVorname
            // 
            this.edtKissVorname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKissVorname.DataSource = this.qryPersonKiss;
            this.edtKissVorname.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKissVorname.Location = new System.Drawing.Point(154, 0);
            this.edtKissVorname.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.edtKissVorname.Name = "edtKissVorname";
            this.edtKissVorname.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKissVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKissVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKissVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtKissVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKissVorname.Properties.Appearance.Options.UseFont = true;
            this.edtKissVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKissVorname.Properties.ReadOnly = true;
            this.edtKissVorname.Size = new System.Drawing.Size(149, 24);
            this.edtKissVorname.TabIndex = 1;
            // 
            // lblKissBeziehung
            // 
            this.lblKissBeziehung.Location = new System.Drawing.Point(3, 93);
            this.lblKissBeziehung.Name = "lblKissBeziehung";
            this.lblKissBeziehung.Size = new System.Drawing.Size(100, 24);
            this.lblKissBeziehung.TabIndex = 6;
            this.lblKissBeziehung.Text = "Klient/Beziehung";
            // 
            // lblKissGeburtsdatum
            // 
            this.lblKissGeburtsdatum.Location = new System.Drawing.Point(3, 63);
            this.lblKissGeburtsdatum.Name = "lblKissGeburtsdatum";
            this.lblKissGeburtsdatum.Size = new System.Drawing.Size(100, 24);
            this.lblKissGeburtsdatum.TabIndex = 4;
            this.lblKissGeburtsdatum.Text = "Geburtsdatum";
            // 
            // lblKissVersNr
            // 
            this.lblKissVersNr.Location = new System.Drawing.Point(3, 33);
            this.lblKissVersNr.Name = "lblKissVersNr";
            this.lblKissVersNr.Size = new System.Drawing.Size(100, 24);
            this.lblKissVersNr.TabIndex = 2;
            this.lblKissVersNr.Text = "Vers.-Nr.";
            // 
            // lblKissNameVorname
            // 
            this.lblKissNameVorname.Location = new System.Drawing.Point(3, 3);
            this.lblKissNameVorname.Name = "lblKissNameVorname";
            this.lblKissNameVorname.Size = new System.Drawing.Size(100, 24);
            this.lblKissNameVorname.TabIndex = 0;
            this.lblKissNameVorname.Text = "Name, Vorname";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(882, 526);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 24);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(786, 526);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(90, 24);
            this.btnAbbrechen.TabIndex = 1;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = false;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // DlgGvExcelImport
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAbbrechen;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.panMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(595, 419);
            this.Name = "DlgGvExcelImport";
            this.Text = "Gesuch-Import aus Excel-Datei";
            this.Load += new System.EventHandler(this.DlgGvExcelImport_Load);
            this.panMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonenExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPersonExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPersonenExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cedExcelOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonenKiss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPersonKiss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPersonenKiss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonenExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonenKiss)).EndInit();
            this.panBottom.ResumeLayout(false);
            this.panDetailsExcel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExcelStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelZahlweg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExcelZahlweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzOrtKanton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelBeziehung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelBeziehung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelGeburtsdatum.Properties)).EndInit();
            this.panExcelNameVorname.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExcelVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExcelBeziehung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExcelGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExcelVersNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameVorname)).EndInit();
            this.panCenter.ResumeLayout(false);
            this.grpKriterium.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKriteriumOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriteriumPlz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriteriumStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriteriumVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriteriumVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriteriumName.Properties)).EndInit();
            this.panDetailsKiss.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKissHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKissStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKissStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKissVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKissBeziehung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKissPlzOrtKanton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKissGeburtsdatum.Properties)).EndInit();
            this.panKissNameVorname.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKissName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKissVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKissBeziehung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKissGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKissVersNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKissNameVorname)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panMain;
        private Gui.KissGrid grdPersonenExcel;
        private Gui.KissGrid grdPersonenKiss;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPersonenExcel;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPersonenKiss;
        private Gui.KissLabel lblPersonenExcel;
        private Gui.KissLabel lblPersonenKiss;
        private System.Windows.Forms.TableLayoutPanel panBottom;
        private System.Windows.Forms.Panel panDetailsExcel;
        private System.Windows.Forms.Panel panCenter;
        private System.Windows.Forms.Panel panDetailsKiss;
        private DB.SqlQuery qryPersonExcel;
        private DB.SqlQuery qryPersonKiss;
        private DevExpress.XtraGrid.Columns.GridColumn colExcelName;
        private DevExpress.XtraGrid.Columns.GridColumn colExcelVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colExcelVersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colExcelGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colExcelBeziehung;
        private DevExpress.XtraGrid.Columns.GridColumn colExcelOk;
        private DevExpress.XtraGrid.Columns.GridColumn colKissName;
        private DevExpress.XtraGrid.Columns.GridColumn colKissVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colKissVersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colKissGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colKissBeziehung;
        private Gui.KissLabel lblNameVorname;
        private Gui.KissTextEdit edtExcelName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit cedExcelOk;
        private Gui.KissTextEdit edtExcelVorname;
        private Gui.KissButton btnZuweisen;
        private Gui.KissButton btnNeuAnlegen;
        private Gui.KissGroupBox grpKriterium;
        private Gui.KissCheckEdit edtKriteriumName;
        private Gui.KissButton btnSuche;
        private Gui.KissCheckEdit edtKriteriumOrt;
        private Gui.KissCheckEdit edtKriteriumPlz;
        private Gui.KissCheckEdit edtKriteriumStrasse;
        private Gui.KissCheckEdit edtKriteriumVersNr;
        private Gui.KissCheckEdit edtKriteriumVorname;
        private Gui.KissLabel lblExcelBeziehung;
        private Gui.KissLabel lblExcelGeburtsdatum;
        private Gui.KissLabel lblExcelVersNr;
        private System.Windows.Forms.TableLayoutPanel panExcelNameVorname;
        private Gui.KissDateEdit edtExcelGeburtsdatum;
        private Gui.KissLookUpEdit edtExcelBeziehung;
        private Gui.KissMemoEdit edtExcelZahlweg;
        private Gui.KissLabel lblExcelZahlweg;
        private Gui.KissLabel lblPlzOrtKanton;
        private Common.KissPLZOrt edtExcelPlzOrt;
        private Gui.KissLabel lblKissPlzOrtKanton;
        private Common.KissPLZOrt edtKissPlzOrt;
        private Gui.KissDateEdit edtKissGeburtsdatum;
        private System.Windows.Forms.TableLayoutPanel panKissNameVorname;
        private Gui.KissTextEdit edtKissName;
        private Gui.KissTextEdit edtKissVorname;
        private Gui.KissLabel lblKissBeziehung;
        private Gui.KissLabel lblKissGeburtsdatum;
        private Gui.KissLabel lblKissVersNr;
        private Gui.KissLabel lblKissNameVorname;
        private Gui.KissTextEdit edtKissBeziehung;
        private Gui.KissVersichertenNrEdit edtExcelVersNr;
        private Gui.KissButton btnOk;
        private Gui.KissVersichertenNrEdit edtKissVersNr;
        private Gui.KissButton btnAbbrechen;
        private Gui.KissTextEdit edtExcelHausNr;
        private Gui.KissLabel lblExcelStrasseNr;
        private Gui.KissTextEdit edtExcelStrasse;
        private Gui.KissTextEdit edtKissHausNr;
        private Gui.KissLabel lblKissStrasseNr;
        private Gui.KissTextEdit edtKissStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colNeuBaPersonID;
    }
}