namespace KiSS4.Vormundschaft
{
    partial class CtlFrmVmBewertung
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.edtSAR = new KiSS4.Gui.KissButtonEdit();
            this.grdMandanten = new KiSS4.Gui.KissGrid();
            this.qryMandant = new KiSS4.DB.SqlQuery(this.components);
            this.grvMandanten = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZGB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBewilligt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ctlVmKriterien = new KiSS4.Vormundschaft.CtlVmKriterien();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.lblAnzahlTotal = new KiSS4.Gui.KissLabel();
            this.lblAnzahlA = new KiSS4.Gui.KissLabel();
            this.lblAnzahlB = new KiSS4.Gui.KissLabel();
            this.lblAnzahlC = new KiSS4.Gui.KissLabel();
            this.lblAnzahlD = new KiSS4.Gui.KissLabel();
            this.lblAuslastung = new KiSS4.Gui.KissLabel();
            this.edtAnzahlA = new KiSS4.Gui.KissCalcEdit();
            this.edtAnzahlB = new KiSS4.Gui.KissCalcEdit();
            this.edtAnzahlC = new KiSS4.Gui.KissCalcEdit();
            this.edtAnzahlD = new KiSS4.Gui.KissCalcEdit();
            this.edtAnzahlTotal = new KiSS4.Gui.KissCalcEdit();
            this.edtAuslastung = new KiSS4.Gui.KissCalcEdit();
            this.lblAuslastungProzent = new KiSS4.Gui.KissLabel();
            this.qryVmMandatsTyp = new KiSS4.DB.SqlQuery(this.components);
            this.qryUser = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMandanten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMandanten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuslastung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuslastung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuslastungProzent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmMandatsTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUser)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSAR
            // 
            this.lblSAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSAR.Location = new System.Drawing.Point(5, 595);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(94, 24);
            this.lblSAR.TabIndex = 679;
            this.lblSAR.Text = "MandatsträgerIn";
            // 
            // edtSAR
            // 
            this.edtSAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSAR.DataMember = "SAR";
            this.edtSAR.EditValue = "";
            this.edtSAR.Location = new System.Drawing.Point(105, 595);
            this.edtSAR.Name = "edtSAR";
            this.edtSAR.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSAR.Properties.Appearance.Options.UseBackColor = true;
            this.edtSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSAR.Properties.Appearance.Options.UseFont = true;
            this.edtSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSAR.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSAR.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSAR.Size = new System.Drawing.Size(225, 24);
            this.edtSAR.TabIndex = 678;
            this.edtSAR.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editSAR_UserModifiedFld);
            // 
            // grdMandanten
            // 
            this.grdMandanten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdMandanten.DataSource = this.qryMandant;
            this.grdMandanten.EmbeddedNavigator.Name = "";
            this.grdMandanten.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdMandanten.Location = new System.Drawing.Point(5, 10);
            this.grdMandanten.MainView = this.grvMandanten;
            this.grdMandanten.Name = "grdMandanten";
            this.grdMandanten.Size = new System.Drawing.Size(345, 523);
            this.grdMandanten.TabIndex = 671;
            this.grdMandanten.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMandanten});
            // 
            // qryMandant
            // 
            this.qryMandant.HostControl = this;
            this.qryMandant.TableName = "FaLeistung";
            this.qryMandant.PositionChanged += new System.EventHandler(this.qryMandant_PositionChanged);
            this.qryMandant.AfterFill += new System.EventHandler(this.qryMandant_AfterFill);
            // 
            // grvMandanten
            // 
            this.grvMandanten.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvMandanten.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMandanten.Appearance.Empty.Options.UseBackColor = true;
            this.grvMandanten.Appearance.Empty.Options.UseFont = true;
            this.grvMandanten.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvMandanten.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMandanten.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvMandanten.Appearance.EvenRow.Options.UseFont = true;
            this.grvMandanten.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvMandanten.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMandanten.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvMandanten.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvMandanten.Appearance.FocusedCell.Options.UseFont = true;
            this.grvMandanten.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvMandanten.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvMandanten.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMandanten.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvMandanten.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvMandanten.Appearance.FocusedRow.Options.UseFont = true;
            this.grvMandanten.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvMandanten.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvMandanten.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvMandanten.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvMandanten.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvMandanten.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvMandanten.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvMandanten.Appearance.GroupRow.Options.UseFont = true;
            this.grvMandanten.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvMandanten.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvMandanten.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvMandanten.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvMandanten.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvMandanten.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvMandanten.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvMandanten.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvMandanten.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMandanten.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvMandanten.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvMandanten.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvMandanten.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvMandanten.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvMandanten.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvMandanten.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvMandanten.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMandanten.Appearance.OddRow.Options.UseBackColor = true;
            this.grvMandanten.Appearance.OddRow.Options.UseFont = true;
            this.grvMandanten.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvMandanten.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMandanten.Appearance.Row.Options.UseBackColor = true;
            this.grvMandanten.Appearance.Row.Options.UseFont = true;
            this.grvMandanten.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvMandanten.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMandanten.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvMandanten.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvMandanten.Appearance.SelectedRow.Options.UseFont = true;
            this.grvMandanten.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvMandanten.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvMandanten.Appearance.VertLine.Options.UseBackColor = true;
            this.grvMandanten.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvMandanten.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMandant,
            this.colZGB,
            this.colFallTyp,
            this.colBewilligt,
            this.colTage});
            this.grvMandanten.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvMandanten.GridControl = this.grdMandanten;
            this.grvMandanten.Name = "gridView1";
            this.grvMandanten.OptionsBehavior.Editable = false;
            this.grvMandanten.OptionsCustomization.AllowFilter = false;
            this.grvMandanten.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvMandanten.OptionsNavigation.AutoFocusNewRow = true;
            this.grvMandanten.OptionsNavigation.UseTabKey = false;
            this.grvMandanten.OptionsView.ColumnAutoWidth = false;
            this.grvMandanten.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvMandanten.OptionsView.ShowGroupPanel = false;
            this.grvMandanten.OptionsView.ShowIndicator = false;
            this.grvMandanten.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.grvMandanten_BeforeLeaveRow);
            // 
            // colMandant
            // 
            this.colMandant.Caption = "Mandant";
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.OptionsColumn.AllowEdit = false;
            this.colMandant.OptionsColumn.ReadOnly = true;
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 0;
            this.colMandant.Width = 142;
            // 
            // colZGB
            // 
            this.colZGB.Caption = "ZGB";
            this.colZGB.FieldName = "ZGB";
            this.colZGB.Name = "colZGB";
            this.colZGB.Visible = true;
            this.colZGB.VisibleIndex = 1;
            this.colZGB.Width = 53;
            // 
            // colFallTyp
            // 
            this.colFallTyp.AppearanceCell.Options.UseTextOptions = true;
            this.colFallTyp.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFallTyp.Caption = "Falltyp";
            this.colFallTyp.FieldName = "VmMandatstypCode";
            this.colFallTyp.Name = "colFallTyp";
            this.colFallTyp.Visible = true;
            this.colFallTyp.VisibleIndex = 2;
            this.colFallTyp.Width = 50;
            // 
            // colBewilligt
            // 
            this.colBewilligt.AppearanceCell.Options.UseTextOptions = true;
            this.colBewilligt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBewilligt.Caption = "bew.";
            this.colBewilligt.FieldName = "VmMandatstypBewilligtCode";
            this.colBewilligt.Name = "colBewilligt";
            this.colBewilligt.Visible = true;
            this.colBewilligt.VisibleIndex = 3;
            this.colBewilligt.Width = 40;
            // 
            // colTage
            // 
            this.colTage.Caption = "Tage";
            this.colTage.FieldName = "Tage";
            this.colTage.Name = "colTage";
            this.colTage.Visible = true;
            this.colTage.VisibleIndex = 4;
            this.colTage.Width = 39;
            // 
            // ctlVmKriterien
            // 
            this.ctlVmKriterien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlVmKriterien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlVmKriterien.Location = new System.Drawing.Point(360, 0);
            this.ctlVmKriterien.Name = "ctlVmKriterien";
            this.ctlVmKriterien.Size = new System.Drawing.Size(662, 623);
            this.ctlVmKriterien.TabIndex = 680;
            // 
            // lblAnzahlTotal
            // 
            this.lblAnzahlTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnzahlTotal.Location = new System.Drawing.Point(218, 535);
            this.lblAnzahlTotal.Name = "lblAnzahlTotal";
            this.lblAnzahlTotal.Size = new System.Drawing.Size(39, 24);
            this.lblAnzahlTotal.TabIndex = 693;
            this.lblAnzahlTotal.Text = "Total";
            this.lblAnzahlTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAnzahlA
            // 
            this.lblAnzahlA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnzahlA.Location = new System.Drawing.Point(29, 535);
            this.lblAnzahlA.Name = "lblAnzahlA";
            this.lblAnzahlA.Size = new System.Drawing.Size(20, 24);
            this.lblAnzahlA.TabIndex = 694;
            this.lblAnzahlA.Text = "A";
            // 
            // lblAnzahlB
            // 
            this.lblAnzahlB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnzahlB.Location = new System.Drawing.Point(79, 535);
            this.lblAnzahlB.Name = "lblAnzahlB";
            this.lblAnzahlB.Size = new System.Drawing.Size(20, 24);
            this.lblAnzahlB.TabIndex = 697;
            this.lblAnzahlB.Text = "B";
            // 
            // lblAnzahlC
            // 
            this.lblAnzahlC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnzahlC.Location = new System.Drawing.Point(129, 535);
            this.lblAnzahlC.Name = "lblAnzahlC";
            this.lblAnzahlC.Size = new System.Drawing.Size(20, 24);
            this.lblAnzahlC.TabIndex = 698;
            this.lblAnzahlC.Text = "C";
            // 
            // lblAnzahlD
            // 
            this.lblAnzahlD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnzahlD.Location = new System.Drawing.Point(179, 535);
            this.lblAnzahlD.Name = "lblAnzahlD";
            this.lblAnzahlD.Size = new System.Drawing.Size(20, 24);
            this.lblAnzahlD.TabIndex = 699;
            this.lblAnzahlD.Text = "D";
            // 
            // lblAuslastung
            // 
            this.lblAuslastung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAuslastung.Location = new System.Drawing.Point(290, 535);
            this.lblAuslastung.Name = "lblAuslastung";
            this.lblAuslastung.Size = new System.Drawing.Size(60, 24);
            this.lblAuslastung.TabIndex = 700;
            this.lblAuslastung.Text = "Auslastung";
            // 
            // edtAnzahlA
            // 
            this.edtAnzahlA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAnzahlA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAnzahlA.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.edtAnzahlA.Location = new System.Drawing.Point(6, 559);
            this.edtAnzahlA.Name = "edtAnzahlA";
            this.edtAnzahlA.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnzahlA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAnzahlA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnzahlA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnzahlA.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnzahlA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnzahlA.Properties.Appearance.Options.UseFont = true;
            this.edtAnzahlA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnzahlA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnzahlA.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnzahlA.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnzahlA.Properties.ReadOnly = true;
            this.edtAnzahlA.Size = new System.Drawing.Size(51, 24);
            this.edtAnzahlA.TabIndex = 701;
            // 
            // edtAnzahlB
            // 
            this.edtAnzahlB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAnzahlB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAnzahlB.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.edtAnzahlB.Location = new System.Drawing.Point(56, 559);
            this.edtAnzahlB.Name = "edtAnzahlB";
            this.edtAnzahlB.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnzahlB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAnzahlB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnzahlB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnzahlB.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnzahlB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnzahlB.Properties.Appearance.Options.UseFont = true;
            this.edtAnzahlB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnzahlB.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnzahlB.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnzahlB.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnzahlB.Properties.ReadOnly = true;
            this.edtAnzahlB.Size = new System.Drawing.Size(51, 24);
            this.edtAnzahlB.TabIndex = 702;
            // 
            // edtAnzahlC
            // 
            this.edtAnzahlC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAnzahlC.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAnzahlC.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.edtAnzahlC.Location = new System.Drawing.Point(106, 559);
            this.edtAnzahlC.Name = "edtAnzahlC";
            this.edtAnzahlC.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnzahlC.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAnzahlC.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnzahlC.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnzahlC.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnzahlC.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnzahlC.Properties.Appearance.Options.UseFont = true;
            this.edtAnzahlC.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnzahlC.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnzahlC.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnzahlC.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnzahlC.Properties.ReadOnly = true;
            this.edtAnzahlC.Size = new System.Drawing.Size(51, 24);
            this.edtAnzahlC.TabIndex = 703;
            // 
            // edtAnzahlD
            // 
            this.edtAnzahlD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAnzahlD.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAnzahlD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.edtAnzahlD.Location = new System.Drawing.Point(156, 559);
            this.edtAnzahlD.Name = "edtAnzahlD";
            this.edtAnzahlD.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnzahlD.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAnzahlD.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnzahlD.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnzahlD.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnzahlD.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnzahlD.Properties.Appearance.Options.UseFont = true;
            this.edtAnzahlD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnzahlD.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnzahlD.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnzahlD.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnzahlD.Properties.ReadOnly = true;
            this.edtAnzahlD.Size = new System.Drawing.Size(51, 24);
            this.edtAnzahlD.TabIndex = 704;
            // 
            // edtAnzahlTotal
            // 
            this.edtAnzahlTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAnzahlTotal.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAnzahlTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.edtAnzahlTotal.Location = new System.Drawing.Point(206, 559);
            this.edtAnzahlTotal.Name = "edtAnzahlTotal";
            this.edtAnzahlTotal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnzahlTotal.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAnzahlTotal.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnzahlTotal.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnzahlTotal.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnzahlTotal.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnzahlTotal.Properties.Appearance.Options.UseFont = true;
            this.edtAnzahlTotal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnzahlTotal.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnzahlTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnzahlTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnzahlTotal.Properties.ReadOnly = true;
            this.edtAnzahlTotal.Size = new System.Drawing.Size(51, 24);
            this.edtAnzahlTotal.TabIndex = 705;
            // 
            // edtAuslastung
            // 
            this.edtAuslastung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAuslastung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAuslastung.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.edtAuslastung.Location = new System.Drawing.Point(290, 559);
            this.edtAuslastung.Name = "edtAuslastung";
            this.edtAuslastung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAuslastung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAuslastung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuslastung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuslastung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuslastung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuslastung.Properties.Appearance.Options.UseFont = true;
            this.edtAuslastung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAuslastung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuslastung.Properties.DisplayFormat.FormatString = "n0";
            this.edtAuslastung.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAuslastung.Properties.EditFormat.FormatString = "n0";
            this.edtAuslastung.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAuslastung.Properties.ReadOnly = true;
            this.edtAuslastung.Size = new System.Drawing.Size(40, 24);
            this.edtAuslastung.TabIndex = 706;
            // 
            // lblAuslastungProzent
            // 
            this.lblAuslastungProzent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAuslastungProzent.Location = new System.Drawing.Point(333, 559);
            this.lblAuslastungProzent.Name = "lblAuslastungProzent";
            this.lblAuslastungProzent.Size = new System.Drawing.Size(20, 24);
            this.lblAuslastungProzent.TabIndex = 707;
            this.lblAuslastungProzent.Text = "%";
            // 
            // qryVmMandatsTyp
            // 
            this.qryVmMandatsTyp.HostControl = this;
            this.qryVmMandatsTyp.TableName = "XLOVCode";
            // 
            // qryUser
            // 
            this.qryUser.HostControl = this;
            this.qryUser.TableName = "XUser";
            // 
            // FrmVmBewertung
            // 
            this.ActiveSQLQuery = this.qryMandant;
            this.ClientSize = new System.Drawing.Size(1022, 626);
            this.Controls.Add(this.grdMandanten);
            this.Controls.Add(this.lblAuslastungProzent);
            this.Controls.Add(this.edtAuslastung);
            this.Controls.Add(this.edtAnzahlTotal);
            this.Controls.Add(this.edtAnzahlD);
            this.Controls.Add(this.edtAnzahlC);
            this.Controls.Add(this.edtAnzahlB);
            this.Controls.Add(this.edtAnzahlA);
            this.Controls.Add(this.lblAuslastung);
            this.Controls.Add(this.lblAnzahlD);
            this.Controls.Add(this.lblAnzahlC);
            this.Controls.Add(this.lblAnzahlB);
            this.Controls.Add(this.lblAnzahlA);
            this.Controls.Add(this.lblAnzahlTotal);
            this.Controls.Add(this.ctlVmKriterien);
            this.Controls.Add(this.lblSAR);
            this.Controls.Add(this.edtSAR);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmVmBewertung";
            this.Text = "VM Fallgewichtung";
            //this.Shown += new System.EventHandler(this.FrmVmBewertung_Shown); TODO: check if it's work without it
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMandanten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMandanten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuslastung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuslastung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuslastungProzent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmMandatsTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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

        private KiSS4.Gui.KissGrid grdMandanten;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraGrid.Columns.GridColumn colBewilligt;
        private DevExpress.XtraGrid.Columns.GridColumn colFallTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colTage;
        private DevExpress.XtraGrid.Columns.GridColumn colZGB;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Vormundschaft.CtlVmKriterien ctlVmKriterien;
        private KiSS4.Gui.KissCalcEdit edtAnzahlA;
        private KiSS4.Gui.KissCalcEdit edtAnzahlB;
        private KiSS4.Gui.KissCalcEdit edtAnzahlC;
        private KiSS4.Gui.KissCalcEdit edtAnzahlD;
        private KiSS4.Gui.KissCalcEdit edtAnzahlTotal;
        private KiSS4.Gui.KissCalcEdit edtAuslastung;
        private KiSS4.Gui.KissButtonEdit edtSAR;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMandanten;
        private KiSS4.Gui.KissLabel lblAnzahlA;
        private KiSS4.Gui.KissLabel lblAuslastungProzent;
        private KiSS4.Gui.KissLabel lblAnzahlB;
        private KiSS4.Gui.KissLabel lblAnzahlC;
        private KiSS4.Gui.KissLabel lblAnzahlD;
        private KiSS4.Gui.KissLabel lblAnzahlTotal;
        private KiSS4.Gui.KissLabel lblAuslastung;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.DB.SqlQuery qryMandant;
        private KiSS4.DB.SqlQuery qryUser;
        private KiSS4.DB.SqlQuery qryVmMandatsTyp;
    }
}