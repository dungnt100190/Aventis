using System;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sostat
{
    public class CtlBfsKonfiguration : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        // fields
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private System.ComponentModel.IContainer components;
        private KissTextEdit edtSostatDSN;
        private KiSS4.Gui.KissTextEdit edtSostatExportPfad;
        private KiSS4.Gui.KissTextEdit edtSostatExportPfadXML;
        private KiSS4.Gui.KissCalcEdit edtSostatInstitutionNr;
        private KiSS4.Gui.KissCalcEdit edtSostatJahr;
        private KiSS4.Gui.KissGrid grdSostatGemeinden;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSostatGemeinden;
        private KissLabel lblDSN;
        private KiSS4.Gui.KissLabel lblSostatErhebungsjahr;
        private KiSS4.Gui.KissLabel lblSostatExportPfad;
        private KiSS4.Gui.KissLabel lblSostatExportPfadXML;
        private KiSS4.Gui.KissLabel lblSostatGemeinden;
        private KiSS4.Gui.KissLabel lblSostatInstitutionNr;
        private KissLabel lblEditInfo;
        private KiSS4.DB.SqlQuery qryBFSLOVCode;

        #endregion

        #endregion

        #region Constructors

        public CtlBfsKonfiguration()
        {
            this.InitializeComponent();

            qryBFSLOVCode.Fill();
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
            this.lblSostatErhebungsjahr = new KiSS4.Gui.KissLabel();
            this.edtSostatJahr = new KiSS4.Gui.KissCalcEdit();
            this.lblSostatInstitutionNr = new KiSS4.Gui.KissLabel();
            this.edtSostatInstitutionNr = new KiSS4.Gui.KissCalcEdit();
            this.lblSostatExportPfad = new KiSS4.Gui.KissLabel();
            this.edtSostatExportPfad = new KiSS4.Gui.KissTextEdit();
            this.lblSostatExportPfadXML = new KiSS4.Gui.KissLabel();
            this.edtSostatExportPfadXML = new KiSS4.Gui.KissTextEdit();
            this.lblSostatGemeinden = new KiSS4.Gui.KissLabel();
            this.grdSostatGemeinden = new KiSS4.Gui.KissGrid();
            this.qryBFSLOVCode = new KiSS4.DB.SqlQuery(this.components);
            this.grvSostatGemeinden = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblDSN = new KiSS4.Gui.KissLabel();
            this.edtSostatDSN = new KiSS4.Gui.KissTextEdit();
            this.lblEditInfo = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblSostatErhebungsjahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSostatJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSostatInstitutionNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSostatInstitutionNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSostatExportPfad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSostatExportPfad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSostatExportPfadXML)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSostatExportPfadXML.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSostatGemeinden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSostatGemeinden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBFSLOVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSostatGemeinden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDSN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSostatDSN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEditInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSostatErhebungsjahr
            // 
            this.lblSostatErhebungsjahr.Location = new System.Drawing.Point(21, 12);
            this.lblSostatErhebungsjahr.Name = "lblSostatErhebungsjahr";
            this.lblSostatErhebungsjahr.Size = new System.Drawing.Size(100, 24);
            this.lblSostatErhebungsjahr.TabIndex = 0;
            this.lblSostatErhebungsjahr.Text = "Erhebungsjahr";
            this.lblSostatErhebungsjahr.UseCompatibleTextRendering = true;
            // 
            // edtSostatJahr
            // 
            this.edtSostatJahr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSostatJahr.Location = new System.Drawing.Point(127, 10);
            this.edtSostatJahr.Name = "edtSostatJahr";
            this.edtSostatJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSostatJahr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSostatJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSostatJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSostatJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSostatJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSostatJahr.Properties.Appearance.Options.UseFont = true;
            this.edtSostatJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSostatJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSostatJahr.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtSostatJahr.Properties.DisplayFormat.FormatString = "F0";
            this.edtSostatJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSostatJahr.Properties.EditFormat.FormatString = "F0";
            this.edtSostatJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSostatJahr.Properties.Mask.EditMask = "####";
            this.edtSostatJahr.Properties.MaxLength = 4;
            this.edtSostatJahr.Properties.Precision = 0;
            this.edtSostatJahr.Properties.ReadOnly = true;
            this.edtSostatJahr.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtSostatJahr.Size = new System.Drawing.Size(59, 24);
            this.edtSostatJahr.TabIndex = 1;
            // 
            // lblSostatInstitutionNr
            // 
            this.lblSostatInstitutionNr.Location = new System.Drawing.Point(21, 40);
            this.lblSostatInstitutionNr.Name = "lblSostatInstitutionNr";
            this.lblSostatInstitutionNr.Size = new System.Drawing.Size(100, 24);
            this.lblSostatInstitutionNr.TabIndex = 2;
            this.lblSostatInstitutionNr.Text = "Institution-Nr.";
            this.lblSostatInstitutionNr.UseCompatibleTextRendering = true;
            // 
            // edtSostatInstitutionNr
            // 
            this.edtSostatInstitutionNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSostatInstitutionNr.Location = new System.Drawing.Point(127, 40);
            this.edtSostatInstitutionNr.Name = "edtSostatInstitutionNr";
            this.edtSostatInstitutionNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSostatInstitutionNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSostatInstitutionNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSostatInstitutionNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSostatInstitutionNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSostatInstitutionNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSostatInstitutionNr.Properties.Appearance.Options.UseFont = true;
            this.edtSostatInstitutionNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSostatInstitutionNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSostatInstitutionNr.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtSostatInstitutionNr.Properties.Mask.EditMask = "F0";
            this.edtSostatInstitutionNr.Properties.Precision = 0;
            this.edtSostatInstitutionNr.Properties.ReadOnly = true;
            this.edtSostatInstitutionNr.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtSostatInstitutionNr.Size = new System.Drawing.Size(166, 24);
            this.edtSostatInstitutionNr.TabIndex = 3;
            // 
            // lblSostatExportPfad
            // 
            this.lblSostatExportPfad.Location = new System.Drawing.Point(21, 70);
            this.lblSostatExportPfad.Name = "lblSostatExportPfad";
            this.lblSostatExportPfad.Size = new System.Drawing.Size(100, 24);
            this.lblSostatExportPfad.TabIndex = 4;
            this.lblSostatExportPfad.Text = "Export-Pfad";
            this.lblSostatExportPfad.UseCompatibleTextRendering = true;
            // 
            // edtSostatExportPfad
            // 
            this.edtSostatExportPfad.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSostatExportPfad.Location = new System.Drawing.Point(127, 70);
            this.edtSostatExportPfad.Name = "edtSostatExportPfad";
            this.edtSostatExportPfad.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSostatExportPfad.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSostatExportPfad.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSostatExportPfad.Properties.Appearance.Options.UseBackColor = true;
            this.edtSostatExportPfad.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSostatExportPfad.Properties.Appearance.Options.UseFont = true;
            this.edtSostatExportPfad.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSostatExportPfad.Properties.ReadOnly = true;
            this.edtSostatExportPfad.Size = new System.Drawing.Size(333, 24);
            this.edtSostatExportPfad.TabIndex = 5;
            // 
            // lblSostatExportPfadXML
            // 
            this.lblSostatExportPfadXML.Location = new System.Drawing.Point(21, 100);
            this.lblSostatExportPfadXML.Name = "lblSostatExportPfadXML";
            this.lblSostatExportPfadXML.Size = new System.Drawing.Size(100, 24);
            this.lblSostatExportPfadXML.TabIndex = 6;
            this.lblSostatExportPfadXML.Text = "Export-Pfad XML";
            this.lblSostatExportPfadXML.UseCompatibleTextRendering = true;
            // 
            // edtSostatExportPfadXML
            // 
            this.edtSostatExportPfadXML.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSostatExportPfadXML.Location = new System.Drawing.Point(127, 100);
            this.edtSostatExportPfadXML.Name = "edtSostatExportPfadXML";
            this.edtSostatExportPfadXML.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSostatExportPfadXML.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSostatExportPfadXML.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSostatExportPfadXML.Properties.Appearance.Options.UseBackColor = true;
            this.edtSostatExportPfadXML.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSostatExportPfadXML.Properties.Appearance.Options.UseFont = true;
            this.edtSostatExportPfadXML.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSostatExportPfadXML.Properties.ReadOnly = true;
            this.edtSostatExportPfadXML.Size = new System.Drawing.Size(333, 24);
            this.edtSostatExportPfadXML.TabIndex = 7;
            // 
            // lblSostatGemeinden
            // 
            this.lblSostatGemeinden.Location = new System.Drawing.Point(21, 130);
            this.lblSostatGemeinden.Name = "lblSostatGemeinden";
            this.lblSostatGemeinden.Size = new System.Drawing.Size(100, 24);
            this.lblSostatGemeinden.TabIndex = 8;
            this.lblSostatGemeinden.Text = "Gemeinden";
            this.lblSostatGemeinden.UseCompatibleTextRendering = true;
            // 
            // grdSostatGemeinden
            // 
            this.grdSostatGemeinden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdSostatGemeinden.DataSource = this.qryBFSLOVCode;
            this.grdSostatGemeinden.EmbeddedNavigator.Name = "";
            this.grdSostatGemeinden.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdSostatGemeinden.Location = new System.Drawing.Point(127, 130);
            this.grdSostatGemeinden.MainView = this.grvSostatGemeinden;
            this.grdSostatGemeinden.Name = "grdSostatGemeinden";
            this.grdSostatGemeinden.Size = new System.Drawing.Size(333, 222);
            this.grdSostatGemeinden.TabIndex = 9;
            this.grdSostatGemeinden.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSostatGemeinden});
            // 
            // qryBFSLOVCode
            // 
            this.qryBFSLOVCode.HostControl = this;
            this.qryBFSLOVCode.SelectStatement = "SELECT Code, Text\r\nFROM BFSLOVCode\r\nWHERE LOVName = \'BFSGemeindeSozialdienst\'\r\nOR" +
                "DER BY SortKey, Text";
            this.qryBFSLOVCode.TableName = "XBFSLOVCode";
            // 
            // grvSostatGemeinden
            // 
            this.grvSostatGemeinden.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvSostatGemeinden.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSostatGemeinden.Appearance.Empty.Options.UseBackColor = true;
            this.grvSostatGemeinden.Appearance.Empty.Options.UseFont = true;
            this.grvSostatGemeinden.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSostatGemeinden.Appearance.EvenRow.Options.UseFont = true;
            this.grvSostatGemeinden.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvSostatGemeinden.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSostatGemeinden.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvSostatGemeinden.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvSostatGemeinden.Appearance.FocusedCell.Options.UseFont = true;
            this.grvSostatGemeinden.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvSostatGemeinden.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvSostatGemeinden.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSostatGemeinden.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvSostatGemeinden.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvSostatGemeinden.Appearance.FocusedRow.Options.UseFont = true;
            this.grvSostatGemeinden.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvSostatGemeinden.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSostatGemeinden.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvSostatGemeinden.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSostatGemeinden.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvSostatGemeinden.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvSostatGemeinden.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvSostatGemeinden.Appearance.GroupRow.Options.UseFont = true;
            this.grvSostatGemeinden.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvSostatGemeinden.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvSostatGemeinden.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvSostatGemeinden.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvSostatGemeinden.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvSostatGemeinden.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvSostatGemeinden.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSostatGemeinden.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvSostatGemeinden.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSostatGemeinden.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvSostatGemeinden.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvSostatGemeinden.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvSostatGemeinden.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvSostatGemeinden.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvSostatGemeinden.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvSostatGemeinden.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSostatGemeinden.Appearance.OddRow.Options.UseFont = true;
            this.grvSostatGemeinden.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvSostatGemeinden.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSostatGemeinden.Appearance.Row.Options.UseBackColor = true;
            this.grvSostatGemeinden.Appearance.Row.Options.UseFont = true;
            this.grvSostatGemeinden.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSostatGemeinden.Appearance.SelectedRow.Options.UseFont = true;
            this.grvSostatGemeinden.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvSostatGemeinden.Appearance.VertLine.Options.UseBackColor = true;
            this.grvSostatGemeinden.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvSostatGemeinden.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colText});
            this.grvSostatGemeinden.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvSostatGemeinden.GridControl = this.grdSostatGemeinden;
            this.grvSostatGemeinden.Name = "grvSostatGemeinden";
            this.grvSostatGemeinden.OptionsBehavior.Editable = false;
            this.grvSostatGemeinden.OptionsCustomization.AllowFilter = false;
            this.grvSostatGemeinden.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvSostatGemeinden.OptionsNavigation.AutoFocusNewRow = true;
            this.grvSostatGemeinden.OptionsNavigation.UseTabKey = false;
            this.grvSostatGemeinden.OptionsView.ColumnAutoWidth = false;
            this.grvSostatGemeinden.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvSostatGemeinden.OptionsView.ShowGroupPanel = false;
            this.grvSostatGemeinden.OptionsView.ShowIndicator = false;
            // 
            // colCode
            // 
            this.colCode.Caption = "Code";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 65;
            // 
            // colText
            // 
            this.colText.Caption = "Gemeinde";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 1;
            this.colText.Width = 256;
            // 
            // lblDSN
            // 
            this.lblDSN.Location = new System.Drawing.Point(202, 10);
            this.lblDSN.Name = "lblDSN";
            this.lblDSN.Size = new System.Drawing.Size(38, 24);
            this.lblDSN.TabIndex = 2;
            this.lblDSN.Text = "DSN";
            this.lblDSN.UseCompatibleTextRendering = true;
            // 
            // edtSostatDSN
            // 
            this.edtSostatDSN.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSostatDSN.Location = new System.Drawing.Point(234, 10);
            this.edtSostatDSN.Name = "edtSostatDSN";
            this.edtSostatDSN.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSostatDSN.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSostatDSN.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSostatDSN.Properties.Appearance.Options.UseBackColor = true;
            this.edtSostatDSN.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSostatDSN.Properties.Appearance.Options.UseFont = true;
            this.edtSostatDSN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSostatDSN.Properties.ReadOnly = true;
            this.edtSostatDSN.Size = new System.Drawing.Size(226, 24);
            this.edtSostatDSN.TabIndex = 5;
            // 
            // lblEditInfo
            // 
            this.lblEditInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditInfo.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblEditInfo.Location = new System.Drawing.Point(493, 10);
            this.lblEditInfo.Name = "lblEditInfo";
            this.lblEditInfo.Size = new System.Drawing.Size(256, 114);
            this.lblEditInfo.TabIndex = 10;
            this.lblEditInfo.Text = "Sie können diese Werte unter \"System\\Konfiguration\" im Schlüssel \"System\\SoStat\" " +
                "anpassen.";
            // 
            // CtlBfsKonfiguration
            // 
            this.Controls.Add(this.lblEditInfo);
            this.Controls.Add(this.grdSostatGemeinden);
            this.Controls.Add(this.lblSostatGemeinden);
            this.Controls.Add(this.edtSostatExportPfadXML);
            this.Controls.Add(this.lblSostatExportPfadXML);
            this.Controls.Add(this.edtSostatDSN);
            this.Controls.Add(this.edtSostatExportPfad);
            this.Controls.Add(this.lblSostatExportPfad);
            this.Controls.Add(this.lblDSN);
            this.Controls.Add(this.edtSostatInstitutionNr);
            this.Controls.Add(this.lblSostatInstitutionNr);
            this.Controls.Add(this.edtSostatJahr);
            this.Controls.Add(this.lblSostatErhebungsjahr);
            this.Name = "CtlBfsKonfiguration";
            this.Size = new System.Drawing.Size(764, 360);
            this.Load += new System.EventHandler(this.CtlBfsKonfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblSostatErhebungsjahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSostatJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSostatInstitutionNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSostatInstitutionNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSostatExportPfad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSostatExportPfad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSostatExportPfadXML)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSostatExportPfadXML.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSostatGemeinden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSostatGemeinden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBFSLOVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSostatGemeinden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDSN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSostatDSN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEditInfo)).EndInit();
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

        private void CtlBfsKonfiguration_Load(object sender, System.EventArgs e)
        {
            try
            {
                // set cursor
                this.Cursor = Cursors.WaitCursor;

                // get current values from  XConfig
                edtSostatJahr.EditValue = DBUtil.GetConfigInt(SostatUtils.SOSTATJAHRKEY, 0);
                edtSostatDSN.EditValue = DBUtil.GetConfigString(SostatUtils.SOSTATDSNKEY, "plausexsql");
                edtSostatInstitutionNr.EditValue = DBUtil.GetConfigInt(SostatUtils.SOSTATINSTITUTIONNRKEY, 0);
                edtSostatExportPfad.EditValue = DBUtil.GetConfigString(SostatUtils.SOSTATEXPORTPATHKEY, "");
                edtSostatExportPfadXML.EditValue = DBUtil.GetConfigString(SostatUtils.SOSTATEXPORTPATHXMLKEY, "");

            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

    }
}