namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten
{
	partial class CtlAbaKlientenStammdaten
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdKlientenStammdaten = new KiSS4.Gui.KissGrid();
            this.qryLoadKlientenByMandantID = new KiSS4.DB.SqlQuery(this.components);
            this.grvKlientenStammdaten = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDoExport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDoExport = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlzOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSachbearbeiter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlientenkontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebitorUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusInsUpd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpEinstellungen = new KiSS4.Gui.KissGroupBox();
            this.edtUserPassword = new KiSS4.Gui.KissTextEdit();
            this.edtUserName = new KiSS4.Gui.KissTextEdit();
            this.edtSelectMandant = new KiSS4.Gui.KissLookUpEdit();
            this.qryLoadMandanten = new KiSS4.DB.SqlQuery(this.components);
            this.lblUserPassword = new KiSS4.Gui.KissLabel();
            this.lblUserName = new KiSS4.Gui.KissLabel();
            this.lblSelectMandant = new KiSS4.Gui.KissLabel();
            this.qryLoadAllClientStatus = new KiSS4.DB.SqlQuery(this.components);
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.btnDatenExport = new KiSS4.Gui.KissButton();
            this.btnLoadKlienten = new KiSS4.Gui.KissButton();
            this.btnSelectAll = new KiSS4.Gui.KissButton();
            this.btnDeselectAll = new KiSS4.Gui.KissButton();
            this.btnInvertSelection = new KiSS4.Gui.KissButton();
            this.edtSelectMode = new KiSS4.Gui.KissLookUpEdit();
            this.btnSelectState = new KiSS4.Gui.KissButton();
            this.btnDeselectState = new KiSS4.Gui.KissButton();
            this.grpLoadData = new KiSS4.Gui.KissGroupBox();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.grpGrid = new KiSS4.Gui.KissGroupBox();
            this.lblSelectedRowsCount = new KiSS4.Gui.KissLabel();
            this.lblSelectByStatus = new KiSS4.Gui.KissLabel();
            this.grpExport = new KiSS4.Gui.KissGroupBox();
            this.pgbExport = new System.Windows.Forms.ProgressBar();
            this.lblStatusBar = new KiSS4.Gui.KissLabel();
            this.panBottom = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdKlientenStammdaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLoadKlientenByMandantID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKlientenStammdaten)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.qryLoadAllClientStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelectMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelectMode.Properties)).BeginInit();
            this.grpLoadData.SuspendLayout();
            this.grpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectedRowsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectByStatus)).BeginInit();
            this.grpExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusBar)).BeginInit();
            this.panBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdKlientenStammdaten
            // 
            this.grdKlientenStammdaten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKlientenStammdaten.DataSource = this.qryLoadKlientenByMandantID;
            // 
            // 
            // 
            this.grdKlientenStammdaten.EmbeddedNavigator.Name = "";
            this.grdKlientenStammdaten.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdKlientenStammdaten.Location = new System.Drawing.Point(6, 51);
            this.grdKlientenStammdaten.MainView = this.grvKlientenStammdaten;
            this.grdKlientenStammdaten.Name = "grdKlientenStammdaten";
            this.grdKlientenStammdaten.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repDoExport});
            this.grdKlientenStammdaten.Size = new System.Drawing.Size(733, 362);
            this.grdKlientenStammdaten.TabIndex = 8;
            this.grdKlientenStammdaten.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKlientenStammdaten});
            // 
            // qryLoadKlientenByMandantID
            // 
            this.qryLoadKlientenByMandantID.BatchUpdate = true;
            this.qryLoadKlientenByMandantID.CanUpdate = true;
            this.qryLoadKlientenByMandantID.HostControl = this;
            this.qryLoadKlientenByMandantID.AfterFill += new System.EventHandler(this.qryLoadKlientenByMandantID_AfterFill);
            this.qryLoadKlientenByMandantID.PositionChanged += new System.EventHandler(this.qryLoadKlientenByMandantID_PositionChanged);
            // 
            // grvKlientenStammdaten
            // 
            this.grvKlientenStammdaten.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKlientenStammdaten.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientenStammdaten.Appearance.Empty.Options.UseBackColor = true;
            this.grvKlientenStammdaten.Appearance.Empty.Options.UseFont = true;
            this.grvKlientenStammdaten.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKlientenStammdaten.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientenStammdaten.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKlientenStammdaten.Appearance.EvenRow.Options.UseFont = true;
            this.grvKlientenStammdaten.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKlientenStammdaten.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientenStammdaten.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvKlientenStammdaten.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKlientenStammdaten.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKlientenStammdaten.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKlientenStammdaten.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKlientenStammdaten.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientenStammdaten.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKlientenStammdaten.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKlientenStammdaten.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKlientenStammdaten.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKlientenStammdaten.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKlientenStammdaten.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKlientenStammdaten.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKlientenStammdaten.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKlientenStammdaten.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKlientenStammdaten.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKlientenStammdaten.Appearance.GroupRow.Options.UseFont = true;
            this.grvKlientenStammdaten.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKlientenStammdaten.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKlientenStammdaten.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKlientenStammdaten.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKlientenStammdaten.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKlientenStammdaten.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKlientenStammdaten.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKlientenStammdaten.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKlientenStammdaten.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientenStammdaten.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKlientenStammdaten.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKlientenStammdaten.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKlientenStammdaten.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKlientenStammdaten.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvKlientenStammdaten.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKlientenStammdaten.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientenStammdaten.Appearance.OddRow.Options.UseFont = true;
            this.grvKlientenStammdaten.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKlientenStammdaten.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientenStammdaten.Appearance.Row.Options.UseBackColor = true;
            this.grvKlientenStammdaten.Appearance.Row.Options.UseFont = true;
            this.grvKlientenStammdaten.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKlientenStammdaten.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientenStammdaten.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKlientenStammdaten.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKlientenStammdaten.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKlientenStammdaten.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKlientenStammdaten.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvKlientenStammdaten.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKlientenStammdaten.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKlientenStammdaten.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDoExport,
            this.colName,
            this.colVorname,
            this.colPlzOrt,
            this.colOrgUnit,
            this.colSachbearbeiter,
            this.colKlientenkontoNr,
            this.colDebitorUpdate,
            this.colStatusInsUpd});
            this.grvKlientenStammdaten.GridControl = this.grdKlientenStammdaten;
            this.grvKlientenStammdaten.Name = "grvKlientenStammdaten";
            this.grvKlientenStammdaten.OptionsCustomization.AllowFilter = false;
            this.grvKlientenStammdaten.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKlientenStammdaten.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKlientenStammdaten.OptionsView.ColumnAutoWidth = false;
            this.grvKlientenStammdaten.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKlientenStammdaten.OptionsView.ShowGroupPanel = false;
            this.grvKlientenStammdaten.LostFocus += new System.EventHandler(this.grvKlientenStammdaten_LostFocus);
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
            // colPlzOrt
            // 
            this.colPlzOrt.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colPlzOrt.AppearanceCell.Options.UseBackColor = true;
            this.colPlzOrt.Caption = "PLZ / Ort";
            this.colPlzOrt.FieldName = "PlzOrt";
            this.colPlzOrt.Name = "colPlzOrt";
            this.colPlzOrt.OptionsColumn.AllowEdit = false;
            this.colPlzOrt.Visible = true;
            this.colPlzOrt.VisibleIndex = 3;
            this.colPlzOrt.Width = 200;
            // 
            // colOrgUnit
            // 
            this.colOrgUnit.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colOrgUnit.AppearanceCell.Options.UseBackColor = true;
            this.colOrgUnit.Caption = "Abteilung";
            this.colOrgUnit.FieldName = "ItemName";
            this.colOrgUnit.Name = "colOrgUnit";
            this.colOrgUnit.OptionsColumn.AllowEdit = false;
            this.colOrgUnit.Visible = true;
            this.colOrgUnit.VisibleIndex = 4;
            this.colOrgUnit.Width = 120;
            // 
            // colSachbearbeiter
            // 
            this.colSachbearbeiter.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colSachbearbeiter.AppearanceCell.Options.UseBackColor = true;
            this.colSachbearbeiter.Caption = "Sachbearbeiter";
            this.colSachbearbeiter.FieldName = "Sachbearbeiter";
            this.colSachbearbeiter.Name = "colSachbearbeiter";
            this.colSachbearbeiter.OptionsColumn.AllowEdit = false;
            this.colSachbearbeiter.Visible = true;
            this.colSachbearbeiter.VisibleIndex = 5;
            this.colSachbearbeiter.Width = 200;
            // 
            // colKlientenkontoNr
            // 
            this.colKlientenkontoNr.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKlientenkontoNr.AppearanceCell.Options.UseBackColor = true;
            this.colKlientenkontoNr.Caption = "Klientenkontonummer";
            this.colKlientenkontoNr.FieldName = "KlientenkontoNr";
            this.colKlientenkontoNr.Name = "colKlientenkontoNr";
            this.colKlientenkontoNr.OptionsColumn.AllowEdit = false;
            this.colKlientenkontoNr.Visible = true;
            this.colKlientenkontoNr.VisibleIndex = 6;
            this.colKlientenkontoNr.Width = 100;
            // 
            // colDebitorUpdate
            // 
            this.colDebitorUpdate.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDebitorUpdate.AppearanceCell.Options.UseBackColor = true;
            this.colDebitorUpdate.Caption = "letztes Update";
            this.colDebitorUpdate.FieldName = "DebitorUpdate";
            this.colDebitorUpdate.Name = "colDebitorUpdate";
            this.colDebitorUpdate.OptionsColumn.AllowEdit = false;
            this.colDebitorUpdate.Visible = true;
            this.colDebitorUpdate.VisibleIndex = 7;
            this.colDebitorUpdate.Width = 100;
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
            this.colStatusInsUpd.VisibleIndex = 8;
            this.colStatusInsUpd.Width = 300;
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
            this.grpEinstellungen.Size = new System.Drawing.Size(748, 52);
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
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSelectMandant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
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
            // qryLoadAllClientStatus
            // 
            this.qryLoadAllClientStatus.HostControl = this;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(649, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 24);
            this.btnCancel.TabIndex = 1;
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
            // btnLoadKlienten
            // 
            this.btnLoadKlienten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadKlienten.Location = new System.Drawing.Point(6, 20);
            this.btnLoadKlienten.Name = "btnLoadKlienten";
            this.btnLoadKlienten.Size = new System.Drawing.Size(129, 24);
            this.btnLoadKlienten.TabIndex = 0;
            this.btnLoadKlienten.Text = "&KiSS Daten laden";
            this.btnLoadKlienten.UseCompatibleTextRendering = true;
            this.btnLoadKlienten.UseVisualStyleBackColor = false;
            this.btnLoadKlienten.Click += new System.EventHandler(this.btnLoadKlienten_Click);
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
            // edtSelectMode
            // 
            this.edtSelectMode.Location = new System.Drawing.Point(278, 20);
            this.edtSelectMode.Name = "edtSelectMode";
            this.edtSelectMode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSelectMode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSelectMode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSelectMode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSelectMode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSelectMode.Properties.Appearance.Options.UseFont = true;
            this.edtSelectMode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSelectMode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSelectMode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSelectMode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSelectMode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSelectMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSelectMode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSelectMode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtSelectMode.Properties.DataSource = this.qryLoadAllClientStatus;
            this.edtSelectMode.Properties.DisplayMember = "Text";
            this.edtSelectMode.Properties.NullText = "";
            this.edtSelectMode.Properties.ShowFooter = false;
            this.edtSelectMode.Properties.ShowHeader = false;
            this.edtSelectMode.Properties.ValueMember = "Code";
            this.edtSelectMode.Size = new System.Drawing.Size(220, 24);
            this.edtSelectMode.TabIndex = 4;
            // 
            // btnSelectState
            // 
            this.btnSelectState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectState.IconID = 74;
            this.btnSelectState.Location = new System.Drawing.Point(504, 20);
            this.btnSelectState.Name = "btnSelectState";
            this.btnSelectState.Size = new System.Drawing.Size(24, 24);
            this.btnSelectState.TabIndex = 5;
            this.btnSelectState.UseCompatibleTextRendering = true;
            this.btnSelectState.UseVisualStyleBackColor = false;
            this.btnSelectState.Click += new System.EventHandler(this.btnSelectState_Click);
            // 
            // btnDeselectState
            // 
            this.btnDeselectState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeselectState.IconID = 75;
            this.btnDeselectState.Location = new System.Drawing.Point(534, 20);
            this.btnDeselectState.Name = "btnDeselectState";
            this.btnDeselectState.Size = new System.Drawing.Size(24, 24);
            this.btnDeselectState.TabIndex = 6;
            this.btnDeselectState.UseCompatibleTextRendering = true;
            this.btnDeselectState.UseVisualStyleBackColor = false;
            this.btnDeselectState.Click += new System.EventHandler(this.btnDeselectState_Click);
            // 
            // grpLoadData
            // 
            this.grpLoadData.Controls.Add(this.ctlGotoFall);
            this.grpLoadData.Controls.Add(this.btnLoadKlienten);
            this.grpLoadData.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLoadData.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpLoadData.Location = new System.Drawing.Point(0, 52);
            this.grpLoadData.Name = "grpLoadData";
            this.grpLoadData.Size = new System.Drawing.Size(748, 52);
            this.grpLoadData.TabIndex = 1;
            this.grpLoadData.TabStop = false;
            this.grpLoadData.Text = "2. Daten laden";
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlGotoFall.Location = new System.Drawing.Point(529, 20);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(210, 24);
            this.ctlGotoFall.TabIndex = 1;
            // 
            // grpGrid
            // 
            this.grpGrid.Controls.Add(this.lblSelectedRowsCount);
            this.grpGrid.Controls.Add(this.lblSelectByStatus);
            this.grpGrid.Controls.Add(this.grdKlientenStammdaten);
            this.grpGrid.Controls.Add(this.btnDeselectState);
            this.grpGrid.Controls.Add(this.btnSelectAll);
            this.grpGrid.Controls.Add(this.btnSelectState);
            this.grpGrid.Controls.Add(this.btnDeselectAll);
            this.grpGrid.Controls.Add(this.edtSelectMode);
            this.grpGrid.Controls.Add(this.btnInvertSelection);
            this.grpGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGrid.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpGrid.Location = new System.Drawing.Point(0, 104);
            this.grpGrid.Name = "grpGrid";
            this.grpGrid.Size = new System.Drawing.Size(748, 419);
            this.grpGrid.TabIndex = 2;
            this.grpGrid.TabStop = false;
            this.grpGrid.Text = "3. Zu exportierende Klienten auswählen";
            // 
            // lblSelectedRowsCount
            // 
            this.lblSelectedRowsCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedRowsCount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSelectedRowsCount.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSelectedRowsCount.Location = new System.Drawing.Point(571, 20);
            this.lblSelectedRowsCount.Name = "lblSelectedRowsCount";
            this.lblSelectedRowsCount.Size = new System.Drawing.Size(165, 24);
            this.lblSelectedRowsCount.TabIndex = 7;
            this.lblSelectedRowsCount.Text = "<Sel> von <Count> Einträgen ausgewählt";
            this.lblSelectedRowsCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSelectByStatus
            // 
            this.lblSelectByStatus.Location = new System.Drawing.Point(148, 20);
            this.lblSelectByStatus.Name = "lblSelectByStatus";
            this.lblSelectByStatus.Size = new System.Drawing.Size(124, 24);
            this.lblSelectByStatus.TabIndex = 3;
            this.lblSelectByStatus.Text = "Auswahl nach Status";
            // 
            // grpExport
            // 
            this.grpExport.Controls.Add(this.btnCancel);
            this.grpExport.Controls.Add(this.btnDatenExport);
            this.grpExport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpExport.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpExport.Location = new System.Drawing.Point(0, 523);
            this.grpExport.Name = "grpExport";
            this.grpExport.Size = new System.Drawing.Size(748, 55);
            this.grpExport.TabIndex = 3;
            this.grpExport.TabStop = false;
            this.grpExport.Text = "4. Export ausführen";
            // 
            // pgbExport
            // 
            this.pgbExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.pgbExport.Location = new System.Drawing.Point(539, 0);
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
            this.lblStatusBar.Size = new System.Drawing.Size(539, 18);
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
            this.panBottom.Size = new System.Drawing.Size(748, 18);
            this.panBottom.TabIndex = 4;
            // 
            // CtlAbaKlientenStammdaten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpGrid);
            this.Controls.Add(this.grpExport);
            this.Controls.Add(this.grpLoadData);
            this.Controls.Add(this.grpEinstellungen);
            this.Controls.Add(this.panBottom);
            this.Name = "CtlAbaKlientenStammdaten";
            this.Size = new System.Drawing.Size(748, 596);
            this.Load += new System.EventHandler(this.CtlAbaKlientenStammdaten_Load);
            this.Leave += new System.EventHandler(this.CtlAbaKlientenStammdaten_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.grdKlientenStammdaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLoadKlientenByMandantID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKlientenStammdaten)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.qryLoadAllClientStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelectMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelectMode)).EndInit();
            this.grpLoadData.ResumeLayout(false);
            this.grpGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectedRowsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectByStatus)).EndInit();
            this.grpExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusBar)).EndInit();
            this.panBottom.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private KiSS4.Gui.KissGrid grdKlientenStammdaten;
		private DevExpress.XtraGrid.Views.Grid.GridView grvKlientenStammdaten;
		private DevExpress.XtraGrid.Columns.GridColumn colDoExport;
		private DevExpress.XtraGrid.Columns.GridColumn colName;
		private DevExpress.XtraGrid.Columns.GridColumn colVorname;
		private DevExpress.XtraGrid.Columns.GridColumn colPlzOrt;
		private DevExpress.XtraGrid.Columns.GridColumn colOrgUnit;
		private DevExpress.XtraGrid.Columns.GridColumn colSachbearbeiter;
		private DevExpress.XtraGrid.Columns.GridColumn colKlientenkontoNr;
		private DevExpress.XtraGrid.Columns.GridColumn colDebitorUpdate;
		private DevExpress.XtraGrid.Columns.GridColumn colStatusInsUpd;
		private KiSS4.Gui.KissGroupBox grpEinstellungen;
		private KiSS4.Gui.KissButton btnDatenExport;
		private KiSS4.Gui.KissButton btnLoadKlienten;
		private KiSS4.Gui.KissButton btnCancel;
		private KiSS4.DB.SqlQuery qryLoadKlientenByMandantID;
		private KiSS4.Gui.KissButton btnInvertSelection;
		private KiSS4.Gui.KissButton btnDeselectAll;
		private KiSS4.Gui.KissButton btnSelectAll;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repDoExport;
		private KiSS4.Gui.KissLookUpEdit edtSelectMode;
		private KiSS4.Gui.KissButton btnSelectState;
		private KiSS4.Gui.KissButton btnDeselectState;
		private KiSS4.DB.SqlQuery qryLoadAllClientStatus;
		private KiSS4.Gui.KissLookUpEdit edtSelectMandant;
		private KiSS4.Gui.KissGroupBox grpLoadData;
		private KiSS4.Gui.KissGroupBox grpGrid;
		private KiSS4.Gui.KissLabel lblStatusBar;
		private KiSS4.Gui.KissGroupBox grpExport;
		private KiSS4.DB.SqlQuery qryLoadMandanten;
		private System.Windows.Forms.ProgressBar pgbExport;
		private KiSS4.Gui.KissLabel lblSelectByStatus;
		private KiSS4.Gui.KissLabel lblSelectedRowsCount;
		private KiSS4.Gui.KissTextEdit edtUserName;
		private KiSS4.Gui.KissLabel lblUserPassword;
		private KiSS4.Gui.KissLabel lblUserName;
		private KiSS4.Gui.KissLabel lblSelectMandant;
		private KiSS4.Gui.KissTextEdit edtUserPassword;
		private System.Windows.Forms.Panel panBottom;
		private KiSS4.Common.CtlGotoFall ctlGotoFall;
	}
}
