using System;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    partial class CtlQueryKaControllingJobtimal
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAblehnungsgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colAbschluss;
        private DevExpress.XtraGrid.Columns.GridColumn colAbschlussgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colAnfrage;
        private DevExpress.XtraGrid.Columns.GridColumn colAnmeldung;
        private DevExpress.XtraGrid.Columns.GridColumn colBerufsabschluss;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrieb;
        private DevExpress.XtraGrid.Columns.GridColumn colCoachinggesprche;
        private DevExpress.XtraGrid.Columns.GridColumn colDeutschkenntnisse;
        private DevExpress.XtraGrid.Columns.GridColumn colDossieranCoach;
        private DevExpress.XtraGrid.Columns.GridColumn coldurch;
        private DevExpress.XtraGrid.Columns.GridColumn colEingang;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzab;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzende;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzplatz;
        private DevExpress.XtraGrid.Columns.GridColumn colEinstze;
        private DevExpress.XtraGrid.Columns.GridColumn colErffnung;
        private DevExpress.XtraGrid.Columns.GridColumn colErffnungPhase;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colGesundheit;
        private DevExpress.XtraGrid.Columns.GridColumn colGesundheitkrperlich;
        private DevExpress.XtraGrid.Columns.GridColumn colGesundheitpsychisch;
        private DevExpress.XtraGrid.Columns.GridColumn colInternerBetrieb;
        private DevExpress.XtraGrid.Columns.GridColumn colIntervention;
        private DevExpress.XtraGrid.Columns.GridColumn colKategorie;
        private DevExpress.XtraGrid.Columns.GridColumn colMahnung;
        private DevExpress.XtraGrid.Columns.GridColumn colMassnahme;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivation;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colPensum;
        private DevExpress.XtraGrid.Columns.GridColumn colPersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colpriorisiert;
        private DevExpress.XtraGrid.Columns.GridColumn colSucht;
        private DevExpress.XtraGrid.Columns.GridColumn coltest;
        private DevExpress.XtraGrid.Columns.GridColumn colVermittelbarkeit;
        private DevExpress.XtraGrid.Columns.GridColumn colvermittelt;
        private DevExpress.XtraGrid.Columns.GridColumn colVermittlungsgesprch;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colVorschlag;
        private DevExpress.XtraGrid.Columns.GridColumn colVorschlagerfasst;
        private DevExpress.XtraGrid.Columns.GridColumn colVorschlge;
        private DevExpress.XtraGrid.Columns.GridColumn colZBanSD;
        private DevExpress.XtraGrid.Columns.GridColumn colZustndig;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlGotoFall ctlGotoFall1;
        private KiSS4.Common.CtlGotoFall ctlGotoFallStelleBI;
        private KiSS4.Gui.KissLookUpEdit edtStatusHeute;
        private KiSS4.Gui.KissLookUpEdit edtSucheNach;
        private KiSS4.Gui.KissDateEdit edtZeitraumBis;
        private KiSS4.Gui.KissDateEdit edtZeitraumVon;
        private KiSS4.Gui.KissButtonEdit edtZustaendigKA;
        private KiSS4.Gui.KissGrid grdVorschlaege;
        private KiSS4.Gui.KissGrid grdZwischenbericht;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVorschlaege;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZwischenbericht;
        private KiSS4.Gui.KissLabel lblStatusHeute;
        private KiSS4.Gui.KissLabel lblSucheNach;
        private KiSS4.Gui.KissLabel lblZeitraumBis;
        private KiSS4.Gui.KissLabel lblZeitraumVon;
        private KiSS4.Gui.KissLabel lblZustaendigKA;
        private KiSS4.DB.SqlQuery qryVorschlaege;
        private KiSS4.DB.SqlQuery qryVertrag;
        private SharpLibrary.WinControls.TabPageEx tpgVorschlaege;
        private SharpLibrary.WinControls.TabPageEx tpgVertrag;

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaControllingJobtimal));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tpgVorschlaege = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFallStelleBI = new KiSS4.Common.CtlGotoFall();
            this.qryVorschlaege = new KiSS4.DB.SqlQuery(this.components);
            this.grdVorschlaege = new KiSS4.Gui.KissGrid();
            this.grvVorschlaege = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpgVertrag = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFall1 = new KiSS4.Common.CtlGotoFall();
            this.qryVertrag = new KiSS4.DB.SqlQuery(this.components);
            this.grdZwischenbericht = new KiSS4.Gui.KissGrid();
            this.grvZwischenbericht = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtZustaendigKA = new KiSS4.Gui.KissButtonEdit();
            this.edtSucheNach = new KiSS4.Gui.KissLookUpEdit();
            this.edtStatusHeute = new KiSS4.Gui.KissLookUpEdit();
            this.edtZeitraumVon = new KiSS4.Gui.KissDateEdit();
            this.edtZeitraumBis = new KiSS4.Gui.KissDateEdit();
            this.lblZustaendigKA = new KiSS4.Gui.KissLabel();
            this.lblSucheNach = new KiSS4.Gui.KissLabel();
            this.lblStatusHeute = new KiSS4.Gui.KissLabel();
            this.lblZeitraumVon = new KiSS4.Gui.KissLabel();
            this.lblZeitraumBis = new KiSS4.Gui.KissLabel();
            this.colAblehnungsgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbschluss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbschlussgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnfrage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnmeldung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBerufsabschluss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrieb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoachinggesprche = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeutschkenntnisse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDossieranCoach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldurch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEingang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzende = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzplatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinstze = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErffnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErffnungPhase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesundheit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesundheitkrperlich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesundheitpsychisch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colvermittelt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKategorie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInternerBetrieb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntervention = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMahnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMassnahme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPensum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpriorisiert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltest = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVermittelbarkeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVermittlungsgesprch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorschlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorschlagerfasst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorschlge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZBanSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZustndig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.tpgVorschlaege.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryVorschlaege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVorschlaege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVorschlaege)).BeginInit();
            this.tpgVertrag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryVertrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZwischenbericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZwischenbericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeute.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusHeute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgVertrag);
            this.tabControlSearch.Controls.Add(this.tpgVorschlaege);
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgVorschlaege,
            this.tpgVertrag});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgVorschlaege, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgVertrag, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Title = "Daten STES";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblZeitraumBis);
            this.tpgSuchen.Controls.Add(this.lblZeitraumVon);
            this.tpgSuchen.Controls.Add(this.lblStatusHeute);
            this.tpgSuchen.Controls.Add(this.lblSucheNach);
            this.tpgSuchen.Controls.Add(this.lblZustaendigKA);
            this.tpgSuchen.Controls.Add(this.edtZeitraumBis);
            this.tpgSuchen.Controls.Add(this.edtZeitraumVon);
            this.tpgSuchen.Controls.Add(this.edtStatusHeute);
            this.tpgSuchen.Controls.Add(this.edtSucheNach);
            this.tpgSuchen.Controls.Add(this.edtZustaendigKA);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.TabIndex = 3;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZustaendigKA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheNach, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStatusHeute, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZeitraumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZustaendigKA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheNach, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStatusHeute, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumBis, 0);
            // 
            // tpgVorschlaege
            // 
            this.tpgVorschlaege.Controls.Add(this.ctlGotoFallStelleBI);
            this.tpgVorschlaege.Controls.Add(this.grdVorschlaege);
            this.tpgVorschlaege.Location = new System.Drawing.Point(6, 6);
            this.tpgVorschlaege.Name = "tpgVorschlaege";
            this.tpgVorschlaege.Size = new System.Drawing.Size(772, 424);
            this.tpgVorschlaege.TabIndex = 1;
            this.tpgVorschlaege.Title = "Einsätze";
            // 
            // ctlGotoFallStelleBI
            // 
            this.ctlGotoFallStelleBI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallStelleBI.DataMember = "BaPersonID$";
            this.ctlGotoFallStelleBI.DataSource = this.qryVorschlaege;
            this.ctlGotoFallStelleBI.Location = new System.Drawing.Point(3, 395);
            this.ctlGotoFallStelleBI.Name = "ctlGotoFallStelleBI";
            this.ctlGotoFallStelleBI.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFallStelleBI.TabIndex = 3;
            // 
            // qryVorschlaege
            // 
            this.qryVorschlaege.HostControl = this;
            this.qryVorschlaege.IsIdentityInsert = false;
            this.qryVorschlaege.SelectStatement = resources.GetString("qryVorschlaege.SelectStatement");
            // 
            // grdVorschlaege
            // 
            this.grdVorschlaege.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVorschlaege.ColumnFilterActivated = true;
            this.grdVorschlaege.DataSource = this.qryVorschlaege;
            // 
            // 
            // 
            this.grdVorschlaege.EmbeddedNavigator.Name = "";
            this.grdVorschlaege.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVorschlaege.Location = new System.Drawing.Point(3, 0);
            this.grdVorschlaege.MainView = this.grvVorschlaege;
            this.grdVorschlaege.Name = "grdVorschlaege";
            this.grdVorschlaege.Size = new System.Drawing.Size(766, 392);
            this.grdVorschlaege.TabIndex = 2;
            this.grdVorschlaege.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVorschlaege});
            // 
            // grvVorschlaege
            // 
            this.grvVorschlaege.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVorschlaege.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVorschlaege.Appearance.Empty.Options.UseBackColor = true;
            this.grvVorschlaege.Appearance.Empty.Options.UseFont = true;
            this.grvVorschlaege.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVorschlaege.Appearance.EvenRow.Options.UseFont = true;
            this.grvVorschlaege.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVorschlaege.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVorschlaege.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVorschlaege.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVorschlaege.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVorschlaege.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVorschlaege.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVorschlaege.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVorschlaege.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVorschlaege.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVorschlaege.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVorschlaege.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVorschlaege.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVorschlaege.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVorschlaege.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvVorschlaege.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvVorschlaege.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVorschlaege.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVorschlaege.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVorschlaege.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVorschlaege.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVorschlaege.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVorschlaege.Appearance.GroupRow.Options.UseFont = true;
            this.grvVorschlaege.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVorschlaege.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVorschlaege.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVorschlaege.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVorschlaege.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVorschlaege.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVorschlaege.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVorschlaege.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVorschlaege.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVorschlaege.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVorschlaege.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVorschlaege.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVorschlaege.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVorschlaege.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVorschlaege.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVorschlaege.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVorschlaege.Appearance.OddRow.Options.UseFont = true;
            this.grvVorschlaege.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVorschlaege.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVorschlaege.Appearance.Row.Options.UseBackColor = true;
            this.grvVorschlaege.Appearance.Row.Options.UseFont = true;
            this.grvVorschlaege.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVorschlaege.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVorschlaege.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVorschlaege.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVorschlaege.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVorschlaege.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVorschlaege.GridControl = this.grdVorschlaege;
            this.grvVorschlaege.Name = "grvVorschlaege";
            this.grvVorschlaege.OptionsBehavior.Editable = false;
            this.grvVorschlaege.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVorschlaege.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVorschlaege.OptionsNavigation.UseTabKey = false;
            this.grvVorschlaege.OptionsView.ColumnAutoWidth = false;
            this.grvVorschlaege.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVorschlaege.OptionsView.ShowGroupPanel = false;
            this.grvVorschlaege.OptionsView.ShowIndicator = false;
            // 
            // tpgVertrag
            // 
            this.tpgVertrag.Controls.Add(this.ctlGotoFall1);
            this.tpgVertrag.Controls.Add(this.grdZwischenbericht);
            this.tpgVertrag.Location = new System.Drawing.Point(6, 6);
            this.tpgVertrag.Name = "tpgVertrag";
            this.tpgVertrag.Size = new System.Drawing.Size(772, 424);
            this.tpgVertrag.TabIndex = 2;
            this.tpgVertrag.Title = "Verträge";
            // 
            // ctlGotoFall1
            // 
            this.ctlGotoFall1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFall1.DataMember = "BaPersonID$";
            this.ctlGotoFall1.DataSource = this.qryVertrag;
            this.ctlGotoFall1.Location = new System.Drawing.Point(3, 395);
            this.ctlGotoFall1.Name = "ctlGotoFall1";
            this.ctlGotoFall1.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFall1.TabIndex = 5;
            // 
            // qryVertrag
            // 
            this.qryVertrag.HostControl = this;
            this.qryVertrag.IsIdentityInsert = false;
            this.qryVertrag.SelectStatement = resources.GetString("qryVertrag.SelectStatement");
            // 
            // grdZwischenbericht
            // 
            this.grdZwischenbericht.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdZwischenbericht.ColumnFilterActivated = true;
            this.grdZwischenbericht.DataSource = this.qryVertrag;
            // 
            // 
            // 
            this.grdZwischenbericht.EmbeddedNavigator.Name = "";
            this.grdZwischenbericht.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZwischenbericht.Location = new System.Drawing.Point(3, 0);
            this.grdZwischenbericht.MainView = this.grvZwischenbericht;
            this.grdZwischenbericht.Name = "grdZwischenbericht";
            this.grdZwischenbericht.Size = new System.Drawing.Size(766, 392);
            this.grdZwischenbericht.TabIndex = 4;
            this.grdZwischenbericht.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZwischenbericht});
            // 
            // grvZwischenbericht
            // 
            this.grvZwischenbericht.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZwischenbericht.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.Empty.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.Empty.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.EvenRow.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZwischenbericht.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZwischenbericht.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZwischenbericht.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZwischenbericht.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZwischenbericht.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZwischenbericht.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZwischenbericht.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZwischenbericht.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvZwischenbericht.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZwischenbericht.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZwischenbericht.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZwischenbericht.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZwischenbericht.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.GroupRow.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZwischenbericht.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZwischenbericht.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZwischenbericht.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZwischenbericht.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZwischenbericht.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZwischenbericht.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZwischenbericht.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZwischenbericht.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZwischenbericht.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.OddRow.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZwischenbericht.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.Row.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.Row.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZwischenbericht.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZwischenbericht.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZwischenbericht.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZwischenbericht.GridControl = this.grdZwischenbericht;
            this.grvZwischenbericht.Name = "grvZwischenbericht";
            this.grvZwischenbericht.OptionsBehavior.Editable = false;
            this.grvZwischenbericht.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZwischenbericht.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZwischenbericht.OptionsNavigation.UseTabKey = false;
            this.grvZwischenbericht.OptionsView.ColumnAutoWidth = false;
            this.grvZwischenbericht.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZwischenbericht.OptionsView.ShowGroupPanel = false;
            this.grvZwischenbericht.OptionsView.ShowIndicator = false;
            // 
            // edtZustaendigKA
            // 
            this.edtZustaendigKA.Location = new System.Drawing.Point(150, 46);
            this.edtZustaendigKA.Name = "edtZustaendigKA";
            this.edtZustaendigKA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZustaendigKA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustaendigKA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigKA.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustaendigKA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustaendigKA.Properties.Appearance.Options.UseFont = true;
            this.edtZustaendigKA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtZustaendigKA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtZustaendigKA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZustaendigKA.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtZustaendigKA.Size = new System.Drawing.Size(250, 24);
            this.edtZustaendigKA.TabIndex = 1;
            this.edtZustaendigKA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtZustaendigKA_UserModifiedFld);
            // 
            // edtSucheNach
            // 
            this.edtSucheNach.AllowNull = false;
            this.edtSucheNach.Location = new System.Drawing.Point(150, 76);
            this.edtSucheNach.LOVName = "KaAbfrageControllingStatus";
            this.edtSucheNach.Name = "edtSucheNach";
            this.edtSucheNach.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheNach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheNach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheNach.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheNach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheNach.Properties.Appearance.Options.UseFont = true;
            this.edtSucheNach.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheNach.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheNach.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheNach.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheNach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheNach.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheNach.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheNach.Properties.NullText = "";
            this.edtSucheNach.Properties.ShowFooter = false;
            this.edtSucheNach.Properties.ShowHeader = false;
            this.edtSucheNach.Size = new System.Drawing.Size(250, 24);
            this.edtSucheNach.TabIndex = 3;
            this.edtSucheNach.EditValueChanged += new System.EventHandler(this.edtSucheNach_EditValueChanged);
            // 
            // edtStatusHeute
            // 
            this.edtStatusHeute.Location = new System.Drawing.Point(150, 106);
            this.edtStatusHeute.LOVName = "KaStatusPhase";
            this.edtStatusHeute.Name = "edtStatusHeute";
            this.edtStatusHeute.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStatusHeute.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatusHeute.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusHeute.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatusHeute.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatusHeute.Properties.Appearance.Options.UseFont = true;
            this.edtStatusHeute.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtStatusHeute.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusHeute.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtStatusHeute.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtStatusHeute.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtStatusHeute.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtStatusHeute.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStatusHeute.Properties.NullText = "";
            this.edtStatusHeute.Properties.ShowFooter = false;
            this.edtStatusHeute.Properties.ShowHeader = false;
            this.edtStatusHeute.Size = new System.Drawing.Size(250, 24);
            this.edtStatusHeute.TabIndex = 4;
            // 
            // edtZeitraumVon
            // 
            this.edtZeitraumVon.EditValue = "";
            this.edtZeitraumVon.Location = new System.Drawing.Point(150, 138);
            this.edtZeitraumVon.Name = "edtZeitraumVon";
            this.edtZeitraumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZeitraumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZeitraumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZeitraumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZeitraumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtZeitraumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZeitraumVon.Properties.Appearance.Options.UseFont = true;
            this.edtZeitraumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtZeitraumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZeitraumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtZeitraumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZeitraumVon.Properties.ShowToday = false;
            this.edtZeitraumVon.Size = new System.Drawing.Size(100, 24);
            this.edtZeitraumVon.TabIndex = 5;
            // 
            // edtZeitraumBis
            // 
            this.edtZeitraumBis.EditValue = "";
            this.edtZeitraumBis.Location = new System.Drawing.Point(300, 138);
            this.edtZeitraumBis.Name = "edtZeitraumBis";
            this.edtZeitraumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZeitraumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZeitraumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZeitraumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZeitraumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtZeitraumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZeitraumBis.Properties.Appearance.Options.UseFont = true;
            this.edtZeitraumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtZeitraumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZeitraumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtZeitraumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZeitraumBis.Properties.ShowToday = false;
            this.edtZeitraumBis.Size = new System.Drawing.Size(100, 24);
            this.edtZeitraumBis.TabIndex = 6;
            // 
            // lblZustaendigKA
            // 
            this.lblZustaendigKA.Location = new System.Drawing.Point(8, 46);
            this.lblZustaendigKA.Name = "lblZustaendigKA";
            this.lblZustaendigKA.Size = new System.Drawing.Size(136, 24);
            this.lblZustaendigKA.TabIndex = 7;
            this.lblZustaendigKA.Text = "Zuständig KA";
            this.lblZustaendigKA.UseCompatibleTextRendering = true;
            // 
            // lblSucheNach
            // 
            this.lblSucheNach.Location = new System.Drawing.Point(8, 76);
            this.lblSucheNach.Name = "lblSucheNach";
            this.lblSucheNach.Size = new System.Drawing.Size(136, 24);
            this.lblSucheNach.TabIndex = 9;
            this.lblSucheNach.Text = "Suche nach";
            this.lblSucheNach.UseCompatibleTextRendering = true;
            // 
            // lblStatusHeute
            // 
            this.lblStatusHeute.Location = new System.Drawing.Point(8, 106);
            this.lblStatusHeute.Name = "lblStatusHeute";
            this.lblStatusHeute.Size = new System.Drawing.Size(136, 24);
            this.lblStatusHeute.TabIndex = 10;
            this.lblStatusHeute.Text = "Status heute";
            this.lblStatusHeute.UseCompatibleTextRendering = true;
            // 
            // lblZeitraumVon
            // 
            this.lblZeitraumVon.Location = new System.Drawing.Point(8, 138);
            this.lblZeitraumVon.Name = "lblZeitraumVon";
            this.lblZeitraumVon.Size = new System.Drawing.Size(136, 24);
            this.lblZeitraumVon.TabIndex = 11;
            this.lblZeitraumVon.Text = "Zeitraum von";
            this.lblZeitraumVon.UseCompatibleTextRendering = true;
            // 
            // lblZeitraumBis
            // 
            this.lblZeitraumBis.Location = new System.Drawing.Point(265, 138);
            this.lblZeitraumBis.Name = "lblZeitraumBis";
            this.lblZeitraumBis.Size = new System.Drawing.Size(29, 24);
            this.lblZeitraumBis.TabIndex = 12;
            this.lblZeitraumBis.Text = "bis";
            this.lblZeitraumBis.UseCompatibleTextRendering = true;
            // 
            // colAblehnungsgrund
            // 
            this.colAblehnungsgrund.Name = "colAblehnungsgrund";
            // 
            // colAbschluss
            // 
            this.colAbschluss.Name = "colAbschluss";
            // 
            // colAbschlussgrund
            // 
            this.colAbschlussgrund.Name = "colAbschlussgrund";
            // 
            // colAlter
            // 
            this.colAlter.Name = "colAlter";
            // 
            // colAnfrage
            // 
            this.colAnfrage.Name = "colAnfrage";
            // 
            // colAnmeldung
            // 
            this.colAnmeldung.Name = "colAnmeldung";
            // 
            // colBerufsabschluss
            // 
            this.colBerufsabschluss.Name = "colBerufsabschluss";
            // 
            // colBetrieb
            // 
            this.colBetrieb.Name = "colBetrieb";
            // 
            // colCoachinggesprche
            // 
            this.colCoachinggesprche.Name = "colCoachinggesprche";
            // 
            // colDeutschkenntnisse
            // 
            this.colDeutschkenntnisse.Name = "colDeutschkenntnisse";
            // 
            // colDossieranCoach
            // 
            this.colDossieranCoach.Name = "colDossieranCoach";
            // 
            // coldurch
            // 
            this.coldurch.Name = "coldurch";
            // 
            // colEingang
            // 
            this.colEingang.Name = "colEingang";
            // 
            // colEinsatzab
            // 
            this.colEinsatzab.Name = "colEinsatzab";
            // 
            // colEinsatzende
            // 
            this.colEinsatzende.Name = "colEinsatzende";
            // 
            // colEinsatzplatz
            // 
            this.colEinsatzplatz.Name = "colEinsatzplatz";
            // 
            // colEinstze
            // 
            this.colEinstze.Name = "colEinstze";
            // 
            // colErffnung
            // 
            this.colErffnung.Name = "colErffnung";
            // 
            // colErffnungPhase
            // 
            this.colErffnungPhase.Name = "colErffnungPhase";
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Name = "colGeschlecht";
            // 
            // colGesundheit
            // 
            this.colGesundheit.Name = "colGesundheit";
            // 
            // colGesundheitkrperlich
            // 
            this.colGesundheitkrperlich.Name = "colGesundheitkrperlich";
            // 
            // colGesundheitpsychisch
            // 
            this.colGesundheitpsychisch.Name = "colGesundheitpsychisch";
            // 
            // colvermittelt
            // 
            this.colvermittelt.Name = "colvermittelt";
            // 
            // colKategorie
            // 
            this.colKategorie.Name = "colKategorie";
            // 
            // colInternerBetrieb
            // 
            this.colInternerBetrieb.Name = "colInternerBetrieb";
            // 
            // colIntervention
            // 
            this.colIntervention.Name = "colIntervention";
            // 
            // colMahnung
            // 
            this.colMahnung.Name = "colMahnung";
            // 
            // colMassnahme
            // 
            this.colMassnahme.Name = "colMassnahme";
            // 
            // colMotivation
            // 
            this.colMotivation.Name = "colMotivation";
            // 
            // colName
            // 
            this.colName.Name = "colName";
            // 
            // colNationalitt
            // 
            this.colNationalitt.Name = "colNationalitt";
            // 
            // colPensum
            // 
            this.colPensum.Name = "colPensum";
            // 
            // colPersNr
            // 
            this.colPersNr.Name = "colPersNr";
            // 
            // colpriorisiert
            // 
            this.colpriorisiert.Name = "colpriorisiert";
            // 
            // colSucht
            // 
            this.colSucht.Name = "colSucht";
            // 
            // coltest
            // 
            this.coltest.Name = "coltest";
            // 
            // colVermittelbarkeit
            // 
            this.colVermittelbarkeit.Name = "colVermittelbarkeit";
            // 
            // colVermittlungsgesprch
            // 
            this.colVermittlungsgesprch.Name = "colVermittlungsgesprch";
            // 
            // colVorname
            // 
            this.colVorname.Name = "colVorname";
            // 
            // colVorschlag
            // 
            this.colVorschlag.Name = "colVorschlag";
            // 
            // colVorschlagerfasst
            // 
            this.colVorschlagerfasst.Name = "colVorschlagerfasst";
            // 
            // colVorschlge
            // 
            this.colVorschlge.Name = "colVorschlge";
            // 
            // colZBanSD
            // 
            this.colZBanSD.Name = "colZBanSD";
            // 
            // colZustndig
            // 
            this.colZustndig.Name = "colZustndig";
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
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            // CtlQueryKaControllingJobtimal
            // 
            this.Name = "CtlQueryKaControllingJobtimal";
            this.Load += new System.EventHandler(this.CtlQueryKaControllingJobtimal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            this.tpgVorschlaege.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryVorschlaege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVorschlaege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVorschlaege)).EndInit();
            this.tpgVertrag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryVertrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZwischenbericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZwischenbericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeute.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusHeute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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