using System;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;

namespace KiSS4.Klientenbuchhaltung
{
    public class CtlKbKostenstellen : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colGebDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatort;
        private DevExpress.XtraGrid.Columns.GridColumn colKantonSeit;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenstelle;
        private DevExpress.XtraGrid.Columns.GridColumn colLand;
        private DevExpress.XtraGrid.Columns.GridColumn colNameVorname;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissButtonEdit edtBaPersonIDX;
        private KiSS4.Gui.KissCheckEdit edtInklusiveUEPersonenX;
        private KiSS4.Gui.KissTextEdit edtNameX;
        private KiSS4.Gui.KissDateEdit edtUnterstuetztBisX;
        private KiSS4.Gui.KissDateEdit edtUnterstuetztVonX;
        private KiSS4.Gui.KissGrid grdPersonen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPersonen;
        private KiSS4.Gui.KissLabel lblBaPersonIDX;
        private KiSS4.Gui.KissLabel lblNameX;
        private KiSS4.Gui.KissLabel lblUnterstuetztBisX;
        private KiSS4.Gui.KissLabel lblUnterstuetztVonX;
        private System.Windows.Forms.Panel pnlWV;
        private KiSS4.DB.SqlQuery qryBaPerson;

        KiSS4.Basis.CtlBaPersonWV ctlBaPersonWV;

        #endregion

        #region Constructors

        public CtlKbKostenstellen()
        {
            this.InitializeComponent();

            //ZUG Control
            this.ctlBaPersonWV = new KiSS4.Basis.CtlBaPersonWV();

            this.ctlBaPersonWV.Dock = DockStyle.Fill;
            this.pnlWV.Controls.Add(ctlBaPersonWV);
            this.ctlBaPersonWV.BringToFront();

            this.tabControlSearch.SelectedTabIndex = tpgSuchen.TabIndex;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbKostenstellen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlWV = new System.Windows.Forms.Panel();
            this.grdPersonen = new KiSS4.Gui.KissGrid();
            this.qryBaPerson = new KiSS4.DB.SqlQuery(this.components);
            this.grvPersonen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGebDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKantonSeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenstelle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtNameX = new KiSS4.Gui.KissTextEdit();
            this.edtBaPersonIDX = new KiSS4.Gui.KissButtonEdit();
            this.edtUnterstuetztVonX = new KiSS4.Gui.KissDateEdit();
            this.edtUnterstuetztBisX = new KiSS4.Gui.KissDateEdit();
            this.edtInklusiveUEPersonenX = new KiSS4.Gui.KissCheckEdit();
            this.lblBaPersonIDX = new KiSS4.Gui.KissLabel();
            this.lblUnterstuetztVonX = new KiSS4.Gui.KissLabel();
            this.lblUnterstuetztBisX = new KiSS4.Gui.KissLabel();
            this.lblNameX = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIDX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetztVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetztBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklusiveUEPersonenX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonIDX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterstuetztVonX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterstuetztBisX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameX)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(810, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Size = new System.Drawing.Size(834, 261);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdPersonen);
            this.tpgListe.Size = new System.Drawing.Size(822, 223);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblNameX);
            this.tpgSuchen.Controls.Add(this.lblUnterstuetztBisX);
            this.tpgSuchen.Controls.Add(this.lblUnterstuetztVonX);
            this.tpgSuchen.Controls.Add(this.lblBaPersonIDX);
            this.tpgSuchen.Controls.Add(this.edtInklusiveUEPersonenX);
            this.tpgSuchen.Controls.Add(this.edtUnterstuetztBisX);
            this.tpgSuchen.Controls.Add(this.edtUnterstuetztVonX);
            this.tpgSuchen.Controls.Add(this.edtBaPersonIDX);
            this.tpgSuchen.Controls.Add(this.edtNameX);
            this.tpgSuchen.Size = new System.Drawing.Size(822, 223);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonIDX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUnterstuetztVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUnterstuetztBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklusiveUEPersonenX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBaPersonIDX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblUnterstuetztVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblUnterstuetztBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNameX, 0);
            // 
            // pnlWV
            // 
            this.pnlWV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWV.Location = new System.Drawing.Point(3, 270);
            this.pnlWV.Name = "pnlWV";
            this.pnlWV.Size = new System.Drawing.Size(834, 265);
            this.pnlWV.TabIndex = 0;
            // 
            // grdPersonen
            // 
            this.grdPersonen.DataSource = this.qryBaPerson;
            this.grdPersonen.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdPersonen.EmbeddedNavigator.Name = "";
            this.grdPersonen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdPersonen.Location = new System.Drawing.Point(0, 0);
            this.grdPersonen.MainView = this.grvPersonen;
            this.grdPersonen.Name = "grdPersonen";
            this.grdPersonen.Size = new System.Drawing.Size(822, 223);
            this.grdPersonen.TabIndex = 0;
            this.grdPersonen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPersonen});
            // 
            // qryBaPerson
            // 
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.SelectStatement = resources.GetString("qryBaPerson.SelectStatement");
            this.qryBaPerson.TableName = "BaPerson";
            this.qryBaPerson.PositionChanged += new System.EventHandler(this.qryBaPerson_PositionChanged);
            // 
            // grvPersonen
            // 
            this.grvPersonen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvPersonen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonen.Appearance.Empty.Options.UseBackColor = true;
            this.grvPersonen.Appearance.Empty.Options.UseFont = true;
            this.grvPersonen.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvPersonen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonen.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvPersonen.Appearance.EvenRow.Options.UseFont = true;
            this.grvPersonen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPersonen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvPersonen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvPersonen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvPersonen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvPersonen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPersonen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvPersonen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvPersonen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvPersonen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvPersonen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPersonen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvPersonen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPersonen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPersonen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPersonen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvPersonen.Appearance.GroupRow.Options.UseFont = true;
            this.grvPersonen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvPersonen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvPersonen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvPersonen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPersonen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvPersonen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvPersonen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPersonen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvPersonen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPersonen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPersonen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvPersonen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvPersonen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvPersonen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvPersonen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonen.Appearance.OddRow.Options.UseFont = true;
            this.grvPersonen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPersonen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonen.Appearance.Row.Options.UseBackColor = true;
            this.grvPersonen.Appearance.Row.Options.UseFont = true;
            this.grvPersonen.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPersonen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonen.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvPersonen.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvPersonen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvPersonen.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvPersonen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvPersonen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvPersonen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvPersonen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAlter,
            this.colGebDatum,
            this.colHeimatort,
            this.colLand,
            this.colKantonSeit,
            this.colKostenstelle,
            this.colNameVorname});
            this.grvPersonen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvPersonen.GridControl = this.grdPersonen;
            this.grvPersonen.Name = "grvPersonen";
            this.grvPersonen.OptionsBehavior.Editable = false;
            this.grvPersonen.OptionsCustomization.AllowFilter = false;
            this.grvPersonen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPersonen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPersonen.OptionsNavigation.UseTabKey = false;
            this.grvPersonen.OptionsView.ColumnAutoWidth = false;
            this.grvPersonen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPersonen.OptionsView.ShowGroupPanel = false;
            this.grvPersonen.OptionsView.ShowIndicator = false;
            // 
            // colAlter
            // 
            this.colAlter.Caption = "Alter";
            this.colAlter.DisplayFormat.FormatString = "d";
            this.colAlter.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colAlter.FieldName = "Alter";
            this.colAlter.Name = "colAlter";
            this.colAlter.OptionsColumn.AllowEdit = false;
            this.colAlter.OptionsColumn.AllowFocus = false;
            this.colAlter.Visible = true;
            this.colAlter.VisibleIndex = 6;
            this.colAlter.Width = 44;
            // 
            // colGebDatum
            // 
            this.colGebDatum.Caption = "Geb. Datum";
            this.colGebDatum.DisplayFormat.FormatString = "d";
            this.colGebDatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colGebDatum.FieldName = "Geburtsdatum";
            this.colGebDatum.Name = "colGebDatum";
            this.colGebDatum.OptionsColumn.AllowEdit = false;
            this.colGebDatum.OptionsColumn.AllowFocus = false;
            this.colGebDatum.OptionsColumn.ReadOnly = true;
            this.colGebDatum.Visible = true;
            this.colGebDatum.VisibleIndex = 5;
            this.colGebDatum.Width = 84;
            // 
            // colHeimatort
            // 
            this.colHeimatort.Caption = "Heimatort";
            this.colHeimatort.FieldName = "Heimatort";
            this.colHeimatort.Name = "colHeimatort";
            this.colHeimatort.OptionsColumn.AllowEdit = false;
            this.colHeimatort.OptionsColumn.AllowFocus = false;
            this.colHeimatort.OptionsColumn.ReadOnly = true;
            this.colHeimatort.Visible = true;
            this.colHeimatort.VisibleIndex = 2;
            this.colHeimatort.Width = 89;
            // 
            // colLand
            // 
            this.colLand.Caption = "Land";
            this.colLand.FieldName = "Nationalitaet";
            this.colLand.Name = "colLand";
            this.colLand.OptionsColumn.AllowEdit = false;
            this.colLand.OptionsColumn.AllowFocus = false;
            this.colLand.OptionsColumn.ReadOnly = true;
            this.colLand.Visible = true;
            this.colLand.VisibleIndex = 3;
            this.colLand.Width = 147;
            // 
            // colKantonSeit
            // 
            this.colKantonSeit.Caption = "im Kanton seit";
            this.colKantonSeit.DisplayFormat.FormatString = "d";
            this.colKantonSeit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colKantonSeit.FieldName = "ZuzugKtDatum";
            this.colKantonSeit.Name = "colKantonSeit";
            this.colKantonSeit.OptionsColumn.AllowEdit = false;
            this.colKantonSeit.OptionsColumn.AllowFocus = false;
            this.colKantonSeit.OptionsColumn.ReadOnly = true;
            this.colKantonSeit.Visible = true;
            this.colKantonSeit.VisibleIndex = 4;
            this.colKantonSeit.Width = 90;
            // 
            // colKostenstelle
            // 
            this.colKostenstelle.Caption = "Kostenstelle";
            this.colKostenstelle.DisplayFormat.FormatString = "N";
            this.colKostenstelle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKostenstelle.FieldName = "Kostenstelle";
            this.colKostenstelle.Name = "colKostenstelle";
            this.colKostenstelle.OptionsColumn.AllowEdit = false;
            this.colKostenstelle.OptionsColumn.AllowFocus = false;
            this.colKostenstelle.Visible = true;
            this.colKostenstelle.VisibleIndex = 1;
            this.colKostenstelle.Width = 140;
            // 
            // colNameVorname
            // 
            this.colNameVorname.Caption = "Name, Vorname";
            this.colNameVorname.FieldName = "NameVorname";
            this.colNameVorname.Name = "colNameVorname";
            this.colNameVorname.OptionsColumn.AllowEdit = false;
            this.colNameVorname.OptionsColumn.AllowFocus = false;
            this.colNameVorname.OptionsColumn.ReadOnly = true;
            this.colNameVorname.Visible = true;
            this.colNameVorname.VisibleIndex = 0;
            this.colNameVorname.Width = 162;
            // 
            // edtNameX
            // 
            this.edtNameX.Location = new System.Drawing.Point(104, 44);
            this.edtNameX.Name = "edtNameX";
            this.edtNameX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameX.Properties.Appearance.Options.UseFont = true;
            this.edtNameX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameX.Size = new System.Drawing.Size(249, 24);
            this.edtNameX.TabIndex = 0;
            // 
            // edtBaPersonIDX
            // 
            this.edtBaPersonIDX.Location = new System.Drawing.Point(104, 74);
            this.edtBaPersonIDX.Name = "edtBaPersonIDX";
            this.edtBaPersonIDX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonIDX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonIDX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonIDX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonIDX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonIDX.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonIDX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBaPersonIDX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBaPersonIDX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonIDX.Size = new System.Drawing.Size(249, 24);
            this.edtBaPersonIDX.TabIndex = 1;
            this.edtBaPersonIDX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPersonIDX_UserModifiedFld);
            // 
            // edtUnterstuetztVonX
            // 
            this.edtUnterstuetztVonX.EditValue = null;
            this.edtUnterstuetztVonX.Location = new System.Drawing.Point(104, 104);
            this.edtUnterstuetztVonX.Name = "edtUnterstuetztVonX";
            this.edtUnterstuetztVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUnterstuetztVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUnterstuetztVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUnterstuetztVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUnterstuetztVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtUnterstuetztVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUnterstuetztVonX.Properties.Appearance.Options.UseFont = true;
            this.edtUnterstuetztVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtUnterstuetztVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtUnterstuetztVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtUnterstuetztVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUnterstuetztVonX.Properties.ShowToday = false;
            this.edtUnterstuetztVonX.Size = new System.Drawing.Size(100, 24);
            this.edtUnterstuetztVonX.TabIndex = 2;
            // 
            // edtUnterstuetztBisX
            // 
            this.edtUnterstuetztBisX.EditValue = null;
            this.edtUnterstuetztBisX.Location = new System.Drawing.Point(253, 104);
            this.edtUnterstuetztBisX.Name = "edtUnterstuetztBisX";
            this.edtUnterstuetztBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUnterstuetztBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUnterstuetztBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUnterstuetztBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUnterstuetztBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtUnterstuetztBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUnterstuetztBisX.Properties.Appearance.Options.UseFont = true;
            this.edtUnterstuetztBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtUnterstuetztBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtUnterstuetztBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtUnterstuetztBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUnterstuetztBisX.Properties.ShowToday = false;
            this.edtUnterstuetztBisX.Size = new System.Drawing.Size(100, 24);
            this.edtUnterstuetztBisX.TabIndex = 3;
            // 
            // edtInklusiveUEPersonenX
            // 
            this.edtInklusiveUEPersonenX.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtInklusiveUEPersonenX.EditValue = false;
            this.edtInklusiveUEPersonenX.Location = new System.Drawing.Point(371, 78);
            this.edtInklusiveUEPersonenX.Name = "edtInklusiveUEPersonenX";
            this.edtInklusiveUEPersonenX.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtInklusiveUEPersonenX.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklusiveUEPersonenX.Properties.Caption = "Inkl. UE-Personen";
            this.edtInklusiveUEPersonenX.Properties.ReadOnly = true;
            this.edtInklusiveUEPersonenX.Size = new System.Drawing.Size(205, 19);
            this.edtInklusiveUEPersonenX.TabIndex = 4;
            // 
            // lblBaPersonIDX
            // 
            this.lblBaPersonIDX.Location = new System.Drawing.Point(8, 74);
            this.lblBaPersonIDX.Name = "lblBaPersonIDX";
            this.lblBaPersonIDX.Size = new System.Drawing.Size(90, 24);
            this.lblBaPersonIDX.TabIndex = 372;
            this.lblBaPersonIDX.Text = "Person";
            this.lblBaPersonIDX.UseCompatibleTextRendering = true;
            // 
            // lblUnterstuetztVonX
            // 
            this.lblUnterstuetztVonX.Location = new System.Drawing.Point(8, 104);
            this.lblUnterstuetztVonX.Name = "lblUnterstuetztVonX";
            this.lblUnterstuetztVonX.Size = new System.Drawing.Size(90, 24);
            this.lblUnterstuetztVonX.TabIndex = 378;
            this.lblUnterstuetztVonX.Text = "Unterstützt von";
            this.lblUnterstuetztVonX.UseCompatibleTextRendering = true;
            // 
            // lblUnterstuetztBisX
            // 
            this.lblUnterstuetztBisX.Location = new System.Drawing.Point(221, 104);
            this.lblUnterstuetztBisX.Name = "lblUnterstuetztBisX";
            this.lblUnterstuetztBisX.Size = new System.Drawing.Size(26, 24);
            this.lblUnterstuetztBisX.TabIndex = 379;
            this.lblUnterstuetztBisX.Text = "bis";
            this.lblUnterstuetztBisX.UseCompatibleTextRendering = true;
            // 
            // lblNameX
            // 
            this.lblNameX.Location = new System.Drawing.Point(8, 48);
            this.lblNameX.Name = "lblNameX";
            this.lblNameX.Size = new System.Drawing.Size(90, 24);
            this.lblNameX.TabIndex = 380;
            this.lblNameX.Text = "Name";
            this.lblNameX.UseCompatibleTextRendering = true;
            // 
            // CtlKbKostenstellen
            // 
            this.ActiveSQLQuery = this.qryBaPerson;
            this.Controls.Add(this.pnlWV);
            this.Name = "CtlKbKostenstellen";
            this.Size = new System.Drawing.Size(840, 535);
            this.Controls.SetChildIndex(this.pnlWV, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIDX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetztVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetztBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklusiveUEPersonenX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonIDX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterstuetztVonX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterstuetztBisX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameX)).EndInit();
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

        // ControlName: edtInklusiveUEPersonenX
        protected override void NewSearch()
        {
            base.NewSearch();
            edtInklusiveUEPersonenX.EditMode = EditModeType.ReadOnly;
            edtInklusiveUEPersonenX.Checked = false;
        }

        #endregion

        #region Private Methods

        private void edtBaPersonIDX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();

            if (!DBUtil.IsEmpty(edtBaPersonIDX.EditValue) && dlg.PersonSuchen(
                edtBaPersonIDX.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%"),
                e.ButtonClicked))
            {
                edtBaPersonIDX.Text = dlg["Name"].ToString();
                edtBaPersonIDX.LookupID = dlg["BaPersonID"];
                edtInklusiveUEPersonenX.EditMode = EditModeType.Normal;
            }
            else
            {
                edtBaPersonIDX.EditValue = DBNull.Value;
                edtInklusiveUEPersonenX.EditMode = EditModeType.ReadOnly;
                edtInklusiveUEPersonenX.Checked = false;
            }
        }

        private void qryBaPerson_PositionChanged(object sender, System.EventArgs e)
        {
            this.ctlBaPersonWV.BaPersonID = (int)qryBaPerson["BaPersonID"];
        }

        #endregion
    }
}