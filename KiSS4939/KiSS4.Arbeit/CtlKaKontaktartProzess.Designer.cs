namespace KiSS4.Arbeit
{
    partial class CtlKaKontaktartProzess
    {
        private System.ComponentModel.IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaKontaktartProzess));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.imageTitle = new System.Windows.Forms.PictureBox();
            this.qryKaKontaktartProzess = new KiSS4.DB.SqlQuery(this.components);
            this.grdProzess = new KiSS4.Gui.KissGrid();
            this.grvProzess = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontaktart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.edtDatum = new KiSS4.Gui.KissDateEdit();
            this.lblKontaktart = new KiSS4.Gui.KissLabel();
            this.edtKontaktart = new KiSS4.Gui.KissLookUpEdit();
            this.btnVerlaufseintragErfassen = new KiSS4.Gui.KissButton();
            this.edtKaKontaktartStatus = new KiSS4.Gui.KissRadioGroup(this.components);
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaKontaktartProzess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProzess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProzess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaKontaktartStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaKontaktartStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Controls.Add(this.imageTitle);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(600, 40);
            this.pnTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(35, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ka_Kontaktart_Prozess";
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // imageTitle
            // 
            this.imageTitle.Location = new System.Drawing.Point(10, 9);
            this.imageTitle.Name = "imageTitle";
            this.imageTitle.Size = new System.Drawing.Size(25, 20);
            this.imageTitle.TabIndex = 1;
            this.imageTitle.TabStop = false;
            // 
            // qryKaKontaktartProzess
            // 
            this.qryKaKontaktartProzess.CanDelete = true;
            this.qryKaKontaktartProzess.CanInsert = true;
            this.qryKaKontaktartProzess.CanUpdate = true;
            this.qryKaKontaktartProzess.HostControl = this;
            this.qryKaKontaktartProzess.IsIdentityInsert = false;
            this.qryKaKontaktartProzess.SelectStatement = resources.GetString("qryKaKontaktartProzess.SelectStatement");
            this.qryKaKontaktartProzess.TableName = "KaKontaktartProzess";
            this.qryKaKontaktartProzess.AfterDelete += new System.EventHandler(this.qryKaKontaktartProzess_AfterDelete);
            this.qryKaKontaktartProzess.AfterInsert += new System.EventHandler(this.qryKaKontaktartProzess_AfterInsert);
            this.qryKaKontaktartProzess.BeforePost += new System.EventHandler(this.qryKaKontaktartProzess_BeforePost);
            // 
            // grdProzess
            // 
            this.grdProzess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdProzess.DataSource = this.qryKaKontaktartProzess;
            // 
            // 
            // 
            this.grdProzess.EmbeddedNavigator.Name = "";
            this.grdProzess.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdProzess.Location = new System.Drawing.Point(3, 46);
            this.grdProzess.MainView = this.grvProzess;
            this.grdProzess.Name = "grdProzess";
            this.grdProzess.SelectLastPosition = true;
            this.grdProzess.Size = new System.Drawing.Size(594, 220);
            this.grdProzess.TabIndex = 1;
            this.grdProzess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProzess});
            // 
            // grvProzess
            // 
            this.grvProzess.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvProzess.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProzess.Appearance.Empty.Options.UseBackColor = true;
            this.grvProzess.Appearance.Empty.Options.UseFont = true;
            this.grvProzess.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProzess.Appearance.EvenRow.Options.UseFont = true;
            this.grvProzess.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvProzess.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProzess.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvProzess.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvProzess.Appearance.FocusedCell.Options.UseFont = true;
            this.grvProzess.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvProzess.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvProzess.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProzess.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvProzess.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvProzess.Appearance.FocusedRow.Options.UseFont = true;
            this.grvProzess.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvProzess.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProzess.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvProzess.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvProzess.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvProzess.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProzess.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvProzess.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProzess.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvProzess.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvProzess.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvProzess.Appearance.GroupRow.Options.UseFont = true;
            this.grvProzess.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvProzess.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvProzess.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvProzess.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvProzess.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvProzess.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvProzess.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvProzess.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvProzess.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProzess.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvProzess.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvProzess.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvProzess.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvProzess.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvProzess.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvProzess.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProzess.Appearance.OddRow.Options.UseFont = true;
            this.grvProzess.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvProzess.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProzess.Appearance.Row.Options.UseBackColor = true;
            this.grvProzess.Appearance.Row.Options.UseFont = true;
            this.grvProzess.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProzess.Appearance.SelectedRow.Options.UseFont = true;
            this.grvProzess.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvProzess.Appearance.VertLine.Options.UseBackColor = true;
            this.grvProzess.BestFitMaxRowCount = 1000;
            this.grvProzess.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvProzess.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colKontaktart});
            this.grvProzess.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvProzess.GridControl = this.grdProzess;
            this.grvProzess.Name = "grvProzess";
            this.grvProzess.OptionsBehavior.Editable = false;
            this.grvProzess.OptionsCustomization.AllowFilter = false;
            this.grvProzess.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvProzess.OptionsNavigation.AutoFocusNewRow = true;
            this.grvProzess.OptionsNavigation.UseTabKey = false;
            this.grvProzess.OptionsView.ColumnAutoWidth = false;
            this.grvProzess.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvProzess.OptionsView.ShowGroupPanel = false;
            this.grvProzess.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            // 
            // colKontaktart
            // 
            this.colKontaktart.Caption = "Kontaktart";
            this.colKontaktart.Name = "colKontaktart";
            this.colKontaktart.Visible = true;
            this.colKontaktart.VisibleIndex = 1;
            this.colKontaktart.Width = 200;
            // 
            // lblDatum
            // 
            this.lblDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatum.Location = new System.Drawing.Point(5, 292);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(100, 24);
            this.lblDatum.TabIndex = 2;
            this.lblDatum.Text = "Datum";
            // 
            // edtDatum
            // 
            this.edtDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatum.DataSource = this.qryKaKontaktartProzess;
            this.edtDatum.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatum.EditValue = null;
            this.edtDatum.Location = new System.Drawing.Point(111, 292);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatum.Properties.ShowToday = false;
            this.edtDatum.Size = new System.Drawing.Size(100, 24);
            this.edtDatum.TabIndex = 3;
            // 
            // lblKontaktart
            // 
            this.lblKontaktart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKontaktart.Location = new System.Drawing.Point(5, 322);
            this.lblKontaktart.Name = "lblKontaktart";
            this.lblKontaktart.Size = new System.Drawing.Size(100, 24);
            this.lblKontaktart.TabIndex = 4;
            this.lblKontaktart.Text = "Kontaktart";
            // 
            // edtKontaktart
            // 
            this.edtKontaktart.AllowNull = false;
            this.edtKontaktart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKontaktart.DataSource = this.qryKaKontaktartProzess;
            this.edtKontaktart.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtKontaktart.Location = new System.Drawing.Point(111, 322);
            this.edtKontaktart.LOVName = "KaKontaktartProzess";
            this.edtKontaktart.Name = "edtKontaktart";
            this.edtKontaktart.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtKontaktart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktart.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktart.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKontaktart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKontaktart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKontaktart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtKontaktart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtKontaktart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontaktart.Properties.NullText = "";
            this.edtKontaktart.Properties.ShowFooter = false;
            this.edtKontaktart.Properties.ShowHeader = false;
            this.edtKontaktart.Size = new System.Drawing.Size(200, 24);
            this.edtKontaktart.TabIndex = 5;
            // 
            // btnVerlaufseintragErfassen
            // 
            this.btnVerlaufseintragErfassen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVerlaufseintragErfassen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerlaufseintragErfassen.Location = new System.Drawing.Point(111, 352);
            this.btnVerlaufseintragErfassen.Name = "btnVerlaufseintragErfassen";
            this.btnVerlaufseintragErfassen.Size = new System.Drawing.Size(200, 24);
            this.btnVerlaufseintragErfassen.TabIndex = 6;
            this.btnVerlaufseintragErfassen.Text = "Verlaufseintrag erfassen";
            this.btnVerlaufseintragErfassen.UseVisualStyleBackColor = false;
            this.btnVerlaufseintragErfassen.Click += new System.EventHandler(this.btnVerlaufseintragErfassen_Click);
            // 
            // edtKaKontaktartStatus
            // 
            this.edtKaKontaktartStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKaKontaktartStatus.DataSource = this.qryKaKontaktartProzess;
            this.edtKaKontaktartStatus.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtKaKontaktartStatus.EditValue = null;
            this.edtKaKontaktartStatus.Location = new System.Drawing.Point(333, 292);
            this.edtKaKontaktartStatus.LookupSQL = null;
            this.edtKaKontaktartStatus.LOVFilter = null;
            this.edtKaKontaktartStatus.LOVName = "KaKontaktartProzessStatus";
            this.edtKaKontaktartStatus.Name = "edtKaKontaktartStatus";
            this.edtKaKontaktartStatus.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtKaKontaktartStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtKaKontaktartStatus.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.edtKaKontaktartStatus.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtKaKontaktartStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtKaKontaktartStatus.Size = new System.Drawing.Size(157, 54);
            this.edtKaKontaktartStatus.TabIndex = 7;
            // 
            // CtlKaKontaktartProzess
            // 
            this.ActiveSQLQuery = this.qryKaKontaktartProzess;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(315, 292);
            this.Controls.Add(this.edtKaKontaktartStatus);
            this.Controls.Add(this.btnVerlaufseintragErfassen);
            this.Controls.Add(this.edtKontaktart);
            this.Controls.Add(this.lblKontaktart);
            this.Controls.Add(this.edtDatum);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.grdProzess);
            this.Controls.Add(this.pnTitle);
            this.Name = "CtlKaKontaktartProzess";
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.CtlKaKontaktartProzess_Load);
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaKontaktartProzess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProzess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProzess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaKontaktartStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKaKontaktartStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imageTitle;
        private KiSS4.Gui.KissLabel lblTitle;
        private System.Windows.Forms.Panel pnTitle;
        private KiSS4.DB.SqlQuery qryKaKontaktartProzess;
        private Gui.KissGrid grdProzess;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProzess;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colKontaktart;
        private Gui.KissButton btnVerlaufseintragErfassen;
        private Gui.KissLookUpEdit edtKontaktart;
        private Gui.KissLabel lblKontaktart;
        private Gui.KissDateEdit edtDatum;
        private Gui.KissLabel lblDatum;
        private Gui.KissRadioGroup edtKaKontaktartStatus;
    }
}
