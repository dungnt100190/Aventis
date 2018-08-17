namespace KiSS4.Schnittstellen.Abacus.ASCII
{
    partial class CtlAbaFakturierung
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAbaFakturierung));
            this.grdFakturierung = new KiSS4.Gui.KissGrid();
            this.grvFakturierung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDoExport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDoExport = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebitorNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlPositionen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusInsUpd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpEinstellungen = new KiSS4.Gui.KissGroupBox();
            this.edtUserPassword = new KiSS4.Gui.KissTextEdit();
            this.edtUserName = new KiSS4.Gui.KissTextEdit();
            this.edtSelectMandant = new KiSS4.Gui.KissLookUpEdit();
            this.qryLoadMandanten = new KiSS4.DB.SqlQuery(this.components);
            this.lblUserPassword = new KiSS4.Gui.KissLabel();
            this.lblUserName = new KiSS4.Gui.KissLabel();
            this.lblSelectMandant = new KiSS4.Gui.KissLabel();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.btnDatenExport = new KiSS4.Gui.KissButton();
            this.btnLoadRechnungen = new KiSS4.Gui.KissButton();
            this.btnSelectAll = new KiSS4.Gui.KissButton();
            this.btnDeselectAll = new KiSS4.Gui.KissButton();
            this.btnInvertSelection = new KiSS4.Gui.KissButton();
            this.grpLoadData = new KiSS4.Gui.KissGroupBox();
            this.edtFakturaCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblFaktura = new KiSS4.Gui.KissLabel();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.grpGrid = new KiSS4.Gui.KissGroupBox();
            this.lblSelectedRowsCount = new KiSS4.Gui.KissLabel();
            this.grpExport = new KiSS4.Gui.KissGroupBox();
            this.edtKSSAusfuehren = new KiSS4.Gui.KissCheckEdit();
            this.pgbExport = new System.Windows.Forms.ProgressBar();
            this.lblStatusBar = new KiSS4.Gui.KissLabel();
            this.panBottom = new System.Windows.Forms.Panel();
            this.qryFakturierung = new KiSS4.DB.SqlQuery(this.components);
            this.qryGetKlientenstammdaten = new KiSS4.DB.SqlQuery(this.components);
            this.bgwFakturierungExport = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.grdFakturierung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFakturierung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDoExport)).BeginInit();
            this.grpEinstellungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelectMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelectMandant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLoadMandanten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectMandant)).BeginInit();
            this.grpLoadData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtFakturaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFakturaCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaktura)).BeginInit();
            this.grpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectedRowsCount)).BeginInit();
            this.grpExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKSSAusfuehren.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusBar)).BeginInit();
            this.panBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryFakturierung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGetKlientenstammdaten)).BeginInit();
            this.SuspendLayout();
            // 
            // grdFakturierung
            // 
            this.grdFakturierung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.grdFakturierung.EmbeddedNavigator.Name = "";
            this.grdFakturierung.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdFakturierung.Location = new System.Drawing.Point(6, 51);
            this.grdFakturierung.MainView = this.grvFakturierung;
            this.grdFakturierung.Name = "grdFakturierung";
            this.grdFakturierung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repDoExport});
            this.grdFakturierung.Size = new System.Drawing.Size(898, 362);
            this.grdFakturierung.TabIndex = 4;
            this.grdFakturierung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFakturierung});
            // 
            // grvFakturierung
            // 
            this.grvFakturierung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFakturierung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFakturierung.Appearance.Empty.Options.UseBackColor = true;
            this.grvFakturierung.Appearance.Empty.Options.UseFont = true;
            this.grvFakturierung.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFakturierung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFakturierung.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFakturierung.Appearance.EvenRow.Options.UseFont = true;
            this.grvFakturierung.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFakturierung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFakturierung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvFakturierung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFakturierung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFakturierung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFakturierung.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFakturierung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFakturierung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFakturierung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFakturierung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFakturierung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFakturierung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFakturierung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFakturierung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvFakturierung.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvFakturierung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFakturierung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFakturierung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFakturierung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFakturierung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFakturierung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFakturierung.Appearance.GroupRow.Options.UseFont = true;
            this.grvFakturierung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFakturierung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFakturierung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFakturierung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFakturierung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFakturierung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFakturierung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFakturierung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFakturierung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFakturierung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFakturierung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFakturierung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFakturierung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFakturierung.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvFakturierung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFakturierung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFakturierung.Appearance.OddRow.Options.UseFont = true;
            this.grvFakturierung.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFakturierung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFakturierung.Appearance.Row.Options.UseBackColor = true;
            this.grvFakturierung.Appearance.Row.Options.UseFont = true;
            this.grvFakturierung.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFakturierung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFakturierung.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFakturierung.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFakturierung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFakturierung.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFakturierung.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvFakturierung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFakturierung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFakturierung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDoExport,
            this.colName,
            this.colVorname,
            this.colDebitorNr,
            this.colAnzahlPositionen,
            this.colDatumVon,
            this.colDatumBis,
            this.colStatusInsUpd});
            this.grvFakturierung.GridControl = this.grdFakturierung;
            this.grvFakturierung.Name = "grvFakturierung";
            this.grvFakturierung.OptionsCustomization.AllowFilter = false;
            this.grvFakturierung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFakturierung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFakturierung.OptionsView.ColumnAutoWidth = false;
            this.grvFakturierung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFakturierung.OptionsView.ShowGroupPanel = false;
            this.grvFakturierung.LostFocus += new System.EventHandler(this.grvKlientenStammdaten_LostFocus);
            // 
            // colDoExport
            // 
            this.colDoExport.Caption = "Export";
            this.colDoExport.ColumnEdit = this.repDoExport;
            this.colDoExport.FieldName = "DoExport";
            this.colDoExport.Name = "colDoExport";
            this.colDoExport.Visible = true;
            this.colDoExport.VisibleIndex = 0;
            this.colDoExport.Width = 60;
            // 
            // repDoExport
            // 
            this.repDoExport.AutoHeight = false;
            this.repDoExport.Name = "repDoExport";
            // 
            // colName
            // 
            this.colName.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colName.AppearanceCell.Options.UseBackColor = true;
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 120;
            // 
            // colVorname
            // 
            this.colVorname.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colVorname.AppearanceCell.Options.UseBackColor = true;
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Vorname";
            this.colVorname.Name = "colVorname";
            this.colVorname.OptionsColumn.AllowEdit = false;
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 2;
            this.colVorname.Width = 120;
            // 
            // colDebitorNr
            // 
            this.colDebitorNr.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDebitorNr.AppearanceCell.Options.UseBackColor = true;
            this.colDebitorNr.Caption = "Debitornummer";
            this.colDebitorNr.FieldName = "DebitorNr";
            this.colDebitorNr.Name = "colDebitorNr";
            this.colDebitorNr.OptionsColumn.AllowEdit = false;
            this.colDebitorNr.Visible = true;
            this.colDebitorNr.VisibleIndex = 3;
            this.colDebitorNr.Width = 100;
            // 
            // colAnzahlPositionen
            // 
            this.colAnzahlPositionen.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colAnzahlPositionen.AppearanceCell.Options.UseBackColor = true;
            this.colAnzahlPositionen.Caption = "Anzahl Positionen";
            this.colAnzahlPositionen.FieldName = "AnzahlPositionen";
            this.colAnzahlPositionen.Name = "colAnzahlPositionen";
            this.colAnzahlPositionen.OptionsColumn.AllowEdit = false;
            this.colAnzahlPositionen.Visible = true;
            this.colAnzahlPositionen.VisibleIndex = 4;
            this.colAnzahlPositionen.Width = 120;
            // 
            // colDatumVon
            // 
            this.colDatumVon.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDatumVon.AppearanceCell.Options.UseBackColor = true;
            this.colDatumVon.Caption = "Datum von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.OptionsColumn.AllowEdit = false;
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 5;
            this.colDatumVon.Width = 85;
            // 
            // colDatumBis
            // 
            this.colDatumBis.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDatumBis.AppearanceCell.Options.UseBackColor = true;
            this.colDatumBis.Caption = "Datum bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.OptionsColumn.AllowEdit = false;
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 6;
            this.colDatumBis.Width = 85;
            // 
            // colStatusInsUpd
            // 
            this.colStatusInsUpd.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colStatusInsUpd.AppearanceCell.Options.UseBackColor = true;
            this.colStatusInsUpd.Caption = "Status";
            this.colStatusInsUpd.FieldName = "StatusInsUpd";
            this.colStatusInsUpd.Name = "colStatusInsUpd";
            this.colStatusInsUpd.OptionsColumn.AllowEdit = false;
            this.colStatusInsUpd.Visible = true;
            this.colStatusInsUpd.VisibleIndex = 7;
            this.colStatusInsUpd.Width = 200;
            // 
            // grpEinstellungen
            // 
            this.grpEinstellungen.Controls.Add(this.edtUserPassword);
            this.grpEinstellungen.Controls.Add(this.edtUserName);
            this.grpEinstellungen.Controls.Add(this.edtSelectMandant);
            this.grpEinstellungen.Controls.Add(this.lblUserPassword);
            this.grpEinstellungen.Controls.Add(this.lblUserName);
            this.grpEinstellungen.Controls.Add(this.lblSelectMandant);
            this.grpEinstellungen.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEinstellungen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpEinstellungen.Location = new System.Drawing.Point(0, 0);
            this.grpEinstellungen.Name = "grpEinstellungen";
            this.grpEinstellungen.Size = new System.Drawing.Size(913, 52);
            this.grpEinstellungen.TabIndex = 0;
            this.grpEinstellungen.TabStop = false;
            this.grpEinstellungen.Text = "1. Mandant wählen und Abacus-Benutzerinformationen angeben ";
            this.grpEinstellungen.UseCompatibleTextRendering = true;
            // 
            // edtUserPassword
            // 
            this.edtUserPassword.Location = new System.Drawing.Point(557, 20);
            this.edtUserPassword.Name = "edtUserPassword";
            this.edtUserPassword.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserPassword.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserPassword.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserPassword.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserPassword.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserPassword.Properties.Appearance.Options.UseFont = true;
            this.edtUserPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUserPassword.Properties.PasswordChar = '*';
            this.edtUserPassword.Size = new System.Drawing.Size(125, 24);
            this.edtUserPassword.TabIndex = 5;
            // 
            // edtUserName
            // 
            this.edtUserName.Location = new System.Drawing.Point(360, 20);
            this.edtUserName.Name = "edtUserName";
            this.edtUserName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserName.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserName.Properties.Appearance.Options.UseFont = true;
            this.edtUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUserName.Size = new System.Drawing.Size(125, 24);
            this.edtUserName.TabIndex = 3;
            // 
            // edtSelectMandant
            // 
            this.edtSelectMandant.Location = new System.Drawing.Point(72, 20);
            this.edtSelectMandant.Name = "edtSelectMandant";
            this.edtSelectMandant.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSelectMandant.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSelectMandant.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSelectMandant.Properties.Appearance.Options.UseBackColor = true;
            this.edtSelectMandant.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSelectMandant.Properties.Appearance.Options.UseFont = true;
            this.edtSelectMandant.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSelectMandant.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSelectMandant.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSelectMandant.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSelectMandant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSelectMandant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSelectMandant.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSelectMandant.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtSelectMandant.Properties.DataSource = this.qryLoadMandanten;
            this.edtSelectMandant.Properties.DisplayMember = "Text";
            this.edtSelectMandant.Properties.NullText = "";
            this.edtSelectMandant.Properties.ShowFooter = false;
            this.edtSelectMandant.Properties.ShowHeader = false;
            this.edtSelectMandant.Properties.ValueMember = "Code";
            this.edtSelectMandant.Size = new System.Drawing.Size(216, 24);
            this.edtSelectMandant.TabIndex = 1;
            this.edtSelectMandant.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.edtSelectMandant_EditValueChanging);
            // 
            // qryLoadMandanten
            // 
            this.qryLoadMandanten.HostControl = this;
            this.qryLoadMandanten.IsIdentityInsert = false;
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.Location = new System.Drawing.Point(491, 20);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(60, 24);
            this.lblUserPassword.TabIndex = 4;
            this.lblUserPassword.Text = "Passwort";
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(294, 20);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 24);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Benutzer";
            // 
            // lblSelectMandant
            // 
            this.lblSelectMandant.Location = new System.Drawing.Point(6, 20);
            this.lblSelectMandant.Name = "lblSelectMandant";
            this.lblSelectMandant.Size = new System.Drawing.Size(60, 24);
            this.lblSelectMandant.TabIndex = 0;
            this.lblSelectMandant.Text = "Mandant";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(814, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "A&bbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDatenExport
            // 
            this.btnDatenExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatenExport.Location = new System.Drawing.Point(6, 20);
            this.btnDatenExport.Name = "btnDatenExport";
            this.btnDatenExport.Size = new System.Drawing.Size(129, 24);
            this.btnDatenExport.TabIndex = 0;
            this.btnDatenExport.Text = "&Daten exportieren...";
            this.btnDatenExport.UseCompatibleTextRendering = true;
            this.btnDatenExport.UseVisualStyleBackColor = false;
            this.btnDatenExport.Click += new System.EventHandler(this.btnDatenExport_Click);
            // 
            // btnLoadRechnungen
            // 
            this.btnLoadRechnungen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadRechnungen.Location = new System.Drawing.Point(360, 20);
            this.btnLoadRechnungen.Name = "btnLoadRechnungen";
            this.btnLoadRechnungen.Size = new System.Drawing.Size(129, 24);
            this.btnLoadRechnungen.TabIndex = 2;
            this.btnLoadRechnungen.Text = "&KiSS Daten laden";
            this.btnLoadRechnungen.UseCompatibleTextRendering = true;
            this.btnLoadRechnungen.UseVisualStyleBackColor = false;
            this.btnLoadRechnungen.Click += new System.EventHandler(this.btnLoadRechnungen_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.IconID = 74;
            this.btnSelectAll.Location = new System.Drawing.Point(6, 20);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(24, 24);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.UseCompatibleTextRendering = true;
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeselectAll.IconID = 75;
            this.btnDeselectAll.Location = new System.Drawing.Point(36, 20);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(24, 24);
            this.btnDeselectAll.TabIndex = 1;
            this.btnDeselectAll.UseCompatibleTextRendering = true;
            this.btnDeselectAll.UseVisualStyleBackColor = false;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // btnInvertSelection
            // 
            this.btnInvertSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvertSelection.IconID = 76;
            this.btnInvertSelection.Location = new System.Drawing.Point(66, 20);
            this.btnInvertSelection.Name = "btnInvertSelection";
            this.btnInvertSelection.Size = new System.Drawing.Size(24, 24);
            this.btnInvertSelection.TabIndex = 2;
            this.btnInvertSelection.UseCompatibleTextRendering = true;
            this.btnInvertSelection.UseVisualStyleBackColor = false;
            this.btnInvertSelection.Click += new System.EventHandler(this.btnInvertSelection_Click);
            // 
            // grpLoadData
            // 
            this.grpLoadData.Controls.Add(this.edtFakturaCode);
            this.grpLoadData.Controls.Add(this.lblFaktura);
            this.grpLoadData.Controls.Add(this.ctlGotoFall);
            this.grpLoadData.Controls.Add(this.btnLoadRechnungen);
            this.grpLoadData.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLoadData.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpLoadData.Location = new System.Drawing.Point(0, 52);
            this.grpLoadData.Name = "grpLoadData";
            this.grpLoadData.Size = new System.Drawing.Size(913, 52);
            this.grpLoadData.TabIndex = 1;
            this.grpLoadData.TabStop = false;
            this.grpLoadData.Text = "2. Daten laden";
            // 
            // edtFakturaCode
            // 
            this.edtFakturaCode.Location = new System.Drawing.Point(72, 20);
            this.edtFakturaCode.LOVName = "BDELeistungsartAuswFaktura";
            this.edtFakturaCode.Name = "edtFakturaCode";
            this.edtFakturaCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFakturaCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFakturaCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFakturaCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtFakturaCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFakturaCode.Properties.Appearance.Options.UseFont = true;
            this.edtFakturaCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFakturaCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFakturaCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFakturaCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFakturaCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtFakturaCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtFakturaCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFakturaCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtFakturaCode.Properties.DataSource = this.qryLoadMandanten;
            this.edtFakturaCode.Properties.DisplayMember = "Text";
            this.edtFakturaCode.Properties.NullText = "";
            this.edtFakturaCode.Properties.ShowFooter = false;
            this.edtFakturaCode.Properties.ShowHeader = false;
            this.edtFakturaCode.Properties.ValueMember = "Code";
            this.edtFakturaCode.Size = new System.Drawing.Size(216, 24);
            this.edtFakturaCode.TabIndex = 1;
            // 
            // lblFaktura
            // 
            this.lblFaktura.Location = new System.Drawing.Point(6, 20);
            this.lblFaktura.Name = "lblFaktura";
            this.lblFaktura.Size = new System.Drawing.Size(60, 24);
            this.lblFaktura.TabIndex = 0;
            this.lblFaktura.Text = "Faktura";
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlGotoFall.Location = new System.Drawing.Point(694, 20);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(210, 24);
            this.ctlGotoFall.TabIndex = 3;
            // 
            // grpGrid
            // 
            this.grpGrid.Controls.Add(this.lblSelectedRowsCount);
            this.grpGrid.Controls.Add(this.grdFakturierung);
            this.grpGrid.Controls.Add(this.btnSelectAll);
            this.grpGrid.Controls.Add(this.btnDeselectAll);
            this.grpGrid.Controls.Add(this.btnInvertSelection);
            this.grpGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGrid.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpGrid.Location = new System.Drawing.Point(0, 104);
            this.grpGrid.Name = "grpGrid";
            this.grpGrid.Size = new System.Drawing.Size(913, 419);
            this.grpGrid.TabIndex = 2;
            this.grpGrid.TabStop = false;
            this.grpGrid.Text = "3. Zu exportierende Rechnungen auswählen";
            // 
            // lblSelectedRowsCount
            // 
            this.lblSelectedRowsCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedRowsCount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSelectedRowsCount.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSelectedRowsCount.Location = new System.Drawing.Point(571, 20);
            this.lblSelectedRowsCount.Name = "lblSelectedRowsCount";
            this.lblSelectedRowsCount.Size = new System.Drawing.Size(330, 24);
            this.lblSelectedRowsCount.TabIndex = 3;
            this.lblSelectedRowsCount.Text = "<Sel> von <Count> Einträgen ausgewählt";
            this.lblSelectedRowsCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpExport
            // 
            this.grpExport.Controls.Add(this.edtKSSAusfuehren);
            this.grpExport.Controls.Add(this.btnCancel);
            this.grpExport.Controls.Add(this.btnDatenExport);
            this.grpExport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpExport.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpExport.Location = new System.Drawing.Point(0, 523);
            this.grpExport.Name = "grpExport";
            this.grpExport.Size = new System.Drawing.Size(913, 55);
            this.grpExport.TabIndex = 3;
            this.grpExport.TabStop = false;
            this.grpExport.Text = "4. Klientenstammdaten- und Fakturierung-Export ausführen";
            // 
            // edtKSSAusfuehren
            // 
            this.edtKSSAusfuehren.EditValue = true;
            this.edtKSSAusfuehren.Location = new System.Drawing.Point(150, 24);
            this.edtKSSAusfuehren.Name = "edtKSSAusfuehren";
            this.edtKSSAusfuehren.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKSSAusfuehren.Properties.Appearance.Options.UseBackColor = true;
            this.edtKSSAusfuehren.Properties.Caption = "Klientenstammdaten-Export ausführen";
            this.edtKSSAusfuehren.Size = new System.Drawing.Size(244, 19);
            this.edtKSSAusfuehren.TabIndex = 1;
            // 
            // pgbExport
            // 
            this.pgbExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.pgbExport.Location = new System.Drawing.Point(704, 0);
            this.pgbExport.Name = "pgbExport";
            this.pgbExport.Size = new System.Drawing.Size(209, 18);
            this.pgbExport.TabIndex = 1;
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusBar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStatusBar.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblStatusBar.Location = new System.Drawing.Point(0, 0);
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(704, 18);
            this.lblStatusBar.TabIndex = 0;
            this.lblStatusBar.Text = "Status: -";
            this.lblStatusBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatusBar.UseCompatibleTextRendering = true;
            // 
            // panBottom
            // 
            this.panBottom.Controls.Add(this.lblStatusBar);
            this.panBottom.Controls.Add(this.pgbExport);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 578);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(913, 18);
            this.panBottom.TabIndex = 4;
            // 
            // qryFakturierung
            // 
            this.qryFakturierung.FillTimeOut = 120;
            this.qryFakturierung.HostControl = this;
            this.qryFakturierung.IsIdentityInsert = false;
            this.qryFakturierung.SelectStatement = resources.GetString("qryFakturierung.SelectStatement");
            this.qryFakturierung.AfterFill += new System.EventHandler(this.qryFakturierung_AfterFill);
            this.qryFakturierung.PositionChanged += new System.EventHandler(this.qryFakturierung_PositionChanged);
            // 
            // qryGetKlientenstammdaten
            // 
            this.qryGetKlientenstammdaten.HostControl = this;
            this.qryGetKlientenstammdaten.IsIdentityInsert = false;
            this.qryGetKlientenstammdaten.SelectStatement = "EXEC dbo.spABAGetKlientenstammdatenData {0}, {1}, {2};";
            // 
            // bgwFakturierungExport
            // 
            this.bgwFakturierungExport.WorkerReportsProgress = true;
            this.bgwFakturierungExport.WorkerSupportsCancellation = true;
            this.bgwFakturierungExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FakturierungExportWorker_DoWork);
            this.bgwFakturierungExport.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_ProgressChanged);
            this.bgwFakturierungExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FakturierungExportWorker_RunWorkerCompleted);
            // 
            // CtlAbaFakturierung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpGrid);
            this.Controls.Add(this.grpExport);
            this.Controls.Add(this.grpLoadData);
            this.Controls.Add(this.grpEinstellungen);
            this.Controls.Add(this.panBottom);
            this.Name = "CtlAbaFakturierung";
            this.Size = new System.Drawing.Size(913, 596);
            this.Load += new System.EventHandler(this.CtlAbaFakturierung_Load);
            this.Leave += new System.EventHandler(this.CtlAbaFakturierung_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.grdFakturierung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFakturierung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDoExport)).EndInit();
            this.grpEinstellungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtUserPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelectMandant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelectMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLoadMandanten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectMandant)).EndInit();
            this.grpLoadData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtFakturaCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFakturaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaktura)).EndInit();
            this.grpGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectedRowsCount)).EndInit();
            this.grpExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKSSAusfuehren.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusBar)).EndInit();
            this.panBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryFakturierung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGetKlientenstammdaten)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissGrid grdFakturierung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFakturierung;
        private DevExpress.XtraGrid.Columns.GridColumn colDoExport;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colDebitorNr;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusInsUpd;
        private KiSS4.Gui.KissGroupBox grpEinstellungen;
        private KiSS4.Gui.KissButton btnDatenExport;
        private KiSS4.Gui.KissButton btnLoadRechnungen;
        private KiSS4.Gui.KissButton btnCancel;
        private KiSS4.Gui.KissButton btnInvertSelection;
        private KiSS4.Gui.KissButton btnDeselectAll;
        private KiSS4.Gui.KissButton btnSelectAll;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repDoExport;
        private KiSS4.Gui.KissLookUpEdit edtSelectMandant;
        private KiSS4.Gui.KissGroupBox grpLoadData;
        private KiSS4.Gui.KissGroupBox grpGrid;
        private KiSS4.Gui.KissLabel lblStatusBar;
        private KiSS4.Gui.KissGroupBox grpExport;
        private KiSS4.DB.SqlQuery qryLoadMandanten;
        private System.Windows.Forms.ProgressBar pgbExport;
        private KiSS4.Gui.KissLabel lblSelectedRowsCount;
        private KiSS4.Gui.KissTextEdit edtUserName;
        private KiSS4.Gui.KissLabel lblUserPassword;
        private KiSS4.Gui.KissLabel lblUserName;
        private KiSS4.Gui.KissLabel lblSelectMandant;
        private KiSS4.Gui.KissTextEdit edtUserPassword;
        private System.Windows.Forms.Panel panBottom;
        private KiSS4.Common.CtlGotoFall ctlGotoFall;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlPositionen;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DB.SqlQuery qryFakturierung;
        private DB.SqlQuery qryGetKlientenstammdaten;
        private System.ComponentModel.BackgroundWorker bgwFakturierungExport;
        private Gui.KissCheckEdit edtKSSAusfuehren;
        private Gui.KissLookUpEdit edtFakturaCode;
        private Gui.KissLabel lblFaktura;
    }
}
