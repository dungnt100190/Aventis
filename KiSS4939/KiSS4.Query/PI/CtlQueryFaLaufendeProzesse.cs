using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Query.PI
{
    public class CtlQueryFaLaufendeProzesse : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAHVNr;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNr;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colVerantwortlicherBW;
        private DevExpress.XtraGrid.Columns.GridColumn colVerantwortlicherCM;
        private DevExpress.XtraGrid.Columns.GridColumn colVerantwortlicherED;
        private DevExpress.XtraGrid.Columns.GridColumn colVerantwortlicherSB;
        private DevExpress.XtraGrid.Columns.GridColumn colVersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colmw;
        private KiSS4.Gui.KissLookUpEdit edtSucheBeratungsstelle;
        private KiSS4.Gui.KissCalcEdit edtSucheLanguageCode;
        private KiSS4.Gui.KissLookUpEdit edtSucheMitarbeiter;
        private System.Windows.Forms.GroupBox grpHiddenSearch;
        private DevExpress.XtraGrid.Views.Grid.GridView grvQuery1;
        private KiSS4.Gui.KissLabel lblSucheBeratungsstelle;
        private KiSS4.Gui.KissLabel lblSucheHiddenLanguageCode;
        private KiSS4.Gui.KissLabel lblSucheMitarbeiter;

        // default search settings
        private Int32 userOrgUnitID = -1; // store the user's orgunitid

        #endregion

        #region Constructors

        public CtlQueryFaLaufendeProzesse()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryFaLaufendeProzesse));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSucheBeratungsstelle = new KiSS4.Gui.KissLabel();
            this.edtSucheBeratungsstelle = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtSucheMitarbeiter = new KiSS4.Gui.KissLookUpEdit();
            this.grpHiddenSearch = new System.Windows.Forms.GroupBox();
            this.lblSucheHiddenLanguageCode = new KiSS4.Gui.KissLabel();
            this.edtSucheLanguageCode = new KiSS4.Gui.KissCalcEdit();
            this.colAHVNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerantwortlicherBW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerantwortlicherCM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerantwortlicherED = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerantwortlicherSB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvQuery1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBeratungsstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBeratungsstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBeratungsstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).BeginInit();
            this.grpHiddenSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheHiddenLanguageCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLanguageCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            //
            // grdQuery1
            //
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.Location = new System.Drawing.Point(3, 3);
            this.grdQuery1.MainView = this.grvQuery1;
            this.grdQuery1.Size = new System.Drawing.Size(766, 389);
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvQuery1});
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(180, 397);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Visible = false;
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Size = new System.Drawing.Size(171, 24);
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.grpHiddenSearch);
            this.tpgSuchen.Controls.Add(this.edtSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.lblSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.edtSucheBeratungsstelle);
            this.tpgSuchen.Controls.Add(this.lblSucheBeratungsstelle);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBeratungsstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBeratungsstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.grpHiddenSearch, 0);
            //
            // lblSucheBeratungsstelle
            //
            this.lblSucheBeratungsstelle.Location = new System.Drawing.Point(31, 40);
            this.lblSucheBeratungsstelle.Name = "lblSucheBeratungsstelle";
            this.lblSucheBeratungsstelle.Size = new System.Drawing.Size(129, 24);
            this.lblSucheBeratungsstelle.TabIndex = 1;
            this.lblSucheBeratungsstelle.Text = "Beratungsstelle";
            this.lblSucheBeratungsstelle.UseCompatibleTextRendering = true;
            //
            // edtSucheBeratungsstelle
            //
            this.edtSucheBeratungsstelle.Location = new System.Drawing.Point(166, 40);
            this.edtSucheBeratungsstelle.Name = "edtSucheBeratungsstelle";
            this.edtSucheBeratungsstelle.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBeratungsstelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBeratungsstelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBeratungsstelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBeratungsstelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBeratungsstelle.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBeratungsstelle.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheBeratungsstelle.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBeratungsstelle.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheBeratungsstelle.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheBeratungsstelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheBeratungsstelle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheBeratungsstelle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBeratungsstelle.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheBeratungsstelle.Properties.DisplayMember = "Text";
            this.edtSucheBeratungsstelle.Properties.NullText = "";
            this.edtSucheBeratungsstelle.Properties.ShowFooter = false;
            this.edtSucheBeratungsstelle.Properties.ShowHeader = false;
            this.edtSucheBeratungsstelle.Properties.ValueMember = "Code";
            this.edtSucheBeratungsstelle.Size = new System.Drawing.Size(216, 24);
            this.edtSucheBeratungsstelle.TabIndex = 2;
            this.edtSucheBeratungsstelle.EditValueChanged += new System.EventHandler(this.edtSucheBeratungsstelle_EditValueChanged);
            //
            // lblSucheMitarbeiter
            //
            this.lblSucheMitarbeiter.Location = new System.Drawing.Point(31, 70);
            this.lblSucheMitarbeiter.Name = "lblSucheMitarbeiter";
            this.lblSucheMitarbeiter.Size = new System.Drawing.Size(129, 24);
            this.lblSucheMitarbeiter.TabIndex = 3;
            this.lblSucheMitarbeiter.Text = "Mitarbeiter/in";
            this.lblSucheMitarbeiter.UseCompatibleTextRendering = true;
            //
            // edtSucheMitarbeiter
            //
            this.edtSucheMitarbeiter.Location = new System.Drawing.Point(166, 70);
            this.edtSucheMitarbeiter.Name = "edtSucheMitarbeiter";
            this.edtSucheMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMitarbeiter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheMitarbeiter.Properties.DisplayMember = "Text";
            this.edtSucheMitarbeiter.Properties.NullText = "";
            this.edtSucheMitarbeiter.Properties.ShowFooter = false;
            this.edtSucheMitarbeiter.Properties.ShowHeader = false;
            this.edtSucheMitarbeiter.Properties.ValueMember = "Code";
            this.edtSucheMitarbeiter.Size = new System.Drawing.Size(216, 24);
            this.edtSucheMitarbeiter.TabIndex = 4;
            //
            // grpHiddenSearch
            //
            this.grpHiddenSearch.Controls.Add(this.edtSucheLanguageCode);
            this.grpHiddenSearch.Controls.Add(this.lblSucheHiddenLanguageCode);
            this.grpHiddenSearch.Location = new System.Drawing.Point(410, 38);
            this.grpHiddenSearch.Name = "grpHiddenSearch";
            this.grpHiddenSearch.Size = new System.Drawing.Size(213, 56);
            this.grpHiddenSearch.TabIndex = 8;
            this.grpHiddenSearch.TabStop = false;
            this.grpHiddenSearch.Text = "Hidden Fields";
            this.grpHiddenSearch.UseCompatibleTextRendering = true;
            this.grpHiddenSearch.Visible = false;
            //
            // lblSucheHiddenLanguageCode
            //
            this.lblSucheHiddenLanguageCode.Location = new System.Drawing.Point(6, 20);
            this.lblSucheHiddenLanguageCode.Name = "lblSucheHiddenLanguageCode";
            this.lblSucheHiddenLanguageCode.Size = new System.Drawing.Size(95, 24);
            this.lblSucheHiddenLanguageCode.TabIndex = 0;
            this.lblSucheHiddenLanguageCode.Text = "LanguageCode";
            this.lblSucheHiddenLanguageCode.UseCompatibleTextRendering = true;
            //
            // edtSucheLanguageCode
            //
            this.edtSucheLanguageCode.Location = new System.Drawing.Point(107, 20);
            this.edtSucheLanguageCode.Name = "edtSucheLanguageCode";
            this.edtSucheLanguageCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheLanguageCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheLanguageCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheLanguageCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheLanguageCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheLanguageCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheLanguageCode.Properties.Appearance.Options.UseFont = true;
            this.edtSucheLanguageCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheLanguageCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheLanguageCode.Size = new System.Drawing.Size(100, 24);
            this.edtSucheLanguageCode.TabIndex = 1;
            //
            // colAHVNr
            //
            this.colAHVNr.Name = "colAHVNr";
            //
            // colAlter
            //
            this.colAlter.Name = "colAlter";
            //
            // colDatum
            //
            this.colDatum.Name = "colDatum";
            //
            // colGeburtsdatum
            //
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            //
            // colmw
            //
            this.colmw.Name = "colmw";
            //
            // colName
            //
            this.colName.Name = "colName";
            //
            // colNr
            //
            this.colNr.Name = "colNr";
            //
            // colOrt
            //
            this.colOrt.Name = "colOrt";
            //
            // colPLZ
            //
            this.colPLZ.Name = "colPLZ";
            //
            // colStrasse
            //
            this.colStrasse.Name = "colStrasse";
            //
            // colVerantwortlicherBW
            //
            this.colVerantwortlicherBW.Name = "colVerantwortlicherBW";
            //
            // colVerantwortlicherCM
            //
            this.colVerantwortlicherCM.Name = "colVerantwortlicherCM";
            //
            // colVerantwortlicherED
            //
            this.colVerantwortlicherED.Name = "colVerantwortlicherED";
            //
            // colVerantwortlicherSB
            //
            this.colVerantwortlicherSB.Name = "colVerantwortlicherSB";
            //
            // colVersNr
            //
            this.colVersNr.Name = "colVersNr";
            //
            // colVorname
            //
            this.colVorname.Name = "colVorname";
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
            this.grvQuery1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvQuery1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvQuery1.GridControl = this.grdQuery1;
            this.grvQuery1.Name = "grvQuery1";
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
            // CtlQueryFaLaufendeProzesse
            //
            this.Name = "CtlQueryFaLaufendeProzesse";
            this.Load += new System.EventHandler(this.CtlQueryFaLaufendeProzesse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBeratungsstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBeratungsstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBeratungsstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).EndInit();
            this.grpHiddenSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheHiddenLanguageCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLanguageCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // apply static search values
            edtSucheLanguageCode.EditValue = Session.User.LanguageCode;

            // default OrgUnit (for all users equal)
            edtSucheBeratungsstelle.EditValue = this.userOrgUnitID;

            // set focus
            edtSucheBeratungsstelle.Focus();
        }

        protected override void RunSearch()
        {
            // check required fields
            if (DBUtil.IsEmpty(edtSucheBeratungsstelle.EditValue))
            {
                // Organisationseinheit is required
                KissMsg.ShowInfo("CtlQueryFaLaufendeProzesse", "RequiredSearchOrgUnit", "Das Feld 'Beratungsstelle' wird für die Suche benötigt!");
                edtSucheBeratungsstelle.Focus();

                throw new KissCancelException();
            }

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void CtlQueryFaLaufendeProzesse_Load(object sender, System.EventArgs e)
        {
            // DEFAULT VALUES:
            // get users member orgunit
            this.userOrgUnitID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT CONVERT(INT, ISNULL(dbo.fnOrgUnitOfUser({0}, 1), -1))", Session.User.UserId));

            // SEARCH:
            // fill dropdowns data, depending on rights
            SqlQuery qryOE = null;

            if (Session.User.IsUserAdmin)
            {
                // admin, get all orgunits
                qryOE = DBUtil.OpenSQL(@"
                            -- orgunits
                            SELECT [Code] = ORG.OrgUnitID,
                                   [Text] = ORG.ItemName + ISNULL(' ('+CONVERT(VARCHAR(50), ORG.Kostenstelle)+')',  '')
                            FROM XOrgUnit ORG
                            ORDER BY [Text], [Code]", Session.User.UserId);
            }
            else
            {
                // normal user
                qryOE = DBUtil.OpenSQL(@"
                            SELECT *
                            FROM dbo.fnBDEGetOEOrgUnitListZLE({0}, 0, 'OrgUnitKS', 'Text')", Session.User.UserId);
            }

            // setup edtSucheBeratungsstelle
            this.edtSucheBeratungsstelle.Properties.DropDownRows = Math.Min(qryOE.Count, 14);
            this.edtSucheBeratungsstelle.Properties.DataSource = qryOE;

            // INIT
            // start with new search
            NewSearch();
        }

        private void edtSucheBeratungsstelle_EditValueChanged(object sender, System.EventArgs e)
        {
            // all users which are member within orgunit
            SqlQuery qryUsers = DBUtil.OpenSQL(@"
                        SELECT [Code] = NULL,
                               [Text] = ''
                        UNION
                        SELECT [Code] = USR.UserID,
                               [Text] = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) + ISNULL(' (' + USR.LogonName + ')', '')
                        FROM XUser USR
                          INNER JOIN XOrgUnit_User OUU ON OUU.UserID = USR.UserID AND OUU.OrgUnitID = ISNULL({0}, -1)
                        ORDER BY [Text], [Code]", edtSucheBeratungsstelle.EditValue);

            // setup edtSucheMitarbeiter
            this.edtSucheMitarbeiter.Properties.DataSource = null;
            this.edtSucheMitarbeiter.Properties.DropDownRows = Math.Min(qryUsers.Count, 14);
            this.edtSucheMitarbeiter.Properties.DataSource = qryUsers;
        }

        #endregion
    }
}