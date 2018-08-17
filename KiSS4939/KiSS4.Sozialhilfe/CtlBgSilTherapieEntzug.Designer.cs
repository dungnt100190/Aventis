namespace KiSS4.Sozialhilfe
{
    partial class CtlBgSilTherapieEntzug
    {
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBgSilTherapieEntzug));
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdBgPosition = new KiSS4.Gui.KissGrid();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.grvBgPosition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBgPositionsartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInstitution = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBewStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgPositionsartID = new KiSS4.Gui.KissLabel();
            this.edtBgPositionsartID = new KiSS4.Gui.KissLookUpEdit();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblVon = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblBis = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblInstitution = new KiSS4.Gui.KissLabel();
            this.edtInstitution = new KiSS4.Gui.KissButtonEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.btnAnpassen = new KiSS4.Gui.KissButton();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.btnBewilligung = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(648, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "{2} vom {0:d} bis {1:d}";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // grdBgPosition
            // 
            this.grdBgPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBgPosition.DataSource = this.qryBgPosition;
            // 
            // 
            // 
            this.grdBgPosition.EmbeddedNavigator.Name = "";
            this.grdBgPosition.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgPosition.Location = new System.Drawing.Point(8, 37);
            this.grdBgPosition.MainView = this.grvBgPosition;
            this.grdBgPosition.Name = "grdBgPosition";
            this.grdBgPosition.Size = new System.Drawing.Size(697, 197);
            this.grdBgPosition.TabIndex = 1;
            this.grdBgPosition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgPosition});
            // 
            // qryBgPosition
            // 
            this.qryBgPosition.CanDelete = true;
            this.qryBgPosition.CanInsert = true;
            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.FillTimeOut = 600;
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.InsertTimeOut = 600;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.TableName = "BgPosition";
            this.qryBgPosition.UpdateTimeOut = 600;
            this.qryBgPosition.BeforeInsert += new System.EventHandler(this.qryBgPosition_BeforeInsert);
            this.qryBgPosition.AfterInsert += new System.EventHandler(this.qryBgPosition_AfterInsert);
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
            this.qryBgPosition.AfterPost += new System.EventHandler(this.qryBgPosition_AfterPost);
            this.qryBgPosition.BeforeDeleteQuestion += new System.EventHandler(this.qryBgPosition_BeforeDeleteQuestion);
            this.qryBgPosition.PositionChanged += new System.EventHandler(this.qryBgPosition_PositionChanged);
            // 
            // grvBgPosition
            // 
            this.grvBgPosition.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgPosition.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.Empty.Options.UseFont = true;
            this.grvBgPosition.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPosition.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPosition.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPosition.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPosition.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPosition.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgPosition.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgPosition.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgPosition.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgPosition.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPosition.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.OddRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgPosition.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.Row.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.Row.Options.UseFont = true;
            this.grvBgPosition.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPosition.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgPosition.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgPosition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatumVon,
            this.colBaPersonID,
            this.colPersNr,
            this.colGeburtsdatum,
            this.colBgPositionsartID,
            this.colBetrag,
            this.colInstitution,
            this.colBewStatus});
            this.grvBgPosition.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgPosition.GridControl = this.grdBgPosition;
            this.grvBgPosition.Name = "grvBgPosition";
            this.grvBgPosition.OptionsBehavior.Editable = false;
            this.grvBgPosition.OptionsCustomization.AllowFilter = false;
            this.grvBgPosition.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgPosition.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgPosition.OptionsNavigation.UseTabKey = false;
            this.grvBgPosition.OptionsView.ColumnAutoWidth = false;
            this.grvBgPosition.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgPosition.OptionsView.ShowFooter = true;
            this.grvBgPosition.OptionsView.ShowGroupPanel = false;
            this.grvBgPosition.OptionsView.ShowIndicator = false;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Gültig ab";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Caption = "Name";
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.Visible = true;
            this.colBaPersonID.VisibleIndex = 1;
            this.colBaPersonID.Width = 127;
            // 
            // colPersNr
            // 
            this.colPersNr.Caption = "Pers.-Nr.";
            this.colPersNr.FieldName = "BaPersonID";
            this.colPersNr.Name = "colPersNr";
            this.colPersNr.Visible = true;
            this.colPersNr.VisibleIndex = 2;
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Caption = "Geburtsdatum";
            this.colGeburtsdatum.DisplayFormat.FormatString = "d";
            this.colGeburtsdatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colGeburtsdatum.FieldName = "Geburtsdatum";
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            this.colGeburtsdatum.Visible = true;
            this.colGeburtsdatum.VisibleIndex = 3;
            // 
            // colBgPositionsartID
            // 
            this.colBgPositionsartID.Caption = "Leistungsart";
            this.colBgPositionsartID.FieldName = "BgPositionsartID";
            this.colBgPositionsartID.Name = "colBgPositionsartID";
            this.colBgPositionsartID.Visible = true;
            this.colBgPositionsartID.VisibleIndex = 4;
            this.colBgPositionsartID.Width = 193;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 5;
            // 
            // colInstitution
            // 
            this.colInstitution.Caption = "Institution";
            this.colInstitution.FieldName = "InstitutionName";
            this.colInstitution.Name = "colInstitution";
            this.colInstitution.Visible = true;
            this.colInstitution.VisibleIndex = 6;
            // 
            // colBewStatus
            // 
            this.colBewStatus.Caption = "Bew. Status";
            this.colBewStatus.FieldName = "BgBewilligungStatusCode";
            this.colBewStatus.Name = "colBewStatus";
            this.colBewStatus.Visible = true;
            this.colBewStatus.VisibleIndex = 7;
            this.colBewStatus.Width = 130;
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Location = new System.Drawing.Point(8, 240);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(65, 24);
            this.lblBaPersonID.TabIndex = 2;
            this.lblBaPersonID.Text = "Person";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryBgPosition;
            this.edtBaPersonID.Location = new System.Drawing.Point(100, 240);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
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
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Size = new System.Drawing.Size(376, 24);
            this.edtBaPersonID.TabIndex = 3;
            // 
            // lblBgPositionsartID
            // 
            this.lblBgPositionsartID.Location = new System.Drawing.Point(8, 270);
            this.lblBgPositionsartID.Name = "lblBgPositionsartID";
            this.lblBgPositionsartID.Size = new System.Drawing.Size(73, 24);
            this.lblBgPositionsartID.TabIndex = 4;
            this.lblBgPositionsartID.Text = "LA";
            this.lblBgPositionsartID.UseCompatibleTextRendering = true;
            // 
            // edtBgPositionsartID
            // 
            this.edtBgPositionsartID.DataMember = "BgPositionsartID";
            this.edtBgPositionsartID.DataSource = this.qryBgPosition;
            this.edtBgPositionsartID.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBgPositionsartID.Location = new System.Drawing.Point(100, 270);
            this.edtBgPositionsartID.Name = "edtBgPositionsartID";
            this.edtBgPositionsartID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBgPositionsartID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgPositionsartID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgPositionsartID.Properties.Appearance.Options.UseFont = true;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgPositionsartID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBgPositionsartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgPositionsartID.Properties.NullText = "";
            this.edtBgPositionsartID.Properties.ShowFooter = false;
            this.edtBgPositionsartID.Properties.ShowHeader = false;
            this.edtBgPositionsartID.Size = new System.Drawing.Size(376, 24);
            this.edtBgPositionsartID.TabIndex = 5;
            // 
            // lblBetrag
            // 
            this.lblBetrag.Location = new System.Drawing.Point(8, 300);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(73, 24);
            this.lblBetrag.TabIndex = 6;
            this.lblBetrag.Text = "mtl.  Betrag";
            this.lblBetrag.UseCompatibleTextRendering = true;
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryBgPosition;
            this.edtBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBetrag.Location = new System.Drawing.Point(100, 300);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Size = new System.Drawing.Size(112, 24);
            this.edtBetrag.TabIndex = 7;
            // 
            // lblVon
            // 
            this.lblVon.Location = new System.Drawing.Point(8, 330);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(86, 24);
            this.lblVon.TabIndex = 8;
            this.lblVon.Text = "geplant von";
            this.lblVon.UseCompatibleTextRendering = true;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryBgPosition;
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(100, 330);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(112, 24);
            this.edtDatumVon.TabIndex = 9;
            // 
            // lblBis
            // 
            this.lblBis.Location = new System.Drawing.Point(219, 330);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(40, 24);
            this.lblBis.TabIndex = 10;
            this.lblBis.Text = "bis";
            this.lblBis.UseCompatibleTextRendering = true;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryBgPosition;
            this.edtDatumBis.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(264, 330);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(112, 24);
            this.edtDatumBis.TabIndex = 11;
            // 
            // lblInstitution
            // 
            this.lblInstitution.Location = new System.Drawing.Point(9, 361);
            this.lblInstitution.Name = "lblInstitution";
            this.lblInstitution.Size = new System.Drawing.Size(72, 24);
            this.lblInstitution.TabIndex = 12;
            this.lblInstitution.Text = "Institution";
            this.lblInstitution.UseCompatibleTextRendering = true;
            // 
            // edtInstitution
            // 
            this.edtInstitution.DataMember = "InstitutionName";
            this.edtInstitution.DataSource = this.qryBgPosition;
            this.edtInstitution.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtInstitution.Location = new System.Drawing.Point(100, 360);
            this.edtInstitution.Name = "edtInstitution";
            this.edtInstitution.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtInstitution.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInstitution.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInstitution.Properties.Appearance.Options.UseBackColor = true;
            this.edtInstitution.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInstitution.Properties.Appearance.Options.UseFont = true;
            this.edtInstitution.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtInstitution.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInstitution.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtInstitution.Size = new System.Drawing.Size(376, 24);
            this.edtInstitution.TabIndex = 13;
            this.edtInstitution.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtInstitution_UserModifiedFld);
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBemerkung.Location = new System.Drawing.Point(9, 400);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(112, 16);
            this.lblBemerkung.TabIndex = 14;
            this.lblBemerkung.Text = "Begründung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgPosition;
            this.edtBemerkung.Location = new System.Drawing.Point(8, 420);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(697, 60);
            this.edtBemerkung.TabIndex = 15;
            // 
            // btnAnpassen
            // 
            this.btnAnpassen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnpassen.Location = new System.Drawing.Point(9, 493);
            this.btnAnpassen.Name = "btnAnpassen";
            this.btnAnpassen.Size = new System.Drawing.Size(248, 24);
            this.btnAnpassen.TabIndex = 16;
            this.btnAnpassen.Text = "bewilligte Beträge anpassen";
            this.btnAnpassen.UseCompatibleTextRendering = true;
            this.btnAnpassen.UseVisualStyleBackColor = false;
            this.btnAnpassen.Click += new System.EventHandler(this.btnAnpassen_Click);
            // 
            // picTitle
            // 
            this.picTitle.Location = new System.Drawing.Point(8, 8);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(16, 16);
            this.picTitle.TabIndex = 55;
            this.picTitle.TabStop = false;
            // 
            // btnBewilligung
            // 
            this.btnBewilligung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBewilligung.Image = ((System.Drawing.Image)(resources.GetObject("btnBewilligung.Image")));
            this.btnBewilligung.Location = new System.Drawing.Point(263, 493);
            this.btnBewilligung.Name = "btnBewilligung";
            this.btnBewilligung.Size = new System.Drawing.Size(24, 24);
            this.btnBewilligung.TabIndex = 57;
            this.btnBewilligung.UseCompatibleTextRendering = true;
            this.btnBewilligung.UseVisualStyleBackColor = false;
            this.btnBewilligung.Click += new System.EventHandler(this.btnBewilligung_Click);
            // 
            // CtlBgSilTherapieEntzug
            // 
            this.ActiveSQLQuery = this.qryBgPosition;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(500, 510);
            this.Controls.Add(this.btnBewilligung);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.btnAnpassen);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.edtInstitution);
            this.Controls.Add(this.lblInstitution);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.lblBis);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.lblVon);
            this.Controls.Add(this.edtBetrag);
            this.Controls.Add(this.lblBetrag);
            this.Controls.Add(this.edtBgPositionsartID);
            this.Controls.Add(this.lblBgPositionsartID);
            this.Controls.Add(this.edtBaPersonID);
            this.Controls.Add(this.lblBaPersonID);
            this.Controls.Add(this.grdBgPosition);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlBgSilTherapieEntzug";
            this.Size = new System.Drawing.Size(713, 520);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnAnpassen;
        private KiSS4.Gui.KissButton btnBewilligung;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBewStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colBgPositionsartID;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colInstitution;
        private DevExpress.XtraGrid.Columns.GridColumn colPersNr;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissLookUpEdit edtBgPositionsartID;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissButtonEdit edtInstitution;
        private KiSS4.Gui.KissGrid grdBgPosition;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgPosition;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBgPositionsartID;
        private KiSS4.Gui.KissLabel lblBis;
        private KiSS4.Gui.KissLabel lblInstitution;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblVon;
        private System.Windows.Forms.PictureBox picTitle;
        private KiSS4.DB.SqlQuery qryBgPosition;
    }
}
