namespace KiSS4.Common
{
    partial class CtlFrmFallZugriff
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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

        #endregion

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFrmFallZugriff));
            this.qryFall = new KiSS4.DB.SqlQuery(this.components);
            this.gridVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryKandidaten = new KiSS4.DB.SqlQuery(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridZugeteilt = new KiSS4.Gui.KissGrid();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMutieren = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSetOwner = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.editOwnerSAR = new KiSS4.Gui.KissTextEdit();
            this.lblFB = new KiSS4.Gui.KissLabel();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.edtPerson = new KiSS4.Gui.KissTextEdit();
            this.lblPerson = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.edtModulCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblModulCode = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtArchiviert = new KiSS4.Gui.KissCheckEdit();
            this.lblFilter = new KiSS4.Gui.KissLabel();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKandidaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editOwnerSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArchiviert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryFall
            // 
            this.qryFall.AutoApplyUserRights = false;
            this.qryFall.CanUpdate = true;
            this.qryFall.HostControl = this;
            this.qryFall.SelectStatement = resources.GetString("qryFall.SelectStatement");
            this.qryFall.TableName = "FaLeistung";
            this.qryFall.AfterPost += new System.EventHandler(this.qryFall_AfterPost);
            this.qryFall.BeforePost += new System.EventHandler(this.qryFall_BeforePost);
            this.qryFall.PositionChanged += new System.EventHandler(this.qryFall_PositionChanged);
            // 
            // gridVerfuegbar
            // 
            this.gridVerfuegbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridVerfuegbar.DataSource = this.qryKandidaten;
            // 
            // 
            // 
            this.gridVerfuegbar.EmbeddedNavigator.Name = "";
            this.gridVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridVerfuegbar.Location = new System.Drawing.Point(5, 129);
            this.gridVerfuegbar.MainView = this.gridView1;
            this.gridVerfuegbar.Name = "gridVerfuegbar";
            this.gridVerfuegbar.Size = new System.Drawing.Size(230, 214);
            this.gridVerfuegbar.TabIndex = 19;
            this.gridVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridVerfuegbar.DoubleClick += new System.EventHandler(this.gridVerfuegbar_DoubleClick);
            this.gridVerfuegbar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridVerfuegbar_KeyPress);
            // 
            // qryKandidaten
            // 
            this.qryKandidaten.HostControl = this;
            this.qryKandidaten.SelectStatement = resources.GetString("qryKandidaten.SelectStatement");
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
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
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUser2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.gridVerfuegbar;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colUser2
            // 
            this.colUser2.Caption = "Kandidaten";
            this.colUser2.FieldName = "UserName";
            this.colUser2.Name = "colUser2";
            this.colUser2.Visible = true;
            this.colUser2.VisibleIndex = 0;
            this.colUser2.Width = 202;
            // 
            // gridZugeteilt
            // 
            this.gridZugeteilt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridZugeteilt.DataSource = this.qryZugeteilt;
            // 
            // 
            // 
            this.gridZugeteilt.EmbeddedNavigator.Name = "";
            this.gridZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.gridZugeteilt.Location = new System.Drawing.Point(275, 175);
            this.gridZugeteilt.MainView = this.gridView2;
            this.gridZugeteilt.Name = "gridZugeteilt";
            this.gridZugeteilt.Size = new System.Drawing.Size(468, 198);
            this.gridZugeteilt.TabIndex = 24;
            this.gridZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // qryZugeteilt
            // 
            this.qryZugeteilt.AutoApplyUserRights = false;
            this.qryZugeteilt.CanDelete = true;
            this.qryZugeteilt.CanInsert = true;
            this.qryZugeteilt.CanUpdate = true;
            this.qryZugeteilt.DeleteQuestion = null;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.SelectStatement = resources.GetString("qryZugeteilt.SelectStatement");
            this.qryZugeteilt.TableName = "FaLeistungZugriff";
            this.qryZugeteilt.BeforePost += new System.EventHandler(this.qryZugeteilt_BeforePost);
            this.qryZugeteilt.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryZugeteilt_ColumnChanged);
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView2.Appearance.EvenRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUser,
            this.colMutieren,
            this.colDatumVon,
            this.colDatumBis});
            this.gridView2.GridControl = this.gridZugeteilt;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsFilter.AllowFilterEditor = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colUser
            // 
            this.colUser.Caption = "SAR mit Gastrecht";
            this.colUser.FieldName = "UserName";
            this.colUser.Name = "colUser";
            this.colUser.OptionsColumn.AllowEdit = false;
            this.colUser.OptionsColumn.ReadOnly = true;
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 0;
            this.colUser.Width = 188;
            // 
            // colMutieren
            // 
            this.colMutieren.Caption = "Mutieren";
            this.colMutieren.FieldName = "DarfMutieren";
            this.colMutieren.Name = "colMutieren";
            this.colMutieren.Visible = true;
            this.colMutieren.VisibleIndex = 1;
            this.colMutieren.Width = 61;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "DatumVon";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 2;
            this.colDatumVon.Width = 86;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "DatumBis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 3;
            this.colDatumBis.Width = 86;
            // 
            // btnSetOwner
            // 
            this.btnSetOwner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetOwner.IconID = 13;
            this.btnSetOwner.Location = new System.Drawing.Point(241, 130);
            this.btnSetOwner.Name = "btnSetOwner";
            this.btnSetOwner.Size = new System.Drawing.Size(28, 24);
            this.btnSetOwner.TabIndex = 20;
            this.btnSetOwner.UseVisualStyleBackColor = false;
            this.btnSetOwner.Click += new System.EventHandler(this.btnSetOwner_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(241, 235);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 21;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // editOwnerSAR
            // 
            this.editOwnerSAR.DataMember = "SAR";
            this.editOwnerSAR.DataSource = this.qryFall;
            this.editOwnerSAR.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editOwnerSAR.Location = new System.Drawing.Point(306, 130);
            this.editOwnerSAR.Name = "editOwnerSAR";
            this.editOwnerSAR.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editOwnerSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editOwnerSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editOwnerSAR.Properties.Appearance.Options.UseBackColor = true;
            this.editOwnerSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.editOwnerSAR.Properties.Appearance.Options.UseFont = true;
            this.editOwnerSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editOwnerSAR.Properties.ReadOnly = true;
            this.editOwnerSAR.Size = new System.Drawing.Size(274, 24);
            this.editOwnerSAR.TabIndex = 25;
            // 
            // lblFB
            // 
            this.lblFB.Location = new System.Drawing.Point(275, 130);
            this.lblFB.Name = "lblFB";
            this.lblFB.Size = new System.Drawing.Size(25, 24);
            this.lblFB.TabIndex = 26;
            this.lblFB.Text = "SAR";
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(241, 205);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // edtPerson
            // 
            this.edtPerson.DataMember = "Person";
            this.edtPerson.DataSource = this.qryFall;
            this.edtPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPerson.Location = new System.Drawing.Point(90, 10);
            this.edtPerson.Name = "edtPerson";
            this.edtPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPerson.Properties.Appearance.Options.UseFont = true;
            this.edtPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPerson.Properties.ReadOnly = true;
            this.edtPerson.Size = new System.Drawing.Size(280, 24);
            this.edtPerson.TabIndex = 28;
            // 
            // lblPerson
            // 
            this.lblPerson.Location = new System.Drawing.Point(5, 10);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(77, 24);
            this.lblPerson.TabIndex = 29;
            this.lblPerson.Text = "Fallträger/-in";
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(5, 70);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(60, 24);
            this.lblDatumVon.TabIndex = 32;
            this.lblDatumVon.Text = "Datum von";
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.Location = new System.Drawing.Point(191, 70);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(25, 24);
            this.lblDatumBis.TabIndex = 33;
            this.lblDatumBis.Text = "bis";
            // 
            // edtModulCode
            // 
            this.edtModulCode.DataMember = "ModulID";
            this.edtModulCode.DataSource = this.qryFall;
            this.edtModulCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtModulCode.Location = new System.Drawing.Point(90, 40);
            this.edtModulCode.LOVName = "Modul";
            this.edtModulCode.Name = "edtModulCode";
            this.edtModulCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtModulCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModulCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtModulCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModulCode.Properties.Appearance.Options.UseFont = true;
            this.edtModulCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtModulCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtModulCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtModulCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtModulCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModulCode.Properties.NullText = "";
            this.edtModulCode.Properties.ReadOnly = true;
            this.edtModulCode.Properties.ShowFooter = false;
            this.edtModulCode.Properties.ShowHeader = false;
            this.edtModulCode.Size = new System.Drawing.Size(280, 24);
            this.edtModulCode.TabIndex = 270;
            // 
            // lblModulCode
            // 
            this.lblModulCode.ForeColor = System.Drawing.Color.Black;
            this.lblModulCode.Location = new System.Drawing.Point(5, 40);
            this.lblModulCode.Name = "lblModulCode";
            this.lblModulCode.Size = new System.Drawing.Size(38, 24);
            this.lblModulCode.TabIndex = 271;
            this.lblModulCode.Text = "Modul";
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryFall;
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(90, 70);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ReadOnly = true;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(91, 24);
            this.edtDatumVon.TabIndex = 272;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryFall;
            this.edtDatumBis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(222, 70);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ReadOnly = true;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(91, 24);
            this.edtDatumBis.TabIndex = 273;
            // 
            // edtArchiviert
            // 
            this.edtArchiviert.DataMember = "Archiviert";
            this.edtArchiviert.DataSource = this.qryFall;
            this.edtArchiviert.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtArchiviert.Location = new System.Drawing.Point(88, 101);
            this.edtArchiviert.Name = "edtArchiviert";
            this.edtArchiviert.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtArchiviert.Properties.Appearance.Options.UseBackColor = true;
            this.edtArchiviert.Properties.Caption = "archiviert";
            this.edtArchiviert.Properties.ReadOnly = true;
            this.edtArchiviert.Size = new System.Drawing.Size(80, 19);
            this.edtArchiviert.TabIndex = 274;
            // 
            // lblFilter
            // 
            this.lblFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFilter.Location = new System.Drawing.Point(7, 349);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(35, 24);
            this.lblFilter.TabIndex = 276;
            this.lblFilter.Text = "Filter";
            this.lblFilter.UseCompatibleTextRendering = true;
            // 
            // edtFilter
            // 
            this.edtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFilter.Location = new System.Drawing.Point(53, 349);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter.Size = new System.Drawing.Size(182, 24);
            this.edtFilter.TabIndex = 275;
            this.edtFilter.EditValueChanged += new System.EventHandler(this.edtFilter_EditValueChanged);
            // 
            // CtlFrmFallZugriff
            // 
            this.ActiveSQLQuery = this.qryFall;
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.edtFilter);
            this.Controls.Add(this.edtArchiviert);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.edtModulCode);
            this.Controls.Add(this.lblModulCode);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.edtPerson);
            this.Controls.Add(this.lblPerson);
            this.Controls.Add(this.editOwnerSAR);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridVerfuegbar);
            this.Controls.Add(this.gridZugeteilt);
            this.Controls.Add(this.btnSetOwner);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblFB);
            this.Name = "CtlFrmFallZugriff";
            this.Size = new System.Drawing.Size(757, 383);
            this.Load += new System.EventHandler(this.CtlFrmFallZugriff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryFall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKandidaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editOwnerSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArchiviert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnSetOwner;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colMutieren;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUser2;
        private KiSS4.Gui.KissTextEdit editOwnerSAR;
        private KiSS4.Gui.KissCheckEdit edtArchiviert;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissTextEdit edtFilter;
        private KiSS4.Gui.KissLookUpEdit edtModulCode;
        private KiSS4.Gui.KissTextEdit edtPerson;
        private KiSS4.Gui.KissGrid gridVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private KiSS4.Gui.KissGrid gridZugeteilt;
        private KiSS4.Gui.KissLabel lblFilter;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblFB;
        private KiSS4.Gui.KissLabel lblModulCode;
        private KiSS4.Gui.KissLabel lblPerson;
        private KiSS4.DB.SqlQuery qryFall;
        private KiSS4.DB.SqlQuery qryKandidaten;
        private KiSS4.DB.SqlQuery qryZugeteilt;


    }
}
