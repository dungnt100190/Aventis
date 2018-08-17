namespace KiSS4.Schnittstellen.Abacus.Mitarbeiter
{
    partial class CtlAbaMitarbeiter
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
            this.lblUser = new KiSS4.Gui.KissLabel();
            this.grpLogin = new KiSS4.Gui.KissGroupBox();
            this.edtGeschaeftsbereich = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.edtMonth = new KiSS4.Gui.KissCalcEdit();
            this.edtYear = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.lblMandant = new KiSS4.Gui.KissLabel();
            this.edtUser = new KiSS4.Gui.KissTextEdit();
            this.edtPassword = new KiSS4.Gui.KissTextEdit();
            this.grdUsers = new KiSS4.Gui.KissGrid();
            this.qryXUser = new KiSS4.DB.SqlQuery(this.components);
            this.grvUsers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoImport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMitarbeiterNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtstag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbteilung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLohnTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAustritt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheckExport = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnSynchronisieren = new KiSS4.Gui.KissButton();
            this.btnSelectAll = new KiSS4.Gui.KissButton();
            this.btnDeselectAll = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblUser)).BeginInit();
            this.grpLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschaeftsbereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschaeftsbereich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckExport)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(286, 20);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(59, 24);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Benutzer";
            // 
            // grpLogin
            // 
            this.grpLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLogin.Controls.Add(this.edtGeschaeftsbereich);
            this.grpLogin.Controls.Add(this.kissLabel4);
            this.grpLogin.Controls.Add(this.kissLabel3);
            this.grpLogin.Controls.Add(this.edtMonth);
            this.grpLogin.Controls.Add(this.edtYear);
            this.grpLogin.Controls.Add(this.kissLabel2);
            this.grpLogin.Controls.Add(this.lblMandant);
            this.grpLogin.Controls.Add(this.edtUser);
            this.grpLogin.Controls.Add(this.edtPassword);
            this.grpLogin.Controls.Add(this.lblUser);
            this.grpLogin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpLogin.Location = new System.Drawing.Point(63, 3);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(749, 85);
            this.grpLogin.TabIndex = 0;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "Login Abacus";
            // 
            // edtGeschaeftsbereich
            // 
            this.edtGeschaeftsbereich.Location = new System.Drawing.Point(69, 20);
            this.edtGeschaeftsbereich.Name = "edtGeschaeftsbereich";
            this.edtGeschaeftsbereich.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeschaeftsbereich.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeschaeftsbereich.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschaeftsbereich.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeschaeftsbereich.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeschaeftsbereich.Properties.Appearance.Options.UseFont = true;
            this.edtGeschaeftsbereich.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGeschaeftsbereich.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschaeftsbereich.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGeschaeftsbereich.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGeschaeftsbereich.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGeschaeftsbereich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGeschaeftsbereich.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeschaeftsbereich.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtGeschaeftsbereich.Properties.DisplayMember = "Text";
            this.edtGeschaeftsbereich.Properties.NullText = "";
            this.edtGeschaeftsbereich.Properties.ShowFooter = false;
            this.edtGeschaeftsbereich.Properties.ShowHeader = false;
            this.edtGeschaeftsbereich.Properties.ValueMember = "Code";
            this.edtGeschaeftsbereich.Size = new System.Drawing.Size(200, 24);
            this.edtGeschaeftsbereich.TabIndex = 1;
            this.edtGeschaeftsbereich.EditValueChanged += new System.EventHandler(this.edtGeschaeftsbereich_EditValueChanged);
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(6, 50);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(57, 24);
            this.kissLabel4.TabIndex = 6;
            this.kissLabel4.Text = "Jahr";
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(146, 50);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(47, 24);
            this.kissLabel3.TabIndex = 8;
            this.kissLabel3.Text = "Monat";
            // 
            // edtMonth
            // 
            this.edtMonth.Location = new System.Drawing.Point(199, 50);
            this.edtMonth.Name = "edtMonth";
            this.edtMonth.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtMonth.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMonth.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMonth.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMonth.Properties.Appearance.Options.UseBackColor = true;
            this.edtMonth.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMonth.Properties.Appearance.Options.UseFont = true;
            this.edtMonth.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMonth.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMonth.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtMonth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtMonth.Properties.Mask.EditMask = "##";
            this.edtMonth.Properties.Precision = 0;
            this.edtMonth.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtMonth.Size = new System.Drawing.Size(70, 24);
            this.edtMonth.TabIndex = 9;
            // 
            // edtYear
            // 
            this.edtYear.Location = new System.Drawing.Point(69, 50);
            this.edtYear.Name = "edtYear";
            this.edtYear.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtYear.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtYear.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtYear.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtYear.Properties.Appearance.Options.UseBackColor = true;
            this.edtYear.Properties.Appearance.Options.UseBorderColor = true;
            this.edtYear.Properties.Appearance.Options.UseFont = true;
            this.edtYear.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtYear.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtYear.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtYear.Properties.Mask.EditMask = "####";
            this.edtYear.Properties.Precision = 0;
            this.edtYear.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtYear.Size = new System.Drawing.Size(70, 24);
            this.edtYear.TabIndex = 7;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(482, 20);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(72, 24);
            this.kissLabel2.TabIndex = 4;
            this.kissLabel2.Text = "Passwort";
            // 
            // lblMandant
            // 
            this.lblMandant.Location = new System.Drawing.Point(6, 20);
            this.lblMandant.Name = "lblMandant";
            this.lblMandant.Size = new System.Drawing.Size(57, 24);
            this.lblMandant.TabIndex = 0;
            this.lblMandant.Text = "Mandant";
            // 
            // edtUser
            // 
            this.edtUser.Location = new System.Drawing.Point(351, 20);
            this.edtUser.Name = "edtUser";
            this.edtUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUser.Properties.Appearance.Options.UseBackColor = true;
            this.edtUser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUser.Properties.Appearance.Options.UseFont = true;
            this.edtUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUser.Size = new System.Drawing.Size(125, 24);
            this.edtUser.TabIndex = 3;
            // 
            // edtPassword
            // 
            this.edtPassword.Location = new System.Drawing.Point(560, 20);
            this.edtPassword.Name = "edtPassword";
            this.edtPassword.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPassword.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPassword.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPassword.Properties.Appearance.Options.UseBackColor = true;
            this.edtPassword.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPassword.Properties.Appearance.Options.UseFont = true;
            this.edtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPassword.Properties.PasswordChar = '*';
            this.edtPassword.Size = new System.Drawing.Size(125, 24);
            this.edtPassword.TabIndex = 5;
            // 
            // grdUsers
            // 
            this.grdUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUsers.DataSource = this.qryXUser;
            // 
            // 
            // 
            this.grdUsers.EmbeddedNavigator.Name = "";
            this.grdUsers.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdUsers.Location = new System.Drawing.Point(3, 94);
            this.grdUsers.MainView = this.grvUsers;
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCheckExport});
            this.grdUsers.Size = new System.Drawing.Size(809, 373);
            this.grdUsers.TabIndex = 1;
            this.grdUsers.TabStop = false;
            this.grdUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUsers});
            // 
            // qryXUser
            // 
            this.qryXUser.BatchUpdate = true;
            this.qryXUser.CanUpdate = true;
            this.qryXUser.HostControl = this;
            this.qryXUser.BeforePost += new System.EventHandler(this.qryXUser_BeforePost);
            // 
            // grvUsers
            // 
            this.grvUsers.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvUsers.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.Empty.Options.UseBackColor = true;
            this.grvUsers.Appearance.Empty.Options.UseFont = true;
            this.grvUsers.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvUsers.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvUsers.Appearance.EvenRow.Options.UseFont = true;
            this.grvUsers.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvUsers.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvUsers.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvUsers.Appearance.FocusedCell.Options.UseFont = true;
            this.grvUsers.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvUsers.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvUsers.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvUsers.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvUsers.Appearance.FocusedRow.Options.UseFont = true;
            this.grvUsers.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvUsers.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvUsers.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvUsers.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvUsers.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvUsers.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvUsers.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvUsers.Appearance.GroupRow.Options.UseFont = true;
            this.grvUsers.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvUsers.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvUsers.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvUsers.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvUsers.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvUsers.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvUsers.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvUsers.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvUsers.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvUsers.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvUsers.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvUsers.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvUsers.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvUsers.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvUsers.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.OddRow.Options.UseFont = true;
            this.grvUsers.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvUsers.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.Row.Options.UseBackColor = true;
            this.grvUsers.Appearance.Row.Options.UseFont = true;
            this.grvUsers.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvUsers.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUsers.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvUsers.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvUsers.Appearance.SelectedRow.Options.UseFont = true;
            this.grvUsers.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvUsers.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvUsers.Appearance.VertLine.Options.UseBackColor = true;
            this.grvUsers.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvUsers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserID,
            this.colDoImport,
            this.colMitarbeiterNr,
            this.colName,
            this.colVorname,
            this.colGeburtstag,
            this.colAbteilung,
            this.colLohnTyp,
            this.colAustritt,
            this.colStatus});
            this.grvUsers.GridControl = this.grdUsers;
            this.grvUsers.Name = "grvUsers";
            this.grvUsers.OptionsCustomization.AllowFilter = false;
            this.grvUsers.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvUsers.OptionsNavigation.AutoFocusNewRow = true;
            this.grvUsers.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvUsers.OptionsView.ColumnAutoWidth = false;
            this.grvUsers.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvUsers.OptionsView.ShowGroupPanel = false;
            // 
            // colUserID
            // 
            this.colUserID.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colUserID.AppearanceCell.Options.UseBackColor = true;
            this.colUserID.Caption = "ID";
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.OptionsColumn.AllowEdit = false;
            this.colUserID.OptionsColumn.AllowFocus = false;
            this.colUserID.OptionsColumn.ReadOnly = true;
            this.colUserID.Width = 76;
            // 
            // colDoImport
            // 
            this.colDoImport.Caption = "Import";
            this.colDoImport.FieldName = "DoImport";
            this.colDoImport.Name = "colDoImport";
            this.colDoImport.Visible = true;
            this.colDoImport.VisibleIndex = 0;
            this.colDoImport.Width = 76;
            // 
            // colMitarbeiterNr
            // 
            this.colMitarbeiterNr.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colMitarbeiterNr.AppearanceCell.Options.UseBackColor = true;
            this.colMitarbeiterNr.Caption = "Mitarbeiter-Nr.";
            this.colMitarbeiterNr.FieldName = "MitarbeiterNr";
            this.colMitarbeiterNr.Name = "colMitarbeiterNr";
            this.colMitarbeiterNr.OptionsColumn.AllowEdit = false;
            this.colMitarbeiterNr.OptionsColumn.AllowFocus = false;
            this.colMitarbeiterNr.OptionsColumn.ReadOnly = true;
            this.colMitarbeiterNr.Visible = true;
            this.colMitarbeiterNr.VisibleIndex = 1;
            this.colMitarbeiterNr.Width = 92;
            // 
            // colName
            // 
            this.colName.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colName.AppearanceCell.Options.UseBackColor = true;
            this.colName.Caption = "Name";
            this.colName.FieldName = "Lastname";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowFocus = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 100;
            // 
            // colVorname
            // 
            this.colVorname.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colVorname.AppearanceCell.Options.UseBackColor = true;
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Firstname";
            this.colVorname.Name = "colVorname";
            this.colVorname.OptionsColumn.AllowEdit = false;
            this.colVorname.OptionsColumn.AllowFocus = false;
            this.colVorname.OptionsColumn.ReadOnly = true;
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 3;
            this.colVorname.Width = 100;
            // 
            // colGeburtstag
            // 
            this.colGeburtstag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colGeburtstag.AppearanceCell.Options.UseBackColor = true;
            this.colGeburtstag.Caption = "Geburtstag";
            this.colGeburtstag.FieldName = "Geburtstag";
            this.colGeburtstag.Name = "colGeburtstag";
            this.colGeburtstag.OptionsColumn.AllowEdit = false;
            this.colGeburtstag.OptionsColumn.AllowFocus = false;
            this.colGeburtstag.OptionsColumn.ReadOnly = true;
            this.colGeburtstag.Visible = true;
            this.colGeburtstag.VisibleIndex = 4;
            this.colGeburtstag.Width = 74;
            // 
            // colAbteilung
            // 
            this.colAbteilung.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colAbteilung.AppearanceCell.Options.UseBackColor = true;
            this.colAbteilung.Caption = "Abteilung";
            this.colAbteilung.FieldName = "Abteilung";
            this.colAbteilung.Name = "colAbteilung";
            this.colAbteilung.OptionsColumn.AllowEdit = false;
            this.colAbteilung.OptionsColumn.AllowFocus = false;
            this.colAbteilung.OptionsColumn.ReadOnly = true;
            this.colAbteilung.Visible = true;
            this.colAbteilung.VisibleIndex = 5;
            this.colAbteilung.Width = 160;
            // 
            // colLohnTyp
            // 
            this.colLohnTyp.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colLohnTyp.AppearanceCell.Options.UseBackColor = true;
            this.colLohnTyp.Caption = "Lohntyp";
            this.colLohnTyp.FieldName = "Lohntyp";
            this.colLohnTyp.Name = "colLohnTyp";
            this.colLohnTyp.OptionsColumn.AllowEdit = false;
            this.colLohnTyp.OptionsColumn.AllowFocus = false;
            this.colLohnTyp.OptionsColumn.ReadOnly = true;
            this.colLohnTyp.Visible = true;
            this.colLohnTyp.VisibleIndex = 6;
            this.colLohnTyp.Width = 57;
            // 
            // colAustritt
            // 
            this.colAustritt.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colAustritt.AppearanceCell.Options.UseBackColor = true;
            this.colAustritt.Caption = "Austritt";
            this.colAustritt.FieldName = "Austrittsdatum";
            this.colAustritt.Name = "colAustritt";
            this.colAustritt.OptionsColumn.AllowEdit = false;
            this.colAustritt.OptionsColumn.AllowFocus = false;
            this.colAustritt.OptionsColumn.ReadOnly = true;
            this.colAustritt.Visible = true;
            this.colAustritt.VisibleIndex = 7;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colStatus.AppearanceCell.Options.UseBackColor = true;
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.OptionsColumn.AllowFocus = false;
            this.colStatus.OptionsColumn.ReadOnly = true;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 8;
            this.colStatus.Width = 200;
            // 
            // repCheckExport
            // 
            this.repCheckExport.AutoHeight = false;
            this.repCheckExport.Name = "repCheckExport";
            // 
            // btnSynchronisieren
            // 
            this.btnSynchronisieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSynchronisieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSynchronisieren.Location = new System.Drawing.Point(3, 473);
            this.btnSynchronisieren.Name = "btnSynchronisieren";
            this.btnSynchronisieren.Size = new System.Drawing.Size(182, 24);
            this.btnSynchronisieren.TabIndex = 2;
            this.btnSynchronisieren.Text = "Daten Synchronisieren";
            this.btnSynchronisieren.UseVisualStyleBackColor = false;
            this.btnSynchronisieren.Click += new System.EventHandler(this.btnSynchro_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.IconID = 74;
            this.btnSelectAll.Location = new System.Drawing.Point(3, 64);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(24, 24);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.UseCompatibleTextRendering = true;
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeselectAll.IconID = 75;
            this.btnDeselectAll.Location = new System.Drawing.Point(33, 64);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(24, 24);
            this.btnDeselectAll.TabIndex = 4;
            this.btnDeselectAll.UseCompatibleTextRendering = true;
            this.btnDeselectAll.UseVisualStyleBackColor = false;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // CtlAbaMitarbeiter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(815, 220);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnDeselectAll);
            this.Controls.Add(this.btnSynchronisieren);
            this.Controls.Add(this.grdUsers);
            this.Controls.Add(this.grpLogin);
            this.Name = "CtlAbaMitarbeiter";
            this.Size = new System.Drawing.Size(815, 500);
            this.Load += new System.EventHandler(this.CtlAbaMitarbeiter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblUser)).EndInit();
            this.grpLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschaeftsbereich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschaeftsbereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckExport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissLabel lblUser;
        private KiSS4.Gui.KissGroupBox grpLogin;
        private KiSS4.Gui.KissTextEdit edtPassword;
        private KiSS4.Gui.KissGrid grdUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUsers;
        private DevExpress.XtraGrid.Columns.GridColumn colDoImport;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckExport;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colAbteilung;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private KiSS4.DB.SqlQuery qryXUser;
        private KiSS4.Gui.KissTextEdit edtUser;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel lblMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colMitarbeiterNr;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtstag;
        private DevExpress.XtraGrid.Columns.GridColumn colLohnTyp;
        private KiSS4.Gui.KissButton btnSynchronisieren;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissCalcEdit edtMonth;
        private KiSS4.Gui.KissCalcEdit edtYear;
        private DevExpress.XtraGrid.Columns.GridColumn colAustritt;
        private Gui.KissLookUpEdit edtGeschaeftsbereich;
        private Gui.KissButton btnSelectAll;
        private Gui.KissButton btnDeselectAll;
    }
}
