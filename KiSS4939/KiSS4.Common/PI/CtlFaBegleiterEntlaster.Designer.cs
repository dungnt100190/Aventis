namespace KiSS4.Common.PI
{
    partial class CtlFaBegleiterEntlaster
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
            this.grdXUser_Einsatzvereinbarung = new KiSS4.Gui.KissGrid();
            this.qryMitarbeiter = new KiSS4.DB.SqlQuery(this.components);
            this.grvXUser_Einsatzvereinbarung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSortKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMitarbeiter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontakt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panUpDown = new System.Windows.Forms.Panel();
            this.btnDown = new KiSS4.Gui.KissButton();
            this.btnUp = new KiSS4.Gui.KissButton();
            this.panDetails = new System.Windows.Forms.Panel();
            this.edtBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtKontakt = new KiSS4.Gui.KissTextEdit();
            this.lblKontakt = new KiSS4.Gui.KissLabel();
            this.btnInfoMitarbeiter = new KiSS4.Gui.KissButton();
            this.edtMitarbeiter = new KiSS4.Gui.KissButtonEdit();
            this.lblMitarbeiter = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdXUser_Einsatzvereinbarung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXUser_Einsatzvereinbarung)).BeginInit();
            this.panUpDown.SuspendLayout();
            this.panDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontakt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontakt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitarbeiter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiter)).BeginInit();
            this.SuspendLayout();
            // 
            // grdXUser_Einsatzvereinbarung
            // 
            this.grdXUser_Einsatzvereinbarung.DataSource = this.qryMitarbeiter;
            this.grdXUser_Einsatzvereinbarung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdXUser_Einsatzvereinbarung.EmbeddedNavigator.Name = "";
            this.grdXUser_Einsatzvereinbarung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdXUser_Einsatzvereinbarung.Location = new System.Drawing.Point(0, 0);
            this.grdXUser_Einsatzvereinbarung.MainView = this.grvXUser_Einsatzvereinbarung;
            this.grdXUser_Einsatzvereinbarung.Name = "grdXUser_Einsatzvereinbarung";
            this.grdXUser_Einsatzvereinbarung.Size = new System.Drawing.Size(641, 272);
            this.grdXUser_Einsatzvereinbarung.TabIndex = 0;
            this.grdXUser_Einsatzvereinbarung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvXUser_Einsatzvereinbarung});
            // 
            // qryMitarbeiter
            // 
            this.qryMitarbeiter.HostControl = this;
            this.qryMitarbeiter.BeforeDelete += new System.EventHandler(this.qryMitarbeiter_BeforeDelete);
            this.qryMitarbeiter.BeforePost += new System.EventHandler(this.qryMitarbeiter_BeforePost);
            this.qryMitarbeiter.PositionChanged += new System.EventHandler(this.qryMitarbeiter_PositionChanged);
            this.qryMitarbeiter.AfterInsert += new System.EventHandler(this.qryMitarbeiter_AfterInsert);
            this.qryMitarbeiter.AfterDelete += new System.EventHandler(this.qryMitarbeiter_AfterDelete);
            // 
            // grvXUser_Einsatzvereinbarung
            // 
            this.grvXUser_Einsatzvereinbarung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvXUser_Einsatzvereinbarung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUser_Einsatzvereinbarung.Appearance.Empty.Options.UseBackColor = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.Empty.Options.UseFont = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUser_Einsatzvereinbarung.Appearance.EvenRow.Options.UseFont = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXUser_Einsatzvereinbarung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUser_Einsatzvereinbarung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvXUser_Einsatzvereinbarung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXUser_Einsatzvereinbarung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUser_Einsatzvereinbarung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvXUser_Einsatzvereinbarung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXUser_Einsatzvereinbarung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXUser_Einsatzvereinbarung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXUser_Einsatzvereinbarung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXUser_Einsatzvereinbarung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.GroupRow.Options.UseFont = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvXUser_Einsatzvereinbarung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvXUser_Einsatzvereinbarung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXUser_Einsatzvereinbarung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvXUser_Einsatzvereinbarung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUser_Einsatzvereinbarung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXUser_Einsatzvereinbarung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvXUser_Einsatzvereinbarung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUser_Einsatzvereinbarung.Appearance.OddRow.Options.UseFont = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvXUser_Einsatzvereinbarung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUser_Einsatzvereinbarung.Appearance.Row.Options.UseBackColor = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.Row.Options.UseFont = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXUser_Einsatzvereinbarung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvXUser_Einsatzvereinbarung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvXUser_Einsatzvereinbarung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvXUser_Einsatzvereinbarung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvXUser_Einsatzvereinbarung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSortKey,
            this.colMitarbeiter,
            this.colKontakt,
            this.colBemerkungen});
            this.grvXUser_Einsatzvereinbarung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvXUser_Einsatzvereinbarung.GridControl = this.grdXUser_Einsatzvereinbarung;
            this.grvXUser_Einsatzvereinbarung.Name = "grvXUser_Einsatzvereinbarung";
            this.grvXUser_Einsatzvereinbarung.OptionsBehavior.Editable = false;
            this.grvXUser_Einsatzvereinbarung.OptionsCustomization.AllowFilter = false;
            this.grvXUser_Einsatzvereinbarung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvXUser_Einsatzvereinbarung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvXUser_Einsatzvereinbarung.OptionsNavigation.UseTabKey = false;
            this.grvXUser_Einsatzvereinbarung.OptionsView.ColumnAutoWidth = false;
            this.grvXUser_Einsatzvereinbarung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvXUser_Einsatzvereinbarung.OptionsView.ShowGroupPanel = false;
            this.grvXUser_Einsatzvereinbarung.OptionsView.ShowIndicator = false;
            this.grvXUser_Einsatzvereinbarung.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvXUserEdEinsatzvereinbarung_CustomDrawCell);
            // 
            // colSortKey
            // 
            this.colSortKey.Caption = "Reihenf.";
            this.colSortKey.FieldName = "ShowingSortKey";
            this.colSortKey.Name = "colSortKey";
            this.colSortKey.Visible = true;
            this.colSortKey.VisibleIndex = 0;
            this.colSortKey.Width = 70;
            // 
            // colMitarbeiter
            // 
            this.colMitarbeiter.Caption = "Mitarbeiter/in";
            this.colMitarbeiter.FieldName = "Mitarbeiter";
            this.colMitarbeiter.Name = "colMitarbeiter";
            this.colMitarbeiter.Visible = true;
            this.colMitarbeiter.VisibleIndex = 1;
            this.colMitarbeiter.Width = 220;
            // 
            // colKontakt
            // 
            this.colKontakt.Caption = "Kontakt";
            this.colKontakt.FieldName = "MitarbeiterKontakt";
            this.colKontakt.Name = "colKontakt";
            this.colKontakt.Visible = true;
            this.colKontakt.VisibleIndex = 2;
            this.colKontakt.Width = 240;
            // 
            // colBemerkungen
            // 
            this.colBemerkungen.Caption = "Bemerkungen";
            this.colBemerkungen.FieldName = "Bemerkungen";
            this.colBemerkungen.Name = "colBemerkungen";
            this.colBemerkungen.Visible = true;
            this.colBemerkungen.VisibleIndex = 3;
            this.colBemerkungen.Width = 105;
            // 
            // panUpDown
            // 
            this.panUpDown.Controls.Add(this.btnDown);
            this.panUpDown.Controls.Add(this.btnUp);
            this.panUpDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.panUpDown.Location = new System.Drawing.Point(641, 0);
            this.panUpDown.Name = "panUpDown";
            this.panUpDown.Size = new System.Drawing.Size(36, 272);
            this.panUpDown.TabIndex = 2;
            // 
            // btnDown
            // 
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.IconID = 17;
            this.btnDown.Location = new System.Drawing.Point(6, 30);
            this.btnDown.Name = "btnDown";
            this.btnDown.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.btnDown.Size = new System.Drawing.Size(24, 24);
            this.btnDown.TabIndex = 1;
            this.btnDown.UseCompatibleTextRendering = true;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.IconID = 16;
            this.btnUp.Location = new System.Drawing.Point(6, 0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btnUp.Size = new System.Drawing.Size(24, 24);
            this.btnUp.TabIndex = 0;
            this.btnUp.UseCompatibleTextRendering = true;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // panDetails
            // 
            this.panDetails.Controls.Add(this.edtBemerkungen);
            this.panDetails.Controls.Add(this.lblBemerkungen);
            this.panDetails.Controls.Add(this.edtKontakt);
            this.panDetails.Controls.Add(this.lblKontakt);
            this.panDetails.Controls.Add(this.btnInfoMitarbeiter);
            this.panDetails.Controls.Add(this.edtMitarbeiter);
            this.panDetails.Controls.Add(this.lblMitarbeiter);
            this.panDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetails.Location = new System.Drawing.Point(0, 272);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(677, 130);
            this.panDetails.TabIndex = 1;
            // 
            // edtBemerkungen
            // 
            this.edtBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkungen.DataMember = "Bemerkungen";
            this.edtBemerkungen.DataSource = this.qryMitarbeiter;
            this.edtBemerkungen.Location = new System.Drawing.Point(110, 69);
            this.edtBemerkungen.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtBemerkungen.Name = "edtBemerkungen";
            this.edtBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungen.Properties.MaxLength = 2000;
            this.edtBemerkungen.Size = new System.Drawing.Size(558, 52);
            this.edtBemerkungen.TabIndex = 6;
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Location = new System.Drawing.Point(9, 69);
            this.lblBemerkungen.Margin = new System.Windows.Forms.Padding(3, 6, 3, 9);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(95, 24);
            this.lblBemerkungen.TabIndex = 5;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            // 
            // edtKontakt
            // 
            this.edtKontakt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKontakt.DataMember = "MitarbeiterKontakt";
            this.edtKontakt.DataSource = this.qryMitarbeiter;
            this.edtKontakt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKontakt.Location = new System.Drawing.Point(110, 39);
            this.edtKontakt.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtKontakt.Name = "edtKontakt";
            this.edtKontakt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKontakt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontakt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontakt.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontakt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontakt.Properties.Appearance.Options.UseFont = true;
            this.edtKontakt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontakt.Properties.ReadOnly = true;
            this.edtKontakt.Size = new System.Drawing.Size(558, 24);
            this.edtKontakt.TabIndex = 4;
            this.edtKontakt.TabStop = false;
            // 
            // lblKontakt
            // 
            this.lblKontakt.Location = new System.Drawing.Point(9, 39);
            this.lblKontakt.Margin = new System.Windows.Forms.Padding(3, 6, 3, 9);
            this.lblKontakt.Name = "lblKontakt";
            this.lblKontakt.Size = new System.Drawing.Size(95, 24);
            this.lblKontakt.TabIndex = 3;
            this.lblKontakt.Text = "Kontakt";
            this.lblKontakt.UseCompatibleTextRendering = true;
            // 
            // btnInfoMitarbeiter
            // 
            this.btnInfoMitarbeiter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoMitarbeiter.IconID = 5004;
            this.btnInfoMitarbeiter.Location = new System.Drawing.Point(375, 9);
            this.btnInfoMitarbeiter.Name = "btnInfoMitarbeiter";
            this.btnInfoMitarbeiter.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btnInfoMitarbeiter.Size = new System.Drawing.Size(24, 24);
            this.btnInfoMitarbeiter.TabIndex = 2;
            this.btnInfoMitarbeiter.UseCompatibleTextRendering = true;
            this.btnInfoMitarbeiter.UseVisualStyleBackColor = false;
            this.btnInfoMitarbeiter.Click += new System.EventHandler(this.btnInfoMitarbeiter_Click);
            // 
            // edtMitarbeiter
            // 
            this.edtMitarbeiter.DataMember = "Mitarbeiter";
            this.edtMitarbeiter.DataSource = this.qryMitarbeiter;
            this.edtMitarbeiter.Location = new System.Drawing.Point(110, 9);
            this.edtMitarbeiter.Name = "edtMitarbeiter";
            this.edtMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.edtMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMitarbeiter.Size = new System.Drawing.Size(259, 24);
            this.edtMitarbeiter.TabIndex = 1;
            this.edtMitarbeiter.EditValueChanged += new System.EventHandler(this.edtMitarbeiter_EditValueChanged);
            this.edtMitarbeiter.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtMitarbeiter_UserModifiedFld);
            // 
            // lblMitarbeiter
            // 
            this.lblMitarbeiter.Location = new System.Drawing.Point(9, 9);
            this.lblMitarbeiter.Margin = new System.Windows.Forms.Padding(3, 6, 3, 9);
            this.lblMitarbeiter.Name = "lblMitarbeiter";
            this.lblMitarbeiter.Size = new System.Drawing.Size(95, 24);
            this.lblMitarbeiter.TabIndex = 0;
            this.lblMitarbeiter.Text = "Mitarbeiter/in";
            this.lblMitarbeiter.UseCompatibleTextRendering = true;
            // 
            // CtlFaBegleiterEntlaster
            // 
            this.ActiveSQLQuery = this.qryMitarbeiter;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.grdXUser_Einsatzvereinbarung);
            this.Controls.Add(this.panUpDown);
            this.Controls.Add(this.panDetails);
            this.Name = "CtlFaBegleiterEntlaster";
            this.Size = new System.Drawing.Size(677, 402);
            ((System.ComponentModel.ISupportInitialize)(this.grdXUser_Einsatzvereinbarung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXUser_Einsatzvereinbarung)).EndInit();
            this.panUpDown.ResumeLayout(false);
            this.panDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontakt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontakt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiter)).EndInit();
            this.ResumeLayout(false);

        }

        

        

        

        #endregion

        private KiSS4.Gui.KissGrid grdXUser_Einsatzvereinbarung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvXUser_Einsatzvereinbarung;
        private DevExpress.XtraGrid.Columns.GridColumn colSortKey;
        private DevExpress.XtraGrid.Columns.GridColumn colMitarbeiter;
        private DevExpress.XtraGrid.Columns.GridColumn colKontakt;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungen;
        private System.Windows.Forms.Panel panUpDown;
        private KiSS4.Gui.KissButton btnDown;
        private KiSS4.Gui.KissButton btnUp;
        private System.Windows.Forms.Panel panDetails;
        private KiSS4.Gui.KissMemoEdit edtBemerkungen;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissTextEdit edtKontakt;
        private KiSS4.Gui.KissLabel lblKontakt;
        private KiSS4.Gui.KissButton btnInfoMitarbeiter;
        private KiSS4.Gui.KissButtonEdit edtMitarbeiter;
        private KiSS4.Gui.KissLabel lblMitarbeiter;
        private KiSS4.DB.SqlQuery qryMitarbeiter;
    }
}
