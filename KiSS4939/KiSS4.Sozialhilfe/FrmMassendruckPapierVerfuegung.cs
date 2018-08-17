using System;
using System.Data;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common;
using KiSS4.Common.Report;
using KiSS4.DB;

namespace KiSS4.Sozialhilfe
{
    [Obsolete]
    public class FrmMassendruckPapierVerfuegung : KiSS4.Gui.KissChildForm
    {
        private KiSS4.Gui.KissTabControlEx tabControlSearch;
        private SharpLibrary.WinControls.TabPageEx tpgListe;
        private System.Windows.Forms.Panel panel3;
        private SharpLibrary.WinControls.TabPageEx tpgSuchen;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissSearchTitel kissSearchTitel1;
        private KiSS4.Gui.KissGrid gridBelege;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private KiSS4.Gui.KissLabel lblMonatsbudget;
        private KiSS4.DB.SqlQuery qryBeleg;
        private KiSS4.Gui.KissButton btnMonatsbudget;
        private KiSS4.Gui.KissButtonEdit editSARX;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private KiSS4.Gui.KissCalcEdit editJahr;
        private KiSS4.Gui.KissComboBox editMonat;
        private KiSS4.Gui.KissButton btnMassendruck;
        private DevExpress.XtraGrid.Columns.GridColumn colSelPrint;
        private System.Windows.Forms.Label lblRowCount;
        private System.Windows.Forms.Label label1;
        private KiSS4.Gui.KissButton btnAbbruch;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLabel lblAktion;

        private bool abbruch = false;

        public FrmMassendruckPapierVerfuegung()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            tabControlSearch.SelectedTabIndex = 0;
            tabControlSearch.SelectedTabIndex = 1;
        }

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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tabControlSearch = new KiSS4.Gui.KissTabControlEx();
            this.tpgListe = new SharpLibrary.WinControls.TabPageEx();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridBelege = new KiSS4.Gui.KissGrid();
            this.qryBeleg = new KiSS4.DB.SqlQuery(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelPrint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.editMonat = new KiSS4.Gui.KissComboBox();
            this.editJahr = new KiSS4.Gui.KissCalcEdit();
            this.editSARX = new KiSS4.Gui.KissButtonEdit();
            this.kissSearchTitel1 = new KiSS4.Gui.KissSearchTitel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.btnMassendruck = new KiSS4.Gui.KissButton();
            this.lblMonatsbudget = new KiSS4.Gui.KissLabel();
            this.btnMonatsbudget = new KiSS4.Gui.KissButton();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAbbruch = new KiSS4.Gui.KissButton();
            this.lblAktion = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBelege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBeleg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editMonat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSARX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatsbudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktion)).BeginInit();
            this.SuspendLayout();
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Controls.Add(this.tpgListe);
            this.tabControlSearch.Controls.Add(this.tpgSuchen);
            this.tabControlSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControlSearch.Location = new System.Drawing.Point(4, 28);
            this.tabControlSearch.Name = "tabControlSearch";
            this.tabControlSearch.ShowFixedWidthTooltip = true;
            this.tabControlSearch.Size = new System.Drawing.Size(961, 454);
            this.tabControlSearch.TabIndex = 0;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe,
            this.tpgSuchen});
            this.tabControlSearch.TabsLineColor = System.Drawing.Color.Black;
            this.tabControlSearch.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabControlSearch.TabStop = false;
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.panel3);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Name = "tpgListe";
            this.tpgListe.Size = new System.Drawing.Size(949, 416);
            this.tpgListe.TabIndex = 1;
            this.tpgListe.Title = "Liste";
            //
            // panel3
            //
            this.panel3.Controls.Add(this.gridBelege);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(949, 416);
            this.panel3.TabIndex = 30;
            //
            // gridBelege
            //
            this.gridBelege.DataSource = this.qryBeleg;
            this.gridBelege.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.gridBelege.EmbeddedNavigator.Name = "";
            this.gridBelege.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.gridBelege.ImeMode = System.Windows.Forms.ImeMode.On;
            this.gridBelege.Location = new System.Drawing.Point(0, 0);
            this.gridBelege.MainView = this.gridView2;
            this.gridBelege.Name = "gridBelege";
            this.gridBelege.Size = new System.Drawing.Size(949, 416);
            this.gridBelege.TabIndex = 0;
            this.gridBelege.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            //
            // qryBeleg
            //
            this.qryBeleg.CanUpdate = true;
            this.qryBeleg.HostControl = this;
            this.qryBeleg.TableName = "BgBudget";
            this.qryBeleg.BeforePost += new System.EventHandler(this.qryBeleg_BeforePost);
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
            this.colSAR,
            this.colKlient,
            this.colMonatJahr,
            this.colText,
            this.colBetrag,
            this.colSelPrint});
            this.gridView2.GridControl = this.gridBelege;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowGroup = false;
            this.gridView2.OptionsFilter.AllowFilterEditor = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView2.OptionsPrint.AutoWidth = false;
            this.gridView2.OptionsPrint.UsePrintStyles = true;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowDetailButtons = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            //
            // colSAR
            //
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SAR";
            this.colSAR.Name = "colSAR";
            this.colSAR.OptionsColumn.AllowEdit = false;
            this.colSAR.OptionsColumn.ReadOnly = true;
            this.colSAR.Visible = true;
            this.colSAR.VisibleIndex = 0;
            this.colSAR.Width = 158;
            //
            // colKlient
            //
            this.colKlient.Caption = "Klient";
            this.colKlient.FieldName = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.OptionsColumn.AllowEdit = false;
            this.colKlient.OptionsColumn.ReadOnly = true;
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 1;
            this.colKlient.Width = 153;
            //
            // colMonatJahr
            //
            this.colMonatJahr.Caption = "Budget";
            this.colMonatJahr.FieldName = "BudgetMonat";
            this.colMonatJahr.Name = "colMonatJahr";
            this.colMonatJahr.OptionsColumn.AllowEdit = false;
            this.colMonatJahr.OptionsColumn.ReadOnly = true;
            this.colMonatJahr.Visible = true;
            this.colMonatJahr.VisibleIndex = 2;
            this.colMonatJahr.Width = 133;
            //
            // colText
            //
            this.colText.Caption = "Buchungstext";
            this.colText.FieldName = "Buchungstext";
            this.colText.Name = "colText";
            this.colText.OptionsColumn.AllowEdit = false;
            this.colText.OptionsColumn.ReadOnly = true;
            this.colText.Visible = true;
            this.colText.VisibleIndex = 3;
            this.colText.Width = 304;
            //
            // colBetrag
            //
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.OptionsColumn.ReadOnly = true;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 4;
            this.colBetrag.Width = 107;
            //
            // colSelPrint
            //
            this.colSelPrint.Caption = "Ausdruck";
            this.colSelPrint.FieldName = "SelPrint";
            this.colSelPrint.Name = "colSelPrint";
            this.colSelPrint.Visible = true;
            this.colSelPrint.VisibleIndex = 5;
            this.colSelPrint.Width = 65;
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.editMonat);
            this.tpgSuchen.Controls.Add(this.editJahr);
            this.tpgSuchen.Controls.Add(this.editSARX);
            this.tpgSuchen.Controls.Add(this.kissSearchTitel1);
            this.tpgSuchen.Controls.Add(this.kissLabel5);
            this.tpgSuchen.Controls.Add(this.kissLabel6);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Name = "tpgSuchen";
            this.tpgSuchen.Size = new System.Drawing.Size(949, 416);
            this.tpgSuchen.TabIndex = 2;
            this.tpgSuchen.Title = "Suchen";
            //
            // editMonat
            //
            this.editMonat.Location = new System.Drawing.Point(84, 76);
            this.editMonat.Name = "editMonat";
            this.editMonat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editMonat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editMonat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editMonat.Properties.Appearance.Options.UseBackColor = true;
            this.editMonat.Properties.Appearance.Options.UseBorderColor = true;
            this.editMonat.Properties.Appearance.Options.UseFont = true;
            this.editMonat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.editMonat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.editMonat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editMonat.Properties.Items.AddRange(new object[] {
            "",
            "Januar",
            "Februar",
            "März",
            "April",
            "Mai",
            "Juni",
            "Juli",
            "August",
            "September",
            "Oktober",
            "November",
            "Dezember"});
            this.editMonat.Size = new System.Drawing.Size(225, 24);
            this.editMonat.TabIndex = 1;
            //
            // editJahr
            //
            this.editJahr.Location = new System.Drawing.Point(84, 106);
            this.editJahr.Name = "editJahr";
            this.editJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editJahr.Properties.Appearance.Options.UseBackColor = true;
            this.editJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.editJahr.Properties.Appearance.Options.UseFont = true;
            this.editJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editJahr.Size = new System.Drawing.Size(57, 24);
            this.editJahr.TabIndex = 2;
            //
            // editSARX
            //
            this.editSARX.Location = new System.Drawing.Point(84, 46);
            this.editSARX.Name = "editSARX";
            this.editSARX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editSARX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editSARX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editSARX.Properties.Appearance.Options.UseBackColor = true;
            this.editSARX.Properties.Appearance.Options.UseBorderColor = true;
            this.editSARX.Properties.Appearance.Options.UseFont = true;
            this.editSARX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.editSARX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.editSARX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editSARX.Size = new System.Drawing.Size(225, 24);
            this.editSARX.TabIndex = 0;
            this.editSARX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editSARX_UserModifiedFld);
            //
            // kissSearchTitel1
            //
            this.kissSearchTitel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissSearchTitel1.Location = new System.Drawing.Point(17, 4);
            this.kissSearchTitel1.Name = "kissSearchTitel1";
            this.kissSearchTitel1.Size = new System.Drawing.Size(200, 24);
            this.kissSearchTitel1.TabIndex = 15;
            //
            // kissLabel5
            //
            this.kissLabel5.Location = new System.Drawing.Point(12, 106);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(66, 24);
            this.kissLabel5.TabIndex = 7;
            this.kissLabel5.Text = "Jahr";
            //
            // kissLabel6
            //
            this.kissLabel6.Location = new System.Drawing.Point(12, 76);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(66, 24);
            this.kissLabel6.TabIndex = 5;
            this.kissLabel6.Text = "Monat";
            //
            // kissLabel1
            //
            this.kissLabel1.Location = new System.Drawing.Point(12, 46);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(66, 24);
            this.kissLabel1.TabIndex = 0;
            this.kissLabel1.Text = "SAR";
            //
            // btnMassendruck
            //
            this.btnMassendruck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMassendruck.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMassendruck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMassendruck.Location = new System.Drawing.Point(871, 464);
            this.btnMassendruck.Name = "btnMassendruck";
            this.btnMassendruck.Size = new System.Drawing.Size(94, 24);
            this.btnMassendruck.TabIndex = 12;
            this.btnMassendruck.Text = "Massendruck";
            this.btnMassendruck.UseVisualStyleBackColor = false;
            this.btnMassendruck.Click += new System.EventHandler(this.btnMassendruck_Click);
            //
            // lblMonatsbudget
            //
            this.lblMonatsbudget.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblMonatsbudget.Location = new System.Drawing.Point(4, 4);
            this.lblMonatsbudget.Name = "lblMonatsbudget";
            this.lblMonatsbudget.Size = new System.Drawing.Size(152, 16);
            this.lblMonatsbudget.TabIndex = 37;
            this.lblMonatsbudget.Text = "Papierverfügungen";
            //
            // btnMonatsbudget
            //
            this.btnMonatsbudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMonatsbudget.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMonatsbudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatsbudget.Location = new System.Drawing.Point(760, 464);
            this.btnMonatsbudget.Name = "btnMonatsbudget";
            this.btnMonatsbudget.Size = new System.Drawing.Size(104, 24);
            this.btnMonatsbudget.TabIndex = 11;
            this.btnMonatsbudget.Text = "> Monatsbudget";
            this.btnMonatsbudget.UseVisualStyleBackColor = false;
            this.btnMonatsbudget.Click += new System.EventHandler(this.btnMonatsbudget_Click);
            //
            // lblRowCount
            //
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblRowCount.Location = new System.Drawing.Point(920, 8);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(44, 16);
            this.lblRowCount.TabIndex = 39;
            this.lblRowCount.Text = "0";
            //
            // label1
            //
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(816, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 14);
            this.label1.TabIndex = 38;
            this.label1.Text = "Anzahl Datensätze:";
            //
            // btnAbbruch
            //
            this.btnAbbruch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbbruch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAbbruch.Enabled = false;
            this.btnAbbruch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbruch.Location = new System.Drawing.Point(648, 464);
            this.btnAbbruch.Name = "btnAbbruch";
            this.btnAbbruch.Size = new System.Drawing.Size(104, 24);
            this.btnAbbruch.TabIndex = 40;
            this.btnAbbruch.Text = "Abbruch";
            this.btnAbbruch.UseVisualStyleBackColor = false;
            this.btnAbbruch.Click += new System.EventHandler(this.btnAbbruch_Click);
            //
            // lblAktion
            //
            this.lblAktion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAktion.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblAktion.Location = new System.Drawing.Point(317, 469);
            this.lblAktion.Name = "lblAktion";
            this.lblAktion.Size = new System.Drawing.Size(317, 16);
            this.lblAktion.TabIndex = 41;
            this.lblAktion.Text = "Aktion";
            //
            // FrmMassendruckPapierVerfuegung
            //
            this.ActiveSQLQuery = this.qryBeleg;
            this.ClientSize = new System.Drawing.Size(971, 495);
            this.Controls.Add(this.lblAktion);
            this.Controls.Add(this.btnAbbruch);
            this.Controls.Add(this.btnMonatsbudget);
            this.Controls.Add(this.lblMonatsbudget);
            this.Controls.Add(this.btnMassendruck);
            this.Controls.Add(this.tabControlSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRowCount);
            this.Name = "FrmMassendruckPapierVerfuegung";
            this.Text = "SH Massendruck Papiervefügungen";
            this.Search += new System.EventHandler(this.FrmMassendruckPapierVerfuegung_Search);
            this.Load += new System.EventHandler(this.FrmMassendruckPapierVerfuegung_Load);
            this.Print += new System.EventHandler(this.FrmMassendruckPapierVerfuegung_Print);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBelege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBeleg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editMonat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSARX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatsbudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private void Suchen()
        {
            editSARX.CheckPendingSearchValue();
            string sql = "select * from vwShMassendruckPapierverfuegung where 1=1 ";

            if (!DBUtil.IsEmpty(editSARX.LookupID))
                sql += " and UserID = " + editSARX.LookupID.ToString();

            if (editMonat.SelectedIndex > 0)
                sql += " and Monat = " + DBUtil.SqlLiteral(editMonat.SelectedIndex);

            if (!DBUtil.IsEmpty(editJahr.EditValue))
                sql += " and Jahr = " + DBUtil.SqlLiteral(editJahr.EditValue);

            qryBeleg.Fill(sql + " order by SAR,Jahr,Monat,Klient");

            lblRowCount.Text = qryBeleg.Count.ToString();
            this.tabControlSearch.SelectedTabIndex = 0;
        }

        private void NeueSuche()
        {
            foreach (Control ctl in tpgSuchen.Controls)
            {
                if (ctl is DevExpress.XtraEditors.BaseEdit)
                    ((DevExpress.XtraEditors.BaseEdit)ctl).EditValue = null;
            }

            editSARX.Focus();
        }

        private void editSARX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(editSARX.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                editSARX.EditValue = dlg["Name"];
                editSARX.LookupID = dlg["UserID"];
            }
        }

        private void FrmMassendruckPapierVerfuegung_Search(object sender, System.EventArgs e)
        {
            if (tabControlSearch.SelectedTabIndex == 1)
                Suchen();
            else
            {
                tabControlSearch.SelectedTabIndex = 1;
                NeueSuche();
            }
        }

        private void btnMonatsbudget_Click(object sender, System.EventArgs e)
        {
            if (this.qryBeleg.Count > 0)
                GetKissMainForm().ShowItem(Gui.ModulID.S, "BBG", (int)this.qryBeleg["BgBudgetID"]);
        }

        private void btnMassendruck_Click(object sender, System.EventArgs e)
        {
            this.OnPrint();
        }

        private void FrmMassendruckPapierVerfuegung_Print(object sender, System.EventArgs e)
        {
            qryBeleg.EndCurrentEdit(true);

            abbruch = false;
            btnAbbruch.Enabled = true;
            btnAbbruch.Focus();

            int count = 0;
            foreach (DataRow row in qryBeleg.DataTable.Rows)
            {
                if ((bool)row["SelPrint"])
                {
                    count++;
                    lblAktion.Text = "Verfügung " + count.ToString() + " wird gedruckt ...";
                    ApplicationFacade.DoEvents();

                    if (abbruch)
                    {
                        count--;
                        break;
                    }

                    NamedPrm[] prms = new NamedPrm[2];
                    prms[0] = new NamedPrm("BgBudgetID", row["BgBudgetID"]);
                    prms[1] = new NamedPrm("KbBuchungID", row["KbBuchungID"]);

                    RepUtil.ExecuteReport("ShMassenPapierverfuegung", KissReportDestination.Printer, prms);
                    //					RepUtil.ExecuteReport("ShMassenPapierverfuegung",KissReportDestination.Viewer, prms);

                    //					R["SelPrint"] = false;
                    ApplicationFacade.DoEvents();
                }
            }
            lblAktion.Text = "";
            abbruch = false;
            btnAbbruch.Enabled = false;

            if (count == 0)
            {
                KissMsg.ShowInfo("FrmMassendruckPapierVerfuegung", "PapierverfuegungNichtSelektiert", "Es ist keine Papierverfügung für den Ausdruck selektiert!");
                return;
            }

            if (count == 1)
                KissMsg.ShowInfo("FrmMassendruckPapierVerfuegung", "1PapierverfuegungGedruckt", "Es wurde 1 Papierverfügung gedruckt.");
            else
                KissMsg.ShowInfo("FrmMassendruckPapierVerfuegung", "XPapierverfuegungenGedruckt", "Es wurden {0} Papierverfügungen gedruckt.", 0, 0, count.ToString());

            this.Activate();
        }

        private void btnAbbruch_Click(object sender, System.EventArgs e)
        {
            abbruch = KissMsg.ShowQuestion("FrmMassendruckPapierVerfuegung", "MassendruckAbbrechen", "Soll der Massendruck abgebrochen werden?");
        }

        private void FrmMassendruckPapierVerfuegung_Load(object sender, System.EventArgs e)
        {
            lblAktion.Text = "";
        }

        private void qryBeleg_BeforePost(object sender, System.EventArgs e)
        {
            qryBeleg.Row.AcceptChanges();
            qryBeleg.RowModified = false;
        }
    }
}