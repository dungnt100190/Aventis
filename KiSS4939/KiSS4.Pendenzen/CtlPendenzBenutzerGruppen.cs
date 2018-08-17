using System;
using System.Data;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Pendenzen
{
    public class CtlPendenzBenutzerGruppen : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnAddAll;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KissButton btnRunAutoTaskAssignement;
        private DevExpress.XtraGrid.Columns.GridColumn colBeschreibung;
        private DevExpress.XtraGrid.Columns.GridColumn colLogin;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNameVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenzengruppeID;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissMemoEdit edtBeschreibung;
        private KiSS4.Gui.KissTextEdit edtFilter;
        private KiSS4.Gui.KissTextEdit edtName;
        private KissTextEdit edtSucheBeschreibung;
        private KissTextEdit edtSucheName;
        private KiSS4.Gui.KissGrid grdUsergruppe;
        private KiSS4.Gui.KissGrid grdVerfuegbar;
        private KiSS4.Gui.KissGrid grdZugeteilt;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDokMeta;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZugeteilt;
        private KiSS4.Gui.KissLabel lblBeschreibung;
        private KiSS4.Gui.KissLabel lblFilter;
        private KiSS4.Gui.KissLabel lblName;
        private KissLabel lblSucheBeschreibung;
        private KissLabel lblSucheName;
        private Panel panDetails;
        private KiSS4.DB.SqlQuery qryFaPendenzgruppe;
        private KiSS4.DB.SqlQuery qryVerfuegbar;
        private KiSS4.DB.SqlQuery qryZugeteilt;

        #endregion

        #region Constructors

        public CtlPendenzBenutzerGruppen()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlPendenzBenutzerGruppen));
            this.grdUsergruppe = new KiSS4.Gui.KissGrid();
            this.qryFaPendenzgruppe = new KiSS4.DB.SqlQuery(this.components);
            this.grvDokMeta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPendenzengruppeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeschreibung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtBeschreibung = new KiSS4.Gui.KissMemoEdit();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.grdZugeteilt = new KiSS4.Gui.KissGrid();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.grvZugeteilt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNameVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblBeschreibung = new KiSS4.Gui.KissLabel();
            this.grdVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
            this.grvVerfuegbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblFilter = new KiSS4.Gui.KissLabel();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.edtSucheName = new KiSS4.Gui.KissTextEdit();
            this.edtSucheBeschreibung = new KiSS4.Gui.KissTextEdit();
            this.lblSucheBeschreibung = new KiSS4.Gui.KissLabel();
            this.panDetails = new System.Windows.Forms.Panel();
            this.btnRunAutoTaskAssignement = new KiSS4.Gui.KissButton();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsergruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaPendenzgruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDokMeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeschreibung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschreibung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBeschreibung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBeschreibung)).BeginInit();
            this.panDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(739, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(763, 248);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdUsergruppe);
            this.tpgListe.Size = new System.Drawing.Size(751, 210);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Controls.Add(this.lblSucheBeschreibung);
            this.tpgSuchen.Controls.Add(this.edtSucheBeschreibung);
            this.tpgSuchen.Controls.Add(this.edtSucheName);
            this.tpgSuchen.Size = new System.Drawing.Size(751, 210);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBeschreibung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBeschreibung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            // 
            // grdUsergruppe
            // 
            this.grdUsergruppe.DataSource = this.qryFaPendenzgruppe;
            this.grdUsergruppe.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdUsergruppe.EmbeddedNavigator.Name = "";
            this.grdUsergruppe.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdUsergruppe.Location = new System.Drawing.Point(0, 0);
            this.grdUsergruppe.MainView = this.grvDokMeta;
            this.grdUsergruppe.Name = "grdUsergruppe";
            this.grdUsergruppe.Size = new System.Drawing.Size(751, 210);
            this.grdUsergruppe.TabIndex = 0;
            this.grdUsergruppe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDokMeta});
            // 
            // qryFaPendenzgruppe
            // 
            this.qryFaPendenzgruppe.CanDelete = true;
            this.qryFaPendenzgruppe.CanInsert = true;
            this.qryFaPendenzgruppe.CanUpdate = true;
            this.qryFaPendenzgruppe.HostControl = this;
            this.qryFaPendenzgruppe.SelectStatement = resources.GetString("qryFaPendenzgruppe.SelectStatement");
            this.qryFaPendenzgruppe.TableName = "FaPendenzgruppe";
            this.qryFaPendenzgruppe.AfterInsert += new System.EventHandler(this.qryFaPendenzgruppe_AfterInsert);
            this.qryFaPendenzgruppe.BeforePost += new System.EventHandler(this.qryFaPendenzgruppe_BeforePost);
            this.qryFaPendenzgruppe.PositionChanged += new System.EventHandler(this.qryFaPendenzgruppe_PositionChanged);
            // 
            // grvDokMeta
            // 
            this.grvDokMeta.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDokMeta.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokMeta.Appearance.Empty.Options.UseBackColor = true;
            this.grvDokMeta.Appearance.Empty.Options.UseFont = true;
            this.grvDokMeta.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokMeta.Appearance.EvenRow.Options.UseFont = true;
            this.grvDokMeta.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDokMeta.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokMeta.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvDokMeta.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDokMeta.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDokMeta.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDokMeta.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDokMeta.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokMeta.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDokMeta.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDokMeta.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDokMeta.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDokMeta.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDokMeta.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDokMeta.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDokMeta.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDokMeta.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDokMeta.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDokMeta.Appearance.GroupRow.Options.UseFont = true;
            this.grvDokMeta.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDokMeta.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvDokMeta.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvDokMeta.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDokMeta.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDokMeta.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDokMeta.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDokMeta.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvDokMeta.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokMeta.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDokMeta.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDokMeta.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDokMeta.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDokMeta.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvDokMeta.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDokMeta.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokMeta.Appearance.OddRow.Options.UseFont = true;
            this.grvDokMeta.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDokMeta.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokMeta.Appearance.Row.Options.UseBackColor = true;
            this.grvDokMeta.Appearance.Row.Options.UseFont = true;
            this.grvDokMeta.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDokMeta.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDokMeta.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvDokMeta.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDokMeta.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvDokMeta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPendenzengruppeID,
            this.colName,
            this.colBeschreibung});
            this.grvDokMeta.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvDokMeta.GridControl = this.grdUsergruppe;
            this.grvDokMeta.Name = "grvDokMeta";
            this.grvDokMeta.OptionsBehavior.Editable = false;
            this.grvDokMeta.OptionsCustomization.AllowFilter = false;
            this.grvDokMeta.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvDokMeta.OptionsNavigation.AutoFocusNewRow = true;
            this.grvDokMeta.OptionsNavigation.UseTabKey = false;
            this.grvDokMeta.OptionsView.ColumnAutoWidth = false;
            this.grvDokMeta.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDokMeta.OptionsView.ShowGroupPanel = false;
            this.grvDokMeta.OptionsView.ShowIndicator = false;
            // 
            // colPendenzengruppeID
            // 
            this.colPendenzengruppeID.Caption = "ID";
            this.colPendenzengruppeID.FieldName = "FaPendenzgruppeID";
            this.colPendenzengruppeID.Name = "colPendenzengruppeID";
            this.colPendenzengruppeID.Visible = true;
            this.colPendenzengruppeID.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 245;
            // 
            // colBeschreibung
            // 
            this.colBeschreibung.Caption = "Beschreibung";
            this.colBeschreibung.FieldName = "Beschreibung";
            this.colBeschreibung.Name = "colBeschreibung";
            this.colBeschreibung.Visible = true;
            this.colBeschreibung.VisibleIndex = 2;
            this.colBeschreibung.Width = 457;
            // 
            // edtName
            // 
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryFaPendenzgruppe;
            this.edtName.Location = new System.Drawing.Point(105, 9);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(257, 24);
            this.edtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(9, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(78, 24);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            // 
            // edtBeschreibung
            // 
            this.edtBeschreibung.DataMember = "Beschreibung";
            this.edtBeschreibung.DataSource = this.qryFaPendenzgruppe;
            this.edtBeschreibung.Location = new System.Drawing.Point(105, 39);
            this.edtBeschreibung.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtBeschreibung.Name = "edtBeschreibung";
            this.edtBeschreibung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBeschreibung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeschreibung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeschreibung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeschreibung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeschreibung.Properties.Appearance.Options.UseFont = true;
            this.edtBeschreibung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBeschreibung.Size = new System.Drawing.Size(649, 62);
            this.edtBeschreibung.TabIndex = 3;
            // 
            // edtFilter
            // 
            this.edtFilter.Location = new System.Drawing.Point(71, 319);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter.Size = new System.Drawing.Size(285, 24);
            this.edtFilter.TabIndex = 6;
            this.edtFilter.EditValueChanged += new System.EventHandler(this.edtFilter_EditValueChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(369, 134);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(10, 30, 10, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(27, 24);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(369, 164);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(27, 24);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.IconID = 14;
            this.btnAddAll.Location = new System.Drawing.Point(369, 194);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(27, 24);
            this.btnAddAll.TabIndex = 9;
            this.btnAddAll.UseCompatibleTextRendering = true;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(369, 224);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(27, 24);
            this.btnRemoveAll.TabIndex = 10;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // grdZugeteilt
            // 
            this.grdZugeteilt.DataSource = this.qryZugeteilt;
            // 
            // 
            // 
            this.grdZugeteilt.EmbeddedNavigator.Name = "";
            this.grdZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZugeteilt.Location = new System.Drawing.Point(409, 107);
            this.grdZugeteilt.MainView = this.grvZugeteilt;
            this.grdZugeteilt.Name = "grdZugeteilt";
            this.grdZugeteilt.Size = new System.Drawing.Size(345, 236);
            this.grdZugeteilt.TabIndex = 11;
            this.grdZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZugeteilt});
            // 
            // qryZugeteilt
            // 
            this.qryZugeteilt.CanDelete = true;
            this.qryZugeteilt.CanInsert = true;
            this.qryZugeteilt.CanUpdate = true;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.SelectStatement = resources.GetString("qryZugeteilt.SelectStatement");
            this.qryZugeteilt.TableName = "FaPendenzgruppe_User";
            // 
            // grvZugeteilt
            // 
            this.grvZugeteilt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZugeteilt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Empty.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Empty.Options.UseFont = true;
            this.grvZugeteilt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.EvenRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZugeteilt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZugeteilt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugeteilt.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugeteilt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZugeteilt.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZugeteilt.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZugeteilt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZugeteilt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZugeteilt.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.OddRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZugeteilt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Row.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Row.Options.UseFont = true;
            this.grvZugeteilt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZugeteilt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZugeteilt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZugeteilt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNameVorname,
            this.colLogin});
            this.grvZugeteilt.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZugeteilt.GridControl = this.grdZugeteilt;
            this.grvZugeteilt.Name = "grvZugeteilt";
            this.grvZugeteilt.OptionsBehavior.Editable = false;
            this.grvZugeteilt.OptionsCustomization.AllowFilter = false;
            this.grvZugeteilt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZugeteilt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZugeteilt.OptionsNavigation.UseTabKey = false;
            this.grvZugeteilt.OptionsView.ColumnAutoWidth = false;
            this.grvZugeteilt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZugeteilt.OptionsView.ShowGroupPanel = false;
            this.grvZugeteilt.OptionsView.ShowIndicator = false;
            // 
            // colNameVorname
            // 
            this.colNameVorname.Caption = "Name Vorname";
            this.colNameVorname.FieldName = "NameVorname";
            this.colNameVorname.Name = "colNameVorname";
            this.colNameVorname.Visible = true;
            this.colNameVorname.VisibleIndex = 0;
            this.colNameVorname.Width = 212;
            // 
            // colLogin
            // 
            this.colLogin.Caption = "Login";
            this.colLogin.FieldName = "LogonName";
            this.colLogin.Name = "colLogin";
            this.colLogin.Visible = true;
            this.colLogin.VisibleIndex = 1;
            this.colLogin.Width = 114;
            // 
            // lblBeschreibung
            // 
            this.lblBeschreibung.Location = new System.Drawing.Point(10, 46);
            this.lblBeschreibung.Name = "lblBeschreibung";
            this.lblBeschreibung.Size = new System.Drawing.Size(78, 24);
            this.lblBeschreibung.TabIndex = 2;
            this.lblBeschreibung.Text = "Beschreibung";
            this.lblBeschreibung.UseCompatibleTextRendering = true;
            // 
            // grdVerfuegbar
            // 
            this.grdVerfuegbar.DataSource = this.qryVerfuegbar;
            // 
            // 
            // 
            this.grdVerfuegbar.EmbeddedNavigator.Name = "";
            this.grdVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVerfuegbar.Location = new System.Drawing.Point(11, 107);
            this.grdVerfuegbar.MainView = this.grvVerfuegbar;
            this.grdVerfuegbar.Name = "grdVerfuegbar";
            this.grdVerfuegbar.Size = new System.Drawing.Size(345, 206);
            this.grdVerfuegbar.TabIndex = 4;
            this.grdVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVerfuegbar});
            // 
            // qryVerfuegbar
            // 
            this.qryVerfuegbar.HostControl = this;
            this.qryVerfuegbar.SelectStatement = resources.GetString("qryVerfuegbar.SelectStatement");
            // 
            // grvVerfuegbar
            // 
            this.grvVerfuegbar.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVerfuegbar.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.Empty.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.Empty.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.EvenRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerfuegbar.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerfuegbar.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfuegbar.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfuegbar.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerfuegbar.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVerfuegbar.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVerfuegbar.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfuegbar.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.OddRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVerfuegbar.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.Row.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.Row.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfuegbar.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVerfuegbar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVerfuegbar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.grvVerfuegbar.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVerfuegbar.GridControl = this.grdVerfuegbar;
            this.grvVerfuegbar.Name = "grvVerfuegbar";
            this.grvVerfuegbar.OptionsBehavior.Editable = false;
            this.grvVerfuegbar.OptionsCustomization.AllowFilter = false;
            this.grvVerfuegbar.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVerfuegbar.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVerfuegbar.OptionsNavigation.UseTabKey = false;
            this.grvVerfuegbar.OptionsView.ColumnAutoWidth = false;
            this.grvVerfuegbar.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVerfuegbar.OptionsView.ShowGroupPanel = false;
            this.grvVerfuegbar.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kandidaten";
            this.gridColumn1.FieldName = "UserName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 326;
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(11, 319);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(54, 24);
            this.lblFilter.TabIndex = 5;
            this.lblFilter.Text = "Filter";
            this.lblFilter.UseCompatibleTextRendering = true;
            // 
            // lblSucheName
            // 
            this.lblSucheName.Location = new System.Drawing.Point(31, 40);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(98, 24);
            this.lblSucheName.TabIndex = 1;
            this.lblSucheName.Text = "Name";
            this.lblSucheName.UseCompatibleTextRendering = true;
            // 
            // edtSucheName
            // 
            this.edtSucheName.Location = new System.Drawing.Point(135, 40);
            this.edtSucheName.Name = "edtSucheName";
            this.edtSucheName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheName.Size = new System.Drawing.Size(257, 24);
            this.edtSucheName.TabIndex = 2;
            // 
            // edtSucheBeschreibung
            // 
            this.edtSucheBeschreibung.Location = new System.Drawing.Point(135, 70);
            this.edtSucheBeschreibung.Name = "edtSucheBeschreibung";
            this.edtSucheBeschreibung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBeschreibung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBeschreibung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBeschreibung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBeschreibung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBeschreibung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBeschreibung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBeschreibung.Size = new System.Drawing.Size(257, 24);
            this.edtSucheBeschreibung.TabIndex = 4;
            // 
            // lblSucheBeschreibung
            // 
            this.lblSucheBeschreibung.Location = new System.Drawing.Point(31, 70);
            this.lblSucheBeschreibung.Name = "lblSucheBeschreibung";
            this.lblSucheBeschreibung.Size = new System.Drawing.Size(98, 24);
            this.lblSucheBeschreibung.TabIndex = 3;
            this.lblSucheBeschreibung.Text = "Beschreibung";
            this.lblSucheBeschreibung.UseCompatibleTextRendering = true;
            // 
            // panDetails
            // 
            this.panDetails.Controls.Add(this.btnRunAutoTaskAssignement);
            this.panDetails.Controls.Add(this.lblName);
            this.panDetails.Controls.Add(this.lblFilter);
            this.panDetails.Controls.Add(this.edtName);
            this.panDetails.Controls.Add(this.grdVerfuegbar);
            this.panDetails.Controls.Add(this.edtBeschreibung);
            this.panDetails.Controls.Add(this.grdZugeteilt);
            this.panDetails.Controls.Add(this.lblBeschreibung);
            this.panDetails.Controls.Add(this.btnRemoveAll);
            this.panDetails.Controls.Add(this.edtFilter);
            this.panDetails.Controls.Add(this.btnAddAll);
            this.panDetails.Controls.Add(this.btnAdd);
            this.panDetails.Controls.Add(this.btnRemove);
            this.panDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetails.Location = new System.Drawing.Point(0, 248);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(763, 352);
            this.panDetails.TabIndex = 1;
            // 
            // btnRunAutoTaskAssignement
            // 
            this.btnRunAutoTaskAssignement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunAutoTaskAssignement.Location = new System.Drawing.Point(602, 9);
            this.btnRunAutoTaskAssignement.Name = "btnRunAutoTaskAssignement";
            this.btnRunAutoTaskAssignement.Size = new System.Drawing.Size(152, 24);
            this.btnRunAutoTaskAssignement.TabIndex = 12;
            this.btnRunAutoTaskAssignement.Text = "Auto. Pendenzen Job";
            this.btnRunAutoTaskAssignement.UseVisualStyleBackColor = false;
            this.btnRunAutoTaskAssignement.Visible = false;
            this.btnRunAutoTaskAssignement.Click += new System.EventHandler(this.btnRunAutoTaskAssignement_Click);
            // 
            // CtlPendenzBenutzerGruppen
            // 
            this.ActiveSQLQuery = this.qryFaPendenzgruppe;
            this.Controls.Add(this.panDetails);
            this.Name = "CtlPendenzBenutzerGruppen";
            this.Size = new System.Drawing.Size(763, 600);
            this.Load += new System.EventHandler(this.CtlTaskUserGroup_Load);
            this.Controls.SetChildIndex(this.panDetails, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUsergruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaPendenzgruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDokMeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeschreibung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschreibung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBeschreibung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBeschreibung)).EndInit();
            this.panDetails.ResumeLayout(false);
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

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // set focus to first search field
            this.edtName.Focus();
        }

        #endregion

        #region Private Methods

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (qryFaPendenzgruppe.Count == 0 || qryVerfuegbar.Count == 0)
            {
                return;
            }

            if (!qryFaPendenzgruppe.Post())
            {
                return;
            }

            qryZugeteilt.Insert();

            qryZugeteilt["UserID"] = qryVerfuegbar["UserID"];
            qryZugeteilt["FaPendenzgruppeID"] = qryFaPendenzgruppe["FaPendenzgruppeID"];

            qryZugeteilt.Post();

            this.DisplayMembers();
        }

        private void btnAddAll_Click(object sender, System.EventArgs e)
        {
            if (qryFaPendenzgruppe.Count == 0 || qryVerfuegbar.Count == 0)
            {
                return;
            }

            if (qryFaPendenzgruppe.Row.RowState == DataRowState.Added && !qryFaPendenzgruppe.Post())
            {
                return;
            }

            DBUtil.ExecSQL(@"
                    INSERT INTO FaPendenzgruppe_User (FaPendenzgruppeID, UserID)
                      SELECT {0}, UserID
                      FROM dbo.XUser USR WITH (READUNCOMMITTED)
                      WHERE NOT EXISTS (SELECT TOP 1 1
                                        FROM dbo.FAPendenzgruppe_User WITH (READUNCOMMITTED)
                                        WHERE FaPendenzgruppeID = {0} AND
                                              UserID = USR.UserID)", qryFaPendenzgruppe["FaPendenzgruppeID"]);

            this.DisplayMembers();
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            if (qryFaPendenzgruppe.Count == 0 || qryZugeteilt.Count == 0)
            {
                return;
            }

            qryZugeteilt.Delete();
            this.DisplayMembers();
        }

        private void btnRemoveAll_Click(object sender, System.EventArgs e)
        {
            if (qryFaPendenzgruppe.Count == 0 || qryZugeteilt.Count == 0)
            {
                return;
            }

            if (qryFaPendenzgruppe.Row.RowState == DataRowState.Added)
            {
                return;
            }

            DBUtil.ExecSQL(@"
                    DELETE FROM dbo.FaPendenzgruppe_User
                    WHERE FaPendenzgruppeID = {0}", qryFaPendenzgruppe["FaPendenzgruppeID"]);

            this.DisplayMembers();
        }

        // the stored procedure called here is usually called by a db job. this is solely for testing purposes.
        private void btnRunAutoTaskAssignement_Click(object sender, EventArgs e)
        {
            if (Session.User.IsUserAdmin || Session.User.IsUserBIAGAdmin)
            {
                DBUtil.ExecSQL(120, string.Format(@"EXEC dbo.spXTask_Create '{0}'", DBUtil.GetDBRowCreatorModifier()));
            }
            else
            {
                KissMsg.ShowInfo("CtlPendenzenBenutzerGruppen", "CannotRunDBJob", "Der Job um Pendenzen automatisch zu zu weisen kann nur mit Administratorenrechte ausgeführt werden.");
            }
        }

        private void CtlTaskUserGroup_Load(object sender, System.EventArgs e)
        {
            qryZugeteilt.DeleteQuestion = null;

            // start a new search
            this.NewSearch();
            this.tabControlSearch.SelectTab(tpgListe);

            if(Session.User.IsUserAdmin || Session.User.IsUserBIAGAdmin)
            {
                btnRunAutoTaskAssignement.Visible = true;
            }
        }

        private void DisplayMembers()
        {
            qryZugeteilt.Fill(qryFaPendenzgruppe["FaPendenzgruppeID"]);
            qryVerfuegbar.Fill(qryFaPendenzgruppe["FaPendenzgruppeID"]);
        }
        private void edtFilter_EditValueChanged(object sender, System.EventArgs e)
        {
            String Value = edtFilter.EditValue.ToString();
            qryVerfuegbar.DataTable.DefaultView.RowFilter = "UserName like '%" + Value + "%' ";
        }

        private void qryFaPendenzgruppe_AfterInsert(object sender, System.EventArgs e)
        {
            edtName.Focus();
        }

        private void qryFaPendenzgruppe_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtName, KissMsg.GetMLMessage("CtlTaskUserGroup", "Name", "Name"));
        }

        private void qryFaPendenzgruppe_PositionChanged(object sender, System.EventArgs e)
        {
            this.DisplayMembers();
        }
        #endregion

        
    }
}