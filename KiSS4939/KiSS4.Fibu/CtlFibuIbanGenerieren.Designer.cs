namespace KiSS4.Fibu
{
    partial class CtlFibuIbanGenerieren
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFibuIbanGenerieren));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnStart = new KiSS4.Gui.KissButton();
            this.lblTodo = new KiSS4.Gui.KissLabel();
            this.lblFailC = new KiSS4.Gui.KissLabel();
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
            this.qryIban = new KiSS4.DB.SqlQuery(this.components);
            this.grpStatusAmount = new KiSS4.Gui.KissGroupBox();
            this.grpGenerate = new KiSS4.Gui.KissGroupBox();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.pgbGenerate = new System.Windows.Forms.ProgressBar();
            this.grpMessage = new KiSS4.Gui.KissGroupBox();
            this.grpKorrektur = new KiSS4.Gui.KissGroupBox();
            this.btnGotoKreditor = new KiSS4.Gui.KissButton();
            this.edtIban = new KiSS4.Gui.KissTextEdit();
            this.qryFbZahlungsweg = new KiSS4.DB.SqlQuery(this.components);
            this.lblIBAN = new KiSS4.Gui.KissLabel();
            this.edtAktiv = new KiSS4.Gui.KissCheckEdit();
            this.edtZahlungsFrist = new KiSS4.Gui.KissIntEdit();
            this.lblZahlungsfrist = new KiSS4.Gui.KissLabel();
            this.edtZahlungsArt = new KiSS4.Gui.KissLookUpEdit();
            this.edtBankKontoNr = new KiSS4.Gui.KissTextEdit();
            this.edtPostKontoNr = new KiSS4.Gui.KissTextEdit();
            this.lblBankKontoNr = new KiSS4.Gui.KissLabel();
            this.lblBank = new KiSS4.Gui.KissLabel();
            this.lblPostKontoNr = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.edtBank = new KiSS4.Gui.KissButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFailC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuccessC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIban)).BeginInit();
            this.grpStatusAmount.SuspendLayout();
            this.grpGenerate.SuspendLayout();
            this.grpMessage.SuspendLayout();
            this.grpKorrektur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtIban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIBAN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsFrist.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsfrist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsArt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankKontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostKontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBank.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(6, 18);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 24);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "IBAN generieren";
            this.btnStart.UseCompatibleTextRendering = true;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTodo
            // 
            this.lblTodo.Location = new System.Drawing.Point(6, 48);
            this.lblTodo.Name = "lblTodo";
            this.lblTodo.Size = new System.Drawing.Size(150, 24);
            this.lblTodo.TabIndex = 2;
            this.lblTodo.Text = "Anzahl zu generieren";
            this.lblTodo.UseCompatibleTextRendering = true;
            // 
            // lblFailC
            // 
            this.lblFailC.Location = new System.Drawing.Point(221, 48);
            this.lblFailC.Margin = new System.Windows.Forms.Padding(3);
            this.lblFailC.Name = "lblFailC";
            this.lblFailC.Size = new System.Drawing.Size(150, 24);
            this.lblFailC.TabIndex = 4;
            this.lblFailC.Text = "Generierung nicht möglich";
            this.lblFailC.UseCompatibleTextRendering = true;
            // 
            // lblFail
            // 
            this.lblFail.Location = new System.Drawing.Point(385, 48);
            this.lblFail.Margin = new System.Windows.Forms.Padding(3);
            this.lblFail.Name = "lblFail";
            this.lblFail.Size = new System.Drawing.Size(75, 24);
            this.lblFail.TabIndex = 5;
            this.lblFail.Text = "-";
            this.lblFail.UseCompatibleTextRendering = true;
            // 
            // lblSuccess
            // 
            this.lblSuccess.Location = new System.Drawing.Point(112, 48);
            this.lblSuccess.Margin = new System.Windows.Forms.Padding(3);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(75, 24);
            this.lblSuccess.TabIndex = 3;
            this.lblSuccess.Text = "-";
            this.lblSuccess.UseCompatibleTextRendering = true;
            // 
            // lblSuccessC
            // 
            this.lblSuccessC.Location = new System.Drawing.Point(6, 48);
            this.lblSuccessC.Margin = new System.Windows.Forms.Padding(3);
            this.lblSuccessC.Name = "lblSuccessC";
            this.lblSuccessC.Size = new System.Drawing.Size(100, 24);
            this.lblSuccessC.TabIndex = 2;
            this.lblSuccessC.Text = "IBAN generiert";
            this.lblSuccessC.UseCompatibleTextRendering = true;
            // 
            // lblTotalC
            // 
            this.lblTotalC.Location = new System.Drawing.Point(6, 17);
            this.lblTotalC.Name = "lblTotalC";
            this.lblTotalC.Size = new System.Drawing.Size(150, 24);
            this.lblTotalC.TabIndex = 0;
            this.lblTotalC.Text = "Zahlungswege ohne IBAN";
            this.lblTotalC.UseCompatibleTextRendering = true;
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(165, 17);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 23);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "-";
            this.lblTotal.UseCompatibleTextRendering = true;
            // 
            // edtTodo
            // 
            this.edtTodo.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.edtTodo.Location = new System.Drawing.Point(165, 48);
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
            // 
            // 
            // 
            this.grdMessage.EmbeddedNavigator.Name = "";
            this.grdMessage.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdMessage.Location = new System.Drawing.Point(3, 17);
            this.grdMessage.MainView = this.grvMessage;
            this.grdMessage.Name = "grdMessage";
            this.grdMessage.Size = new System.Drawing.Size(838, 249);
            this.grdMessage.TabIndex = 0;
            this.grdMessage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMessage});
            // 
            // qryMessages
            // 
            this.qryMessages.BatchUpdate = true;
            this.qryMessages.HostControl = this;
            this.qryMessages.TableName = "FbZahlungsweg";
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
            this.colKontoNr.Width = 186;
            // 
            // colMessage
            // 
            this.colMessage.Caption = "Fehler";
            this.colMessage.FieldName = "Message";
            this.colMessage.Name = "colMessage";
            this.colMessage.Visible = true;
            this.colMessage.VisibleIndex = 3;
            this.colMessage.Width = 350;
            // 
            // colNameEmpfaenger
            // 
            this.colNameEmpfaenger.Caption = "Kreditor";
            this.colNameEmpfaenger.FieldName = "Name";
            this.colNameEmpfaenger.Name = "colNameEmpfaenger";
            this.colNameEmpfaenger.Visible = true;
            this.colNameEmpfaenger.VisibleIndex = 2;
            this.colNameEmpfaenger.Width = 200;
            // 
            // qryIban
            // 
            this.qryIban.BatchUpdate = true;
            this.qryIban.HostControl = this;
            this.qryIban.SelectStatement = "-- in btnStart_Click";
            this.qryIban.TableName = "FbZahlungsweg";
            // 
            // grpStatusAmount
            // 
            this.grpStatusAmount.Controls.Add(this.lblTotalC);
            this.grpStatusAmount.Controls.Add(this.lblTodo);
            this.grpStatusAmount.Controls.Add(this.lblTotal);
            this.grpStatusAmount.Controls.Add(this.edtTodo);
            this.grpStatusAmount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpStatusAmount.Location = new System.Drawing.Point(3, 3);
            this.grpStatusAmount.Name = "grpStatusAmount";
            this.grpStatusAmount.Size = new System.Drawing.Size(369, 110);
            this.grpStatusAmount.TabIndex = 1;
            this.grpStatusAmount.TabStop = false;
            this.grpStatusAmount.Text = "Status";
            // 
            // grpGenerate
            // 
            this.grpGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGenerate.Controls.Add(this.btnCancel);
            this.grpGenerate.Controls.Add(this.pgbGenerate);
            this.grpGenerate.Controls.Add(this.btnStart);
            this.grpGenerate.Controls.Add(this.lblFailC);
            this.grpGenerate.Controls.Add(this.lblFail);
            this.grpGenerate.Controls.Add(this.lblSuccess);
            this.grpGenerate.Controls.Add(this.lblSuccessC);
            this.grpGenerate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpGenerate.Location = new System.Drawing.Point(378, 3);
            this.grpGenerate.Name = "grpGenerate";
            this.grpGenerate.Size = new System.Drawing.Size(469, 110);
            this.grpGenerate.TabIndex = 2;
            this.grpGenerate.TabStop = false;
            this.grpGenerate.Text = "Generieren";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(162, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pgbGenerate
            // 
            this.pgbGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbGenerate.Location = new System.Drawing.Point(6, 78);
            this.pgbGenerate.Name = "pgbGenerate";
            this.pgbGenerate.Size = new System.Drawing.Size(454, 24);
            this.pgbGenerate.TabIndex = 1;
            // 
            // grpMessage
            // 
            this.grpMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMessage.Controls.Add(this.grdMessage);
            this.grpMessage.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpMessage.Location = new System.Drawing.Point(3, 119);
            this.grpMessage.Name = "grpMessage";
            this.grpMessage.Size = new System.Drawing.Size(844, 269);
            this.grpMessage.TabIndex = 3;
            this.grpMessage.TabStop = false;
            this.grpMessage.Text = "Ausgabe Zahlungswege";
            // 
            // grpKorrektur
            // 
            this.grpKorrektur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpKorrektur.Controls.Add(this.btnGotoKreditor);
            this.grpKorrektur.Controls.Add(this.edtIban);
            this.grpKorrektur.Controls.Add(this.lblIBAN);
            this.grpKorrektur.Controls.Add(this.edtAktiv);
            this.grpKorrektur.Controls.Add(this.edtZahlungsFrist);
            this.grpKorrektur.Controls.Add(this.lblZahlungsfrist);
            this.grpKorrektur.Controls.Add(this.edtZahlungsArt);
            this.grpKorrektur.Controls.Add(this.edtBankKontoNr);
            this.grpKorrektur.Controls.Add(this.edtPostKontoNr);
            this.grpKorrektur.Controls.Add(this.lblBankKontoNr);
            this.grpKorrektur.Controls.Add(this.lblBank);
            this.grpKorrektur.Controls.Add(this.lblPostKontoNr);
            this.grpKorrektur.Controls.Add(this.kissLabel7);
            this.grpKorrektur.Controls.Add(this.edtBank);
            this.grpKorrektur.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpKorrektur.Location = new System.Drawing.Point(3, 394);
            this.grpKorrektur.Name = "grpKorrektur";
            this.grpKorrektur.Size = new System.Drawing.Size(844, 203);
            this.grpKorrektur.TabIndex = 5;
            this.grpKorrektur.TabStop = false;
            this.grpKorrektur.Text = "Korrektur Zahlungsweg";
            // 
            // btnGotoKreditor
            // 
            this.btnGotoKreditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGotoKreditor.Location = new System.Drawing.Point(381, 20);
            this.btnGotoKreditor.Name = "btnGotoKreditor";
            this.btnGotoKreditor.Size = new System.Drawing.Size(150, 24);
            this.btnGotoKreditor.TabIndex = 355;
            this.btnGotoKreditor.Text = "Zu Kreditor springen";
            this.btnGotoKreditor.UseVisualStyleBackColor = false;
            this.btnGotoKreditor.Click += new System.EventHandler(this.btnGotoKreditor_Click);
            // 
            // edtIban
            // 
            this.edtIban.DataMember = "IBAN";
            this.edtIban.DataSource = this.qryFbZahlungsweg;
            this.edtIban.Location = new System.Drawing.Point(112, 80);
            this.edtIban.Name = "edtIban";
            this.edtIban.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIban.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIban.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIban.Properties.Appearance.Options.UseBackColor = true;
            this.edtIban.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIban.Properties.Appearance.Options.UseFont = true;
            this.edtIban.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIban.Size = new System.Drawing.Size(260, 24);
            this.edtIban.TabIndex = 353;
            // 
            // qryFbZahlungsweg
            // 
            this.qryFbZahlungsweg.CanUpdate = true;
            this.qryFbZahlungsweg.HostControl = this;
            this.qryFbZahlungsweg.SelectStatement = resources.GetString("qryFbZahlungsweg.SelectStatement");
            this.qryFbZahlungsweg.TableName = "FbZahlungsweg";
            // 
            // lblIBAN
            // 
            this.lblIBAN.Location = new System.Drawing.Point(6, 80);
            this.lblIBAN.Name = "lblIBAN";
            this.lblIBAN.Size = new System.Drawing.Size(100, 24);
            this.lblIBAN.TabIndex = 354;
            this.lblIBAN.Text = "IBAN";
            // 
            // edtAktiv
            // 
            this.edtAktiv.DataMember = "IsActive";
            this.edtAktiv.DataSource = this.qryFbZahlungsweg;
            this.edtAktiv.Location = new System.Drawing.Point(309, 174);
            this.edtAktiv.Name = "edtAktiv";
            this.edtAktiv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtAktiv.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.edtAktiv.Properties.Appearance.Options.UseFont = true;
            this.edtAktiv.Properties.Caption = "Aktiv";
            this.edtAktiv.Size = new System.Drawing.Size(63, 19);
            this.edtAktiv.TabIndex = 347;
            // 
            // edtZahlungsFrist
            // 
            this.edtZahlungsFrist.DataMember = "ZahlungsFrist";
            this.edtZahlungsFrist.DataSource = this.qryFbZahlungsweg;
            this.edtZahlungsFrist.Location = new System.Drawing.Point(112, 170);
            this.edtZahlungsFrist.Name = "edtZahlungsFrist";
            this.edtZahlungsFrist.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZahlungsFrist.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZahlungsFrist.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZahlungsFrist.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungsFrist.Properties.Appearance.Options.UseBackColor = true;
            this.edtZahlungsFrist.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZahlungsFrist.Properties.Appearance.Options.UseFont = true;
            this.edtZahlungsFrist.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZahlungsFrist.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZahlungsFrist.Properties.DisplayFormat.FormatString = "################################";
            this.edtZahlungsFrist.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtZahlungsFrist.Properties.EditFormat.FormatString = "################################";
            this.edtZahlungsFrist.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtZahlungsFrist.Properties.Mask.EditMask = "################################";
            this.edtZahlungsFrist.Size = new System.Drawing.Size(191, 24);
            this.edtZahlungsFrist.TabIndex = 346;
            // 
            // lblZahlungsfrist
            // 
            this.lblZahlungsfrist.Location = new System.Drawing.Point(6, 170);
            this.lblZahlungsfrist.Name = "lblZahlungsfrist";
            this.lblZahlungsfrist.Size = new System.Drawing.Size(100, 24);
            this.lblZahlungsfrist.TabIndex = 352;
            this.lblZahlungsfrist.Text = "Zahlungsfrist";
            // 
            // edtZahlungsArt
            // 
            this.edtZahlungsArt.DataMember = "ZahlungsArtCode";
            this.edtZahlungsArt.DataSource = this.qryFbZahlungsweg;
            this.edtZahlungsArt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZahlungsArt.Location = new System.Drawing.Point(112, 20);
            this.edtZahlungsArt.LOVName = "FbZahlungsArtCode";
            this.edtZahlungsArt.Name = "edtZahlungsArt";
            this.edtZahlungsArt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZahlungsArt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZahlungsArt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungsArt.Properties.Appearance.Options.UseBackColor = true;
            this.edtZahlungsArt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZahlungsArt.Properties.Appearance.Options.UseFont = true;
            this.edtZahlungsArt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZahlungsArt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungsArt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZahlungsArt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZahlungsArt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtZahlungsArt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtZahlungsArt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZahlungsArt.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Typ")});
            this.edtZahlungsArt.Properties.NullText = "";
            this.edtZahlungsArt.Properties.ReadOnly = true;
            this.edtZahlungsArt.Properties.ShowFooter = false;
            this.edtZahlungsArt.Properties.ShowHeader = false;
            this.edtZahlungsArt.Size = new System.Drawing.Size(260, 24);
            this.edtZahlungsArt.TabIndex = 342;
            // 
            // edtBankKontoNr
            // 
            this.edtBankKontoNr.DataMember = "BankKontoNr";
            this.edtBankKontoNr.DataSource = this.qryFbZahlungsweg;
            this.edtBankKontoNr.Location = new System.Drawing.Point(112, 140);
            this.edtBankKontoNr.Name = "edtBankKontoNr";
            this.edtBankKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBankKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBankKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBankKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtBankKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBankKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtBankKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBankKontoNr.Size = new System.Drawing.Size(260, 24);
            this.edtBankKontoNr.TabIndex = 345;
            // 
            // edtPostKontoNr
            // 
            this.edtPostKontoNr.DataMember = "PCKontoNr";
            this.edtPostKontoNr.DataSource = this.qryFbZahlungsweg;
            this.edtPostKontoNr.Location = new System.Drawing.Point(112, 110);
            this.edtPostKontoNr.Name = "edtPostKontoNr";
            this.edtPostKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPostKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPostKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPostKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtPostKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPostKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtPostKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPostKontoNr.Size = new System.Drawing.Size(260, 24);
            this.edtPostKontoNr.TabIndex = 344;
            // 
            // lblBankKontoNr
            // 
            this.lblBankKontoNr.Location = new System.Drawing.Point(6, 136);
            this.lblBankKontoNr.Name = "lblBankKontoNr";
            this.lblBankKontoNr.Size = new System.Drawing.Size(100, 24);
            this.lblBankKontoNr.TabIndex = 351;
            this.lblBankKontoNr.Text = "Bankkonto Nr";
            // 
            // lblBank
            // 
            this.lblBank.Location = new System.Drawing.Point(6, 50);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(100, 24);
            this.lblBank.TabIndex = 350;
            this.lblBank.Text = "Bank";
            // 
            // lblPostKontoNr
            // 
            this.lblPostKontoNr.Location = new System.Drawing.Point(6, 110);
            this.lblPostKontoNr.Name = "lblPostKontoNr";
            this.lblPostKontoNr.Size = new System.Drawing.Size(100, 24);
            this.lblPostKontoNr.TabIndex = 349;
            this.lblPostKontoNr.Text = "Postkonto Nr";
            // 
            // kissLabel7
            // 
            this.kissLabel7.Location = new System.Drawing.Point(6, 20);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(100, 24);
            this.kissLabel7.TabIndex = 348;
            this.kissLabel7.Text = "Zahlungsart";
            // 
            // edtBank
            // 
            this.edtBank.DataMember = "Finanzinstitut";
            this.edtBank.DataSource = this.qryFbZahlungsweg;
            this.edtBank.Location = new System.Drawing.Point(112, 50);
            this.edtBank.Name = "edtBank";
            this.edtBank.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBank.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBank.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBank.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtBank.Properties.Appearance.Options.UseBackColor = true;
            this.edtBank.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBank.Properties.Appearance.Options.UseFont = true;
            this.edtBank.Properties.Appearance.Options.UseForeColor = true;
            this.edtBank.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBank.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBank.Size = new System.Drawing.Size(260, 24);
            this.edtBank.TabIndex = 343;
            this.edtBank.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBank_UserModifiedFld);
            // 
            // CtlFibuIbanGenerieren
            // 
            this.ActiveSQLQuery = this.qryFbZahlungsweg;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.grpKorrektur);
            this.Controls.Add(this.grpStatusAmount);
            this.Controls.Add(this.grpMessage);
            this.Controls.Add(this.grpGenerate);
            this.Name = "CtlFibuIbanGenerieren";
            this.Size = new System.Drawing.Size(850, 600);
            this.Load += new System.EventHandler(this.CtlIbanGenerieren_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblTodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFailC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuccessC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIban)).EndInit();
            this.grpStatusAmount.ResumeLayout(false);
            this.grpGenerate.ResumeLayout(false);
            this.grpMessage.ResumeLayout(false);
            this.grpKorrektur.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtIban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIBAN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsFrist.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsfrist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsArt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankKontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostKontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBank.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnStart;
        private DevExpress.XtraGrid.Columns.GridColumn colBCL;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colMessage;
        private DevExpress.XtraGrid.Columns.GridColumn colNameEmpfaenger;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissCalcEdit edtTodo;
        private KiSS4.Gui.KissGrid grdMessage;
        private KiSS4.Gui.KissGroupBox grpGenerate;
        private KiSS4.Gui.KissGroupBox grpMessage;
        private KiSS4.Gui.KissGroupBox grpStatusAmount;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMessage;
        private KiSS4.Gui.KissLabel lblFail;
        private KiSS4.Gui.KissLabel lblFailC;
        private KiSS4.Gui.KissLabel lblSuccess;
        private KiSS4.Gui.KissLabel lblSuccessC;
        private KiSS4.Gui.KissLabel lblTodo;
        private KiSS4.Gui.KissLabel lblTotal;
        private KiSS4.Gui.KissLabel lblTotalC;
        private System.Windows.Forms.ProgressBar pgbGenerate;
        private KiSS4.DB.SqlQuery qryIban;
        private KiSS4.DB.SqlQuery qryMessages;
        private Gui.KissGroupBox grpKorrektur;
        private Gui.KissButton btnCancel;
        private Gui.KissTextEdit edtIban;
        private Gui.KissLabel lblIBAN;
        private Gui.KissCheckEdit edtAktiv;
        private Gui.KissIntEdit edtZahlungsFrist;
        private Gui.KissLabel lblZahlungsfrist;
        private Gui.KissLookUpEdit edtZahlungsArt;
        private Gui.KissTextEdit edtBankKontoNr;
        private Gui.KissTextEdit edtPostKontoNr;
        private Gui.KissLabel lblBankKontoNr;
        private Gui.KissLabel lblBank;
        private Gui.KissLabel lblPostKontoNr;
        private Gui.KissLabel kissLabel7;
        private Gui.KissButtonEdit edtBank;
        private DB.SqlQuery qryFbZahlungsweg;
        private Gui.KissButton btnGotoKreditor;
    }
}
