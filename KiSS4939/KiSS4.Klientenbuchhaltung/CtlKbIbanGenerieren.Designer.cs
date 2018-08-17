namespace KiSS4.Klientenbuchhaltung
{
    partial class CtlKbIbanGenerieren
    {
        #region Dispose

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

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbIbanGenerieren));
            this.btnStart = new KiSS4.Gui.KissButton();
            this.lblTodo = new KiSS4.Gui.KissLabel();
            this.lblFailC = new KiSS4.Gui.KissLabel();
            this.lblAuswahl = new KiSS4.Gui.KissLabel();
            this.lblFail = new KiSS4.Gui.KissLabel();
            this.lblSuccess = new KiSS4.Gui.KissLabel();
            this.lblSuccessC = new KiSS4.Gui.KissLabel();
            this.lblTotalC = new KiSS4.Gui.KissLabel();
            this.lblTotal = new KiSS4.Gui.KissLabel();
            this.edtTodo = new KiSS4.Gui.KissCalcEdit();
            this.grdMessage = new KiSS4.Gui.KissGrid();
            this.qryMessages = new KiSS4.DB.SqlQuery(this.components);
            this.grvMessage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBCL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameEmpfaenger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnGotoKreditor = new KiSS4.Gui.KissButton();
            this.edtAuswahl = new KiSS4.Gui.KissLookUpEdit();
            this.qryIBAN = new KiSS4.DB.SqlQuery(this.components);
            this.grpFilter = new KiSS4.Gui.KissGroupBox();
            this.grpStatusAmount = new KiSS4.Gui.KissGroupBox();
            this.grpGenerate = new KiSS4.Gui.KissGroupBox();
            this.pgbGenerate = new System.Windows.Forms.ProgressBar();
            this.grpMessage = new KiSS4.Gui.KissGroupBox();
            this.panMessageBottom = new System.Windows.Forms.Panel();
            this.lblMessageCount = new KiSS4.Gui.KissLabel();
            this.ctlBaZahlungsweg = new KiSS4.Basis.CtlBaZahlungsweg();
            this.ScrollablePanel = new KiSS4.Gui.KissScrollablePanel();
            ((System.ComponentModel.ISupportInitialize)(this.lblTodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFailC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswahl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuccessC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswahl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswahl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIBAN)).BeginInit();
            this.grpFilter.SuspendLayout();
            this.grpStatusAmount.SuspendLayout();
            this.grpGenerate.SuspendLayout();
            this.grpMessage.SuspendLayout();
            this.panMessageBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblMessageCount)).BeginInit();
            this.ScrollablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(9, 18);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(256, 24);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "IBAN generieren";
            this.btnStart.UseCompatibleTextRendering = true;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTodo
            // 
            this.lblTodo.Location = new System.Drawing.Point(9, 47);
            this.lblTodo.Name = "lblTodo";
            this.lblTodo.Size = new System.Drawing.Size(150, 24);
            this.lblTodo.TabIndex = 2;
            this.lblTodo.Text = "Anzahl zu generieren";
            this.lblTodo.UseCompatibleTextRendering = true;
            // 
            // lblFailC
            // 
            this.lblFailC.Location = new System.Drawing.Point(9, 76);
            this.lblFailC.Margin = new System.Windows.Forms.Padding(3);
            this.lblFailC.Name = "lblFailC";
            this.lblFailC.Size = new System.Drawing.Size(150, 24);
            this.lblFailC.TabIndex = 4;
            this.lblFailC.Text = "Generierung nicht möglich";
            this.lblFailC.UseCompatibleTextRendering = true;
            // 
            // lblAuswahl
            // 
            this.lblAuswahl.Location = new System.Drawing.Point(9, 18);
            this.lblAuswahl.Name = "lblAuswahl";
            this.lblAuswahl.Size = new System.Drawing.Size(150, 24);
            this.lblAuswahl.TabIndex = 0;
            this.lblAuswahl.Text = "Auswahl";
            this.lblAuswahl.UseCompatibleTextRendering = true;
            // 
            // lblFail
            // 
            this.lblFail.Location = new System.Drawing.Point(165, 77);
            this.lblFail.Margin = new System.Windows.Forms.Padding(3);
            this.lblFail.Name = "lblFail";
            this.lblFail.Size = new System.Drawing.Size(100, 23);
            this.lblFail.TabIndex = 5;
            this.lblFail.Text = "";
            this.lblFail.UseCompatibleTextRendering = true;
            // 
            // lblSuccess
            // 
            this.lblSuccess.Location = new System.Drawing.Point(165, 48);
            this.lblSuccess.Margin = new System.Windows.Forms.Padding(3);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(100, 23);
            this.lblSuccess.TabIndex = 3;
            this.lblSuccess.Text = "";
            this.lblSuccess.UseCompatibleTextRendering = true;
            // 
            // lblSuccessC
            // 
            this.lblSuccessC.Location = new System.Drawing.Point(9, 48);
            this.lblSuccessC.Margin = new System.Windows.Forms.Padding(3);
            this.lblSuccessC.Name = "lblSuccessC";
            this.lblSuccessC.Size = new System.Drawing.Size(150, 24);
            this.lblSuccessC.TabIndex = 2;
            this.lblSuccessC.Text = "IBAN generiert";
            this.lblSuccessC.UseCompatibleTextRendering = true;
            // 
            // lblTotalC
            // 
            this.lblTotalC.Location = new System.Drawing.Point(9, 18);
            this.lblTotalC.Name = "lblTotalC";
            this.lblTotalC.Size = new System.Drawing.Size(150, 24);
            this.lblTotalC.TabIndex = 0;
            this.lblTotalC.Text = "Zahlungswege ohne IBAN";
            this.lblTotalC.UseCompatibleTextRendering = true;
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(165, 18);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 23);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "";
            this.lblTotal.UseCompatibleTextRendering = true;
            // 
            // edtTodo
            // 
            this.edtTodo.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.edtTodo.Location = new System.Drawing.Point(165, 47);
            this.edtTodo.Name = "edtTodo";
            this.edtTodo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTodo.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTodo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTodo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTodo.Properties.Appearance.Options.UseBackColor = true;
            this.edtTodo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTodo.Properties.Appearance.Options.UseFont = true;
            this.edtTodo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTodo.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTodo.Properties.DisplayFormat.FormatString = "n0";
            this.edtTodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTodo.Properties.EditFormat.FormatString = "n0";
            this.edtTodo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTodo.Properties.Mask.EditMask = "n0";
            this.edtTodo.Properties.Precision = 0;
            this.edtTodo.Size = new System.Drawing.Size(100, 24);
            this.edtTodo.TabIndex = 3;
            // 
            // grdMessage
            // 
            this.grdMessage.DataSource = this.qryMessages;
            this.grdMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMessage.EmbeddedNavigator.Name = "";
            this.grdMessage.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdMessage.Location = new System.Drawing.Point(3, 17);
            this.grdMessage.MainView = this.grvMessage;
            this.grdMessage.Name = "grdMessage";
            this.grdMessage.Size = new System.Drawing.Size(794, 108);
            this.grdMessage.TabIndex = 0;
            this.grdMessage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMessage});
            // 
            // qryMessages
            // 
            this.qryMessages.BatchUpdate = true;
            this.qryMessages.HostControl = this;
            this.qryMessages.PositionChanged += new System.EventHandler(this.qryMessages_PositionChanged);
            // 
            // grvMessage
            // 
            this.grvMessage.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvMessage.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.Empty.Options.UseBackColor = true;
            this.grvMessage.Appearance.Empty.Options.UseFont = true;
            this.grvMessage.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.EvenRow.Options.UseFont = true;
            this.grvMessage.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvMessage.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvMessage.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvMessage.Appearance.FocusedCell.Options.UseFont = true;
            this.grvMessage.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvMessage.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvMessage.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvMessage.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvMessage.Appearance.FocusedRow.Options.UseFont = true;
            this.grvMessage.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvMessage.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvMessage.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvMessage.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvMessage.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvMessage.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvMessage.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvMessage.Appearance.GroupRow.Options.UseFont = true;
            this.grvMessage.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvMessage.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvMessage.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvMessage.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvMessage.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvMessage.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvMessage.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvMessage.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvMessage.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvMessage.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvMessage.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvMessage.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvMessage.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvMessage.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvMessage.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.OddRow.Options.UseFont = true;
            this.grvMessage.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvMessage.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.Row.Options.UseBackColor = true;
            this.grvMessage.Appearance.Row.Options.UseFont = true;
            this.grvMessage.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.SelectedRow.Options.UseFont = true;
            this.grvMessage.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvMessage.Appearance.VertLine.Options.UseBackColor = true;
            this.grvMessage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvMessage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBCL,
            this.colKontoNr,
            this.colMessage,
            this.colNameEmpfaenger});
            this.grvMessage.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvMessage.GridControl = this.grdMessage;
            this.grvMessage.Name = "grvMessage";
            this.grvMessage.OptionsBehavior.Editable = false;
            this.grvMessage.OptionsCustomization.AllowFilter = false;
            this.grvMessage.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvMessage.OptionsNavigation.AutoFocusNewRow = true;
            this.grvMessage.OptionsNavigation.UseTabKey = false;
            this.grvMessage.OptionsView.ColumnAutoWidth = false;
            this.grvMessage.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvMessage.OptionsView.ShowGroupPanel = false;
            this.grvMessage.OptionsView.ShowIndicator = false;
            // 
            // colBCL
            // 
            this.colBCL.Caption = "BCL";
            this.colBCL.FieldName = "BCL";
            this.colBCL.Name = "colBCL";
            this.colBCL.Visible = true;
            this.colBCL.VisibleIndex = 0;
            this.colBCL.Width = 60;
            // 
            // colKontoNr
            // 
            this.colKontoNr.Caption = "Konto";
            this.colKontoNr.FieldName = "KontoNr";
            this.colKontoNr.Name = "colKontoNr";
            this.colKontoNr.Visible = true;
            this.colKontoNr.VisibleIndex = 1;
            this.colKontoNr.Width = 200;
            // 
            // colMessage
            // 
            this.colMessage.Caption = "Fehler";
            this.colMessage.FieldName = "Message";
            this.colMessage.Name = "colMessage";
            this.colMessage.Visible = true;
            this.colMessage.VisibleIndex = 2;
            this.colMessage.Width = 410;
            // 
            // colNameEmpfaenger
            // 
            this.colNameEmpfaenger.Caption = "Name";
            this.colNameEmpfaenger.FieldName = "Name";
            this.colNameEmpfaenger.Name = "colNameEmpfaenger";
            this.colNameEmpfaenger.Visible = true;
            this.colNameEmpfaenger.VisibleIndex = 3;
            this.colNameEmpfaenger.Width = 200;
            // 
            // btnGotoKreditor
            // 
            this.btnGotoKreditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGotoKreditor.Enabled = false;
            this.btnGotoKreditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGotoKreditor.Location = new System.Drawing.Point(6, 6);
            this.btnGotoKreditor.Name = "btnGotoKreditor";
            this.btnGotoKreditor.Size = new System.Drawing.Size(150, 24);
            this.btnGotoKreditor.TabIndex = 0;
            this.btnGotoKreditor.Text = "Zu Kreditor springen";
            this.btnGotoKreditor.UseCompatibleTextRendering = true;
            this.btnGotoKreditor.UseVisualStyleBackColor = false;
            this.btnGotoKreditor.Click += new System.EventHandler(this.btnGotoKreditor_Click);
            // 
            // edtAuswahl
            // 
            this.edtAuswahl.Location = new System.Drawing.Point(165, 18);
            this.edtAuswahl.Name = "edtAuswahl";
            this.edtAuswahl.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuswahl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuswahl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswahl.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuswahl.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuswahl.Properties.Appearance.Options.UseFont = true;
            this.edtAuswahl.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAuswahl.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswahl.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAuswahl.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAuswahl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtAuswahl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtAuswahl.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuswahl.Properties.NullText = "";
            this.edtAuswahl.Properties.ShowFooter = false;
            this.edtAuswahl.Properties.ShowHeader = false;
            this.edtAuswahl.Size = new System.Drawing.Size(193, 24);
            this.edtAuswahl.TabIndex = 1;
            this.edtAuswahl.EditValueChanged += new System.EventHandler(this.edtAuswahl_EditValueChanged);
            // 
            // qryIBAN
            // 
            this.qryIBAN.BatchUpdate = true;
            this.qryIBAN.HostControl = this;
            this.qryIBAN.SelectStatement = resources.GetString("qryIBAN.SelectStatement");
            this.qryIBAN.TableName = "vwBaZahlungsweg";
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.lblAuswahl);
            this.grpFilter.Controls.Add(this.edtAuswahl);
            this.grpFilter.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpFilter.Location = new System.Drawing.Point(0, 0);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(369, 54);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // grpStatusAmount
            // 
            this.grpStatusAmount.Controls.Add(this.lblTotalC);
            this.grpStatusAmount.Controls.Add(this.lblTodo);
            this.grpStatusAmount.Controls.Add(this.lblTotal);
            this.grpStatusAmount.Controls.Add(this.edtTodo);
            this.grpStatusAmount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpStatusAmount.Location = new System.Drawing.Point(0, 54);
            this.grpStatusAmount.Name = "grpStatusAmount";
            this.grpStatusAmount.Size = new System.Drawing.Size(369, 83);
            this.grpStatusAmount.TabIndex = 1;
            this.grpStatusAmount.TabStop = false;
            this.grpStatusAmount.Text = "Status";
            // 
            // grpGenerate
            // 
            this.grpGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGenerate.Controls.Add(this.pgbGenerate);
            this.grpGenerate.Controls.Add(this.btnStart);
            this.grpGenerate.Controls.Add(this.lblFailC);
            this.grpGenerate.Controls.Add(this.lblFail);
            this.grpGenerate.Controls.Add(this.lblSuccess);
            this.grpGenerate.Controls.Add(this.lblSuccessC);
            this.grpGenerate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpGenerate.Location = new System.Drawing.Point(375, 0);
            this.grpGenerate.Name = "grpGenerate";
            this.grpGenerate.Size = new System.Drawing.Size(425, 137);
            this.grpGenerate.TabIndex = 2;
            this.grpGenerate.TabStop = false;
            this.grpGenerate.Text = "Generieren";
            // 
            // pgbGenerate
            // 
            this.pgbGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbGenerate.Location = new System.Drawing.Point(9, 106);
            this.pgbGenerate.Name = "pgbGenerate";
            this.pgbGenerate.Size = new System.Drawing.Size(410, 24);
            this.pgbGenerate.TabIndex = 1;
            // 
            // grpMessage
            // 
            this.grpMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMessage.Controls.Add(this.grdMessage);
            this.grpMessage.Controls.Add(this.panMessageBottom);
            this.grpMessage.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpMessage.Location = new System.Drawing.Point(0, 141);
            this.grpMessage.Name = "grpMessage";
            this.grpMessage.Size = new System.Drawing.Size(800, 164);
            this.grpMessage.TabIndex = 3;
            this.grpMessage.TabStop = false;
            this.grpMessage.Text = "Ausgabe";
            // 
            // panMessageBottom
            // 
            this.panMessageBottom.Controls.Add(this.lblMessageCount);
            this.panMessageBottom.Controls.Add(this.btnGotoKreditor);
            this.panMessageBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panMessageBottom.Location = new System.Drawing.Point(3, 125);
            this.panMessageBottom.Name = "panMessageBottom";
            this.panMessageBottom.Size = new System.Drawing.Size(794, 36);
            this.panMessageBottom.TabIndex = 1;
            // 
            // lblMessageCount
            // 
            this.lblMessageCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessageCount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMessageCount.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblMessageCount.Location = new System.Drawing.Point(607, 6);
            this.lblMessageCount.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.lblMessageCount.Name = "lblMessageCount";
            this.lblMessageCount.Size = new System.Drawing.Size(178, 24);
            this.lblMessageCount.TabIndex = 1;
            this.lblMessageCount.Text = "Anzahlt: {0}";
            this.lblMessageCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctlBaZahlungsweg
            // 
            this.ctlBaZahlungsweg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlBaZahlungsweg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlBaZahlungsweg.BaInstitutionID = 0;
            this.ctlBaZahlungsweg.BaPersonID = 0;
            this.ctlBaZahlungsweg.Location = new System.Drawing.Point(0, 308);
            this.ctlBaZahlungsweg.Name = "ctlBaZahlungsweg";
            this.ctlBaZahlungsweg.Size = new System.Drawing.Size(691, 426);
            this.ctlBaZahlungsweg.TabIndex = 4;
            // 
            // ScrollablePanel
            // 
            this.ScrollablePanel.AutoScrollMargin = new System.Drawing.Size(6, 6);
            this.ScrollablePanel.AutoScrollMinSize = new System.Drawing.Size(720, 720);
            this.ScrollablePanel.Controls.Add(this.ctlBaZahlungsweg);
            this.ScrollablePanel.Controls.Add(this.grpMessage);
            this.ScrollablePanel.Controls.Add(this.grpGenerate);
            this.ScrollablePanel.Controls.Add(this.grpStatusAmount);
            this.ScrollablePanel.Controls.Add(this.grpFilter);
            this.ScrollablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScrollablePanel.Location = new System.Drawing.Point(0, 0);
            this.ScrollablePanel.Name = "ScrollablePanel";
            this.ScrollablePanel.Size = new System.Drawing.Size(800, 740);
            this.ScrollablePanel.TabIndex = 5;
            // 
            // CtlKbIbanGenerieren
            // 
            this.ActiveSQLQuery = this.qryIBAN;
            this.Controls.Add(this.ScrollablePanel);
            this.Name = "CtlKbIbanGenerieren";
            this.Size = new System.Drawing.Size(800, 740);
            this.Load += new System.EventHandler(this.CtlIbanGenerieren_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblTodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFailC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswahl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuccessC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswahl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswahl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIBAN)).EndInit();
            this.grpFilter.ResumeLayout(false);
            this.grpStatusAmount.ResumeLayout(false);
            this.grpGenerate.ResumeLayout(false);
            this.grpMessage.ResumeLayout(false);
            this.panMessageBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblMessageCount)).EndInit();
            this.ScrollablePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnGotoKreditor;
        private KiSS4.Gui.KissButton btnStart;
        private DevExpress.XtraGrid.Columns.GridColumn colBCL;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colMessage;
        private DevExpress.XtraGrid.Columns.GridColumn colNameEmpfaenger;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtAuswahl;
        private KiSS4.Gui.KissCalcEdit edtTodo;
        private KiSS4.Gui.KissGrid grdMessage;
        private KiSS4.Gui.KissGroupBox grpFilter;
        private KiSS4.Gui.KissGroupBox grpGenerate;
        private KiSS4.Gui.KissGroupBox grpMessage;
        private KiSS4.Gui.KissGroupBox grpStatusAmount;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMessage;
        private KiSS4.Gui.KissLabel lblAuswahl;
        private KiSS4.Gui.KissLabel lblFail;
        private KiSS4.Gui.KissLabel lblFailC;
        private KiSS4.Gui.KissLabel lblMessageCount;
        private KiSS4.Gui.KissLabel lblSuccess;
        private KiSS4.Gui.KissLabel lblSuccessC;
        private KiSS4.Gui.KissLabel lblTodo;
        private KiSS4.Gui.KissLabel lblTotal;
        private KiSS4.Gui.KissLabel lblTotalC;
        private System.Windows.Forms.Panel panMessageBottom;
        private System.Windows.Forms.ProgressBar pgbGenerate;
        private KiSS4.DB.SqlQuery qryIBAN;
        private KiSS4.Basis.CtlBaZahlungsweg ctlBaZahlungsweg;
        private KiSS4.Gui.KissScrollablePanel ScrollablePanel;
        private KiSS4.DB.SqlQuery qryMessages;
    }
}
