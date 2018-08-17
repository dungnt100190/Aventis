using System;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public class CtlQueryKaStagesQJExtern : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAblehnungsgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colAbschluss;
        private DevExpress.XtraGrid.Columns.GridColumn colAbschlussEinsatz;
        private DevExpress.XtraGrid.Columns.GridColumn colAbschlussgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colAnfrage;
        private DevExpress.XtraGrid.Columns.GridColumn colAnmeldung;
        private DevExpress.XtraGrid.Columns.GridColumn colAustrittsgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colBerufsabschluss;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrieb;
        private DevExpress.XtraGrid.Columns.GridColumn colCoachinggesprche;
        private DevExpress.XtraGrid.Columns.GridColumn colDeutschkenntnisse;
        private DevExpress.XtraGrid.Columns.GridColumn colDossieranCoach;
        private DevExpress.XtraGrid.Columns.GridColumn colEingang;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzBemerkungen;
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
        private DevExpress.XtraGrid.Columns.GridColumn colInaktivGrund;
        private DevExpress.XtraGrid.Columns.GridColumn colInternerBetrieb;
        private DevExpress.XtraGrid.Columns.GridColumn colIntervention;
        private DevExpress.XtraGrid.Columns.GridColumn colKontaktperson;
        private DevExpress.XtraGrid.Columns.GridColumn colMahnung;
        private DevExpress.XtraGrid.Columns.GridColumn colMassnahme;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivation;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colPensum;
        private DevExpress.XtraGrid.Columns.GridColumn colPersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colSucht;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefon;
        private DevExpress.XtraGrid.Columns.GridColumn colVermittelbarkeit;
        private DevExpress.XtraGrid.Columns.GridColumn colVermittlungsgesprch;
        private DevExpress.XtraGrid.Columns.GridColumn colVermittlungsprofilBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colVorschlag;
        private DevExpress.XtraGrid.Columns.GridColumn colVorschlagerfasst;
        private DevExpress.XtraGrid.Columns.GridColumn colVorschlge;
        private DevExpress.XtraGrid.Columns.GridColumn colZBanSD;
        private DevExpress.XtraGrid.Columns.GridColumn colZustndig;
        private DevExpress.XtraGrid.Columns.GridColumn colZustndigKA;
        private DevExpress.XtraGrid.Columns.GridColumn colZuteilungFachbereich;
        private DevExpress.XtraGrid.Columns.GridColumn coldurch;
        private DevExpress.XtraGrid.Columns.GridColumn colinaktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colpriorisiert;
        private DevExpress.XtraGrid.Columns.GridColumn coltest;
        private KiSS4.Gui.KissLookUpEdit edtFachbereich;
        private KiSS4.Gui.KissLookUpEdit edtStatusHeute;
        private KiSS4.Gui.KissLookUpEdit edtSucheNach;
        private KiSS4.Gui.KissDateEdit edtZeitraumBis;
        private KiSS4.Gui.KissDateEdit edtZeitraumVon;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblFachbereich;
        private KiSS4.Gui.KissLabel lblStatusHeute;
        private KiSS4.Gui.KissLabel lblSucheNach;
        private KiSS4.Gui.KissLabel lblZeitraumBis;
        private KiSS4.Gui.KissLabel lblZeitraumVon;

        #endregion

        #region Constructors

        public CtlQueryKaStagesQJExtern()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaStagesQJExtern));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtFachbereich = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheNach = new KiSS4.Gui.KissLookUpEdit();
            this.edtStatusHeute = new KiSS4.Gui.KissLookUpEdit();
            this.edtZeitraumVon = new KiSS4.Gui.KissDateEdit();
            this.edtZeitraumBis = new KiSS4.Gui.KissDateEdit();
            this.lblFachbereich = new KiSS4.Gui.KissLabel();
            this.lblSucheNach = new KiSS4.Gui.KissLabel();
            this.lblStatusHeute = new KiSS4.Gui.KissLabel();
            this.lblZeitraumVon = new KiSS4.Gui.KissLabel();
            this.lblZeitraumBis = new KiSS4.Gui.KissLabel();
            this.colAblehnungsgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbschluss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbschlussEinsatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbschlussgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnfrage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnmeldung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAustrittsgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBerufsabschluss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrieb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoachinggesprche = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeutschkenntnisse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDossieranCoach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldurch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEingang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colinaktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInaktivGrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInternerBetrieb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntervention = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontaktperson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMahnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMassnahme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPensum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpriorisiert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltest = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVermittelbarkeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVermittlungsgesprch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVermittlungsprofilBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorschlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorschlagerfasst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorschlge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZBanSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZustndig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZustndigKA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuteilungFachbereich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtFachbereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFachbereich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeute.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachbereich)).BeginInit();
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
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "Dokument öffnen")});
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblZeitraumBis);
            this.tpgSuchen.Controls.Add(this.lblZeitraumVon);
            this.tpgSuchen.Controls.Add(this.lblStatusHeute);
            this.tpgSuchen.Controls.Add(this.lblSucheNach);
            this.tpgSuchen.Controls.Add(this.lblFachbereich);
            this.tpgSuchen.Controls.Add(this.edtZeitraumBis);
            this.tpgSuchen.Controls.Add(this.edtZeitraumVon);
            this.tpgSuchen.Controls.Add(this.edtStatusHeute);
            this.tpgSuchen.Controls.Add(this.edtSucheNach);
            this.tpgSuchen.Controls.Add(this.edtFachbereich);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFachbereich, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheNach, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStatusHeute, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZeitraumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFachbereich, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheNach, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStatusHeute, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumBis, 0);
            // 
            // edtFachbereich
            // 
            this.edtFachbereich.Location = new System.Drawing.Point(150, 46);
            this.edtFachbereich.LOVFilter = "Value1 = \'Semo\'";
            this.edtFachbereich.LOVFilterWhereAppend = true;
            this.edtFachbereich.LOVName = "KaFachbereich";
            this.edtFachbereich.Name = "edtFachbereich";
            this.edtFachbereich.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFachbereich.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFachbereich.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFachbereich.Properties.Appearance.Options.UseBackColor = true;
            this.edtFachbereich.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFachbereich.Properties.Appearance.Options.UseFont = true;
            this.edtFachbereich.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFachbereich.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFachbereich.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFachbereich.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFachbereich.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtFachbereich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtFachbereich.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFachbereich.Properties.NullText = "";
            this.edtFachbereich.Properties.ShowFooter = false;
            this.edtFachbereich.Properties.ShowHeader = false;
            this.edtFachbereich.Size = new System.Drawing.Size(250, 24);
            this.edtFachbereich.TabIndex = 1;
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
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSucheNach.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSucheNach.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheNach.Properties.NullText = "";
            this.edtSucheNach.Properties.ShowFooter = false;
            this.edtSucheNach.Properties.ShowHeader = false;
            this.edtSucheNach.Size = new System.Drawing.Size(250, 24);
            this.edtSucheNach.TabIndex = 2;
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
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtStatusHeute.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtStatusHeute.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStatusHeute.Properties.NullText = "";
            this.edtStatusHeute.Properties.ShowFooter = false;
            this.edtStatusHeute.Properties.ShowHeader = false;
            this.edtStatusHeute.Size = new System.Drawing.Size(250, 24);
            this.edtStatusHeute.TabIndex = 3;
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
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtZeitraumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZeitraumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtZeitraumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZeitraumVon.Properties.ShowToday = false;
            this.edtZeitraumVon.Size = new System.Drawing.Size(100, 24);
            this.edtZeitraumVon.TabIndex = 4;
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
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtZeitraumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZeitraumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtZeitraumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZeitraumBis.Properties.ShowToday = false;
            this.edtZeitraumBis.Size = new System.Drawing.Size(100, 24);
            this.edtZeitraumBis.TabIndex = 5;
            // 
            // lblFachbereich
            // 
            this.lblFachbereich.Location = new System.Drawing.Point(8, 46);
            this.lblFachbereich.Name = "lblFachbereich";
            this.lblFachbereich.Size = new System.Drawing.Size(96, 24);
            this.lblFachbereich.TabIndex = 6;
            this.lblFachbereich.Text = "Fachbereich";
            this.lblFachbereich.UseCompatibleTextRendering = true;
            // 
            // lblSucheNach
            // 
            this.lblSucheNach.Location = new System.Drawing.Point(8, 76);
            this.lblSucheNach.Name = "lblSucheNach";
            this.lblSucheNach.Size = new System.Drawing.Size(130, 24);
            this.lblSucheNach.TabIndex = 7;
            this.lblSucheNach.Text = "Suche nach";
            this.lblSucheNach.UseCompatibleTextRendering = true;
            // 
            // lblStatusHeute
            // 
            this.lblStatusHeute.Location = new System.Drawing.Point(8, 106);
            this.lblStatusHeute.Name = "lblStatusHeute";
            this.lblStatusHeute.Size = new System.Drawing.Size(130, 24);
            this.lblStatusHeute.TabIndex = 8;
            this.lblStatusHeute.Text = "Status heute";
            this.lblStatusHeute.UseCompatibleTextRendering = true;
            // 
            // lblZeitraumVon
            // 
            this.lblZeitraumVon.Location = new System.Drawing.Point(8, 138);
            this.lblZeitraumVon.Name = "lblZeitraumVon";
            this.lblZeitraumVon.Size = new System.Drawing.Size(136, 24);
            this.lblZeitraumVon.TabIndex = 9;
            this.lblZeitraumVon.Text = "Zeitraum von";
            this.lblZeitraumVon.UseCompatibleTextRendering = true;
            // 
            // lblZeitraumBis
            // 
            this.lblZeitraumBis.Location = new System.Drawing.Point(265, 138);
            this.lblZeitraumBis.Name = "lblZeitraumBis";
            this.lblZeitraumBis.Size = new System.Drawing.Size(29, 24);
            this.lblZeitraumBis.TabIndex = 10;
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
            // colAbschlussEinsatz
            // 
            this.colAbschlussEinsatz.Name = "colAbschlussEinsatz";
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
            // colAustrittsgrund
            // 
            this.colAustrittsgrund.Name = "colAustrittsgrund";
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
            // colEinsatzBemerkungen
            // 
            this.colEinsatzBemerkungen.Name = "colEinsatzBemerkungen";
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
            // colinaktiv
            // 
            this.colinaktiv.Name = "colinaktiv";
            // 
            // colInaktivGrund
            // 
            this.colInaktivGrund.Name = "colInaktivGrund";
            // 
            // colInternerBetrieb
            // 
            this.colInternerBetrieb.Name = "colInternerBetrieb";
            // 
            // colIntervention
            // 
            this.colIntervention.Name = "colIntervention";
            // 
            // colKontaktperson
            // 
            this.colKontaktperson.Name = "colKontaktperson";
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
            // colTelefon
            // 
            this.colTelefon.Name = "colTelefon";
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
            // colVermittlungsprofilBemerkungen
            // 
            this.colVermittlungsprofilBemerkungen.Name = "colVermittlungsprofilBemerkungen";
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
            // colZustndigKA
            // 
            this.colZustndigKA.Name = "colZustndigKA";
            // 
            // colZuteilungFachbereich
            // 
            this.colZuteilungFachbereich.Name = "colZuteilungFachbereich";
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
            // CtlQueryKaStagesQJExtern
            // 
            this.Name = "CtlQueryKaStagesQJExtern";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtFachbereich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFachbereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeute.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusHeute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachbereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusHeute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtSucheNach.EditValue = 1;

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

        #endregion
    }
}