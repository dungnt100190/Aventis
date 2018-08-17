namespace KiSS4.Sozialhilfe
{
    partial class DlgWhWeitereZahlinfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgWhWeitereZahlinfo));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.kissGrid1 = new KiSS4.Gui.KissGrid();
            this.qryBgAuszahlungPerson = new KiSS4.DB.SqlQuery();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuszahlung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTermin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.btnOk = new KiSS4.Gui.KissButton();
            this.edtKbAuszahlungsArtCode = new KiSS4.Gui.KissLookUpEdit();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            this.edtBgAuszahlungsTerminCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblKbAuszahlungsArtCode = new KiSS4.Gui.KissLabel();
            this.lblBgAuszahlungsTerminCode = new KiSS4.Gui.KissLabel();
            this.tabZahlinfo = new KiSS4.Gui.KissTabControlEx();
            this.tpgKalender = new SharpLibrary.WinControls.TabPageEx();
            this.edtWochentagCodes = new KiSS4.Gui.KissCheckedLookupEdit();
            this.edtCalendar = new SharpLibrary.WinControls.MonthCalendarEx();
            this.tpgMitteilung = new SharpLibrary.WinControls.TabPageEx();
            this.lblZahlbarAn = new KiSS4.Gui.KissLabel();
            this.lblMitteilung = new KiSS4.Gui.KissLabel();
            this.edtMitteilungZeile3 = new KiSS4.Gui.KissTextEdit();
            this.edtMitteilungZeile2 = new KiSS4.Gui.KissTextEdit();
            this.edtMitteilungZeile1 = new KiSS4.Gui.KissTextEdit();
            this.tpgZahlinfo = new SharpLibrary.WinControls.TabPageEx();
            this.edtValutaTermine = new KiSS4.Gui.KissTextEdit();
            this.kissMemoEdit1 = new KiSS4.Gui.KissMemoEdit();
            this.lblReferenzNummer = new KiSS4.Gui.KissLabel();
            this.lblKreditor = new KiSS4.Gui.KissLabel();
            this.lblValutaDatum = new KiSS4.Gui.KissLabel();
            this.edtReferenzNummer = new KiSS4.Common.KissReferenzNrEdit();
            this.edtKreditor = new KiSS4.Gui.KissButtonEdit();
            this.edtValutaDatum = new KiSS4.Gui.KissDateEdit();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.kissTextEdit1 = new KiSS4.Gui.KissTextEdit();
            this.qryBgAuszahlungPersonTermin = new KiSS4.DB.SqlQuery();
            this.timer1 = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.kissGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgAuszahlungPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbAuszahlungsArtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbAuszahlungsArtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgAuszahlungsTerminCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgAuszahlungsTerminCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKbAuszahlungsArtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgAuszahlungsTerminCode)).BeginInit();
            this.tabZahlinfo.SuspendLayout();
            this.tpgKalender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtWochentagCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCalendar)).BeginInit();
            this.tpgMitteilung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlbarAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile1.Properties)).BeginInit();
            this.tpgZahlinfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaTermine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReferenzNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenzNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgAuszahlungPersonTermin)).BeginInit();
            this.SuspendLayout();
            // 
            // kissGrid1
            // 
            this.kissGrid1.DataSource = this.qryBgAuszahlungPerson;
            // 
            // 
            // 
            this.kissGrid1.EmbeddedNavigator.Name = "";
            this.kissGrid1.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.kissGrid1.Location = new System.Drawing.Point(5, 5);
            this.kissGrid1.MainView = this.gridView1;
            this.kissGrid1.Name = "kissGrid1";
            this.kissGrid1.Size = new System.Drawing.Size(529, 152);
            this.kissGrid1.TabIndex = 0;
            this.kissGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.bandedGridView1});
            // 
            // qryBgAuszahlungPerson
            // 
            this.qryBgAuszahlungPerson.BatchUpdate = true;
            this.qryBgAuszahlungPerson.HostControl = this;
            this.qryBgAuszahlungPerson.SelectStatement = resources.GetString("qryBgAuszahlungPerson.SelectStatement");
            this.qryBgAuszahlungPerson.TableName = "BgAuszahlungPerson";
            this.qryBgAuszahlungPerson.BeforePost += new System.EventHandler(this.qryBgAuszahlungPerson_BeforePost);
            this.qryBgAuszahlungPerson.AfterPost += new System.EventHandler(this.qryBgAuszahlungPerson_AfterPost);
            this.qryBgAuszahlungPerson.PositionChanged += new System.EventHandler(this.qryBgAuszahlungPerson_PositionChanged);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLT,
            this.colKlient,
            this.colAuszahlung,
            this.colTermin,
            this.colKreditor});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.kissGrid1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colLT
            // 
            this.colLT.AppearanceCell.Font = new System.Drawing.Font("Wingdings", 8.25F);
            this.colLT.AppearanceCell.Options.HighPriority = true;
            this.colLT.AppearanceCell.Options.UseFont = true;
            this.colLT.AppearanceCell.Options.UseTextOptions = true;
            this.colLT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLT.Caption = "LT";
            this.colLT.FieldName = "LT";
            this.colLT.Name = "colLT";
            this.colLT.Visible = true;
            this.colLT.VisibleIndex = 0;
            this.colLT.Width = 25;
            // 
            // colKlient
            // 
            this.colKlient.Caption = "Betrifft Person";
            this.colKlient.FieldName = "Person";
            this.colKlient.Name = "colKlient";
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 1;
            this.colKlient.Width = 198;
            // 
            // colAuszahlung
            // 
            this.colAuszahlung.Caption = "Auszahl.";
            this.colAuszahlung.FieldName = "KbAuszahlungsArtCode";
            this.colAuszahlung.Name = "colAuszahlung";
            this.colAuszahlung.Visible = true;
            this.colAuszahlung.VisibleIndex = 2;
            this.colAuszahlung.Width = 65;
            // 
            // colTermin
            // 
            this.colTermin.Caption = "Termin";
            this.colTermin.FieldName = "BgAuszahlungsTerminCode";
            this.colTermin.Name = "colTermin";
            this.colTermin.Visible = true;
            this.colTermin.VisibleIndex = 3;
            this.colTermin.Width = 91;
            // 
            // colKreditor
            // 
            this.colKreditor.Caption = "Kreditor";
            this.colKreditor.FieldName = "Kreditor";
            this.colKreditor.Name = "colKreditor";
            this.colKreditor.Visible = true;
            this.colKreditor.VisibleIndex = 4;
            this.colKreditor.Width = 127;
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.bandedGridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.Empty.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.Empty.Options.UseFont = true;
            this.bandedGridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.EvenRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.bandedGridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.bandedGridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.bandedGridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.bandedGridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.bandedGridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bandedGridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.GroupRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.bandedGridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.bandedGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.bandedGridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.bandedGridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bandedGridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.bandedGridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.OddRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.bandedGridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.Row.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.Row.Options.UseFont = true;
            this.bandedGridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.bandedGridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.bandedGridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.bandedGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.bandedGridView1.GridControl = this.kissGrid1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.Editable = false;
            this.bandedGridView1.OptionsCustomization.AllowFilter = false;
            this.bandedGridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.bandedGridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.bandedGridView1.OptionsNavigation.UseTabKey = false;
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            this.bandedGridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            this.bandedGridView1.OptionsView.ShowIndicator = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(347, 485);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 24);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseCompatibleTextRendering = true;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // edtKbAuszahlungsArtCode
            // 
            this.edtKbAuszahlungsArtCode.AllowNull = false;
            this.edtKbAuszahlungsArtCode.DataMember = "KbAuszahlungsArtCode";
            this.edtKbAuszahlungsArtCode.DataSource = this.qryBgAuszahlungPerson;
            this.edtKbAuszahlungsArtCode.Location = new System.Drawing.Point(92, 200);
            this.edtKbAuszahlungsArtCode.LOVFilter = "S";
            this.edtKbAuszahlungsArtCode.LOVName = "KbAuszahlungsArt";
            this.edtKbAuszahlungsArtCode.Name = "edtKbAuszahlungsArtCode";
            this.edtKbAuszahlungsArtCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKbAuszahlungsArtCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKbAuszahlungsArtCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKbAuszahlungsArtCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtKbAuszahlungsArtCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKbAuszahlungsArtCode.Properties.Appearance.Options.UseFont = true;
            this.edtKbAuszahlungsArtCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKbAuszahlungsArtCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKbAuszahlungsArtCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKbAuszahlungsArtCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKbAuszahlungsArtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtKbAuszahlungsArtCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtKbAuszahlungsArtCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKbAuszahlungsArtCode.Properties.NullText = "";
            this.edtKbAuszahlungsArtCode.Properties.ShowFooter = false;
            this.edtKbAuszahlungsArtCode.Properties.ShowHeader = false;
            this.edtKbAuszahlungsArtCode.Size = new System.Drawing.Size(362, 24);
            this.edtKbAuszahlungsArtCode.TabIndex = 1;
            this.edtKbAuszahlungsArtCode.EditValueChanged += new System.EventHandler(this.edtKbAuszahlungsArtCode_EditValueChanged);
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(443, 485);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(90, 24);
            this.btnAbbrechen.TabIndex = 2;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseCompatibleTextRendering = true;
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // edtBgAuszahlungsTerminCode
            // 
            this.edtBgAuszahlungsTerminCode.AllowNull = false;
            this.edtBgAuszahlungsTerminCode.DataMember = "BgAuszahlungsTerminCode";
            this.edtBgAuszahlungsTerminCode.DataSource = this.qryBgAuszahlungPerson;
            this.edtBgAuszahlungsTerminCode.Location = new System.Drawing.Point(92, 230);
            this.edtBgAuszahlungsTerminCode.LOVFilter = "aktiv";
            this.edtBgAuszahlungsTerminCode.LOVName = "BgAuszahlungsTermin";
            this.edtBgAuszahlungsTerminCode.Name = "edtBgAuszahlungsTerminCode";
            this.edtBgAuszahlungsTerminCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgAuszahlungsTerminCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgAuszahlungsTerminCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgAuszahlungsTerminCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgAuszahlungsTerminCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgAuszahlungsTerminCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgAuszahlungsTerminCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgAuszahlungsTerminCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgAuszahlungsTerminCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgAuszahlungsTerminCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgAuszahlungsTerminCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBgAuszahlungsTerminCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBgAuszahlungsTerminCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgAuszahlungsTerminCode.Properties.NullText = "";
            this.edtBgAuszahlungsTerminCode.Properties.ShowFooter = false;
            this.edtBgAuszahlungsTerminCode.Properties.ShowHeader = false;
            this.edtBgAuszahlungsTerminCode.Size = new System.Drawing.Size(363, 24);
            this.edtBgAuszahlungsTerminCode.TabIndex = 2;
            this.edtBgAuszahlungsTerminCode.EditValueChanged += new System.EventHandler(this.edtBgAuszahlungsTerminCode_EditValueChanged);
            // 
            // lblKbAuszahlungsArtCode
            // 
            this.lblKbAuszahlungsArtCode.Location = new System.Drawing.Point(5, 200);
            this.lblKbAuszahlungsArtCode.Name = "lblKbAuszahlungsArtCode";
            this.lblKbAuszahlungsArtCode.Size = new System.Drawing.Size(86, 24);
            this.lblKbAuszahlungsArtCode.TabIndex = 61;
            this.lblKbAuszahlungsArtCode.Text = "Auszahlungsart";
            this.lblKbAuszahlungsArtCode.UseCompatibleTextRendering = true;
            // 
            // lblBgAuszahlungsTerminCode
            // 
            this.lblBgAuszahlungsTerminCode.Location = new System.Drawing.Point(5, 230);
            this.lblBgAuszahlungsTerminCode.Name = "lblBgAuszahlungsTerminCode";
            this.lblBgAuszahlungsTerminCode.Size = new System.Drawing.Size(48, 24);
            this.lblBgAuszahlungsTerminCode.TabIndex = 63;
            this.lblBgAuszahlungsTerminCode.Text = "Termin";
            this.lblBgAuszahlungsTerminCode.UseCompatibleTextRendering = true;
            // 
            // tabZahlinfo
            // 
            this.tabZahlinfo.Controls.Add(this.tpgKalender);
            this.tabZahlinfo.Controls.Add(this.tpgMitteilung);
            this.tabZahlinfo.Controls.Add(this.tpgZahlinfo);
            this.tabZahlinfo.Location = new System.Drawing.Point(92, 262);
            this.tabZahlinfo.Name = "tabZahlinfo";
            this.tabZahlinfo.ShowFixedWidthTooltip = true;
            this.tabZahlinfo.Size = new System.Drawing.Size(363, 223);
            this.tabZahlinfo.TabIndex = 64;
            this.tabZahlinfo.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgZahlinfo,
            this.tpgMitteilung,
            this.tpgKalender});
            this.tabZahlinfo.TabsLineColor = System.Drawing.Color.Black;
            this.tabZahlinfo.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            // 
            // tpgKalender
            // 
            this.tpgKalender.Controls.Add(this.edtWochentagCodes);
            this.tpgKalender.Controls.Add(this.edtCalendar);
            this.tpgKalender.Location = new System.Drawing.Point(6, 6);
            this.tpgKalender.Name = "tpgKalender";
            this.tpgKalender.Size = new System.Drawing.Size(351, 185);
            this.tpgKalender.TabIndex = 2;
            this.tpgKalender.Title = "Kalender";
            // 
            // edtWochentagCodes
            // 
            this.edtWochentagCodes.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtWochentagCodes.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWochentagCodes.Appearance.Options.UseBackColor = true;
            this.edtWochentagCodes.Appearance.Options.UseBorderColor = true;
            this.edtWochentagCodes.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtWochentagCodes.CheckOnClick = true;
            this.edtWochentagCodes.Location = new System.Drawing.Point(74, 60);
            this.edtWochentagCodes.LOVName = "KgWochentag";
            this.edtWochentagCodes.Name = "edtWochentagCodes";
            this.edtWochentagCodes.Size = new System.Drawing.Size(50, 95);
            this.edtWochentagCodes.TabIndex = 16;
            this.edtWochentagCodes.Visible = false;
            // 
            // edtCalendar
            // 
            this.edtCalendar.AllowRangeSelection = false;
            this.edtCalendar.BoldedDates = new System.DateTime[] {
        new System.DateTime(2007, 10, 10, 0, 0, 0, 0),
        new System.DateTime(2007, 10, 12, 0, 0, 0, 0),
        new System.DateTime(2007, 12, 15, 0, 0, 0, 0),
        new System.DateTime(2007, 12, 16, 0, 0, 0, 0)};
            this.edtCalendar.BoldedDatesBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.edtCalendar.BoldedDatesForeColor = System.Drawing.SystemColors.ControlText;
            this.edtCalendar.BorderStyleEx = SharpLibrary.WinControls.BorderStyleEx.FixedSingle;
            this.edtCalendar.CalendarDimensions = new System.Drawing.Size(2, 1);
            this.edtCalendar.DrawNextMonthDays = false;
            this.edtCalendar.DrawPreviousMonthDays = false;
            this.edtCalendar.DrawWeekNumbersBorder = true;
            this.edtCalendar.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.edtCalendar.GoToTodayLocalizedString = "heute";
            // 
            // 
            // 
            this.edtCalendar.LeftButtonPoupMenu.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.edtCalendar.Location = new System.Drawing.Point(6, 11);
            this.edtCalendar.MaxSelectionCount = 1;
            this.edtCalendar.Name = "edtCalendar";
            this.edtCalendar.NextMonthForeColor = System.Drawing.SystemColors.GrayText;
            // 
            // 
            // 
            this.edtCalendar.RightButtonPoupMenu.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.edtCalendar.SelectionEnd = new System.DateTime(2007, 12, 15, 0, 0, 0, 0);
            this.edtCalendar.SelectionStart = new System.DateTime(2007, 12, 15, 0, 0, 0, 0);
            this.edtCalendar.ShowFooter = false;
            this.edtCalendar.ShowLeftButtonPopupMenu = false;
            this.edtCalendar.ShowRightButtonPopupMenu = false;
            this.edtCalendar.ShowTodayCircle = false;
            this.edtCalendar.ShowWeekNumbers = true;
            this.edtCalendar.Size = new System.Drawing.Size(340, 160);
            this.edtCalendar.TabIndex = 14;
            this.edtCalendar.TitleBackgroundStyle = SharpLibrary.WinControls.BackgroundStyle.SolidColor;
            this.edtCalendar.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.edtCalendar.TodayCircleImage = null;
            this.edtCalendar.TodayCircleImageToTextMargin = 0;
            this.edtCalendar.TodayDate = new System.DateTime(2007, 12, 15, 0, 0, 0, 0);
            this.edtCalendar.TodayLocalizedString = "heute";
            this.edtCalendar.WeekNumbersToWeekDaysMargin = 5;
            // 
            // tpgMitteilung
            // 
            this.tpgMitteilung.Controls.Add(this.lblZahlbarAn);
            this.tpgMitteilung.Controls.Add(this.lblMitteilung);
            this.tpgMitteilung.Controls.Add(this.edtMitteilungZeile3);
            this.tpgMitteilung.Controls.Add(this.edtMitteilungZeile2);
            this.tpgMitteilung.Controls.Add(this.edtMitteilungZeile1);
            this.tpgMitteilung.Location = new System.Drawing.Point(6, 6);
            this.tpgMitteilung.Name = "tpgMitteilung";
            this.tpgMitteilung.Size = new System.Drawing.Size(351, 185);
            this.tpgMitteilung.TabIndex = 1;
            this.tpgMitteilung.Title = "Mitteilung";
            // 
            // lblZahlbarAn
            // 
            this.lblZahlbarAn.Location = new System.Drawing.Point(218, 37);
            this.lblZahlbarAn.Name = "lblZahlbarAn";
            this.lblZahlbarAn.Size = new System.Drawing.Size(58, 24);
            this.lblZahlbarAn.TabIndex = 18;
            this.lblZahlbarAn.Text = "zahlbar an";
            this.lblZahlbarAn.UseCompatibleTextRendering = true;
            // 
            // lblMitteilung
            // 
            this.lblMitteilung.Location = new System.Drawing.Point(68, 36);
            this.lblMitteilung.Name = "lblMitteilung";
            this.lblMitteilung.Size = new System.Drawing.Size(51, 24);
            this.lblMitteilung.TabIndex = 15;
            this.lblMitteilung.Text = "Mitteilung";
            this.lblMitteilung.UseCompatibleTextRendering = true;
            // 
            // edtMitteilungZeile3
            // 
            this.edtMitteilungZeile3.DataMember = "MitteilungZeile3";
            this.edtMitteilungZeile3.DataSource = this.qryBgAuszahlungPerson;
            this.edtMitteilungZeile3.Location = new System.Drawing.Point(68, 109);
            this.edtMitteilungZeile3.Name = "edtMitteilungZeile3";
            this.edtMitteilungZeile3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilungZeile3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilungZeile3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilungZeile3.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilungZeile3.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilungZeile3.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilungZeile3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilungZeile3.Properties.MaxLength = 35;
            this.edtMitteilungZeile3.Size = new System.Drawing.Size(208, 24);
            this.edtMitteilungZeile3.TabIndex = 14;
            // 
            // edtMitteilungZeile2
            // 
            this.edtMitteilungZeile2.DataMember = "MitteilungZeile2";
            this.edtMitteilungZeile2.DataSource = this.qryBgAuszahlungPerson;
            this.edtMitteilungZeile2.Location = new System.Drawing.Point(68, 86);
            this.edtMitteilungZeile2.Name = "edtMitteilungZeile2";
            this.edtMitteilungZeile2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilungZeile2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilungZeile2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilungZeile2.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilungZeile2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilungZeile2.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilungZeile2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilungZeile2.Properties.MaxLength = 35;
            this.edtMitteilungZeile2.Size = new System.Drawing.Size(208, 24);
            this.edtMitteilungZeile2.TabIndex = 13;
            // 
            // edtMitteilungZeile1
            // 
            this.edtMitteilungZeile1.DataMember = "MitteilungZeile1";
            this.edtMitteilungZeile1.DataSource = this.qryBgAuszahlungPerson;
            this.edtMitteilungZeile1.Location = new System.Drawing.Point(68, 63);
            this.edtMitteilungZeile1.Name = "edtMitteilungZeile1";
            this.edtMitteilungZeile1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilungZeile1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilungZeile1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilungZeile1.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilungZeile1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilungZeile1.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilungZeile1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilungZeile1.Properties.MaxLength = 35;
            this.edtMitteilungZeile1.Size = new System.Drawing.Size(208, 24);
            this.edtMitteilungZeile1.TabIndex = 12;
            // 
            // tpgZahlinfo
            // 
            this.tpgZahlinfo.Controls.Add(this.edtValutaTermine);
            this.tpgZahlinfo.Controls.Add(this.kissMemoEdit1);
            this.tpgZahlinfo.Controls.Add(this.lblReferenzNummer);
            this.tpgZahlinfo.Controls.Add(this.lblKreditor);
            this.tpgZahlinfo.Controls.Add(this.lblValutaDatum);
            this.tpgZahlinfo.Controls.Add(this.edtReferenzNummer);
            this.tpgZahlinfo.Controls.Add(this.edtKreditor);
            this.tpgZahlinfo.Controls.Add(this.edtValutaDatum);
            this.tpgZahlinfo.Location = new System.Drawing.Point(6, 6);
            this.tpgZahlinfo.Name = "tpgZahlinfo";
            this.tpgZahlinfo.Size = new System.Drawing.Size(351, 185);
            this.tpgZahlinfo.TabIndex = 0;
            this.tpgZahlinfo.Title = "Zahlinfo";
            // 
            // edtValutaTermine
            // 
            this.edtValutaTermine.DataMember = "ValutaTermine";
            this.edtValutaTermine.DataSource = this.qryBgAuszahlungPerson;
            this.edtValutaTermine.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtValutaTermine.Location = new System.Drawing.Point(84, 3);
            this.edtValutaTermine.Name = "edtValutaTermine";
            this.edtValutaTermine.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtValutaTermine.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValutaTermine.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValutaTermine.Properties.Appearance.Options.UseBackColor = true;
            this.edtValutaTermine.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValutaTermine.Properties.Appearance.Options.UseFont = true;
            this.edtValutaTermine.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtValutaTermine.Properties.ReadOnly = true;
            this.edtValutaTermine.Size = new System.Drawing.Size(272, 24);
            this.edtValutaTermine.TabIndex = 54;
            // 
            // kissMemoEdit1
            // 
            this.kissMemoEdit1.DataMember = "Zusatzinfo";
            this.kissMemoEdit1.DataSource = this.qryBgAuszahlungPerson;
            this.kissMemoEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissMemoEdit1.Location = new System.Drawing.Point(62, 55);
            this.kissMemoEdit1.Name = "kissMemoEdit1";
            this.kissMemoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissMemoEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissMemoEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissMemoEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissMemoEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissMemoEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissMemoEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissMemoEdit1.Properties.ReadOnly = true;
            this.kissMemoEdit1.Size = new System.Drawing.Size(272, 102);
            this.kissMemoEdit1.TabIndex = 52;
            // 
            // lblReferenzNummer
            // 
            this.lblReferenzNummer.Location = new System.Drawing.Point(5, 156);
            this.lblReferenzNummer.Name = "lblReferenzNummer";
            this.lblReferenzNummer.Size = new System.Drawing.Size(51, 24);
            this.lblReferenzNummer.TabIndex = 50;
            this.lblReferenzNummer.Text = "Ref-Nr.";
            this.lblReferenzNummer.UseCompatibleTextRendering = true;
            // 
            // lblKreditor
            // 
            this.lblKreditor.Location = new System.Drawing.Point(5, 32);
            this.lblKreditor.Name = "lblKreditor";
            this.lblKreditor.Size = new System.Drawing.Size(51, 24);
            this.lblKreditor.TabIndex = 47;
            this.lblKreditor.Text = "Kreditor";
            this.lblKreditor.UseCompatibleTextRendering = true;
            // 
            // lblValutaDatum
            // 
            this.lblValutaDatum.Location = new System.Drawing.Point(5, 3);
            this.lblValutaDatum.Name = "lblValutaDatum";
            this.lblValutaDatum.Size = new System.Drawing.Size(55, 24);
            this.lblValutaDatum.TabIndex = 25;
            this.lblValutaDatum.Text = "Valuta";
            this.lblValutaDatum.UseCompatibleTextRendering = true;
            // 
            // edtReferenzNummer
            // 
            this.edtReferenzNummer.DataMember = "ReferenzNummer";
            this.edtReferenzNummer.DataSource = this.qryBgAuszahlungPerson;
            this.edtReferenzNummer.Location = new System.Drawing.Point(62, 156);
            this.edtReferenzNummer.Name = "edtReferenzNummer";
            this.edtReferenzNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtReferenzNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtReferenzNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtReferenzNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseFont = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseTextOptions = true;
            this.edtReferenzNummer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtReferenzNummer.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.edtReferenzNummer.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtReferenzNummer.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.edtReferenzNummer.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtReferenzNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtReferenzNummer.Size = new System.Drawing.Size(272, 24);
            this.edtReferenzNummer.TabIndex = 2;
            // 
            // edtKreditor
            // 
            this.edtKreditor.DataMember = "Kreditor";
            this.edtKreditor.DataSource = this.qryBgAuszahlungPerson;
            this.edtKreditor.Location = new System.Drawing.Point(62, 32);
            this.edtKreditor.Name = "edtKreditor";
            this.edtKreditor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKreditor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditor.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseFont = true;
            this.edtKreditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtKreditor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtKreditor.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKreditor.SearchStringMinLength = 3;
            this.edtKreditor.Size = new System.Drawing.Size(272, 24);
            this.edtKreditor.TabIndex = 1;
            this.edtKreditor.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKreditor_UserModifiedFld);
            // 
            // edtValutaDatum
            // 
            this.edtValutaDatum.DataMember = "ValutaDatum";
            this.edtValutaDatum.DataSource = this.qryBgAuszahlungPerson;
            this.edtValutaDatum.EditValue = null;
            this.edtValutaDatum.Location = new System.Drawing.Point(62, 3);
            this.edtValutaDatum.Name = "edtValutaDatum";
            this.edtValutaDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValutaDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValutaDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValutaDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValutaDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseFont = true;
            this.edtValutaDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValutaDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtValutaDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValutaDatum.Properties.ShowToday = false;
            this.edtValutaDatum.Size = new System.Drawing.Size(100, 24);
            this.edtValutaDatum.TabIndex = 0;
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Location = new System.Drawing.Point(5, 170);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(81, 24);
            this.lblBaPersonID.TabIndex = 70;
            this.lblBaPersonID.Text = "Betrifft Person";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            // 
            // kissTextEdit1
            // 
            this.kissTextEdit1.DataMember = "Person";
            this.kissTextEdit1.DataSource = this.qryBgAuszahlungPerson;
            this.kissTextEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit1.Location = new System.Drawing.Point(92, 170);
            this.kissTextEdit1.Name = "kissTextEdit1";
            this.kissTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit1.Properties.ReadOnly = true;
            this.kissTextEdit1.Size = new System.Drawing.Size(363, 24);
            this.kissTextEdit1.TabIndex = 71;
            // 
            // qryBgAuszahlungPersonTermin
            // 
            this.qryBgAuszahlungPersonTermin.BatchUpdate = true;
            this.qryBgAuszahlungPersonTermin.SelectStatement = resources.GetString("qryBgAuszahlungPersonTermin.SelectStatement");
            this.qryBgAuszahlungPersonTermin.TableName = "BgAuszahlungPersonTermin";
            // 
            // DlgWhWeitereZahlinfo
            // 
            this.ActiveSQLQuery = this.qryBgAuszahlungPerson;
            this.CancelButton = this.btnAbbrechen;
            this.ClientSize = new System.Drawing.Size(541, 515);
            this.Controls.Add(this.kissTextEdit1);
            this.Controls.Add(this.lblBaPersonID);
            this.Controls.Add(this.tabZahlinfo);
            this.Controls.Add(this.lblBgAuszahlungsTerminCode);
            this.Controls.Add(this.lblKbAuszahlungsArtCode);
            this.Controls.Add(this.edtBgAuszahlungsTerminCode);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.edtKbAuszahlungsArtCode);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.kissGrid1);
            this.Name = "DlgWhWeitereZahlinfo";
            this.Text = "Weitere Zahlinfos";
            ((System.ComponentModel.ISupportInitialize)(this.kissGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgAuszahlungPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbAuszahlungsArtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbAuszahlungsArtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgAuszahlungsTerminCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgAuszahlungsTerminCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKbAuszahlungsArtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgAuszahlungsTerminCode)).EndInit();
            this.tabZahlinfo.ResumeLayout(false);
            this.tpgKalender.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtWochentagCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCalendar)).EndInit();
            this.tpgMitteilung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlbarAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungZeile1.Properties)).EndInit();
            this.tpgZahlinfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaTermine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReferenzNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenzNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgAuszahlungPersonTermin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private KiSS4.Gui.KissButton btnAbbrechen;
        private KiSS4.Gui.KissButton btnOk;
        private DevExpress.XtraGrid.Columns.GridColumn colAuszahlung;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colLT;
        private DevExpress.XtraGrid.Columns.GridColumn colTermin;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLookUpEdit edtBgAuszahlungsTerminCode;
        private SharpLibrary.WinControls.MonthCalendarEx edtCalendar;
        private KiSS4.Gui.KissLookUpEdit edtKbAuszahlungsArtCode;
        private KiSS4.Gui.KissButtonEdit edtKreditor;
        private KiSS4.Gui.KissTextEdit edtMitteilungZeile1;
        private KiSS4.Gui.KissTextEdit edtMitteilungZeile2;
        private KiSS4.Gui.KissTextEdit edtMitteilungZeile3;
        private KiSS4.Common.KissReferenzNrEdit edtReferenzNummer;
        private KiSS4.Gui.KissDateEdit edtValutaDatum;
        private KiSS4.Gui.KissTextEdit edtValutaTermine;
        private KiSS4.Gui.KissCheckedLookupEdit edtWochentagCodes;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissGrid kissGrid1;
        private KiSS4.Gui.KissMemoEdit kissMemoEdit1;
        private KiSS4.Gui.KissTextEdit kissTextEdit1;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblBgAuszahlungsTerminCode;
        private KiSS4.Gui.KissLabel lblKbAuszahlungsArtCode;
        private KiSS4.Gui.KissLabel lblKreditor;
        private KiSS4.Gui.KissLabel lblMitteilung;
        private KiSS4.Gui.KissLabel lblReferenzNummer;
        private KiSS4.Gui.KissLabel lblValutaDatum;
        private KiSS4.Gui.KissLabel lblZahlbarAn;
        private KiSS4.DB.SqlQuery qryBgAuszahlungPerson;
        private KiSS4.DB.SqlQuery qryBgAuszahlungPersonTermin;
        private KiSS4.Gui.KissTabControlEx tabZahlinfo;
        private System.Windows.Forms.Timer timer1;
        private SharpLibrary.WinControls.TabPageEx tpgKalender;
        private SharpLibrary.WinControls.TabPageEx tpgMitteilung;
        private SharpLibrary.WinControls.TabPageEx tpgZahlinfo;
    }
}
