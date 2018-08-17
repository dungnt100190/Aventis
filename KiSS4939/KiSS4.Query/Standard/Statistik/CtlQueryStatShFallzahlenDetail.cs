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

namespace KiSS4.Query
{
    public class CtlQueryStatShFallzahlenDetail : KiSS4.Common.KissQueryControl
    {
        #region Fields

        #region Private Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colAlterTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzPersHaushalt;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzPersUnterst;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlFP;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlUE;
        private DevExpress.XtraGrid.Columns.GridColumn colArchiviertAm;
        private DevExpress.XtraGrid.Columns.GridColumn colFall;
        private DevExpress.XtraGrid.Columns.GridColumn colFallNr;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltrger;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeffnet;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlossen;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatort;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatortKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colModul;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSARKrzel;
        private DevExpress.XtraGrid.Columns.GridColumn colSARName;
        private DevExpress.XtraGrid.Columns.GridColumn colSARSektion;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasseNr;
        private DevExpress.XtraGrid.Columns.GridColumn colZivilstand;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissCheckEdit edtFT;
        private KissLookUpEdit edtGemeindeCode;
        private KiSS4.Gui.KissTextEdit edtJahr;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblAuswertungsjahr;
        private KissLabel lblGemeinde;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryStatShFallzahlenDetail()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryStatShFallzahlenDetail));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.lblAuswertungsjahr = new KiSS4.Gui.KissLabel();
            this.edtJahr = new KiSS4.Gui.KissTextEdit();
            this.edtFT = new KiSS4.Gui.KissCheckEdit();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlterTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlFP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzPersHaushalt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzPersUnterst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchiviertAm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFall = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltrger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeffnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlossen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatortKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModul = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARKrzel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARSektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasseNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZivilstand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtGemeindeCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblGemeinde = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswertungsjahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGemeinde)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
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
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
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
            this.tpgSuchen.Controls.Add(this.lblGemeinde);
            this.tpgSuchen.Controls.Add(this.edtGemeindeCode);
            this.tpgSuchen.Controls.Add(this.edtFT);
            this.tpgSuchen.Controls.Add(this.edtJahr);
            this.tpgSuchen.Controls.Add(this.lblAuswertungsjahr);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAuswertungsjahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtJahr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFT, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGemeindeCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblGemeinde, 0);
            //
            // lblAuswertungsjahr
            //
            this.lblAuswertungsjahr.Location = new System.Drawing.Point(30, 40);
            this.lblAuswertungsjahr.Name = "lblAuswertungsjahr";
            this.lblAuswertungsjahr.Size = new System.Drawing.Size(114, 24);
            this.lblAuswertungsjahr.TabIndex = 1;
            this.lblAuswertungsjahr.Text = "Auswertungsjahr";
            this.lblAuswertungsjahr.UseCompatibleTextRendering = true;
            //
            // edtJahr
            //
            this.edtJahr.EditValue = "";
            this.edtJahr.Location = new System.Drawing.Point(150, 40);
            this.edtJahr.Name = "edtJahr";
            this.edtJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtJahr.Properties.Appearance.Options.UseFont = true;
            this.edtJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtJahr.Size = new System.Drawing.Size(60, 24);
            this.edtJahr.TabIndex = 20;
            //
            // edtFT
            //
            this.edtFT.EditValue = false;
            this.edtFT.Location = new System.Drawing.Point(150, 100);
            this.edtFT.Name = "edtFT";
            this.edtFT.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtFT.Properties.Appearance.Options.UseBackColor = true;
            this.edtFT.Properties.Caption = "nur Falltraeger";
            this.edtFT.Size = new System.Drawing.Size(200, 19);
            this.edtFT.TabIndex = 21;
            //
            // colAlter
            //
            this.colAlter.Name = "colAlter";
            //
            // colAlterTyp
            //
            this.colAlterTyp.Name = "colAlterTyp";
            //
            // colAnzahlFP
            //
            this.colAnzahlFP.Name = "colAnzahlFP";
            //
            // colAnzahlUE
            //
            this.colAnzahlUE.Name = "colAnzahlUE";
            //
            // colAnzPersHaushalt
            //
            this.colAnzPersHaushalt.Name = "colAnzPersHaushalt";
            //
            // colAnzPersUnterst
            //
            this.colAnzPersUnterst.Name = "colAnzPersUnterst";
            //
            // colArchiviertAm
            //
            this.colArchiviertAm.Name = "colArchiviertAm";
            //
            // colFall
            //
            this.colFall.Name = "colFall";
            //
            // colFallNr
            //
            this.colFallNr.Name = "colFallNr";
            //
            // colFalltrger
            //
            this.colFalltrger.Name = "colFalltrger";
            //
            // colGeburtsdatum
            //
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            //
            // colGeffnet
            //
            this.colGeffnet.Name = "colGeffnet";
            //
            // colGeschlecht
            //
            this.colGeschlecht.Name = "colGeschlecht";
            //
            // colGeschlossen
            //
            this.colGeschlossen.Name = "colGeschlossen";
            //
            // colHeimatort
            //
            this.colHeimatort.Name = "colHeimatort";
            //
            // colHeimatortKanton
            //
            this.colHeimatortKanton.Name = "colHeimatortKanton";
            //
            // colKanton
            //
            this.colKanton.Name = "colKanton";
            //
            // colModul
            //
            this.colModul.Name = "colModul";
            //
            // colNationalitt
            //
            this.colNationalitt.Name = "colNationalitt";
            //
            // colOrt
            //
            this.colOrt.Name = "colOrt";
            //
            // colPerson
            //
            this.colPerson.Name = "colPerson";
            //
            // colPLZ
            //
            this.colPLZ.Name = "colPLZ";
            //
            // colSARKrzel
            //
            this.colSARKrzel.Name = "colSARKrzel";
            //
            // colSARName
            //
            this.colSARName.Name = "colSARName";
            //
            // colSARSektion
            //
            this.colSARSektion.Name = "colSARSektion";
            //
            // colStrasse
            //
            this.colStrasse.Name = "colStrasse";
            //
            // colStrasseNr
            //
            this.colStrasseNr.Name = "colStrasseNr";
            //
            // colZivilstand
            //
            this.colZivilstand.Name = "colZivilstand";
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
            // edtGemeindeCode
            //
            this.edtGemeindeCode.Location = new System.Drawing.Point(150, 70);
            this.edtGemeindeCode.LOVName = "GemeindeSozialdienst";
            this.edtGemeindeCode.Name = "edtGemeindeCode";
            this.edtGemeindeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGemeindeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGemeindeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGemeindeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtGemeindeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGemeindeCode.Properties.Appearance.Options.UseFont = true;
            this.edtGemeindeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGemeindeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGemeindeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGemeindeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGemeindeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtGemeindeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtGemeindeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGemeindeCode.Properties.NullText = "";
            this.edtGemeindeCode.Properties.ShowFooter = false;
            this.edtGemeindeCode.Properties.ShowHeader = false;
            this.edtGemeindeCode.Size = new System.Drawing.Size(200, 24);
            this.edtGemeindeCode.TabIndex = 22;
            //
            // lblGemeinde
            //
            this.lblGemeinde.Location = new System.Drawing.Point(30, 70);
            this.lblGemeinde.Name = "lblGemeinde";
            this.lblGemeinde.Size = new System.Drawing.Size(114, 24);
            this.lblGemeinde.TabIndex = 23;
            this.lblGemeinde.Text = "Gemeinde";
            this.lblGemeinde.UseCompatibleTextRendering = true;
            //
            // CtlQueryStatShFallzahlenDetail
            //
            this.Name = "CtlQueryStatShFallzahlenDetail";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAuswertungsjahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGemeinde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
    }
}