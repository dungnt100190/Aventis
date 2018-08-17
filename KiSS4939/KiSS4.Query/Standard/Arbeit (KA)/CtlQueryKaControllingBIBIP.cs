using System;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public class CtlQueryKaControllingBIBIP : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAblehnungsgrundBI;
        private DevExpress.XtraGrid.Columns.GridColumn colAblehnungsgrundBIP;
        private DevExpress.XtraGrid.Columns.GridColumn colAbschluss;
        private DevExpress.XtraGrid.Columns.GridColumn colAbschlussgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colAbschlussgrundBI;
        private DevExpress.XtraGrid.Columns.GridColumn colAbschlussgrundBIP;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colAnmeldung;
        private DevExpress.XtraGrid.Columns.GridColumn colBerufsabschluss;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrieb;
        private DevExpress.XtraGrid.Columns.GridColumn colCoachinggesprche;
        private DevExpress.XtraGrid.Columns.GridColumn colDeutschkenntnisse;
        private DevExpress.XtraGrid.Columns.GridColumn colDossieranCoach;
        private DevExpress.XtraGrid.Columns.GridColumn coldurch;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzab;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzbis;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzplatz;
        private DevExpress.XtraGrid.Columns.GridColumn colEinstze;
        private DevExpress.XtraGrid.Columns.GridColumn colErffnung;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colGesundheit;
        private DevExpress.XtraGrid.Columns.GridColumn colinaktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colInternerBetrieb;
        private DevExpress.XtraGrid.Columns.GridColumn colKAProgramm;
        private DevExpress.XtraGrid.Columns.GridColumn colKAProgramm1;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivation;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colPensum;
        private DevExpress.XtraGrid.Columns.GridColumn colPersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colpriorisiert;
        private DevExpress.XtraGrid.Columns.GridColumn colStellenende;
        private DevExpress.XtraGrid.Columns.GridColumn colSucht;
        private DevExpress.XtraGrid.Columns.GridColumn coltest;
        private DevExpress.XtraGrid.Columns.GridColumn colunbefristet;
        private DevExpress.XtraGrid.Columns.GridColumn colVermittelbarkeit;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colVorschlag;
        private DevExpress.XtraGrid.Columns.GridColumn colVorschlagerfasst;
        private DevExpress.XtraGrid.Columns.GridColumn colVorschlge;
        private DevExpress.XtraGrid.Columns.GridColumn colZustndig;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlGotoFall ctlGotoFallVorschlaege;
        private KiSS4.Gui.KissLookUpEdit edtProgrammKA;
        private KiSS4.Gui.KissLookUpEdit edtStatusHeute;
        private KiSS4.Gui.KissLookUpEdit edtSucheNach;
        private KiSS4.Gui.KissDateEdit edtZeitraumBis;
        private KiSS4.Gui.KissDateEdit edtZeitraumVon;
        private KiSS4.Gui.KissButtonEdit edtZustaendigKA;
        private KiSS4.Gui.KissGrid grdVorschlaege;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVorschlaege;
        private KiSS4.Gui.KissLabel lblProgrammKA;
        private KiSS4.Gui.KissLabel lblStatusHeute;
        private KiSS4.Gui.KissLabel lblSucheNach;
        private KiSS4.Gui.KissLabel lblZeitraumBis;
        private KiSS4.Gui.KissLabel lblZeitraumVon;
        private KiSS4.Gui.KissLabel lblZustaendigKA;
        private KiSS4.DB.SqlQuery qryVorschlaege;
        private SharpLibrary.WinControls.TabPageEx tpgVorschlaege;

        #endregion

        #region Constructors

        public CtlQueryKaControllingBIBIP()
        {
            this.InitializeComponent();

            edtSucheNach.EditValue = 1;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaControllingBIBIP));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtZustaendigKA = new KiSS4.Gui.KissButtonEdit();
            this.edtProgrammKA = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheNach = new KiSS4.Gui.KissLookUpEdit();
            this.edtStatusHeute = new KiSS4.Gui.KissLookUpEdit();
            this.edtZeitraumVon = new KiSS4.Gui.KissDateEdit();
            this.edtZeitraumBis = new KiSS4.Gui.KissDateEdit();
            this.lblZustaendigKA = new KiSS4.Gui.KissLabel();
            this.lblProgrammKA = new KiSS4.Gui.KissLabel();
            this.lblSucheNach = new KiSS4.Gui.KissLabel();
            this.lblStatusHeute = new KiSS4.Gui.KissLabel();
            this.lblZeitraumVon = new KiSS4.Gui.KissLabel();
            this.lblZeitraumBis = new KiSS4.Gui.KissLabel();
            this.tpgVorschlaege = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFallVorschlaege = new KiSS4.Common.CtlGotoFall();
            this.qryVorschlaege = new KiSS4.DB.SqlQuery(this.components);
            this.grdVorschlaege = new KiSS4.Gui.KissGrid();
            this.grvVorschlaege = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAblehnungsgrundBI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAblehnungsgrundBIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbschluss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbschlussgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbschlussgrundBI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbschlussgrundBIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnmeldung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBerufsabschluss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrieb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoachinggesprche = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeutschkenntnisse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDossieranCoach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldurch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzbis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzplatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinstze = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErffnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesundheit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinaktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInternerBetrieb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAProgramm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKAProgramm1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPensum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpriorisiert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStellenende = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltest = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colunbefristet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVermittelbarkeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorschlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorschlagerfasst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorschlge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZustndig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProgrammKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProgrammKA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeute.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgrammKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusHeute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumBis)).BeginInit();
            this.tpgVorschlaege.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryVorschlaege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVorschlaege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVorschlaege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.tabControlSearch.Controls.Add(this.tpgVorschlaege);
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgVorschlaege});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgVorschlaege, 0);
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
            this.tpgSuchen.Controls.Add(this.lblProgrammKA);
            this.tpgSuchen.Controls.Add(this.lblZustaendigKA);
            this.tpgSuchen.Controls.Add(this.edtZeitraumBis);
            this.tpgSuchen.Controls.Add(this.edtZeitraumVon);
            this.tpgSuchen.Controls.Add(this.edtStatusHeute);
            this.tpgSuchen.Controls.Add(this.edtSucheNach);
            this.tpgSuchen.Controls.Add(this.edtProgrammKA);
            this.tpgSuchen.Controls.Add(this.edtZustaendigKA);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZustaendigKA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtProgrammKA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheNach, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStatusHeute, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZeitraumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZustaendigKA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblProgrammKA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheNach, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStatusHeute, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumBis, 0);
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
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtZustaendigKA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtZustaendigKA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZustaendigKA.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtZustaendigKA.Size = new System.Drawing.Size(250, 24);
            this.edtZustaendigKA.TabIndex = 1;
            this.edtZustaendigKA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtZustaendigKA_UserModifiedFld);
            //
            // edtProgrammKA
            //
            this.edtProgrammKA.Location = new System.Drawing.Point(150, 76);
            this.edtProgrammKA.LOVFilter = "\',\' + Value2 + \',\'  like \'%,4,%\'";
            this.edtProgrammKA.LOVFilterWhereAppend = true;
            this.edtProgrammKA.LOVName = "KaVermittlungProgramm";
            this.edtProgrammKA.Name = "edtProgrammKA";
            this.edtProgrammKA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtProgrammKA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtProgrammKA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtProgrammKA.Properties.Appearance.Options.UseBackColor = true;
            this.edtProgrammKA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtProgrammKA.Properties.Appearance.Options.UseFont = true;
            this.edtProgrammKA.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtProgrammKA.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtProgrammKA.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtProgrammKA.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtProgrammKA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtProgrammKA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtProgrammKA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtProgrammKA.Properties.NullText = "";
            this.edtProgrammKA.Properties.ShowFooter = false;
            this.edtProgrammKA.Properties.ShowHeader = false;
            this.edtProgrammKA.Size = new System.Drawing.Size(250, 24);
            this.edtProgrammKA.TabIndex = 2;
            //
            // edtSucheNach
            //
            this.edtSucheNach.AllowNull = false;
            this.edtSucheNach.Location = new System.Drawing.Point(150, 106);
            this.edtSucheNach.LOVName = "KaAbfrageControllingStatus";
            this.edtSucheNach.Name = "edtSucheNach";
            this.edtSucheNach.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheNach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheNach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheNach.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheNach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheNach.Properties.Appearance.Options.UseFont = true;
            this.edtSucheNach.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
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
            this.edtStatusHeute.Location = new System.Drawing.Point(150, 136);
            this.edtStatusHeute.LOVName = "KaStatusPhase";
            this.edtStatusHeute.Name = "edtStatusHeute";
            this.edtStatusHeute.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStatusHeute.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatusHeute.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusHeute.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatusHeute.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatusHeute.Properties.Appearance.Options.UseFont = true;
            this.edtStatusHeute.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
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
            this.edtZeitraumVon.Location = new System.Drawing.Point(150, 168);
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
            this.edtZeitraumBis.Location = new System.Drawing.Point(300, 168);
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
            this.lblZustaendigKA.Size = new System.Drawing.Size(96, 24);
            this.lblZustaendigKA.TabIndex = 7;
            this.lblZustaendigKA.Text = "Zuständig KA";
            this.lblZustaendigKA.UseCompatibleTextRendering = true;
            //
            // lblProgrammKA
            //
            this.lblProgrammKA.Location = new System.Drawing.Point(8, 76);
            this.lblProgrammKA.Name = "lblProgrammKA";
            this.lblProgrammKA.Size = new System.Drawing.Size(130, 24);
            this.lblProgrammKA.TabIndex = 8;
            this.lblProgrammKA.Text = "Programm KA";
            this.lblProgrammKA.UseCompatibleTextRendering = true;
            //
            // lblSucheNach
            //
            this.lblSucheNach.Location = new System.Drawing.Point(8, 106);
            this.lblSucheNach.Name = "lblSucheNach";
            this.lblSucheNach.Size = new System.Drawing.Size(130, 24);
            this.lblSucheNach.TabIndex = 9;
            this.lblSucheNach.Text = "Suche nach";
            this.lblSucheNach.UseCompatibleTextRendering = true;
            //
            // lblStatusHeute
            //
            this.lblStatusHeute.Location = new System.Drawing.Point(8, 136);
            this.lblStatusHeute.Name = "lblStatusHeute";
            this.lblStatusHeute.Size = new System.Drawing.Size(130, 24);
            this.lblStatusHeute.TabIndex = 10;
            this.lblStatusHeute.Text = "Status heute";
            this.lblStatusHeute.UseCompatibleTextRendering = true;
            //
            // lblZeitraumVon
            //
            this.lblZeitraumVon.Location = new System.Drawing.Point(8, 168);
            this.lblZeitraumVon.Name = "lblZeitraumVon";
            this.lblZeitraumVon.Size = new System.Drawing.Size(136, 24);
            this.lblZeitraumVon.TabIndex = 11;
            this.lblZeitraumVon.Text = "Zeitraum von";
            this.lblZeitraumVon.UseCompatibleTextRendering = true;
            //
            // lblZeitraumBis
            //
            this.lblZeitraumBis.Location = new System.Drawing.Point(265, 168);
            this.lblZeitraumBis.Name = "lblZeitraumBis";
            this.lblZeitraumBis.Size = new System.Drawing.Size(29, 24);
            this.lblZeitraumBis.TabIndex = 12;
            this.lblZeitraumBis.Text = "bis";
            this.lblZeitraumBis.UseCompatibleTextRendering = true;
            //
            // tpgVorschlaege
            //
            this.tpgVorschlaege.Controls.Add(this.ctlGotoFallVorschlaege);
            this.tpgVorschlaege.Controls.Add(this.grdVorschlaege);
            this.tpgVorschlaege.Location = new System.Drawing.Point(6, 6);
            this.tpgVorschlaege.Name = "tpgVorschlaege";
            this.tpgVorschlaege.Size = new System.Drawing.Size(772, 424);
            this.tpgVorschlaege.TabIndex = 1;
            this.tpgVorschlaege.Title = "Vorschläge / Einsätze";
            //
            // ctlGotoFallVorschlaege
            //
            this.ctlGotoFallVorschlaege.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallVorschlaege.DataMember = "BaPersonID$";
            this.ctlGotoFallVorschlaege.DataSource = this.qryVorschlaege;
            this.ctlGotoFallVorschlaege.Location = new System.Drawing.Point(3, 398);
            this.ctlGotoFallVorschlaege.Name = "ctlGotoFallVorschlaege";
            this.ctlGotoFallVorschlaege.Size = new System.Drawing.Size(162, 24);
            this.ctlGotoFallVorschlaege.TabIndex = 3;
            //
            // qryVorschlaege
            //
            this.qryVorschlaege.HostControl = this;
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
            this.grdVorschlaege.Location = new System.Drawing.Point(3, 1);
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
            // colAblehnungsgrundBI
            //
            this.colAblehnungsgrundBI.Name = "colAblehnungsgrundBI";
            //
            // colAblehnungsgrundBIP
            //
            this.colAblehnungsgrundBIP.Name = "colAblehnungsgrundBIP";
            //
            // colAbschluss
            //
            this.colAbschluss.Name = "colAbschluss";
            //
            // colAbschlussgrund
            //
            this.colAbschlussgrund.Name = "colAbschlussgrund";
            //
            // colAbschlussgrundBI
            //
            this.colAbschlussgrundBI.Name = "colAbschlussgrundBI";
            //
            // colAbschlussgrundBIP
            //
            this.colAbschlussgrundBIP.Name = "colAbschlussgrundBIP";
            //
            // colAlter
            //
            this.colAlter.Name = "colAlter";
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
            // colEinsatzab
            //
            this.colEinsatzab.Name = "colEinsatzab";
            //
            // colEinsatzbis
            //
            this.colEinsatzbis.Name = "colEinsatzbis";
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
            // colinaktiv
            //
            this.colinaktiv.Name = "colinaktiv";
            //
            // colInternerBetrieb
            //
            this.colInternerBetrieb.Name = "colInternerBetrieb";
            //
            // colKAProgramm
            //
            this.colKAProgramm.Name = "colKAProgramm";
            //
            // colKAProgramm1
            //
            this.colKAProgramm1.Name = "colKAProgramm1";
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
            // colStellenende
            //
            this.colStellenende.Name = "colStellenende";
            //
            // colSucht
            //
            this.colSucht.Name = "colSucht";
            //
            // coltest
            //
            this.coltest.Name = "coltest";
            //
            // colunbefristet
            //
            this.colunbefristet.Name = "colunbefristet";
            //
            // colVermittelbarkeit
            //
            this.colVermittelbarkeit.Name = "colVermittelbarkeit";
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
            // CtlQueryKaControllingBIBIP
            //
            this.Name = "CtlQueryKaControllingBIBIP";
            this.Load += new System.EventHandler(this.CtlQueryKaControllingBIBIP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProgrammKA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProgrammKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeute.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgrammKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusHeute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumBis)).EndInit();
            this.tpgVorschlaege.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryVorschlaege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVorschlaege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVorschlaege)).EndInit();
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

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtSucheNach.EditValue = 1;

            edtProgrammKA.EditValue = null;
            edtZustaendigKA.EditValue = null;
            edtZustaendigKA.LookupID = null;
            edtStatusHeute.EditValue = null;
            edtZeitraumVon.EditValue = null;
            edtZeitraumBis.EditValue = null;
        }

        protected override void RunSearch()
        {
            if (DBUtil.IsEmpty(edtSucheNach.EditValue))
            {
                edtSucheNach.EditValue = 1;
                edtZeitraumVon.EditValue = null;
                edtZeitraumBis.EditValue = null;
            }

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void CtlQueryKaControllingBIBIP_Load(object sender, System.EventArgs e)
        {
            tpgListe.Title = "Daten STES";
        }

        private void edtSucheNach_EditValueChanged(object sender, System.EventArgs e)
        {
            edtStatusHeute.EditMode = EditModeType.ReadOnly;
            edtZeitraumVon.EditMode = EditModeType.ReadOnly;
            edtZeitraumBis.EditMode = EditModeType.ReadOnly;

            edtStatusHeute.EditValue = null;
            edtZeitraumVon.EditValue = null;
            edtZeitraumBis.EditValue = null;

            if (!DBUtil.IsEmpty(edtSucheNach.EditValue))
            {
                if (Convert.ToInt32(edtSucheNach.EditValue) == 1)
                {
                    edtStatusHeute.EditMode = EditModeType.Normal;
                }
                else
                {
                    edtZeitraumVon.EditMode = EditModeType.Normal;
                    edtZeitraumBis.EditMode = EditModeType.Normal;
                }
            }
        }

        private void edtZustaendigKA_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtZustaendigKA.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtZustaendigKA.EditValue = null;
                    edtZustaendigKA.LookupID = null;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$ = UserID,
                     [Kürzel] = LogonName,
                     [Mitarbeiter/in] = NameVorname,
                     [Org.Einheit] = OrgUnit
              FROM   vwUser
              WHERE  NameVorname like {0} + '%'
              AND    LogonName like 'KA%'
              ORDER BY NameVorname",
              SearchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtZustaendigKA.EditValue = dlg[2];
                edtZustaendigKA.LookupID = dlg[0];
            }
        }

        #endregion
    }
}