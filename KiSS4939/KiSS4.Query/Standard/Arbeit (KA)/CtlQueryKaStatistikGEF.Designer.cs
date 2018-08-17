using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Query
{
    partial class CtlQueryKaStatistikGEF
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaStatistikGEF));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtAuswAngebot = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblAngebot = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.colNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzplatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzbeginn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzende = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrundEinsatzende = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArbeitspensum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEAZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrieb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetriebstyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAngebotstyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameSTES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVornameSTES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitaet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusbildung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBerufserfahrung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuweiser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzmonate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMassnahmetage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeplEinsatzende = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswAngebot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswAngebot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngebot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
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
            this.grvQuery1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNr,
            this.colEinsatzplatz,
            this.colEinsatzbeginn,
            this.colEinsatzende,
            this.colGeplEinsatzende,
            this.colGrundEinsatzende,
            this.colArbeitspensum,
            this.colEAZ,
            this.colBetrieb,
            this.colBetriebstyp,
            this.colAngebotstyp,
            this.colNameSTES,
            this.colVornameSTES,
            this.colNationalitaet,
            this.colGeschlecht,
            this.colAusbildung,
            this.colBerufserfahrung,
            this.colAlter,
            this.colCoach,
            this.colZuweiser,
            this.colEinsatzmonate,
            this.colMassnahmetage});
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
            this.tpgSuchen.Controls.Add(this.lblDatumBis);
            this.tpgSuchen.Controls.Add(this.lblDatumVon);
            this.tpgSuchen.Controls.Add(this.lblAngebot);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.edtAuswAngebot);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAuswAngebot, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAngebot, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumBis, 0);
            // 
            // edtAuswAngebot
            // 
            this.edtAuswAngebot.Location = new System.Drawing.Point(150, 42);
            this.edtAuswAngebot.Name = "edtAuswAngebot";
            this.edtAuswAngebot.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuswAngebot.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuswAngebot.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswAngebot.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuswAngebot.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuswAngebot.Properties.Appearance.Options.UseFont = true;
            this.edtAuswAngebot.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAuswAngebot.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswAngebot.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAuswAngebot.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAuswAngebot.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtAuswAngebot.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtAuswAngebot.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuswAngebot.Properties.NullText = "";
            this.edtAuswAngebot.Properties.ShowFooter = false;
            this.edtAuswAngebot.Properties.ShowHeader = false;
            this.edtAuswAngebot.Size = new System.Drawing.Size(100, 24);
            this.edtAuswAngebot.TabIndex = 2;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(150, 79);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 4;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(300, 79);
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
            this.edtDatumBis.TabIndex = 6;
            // 
            // lblAngebot
            // 
            this.lblAngebot.Location = new System.Drawing.Point(10, 42);
            this.lblAngebot.Name = "lblAngebot";
            this.lblAngebot.Size = new System.Drawing.Size(130, 24);
            this.lblAngebot.TabIndex = 1;
            this.lblAngebot.Text = "Angebot";
            this.lblAngebot.UseCompatibleTextRendering = true;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(10, 79);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(130, 24);
            this.lblDatumVon.TabIndex = 3;
            this.lblDatumVon.Text = "Datum von";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.Location = new System.Drawing.Point(268, 79);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(26, 24);
            this.lblDatumBis.TabIndex = 5;
            this.lblDatumBis.Text = "bis";
            this.lblDatumBis.UseCompatibleTextRendering = true;
            // 
            // colNr
            // 
            this.colNr.Caption = "Nr.";
            this.colNr.FieldName = "Nr";
            this.colNr.Name = "colNr";
            this.colNr.Visible = true;
            this.colNr.VisibleIndex = 0;
            // 
            // colEinsatzplatz
            // 
            this.colEinsatzplatz.Caption = "Einsatzplatz";
            this.colEinsatzplatz.FieldName = "Einsatzplatz";
            this.colEinsatzplatz.Name = "colEinsatzplatz";
            this.colEinsatzplatz.Visible = true;
            this.colEinsatzplatz.VisibleIndex = 1;
            // 
            // colEinsatzbeginn
            // 
            this.colEinsatzbeginn.Caption = "Einsatzbeginn";
            this.colEinsatzbeginn.FieldName = "Einsatzbeginn";
            this.colEinsatzbeginn.Name = "colEinsatzbeginn";
            this.colEinsatzbeginn.Visible = true;
            this.colEinsatzbeginn.VisibleIndex = 2;
            // 
            // colEinsatzende
            // 
            this.colEinsatzende.Caption = "Einsatzende";
            this.colEinsatzende.FieldName = "Einsatzende";
            this.colEinsatzende.Name = "colEinsatzende";
            this.colEinsatzende.Visible = true;
            this.colEinsatzende.VisibleIndex = 3;
            // 
            // colGrundEinsatzende
            // 
            this.colGrundEinsatzende.Caption = "Grund Einsatzende";
            this.colGrundEinsatzende.FieldName = "GrundEinsatzende";
            this.colGrundEinsatzende.Name = "colGrundEinsatzende";
            this.colGrundEinsatzende.Visible = true;
            this.colGrundEinsatzende.VisibleIndex = 5;
            // 
            // colArbeitspensum
            // 
            this.colArbeitspensum.Caption = "Arbeitspensum";
            this.colArbeitspensum.FieldName = "Arbeitspensum";
            this.colArbeitspensum.Name = "colArbeitspensum";
            this.colArbeitspensum.Visible = true;
            this.colArbeitspensum.VisibleIndex = 6;
            // 
            // colEAZ
            // 
            this.colEAZ.Caption = "EAZ %";
            this.colEAZ.FieldName = "EAZ";
            this.colEAZ.Name = "colEAZ";
            this.colEAZ.Visible = true;
            this.colEAZ.VisibleIndex = 7;
            // 
            // colBetrieb
            // 
            this.colBetrieb.Caption = "Betrieb";
            this.colBetrieb.FieldName = "Betrieb";
            this.colBetrieb.Name = "colBetrieb";
            this.colBetrieb.Visible = true;
            this.colBetrieb.VisibleIndex = 8;
            // 
            // colBetriebstyp
            // 
            this.colBetriebstyp.Caption = "Betriebstyp";
            this.colBetriebstyp.FieldName = "Betriebstyp";
            this.colBetriebstyp.Name = "colBetriebstyp";
            this.colBetriebstyp.Visible = true;
            this.colBetriebstyp.VisibleIndex = 9;
            // 
            // colAngebotstyp
            // 
            this.colAngebotstyp.Caption = "Angebotstyp";
            this.colAngebotstyp.FieldName = "Angebotstyp";
            this.colAngebotstyp.Name = "colAngebotstyp";
            this.colAngebotstyp.Visible = true;
            this.colAngebotstyp.VisibleIndex = 10;
            // 
            // colNameSTES
            // 
            this.colNameSTES.Caption = "Name STES";
            this.colNameSTES.FieldName = "NameSTES";
            this.colNameSTES.Name = "colNameSTES";
            this.colNameSTES.Visible = true;
            this.colNameSTES.VisibleIndex = 11;
            // 
            // colVornameSTES
            // 
            this.colVornameSTES.Caption = "Vorname STES";
            this.colVornameSTES.FieldName = "VornameSTES";
            this.colVornameSTES.Name = "colVornameSTES";
            this.colVornameSTES.Visible = true;
            this.colVornameSTES.VisibleIndex = 12;
            // 
            // colNationalitaet
            // 
            this.colNationalitaet.Caption = "Nationalität";
            this.colNationalitaet.FieldName = "Nationalitaet";
            this.colNationalitaet.Name = "colNationalitaet";
            this.colNationalitaet.Visible = true;
            this.colNationalitaet.VisibleIndex = 13;
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Caption = "Geschlecht";
            this.colGeschlecht.FieldName = "Geschlecht";
            this.colGeschlecht.Name = "colGeschlecht";
            this.colGeschlecht.Visible = true;
            this.colGeschlecht.VisibleIndex = 14;
            // 
            // colAusbildung
            // 
            this.colAusbildung.Caption = "Ausbildung";
            this.colAusbildung.FieldName = "Ausbildung";
            this.colAusbildung.Name = "colAusbildung";
            this.colAusbildung.Visible = true;
            this.colAusbildung.VisibleIndex = 15;
            // 
            // colBerufserfahrung
            // 
            this.colBerufserfahrung.Caption = "Berufserfahrung";
            this.colBerufserfahrung.FieldName = "Berufserfahrung";
            this.colBerufserfahrung.Name = "colBerufserfahrung";
            this.colBerufserfahrung.Visible = true;
            this.colBerufserfahrung.VisibleIndex = 16;
            // 
            // colAlter
            // 
            this.colAlter.Caption = "Alter";
            this.colAlter.FieldName = "Alter";
            this.colAlter.Name = "colAlter";
            this.colAlter.Visible = true;
            this.colAlter.VisibleIndex = 17;
            // 
            // colCoach
            // 
            this.colCoach.Caption = "Coach";
            this.colCoach.FieldName = "Coach";
            this.colCoach.Name = "colCoach";
            this.colCoach.Visible = true;
            this.colCoach.VisibleIndex = 18;
            // 
            // colZuweiser
            // 
            this.colZuweiser.Caption = "Zuweiser";
            this.colZuweiser.FieldName = "Zuweiser";
            this.colZuweiser.Name = "colZuweiser";
            this.colZuweiser.Visible = true;
            this.colZuweiser.VisibleIndex = 19;
            // 
            // colEinsatzmonate
            // 
            this.colEinsatzmonate.Caption = "Einsatzmonate";
            this.colEinsatzmonate.DisplayFormat.FormatString = "n3";
            this.colEinsatzmonate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEinsatzmonate.FieldName = "Einsatzmonate";
            this.colEinsatzmonate.Name = "colEinsatzmonate";
            this.colEinsatzmonate.Visible = true;
            this.colEinsatzmonate.VisibleIndex = 20;
            // 
            // colMassnahmetage
            // 
            this.colMassnahmetage.Caption = "Massnahmetage";
            this.colMassnahmetage.DisplayFormat.FormatString = "n3";
            this.colMassnahmetage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMassnahmetage.FieldName = "Massnahmetage";
            this.colMassnahmetage.Name = "colMassnahmetage";
            this.colMassnahmetage.Visible = true;
            this.colMassnahmetage.VisibleIndex = 21;
            // 
            // colGeplEinsatzende
            // 
            this.colGeplEinsatzende.Caption = "gepl. Einsatzende";
            this.colGeplEinsatzende.FieldName = "GeplEinsatzende";
            this.colGeplEinsatzende.Name = "colGeplEinsatzende";
            this.colGeplEinsatzende.Visible = true;
            this.colGeplEinsatzende.VisibleIndex = 4;
            // 
            // CtlQueryKaStatistikGEF
            // 
            this.Name = "CtlQueryKaStatistikGEF";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswAngebot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswAngebot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngebot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KiSS4.Gui.KissLookUpEdit edtAuswAngebot;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLabel lblAngebot;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colNr;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzplatz;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzbeginn;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzende;
        private DevExpress.XtraGrid.Columns.GridColumn colGrundEinsatzende;
        private DevExpress.XtraGrid.Columns.GridColumn colArbeitspensum;
        private DevExpress.XtraGrid.Columns.GridColumn colEAZ;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrieb;
        private DevExpress.XtraGrid.Columns.GridColumn colBetriebstyp;
        private DevExpress.XtraGrid.Columns.GridColumn colAngebotstyp;
        private DevExpress.XtraGrid.Columns.GridColumn colNameSTES;
        private DevExpress.XtraGrid.Columns.GridColumn colVornameSTES;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitaet;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colAusbildung;
        private DevExpress.XtraGrid.Columns.GridColumn colBerufserfahrung;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colCoach;
        private DevExpress.XtraGrid.Columns.GridColumn colZuweiser;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzmonate;
        private DevExpress.XtraGrid.Columns.GridColumn colMassnahmetage;
        private DevExpress.XtraGrid.Columns.GridColumn colGeplEinsatzende;
    }
}
