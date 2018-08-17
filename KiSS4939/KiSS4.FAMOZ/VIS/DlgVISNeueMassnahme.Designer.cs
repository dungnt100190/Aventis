namespace KiSS4.FAMOZ.VIS
{
    partial class DlgVISNeueMassnahme
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgVISNeueMassnahme));
            this.btnOK = new KiSS4.Gui.KissButton();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.grdVISMassnahmen = new KiSS4.Gui.KissGrid();
            this.qryVISMassnahmen = new KiSS4.DB.SqlQuery();
            this.grvPerson = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVormschID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnordnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAufhebung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMassnahme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandatstyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVMExist = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblKiSSPerson = new KiSS4.Gui.KissLabel();
            this.edtPerson = new KiSS4.Gui.KissTextEdit();
            this.qryBaPerson = new KiSS4.DB.SqlQuery();
            this.lblZipNr = new KiSS4.Gui.KissLabel();
            this.edtZIPnr = new KiSS4.Gui.KissTextEdit();
            this.lblVISFallNr = new KiSS4.Gui.KissLabel();
            this.lblVISMandant = new KiSS4.Gui.KissLabel();
            this.edtVISMandant = new KiSS4.Gui.KissTextEdit();
            this.lblMassnahmen = new KiSS4.Gui.KissLabel();
            this.grpVIS = new KiSS4.Gui.KissGroupBox();
            this.edtVISFallNr = new KiSS4.Gui.KissCalcEdit();
            this.btnVISMassnahmenLaden = new KiSS4.Gui.KissButton();
            this.edtInklAufgehobeneMassnahme = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVISMassnahmen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVISMassnahmen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKiSSPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZipNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZIPnr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVISFallNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVISMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVISMandant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMassnahmen)).BeginInit();
            this.grpVIS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtVISFallNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklAufgehobeneMassnahme.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(393, 341);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(206, 24);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Neue M-Leistung im KiSS erstellen";
            this.btnOK.UseCompatibleTextRendering = true;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(605, 341);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseCompatibleTextRendering = true;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grdVISMassnahmen
            // 
            this.grdVISMassnahmen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVISMassnahmen.DataSource = this.qryVISMassnahmen;
            // 
            // 
            // 
            this.grdVISMassnahmen.EmbeddedNavigator.Name = "";
            this.grdVISMassnahmen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVISMassnahmen.Location = new System.Drawing.Point(6, 112);
            this.grdVISMassnahmen.MainView = this.grvPerson;
            this.grdVISMassnahmen.Name = "grdVISMassnahmen";
            this.grdVISMassnahmen.Size = new System.Drawing.Size(651, 116);
            this.grdVISMassnahmen.TabIndex = 3;
            this.grdVISMassnahmen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPerson});
            // 
            // qryVISMassnahmen
            // 
            this.qryVISMassnahmen.HostControl = this;
            this.qryVISMassnahmen.SelectStatement = resources.GetString("qryVISMassnahmen.SelectStatement");
            this.qryVISMassnahmen.TableName = "vwVIS_MASSNAHMEN";
            // 
            // grvPerson
            // 
            this.grvPerson.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvPerson.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPerson.Appearance.Empty.Options.UseBackColor = true;
            this.grvPerson.Appearance.Empty.Options.UseFont = true;
            this.grvPerson.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPerson.Appearance.EvenRow.Options.UseFont = true;
            this.grvPerson.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPerson.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPerson.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvPerson.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvPerson.Appearance.FocusedCell.Options.UseFont = true;
            this.grvPerson.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvPerson.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPerson.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPerson.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvPerson.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvPerson.Appearance.FocusedRow.Options.UseFont = true;
            this.grvPerson.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvPerson.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPerson.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPerson.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvPerson.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvPerson.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPerson.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvPerson.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPerson.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPerson.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPerson.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvPerson.Appearance.GroupRow.Options.UseFont = true;
            this.grvPerson.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvPerson.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvPerson.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvPerson.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPerson.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvPerson.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvPerson.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPerson.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvPerson.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPerson.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPerson.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPerson.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvPerson.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvPerson.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvPerson.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvPerson.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPerson.Appearance.OddRow.Options.UseFont = true;
            this.grvPerson.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPerson.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPerson.Appearance.Row.Options.UseBackColor = true;
            this.grvPerson.Appearance.Row.Options.UseFont = true;
            this.grvPerson.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPerson.Appearance.SelectedRow.Options.UseFont = true;
            this.grvPerson.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvPerson.Appearance.VertLine.Options.UseBackColor = true;
            this.grvPerson.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvPerson.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVormschID,
            this.colAnordnung,
            this.colAufhebung,
            this.colMassnahme,
            this.colMandatstyp,
            this.colVMExist});
            this.grvPerson.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvPerson.GridControl = this.grdVISMassnahmen;
            this.grvPerson.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvPerson.Name = "grvPerson";
            this.grvPerson.OptionsBehavior.Editable = false;
            this.grvPerson.OptionsCustomization.AllowFilter = false;
            this.grvPerson.OptionsFilter.AllowFilterEditor = false;
            this.grvPerson.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPerson.OptionsMenu.EnableColumnMenu = false;
            this.grvPerson.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPerson.OptionsNavigation.UseTabKey = false;
            this.grvPerson.OptionsView.ColumnAutoWidth = false;
            this.grvPerson.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPerson.OptionsView.ShowGroupPanel = false;
            this.grvPerson.OptionsView.ShowIndicator = false;
            // 
            // colVormschID
            // 
            this.colVormschID.Caption = "Vormsch ID";
            this.colVormschID.FieldName = "VormschID";
            this.colVormschID.Name = "colVormschID";
            this.colVormschID.Visible = true;
            this.colVormschID.VisibleIndex = 0;
            this.colVormschID.Width = 80;
            // 
            // colAnordnung
            // 
            this.colAnordnung.Caption = "Anordnung";
            this.colAnordnung.FieldName = "Anordnung";
            this.colAnordnung.Name = "colAnordnung";
            this.colAnordnung.Visible = true;
            this.colAnordnung.VisibleIndex = 1;
            // 
            // colAufhebung
            // 
            this.colAufhebung.Caption = "Aufhebung";
            this.colAufhebung.FieldName = "Aufhebung";
            this.colAufhebung.Name = "colAufhebung";
            this.colAufhebung.Visible = true;
            this.colAufhebung.VisibleIndex = 2;
            // 
            // colMassnahme
            // 
            this.colMassnahme.Caption = "Massnahme";
            this.colMassnahme.FieldName = "Massnahme";
            this.colMassnahme.Name = "colMassnahme";
            this.colMassnahme.Visible = true;
            this.colMassnahme.VisibleIndex = 3;
            this.colMassnahme.Width = 138;
            // 
            // colMandatstyp
            // 
            this.colMandatstyp.Caption = "Behördliche Massnahme";
            this.colMandatstyp.FieldName = "Behördliche Massnahme";
            this.colMandatstyp.Name = "colMandatstyp";
            this.colMandatstyp.Visible = true;
            this.colMandatstyp.VisibleIndex = 4;
            this.colMandatstyp.Width = 152;
            // 
            // colVMExist
            // 
            this.colVMExist.Caption = "KES-Massn. exist.";
            this.colVMExist.FieldName = "VMExist";
            this.colVMExist.Name = "colVMExist";
            this.colVMExist.Visible = true;
            this.colVMExist.VisibleIndex = 5;
            this.colVMExist.Width = 110;
            // 
            // lblKiSSPerson
            // 
            this.lblKiSSPerson.Location = new System.Drawing.Point(12, 12);
            this.lblKiSSPerson.Name = "lblKiSSPerson";
            this.lblKiSSPerson.Size = new System.Drawing.Size(86, 24);
            this.lblKiSSPerson.TabIndex = 23;
            this.lblKiSSPerson.Text = "Person";
            this.lblKiSSPerson.UseCompatibleTextRendering = true;
            // 
            // edtPerson
            // 
            this.edtPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPerson.DataMember = "Person";
            this.edtPerson.DataSource = this.qryBaPerson;
            this.edtPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPerson.Location = new System.Drawing.Point(99, 12);
            this.edtPerson.Name = "edtPerson";
            this.edtPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPerson.Properties.Appearance.Options.UseFont = true;
            this.edtPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPerson.Properties.ReadOnly = true;
            this.edtPerson.Size = new System.Drawing.Size(570, 24);
            this.edtPerson.TabIndex = 0;
            // 
            // qryBaPerson
            // 
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.SelectStatement = "SELECT \r\n\tPerson = DisplayText + \' (\' + CONVERT(varchar, BaPersonID) + \')\',\r\n\tZIP" +
    "Nr = ZIPNr\r\nFROM vwPerson\r\nWHERE BaPersonID = {0}";
            this.qryBaPerson.TableName = "BaPerson";
            // 
            // lblZipNr
            // 
            this.lblZipNr.Location = new System.Drawing.Point(12, 42);
            this.lblZipNr.Name = "lblZipNr";
            this.lblZipNr.Size = new System.Drawing.Size(86, 24);
            this.lblZipNr.TabIndex = 25;
            this.lblZipNr.Text = "PID";
            this.lblZipNr.UseCompatibleTextRendering = true;
            // 
            // edtZIPnr
            // 
            this.edtZIPnr.DataMember = "ZIPNr";
            this.edtZIPnr.DataSource = this.qryBaPerson;
            this.edtZIPnr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZIPnr.Location = new System.Drawing.Point(99, 42);
            this.edtZIPnr.Name = "edtZIPnr";
            this.edtZIPnr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZIPnr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZIPnr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZIPnr.Properties.Appearance.Options.UseBackColor = true;
            this.edtZIPnr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZIPnr.Properties.Appearance.Options.UseFont = true;
            this.edtZIPnr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZIPnr.Properties.ReadOnly = true;
            this.edtZIPnr.Size = new System.Drawing.Size(155, 24);
            this.edtZIPnr.TabIndex = 1;
            // 
            // lblVISFallNr
            // 
            this.lblVISFallNr.Location = new System.Drawing.Point(6, 21);
            this.lblVISFallNr.Name = "lblVISFallNr";
            this.lblVISFallNr.Size = new System.Drawing.Size(75, 24);
            this.lblVISFallNr.TabIndex = 30;
            this.lblVISFallNr.Text = "VIS Fall Nr.";
            this.lblVISFallNr.UseCompatibleTextRendering = true;
            // 
            // lblVISMandant
            // 
            this.lblVISMandant.Location = new System.Drawing.Point(6, 51);
            this.lblVISMandant.Name = "lblVISMandant";
            this.lblVISMandant.Size = new System.Drawing.Size(75, 24);
            this.lblVISMandant.TabIndex = 32;
            this.lblVISMandant.Text = "VIS Mandant";
            this.lblVISMandant.UseCompatibleTextRendering = true;
            // 
            // edtVISMandant
            // 
            this.edtVISMandant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtVISMandant.DataMember = "VISMandant";
            this.edtVISMandant.DataSource = this.qryVISMassnahmen;
            this.edtVISMandant.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVISMandant.Location = new System.Drawing.Point(87, 51);
            this.edtVISMandant.Name = "edtVISMandant";
            this.edtVISMandant.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVISMandant.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVISMandant.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVISMandant.Properties.Appearance.Options.UseBackColor = true;
            this.edtVISMandant.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVISMandant.Properties.Appearance.Options.UseFont = true;
            this.edtVISMandant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVISMandant.Properties.ReadOnly = true;
            this.edtVISMandant.Size = new System.Drawing.Size(570, 24);
            this.edtVISMandant.TabIndex = 2;
            // 
            // lblMassnahmen
            // 
            this.lblMassnahmen.Location = new System.Drawing.Point(6, 85);
            this.lblMassnahmen.Name = "lblMassnahmen";
            this.lblMassnahmen.Size = new System.Drawing.Size(358, 24);
            this.lblMassnahmen.TabIndex = 33;
            this.lblMassnahmen.Text = "Bitte selektieren Sie eine VIS-Massnahme dieses VIS-Falles:";
            this.lblMassnahmen.UseCompatibleTextRendering = true;
            // 
            // grpVIS
            // 
            this.grpVIS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVIS.Controls.Add(this.edtVISFallNr);
            this.grpVIS.Controls.Add(this.btnVISMassnahmenLaden);
            this.grpVIS.Controls.Add(this.lblVISFallNr);
            this.grpVIS.Controls.Add(this.lblMassnahmen);
            this.grpVIS.Controls.Add(this.grdVISMassnahmen);
            this.grpVIS.Controls.Add(this.lblVISMandant);
            this.grpVIS.Controls.Add(this.edtVISMandant);
            this.grpVIS.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpVIS.Location = new System.Drawing.Point(12, 90);
            this.grpVIS.Name = "grpVIS";
            this.grpVIS.Size = new System.Drawing.Size(676, 245);
            this.grpVIS.TabIndex = 2;
            this.grpVIS.TabStop = false;
            this.grpVIS.Text = "VIS Massnahme";
            // 
            // edtVISFallNr
            // 
            this.edtVISFallNr.DataMember = "VISFallNr";
            this.edtVISFallNr.Location = new System.Drawing.Point(87, 21);
            this.edtVISFallNr.Name = "edtVISFallNr";
            this.edtVISFallNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVISFallNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVISFallNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVISFallNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVISFallNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtVISFallNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVISFallNr.Properties.Appearance.Options.UseFont = true;
            this.edtVISFallNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVISFallNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVISFallNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVISFallNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVISFallNr.Size = new System.Drawing.Size(155, 24);
            this.edtVISFallNr.TabIndex = 0;
            // 
            // btnVISMassnahmenLaden
            // 
            this.btnVISMassnahmenLaden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVISMassnahmenLaden.Location = new System.Drawing.Point(261, 21);
            this.btnVISMassnahmenLaden.Name = "btnVISMassnahmenLaden";
            this.btnVISMassnahmenLaden.Size = new System.Drawing.Size(149, 24);
            this.btnVISMassnahmenLaden.TabIndex = 1;
            this.btnVISMassnahmenLaden.Text = "VIS Fall neu laden";
            this.btnVISMassnahmenLaden.UseCompatibleTextRendering = true;
            this.btnVISMassnahmenLaden.UseVisualStyleBackColor = false;
            this.btnVISMassnahmenLaden.Click += new System.EventHandler(this.btnVISMassnahmenLaden_Click);
            // 
            // edtInklAufgehobeneMassnahme
            // 
            this.edtInklAufgehobeneMassnahme.EditValue = false;
            this.edtInklAufgehobeneMassnahme.Location = new System.Drawing.Point(18, 345);
            this.edtInklAufgehobeneMassnahme.Name = "edtInklAufgehobeneMassnahme";
            this.edtInklAufgehobeneMassnahme.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInklAufgehobeneMassnahme.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklAufgehobeneMassnahme.Properties.Caption = "inkl. aufgehobene Massnahme";
            this.edtInklAufgehobeneMassnahme.Size = new System.Drawing.Size(171, 19);
            this.edtInklAufgehobeneMassnahme.TabIndex = 26;
            this.edtInklAufgehobeneMassnahme.CheckedChanged += new System.EventHandler(this.edtInklAufgehobeneMassnahme_CheckedChanged);
            // 
            // DlgVISNeueMassnahme
            // 
            this.AcceptButton = this.btnOK;
            this.ActiveSQLQuery = this.qryVISMassnahmen;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(707, 370);
            this.Controls.Add(this.edtInklAufgehobeneMassnahme);
            this.Controls.Add(this.grpVIS);
            this.Controls.Add(this.lblZipNr);
            this.Controls.Add(this.edtZIPnr);
            this.Controls.Add(this.lblKiSSPerson);
            this.Controls.Add(this.edtPerson);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "DlgVISNeueMassnahme";
            this.Text = "Neue Kindes- / Erwachsenenschutzmassnahme aus VIS importieren";
            this.Load += new System.EventHandler(this.DlgVISNeueMassnahme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVISMassnahmen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVISMassnahmen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKiSSPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZipNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZIPnr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVISFallNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVISMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVISMandant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMassnahmen)).EndInit();
            this.grpVIS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtVISFallNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklAufgehobeneMassnahme.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnCancel;
        private KiSS4.Gui.KissButton btnOK;
        private KiSS4.Gui.KissButton btnVISMassnahmenLaden;
        private KiSS4.Gui.KissCheckEdit edtInklAufgehobeneMassnahme;
        private DevExpress.XtraGrid.Columns.GridColumn colAnordnung;
        private DevExpress.XtraGrid.Columns.GridColumn colAufhebung;
        private DevExpress.XtraGrid.Columns.GridColumn colMandatstyp;
        private DevExpress.XtraGrid.Columns.GridColumn colMassnahme;
        private DevExpress.XtraGrid.Columns.GridColumn colVMExist;
        private DevExpress.XtraGrid.Columns.GridColumn colVormschID;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtPerson;
        private KiSS4.Gui.KissCalcEdit edtVISFallNr;
        private KiSS4.Gui.KissTextEdit edtVISMandant;
        private KiSS4.Gui.KissTextEdit edtZIPnr;
        private KiSS4.Gui.KissGrid grdVISMassnahmen;
        private KiSS4.Gui.KissGroupBox grpVIS;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPerson;
        private KiSS4.Gui.KissLabel lblKiSSPerson;
        private KiSS4.Gui.KissLabel lblMassnahmen;
        private KiSS4.Gui.KissLabel lblVISFallNr;
        private KiSS4.Gui.KissLabel lblVISMandant;
        private KiSS4.Gui.KissLabel lblZipNr;
        private KiSS4.DB.SqlQuery qryBaPerson;
        private KiSS4.DB.SqlQuery qryVISMassnahmen;
    }
}
