using System.Drawing;

using DevExpress.Utils;

namespace KiSS4.Query
{
    partial class CtlQueryGvGesuchAbschliessen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryGvGesuchAbschliessen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSucheGesuchsteller = new KiSS4.Gui.KissLabel();
            this.edtSucheGesuchsteller = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheFonds = new KiSS4.Gui.KissLabel();
            this.edtSucheFonds = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheGesuchsDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheGesuchsDatumBis = new KiSS4.Gui.KissLabel();
            this.edtSucheGesuchsDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheGesuchsDatum = new KiSS4.Gui.KissLabel();
            this.btnGesucheAbschliessen = new KiSS4.Gui.KissButton();
            this.grvGesuchAbschliessen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAbschliessenCheckBox = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesuchID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesuchsgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErstellDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameFonds = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBewilligt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntscheid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSelectNone = new KiSS4.Gui.KissButton();
            this.btnSelectAll = new KiSS4.Gui.KissButton();
            this.ctlKGSKostenstelleSAR = new KiSS4.Common.CtlKGSKostenstelleSAR();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGesuchsteller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGesuchsteller.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFonds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFonds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFonds.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGesuchsDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGesuchsDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGesuchsDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGesuchsDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGesuchAbschliessen)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.BatchUpdate = true;
            this.qryQuery.CanUpdate = true;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.BeforePost += new System.EventHandler(this.qryQuery_BeforePost);
            // 
            // grvQuery1
            // 
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            // 
            // grdQuery1
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.MainView = this.grvGesuchAbschliessen;
            this.grdQuery1.Size = new System.Drawing.Size(766, 384);
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGesuchAbschliessen});
            // 
            // xDocument
            // 
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID";
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.btnGesucheAbschliessen);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.lblSuchkriterienInfo, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnGesucheAbschliessen, 0);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.ctlKGSKostenstelleSAR);
            this.tpgSuchen.Controls.Add(this.edtSucheGesuchsDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheGesuchsDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheGesuchsDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheGesuchsDatum);
            this.tpgSuchen.Controls.Add(this.lblSucheFonds);
            this.tpgSuchen.Controls.Add(this.edtSucheFonds);
            this.tpgSuchen.Controls.Add(this.edtSucheGesuchsteller);
            this.tpgSuchen.Controls.Add(this.lblSucheGesuchsteller);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGesuchsteller, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGesuchsteller, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFonds, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheFonds, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGesuchsDatum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGesuchsDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGesuchsDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGesuchsDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.ctlKGSKostenstelleSAR, 0);
            // 
            // lblSucheGesuchsteller
            // 
            this.lblSucheGesuchsteller.Location = new System.Drawing.Point(8, 71);
            this.lblSucheGesuchsteller.Name = "lblSucheGesuchsteller";
            this.lblSucheGesuchsteller.Size = new System.Drawing.Size(133, 24);
            this.lblSucheGesuchsteller.TabIndex = 8;
            this.lblSucheGesuchsteller.Text = "Gesuchsteller";
            this.lblSucheGesuchsteller.UseCompatibleTextRendering = true;
            // 
            // edtSucheGesuchsteller
            // 
            this.edtSucheGesuchsteller.Location = new System.Drawing.Point(147, 71);
            this.edtSucheGesuchsteller.Name = "edtSucheGesuchsteller";
            this.edtSucheGesuchsteller.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGesuchsteller.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGesuchsteller.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGesuchsteller.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGesuchsteller.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGesuchsteller.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGesuchsteller.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheGesuchsteller.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheGesuchsteller.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGesuchsteller.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheGesuchsteller.Size = new System.Drawing.Size(244, 24);
            this.edtSucheGesuchsteller.TabIndex = 9;
            this.edtSucheGesuchsteller.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheGesuchsteller_UserModifiedFld);
            // 
            // lblSucheFonds
            // 
            this.lblSucheFonds.Location = new System.Drawing.Point(8, 191);
            this.lblSucheFonds.Name = "lblSucheFonds";
            this.lblSucheFonds.Size = new System.Drawing.Size(133, 24);
            this.lblSucheFonds.TabIndex = 13;
            this.lblSucheFonds.Text = "Fonds";
            this.lblSucheFonds.UseCompatibleTextRendering = true;
            // 
            // edtSucheFonds
            // 
            this.edtSucheFonds.Location = new System.Drawing.Point(147, 191);
            this.edtSucheFonds.Name = "edtSucheFonds";
            this.edtSucheFonds.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFonds.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFonds.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFonds.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFonds.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFonds.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFonds.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheFonds.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFonds.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheFonds.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheFonds.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheFonds.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheFonds.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFonds.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheFonds.Properties.DisplayMember = "Text";
            this.edtSucheFonds.Properties.NullText = "";
            this.edtSucheFonds.Properties.ShowFooter = false;
            this.edtSucheFonds.Properties.ShowHeader = false;
            this.edtSucheFonds.Properties.ValueMember = "Code";
            this.edtSucheFonds.Size = new System.Drawing.Size(244, 24);
            this.edtSucheFonds.TabIndex = 14;
            // 
            // edtSucheGesuchsDatumBis
            // 
            this.edtSucheGesuchsDatumBis.EditValue = null;
            this.edtSucheGesuchsDatumBis.Location = new System.Drawing.Point(291, 221);
            this.edtSucheGesuchsDatumBis.Name = "edtSucheGesuchsDatumBis";
            this.edtSucheGesuchsDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheGesuchsDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGesuchsDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGesuchsDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGesuchsDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGesuchsDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGesuchsDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGesuchsDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheGesuchsDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheGesuchsDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheGesuchsDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGesuchsDatumBis.Properties.ShowToday = false;
            this.edtSucheGesuchsDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheGesuchsDatumBis.TabIndex = 20;
            // 
            // lblSucheGesuchsDatumBis
            // 
            this.lblSucheGesuchsDatumBis.Location = new System.Drawing.Point(253, 221);
            this.lblSucheGesuchsDatumBis.Name = "lblSucheGesuchsDatumBis";
            this.lblSucheGesuchsDatumBis.Size = new System.Drawing.Size(32, 24);
            this.lblSucheGesuchsDatumBis.TabIndex = 19;
            this.lblSucheGesuchsDatumBis.Text = "bis";
            this.lblSucheGesuchsDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtSucheGesuchsDatumVon
            // 
            this.edtSucheGesuchsDatumVon.EditValue = null;
            this.edtSucheGesuchsDatumVon.Location = new System.Drawing.Point(147, 221);
            this.edtSucheGesuchsDatumVon.Name = "edtSucheGesuchsDatumVon";
            this.edtSucheGesuchsDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheGesuchsDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGesuchsDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGesuchsDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGesuchsDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGesuchsDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGesuchsDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGesuchsDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheGesuchsDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheGesuchsDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheGesuchsDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGesuchsDatumVon.Properties.EditFormat.FormatString = "yyyy";
            this.edtSucheGesuchsDatumVon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtSucheGesuchsDatumVon.Properties.ShowToday = false;
            this.edtSucheGesuchsDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheGesuchsDatumVon.TabIndex = 18;
            // 
            // lblSucheGesuchsDatum
            // 
            this.lblSucheGesuchsDatum.Location = new System.Drawing.Point(8, 221);
            this.lblSucheGesuchsDatum.Name = "lblSucheGesuchsDatum";
            this.lblSucheGesuchsDatum.Size = new System.Drawing.Size(133, 24);
            this.lblSucheGesuchsDatum.TabIndex = 17;
            this.lblSucheGesuchsDatum.Text = "Datum von";
            this.lblSucheGesuchsDatum.UseCompatibleTextRendering = true;
            // 
            // btnGesucheAbschliessen
            // 
            this.btnGesucheAbschliessen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGesucheAbschliessen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGesucheAbschliessen.Location = new System.Drawing.Point(607, 390);
            this.btnGesucheAbschliessen.Name = "btnGesucheAbschliessen";
            this.btnGesucheAbschliessen.Size = new System.Drawing.Size(162, 24);
            this.btnGesucheAbschliessen.TabIndex = 3;
            this.btnGesucheAbschliessen.Text = "Gesuche abschliessen";
            this.btnGesucheAbschliessen.UseVisualStyleBackColor = false;
            this.btnGesucheAbschliessen.Click += new System.EventHandler(this.btnGesucheAbschliessen_Click);
            // 
            // grvGesuchAbschliessen
            // 
            this.grvGesuchAbschliessen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvGesuchAbschliessen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuchAbschliessen.Appearance.Empty.Options.UseBackColor = true;
            this.grvGesuchAbschliessen.Appearance.Empty.Options.UseFont = true;
            this.grvGesuchAbschliessen.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvGesuchAbschliessen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuchAbschliessen.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvGesuchAbschliessen.Appearance.EvenRow.Options.UseFont = true;
            this.grvGesuchAbschliessen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGesuchAbschliessen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuchAbschliessen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvGesuchAbschliessen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvGesuchAbschliessen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvGesuchAbschliessen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvGesuchAbschliessen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGesuchAbschliessen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuchAbschliessen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvGesuchAbschliessen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvGesuchAbschliessen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvGesuchAbschliessen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvGesuchAbschliessen.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGesuchAbschliessen.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvGesuchAbschliessen.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvGesuchAbschliessen.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvGesuchAbschliessen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGesuchAbschliessen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvGesuchAbschliessen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGesuchAbschliessen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGesuchAbschliessen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGesuchAbschliessen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvGesuchAbschliessen.Appearance.GroupRow.Options.UseFont = true;
            this.grvGesuchAbschliessen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvGesuchAbschliessen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvGesuchAbschliessen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvGesuchAbschliessen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGesuchAbschliessen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvGesuchAbschliessen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvGesuchAbschliessen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvGesuchAbschliessen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvGesuchAbschliessen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuchAbschliessen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGesuchAbschliessen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvGesuchAbschliessen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvGesuchAbschliessen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvGesuchAbschliessen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvGesuchAbschliessen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvGesuchAbschliessen.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvGesuchAbschliessen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuchAbschliessen.Appearance.OddRow.Options.UseBackColor = true;
            this.grvGesuchAbschliessen.Appearance.OddRow.Options.UseFont = true;
            this.grvGesuchAbschliessen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvGesuchAbschliessen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuchAbschliessen.Appearance.Row.Options.UseBackColor = true;
            this.grvGesuchAbschliessen.Appearance.Row.Options.UseFont = true;
            this.grvGesuchAbschliessen.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvGesuchAbschliessen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuchAbschliessen.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvGesuchAbschliessen.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvGesuchAbschliessen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvGesuchAbschliessen.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvGesuchAbschliessen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvGesuchAbschliessen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvGesuchAbschliessen.BestFitMaxRowCount = 50;
            this.grvGesuchAbschliessen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvGesuchAbschliessen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAbschliessenCheckBox,
            this.colKlient,
            this.colGesuchID,
            this.colGesuchsgrund,
            this.colErstellDatum,
            this.colNameFonds,
            this.colBewilligt,
            this.colEntscheid,
            this.colAutor});
            this.grvGesuchAbschliessen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvGesuchAbschliessen.GridControl = this.grdQuery1;
            this.grvGesuchAbschliessen.Name = "grvGesuchAbschliessen";
            this.grvGesuchAbschliessen.OptionsBehavior.Editable = false;
            this.grvGesuchAbschliessen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvGesuchAbschliessen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvGesuchAbschliessen.OptionsNavigation.UseTabKey = false;
            this.grvGesuchAbschliessen.OptionsPrint.AutoWidth = false;
            this.grvGesuchAbschliessen.OptionsPrint.ExpandAllDetails = true;
            this.grvGesuchAbschliessen.OptionsPrint.UsePrintStyles = true;
            this.grvGesuchAbschliessen.OptionsView.ColumnAutoWidth = false;
            this.grvGesuchAbschliessen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvGesuchAbschliessen.OptionsView.ShowGroupPanel = false;
            this.grvGesuchAbschliessen.OptionsView.ShowIndicator = false;
            // 
            // colAbschliessenCheckBox
            // 
            this.colAbschliessenCheckBox.Caption = "abschl.";
            this.colAbschliessenCheckBox.Name = "colAbschliessenCheckBox";
            this.colAbschliessenCheckBox.Visible = true;
            this.colAbschliessenCheckBox.VisibleIndex = 0;
            // 
            // colKlient
            // 
            this.colKlient.Caption = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.OptionsColumn.AllowEdit = false;
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 1;
            this.colKlient.Width = 82;
            // 
            // colGesuchID
            // 
            this.colGesuchID.AppearanceCell.Options.UseTextOptions = true;
            this.colGesuchID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGesuchID.Caption = "Gesuchs-ID";
            this.colGesuchID.Name = "colGesuchID";
            this.colGesuchID.OptionsColumn.AllowEdit = false;
            this.colGesuchID.Visible = true;
            this.colGesuchID.VisibleIndex = 2;
            // 
            // colGesuchsgrund
            // 
            this.colGesuchsgrund.Caption = "Gesuchsgrund";
            this.colGesuchsgrund.Name = "colGesuchsgrund";
            this.colGesuchsgrund.OptionsColumn.AllowEdit = false;
            this.colGesuchsgrund.Visible = true;
            this.colGesuchsgrund.VisibleIndex = 3;
            // 
            // colErstellDatum
            // 
            this.colErstellDatum.Caption = "Erstell-Dat.";
            this.colErstellDatum.Name = "colErstellDatum";
            this.colErstellDatum.OptionsColumn.AllowEdit = false;
            this.colErstellDatum.Visible = true;
            this.colErstellDatum.VisibleIndex = 4;
            // 
            // colNameFonds
            // 
            this.colNameFonds.Caption = "Name Fonds";
            this.colNameFonds.Name = "colNameFonds";
            this.colNameFonds.OptionsColumn.AllowEdit = false;
            this.colNameFonds.Visible = true;
            this.colNameFonds.VisibleIndex = 5;
            // 
            // colBewilligt
            // 
            this.colBewilligt.Caption = "bewilligt";
            this.colBewilligt.Name = "colBewilligt";
            this.colBewilligt.OptionsColumn.AllowEdit = false;
            this.colBewilligt.Visible = true;
            this.colBewilligt.VisibleIndex = 6;
            // 
            // colEntscheid
            // 
            this.colEntscheid.Caption = "Entscheid";
            this.colEntscheid.Name = "colEntscheid";
            this.colEntscheid.OptionsColumn.AllowEdit = false;
            this.colEntscheid.Visible = true;
            this.colEntscheid.VisibleIndex = 7;
            // 
            // colAutor
            // 
            this.colAutor.Caption = "Autor";
            this.colAutor.Name = "colAutor";
            this.colAutor.OptionsColumn.AllowEdit = false;
            this.colAutor.Visible = true;
            this.colAutor.VisibleIndex = 8;
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectNone.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectNone.Image")));
            this.btnSelectNone.Location = new System.Drawing.Point(208, 5);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(24, 24);
            this.btnSelectNone.TabIndex = 53;
            this.btnSelectNone.UseCompatibleTextRendering = true;
            this.btnSelectNone.UseVisualStyleBackColor = false;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.Location = new System.Drawing.Point(178, 5);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(24, 24);
            this.btnSelectAll.TabIndex = 52;
            this.btnSelectAll.UseCompatibleTextRendering = true;
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // ctlKGSKostenstelleSAR
            // 
            this.ctlKGSKostenstelleSAR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlKGSKostenstelleSAR.DataMemberKGS = "";
            this.ctlKGSKostenstelleSAR.DataMemberKostenstelle = "";
            this.ctlKGSKostenstelleSAR.DataMemberMitarbeiter = "";
            this.ctlKGSKostenstelleSAR.Location = new System.Drawing.Point(8, 101);
            this.ctlKGSKostenstelleSAR.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.ctlKGSKostenstelleSAR.Name = "ctlKGSKostenstelleSAR";
            this.ctlKGSKostenstelleSAR.Size = new System.Drawing.Size(383, 84);
            this.ctlKGSKostenstelleSAR.TabIndex = 21;
            // 
            // CtlQueryGvGesuchAbschliessen
            // 
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnSelectNone);
            this.Name = "CtlQueryGvGesuchAbschliessen";
            this.Load += new System.EventHandler(this.CtlQueryGvGesuchAbschliessen_Load);
            this.Controls.SetChildIndex(this.btnSelectNone, 0);
            this.Controls.SetChildIndex(this.btnSelectAll, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGesuchsteller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGesuchsteller.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFonds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFonds.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFonds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGesuchsDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGesuchsDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGesuchsDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGesuchsDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGesuchAbschliessen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gui.KissLabel lblSucheGesuchsteller;
        private Gui.KissButtonEdit edtSucheGesuchsteller;
        private Gui.KissLabel lblSucheFonds;
        private Gui.KissLookUpEdit edtSucheFonds;
        private Gui.KissDateEdit edtSucheGesuchsDatumBis;
        private Gui.KissLabel lblSucheGesuchsDatumBis;
        private Gui.KissDateEdit edtSucheGesuchsDatumVon;
        private Gui.KissLabel lblSucheGesuchsDatum;
        private Gui.KissButton btnGesucheAbschliessen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGesuchAbschliessen;
        private DevExpress.XtraGrid.Columns.GridColumn colAbschliessenCheckBox;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colGesuchID;
        private DevExpress.XtraGrid.Columns.GridColumn colGesuchsgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colErstellDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colNameFonds;
        private DevExpress.XtraGrid.Columns.GridColumn colBewilligt;
        private DevExpress.XtraGrid.Columns.GridColumn colEntscheid;
        private DevExpress.XtraGrid.Columns.GridColumn colAutor;
        private Gui.KissButton btnSelectNone;
        private Gui.KissButton btnSelectAll;
        private Common.CtlKGSKostenstelleSAR ctlKGSKostenstelleSAR;
    }
}
