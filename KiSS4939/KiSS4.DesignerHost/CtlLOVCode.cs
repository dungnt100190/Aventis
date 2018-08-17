using System;
using System.ComponentModel;
using System.Drawing;

using KiSS.DBScheme;

using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.XtraGrid.Columns;

namespace KiSS4.DesignerHost
{
    /// <summary>
    /// Summary description for CtlLOVCode.
    /// </summary>
    public class CtlLOVCode : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        private int _currentLanguageCode = Session.User.LanguageCode;
        private string _deleteQuestionOriginal = string.Empty;
        private bool _isSystemLOV = true;
        private string _lovName = string.Empty;
        private KissCheckEdit chkLock;
        private DevExpress.XtraGrid.Columns.GridColumn colBFSCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colShortText;
        private DevExpress.XtraGrid.Columns.GridColumn colSortkey;
        private DevExpress.XtraGrid.Columns.GridColumn colSystem;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colTransShortText;
        private DevExpress.XtraGrid.Columns.GridColumn colTransValue1;
        private DevExpress.XtraGrid.Columns.GridColumn colTransValue2;
        private DevExpress.XtraGrid.Columns.GridColumn colTransValue3;
        private DevExpress.XtraGrid.Columns.GridColumn colTranslation;
        private DevExpress.XtraGrid.Columns.GridColumn colValue1;
        private DevExpress.XtraGrid.Columns.GridColumn colValue2;
        private DevExpress.XtraGrid.Columns.GridColumn colValue3;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtSearchText;
        private KiSS4.Gui.KissGrid grdLOVCode;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLOVCode;
        private KissLabel lblCount;
        private KiSS4.Gui.KissLabel lblSearchText;
        private KiSS4.DB.SqlQuery qryXLOV;
        private KiSS4.DB.SqlQuery qryXLOVCode;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlLOVCode"/> class.
        /// </summary>
        /// <param name="lovName">The name of the lov to use for editing</param>
        public CtlLOVCode(string lovName)
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // apply fields
            this._lovName = lovName;

            // lock is always checked first
            chkLock.Checked = true;

            // fill data
            FillDataSources();

            // setup control depending on rights
            SetupRights();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlLOVCode));
            this.qryXLOVCode = new KiSS4.DB.SqlQuery(this.components);
            this.grdLOVCode = new KiSS4.Gui.KissGrid();
            this.grvLOVCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTranslation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSortkey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShortText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransShortText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBFSCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransValue1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransValue2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransValue3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qryXLOV = new KiSS4.DB.SqlQuery(this.components);
            this.lblSearchText = new KiSS4.Gui.KissLabel();
            this.edtSearchText = new KiSS4.Gui.KissTextEdit();
            this.lblCount = new KiSS4.Gui.KissLabel();
            this.chkLock = new KiSS4.Gui.KissCheckEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryXLOVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLOVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLOVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXLOV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLock.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(776, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(800, 500);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdLOVCode);
            this.tpgListe.Size = new System.Drawing.Size(788, 462);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblSearchText);
            this.tpgSuchen.Controls.Add(this.edtSearchText);
            this.tpgSuchen.Size = new System.Drawing.Size(788, 462);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchText, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchText, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            // 
            // qryXLOVCode
            // 
            this.qryXLOVCode.HostControl = this;
            this.qryXLOVCode.SelectStatement = resources.GetString("qryXLOVCode.SelectStatement");
            this.qryXLOVCode.TableName = "XLOVCode";
            this.qryXLOVCode.AfterFill += new System.EventHandler(this.qryXLOVCode_AfterFill);
            this.qryXLOVCode.AfterInsert += new System.EventHandler(this.qryXLOVCode_AfterInsert);
            this.qryXLOVCode.BeforePost += new System.EventHandler(this.qryXLOVCode_BeforePost);
            this.qryXLOVCode.AfterPost += new System.EventHandler(this.qryXLOVCode_AfterPost);
            this.qryXLOVCode.BeforeDeleteQuestion += new System.EventHandler(this.qryXLOVCode_BeforeDeleteQuestion);
            // 
            // grdLOVCode
            // 
            this.grdLOVCode.DataSource = this.qryXLOVCode;
            this.grdLOVCode.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdLOVCode.EmbeddedNavigator.Name = "";
            this.grdLOVCode.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdLOVCode.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdLOVCode.Location = new System.Drawing.Point(0, 0);
            this.grdLOVCode.MainView = this.grvLOVCode;
            this.grdLOVCode.Name = "grdLOVCode";
            this.grdLOVCode.Size = new System.Drawing.Size(788, 462);
            this.grdLOVCode.TabIndex = 5;
            this.grdLOVCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLOVCode});
            // 
            // grvLOVCode
            // 
            this.grvLOVCode.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvLOVCode.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLOVCode.Appearance.Empty.Options.UseBackColor = true;
            this.grvLOVCode.Appearance.Empty.Options.UseFont = true;
            this.grvLOVCode.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvLOVCode.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLOVCode.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvLOVCode.Appearance.EvenRow.Options.UseFont = true;
            this.grvLOVCode.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvLOVCode.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLOVCode.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvLOVCode.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvLOVCode.Appearance.FocusedCell.Options.UseFont = true;
            this.grvLOVCode.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvLOVCode.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvLOVCode.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLOVCode.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvLOVCode.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvLOVCode.Appearance.FocusedRow.Options.UseFont = true;
            this.grvLOVCode.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvLOVCode.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvLOVCode.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvLOVCode.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvLOVCode.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvLOVCode.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvLOVCode.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvLOVCode.Appearance.GroupRow.Options.UseFont = true;
            this.grvLOVCode.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvLOVCode.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvLOVCode.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvLOVCode.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvLOVCode.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvLOVCode.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvLOVCode.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvLOVCode.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvLOVCode.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLOVCode.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvLOVCode.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvLOVCode.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvLOVCode.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvLOVCode.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvLOVCode.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvLOVCode.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvLOVCode.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLOVCode.Appearance.OddRow.Options.UseBackColor = true;
            this.grvLOVCode.Appearance.OddRow.Options.UseFont = true;
            this.grvLOVCode.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvLOVCode.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLOVCode.Appearance.Row.Options.UseBackColor = true;
            this.grvLOVCode.Appearance.Row.Options.UseFont = true;
            this.grvLOVCode.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvLOVCode.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLOVCode.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvLOVCode.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvLOVCode.Appearance.SelectedRow.Options.UseFont = true;
            this.grvLOVCode.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvLOVCode.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvLOVCode.Appearance.VertLine.Options.UseBackColor = true;
            this.grvLOVCode.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvLOVCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colText,
            this.colTranslation,
            this.colSortkey,
            this.colShortText,
            this.colTransShortText,
            this.colBFSCode,
            this.colSystem,
            this.colValue1,
            this.colTransValue1,
            this.colValue2,
            this.colTransValue2,
            this.colValue3,
            this.colTransValue3,
            this.colDescription});
            this.grvLOVCode.GridControl = this.grdLOVCode;
            this.grvLOVCode.Name = "grvLOVCode";
            this.grvLOVCode.OptionsCustomization.AllowColumnMoving = false;
            this.grvLOVCode.OptionsCustomization.AllowFilter = false;
            this.grvLOVCode.OptionsCustomization.AllowGroup = false;
            this.grvLOVCode.OptionsFilter.AllowFilterEditor = false;
            this.grvLOVCode.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvLOVCode.OptionsMenu.EnableGroupPanelMenu = false;
            this.grvLOVCode.OptionsNavigation.AutoFocusNewRow = true;
            this.grvLOVCode.OptionsView.ColumnAutoWidth = false;
            this.grvLOVCode.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvLOVCode.OptionsView.ShowGroupPanel = false;
            this.grvLOVCode.ViewStyles.AddReplace("FocusedRow", "Row");
            this.grvLOVCode.ViewStyles.AddReplace("SelectedRow", "Row");
            this.grvLOVCode.ViewStyles.AddReplace("HideSelectionRow", "Row");
            this.grvLOVCode.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvLOVCode_CustomDrawCell);
            this.grvLOVCode.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvLOVCode_ShowingEditor);
            // 
            // colCode
            // 
            this.colCode.Caption = "Code";
            this.colCode.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 66;
            // 
            // colText
            // 
            this.colText.Caption = "Deutsch";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 1;
            this.colText.Width = 298;
            // 
            // colTranslation
            // 
            this.colTranslation.Caption = "Translation";
            this.colTranslation.FieldName = "Translation";
            this.colTranslation.Name = "colTranslation";
            this.colTranslation.Visible = true;
            this.colTranslation.VisibleIndex = 2;
            this.colTranslation.Width = 298;
            // 
            // colSortkey
            // 
            this.colSortkey.Caption = "Abfolge";
            this.colSortkey.FieldName = "SortKey";
            this.colSortkey.Name = "colSortkey";
            this.colSortkey.Visible = true;
            this.colSortkey.VisibleIndex = 3;
            this.colSortkey.Width = 56;
            // 
            // colShortText
            // 
            this.colShortText.Caption = "Kurztext";
            this.colShortText.FieldName = "ShortText";
            this.colShortText.Name = "colShortText";
            this.colShortText.Visible = true;
            this.colShortText.VisibleIndex = 4;
            this.colShortText.Width = 62;
            // 
            // colTransShortText
            // 
            this.colTransShortText.Caption = "TransShortText";
            this.colTransShortText.FieldName = "TransShortText";
            this.colTransShortText.Name = "colTransShortText";
            this.colTransShortText.Visible = true;
            this.colTransShortText.VisibleIndex = 5;
            // 
            // colBFSCode
            // 
            this.colBFSCode.Caption = "BFS Code";
            this.colBFSCode.FieldName = "BFSCode";
            this.colBFSCode.Name = "colBFSCode";
            this.colBFSCode.Visible = true;
            this.colBFSCode.VisibleIndex = 6;
            this.colBFSCode.Width = 68;
            // 
            // colSystem
            // 
            this.colSystem.Caption = "System";
            this.colSystem.FieldName = "System";
            this.colSystem.Name = "colSystem";
            this.colSystem.Visible = true;
            this.colSystem.VisibleIndex = 7;
            this.colSystem.Width = 57;
            // 
            // colValue1
            // 
            this.colValue1.Caption = "Wert 1";
            this.colValue1.FieldName = "Value1";
            this.colValue1.Name = "colValue1";
            this.colValue1.Visible = true;
            this.colValue1.VisibleIndex = 8;
            // 
            // colTransValue1
            // 
            this.colTransValue1.Caption = "TransValue1";
            this.colTransValue1.FieldName = "TransValue1";
            this.colTransValue1.Name = "colTransValue1";
            this.colTransValue1.Visible = true;
            this.colTransValue1.VisibleIndex = 9;
            // 
            // colValue2
            // 
            this.colValue2.Caption = "Wert 2";
            this.colValue2.FieldName = "Value2";
            this.colValue2.Name = "colValue2";
            this.colValue2.Visible = true;
            this.colValue2.VisibleIndex = 10;
            // 
            // colTransValue2
            // 
            this.colTransValue2.Caption = "TransValue2";
            this.colTransValue2.FieldName = "TransValue2";
            this.colTransValue2.Name = "colTransValue2";
            this.colTransValue2.Visible = true;
            this.colTransValue2.VisibleIndex = 11;
            // 
            // colValue3
            // 
            this.colValue3.Caption = "Wert 3";
            this.colValue3.FieldName = "Value3";
            this.colValue3.Name = "colValue3";
            this.colValue3.Visible = true;
            this.colValue3.VisibleIndex = 12;
            // 
            // colTransValue3
            // 
            this.colTransValue3.Caption = "TransValue3";
            this.colTransValue3.FieldName = "TransValue3";
            this.colTransValue3.Name = "colTransValue3";
            this.colTransValue3.Visible = true;
            this.colTransValue3.VisibleIndex = 13;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Beschreibung";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 14;
            this.colDescription.Width = 150;
            // 
            // qryXLOV
            // 
            this.qryXLOV.HostControl = this;
            this.qryXLOV.SelectStatement = "SELECT LOV.* \r\nFROM dbo.XLOV LOV WITH (READUNCOMMITTED)\r\nWHERE LOV.LOVName = {0}";
            this.qryXLOV.TableName = "XLOV";
            this.qryXLOV.AfterFill += new System.EventHandler(this.qryXLOV_AfterFill);
            // 
            // lblSearchText
            // 
            this.lblSearchText.Location = new System.Drawing.Point(31, 40);
            this.lblSearchText.Name = "lblSearchText";
            this.lblSearchText.Size = new System.Drawing.Size(100, 23);
            this.lblSearchText.TabIndex = 1;
            this.lblSearchText.Text = "Text";
            // 
            // edtSearchText
            // 
            this.edtSearchText.Location = new System.Drawing.Point(137, 40);
            this.edtSearchText.Name = "edtSearchText";
            this.edtSearchText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchText.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchText.Properties.Appearance.Options.UseFont = true;
            this.edtSearchText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchText.Size = new System.Drawing.Size(432, 24);
            this.edtSearchText.TabIndex = 2;
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCount.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblCount.Location = new System.Drawing.Point(554, 476);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(243, 24);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "Anzahl Einträge: <count>";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkLock
            // 
            this.chkLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLock.EditValue = true;
            this.chkLock.Location = new System.Drawing.Point(428, 478);
            this.chkLock.Name = "chkLock";
            this.chkLock.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkLock.Properties.Appearance.Options.UseBackColor = true;
            this.chkLock.Properties.Caption = "Schreibschutz";
            this.chkLock.Size = new System.Drawing.Size(120, 19);
            this.chkLock.TabIndex = 1;
            this.chkLock.CheckedChanged += new System.EventHandler(this.chkLock_CheckedChanged);
            // 
            // CtlLOVCode
            // 
            this.ActiveSQLQuery = this.qryXLOVCode;
            this.Controls.Add(this.chkLock);
            this.Controls.Add(this.lblCount);
            this.Name = "CtlLOVCode";
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.lblCount, 0);
            this.Controls.SetChildIndex(this.chkLock, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryXLOVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLOVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLOVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXLOV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLock.Properties)).EndInit();
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
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        private void chkLock_CheckedChanged(object sender, EventArgs e)
        {
            // reapply rights
            SetupRights();
        }

        private void grvLOVCode_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            // do the following code only if user is not biag-admin and can edit grid
            if (SpecialHandlingInEditGridRequired())
            {
                // get flag if entry is system entry
                bool systemEntry = Convert.ToBoolean(grvLOVCode.GetRowCellValue(e.RowHandle, colSystem));
                bool translationColumn = IsTranslationColumn(e.Column);

                // setup color (also handle AllowEdit as it was set in SetupRights())
                e.Appearance.BackColor = e.Column.OptionsColumn.AllowEdit && (translationColumn || !systemEntry) ? GuiConfig.GridEditable : GuiConfig.GridReadOnly;
            }
            else
            {
                // check if writeable
                if (grdLOVCode.GridStyle != GridStyleType.ReadOnly)
                {
                    // setup color depending on AllowEdit rights
                    e.Appearance.BackColor = !e.Column.OptionsColumn.AllowEdit ? GuiConfig.GridReadOnly : GuiConfig.GridEditable;
                }
            }
        }

        private void grvLOVCode_ShowingEditor(object sender, CancelEventArgs e)
        {
            // do the following code only if user is not biag-admin and can edit grid
            if (SpecialHandlingInEditGridRequired())
            {
                // get flag if entry is system entry
                bool systemEntry = Convert.ToBoolean(grvLOVCode.GetRowCellValue(grvLOVCode.FocusedRowHandle, colSystem.FieldName));
                bool translationColumn = IsTranslationColumn(grvLOVCode.FocusedColumn);

                // cancel edit if the current row is system entry and current column is not translation-column
                e.Cancel = systemEntry && !translationColumn;
            }
        }

        private void qryXLOVCode_AfterFill(object sender, EventArgs e)
        {
            // count LOV entries
            lblCount.Text = KissMsg.GetMLMessage("CtlLOVCode", "CountLOVEntries", "Anzahl Einträge: {0}", qryXLOVCode.Count);
        }

        private void qryXLOVCode_AfterInsert(object sender, System.EventArgs e)
        {
            // apply default values
            qryXLOVCode["LOVName"] = this._lovName;
            qryXLOVCode["XLOVID"] = qryXLOV[DBO.XLOV.XLOVID];
            qryXLOVCode["System"] = _isSystemLOV;

            // init grid
            grvLOVCode.FocusedColumn = grvLOVCode.Columns["Code"];
            grvLOVCode.ShowEditor();
            grdLOVCode.Focus();
        }

        private void qryXLOVCode_AfterPost(object sender, System.EventArgs e)
        {
            // clear cache to prevent wrong data
            Session.CacheManager.LOVQuery.Clear();

            // only needed if not default language
            if (qryXLOVCode.RowModified && Session.User.LanguageCode != 1)
            {
                TranslateColumn("Translation", "TextTID", 4);
                TranslateColumn("TransShortText", "ShortTextTID", 5);
                TranslateColumn("TransValue1", "Value1TID", 6);
                TranslateColumn("TransValue2", "Value2TID", 7);
                TranslateColumn("TransValue3", "Value3TID", 8);
            }
        }

        private void qryXLOVCode_BeforeDeleteQuestion(object sender, System.EventArgs e)
        {
            // get flag if system
            bool system = Convert.ToBoolean(qryXLOVCode["System"]);

            // check if entry is system-entry
            if (!Session.User.IsUserBIAGAdmin && (system || _isSystemLOV))
            {
                // system entries cannot be deleted for non BIAGAdmins
                throw new KissInfoException(KissMsg.GetMLMessage("CtlLOVCode", "LoeschenNichtMoeglichCodes", "System-Codes können nicht gelöscht werden!", KissMsgCode.MsgInfo));
            }

            // BIAGAdmin: confirm delete by special hint
            if (system)
            {
                qryXLOVCode.DeleteQuestion = KissMsg.GetMLMessage("CtlLOVCode", "ConfirmDeleteSystemLOVEntry_v02", "ACHTUNG: Der gewählte Eintrag ist ein Systemwert und hat möglicherweise noch Abhängigkeiten.\r\n\r\nSoll dieser Datensatz nun trotzdem gelöscht werden?");
            }
            else
            {
                // default original question
                qryXLOVCode.DeleteQuestion = _deleteQuestionOriginal;
            }
        }

        private void qryXLOVCode_BeforePost(object sender, System.EventArgs e)
        {
            // validate must fields
            DBUtil.CheckNotNullFieldInGrid(qryXLOVCode, "Code", KissMsg.GetMLMessage("FrmLOV", "Code", "Code"));
            DBUtil.CheckNotNullFieldInGrid(qryXLOVCode, "Text", KissMsg.GetMLMessage("FrmLOV", "Deutsch", "Deutsch"));
        }

        private void qryXLOV_AfterFill(object sender, EventArgs e)
        {
            // validate
            if (qryXLOV.Count != 1)
            {
                // no or too much data found, lock edit to other uses due to security reason
                _isSystemLOV = true;
            }
            else
            {
                // apply flag
                _isSystemLOV = Convert.ToBoolean(qryXLOV["System"]);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void Translate()
        {
            // let base do stuff
            base.Translate();

            // init flags
            bool isLOVTranslatable = Convert.ToBoolean(qryXLOV["Translatable"]);
            bool isNonGermanLanguage = Session.User.LanguageCode != 1;
            bool showTranslatableCols = isNonGermanLanguage && isLOVTranslatable;

            // setup columns
            this.colTranslation.Caption = DBUtil.GetLOVText("Sprache", Session.User.LanguageCode);
            // TODO: >> really change? this.colTransShortText.Caption = DBUtil.GetLOVText("Sprache", Session.User.LanguageCode);
            this.colValue1.Caption = DBUtil.IsEmpty(this.qryXLOV["NameValue1"]) ? this.colValue1.Caption : this.qryXLOV["NameValue1"] as string;
            this.colValue2.Caption = DBUtil.IsEmpty(this.qryXLOV["NameValue2"]) ? this.colValue2.Caption : this.qryXLOV["NameValue2"] as string;
            this.colValue3.Caption = DBUtil.IsEmpty(this.qryXLOV["NameValue3"]) ? this.colValue3.Caption : this.qryXLOV["NameValue3"] as string;

            // translation columns are only visible if not in default language
            colTranslation.Visible = isNonGermanLanguage;
            colTransShortText.Visible = isNonGermanLanguage;

            // value 1,2,3 are only visible if not in default language and translatable flag is set
            colTransValue1.Visible = showTranslatableCols;
            colTransValue2.Visible = showTranslatableCols;
            colTransValue3.Visible = showTranslatableCols;

            // apply confirm delete question (could be translated)
            _deleteQuestionOriginal = qryXLOVCode.DeleteQuestion;

            // check if need to reload data
            if (_currentLanguageCode != Session.User.LanguageCode)
            {
                // user has switched language while having control open > reload data
                NewSearch();
                tabControlSearch.SelectTab(tpgListe);
            }

            // apply current languagecode
            _currentLanguageCode = Session.User.LanguageCode;
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // set focus
            edtSearchText.Focus();
        }

        protected override void RunSearch()
        {
            // replace search parameters
            object[] parameters = new object[] { _lovName, Session.User.LanguageCode };
            this.kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void FillDataSources()
        {
            // fill data
            this.qryXLOV.Fill(qryXLOV.SelectStatement, _lovName);
            this.qryXLOVCode.Fill(qryXLOVCode.SelectStatement, _lovName, Session.User.LanguageCode);
        }

        /// <summary>
        /// Check if given column is a tranlation column and therefore has special handling
        /// </summary>
        /// <param name="col">The column to check</param>
        /// <returns><c>True</c> if column is a translation column, otherwise <c>False</c></returns>
        private bool IsTranslationColumn(GridColumn col)
        {
            return (col == colTranslation ||
                    col == colTransShortText ||
                    col == colTransValue1 ||
                    col == colTransValue2 ||
                    col == colTransValue3);
        }

        private void SetupColumn(bool isGridEditable, GridColumn col, bool canColumnBeEdited)
        {
            // setup editable mode
            col.OptionsColumn.AllowEdit = canColumnBeEdited;
            col.OptionsColumn.ReadOnly = !canColumnBeEdited;

            // setup colors (depending on flag and current gridstyle)
            if (isGridEditable)
            {
                // editable grid
                col.AppearanceCell.BackColor = (!canColumnBeEdited) || (!isGridEditable) ? GuiConfig.GridReadOnly : GuiConfig.GridEditable;
            }
            else
            {
                // locked grid
                col.AppearanceCell.BackColor = Color.Transparent;
            }
        }

        private void SetupRights()
        {
            // set admin flags
            bool isUserAdmin = Session.User.IsUserAdmin || DBUtil.UserHasRight("DSGBusinessDesignerAdmin");     // special right is like beeing admin
            bool isUserBIAGAdmin = Session.User.IsUserBIAGAdmin;

            // check rights
            if (!isUserBIAGAdmin && !isUserAdmin)
            {
                // no access to this control without admin privileges
                throw new Exception("Access to this control is denied. User has no administration privileges.");
            }

            // set more flags
            bool isLocked = chkLock.Checked;
            // --
            bool canModifyNonCritical = (isUserAdmin || isUserBIAGAdmin);
            bool canModifyCritical = ((isUserAdmin && !_isSystemLOV) || isUserBIAGAdmin);

            // can change only if: (user-is-admin and non-system-lov or user-is-biag-admin) and not writelocked
            bool allowChange = canModifyNonCritical && !isLocked;
            bool allowInsertDelete = allowChange && (!_isSystemLOV || isUserBIAGAdmin);     // insert/delete for system-LOVs can only be done by BIAGAdmin

            // setup locked-checkbox
            chkLock.EditMode = canModifyNonCritical ? EditModeType.Normal : EditModeType.ReadOnly;

            // setup query XLOV (always locked)
            qryXLOV.CanInsert = false;
            qryXLOV.CanUpdate = false;
            qryXLOV.CanDelete = false;

            // setup query XLOVCode
            qryXLOVCode.CanInsert = allowInsertDelete && Convert.ToBoolean(this.qryXLOV["Expandable"]);   // only if really expandable
            qryXLOVCode.CanUpdate = allowChange;
            qryXLOVCode.CanDelete = allowInsertDelete;

            // refresh controls
            qryXLOVCode.EnableBoundFields();

            // setup grid
            grdLOVCode.GridStyle = allowChange ? GridStyleType.Editable : GridStyleType.ReadOnly;

            // setup columns depending on rights
            SetupColumn(allowChange, colCode, canModifyCritical);
            SetupColumn(allowChange, colText, canModifyCritical);
            SetupColumn(allowChange, colTranslation, canModifyNonCritical);         // ML: can be changed even if system
            SetupColumn(allowChange, colSortkey, canModifyCritical);
            SetupColumn(allowChange, colShortText, canModifyCritical);
            SetupColumn(allowChange, colTransShortText, canModifyNonCritical);      // ML: can be changed even if system
            SetupColumn(allowChange, colBFSCode, canModifyCritical);
            SetupColumn(allowChange, colSystem, isUserBIAGAdmin && !_isSystemLOV);  // can only be changed if BIAGAdmin and non-system-LOVs (there: inherited from main-LOV-entry)
            SetupColumn(allowChange, colValue1, canModifyCritical);
            SetupColumn(allowChange, colTransValue1, canModifyNonCritical);         // ML: can be changed even if system
            SetupColumn(allowChange, colValue2, canModifyCritical);
            SetupColumn(allowChange, colTransValue2, canModifyNonCritical);         // ML: can be changed even if system
            SetupColumn(allowChange, colValue3, canModifyCritical);
            SetupColumn(allowChange, colTransValue3, canModifyNonCritical);         // ML: can be changed even if system
            SetupColumn(allowChange, colDescription, canModifyCritical);
        }

        private bool SpecialHandlingInEditGridRequired()
        {
            // return value depending on current settings
            return (!Session.User.IsUserBIAGAdmin && !_isSystemLOV && grdLOVCode.GridStyle != GridStyleType.ReadOnly);
        }

        private void TranslateColumn(string textColumName, string tidColumnName, int typeCode)
        {
            // can only translate other than german language
            if (Session.User.LanguageCode != 1)
            {
                // check if entry already has tid
                bool hasTID = !DBUtil.IsEmpty(qryXLOVCode[tidColumnName]);

                // start new transaction
                Session.BeginTransaction();

                try
                {
                    // update translation (apply TID if not yet defined and store translation for given language)
                    qryXLOVCode[tidColumnName] = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                        --SQLCHECK_IGNORE--
                        EXEC dbo.spXSetXLangText {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7} out
                        SELECT {7}",
                            qryXLOVCode[tidColumnName],
                            Session.User.LanguageCode,
                            qryXLOVCode[textColumName],
                            qryXLOVCode["LOVName"],
                            DBNull.Value,
                            typeCode,
                            qryXLOVCode["Code"],
                            -1));

                    // refresh query to prevent concurrency error if no tid was defined yet
                    if (!hasTID)
                    {
                        // get current timestamp from database
                        qryXLOVCode["XLOVCodeTS"] = DBUtil.ExecuteScalarSQLThrowingException(@"
                            SELECT LOV.XLOVCodeTS
                            FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
                            WHERE LOV.LOVName = {0}
                              AND LOV.Code = {1}", qryXLOVCode["LOVName"], qryXLOVCode["Code"]);
                    }

                    // do it
                    Session.Commit();
                }
                catch (Exception ex)
                {
                    // undo changes
                    Session.Rollback();

                    // show message
                    KissMsg.ShowError("CtlLOVCode", "ErrorTranslateColumn", "Es ist ein Fehler beim Speichern der Übersetzungen aufgetreten.", ex);
                }
            }
        }

        #endregion

        #endregion
    }
}