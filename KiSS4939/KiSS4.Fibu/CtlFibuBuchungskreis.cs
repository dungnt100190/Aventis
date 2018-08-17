using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Summary description for CtlFibuBuchungskreis.
    /// </summary>
    public class CtlFibuBuchungskreis : KiSS4.Gui.KissUserControl
    {
        private KiSS4.Gui.KissButton btnVerbuchen;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colHaben;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colSoll;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private System.ComponentModel.IContainer components;

        private KiSS4.Gui.KissDateEdit editBuchungsdatum;
        private KiSS4.Gui.KissLookUpEdit editBuchungskreis;
        private KiSS4.Gui.KissGrid grdFbBuchungskreis;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit grideditMandant;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFbBuchungskreis;
        private bool inCellValueChangedEvent = false;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.DB.SqlQuery qryFbBuchungskreis;
        private System.Windows.Forms.Timer timer1;

        public CtlFibuBuchungskreis()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFibuBuchungskreis));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryFbBuchungskreis = new KiSS4.DB.SqlQuery(this.components);
            this.grdFbBuchungskreis = new KiSS4.Gui.KissGrid();
            this.grvFbBuchungskreis = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grideditMandant = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colSoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.editBuchungskreis = new KiSS4.Gui.KissLookUpEdit();
            this.btnVerbuchen = new KiSS4.Gui.KissButton();
            this.editBuchungsdatum = new KiSS4.Gui.KissDateEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.qryFbBuchungskreis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbBuchungskreis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbBuchungskreis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBuchungskreis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBuchungskreis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBuchungsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            this.SuspendLayout();
            //
            // qryFbBuchungskreis
            //
            this.qryFbBuchungskreis.CanDelete = true;
            this.qryFbBuchungskreis.CanInsert = true;
            this.qryFbBuchungskreis.CanUpdate = true;
            this.qryFbBuchungskreis.HostControl = this;
            this.qryFbBuchungskreis.TableName = "FbBuchungskreis";
            this.qryFbBuchungskreis.BeforePost += new System.EventHandler(this.qryBuchungskreis_BeforePost);
            this.qryFbBuchungskreis.AfterInsert += new System.EventHandler(this.qryBuchungskreis_AfterInsert);
            this.qryFbBuchungskreis.BeforeInsert += new System.EventHandler(this.qryBuchungskreis_BeforeInsert);
            //
            // grdFbBuchungskreis
            //
            this.grdFbBuchungskreis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFbBuchungskreis.DataSource = this.qryFbBuchungskreis;
            this.grdFbBuchungskreis.EmbeddedNavigator.Name = "";
            this.grdFbBuchungskreis.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdFbBuchungskreis.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdFbBuchungskreis.Location = new System.Drawing.Point(10, 50);
            this.grdFbBuchungskreis.MainView = this.grvFbBuchungskreis;
            this.grdFbBuchungskreis.Name = "grdFbBuchungskreis";
            this.grdFbBuchungskreis.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.grideditMandant});
            this.grdFbBuchungskreis.Size = new System.Drawing.Size(805, 435);
            this.grdFbBuchungskreis.TabIndex = 0;
            this.grdFbBuchungskreis.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFbBuchungskreis});
            //
            // grvFbBuchungskreis
            //
            this.grvFbBuchungskreis.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFbBuchungskreis.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBuchungskreis.Appearance.Empty.Options.UseBackColor = true;
            this.grvFbBuchungskreis.Appearance.Empty.Options.UseFont = true;
            this.grvFbBuchungskreis.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvFbBuchungskreis.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBuchungskreis.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFbBuchungskreis.Appearance.EvenRow.Options.UseFont = true;
            this.grvFbBuchungskreis.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFbBuchungskreis.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBuchungskreis.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvFbBuchungskreis.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFbBuchungskreis.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFbBuchungskreis.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFbBuchungskreis.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFbBuchungskreis.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBuchungskreis.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFbBuchungskreis.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFbBuchungskreis.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFbBuchungskreis.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFbBuchungskreis.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbBuchungskreis.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFbBuchungskreis.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbBuchungskreis.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbBuchungskreis.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbBuchungskreis.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFbBuchungskreis.Appearance.GroupRow.Options.UseFont = true;
            this.grvFbBuchungskreis.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFbBuchungskreis.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFbBuchungskreis.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFbBuchungskreis.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbBuchungskreis.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFbBuchungskreis.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFbBuchungskreis.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFbBuchungskreis.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFbBuchungskreis.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBuchungskreis.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbBuchungskreis.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFbBuchungskreis.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFbBuchungskreis.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFbBuchungskreis.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvFbBuchungskreis.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFbBuchungskreis.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvFbBuchungskreis.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBuchungskreis.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFbBuchungskreis.Appearance.OddRow.Options.UseFont = true;
            this.grvFbBuchungskreis.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFbBuchungskreis.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBuchungskreis.Appearance.Row.Options.UseBackColor = true;
            this.grvFbBuchungskreis.Appearance.Row.Options.UseFont = true;
            this.grvFbBuchungskreis.Appearance.RowSeparator.BackColor = System.Drawing.Color.Firebrick;
            this.grvFbBuchungskreis.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvFbBuchungskreis.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFbBuchungskreis.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBuchungskreis.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFbBuchungskreis.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFbBuchungskreis.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFbBuchungskreis.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFbBuchungskreis.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvFbBuchungskreis.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFbBuchungskreis.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFbBuchungskreis.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMandant,
            this.colSoll,
            this.colHaben,
            this.colText,
            this.colBetrag,
            this.colStatus});
            this.grvFbBuchungskreis.GridControl = this.grdFbBuchungskreis;
            this.grvFbBuchungskreis.Name = "grvFbBuchungskreis";
            this.grvFbBuchungskreis.OptionsCustomization.AllowFilter = false;
            this.grvFbBuchungskreis.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFbBuchungskreis.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFbBuchungskreis.OptionsView.ColumnAutoWidth = false;
            this.grvFbBuchungskreis.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFbBuchungskreis.OptionsView.ShowGroupPanel = false;
            this.grvFbBuchungskreis.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            //
            // colMandant
            //
            this.colMandant.Caption = "Mandant";
            this.colMandant.ColumnEdit = this.grideditMandant;
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 0;
            this.colMandant.Width = 177;
            //
            // grideditMandant
            //
            this.grideditMandant.AutoHeight = false;
            this.grideditMandant.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.grideditMandant.Name = "grideditMandant";
            this.grideditMandant.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.grideditMandant_ButtonPressed);
            //
            // colSoll
            //
            this.colSoll.Caption = "Soll";
            this.colSoll.FieldName = "SollKtoNr";
            this.colSoll.Name = "colSoll";
            this.colSoll.Visible = true;
            this.colSoll.VisibleIndex = 1;
            this.colSoll.Width = 64;
            //
            // colHaben
            //
            this.colHaben.Caption = "Haben";
            this.colHaben.FieldName = "HabenKtoNr";
            this.colHaben.Name = "colHaben";
            this.colHaben.Visible = true;
            this.colHaben.VisibleIndex = 2;
            this.colHaben.Width = 68;
            //
            // colText
            //
            this.colText.Caption = "Text";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 3;
            this.colText.Width = 206;
            //
            // colBetrag
            //
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 4;
            this.colBetrag.Width = 90;
            //
            // colStatus
            //
            this.colStatus.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colStatus.AppearanceCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.colStatus.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.colStatus.AppearanceCell.Options.UseBackColor = true;
            this.colStatus.AppearanceCell.Options.UseFont = true;
            this.colStatus.AppearanceCell.Options.UseForeColor = true;
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.OptionsColumn.ReadOnly = true;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;
            this.colStatus.Width = 162;
            //
            // kissLabel1
            //
            this.kissLabel1.ForeColor = System.Drawing.Color.Black;
            this.kissLabel1.Location = new System.Drawing.Point(10, 15);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(100, 24);
            this.kissLabel1.TabIndex = 287;
            this.kissLabel1.Text = "Buchungskreis";
            //
            // editBuchungskreis
            //
            this.editBuchungskreis.Location = new System.Drawing.Point(105, 15);
            this.editBuchungskreis.LOVName = "FbBuchungskreis";
            this.editBuchungskreis.Name = "editBuchungskreis";
            this.editBuchungskreis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editBuchungskreis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editBuchungskreis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editBuchungskreis.Properties.Appearance.Options.UseBackColor = true;
            this.editBuchungskreis.Properties.Appearance.Options.UseBorderColor = true;
            this.editBuchungskreis.Properties.Appearance.Options.UseFont = true;
            this.editBuchungskreis.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editBuchungskreis.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editBuchungskreis.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editBuchungskreis.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editBuchungskreis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.editBuchungskreis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.editBuchungskreis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editBuchungskreis.Properties.NullText = "";
            this.editBuchungskreis.Properties.ShowFooter = false;
            this.editBuchungskreis.Properties.ShowHeader = false;
            this.editBuchungskreis.Properties.EditValueChanged += new System.EventHandler(this.kissLookUpEdit1_Properties_EditValueChanged);
            this.editBuchungskreis.Size = new System.Drawing.Size(255, 24);
            this.editBuchungskreis.TabIndex = 288;
            //
            // btnVerbuchen
            //
            this.btnVerbuchen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerbuchen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVerbuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerbuchen.Location = new System.Drawing.Point(650, 495);
            this.btnVerbuchen.Name = "btnVerbuchen";
            this.btnVerbuchen.Size = new System.Drawing.Size(165, 24);
            this.btnVerbuchen.TabIndex = 289;
            this.btnVerbuchen.Text = "Buchungskreis verbuchen";
            this.btnVerbuchen.UseVisualStyleBackColor = false;
            this.btnVerbuchen.Click += new System.EventHandler(this.btnVerbuchen_Click);
            //
            // editBuchungsdatum
            //
            this.editBuchungsdatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editBuchungsdatum.EditValue = new System.DateTime(2004, 4, 13, 0, 0, 0, 0);
            this.editBuchungsdatum.Location = new System.Drawing.Point(530, 497);
            this.editBuchungsdatum.Name = "editBuchungsdatum";
            this.editBuchungsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editBuchungsdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editBuchungsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editBuchungsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editBuchungsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.editBuchungsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.editBuchungsdatum.Properties.Appearance.Options.UseFont = true;
            this.editBuchungsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.editBuchungsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editBuchungsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.editBuchungsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editBuchungsdatum.Properties.ShowToday = false;
            this.editBuchungsdatum.Size = new System.Drawing.Size(100, 24);
            this.editBuchungsdatum.TabIndex = 290;
            //
            // kissLabel2
            //
            this.kissLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel2.ForeColor = System.Drawing.Color.Black;
            this.kissLabel2.Location = new System.Drawing.Point(420, 497);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(90, 24);
            this.kissLabel2.TabIndex = 291;
            this.kissLabel2.Text = "Buchungsdatum";
            //
            // timer1
            //
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            //
            // CtlFibuBuchungskreis
            //
            this.ActiveSQLQuery = this.qryFbBuchungskreis;
            this.AutoRefresh = false;
            this.Controls.Add(this.kissLabel2);
            this.Controls.Add(this.editBuchungsdatum);
            this.Controls.Add(this.btnVerbuchen);
            this.Controls.Add(this.editBuchungskreis);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.grdFbBuchungskreis);
            this.Name = "CtlFibuBuchungskreis";
            this.Size = new System.Drawing.Size(825, 535);
            this.Load += new System.EventHandler(this.ctlFibuBuchung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryFbBuchungskreis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbBuchungskreis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbBuchungskreis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBuchungskreis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBuchungskreis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBuchungsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private void btnVerbuchen_Click(object sender, System.EventArgs e)
        {
            if (!qryFbBuchungskreis.Post()) return;

            if (editBuchungsdatum.EditValue == null)
            {
                KissMsg.ShowInfo("CtlFibuBuchungskreis", "BuchungsdatumLeer", "Das Buchungsdatum darf nicht leer bleiben");
                editBuchungsdatum.Focus();
                return;
            }

            if (editBuchungsdatum.DateTime > DateTime.Today.AddDays(10) ||
                editBuchungsdatum.DateTime < DateTime.Today.AddDays(-10))
            {
                if (!KissMsg.ShowQuestion("FibuBuchungskreis", "BuchungsdatumAbweichung", "Das Buchungsdatum weicht um mehr als 10 Tage von heute ab.\r\n\r\nTrotzdem Verbuchen ?"))
                {
                    editBuchungsdatum.Focus();
                    return;
                }
            }

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            // validate each entry
            int ErrorCount = 0;
            SqlQuery qry;

            foreach (DataRow row in qryFbBuchungskreis.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Betrag"]) && ((Decimal)row["Betrag"]) != 0)
                {
                    qry = DBUtil.OpenSQL(@"
                         SELECT
                            PER.FbPeriodeID,
                            PER.PeriodeStatusCode,
                            Soll = KTOS.KontoNr,
                            Haben = KTOH.KontoNr
                         FROM FbPeriode PER
                            LEFT JOIN FbKonto KTOS ON KTOS.FbPeriodeID = PER.FbPeriodeID AND KTOS.KontoNr = {2}
                            LEFT JOIN FbKonto KTOH ON KTOH.FbPeriodeID = PER.FbPeriodeID AND KTOH.KontoNr = {3}
                         WHERE BaPersonID = {0}
                            AND {1} BETWEEN PeriodeVon AND PeriodeBis ",
                        row["BaPersonID"],
                        editBuchungsdatum.DateTime,
                        row["SollKtoNr"],
                        row["HabenKtoNr"]);

                    if (qry.Count == 0)
                    {
                        row["Status"] = "keine Periode";
                        row.AcceptChanges();
                        ErrorCount++;
                    }
                    else if (((int)qry["PeriodeStatusCode"]) == 2)
                    {
                        row["Status"] = "Periode inaktiv";
                        row.AcceptChanges();
                        ErrorCount++;
                    }
                    else if (((int)qry["PeriodeStatusCode"]) == 3)
                    {
                        row["Status"] = "Periode abgeschlossen";
                        row.AcceptChanges();
                        ErrorCount++;
                    }
                    else if (DBUtil.IsEmpty(qry["Soll"]))
                    {
                        row["Status"] = "Soll-Kto. ungültig";
                        row.AcceptChanges();
                        ErrorCount++;
                    }
                    else if (DBUtil.IsEmpty(qry["Haben"]))
                    {
                        row["Status"] = "Haben-Kto. ungültig";
                        row.AcceptChanges();
                        ErrorCount++;
                    }
                    else
                    {
                        row["Status"] = "";
                        row["FbPeriodeID"] = qry["FbPeriodeID"];
                        row.AcceptChanges();
                    }
                }
                else
                {
                    row["Status"] = "";
                    row.AcceptChanges();
                }
            }

            if (ErrorCount > 0)
            {
                Cursor.Current = currentCursor;
                KissMsg.ShowInfo("CtlFibuBuchungskreis", "FehlerValidierung", "Beim Validieren sind {0} Fehler aufgetreten!", 0, 0, ErrorCount.ToString());
                return;
            }

            // Verbuchen
            int VerbuchtCount = 0;
            foreach (DataRow row in qryFbBuchungskreis.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Betrag"]) && ((Decimal)row["Betrag"]) != 0)
                {
                    SqlQuery qry2 = DBUtil.OpenSQL("select top 1 Praefix,NaechsteBelegNr from FbBelegNr where BelegNrCode =  3");
                    if (qry2.Count == 0)
                    {
                        KissMsg.ShowInfo("CtlFibuBuchungskreis", "KeinEintragBelegnr", "Kein Eintrag für Buchungskreise in den Belegnummern gefunden!");
                        return;
                    }
                    string NextBelegNrText = qry2["Praefix"].ToString() + qry2["NaechsteBelegNr"].ToString();

                    VerbuchtCount += DBUtil.ExecSQL(@"
                        INSERT INTO dbo.FbBuchung (FbPeriodeID, BuchungTypCode, BelegNr, BelegNrPos, BuchungsDatum,
                                                   SollKtoNr, HabenKtoNr, Betrag, Text,
                                                   Creator, Modifier)
                        VALUES ({0}, 3, {1}, 0, {2},
                                {3}, {4}, {5}, dbo.fnFbGetBuchungstext({6}, {2}),
                                {7}, {7})",
                        row["FbPeriodeID"],
                        NextBelegNrText,
                        editBuchungsdatum.DateTime,
                        row["SollKtoNr"],
                        row["HabenKtoNr"],
                        row["Betrag"],
                        row["Text"],
                        DBUtil.GetDBRowCreatorModifier());

                    DBUtil.ExecSQL("UPDATE FbBelegNr SET NaechsteBelegNr = NaechsteBelegNr + 1 WHERE BelegNrCode = 3");
                }
            }
            Cursor.Current = currentCursor;
            KissMsg.ShowInfo("CtlFibuBuchungskreis", "EintraegeVerbucht", "{0} Einträge verbucht", 0, 0, VerbuchtCount.ToString());
        }

        private void ctlFibuBuchung_Load(object sender, System.EventArgs e)
        {
            editBuchungsdatum.DateTime = DateTime.Today;
        }

        private void grideditMandant_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            MandantSuchen(editor.EditValue.ToString(), true);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (inCellValueChangedEvent) return;

            if (e.Column.FieldName == "Mandant")
            {
                inCellValueChangedEvent = true;
                MandantSuchen(e.Value.ToString(), false);
                inCellValueChangedEvent = false;
            }
        }

        private void kissLookUpEdit1_Properties_EditValueChanged(object sender, System.EventArgs e)
        {
            qryFbBuchungskreis.Fill(
                "select BUK.*, " +
                "       Mandant = PRS.Name + isNull(', ' + PRS.Vorname,''), " +
                "       Status  = '', " +
                "       FbPeriodeID = 0 " +
                "from   FbBuchungskreis BUK " +
                "       inner join BaPerson PRS on PRS.BaPersonID = BUK.BaPersonID " +
                "where  FbBuchungskreisCode = {0} " +
                "order by Mandant, BUK.SollKtoNr",
                editBuchungskreis.EditValue);
        }

        private void MandantSuchen(string Suchbegriff, bool open)
        {
            if (Suchbegriff == "")
            {
                qryFbBuchungskreis["BaPersonID"] = DBNull.Value;
                qryFbBuchungskreis["Mandant"] = DBNull.Value;
                qryFbBuchungskreis.RefreshDisplay();
                return;
            }

            DlgAuswahl dlg = new DlgAuswahl();
            if (dlg.MandantSuchenB(Suchbegriff, open))
            {
                qryFbBuchungskreis["BaPersonID"] = dlg["BaPersonID"];

                grdFbBuchungskreis.View.SetRowCellValue(grdFbBuchungskreis.View.FocusedRowHandle,
                                                   grdFbBuchungskreis.View.Columns["Mandant"],
                                                   dlg["Mandant"].ToString());
            }
        }

        private void qryBuchungskreis_AfterInsert(object sender, System.EventArgs e)
        {
            qryFbBuchungskreis["FbBuchungskreisCode"] = editBuchungskreis.EditValue;
            grdFbBuchungskreis.View.FocusedColumn = grdFbBuchungskreis.View.Columns["Mandant"];
            timer1.Enabled = true;
        }

        private void qryBuchungskreis_BeforeInsert(object sender, System.EventArgs e)
        {
            if (editBuchungskreis.EditValue == null)
            {
                KissMsg.ShowInfo("CtlFibuBuchungskreis", "BuchungNichtErlaubt", "Einfügen einer neuen Buchung nicht erlaubt, da kein Buchungskreis ausgewählt ist!");
                throw new Exception();
            }
        }

        private void qryBuchungskreis_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullFieldInGrid(qryFbBuchungskreis, "BaPersonID", KissMsg.GetMLMessage("CtlFibuBuchungskreis", "Mandant", "Mandant"));
            DBUtil.CheckNotNullFieldInGrid(qryFbBuchungskreis, "SollKtoNr", KissMsg.GetMLMessage("CtlFibuBuchungskreis", "Soll", "Soll"));
            DBUtil.CheckNotNullFieldInGrid(qryFbBuchungskreis, "HabenKtoNr", KissMsg.GetMLMessage("CtlFibuBuchungskreis", "Haben", "Haben"));
            DBUtil.CheckNotNullFieldInGrid(qryFbBuchungskreis, "Text", KissMsg.GetMLMessage("CtlFibuBuchungskreis", "Text", "Text"));
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            grdFbBuchungskreis.View.ShowEditor();
            timer1.Enabled = false;
        }
    }
}