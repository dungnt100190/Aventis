
using DevExpress.XtraGrid.Views.Grid;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.PI
{
    partial class CtlQueryBDEStundenProLA
    {
        #region Fields

        #region Private Fields

        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtSucheAuswFaktura;
        private KiSS4.Gui.KissLookUpEdit edtSucheAuswPIAuftrag;
        private KiSS4.Gui.KissLookUpEdit edtSucheAuswProdukt;
        private KiSS4.Gui.KissLookUpEdit edtSucheAuswZLE;
        private KiSS4.Gui.KissLookUpEdit edtSucheKostenstelle;
        private KiSS4.Gui.KissCalcEdit edtSucheLanguageCode;
        private KiSS4.Gui.KissButtonEdit edtSucheLeistungsart;
        private KiSS4.Gui.KissLookUpEdit edtSucheMitarbeiter;
        private KiSS4.Gui.KissCalcEdit edtSucheUserID;
        private KiSS4.Gui.KissDateEdit edtSucheZeitraumBis;
        private KiSS4.Gui.KissDateEdit edtSucheZeitraumVon;
        private KissGrid grdKostenstelle;
        private KiSS4.Gui.KissGrid grdProMonat;
        private KiSS4.Gui.KissGrid grdZusammenfassung;
        private KiSS4.Gui.KissGroupBox grpAuswertung;
        private KiSS4.Gui.KissGroupBox grpHiddenSearch;
        private GridView grvKostenstelle;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProMonat;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZusammenfassung;
        private KiSS4.Gui.KissLabel lblSucheAuswFaktura;
        private KiSS4.Gui.KissLabel lblSucheAuswPIAuftrag;
        private KiSS4.Gui.KissLabel lblSucheAuswProdukt;
        private KiSS4.Gui.KissLabel lblSucheAuswZLE;
        private KiSS4.Gui.KissLabel lblSucheHiddenLanguageCode;
        private KiSS4.Gui.KissLabel lblSucheHiddenUserID;
        private KiSS4.Gui.KissLabel lblSucheKostenstelle;
        private KiSS4.Gui.KissLabel lblSucheLeistungsart;
        private KiSS4.Gui.KissLabel lblSucheMitarbeiter;
        private KiSS4.Gui.KissLabel lblSucheZeitraumBis;
        private KiSS4.Gui.KissLabel lblSucheZeitraumVon;
        private KiSS4.DB.SqlQuery qryListe2Zusammenfassung;
        private KiSS4.DB.SqlQuery qryListe3ProMonat;
        private SqlQuery qryListe4Kostenstelle;
        private SharpLibrary.WinControls.TabPageEx tpgKostenstelle;
        private SharpLibrary.WinControls.TabPageEx tpgProMonat;
        private SharpLibrary.WinControls.TabPageEx tpgZusammenfassung;

        #endregion

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBDEStundenProLA));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSucheKostenstelle = new KiSS4.Gui.KissLabel();
            this.edtSucheKostenstelle = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheZeitraumVon = new KiSS4.Gui.KissLabel();
            this.edtSucheZeitraumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheZeitraumBis = new KiSS4.Gui.KissLabel();
            this.edtSucheZeitraumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheLeistungsart = new KiSS4.Gui.KissLabel();
            this.edtSucheLeistungsart = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtSucheMitarbeiter = new KiSS4.Gui.KissLookUpEdit();
            this.grpHiddenSearch = new KiSS4.Gui.KissGroupBox();
            this.edtSucheLanguageCode = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheHiddenLanguageCode = new KiSS4.Gui.KissLabel();
            this.edtSucheUserID = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheHiddenUserID = new KiSS4.Gui.KissLabel();
            this.grpAuswertung = new KiSS4.Gui.KissGroupBox();
            this.edtSucheAuswFaktura = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheAuswFaktura = new KiSS4.Gui.KissLabel();
            this.edtSucheAuswPIAuftrag = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheAuswPIAuftrag = new KiSS4.Gui.KissLabel();
            this.edtSucheAuswProdukt = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheAuswProdukt = new KiSS4.Gui.KissLabel();
            this.edtSucheAuswZLE = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheAuswZLE = new KiSS4.Gui.KissLabel();
            this.tpgZusammenfassung = new SharpLibrary.WinControls.TabPageEx();
            this.grdZusammenfassung = new KiSS4.Gui.KissGrid();
            this.qryListe2Zusammenfassung = new KiSS4.DB.SqlQuery(this.components);
            this.grvZusammenfassung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpgProMonat = new SharpLibrary.WinControls.TabPageEx();
            this.grdProMonat = new KiSS4.Gui.KissGrid();
            this.qryListe3ProMonat = new KiSS4.DB.SqlQuery(this.components);
            this.grvProMonat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpgKostenstelle = new SharpLibrary.WinControls.TabPageEx();
            this.grdKostenstelle = new KiSS4.Gui.KissGrid();
            this.qryListe4Kostenstelle = new KiSS4.DB.SqlQuery(this.components);
            this.grvKostenstelle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtNurExport = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheZeitraumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZeitraumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheZeitraumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZeitraumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLeistungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).BeginInit();
            this.grpHiddenSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLanguageCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheHiddenLanguageCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheHiddenUserID)).BeginInit();
            this.grpAuswertung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuswFaktura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuswFaktura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAuswFaktura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuswPIAuftrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuswPIAuftrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAuswPIAuftrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuswProdukt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuswProdukt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAuswProdukt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuswZLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuswZLE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAuswZLE)).BeginInit();
            this.tpgZusammenfassung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdZusammenfassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe2Zusammenfassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZusammenfassung)).BeginInit();
            this.tpgProMonat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe3ProMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProMonat)).BeginInit();
            this.tpgKostenstelle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe4Kostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurExport.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = "SELECT [Error] = \'no statement yet, done in code\', \r\n       [BaPersonID$] = NULL";
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
            // 
            // 
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.Location = new System.Drawing.Point(3, 3);
            this.grdQuery1.Size = new System.Drawing.Size(766, 389);
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
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Size = new System.Drawing.Size(171, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgZusammenfassung);
            this.tabControlSearch.Controls.Add(this.tpgProMonat);
            this.tabControlSearch.Controls.Add(this.tpgKostenstelle);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgZusammenfassung,
            this.tpgProMonat,
            this.tpgKostenstelle});
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgKostenstelle, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgProMonat, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgZusammenfassung, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Title = "Klient/innen Mitarbeiter/innen";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtNurExport);
            this.tpgSuchen.Controls.Add(this.grpAuswertung);
            this.tpgSuchen.Controls.Add(this.grpHiddenSearch);
            this.tpgSuchen.Controls.Add(this.edtSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.lblSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.edtSucheLeistungsart);
            this.tpgSuchen.Controls.Add(this.lblSucheLeistungsart);
            this.tpgSuchen.Controls.Add(this.edtSucheZeitraumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheZeitraumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheZeitraumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheZeitraumVon);
            this.tpgSuchen.Controls.Add(this.edtSucheKostenstelle);
            this.tpgSuchen.Controls.Add(this.lblSucheKostenstelle);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKostenstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKostenstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheZeitraumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheZeitraumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheLeistungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheLeistungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.grpHiddenSearch, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.grpAuswertung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurExport, 0);
            // 
            // lblSucheKostenstelle
            // 
            this.lblSucheKostenstelle.Location = new System.Drawing.Point(31, 40);
            this.lblSucheKostenstelle.Name = "lblSucheKostenstelle";
            this.lblSucheKostenstelle.Size = new System.Drawing.Size(105, 24);
            this.lblSucheKostenstelle.TabIndex = 1;
            this.lblSucheKostenstelle.Text = "Kostenstelle";
            this.lblSucheKostenstelle.UseCompatibleTextRendering = true;
            // 
            // edtSucheKostenstelle
            // 
            this.edtSucheKostenstelle.Location = new System.Drawing.Point(142, 40);
            this.edtSucheKostenstelle.Name = "edtSucheKostenstelle";
            this.edtSucheKostenstelle.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKostenstelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKostenstelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKostenstelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKostenstelle.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheKostenstelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtSucheKostenstelle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKostenstelle.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheKostenstelle.Properties.DisplayMember = "Text";
            this.edtSucheKostenstelle.Properties.NullText = "";
            this.edtSucheKostenstelle.Properties.ShowFooter = false;
            this.edtSucheKostenstelle.Properties.ShowHeader = false;
            this.edtSucheKostenstelle.Properties.ValueMember = "Code";
            this.edtSucheKostenstelle.Size = new System.Drawing.Size(244, 24);
            this.edtSucheKostenstelle.TabIndex = 2;
            this.edtSucheKostenstelle.EditValueChanged += new System.EventHandler(this.edtSucheKostenstelle_EditValueChanged);
            // 
            // lblSucheZeitraumVon
            // 
            this.lblSucheZeitraumVon.Location = new System.Drawing.Point(31, 70);
            this.lblSucheZeitraumVon.Name = "lblSucheZeitraumVon";
            this.lblSucheZeitraumVon.Size = new System.Drawing.Size(105, 24);
            this.lblSucheZeitraumVon.TabIndex = 3;
            this.lblSucheZeitraumVon.Text = "Zeitraum von";
            this.lblSucheZeitraumVon.UseCompatibleTextRendering = true;
            // 
            // edtSucheZeitraumVon
            // 
            this.edtSucheZeitraumVon.EditValue = null;
            this.edtSucheZeitraumVon.Location = new System.Drawing.Point(142, 70);
            this.edtSucheZeitraumVon.Name = "edtSucheZeitraumVon";
            this.edtSucheZeitraumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheZeitraumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheZeitraumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheZeitraumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheZeitraumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheZeitraumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheZeitraumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheZeitraumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSucheZeitraumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheZeitraumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSucheZeitraumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheZeitraumVon.Properties.ShowToday = false;
            this.edtSucheZeitraumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheZeitraumVon.TabIndex = 4;
            // 
            // lblSucheZeitraumBis
            // 
            this.lblSucheZeitraumBis.Location = new System.Drawing.Point(248, 70);
            this.lblSucheZeitraumBis.Name = "lblSucheZeitraumBis";
            this.lblSucheZeitraumBis.Size = new System.Drawing.Size(32, 24);
            this.lblSucheZeitraumBis.TabIndex = 5;
            this.lblSucheZeitraumBis.Text = "bis";
            this.lblSucheZeitraumBis.UseCompatibleTextRendering = true;
            // 
            // edtSucheZeitraumBis
            // 
            this.edtSucheZeitraumBis.EditValue = null;
            this.edtSucheZeitraumBis.Location = new System.Drawing.Point(286, 70);
            this.edtSucheZeitraumBis.Name = "edtSucheZeitraumBis";
            this.edtSucheZeitraumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheZeitraumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheZeitraumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheZeitraumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheZeitraumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheZeitraumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheZeitraumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheZeitraumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSucheZeitraumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheZeitraumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSucheZeitraumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheZeitraumBis.Properties.ShowToday = false;
            this.edtSucheZeitraumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheZeitraumBis.TabIndex = 6;
            // 
            // lblSucheLeistungsart
            // 
            this.lblSucheLeistungsart.Location = new System.Drawing.Point(31, 248);
            this.lblSucheLeistungsart.Name = "lblSucheLeistungsart";
            this.lblSucheLeistungsart.Size = new System.Drawing.Size(105, 24);
            this.lblSucheLeistungsart.TabIndex = 7;
            this.lblSucheLeistungsart.Text = "Leistungsart";
            this.lblSucheLeistungsart.UseCompatibleTextRendering = true;
            // 
            // edtSucheLeistungsart
            // 
            this.edtSucheLeistungsart.Location = new System.Drawing.Point(142, 248);
            this.edtSucheLeistungsart.Name = "edtSucheLeistungsart";
            this.edtSucheLeistungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheLeistungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheLeistungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheLeistungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheLeistungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheLeistungsart.Properties.Appearance.Options.UseFont = true;
            this.edtSucheLeistungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSucheLeistungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSucheLeistungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheLeistungsart.Size = new System.Drawing.Size(244, 24);
            this.edtSucheLeistungsart.TabIndex = 8;
            this.edtSucheLeistungsart.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheLeistungsart_UserModifiedFld);
            // 
            // lblSucheMitarbeiter
            // 
            this.lblSucheMitarbeiter.Location = new System.Drawing.Point(31, 278);
            this.lblSucheMitarbeiter.Name = "lblSucheMitarbeiter";
            this.lblSucheMitarbeiter.Size = new System.Drawing.Size(105, 24);
            this.lblSucheMitarbeiter.TabIndex = 9;
            this.lblSucheMitarbeiter.Text = "Mitarbeiter/in";
            this.lblSucheMitarbeiter.UseCompatibleTextRendering = true;
            // 
            // edtSucheMitarbeiter
            // 
            this.edtSucheMitarbeiter.Location = new System.Drawing.Point(142, 278);
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
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSucheMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMitarbeiter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheMitarbeiter.Properties.DisplayMember = "Text";
            this.edtSucheMitarbeiter.Properties.NullText = "";
            this.edtSucheMitarbeiter.Properties.ShowFooter = false;
            this.edtSucheMitarbeiter.Properties.ShowHeader = false;
            this.edtSucheMitarbeiter.Properties.ValueMember = "Code";
            this.edtSucheMitarbeiter.Size = new System.Drawing.Size(244, 24);
            this.edtSucheMitarbeiter.TabIndex = 10;
            // 
            // grpHiddenSearch
            // 
            this.grpHiddenSearch.Controls.Add(this.edtSucheLanguageCode);
            this.grpHiddenSearch.Controls.Add(this.lblSucheHiddenLanguageCode);
            this.grpHiddenSearch.Controls.Add(this.edtSucheUserID);
            this.grpHiddenSearch.Controls.Add(this.lblSucheHiddenUserID);
            this.grpHiddenSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpHiddenSearch.Location = new System.Drawing.Point(555, 337);
            this.grpHiddenSearch.Name = "grpHiddenSearch";
            this.grpHiddenSearch.Size = new System.Drawing.Size(213, 84);
            this.grpHiddenSearch.TabIndex = 11;
            this.grpHiddenSearch.TabStop = false;
            this.grpHiddenSearch.Text = "Hidden Fields";
            this.grpHiddenSearch.UseCompatibleTextRendering = true;
            this.grpHiddenSearch.Visible = false;
            // 
            // edtSucheLanguageCode
            // 
            this.edtSucheLanguageCode.Location = new System.Drawing.Point(107, 50);
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
            this.edtSucheLanguageCode.TabIndex = 3;
            // 
            // lblSucheHiddenLanguageCode
            // 
            this.lblSucheHiddenLanguageCode.Location = new System.Drawing.Point(6, 50);
            this.lblSucheHiddenLanguageCode.Name = "lblSucheHiddenLanguageCode";
            this.lblSucheHiddenLanguageCode.Size = new System.Drawing.Size(95, 24);
            this.lblSucheHiddenLanguageCode.TabIndex = 2;
            this.lblSucheHiddenLanguageCode.Text = "LanguageCode";
            this.lblSucheHiddenLanguageCode.UseCompatibleTextRendering = true;
            // 
            // edtSucheUserID
            // 
            this.edtSucheUserID.Location = new System.Drawing.Point(107, 20);
            this.edtSucheUserID.Name = "edtSucheUserID";
            this.edtSucheUserID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheUserID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheUserID.Size = new System.Drawing.Size(100, 24);
            this.edtSucheUserID.TabIndex = 1;
            // 
            // lblSucheHiddenUserID
            // 
            this.lblSucheHiddenUserID.Location = new System.Drawing.Point(6, 20);
            this.lblSucheHiddenUserID.Name = "lblSucheHiddenUserID";
            this.lblSucheHiddenUserID.Size = new System.Drawing.Size(95, 24);
            this.lblSucheHiddenUserID.TabIndex = 0;
            this.lblSucheHiddenUserID.Text = "UserID";
            this.lblSucheHiddenUserID.UseCompatibleTextRendering = true;
            // 
            // grpAuswertung
            // 
            this.grpAuswertung.Controls.Add(this.edtSucheAuswFaktura);
            this.grpAuswertung.Controls.Add(this.lblSucheAuswFaktura);
            this.grpAuswertung.Controls.Add(this.edtSucheAuswPIAuftrag);
            this.grpAuswertung.Controls.Add(this.lblSucheAuswPIAuftrag);
            this.grpAuswertung.Controls.Add(this.edtSucheAuswProdukt);
            this.grpAuswertung.Controls.Add(this.lblSucheAuswProdukt);
            this.grpAuswertung.Controls.Add(this.edtSucheAuswZLE);
            this.grpAuswertung.Controls.Add(this.lblSucheAuswZLE);
            this.grpAuswertung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpAuswertung.Location = new System.Drawing.Point(31, 100);
            this.grpAuswertung.Name = "grpAuswertung";
            this.grpAuswertung.Size = new System.Drawing.Size(355, 142);
            this.grpAuswertung.TabIndex = 12;
            this.grpAuswertung.TabStop = false;
            this.grpAuswertung.Text = "Abfragegruppen";
            this.grpAuswertung.UseCompatibleTextRendering = true;
            // 
            // edtSucheAuswFaktura
            // 
            this.edtSucheAuswFaktura.Location = new System.Drawing.Point(111, 108);
            this.edtSucheAuswFaktura.LOVName = "BDELeistungsartAuswFaktura";
            this.edtSucheAuswFaktura.Name = "edtSucheAuswFaktura";
            this.edtSucheAuswFaktura.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAuswFaktura.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAuswFaktura.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAuswFaktura.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAuswFaktura.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAuswFaktura.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAuswFaktura.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheAuswFaktura.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAuswFaktura.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheAuswFaktura.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheAuswFaktura.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheAuswFaktura.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheAuswFaktura.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheAuswFaktura.Properties.NullText = "";
            this.edtSucheAuswFaktura.Properties.ShowFooter = false;
            this.edtSucheAuswFaktura.Properties.ShowHeader = false;
            this.edtSucheAuswFaktura.Size = new System.Drawing.Size(232, 24);
            this.edtSucheAuswFaktura.TabIndex = 7;
            // 
            // lblSucheAuswFaktura
            // 
            this.lblSucheAuswFaktura.Location = new System.Drawing.Point(9, 108);
            this.lblSucheAuswFaktura.Name = "lblSucheAuswFaktura";
            this.lblSucheAuswFaktura.Size = new System.Drawing.Size(96, 24);
            this.lblSucheAuswFaktura.TabIndex = 6;
            this.lblSucheAuswFaktura.Text = "Faktura";
            this.lblSucheAuswFaktura.UseCompatibleTextRendering = true;
            // 
            // edtSucheAuswPIAuftrag
            // 
            this.edtSucheAuswPIAuftrag.Location = new System.Drawing.Point(111, 78);
            this.edtSucheAuswPIAuftrag.LOVName = "BDELeistungsartAuswPIAuftrag";
            this.edtSucheAuswPIAuftrag.Name = "edtSucheAuswPIAuftrag";
            this.edtSucheAuswPIAuftrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAuswPIAuftrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAuswPIAuftrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAuswPIAuftrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAuswPIAuftrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAuswPIAuftrag.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAuswPIAuftrag.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheAuswPIAuftrag.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAuswPIAuftrag.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheAuswPIAuftrag.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheAuswPIAuftrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheAuswPIAuftrag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheAuswPIAuftrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheAuswPIAuftrag.Properties.NullText = "";
            this.edtSucheAuswPIAuftrag.Properties.ShowFooter = false;
            this.edtSucheAuswPIAuftrag.Properties.ShowHeader = false;
            this.edtSucheAuswPIAuftrag.Size = new System.Drawing.Size(232, 24);
            this.edtSucheAuswPIAuftrag.TabIndex = 5;
            // 
            // lblSucheAuswPIAuftrag
            // 
            this.lblSucheAuswPIAuftrag.Location = new System.Drawing.Point(9, 78);
            this.lblSucheAuswPIAuftrag.Name = "lblSucheAuswPIAuftrag";
            this.lblSucheAuswPIAuftrag.Size = new System.Drawing.Size(96, 24);
            this.lblSucheAuswPIAuftrag.TabIndex = 4;
            this.lblSucheAuswPIAuftrag.Text = "PI-Auftrag";
            this.lblSucheAuswPIAuftrag.UseCompatibleTextRendering = true;
            // 
            // edtSucheAuswProdukt
            // 
            this.edtSucheAuswProdukt.Location = new System.Drawing.Point(111, 48);
            this.edtSucheAuswProdukt.LOVName = "BDELeistungsartAuswProdukt";
            this.edtSucheAuswProdukt.Name = "edtSucheAuswProdukt";
            this.edtSucheAuswProdukt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAuswProdukt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAuswProdukt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAuswProdukt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAuswProdukt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAuswProdukt.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAuswProdukt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheAuswProdukt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAuswProdukt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheAuswProdukt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheAuswProdukt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheAuswProdukt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheAuswProdukt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheAuswProdukt.Properties.NullText = "";
            this.edtSucheAuswProdukt.Properties.ShowFooter = false;
            this.edtSucheAuswProdukt.Properties.ShowHeader = false;
            this.edtSucheAuswProdukt.Size = new System.Drawing.Size(232, 24);
            this.edtSucheAuswProdukt.TabIndex = 3;
            // 
            // lblSucheAuswProdukt
            // 
            this.lblSucheAuswProdukt.Location = new System.Drawing.Point(9, 48);
            this.lblSucheAuswProdukt.Name = "lblSucheAuswProdukt";
            this.lblSucheAuswProdukt.Size = new System.Drawing.Size(96, 24);
            this.lblSucheAuswProdukt.TabIndex = 2;
            this.lblSucheAuswProdukt.Text = "Produkt";
            this.lblSucheAuswProdukt.UseCompatibleTextRendering = true;
            // 
            // edtSucheAuswZLE
            // 
            this.edtSucheAuswZLE.Location = new System.Drawing.Point(111, 18);
            this.edtSucheAuswZLE.LOVName = "BDELeistungsartAuswDienstleistung";
            this.edtSucheAuswZLE.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtSucheAuswZLE.Name = "edtSucheAuswZLE";
            this.edtSucheAuswZLE.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAuswZLE.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAuswZLE.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAuswZLE.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAuswZLE.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAuswZLE.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAuswZLE.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheAuswZLE.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAuswZLE.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheAuswZLE.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheAuswZLE.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheAuswZLE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheAuswZLE.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheAuswZLE.Properties.NullText = "";
            this.edtSucheAuswZLE.Properties.ShowFooter = false;
            this.edtSucheAuswZLE.Properties.ShowHeader = false;
            this.edtSucheAuswZLE.Size = new System.Drawing.Size(232, 24);
            this.edtSucheAuswZLE.TabIndex = 1;
            // 
            // lblSucheAuswZLE
            // 
            this.lblSucheAuswZLE.Location = new System.Drawing.Point(9, 18);
            this.lblSucheAuswZLE.Name = "lblSucheAuswZLE";
            this.lblSucheAuswZLE.Size = new System.Drawing.Size(96, 24);
            this.lblSucheAuswZLE.TabIndex = 0;
            this.lblSucheAuswZLE.Text = "ZLE";
            this.lblSucheAuswZLE.UseCompatibleTextRendering = true;
            // 
            // tpgZusammenfassung
            // 
            this.tpgZusammenfassung.Controls.Add(this.grdZusammenfassung);
            this.tpgZusammenfassung.Location = new System.Drawing.Point(6, 6);
            this.tpgZusammenfassung.Name = "tpgZusammenfassung";
            this.tpgZusammenfassung.Size = new System.Drawing.Size(772, 424);
            this.tpgZusammenfassung.TabIndex = 1;
            this.tpgZusammenfassung.Title = "Zusammenfassung";
            // 
            // grdZusammenfassung
            // 
            this.grdZusammenfassung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdZusammenfassung.DataSource = this.qryListe2Zusammenfassung;
            // 
            // 
            // 
            this.grdZusammenfassung.EmbeddedNavigator.Name = "";
            this.grdZusammenfassung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZusammenfassung.Location = new System.Drawing.Point(3, 3);
            this.grdZusammenfassung.MainView = this.grvZusammenfassung;
            this.grdZusammenfassung.Name = "grdZusammenfassung";
            this.grdZusammenfassung.Size = new System.Drawing.Size(766, 418);
            this.grdZusammenfassung.TabIndex = 0;
            this.grdZusammenfassung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZusammenfassung});
            // 
            // qryListe2Zusammenfassung
            // 
            this.qryListe2Zusammenfassung.FillTimeOut = 300;
            this.qryListe2Zusammenfassung.HostControl = this;
            this.qryListe2Zusammenfassung.SelectStatement = "SELECT [Error] = \'no statement yet, done in code\', \r\n       [BaPersonID$] = NULL";
            // 
            // grvZusammenfassung
            // 
            this.grvZusammenfassung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZusammenfassung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZusammenfassung.Appearance.Empty.Options.UseBackColor = true;
            this.grvZusammenfassung.Appearance.Empty.Options.UseFont = true;
            this.grvZusammenfassung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZusammenfassung.Appearance.EvenRow.Options.UseFont = true;
            this.grvZusammenfassung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZusammenfassung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZusammenfassung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZusammenfassung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZusammenfassung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZusammenfassung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZusammenfassung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZusammenfassung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZusammenfassung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZusammenfassung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZusammenfassung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZusammenfassung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZusammenfassung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZusammenfassung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZusammenfassung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZusammenfassung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZusammenfassung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZusammenfassung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZusammenfassung.Appearance.GroupRow.Options.UseFont = true;
            this.grvZusammenfassung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZusammenfassung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZusammenfassung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZusammenfassung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZusammenfassung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZusammenfassung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZusammenfassung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZusammenfassung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZusammenfassung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZusammenfassung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZusammenfassung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZusammenfassung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZusammenfassung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZusammenfassung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZusammenfassung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZusammenfassung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZusammenfassung.Appearance.OddRow.Options.UseFont = true;
            this.grvZusammenfassung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZusammenfassung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZusammenfassung.Appearance.Row.Options.UseBackColor = true;
            this.grvZusammenfassung.Appearance.Row.Options.UseFont = true;
            this.grvZusammenfassung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZusammenfassung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZusammenfassung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZusammenfassung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZusammenfassung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZusammenfassung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZusammenfassung.GridControl = this.grdZusammenfassung;
            this.grvZusammenfassung.Name = "grvZusammenfassung";
            this.grvZusammenfassung.OptionsBehavior.Editable = false;
            this.grvZusammenfassung.OptionsCustomization.AllowFilter = false;
            this.grvZusammenfassung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZusammenfassung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZusammenfassung.OptionsNavigation.UseTabKey = false;
            this.grvZusammenfassung.OptionsView.ColumnAutoWidth = false;
            this.grvZusammenfassung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZusammenfassung.OptionsView.ShowGroupPanel = false;
            this.grvZusammenfassung.OptionsView.ShowIndicator = false;
            // 
            // tpgProMonat
            // 
            this.tpgProMonat.Controls.Add(this.grdProMonat);
            this.tpgProMonat.Location = new System.Drawing.Point(6, 6);
            this.tpgProMonat.Name = "tpgProMonat";
            this.tpgProMonat.Size = new System.Drawing.Size(772, 424);
            this.tpgProMonat.TabIndex = 2;
            this.tpgProMonat.Title = "Pro Monat";
            // 
            // grdProMonat
            // 
            this.grdProMonat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdProMonat.DataSource = this.qryListe3ProMonat;
            // 
            // 
            // 
            this.grdProMonat.EmbeddedNavigator.Name = "";
            this.grdProMonat.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdProMonat.Location = new System.Drawing.Point(3, 3);
            this.grdProMonat.MainView = this.grvProMonat;
            this.grdProMonat.Name = "grdProMonat";
            this.grdProMonat.Size = new System.Drawing.Size(766, 418);
            this.grdProMonat.TabIndex = 1;
            this.grdProMonat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProMonat});
            // 
            // qryListe3ProMonat
            // 
            this.qryListe3ProMonat.FillTimeOut = 300;
            this.qryListe3ProMonat.HostControl = this;
            this.qryListe3ProMonat.SelectStatement = "SELECT [Error] = \'no statement yet, done in code\', \r\n       [BaPersonID$] = NULL";
            // 
            // grvProMonat
            // 
            this.grvProMonat.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvProMonat.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProMonat.Appearance.Empty.Options.UseBackColor = true;
            this.grvProMonat.Appearance.Empty.Options.UseFont = true;
            this.grvProMonat.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProMonat.Appearance.EvenRow.Options.UseFont = true;
            this.grvProMonat.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvProMonat.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProMonat.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvProMonat.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvProMonat.Appearance.FocusedCell.Options.UseFont = true;
            this.grvProMonat.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvProMonat.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvProMonat.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProMonat.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvProMonat.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvProMonat.Appearance.FocusedRow.Options.UseFont = true;
            this.grvProMonat.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvProMonat.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProMonat.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvProMonat.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProMonat.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvProMonat.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvProMonat.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvProMonat.Appearance.GroupRow.Options.UseFont = true;
            this.grvProMonat.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvProMonat.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvProMonat.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvProMonat.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvProMonat.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvProMonat.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvProMonat.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvProMonat.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvProMonat.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProMonat.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvProMonat.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvProMonat.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvProMonat.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvProMonat.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvProMonat.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvProMonat.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProMonat.Appearance.OddRow.Options.UseFont = true;
            this.grvProMonat.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvProMonat.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProMonat.Appearance.Row.Options.UseBackColor = true;
            this.grvProMonat.Appearance.Row.Options.UseFont = true;
            this.grvProMonat.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProMonat.Appearance.SelectedRow.Options.UseFont = true;
            this.grvProMonat.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvProMonat.Appearance.VertLine.Options.UseBackColor = true;
            this.grvProMonat.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvProMonat.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvProMonat.GridControl = this.grdProMonat;
            this.grvProMonat.Name = "grvProMonat";
            this.grvProMonat.OptionsBehavior.Editable = false;
            this.grvProMonat.OptionsCustomization.AllowFilter = false;
            this.grvProMonat.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvProMonat.OptionsNavigation.AutoFocusNewRow = true;
            this.grvProMonat.OptionsNavigation.UseTabKey = false;
            this.grvProMonat.OptionsView.ColumnAutoWidth = false;
            this.grvProMonat.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvProMonat.OptionsView.ShowGroupPanel = false;
            this.grvProMonat.OptionsView.ShowIndicator = false;
            // 
            // tpgKostenstelle
            // 
            this.tpgKostenstelle.Controls.Add(this.grdKostenstelle);
            this.tpgKostenstelle.Location = new System.Drawing.Point(6, 6);
            this.tpgKostenstelle.Name = "tpgKostenstelle";
            this.tpgKostenstelle.Size = new System.Drawing.Size(772, 424);
            this.tpgKostenstelle.TabIndex = 3;
            this.tpgKostenstelle.Title = "Kostenstelle";
            // 
            // grdKostenstelle
            // 
            this.grdKostenstelle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKostenstelle.DataSource = this.qryListe4Kostenstelle;
            // 
            // 
            // 
            this.grdKostenstelle.EmbeddedNavigator.Name = "";
            this.grdKostenstelle.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKostenstelle.Location = new System.Drawing.Point(3, 3);
            this.grdKostenstelle.MainView = this.grvKostenstelle;
            this.grdKostenstelle.Name = "grdKostenstelle";
            this.grdKostenstelle.Size = new System.Drawing.Size(766, 418);
            this.grdKostenstelle.TabIndex = 2;
            this.grdKostenstelle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKostenstelle});
            // 
            // qryListe4Kostenstelle
            // 
            this.qryListe4Kostenstelle.FillTimeOut = 300;
            this.qryListe4Kostenstelle.HostControl = this;
            this.qryListe4Kostenstelle.SelectStatement = "SELECT [Error] = \'no statement yet, done in code\', \r\n       [BaPersonID$] = NULL";
            // 
            // grvKostenstelle
            // 
            this.grvKostenstelle.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKostenstelle.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstelle.Appearance.Empty.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.Empty.Options.UseFont = true;
            this.grvKostenstelle.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstelle.Appearance.EvenRow.Options.UseFont = true;
            this.grvKostenstelle.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKostenstelle.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstelle.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKostenstelle.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKostenstelle.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKostenstelle.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKostenstelle.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstelle.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKostenstelle.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKostenstelle.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKostenstelle.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKostenstelle.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKostenstelle.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKostenstelle.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKostenstelle.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.GroupRow.Options.UseFont = true;
            this.grvKostenstelle.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKostenstelle.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKostenstelle.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKostenstelle.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKostenstelle.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKostenstelle.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKostenstelle.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKostenstelle.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstelle.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKostenstelle.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKostenstelle.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKostenstelle.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKostenstelle.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstelle.Appearance.OddRow.Options.UseFont = true;
            this.grvKostenstelle.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKostenstelle.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstelle.Appearance.Row.Options.UseBackColor = true;
            this.grvKostenstelle.Appearance.Row.Options.UseFont = true;
            this.grvKostenstelle.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKostenstelle.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKostenstelle.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKostenstelle.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKostenstelle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKostenstelle.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKostenstelle.GridControl = this.grdKostenstelle;
            this.grvKostenstelle.Name = "grvKostenstelle";
            this.grvKostenstelle.OptionsBehavior.Editable = false;
            this.grvKostenstelle.OptionsCustomization.AllowFilter = false;
            this.grvKostenstelle.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKostenstelle.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKostenstelle.OptionsNavigation.UseTabKey = false;
            this.grvKostenstelle.OptionsView.ColumnAutoWidth = false;
            this.grvKostenstelle.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKostenstelle.OptionsView.ShowGroupPanel = false;
            this.grvKostenstelle.OptionsView.ShowIndicator = false;
            // 
            // edtNurExport
            // 
            this.edtNurExport.EditValue = true;
            this.edtNurExport.Location = new System.Drawing.Point(31, 314);
            this.edtNurExport.Name = "edtNurExport";
            this.edtNurExport.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurExport.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurExport.Properties.Caption = "Nur zu exportierende Daten";
            this.edtNurExport.Size = new System.Drawing.Size(211, 19);
            this.edtNurExport.TabIndex = 14;
            // 
            // CtlQueryBDEStundenProLA
            // 
            this.Name = "CtlQueryBDEStundenProLA";
            this.Load += new System.EventHandler(this.CtlQueryBDEStundenProLA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheZeitraumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZeitraumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheZeitraumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZeitraumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLeistungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).EndInit();
            this.grpHiddenSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLanguageCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheHiddenLanguageCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheHiddenUserID)).EndInit();
            this.grpAuswertung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuswFaktura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuswFaktura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAuswFaktura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuswPIAuftrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuswPIAuftrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAuswPIAuftrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuswProdukt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuswProdukt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAuswProdukt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuswZLE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuswZLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAuswZLE)).EndInit();
            this.tpgZusammenfassung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdZusammenfassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe2Zusammenfassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZusammenfassung)).EndInit();
            this.tpgProMonat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe3ProMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProMonat)).EndInit();
            this.tpgKostenstelle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe4Kostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurExport.Properties)).EndInit();
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

        private KissCheckEdit edtNurExport;

    }
}
