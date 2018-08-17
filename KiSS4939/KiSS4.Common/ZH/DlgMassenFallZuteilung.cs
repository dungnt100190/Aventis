#region Header

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.832
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#endregion

using System;

using KiSS4.DB;

namespace KiSS4.Common.ZH
{
    public class DlgMassenFallZuteilung : KiSS4.Gui.KissDialog
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "DlgMassenFallZuteilung";

        #endregion

        #region Private Fields

        private KiSS4.Gui.KissButton btnMA;
        private KiSS4.Gui.KissButton btnOK;
        private DevExpress.XtraGrid.Columns.GridColumn colLogonName;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrgUnit;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtFilterDst;
        private KiSS4.Gui.KissTextEdit edtFilterSrc;
        private KiSS4.Gui.KissGrid grdUserDst;
        private KiSS4.Gui.KissGrid grdUserSrc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUserDst;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUserSrc;
        private KiSS4.Gui.KissLabel lblFilterDst;
        private KiSS4.Gui.KissLabel lblFilterSrc;
        private KiSS4.DB.SqlQuery qryUserDst;
        private KiSS4.DB.SqlQuery qryUserSrc;

        #endregion

        #endregion

        #region Constructors

        public DlgMassenFallZuteilung()
        {
            this.InitializeComponent();
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
            this.grdUserSrc = new KiSS4.Gui.KissGrid();
            this.grdUserDst = new KiSS4.Gui.KissGrid();
            this.edtFilterSrc = new KiSS4.Gui.KissTextEdit();
            this.edtFilterDst = new KiSS4.Gui.KissTextEdit();
            this.btnMA = new KiSS4.Gui.KissButton();
            this.btnOK = new KiSS4.Gui.KissButton();
            this.lblFilterSrc = new KiSS4.Gui.KissLabel();
            this.lblFilterDst = new KiSS4.Gui.KissLabel();
            this.colLogonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvUserDst = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grvUserSrc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryUserDst = new KiSS4.DB.SqlQuery(this.components);
            this.qryUserSrc = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserDst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterSrc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterDst.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterDst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserDst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserDst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserSrc)).BeginInit();
            this.SuspendLayout();
            //
            // grdUserSrc
            //
            this.grdUserSrc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdUserSrc.DataSource = this.qryUserSrc;
            this.grdUserSrc.EmbeddedNavigator.Name = "";
            this.grdUserSrc.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdUserSrc.Location = new System.Drawing.Point(16, 16);
            this.grdUserSrc.MainView = this.grvUserSrc;
            this.grdUserSrc.Name = "grdUserSrc";
            this.grdUserSrc.Size = new System.Drawing.Size(412, 243);
            this.grdUserSrc.TabIndex = 0;
            this.grdUserSrc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvUserSrc});
            //
            // grdUserDst
            //
            this.grdUserDst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdUserDst.DataSource = this.qryUserDst;
            this.grdUserDst.EmbeddedNavigator.Name = "";
            this.grdUserDst.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdUserDst.Location = new System.Drawing.Point(463, 16);
            this.grdUserDst.MainView = this.grvUserDst;
            this.grdUserDst.Name = "grdUserDst";
            this.grdUserDst.Size = new System.Drawing.Size(412, 243);
            this.grdUserDst.TabIndex = 1;
            this.grdUserDst.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvUserDst});
            //
            // edtFilterSrc
            //
            this.edtFilterSrc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFilterSrc.Location = new System.Drawing.Point(56, 265);
            this.edtFilterSrc.Name = "edtFilterSrc";
            this.edtFilterSrc.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilterSrc.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilterSrc.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilterSrc.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterSrc.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilterSrc.Properties.Appearance.Options.UseFont = true;
            this.edtFilterSrc.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilterSrc.Size = new System.Drawing.Size(194, 24);
            this.edtFilterSrc.TabIndex = 2;
            this.edtFilterSrc.EditValueChanged += new System.EventHandler(this.edtFilterSrc_EditValueChanged);
            //
            // edtFilterDst
            //
            this.edtFilterDst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFilterDst.Location = new System.Drawing.Point(503, 265);
            this.edtFilterDst.Name = "edtFilterDst";
            this.edtFilterDst.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilterDst.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilterDst.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilterDst.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterDst.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilterDst.Properties.Appearance.Options.UseFont = true;
            this.edtFilterDst.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilterDst.Size = new System.Drawing.Size(194, 24);
            this.edtFilterDst.TabIndex = 3;
            this.edtFilterDst.EditValueChanged += new System.EventHandler(this.edtFilterDst_EditValueChanged);
            //
            // btnMA
            //
            this.btnMA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMA.IconID = 13;
            this.btnMA.Location = new System.Drawing.Point(434, 107);
            this.btnMA.Name = "btnMA";
            this.btnMA.Size = new System.Drawing.Size(24, 24);
            this.btnMA.TabIndex = 4;
            this.btnMA.UseCompatibleTextRendering = true;
            this.btnMA.UseVisualStyleBackColor = false;
            this.btnMA.Click += new System.EventHandler(this.btnMA_Click);
            //
            // btnOK
            //
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(791, 296);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 24);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseCompatibleTextRendering = true;
            this.btnOK.UseVisualStyleBackColor = true;
            //
            // lblFilterSrc
            //
            this.lblFilterSrc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFilterSrc.Location = new System.Drawing.Point(16, 265);
            this.lblFilterSrc.Name = "lblFilterSrc";
            this.lblFilterSrc.Size = new System.Drawing.Size(33, 24);
            this.lblFilterSrc.TabIndex = 6;
            this.lblFilterSrc.Text = "Filter";
            this.lblFilterSrc.UseCompatibleTextRendering = true;
            //
            // lblFilterDst
            //
            this.lblFilterDst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFilterDst.Location = new System.Drawing.Point(463, 265);
            this.lblFilterDst.Name = "lblFilterDst";
            this.lblFilterDst.Size = new System.Drawing.Size(33, 24);
            this.lblFilterDst.TabIndex = 7;
            this.lblFilterDst.Text = "Filter";
            this.lblFilterDst.UseCompatibleTextRendering = true;
            //
            // colLogonName
            //
            this.colLogonName.Caption = "K�rzel";
            this.colLogonName.FieldName = "LogonName";
            this.colLogonName.Name = "colLogonName";
            this.colLogonName.Visible = true;
            this.colLogonName.VisibleIndex = 0;
            this.colLogonName.Width = 70;
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "NameVorname";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 166;
            //
            // colOrgUnit
            //
            this.colOrgUnit.Caption = "Organisationseinheit";
            this.colOrgUnit.FieldName = "OrgUnit";
            this.colOrgUnit.Name = "colOrgUnit";
            this.colOrgUnit.Visible = true;
            this.colOrgUnit.VisibleIndex = 2;
            this.colOrgUnit.Width = 171;
            //
            // gridColumn1
            //
            this.gridColumn1.Caption = "K�rzel";
            this.gridColumn1.FieldName = "LogonName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 70;
            //
            // gridColumn2
            //
            this.gridColumn2.Caption = "Name";
            this.gridColumn2.FieldName = "NameVorname";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 166;
            //
            // gridColumn3
            //
            this.gridColumn3.Caption = "Organisationseinheit";
            this.gridColumn3.FieldName = "OrgUnit";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 171;
            //
            // grvUserDst
            //
            this.grvUserDst.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvUserDst.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserDst.Appearance.Empty.Options.UseBackColor = true;
            this.grvUserDst.Appearance.Empty.Options.UseFont = true;
            this.grvUserDst.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserDst.Appearance.EvenRow.Options.UseFont = true;
            this.grvUserDst.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvUserDst.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserDst.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvUserDst.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvUserDst.Appearance.FocusedCell.Options.UseFont = true;
            this.grvUserDst.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvUserDst.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvUserDst.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserDst.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvUserDst.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvUserDst.Appearance.FocusedRow.Options.UseFont = true;
            this.grvUserDst.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvUserDst.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvUserDst.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvUserDst.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvUserDst.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserDst.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvUserDst.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvUserDst.Appearance.GroupRow.Options.UseFont = true;
            this.grvUserDst.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvUserDst.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvUserDst.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvUserDst.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserDst.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvUserDst.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvUserDst.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvUserDst.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvUserDst.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserDst.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvUserDst.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvUserDst.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvUserDst.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvUserDst.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvUserDst.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvUserDst.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserDst.Appearance.OddRow.Options.UseFont = true;
            this.grvUserDst.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvUserDst.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserDst.Appearance.Row.Options.UseBackColor = true;
            this.grvUserDst.Appearance.Row.Options.UseFont = true;
            this.grvUserDst.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserDst.Appearance.SelectedRow.Options.UseFont = true;
            this.grvUserDst.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvUserDst.Appearance.VertLine.Options.UseBackColor = true;
            this.grvUserDst.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvUserDst.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.gridColumn1,
                        this.gridColumn2,
                        this.gridColumn3});
            this.grvUserDst.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvUserDst.GridControl = this.grdUserDst;
            this.grvUserDst.Name = "grvUserDst";
            this.grvUserDst.OptionsBehavior.Editable = false;
            this.grvUserDst.OptionsCustomization.AllowFilter = false;
            this.grvUserDst.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvUserDst.OptionsNavigation.AutoFocusNewRow = true;
            this.grvUserDst.OptionsNavigation.UseTabKey = false;
            this.grvUserDst.OptionsView.ColumnAutoWidth = false;
            this.grvUserDst.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvUserDst.OptionsView.ShowGroupPanel = false;
            this.grvUserDst.OptionsView.ShowIndicator = false;
            //
            // grvUserSrc
            //
            this.grvUserSrc.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvUserSrc.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserSrc.Appearance.Empty.Options.UseBackColor = true;
            this.grvUserSrc.Appearance.Empty.Options.UseFont = true;
            this.grvUserSrc.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserSrc.Appearance.EvenRow.Options.UseFont = true;
            this.grvUserSrc.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvUserSrc.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserSrc.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvUserSrc.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvUserSrc.Appearance.FocusedCell.Options.UseFont = true;
            this.grvUserSrc.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvUserSrc.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvUserSrc.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserSrc.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvUserSrc.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvUserSrc.Appearance.FocusedRow.Options.UseFont = true;
            this.grvUserSrc.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvUserSrc.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvUserSrc.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvUserSrc.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvUserSrc.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserSrc.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvUserSrc.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvUserSrc.Appearance.GroupRow.Options.UseFont = true;
            this.grvUserSrc.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvUserSrc.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvUserSrc.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvUserSrc.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserSrc.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvUserSrc.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvUserSrc.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvUserSrc.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvUserSrc.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserSrc.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvUserSrc.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvUserSrc.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvUserSrc.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvUserSrc.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvUserSrc.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvUserSrc.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserSrc.Appearance.OddRow.Options.UseFont = true;
            this.grvUserSrc.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvUserSrc.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserSrc.Appearance.Row.Options.UseBackColor = true;
            this.grvUserSrc.Appearance.Row.Options.UseFont = true;
            this.grvUserSrc.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUserSrc.Appearance.SelectedRow.Options.UseFont = true;
            this.grvUserSrc.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvUserSrc.Appearance.VertLine.Options.UseBackColor = true;
            this.grvUserSrc.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvUserSrc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colLogonName,
                        this.colName,
                        this.colOrgUnit});
            this.grvUserSrc.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvUserSrc.GridControl = this.grdUserSrc;
            this.grvUserSrc.Name = "grvUserSrc";
            this.grvUserSrc.OptionsBehavior.Editable = false;
            this.grvUserSrc.OptionsCustomization.AllowFilter = false;
            this.grvUserSrc.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvUserSrc.OptionsNavigation.AutoFocusNewRow = true;
            this.grvUserSrc.OptionsNavigation.UseTabKey = false;
            this.grvUserSrc.OptionsView.ColumnAutoWidth = false;
            this.grvUserSrc.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvUserSrc.OptionsView.ShowGroupPanel = false;
            this.grvUserSrc.OptionsView.ShowIndicator = false;
            //
            // qryUserDst
            //
            this.qryUserDst.HostControl = this;
            this.qryUserDst.SelectStatement = "select UserID,\r\n       LogonName,\r\n       NameVorname,\r\n       OrgUnit,\r\n       U" +
                "serInfo = LogonNameVornameOrgUnit\r\nfrom   vwUser\r\norder by NameVorname";
            //
            // qryUserSrc
            //
            this.qryUserSrc.HostControl = this;
            this.qryUserSrc.SelectStatement = "select UserID,\r\n       LogonName,\r\n       NameVorname,\r\n       OrgUnit,\r\n       U" +
                "serInfo = LogonNameVornameOrgUnit\r\nfrom   vwUser\r\norder by NameVorname";
            //
            // DlgMassenFallZuteilung
            //
            this.ClientSize = new System.Drawing.Size(887, 326);
            this.Controls.Add(this.lblFilterDst);
            this.Controls.Add(this.lblFilterSrc);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnMA);
            this.Controls.Add(this.edtFilterDst);
            this.Controls.Add(this.edtFilterSrc);
            this.Controls.Add(this.grdUserDst);
            this.Controls.Add(this.grdUserSrc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DlgMassenFallZuteilung";
            this.Text = "Fallzuteilung";
            this.Load += new System.EventHandler(this.DlgMassenFallZuteilung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserDst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterSrc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterDst.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterDst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserDst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserDst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserSrc)).EndInit();
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

        private void DlgMassenFallZuteilung_Load(object sender, System.EventArgs e)
        {
            qryUserSrc.Fill();
            qryUserDst.Fill();
        }

        private void btnMA_Click(object sender, System.EventArgs e)
        {
            if (qryUserSrc.Count == 0 || qryUserDst.Count == 0) return;
            if (DBUtil.IsEmpty(qryUserSrc["UserID"]) || DBUtil.IsEmpty(qryUserDst["UserID"])) return;
            if (qryUserSrc["UserID"].ToString() == qryUserDst["UserID"].ToString()) return;

            if( KissMsg.ShowQuestion("DlgMassenFallZuteilung", "SicherAlleF�lleVerschieben", "Wollen Sie wirklich alle Leistungen und Alle F�lle von Benutzer '{0}' dem Benutzer '{1}' zuteilen?", 0, 0, true, qryUserSrc["UserInfo"], qryUserDst["UserInfo"]) == false)
                return;

            //Pendenzen umhaengen: Nur offene Pendezen mit alten SAR als Empfaenger werden umgeh�ngt
            //pr�fen, ob unerledigte Pendenzen existieren, die umgehaengt werden muessen
            if (DBUtil.GetConfigBool(@"System\Pendenzen\Pendenzenverwaltung\FragenVorWechselLV", false))
            {
                //taskstatuscode 3 = erledigt
                int countUnerledigte = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                        SELECT COUNT(*)
                        FROM dbo.XTask WITH(READUNCOMMITTED)
                        WHERE TaskStatusCode <> 3
                        AND ReceiverID = {0}",
                        qryUserSrc["UserID"]);

                if (countUnerledigte > 0)
                {
                    //Bei Nein im Dialog -> abbrechen
                    if (!KissMsg.ShowQuestion(CLASSNAME, "DlgWechselLeistungsverantwortung", FallUtil.LV_WECHSEL_PENDENZEN_FRAGE))
                    {
                        return;
                    }
                }
            }

            try
            {
                Session.BeginTransaction();

                // Umhaengen der Pendenzen
                DBUtil.ExecSQL(@"UPDATE dbo.XTask
                                    SET    ReceiverID = {0}
                                  WHERE    ReceiverID = {1}
                                    AND    TaskStatusCode <> 3 ", qryUserDst["UserID"], qryUserSrc["UserID"]);

                //Eintrag ins Fallverlaufsprotokoll
                DBUtil.ExecSQLThrowingException( @"INSERT FaJournal (FaFallID, FaLeistungID, BaPersonID, UserID, Text, OrgUnitID)
                                  SELECT FaFallID, FaLeistungID, null, {0}, {1}, {2}
                                  FROM   FaLeistung
                                  WHERE  UserID = {3}",
                                Session.User.UserID,
                        string.Format("Wechsel Leistungsverantwortung: von {0} zu {1}", qryUserSrc["UserInfo"], qryUserDst["UserInfo"]),
                        Session.User["OrgUnitID"],
                                qryUserSrc["UserID"]);

                int leistungCount = (int)DBUtil.ExecSQLThrowingException(@"update FaLeistung set UserID = {0}, Modifier = {1}, Modified = GetDate() where UserID = {2}",
                    qryUserDst["UserID"],
                    DBUtil.GetDBRowCreatorModifier(),
                    qryUserSrc["UserID"]);

                //Eintrag ins Fallverlaufsprotokoll
                DBUtil.ExecSQLThrowingException( @"INSERT FaJournal (FaFallID, FaLeistungID, BaPersonID, UserID, Text, OrgUnitID)
                                  SELECT FaFallID, null, null, {0}, {1}, {2}
                                  FROM   FaFall
                                  WHERE  UserID = {3}",
                        Session.User.UserID,
                        string.Format("Wechsel Fallverantwortung: von {0} zu {1}", qryUserSrc["UserInfo"], qryUserDst["UserInfo"]),
                        Session.User["OrgUnitID"],
                                qryUserSrc["UserID"]);

                int fallCount = (int)DBUtil.ExecSQLThrowingException(@"update FaFall set UserID = {0} where UserID = {1}",
                    qryUserDst["UserID"],
                    qryUserSrc["UserID"]);

                Refresh();

                Session.Commit();

                KissMsg.ShowInfo( "DlgMassenFallZuteilung", "InfoFallUmteilung", "Es wurde {0} F�lle und {1} Leistungen umgeteilt", 0, 0, fallCount, leistungCount);
            }
            catch(Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError( "DlgMassenFallZuteilung", "FehlerBeiFallUmteilung", "Fehler beim Uteilen von F�llen/Leistungen", ex);
            }
        }

        private void edtFilterDst_EditValueChanged(object sender, System.EventArgs e)
        {
            string Value = edtFilterDst.EditValue.ToString();
            qryUserDst.DataTable.DefaultView.RowFilter = "NameVorname like '%" + Value + "%' or LogonName like '%" + Value + "%' or OrgUnit like '%" + Value + "%'";
        }

        private void edtFilterSrc_EditValueChanged(object sender, System.EventArgs e)
        {
            string Value = edtFilterSrc.EditValue.ToString();
            qryUserSrc.DataTable.DefaultView.RowFilter = "NameVorname like '%" + Value + "%' or LogonName like '%" + Value + "%' or OrgUnit like '%" + Value + "%'";
        }

        #endregion
    }
}