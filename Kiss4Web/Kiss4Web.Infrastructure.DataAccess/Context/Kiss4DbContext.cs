using Kiss4Web.Model;
using Microsoft.EntityFrameworkCore;

namespace Kiss4Web.Infrastructure.DataAccess.Context
{
    public partial class Kiss4DbContext : DbContext
    {
        protected Kiss4DbContext()
        {
        }
        #region DbSets

        public virtual DbSet<BaAdresse> BaAdresse { get; set; }
        public virtual DbSet<BaArbeit> BaArbeit { get; set; }
        public virtual DbSet<BaArbeitAusbildung> BaArbeitAusbildung { get; set; }
        public virtual DbSet<BaBank> BaBank { get; set; }
        public virtual DbSet<BaBeruf> BaBeruf { get; set; }
        public virtual DbSet<BaEinwohnerregisterEmpfangeneEreignisse> BaEinwohnerregisterEmpfangeneEreignisse { get; set; }
        public virtual DbSet<BaEinwohnerregisterEmpfangeneEreignisseRohdaten> BaEinwohnerregisterEmpfangeneEreignisseRohdaten { get; set; }
        public virtual DbSet<BaEinwohnerregisterPersonAnAbmeldung> BaEinwohnerregisterPersonAnAbmeldung { get; set; }
        public virtual DbSet<BaEinwohnerregisterPersonStatus> BaEinwohnerregisterPersonStatus { get; set; }
        public virtual DbSet<BaGemeinde> BaGemeinde { get; set; }
        public virtual DbSet<BaGesundheit> BaGesundheit { get; set; }
        public virtual DbSet<BaInstitution> BaInstitution { get; set; }
        public virtual DbSet<BaInstitutionBaInstitutionTyp> BaInstitutionBaInstitutionTyp { get; set; }
        public virtual DbSet<BaInstitutionDokument> BaInstitutionDokument { get; set; }
        public virtual DbSet<BaInstitutionKontakt> BaInstitutionKontakt { get; set; }
        public virtual DbSet<BaInstitutionTyp> BaInstitutionTyp { get; set; }
        public virtual DbSet<BaKantonalerZuschuss> BaKantonalerZuschuss { get; set; }
        public virtual DbSet<BaKopfquote> BaKopfquote { get; set; }
        public virtual DbSet<BaLand> BaLand { get; set; }
        public virtual DbSet<BaMietvertrag> BaMietvertrag { get; set; }
        public virtual DbSet<BaPerson> BaPerson { get; set; }
        public virtual DbSet<BaPersonBaInstitution> BaPersonBaInstitution { get; set; }
        public virtual DbSet<BaPersonKantonalerZuschuss> BaPersonKantonalerZuschuss { get; set; }
        public virtual DbSet<BaPersonRelation> BaPersonRelation { get; set; }
        public virtual DbSet<BaPlz> BaPlz { get; set; }
        public virtual DbSet<BaPraemienverbilligung> BaPraemienverbilligung { get; set; }
        public virtual DbSet<BaRelation> BaRelation { get; set; }
        public virtual DbSet<BaWvcode> BaWvcode { get; set; }
        public virtual DbSet<BaZahlungsweg> BaZahlungsweg { get; set; }
        public virtual DbSet<BdeausbezahlteUeberstundenXuser> BdeausbezahlteUeberstundenXuser { get; set; }
        public virtual DbSet<BdeferienanspruchXuser> BdeferienanspruchXuser { get; set; }
        public virtual DbSet<BdeferienkuerzungenXuser> BdeferienkuerzungenXuser { get; set; }
        public virtual DbSet<Bdeleistung> Bdeleistung { get; set; }
        public virtual DbSet<Bdeleistungsart> Bdeleistungsart { get; set; }
        public virtual DbSet<BdepensumXuser> BdepensumXuser { get; set; }
        public virtual DbSet<BdesollProTagXuser> BdesollProTagXuser { get; set; }
        public virtual DbSet<BdesollStundenProJahrXuser> BdesollStundenProJahrXuser { get; set; }
        public virtual DbSet<BdeuserGroup> BdeuserGroup { get; set; }
        public virtual DbSet<BdeuserGroupBdeleistungsart> BdeuserGroupBdeleistungsart { get; set; }
        public virtual DbSet<Bdezeitrechner> Bdezeitrechner { get; set; }
        public virtual DbSet<Bfsdossier> Bfsdossier { get; set; }
        public virtual DbSet<BfsdossierPerson> BfsdossierPerson { get; set; }
        public virtual DbSet<BfsfarbCode> BfsfarbCode { get; set; }
        public virtual DbSet<Bfsfrage> Bfsfrage { get; set; }
        public virtual DbSet<BfskatalogVersion> BfskatalogVersion { get; set; }
        public virtual DbSet<Bfslov> Bfslov { get; set; }
        public virtual DbSet<Bfslovcode> Bfslovcode { get; set; }
        public virtual DbSet<Bfswert> Bfswert { get; set; }
        public virtual DbSet<BgAuszahlungPerson> BgAuszahlungPerson { get; set; }
        public virtual DbSet<BgAuszahlungPersonTermin> BgAuszahlungPersonTermin { get; set; }
        public virtual DbSet<BgBewilligung> BgBewilligung { get; set; }
        public virtual DbSet<BgBudget> BgBudget { get; set; }
        public virtual DbSet<BgDokument> BgDokument { get; set; }
        public virtual DbSet<BgFinanzplan> BgFinanzplan { get; set; }
        public virtual DbSet<BgFinanzplanBaPerson> BgFinanzplanBaPerson { get; set; }
        public virtual DbSet<BgGruppeBfsfrage> BgGruppeBfsfrage { get; set; }
        public virtual DbSet<BgKostenart> BgKostenart { get; set; }
        public virtual DbSet<BgKostenartWhGefKategorie> BgKostenartWhGefKategorie { get; set; }
        public virtual DbSet<BgPosition> BgPosition { get; set; }
        public virtual DbSet<BgPositionsart> BgPositionsart { get; set; }
        public virtual DbSet<BgPositionsartBuchungstext> BgPositionsartBuchungstext { get; set; }
        public virtual DbSet<BgSpezkonto> BgSpezkonto { get; set; }
        public virtual DbSet<BgSpezkontoAbschluss> BgSpezkontoAbschluss { get; set; }
        public virtual DbSet<BgZahlungsmodus> BgZahlungsmodus { get; set; }
        public virtual DbSet<BgZahlungsmodusTermin> BgZahlungsmodusTermin { get; set; }
        public virtual DbSet<DynaField> DynaField { get; set; }
        public virtual DbSet<DynaMask> DynaMask { get; set; }
        public virtual DbSet<DynaValue> DynaValue { get; set; }
        public virtual DbSet<FaAktennotizen> FaAktennotizen { get; set; }
        public virtual DbSet<FaDokumentAblage> FaDokumentAblage { get; set; }
        public virtual DbSet<FaDokumentAblageBaPerson> FaDokumentAblageBaPerson { get; set; }
        public virtual DbSet<FaDokumente> FaDokumente { get; set; }
        public virtual DbSet<FaKategorisierung> FaKategorisierung { get; set; }
        public virtual DbSet<FaKategorisierungEksProdukt> FaKategorisierungEksProdukt { get; set; }
        public virtual DbSet<FaLeistung> FaLeistung { get; set; }
        public virtual DbSet<FaLeistungArchiv> FaLeistungArchiv { get; set; }
        public virtual DbSet<FaLeistungBewertung> FaLeistungBewertung { get; set; }
        public virtual DbSet<FaLeistungUserHist> FaLeistungUserHist { get; set; }
        public virtual DbSet<FaLeistungZugriff> FaLeistungZugriff { get; set; }
        public virtual DbSet<FaPendenzgruppe> FaPendenzgruppe { get; set; }
        public virtual DbSet<FaPendenzgruppeUser> FaPendenzgruppeUser { get; set; }
        public virtual DbSet<FaPhase> FaPhase { get; set; }
        public virtual DbSet<FaRelation> FaRelation { get; set; }
        public virtual DbSet<FaWeisung> FaWeisung { get; set; }
        public virtual DbSet<FaWeisungBaPerson> FaWeisungBaPerson { get; set; }
        public virtual DbSet<FaWeisungProtokoll> FaWeisungProtokoll { get; set; }
        public virtual DbSet<FaWeisungWorkflow> FaWeisungWorkflow { get; set; }
        public virtual DbSet<FaZeitlichePlanung> FaZeitlichePlanung { get; set; }
        public virtual DbSet<FbBarauszahlungAuftrag> FbBarauszahlungAuftrag { get; set; }
        public virtual DbSet<FbBarauszahlungAusbezahlt> FbBarauszahlungAusbezahlt { get; set; }
        public virtual DbSet<FbBarauszahlungZyklus> FbBarauszahlungZyklus { get; set; }
        public virtual DbSet<FbBelegNr> FbBelegNr { get; set; }
        public virtual DbSet<FbBuchung> FbBuchung { get; set; }
        public virtual DbSet<FbBuchungCode> FbBuchungCode { get; set; }
        public virtual DbSet<FbBuchungskreis> FbBuchungskreis { get; set; }
        public virtual DbSet<FbDauerauftrag> FbDauerauftrag { get; set; }
        public virtual DbSet<FbDtabuchung> FbDtabuchung { get; set; }
        public virtual DbSet<FbDtajournal> FbDtajournal { get; set; }
        public virtual DbSet<FbDtazugang> FbDtazugang { get; set; }
        public virtual DbSet<FbKonto> FbKonto { get; set; }
        public virtual DbSet<FbKreditor> FbKreditor { get; set; }
        public virtual DbSet<FbPeriode> FbPeriode { get; set; }
        public virtual DbSet<FbTeam> FbTeam { get; set; }
        public virtual DbSet<FbTeamMitglied> FbTeamMitglied { get; set; }
        public virtual DbSet<FbZahlungsweg> FbZahlungsweg { get; set; }
        public virtual DbSet<FsDienstleistung> FsDienstleistung { get; set; }
        public virtual DbSet<FsDienstleistungFsDienstleistungspaket> FsDienstleistungFsDienstleistungspaket { get; set; }
        public virtual DbSet<FsDienstleistungspaket> FsDienstleistungspaket { get; set; }
        public virtual DbSet<FsReduktion> FsReduktion { get; set; }
        public virtual DbSet<FsReduktionMitarbeiter> FsReduktionMitarbeiter { get; set; }
        public virtual DbSet<GvAbklaerendeStelle> GvAbklaerendeStelle { get; set; }
        public virtual DbSet<GvAntragPosition> GvAntragPosition { get; set; }
        public virtual DbSet<GvAuflage> GvAuflage { get; set; }
        public virtual DbSet<GvAuszahlungPosition> GvAuszahlungPosition { get; set; }
        public virtual DbSet<GvAuszahlungPositionValuta> GvAuszahlungPositionValuta { get; set; }
        public virtual DbSet<GvBewilligung> GvBewilligung { get; set; }
        public virtual DbSet<GvDocument> GvDocument { get; set; }
        public virtual DbSet<GvDokumenteInformation> GvDokumenteInformation { get; set; }
        public virtual DbSet<GvFonds> GvFonds { get; set; }
        public virtual DbSet<GvFondsXorgUnit> GvFondsXorgUnit { get; set; }
        public virtual DbSet<GvGesuch> GvGesuch { get; set; }
        public virtual DbSet<GvPositionsart> GvPositionsart { get; set; }
        public virtual DbSet<HistBaAdresse> HistBaAdresse { get; set; }
        public virtual DbSet<HistBaPerson> HistBaPerson { get; set; }
        public virtual DbSet<HistBdeferienkuerzungenXuser> HistBdeferienkuerzungenXuser { get; set; }
        public virtual DbSet<HistBdeleistung> HistBdeleistung { get; set; }
        public virtual DbSet<HistBdeleistungsart> HistBdeleistungsart { get; set; }
        public virtual DbSet<HistBdesollStundenProJahrXuser> HistBdesollStundenProJahrXuser { get; set; }
        public virtual DbSet<HistoryVersion> HistoryVersion { get; set; }
        public virtual DbSet<HistXorgUnit> HistXorgUnit { get; set; }
        public virtual DbSet<HistXorgUnitUser> HistXorgUnitUser { get; set; }
        public virtual DbSet<HistXuser> HistXuser { get; set; }
        public virtual DbSet<HistXuserStundenansatz> HistXuserStundenansatz { get; set; }
        public virtual DbSet<IkAbklaerung> IkAbklaerung { get; set; }
        public virtual DbSet<IkAnzeige> IkAnzeige { get; set; }
        public virtual DbSet<IkBetreibung> IkBetreibung { get; set; }
        public virtual DbSet<IkBetreibungAusgleich> IkBetreibungAusgleich { get; set; }
        public virtual DbSet<IkEinkommen> IkEinkommen { get; set; }
        public virtual DbSet<IkForderung> IkForderung { get; set; }
        public virtual DbSet<IkForderungBgKostenart> IkForderungBgKostenart { get; set; }
        public virtual DbSet<IkForderungBgKostenartHist> IkForderungBgKostenartHist { get; set; }
        public virtual DbSet<IkForderungPosition> IkForderungPosition { get; set; }
        public virtual DbSet<IkGlaeubiger> IkGlaeubiger { get; set; }
        public virtual DbSet<IkLandesindex> IkLandesindex { get; set; }
        public virtual DbSet<IkLandesindexWert> IkLandesindexWert { get; set; }
        public virtual DbSet<IkPosition> IkPosition { get; set; }
        public virtual DbSet<IkRatenplan> IkRatenplan { get; set; }
        public virtual DbSet<IkRatenplanForderung> IkRatenplanForderung { get; set; }
        public virtual DbSet<IkRechtstitel> IkRechtstitel { get; set; }
        public virtual DbSet<IkVerrechnungskonto> IkVerrechnungskonto { get; set; }
        public virtual DbSet<KaAbklaerungIntake> KaAbklaerungIntake { get; set; }
        public virtual DbSet<KaAbklaerungVertieft> KaAbklaerungVertieft { get; set; }
        public virtual DbSet<KaAbklaerungVertieftProbeeinsatz> KaAbklaerungVertieftProbeeinsatz { get; set; }
        public virtual DbSet<KaAkzuweiser> KaAkzuweiser { get; set; }
        public virtual DbSet<KaAllgemein> KaAllgemein { get; set; }
        public virtual DbSet<KaAmmBesch> KaAmmBesch { get; set; }
        public virtual DbSet<KaArbeitsrapport> KaArbeitsrapport { get; set; }
        public virtual DbSet<KaAssistenz> KaAssistenz { get; set; }
        public virtual DbSet<KaAusbildung> KaAusbildung { get; set; }
        public virtual DbSet<KaBetrieb> KaBetrieb { get; set; }
        public virtual DbSet<KaBetriebBesprechung> KaBetriebBesprechung { get; set; }
        public virtual DbSet<KaBetriebDokument> KaBetriebDokument { get; set; }
        public virtual DbSet<KaBetriebKontakt> KaBetriebKontakt { get; set; }
        public virtual DbSet<KaEafSozioberuflicheBilanz> KaEafSozioberuflicheBilanz { get; set; }
        public virtual DbSet<KaEafSpezifischeErmittlung> KaEafSpezifischeErmittlung { get; set; }
        public virtual DbSet<KaEinsatz> KaEinsatz { get; set; }
        public virtual DbSet<KaEinsatzplatz> KaEinsatzplatz { get; set; }
        public virtual DbSet<KaEinsatzplatz2> KaEinsatzplatz2 { get; set; }
        public virtual DbSet<KaExterneBildung> KaExterneBildung { get; set; }
        public virtual DbSet<KaExterneBildungZahlung> KaExterneBildungZahlung { get; set; }
        public virtual DbSet<KaInizio> KaInizio { get; set; }
        public virtual DbSet<KaIntegBildung> KaIntegBildung { get; set; }
        public virtual DbSet<KaJobtimal> KaJobtimal { get; set; }
        public virtual DbSet<KaJobtimalVertrag> KaJobtimalVertrag { get; set; }
        public virtual DbSet<KaKontaktartProzess> KaKontaktartProzess { get; set; }
        public virtual DbSet<KaKurs> KaKurs { get; set; }
        public virtual DbSet<KaKurserfassung> KaKurserfassung { get; set; }
        public virtual DbSet<KaQeepq> KaQeepq { get; set; }
        public virtual DbSet<KaQeepqzielvereinb> KaQeepqzielvereinb { get; set; }
        public virtual DbSet<KaQeepqzielvereinbVerl> KaQeepqzielvereinbVerl { get; set; }
        public virtual DbSet<KaQejobtimum> KaQejobtimum { get; set; }
        public virtual DbSet<KaQjbildung> KaQjbildung { get; set; }
        public virtual DbSet<KaQjintake> KaQjintake { get; set; }
        public virtual DbSet<KaQjintakeGespraech> KaQjintakeGespraech { get; set; }
        public virtual DbSet<KaQjprozess> KaQjprozess { get; set; }
        public virtual DbSet<KaQjpzassessment> KaQjpzassessment { get; set; }
        public virtual DbSet<KaQjpzbericht> KaQjpzbericht { get; set; }
        public virtual DbSet<KaQjpzschlussbericht> KaQjpzschlussbericht { get; set; }
        public virtual DbSet<KaQjpzzielvereinbarung> KaQjpzzielvereinbarung { get; set; }
        public virtual DbSet<KaQjvereinbarung> KaQjvereinbarung { get; set; }
        public virtual DbSet<KaSequenzen> KaSequenzen { get; set; }
        public virtual DbSet<KaTransfer> KaTransfer { get; set; }
        public virtual DbSet<KaTransferZielvereinb> KaTransferZielvereinb { get; set; }
        public virtual DbSet<KaVerlauf> KaVerlauf { get; set; }
        public virtual DbSet<KaVermittlungBibip> KaVermittlungBibip { get; set; }
        public virtual DbSet<KaVermittlungEinsatz> KaVermittlungEinsatz { get; set; }
        public virtual DbSet<KaVermittlungProfil> KaVermittlungProfil { get; set; }
        public virtual DbSet<KaVermittlungSi> KaVermittlungSi { get; set; }
        public virtual DbSet<KaVermittlungSizwischenbericht> KaVermittlungSizwischenbericht { get; set; }
        public virtual DbSet<KaVermittlungVorschlag> KaVermittlungVorschlag { get; set; }
        public virtual DbSet<KaZuteilFachbereich> KaZuteilFachbereich { get; set; }
        public virtual DbSet<KbBelegKreis> KbBelegKreis { get; set; }
        public virtual DbSet<KbBuchung> KbBuchung { get; set; }
        public virtual DbSet<KbBuchungKostenart> KbBuchungKostenart { get; set; }
        public virtual DbSet<KbForderungAuszahlung> KbForderungAuszahlung { get; set; }
        public virtual DbSet<KbFreieBelegNummer> KbFreieBelegNummer { get; set; }
        public virtual DbSet<KbKonto> KbKonto { get; set; }
        public virtual DbSet<KbKostenstelle> KbKostenstelle { get; set; }
        public virtual DbSet<KbKostenstelleBaPerson> KbKostenstelleBaPerson { get; set; }
        public virtual DbSet<KbMandant> KbMandant { get; set; }
        public virtual DbSet<KbOpAusgleich> KbOpAusgleich { get; set; }
        public virtual DbSet<KbPeriode> KbPeriode { get; set; }
        public virtual DbSet<KbPeriodeUser> KbPeriodeUser { get; set; }
        public virtual DbSet<KbTransfer> KbTransfer { get; set; }
        public virtual DbSet<KbWveinzelposten> KbWveinzelposten { get; set; }
        public virtual DbSet<KbWveinzelpostenFehler> KbWveinzelpostenFehler { get; set; }
        public virtual DbSet<KbWvlauf> KbWvlauf { get; set; }
        public virtual DbSet<KbZahlungseingang> KbZahlungseingang { get; set; }
        public virtual DbSet<KbZahlungskonto> KbZahlungskonto { get; set; }
        public virtual DbSet<KbZahlungskontoXorgUnit> KbZahlungskontoXorgUnit { get; set; }
        public virtual DbSet<KbZahlungslauf> KbZahlungslauf { get; set; }
        public virtual DbSet<KbZahlungslaufValuta> KbZahlungslaufValuta { get; set; }
        public virtual DbSet<KesArtikel> KesArtikel { get; set; }
        public virtual DbSet<KesAuftrag> KesAuftrag { get; set; }
        public virtual DbSet<KesAuftragBaPerson> KesAuftragBaPerson { get; set; }
        public virtual DbSet<KesBehoerde> KesBehoerde { get; set; }
        public virtual DbSet<KesDokument> KesDokument { get; set; }
        public virtual DbSet<KesMandatsfuehrendePerson> KesMandatsfuehrendePerson { get; set; }
        public virtual DbSet<KesMassnahme> KesMassnahme { get; set; }
        public virtual DbSet<KesMassnahmeAuftrag> KesMassnahmeAuftrag { get; set; }
        public virtual DbSet<KesMassnahmeBericht> KesMassnahmeBericht { get; set; }
        public virtual DbSet<KesMassnahmeBss> KesMassnahmeBss { get; set; }
        public virtual DbSet<KesMassnahmeKesArtikel> KesMassnahmeKesArtikel { get; set; }
        public virtual DbSet<KesPflegekinderaufsicht> KesPflegekinderaufsicht { get; set; }
        public virtual DbSet<KesPraevention> KesPraevention { get; set; }
        public virtual DbSet<KesVerlauf> KesVerlauf { get; set; }
        public virtual DbSet<MigAssignment> MigAssignment { get; set; }
        public virtual DbSet<MigLog> MigLog { get; set; }
        public virtual DbSet<MigLookup> MigLookup { get; set; }
        public virtual DbSet<MigVmPriMaToBaInstitution> MigVmPriMaToBaInstitution { get; set; }
        public virtual DbSet<NewodPerson> NewodPerson { get; set; }
        public virtual DbSet<ServiceCall> ServiceCall { get; set; }
        public virtual DbSet<ServiceProcessError> ServiceProcessError { get; set; }
        public virtual DbSet<ServiceProcessErrorMessage> ServiceProcessErrorMessage { get; set; }
        public virtual DbSet<ShEinzelzahlung> ShEinzelzahlung { get; set; }
        public virtual DbSet<SstAsvsexport> SstAsvsexport { get; set; }
        public virtual DbSet<SstAsvsexportEintrag> SstAsvsexportEintrag { get; set; }
        public virtual DbSet<SstNewodMapping> SstNewodMapping { get; set; }
        public virtual DbSet<SstNewodMutation> SstNewodMutation { get; set; }
        public virtual DbSet<UserSession> UserSession { get; set; }
        public virtual DbSet<VmAhvmindestbeitrag> VmAhvmindestbeitrag { get; set; }
        public virtual DbSet<VmAntragEksk> VmAntragEksk { get; set; }
        public virtual DbSet<VmBericht> VmBericht { get; set; }
        public virtual DbSet<VmBeschwerdeAnfrage> VmBeschwerdeAnfrage { get; set; }
        public virtual DbSet<VmBewertung> VmBewertung { get; set; }
        public virtual DbSet<VmBudget> VmBudget { get; set; }
        public virtual DbSet<VmElkrankheitskosten> VmElkrankheitskosten { get; set; }
        public virtual DbSet<VmErbe> VmErbe { get; set; }
        public virtual DbSet<VmErblasser> VmErblasser { get; set; }
        public virtual DbSet<VmErbschaftsdienst> VmErbschaftsdienst { get; set; }
        public virtual DbSet<VmErnennung> VmErnennung { get; set; }
        public virtual DbSet<VmGefaehrdungsMeldung> VmGefaehrdungsMeldung { get; set; }
        public virtual DbSet<VmInventar> VmInventar { get; set; }
        public virtual DbSet<VmKlientenbudget> VmKlientenbudget { get; set; }
        public virtual DbSet<VmMandant> VmMandant { get; set; }
        public virtual DbSet<VmMandBericht> VmMandBericht { get; set; }
        public virtual DbSet<VmMassnahme> VmMassnahme { get; set; }
        public virtual DbSet<VmPosition> VmPosition { get; set; }
        public virtual DbSet<VmPositionsart> VmPositionsart { get; set; }
        public virtual DbSet<VmPriMa> VmPriMa { get; set; }
        public virtual DbSet<VmSachversicherung> VmSachversicherung { get; set; }
        public virtual DbSet<VmSchulden> VmSchulden { get; set; }
        public virtual DbSet<VmSiegelung> VmSiegelung { get; set; }
        public virtual DbSet<VmSituationsBericht> VmSituationsBericht { get; set; }
        public virtual DbSet<VmSozialversicherung> VmSozialversicherung { get; set; }
        public virtual DbSet<VmSteuern> VmSteuern { get; set; }
        public virtual DbSet<VmTestament> VmTestament { get; set; }
        public virtual DbSet<VmTestamentBescheinigung> VmTestamentBescheinigung { get; set; }
        public virtual DbSet<VmTestamentVerfuegung> VmTestamentVerfuegung { get; set; }
        public virtual DbSet<VmVaterschaft> VmVaterschaft { get; set; }
        public virtual DbSet<WhAsvseintrag> WhAsvseintrag { get; set; }
        public virtual DbSet<WhGefKategorie> WhGefKategorie { get; set; }
        public virtual DbSet<Xarchive> Xarchive { get; set; }
        public virtual DbSet<Xbookmark> Xbookmark { get; set; }
        public virtual DbSet<XClass> Xclass { get; set; }
        public virtual DbSet<XclassComponent> XclassComponent { get; set; }
        public virtual DbSet<XclassControl> XclassControl { get; set; }
        public virtual DbSet<XclassReference> XclassReference { get; set; }
        public virtual DbSet<XclassRule> XclassRule { get; set; }
        public virtual DbSet<XConfig> Xconfig { get; set; }
        public virtual DbSet<XdbserverVersion> XdbserverVersion { get; set; }
        public virtual DbSet<Xdbversion> Xdbversion { get; set; }
        public virtual DbSet<XdeleteRule> XdeleteRule { get; set; }
        public virtual DbSet<XdocContext> XdocContext { get; set; }
        public virtual DbSet<XdocContextTemplate> XdocContextTemplate { get; set; }
        public virtual DbSet<XdocContextType> XdocContextType { get; set; }
        public virtual DbSet<XDocTemplate> XdocTemplate { get; set; }
        public virtual DbSet<XDocument> Xdocument { get; set; }
        public virtual DbSet<Xhyperlink> Xhyperlink { get; set; }
        public virtual DbSet<XhyperlinkContext> XhyperlinkContext { get; set; }
        public virtual DbSet<XhyperlinkContextHyperlink> XhyperlinkContextHyperlink { get; set; }
        public virtual DbSet<Xicon> Xicon { get; set; }
        public virtual DbSet<XLangText> XlangText { get; set; }
        public virtual DbSet<Xlog> Xlog { get; set; }
        public virtual DbSet<Xlov> Xlov { get; set; }
        public virtual DbSet<XLovCode> Xlovcode { get; set; }
        public virtual DbSet<XmenuItem> XmenuItem { get; set; }
        public virtual DbSet<XMessage> Xmessage { get; set; }
        public virtual DbSet<XModul> Xmodul { get; set; }
        public virtual DbSet<XmodulTree> XmodulTree { get; set; }
        public virtual DbSet<XnamespaceExtension> XnamespaceExtension { get; set; }
        public virtual DbSet<XOrgUnit> XorgUnit { get; set; }
        public virtual DbSet<XOrgUnit_User> XorgUnitUser { get; set; }
        public virtual DbSet<XorgUnitXdocTemplate> XorgUnitXdocTemplate { get; set; }
        public virtual DbSet<XpermissionGroup> XpermissionGroup { get; set; }
        public virtual DbSet<XpermissionValue> XpermissionValue { get; set; }
        public virtual DbSet<Xprofile> Xprofile { get; set; }
        public virtual DbSet<XprofileTag> XprofileTag { get; set; }
        public virtual DbSet<XprofileXprofileTag> XprofileXprofileTag { get; set; }
        public virtual DbSet<Xquery> Xquery { get; set; }
        public virtual DbSet<XRight> Xright { get; set; }
        public virtual DbSet<Xrule> Xrule { get; set; }
        public virtual DbSet<XsearchControlTemplate> XsearchControlTemplate { get; set; }
        public virtual DbSet<XsearchControlTemplateField> XsearchControlTemplateField { get; set; }
        public virtual DbSet<Xtable> Xtable { get; set; }
        public virtual DbSet<XtableColumn> XtableColumn { get; set; }
        public virtual DbSet<XTask> Xtask { get; set; }
        public virtual DbSet<XtaskAutoGenerated> XtaskAutoGenerated { get; set; }
        public virtual DbSet<XtaskTemplate> XtaskTemplate { get; set; }
        public virtual DbSet<XtaskTypeAction> XtaskTypeAction { get; set; }
        public virtual DbSet<XtranslateColumn> XtranslateColumn { get; set; }
        public virtual DbSet<XtypeConfig> XtypeConfig { get; set; }
        public virtual DbSet<XUser> Xuser { get; set; }
        public virtual DbSet<XuserArchive> XuserArchive { get; set; }
        public virtual DbSet<XuserBdeuserGroup> XuserBdeuserGroup { get; set; }
        public virtual DbSet<XUserGroup> XuserGroup { get; set; }
        public virtual DbSet<XUserGroupRight> XuserGroupRight { get; set; }
        public virtual DbSet<XuserStundenansatz> XuserStundenansatz { get; set; }
        public virtual DbSet<XUserUserGroup> XuserUserGroup { get; set; }
        public virtual DbSet<XuserXdocTemplate> XuserXdocTemplate { get; set; }

        #endregion

        // Unable to generate entity type for table 'dbo.MigXClassFrmToCtl'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo._Mig_KesMassnahmeBSS'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo._Mig_KesMassnahmeBSS_Group'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo._Mig_KesMassnahmeBSS_Merge'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo._Old_KaVerlauf'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo._Old_XBookmark'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo._Old_BaAdresse'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo._Old_KaKontaktartProzess'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo._Old_BaPerson'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.BaPerson_NewodPerson'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.XPlausiFehler'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo._Old_KaTransfer'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo._Old_KaJobtimal'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo._tmp_deleted_BgAuszahlungPerson'. Please see the warning messages.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaAdresse>(entity =>
            {
                entity.HasIndex(e => e.BaLandId);

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.KaBetriebId);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => e.VmMandantId);

                entity.HasIndex(e => e.VmPriMaId);

                entity.HasIndex(e => new { e.AdresseCode, e.BaAdresseId });

                entity.HasIndex(e => new { e.BaInstitutionId, e.DatumBis });

                entity.HasIndex(e => new { e.BaPersonId, e.DatumBis })
                    .HasName("IX_BaAdresse_BaPerson_DatumBis");

                entity.HasIndex(e => new { e.BaInstitutionId, e.DatumVon, e.DatumBis, e.BaAdresseId });

                entity.HasIndex(e => new { e.KaBetriebId, e.BaAdresseId, e.DatumVon, e.DatumBis });

                entity.HasIndex(e => new { e.BaPersonId, e.BaInstitutionId, e.BaAdresseId, e.DatumBis, e.DatumVon })
                    .HasName("IX_BaAdresse_BaPersonID_BaInstitutionID_BaAdresseID_DatumVon_DatumBis__AddCols");

                entity.HasIndex(e => new { e.BaPersonId, e.BaAdresseId, e.DatumVon, e.DatumBis, e.AdresseCode, e.Zusatz, e.Strasse, e.HausNr, e.Postfach, e.Plz, e.Ort })
                    .HasName("IX_BaAdresse_BaPersonID_BaAdresseID_DatumVonBis_AdresseCode_Zusatz_StrNrPostfachPLZOrt");

                entity.HasIndex(e => new { e.BaInstitutionId, e.CareOf, e.Bemerkung, e.WohnStatusCode, e.WohnungsgroesseCode, e.BaAdresseId, e.Zusatz, e.Strasse, e.HausNr, e.Postfach, e.PostfachOhneNr, e.Plz, e.Ort, e.BaLandId, e.OrtschaftCode, e.Kanton, e.Bezirk })
                    .HasName("IX_BaAdresse_BaAdresseID_Zusatz_Strasse_HausNr_Postfach_PostfachOhneNr_PLZ_Ort_BaLandID_OrtschaftCode_Kanton_Bezirk__AddCols");

                entity.HasIndex(e => new { e.BaLandId, e.Zusatz, e.Strasse, e.HausNr, e.Postfach, e.PostfachOhneNr, e.Plz, e.Ort, e.OrtschaftCode, e.Kanton, e.Bezirk, e.BaInstitutionId, e.BaPersonId, e.BaAdresseId, e.DatumVon, e.DatumBis, e.AdresseCode })
                    .HasName("IX_BaAdresse_BaInstitutionID_BaPersonID_BaAdresseID_DatumVon_DatumBis_AdresseCode__AddCols");

                entity.Property(e => e.BaAdresseId).HasColumnName("BaAdresseID");

                entity.Property(e => e.BaAdresseTs)
                    .IsRequired()
                    .HasColumnName("BaAdresseTS")
                    .IsRowVersion();

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.BaLandId).HasColumnName("BaLandID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).HasColumnType("varchar(max)");

                entity.Property(e => e.Bezirk)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CareOf)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.HausNr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutionName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KaBetriebId).HasColumnName("KaBetriebID");

                entity.Property(e => e.KaBetriebKontaktId).HasColumnName("KaBetriebKontaktID");

                entity.Property(e => e.Kanton)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MigrationKa)
                    .HasColumnName("MigrationKA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ort)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlatzierungInstId).HasColumnName("PlatzierungInstID");

                entity.Property(e => e.Plz)
                    .HasColumnName("PLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Postfach)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Strasse)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.VmMandantId).HasColumnName("VmMandantID");

                entity.Property(e => e.VmPriMaId).HasColumnName("VmPriMaID");

                entity.Property(e => e.ZuhandenVon)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Zusatz)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.BaAdresseBaInstitution)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BaAdresse_BaInstitution");

                entity.HasOne(d => d.BaLand)
                    .WithMany(p => p.BaAdresse)
                    .HasForeignKey(d => d.BaLandId)
                    .HasConstraintName("FK_BaAdresse_BaLand");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.BaAdresse)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BaAdresse_BaPerson");

                entity.HasOne(d => d.KaBetrieb)
                    .WithMany(p => p.BaAdresse)
                    .HasForeignKey(d => d.KaBetriebId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BaAdresse_KaBetrieb");

                entity.HasOne(d => d.KaBetriebKontakt)
                    .WithMany(p => p.BaAdresse)
                    .HasForeignKey(d => d.KaBetriebKontaktId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BaAdresse_KaBetriebKontakt");

                entity.HasOne(d => d.PlatzierungInst)
                    .WithMany(p => p.BaAdressePlatzierungInst)
                    .HasForeignKey(d => d.PlatzierungInstId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BaAdresse)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BaAdresse_XUser");

                entity.HasOne(d => d.VmMandant)
                    .WithMany(p => p.BaAdresse)
                    .HasForeignKey(d => d.VmMandantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BaAdresse_VmMandant");

                entity.HasOne(d => d.VmPriMa)
                    .WithMany(p => p.BaAdresse)
                    .HasForeignKey(d => d.VmPriMaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BaAdresse_VmPriMa");
            });

            modelBuilder.Entity<BaArbeit>(entity =>
            {
                entity.HasKey(e => e.BaArbeit1);

                entity.Property(e => e.BaArbeit1).HasColumnName("BaArbeit");

                entity.Property(e => e.Adresse).IsUnicode(false);

                entity.Property(e => e.BaArbeitTs)
                    .IsRequired()
                    .HasColumnName("BaArbeitTS")
                    .IsRowVersion();

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.BaArbeit)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .HasConstraintName("FK_BaArbeit_BaInstitution");
            });

            modelBuilder.Entity<BaArbeitAusbildung>(entity =>
            {
                entity.HasKey(e => e.BaPersonId);

                entity.HasIndex(e => e.BaInstitutionId);

                entity.Property(e => e.BaPersonId)
                    .HasColumnName("BaPersonID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Arbeitszeit).HasColumnType("numeric(2, 0)");

                entity.Property(e => e.AusgesteuertDatum).HasColumnType("datetime");

                entity.Property(e => e.BaArbeitAusbildungTs)
                    .IsRequired()
                    .HasColumnName("BaArbeitAusbildungTS")
                    .IsRowVersion();

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.StempelDatum).HasColumnType("datetime");

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.BaArbeitAusbildung)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .HasConstraintName("FK_BaArbeitAusbildung_BaInstitution");

                entity.HasOne(d => d.BaPerson)
                    .WithOne(p => p.BaArbeitAusbildung)
                    .HasForeignKey<BaArbeitAusbildung>(d => d.BaPersonId)
                    .HasConstraintName("FK_BaArbeitAusbildung_BaPerson");
            });

            modelBuilder.Entity<BaBank>(entity =>
            {
                entity.HasIndex(e => e.LandCode);

                entity.HasIndex(e => new { e.ClearingNr, e.FilialeNr });

                entity.HasIndex(e => new { e.Name, e.Strasse, e.Plz, e.Ort, e.ClearingNr, e.PckontoNr, e.BaBankId })
                    .HasName("IX_BaBank_BaBankID__AddCols");

                entity.Property(e => e.BaBankId).HasColumnName("BaBankID");

                entity.Property(e => e.BaBankTs)
                    .IsRequired()
                    .HasColumnName("BaBankTS")
                    .IsRowVersion();

                entity.Property(e => e.ClearingNr)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ClearingNrNeu)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GueltigAb).HasColumnType("datetime");

                entity.Property(e => e.HauptsitzBcl)
                    .HasColumnName("HauptsitzBCL")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Ort)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PckontoNr)
                    .HasColumnName("PCKontoNr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Plz)
                    .HasColumnName("PLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Strasse)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zusatz)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LandCodeNavigation)
                    .WithMany(p => p.BaBank)
                    .HasForeignKey(d => d.LandCode)
                    .HasConstraintName("FK_BaBank_BaLand");
            });

            modelBuilder.Entity<BaBeruf>(entity =>
            {
                entity.Property(e => e.BaBerufId)
                    .HasColumnName("BaBerufID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BaBerufTs)
                    .IsRequired()
                    .HasColumnName("BaBerufTS")
                    .IsRowVersion();

                entity.Property(e => e.Beruf)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BezeichnungM)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BezeichnungW)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Bfscode).HasColumnName("BFSCode");
            });

            modelBuilder.Entity<BaEinwohnerregisterEmpfangeneEreignisse>(entity =>
            {
                entity.ToTable("BaEinwohnerregisterEmpfangeneEreignisse", "log");

                entity.HasIndex(e => e.BaEinwohnerregisterEmpfangeneEreignisseRohdatenId);

                entity.Property(e => e.BaEinwohnerregisterEmpfangeneEreignisseId).HasColumnName("BaEinwohnerregisterEmpfangeneEreignisseID");

                entity.Property(e => e.Absence)
                    .HasColumnName("absence")
                    .IsUnicode(false);

                entity.Property(e => e.Acknowledgement)
                    .HasColumnName("acknowledgement")
                    .IsUnicode(false);

                entity.Property(e => e.AddressLock)
                    .HasColumnName("addressLock")
                    .IsUnicode(false);

                entity.Property(e => e.Adoption)
                    .HasColumnName("adoption")
                    .IsUnicode(false);

                entity.Property(e => e.BaEinwohnerregisterEmpfangeneEreignisseRohdatenId).HasColumnName("BaEinwohnerregisterEmpfangeneEreignisseRohdatenID");

                entity.Property(e => e.BaEinwohnerregisterEmpfangeneEreignisseTs)
                    .IsRequired()
                    .HasColumnName("BaEinwohnerregisterEmpfangeneEreignisseTS")
                    .IsRowVersion();

                entity.Property(e => e.BaseDeliveryMessages)
                    .HasColumnName("baseDelivery_messages")
                    .IsUnicode(false);

                entity.Property(e => e.BaseDeliveryNumberOfMessages)
                    .HasColumnName("baseDelivery_numberOfMessages")
                    .IsUnicode(false);

                entity.Property(e => e.Birth)
                    .HasColumnName("birth")
                    .IsUnicode(false);

                entity.Property(e => e.Care)
                    .HasColumnName("care")
                    .IsUnicode(false);

                entity.Property(e => e.ChangeCitizen)
                    .HasColumnName("changeCitizen")
                    .IsUnicode(false);

                entity.Property(e => e.ChangeGardian)
                    .HasColumnName("changeGardian")
                    .IsUnicode(false);

                entity.Property(e => e.ChangeName)
                    .HasColumnName("changeName")
                    .IsUnicode(false);

                entity.Property(e => e.ChangeNationality)
                    .HasColumnName("changeNationality")
                    .IsUnicode(false);

                entity.Property(e => e.ChangeNestRegister)
                    .HasColumnName("changeNestRegister")
                    .IsUnicode(false);

                entity.Property(e => e.ChangeNestTarget)
                    .HasColumnName("changeNestTarget")
                    .IsUnicode(false);

                entity.Property(e => e.ChangeOccupation)
                    .HasColumnName("changeOccupation")
                    .IsUnicode(false);

                entity.Property(e => e.ChangeOkv)
                    .HasColumnName("changeOKV")
                    .IsUnicode(false);

                entity.Property(e => e.ChangeReligion)
                    .HasColumnName("changeReligion")
                    .IsUnicode(false);

                entity.Property(e => e.ChangeResidencePermit)
                    .HasColumnName("changeResidencePermit")
                    .IsUnicode(false);

                entity.Property(e => e.ChangeResidenceType)
                    .HasColumnName("changeResidenceType")
                    .IsUnicode(false);

                entity.Property(e => e.ChangeSex)
                    .HasColumnName("changeSex")
                    .IsUnicode(false);

                entity.Property(e => e.ChildRelationship)
                    .HasColumnName("childRelationship")
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectAbsence)
                    .HasColumnName("correctAbsence")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectAdditionalAddresses)
                    .HasColumnName("correctAdditionalAddresses")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectAddress)
                    .HasColumnName("correctAddress")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectCodes)
                    .HasColumnName("correctCodes")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectContact)
                    .HasColumnName("correctContact")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectDateOfDeath)
                    .HasColumnName("correctDateOfDeath")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectDateOfNameChange)
                    .HasColumnName("correctDateOfNameChange")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectDateOfNaturalization)
                    .HasColumnName("correctDateOfNaturalization")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectDmp)
                    .HasColumnName("correctDMP")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectIdentification)
                    .HasColumnName("correctIdentification")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectLanguageOfCorrespondance)
                    .HasColumnName("correctLanguageOfCorrespondance")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectLiabilities)
                    .HasColumnName("correctLiabilities")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectMaritalData)
                    .HasColumnName("correctMaritalData")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectName)
                    .HasColumnName("correctName")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectNationality)
                    .HasColumnName("correctNationality")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectOccupation)
                    .HasColumnName("correctOccupation")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectOrigin)
                    .HasColumnName("correctOrigin")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectPerson)
                    .HasColumnName("correctPerson")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectPlaceOfBirth)
                    .HasColumnName("correctPlaceOfBirth")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectRelationship)
                    .HasColumnName("correctRelationship")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectReligion)
                    .HasColumnName("correctReligion")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectReporting)
                    .HasColumnName("correctReporting")
                    .IsUnicode(false);

                entity.Property(e => e.CorrectResidencePermit)
                    .HasColumnName("correctResidencePermit")
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataRequest)
                    .HasColumnName("dataRequest")
                    .IsUnicode(false);

                entity.Property(e => e.Death)
                    .HasColumnName("death")
                    .IsUnicode(false);

                entity.Property(e => e.DeletePerson)
                    .HasColumnName("deletePerson")
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryHeader)
                    .HasColumnName("deliveryHeader")
                    .IsUnicode(false);

                entity.Property(e => e.Divorce)
                    .HasColumnName("divorce")
                    .IsUnicode(false);

                entity.Property(e => e.FremdsystemId)
                    .IsRequired()
                    .HasColumnName("FremdsystemID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GardianMeasure)
                    .HasColumnName("gardianMeasure")
                    .IsUnicode(false);

                entity.Property(e => e.KeyDeliveryMessages)
                    .HasColumnName("keyDelivery_messages")
                    .IsUnicode(false);

                entity.Property(e => e.KeyDeliveryNumberOfKeyMessages)
                    .HasColumnName("keyDelivery_numberOfKeyMessages")
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatusPartner)
                    .HasColumnName("maritalStatusPartner")
                    .IsUnicode(false);

                entity.Property(e => e.Marriage)
                    .HasColumnName("marriage")
                    .IsUnicode(false);

                entity.Property(e => e.Missing)
                    .HasColumnName("missing")
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Move)
                    .HasColumnName("move")
                    .IsUnicode(false);

                entity.Property(e => e.MoveIn)
                    .HasColumnName("moveIn")
                    .IsUnicode(false);

                entity.Property(e => e.MoveOut)
                    .HasColumnName("moveOut")
                    .IsUnicode(false);

                entity.Property(e => e.NaturalizeForeigner)
                    .HasColumnName("naturalizeForeigner")
                    .IsUnicode(false);

                entity.Property(e => e.NaturalizeSwiss)
                    .HasColumnName("naturalizeSwiss")
                    .IsUnicode(false);

                entity.Property(e => e.PaperLock)
                    .HasColumnName("paperLock")
                    .IsUnicode(false);

                entity.Property(e => e.Partnership)
                    .HasColumnName("partnership")
                    .IsUnicode(false);

                entity.Property(e => e.RenewPermit)
                    .HasColumnName("renewPermit")
                    .IsUnicode(false);

                entity.Property(e => e.ReplacePerson)
                    .HasColumnName("replacePerson")
                    .IsUnicode(false);

                entity.Property(e => e.Separation)
                    .HasColumnName("separation")
                    .IsUnicode(false);

                entity.Property(e => e.UndoAbsence)
                    .HasColumnName("undoAbsence")
                    .IsUnicode(false);

                entity.Property(e => e.UndoCitizen)
                    .HasColumnName("undoCitizen")
                    .IsUnicode(false);

                entity.Property(e => e.UndoGardian)
                    .HasColumnName("undoGardian")
                    .IsUnicode(false);

                entity.Property(e => e.UndoMarriage)
                    .HasColumnName("undoMarriage")
                    .IsUnicode(false);

                entity.Property(e => e.UndoMissing)
                    .HasColumnName("undoMissing")
                    .IsUnicode(false);

                entity.Property(e => e.UndoPartnership)
                    .HasColumnName("undoPartnership")
                    .IsUnicode(false);

                entity.Property(e => e.UndoSeparation)
                    .HasColumnName("undoSeparation")
                    .IsUnicode(false);

                entity.Property(e => e.UndoSwiss)
                    .HasColumnName("undoSwiss")
                    .IsUnicode(false);

                entity.HasOne(d => d.BaEinwohnerregisterEmpfangeneEreignisseRohdaten)
                    .WithMany(p => p.BaEinwohnerregisterEmpfangeneEreignisse)
                    .HasForeignKey(d => d.BaEinwohnerregisterEmpfangeneEreignisseRohdatenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaEinwohnerregisterEmpfangeneEreignisse_BaEinwohnerregisterEmpfangeneEreignisseRohdaten");
            });

            modelBuilder.Entity<BaEinwohnerregisterEmpfangeneEreignisseRohdaten>(entity =>
            {
                entity.ToTable("BaEinwohnerregisterEmpfangeneEreignisseRohdaten", "log");

                entity.Property(e => e.BaEinwohnerregisterEmpfangeneEreignisseRohdatenId).HasColumnName("BaEinwohnerregisterEmpfangeneEreignisseRohdatenID");

                entity.Property(e => e.BaEinwohnerregisterEmpfangeneEreignisseRohdatenTs)
                    .IsRequired()
                    .HasColumnName("BaEinwohnerregisterEmpfangeneEreignisseRohdatenTS")
                    .IsRowVersion();

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Xml)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaEinwohnerregisterPersonAnAbmeldung>(entity =>
            {
                entity.ToTable("BaEinwohnerregisterPersonAnAbmeldung", "log");

                entity.HasIndex(e => e.BaPersonId);

                entity.Property(e => e.BaEinwohnerregisterPersonAnAbmeldungId).HasColumnName("BaEinwohnerregisterPersonAnAbmeldungID");

                entity.Property(e => e.BaEinwohnerregisterPersonAnAbmeldungTs)
                    .IsRequired()
                    .HasColumnName("BaEinwohnerregisterPersonAnAbmeldungTS")
                    .IsRowVersion();

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.FremdsystemId)
                    .IsRequired()
                    .HasColumnName("FremdsystemID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.BaEinwohnerregisterPersonAnAbmeldung)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaEinwohnerregisterPersonAnAbmeldung_BaPerson");
            });

            modelBuilder.Entity<BaEinwohnerregisterPersonStatus>(entity =>
            {
                entity.HasIndex(e => e.BaEinwohnerregisterPersonStatusId)
                    .HasName("IX_BaEinwohnerregisterPersonStatus_BaPersonID");

                entity.Property(e => e.BaEinwohnerregisterPersonStatusId).HasColumnName("BaEinwohnerregisterPersonStatusID");

                entity.Property(e => e.BaEinwohnerregisterPersonStatusTs)
                    .IsRequired()
                    .HasColumnName("BaEinwohnerregisterPersonStatusTS")
                    .IsRowVersion();

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.BaEinwohnerregisterPersonStatus)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaEinwohnerregisterPersonStatus_BaPerson");
            });

            modelBuilder.Entity<BaGemeinde>(entity =>
            {
                entity.HasIndex(e => e.Name);

                entity.HasIndex(e => e.Plz);

                entity.HasIndex(e => new { e.Name, e.Plz })
                    .HasName("IX_BaGemeinde_NamePLZ");

                entity.HasIndex(e => new { e.Name, e.Plz, e.NameTid, e.BezirkName, e.BezirkNameTid, e.Kanton })
                    .HasName("IX_BaGemeinde_NamePLZNameTIDBezirkNameBezirkNameTIDKanton");

                entity.Property(e => e.BaGemeindeId).HasColumnName("BaGemeindeID");

                entity.Property(e => e.BaGemeindeTs)
                    .IsRequired()
                    .HasColumnName("BaGemeindeTS")
                    .IsRowVersion();

                entity.Property(e => e.BezirkAenderungDatum).HasColumnType("datetime");

                entity.Property(e => e.BezirkAufhebungDatum).HasColumnType("datetime");

                entity.Property(e => e.BezirkAufnahmeDatum).HasColumnType("datetime");

                entity.Property(e => e.BezirkName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BezirkNameLang)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BezirkNameTid).HasColumnName("BezirkNameTID");

                entity.Property(e => e.Bfscode).HasColumnName("BFSCode");

                entity.Property(e => e.Bfsdelivered).HasColumnName("BFSDelivered");

                entity.Property(e => e.GemeindeAenderungDatum).HasColumnType("datetime");

                entity.Property(e => e.GemeindeAufhebungDatum).HasColumnType("datetime");

                entity.Property(e => e.GemeindeAufnahmeDatum).HasColumnType("datetime");

                entity.Property(e => e.GemeindeHistorisierungId).HasColumnName("GemeindeHistorisierungID");

                entity.Property(e => e.Kanton)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.KantonId).HasColumnName("KantonID");

                entity.Property(e => e.KantonNameLang)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameLang)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NameTid).HasColumnName("NameTID");

                entity.Property(e => e.Plz).HasColumnName("PLZ");
            });

            modelBuilder.Entity<BaGesundheit>(entity =>
            {
                entity.HasIndex(e => new { e.BaPersonId, e.Jahr })
                    .HasName("UK_BaGesundheit_BaPersonID_Jahr");

                entity.Property(e => e.BaGesundheitId).HasColumnName("BaGesundheitID");

                entity.Property(e => e.AbtretungKk).HasColumnName("AbtretungKK");

                entity.Property(e => e.Asvsabmeldung)
                    .HasColumnName("ASVSAbmeldung")
                    .HasColumnType("datetime");

                entity.Property(e => e.Asvsanmeldung)
                    .HasColumnName("ASVSAnmeldung")
                    .HasColumnType("datetime");

                entity.Property(e => e.BaGesundheitTs)
                    .IsRequired()
                    .HasColumnName("BaGesundheitTS")
                    .IsRowVersion();

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.Evazdatum)
                    .HasColumnName("EVAZDatum")
                    .HasColumnType("datetime");

                entity.Property(e => e.IveingliederungsmassnahmeCode).HasColumnName("IVEingliederungsmassnahmeCode");

                entity.Property(e => e.Jahr).HasDefaultValueSql("(datepart(year,getdate()))");

                entity.Property(e => e.Kvgfranchise)
                    .HasColumnName("KVGFranchise")
                    .HasColumnType("money");

                entity.Property(e => e.KvggesundFoerdPraemie)
                    .HasColumnName("KVGGesundFoerdPraemie")
                    .HasColumnType("money");

                entity.Property(e => e.KvggrundPraemie)
                    .HasColumnName("KVGGrundPraemie")
                    .HasColumnType("money");

                entity.Property(e => e.KvgkontaktPerson)
                    .HasColumnName("KVGKontaktPerson")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KvgkontaktTelefon)
                    .HasColumnName("KVGKontaktTelefon")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KvgmitgliedNr)
                    .HasColumnName("KVGMitgliedNr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KvgorganisationId).HasColumnName("KVGOrganisationID");

                entity.Property(e => e.Kvgpraemie)
                    .HasColumnName("KVGPraemie")
                    .HasColumnType("money");

                entity.Property(e => e.KvgumweltabgabeBetrag)
                    .HasColumnName("KVGUmweltabgabeBetrag")
                    .HasColumnType("money");

                entity.Property(e => e.KvgunfallPraemie)
                    .HasColumnName("KVGUnfallPraemie")
                    .HasColumnType("money");

                entity.Property(e => e.KvgversichertSeit)
                    .HasColumnName("KVGVersichertSeit")
                    .HasColumnType("datetime");

                entity.Property(e => e.KvgzahlungsPeriodeCode).HasColumnName("KVGZahlungsPeriodeCode");

                entity.Property(e => e.KvgzuschussBetrag)
                    .HasColumnName("KVGZuschussBetrag")
                    .HasColumnType("money");

                entity.Property(e => e.Vvgfranchise)
                    .HasColumnName("VVGFranchise")
                    .HasColumnType("money");

                entity.Property(e => e.VvgkontaktPerson)
                    .HasColumnName("VVGKontaktPerson")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VvgkontaktTelefon)
                    .HasColumnName("VVGKontaktTelefon")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VvgmitgliedNr)
                    .HasColumnName("VVGMitgliedNr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VvgorganisationId).HasColumnName("VVGOrganisationID");

                entity.Property(e => e.Vvgpraemie)
                    .HasColumnName("VVGPraemie")
                    .HasColumnType("money");

                entity.Property(e => e.VvgversichertSeit)
                    .HasColumnName("VVGVersichertSeit")
                    .HasColumnType("datetime");

                entity.Property(e => e.VvgzahlungsPeriodeCode).HasColumnName("VVGZahlungsPeriodeCode");

                entity.Property(e => e.VvgzusaetzeRtf)
                    .HasColumnName("VVGZusaetzeRTF")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.ZahnarztBaInstitutionId).HasColumnName("ZahnarztBaInstitutionID");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.BaGesundheit)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_BaGesundheit_BaPerson");

                entity.HasOne(d => d.Kvgorganisation)
                    .WithMany(p => p.BaGesundheitKvgorganisation)
                    .HasForeignKey(d => d.KvgorganisationId)
                    .HasConstraintName("FK_BaGesundheit_BaInstitution_KVG");

                entity.HasOne(d => d.Vvgorganisation)
                    .WithMany(p => p.BaGesundheitVvgorganisation)
                    .HasForeignKey(d => d.VvgorganisationId)
                    .HasConstraintName("FK_BaGesundheit_BaInstitution_VVG");

                entity.HasOne(d => d.ZahnarztBaInstitution)
                    .WithMany(p => p.BaGesundheitZahnarztBaInstitution)
                    .HasForeignKey(d => d.ZahnarztBaInstitutionId)
                    .HasConstraintName("FK_BaGesundheit_BaInstitution");
            });

            modelBuilder.Entity<BaInstitution>(entity =>
            {
                entity.HasIndex(e => e.InstitutionName);

                entity.HasIndex(e => e.Name);

                entity.HasIndex(e => e.OrgUnitId);

                entity.HasIndex(e => new { e.BaInstitutionId, e.Name, e.Vorname });

                entity.HasIndex(e => new { e.Name, e.Vorname, e.BaInstitutionId })
                    .HasName("IX_BaInstitution_BaInstitutionID__AddCols");

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.Aktiv).HasDefaultValueSql("((1))");

                entity.Property(e => e.Anrede)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BaInstitutionTs)
                    .IsRequired()
                    .HasColumnName("BaInstitutionTS")
                    .IsRowVersion();

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Briefanrede)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefinitivDatum).HasColumnType("datetime");

                entity.Property(e => e.DefinitivUserId).HasColumnName("DefinitivUserID");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ErstelltDatum).HasColumnType("datetime");

                entity.Property(e => e.ErstelltUserId).HasColumnName("ErstelltUserID");

                entity.Property(e => e.Fax)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Geburtsdatum).HasColumnType("datetime");

                entity.Property(e => e.Homepage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutionName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutionNr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MutiertDatum).HasColumnType("datetime");

                entity.Property(e => e.MutiertUserId).HasColumnName("MutiertUserID");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OrgUnitId).HasColumnName("OrgUnitID");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Versichertennummer)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Vorname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrgUnit)
                    .WithMany(p => p.BaInstitution)
                    .HasForeignKey(d => d.OrgUnitId)
                    .HasConstraintName("FK_BaInstitution_XOrgUnit");
            });

            modelBuilder.Entity<BaInstitutionBaInstitutionTyp>(entity =>
            {
                entity.ToTable("BaInstitution_BaInstitutionTyp");

                entity.HasIndex(e => new { e.BaInstitutionId, e.BaInstitutionTypId })
                    .HasName("IX_BaInstitution_BaInstitutionTyp_BaInstitutionTypID_BaInstitutionID");

                entity.Property(e => e.BaInstitutionBaInstitutionTypId).HasColumnName("BaInstitution_BaInstitutionTypID");

                entity.Property(e => e.BaInstitutionBaInstitutionTypTs)
                    .IsRequired()
                    .HasColumnName("BaInstitution_BaInstitutionTypTS")
                    .IsRowVersion();

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.BaInstitutionTypId).HasColumnName("BaInstitutionTypID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.BaInstitutionBaInstitutionTyp)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaInstitution_BaInstitutionTyp_BaInstitution");

                entity.HasOne(d => d.BaInstitutionTyp)
                    .WithMany(p => p.BaInstitutionBaInstitutionTyp)
                    .HasForeignKey(d => d.BaInstitutionTypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaInstitution_BaInstitutionTyp_BaInstitutionTyp");
            });

            modelBuilder.Entity<BaInstitutionDokument>(entity =>
            {
                entity.HasIndex(e => e.BaInstitutionId);

                entity.HasIndex(e => e.BaInstitutionIdAdressat);

                entity.HasIndex(e => e.BaPersonIdAdressat);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.BaInstitutionDokumentId).HasColumnName("BaInstitutionDokumentID");

                entity.Property(e => e.BaInstitutionDokumentTs)
                    .IsRequired()
                    .HasColumnName("BaInstitutionDokumentTS")
                    .IsRowVersion();

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.BaInstitutionIdAdressat).HasColumnName("BaInstitutionID_Adressat");

                entity.Property(e => e.BaPersonIdAdressat).HasColumnName("BaPersonID_Adressat");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.Inhalt).IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stichwort).IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.BaInstitutionDokumentBaInstitution)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaInstitutionDokument_BaInstitution");

                entity.HasOne(d => d.BaInstitutionIdAdressatNavigation)
                    .WithMany(p => p.BaInstitutionDokumentBaInstitutionIdAdressatNavigation)
                    .HasForeignKey(d => d.BaInstitutionIdAdressat)
                    .HasConstraintName("FK_BaInstitutionDokument_BaInstitution_Adressat");

                entity.HasOne(d => d.BaPersonIdAdressatNavigation)
                    .WithMany(p => p.BaInstitutionDokument)
                    .HasForeignKey(d => d.BaPersonIdAdressat)
                    .HasConstraintName("FK_BaInstitutionDokument_BaPerson");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BaInstitutionDokument)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaInstitutionDokument_XUser");
            });

            modelBuilder.Entity<BaInstitutionKontakt>(entity =>
            {
                entity.HasIndex(e => e.BaInstitutionId);

                entity.Property(e => e.BaInstitutionKontaktId).HasColumnName("BaInstitutionKontaktID");

                entity.Property(e => e.Anrede)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.BaInstitutionKontaktTs)
                    .IsRequired()
                    .HasColumnName("BaInstitutionKontaktTS")
                    .IsRowVersion();

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Briefanrede)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Vorname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.BaInstitutionKontakt)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaInstitutionKontakt_BaInstitution");
            });

            modelBuilder.Entity<BaInstitutionTyp>(entity =>
            {
                entity.HasIndex(e => e.OrgUnitId);

                entity.Property(e => e.BaInstitutionTypId).HasColumnName("BaInstitutionTypID");

                entity.Property(e => e.BaInstitutionTypTs)
                    .IsRequired()
                    .HasColumnName("BaInstitutionTypTS")
                    .IsRowVersion();

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NameTid).HasColumnName("NameTID");

                entity.Property(e => e.OrgUnitId).HasColumnName("OrgUnitID");

                entity.HasOne(d => d.OrgUnit)
                    .WithMany(p => p.BaInstitutionTyp)
                    .HasForeignKey(d => d.OrgUnitId)
                    .HasConstraintName("FK_BaInstitutionTyp_XOrgUnit");
            });

            modelBuilder.Entity<BaKantonalerZuschuss>(entity =>
            {
                entity.Property(e => e.BaKantonalerZuschussId).HasColumnName("BaKantonalerZuschussID");

                entity.Property(e => e.BaKantonalerZuschussTs)
                    .IsRequired()
                    .HasColumnName("BaKantonalerZuschussTS")
                    .IsRowVersion();

                entity.Property(e => e.Bemerkungen)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BezeichnungTid).HasColumnName("BezeichnungTID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaKopfquote>(entity =>
            {
                entity.Property(e => e.BaKopfquoteId).HasColumnName("BaKopfquoteID");

                entity.Property(e => e.BaKopfquoteTs)
                    .HasColumnName("BaKopfquoteTS")
                    .IsRowVersion();

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).HasColumnType("nchar(500)");

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.RechnungDatum).HasColumnType("datetime");

                entity.Property(e => e.Zeitspanne)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.BaKopfquote)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_BaKopfquote_BaPerson");
            });

            modelBuilder.Entity<BaLand>(entity =>
            {
                entity.HasIndex(e => new { e.BaLandId, e.Text, e.TextFr, e.TextIt, e.TextEn });

                entity.Property(e => e.BaLandId).HasColumnName("BaLandID");

                entity.Property(e => e.BaLandTs)
                    .IsRequired()
                    .HasColumnName("BaLandTS")
                    .IsRowVersion();

                entity.Property(e => e.Bfscode).HasColumnName("BFSCode");

                entity.Property(e => e.Bfsdelivered).HasColumnName("BFSDelivered");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.Iso2Code)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Iso3Code)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sapcode)
                    .HasColumnName("SAPCode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TextEn)
                    .IsRequired()
                    .HasColumnName("TextEN")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TextFr)
                    .IsRequired()
                    .HasColumnName("TextFR")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TextIt)
                    .IsRequired()
                    .HasColumnName("TextIT")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BaMietvertrag>(entity =>
            {
                entity.HasIndex(e => e.BaInstitutionId);

                entity.HasIndex(e => e.BaPersonId)
                    .HasName("UQ_BaMietvertrag_BaPersonID");

                entity.Property(e => e.BaMietvertragId).HasColumnName("BaMietvertragID");

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.BaMietvertragTs)
                    .IsRequired()
                    .HasColumnName("BaMietvertragTS")
                    .IsRowVersion();

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.GarantieBis).HasColumnType("datetime");

                entity.Property(e => e.KostenanteilUe)
                    .HasColumnName("KostenanteilUE")
                    .HasColumnType("money");

                entity.Property(e => e.Mietdepot).HasColumnType("money");

                entity.Property(e => e.Mietkosten).HasColumnType("money");

                entity.Property(e => e.Mietzinsgarantie).HasColumnType("money");

                entity.Property(e => e.Nebenkosten).HasColumnType("money");

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.BaMietvertrag)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .HasConstraintName("FK_BaMietvertrag_BaInstitution");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.BaMietvertrag)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_BaMietvertrag_BaPerson");
            });

            modelBuilder.Entity<BaPerson>(entity =>
            {
                entity.HasIndex(e => e.BaPersonIdDossiertraeger);

                entity.HasIndex(e => e.Geburtsdatum)
                    .HasName("IX_BaPerson_Birthday");

                entity.HasIndex(e => e.KontoFuehrung);

                entity.HasIndex(e => e.KopfquoteBaInstitutionId);

                entity.HasIndex(e => e.NationalitaetCode);

                entity.HasIndex(e => e.UntWohnsitzLandCode);

                entity.HasIndex(e => e.Vorname);

                entity.HasIndex(e => e.WegzugLandCode);

                entity.HasIndex(e => e.Zipnr)
                    .HasName("IX_BaPerson_ZipNummer");

                entity.HasIndex(e => e.ZuzugGdeLandCode);

                entity.HasIndex(e => e.ZuzugKtLandCode);

                entity.HasIndex(e => new { e.Name, e.Vorname });

                entity.HasIndex(e => new { e.Name, e.Vorname, e.BaPersonID })
                    .HasName("IX_BaPerson_BaPersonID_Name_Vorname");

                entity.HasIndex(e => new { e.BaPersonID, e.Name, e.Vorname, e.Geburtsdatum });

                entity.Property(e => e.BaPersonID).HasColumnName("BaPersonID");

                entity.Property(e => e.Ahvnummer)
                    .HasColumnName("AHVNummer")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Alk).HasColumnName("ALK");

                entity.Property(e => e.AndereSvleistungen)
                    .HasColumnName("AndereSVLeistungen")
                    .IsUnicode(false);

                entity.Property(e => e.Anrede)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ArbeitSpezFaehigkeiten).IsUnicode(false);

                entity.Property(e => e.AufenthaltWieBaInstitutionId).HasColumnName("AufenthaltWieBaInstitutionID");

                entity.Property(e => e.AuslaenderStatusGueltigBis).HasColumnType("datetime");

                entity.Property(e => e.BaPersonIdDossiertraeger).HasColumnName("BaPersonID_Dossiertraeger");

                entity.Property(e => e.BaPersonTs)
                    .IsRequired()
                    .HasColumnName("BaPersonTS")
                    .IsRowVersion();

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.BemerkungenAdresse).IsUnicode(false);

                entity.Property(e => e.BemerkungenSv)
                    .HasColumnName("BemerkungenSV")
                    .IsUnicode(false);

                entity.Property(e => e.BeruflicheMassnahmeIv).HasColumnName("BeruflicheMassnahmeIV");

                entity.Property(e => e.Bffnummer)
                    .HasColumnName("BFFNummer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Briefanrede)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BsvbehinderungsartCode).HasColumnName("BSVBehinderungsartCode");

                entity.Property(e => e.Bvgrente).HasColumnName("BVGRente");

                entity.Property(e => e.CausweisDatum)
                    .HasColumnName("CAusweisDatum")
                    .HasColumnType("datetime");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumAssistenzbeitrag).HasColumnType("datetime");

                entity.Property(e => e.DatumAsylgesuch).HasColumnType("datetime");

                entity.Property(e => e.DatumEinbezugFaz).HasColumnType("datetime");

                entity.Property(e => e.DatumIvVerfuegung).HasColumnType("datetime");

                entity.Property(e => e.DebitorUpdate).HasColumnType("datetime");

                entity.Property(e => e.Einrichtpauschale).HasColumnType("money");

                entity.Property(e => e.EinwohnerregisterId)
                    .HasColumnName("EinwohnerregisterID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ErteilungVa)
                    .HasColumnName("ErteilungVA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fax)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FruehererName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Geburtsdatum).HasColumnType("datetime");

                entity.Property(e => e.HaushaltVersicherungsNummer)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Hcmcfluechtling).HasColumnName("HCMCFluechtling");

                entity.Property(e => e.HeimatgemeindeBaGemeindeId).HasColumnName("HeimatgemeindeBaGemeindeID");

                entity.Property(e => e.HeimatgemeindeCodes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Helbab)
                    .HasColumnName("HELBAb")
                    .HasColumnType("datetime");

                entity.Property(e => e.Helbanmeldung)
                    .HasColumnName("HELBAnmeldung")
                    .HasColumnType("datetime");

                entity.Property(e => e.Helbentscheid)
                    .HasColumnName("HELBEntscheid")
                    .HasColumnType("datetime");

                entity.Property(e => e.HelbentscheidCode).HasColumnName("HELBEntscheidCode");

                entity.Property(e => e.HelbkeinAntrag).HasColumnName("HELBKeinAntrag");

                entity.Property(e => e.ImKantonSeit).HasColumnType("datetime");

                entity.Property(e => e.InChseit)
                    .HasColumnName("InCHSeit")
                    .HasColumnType("datetime");

                entity.Property(e => e.InChseitGeburt).HasColumnName("InCHSeitGeburt");

                entity.Property(e => e.InGemeindeSeit).HasColumnType("datetime");

                entity.Property(e => e.IvberechtigungAnfangsStatusCode).HasColumnName("IVBerechtigungAnfangsStatusCode");

                entity.Property(e => e.IvberechtigungErsterEntscheidAb)
                    .HasColumnName("IVBerechtigungErsterEntscheidAb")
                    .HasColumnType("datetime");

                entity.Property(e => e.IvberechtigungErsterEntscheidCode).HasColumnName("IVBerechtigungErsterEntscheidCode");

                entity.Property(e => e.IvberechtigungZweiterEntscheidAb)
                    .HasColumnName("IVBerechtigungZweiterEntscheidAb")
                    .HasColumnType("datetime");

                entity.Property(e => e.IvberechtigungZweiterEntscheidCode).HasColumnName("IVBerechtigungZweiterEntscheidCode");

                entity.Property(e => e.Ivgrad).HasColumnName("IVGrad");

                entity.Property(e => e.Ivhilfsmittel).HasColumnName("IVHilfsmittel");

                entity.Property(e => e.Ivtaggeld).HasColumnName("IVTaggeld");

                entity.Property(e => e.KantonaleReferenznummer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KbKostenstelleId).HasColumnName("KbKostenstelleID");

                entity.Property(e => e.KopfquoteAbDatum).HasColumnType("datetime");

                entity.Property(e => e.KopfquoteBaInstitutionId).HasColumnName("Kopfquote_BaInstitutionID");

                entity.Property(e => e.KopfquoteBisDatum).HasColumnType("datetime");

                entity.Property(e => e.Ktg).HasColumnName("KTG");

                entity.Property(e => e.MedizinischeMassnahmeIv).HasColumnName("MedizinischeMassnahmeIV");

                entity.Property(e => e.MietdepotPi).HasColumnName("MietdepotPI");

                entity.Property(e => e.MigrationKa).HasColumnName("MigrationKA");

                entity.Property(e => e.MobilTel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobilTel1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobilTel2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NavigatorZusatz)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Neanmeldung)
                    .HasColumnName("NEAnmeldung")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nnummer)
                    .HasColumnName("NNummer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PauschaleAktualDatum).HasColumnType("datetime");

                entity.Property(e => e.PersonSichtbarSdflag)
                    .HasColumnName("PersonSichtbarSDFlag")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PraemienuebernahmeBis).HasColumnType("datetime");

                entity.Property(e => e.PraemienuebernahmeVon).HasColumnType("datetime");

                entity.Property(e => e.PuanzahlVerlustscheine).HasColumnName("PUAnzahlVerlustscheine");

                entity.Property(e => e.Pukrankenkasse)
                    .HasColumnName("PUKrankenkasse")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.Property(e => e.Sprachpauschale).HasColumnType("money");

                entity.Property(e => e.Sterbedatum).HasColumnType("datetime");

                entity.Property(e => e.TelefonG)
                    .HasColumnName("Telefon_G")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonP)
                    .HasColumnName("Telefon_P")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UntWohnsitzKanton)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UntWohnsitzOrt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UntWohnsitzPlz)
                    .HasColumnName("UntWohnsitzPLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Uvgrente).HasColumnName("UVGRente");

                entity.Property(e => e.Uvgtaggeld).HasColumnName("UVGTaggeld");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.Versichertennummer)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Visdat36Area)
                    .HasColumnName("visdat36Area")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Visdat36Id)
                    .HasColumnName("visdat36ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VormundPi).HasColumnName("VormundPI");

                entity.Property(e => e.Vorname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Vorname2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WegzugDatum).HasColumnType("datetime");

                entity.Property(e => e.WegzugKanton)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WegzugOrt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WegzugPlz)
                    .HasColumnName("WegzugPLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WichtigerHinweis)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.WohnsitzWieBaPersonId).HasColumnName("WohnsitzWieBaPersonID");

                entity.Property(e => e.Zarnummer)
                    .HasColumnName("ZARNummer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ZeigeDetails).HasDefaultValueSql("((1))");

                entity.Property(e => e.ZeigeTelPrivat).HasDefaultValueSql("((1))");

                entity.Property(e => e.Zemisnummer)
                    .HasColumnName("ZEMISNummer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Zipnr).HasColumnName("ZIPNr");

                entity.Property(e => e.ZivilstandDatum).HasColumnType("datetime");

                entity.Property(e => e.ZuzugGdeDatum).HasColumnType("datetime");

                entity.Property(e => e.ZuzugGdeKanton)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ZuzugGdeOrt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZuzugGdePlz)
                    .HasColumnName("ZuzugGdePLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ZuzugKtDatum).HasColumnType("datetime");

                entity.Property(e => e.ZuzugKtKanton)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ZuzugKtOrt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZuzugKtPlz)
                    .HasColumnName("ZuzugKtPLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPersonIdDossiertraegerNavigation)
                    .WithMany(p => p.InverseBaPersonIdDossiertraegerNavigation)
                    .HasForeignKey(d => d.BaPersonIdDossiertraeger)
                    .HasConstraintName("FK_BaPerson_BaPerson_Dossiertraeger");

                entity.HasOne(d => d.HeimatgemeindeBaGemeinde)
                    .WithMany(p => p.BaPersonHeimatgemeindeBaGemeinde)
                    .HasForeignKey(d => d.HeimatgemeindeBaGemeindeId)
                    .HasConstraintName("FK_BaPerson_BaGemeinde");

                entity.HasOne(d => d.HeimatgemeindeCodeNavigation)
                    .WithMany(p => p.BaPersonHeimatgemeindeCodeNavigation)
                    .HasForeignKey(d => d.HeimatgemeindeCode);

                entity.HasOne(d => d.KopfquoteBaInstitution)
                    .WithMany(p => p.BaPerson)
                    .HasForeignKey(d => d.KopfquoteBaInstitutionId)
                    .HasConstraintName("FK_BaPerson_BaInstitution");

                entity.HasOne(d => d.NationalitaetCodeNavigation)
                    .WithMany(p => p.BaPersonNationalitaetCodeNavigation)
                    .HasForeignKey(d => d.NationalitaetCode);

                entity.HasOne(d => d.UntWohnsitzLandCodeNavigation)
                    .WithMany(p => p.BaPersonUntWohnsitzLandCodeNavigation)
                    .HasForeignKey(d => d.UntWohnsitzLandCode);

                entity.HasOne(d => d.WegzugLandCodeNavigation)
                    .WithMany(p => p.BaPersonWegzugLandCodeNavigation)
                    .HasForeignKey(d => d.WegzugLandCode);

                entity.HasOne(d => d.WegzugOrtCodeNavigation)
                    .WithMany(p => p.BaPersonWegzugOrtCodeNavigation)
                    .HasForeignKey(d => d.WegzugOrtCode);

                entity.HasOne(d => d.ZuzugGdeLandCodeNavigation)
                    .WithMany(p => p.BaPersonZuzugGdeLandCodeNavigation)
                    .HasForeignKey(d => d.ZuzugGdeLandCode);

                entity.HasOne(d => d.ZuzugGdeOrtCodeNavigation)
                    .WithMany(p => p.BaPersonZuzugGdeOrtCodeNavigation)
                    .HasForeignKey(d => d.ZuzugGdeOrtCode);

                entity.HasOne(d => d.ZuzugKtLandCodeNavigation)
                    .WithMany(p => p.BaPersonZuzugKtLandCodeNavigation)
                    .HasForeignKey(d => d.ZuzugKtLandCode);
            });

            modelBuilder.Entity<BaPersonBaInstitution>(entity =>
            {
                entity.ToTable("BaPerson_BaInstitution");

                entity.HasIndex(e => e.BaInstitutionId);

                entity.HasIndex(e => e.BaInstitutionKontaktId);

                entity.HasIndex(e => e.BaInstitutionTypId);

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => new { e.BaPersonId, e.BaInstitutionId, e.BaInstitutionKontaktId, e.BaInstitutionTypId })
                    .HasName("UK_BaPerson_BaInstitution_BaPersonID_BaInstitutionID_BaInstitutionKontaktID_BaInstitutionTypID")
                    .IsUnique();

                entity.Property(e => e.BaPersonBaInstitutionId).HasColumnName("BaPerson_BaInstitutionID");

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.BaInstitutionKontaktId).HasColumnName("BaInstitutionKontaktID");

                entity.Property(e => e.BaInstitutionTypId).HasColumnName("BaInstitutionTypID");

                entity.Property(e => e.BaPersonBaInstitutionTs)
                    .IsRequired()
                    .HasColumnName("BaPerson_BaInstitutionTS")
                    .IsRowVersion();

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.BaPersonBaInstitution)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaPerson_BaInstitution_BaInstitution");

                entity.HasOne(d => d.BaInstitutionKontakt)
                    .WithMany(p => p.BaPersonBaInstitution)
                    .HasForeignKey(d => d.BaInstitutionKontaktId)
                    .HasConstraintName("FK_BaPerson_BaInstitution_BaInstitutionKontakt");

                entity.HasOne(d => d.BaInstitutionTyp)
                    .WithMany(p => p.BaPersonBaInstitution)
                    .HasForeignKey(d => d.BaInstitutionTypId)
                    .HasConstraintName("FK_BaPerson_BaInstitution_BaInstitutionTyp");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.BaPersonBaInstitution)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_BaPerson_BaInstitution_BaPerson");
            });

            modelBuilder.Entity<BaPersonKantonalerZuschuss>(entity =>
            {
                entity.ToTable("BaPerson_KantonalerZuschuss");

                entity.HasIndex(e => new { e.BaPersonId, e.BaKantonalerZuschussId })
                    .HasName("IX_BaPerson_KantonalerZuschuss_BaPersonID_BaKantonalerZuschussID_Unique")
                    .IsUnique();

                entity.Property(e => e.BaPersonKantonalerZuschussId).HasColumnName("BaPerson_KantonalerZuschussID");

                entity.Property(e => e.BaKantonalerZuschussId).HasColumnName("BaKantonalerZuschussID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.BaPersonKantonalerZuschussTs)
                    .IsRequired()
                    .HasColumnName("BaPerson_KantonalerZuschussTS")
                    .IsRowVersion();

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaKantonalerZuschuss)
                    .WithMany(p => p.BaPersonKantonalerZuschuss)
                    .HasForeignKey(d => d.BaKantonalerZuschussId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaPerson_KantonalerZuschuss_BaKantonalerZuschuss");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.BaPersonKantonalerZuschuss)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaPerson_KantonalerZuschuss_BaPerson");
            });

            modelBuilder.Entity<BaPersonRelation>(entity =>
            {
                entity.ToTable("BaPerson_Relation");

                entity.HasIndex(e => e.BaPersonId1);

                entity.HasIndex(e => e.BaPersonId2);

                entity.HasIndex(e => e.BaRelationId);

                entity.HasIndex(e => new { e.BaPersonId1, e.BaPersonId2 })
                    .HasName("IX_BaPerson_Relation_BaPerson12_Unique")
                    .IsUnique();

                entity.Property(e => e.BaPersonRelationId).HasColumnName("BaPerson_RelationID");

                entity.Property(e => e.BaPersonId1).HasColumnName("BaPersonID_1");

                entity.Property(e => e.BaPersonId2).HasColumnName("BaPersonID_2");

                entity.Property(e => e.BaPersonRelationTs)
                    .IsRequired()
                    .HasColumnName("BaPerson_RelationTS")
                    .IsRowVersion();

                entity.Property(e => e.BaRelationId).HasColumnName("BaRelationID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.HasOne(d => d.BaPersonId1Navigation)
                    .WithMany(p => p.BaPersonRelationBaPersonId1Navigation)
                    .HasForeignKey(d => d.BaPersonId1)
                    .HasConstraintName("FK_BaPerson_Relation_BaPerson1");

                entity.HasOne(d => d.BaPersonId2Navigation)
                    .WithMany(p => p.BaPersonRelationBaPersonId2Navigation)
                    .HasForeignKey(d => d.BaPersonId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaPerson_Relation_BaPerson2");

                entity.HasOne(d => d.BaRelation)
                    .WithMany(p => p.BaPersonRelation)
                    .HasForeignKey(d => d.BaRelationId)
                    .HasConstraintName("FK_BaPerson_Relation_BaRelation");
            });

            modelBuilder.Entity<BaPlz>(entity =>
            {
                entity.ToTable("BaPLZ");

                entity.HasIndex(e => e.Name);

                entity.HasIndex(e => e.Onrp)
                    .IsUnique();

                entity.HasIndex(e => e.Plz);

                entity.HasIndex(e => new { e.Plz, e.Name })
                    .HasName("IX_BaPLZ");

                entity.Property(e => e.BaPlzid).HasColumnName("BaPLZID");

                entity.Property(e => e.BaPlzts)
                    .IsRequired()
                    .HasColumnName("BaPLZTS")
                    .IsRowVersion();

                entity.Property(e => e.Bfscode).HasColumnName("BFSCode");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.Kanton)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameTid).HasColumnName("NameTID");

                entity.Property(e => e.Onrp).HasColumnName("ONRP");

                entity.Property(e => e.Plz).HasColumnName("PLZ");

                entity.Property(e => e.Plz6).HasColumnName("PLZ6");

                entity.Property(e => e.Plzsuffix).HasColumnName("PLZSuffix");
            });

            modelBuilder.Entity<BaPraemienverbilligung>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId)
                    .HasName("IX_BaPraemienverbilligungID_BaPersonID");

                entity.Property(e => e.BaPraemienverbilligungId).HasColumnName("BaPraemienverbilligungID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.BaPraemienverbilligungTs)
                    .IsRequired()
                    .HasColumnName("BaPraemienverbilligungTS")
                    .IsRowVersion();

                entity.Property(e => e.BetragAnspruch).HasColumnType("money");

                entity.Property(e => e.BetragAuszahlung).HasColumnType("money");

                entity.Property(e => e.Grund)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LetzteMutation).HasColumnType("datetime");

                entity.Property(e => e.ZahlungAn)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZahlungAnKrankenkassennummer)
                    .HasColumnName("ZahlungAn_Krankenkassennummer")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.BaPraemienverbilligung)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaPraemienverbilligung_BaPerson");
            });

            modelBuilder.Entity<BaRelation>(entity =>
            {
                entity.Property(e => e.BaRelationId).HasColumnName("BaRelationID");

                entity.Property(e => e.BaRelationTs)
                    .IsRequired()
                    .HasColumnName("BaRelationTS")
                    .IsRowVersion();

                entity.Property(e => e.NameGenerisch1)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.NameGenerisch2)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.NameMaennlich1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameMaennlich2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameRelation)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameWeiblich1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameWeiblich2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Symmetrisch).HasColumnName("symmetrisch");
            });

            modelBuilder.Entity<BaWvcode>(entity =>
            {
                entity.ToTable("BaWVCode");

                entity.HasIndex(e => e.BaPersonId);

                entity.Property(e => e.BaWvcodeId).HasColumnName("BaWVCodeID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.BaWvcode1).HasColumnName("BaWVCode");

                entity.Property(e => e.BaWvcodeTs)
                    .IsRequired()
                    .HasColumnName("BaWVCodeTS")
                    .IsRowVersion();

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.HeimatKantonNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KantonKuerzel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WohnKantonNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.BaWvcode)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaWVCode_BaPerson");
            });

            modelBuilder.Entity<BaZahlungsweg>(entity =>
            {
                entity.HasIndex(e => e.AdresseLandCode);

                entity.HasIndex(e => e.BaBankId);

                entity.HasIndex(e => e.BaInstitutionId);

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.BankKontoNummer);

                entity.HasIndex(e => e.Ibannummer);

                entity.HasIndex(e => e.PostKontoNummer);

                entity.HasIndex(e => new { e.BaZahlungswegId, e.DatumVon, e.DatumBis, e.EinzahlungsscheinCode, e.BaBankId, e.BankKontoNummer, e.Ibannummer, e.PostKontoNummer, e.ReferenzNummer, e.AdresseName, e.AdresseName2, e.AdresseStrasse, e.AdresseHausNr, e.AdressePostfach, e.AdressePlz, e.AdresseOrt, e.BaInstitutionId, e.BaPersonId })
                    .HasName("IX_BaZahlungsweg_BaInstitutionID_BaPersonID__AddCols");

                entity.Property(e => e.BaZahlungswegId).HasColumnName("BaZahlungswegID");

                entity.Property(e => e.AdresseHausNr)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.AdresseName)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.AdresseName2)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.AdresseOrt)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AdressePlz)
                    .HasColumnName("AdressePLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AdressePostfach)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.AdresseStrasse)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.BaBankId).HasColumnName("BaBankID");

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.BaZahlungswegTs)
                    .IsRequired()
                    .HasColumnName("BaZahlungswegTS")
                    .IsRowVersion();

                entity.Property(e => e.BaZahlwegModulStdCodes)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BankKontoNummer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.Ibannummer)
                    .HasColumnName("IBANNummer")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostKontoNummer)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenzNummer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AdresseLandCodeNavigation)
                    .WithMany(p => p.BaZahlungsweg)
                    .HasForeignKey(d => d.AdresseLandCode)
                    .HasConstraintName("FK_BaZahlungsweg_BaLand");

                entity.HasOne(d => d.BaBank)
                    .WithMany(p => p.BaZahlungsweg)
                    .HasForeignKey(d => d.BaBankId)
                    .HasConstraintName("FK_BaZahlungsweg_BaBank");

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.BaZahlungsweg)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .HasConstraintName("FK_BaZahlungsweg_BaInstitution");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.BaZahlungsweg)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_BaZahlungsweg_BaPerson");
            });

            modelBuilder.Entity<BdeausbezahlteUeberstundenXuser>(entity =>
            {
                entity.ToTable("BDEAusbezahlteUeberstunden_XUser");

                entity.HasIndex(e => new { e.UserId, e.Jahr, e.DatumVon })
                    .HasName("IX_BDEAusbezahlteUeberstunden_XUser")
                    .IsUnique();

                entity.Property(e => e.BdeausbezahlteUeberstundenXuserId).HasColumnName("BDEAusbezahlteUeberstunden_XUserID");

                entity.Property(e => e.AusbezahlteStd).HasColumnType("money");

                entity.Property(e => e.BdeausbezahlteUeberstundenXuserTs)
                    .IsRequired()
                    .HasColumnName("BDEAusbezahlteUeberstunden_XUserTS")
                    .IsRowVersion();

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BdeausbezahlteUeberstundenXuser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BDEAusbezahlteUeberstunden_XUser_XUser");
            });

            modelBuilder.Entity<BdeferienanspruchXuser>(entity =>
            {
                entity.ToTable("BDEFerienanspruch_XUser");

                entity.HasIndex(e => new { e.UserId, e.DatumVon })
                    .HasName("IX_BDEFerienanspruch_XUser")
                    .IsUnique();

                entity.Property(e => e.BdeferienanspruchXuserId).HasColumnName("BDEFerienanspruch_XUserID");

                entity.Property(e => e.BdeferienanspruchXuserTs)
                    .IsRequired()
                    .HasColumnName("BDEFerienanspruch_XUserTS")
                    .IsRowVersion();

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.FerienanspruchStdProJahr).HasColumnType("money");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BdeferienanspruchXuser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BDEFerienanspruch_XUser_XUser");
            });

            modelBuilder.Entity<BdeferienkuerzungenXuser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Jahr });

                entity.ToTable("BDEFerienkuerzungen_XUser");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.BdeferienkuerzungenXuserTs)
                    .IsRequired()
                    .HasColumnName("BDEFerienkuerzungen_XUserTS")
                    .IsRowVersion();

                entity.Property(e => e.FerienkuerzungStd).HasColumnType("money");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BdeferienkuerzungenXuser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BDEFerienkuerzungen_XUser_XUser");
            });

            modelBuilder.Entity<Bdeleistung>(entity =>
            {
                entity.ToTable("BDELeistung");

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.BdeleistungsartId);

                entity.HasIndex(e => e.Datum);

                entity.HasIndex(e => e.HistKostenart);

                entity.HasIndex(e => e.HistKostenstelle);

                entity.HasIndex(e => e.HistKostentraeger);

                entity.HasIndex(e => e.HistMandantNr);

                entity.HasIndex(e => e.KostenstelleOrgUnitId);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => e.Verbucht);

                entity.HasIndex(e => e.Visiert);

                entity.HasIndex(e => new { e.Visiert, e.Fakturiert })
                    .HasName("IX_BDELeistung_Fakturierung");

                entity.HasIndex(e => new { e.BaPersonId, e.Datum, e.Dauer });

                entity.HasIndex(e => new { e.Datum, e.Dauer, e.UserId });

                entity.HasIndex(e => new { e.Datum, e.UserId, e.LohnartCode })
                    .HasName("IX_BDELeistung_DatumUserIDLohnartCode");

                entity.HasIndex(e => new { e.UserId, e.Datum, e.Freigegeben })
                    .HasName("IX_BDELeistung_UserIDDatumFreigegeben");

                entity.HasIndex(e => new { e.UserId, e.Datum, e.Visiert })
                    .HasName("IX_BDELeistung_UserIDDatumVisiert");

                entity.HasIndex(e => new { e.BaPersonId, e.Datum, e.Anzahl, e.BdeleistungsartId })
                    .HasName("IX_BDELeistung_BaPersonID_Datum_Anzahl_BDELaID");

                entity.HasIndex(e => new { e.BaPersonId, e.Datum, e.Dauer, e.BdeleistungsartId })
                    .HasName("IX_BDELeistung_BaPersonID_Datum_Dauer_BDELaID");

                entity.HasIndex(e => new { e.Datum, e.Verbucht, e.VerbuchtLd, e.HistMandantNr });

                entity.HasIndex(e => new { e.UserId, e.Datum, e.Verbucht, e.KostenstelleOrgUnitId })
                    .HasName("IX_BDELeistung_UserIDDatumVerbuchtKSTOrgUnitID");

                entity.HasIndex(e => new { e.UserId, e.Datum, e.VerbuchtLd, e.KostenstelleOrgUnitId })
                    .HasName("IX_BDELeistung_UserIDDatumVerbuchtLDKSTOrgUnitID");

                entity.HasIndex(e => new { e.UserId, e.BdeleistungsartId, e.KostenstelleOrgUnitId, e.Datum, e.LohnartCode })
                    .HasName("IX_BDELeistung_UserIDLBDELaIDKSTOrgDatLA");

                entity.HasIndex(e => new { e.Datum, e.Dauer, e.UserId, e.BdeleistungsartId, e.KostenstelleOrgUnitId, e.LohnartCode })
                    .HasName("IX_BDELeistung_DatumDauerUserIDBDELaIDKSTOrgUnitIDLohnArtCode");

                entity.HasIndex(e => new { e.UserId, e.Datum, e.Verbucht, e.KostenstelleOrgUnitId, e.BdeleistungsartId, e.Dauer, e.LohnartCode })
                    .HasName("IX_BDELeistung_UserIDDatumVerbKSTOrgBDELaIDDauerLACode");

                entity.Property(e => e.BdeleistungId).HasColumnName("BDELeistungID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.BdeleistungTs)
                    .IsRequired()
                    .HasColumnName("BDELeistungTS")
                    .IsRowVersion();

                entity.Property(e => e.BdeleistungsartId).HasColumnName("BDELeistungsartID");

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Dauer).HasColumnType("money");

                entity.Property(e => e.KostenstelleOrgUnitId).HasColumnName("KostenstelleOrgUnitID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.Verbucht).HasColumnType("datetime");

                entity.Property(e => e.VerbuchtLd)
                    .HasColumnName("VerbuchtLD")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.Bdeleistung)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_BDELeistung_BaPerson");

                entity.HasOne(d => d.Bdeleistungsart)
                    .WithMany(p => p.Bdeleistung)
                    .HasForeignKey(d => d.BdeleistungsartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BDELeistung_BDELeistungsart");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bdeleistung)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BDELeistung_XUser");
            });

            modelBuilder.Entity<Bdeleistungsart>(entity =>
            {
                entity.ToTable("BDELeistungsart");

                entity.HasIndex(e => e.AuswDienstleistungCode);

                entity.HasIndex(e => new { e.BdeleistungsartId, e.AuswDienstleistungCode });

                entity.Property(e => e.BdeleistungsartId).HasColumnName("BDELeistungsartID");

                entity.Property(e => e.ArtikelNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AuswPiauftragCode).HasColumnName("AuswPIAuftragCode");

                entity.Property(e => e.BdeleistungsartTs)
                    .IsRequired()
                    .HasColumnName("BDELeistungsartTS")
                    .IsRowVersion();

                entity.Property(e => e.Beschreibung)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BezeichnungTid).HasColumnName("BezeichnungTID");

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.Ktrahv)
                    .HasColumnName("KTRAHV")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ktriv)
                    .HasColumnName("KTRIV")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ktrnichtberechtigte)
                    .HasColumnName("KTRNichtberechtigte")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ktrstandard)
                    .HasColumnName("KTRStandard")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LeistungsartTypCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.VerId).HasColumnName("VerID");
            });

            modelBuilder.Entity<BdepensumXuser>(entity =>
            {
                entity.ToTable("BDEPensum_XUser");

                entity.HasIndex(e => new { e.UserId, e.DatumVon })
                    .HasName("IX_BDEPensum_XUser")
                    .IsUnique();

                entity.HasIndex(e => new { e.UserId, e.DatumVon, e.DatumBis, e.PensumProzent })
                    .HasName("IX_BDEPensum_XUser_UserIDDatumVonBisPensumProzent");

                entity.Property(e => e.BdepensumXuserId).HasColumnName("BDEPensum_XUserID");

                entity.Property(e => e.BdepensumXuserTs)
                    .IsRequired()
                    .HasColumnName("BDEPensum_XUserTS")
                    .IsRowVersion();

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BdepensumXuser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BDEPensum_XUser_XUser");
            });

            modelBuilder.Entity<BdesollProTagXuser>(entity =>
            {
                entity.ToTable("BDESollProTag_XUser");

                entity.HasIndex(e => new { e.UserId, e.DatumVon })
                    .HasName("IX_BDESollProTag_XUser")
                    .IsUnique();

                entity.Property(e => e.BdesollProTagXuserId).HasColumnName("BDESollProTag_XUserID");

                entity.Property(e => e.BdesollProTagXuserTs)
                    .IsRequired()
                    .HasColumnName("BDESollProTag_XUserTS")
                    .IsRowVersion();

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.SollStundenProTag).HasColumnType("money");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BdesollProTagXuser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BDESollProTag_XUser_XUser");
            });

            modelBuilder.Entity<BdesollStundenProJahrXuser>(entity =>
            {
                entity.ToTable("BDESollStundenProJahr_XUser");

                entity.HasIndex(e => new { e.UserId, e.Jahr })
                    .HasName("UK_BDESollStundenProJahr_UserID_Jahr");

                entity.Property(e => e.BdesollStundenProJahrXuserId).HasColumnName("BDESollStundenProJahr_XUserID");

                entity.Property(e => e.AprilStd).HasColumnType("money");

                entity.Property(e => e.AugustStd).HasColumnType("money");

                entity.Property(e => e.BdesollStundenProJahrXuserTs)
                    .IsRequired()
                    .HasColumnName("BDESollStundenProJahr_XUserTS")
                    .IsRowVersion();

                entity.Property(e => e.DezemberStd).HasColumnType("money");

                entity.Property(e => e.FebruarStd).HasColumnType("money");

                entity.Property(e => e.JanuarStd).HasColumnType("money");

                entity.Property(e => e.JuliStd).HasColumnType("money");

                entity.Property(e => e.JuniStd).HasColumnType("money");

                entity.Property(e => e.MaerzStd).HasColumnType("money");

                entity.Property(e => e.MaiStd).HasColumnType("money");

                entity.Property(e => e.NovemberStd).HasColumnType("money");

                entity.Property(e => e.OktoberStd).HasColumnType("money");

                entity.Property(e => e.SeptemberStd).HasColumnType("money");

                entity.Property(e => e.TotalStd).HasColumnType("money");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BdesollStundenProJahrXuser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BDESollStundenProJahr_XUser_XUser");
            });

            modelBuilder.Entity<BdeuserGroup>(entity =>
            {
                entity.ToTable("BDEUserGroup");

                entity.Property(e => e.BdeuserGroupId).HasColumnName("BDEUserGroupID");

                entity.Property(e => e.BdeuserGroupTs)
                    .IsRequired()
                    .HasColumnName("BDEUserGroupTS")
                    .IsRowVersion();

                entity.Property(e => e.Beschreibung)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserGroupName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserGroupNameTid).HasColumnName("UserGroupNameTID");
            });

            modelBuilder.Entity<BdeuserGroupBdeleistungsart>(entity =>
            {
                entity.HasKey(e => new { e.BdeuserGroupId, e.BdeleistungsartId });

                entity.ToTable("BDEUserGroup_BDELeistungsart");

                entity.Property(e => e.BdeuserGroupId).HasColumnName("BDEUserGroupID");

                entity.Property(e => e.BdeleistungsartId).HasColumnName("BDELeistungsartID");

                entity.Property(e => e.BdeuserGroupBdeleistungsartTs)
                    .IsRequired()
                    .HasColumnName("BDEUserGroup_BDELeistungsartTS")
                    .IsRowVersion();

                entity.HasOne(d => d.Bdeleistungsart)
                    .WithMany(p => p.BdeuserGroupBdeleistungsart)
                    .HasForeignKey(d => d.BdeleistungsartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BDEUserGroup_BDELeisungsart_BDELeistungsart");

                entity.HasOne(d => d.BdeuserGroup)
                    .WithMany(p => p.BdeuserGroupBdeleistungsart)
                    .HasForeignKey(d => d.BdeuserGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BDEUserGroup_BDELeisungsart_BDEUserGroup");
            });

            modelBuilder.Entity<Bdezeitrechner>(entity =>
            {
                entity.ToTable("BDEZeitrechner");

                entity.Property(e => e.BdezeitrechnerId).HasColumnName("BDEZeitrechnerID");

                entity.Property(e => e.BdezeitrechnerTs)
                    .IsRequired()
                    .HasColumnName("BDEZeitrechnerTS")
                    .IsRowVersion();

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Verbucht).HasColumnType("datetime");

                entity.Property(e => e.ZeitBis).HasColumnType("datetime");

                entity.Property(e => e.ZeitVon).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bdezeitrechner)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BDEZeitrechner_XUser");
            });

            modelBuilder.Entity<Bfsdossier>(entity =>
            {
                entity.ToTable("BFSDossier");

                entity.HasIndex(e => e.BfskatalogVersionId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.BfsdossierId).HasColumnName("BFSDossierID");

                entity.Property(e => e.BfsdossierStatusCode).HasColumnName("BFSDossierStatusCode");

                entity.Property(e => e.BfsdossierTs)
                    .IsRequired()
                    .HasColumnName("BFSDossierTS")
                    .IsRowVersion();

                entity.Property(e => e.BfskatalogVersionId).HasColumnName("BFSKatalogVersionID");

                entity.Property(e => e.BfsleistungsartCode).HasColumnName("BFSLeistungsartCode");

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.ExportDatum).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.ImportDatum).HasColumnType("datetime");

                entity.Property(e => e.PlausibilisierungDatum).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Xml)
                    .HasColumnName("XML")
                    .IsUnicode(false);

                entity.HasOne(d => d.BfskatalogVersion)
                    .WithMany(p => p.Bfsdossier)
                    .HasForeignKey(d => d.BfskatalogVersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BFSDossier_BFSKatalogVersion");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.Bfsdossier)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BFSDossier_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bfsdossier)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_BFSDossier_XUser");
            });

            modelBuilder.Entity<BfsdossierPerson>(entity =>
            {
                entity.ToTable("BFSDossierPerson");

                entity.HasIndex(e => e.BfsdossierPersonId)
                    .HasName("IX_BFSDossierPerson_1");

                entity.HasIndex(e => new { e.BfsdossierId, e.BfspersonCode, e.PersonIndex })
                    .HasName("IX_BFSDossierPerson_BFSDossierIDBFSPersonCOdePersonIndex_Unique")
                    .IsUnique();

                entity.Property(e => e.BfsdossierPersonId).HasColumnName("BFSDossierPersonID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.BfsdossierId).HasColumnName("BFSDossierID");

                entity.Property(e => e.BfsdossierPersonTs)
                    .IsRequired()
                    .HasColumnName("BFSDossierPersonTS")
                    .IsRowVersion();

                entity.Property(e => e.BfspersonCode).HasColumnName("BFSPersonCode");

                entity.Property(e => e.PersonName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.BfsdossierPerson)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BFSDossierPerson_BaPerson");

                entity.HasOne(d => d.Bfsdossier)
                    .WithMany(p => p.BfsdossierPerson)
                    .HasForeignKey(d => d.BfsdossierId)
                    .HasConstraintName("FK_BFSDossierPerson_BFSDossier");
            });

            modelBuilder.Entity<BfsfarbCode>(entity =>
            {
                entity.ToTable("BFSFarbCode");

                entity.Property(e => e.BfsfarbCodeId).HasColumnName("BFSFarbCodeID");

                entity.Property(e => e.BfsfrageId).HasColumnName("BFSFrageID");

                entity.HasOne(d => d.Bfsfrage)
                    .WithMany(p => p.BfsfarbCode)
                    .HasForeignKey(d => d.BfsfrageId)
                    .HasConstraintName("FK_BFSFarbCode_BFSFrage");
            });

            modelBuilder.Entity<Bfsfrage>(entity =>
            {
                entity.ToTable("BFSFrage");

                entity.HasIndex(e => new { e.BfskatalogVersionId, e.Variable, e.ExportNode, e.ExportAttribute })
                    .HasName("IX_BFSFrage_VariableExportNodeExportAttribute_Unique")
                    .IsUnique();

                entity.Property(e => e.BfsfrageId).HasColumnName("BFSFrageID");

                entity.Property(e => e.BfsfeldCode).HasColumnName("BFSFeldCode");

                entity.Property(e => e.Bfsformat)
                    .HasColumnName("BFSFormat")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BfsfrageTs)
                    .IsRequired()
                    .HasColumnName("BFSFrageTS")
                    .IsRowVersion();

                entity.Property(e => e.BfskatalogVersionId).HasColumnName("BFSKatalogVersionID");

                entity.Property(e => e.BfskategorieCode).HasColumnName("BFSKategorieCode");

                entity.Property(e => e.BfsleistungsfilterCodes)
                    .HasColumnName("BFSLeistungsfilterCodes")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bfslovname)
                    .HasColumnName("BFSLOVName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BfspersonCode).HasColumnName("BFSPersonCode");

                entity.Property(e => e.BfsvalidierungCode).HasColumnName("BFSValidierungCode");

                entity.Property(e => e.Editierbar).HasDefaultValueSql("((1))");

                entity.Property(e => e.ExportAttribute)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExportNode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExportPredicate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fffeld)
                    .HasColumnName("FFFeld")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fflovname)
                    .HasColumnName("FFLOVName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ffpkfeld)
                    .HasColumnName("FFPKFeld")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fftabelle)
                    .HasColumnName("FFTabelle")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FilterRegel)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Frage)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.HerkunftBeschreibung).IsUnicode(false);

                entity.Property(e => e.HerkunftSql)
                    .HasColumnName("HerkunftSQL")
                    .IsUnicode(false);

                entity.Property(e => e.HilfeText).IsUnicode(false);

                entity.Property(e => e.HilfeTitel)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateOk).HasColumnName("UpdateOK");

                entity.Property(e => e.Variable)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VariableAntragsteller)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VariableExpandiert)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.BfskatalogVersion)
                    .WithMany(p => p.Bfsfrage)
                    .HasForeignKey(d => d.BfskatalogVersionId)
                    .HasConstraintName("FK_BFSFrage_BFSKatalogVersion");
            });

            modelBuilder.Entity<BfskatalogVersion>(entity =>
            {
                entity.ToTable("BFSKatalogVersion");

                entity.Property(e => e.BfskatalogVersionId)
                    .HasColumnName("BFSKatalogVersionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DossierXml)
                    .HasColumnName("DossierXML")
                    .IsUnicode(false);

                entity.Property(e => e.PlausexVersion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bfslov>(entity =>
            {
                entity.HasKey(e => e.Lovname);

                entity.ToTable("BFSLOV");

                entity.Property(e => e.Lovname)
                    .HasColumnName("LOVName")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Bfslovts)
                    .IsRequired()
                    .HasColumnName("BFSLOVTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<Bfslovcode>(entity =>
            {
                entity.HasKey(e => new { e.Lovname, e.Code });

                entity.ToTable("BFSLOVCode");

                entity.Property(e => e.Lovname)
                    .HasColumnName("LOVName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BfslovcodeTs)
                    .IsRequired()
                    .HasColumnName("BFSLOVCodeTS")
                    .IsRowVersion();

                entity.Property(e => e.Filter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KurzText)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.KurzTextTid).HasColumnName("KurzTextTID");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TextTid).HasColumnName("TextTID");

                entity.HasOne(d => d.LovnameNavigation)
                    .WithMany(p => p.Bfslovcode)
                    .HasForeignKey(d => d.Lovname)
                    .HasConstraintName("FK_BFSLOVCode_BFSLOV");
            });

            modelBuilder.Entity<Bfswert>(entity =>
            {
                entity.ToTable("BFSWert");

                entity.HasIndex(e => new { e.BfsdossierId, e.BfsdossierPersonId, e.BfsfrageId })
                    .HasName("IX_BFSWert")
                    .IsUnique();

                entity.HasIndex(e => new { e.PlausiFehler, e.BfsdossierId, e.BfsfrageId, e.BfsdossierPersonId })
                    .HasName("IX_BFSWert_BFSDossierID_BFSFrageID_BFSDossierPersonID_PlausiFehler");

                entity.Property(e => e.BfswertId).HasColumnName("BFSWertID");

                entity.Property(e => e.BfsdossierId).HasColumnName("BFSDossierID");

                entity.Property(e => e.BfsdossierPersonId).HasColumnName("BFSDossierPersonID");

                entity.Property(e => e.BfsfrageId).HasColumnName("BFSFrageID");

                entity.Property(e => e.BfswertTs)
                    .IsRequired()
                    .HasColumnName("BFSWertTS")
                    .IsRowVersion();

                entity.Property(e => e.PlausiFehler).HasColumnType("varchar(max)");

                entity.HasOne(d => d.Bfsdossier)
                    .WithMany(p => p.Bfswert)
                    .HasForeignKey(d => d.BfsdossierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BFSWert_BFSDossier");

                entity.HasOne(d => d.BfsdossierPerson)
                    .WithMany(p => p.Bfswert)
                    .HasForeignKey(d => d.BfsdossierPersonId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BFSWert_BFSDossierPerson");

                entity.HasOne(d => d.Bfsfrage)
                    .WithMany(p => p.Bfswert)
                    .HasForeignKey(d => d.BfsfrageId)
                    .HasConstraintName("FK_BFSWert_BFSFrage");
            });

            modelBuilder.Entity<BgAuszahlungPerson>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.BaZahlungswegId);

                entity.HasIndex(e => e.BgPositionId);

                entity.HasIndex(e => e.BgZahlungsmodusId);

                entity.HasIndex(e => new { e.BaPersonId, e.BgPositionId })
                    .HasName("IX_BgAuszahlungPerson_BaPersonIDBgPositionID_Unique")
                    .IsUnique();

                entity.HasIndex(e => new { e.BgPositionId, e.BgAuszahlungPersonId, e.BaPersonId });

                entity.Property(e => e.BgAuszahlungPersonId).HasColumnName("BgAuszahlungPersonID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.BaZahlungswegId).HasColumnName("BaZahlungswegID");

                entity.Property(e => e.BgAuszahlungPersonTs)
                    .IsRequired()
                    .HasColumnName("BgAuszahlungPersonTS")
                    .IsRowVersion();

                entity.Property(e => e.BgAuszahlungsTerminCode).HasDefaultValueSql("(1)");

                entity.Property(e => e.BgPositionId).HasColumnName("BgPositionID");

                entity.Property(e => e.BgWochentagCodes)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BgZahlungsmodusId).HasColumnName("BgZahlungsmodusID");

                entity.Property(e => e.MitteilungZeile1)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MitteilungZeile2)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MitteilungZeile3)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MitteilungZeile4)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenzNummer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zahlungsgrund)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.BgAuszahlungPerson)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_BgAuszahlungPerson_BaPerson");

                entity.HasOne(d => d.BaZahlungsweg)
                    .WithMany(p => p.BgAuszahlungPerson)
                    .HasForeignKey(d => d.BaZahlungswegId)
                    .HasConstraintName("FK_BgAuszahlungPerson_BaZahlungsweg");

                entity.HasOne(d => d.BgPosition)
                    .WithMany(p => p.BgAuszahlungPerson)
                    .HasForeignKey(d => d.BgPositionId)
                    .HasConstraintName("FK_BgAuszahlungPerson_BgPosition");

                entity.HasOne(d => d.BgZahlungsmodus)
                    .WithMany(p => p.BgAuszahlungPerson)
                    .HasForeignKey(d => d.BgZahlungsmodusId)
                    .HasConstraintName("FK_BgAuszahlungPerson_BgZahlungsmodus");
            });

            modelBuilder.Entity<BgAuszahlungPersonTermin>(entity =>
            {
                entity.HasIndex(e => new { e.BgAuszahlungPersonId, e.Datum });

                entity.Property(e => e.BgAuszahlungPersonTerminId).HasColumnName("BgAuszahlungPersonTerminID");

                entity.Property(e => e.BgAuszahlungPersonId).HasColumnName("BgAuszahlungPersonID");

                entity.Property(e => e.BgAuszahlungPersonTerminTs)
                    .IsRequired()
                    .HasColumnName("BgAuszahlungPersonTerminTS")
                    .IsRowVersion();

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.HasOne(d => d.BgAuszahlungPerson)
                    .WithMany(p => p.BgAuszahlungPersonTermin)
                    .HasForeignKey(d => d.BgAuszahlungPersonId)
                    .HasConstraintName("FK_BgAuszahlungPersonTermin_BgAuszahlungPerson");
            });

            modelBuilder.Entity<BgBewilligung>(entity =>
            {
                entity.HasIndex(e => e.BgPositionId);

                entity.HasIndex(e => new { e.BgBudgetId, e.Datum })
                    .HasName("IX_BgBewilligung")
                    .ForSqlServerIsClustered();

                entity.HasIndex(e => new { e.BgFinanzplanId, e.Datum })
                    .HasName("IX_BgBewilligung_ShFinanzPlanID");

                entity.Property(e => e.BgBewilligungId).HasColumnName("BgBewilligungID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.BgBewilligungTs)
                    .IsRequired()
                    .HasColumnName("BgBewilligungTS")
                    .IsRowVersion();

                entity.Property(e => e.BgBudgetId).HasColumnName("BgBudgetID");

                entity.Property(e => e.BgFinanzplanId).HasColumnName("BgFinanzplanID");

                entity.Property(e => e.BgPositionId).HasColumnName("BgPositionID");

                entity.Property(e => e.Datum)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrgUnitIdChefZustaendig).HasColumnName("OrgUnitID_ChefZustaendig");

                entity.Property(e => e.PerDatum).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserIdAn).HasColumnName("UserID_An");

                entity.Property(e => e.UserIdZustaendig).HasColumnName("UserID_Zustaendig");

                entity.HasOne(d => d.BgBudget)
                    .WithMany(p => p.BgBewilligung)
                    .HasForeignKey(d => d.BgBudgetId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BgBewilligung_BgBudget");

                entity.HasOne(d => d.BgFinanzplan)
                    .WithMany(p => p.BgBewilligung)
                    .HasForeignKey(d => d.BgFinanzplanId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BgBewilligung_BgFinanzplan");

                entity.HasOne(d => d.BgPosition)
                    .WithMany(p => p.BgBewilligung)
                    .HasForeignKey(d => d.BgPositionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BgBewilligung_BgPosition");

                entity.HasOne(d => d.OrgUnitIdChefZustaendigNavigation)
                    .WithMany(p => p.BgBewilligung)
                    .HasForeignKey(d => d.OrgUnitIdChefZustaendig)
                    .HasConstraintName("FK_BgBewilligung_XOrgUnit_An");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BgBewilligungUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BgBewilligung_User");

                entity.HasOne(d => d.UserIdAnNavigation)
                    .WithMany(p => p.BgBewilligungUserIdAnNavigation)
                    .HasForeignKey(d => d.UserIdAn)
                    .HasConstraintName("FK_BgBewilligung_User_An");

                entity.HasOne(d => d.UserIdZustaendigNavigation)
                    .WithMany(p => p.BgBewilligungUserIdZustaendigNavigation)
                    .HasForeignKey(d => d.UserIdZustaendig)
                    .HasConstraintName("FK_BgBewilligung_XUser_Zustaendig");
            });

            modelBuilder.Entity<BgBudget>(entity =>
            {
                entity.HasIndex(e => e.BgBudgetTs);

                entity.HasIndex(e => e.BgFinanzplanId);

                entity.HasIndex(e => new { e.BgFinanzplanId, e.BgBudgetId, e.MasterBudget });

                entity.Property(e => e.BgBudgetId).HasColumnName("BgBudgetID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.BgBudgetTs)
                    .IsRequired()
                    .HasColumnName("BgBudgetTS")
                    .IsRowVersion();

                entity.Property(e => e.BgFinanzplanId).HasColumnName("BgFinanzplanID");

                entity.Property(e => e.OldId).HasColumnName("OldID");

                entity.HasOne(d => d.BgFinanzplan)
                    .WithMany(p => p.BgBudget)
                    .HasForeignKey(d => d.BgFinanzplanId)
                    .HasConstraintName("FK_BgBudget_BgFinanzplan");
            });

            modelBuilder.Entity<BgDokument>(entity =>
            {
                entity.HasIndex(e => e.BgBudgetId);

                entity.HasIndex(e => e.BgFinanzplanId);

                entity.HasIndex(e => e.BgPositionId);

                entity.Property(e => e.BgDokumentId).HasColumnName("BgDokumentID");

                entity.Property(e => e.BgBudgetId).HasColumnName("BgBudgetID");

                entity.Property(e => e.BgDocumentTs)
                    .IsRequired()
                    .HasColumnName("BgDocumentTS")
                    .IsRowVersion();

                entity.Property(e => e.BgFinanzplanId).HasColumnName("BgFinanzplanID");

                entity.Property(e => e.BgPositionId).HasColumnName("BgPositionID");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.Stichwort)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.BgBudget)
                    .WithMany(p => p.BgDokument)
                    .HasForeignKey(d => d.BgBudgetId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BgDokument_BgBudget");

                entity.HasOne(d => d.BgFinanzplan)
                    .WithMany(p => p.BgDokument)
                    .HasForeignKey(d => d.BgFinanzplanId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BgDokument_BgFinanzplan");

                entity.HasOne(d => d.BgPosition)
                    .WithMany(p => p.BgDokument)
                    .HasForeignKey(d => d.BgPositionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BgDokument_BgPosition");
            });

            modelBuilder.Entity<BgFinanzplan>(entity =>
            {
                entity.HasIndex(e => e.BgFinanzplanTs);

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.BgFinanzplanId).HasColumnName("BgFinanzplanID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.BgBewilligungStatusCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.BgFinanzplanTs)
                    .IsRequired()
                    .HasColumnName("BgFinanzplanTS")
                    .IsRowVersion();

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.GeplantBis).HasColumnType("datetime");

                entity.Property(e => e.GeplantVon).HasColumnType("datetime");

                entity.Property(e => e.WhHilfeTypCode).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.BgFinanzplan)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BgFinanzplan_FaLeistung");
            });

            modelBuilder.Entity<BgFinanzplanBaPerson>(entity =>
            {
                entity.HasKey(e => new { e.BgFinanzplanId, e.BaPersonId });

                entity.ToTable("BgFinanzplan_BaPerson");

                entity.HasIndex(e => new { e.BaPersonId, e.IstUnterstuetzt })
                    .HasName("IX_BgFinanzplan_BaPerson");

                entity.HasIndex(e => new { e.BaPersonId, e.BgFinanzplanId, e.IstUnterstuetzt })
                    .HasName("IX_BgFinanzplan_BaPerson_BaPersonID");

                entity.Property(e => e.BgFinanzplanId).HasColumnName("BgFinanzplanID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.AuslandChBis).HasColumnType("datetime");

                entity.Property(e => e.AuslandChMeldungAm).HasColumnType("datetime");

                entity.Property(e => e.AuslandChReferenzNrBund)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AuslandChVon).HasColumnType("datetime");

                entity.Property(e => e.BaZahlungswegId).HasColumnName("BaZahlungswegID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.BgFinanzplanBaPersonTs)
                    .IsRequired()
                    .HasColumnName("BgFinanzplan_BaPersonTS")
                    .IsRowVersion();

                entity.Property(e => e.BurgergemeindeId).HasColumnName("BurgergemeindeID");

                entity.Property(e => e.IstUnterstuetzt).HasDefaultValueSql("((1))");

                entity.Property(e => e.KbKostenstelleId).HasColumnName("KbKostenstelleID");

                entity.Property(e => e.KbKostenstelleIdKvg).HasColumnName("KbKostenstelleID_KVG");

                entity.Property(e => e.NrmVerrechnungBis).HasColumnType("datetime");

                entity.Property(e => e.NrmVerrechnungVon).HasColumnType("datetime");

                entity.Property(e => e.PrsNummerHeimat)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PrsNummerKanton)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenzNummer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShNrmVerrechnungsbasisId)
                    .HasColumnName("ShNrmVerrechnungsbasisID")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.BgFinanzplanBaPerson)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BgFinanzplan_BaPerson_BaPerson");

                entity.HasOne(d => d.BaZahlungsweg)
                    .WithMany(p => p.BgFinanzplanBaPerson)
                    .HasForeignKey(d => d.BaZahlungswegId)
                    .HasConstraintName("FK_BgFinanzplan_BaPerson_BaZahlungsweg");

                entity.HasOne(d => d.BgFinanzplan)
                    .WithMany(p => p.BgFinanzplanBaPerson)
                    .HasForeignKey(d => d.BgFinanzplanId)
                    .HasConstraintName("FK_BgFinanzplan_BaPerson_BgFinanzplan");

                entity.HasOne(d => d.Burgergemeinde)
                    .WithMany(p => p.BgFinanzplanBaPerson)
                    .HasForeignKey(d => d.BurgergemeindeId)
                    .HasConstraintName("FK_BgFinanzplan_BaPerson_BaGemeinde");

                entity.HasOne(d => d.KbKostenstelle)
                    .WithMany(p => p.BgFinanzplanBaPersonKbKostenstelle)
                    .HasForeignKey(d => d.KbKostenstelleId)
                    .HasConstraintName("FK_BgFinanzplan_BaPerson_KbKostenstelle");

                entity.HasOne(d => d.KbKostenstelleIdKvgNavigation)
                    .WithMany(p => p.BgFinanzplanBaPersonKbKostenstelleIdKvgNavigation)
                    .HasForeignKey(d => d.KbKostenstelleIdKvg)
                    .HasConstraintName("FK_BgFinanzplan_BaPerson_KbKostenstelle_KVG");
            });

            modelBuilder.Entity<BgGruppeBfsfrage>(entity =>
            {
                entity.ToTable("BgGruppe_BFSFrage");

                entity.Property(e => e.BgGruppeBfsfrageId).HasColumnName("BgGruppe_BFSFrageID");

                entity.Property(e => e.Variable)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BgKostenart>(entity =>
            {
                entity.HasIndex(e => e.ModulId);

                entity.Property(e => e.BgKostenartId).HasColumnName("BgKostenartID");

                entity.Property(e => e.BaWvzeileCode).HasColumnName("BaWVZeileCode");

                entity.Property(e => e.BgKostenartTs)
                    .IsRequired()
                    .HasColumnName("BgKostenartTS")
                    .IsRowVersion();

                entity.Property(e => e.KontoNr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModulId)
                    .HasColumnName("ModulID")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameTid).HasColumnName("NameTID");

                entity.HasOne(d => d.Modul)
                    .WithMany(p => p.BgKostenart)
                    .HasForeignKey(d => d.ModulId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BgKostenart_XModul");
            });

            modelBuilder.Entity<BgKostenartWhGefKategorie>(entity =>
            {
                entity.ToTable("BgKostenart_WhGefKategorie");

                entity.HasIndex(e => e.BgKostenartId);

                entity.HasIndex(e => e.WhGefKategorieId);

                entity.Property(e => e.BgKostenartWhGefKategorieId).HasColumnName("BgKostenart_WhGefKategorieID");

                entity.Property(e => e.BgKostenartId).HasColumnName("BgKostenartID");

                entity.Property(e => e.BgKostenartWhGefKategorieTs)
                    .IsRequired()
                    .HasColumnName("BgKostenart_WhGefKategorieTS")
                    .IsRowVersion();

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WhGefKategorieId).HasColumnName("WhGefKategorieID");

                entity.HasOne(d => d.BgKostenart)
                    .WithMany(p => p.BgKostenartWhGefKategorie)
                    .HasForeignKey(d => d.BgKostenartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BgKostenart_WhGefKategorie_BgKostenart");

                entity.HasOne(d => d.WhGefKategorie)
                    .WithMany(p => p.BgKostenartWhGefKategorie)
                    .HasForeignKey(d => d.WhGefKategorieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BgKostenart_WhGefKategorie_WhGefKategorie");
            });

            modelBuilder.Entity<BgPosition>(entity =>
            {
                entity.HasIndex(e => e.BaInstitutionId);

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.BgBudgetId);

                entity.HasIndex(e => e.BgPositionIdAutoForderung);

                entity.HasIndex(e => e.BgPositionIdCopyOf);

                entity.HasIndex(e => e.BgPositionIdParent);

                entity.HasIndex(e => e.BgPositionTs);

                entity.HasIndex(e => e.BgSpezkontoId);

                entity.HasIndex(e => e.ErstelltUserId);

                entity.HasIndex(e => e.MutiertUserId);

                entity.HasIndex(e => e.ShBelegId);

                entity.HasIndex(e => new { e.BgBudgetId, e.BgPositionId })
                    .HasName("IX_BgPosition")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.HasIndex(e => new { e.BgPositionId, e.BgPositionIdParent, e.BgBewilligungStatusCode });

                entity.Property(e => e.BgPositionId).HasColumnName("BgPositionID");

                entity.Property(e => e.Abzug)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.BemerkungSaldierung).IsUnicode(false);

                entity.Property(e => e.Betrag)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BetragAnfrage).HasColumnType("money");

                entity.Property(e => e.BetragEff).HasColumnType("money");

                entity.Property(e => e.BgAuszahlungId).HasColumnName("BgAuszahlungID");

                entity.Property(e => e.BgBewilligungStatusCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.BgBudgetId).HasColumnName("BgBudgetID");

                entity.Property(e => e.BgPositionIdAutoForderung).HasColumnName("BgPositionID_AutoForderung");

                entity.Property(e => e.BgPositionIdCopyOf).HasColumnName("BgPositionID_CopyOf");

                entity.Property(e => e.BgPositionIdParent).HasColumnName("BgPositionID_Parent");

                entity.Property(e => e.BgPositionTs)
                    .IsRequired()
                    .HasColumnName("BgPositionTS")
                    .IsRowVersion();

                entity.Property(e => e.BgPositionsartId).HasColumnName("BgPositionsartID");

                entity.Property(e => e.BgSpezkontoId).HasColumnName("BgSpezkontoID");

                entity.Property(e => e.Buchungstext)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumEff).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.DebitorBaPersonId).HasColumnName("DebitorBaPersonID");

                entity.Property(e => e.ErstelltDatum).HasColumnType("datetime");

                entity.Property(e => e.ErstelltUserId).HasColumnName("ErstelltUserID");

                entity.Property(e => e.FaelligAm).HasColumnType("datetime");

                entity.Property(e => e.MaxBeitragSd)
                    .HasColumnName("MaxBeitragSD")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((999999999))");

                entity.Property(e => e.MutiertDatum).HasColumnType("datetime");

                entity.Property(e => e.MutiertUserId).HasColumnName("MutiertUserID");

                entity.Property(e => e.OldId).HasColumnName("OldID");

                entity.Property(e => e.RechnungDatum).HasColumnType("datetime");

                entity.Property(e => e.Reduktion)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ShBelegId).HasColumnName("ShBelegID");

                entity.Property(e => e.VerwPeriodeBis).HasColumnType("datetime");

                entity.Property(e => e.VerwPeriodeVon).HasColumnType("datetime");

                entity.Property(e => e.VerwaltungSd).HasColumnName("VerwaltungSD");

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.BgPosition)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .HasConstraintName("FK_BgPosition_BaInstitution");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.BgPositionBaPerson)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_BgPosition_BaPerson");

                entity.HasOne(d => d.BgBudget)
                    .WithMany(p => p.BgPosition)
                    .HasForeignKey(d => d.BgBudgetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BgPosition_BgBudget");

                entity.HasOne(d => d.BgPositionIdAutoForderungNavigation)
                    .WithMany(p => p.InverseBgPositionIdAutoForderungNavigation)
                    .HasForeignKey(d => d.BgPositionIdAutoForderung)
                    .HasConstraintName("FK_BgPosition_AutoForderung");

                entity.HasOne(d => d.BgPositionIdCopyOfNavigation)
                    .WithMany(p => p.InverseBgPositionIdCopyOfNavigation)
                    .HasForeignKey(d => d.BgPositionIdCopyOf)
                    .HasConstraintName("FK_BgPosition_BgPosition_CopyOf");

                entity.HasOne(d => d.BgPositionIdParentNavigation)
                    .WithMany(p => p.InverseBgPositionIdParentNavigation)
                    .HasForeignKey(d => d.BgPositionIdParent)
                    .HasConstraintName("FK_BgPosition_BgPosition");

                entity.HasOne(d => d.BgPositionsart)
                    .WithMany(p => p.BgPosition)
                    .HasForeignKey(d => d.BgPositionsartId)
                    .HasConstraintName("FK_BgPosition_BgPositionsart");

                entity.HasOne(d => d.BgSpezkonto)
                    .WithMany(p => p.BgPosition)
                    .HasForeignKey(d => d.BgSpezkontoId)
                    .HasConstraintName("FK_BgPosition_BgSpezkonto");

                entity.HasOne(d => d.DebitorBaPerson)
                    .WithMany(p => p.BgPositionDebitorBaPerson)
                    .HasForeignKey(d => d.DebitorBaPersonId);

                entity.HasOne(d => d.ErstelltUser)
                    .WithMany(p => p.BgPositionErstelltUser)
                    .HasForeignKey(d => d.ErstelltUserId)
                    .HasConstraintName("FK_BgPosition_XUser");

                entity.HasOne(d => d.MutiertUser)
                    .WithMany(p => p.BgPositionMutiertUser)
                    .HasForeignKey(d => d.MutiertUserId)
                    .HasConstraintName("FK_BgPosition_XUser1");
            });

            modelBuilder.Entity<BgPositionsart>(entity =>
            {
                entity.HasIndex(e => e.BgKostenartId);

                entity.HasIndex(e => e.ModulId);

                entity.HasIndex(e => new { e.BgPositionsartId, e.BgKategorieCode })
                    .HasName("IX_BgPositionsart_BgPositionsartIDBgKategorieCode_Unique")
                    .IsUnique();

                entity.Property(e => e.BgPositionsartId).HasColumnName("BgPositionsartID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.BgKostenartId).HasColumnName("BgKostenartID");

                entity.Property(e => e.BgPositionsartIdCopyOf).HasColumnName("BgPositionsartID_CopyOf");

                entity.Property(e => e.BgPositionsartTs)
                    .IsRequired()
                    .HasColumnName("BgPositionsartTS")
                    .IsRowVersion();

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.HilfeText).IsUnicode(false);

                entity.Property(e => e.MasterbudgetEditMask)
                    .HasColumnName("Masterbudget_EditMask")
                    .HasDefaultValueSql("((16773120))");

                entity.Property(e => e.ModulId)
                    .HasColumnName("ModulID")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.MonatsbudgetEditMask)
                    .HasColumnName("Monatsbudget_EditMask")
                    .HasDefaultValueSql("((4095))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameTid).HasColumnName("NameTID");

                entity.Property(e => e.ProUe).HasColumnName("ProUE");

                entity.Property(e => e.SqlRichtlinie)
                    .HasColumnName("sqlRichtlinie")
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.VarName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Verrechenbar).HasDefaultValueSql("((1))");

                entity.Property(e => e.VerwaltungSdDefault).HasColumnName("VerwaltungSD_Default");

                entity.HasOne(d => d.BgKostenart)
                    .WithMany(p => p.BgPositionsart)
                    .HasForeignKey(d => d.BgKostenartId)
                    .HasConstraintName("FK_BgPositionsart_BgKostenart");

                entity.HasOne(d => d.Modul)
                    .WithMany(p => p.BgPositionsart)
                    .HasForeignKey(d => d.ModulId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BgPositionsart_XModul");
            });

            modelBuilder.Entity<BgPositionsartBuchungstext>(entity =>
            {
                entity.Property(e => e.BgPositionsartBuchungstextId).HasColumnName("BgPositionsartBuchungstextID");

                entity.Property(e => e.BgPositionsartBuchungstextTs)
                    .IsRequired()
                    .HasColumnName("BgPositionsartBuchungstextTS")
                    .IsRowVersion();

                entity.Property(e => e.BgPositionsartId).HasColumnName("BgPositionsartID");

                entity.Property(e => e.BgPositionsartIdUseText).HasColumnName("BgPositionsartID_UseText");

                entity.Property(e => e.Buchungstext)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BgPositionsart)
                    .WithMany(p => p.BgPositionsartBuchungstextBgPositionsart)
                    .HasForeignKey(d => d.BgPositionsartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BgPositionsartBuchungstext_BgPositionsart");

                entity.HasOne(d => d.BgPositionsartIdUseTextNavigation)
                    .WithMany(p => p.BgPositionsartBuchungstextBgPositionsartIdUseTextNavigation)
                    .HasForeignKey(d => d.BgPositionsartIdUseText)
                    .HasConstraintName("FK_BgPositionsartBuchungstext_BgPositionsart_UseText");
            });

            modelBuilder.Entity<BgSpezkonto>(entity =>
            {
                entity.HasIndex(e => e.BaInstitutionId);

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.BgKostenartId);

                entity.HasIndex(e => e.BgPositionsartId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.BgSpezkontoId).HasColumnName("BgSpezkontoID");

                entity.Property(e => e.AbschlussBegruendung).IsUnicode(false);

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.BetragProMonat).HasColumnType("money");

                entity.Property(e => e.BgKostenartId).HasColumnName("BgKostenartID");

                entity.Property(e => e.BgPositionsartId).HasColumnName("BgPositionsartID");

                entity.Property(e => e.BgSpezkontoTs)
                    .IsRequired()
                    .HasColumnName("BgSpezkontoTS")
                    .IsRowVersion();

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErsterMonat).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KuerzungAnteilGbl)
                    .HasColumnName("KuerzungAnteilGBL")
                    .HasColumnType("money");

                entity.Property(e => e.NameSpezkonto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OldId).HasColumnName("OldID");

                entity.Property(e => e.StartSaldo)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.0000))");

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.BgSpezkonto)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .HasConstraintName("FK_BgSpezkonto_BaInstitution");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.BgSpezkonto)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_BgSpezkonto_BaPerson");

                entity.HasOne(d => d.BgKostenart)
                    .WithMany(p => p.BgSpezkonto)
                    .HasForeignKey(d => d.BgKostenartId)
                    .HasConstraintName("FK_BgSpezkonto_BgKostenart");

                entity.HasOne(d => d.BgPositionsart)
                    .WithMany(p => p.BgSpezkonto)
                    .HasForeignKey(d => d.BgPositionsartId)
                    .HasConstraintName("FK_BgSpezkonto_BgPositionsart");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.BgSpezkonto)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_BgSpezkonto_FaLeistung");
            });

            modelBuilder.Entity<BgSpezkontoAbschluss>(entity =>
            {
                entity.Property(e => e.BgSpezkontoAbschlussId).HasColumnName("BgSpezkontoAbschlussID");

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.BgSpezkontoAbschlussTs)
                    .IsRequired()
                    .HasColumnName("BgSpezkontoAbschlussTS")
                    .IsRowVersion();

                entity.Property(e => e.BgSpezkontoId).HasColumnName("BgSpezkontoID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.BgSpezkonto)
                    .WithMany(p => p.BgSpezkontoAbschluss)
                    .HasForeignKey(d => d.BgSpezkontoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BgSpezkontoAbschluss_BgSpezkonto");
            });

            modelBuilder.Entity<BgZahlungsmodus>(entity =>
            {
                entity.HasIndex(e => e.BaZahlungswegId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.BgZahlungsmodusId).HasColumnName("BgZahlungsmodusID");

                entity.Property(e => e.BaZahlungswegId).HasColumnName("BaZahlungswegID");

                entity.Property(e => e.BgZahlungsmodusTs)
                    .IsRequired()
                    .HasColumnName("BgZahlungsmodusTS")
                    .IsRowVersion();

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KontoKlient).HasDefaultValueSql("(0)");

                entity.Property(e => e.NameZahlungsmodus)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OldId).HasColumnName("OldID");

                entity.Property(e => e.ReferenzNummer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaZahlungsweg)
                    .WithMany(p => p.BgZahlungsmodus)
                    .HasForeignKey(d => d.BaZahlungswegId)
                    .HasConstraintName("FK_BgZahlungsmodus_BaZahlungsweg");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.BgZahlungsmodus)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_BgZahlungsmodus_FaLeistung");
            });

            modelBuilder.Entity<BgZahlungsmodusTermin>(entity =>
            {
                entity.HasIndex(e => e.BgZahlungsmodusId);

                entity.Property(e => e.BgZahlungsmodusTerminId).HasColumnName("BgZahlungsmodusTerminID");

                entity.Property(e => e.BetragGleich).HasDefaultValueSql("(1)");

                entity.Property(e => e.BgZahlungsmodusId).HasColumnName("BgZahlungsmodusID");

                entity.Property(e => e.BgZahlungsmodusTerminTs)
                    .IsRequired()
                    .HasColumnName("BgZahlungsmodusTerminTS")
                    .IsRowVersion();

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.ImVormonat).HasDefaultValueSql("(0)");

                entity.Property(e => e.NMonatlich)
                    .HasColumnName("nMonatlich")
                    .HasDefaultValueSql("(1)");

                entity.HasOne(d => d.BgZahlungsmodus)
                    .WithMany(p => p.BgZahlungsmodusTermin)
                    .HasForeignKey(d => d.BgZahlungsmodusId)
                    .HasConstraintName("FK_BgZahlungsmodusTermin_BgZahlungsmodus");
            });

            modelBuilder.Entity<DynaField>(entity =>
            {
                entity.HasIndex(e => e.FieldName);

                entity.HasIndex(e => e.MaskName);

                entity.Property(e => e.DynaFieldId).HasColumnName("DynaFieldID");

                entity.Property(e => e.AppCode)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultValue)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayText)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayTextTid).HasColumnName("DisplayTextTID");

                entity.Property(e => e.DynaFieldTs)
                    .IsRequired()
                    .HasColumnName("DynaFieldTS")
                    .IsRowVersion();

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GridColTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GridColTitleTid).HasColumnName("GridColTitleTID");

                entity.Property(e => e.Lovname)
                    .HasColumnName("LOVName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MaskName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sql)
                    .HasColumnName("SQL")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.TabName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaskNameNavigation)
                    .WithMany(p => p.DynaField)
                    .HasForeignKey(d => d.MaskName)
                    .HasConstraintName("FK_DynaField_DynaMask");
            });

            modelBuilder.Entity<DynaMask>(entity =>
            {
                entity.HasKey(e => e.MaskName);

                entity.HasIndex(e => e.FaPhaseCode);

                entity.HasIndex(e => e.ParentMaskName);

                entity.HasIndex(e => e.ParentPosition);

                entity.Property(e => e.MaskName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValueSql("(0)");

                entity.Property(e => e.AppCode)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayText)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayTextTid).HasColumnName("DisplayTextTID");

                entity.Property(e => e.DynaMaskTs)
                    .IsRequired()
                    .HasColumnName("DynaMaskTS")
                    .IsRowVersion();

                entity.Property(e => e.IconId).HasColumnName("IconID");

                entity.Property(e => e.ModulId).HasColumnName("ModulID");

                entity.Property(e => e.ParentMaskName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.System).HasDefaultValueSql("(0)");

                entity.Property(e => e.TabNames)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Modul)
                    .WithMany(p => p.DynaMask)
                    .HasForeignKey(d => d.ModulId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DynaMask_XModul");
            });

            modelBuilder.Entity<DynaValue>(entity =>
            {
                entity.HasIndex(e => e.DynaFieldId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.FaPhaseId);

                entity.HasIndex(e => new { e.FaLeistungId, e.DynaValueId, e.DynaFieldId, e.GridRowId });

                entity.Property(e => e.DynaValueId).HasColumnName("DynaValueID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.DynaFieldId).HasColumnName("DynaFieldID");

                entity.Property(e => e.DynaValueTs)
                    .IsRequired()
                    .HasColumnName("DynaValueTS")
                    .IsRowVersion();

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FaPhaseId).HasColumnName("FaPhaseID");

                entity.Property(e => e.GridRowId).HasColumnName("GridRowID");

                entity.Property(e => e.ValueText).IsUnicode(false);

                entity.HasOne(d => d.DynaField)
                    .WithMany(p => p.DynaValue)
                    .HasForeignKey(d => d.DynaFieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DynaValue_DynaField");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.DynaValue)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_DynaValue_FaLeistung");

                entity.HasOne(d => d.FaPhase)
                    .WithMany(p => p.DynaValue)
                    .HasForeignKey(d => d.FaPhaseId)
                    .HasConstraintName("FK_DynaValue_FaPhase");
            });

            modelBuilder.Entity<FaAktennotizen>(entity =>
            {
                entity.HasKey(e => e.FaAktennotizId);

                entity.Property(e => e.FaAktennotizId).HasColumnName("FaAktennotizID");

                entity.Property(e => e.BaPersonIds)
                    .HasColumnName("BaPersonIDs")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BesprechungThemaText1)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BesprechungThemaText2)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BesprechungThemaText3)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BesprechungThemaText4)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BesprechungZiel1)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BesprechungZiel2)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BesprechungZiel3)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BesprechungZiel4)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.FaAktennotizTs)
                    .IsRequired()
                    .HasColumnName("FaAktennotizTS")
                    .IsRowVersion();

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FaThemaCodes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InhaltRtf)
                    .HasColumnName("InhaltRTF")
                    .IsUnicode(false);

                entity.Property(e => e.Kontaktpartner)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pendenz1)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pendenz2)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pendenz3)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pendenz4)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Stichwort)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Zeit).HasColumnType("datetime");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.FaAktennotizen)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaAktennotizen_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FaAktennotizen)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_FaAktennotizen_XUser");
            });

            modelBuilder.Entity<FaDokumentAblage>(entity =>
            {
                entity.HasIndex(e => e.BaInstitutionIdAdressat);

                entity.HasIndex(e => e.BaPersonIdAdressat);

                entity.HasIndex(e => e.DocumentId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.FaDokumentAblageId).HasColumnName("FaDokumentAblageID");

                entity.Property(e => e.BaInstitutionIdAdressat).HasColumnName("BaInstitutionID_Adressat");

                entity.Property(e => e.BaPersonIdAdressat).HasColumnName("BaPersonID_Adressat");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumErstellung).HasColumnType("datetime");

                entity.Property(e => e.DatumGueltigBis).HasColumnType("datetime");

                entity.Property(e => e.DatumGueltigVon).HasColumnType("datetime");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.FaDokumentAblageTs)
                    .IsRequired()
                    .HasColumnName("FaDokumentAblageTS")
                    .IsRowVersion();

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FaThemaDokAblageCodes)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stichwort).IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.BaInstitutionIdAdressatNavigation)
                    .WithMany(p => p.FaDokumentAblage)
                    .HasForeignKey(d => d.BaInstitutionIdAdressat)
                    .HasConstraintName("FK_FaDokumentAblage_BaInstitution");

                entity.HasOne(d => d.BaPersonIdAdressatNavigation)
                    .WithMany(p => p.FaDokumentAblage)
                    .HasForeignKey(d => d.BaPersonIdAdressat)
                    .HasConstraintName("FK_FaDokumentAblage_BaPerson");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.FaDokumentAblage)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaDokumentAblage_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FaDokumentAblage)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaDokumentAblage_XUser");
            });

            modelBuilder.Entity<FaDokumentAblageBaPerson>(entity =>
            {
                entity.ToTable("FaDokumentAblage_BaPerson");

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.FaDokumentAblageId);

                entity.HasIndex(e => new { e.BaPersonId, e.FaDokumentAblageId })
                    .HasName("UK_FaDokumentAblage_BaPerson_BaPersonID_FaDokumentID")
                    .IsUnique();

                entity.HasIndex(e => new { e.FaDokumentAblageId, e.BaPersonId });

                entity.Property(e => e.FaDokumentAblageBaPersonId).HasColumnName("FaDokumentAblage_BaPersonID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaDokumentAblageBaPersonTs)
                    .IsRequired()
                    .HasColumnName("FaDokumentAblage_BaPersonTS")
                    .IsRowVersion();

                entity.Property(e => e.FaDokumentAblageId).HasColumnName("FaDokumentAblageID");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.FaDokumentAblageBaPerson)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaDokumentAblage_BaPerson_BaPerson");

                entity.HasOne(d => d.FaDokumentAblage)
                    .WithMany(p => p.FaDokumentAblageBaPerson)
                    .HasForeignKey(d => d.FaDokumentAblageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaDokumentAblage_BaPerson_FaDokumentAblage");
            });

            modelBuilder.Entity<FaDokumente>(entity =>
            {
                entity.HasIndex(e => e.BaInstitutionIdAdressat);

                entity.HasIndex(e => e.BaPersonIdAdressat);

                entity.HasIndex(e => e.BaPersonIdLt);

                entity.HasIndex(e => e.DocumentId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserIdAbsender);

                entity.HasIndex(e => e.UserIdEkVisumUser);

                entity.HasIndex(e => e.UserIdVisiertDurch);

                entity.HasIndex(e => e.UserIdVisumBeantragtBei);

                entity.HasIndex(e => e.VmPriMaIdAdressat);

                entity.Property(e => e.FaDokumenteId).HasColumnName("FaDokumenteID");

                entity.Property(e => e.BaInstitutionIdAdressat).HasColumnName("BaInstitutionID_Adressat");

                entity.Property(e => e.BaPersonIdAdressat).HasColumnName("BaPersonID_Adressat");

                entity.Property(e => e.BaPersonIdLt).HasColumnName("BaPersonID_LT");

                entity.Property(e => e.BaPersonIds)
                    .HasColumnName("BaPersonIDs")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumErstellung).HasColumnType("datetime");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.DocumentIdMerkblatt).HasColumnName("DocumentID_Merkblatt");

                entity.Property(e => e.EkKw).HasColumnName("EkKW");

                entity.Property(e => e.EkVisumDatum).HasColumnType("datetime");

                entity.Property(e => e.FaDokumenteTs)
                    .IsRequired()
                    .HasColumnName("FaDokumenteTS")
                    .IsRowVersion();

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FaThemaCodes)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PendenzDatum).HasColumnType("datetime");

                entity.Property(e => e.Stichwort)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserIdAbsender).HasColumnName("UserID_Absender");

                entity.Property(e => e.UserIdEkVisumUser).HasColumnName("UserID_EkVisumUser");

                entity.Property(e => e.UserIdVisiertDurch).HasColumnName("UserID_VisiertDurch");

                entity.Property(e => e.UserIdVisumBeantragtBei).HasColumnName("UserID_VisumBeantragtBei");

                entity.Property(e => e.UserIdVisumBeantragtDurch).HasColumnName("UserID_VisumBeantragtDurch");

                entity.Property(e => e.VisiertDatum).HasColumnType("datetime");

                entity.Property(e => e.VisumBeantragtDatum).HasColumnType("datetime");

                entity.Property(e => e.VmPriMaIdAdressat).HasColumnName("VmPriMaID_Adressat");

                entity.HasOne(d => d.BaInstitutionIdAdressatNavigation)
                    .WithMany(p => p.FaDokumente)
                    .HasForeignKey(d => d.BaInstitutionIdAdressat)
                    .HasConstraintName("FK_FaDokumente_BaInstitution_Adressat");

                entity.HasOne(d => d.BaPersonIdAdressatNavigation)
                    .WithMany(p => p.FaDokumenteBaPersonIdAdressatNavigation)
                    .HasForeignKey(d => d.BaPersonIdAdressat)
                    .HasConstraintName("FK_FaDokumente_BaPerson_Adressat");

                entity.HasOne(d => d.BaPersonIdLtNavigation)
                    .WithMany(p => p.FaDokumenteBaPersonIdLtNavigation)
                    .HasForeignKey(d => d.BaPersonIdLt)
                    .HasConstraintName("FK_FaDokumente_BaPerson_LT");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.FaDokumente)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaDokumente_FaLeistung");

                entity.HasOne(d => d.UserIdAbsenderNavigation)
                    .WithMany(p => p.FaDokumenteUserIdAbsenderNavigation)
                    .HasForeignKey(d => d.UserIdAbsender)
                    .HasConstraintName("FK_FaDokumente_XUser_Absender");

                entity.HasOne(d => d.UserIdEkVisumUserNavigation)
                    .WithMany(p => p.FaDokumenteUserIdEkVisumUserNavigation)
                    .HasForeignKey(d => d.UserIdEkVisumUser)
                    .HasConstraintName("FK_FaDokumente_XUser_EkVisumUserID");

                entity.HasOne(d => d.UserIdVisiertDurchNavigation)
                    .WithMany(p => p.FaDokumenteUserIdVisiertDurchNavigation)
                    .HasForeignKey(d => d.UserIdVisiertDurch)
                    .HasConstraintName("FK_FaDokumente_XUser_VisiertDurchID");

                entity.HasOne(d => d.UserIdVisumBeantragtBeiNavigation)
                    .WithMany(p => p.FaDokumenteUserIdVisumBeantragtBeiNavigation)
                    .HasForeignKey(d => d.UserIdVisumBeantragtBei)
                    .HasConstraintName("FK_FaDokumente_XUser_VisumBeantragtBeiID");

                entity.HasOne(d => d.UserIdVisumBeantragtDurchNavigation)
                    .WithMany(p => p.FaDokumenteUserIdVisumBeantragtDurchNavigation)
                    .HasForeignKey(d => d.UserIdVisumBeantragtDurch)
                    .HasConstraintName("FK_FaDokumente_XUser_VisumBeantragtDurchID");

                entity.HasOne(d => d.VmPriMaIdAdressatNavigation)
                    .WithMany(p => p.FaDokumente)
                    .HasForeignKey(d => d.VmPriMaIdAdressat)
                    .HasConstraintName("FK_FaDokumente_VmPriMa");
            });

            modelBuilder.Entity<FaKategorisierung>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.FaKategorisierungEksProduktId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.FaKategorisierungId).HasColumnName("FaKategorisierungID");

                entity.Property(e => e.Abschlussdatum).HasColumnType("datetime");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Begruendung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.FaKategorieCode).HasComputedColumnSql("([dbo].[fnFaGetKategorie]([FaKategorisierungEksProduktID],[FaKategorisierungEksOptionCode],[FaKategorisierungKiStatusCode],[FaKategorisierungIntakeCode],[FaKategorisierungKooperationCode],[FaKategorisierungRessourcenCode],[FaKategorisierungAbschlussgrundCode]))");

                entity.Property(e => e.FaKategorisierungEksProduktId).HasColumnName("FaKategorisierungEksProduktID");

                entity.Property(e => e.FaKategorisierungTs)
                    .IsRequired()
                    .HasColumnName("FaKategorisierungTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.FaKategorisierung)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_FaKategorisierung_BaPerson");

                entity.HasOne(d => d.FaKategorisierungEksProdukt)
                    .WithMany(p => p.FaKategorisierung)
                    .HasForeignKey(d => d.FaKategorisierungEksProduktId)
                    .HasConstraintName("FK_FaKategorisierung_FaKategorisierungEksProdukt");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FaKategorisierung)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaKategorisierung_XUser");
            });

            modelBuilder.Entity<FaKategorisierungEksProdukt>(entity =>
            {
                entity.HasIndex(e => e.OrgUnitId);

                entity.Property(e => e.FaKategorisierungEksProduktId).HasColumnName("FaKategorisierungEksProduktID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaKategorisierungEksProduktTs)
                    .IsRequired()
                    .HasColumnName("FaKategorisierungEksProduktTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrgUnitId).HasColumnName("OrgUnitID");

                entity.Property(e => e.ShortText)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrgUnit)
                    .WithMany(p => p.FaKategorisierungEksProdukt)
                    .HasForeignKey(d => d.OrgUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaKategorisierungEksProdukt_XOrgUnit");
            });

            modelBuilder.Entity<FaLeistung>(entity =>
            {
                entity.HasIndex(e => e.BaPersonID);

                entity.HasIndex(e => e.DatumBis);

                entity.HasIndex(e => e.FaLeistungTs);

                entity.HasIndex(e => e.SachbearbeiterId);

                entity.HasIndex(e => e.SchuldnerBaPersonId);

                entity.HasIndex(e => e.UserID);

                entity.HasIndex(e => e.VufaFallId);

                entity.HasIndex(e => new { e.BaPersonID, e.FaLeistungID, e.ModulID, e.DatumVon });

                entity.HasIndex(e => new { e.FaFallID, e.FaProzessCode, e.BaPersonID, e.DatumVon })
                    .HasName("IX_FaLeistung_BaPersonID_DatumVon_FaFallID_FaProzessCode");

                entity.HasIndex(e => new { e.FaFallID, e.ModulID, e.GemeindeCode, e.DatumVon });

                entity.HasIndex(e => new { e.FaLeistungID, e.FaFallID, e.DatumBis, e.ModulID })
                    .HasName("IX_FaLeistung_ModulID_FaLeistungID_FaFallID_DatumBis");

                entity.HasIndex(e => new { e.FaLeistungID, e.UserID, e.BaPersonID, e.ModulID });

                entity.HasIndex(e => new { e.FaProzessCode, e.FaLeistungID, e.UserID, e.BaPersonID });

                entity.HasIndex(e => new { e.UserID, e.FaLeistungID, e.BaPersonID, e.DatumBis });

                entity.HasIndex(e => new { e.FaLeistungID, e.BaPersonID, e.ModulID, e.DatumVon, e.DatumBis });

                entity.HasIndex(e => new { e.ModulID, e.FaLeistungID, e.BaPersonID, e.UserID, e.DatumVon });

                entity.HasIndex(e => new { e.BaPersonID, e.ModulID, e.FaLeistungID, e.DatumVon, e.DatumBis, e.Visdat36Fallid, e.Visdat36Area })
                    .HasName("IX_FaLeistung_BaPersonID_ModulID_FaLeistungID_DatumVon_DatumBis_VisDatFallID_visdat36Area");

                entity.HasIndex(e => new { e.FaLeistungID, e.BaPersonID, e.ModulID, e.SchuldnerBaPersonId, e.DatumBis, e.GemeindeCode, e.DatumVon })
                    .HasName("IX_FaLeistung_GemeindeCode_DatumVon_FaLeistungID_BaPersonID_ModulID_SchuldnerBaPersonID_DatumBis");

                entity.HasIndex(e => new { e.BaPersonID, e.ModulID, e.UserID, e.SachbearbeiterId, e.FaProzessCode, e.DatumVon, e.DatumBis, e.FaFallID })
                    .HasName("IX_FaLeistung_FaFallID_BaPersonID_ModulID_DatumVon_DatumBis_UserID_SachbearbeiterID");

                entity.Property(e => e.FaLeistungID).HasColumnName("FaLeistungID");

                entity.Property(e => e.BaPersonID).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dossiernummer)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FaFallID).HasColumnName("FaFallID");

                entity.Property(e => e.FaLeistungTs)
                    .IsRequired()
                    .HasColumnName("FaLeistungTS")
                    .IsRowVersion();

                entity.Property(e => e.FaTeilleistungserbringerCodes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GemeindeCode).HasDefaultValueSql("([dbo].[fnGetDefaultGemeindeCode]())");

                entity.Property(e => e.IkDatumForderungstitel).HasColumnType("datetime");

                entity.Property(e => e.IkDatumRechtskraft).HasColumnType("datetime");

                entity.Property(e => e.IkSchuldnerMahnen).HasDefaultValueSql("((1))");

                entity.Property(e => e.IkVerjaehrungAm).HasColumnType("datetime");

                entity.Property(e => e.MigBemerkung)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MigrationKa)
                    .HasColumnName("MigrationKA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModulID).HasColumnName("ModulID");

                entity.Property(e => e.OldUnitId).HasColumnName("OldUnitID");

                entity.Property(e => e.PscdVertragsgegenstandId).HasColumnName("PscdVertragsgegenstandID");

                entity.Property(e => e.SachbearbeiterId).HasColumnName("SachbearbeiterID");

                entity.Property(e => e.SchuldnerBaPersonId).HasColumnName("SchuldnerBaPersonID");

                entity.Property(e => e.UserID).HasColumnName("UserID");

                entity.Property(e => e.Visdat36Area)
                    .HasColumnName("visdat36Area")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Visdat36Fallid)
                    .HasColumnName("visdat36FALLID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Visdat36Leistungid)
                    .HasColumnName("visdat36LEISTUNGID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VufaFallId).HasColumnName("VUFaFallID");

                entity.Property(e => e.WiederholteSpezifischeErmittlungEaf).HasColumnName("WiederholteSpezifischeErmittlungEAF");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.FaLeistungBaPerson)
                    .HasForeignKey(d => d.BaPersonID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaLeistung_BaPerson");

                entity.HasOne(d => d.Modul)
                    .WithMany(p => p.FaLeistung)
                    .HasForeignKey(d => d.ModulID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaLeistung_XModul");

                entity.HasOne(d => d.Sachbearbeiter)
                    .WithMany(p => p.FaLeistungSachbearbeiter)
                    .HasForeignKey(d => d.SachbearbeiterId)
                    .HasConstraintName("FK_FaLeistung_SachbearbeiterID");

                entity.HasOne(d => d.SchuldnerBaPerson)
                    .WithMany(p => p.FaLeistungSchuldnerBaPerson)
                    .HasForeignKey(d => d.SchuldnerBaPersonId)
                    .HasConstraintName("FK_FaLeistung_SchuldnerBaPerson");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FaLeistungUser)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaLeistung_XUser");
            });

            modelBuilder.Entity<FaLeistungArchiv>(entity =>
            {
                entity.HasIndex(e => e.ArchiveId);

                entity.HasIndex(e => e.CheckInUserId);

                entity.HasIndex(e => e.CheckOut);

                entity.HasIndex(e => e.CheckOutUserId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.FaLeistungArchivId).HasColumnName("FaLeistungArchivID");

                entity.Property(e => e.ArchivNr)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ArchiveId).HasColumnName("ArchiveID");

                entity.Property(e => e.CheckIn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CheckInUserId).HasColumnName("CheckInUserID");

                entity.Property(e => e.CheckOut).HasColumnType("datetime");

                entity.Property(e => e.CheckOutUserId).HasColumnName("CheckOutUserID");

                entity.Property(e => e.FaLeistungArchivTs)
                    .IsRequired()
                    .HasColumnName("FaLeistungArchivTS")
                    .IsRowVersion();

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.HasOne(d => d.Archive)
                    .WithMany(p => p.FaLeistungArchiv)
                    .HasForeignKey(d => d.ArchiveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaLeistungArchiv_XArchive");

                entity.HasOne(d => d.CheckInUser)
                    .WithMany(p => p.FaLeistungArchivCheckInUser)
                    .HasForeignKey(d => d.CheckInUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaLeistungArchiv_XUser");

                entity.HasOne(d => d.CheckOutUser)
                    .WithMany(p => p.FaLeistungArchivCheckOutUser)
                    .HasForeignKey(d => d.CheckOutUserId)
                    .HasConstraintName("FK_FaLeistungArchiv_XUser1");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.FaLeistungArchiv)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_FaLeistungArchiv_FaLeistung");
            });

            modelBuilder.Entity<FaLeistungBewertung>(entity =>
            {
                entity.HasKey(e => e.FaBewertungId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.FaBewertungId).HasColumnName("FaBewertungID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.FaKriterienCodes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungBewertungTs)
                    .IsRequired()
                    .HasColumnName("FaLeistungBewertungTS")
                    .IsRowVersion();

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Termin).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.FaLeistungBewertung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaLeistungBewertung_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FaLeistungBewertung)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_FaLeistungBewertung_XUser");
            });

            modelBuilder.Entity<FaLeistungUserHist>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.FaLeistungUserHistId).HasColumnName("FaLeistungUserHistID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FaLeistungUserHistTs)
                    .IsRequired()
                    .HasColumnName("FaLeistungUserHistTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.FaLeistungUserHist)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_FaLeistungUserHist_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FaLeistungUserHist)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaLeistungUserHist_XUser");
            });

            modelBuilder.Entity<FaLeistungZugriff>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => new { e.FaLeistungId, e.UserId })
                    .HasName("IX_FaLeistungZugriff_UserID_FaLeistungID");

                entity.Property(e => e.FaLeistungZugriffId).HasColumnName("FaLeistungZugriffID");

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FaLeistungZugriffTs)
                    .IsRequired()
                    .HasColumnName("FaLeistungZugriffTS")
                    .IsRowVersion();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.FaLeistungZugriff)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_FaLeistungZugriff_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FaLeistungZugriff)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_FaLeistungZugriff_XUser");
            });

            modelBuilder.Entity<FaPendenzgruppe>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_FaPendenzgruppe_Name_Unique")
                    .IsUnique();

                entity.Property(e => e.FaPendenzgruppeId).HasColumnName("FaPendenzgruppeID");

                entity.Property(e => e.Beschreibung)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FaPendenzgruppeTs)
                    .IsRequired()
                    .HasColumnName("FaPendenzgruppeTS")
                    .IsRowVersion();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FaPendenzgruppeUser>(entity =>
            {
                entity.ToTable("FaPendenzgruppe_User");

                entity.HasIndex(e => new { e.FaPendenzgruppeId, e.UserId })
                    .HasName("IX_FaTaskGroup_User_FaPendenzgruppeID");

                entity.HasIndex(e => new { e.UserId, e.FaPendenzgruppeId })
                    .HasName("IX_FaTaskGroup_User");

                entity.Property(e => e.FaPendenzgruppeUserId).HasColumnName("FaPendenzgruppe_UserID");

                entity.Property(e => e.FaPendenzgruppeId).HasColumnName("FaPendenzgruppeID");

                entity.Property(e => e.FaPendenzgruppeUserTs)
                    .IsRequired()
                    .HasColumnName("FaPendenzgruppe_UserTS")
                    .IsRowVersion();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FaPendenzgruppe)
                    .WithMany(p => p.FaPendenzgruppeUser)
                    .HasForeignKey(d => d.FaPendenzgruppeId)
                    .HasConstraintName("FK_FaPendenzgruppe_XUser_FaPendenzgruppe");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FaPendenzgruppeUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_FaPendenzgruppe_XUser_XUser");
            });

            modelBuilder.Entity<FaPhase>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.FsDienstleistungspaketIdBedarf);

                entity.HasIndex(e => e.FsDienstleistungspaketIdZugewiesen);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.FaPhaseId).HasColumnName("FaPhaseID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FaPhaseTs)
                    .IsRequired()
                    .HasColumnName("FaPhaseTS")
                    .IsRowVersion();

                entity.Property(e => e.FsDienstleistungspaketIdBedarf).HasColumnName("FsDienstleistungspaketID_Bedarf");

                entity.Property(e => e.FsDienstleistungspaketIdZugewiesen).HasColumnName("FsDienstleistungspaketID_Zugewiesen");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.FaPhase)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaPhase_FaLeistung");

                entity.HasOne(d => d.FsDienstleistungspaketIdBedarfNavigation)
                    .WithMany(p => p.FaPhaseFsDienstleistungspaketIdBedarfNavigation)
                    .HasForeignKey(d => d.FsDienstleistungspaketIdBedarf)
                    .HasConstraintName("FK_FaPhase_FsDienstleistungspaket_Bedarf");

                entity.HasOne(d => d.FsDienstleistungspaketIdZugewiesenNavigation)
                    .WithMany(p => p.FaPhaseFsDienstleistungspaketIdZugewiesenNavigation)
                    .HasForeignKey(d => d.FsDienstleistungspaketIdZugewiesen)
                    .HasConstraintName("FK_FaPhase_FsDienstleistungspaket_Zugewiesen");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FaPhase)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_FaPhase_XUser");
            });

            modelBuilder.Entity<FaRelation>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId1);

                entity.HasIndex(e => e.FaLeistungId2);

                entity.Property(e => e.FaRelationId).HasColumnName("FaRelationID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId1).HasColumnName("FaLeistungID1");

                entity.Property(e => e.FaLeistungId2).HasColumnName("FaLeistungID2");

                entity.Property(e => e.FaRelationTs)
                    .IsRequired()
                    .HasColumnName("FaRelationTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FaLeistungId1Navigation)
                    .WithMany(p => p.FaRelationFaLeistungId1Navigation)
                    .HasForeignKey(d => d.FaLeistungId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaRelation_FaLeistung1");

                entity.HasOne(d => d.FaLeistungId2Navigation)
                    .WithMany(p => p.FaRelationFaLeistungId2Navigation)
                    .HasForeignKey(d => d.FaLeistungId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaRelation_FaLeistung2");
            });

            modelBuilder.Entity<FaWeisung>(entity =>
            {
                entity.Property(e => e.FaWeisungId).HasColumnName("FaWeisungID");

                entity.Property(e => e.Auflage).IsUnicode(false);

                entity.Property(e => e.Ausganslage).IsUnicode(false);

                entity.Property(e => e.Betreff)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CanDelete).HasDefaultValueSql("((1))");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumVerfuegung).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FaWeisungTs)
                    .IsRequired()
                    .HasColumnName("FaWeisungTS")
                    .IsRowVersion();

                entity.Property(e => e.KonsequenzCodeAngedroht).HasDefaultValueSql("((0))");

                entity.Property(e => e.KonsequenzDatumBis).HasColumnType("datetime");

                entity.Property(e => e.KonsequenzDatumVon).HasColumnType("datetime");

                entity.Property(e => e.KuerzungDatumBis).HasColumnType("datetime");

                entity.Property(e => e.KuerzungDatumVon).HasColumnType("datetime");

                entity.Property(e => e.KuerzungGbangedroht)
                    .HasColumnName("KuerzungGBAngedroht")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.KuerzungGbverfuegt).HasColumnName("KuerzungGBVerfuegt");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.TerminMahnung1).HasColumnType("datetime");

                entity.Property(e => e.TerminMahnung2).HasColumnType("datetime");

                entity.Property(e => e.TerminMahnung3).HasColumnType("datetime");

                entity.Property(e => e.TerminWeisung).HasColumnType("datetime");

                entity.Property(e => e.UserIdCreator).HasColumnName("UserID_Creator");

                entity.Property(e => e.UserIdVerantwortlichRd).HasColumnName("UserID_VerantwortlichRD");

                entity.Property(e => e.UserIdVerantwortlichSar).HasColumnName("UserID_VerantwortlichSAR");

                entity.Property(e => e.WeisungsartCode).HasDefaultValueSql("((0))");

                entity.Property(e => e.XdocumentIdMahnung1).HasColumnName("XDocumentID_Mahnung1");

                entity.Property(e => e.XdocumentIdMahnung2).HasColumnName("XDocumentID_Mahnung2");

                entity.Property(e => e.XdocumentIdMahnung3).HasColumnName("XDocumentID_Mahnung3");

                entity.Property(e => e.XdocumentIdVerfuegung).HasColumnName("XDocumentID_Verfuegung");

                entity.Property(e => e.XdocumentIdWeisung).HasColumnName("XDocumentID_Weisung");

                entity.Property(e => e.XtaskIdSar).HasColumnName("XTaskID_SAR");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.FaWeisung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaWeisung_FaLeistung");

                entity.HasOne(d => d.UserIdCreatorNavigation)
                    .WithMany(p => p.FaWeisungUserIdCreatorNavigation)
                    .HasForeignKey(d => d.UserIdCreator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaWeisung_XUser_Creator");

                entity.HasOne(d => d.UserIdVerantwortlichRdNavigation)
                    .WithMany(p => p.FaWeisungUserIdVerantwortlichRdNavigation)
                    .HasForeignKey(d => d.UserIdVerantwortlichRd)
                    .HasConstraintName("FK_FaWeisung_XUser_VerantwortlichRD");

                entity.HasOne(d => d.UserIdVerantwortlichSarNavigation)
                    .WithMany(p => p.FaWeisungUserIdVerantwortlichSarNavigation)
                    .HasForeignKey(d => d.UserIdVerantwortlichSar)
                    .HasConstraintName("FK_FaWeisung_XUser_VerantwortlichSAR");

                entity.HasOne(d => d.XtaskIdSarNavigation)
                    .WithMany(p => p.FaWeisung)
                    .HasForeignKey(d => d.XtaskIdSar)
                    .HasConstraintName("FK_FaWeisung_XTask");
            });

            modelBuilder.Entity<FaWeisungBaPerson>(entity =>
            {
                entity.ToTable("FaWeisung_BaPerson");

                entity.Property(e => e.FaWeisungBaPersonId).HasColumnName("FaWeisung_BaPersonID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.FaWeisungBaPersonTs)
                    .IsRequired()
                    .HasColumnName("FaWeisung_BaPersonTS")
                    .IsRowVersion();

                entity.Property(e => e.FaWeisungId).HasColumnName("FaWeisungID");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.FaWeisungBaPerson)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaWeisung_BaPerson_BaPerson");

                entity.HasOne(d => d.FaWeisung)
                    .WithMany(p => p.FaWeisungBaPerson)
                    .HasForeignKey(d => d.FaWeisungId)
                    .HasConstraintName("FK_FaWeisung_BaPerson_FaWeisung");
            });

            modelBuilder.Entity<FaWeisungProtokoll>(entity =>
            {
                entity.Property(e => e.FaWeisungProtokollId).HasColumnName("FaWeisungProtokollID");

                entity.Property(e => e.Aktion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaWeisungId).HasColumnName("FaWeisungID");

                entity.Property(e => e.FaWeisungProtokollTs)
                    .IsRequired()
                    .HasColumnName("FaWeisung_ProtokollTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Termin).HasColumnType("datetime");

                entity.Property(e => e.Verantwortlich)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FaWeisung)
                    .WithMany(p => p.FaWeisungProtokoll)
                    .HasForeignKey(d => d.FaWeisungId)
                    .HasConstraintName("FK_FaWeisungProtokoll_FaWeisung");
            });

            modelBuilder.Entity<FaWeisungWorkflow>(entity =>
            {
                entity.Property(e => e.FaWeisungWorkflowId).HasColumnName("FaWeisungWorkflowID");

                entity.Property(e => e.Aktion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AktionTid).HasColumnName("AktionTID");

                entity.Property(e => e.FaWeisungWorkflowTs)
                    .IsRequired()
                    .HasColumnName("FaWeisungWorkflowTS")
                    .IsRowVersion();

                entity.Property(e => e.PendenzRd).HasColumnName("PendenzRD");

                entity.Property(e => e.PendenzSar).HasColumnName("PendenzSAR");

                entity.Property(e => e.SarpendenzAnpassen).HasColumnName("SARPendenzAnpassen");

                entity.Property(e => e.XtaskTemplateIdRd).HasColumnName("XTaskTemplateID_RD");

                entity.Property(e => e.XtaskTemplateIdSar).HasColumnName("XTaskTemplateID_SAR");

                entity.Property(e => e.ZustaendigCode).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.XtaskTemplateIdRdNavigation)
                    .WithMany(p => p.FaWeisungWorkflowXtaskTemplateIdRdNavigation)
                    .HasForeignKey(d => d.XtaskTemplateIdRd)
                    .HasConstraintName("FK_FaWeisungWorkflow_XTaskTemplate_RD");

                entity.HasOne(d => d.XtaskTemplateIdSarNavigation)
                    .WithMany(p => p.FaWeisungWorkflowXtaskTemplateIdSarNavigation)
                    .HasForeignKey(d => d.XtaskTemplateIdSar)
                    .HasConstraintName("FK_FaWeisungWorkflow_XTaskTemplate_SAR");
            });

            modelBuilder.Entity<FaZeitlichePlanung>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId)
                    .IsUnique();

                entity.Property(e => e.FaZeitlichePlanungId).HasColumnName("FaZeitlichePlanungID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FaZeitlichePlanungTs)
                    .IsRequired()
                    .HasColumnName("FaZeitlichePlanungTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phase1Bemerkungen).IsUnicode(false);

                entity.Property(e => e.Phase1Ende).HasColumnType("datetime");

                entity.Property(e => e.Phase1SitAnalyse).HasColumnType("datetime");

                entity.Property(e => e.Phase2Beginn).HasColumnType("datetime");

                entity.Property(e => e.Phase2Bemerkungen).IsUnicode(false);

                entity.Property(e => e.Phase2Ende).HasColumnType("datetime");

                entity.Property(e => e.Phase2SitAnalyse).HasColumnType("datetime");

                entity.Property(e => e.Phase3Beginn).HasColumnType("datetime");

                entity.Property(e => e.Phase3Bemerkungen).IsUnicode(false);

                entity.Property(e => e.Phase3SitAnalyse).HasColumnType("datetime");

                entity.HasOne(d => d.FaLeistung)
                    .WithOne(p => p.FaZeitlichePlanung)
                    .HasForeignKey<FaZeitlichePlanung>(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaZeitlichePlanung_FaLeistung");
            });

            modelBuilder.Entity<FbBarauszahlungAuftrag>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserIdCreator);

                entity.HasIndex(e => e.UserIdModifier);

                entity.Property(e => e.FbBarauszahlungAuftragId).HasColumnName("FbBarauszahlungAuftragID");

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.Buchungstext)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FbBarauszahlungAuftragTs)
                    .IsRequired()
                    .HasColumnName("FbBarauszahlungAuftragTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserIdCreator).HasColumnName("UserID_Creator");

                entity.Property(e => e.UserIdModifier).HasColumnName("UserID_Modifier");

                entity.Property(e => e.XdocumentId).HasColumnName("XDocumentID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.FbBarauszahlungAuftrag)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FbBarauszahlungAuftrag_FaLeistung");

                entity.HasOne(d => d.UserIdCreatorNavigation)
                    .WithMany(p => p.FbBarauszahlungAuftragUserIdCreatorNavigation)
                    .HasForeignKey(d => d.UserIdCreator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FbBarauszahlungAuftrag_XUser_Creator");

                entity.HasOne(d => d.UserIdModifierNavigation)
                    .WithMany(p => p.FbBarauszahlungAuftragUserIdModifierNavigation)
                    .HasForeignKey(d => d.UserIdModifier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FbBarauszahlungAuftrag_XUser_Modifier");
            });

            modelBuilder.Entity<FbBarauszahlungAusbezahlt>(entity =>
            {
                entity.HasIndex(e => e.FbBarauszahlungZyklusId);

                entity.HasIndex(e => e.FbBuchungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.FbBarauszahlungAusbezahltId).HasColumnName("FbBarauszahlungAusbezahltID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.FbBarauszahlungAusbezahltTs)
                    .IsRequired()
                    .HasColumnName("FbBarauszahlungAusbezahltTS")
                    .IsRowVersion();

                entity.Property(e => e.FbBarauszahlungZyklusId).HasColumnName("FbBarauszahlungZyklusID");

                entity.Property(e => e.FbBuchungId).HasColumnName("FbBuchungID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stichtag).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FbBarauszahlungZyklus)
                    .WithMany(p => p.FbBarauszahlungAusbezahlt)
                    .HasForeignKey(d => d.FbBarauszahlungZyklusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FbBarauszahlungAusbezahlt_FbBarauszahlungZyklus");

                entity.HasOne(d => d.FbBuchung)
                    .WithMany(p => p.FbBarauszahlungAusbezahlt)
                    .HasForeignKey(d => d.FbBuchungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FbBarauszahlungAusbezahlt_FbBuchung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FbBarauszahlungAusbezahlt)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FbBarauszahlungAusbezahlt_XUser");
            });

            modelBuilder.Entity<FbBarauszahlungZyklus>(entity =>
            {
                entity.HasIndex(e => e.FbBarauszahlungAuftragId);

                entity.Property(e => e.FbBarauszahlungZyklusId).HasColumnName("FbBarauszahlungZyklusID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumStart).HasColumnType("datetime");

                entity.Property(e => e.FbBarauszahlungAuftragId).HasColumnName("FbBarauszahlungAuftragID");

                entity.Property(e => e.FbBarauszahlungZyklusTs)
                    .IsRequired()
                    .HasColumnName("FbBarauszahlungZyklusTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FbBarauszahlungAuftrag)
                    .WithMany(p => p.FbBarauszahlungZyklus)
                    .HasForeignKey(d => d.FbBarauszahlungAuftragId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FbBarauszahlungZyklus_FbBarauszahlungAuftrag");
            });

            modelBuilder.Entity<FbBelegNr>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => new { e.BelegNrCode, e.UserId, e.BaPersonId })
                    .HasName("IX_FbBelegNr_BelegNrCodeUserIDBaPersonID_Unique")
                    .IsUnique();

                entity.Property(e => e.FbBelegNrId).HasColumnName("FbBelegNrID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.BelegNrCode).HasDefaultValueSql("(0)");

                entity.Property(e => e.FbBelegNrTs)
                    .IsRequired()
                    .HasColumnName("FbBelegNrTS")
                    .IsRowVersion();

                entity.Property(e => e.Praefix)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.FbBelegNr)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FbBelegNr_DmgPerson");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FbBelegNr)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FbBelegNr_XUser");
            });

            modelBuilder.Entity<FbBuchung>(entity =>
            {
                entity.HasIndex(e => e.FbDauerauftragId);

                entity.HasIndex(e => e.FbPeriodeId);

                entity.HasIndex(e => e.FbZahlungswegId);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => new { e.FbPeriodeId, e.HabenKtoNr });

                entity.HasIndex(e => new { e.FbPeriodeId, e.SollKtoNr });

                entity.Property(e => e.FbBuchungId).HasColumnName("FbBuchungID");

                entity.Property(e => e.BankKontoNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BelegNr)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.BuchungsDatum).HasColumnType("datetime");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ErfassungsDatum)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FbBuchungTs)
                    .IsRequired()
                    .HasColumnName("FbBuchungTS")
                    .IsRowVersion();

                entity.Property(e => e.FbDauerauftragId).HasColumnName("FbDauerauftragID");

                entity.Property(e => e.FbPeriodeId).HasColumnName("FbPeriodeID");

                entity.Property(e => e.FbZahlungswegId).HasColumnName("FbZahlungswegID");

                entity.Property(e => e.Iban)
                    .HasColumnName("IBAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ort)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PckontoNr)
                    .HasColumnName("PCKontoNr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Plz)
                    .HasColumnName("PLZ")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenzNummer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Strasse)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ValutaDatum).HasColumnType("datetime");

                entity.Property(e => e.ValutaDatumOriginal).HasColumnType("datetime");

                entity.Property(e => e.Zahlungsgrund)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Zusatz)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FbDauerauftrag)
                    .WithMany(p => p.FbBuchung)
                    .HasForeignKey(d => d.FbDauerauftragId)
                    .HasConstraintName("FK_FBBUCHUN_REFERENCE_FBDAUERA");

                entity.HasOne(d => d.FbPeriode)
                    .WithMany(p => p.FbBuchung)
                    .HasForeignKey(d => d.FbPeriodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FBBUCHUN_REFERENCE_FBPERIOD");

                entity.HasOne(d => d.FbZahlungsweg)
                    .WithMany(p => p.FbBuchung)
                    .HasForeignKey(d => d.FbZahlungswegId)
                    .HasConstraintName("FK_FBBUCHUN_REFERENCE_FBZAHLUN");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FbBuchung)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_FbBuchung_XUser");

                entity.HasOne(d => d.FbKonto)
                    .WithMany(p => p.FbBuchung)
                    .HasPrincipalKey(p => new { p.FbPeriodeId, p.KontoNr })
                    .HasForeignKey(d => new { d.FbPeriodeId, d.HabenKtoNr })
                    .HasConstraintName("FK_FBBUCHUN_REFERENCE_FBKONTO2");
            });

            modelBuilder.Entity<FbBuchungCode>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.Code);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => new { e.Code, e.BaPersonId })
                    .HasName("IX_FbBuchungCode_CodeBaPersonID_Unique")
                    .IsUnique();

                entity.Property(e => e.FbBuchungCodeId).HasColumnName("FbBuchungCodeID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FbBuchungCodeTs)
                    .IsRequired()
                    .HasColumnName("FbBuchungCodeTS")
                    .IsRowVersion();

                entity.Property(e => e.Text)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.FbBuchungCode)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FbBuchungCode_BaPerson");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FbBuchungCode)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FbBuchungCode_XUser");
            });

            modelBuilder.Entity<FbBuchungskreis>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.Property(e => e.FbBuchungskreisId).HasColumnName("FbBuchungskreisID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.BuchungsDatum).HasColumnType("datetime");

                entity.Property(e => e.FbBuchungskreisTs)
                    .IsRequired()
                    .HasColumnName("FbBuchungskreisTS")
                    .IsRowVersion();

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.FbBuchungskreis)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_FbBuchungskreis_BaPerson");
            });

            modelBuilder.Entity<FbDauerauftrag>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.FbZahlungswegId);

                entity.Property(e => e.FbDauerauftragId).HasColumnName("FbDauerauftragID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.DauerauftragDokId).HasColumnName("DauerauftragDokID");

                entity.Property(e => e.FbDauerauftragTs)
                    .IsRequired()
                    .HasColumnName("FbDauerauftragTS")
                    .IsRowVersion();

                entity.Property(e => e.FbZahlungswegId).HasColumnName("FbZahlungswegID");

                entity.Property(e => e.ReferenzNummer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Zahlungsgrund)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.FbDauerauftrag)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FbDauerauftrag_BaPerson");

                entity.HasOne(d => d.FbZahlungsweg)
                    .WithMany(p => p.FbDauerauftrag)
                    .HasForeignKey(d => d.FbZahlungswegId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FbDauerauftrag_FbZahlungsweg");
            });

            modelBuilder.Entity<FbDtabuchung>(entity =>
            {
                entity.HasKey(e => new { e.FbBuchungId, e.FbDtajournalId });

                entity.ToTable("FbDTABuchung");

                entity.Property(e => e.FbBuchungId).HasColumnName("FbBuchungID");

                entity.Property(e => e.FbDtajournalId).HasColumnName("FbDTAJournalID");

                entity.Property(e => e.FbDtabuchungTs)
                    .IsRequired()
                    .HasColumnName("FbDTABuchungTS")
                    .IsRowVersion();

                entity.Property(e => e.Status).HasDefaultValueSql("(0)");

                entity.HasOne(d => d.FbBuchung)
                    .WithMany(p => p.FbDtabuchung)
                    .HasForeignKey(d => d.FbBuchungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FbBuchungDTA_FbBuchung");

                entity.HasOne(d => d.FbDtajournal)
                    .WithMany(p => p.FbDtabuchung)
                    .HasForeignKey(d => d.FbDtajournalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FbBuchungDTA_FbDTAJournal");
            });

            modelBuilder.Entity<FbDtajournal>(entity =>
            {
                entity.ToTable("FbDTAJournal");

                entity.HasIndex(e => e.FbDtazugangId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.FbDtajournalId).HasColumnName("FbDTAJournalID");

                entity.Property(e => e.FbDtajournalTs)
                    .IsRequired()
                    .HasColumnName("FbDTAJournalTS")
                    .IsRowVersion();

                entity.Property(e => e.FbDtazugangId).HasColumnName("FbDTAZugangID");

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMessageId)
                    .HasColumnName("PaymentMessageID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.TotalBetrag).HasColumnType("money");

                entity.Property(e => e.TransferDatum).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Zahlungsdaten).IsUnicode(false);

                entity.HasOne(d => d.FbDtazugang)
                    .WithMany(p => p.FbDtajournal)
                    .HasForeignKey(d => d.FbDtazugangId)
                    .HasConstraintName("FK_FbDTAJournal_FbDTAZugang");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FbDtajournal)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FbDTAJournal_XUser");
            });

            modelBuilder.Entity<FbDtazugang>(entity =>
            {
                entity.ToTable("FbDTAZugang");

                entity.HasIndex(e => e.BaBankId);

                entity.HasIndex(e => e.FbTeamId);

                entity.Property(e => e.FbDtazugangId).HasColumnName("FbDTAZugangID");

                entity.Property(e => e.BaBankId).HasColumnName("BaBankID");

                entity.Property(e => e.FbDtazugangTs)
                    .IsRequired()
                    .HasColumnName("FbDTAZugangTS")
                    .IsRowVersion();

                entity.Property(e => e.FbTeamId).HasColumnName("FbTeamID");

                entity.Property(e => e.KontoNr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VertragNr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaBank)
                    .WithMany(p => p.FbDtazugang)
                    .HasForeignKey(d => d.BaBankId)
                    .HasConstraintName("FK_FbDTAZugang_BaBank");

                entity.HasOne(d => d.FbTeam)
                    .WithMany(p => p.FbDtazugang)
                    .HasForeignKey(d => d.FbTeamId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FbDTAZugang_FbTeam");
            });

            modelBuilder.Entity<FbKonto>(entity =>
            {
                entity.HasIndex(e => e.FbDtazugangId);

                entity.HasIndex(e => e.FbPeriodeId);

                entity.HasIndex(e => new { e.FbPeriodeId, e.KontoNr })
                    .HasName("IX_FbKonto_FbPeriodeIDKontoNr_Unique")
                    .IsUnique();

                entity.Property(e => e.FbKontoId).HasColumnName("FbKontoID");

                entity.Property(e => e.EroeffnungsSaldo)
                    .HasColumnType("money")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.EroeffnungsSaldoAtCreation)
                    .HasColumnName("EroeffnungsSaldo_AtCreation")
                    .HasColumnType("money");

                entity.Property(e => e.EroeffnungsSaldoCreated).HasColumnType("datetime");

                entity.Property(e => e.EroeffnungsSaldoCreator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EroeffnungsSaldoModified).HasColumnType("datetime");

                entity.Property(e => e.EroeffnungsSaldoModifier)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FbDepotNr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FbDtazugangId).HasColumnName("FbDTAZugangID");

                entity.Property(e => e.FbKontoTs)
                    .IsRequired()
                    .HasColumnName("FbKontoTS")
                    .IsRowVersion();

                entity.Property(e => e.FbPeriodeId)
                    .IsRequired()
                    .HasColumnName("FbPeriodeID");

                entity.Property(e => e.KontoName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SaldoGruppeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.FbDtazugang)
                    .WithMany(p => p.FbKonto)
                    .HasForeignKey(d => d.FbDtazugangId)
                    .HasConstraintName("FK_FbKonto_FbDTAZugang");

                entity.HasOne(d => d.FbPeriode)
                    .WithMany(p => p.FbKonto)
                    .HasForeignKey(d => d.FbPeriodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FbKonto_FbPeriode");
            });

            modelBuilder.Entity<FbKreditor>(entity =>
            {
                entity.HasIndex(e => e.Name);

                entity.Property(e => e.FbKreditorId).HasColumnName("FbKreditorID");

                entity.Property(e => e.Aktiv).HasDefaultValueSql("((1))");

                entity.Property(e => e.BaLandId).HasColumnName("BaLandID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FbKreditorTs)
                    .IsRequired()
                    .HasColumnName("FbKreditorTS")
                    .IsRowVersion();

                entity.Property(e => e.KurzName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ort)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Plz)
                    .IsRequired()
                    .HasColumnName("PLZ")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Strasse)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Zusatz)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaLand)
                    .WithMany(p => p.FbKreditor)
                    .HasForeignKey(d => d.BaLandId)
                    .HasConstraintName("FK_FbKreditor_BaLand");
            });

            modelBuilder.Entity<FbPeriode>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.FbTeamId);

                entity.Property(e => e.FbPeriodeId).HasColumnName("FbPeriodeID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.FbPeriodeTs)
                    .IsRequired()
                    .HasColumnName("FbPeriodeTS")
                    .IsRowVersion();

                entity.Property(e => e.FbTeamId).HasColumnName("FbTeamID");

                entity.Property(e => e.PeriodeBis).HasColumnType("datetime");

                entity.Property(e => e.PeriodeVon).HasColumnType("datetime");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.FbPeriode)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FbPeriode_BaPerson");

                entity.HasOne(d => d.FbTeam)
                    .WithMany(p => p.FbPeriode)
                    .HasForeignKey(d => d.FbTeamId)
                    .HasConstraintName("FK_FbPeriode_FbTeam");
            });

            modelBuilder.Entity<FbTeam>(entity =>
            {
                entity.Property(e => e.FbTeamId).HasColumnName("FbTeamID");

                entity.Property(e => e.FbTeamTs)
                    .IsRequired()
                    .HasColumnName("FbTeamTS")
                    .IsRowVersion();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FbTeamMitglied>(entity =>
            {
                entity.HasKey(e => new { e.FbTeamId, e.UserId });

                entity.Property(e => e.FbTeamId).HasColumnName("FbTeamID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.DepotBereich).HasDefaultValueSql("(0)");

                entity.Property(e => e.FbTeamMitgliedTs)
                    .IsRequired()
                    .HasColumnName("FbTeamMitgliedTS")
                    .IsRowVersion();

                entity.Property(e => e.StandardBereich).HasDefaultValueSql("(1)");

                entity.HasOne(d => d.FbTeam)
                    .WithMany(p => p.FbTeamMitglied)
                    .HasForeignKey(d => d.FbTeamId)
                    .HasConstraintName("FK_FbTeamMitglied_FbTeam");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FbTeamMitglied)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_FbTeamMitglied_XUser");
            });

            modelBuilder.Entity<FbZahlungsweg>(entity =>
            {
                entity.HasIndex(e => e.BaBankId);

                entity.HasIndex(e => e.FbKreditorId);

                entity.Property(e => e.FbZahlungswegId).HasColumnName("FbZahlungswegID");

                entity.Property(e => e.BaBankId).HasColumnName("BaBankID");

                entity.Property(e => e.BankKontoNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BelegBankKontoNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FbKreditorId).HasColumnName("FbKreditorID");

                entity.Property(e => e.FbZahlungswegTs)
                    .IsRequired()
                    .HasColumnName("FbZahlungswegTS")
                    .IsRowVersion();

                entity.Property(e => e.Iban)
                    .HasColumnName("IBAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PckontoNr)
                    .HasColumnName("PCKontoNr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaBank)
                    .WithMany(p => p.FbZahlungsweg)
                    .HasForeignKey(d => d.BaBankId)
                    .HasConstraintName("FK_FbZahlungsweg_BaBank");

                entity.HasOne(d => d.FbKreditor)
                    .WithMany(p => p.FbZahlungsweg)
                    .HasForeignKey(d => d.FbKreditorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FbZahlungsweg_FbKreditor");
            });

            modelBuilder.Entity<FsDienstleistung>(entity =>
            {
                entity.Property(e => e.FsDienstleistungId).HasColumnName("FsDienstleistungID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FsDienstleistungTs)
                    .IsRequired()
                    .HasColumnName("FsDienstleistungTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StandardAufwand).HasColumnType("money");
            });

            modelBuilder.Entity<FsDienstleistungFsDienstleistungspaket>(entity =>
            {
                entity.ToTable("FsDienstleistung_FsDienstleistungspaket");

                entity.HasIndex(e => e.FsDienstleistungId);

                entity.HasIndex(e => e.FsDienstleistungspaketId);

                entity.HasIndex(e => new { e.FsDienstleistungId, e.FsDienstleistungspaketId })
                    .HasName("UK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistungID_FsDienstleistungspaketID")
                    .IsUnique();

                entity.Property(e => e.FsDienstleistungFsDienstleistungspaketId).HasColumnName("FsDienstleistung_FsDienstleistungspaketID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FsDienstleistungFsDienstleistungspaketTs)
                    .IsRequired()
                    .HasColumnName("FsDienstleistung_FsDienstleistungspaketTS")
                    .IsRowVersion();

                entity.Property(e => e.FsDienstleistungId).HasColumnName("FsDienstleistungID");

                entity.Property(e => e.FsDienstleistungspaketId).HasColumnName("FsDienstleistungspaketID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FsDienstleistung)
                    .WithMany(p => p.FsDienstleistungFsDienstleistungspaket)
                    .HasForeignKey(d => d.FsDienstleistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistung");

                entity.HasOne(d => d.FsDienstleistungspaket)
                    .WithMany(p => p.FsDienstleistungFsDienstleistungspaket)
                    .HasForeignKey(d => d.FsDienstleistungspaketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistungspaket");
            });

            modelBuilder.Entity<FsDienstleistungspaket>(entity =>
            {
                entity.Property(e => e.FsDienstleistungspaketId).HasColumnName("FsDienstleistungspaketID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FsDienstleistungspaketTs)
                    .IsRequired()
                    .HasColumnName("FsDienstleistungspaketTS")
                    .IsRowVersion();

                entity.Property(e => e.MaximaleLaufzeit).HasColumnType("money");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FsReduktion>(entity =>
            {
                entity.HasIndex(e => e.BdeleistungsartId);

                entity.Property(e => e.FsReduktionId).HasColumnName("FsReduktionID");

                entity.Property(e => e.AbhaengigVonBg).HasColumnName("AbhaengigVonBG");

                entity.Property(e => e.BdeleistungsartId).HasColumnName("BDELeistungsartID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FsReduktionTs)
                    .IsRequired()
                    .HasColumnName("FsReduktionTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StandardAufwand).HasColumnType("money");

                entity.HasOne(d => d.Bdeleistungsart)
                    .WithMany(p => p.FsReduktion)
                    .HasForeignKey(d => d.BdeleistungsartId)
                    .HasConstraintName("FK_FsReduktion_BDELeistungsart");
            });

            modelBuilder.Entity<FsReduktionMitarbeiter>(entity =>
            {
                entity.HasIndex(e => e.FsReduktionId);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => new { e.UserId, e.Jahr, e.Monat, e.FsReduktionId })
                    .HasName("UX_FsReduktionMitarbeiter_UserId_Jahr_Monat_FsReduktionId")
                    .IsUnique();

                entity.Property(e => e.FsReduktionMitarbeiterId).HasColumnName("FsReduktionMitarbeiterID");

                entity.Property(e => e.AngepassteReduktionZeit).HasColumnType("money");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FsReduktionId).HasColumnName("FsReduktionID");

                entity.Property(e => e.FsReduktionMitarbeiterTs)
                    .IsRequired()
                    .HasColumnName("FsReduktionMitarbeiterTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalReduktionZeit).HasColumnType("money");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FsReduktion)
                    .WithMany(p => p.FsReduktionMitarbeiter)
                    .HasForeignKey(d => d.FsReduktionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FsReduktionMitarbeiter_FsReduktion");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FsReduktionMitarbeiter)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FsReduktionMitarbeiter_XUser");
            });

            modelBuilder.Entity<GvAbklaerendeStelle>(entity =>
            {
                entity.HasIndex(e => e.BaZahlungswegId);

                entity.HasIndex(e => e.GvGesuchId);

                entity.Property(e => e.GvAbklaerendeStelleId).HasColumnName("GvAbklaerendeStelleID");

                entity.Property(e => e.BaZahlungswegId).HasColumnName("BaZahlungswegID");

                entity.Property(e => e.BeantragendeStelle)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Bemerkungen).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GvAbklaerendeStelleTs)
                    .IsRequired()
                    .HasColumnName("GvAbklaerendeStelleTS")
                    .IsRowVersion();

                entity.Property(e => e.GvGesuchId).HasColumnName("GvGesuchID");

                entity.Property(e => e.HausNr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Kanton)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Kontaktperson)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MitteilungZeile1)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MitteilungZeile2)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MitteilungZeile3)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MitteilungZeile4)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ort)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Plz)
                    .HasColumnName("PLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Postfach)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Strasse)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Zahlungsinstruktion).IsUnicode(false);

                entity.Property(e => e.Zusatz)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaZahlungsweg)
                    .WithMany(p => p.GvAbklaerendeStelle)
                    .HasForeignKey(d => d.BaZahlungswegId)
                    .HasConstraintName("FK_GvAbklaerendeStelle_BaZahlungsweg");

                entity.HasOne(d => d.GvGesuch)
                    .WithMany(p => p.GvAbklaerendeStelle)
                    .HasForeignKey(d => d.GvGesuchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvAbklaerendeStelle_GvGesuch");
            });

            modelBuilder.Entity<GvAntragPosition>(entity =>
            {
                entity.HasIndex(e => e.GvGesuchId);

                entity.Property(e => e.GvAntragPositionId).HasColumnName("GvAntragPositionID");

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GvAntragPositionTs)
                    .IsRequired()
                    .HasColumnName("GvAntragPositionTS")
                    .IsRowVersion();

                entity.Property(e => e.GvGesuchId).HasColumnName("GvGesuchID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.GvGesuch)
                    .WithMany(p => p.GvAntragPosition)
                    .HasForeignKey(d => d.GvGesuchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvAntragPosition_GvGesuch");
            });

            modelBuilder.Entity<GvAuflage>(entity =>
            {
                entity.HasIndex(e => e.GvGesuchId);

                entity.Property(e => e.GvAuflageId).HasColumnName("GvAuflageID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Erfasst)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Erlassungsgrund).IsUnicode(false);

                entity.Property(e => e.Faellig).HasColumnType("datetime");

                entity.Property(e => e.Gegenstand)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.GvAuflageTs)
                    .IsRequired()
                    .HasColumnName("GvAuflageTS")
                    .IsRowVersion();

                entity.Property(e => e.GvGesuchId).HasColumnName("GvGesuchID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rate1Betrag).HasColumnType("money");

                entity.Property(e => e.Rate1Datum).HasColumnType("datetime");

                entity.Property(e => e.Rate2Betrag).HasColumnType("money");

                entity.Property(e => e.Rate2Datum).HasColumnType("datetime");

                entity.Property(e => e.Rate3Betrag).HasColumnType("money");

                entity.Property(e => e.Rate3Datum).HasColumnType("datetime");

                entity.Property(e => e.Rate4Betrag).HasColumnType("money");

                entity.Property(e => e.Rate4Datum).HasColumnType("datetime");

                entity.Property(e => e.Rate5Betrag).HasColumnType("money");

                entity.Property(e => e.Rate5Datum).HasColumnType("datetime");

                entity.Property(e => e.Rate6Betrag).HasColumnType("money");

                entity.Property(e => e.Rate6Datum).HasColumnType("datetime");

                entity.Property(e => e.Rate7Betrag).HasColumnType("money");

                entity.Property(e => e.Rate7Datum).HasColumnType("datetime");

                entity.Property(e => e.Rate8Betrag).HasColumnType("money");

                entity.Property(e => e.Rate8Datum).HasColumnType("datetime");

                entity.HasOne(d => d.GvGesuch)
                    .WithMany(p => p.GvAuflage)
                    .HasForeignKey(d => d.GvGesuchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvAuflage_GvGesuch");
            });

            modelBuilder.Entity<GvAuszahlungPosition>(entity =>
            {
                entity.HasIndex(e => e.BaZahlungswegId);

                entity.HasIndex(e => e.GvGesuchId);

                entity.HasIndex(e => e.GvPositionsartId);

                entity.Property(e => e.GvAuszahlungPositionId).HasColumnName("GvAuszahlungPositionID");

                entity.Property(e => e.BaZahlungswegId).HasColumnName("BaZahlungswegID");

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.BuchungsText)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GvAuszahlungPositionTs)
                    .IsRequired()
                    .HasColumnName("GvAuszahlungPositionTS")
                    .IsRowVersion();

                entity.Property(e => e.GvGesuchId).HasColumnName("GvGesuchID");

                entity.Property(e => e.GvPositionsartId).HasColumnName("GvPositionsartID");

                entity.Property(e => e.MitteilungZeile1)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MitteilungZeile2)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MitteilungZeile3)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MitteilungZeile4)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenzNummer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValutaDatum).HasColumnType("datetime");

                entity.Property(e => e.Zahlungsinstruktion).IsUnicode(false);

                entity.HasOne(d => d.BaZahlungsweg)
                    .WithMany(p => p.GvAuszahlungPosition)
                    .HasForeignKey(d => d.BaZahlungswegId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvAuszahlungPosition_BaZahlungsweg");

                entity.HasOne(d => d.GvGesuch)
                    .WithMany(p => p.GvAuszahlungPosition)
                    .HasForeignKey(d => d.GvGesuchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvAuszahlungPosition_GvGesuch");

                entity.HasOne(d => d.GvPositionsart)
                    .WithMany(p => p.GvAuszahlungPosition)
                    .HasForeignKey(d => d.GvPositionsartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvAuszahlungPosition_GvPositionsart");
            });

            modelBuilder.Entity<GvAuszahlungPositionValuta>(entity =>
            {
                entity.HasIndex(e => e.GvAuszahlungPositionId);

                entity.Property(e => e.GvAuszahlungPositionValutaId).HasColumnName("GvAuszahlungPositionValutaID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.GvAuszahlungPositionId).HasColumnName("GvAuszahlungPositionID");

                entity.Property(e => e.GvAuszahlungPositionValutaTs)
                    .IsRequired()
                    .HasColumnName("GvAuszahlungPositionValutaTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.GvAuszahlungPosition)
                    .WithMany(p => p.GvAuszahlungPositionValuta)
                    .HasForeignKey(d => d.GvAuszahlungPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvAuszahlungPositionValuta_GvAuszahlungPosition");
            });

            modelBuilder.Entity<GvBewilligung>(entity =>
            {
                entity.HasIndex(e => e.GvGesuchId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.GvBewilligungId).HasColumnName("GvBewilligungID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GvBewilligungTs)
                    .IsRequired()
                    .HasColumnName("GvBewilligungTS")
                    .IsRowVersion();

                entity.Property(e => e.GvGesuchId).HasColumnName("GvGesuchID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.GvGesuch)
                    .WithMany(p => p.GvBewilligung)
                    .HasForeignKey(d => d.GvGesuchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvBewilligung_GvGesuch");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GvBewilligung)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvBewilligung_XUser");
            });

            modelBuilder.Entity<GvDocument>(entity =>
            {
                entity.HasIndex(e => e.BaInstitutionId);

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.GvGesuchId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.GvDocumentId).HasColumnName("GvDocumentID");

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkungen).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.GvDocumentTs)
                    .IsRequired()
                    .HasColumnName("GvDocumentTS")
                    .IsRowVersion();

                entity.Property(e => e.GvGesuchId).HasColumnName("GvGesuchID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stichworte)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.GvDocument)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .HasConstraintName("FK_GvDocument_BaInstitution");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.GvDocument)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_GvDocument_BaPerson");

                entity.HasOne(d => d.GvGesuch)
                    .WithMany(p => p.GvDocument)
                    .HasForeignKey(d => d.GvGesuchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvDocument_GvGesuch");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GvDocument)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvDocument_XUser");
            });

            modelBuilder.Entity<GvDokumenteInformation>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId)
                    .IsUnique();

                entity.Property(e => e.GvDokumenteInformationId).HasColumnName("GvDokumenteInformationID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GvDokumenteInformationTs)
                    .IsRequired()
                    .HasColumnName("GvDokumenteInformationTS")
                    .IsRowVersion();

                entity.Property(e => e.Information).IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithOne(p => p.GvDokumenteInformation)
                    .HasForeignKey<GvDokumenteInformation>(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvDokumenteInformation_BaPerson");
            });

            modelBuilder.Entity<GvFonds>(entity =>
            {
                entity.HasIndex(e => e.KbZahlungskontoId);

                entity.Property(e => e.GvFondsId).HasColumnName("GvFondsID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.BemerkungTid).HasColumnName("BemerkungTID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.GvFondsTs)
                    .IsRequired()
                    .HasColumnName("GvFondsTS")
                    .IsRowVersion();

                entity.Property(e => e.IstCh).HasColumnName("IstCH");

                entity.Property(e => e.KbZahlungskontoId).HasColumnName("KbZahlungskontoID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameKurz)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NameLang)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.KbZahlungskonto)
                    .WithMany(p => p.GvFonds)
                    .HasForeignKey(d => d.KbZahlungskontoId)
                    .HasConstraintName("FK_GvFonds_KbZahlungskonto");
            });

            modelBuilder.Entity<GvFondsXorgUnit>(entity =>
            {
                entity.ToTable("GvFonds_XOrgUnit");

                entity.HasIndex(e => e.GvFondsId);

                entity.HasIndex(e => e.OrgUnitId);

                entity.Property(e => e.GvFondsXorgUnitId).HasColumnName("GvFonds_XOrgUnitID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GvFondsId).HasColumnName("GvFondsID");

                entity.Property(e => e.GvFondsXorgUnitTs)
                    .IsRequired()
                    .HasColumnName("GvFonds_XOrgUnitTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrgUnitId).HasColumnName("OrgUnitID");

                entity.HasOne(d => d.GvFonds)
                    .WithMany(p => p.GvFondsXorgUnit)
                    .HasForeignKey(d => d.GvFondsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvFonds_XOrgUnit_GvFonds");

                entity.HasOne(d => d.OrgUnit)
                    .WithMany(p => p.GvFondsXorgUnit)
                    .HasForeignKey(d => d.OrgUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvFonds_XOrgUnit_XOrgUnit");
            });

            modelBuilder.Entity<GvGesuch>(entity =>
            {
                entity.HasIndex(e => e.AbgeschlossenesGesuchdurchIksUserId);

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.ErfasstesGesuchgeprueftdurchIksUserId);

                entity.HasIndex(e => e.GvFondsId);

                entity.HasIndex(e => e.XuserIdAutor);

                entity.Property(e => e.GvGesuchId).HasColumnName("GvGesuchID");

                entity.Property(e => e.AbgeschlossenesGesuchBemerkung).IsUnicode(false);

                entity.Property(e => e.AbgeschlossenesGesuchdurchIksUserId).HasColumnName("AbgeschlossenesGesuchdurchIKS_UserID");

                entity.Property(e => e.AbgeschlossenesGesuchgeprueftam).HasColumnType("datetime");

                entity.Property(e => e.AbschlussDatum).HasColumnType("datetime");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Begruendung).IsUnicode(false);

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.BemerkungBewilligungKompetenzstufe1).IsUnicode(false);

                entity.Property(e => e.BemerkungBewilligungKompetenzstufe2).IsUnicode(false);

                entity.Property(e => e.BetragBewilligt).HasColumnType("money");

                entity.Property(e => e.BetragBewilligtKompetenzstufe1).HasColumnType("money");

                entity.Property(e => e.BetragBewilligtKompetenzstufe2).HasColumnType("money");

                entity.Property(e => e.BewilligtAm).HasColumnType("datetime");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBewilligtKompetenzstufe1).HasColumnType("datetime");

                entity.Property(e => e.DatumBewilligtKompetenzstufe2).HasColumnType("datetime");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.ErfasstesGesuchBemerkung).IsUnicode(false);

                entity.Property(e => e.ErfasstesGesuchgeprueftam).HasColumnType("datetime");

                entity.Property(e => e.ErfasstesGesuchgeprueftdurchIksUserId).HasColumnName("ErfasstesGesuchgeprueftdurchIKS_UserID");

                entity.Property(e => e.ErfassungAbgeschlossen).HasColumnType("datetime");

                entity.Property(e => e.GesuchsDatum).HasColumnType("datetime");

                entity.Property(e => e.Gesuchsgrund)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.GvFondsId).HasColumnName("GvFondsID");

                entity.Property(e => e.GvGesuchTs)
                    .IsRequired()
                    .HasColumnName("GvGesuchTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserIdbewilligt).HasColumnName("UserIDBewilligt");

                entity.Property(e => e.XuserIdAutor).HasColumnName("XUserID_Autor");

                entity.HasOne(d => d.AbgeschlossenesGesuchdurchIksUser)
                    .WithMany(p => p.GvGesuchAbgeschlossenesGesuchdurchIksUser)
                    .HasForeignKey(d => d.AbgeschlossenesGesuchdurchIksUserId)
                    .HasConstraintName("FK_GvGesuch_AbgeschlossenesGesuchdurchIKS_UserID");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.GvGesuch)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvGesuch_BaPerson");

                entity.HasOne(d => d.ErfasstesGesuchgeprueftdurchIksUser)
                    .WithMany(p => p.GvGesuchErfasstesGesuchgeprueftdurchIksUser)
                    .HasForeignKey(d => d.ErfasstesGesuchgeprueftdurchIksUserId)
                    .HasConstraintName("FK_GvGesuch_ErfasstesGesuchgeprueftdurchIKS_UserID");

                entity.HasOne(d => d.GvFonds)
                    .WithMany(p => p.GvGesuch)
                    .HasForeignKey(d => d.GvFondsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvGesuch_GvFonds");

                entity.HasOne(d => d.XuserIdAutorNavigation)
                    .WithMany(p => p.GvGesuchXuserIdAutorNavigation)
                    .HasForeignKey(d => d.XuserIdAutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvGesuch_XUser");
            });

            modelBuilder.Entity<GvPositionsart>(entity =>
            {
                entity.HasIndex(e => e.BgKostenartId);

                entity.HasIndex(e => e.GvPositionsartIdCopyOf);

                entity.Property(e => e.GvPositionsartId)
                    .HasColumnName("GvPositionsartID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Bezeichnung).IsUnicode(false);

                entity.Property(e => e.BezeichnungTid).HasColumnName("BezeichnungTID");

                entity.Property(e => e.BgKostenartId).HasColumnName("BgKostenartID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.GvPositionsartIdCopyOf).HasColumnName("GvPositionsartID_CopyOf");

                entity.Property(e => e.GvPositionsartTs)
                    .IsRequired()
                    .HasColumnName("GvPositionsartTS")
                    .IsRowVersion();

                entity.Property(e => e.Hsonly).HasColumnName("HSOnly");

                entity.Property(e => e.IsFlb).HasColumnName("IsFLB");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BgKostenart)
                    .WithMany(p => p.GvPositionsart)
                    .HasForeignKey(d => d.BgKostenartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvPositionsart_BgKostenart");

                entity.HasOne(d => d.GvPositionsartNavigation)
                    .WithOne(p => p.InverseGvPositionsartNavigation)
                    .HasForeignKey<GvPositionsart>(d => d.GvPositionsartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GvPositionsart_GvPositionsart");

                entity.HasOne(d => d.GvPositionsartIdCopyOfNavigation)
                    .WithMany(p => p.InverseGvPositionsartIdCopyOfNavigation)
                    .HasForeignKey(d => d.GvPositionsartIdCopyOf)
                    .HasConstraintName("FK_GvPositionsart_GvPositionsartID_CopyOf");
            });

            modelBuilder.Entity<HistBaAdresse>(entity =>
            {
                entity.HasKey(e => new { e.BaAdresseId, e.VerId });

                entity.ToTable("Hist_BaAdresse");

                entity.HasIndex(e => e.BaAdresseId);

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.VerId);

                entity.HasIndex(e => new { e.BaAdresseId, e.VerId })
                    .HasName("UK_Hist_BaAdresse_BaAdresseID_VerID")
                    .IsUnique();

                entity.Property(e => e.BaAdresseId).HasColumnName("BaAdresseID");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.BaLandId).HasColumnName("BaLandID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Bezirk)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CareOf)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.HausNr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutionName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KaBetriebId).HasColumnName("KaBetriebID");

                entity.Property(e => e.KaBetriebKontaktId).HasColumnName("KaBetriebKontaktID");

                entity.Property(e => e.Kanton)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MigrationKa).HasColumnName("MigrationKA");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ort)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlatzierungInstId).HasColumnName("PlatzierungInstID");

                entity.Property(e => e.Plz)
                    .HasColumnName("PLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Postfach)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Strasse)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VerIdDeleted).HasColumnName("VerID_DELETED");

                entity.Property(e => e.VmMandantId).HasColumnName("VmMandantID");

                entity.Property(e => e.VmPriMaId).HasColumnName("VmPriMaID");

                entity.Property(e => e.ZuhandenVon)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Zusatz)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HistBaPerson>(entity =>
            {
                entity.HasKey(e => new { e.BaPersonId, e.VerId });

                entity.ToTable("Hist_BaPerson");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.Ahvnummer)
                    .HasColumnName("AHVNummer")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Alk).HasColumnName("ALK");

                entity.Property(e => e.AndereSvleistungen)
                    .HasColumnName("AndereSVLeistungen")
                    .IsUnicode(false);

                entity.Property(e => e.Anrede)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ArbeitSpezFaehigkeiten).IsUnicode(false);

                entity.Property(e => e.AufenthaltWieBaInstitutionId).HasColumnName("AufenthaltWieBaInstitutionID");

                entity.Property(e => e.AuslaenderStatusGueltigBis).HasColumnType("datetime");

                entity.Property(e => e.BaPersonIdDossiertraeger).HasColumnName("BaPersonID_Dossiertraeger");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.BemerkungenAdresse).IsUnicode(false);

                entity.Property(e => e.BemerkungenSv)
                    .HasColumnName("BemerkungenSV")
                    .IsUnicode(false);

                entity.Property(e => e.BeruflicheMassnahmeIv).HasColumnName("BeruflicheMassnahmeIV");

                entity.Property(e => e.Bffnummer)
                    .HasColumnName("BFFNummer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Briefanrede)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BsvbehinderungsartCode).HasColumnName("BSVBehinderungsartCode");

                entity.Property(e => e.Bvgrente).HasColumnName("BVGRente");

                entity.Property(e => e.CausweisDatum)
                    .HasColumnName("CAusweisDatum")
                    .HasColumnType("datetime");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumAssistenzbeitrag).HasColumnType("datetime");

                entity.Property(e => e.DatumAsylgesuch).HasColumnType("datetime");

                entity.Property(e => e.DatumEinbezugFaz).HasColumnType("datetime");

                entity.Property(e => e.DatumIvVerfuegung).HasColumnType("datetime");

                entity.Property(e => e.DebitorUpdate).HasColumnType("datetime");

                entity.Property(e => e.Einrichtpauschale).HasColumnType("money");

                entity.Property(e => e.EinwohnerregisterId)
                    .HasColumnName("EinwohnerregisterID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ErteilungVa)
                    .HasColumnName("ErteilungVA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fax)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FruehererName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Geburtsdatum).HasColumnType("datetime");

                entity.Property(e => e.HaushaltVersicherungsNummer)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Hcmcfluechtling).HasColumnName("HCMCFluechtling");

                entity.Property(e => e.HeimatgemeindeBaGemeindeId).HasColumnName("HeimatgemeindeBaGemeindeID");

                entity.Property(e => e.HeimatgemeindeCodes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Helbab)
                    .HasColumnName("HELBAb")
                    .HasColumnType("datetime");

                entity.Property(e => e.Helbanmeldung)
                    .HasColumnName("HELBAnmeldung")
                    .HasColumnType("datetime");

                entity.Property(e => e.Helbentscheid)
                    .HasColumnName("HELBEntscheid")
                    .HasColumnType("datetime");

                entity.Property(e => e.HelbentscheidCode).HasColumnName("HELBEntscheidCode");

                entity.Property(e => e.HelbkeinAntrag).HasColumnName("HELBKeinAntrag");

                entity.Property(e => e.ImKantonSeit).HasColumnType("datetime");

                entity.Property(e => e.InChseit)
                    .HasColumnName("InCHSeit")
                    .HasColumnType("datetime");

                entity.Property(e => e.InChseitGeburt).HasColumnName("InCHSeitGeburt");

                entity.Property(e => e.InGemeindeSeit).HasColumnType("datetime");

                entity.Property(e => e.IvberechtigungAnfangsStatusCode).HasColumnName("IVBerechtigungAnfangsStatusCode");

                entity.Property(e => e.IvberechtigungErsterEntscheidAb)
                    .HasColumnName("IVBerechtigungErsterEntscheidAb")
                    .HasColumnType("datetime");

                entity.Property(e => e.IvberechtigungErsterEntscheidCode).HasColumnName("IVBerechtigungErsterEntscheidCode");

                entity.Property(e => e.IvberechtigungZweiterEntscheidAb)
                    .HasColumnName("IVBerechtigungZweiterEntscheidAb")
                    .HasColumnType("datetime");

                entity.Property(e => e.IvberechtigungZweiterEntscheidCode).HasColumnName("IVBerechtigungZweiterEntscheidCode");

                entity.Property(e => e.Ivgrad).HasColumnName("IVGrad");

                entity.Property(e => e.Ivhilfsmittel).HasColumnName("IVHilfsmittel");

                entity.Property(e => e.Ivtaggeld).HasColumnName("IVTaggeld");

                entity.Property(e => e.KantonaleReferenznummer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KbKostenstelleId).HasColumnName("KbKostenstelleID");

                entity.Property(e => e.KopfquoteAbDatum).HasColumnType("datetime");

                entity.Property(e => e.KopfquoteBaInstitutionId).HasColumnName("Kopfquote_BaInstitutionID");

                entity.Property(e => e.KopfquoteBisDatum).HasColumnType("datetime");

                entity.Property(e => e.Ktg).HasColumnName("KTG");

                entity.Property(e => e.MedizinischeMassnahmeIv).HasColumnName("MedizinischeMassnahmeIV");

                entity.Property(e => e.MietdepotPi).HasColumnName("MietdepotPI");

                entity.Property(e => e.MigrationKa).HasColumnName("MigrationKA");

                entity.Property(e => e.MobilTel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobilTel1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobilTel2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NavigatorZusatz)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Neanmeldung)
                    .HasColumnName("NEAnmeldung")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nnummer)
                    .HasColumnName("NNummer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PauschaleAktualDatum).HasColumnType("datetime");

                entity.Property(e => e.PersonSichtbarSdflag).HasColumnName("PersonSichtbarSDFlag");

                entity.Property(e => e.PraemienuebernahmeBis).HasColumnType("datetime");

                entity.Property(e => e.PraemienuebernahmeVon).HasColumnType("datetime");

                entity.Property(e => e.PuanzahlVerlustscheine).HasColumnName("PUAnzahlVerlustscheine");

                entity.Property(e => e.Pukrankenkasse)
                    .HasColumnName("PUKrankenkasse")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.Property(e => e.Sprachpauschale).HasColumnType("money");

                entity.Property(e => e.Sterbedatum).HasColumnType("datetime");

                entity.Property(e => e.TelefonG)
                    .HasColumnName("Telefon_G")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonP)
                    .HasColumnName("Telefon_P")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UntWohnsitzKanton)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UntWohnsitzOrt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UntWohnsitzPlz)
                    .HasColumnName("UntWohnsitzPLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Uvgrente).HasColumnName("UVGRente");

                entity.Property(e => e.Uvgtaggeld).HasColumnName("UVGTaggeld");

                entity.Property(e => e.VerIdDeleted).HasColumnName("VerID_DELETED");

                entity.Property(e => e.Versichertennummer)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Visdat36Area)
                    .HasColumnName("visdat36Area")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Visdat36Id)
                    .HasColumnName("visdat36ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.VormundPi).HasColumnName("VormundPI");

                entity.Property(e => e.Vorname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Vorname2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WegzugDatum).HasColumnType("datetime");

                entity.Property(e => e.WegzugKanton)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WegzugOrt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WegzugPlz)
                    .HasColumnName("WegzugPLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WichtigerHinweis)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.WohnsitzWieBaPersonId).HasColumnName("WohnsitzWieBaPersonID");

                entity.Property(e => e.Zarnummer)
                    .HasColumnName("ZARNummer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Zemisnummer)
                    .HasColumnName("ZEMISNummer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Zipnr).HasColumnName("ZIPNr");

                entity.Property(e => e.ZivilstandDatum).HasColumnType("datetime");

                entity.Property(e => e.ZuzugGdeDatum).HasColumnType("datetime");

                entity.Property(e => e.ZuzugGdeKanton)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ZuzugGdeOrt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZuzugGdePlz)
                    .HasColumnName("ZuzugGdePLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ZuzugKtDatum).HasColumnType("datetime");

                entity.Property(e => e.ZuzugKtKanton)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ZuzugKtOrt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZuzugKtPlz)
                    .HasColumnName("ZuzugKtPLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HistBdeferienkuerzungenXuser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Jahr, e.VerId });

                entity.ToTable("Hist_BDEFerienkuerzungen_XUser");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.FerienkuerzungStd).HasColumnType("money");

                entity.Property(e => e.VerIdDeleted).HasColumnName("VerID_DELETED");
            });

            modelBuilder.Entity<HistBdeleistung>(entity =>
            {
                entity.HasKey(e => new { e.BdeleistungId, e.VerId });

                entity.ToTable("Hist_BDELeistung");

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.BdeleistungsartId);

                entity.HasIndex(e => e.Datum);

                entity.HasIndex(e => e.Dauer);

                entity.HasIndex(e => e.Freigegeben);

                entity.HasIndex(e => e.KostenstelleOrgUnitId);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => e.Verbucht);

                entity.HasIndex(e => e.VerbuchtLd);

                entity.HasIndex(e => e.Visiert);

                entity.HasIndex(e => new { e.Datum, e.Dauer, e.UserId });

                entity.Property(e => e.BdeleistungId)
                    .HasColumnName("BDELeistungID")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.BdeleistungsartId).HasColumnName("BDELeistungsartID");

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Dauer).HasColumnType("money");

                entity.Property(e => e.KostenstelleOrgUnitId).HasColumnName("KostenstelleOrgUnitID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VerIdDeleted).HasColumnName("VerID_DELETED");

                entity.Property(e => e.Verbucht).HasColumnType("datetime");

                entity.Property(e => e.VerbuchtLd)
                    .HasColumnName("VerbuchtLD")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<HistBdeleistungsart>(entity =>
            {
                entity.HasKey(e => new { e.BdeleistungsartId, e.VerId });

                entity.ToTable("Hist_BDELeistungsart");

                entity.Property(e => e.BdeleistungsartId).HasColumnName("BDELeistungsartID");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.ArtikelNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AuswPiauftragCode).HasColumnName("AuswPIAuftragCode");

                entity.Property(e => e.Beschreibung)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BezeichnungTid).HasColumnName("BezeichnungTID");

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.Ktrahv)
                    .HasColumnName("KTRAHV")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ktriv)
                    .HasColumnName("KTRIV")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ktrnichtberechtigte)
                    .HasColumnName("KTRNichtberechtigte")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ktrstandard)
                    .HasColumnName("KTRStandard")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VerIdDeleted).HasColumnName("VerID_DELETED");
            });

            modelBuilder.Entity<HistBdesollStundenProJahrXuser>(entity =>
            {
                entity.HasKey(e => new { e.BdesollStundenProJahrXuserId, e.VerId });

                entity.ToTable("Hist_BDESollStundenProJahr_XUser");

                entity.Property(e => e.BdesollStundenProJahrXuserId).HasColumnName("BDESollStundenProJahr_XUserID");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.AprilStd).HasColumnType("money");

                entity.Property(e => e.AugustStd).HasColumnType("money");

                entity.Property(e => e.DezemberStd).HasColumnType("money");

                entity.Property(e => e.FebruarStd).HasColumnType("money");

                entity.Property(e => e.JanuarStd).HasColumnType("money");

                entity.Property(e => e.JuliStd).HasColumnType("money");

                entity.Property(e => e.JuniStd).HasColumnType("money");

                entity.Property(e => e.MaerzStd).HasColumnType("money");

                entity.Property(e => e.MaiStd).HasColumnType("money");

                entity.Property(e => e.NovemberStd).HasColumnType("money");

                entity.Property(e => e.OktoberStd).HasColumnType("money");

                entity.Property(e => e.SeptemberStd).HasColumnType("money");

                entity.Property(e => e.TotalStd).HasColumnType("money");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VerIdDeleted).HasColumnName("VerID_DELETED");
            });

            modelBuilder.Entity<HistoryVersion>(entity =>
            {
                entity.HasKey(e => e.VerId);

                entity.HasIndex(e => new { e.SessionId, e.VerId });

                entity.HasIndex(e => new { e.VerId, e.VersionDate });

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.AppName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AppUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DbUser)
                    .IsRequired()
                    .HasColumnName("dbUser")
                    .HasColumnType("sysname")
                    .HasMaxLength(4000);

                entity.Property(e => e.HostName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.SystemUser)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserAction)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.VersionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<HistXorgUnit>(entity =>
            {
                entity.HasKey(e => new { e.OrgUnitId, e.VerId });

                entity.ToTable("Hist_XOrgUnit");

                entity.HasIndex(e => e.ChiefId);

                entity.HasIndex(e => e.Kostenstelle);

                entity.HasIndex(e => e.Mandantennummer);

                entity.HasIndex(e => e.OeitemTypCode);

                entity.HasIndex(e => e.OrgUnitId);

                entity.HasIndex(e => e.ParentId);

                entity.HasIndex(e => e.RepresentativeId);

                entity.HasIndex(e => new { e.OrgUnitId, e.VerId, e.Kostenstelle });

                entity.HasIndex(e => new { e.ParentId, e.Mandantennummer, e.VerId, e.OrgUnitId })
                    .HasName("IX_Hist_XOrgUnit_ParentID_MandantenNr_VerID_OrgUnitID");

                entity.Property(e => e.OrgUnitId).HasColumnName("OrgUnitID");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.AdAbteilung)
                    .HasColumnName("AD_Abteilung")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Adressat)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Adresse)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.AdresseAbteilung)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AdresseHausNr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AdresseKgs)
                    .HasColumnName("AdresseKGS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AdresseOrt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdressePlz)
                    .HasColumnName("AdressePLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AdresseStrasse)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ChiefId).HasColumnName("ChiefID");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Internet)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Logo).IsUnicode(false);

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModulId).HasColumnName("ModulID");

                entity.Property(e => e.OeitemTypCode).HasColumnName("OEItemTypCode");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Pckonto)
                    .HasColumnName("PCKonto")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Postfach)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RechtsdienstUserId).HasColumnName("RechtsdienstUserID");

                entity.Property(e => e.RepresentativeId).HasColumnName("RepresentativeID");

                entity.Property(e => e.StellvertreterId).HasColumnName("StellvertreterID");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Text1)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Text2)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Text3)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Text4)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.VerIdDeleted).HasColumnName("VerID_DELETED");

                entity.Property(e => e.Www)
                    .HasColumnName("WWW")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.XprofileId).HasColumnName("XProfileID");
            });

            modelBuilder.Entity<HistXorgUnitUser>(entity =>
            {
                entity.HasKey(e => new { e.OrgUnitId, e.UserId, e.VerId });

                entity.ToTable("Hist_XOrgUnit_User");

                entity.HasIndex(e => e.OrgUnitMemberCode);

                entity.HasIndex(e => new { e.UserId, e.OrgUnitMemberCode })
                    .HasName("IX_Hist_XOrgUnit_User_UserID");

                entity.HasIndex(e => new { e.UserId, e.OrgUnitMemberCode, e.OrgUnitId, e.VerId })
                    .HasName("IX_Hist_XOrgUnit_User_UserIDMemberCodeOrgUnitIDVerID");

                entity.Property(e => e.OrgUnitId).HasColumnName("OrgUnitID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.VerIdDeleted).HasColumnName("VerID_DELETED");

                entity.Property(e => e.XorgUnitUserId).HasColumnName("XOrgUnit_UserID");
            });

            modelBuilder.Entity<HistXuser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.VerId });

                entity.ToTable("Hist_XUser");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.Austrittsdatum).HasColumnType("datetime");

                entity.Property(e => e.Bemerkungen)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ChiefId).HasColumnName("ChiefID");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Eintrittsdatum).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Funktion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Geburtstag).HasColumnType("datetime");

                entity.Property(e => e.GrantPermGroupId).HasColumnName("GrantPermGroupID");

                entity.Property(e => e.IsUserBiagadmin).HasColumnName("IsUserBIAGAdmin");

                entity.Property(e => e.KeinBdeexport).HasColumnName("KeinBDEExport");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LogonName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MigHerkunft)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MigMakuerzel)
                    .HasColumnName("MigMAKuerzel")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MitarbeiterNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModulId).HasColumnName("ModulID");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PermissionGroupId).HasColumnName("PermissionGroupID");

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneIntern)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneMobile)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneOffice)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhonePrivat)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrimaryUserId).HasColumnName("PrimaryUserID");

                entity.Property(e => e.SachbearbeiterId).HasColumnName("SachbearbeiterID");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Text1)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Text2)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.VerIdDeleted).HasColumnName("VerID_DELETED");

                entity.Property(e => e.Visdat36Area)
                    .HasColumnName("visdat36Area")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Visdat36Id)
                    .HasColumnName("visdat36ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Visdat36Name)
                    .HasColumnName("visdat36Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Visdat36SourceFile)
                    .HasColumnName("visdat36SourceFile")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WeitereKostentraeger)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.XprofileId).HasColumnName("XProfileID");
            });

            modelBuilder.Entity<HistXuserStundenansatz>(entity =>
            {
                entity.HasKey(e => new { e.XuserStundenansatzId, e.VerId });

                entity.ToTable("Hist_XUserStundenansatz");

                entity.Property(e => e.XuserStundenansatzId).HasColumnName("XUserStundenansatzID");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lohnart1).HasColumnType("money");

                entity.Property(e => e.Lohnart10).HasColumnType("money");

                entity.Property(e => e.Lohnart11).HasColumnType("money");

                entity.Property(e => e.Lohnart12).HasColumnType("money");

                entity.Property(e => e.Lohnart13).HasColumnType("money");

                entity.Property(e => e.Lohnart14).HasColumnType("money");

                entity.Property(e => e.Lohnart15).HasColumnType("money");

                entity.Property(e => e.Lohnart16).HasColumnType("money");

                entity.Property(e => e.Lohnart17).HasColumnType("money");

                entity.Property(e => e.Lohnart18).HasColumnType("money");

                entity.Property(e => e.Lohnart19).HasColumnType("money");

                entity.Property(e => e.Lohnart2).HasColumnType("money");

                entity.Property(e => e.Lohnart20).HasColumnType("money");

                entity.Property(e => e.Lohnart3).HasColumnType("money");

                entity.Property(e => e.Lohnart4).HasColumnType("money");

                entity.Property(e => e.Lohnart5).HasColumnType("money");

                entity.Property(e => e.Lohnart6).HasColumnType("money");

                entity.Property(e => e.Lohnart7).HasColumnType("money");

                entity.Property(e => e.Lohnart8).HasColumnType("money");

                entity.Property(e => e.Lohnart9).HasColumnType("money");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VerIdDeleted).HasColumnName("VerID_DELETED");
            });

            modelBuilder.Entity<IkAbklaerung>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.IkAbklaerungId).HasColumnName("IkAbklaerungID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumAbklaerung).HasColumnType("datetime");

                entity.Property(e => e.DatumAuswertung).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.IkAbklaerungTs)
                    .IsRequired()
                    .HasColumnName("IkAbklaerungTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.IkAbklaerung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_IkAbklaerung_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IkAbklaerung)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_IkAbklaerung_XUser");
            });

            modelBuilder.Entity<IkAnzeige>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.IkAnzeigeId).HasColumnName("IkAnzeigeID");

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EroeffnungGrund)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.IkAnzeigeTs)
                    .IsRequired()
                    .HasColumnName("IkAnzeigeTS")
                    .IsRowVersion();

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.IkAnzeige)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IkAnzeige_FaLeistung");
            });

            modelBuilder.Entity<IkBetreibung>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.IkRechtstitelId);

                entity.Property(e => e.IkBetreibungId).HasColumnName("IkBetreibungID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.BetreibungAm).HasColumnType("datetime");

                entity.Property(e => e.BetreibungAmt)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BetreibungBetrag).HasColumnType("money");

                entity.Property(e => e.BetreibungBis).HasColumnType("datetime");

                entity.Property(e => e.BetreibungFortsetzungAm).HasColumnType("datetime");

                entity.Property(e => e.BetreibungNummer)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BetreibungRechtsoeffnungAm).HasColumnType("datetime");

                entity.Property(e => e.BetreibungVerwertungAm).HasColumnType("datetime");

                entity.Property(e => e.BetreibungVon).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Glaeubiger)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IkBetreibungStatusCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.IkBetreibungTs)
                    .IsRequired()
                    .HasColumnName("IkBetreibungTS")
                    .IsRowVersion();

                entity.Property(e => e.IkRechtstitelId).HasColumnName("IkRechtstitelID");

                entity.Property(e => e.IkVerlustscheinStatusCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.IkVerlustscheinTypCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.VerlustscheinAm).HasColumnType("datetime");

                entity.Property(e => e.VerlustscheinAmt)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VerlustscheinBetrag).HasColumnType("money");

                entity.Property(e => e.VerlustscheinKosten).HasColumnType("money");

                entity.Property(e => e.VerlustscheinNummer)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VerlustscheinVerjaehrungAm).HasColumnType("datetime");

                entity.Property(e => e.VerlustscheinZins).HasColumnType("money");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.IkBetreibung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_IkBetreibung_FaLeistung");

                entity.HasOne(d => d.IkRechtstitel)
                    .WithMany(p => p.IkBetreibung)
                    .HasForeignKey(d => d.IkRechtstitelId)
                    .HasConstraintName("FK_IkBetreibung_IkRechtstitel");
            });

            modelBuilder.Entity<IkBetreibungAusgleich>(entity =>
            {
                entity.HasIndex(e => e.AusgleichBuchungId);

                entity.HasIndex(e => e.IkBetreibungId);

                entity.Property(e => e.IkBetreibungAusgleichId).HasColumnName("IkBetreibungAusgleichID");

                entity.Property(e => e.AusgleichBuchungId).HasColumnName("AusgleichBuchungID");

                entity.Property(e => e.Betrag)
                    .HasColumnType("money")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IkBetreibungAusgleichTs)
                    .IsRequired()
                    .HasColumnName("IkBetreibungAusgleichTS")
                    .IsRowVersion();

                entity.Property(e => e.IkBetreibungId).HasColumnName("IkBetreibungID");

                entity.HasOne(d => d.AusgleichBuchung)
                    .WithMany(p => p.IkBetreibungAusgleich)
                    .HasForeignKey(d => d.AusgleichBuchungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IkBetreibungAusgleich_KbBuchung");

                entity.HasOne(d => d.IkBetreibung)
                    .WithMany(p => p.IkBetreibungAusgleich)
                    .HasForeignKey(d => d.IkBetreibungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IkBetreibungAusgleich_IkBetreibung");
            });

            modelBuilder.Entity<IkEinkommen>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.IkRechtstitelId);

                entity.Property(e => e.IkEinkommenId).HasColumnName("IkEinkommenID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GueltigBis).HasColumnType("datetime");

                entity.Property(e => e.GueltigVon).HasColumnType("datetime");

                entity.Property(e => e.IkEinkommenTs)
                    .IsRequired()
                    .HasColumnName("IkEinkommenTS")
                    .IsRowVersion();

                entity.Property(e => e.IkRechtstitelId).HasColumnName("IkRechtstitelID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.IkEinkommen)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IkEinkommen_BaPerson");

                entity.HasOne(d => d.IkRechtstitel)
                    .WithMany(p => p.IkEinkommen)
                    .HasForeignKey(d => d.IkRechtstitelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IkEinkommen_IkRechtstitel");
            });

            modelBuilder.Entity<IkForderung>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.IkRechtstitelId);

                entity.Property(e => e.IkForderungId).HasColumnName("IkForderungID");

                entity.Property(e => e.Albvberechtigt).HasColumnName("ALBVBerechtigt");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.DatumAnpassenAb).HasColumnType("datetime");

                entity.Property(e => e.DatumGueltigBis).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.IkForderungTs)
                    .IsRequired()
                    .HasColumnName("IkForderungTS")
                    .IsRowVersion();

                entity.Property(e => e.IkRechtstitelId).HasColumnName("IkRechtstitelID");

                entity.Property(e => e.IndexStandBeiBerechnung).HasColumnType("money");

                entity.Property(e => e.IndexStandDatum).HasColumnType("datetime");

                entity.Property(e => e.TeilAlbv).HasColumnName("TeilALBV");

                entity.Property(e => e.TeilAlbvbetrag)
                    .HasColumnName("TeilALBVBetrag")
                    .HasColumnType("money");

                entity.Property(e => e.TmpAiForderungIdPeriodisch).HasColumnName("_tmp_AiForderungID_Periodisch");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.IkForderung)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_IkForderung_BaPerson");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.IkForderung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_IkForderung_FaLeistung");

                entity.HasOne(d => d.IkRechtstitel)
                    .WithMany(p => p.IkForderung)
                    .HasForeignKey(d => d.IkRechtstitelId)
                    .HasConstraintName("FK_IkForderung_IkRechtstitel");
            });

            modelBuilder.Entity<IkForderungBgKostenart>(entity =>
            {
                entity.ToTable("IkForderung_BgKostenart");

                entity.Property(e => e.IkForderungBgKostenartId).HasColumnName("IkForderung_BgKostenartID");

                entity.Property(e => e.BgKostenartIdAuszahlung).HasColumnName("BgKostenartID_Auszahlung");

                entity.Property(e => e.BgKostenartIdForderung).HasColumnName("BgKostenartID_Forderung");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IkForderungBgKostenartTs)
                    .IsRequired()
                    .HasColumnName("IkForderung_BgKostenartTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BgKostenartIdAuszahlungNavigation)
                    .WithMany(p => p.IkForderungBgKostenartBgKostenartIdAuszahlungNavigation)
                    .HasForeignKey(d => d.BgKostenartIdAuszahlung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IkForderung_BgKostenart_BgKostenart_Auszahlung");

                entity.HasOne(d => d.BgKostenartIdForderungNavigation)
                    .WithMany(p => p.IkForderungBgKostenartBgKostenartIdForderungNavigation)
                    .HasForeignKey(d => d.BgKostenartIdForderung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IkForderung_BgKostenart_BgKostenart_Forderung");
            });

            modelBuilder.Entity<IkForderungBgKostenartHist>(entity =>
            {
                entity.HasIndex(e => e.BgKostenartId);

                entity.Property(e => e.IkForderungBgKostenartHistId).HasColumnName("IkForderungBgKostenartHistID");

                entity.Property(e => e.BgKostenartId).HasColumnName("BgKostenartID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.IkForderungBgKostenartHistTs)
                    .IsRequired()
                    .HasColumnName("IkForderungBgKostenartHistTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BgKostenart)
                    .WithMany(p => p.IkForderungBgKostenartHist)
                    .HasForeignKey(d => d.BgKostenartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IkForderungBgKostenartHist_BgKostenart");
            });

            modelBuilder.Entity<IkForderungPosition>(entity =>
            {
                entity.HasIndex(e => e.IkForderungId)
                    .HasName("IX_IkForderungPosition_IkForderunngID");

                entity.HasIndex(e => e.IkPositionId);

                entity.Property(e => e.IkForderungPositionId).HasColumnName("IkForderungPositionID");

                entity.Property(e => e.IkForderungId).HasColumnName("IkForderungID");

                entity.Property(e => e.IkForderungPositionTs)
                    .IsRequired()
                    .HasColumnName("IkForderungPositionTS")
                    .IsRowVersion();

                entity.Property(e => e.IkPositionId).HasColumnName("IkPositionID");

                entity.HasOne(d => d.IkForderung)
                    .WithMany(p => p.IkForderungPosition)
                    .HasForeignKey(d => d.IkForderungId)
                    .HasConstraintName("FK_IkForderungPosition_IkForderung");

                entity.HasOne(d => d.IkPosition)
                    .WithMany(p => p.IkForderungPosition)
                    .HasForeignKey(d => d.IkPositionId)
                    .HasConstraintName("FK_IkForderungPosition_IkPosition");
            });

            modelBuilder.Entity<IkGlaeubiger>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.BaPersonIdAntragStellendePerson);

                entity.HasIndex(e => e.BaZahlungswegId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.IkRechtstitelId);

                entity.HasIndex(e => new { e.BaPersonId, e.IkRechtstitelId, e.FaLeistungId })
                    .HasName("IX_IkGlaeubiger_BaPersonIDIkRechtstitelIDFaLeistungID_Unique")
                    .IsUnique();

                entity.Property(e => e.IkGlaeubigerId).HasColumnName("IkGlaeubigerID");

                entity.Property(e => e.Ausbildung)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.BaPersonIdAntragStellendePerson).HasColumnName("BaPersonID_AntragStellendePerson");

                entity.Property(e => e.BaZahlungswegId).HasColumnName("BaZahlungswegID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.IkGlaeubigerTs)
                    .IsRequired()
                    .HasColumnName("IkGlaeubigerTS")
                    .IsRowVersion();

                entity.Property(e => e.IkRechtstitelId).HasColumnName("IkRechtstitelID");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.IkGlaeubigerBaPerson)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IkGlaeubiger_BaPerson");

                entity.HasOne(d => d.BaPersonIdAntragStellendePersonNavigation)
                    .WithMany(p => p.IkGlaeubigerBaPersonIdAntragStellendePersonNavigation)
                    .HasForeignKey(d => d.BaPersonIdAntragStellendePerson)
                    .HasConstraintName("FK_IkGlaeubiger_BaPerson_AntragStellendePerson");

                entity.HasOne(d => d.BaZahlungsweg)
                    .WithMany(p => p.IkGlaeubiger)
                    .HasForeignKey(d => d.BaZahlungswegId)
                    .HasConstraintName("FK_IkGlaeubiger_BaZahlungsweg");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.IkGlaeubiger)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_IkGlaeubiger_FaLeistung");

                entity.HasOne(d => d.IkRechtstitel)
                    .WithMany(p => p.IkGlaeubiger)
                    .HasForeignKey(d => d.IkRechtstitelId)
                    .HasConstraintName("FK_IkGlaeubiger_IkRechtstitel");
            });

            modelBuilder.Entity<IkLandesindex>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UK_IkLandesindex_Name")
                    .IsUnique();

                entity.Property(e => e.IkLandesindexId).HasColumnName("IkLandesindexID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IkLandesindexTs)
                    .IsRequired()
                    .HasColumnName("IkLandesindexTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IkLandesindexWert>(entity =>
            {
                entity.HasIndex(e => e.IkLandesindexId);

                entity.HasIndex(e => new { e.IkLandesindexId, e.Jahr, e.Monat })
                    .HasName("UK_IkLandesindexWert_IkLandesindexID_Jahr_Monat")
                    .IsUnique();

                entity.HasIndex(e => new { e.IkLandesindexId, e.Jahr, e.Monat, e.Wert });

                entity.Property(e => e.IkLandesindexWertId).HasColumnName("IkLandesindexWertID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IkLandesindexId).HasColumnName("IkLandesindexID");

                entity.Property(e => e.IkLandesindexWertTs)
                    .IsRequired()
                    .HasColumnName("IkLandesindexWertTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Wert).HasColumnType("money");

                entity.HasOne(d => d.IkLandesindex)
                    .WithMany(p => p.IkLandesindexWert)
                    .HasForeignKey(d => d.IkLandesindexId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IkLandesindexWert_IkLandesindex");
            });

            modelBuilder.Entity<IkPosition>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.IkRechtstitelId);

                entity.HasIndex(e => new { e.BaPersonId, e.IkPositionId, e.Datum, e.TotalAliment, e.Albvberechtigt });

                entity.Property(e => e.IkPositionId).HasColumnName("IkPositionID");

                entity.Property(e => e.Albvberechtigt)
                    .HasColumnName("ALBVBerechtigt")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BetragAlbv)
                    .HasColumnName("BetragALBV")
                    .HasColumnType("money");

                entity.Property(e => e.BetragAlbvsoll)
                    .HasColumnName("BetragALBVSoll")
                    .HasColumnType("money");

                entity.Property(e => e.BetragAlbvverrechnung)
                    .HasColumnName("BetragALBVverrechnung")
                    .HasColumnType("money");

                entity.Property(e => e.BetragAuszahlung).HasColumnType("money");

                entity.Property(e => e.BetragEinmalig).HasColumnType("money");

                entity.Property(e => e.BetragIstNegativ).HasDefaultValueSql("(0)");

                entity.Property(e => e.BetragKiZulage).HasColumnType("money");

                entity.Property(e => e.BetragKiZulageSoll).HasColumnType("money");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Einmalig).HasDefaultValueSql("(0)");

                entity.Property(e => e.ErledigterMonat).HasDefaultValueSql("(0)");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.IkPositionTs)
                    .IsRequired()
                    .HasColumnName("IkPositionTS")
                    .IsRowVersion();

                entity.Property(e => e.IkRechtstitelId).HasColumnName("IkRechtstitelID");

                entity.Property(e => e.IndexStandBeiBerechnung).HasColumnType("money");

                entity.Property(e => e.IndexStandDatum).HasColumnType("datetime");

                entity.Property(e => e.TmpAiForderungId).HasColumnName("_tmp_AiForderungID");

                entity.Property(e => e.TmpAiForderungIdEinmalig).HasColumnName("_tmp_AiForderungID_Einmalig");

                entity.Property(e => e.TotalAliment).HasColumnType("money");

                entity.Property(e => e.TotalAlimentSoll).HasColumnType("money");

                entity.Property(e => e.Unterstuetzungsfall).HasDefaultValueSql("(0)");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.IkPosition)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_IkPosition_BaPerson");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.IkPosition)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_IkPosition_FaLeistung");

                entity.HasOne(d => d.IkRechtstitel)
                    .WithMany(p => p.IkPosition)
                    .HasForeignKey(d => d.IkRechtstitelId)
                    .HasConstraintName("FK_IkPosition_IkRechtstitel");
            });

            modelBuilder.Entity<IkRatenplan>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.IkRatenplanId).HasColumnName("IkRatenplanID");

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BetragProMonat).HasColumnType("money");

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.GesamtBetrag).HasColumnType("money");

                entity.Property(e => e.IkRatenplanTs)
                    .IsRequired()
                    .HasColumnName("IkRatenplanTS")
                    .IsRowVersion();

                entity.Property(e => e.LetzterProMonat).HasColumnType("money");

                entity.Property(e => e.VereinbarungVom).HasColumnType("datetime");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.IkRatenplan)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IkRatenplan_FaLeistung");
            });

            modelBuilder.Entity<IkRatenplanForderung>(entity =>
            {
                entity.HasIndex(e => e.IkForderungId);

                entity.HasIndex(e => e.IkPositionId);

                entity.HasIndex(e => e.IkRatenplanId);

                entity.HasIndex(e => e.IkRechtstitelId);

                entity.Property(e => e.IkRatenplanForderungId).HasColumnName("IkRatenplanForderungID");

                entity.Property(e => e.IkForderungId).HasColumnName("IkForderungID");

                entity.Property(e => e.IkPositionId).HasColumnName("IkPositionID");

                entity.Property(e => e.IkRatenplanForderungTs)
                    .IsRequired()
                    .HasColumnName("IkRatenplanForderungTS")
                    .IsRowVersion();

                entity.Property(e => e.IkRatenplanId).HasColumnName("IkRatenplanID");

                entity.Property(e => e.IkRechtstitelId).HasColumnName("IkRechtstitelID");

                entity.HasOne(d => d.IkForderung)
                    .WithMany(p => p.IkRatenplanForderung)
                    .HasForeignKey(d => d.IkForderungId)
                    .HasConstraintName("FK_IkRatenplanForderung_IkForderung");

                entity.HasOne(d => d.IkPosition)
                    .WithMany(p => p.IkRatenplanForderung)
                    .HasForeignKey(d => d.IkPositionId)
                    .HasConstraintName("FK_IkRatenplanForderung_IkPosition");

                entity.HasOne(d => d.IkRatenplan)
                    .WithMany(p => p.IkRatenplanForderung)
                    .HasForeignKey(d => d.IkRatenplanId)
                    .HasConstraintName("FK_IkRatenplanForderung_IkRatenplan");

                entity.HasOne(d => d.IkRechtstitel)
                    .WithMany(p => p.IkRatenplanForderung)
                    .HasForeignKey(d => d.IkRechtstitelId)
                    .HasConstraintName("FK_IkRatenplanForderung_IkRechtstitel");
            });

            modelBuilder.Entity<IkRechtstitel>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.IkRechtstitelId).HasColumnName("IkRechtstitelID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.BasisEhegattenalimente).HasColumnType("money");

                entity.Property(e => e.BasisKinderalimente).HasColumnType("money");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.ElterlicheSorgeBemerkung)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.IkBezugKinderzulagenCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.IkRechtstitelGueltigBis).HasColumnType("datetime");

                entity.Property(e => e.IkRechtstitelGueltigVon).HasColumnType("datetime");

                entity.Property(e => e.IkRechtstitelStatusCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.IkRechtstitelTs)
                    .IsRequired()
                    .HasColumnName("IkRechtstitelTS")
                    .IsRowVersion();

                entity.Property(e => e.IndexStandVom).HasColumnType("datetime");

                entity.Property(e => e.InkassoFallName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RechtstitelDatumVon).HasColumnType("datetime");

                entity.Property(e => e.RechtstitelInfo)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.RechtstitelRechtskraeftig).HasColumnType("datetime");

                entity.Property(e => e.SchuldnerMahnen).HasDefaultValueSql("((1))");

                entity.Property(e => e.VerjaehrungAm).HasColumnType("datetime");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.IkRechtstitel)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_IkRechtstitel_BaPerson");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.IkRechtstitel)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IkRechtstitel_FaLeistung");
            });

            modelBuilder.Entity<IkVerrechnungskonto>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.IkRechtstitelId);

                entity.Property(e => e.IkVerrechnungskontoId).HasColumnName("IkVerrechnungskontoID");

                entity.Property(e => e.AnnulliertAm).HasColumnType("datetime");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.BetragProMonat).HasColumnType("money");

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.Grundforderung).HasColumnType("money");

                entity.Property(e => e.IkRechtstitelId).HasColumnName("IkRechtstitelID");

                entity.Property(e => e.IkVerrechnungskontoTs)
                    .IsRequired()
                    .HasColumnName("IkVerrechnungskontoTS")
                    .IsRowVersion();

                entity.Property(e => e.LetzterMonat).HasColumnType("money");

                entity.Property(e => e.VereinbarungVom).HasColumnType("datetime");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.IkVerrechnungskonto)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IkVerrechnungskonto_BaPerson");

                entity.HasOne(d => d.IkRechtstitel)
                    .WithMany(p => p.IkVerrechnungskonto)
                    .HasForeignKey(d => d.IkRechtstitelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IkVerrechnungskonto_IkRechtstitel");
            });

            modelBuilder.Entity<KaAbklaerungIntake>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaAbklaerungIntakeId).HasColumnName("KaAbklaerungIntakeID");

                entity.Property(e => e.AsdFragen).IsUnicode(false);

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.DatumIntegration).HasColumnType("datetime");

                entity.Property(e => e.DocumentIdFormularAsD).HasColumnName("DocumentID_FormularAsD");

                entity.Property(e => e.DocumentIdIntegration).HasColumnName("DocumentID_Integration");

                entity.Property(e => e.DocumentIdZusammenfassungEg).HasColumnName("DocumentID_ZusammenfassungEG");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Gespraechstermin).HasColumnType("datetime");

                entity.Property(e => e.KaAbklaerungIntakeTs)
                    .IsRequired()
                    .HasColumnName("KaAbklaerungIntakeTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaAbklaerungIntake)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaAbklaerungIntake_FaLeistung");
            });

            modelBuilder.Entity<KaAbklaerungVertieft>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.KaKurserfassungId);

                entity.Property(e => e.KaAbklaerungVertieftId).HasColumnName("KaAbklaerungVertieftID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.DatumAustritt).HasColumnType("datetime");

                entity.Property(e => e.DatumIntegration).HasColumnType("datetime");

                entity.Property(e => e.DatumKursAbbruch).HasColumnType("datetime");

                entity.Property(e => e.DocumentIdIntegration).HasColumnName("DocumentID_Integration");

                entity.Property(e => e.DocumentIdSchlussbericht).HasColumnName("DocumentID_Schlussbericht");

                entity.Property(e => e.EinsatzBis).HasColumnType("datetime");

                entity.Property(e => e.EinsatzVon).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaAbklaerungVertieftTs)
                    .IsRequired()
                    .HasColumnName("KaAbklaerungVertieftTS")
                    .IsRowVersion();

                entity.Property(e => e.KaKurserfassungId).HasColumnName("KaKurserfassungID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaAbklaerungVertieft)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaAbklaerungVertieft_FaLeistung");

                entity.HasOne(d => d.KaKurserfassung)
                    .WithMany(p => p.KaAbklaerungVertieft)
                    .HasForeignKey(d => d.KaKurserfassungId)
                    .HasConstraintName("FK_KaAbklaerungVertieft_KaKurserfassung");
            });

            modelBuilder.Entity<KaAbklaerungVertieftProbeeinsatz>(entity =>
            {
                entity.HasIndex(e => e.KaAbklaerungVertieftId);

                entity.Property(e => e.KaAbklaerungVertieftProbeeinsatzId).HasColumnName("KaAbklaerungVertieftProbeeinsatzID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.DocumentIdProzessschritt).HasColumnName("DocumentID_Prozessschritt");

                entity.Property(e => e.KaAbklaerungVertieftId).HasColumnName("KaAbklaerungVertieftID");

                entity.Property(e => e.KaAbklaerungVertieftProbeeinsatzTs)
                    .IsRequired()
                    .HasColumnName("KaAbklaerungVertieftProbeeinsatzTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.KaAbklaerungVertieft)
                    .WithMany(p => p.KaAbklaerungVertieftProbeeinsatz)
                    .HasForeignKey(d => d.KaAbklaerungVertieftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaAbklaerungVertieftProbeeinsatz_KaAbklaerungVertieft");
            });

            modelBuilder.Entity<KaAkzuweiser>(entity =>
            {
                entity.ToTable("KaAKZuweiser");

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaAkzuweiserId).HasColumnName("KaAKZuweiserID");

                entity.Property(e => e.BeraterId).HasColumnName("BeraterID");

                entity.Property(e => e.Erfassung).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.KaAkzuweiserTs)
                    .IsRequired()
                    .HasColumnName("KaAKZuweiserTS")
                    .IsRowVersion();

                entity.Property(e => e.SichtbarSdflag)
                    .HasColumnName("SichtbarSDFlag")
                    .HasDefaultValueSql("(0)");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaAkzuweiser)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaAKZuweiser_FaLeistung");
            });

            modelBuilder.Entity<KaAllgemein>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaAllgemeinId).HasColumnName("KaAllgemeinID");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaAllgemeinTs)
                    .IsRequired()
                    .HasColumnName("KaAllgemeinTS")
                    .IsRowVersion();

                entity.Property(e => e.SichtbarSdflag)
                    .HasColumnName("SichtbarSDFlag")
                    .HasDefaultValueSql("(0)");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaAllgemein)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaAllgemein_FaLeistung");
            });

            modelBuilder.Entity<KaAmmBesch>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.KaEinsatzId);

                entity.Property(e => e.KaAmmBeschId).HasColumnName("KaAmmBeschID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.GedrucktFlag).HasColumnName("gedrucktFlag");

                entity.Property(e => e.KaAkzuweiserTs)
                    .IsRequired()
                    .HasColumnName("KaAKZuweiserTS")
                    .IsRowVersion();

                entity.Property(e => e.KaEinsatzId).HasColumnName("KaEinsatzID");

                entity.Property(e => e.KaEinsatzplatzId).HasColumnName("KaEinsatzplatzID");

                entity.Property(e => e.ZustaendigKaId).HasColumnName("ZustaendigKaID");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.KaAmmBesch)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaAmmBesch_BaPerson");

                entity.HasOne(d => d.KaEinsatz)
                    .WithMany(p => p.KaAmmBesch)
                    .HasForeignKey(d => d.KaEinsatzId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaAmmBesch_KaEinsatz");

                entity.HasOne(d => d.KaEinsatzplatz)
                    .WithMany(p => p.KaAmmBesch)
                    .HasForeignKey(d => d.KaEinsatzplatzId)
                    .HasConstraintName("FK_KaAmmBesch_KaEinsatzplatz");
            });

            modelBuilder.Entity<KaArbeitsrapport>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.KaEinsatzId);

                entity.Property(e => e.KaArbeitsrapportId).HasColumnName("KaArbeitsrapportID");

                entity.Property(e => e.AmAnwCode).HasColumnName("AM_AnwCode");

                entity.Property(e => e.AmBemerkung)
                    .HasColumnName("AM_Bemerkung")
                    .IsUnicode(false);

                entity.Property(e => e.AmStd).HasColumnName("AM_Std");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.KaArbeitsrapportTs)
                    .IsRequired()
                    .HasColumnName("KaArbeitsrapportTS")
                    .IsRowVersion();

                entity.Property(e => e.KaEinsatzId).HasColumnName("KaEinsatzID");

                entity.Property(e => e.PmAnwCode).HasColumnName("PM_AnwCode");

                entity.Property(e => e.PmBemerkung)
                    .HasColumnName("PM_Bemerkung")
                    .IsUnicode(false);

                entity.Property(e => e.PmStd).HasColumnName("PM_Std");

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.KaArbeitsrapport)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaArbeitsrapport_BaPerson");
            });

            modelBuilder.Entity<KaAssistenz>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaAssistenzId).HasColumnName("KaAssistenzID");

                entity.Property(e => e.Austrittsdatum).HasColumnType("datetime");

                entity.Property(e => e.Bemerkungen)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Einsatzplatz)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaAssistenzTs)
                    .IsRequired()
                    .HasColumnName("KaAssistenzTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stufe)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaAssistenz)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaAssistenz_FaLeistung");
            });

            modelBuilder.Entity<KaAusbildung>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaAusbildungId).HasColumnName("KaAusbildungID");

                entity.Property(e => e.Andere).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaAusbildungTs)
                    .IsRequired()
                    .HasColumnName("KaAusbildungTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaAusbildung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaAusbildung_FaLeistung");
            });

            modelBuilder.Entity<KaBetrieb>(entity =>
            {
                entity.HasIndex(e => e.BetriebName);

                entity.Property(e => e.KaBetriebId).HasColumnName("KaBetriebID");

                entity.Property(e => e.Aktiv).HasDefaultValueSql("((1))");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.BetriebName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DmgAdresseIdObsolete).HasColumnName("DmgAdresseID_OBSOLETE");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Homepage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KaBetriebTs)
                    .IsRequired()
                    .HasColumnName("KaBetriebTS")
                    .IsRowVersion();

                entity.Property(e => e.KontaktPersonObsolete)
                    .HasColumnName("KontaktPerson_OBSOLETE")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MigrationKa)
                    .HasColumnName("MigrationKA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrganisationTypCodeObsolete).HasColumnName("OrganisationTypCode_OBSOLETE");

                entity.Property(e => e.TeilbetriebId).HasColumnName("TeilbetriebID");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KaBetriebBesprechung>(entity =>
            {
                entity.HasIndex(e => e.KaBetriebId);

                entity.Property(e => e.KaBetriebBesprechungId).HasColumnName("KaBetriebBesprechungID");

                entity.Property(e => e.AutorId).HasColumnName("AutorID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Inhalt).IsUnicode(false);

                entity.Property(e => e.KaBetriebBesprechungTs)
                    .IsRequired()
                    .HasColumnName("KaBetriebBesprechungTS")
                    .IsRowVersion();

                entity.Property(e => e.KaBetriebId).HasColumnName("KaBetriebID");

                entity.Property(e => e.KontaktGeplant).HasColumnType("datetime");

                entity.Property(e => e.KontaktPersonId).HasColumnName("KontaktPersonID");

                entity.Property(e => e.Stichwort)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.KaBetriebBesprechung)
                    .HasForeignKey(d => d.AutorId)
                    .HasConstraintName("FK_KaBetriebBesprechung_XUser");

                entity.HasOne(d => d.KaBetrieb)
                    .WithMany(p => p.KaBetriebBesprechung)
                    .HasForeignKey(d => d.KaBetriebId)
                    .HasConstraintName("FK_KaBetriebBesprechung_KaBetrieb");
            });

            modelBuilder.Entity<KaBetriebDokument>(entity =>
            {
                entity.HasIndex(e => e.KaBetriebId);

                entity.Property(e => e.KaBetriebDokumentId).HasColumnName("KaBetriebDokumentID");

                entity.Property(e => e.AbsenderId).HasColumnName("AbsenderID");

                entity.Property(e => e.AdressatId).HasColumnName("AdressatID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.DokumentDocId).HasColumnName("DokumentDocID");

                entity.Property(e => e.KaBetriebDokumentTs)
                    .IsRequired()
                    .HasColumnName("KaBetriebDokumentTS")
                    .IsRowVersion();

                entity.Property(e => e.KaBetriebId).HasColumnName("KaBetriebID");

                entity.Property(e => e.Stichwort)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.KaBetrieb)
                    .WithMany(p => p.KaBetriebDokument)
                    .HasForeignKey(d => d.KaBetriebId)
                    .HasConstraintName("FK_KaBetriebDokument_KaBetrieb");
            });

            modelBuilder.Entity<KaBetriebKontakt>(entity =>
            {
                entity.HasIndex(e => e.KaBetriebId);

                entity.Property(e => e.KaBetriebKontaktId).HasColumnName("KaBetriebKontaktID");

                entity.Property(e => e.Aktiv).HasDefaultValueSql("(1)");

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(7000)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Funktion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KaBetriebId).HasColumnName("KaBetriebID");

                entity.Property(e => e.KaBetriebKontaktTs)
                    .IsRequired()
                    .HasColumnName("KaBetriebKontaktTS")
                    .IsRowVersion();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonMobil)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vorname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.KaBetrieb)
                    .WithMany(p => p.KaBetriebKontakt)
                    .HasForeignKey(d => d.KaBetriebId)
                    .HasConstraintName("FK_KaBetriebKontakt_KaBetrieb");
            });

            modelBuilder.Entity<KaEafSozioberuflicheBilanz>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaEafSozioberuflicheBilanzId).HasColumnName("KaEafSozioberuflicheBilanzID");

                entity.Property(e => e.AnwesendTeilzeit)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AufnahmeErgebnisseAssessment).IsUnicode(false);

                entity.Property(e => e.AufnahmeErgebnisseBewerbung).IsUnicode(false);

                entity.Property(e => e.AufnahmeErgebnisseInterview).IsUnicode(false);

                entity.Property(e => e.AufnahmeErgebnisseWerkstatt).IsUnicode(false);

                entity.Property(e => e.AufnahmeZielsetzungenRav)
                    .HasColumnName("AufnahmeZielsetzungenRAV")
                    .IsUnicode(false);

                entity.Property(e => e.AustrittDatum).HasColumnType("datetime");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentIdInterventionenProgrammabbruch).HasColumnName("DocumentID_InterventionenProgrammabbruch");

                entity.Property(e => e.DocumentIdInterventionenVereinbarung).HasColumnName("DocumentID_InterventionenVereinbarung");

                entity.Property(e => e.DocumentIdInterventionenVerwarnung1).HasColumnName("DocumentID_InterventionenVerwarnung1");

                entity.Property(e => e.DocumentIdInterventionenVerwarnung2).HasColumnName("DocumentID_InterventionenVerwarnung2");

                entity.Property(e => e.DocumentIdProzessBewerbungskompetenz).HasColumnName("DocumentID_ProzessBewerbungskompetenz");

                entity.Property(e => e.DocumentIdProzessErmittlungsprogramm).HasColumnName("DocumentID_ProzessErmittlungsprogramm");

                entity.Property(e => e.DocumentIdProzessFaehigkeitsAnalyse).HasColumnName("DocumentID_ProzessFaehigkeitsAnalyse");

                entity.Property(e => e.DocumentIdProzessFaehigkeitsprofilMelba).HasColumnName("DocumentID_ProzessFaehigkeitsprofilMelba");

                entity.Property(e => e.DocumentIdProzessSchlussbericht).HasColumnName("DocumentID_ProzessSchlussbericht");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.InterventionenAufforderung).IsUnicode(false);

                entity.Property(e => e.InterventionenDatumAufforderung).HasColumnType("datetime");

                entity.Property(e => e.KaEafSozioberuflicheBilanzTs)
                    .IsRequired()
                    .HasColumnName("KaEafSozioberuflicheBilanzTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProzessBemerkungenAbschluss).IsUnicode(false);

                entity.Property(e => e.ProzessDatumVerzahnungsgespraech1).HasColumnType("datetime");

                entity.Property(e => e.ProzessDatumVerzahnungsgespraech2).HasColumnType("datetime");

                entity.Property(e => e.ProzessDatumVerzahnungsgespraech3).HasColumnType("datetime");

                entity.Property(e => e.ProzessDatumZwischengespraech).HasColumnType("datetime");

                entity.Property(e => e.Schwerpunkte).IsUnicode(false);

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaEafSozioberuflicheBilanz)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaEafSozioberuflicheBilanz_FaLeistung");
            });

            modelBuilder.Entity<KaEafSpezifischeErmittlung>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaEafSpezifischeErmittlungId).HasColumnName("KaEafSpezifischeErmittlungID");

                entity.Property(e => e.AnwesendTeilzeit)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AustrittDatum).HasColumnType("datetime");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentIdInterventionenAufforderung1).HasColumnName("DocumentID_InterventionenAufforderung1");

                entity.Property(e => e.DocumentIdInterventionenAufforderung2).HasColumnName("DocumentID_InterventionenAufforderung2");

                entity.Property(e => e.DocumentIdInterventionenAufforderung3).HasColumnName("DocumentID_InterventionenAufforderung3");

                entity.Property(e => e.DocumentIdInterventionenProgrammabbruch).HasColumnName("DocumentID_InterventionenProgrammabbruch");

                entity.Property(e => e.DocumentIdInterventionenVereinbarung1).HasColumnName("DocumentID_InterventionenVereinbarung1");

                entity.Property(e => e.DocumentIdInterventionenVereinbarung2).HasColumnName("DocumentID_InterventionenVereinbarung2");

                entity.Property(e => e.DocumentIdInterventionenVerwarnung1).HasColumnName("DocumentID_InterventionenVerwarnung1");

                entity.Property(e => e.DocumentIdInterventionenVerwarnung2).HasColumnName("DocumentID_InterventionenVerwarnung2");

                entity.Property(e => e.DocumentIdProzessSchlussbericht).HasColumnName("DocumentID_ProzessSchlussbericht");

                entity.Property(e => e.DocumentIdProzessVereinbarung).HasColumnName("DocumentID_ProzessVereinbarung");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.InterventionenAufforderung1).IsUnicode(false);

                entity.Property(e => e.InterventionenAufforderung2).IsUnicode(false);

                entity.Property(e => e.InterventionenDatumAufforderung1).HasColumnType("datetime");

                entity.Property(e => e.InterventionenDatumAufforderung2).HasColumnType("datetime");

                entity.Property(e => e.KaEafSpezifischeErmittlungTs)
                    .IsRequired()
                    .HasColumnName("KaEafSpezifischeErmittlungTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProzessBemerkungenAbschluss).IsUnicode(false);

                entity.Property(e => e.ProzessDatumAustauschgespraech1).HasColumnType("datetime");

                entity.Property(e => e.ProzessDatumAustauschgespraech2).HasColumnType("datetime");

                entity.Property(e => e.ProzessDatumAustauschgespraech3).HasColumnType("datetime");

                entity.Property(e => e.ProzessDatumVereinbarung).HasColumnType("datetime");

                entity.Property(e => e.Zielsetzungen).IsUnicode(false);

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaEafSpezifischeErmittlung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaEafSpezifischeErmittlung_FaLeistung");
            });

            modelBuilder.Entity<KaEinsatz>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.KaEinsatzplatzId);

                entity.Property(e => e.KaEinsatzId).HasColumnName("KaEinsatzID");

                entity.Property(e => e.AlkasseId).HasColumnName("ALKasseID");

                entity.Property(e => e.ApvzusatzCode).HasColumnName("APVZusatzCode");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaEinsatzTs)
                    .IsRequired()
                    .HasColumnName("KaEinsatzTS")
                    .IsRowVersion();

                entity.Property(e => e.KaEinsatzplatzId).HasColumnName("KaEinsatzplatzID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RahmenfristBis).HasColumnType("datetime");

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.Property(e => e.ZuweiserId).HasColumnName("ZuweiserID");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.KaEinsatz)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaEinsatz_BaPerson");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaEinsatz)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_KaEinsatz_FaLeistung");

                entity.HasOne(d => d.KaEinsatzplatz)
                    .WithMany(p => p.KaEinsatz)
                    .HasForeignKey(d => d.KaEinsatzplatzId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaEinsatz_KaEinsatzplatz2");
            });

            modelBuilder.Entity<KaEinsatzplatz>(entity =>
            {
                entity.HasIndex(e => e.KaBetriebId);

                entity.HasIndex(e => e.KaKontaktpersonId);

                entity.Property(e => e.KaEinsatzplatzId).HasColumnName("KaEinsatzplatzID");

                entity.Property(e => e.Aktiv).HasDefaultValueSql("(1)");

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DauerUnbefristet).HasDefaultValueSql("(0)");

                entity.Property(e => e.Details)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.EinsatzAb).HasColumnType("datetime");

                entity.Property(e => e.ErfassungsDatum).HasColumnType("datetime");

                entity.Property(e => e.Fuehrerausweis).HasDefaultValueSql("(0)");

                entity.Property(e => e.KaBetriebId).HasColumnName("KaBetriebID");

                entity.Property(e => e.KaEinsatzplatzTs)
                    .IsRequired()
                    .HasColumnName("KaEinsatzplatzTS")
                    .IsRowVersion();

                entity.Property(e => e.KaKontaktpersonId).HasColumnName("KaKontaktpersonID");

                entity.Property(e => e.MigrationKa)
                    .HasColumnName("MigrationKA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NeuGeschaffeneLehrstelle).HasDefaultValueSql("(0)");

                entity.Property(e => e.Pckenntnisse)
                    .HasColumnName("PCKenntnisse")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PensumAufteilbar).HasDefaultValueSql("(0)");

                entity.Property(e => e.PensumUnbestimmt).HasDefaultValueSql("(0)");

                entity.Property(e => e.WeitereAnforderungen)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.ZustaendigKa).HasColumnName("ZustaendigKA");

                entity.HasOne(d => d.KaBetrieb)
                    .WithMany(p => p.KaEinsatzplatz)
                    .HasForeignKey(d => d.KaBetriebId)
                    .HasConstraintName("FK_KaEinsatzplatz_KaBetrieb");

                entity.HasOne(d => d.KaKontaktperson)
                    .WithMany(p => p.KaEinsatzplatz)
                    .HasForeignKey(d => d.KaKontaktpersonId)
                    .HasConstraintName("FK_KaEinsatzplatz_KaBetriebKontakt");
            });

            modelBuilder.Entity<KaEinsatzplatz2>(entity =>
            {
                entity.HasKey(e => e.KaEinsatzplatzId);

                entity.HasIndex(e => e.Name);

                entity.Property(e => e.KaEinsatzplatzId).HasColumnName("KaEinsatzplatzID");

                entity.Property(e => e.Apvcode).HasColumnName("APVCode");

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.KaEinsatzplatz2Ts)
                    .IsRequired()
                    .HasColumnName("KaEinsatzplatz2TS")
                    .IsRowVersion();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KaExterneBildung>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaExterneBildungId).HasColumnName("KaExterneBildungID");

                entity.Property(e => e.AnteilDritte).HasColumnType("money");

                entity.Property(e => e.AnteilKa)
                    .HasColumnName("AnteilKA")
                    .HasColumnType("money");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaExterneBildungTs)
                    .IsRequired()
                    .HasColumnName("KaExterneBildungTS")
                    .IsRowVersion();

                entity.Property(e => e.Kursort)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.KaExterneBildung)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaExterneBildung_BaPerson");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaExterneBildung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_KaExterneBildung_FaLeistung");
            });

            modelBuilder.Entity<KaExterneBildungZahlung>(entity =>
            {
                entity.HasIndex(e => e.KaExterneBildungId);

                entity.Property(e => e.KaExterneBildungZahlungId).HasColumnName("KaExterneBildungZahlungID");

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.KaExterneBildungId).HasColumnName("KaExterneBildungID");

                entity.Property(e => e.KaExterneBildungZahlungTs)
                    .IsRequired()
                    .HasColumnName("KaExterneBildungZahlungTS")
                    .IsRowVersion();

                entity.Property(e => e.Zweck)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.KaExterneBildung)
                    .WithMany(p => p.KaExterneBildungZahlung)
                    .HasForeignKey(d => d.KaExterneBildungId)
                    .HasConstraintName("FK_KaExterneBildungZahlung_KaExterneBildung");
            });

            modelBuilder.Entity<KaInizio>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaInizioId).HasColumnName("KaInizioID");

                entity.Property(e => e.AnmeldungEingegangen).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaInizioTs)
                    .IsRequired()
                    .HasColumnName("KaInizioTS")
                    .IsRowVersion();

                entity.Property(e => e.MappeVerschickt).HasColumnType("datetime");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaInizio)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_KaInizio_FaLeistung");
            });

            modelBuilder.Entity<KaIntegBildung>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.KaKurserfassungId);

                entity.Property(e => e.KaIntegBildungId).HasColumnName("KaIntegBildungID");

                entity.Property(e => e.AbschlussDokId).HasColumnName("AbschlussDokID");

                entity.Property(e => e.Austritt).HasColumnType("datetime");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Eintritt).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaIntegBildungTs)
                    .IsRequired()
                    .HasColumnName("KaIntegBildungTS")
                    .IsRowVersion();

                entity.Property(e => e.KaKurserfassungId).HasColumnName("KaKurserfassungID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RueckmeldungDokId).HasColumnName("RueckmeldungDokID");

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.KaIntegBildung)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaIntegBildung_BaPerson");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaIntegBildung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_KaIntegBildung_FaLeistung");

                entity.HasOne(d => d.KaKurserfassung)
                    .WithMany(p => p.KaIntegBildung)
                    .HasForeignKey(d => d.KaKurserfassungId)
                    .HasConstraintName("FK_KaIntegBildung_KaKurserfassung");
            });

            modelBuilder.Entity<KaJobtimal>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaJobtimalId).HasColumnName("KaJobtimalID");

                entity.Property(e => e.AbschlussDatum).HasColumnType("datetime");

                entity.Property(e => e.Bemerkungen)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentIdFaehigkeitsprofil).HasColumnName("DocumentID_Faehigkeitsprofil");

                entity.Property(e => e.DocumentIdRahmenvertrag).HasColumnName("DocumentID_Rahmenvertrag");

                entity.Property(e => e.DocumentIdSchlussbericht).HasColumnName("DocumentID_Schlussbericht");

                entity.Property(e => e.DossierRetourAnSdgrundCode).HasColumnName("DossierRetourAnSDGrundCode");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaJobtimalTs)
                    .IsRequired()
                    .HasColumnName("KaJobtimalTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.Property(e => e.SozialhilfebezugAb).HasColumnType("datetime");

                entity.Property(e => e.ZuweiserId).HasColumnName("ZuweiserID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaJobtimal)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_KaJobtimal_FaLeistung");
            });

            modelBuilder.Entity<KaJobtimalVertrag>(entity =>
            {
                entity.HasIndex(e => e.KaVermittlungVorschlagId);

                entity.Property(e => e.KaJobtimalVertragId).HasColumnName("KaJobtimalVertragID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.KaJobtimalVertragTs)
                    .IsRequired()
                    .HasColumnName("KaJobtimalVertragTS")
                    .IsRowVersion();

                entity.Property(e => e.KaVermittlungVorschlagId).HasColumnName("KaVermittlungVorschlagID");

                entity.HasOne(d => d.KaVermittlungVorschlag)
                    .WithMany(p => p.KaJobtimalVertrag)
                    .HasForeignKey(d => d.KaVermittlungVorschlagId)
                    .HasConstraintName("FK_KaJobtimalVertrag_KaVermittlungVorschlag");
            });

            modelBuilder.Entity<KaKontaktartProzess>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaKontaktartProzessId).HasColumnName("KaKontaktartProzessID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaKontaktartProzessTs)
                    .IsRequired()
                    .HasColumnName("KaKontaktartProzessTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaKontaktartProzess)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaKontaktartProzess_FaLeistung");
            });

            modelBuilder.Entity<KaKurs>(entity =>
            {
                entity.HasIndex(e => e.Name);

                entity.Property(e => e.KaKursId).HasColumnName("KaKursID");

                entity.Property(e => e.ClosedFlag).HasDefaultValueSql("(0)");

                entity.Property(e => e.KaKursTs)
                    .IsRequired()
                    .HasColumnName("KaKursTS")
                    .IsRowVersion();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KaKurserfassung>(entity =>
            {
                entity.HasIndex(e => e.KursId);

                entity.Property(e => e.KaKurserfassungId).HasColumnName("KaKurserfassungID");

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.KaKurserfassungTs)
                    .IsRequired()
                    .HasColumnName("KaKurserfassungTS")
                    .IsRowVersion();

                entity.Property(e => e.KursId).HasColumnName("KursID");

                entity.Property(e => e.KursNr)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SistiertFlag).HasDefaultValueSql("(0)");

                entity.HasOne(d => d.Kurs)
                    .WithMany(p => p.KaKurserfassung)
                    .HasForeignKey(d => d.KursId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaKurserfassung_KaKurs");
            });

            modelBuilder.Entity<KaQeepq>(entity =>
            {
                entity.ToTable("KaQEEPQ");

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaQeepqid).HasColumnName("KaQEEPQID");

                entity.Property(e => e.ArbeitszeugnisDokId).HasColumnName("ArbeitszeugnisDokID");

                entity.Property(e => e.Aufforderung1DokId).HasColumnName("Aufforderung1DokID");

                entity.Property(e => e.Aufforderung2DokId).HasColumnName("Aufforderung2DokID");

                entity.Property(e => e.Aufforderung3DokId).HasColumnName("Aufforderung3DokID");

                entity.Property(e => e.AustrittBemerkung).IsUnicode(false);

                entity.Property(e => e.AustrittDatum).HasColumnType("datetime");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Einladung1DokId).HasColumnName("Einladung1DokID");

                entity.Property(e => e.Einladung2DokId).HasColumnName("Einladung2DokID");

                entity.Property(e => e.EinladungDat1).HasColumnType("datetime");

                entity.Property(e => e.EinladungDat2).HasColumnType("datetime");

                entity.Property(e => e.EinladungProgBeginn1DokId).HasColumnName("EinladungProgBeginn1DokID");

                entity.Property(e => e.EinladungProgBeginn2DokId).HasColumnName("EinladungProgBeginn2DokID");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.IndivZieleRav)
                    .HasColumnName("IndivZieleRAV")
                    .IsUnicode(false);

                entity.Property(e => e.IndivZieleRavdokId).HasColumnName("IndivZieleRAVDokID");

                entity.Property(e => e.IndivZieleRavverl)
                    .HasColumnName("IndivZieleRAVVerl")
                    .IsUnicode(false);

                entity.Property(e => e.IndivZieleRavverlDokId).HasColumnName("IndivZieleRAVVerlDokID");

                entity.Property(e => e.IntakeCodes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.KaQeepqts)
                    .IsRequired()
                    .HasColumnName("KaQEEPQTS")
                    .IsRowVersion();

                entity.Property(e => e.MuendAuffordBem1)
                    .HasColumnName("muendAuffordBem1")
                    .IsUnicode(false);

                entity.Property(e => e.MuendAuffordBem2)
                    .HasColumnName("muendAuffordBem2")
                    .IsUnicode(false);

                entity.Property(e => e.MuendAuffordDat1)
                    .HasColumnName("muendAuffordDat1")
                    .HasColumnType("datetime");

                entity.Property(e => e.MuendAuffordDat2)
                    .HasColumnName("muendAuffordDat2")
                    .HasColumnType("datetime");

                entity.Property(e => e.PersonalblattDokId).HasColumnName("PersonalblattDokID");

                entity.Property(e => e.ProgAbbruchDokId).HasColumnName("ProgAbbruchDokID");

                entity.Property(e => e.RueckanwortDokId).HasColumnName("RueckanwortDokID");

                entity.Property(e => e.Schlussbericht1DokId).HasColumnName("Schlussbericht1DokID");

                entity.Property(e => e.Schlussbericht2DokId).HasColumnName("Schlussbericht2DokID");

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.Property(e => e.StaoDat).HasColumnType("datetime");

                entity.Property(e => e.TaetigProgrammDokId).HasColumnName("TaetigProgrammDokID");

                entity.Property(e => e.Vereinbarung1DokId).HasColumnName("Vereinbarung1DokID");

                entity.Property(e => e.Vereinbarung2DokId).HasColumnName("Vereinbarung2DokID");

                entity.Property(e => e.VerlaengerungDat).HasColumnType("datetime");

                entity.Property(e => e.VerlaengerungDokId).HasColumnName("VerlaengerungDokID");

                entity.Property(e => e.VerwNichterscheinenDokId).HasColumnName("VerwNichterscheinenDokID");

                entity.Property(e => e.VerwRegelverstossDokId).HasColumnName("VerwRegelverstossDokID");

                entity.Property(e => e.XdocumentIdStandortbestimmung1).HasColumnName("XDocumentID_Standortbestimmung1");

                entity.Property(e => e.XdocumentIdStandortbestimmung2).HasColumnName("XDocumentID_Standortbestimmung2");

                entity.Property(e => e.XdocumentIdVorstellungsgespraech).HasColumnName("XDocumentID_Vorstellungsgespraech");

                entity.Property(e => e.ZwBericht1DokId).HasColumnName("ZwBericht1DokID");

                entity.Property(e => e.ZwBericht2DokId).HasColumnName("ZwBericht2DokID");

                entity.Property(e => e.ZwischenzeugnisDokId).HasColumnName("ZwischenzeugnisDokID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaQeepq)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaQEEPQ_FaLeistung");
            });

            modelBuilder.Entity<KaQeepqzielvereinb>(entity =>
            {
                entity.ToTable("KaQEEPQZielvereinb");

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaQeepqzielvereinbId).HasColumnName("KaQEEPQZielvereinbID");

                entity.Property(e => e.Ergebnis).IsUnicode(false);

                entity.Property(e => e.ErreichenBis)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Feinziel).IsUnicode(false);

                entity.Property(e => e.FeinzielDat).HasColumnType("datetime");

                entity.Property(e => e.KaQeepqzielvereinbTs)
                    .IsRequired()
                    .HasColumnName("KaQEEPQZielvereinbTS")
                    .IsRowVersion();

                entity.Property(e => e.MessungZielerreichung).IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaQeepqzielvereinb)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaQEEPQZielvereinb_FaLeistung");
            });

            modelBuilder.Entity<KaQeepqzielvereinbVerl>(entity =>
            {
                entity.ToTable("KaQEEPQZielvereinbVerl");

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaQeepqzielvereinbVerlId).HasColumnName("KaQEEPQZielvereinbVerlID");

                entity.Property(e => e.Ergebnis).IsUnicode(false);

                entity.Property(e => e.ErreichenBis)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Feinziel).IsUnicode(false);

                entity.Property(e => e.FeinzielDat).HasColumnType("datetime");

                entity.Property(e => e.KaQeepqzielvereinbVerlTs)
                    .IsRequired()
                    .HasColumnName("KaQEEPQZielvereinbVerlTS")
                    .IsRowVersion();

                entity.Property(e => e.MessungZielerreichung).IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaQeepqzielvereinbVerl)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaQEEPQZielvereinbVerl_FaLeistung");
            });

            modelBuilder.Entity<KaQejobtimum>(entity =>
            {
                entity.ToTable("KaQEJobtimum");

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaQejobtimumId).HasColumnName("KaQEJobtimumID");

                entity.Property(e => e.AustrittBemerkung).IsUnicode(false);

                entity.Property(e => e.AustrittDatum).HasColumnType("datetime");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Einladung1DokId).HasColumnName("Einladung1DokID");

                entity.Property(e => e.Einladung2DokId).HasColumnName("Einladung2DokID");

                entity.Property(e => e.EinladungDat1).HasColumnType("datetime");

                entity.Property(e => e.EinladungDat2).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaQejobtimumTs)
                    .IsRequired()
                    .HasColumnName("KaQEJobtimumTS")
                    .IsRowVersion();

                entity.Property(e => e.MuendAuffordBem1)
                    .HasColumnName("muendAuffordBem1")
                    .IsUnicode(false);

                entity.Property(e => e.MuendAuffordBem2)
                    .HasColumnName("muendAuffordBem2")
                    .IsUnicode(false);

                entity.Property(e => e.MuendAuffordDat1)
                    .HasColumnName("muendAuffordDat1")
                    .HasColumnType("datetime");

                entity.Property(e => e.MuendAuffordDat2)
                    .HasColumnName("muendAuffordDat2")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProgAbbruch2DokId).HasColumnName("ProgAbbruch2DokID");

                entity.Property(e => e.ProgAbbruchDokId).HasColumnName("ProgAbbruchDokID");

                entity.Property(e => e.ProgBeginnCodeOld).HasColumnName("ProgBeginnCodeOLD");

                entity.Property(e => e.ProgBeginnOld).HasColumnName("ProgBeginnOLD");

                entity.Property(e => e.Schlussbericht1DokId).HasColumnName("Schlussbericht1DokID");

                entity.Property(e => e.SchlussberichtDokId).HasColumnName("SchlussberichtDokID");

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.Property(e => e.TeilnahmebestDokId).HasColumnName("TeilnahmebestDokID");

                entity.Property(e => e.TerminDat).HasColumnType("datetime");

                entity.Property(e => e.Verwarnung1DokId).HasColumnName("Verwarnung1DokID");

                entity.Property(e => e.Verwarnung1aDokId).HasColumnName("Verwarnung1aDokID");

                entity.Property(e => e.Verwarnung2DokId).HasColumnName("Verwarnung2DokID");

                entity.Property(e => e.Verwarnung2aDokId).HasColumnName("Verwarnung2aDokID");

                entity.Property(e => e.Ziel1DokId).HasColumnName("Ziel1DokID");

                entity.Property(e => e.Ziel2DokId).HasColumnName("Ziel2DokID");

                entity.Property(e => e.Ziel3DokId).HasColumnName("Ziel3DokID");

                entity.Property(e => e.Ziel4DokId).HasColumnName("Ziel4DokID");

                entity.Property(e => e.ZielDat1).HasColumnType("datetime");

                entity.Property(e => e.ZielDat2).HasColumnType("datetime");

                entity.Property(e => e.ZielDat3).HasColumnType("datetime");

                entity.Property(e => e.ZielDat4).HasColumnType("datetime");

                entity.Property(e => e.Zusatzinfos).IsUnicode(false);

                entity.Property(e => e.ZwischenberichtDokId).HasColumnName("ZwischenberichtDokID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaQejobtimum)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaQEJobtimum_FaLeistung");
            });

            modelBuilder.Entity<KaQjbildung>(entity =>
            {
                entity.ToTable("KaQJBildung");

                entity.Property(e => e.KaQjbildungId).HasColumnName("KaQJBildungID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaQjbildungTs)
                    .IsRequired()
                    .HasColumnName("KaQJBildungTS")
                    .IsRowVersion();

                entity.Property(e => e.KursCustom1Text)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.KursCustom2Text)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.KursCustom3Text)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.KursCustom4Text)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.KursCustom5Text)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.KursCustom6Text)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaQjbildung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_KaQJBildung_FaLeistung");
            });

            modelBuilder.Entity<KaQjintake>(entity =>
            {
                entity.ToTable("KaQJIntake");

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaQjintakeId).HasColumnName("KaQJIntakeID");

                entity.Property(e => e.AbgemeldetAlvflag).HasColumnName("AbgemeldetALVFlag");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentIdIntakegespraech).HasColumnName("DocumentID_Intakegespraech");

                entity.Property(e => e.Eintritt)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaQjIntakeSpracheCodeErstsprache).HasColumnName("KaQjIntakeSpracheCode_Erstsprache");

                entity.Property(e => e.KaQjIntakeSpracheCodeHauptsprache).HasColumnName("KaQjIntakeSpracheCode_Hauptsprache");

                entity.Property(e => e.KaQjintakeTs)
                    .IsRequired()
                    .HasColumnName("KaQJIntakeTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.Property(e => e.ZuweiserId).HasColumnName("ZuweiserID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaQjintake)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaQJIntake_FaLeistung");
            });

            modelBuilder.Entity<KaQjintakeGespraech>(entity =>
            {
                entity.ToTable("KaQJIntakeGespraech");

                entity.HasIndex(e => e.KaQjintakeId);

                entity.Property(e => e.KaQjintakeGespraechId).HasColumnName("KaQJIntakeGespraechID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.KaQjintakeGespraechTs)
                    .IsRequired()
                    .HasColumnName("KaQJIntakeGespraechTS")
                    .IsRowVersion();

                entity.Property(e => e.KaQjintakeId).HasColumnName("KaQJIntakeID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.KaQjintake)
                    .WithMany(p => p.KaQjintakeGespraech)
                    .HasForeignKey(d => d.KaQjintakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaQJIntakeGespraech_KaQJIntake");
            });

            modelBuilder.Entity<KaQjprozess>(entity =>
            {
                entity.ToTable("KaQJProzess");

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaQjprozessId).HasColumnName("KaQJProzessID");

                entity.Property(e => e.AndereStellen).IsUnicode(false);

                entity.Property(e => e.BeilageSemodokId).HasColumnName("BeilageSEMODokID");

                entity.Property(e => e.BeraterId).HasColumnName("BeraterID");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FallfuehrungId).HasColumnName("FallfuehrungID");

                entity.Property(e => e.KaQjprozessTs)
                    .IsRequired()
                    .HasColumnName("KaQJProzessTS")
                    .IsRowVersion();

                entity.Property(e => e.KompetenzDokId).HasColumnName("KompetenzDokID");

                entity.Property(e => e.LebenslaufDokId).HasColumnName("LebenslaufDokID");

                entity.Property(e => e.ProgEnde).HasColumnType("datetime");

                entity.Property(e => e.ProgrammBildungDokId).HasColumnName("ProgrammBildungDokID");

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.Property(e => e.StandortbestDokId).HasColumnName("StandortbestDokID");

                entity.Property(e => e.TermineStaoDokId).HasColumnName("TermineStaoDokID");

                entity.Property(e => e.ZwischenzeugnisDokId).HasColumnName("ZwischenzeugnisDokID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaQjprozess)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaQJProzess_FaLeistung");
            });

            modelBuilder.Entity<KaQjpzassessment>(entity =>
            {
                entity.ToTable("KaQJPZAssessment");

                entity.Property(e => e.KaQjpzassessmentId).HasColumnName("KaQJPZAssessmentID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumAssessment).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaQjpzassessmentTs)
                    .IsRequired()
                    .HasColumnName("KaQJPZAssessmentTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NichtAufgGrund).IsUnicode(false);

                entity.Property(e => e.ProjGefaehrGrund).IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaQjpzassessment)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_KaQJPZAssessment_FaLeistung");
            });

            modelBuilder.Entity<KaQjpzbericht>(entity =>
            {
                entity.ToTable("KaQJPZBericht");

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaQjpzberichtId).HasColumnName("KaQJPZBerichtID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaQjpzberichtTs)
                    .IsRequired()
                    .HasColumnName("KaQJPZBerichtTS")
                    .IsRowVersion();

                entity.Property(e => e.KaQjpzberichtTypCode).HasColumnName("KaQJPZBerichtTypCode");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaQjpzbericht)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaQJPZBericht_FaLeistung");
            });

            modelBuilder.Entity<KaQjpzschlussbericht>(entity =>
            {
                entity.ToTable("KaQJPZSchlussbericht");

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaQjpzschlussberichtId).HasColumnName("KaQJPZSchlussberichtID");

                entity.Property(e => e.AorganisationCode).HasColumnName("AOrganisationCode");

                entity.Property(e => e.AqualitaetCode).HasColumnName("AQualitaetCode");

                entity.Property(e => e.AtempoCode).HasColumnName("ATempoCode");

                entity.Property(e => e.BemAbsenzen).IsUnicode(false);

                entity.Property(e => e.BemBildung).IsUnicode(false);

                entity.Property(e => e.BemEmpfehlung).IsUnicode(false);

                entity.Property(e => e.BemKompetenz).IsUnicode(false);

                entity.Property(e => e.BemZielvereinbarung).IsUnicode(false);

                entity.Property(e => e.BeurteilungDat).HasColumnType("datetime");

                entity.Property(e => e.EingVermittelbar).IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaQjpzschlussberichtTs)
                    .IsRequired()
                    .HasColumnName("KaQJPZSchlussberichtTS")
                    .IsRowVersion();

                entity.Property(e => e.SchlussberichtDokId).HasColumnName("SchlussberichtDokID");

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaQjpzschlussbericht)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaQJPZSchlussbericht_FaLeistung");
            });

            modelBuilder.Entity<KaQjpzzielvereinbarung>(entity =>
            {
                entity.ToTable("KaQJPZZielvereinbarung");

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaQjpzzielvereinbarungId).HasColumnName("KaQJPZZielvereinbarungID");

                entity.Property(e => e.BeurteilungId).HasColumnName("BeurteilungID");

                entity.Property(e => e.DatumBeurteilung).HasColumnType("datetime");

                entity.Property(e => e.ErreichenBis).IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaQjpzzielvereinbarungTs)
                    .IsRequired()
                    .HasColumnName("KaQJPZZielvereinbarungTS")
                    .IsRowVersion();

                entity.Property(e => e.KriterienPruefen).IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.Property(e => e.VereinbartesZiel).IsUnicode(false);

                entity.Property(e => e.ZielDatum).HasColumnType("datetime");

                entity.Property(e => e.ZielvereinbarungDokId).HasColumnName("ZielvereinbarungDokID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaQjpzzielvereinbarung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaQJPZZielvereinbarung_FaLeistung");
            });

            modelBuilder.Entity<KaQjvereinbarung>(entity =>
            {
                entity.ToTable("KaQJVereinbarung");

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaQjvereinbarungId).HasColumnName("KaQJVereinbarungID");

                entity.Property(e => e.Abmachungen).IsUnicode(false);

                entity.Property(e => e.ErstelltAm).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.GrundZiel).IsUnicode(false);

                entity.Property(e => e.KaQjvereinbarungTs)
                    .IsRequired()
                    .HasColumnName("KaQJVereinbarungTS")
                    .IsRowVersion();

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.Property(e => e.VereinbarungDokId).HasColumnName("VereinbarungDokID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaQjvereinbarung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaQJVereinbarung_FaLeistung");
            });

            modelBuilder.Entity<KaSequenzen>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.Property(e => e.KaSequenzenId).HasColumnName("KaSequenzenID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.KaSequenzenTs)
                    .IsRequired()
                    .HasColumnName("KaSequenzenTS")
                    .IsRowVersion();

                entity.Property(e => e.SichtbarSdflag)
                    .HasColumnName("SichtbarSDFlag")
                    .HasDefaultValueSql("(0)");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.KaSequenzen)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaSequenzen_BaPerson");
            });

            modelBuilder.Entity<KaTransfer>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaTransferId).HasColumnName("KaTransferID");

                entity.Property(e => e.AllgZiele).IsUnicode(false);

                entity.Property(e => e.AllgZieleDokId).HasColumnName("AllgZieleDokID");

                entity.Property(e => e.ArbeitsprobenDokId).HasColumnName("ArbeitsprobenDokID");

                entity.Property(e => e.Aufforderung1DokId).HasColumnName("Aufforderung1DokID");

                entity.Property(e => e.Aufforderung2DokId).HasColumnName("Aufforderung2DokID");

                entity.Property(e => e.Aufforderung3DokId).HasColumnName("Aufforderung3DokID");

                entity.Property(e => e.AustrittBem).IsUnicode(false);

                entity.Property(e => e.AustrittDat).HasColumnType("datetime");

                entity.Property(e => e.Bewerbungsstrategie).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumVg)
                    .HasColumnName("DatumVG")
                    .HasColumnType("datetime");

                entity.Property(e => e.EntwicklungsverlaufDokId).HasColumnName("EntwicklungsverlaufDokID");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FaehigkeitsprofilDokId).HasColumnName("FaehigkeitsprofilDokID");

                entity.Property(e => e.KaTransferTs)
                    .IsRequired()
                    .HasColumnName("KaTransferTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MuendAufforderungBem1).IsUnicode(false);

                entity.Property(e => e.MuendAufforderungBem2).IsUnicode(false);

                entity.Property(e => e.MuendAufforderungDat1).HasColumnType("datetime");

                entity.Property(e => e.MuendAufforderungDat2).HasColumnType("datetime");

                entity.Property(e => e.NichterscheinenDokId).HasColumnName("NichterscheinenDokID");

                entity.Property(e => e.PersonalblattDokId).HasColumnName("PersonalblattDokID");

                entity.Property(e => e.ProgrammabbruchDokId).HasColumnName("ProgrammabbruchDokID");

                entity.Property(e => e.RegelverstossDokId).HasColumnName("RegelverstossDokID");

                entity.Property(e => e.RueckmeldungRavdokId).HasColumnName("RueckmeldungRAVDokID");

                entity.Property(e => e.SchlussberichtDokId).HasColumnName("SchlussberichtDokID");

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.Property(e => e.SituationserfassungVgdokId).HasColumnName("SituationserfassungVGDokID");

                entity.Property(e => e.TeilnahmebestaetigungDokId).HasColumnName("TeilnahmebestaetigungDokID");

                entity.Property(e => e.TelErstkontaktDat).HasColumnType("datetime");

                entity.Property(e => e.Vereinbarung1DokId).HasColumnName("Vereinbarung1DokID");

                entity.Property(e => e.Vereinbarung2DokId).HasColumnName("Vereinbarung2DokID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaTransfer)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaTransfer_FaLeistung");
            });

            modelBuilder.Entity<KaTransferZielvereinb>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaTransferZielvereinbId).HasColumnName("KaTransferZielvereinbID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ergebnis).IsUnicode(false);

                entity.Property(e => e.ErreichenBis)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Feinziel).IsUnicode(false);

                entity.Property(e => e.FeinzielDat).HasColumnType("datetime");

                entity.Property(e => e.KaTransferZielvereinbTs)
                    .IsRequired()
                    .HasColumnName("KaTransferZielvereinbTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProzessAuftrag).IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaTransferZielvereinb)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaTransferZielvereinb_FaLeistung");
            });

            modelBuilder.Entity<KaVerlauf>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.KaVerlaufId).HasColumnName("KaVerlaufID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.InhaltRtf)
                    .HasColumnName("InhaltRTF")
                    .IsUnicode(false);

                entity.Property(e => e.KaAllgemThemaCodes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.KaVerlaufTs)
                    .IsRequired()
                    .HasColumnName("KaVerlaufTS")
                    .IsRowVersion();

                entity.Property(e => e.Kontaktperson)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.Property(e => e.Stichwort)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaVerlauf)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaVerlauf_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.KaVerlauf)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_KaVerlauf_XUser");
            });

            modelBuilder.Entity<KaVermittlungBibip>(entity =>
            {
                entity.ToTable("KaVermittlungBIBIP");

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaVermittlungBibipid).HasColumnName("KaVermittlungBIBIPID");

                entity.Property(e => e.AbschlussDatum).HasColumnType("datetime");

                entity.Property(e => e.Bemerkungen)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentIdSchlussbericht).HasColumnName("DocumentID_Schlussbericht");

                entity.Property(e => e.DossierAnCoach).HasColumnType("datetime");

                entity.Property(e => e.DossierRetourAnSd).HasColumnName("DossierRetourAnSD");

                entity.Property(e => e.DossierRetourAnSdgrundCode).HasColumnName("DossierRetourAnSDGrundCode");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaVermittlungBibipts)
                    .IsRequired()
                    .HasColumnName("KaVermittlungBIBIPTS")
                    .IsRowVersion();

                entity.Property(e => e.MigrationKa)
                    .HasColumnName("MigrationKA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.Property(e => e.WechselKaintern).HasColumnName("WechselKAIntern");

                entity.Property(e => e.WechselKainternGrundCode).HasColumnName("WechselKAInternGrundCode");

                entity.Property(e => e.ZuweiserId).HasColumnName("ZuweiserID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaVermittlungBibip)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_KaVermittlungBIBIP_FaLeistung");
            });

            modelBuilder.Entity<KaVermittlungEinsatz>(entity =>
            {
                entity.HasIndex(e => e.KaVermittlungVorschlagId);

                entity.Property(e => e.KaVermittlungEinsatzId).HasColumnName("KaVermittlungEinsatzID");

                entity.Property(e => e.Abschluss).HasColumnType("datetime");

                entity.Property(e => e.ArbeitspensumErgaenzungen)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BiabschlussGrundCode).HasColumnName("BIAbschlussGrundCode");

                entity.Property(e => e.BibeteilungEaz)
                    .HasColumnName("BIBeteilungEAZ")
                    .HasColumnType("money");

                entity.Property(e => e.BibipsiabschlussDurchCode).HasColumnName("BIBIPSIAbschlussDurchCode");

                entity.Property(e => e.Bibruttolohn)
                    .HasColumnName("BIBruttolohn")
                    .HasColumnType("money");

                entity.Property(e => e.Bieazbemerkung)
                    .HasColumnName("BIEAZBemerkung")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.BieazdatumBis)
                    .HasColumnName("BIEAZDatumBis")
                    .HasColumnType("datetime");

                entity.Property(e => e.BieazdatumVon)
                    .HasColumnName("BIEAZDatumVon")
                    .HasColumnType("datetime");

                entity.Property(e => e.BieazvereinbarungDokId).HasColumnName("BIEAZVereinbarungDokID");

                entity.Property(e => e.BieazvereinbarungUnterschrieben).HasColumnName("BIEAZVereinbarungUnterschrieben");

                entity.Property(e => e.Bieazverlaengert).HasColumnName("BIEAZVerlaengert");

                entity.Property(e => e.BifinanzierungsgradEaz).HasColumnName("BIFinanzierungsgradEAZ");

                entity.Property(e => e.BipabschlussGrundCode).HasColumnName("BIPAbschlussGrundCode");

                entity.Property(e => e.Bipzwischenbericht1Datum)
                    .HasColumnName("BIPZwischenbericht1Datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.Bipzwischenbericht1Erhalten).HasColumnName("BIPZwischenbericht1Erhalten");

                entity.Property(e => e.Bipzwischenbericht2Datum)
                    .HasColumnName("BIPZwischenbericht2Datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.Bipzwischenbericht2Erhalten).HasColumnName("BIPZwischenbericht2Erhalten");

                entity.Property(e => e.EinsatzBemerkungen)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EinsatzBis).HasColumnType("datetime");

                entity.Property(e => e.EinsatzEinladungDokId).HasColumnName("EinsatzEinladungDokID");

                entity.Property(e => e.EinsatzVereinbarungDokId).HasColumnName("EinsatzVereinbarungDokID");

                entity.Property(e => e.EinsatzVereinbarungErhalten).HasColumnType("datetime");

                entity.Property(e => e.EinsatzVon).HasColumnType("datetime");

                entity.Property(e => e.InizioAbschlussGrund)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InizioEinsatzAbbruch).HasColumnType("datetime");

                entity.Property(e => e.InizioLoesung)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KaVermittlungEinsatzTs)
                    .IsRequired()
                    .HasColumnName("KaVermittlungEinsatzTS")
                    .IsRowVersion();

                entity.Property(e => e.KaVermittlungVorschlagId).HasColumnName("KaVermittlungVorschlagID");

                entity.Property(e => e.Lehrvertrag).HasColumnType("datetime");

                entity.Property(e => e.MigrationKa)
                    .HasColumnName("MigrationKA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SiabschlussGrundCode).HasColumnName("SIAbschlussGrundCode");

                entity.HasOne(d => d.KaVermittlungVorschlag)
                    .WithMany(p => p.KaVermittlungEinsatz)
                    .HasForeignKey(d => d.KaVermittlungVorschlagId)
                    .HasConstraintName("FK_KaVermittlungEinsatz_KaVermittlungVorschlag");
            });

            modelBuilder.Entity<KaVermittlungProfil>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaVermittlungProfilId).HasColumnName("KaVermittlungProfilID");

                entity.Property(e => e.AktuelleTaetigkeit)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ArbeitsgebietBemerkungen)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ArbeitszeitenCodes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bemerkungen)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.BesondereFaehigkeiten)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.BesondereWuensche)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.BrancheCodes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EinsatzbereichCodes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EinschraenkungDi)
                    .HasColumnName("EinschraenkungDI")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EinschraenkungDo)
                    .HasColumnName("EinschraenkungDO")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EinschraenkungFr)
                    .HasColumnName("EinschraenkungFR")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EinschraenkungMi)
                    .HasColumnName("EinschraenkungMI")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EinschraenkungMo)
                    .HasColumnName("EinschraenkungMO")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EinschraenkungSa)
                    .HasColumnName("EinschraenkungSA")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EinschraenkungSo)
                    .HasColumnName("EinschraenkungSO")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.GespraechDatum).HasColumnType("datetime");

                entity.Property(e => e.GesundheitBemerkung)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.GesundheitEinschraenkungen)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InfoAnSderfolgt).HasColumnName("InfoAnSDErfolgt");

                entity.Property(e => e.InizioErstgesprVerlaufDokId).HasColumnName("InizioErstgesprVerlaufDokID");

                entity.Property(e => e.Interview).HasColumnType("datetime");

                entity.Property(e => e.KaBetriebCodes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KaLohnabtretungSdcode).HasColumnName("KaLohnabtretungSDCode");

                entity.Property(e => e.KaVermittlungProfilTs)
                    .IsRequired()
                    .HasColumnName("KaVermittlungProfilTS")
                    .IsRowVersion();

                entity.Property(e => e.MigrationKa).HasColumnName("MigrationKA");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MotivationBibipsibewertung).HasColumnName("MotivationBIBIPSIBewertung");

                entity.Property(e => e.MotivationBibipsicode).HasColumnName("MotivationBIBIPSICode");

                entity.Property(e => e.PckenntnisseCode).HasColumnName("PCKenntnisseCode");

                entity.Property(e => e.Qjextern).HasColumnName("QJExtern");

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.Property(e => e.Sigespraech)
                    .HasColumnName("SIGespraech")
                    .HasColumnType("datetime");

                entity.Property(e => e.SigespraechfuehrerinId).HasColumnName("SIGespraechfuehrerinID");

                entity.Property(e => e.UnterstuetzungInizioCodes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VermittelbarkeitBemerkung)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VermittelbarkeitBibipcode).HasColumnName("VermittelbarkeitBIBIPCode");

                entity.Property(e => e.VermittelbarkeitSicode).HasColumnName("VermittelbarkeitSICode");

                entity.Property(e => e.VermittlungsgespraechDokId).HasColumnName("VermittlungsgespraechDokID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaVermittlungProfil)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_KaVermittlungProfil_FaLeistung");
            });

            modelBuilder.Entity<KaVermittlungSi>(entity =>
            {
                entity.ToTable("KaVermittlungSI");

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.KaVermittlungSiid).HasColumnName("KaVermittlungSIID");

                entity.Property(e => e.AbschlussDatum).HasColumnType("datetime");

                entity.Property(e => e.Bemerkungen)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentIdSchlussbericht).HasColumnName("DocumentID_Schlussbericht");

                entity.Property(e => e.DossierRetourAnSd).HasColumnName("DossierRetourAnSD");

                entity.Property(e => e.DossierRetourAnSdgrundCode).HasColumnName("DossierRetourAnSDGrundCode");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaVermittlungSits)
                    .IsRequired()
                    .HasColumnName("KaVermittlungSITS")
                    .IsRowVersion();

                entity.Property(e => e.MigrationKa).HasColumnName("MigrationKA");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SichtbarSdflag).HasColumnName("SichtbarSDFlag");

                entity.Property(e => e.WechselKaintern).HasColumnName("WechselKAIntern");

                entity.Property(e => e.WechselKainternGrundCode).HasColumnName("WechselKAInternGrundCode");

                entity.Property(e => e.ZuweiserId).HasColumnName("ZuweiserID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaVermittlungSi)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_KaVermittlungSI_FaLeistung");
            });

            modelBuilder.Entity<KaVermittlungSizwischenbericht>(entity =>
            {
                entity.ToTable("KaVermittlungSIZwischenbericht");

                entity.HasIndex(e => e.KaVermittlungVorschlagId);

                entity.Property(e => e.KaVermittlungSizwischenberichtId).HasColumnName("KaVermittlungSIZwischenberichtID");

                entity.Property(e => e.Anfrage).HasColumnType("datetime");

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Eingang).HasColumnType("datetime");

                entity.Property(e => e.KaVermittlungSizwischenberichtTs)
                    .IsRequired()
                    .HasColumnName("KaVermittlungSIZwischenberichtTS")
                    .IsRowVersion();

                entity.Property(e => e.KaVermittlungVorschlagId).HasColumnName("KaVermittlungVorschlagID");

                entity.Property(e => e.Mahnung).HasColumnType("datetime");

                entity.Property(e => e.ZwischenberichtSd)
                    .HasColumnName("ZwischenberichtSD")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.KaVermittlungVorschlag)
                    .WithMany(p => p.KaVermittlungSizwischenbericht)
                    .HasForeignKey(d => d.KaVermittlungVorschlagId)
                    .HasConstraintName("FK_KaVermittlungSIZwischenbericht_KaVermittlungVorschlag");
            });

            modelBuilder.Entity<KaVermittlungVorschlag>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.KaEinsatzplatzId);

                entity.Property(e => e.KaVermittlungVorschlagId).HasColumnName("KaVermittlungVorschlagID");

                entity.Property(e => e.DossierGesendet).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KaEinsatzplatzId).HasColumnName("KaEinsatzplatzID");

                entity.Property(e => e.KaVermittlungVorschlagTs)
                    .IsRequired()
                    .HasColumnName("KaVermittlungVorschlagTS")
                    .IsRowVersion();

                entity.Property(e => e.MigrationKa)
                    .HasColumnName("MigrationKA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SchnuppernBis).HasColumnType("datetime");

                entity.Property(e => e.SchnuppernVon).HasColumnType("datetime");

                entity.Property(e => e.SichtbarSdflag)
                    .HasColumnName("SichtbarSDFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Vorschlag).HasColumnType("datetime");

                entity.Property(e => e.VorschlagAblehnungsgrundBicode).HasColumnName("VorschlagAblehnungsgrundBICode");

                entity.Property(e => e.VorschlagAblehnungsgrundBipcode).HasColumnName("VorschlagAblehnungsgrundBIPCode");

                entity.Property(e => e.VorschlagAblehnungsgrundSicode).HasColumnName("VorschlagAblehnungsgrundSICode");

                entity.Property(e => e.VorschlagBemerkungen)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.VorschlagErfasst).HasColumnType("datetime");

                entity.Property(e => e.VorschlagResultatDatum).HasColumnType("datetime");

                entity.Property(e => e.Vorstellungsgespraech).HasColumnType("datetime");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KaVermittlungVorschlag)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_KaVermittlungVorschlag_FaLeistung");

                entity.HasOne(d => d.KaEinsatzplatz)
                    .WithMany(p => p.KaVermittlungVorschlag)
                    .HasForeignKey(d => d.KaEinsatzplatzId)
                    .HasConstraintName("FK_KaVermittlungVorschlag_KaEinsatzplatz");
            });

            modelBuilder.Entity<KaZuteilFachbereich>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.Property(e => e.KaZuteilFachbereichId).HasColumnName("KaZuteilFachbereichID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.FachbereichId).HasColumnName("FachbereichID");

                entity.Property(e => e.FachleitungId).HasColumnName("FachleitungID");

                entity.Property(e => e.KaZuteilFachbereichTs)
                    .IsRequired()
                    .HasColumnName("KaZuteilFachbereichTS")
                    .IsRowVersion();

                entity.Property(e => e.SichtbarSdflag)
                    .HasColumnName("SichtbarSDFlag")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ZustaendigKaId).HasColumnName("ZustaendigKaID");

                entity.Property(e => e.ZuteilDokId).HasColumnName("ZuteilDokID");

                entity.Property(e => e.ZuteilungBis).HasColumnType("datetime");

                entity.Property(e => e.ZuteilungVon).HasColumnType("datetime");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.KaZuteilFachbereich)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KaZuteilFachbereich_BaPerson");
            });

            modelBuilder.Entity<KbBelegKreis>(entity =>
            {
                entity.HasIndex(e => e.KbPeriodeId);

                entity.HasIndex(e => new { e.KbPeriodeId, e.KbBelegKreisCode, e.KontoNr })
                    .HasName("IX_KbBelegKreis_KbBelegKreisKbPeriodeIDKontoNr_Unique")
                    .IsUnique();

                entity.Property(e => e.KbBelegKreisId).HasColumnName("KbBelegKreisID");

                entity.Property(e => e.KbBelegKreisTs)
                    .IsRequired()
                    .HasColumnName("KbBelegKreisTS")
                    .IsRowVersion();

                entity.Property(e => e.KbPeriodeId).HasColumnName("KbPeriodeID");

                entity.Property(e => e.KontoNr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.KbPeriode)
                    .WithMany(p => p.KbBelegKreis)
                    .HasForeignKey(d => d.KbPeriodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbBelegKreis_KbPeriode");

                entity.HasOne(d => d.K)
                    .WithMany(p => p.KbBelegKreis)
                    .HasPrincipalKey(p => new { p.KbPeriodeId, p.KontoNr })
                    .HasForeignKey(d => new { d.KbPeriodeId, d.KontoNr })
                    .HasConstraintName("FK_KbBelegKreis_KbKonto");
            });

            modelBuilder.Entity<KbBuchung>(entity =>
            {
                entity.HasIndex(e => e.BeguenstigtLandCode);

                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.IkForderungBgKostenartHistId)
                    .HasName("IX_KbBuchung_IkForderungBgKostenartHist");

                entity.HasIndex(e => e.IkPositionId);

                entity.HasIndex(e => e.KbAuszahlungsArtCode);

                entity.HasIndex(e => e.KbBuchungStatusCode);

                entity.HasIndex(e => e.KbBuchungTs);

                entity.HasIndex(e => e.KbZahlungskontoId);

                entity.HasIndex(e => e.NeubuchungVonKbBuchungId)
                    .HasName("IX_KbBuchung_NeuBuchung");

                entity.HasIndex(e => e.StorniertKbBuchungId)
                    .HasName("IX_KbBuchung_StornierKbBuchung");

                entity.HasIndex(e => new { e.KbBelegKreisId, e.BelegNr });

                entity.HasIndex(e => new { e.KbPeriodeId, e.HabenKtoNr })
                    .HasName("IX_KbBuchung_HabenKtoNr");

                entity.HasIndex(e => new { e.KbPeriodeId, e.KbBuchungId })
                    .HasName("IX_KbBuchung_Sicherung")
                    .IsUnique();

                entity.HasIndex(e => new { e.KbPeriodeId, e.SollKtoNr })
                    .HasName("IX_KbBuchung_SollKto");

                entity.HasIndex(e => new { e.KbZahlungseingangId, e.Betrag })
                    .HasName("IX_KbBuchung_KbZahlungseingangID");

                entity.HasIndex(e => new { e.BgBudgetId, e.KbBuchungStatusCode, e.KbBuchungId })
                    .HasName("IX_KbBuchung_BgBudgetID");

                entity.HasIndex(e => new { e.KbBuchungId, e.BelegNr, e.KbPeriodeId, e.KbBuchungTypCode, e.KbZahlungseingangId })
                    .HasName("IX_KbBuchung_KbBuchungTypCode_KbZahlungseingangID");

                entity.HasIndex(e => new { e.KbBuchungId, e.KbAuszahlungsArtCode, e.KbBuchungStatusCode, e.BelegDatum, e.ValutaDatum });

                entity.HasIndex(e => new { e.KbBuchungId, e.KbBuchungStatusCode, e.BgBudgetId, e.ValutaDatum, e.KbPeriodeId, e.KbBuchungTypCode, e.KbAuszahlungsArtCode })
                    .HasName("IX_KbBuchung_KbBuchungTypCode_KbBuchungStatusCode_KbAuszahlungsArtCode");

                entity.HasIndex(e => new { e.KbBuchungId, e.ValutaDatum, e.KbPeriodeId, e.KbBuchungStatusCode, e.BgBudgetId, e.KbBuchungTypCode, e.KbAuszahlungsArtCode })
                    .HasName("IX_KbBuchung_KbBuchungTypCode_KbAuszahlungsArtCode");

                entity.HasIndex(e => new { e.KbPeriodeId, e.HabenKtoNr, e.KbBuchungId, e.BelegNr, e.BelegDatum, e.SollKtoNr, e.Betrag });

                entity.HasIndex(e => new { e.KbBuchungId, e.SollKtoNr, e.HabenKtoNr, e.KbZahlungseingangId, e.KbPeriodeId, e.BelegNr, e.BelegDatum, e.Betrag })
                    .HasName("IX_KbBuchung_KbPeriodeID_BelegNr_BelegDatum_Betrag");

                entity.Property(e => e.KbBuchungId).HasColumnName("KbBuchungID");

                entity.Property(e => e.AggregateInfo)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.BaBankId).HasColumnName("BaBankID");

                entity.Property(e => e.BaZahlungswegId).HasColumnName("BaZahlungswegID");

                entity.Property(e => e.BankBcn)
                    .HasColumnName("BankBCN")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.BankKontoNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.BankOrt)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.BankPlz)
                    .HasColumnName("BankPLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BankStrasse)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BarbelegDatum).HasColumnType("datetime");

                entity.Property(e => e.BarbelegUserId).HasColumnName("BarbelegUserID");

                entity.Property(e => e.BeguenstigtHausNr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BeguenstigtName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BeguenstigtName2)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BeguenstigtOrt)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BeguenstigtPlz)
                    .HasColumnName("BeguenstigtPLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BeguenstigtPostfach)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.BeguenstigtStrasse)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BelegDatum).HasColumnType("datetime");

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.BgBudgetId).HasColumnName("BgBudgetID");

                entity.Property(e => e.ErstelltDatum)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErstelltUserId).HasColumnName("ErstelltUserID");

                entity.Property(e => e.Extern)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FibuFehlermeldung)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.HabenKtoNr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Iban)
                    .HasColumnName("IBAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IkForderungBgKostenartHistId).HasColumnName("IkForderungBgKostenartHistID");

                entity.Property(e => e.IkPositionId).HasColumnName("IkPositionID");

                entity.Property(e => e.KbBelegKreisId).HasColumnName("KbBelegKreisID");

                entity.Property(e => e.KbBuchungTs)
                    .IsRequired()
                    .HasColumnName("KbBuchungTS")
                    .IsRowVersion();

                entity.Property(e => e.KbPeriodeId).HasColumnName("KbPeriodeID");

                entity.Property(e => e.KbZahlungseingangId).HasColumnName("KbZahlungseingangID");

                entity.Property(e => e.KbZahlungskontoId).HasColumnName("KbZahlungskontoID");

                entity.Property(e => e.MitteilungZeile1)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MitteilungZeile2)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MitteilungZeile3)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MitteilungZeile4)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MutiertDatum).HasColumnType("datetime");

                entity.Property(e => e.MutiertUserId).HasColumnName("MutiertUserID");

                entity.Property(e => e.NeubuchungVonKbBuchungId).HasColumnName("NeubuchungVonKbBuchungID");

                entity.Property(e => e.OldSourceId).HasColumnName("Old_SourceID");

                entity.Property(e => e.PckontoNr)
                    .HasColumnName("PCKontoNr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenzNummer)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SchuldnerBaInstitutionId).HasColumnName("Schuldner_BaInstitutionID");

                entity.Property(e => e.SchuldnerBaPersonId).HasColumnName("Schuldner_BaPersonID");

                entity.Property(e => e.SollKtoNr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StorniertKbBuchungId).HasColumnName("StorniertKbBuchungID");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TransferDatum).HasColumnType("datetime");

                entity.Property(e => e.ValutaDatum).HasColumnType("datetime");

                entity.Property(e => e.Zahlungsgrund)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaBank)
                    .WithMany(p => p.KbBuchung)
                    .HasForeignKey(d => d.BaBankId)
                    .HasConstraintName("FK_KbBuchung_BaBank");

                entity.HasOne(d => d.BaZahlungsweg)
                    .WithMany(p => p.KbBuchung)
                    .HasForeignKey(d => d.BaZahlungswegId)
                    .HasConstraintName("FK_KbBuchung_BaZahlungsweg");

                entity.HasOne(d => d.BarbelegUser)
                    .WithMany(p => p.KbBuchungBarbelegUser)
                    .HasForeignKey(d => d.BarbelegUserId)
                    .HasConstraintName("FK_KbBuchung_UserID_Kasse");

                entity.HasOne(d => d.BeguenstigtLandCodeNavigation)
                    .WithMany(p => p.KbBuchung)
                    .HasForeignKey(d => d.BeguenstigtLandCode)
                    .HasConstraintName("FK_KbBuchung_BaLand");

                entity.HasOne(d => d.BgBudget)
                    .WithMany(p => p.KbBuchung)
                    .HasForeignKey(d => d.BgBudgetId)
                    .HasConstraintName("FK_KbBuchung_BgBudget");

                entity.HasOne(d => d.ErstelltUser)
                    .WithMany(p => p.KbBuchungErstelltUser)
                    .HasForeignKey(d => d.ErstelltUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KbBuchung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_KbBuchung_FaLeistung");

                entity.HasOne(d => d.IkForderungBgKostenartHist)
                    .WithMany(p => p.KbBuchung)
                    .HasForeignKey(d => d.IkForderungBgKostenartHistId)
                    .HasConstraintName("FK_KbBuchung_IkForderungBgKostenartHist");

                entity.HasOne(d => d.IkPosition)
                    .WithMany(p => p.KbBuchung)
                    .HasForeignKey(d => d.IkPositionId)
                    .HasConstraintName("FK_KbBuchung_IkPosition");

                entity.HasOne(d => d.KbBelegKreis)
                    .WithMany(p => p.KbBuchung)
                    .HasForeignKey(d => d.KbBelegKreisId)
                    .HasConstraintName("FK_KbBuchung_KbBelegKreis");

                entity.HasOne(d => d.KbPeriode)
                    .WithMany(p => p.KbBuchung)
                    .HasForeignKey(d => d.KbPeriodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbBuchung_KbPeriode");

                entity.HasOne(d => d.KbZahlungseingang)
                    .WithMany(p => p.KbBuchung)
                    .HasForeignKey(d => d.KbZahlungseingangId)
                    .HasConstraintName("FK_KbBuchung_KbZahlungseingang");

                entity.HasOne(d => d.KbZahlungskonto)
                    .WithMany(p => p.KbBuchung)
                    .HasForeignKey(d => d.KbZahlungskontoId)
                    .HasConstraintName("FK_KbBuchung_KbZahlungskonto");

                entity.HasOne(d => d.MutiertUser)
                    .WithMany(p => p.KbBuchungMutiertUser)
                    .HasForeignKey(d => d.MutiertUserId);

                entity.HasOne(d => d.NeubuchungVonKbBuchung)
                    .WithMany(p => p.InverseNeubuchungVonKbBuchung)
                    .HasForeignKey(d => d.NeubuchungVonKbBuchungId)
                    .HasConstraintName("FK_KbBuchung_KbBuchungNeuBuchung");

                entity.HasOne(d => d.SchuldnerBaInstitution)
                    .WithMany(p => p.KbBuchung)
                    .HasForeignKey(d => d.SchuldnerBaInstitutionId)
                    .HasConstraintName("FK_KbBuchung_BaInstitution");

                entity.HasOne(d => d.SchuldnerBaPerson)
                    .WithMany(p => p.KbBuchung)
                    .HasForeignKey(d => d.SchuldnerBaPersonId)
                    .HasConstraintName("FK_KbBuchung_BaPerson");

                entity.HasOne(d => d.StorniertKbBuchung)
                    .WithMany(p => p.InverseStorniertKbBuchung)
                    .HasForeignKey(d => d.StorniertKbBuchungId)
                    .HasConstraintName("FK_KbBuchung_KbBuchungStorniert");
            });

            modelBuilder.Entity<KbBuchungKostenart>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.BgKostenartId);

                entity.HasIndex(e => e.KbBuchungId);

                entity.HasIndex(e => e.KbKostenstelleId);

                entity.HasIndex(e => new { e.BgPositionId, e.KbBuchungId });

                entity.HasIndex(e => new { e.GvAuszahlungPositionId, e.KbBuchungId });

                entity.HasIndex(e => new { e.KbBuchungId, e.KbKostenstelleId });

                entity.HasIndex(e => new { e.Betrag, e.KbBuchungId, e.KontoNr });

                entity.HasIndex(e => new { e.BgKostenartId, e.KbBuchungKostenartId, e.KbBuchungId });

                entity.HasIndex(e => new { e.KbBuchungId, e.KbBuchungKostenartId, e.KbKostenstelleId, e.Betrag, e.BgKostenartId });

                entity.Property(e => e.KbBuchungKostenartId).HasColumnName("KbBuchungKostenartID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.BgKostenartId).HasColumnName("BgKostenartID");

                entity.Property(e => e.BgPositionId).HasColumnName("BgPositionID");

                entity.Property(e => e.Buchungstext)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.GvAuszahlungPositionId).HasColumnName("GvAuszahlungPositionID");

                entity.Property(e => e.KbBuchungId).HasColumnName("KbBuchungID");

                entity.Property(e => e.KbBuchungKostenartTs)
                    .IsRequired()
                    .HasColumnName("KbBuchungKostenartTS")
                    .IsRowVersion();

                entity.Property(e => e.KbKostenstelleId).HasColumnName("KbKostenstelleID");

                entity.Property(e => e.KontoNr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VerwPeriodeBis).HasColumnType("datetime");

                entity.Property(e => e.VerwPeriodeVon).HasColumnType("datetime");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.KbBuchungKostenart)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_KbBuchungKostenart_BaPerson");

                entity.HasOne(d => d.BgKostenart)
                    .WithMany(p => p.KbBuchungKostenart)
                    .HasForeignKey(d => d.BgKostenartId)
                    .HasConstraintName("FK_KbBuchungKostenart_BgKostenart");

                entity.HasOne(d => d.BgPosition)
                    .WithMany(p => p.KbBuchungKostenart)
                    .HasForeignKey(d => d.BgPositionId)
                    .HasConstraintName("FK_KbBuchungKostenart_BgPosition");

                entity.HasOne(d => d.GvAuszahlungPosition)
                    .WithMany(p => p.KbBuchungKostenart)
                    .HasForeignKey(d => d.GvAuszahlungPositionId)
                    .HasConstraintName("FK_KbBuchungKostenart_GvAuszahlungPosition");

                entity.HasOne(d => d.KbBuchung)
                    .WithMany(p => p.KbBuchungKostenart)
                    .HasForeignKey(d => d.KbBuchungId)
                    .HasConstraintName("FK_KbBuchungKostenart_KbBuchung");

                entity.HasOne(d => d.KbKostenstelle)
                    .WithMany(p => p.KbBuchungKostenart)
                    .HasForeignKey(d => d.KbKostenstelleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbKostenstelle_KbKostenstelle");
            });

            modelBuilder.Entity<KbForderungAuszahlung>(entity =>
            {
                entity.HasIndex(e => e.KbBuchungIdAuszahlung);

                entity.HasIndex(e => e.KbBuchungIdForderung);

                entity.Property(e => e.KbForderungAuszahlungId).HasColumnName("KbForderungAuszahlungID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KbBuchungIdAuszahlung).HasColumnName("KbBuchungID_Auszahlung");

                entity.Property(e => e.KbBuchungIdForderung).HasColumnName("KbBuchungID_Forderung");

                entity.Property(e => e.KbForderungAuszahlungTs)
                    .IsRequired()
                    .HasColumnName("KbForderungAuszahlungTS")
                    .IsRowVersion();

                entity.Property(e => e.KbOpAusgleichId).HasColumnName("KbOpAusgleichID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.KbBuchungIdAuszahlungNavigation)
                    .WithMany(p => p.KbForderungAuszahlungKbBuchungIdAuszahlungNavigation)
                    .HasForeignKey(d => d.KbBuchungIdAuszahlung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbForderungAuszahlung_KbBuchung_Auszahlung");

                entity.HasOne(d => d.KbBuchungIdForderungNavigation)
                    .WithMany(p => p.KbForderungAuszahlungKbBuchungIdForderungNavigation)
                    .HasForeignKey(d => d.KbBuchungIdForderung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbForderungAuszahlung_KbBuchung_Forderung");

                entity.HasOne(d => d.KbOpAusgleich)
                    .WithMany(p => p.KbForderungAuszahlung)
                    .HasForeignKey(d => d.KbOpAusgleichId)
                    .HasConstraintName("FK_KbForderungAuszahlung_KbOpAusgleich");
            });

            modelBuilder.Entity<KbFreieBelegNummer>(entity =>
            {
                entity.HasKey(e => new { e.KbBelegKreisId, e.BelegNr });

                entity.Property(e => e.KbBelegKreisId).HasColumnName("KbBelegKreisID");

                entity.Property(e => e.KbFreieBelegNummerTs)
                    .IsRequired()
                    .HasColumnName("KbFreieBelegNummerTS")
                    .IsRowVersion();

                entity.HasOne(d => d.KbBelegKreis)
                    .WithMany(p => p.KbFreieBelegNummer)
                    .HasForeignKey(d => d.KbBelegKreisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbFreieBelegNummer_KbBelegKreis");
            });

            modelBuilder.Entity<KbKonto>(entity =>
            {
                entity.HasIndex(e => new { e.KbPeriodeId, e.KontoNr })
                    .HasName("IX_KbKonto")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.KbKontoId).HasColumnName("KbKontoID");

                entity.Property(e => e.GruppeKontoId).HasColumnName("GruppeKontoID");

                entity.Property(e => e.KbKontoTs)
                    .IsRequired()
                    .HasColumnName("KbKontoTS")
                    .IsRowVersion();

                entity.Property(e => e.KbKontoartCodes)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.KbPeriodeId)
                    .IsRequired()
                    .HasColumnName("KbPeriodeID");

                entity.Property(e => e.KbZahlungskontoId).HasColumnName("KbZahlungskontoID");

                entity.Property(e => e.KontoName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KontoNr)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SaldoGruppeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Vorsaldo)
                    .HasColumnType("money")
                    .HasDefaultValueSql("(0)");

                entity.HasOne(d => d.GruppeKonto)
                    .WithMany(p => p.InverseGruppeKonto)
                    .HasForeignKey(d => d.GruppeKontoId)
                    .HasConstraintName("FK_KbKonto_KbKonto");

                entity.HasOne(d => d.KbPeriode)
                    .WithMany(p => p.KbKonto)
                    .HasForeignKey(d => d.KbPeriodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbKonto_KbPeriode");

                entity.HasOne(d => d.KbZahlungskonto)
                    .WithMany(p => p.KbKonto)
                    .HasForeignKey(d => d.KbZahlungskontoId)
                    .HasConstraintName("FK_KbKonto_KbZahlungskonto");
            });

            modelBuilder.Entity<KbKostenstelle>(entity =>
            {
                entity.HasIndex(e => e.ModulId);

                entity.Property(e => e.KbKostenstelleId).HasColumnName("KbKostenstelleID");

                entity.Property(e => e.KbKostenstelleTs)
                    .IsRequired()
                    .HasColumnName("KbKostenstelleTS")
                    .IsRowVersion();

                entity.Property(e => e.ModulId).HasColumnName("ModulID");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nr)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Vorsaldo).HasColumnType("money");

                entity.HasOne(d => d.Modul)
                    .WithMany(p => p.KbKostenstelle)
                    .HasForeignKey(d => d.ModulId)
                    .HasConstraintName("FK_KbKostenstelle_XModul");
            });

            modelBuilder.Entity<KbKostenstelleBaPerson>(entity =>
            {
                entity.ToTable("KbKostenstelle_BaPerson");

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.KbKostenstelleId);

                entity.Property(e => e.KbKostenstelleBaPersonId).HasColumnName("KbKostenstelleBaPersonID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.KbKostenstelleBaPersonTs)
                    .IsRequired()
                    .HasColumnName("KbKostenstelle_BaPersonTS")
                    .IsRowVersion();

                entity.Property(e => e.KbKostenstelleId).HasColumnName("KbKostenstelleID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.KbKostenstelleBaPerson)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_KbKostenstelle_BaPerson_BaPersonID");

                entity.HasOne(d => d.KbKostenstelle)
                    .WithMany(p => p.KbKostenstelleBaPerson)
                    .HasForeignKey(d => d.KbKostenstelleId)
                    .HasConstraintName("FK_KbKostenstelle_BaPerson_KbKostenstelleID");
            });

            modelBuilder.Entity<KbMandant>(entity =>
            {
                entity.Property(e => e.KbMandantId).HasColumnName("KbMandantID");

                entity.Property(e => e.KbMandantTs)
                    .IsRequired()
                    .HasColumnName("KbMandantTS")
                    .IsRowVersion();

                entity.Property(e => e.Mandant)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MandantTid).HasColumnName("MandantTID");
            });

            modelBuilder.Entity<KbOpAusgleich>(entity =>
            {
                entity.HasIndex(e => e.AusgleichBuchungId);

                entity.HasIndex(e => e.OpBuchungId);

                entity.HasIndex(e => new { e.OpBuchungId, e.KbOpAusgleichId, e.AusgleichBuchungId });

                entity.Property(e => e.KbOpAusgleichId).HasColumnName("KbOpAusgleichID");

                entity.Property(e => e.AusgleichBuchungId).HasColumnName("AusgleichBuchungID");

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.KbOpAusgleichTs)
                    .IsRequired()
                    .HasColumnName("KbOpAusgleichTS")
                    .IsRowVersion();

                entity.Property(e => e.MigAiZahlungVsForderungId).HasColumnName("_mig_AiZahlungVsForderungID");

                entity.Property(e => e.OpBuchungId).HasColumnName("OpBuchungID");

                entity.HasOne(d => d.AusgleichBuchung)
                    .WithMany(p => p.KbOpAusgleichAusgleichBuchung)
                    .HasForeignKey(d => d.AusgleichBuchungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbOpAusgleich_KbBuchung1");

                entity.HasOne(d => d.OpBuchung)
                    .WithMany(p => p.KbOpAusgleichOpBuchung)
                    .HasForeignKey(d => d.OpBuchungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbOpAusgleich_KbBuchung");
            });

            modelBuilder.Entity<KbPeriode>(entity =>
            {
                entity.HasIndex(e => e.KbMandantId);

                entity.Property(e => e.KbPeriodeId).HasColumnName("KbPeriodeID");

                entity.Property(e => e.KbMandantId).HasColumnName("KbMandantID");

                entity.Property(e => e.KbPeriodeTs)
                    .IsRequired()
                    .HasColumnName("KbPeriodeTS")
                    .IsRowVersion();

                entity.Property(e => e.PeriodeBis).HasColumnType("datetime");

                entity.Property(e => e.PeriodeVon).HasColumnType("datetime");

                entity.Property(e => e.VerbuchtBis).HasColumnType("datetime");

                entity.HasOne(d => d.KbMandant)
                    .WithMany(p => p.KbPeriode)
                    .HasForeignKey(d => d.KbMandantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbPeriode_KbMandant");
            });

            modelBuilder.Entity<KbPeriodeUser>(entity =>
            {
                entity.HasKey(e => new { e.KbPeriodeId, e.UserId });

                entity.ToTable("KbPeriode_User");

                entity.Property(e => e.KbPeriodeId).HasColumnName("KbPeriodeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.KbPeriodeUserTs)
                    .IsRequired()
                    .HasColumnName("KbPeriode_UserTS")
                    .IsRowVersion();

                entity.HasOne(d => d.KbPeriode)
                    .WithMany(p => p.KbPeriodeUser)
                    .HasForeignKey(d => d.KbPeriodeId)
                    .HasConstraintName("FK_KbPeriode_User_KbPeriode");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.KbPeriodeUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_KbPeriode_User_XUser");
            });

            modelBuilder.Entity<KbTransfer>(entity =>
            {
                entity.HasKey(e => new { e.KbBuchungId, e.KbZahlungslaufId });

                entity.HasIndex(e => new { e.KbBuchungId, e.KbZahlungslaufId, e.KbTransferStatusCode })
                    .HasName("IX_KbTransfer_KbZahlungslaufID_KbTransferStatusCode");

                entity.Property(e => e.KbBuchungId).HasColumnName("KbBuchungID");

                entity.Property(e => e.KbZahlungslaufId).HasColumnName("KbZahlungslaufID");

                entity.Property(e => e.KbTransferStatusCode).HasDefaultValueSql("(1)");

                entity.Property(e => e.KbTransferTs)
                    .IsRequired()
                    .HasColumnName("KbTransferTS")
                    .IsRowVersion();

                entity.HasOne(d => d.KbBuchung)
                    .WithMany(p => p.KbTransfer)
                    .HasForeignKey(d => d.KbBuchungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbTransfer_KbBuchung");

                entity.HasOne(d => d.KbZahlungslauf)
                    .WithMany(p => p.KbTransfer)
                    .HasForeignKey(d => d.KbZahlungslaufId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbTransfer_KbZahlungslauf");
            });

            modelBuilder.Entity<KbWveinzelposten>(entity =>
            {
                entity.ToTable("KbWVEinzelposten");

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.BaWvcodeId);

                entity.HasIndex(e => e.BgKostenartId);

                entity.HasIndex(e => e.KbBuchungKostenartId);

                entity.HasIndex(e => e.KbKostenstelleId);

                entity.HasIndex(e => e.KbWvlaufId);

                entity.HasIndex(e => e.StorniertKbWveinzelpostenId);

                entity.Property(e => e.KbWveinzelpostenId).HasColumnName("KbWVEinzelpostenID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.BaWvcode).HasColumnName("BaWVCode");

                entity.Property(e => e.BaWvcodeId).HasColumnName("BaWVCodeID");

                entity.Property(e => e.Bemerkungen)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.BgKostenartId).HasColumnName("BgKostenartID");

                entity.Property(e => e.Buchungstext)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.HeimatkantonNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KantonKuerzel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KbBuchungKostenartId).HasColumnName("KbBuchungKostenartID");

                entity.Property(e => e.KbKostenstelleId).HasColumnName("KbKostenstelleID");

                entity.Property(e => e.KbWveinzelpositionTs)
                    .IsRequired()
                    .HasColumnName("KbWVEinzelpositionTS")
                    .IsRowVersion();

                entity.Property(e => e.KbWveinzelpostenStatusCode).HasColumnName("KbWVEinzelpostenStatusCode");

                entity.Property(e => e.KbWvlaufId).HasColumnName("KbWVLaufID");

                entity.Property(e => e.SplittingDurchWvlaufDatumBis).HasColumnName("SplittingDurchWVLaufDatumBis");

                entity.Property(e => e.StorniertKbWveinzelpostenId).HasColumnName("StorniertKbWVEinzelpostenID");

                entity.Property(e => e.WohnKantonNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.KbWveinzelposten)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbWVEinzelposten_BaPerson");

                entity.HasOne(d => d.BaWvcodeNavigation)
                    .WithMany(p => p.KbWveinzelposten)
                    .HasForeignKey(d => d.BaWvcodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbWVEinzelposten_BaWVCode");

                entity.HasOne(d => d.BgKostenart)
                    .WithMany(p => p.KbWveinzelposten)
                    .HasForeignKey(d => d.BgKostenartId)
                    .HasConstraintName("FK_KbWVEinzelposten_BgKostenart");

                entity.HasOne(d => d.KbBuchungKostenart)
                    .WithMany(p => p.KbWveinzelposten)
                    .HasForeignKey(d => d.KbBuchungKostenartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbWVEinzelposten_KbBuchungKostenart");

                entity.HasOne(d => d.KbKostenstelle)
                    .WithMany(p => p.KbWveinzelposten)
                    .HasForeignKey(d => d.KbKostenstelleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbWVEinzelposten_KbKostenstelle");

                entity.HasOne(d => d.KbWvlauf)
                    .WithMany(p => p.KbWveinzelposten)
                    .HasForeignKey(d => d.KbWvlaufId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbWVEinzelposten_KbWVLauf");

                entity.HasOne(d => d.StorniertKbWveinzelposten)
                    .WithMany(p => p.InverseStorniertKbWveinzelposten)
                    .HasForeignKey(d => d.StorniertKbWveinzelpostenId)
                    .HasConstraintName("FK_KbWVEinzelposten_KbWVEinzelposten");
            });

            modelBuilder.Entity<KbWveinzelpostenFehler>(entity =>
            {
                entity.ToTable("KbWVEinzelpostenFehler");

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.KbBuchungKostenartId);

                entity.HasIndex(e => e.KbWvlaufId);

                entity.Property(e => e.KbWveinzelpostenFehlerId).HasColumnName("KbWVEinzelpostenFehlerID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.KbBuchungKostenartId).HasColumnName("KbBuchungKostenartID");

                entity.Property(e => e.KbWveinzelpostenFehlerTs)
                    .IsRequired()
                    .HasColumnName("KbWVEinzelpostenFehlerTS")
                    .IsRowVersion();

                entity.Property(e => e.KbWvlaufId).HasColumnName("KbWVLaufID");

                entity.Property(e => e.Wvfehlermeldung)
                    .IsRequired()
                    .HasColumnName("WVFehlermeldung")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.KbWveinzelpostenFehler)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbWVEinzelpostenFehler_BaPerson");

                entity.HasOne(d => d.KbBuchungKostenart)
                    .WithMany(p => p.KbWveinzelpostenFehler)
                    .HasForeignKey(d => d.KbBuchungKostenartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbWVEinzelpostenFehler_KbBuchungKostenart");

                entity.HasOne(d => d.KbWvlauf)
                    .WithMany(p => p.KbWveinzelpostenFehler)
                    .HasForeignKey(d => d.KbWvlaufId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbWVEinzelpostenFehler_KbWVLauf");
            });

            modelBuilder.Entity<KbWvlauf>(entity =>
            {
                entity.ToTable("KbWVLauf");

                entity.HasIndex(e => e.KbPeriodeId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.KbWvlaufId).HasColumnName("KbWVLaufID");

                entity.Property(e => e.DatumBisWvlauf)
                    .HasColumnName("DatumBisWVLauf")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDatum).HasColumnType("datetime");

                entity.Property(e => e.KbPeriodeId).HasColumnName("KbPeriodeID");

                entity.Property(e => e.KbWvlaufTs)
                    .IsRequired()
                    .HasColumnName("KbWVLaufTS")
                    .IsRowVersion();

                entity.Property(e => e.StartDatum)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.KbPeriode)
                    .WithMany(p => p.KbWvlauf)
                    .HasForeignKey(d => d.KbPeriodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbWVLauf_KbPeriode");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.KbWvlauf)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbWVLauf_XUser");
            });

            modelBuilder.Entity<KbZahlungseingang>(entity =>
            {
                entity.HasIndex(e => e.BaInstitutionId);

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.ErstelltUserId);

                entity.HasIndex(e => e.MutiertUserId);

                entity.HasIndex(e => e.ZugeteiltUserId);

                entity.Property(e => e.KbZahlungseingangId).HasColumnName("KbZahlungseingangID");

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Debitor)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ErstelltDatum).HasColumnType("datetime");

                entity.Property(e => e.ErstelltUserId).HasColumnName("ErstelltUserID");

                entity.Property(e => e.KbZahlungseingangTs)
                    .IsRequired()
                    .HasColumnName("KbZahlungseingangTS")
                    .IsRowVersion();

                entity.Property(e => e.KontoNr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Mitteilung1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mitteilung2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mitteilung3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mitteilung4)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MutiertDatum).HasColumnType("datetime");

                entity.Property(e => e.MutiertUserId).HasColumnName("MutiertUserID");

                entity.Property(e => e.ZugeteiltUserId).HasColumnName("ZugeteiltUserID");

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.KbZahlungseingang)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .HasConstraintName("FK_KbZahlungseingang_BaInstitution");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.KbZahlungseingang)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_KbZahlungseingang_BaPerson");

                entity.HasOne(d => d.ErstelltUser)
                    .WithMany(p => p.KbZahlungseingangErstelltUser)
                    .HasForeignKey(d => d.ErstelltUserId)
                    .HasConstraintName("FK_KbZahlungseingang_ErstelltXUser");

                entity.HasOne(d => d.MutiertUser)
                    .WithMany(p => p.KbZahlungseingangMutiertUser)
                    .HasForeignKey(d => d.MutiertUserId)
                    .HasConstraintName("FK_KbZahlungseingang_MutiertXUser");

                entity.HasOne(d => d.ZugeteiltUser)
                    .WithMany(p => p.KbZahlungseingangZugeteiltUser)
                    .HasForeignKey(d => d.ZugeteiltUserId)
                    .HasConstraintName("FK_KbZahlungseingang_ZugeteiltXUser");
            });

            modelBuilder.Entity<KbZahlungskonto>(entity =>
            {
                entity.HasIndex(e => e.BaBankId);

                entity.Property(e => e.KbZahlungskontoId).HasColumnName("KbZahlungskontoID");

                entity.Property(e => e.BaBankId).HasColumnName("BaBankID");

                entity.Property(e => e.KbDtazugangTs)
                    .IsRequired()
                    .HasColumnName("KbDTAZugangTS")
                    .IsRowVersion();

                entity.Property(e => e.KontoNr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VertragNr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaBank)
                    .WithMany(p => p.KbZahlungskonto)
                    .HasForeignKey(d => d.BaBankId)
                    .HasConstraintName("FK_KbDTAZugang_BaBank");
            });

            modelBuilder.Entity<KbZahlungskontoXorgUnit>(entity =>
            {
                entity.ToTable("KbZahlungskonto_XOrgUnit");

                entity.HasIndex(e => e.KbZahlungskontoId);

                entity.HasIndex(e => e.OrgUnitId);

                entity.Property(e => e.KbZahlungskontoXorgUnitId).HasColumnName("KbZahlungskonto_XOrgUnitID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KbZahlungskontoId).HasColumnName("KbZahlungskontoID");

                entity.Property(e => e.KbZahlungskontoXorgUnitTs)
                    .IsRequired()
                    .HasColumnName("KbZahlungskonto_XOrgUnitTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrgUnitId).HasColumnName("OrgUnitID");

                entity.HasOne(d => d.KbZahlungskonto)
                    .WithMany(p => p.KbZahlungskontoXorgUnit)
                    .HasForeignKey(d => d.KbZahlungskontoId)
                    .HasConstraintName("FK_KbZahlungskonto_XOrgUnit_KbZahlungskonto");

                entity.HasOne(d => d.OrgUnit)
                    .WithMany(p => p.KbZahlungskontoXorgUnit)
                    .HasForeignKey(d => d.OrgUnitId)
                    .HasConstraintName("FK_KbZahlungskonto_XOrgUnit_XOrgUnit");
            });

            modelBuilder.Entity<KbZahlungslauf>(entity =>
            {
                entity.HasIndex(e => e.KbZahlungskontoId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.KbZahlungslaufId).HasColumnName("KbZahlungslaufID");

                entity.Property(e => e.FaelligkeitDatum).HasColumnType("datetime");

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.KbZahlungskontoId).HasColumnName("KbZahlungskontoID");

                entity.Property(e => e.KbZahlungslaufTs)
                    .IsRequired()
                    .HasColumnName("KbZahlungslaufTS")
                    .IsRowVersion();

                entity.Property(e => e.PaymentMessageId)
                    .HasColumnName("PaymentMessageID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.TotalBetrag).HasColumnType("money");

                entity.Property(e => e.TransferDatum).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Zahlungsdaten)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.KbZahlungskonto)
                    .WithMany(p => p.KbZahlungslauf)
                    .HasForeignKey(d => d.KbZahlungskontoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbZahlungslauf_KbZahlungskonto");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.KbZahlungslauf)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KbZahlungslauf_XUser");
            });

            modelBuilder.Entity<KbZahlungslaufValuta>(entity =>
            {
                entity.HasIndex(e => new { e.Jahr, e.Monat })
                    .HasName("IX_KbZahlungslaufValuta_JahrMonat_Unique")
                    .IsUnique();

                entity.Property(e => e.KbZahlungslaufValutaId).HasColumnName("KbZahlungslaufValutaID");

                entity.Property(e => e.Dat14Tage1).HasColumnType("datetime");

                entity.Property(e => e.Dat14Tage2).HasColumnType("datetime");

                entity.Property(e => e.Dat14Tage3).HasColumnType("datetime");

                entity.Property(e => e.DatMonatlich).HasColumnType("datetime");

                entity.Property(e => e.DatTeil1).HasColumnType("datetime");

                entity.Property(e => e.DatTeil2).HasColumnType("datetime");

                entity.Property(e => e.DatWoche1).HasColumnType("datetime");

                entity.Property(e => e.DatWoche2).HasColumnType("datetime");

                entity.Property(e => e.DatWoche3).HasColumnType("datetime");

                entity.Property(e => e.DatWoche4).HasColumnType("datetime");

                entity.Property(e => e.DatWoche5).HasColumnType("datetime");

                entity.Property(e => e.KbZahlungslaufValutaTs)
                    .IsRequired()
                    .HasColumnName("KbZahlungslaufValutaTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<KesArtikel>(entity =>
            {
                entity.Property(e => e.KesArtikelId).HasColumnName("KesArtikelID");

                entity.Property(e => e.Absatz)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Artikel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bezeichnung).IsUnicode(false);

                entity.Property(e => e.BezeichnungKurz).IsUnicode(false);

                entity.Property(e => e.CodeKokes)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.Gesetz)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KesArtikelTs)
                    .IsRequired()
                    .HasColumnName("KesArtikelTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ziffer)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KesAuftrag>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.KesAuftragId).HasColumnName("KesAuftragID");

                entity.Property(e => e.AbschlussDatum).HasColumnType("datetime");

                entity.Property(e => e.Anlass).IsUnicode(false);

                entity.Property(e => e.Auftrag).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumAuftrag).HasColumnType("datetime");

                entity.Property(e => e.DatumFrist).HasColumnType("datetime");

                entity.Property(e => e.DocumentIdAuftrag).HasColumnName("DocumentID_Auftrag");

                entity.Property(e => e.DocumentIdBeschlussRueckmeldung).HasColumnName("DocumentID_BeschlussRueckmeldung");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.IsKs).HasColumnName("IsKS");

                entity.Property(e => e.KesAuftragTs)
                    .IsRequired()
                    .HasColumnName("KesAuftragTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KesAuftrag)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KesAuftrag_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.KesAuftrag)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_KesAuftrag_XUser");
            });

            modelBuilder.Entity<KesAuftragBaPerson>(entity =>
            {
                entity.ToTable("KesAuftrag_BaPerson");

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.KesAuftragId);

                entity.HasIndex(e => new { e.BaPersonId, e.KesAuftragId })
                    .HasName("UK_KesAuftrag_BaPerson_BaPersonID_FaDokumentID")
                    .IsUnique();

                entity.HasIndex(e => new { e.KesAuftragId, e.BaPersonId });

                entity.Property(e => e.KesAuftragBaPersonId).HasColumnName("KesAuftrag_BaPersonID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KesAuftragBaPersonTs)
                    .IsRequired()
                    .HasColumnName("KesAuftrag_BaPersonTS")
                    .IsRowVersion();

                entity.Property(e => e.KesAuftragId).HasColumnName("KesAuftragID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.KesAuftragBaPerson)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KesAuftrag_BaPerson_BaPerson");

                entity.HasOne(d => d.KesAuftrag)
                    .WithMany(p => p.KesAuftragBaPerson)
                    .HasForeignKey(d => d.KesAuftragId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KesAuftrag_BaPerson_KesAuftrag");
            });

            modelBuilder.Entity<KesBehoerde>(entity =>
            {
                entity.Property(e => e.KesBehoerdeId).HasColumnName("KesBehoerdeID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Kanton)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KesBehoerdeTs)
                    .IsRequired()
                    .HasColumnName("KesBehoerdeTS")
                    .IsRowVersion();

                entity.Property(e => e.Kesbid)
                    .IsRequired()
                    .HasColumnName("KESBID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Kesbname)
                    .IsRequired()
                    .HasColumnName("KESBName")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KesDokument>(entity =>
            {
                entity.HasIndex(e => e.BaInstitutionIdAdressat);

                entity.HasIndex(e => e.BaPersonIdAdressat);

                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.KesAuftragId);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => e.XdocumentIdDokument);

                entity.HasIndex(e => e.XdocumentIdVersand);

                entity.Property(e => e.KesDokumentId).HasColumnName("KesDokumentID");

                entity.Property(e => e.BaInstitutionIdAdressat).HasColumnName("BaInstitutionID_Adressat");

                entity.Property(e => e.BaPersonIdAdressat).HasColumnName("BaPersonID_Adressat");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KesAuftragId).HasColumnName("KesAuftragID");

                entity.Property(e => e.KesDokumentTs)
                    .IsRequired()
                    .HasColumnName("KesDokumentTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stichwort).IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.XdocumentIdDokument).HasColumnName("XDocumentID_Dokument");

                entity.Property(e => e.XdocumentIdVersand).HasColumnName("XDocumentID_Versand");

                entity.HasOne(d => d.BaInstitutionIdAdressatNavigation)
                    .WithMany(p => p.KesDokument)
                    .HasForeignKey(d => d.BaInstitutionIdAdressat)
                    .HasConstraintName("FK_KesDokument_BaInstitution_Adressat");

                entity.HasOne(d => d.BaPersonIdAdressatNavigation)
                    .WithMany(p => p.KesDokument)
                    .HasForeignKey(d => d.BaPersonIdAdressat)
                    .HasConstraintName("FK_KesDokument_BaPerson_Adressat");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KesDokument)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_KesDokument_FaLeistung");

                entity.HasOne(d => d.KesAuftrag)
                    .WithMany(p => p.KesDokument)
                    .HasForeignKey(d => d.KesAuftragId)
                    .HasConstraintName("FK_KesDokument_KesAuftrag");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.KesDokument)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_KesDokument_XUser");
            });

            modelBuilder.Entity<KesMandatsfuehrendePerson>(entity =>
            {
                entity.HasIndex(e => e.KesMassnahmeId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.KesMandatsfuehrendePersonId).HasColumnName("KesMandatsfuehrendePersonID");

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumErnennungsurkunde).HasColumnType("datetime");

                entity.Property(e => e.DatumMandatBis).HasColumnType("datetime");

                entity.Property(e => e.DatumMandatVon).HasColumnType("datetime");

                entity.Property(e => e.DatumRechnungsfuehrungBis).HasColumnType("datetime");

                entity.Property(e => e.DatumRechnungsfuehrungVon).HasColumnType("datetime");

                entity.Property(e => e.DatumVorgeschlagenAm).HasColumnType("datetime");

                entity.Property(e => e.DocumentIdErnennungsurkunde).HasColumnName("DocumentID_Ernennungsurkunde");

                entity.Property(e => e.KesMandatsfuehrendePersonTs)
                    .IsRequired()
                    .HasColumnName("KesMandatsfuehrendePersonTS")
                    .IsRowVersion();

                entity.Property(e => e.KesMassnahmeId).HasColumnName("KesMassnahmeID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.KesMandatsfuehrendePerson)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .HasConstraintName("FK_KesMandatsfuehrendePerson_BaInstitution");

                entity.HasOne(d => d.KesMassnahme)
                    .WithMany(p => p.KesMandatsfuehrendePerson)
                    .HasForeignKey(d => d.KesMassnahmeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KesMandatsfuehrendePerson_KesMassnahme");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.KesMandatsfuehrendePerson)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_KesMandatsfuehrendePerson_XUser");
            });

            modelBuilder.Entity<KesMassnahme>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.PlatzierungBaInstitutionId);

                entity.HasIndex(e => e.UebernahmeVonKesBehoerdeId);

                entity.HasIndex(e => e.UebertragungAnKesBehoerdeId);

                entity.HasIndex(e => e.ZustaendigKesBehoerdeId);

                entity.Property(e => e.KesMassnahmeId).HasColumnName("KesMassnahmeID");

                entity.Property(e => e.AenderungVomDatum)
                    .HasColumnName("AenderungVom_Datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.Auftragstext).IsUnicode(false);

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.DocumentIdAufhebungsbeschluss).HasColumnName("DocumentID_Aufhebungsbeschluss");

                entity.Property(e => e.DocumentIdErrichtungsbeschluss).HasColumnName("DocumentID_Errichtungsbeschluss");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.IsKs).HasColumnName("IsKS");

                entity.Property(e => e.KesAufgabenbereichCodes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.KesElterlicheSorgeObhutCodeElterlicheSorge).HasColumnName("KesElterlicheSorgeObhutCode_ElterlicheSorge");

                entity.Property(e => e.KesElterlicheSorgeObhutCodeObhut).HasColumnName("KesElterlicheSorgeObhutCode_Obhut");

                entity.Property(e => e.KesIndikationCodes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.KesMassnahmeTs)
                    .IsRequired()
                    .HasColumnName("KesMassnahmeTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlatzierungBaInstitutionId).HasColumnName("Platzierung_BaInstitutionID");

                entity.Property(e => e.UebernahmeVonDatum)
                    .HasColumnName("UebernahmeVon_Datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.UebernahmeVonKanton)
                    .HasColumnName("UebernahmeVon_Kanton")
                    .IsUnicode(false);

                entity.Property(e => e.UebernahmeVonKesBehoerdeId).HasColumnName("UebernahmeVon_KesBehoerdeID");

                entity.Property(e => e.UebernahmeVonOrt)
                    .HasColumnName("UebernahmeVon_Ort")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UebernahmeVonOrtschaftCode).HasColumnName("UebernahmeVon_OrtschaftCode");

                entity.Property(e => e.UebernahmeVonPlz)
                    .HasColumnName("UebernahmeVon_PLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UebertragungAnDatum)
                    .HasColumnName("UebertragungAn_Datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.UebertragungAnKanton)
                    .HasColumnName("UebertragungAn_Kanton")
                    .IsUnicode(false);

                entity.Property(e => e.UebertragungAnKesBehoerdeId).HasColumnName("UebertragungAn_KesBehoerdeID");

                entity.Property(e => e.UebertragungAnOrt)
                    .HasColumnName("UebertragungAn_Ort")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UebertragungAnOrtschaftCode).HasColumnName("UebertragungAn_OrtschaftCode");

                entity.Property(e => e.UebertragungAnPlz)
                    .HasColumnName("UebertragungAn_PLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ZustaendigKesBehoerdeId).HasColumnName("Zustaendig_KesBehoerdeID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KesMassnahme)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KesMassnahme_FaLeistung");

                entity.HasOne(d => d.PlatzierungBaInstitution)
                    .WithMany(p => p.KesMassnahme)
                    .HasForeignKey(d => d.PlatzierungBaInstitutionId)
                    .HasConstraintName("FK_KesMassnahme_Platzierung_BaInstitutionID");

                entity.HasOne(d => d.UebernahmeVonKesBehoerde)
                    .WithMany(p => p.KesMassnahmeUebernahmeVonKesBehoerde)
                    .HasForeignKey(d => d.UebernahmeVonKesBehoerdeId);

                entity.HasOne(d => d.UebertragungAnKesBehoerde)
                    .WithMany(p => p.KesMassnahmeUebertragungAnKesBehoerde)
                    .HasForeignKey(d => d.UebertragungAnKesBehoerdeId);

                entity.HasOne(d => d.ZustaendigKesBehoerde)
                    .WithMany(p => p.KesMassnahmeZustaendigKesBehoerde)
                    .HasForeignKey(d => d.ZustaendigKesBehoerdeId);
            });

            modelBuilder.Entity<KesMassnahmeAuftrag>(entity =>
            {
                entity.HasIndex(e => e.KesMassnahmeId);

                entity.Property(e => e.KesMassnahmeAuftragId).HasColumnName("KesMassnahmeAuftragID");

                entity.Property(e => e.Auftrag).IsUnicode(false);

                entity.Property(e => e.BeschlussVom).HasColumnType("datetime");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumVerfuegungKesb)
                    .HasColumnName("DatumVerfuegungKESB")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatumVersand).HasColumnType("datetime");

                entity.Property(e => e.DocumentIdBericht).HasColumnName("DocumentID_Bericht");

                entity.Property(e => e.DocumentIdBeschluss).HasColumnName("DocumentID_Beschluss");

                entity.Property(e => e.DocumentIdVerfuegungKesb).HasColumnName("DocumentID_VerfuegungKESB");

                entity.Property(e => e.DocumentIdVersand).HasColumnName("DocumentID_Versand");

                entity.Property(e => e.ErledigungBis).HasColumnType("datetime");

                entity.Property(e => e.KesMassnahmeAuftragTs)
                    .IsRequired()
                    .HasColumnName("KesMassnahmeAuftragTS")
                    .IsRowVersion();

                entity.Property(e => e.KesMassnahmeId).HasColumnName("KesMassnahmeID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.KesMassnahme)
                    .WithMany(p => p.KesMassnahmeAuftrag)
                    .HasForeignKey(d => d.KesMassnahmeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KesMassnahmeAuftrag_KesMassnahme");
            });

            modelBuilder.Entity<KesMassnahmeBericht>(entity =>
            {
                entity.HasIndex(e => e.KesMassnahmeId);

                entity.Property(e => e.KesMassnahmeBerichtId).HasColumnName("KesMassnahmeBerichtID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBelegeZurueck).HasColumnType("datetime");

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVerfuegungKesb)
                    .HasColumnName("DatumVerfuegungKESB")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatumVersand).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.DocumentIdBericht).HasColumnName("DocumentID_Bericht");

                entity.Property(e => e.DocumentIdRechnung).HasColumnName("DocumentID_Rechnung");

                entity.Property(e => e.DocumentIdVerfuegungKesb).HasColumnName("DocumentID_VerfuegungKESB");

                entity.Property(e => e.DocumentIdVersand).HasColumnName("DocumentID_Versand");

                entity.Property(e => e.KesMassnahmeBerichtTs)
                    .IsRequired()
                    .HasColumnName("KesMassnahmeBerichtTS")
                    .IsRowVersion();

                entity.Property(e => e.KesMassnahmeId).HasColumnName("KesMassnahmeID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.KesMassnahme)
                    .WithMany(p => p.KesMassnahmeBericht)
                    .HasForeignKey(d => d.KesMassnahmeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KesMassnahmeBericht_KesMassnahme");
            });

            modelBuilder.Entity<KesMassnahmeBss>(entity =>
            {
                entity.ToTable("KesMassnahmeBSS");

                entity.HasIndex(e => e.BaInstitutionId)
                    .HasName("IX_KesMassnahmeBSS_Platzierung_BaInstitutionID");

                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.KesArtikelIdMassnahmegebundeneGeschaefte);

                entity.HasIndex(e => e.KesArtikelIdNichtMassnahmegebundeneGeschaefte);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => e.VmPriMaId);

                entity.Property(e => e.KesMassnahmeBssid).HasColumnName("KesMassnahmeBSSID");

                entity.Property(e => e.AenderungVom).HasColumnType("datetime");

                entity.Property(e => e.AufhebungVom).HasColumnType("datetime");

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.Beistandswechsel).HasColumnType("datetime");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.BerichtsgenehmigungVom).HasColumnType("datetime");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentIdUrkunde).HasColumnName("DocumentID_Urkunde");

                entity.Property(e => e.ErrichtungVom).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Kanton)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.KesArtikelIdMassnahmegebundeneGeschaefte).HasColumnName("KesArtikelID_MassnahmegebundeneGeschaefte");

                entity.Property(e => e.KesArtikelIdNichtMassnahmegebundeneGeschaefte).HasColumnName("KesArtikelID_NichtMassnahmegebundeneGeschaefte");

                entity.Property(e => e.KesAufgabenbereichCodes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.KesElterlicheSorgeObhutCodeElterlicheSorge).HasColumnName("KesElterlicheSorgeObhutCode_ElterlicheSorge");

                entity.Property(e => e.KesElterlicheSorgeObhutCodeObhut).HasColumnName("KesElterlicheSorgeObhutCode_Obhut");

                entity.Property(e => e.KesIndikationCodes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.KesMassnahmeBssts)
                    .IsRequired()
                    .HasColumnName("KesMassnahmeBSSTS")
                    .IsRowVersion();

                entity.Property(e => e.KesbdocumentId).HasColumnName("KESBDocumentID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ort)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlatzierungBaInstitutionId).HasColumnName("Platzierung_BaInstitutionID");

                entity.Property(e => e.Plz)
                    .HasColumnName("PLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UebernahmeVom).HasColumnType("datetime");

                entity.Property(e => e.UebertragungVom).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VmPriMaId).HasColumnName("VmPriMaID");

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.KesMassnahmeBssBaInstitution)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .HasConstraintName("FK_KesMassnahmeBSS_BaInstitution");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KesMassnahmeBss)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KesMassnahmeBSS_FaLeistung");

                entity.HasOne(d => d.KesArtikelIdMassnahmegebundeneGeschaefteNavigation)
                    .WithMany(p => p.KesMassnahmeBssKesArtikelIdMassnahmegebundeneGeschaefteNavigation)
                    .HasForeignKey(d => d.KesArtikelIdMassnahmegebundeneGeschaefte)
                    .HasConstraintName("FK_KesMassnahmeBSS_KesArtikel_Massnahmegebunden");

                entity.HasOne(d => d.KesArtikelIdNichtMassnahmegebundeneGeschaefteNavigation)
                    .WithMany(p => p.KesMassnahmeBssKesArtikelIdNichtMassnahmegebundeneGeschaefteNavigation)
                    .HasForeignKey(d => d.KesArtikelIdNichtMassnahmegebundeneGeschaefte)
                    .HasConstraintName("FK_KesMassnahmeBSS_KesArtikel_NichtMassnahmegebunden");

                entity.HasOne(d => d.PlatzierungBaInstitution)
                    .WithMany(p => p.KesMassnahmeBssPlatzierungBaInstitution)
                    .HasForeignKey(d => d.PlatzierungBaInstitutionId)
                    .HasConstraintName("FK_KesMassnahmeBSS_Platzierung_BaInstitution");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.KesMassnahmeBss)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_KesMassnahmeBSS_XUser");

                entity.HasOne(d => d.VmPriMa)
                    .WithMany(p => p.KesMassnahmeBss)
                    .HasForeignKey(d => d.VmPriMaId)
                    .HasConstraintName("FK_KesMassnahmeBSS_VmPriMa");
            });

            modelBuilder.Entity<KesMassnahmeKesArtikel>(entity =>
            {
                entity.ToTable("KesMassnahme_KesArtikel");

                entity.HasIndex(e => e.KesArtikelId);

                entity.HasIndex(e => e.KesMassnahmeId);

                entity.HasIndex(e => new { e.KesMassnahmeId, e.KesArtikelId });

                entity.Property(e => e.KesMassnahmeKesArtikelId).HasColumnName("KesMassnahme_KesArtikelID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KesArtikelId).HasColumnName("KesArtikelID");

                entity.Property(e => e.KesMassnahmeId).HasColumnName("KesMassnahmeID");

                entity.Property(e => e.KesMassnahmeKesArtikelTs)
                    .IsRequired()
                    .HasColumnName("KesMassnahme_KesArtikelTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.KesArtikel)
                    .WithMany(p => p.KesMassnahmeKesArtikel)
                    .HasForeignKey(d => d.KesArtikelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KesMassnahme_KesArtikel_KesArtikel");

                entity.HasOne(d => d.KesMassnahme)
                    .WithMany(p => p.KesMassnahmeKesArtikel)
                    .HasForeignKey(d => d.KesMassnahmeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KesMassnahme_KesArtikel_KesMassnahme");
            });

            modelBuilder.Entity<KesPflegekinderaufsicht>(entity =>
            {
                entity.HasIndex(e => e.BaInstitutionId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.KesPflegekinderaufsichtId).HasColumnName("KesPflegekinderaufsichtID");

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KesPflegekinderaufsichtTs)
                    .IsRequired()
                    .HasColumnName("KesPflegekinderaufsichtTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.KesPflegekinderaufsicht)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .HasConstraintName("FK_KesPflegekinderaufsicht_BaInstitution");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KesPflegekinderaufsicht)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KesPflegekinderaufsicht_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.KesPflegekinderaufsicht)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_KesPflegekinderaufsicht_XUser");
            });

            modelBuilder.Entity<KesPraevention>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.KesPraeventionId).HasColumnName("KesPraeventionID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KesPraeventionTs)
                    .IsRequired()
                    .HasColumnName("KesPraeventionTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KesPraevention)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KesPraevention_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.KesPraevention)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_KesPraevention_XUser");
            });

            modelBuilder.Entity<KesVerlauf>(entity =>
            {
                entity.HasIndex(e => e.BaInstitutionIdAdressat);

                entity.HasIndex(e => e.BaPersonIdAdressat);

                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.KesVerlaufId).HasColumnName("KesVerlaufID");

                entity.Property(e => e.BaInstitutionIdAdressat).HasColumnName("BaInstitutionID_Adressat");

                entity.Property(e => e.BaPersonIdAdressat).HasColumnName("BaPersonID_Adressat");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Inhalt).IsUnicode(false);

                entity.Property(e => e.KesVerlaufTs)
                    .IsRequired()
                    .HasColumnName("KesVerlaufTS")
                    .IsRowVersion();

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stichwort).IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.BaInstitutionIdAdressatNavigation)
                    .WithMany(p => p.KesVerlauf)
                    .HasForeignKey(d => d.BaInstitutionIdAdressat)
                    .HasConstraintName("FK_KesVerlauf_BaInstitution");

                entity.HasOne(d => d.BaPersonIdAdressatNavigation)
                    .WithMany(p => p.KesVerlauf)
                    .HasForeignKey(d => d.BaPersonIdAdressat)
                    .HasConstraintName("FK_KesVerlauf_BaPerson");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.KesVerlauf)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KesVerlauf_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.KesVerlauf)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_KesVerlauf_XUser");
            });

            modelBuilder.Entity<MigAssignment>(entity =>
            {
                entity.HasKey(e => new { e.Lookup, e.OldValue });

                entity.Property(e => e.Lookup)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OldValue)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MigAssignmentTs)
                    .IsRequired()
                    .HasColumnName("MigAssignmentTS")
                    .IsRowVersion();

                entity.Property(e => e.NewValue)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MigLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Column)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DurationMs).HasColumnName("Duration_ms");

                entity.Property(e => e.Error)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Function)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MigLogTs)
                    .IsRequired()
                    .HasColumnName("MigLogTS")
                    .IsRowVersion();

                entity.Property(e => e.Prms)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Table)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Time)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MigLookup>(entity =>
            {
                entity.HasKey(e => new { e.Lookup, e.RowId });

                entity.Property(e => e.Lookup)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RowId).HasColumnName("RowID");

                entity.Property(e => e.MigLookupTs)
                    .IsRequired()
                    .HasColumnName("MigLookupTS")
                    .IsRowVersion();

                entity.Property(e => e.Value).IsUnicode(false);
            });

            modelBuilder.Entity<MigVmPriMaToBaInstitution>(entity =>
            {
                entity.ToTable("_Mig_VmPriMa_To_BaInstitution");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VmPriMaId).HasColumnName("VmPriMaID");
            });

            modelBuilder.Entity<NewodPerson>(entity =>
            {
                entity.Property(e => e.NewodPersonId)
                    .HasColumnName("NewodPersonID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ahvnummer)
                    .IsRequired()
                    .HasColumnName("AHVNummer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Geburtsdatum).HasColumnType("datetime");

                entity.Property(e => e.GeburtsdatumString)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HausNr)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HausNrZusatz)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ort)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Plz)
                    .IsRequired()
                    .HasColumnName("PLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Strasse)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Versichertennummer)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Vorname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ServiceCall>(entity =>
            {
                entity.ToTable("ServiceCall", "log");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.ServiceCallId).HasColumnName("ServiceCallID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Info).IsUnicode(false);

                entity.Property(e => e.MachineName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MethodName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceCallTs)
                    .IsRequired()
                    .HasColumnName("ServiceCallTS")
                    .IsRowVersion();

                entity.Property(e => e.ServiceEnd).HasColumnType("datetime");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceParam).IsUnicode(false);

                entity.Property(e => e.ServiceStart).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ServiceCall)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ServiceCall_XUser");
            });

            modelBuilder.Entity<ServiceProcessError>(entity =>
            {
                entity.ToTable("ServiceProcessError", "log");

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.ServiceProcessErrorId).HasColumnName("ServiceProcessErrorID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FremdsystemId)
                    .HasColumnName("FremdsystemID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Info).IsUnicode(false);

                entity.Property(e => e.MethodName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceProcessErrorTs)
                    .IsRequired()
                    .HasColumnName("ServiceProcessErrorTS")
                    .IsRowVersion();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.ServiceProcessError)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_ServiceProcessError_BaPerson");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ServiceProcessError)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ServiceProcessError_XUser");
            });

            modelBuilder.Entity<ServiceProcessErrorMessage>(entity =>
            {
                entity.ToTable("ServiceProcessErrorMessage", "log");

                entity.HasIndex(e => e.ServiceProcessErrorId);

                entity.Property(e => e.ServiceProcessErrorMessageId).HasColumnName("ServiceProcessErrorMessageID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceProcessErrorId).HasColumnName("ServiceProcessErrorID");

                entity.Property(e => e.ServiceProcessErrorMessageTs)
                    .IsRequired()
                    .HasColumnName("ServiceProcessErrorMessageTS")
                    .IsRowVersion();

                entity.HasOne(d => d.ServiceProcessError)
                    .WithMany(p => p.ServiceProcessErrorMessage)
                    .HasForeignKey(d => d.ServiceProcessErrorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProcessErrorMessage_ServiceProcessError");
            });

            modelBuilder.Entity<ShEinzelzahlung>(entity =>
            {
                entity.HasIndex(e => e.BgBudgetId)
                    .HasName("IX_ShEinzelzahlung")
                    .ForSqlServerIsClustered();

                entity.HasIndex(e => e.BgSpezkontoId)
                    .HasName("IX_ShEinzelzahlung_ShSpezkontoID");

                entity.Property(e => e.ShEinzelzahlungId).HasColumnName("ShEinzelzahlungID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).HasColumnType("text");

                entity.Property(e => e.Betrag)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BetragAnfrage).HasColumnType("money");

                entity.Property(e => e.BgBudgetId).HasColumnName("BgBudgetID");

                entity.Property(e => e.BgPositionsartId).HasColumnName("BgPositionsartID");

                entity.Property(e => e.BgSpezkontoId).HasColumnName("BgSpezkontoID");

                entity.Property(e => e.FlKostenartId).HasColumnName("FlKostenartID");

                entity.Property(e => e.NameEinzelzahlung)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RechnungDatum).HasColumnType("datetime");

                entity.Property(e => e.ShBelegId).HasColumnName("ShBelegID");

                entity.Property(e => e.ShEinzelzahlungTs)
                    .IsRequired()
                    .HasColumnName("ShEinzelzahlungTS")
                    .IsRowVersion();

                entity.Property(e => e.ShStatusEinzelzahlungCode).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.ShEinzelzahlung)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_ShEinzelzahlung_BaPerson");

                entity.HasOne(d => d.BgBudget)
                    .WithMany(p => p.ShEinzelzahlung)
                    .HasForeignKey(d => d.BgBudgetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShEinzelzahlung_BgBudget");

                entity.HasOne(d => d.BgPositionsart)
                    .WithMany(p => p.ShEinzelzahlung)
                    .HasForeignKey(d => d.BgPositionsartId)
                    .HasConstraintName("FK_ShEinzelzahlung_BgPositionsart");

                entity.HasOne(d => d.BgSpezkonto)
                    .WithMany(p => p.ShEinzelzahlung)
                    .HasForeignKey(d => d.BgSpezkontoId)
                    .HasConstraintName("FK_ShEinzelzahlung_BgSpezkonto");
            });

            modelBuilder.Entity<SstAsvsexport>(entity =>
            {
                entity.ToTable("SstASVSExport");

                entity.Property(e => e.SstAsvsexportId).HasColumnName("SstASVSExportID");

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumExport).HasColumnType("datetime");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.Modified)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SstAsvsexportTs)
                    .IsRequired()
                    .HasColumnName("SstASVSExportTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<SstAsvsexportEintrag>(entity =>
            {
                entity.ToTable("SstASVSExport_Eintrag");

                entity.HasIndex(e => e.SstAsvsexportId)
                    .HasName("IX_SstASVSExport_SstASVSExport");

                entity.HasIndex(e => e.WhAsvseintragId)
                    .HasName("IX_SstASVSExport_WhASVSEintrag");

                entity.Property(e => e.SstAsvsexportEintragId).HasColumnName("SstASVSExport_EintragID");

                entity.Property(e => e.AsvsexportCode).HasColumnName("ASVSExportCode");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SstAsvsexportEintragTs)
                    .IsRequired()
                    .HasColumnName("SstASVSExport_EintragTS")
                    .IsRowVersion();

                entity.Property(e => e.SstAsvsexportId).HasColumnName("SstASVSExportID");

                entity.Property(e => e.WhAsvseintragId).HasColumnName("WhASVSEintragID");

                entity.HasOne(d => d.SstAsvsexport)
                    .WithMany(p => p.SstAsvsexportEintrag)
                    .HasForeignKey(d => d.SstAsvsexportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WhASVSEintrag_Eintrag_SstASVSExport");

                entity.HasOne(d => d.WhAsvseintrag)
                    .WithMany(p => p.SstAsvsexportEintrag)
                    .HasForeignKey(d => d.WhAsvseintragId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WhASVSEintrag_Eintrag_WhASVSEintrag");
            });

            modelBuilder.Entity<SstNewodMapping>(entity =>
            {
                entity.HasKey(e => e.NewodMappingId);

                entity.Property(e => e.NewodMappingId).HasColumnName("NewodMappingID");

                entity.Property(e => e.Attribut)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KissWert)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NewodAttribut).HasMaxLength(50);

                entity.Property(e => e.NewodWert)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SstNewodMutation>(entity =>
            {
                entity.HasKey(e => e.NewodMutationId);

                entity.Property(e => e.NewodMutationId).HasColumnName("NewodMutationID");

                entity.Property(e => e.Data).IsUnicode(false);

                entity.Property(e => e.DatumVon)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Imported)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Mutationsart)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserSession>(entity =>
            {
                entity.ToTable("UserSession", "log");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserSessionId).HasColumnName("UserSessionID");

                entity.Property(e => e.ClientVersion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CultureInfo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DotNetVersion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoginDatum).HasColumnType("datetime");

                entity.Property(e => e.LogonName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LogoutDatum).HasColumnType("datetime");

                entity.Property(e => e.MachineName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfficeVersionExcel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfficeVersionOutlook)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfficeVersionWord)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserDomainName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserSessionTs)
                    .IsRequired()
                    .HasColumnName("UserSessionTS")
                    .IsRowVersion();

                entity.Property(e => e.WindowsVersion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSession)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSession_XUser");
            });

            modelBuilder.Entity<VmAhvmindestbeitrag>(entity =>
            {
                entity.ToTable("VmAHVMindestbeitrag");

                entity.HasIndex(e => e.DocumentIdIkauszug);

                entity.HasIndex(e => e.DocumentIdNeanmeldung);

                entity.HasIndex(e => e.DocumentIdNeutral);

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.VmAhvmindestbeitragId).HasColumnName("VmAHVMindestbeitragID");

                entity.Property(e => e.BeitragsRechnungsJahr)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Bemerkungen).IsUnicode(false);

                entity.Property(e => e.Bruttolohn).HasColumnType("money");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DocumentIdIkauszug).HasColumnName("DocumentID_IKAuszug");

                entity.Property(e => e.DocumentIdNeanmeldung).HasColumnName("DocumentID_NEAnmeldung");

                entity.Property(e => e.DocumentIdNeutral).HasColumnName("DocumentID_Neutral");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.IkauszugDatum)
                    .HasColumnName("IKAuszugDatum")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NeanmeldungDatum)
                    .HasColumnName("NEAnmeldungDatum")
                    .HasColumnType("datetime");

                entity.Property(e => e.VmAhvmindestbeitragTs)
                    .IsRequired()
                    .HasColumnName("VmAHVMindestbeitragTS")
                    .IsRowVersion();

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmAhvmindestbeitrag)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmAHVMindestbeitrag_FaLeistung");
            });

            modelBuilder.Entity<VmAntragEksk>(entity =>
            {
                entity.ToTable("VmAntragEKSK");

                entity.HasIndex(e => e.DocumentId);

                entity.HasIndex(e => e.FaLeistungId)
                    .HasName("IX_VmAntragEKSK_FaLeistungsID");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_VmAntragEKSK_UserId");

                entity.Property(e => e.VmAntragEkskid).HasColumnName("VmAntragEKSKID");

                entity.Property(e => e.Antrag).IsUnicode(false);

                entity.Property(e => e.Begruendung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumAntrag).HasColumnType("datetime");

                entity.Property(e => e.DatumGenehmigtEksk)
                    .HasColumnName("DatumGenehmigtEKSK")
                    .HasColumnType("datetime");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VmAntragEkskts)
                    .IsRequired()
                    .HasColumnName("VmAntragEKSKTS")
                    .IsRowVersion();

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmAntragEksk)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmAntragEKSK_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VmAntragEksk)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_VmAntragEKSK_XUser");
            });

            modelBuilder.Entity<VmBericht>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.VmBerichtId).HasColumnName("VmBerichtID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.BerichtsperiodeBis).HasColumnType("datetime");

                entity.Property(e => e.BerichtsperiodeVon).HasColumnType("datetime");

                entity.Property(e => e.Entschaedigung).HasColumnType("money");

                entity.Property(e => e.Erstellung).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Mahnung).HasColumnType("datetime");

                entity.Property(e => e.Mahnung2).HasColumnType("datetime");

                entity.Property(e => e.Passation1).HasColumnType("datetime");

                entity.Property(e => e.Passation2).HasColumnType("datetime");

                entity.Property(e => e.Versand).HasColumnType("datetime");

                entity.Property(e => e.VmBerichtTs)
                    .IsRequired()
                    .HasColumnName("VmBerichtTS")
                    .IsRowVersion();

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmBericht)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmBericht_FaLeistung");
            });

            modelBuilder.Entity<VmBeschwerdeAnfrage>(entity =>
            {
                entity.HasIndex(e => e.DocumentId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.VmBeschwerdeAnfrageId).HasColumnName("VmBeschwerdeAnfrageID");

                entity.Property(e => e.Abschluss).HasColumnType("datetime");

                entity.Property(e => e.Absender)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.Eingang).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stichworte).IsUnicode(false);

                entity.Property(e => e.VmBeschwerdeAnfrageTs)
                    .IsRequired()
                    .HasColumnName("VmBeschwerdeAnfrageTS")
                    .IsRowVersion();

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmBeschwerdeAnfrage)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmBeschwerdeAnfrage_FaLeistung");
            });

            modelBuilder.Entity<VmBewertung>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.VmBewertungId).HasColumnName("VmBewertungID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.ProduktId).HasColumnName("ProduktID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VmBewertungTs)
                    .IsRequired()
                    .HasColumnName("VmBewertungTS")
                    .IsRowVersion();

                entity.Property(e => e.VmFallgewichtungJahr).HasDefaultValueSql("((1))");

                entity.Property(e => e.VmFallgewichtungStichtagCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.VmKriterienCodes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VmKriterienListe)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmBewertung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_VmBewertung_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VmBewertung)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_VmBewertung_XUser");
            });

            modelBuilder.Entity<VmBudget>(entity =>
            {
                entity.HasIndex(e => e.DocumentId);

                entity.HasIndex(e => e.FaLeistungId)
                    .HasName("IX_VmBudget_FaLeistungsID");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.VmBudgetId).HasColumnName("VmBudgetID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumErstellung).HasColumnType("datetime");

                entity.Property(e => e.DatumMutation).HasColumnType("datetime");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Grund)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stichworte)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VmBudgetTs)
                    .IsRequired()
                    .HasColumnName("VmBudgetTS")
                    .IsRowVersion();

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmBudget)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmBudget_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VmBudget)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_VmBudget_XUser");
            });

            modelBuilder.Entity<VmElkrankheitskosten>(entity =>
            {
                entity.ToTable("VmELKrankheitskosten");

                entity.HasIndex(e => e.DocumentId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.VmElkrankheitskostenId)
                    .HasColumnName("VmELKrankheitskostenID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AbrechnungenBis).HasColumnType("datetime");

                entity.Property(e => e.AbrechnungenVom).HasColumnType("datetime");

                entity.Property(e => e.Bemerkungen).IsUnicode(false);

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.Eingereicht).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VerfuegungLeistung).HasColumnType("money");

                entity.Property(e => e.VerfuegungVom).HasColumnType("datetime");

                entity.Property(e => e.VmElkrankheitskostenTs)
                    .IsRequired()
                    .HasColumnName("VmELKrankheitskostenTS")
                    .IsRowVersion();

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmElkrankheitskosten)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmELKrankheitskosten_FaLeistung");

                entity.HasOne(d => d.VmElkrankheitskostenNavigation)
                    .WithOne(p => p.InverseVmElkrankheitskostenNavigation)
                    .HasForeignKey<VmElkrankheitskosten>(d => d.VmElkrankheitskostenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmELKrankheitskosten_VmELKrankheitskosten");
            });

            modelBuilder.Entity<VmErbe>(entity =>
            {
                entity.HasIndex(e => e.VmErbschaftsdienstId);

                entity.HasIndex(e => e.VmSiegelungId);

                entity.HasIndex(e => e.VmTestamentId);

                entity.Property(e => e.VmErbeId).HasColumnName("VmErbeID");

                entity.Property(e => e.Anrede)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.ErbCodierung)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ergaenzung)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.FamilienNamen)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Geburtsdatum)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.KontaktAdresse)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Land)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ort)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Strasse)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TestamentEroeffnungStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TestamentEroeffnungVersandDatum).HasColumnType("datetime");

                entity.Property(e => e.TestamentEroeffnungVersandart)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Titel2)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VmErbeTs)
                    .IsRequired()
                    .HasColumnName("VmErbeTS")
                    .IsRowVersion();

                entity.Property(e => e.VmErbschaftsdienstId).HasColumnName("VmErbschaftsdienstID");

                entity.Property(e => e.VmSiegelungId).HasColumnName("VmSiegelungID");

                entity.Property(e => e.VmTestamentId).HasColumnName("VmTestamentID");

                entity.Property(e => e.Vornamen)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Zusatz)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.VmErbschaftsdienst)
                    .WithMany(p => p.VmErbe)
                    .HasForeignKey(d => d.VmErbschaftsdienstId)
                    .HasConstraintName("FK_VmErbe_VmErbschaftsdienst");

                entity.HasOne(d => d.VmSiegelung)
                    .WithMany(p => p.VmErbe)
                    .HasForeignKey(d => d.VmSiegelungId)
                    .HasConstraintName("FK_VmErbe_VmSiegelung");

                entity.HasOne(d => d.VmTestament)
                    .WithMany(p => p.VmErbe)
                    .HasForeignKey(d => d.VmTestamentId)
                    .HasConstraintName("FK_VmErbe_VmTestament");
            });

            modelBuilder.Entity<VmErblasser>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.VmErblasserId).HasColumnName("VmErblasserID");

                entity.Property(e => e.Ahvnummer)
                    .HasColumnName("AHVNummer")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Anrede)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Aufenthalt)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Elternnamen)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FamilienNamen)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Geburtsdatum)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Heimatorte)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.LedigName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ort)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Strasse)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TodesDatum).HasColumnType("datetime");

                entity.Property(e => e.TodesDatumText)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TodesOrt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Versichertennummer)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.VmErblasserTs)
                    .IsRequired()
                    .HasColumnName("VmErblasserTS")
                    .IsRowVersion();

                entity.Property(e => e.Vornamen)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Zivilstand)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmErblasser)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_VmErblasser_FaLeistung");
            });

            modelBuilder.Entity<VmErbschaftsdienst>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.VmErbschaftsdienstId).HasColumnName("VmErbschaftsdienstID");

                entity.Property(e => e.AnschriftErbenDatum).HasColumnType("datetime");

                entity.Property(e => e.AnschriftErbenDokId).HasColumnName("AnschriftErbenDokID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.InventarNotarId).HasColumnName("InventarNotarID");

                entity.Property(e => e.KopieAnCodes)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Massnahme).IsUnicode(false);

                entity.Property(e => e.MassnahmenCodes)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UeberweisungRsta)
                    .HasColumnName("UeberweisungRSTA")
                    .HasColumnType("datetime");

                entity.Property(e => e.UeberweisungRstadokId).HasColumnName("UeberweisungRSTADokID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VmErbschaftsdienstTs)
                    .IsRequired()
                    .HasColumnName("VmErbschaftsdienstTS")
                    .IsRowVersion();

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmErbschaftsdienst)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_VmErbschaftsdienst_FaLeistung");

                entity.HasOne(d => d.InventarNotar)
                    .WithMany(p => p.VmErbschaftsdienst)
                    .HasForeignKey(d => d.InventarNotarId)
                    .HasConstraintName("FK_VmErbschaftsdienst_BaInstitution");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VmErbschaftsdienst)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_VmErbschaftsdienst_XUser");
            });

            modelBuilder.Entity<VmErnennung>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => e.VmMassnahmeId);

                entity.HasIndex(e => e.VmPriMaId);

                entity.Property(e => e.VmErnennungId).HasColumnName("VmErnennungID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ernennung).HasColumnType("datetime");

                entity.Property(e => e.ErnennungsurkundeDokId).HasColumnName("ErnennungsurkundeDokID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VmErnennungTs)
                    .IsRequired()
                    .HasColumnName("VmErnennungTS")
                    .IsRowVersion();

                entity.Property(e => e.VmMassnahmeId).HasColumnName("VmMassnahmeID");

                entity.Property(e => e.VmPriMaId).HasColumnName("VmPriMaID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VmErnennung)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_VmErnennung_XUser");

                entity.HasOne(d => d.VmMassnahme)
                    .WithMany(p => p.VmErnennung)
                    .HasForeignKey(d => d.VmMassnahmeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmErnennung_VmMassnahme");

                entity.HasOne(d => d.VmPriMa)
                    .WithMany(p => p.VmErnennung)
                    .HasForeignKey(d => d.VmPriMaId)
                    .HasConstraintName("FK_VmErnennung_VmPriMa");
            });

            modelBuilder.Entity<VmGefaehrdungsMeldung>(entity =>
            {
                entity.HasIndex(e => e.DocumentId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.VmGefaehrdungsMeldungId).HasColumnName("VmGefaehrdungsMeldungID");

                entity.Property(e => e.AuflageDatum).HasColumnType("datetime");

                entity.Property(e => e.Auflagen).IsUnicode(false);

                entity.Property(e => e.Ausgangslage).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumEingang).HasColumnType("datetime");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FaThemaCodes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Konsequenzen).IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ueberpruefung).IsUnicode(false);

                entity.Property(e => e.VmGefaehrdungNsbcodes)
                    .HasColumnName("VmGefaehrdungNSBCodes")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VmGefaehrdungsMeldungTs)
                    .IsRequired()
                    .HasColumnName("VmGefaehrdungsMeldungTS")
                    .IsRowVersion();

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmGefaehrdungsMeldung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmGefaehrdungsMeldung_FaLeistung");
            });

            modelBuilder.Entity<VmInventar>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.VmInventarId).HasColumnName("VmInventarID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.Eroeffnung).HasColumnType("datetime");

                entity.Property(e => e.ErstKontakt).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Genehmigung).HasColumnType("datetime");

                entity.Property(e => e.InventarAufgenommen).HasColumnType("datetime");

                entity.Property(e => e.Mahnung).HasColumnType("datetime");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Versand).HasColumnType("datetime");

                entity.Property(e => e.VmInventarTs)
                    .IsRequired()
                    .HasColumnName("VmInventarTS")
                    .IsRowVersion();

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmInventar)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmInventar_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VmInventar)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_VmInventar_XUser");
            });

            modelBuilder.Entity<VmKlientenbudget>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.VmKlientenbudgetId).HasColumnName("VmKlientenbudgetID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.GueltigAb).HasColumnType("datetime");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VmKlientenbudgetTs)
                    .IsRequired()
                    .HasColumnName("VmKlientenbudgetTS")
                    .IsRowVersion();

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmKlientenbudget)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmKlientenbudget_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VmKlientenbudget)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmKlientenbudget_XUser");
            });

            modelBuilder.Entity<VmMandant>(entity =>
            {
                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.VmMandantId).HasColumnName("VmMandantID");

                entity.Property(e => e.Ahvnummer)
                    .HasColumnName("AHVNummer")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Beruf)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Geburtsdatum).HasColumnType("datetime");

                entity.Property(e => e.HeimatgemeindeBaGemeindeId).HasColumnName("HeimatgemeindeBaGemeindeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Versichertennummer)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.VmMandantTs)
                    .IsRequired()
                    .HasColumnName("VmMandantTS")
                    .IsRowVersion();

                entity.Property(e => e.Vorname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WertschriftenDepot)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.VmMandant)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmMandant_BaPerson");

                entity.HasOne(d => d.HeimatgemeindeBaGemeinde)
                    .WithMany(p => p.VmMandant)
                    .HasForeignKey(d => d.HeimatgemeindeBaGemeindeId)
                    .HasConstraintName("FK_VmMandant_BaGemeinde");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VmMandant)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_VmMandant_XUser");
            });

            modelBuilder.Entity<VmMandBericht>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_VmMandBericht_UserId");

                entity.HasIndex(e => e.VmBerichtId);

                entity.Property(e => e.VmMandBerichtId).HasColumnName("VmMandBerichtID");

                entity.Property(e => e.AntragBegruendung).IsUnicode(false);

                entity.Property(e => e.AuftragZielsetzungText).IsUnicode(false);

                entity.Property(e => e.Begruendung).IsUnicode(false);

                entity.Property(e => e.BelastungAdminText).IsUnicode(false);

                entity.Property(e => e.BelastungMandatText).IsUnicode(false);

                entity.Property(e => e.BelegeZurueckRevision).HasColumnType("datetime");

                entity.Property(e => e.BerichtDatumBis).HasColumnType("datetime");

                entity.Property(e => e.BerichtDatumVon).HasColumnType("datetime");

                entity.Property(e => e.BesondereAngabenBemerkungen).IsUnicode(false);

                entity.Property(e => e.BesondereRessourcenText).IsUnicode(false);

                entity.Property(e => e.BesondereSchwierigkeitenText).IsUnicode(false);

                entity.Property(e => e.BsDatum).HasColumnType("datetime");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.DritteText).IsUnicode(false);

                entity.Property(e => e.EinnahmenBemerkungen).IsUnicode(false);

                entity.Property(e => e.ErstellungDatum).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FamSituationText).IsUnicode(false);

                entity.Property(e => e.FreizeitText).IsUnicode(false);

                entity.Property(e => e.GesundheitText).IsUnicode(false);

                entity.Property(e => e.GrundMassnahmeText).IsUnicode(false);

                entity.Property(e => e.HandlungenText).IsUnicode(false);

                entity.Property(e => e.InstitutionenText).IsUnicode(false);

                entity.Property(e => e.KlientText).IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NeueZieleText).IsUnicode(false);

                entity.Property(e => e.PassationBemerkung).IsUnicode(false);

                entity.Property(e => e.SozialeKompetenzenText).IsUnicode(false);

                entity.Property(e => e.TaetigkeitText).IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VerhaltenText).IsUnicode(false);

                entity.Property(e => e.VersicherungenBemerkungen).IsUnicode(false);

                entity.Property(e => e.VmBerichtBelastungsangabeMcsccodeAdmin).HasColumnName("VmBerichtBelastungsangabeMCSCCode_Admin");

                entity.Property(e => e.VmBerichtBelastungsangabeMcsccodeMandat).HasColumnName("VmBerichtBelastungsangabeMCSCCode_Mandat");

                entity.Property(e => e.VmBerichtBesondereAngabenCodes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VmBerichtId).HasColumnName("VmBerichtID");

                entity.Property(e => e.VmBerichtVersicherungenCodes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VmEinnahmenAngabenCodes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VmMandBerichtTs)
                    .IsRequired()
                    .HasColumnName("VmMandBerichtTS")
                    .IsRowVersion();

                entity.Property(e => e.WohnenText).IsUnicode(false);

                entity.Property(e => e.ZurueckVomBs)
                    .HasColumnName("ZurueckVomBS")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmMandBericht)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmMandBericht_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VmMandBericht)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_VmMandBericht_XUser");

                entity.HasOne(d => d.VmBericht)
                    .WithMany(p => p.VmMandBericht)
                    .HasForeignKey(d => d.VmBerichtId)
                    .HasConstraintName("FK_VmMandBericht_VmBericht");
            });

            modelBuilder.Entity<VmMassnahme>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.VmMassnahmeId).HasColumnName("VmMassnahmeID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VmMassnahmeTs)
                    .IsRequired()
                    .HasColumnName("VmMassnahmeTS")
                    .IsRowVersion();

                entity.Property(e => e.WeitereZgb)
                    .HasColumnName("WeitereZGB")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Zgbcodes)
                    .HasColumnName("ZGBCodes")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmMassnahme)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmMassnahme_FaLeistung");
            });

            modelBuilder.Entity<VmPosition>(entity =>
            {
                entity.HasIndex(e => e.VmKlientenbudgetId);

                entity.HasIndex(e => e.VmPositionsartId);

                entity.Property(e => e.VmPositionId).HasColumnName("VmPositionID");

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.BetragJaehrlich).HasColumnType("money");

                entity.Property(e => e.BetragMonatlich).HasColumnType("money");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumSaldoPer).HasColumnType("datetime");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Saldo).HasColumnType("money");

                entity.Property(e => e.VmKlientenbudgetId).HasColumnName("VmKlientenbudgetID");

                entity.Property(e => e.VmPositionTs)
                    .IsRequired()
                    .HasColumnName("VmPositionTS")
                    .IsRowVersion();

                entity.Property(e => e.VmPositionsartId).HasColumnName("VmPositionsartID");

                entity.HasOne(d => d.VmKlientenbudget)
                    .WithMany(p => p.VmPosition)
                    .HasForeignKey(d => d.VmKlientenbudgetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmPosition_VmKlientenbudget");

                entity.HasOne(d => d.VmPositionsart)
                    .WithMany(p => p.VmPosition)
                    .HasForeignKey(d => d.VmPositionsartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmPosition_VmPositionsart");
            });

            modelBuilder.Entity<VmPositionsart>(entity =>
            {
                entity.Property(e => e.VmPositionsartId).HasColumnName("VmPositionsartID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VmPositionsartTs)
                    .IsRequired()
                    .HasColumnName("VmPositionsartTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<VmPriMa>(entity =>
            {
                entity.Property(e => e.VmPriMaId).HasColumnName("VmPriMaID");

                entity.Property(e => e.Ahvnummer)
                    .HasColumnName("AHVNummer")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.BankKontoNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.Beruf)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Geburtsdatum).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.MobilTel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonG)
                    .HasColumnName("Telefon_G")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonP)
                    .HasColumnName("Telefon_P")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.Versichertennummer)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.VmPriMaTs)
                    .IsRequired()
                    .HasColumnName("VmPriMaTS")
                    .IsRowVersion();

                entity.Property(e => e.Vorname)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VmSachversicherung>(entity =>
            {
                entity.HasIndex(e => e.BaInstitutionId);

                entity.HasIndex(e => e.BaPersonId)
                    .HasName("IX_VmSachversicherung_BaPersonId");

                entity.HasIndex(e => e.DocumentIdAufhKuend);

                entity.HasIndex(e => e.DocumentIdMittAnm);

                entity.HasIndex(e => e.DocumentIdMutation);

                entity.HasIndex(e => e.FaLeistungId)
                    .HasName("IX_VmSachversicherung_FaLeistungsID");

                entity.HasIndex(e => e.VmPriMaId);

                entity.Property(e => e.VmSachversicherungId).HasColumnName("VmSachversicherungID");

                entity.Property(e => e.BaInstitutionId).HasColumnName("BaInstitutionID");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkungen).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentIdAufhKuend).HasColumnName("DocumentID_AufhKuend");

                entity.Property(e => e.DocumentIdMittAnm).HasColumnName("DocumentID_MittAnm");

                entity.Property(e => e.DocumentIdMutation).HasColumnName("DocumentID_Mutation");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Grundpraemie)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LaufzeitBis).HasColumnType("datetime");

                entity.Property(e => e.LaufzeitVon).HasColumnType("datetime");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Person)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Policenummer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Selbstbehalt).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.VersichertSeit).HasColumnType("datetime");

                entity.Property(e => e.VmPriMaId).HasColumnName("VmPriMaID");

                entity.Property(e => e.VmSachversicherungTs)
                    .IsRequired()
                    .HasColumnName("VmSachversicherungTS")
                    .IsRowVersion();

                entity.HasOne(d => d.BaInstitution)
                    .WithMany(p => p.VmSachversicherung)
                    .HasForeignKey(d => d.BaInstitutionId)
                    .HasConstraintName("FK_VmSachversicherung_BaInstitution");

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.VmSachversicherung)
                    .HasForeignKey(d => d.BaPersonId)
                    .HasConstraintName("FK_VmSachversicherung_BaPerson");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmSachversicherung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmSachversicherung_FaLeistung");

                entity.HasOne(d => d.VmPriMa)
                    .WithMany(p => p.VmSachversicherung)
                    .HasForeignKey(d => d.VmPriMaId)
                    .HasConstraintName("FK_VmSachversicherung_VmPriMa");
            });

            modelBuilder.Entity<VmSchulden>(entity =>
            {
                entity.Property(e => e.VmSchuldenId).HasColumnName("VmSchuldenID");

                entity.Property(e => e.Bemerkungen)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TilgungDatum).HasColumnType("datetime");

                entity.Property(e => e.VmSchuldenTs)
                    .IsRequired()
                    .HasColumnName("VmSchuldenTS")
                    .IsRowVersion();

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmSchulden)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmSchulden_FaLeistung");
            });

            modelBuilder.Entity<VmSiegelung>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.VmSiegelungId).HasColumnName("VmSiegelungID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.EntsiegelungsDatum).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KopieAndere)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MassaVerwalter)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NotarId).HasColumnName("NotarID");

                entity.Property(e => e.PliQuittung)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RechnungAn)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RechnungsBetrag).HasColumnType("money");

                entity.Property(e => e.RechnungsDatum).HasColumnType("datetime");

                entity.Property(e => e.RechnungsNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sdabgeschlossen).HasColumnName("SDabgeschlossen");

                entity.Property(e => e.SiegelungsDatum).HasColumnType("datetime");

                entity.Property(e => e.SiegelungsProtokollDokId).HasColumnName("SiegelungsProtokollDokID");

                entity.Property(e => e.TodesmeldungDatum).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VersandDatum).HasColumnType("datetime");

                entity.Property(e => e.VmSiegelungTs)
                    .IsRequired()
                    .HasColumnName("VmSiegelungTS")
                    .IsRowVersion();

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmSiegelung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_VmSiegelung_FaLeistung");

                entity.HasOne(d => d.Notar)
                    .WithMany(p => p.VmSiegelung)
                    .HasForeignKey(d => d.NotarId)
                    .HasConstraintName("FK_VmSiegelung_BaInstitution");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VmSiegelung)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_VmSiegelung_XUser");
            });

            modelBuilder.Entity<VmSituationsBericht>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.VmSituationsBerichtId).HasColumnName("VmSituationsBerichtID");

                entity.Property(e => e.AntragDatum).HasColumnType("datetime");

                entity.Property(e => e.AntragText).IsUnicode(false);

                entity.Property(e => e.BerichtFinanzen).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FaThemaCodes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VmSituationsBerichtTs)
                    .IsRequired()
                    .HasColumnName("VmSituationsBerichtTS")
                    .IsRowVersion();

                entity.Property(e => e.VmtypShantragCode).HasColumnName("VMTypSHAntragCode");

                entity.Property(e => e.ZielPrognose).IsUnicode(false);

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmSituationsBericht)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmSituationsBericht_FaLeistung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VmSituationsBericht)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_VmSituationsBericht_XUser");
            });

            modelBuilder.Entity<VmSozialversicherung>(entity =>
            {
                entity.HasIndex(e => e.BaInstitutionIdAdressat);

                entity.HasIndex(e => e.BaPersonIdAdressat);

                entity.HasIndex(e => e.DocumentIdKorrespondenz)
                    .HasName("IX_VmSozialversicherung_Korrespondenz");

                entity.Property(e => e.VmSozialversicherungId).HasColumnName("VmSozialversicherungID");

                entity.Property(e => e.BaInstitutionIdAdressat).HasColumnName("BaInstitutionID_Adressat");

                entity.Property(e => e.BaPersonIdAdressat).HasColumnName("BaPersonID_Adressat");

                entity.Property(e => e.Bemerkungen).IsUnicode(false);

                entity.Property(e => e.Berechnungsgrundlage)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentIdKorrespondenz).HasColumnName("DocumentID_Korrespondenz");

                entity.Property(e => e.Eingereicht).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Grund).IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VerfuegungVom).HasColumnType("datetime");

                entity.Property(e => e.Verfuegungsbetrag).HasColumnType("money");

                entity.Property(e => e.VmPriMaIdAdressat).HasColumnName("VmPriMaID_Adressat");

                entity.Property(e => e.VmSozialversicherungTs)
                    .IsRequired()
                    .HasColumnName("VmSozialversicherungTS")
                    .IsRowVersion();

                entity.HasOne(d => d.BaInstitutionIdAdressatNavigation)
                    .WithMany(p => p.VmSozialversicherung)
                    .HasForeignKey(d => d.BaInstitutionIdAdressat)
                    .HasConstraintName("FK_VmSozialversicherung_BaInstitution");

                entity.HasOne(d => d.BaPersonIdAdressatNavigation)
                    .WithMany(p => p.VmSozialversicherung)
                    .HasForeignKey(d => d.BaPersonIdAdressat)
                    .HasConstraintName("FK_VmSozialversicherung_BaPerson");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmSozialversicherung)
                    .HasForeignKey(d => d.FaLeistungId)
                    .HasConstraintName("FK_VmSozialversicherung_FaLeistung");

                entity.HasOne(d => d.VmPriMaIdAdressatNavigation)
                    .WithMany(p => p.VmSozialversicherung)
                    .HasForeignKey(d => d.VmPriMaIdAdressat)
                    .HasConstraintName("FK_VmSozialversicherung_VmPriMa");
            });

            modelBuilder.Entity<VmSteuern>(entity =>
            {
                entity.Property(e => e.VmSteuernId).HasColumnName("VmSteuernID");

                entity.Property(e => e.Bemerkungen).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumEntscheidErlass).HasColumnType("datetime");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.EingangDefVeranlagung).HasColumnType("datetime");

                entity.Property(e => e.ErledigungDurch)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.FristverlaengerungBeantragt).HasColumnType("datetime");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SteuererklaerungEingereicht).HasColumnType("datetime");

                entity.Property(e => e.VmSteuernTs)
                    .IsRequired()
                    .HasColumnName("VmSteuernTS")
                    .IsRowVersion();

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmSteuern)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmSteuern_FaLeistung");
            });

            modelBuilder.Entity<VmTestament>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.VmTestamentId).HasColumnName("VmTestamentID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.EroeffnungAbgeschlossenDatum).HasColumnType("datetime");

                entity.Property(e => e.EroeffnungAdressenDokId).HasColumnName("EroeffnungAdressenDokID");

                entity.Property(e => e.EroeffnungAuszugDokId).HasColumnName("EroeffnungAuszugDokID");

                entity.Property(e => e.EroeffnungDokId).HasColumnName("EroeffnungDokID");

                entity.Property(e => e.EroeffnungsRechnungBetrag).HasColumnType("money");

                entity.Property(e => e.EroeffnungsRechnungSapnr)
                    .HasColumnName("EroeffnungsRechnungSAPNr")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.KopieAnCodes)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NotarId).HasColumnName("NotarID");

                entity.Property(e => e.PublikationDatum).HasColumnType("datetime");

                entity.Property(e => e.PublikationFrist).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VmTestamentTs)
                    .IsRequired()
                    .HasColumnName("VmTestamentTS")
                    .IsRowVersion();

                entity.Property(e => e.ZeugnisseCodes)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ZusatzRechnungBetrag).HasColumnType("money");

                entity.Property(e => e.ZusatzRechnungSapnr)
                    .HasColumnName("ZusatzRechnungSAPNr")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmTestament)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmTestament_FaLeistung");

                entity.HasOne(d => d.Notar)
                    .WithMany(p => p.VmTestament)
                    .HasForeignKey(d => d.NotarId)
                    .HasConstraintName("FK_VmTestament_BaInstitution");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VmTestament)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_VmTestament_XUser");
            });

            modelBuilder.Entity<VmTestamentBescheinigung>(entity =>
            {
                entity.HasIndex(e => e.VmTestamentBescheinigungId);

                entity.HasIndex(e => e.VmTestamentId);

                entity.Property(e => e.VmTestamentBescheinigungId).HasColumnName("VmTestamentBescheinigungID");

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.BescheinigungDokId).HasColumnName("BescheinigungDokID");

                entity.Property(e => e.BescheinigungText)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Gebuehr).HasColumnType("money");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sapnr)
                    .HasColumnName("SAPNr")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VmTestamentBescheinigungTs)
                    .IsRequired()
                    .HasColumnName("VmTestamentBescheinigungTS")
                    .IsRowVersion();

                entity.Property(e => e.VmTestamentId).HasColumnName("VmTestamentID");

                entity.HasOne(d => d.VmTestament)
                    .WithMany(p => p.VmTestamentBescheinigung)
                    .HasForeignKey(d => d.VmTestamentId)
                    .HasConstraintName("FK_VmTestamentBescheinigung_VmTestament");
            });

            modelBuilder.Entity<VmTestamentVerfuegung>(entity =>
            {
                entity.HasIndex(e => e.VmTestamentId);

                entity.Property(e => e.VmTestamentVerfuegungId).HasColumnName("VmTestamentVerfuegungID");

                entity.Property(e => e.AbonachherCode).HasColumnName("ABOnachherCode");

                entity.Property(e => e.AbonachherText)
                    .HasColumnName("ABOnachherText")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AbovorherCode).HasColumnName("ABOvorherCode");

                entity.Property(e => e.AbovorherText)
                    .HasColumnName("ABOvorherText")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.EingangsDatum).HasColumnType("datetime");

                entity.Property(e => e.EroeffnungsDatum).HasColumnType("datetime");

                entity.Property(e => e.VerfuegungText).IsUnicode(false);

                entity.Property(e => e.VerfuegungsDatum).HasColumnType("datetime");

                entity.Property(e => e.VmTestamentId).HasColumnName("VmTestamentID");

                entity.Property(e => e.VmTestamentVerfuegungTs)
                    .IsRequired()
                    .HasColumnName("VmTestamentVerfuegungTS")
                    .IsRowVersion();

                entity.HasOne(d => d.VmTestament)
                    .WithMany(p => p.VmTestamentVerfuegung)
                    .HasForeignKey(d => d.VmTestamentId)
                    .HasConstraintName("FK_VmTestamentVerfuegung_VmTestament");
            });

            modelBuilder.Entity<VmVaterschaft>(entity =>
            {
                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.VmVaterschaftId).HasColumnName("VmVaterschaftID");

                entity.Property(e => e.AnerkennungDatum).HasColumnType("datetime");

                entity.Property(e => e.AnerkennungOrt)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bemerkung).IsUnicode(false);

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.GebuehrDatum).HasColumnType("datetime");

                entity.Property(e => e.GeburtsmitteilungDatum).HasColumnType("datetime");

                entity.Property(e => e.GeburtsmitteilungOrt)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PendenzFrist).HasColumnType("datetime");

                entity.Property(e => e.PendenzText)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SchlussberichtAnKommission).HasColumnType("datetime");

                entity.Property(e => e.SchlussberichtGenehmigung).HasColumnType("datetime");

                entity.Property(e => e.SorgerechtVereinbDatum).HasColumnType("datetime");

                entity.Property(e => e.UhvabschlussGrundCode).HasColumnName("UHVAbschlussGrundCode");

                entity.Property(e => e.Uhvbetrag)
                    .HasColumnName("UHVBetrag")
                    .HasColumnType("money");

                entity.Property(e => e.Uhvdatum)
                    .HasColumnName("UHVDatum")
                    .HasColumnType("datetime");

                entity.Property(e => e.UnterhaltsurteilBetrag).HasColumnType("money");

                entity.Property(e => e.UnterhaltsurteilDatum).HasColumnType("datetime");

                entity.Property(e => e.Vanfechtungsurteil)
                    .HasColumnName("VAnfechtungsurteil")
                    .HasColumnType("datetime");

                entity.Property(e => e.VmVaterschaftTs)
                    .IsRequired()
                    .HasColumnName("VmVaterschaftTS")
                    .IsRowVersion();

                entity.Property(e => e.VurteilBetrag)
                    .HasColumnName("VUrteilBetrag")
                    .HasColumnType("money");

                entity.Property(e => e.VurteilDatum)
                    .HasColumnName("VUrteilDatum")
                    .HasColumnType("datetime");

                entity.Property(e => e.Zgbcodes)
                    .HasColumnName("ZGBCodes")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.VmVaterschaft)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VmVaterschaft_FaLeistung");
            });

            modelBuilder.Entity<WhAsvseintrag>(entity =>
            {
                entity.ToTable("WhASVSEintrag");

                entity.HasIndex(e => e.BaPersonId);

                entity.HasIndex(e => e.FaLeistungId);

                entity.Property(e => e.WhAsvseintragId).HasColumnName("WhASVSEintragID");

                entity.Property(e => e.AsvseintragStatusCode).HasColumnName("ASVSEintragStatusCode");

                entity.Property(e => e.BaPersonId).HasColumnName("BaPersonID");

                entity.Property(e => e.Bemerkung)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumBis).HasColumnType("datetime");

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.FaLeistungId).HasColumnName("FaLeistungID");

                entity.Property(e => e.Modified)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WhAsvseintragTs)
                    .IsRequired()
                    .HasColumnName("WhASVSEintragTS")
                    .IsRowVersion();

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.WhAsvseintrag)
                    .HasForeignKey(d => d.BaPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WhASVSEintrag_BaPerson");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.WhAsvseintrag)
                    .HasForeignKey(d => d.FaLeistungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WhASVSEintrag_FaLeistung");
            });

            modelBuilder.Entity<WhGefKategorie>(entity =>
            {
                entity.HasIndex(e => e.WhGefKategorieId)
                    .HasName("UK_WhGefKategorie_WhGefKategorieCode")
                    .IsUnique();

                entity.Property(e => e.WhGefKategorieId).HasColumnName("WhGefKategorieID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WhGefKategorieTs)
                    .IsRequired()
                    .HasColumnName("WhGefKategorieTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<Xarchive>(entity =>
            {
                entity.HasKey(e => e.ArchiveId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("XArchive");

                entity.HasIndex(e => e.SortKey)
                    .HasName("IX_XArchive")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.ArchiveId).HasColumnName("ArchiveID");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Remark).IsUnicode(false);

                entity.Property(e => e.XarchiveTs)
                    .IsRequired()
                    .HasColumnName("XArchiveTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<Xbookmark>(entity =>
            {
                entity.HasKey(e => e.BookmarkName);

                entity.ToTable("XBookmark");

                entity.HasIndex(e => e.ModulId);

                entity.Property(e => e.BookmarkName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BookmarkNameTid).HasColumnName("BookmarkNameTID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryTid).HasColumnName("CategoryTID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.DescriptionTid).HasColumnName("DescriptionTID");

                entity.Property(e => e.ModulId).HasColumnName("ModulID");

                entity.Property(e => e.Sql)
                    .HasColumnName("SQL")
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.XbookmarkTs)
                    .IsRequired()
                    .HasColumnName("XBookmarkTS")
                    .IsRowVersion();

                entity.HasOne(d => d.Modul)
                    .WithMany(p => p.Xbookmark)
                    .HasForeignKey(d => d.ModulId)
                    .HasConstraintName("FK_XBookmark_XModul");
            });

            modelBuilder.Entity<XClass>(entity =>
            {
                entity.ToTable("XClass");

                entity.HasIndex(e => e.ClassName)
                    .HasName("UK_XClass_ClassName");

                entity.HasIndex(e => e.ModulId);

                entity.Property(e => e.XclassId).HasColumnName("XClassID");

                entity.Property(e => e.Assembly).HasColumnType("image");

                entity.Property(e => e.BaseType)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Branch)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.BuildNr).HasDefaultValueSql("((0))");

                entity.Property(e => e.CheckOutDate)
                    .HasColumnName("CheckOut_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CheckOutUserId).HasColumnName("CheckOut_UserID");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ClassNameViewModel)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ClassTid).HasColumnName("ClassTID");

                entity.Property(e => e.CodeGenerated).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Designer).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaskName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModulId).HasColumnName("ModulID");

                entity.Property(e => e.NamespaceExtension)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PropertiesXml)
                    .HasColumnName("PropertiesXML")
                    .IsUnicode(false);

                entity.Property(e => e.Resource).HasColumnType("image");

                entity.Property(e => e.XclassTs)
                    .IsRequired()
                    .HasColumnName("XClassTS")
                    .IsRowVersion();

                entity.HasOne(d => d.Modul)
                    .WithMany(p => p.Xclass)
                    .HasForeignKey(d => d.ModulId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XClass_XModul");
            });

            modelBuilder.Entity<XclassComponent>(entity =>
            {
                entity.HasKey(e => new { e.ClassName, e.ComponentName });

                entity.ToTable("XClassComponent");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentTid).HasColumnName("ComponentTID");

                entity.Property(e => e.PropertiesXml)
                    .HasColumnName("PropertiesXML")
                    .IsUnicode(false);

                entity.Property(e => e.SelectStatement).IsUnicode(false);

                entity.Property(e => e.TableName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.XclassComponentTs)
                    .IsRequired()
                    .HasColumnName("XClassComponentTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XclassControl>(entity =>
            {
                entity.HasKey(e => new { e.ClassName, e.ControlName });

                entity.ToTable("XClassControl");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ControlName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ControlTid).HasColumnName("ControlTID");

                entity.Property(e => e.DataMember)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DataSource)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lovname)
                    .HasColumnName("LOVName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParentControl)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PropertiesXml)
                    .HasColumnName("PropertiesXML")
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.XclassControlTs)
                    .IsRequired()
                    .HasColumnName("XClassControlTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XclassReference>(entity =>
            {
                entity.HasKey(e => new { e.ClassName, e.ClassNameRef });

                entity.ToTable("XClassReference");

                entity.HasIndex(e => e.ClassNameRef)
                    .HasName("IX_XClassReference");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ClassNameRef)
                    .HasColumnName("ClassName_Ref")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.XclassReferenceTs)
                    .IsRequired()
                    .HasColumnName("XClassReferenceTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XclassRule>(entity =>
            {
                entity.ToTable("XClassRule");

                entity.HasIndex(e => new { e.ClassName, e.ControlName, e.ComponentName })
                    .HasName("IX_XClassRule")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.XclassRuleId).HasColumnName("XClassRuleID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ControlName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SortKey).HasDefaultValueSql("((100))");

                entity.Property(e => e.XclassRuleTs)
                    .IsRequired()
                    .HasColumnName("XClassRuleTS")
                    .IsRowVersion();

                entity.Property(e => e.XruleId).HasColumnName("XRuleID");

                entity.HasOne(d => d.Xrule)
                    .WithMany(p => p.XclassRule)
                    .HasForeignKey(d => d.XruleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XClassRule_XRule");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.XclassRule)
                    .HasForeignKey(d => new { d.ClassName, d.ComponentName })
                    .HasConstraintName("FK_XClassRule_XClassComponent");

                entity.HasOne(d => d.CNavigation)
                    .WithMany(p => p.XclassRule)
                    .HasForeignKey(d => new { d.ClassName, d.ControlName })
                    .HasConstraintName("FK_XClassRule_XClassControl");
            });

            modelBuilder.Entity<XConfig>(entity =>
            {
                entity.ToTable("XConfig");

                entity.HasIndex(e => new { e.KeyPath, e.DatumVon })
                    .HasName("UK_XConfig_KeyPath_DatumVon")
                    .IsUnique();

                entity.HasIndex(e => new { e.ValueBit, e.OriginalValueBit, e.ValueDateTime, e.OriginalValueDateTime, e.ValueDecimal, e.OriginalValueDecimal, e.ValueInt, e.OriginalValueInt, e.ValueMoney, e.OriginalValueMoney, e.ValueVarchar, e.OriginalValueVarchar, e.KeyPath, e.DatumVon })
                    .HasName("IX_XConfig_KeyPath_DatumVon_ValueVar_OriginalValue");

                entity.Property(e => e.XconfigId).HasColumnName("XConfigID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumVon).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionTid).HasColumnName("DescriptionTID");

                entity.Property(e => e.KeyPath)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.KeyPathTid).HasColumnName("KeyPathTID");

                entity.Property(e => e.LOVName)
                    .HasColumnName("LOVName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalValueDateTime).HasColumnType("datetime");

                entity.Property(e => e.OriginalValueDecimal).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.OriginalValueMoney).HasColumnType("money");

                entity.Property(e => e.OriginalValueVarchar).HasColumnType("varchar(max)");

                entity.Property(e => e.ValueDateTime).HasColumnType("datetime");

                entity.Property(e => e.ValueDecimal).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.ValueMoney).HasColumnType("money");

                entity.Property(e => e.ValueVarchar).HasColumnType("varchar(max)");

                entity.Property(e => e.XconfigTs)
                    .IsRequired()
                    .HasColumnName("XConfigTS")
                    .IsRowVersion();

                entity.Property(e => e.XnamespaceExtensionId).HasColumnName("XNamespaceExtensionID");

                entity.HasOne(d => d.XnamespaceExtension)
                    .WithMany(p => p.Xconfig)
                    .HasForeignKey(d => d.XnamespaceExtensionId)
                    .HasConstraintName("FK_XConfig_XNamespaceExtension");
            });

            modelBuilder.Entity<XdbserverVersion>(entity =>
            {
                entity.ToTable("XDBServerVersion");

                entity.Property(e => e.XdbserverVersionId).HasColumnName("XDBServerVersionID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServerVersion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(@@version)");

                entity.Property(e => e.XdbserverVersionTs)
                    .IsRequired()
                    .HasColumnName("XDBServerVersionTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<Xdbversion>(entity =>
            {
                entity.ToTable("XDBVersion");

                entity.Property(e => e.XdbversionId).HasColumnName("XDBVersionID");

                entity.Property(e => e.BackwardCompatibleDownToClientVersion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ChangesSinceLastVersion).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SqlserverVersionInfo)
                    .IsRequired()
                    .HasColumnName("SQLServerVersionInfo")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VersionDate).HasColumnType("datetime");

                entity.Property(e => e.XdbversionTs)
                    .IsRequired()
                    .HasColumnName("XDBVersionTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XdeleteRule>(entity =>
            {
                entity.ToTable("XDeleteRule");

                entity.Property(e => e.XdeleteRuleId).HasColumnName("XDeleteRuleID");

                entity.Property(e => e.ColumnName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.XdeleteRuleCode)
                    .HasColumnName("XDeleteRuleCode")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.XdeleteRuleTs)
                    .IsRequired()
                    .HasColumnName("XDeleteRuleTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XdocContext>(entity =>
            {
                entity.HasKey(e => e.DocContextId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("XDocContext");

                entity.HasIndex(e => e.DocContextName)
                    .HasName("IX_XDocContext")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.DocContextId).HasColumnName("DocContextID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DocContextName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.System).HasDefaultValueSql("(0)");

                entity.Property(e => e.XdocContextTs)
                    .IsRequired()
                    .HasColumnName("XDocContextTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XdocContextTemplate>(entity =>
            {
                entity.ToTable("XDocContext_Template");

                entity.HasIndex(e => e.DocContextId);

                entity.HasIndex(e => new { e.ParentId, e.ParentPosition })
                    .HasName("IX_XDocContext_Template")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.XdocContextTemplateId).HasColumnName("XDocContext_TemplateID");

                entity.Property(e => e.DocContextId).HasColumnName("DocContextID");

                entity.Property(e => e.DocTemplateId).HasColumnName("DocTemplateID");

                entity.Property(e => e.FolderName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModulId).HasColumnName("ModulID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.XdocContextTemplateTs)
                    .IsRequired()
                    .HasColumnName("XDocContext_TemplateTS")
                    .IsRowVersion();

                entity.HasOne(d => d.DocContext)
                    .WithMany(p => p.XdocContextTemplate)
                    .HasForeignKey(d => d.DocContextId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_XDocContext_Template_XDocContext");

                entity.HasOne(d => d.DocTemplate)
                    .WithMany(p => p.XdocContextTemplate)
                    .HasForeignKey(d => d.DocTemplateId)
                    .HasConstraintName("FK_XDocContext_Template_XDocTemplate");

                entity.HasOne(d => d.Modul)
                    .WithMany(p => p.XdocContextTemplate)
                    .HasForeignKey(d => d.ModulId)
                    .HasConstraintName("FK_XDocContext_Template_XModul");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_XDocContext_Template_XDocContext_Template");
            });

            modelBuilder.Entity<XdocContextType>(entity =>
            {
                entity.HasKey(e => e.DocContextTypeId);

                entity.ToTable("XDocContextType");

                entity.HasIndex(e => e.NameDocContextType)
                    .HasName("IX_XDocContextType")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.DocContextTypeId).HasColumnName("DocContextTypeID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentFolder)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NameDocContextType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TemplateFolder)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.XdocContextTypeTs)
                    .IsRequired()
                    .HasColumnName("XDocContextTypeTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XDocTemplate>(entity =>
            {
                entity.HasKey(e => e.DocTemplateId);

                entity.ToTable("XDocTemplate");

                entity.HasIndex(e => e.XprofileId);

                entity.Property(e => e.DocTemplateId).HasColumnName("DocTemplateID");

                entity.Property(e => e.CheckOutDate)
                    .HasColumnName("CheckOut_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CheckOutFilename)
                    .HasColumnName("CheckOut_Filename")
                    .IsUnicode(false);

                entity.Property(e => e.CheckOutMachine)
                    .HasColumnName("CheckOut_Machine")
                    .IsUnicode(false);

                entity.Property(e => e.CheckOutUserId).HasColumnName("CheckOut_UserID");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateLastSave).HasColumnType("datetime");

                entity.Property(e => e.DocTemplateName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DocTemplateTs)
                    .IsRequired()
                    .HasColumnName("DocTemplateTS")
                    .IsRowVersion();

                entity.Property(e => e.FileBinary).HasColumnType("image");

                entity.Property(e => e.FileExtension)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.XprofileId).HasColumnName("XProfileID");

                entity.HasOne(d => d.CheckOutUser)
                    .WithMany(p => p.XdocTemplate)
                    .HasForeignKey(d => d.CheckOutUserId)
                    .HasConstraintName("FK_XDocTemplate_XUser");

                entity.HasOne(d => d.Xprofile)
                    .WithMany(p => p.XdocTemplate)
                    .HasForeignKey(d => d.XprofileId)
                    .HasConstraintName("FK_XDocTemplate_XProfile");
            });

            modelBuilder.Entity<XDocument>(entity =>
            {
                entity.HasKey(e => e.DocumentId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("XDocument");

                entity.HasIndex(e => new { e.DocTypeCode, e.DocFormatCode, e.FileExtension })
                    .HasName("IX_XDocument_DocTypeCode")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.CheckOutDate)
                    .HasColumnName("CheckOut_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CheckOutFilename)
                    .HasColumnName("CheckOut_Filename")
                    .IsUnicode(false);

                entity.Property(e => e.CheckOutMachine)
                    .HasColumnName("CheckOut_Machine")
                    .IsUnicode(false);

                entity.Property(e => e.CheckOutUserId).HasColumnName("CheckOut_UserID");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLastRead).HasColumnType("datetime");

                entity.Property(e => e.DateLastSave)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DocTemplateId).HasColumnName("DocTemplateID");

                entity.Property(e => e.DocTemplateName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FileBinary)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.FileExtension)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserIdCreator).HasColumnName("UserID_Creator");

                entity.Property(e => e.UserIdLastRead).HasColumnName("UserID_LastRead");

                entity.Property(e => e.UserIdLastSave).HasColumnName("UserID_LastSave");

                entity.Property(e => e.XdocumentTs)
                    .IsRequired()
                    .HasColumnName("XDocumentTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<Xhyperlink>(entity =>
            {
                entity.ToTable("XHyperlink");

                entity.Property(e => e.XhyperlinkId).HasColumnName("XHyperlinkID");

                entity.Property(e => e.Hyperlink)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.XhyperlinkTs)
                    .IsRequired()
                    .HasColumnName("XHyperlinkTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XhyperlinkContext>(entity =>
            {
                entity.ToTable("XHyperlinkContext");

                entity.Property(e => e.XhyperlinkContextId).HasColumnName("XHyperlinkContextID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.System).HasDefaultValueSql("(0)");

                entity.Property(e => e.XhyperlinkContextTs)
                    .IsRequired()
                    .HasColumnName("XHyperlinkContextTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XhyperlinkContextHyperlink>(entity =>
            {
                entity.ToTable("XHyperlinkContext_Hyperlink");

                entity.HasIndex(e => new { e.XhyperlinkContextId, e.ParentId, e.SortKey })
                    .HasName("IX_XHyperlinkContext_Hyperlink")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.XhyperlinkContextHyperlinkId).HasColumnName("XHyperlinkContext_HyperlinkID");

                entity.Property(e => e.FolderName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.XhyperlinkContextHyperlinkTs)
                    .IsRequired()
                    .HasColumnName("XHyperlinkContext_HyperlinkTS")
                    .IsRowVersion();

                entity.Property(e => e.XhyperlinkContextId).HasColumnName("XHyperlinkContextID");

                entity.Property(e => e.XhyperlinkId).HasColumnName("XHyperlinkID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_XHyperlinkContext_Hyperlink_XHyperlinkContext_Hyperlink");

                entity.HasOne(d => d.XhyperlinkContext)
                    .WithMany(p => p.XhyperlinkContextHyperlink)
                    .HasForeignKey(d => d.XhyperlinkContextId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XHyperlinkContext_Hyperlink_XHyperlinkContext");

                entity.HasOne(d => d.Xhyperlink)
                    .WithMany(p => p.XhyperlinkContextHyperlink)
                    .HasForeignKey(d => d.XhyperlinkId)
                    .HasConstraintName("FK_XHyperlinkContext_Hyperlink_XHyperlink");
            });

            modelBuilder.Entity<Xicon>(entity =>
            {
                entity.ToTable("XIcon");

                entity.Property(e => e.XiconId)
                    .HasColumnName("XIconID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Icon).HasColumnType("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.XiconTs)
                    .IsRequired()
                    .HasColumnName("XIconTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XLangText>(entity =>
            {
                entity.HasKey(e => new { e.Tid, e.LanguageCode });

                entity.ToTable("XLangText");

                entity.Property(e => e.Tid)
                    .HasColumnName("TID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LargeText).IsUnicode(false);

                entity.Property(e => e.Text)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.XlangTextTs)
                    .IsRequired()
                    .HasColumnName("XLangTextTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<Xlog>(entity =>
            {
                entity.ToTable("XLog");

                entity.HasIndex(e => e.Source)
                    .HasName("IX_XLog_XLogCode");

                entity.Property(e => e.XlogId).HasColumnName("XLogID");

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");

                entity.Property(e => e.ReferenceTable)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.XlogLevelCode).HasColumnName("XLogLevelCode");

                entity.Property(e => e.XlogTs)
                    .IsRequired()
                    .HasColumnName("XLogTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<Xlov>(entity =>
            {
                entity.ToTable("XLOV");

                entity.HasIndex(e => e.Lovname)
                    .HasName("UK_XLOV_LOVName")
                    .IsUnique();

                entity.Property(e => e.Xlovid).HasColumnName("XLOVID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Expandable).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

                entity.Property(e => e.Lovname)
                    .IsRequired()
                    .HasColumnName("LOVName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModulId).HasColumnName("ModulID");

                entity.Property(e => e.NameValue1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameValue2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameValue3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Translatable).HasDefaultValueSql("((1))");

                entity.Property(e => e.Xlovts)
                    .IsRequired()
                    .HasColumnName("XLOVTS")
                    .IsRowVersion();

                entity.HasOne(d => d.Modul)
                    .WithMany(p => p.Xlov)
                    .HasForeignKey(d => d.ModulId)
                    .HasConstraintName("FK_XLOV_XModul");
            });

            modelBuilder.Entity<XLovCode>(entity =>
            {
                entity.ToTable("XLOVCode");

                entity.HasIndex(e => e.Text);

                entity.HasIndex(e => e.Value2);

                entity.HasIndex(e => e.Value3);

                entity.HasIndex(e => new { e.Lovname, e.Code })
                    .HasName("UK_XLOVCode_LOVName_Code");

                entity.HasIndex(e => new { e.Lovname, e.SortKey, e.Code })
                    .HasName("IX_XLOVCode_LOVName_SortKey")
                    .ForSqlServerIsClustered();

                entity.HasIndex(e => new { e.Lovname, e.Code, e.SortKey, e.Bfscode });

                entity.Property(e => e.XlovcodeId).HasColumnName("XLOVCodeID");

                entity.Property(e => e.Bfscode).HasColumnName("BFSCode");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LovcodeName)
                    .HasColumnName("LOVCodeName")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Lovname)
                    .IsRequired()
                    .HasColumnName("LOVName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortText)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShortTextTid).HasColumnName("ShortTextTID");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TextTid).HasColumnName("TextTID");

                entity.Property(e => e.Value1)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Value1Tid).HasColumnName("Value1TID");

                entity.Property(e => e.Value2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Value2Tid).HasColumnName("Value2TID");

                entity.Property(e => e.Value3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Value3Tid).HasColumnName("Value3TID");

                entity.Property(e => e.XlovcodeTs)
                    .IsRequired()
                    .HasColumnName("XLOVCodeTS")
                    .IsRowVersion();

                entity.Property(e => e.Xlovid).HasColumnName("XLOVID");

                entity.HasOne(d => d.LovnameNavigation)
                    .WithMany(p => p.XlovcodeLovnameNavigation)
                    .HasPrincipalKey(p => p.Lovname)
                    .HasForeignKey(d => d.Lovname);

                entity.HasOne(d => d.Xlov)
                    .WithMany(p => p.XlovcodeXlov)
                    .HasForeignKey(d => d.Xlovid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XLOVCode_XLOV");
            });

            modelBuilder.Entity<XmenuItem>(entity =>
            {
                entity.HasKey(e => e.MenuItemId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("XMenuItem");

                entity.HasIndex(e => new { e.ParentMenuItemId, e.SortKey })
                    .HasName("IX_XMenuItem")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");

                entity.Property(e => e.Caption)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClassName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ControlName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Enabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.ImageIndex).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ImageIndexDisabled).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ItemShortcutKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MenuTid).HasColumnName("MenuTID");

                entity.Property(e => e.OnlyBiagadminVisible).HasColumnName("OnlyBIAGAdminVisible");

                entity.Property(e => e.ParentMenuItemId).HasColumnName("ParentMenuItemID");

                entity.Property(e => e.Visible).HasDefaultValueSql("((1))");

                entity.Property(e => e.XmenuItemTs)
                    .IsRequired()
                    .HasColumnName("XMenuItemTS")
                    .IsRowVersion();

                entity.HasOne(d => d.ParentMenuItem)
                    .WithMany(p => p.InverseParentMenuItem)
                    .HasForeignKey(d => d.ParentMenuItemId)
                    .HasConstraintName("FK_XMenuItem_XMenuItem");
            });

            modelBuilder.Entity<XMessage>(entity =>
            {
                entity.HasKey(e => new { e.MaskName, e.MessageName });

                entity.ToTable("XMessage");

                entity.Property(e => e.MaskName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MessageName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Context)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MessageTid).HasColumnName("MessageTID");

                entity.Property(e => e.XmessageTs)
                    .IsRequired()
                    .HasColumnName("XMessageTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XModul>(entity =>
            {
                entity.HasKey(e => e.ModulId);

                entity.ToTable("XModul");

                entity.Property(e => e.ModulId)
                    .HasColumnName("ModulID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DbPrefix)
                    .HasColumnName("DB_Prefix")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ModulTree).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameSpace)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.XmodulTs)
                    .IsRequired()
                    .HasColumnName("XModulTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XmodulTree>(entity =>
            {
                entity.HasKey(e => e.ModulTreeId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("XModulTree");

                entity.HasIndex(e => new { e.ModulTreeId, e.ModulId })
                    .HasName("IX_XModulTree_ModulTreeID")
                    .IsUnique();

                entity.HasIndex(e => new { e.ModulId, e.ModulTreeIdParent, e.SortKey })
                    .HasName("IX_XModulTree")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.ModulTreeId)
                    .HasColumnName("ModulTreeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaskName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModulId).HasColumnName("ModulID");

                entity.Property(e => e.ModulTreeCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModulTreeIdParent).HasColumnName("ModulTreeID_Parent");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameTid).HasColumnName("NameTID");

                entity.Property(e => e.SortKey).HasDefaultValueSql("((9999))");

                entity.Property(e => e.SqlInsertTreeItem)
                    .HasColumnName("sqlInsertTreeItem")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.SqlPreExecute)
                    .HasColumnName("sqlPreExecute")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.XiconId)
                    .HasColumnName("XIconID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.XmodulTreeTs)
                    .IsRequired()
                    .HasColumnName("XModulTreeTS")
                    .IsRowVersion();

                entity.HasOne(d => d.MaskNameNavigation)
                    .WithMany(p => p.XmodulTree)
                    .HasForeignKey(d => d.MaskName)
                    .HasConstraintName("FK_XModulTree_DynaMask");

                entity.HasOne(d => d.Xicon)
                    .WithMany(p => p.XmodulTree)
                    .HasForeignKey(d => d.XiconId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XModulTree_XIcon");

                entity.HasOne(d => d.Modul)
                    .WithMany(p => p.InverseModul)
                    .HasPrincipalKey(p => new { p.ModulTreeId, p.ModulId })
                    .HasForeignKey(d => new { d.ModulTreeIdParent, d.ModulId })
                    .HasConstraintName("FK_XModulTree_XModulTree");
            });

            modelBuilder.Entity<XnamespaceExtension>(entity =>
            {
                entity.ToTable("XNamespaceExtension");

                entity.HasIndex(e => e.NamespaceExtension)
                    .HasName("UK_XNamespaceExtension_NamespaceExtension")
                    .IsUnique();

                entity.HasIndex(e => new { e.XnamespaceExtensionId, e.NamespaceExtension });

                entity.Property(e => e.XnamespaceExtensionId).HasColumnName("XNamespaceExtensionID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamespaceExtension)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.XnamespaceExtensionTs)
                    .IsRequired()
                    .HasColumnName("XNamespaceExtensionTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XOrgUnit>(entity =>
            {
                entity.HasKey(e => e.OrgUnitId);

                entity.ToTable("XOrgUnit");

                entity.HasIndex(e => e.ChiefId);

                entity.HasIndex(e => e.Kostenstelle);

                entity.HasIndex(e => e.Mandantennummer);

                entity.HasIndex(e => e.ModulId);

                entity.HasIndex(e => e.OeitemTypCode);

                entity.HasIndex(e => e.RechtsdienstUserId);

                entity.HasIndex(e => e.RepresentativeId);

                entity.HasIndex(e => e.XprofileId);

                entity.HasIndex(e => new { e.OrgUnitId, e.ItemName });

                entity.HasIndex(e => new { e.OrgUnitId, e.OeitemTypCode });

                entity.HasIndex(e => new { e.OrgUnitId, e.ParentId });

                entity.HasIndex(e => new { e.OrgUnitId, e.Kostenstelle, e.ItemName });

                entity.HasIndex(e => new { e.OrgUnitId, e.ParentId, e.Mandantennummer, e.StundenLohnlaufNr, e.LeistungLohnlaufNr, e.Sammelkonto })
                    .HasName("IX_XOrgUnit_OrgUnitID_ParentID_MandantenNr_LohnlaufNrn_Sammelkonto");

                entity.Property(e => e.OrgUnitId).HasColumnName("OrgUnitID");

                entity.Property(e => e.AdAbteilung)
                    .HasColumnName("AD_Abteilung")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Adressat)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Adresse)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.AdresseAbteilung)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AdresseHausNr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AdresseKgs)
                    .HasColumnName("AdresseKGS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AdresseOrt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdressePlz)
                    .HasColumnName("AdressePLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AdresseStrasse)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ChiefId).HasColumnName("ChiefID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Internet)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Logo).IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModulId).HasColumnName("ModulID");

                entity.Property(e => e.OeitemTypCode).HasColumnName("OEItemTypCode");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Pckonto)
                    .HasColumnName("PCKonto")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Postfach)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RechtsdienstUserId).HasColumnName("RechtsdienstUserID");

                entity.Property(e => e.RepresentativeId).HasColumnName("RepresentativeID");

                entity.Property(e => e.StellvertreterId).HasColumnName("StellvertreterID");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Text1)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Text2)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Text3)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Text4)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.Www)
                    .HasColumnName("WWW")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.XorgUnitTs)
                    .IsRequired()
                    .HasColumnName("XOrgUnitTS")
                    .IsRowVersion();

                entity.Property(e => e.XprofileId).HasColumnName("XProfileID");

                entity.HasOne(d => d.Chief)
                    .WithMany(p => p.XorgUnitChief)
                    .HasForeignKey(d => d.ChiefId);

                entity.HasOne(d => d.Modul)
                    .WithMany(p => p.XorgUnit)
                    .HasForeignKey(d => d.ModulId)
                    .HasConstraintName("FK_XOrgUnit_XModul");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_XOrgUnit_XOrgUnit");

                entity.HasOne(d => d.RechtsdienstUser)
                    .WithMany(p => p.XorgUnitRechtsdienstUser)
                    .HasForeignKey(d => d.RechtsdienstUserId);

                entity.HasOne(d => d.Representative)
                    .WithMany(p => p.XorgUnitRepresentative)
                    .HasForeignKey(d => d.RepresentativeId);

                entity.HasOne(d => d.Xprofile)
                    .WithMany(p => p.XorgUnit)
                    .HasForeignKey(d => d.XprofileId)
                    .HasConstraintName("FK_XOrgUnit_XProfile");
            });

            modelBuilder.Entity<XOrgUnit_User>(entity =>
            {
                entity.ToTable("XOrgUnit_User");

                entity.HasIndex(e => e.OrgUnitMemberCode);

                entity.HasIndex(e => new { e.OrgUnitId, e.OrgUnitMemberCode });

                entity.HasIndex(e => new { e.OrgUnitId, e.UserId })
                    .HasName("UK_XOrgUnit_User_OrgUnitID_UserID")
                    .IsUnique();

                entity.HasIndex(e => new { e.UserId, e.OrgUnitMemberCode });

                entity.HasIndex(e => new { e.OrgUnitId, e.UserId, e.OrgUnitMemberCode });

                entity.HasKey(e => e.XorgUnitUserId);
                entity.Property(e => e.XorgUnitUserId).HasColumnName("XOrgUnit_UserID");

                entity.Property(e => e.OrgUnitId).HasColumnName("OrgUnitID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.XorgUnitUserTs)
                    .IsRequired()
                    .HasColumnName("XOrgUnit_UserTS")
                    .IsRowVersion();

                entity.HasOne(d => d.OrgUnit)
                    .WithMany(p => p.XorgUnitUser)
                    .HasForeignKey(d => d.OrgUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XOrgUnit_User_XOrgUnit");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.XorgUnitUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_XOrgUnit_User_XUser");
            });

            modelBuilder.Entity<XorgUnitXdocTemplate>(entity =>
            {
                entity.ToTable("XOrgUnit_XDocTemplate");

                entity.HasIndex(e => e.DocTemplateId);

                entity.HasIndex(e => e.OrgUnitId);

                entity.Property(e => e.XorgUnitXdocTemplateId).HasColumnName("XOrgUnit_XDocTemplateID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocTemplateId).HasColumnName("DocTemplateID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrgUnitId).HasColumnName("OrgUnitID");

                entity.Property(e => e.XorgUnitXdocTemplateTs)
                    .IsRequired()
                    .HasColumnName("XOrgUnit_XDocTemplateTS")
                    .IsRowVersion();

                entity.HasOne(d => d.DocTemplate)
                    .WithMany(p => p.XorgUnitXdocTemplate)
                    .HasForeignKey(d => d.DocTemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XOrgUnit_XDocTemplate_XDocTemplate");

                entity.HasOne(d => d.OrgUnit)
                    .WithMany(p => p.XorgUnitXdocTemplate)
                    .HasForeignKey(d => d.OrgUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XOrgUnit_XDocTemplate_XOrgUnit");
            });

            modelBuilder.Entity<XpermissionGroup>(entity =>
            {
                entity.HasKey(e => e.PermissionGroupId);

                entity.ToTable("XPermissionGroup");

                entity.Property(e => e.PermissionGroupId).HasColumnName("PermissionGroupID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.PermissionGroupName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.XpermissionGroupTs)
                    .IsRequired()
                    .HasColumnName("XPermissionGroupTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XpermissionValue>(entity =>
            {
                entity.HasKey(e => e.PermissionValueId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("XPermissionValue");

                entity.HasIndex(e => new { e.PermissionGroupId, e.PermissionCode, e.BgPositionsartId })
                    .HasName("IX_XPermissionValue")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.PermissionValueId).HasColumnName("PermissionValueID");

                entity.Property(e => e.BgPositionsartId).HasColumnName("BgPositionsartID");

                entity.Property(e => e.PermissionGroupId).HasColumnName("PermissionGroupID");

                entity.Property(e => e.XpermissionValueTs)
                    .IsRequired()
                    .HasColumnName("XPermissionValueTS")
                    .IsRowVersion();

                entity.HasOne(d => d.BgPositionsart)
                    .WithMany(p => p.XpermissionValue)
                    .HasForeignKey(d => d.BgPositionsartId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_XPermissionValue_BgPositionsart");

                entity.HasOne(d => d.PermissionGroup)
                    .WithMany(p => p.XpermissionValue)
                    .HasForeignKey(d => d.PermissionGroupId)
                    .HasConstraintName("FK_XPermissionValue_XPermissionGroup");
            });

            modelBuilder.Entity<Xprofile>(entity =>
            {
                entity.ToTable("XProfile");

                entity.Property(e => e.XprofileId).HasColumnName("XProfileID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.NameTid).HasColumnName("NameTID");

                entity.Property(e => e.XprofileTs)
                    .IsRequired()
                    .HasColumnName("XProfileTS")
                    .IsRowVersion();

                entity.Property(e => e.XprofileTypeCode).HasColumnName("XProfileTypeCode");
            });

            modelBuilder.Entity<XprofileTag>(entity =>
            {
                entity.ToTable("XProfileTag");

                entity.Property(e => e.XprofileTagId).HasColumnName("XProfileTagID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.NameTid).HasColumnName("NameTID");

                entity.Property(e => e.XprofileTagTs)
                    .IsRequired()
                    .HasColumnName("XProfileTagTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XprofileXprofileTag>(entity =>
            {
                entity.ToTable("XProfile_XProfileTag");

                entity.HasIndex(e => e.XprofileId);

                entity.HasIndex(e => e.XprofileTagId);

                entity.Property(e => e.XprofileXprofileTagId).HasColumnName("XProfile_XProfileTagID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.XprofileId).HasColumnName("XProfileID");

                entity.Property(e => e.XprofileTagId).HasColumnName("XProfileTagID");

                entity.Property(e => e.XprofileXprofileTagTs)
                    .IsRequired()
                    .HasColumnName("XProfile_XProfileTagTS")
                    .IsRowVersion();

                entity.HasOne(d => d.Xprofile)
                    .WithMany(p => p.XprofileXprofileTag)
                    .HasForeignKey(d => d.XprofileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XProfile_XProfileTag_XProfile");

                entity.HasOne(d => d.XprofileTag)
                    .WithMany(p => p.XprofileXprofileTag)
                    .HasForeignKey(d => d.XprofileTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XProfile_XProfileTag_XProfileTag");
            });

            modelBuilder.Entity<Xquery>(entity =>
            {
                entity.HasKey(e => e.QueryName)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("XQuery");

                entity.HasIndex(e => new { e.ParentReportName, e.ReportSortKey })
                    .HasName("IX_XQuery")
                    .ForSqlServerIsClustered();

                entity.HasIndex(e => new { e.QueryName, e.QueryCode })
                    .HasName("IXU_XQuery_QueryName")
                    .IsUnique();

                entity.Property(e => e.QueryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ContextForms)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LayoutXml)
                    .HasColumnName("LayoutXML")
                    .IsUnicode(false);

                entity.Property(e => e.ParameterXml)
                    .HasColumnName("ParameterXML")
                    .IsUnicode(false);

                entity.Property(e => e.ParentReportName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RelationColumnName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sqlquery)
                    .HasColumnName("SQLquery")
                    .IsUnicode(false);

                entity.Property(e => e.System).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserText)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.XqueryTs)
                    .IsRequired()
                    .HasColumnName("XQueryTS")
                    .IsRowVersion();

                entity.HasOne(d => d.XqueryNavigation)
                    .WithMany(p => p.InverseXqueryNavigation)
                    .HasPrincipalKey(p => new { p.QueryName, p.QueryCode })
                    .HasForeignKey(d => new { d.ParentReportName, d.QueryCode })
                    .HasConstraintName("FK_XQuery_XQuery");
            });

            modelBuilder.Entity<XRight>(entity =>
            {
                entity.HasKey(e => e.RightId);

                entity.ToTable("XRight");

                entity.HasIndex(e => e.RightName)
                    .HasName("IX_XRight_RightName_Unique")
                    .IsUnique();

                entity.HasIndex(e => e.XclassId);

                entity.HasIndex(e => new { e.ClassName, e.RightId })
                    .HasName("IX_XRight_ClassNameRightID");

                entity.HasIndex(e => new { e.ClassName, e.RightName })
                    .HasName("IX_XRight_ClassNameRightName");

                entity.Property(e => e.RightId).HasColumnName("RightID");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RightName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserText)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.XclassId).HasColumnName("XClassID");

                entity.Property(e => e.XrightTs)
                    .IsRequired()
                    .HasColumnName("XRightTS")
                    .IsRowVersion();

                entity.HasOne(d => d.XClass)
                    .WithMany(p => p.Xright)
                    .HasForeignKey(d => d.XclassId)
                    .HasConstraintName("FK_XRight_XClass");
            });

            modelBuilder.Entity<Xrule>(entity =>
            {
                entity.ToTable("XRule");

                entity.Property(e => e.XruleId)
                    .HasColumnName("XRuleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CsCode)
                    .HasColumnName("csCode")
                    .IsUnicode(false);

                entity.Property(e => e.ModulId).HasColumnName("ModulID");

                entity.Property(e => e.RuleCode).HasDefaultValueSql("((3))");

                entity.Property(e => e.RuleDescription)
                    .HasMaxLength(7000)
                    .IsUnicode(false);

                entity.Property(e => e.RuleName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.XruleTs)
                    .IsRequired()
                    .HasColumnName("XRuleTS")
                    .IsRowVersion();

                entity.HasOne(d => d.Modul)
                    .WithMany(p => p.Xrule)
                    .HasForeignKey(d => d.ModulId)
                    .HasConstraintName("FK_XRule_XModul");
            });

            modelBuilder.Entity<XsearchControlTemplate>(entity =>
            {
                entity.ToTable("XSearchControlTemplate");

                entity.Property(e => e.XsearchControlTemplateId).HasColumnName("XSearchControlTemplateID");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ColLayout).IsUnicode(false);

                entity.Property(e => e.ModulTreeId).HasColumnName("ModulTreeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ParentXsearchControlTemplateId).HasColumnName("ParentXSearchControlTemplateID");

                entity.Property(e => e.SortKey).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.ModulTree)
                    .WithMany(p => p.XsearchControlTemplate)
                    .HasForeignKey(d => d.ModulTreeId)
                    .HasConstraintName("FK_XSearchControlTemplate_XModulTree");

                entity.HasOne(d => d.ParentXsearchControlTemplate)
                    .WithMany(p => p.InverseParentXsearchControlTemplate)
                    .HasForeignKey(d => d.ParentXsearchControlTemplateId)
                    .HasConstraintName("FK_XSearchControlTemplate_XSearchControlTemplate");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.XsearchControlTemplate)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XSearchControlTemplate_XUser");
            });

            modelBuilder.Entity<XsearchControlTemplateField>(entity =>
            {
                entity.ToTable("XSearchControlTemplateField");

                entity.Property(e => e.XsearchControlTemplateFieldId).HasColumnName("XSearchControlTemplateFieldID");

                entity.Property(e => e.ControlName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ControlType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.XsearchControlTemplateId).HasColumnName("XSearchControlTemplateID");

                entity.HasOne(d => d.XsearchControlTemplate)
                    .WithMany(p => p.XsearchControlTemplateField)
                    .HasForeignKey(d => d.XsearchControlTemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XSearchControlTemplateField_XSearchControlTemplate");
            });

            modelBuilder.Entity<Xtable>(entity =>
            {
                entity.HasKey(e => e.TableName);

                entity.ToTable("XTable");

                entity.Property(e => e.TableName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Alias).HasColumnType("char(3)");

                entity.Property(e => e.Comment)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.DataWareHouse).HasDefaultValueSql("(0)");

                entity.Property(e => e.ModulId).HasColumnName("ModulID");

                entity.Property(e => e.System).HasDefaultValueSql("(0)");

                entity.Property(e => e.XtableTs)
                    .IsRequired()
                    .HasColumnName("XTableTS")
                    .IsRowVersion();

                entity.HasOne(d => d.Modul)
                    .WithMany(p => p.Xtable)
                    .HasForeignKey(d => d.ModulId)
                    .HasConstraintName("FK_XTable_XModul");
            });

            modelBuilder.Entity<XtableColumn>(entity =>
            {
                entity.HasKey(e => new { e.TableName, e.ColumnName })
                    .ForSqlServerIsClustered(false);

                entity.ToTable("XTableColumn");

                entity.HasIndex(e => new { e.TableName, e.SortKey, e.ColumnName })
                    .HasName("IX_XTableColumn")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.TableName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Comment)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayText)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayTextTid).HasColumnName("DisplayTextTID");

                entity.Property(e => e.Lovname)
                    .HasColumnName("LOVName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.XtableColumnTs)
                    .IsRequired()
                    .HasColumnName("XTableColumnTS")
                    .IsRowVersion();

                entity.HasOne(d => d.TableNameNavigation)
                    .WithMany(p => p.XtableColumn)
                    .HasForeignKey(d => d.TableName)
                    .HasConstraintName("FK_XTableColumn_XTable");
            });

            modelBuilder.Entity<XTask>(entity =>
            {
                entity.ToTable("XTask");

                entity.HasIndex(e => e.FaFallID);

                entity.HasIndex(e => new { e.XTaskID, e.TaskTypeCode });

                entity.HasIndex(e => new { e.BaPersonID, e.FaFallID, e.TaskSenderCode })
                    .HasName("IX_XTask_TaskSenderCode_FaFallID_BaPersonID");

                entity.HasIndex(e => new { e.SenderID, e.TaskSenderCode, e.TaskStatusCode })
                    .HasName("IX_XTask_SenderID");

                entity.HasIndex(e => new { e.ReceiverID, e.TaskReceiverCode, e.TaskStatusCode, e.ExpirationDate });

                entity.HasIndex(e => new { e.FaFallID, e.XTaskID, e.CreateDate, e.TaskSenderCode, e.BaPersonID });

                entity.HasIndex(e => new { e.TaskTypeCode, e.XTaskID, e.TaskStatusCode, e.ReceiverID, e.TaskReceiverCode });

                entity.HasIndex(e => new { e.SenderID, e.TaskSenderCode, e.TaskStatusCode, e.XTaskID, e.TaskTypeCode, e.ExpirationDate, e.ReceiverID, e.TaskReceiverCode });

                entity.Property(e => e.XTaskID).HasColumnName("XTaskID");

                entity.Property(e => e.BaPersonID).HasColumnName("BaPersonID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DoneDate).HasColumnType("datetime");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.FaAktennotizId).HasColumnName("FaAktennotizID");

                entity.Property(e => e.FaDokumenteId).HasColumnName("FaDokumenteID");

                entity.Property(e => e.FaFallID).HasColumnName("FaFallID");

                entity.Property(e => e.FaLeistungID).HasColumnName("FaLeistungID");

                entity.Property(e => e.JumpToPath)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverID).HasColumnName("ReceiverID");

                entity.Property(e => e.ResponseText)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.SenderID).HasColumnName("SenderID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TaskDescription)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.TaskStatusCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserIdErledigt).HasColumnName("UserID_Erledigt");

                entity.Property(e => e.UserIdInBearbeitung).HasColumnName("UserID_InBearbeitung");

                entity.Property(e => e.XTaskTS)
                    .IsRequired()
                    .HasColumnName("XTaskTS")
                    .IsRowVersion();

                entity.HasOne(d => d.BaPerson)
                    .WithMany(p => p.Xtask)
                    .HasForeignKey(d => d.BaPersonID)
                    .HasConstraintName("FK_XTask_BaPerson");

                entity.HasOne(d => d.FaLeistung)
                    .WithMany(p => p.Xtask)
                    .HasForeignKey(d => d.FaLeistungID)
                    .HasConstraintName("FK_XTask_FaLeistung");

                entity.HasOne(d => d.UserIdErledigtNavigation)
                    .WithMany(p => p.XtaskUserIdErledigtNavigation)
                    .HasForeignKey(d => d.UserIdErledigt)
                    .HasConstraintName("FK_XTask_XUser_Erledigt");

                entity.HasOne(d => d.UserIdInBearbeitungNavigation)
                    .WithMany(p => p.XtaskUserIdInBearbeitungNavigation)
                    .HasForeignKey(d => d.UserIdInBearbeitung)
                    .HasConstraintName("FK_XTask_XUser_Bearbeitung");
            });

            modelBuilder.Entity<XtaskAutoGenerated>(entity =>
            {
                entity.ToTable("XTaskAutoGenerated");

                entity.HasIndex(e => e.XtaskId)
                    .HasName("UK_XTaskAutoGenerated_XTaskID")
                    .IsUnique();

                entity.HasIndex(e => new { e.XtaskId, e.ReferenceTable, e.ReferenceId })
                    .HasName("IX_XTaskAutoGenerated_ReferenceTable_ReferenceID");

                entity.Property(e => e.XtaskAutoGeneratedId).HasColumnName("XTaskAutoGeneratedID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");

                entity.Property(e => e.ReferenceTable)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.XtaskAutoGeneratedTs)
                    .IsRequired()
                    .HasColumnName("XTaskAutoGeneratedTS")
                    .IsRowVersion();

                entity.Property(e => e.XtaskAutoGeneratedTypeCode).HasColumnName("XTaskAutoGeneratedTypeCode");

                entity.Property(e => e.XtaskId).HasColumnName("XTaskID");

                entity.HasOne(d => d.Xtask)
                    .WithOne(p => p.XtaskAutoGenerated)
                    .HasForeignKey<XtaskAutoGenerated>(d => d.XtaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XTaskAutoGenerated_XTask");
            });

            modelBuilder.Entity<XtaskTemplate>(entity =>
            {
                entity.ToTable("XTaskTemplate");

                entity.Property(e => e.XtaskTemplateId).HasColumnName("XTaskTemplateID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaskDescription)
                    .IsRequired()
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.TaskDescriptionTid).HasColumnName("TaskDescriptionTID");

                entity.Property(e => e.TaskSubject)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TaskSubjectTid).HasColumnName("TaskSubjectTID");

                entity.Property(e => e.XtaskTemplateTs)
                    .IsRequired()
                    .HasColumnName("XTaskTemplateTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XtaskTypeAction>(entity =>
            {
                entity.ToTable("XTaskTypeAction");

                entity.Property(e => e.XtaskTypeActionId).HasColumnName("XTaskTypeActionID");

                entity.Property(e => e.Betreff).IsUnicode(false);

                entity.Property(e => e.BetreffTid).HasColumnName("BetreffTID");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.BezeichnungTid).HasColumnName("BezeichnungTID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Text).IsUnicode(false);

                entity.Property(e => e.TextTid).HasColumnName("TextTID");

                entity.Property(e => e.XtaskTypeActionTs)
                    .IsRequired()
                    .HasColumnName("XTaskTypeActionTS")
                    .IsRowVersion();

                entity.Property(e => e.XtaskTypeActionTypeCode).HasColumnName("XTaskTypeActionTypeCode");
            });

            modelBuilder.Entity<XtranslateColumn>(entity =>
            {
                entity.ToTable("XTranslateColumn");

                entity.HasIndex(e => new { e.TableName, e.ColumnName })
                    .HasName("UK_XTranslateColumn_TableName_ColumnName")
                    .IsUnique();

                entity.Property(e => e.XtranslateColumnId).HasColumnName("XTranslateColumnID");

                entity.Property(e => e.ColumnName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TidcolumnName)
                    .IsRequired()
                    .HasColumnName("TIDColumnName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.XtranslateColumnTs)
                    .IsRequired()
                    .HasColumnName("XTranslateColumnTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XtypeConfig>(entity =>
            {
                entity.ToTable("XTypeConfig");

                entity.HasIndex(e => new { e.LookupTypeNamespace, e.LookupTypeName })
                    .HasName("UK_XTypeConfig_LookupTypeNamespace_LookupTypeName")
                    .IsUnique();

                entity.Property(e => e.XtypeConfigId).HasColumnName("XTypeConfigID");

                entity.Property(e => e.ConcreteCustomTypeAssemblyName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ConcreteCustomTypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ConcreteCustomTypeNamespace)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ConcreteStandardTypeAssemblyName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ConcreteStandardTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ConcreteStandardTypeNamespace)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.InstanceScopeCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.LookupTypeAssemblyName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LookupTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LookupTypeNamespace)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.XtypeConfigTs)
                    .IsRequired()
                    .HasColumnName("XTypeConfigTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XUser>(entity =>
            {
                entity.HasKey(e => e.UserID);

                entity.ToTable("XUser");

                entity.HasIndex(e => e.ChiefId);

                entity.HasIndex(e => e.GrantPermGroupId);

                entity.HasIndex(e => e.LogonName)
                    .HasName("UK_XUser_LogonName")
                    .IsUnique();

                entity.HasIndex(e => e.PermissionGroupId);

                entity.HasIndex(e => e.PrimaryUserId);

                entity.HasIndex(e => e.SachbearbeiterId);

                entity.HasIndex(e => e.XprofileId);

                entity.HasIndex(e => new { e.LastName, e.FirstName });

                entity.HasIndex(e => new { e.UserID, e.IsUserAdmin, e.IsUserBiagadmin });

                entity.HasIndex(e => new { e.UserID, e.LastName, e.FirstName, e.LogonName });

                entity.HasIndex(e => new { e.UserID, e.LastName, e.FirstName, e.ShortName, e.LogonName });

                entity.HasIndex(e => new { e.UserID, e.LogonName, e.FirstName, e.LastName, e.IsLocked })
                    .HasName("IX_XUser_IsLocked");

                entity.HasIndex(e => new { e.UserID, e.MitarbeiterNr, e.FirstName, e.LastName, e.IsUserAdmin });

                entity.HasIndex(e => new { e.UserID, e.MitarbeiterNr, e.FirstName, e.LastName, e.LohntypCode });

                entity.Property(e => e.UserID).HasColumnName("UserID");

                entity.Property(e => e.Austrittsdatum).HasColumnType("datetime");

                entity.Property(e => e.Bemerkungen)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ChiefId).HasColumnName("ChiefID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Eintrittsdatum).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Funktion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Geburtstag).HasColumnType("datetime");

                entity.Property(e => e.GrantPermGroupId).HasColumnName("GrantPermGroupID");

                entity.Property(e => e.IsUserBiagadmin).HasColumnName("IsUserBIAGAdmin");

                entity.Property(e => e.KeinBdeexport).HasColumnName("KeinBDEExport");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LogonName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MigHerkunft)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MigMakuerzel)
                    .HasColumnName("MigMAKuerzel")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MitarbeiterNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModulId).HasColumnName("ModulID");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([dbo].[fnXGetUserRNDPwd](newid()))");

                entity.Property(e => e.PermissionGroupId).HasColumnName("PermissionGroupID");

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneIntern)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneMobile)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneOffice)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhonePrivat)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrimaryUserId).HasColumnName("PrimaryUserID");

                entity.Property(e => e.SachbearbeiterId).HasColumnName("SachbearbeiterID");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Text1)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Text2)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.Visdat36Area)
                    .HasColumnName("visdat36Area")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Visdat36Id)
                    .HasColumnName("visdat36ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Visdat36Name)
                    .HasColumnName("visdat36Name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Visdat36SourceFile)
                    .HasColumnName("visdat36SourceFile")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WeitereKostentraeger)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.XprofileId).HasColumnName("XProfileID");

                entity.Property(e => e.XUserTs)
                    .IsRequired()
                    .HasColumnName("XUserTS")
                    .IsRowVersion();

                entity.HasOne(d => d.Chief)
                    .WithMany(p => p.InverseChief)
                    .HasForeignKey(d => d.ChiefId);

                entity.HasOne(d => d.GrantPermGroup)
                    .WithMany(p => p.XuserGrantPermGroup)
                    .HasForeignKey(d => d.GrantPermGroupId);

                entity.HasOne(d => d.Modul)
                    .WithMany(p => p.Xuser)
                    .HasForeignKey(d => d.ModulId)
                    .HasConstraintName("FK_XUser_XModul");

                entity.HasOne(d => d.PermissionGroup)
                    .WithMany(p => p.XuserPermissionGroup)
                    .HasForeignKey(d => d.PermissionGroupId);

                entity.HasOne(d => d.PrimaryUser)
                    .WithMany(p => p.InversePrimaryUser)
                    .HasForeignKey(d => d.PrimaryUserId);

                entity.HasOne(d => d.Sachbearbeiter)
                    .WithMany(p => p.InverseSachbearbeiter)
                    .HasForeignKey(d => d.SachbearbeiterId);

                entity.HasOne(d => d.Xprofile)
                    .WithMany(p => p.Xuser)
                    .HasForeignKey(d => d.XprofileId)
                    .HasConstraintName("FK_XUser_XProfile");
            });

            modelBuilder.Entity<XuserArchive>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ArchiveId });

                entity.ToTable("XUser_Archive");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ArchiveId).HasColumnName("ArchiveID");

                entity.Property(e => e.XuserArchiveTs)
                    .IsRequired()
                    .HasColumnName("XUser_ArchiveTS")
                    .IsRowVersion();

                entity.HasOne(d => d.Archive)
                    .WithMany(p => p.XuserArchive)
                    .HasForeignKey(d => d.ArchiveId)
                    .HasConstraintName("FK_XUser_Archive_XArchive");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.XuserArchive)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_XUser_Archive_XUser");
            });

            modelBuilder.Entity<XuserBdeuserGroup>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BdeuserGroupId });

                entity.ToTable("XUser_BDEUserGroup");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.BdeuserGroupId).HasColumnName("BDEUserGroupID");

                entity.Property(e => e.XuserBdeuserGroupTs)
                    .IsRequired()
                    .HasColumnName("XUser_BDEUserGroupTS")
                    .IsRowVersion();

                entity.HasOne(d => d.BdeuserGroup)
                    .WithMany(p => p.XuserBdeuserGroup)
                    .HasForeignKey(d => d.BdeuserGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XUser_UserGroup_BDEUserGroup");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.XuserBdeuserGroup)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_XUser_BDEUserGroup_XUser");
            });

            modelBuilder.Entity<XUserGroup>(entity =>
            {
                entity.HasKey(e => e.UserGroupId);

                entity.ToTable("XUserGroup");

                entity.Property(e => e.UserGroupId).HasColumnName("UserGroupID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.DescriptionTid).HasColumnName("DescriptionTID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserGroupName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserGroupNameTid).HasColumnName("UserGroupNameTID");

                entity.Property(e => e.XuserGroupTs)
                    .IsRequired()
                    .HasColumnName("XUserGroupTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<XUserGroupRight>(entity =>
            {
                entity.HasKey(e => e.UserGroupRightId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("XUserGroup_Right");

                entity.HasIndex(e => e.ClassName);

                entity.HasIndex(e => e.MaskName);

                entity.HasIndex(e => e.QueryName);

                entity.HasIndex(e => e.UserGroupId)
                    .HasName("IX_XUserGroup_Right")
                    .ForSqlServerIsClustered();

                entity.HasIndex(e => e.XclassId);

                entity.Property(e => e.UserGroupRightId).HasColumnName("UserGroup_RightID");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaskName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QueryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RightId).HasColumnName("RightID");

                entity.Property(e => e.UserGroupId).HasColumnName("UserGroupID");

                entity.Property(e => e.XclassId).HasColumnName("XClassID");

                entity.Property(e => e.XuserGroupRightTs)
                    .IsRequired()
                    .HasColumnName("XUserGroup_RightTS")
                    .IsRowVersion();

                entity.HasOne(d => d.MaskNameNavigation)
                    .WithMany(p => p.XuserGroupRight)
                    .HasForeignKey(d => d.MaskName)
                    .HasConstraintName("FK_XUserGroup_Right_DynaMask");

                entity.HasOne(d => d.QueryNameNavigation)
                    .WithMany(p => p.XuserGroupRight)
                    .HasForeignKey(d => d.QueryName)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_XUserGroup_Right_XQuery");

                entity.HasOne(d => d.Right)
                    .WithMany(p => p.XuserGroupRight)
                    .HasForeignKey(d => d.RightId)
                    .HasConstraintName("FK_XUserGroup_Right_XRight");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.XuserGroupRight)
                    .HasForeignKey(d => d.UserGroupId)
                    .HasConstraintName("FK_XUserGroup_Right_XUserGroup");

                entity.HasOne(d => d.XClass)
                    .WithMany(p => p.XuserGroupRight)
                    .HasForeignKey(d => d.XclassId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_XUserGroup_Right_XClass");
            });

            modelBuilder.Entity<XuserStundenansatz>(entity =>
            {
                entity.ToTable("XUserStundenansatz");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.XuserStundenansatzId).HasColumnName("XUserStundenansatzID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lohnart1).HasColumnType("money");

                entity.Property(e => e.Lohnart10).HasColumnType("money");

                entity.Property(e => e.Lohnart11).HasColumnType("money");

                entity.Property(e => e.Lohnart12).HasColumnType("money");

                entity.Property(e => e.Lohnart13).HasColumnType("money");

                entity.Property(e => e.Lohnart14).HasColumnType("money");

                entity.Property(e => e.Lohnart15).HasColumnType("money");

                entity.Property(e => e.Lohnart16).HasColumnType("money");

                entity.Property(e => e.Lohnart17).HasColumnType("money");

                entity.Property(e => e.Lohnart18).HasColumnType("money");

                entity.Property(e => e.Lohnart19).HasColumnType("money");

                entity.Property(e => e.Lohnart2).HasColumnType("money");

                entity.Property(e => e.Lohnart20).HasColumnType("money");

                entity.Property(e => e.Lohnart3).HasColumnType("money");

                entity.Property(e => e.Lohnart4).HasColumnType("money");

                entity.Property(e => e.Lohnart5).HasColumnType("money");

                entity.Property(e => e.Lohnart6).HasColumnType("money");

                entity.Property(e => e.Lohnart7).HasColumnType("money");

                entity.Property(e => e.Lohnart8).HasColumnType("money");

                entity.Property(e => e.Lohnart9).HasColumnType("money");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VerId).HasColumnName("VerID");

                entity.Property(e => e.XuserStundenansatzTs)
                    .IsRequired()
                    .HasColumnName("XUserStundenansatzTS")
                    .IsRowVersion();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.XuserStundenansatz)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_XUserStundenansatz_XUser");
            });

            modelBuilder.Entity<XUserUserGroup>(entity =>
            {
                entity.ToTable("XUser_UserGroup");

                entity.HasIndex(e => new { e.UserGroupId, e.UserId })
                    .HasName("IX_XUser_UserGroup_UserGroupID");

                entity.HasIndex(e => new { e.UserId, e.UserGroupId })
                    .HasName("UK_XUser_UserGroup_UserID_UserGroupID")
                    .IsUnique();

                entity.Property(e => e.XuserUserGroupId).HasColumnName("XUser_UserGroupID");

                entity.Property(e => e.UserGroupId).HasColumnName("UserGroupID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.XuserUserGroupTs)
                    .IsRequired()
                    .HasColumnName("XUser_UserGroupTS")
                    .IsRowVersion();

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.XUserUserGroup)
                    .HasForeignKey(d => d.UserGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_XUser_UserGroup_XUserGroup");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.XuserUserGroup)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_XUser_UserGroup_XUser");
            });

            modelBuilder.Entity<XuserXdocTemplate>(entity =>
            {
                entity.ToTable("XUser_XDocTemplate");

                entity.HasIndex(e => e.DocTemplateId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.XuserXdocTemplateId).HasColumnName("XUser_XDocTemplateID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocTemplateId).HasColumnName("DocTemplateID");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.XuserXdocTemplateTs)
                    .IsRequired()
                    .HasColumnName("XUser_XDocTemplateTS")
                    .IsRowVersion();

                entity.HasOne(d => d.DocTemplate)
                    .WithMany(p => p.XuserXdocTemplate)
                    .HasForeignKey(d => d.DocTemplateId)
                    .HasConstraintName("FK_XUser_XDocTemplate_XDocTemplate");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.XuserXdocTemplate)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_XUser_XDocTemplate_XUser");

                CreateQueryTypeModels(modelBuilder);
            });
        }
    }
}