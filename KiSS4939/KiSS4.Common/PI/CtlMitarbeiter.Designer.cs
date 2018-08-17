namespace KiSS4.Common.PI
{
    partial class CtlMitarbeiter
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject22 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject19 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlMitarbeiter));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject21 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject20 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdEdMitarbeiter = new KiSS4.Gui.KissGrid();
            this.qryEdMitarbeiter = new KiSS4.DB.SqlQuery(this.components);
            this.grvEdMitarbeiter = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsBw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktivBw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsEd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktivEd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZusatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdresse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezirk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefonMobil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypBW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypED = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKurseZuAbsolvieren = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnrede = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.edtSucheName = new KiSS4.Gui.KissTextEdit();
            this.lblSucheVorname = new KiSS4.Gui.KissLabel();
            this.edtSucheVorname = new KiSS4.Gui.KissTextEdit();
            this.lblSucheOrt = new KiSS4.Gui.KissLabel();
            this.edtSucheOrt = new KiSS4.Gui.KissTextEdit();
            this.edtSucheTypED = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheNurAktive = new KiSS4.Gui.KissCheckEdit();
            this.tabMitarbeiter = new KiSS4.Gui.KissTabControlEx();
            this.tpgGrunddaten = new SharpLibrary.WinControls.TabPageEx();
            this.kissMitarbeiterButtonEditVorgesetzter = new KiSS4.Common.KissMitarbeiterButtonEdit(this.components);
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.grpFreieKapazitaet = new KiSS4.Gui.KissGroupBox();
            this.kissMemoEdit1 = new KiSS4.Gui.KissMemoEdit();
            this.lblVersichertennummer = new KiSS4.Gui.KissLabel();
            this.edtVersichertennummer = new KiSS4.Gui.KissVersichertenNrEdit();
            this.chkPostfachOhneNummer = new KiSS4.Gui.KissCheckEdit();
            this.grpModulAktiv = new KiSS4.Gui.KissGroupBox();
            this.kissButtonEdit1 = new KiSS4.Gui.KissButtonEdit();
            this.edtGrunddatenIsBwMitarbeiter = new KiSS4.Gui.KissCheckEdit();
            this.edtGrunddatenEdAktiv = new KiSS4.Gui.KissCheckEdit();
            this.edtGrunddatenBwAktiv = new KiSS4.Gui.KissCheckEdit();
            this.edtGrunddatenIsEdMitarbeiter = new KiSS4.Gui.KissCheckEdit();
            this.grpGrunddatenTypBW = new KiSS4.Gui.KissGroupBox();
            this.edtGrunddatenTypBW = new KiSS4.Gui.KissCheckedLookupEdit();
            this.grpGrunddatenTypED = new KiSS4.Gui.KissGroupBox();
            this.edtGrunddatenTypED = new KiSS4.Gui.KissCheckedLookupEdit();
            this.edtGrunddatenGeschlecht = new KiSS4.Gui.KissLookUpEdit();
            this.lblGrunddatenGeschlecht = new KiSS4.Gui.KissLabel();
            this.edtGrunddatenGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            this.lblGrunddatenGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.edtGrunddatenAustrittsdatum = new KiSS4.Gui.KissDateEdit();
            this.lblGrunddatenAustrittsdatum = new KiSS4.Gui.KissLabel();
            this.edtGrunddatenEintrittsdatum = new KiSS4.Gui.KissDateEdit();
            this.lblGrunddatenEintrittsdatum = new KiSS4.Gui.KissLabel();
            this.edtGrunddatenPersonalNr = new KiSS4.Gui.KissCalcEdit();
            this.lblGrunddatenPersonalNr = new KiSS4.Gui.KissLabel();
            this.edtGrunddatenFax = new KiSS4.Gui.KissTextEdit();
            this.lblGrunddatenFax = new KiSS4.Gui.KissLabel();
            this.edtGrunddatenTelefonMobil = new KiSS4.Gui.KissTextEdit();
            this.lblGrunddatenTelefonMobil = new KiSS4.Gui.KissLabel();
            this.edtGrunddatenTelefon = new KiSS4.Gui.KissTextEdit();
            this.lblGrunddatenTelefon = new KiSS4.Gui.KissLabel();
            this.edtGrunddatenEmail = new KiSS4.Gui.KissTextEdit();
            this.lblGrunddatenEmail = new KiSS4.Gui.KissLabel();
            this.edtGrunddatenAdresseLand = new KiSS4.Gui.KissLookUpEdit();
            this.lblGrunddatenAdresseLand = new KiSS4.Gui.KissLabel();
            this.edtGrunddatenAdresseBezirk = new KiSS4.Gui.KissTextEdit();
            this.lblGrunddatenAdresseBezirk = new KiSS4.Gui.KissLabel();
            this.edtGrunddatenAdresseKt = new KiSS4.Gui.KissTextEdit();
            this.edtGrunddatenAdresseOrt = new KiSS4.Gui.KissTextEdit();
            this.edtGrunddatenAdressePLZ = new KiSS4.Gui.KissTextEdit();
            this.lblGrunddatenAdressePLZOrtKt = new KiSS4.Gui.KissLabel();
            this.edtGrunddatenAdressePostfach = new KiSS4.Gui.KissTextEdit();
            this.lblGrunddatenAdressePostfach = new KiSS4.Gui.KissLabel();
            this.edtGrunddatenAdresseNr = new KiSS4.Gui.KissTextEdit();
            this.edtGrunddatenAdresseStrasse = new KiSS4.Gui.KissTextEdit();
            this.lblGrunddatenAdresseStrasseNr = new KiSS4.Gui.KissLabel();
            this.edtGrunddatenAdresseZusatz = new KiSS4.Gui.KissTextEdit();
            this.lblGrunddatenAdresseZusatz = new KiSS4.Gui.KissLabel();
            this.edtGrunddatenName = new KiSS4.Gui.KissButtonEdit();
            this.lblGrunddatenName = new KiSS4.Gui.KissLabel();
            this.tpgZusatzdaten = new SharpLibrary.WinControls.TabPageEx();
            this.grpGrunddatenAusbildungTaetigkeit = new KiSS4.Gui.KissGroupBox();
            this.edtZusatzdatenlTaetigkeit = new KiSS4.Gui.KissMemoEdit();
            this.lbZusatzdatenlTaetigkeit = new KiSS4.Gui.KissLabel();
            this.edtZusatzdatenAusbildung = new KiSS4.Gui.KissMemoEdit();
            this.lblZusatzdatenAusbildung = new KiSS4.Gui.KissLabel();
            this.edtZusatzdatenStrafregisterauszugBemerkungen = new KiSS4.Gui.KissTextEdit();
            this.lblZusatzdatenStrafregisterauszugBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtZusatzdatenStrafregisterauszug = new KiSS4.Gui.KissDateEdit();
            this.lblZusatzdatenStrafregisterauszug = new KiSS4.Gui.KissLabel();
            this.chkTabStopBug = new KiSS4.Gui.KissCheckEdit();
            this.edtZusatzdatenAufenthaltsbewilligung = new KiSS4.Gui.KissLookUpEdit();
            this.lblZusatzdatenAufenthaltsbewilligung = new KiSS4.Gui.KissLabel();
            this.edtZusatzdatenNationalitaet = new KiSS4.Gui.KissLookUpEdit();
            this.lblZusatzdatenNationalitaet = new KiSS4.Gui.KissLabel();
            this.edtZusatzdatenWeitereSprachen = new KiSS4.Gui.KissTextEdit();
            this.lblZusatzdatenWeitereSprachen = new KiSS4.Gui.KissLabel();
            this.edtZusatzdatenSprache = new KiSS4.Gui.KissLookUpEdit();
            this.lblZusatzdatenSprache = new KiSS4.Gui.KissLabel();
            this.edtZusatzdatenAnzahlKinder = new KiSS4.Gui.KissCalcEdit();
            this.lblZusatzdatenAnzahlKinder = new KiSS4.Gui.KissLabel();
            this.edtZusatzdatenZivilstand = new KiSS4.Gui.KissLookUpEdit();
            this.lblZusatzdatenZivilstand = new KiSS4.Gui.KissLabel();
            this.tpgInterview = new SharpLibrary.WinControls.TabPageEx();
            this.edtInterviewBeurteilung = new KiSS4.Gui.KissMemoEdit();
            this.lblInterviewBeurteilung = new KiSS4.Gui.KissLabel();
            this.edtInterviewZusammenfassung = new KiSS4.Gui.KissMemoEdit();
            this.lblInterviewZusammenfassung = new KiSS4.Gui.KissLabel();
            this.edtInterviewInterviewer = new KiSS4.Gui.KissButtonEdit();
            this.lblInterviewInterviewer = new KiSS4.Gui.KissLabel();
            this.edtInterviewDatum = new KiSS4.Gui.KissDateEdit();
            this.lblInterviewDatum = new KiSS4.Gui.KissLabel();
            this.tpgWeiterbildung = new SharpLibrary.WinControls.TabPageEx();
            this.grdKurs = new KiSS4.Gui.KissGrid();
            this.qryEdMitarbeiterKurs = new KiSS4.DB.SqlQuery(this.components);
            this.grvKurs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWeiterbildungKurs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeiterbildungFrist = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeiterbildungAbsolviert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeiterbildungDispensiert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeiterbildungBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panWeiterbildungDetails = new System.Windows.Forms.Panel();
            this.edtWeiterbildungBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.lblWeiterbildungBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtWeiterbildungDispensiert = new KiSS4.Gui.KissCheckEdit();
            this.edtWeiterbildungAbsolviert = new KiSS4.Gui.KissDateEdit();
            this.lblWeiterbildungAbsolviert = new KiSS4.Gui.KissLabel();
            this.edtWeiterbildungZuAbsolvierenBis = new KiSS4.Gui.KissDateEdit();
            this.lblWeiterbildungZuAbsolvierenBis = new KiSS4.Gui.KissLabel();
            this.edtWeiterbildungKurs = new KiSS4.Gui.KissLookUpEdit();
            this.lblWeiterbildungKurs = new KiSS4.Gui.KissLabel();
            this.tpgPersoenlichkeit = new SharpLibrary.WinControls.TabPageEx();
            this.tblPersoenlichkeit = new System.Windows.Forms.TableLayoutPanel();
            this.edtPersoenlichkeitErfahrungen = new KiSS4.Gui.KissMemoEdit();
            this.lblPersoenlichkeitErfahrungen = new KiSS4.Gui.KissLabel();
            this.lblPersoenlichkeitErfahrungenNachAltersklassen = new KiSS4.Gui.KissLabel();
            this.lblPersoenlichkeitVorlieben = new KiSS4.Gui.KissLabel();
            this.lblPersoenlichkeitPersoenlichkeit = new KiSS4.Gui.KissLabel();
            this.lblPersoenlichkeitGesundheit = new KiSS4.Gui.KissLabel();
            this.edtPersoenlichkeitGesundheit = new KiSS4.Gui.KissMemoEdit();
            this.edtPersoenlichkeitErfahrungenNachAltersklassen = new KiSS4.Gui.KissMemoEdit();
            this.edtPersoenlichkeitVorlieben = new KiSS4.Gui.KissMemoEdit();
            this.edtPersoenlichkeitPersoenlichkeit = new KiSS4.Gui.KissMemoEdit();
            this.tpgKenntnisse = new SharpLibrary.WinControls.TabPageEx();
            this.edtKenntnisseWeitereKenntnisse = new KiSS4.Gui.KissMemoEdit();
            this.lblKenntnisseWeitereKenntnisse = new KiSS4.Gui.KissLabel();
            this.grpKenntnisseHilfetechniken = new KiSS4.Gui.KissGroupBox();
            this.edtKenntnisseKommunikation = new KiSS4.Gui.KissTextEdit();
            this.lblKenntnisseKommunikation = new KiSS4.Gui.KissLabel();
            this.edtKenntnisseTransporte = new KiSS4.Gui.KissTextEdit();
            this.lblKenntnisseTransporte = new KiSS4.Gui.KissLabel();
            this.edtKenntnisseHilfsmittel = new KiSS4.Gui.KissTextEdit();
            this.lblKenntnisseHilfsmittel = new KiSS4.Gui.KissLabel();
            this.grpKenntnissePsychischeBehinderung = new KiSS4.Gui.KissGroupBox();
            this.edtKenntnisseSelbstFremdaggression = new KiSS4.Gui.KissTextEdit();
            this.lblKenntnisseSelbstFremdaggression = new KiSS4.Gui.KissLabel();
            this.edtKenntnisseVerhaltensstoerung = new KiSS4.Gui.KissTextEdit();
            this.lblKenntnisseVerhaltensstoerung = new KiSS4.Gui.KissLabel();
            this.grpKenntnisseGeistigeBehinderung = new KiSS4.Gui.KissGroupBox();
            this.edtGeistigeBehinderung = new KiSS4.Gui.KissTextEdit();
            this.lblKenntnisseGeistigeBehinderung = new KiSS4.Gui.KissLabel();
            this.grpKenntnisseKoerperlicheBehinderung = new KiSS4.Gui.KissGroupBox();
            this.edtKenntnisseEpilepsie = new KiSS4.Gui.KissTextEdit();
            this.lblKenntnisseEpilepsie = new KiSS4.Gui.KissLabel();
            this.edtKenntnisseGehirnschaedigung = new KiSS4.Gui.KissTextEdit();
            this.lblKenntnisseGehirnschaedigung = new KiSS4.Gui.KissLabel();
            this.edtKenntnisseIMC = new KiSS4.Gui.KissTextEdit();
            this.lblKenntnisseIMC = new KiSS4.Gui.KissLabel();
            this.edtKenntnisseMehrfachbehinderung = new KiSS4.Gui.KissTextEdit();
            this.lblKenntnisseMehrfachbehinderung = new KiSS4.Gui.KissLabel();
            this.btnVerfuegbarkeit = new KiSS4.Gui.KissButton();
            this.btnEdMaBericht = new KiSS4.Dokument.KissDocumentButton();
            this.edtSucheModul = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheTypBW = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheModul = new KiSS4.Gui.KissLabel();
            this.lblSucheTypBW = new KiSS4.Gui.KissLabel();
            this.lblSucheTypED = new KiSS4.Gui.KissLabel();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEdMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEdMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEdMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTypED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTypED.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNurAktive.Properties)).BeginInit();
            this.tabMitarbeiter.SuspendLayout();
            this.tpgGrunddaten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissMitarbeiterButtonEditVorgesetzter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            this.grpFreieKapazitaet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersichertennummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPostfachOhneNummer.Properties)).BeginInit();
            this.grpModulAktiv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissButtonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenIsBwMitarbeiter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenEdAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenBwAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenIsEdMitarbeiter.Properties)).BeginInit();
            this.grpGrunddatenTypBW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenTypBW)).BeginInit();
            this.grpGrunddatenTypED.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenTypED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenGeschlecht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenGeburtsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAustrittsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAustrittsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenEintrittsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenEintrittsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenPersonalNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenPersonalNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenTelefonMobil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenTelefonMobil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdresseLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdresseLand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdresseLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdresseBezirk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdresseBezirk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdresseKt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdresseOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdressePLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdressePLZOrtKt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdressePostfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdressePostfach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdresseNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdresseStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdresseStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdresseZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdresseZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenName)).BeginInit();
            this.tpgZusatzdaten.SuspendLayout();
            this.grpGrunddatenAusbildungTaetigkeit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenlTaetigkeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbZusatzdatenlTaetigkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenAusbildung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenStrafregisterauszugBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenStrafregisterauszugBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenStrafregisterauszug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenStrafregisterauszug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTabStopBug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenAufenthaltsbewilligung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenAufenthaltsbewilligung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenAufenthaltsbewilligung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenNationalitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenWeitereSprachen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenWeitereSprachen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenSprache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenSprache.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenSprache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenAnzahlKinder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenAnzahlKinder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenZivilstand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenZivilstand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenZivilstand)).BeginInit();
            this.tpgInterview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtInterviewBeurteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInterviewBeurteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInterviewZusammenfassung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInterviewZusammenfassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInterviewInterviewer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInterviewInterviewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInterviewDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInterviewDatum)).BeginInit();
            this.tpgWeiterbildung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEdMitarbeiterKurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKurs)).BeginInit();
            this.panWeiterbildungDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeiterbildungBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeiterbildungBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeiterbildungDispensiert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeiterbildungAbsolviert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeiterbildungAbsolviert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeiterbildungZuAbsolvierenBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeiterbildungZuAbsolvierenBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeiterbildungKurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeiterbildungKurs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeiterbildungKurs)).BeginInit();
            this.tpgPersoenlichkeit.SuspendLayout();
            this.tblPersoenlichkeit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersoenlichkeitErfahrungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersoenlichkeitErfahrungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersoenlichkeitErfahrungenNachAltersklassen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersoenlichkeitVorlieben)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersoenlichkeitPersoenlichkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersoenlichkeitGesundheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersoenlichkeitGesundheit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersoenlichkeitErfahrungenNachAltersklassen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersoenlichkeitVorlieben.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersoenlichkeitPersoenlichkeit.Properties)).BeginInit();
            this.tpgKenntnisse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseWeitereKenntnisse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseWeitereKenntnisse)).BeginInit();
            this.grpKenntnisseHilfetechniken.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseKommunikation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseKommunikation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseTransporte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseTransporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseHilfsmittel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseHilfsmittel)).BeginInit();
            this.grpKenntnissePsychischeBehinderung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseSelbstFremdaggression.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseSelbstFremdaggression)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseVerhaltensstoerung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseVerhaltensstoerung)).BeginInit();
            this.grpKenntnisseGeistigeBehinderung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeistigeBehinderung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseGeistigeBehinderung)).BeginInit();
            this.grpKenntnisseKoerperlicheBehinderung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseEpilepsie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseEpilepsie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseGehirnschaedigung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseGehirnschaedigung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseIMC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseIMC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseMehrfachbehinderung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseMehrfachbehinderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheModul.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTypBW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTypBW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTypBW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTypED)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(966, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(988, 283);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            this.tabControlSearch.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabControlSearch_SelectedTabChanging);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdEdMitarbeiter);
            this.tpgListe.Size = new System.Drawing.Size(976, 245);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSucheTypBW);
            this.tpgSuchen.Controls.Add(this.edtSucheModul);
            this.tpgSuchen.Controls.Add(this.edtSucheNurAktive);
            this.tpgSuchen.Controls.Add(this.edtSucheTypED);
            this.tpgSuchen.Controls.Add(this.edtSucheOrt);
            this.tpgSuchen.Controls.Add(this.lblSucheTypED);
            this.tpgSuchen.Controls.Add(this.lblSucheTypBW);
            this.tpgSuchen.Controls.Add(this.lblSucheModul);
            this.tpgSuchen.Controls.Add(this.lblSucheOrt);
            this.tpgSuchen.Controls.Add(this.edtSucheVorname);
            this.tpgSuchen.Controls.Add(this.lblSucheVorname);
            this.tpgSuchen.Controls.Add(this.edtSucheName);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Size = new System.Drawing.Size(976, 245);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheModul, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheTypBW, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheTypED, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheTypED, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheNurAktive, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheModul, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheTypBW, 0);
            // 
            // grdEdMitarbeiter
            // 
            this.grdEdMitarbeiter.DataSource = this.qryEdMitarbeiter;
            this.grdEdMitarbeiter.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdEdMitarbeiter.EmbeddedNavigator.Name = "";
            this.grdEdMitarbeiter.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdEdMitarbeiter.Location = new System.Drawing.Point(0, 0);
            this.grdEdMitarbeiter.MainView = this.grvEdMitarbeiter;
            this.grdEdMitarbeiter.Name = "grdEdMitarbeiter";
            this.grdEdMitarbeiter.Size = new System.Drawing.Size(976, 245);
            this.grdEdMitarbeiter.TabIndex = 0;
            this.grdEdMitarbeiter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEdMitarbeiter});
            // 
            // qryEdMitarbeiter
            // 
            this.qryEdMitarbeiter.HostControl = this;
            this.qryEdMitarbeiter.SelectStatement = resources.GetString("qryEdMitarbeiter.SelectStatement");
            this.qryEdMitarbeiter.TableName = "EdMitarbeiter";
            this.qryEdMitarbeiter.AfterDelete += new System.EventHandler(this.qryEdMitarbeiter_AfterDelete);
            this.qryEdMitarbeiter.AfterFill += new System.EventHandler(this.qryEdMitarbeiter_AfterFill);
            this.qryEdMitarbeiter.AfterInsert += new System.EventHandler(this.qryEdMitarbeiter_AfterInsert);
            this.qryEdMitarbeiter.AfterPost += new System.EventHandler(this.qryEdMitarbeiter_AfterPost);
            this.qryEdMitarbeiter.BeforeDelete += new System.EventHandler(this.qryEdMitarbeiter_BeforeDelete);
            this.qryEdMitarbeiter.BeforePost += new System.EventHandler(this.qryEdMitarbeiter_BeforePost);
            this.qryEdMitarbeiter.PositionChanged += new System.EventHandler(this.qryEdMitarbeiter_PositionChanged);
            this.qryEdMitarbeiter.PostCompleted += new System.EventHandler(this.qryEdMitarbeiter_PostCompleted);
            // 
            // grvEdMitarbeiter
            // 
            this.grvEdMitarbeiter.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvEdMitarbeiter.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdMitarbeiter.Appearance.Empty.Options.UseBackColor = true;
            this.grvEdMitarbeiter.Appearance.Empty.Options.UseFont = true;
            this.grvEdMitarbeiter.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdMitarbeiter.Appearance.EvenRow.Options.UseFont = true;
            this.grvEdMitarbeiter.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEdMitarbeiter.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdMitarbeiter.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvEdMitarbeiter.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvEdMitarbeiter.Appearance.FocusedCell.Options.UseFont = true;
            this.grvEdMitarbeiter.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvEdMitarbeiter.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEdMitarbeiter.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdMitarbeiter.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvEdMitarbeiter.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvEdMitarbeiter.Appearance.FocusedRow.Options.UseFont = true;
            this.grvEdMitarbeiter.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvEdMitarbeiter.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEdMitarbeiter.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvEdMitarbeiter.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEdMitarbeiter.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEdMitarbeiter.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEdMitarbeiter.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvEdMitarbeiter.Appearance.GroupRow.Options.UseFont = true;
            this.grvEdMitarbeiter.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvEdMitarbeiter.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvEdMitarbeiter.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvEdMitarbeiter.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEdMitarbeiter.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvEdMitarbeiter.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvEdMitarbeiter.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvEdMitarbeiter.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvEdMitarbeiter.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdMitarbeiter.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEdMitarbeiter.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvEdMitarbeiter.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvEdMitarbeiter.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvEdMitarbeiter.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvEdMitarbeiter.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvEdMitarbeiter.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdMitarbeiter.Appearance.OddRow.Options.UseFont = true;
            this.grvEdMitarbeiter.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvEdMitarbeiter.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdMitarbeiter.Appearance.Row.Options.UseBackColor = true;
            this.grvEdMitarbeiter.Appearance.Row.Options.UseFont = true;
            this.grvEdMitarbeiter.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdMitarbeiter.Appearance.SelectedRow.Options.UseFont = true;
            this.grvEdMitarbeiter.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvEdMitarbeiter.Appearance.VertLine.Options.UseBackColor = true;
            this.grvEdMitarbeiter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvEdMitarbeiter.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsBw,
            this.colAktivBw,
            this.colIsEd,
            this.colAktivEd,
            this.colName,
            this.colVorname,
            this.colZusatz,
            this.colAdresse,
            this.colPLZ,
            this.colOrt,
            this.colBezirk,
            this.colLand,
            this.colTelefonMobil,
            this.colTelefon,
            this.colEmail,
            this.colTypBW,
            this.colTypED,
            this.colKurseZuAbsolvieren,
            this.colAnrede});
            this.grvEdMitarbeiter.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvEdMitarbeiter.GridControl = this.grdEdMitarbeiter;
            this.grvEdMitarbeiter.Name = "grvEdMitarbeiter";
            this.grvEdMitarbeiter.OptionsBehavior.Editable = false;
            this.grvEdMitarbeiter.OptionsCustomization.AllowFilter = false;
            this.grvEdMitarbeiter.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvEdMitarbeiter.OptionsNavigation.AutoFocusNewRow = true;
            this.grvEdMitarbeiter.OptionsNavigation.UseTabKey = false;
            this.grvEdMitarbeiter.OptionsView.ColumnAutoWidth = false;
            this.grvEdMitarbeiter.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvEdMitarbeiter.OptionsView.ShowGroupPanel = false;
            this.grvEdMitarbeiter.OptionsView.ShowIndicator = false;
            // 
            // colIsBw
            // 
            this.colIsBw.Caption = "BW";
            this.colIsBw.FieldName = "IsBwMitarbeiter";
            this.colIsBw.Name = "colIsBw";
            this.colIsBw.Visible = true;
            this.colIsBw.VisibleIndex = 0;
            this.colIsBw.Width = 30;
            // 
            // colAktivBw
            // 
            this.colAktivBw.Caption = "Aktiv BW";
            this.colAktivBw.FieldName = "BwAktiv";
            this.colAktivBw.Name = "colAktivBw";
            this.colAktivBw.Visible = true;
            this.colAktivBw.VisibleIndex = 1;
            this.colAktivBw.Width = 59;
            // 
            // colIsEd
            // 
            this.colIsEd.Caption = "ED";
            this.colIsEd.FieldName = "IsEdMitarbeiter";
            this.colIsEd.Name = "colIsEd";
            this.colIsEd.Visible = true;
            this.colIsEd.VisibleIndex = 2;
            this.colIsEd.Width = 30;
            // 
            // colAktivEd
            // 
            this.colAktivEd.Caption = "Aktiv ED";
            this.colAktivEd.FieldName = "EdAktiv";
            this.colAktivEd.Name = "colAktivEd";
            this.colAktivEd.Visible = true;
            this.colAktivEd.VisibleIndex = 3;
            this.colAktivEd.Width = 56;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "LastName";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 4;
            this.colName.Width = 150;
            // 
            // colVorname
            // 
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "FirstName";
            this.colVorname.Name = "colVorname";
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 5;
            this.colVorname.Width = 150;
            // 
            // colZusatz
            // 
            this.colZusatz.Caption = "Zusatz";
            this.colZusatz.FieldName = "Zusatz";
            this.colZusatz.Name = "colZusatz";
            this.colZusatz.Visible = true;
            this.colZusatz.VisibleIndex = 6;
            this.colZusatz.Width = 70;
            // 
            // colAdresse
            // 
            this.colAdresse.Caption = "Adresse";
            this.colAdresse.FieldName = "Adresse";
            this.colAdresse.Name = "colAdresse";
            this.colAdresse.Visible = true;
            this.colAdresse.VisibleIndex = 7;
            this.colAdresse.Width = 150;
            // 
            // colPLZ
            // 
            this.colPLZ.Caption = "PLZ";
            this.colPLZ.FieldName = "PLZ";
            this.colPLZ.Name = "colPLZ";
            this.colPLZ.Visible = true;
            this.colPLZ.VisibleIndex = 8;
            this.colPLZ.Width = 55;
            // 
            // colOrt
            // 
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "Ort";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 9;
            this.colOrt.Width = 150;
            // 
            // colBezirk
            // 
            this.colBezirk.Caption = "Bezirk";
            this.colBezirk.FieldName = "Bezirk";
            this.colBezirk.Name = "colBezirk";
            this.colBezirk.Visible = true;
            this.colBezirk.VisibleIndex = 10;
            this.colBezirk.Width = 120;
            // 
            // colLand
            // 
            this.colLand.Caption = "Land";
            this.colLand.FieldName = "AdresseLand";
            this.colLand.Name = "colLand";
            this.colLand.Visible = true;
            this.colLand.VisibleIndex = 11;
            this.colLand.Width = 100;
            // 
            // colTelefonMobil
            // 
            this.colTelefonMobil.Caption = "Telefon mobil";
            this.colTelefonMobil.FieldName = "PhoneMobile";
            this.colTelefonMobil.Name = "colTelefonMobil";
            this.colTelefonMobil.Visible = true;
            this.colTelefonMobil.VisibleIndex = 13;
            this.colTelefonMobil.Width = 100;
            // 
            // colTelefon
            // 
            this.colTelefon.Caption = "Telefon";
            this.colTelefon.FieldName = "Telefon";
            this.colTelefon.Name = "colTelefon";
            this.colTelefon.Visible = true;
            this.colTelefon.VisibleIndex = 12;
            this.colTelefon.Width = 120;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "E-Mail";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 14;
            this.colEmail.Width = 120;
            // 
            // colTypBW
            // 
            this.colTypBW.Caption = "Typ BW";
            this.colTypBW.FieldName = "TypBW";
            this.colTypBW.Name = "colTypBW";
            this.colTypBW.Visible = true;
            this.colTypBW.VisibleIndex = 15;
            this.colTypBW.Width = 150;
            // 
            // colTypED
            // 
            this.colTypED.Caption = "Typ ED";
            this.colTypED.FieldName = "TypED";
            this.colTypED.Name = "colTypED";
            this.colTypED.Visible = true;
            this.colTypED.VisibleIndex = 16;
            this.colTypED.Width = 150;
            // 
            // colKurseZuAbsolvieren
            // 
            this.colKurseZuAbsolvieren.Caption = "Zu absolvieren";
            this.colKurseZuAbsolvieren.FieldName = "KurseZuAbsolvieren";
            this.colKurseZuAbsolvieren.Name = "colKurseZuAbsolvieren";
            this.colKurseZuAbsolvieren.Visible = true;
            this.colKurseZuAbsolvieren.VisibleIndex = 17;
            this.colKurseZuAbsolvieren.Width = 100;
            // 
            // colAnrede
            // 
            this.colAnrede.Caption = "Anrede";
            this.colAnrede.FieldName = "Anrede";
            this.colAnrede.Name = "colAnrede";
            this.colAnrede.Visible = true;
            this.colAnrede.VisibleIndex = 18;
            this.colAnrede.Width = 100;
            // 
            // lblSucheName
            // 
            this.lblSucheName.Location = new System.Drawing.Point(30, 40);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(95, 24);
            this.lblSucheName.TabIndex = 1;
            this.lblSucheName.Text = "Name";
            this.lblSucheName.UseCompatibleTextRendering = true;
            // 
            // edtSucheName
            // 
            this.edtSucheName.Location = new System.Drawing.Point(131, 40);
            this.edtSucheName.Name = "edtSucheName";
            this.edtSucheName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheName.Properties.Name = "editNameX.Properties";
            this.edtSucheName.Size = new System.Drawing.Size(223, 24);
            this.edtSucheName.TabIndex = 2;
            // 
            // lblSucheVorname
            // 
            this.lblSucheVorname.Location = new System.Drawing.Point(30, 70);
            this.lblSucheVorname.Name = "lblSucheVorname";
            this.lblSucheVorname.Size = new System.Drawing.Size(95, 24);
            this.lblSucheVorname.TabIndex = 3;
            this.lblSucheVorname.Text = "Vorname";
            this.lblSucheVorname.UseCompatibleTextRendering = true;
            // 
            // edtSucheVorname
            // 
            this.edtSucheVorname.Location = new System.Drawing.Point(131, 70);
            this.edtSucheVorname.Name = "edtSucheVorname";
            this.edtSucheVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVorname.Properties.Name = "editVornameX.Properties";
            this.edtSucheVorname.Size = new System.Drawing.Size(223, 24);
            this.edtSucheVorname.TabIndex = 4;
            // 
            // lblSucheOrt
            // 
            this.lblSucheOrt.Location = new System.Drawing.Point(30, 100);
            this.lblSucheOrt.Name = "lblSucheOrt";
            this.lblSucheOrt.Size = new System.Drawing.Size(95, 24);
            this.lblSucheOrt.TabIndex = 5;
            this.lblSucheOrt.Text = "Ort";
            this.lblSucheOrt.UseCompatibleTextRendering = true;
            // 
            // edtSucheOrt
            // 
            this.edtSucheOrt.Location = new System.Drawing.Point(131, 100);
            this.edtSucheOrt.Name = "edtSucheOrt";
            this.edtSucheOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheOrt.Properties.Appearance.Options.UseFont = true;
            this.edtSucheOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheOrt.Properties.Name = "editOrtX.Properties";
            this.edtSucheOrt.Size = new System.Drawing.Size(223, 24);
            this.edtSucheOrt.TabIndex = 6;
            // 
            // edtSucheTypED
            // 
            this.edtSucheTypED.Location = new System.Drawing.Point(501, 70);
            this.edtSucheTypED.LOVName = "EdTyp";
            this.edtSucheTypED.Name = "edtSucheTypED";
            this.edtSucheTypED.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTypED.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTypED.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTypED.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTypED.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTypED.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTypED.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheTypED.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTypED.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheTypED.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheTypED.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSucheTypED.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSucheTypED.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTypED.Properties.NullText = "";
            this.edtSucheTypED.Properties.ShowFooter = false;
            this.edtSucheTypED.Properties.ShowHeader = false;
            this.edtSucheTypED.Size = new System.Drawing.Size(223, 24);
            this.edtSucheTypED.TabIndex = 12;
            // 
            // edtSucheNurAktive
            // 
            this.edtSucheNurAktive.EditValue = true;
            this.edtSucheNurAktive.Location = new System.Drawing.Point(501, 102);
            this.edtSucheNurAktive.Name = "edtSucheNurAktive";
            this.edtSucheNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSucheNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheNurAktive.Properties.Caption = "Nur Aktive";
            this.edtSucheNurAktive.Size = new System.Drawing.Size(223, 19);
            this.edtSucheNurAktive.TabIndex = 13;
            // 
            // tabMitarbeiter
            // 
            this.tabMitarbeiter.Controls.Add(this.tpgGrunddaten);
            this.tabMitarbeiter.Controls.Add(this.tpgZusatzdaten);
            this.tabMitarbeiter.Controls.Add(this.tpgInterview);
            this.tabMitarbeiter.Controls.Add(this.tpgWeiterbildung);
            this.tabMitarbeiter.Controls.Add(this.tpgPersoenlichkeit);
            this.tabMitarbeiter.Controls.Add(this.tpgKenntnisse);
            this.tabMitarbeiter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabMitarbeiter.Location = new System.Drawing.Point(0, 283);
            this.tabMitarbeiter.Name = "tabMitarbeiter";
            this.tabMitarbeiter.ShowFixedWidthTooltip = true;
            this.tabMitarbeiter.Size = new System.Drawing.Size(988, 380);
            this.tabMitarbeiter.TabIndex = 1;
            this.tabMitarbeiter.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgGrunddaten,
            this.tpgZusatzdaten,
            this.tpgInterview,
            this.tpgWeiterbildung,
            this.tpgPersoenlichkeit,
            this.tpgKenntnisse});
            this.tabMitarbeiter.TabsLineColor = System.Drawing.Color.Black;
            this.tabMitarbeiter.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabMitarbeiter.Text = "kissTabControlEx1";
            this.tabMitarbeiter.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabMitarbeiter_SelectedTabChanged);
            this.tabMitarbeiter.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabMitarbeiter_SelectedTabChanging);
            // 
            // tpgGrunddaten
            // 
            this.tpgGrunddaten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tpgGrunddaten.AutoScroll = true;
            this.tpgGrunddaten.AutoScrollMinSize = new System.Drawing.Size(976, 301);
            this.tpgGrunddaten.Controls.Add(this.kissMitarbeiterButtonEditVorgesetzter);
            this.tpgGrunddaten.Controls.Add(this.kissLabel1);
            this.tpgGrunddaten.Controls.Add(this.grpFreieKapazitaet);
            this.tpgGrunddaten.Controls.Add(this.lblVersichertennummer);
            this.tpgGrunddaten.Controls.Add(this.edtVersichertennummer);
            this.tpgGrunddaten.Controls.Add(this.chkPostfachOhneNummer);
            this.tpgGrunddaten.Controls.Add(this.grpModulAktiv);
            this.tpgGrunddaten.Controls.Add(this.grpGrunddatenTypBW);
            this.tpgGrunddaten.Controls.Add(this.grpGrunddatenTypED);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenGeschlecht);
            this.tpgGrunddaten.Controls.Add(this.lblGrunddatenGeschlecht);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenGeburtsdatum);
            this.tpgGrunddaten.Controls.Add(this.lblGrunddatenGeburtsdatum);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenAustrittsdatum);
            this.tpgGrunddaten.Controls.Add(this.lblGrunddatenAustrittsdatum);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenEintrittsdatum);
            this.tpgGrunddaten.Controls.Add(this.lblGrunddatenEintrittsdatum);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenPersonalNr);
            this.tpgGrunddaten.Controls.Add(this.lblGrunddatenPersonalNr);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenFax);
            this.tpgGrunddaten.Controls.Add(this.lblGrunddatenFax);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenTelefonMobil);
            this.tpgGrunddaten.Controls.Add(this.lblGrunddatenTelefonMobil);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenTelefon);
            this.tpgGrunddaten.Controls.Add(this.lblGrunddatenTelefon);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenEmail);
            this.tpgGrunddaten.Controls.Add(this.lblGrunddatenEmail);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenAdresseLand);
            this.tpgGrunddaten.Controls.Add(this.lblGrunddatenAdresseLand);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenAdresseBezirk);
            this.tpgGrunddaten.Controls.Add(this.lblGrunddatenAdresseBezirk);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenAdresseKt);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenAdresseOrt);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenAdressePLZ);
            this.tpgGrunddaten.Controls.Add(this.lblGrunddatenAdressePLZOrtKt);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenAdressePostfach);
            this.tpgGrunddaten.Controls.Add(this.lblGrunddatenAdressePostfach);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenAdresseNr);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenAdresseStrasse);
            this.tpgGrunddaten.Controls.Add(this.lblGrunddatenAdresseStrasseNr);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenAdresseZusatz);
            this.tpgGrunddaten.Controls.Add(this.lblGrunddatenAdresseZusatz);
            this.tpgGrunddaten.Controls.Add(this.edtGrunddatenName);
            this.tpgGrunddaten.Controls.Add(this.lblGrunddatenName);
            this.tpgGrunddaten.Location = new System.Drawing.Point(6, 6);
            this.tpgGrunddaten.Name = "tpgGrunddaten";
            this.tpgGrunddaten.Size = new System.Drawing.Size(976, 342);
            this.tpgGrunddaten.TabIndex = 0;
            this.tpgGrunddaten.Title = "Grunddaten";
            // 
            // kissMitarbeiterButtonEditVorgesetzter
            // 
            this.kissMitarbeiterButtonEditVorgesetzter.DataMember = "NameVornameVorgesetzter";
            this.kissMitarbeiterButtonEditVorgesetzter.DataMemberUserId = "UserIDVorgesetzter";
            this.kissMitarbeiterButtonEditVorgesetzter.DataSource = this.qryEdMitarbeiter;
            this.kissMitarbeiterButtonEditVorgesetzter.Location = new System.Drawing.Point(110, 306);
            this.kissMitarbeiterButtonEditVorgesetzter.Name = "kissMitarbeiterButtonEditVorgesetzter";
            this.kissMitarbeiterButtonEditVorgesetzter.PiMode = true;
            this.kissMitarbeiterButtonEditVorgesetzter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissMitarbeiterButtonEditVorgesetzter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissMitarbeiterButtonEditVorgesetzter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissMitarbeiterButtonEditVorgesetzter.Properties.Appearance.Options.UseBackColor = true;
            this.kissMitarbeiterButtonEditVorgesetzter.Properties.Appearance.Options.UseBorderColor = true;
            this.kissMitarbeiterButtonEditVorgesetzter.Properties.Appearance.Options.UseFont = true;
            this.kissMitarbeiterButtonEditVorgesetzter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject22.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject22.Options.UseBackColor = true;
            this.kissMitarbeiterButtonEditVorgesetzter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject22)});
            this.kissMitarbeiterButtonEditVorgesetzter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissMitarbeiterButtonEditVorgesetzter.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.kissMitarbeiterButtonEditVorgesetzter.ShowToolTips = false;
            this.kissMitarbeiterButtonEditVorgesetzter.Size = new System.Drawing.Size(288, 24);
            this.kissMitarbeiterButtonEditVorgesetzter.TabIndex = 43;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(3, 306);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(101, 24);
            this.kissLabel1.TabIndex = 42;
            this.kissLabel1.Text = "Vorgesetzter";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // grpFreieKapazitaet
            // 
            this.grpFreieKapazitaet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFreieKapazitaet.Controls.Add(this.kissMemoEdit1);
            this.grpFreieKapazitaet.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpFreieKapazitaet.Location = new System.Drawing.Point(862, 9);
            this.grpFreieKapazitaet.Name = "grpFreieKapazitaet";
            this.grpFreieKapazitaet.Size = new System.Drawing.Size(105, 137);
            this.grpFreieKapazitaet.TabIndex = 41;
            this.grpFreieKapazitaet.TabStop = false;
            this.grpFreieKapazitaet.Text = "Freie Kapazität";
            // 
            // kissMemoEdit1
            // 
            this.kissMemoEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kissMemoEdit1.DataMember = "FreieKapazitaet";
            this.kissMemoEdit1.DataSource = this.qryEdMitarbeiter;
            this.kissMemoEdit1.Location = new System.Drawing.Point(6, 20);
            this.kissMemoEdit1.Name = "kissMemoEdit1";
            this.kissMemoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissMemoEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissMemoEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissMemoEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissMemoEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissMemoEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissMemoEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissMemoEdit1.Size = new System.Drawing.Size(93, 111);
            this.kissMemoEdit1.TabIndex = 0;
            // 
            // lblVersichertennummer
            // 
            this.lblVersichertennummer.Location = new System.Drawing.Point(3, 283);
            this.lblVersichertennummer.Name = "lblVersichertennummer";
            this.lblVersichertennummer.Size = new System.Drawing.Size(101, 24);
            this.lblVersichertennummer.TabIndex = 40;
            this.lblVersichertennummer.Text = "Vers.-Nr.";
            // 
            // edtVersichertennummer
            // 
            this.edtVersichertennummer.DataMember = "Versichertennummer";
            this.edtVersichertennummer.DataSource = this.qryEdMitarbeiter;
            this.edtVersichertennummer.Location = new System.Drawing.Point(110, 283);
            this.edtVersichertennummer.Name = "edtVersichertennummer";
            this.edtVersichertennummer.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVersichertennummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVersichertennummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersichertennummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersichertennummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseFont = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseTextOptions = true;
            this.edtVersichertennummer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtVersichertennummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersichertennummer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVersichertennummer.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtVersichertennummer.Properties.DisplayFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummer.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersichertennummer.Properties.EditFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummer.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersichertennummer.Properties.Mask.EditMask = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummer.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtVersichertennummer.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtVersichertennummer.Properties.MaxLength = 13;
            this.edtVersichertennummer.Properties.Precision = 0;
            this.edtVersichertennummer.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtVersichertennummer.Size = new System.Drawing.Size(288, 24);
            this.edtVersichertennummer.TabIndex = 39;
            // 
            // chkPostfachOhneNummer
            // 
            this.chkPostfachOhneNummer.DataMember = "PostfachOhneNr";
            this.chkPostfachOhneNummer.DataSource = this.qryEdMitarbeiter;
            this.chkPostfachOhneNummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkPostfachOhneNummer.Location = new System.Drawing.Point(326, 89);
            this.chkPostfachOhneNummer.Name = "chkPostfachOhneNummer";
            this.chkPostfachOhneNummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkPostfachOhneNummer.Properties.Appearance.Options.UseBackColor = true;
            this.chkPostfachOhneNummer.Properties.Caption = "ohne Nr.";
            this.chkPostfachOhneNummer.Properties.ReadOnly = true;
            this.chkPostfachOhneNummer.Size = new System.Drawing.Size(72, 19);
            this.chkPostfachOhneNummer.TabIndex = 38;
            // 
            // grpModulAktiv
            // 
            this.grpModulAktiv.Controls.Add(this.kissButtonEdit1);
            this.grpModulAktiv.Controls.Add(this.edtGrunddatenIsBwMitarbeiter);
            this.grpModulAktiv.Controls.Add(this.edtGrunddatenEdAktiv);
            this.grpModulAktiv.Controls.Add(this.edtGrunddatenBwAktiv);
            this.grpModulAktiv.Controls.Add(this.edtGrunddatenIsEdMitarbeiter);
            this.grpModulAktiv.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grpModulAktiv.Location = new System.Drawing.Point(691, 9);
            this.grpModulAktiv.Name = "grpModulAktiv";
            this.grpModulAktiv.Size = new System.Drawing.Size(165, 137);
            this.grpModulAktiv.TabIndex = 35;
            this.grpModulAktiv.TabStop = false;
            this.grpModulAktiv.Text = "Modul/Aktiv";
            // 
            // kissButtonEdit1
            // 
            this.kissButtonEdit1.DataMember = "NameVornameInterviewer";
            this.kissButtonEdit1.DataSource = this.qryEdMitarbeiter;
            this.kissButtonEdit1.Location = new System.Drawing.Point(-142, 30);
            this.kissButtonEdit1.Name = "kissButtonEdit1";
            this.kissButtonEdit1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissButtonEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissButtonEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissButtonEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissButtonEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissButtonEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissButtonEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            this.kissButtonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19)});
            this.kissButtonEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissButtonEdit1.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.kissButtonEdit1.Size = new System.Drawing.Size(136, 24);
            this.kissButtonEdit1.TabIndex = 43;
            // 
            // edtGrunddatenIsBwMitarbeiter
            // 
            this.edtGrunddatenIsBwMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGrunddatenIsBwMitarbeiter.DataMember = "IsBwMitarbeiter";
            this.edtGrunddatenIsBwMitarbeiter.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenIsBwMitarbeiter.Location = new System.Drawing.Point(11, 19);
            this.edtGrunddatenIsBwMitarbeiter.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtGrunddatenIsBwMitarbeiter.Name = "edtGrunddatenIsBwMitarbeiter";
            this.edtGrunddatenIsBwMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenIsBwMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenIsBwMitarbeiter.Properties.Caption = "BW Mitarbeiter";
            this.edtGrunddatenIsBwMitarbeiter.Size = new System.Drawing.Size(144, 19);
            this.edtGrunddatenIsBwMitarbeiter.TabIndex = 0;
            this.edtGrunddatenIsBwMitarbeiter.CheckedChanged += new System.EventHandler(this.edtGrunddatenIsBwMitarbeiter_CheckedChanged);
            // 
            // edtGrunddatenEdAktiv
            // 
            this.edtGrunddatenEdAktiv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGrunddatenEdAktiv.DataMember = "EdAktiv";
            this.edtGrunddatenEdAktiv.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenEdAktiv.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenEdAktiv.Location = new System.Drawing.Point(11, 108);
            this.edtGrunddatenEdAktiv.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtGrunddatenEdAktiv.Name = "edtGrunddatenEdAktiv";
            this.edtGrunddatenEdAktiv.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenEdAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenEdAktiv.Properties.Caption = "Aktiv ED";
            this.edtGrunddatenEdAktiv.Properties.ReadOnly = true;
            this.edtGrunddatenEdAktiv.Size = new System.Drawing.Size(144, 19);
            this.edtGrunddatenEdAktiv.TabIndex = 3;
            // 
            // edtGrunddatenBwAktiv
            // 
            this.edtGrunddatenBwAktiv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGrunddatenBwAktiv.DataMember = "BwAktiv";
            this.edtGrunddatenBwAktiv.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenBwAktiv.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenBwAktiv.Location = new System.Drawing.Point(11, 44);
            this.edtGrunddatenBwAktiv.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtGrunddatenBwAktiv.Name = "edtGrunddatenBwAktiv";
            this.edtGrunddatenBwAktiv.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenBwAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenBwAktiv.Properties.Caption = "Aktiv BW";
            this.edtGrunddatenBwAktiv.Properties.ReadOnly = true;
            this.edtGrunddatenBwAktiv.Size = new System.Drawing.Size(144, 19);
            this.edtGrunddatenBwAktiv.TabIndex = 1;
            // 
            // edtGrunddatenIsEdMitarbeiter
            // 
            this.edtGrunddatenIsEdMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGrunddatenIsEdMitarbeiter.DataMember = "IsEdMitarbeiter";
            this.edtGrunddatenIsEdMitarbeiter.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenIsEdMitarbeiter.Location = new System.Drawing.Point(11, 83);
            this.edtGrunddatenIsEdMitarbeiter.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtGrunddatenIsEdMitarbeiter.Name = "edtGrunddatenIsEdMitarbeiter";
            this.edtGrunddatenIsEdMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenIsEdMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenIsEdMitarbeiter.Properties.Caption = "ED Mitarbeiter";
            this.edtGrunddatenIsEdMitarbeiter.Size = new System.Drawing.Size(144, 19);
            this.edtGrunddatenIsEdMitarbeiter.TabIndex = 2;
            this.edtGrunddatenIsEdMitarbeiter.CheckedChanged += new System.EventHandler(this.edtGrunddatenIsEdMitarbeiter_CheckedChanged);
            // 
            // grpGrunddatenTypBW
            // 
            this.grpGrunddatenTypBW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGrunddatenTypBW.Controls.Add(this.edtGrunddatenTypBW);
            this.grpGrunddatenTypBW.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grpGrunddatenTypBW.Location = new System.Drawing.Point(431, 152);
            this.grpGrunddatenTypBW.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.grpGrunddatenTypBW.Name = "grpGrunddatenTypBW";
            this.grpGrunddatenTypBW.Padding = new System.Windows.Forms.Padding(6);
            this.grpGrunddatenTypBW.Size = new System.Drawing.Size(536, 70);
            this.grpGrunddatenTypBW.TabIndex = 36;
            this.grpGrunddatenTypBW.TabStop = false;
            this.grpGrunddatenTypBW.Text = "Typ Begleitetes Wohnen";
            // 
            // edtGrunddatenTypBW
            // 
            this.edtGrunddatenTypBW.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtGrunddatenTypBW.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenTypBW.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenTypBW.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenTypBW.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtGrunddatenTypBW.CheckOnClick = true;
            this.edtGrunddatenTypBW.DataMember = "GrunddatenBwTypCodes";
            this.edtGrunddatenTypBW.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenTypBW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtGrunddatenTypBW.Location = new System.Drawing.Point(6, 20);
            this.edtGrunddatenTypBW.LOVName = "BwTyp";
            this.edtGrunddatenTypBW.MultiColumn = true;
            this.edtGrunddatenTypBW.Name = "edtGrunddatenTypBW";
            this.edtGrunddatenTypBW.Size = new System.Drawing.Size(524, 44);
            this.edtGrunddatenTypBW.TabIndex = 0;
            // 
            // grpGrunddatenTypED
            // 
            this.grpGrunddatenTypED.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGrunddatenTypED.Controls.Add(this.edtGrunddatenTypED);
            this.grpGrunddatenTypED.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grpGrunddatenTypED.Location = new System.Drawing.Point(431, 228);
            this.grpGrunddatenTypED.Name = "grpGrunddatenTypED";
            this.grpGrunddatenTypED.Padding = new System.Windows.Forms.Padding(6);
            this.grpGrunddatenTypED.Size = new System.Drawing.Size(535, 69);
            this.grpGrunddatenTypED.TabIndex = 37;
            this.grpGrunddatenTypED.TabStop = false;
            this.grpGrunddatenTypED.Text = "Typ Entlastungsdienst";
            this.grpGrunddatenTypED.UseCompatibleTextRendering = true;
            // 
            // edtGrunddatenTypED
            // 
            this.edtGrunddatenTypED.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtGrunddatenTypED.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenTypED.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenTypED.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenTypED.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtGrunddatenTypED.CheckOnClick = true;
            this.edtGrunddatenTypED.DataMember = "GrunddatenEDTypCodes";
            this.edtGrunddatenTypED.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenTypED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtGrunddatenTypED.Location = new System.Drawing.Point(6, 20);
            this.edtGrunddatenTypED.LOVName = "EDTyp";
            this.edtGrunddatenTypED.MultiColumn = true;
            this.edtGrunddatenTypED.Name = "edtGrunddatenTypED";
            this.edtGrunddatenTypED.Size = new System.Drawing.Size(523, 43);
            this.edtGrunddatenTypED.TabIndex = 0;
            // 
            // edtGrunddatenGeschlecht
            // 
            this.edtGrunddatenGeschlecht.DataMember = "GenderCode";
            this.edtGrunddatenGeschlecht.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenGeschlecht.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenGeschlecht.Location = new System.Drawing.Point(549, 122);
            this.edtGrunddatenGeschlecht.LOVName = "Geschlecht";
            this.edtGrunddatenGeschlecht.Name = "edtGrunddatenGeschlecht";
            this.edtGrunddatenGeschlecht.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenGeschlecht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenGeschlecht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenGeschlecht.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenGeschlecht.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenGeschlecht.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenGeschlecht.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGrunddatenGeschlecht.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenGeschlecht.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGrunddatenGeschlecht.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGrunddatenGeschlecht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGrunddatenGeschlecht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGrunddatenGeschlecht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrunddatenGeschlecht.Properties.NullText = "";
            this.edtGrunddatenGeschlecht.Properties.ReadOnly = true;
            this.edtGrunddatenGeschlecht.Properties.ShowFooter = false;
            this.edtGrunddatenGeschlecht.Properties.ShowHeader = false;
            this.edtGrunddatenGeschlecht.Size = new System.Drawing.Size(136, 24);
            this.edtGrunddatenGeschlecht.TabIndex = 34;
            // 
            // lblGrunddatenGeschlecht
            // 
            this.lblGrunddatenGeschlecht.Location = new System.Drawing.Point(431, 122);
            this.lblGrunddatenGeschlecht.Name = "lblGrunddatenGeschlecht";
            this.lblGrunddatenGeschlecht.Size = new System.Drawing.Size(112, 24);
            this.lblGrunddatenGeschlecht.TabIndex = 33;
            this.lblGrunddatenGeschlecht.Text = "Geschlecht";
            this.lblGrunddatenGeschlecht.UseCompatibleTextRendering = true;
            // 
            // edtGrunddatenGeburtsdatum
            // 
            this.edtGrunddatenGeburtsdatum.DataMember = "Geburtstag";
            this.edtGrunddatenGeburtsdatum.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenGeburtsdatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenGeburtsdatum.EditValue = null;
            this.edtGrunddatenGeburtsdatum.Location = new System.Drawing.Point(549, 92);
            this.edtGrunddatenGeburtsdatum.Name = "edtGrunddatenGeburtsdatum";
            this.edtGrunddatenGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGrunddatenGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtGrunddatenGeburtsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGrunddatenGeburtsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtGrunddatenGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrunddatenGeburtsdatum.Properties.ReadOnly = true;
            this.edtGrunddatenGeburtsdatum.Properties.ShowToday = false;
            this.edtGrunddatenGeburtsdatum.Size = new System.Drawing.Size(100, 24);
            this.edtGrunddatenGeburtsdatum.TabIndex = 32;
            // 
            // lblGrunddatenGeburtsdatum
            // 
            this.lblGrunddatenGeburtsdatum.Location = new System.Drawing.Point(431, 92);
            this.lblGrunddatenGeburtsdatum.Name = "lblGrunddatenGeburtsdatum";
            this.lblGrunddatenGeburtsdatum.Size = new System.Drawing.Size(112, 24);
            this.lblGrunddatenGeburtsdatum.TabIndex = 31;
            this.lblGrunddatenGeburtsdatum.Text = "Geburtsdatum";
            this.lblGrunddatenGeburtsdatum.UseCompatibleTextRendering = true;
            // 
            // edtGrunddatenAustrittsdatum
            // 
            this.edtGrunddatenAustrittsdatum.DataMember = "Austrittsdatum";
            this.edtGrunddatenAustrittsdatum.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenAustrittsdatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenAustrittsdatum.EditValue = null;
            this.edtGrunddatenAustrittsdatum.Location = new System.Drawing.Point(549, 62);
            this.edtGrunddatenAustrittsdatum.Name = "edtGrunddatenAustrittsdatum";
            this.edtGrunddatenAustrittsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGrunddatenAustrittsdatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenAustrittsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenAustrittsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenAustrittsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenAustrittsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenAustrittsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenAustrittsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtGrunddatenAustrittsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGrunddatenAustrittsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtGrunddatenAustrittsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrunddatenAustrittsdatum.Properties.ReadOnly = true;
            this.edtGrunddatenAustrittsdatum.Properties.ShowToday = false;
            this.edtGrunddatenAustrittsdatum.Size = new System.Drawing.Size(100, 24);
            this.edtGrunddatenAustrittsdatum.TabIndex = 30;
            // 
            // lblGrunddatenAustrittsdatum
            // 
            this.lblGrunddatenAustrittsdatum.Location = new System.Drawing.Point(431, 62);
            this.lblGrunddatenAustrittsdatum.Name = "lblGrunddatenAustrittsdatum";
            this.lblGrunddatenAustrittsdatum.Size = new System.Drawing.Size(112, 24);
            this.lblGrunddatenAustrittsdatum.TabIndex = 29;
            this.lblGrunddatenAustrittsdatum.Text = "Austrittsdatum";
            this.lblGrunddatenAustrittsdatum.UseCompatibleTextRendering = true;
            // 
            // edtGrunddatenEintrittsdatum
            // 
            this.edtGrunddatenEintrittsdatum.DataMember = "Eintrittsdatum";
            this.edtGrunddatenEintrittsdatum.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenEintrittsdatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenEintrittsdatum.EditValue = null;
            this.edtGrunddatenEintrittsdatum.Location = new System.Drawing.Point(549, 39);
            this.edtGrunddatenEintrittsdatum.Name = "edtGrunddatenEintrittsdatum";
            this.edtGrunddatenEintrittsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGrunddatenEintrittsdatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenEintrittsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenEintrittsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenEintrittsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenEintrittsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenEintrittsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenEintrittsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtGrunddatenEintrittsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGrunddatenEintrittsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtGrunddatenEintrittsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrunddatenEintrittsdatum.Properties.ReadOnly = true;
            this.edtGrunddatenEintrittsdatum.Properties.ShowToday = false;
            this.edtGrunddatenEintrittsdatum.Size = new System.Drawing.Size(100, 24);
            this.edtGrunddatenEintrittsdatum.TabIndex = 28;
            // 
            // lblGrunddatenEintrittsdatum
            // 
            this.lblGrunddatenEintrittsdatum.Location = new System.Drawing.Point(431, 39);
            this.lblGrunddatenEintrittsdatum.Name = "lblGrunddatenEintrittsdatum";
            this.lblGrunddatenEintrittsdatum.Size = new System.Drawing.Size(112, 24);
            this.lblGrunddatenEintrittsdatum.TabIndex = 27;
            this.lblGrunddatenEintrittsdatum.Text = "Eintrittsdatum";
            this.lblGrunddatenEintrittsdatum.UseCompatibleTextRendering = true;
            // 
            // edtGrunddatenPersonalNr
            // 
            this.edtGrunddatenPersonalNr.DataMember = "MitarbeiterNr";
            this.edtGrunddatenPersonalNr.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenPersonalNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenPersonalNr.Location = new System.Drawing.Point(549, 9);
            this.edtGrunddatenPersonalNr.Name = "edtGrunddatenPersonalNr";
            this.edtGrunddatenPersonalNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGrunddatenPersonalNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenPersonalNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenPersonalNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenPersonalNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenPersonalNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenPersonalNr.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenPersonalNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrunddatenPersonalNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrunddatenPersonalNr.Properties.ReadOnly = true;
            this.edtGrunddatenPersonalNr.Size = new System.Drawing.Size(136, 24);
            this.edtGrunddatenPersonalNr.TabIndex = 26;
            // 
            // lblGrunddatenPersonalNr
            // 
            this.lblGrunddatenPersonalNr.Location = new System.Drawing.Point(431, 9);
            this.lblGrunddatenPersonalNr.Name = "lblGrunddatenPersonalNr";
            this.lblGrunddatenPersonalNr.Size = new System.Drawing.Size(112, 24);
            this.lblGrunddatenPersonalNr.TabIndex = 25;
            this.lblGrunddatenPersonalNr.Text = "Personal-Nr.";
            this.lblGrunddatenPersonalNr.UseCompatibleTextRendering = true;
            // 
            // edtGrunddatenFax
            // 
            this.edtGrunddatenFax.DataMember = "Fax";
            this.edtGrunddatenFax.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenFax.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenFax.Location = new System.Drawing.Point(110, 253);
            this.edtGrunddatenFax.Name = "edtGrunddatenFax";
            this.edtGrunddatenFax.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenFax.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenFax.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenFax.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrunddatenFax.Properties.MaxLength = 255;
            this.edtGrunddatenFax.Properties.ReadOnly = true;
            this.edtGrunddatenFax.Size = new System.Drawing.Size(288, 24);
            this.edtGrunddatenFax.TabIndex = 24;
            // 
            // lblGrunddatenFax
            // 
            this.lblGrunddatenFax.Location = new System.Drawing.Point(3, 253);
            this.lblGrunddatenFax.Name = "lblGrunddatenFax";
            this.lblGrunddatenFax.Size = new System.Drawing.Size(101, 24);
            this.lblGrunddatenFax.TabIndex = 23;
            this.lblGrunddatenFax.Text = "Fax";
            this.lblGrunddatenFax.UseCompatibleTextRendering = true;
            // 
            // edtGrunddatenTelefonMobil
            // 
            this.edtGrunddatenTelefonMobil.DataMember = "PhoneMobile";
            this.edtGrunddatenTelefonMobil.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenTelefonMobil.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenTelefonMobil.Location = new System.Drawing.Point(110, 230);
            this.edtGrunddatenTelefonMobil.Name = "edtGrunddatenTelefonMobil";
            this.edtGrunddatenTelefonMobil.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenTelefonMobil.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenTelefonMobil.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenTelefonMobil.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenTelefonMobil.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenTelefonMobil.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenTelefonMobil.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrunddatenTelefonMobil.Properties.MaxLength = 255;
            this.edtGrunddatenTelefonMobil.Properties.ReadOnly = true;
            this.edtGrunddatenTelefonMobil.Size = new System.Drawing.Size(288, 24);
            this.edtGrunddatenTelefonMobil.TabIndex = 22;
            // 
            // lblGrunddatenTelefonMobil
            // 
            this.lblGrunddatenTelefonMobil.Location = new System.Drawing.Point(3, 230);
            this.lblGrunddatenTelefonMobil.Name = "lblGrunddatenTelefonMobil";
            this.lblGrunddatenTelefonMobil.Size = new System.Drawing.Size(101, 24);
            this.lblGrunddatenTelefonMobil.TabIndex = 21;
            this.lblGrunddatenTelefonMobil.Text = "Telefon mobil";
            this.lblGrunddatenTelefonMobil.UseCompatibleTextRendering = true;
            // 
            // edtGrunddatenTelefon
            // 
            this.edtGrunddatenTelefon.DataMember = "Telefon";
            this.edtGrunddatenTelefon.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenTelefon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenTelefon.Location = new System.Drawing.Point(110, 207);
            this.edtGrunddatenTelefon.Name = "edtGrunddatenTelefon";
            this.edtGrunddatenTelefon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrunddatenTelefon.Properties.ReadOnly = true;
            this.edtGrunddatenTelefon.Size = new System.Drawing.Size(288, 24);
            this.edtGrunddatenTelefon.TabIndex = 20;
            // 
            // lblGrunddatenTelefon
            // 
            this.lblGrunddatenTelefon.Location = new System.Drawing.Point(3, 207);
            this.lblGrunddatenTelefon.Name = "lblGrunddatenTelefon";
            this.lblGrunddatenTelefon.Size = new System.Drawing.Size(101, 24);
            this.lblGrunddatenTelefon.TabIndex = 19;
            this.lblGrunddatenTelefon.Text = "Telefon";
            this.lblGrunddatenTelefon.UseCompatibleTextRendering = true;
            // 
            // edtGrunddatenEmail
            // 
            this.edtGrunddatenEmail.DataMember = "Email";
            this.edtGrunddatenEmail.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenEmail.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenEmail.Location = new System.Drawing.Point(110, 184);
            this.edtGrunddatenEmail.Name = "edtGrunddatenEmail";
            this.edtGrunddatenEmail.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenEmail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenEmail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenEmail.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenEmail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenEmail.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrunddatenEmail.Properties.ReadOnly = true;
            this.edtGrunddatenEmail.Size = new System.Drawing.Size(288, 24);
            this.edtGrunddatenEmail.TabIndex = 18;
            // 
            // lblGrunddatenEmail
            // 
            this.lblGrunddatenEmail.Location = new System.Drawing.Point(3, 184);
            this.lblGrunddatenEmail.Name = "lblGrunddatenEmail";
            this.lblGrunddatenEmail.Size = new System.Drawing.Size(101, 24);
            this.lblGrunddatenEmail.TabIndex = 17;
            this.lblGrunddatenEmail.Text = "E-Mail";
            this.lblGrunddatenEmail.UseCompatibleTextRendering = true;
            // 
            // edtGrunddatenAdresseLand
            // 
            this.edtGrunddatenAdresseLand.DataMember = "BaLandID";
            this.edtGrunddatenAdresseLand.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenAdresseLand.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenAdresseLand.Location = new System.Drawing.Point(110, 154);
            this.edtGrunddatenAdresseLand.LOVName = "BaLand";
            this.edtGrunddatenAdresseLand.Name = "edtGrunddatenAdresseLand";
            this.edtGrunddatenAdresseLand.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenAdresseLand.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenAdresseLand.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenAdresseLand.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenAdresseLand.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenAdresseLand.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenAdresseLand.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGrunddatenAdresseLand.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenAdresseLand.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGrunddatenAdresseLand.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGrunddatenAdresseLand.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtGrunddatenAdresseLand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtGrunddatenAdresseLand.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrunddatenAdresseLand.Properties.NullText = "";
            this.edtGrunddatenAdresseLand.Properties.ReadOnly = true;
            this.edtGrunddatenAdresseLand.Properties.ShowFooter = false;
            this.edtGrunddatenAdresseLand.Properties.ShowHeader = false;
            this.edtGrunddatenAdresseLand.Size = new System.Drawing.Size(288, 24);
            this.edtGrunddatenAdresseLand.TabIndex = 16;
            // 
            // lblGrunddatenAdresseLand
            // 
            this.lblGrunddatenAdresseLand.Location = new System.Drawing.Point(3, 154);
            this.lblGrunddatenAdresseLand.Name = "lblGrunddatenAdresseLand";
            this.lblGrunddatenAdresseLand.Size = new System.Drawing.Size(101, 24);
            this.lblGrunddatenAdresseLand.TabIndex = 15;
            this.lblGrunddatenAdresseLand.Text = "Land";
            this.lblGrunddatenAdresseLand.UseCompatibleTextRendering = true;
            // 
            // edtGrunddatenAdresseBezirk
            // 
            this.edtGrunddatenAdresseBezirk.DataMember = "Bezirk";
            this.edtGrunddatenAdresseBezirk.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenAdresseBezirk.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenAdresseBezirk.Location = new System.Drawing.Point(110, 131);
            this.edtGrunddatenAdresseBezirk.Name = "edtGrunddatenAdresseBezirk";
            this.edtGrunddatenAdresseBezirk.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenAdresseBezirk.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenAdresseBezirk.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenAdresseBezirk.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenAdresseBezirk.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenAdresseBezirk.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenAdresseBezirk.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrunddatenAdresseBezirk.Properties.ReadOnly = true;
            this.edtGrunddatenAdresseBezirk.Size = new System.Drawing.Size(288, 24);
            this.edtGrunddatenAdresseBezirk.TabIndex = 14;
            this.edtGrunddatenAdresseBezirk.TabStop = false;
            // 
            // lblGrunddatenAdresseBezirk
            // 
            this.lblGrunddatenAdresseBezirk.Location = new System.Drawing.Point(3, 131);
            this.lblGrunddatenAdresseBezirk.Name = "lblGrunddatenAdresseBezirk";
            this.lblGrunddatenAdresseBezirk.Size = new System.Drawing.Size(101, 24);
            this.lblGrunddatenAdresseBezirk.TabIndex = 13;
            this.lblGrunddatenAdresseBezirk.Text = "Bezirk";
            this.lblGrunddatenAdresseBezirk.UseCompatibleTextRendering = true;
            // 
            // edtGrunddatenAdresseKt
            // 
            this.edtGrunddatenAdresseKt.DataMember = "Kanton";
            this.edtGrunddatenAdresseKt.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenAdresseKt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenAdresseKt.Location = new System.Drawing.Point(367, 108);
            this.edtGrunddatenAdresseKt.Name = "edtGrunddatenAdresseKt";
            this.edtGrunddatenAdresseKt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenAdresseKt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenAdresseKt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenAdresseKt.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenAdresseKt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenAdresseKt.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenAdresseKt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrunddatenAdresseKt.Properties.ReadOnly = true;
            this.edtGrunddatenAdresseKt.Size = new System.Drawing.Size(31, 24);
            this.edtGrunddatenAdresseKt.TabIndex = 12;
            this.edtGrunddatenAdresseKt.TabStop = false;
            // 
            // edtGrunddatenAdresseOrt
            // 
            this.edtGrunddatenAdresseOrt.DataMember = "Ort";
            this.edtGrunddatenAdresseOrt.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenAdresseOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenAdresseOrt.Location = new System.Drawing.Point(154, 108);
            this.edtGrunddatenAdresseOrt.Name = "edtGrunddatenAdresseOrt";
            this.edtGrunddatenAdresseOrt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenAdresseOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenAdresseOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenAdresseOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenAdresseOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenAdresseOrt.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenAdresseOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrunddatenAdresseOrt.Properties.MaxLength = 255;
            this.edtGrunddatenAdresseOrt.Properties.ReadOnly = true;
            this.edtGrunddatenAdresseOrt.Size = new System.Drawing.Size(214, 24);
            this.edtGrunddatenAdresseOrt.TabIndex = 11;
            // 
            // edtGrunddatenAdressePLZ
            // 
            this.edtGrunddatenAdressePLZ.DataMember = "PLZ";
            this.edtGrunddatenAdressePLZ.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenAdressePLZ.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenAdressePLZ.Location = new System.Drawing.Point(110, 108);
            this.edtGrunddatenAdressePLZ.Name = "edtGrunddatenAdressePLZ";
            this.edtGrunddatenAdressePLZ.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenAdressePLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenAdressePLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenAdressePLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenAdressePLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenAdressePLZ.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenAdressePLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrunddatenAdressePLZ.Properties.MaxLength = 255;
            this.edtGrunddatenAdressePLZ.Properties.ReadOnly = true;
            this.edtGrunddatenAdressePLZ.Size = new System.Drawing.Size(45, 24);
            this.edtGrunddatenAdressePLZ.TabIndex = 10;
            // 
            // lblGrunddatenAdressePLZOrtKt
            // 
            this.lblGrunddatenAdressePLZOrtKt.Location = new System.Drawing.Point(3, 108);
            this.lblGrunddatenAdressePLZOrtKt.Name = "lblGrunddatenAdressePLZOrtKt";
            this.lblGrunddatenAdressePLZOrtKt.Size = new System.Drawing.Size(101, 24);
            this.lblGrunddatenAdressePLZOrtKt.TabIndex = 9;
            this.lblGrunddatenAdressePLZOrtKt.Text = "PLZ / Ort / Kt.";
            this.lblGrunddatenAdressePLZOrtKt.UseCompatibleTextRendering = true;
            // 
            // edtGrunddatenAdressePostfach
            // 
            this.edtGrunddatenAdressePostfach.DataMember = "Postfach";
            this.edtGrunddatenAdressePostfach.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenAdressePostfach.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenAdressePostfach.Location = new System.Drawing.Point(110, 85);
            this.edtGrunddatenAdressePostfach.Name = "edtGrunddatenAdressePostfach";
            this.edtGrunddatenAdressePostfach.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenAdressePostfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenAdressePostfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenAdressePostfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenAdressePostfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenAdressePostfach.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenAdressePostfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrunddatenAdressePostfach.Properties.MaxLength = 255;
            this.edtGrunddatenAdressePostfach.Properties.ReadOnly = true;
            this.edtGrunddatenAdressePostfach.Size = new System.Drawing.Size(210, 24);
            this.edtGrunddatenAdressePostfach.TabIndex = 8;
            // 
            // lblGrunddatenAdressePostfach
            // 
            this.lblGrunddatenAdressePostfach.Location = new System.Drawing.Point(3, 85);
            this.lblGrunddatenAdressePostfach.Name = "lblGrunddatenAdressePostfach";
            this.lblGrunddatenAdressePostfach.Size = new System.Drawing.Size(101, 24);
            this.lblGrunddatenAdressePostfach.TabIndex = 7;
            this.lblGrunddatenAdressePostfach.Text = "Postfach";
            this.lblGrunddatenAdressePostfach.UseCompatibleTextRendering = true;
            // 
            // edtGrunddatenAdresseNr
            // 
            this.edtGrunddatenAdresseNr.DataMember = "HausNr";
            this.edtGrunddatenAdresseNr.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenAdresseNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenAdresseNr.Location = new System.Drawing.Point(349, 62);
            this.edtGrunddatenAdresseNr.Name = "edtGrunddatenAdresseNr";
            this.edtGrunddatenAdresseNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenAdresseNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenAdresseNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenAdresseNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenAdresseNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenAdresseNr.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenAdresseNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrunddatenAdresseNr.Properties.MaxLength = 255;
            this.edtGrunddatenAdresseNr.Properties.ReadOnly = true;
            this.edtGrunddatenAdresseNr.Size = new System.Drawing.Size(49, 24);
            this.edtGrunddatenAdresseNr.TabIndex = 6;
            // 
            // edtGrunddatenAdresseStrasse
            // 
            this.edtGrunddatenAdresseStrasse.DataMember = "Strasse";
            this.edtGrunddatenAdresseStrasse.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenAdresseStrasse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenAdresseStrasse.Location = new System.Drawing.Point(110, 62);
            this.edtGrunddatenAdresseStrasse.Name = "edtGrunddatenAdresseStrasse";
            this.edtGrunddatenAdresseStrasse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenAdresseStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenAdresseStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenAdresseStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenAdresseStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenAdresseStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenAdresseStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrunddatenAdresseStrasse.Properties.MaxLength = 255;
            this.edtGrunddatenAdresseStrasse.Properties.ReadOnly = true;
            this.edtGrunddatenAdresseStrasse.Size = new System.Drawing.Size(240, 24);
            this.edtGrunddatenAdresseStrasse.TabIndex = 5;
            // 
            // lblGrunddatenAdresseStrasseNr
            // 
            this.lblGrunddatenAdresseStrasseNr.Location = new System.Drawing.Point(3, 62);
            this.lblGrunddatenAdresseStrasseNr.Name = "lblGrunddatenAdresseStrasseNr";
            this.lblGrunddatenAdresseStrasseNr.Size = new System.Drawing.Size(101, 24);
            this.lblGrunddatenAdresseStrasseNr.TabIndex = 4;
            this.lblGrunddatenAdresseStrasseNr.Text = "Strasse / Nr.";
            this.lblGrunddatenAdresseStrasseNr.UseCompatibleTextRendering = true;
            // 
            // edtGrunddatenAdresseZusatz
            // 
            this.edtGrunddatenAdresseZusatz.DataMember = "Zusatz";
            this.edtGrunddatenAdresseZusatz.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenAdresseZusatz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrunddatenAdresseZusatz.Location = new System.Drawing.Point(110, 39);
            this.edtGrunddatenAdresseZusatz.Name = "edtGrunddatenAdresseZusatz";
            this.edtGrunddatenAdresseZusatz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGrunddatenAdresseZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenAdresseZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenAdresseZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenAdresseZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenAdresseZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenAdresseZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrunddatenAdresseZusatz.Properties.MaxLength = 255;
            this.edtGrunddatenAdresseZusatz.Properties.ReadOnly = true;
            this.edtGrunddatenAdresseZusatz.Size = new System.Drawing.Size(288, 24);
            this.edtGrunddatenAdresseZusatz.TabIndex = 3;
            // 
            // lblGrunddatenAdresseZusatz
            // 
            this.lblGrunddatenAdresseZusatz.Location = new System.Drawing.Point(3, 39);
            this.lblGrunddatenAdresseZusatz.Name = "lblGrunddatenAdresseZusatz";
            this.lblGrunddatenAdresseZusatz.Size = new System.Drawing.Size(101, 24);
            this.lblGrunddatenAdresseZusatz.TabIndex = 2;
            this.lblGrunddatenAdresseZusatz.Text = "Zusatz";
            this.lblGrunddatenAdresseZusatz.UseCompatibleTextRendering = true;
            // 
            // edtGrunddatenName
            // 
            this.edtGrunddatenName.DataMember = "NameVorname";
            this.edtGrunddatenName.DataSource = this.qryEdMitarbeiter;
            this.edtGrunddatenName.Location = new System.Drawing.Point(110, 9);
            this.edtGrunddatenName.Name = "edtGrunddatenName";
            this.edtGrunddatenName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGrunddatenName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrunddatenName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrunddatenName.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrunddatenName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrunddatenName.Properties.Appearance.Options.UseFont = true;
            this.edtGrunddatenName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtGrunddatenName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtGrunddatenName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrunddatenName.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtGrunddatenName.Size = new System.Drawing.Size(288, 24);
            this.edtGrunddatenName.TabIndex = 1;
            this.edtGrunddatenName.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtGrunddatenName_UserModifiedFld);
            this.edtGrunddatenName.EditValueChanged += new System.EventHandler(this.edtGrunddatenName_EditValueChanged);
            // 
            // lblGrunddatenName
            // 
            this.lblGrunddatenName.Location = new System.Drawing.Point(3, 9);
            this.lblGrunddatenName.Name = "lblGrunddatenName";
            this.lblGrunddatenName.Size = new System.Drawing.Size(101, 24);
            this.lblGrunddatenName.TabIndex = 0;
            this.lblGrunddatenName.Text = "Name";
            this.lblGrunddatenName.UseCompatibleTextRendering = true;
            // 
            // tpgZusatzdaten
            // 
            this.tpgZusatzdaten.Controls.Add(this.grpGrunddatenAusbildungTaetigkeit);
            this.tpgZusatzdaten.Controls.Add(this.edtZusatzdatenStrafregisterauszugBemerkungen);
            this.tpgZusatzdaten.Controls.Add(this.lblZusatzdatenStrafregisterauszugBemerkungen);
            this.tpgZusatzdaten.Controls.Add(this.edtZusatzdatenStrafregisterauszug);
            this.tpgZusatzdaten.Controls.Add(this.lblZusatzdatenStrafregisterauszug);
            this.tpgZusatzdaten.Controls.Add(this.chkTabStopBug);
            this.tpgZusatzdaten.Controls.Add(this.edtZusatzdatenAufenthaltsbewilligung);
            this.tpgZusatzdaten.Controls.Add(this.lblZusatzdatenAufenthaltsbewilligung);
            this.tpgZusatzdaten.Controls.Add(this.edtZusatzdatenNationalitaet);
            this.tpgZusatzdaten.Controls.Add(this.lblZusatzdatenNationalitaet);
            this.tpgZusatzdaten.Controls.Add(this.edtZusatzdatenWeitereSprachen);
            this.tpgZusatzdaten.Controls.Add(this.lblZusatzdatenWeitereSprachen);
            this.tpgZusatzdaten.Controls.Add(this.edtZusatzdatenSprache);
            this.tpgZusatzdaten.Controls.Add(this.lblZusatzdatenSprache);
            this.tpgZusatzdaten.Controls.Add(this.edtZusatzdatenAnzahlKinder);
            this.tpgZusatzdaten.Controls.Add(this.lblZusatzdatenAnzahlKinder);
            this.tpgZusatzdaten.Controls.Add(this.edtZusatzdatenZivilstand);
            this.tpgZusatzdaten.Controls.Add(this.lblZusatzdatenZivilstand);
            this.tpgZusatzdaten.Location = new System.Drawing.Point(6, 6);
            this.tpgZusatzdaten.Name = "tpgZusatzdaten";
            this.tpgZusatzdaten.Size = new System.Drawing.Size(976, 342);
            this.tpgZusatzdaten.TabIndex = 1;
            this.tpgZusatzdaten.Title = "Zusatzdaten";
            // 
            // grpGrunddatenAusbildungTaetigkeit
            // 
            this.grpGrunddatenAusbildungTaetigkeit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGrunddatenAusbildungTaetigkeit.Controls.Add(this.edtZusatzdatenlTaetigkeit);
            this.grpGrunddatenAusbildungTaetigkeit.Controls.Add(this.lbZusatzdatenlTaetigkeit);
            this.grpGrunddatenAusbildungTaetigkeit.Controls.Add(this.edtZusatzdatenAusbildung);
            this.grpGrunddatenAusbildungTaetigkeit.Controls.Add(this.lblZusatzdatenAusbildung);
            this.grpGrunddatenAusbildungTaetigkeit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grpGrunddatenAusbildungTaetigkeit.Location = new System.Drawing.Point(9, 159);
            this.grpGrunddatenAusbildungTaetigkeit.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.grpGrunddatenAusbildungTaetigkeit.Name = "grpGrunddatenAusbildungTaetigkeit";
            this.grpGrunddatenAusbildungTaetigkeit.Size = new System.Drawing.Size(960, 134);
            this.grpGrunddatenAusbildungTaetigkeit.TabIndex = 16;
            this.grpGrunddatenAusbildungTaetigkeit.TabStop = false;
            this.grpGrunddatenAusbildungTaetigkeit.Text = "Ausbildung, Tätigkeit";
            this.grpGrunddatenAusbildungTaetigkeit.UseCompatibleTextRendering = true;
            // 
            // edtZusatzdatenlTaetigkeit
            // 
            this.edtZusatzdatenlTaetigkeit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtZusatzdatenlTaetigkeit.DataMember = "ZusatzTaetigkeit";
            this.edtZusatzdatenlTaetigkeit.DataSource = this.qryEdMitarbeiter;
            this.edtZusatzdatenlTaetigkeit.Location = new System.Drawing.Point(130, 73);
            this.edtZusatzdatenlTaetigkeit.Name = "edtZusatzdatenlTaetigkeit";
            this.edtZusatzdatenlTaetigkeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatzdatenlTaetigkeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzdatenlTaetigkeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzdatenlTaetigkeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzdatenlTaetigkeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzdatenlTaetigkeit.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzdatenlTaetigkeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZusatzdatenlTaetigkeit.Properties.MaxLength = 5000;
            this.edtZusatzdatenlTaetigkeit.Size = new System.Drawing.Size(826, 50);
            this.edtZusatzdatenlTaetigkeit.TabIndex = 3;
            // 
            // lbZusatzdatenlTaetigkeit
            // 
            this.lbZusatzdatenlTaetigkeit.Location = new System.Drawing.Point(6, 73);
            this.lbZusatzdatenlTaetigkeit.Name = "lbZusatzdatenlTaetigkeit";
            this.lbZusatzdatenlTaetigkeit.Size = new System.Drawing.Size(118, 24);
            this.lbZusatzdatenlTaetigkeit.TabIndex = 2;
            this.lbZusatzdatenlTaetigkeit.Text = "Tätigkeit";
            this.lbZusatzdatenlTaetigkeit.UseCompatibleTextRendering = true;
            // 
            // edtZusatzdatenAusbildung
            // 
            this.edtZusatzdatenAusbildung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtZusatzdatenAusbildung.DataMember = "ZusatzAusbildung";
            this.edtZusatzdatenAusbildung.DataSource = this.qryEdMitarbeiter;
            this.edtZusatzdatenAusbildung.Location = new System.Drawing.Point(130, 17);
            this.edtZusatzdatenAusbildung.Name = "edtZusatzdatenAusbildung";
            this.edtZusatzdatenAusbildung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatzdatenAusbildung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzdatenAusbildung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzdatenAusbildung.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzdatenAusbildung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzdatenAusbildung.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzdatenAusbildung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZusatzdatenAusbildung.Properties.MaxLength = 5000;
            this.edtZusatzdatenAusbildung.Size = new System.Drawing.Size(826, 50);
            this.edtZusatzdatenAusbildung.TabIndex = 1;
            // 
            // lblZusatzdatenAusbildung
            // 
            this.lblZusatzdatenAusbildung.Location = new System.Drawing.Point(6, 17);
            this.lblZusatzdatenAusbildung.Name = "lblZusatzdatenAusbildung";
            this.lblZusatzdatenAusbildung.Size = new System.Drawing.Size(118, 24);
            this.lblZusatzdatenAusbildung.TabIndex = 0;
            this.lblZusatzdatenAusbildung.Text = "Ausbildung";
            this.lblZusatzdatenAusbildung.UseCompatibleTextRendering = true;
            // 
            // edtZusatzdatenStrafregisterauszugBemerkungen
            // 
            this.edtZusatzdatenStrafregisterauszugBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtZusatzdatenStrafregisterauszugBemerkungen.DataMember = "ZusatzStrafregisterauszugBemerkungen";
            this.edtZusatzdatenStrafregisterauszugBemerkungen.DataSource = this.qryEdMitarbeiter;
            this.edtZusatzdatenStrafregisterauszugBemerkungen.Location = new System.Drawing.Point(379, 129);
            this.edtZusatzdatenStrafregisterauszugBemerkungen.Name = "edtZusatzdatenStrafregisterauszugBemerkungen";
            this.edtZusatzdatenStrafregisterauszugBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatzdatenStrafregisterauszugBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzdatenStrafregisterauszugBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzdatenStrafregisterauszugBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzdatenStrafregisterauszugBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzdatenStrafregisterauszugBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzdatenStrafregisterauszugBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZusatzdatenStrafregisterauszugBemerkungen.Properties.MaxLength = 255;
            this.edtZusatzdatenStrafregisterauszugBemerkungen.Size = new System.Drawing.Size(590, 24);
            this.edtZusatzdatenStrafregisterauszugBemerkungen.TabIndex = 15;
            // 
            // lblZusatzdatenStrafregisterauszugBemerkungen
            // 
            this.lblZusatzdatenStrafregisterauszugBemerkungen.Location = new System.Drawing.Point(258, 129);
            this.lblZusatzdatenStrafregisterauszugBemerkungen.Name = "lblZusatzdatenStrafregisterauszugBemerkungen";
            this.lblZusatzdatenStrafregisterauszugBemerkungen.Size = new System.Drawing.Size(115, 24);
            this.lblZusatzdatenStrafregisterauszugBemerkungen.TabIndex = 14;
            this.lblZusatzdatenStrafregisterauszugBemerkungen.Text = "Bem. Strafregister";
            this.lblZusatzdatenStrafregisterauszugBemerkungen.UseCompatibleTextRendering = true;
            // 
            // edtZusatzdatenStrafregisterauszug
            // 
            this.edtZusatzdatenStrafregisterauszug.DataMember = "ZusatzStrafregisterauszugDatum";
            this.edtZusatzdatenStrafregisterauszug.DataSource = this.qryEdMitarbeiter;
            this.edtZusatzdatenStrafregisterauszug.EditValue = null;
            this.edtZusatzdatenStrafregisterauszug.Location = new System.Drawing.Point(139, 129);
            this.edtZusatzdatenStrafregisterauszug.Name = "edtZusatzdatenStrafregisterauszug";
            this.edtZusatzdatenStrafregisterauszug.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZusatzdatenStrafregisterauszug.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatzdatenStrafregisterauszug.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzdatenStrafregisterauszug.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzdatenStrafregisterauszug.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzdatenStrafregisterauszug.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzdatenStrafregisterauszug.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzdatenStrafregisterauszug.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtZusatzdatenStrafregisterauszug.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZusatzdatenStrafregisterauszug.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtZusatzdatenStrafregisterauszug.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZusatzdatenStrafregisterauszug.Properties.ShowToday = false;
            this.edtZusatzdatenStrafregisterauszug.Size = new System.Drawing.Size(100, 24);
            this.edtZusatzdatenStrafregisterauszug.TabIndex = 13;
            // 
            // lblZusatzdatenStrafregisterauszug
            // 
            this.lblZusatzdatenStrafregisterauszug.Location = new System.Drawing.Point(9, 129);
            this.lblZusatzdatenStrafregisterauszug.Name = "lblZusatzdatenStrafregisterauszug";
            this.lblZusatzdatenStrafregisterauszug.Size = new System.Drawing.Size(124, 24);
            this.lblZusatzdatenStrafregisterauszug.TabIndex = 12;
            this.lblZusatzdatenStrafregisterauszug.Text = "Strafregisterauszug";
            this.lblZusatzdatenStrafregisterauszug.UseCompatibleTextRendering = true;
            // 
            // chkTabStopBug
            // 
            this.chkTabStopBug.EditValue = false;
            this.chkTabStopBug.Location = new System.Drawing.Point(401, 102);
            this.chkTabStopBug.Name = "chkTabStopBug";
            this.chkTabStopBug.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkTabStopBug.Properties.Appearance.Options.UseBackColor = true;
            this.chkTabStopBug.Properties.Caption = "TabStopBug";
            this.chkTabStopBug.Size = new System.Drawing.Size(24, 19);
            this.chkTabStopBug.TabIndex = 12;
            this.chkTabStopBug.Visible = false;
            // 
            // edtZusatzdatenAufenthaltsbewilligung
            // 
            this.edtZusatzdatenAufenthaltsbewilligung.DataMember = "ZusatzAufenthaltsbewilligungCode";
            this.edtZusatzdatenAufenthaltsbewilligung.DataSource = this.qryEdMitarbeiter;
            this.edtZusatzdatenAufenthaltsbewilligung.Location = new System.Drawing.Point(139, 99);
            this.edtZusatzdatenAufenthaltsbewilligung.LOVName = "BaAuslaenderAufenthaltStatus";
            this.edtZusatzdatenAufenthaltsbewilligung.Name = "edtZusatzdatenAufenthaltsbewilligung";
            this.edtZusatzdatenAufenthaltsbewilligung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatzdatenAufenthaltsbewilligung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzdatenAufenthaltsbewilligung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzdatenAufenthaltsbewilligung.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzdatenAufenthaltsbewilligung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzdatenAufenthaltsbewilligung.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzdatenAufenthaltsbewilligung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZusatzdatenAufenthaltsbewilligung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzdatenAufenthaltsbewilligung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZusatzdatenAufenthaltsbewilligung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZusatzdatenAufenthaltsbewilligung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtZusatzdatenAufenthaltsbewilligung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtZusatzdatenAufenthaltsbewilligung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZusatzdatenAufenthaltsbewilligung.Properties.NullText = "";
            this.edtZusatzdatenAufenthaltsbewilligung.Properties.ShowFooter = false;
            this.edtZusatzdatenAufenthaltsbewilligung.Properties.ShowHeader = false;
            this.edtZusatzdatenAufenthaltsbewilligung.Size = new System.Drawing.Size(256, 24);
            this.edtZusatzdatenAufenthaltsbewilligung.TabIndex = 11;
            // 
            // lblZusatzdatenAufenthaltsbewilligung
            // 
            this.lblZusatzdatenAufenthaltsbewilligung.Location = new System.Drawing.Point(9, 98);
            this.lblZusatzdatenAufenthaltsbewilligung.Name = "lblZusatzdatenAufenthaltsbewilligung";
            this.lblZusatzdatenAufenthaltsbewilligung.Size = new System.Drawing.Size(124, 24);
            this.lblZusatzdatenAufenthaltsbewilligung.TabIndex = 10;
            this.lblZusatzdatenAufenthaltsbewilligung.Text = "Aufenthaltsbewilligung";
            this.lblZusatzdatenAufenthaltsbewilligung.UseCompatibleTextRendering = true;
            // 
            // edtZusatzdatenNationalitaet
            // 
            this.edtZusatzdatenNationalitaet.DataMember = "ZusatzNationalitaetLandCode";
            this.edtZusatzdatenNationalitaet.DataSource = this.qryEdMitarbeiter;
            this.edtZusatzdatenNationalitaet.Location = new System.Drawing.Point(139, 69);
            this.edtZusatzdatenNationalitaet.Name = "edtZusatzdatenNationalitaet";
            this.edtZusatzdatenNationalitaet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatzdatenNationalitaet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzdatenNationalitaet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzdatenNationalitaet.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzdatenNationalitaet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzdatenNationalitaet.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzdatenNationalitaet.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZusatzdatenNationalitaet.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzdatenNationalitaet.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZusatzdatenNationalitaet.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZusatzdatenNationalitaet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtZusatzdatenNationalitaet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtZusatzdatenNationalitaet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZusatzdatenNationalitaet.Properties.NullText = "";
            this.edtZusatzdatenNationalitaet.Properties.ShowFooter = false;
            this.edtZusatzdatenNationalitaet.Properties.ShowHeader = false;
            this.edtZusatzdatenNationalitaet.Size = new System.Drawing.Size(256, 24);
            this.edtZusatzdatenNationalitaet.TabIndex = 9;
            // 
            // lblZusatzdatenNationalitaet
            // 
            this.lblZusatzdatenNationalitaet.Location = new System.Drawing.Point(9, 68);
            this.lblZusatzdatenNationalitaet.Name = "lblZusatzdatenNationalitaet";
            this.lblZusatzdatenNationalitaet.Size = new System.Drawing.Size(124, 24);
            this.lblZusatzdatenNationalitaet.TabIndex = 8;
            this.lblZusatzdatenNationalitaet.Text = "Nationalität";
            this.lblZusatzdatenNationalitaet.UseCompatibleTextRendering = true;
            // 
            // edtZusatzdatenWeitereSprachen
            // 
            this.edtZusatzdatenWeitereSprachen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtZusatzdatenWeitereSprachen.DataMember = "ZusatzWeitereSprachen";
            this.edtZusatzdatenWeitereSprachen.DataSource = this.qryEdMitarbeiter;
            this.edtZusatzdatenWeitereSprachen.Location = new System.Drawing.Point(522, 37);
            this.edtZusatzdatenWeitereSprachen.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtZusatzdatenWeitereSprachen.Name = "edtZusatzdatenWeitereSprachen";
            this.edtZusatzdatenWeitereSprachen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatzdatenWeitereSprachen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzdatenWeitereSprachen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzdatenWeitereSprachen.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzdatenWeitereSprachen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzdatenWeitereSprachen.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzdatenWeitereSprachen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZusatzdatenWeitereSprachen.Properties.MaxLength = 255;
            this.edtZusatzdatenWeitereSprachen.Size = new System.Drawing.Size(447, 24);
            this.edtZusatzdatenWeitereSprachen.TabIndex = 7;
            // 
            // lblZusatzdatenWeitereSprachen
            // 
            this.lblZusatzdatenWeitereSprachen.Location = new System.Drawing.Point(416, 38);
            this.lblZusatzdatenWeitereSprachen.Name = "lblZusatzdatenWeitereSprachen";
            this.lblZusatzdatenWeitereSprachen.Size = new System.Drawing.Size(100, 23);
            this.lblZusatzdatenWeitereSprachen.TabIndex = 6;
            this.lblZusatzdatenWeitereSprachen.Text = "Weitere Sprachen";
            this.lblZusatzdatenWeitereSprachen.UseCompatibleTextRendering = true;
            // 
            // edtZusatzdatenSprache
            // 
            this.edtZusatzdatenSprache.DataMember = "LanguageCode";
            this.edtZusatzdatenSprache.DataSource = this.qryEdMitarbeiter;
            this.edtZusatzdatenSprache.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZusatzdatenSprache.Location = new System.Drawing.Point(139, 39);
            this.edtZusatzdatenSprache.LOVName = "Sprache";
            this.edtZusatzdatenSprache.Name = "edtZusatzdatenSprache";
            this.edtZusatzdatenSprache.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZusatzdatenSprache.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzdatenSprache.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzdatenSprache.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzdatenSprache.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzdatenSprache.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzdatenSprache.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZusatzdatenSprache.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzdatenSprache.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZusatzdatenSprache.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZusatzdatenSprache.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtZusatzdatenSprache.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtZusatzdatenSprache.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZusatzdatenSprache.Properties.NullText = "";
            this.edtZusatzdatenSprache.Properties.ReadOnly = true;
            this.edtZusatzdatenSprache.Properties.ShowFooter = false;
            this.edtZusatzdatenSprache.Properties.ShowHeader = false;
            this.edtZusatzdatenSprache.Size = new System.Drawing.Size(256, 24);
            this.edtZusatzdatenSprache.TabIndex = 5;
            // 
            // lblZusatzdatenSprache
            // 
            this.lblZusatzdatenSprache.Location = new System.Drawing.Point(9, 38);
            this.lblZusatzdatenSprache.Name = "lblZusatzdatenSprache";
            this.lblZusatzdatenSprache.Size = new System.Drawing.Size(124, 24);
            this.lblZusatzdatenSprache.TabIndex = 4;
            this.lblZusatzdatenSprache.Text = "Sprache";
            this.lblZusatzdatenSprache.UseCompatibleTextRendering = true;
            // 
            // edtZusatzdatenAnzahlKinder
            // 
            this.edtZusatzdatenAnzahlKinder.DataMember = "ZusatzAnzahlKinder";
            this.edtZusatzdatenAnzahlKinder.DataSource = this.qryEdMitarbeiter;
            this.edtZusatzdatenAnzahlKinder.Location = new System.Drawing.Point(522, 7);
            this.edtZusatzdatenAnzahlKinder.Name = "edtZusatzdatenAnzahlKinder";
            this.edtZusatzdatenAnzahlKinder.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZusatzdatenAnzahlKinder.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatzdatenAnzahlKinder.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzdatenAnzahlKinder.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzdatenAnzahlKinder.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzdatenAnzahlKinder.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzdatenAnzahlKinder.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzdatenAnzahlKinder.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZusatzdatenAnzahlKinder.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZusatzdatenAnzahlKinder.Properties.MaxLength = 2;
            this.edtZusatzdatenAnzahlKinder.Size = new System.Drawing.Size(65, 24);
            this.edtZusatzdatenAnzahlKinder.TabIndex = 3;
            // 
            // lblZusatzdatenAnzahlKinder
            // 
            this.lblZusatzdatenAnzahlKinder.Location = new System.Drawing.Point(416, 9);
            this.lblZusatzdatenAnzahlKinder.Name = "lblZusatzdatenAnzahlKinder";
            this.lblZusatzdatenAnzahlKinder.Size = new System.Drawing.Size(100, 24);
            this.lblZusatzdatenAnzahlKinder.TabIndex = 2;
            this.lblZusatzdatenAnzahlKinder.Text = "Anzahl Kinder";
            this.lblZusatzdatenAnzahlKinder.UseCompatibleTextRendering = true;
            // 
            // edtZusatzdatenZivilstand
            // 
            this.edtZusatzdatenZivilstand.DataMember = "ZusatzZivilstandCode";
            this.edtZusatzdatenZivilstand.DataSource = this.qryEdMitarbeiter;
            this.edtZusatzdatenZivilstand.Location = new System.Drawing.Point(139, 9);
            this.edtZusatzdatenZivilstand.LOVName = "Zivilstand";
            this.edtZusatzdatenZivilstand.Name = "edtZusatzdatenZivilstand";
            this.edtZusatzdatenZivilstand.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatzdatenZivilstand.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzdatenZivilstand.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzdatenZivilstand.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzdatenZivilstand.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzdatenZivilstand.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzdatenZivilstand.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZusatzdatenZivilstand.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzdatenZivilstand.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZusatzdatenZivilstand.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZusatzdatenZivilstand.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtZusatzdatenZivilstand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtZusatzdatenZivilstand.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZusatzdatenZivilstand.Properties.NullText = "";
            this.edtZusatzdatenZivilstand.Properties.ShowFooter = false;
            this.edtZusatzdatenZivilstand.Properties.ShowHeader = false;
            this.edtZusatzdatenZivilstand.Size = new System.Drawing.Size(256, 24);
            this.edtZusatzdatenZivilstand.TabIndex = 1;
            // 
            // lblZusatzdatenZivilstand
            // 
            this.lblZusatzdatenZivilstand.Location = new System.Drawing.Point(9, 9);
            this.lblZusatzdatenZivilstand.Name = "lblZusatzdatenZivilstand";
            this.lblZusatzdatenZivilstand.Size = new System.Drawing.Size(124, 24);
            this.lblZusatzdatenZivilstand.TabIndex = 0;
            this.lblZusatzdatenZivilstand.Text = "Zivilstand";
            this.lblZusatzdatenZivilstand.UseCompatibleTextRendering = true;
            // 
            // tpgInterview
            // 
            this.tpgInterview.Controls.Add(this.edtInterviewBeurteilung);
            this.tpgInterview.Controls.Add(this.lblInterviewBeurteilung);
            this.tpgInterview.Controls.Add(this.edtInterviewZusammenfassung);
            this.tpgInterview.Controls.Add(this.lblInterviewZusammenfassung);
            this.tpgInterview.Controls.Add(this.edtInterviewInterviewer);
            this.tpgInterview.Controls.Add(this.lblInterviewInterviewer);
            this.tpgInterview.Controls.Add(this.edtInterviewDatum);
            this.tpgInterview.Controls.Add(this.lblInterviewDatum);
            this.tpgInterview.Location = new System.Drawing.Point(6, 6);
            this.tpgInterview.Name = "tpgInterview";
            this.tpgInterview.Size = new System.Drawing.Size(976, 342);
            this.tpgInterview.TabIndex = 2;
            this.tpgInterview.Title = "Interview";
            // 
            // edtInterviewBeurteilung
            // 
            this.edtInterviewBeurteilung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtInterviewBeurteilung.DataMember = "InterviewBeurteilung";
            this.edtInterviewBeurteilung.DataSource = this.qryEdMitarbeiter;
            this.edtInterviewBeurteilung.Location = new System.Drawing.Point(127, 183);
            this.edtInterviewBeurteilung.Name = "edtInterviewBeurteilung";
            this.edtInterviewBeurteilung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInterviewBeurteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInterviewBeurteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInterviewBeurteilung.Properties.Appearance.Options.UseBackColor = true;
            this.edtInterviewBeurteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInterviewBeurteilung.Properties.Appearance.Options.UseFont = true;
            this.edtInterviewBeurteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtInterviewBeurteilung.Properties.MaxLength = 5000;
            this.edtInterviewBeurteilung.Size = new System.Drawing.Size(842, 108);
            this.edtInterviewBeurteilung.TabIndex = 7;
            // 
            // lblInterviewBeurteilung
            // 
            this.lblInterviewBeurteilung.Location = new System.Drawing.Point(9, 183);
            this.lblInterviewBeurteilung.Name = "lblInterviewBeurteilung";
            this.lblInterviewBeurteilung.Size = new System.Drawing.Size(112, 24);
            this.lblInterviewBeurteilung.TabIndex = 6;
            this.lblInterviewBeurteilung.Text = "Beurteilung";
            this.lblInterviewBeurteilung.UseCompatibleTextRendering = true;
            // 
            // edtInterviewZusammenfassung
            // 
            this.edtInterviewZusammenfassung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtInterviewZusammenfassung.DataMember = "InterviewZusammenfassung";
            this.edtInterviewZusammenfassung.DataSource = this.qryEdMitarbeiter;
            this.edtInterviewZusammenfassung.Location = new System.Drawing.Point(127, 69);
            this.edtInterviewZusammenfassung.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtInterviewZusammenfassung.Name = "edtInterviewZusammenfassung";
            this.edtInterviewZusammenfassung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInterviewZusammenfassung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInterviewZusammenfassung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInterviewZusammenfassung.Properties.Appearance.Options.UseBackColor = true;
            this.edtInterviewZusammenfassung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInterviewZusammenfassung.Properties.Appearance.Options.UseFont = true;
            this.edtInterviewZusammenfassung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtInterviewZusammenfassung.Properties.MaxLength = 5000;
            this.edtInterviewZusammenfassung.Size = new System.Drawing.Size(842, 108);
            this.edtInterviewZusammenfassung.TabIndex = 5;
            // 
            // lblInterviewZusammenfassung
            // 
            this.lblInterviewZusammenfassung.Location = new System.Drawing.Point(9, 69);
            this.lblInterviewZusammenfassung.Name = "lblInterviewZusammenfassung";
            this.lblInterviewZusammenfassung.Size = new System.Drawing.Size(112, 24);
            this.lblInterviewZusammenfassung.TabIndex = 4;
            this.lblInterviewZusammenfassung.Text = "Zusammenfassung";
            this.lblInterviewZusammenfassung.UseCompatibleTextRendering = true;
            // 
            // edtInterviewInterviewer
            // 
            this.edtInterviewInterviewer.DataMember = "NameVornameInterviewer";
            this.edtInterviewInterviewer.DataSource = this.qryEdMitarbeiter;
            this.edtInterviewInterviewer.Location = new System.Drawing.Point(127, 39);
            this.edtInterviewInterviewer.Name = "edtInterviewInterviewer";
            this.edtInterviewInterviewer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInterviewInterviewer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInterviewInterviewer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInterviewInterviewer.Properties.Appearance.Options.UseBackColor = true;
            this.edtInterviewInterviewer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInterviewInterviewer.Properties.Appearance.Options.UseFont = true;
            this.edtInterviewInterviewer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtInterviewInterviewer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtInterviewInterviewer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInterviewInterviewer.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtInterviewInterviewer.Size = new System.Drawing.Size(275, 24);
            this.edtInterviewInterviewer.TabIndex = 3;
            this.edtInterviewInterviewer.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtInterviewInterviewer_UserModifiedFld);
            this.edtInterviewInterviewer.EditValueChanged += new System.EventHandler(this.edtInterviewInterviewer_EditValueChanged);
            // 
            // lblInterviewInterviewer
            // 
            this.lblInterviewInterviewer.Location = new System.Drawing.Point(9, 39);
            this.lblInterviewInterviewer.Name = "lblInterviewInterviewer";
            this.lblInterviewInterviewer.Size = new System.Drawing.Size(112, 24);
            this.lblInterviewInterviewer.TabIndex = 2;
            this.lblInterviewInterviewer.Text = "Interviewer";
            this.lblInterviewInterviewer.UseCompatibleTextRendering = true;
            // 
            // edtInterviewDatum
            // 
            this.edtInterviewDatum.DataMember = "InterviewDatum";
            this.edtInterviewDatum.DataSource = this.qryEdMitarbeiter;
            this.edtInterviewDatum.EditValue = null;
            this.edtInterviewDatum.Location = new System.Drawing.Point(127, 9);
            this.edtInterviewDatum.Name = "edtInterviewDatum";
            this.edtInterviewDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtInterviewDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInterviewDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInterviewDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInterviewDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtInterviewDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInterviewDatum.Properties.Appearance.Options.UseFont = true;
            this.edtInterviewDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtInterviewDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtInterviewDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtInterviewDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInterviewDatum.Properties.ShowToday = false;
            this.edtInterviewDatum.Size = new System.Drawing.Size(100, 24);
            this.edtInterviewDatum.TabIndex = 1;
            // 
            // lblInterviewDatum
            // 
            this.lblInterviewDatum.Location = new System.Drawing.Point(9, 9);
            this.lblInterviewDatum.Name = "lblInterviewDatum";
            this.lblInterviewDatum.Size = new System.Drawing.Size(112, 24);
            this.lblInterviewDatum.TabIndex = 0;
            this.lblInterviewDatum.Text = "Datum";
            this.lblInterviewDatum.UseCompatibleTextRendering = true;
            // 
            // tpgWeiterbildung
            // 
            this.tpgWeiterbildung.Controls.Add(this.grdKurs);
            this.tpgWeiterbildung.Controls.Add(this.panWeiterbildungDetails);
            this.tpgWeiterbildung.Location = new System.Drawing.Point(6, 6);
            this.tpgWeiterbildung.Name = "tpgWeiterbildung";
            this.tpgWeiterbildung.Size = new System.Drawing.Size(976, 342);
            this.tpgWeiterbildung.TabIndex = 3;
            this.tpgWeiterbildung.Title = "Weiterbildung";
            // 
            // grdKurs
            // 
            this.grdKurs.DataSource = this.qryEdMitarbeiterKurs;
            this.grdKurs.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdKurs.EmbeddedNavigator.Name = "";
            this.grdKurs.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKurs.Location = new System.Drawing.Point(0, 0);
            this.grdKurs.MainView = this.grvKurs;
            this.grdKurs.Name = "grdKurs";
            this.grdKurs.Size = new System.Drawing.Size(976, 187);
            this.grdKurs.TabIndex = 0;
            this.grdKurs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKurs});
            // 
            // qryEdMitarbeiterKurs
            // 
            this.qryEdMitarbeiterKurs.HostControl = this;
            this.qryEdMitarbeiterKurs.SelectStatement = resources.GetString("qryEdMitarbeiterKurs.SelectStatement");
            this.qryEdMitarbeiterKurs.TableName = "EdMitarbeiter_Kurs";
            this.qryEdMitarbeiterKurs.AfterInsert += new System.EventHandler(this.qryEdMitarbeiterKurs_AfterInsert);
            this.qryEdMitarbeiterKurs.AfterPost += new System.EventHandler(this.qryEdMitarbeiterKurs_AfterPost);
            this.qryEdMitarbeiterKurs.BeforePost += new System.EventHandler(this.qryEdMitarbeiterKurs_BeforePost);
            this.qryEdMitarbeiterKurs.PostCompleted += new System.EventHandler(this.qryEdMitarbeiterKurs_PostCompleted);
            // 
            // grvKurs
            // 
            this.grvKurs.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKurs.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKurs.Appearance.Empty.Options.UseBackColor = true;
            this.grvKurs.Appearance.Empty.Options.UseFont = true;
            this.grvKurs.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKurs.Appearance.EvenRow.Options.UseFont = true;
            this.grvKurs.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKurs.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKurs.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKurs.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKurs.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKurs.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKurs.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKurs.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKurs.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKurs.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKurs.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKurs.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKurs.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKurs.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKurs.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKurs.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKurs.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKurs.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKurs.Appearance.GroupRow.Options.UseFont = true;
            this.grvKurs.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKurs.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKurs.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKurs.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKurs.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKurs.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKurs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKurs.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKurs.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKurs.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKurs.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKurs.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKurs.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKurs.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKurs.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKurs.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKurs.Appearance.OddRow.Options.UseFont = true;
            this.grvKurs.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKurs.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKurs.Appearance.Row.Options.UseBackColor = true;
            this.grvKurs.Appearance.Row.Options.UseFont = true;
            this.grvKurs.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKurs.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKurs.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKurs.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKurs.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKurs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWeiterbildungKurs,
            this.colWeiterbildungFrist,
            this.colWeiterbildungAbsolviert,
            this.colWeiterbildungDispensiert,
            this.colWeiterbildungBemerkungen});
            this.grvKurs.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKurs.GridControl = this.grdKurs;
            this.grvKurs.Name = "grvKurs";
            this.grvKurs.OptionsBehavior.Editable = false;
            this.grvKurs.OptionsCustomization.AllowFilter = false;
            this.grvKurs.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKurs.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKurs.OptionsNavigation.UseTabKey = false;
            this.grvKurs.OptionsView.ColumnAutoWidth = false;
            this.grvKurs.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKurs.OptionsView.ShowGroupPanel = false;
            this.grvKurs.OptionsView.ShowIndicator = false;
            // 
            // colWeiterbildungKurs
            // 
            this.colWeiterbildungKurs.Caption = "Kurs";
            this.colWeiterbildungKurs.FieldName = "MLBezeichnung";
            this.colWeiterbildungKurs.Name = "colWeiterbildungKurs";
            this.colWeiterbildungKurs.Visible = true;
            this.colWeiterbildungKurs.VisibleIndex = 0;
            this.colWeiterbildungKurs.Width = 220;
            // 
            // colWeiterbildungFrist
            // 
            this.colWeiterbildungFrist.Caption = "Frist";
            this.colWeiterbildungFrist.FieldName = "ZuAbsolvierenBis";
            this.colWeiterbildungFrist.Name = "colWeiterbildungFrist";
            this.colWeiterbildungFrist.Visible = true;
            this.colWeiterbildungFrist.VisibleIndex = 1;
            this.colWeiterbildungFrist.Width = 100;
            // 
            // colWeiterbildungAbsolviert
            // 
            this.colWeiterbildungAbsolviert.Caption = "Absolviert";
            this.colWeiterbildungAbsolviert.FieldName = "AbsolviertAm";
            this.colWeiterbildungAbsolviert.Name = "colWeiterbildungAbsolviert";
            this.colWeiterbildungAbsolviert.Visible = true;
            this.colWeiterbildungAbsolviert.VisibleIndex = 2;
            this.colWeiterbildungAbsolviert.Width = 100;
            // 
            // colWeiterbildungDispensiert
            // 
            this.colWeiterbildungDispensiert.Caption = "Dispensiert";
            this.colWeiterbildungDispensiert.FieldName = "Dispensiert";
            this.colWeiterbildungDispensiert.Name = "colWeiterbildungDispensiert";
            this.colWeiterbildungDispensiert.Visible = true;
            this.colWeiterbildungDispensiert.VisibleIndex = 3;
            this.colWeiterbildungDispensiert.Width = 80;
            // 
            // colWeiterbildungBemerkungen
            // 
            this.colWeiterbildungBemerkungen.Caption = "Bemerkungen";
            this.colWeiterbildungBemerkungen.FieldName = "Bemerkungen";
            this.colWeiterbildungBemerkungen.Name = "colWeiterbildungBemerkungen";
            this.colWeiterbildungBemerkungen.Visible = true;
            this.colWeiterbildungBemerkungen.VisibleIndex = 4;
            this.colWeiterbildungBemerkungen.Width = 250;
            // 
            // panWeiterbildungDetails
            // 
            this.panWeiterbildungDetails.Controls.Add(this.edtWeiterbildungBemerkungen);
            this.panWeiterbildungDetails.Controls.Add(this.lblWeiterbildungBemerkungen);
            this.panWeiterbildungDetails.Controls.Add(this.edtWeiterbildungDispensiert);
            this.panWeiterbildungDetails.Controls.Add(this.edtWeiterbildungAbsolviert);
            this.panWeiterbildungDetails.Controls.Add(this.lblWeiterbildungAbsolviert);
            this.panWeiterbildungDetails.Controls.Add(this.edtWeiterbildungZuAbsolvierenBis);
            this.panWeiterbildungDetails.Controls.Add(this.lblWeiterbildungZuAbsolvierenBis);
            this.panWeiterbildungDetails.Controls.Add(this.edtWeiterbildungKurs);
            this.panWeiterbildungDetails.Controls.Add(this.lblWeiterbildungKurs);
            this.panWeiterbildungDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panWeiterbildungDetails.Location = new System.Drawing.Point(0, 187);
            this.panWeiterbildungDetails.Name = "panWeiterbildungDetails";
            this.panWeiterbildungDetails.Size = new System.Drawing.Size(976, 155);
            this.panWeiterbildungDetails.TabIndex = 1;
            // 
            // edtWeiterbildungBemerkungen
            // 
            this.edtWeiterbildungBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWeiterbildungBemerkungen.DataMember = "Bemerkungen";
            this.edtWeiterbildungBemerkungen.DataSource = this.qryEdMitarbeiterKurs;
            this.edtWeiterbildungBemerkungen.Location = new System.Drawing.Point(130, 69);
            this.edtWeiterbildungBemerkungen.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtWeiterbildungBemerkungen.Name = "edtWeiterbildungBemerkungen";
            this.edtWeiterbildungBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWeiterbildungBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWeiterbildungBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWeiterbildungBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtWeiterbildungBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWeiterbildungBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtWeiterbildungBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWeiterbildungBemerkungen.Properties.MaxLength = 5000;
            this.edtWeiterbildungBemerkungen.Size = new System.Drawing.Size(839, 77);
            this.edtWeiterbildungBemerkungen.TabIndex = 8;
            // 
            // lblWeiterbildungBemerkungen
            // 
            this.lblWeiterbildungBemerkungen.Location = new System.Drawing.Point(9, 69);
            this.lblWeiterbildungBemerkungen.Name = "lblWeiterbildungBemerkungen";
            this.lblWeiterbildungBemerkungen.Size = new System.Drawing.Size(93, 24);
            this.lblWeiterbildungBemerkungen.TabIndex = 7;
            this.lblWeiterbildungBemerkungen.Text = "Bemerkungen";
            this.lblWeiterbildungBemerkungen.UseCompatibleTextRendering = true;
            // 
            // edtWeiterbildungDispensiert
            // 
            this.edtWeiterbildungDispensiert.DataMember = "Dispensiert";
            this.edtWeiterbildungDispensiert.DataSource = this.qryEdMitarbeiterKurs;
            this.edtWeiterbildungDispensiert.Location = new System.Drawing.Point(450, 42);
            this.edtWeiterbildungDispensiert.Name = "edtWeiterbildungDispensiert";
            this.edtWeiterbildungDispensiert.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtWeiterbildungDispensiert.Properties.Appearance.Options.UseBackColor = true;
            this.edtWeiterbildungDispensiert.Properties.Caption = "Dispensiert";
            this.edtWeiterbildungDispensiert.Size = new System.Drawing.Size(119, 19);
            this.edtWeiterbildungDispensiert.TabIndex = 6;
            // 
            // edtWeiterbildungAbsolviert
            // 
            this.edtWeiterbildungAbsolviert.DataMember = "AbsolviertAm";
            this.edtWeiterbildungAbsolviert.DataSource = this.qryEdMitarbeiterKurs;
            this.edtWeiterbildungAbsolviert.EditValue = null;
            this.edtWeiterbildungAbsolviert.Location = new System.Drawing.Point(329, 39);
            this.edtWeiterbildungAbsolviert.Name = "edtWeiterbildungAbsolviert";
            this.edtWeiterbildungAbsolviert.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtWeiterbildungAbsolviert.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWeiterbildungAbsolviert.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWeiterbildungAbsolviert.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWeiterbildungAbsolviert.Properties.Appearance.Options.UseBackColor = true;
            this.edtWeiterbildungAbsolviert.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWeiterbildungAbsolviert.Properties.Appearance.Options.UseFont = true;
            this.edtWeiterbildungAbsolviert.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtWeiterbildungAbsolviert.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtWeiterbildungAbsolviert.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtWeiterbildungAbsolviert.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWeiterbildungAbsolviert.Properties.ShowToday = false;
            this.edtWeiterbildungAbsolviert.Size = new System.Drawing.Size(95, 24);
            this.edtWeiterbildungAbsolviert.TabIndex = 5;
            // 
            // lblWeiterbildungAbsolviert
            // 
            this.lblWeiterbildungAbsolviert.Location = new System.Drawing.Point(248, 39);
            this.lblWeiterbildungAbsolviert.Name = "lblWeiterbildungAbsolviert";
            this.lblWeiterbildungAbsolviert.Size = new System.Drawing.Size(75, 24);
            this.lblWeiterbildungAbsolviert.TabIndex = 4;
            this.lblWeiterbildungAbsolviert.Text = "Absolviert";
            this.lblWeiterbildungAbsolviert.UseCompatibleTextRendering = true;
            // 
            // edtWeiterbildungZuAbsolvierenBis
            // 
            this.edtWeiterbildungZuAbsolvierenBis.DataMember = "ZuAbsolvierenBis";
            this.edtWeiterbildungZuAbsolvierenBis.DataSource = this.qryEdMitarbeiterKurs;
            this.edtWeiterbildungZuAbsolvierenBis.EditValue = null;
            this.edtWeiterbildungZuAbsolvierenBis.Location = new System.Drawing.Point(130, 39);
            this.edtWeiterbildungZuAbsolvierenBis.Name = "edtWeiterbildungZuAbsolvierenBis";
            this.edtWeiterbildungZuAbsolvierenBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtWeiterbildungZuAbsolvierenBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWeiterbildungZuAbsolvierenBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWeiterbildungZuAbsolvierenBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWeiterbildungZuAbsolvierenBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtWeiterbildungZuAbsolvierenBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWeiterbildungZuAbsolvierenBis.Properties.Appearance.Options.UseFont = true;
            this.edtWeiterbildungZuAbsolvierenBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtWeiterbildungZuAbsolvierenBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtWeiterbildungZuAbsolvierenBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtWeiterbildungZuAbsolvierenBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWeiterbildungZuAbsolvierenBis.Properties.ShowToday = false;
            this.edtWeiterbildungZuAbsolvierenBis.Size = new System.Drawing.Size(95, 24);
            this.edtWeiterbildungZuAbsolvierenBis.TabIndex = 3;
            // 
            // lblWeiterbildungZuAbsolvierenBis
            // 
            this.lblWeiterbildungZuAbsolvierenBis.Location = new System.Drawing.Point(9, 39);
            this.lblWeiterbildungZuAbsolvierenBis.Name = "lblWeiterbildungZuAbsolvierenBis";
            this.lblWeiterbildungZuAbsolvierenBis.Size = new System.Drawing.Size(115, 24);
            this.lblWeiterbildungZuAbsolvierenBis.TabIndex = 2;
            this.lblWeiterbildungZuAbsolvierenBis.Text = "Zu absolvieren bis";
            this.lblWeiterbildungZuAbsolvierenBis.UseCompatibleTextRendering = true;
            // 
            // edtWeiterbildungKurs
            // 
            this.edtWeiterbildungKurs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWeiterbildungKurs.DataMember = "EdKursID";
            this.edtWeiterbildungKurs.DataSource = this.qryEdMitarbeiterKurs;
            this.edtWeiterbildungKurs.Location = new System.Drawing.Point(130, 9);
            this.edtWeiterbildungKurs.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtWeiterbildungKurs.Name = "edtWeiterbildungKurs";
            this.edtWeiterbildungKurs.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWeiterbildungKurs.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWeiterbildungKurs.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWeiterbildungKurs.Properties.Appearance.Options.UseBackColor = true;
            this.edtWeiterbildungKurs.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWeiterbildungKurs.Properties.Appearance.Options.UseFont = true;
            this.edtWeiterbildungKurs.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWeiterbildungKurs.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWeiterbildungKurs.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWeiterbildungKurs.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWeiterbildungKurs.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtWeiterbildungKurs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtWeiterbildungKurs.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWeiterbildungKurs.Properties.NullText = "";
            this.edtWeiterbildungKurs.Properties.ShowFooter = false;
            this.edtWeiterbildungKurs.Properties.ShowHeader = false;
            this.edtWeiterbildungKurs.Size = new System.Drawing.Size(839, 24);
            this.edtWeiterbildungKurs.TabIndex = 1;
            // 
            // lblWeiterbildungKurs
            // 
            this.lblWeiterbildungKurs.Location = new System.Drawing.Point(9, 9);
            this.lblWeiterbildungKurs.Name = "lblWeiterbildungKurs";
            this.lblWeiterbildungKurs.Size = new System.Drawing.Size(93, 24);
            this.lblWeiterbildungKurs.TabIndex = 0;
            this.lblWeiterbildungKurs.Text = "Kurs";
            this.lblWeiterbildungKurs.UseCompatibleTextRendering = true;
            // 
            // tpgPersoenlichkeit
            // 
            this.tpgPersoenlichkeit.Controls.Add(this.tblPersoenlichkeit);
            this.tpgPersoenlichkeit.Location = new System.Drawing.Point(6, 6);
            this.tpgPersoenlichkeit.Name = "tpgPersoenlichkeit";
            this.tpgPersoenlichkeit.Size = new System.Drawing.Size(976, 342);
            this.tpgPersoenlichkeit.TabIndex = 4;
            this.tpgPersoenlichkeit.Title = "Persönlichkeit";
            // 
            // tblPersoenlichkeit
            // 
            this.tblPersoenlichkeit.ColumnCount = 2;
            this.tblPersoenlichkeit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblPersoenlichkeit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPersoenlichkeit.Controls.Add(this.edtPersoenlichkeitErfahrungen, 1, 0);
            this.tblPersoenlichkeit.Controls.Add(this.lblPersoenlichkeitErfahrungen, 0, 0);
            this.tblPersoenlichkeit.Controls.Add(this.lblPersoenlichkeitErfahrungenNachAltersklassen, 0, 1);
            this.tblPersoenlichkeit.Controls.Add(this.lblPersoenlichkeitVorlieben, 0, 2);
            this.tblPersoenlichkeit.Controls.Add(this.lblPersoenlichkeitPersoenlichkeit, 0, 3);
            this.tblPersoenlichkeit.Controls.Add(this.lblPersoenlichkeitGesundheit, 0, 4);
            this.tblPersoenlichkeit.Controls.Add(this.edtPersoenlichkeitGesundheit, 1, 4);
            this.tblPersoenlichkeit.Controls.Add(this.edtPersoenlichkeitErfahrungenNachAltersklassen, 1, 1);
            this.tblPersoenlichkeit.Controls.Add(this.edtPersoenlichkeitVorlieben, 1, 2);
            this.tblPersoenlichkeit.Controls.Add(this.edtPersoenlichkeitPersoenlichkeit, 1, 3);
            this.tblPersoenlichkeit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPersoenlichkeit.Location = new System.Drawing.Point(0, 0);
            this.tblPersoenlichkeit.Name = "tblPersoenlichkeit";
            this.tblPersoenlichkeit.RowCount = 5;
            this.tblPersoenlichkeit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblPersoenlichkeit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblPersoenlichkeit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblPersoenlichkeit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblPersoenlichkeit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblPersoenlichkeit.Size = new System.Drawing.Size(976, 342);
            this.tblPersoenlichkeit.TabIndex = 10;
            // 
            // edtPersoenlichkeitErfahrungen
            // 
            this.edtPersoenlichkeitErfahrungen.DataMember = "PersoenlichkeitErfahrungen";
            this.edtPersoenlichkeitErfahrungen.DataSource = this.qryEdMitarbeiter;
            this.edtPersoenlichkeitErfahrungen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtPersoenlichkeitErfahrungen.Location = new System.Drawing.Point(122, 3);
            this.edtPersoenlichkeitErfahrungen.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtPersoenlichkeitErfahrungen.Name = "edtPersoenlichkeitErfahrungen";
            this.edtPersoenlichkeitErfahrungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersoenlichkeitErfahrungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersoenlichkeitErfahrungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersoenlichkeitErfahrungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersoenlichkeitErfahrungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersoenlichkeitErfahrungen.Properties.Appearance.Options.UseFont = true;
            this.edtPersoenlichkeitErfahrungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersoenlichkeitErfahrungen.Properties.MaxLength = 5000;
            this.edtPersoenlichkeitErfahrungen.Size = new System.Drawing.Size(845, 62);
            this.edtPersoenlichkeitErfahrungen.TabIndex = 1;
            // 
            // lblPersoenlichkeitErfahrungen
            // 
            this.lblPersoenlichkeitErfahrungen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPersoenlichkeitErfahrungen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersoenlichkeitErfahrungen.Location = new System.Drawing.Point(3, 3);
            this.lblPersoenlichkeitErfahrungen.Margin = new System.Windows.Forms.Padding(3);
            this.lblPersoenlichkeitErfahrungen.Name = "lblPersoenlichkeitErfahrungen";
            this.lblPersoenlichkeitErfahrungen.Size = new System.Drawing.Size(113, 51);
            this.lblPersoenlichkeitErfahrungen.TabIndex = 0;
            this.lblPersoenlichkeitErfahrungen.Text = "Erfahrungen";
            this.lblPersoenlichkeitErfahrungen.UseCompatibleTextRendering = true;
            // 
            // lblPersoenlichkeitErfahrungenNachAltersklassen
            // 
            this.lblPersoenlichkeitErfahrungenNachAltersklassen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPersoenlichkeitErfahrungenNachAltersklassen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersoenlichkeitErfahrungenNachAltersklassen.Location = new System.Drawing.Point(3, 71);
            this.lblPersoenlichkeitErfahrungenNachAltersklassen.Margin = new System.Windows.Forms.Padding(3);
            this.lblPersoenlichkeitErfahrungenNachAltersklassen.Name = "lblPersoenlichkeitErfahrungenNachAltersklassen";
            this.lblPersoenlichkeitErfahrungenNachAltersklassen.Size = new System.Drawing.Size(113, 51);
            this.lblPersoenlichkeitErfahrungenNachAltersklassen.TabIndex = 2;
            this.lblPersoenlichkeitErfahrungenNachAltersklassen.Text = "Erfahrungen nach Altersklassen";
            this.lblPersoenlichkeitErfahrungenNachAltersklassen.UseCompatibleTextRendering = true;
            // 
            // lblPersoenlichkeitVorlieben
            // 
            this.lblPersoenlichkeitVorlieben.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPersoenlichkeitVorlieben.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersoenlichkeitVorlieben.Location = new System.Drawing.Point(3, 139);
            this.lblPersoenlichkeitVorlieben.Margin = new System.Windows.Forms.Padding(3);
            this.lblPersoenlichkeitVorlieben.Name = "lblPersoenlichkeitVorlieben";
            this.lblPersoenlichkeitVorlieben.Size = new System.Drawing.Size(113, 51);
            this.lblPersoenlichkeitVorlieben.TabIndex = 4;
            this.lblPersoenlichkeitVorlieben.Text = "Vorlieben";
            this.lblPersoenlichkeitVorlieben.UseCompatibleTextRendering = true;
            // 
            // lblPersoenlichkeitPersoenlichkeit
            // 
            this.lblPersoenlichkeitPersoenlichkeit.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPersoenlichkeitPersoenlichkeit.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersoenlichkeitPersoenlichkeit.Location = new System.Drawing.Point(3, 207);
            this.lblPersoenlichkeitPersoenlichkeit.Margin = new System.Windows.Forms.Padding(3);
            this.lblPersoenlichkeitPersoenlichkeit.Name = "lblPersoenlichkeitPersoenlichkeit";
            this.lblPersoenlichkeitPersoenlichkeit.Size = new System.Drawing.Size(113, 51);
            this.lblPersoenlichkeitPersoenlichkeit.TabIndex = 6;
            this.lblPersoenlichkeitPersoenlichkeit.Text = "Persönlichkeit";
            this.lblPersoenlichkeitPersoenlichkeit.UseCompatibleTextRendering = true;
            // 
            // lblPersoenlichkeitGesundheit
            // 
            this.lblPersoenlichkeitGesundheit.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPersoenlichkeitGesundheit.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersoenlichkeitGesundheit.Location = new System.Drawing.Point(3, 275);
            this.lblPersoenlichkeitGesundheit.Margin = new System.Windows.Forms.Padding(3);
            this.lblPersoenlichkeitGesundheit.Name = "lblPersoenlichkeitGesundheit";
            this.lblPersoenlichkeitGesundheit.Size = new System.Drawing.Size(113, 51);
            this.lblPersoenlichkeitGesundheit.TabIndex = 8;
            this.lblPersoenlichkeitGesundheit.Text = "Gesundheitliche Einschränkungen";
            this.lblPersoenlichkeitGesundheit.UseCompatibleTextRendering = true;
            // 
            // edtPersoenlichkeitGesundheit
            // 
            this.edtPersoenlichkeitGesundheit.DataMember = "PersoenlichkeitGesundheit";
            this.edtPersoenlichkeitGesundheit.DataSource = this.qryEdMitarbeiter;
            this.edtPersoenlichkeitGesundheit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtPersoenlichkeitGesundheit.Location = new System.Drawing.Point(122, 275);
            this.edtPersoenlichkeitGesundheit.Name = "edtPersoenlichkeitGesundheit";
            this.edtPersoenlichkeitGesundheit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersoenlichkeitGesundheit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersoenlichkeitGesundheit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersoenlichkeitGesundheit.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersoenlichkeitGesundheit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersoenlichkeitGesundheit.Properties.Appearance.Options.UseFont = true;
            this.edtPersoenlichkeitGesundheit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersoenlichkeitGesundheit.Properties.MaxLength = 5000;
            this.edtPersoenlichkeitGesundheit.Size = new System.Drawing.Size(851, 64);
            this.edtPersoenlichkeitGesundheit.TabIndex = 9;
            // 
            // edtPersoenlichkeitErfahrungenNachAltersklassen
            // 
            this.edtPersoenlichkeitErfahrungenNachAltersklassen.DataMember = "PersoenlichkeitErfahrungenAlter";
            this.edtPersoenlichkeitErfahrungenNachAltersklassen.DataSource = this.qryEdMitarbeiter;
            this.edtPersoenlichkeitErfahrungenNachAltersklassen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtPersoenlichkeitErfahrungenNachAltersklassen.Location = new System.Drawing.Point(122, 71);
            this.edtPersoenlichkeitErfahrungenNachAltersklassen.Name = "edtPersoenlichkeitErfahrungenNachAltersklassen";
            this.edtPersoenlichkeitErfahrungenNachAltersklassen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersoenlichkeitErfahrungenNachAltersklassen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersoenlichkeitErfahrungenNachAltersklassen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersoenlichkeitErfahrungenNachAltersklassen.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersoenlichkeitErfahrungenNachAltersklassen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersoenlichkeitErfahrungenNachAltersklassen.Properties.Appearance.Options.UseFont = true;
            this.edtPersoenlichkeitErfahrungenNachAltersklassen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersoenlichkeitErfahrungenNachAltersklassen.Properties.MaxLength = 5000;
            this.edtPersoenlichkeitErfahrungenNachAltersklassen.Size = new System.Drawing.Size(851, 62);
            this.edtPersoenlichkeitErfahrungenNachAltersklassen.TabIndex = 3;
            // 
            // edtPersoenlichkeitVorlieben
            // 
            this.edtPersoenlichkeitVorlieben.DataMember = "PersoenlichkeitVorlieben";
            this.edtPersoenlichkeitVorlieben.DataSource = this.qryEdMitarbeiter;
            this.edtPersoenlichkeitVorlieben.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtPersoenlichkeitVorlieben.Location = new System.Drawing.Point(122, 139);
            this.edtPersoenlichkeitVorlieben.Name = "edtPersoenlichkeitVorlieben";
            this.edtPersoenlichkeitVorlieben.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersoenlichkeitVorlieben.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersoenlichkeitVorlieben.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersoenlichkeitVorlieben.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersoenlichkeitVorlieben.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersoenlichkeitVorlieben.Properties.Appearance.Options.UseFont = true;
            this.edtPersoenlichkeitVorlieben.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersoenlichkeitVorlieben.Properties.MaxLength = 5000;
            this.edtPersoenlichkeitVorlieben.Size = new System.Drawing.Size(851, 62);
            this.edtPersoenlichkeitVorlieben.TabIndex = 5;
            // 
            // edtPersoenlichkeitPersoenlichkeit
            // 
            this.edtPersoenlichkeitPersoenlichkeit.DataMember = "PersoenlichkeitPersoenlichkeit";
            this.edtPersoenlichkeitPersoenlichkeit.DataSource = this.qryEdMitarbeiter;
            this.edtPersoenlichkeitPersoenlichkeit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtPersoenlichkeitPersoenlichkeit.Location = new System.Drawing.Point(122, 207);
            this.edtPersoenlichkeitPersoenlichkeit.Name = "edtPersoenlichkeitPersoenlichkeit";
            this.edtPersoenlichkeitPersoenlichkeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersoenlichkeitPersoenlichkeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersoenlichkeitPersoenlichkeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersoenlichkeitPersoenlichkeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersoenlichkeitPersoenlichkeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersoenlichkeitPersoenlichkeit.Properties.Appearance.Options.UseFont = true;
            this.edtPersoenlichkeitPersoenlichkeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersoenlichkeitPersoenlichkeit.Properties.MaxLength = 5000;
            this.edtPersoenlichkeitPersoenlichkeit.Size = new System.Drawing.Size(851, 62);
            this.edtPersoenlichkeitPersoenlichkeit.TabIndex = 7;
            // 
            // tpgKenntnisse
            // 
            this.tpgKenntnisse.Controls.Add(this.edtKenntnisseWeitereKenntnisse);
            this.tpgKenntnisse.Controls.Add(this.lblKenntnisseWeitereKenntnisse);
            this.tpgKenntnisse.Controls.Add(this.grpKenntnisseHilfetechniken);
            this.tpgKenntnisse.Controls.Add(this.grpKenntnissePsychischeBehinderung);
            this.tpgKenntnisse.Controls.Add(this.grpKenntnisseGeistigeBehinderung);
            this.tpgKenntnisse.Controls.Add(this.grpKenntnisseKoerperlicheBehinderung);
            this.tpgKenntnisse.Location = new System.Drawing.Point(6, 6);
            this.tpgKenntnisse.Name = "tpgKenntnisse";
            this.tpgKenntnisse.Size = new System.Drawing.Size(976, 342);
            this.tpgKenntnisse.TabIndex = 5;
            this.tpgKenntnisse.Title = "Kenntnisse";
            // 
            // edtKenntnisseWeitereKenntnisse
            // 
            this.edtKenntnisseWeitereKenntnisse.DataMember = "KenntnisseWeitere";
            this.edtKenntnisseWeitereKenntnisse.DataSource = this.qryEdMitarbeiter;
            this.edtKenntnisseWeitereKenntnisse.Location = new System.Drawing.Point(169, 217);
            this.edtKenntnisseWeitereKenntnisse.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtKenntnisseWeitereKenntnisse.Name = "edtKenntnisseWeitereKenntnisse";
            this.edtKenntnisseWeitereKenntnisse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKenntnisseWeitereKenntnisse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKenntnisseWeitereKenntnisse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKenntnisseWeitereKenntnisse.Properties.Appearance.Options.UseBackColor = true;
            this.edtKenntnisseWeitereKenntnisse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKenntnisseWeitereKenntnisse.Properties.Appearance.Options.UseFont = true;
            this.edtKenntnisseWeitereKenntnisse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKenntnisseWeitereKenntnisse.Properties.MaxLength = 5000;
            this.edtKenntnisseWeitereKenntnisse.Size = new System.Drawing.Size(610, 74);
            this.edtKenntnisseWeitereKenntnisse.TabIndex = 5;
            // 
            // lblKenntnisseWeitereKenntnisse
            // 
            this.lblKenntnisseWeitereKenntnisse.Location = new System.Drawing.Point(9, 217);
            this.lblKenntnisseWeitereKenntnisse.Name = "lblKenntnisseWeitereKenntnisse";
            this.lblKenntnisseWeitereKenntnisse.Size = new System.Drawing.Size(154, 24);
            this.lblKenntnisseWeitereKenntnisse.TabIndex = 4;
            this.lblKenntnisseWeitereKenntnisse.Text = "Weitere Kenntnisse";
            this.lblKenntnisseWeitereKenntnisse.UseCompatibleTextRendering = true;
            // 
            // grpKenntnisseHilfetechniken
            // 
            this.grpKenntnisseHilfetechniken.Controls.Add(this.edtKenntnisseKommunikation);
            this.grpKenntnisseHilfetechniken.Controls.Add(this.lblKenntnisseKommunikation);
            this.grpKenntnisseHilfetechniken.Controls.Add(this.edtKenntnisseTransporte);
            this.grpKenntnisseHilfetechniken.Controls.Add(this.lblKenntnisseTransporte);
            this.grpKenntnisseHilfetechniken.Controls.Add(this.edtKenntnisseHilfsmittel);
            this.grpKenntnisseHilfetechniken.Controls.Add(this.lblKenntnisseHilfsmittel);
            this.grpKenntnisseHilfetechniken.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grpKenntnisseHilfetechniken.Location = new System.Drawing.Point(404, 100);
            this.grpKenntnisseHilfetechniken.Name = "grpKenntnisseHilfetechniken";
            this.grpKenntnisseHilfetechniken.Size = new System.Drawing.Size(375, 111);
            this.grpKenntnisseHilfetechniken.TabIndex = 3;
            this.grpKenntnisseHilfetechniken.TabStop = false;
            this.grpKenntnisseHilfetechniken.Text = "Hilfetechniken";
            this.grpKenntnisseHilfetechniken.UseCompatibleTextRendering = true;
            // 
            // edtKenntnisseKommunikation
            // 
            this.edtKenntnisseKommunikation.DataMember = "KenntnisseKommunikation";
            this.edtKenntnisseKommunikation.DataSource = this.qryEdMitarbeiter;
            this.edtKenntnisseKommunikation.Location = new System.Drawing.Point(158, 77);
            this.edtKenntnisseKommunikation.Name = "edtKenntnisseKommunikation";
            this.edtKenntnisseKommunikation.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKenntnisseKommunikation.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKenntnisseKommunikation.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKenntnisseKommunikation.Properties.Appearance.Options.UseBackColor = true;
            this.edtKenntnisseKommunikation.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKenntnisseKommunikation.Properties.Appearance.Options.UseFont = true;
            this.edtKenntnisseKommunikation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKenntnisseKommunikation.Properties.MaxLength = 255;
            this.edtKenntnisseKommunikation.Size = new System.Drawing.Size(211, 24);
            this.edtKenntnisseKommunikation.TabIndex = 5;
            // 
            // lblKenntnisseKommunikation
            // 
            this.lblKenntnisseKommunikation.Location = new System.Drawing.Point(6, 77);
            this.lblKenntnisseKommunikation.Name = "lblKenntnisseKommunikation";
            this.lblKenntnisseKommunikation.Size = new System.Drawing.Size(146, 24);
            this.lblKenntnisseKommunikation.TabIndex = 4;
            this.lblKenntnisseKommunikation.Text = "Kommunikation";
            this.lblKenntnisseKommunikation.UseCompatibleTextRendering = true;
            // 
            // edtKenntnisseTransporte
            // 
            this.edtKenntnisseTransporte.DataMember = "KenntnisseTransport";
            this.edtKenntnisseTransporte.DataSource = this.qryEdMitarbeiter;
            this.edtKenntnisseTransporte.Location = new System.Drawing.Point(158, 47);
            this.edtKenntnisseTransporte.Name = "edtKenntnisseTransporte";
            this.edtKenntnisseTransporte.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKenntnisseTransporte.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKenntnisseTransporte.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKenntnisseTransporte.Properties.Appearance.Options.UseBackColor = true;
            this.edtKenntnisseTransporte.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKenntnisseTransporte.Properties.Appearance.Options.UseFont = true;
            this.edtKenntnisseTransporte.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKenntnisseTransporte.Properties.MaxLength = 255;
            this.edtKenntnisseTransporte.Size = new System.Drawing.Size(211, 24);
            this.edtKenntnisseTransporte.TabIndex = 3;
            // 
            // lblKenntnisseTransporte
            // 
            this.lblKenntnisseTransporte.Location = new System.Drawing.Point(6, 47);
            this.lblKenntnisseTransporte.Name = "lblKenntnisseTransporte";
            this.lblKenntnisseTransporte.Size = new System.Drawing.Size(146, 24);
            this.lblKenntnisseTransporte.TabIndex = 2;
            this.lblKenntnisseTransporte.Text = "Transport";
            this.lblKenntnisseTransporte.UseCompatibleTextRendering = true;
            // 
            // edtKenntnisseHilfsmittel
            // 
            this.edtKenntnisseHilfsmittel.DataMember = "KenntnisseHilfsmittel";
            this.edtKenntnisseHilfsmittel.DataSource = this.qryEdMitarbeiter;
            this.edtKenntnisseHilfsmittel.Location = new System.Drawing.Point(158, 17);
            this.edtKenntnisseHilfsmittel.Name = "edtKenntnisseHilfsmittel";
            this.edtKenntnisseHilfsmittel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKenntnisseHilfsmittel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKenntnisseHilfsmittel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKenntnisseHilfsmittel.Properties.Appearance.Options.UseBackColor = true;
            this.edtKenntnisseHilfsmittel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKenntnisseHilfsmittel.Properties.Appearance.Options.UseFont = true;
            this.edtKenntnisseHilfsmittel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKenntnisseHilfsmittel.Properties.MaxLength = 255;
            this.edtKenntnisseHilfsmittel.Size = new System.Drawing.Size(211, 24);
            this.edtKenntnisseHilfsmittel.TabIndex = 1;
            // 
            // lblKenntnisseHilfsmittel
            // 
            this.lblKenntnisseHilfsmittel.Location = new System.Drawing.Point(6, 17);
            this.lblKenntnisseHilfsmittel.Name = "lblKenntnisseHilfsmittel";
            this.lblKenntnisseHilfsmittel.Size = new System.Drawing.Size(146, 24);
            this.lblKenntnisseHilfsmittel.TabIndex = 0;
            this.lblKenntnisseHilfsmittel.Text = "Hilfsmittel";
            this.lblKenntnisseHilfsmittel.UseCompatibleTextRendering = true;
            // 
            // grpKenntnissePsychischeBehinderung
            // 
            this.grpKenntnissePsychischeBehinderung.Controls.Add(this.edtKenntnisseSelbstFremdaggression);
            this.grpKenntnissePsychischeBehinderung.Controls.Add(this.lblKenntnisseSelbstFremdaggression);
            this.grpKenntnissePsychischeBehinderung.Controls.Add(this.edtKenntnisseVerhaltensstoerung);
            this.grpKenntnissePsychischeBehinderung.Controls.Add(this.lblKenntnisseVerhaltensstoerung);
            this.grpKenntnissePsychischeBehinderung.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grpKenntnissePsychischeBehinderung.Location = new System.Drawing.Point(404, 9);
            this.grpKenntnissePsychischeBehinderung.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.grpKenntnissePsychischeBehinderung.Name = "grpKenntnissePsychischeBehinderung";
            this.grpKenntnissePsychischeBehinderung.Size = new System.Drawing.Size(375, 85);
            this.grpKenntnissePsychischeBehinderung.TabIndex = 2;
            this.grpKenntnissePsychischeBehinderung.TabStop = false;
            this.grpKenntnissePsychischeBehinderung.Text = "Psychische Behinderung";
            this.grpKenntnissePsychischeBehinderung.UseCompatibleTextRendering = true;
            // 
            // edtKenntnisseSelbstFremdaggression
            // 
            this.edtKenntnisseSelbstFremdaggression.DataMember = "KenntnisseAggression";
            this.edtKenntnisseSelbstFremdaggression.DataSource = this.qryEdMitarbeiter;
            this.edtKenntnisseSelbstFremdaggression.Location = new System.Drawing.Point(158, 47);
            this.edtKenntnisseSelbstFremdaggression.Name = "edtKenntnisseSelbstFremdaggression";
            this.edtKenntnisseSelbstFremdaggression.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKenntnisseSelbstFremdaggression.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKenntnisseSelbstFremdaggression.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKenntnisseSelbstFremdaggression.Properties.Appearance.Options.UseBackColor = true;
            this.edtKenntnisseSelbstFremdaggression.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKenntnisseSelbstFremdaggression.Properties.Appearance.Options.UseFont = true;
            this.edtKenntnisseSelbstFremdaggression.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKenntnisseSelbstFremdaggression.Properties.MaxLength = 255;
            this.edtKenntnisseSelbstFremdaggression.Size = new System.Drawing.Size(211, 24);
            this.edtKenntnisseSelbstFremdaggression.TabIndex = 3;
            // 
            // lblKenntnisseSelbstFremdaggression
            // 
            this.lblKenntnisseSelbstFremdaggression.Location = new System.Drawing.Point(6, 47);
            this.lblKenntnisseSelbstFremdaggression.Name = "lblKenntnisseSelbstFremdaggression";
            this.lblKenntnisseSelbstFremdaggression.Size = new System.Drawing.Size(146, 24);
            this.lblKenntnisseSelbstFremdaggression.TabIndex = 2;
            this.lblKenntnisseSelbstFremdaggression.Text = "Selbst-/Fremdaggression";
            this.lblKenntnisseSelbstFremdaggression.UseCompatibleTextRendering = true;
            // 
            // edtKenntnisseVerhaltensstoerung
            // 
            this.edtKenntnisseVerhaltensstoerung.DataMember = "KenntnisseVerhaltensstoerung";
            this.edtKenntnisseVerhaltensstoerung.DataSource = this.qryEdMitarbeiter;
            this.edtKenntnisseVerhaltensstoerung.Location = new System.Drawing.Point(158, 20);
            this.edtKenntnisseVerhaltensstoerung.Name = "edtKenntnisseVerhaltensstoerung";
            this.edtKenntnisseVerhaltensstoerung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKenntnisseVerhaltensstoerung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKenntnisseVerhaltensstoerung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKenntnisseVerhaltensstoerung.Properties.Appearance.Options.UseBackColor = true;
            this.edtKenntnisseVerhaltensstoerung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKenntnisseVerhaltensstoerung.Properties.Appearance.Options.UseFont = true;
            this.edtKenntnisseVerhaltensstoerung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKenntnisseVerhaltensstoerung.Properties.MaxLength = 255;
            this.edtKenntnisseVerhaltensstoerung.Size = new System.Drawing.Size(211, 24);
            this.edtKenntnisseVerhaltensstoerung.TabIndex = 1;
            // 
            // lblKenntnisseVerhaltensstoerung
            // 
            this.lblKenntnisseVerhaltensstoerung.Location = new System.Drawing.Point(6, 17);
            this.lblKenntnisseVerhaltensstoerung.Name = "lblKenntnisseVerhaltensstoerung";
            this.lblKenntnisseVerhaltensstoerung.Size = new System.Drawing.Size(146, 24);
            this.lblKenntnisseVerhaltensstoerung.TabIndex = 0;
            this.lblKenntnisseVerhaltensstoerung.Text = "Verhaltensstörungen";
            this.lblKenntnisseVerhaltensstoerung.UseCompatibleTextRendering = true;
            // 
            // grpKenntnisseGeistigeBehinderung
            // 
            this.grpKenntnisseGeistigeBehinderung.Controls.Add(this.edtGeistigeBehinderung);
            this.grpKenntnisseGeistigeBehinderung.Controls.Add(this.lblKenntnisseGeistigeBehinderung);
            this.grpKenntnisseGeistigeBehinderung.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grpKenntnisseGeistigeBehinderung.Location = new System.Drawing.Point(9, 158);
            this.grpKenntnisseGeistigeBehinderung.Name = "grpKenntnisseGeistigeBehinderung";
            this.grpKenntnisseGeistigeBehinderung.Size = new System.Drawing.Size(375, 53);
            this.grpKenntnisseGeistigeBehinderung.TabIndex = 1;
            this.grpKenntnisseGeistigeBehinderung.TabStop = false;
            this.grpKenntnisseGeistigeBehinderung.Text = "Geistige Behinderung";
            this.grpKenntnisseGeistigeBehinderung.UseCompatibleTextRendering = true;
            // 
            // edtGeistigeBehinderung
            // 
            this.edtGeistigeBehinderung.DataMember = "KenntnisseGeistigeBehinderung";
            this.edtGeistigeBehinderung.DataSource = this.qryEdMitarbeiter;
            this.edtGeistigeBehinderung.Location = new System.Drawing.Point(158, 17);
            this.edtGeistigeBehinderung.Name = "edtGeistigeBehinderung";
            this.edtGeistigeBehinderung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeistigeBehinderung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeistigeBehinderung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeistigeBehinderung.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeistigeBehinderung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeistigeBehinderung.Properties.Appearance.Options.UseFont = true;
            this.edtGeistigeBehinderung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGeistigeBehinderung.Properties.MaxLength = 255;
            this.edtGeistigeBehinderung.Size = new System.Drawing.Size(211, 24);
            this.edtGeistigeBehinderung.TabIndex = 1;
            // 
            // lblKenntnisseGeistigeBehinderung
            // 
            this.lblKenntnisseGeistigeBehinderung.Location = new System.Drawing.Point(6, 17);
            this.lblKenntnisseGeistigeBehinderung.Name = "lblKenntnisseGeistigeBehinderung";
            this.lblKenntnisseGeistigeBehinderung.Size = new System.Drawing.Size(146, 24);
            this.lblKenntnisseGeistigeBehinderung.TabIndex = 0;
            this.lblKenntnisseGeistigeBehinderung.Text = "Geistige Behinderung";
            this.lblKenntnisseGeistigeBehinderung.UseCompatibleTextRendering = true;
            // 
            // grpKenntnisseKoerperlicheBehinderung
            // 
            this.grpKenntnisseKoerperlicheBehinderung.Controls.Add(this.edtKenntnisseEpilepsie);
            this.grpKenntnisseKoerperlicheBehinderung.Controls.Add(this.lblKenntnisseEpilepsie);
            this.grpKenntnisseKoerperlicheBehinderung.Controls.Add(this.edtKenntnisseGehirnschaedigung);
            this.grpKenntnisseKoerperlicheBehinderung.Controls.Add(this.lblKenntnisseGehirnschaedigung);
            this.grpKenntnisseKoerperlicheBehinderung.Controls.Add(this.edtKenntnisseIMC);
            this.grpKenntnisseKoerperlicheBehinderung.Controls.Add(this.lblKenntnisseIMC);
            this.grpKenntnisseKoerperlicheBehinderung.Controls.Add(this.edtKenntnisseMehrfachbehinderung);
            this.grpKenntnisseKoerperlicheBehinderung.Controls.Add(this.lblKenntnisseMehrfachbehinderung);
            this.grpKenntnisseKoerperlicheBehinderung.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grpKenntnisseKoerperlicheBehinderung.Location = new System.Drawing.Point(9, 9);
            this.grpKenntnisseKoerperlicheBehinderung.Name = "grpKenntnisseKoerperlicheBehinderung";
            this.grpKenntnisseKoerperlicheBehinderung.Size = new System.Drawing.Size(375, 143);
            this.grpKenntnisseKoerperlicheBehinderung.TabIndex = 0;
            this.grpKenntnisseKoerperlicheBehinderung.TabStop = false;
            this.grpKenntnisseKoerperlicheBehinderung.Text = "Körperliche Behinderung";
            this.grpKenntnisseKoerperlicheBehinderung.UseCompatibleTextRendering = true;
            // 
            // edtKenntnisseEpilepsie
            // 
            this.edtKenntnisseEpilepsie.DataMember = "KenntnisseEpilepsie";
            this.edtKenntnisseEpilepsie.DataSource = this.qryEdMitarbeiter;
            this.edtKenntnisseEpilepsie.Location = new System.Drawing.Point(158, 107);
            this.edtKenntnisseEpilepsie.Name = "edtKenntnisseEpilepsie";
            this.edtKenntnisseEpilepsie.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKenntnisseEpilepsie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKenntnisseEpilepsie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKenntnisseEpilepsie.Properties.Appearance.Options.UseBackColor = true;
            this.edtKenntnisseEpilepsie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKenntnisseEpilepsie.Properties.Appearance.Options.UseFont = true;
            this.edtKenntnisseEpilepsie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKenntnisseEpilepsie.Properties.MaxLength = 255;
            this.edtKenntnisseEpilepsie.Size = new System.Drawing.Size(211, 24);
            this.edtKenntnisseEpilepsie.TabIndex = 7;
            // 
            // lblKenntnisseEpilepsie
            // 
            this.lblKenntnisseEpilepsie.Location = new System.Drawing.Point(6, 107);
            this.lblKenntnisseEpilepsie.Name = "lblKenntnisseEpilepsie";
            this.lblKenntnisseEpilepsie.Size = new System.Drawing.Size(146, 24);
            this.lblKenntnisseEpilepsie.TabIndex = 6;
            this.lblKenntnisseEpilepsie.Text = "Epilepsie";
            this.lblKenntnisseEpilepsie.UseCompatibleTextRendering = true;
            // 
            // edtKenntnisseGehirnschaedigung
            // 
            this.edtKenntnisseGehirnschaedigung.DataMember = "KenntnisseGehirnschaedigung";
            this.edtKenntnisseGehirnschaedigung.DataSource = this.qryEdMitarbeiter;
            this.edtKenntnisseGehirnschaedigung.Location = new System.Drawing.Point(158, 77);
            this.edtKenntnisseGehirnschaedigung.Name = "edtKenntnisseGehirnschaedigung";
            this.edtKenntnisseGehirnschaedigung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKenntnisseGehirnschaedigung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKenntnisseGehirnschaedigung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKenntnisseGehirnschaedigung.Properties.Appearance.Options.UseBackColor = true;
            this.edtKenntnisseGehirnschaedigung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKenntnisseGehirnschaedigung.Properties.Appearance.Options.UseFont = true;
            this.edtKenntnisseGehirnschaedigung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKenntnisseGehirnschaedigung.Properties.MaxLength = 255;
            this.edtKenntnisseGehirnschaedigung.Size = new System.Drawing.Size(211, 24);
            this.edtKenntnisseGehirnschaedigung.TabIndex = 5;
            // 
            // lblKenntnisseGehirnschaedigung
            // 
            this.lblKenntnisseGehirnschaedigung.Location = new System.Drawing.Point(6, 77);
            this.lblKenntnisseGehirnschaedigung.Name = "lblKenntnisseGehirnschaedigung";
            this.lblKenntnisseGehirnschaedigung.Size = new System.Drawing.Size(146, 24);
            this.lblKenntnisseGehirnschaedigung.TabIndex = 4;
            this.lblKenntnisseGehirnschaedigung.Text = "Gehirnschädigung";
            this.lblKenntnisseGehirnschaedigung.UseCompatibleTextRendering = true;
            // 
            // edtKenntnisseIMC
            // 
            this.edtKenntnisseIMC.DataMember = "KenntnisseIMC";
            this.edtKenntnisseIMC.DataSource = this.qryEdMitarbeiter;
            this.edtKenntnisseIMC.Location = new System.Drawing.Point(158, 47);
            this.edtKenntnisseIMC.Name = "edtKenntnisseIMC";
            this.edtKenntnisseIMC.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKenntnisseIMC.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKenntnisseIMC.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKenntnisseIMC.Properties.Appearance.Options.UseBackColor = true;
            this.edtKenntnisseIMC.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKenntnisseIMC.Properties.Appearance.Options.UseFont = true;
            this.edtKenntnisseIMC.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKenntnisseIMC.Properties.MaxLength = 255;
            this.edtKenntnisseIMC.Size = new System.Drawing.Size(211, 24);
            this.edtKenntnisseIMC.TabIndex = 3;
            // 
            // lblKenntnisseIMC
            // 
            this.lblKenntnisseIMC.Location = new System.Drawing.Point(6, 47);
            this.lblKenntnisseIMC.Name = "lblKenntnisseIMC";
            this.lblKenntnisseIMC.Size = new System.Drawing.Size(146, 24);
            this.lblKenntnisseIMC.TabIndex = 2;
            this.lblKenntnisseIMC.Text = "IMC";
            this.lblKenntnisseIMC.UseCompatibleTextRendering = true;
            // 
            // edtKenntnisseMehrfachbehinderung
            // 
            this.edtKenntnisseMehrfachbehinderung.DataMember = "KenntnisseMehrfachbehinderung";
            this.edtKenntnisseMehrfachbehinderung.DataSource = this.qryEdMitarbeiter;
            this.edtKenntnisseMehrfachbehinderung.Location = new System.Drawing.Point(158, 17);
            this.edtKenntnisseMehrfachbehinderung.Name = "edtKenntnisseMehrfachbehinderung";
            this.edtKenntnisseMehrfachbehinderung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKenntnisseMehrfachbehinderung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKenntnisseMehrfachbehinderung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKenntnisseMehrfachbehinderung.Properties.Appearance.Options.UseBackColor = true;
            this.edtKenntnisseMehrfachbehinderung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKenntnisseMehrfachbehinderung.Properties.Appearance.Options.UseFont = true;
            this.edtKenntnisseMehrfachbehinderung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKenntnisseMehrfachbehinderung.Properties.MaxLength = 255;
            this.edtKenntnisseMehrfachbehinderung.Size = new System.Drawing.Size(211, 24);
            this.edtKenntnisseMehrfachbehinderung.TabIndex = 1;
            // 
            // lblKenntnisseMehrfachbehinderung
            // 
            this.lblKenntnisseMehrfachbehinderung.Location = new System.Drawing.Point(6, 17);
            this.lblKenntnisseMehrfachbehinderung.Name = "lblKenntnisseMehrfachbehinderung";
            this.lblKenntnisseMehrfachbehinderung.Size = new System.Drawing.Size(146, 24);
            this.lblKenntnisseMehrfachbehinderung.TabIndex = 0;
            this.lblKenntnisseMehrfachbehinderung.Text = "Mehrfachbehinderung";
            this.lblKenntnisseMehrfachbehinderung.UseCompatibleTextRendering = true;
            // 
            // btnVerfuegbarkeit
            // 
            this.btnVerfuegbarkeit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerfuegbarkeit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerfuegbarkeit.Location = new System.Drawing.Point(746, 641);
            this.btnVerfuegbarkeit.Name = "btnVerfuegbarkeit";
            this.btnVerfuegbarkeit.Size = new System.Drawing.Size(116, 24);
            this.btnVerfuegbarkeit.TabIndex = 2;
            this.btnVerfuegbarkeit.Text = ">> &Verfügbarkeit";
            this.btnVerfuegbarkeit.UseCompatibleTextRendering = true;
            this.btnVerfuegbarkeit.UseVisualStyleBackColor = false;
            this.btnVerfuegbarkeit.Click += new System.EventHandler(this.btnVerfuegbarkeit_Click);
            // 
            // btnEdMaBericht
            // 
            this.btnEdMaBericht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdMaBericht.Context = "ED_Mitarbeiter_Dokument";
            this.btnEdMaBericht.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.btnEdMaBericht.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdMaBericht.Image = ((System.Drawing.Image)(resources.GetObject("btnEdMaBericht.Image")));
            this.btnEdMaBericht.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdMaBericht.Location = new System.Drawing.Point(873, 641);
            this.btnEdMaBericht.Name = "btnEdMaBericht";
            this.btnEdMaBericht.Size = new System.Drawing.Size(110, 24);
            this.btnEdMaBericht.TabIndex = 3;
            this.btnEdMaBericht.Text = "Dokument";
            this.btnEdMaBericht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdMaBericht.UseVisualStyleBackColor = false;
            // 
            // edtSucheModul
            // 
            this.edtSucheModul.Location = new System.Drawing.Point(131, 130);
            this.edtSucheModul.LOVFilter = "ModulID IN (5,6)";
            this.edtSucheModul.LOVFilterWhereAppend = true;
            this.edtSucheModul.LOVName = "Modul";
            this.edtSucheModul.Name = "edtSucheModul";
            this.edtSucheModul.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheModul.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheModul.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheModul.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheModul.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheModul.Properties.Appearance.Options.UseFont = true;
            this.edtSucheModul.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheModul.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheModul.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheModul.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheModul.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject21.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject21.Options.UseBackColor = true;
            this.edtSucheModul.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21)});
            this.edtSucheModul.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheModul.Properties.NullText = "";
            this.edtSucheModul.Properties.ShowFooter = false;
            this.edtSucheModul.Properties.ShowHeader = false;
            this.edtSucheModul.Size = new System.Drawing.Size(223, 24);
            this.edtSucheModul.TabIndex = 8;
            // 
            // edtSucheTypBW
            // 
            this.edtSucheTypBW.Location = new System.Drawing.Point(501, 40);
            this.edtSucheTypBW.LOVName = "BwTyp";
            this.edtSucheTypBW.Name = "edtSucheTypBW";
            this.edtSucheTypBW.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTypBW.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTypBW.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTypBW.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTypBW.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTypBW.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTypBW.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheTypBW.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTypBW.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheTypBW.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheTypBW.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject20.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject20.Options.UseBackColor = true;
            this.edtSucheTypBW.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject20)});
            this.edtSucheTypBW.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTypBW.Properties.NullText = "";
            this.edtSucheTypBW.Properties.ShowFooter = false;
            this.edtSucheTypBW.Properties.ShowHeader = false;
            this.edtSucheTypBW.Size = new System.Drawing.Size(223, 24);
            this.edtSucheTypBW.TabIndex = 10;
            // 
            // lblSucheModul
            // 
            this.lblSucheModul.Location = new System.Drawing.Point(30, 130);
            this.lblSucheModul.Name = "lblSucheModul";
            this.lblSucheModul.Size = new System.Drawing.Size(95, 24);
            this.lblSucheModul.TabIndex = 7;
            this.lblSucheModul.Text = "Modul";
            this.lblSucheModul.UseCompatibleTextRendering = true;
            // 
            // lblSucheTypBW
            // 
            this.lblSucheTypBW.Location = new System.Drawing.Point(400, 40);
            this.lblSucheTypBW.Name = "lblSucheTypBW";
            this.lblSucheTypBW.Size = new System.Drawing.Size(95, 24);
            this.lblSucheTypBW.TabIndex = 9;
            this.lblSucheTypBW.Text = "Typ BW";
            this.lblSucheTypBW.UseCompatibleTextRendering = true;
            // 
            // lblSucheTypED
            // 
            this.lblSucheTypED.Location = new System.Drawing.Point(400, 70);
            this.lblSucheTypED.Name = "lblSucheTypED";
            this.lblSucheTypED.Size = new System.Drawing.Size(95, 24);
            this.lblSucheTypED.TabIndex = 11;
            this.lblSucheTypED.Text = "Typ ED";
            this.lblSucheTypED.UseCompatibleTextRendering = true;
            // 
            // splitter
            // 
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.tabMitarbeiter;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 275);
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 4;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // CtlMitarbeiter
            // 
            this.ActiveSQLQuery = this.qryEdMitarbeiter;
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.btnVerfuegbarkeit);
            this.Controls.Add(this.btnEdMaBericht);
            this.Controls.Add(this.tabMitarbeiter);
            this.Name = "CtlMitarbeiter";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.Size = new System.Drawing.Size(988, 669);
            this.Load += new System.EventHandler(this.CtlMitarbeiter_Load);
            this.Controls.SetChildIndex(this.tabMitarbeiter, 0);
            this.Controls.SetChildIndex(this.btnEdMaBericht, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.btnVerfuegbarkeit, 0);
            this.Controls.SetChildIndex(this.splitter, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEdMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEdMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEdMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTypED.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTypED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNurAktive.Properties)).EndInit();
            this.tabMitarbeiter.ResumeLayout(false);
            this.tpgGrunddaten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissMitarbeiterButtonEditVorgesetzter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            this.grpFreieKapazitaet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersichertennummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPostfachOhneNummer.Properties)).EndInit();
            this.grpModulAktiv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissButtonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenIsBwMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenEdAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenBwAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenIsEdMitarbeiter.Properties)).EndInit();
            this.grpGrunddatenTypBW.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenTypBW)).EndInit();
            this.grpGrunddatenTypED.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenTypED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenGeschlecht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenGeburtsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAustrittsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAustrittsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenEintrittsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenEintrittsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenPersonalNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenPersonalNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenTelefonMobil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenTelefonMobil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdresseLand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdresseLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdresseLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdresseBezirk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdresseBezirk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdresseKt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdresseOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdressePLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdressePLZOrtKt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdressePostfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdressePostfach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdresseNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdresseStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdresseStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenAdresseZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenAdresseZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrunddatenName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrunddatenName)).EndInit();
            this.tpgZusatzdaten.ResumeLayout(false);
            this.grpGrunddatenAusbildungTaetigkeit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenlTaetigkeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbZusatzdatenlTaetigkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenAusbildung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenStrafregisterauszugBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenStrafregisterauszugBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenStrafregisterauszug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenStrafregisterauszug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTabStopBug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenAufenthaltsbewilligung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenAufenthaltsbewilligung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenAufenthaltsbewilligung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenNationalitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenWeitereSprachen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenWeitereSprachen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenSprache.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenSprache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenSprache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenAnzahlKinder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenAnzahlKinder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenZivilstand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzdatenZivilstand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzdatenZivilstand)).EndInit();
            this.tpgInterview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtInterviewBeurteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInterviewBeurteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInterviewZusammenfassung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInterviewZusammenfassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInterviewInterviewer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInterviewInterviewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInterviewDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInterviewDatum)).EndInit();
            this.tpgWeiterbildung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEdMitarbeiterKurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKurs)).EndInit();
            this.panWeiterbildungDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtWeiterbildungBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeiterbildungBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeiterbildungDispensiert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeiterbildungAbsolviert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeiterbildungAbsolviert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeiterbildungZuAbsolvierenBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeiterbildungZuAbsolvierenBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeiterbildungKurs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWeiterbildungKurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeiterbildungKurs)).EndInit();
            this.tpgPersoenlichkeit.ResumeLayout(false);
            this.tblPersoenlichkeit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtPersoenlichkeitErfahrungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersoenlichkeitErfahrungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersoenlichkeitErfahrungenNachAltersklassen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersoenlichkeitVorlieben)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersoenlichkeitPersoenlichkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersoenlichkeitGesundheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersoenlichkeitGesundheit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersoenlichkeitErfahrungenNachAltersklassen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersoenlichkeitVorlieben.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersoenlichkeitPersoenlichkeit.Properties)).EndInit();
            this.tpgKenntnisse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseWeitereKenntnisse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseWeitereKenntnisse)).EndInit();
            this.grpKenntnisseHilfetechniken.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseKommunikation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseKommunikation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseTransporte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseTransporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseHilfsmittel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseHilfsmittel)).EndInit();
            this.grpKenntnissePsychischeBehinderung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseSelbstFremdaggression.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseSelbstFremdaggression)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseVerhaltensstoerung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseVerhaltensstoerung)).EndInit();
            this.grpKenntnisseGeistigeBehinderung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtGeistigeBehinderung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseGeistigeBehinderung)).EndInit();
            this.grpKenntnisseKoerperlicheBehinderung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseEpilepsie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseEpilepsie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseGehirnschaedigung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseGehirnschaedigung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseIMC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseIMC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKenntnisseMehrfachbehinderung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKenntnisseMehrfachbehinderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheModul.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTypBW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTypBW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTypBW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTypED)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Dokument.KissDocumentButton btnEdMaBericht;
        private KiSS4.Gui.KissButton btnVerfuegbarkeit;
        private KiSS4.Gui.KissCheckEdit chkTabStopBug;
        private DevExpress.XtraGrid.Columns.GridColumn colAdresse;
        private DevExpress.XtraGrid.Columns.GridColumn colAktivBw;
        private DevExpress.XtraGrid.Columns.GridColumn colAktivEd;
        private DevExpress.XtraGrid.Columns.GridColumn colAnrede;
        private DevExpress.XtraGrid.Columns.GridColumn colBezirk;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colIsBw;
        private DevExpress.XtraGrid.Columns.GridColumn colIsEd;
        private DevExpress.XtraGrid.Columns.GridColumn colKurseZuAbsolvieren;
        private DevExpress.XtraGrid.Columns.GridColumn colLand;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefon;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefonMobil;
        private DevExpress.XtraGrid.Columns.GridColumn colTypBW;
        private DevExpress.XtraGrid.Columns.GridColumn colTypED;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colWeiterbildungAbsolviert;
        private DevExpress.XtraGrid.Columns.GridColumn colWeiterbildungBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colWeiterbildungDispensiert;
        private DevExpress.XtraGrid.Columns.GridColumn colWeiterbildungFrist;
        private DevExpress.XtraGrid.Columns.GridColumn colWeiterbildungKurs;
        private DevExpress.XtraGrid.Columns.GridColumn colZusatz;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissTextEdit edtGeistigeBehinderung;
        private KiSS4.Gui.KissTextEdit edtGrunddatenAdresseBezirk;
        private KiSS4.Gui.KissTextEdit edtGrunddatenAdresseKt;
        private KiSS4.Gui.KissLookUpEdit edtGrunddatenAdresseLand;
        private KiSS4.Gui.KissTextEdit edtGrunddatenAdresseNr;
        private KiSS4.Gui.KissTextEdit edtGrunddatenAdresseOrt;
        private KiSS4.Gui.KissTextEdit edtGrunddatenAdressePLZ;
        private KiSS4.Gui.KissTextEdit edtGrunddatenAdressePostfach;
        private KiSS4.Gui.KissTextEdit edtGrunddatenAdresseStrasse;
        private KiSS4.Gui.KissTextEdit edtGrunddatenAdresseZusatz;
        private KiSS4.Gui.KissDateEdit edtGrunddatenAustrittsdatum;
        private KiSS4.Gui.KissCheckEdit edtGrunddatenBwAktiv;
        private KiSS4.Gui.KissCheckEdit edtGrunddatenEdAktiv;
        private KiSS4.Gui.KissDateEdit edtGrunddatenEintrittsdatum;
        private KiSS4.Gui.KissTextEdit edtGrunddatenEmail;
        private KiSS4.Gui.KissTextEdit edtGrunddatenFax;
        private KiSS4.Gui.KissDateEdit edtGrunddatenGeburtsdatum;
        private KiSS4.Gui.KissLookUpEdit edtGrunddatenGeschlecht;
        private KiSS4.Gui.KissCheckEdit edtGrunddatenIsBwMitarbeiter;
        private KiSS4.Gui.KissCheckEdit edtGrunddatenIsEdMitarbeiter;
        private KiSS4.Gui.KissButtonEdit edtGrunddatenName;
        private KiSS4.Gui.KissCalcEdit edtGrunddatenPersonalNr;
        private KiSS4.Gui.KissTextEdit edtGrunddatenTelefon;
        private KiSS4.Gui.KissTextEdit edtGrunddatenTelefonMobil;
        private KiSS4.Gui.KissCheckedLookupEdit edtGrunddatenTypBW;
        private KiSS4.Gui.KissCheckedLookupEdit edtGrunddatenTypED;
        private KiSS4.Gui.KissMemoEdit edtInterviewBeurteilung;
        private KiSS4.Gui.KissDateEdit edtInterviewDatum;
        private KiSS4.Gui.KissButtonEdit edtInterviewInterviewer;
        private KiSS4.Gui.KissMemoEdit edtInterviewZusammenfassung;
        private KiSS4.Gui.KissTextEdit edtKenntnisseEpilepsie;
        private KiSS4.Gui.KissTextEdit edtKenntnisseGehirnschaedigung;
        private KiSS4.Gui.KissTextEdit edtKenntnisseHilfsmittel;
        private KiSS4.Gui.KissTextEdit edtKenntnisseIMC;
        private KiSS4.Gui.KissTextEdit edtKenntnisseKommunikation;
        private KiSS4.Gui.KissTextEdit edtKenntnisseMehrfachbehinderung;
        private KiSS4.Gui.KissTextEdit edtKenntnisseSelbstFremdaggression;
        private KiSS4.Gui.KissTextEdit edtKenntnisseTransporte;
        private KiSS4.Gui.KissTextEdit edtKenntnisseVerhaltensstoerung;
        private KiSS4.Gui.KissMemoEdit edtKenntnisseWeitereKenntnisse;
        private KiSS4.Gui.KissMemoEdit edtPersoenlichkeitErfahrungen;
        private KiSS4.Gui.KissMemoEdit edtPersoenlichkeitErfahrungenNachAltersklassen;
        private KiSS4.Gui.KissMemoEdit edtPersoenlichkeitGesundheit;
        private KiSS4.Gui.KissMemoEdit edtPersoenlichkeitPersoenlichkeit;
        private KiSS4.Gui.KissMemoEdit edtPersoenlichkeitVorlieben;
        private KiSS4.Gui.KissLookUpEdit edtSucheModul;
        private KiSS4.Gui.KissTextEdit edtSucheName;
        private KiSS4.Gui.KissCheckEdit edtSucheNurAktive;
        private KiSS4.Gui.KissTextEdit edtSucheOrt;
        private KiSS4.Gui.KissLookUpEdit edtSucheTypBW;
        private KiSS4.Gui.KissLookUpEdit edtSucheTypED;
        private KiSS4.Gui.KissTextEdit edtSucheVorname;
        private KiSS4.Gui.KissDateEdit edtWeiterbildungAbsolviert;
        private KiSS4.Gui.KissMemoEdit edtWeiterbildungBemerkungen;
        private KiSS4.Gui.KissCheckEdit edtWeiterbildungDispensiert;
        private KiSS4.Gui.KissLookUpEdit edtWeiterbildungKurs;
        private KiSS4.Gui.KissDateEdit edtWeiterbildungZuAbsolvierenBis;
        private KiSS4.Gui.KissCalcEdit edtZusatzdatenAnzahlKinder;
        private KiSS4.Gui.KissLookUpEdit edtZusatzdatenAufenthaltsbewilligung;
        private KiSS4.Gui.KissMemoEdit edtZusatzdatenAusbildung;
        private KiSS4.Gui.KissLookUpEdit edtZusatzdatenNationalitaet;
        private KiSS4.Gui.KissLookUpEdit edtZusatzdatenSprache;
        private KiSS4.Gui.KissDateEdit edtZusatzdatenStrafregisterauszug;
        private KiSS4.Gui.KissTextEdit edtZusatzdatenStrafregisterauszugBemerkungen;
        private KiSS4.Gui.KissTextEdit edtZusatzdatenWeitereSprachen;
        private KiSS4.Gui.KissLookUpEdit edtZusatzdatenZivilstand;
        private KiSS4.Gui.KissMemoEdit edtZusatzdatenlTaetigkeit;
        private KiSS4.Gui.KissGrid grdEdMitarbeiter;
        private KiSS4.Gui.KissGrid grdKurs;
        private KiSS4.Gui.KissGroupBox grpGrunddatenAusbildungTaetigkeit;
        private KiSS4.Gui.KissGroupBox grpGrunddatenTypBW;
        private KiSS4.Gui.KissGroupBox grpGrunddatenTypED;
        private KiSS4.Gui.KissGroupBox grpKenntnisseGeistigeBehinderung;
        private KiSS4.Gui.KissGroupBox grpKenntnisseHilfetechniken;
        private KiSS4.Gui.KissGroupBox grpKenntnisseKoerperlicheBehinderung;
        private KiSS4.Gui.KissGroupBox grpKenntnissePsychischeBehinderung;
        private KiSS4.Gui.KissGroupBox grpModulAktiv;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEdMitarbeiter;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKurs;
        private KiSS4.Gui.KissLabel lbZusatzdatenlTaetigkeit;
        private KiSS4.Gui.KissLabel lblGrunddatenAdresseBezirk;
        private KiSS4.Gui.KissLabel lblGrunddatenAdresseLand;
        private KiSS4.Gui.KissLabel lblGrunddatenAdressePLZOrtKt;
        private KiSS4.Gui.KissLabel lblGrunddatenAdressePostfach;
        private KiSS4.Gui.KissLabel lblGrunddatenAdresseStrasseNr;
        private KiSS4.Gui.KissLabel lblGrunddatenAdresseZusatz;
        private KiSS4.Gui.KissLabel lblGrunddatenAustrittsdatum;
        private KiSS4.Gui.KissLabel lblGrunddatenEintrittsdatum;
        private KiSS4.Gui.KissLabel lblGrunddatenEmail;
        private KiSS4.Gui.KissLabel lblGrunddatenFax;
        private KiSS4.Gui.KissLabel lblGrunddatenGeburtsdatum;
        private KiSS4.Gui.KissLabel lblGrunddatenGeschlecht;
        private KiSS4.Gui.KissLabel lblGrunddatenName;
        private KiSS4.Gui.KissLabel lblGrunddatenPersonalNr;
        private KiSS4.Gui.KissLabel lblGrunddatenTelefon;
        private KiSS4.Gui.KissLabel lblGrunddatenTelefonMobil;
        private KiSS4.Gui.KissLabel lblInterviewBeurteilung;
        private KiSS4.Gui.KissLabel lblInterviewDatum;
        private KiSS4.Gui.KissLabel lblInterviewInterviewer;
        private KiSS4.Gui.KissLabel lblInterviewZusammenfassung;
        private KiSS4.Gui.KissLabel lblKenntnisseEpilepsie;
        private KiSS4.Gui.KissLabel lblKenntnisseGehirnschaedigung;
        private KiSS4.Gui.KissLabel lblKenntnisseGeistigeBehinderung;
        private KiSS4.Gui.KissLabel lblKenntnisseHilfsmittel;
        private KiSS4.Gui.KissLabel lblKenntnisseIMC;
        private KiSS4.Gui.KissLabel lblKenntnisseKommunikation;
        private KiSS4.Gui.KissLabel lblKenntnisseMehrfachbehinderung;
        private KiSS4.Gui.KissLabel lblKenntnisseSelbstFremdaggression;
        private KiSS4.Gui.KissLabel lblKenntnisseTransporte;
        private KiSS4.Gui.KissLabel lblKenntnisseVerhaltensstoerung;
        private KiSS4.Gui.KissLabel lblKenntnisseWeitereKenntnisse;
        private KiSS4.Gui.KissLabel lblPersoenlichkeitErfahrungen;
        private KiSS4.Gui.KissLabel lblPersoenlichkeitErfahrungenNachAltersklassen;
        private KiSS4.Gui.KissLabel lblPersoenlichkeitGesundheit;
        private KiSS4.Gui.KissLabel lblPersoenlichkeitPersoenlichkeit;
        private KiSS4.Gui.KissLabel lblPersoenlichkeitVorlieben;
        private KiSS4.Gui.KissLabel lblSucheModul;
        private KiSS4.Gui.KissLabel lblSucheName;
        private KiSS4.Gui.KissLabel lblSucheOrt;
        private KiSS4.Gui.KissLabel lblSucheTypBW;
        private KiSS4.Gui.KissLabel lblSucheTypED;
        private KiSS4.Gui.KissLabel lblSucheVorname;
        private KiSS4.Gui.KissLabel lblWeiterbildungAbsolviert;
        private KiSS4.Gui.KissLabel lblWeiterbildungBemerkungen;
        private KiSS4.Gui.KissLabel lblWeiterbildungKurs;
        private KiSS4.Gui.KissLabel lblWeiterbildungZuAbsolvierenBis;
        private KiSS4.Gui.KissLabel lblZusatzdatenAnzahlKinder;
        private KiSS4.Gui.KissLabel lblZusatzdatenAufenthaltsbewilligung;
        private KiSS4.Gui.KissLabel lblZusatzdatenAusbildung;
        private KiSS4.Gui.KissLabel lblZusatzdatenNationalitaet;
        private KiSS4.Gui.KissLabel lblZusatzdatenSprache;
        private KiSS4.Gui.KissLabel lblZusatzdatenStrafregisterauszug;
        private KiSS4.Gui.KissLabel lblZusatzdatenStrafregisterauszugBemerkungen;
        private KiSS4.Gui.KissLabel lblZusatzdatenWeitereSprachen;
        private KiSS4.Gui.KissLabel lblZusatzdatenZivilstand;
        private System.Windows.Forms.Panel panWeiterbildungDetails;
        private KiSS4.DB.SqlQuery qryEdMitarbeiter;
        private KiSS4.DB.SqlQuery qryEdMitarbeiterKurs;
        private KiSS4.Gui.KissTabControlEx tabMitarbeiter;
        private SharpLibrary.WinControls.TabPageEx tpgGrunddaten;
        private SharpLibrary.WinControls.TabPageEx tpgInterview;
        private SharpLibrary.WinControls.TabPageEx tpgKenntnisse;
        private SharpLibrary.WinControls.TabPageEx tpgPersoenlichkeit;
        private SharpLibrary.WinControls.TabPageEx tpgWeiterbildung;
        private KiSS4.Gui.KissCheckEdit chkPostfachOhneNummer;
        private SharpLibrary.WinControls.TabPageEx tpgZusatzdaten;
        private Gui.KissSplitterCollapsible splitter;
        private Gui.KissGroupBox grpFreieKapazitaet;
        private Gui.KissLabel lblVersichertennummer;
        private Gui.KissVersichertenNrEdit edtVersichertennummer;
        private Gui.KissMemoEdit kissMemoEdit1;
        private System.Windows.Forms.TableLayoutPanel tblPersoenlichkeit;
        private Gui.KissLabel kissLabel1;
        private Gui.KissButtonEdit kissButtonEdit1;
        private KissMitarbeiterButtonEdit kissMitarbeiterButtonEditVorgesetzter;
    }
}
