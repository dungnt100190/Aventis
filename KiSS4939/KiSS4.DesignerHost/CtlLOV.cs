using System;

using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.DesignerHost
{
    /// <summary>
    /// Summary description for CtlLOV.
    /// </summary>
    public class CtlLOV : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        private int? _modulID = null;
        private KissCheckEdit chkLock;
        private KissCheckEdit chkSearchExpandable;
        private KissCheckEdit chkSearchSystem;
        private KissCheckEdit chkSearchTranslatable;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colExpandable;
        private DevExpress.XtraGrid.Columns.GridColumn colLOVName;
        private DevExpress.XtraGrid.Columns.GridColumn colModulName;
        private DevExpress.XtraGrid.Columns.GridColumn colNameValue1;
        private DevExpress.XtraGrid.Columns.GridColumn colNameValue2;
        private DevExpress.XtraGrid.Columns.GridColumn colNameValue3;
        private DevExpress.XtraGrid.Columns.GridColumn colSystem;
        private DevExpress.XtraGrid.Columns.GridColumn colTranslatable;
        private System.ComponentModel.IContainer components;
        private KissTextEdit edtSearchDescription;
        private KiSS4.Gui.KissTextEdit edtSearchLOVName;
        private KissLookUpEdit edtSearchModulID;
        private KiSS4.Gui.KissGrid grdXLOV;
        private DevExpress.XtraGrid.Views.Grid.GridView grvXLOV;
        private KissLabel lblCount;
        private KissLabel lblSearchDescription;
        private KiSS4.Gui.KissLabel lblSearchLOVName;
        private KissLabel lblSearchModulID;
        private KiSS4.DB.SqlQuery qryXLOV;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlLOV"/> class.
        /// </summary>
        public CtlLOV()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // lock is always checked first
            chkLock.Checked = true;

            // setup control depending on rights
            SetupRights();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlLOV"/> class.
        /// </summary>
        /// <param name="modulID">The module id used for filtering</param>
        public CtlLOV(int modulID)
            : this()
        {
            // apply fields
            this._modulID = modulID;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlLOV));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryXLOV = new KiSS4.DB.SqlQuery(this.components);
            this.grdXLOV = new KiSS4.Gui.KissGrid();
            this.grvXLOV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLOVName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpandable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTranslatable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameValue1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameValue2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameValue3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModulName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSearchLOVName = new KiSS4.Gui.KissLabel();
            this.edtSearchLOVName = new KiSS4.Gui.KissTextEdit();
            this.chkSearchSystem = new KiSS4.Gui.KissCheckEdit();
            this.chkSearchExpandable = new KiSS4.Gui.KissCheckEdit();
            this.chkSearchTranslatable = new KiSS4.Gui.KissCheckEdit();
            this.edtSearchDescription = new KiSS4.Gui.KissTextEdit();
            this.lblSearchDescription = new KiSS4.Gui.KissLabel();
            this.lblSearchModulID = new KiSS4.Gui.KissLabel();
            this.edtSearchModulID = new KiSS4.Gui.KissLookUpEdit();
            this.lblCount = new KiSS4.Gui.KissLabel();
            this.chkLock = new KiSS4.Gui.KissCheckEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryXLOV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXLOV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXLOV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchLOVName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchLOVName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSearchSystem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSearchExpandable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSearchTranslatable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchModulID.Properties)).BeginInit();
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
            this.tpgListe.Controls.Add(this.grdXLOV);
            this.tpgListe.Size = new System.Drawing.Size(788, 462);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.lblSearchLOVName);
            this.tpgSuchen.Controls.Add(this.edtSearchModulID);
            this.tpgSuchen.Controls.Add(this.lblSearchDescription);
            this.tpgSuchen.Controls.Add(this.lblSearchModulID);
            this.tpgSuchen.Controls.Add(this.edtSearchLOVName);
            this.tpgSuchen.Controls.Add(this.chkSearchSystem);
            this.tpgSuchen.Controls.Add(this.edtSearchDescription);
            this.tpgSuchen.Controls.Add(this.chkSearchTranslatable);
            this.tpgSuchen.Controls.Add(this.chkSearchExpandable);
            this.tpgSuchen.Size = new System.Drawing.Size(788, 462);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.chkSearchExpandable, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSearchTranslatable, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchDescription, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSearchSystem, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchLOVName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchModulID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchDescription, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchModulID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchLOVName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            //
            // qryXLOV
            //
            this.qryXLOV.CanDelete = true;
            this.qryXLOV.CanInsert = true;
            this.qryXLOV.CanUpdate = true;
            this.qryXLOV.HostControl = this;
            this.qryXLOV.SelectStatement = resources.GetString("qryXLOV.SelectStatement");
            this.qryXLOV.TableName = "XLOV";
            this.qryXLOV.BeforeDelete += new System.EventHandler(this.qryXLOV_BeforeDelete);
            this.qryXLOV.BeforePost += new System.EventHandler(this.qryXLOV_BeforePost);
            this.qryXLOV.AfterFill += new System.EventHandler(this.qryXLOV_AfterFill);
            this.qryXLOV.AfterInsert += new System.EventHandler(this.qryXLOV_AfterInsert);
            this.qryXLOV.BeforeDeleteQuestion += new System.EventHandler(this.qryXLOV_BeforeDeleteQuestion);
            this.qryXLOV.AfterPost += new System.EventHandler(this.qryXLOV_AfterPost);
            this.qryXLOV.AfterDelete += new System.EventHandler(this.qryXLOV_AfterDelete);
            //
            // grdXLOV
            //
            this.grdXLOV.DataSource = this.qryXLOV;
            this.grdXLOV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdXLOV.EmbeddedNavigator.Name = "";
            this.grdXLOV.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdXLOV.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdXLOV.Location = new System.Drawing.Point(0, 0);
            this.grdXLOV.MainView = this.grvXLOV;
            this.grdXLOV.Name = "grdXLOV";
            this.grdXLOV.Size = new System.Drawing.Size(788, 462);
            this.grdXLOV.TabIndex = 0;
            this.grdXLOV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvXLOV});
            this.grdXLOV.DoubleClick += new System.EventHandler(this.grdXLOV_DoubleClick);
            //
            // grvXLOV
            //
            this.grvXLOV.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvXLOV.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXLOV.Appearance.Empty.Options.UseBackColor = true;
            this.grvXLOV.Appearance.Empty.Options.UseFont = true;
            this.grvXLOV.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvXLOV.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXLOV.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvXLOV.Appearance.EvenRow.Options.UseFont = true;
            this.grvXLOV.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvXLOV.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXLOV.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvXLOV.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvXLOV.Appearance.FocusedCell.Options.UseFont = true;
            this.grvXLOV.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvXLOV.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvXLOV.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXLOV.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvXLOV.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvXLOV.Appearance.FocusedRow.Options.UseFont = true;
            this.grvXLOV.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvXLOV.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXLOV.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvXLOV.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXLOV.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXLOV.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXLOV.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvXLOV.Appearance.GroupRow.Options.UseFont = true;
            this.grvXLOV.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvXLOV.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvXLOV.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvXLOV.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXLOV.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvXLOV.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvXLOV.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvXLOV.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvXLOV.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXLOV.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXLOV.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvXLOV.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvXLOV.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvXLOV.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvXLOV.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvXLOV.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvXLOV.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXLOV.Appearance.OddRow.Options.UseBackColor = true;
            this.grvXLOV.Appearance.OddRow.Options.UseFont = true;
            this.grvXLOV.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvXLOV.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXLOV.Appearance.Row.Options.UseBackColor = true;
            this.grvXLOV.Appearance.Row.Options.UseFont = true;
            this.grvXLOV.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvXLOV.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXLOV.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvXLOV.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvXLOV.Appearance.SelectedRow.Options.UseFont = true;
            this.grvXLOV.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvXLOV.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvXLOV.Appearance.VertLine.Options.UseBackColor = true;
            this.grvXLOV.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvXLOV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLOVName,
            this.colSystem,
            this.colExpandable,
            this.colTranslatable,
            this.colDescription,
            this.colNameValue1,
            this.colNameValue2,
            this.colNameValue3,
            this.colModulName});
            this.grvXLOV.GridControl = this.grdXLOV;
            this.grvXLOV.Name = "grvXLOV";
            this.grvXLOV.OptionsCustomization.AllowFilter = false;
            this.grvXLOV.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvXLOV.OptionsNavigation.AutoFocusNewRow = true;
            this.grvXLOV.OptionsView.ColumnAutoWidth = false;
            this.grvXLOV.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvXLOV.OptionsView.ShowGroupPanel = false;
            this.grvXLOV.ViewStyles.AddReplace("FocusedRow", "Row");
            this.grvXLOV.ViewStyles.AddReplace("HideSelectionRow", "Row");
            this.grvXLOV.ViewStyles.AddReplace("SelectedRow", "Row");
            //
            // colLOVName
            //
            this.colLOVName.Caption = "Werteliste";
            this.colLOVName.FieldName = "LOVName";
            this.colLOVName.Name = "colLOVName";
            this.colLOVName.Visible = true;
            this.colLOVName.VisibleIndex = 0;
            this.colLOVName.Width = 242;
            //
            // colSystem
            //
            this.colSystem.Caption = "Sys.";
            this.colSystem.FieldName = "System";
            this.colSystem.Name = "colSystem";
            this.colSystem.Visible = true;
            this.colSystem.VisibleIndex = 1;
            this.colSystem.Width = 45;
            //
            // colExpandable
            //
            this.colExpandable.Caption = "Erw.";
            this.colExpandable.FieldName = "Expandable";
            this.colExpandable.Name = "colExpandable";
            this.colExpandable.Visible = true;
            this.colExpandable.VisibleIndex = 2;
            this.colExpandable.Width = 48;
            //
            // colTranslatable
            //
            this.colTranslatable.Caption = "Übers.";
            this.colTranslatable.FieldName = "Translatable";
            this.colTranslatable.Name = "colTranslatable";
            this.colTranslatable.Visible = true;
            this.colTranslatable.VisibleIndex = 3;
            this.colTranslatable.Width = 48;
            //
            // colDescription
            //
            this.colDescription.Caption = "Beschreibung";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            this.colDescription.Width = 320;
            //
            // colNameValue1
            //
            this.colNameValue1.Caption = "Name Wert 1";
            this.colNameValue1.FieldName = "NameValue1";
            this.colNameValue1.Name = "colNameValue1";
            this.colNameValue1.Visible = true;
            this.colNameValue1.VisibleIndex = 5;
            this.colNameValue1.Width = 100;
            //
            // colNameValue2
            //
            this.colNameValue2.Caption = "Name Wert 2";
            this.colNameValue2.FieldName = "NameValue2";
            this.colNameValue2.Name = "colNameValue2";
            this.colNameValue2.Visible = true;
            this.colNameValue2.VisibleIndex = 6;
            this.colNameValue2.Width = 100;
            //
            // colNameValue3
            //
            this.colNameValue3.Caption = "Name Wert 3";
            this.colNameValue3.FieldName = "NameValue3";
            this.colNameValue3.Name = "colNameValue3";
            this.colNameValue3.Visible = true;
            this.colNameValue3.VisibleIndex = 7;
            this.colNameValue3.Width = 100;
            //
            // colModulName
            //
            this.colModulName.Caption = "Modul";
            this.colModulName.FieldName = "ModulID";
            this.colModulName.Name = "colModulName";
            this.colModulName.Visible = true;
            this.colModulName.VisibleIndex = 8;
            this.colModulName.Width = 130;
            //
            // lblSearchLOVName
            //
            this.lblSearchLOVName.Location = new System.Drawing.Point(31, 40);
            this.lblSearchLOVName.Name = "lblSearchLOVName";
            this.lblSearchLOVName.Size = new System.Drawing.Size(100, 23);
            this.lblSearchLOVName.TabIndex = 1;
            this.lblSearchLOVName.Text = "Werteliste";
            //
            // edtSearchLOVName
            //
            this.edtSearchLOVName.Location = new System.Drawing.Point(137, 40);
            this.edtSearchLOVName.Name = "edtSearchLOVName";
            this.edtSearchLOVName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchLOVName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchLOVName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchLOVName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchLOVName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchLOVName.Properties.Appearance.Options.UseFont = true;
            this.edtSearchLOVName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchLOVName.Size = new System.Drawing.Size(368, 24);
            this.edtSearchLOVName.TabIndex = 2;
            //
            // chkSearchSystem
            //
            this.chkSearchSystem.EditValue = false;
            this.chkSearchSystem.Location = new System.Drawing.Point(137, 133);
            this.chkSearchSystem.Name = "chkSearchSystem";
            this.chkSearchSystem.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSearchSystem.Properties.Appearance.Options.UseBackColor = true;
            this.chkSearchSystem.Properties.Caption = "System";
            this.chkSearchSystem.Size = new System.Drawing.Size(122, 19);
            this.chkSearchSystem.TabIndex = 7;
            //
            // chkSearchExpandable
            //
            this.chkSearchExpandable.EditValue = false;
            this.chkSearchExpandable.Location = new System.Drawing.Point(137, 158);
            this.chkSearchExpandable.Name = "chkSearchExpandable";
            this.chkSearchExpandable.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSearchExpandable.Properties.Appearance.Options.UseBackColor = true;
            this.chkSearchExpandable.Properties.Caption = "Erweiterbar";
            this.chkSearchExpandable.Size = new System.Drawing.Size(122, 19);
            this.chkSearchExpandable.TabIndex = 8;
            //
            // chkSearchTranslatable
            //
            this.chkSearchTranslatable.EditValue = false;
            this.chkSearchTranslatable.Location = new System.Drawing.Point(137, 183);
            this.chkSearchTranslatable.Name = "chkSearchTranslatable";
            this.chkSearchTranslatable.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSearchTranslatable.Properties.Appearance.Options.UseBackColor = true;
            this.chkSearchTranslatable.Properties.Caption = "Übersetzbar";
            this.chkSearchTranslatable.Size = new System.Drawing.Size(122, 19);
            this.chkSearchTranslatable.TabIndex = 9;
            //
            // edtSearchDescription
            //
            this.edtSearchDescription.Location = new System.Drawing.Point(137, 70);
            this.edtSearchDescription.Name = "edtSearchDescription";
            this.edtSearchDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchDescription.Properties.Appearance.Options.UseFont = true;
            this.edtSearchDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchDescription.Size = new System.Drawing.Size(368, 24);
            this.edtSearchDescription.TabIndex = 4;
            //
            // lblSearchDescription
            //
            this.lblSearchDescription.Location = new System.Drawing.Point(31, 70);
            this.lblSearchDescription.Name = "lblSearchDescription";
            this.lblSearchDescription.Size = new System.Drawing.Size(100, 23);
            this.lblSearchDescription.TabIndex = 3;
            this.lblSearchDescription.Text = "Beschreibung";
            //
            // lblSearchModulID
            //
            this.lblSearchModulID.Location = new System.Drawing.Point(31, 100);
            this.lblSearchModulID.Name = "lblSearchModulID";
            this.lblSearchModulID.Size = new System.Drawing.Size(100, 23);
            this.lblSearchModulID.TabIndex = 5;
            this.lblSearchModulID.Text = "Modul";
            //
            // edtSearchModulID
            //
            this.edtSearchModulID.Location = new System.Drawing.Point(137, 100);
            this.edtSearchModulID.Name = "edtSearchModulID";
            this.edtSearchModulID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchModulID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchModulID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchModulID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchModulID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchModulID.Properties.Appearance.Options.UseFont = true;
            this.edtSearchModulID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSearchModulID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchModulID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSearchModulID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSearchModulID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSearchModulID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSearchModulID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchModulID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtSearchModulID.Properties.DisplayMember = "Text";
            this.edtSearchModulID.Properties.NullText = "";
            this.edtSearchModulID.Properties.ShowFooter = false;
            this.edtSearchModulID.Properties.ShowHeader = false;
            this.edtSearchModulID.Properties.ValueMember = "Code";
            this.edtSearchModulID.Size = new System.Drawing.Size(368, 24);
            this.edtSearchModulID.TabIndex = 6;
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
            this.lblCount.Text = "Anzahl Wertelisten: <count>";
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
            // CtlLOV
            //
            this.ActiveSQLQuery = this.qryXLOV;
            this.Controls.Add(this.chkLock);
            this.Controls.Add(this.lblCount);
            this.Name = "CtlLOV";
            this.Load += new System.EventHandler(this.CtlLOV_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.lblCount, 0);
            this.Controls.SetChildIndex(this.chkLock, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryXLOV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXLOV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXLOV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchLOVName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchLOVName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSearchSystem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSearchExpandable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSearchTranslatable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchModulID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchModulID)).EndInit();
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

        #region Properties

        /// <summary>
        /// Get the current set modulid (if any is given)
        /// </summary>
        private int CurrentModulID
        {
            get
            {
                // check if we have any modulid
                if (!this.IsModulIDSet)
                {
                    throw new NullReferenceException("There is no ModulID given, cannot get value.");
                }

                // convert and return
                return _modulID.Value;
            }
        }

        /// <summary>
        /// Get flag if ModulID is set
        /// </summary>
        private bool IsModulIDSet
        {
            get { return this._modulID.HasValue; }
        }

        #endregion

        #region EventHandlers

        private void CtlLOV_Load(object sender, EventArgs e)
        {
            // load dropdown for modul-name-search
            this.InitModulDropdown();

            // start with new search
            this.NewSearch();

            // run search to show data for given parameters
            this.tabControlSearch.SelectTab(this.tpgListe);
        }

        private void chkLock_CheckedChanged(object sender, EventArgs e)
        {
            // reapply rights
            SetupRights();
        }

        private void grdXLOV_DoubleClick(object sender, EventArgs e)
        {
            // show designer of current selected lov (only if successfully saved)
            if (!DBUtil.IsEmpty(qryXLOV["LOVName"]) && qryXLOV.Post())
            {
                FormController.SendMessage("FrmDesigner", "Action", "OpenChildLOV",
                                                          "LOVName", Convert.ToString(qryXLOV["LOVName"]));
            }
        }

        private void qryXLOV_AfterDelete(object sender, System.EventArgs e)
        {
            // refresh tree to apply changes
            FormController.SendMessage("FrmDesigner", "Action", "RefreshTree");
        }

        private void qryXLOV_AfterFill(object sender, EventArgs e)
        {
            // count LOVs
            lblCount.Text = KissMsg.GetMLMessage("CtlLOV", "CountLOVs", "Anzahl Wertelisten: {0}", qryXLOV.Count);
        }

        private void qryXLOV_AfterInsert(object sender, System.EventArgs e)
        {
            // set default values
            qryXLOV["ModulID"] = this._modulID;
            qryXLOV["Expandable"] = true;       // by default, LOV can be expanded by new values
            qryXLOV["Translatable"] = false;    // by default, user cannot translate Value1-3
            qryXLOV["System"] = true;           // by default, new LOVs are system-LOVs and therefore cannot be changed by user

            // setup grid
            grdXLOV.Focus();
            grvXLOV.FocusedColumn = grvXLOV.Columns["LOVName"];
            grvXLOV.ShowEditor();
        }

        private void qryXLOV_AfterPost(object sender, System.EventArgs e)
        {
            // clear cache to prevent wrong data
            Session.CacheManager.LOVQuery.Clear();

            // refresh tree to apply changes
            FormController.SendMessage("FrmDesigner", "Action", "RefreshTree");
        }

        private void qryXLOV_BeforeDelete(object sender, System.EventArgs e)
        {
            // remove all lov-codes for current lov
            DBUtil.ExecSQL("DELETE FROM dbo.XLOVCode WHERE LOVName = {0}", qryXLOV["LOVName"]);
        }

        private void qryXLOV_BeforeDeleteQuestion(object sender, System.EventArgs e)
        {
            // check if current lov is system lov
            if (Convert.ToBoolean(qryXLOV["System"]))
            {
                // system lovs cannot be deleted
                throw new KissInfoException(KissMsg.GetMLMessage("CtlLOV", "LoeschenNichtMoeglichWerteliste", "System-Wertelisten können nicht gelöscht werden!", KissMsgCode.MsgInfo));
            }
        }

        private void qryXLOV_BeforePost(object sender, System.EventArgs e)
        {
            // validate must fields
            DBUtil.CheckNotNullFieldInGrid(qryXLOV, "LOVName", this.colLOVName.Caption);
        }

        #endregion

        #region Methods

        #region Protected Methods

        /// <summary>
        /// Initialize a new search
        /// </summary>
        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // set default search value for modul
            if (this.IsModulIDSet)
            {
                // set default search modulid
                edtSearchModulID.EditValue = this.CurrentModulID;

                // if any modulid is set, we cannot change value!
                edtSearchModulID.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                // we can select any modulid
                edtSearchModulID.EditMode = EditModeType.Normal;
            }

            // set focus
            this.edtSearchLOVName.Focus();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Fill the search dropdown for modul names
        /// </summary>
        private void InitModulDropdown()
        {
            // remove datasource to clear dropdown
            edtSearchModulID.DataSource = null;

            // fill combobox with states that are available
            SqlQuery qryModulNames = DBUtil.OpenSQL(@"
                        SELECT [Code] = NULL,
                               [Text] = ''
                        UNION
                        SELECT [Code] = MDL.ModulID,
                               [Text] = MDL.Name
                        FROM dbo.XModul MDL WITH (READUNCOMMITTED)
                        ORDER BY [Code]");

            // setup properties
            edtSearchModulID.Properties.DropDownRows = Math.Min(qryModulNames.Count, 7);
            edtSearchModulID.Properties.DataSource = qryModulNames;

            // setup column
            colModulName.ColumnEdit = grdXLOV.GetLOVLookUpEdit(qryModulNames);
        }

        /// <summary>
        /// Setup rights depending on current user. Only BIAGAdmin can change anything if not is locked.
        /// </summary>
        private void SetupRights()
        {
            // set flags
            bool isUserBIAGAdmin = Session.User.IsUserBIAGAdmin;
            bool isLocked = chkLock.Checked;

            // setup locked-checkbox
            chkLock.EditMode = isUserBIAGAdmin ? EditModeType.Normal : EditModeType.ReadOnly;

            // BIAGAdmin can change if not is locked
            bool allowChange = isUserBIAGAdmin && !isLocked;

            // setup flags on query
            qryXLOV.CanInsert = allowChange;
            qryXLOV.CanUpdate = allowChange;
            qryXLOV.CanDelete = allowChange;

            // setup grid
            grdXLOV.GridStyle = allowChange ? GridStyleType.Editable : GridStyleType.ReadOnly;

            // refresh controls
            qryXLOV.EnableBoundFields();
        }

        #endregion

        #endregion
    }
}