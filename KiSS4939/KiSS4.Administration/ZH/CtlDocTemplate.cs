using System;
using System.ComponentModel;
using System.Data;

using Kiss.Interfaces.DocumentHandling;

using KiSS4.DB;
using KiSS4.Dokument;

namespace KiSS4.Administration.ZH
{
    public class CtlDocTemplate : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Static Fields

        private static string XDocTemplateNonBlobFieldList = XDocFileHandler.GetXDocumentNonBlobFieldList("XDocTemplate");

        #endregion

        #region Private Fields

        private DevExpress.XtraGrid.Columns.GridColumn colDateCreation;
        private DevExpress.XtraGrid.Columns.GridColumn colDateLastSave;
        private DevExpress.XtraGrid.Columns.GridColumn colDocFormatCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDocTemplateName;
        private System.ComponentModel.IContainer components;
        int defaultDokKatalogID = 0;
        private KiSS4.Dokument.XDokument edtDocTemplate;
        private KiSS4.Gui.KissTextEdit edtDocTemplateName;
        private KiSS4.Gui.KissLookUpEdit edtFaDokKatalogID;
        private KiSS4.Gui.KissGrid grdDocTemplate;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDocTemplate;
        private KiSS4.Gui.KissLabel lblDocTemplate;
        private KiSS4.Gui.KissLabel lblDocTemplateName;
        private KiSS4.Gui.KissLabel lblFaDokKatalogID;
        private KiSS4.DB.SqlQuery qryDocTemplate;

        #endregion

        #endregion

        #region Constructors

        public CtlDocTemplate()
        {
            this.InitializeComponent();

            edtDocTemplate.DataMember = "";
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlDocTemplate));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdDocTemplate = new KiSS4.Gui.KissGrid();
            this.qryDocTemplate = new KiSS4.DB.SqlQuery(this.components);
            this.grvDocTemplate = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocFormatCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocTemplateName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateLastSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtDocTemplateName = new KiSS4.Gui.KissTextEdit();
            this.lblDocTemplateName = new KiSS4.Gui.KissLabel();
            this.edtDocTemplate = new KiSS4.Dokument.XDokument();
            this.lblDocTemplate = new KiSS4.Gui.KissLabel();
            this.lblFaDokKatalogID = new KiSS4.Gui.KissLabel();
            this.edtFaDokKatalogID = new KiSS4.Gui.KissLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDocTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDocTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocTemplateName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocTemplateName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocTemplate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKatalogID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKatalogID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKatalogID.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // grdDocTemplate
            //
            this.grdDocTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDocTemplate.DataSource = this.qryDocTemplate;
            this.grdDocTemplate.EmbeddedNavigator.Name = "";
            this.grdDocTemplate.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdDocTemplate.Location = new System.Drawing.Point(5, 10);
            this.grdDocTemplate.MainView = this.grvDocTemplate;
            this.grdDocTemplate.Name = "grdDocTemplate";
            this.grdDocTemplate.Size = new System.Drawing.Size(805, 285);
            this.grdDocTemplate.TabIndex = 0;
            this.grdDocTemplate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDocTemplate});
            this.grdDocTemplate.DoubleClick += new System.EventHandler(this.grdDocTemplate_DoubleClick);
            //
            // qryDocTemplate
            //
            this.qryDocTemplate.CanDelete = true;
            this.qryDocTemplate.CanInsert = true;
            this.qryDocTemplate.CanUpdate = true;
            this.qryDocTemplate.HostControl = this;
            this.qryDocTemplate.TableName = "XDocTemplate";
            this.qryDocTemplate.BeforeDelete += new System.EventHandler(this.qryDocTemplate_BeforeDelete);
            this.qryDocTemplate.BeforePost += new System.EventHandler(this.qryDocTemplate_BeforePost);
            this.qryDocTemplate.PositionChanged += new System.EventHandler(this.qryDocTemplate_PositionChanged);
            this.qryDocTemplate.AfterFill += new System.EventHandler(this.qryDocTemplate_AfterFill);
            this.qryDocTemplate.AfterInsert += new System.EventHandler(this.qryDocTemplate_AfterInsert);
            this.qryDocTemplate.BeforeDeleteQuestion += new System.EventHandler(this.qryDocTemplate_BeforeDeleteQuestion);
            this.qryDocTemplate.AfterPost += new System.EventHandler(this.qryDocTemplate_AfterPost);
            //
            // grvDocTemplate
            //
            this.grvDocTemplate.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDocTemplate.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocTemplate.Appearance.Empty.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.Empty.Options.UseFont = true;
            this.grvDocTemplate.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocTemplate.Appearance.EvenRow.Options.UseFont = true;
            this.grvDocTemplate.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDocTemplate.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocTemplate.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvDocTemplate.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDocTemplate.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDocTemplate.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDocTemplate.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocTemplate.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDocTemplate.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDocTemplate.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDocTemplate.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDocTemplate.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDocTemplate.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDocTemplate.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDocTemplate.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.GroupRow.Options.UseFont = true;
            this.grvDocTemplate.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDocTemplate.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvDocTemplate.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvDocTemplate.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDocTemplate.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDocTemplate.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDocTemplate.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvDocTemplate.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocTemplate.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDocTemplate.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDocTemplate.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDocTemplate.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvDocTemplate.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocTemplate.Appearance.OddRow.Options.UseFont = true;
            this.grvDocTemplate.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDocTemplate.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocTemplate.Appearance.Row.Options.UseBackColor = true;
            this.grvDocTemplate.Appearance.Row.Options.UseFont = true;
            this.grvDocTemplate.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDocTemplate.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDocTemplate.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvDocTemplate.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDocTemplate.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvDocTemplate.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocFormatCode,
            this.colDocTemplateName,
            this.colDateCreation,
            this.colDateLastSave});
            this.grvDocTemplate.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvDocTemplate.GridControl = this.grdDocTemplate;
            this.grvDocTemplate.Name = "grvDocTemplate";
            this.grvDocTemplate.OptionsBehavior.Editable = false;
            this.grvDocTemplate.OptionsCustomization.AllowFilter = false;
            this.grvDocTemplate.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvDocTemplate.OptionsNavigation.AutoFocusNewRow = true;
            this.grvDocTemplate.OptionsNavigation.UseTabKey = false;
            this.grvDocTemplate.OptionsView.ColumnAutoWidth = false;
            this.grvDocTemplate.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDocTemplate.OptionsView.ShowGroupPanel = false;
            this.grvDocTemplate.OptionsView.ShowIndicator = false;
            //
            // colDocFormatCode
            //
            this.colDocFormatCode.Caption = "Format";
            this.colDocFormatCode.FieldName = "DocFormatCode";
            this.colDocFormatCode.Name = "colDocFormatCode";
            this.colDocFormatCode.Visible = true;
            this.colDocFormatCode.VisibleIndex = 0;
            this.colDocFormatCode.Width = 70;
            //
            // colDocTemplateName
            //
            this.colDocTemplateName.Caption = "Name der Vorlage";
            this.colDocTemplateName.FieldName = "DocTemplateName";
            this.colDocTemplateName.Name = "colDocTemplateName";
            this.colDocTemplateName.Visible = true;
            this.colDocTemplateName.VisibleIndex = 1;
            this.colDocTemplateName.Width = 427;
            //
            // colDateCreation
            //
            this.colDateCreation.Caption = "erzeugt";
            this.colDateCreation.FieldName = "DateCreation";
            this.colDateCreation.Name = "colDateCreation";
            this.colDateCreation.Visible = true;
            this.colDateCreation.VisibleIndex = 2;
            this.colDateCreation.Width = 78;
            //
            // colDateLastSave
            //
            this.colDateLastSave.Caption = "verändert";
            this.colDateLastSave.FieldName = "DateLastSave";
            this.colDateLastSave.Name = "colDateLastSave";
            this.colDateLastSave.Visible = true;
            this.colDateLastSave.VisibleIndex = 3;
            this.colDateLastSave.Width = 76;
            //
            // edtDocTemplateName
            //
            this.edtDocTemplateName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDocTemplateName.DataMember = "DocTemplateName";
            this.edtDocTemplateName.DataSource = this.qryDocTemplate;
            this.edtDocTemplateName.Location = new System.Drawing.Point(110, 301);
            this.edtDocTemplateName.Name = "edtDocTemplateName";
            this.edtDocTemplateName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDocTemplateName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocTemplateName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocTemplateName.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocTemplateName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocTemplateName.Properties.Appearance.Options.UseFont = true;
            this.edtDocTemplateName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDocTemplateName.Size = new System.Drawing.Size(516, 24);
            this.edtDocTemplateName.TabIndex = 3;
            //
            // lblDocTemplateName
            //
            this.lblDocTemplateName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDocTemplateName.Location = new System.Drawing.Point(5, 301);
            this.lblDocTemplateName.Name = "lblDocTemplateName";
            this.lblDocTemplateName.Size = new System.Drawing.Size(100, 24);
            this.lblDocTemplateName.TabIndex = 6;
            this.lblDocTemplateName.Text = "Name der Vorlage";
            this.lblDocTemplateName.UseCompatibleTextRendering = true;
            //
            // edtDocTemplate
            //
            this.edtDocTemplate.AllowDrop = true;
            this.edtDocTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDocTemplate.Context = null;
            this.edtDocTemplate.DataMember = null;
            this.edtDocTemplate.DataSource = this.qryDocTemplate;
            this.edtDocTemplate.Location = new System.Drawing.Point(110, 365);
            this.edtDocTemplate.Name = "edtDocTemplate";
            this.edtDocTemplate.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDocTemplate.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocTemplate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocTemplate.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocTemplate.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocTemplate.Properties.Appearance.Options.UseFont = true;
            this.edtDocTemplate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDocTemplate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocTemplate.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocTemplate.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocTemplate.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocTemplate.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Dokument importieren")});
            this.edtDocTemplate.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocTemplate.Properties.ReadOnly = true;
            this.edtDocTemplate.Size = new System.Drawing.Size(125, 24);
            this.edtDocTemplate.TabIndex = 7;
            this.edtDocTemplate.DocumentOpening += new System.ComponentModel.CancelEventHandler(this.edtDocTemplate_DocumentOpening);
            this.edtDocTemplate.DocumentImporting += new System.ComponentModel.CancelEventHandler(this.edtDocTemplate_DocumentImporting);
            //
            // lblDocTemplate
            //
            this.lblDocTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDocTemplate.Location = new System.Drawing.Point(5, 366);
            this.lblDocTemplate.Name = "lblDocTemplate";
            this.lblDocTemplate.Size = new System.Drawing.Size(100, 24);
            this.lblDocTemplate.TabIndex = 8;
            this.lblDocTemplate.Text = "Vorlage";
            this.lblDocTemplate.UseCompatibleTextRendering = true;
            //
            // lblFaDokKatalogID
            //
            this.lblFaDokKatalogID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFaDokKatalogID.Location = new System.Drawing.Point(5, 332);
            this.lblFaDokKatalogID.Name = "lblFaDokKatalogID";
            this.lblFaDokKatalogID.Size = new System.Drawing.Size(100, 24);
            this.lblFaDokKatalogID.TabIndex = 635;
            this.lblFaDokKatalogID.Text = "Dokumentekategorie";
            this.lblFaDokKatalogID.UseCompatibleTextRendering = true;
            //
            // edtFaDokKatalogID
            //
            this.edtFaDokKatalogID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFaDokKatalogID.DataMember = "FaDokKatalogID";
            this.edtFaDokKatalogID.DataSource = this.qryDocTemplate;
            this.edtFaDokKatalogID.Location = new System.Drawing.Point(110, 332);
            this.edtFaDokKatalogID.Name = "edtFaDokKatalogID";
            this.edtFaDokKatalogID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaDokKatalogID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaDokKatalogID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokKatalogID.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaDokKatalogID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaDokKatalogID.Properties.Appearance.Options.UseFont = true;
            this.edtFaDokKatalogID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaDokKatalogID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaDokKatalogID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaDokKatalogID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaDokKatalogID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtFaDokKatalogID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtFaDokKatalogID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaDokKatalogID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kurzbeschreibung")});
            this.edtFaDokKatalogID.Properties.DisplayMember = "Kurzbeschreibung";
            this.edtFaDokKatalogID.Properties.NullText = "";
            this.edtFaDokKatalogID.Properties.ShowFooter = false;
            this.edtFaDokKatalogID.Properties.ShowHeader = false;
            this.edtFaDokKatalogID.Properties.ValueMember = "FaDokKatalogID";
            this.edtFaDokKatalogID.Size = new System.Drawing.Size(310, 24);
            this.edtFaDokKatalogID.TabIndex = 636;
            //
            // CtlDocTemplate
            //
            this.ActiveSQLQuery = this.qryDocTemplate;
            this.Controls.Add(this.edtFaDokKatalogID);
            this.Controls.Add(this.lblFaDokKatalogID);
            this.Controls.Add(this.lblDocTemplate);
            this.Controls.Add(this.edtDocTemplate);
            this.Controls.Add(this.lblDocTemplateName);
            this.Controls.Add(this.edtDocTemplateName);
            this.Controls.Add(this.grdDocTemplate);
            this.Name = "CtlDocTemplate";
            this.Size = new System.Drawing.Size(819, 406);
            this.Load += new System.EventHandler(this.CtlDocTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDocTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDocTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDocTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocTemplateName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocTemplateName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocTemplate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaDokKatalogID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKatalogID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaDokKatalogID)).EndInit();
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

        #region EventHandlers

        private void CtlDocTemplate_Load(object sender, System.EventArgs e)
        {
            // set this property in order to let work the documenthandler correctly
            this.edtDocTemplate.DokTypCode = DokTyp.Template;

            this.colDocFormatCode.ColumnEdit = this.grdDocTemplate.GetLOVLookUpEdit("DocFormat");

            // do not add WITH (READUNCOMMITTED) for XDocTemplate, in order to get a correct locking !!!
            qryDocTemplate.Fill(@"
                SELECT " + XDocTemplateNonBlobFieldList + @", FileBinary = CONVERT(image, NULL)
                FROM dbo.XDocTemplate
                ORDER BY DocTemplateName");

            //this.edtFaDokThemaCode_EditValueChanged(null, System.EventArgs.Empty);

            this.edtFaDokKatalogID.Properties.DropDownRows = 9;

            this.edtFaDokKatalogID.Properties.DataSource = DBUtil.OpenSQL(@"
                SELECT FaDokKatalogID, Kurzbeschreibung
                FROM dbo.FaDokKatalog WITH (READUNCOMMITTED)");

            defaultDokKatalogID = (int)DBUtil.ExecuteScalarSQL("SELECT TOP 1 FaDokKatalogID FROM dbo.FaDokKatalog WITH (READUNCOMMITTED)");
        }

        private void edtDocTemplate_DocumentImporting(object sender, CancelEventArgs e)
        {
            // importing needs a post (as DocumentOpening)
            edtDocTemplate_DocumentOpening(sender, e);
        }

        private void edtDocTemplate_DocumentOpening(object sender, CancelEventArgs e)
        {
            e.Cancel = false;

            if (edtDocTemplate.InUse)
            {
                // problem is observed with EXCEL:
                // after closing a template and reopening it too quickly KISS shuts down ... good bye :-)
                // thus : check if document is still in use and therefore cannot be saved back
                // TODO RH : has to be tested if efficient
                KissMsg.ShowInfo("CtlDocTemplate", "DokumentProzessNochOffen",
                    "Bitte warten Sie, bis das der Prozess das Dokument wieder freigegben hat.\r\n" +
                    "Unter Umständen haben Sie die aktuelle Bearbeitung noch nicht abgeschlossen.");
                e.Cancel = true;
                return;
            }

            if (qryDocTemplate.Row.RowState == DataRowState.Added)
            {
                // new row : check if we have already a file defined
                if (DBUtil.IsEmpty(qryDocTemplate["FileBinary"]))
                {
                    // no stream for filebinary found, cannot open template
                    KissMsg.ShowInfo("CtlDocTemplate", "NoTemplateFileBinaryNewItem",
                        "Zu dieser Vorlage wurde noch kein Dokument importiert.");

                    // no filebinary found, cannot open document
                    e.Cancel = true;
                    return;
                }
                else
                {
                    // stream for filebinary found, so let him edit it
                    // but in order to get the template ID new rows have to be posted first
                    bool oldRowModified = qryDocTemplate.RowModified;
                    qryDocTemplate.RowModified = true;
                    if (!qryDocTemplate.Post())
                    {
                        // probably the name is missing (or other errors), so do not continue
                        qryDocTemplate.RowModified = oldRowModified;
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        // post was successful, so set the metadata again
                        // in order to have the row ID in XDocument class
                        edtDocTemplate.Row = qryDocTemplate.Row;
                        qryDocTemplate.RowModified = true;
                    }
                }
            }
        }

        private void grdDocTemplate_DoubleClick(object sender, System.EventArgs e)
        {
            edtDocTemplate.OpenDoc();
        }

        private void qryDocTemplate_AfterFill(object sender, EventArgs e)
        {
            // in order to disable the editing fields
            if (qryDocTemplate.Count == 0) qryDocTemplate_PositionChanged(sender, e);
        }

        private void qryDocTemplate_AfterInsert(object sender, System.EventArgs e)
        {
            // TODO RH new doc handling has to be implemented

            qryDocTemplate["DocTemplateName"] = "Neue Vorlage";
            qryDocTemplate["DocFormatCode"] = DokFormat.Word;
            qryDocTemplate["FileExtension"] = ".dot";
            try
            {
                qryDocTemplate["FileBinary"] = edtDocTemplate.GetEmptyWordTemplate();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlDocTemplate", "ErrorInGetEmptyWordTemplate",
                    "Fehler beim Erstellen eines leeren Word-Templates. " +
                    "Möglicherweise ist Word nicht korrekt installiert", ex);
            }
            qryDocTemplate["DateCreation"] = DateTime.Now;
            qryDocTemplate["DateLastSave"] = DateTime.Now;
            qryDocTemplate["FaDokKatalogID"] = defaultDokKatalogID;

            // in order not to loose the row, when user does not make modificatoins at all:
            qryDocTemplate.RowModified = true;

            // in order to show the correct infos in KissButtonEdit
            edtDocTemplate.EditValue = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void qryDocTemplate_AfterPost(object sender, EventArgs e)
        {
            // in order to be up to date, when the row position will not be changed
            qryDocTemplate_PositionChanged(sender, e);
        }

        private void qryDocTemplate_BeforeDelete(object sender, EventArgs e)
        {
            // make a copy of the template before deleting it
            edtDocTemplate.SaveTemplateToLocalDirectory();
        }

        private void qryDocTemplate_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            // has to be made in order to get the newest timestamp
            // if not, KISS cannot delete
            if (!RestoreDataFromDB(true)) throw new KissCancelException();
        }

        private void qryDocTemplate_BeforePost(object sender, System.EventArgs e)
        {
            // check not null fields
            DBUtil.CheckNotNullField(edtDocTemplateName, lblDocTemplateName.Text);
            DBUtil.CheckNotNullField(edtFaDokKatalogID, lblFaDokKatalogID.Text);

            // TODO : no more required ?
            //DBUtil.CheckNotNullField(qryDocTemplate, "FileBinary", KissMsg.GetMLMessage("CtlDocTemplate", "Vorlage", "Vorlage"), edtDocTemplate);

            // check if document is still in use and therefore cannot be saved back
            if (edtDocTemplate.InUse)
            {
                // cancel Post() event
                throw new KissInfoException(KissMsg.GetMLMessage("CtlDocTemplate", "DokumentSchliessenUndWarten",
                    "Bitte das Dokument vor dem Speichern in KiSS schliessen und warten, bis das Dokument geschlossen ist.",
                    KissMsgCode.MsgInfo
                ));
            }

            // TODO RH required for ZH ?
            /*
            // validate must-fields on database-table
            if (DBUtil.IsEmpty(qryDocTemplate["DateCreation"]))
            {
                KissMsg.ShowInfo("CtlDocTemplate", "DateCreationIsEmpty",
                    "Die Vorlage kann nicht gepeichert werden, es ist kein Erstelldatum hinterlegt.");
                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(qryDocTemplate["DateLastSave"]))
            {
                KissMsg.ShowInfo("CtlDocTemplate", "DateLastSaveIsEmpty",
                    "Die Vorlage kann nicht gepeichert werden, es ist kein Speicherdatum hinterlegt.");
                throw new KissCancelException();
            }
            */

            // due to late-loading of FileBinary, we have to try to load it from database if user changed something and
            // the filebinary was not loaded yet. otherwise, the filebinary will be overriden by NULL and the template
            // therefore lost. this is only important for already existing documents.
            //if (DBUtil.IsEmpty(qryDocTemplate["FileBinary"]) && qryDocTemplate.Row.RowState != DataRowState.Added)
            if (qryDocTemplate.Row.RowState != DataRowState.Added)
            {
                // try to load FileBinary from database
                // we do not Post, if there is no success (FileBinary might be empty)
                if (!RestoreDataFromDB(false)) throw new KissCancelException();
            }

            // validate must-fields on database-table
            if (DBUtil.IsEmpty(qryDocTemplate["FileBinary"]))
            {
                KissMsg.ShowInfo("CtlDocTemplate", "FileBinaryIsEmpty",
                    "Die Vorlage kann nicht gepeichert werden, da noch kein Dokument hinterlegt ist.");
                throw new KissCancelException();
            }

            // security check
            if (!edtDocTemplate.CanUpdate)
            {
                KissMsg.ShowInfo("CtlDocTemplate", "SecurityCheckBeforePost_v01",
                    "Der Datensatz kann nicht gespeichert werden, " +
                    "da er als \"in Bearbeitung\" gekennzeichnet ist.");
                throw new KissCancelException();
            }

            // TODO RH : checkout the templete here, in order to have check it out for other users
            // could also be done by locking the template later, but then a transaction is a must !!!
            // has not a high priority, because only the transaction is not implemented yet

            // when the user can edit the document (not checked out by another user),
            // we allways can checkin the row here, because timestamp will check for us
            qryDocTemplate["CheckOut_UserID"] = DBNull.Value;
            qryDocTemplate["CheckOut_Date"] = DBNull.Value;
            qryDocTemplate["CheckOut_Filename"] = DBNull.Value;
            qryDocTemplate["CheckOut_Machine"] = DBNull.Value;
        }

        private void qryDocTemplate_PositionChanged(object sender, System.EventArgs e)
        {
            // setting the editing fields
            //bool canEdit = (qryDocTemplate.Count > 0 && DBUtil.IsEmpty(qryDocTemplate["Checkout_UserID"]));
            //qryDocTemplate.EnableBoundFields(canEdit);

            if (qryDocTemplate.Row != null)
            {
                // check if user added a new row
                if (qryDocTemplate.Row.RowState == DataRowState.Added)
                {
                    // new row, prevent applying row because of further problems with display...
                    edtDocTemplate.Row = null;
                }
                else
                {
                    // here the main document information is collected, colors are changed, hints are set
                    edtDocTemplate.Row = qryDocTemplate.Row;
                }
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// Restores actual from DB back to qryDocTemplate.
        /// </summary>
        private bool RestoreDataFromDB(bool onlyTimestamp)
        {
            // nothing to do, wenn DocTemplateID is NULL
            if (DBUtil.IsEmpty(qryDocTemplate["DocTemplateID"]))
            {
                // Coding error, do not translate
                KissMsg.ShowInfo("Programmfehler: Beim neuen Zeilen kann keine Vorlage zurückgesichert werden.");
                return false;
            }

            // restoring the filebinary data from the DB to the actual row
            // TODO RH : new fields UserIDLastSave ?
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT DTP.FileBinary,
                       DTP.DateCreation,
                       DTP.DateLastSave,
                       DTP.DocFormatCode,
                       DTP.FileExtension,
                       DTP.DocTemplateTS
                FROM dbo.XDocTemplate DTP
                WHERE DTP.DocTemplateID = {0}",
                qryDocTemplate["DocTemplateID"]);

            // check if we have a template saved on database
            if (!onlyTimestamp && DBUtil.IsEmpty(qry["FileBinary"]))
            {
                // no stream for filebinary found, cannot open template
                KissMsg.ShowInfo("CtlDocTemplate", "NoTemplateFileBinary",
                    "Zu dieser Vorlage wurde kein Dokument gefunden. Die Vorlage kann nicht geöffnet werden.");
                return false;
            }

            // apply for current row all new data including filebinary
            if (!onlyTimestamp)
            {
                qryDocTemplate["FileBinary"] = qry["FileBinary"];
                qryDocTemplate["DateCreation"] = qry["DateCreation"];
                qryDocTemplate["DateLastSave"] = qry["DateLastSave"];
                qryDocTemplate["DocFormatCode"] = qry["DocFormatCode"];
                qryDocTemplate["FileExtension"] = qry["FileExtension"];
                // TODO RH : new fields UserIDLastSave ?
            }
            qryDocTemplate["DocTemplateTS"] = qry["DocTemplateTS"];

            qryDocTemplate.Row.AcceptChanges();
            return true;
        }

        #endregion

        #endregion
    }
}