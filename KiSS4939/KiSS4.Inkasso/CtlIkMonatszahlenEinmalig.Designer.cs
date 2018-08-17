namespace KiSS4.Inkasso
{
    public partial class CtlIkMonatszahlenEinmalig
    {
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragAusgeglichen;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colIkForderungCode;
        private DevExpress.XtraGrid.Columns.GridColumn colNegativ;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colVerbucht;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtBetragAusgeglichen;
        private KiSS4.Gui.KissCalcEdit edtBetragEinmalig;
        private KiSS4.Gui.KissCheckEdit edtBetragIstNegativ;
        private KiSS4.Gui.KissDateEdit edtDatum;
        private KiSS4.Gui.KissLookUpEdit edtIkForderungEinmaligCode;
        private KiSS4.Gui.KissCheckEdit edtVerbucht;
        private KiSS4.Gui.KissGrid grdIkPosition;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIkPosition;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBetragBeglichen;
        private KiSS4.Gui.KissLabel lblBetragEinmalig;
        private KiSS4.Gui.KissLabel lblBetragIstNegativ;
        private KiSS4.Gui.KissLabel lblDatum;
        private KiSS4.Gui.KissLabel lblIkForderungEinmaligCode;
        private KiSS4.DB.SqlQuery qryPerson;
        private KiSS4.DB.SqlQuery qryIkPosition;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkMonatszahlenEinmalig));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdIkPosition = new KiSS4.Gui.KissGrid();
            this.qryIkPosition = new KiSS4.DB.SqlQuery();
            this.grvIkPosition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkForderungCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerbucht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNegativ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragAusgeglichen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.edtIkForderungEinmaligCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.edtDatum = new KiSS4.Gui.KissDateEdit();
            this.edtBetragEinmalig = new KiSS4.Gui.KissCalcEdit();
            this.edtBetragIstNegativ = new KiSS4.Gui.KissCheckEdit();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.lblBetragEinmalig = new KiSS4.Gui.KissLabel();
            this.lblIkForderungEinmaligCode = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.lblBetragIstNegativ = new KiSS4.Gui.KissLabel();
            this.edtVerbucht = new KiSS4.Gui.KissCheckEdit();
            this.qryPerson = new KiSS4.DB.SqlQuery();
            this.lblBetragBeglichen = new KiSS4.Gui.KissLabel();
            this.edtBetragAusgeglichen = new KiSS4.Gui.KissCalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIkPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIkPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkForderungEinmaligCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkForderungEinmaligCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragEinmalig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragIstNegativ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragEinmalig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkForderungEinmaligCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragIstNegativ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerbucht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragBeglichen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragAusgeglichen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdIkPosition
            // 
            this.grdIkPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdIkPosition.DataSource = this.qryIkPosition;
            // 
            // 
            // 
            this.grdIkPosition.EmbeddedNavigator.Name = "";
            this.grdIkPosition.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdIkPosition.Location = new System.Drawing.Point(10, 8);
            this.grdIkPosition.MainView = this.grvIkPosition;
            this.grdIkPosition.Name = "grdIkPosition";
            this.grdIkPosition.Size = new System.Drawing.Size(684, 245);
            this.grdIkPosition.TabIndex = 0;
            this.grdIkPosition.TabStop = false;
            this.grdIkPosition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIkPosition});
            // 
            // qryIkPosition
            // 
            this.qryIkPosition.CanDelete = true;
            this.qryIkPosition.CanInsert = true;
            this.qryIkPosition.CanUpdate = true;
            this.qryIkPosition.HostControl = this;
            this.qryIkPosition.SelectStatement = resources.GetString("qryIkPosition.SelectStatement");
            this.qryIkPosition.TableName = "IkPosition";
            this.qryIkPosition.AfterFill += new System.EventHandler(this.qryIkPosition_AfterFill);
            this.qryIkPosition.AfterInsert += new System.EventHandler(this.qryIkPosition_AfterInsert);
            this.qryIkPosition.BeforePost += new System.EventHandler(this.qryIkPosition_BeforePost);
            this.qryIkPosition.AfterPost += new System.EventHandler(this.qryIkPosition_AfterPost);
            this.qryIkPosition.PositionChanged += new System.EventHandler(this.qryIkPosition_PositionChanged);
            // 
            // grvIkPosition
            // 
            this.grvIkPosition.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvIkPosition.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkPosition.Appearance.Empty.Options.UseBackColor = true;
            this.grvIkPosition.Appearance.Empty.Options.UseFont = true;
            this.grvIkPosition.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvIkPosition.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkPosition.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvIkPosition.Appearance.EvenRow.Options.UseFont = true;
            this.grvIkPosition.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvIkPosition.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkPosition.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvIkPosition.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvIkPosition.Appearance.FocusedCell.Options.UseFont = true;
            this.grvIkPosition.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvIkPosition.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvIkPosition.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkPosition.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvIkPosition.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvIkPosition.Appearance.FocusedRow.Options.UseFont = true;
            this.grvIkPosition.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvIkPosition.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvIkPosition.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvIkPosition.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvIkPosition.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvIkPosition.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvIkPosition.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvIkPosition.Appearance.GroupRow.Options.UseFont = true;
            this.grvIkPosition.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvIkPosition.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvIkPosition.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvIkPosition.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvIkPosition.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvIkPosition.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvIkPosition.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvIkPosition.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvIkPosition.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkPosition.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvIkPosition.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvIkPosition.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvIkPosition.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvIkPosition.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvIkPosition.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvIkPosition.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkPosition.Appearance.OddRow.Options.UseFont = true;
            this.grvIkPosition.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvIkPosition.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkPosition.Appearance.Row.Options.UseBackColor = true;
            this.grvIkPosition.Appearance.Row.Options.UseFont = true;
            this.grvIkPosition.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvIkPosition.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkPosition.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvIkPosition.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvIkPosition.Appearance.SelectedRow.Options.UseFont = true;
            this.grvIkPosition.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvIkPosition.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvIkPosition.Appearance.VertLine.Options.UseBackColor = true;
            this.grvIkPosition.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvIkPosition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colPerson,
            this.colIkForderungCode,
            this.colBetrag,
            this.colVerbucht,
            this.colNegativ,
            this.colBetragAusgeglichen});
            this.grvIkPosition.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvIkPosition.GridControl = this.grdIkPosition;
            this.grvIkPosition.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
            this.grvIkPosition.Name = "grvIkPosition";
            this.grvIkPosition.OptionsBehavior.Editable = false;
            this.grvIkPosition.OptionsCustomization.AllowFilter = false;
            this.grvIkPosition.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvIkPosition.OptionsNavigation.AutoFocusNewRow = true;
            this.grvIkPosition.OptionsNavigation.UseTabKey = false;
            this.grvIkPosition.OptionsView.ColumnAutoWidth = false;
            this.grvIkPosition.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvIkPosition.OptionsView.ShowGroupPanel = false;
            this.grvIkPosition.OptionsView.ShowIndicator = false;
            this.grvIkPosition.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvIkPosition_CustomDrawCell);
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.OptionsColumn.AllowEdit = false;
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 2;
            this.colDatum.Width = 85;
            // 
            // colPerson
            // 
            this.colPerson.Caption = "Person, Gläubiger";
            this.colPerson.Name = "colPerson";
            this.colPerson.OptionsColumn.AllowEdit = false;
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 0;
            this.colPerson.Width = 184;
            // 
            // colIkForderungCode
            // 
            this.colIkForderungCode.Caption = "Forderungstitel";
            this.colIkForderungCode.Name = "colIkForderungCode";
            this.colIkForderungCode.Visible = true;
            this.colIkForderungCode.VisibleIndex = 1;
            this.colIkForderungCode.Width = 224;
            // 
            // colBetrag
            // 
            this.colBetrag.AppearanceHeader.Options.UseTextOptions = true;
            this.colBetrag.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 3;
            this.colBetrag.Width = 94;
            // 
            // colVerbucht
            // 
            this.colVerbucht.AppearanceCell.Options.UseTextOptions = true;
            this.colVerbucht.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerbucht.Caption = "verb.";
            this.colVerbucht.MinWidth = 10;
            this.colVerbucht.Name = "colVerbucht";
            this.colVerbucht.Visible = true;
            this.colVerbucht.VisibleIndex = 4;
            this.colVerbucht.Width = 40;
            // 
            // colNegativ
            // 
            this.colNegativ.Caption = "neg.";
            this.colNegativ.Name = "colNegativ";
            this.colNegativ.Visible = true;
            this.colNegativ.VisibleIndex = 5;
            this.colNegativ.Width = 40;
            // 
            // colBetragAusgeglichen
            // 
            this.colBetragAusgeglichen.Caption = "beglichenen Betrag";
            this.colBetragAusgeglichen.DisplayFormat.FormatString = "N2";
            this.colBetragAusgeglichen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragAusgeglichen.Name = "colBetragAusgeglichen";
            this.colBetragAusgeglichen.Visible = true;
            this.colBetragAusgeglichen.VisibleIndex = 6;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBaPersonID.DataSource = this.qryIkPosition;
            this.edtBaPersonID.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBaPersonID.Location = new System.Drawing.Point(134, 259);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaPersonID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Text", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBaPersonID.Properties.DisplayMember = "Text";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "BaPersonID";
            this.edtBaPersonID.Size = new System.Drawing.Size(285, 24);
            this.edtBaPersonID.TabIndex = 1;
            // 
            // edtIkForderungEinmaligCode
            // 
            this.edtIkForderungEinmaligCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIkForderungEinmaligCode.DataSource = this.qryIkPosition;
            this.edtIkForderungEinmaligCode.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtIkForderungEinmaligCode.FilterOnIsActive = true;
            this.edtIkForderungEinmaligCode.Location = new System.Drawing.Point(134, 289);
            this.edtIkForderungEinmaligCode.LOVName = "IkForderungEinmalig";
            this.edtIkForderungEinmaligCode.Name = "edtIkForderungEinmaligCode";
            this.edtIkForderungEinmaligCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtIkForderungEinmaligCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkForderungEinmaligCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkForderungEinmaligCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkForderungEinmaligCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkForderungEinmaligCode.Properties.Appearance.Options.UseFont = true;
            this.edtIkForderungEinmaligCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIkForderungEinmaligCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkForderungEinmaligCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIkForderungEinmaligCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIkForderungEinmaligCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtIkForderungEinmaligCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtIkForderungEinmaligCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkForderungEinmaligCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtIkForderungEinmaligCode.Properties.DisplayMember = "Text";
            this.edtIkForderungEinmaligCode.Properties.NullText = "";
            this.edtIkForderungEinmaligCode.Properties.ShowFooter = false;
            this.edtIkForderungEinmaligCode.Properties.ShowHeader = false;
            this.edtIkForderungEinmaligCode.Properties.ValueMember = "Code";
            this.edtIkForderungEinmaligCode.Size = new System.Drawing.Size(285, 24);
            this.edtIkForderungEinmaligCode.TabIndex = 2;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.DataSource = this.qryIkPosition;
            this.edtBemerkung.EditValue = "";
            this.edtBemerkung.Location = new System.Drawing.Point(134, 319);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(285, 76);
            this.edtBemerkung.TabIndex = 4;
            // 
            // edtDatum
            // 
            this.edtDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatum.DataSource = this.qryIkPosition;
            this.edtDatum.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatum.EditValue = null;
            this.edtDatum.Location = new System.Drawing.Point(573, 259);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatum.Properties.ShowToday = false;
            this.edtDatum.Size = new System.Drawing.Size(123, 24);
            this.edtDatum.TabIndex = 5;
            // 
            // edtBetragEinmalig
            // 
            this.edtBetragEinmalig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBetragEinmalig.DataSource = this.qryIkPosition;
            this.edtBetragEinmalig.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBetragEinmalig.Location = new System.Drawing.Point(573, 289);
            this.edtBetragEinmalig.Name = "edtBetragEinmalig";
            this.edtBetragEinmalig.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetragEinmalig.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBetragEinmalig.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetragEinmalig.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetragEinmalig.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetragEinmalig.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetragEinmalig.Properties.Appearance.Options.UseFont = true;
            this.edtBetragEinmalig.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetragEinmalig.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetragEinmalig.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetragEinmalig.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragEinmalig.Properties.EditFormat.FormatString = "n2";
            this.edtBetragEinmalig.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragEinmalig.Properties.Mask.EditMask = "N2";
            this.edtBetragEinmalig.Size = new System.Drawing.Size(123, 24);
            this.edtBetragEinmalig.TabIndex = 6;
            // 
            // edtBetragIstNegativ
            // 
            this.edtBetragIstNegativ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBetragIstNegativ.DataSource = this.qryIkPosition;
            this.edtBetragIstNegativ.EditValue = false;
            this.edtBetragIstNegativ.Location = new System.Drawing.Point(460, 336);
            this.edtBetragIstNegativ.Name = "edtBetragIstNegativ";
            this.edtBetragIstNegativ.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtBetragIstNegativ.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetragIstNegativ.Properties.Caption = "Betrag ist negativ für Storno oder";
            this.edtBetragIstNegativ.Size = new System.Drawing.Size(222, 19);
            this.edtBetragIstNegativ.TabIndex = 7;
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBaPersonID.Location = new System.Drawing.Point(10, 257);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(118, 24);
            this.lblBaPersonID.TabIndex = 21;
            this.lblBaPersonID.Text = "Person, Kostenstelle";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            // 
            // lblBetragEinmalig
            // 
            this.lblBetragEinmalig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBetragEinmalig.Location = new System.Drawing.Point(460, 289);
            this.lblBetragEinmalig.Name = "lblBetragEinmalig";
            this.lblBetragEinmalig.Size = new System.Drawing.Size(72, 24);
            this.lblBetragEinmalig.TabIndex = 25;
            this.lblBetragEinmalig.Text = "Betrag ";
            this.lblBetragEinmalig.UseCompatibleTextRendering = true;
            // 
            // lblIkForderungEinmaligCode
            // 
            this.lblIkForderungEinmaligCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIkForderungEinmaligCode.Location = new System.Drawing.Point(10, 289);
            this.lblIkForderungEinmaligCode.Name = "lblIkForderungEinmaligCode";
            this.lblIkForderungEinmaligCode.Size = new System.Drawing.Size(106, 24);
            this.lblIkForderungEinmaligCode.TabIndex = 26;
            this.lblIkForderungEinmaligCode.Text = "Teilforderungsart";
            this.lblIkForderungEinmaligCode.UseCompatibleTextRendering = true;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung.Location = new System.Drawing.Point(10, 319);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(106, 24);
            this.lblBemerkung.TabIndex = 27;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblDatum
            // 
            this.lblDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatum.Location = new System.Drawing.Point(460, 259);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(80, 24);
            this.lblDatum.TabIndex = 28;
            this.lblDatum.Text = "Datum per";
            this.lblDatum.UseCompatibleTextRendering = true;
            // 
            // lblBetragIstNegativ
            // 
            this.lblBetragIstNegativ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBetragIstNegativ.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBetragIstNegativ.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBetragIstNegativ.Location = new System.Drawing.Point(481, 354);
            this.lblBetragIstNegativ.Name = "lblBetragIstNegativ";
            this.lblBetragIstNegativ.Size = new System.Drawing.Size(209, 13);
            this.lblBetragIstNegativ.TabIndex = 30;
            this.lblBetragIstNegativ.Text = "Aushändigung eines Verlustscheines";
            this.lblBetragIstNegativ.UseCompatibleTextRendering = true;
            // 
            // edtVerbucht
            // 
            this.edtVerbucht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVerbucht.DataSource = this.qryIkPosition;
            this.edtVerbucht.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVerbucht.EditValue = false;
            this.edtVerbucht.Location = new System.Drawing.Point(460, 374);
            this.edtVerbucht.Name = "edtVerbucht";
            this.edtVerbucht.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtVerbucht.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerbucht.Properties.Caption = "Verbucht";
            this.edtVerbucht.Properties.ReadOnly = true;
            this.edtVerbucht.Size = new System.Drawing.Size(209, 19);
            this.edtVerbucht.TabIndex = 32;
            // 
            // qryPerson
            // 
            this.qryPerson.SelectStatement = resources.GetString("qryPerson.SelectStatement");
            // 
            // lblBetragBeglichen
            // 
            this.lblBetragBeglichen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBetragBeglichen.Location = new System.Drawing.Point(460, 399);
            this.lblBetragBeglichen.Name = "lblBetragBeglichen";
            this.lblBetragBeglichen.Size = new System.Drawing.Size(107, 24);
            this.lblBetragBeglichen.TabIndex = 34;
            this.lblBetragBeglichen.Text = "Beglichener Betrag";
            this.lblBetragBeglichen.UseCompatibleTextRendering = true;
            // 
            // edtBetragAusgeglichen
            // 
            this.edtBetragAusgeglichen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBetragAusgeglichen.DataSource = this.qryIkPosition;
            this.edtBetragAusgeglichen.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetragAusgeglichen.Location = new System.Drawing.Point(573, 399);
            this.edtBetragAusgeglichen.Name = "edtBetragAusgeglichen";
            this.edtBetragAusgeglichen.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetragAusgeglichen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetragAusgeglichen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetragAusgeglichen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetragAusgeglichen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetragAusgeglichen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetragAusgeglichen.Properties.Appearance.Options.UseFont = true;
            this.edtBetragAusgeglichen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetragAusgeglichen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetragAusgeglichen.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetragAusgeglichen.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragAusgeglichen.Properties.EditFormat.FormatString = "n2";
            this.edtBetragAusgeglichen.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragAusgeglichen.Properties.Mask.EditMask = "N2";
            this.edtBetragAusgeglichen.Properties.ReadOnly = true;
            this.edtBetragAusgeglichen.Size = new System.Drawing.Size(123, 24);
            this.edtBetragAusgeglichen.TabIndex = 33;
            // 
            // CtlIkMonatszahlenEinmalig
            // 
            this.ActiveSQLQuery = this.qryIkPosition;
            this.Controls.Add(this.lblBetragBeglichen);
            this.Controls.Add(this.edtBetragAusgeglichen);
            this.Controls.Add(this.edtVerbucht);
            this.Controls.Add(this.lblBetragIstNegativ);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblIkForderungEinmaligCode);
            this.Controls.Add(this.lblBetragEinmalig);
            this.Controls.Add(this.lblBaPersonID);
            this.Controls.Add(this.edtBetragIstNegativ);
            this.Controls.Add(this.edtBetragEinmalig);
            this.Controls.Add(this.edtDatum);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.edtIkForderungEinmaligCode);
            this.Controls.Add(this.edtBaPersonID);
            this.Controls.Add(this.grdIkPosition);
            this.Name = "CtlIkMonatszahlenEinmalig";
            this.Size = new System.Drawing.Size(707, 432);
            this.Load += new System.EventHandler(this.CtlIkMonatszahlenEinmalig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdIkPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIkPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkForderungEinmaligCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkForderungEinmaligCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragEinmalig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragIstNegativ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragEinmalig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkForderungEinmaligCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragIstNegativ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerbucht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragBeglichen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragAusgeglichen.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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
    }
}