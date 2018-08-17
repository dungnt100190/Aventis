using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;

namespace KiSS4.Query
{
    partial class CtlQueryKaPraesenzzeit
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaPraesenzzeit));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblFachbereich = new KiSS4.Gui.KissLabel();
            this.edtFachbereich = new KiSS4.Gui.KissButtonEdit();
            this.colAnrede = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuswertung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeschftigungsgrad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrist = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtstag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprovAustritt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprovEintritt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRAVBeraterIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRAVTelNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorstellungstermin1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorstellungstermin2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.edtApvNummer = new KiSS4.Gui.KissLookUpEdit();
            this.lblApvNummer = new KiSS4.Gui.KissLabel();
            this.edtZusatz = new KiSS4.Gui.KissLookUpEdit();
            this.lblZusatz = new KiSS4.Gui.KissLabel();
            this.edtFachleitung = new KiSS4.Gui.KissButtonEdit();
            this.lblZustaendigKa = new KiSS4.Gui.KissLabel();
            this.edtZustaendigKa = new KiSS4.Gui.KissButtonEdit();
            this.lblFachleitung = new KiSS4.Gui.KissLabel();
            this.edtStes = new KiSS4.Gui.KissButtonEdit();
            this.lblSTES = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachbereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFachbereich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtApvNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtApvNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblApvNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFachleitung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachleitung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSTES)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
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
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
            // 
            // 
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.MainView = this.gridView1;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
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
            this.ctlGotoFall.DataMember = "BaPersonID$";
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtStes);
            this.tpgSuchen.Controls.Add(this.lblSTES);
            this.tpgSuchen.Controls.Add(this.lblDatumVon);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.lblZustaendigKa);
            this.tpgSuchen.Controls.Add(this.edtFachleitung);
            this.tpgSuchen.Controls.Add(this.edtZusatz);
            this.tpgSuchen.Controls.Add(this.lblZusatz);
            this.tpgSuchen.Controls.Add(this.edtApvNummer);
            this.tpgSuchen.Controls.Add(this.lblApvNummer);
            this.tpgSuchen.Controls.Add(this.lblFachbereich);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.lblDatumBis);
            this.tpgSuchen.Controls.Add(this.edtFachbereich);
            this.tpgSuchen.Controls.Add(this.lblFachleitung);
            this.tpgSuchen.Controls.Add(this.edtZustaendigKa);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZustaendigKa, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFachleitung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFachbereich, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFachbereich, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblApvNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtApvNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZusatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZusatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFachleitung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZustaendigKa, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSTES, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStes, 0);
            // 
            // lblFachbereich
            // 
            this.lblFachbereich.Location = new System.Drawing.Point(13, 225);
            this.lblFachbereich.Name = "lblFachbereich";
            this.lblFachbereich.Size = new System.Drawing.Size(130, 24);
            this.lblFachbereich.TabIndex = 15;
            this.lblFachbereich.Text = "Fachbereich";
            this.lblFachbereich.UseCompatibleTextRendering = true;
            // 
            // edtFachbereich
            // 
            this.edtFachbereich.Location = new System.Drawing.Point(153, 225);
            this.edtFachbereich.LookupSQL = resources.GetString("edtFachbereich.LookupSQL");
            this.edtFachbereich.Name = "edtFachbereich";
            this.edtFachbereich.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFachbereich.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFachbereich.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFachbereich.Properties.Appearance.Options.UseBackColor = true;
            this.edtFachbereich.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFachbereich.Properties.Appearance.Options.UseFont = true;
            this.edtFachbereich.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtFachbereich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtFachbereich.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFachbereich.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtFachbereich.Size = new System.Drawing.Size(250, 24);
            this.edtFachbereich.TabIndex = 7;
            this.edtFachbereich.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtFachbereich_UserModifiedFld);
            // 
            // colAnrede
            // 
            this.colAnrede.Name = "colAnrede";
            // 
            // colAuswertung
            // 
            this.colAuswertung.Name = "colAuswertung";
            // 
            // colBeschftigungsgrad
            // 
            this.colBeschftigungsgrad.Name = "colBeschftigungsgrad";
            // 
            // colBG
            // 
            this.colBG.Name = "colBG";
            // 
            // colFrist
            // 
            this.colFrist.Name = "colFrist";
            // 
            // colGeburtstag
            // 
            this.colGeburtstag.Name = "colGeburtstag";
            // 
            // colName
            // 
            this.colName.Name = "colName";
            // 
            // colprovAustritt
            // 
            this.colprovAustritt.Name = "colprovAustritt";
            // 
            // colprovEintritt
            // 
            this.colprovEintritt.Name = "colprovEintritt";
            // 
            // colRAVBeraterIn
            // 
            this.colRAVBeraterIn.Name = "colRAVBeraterIn";
            // 
            // colRAVTelNr
            // 
            this.colRAVTelNr.Name = "colRAVTelNr";
            // 
            // colTitel
            // 
            this.colTitel.Name = "colTitel";
            // 
            // colVorname
            // 
            this.colVorname.Name = "colVorname";
            // 
            // colVorstellungstermin1
            // 
            this.colVorstellungstermin1.Name = "colVorstellungstermin1";
            // 
            // colVorstellungstermin2
            // 
            this.colVorstellungstermin2.Name = "colVorstellungstermin2";
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatumBis.EditValue = "";
            this.edtDatumBis.Location = new System.Drawing.Point(303, 45);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 1;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatumVon.EditValue = "";
            this.edtDatumVon.Location = new System.Drawing.Point(153, 45);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 0;
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.Location = new System.Drawing.Point(273, 45);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(24, 24);
            this.lblDatumBis.TabIndex = 9;
            this.lblDatumBis.Text = "bis";
            this.lblDatumBis.UseCompatibleTextRendering = true;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(13, 45);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(130, 24);
            this.lblDatumVon.TabIndex = 8;
            this.lblDatumVon.Text = "Datum von";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // edtApvNummer
            // 
            this.edtApvNummer.Location = new System.Drawing.Point(153, 105);
            this.edtApvNummer.LOVName = "KaAPV";
            this.edtApvNummer.Name = "edtApvNummer";
            this.edtApvNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtApvNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtApvNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtApvNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtApvNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtApvNummer.Properties.Appearance.Options.UseFont = true;
            this.edtApvNummer.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtApvNummer.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtApvNummer.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtApvNummer.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtApvNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtApvNummer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtApvNummer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtApvNummer.Properties.NullText = "";
            this.edtApvNummer.Properties.ShowFooter = false;
            this.edtApvNummer.Properties.ShowHeader = false;
            this.edtApvNummer.Size = new System.Drawing.Size(250, 24);
            this.edtApvNummer.TabIndex = 3;
            // 
            // lblApvNummer
            // 
            this.lblApvNummer.Location = new System.Drawing.Point(13, 105);
            this.lblApvNummer.Name = "lblApvNummer";
            this.lblApvNummer.Size = new System.Drawing.Size(130, 24);
            this.lblApvNummer.TabIndex = 11;
            this.lblApvNummer.Text = "APV-Nummer";
            this.lblApvNummer.UseCompatibleTextRendering = true;
            // 
            // edtZusatz
            // 
            this.edtZusatz.Location = new System.Drawing.Point(153, 135);
            this.edtZusatz.LOVName = "KaAPVZusatz";
            this.edtZusatz.Name = "edtZusatz";
            this.edtZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtZusatz.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZusatz.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatz.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZusatz.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtZusatz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtZusatz.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZusatz.Properties.NullText = "";
            this.edtZusatz.Properties.ShowFooter = false;
            this.edtZusatz.Properties.ShowHeader = false;
            this.edtZusatz.Size = new System.Drawing.Size(250, 24);
            this.edtZusatz.TabIndex = 4;
            // 
            // lblZusatz
            // 
            this.lblZusatz.Location = new System.Drawing.Point(13, 135);
            this.lblZusatz.Name = "lblZusatz";
            this.lblZusatz.Size = new System.Drawing.Size(130, 24);
            this.lblZusatz.TabIndex = 12;
            this.lblZusatz.Text = "Zusatz";
            this.lblZusatz.UseCompatibleTextRendering = true;
            // 
            // edtFachleitung
            // 
            this.edtFachleitung.Location = new System.Drawing.Point(153, 195);
            this.edtFachleitung.LookupSQL = "select ID = BaPersonID, Person = NameVorname\r\nfrom   vwPerson\r\nwhere NameVorname " +
    "like {0} + \'%\'\r\norder by Person";
            this.edtFachleitung.Name = "edtFachleitung";
            this.edtFachleitung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFachleitung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFachleitung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFachleitung.Properties.Appearance.Options.UseBackColor = true;
            this.edtFachleitung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFachleitung.Properties.Appearance.Options.UseFont = true;
            this.edtFachleitung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtFachleitung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtFachleitung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFachleitung.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtFachleitung.Size = new System.Drawing.Size(250, 24);
            this.edtFachleitung.TabIndex = 6;
            this.edtFachleitung.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtFachleitung_UserModifiedFld);
            // 
            // lblZustaendigKa
            // 
            this.lblZustaendigKa.Location = new System.Drawing.Point(13, 165);
            this.lblZustaendigKa.Name = "lblZustaendigKa";
            this.lblZustaendigKa.Size = new System.Drawing.Size(130, 24);
            this.lblZustaendigKa.TabIndex = 13;
            this.lblZustaendigKa.Text = "Zuständig KA";
            this.lblZustaendigKa.UseCompatibleTextRendering = true;
            // 
            // edtZustaendigKa
            // 
            this.edtZustaendigKa.Location = new System.Drawing.Point(153, 165);
            this.edtZustaendigKa.LookupSQL = "select ID = BaPersonID, Person = NameVorname\r\nfrom   vwPerson\r\nwhere NameVorname " +
    "like {0} + \'%\'\r\norder by Person";
            this.edtZustaendigKa.Name = "edtZustaendigKa";
            this.edtZustaendigKa.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZustaendigKa.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustaendigKa.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigKa.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustaendigKa.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustaendigKa.Properties.Appearance.Options.UseFont = true;
            this.edtZustaendigKa.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtZustaendigKa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtZustaendigKa.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZustaendigKa.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtZustaendigKa.Size = new System.Drawing.Size(250, 24);
            this.edtZustaendigKa.TabIndex = 5;
            this.edtZustaendigKa.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtZustaendigKa_UserModifiedFld);
            // 
            // lblFachleitung
            // 
            this.lblFachleitung.Location = new System.Drawing.Point(13, 195);
            this.lblFachleitung.Name = "lblFachleitung";
            this.lblFachleitung.Size = new System.Drawing.Size(130, 24);
            this.lblFachleitung.TabIndex = 14;
            this.lblFachleitung.Text = "Fachleitung";
            this.lblFachleitung.UseCompatibleTextRendering = true;
            // 
            // edtStes
            // 
            this.edtStes.Location = new System.Drawing.Point(153, 75);
            this.edtStes.LookupSQL = "select ID = BaPersonID, Person = NameVorname\r\nfrom   vwPerson\r\nwhere NameVorname " +
    "like {0} + \'%\'\r\norder by Person";
            this.edtStes.Name = "edtStes";
            this.edtStes.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStes.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStes.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStes.Properties.Appearance.Options.UseBackColor = true;
            this.edtStes.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStes.Properties.Appearance.Options.UseFont = true;
            this.edtStes.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtStes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtStes.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStes.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtStes.Size = new System.Drawing.Size(250, 24);
            this.edtStes.TabIndex = 2;
            this.edtStes.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtStes_UserModifiedFld);
            // 
            // lblSTES
            // 
            this.lblSTES.Location = new System.Drawing.Point(13, 75);
            this.lblSTES.Name = "lblSTES";
            this.lblSTES.Size = new System.Drawing.Size(130, 24);
            this.lblSTES.TabIndex = 10;
            this.lblSTES.Text = "STES";
            this.lblSTES.UseCompatibleTextRendering = true;
            // 
            // CtlQueryKaPraesenzzeit
            // 
            this.Name = "CtlQueryKaPraesenzzeit";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFachbereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFachbereich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtApvNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtApvNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblApvNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFachleitung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachleitung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSTES)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colAnrede;
        private DevExpress.XtraGrid.Columns.GridColumn colAuswertung;
        private DevExpress.XtraGrid.Columns.GridColumn colBG;
        private DevExpress.XtraGrid.Columns.GridColumn colBeschftigungsgrad;
        private DevExpress.XtraGrid.Columns.GridColumn colFrist;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtstag;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colRAVBeraterIn;
        private DevExpress.XtraGrid.Columns.GridColumn colRAVTelNr;
        private DevExpress.XtraGrid.Columns.GridColumn colTitel;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colVorstellungstermin1;
        private DevExpress.XtraGrid.Columns.GridColumn colVorstellungstermin2;
        private DevExpress.XtraGrid.Columns.GridColumn colprovAustritt;
        private DevExpress.XtraGrid.Columns.GridColumn colprovEintritt;
        private KiSS4.Gui.KissButtonEdit edtFachbereich;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblFachbereich;
        private KissDateEdit edtDatumBis;
        private KissDateEdit edtDatumVon;
        private KissLabel lblDatumBis;
        private KissLabel lblDatumVon;
        private KissLookUpEdit edtApvNummer;
        private KissLabel lblApvNummer;
        private KissLookUpEdit edtZusatz;
        private KissLabel lblZusatz;
        private KissButtonEdit edtFachleitung;
        private KissLabel lblZustaendigKa;
        private KissButtonEdit edtZustaendigKa;
        private KissLabel lblFachleitung;
        private KissButtonEdit edtStes;
        private KissLabel lblSTES;

    }
}