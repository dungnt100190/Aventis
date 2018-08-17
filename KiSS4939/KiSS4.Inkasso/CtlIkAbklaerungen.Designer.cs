using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Inkasso
{
    partial class CtlIkAbklaerungen
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkAbklaerungen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryIkAbklaerung = new KiSS4.DB.SqlQuery(this.components);
            this.grdIkAbklaerung = new KiSS4.Gui.KissGrid();
            this.grvIkAnzeige = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coAbklaerungsDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAabklaerungsart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuswertung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbklaerungDurch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panTitle = new System.Windows.Forms.Panel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtAbklaerungDurch = new KiSS4.Gui.KissButtonEdit();
            this.edtAbklaerungsart = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.edtBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.edtDatumAuswertung = new KiSS4.Gui.KissDateEdit();
            this.lblAbklaerungDurch = new KiSS4.Gui.KissLabel();
            this.edtAuswertung = new KiSS4.Gui.KissLookUpEdit();
            this.lblAuswertung = new KiSS4.Gui.KissLabel();
            this.lbDatum1 = new KiSS4.Gui.KissLabel();
            this.edtDatumAbklaerung = new KiSS4.Gui.KissDateEdit();
            this.lblAbklaerungsart = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkAbklaerung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIkAbklaerung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIkAnzeige)).BeginInit();
            this.panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbklaerungDurch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbklaerungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbklaerungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAuswertung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbklaerungDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswertung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswertung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswertung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbDatum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAbklaerung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbklaerungsart)).BeginInit();
            this.SuspendLayout();
            // 
            // qryIkAbklaerung
            // 
            this.qryIkAbklaerung.CanDelete = true;
            this.qryIkAbklaerung.CanInsert = true;
            this.qryIkAbklaerung.CanUpdate = true;
            this.qryIkAbklaerung.HostControl = this;
            this.qryIkAbklaerung.SelectStatement = resources.GetString("qryIkAbklaerung.SelectStatement");
            this.qryIkAbklaerung.TableName = "IkAbklaerung";
            this.qryIkAbklaerung.AfterInsert += new System.EventHandler(this.qryIkAbklaerung_AfterInsert);
            // 
            // grdIkAbklaerung
            // 
            this.grdIkAbklaerung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdIkAbklaerung.DataSource = this.qryIkAbklaerung;
            // 
            // 
            // 
            this.grdIkAbklaerung.EmbeddedNavigator.Name = "grdIkAnzeige.EmbeddedNavigator";
            this.grdIkAbklaerung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdIkAbklaerung.Location = new System.Drawing.Point(3, 31);
            this.grdIkAbklaerung.MainView = this.grvIkAnzeige;
            this.grdIkAbklaerung.Name = "grdIkAbklaerung";
            this.grdIkAbklaerung.Size = new System.Drawing.Size(708, 260);
            this.grdIkAbklaerung.TabIndex = 1;
            this.grdIkAbklaerung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIkAnzeige});
            // 
            // grvIkAnzeige
            // 
            this.grvIkAnzeige.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvIkAnzeige.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkAnzeige.Appearance.Empty.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.Empty.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkAnzeige.Appearance.EvenRow.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvIkAnzeige.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkAnzeige.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvIkAnzeige.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.FocusedCell.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvIkAnzeige.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvIkAnzeige.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkAnzeige.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvIkAnzeige.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.FocusedRow.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvIkAnzeige.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvIkAnzeige.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvIkAnzeige.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvIkAnzeige.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvIkAnzeige.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.GroupRow.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvIkAnzeige.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvIkAnzeige.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvIkAnzeige.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvIkAnzeige.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvIkAnzeige.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvIkAnzeige.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkAnzeige.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvIkAnzeige.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvIkAnzeige.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvIkAnzeige.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkAnzeige.Appearance.OddRow.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvIkAnzeige.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkAnzeige.Appearance.Row.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.Row.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkAnzeige.Appearance.SelectedRow.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvIkAnzeige.Appearance.VertLine.Options.UseBackColor = true;
            this.grvIkAnzeige.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvIkAnzeige.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coAbklaerungsDatum,
            this.colAabklaerungsart,
            this.colAuswertung,
            this.colAbklaerungDurch});
            this.grvIkAnzeige.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvIkAnzeige.GridControl = this.grdIkAbklaerung;
            this.grvIkAnzeige.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvIkAnzeige.Name = "grvIkAnzeige";
            this.grvIkAnzeige.OptionsBehavior.Editable = false;
            this.grvIkAnzeige.OptionsCustomization.AllowFilter = false;
            this.grvIkAnzeige.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvIkAnzeige.OptionsNavigation.AutoFocusNewRow = true;
            this.grvIkAnzeige.OptionsNavigation.UseTabKey = false;
            this.grvIkAnzeige.OptionsView.ColumnAutoWidth = false;
            this.grvIkAnzeige.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvIkAnzeige.OptionsView.ShowGroupPanel = false;
            this.grvIkAnzeige.OptionsView.ShowIndicator = false;
            // 
            // coAbklaerungsDatum
            // 
            this.coAbklaerungsDatum.Caption = "Abkl. Datum";
            this.coAbklaerungsDatum.Name = "coAbklaerungsDatum";
            this.coAbklaerungsDatum.Visible = true;
            this.coAbklaerungsDatum.VisibleIndex = 0;
            this.coAbklaerungsDatum.Width = 120;
            // 
            // colAabklaerungsart
            // 
            this.colAabklaerungsart.Caption = "Abklärungsart";
            this.colAabklaerungsart.Name = "colAabklaerungsart";
            this.colAabklaerungsart.Visible = true;
            this.colAabklaerungsart.VisibleIndex = 1;
            this.colAabklaerungsart.Width = 179;
            // 
            // colAuswertung
            // 
            this.colAuswertung.Caption = "Auswertung";
            this.colAuswertung.Name = "colAuswertung";
            this.colAuswertung.Visible = true;
            this.colAuswertung.VisibleIndex = 2;
            this.colAuswertung.Width = 283;
            // 
            // colAbklaerungDurch
            // 
            this.colAbklaerungDurch.Caption = "durch";
            this.colAbklaerungDurch.Name = "colAbklaerungDurch";
            this.colAbklaerungDurch.Visible = true;
            this.colAbklaerungDurch.VisibleIndex = 3;
            this.colAbklaerungDurch.Width = 111;
            // 
            // panTitle
            // 
            this.panTitle.Controls.Add(this.picTitle);
            this.panTitle.Controls.Add(this.lblTitel);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(714, 25);
            this.panTitle.TabIndex = 0;
            // 
            // picTitle
            // 
            this.picTitle.Location = new System.Drawing.Point(5, 5);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(16, 16);
            this.picTitle.TabIndex = 1;
            this.picTitle.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(676, 18);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Abklärungen";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung.Location = new System.Drawing.Point(3, 387);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(96, 24);
            this.lblBemerkung.TabIndex = 12;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // edtAbklaerungDurch
            // 
            this.edtAbklaerungDurch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAbklaerungDurch.Location = new System.Drawing.Point(105, 357);
            this.edtAbklaerungDurch.Name = "edtAbklaerungDurch";
            this.edtAbklaerungDurch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbklaerungDurch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbklaerungDurch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbklaerungDurch.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbklaerungDurch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbklaerungDurch.Properties.Appearance.Options.UseFont = true;
            this.edtAbklaerungDurch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtAbklaerungDurch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtAbklaerungDurch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbklaerungDurch.Size = new System.Drawing.Size(388, 24);
            this.edtAbklaerungDurch.TabIndex = 11;
            this.edtAbklaerungDurch.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtAbklaerungDurch_UserModifiedFld);
            // 
            // edtAbklaerungsart
            // 
            this.edtAbklaerungsart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAbklaerungsart.Location = new System.Drawing.Point(105, 297);
            this.edtAbklaerungsart.LOVName = "IkAbklaerungArt";
            this.edtAbklaerungsart.Name = "edtAbklaerungsart";
            this.edtAbklaerungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbklaerungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbklaerungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbklaerungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbklaerungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbklaerungsart.Properties.Appearance.Options.UseFont = true;
            this.edtAbklaerungsart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAbklaerungsart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbklaerungsart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAbklaerungsart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAbklaerungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAbklaerungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAbklaerungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbklaerungsart.Properties.Name = "cboAnzeigeTyp.Properties";
            this.edtAbklaerungsart.Properties.NullText = "";
            this.edtAbklaerungsart.Properties.ShowFooter = false;
            this.edtAbklaerungsart.Properties.ShowHeader = false;
            this.edtAbklaerungsart.Size = new System.Drawing.Size(388, 24);
            this.edtAbklaerungsart.TabIndex = 3;
            this.edtAbklaerungsart.EditValueChanged += new System.EventHandler(this.edtAbklaerungsart_EditValueChanged);
            // 
            // kissLabel1
            // 
            this.kissLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel1.Location = new System.Drawing.Point(519, 327);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(90, 24);
            this.kissLabel1.TabIndex = 8;
            this.kissLabel1.Text = "Datum (Stichtag)";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // edtBemerkungen
            // 
            this.edtBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkungen.Location = new System.Drawing.Point(105, 387);
            this.edtBemerkungen.Name = "edtBemerkungen";
            this.edtBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungen.Properties.Name = "txtBemerkungen.Properties";
            this.edtBemerkungen.Size = new System.Drawing.Size(606, 95);
            this.edtBemerkungen.TabIndex = 13;
            // 
            // edtDatumAuswertung
            // 
            this.edtDatumAuswertung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDatumAuswertung.EditValue = null;
            this.edtDatumAuswertung.Location = new System.Drawing.Point(615, 327);
            this.edtDatumAuswertung.Name = "edtDatumAuswertung";
            this.edtDatumAuswertung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumAuswertung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumAuswertung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumAuswertung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumAuswertung.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumAuswertung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumAuswertung.Properties.Appearance.Options.UseFont = true;
            this.edtDatumAuswertung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumAuswertung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumAuswertung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumAuswertung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumAuswertung.Properties.Name = "dateAbgeschlossen.Properties";
            this.edtDatumAuswertung.Properties.ShowToday = false;
            this.edtDatumAuswertung.Size = new System.Drawing.Size(96, 24);
            this.edtDatumAuswertung.TabIndex = 9;
            // 
            // lblAbklaerungDurch
            // 
            this.lblAbklaerungDurch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAbklaerungDurch.Location = new System.Drawing.Point(3, 357);
            this.lblAbklaerungDurch.Name = "lblAbklaerungDurch";
            this.lblAbklaerungDurch.Size = new System.Drawing.Size(96, 24);
            this.lblAbklaerungDurch.TabIndex = 10;
            this.lblAbklaerungDurch.Text = "Abklärung durch";
            this.lblAbklaerungDurch.UseCompatibleTextRendering = true;
            // 
            // edtAuswertung
            // 
            this.edtAuswertung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAuswertung.Location = new System.Drawing.Point(105, 327);
            this.edtAuswertung.LOVName = "IkAbklaerungAuswertung";
            this.edtAuswertung.Name = "edtAuswertung";
            this.edtAuswertung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuswertung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuswertung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswertung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuswertung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuswertung.Properties.Appearance.Options.UseFont = true;
            this.edtAuswertung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAuswertung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswertung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAuswertung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAuswertung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtAuswertung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtAuswertung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuswertung.Properties.Name = "cboAnzeigeTyp.Properties";
            this.edtAuswertung.Properties.NullText = "";
            this.edtAuswertung.Properties.ShowFooter = false;
            this.edtAuswertung.Properties.ShowHeader = false;
            this.edtAuswertung.Size = new System.Drawing.Size(388, 24);
            this.edtAuswertung.TabIndex = 7;
            // 
            // lblAuswertung
            // 
            this.lblAuswertung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAuswertung.Location = new System.Drawing.Point(3, 327);
            this.lblAuswertung.Name = "lblAuswertung";
            this.lblAuswertung.Size = new System.Drawing.Size(96, 24);
            this.lblAuswertung.TabIndex = 6;
            this.lblAuswertung.Text = "Auswertung";
            this.lblAuswertung.UseCompatibleTextRendering = true;
            // 
            // lbDatum1
            // 
            this.lbDatum1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDatum1.Location = new System.Drawing.Point(519, 297);
            this.lbDatum1.Name = "lbDatum1";
            this.lbDatum1.Size = new System.Drawing.Size(90, 24);
            this.lbDatum1.TabIndex = 4;
            this.lbDatum1.Text = "Datum (Stichtag)";
            this.lbDatum1.UseCompatibleTextRendering = true;
            // 
            // edtDatumAbklaerung
            // 
            this.edtDatumAbklaerung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDatumAbklaerung.EditValue = null;
            this.edtDatumAbklaerung.Location = new System.Drawing.Point(615, 297);
            this.edtDatumAbklaerung.Name = "edtDatumAbklaerung";
            this.edtDatumAbklaerung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumAbklaerung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumAbklaerung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumAbklaerung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumAbklaerung.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumAbklaerung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumAbklaerung.Properties.Appearance.Options.UseFont = true;
            this.edtDatumAbklaerung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDatumAbklaerung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumAbklaerung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtDatumAbklaerung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumAbklaerung.Properties.Name = "dateEroeffnet.Properties";
            this.edtDatumAbklaerung.Properties.ShowToday = false;
            this.edtDatumAbklaerung.Size = new System.Drawing.Size(96, 24);
            this.edtDatumAbklaerung.TabIndex = 5;
            // 
            // lblAbklaerungsart
            // 
            this.lblAbklaerungsart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAbklaerungsart.Location = new System.Drawing.Point(3, 297);
            this.lblAbklaerungsart.Name = "lblAbklaerungsart";
            this.lblAbklaerungsart.Size = new System.Drawing.Size(96, 24);
            this.lblAbklaerungsart.TabIndex = 2;
            this.lblAbklaerungsart.Text = "Abklärungsart";
            this.lblAbklaerungsart.UseCompatibleTextRendering = true;
            // 
            // CtlIkAbklaerungen
            // 
            this.ActiveSQLQuery = this.qryIkAbklaerung;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(536, 310);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.edtAbklaerungDurch);
            this.Controls.Add(this.edtAbklaerungsart);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.edtBemerkungen);
            this.Controls.Add(this.edtDatumAuswertung);
            this.Controls.Add(this.lblAbklaerungDurch);
            this.Controls.Add(this.edtAuswertung);
            this.Controls.Add(this.lblAuswertung);
            this.Controls.Add(this.lbDatum1);
            this.Controls.Add(this.edtDatumAbklaerung);
            this.Controls.Add(this.lblAbklaerungsart);
            this.Controls.Add(this.panTitle);
            this.Controls.Add(this.grdIkAbklaerung);
            this.Name = "CtlIkAbklaerungen";
            this.Size = new System.Drawing.Size(714, 485);
            this.Load += new System.EventHandler(this.CtlIkAbklaerungen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryIkAbklaerung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIkAbklaerung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIkAnzeige)).EndInit();
            this.panTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbklaerungDurch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbklaerungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbklaerungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAuswertung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbklaerungDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswertung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswertung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswertung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbDatum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAbklaerung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbklaerungsart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn coAbklaerungsDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colAabklaerungsart;
        private DevExpress.XtraGrid.Columns.GridColumn colAbklaerungDurch;
        private DevExpress.XtraGrid.Columns.GridColumn colAuswertung;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissGrid grdIkAbklaerung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIkAnzeige;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.PictureBox picTitle;
        private System.Windows.Forms.Panel panTitle;
        private KiSS4.DB.SqlQuery qryIkAbklaerung;
        private Gui.KissLabel lblBemerkung;
        private Gui.KissButtonEdit edtAbklaerungDurch;
        private Gui.KissLookUpEdit edtAbklaerungsart;
        private Gui.KissLabel kissLabel1;
        private Gui.KissMemoEdit edtBemerkungen;
        private Gui.KissDateEdit edtDatumAuswertung;
        private Gui.KissLabel lblAbklaerungDurch;
        private Gui.KissLookUpEdit edtAuswertung;
        private Gui.KissLabel lblAuswertung;
        private Gui.KissLabel lbDatum1;
        private Gui.KissDateEdit edtDatumAbklaerung;
        private Gui.KissLabel lblAbklaerungsart;
    }
}
