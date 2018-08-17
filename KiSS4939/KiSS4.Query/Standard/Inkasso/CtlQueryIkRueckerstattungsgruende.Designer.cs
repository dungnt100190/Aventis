using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Query
{
    partial class CtlQueryIkRueckerstattungsgruende
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlFaelle;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlGlaeubiger;
        private DevExpress.XtraGrid.Columns.GridColumn colArchiv;
        private DevExpress.XtraGrid.Columns.GridColumn colBemhung;
        private DevExpress.XtraGrid.Columns.GridColumn colBemuehungText;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumAnpassenAb;
        private DevExpress.XtraGrid.Columns.GridColumn colElterlicheSorge;
        private DevExpress.XtraGrid.Columns.GridColumn colElterlicheSorgeBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colFaLeistungID;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlaeubiger;
        private DevExpress.XtraGrid.Columns.GridColumn colGlubiger;
        private DevExpress.XtraGrid.Columns.GridColumn colIkForderungID;
        private DevExpress.XtraGrid.Columns.GridColumn colIkGlaeubigerID;
        private DevExpress.XtraGrid.Columns.GridColumn colIkRechtstitelID;
        private DevExpress.XtraGrid.Columns.GridColumn colInkassoFallName;
        private DevExpress.XtraGrid.Columns.GridColumn colInkassoTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatsBevorschussung;
        private DevExpress.XtraGrid.Columns.GridColumn colRckerstattungtyp;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSARName;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldner;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colUnterart;
        private DevExpress.XtraGrid.Columns.GridColumn colVerjaehrungAm;
        private DevExpress.XtraGrid.Columns.GridColumn colmonatlBetrag;
        private KiSS4.Gui.KissCheckEdit edtInklAbgeschlossen;
        private KiSS4.Gui.KissCheckEdit edtInklArchiviert;
        private KiSS4.Gui.KissDateEdit edtZeitraumBis;
        private KiSS4.Gui.KissDateEdit edtZeitraumVon;
        private KiSS4.Gui.KissLookUpEdit edtRueckerstattungTyp;
        private KiSS4.Gui.KissLookUpEdit edtInkassoTyp;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private KiSS4.Gui.KissLabel lblZeitraumBis;
        private KiSS4.Gui.KissLabel lblRueckerstattungTypX;
        private KiSS4.Gui.KissLabel lblUserID;
        private KiSS4.Gui.KissLabel lblinkassoTyp;

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryIkRueckerstattungsgruende));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtInkassoTyp = new KiSS4.Gui.KissLookUpEdit();
            this.lblZeitraumBis = new KiSS4.Gui.KissLabel();
            this.lblinkassoTyp = new KiSS4.Gui.KissLabel();
            this.lblUserID = new KiSS4.Gui.KissLabel();
            this.edtZeitraumVon = new KiSS4.Gui.KissDateEdit();
            this.edtZeitraumBis = new KiSS4.Gui.KissDateEdit();
            this.edtInklAbgeschlossen = new KiSS4.Gui.KissCheckEdit();
            this.edtInklArchiviert = new KiSS4.Gui.KissCheckEdit();
            this.lblRueckerstattungTypX = new KiSS4.Gui.KissLabel();
            this.edtRueckerstattungTyp = new KiSS4.Gui.KissLookUpEdit();
            this.colAnzahlFaelle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlGlaeubiger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemhung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemuehungText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumAnpassenAb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colElterlicheSorge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colElterlicheSorgeBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaLeistungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlaeubiger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlubiger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkForderungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkGlaeubigerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkRechtstitelID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInkassoFallName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInkassoTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmonatlBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatsBevorschussung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRckerstattungtyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnterart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerjaehrungAm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblAbklaerungsart = new KiSS4.Gui.KissLabel();
            this.edtAbklaerungArt = new KiSS4.Gui.KissLookUpEdit();
            this.edtForderungenInZeitraum = new KiSS4.Gui.KissCheckEdit();
            this.edtZahlungenInZeitraum = new KiSS4.Gui.KissCheckEdit();
            this.edtUnterstuetzungsendeBis = new KiSS4.Gui.KissDateEdit();
            this.edtUnterstuetzungsendeVon = new KiSS4.Gui.KissDateEdit();
            this.lblUnterstuetzungsendeBis = new KiSS4.Gui.KissLabel();
            this.lblUnterstuezungsende = new KiSS4.Gui.KissLabel();
            this.tpgZusammenzug = new SharpLibrary.WinControls.TabPageEx();
            this.grdQuery2 = new KiSS4.Gui.KissGrid();
            this.grvQuery2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnAbsprung = new KiSS4.Gui.KissButton();
            this.kissGroupBox1 = new KiSS4.Gui.KissGroupBox();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblinkassoTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklAbgeschlossen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklArchiviert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRueckerstattungTypX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRueckerstattungTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRueckerstattungTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbklaerungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbklaerungArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbklaerungArt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungenInZeitraum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungenInZeitraum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetzungsendeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetzungsendeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterstuetzungsendeBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterstuezungsende)).BeginInit();
            this.tpgZusammenzug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery2)).BeginInit();
            this.kissGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.FillTimeOut = 900;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
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
            this.grvQuery1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            // 
            // 
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.Size = new System.Drawing.Size(766, 467);
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(164, 476);
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
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 437);
            // 
            // lblSuchkriterienInfo
            // 
            this.lblSuchkriterienInfo.Location = new System.Drawing.Point(306, 438);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgZusammenzug);
            this.tabControlSearch.Location = new System.Drawing.Point(9, 35);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(784, 501);
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgZusammenzug});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgZusammenzug, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.btnAbsprung);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Size = new System.Drawing.Size(772, 463);
            this.tpgListe.Controls.SetChildIndex(this.lblSuchkriterienInfo, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnAbsprung, 0);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.kissGroupBox1);
            this.tpgSuchen.Controls.Add(this.edtUnterstuetzungsendeBis);
            this.tpgSuchen.Controls.Add(this.edtUnterstuetzungsendeVon);
            this.tpgSuchen.Controls.Add(this.lblUnterstuetzungsendeBis);
            this.tpgSuchen.Controls.Add(this.lblUnterstuezungsende);
            this.tpgSuchen.Controls.Add(this.lblAbklaerungsart);
            this.tpgSuchen.Controls.Add(this.edtAbklaerungArt);
            this.tpgSuchen.Controls.Add(this.edtRueckerstattungTyp);
            this.tpgSuchen.Controls.Add(this.lblRueckerstattungTypX);
            this.tpgSuchen.Controls.Add(this.edtInklArchiviert);
            this.tpgSuchen.Controls.Add(this.edtInklAbgeschlossen);
            this.tpgSuchen.Controls.Add(this.lblUserID);
            this.tpgSuchen.Controls.Add(this.lblinkassoTyp);
            this.tpgSuchen.Controls.Add(this.edtInkassoTyp);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Size = new System.Drawing.Size(772, 463);
            this.tpgSuchen.TabIndex = 2;
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInkassoTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblinkassoTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklAbgeschlossen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklArchiviert, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblRueckerstattungTypX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtRueckerstattungTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAbklaerungArt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAbklaerungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblUnterstuezungsende, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblUnterstuetzungsendeBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUnterstuetzungsendeVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUnterstuetzungsendeBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissGroupBox1, 0);
            // 
            // edtUserID
            // 
            this.edtUserID.Location = new System.Drawing.Point(160, 63);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUserID.Size = new System.Drawing.Size(271, 24);
            this.edtUserID.TabIndex = 2;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            // 
            // edtInkassoTyp
            // 
            this.edtInkassoTyp.AllowNull = false;
            this.edtInkassoTyp.Location = new System.Drawing.Point(160, 93);
            this.edtInkassoTyp.LOVFilter = "Code IN (403, 406, 407)";
            this.edtInkassoTyp.LOVFilterWhereAppend = true;
            this.edtInkassoTyp.LOVName = "FaProzess";
            this.edtInkassoTyp.Name = "edtInkassoTyp";
            this.edtInkassoTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInkassoTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInkassoTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInkassoTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtInkassoTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInkassoTyp.Properties.Appearance.Options.UseFont = true;
            this.edtInkassoTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtInkassoTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtInkassoTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtInkassoTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtInkassoTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtInkassoTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtInkassoTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInkassoTyp.Properties.NullText = "";
            this.edtInkassoTyp.Properties.ShowFooter = false;
            this.edtInkassoTyp.Properties.ShowHeader = false;
            this.edtInkassoTyp.Size = new System.Drawing.Size(271, 24);
            this.edtInkassoTyp.TabIndex = 4;
            // 
            // lblZeitraumBis
            // 
            this.lblZeitraumBis.Location = new System.Drawing.Point(264, 20);
            this.lblZeitraumBis.Name = "lblZeitraumBis";
            this.lblZeitraumBis.Size = new System.Drawing.Size(26, 24);
            this.lblZeitraumBis.TabIndex = 15;
            this.lblZeitraumBis.Text = "bis";
            this.lblZeitraumBis.UseCompatibleTextRendering = true;
            // 
            // lblinkassoTyp
            // 
            this.lblinkassoTyp.Location = new System.Drawing.Point(32, 93);
            this.lblinkassoTyp.Name = "lblinkassoTyp";
            this.lblinkassoTyp.Size = new System.Drawing.Size(115, 24);
            this.lblinkassoTyp.TabIndex = 3;
            this.lblinkassoTyp.Text = "Inkasso-Typ";
            this.lblinkassoTyp.UseCompatibleTextRendering = true;
            // 
            // lblUserID
            // 
            this.lblUserID.Location = new System.Drawing.Point(32, 63);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(115, 24);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "SAR";
            this.lblUserID.UseCompatibleTextRendering = true;
            // 
            // edtZeitraumVon
            // 
            this.edtZeitraumVon.EditValue = null;
            this.edtZeitraumVon.Location = new System.Drawing.Point(140, 20);
            this.edtZeitraumVon.Name = "edtZeitraumVon";
            this.edtZeitraumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZeitraumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZeitraumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZeitraumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZeitraumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtZeitraumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZeitraumVon.Properties.Appearance.Options.UseFont = true;
            this.edtZeitraumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtZeitraumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZeitraumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtZeitraumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZeitraumVon.Properties.ShowToday = false;
            this.edtZeitraumVon.Size = new System.Drawing.Size(100, 24);
            this.edtZeitraumVon.TabIndex = 14;
            // 
            // edtZeitraumBis
            // 
            this.edtZeitraumBis.EditValue = null;
            this.edtZeitraumBis.Location = new System.Drawing.Point(311, 20);
            this.edtZeitraumBis.Name = "edtZeitraumBis";
            this.edtZeitraumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZeitraumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZeitraumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZeitraumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZeitraumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtZeitraumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZeitraumBis.Properties.Appearance.Options.UseFont = true;
            this.edtZeitraumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtZeitraumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZeitraumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtZeitraumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZeitraumBis.Properties.ShowToday = false;
            this.edtZeitraumBis.Size = new System.Drawing.Size(100, 24);
            this.edtZeitraumBis.TabIndex = 16;
            // 
            // edtInklAbgeschlossen
            // 
            this.edtInklAbgeschlossen.EditValue = true;
            this.edtInklAbgeschlossen.Location = new System.Drawing.Point(160, 183);
            this.edtInklAbgeschlossen.Name = "edtInklAbgeschlossen";
            this.edtInklAbgeschlossen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInklAbgeschlossen.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklAbgeschlossen.Properties.Caption = "inkl. abgeschlossene Fälle";
            this.edtInklAbgeschlossen.Size = new System.Drawing.Size(271, 19);
            this.edtInklAbgeschlossen.TabIndex = 10;
            // 
            // edtInklArchiviert
            // 
            this.edtInklArchiviert.EditValue = true;
            this.edtInklArchiviert.Location = new System.Drawing.Point(160, 213);
            this.edtInklArchiviert.Name = "edtInklArchiviert";
            this.edtInklArchiviert.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInklArchiviert.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklArchiviert.Properties.Caption = "inkl. archivierte Fälle";
            this.edtInklArchiviert.Size = new System.Drawing.Size(271, 19);
            this.edtInklArchiviert.TabIndex = 12;
            // 
            // lblRueckerstattungTypX
            // 
            this.lblRueckerstattungTypX.Location = new System.Drawing.Point(32, 123);
            this.lblRueckerstattungTypX.Name = "lblRueckerstattungTypX";
            this.lblRueckerstattungTypX.Size = new System.Drawing.Size(115, 24);
            this.lblRueckerstattungTypX.TabIndex = 5;
            this.lblRueckerstattungTypX.Text = "Rückerstattungs-Typ";
            this.lblRueckerstattungTypX.UseCompatibleTextRendering = true;
            // 
            // edtRueckerstattungTyp
            // 
            this.edtRueckerstattungTyp.Location = new System.Drawing.Point(160, 123);
            this.edtRueckerstattungTyp.LOVName = "IkRueckerstattungTyp";
            this.edtRueckerstattungTyp.Name = "edtRueckerstattungTyp";
            this.edtRueckerstattungTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRueckerstattungTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRueckerstattungTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRueckerstattungTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtRueckerstattungTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRueckerstattungTyp.Properties.Appearance.Options.UseFont = true;
            this.edtRueckerstattungTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtRueckerstattungTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtRueckerstattungTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtRueckerstattungTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtRueckerstattungTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtRueckerstattungTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtRueckerstattungTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRueckerstattungTyp.Properties.NullText = "";
            this.edtRueckerstattungTyp.Properties.ShowFooter = false;
            this.edtRueckerstattungTyp.Properties.ShowHeader = false;
            this.edtRueckerstattungTyp.Size = new System.Drawing.Size(271, 24);
            this.edtRueckerstattungTyp.TabIndex = 6;
            // 
            // colAnzahlFaelle
            // 
            this.colAnzahlFaelle.Name = "colAnzahlFaelle";
            // 
            // colAnzahlGlaeubiger
            // 
            this.colAnzahlGlaeubiger.Name = "colAnzahlGlaeubiger";
            // 
            // colArchiv
            // 
            this.colArchiv.Name = "colArchiv";
            // 
            // colBemhung
            // 
            this.colBemhung.Name = "colBemhung";
            // 
            // colBemuehungText
            // 
            this.colBemuehungText.Name = "colBemuehungText";
            // 
            // colDatumAnpassenAb
            // 
            this.colDatumAnpassenAb.Name = "colDatumAnpassenAb";
            // 
            // colElterlicheSorge
            // 
            this.colElterlicheSorge.Name = "colElterlicheSorge";
            // 
            // colElterlicheSorgeBemerkung
            // 
            this.colElterlicheSorgeBemerkung.Name = "colElterlicheSorgeBemerkung";
            // 
            // colFaLeistungID
            // 
            this.colFaLeistungID.Name = "colFaLeistungID";
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            // 
            // colGlaeubiger
            // 
            this.colGlaeubiger.Name = "colGlaeubiger";
            // 
            // colGlubiger
            // 
            this.colGlubiger.Name = "colGlubiger";
            // 
            // colIkForderungID
            // 
            this.colIkForderungID.Name = "colIkForderungID";
            // 
            // colIkGlaeubigerID
            // 
            this.colIkGlaeubigerID.Name = "colIkGlaeubigerID";
            // 
            // colIkRechtstitelID
            // 
            this.colIkRechtstitelID.Name = "colIkRechtstitelID";
            // 
            // colInkassoFallName
            // 
            this.colInkassoFallName.Name = "colInkassoFallName";
            // 
            // colInkassoTyp
            // 
            this.colInkassoTyp.Name = "colInkassoTyp";
            // 
            // colmonatlBetrag
            // 
            this.colmonatlBetrag.Name = "colmonatlBetrag";
            // 
            // colMonatsBevorschussung
            // 
            this.colMonatsBevorschussung.Name = "colMonatsBevorschussung";
            // 
            // colRckerstattungtyp
            // 
            this.colRckerstattungtyp.Name = "colRckerstattungtyp";
            // 
            // colSAR
            // 
            this.colSAR.Name = "colSAR";
            // 
            // colSARName
            // 
            this.colSARName.Name = "colSARName";
            // 
            // colSchuldner
            // 
            this.colSchuldner.Name = "colSchuldner";
            // 
            // colStatus
            // 
            this.colStatus.Name = "colStatus";
            // 
            // colUnterart
            // 
            this.colUnterart.Name = "colUnterart";
            // 
            // colVerjaehrungAm
            // 
            this.colVerjaehrungAm.Name = "colVerjaehrungAm";
            // 
            // lblAbklaerungsart
            // 
            this.lblAbklaerungsart.Location = new System.Drawing.Point(32, 153);
            this.lblAbklaerungsart.Name = "lblAbklaerungsart";
            this.lblAbklaerungsart.Size = new System.Drawing.Size(115, 24);
            this.lblAbklaerungsart.TabIndex = 7;
            this.lblAbklaerungsart.Text = "Abklärungsart";
            this.lblAbklaerungsart.UseCompatibleTextRendering = true;
            // 
            // edtAbklaerungArt
            // 
            this.edtAbklaerungArt.Location = new System.Drawing.Point(160, 153);
            this.edtAbklaerungArt.LOVName = "IkAbklaerungArt";
            this.edtAbklaerungArt.Name = "edtAbklaerungArt";
            this.edtAbklaerungArt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbklaerungArt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbklaerungArt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbklaerungArt.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbklaerungArt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbklaerungArt.Properties.Appearance.Options.UseFont = true;
            this.edtAbklaerungArt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAbklaerungArt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbklaerungArt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAbklaerungArt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAbklaerungArt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtAbklaerungArt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtAbklaerungArt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbklaerungArt.Properties.NullText = "";
            this.edtAbklaerungArt.Properties.ShowFooter = false;
            this.edtAbklaerungArt.Properties.ShowHeader = false;
            this.edtAbklaerungArt.Size = new System.Drawing.Size(271, 24);
            this.edtAbklaerungArt.TabIndex = 8;
            // 
            // edtForderungenInZeitraum
            // 
            this.edtForderungenInZeitraum.EditValue = false;
            this.edtForderungenInZeitraum.Location = new System.Drawing.Point(140, 54);
            this.edtForderungenInZeitraum.Name = "edtForderungenInZeitraum";
            this.edtForderungenInZeitraum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtForderungenInZeitraum.Properties.Appearance.Options.UseBackColor = true;
            this.edtForderungenInZeitraum.Properties.Caption = "Forderungen in diesem Zeitraum";
            this.edtForderungenInZeitraum.Size = new System.Drawing.Size(271, 19);
            this.edtForderungenInZeitraum.TabIndex = 18;
            // 
            // edtZahlungenInZeitraum
            // 
            this.edtZahlungenInZeitraum.EditValue = false;
            this.edtZahlungenInZeitraum.Location = new System.Drawing.Point(140, 84);
            this.edtZahlungenInZeitraum.Name = "edtZahlungenInZeitraum";
            this.edtZahlungenInZeitraum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZahlungenInZeitraum.Properties.Appearance.Options.UseBackColor = true;
            this.edtZahlungenInZeitraum.Properties.Caption = "Zahlungen in diesem Zeitraum";
            this.edtZahlungenInZeitraum.Size = new System.Drawing.Size(271, 19);
            this.edtZahlungenInZeitraum.TabIndex = 20;
            // 
            // edtUnterstuetzungsendeBis
            // 
            this.edtUnterstuetzungsendeBis.EditValue = null;
            this.edtUnterstuetzungsendeBis.Location = new System.Drawing.Point(331, 368);
            this.edtUnterstuetzungsendeBis.Name = "edtUnterstuetzungsendeBis";
            this.edtUnterstuetzungsendeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUnterstuetzungsendeBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUnterstuetzungsendeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUnterstuetzungsendeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUnterstuetzungsendeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtUnterstuetzungsendeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUnterstuetzungsendeBis.Properties.Appearance.Options.UseFont = true;
            this.edtUnterstuetzungsendeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtUnterstuetzungsendeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtUnterstuetzungsendeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtUnterstuetzungsendeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUnterstuetzungsendeBis.Properties.ShowToday = false;
            this.edtUnterstuetzungsendeBis.Size = new System.Drawing.Size(100, 24);
            this.edtUnterstuetzungsendeBis.TabIndex = 24;
            // 
            // edtUnterstuetzungsendeVon
            // 
            this.edtUnterstuetzungsendeVon.EditValue = null;
            this.edtUnterstuetzungsendeVon.Location = new System.Drawing.Point(160, 368);
            this.edtUnterstuetzungsendeVon.Name = "edtUnterstuetzungsendeVon";
            this.edtUnterstuetzungsendeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUnterstuetzungsendeVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUnterstuetzungsendeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUnterstuetzungsendeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUnterstuetzungsendeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtUnterstuetzungsendeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUnterstuetzungsendeVon.Properties.Appearance.Options.UseFont = true;
            this.edtUnterstuetzungsendeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtUnterstuetzungsendeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtUnterstuetzungsendeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtUnterstuetzungsendeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUnterstuetzungsendeVon.Properties.ShowToday = false;
            this.edtUnterstuetzungsendeVon.Size = new System.Drawing.Size(100, 24);
            this.edtUnterstuetzungsendeVon.TabIndex = 22;
            // 
            // lblUnterstuetzungsendeBis
            // 
            this.lblUnterstuetzungsendeBis.Location = new System.Drawing.Point(284, 368);
            this.lblUnterstuetzungsendeBis.Name = "lblUnterstuetzungsendeBis";
            this.lblUnterstuetzungsendeBis.Size = new System.Drawing.Size(26, 24);
            this.lblUnterstuetzungsendeBis.TabIndex = 23;
            this.lblUnterstuetzungsendeBis.Text = "bis";
            this.lblUnterstuetzungsendeBis.UseCompatibleTextRendering = true;
            // 
            // lblUnterstuezungsende
            // 
            this.lblUnterstuezungsende.Location = new System.Drawing.Point(22, 368);
            this.lblUnterstuezungsende.Name = "lblUnterstuezungsende";
            this.lblUnterstuezungsende.Size = new System.Drawing.Size(139, 24);
            this.lblUnterstuezungsende.TabIndex = 21;
            this.lblUnterstuezungsende.Text = "Unterstützungsende von";
            this.lblUnterstuezungsende.UseCompatibleTextRendering = true;
            // 
            // tpgZusammenzug
            // 
            this.tpgZusammenzug.Controls.Add(this.grdQuery2);
            this.tpgZusammenzug.Location = new System.Drawing.Point(6, 6);
            this.tpgZusammenzug.Name = "tpgZusammenzug";
            this.tpgZusammenzug.Size = new System.Drawing.Size(772, 463);
            this.tpgZusammenzug.TabIndex = 1;
            this.tpgZusammenzug.Title = "Zusammenzug";
            // 
            // grdQuery2
            // 
            this.grdQuery2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.grdQuery2.EmbeddedNavigator.Name = "";
            this.grdQuery2.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdQuery2.Location = new System.Drawing.Point(3, 0);
            this.grdQuery2.MainView = this.grvQuery2;
            this.grdQuery2.Name = "grdQuery2";
            this.grdQuery2.Size = new System.Drawing.Size(766, 460);
            this.grdQuery2.TabIndex = 0;
            this.grdQuery2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvQuery2});
            // 
            // grvQuery2
            // 
            this.grvQuery2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery2.Appearance.Empty.Options.UseFont = true;
            this.grvQuery2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery2.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery2.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery2.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery2.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery2.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvQuery2.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvQuery2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery2.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery2.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery2.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery2.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery2.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery2.Appearance.Row.Options.UseFont = true;
            this.grvQuery2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery2.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery2.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery2.BestFitMaxRowCount = 1000;
            this.grvQuery2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvQuery2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvQuery2.GridControl = this.grdQuery2;
            this.grvQuery2.Name = "grvQuery2";
            this.grvQuery2.OptionsBehavior.Editable = false;
            this.grvQuery2.OptionsCustomization.AllowFilter = false;
            this.grvQuery2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery2.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery2.OptionsNavigation.UseTabKey = false;
            this.grvQuery2.OptionsView.ColumnAutoWidth = false;
            this.grvQuery2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery2.OptionsView.ShowGroupPanel = false;
            this.grvQuery2.OptionsView.ShowIndicator = false;
            // 
            // btnAbsprung
            // 
            this.btnAbsprung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbsprung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbsprung.Location = new System.Drawing.Point(654, 436);
            this.btnAbsprung.Name = "btnAbsprung";
            this.btnAbsprung.Size = new System.Drawing.Size(115, 24);
            this.btnAbsprung.TabIndex = 3;
            this.btnAbsprung.Text = "Schuldnermaske";
            this.btnAbsprung.UseVisualStyleBackColor = false;
            this.btnAbsprung.Click += new System.EventHandler(this.btnAbsprung_Click);
            // 
            // kissGroupBox1
            // 
            this.kissGroupBox1.Controls.Add(this.kissLabel1);
            this.kissGroupBox1.Controls.Add(this.edtZeitraumVon);
            this.kissGroupBox1.Controls.Add(this.lblZeitraumBis);
            this.kissGroupBox1.Controls.Add(this.edtZeitraumBis);
            this.kissGroupBox1.Controls.Add(this.edtForderungenInZeitraum);
            this.kissGroupBox1.Controls.Add(this.edtZahlungenInZeitraum);
            this.kissGroupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissGroupBox1.Location = new System.Drawing.Point(20, 238);
            this.kissGroupBox1.Name = "kissGroupBox1";
            this.kissGroupBox1.Size = new System.Drawing.Size(425, 115);
            this.kissGroupBox1.TabIndex = 25;
            this.kissGroupBox1.TabStop = false;
            this.kissGroupBox1.Text = "Zeitraum";
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(107, 20);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(26, 24);
            this.kissLabel1.TabIndex = 16;
            this.kissLabel1.Text = "von";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // CtlQueryIkRueckerstattungsgruende
            // 
            this.Name = "CtlQueryIkRueckerstattungsgruende";
            this.Size = new System.Drawing.Size(800, 539);
            this.Load += new System.EventHandler(this.CtlQueryIkRueckerstattungsgruende_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblinkassoTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklAbgeschlossen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklArchiviert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRueckerstattungTypX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRueckerstattungTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRueckerstattungTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbklaerungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbklaerungArt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbklaerungArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungenInZeitraum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungenInZeitraum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetzungsendeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetzungsendeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterstuetzungsendeBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterstuezungsende)).EndInit();
            this.tpgZusammenzug.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery2)).EndInit();
            this.kissGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gui.KissDateEdit edtUnterstuetzungsendeBis;
        private Gui.KissDateEdit edtUnterstuetzungsendeVon;
        private Gui.KissLabel lblUnterstuetzungsendeBis;
        private Gui.KissLabel lblUnterstuezungsende;
        private Gui.KissCheckEdit edtZahlungenInZeitraum;
        private Gui.KissCheckEdit edtForderungenInZeitraum;
        private Gui.KissLabel lblAbklaerungsart;
        private Gui.KissLookUpEdit edtAbklaerungArt;
        private SharpLibrary.WinControls.TabPageEx tpgZusammenzug;
        private Gui.KissButton btnAbsprung;
        private Gui.KissGrid grdQuery2;
        private DevExpress.XtraGrid.Views.Grid.GridView grvQuery2;
        private Gui.KissGroupBox kissGroupBox1;
        private Gui.KissLabel kissLabel1;
        private System.ComponentModel.IContainer components;
    }
}
