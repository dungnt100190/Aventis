using System.Data;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Summary description for CtlFibuTeam.
    /// </summary>
    public class CtlFibuTeam : KiSS4.Gui.KissUserControl
    {
        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnRemove;
        private DevExpress.XtraGrid.Columns.GridColumn colDepot;
        private DevExpress.XtraGrid.Columns.GridColumn colFbTeamID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colStandard;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissGrid grdFbTeam;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit grideditUser;
        private KiSS4.Gui.KissGrid gridKandidaten;
        private KiSS4.Gui.KissGrid gridTeamMitglied;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFbTeam;
        private KiSS4.DB.SqlQuery qryFbTeam;
        private KiSS4.DB.SqlQuery qryKandidaten;
        private KiSS4.DB.SqlQuery qryTeamMitglied;

        public CtlFibuTeam()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>

        public override string GetContextName()
        {
            return "VmFibu";
        }

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.qryFbTeam = new KiSS4.DB.SqlQuery(this.components);
            this.grdFbTeam = new KiSS4.Gui.KissGrid();
            this.grvFbTeam = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFbTeamID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridTeamMitglied = new KiSS4.Gui.KissGrid();
            this.qryTeamMitglied = new KiSS4.DB.SqlQuery(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grideditUser = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colStandard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.gridKandidaten = new KiSS4.Gui.KissGrid();
            this.qryKandidaten = new KiSS4.DB.SqlQuery(this.components);
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeamMitglied)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTeamMitglied)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKandidaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKandidaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            //
            // qryFbTeam
            //
            this.qryFbTeam.CanDelete = true;
            this.qryFbTeam.CanInsert = true;
            this.qryFbTeam.CanUpdate = true;
            this.qryFbTeam.HostControl = this;
            this.qryFbTeam.TableName = "FbTeam";
            this.qryFbTeam.BeforePost += new System.EventHandler(this.qryTeam_BeforePost);
            this.qryFbTeam.PositionChanged += new System.EventHandler(this.qryTeam_PositionChanged);
            //
            // grdFbTeam
            //
            this.grdFbTeam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFbTeam.DataSource = this.qryFbTeam;
            this.grdFbTeam.EmbeddedNavigator.Name = "";
            this.grdFbTeam.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdFbTeam.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdFbTeam.Location = new System.Drawing.Point(5, 10);
            this.grdFbTeam.MainView = this.grvFbTeam;
            this.grdFbTeam.Name = "grdFbTeam";
            this.grdFbTeam.Size = new System.Drawing.Size(615, 209);
            this.grdFbTeam.TabIndex = 0;
            this.grdFbTeam.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFbTeam});
            //
            // grvFbTeam
            //
            this.grvFbTeam.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFbTeam.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbTeam.Appearance.Empty.Options.UseBackColor = true;
            this.grvFbTeam.Appearance.Empty.Options.UseFont = true;
            this.grvFbTeam.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvFbTeam.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbTeam.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFbTeam.Appearance.EvenRow.Options.UseFont = true;
            this.grvFbTeam.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFbTeam.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbTeam.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvFbTeam.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFbTeam.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFbTeam.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFbTeam.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFbTeam.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbTeam.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFbTeam.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFbTeam.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFbTeam.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFbTeam.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbTeam.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFbTeam.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbTeam.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbTeam.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbTeam.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFbTeam.Appearance.GroupRow.Options.UseFont = true;
            this.grvFbTeam.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFbTeam.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFbTeam.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFbTeam.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbTeam.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFbTeam.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFbTeam.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFbTeam.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFbTeam.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbTeam.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbTeam.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFbTeam.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFbTeam.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFbTeam.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvFbTeam.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFbTeam.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvFbTeam.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbTeam.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFbTeam.Appearance.OddRow.Options.UseFont = true;
            this.grvFbTeam.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFbTeam.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbTeam.Appearance.Row.Options.UseBackColor = true;
            this.grvFbTeam.Appearance.Row.Options.UseFont = true;
            this.grvFbTeam.Appearance.RowSeparator.BackColor = System.Drawing.Color.Firebrick;
            this.grvFbTeam.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvFbTeam.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFbTeam.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbTeam.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFbTeam.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFbTeam.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFbTeam.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFbTeam.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvFbTeam.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFbTeam.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFbTeam.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFbTeamID,
            this.colName});
            this.grvFbTeam.GridControl = this.grdFbTeam;
            this.grvFbTeam.Name = "grvFbTeam";
            this.grvFbTeam.OptionsCustomization.AllowFilter = false;
            this.grvFbTeam.OptionsFilter.AllowFilterEditor = false;
            this.grvFbTeam.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFbTeam.OptionsMenu.EnableColumnMenu = false;
            this.grvFbTeam.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFbTeam.OptionsView.ColumnAutoWidth = false;
            this.grvFbTeam.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFbTeam.OptionsView.ShowGroupPanel = false;
            //
            // colFbTeamID
            //
            this.colFbTeamID.AppearanceCell.Options.UseTextOptions = true;
            this.colFbTeamID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFbTeamID.Caption = "Team-Nr";
            this.colFbTeamID.FieldName = "FbTeamID";
            this.colFbTeamID.Name = "colFbTeamID";
            this.colFbTeamID.OptionsColumn.AllowEdit = false;
            this.colFbTeamID.OptionsColumn.ReadOnly = true;
            this.colFbTeamID.Visible = true;
            this.colFbTeamID.VisibleIndex = 0;
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 501;
            //
            // gridTeamMitglied
            //
            this.gridTeamMitglied.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gridTeamMitglied.DataSource = this.qryTeamMitglied;
            this.gridTeamMitglied.EmbeddedNavigator.Name = "";
            this.gridTeamMitglied.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.gridTeamMitglied.Location = new System.Drawing.Point(273, 235);
            this.gridTeamMitglied.MainView = this.gridView2;
            this.gridTeamMitglied.Name = "gridTeamMitglied";
            this.gridTeamMitglied.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.grideditUser});
            this.gridTeamMitglied.Size = new System.Drawing.Size(347, 175);
            this.gridTeamMitglied.TabIndex = 287;
            this.gridTeamMitglied.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            //
            // qryTeamMitglied
            //
            this.qryTeamMitglied.CanDelete = true;
            this.qryTeamMitglied.CanInsert = true;
            this.qryTeamMitglied.CanUpdate = true;
            this.qryTeamMitglied.HostControl = this;
            this.qryTeamMitglied.TableName = "FbTeamMitglied";
            this.qryTeamMitglied.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryTeamMitglied_ColumnChanged);
            //
            // gridView2
            //
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
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
            this.colStandard,
            this.colDepot});
            this.gridView2.GridControl = this.gridTeamMitglied;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsFilter.AllowFilterEditor = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            //
            // colUser
            //
            this.colUser.Caption = "Teammitglieder";
            this.colUser.ColumnEdit = this.grideditUser;
            this.colUser.FieldName = "MTName";
            this.colUser.Name = "colUser";
            this.colUser.OptionsColumn.AllowEdit = false;
            this.colUser.OptionsColumn.ReadOnly = true;
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 0;
            this.colUser.Width = 180;
            //
            // grideditUser
            //
            this.grideditUser.AutoHeight = false;
            this.grideditUser.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.grideditUser.Name = "grideditUser";
            //
            // colStandard
            //
            this.colStandard.Caption = "Standard";
            this.colStandard.FieldName = "StandardBereich";
            this.colStandard.Name = "colStandard";
            this.colStandard.Visible = true;
            this.colStandard.VisibleIndex = 1;
            this.colStandard.Width = 65;
            //
            // colDepot
            //
            this.colDepot.Caption = "Depot";
            this.colDepot.FieldName = "DepotBereich";
            this.colDepot.Name = "colDepot";
            this.colDepot.Visible = true;
            this.colDepot.VisibleIndex = 2;
            this.colDepot.Width = 65;
            //
            // btnAdd
            //
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(228, 290);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 291;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnRemove
            //
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(228, 320);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 290;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            //
            // gridKandidaten
            //
            this.gridKandidaten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gridKandidaten.DataSource = this.qryKandidaten;
            this.gridKandidaten.EmbeddedNavigator.Name = "";
            this.gridKandidaten.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridKandidaten.Location = new System.Drawing.Point(5, 235);
            this.gridKandidaten.MainView = this.gridView3;
            this.gridKandidaten.Name = "gridKandidaten";
            this.gridKandidaten.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.grideditUser});
            this.gridKandidaten.Size = new System.Drawing.Size(205, 175);
            this.gridKandidaten.TabIndex = 292;
            this.gridKandidaten.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            this.gridKandidaten.DoubleClick += new System.EventHandler(this.gridKandidaten_DoubleClick);
            this.gridKandidaten.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridKandidaten_KeyPress);
            //
            // qryKandidaten
            //
            this.qryKandidaten.HostControl = this;
            //
            // gridView3
            //
            this.gridView3.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView3.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.Empty.Options.UseBackColor = true;
            this.gridView3.Appearance.Empty.Options.UseFont = true;
            this.gridView3.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView3.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView3.Appearance.EvenRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView3.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView3.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView3.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView3.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView3.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.Options.UseFont = true;
            this.gridView3.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView3.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView3.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView3.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView3.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView3.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView3.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView3.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridView3.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView3.Appearance.OddRow.Options.UseFont = true;
            this.gridView3.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView3.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.Row.Options.UseBackColor = true;
            this.gridView3.Appearance.Row.Options.UseFont = true;
            this.gridView3.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView3.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView3.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView3.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView3.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView3.GridControl = this.gridKandidaten;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsCustomization.AllowFilter = false;
            this.gridView3.OptionsFilter.AllowFilterEditor = false;
            this.gridView3.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView3.OptionsMenu.EnableColumnMenu = false;
            this.gridView3.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView3.OptionsNavigation.UseTabKey = false;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            //
            // gridColumn1
            //
            this.gridColumn1.Caption = "Kandidaten";
            this.gridColumn1.ColumnEdit = this.grideditUser;
            this.gridColumn1.FieldName = "MTName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 180;
            //
            // CtlFibuTeam
            //
            this.ActiveSQLQuery = this.qryFbTeam;
            this.AutoRefresh = false;

            this.Controls.Add(this.gridKandidaten);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.gridTeamMitglied);
            this.Controls.Add(this.grdFbTeam);
            this.Name = "CtlFibuTeam";
            this.Size = new System.Drawing.Size(825, 535);
            this.Load += new System.EventHandler(this.ctlFibuBuchung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryFbTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeamMitglied)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTeamMitglied)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKandidaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKandidaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (qryFbTeam.Count == 0 || qryKandidaten.Count == 0) return;
            if (qryFbTeam.Row.RowState == DataRowState.Added && !qryFbTeam.Post()) return;

            qryTeamMitglied.Insert();
            qryTeamMitglied["FbTeamID"] = qryFbTeam["FbTeamID"];
            qryTeamMitglied["UserID"] = qryKandidaten["UserID"];
            qryTeamMitglied["StandardBereich"] = 0;
            qryTeamMitglied["DepotBereich"] = 0;
            qryTeamMitglied.Post();

            DisplayTeamMitglieder();
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            if (qryFbTeam.Count == 0 || qryTeamMitglied.Count == 0) return;
            if (qryFbTeam.Row.RowState == DataRowState.Added) return;

            qryTeamMitglied.Delete();
            DisplayTeamMitglieder();
        }

        private void ctlFibuBuchung_Load(object sender, System.EventArgs e)
        {
            qryFbTeam.Fill("select * from FbTeam order by Name");

            //only admins allowed to edit
            if (!Session.User.IsUserAdmin)
            {
                qryFbTeam.CanDelete = false;
                qryFbTeam.CanInsert = false;
                qryFbTeam.CanUpdate = false;
                grdFbTeam.GridStyle = GridStyleType.ReadOnly;
                gridTeamMitglied.GridStyle = GridStyleType.ReadOnly;
                btnAdd.Enabled = false;
                btnRemove.Enabled = false;
            }

            qryTeamMitglied.DeleteQuestion = null;
        }

        private void DisplayTeamMitglieder()
        {
            qryTeamMitglied.Fill(
                "select TMI.*, LastName + isNull(', ' + FirstName,'') MTName " +
                "from   FbTeamMitglied TMI " +
                "       inner join XUser USR on USR.UserID = TMI.UserID " +
                "where  TMI.FbTeamID = {0} " +
                "order by MTName", qryFbTeam["FbTeamID"]);

            qryKandidaten.Fill(
                "select USR.UserID, LastName + isNull(', ' + FirstName,'') MTName " +
                "from   XUser USR " +
                "       left join FbTeamMitglied TMI on TMI.UserID = USR.UserID and " +
                "                                       TMI.FbTeamID = {0} " +
                "where  TMI.UserID is null " +
                "order by MTName", qryFbTeam["FbTeamID"]);
        }

        private void gridKandidaten_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.btnAdd.Enabled) this.btnAdd.PerformClick();
        }

        private void gridKandidaten_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar < 'A' || e.KeyChar > 'z') return;

            for (int i = 0; i < qryKandidaten.Count; i++)
            {
                string UserName = qryKandidaten.DataTable.Rows[i]["MTName"].ToString();
                if (UserName.ToUpper().StartsWith(e.KeyChar.ToString().ToUpper()))
                {
                    qryKandidaten.Position = i;
                    e.Handled = true;
                    return;
                }
            }
        }

        private void qryTeam_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullFieldInGrid(qryFbTeam, "Name", colName.Caption);
            qryTeamMitglied.Post(); //save pending changes
        }

        private void qryTeam_PositionChanged(object sender, System.EventArgs e)
        {
            DisplayTeamMitglieder();
        }

        private void qryTeamMitglied_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            qryFbTeam.RowModified = true;
        }
    }
}