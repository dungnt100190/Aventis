namespace KiSS4.Fibu
{
    partial class CtlFibuDTAZahlungsLauf
    {
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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFibuDTAZahlungsLauf));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryDTABuchungErwartung = new KiSS4.DB.SqlQuery(this.components);
            this.qryFbDTAJournal = new KiSS4.DB.SqlQuery(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAlleEntfernen = new KiSS4.Gui.KissButton();
            this.btnOK = new KiSS4.Gui.KissButton();
            this.grdErwartung = new KiSS4.Gui.KissGrid();
            this.gridViewFields = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDTAZugang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontoName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeguenstigter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungsgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUebermitteln = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboEZugang = new KiSS4.Gui.KissLookUpEdit();
            this.ValutaDatumBis = new KiSS4.Gui.KissDateEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.btnSuchen = new KiSS4.Gui.KissButton();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryDTABuchungErwartung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbDTAJournal)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdErwartung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEZugang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEZugang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValutaDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // qryDTABuchungErwartung
            // 
            this.qryDTABuchungErwartung.CanUpdate = true;
            this.qryDTABuchungErwartung.FillTimeOut = 120;
            this.qryDTABuchungErwartung.HostControl = this;
            this.qryDTABuchungErwartung.IsIdentityInsert = false;
            this.qryDTABuchungErwartung.TableName = "FbBuchung";
            // 
            // qryFbDTAJournal
            // 
            this.qryFbDTAJournal.CanInsert = true;
            this.qryFbDTAJournal.CanUpdate = true;
            this.qryFbDTAJournal.FillTimeOut = 120;
            this.qryFbDTAJournal.HostControl = this;
            this.qryFbDTAJournal.IsIdentityInsert = false;
            this.qryFbDTAJournal.TableName = "FbDTAJournal";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAlleEntfernen);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 505);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(825, 30);
            this.panel2.TabIndex = 8;
            // 
            // btnAlleEntfernen
            // 
            this.btnAlleEntfernen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlleEntfernen.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAlleEntfernen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlleEntfernen.Location = new System.Drawing.Point(440, 4);
            this.btnAlleEntfernen.Name = "btnAlleEntfernen";
            this.btnAlleEntfernen.Size = new System.Drawing.Size(184, 24);
            this.btnAlleEntfernen.TabIndex = 4;
            this.btnAlleEntfernen.Text = "Alle entfernen";
            this.btnAlleEntfernen.UseVisualStyleBackColor = false;
            this.btnAlleEntfernen.Click += new System.EventHandler(this.btnAlleEntfernen_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(631, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(184, 24);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Zahlungsauftrag generieren";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // grdErwartung
            // 
            this.grdErwartung.DataSource = this.qryDTABuchungErwartung;
            this.grdErwartung.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdErwartung.EmbeddedNavigator.Name = "";
            this.grdErwartung.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdErwartung.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdErwartung.Location = new System.Drawing.Point(0, 30);
            this.grdErwartung.MainView = this.gridViewFields;
            this.grdErwartung.Name = "grdErwartung";
            this.grdErwartung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdErwartung.Size = new System.Drawing.Size(825, 475);
            this.grdErwartung.TabIndex = 14;
            this.grdErwartung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFields});
            this.grdErwartung.Load += new System.EventHandler(this.grdErwartung_Load);
            this.grdErwartung.Click += new System.EventHandler(this.grdErwartung_Click);
            // 
            // gridViewFields
            // 
            this.gridViewFields.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridViewFields.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewFields.Appearance.Empty.Options.UseBackColor = true;
            this.gridViewFields.Appearance.Empty.Options.UseFont = true;
            this.gridViewFields.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridViewFields.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewFields.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewFields.Appearance.EvenRow.Options.UseFont = true;
            this.gridViewFields.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.gridViewFields.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewFields.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridViewFields.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewFields.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewFields.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewFields.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridViewFields.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewFields.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewFields.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewFields.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewFields.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewFields.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridViewFields.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridViewFields.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridViewFields.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridViewFields.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridViewFields.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridViewFields.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridViewFields.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridViewFields.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridViewFields.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridViewFields.Appearance.GroupRow.Options.UseFont = true;
            this.gridViewFields.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridViewFields.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridViewFields.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridViewFields.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridViewFields.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridViewFields.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridViewFields.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewFields.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridViewFields.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewFields.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridViewFields.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridViewFields.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridViewFields.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewFields.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gridViewFields.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridViewFields.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridViewFields.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewFields.Appearance.OddRow.Options.UseBackColor = true;
            this.gridViewFields.Appearance.OddRow.Options.UseFont = true;
            this.gridViewFields.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.gridViewFields.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewFields.Appearance.Row.Options.UseBackColor = true;
            this.gridViewFields.Appearance.Row.Options.UseFont = true;
            this.gridViewFields.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridViewFields.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewFields.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewFields.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewFields.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewFields.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewFields.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.gridViewFields.Appearance.VertLine.Options.UseBackColor = true;
            this.gridViewFields.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridViewFields.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDTAZugang,
            this.colValuta,
            this.colMandant,
            this.colKontoName,
            this.colBetrag,
            this.colKonto,
            this.colBelegNr,
            this.colBeguenstigter,
            this.colZahlungsgrund,
            this.colStatus,
            this.colUebermitteln});
            this.gridViewFields.GridControl = this.grdErwartung;
            this.gridViewFields.Name = "gridViewFields";
            this.gridViewFields.OptionsCustomization.AllowFilter = false;
            this.gridViewFields.OptionsCustomization.AllowGroup = false;
            this.gridViewFields.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridViewFields.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewFields.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewFields.OptionsView.ColumnAutoWidth = false;
            this.gridViewFields.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewFields.OptionsView.ShowGroupPanel = false;
            // 
            // colDTAZugang
            // 
            this.colDTAZugang.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDTAZugang.AppearanceCell.Options.UseBackColor = true;
            this.colDTAZugang.Caption = "EBanking Konto";
            this.colDTAZugang.FieldName = "DTAZugang";
            this.colDTAZugang.Name = "colDTAZugang";
            this.colDTAZugang.OptionsColumn.AllowEdit = false;
            this.colDTAZugang.OptionsColumn.ReadOnly = true;
            this.colDTAZugang.Visible = true;
            this.colDTAZugang.VisibleIndex = 0;
            this.colDTAZugang.Width = 115;
            // 
            // colValuta
            // 
            this.colValuta.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colValuta.AppearanceCell.Options.UseBackColor = true;
            this.colValuta.Caption = "Valuta Datum";
            this.colValuta.FieldName = "ValutaDatum";
            this.colValuta.Name = "colValuta";
            this.colValuta.OptionsColumn.AllowEdit = false;
            this.colValuta.OptionsColumn.ReadOnly = true;
            this.colValuta.Visible = true;
            this.colValuta.VisibleIndex = 1;
            this.colValuta.Width = 83;
            // 
            // colMandant
            // 
            this.colMandant.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colMandant.AppearanceCell.Options.UseBackColor = true;
            this.colMandant.Caption = "Mandant";
            this.colMandant.DisplayFormat.FormatString = "N0";
            this.colMandant.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.OptionsColumn.AllowEdit = false;
            this.colMandant.OptionsColumn.ReadOnly = true;
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 2;
            this.colMandant.Width = 81;
            // 
            // colKontoName
            // 
            this.colKontoName.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKontoName.AppearanceCell.Options.UseBackColor = true;
            this.colKontoName.Caption = "Konto Name";
            this.colKontoName.FieldName = "KontoName";
            this.colKontoName.Name = "colKontoName";
            this.colKontoName.OptionsColumn.AllowEdit = false;
            this.colKontoName.OptionsColumn.ReadOnly = true;
            this.colKontoName.Visible = true;
            this.colKontoName.VisibleIndex = 4;
            this.colKontoName.Width = 88;
            // 
            // colBetrag
            // 
            this.colBetrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBetrag.AppearanceCell.Options.UseBackColor = true;
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "c2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.OptionsColumn.ReadOnly = true;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 6;
            // 
            // colKonto
            // 
            this.colKonto.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKonto.AppearanceCell.Options.UseBackColor = true;
            this.colKonto.Caption = "Konto Nr";
            this.colKonto.FieldName = "KontoNr";
            this.colKonto.Name = "colKonto";
            this.colKonto.OptionsColumn.AllowEdit = false;
            this.colKonto.OptionsColumn.ReadOnly = true;
            this.colKonto.Visible = true;
            this.colKonto.VisibleIndex = 3;
            // 
            // colBelegNr
            // 
            this.colBelegNr.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBelegNr.AppearanceCell.Options.UseBackColor = true;
            this.colBelegNr.Caption = "Beleg Nr";
            this.colBelegNr.FieldName = "BelegNr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 5;
            // 
            // colBeguenstigter
            // 
            this.colBeguenstigter.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBeguenstigter.AppearanceCell.Options.UseBackColor = true;
            this.colBeguenstigter.Caption = "Beguenstigter";
            this.colBeguenstigter.FieldName = "Kreditor";
            this.colBeguenstigter.Name = "colBeguenstigter";
            this.colBeguenstigter.OptionsColumn.AllowEdit = false;
            this.colBeguenstigter.OptionsColumn.ReadOnly = true;
            this.colBeguenstigter.Visible = true;
            this.colBeguenstigter.VisibleIndex = 7;
            this.colBeguenstigter.Width = 95;
            // 
            // colZahlungsgrund
            // 
            this.colZahlungsgrund.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colZahlungsgrund.AppearanceCell.Options.UseBackColor = true;
            this.colZahlungsgrund.Caption = "Zahlungsgrund";
            this.colZahlungsgrund.FieldName = "Zahlungsgrund";
            this.colZahlungsgrund.Name = "colZahlungsgrund";
            this.colZahlungsgrund.OptionsColumn.AllowEdit = false;
            this.colZahlungsgrund.OptionsColumn.ReadOnly = true;
            this.colZahlungsgrund.Visible = true;
            this.colZahlungsgrund.VisibleIndex = 8;
            this.colZahlungsgrund.Width = 90;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colStatus.AppearanceCell.Options.UseBackColor = true;
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "StatusText";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.OptionsColumn.ReadOnly = true;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 9;
            this.colStatus.Width = 84;
            // 
            // colUebermitteln
            // 
            this.colUebermitteln.Caption = "Auswählen";
            this.colUebermitteln.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colUebermitteln.FieldName = "Uebermitteln";
            this.colUebermitteln.Name = "colUebermitteln";
            this.colUebermitteln.Visible = true;
            this.colUebermitteln.VisibleIndex = 10;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboEZugang);
            this.panel1.Controls.Add(this.ValutaDatumBis);
            this.panel1.Controls.Add(this.kissLabel2);
            this.panel1.Controls.Add(this.btnSuchen);
            this.panel1.Controls.Add(this.kissLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 30);
            this.panel1.TabIndex = 16;
            // 
            // cboEZugang
            // 
            this.cboEZugang.Location = new System.Drawing.Point(92, 4);
            this.cboEZugang.Name = "cboEZugang";
            this.cboEZugang.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboEZugang.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboEZugang.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboEZugang.Properties.Appearance.Options.UseBackColor = true;
            this.cboEZugang.Properties.Appearance.Options.UseBorderColor = true;
            this.cboEZugang.Properties.Appearance.Options.UseFont = true;
            this.cboEZugang.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboEZugang.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboEZugang.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboEZugang.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboEZugang.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.cboEZugang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.cboEZugang.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboEZugang.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.cboEZugang.Properties.DisplayMember = "Text";
            this.cboEZugang.Properties.NullText = "";
            this.cboEZugang.Properties.ShowFooter = false;
            this.cboEZugang.Properties.ShowHeader = false;
            this.cboEZugang.Properties.ValueMember = "Code";
            this.cboEZugang.Size = new System.Drawing.Size(260, 24);
            this.cboEZugang.TabIndex = 372;
            // 
            // ValutaDatumBis
            // 
            this.ValutaDatumBis.EditValue = new System.DateTime(2004, 5, 11, 0, 0, 0, 0);
            this.ValutaDatumBis.Location = new System.Drawing.Point(464, 4);
            this.ValutaDatumBis.Name = "ValutaDatumBis";
            this.ValutaDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.ValutaDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ValutaDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ValutaDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ValutaDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.ValutaDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.ValutaDatumBis.Properties.Appearance.Options.UseFont = true;
            this.ValutaDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.ValutaDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("ValutaDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.ValutaDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ValutaDatumBis.Properties.ShowToday = false;
            this.ValutaDatumBis.Size = new System.Drawing.Size(140, 24);
            this.ValutaDatumBis.TabIndex = 7;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(364, 4);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(100, 24);
            this.kissLabel2.TabIndex = 6;
            this.kissLabel2.Text = "Valutadatum bis";
            // 
            // btnSuchen
            // 
            this.btnSuchen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuchen.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuchen.Location = new System.Drawing.Point(631, 4);
            this.btnSuchen.Name = "btnSuchen";
            this.btnSuchen.Size = new System.Drawing.Size(184, 24);
            this.btnSuchen.TabIndex = 3;
            this.btnSuchen.Text = "Zahlungen aktualisieren";
            this.btnSuchen.UseVisualStyleBackColor = false;
            this.btnSuchen.Click += new System.EventHandler(this.btnSuchen_Click);
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(4, 2);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(100, 23);
            this.kissLabel1.TabIndex = 5;
            this.kissLabel1.Text = "EBanking Konto";
            // 
            // CtlFibuDTAZahlungsLauf
            // 
            this.ActiveSQLQuery = this.qryDTABuchungErwartung;
            this.AutoRefresh = false;
            this.Controls.Add(this.grdErwartung);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "CtlFibuDTAZahlungsLauf";
            this.Size = new System.Drawing.Size(825, 535);
            this.RefreshData += new System.EventHandler(this.CtlFibuDTAZahlungsLauf_RefreshData);
            ((System.ComponentModel.ISupportInitialize)(this.qryDTABuchungErwartung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbDTAJournal)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdErwartung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboEZugang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEZugang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValutaDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.ComponentModel.IContainer components = null;
        private KiSS4.DB.SqlQuery qryFbDTAJournal;
        private KiSS4.DB.SqlQuery qryDTABuchungErwartung;
        private System.Windows.Forms.Panel panel2;
        private KiSS4.Gui.KissButton btnOK;
        private KiSS4.Gui.KissGrid grdErwartung;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFields;
        private DevExpress.XtraGrid.Columns.GridColumn colDTAZugang;
        private DevExpress.XtraGrid.Columns.GridColumn colValuta;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoName;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colKonto;
        private DevExpress.XtraGrid.Columns.GridColumn colBeguenstigter;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungsgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colUebermitteln;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private KiSS4.Gui.KissButton btnAlleEntfernen;
        private System.Windows.Forms.Panel panel1;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissButton btnSuchen;
        private KiSS4.Gui.KissLookUpEdit cboEZugang;
        private KiSS4.Gui.KissDateEdit ValutaDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
    }
}
