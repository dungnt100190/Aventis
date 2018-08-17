namespace KiSS4.Fibu
{
    partial class DlgAuswahlFbZahlungsweg
    {
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// 		/// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryFbKreditor = new KiSS4.DB.SqlQuery(this.components);
            this.qryFbZahlungsweg = new KiSS4.DB.SqlQuery(this.components);
            this.tabControlSearch = new KiSS4.Gui.KissTabControlEx();
            this.tpgListe = new SharpLibrary.WinControls.TabPageEx();
            this.grdFbKreditor = new KiSS4.Gui.KissGrid();
            this.grvFbKreditor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZusatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAufwandKonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKurzName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panKreditor = new System.Windows.Forms.Panel();
            this.lblKreditoren = new KiSS4.Gui.KissLabel();
            this.panZahlungsweg = new System.Windows.Forms.Panel();
            this.lblZahlungswege = new KiSS4.Gui.KissLabel();
            this.grdFbZahlungsweg = new KiSS4.Gui.KissGrid();
            this.grvFbZahlungsweg = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colZahlungsArt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIBAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPCKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungsFrist = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnListeOK = new KiSS4.Gui.KissButton();
            this.btnListeAbbruch = new KiSS4.Gui.KissButton();
            this.tpgSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.lblIban = new KiSS4.Gui.KissLabel();
            this.edtSearchIban = new KiSS4.Gui.KissTextEdit();
            this.edtSearchAufwandKontoName = new KiSS4.Gui.KissTextEdit();
            this.edtSearchAufwandKonto = new KiSS4.Gui.KissButtonEdit();
            this.btnNeueSuche = new KiSS4.Gui.KissButton();
            this.edtSearchZahlungsFrist = new KiSS4.Gui.KissCalcEdit();
            this.edtSearchZahlungsArt = new KiSS4.Gui.KissLookUpEdit();
            this.btnSuchen = new KiSS4.Gui.KissButton();
            this.lblZahlungsfrist = new KiSS4.Gui.KissLabel();
            this.edtSearchBankKontoNr = new KiSS4.Gui.KissTextEdit();
            this.edtSearchPostKontoNr = new KiSS4.Gui.KissTextEdit();
            this.lblBankKontoNr = new KiSS4.Gui.KissLabel();
            this.lblBank = new KiSS4.Gui.KissLabel();
            this.lblPostKontoNr = new KiSS4.Gui.KissLabel();
            this.lblZahlungsart = new KiSS4.Gui.KissLabel();
            this.edtSearchBank = new KiSS4.Gui.KissButtonEdit();
            this.lblZahlungsweg = new KiSS4.Gui.KissLabel();
            this.edtSearchPLZOrt = new KiSS4.Common.KissPLZOrt();
            this.edtSearchStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtSearchZusatz = new KiSS4.Gui.KissTextEdit();
            this.lblAktiv = new KiSS4.Gui.KissLabel();
            this.edtSearchAktiv = new KiSS4.Gui.KissCheckEdit();
            this.edtSearchKurzName = new KiSS4.Gui.KissTextEdit();
            this.lblPlzOrt = new KiSS4.Gui.KissLabel();
            this.lblZusatz = new KiSS4.Gui.KissLabel();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.lblKurzname = new KiSS4.Gui.KissLabel();
            this.edtSearchName = new KiSS4.Gui.KissButtonEdit();
            this.lblStrasse = new KiSS4.Gui.KissLabel();
            this.lblAufwandKonto = new KiSS4.Gui.KissLabel();
            this.lblKreditor = new KiSS4.Gui.KissLabel();
            this.tpgNeuKreditor = new SharpLibrary.WinControls.TabPageEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.editAufwandKontoName = new KiSS4.Gui.KissTextEdit();
            this.editAufwandKonto = new KiSS4.Gui.KissButtonEdit();
            this.editPLZOrt = new KiSS4.Common.KissPLZOrt();
            this.btnNeuKreditorAbbrechen = new KiSS4.Gui.KissButton();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.label8 = new KiSS4.Gui.KissLabel();
            this.editKuerzel = new KiSS4.Gui.KissTextEdit();
            this.editStrasse = new KiSS4.Gui.KissTextEdit();
            this.label5 = new KiSS4.Gui.KissLabel();
            this.label4 = new KiSS4.Gui.KissLabel();
            this.label3 = new KiSS4.Gui.KissLabel();
            this.label2 = new KiSS4.Gui.KissLabel();
            this.label1 = new KiSS4.Gui.KissLabel();
            this.editZusatz = new KiSS4.Gui.KissTextEdit();
            this.editName = new KiSS4.Gui.KissTextEdit();
            this.btnNeuKreditorOk = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbZahlungsweg)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbKreditor)).BeginInit();
            this.panKreditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditoren)).BeginInit();
            this.panZahlungsweg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungswege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbZahlungsweg)).BeginInit();
            this.panel1.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblIban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchIban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchAufwandKontoName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchAufwandKonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchZahlungsFrist.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchZahlungsArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchZahlungsArt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsfrist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchBankKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchPostKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankKontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostKontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchKurzName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufwandKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).BeginInit();
            this.tpgNeuKreditor.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editAufwandKontoName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufwandKonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKuerzel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryFbKreditor
            // 
            this.qryFbKreditor.CanInsert = true;
            this.qryFbKreditor.CanUpdate = true;
            this.qryFbKreditor.HostControl = this;
            this.qryFbKreditor.TableName = "FbKreditor";
            this.qryFbKreditor.PositionChanged += new System.EventHandler(this.qryKreditor_PositionChanged);
            // 
            // qryFbZahlungsweg
            // 
            this.qryFbZahlungsweg.HostControl = this;
            this.qryFbZahlungsweg.TableName = "FbZahlungsweg";
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgListe);
            this.tabControlSearch.Controls.Add(this.tpgSuchen);
            this.tabControlSearch.Controls.Add(this.tpgNeuKreditor);
            this.tabControlSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Name = "tabControlSearch";
            this.tabControlSearch.ShowFixedWidthTooltip = true;
            this.tabControlSearch.Size = new System.Drawing.Size(919, 514);
            this.tabControlSearch.TabIndex = 0;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe,
            this.tpgSuchen,
            this.tpgNeuKreditor});
            this.tabControlSearch.TabsLineColor = System.Drawing.Color.Black;
            this.tabControlSearch.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabControlSearch.TabStop = false;
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.xTabControl1_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdFbKreditor);
            this.tpgListe.Controls.Add(this.panKreditor);
            this.tpgListe.Controls.Add(this.panZahlungsweg);
            this.tpgListe.Controls.Add(this.grdFbZahlungsweg);
            this.tpgListe.Controls.Add(this.panel1);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Name = "tpgListe";
            this.tpgListe.Size = new System.Drawing.Size(907, 476);
            this.tpgListe.TabIndex = 0;
            this.tpgListe.Title = "Liste";
            // 
            // grdFbKreditor
            // 
            this.grdFbKreditor.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdFbKreditor.EmbeddedNavigator.Name = "";
            this.grdFbKreditor.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFbKreditor.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdFbKreditor.Location = new System.Drawing.Point(0, 22);
            this.grdFbKreditor.MainView = this.grvFbKreditor;
            this.grdFbKreditor.Name = "grdFbKreditor";
            this.grdFbKreditor.Size = new System.Drawing.Size(907, 270);
            this.grdFbKreditor.TabIndex = 1;
            this.grdFbKreditor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFbKreditor});
            // 
            // grvFbKreditor
            // 
            this.grvFbKreditor.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFbKreditor.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbKreditor.Appearance.Empty.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.Empty.Options.UseFont = true;
            this.grvFbKreditor.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvFbKreditor.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbKreditor.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.EvenRow.Options.UseFont = true;
            this.grvFbKreditor.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbKreditor.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbKreditor.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFbKreditor.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFbKreditor.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFbKreditor.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbKreditor.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbKreditor.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFbKreditor.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFbKreditor.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFbKreditor.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbKreditor.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbKreditor.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbKreditor.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbKreditor.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.GroupRow.Options.UseFont = true;
            this.grvFbKreditor.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFbKreditor.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFbKreditor.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFbKreditor.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbKreditor.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFbKreditor.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFbKreditor.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFbKreditor.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbKreditor.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbKreditor.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFbKreditor.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFbKreditor.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbKreditor.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvFbKreditor.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbKreditor.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.OddRow.Options.UseFont = true;
            this.grvFbKreditor.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFbKreditor.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbKreditor.Appearance.Row.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.Row.Options.UseFont = true;
            this.grvFbKreditor.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvFbKreditor.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbKreditor.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFbKreditor.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFbKreditor.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFbKreditor.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbKreditor.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFbKreditor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFbKreditor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKreditor,
            this.colStrasse,
            this.colZusatz,
            this.colOrt,
            this.colAufwandKonto,
            this.colKurzName});
            this.grvFbKreditor.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFbKreditor.GridControl = this.grdFbKreditor;
            this.grvFbKreditor.Name = "grvFbKreditor";
            this.grvFbKreditor.OptionsBehavior.Editable = false;
            this.grvFbKreditor.OptionsCustomization.AllowFilter = false;
            this.grvFbKreditor.OptionsCustomization.AllowGroup = false;
            this.grvFbKreditor.OptionsFilter.AllowFilterEditor = false;
            this.grvFbKreditor.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFbKreditor.OptionsMenu.EnableColumnMenu = false;
            this.grvFbKreditor.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFbKreditor.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvFbKreditor.OptionsNavigation.UseTabKey = false;
            this.grvFbKreditor.OptionsPrint.AutoWidth = false;
            this.grvFbKreditor.OptionsPrint.UsePrintStyles = true;
            this.grvFbKreditor.OptionsView.ColumnAutoWidth = false;
            this.grvFbKreditor.OptionsView.ShowDetailButtons = false;
            this.grvFbKreditor.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFbKreditor.OptionsView.ShowGroupPanel = false;
            this.grvFbKreditor.OptionsView.ShowIndicator = false;
            // 
            // colKreditor
            // 
            this.colKreditor.Caption = "Kreditor Name";
            this.colKreditor.FieldName = "Kreditor";
            this.colKreditor.Name = "colKreditor";
            this.colKreditor.Visible = true;
            this.colKreditor.VisibleIndex = 0;
            this.colKreditor.Width = 218;
            // 
            // colStrasse
            // 
            this.colStrasse.Caption = "Strasse";
            this.colStrasse.FieldName = "Strasse";
            this.colStrasse.Name = "colStrasse";
            this.colStrasse.Visible = true;
            this.colStrasse.VisibleIndex = 3;
            this.colStrasse.Width = 184;
            // 
            // colZusatz
            // 
            this.colZusatz.Caption = "Zusatz";
            this.colZusatz.FieldName = "Zusatz";
            this.colZusatz.Name = "colZusatz";
            this.colZusatz.Visible = true;
            this.colZusatz.VisibleIndex = 2;
            this.colZusatz.Width = 101;
            // 
            // colOrt
            // 
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "KreditorOrt";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 4;
            this.colOrt.Width = 202;
            // 
            // colAufwandKonto
            // 
            this.colAufwandKonto.Caption = "Aufwandkonto";
            this.colAufwandKonto.FieldName = "AufwandKonto";
            this.colAufwandKonto.Name = "colAufwandKonto";
            this.colAufwandKonto.Visible = true;
            this.colAufwandKonto.VisibleIndex = 5;
            this.colAufwandKonto.Width = 85;
            // 
            // colKurzName
            // 
            this.colKurzName.Caption = "Kurzname";
            this.colKurzName.FieldName = "KurzName";
            this.colKurzName.Name = "colKurzName";
            this.colKurzName.Visible = true;
            this.colKurzName.VisibleIndex = 1;
            this.colKurzName.Width = 89;
            // 
            // panKreditor
            // 
            this.panKreditor.Controls.Add(this.lblKreditoren);
            this.panKreditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panKreditor.Location = new System.Drawing.Point(0, 0);
            this.panKreditor.Name = "panKreditor";
            this.panKreditor.Size = new System.Drawing.Size(907, 22);
            this.panKreditor.TabIndex = 0;
            // 
            // lblKreditoren
            // 
            this.lblKreditoren.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblKreditoren.Location = new System.Drawing.Point(0, 2);
            this.lblKreditoren.Name = "lblKreditoren";
            this.lblKreditoren.Size = new System.Drawing.Size(150, 16);
            this.lblKreditoren.TabIndex = 0;
            this.lblKreditoren.Text = "Kreditoren";
            // 
            // panZahlungsweg
            // 
            this.panZahlungsweg.Controls.Add(this.lblZahlungswege);
            this.panZahlungsweg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panZahlungsweg.Location = new System.Drawing.Point(0, 292);
            this.panZahlungsweg.Name = "panZahlungsweg";
            this.panZahlungsweg.Size = new System.Drawing.Size(907, 29);
            this.panZahlungsweg.TabIndex = 2;
            // 
            // lblZahlungswege
            // 
            this.lblZahlungswege.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblZahlungswege.Location = new System.Drawing.Point(9, 6);
            this.lblZahlungswege.Name = "lblZahlungswege";
            this.lblZahlungswege.Size = new System.Drawing.Size(118, 18);
            this.lblZahlungswege.TabIndex = 0;
            this.lblZahlungswege.Text = "Zahlungswege";
            // 
            // grdFbZahlungsweg
            // 
            this.grdFbZahlungsweg.Dock = System.Windows.Forms.DockStyle.Bottom;
            // 
            // 
            // 
            this.grdFbZahlungsweg.EmbeddedNavigator.Name = "";
            this.grdFbZahlungsweg.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFbZahlungsweg.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdFbZahlungsweg.Location = new System.Drawing.Point(0, 321);
            this.grdFbZahlungsweg.MainView = this.grvFbZahlungsweg;
            this.grdFbZahlungsweg.Name = "grdFbZahlungsweg";
            this.grdFbZahlungsweg.Size = new System.Drawing.Size(907, 124);
            this.grdFbZahlungsweg.TabIndex = 3;
            this.grdFbZahlungsweg.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFbZahlungsweg});
            // 
            // grvFbZahlungsweg
            // 
            this.grvFbZahlungsweg.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFbZahlungsweg.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbZahlungsweg.Appearance.Empty.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.Empty.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvFbZahlungsweg.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbZahlungsweg.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.EvenRow.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbZahlungsweg.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbZahlungsweg.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFbZahlungsweg.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFbZahlungsweg.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbZahlungsweg.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbZahlungsweg.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFbZahlungsweg.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFbZahlungsweg.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbZahlungsweg.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbZahlungsweg.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbZahlungsweg.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbZahlungsweg.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.GroupRow.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFbZahlungsweg.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFbZahlungsweg.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFbZahlungsweg.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbZahlungsweg.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFbZahlungsweg.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFbZahlungsweg.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbZahlungsweg.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbZahlungsweg.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFbZahlungsweg.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbZahlungsweg.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvFbZahlungsweg.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbZahlungsweg.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.OddRow.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFbZahlungsweg.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbZahlungsweg.Appearance.Row.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.Row.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvFbZahlungsweg.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbZahlungsweg.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFbZahlungsweg.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFbZahlungsweg.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbZahlungsweg.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFbZahlungsweg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFbZahlungsweg.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colZahlungsArt,
            this.colBank,
            this.colIBAN,
            this.colPCKontoNr,
            this.colBankKontoNr,
            this.colZahlungsFrist});
            this.grvFbZahlungsweg.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFbZahlungsweg.GridControl = this.grdFbZahlungsweg;
            this.grvFbZahlungsweg.Name = "grvFbZahlungsweg";
            this.grvFbZahlungsweg.OptionsBehavior.Editable = false;
            this.grvFbZahlungsweg.OptionsCustomization.AllowFilter = false;
            this.grvFbZahlungsweg.OptionsCustomization.AllowGroup = false;
            this.grvFbZahlungsweg.OptionsFilter.AllowFilterEditor = false;
            this.grvFbZahlungsweg.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFbZahlungsweg.OptionsMenu.EnableColumnMenu = false;
            this.grvFbZahlungsweg.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFbZahlungsweg.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvFbZahlungsweg.OptionsNavigation.UseTabKey = false;
            this.grvFbZahlungsweg.OptionsPrint.AutoWidth = false;
            this.grvFbZahlungsweg.OptionsPrint.UsePrintStyles = true;
            this.grvFbZahlungsweg.OptionsView.ColumnAutoWidth = false;
            this.grvFbZahlungsweg.OptionsView.ShowDetailButtons = false;
            this.grvFbZahlungsweg.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFbZahlungsweg.OptionsView.ShowGroupPanel = false;
            this.grvFbZahlungsweg.OptionsView.ShowIndicator = false;
            // 
            // colZahlungsArt
            // 
            this.colZahlungsArt.Caption = "Zahlungsart";
            this.colZahlungsArt.FieldName = "Text";
            this.colZahlungsArt.Name = "colZahlungsArt";
            this.colZahlungsArt.Visible = true;
            this.colZahlungsArt.VisibleIndex = 0;
            this.colZahlungsArt.Width = 167;
            // 
            // colBank
            // 
            this.colBank.Caption = "Finanz Institut";
            this.colBank.FieldName = "Bank";
            this.colBank.Name = "colBank";
            this.colBank.Visible = true;
            this.colBank.VisibleIndex = 1;
            this.colBank.Width = 185;
            // 
            // colIBAN
            // 
            this.colIBAN.Caption = "IBAN-Nummer";
            this.colIBAN.FieldName = "IBAN";
            this.colIBAN.Name = "colIBAN";
            this.colIBAN.Visible = true;
            this.colIBAN.VisibleIndex = 2;
            this.colIBAN.Width = 120;
            // 
            // colPCKontoNr
            // 
            this.colPCKontoNr.Caption = "Postkonto Nummer";
            this.colPCKontoNr.FieldName = "PCKontoNr";
            this.colPCKontoNr.Name = "colPCKontoNr";
            this.colPCKontoNr.Visible = true;
            this.colPCKontoNr.VisibleIndex = 3;
            this.colPCKontoNr.Width = 144;
            // 
            // colBankKontoNr
            // 
            this.colBankKontoNr.Caption = "Bankkonto Nummer";
            this.colBankKontoNr.FieldName = "BankKontoNr";
            this.colBankKontoNr.Name = "colBankKontoNr";
            this.colBankKontoNr.Visible = true;
            this.colBankKontoNr.VisibleIndex = 4;
            this.colBankKontoNr.Width = 139;
            // 
            // colZahlungsFrist
            // 
            this.colZahlungsFrist.Caption = "Zahlungsfrist";
            this.colZahlungsFrist.FieldName = "ZahlungsFrist";
            this.colZahlungsFrist.Name = "colZahlungsFrist";
            this.colZahlungsFrist.Visible = true;
            this.colZahlungsFrist.VisibleIndex = 5;
            this.colZahlungsFrist.Width = 85;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnListeOK);
            this.panel1.Controls.Add(this.btnListeAbbruch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 445);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 31);
            this.panel1.TabIndex = 4;
            // 
            // btnListeOK
            // 
            this.btnListeOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListeOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnListeOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListeOK.Location = new System.Drawing.Point(658, 3);
            this.btnListeOK.Name = "btnListeOK";
            this.btnListeOK.Size = new System.Drawing.Size(121, 24);
            this.btnListeOK.TabIndex = 0;
            this.btnListeOK.Text = "OK";
            this.btnListeOK.UseVisualStyleBackColor = false;
            this.btnListeOK.Click += new System.EventHandler(this.btnListeOK_Click);
            // 
            // btnListeAbbruch
            // 
            this.btnListeAbbruch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListeAbbruch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnListeAbbruch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListeAbbruch.Location = new System.Drawing.Point(783, 3);
            this.btnListeAbbruch.Name = "btnListeAbbruch";
            this.btnListeAbbruch.Size = new System.Drawing.Size(121, 24);
            this.btnListeAbbruch.TabIndex = 1;
            this.btnListeAbbruch.Text = "Abbruch";
            this.btnListeAbbruch.UseVisualStyleBackColor = false;
            this.btnListeAbbruch.Click += new System.EventHandler(this.btnListeAbbruch_Click);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblIban);
            this.tpgSuchen.Controls.Add(this.edtSearchIban);
            this.tpgSuchen.Controls.Add(this.edtSearchAufwandKontoName);
            this.tpgSuchen.Controls.Add(this.edtSearchAufwandKonto);
            this.tpgSuchen.Controls.Add(this.btnNeueSuche);
            this.tpgSuchen.Controls.Add(this.edtSearchZahlungsFrist);
            this.tpgSuchen.Controls.Add(this.edtSearchZahlungsArt);
            this.tpgSuchen.Controls.Add(this.btnSuchen);
            this.tpgSuchen.Controls.Add(this.lblZahlungsfrist);
            this.tpgSuchen.Controls.Add(this.edtSearchBankKontoNr);
            this.tpgSuchen.Controls.Add(this.edtSearchPostKontoNr);
            this.tpgSuchen.Controls.Add(this.lblBankKontoNr);
            this.tpgSuchen.Controls.Add(this.lblBank);
            this.tpgSuchen.Controls.Add(this.lblPostKontoNr);
            this.tpgSuchen.Controls.Add(this.lblZahlungsart);
            this.tpgSuchen.Controls.Add(this.edtSearchBank);
            this.tpgSuchen.Controls.Add(this.lblZahlungsweg);
            this.tpgSuchen.Controls.Add(this.edtSearchPLZOrt);
            this.tpgSuchen.Controls.Add(this.edtSearchStrasse);
            this.tpgSuchen.Controls.Add(this.edtSearchZusatz);
            this.tpgSuchen.Controls.Add(this.lblAktiv);
            this.tpgSuchen.Controls.Add(this.edtSearchAktiv);
            this.tpgSuchen.Controls.Add(this.edtSearchKurzName);
            this.tpgSuchen.Controls.Add(this.lblPlzOrt);
            this.tpgSuchen.Controls.Add(this.lblZusatz);
            this.tpgSuchen.Controls.Add(this.lblName);
            this.tpgSuchen.Controls.Add(this.lblKurzname);
            this.tpgSuchen.Controls.Add(this.edtSearchName);
            this.tpgSuchen.Controls.Add(this.lblStrasse);
            this.tpgSuchen.Controls.Add(this.lblAufwandKonto);
            this.tpgSuchen.Controls.Add(this.lblKreditor);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Name = "tpgSuchen";
            this.tpgSuchen.Size = new System.Drawing.Size(907, 476);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suchen";
            // 
            // lblIban
            // 
            this.lblIban.Location = new System.Drawing.Point(6, 282);
            this.lblIban.Name = "lblIban";
            this.lblIban.Size = new System.Drawing.Size(88, 24);
            this.lblIban.TabIndex = 21;
            this.lblIban.Text = "IBAN";
            // 
            // edtSearchIban
            // 
            this.edtSearchIban.Location = new System.Drawing.Point(100, 282);
            this.edtSearchIban.Name = "edtSearchIban";
            this.edtSearchIban.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchIban.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchIban.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchIban.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchIban.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchIban.Properties.Appearance.Options.UseFont = true;
            this.edtSearchIban.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchIban.Size = new System.Drawing.Size(259, 24);
            this.edtSearchIban.TabIndex = 22;
            // 
            // edtSearchAufwandKontoName
            // 
            this.edtSearchAufwandKontoName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSearchAufwandKontoName.EditValue = "";
            this.edtSearchAufwandKontoName.Location = new System.Drawing.Point(585, 32);
            this.edtSearchAufwandKontoName.Name = "edtSearchAufwandKontoName";
            this.edtSearchAufwandKontoName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSearchAufwandKontoName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchAufwandKontoName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchAufwandKontoName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSearchAufwandKontoName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchAufwandKontoName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchAufwandKontoName.Properties.Appearance.Options.UseFont = true;
            this.edtSearchAufwandKontoName.Properties.Appearance.Options.UseForeColor = true;
            this.edtSearchAufwandKontoName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchAufwandKontoName.Properties.ReadOnly = true;
            this.edtSearchAufwandKontoName.Size = new System.Drawing.Size(218, 24);
            this.edtSearchAufwandKontoName.TabIndex = 13;
            this.edtSearchAufwandKontoName.TabStop = false;
            // 
            // edtSearchAufwandKonto
            // 
            this.edtSearchAufwandKonto.Location = new System.Drawing.Point(514, 32);
            this.edtSearchAufwandKonto.Name = "edtSearchAufwandKonto";
            this.edtSearchAufwandKonto.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchAufwandKonto.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchAufwandKonto.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchAufwandKonto.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSearchAufwandKonto.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchAufwandKonto.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchAufwandKonto.Properties.Appearance.Options.UseFont = true;
            this.edtSearchAufwandKonto.Properties.Appearance.Options.UseForeColor = true;
            this.edtSearchAufwandKonto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSearchAufwandKonto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSearchAufwandKonto.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchAufwandKonto.Size = new System.Drawing.Size(72, 24);
            this.edtSearchAufwandKonto.TabIndex = 12;
            this.edtSearchAufwandKonto.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editAufwandKontoSearch_UserModifiedFld);
            // 
            // btnNeueSuche
            // 
            this.btnNeueSuche.CausesValidation = false;
            this.btnNeueSuche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeueSuche.Location = new System.Drawing.Point(257, 402);
            this.btnNeueSuche.Name = "btnNeueSuche";
            this.btnNeueSuche.Size = new System.Drawing.Size(102, 24);
            this.btnNeueSuche.TabIndex = 30;
            this.btnNeueSuche.Text = "Neue Suche";
            this.btnNeueSuche.UseVisualStyleBackColor = false;
            this.btnNeueSuche.Click += new System.EventHandler(this.btnNeuSuche_Click);
            // 
            // edtSearchZahlungsFrist
            // 
            this.edtSearchZahlungsFrist.Location = new System.Drawing.Point(100, 372);
            this.edtSearchZahlungsFrist.Name = "edtSearchZahlungsFrist";
            this.edtSearchZahlungsFrist.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSearchZahlungsFrist.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchZahlungsFrist.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchZahlungsFrist.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchZahlungsFrist.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchZahlungsFrist.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchZahlungsFrist.Properties.Appearance.Options.UseFont = true;
            this.edtSearchZahlungsFrist.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchZahlungsFrist.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchZahlungsFrist.Size = new System.Drawing.Size(259, 24);
            this.edtSearchZahlungsFrist.TabIndex = 28;
            // 
            // edtSearchZahlungsArt
            // 
            this.edtSearchZahlungsArt.Location = new System.Drawing.Point(100, 222);
            this.edtSearchZahlungsArt.LOVName = "FbZahlungsartCode";
            this.edtSearchZahlungsArt.Name = "edtSearchZahlungsArt";
            this.edtSearchZahlungsArt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchZahlungsArt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchZahlungsArt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchZahlungsArt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchZahlungsArt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchZahlungsArt.Properties.Appearance.Options.UseFont = true;
            this.edtSearchZahlungsArt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSearchZahlungsArt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchZahlungsArt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSearchZahlungsArt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSearchZahlungsArt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSearchZahlungsArt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSearchZahlungsArt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchZahlungsArt.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSearchZahlungsArt.Properties.DisplayMember = "Text";
            this.edtSearchZahlungsArt.Properties.NullText = "";
            this.edtSearchZahlungsArt.Properties.ShowFooter = false;
            this.edtSearchZahlungsArt.Properties.ShowHeader = false;
            this.edtSearchZahlungsArt.Properties.ValueMember = "Code";
            this.edtSearchZahlungsArt.Size = new System.Drawing.Size(259, 24);
            this.edtSearchZahlungsArt.TabIndex = 18;
            // 
            // btnSuchen
            // 
            this.btnSuchen.CausesValidation = false;
            this.btnSuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuchen.Location = new System.Drawing.Point(149, 402);
            this.btnSuchen.Name = "btnSuchen";
            this.btnSuchen.Size = new System.Drawing.Size(102, 24);
            this.btnSuchen.TabIndex = 29;
            this.btnSuchen.Text = "Suchen";
            this.btnSuchen.UseVisualStyleBackColor = false;
            this.btnSuchen.Click += new System.EventHandler(this.btnSuchen_Click);
            // 
            // lblZahlungsfrist
            // 
            this.lblZahlungsfrist.Location = new System.Drawing.Point(6, 372);
            this.lblZahlungsfrist.Name = "lblZahlungsfrist";
            this.lblZahlungsfrist.Size = new System.Drawing.Size(88, 24);
            this.lblZahlungsfrist.TabIndex = 27;
            this.lblZahlungsfrist.Text = "Zahlungsfrist";
            // 
            // edtSearchBankKontoNr
            // 
            this.edtSearchBankKontoNr.EditValue = "";
            this.edtSearchBankKontoNr.Location = new System.Drawing.Point(100, 342);
            this.edtSearchBankKontoNr.Name = "edtSearchBankKontoNr";
            this.edtSearchBankKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchBankKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchBankKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchBankKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchBankKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchBankKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtSearchBankKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchBankKontoNr.Size = new System.Drawing.Size(259, 24);
            this.edtSearchBankKontoNr.TabIndex = 26;
            // 
            // edtSearchPostKontoNr
            // 
            this.edtSearchPostKontoNr.EditValue = "";
            this.edtSearchPostKontoNr.Location = new System.Drawing.Point(100, 312);
            this.edtSearchPostKontoNr.Name = "edtSearchPostKontoNr";
            this.edtSearchPostKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchPostKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchPostKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchPostKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchPostKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchPostKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtSearchPostKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchPostKontoNr.Size = new System.Drawing.Size(259, 24);
            this.edtSearchPostKontoNr.TabIndex = 24;
            // 
            // lblBankKontoNr
            // 
            this.lblBankKontoNr.Location = new System.Drawing.Point(6, 342);
            this.lblBankKontoNr.Name = "lblBankKontoNr";
            this.lblBankKontoNr.Size = new System.Drawing.Size(88, 24);
            this.lblBankKontoNr.TabIndex = 25;
            this.lblBankKontoNr.Text = "Bankkonto Nr";
            // 
            // lblBank
            // 
            this.lblBank.Location = new System.Drawing.Point(6, 252);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(88, 24);
            this.lblBank.TabIndex = 19;
            this.lblBank.Text = "Bank";
            // 
            // lblPostKontoNr
            // 
            this.lblPostKontoNr.Location = new System.Drawing.Point(6, 312);
            this.lblPostKontoNr.Name = "lblPostKontoNr";
            this.lblPostKontoNr.Size = new System.Drawing.Size(88, 24);
            this.lblPostKontoNr.TabIndex = 23;
            this.lblPostKontoNr.Text = "Postkonto Nr";
            // 
            // lblZahlungsart
            // 
            this.lblZahlungsart.Location = new System.Drawing.Point(6, 222);
            this.lblZahlungsart.Name = "lblZahlungsart";
            this.lblZahlungsart.Size = new System.Drawing.Size(88, 24);
            this.lblZahlungsart.TabIndex = 17;
            this.lblZahlungsart.Text = "Zahlungsart";
            // 
            // edtSearchBank
            // 
            this.edtSearchBank.Location = new System.Drawing.Point(100, 252);
            this.edtSearchBank.Name = "edtSearchBank";
            this.edtSearchBank.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchBank.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchBank.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchBank.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSearchBank.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchBank.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchBank.Properties.Appearance.Options.UseFont = true;
            this.edtSearchBank.Properties.Appearance.Options.UseForeColor = true;
            this.edtSearchBank.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSearchBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSearchBank.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchBank.Size = new System.Drawing.Size(259, 24);
            this.edtSearchBank.TabIndex = 20;
            this.edtSearchBank.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.editBankSearch_ButtonPressed);
            this.edtSearchBank.Leave += new System.EventHandler(this.editBankSearch_Leave);
            // 
            // lblZahlungsweg
            // 
            this.lblZahlungsweg.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblZahlungsweg.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblZahlungsweg.Location = new System.Drawing.Point(6, 199);
            this.lblZahlungsweg.Name = "lblZahlungsweg";
            this.lblZahlungsweg.Size = new System.Drawing.Size(90, 23);
            this.lblZahlungsweg.TabIndex = 16;
            this.lblZahlungsweg.Text = "Zahlungsweg";
            // 
            // edtSearchPLZOrt
            // 
            this.edtSearchPLZOrt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSearchPLZOrt.Location = new System.Drawing.Point(100, 152);
            this.edtSearchPLZOrt.Name = "edtSearchPLZOrt";
            this.edtSearchPLZOrt.Size = new System.Drawing.Size(259, 24);
            this.edtSearchPLZOrt.TabIndex = 10;
            // 
            // edtSearchStrasse
            // 
            this.edtSearchStrasse.EditValue = "";
            this.edtSearchStrasse.Location = new System.Drawing.Point(100, 122);
            this.edtSearchStrasse.Name = "edtSearchStrasse";
            this.edtSearchStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtSearchStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchStrasse.Size = new System.Drawing.Size(259, 24);
            this.edtSearchStrasse.TabIndex = 8;
            // 
            // edtSearchZusatz
            // 
            this.edtSearchZusatz.EditValue = "";
            this.edtSearchZusatz.Location = new System.Drawing.Point(100, 92);
            this.edtSearchZusatz.Name = "edtSearchZusatz";
            this.edtSearchZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtSearchZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchZusatz.Size = new System.Drawing.Size(259, 24);
            this.edtSearchZusatz.TabIndex = 6;
            // 
            // lblAktiv
            // 
            this.lblAktiv.Location = new System.Drawing.Point(413, 64);
            this.lblAktiv.Name = "lblAktiv";
            this.lblAktiv.Size = new System.Drawing.Size(85, 24);
            this.lblAktiv.TabIndex = 14;
            this.lblAktiv.Text = "Aktiv";
            // 
            // edtSearchAktiv
            // 
            this.edtSearchAktiv.EditValue = true;
            this.edtSearchAktiv.Location = new System.Drawing.Point(511, 67);
            this.edtSearchAktiv.Name = "edtSearchAktiv";
            this.edtSearchAktiv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSearchAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchAktiv.Properties.Caption = "";
            this.edtSearchAktiv.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Inactive;
            this.edtSearchAktiv.Size = new System.Drawing.Size(250, 19);
            this.edtSearchAktiv.TabIndex = 15;
            // 
            // edtSearchKurzName
            // 
            this.edtSearchKurzName.EditValue = "";
            this.edtSearchKurzName.Location = new System.Drawing.Point(100, 62);
            this.edtSearchKurzName.Name = "edtSearchKurzName";
            this.edtSearchKurzName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchKurzName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchKurzName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchKurzName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchKurzName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchKurzName.Properties.Appearance.Options.UseFont = true;
            this.edtSearchKurzName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchKurzName.Size = new System.Drawing.Size(259, 24);
            this.edtSearchKurzName.TabIndex = 4;
            // 
            // lblPlzOrt
            // 
            this.lblPlzOrt.Location = new System.Drawing.Point(6, 152);
            this.lblPlzOrt.Name = "lblPlzOrt";
            this.lblPlzOrt.Size = new System.Drawing.Size(88, 24);
            this.lblPlzOrt.TabIndex = 9;
            this.lblPlzOrt.Text = "Plz/Ort";
            // 
            // lblZusatz
            // 
            this.lblZusatz.Location = new System.Drawing.Point(6, 92);
            this.lblZusatz.Name = "lblZusatz";
            this.lblZusatz.Size = new System.Drawing.Size(88, 24);
            this.lblZusatz.TabIndex = 5;
            this.lblZusatz.Text = "Zusatz";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(6, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(88, 24);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblKurzname
            // 
            this.lblKurzname.Location = new System.Drawing.Point(6, 62);
            this.lblKurzname.Name = "lblKurzname";
            this.lblKurzname.Size = new System.Drawing.Size(88, 24);
            this.lblKurzname.TabIndex = 3;
            this.lblKurzname.Text = "Kurzname";
            // 
            // edtSearchName
            // 
            this.edtSearchName.Location = new System.Drawing.Point(100, 32);
            this.edtSearchName.Name = "edtSearchName";
            this.edtSearchName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchName.Properties.Appearance.Options.UseFont = true;
            this.edtSearchName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchName.Size = new System.Drawing.Size(259, 24);
            this.edtSearchName.TabIndex = 2;
            // 
            // lblStrasse
            // 
            this.lblStrasse.Location = new System.Drawing.Point(6, 122);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(88, 24);
            this.lblStrasse.TabIndex = 7;
            this.lblStrasse.Text = "Strasse";
            // 
            // lblAufwandKonto
            // 
            this.lblAufwandKonto.Location = new System.Drawing.Point(413, 32);
            this.lblAufwandKonto.Name = "lblAufwandKonto";
            this.lblAufwandKonto.Size = new System.Drawing.Size(85, 24);
            this.lblAufwandKonto.TabIndex = 11;
            this.lblAufwandKonto.Text = "Aufwand Konto";
            // 
            // lblKreditor
            // 
            this.lblKreditor.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblKreditor.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblKreditor.Location = new System.Drawing.Point(6, 6);
            this.lblKreditor.Name = "lblKreditor";
            this.lblKreditor.Size = new System.Drawing.Size(88, 23);
            this.lblKreditor.TabIndex = 0;
            this.lblKreditor.Text = "Kreditor";
            // 
            // tpgNeuKreditor
            // 
            this.tpgNeuKreditor.Controls.Add(this.panel2);
            this.tpgNeuKreditor.Location = new System.Drawing.Point(6, 6);
            this.tpgNeuKreditor.Name = "tpgNeuKreditor";
            this.tpgNeuKreditor.Size = new System.Drawing.Size(907, 476);
            this.tpgNeuKreditor.TabIndex = 2;
            this.tpgNeuKreditor.Title = "Neu Kreditor";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.editAufwandKontoName);
            this.panel2.Controls.Add(this.editAufwandKonto);
            this.panel2.Controls.Add(this.editPLZOrt);
            this.panel2.Controls.Add(this.btnNeuKreditorAbbrechen);
            this.panel2.Controls.Add(this.kissLabel10);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.editKuerzel);
            this.panel2.Controls.Add(this.editStrasse);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.editZusatz);
            this.panel2.Controls.Add(this.editName);
            this.panel2.Controls.Add(this.btnNeuKreditorOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(907, 476);
            this.panel2.TabIndex = 0;
            // 
            // editAufwandKontoName
            // 
            this.editAufwandKontoName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editAufwandKontoName.EditValue = "";
            this.editAufwandKontoName.Location = new System.Drawing.Point(185, 179);
            this.editAufwandKontoName.Name = "editAufwandKontoName";
            this.editAufwandKontoName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editAufwandKontoName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAufwandKontoName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAufwandKontoName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editAufwandKontoName.Properties.Appearance.Options.UseBackColor = true;
            this.editAufwandKontoName.Properties.Appearance.Options.UseBorderColor = true;
            this.editAufwandKontoName.Properties.Appearance.Options.UseFont = true;
            this.editAufwandKontoName.Properties.Appearance.Options.UseForeColor = true;
            this.editAufwandKontoName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editAufwandKontoName.Properties.ReadOnly = true;
            this.editAufwandKontoName.Size = new System.Drawing.Size(218, 24);
            this.editAufwandKontoName.TabIndex = 13;
            this.editAufwandKontoName.TabStop = false;
            // 
            // editAufwandKonto
            // 
            this.editAufwandKonto.Location = new System.Drawing.Point(114, 179);
            this.editAufwandKonto.Name = "editAufwandKonto";
            this.editAufwandKonto.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editAufwandKonto.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAufwandKonto.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAufwandKonto.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editAufwandKonto.Properties.Appearance.Options.UseBackColor = true;
            this.editAufwandKonto.Properties.Appearance.Options.UseBorderColor = true;
            this.editAufwandKonto.Properties.Appearance.Options.UseFont = true;
            this.editAufwandKonto.Properties.Appearance.Options.UseForeColor = true;
            this.editAufwandKonto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.editAufwandKonto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.editAufwandKonto.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editAufwandKonto.Size = new System.Drawing.Size(72, 24);
            this.editAufwandKonto.TabIndex = 12;
            this.editAufwandKonto.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editAufwandKonto_UserModifiedFld);
            // 
            // editPLZOrt
            // 
            this.editPLZOrt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editPLZOrt.Location = new System.Drawing.Point(114, 149);
            this.editPLZOrt.Name = "editPLZOrt";
            this.editPLZOrt.Size = new System.Drawing.Size(289, 24);
            this.editPLZOrt.TabIndex = 10;
            // 
            // btnNeuKreditorAbbrechen
            // 
            this.btnNeuKreditorAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNeuKreditorAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeuKreditorAbbrechen.Location = new System.Drawing.Point(296, 209);
            this.btnNeuKreditorAbbrechen.Name = "btnNeuKreditorAbbrechen";
            this.btnNeuKreditorAbbrechen.Size = new System.Drawing.Size(107, 24);
            this.btnNeuKreditorAbbrechen.TabIndex = 15;
            this.btnNeuKreditorAbbrechen.Text = "Abbrechen";
            this.btnNeuKreditorAbbrechen.UseVisualStyleBackColor = false;
            // 
            // kissLabel10
            // 
            this.kissLabel10.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel10.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel10.Location = new System.Drawing.Point(6, 6);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(100, 23);
            this.kissLabel10.TabIndex = 0;
            this.kissLabel10.Text = "Neuer Kreditor";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 3;
            this.label8.Text = "Kuerzel";
            // 
            // editKuerzel
            // 
            this.editKuerzel.EditValue = "";
            this.editKuerzel.Location = new System.Drawing.Point(114, 59);
            this.editKuerzel.Name = "editKuerzel";
            this.editKuerzel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editKuerzel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKuerzel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKuerzel.Properties.Appearance.Options.UseBackColor = true;
            this.editKuerzel.Properties.Appearance.Options.UseBorderColor = true;
            this.editKuerzel.Properties.Appearance.Options.UseFont = true;
            this.editKuerzel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKuerzel.Size = new System.Drawing.Size(289, 24);
            this.editKuerzel.TabIndex = 4;
            // 
            // editStrasse
            // 
            this.editStrasse.EditValue = "";
            this.editStrasse.Location = new System.Drawing.Point(114, 119);
            this.editStrasse.Name = "editStrasse";
            this.editStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.editStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.editStrasse.Properties.Appearance.Options.UseFont = true;
            this.editStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editStrasse.Properties.MaxLength = 30;
            this.editStrasse.Size = new System.Drawing.Size(289, 24);
            this.editStrasse.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Aufwand Konto";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "PLZ/Ort";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Strasse";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Zusatz";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // editZusatz
            // 
            this.editZusatz.EditValue = "";
            this.editZusatz.Location = new System.Drawing.Point(114, 89);
            this.editZusatz.Name = "editZusatz";
            this.editZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.editZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.editZusatz.Properties.Appearance.Options.UseFont = true;
            this.editZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editZusatz.Size = new System.Drawing.Size(289, 24);
            this.editZusatz.TabIndex = 6;
            // 
            // editName
            // 
            this.editName.EditValue = "";
            this.editName.Location = new System.Drawing.Point(114, 29);
            this.editName.Name = "editName";
            this.editName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editName.Properties.Appearance.Options.UseBackColor = true;
            this.editName.Properties.Appearance.Options.UseBorderColor = true;
            this.editName.Properties.Appearance.Options.UseFont = true;
            this.editName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editName.Properties.MaxLength = 30;
            this.editName.Size = new System.Drawing.Size(289, 24);
            this.editName.TabIndex = 2;
            // 
            // btnNeuKreditorOk
            // 
            this.btnNeuKreditorOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeuKreditorOk.Location = new System.Drawing.Point(183, 209);
            this.btnNeuKreditorOk.Name = "btnNeuKreditorOk";
            this.btnNeuKreditorOk.Size = new System.Drawing.Size(107, 24);
            this.btnNeuKreditorOk.TabIndex = 14;
            this.btnNeuKreditorOk.Text = "OK";
            this.btnNeuKreditorOk.UseVisualStyleBackColor = false;
            this.btnNeuKreditorOk.Click += new System.EventHandler(this.btnNeuKreditorOk_Click);
            // 
            // DlgAuswahlFbZahlungsweg
            // 
            
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(919, 514);
            this.Controls.Add(this.tabControlSearch);
            this.Name = "DlgAuswahlFbZahlungsweg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auswahl Zahlungsweg";
            ((System.ComponentModel.ISupportInitialize)(this.qryFbKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbZahlungsweg)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFbKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbKreditor)).EndInit();
            this.panKreditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditoren)).EndInit();
            this.panZahlungsweg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungswege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbZahlungsweg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblIban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchIban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchAufwandKontoName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchAufwandKonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchZahlungsFrist.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchZahlungsArt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchZahlungsArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsfrist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchBankKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchPostKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankKontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostKontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchKurzName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurzname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufwandKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).EndInit();
            this.tpgNeuKreditor.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editAufwandKontoName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufwandKonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKuerzel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editName.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.ComponentModel.IContainer components;
        public KiSS4.DB.SqlQuery qryFbKreditor;
        public KiSS4.DB.SqlQuery qryFbZahlungsweg;
        private KiSS4.Gui.KissTabControlEx tabControlSearch;
        private SharpLibrary.WinControls.TabPageEx tpgListe;
        private System.Windows.Forms.Panel panel2;
        private KiSS4.Gui.KissTextEdit editStrasse;
        private KiSS4.Gui.KissLabel label5;
        private KiSS4.Gui.KissLabel label4;
        private KiSS4.Gui.KissLabel label3;
        private KiSS4.Gui.KissLabel label2;
        private KiSS4.Gui.KissLabel label1;
        private KiSS4.Gui.KissTextEdit editZusatz;
        private KiSS4.Gui.KissTextEdit editName;
        private KiSS4.Gui.KissTextEdit editKuerzel;
        private KiSS4.Gui.KissLabel label8;
        private KiSS4.Gui.KissLabel lblKreditor;
        private KiSS4.Gui.KissLabel lblAktiv;
        private KiSS4.Gui.KissLabel lblPlzOrt;
        private KiSS4.Gui.KissLabel lblZusatz;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblKurzname;
        private KiSS4.Gui.KissLabel lblStrasse;
        private KiSS4.Gui.KissLabel lblAufwandKonto;
        private KiSS4.Gui.KissLabel lblZahlungsweg;
        private KiSS4.Gui.KissLabel lblZahlungsfrist;
        private KiSS4.Gui.KissLabel lblBankKontoNr;
        private KiSS4.Gui.KissLabel lblBank;
        private KiSS4.Gui.KissLabel lblPostKontoNr;
        private KiSS4.Gui.KissLabel lblZahlungsart;
        private KiSS4.Common.KissPLZOrt edtSearchPLZOrt;
        private KiSS4.Gui.KissTextEdit edtSearchStrasse;
        private KiSS4.Gui.KissTextEdit edtSearchZusatz;
        private KiSS4.Gui.KissCheckEdit edtSearchAktiv;
        private KiSS4.Gui.KissTextEdit edtSearchKurzName;
        private KiSS4.Gui.KissButtonEdit edtSearchName;
        private KiSS4.Gui.KissTextEdit edtSearchBankKontoNr;
        private KiSS4.Gui.KissTextEdit edtSearchPostKontoNr;
        private KiSS4.Gui.KissButtonEdit edtSearchBank;
        private KiSS4.Gui.KissButton btnSuchen;
        private KiSS4.Gui.KissLookUpEdit edtSearchZahlungsArt;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissCalcEdit edtSearchZahlungsFrist;
        private KiSS4.Gui.KissButton btnNeueSuche;
        private SharpLibrary.WinControls.TabPageEx tpgSuchen;
        private System.Windows.Forms.Panel panel1;
        private SharpLibrary.WinControls.TabPageEx tpgNeuKreditor;
        private KiSS4.Gui.KissButton btnNeuKreditorOk;
        private KiSS4.Gui.KissButton btnNeuKreditorAbbrechen;
        private KiSS4.Gui.KissButton btnListeOK;
        private KiSS4.Gui.KissButton btnListeAbbruch;
        private KiSS4.Gui.KissTextEdit editAufwandKontoName;
        private KiSS4.Gui.KissButtonEdit editAufwandKonto;
        private KiSS4.Gui.KissTextEdit edtSearchAufwandKontoName;
        private KiSS4.Gui.KissButtonEdit edtSearchAufwandKonto;
        private KiSS4.Common.KissPLZOrt editPLZOrt;
        private KiSS4.Gui.KissGrid grdFbZahlungsweg;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFbZahlungsweg;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungsArt;
        private DevExpress.XtraGrid.Columns.GridColumn colPCKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBankKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBank;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungsFrist;
        private System.Windows.Forms.Panel panZahlungsweg;
        private KiSS4.Gui.KissLabel lblZahlungswege;
        private System.Windows.Forms.Panel panKreditor;
        private KiSS4.Gui.KissLabel lblKreditoren;
        private KiSS4.Gui.KissGrid grdFbKreditor;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFbKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colZusatz;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colAufwandKonto;
        private DevExpress.XtraGrid.Columns.GridColumn colKurzName;
        private Gui.KissLabel lblIban;
        private Gui.KissTextEdit edtSearchIban;
        private DevExpress.XtraGrid.Columns.GridColumn colIBAN;
    }
}
