namespace Kiss4Web.Test.DataAccess
{
    using System.Data.Entity;

    public partial class KissContext : DbContext
    {
        public KissContext()
            : base("name=KissDBConnection")
        {
        }

        public virtual DbSet<BaAdresse> BaAdresses { get; set; }
        public virtual DbSet<BaArbeit> BaArbeits { get; set; }
        public virtual DbSet<BaArbeitAusbildung> BaArbeitAusbildungs { get; set; }
        public virtual DbSet<BaBank> BaBanks { get; set; }
        public virtual DbSet<BaBeruf> BaBerufs { get; set; }
        public virtual DbSet<BaEinwohnerregisterPersonStatu> BaEinwohnerregisterPersonStatus { get; set; }
        public virtual DbSet<BaGemeinde> BaGemeindes { get; set; }
        public virtual DbSet<BaGesundheit> BaGesundheits { get; set; }
        public virtual DbSet<BaInstitution> BaInstitutions { get; set; }
        public virtual DbSet<BaInstitution_BaInstitutionTyp> BaInstitution_BaInstitutionTyp { get; set; }
        public virtual DbSet<BaInstitutionDokument> BaInstitutionDokuments { get; set; }
        public virtual DbSet<BaInstitutionKontakt> BaInstitutionKontakts { get; set; }
        public virtual DbSet<BaInstitutionTyp> BaInstitutionTyps { get; set; }
        public virtual DbSet<BaKantonalerZuschuss> BaKantonalerZuschusses { get; set; }
        public virtual DbSet<BaKopfquote> BaKopfquotes { get; set; }
        public virtual DbSet<BaLand> BaLands { get; set; }
        public virtual DbSet<BaMietvertrag> BaMietvertrags { get; set; }
        public virtual DbSet<BaPerson> BaPersons { get; set; }
        public virtual DbSet<BaPersonBaInstitution> BaPerson_BaInstitution { get; set; }
        public virtual DbSet<BaPerson_KantonalerZuschuss> BaPerson_KantonalerZuschuss { get; set; }
        public virtual DbSet<BaPerson_Relation> BaPerson_Relation { get; set; }
        public virtual DbSet<BaPLZ> BaPLZs { get; set; }
        public virtual DbSet<BaPraemienverbilligung> BaPraemienverbilligungs { get; set; }
        public virtual DbSet<BaRelation> BaRelations { get; set; }
        public virtual DbSet<BaWVCode> BaWVCodes { get; set; }
        public virtual DbSet<BaZahlungsweg> BaZahlungswegs { get; set; }
        public virtual DbSet<BDEAusbezahlteUeberstunden_XUser> BDEAusbezahlteUeberstunden_XUser { get; set; }
        public virtual DbSet<BDEFerienanspruch_XUser> BDEFerienanspruch_XUser { get; set; }
        public virtual DbSet<BDEFerienkuerzungen_XUser> BDEFerienkuerzungen_XUser { get; set; }
        public virtual DbSet<BDELeistung> BDELeistungs { get; set; }
        public virtual DbSet<BDELeistungsart> BDELeistungsarts { get; set; }
        public virtual DbSet<BDEPensum_XUser> BDEPensum_XUser { get; set; }
        public virtual DbSet<BDESollProTag_XUser> BDESollProTag_XUser { get; set; }
        public virtual DbSet<BDESollStundenProJahr_XUser> BDESollStundenProJahr_XUser { get; set; }
        public virtual DbSet<BDEUserGroup> BDEUserGroups { get; set; }
        public virtual DbSet<BDEUserGroup_BDELeistungsart> BDEUserGroup_BDELeistungsart { get; set; }
        public virtual DbSet<BDEZeitrechner> BDEZeitrechners { get; set; }
        public virtual DbSet<BFSDossier> BFSDossiers { get; set; }
        public virtual DbSet<BFSDossierPerson> BFSDossierPersons { get; set; }
        public virtual DbSet<BFSFarbCode> BFSFarbCodes { get; set; }
        public virtual DbSet<BFSFrage> BFSFrages { get; set; }
        public virtual DbSet<BFSKatalogVersion> BFSKatalogVersions { get; set; }
        public virtual DbSet<BFSLOV> BFSLOVs { get; set; }
        public virtual DbSet<BFSLOVCode> BFSLOVCodes { get; set; }
        public virtual DbSet<BFSWert> BFSWerts { get; set; }
        public virtual DbSet<BgAuszahlungPerson> BgAuszahlungPersons { get; set; }
        public virtual DbSet<BgAuszahlungPersonTermin> BgAuszahlungPersonTermins { get; set; }
        public virtual DbSet<BgBewilligung> BgBewilligungs { get; set; }
        public virtual DbSet<BgBudget> BgBudgets { get; set; }
        public virtual DbSet<BgDokument> BgDokuments { get; set; }
        public virtual DbSet<BgFinanzplan> BgFinanzplans { get; set; }
        public virtual DbSet<BgFinanzplan_BaPerson> BgFinanzplan_BaPerson { get; set; }
        public virtual DbSet<BgGruppe_BFSFrage> BgGruppe_BFSFrage { get; set; }
        public virtual DbSet<BgKostenart> BgKostenarts { get; set; }
        public virtual DbSet<BgKostenart_WhGefKategorie> BgKostenart_WhGefKategorie { get; set; }
        public virtual DbSet<BgPosition> BgPositions { get; set; }
        public virtual DbSet<BgPositionsart> BgPositionsarts { get; set; }
        public virtual DbSet<BgPositionsartBuchungstext> BgPositionsartBuchungstexts { get; set; }
        public virtual DbSet<BgSpezkonto> BgSpezkontoes { get; set; }
        public virtual DbSet<BgSpezkontoAbschluss> BgSpezkontoAbschlusses { get; set; }
        public virtual DbSet<BgZahlungsmodu> BgZahlungsmodus { get; set; }
        public virtual DbSet<BgZahlungsmodusTermin> BgZahlungsmodusTermins { get; set; }
        public virtual DbSet<DynaField> DynaFields { get; set; }
        public virtual DbSet<DynaMask> DynaMasks { get; set; }
        public virtual DbSet<DynaValue> DynaValues { get; set; }
        public virtual DbSet<FaAktennotizen> FaAktennotizens { get; set; }
        public virtual DbSet<FaDokumentAblage> FaDokumentAblages { get; set; }
        public virtual DbSet<FaDokumentAblageBaPerson> FaDokumentAblage_BaPerson { get; set; }
        public virtual DbSet<FaDokumente> FaDokumentes { get; set; }
        public virtual DbSet<FaKategorisierung> FaKategorisierungs { get; set; }
        public virtual DbSet<FaKategorisierungEksProdukt> FaKategorisierungEksProdukts { get; set; }
        public virtual DbSet<FaLeistung> FaLeistungs { get; set; }
        public virtual DbSet<FaLeistungArchiv> FaLeistungArchivs { get; set; }
        public virtual DbSet<FaLeistungBewertung> FaLeistungBewertungs { get; set; }
        public virtual DbSet<FaLeistungUserHist> FaLeistungUserHists { get; set; }
        public virtual DbSet<FaLeistungZugriff> FaLeistungZugriffs { get; set; }
        public virtual DbSet<FaPendenzgruppe> FaPendenzgruppes { get; set; }
        public virtual DbSet<FaPendenzgruppe_User> FaPendenzgruppe_User { get; set; }
        public virtual DbSet<FaPhase> FaPhases { get; set; }
        public virtual DbSet<FaRelation> FaRelations { get; set; }
        public virtual DbSet<FaWeisung> FaWeisungs { get; set; }
        public virtual DbSet<FaWeisung_BaPerson> FaWeisung_BaPerson { get; set; }
        public virtual DbSet<FaWeisungProtokoll> FaWeisungProtokolls { get; set; }
        public virtual DbSet<FaWeisungWorkflow> FaWeisungWorkflows { get; set; }
        public virtual DbSet<FaZeitlichePlanung> FaZeitlichePlanungs { get; set; }
        public virtual DbSet<FbBarauszahlungAuftrag> FbBarauszahlungAuftrags { get; set; }
        public virtual DbSet<FbBarauszahlungAusbezahlt> FbBarauszahlungAusbezahlts { get; set; }
        public virtual DbSet<FbBarauszahlungZyklu> FbBarauszahlungZyklus { get; set; }
        public virtual DbSet<FbBelegNr> FbBelegNrs { get; set; }
        public virtual DbSet<FbBuchung> FbBuchungs { get; set; }
        public virtual DbSet<FbBuchungCode> FbBuchungCodes { get; set; }
        public virtual DbSet<FbBuchungskrei> FbBuchungskreis { get; set; }
        public virtual DbSet<FbDauerauftrag> FbDauerauftrags { get; set; }
        public virtual DbSet<FbDTABuchung> FbDTABuchungs { get; set; }
        public virtual DbSet<FbDTAJournal> FbDTAJournals { get; set; }
        public virtual DbSet<FbDTAZugang> FbDTAZugangs { get; set; }
        public virtual DbSet<FbKonto> FbKontoes { get; set; }
        public virtual DbSet<FbKreditor> FbKreditors { get; set; }
        public virtual DbSet<FbPeriode> FbPeriodes { get; set; }
        public virtual DbSet<FbTeam> FbTeams { get; set; }
        public virtual DbSet<FbTeamMitglied> FbTeamMitglieds { get; set; }
        public virtual DbSet<FbZahlungsweg> FbZahlungswegs { get; set; }
        public virtual DbSet<FsDienstleistung> FsDienstleistungs { get; set; }
        public virtual DbSet<FsDienstleistung_FsDienstleistungspaket> FsDienstleistung_FsDienstleistungspaket { get; set; }
        public virtual DbSet<FsDienstleistungspaket> FsDienstleistungspakets { get; set; }
        public virtual DbSet<FsReduktion> FsReduktions { get; set; }
        public virtual DbSet<FsReduktionMitarbeiter> FsReduktionMitarbeiters { get; set; }
        public virtual DbSet<GvAbklaerendeStelle> GvAbklaerendeStelles { get; set; }
        public virtual DbSet<GvAntragPosition> GvAntragPositions { get; set; }
        public virtual DbSet<GvAuflage> GvAuflages { get; set; }
        public virtual DbSet<GvAuszahlungPosition> GvAuszahlungPositions { get; set; }
        public virtual DbSet<GvAuszahlungPositionValuta> GvAuszahlungPositionValutas { get; set; }
        public virtual DbSet<GvBewilligung> GvBewilligungs { get; set; }
        public virtual DbSet<GvDocument> GvDocuments { get; set; }
        public virtual DbSet<GvDokumenteInformation> GvDokumenteInformations { get; set; }
        public virtual DbSet<GvFond> GvFonds { get; set; }
        public virtual DbSet<GvFonds_XOrgUnit> GvFonds_XOrgUnit { get; set; }
        public virtual DbSet<GvGesuch> GvGesuches { get; set; }
        public virtual DbSet<GvPositionsart> GvPositionsarts { get; set; }
        public virtual DbSet<Hist_BaAdresse> Hist_BaAdresse { get; set; }
        public virtual DbSet<Hist_BaPerson> Hist_BaPerson { get; set; }
        public virtual DbSet<Hist_BDEFerienkuerzungen_XUser> Hist_BDEFerienkuerzungen_XUser { get; set; }
        public virtual DbSet<Hist_BDELeistung> Hist_BDELeistung { get; set; }
        public virtual DbSet<Hist_BDELeistungsart> Hist_BDELeistungsart { get; set; }
        public virtual DbSet<Hist_BDESollStundenProJahr_XUser> Hist_BDESollStundenProJahr_XUser { get; set; }
        public virtual DbSet<Hist_XOrgUnit> Hist_XOrgUnit { get; set; }
        public virtual DbSet<Hist_XOrgUnit_User> Hist_XOrgUnit_User { get; set; }
        public virtual DbSet<Hist_XUser> Hist_XUser { get; set; }
        public virtual DbSet<Hist_XUserStundenansatz> Hist_XUserStundenansatz { get; set; }
        public virtual DbSet<HistoryVersion> HistoryVersions { get; set; }
        public virtual DbSet<IkAbklaerung> IkAbklaerungs { get; set; }
        public virtual DbSet<IkAnzeige> IkAnzeiges { get; set; }
        public virtual DbSet<IkBetreibung> IkBetreibungs { get; set; }
        public virtual DbSet<IkBetreibungAusgleich> IkBetreibungAusgleiches { get; set; }
        public virtual DbSet<IkEinkomman> IkEinkommen { get; set; }
        public virtual DbSet<IkForderung> IkForderungs { get; set; }
        public virtual DbSet<IkForderung_BgKostenart> IkForderung_BgKostenart { get; set; }
        public virtual DbSet<IkForderungBgKostenartHist> IkForderungBgKostenartHists { get; set; }
        public virtual DbSet<IkForderungPosition> IkForderungPositions { get; set; }
        public virtual DbSet<IkGlaeubiger> IkGlaeubigers { get; set; }
        public virtual DbSet<IkLandesindex> IkLandesindexes { get; set; }
        public virtual DbSet<IkLandesindexWert> IkLandesindexWerts { get; set; }
        public virtual DbSet<IkPosition> IkPositions { get; set; }
        public virtual DbSet<IkRatenplan> IkRatenplans { get; set; }
        public virtual DbSet<IkRatenplanForderung> IkRatenplanForderungs { get; set; }
        public virtual DbSet<IkRechtstitel> IkRechtstitels { get; set; }
        public virtual DbSet<IkVerrechnungskonto> IkVerrechnungskontoes { get; set; }
        public virtual DbSet<KaAbklaerungIntake> KaAbklaerungIntakes { get; set; }
        public virtual DbSet<KaAbklaerungVertieft> KaAbklaerungVertiefts { get; set; }
        public virtual DbSet<KaAbklaerungVertieftProbeeinsatz> KaAbklaerungVertieftProbeeinsatzs { get; set; }
        public virtual DbSet<KaAKZuweiser> KaAKZuweisers { get; set; }
        public virtual DbSet<KaAllgemein> KaAllgemeins { get; set; }
        public virtual DbSet<KaAmmBesch> KaAmmBesches { get; set; }
        public virtual DbSet<KaArbeitsrapport> KaArbeitsrapports { get; set; }
        public virtual DbSet<KaAssistenz> KaAssistenzs { get; set; }
        public virtual DbSet<KaAusbildung> KaAusbildungs { get; set; }
        public virtual DbSet<KaBetrieb> KaBetriebs { get; set; }
        public virtual DbSet<KaBetriebBesprechung> KaBetriebBesprechungs { get; set; }
        public virtual DbSet<KaBetriebDokument> KaBetriebDokuments { get; set; }
        public virtual DbSet<KaBetriebKontakt> KaBetriebKontakts { get; set; }
        public virtual DbSet<KaEafSozioberuflicheBilanz> KaEafSozioberuflicheBilanzs { get; set; }
        public virtual DbSet<KaEafSpezifischeErmittlung> KaEafSpezifischeErmittlungs { get; set; }
        public virtual DbSet<KaEinsatz> KaEinsatzs { get; set; }
        public virtual DbSet<KaEinsatzplatz> KaEinsatzplatzs { get; set; }
        public virtual DbSet<KaEinsatzplatz2> KaEinsatzplatz2 { get; set; }
        public virtual DbSet<KaExterneBildung> KaExterneBildungs { get; set; }
        public virtual DbSet<KaExterneBildungZahlung> KaExterneBildungZahlungs { get; set; }
        public virtual DbSet<KaInizio> KaInizios { get; set; }
        public virtual DbSet<KaIntegBildung> KaIntegBildungs { get; set; }
        public virtual DbSet<KaJobtimal> KaJobtimals { get; set; }
        public virtual DbSet<KaJobtimalVertrag> KaJobtimalVertrags { get; set; }
        public virtual DbSet<KaKontaktartProzess> KaKontaktartProzesses { get; set; }
        public virtual DbSet<KaKur> KaKurs { get; set; }
        public virtual DbSet<KaKurserfassung> KaKurserfassungs { get; set; }
        public virtual DbSet<KaQEEPQ> KaQEEPQs { get; set; }
        public virtual DbSet<KaQEEPQZielvereinb> KaQEEPQZielvereinbs { get; set; }
        public virtual DbSet<KaQEEPQZielvereinbVerl> KaQEEPQZielvereinbVerls { get; set; }
        public virtual DbSet<KaQEJobtimum> KaQEJobtimums { get; set; }
        public virtual DbSet<KaQJBildung> KaQJBildungs { get; set; }
        public virtual DbSet<KaQJIntake> KaQJIntakes { get; set; }
        public virtual DbSet<KaQJIntakeGespraech> KaQJIntakeGespraeches { get; set; }
        public virtual DbSet<KaQJProzess> KaQJProzesses { get; set; }
        public virtual DbSet<KaQJPZAssessment> KaQJPZAssessments { get; set; }
        public virtual DbSet<KaQJPZBericht> KaQJPZBerichts { get; set; }
        public virtual DbSet<KaQJPZSchlussbericht> KaQJPZSchlussberichts { get; set; }
        public virtual DbSet<KaQJPZZielvereinbarung> KaQJPZZielvereinbarungs { get; set; }
        public virtual DbSet<KaQJVereinbarung> KaQJVereinbarungs { get; set; }
        public virtual DbSet<KaSequenzen> KaSequenzens { get; set; }
        public virtual DbSet<KaTransfer> KaTransfers { get; set; }
        public virtual DbSet<KaTransferZielvereinb> KaTransferZielvereinbs { get; set; }
        public virtual DbSet<KaVerlauf> KaVerlaufs { get; set; }
        public virtual DbSet<KaVermittlungBIBIP> KaVermittlungBIBIPs { get; set; }
        public virtual DbSet<KaVermittlungEinsatz> KaVermittlungEinsatzs { get; set; }
        public virtual DbSet<KaVermittlungProfil> KaVermittlungProfils { get; set; }
        public virtual DbSet<KaVermittlungSI> KaVermittlungSIs { get; set; }
        public virtual DbSet<KaVermittlungSIZwischenbericht> KaVermittlungSIZwischenberichts { get; set; }
        public virtual DbSet<KaVermittlungVorschlag> KaVermittlungVorschlags { get; set; }
        public virtual DbSet<KaZuteilFachbereich> KaZuteilFachbereiches { get; set; }
        public virtual DbSet<KbBelegKrei> KbBelegKreis { get; set; }
        public virtual DbSet<KbBuchung> KbBuchungs { get; set; }
        public virtual DbSet<KbBuchungKostenart> KbBuchungKostenarts { get; set; }
        public virtual DbSet<KbForderungAuszahlung> KbForderungAuszahlungs { get; set; }
        public virtual DbSet<KbFreieBelegNummer> KbFreieBelegNummers { get; set; }
        public virtual DbSet<KbKonto> KbKontoes { get; set; }
        public virtual DbSet<KbKostenstelle> KbKostenstelles { get; set; }
        public virtual DbSet<KbKostenstelle_BaPerson> KbKostenstelle_BaPerson { get; set; }
        public virtual DbSet<KbMandant> KbMandants { get; set; }
        public virtual DbSet<KbOpAusgleich> KbOpAusgleiches { get; set; }
        public virtual DbSet<KbPeriode> KbPeriodes { get; set; }
        public virtual DbSet<KbPeriode_User> KbPeriode_User { get; set; }
        public virtual DbSet<KbTransfer> KbTransfers { get; set; }
        public virtual DbSet<KbWVEinzelposten> KbWVEinzelpostens { get; set; }
        public virtual DbSet<KbWVEinzelpostenFehler> KbWVEinzelpostenFehlers { get; set; }
        public virtual DbSet<KbWVLauf> KbWVLaufs { get; set; }
        public virtual DbSet<KbZahlungseingang> KbZahlungseingangs { get; set; }
        public virtual DbSet<KbZahlungskonto> KbZahlungskontoes { get; set; }
        public virtual DbSet<KbZahlungskonto_XOrgUnit> KbZahlungskonto_XOrgUnit { get; set; }
        public virtual DbSet<KbZahlungslauf> KbZahlungslaufs { get; set; }
        public virtual DbSet<KbZahlungslaufValuta> KbZahlungslaufValutas { get; set; }
        public virtual DbSet<KesArtikel> KesArtikels { get; set; }
        public virtual DbSet<KesAuftrag> KesAuftrags { get; set; }
        public virtual DbSet<KesAuftrag_BaPerson> KesAuftrag_BaPerson { get; set; }
        public virtual DbSet<KesBehoerde> KesBehoerdes { get; set; }
        public virtual DbSet<KesDokument> KesDokuments { get; set; }
        public virtual DbSet<KesMandatsfuehrendePerson> KesMandatsfuehrendePersons { get; set; }
        public virtual DbSet<KesMassnahme> KesMassnahmes { get; set; }
        public virtual DbSet<KesMassnahme_KesArtikel> KesMassnahme_KesArtikel { get; set; }
        public virtual DbSet<KesMassnahmeAuftrag> KesMassnahmeAuftrags { get; set; }
        public virtual DbSet<KesMassnahmeBericht> KesMassnahmeBerichts { get; set; }
        public virtual DbSet<KesMassnahmeBSS> KesMassnahmeBSSes { get; set; }
        public virtual DbSet<KesPflegekinderaufsicht> KesPflegekinderaufsichts { get; set; }
        public virtual DbSet<KesPraevention> KesPraeventions { get; set; }
        public virtual DbSet<KesVerlauf> KesVerlaufs { get; set; }
        public virtual DbSet<MigAssignment> MigAssignments { get; set; }
        public virtual DbSet<MigLog> MigLogs { get; set; }
        public virtual DbSet<MigLookup> MigLookups { get; set; }
        public virtual DbSet<NewodPerson> NewodPersons { get; set; }
        public virtual DbSet<ShEinzelzahlung> ShEinzelzahlungs { get; set; }
        public virtual DbSet<SstASVSExport> SstASVSExports { get; set; }
        public virtual DbSet<SstASVSExport_Eintrag> SstASVSExport_Eintrag { get; set; }
        public virtual DbSet<SstNewodMapping> SstNewodMappings { get; set; }
        public virtual DbSet<SstNewodMutation> SstNewodMutations { get; set; }
        public virtual DbSet<VmAHVMindestbeitrag> VmAHVMindestbeitrags { get; set; }
        public virtual DbSet<VmAntragEKSK> VmAntragEKSKs { get; set; }
        public virtual DbSet<VmBericht> VmBerichts { get; set; }
        public virtual DbSet<VmBeschwerdeAnfrage> VmBeschwerdeAnfrages { get; set; }
        public virtual DbSet<VmBewertung> VmBewertungs { get; set; }
        public virtual DbSet<VmBudget> VmBudgets { get; set; }
        public virtual DbSet<VmELKrankheitskosten> VmELKrankheitskostens { get; set; }
        public virtual DbSet<VmErbe> VmErbes { get; set; }
        public virtual DbSet<VmErblasser> VmErblassers { get; set; }
        public virtual DbSet<VmErbschaftsdienst> VmErbschaftsdiensts { get; set; }
        public virtual DbSet<VmErnennung> VmErnennungs { get; set; }
        public virtual DbSet<VmGefaehrdungsMeldung> VmGefaehrdungsMeldungs { get; set; }
        public virtual DbSet<VmInventar> VmInventars { get; set; }
        public virtual DbSet<VmKlientenbudget> VmKlientenbudgets { get; set; }
        public virtual DbSet<VmMandant> VmMandants { get; set; }
        public virtual DbSet<VmMandBericht> VmMandBerichts { get; set; }
        public virtual DbSet<VmMassnahme> VmMassnahmes { get; set; }
        public virtual DbSet<VmPosition> VmPositions { get; set; }
        public virtual DbSet<VmPositionsart> VmPositionsarts { get; set; }
        public virtual DbSet<VmPriMa> VmPriMas { get; set; }
        public virtual DbSet<VmSachversicherung> VmSachversicherungs { get; set; }
        public virtual DbSet<VmSchulden> VmSchuldens { get; set; }
        public virtual DbSet<VmSiegelung> VmSiegelungs { get; set; }
        public virtual DbSet<VmSituationsBericht> VmSituationsBerichts { get; set; }
        public virtual DbSet<VmSozialversicherung> VmSozialversicherungs { get; set; }
        public virtual DbSet<VmSteuern> VmSteuerns { get; set; }
        public virtual DbSet<VmTestament> VmTestaments { get; set; }
        public virtual DbSet<VmTestamentBescheinigung> VmTestamentBescheinigungs { get; set; }
        public virtual DbSet<VmTestamentVerfuegung> VmTestamentVerfuegungs { get; set; }
        public virtual DbSet<VmVaterschaft> VmVaterschafts { get; set; }
        public virtual DbSet<WhASVSEintrag> WhASVSEintrags { get; set; }
        public virtual DbSet<WhGefKategorie> WhGefKategories { get; set; }
        public virtual DbSet<XArchive> XArchives { get; set; }
        public virtual DbSet<XBookmark> XBookmarks { get; set; }
        public virtual DbSet<XClass> XClasses { get; set; }
        public virtual DbSet<XClassComponent> XClassComponents { get; set; }
        public virtual DbSet<XClassControl> XClassControls { get; set; }
        public virtual DbSet<XClassReference> XClassReferences { get; set; }
        public virtual DbSet<XClassRule> XClassRules { get; set; }
        public virtual DbSet<XConfig> XConfigs { get; set; }
        public virtual DbSet<XDBServerVersion> XDBServerVersions { get; set; }
        public virtual DbSet<XDBVersion> XDBVersions { get; set; }
        public virtual DbSet<XDeleteRule> XDeleteRules { get; set; }
        public virtual DbSet<XDocContext> XDocContexts { get; set; }
        public virtual DbSet<XDocContext_Template> XDocContext_Template { get; set; }
        public virtual DbSet<XDocContextType> XDocContextTypes { get; set; }
        public virtual DbSet<XDocTemplate> XDocTemplates { get; set; }
        public virtual DbSet<XDocument> XDocuments { get; set; }
        public virtual DbSet<XHyperlink> XHyperlinks { get; set; }
        public virtual DbSet<XHyperlinkContext> XHyperlinkContexts { get; set; }
        public virtual DbSet<XHyperlinkContext_Hyperlink> XHyperlinkContext_Hyperlink { get; set; }
        public virtual DbSet<XIcon> XIcons { get; set; }
        public virtual DbSet<XLangText> XLangTexts { get; set; }
        public virtual DbSet<XLog> XLogs { get; set; }
        public virtual DbSet<XLOV> XLOVs { get; set; }
        public virtual DbSet<XLOVCode> XLOVCodes { get; set; }
        public virtual DbSet<XMenuItem> XMenuItems { get; set; }
        public virtual DbSet<XMessage> XMessages { get; set; }
        public virtual DbSet<XModul> XModuls { get; set; }
        public virtual DbSet<XModulTree> XModulTrees { get; set; }
        public virtual DbSet<XNamespaceExtension> XNamespaceExtensions { get; set; }
        public virtual DbSet<XOrgUnit> XOrgUnits { get; set; }
        public virtual DbSet<XOrgUnit_User> XOrgUnit_User { get; set; }
        public virtual DbSet<XOrgUnit_XDocTemplate> XOrgUnit_XDocTemplate { get; set; }
        public virtual DbSet<XPermissionGroup> XPermissionGroups { get; set; }
        public virtual DbSet<XPermissionValue> XPermissionValues { get; set; }
        public virtual DbSet<XProfile> XProfiles { get; set; }
        public virtual DbSet<XProfile_XProfileTag> XProfile_XProfileTag { get; set; }
        public virtual DbSet<XProfileTag> XProfileTags { get; set; }
        public virtual DbSet<XQuery> XQueries { get; set; }
        public virtual DbSet<XRight> XRights { get; set; }
        public virtual DbSet<XRule> XRules { get; set; }
        public virtual DbSet<XSearchControlTemplate> XSearchControlTemplates { get; set; }
        public virtual DbSet<XSearchControlTemplateField> XSearchControlTemplateFields { get; set; }
        public virtual DbSet<XTable> XTables { get; set; }
        public virtual DbSet<XTableColumn> XTableColumns { get; set; }
        public virtual DbSet<XTask> XTasks { get; set; }
        public virtual DbSet<XTaskAutoGenerated> XTaskAutoGenerateds { get; set; }
        public virtual DbSet<XTaskTemplate> XTaskTemplates { get; set; }
        public virtual DbSet<XTaskTypeAction> XTaskTypeActions { get; set; }
        public virtual DbSet<XTranslateColumn> XTranslateColumns { get; set; }
        public virtual DbSet<XTypeConfig> XTypeConfigs { get; set; }
        public virtual DbSet<XUser> XUsers { get; set; }
        public virtual DbSet<XUser_Archive> XUser_Archive { get; set; }
        public virtual DbSet<XUser_BDEUserGroup> XUser_BDEUserGroup { get; set; }
        public virtual DbSet<XUser_UserGroup> XUser_UserGroup { get; set; }
        public virtual DbSet<XUser_XDocTemplate> XUser_XDocTemplate { get; set; }
        public virtual DbSet<XUserGroup> XUserGroups { get; set; }
        public virtual DbSet<XUserGroup_Right> XUserGroup_Right { get; set; }
        public virtual DbSet<XUserStundenansatz> XUserStundenansatzs { get; set; }
        public virtual DbSet<BaPerson_NewodPerson> BaPerson_NewodPerson { get; set; }
        public virtual DbSet<dtproperty> dtproperties { get; set; }
        public virtual DbSet<MigXClassFrmToCtl> MigXClassFrmToCtls { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<XPlausiFehler> XPlausiFehlers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Tables
            modelBuilder.Entity<BaAdresse>()
                .Property(e => e.CareOf)
                .IsUnicode(false);

            modelBuilder.Entity<BaAdresse>()
                .Property(e => e.Zusatz)
                .IsUnicode(false);

            modelBuilder.Entity<BaAdresse>()
                .Property(e => e.ZuhandenVon)
                .IsUnicode(false);

            modelBuilder.Entity<BaAdresse>()
                .Property(e => e.Strasse)
                .IsUnicode(false);

            modelBuilder.Entity<BaAdresse>()
                .Property(e => e.HausNr)
                .IsUnicode(false);

            modelBuilder.Entity<BaAdresse>()
                .Property(e => e.Postfach)
                .IsUnicode(false);

            modelBuilder.Entity<BaAdresse>()
                .Property(e => e.PLZ)
                .IsUnicode(false);

            modelBuilder.Entity<BaAdresse>()
                .Property(e => e.Ort)
                .IsUnicode(false);

            modelBuilder.Entity<BaAdresse>()
                .Property(e => e.Kanton)
                .IsUnicode(false);

            modelBuilder.Entity<BaAdresse>()
                .Property(e => e.Bezirk)
                .IsUnicode(false);

            modelBuilder.Entity<BaAdresse>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BaAdresse>()
                .Property(e => e.InstitutionName)
                .IsUnicode(false);

            modelBuilder.Entity<BaAdresse>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BaAdresse>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<BaAdresse>()
                .Property(e => e.BaAdresseTS)
                .IsFixedLength();

            modelBuilder.Entity<BaArbeit>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BaArbeit>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<BaArbeit>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BaArbeit>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<BaArbeit>()
                .Property(e => e.BaArbeitTS)
                .IsFixedLength();

            modelBuilder.Entity<BaArbeitAusbildung>()
                .Property(e => e.Arbeitszeit)
                .HasPrecision(2, 0);

            modelBuilder.Entity<BaArbeitAusbildung>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BaArbeitAusbildung>()
                .Property(e => e.BaArbeitAusbildungTS)
                .IsFixedLength();

            modelBuilder.Entity<BaBank>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BaBank>()
                .Property(e => e.Zusatz)
                .IsUnicode(false);

            modelBuilder.Entity<BaBank>()
                .Property(e => e.Strasse)
                .IsUnicode(false);

            modelBuilder.Entity<BaBank>()
                .Property(e => e.PLZ)
                .IsUnicode(false);

            modelBuilder.Entity<BaBank>()
                .Property(e => e.Ort)
                .IsUnicode(false);

            modelBuilder.Entity<BaBank>()
                .Property(e => e.ClearingNr)
                .IsUnicode(false);

            modelBuilder.Entity<BaBank>()
                .Property(e => e.ClearingNrNeu)
                .IsUnicode(false);

            modelBuilder.Entity<BaBank>()
                .Property(e => e.HauptsitzBCL)
                .IsUnicode(false);

            modelBuilder.Entity<BaBank>()
                .Property(e => e.PCKontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<BaBank>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BaBank>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<BaBank>()
                .Property(e => e.BaBankTS)
                .IsFixedLength();

            modelBuilder.Entity<BaBeruf>()
                .Property(e => e.Beruf)
                .IsUnicode(false);

            modelBuilder.Entity<BaBeruf>()
                .Property(e => e.BezeichnungM)
                .IsUnicode(false);

            modelBuilder.Entity<BaBeruf>()
                .Property(e => e.BezeichnungW)
                .IsUnicode(false);

            modelBuilder.Entity<BaBeruf>()
                .Property(e => e.BaBerufTS)
                .IsFixedLength();

            modelBuilder.Entity<BaEinwohnerregisterPersonStatu>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BaEinwohnerregisterPersonStatu>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<BaEinwohnerregisterPersonStatu>()
                .Property(e => e.BaEinwohnerregisterPersonStatusTS)
                .IsFixedLength();

            modelBuilder.Entity<BaGemeinde>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BaGemeinde>()
                .Property(e => e.NameLang)
                .IsUnicode(false);

            modelBuilder.Entity<BaGemeinde>()
                .Property(e => e.BezirkName)
                .IsUnicode(false);

            modelBuilder.Entity<BaGemeinde>()
                .Property(e => e.BezirkNameLang)
                .IsUnicode(false);

            modelBuilder.Entity<BaGemeinde>()
                .Property(e => e.Kanton)
                .IsUnicode(false);

            modelBuilder.Entity<BaGemeinde>()
                .Property(e => e.KantonNameLang)
                .IsUnicode(false);

            modelBuilder.Entity<BaGemeinde>()
                .Property(e => e.BaGemeindeTS)
                .IsFixedLength();

            modelBuilder.Entity<BaGemeinde>()
                .HasMany(e => e.BaPersons)
                .WithOptional(e => e.BaGemeinde)
                .HasForeignKey(e => e.HeimatgemeindeBaGemeindeID);

            modelBuilder.Entity<BaGemeinde>()
                .HasMany(e => e.BaPersons1)
                .WithOptional(e => e.BaGemeinde1)
                .HasForeignKey(e => e.HeimatgemeindeCode);

            modelBuilder.Entity<BaGemeinde>()
                .HasMany(e => e.BaPersons2)
                .WithOptional(e => e.BaGemeinde2)
                .HasForeignKey(e => e.WegzugOrtCode);

            modelBuilder.Entity<BaGemeinde>()
                .HasMany(e => e.BaPersons3)
                .WithOptional(e => e.BaGemeinde3)
                .HasForeignKey(e => e.ZuzugGdeOrtCode);

            modelBuilder.Entity<BaGemeinde>()
                .HasMany(e => e.BgFinanzplan_BaPerson)
                .WithOptional(e => e.BaGemeinde)
                .HasForeignKey(e => e.BurgergemeindeID);

            modelBuilder.Entity<BaGemeinde>()
                .HasMany(e => e.VmMandants)
                .WithOptional(e => e.BaGemeinde)
                .HasForeignKey(e => e.HeimatgemeindeBaGemeindeID);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.KVGKontaktPerson)
                .IsUnicode(false);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.KVGKontaktTelefon)
                .IsUnicode(false);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.KVGMitgliedNr)
                .IsUnicode(false);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.KVGGrundPraemie)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.KVGUnfallPraemie)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.KVGGesundFoerdPraemie)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.KVGZuschussBetrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.KVGUmweltabgabeBetrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.KVGPraemie)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.KVGFranchise)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.VVGKontaktPerson)
                .IsUnicode(false);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.VVGKontaktTelefon)
                .IsUnicode(false);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.VVGMitgliedNr)
                .IsUnicode(false);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.VVGPraemie)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.VVGFranchise)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.VVGZusaetzeRTF)
                .IsUnicode(false);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BaGesundheit>()
                .Property(e => e.BaGesundheitTS)
                .IsFixedLength();

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.InstitutionNr)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.Anrede)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.Briefanrede)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.Vorname)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.Versichertennummer)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.Telefon2)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.Telefon3)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.Homepage)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.InstitutionName)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution>()
                .Property(e => e.BaInstitutionTS)
                .IsFixedLength();

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.BaAdresses)
                .WithOptional(e => e.BaInstitution)
                .HasForeignKey(e => e.BaInstitutionID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.BaAdresses1)
                .WithOptional(e => e.BaInstitution1)
                .HasForeignKey(e => e.PlatzierungInstID);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.BaGesundheits)
                .WithOptional(e => e.BaInstitution)
                .HasForeignKey(e => e.ZahnarztBaInstitutionID);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.BaGesundheits1)
                .WithOptional(e => e.BaInstitution1)
                .HasForeignKey(e => e.KVGOrganisationID);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.BaGesundheits2)
                .WithOptional(e => e.BaInstitution2)
                .HasForeignKey(e => e.VVGOrganisationID);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.BaInstitution_BaInstitutionTyp)
                .WithRequired(e => e.BaInstitution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.BaInstitutionDokuments)
                .WithRequired(e => e.BaInstitution)
                .HasForeignKey(e => e.BaInstitutionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.BaInstitutionDokuments1)
                .WithOptional(e => e.BaInstitution1)
                .HasForeignKey(e => e.BaInstitutionID_Adressat);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.BaInstitutionKontakts)
                .WithRequired(e => e.BaInstitution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.BaPersons)
                .WithOptional(e => e.BaInstitution)
                .HasForeignKey(e => e.Kopfquote_BaInstitutionID);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.BaPerson_BaInstitution)
                .WithRequired(e => e.BaInstitution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.FaDokumentAblages)
                .WithOptional(e => e.BaInstitution)
                .HasForeignKey(e => e.BaInstitutionID_Adressat);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.FaDokumentes)
                .WithOptional(e => e.BaInstitution)
                .HasForeignKey(e => e.BaInstitutionID_Adressat);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.KbBuchungs)
                .WithOptional(e => e.BaInstitution)
                .HasForeignKey(e => e.Schuldner_BaInstitutionID);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.KesDokuments)
                .WithOptional(e => e.BaInstitution)
                .HasForeignKey(e => e.BaInstitutionID_Adressat);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.KesMassnahmeBSSes)
                .WithOptional(e => e.BaInstitution)
                .HasForeignKey(e => e.BaInstitutionID);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.KesMassnahmeBSSes1)
                .WithOptional(e => e.BaInstitution1)
                .HasForeignKey(e => e.Platzierung_BaInstitutionID);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.KesVerlaufs)
                .WithOptional(e => e.BaInstitution)
                .HasForeignKey(e => e.BaInstitutionID_Adressat);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.VmErbschaftsdiensts)
                .WithOptional(e => e.BaInstitution)
                .HasForeignKey(e => e.InventarNotarID);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.VmSiegelungs)
                .WithOptional(e => e.BaInstitution)
                .HasForeignKey(e => e.NotarID);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.VmSozialversicherungs)
                .WithOptional(e => e.BaInstitution)
                .HasForeignKey(e => e.BaInstitutionID_Adressat);

            modelBuilder.Entity<BaInstitution>()
                .HasMany(e => e.VmTestaments)
                .WithOptional(e => e.BaInstitution)
                .HasForeignKey(e => e.NotarID);

            modelBuilder.Entity<BaInstitution_BaInstitutionTyp>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution_BaInstitutionTyp>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitution_BaInstitutionTyp>()
                .Property(e => e.BaInstitution_BaInstitutionTypTS)
                .IsFixedLength();

            modelBuilder.Entity<BaInstitutionDokument>()
                .Property(e => e.Stichwort)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionDokument>()
                .Property(e => e.Inhalt)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionDokument>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionDokument>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionDokument>()
                .Property(e => e.BaInstitutionDokumentTS)
                .IsFixedLength();

            modelBuilder.Entity<BaInstitutionKontakt>()
                .Property(e => e.Anrede)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionKontakt>()
                .Property(e => e.Briefanrede)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionKontakt>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionKontakt>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionKontakt>()
                .Property(e => e.Vorname)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionKontakt>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionKontakt>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionKontakt>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionKontakt>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionKontakt>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionKontakt>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionKontakt>()
                .Property(e => e.BaInstitutionKontaktTS)
                .IsFixedLength();

            modelBuilder.Entity<BaInstitutionTyp>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionTyp>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionTyp>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionTyp>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<BaInstitutionTyp>()
                .Property(e => e.BaInstitutionTypTS)
                .IsFixedLength();

            modelBuilder.Entity<BaInstitutionTyp>()
                .HasMany(e => e.BaInstitution_BaInstitutionTyp)
                .WithRequired(e => e.BaInstitutionTyp)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaKantonalerZuschuss>()
                .Property(e => e.Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<BaKantonalerZuschuss>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<BaKantonalerZuschuss>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BaKantonalerZuschuss>()
                .Property(e => e.BaKantonalerZuschussTS)
                .IsFixedLength();

            modelBuilder.Entity<BaKantonalerZuschuss>()
                .HasMany(e => e.BaPerson_KantonalerZuschuss)
                .WithRequired(e => e.BaKantonalerZuschuss)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaKopfquote>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaKopfquote>()
                .Property(e => e.Zeitspanne)
                .IsUnicode(false);

            modelBuilder.Entity<BaKopfquote>()
                .Property(e => e.Bemerkung)
                .IsFixedLength();

            modelBuilder.Entity<BaKopfquote>()
                .Property(e => e.BaKopfquoteTS)
                .IsFixedLength();

            modelBuilder.Entity<BaLand>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<BaLand>()
                .Property(e => e.TextFR)
                .IsUnicode(false);

            modelBuilder.Entity<BaLand>()
                .Property(e => e.TextIT)
                .IsUnicode(false);

            modelBuilder.Entity<BaLand>()
                .Property(e => e.TextEN)
                .IsUnicode(false);

            modelBuilder.Entity<BaLand>()
                .Property(e => e.Iso2Code)
                .IsUnicode(false);

            modelBuilder.Entity<BaLand>()
                .Property(e => e.Iso3Code)
                .IsUnicode(false);

            modelBuilder.Entity<BaLand>()
                .Property(e => e.SAPCode)
                .IsUnicode(false);

            modelBuilder.Entity<BaLand>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BaLand>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<BaLand>()
                .Property(e => e.BaLandTS)
                .IsFixedLength();

            modelBuilder.Entity<BaLand>()
                .HasMany(e => e.BaBanks)
                .WithOptional(e => e.BaLand)
                .HasForeignKey(e => e.LandCode);

            modelBuilder.Entity<BaLand>()
                .HasMany(e => e.BaPersons)
                .WithOptional(e => e.BaLand)
                .HasForeignKey(e => e.NationalitaetCode);

            modelBuilder.Entity<BaLand>()
                .HasMany(e => e.BaPersons1)
                .WithOptional(e => e.BaLand1)
                .HasForeignKey(e => e.UntWohnsitzLandCode);

            modelBuilder.Entity<BaLand>()
                .HasMany(e => e.BaPersons2)
                .WithOptional(e => e.BaLand2)
                .HasForeignKey(e => e.WegzugLandCode);

            modelBuilder.Entity<BaLand>()
                .HasMany(e => e.BaPersons3)
                .WithOptional(e => e.BaLand3)
                .HasForeignKey(e => e.ZuzugGdeLandCode);

            modelBuilder.Entity<BaLand>()
                .HasMany(e => e.BaPersons4)
                .WithOptional(e => e.BaLand4)
                .HasForeignKey(e => e.ZuzugKtLandCode);

            modelBuilder.Entity<BaLand>()
                .HasMany(e => e.BaZahlungswegs)
                .WithOptional(e => e.BaLand)
                .HasForeignKey(e => e.AdresseLandCode);

            modelBuilder.Entity<BaLand>()
                .HasMany(e => e.KbBuchungs)
                .WithOptional(e => e.BaLand)
                .HasForeignKey(e => e.BeguenstigtLandCode);

            modelBuilder.Entity<BaMietvertrag>()
                .Property(e => e.Mietkosten)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaMietvertrag>()
                .Property(e => e.Nebenkosten)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaMietvertrag>()
                .Property(e => e.KostenanteilUE)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaMietvertrag>()
                .Property(e => e.Mietdepot)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaMietvertrag>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BaMietvertrag>()
                .Property(e => e.BaMietvertragTS)
                .IsFixedLength();

            modelBuilder.Entity<BaMietvertrag>()
                .Property(e => e.Mietzinsgarantie)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.FruehererName)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.Vorname)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.Vorname2)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.AHVNummer)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.Versichertennummer)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.HaushaltVersicherungsNummer)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.NNummer)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.BFFNummer)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.ZARNummer)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.KantonaleReferenznummer)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.HeimatgemeindeCodes)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.Telefon_P)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.Telefon_G)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.MobilTel1)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.MobilTel2)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.EinwohnerregisterID)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.ZuzugKtPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.ZuzugKtOrt)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.ZuzugKtKanton)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.ZuzugGdePLZ)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.ZuzugGdeOrt)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.ZuzugGdeKanton)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.UntWohnsitzPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.UntWohnsitzOrt)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.UntWohnsitzKanton)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.WegzugPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.WegzugOrt)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.WegzugKanton)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.ArbeitSpezFaehigkeiten)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.PUKrankenkasse)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.AndereSVLeistungen)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.Anrede)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.BemerkungenAdresse)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.BemerkungenSV)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.Briefanrede)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.Einrichtpauschale)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.MobilTel)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.NavigatorZusatz)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.Sprachpauschale)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.visdat36Area)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.visdat36ID)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.WichtigerHinweis)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.ZEMISNummer)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson>()
                .Property(e => e.BaPersonTS)
                .IsFixedLength();

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.BaAdresses)
                .WithOptional(e => e.BaPerson)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BaPerson>()
                .HasOptional(e => e.BaArbeitAusbildung)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.BaEinwohnerregisterPersonStatus)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.BaInstitutionDokuments)
                .WithOptional(e => e.BaPerson)
                .HasForeignKey(e => e.BaPersonID_Adressat);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.BaPerson1)
                .WithOptional(e => e.BaPerson2)
                .HasForeignKey(e => e.BaPersonID_Dossiertraeger);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.BaPerson_KantonalerZuschuss)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.BaPerson_Relation)
                .WithRequired(e => e.BaPerson)
                .HasForeignKey(e => e.BaPersonID_1);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.BaPerson_Relation1)
                .WithRequired(e => e.BaPerson1)
                .HasForeignKey(e => e.BaPersonID_2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.BaPraemienverbilligungs)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.BaWVCodes)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.BFSDossierPersons)
                .WithOptional(e => e.BaPerson)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.BgFinanzplan_BaPerson)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.BgPositions)
                .WithOptional(e => e.BaPerson)
                .HasForeignKey(e => e.BaPersonID);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.BgPositions1)
                .WithOptional(e => e.BaPerson1)
                .HasForeignKey(e => e.DebitorBaPersonID);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.FaDokumentAblages)
                .WithOptional(e => e.BaPerson)
                .HasForeignKey(e => e.BaPersonID_Adressat);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.FaDokumentAblage_BaPerson)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.FaDokumentes)
                .WithOptional(e => e.BaPerson)
                .HasForeignKey(e => e.BaPersonID_Adressat);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.FaDokumentes1)
                .WithOptional(e => e.BaPerson1)
                .HasForeignKey(e => e.BaPersonID_LT);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.FaLeistungs)
                .WithRequired(e => e.BaPerson)
                .HasForeignKey(e => e.BaPersonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.FaLeistungs1)
                .WithOptional(e => e.BaPerson1)
                .HasForeignKey(e => e.SchuldnerBaPersonID);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.FaWeisung_BaPerson)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.FbBelegNrs)
                .WithOptional(e => e.BaPerson)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.FbBuchungCodes)
                .WithOptional(e => e.BaPerson)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.FbDauerauftrags)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.FbPeriodes)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.GvDokumenteInformations)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.GvGesuches)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.IkEinkommen)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.IkGlaeubigers)
                .WithRequired(e => e.BaPerson)
                .HasForeignKey(e => e.BaPersonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.IkGlaeubigers1)
                .WithOptional(e => e.BaPerson1)
                .HasForeignKey(e => e.BaPersonID_AntragStellendePerson);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.IkVerrechnungskontoes)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.KaAmmBesches)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.KaArbeitsrapports)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.KaEinsatzs)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.KaExterneBildungs)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.KaIntegBildungs)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.KaSequenzens)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.KaZuteilFachbereiches)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.KbBuchungs)
                .WithOptional(e => e.BaPerson)
                .HasForeignKey(e => e.Schuldner_BaPersonID);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.KbWVEinzelpostens)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.KbWVEinzelpostenFehlers)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.KesAuftrag_BaPerson)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.KesDokuments)
                .WithOptional(e => e.BaPerson)
                .HasForeignKey(e => e.BaPersonID_Adressat);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.KesVerlaufs)
                .WithOptional(e => e.BaPerson)
                .HasForeignKey(e => e.BaPersonID_Adressat);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.VmMandants)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.VmSozialversicherungs)
                .WithOptional(e => e.BaPerson)
                .HasForeignKey(e => e.BaPersonID_Adressat);

            modelBuilder.Entity<BaPerson>()
                .HasMany(e => e.WhASVSEintrags)
                .WithRequired(e => e.BaPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaPersonBaInstitution>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BaPersonBaInstitution>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BaPersonBaInstitution>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<BaPersonBaInstitution>()
                .Property(e => e.BaPersonBaInstitutionTS)
                .IsFixedLength();

            modelBuilder.Entity<BaPerson_KantonalerZuschuss>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson_KantonalerZuschuss>()
                .Property(e => e.BaPerson_KantonalerZuschussTS)
                .IsFixedLength();

            modelBuilder.Entity<BaPerson_Relation>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BaPerson_Relation>()
                .Property(e => e.BaPerson_RelationTS)
                .IsFixedLength();

            modelBuilder.Entity<BaPLZ>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BaPLZ>()
                .Property(e => e.Kanton)
                .IsUnicode(false);

            modelBuilder.Entity<BaPLZ>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BaPLZ>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<BaPLZ>()
                .Property(e => e.BaPLZTS)
                .IsFixedLength();

            modelBuilder.Entity<BaPraemienverbilligung>()
                .Property(e => e.BetragAnspruch)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaPraemienverbilligung>()
                .Property(e => e.BetragAuszahlung)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BaPraemienverbilligung>()
                .Property(e => e.ZahlungAn)
                .IsUnicode(false);

            modelBuilder.Entity<BaPraemienverbilligung>()
                .Property(e => e.ZahlungAn_Krankenkassennummer)
                .IsUnicode(false);

            modelBuilder.Entity<BaPraemienverbilligung>()
                .Property(e => e.Grund)
                .IsUnicode(false);

            modelBuilder.Entity<BaPraemienverbilligung>()
                .Property(e => e.BaPraemienverbilligungTS)
                .IsFixedLength();

            modelBuilder.Entity<BaRelation>()
                .Property(e => e.NameRelation)
                .IsUnicode(false);

            modelBuilder.Entity<BaRelation>()
                .Property(e => e.NameGenerisch1)
                .IsUnicode(false);

            modelBuilder.Entity<BaRelation>()
                .Property(e => e.NameGenerisch2)
                .IsUnicode(false);

            modelBuilder.Entity<BaRelation>()
                .Property(e => e.NameMaennlich1)
                .IsUnicode(false);

            modelBuilder.Entity<BaRelation>()
                .Property(e => e.NameWeiblich1)
                .IsUnicode(false);

            modelBuilder.Entity<BaRelation>()
                .Property(e => e.NameMaennlich2)
                .IsUnicode(false);

            modelBuilder.Entity<BaRelation>()
                .Property(e => e.NameWeiblich2)
                .IsUnicode(false);

            modelBuilder.Entity<BaRelation>()
                .Property(e => e.BaRelationTS)
                .IsFixedLength();

            modelBuilder.Entity<BaWVCode>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BaWVCode>()
                .Property(e => e.HeimatKantonNr)
                .IsUnicode(false);

            modelBuilder.Entity<BaWVCode>()
                .Property(e => e.WohnKantonNr)
                .IsUnicode(false);

            modelBuilder.Entity<BaWVCode>()
                .Property(e => e.KantonKuerzel)
                .IsUnicode(false);

            modelBuilder.Entity<BaWVCode>()
                .Property(e => e.BaWVCodeTS)
                .IsFixedLength();

            modelBuilder.Entity<BaWVCode>()
                .HasMany(e => e.KbWVEinzelpostens)
                .WithRequired(e => e.BaWVCode1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaZahlungsweg>()
                .Property(e => e.BankKontoNummer)
                .IsUnicode(false);

            modelBuilder.Entity<BaZahlungsweg>()
                .Property(e => e.IBANNummer)
                .IsUnicode(false);

            modelBuilder.Entity<BaZahlungsweg>()
                .Property(e => e.PostKontoNummer)
                .IsUnicode(false);

            modelBuilder.Entity<BaZahlungsweg>()
                .Property(e => e.ReferenzNummer)
                .IsUnicode(false);

            modelBuilder.Entity<BaZahlungsweg>()
                .Property(e => e.AdresseName)
                .IsUnicode(false);

            modelBuilder.Entity<BaZahlungsweg>()
                .Property(e => e.AdresseName2)
                .IsUnicode(false);

            modelBuilder.Entity<BaZahlungsweg>()
                .Property(e => e.AdresseStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<BaZahlungsweg>()
                .Property(e => e.AdresseHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<BaZahlungsweg>()
                .Property(e => e.AdressePostfach)
                .IsUnicode(false);

            modelBuilder.Entity<BaZahlungsweg>()
                .Property(e => e.AdressePLZ)
                .IsUnicode(false);

            modelBuilder.Entity<BaZahlungsweg>()
                .Property(e => e.AdresseOrt)
                .IsUnicode(false);

            modelBuilder.Entity<BaZahlungsweg>()
                .Property(e => e.BaZahlwegModulStdCodes)
                .IsUnicode(false);

            modelBuilder.Entity<BaZahlungsweg>()
                .Property(e => e.BaZahlungswegTS)
                .IsFixedLength();

            modelBuilder.Entity<BaZahlungsweg>()
                .HasMany(e => e.GvAuszahlungPositions)
                .WithRequired(e => e.BaZahlungsweg)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BDEAusbezahlteUeberstunden_XUser>()
                .Property(e => e.AusbezahlteStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDEAusbezahlteUeberstunden_XUser>()
                .Property(e => e.BDEAusbezahlteUeberstunden_XUserTS)
                .IsFixedLength();

            modelBuilder.Entity<BDEFerienanspruch_XUser>()
                .Property(e => e.FerienanspruchStdProJahr)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDEFerienanspruch_XUser>()
                .Property(e => e.BDEFerienanspruch_XUserTS)
                .IsFixedLength();

            modelBuilder.Entity<BDEFerienkuerzungen_XUser>()
                .Property(e => e.FerienkuerzungStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDEFerienkuerzungen_XUser>()
                .Property(e => e.BDEFerienkuerzungen_XUserTS)
                .IsFixedLength();

            modelBuilder.Entity<BDELeistung>()
                .Property(e => e.Dauer)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDELeistung>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BDELeistung>()
                .Property(e => e.BDELeistungTS)
                .IsFixedLength();

            modelBuilder.Entity<BDELeistungsart>()
                .Property(e => e.Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<BDELeistungsart>()
                .Property(e => e.ArtikelNr)
                .IsUnicode(false);

            modelBuilder.Entity<BDELeistungsart>()
                .Property(e => e.KTRStandard)
                .IsUnicode(false);

            modelBuilder.Entity<BDELeistungsart>()
                .Property(e => e.KTRIV)
                .IsUnicode(false);

            modelBuilder.Entity<BDELeistungsart>()
                .Property(e => e.KTRAHV)
                .IsUnicode(false);

            modelBuilder.Entity<BDELeistungsart>()
                .Property(e => e.KTRNichtberechtigte)
                .IsUnicode(false);

            modelBuilder.Entity<BDELeistungsart>()
                .Property(e => e.Beschreibung)
                .IsUnicode(false);

            modelBuilder.Entity<BDELeistungsart>()
                .Property(e => e.BDELeistungsartTS)
                .IsFixedLength();

            modelBuilder.Entity<BDELeistungsart>()
                .HasMany(e => e.BDELeistungs)
                .WithRequired(e => e.BDELeistungsart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BDELeistungsart>()
                .HasMany(e => e.BDEUserGroup_BDELeistungsart)
                .WithRequired(e => e.BDELeistungsart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BDEPensum_XUser>()
                .Property(e => e.BDEPensum_XUserTS)
                .IsFixedLength();

            modelBuilder.Entity<BDESollProTag_XUser>()
                .Property(e => e.SollStundenProTag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDESollProTag_XUser>()
                .Property(e => e.BDESollProTag_XUserTS)
                .IsFixedLength();

            modelBuilder.Entity<BDESollStundenProJahr_XUser>()
                .Property(e => e.JanuarStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDESollStundenProJahr_XUser>()
                .Property(e => e.FebruarStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDESollStundenProJahr_XUser>()
                .Property(e => e.MaerzStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDESollStundenProJahr_XUser>()
                .Property(e => e.AprilStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDESollStundenProJahr_XUser>()
                .Property(e => e.MaiStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDESollStundenProJahr_XUser>()
                .Property(e => e.JuniStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDESollStundenProJahr_XUser>()
                .Property(e => e.JuliStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDESollStundenProJahr_XUser>()
                .Property(e => e.AugustStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDESollStundenProJahr_XUser>()
                .Property(e => e.SeptemberStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDESollStundenProJahr_XUser>()
                .Property(e => e.OktoberStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDESollStundenProJahr_XUser>()
                .Property(e => e.NovemberStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDESollStundenProJahr_XUser>()
                .Property(e => e.DezemberStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDESollStundenProJahr_XUser>()
                .Property(e => e.TotalStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BDESollStundenProJahr_XUser>()
                .Property(e => e.BDESollStundenProJahr_XUserTS)
                .IsFixedLength();

            modelBuilder.Entity<BDEUserGroup>()
                .Property(e => e.UserGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<BDEUserGroup>()
                .Property(e => e.Beschreibung)
                .IsUnicode(false);

            modelBuilder.Entity<BDEUserGroup>()
                .Property(e => e.BDEUserGroupTS)
                .IsFixedLength();

            modelBuilder.Entity<BDEUserGroup>()
                .HasMany(e => e.BDEUserGroup_BDELeistungsart)
                .WithRequired(e => e.BDEUserGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BDEUserGroup>()
                .HasMany(e => e.XUser_BDEUserGroup)
                .WithRequired(e => e.BDEUserGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BDEUserGroup_BDELeistungsart>()
                .Property(e => e.BDEUserGroup_BDELeistungsartTS)
                .IsFixedLength();

            modelBuilder.Entity<BDEZeitrechner>()
                .Property(e => e.BDEZeitrechnerTS)
                .IsFixedLength();

            modelBuilder.Entity<BFSDossier>()
                .Property(e => e.XML)
                .IsUnicode(false);

            modelBuilder.Entity<BFSDossier>()
                .Property(e => e.BFSDossierTS)
                .IsFixedLength();

            modelBuilder.Entity<BFSDossier>()
                .HasMany(e => e.BFSWerts)
                .WithRequired(e => e.BFSDossier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BFSDossierPerson>()
                .Property(e => e.PersonName)
                .IsUnicode(false);

            modelBuilder.Entity<BFSDossierPerson>()
                .Property(e => e.BFSDossierPersonTS)
                .IsFixedLength();

            modelBuilder.Entity<BFSDossierPerson>()
                .HasMany(e => e.BFSWerts)
                .WithOptional(e => e.BFSDossierPerson)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.Variable)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.Frage)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.BFSLeistungsfilterCodes)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.BFSFormat)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.FFLOVName)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.BFSLOVName)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.HerkunftBeschreibung)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.HerkunftSQL)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.FFTabelle)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.FFFeld)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.FFPKFeld)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.ExportNode)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.ExportAttribute)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.ExportPredicate)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.HilfeTitel)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.HilfeText)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.BFSFrageTS)
                .IsFixedLength();

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.FilterRegel)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.VariableAntragsteller)
                .IsUnicode(false);

            modelBuilder.Entity<BFSFrage>()
                .Property(e => e.VariableExpandiert)
                .IsUnicode(false);

            modelBuilder.Entity<BFSKatalogVersion>()
                .Property(e => e.PlausexVersion)
                .IsUnicode(false);

            modelBuilder.Entity<BFSKatalogVersion>()
                .Property(e => e.DossierXML)
                .IsUnicode(false);

            modelBuilder.Entity<BFSKatalogVersion>()
                .HasMany(e => e.BFSDossiers)
                .WithRequired(e => e.BFSKatalogVersion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BFSLOV>()
                .Property(e => e.LOVName)
                .IsUnicode(false);

            modelBuilder.Entity<BFSLOV>()
                .Property(e => e.BFSLOVTS)
                .IsFixedLength();

            modelBuilder.Entity<BFSLOVCode>()
                .Property(e => e.LOVName)
                .IsUnicode(false);

            modelBuilder.Entity<BFSLOVCode>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<BFSLOVCode>()
                .Property(e => e.KurzText)
                .IsUnicode(false);

            modelBuilder.Entity<BFSLOVCode>()
                .Property(e => e.Filter)
                .IsUnicode(false);

            modelBuilder.Entity<BFSLOVCode>()
                .Property(e => e.BFSLOVCodeTS)
                .IsFixedLength();

            modelBuilder.Entity<BFSWert>()
                .Property(e => e.PlausiFehler)
                .IsUnicode(false);

            modelBuilder.Entity<BFSWert>()
                .Property(e => e.BFSWertTS)
                .IsFixedLength();

            modelBuilder.Entity<BgAuszahlungPerson>()
                .Property(e => e.BgWochentagCodes)
                .IsUnicode(false);

            modelBuilder.Entity<BgAuszahlungPerson>()
                .Property(e => e.Zahlungsgrund)
                .IsUnicode(false);

            modelBuilder.Entity<BgAuszahlungPerson>()
                .Property(e => e.ReferenzNummer)
                .IsUnicode(false);

            modelBuilder.Entity<BgAuszahlungPerson>()
                .Property(e => e.MitteilungZeile1)
                .IsUnicode(false);

            modelBuilder.Entity<BgAuszahlungPerson>()
                .Property(e => e.MitteilungZeile2)
                .IsUnicode(false);

            modelBuilder.Entity<BgAuszahlungPerson>()
                .Property(e => e.MitteilungZeile3)
                .IsUnicode(false);

            modelBuilder.Entity<BgAuszahlungPerson>()
                .Property(e => e.MitteilungZeile4)
                .IsUnicode(false);

            modelBuilder.Entity<BgAuszahlungPerson>()
                .Property(e => e.BgAuszahlungPersonTS)
                .IsFixedLength();

            modelBuilder.Entity<BgAuszahlungPersonTermin>()
                .Property(e => e.BgAuszahlungPersonTerminTS)
                .IsFixedLength();

            modelBuilder.Entity<BgBewilligung>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BgBewilligung>()
                .Property(e => e.BgBewilligungTS)
                .IsFixedLength();

            modelBuilder.Entity<BgBudget>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BgBudget>()
                .Property(e => e.BgBudgetTS)
                .IsFixedLength();

            modelBuilder.Entity<BgBudget>()
                .HasMany(e => e.BgBewilligungs)
                .WithOptional(e => e.BgBudget)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BgBudget>()
                .HasMany(e => e.BgDokuments)
                .WithOptional(e => e.BgBudget)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BgBudget>()
                .HasMany(e => e.BgPositions)
                .WithRequired(e => e.BgBudget)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BgBudget>()
                .HasMany(e => e.ShEinzelzahlungs)
                .WithRequired(e => e.BgBudget)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BgDokument>()
                .Property(e => e.Stichwort)
                .IsUnicode(false);

            modelBuilder.Entity<BgDokument>()
                .Property(e => e.BgDocumentTS)
                .IsFixedLength();

            modelBuilder.Entity<BgFinanzplan>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BgFinanzplan>()
                .Property(e => e.BgFinanzplanTS)
                .IsFixedLength();

            modelBuilder.Entity<BgFinanzplan>()
                .HasMany(e => e.BgBewilligungs)
                .WithOptional(e => e.BgFinanzplan)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BgFinanzplan>()
                .HasMany(e => e.BgDokuments)
                .WithOptional(e => e.BgFinanzplan)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BgFinanzplan_BaPerson>()
                .Property(e => e.ReferenzNummer)
                .IsUnicode(false);

            modelBuilder.Entity<BgFinanzplan_BaPerson>()
                .Property(e => e.PrsNummerKanton)
                .IsUnicode(false);

            modelBuilder.Entity<BgFinanzplan_BaPerson>()
                .Property(e => e.PrsNummerHeimat)
                .IsUnicode(false);

            modelBuilder.Entity<BgFinanzplan_BaPerson>()
                .Property(e => e.AuslandChReferenzNrBund)
                .IsUnicode(false);

            modelBuilder.Entity<BgFinanzplan_BaPerson>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BgFinanzplan_BaPerson>()
                .Property(e => e.BgFinanzplan_BaPersonTS)
                .IsFixedLength();

            modelBuilder.Entity<BgGruppe_BFSFrage>()
                .Property(e => e.Variable)
                .IsUnicode(false);

            modelBuilder.Entity<BgKostenart>()
                .Property(e => e.KontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<BgKostenart>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BgKostenart>()
                .Property(e => e.BgKostenartTS)
                .IsFixedLength();

            modelBuilder.Entity<BgKostenart>()
                .HasMany(e => e.BgKostenart_WhGefKategorie)
                .WithRequired(e => e.BgKostenart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BgKostenart>()
                .HasMany(e => e.GvPositionsarts)
                .WithRequired(e => e.BgKostenart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BgKostenart>()
                .HasMany(e => e.IkForderung_BgKostenart)
                .WithRequired(e => e.BgKostenart)
                .HasForeignKey(e => e.BgKostenartID_Auszahlung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BgKostenart>()
                .HasMany(e => e.IkForderung_BgKostenart1)
                .WithRequired(e => e.BgKostenart1)
                .HasForeignKey(e => e.BgKostenartID_Forderung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BgKostenart>()
                .HasMany(e => e.IkForderungBgKostenartHists)
                .WithRequired(e => e.BgKostenart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BgKostenart_WhGefKategorie>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BgKostenart_WhGefKategorie>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<BgKostenart_WhGefKategorie>()
                .Property(e => e.BgKostenart_WhGefKategorieTS)
                .IsFixedLength();

            modelBuilder.Entity<BgPosition>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BgPosition>()
                .Property(e => e.Reduktion)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BgPosition>()
                .Property(e => e.Abzug)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BgPosition>()
                .Property(e => e.BetragEff)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BgPosition>()
                .Property(e => e.MaxBeitragSD)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BgPosition>()
                .Property(e => e.Buchungstext)
                .IsUnicode(false);

            modelBuilder.Entity<BgPosition>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BgPosition>()
                .Property(e => e.BetragAnfrage)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BgPosition>()
                .Property(e => e.BemerkungSaldierung)
                .IsUnicode(false);

            modelBuilder.Entity<BgPosition>()
                .Property(e => e.BgPositionTS)
                .IsFixedLength();

            modelBuilder.Entity<BgPosition>()
                .HasMany(e => e.BgBewilligungs)
                .WithOptional(e => e.BgPosition)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BgPosition>()
                .HasMany(e => e.BgDokuments)
                .WithOptional(e => e.BgPosition)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BgPosition>()
                .HasMany(e => e.BgPosition1)
                .WithOptional(e => e.BgPosition2)
                .HasForeignKey(e => e.BgPositionID_AutoForderung);

            modelBuilder.Entity<BgPosition>()
                .HasMany(e => e.BgPosition11)
                .WithOptional(e => e.BgPosition3)
                .HasForeignKey(e => e.BgPositionID_Parent);

            modelBuilder.Entity<BgPosition>()
                .HasMany(e => e.BgPosition12)
                .WithOptional(e => e.BgPosition4)
                .HasForeignKey(e => e.BgPositionID_CopyOf);

            modelBuilder.Entity<BgPositionsart>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BgPositionsart>()
                .Property(e => e.HilfeText)
                .IsUnicode(false);

            modelBuilder.Entity<BgPositionsart>()
                .Property(e => e.sqlRichtlinie)
                .IsUnicode(false);

            modelBuilder.Entity<BgPositionsart>()
                .Property(e => e.BgPositionsartTS)
                .IsFixedLength();

            modelBuilder.Entity<BgPositionsart>()
                .Property(e => e.VarName)
                .IsUnicode(false);

            modelBuilder.Entity<BgPositionsart>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BgPositionsart>()
                .HasMany(e => e.BgPositionsartBuchungstexts)
                .WithRequired(e => e.BgPositionsart)
                .HasForeignKey(e => e.BgPositionsartID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BgPositionsart>()
                .HasMany(e => e.BgPositionsartBuchungstexts1)
                .WithOptional(e => e.BgPositionsart1)
                .HasForeignKey(e => e.BgPositionsartID_UseText);

            modelBuilder.Entity<BgPositionsart>()
                .HasMany(e => e.XPermissionValues)
                .WithOptional(e => e.BgPositionsart)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BgPositionsartBuchungstext>()
                .Property(e => e.Buchungstext)
                .IsUnicode(false);

            modelBuilder.Entity<BgPositionsartBuchungstext>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BgPositionsartBuchungstext>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<BgPositionsartBuchungstext>()
                .Property(e => e.BgPositionsartBuchungstextTS)
                .IsFixedLength();

            modelBuilder.Entity<BgSpezkonto>()
                .Property(e => e.NameSpezkonto)
                .IsUnicode(false);

            modelBuilder.Entity<BgSpezkonto>()
                .Property(e => e.StartSaldo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BgSpezkonto>()
                .Property(e => e.BetragProMonat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BgSpezkonto>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<BgSpezkonto>()
                .Property(e => e.BgSpezkontoTS)
                .IsFixedLength();

            modelBuilder.Entity<BgSpezkonto>()
                .Property(e => e.KuerzungAnteilGBL)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BgSpezkonto>()
                .Property(e => e.AbschlussBegruendung)
                .IsUnicode(false);

            modelBuilder.Entity<BgSpezkonto>()
                .HasMany(e => e.BgSpezkontoAbschlusses)
                .WithRequired(e => e.BgSpezkonto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BgSpezkontoAbschluss>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BgSpezkontoAbschluss>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<BgSpezkontoAbschluss>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<BgSpezkontoAbschluss>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<BgSpezkontoAbschluss>()
                .Property(e => e.BgSpezkontoAbschlussTS)
                .IsFixedLength();

            modelBuilder.Entity<BgZahlungsmodu>()
                .Property(e => e.NameZahlungsmodus)
                .IsUnicode(false);

            modelBuilder.Entity<BgZahlungsmodu>()
                .Property(e => e.ReferenzNummer)
                .IsUnicode(false);

            modelBuilder.Entity<BgZahlungsmodu>()
                .Property(e => e.BgZahlungsmodusTS)
                .IsFixedLength();

            modelBuilder.Entity<BgZahlungsmodusTermin>()
                .Property(e => e.BgZahlungsmodusTerminTS)
                .IsFixedLength();

            modelBuilder.Entity<DynaField>()
                .Property(e => e.MaskName)
                .IsUnicode(false);

            modelBuilder.Entity<DynaField>()
                .Property(e => e.FieldName)
                .IsUnicode(false);

            modelBuilder.Entity<DynaField>()
                .Property(e => e.DisplayText)
                .IsUnicode(false);

            modelBuilder.Entity<DynaField>()
                .Property(e => e.LOVName)
                .IsUnicode(false);

            modelBuilder.Entity<DynaField>()
                .Property(e => e.SQL)
                .IsUnicode(false);

            modelBuilder.Entity<DynaField>()
                .Property(e => e.DefaultValue)
                .IsUnicode(false);

            modelBuilder.Entity<DynaField>()
                .Property(e => e.TabName)
                .IsUnicode(false);

            modelBuilder.Entity<DynaField>()
                .Property(e => e.GridColTitle)
                .IsUnicode(false);

            modelBuilder.Entity<DynaField>()
                .Property(e => e.AppCode)
                .IsUnicode(false);

            modelBuilder.Entity<DynaField>()
                .Property(e => e.DynaFieldTS)
                .IsFixedLength();

            modelBuilder.Entity<DynaField>()
                .HasMany(e => e.DynaValues)
                .WithRequired(e => e.DynaField)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DynaMask>()
                .Property(e => e.MaskName)
                .IsUnicode(false);

            modelBuilder.Entity<DynaMask>()
                .Property(e => e.ParentMaskName)
                .IsUnicode(false);

            modelBuilder.Entity<DynaMask>()
                .Property(e => e.DisplayText)
                .IsUnicode(false);

            modelBuilder.Entity<DynaMask>()
                .Property(e => e.TabNames)
                .IsUnicode(false);

            modelBuilder.Entity<DynaMask>()
                .Property(e => e.AppCode)
                .IsUnicode(false);

            modelBuilder.Entity<DynaMask>()
                .Property(e => e.DynaMaskTS)
                .IsFixedLength();

            modelBuilder.Entity<DynaValue>()
                .Property(e => e.ValueText)
                .IsUnicode(false);

            modelBuilder.Entity<DynaValue>()
                .Property(e => e.DynaValueTS)
                .IsFixedLength();

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.FaThemaCodes)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.Kontaktpartner)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.BaPersonIDs)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.Stichwort)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.InhaltRTF)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.BesprechungThemaText1)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.BesprechungThemaText2)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.BesprechungThemaText3)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.BesprechungThemaText4)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.BesprechungZiel1)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.BesprechungZiel2)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.BesprechungZiel3)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.BesprechungZiel4)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.Pendenz1)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.Pendenz2)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.Pendenz3)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.Pendenz4)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FaAktennotizen>()
                .Property(e => e.FaAktennotizTS)
                .IsFixedLength();

            modelBuilder.Entity<FaDokumentAblage>()
                .Property(e => e.FaThemaDokAblageCodes)
                .IsUnicode(false);

            modelBuilder.Entity<FaDokumentAblage>()
                .Property(e => e.Stichwort)
                .IsUnicode(false);

            modelBuilder.Entity<FaDokumentAblage>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<FaDokumentAblage>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FaDokumentAblage>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FaDokumentAblage>()
                .Property(e => e.FaDokumentAblageTS)
                .IsFixedLength();

            modelBuilder.Entity<FaDokumentAblage>()
                .HasMany(e => e.FaDokumentAblage_BaPerson)
                .WithRequired(e => e.FaDokumentAblage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaDokumentAblageBaPerson>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FaDokumentAblageBaPerson>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FaDokumentAblageBaPerson>()
                .Property(e => e.FaDokumentAblageBaPersonTS)
                .IsFixedLength();

            modelBuilder.Entity<FaDokumente>()
                .Property(e => e.BaPersonIDs)
                .IsUnicode(false);

            modelBuilder.Entity<FaDokumente>()
                .Property(e => e.Stichwort)
                .IsUnicode(false);

            modelBuilder.Entity<FaDokumente>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<FaDokumente>()
                .Property(e => e.FaThemaCodes)
                .IsUnicode(false);

            modelBuilder.Entity<FaDokumente>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FaDokumente>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FaDokumente>()
                .Property(e => e.FaDokumenteTS)
                .IsFixedLength();

            modelBuilder.Entity<FaKategorisierung>()
                .Property(e => e.Begruendung)
                .IsUnicode(false);

            modelBuilder.Entity<FaKategorisierung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FaKategorisierung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FaKategorisierung>()
                .Property(e => e.FaKategorisierungTS)
                .IsFixedLength();

            modelBuilder.Entity<FaKategorisierungEksProdukt>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<FaKategorisierungEksProdukt>()
                .Property(e => e.ShortText)
                .IsUnicode(false);

            modelBuilder.Entity<FaKategorisierungEksProdukt>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FaKategorisierungEksProdukt>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FaKategorisierungEksProdukt>()
                .Property(e => e.FaKategorisierungEksProduktTS)
                .IsFixedLength();

            modelBuilder.Entity<FaLeistung>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<FaLeistung>()
                .Property(e => e.Dossiernummer)
                .IsUnicode(false);

            modelBuilder.Entity<FaLeistung>()
                .Property(e => e.FaTeilleistungserbringerCodes)
                .IsUnicode(false);

            modelBuilder.Entity<FaLeistung>()
                .Property(e => e.Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<FaLeistung>()
                .Property(e => e.MigBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<FaLeistung>()
                .Property(e => e.visdat36Area)
                .IsUnicode(false);

            modelBuilder.Entity<FaLeistung>()
                .Property(e => e.visdat36FALLID)
                .IsUnicode(false);

            modelBuilder.Entity<FaLeistung>()
                .Property(e => e.visdat36LEISTUNGID)
                .IsUnicode(false);

            modelBuilder.Entity<FaLeistung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FaLeistung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FaLeistung>()
                .Property(e => e.FaLeistungTS)
                .IsFixedLength();

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.BFSDossiers)
                .WithOptional(e => e.FaLeistung)
                .WillCascadeOnDelete();

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.BgFinanzplans)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.FaAktennotizens)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.FaDokumentAblages)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.FaDokumentes)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.FaLeistungBewertungs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.FaPhases)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.FaRelations)
                .WithRequired(e => e.FaLeistung)
                .HasForeignKey(e => e.FaLeistungID1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.FaRelations1)
                .WithRequired(e => e.FaLeistung1)
                .HasForeignKey(e => e.FaLeistungID2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.FaWeisungs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.FaZeitlichePlanungs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.FbBarauszahlungAuftrags)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.IkAnzeiges)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.IkRatenplans)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.IkRechtstitels)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaAbklaerungIntakes)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaAbklaerungVertiefts)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaAKZuweisers)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaAllgemeins)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaAssistenzs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaAusbildungs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaEafSozioberuflicheBilanzs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaEafSpezifischeErmittlungs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaKontaktartProzesses)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaQEEPQs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaQEEPQZielvereinbs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaQEEPQZielvereinbVerls)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaQEJobtimums)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaQJIntakes)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaQJProzesses)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaQJPZBerichts)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaQJPZSchlussberichts)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaQJPZZielvereinbarungs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaQJVereinbarungs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaTransfers)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaTransferZielvereinbs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KaVerlaufs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KesAuftrags)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KesMassnahmes)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KesMassnahmeBSSes)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KesPflegekinderaufsichts)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KesPraeventions)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.KesVerlaufs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmAHVMindestbeitrags)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmAntragEKSKs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmBerichts)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmBeschwerdeAnfrages)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmBudgets)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmELKrankheitskostens)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmGefaehrdungsMeldungs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmInventars)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmKlientenbudgets)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmMandBerichts)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmMassnahmes)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmSachversicherungs)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmSchuldens)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmSituationsBerichts)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmSteuerns)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmTestaments)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.VmVaterschafts)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistung>()
                .HasMany(e => e.WhASVSEintrags)
                .WithRequired(e => e.FaLeistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FaLeistungArchiv>()
                .Property(e => e.ArchivNr)
                .IsUnicode(false);

            modelBuilder.Entity<FaLeistungArchiv>()
                .Property(e => e.FaLeistungArchivTS)
                .IsFixedLength();

            modelBuilder.Entity<FaLeistungBewertung>()
                .Property(e => e.FaKriterienCodes)
                .IsUnicode(false);

            modelBuilder.Entity<FaLeistungBewertung>()
                .Property(e => e.FaLeistungBewertungTS)
                .IsFixedLength();

            modelBuilder.Entity<FaLeistungUserHist>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FaLeistungUserHist>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FaLeistungUserHist>()
                .Property(e => e.FaLeistungUserHistTS)
                .IsFixedLength();

            modelBuilder.Entity<FaLeistungZugriff>()
                .Property(e => e.FaLeistungZugriffTS)
                .IsFixedLength();

            modelBuilder.Entity<FaPendenzgruppe>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FaPendenzgruppe>()
                .Property(e => e.Beschreibung)
                .IsUnicode(false);

            modelBuilder.Entity<FaPendenzgruppe>()
                .Property(e => e.FaPendenzgruppeTS)
                .IsFixedLength();

            modelBuilder.Entity<FaPendenzgruppe_User>()
                .Property(e => e.FaPendenzgruppe_UserTS)
                .IsFixedLength();

            modelBuilder.Entity<FaPhase>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<FaPhase>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FaPhase>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FaPhase>()
                .Property(e => e.FaPhaseTS)
                .IsFixedLength();

            modelBuilder.Entity<FaRelation>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FaRelation>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FaRelation>()
                .Property(e => e.FaRelationTS)
                .IsFixedLength();

            modelBuilder.Entity<FaWeisung>()
                .Property(e => e.Betreff)
                .IsUnicode(false);

            modelBuilder.Entity<FaWeisung>()
                .Property(e => e.Ausganslage)
                .IsUnicode(false);

            modelBuilder.Entity<FaWeisung>()
                .Property(e => e.Auflage)
                .IsUnicode(false);

            modelBuilder.Entity<FaWeisung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FaWeisung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FaWeisung>()
                .Property(e => e.FaWeisungTS)
                .IsFixedLength();

            modelBuilder.Entity<FaWeisung_BaPerson>()
                .Property(e => e.FaWeisung_BaPersonTS)
                .IsFixedLength();

            modelBuilder.Entity<FaWeisungProtokoll>()
                .Property(e => e.Aktion)
                .IsUnicode(false);

            modelBuilder.Entity<FaWeisungProtokoll>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<FaWeisungProtokoll>()
                .Property(e => e.Verantwortlich)
                .IsUnicode(false);

            modelBuilder.Entity<FaWeisungProtokoll>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FaWeisungProtokoll>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FaWeisungProtokoll>()
                .Property(e => e.FaWeisung_ProtokollTS)
                .IsFixedLength();

            modelBuilder.Entity<FaWeisungWorkflow>()
                .Property(e => e.Aktion)
                .IsUnicode(false);

            modelBuilder.Entity<FaWeisungWorkflow>()
                .Property(e => e.FaWeisungWorkflowTS)
                .IsFixedLength();

            modelBuilder.Entity<FaZeitlichePlanung>()
                .Property(e => e.Phase1Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<FaZeitlichePlanung>()
                .Property(e => e.Phase2Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<FaZeitlichePlanung>()
                .Property(e => e.Phase3Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<FaZeitlichePlanung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FaZeitlichePlanung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FaZeitlichePlanung>()
                .Property(e => e.FaZeitlichePlanungTS)
                .IsFixedLength();

            modelBuilder.Entity<FbBarauszahlungAuftrag>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FbBarauszahlungAuftrag>()
                .Property(e => e.Buchungstext)
                .IsUnicode(false);

            modelBuilder.Entity<FbBarauszahlungAuftrag>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FbBarauszahlungAuftrag>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FbBarauszahlungAuftrag>()
                .Property(e => e.FbBarauszahlungAuftragTS)
                .IsFixedLength();

            modelBuilder.Entity<FbBarauszahlungAuftrag>()
                .HasMany(e => e.FbBarauszahlungZyklus)
                .WithRequired(e => e.FbBarauszahlungAuftrag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FbBarauszahlungAusbezahlt>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FbBarauszahlungAusbezahlt>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FbBarauszahlungAusbezahlt>()
                .Property(e => e.FbBarauszahlungAusbezahltTS)
                .IsFixedLength();

            modelBuilder.Entity<FbBarauszahlungZyklu>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FbBarauszahlungZyklu>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FbBarauszahlungZyklu>()
                .Property(e => e.FbBarauszahlungZyklusTS)
                .IsFixedLength();

            modelBuilder.Entity<FbBarauszahlungZyklu>()
                .HasMany(e => e.FbBarauszahlungAusbezahlts)
                .WithRequired(e => e.FbBarauszahlungZyklu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FbBelegNr>()
                .Property(e => e.Praefix)
                .IsUnicode(false);

            modelBuilder.Entity<FbBelegNr>()
                .Property(e => e.FbBelegNrTS)
                .IsFixedLength();

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.BelegNr)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.PCKontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.BankKontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.IBAN)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.ReferenzNummer)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.Zahlungsgrund)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.Zusatz)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.Strasse)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.PLZ)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.Ort)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchung>()
                .Property(e => e.FbBuchungTS)
                .IsFixedLength();

            modelBuilder.Entity<FbBuchung>()
                .HasMany(e => e.FbBarauszahlungAusbezahlts)
                .WithRequired(e => e.FbBuchung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FbBuchung>()
                .HasMany(e => e.FbDTABuchungs)
                .WithRequired(e => e.FbBuchung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FbBuchungCode>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchungCode>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FbBuchungCode>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchungCode>()
                .Property(e => e.FbBuchungCodeTS)
                .IsFixedLength();

            modelBuilder.Entity<FbBuchungskrei>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FbBuchungskrei>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<FbBuchungskrei>()
                .Property(e => e.FbBuchungskreisTS)
                .IsFixedLength();

            modelBuilder.Entity<FbDauerauftrag>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<FbDauerauftrag>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FbDauerauftrag>()
                .Property(e => e.ReferenzNummer)
                .IsUnicode(false);

            modelBuilder.Entity<FbDauerauftrag>()
                .Property(e => e.Zahlungsgrund)
                .IsUnicode(false);

            modelBuilder.Entity<FbDauerauftrag>()
                .Property(e => e.FbDauerauftragTS)
                .IsFixedLength();

            modelBuilder.Entity<FbDTABuchung>()
                .Property(e => e.FbDTABuchungTS)
                .IsFixedLength();

            modelBuilder.Entity<FbDTAJournal>()
                .Property(e => e.FilePath)
                .IsUnicode(false);

            modelBuilder.Entity<FbDTAJournal>()
                .Property(e => e.TotalBetrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FbDTAJournal>()
                .Property(e => e.PaymentMessageID)
                .IsUnicode(false);

            modelBuilder.Entity<FbDTAJournal>()
                .Property(e => e.Zahlungsdaten)
                .IsUnicode(false);

            modelBuilder.Entity<FbDTAJournal>()
                .Property(e => e.FbDTAJournalTS)
                .IsFixedLength();

            modelBuilder.Entity<FbDTAJournal>()
                .HasMany(e => e.FbDTABuchungs)
                .WithRequired(e => e.FbDTAJournal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FbDTAZugang>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FbDTAZugang>()
                .Property(e => e.VertragNr)
                .IsUnicode(false);

            modelBuilder.Entity<FbDTAZugang>()
                .Property(e => e.KontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<FbDTAZugang>()
                .Property(e => e.FbDTAZugangTS)
                .IsFixedLength();

            modelBuilder.Entity<FbKonto>()
                .Property(e => e.KontoName)
                .IsUnicode(false);

            modelBuilder.Entity<FbKonto>()
                .Property(e => e.EroeffnungsSaldo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FbKonto>()
                .Property(e => e.SaldoGruppeName)
                .IsUnicode(false);

            modelBuilder.Entity<FbKonto>()
                .Property(e => e.FbKontoTS)
                .IsFixedLength();

            modelBuilder.Entity<FbKonto>()
                .Property(e => e.FbDepotNr)
                .IsUnicode(false);

            modelBuilder.Entity<FbKonto>()
                .Property(e => e.EroeffnungsSaldoModifier)
                .IsUnicode(false);

            modelBuilder.Entity<FbKonto>()
                .Property(e => e.EroeffnungsSaldoCreator)
                .IsUnicode(false);

            modelBuilder.Entity<FbKonto>()
                .Property(e => e.EroeffnungsSaldo_AtCreation)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FbKreditor>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FbKreditor>()
                .Property(e => e.KurzName)
                .IsUnicode(false);

            modelBuilder.Entity<FbKreditor>()
                .Property(e => e.Zusatz)
                .IsUnicode(false);

            modelBuilder.Entity<FbKreditor>()
                .Property(e => e.Strasse)
                .IsUnicode(false);

            modelBuilder.Entity<FbKreditor>()
                .Property(e => e.PLZ)
                .IsUnicode(false);

            modelBuilder.Entity<FbKreditor>()
                .Property(e => e.Ort)
                .IsUnicode(false);

            modelBuilder.Entity<FbKreditor>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FbKreditor>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FbKreditor>()
                .Property(e => e.FbKreditorTS)
                .IsFixedLength();

            modelBuilder.Entity<FbKreditor>()
                .HasMany(e => e.FbZahlungswegs)
                .WithRequired(e => e.FbKreditor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FbPeriode>()
                .Property(e => e.FbPeriodeTS)
                .IsFixedLength();

            modelBuilder.Entity<FbPeriode>()
                .HasMany(e => e.FbBuchungs)
                .WithRequired(e => e.FbPeriode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FbTeam>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FbTeam>()
                .Property(e => e.FbTeamTS)
                .IsFixedLength();

            modelBuilder.Entity<FbTeam>()
                .HasMany(e => e.FbDTAZugangs)
                .WithOptional(e => e.FbTeam)
                .WillCascadeOnDelete();

            modelBuilder.Entity<FbTeamMitglied>()
                .Property(e => e.FbTeamMitgliedTS)
                .IsFixedLength();

            modelBuilder.Entity<FbZahlungsweg>()
                .Property(e => e.PCKontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<FbZahlungsweg>()
                .Property(e => e.BankKontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<FbZahlungsweg>()
                .Property(e => e.IBAN)
                .IsUnicode(false);

            modelBuilder.Entity<FbZahlungsweg>()
                .Property(e => e.BelegBankKontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<FbZahlungsweg>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FbZahlungsweg>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FbZahlungsweg>()
                .Property(e => e.FbZahlungswegTS)
                .IsFixedLength();

            modelBuilder.Entity<FbZahlungsweg>()
                .HasMany(e => e.FbDauerauftrags)
                .WithRequired(e => e.FbZahlungsweg)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FsDienstleistung>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FsDienstleistung>()
                .Property(e => e.StandardAufwand)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FsDienstleistung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FsDienstleistung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FsDienstleistung>()
                .Property(e => e.FsDienstleistungTS)
                .IsFixedLength();

            modelBuilder.Entity<FsDienstleistung>()
                .HasMany(e => e.FsDienstleistung_FsDienstleistungspaket)
                .WithRequired(e => e.FsDienstleistung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FsDienstleistung_FsDienstleistungspaket>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FsDienstleistung_FsDienstleistungspaket>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FsDienstleistung_FsDienstleistungspaket>()
                .Property(e => e.FsDienstleistung_FsDienstleistungspaketTS)
                .IsFixedLength();

            modelBuilder.Entity<FsDienstleistungspaket>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FsDienstleistungspaket>()
                .Property(e => e.MaximaleLaufzeit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FsDienstleistungspaket>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FsDienstleistungspaket>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FsDienstleistungspaket>()
                .Property(e => e.FsDienstleistungspaketTS)
                .IsFixedLength();

            modelBuilder.Entity<FsDienstleistungspaket>()
                .HasMany(e => e.FaPhases)
                .WithOptional(e => e.FsDienstleistungspaket)
                .HasForeignKey(e => e.FsDienstleistungspaketID_Bedarf);

            modelBuilder.Entity<FsDienstleistungspaket>()
                .HasMany(e => e.FaPhases1)
                .WithOptional(e => e.FsDienstleistungspaket1)
                .HasForeignKey(e => e.FsDienstleistungspaketID_Zugewiesen);

            modelBuilder.Entity<FsDienstleistungspaket>()
                .HasMany(e => e.FsDienstleistung_FsDienstleistungspaket)
                .WithRequired(e => e.FsDienstleistungspaket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FsReduktion>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FsReduktion>()
                .Property(e => e.StandardAufwand)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FsReduktion>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FsReduktion>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FsReduktion>()
                .Property(e => e.FsReduktionTS)
                .IsFixedLength();

            modelBuilder.Entity<FsReduktion>()
                .HasMany(e => e.FsReduktionMitarbeiters)
                .WithRequired(e => e.FsReduktion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FsReduktionMitarbeiter>()
                .Property(e => e.OriginalReduktionZeit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FsReduktionMitarbeiter>()
                .Property(e => e.AngepassteReduktionZeit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FsReduktionMitarbeiter>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<FsReduktionMitarbeiter>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<FsReduktionMitarbeiter>()
                .Property(e => e.FsReduktionMitarbeiterTS)
                .IsFixedLength();

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.BeantragendeStelle)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.Kontaktperson)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.Strasse)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.HausNr)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.Zusatz)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.PLZ)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.Ort)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.Kanton)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.Postfach)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.MitteilungZeile1)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.MitteilungZeile2)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.MitteilungZeile3)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.MitteilungZeile4)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.Zahlungsinstruktion)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<GvAbklaerendeStelle>()
                .Property(e => e.GvAbklaerendeStelleTS)
                .IsFixedLength();

            modelBuilder.Entity<GvAntragPosition>()
                .Property(e => e.Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<GvAntragPosition>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GvAntragPosition>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<GvAntragPosition>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<GvAntragPosition>()
                .Property(e => e.GvAntragPositionTS)
                .IsFixedLength();

            modelBuilder.Entity<GvAuflage>()
                .Property(e => e.Gegenstand)
                .IsUnicode(false);

            modelBuilder.Entity<GvAuflage>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GvAuflage>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<GvAuflage>()
                .Property(e => e.Erlassungsgrund)
                .IsUnicode(false);

            modelBuilder.Entity<GvAuflage>()
                .Property(e => e.Rate1Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GvAuflage>()
                .Property(e => e.Rate2Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GvAuflage>()
                .Property(e => e.Rate3Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GvAuflage>()
                .Property(e => e.Rate4Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GvAuflage>()
                .Property(e => e.Rate5Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GvAuflage>()
                .Property(e => e.Rate6Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GvAuflage>()
                .Property(e => e.Rate7Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GvAuflage>()
                .Property(e => e.Rate8Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GvAuflage>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<GvAuflage>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<GvAuflage>()
                .Property(e => e.GvAuflageTS)
                .IsFixedLength();

            modelBuilder.Entity<GvAuszahlungPosition>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GvAuszahlungPosition>()
                .Property(e => e.ReferenzNummer)
                .IsUnicode(false);

            modelBuilder.Entity<GvAuszahlungPosition>()
                .Property(e => e.Zahlungsinstruktion)
                .IsUnicode(false);

            modelBuilder.Entity<GvAuszahlungPosition>()
                .Property(e => e.MitteilungZeile1)
                .IsUnicode(false);

            modelBuilder.Entity<GvAuszahlungPosition>()
                .Property(e => e.MitteilungZeile2)
                .IsUnicode(false);

            modelBuilder.Entity<GvAuszahlungPosition>()
                .Property(e => e.MitteilungZeile3)
                .IsUnicode(false);

            modelBuilder.Entity<GvAuszahlungPosition>()
                .Property(e => e.MitteilungZeile4)
                .IsUnicode(false);

            modelBuilder.Entity<GvAuszahlungPosition>()
                .Property(e => e.BuchungsText)
                .IsUnicode(false);

            modelBuilder.Entity<GvAuszahlungPosition>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<GvAuszahlungPosition>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<GvAuszahlungPosition>()
                .Property(e => e.GvAuszahlungPositionTS)
                .IsFixedLength();

            modelBuilder.Entity<GvAuszahlungPosition>()
                .HasMany(e => e.GvAuszahlungPositionValutas)
                .WithRequired(e => e.GvAuszahlungPosition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GvAuszahlungPositionValuta>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<GvAuszahlungPositionValuta>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<GvAuszahlungPositionValuta>()
                .Property(e => e.GvAuszahlungPositionValutaTS)
                .IsFixedLength();

            modelBuilder.Entity<GvBewilligung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<GvBewilligung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<GvBewilligung>()
                .Property(e => e.GvBewilligungTS)
                .IsFixedLength();

            modelBuilder.Entity<GvDocument>()
                .Property(e => e.Stichworte)
                .IsUnicode(false);

            modelBuilder.Entity<GvDocument>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<GvDocument>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<GvDocument>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<GvDocument>()
                .Property(e => e.GvDocumentTS)
                .IsFixedLength();

            modelBuilder.Entity<GvDokumenteInformation>()
                .Property(e => e.Information)
                .IsUnicode(false);

            modelBuilder.Entity<GvDokumenteInformation>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<GvDokumenteInformation>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<GvDokumenteInformation>()
                .Property(e => e.GvDokumenteInformationTS)
                .IsFixedLength();

            modelBuilder.Entity<GvFond>()
                .Property(e => e.NameKurz)
                .IsUnicode(false);

            modelBuilder.Entity<GvFond>()
                .Property(e => e.NameLang)
                .IsUnicode(false);

            modelBuilder.Entity<GvFond>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<GvFond>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<GvFond>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<GvFond>()
                .Property(e => e.GvFondsTS)
                .IsFixedLength();

            modelBuilder.Entity<GvFond>()
                .HasMany(e => e.GvFonds_XOrgUnit)
                .WithRequired(e => e.GvFond)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GvFond>()
                .HasMany(e => e.GvGesuches)
                .WithRequired(e => e.GvFond)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GvFonds_XOrgUnit>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<GvFonds_XOrgUnit>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<GvFonds_XOrgUnit>()
                .Property(e => e.GvFonds_XOrgUnitTS)
                .IsFixedLength();

            modelBuilder.Entity<GvGesuch>()
                .Property(e => e.BetragBewilligt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GvGesuch>()
                .Property(e => e.Begruendung)
                .IsUnicode(false);

            modelBuilder.Entity<GvGesuch>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<GvGesuch>()
                .Property(e => e.BetragBewilligtKompetenzstufe1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GvGesuch>()
                .Property(e => e.BemerkungBewilligungKompetenzstufe1)
                .IsUnicode(false);

            modelBuilder.Entity<GvGesuch>()
                .Property(e => e.BetragBewilligtKompetenzstufe2)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GvGesuch>()
                .Property(e => e.BemerkungBewilligungKompetenzstufe2)
                .IsUnicode(false);

            modelBuilder.Entity<GvGesuch>()
                .Property(e => e.Gesuchsgrund)
                .IsUnicode(false);

            modelBuilder.Entity<GvGesuch>()
                .Property(e => e.ErfasstesGesuchBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<GvGesuch>()
                .Property(e => e.AbgeschlossenesGesuchBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<GvGesuch>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<GvGesuch>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<GvGesuch>()
                .Property(e => e.GvGesuchTS)
                .IsFixedLength();

            modelBuilder.Entity<GvGesuch>()
                .HasMany(e => e.GvAbklaerendeStelles)
                .WithRequired(e => e.GvGesuch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GvGesuch>()
                .HasMany(e => e.GvAntragPositions)
                .WithRequired(e => e.GvGesuch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GvGesuch>()
                .HasMany(e => e.GvAuflages)
                .WithRequired(e => e.GvGesuch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GvGesuch>()
                .HasMany(e => e.GvAuszahlungPositions)
                .WithRequired(e => e.GvGesuch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GvGesuch>()
                .HasMany(e => e.GvBewilligungs)
                .WithRequired(e => e.GvGesuch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GvGesuch>()
                .HasMany(e => e.GvDocuments)
                .WithRequired(e => e.GvGesuch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GvPositionsart>()
                .Property(e => e.Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<GvPositionsart>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<GvPositionsart>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<GvPositionsart>()
                .Property(e => e.GvPositionsartTS)
                .IsFixedLength();

            modelBuilder.Entity<GvPositionsart>()
                .HasMany(e => e.GvAuszahlungPositions)
                .WithRequired(e => e.GvPositionsart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GvPositionsart>()
                .HasOptional(e => e.GvPositionsart1)
                .WithRequired(e => e.GvPositionsart2);

            modelBuilder.Entity<GvPositionsart>()
                .HasMany(e => e.GvPositionsart11)
                .WithOptional(e => e.GvPositionsart3)
                .HasForeignKey(e => e.GvPositionsartID_CopyOf);

            modelBuilder.Entity<Hist_BaAdresse>()
                .Property(e => e.CareOf)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaAdresse>()
                .Property(e => e.Zusatz)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaAdresse>()
                .Property(e => e.ZuhandenVon)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaAdresse>()
                .Property(e => e.Strasse)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaAdresse>()
                .Property(e => e.HausNr)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaAdresse>()
                .Property(e => e.Postfach)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaAdresse>()
                .Property(e => e.PLZ)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaAdresse>()
                .Property(e => e.Ort)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaAdresse>()
                .Property(e => e.Kanton)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaAdresse>()
                .Property(e => e.Bezirk)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaAdresse>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaAdresse>()
                .Property(e => e.InstitutionName)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaAdresse>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaAdresse>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.FruehererName)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.Vorname)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.Vorname2)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.AHVNummer)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.Versichertennummer)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.HaushaltVersicherungsNummer)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.NNummer)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.BFFNummer)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.ZARNummer)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.KantonaleReferenznummer)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.HeimatgemeindeCodes)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.Telefon_P)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.Telefon_G)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.MobilTel1)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.MobilTel2)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.EinwohnerregisterID)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.ZuzugKtPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.ZuzugKtOrt)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.ZuzugKtKanton)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.ZuzugGdePLZ)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.ZuzugGdeOrt)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.ZuzugGdeKanton)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.UntWohnsitzPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.UntWohnsitzOrt)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.UntWohnsitzKanton)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.WegzugPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.WegzugOrt)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.WegzugKanton)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.ArbeitSpezFaehigkeiten)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.PUKrankenkasse)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.AndereSVLeistungen)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.Anrede)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.BemerkungenAdresse)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.BemerkungenSV)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.Briefanrede)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.Einrichtpauschale)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.MobilTel)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.NavigatorZusatz)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.Sprachpauschale)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.visdat36Area)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.visdat36ID)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.WichtigerHinweis)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.ZEMISNummer)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BaPerson>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BDEFerienkuerzungen_XUser>()
                .Property(e => e.FerienkuerzungStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_BDELeistung>()
                .Property(e => e.Dauer)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_BDELeistung>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BDELeistungsart>()
                .Property(e => e.Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BDELeistungsart>()
                .Property(e => e.ArtikelNr)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BDELeistungsart>()
                .Property(e => e.KTRStandard)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BDELeistungsart>()
                .Property(e => e.KTRIV)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BDELeistungsart>()
                .Property(e => e.KTRAHV)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BDELeistungsart>()
                .Property(e => e.KTRNichtberechtigte)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BDELeistungsart>()
                .Property(e => e.Beschreibung)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_BDESollStundenProJahr_XUser>()
                .Property(e => e.JanuarStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_BDESollStundenProJahr_XUser>()
                .Property(e => e.FebruarStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_BDESollStundenProJahr_XUser>()
                .Property(e => e.MaerzStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_BDESollStundenProJahr_XUser>()
                .Property(e => e.AprilStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_BDESollStundenProJahr_XUser>()
                .Property(e => e.MaiStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_BDESollStundenProJahr_XUser>()
                .Property(e => e.JuniStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_BDESollStundenProJahr_XUser>()
                .Property(e => e.JuliStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_BDESollStundenProJahr_XUser>()
                .Property(e => e.AugustStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_BDESollStundenProJahr_XUser>()
                .Property(e => e.SeptemberStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_BDESollStundenProJahr_XUser>()
                .Property(e => e.OktoberStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_BDESollStundenProJahr_XUser>()
                .Property(e => e.NovemberStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_BDESollStundenProJahr_XUser>()
                .Property(e => e.DezemberStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_BDESollStundenProJahr_XUser>()
                .Property(e => e.TotalStd)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.ItemName)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.PCKonto)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.AD_Abteilung)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.Adressat)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.AdresseKGS)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.AdresseAbteilung)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.AdresseStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.Postfach)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.AdresseHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.AdressePLZ)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.AdresseOrt)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.WWW)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.Internet)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.Text1)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.Text2)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.Text3)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.Text4)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XOrgUnit>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.MitarbeiterNr)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.LogonName)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.ShortName)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.PhoneMobile)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.PhoneOffice)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.PhoneIntern)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.PhonePrivat)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.Funktion)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.Text1)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.Text2)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.WeitereKostentraeger)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.MigHerkunft)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.MigMAKuerzel)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.visdat36Area)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.visdat36SourceFile)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.visdat36ID)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.visdat36Name)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUser>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart2)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart3)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart4)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart5)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart6)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart7)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart8)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart9)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart10)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart11)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart12)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart13)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart14)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart15)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart16)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart17)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart18)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart19)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Lohnart20)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<Hist_XUserStundenansatz>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<HistoryVersion>()
                .Property(e => e.HostName)
                .IsUnicode(false);

            modelBuilder.Entity<HistoryVersion>()
                .Property(e => e.SystemUser)
                .IsUnicode(false);

            modelBuilder.Entity<HistoryVersion>()
                .Property(e => e.AppName)
                .IsUnicode(false);

            modelBuilder.Entity<HistoryVersion>()
                .Property(e => e.AppUser)
                .IsUnicode(false);

            modelBuilder.Entity<HistoryVersion>()
                .Property(e => e.UserAction)
                .IsUnicode(false);

            modelBuilder.Entity<IkAbklaerung>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<IkAbklaerung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<IkAbklaerung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<IkAbklaerung>()
                .Property(e => e.IkAbklaerungTS)
                .IsFixedLength();

            modelBuilder.Entity<IkAnzeige>()
                .Property(e => e.EroeffnungGrund)
                .IsUnicode(false);

            modelBuilder.Entity<IkAnzeige>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<IkAnzeige>()
                .Property(e => e.IkAnzeigeTS)
                .IsFixedLength();

            modelBuilder.Entity<IkBetreibung>()
                .Property(e => e.BetreibungNummer)
                .IsUnicode(false);

            modelBuilder.Entity<IkBetreibung>()
                .Property(e => e.BetreibungAmt)
                .IsUnicode(false);

            modelBuilder.Entity<IkBetreibung>()
                .Property(e => e.BetreibungBetrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkBetreibung>()
                .Property(e => e.Glaeubiger)
                .IsUnicode(false);

            modelBuilder.Entity<IkBetreibung>()
                .Property(e => e.VerlustscheinNummer)
                .IsUnicode(false);

            modelBuilder.Entity<IkBetreibung>()
                .Property(e => e.VerlustscheinAmt)
                .IsUnicode(false);

            modelBuilder.Entity<IkBetreibung>()
                .Property(e => e.VerlustscheinBetrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkBetreibung>()
                .Property(e => e.VerlustscheinZins)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkBetreibung>()
                .Property(e => e.VerlustscheinKosten)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkBetreibung>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<IkBetreibung>()
                .Property(e => e.IkBetreibungTS)
                .IsFixedLength();

            modelBuilder.Entity<IkBetreibung>()
                .HasMany(e => e.IkBetreibungAusgleiches)
                .WithRequired(e => e.IkBetreibung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IkBetreibungAusgleich>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkBetreibungAusgleich>()
                .Property(e => e.IkBetreibungAusgleichTS)
                .IsFixedLength();

            modelBuilder.Entity<IkEinkomman>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkEinkomman>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<IkEinkomman>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<IkEinkomman>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<IkEinkomman>()
                .Property(e => e.IkEinkommenTS)
                .IsFixedLength();

            modelBuilder.Entity<IkForderung>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkForderung>()
                .Property(e => e.IndexStandBeiBerechnung)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkForderung>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<IkForderung>()
                .Property(e => e.TeilALBVBetrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkForderung>()
                .Property(e => e.IkForderungTS)
                .IsFixedLength();

            modelBuilder.Entity<IkForderung_BgKostenart>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<IkForderung_BgKostenart>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<IkForderung_BgKostenart>()
                .Property(e => e.IkForderung_BgKostenartTS)
                .IsFixedLength();

            modelBuilder.Entity<IkForderungBgKostenartHist>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<IkForderungBgKostenartHist>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<IkForderungBgKostenartHist>()
                .Property(e => e.IkForderungBgKostenartHistTS)
                .IsFixedLength();

            modelBuilder.Entity<IkForderungPosition>()
                .Property(e => e.IkForderungPositionTS)
                .IsFixedLength();

            modelBuilder.Entity<IkGlaeubiger>()
                .Property(e => e.Ausbildung)
                .IsUnicode(false);

            modelBuilder.Entity<IkGlaeubiger>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<IkGlaeubiger>()
                .Property(e => e.IkGlaeubigerTS)
                .IsFixedLength();

            modelBuilder.Entity<IkLandesindex>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<IkLandesindex>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<IkLandesindex>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<IkLandesindex>()
                .Property(e => e.IkLandesindexTS)
                .IsFixedLength();

            modelBuilder.Entity<IkLandesindex>()
                .HasMany(e => e.IkLandesindexWerts)
                .WithRequired(e => e.IkLandesindex)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IkLandesindexWert>()
                .Property(e => e.Wert)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkLandesindexWert>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<IkLandesindexWert>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<IkLandesindexWert>()
                .Property(e => e.IkLandesindexWertTS)
                .IsFixedLength();

            modelBuilder.Entity<IkPosition>()
                .Property(e => e.TotalAliment)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkPosition>()
                .Property(e => e.TotalAlimentSoll)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkPosition>()
                .Property(e => e.BetragALBV)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkPosition>()
                .Property(e => e.BetragALBVSoll)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkPosition>()
                .Property(e => e.BetragKiZulage)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkPosition>()
                .Property(e => e.BetragKiZulageSoll)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkPosition>()
                .Property(e => e.BetragALBVverrechnung)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkPosition>()
                .Property(e => e.BetragEinmalig)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkPosition>()
                .Property(e => e.BetragAuszahlung)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkPosition>()
                .Property(e => e.IndexStandBeiBerechnung)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkPosition>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<IkPosition>()
                .Property(e => e.IkPositionTS)
                .IsFixedLength();

            modelBuilder.Entity<IkRatenplan>()
                .Property(e => e.Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<IkRatenplan>()
                .Property(e => e.GesamtBetrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkRatenplan>()
                .Property(e => e.BetragProMonat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkRatenplan>()
                .Property(e => e.LetzterProMonat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkRatenplan>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<IkRatenplan>()
                .Property(e => e.IkRatenplanTS)
                .IsFixedLength();

            modelBuilder.Entity<IkRatenplanForderung>()
                .Property(e => e.IkRatenplanForderungTS)
                .IsFixedLength();

            modelBuilder.Entity<IkRechtstitel>()
                .Property(e => e.InkassoFallName)
                .IsUnicode(false);

            modelBuilder.Entity<IkRechtstitel>()
                .Property(e => e.RechtstitelInfo)
                .IsUnicode(false);

            modelBuilder.Entity<IkRechtstitel>()
                .Property(e => e.ElterlicheSorgeBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<IkRechtstitel>()
                .Property(e => e.BasisKinderalimente)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkRechtstitel>()
                .Property(e => e.BasisEhegattenalimente)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkRechtstitel>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<IkRechtstitel>()
                .Property(e => e.IkRechtstitelTS)
                .IsFixedLength();

            modelBuilder.Entity<IkRechtstitel>()
                .HasMany(e => e.IkEinkommen)
                .WithRequired(e => e.IkRechtstitel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IkRechtstitel>()
                .HasMany(e => e.IkVerrechnungskontoes)
                .WithRequired(e => e.IkRechtstitel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IkVerrechnungskonto>()
                .Property(e => e.Grundforderung)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkVerrechnungskonto>()
                .Property(e => e.BetragProMonat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkVerrechnungskonto>()
                .Property(e => e.LetzterMonat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<IkVerrechnungskonto>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<IkVerrechnungskonto>()
                .Property(e => e.IkVerrechnungskontoTS)
                .IsFixedLength();

            modelBuilder.Entity<KaAbklaerungIntake>()
                .Property(e => e.AsdFragen)
                .IsUnicode(false);

            modelBuilder.Entity<KaAbklaerungIntake>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaAbklaerungIntake>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaAbklaerungIntake>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaAbklaerungIntake>()
                .Property(e => e.KaAbklaerungIntakeTS)
                .IsFixedLength();

            modelBuilder.Entity<KaAbklaerungVertieft>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaAbklaerungVertieft>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaAbklaerungVertieft>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaAbklaerungVertieft>()
                .Property(e => e.KaAbklaerungVertieftTS)
                .IsFixedLength();

            modelBuilder.Entity<KaAbklaerungVertieft>()
                .HasMany(e => e.KaAbklaerungVertieftProbeeinsatzs)
                .WithRequired(e => e.KaAbklaerungVertieft)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KaAbklaerungVertieftProbeeinsatz>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaAbklaerungVertieftProbeeinsatz>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaAbklaerungVertieftProbeeinsatz>()
                .Property(e => e.KaAbklaerungVertieftProbeeinsatzTS)
                .IsFixedLength();

            modelBuilder.Entity<KaAKZuweiser>()
                .Property(e => e.KaAKZuweiserTS)
                .IsFixedLength();

            modelBuilder.Entity<KaAllgemein>()
                .Property(e => e.KaAllgemeinTS)
                .IsFixedLength();

            modelBuilder.Entity<KaAmmBesch>()
                .Property(e => e.KaAKZuweiserTS)
                .IsFixedLength();

            modelBuilder.Entity<KaArbeitsrapport>()
                .Property(e => e.AM_Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaArbeitsrapport>()
                .Property(e => e.PM_Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaArbeitsrapport>()
                .Property(e => e.KaArbeitsrapportTS)
                .IsFixedLength();

            modelBuilder.Entity<KaAssistenz>()
                .Property(e => e.Einsatzplatz)
                .IsUnicode(false);

            modelBuilder.Entity<KaAssistenz>()
                .Property(e => e.Stufe)
                .IsUnicode(false);

            modelBuilder.Entity<KaAssistenz>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<KaAssistenz>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaAssistenz>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaAssistenz>()
                .Property(e => e.KaAssistenzTS)
                .IsFixedLength();

            modelBuilder.Entity<KaAusbildung>()
                .Property(e => e.Andere)
                .IsUnicode(false);

            modelBuilder.Entity<KaAusbildung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaAusbildung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaAusbildung>()
                .Property(e => e.KaAusbildungTS)
                .IsFixedLength();

            modelBuilder.Entity<KaBetrieb>()
                .Property(e => e.BetriebName)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetrieb>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetrieb>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetrieb>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetrieb>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetrieb>()
                .Property(e => e.Homepage)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetrieb>()
                .Property(e => e.KontaktPerson_OBSOLETE)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetrieb>()
                .Property(e => e.KaBetriebTS)
                .IsFixedLength();

            modelBuilder.Entity<KaBetrieb>()
                .HasMany(e => e.BaAdresses)
                .WithOptional(e => e.KaBetrieb)
                .WillCascadeOnDelete();

            modelBuilder.Entity<KaBetriebBesprechung>()
                .Property(e => e.Stichwort)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetriebBesprechung>()
                .Property(e => e.Inhalt)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetriebBesprechung>()
                .Property(e => e.KaBetriebBesprechungTS)
                .IsFixedLength();

            modelBuilder.Entity<KaBetriebDokument>()
                .Property(e => e.Stichwort)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetriebDokument>()
                .Property(e => e.KaBetriebDokumentTS)
                .IsFixedLength();

            modelBuilder.Entity<KaBetriebKontakt>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetriebKontakt>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetriebKontakt>()
                .Property(e => e.Vorname)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetriebKontakt>()
                .Property(e => e.Funktion)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetriebKontakt>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetriebKontakt>()
                .Property(e => e.TelefonMobil)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetriebKontakt>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetriebKontakt>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetriebKontakt>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaBetriebKontakt>()
                .Property(e => e.KaBetriebKontaktTS)
                .IsFixedLength();

            modelBuilder.Entity<KaBetriebKontakt>()
                .HasMany(e => e.BaAdresses)
                .WithOptional(e => e.KaBetriebKontakt)
                .WillCascadeOnDelete();

            modelBuilder.Entity<KaBetriebKontakt>()
                .HasMany(e => e.KaEinsatzplatzs)
                .WithOptional(e => e.KaBetriebKontakt)
                .HasForeignKey(e => e.KaKontaktpersonID);

            modelBuilder.Entity<KaEafSozioberuflicheBilanz>()
                .Property(e => e.AnwesendTeilzeit)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSozioberuflicheBilanz>()
                .Property(e => e.Schwerpunkte)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSozioberuflicheBilanz>()
                .Property(e => e.ProzessBemerkungenAbschluss)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSozioberuflicheBilanz>()
                .Property(e => e.AufnahmeZielsetzungenRAV)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSozioberuflicheBilanz>()
                .Property(e => e.AufnahmeErgebnisseInterview)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSozioberuflicheBilanz>()
                .Property(e => e.AufnahmeErgebnisseBewerbung)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSozioberuflicheBilanz>()
                .Property(e => e.AufnahmeErgebnisseAssessment)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSozioberuflicheBilanz>()
                .Property(e => e.AufnahmeErgebnisseWerkstatt)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSozioberuflicheBilanz>()
                .Property(e => e.InterventionenAufforderung)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSozioberuflicheBilanz>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSozioberuflicheBilanz>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSozioberuflicheBilanz>()
                .Property(e => e.KaEafSozioberuflicheBilanzTS)
                .IsFixedLength();

            modelBuilder.Entity<KaEafSpezifischeErmittlung>()
                .Property(e => e.AnwesendTeilzeit)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSpezifischeErmittlung>()
                .Property(e => e.Zielsetzungen)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSpezifischeErmittlung>()
                .Property(e => e.ProzessBemerkungenAbschluss)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSpezifischeErmittlung>()
                .Property(e => e.InterventionenAufforderung1)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSpezifischeErmittlung>()
                .Property(e => e.InterventionenAufforderung2)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSpezifischeErmittlung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSpezifischeErmittlung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaEafSpezifischeErmittlung>()
                .Property(e => e.KaEafSpezifischeErmittlungTS)
                .IsFixedLength();

            modelBuilder.Entity<KaEinsatz>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaEinsatz>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaEinsatz>()
                .Property(e => e.KaEinsatzTS)
                .IsFixedLength();

            modelBuilder.Entity<KaEinsatz>()
                .HasMany(e => e.KaAmmBesches)
                .WithRequired(e => e.KaEinsatz)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KaEinsatzplatz>()
                .Property(e => e.Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<KaEinsatzplatz>()
                .Property(e => e.Details)
                .IsUnicode(false);

            modelBuilder.Entity<KaEinsatzplatz>()
                .Property(e => e.WeitereAnforderungen)
                .IsUnicode(false);

            modelBuilder.Entity<KaEinsatzplatz>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaEinsatzplatz>()
                .Property(e => e.KaEinsatzplatzTS)
                .IsFixedLength();

            modelBuilder.Entity<KaEinsatzplatz2>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<KaEinsatzplatz2>()
                .Property(e => e.KaEinsatzplatz2TS)
                .IsFixedLength();

            modelBuilder.Entity<KaEinsatzplatz2>()
                .HasMany(e => e.KaEinsatzs)
                .WithRequired(e => e.KaEinsatzplatz2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KaExterneBildung>()
                .Property(e => e.Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<KaExterneBildung>()
                .Property(e => e.Kursort)
                .IsUnicode(false);

            modelBuilder.Entity<KaExterneBildung>()
                .Property(e => e.AnteilKA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KaExterneBildung>()
                .Property(e => e.AnteilDritte)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KaExterneBildung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaExterneBildung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaExterneBildung>()
                .Property(e => e.KaExterneBildungTS)
                .IsFixedLength();

            modelBuilder.Entity<KaExterneBildungZahlung>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KaExterneBildungZahlung>()
                .Property(e => e.Zweck)
                .IsUnicode(false);

            modelBuilder.Entity<KaExterneBildungZahlung>()
                .Property(e => e.KaExterneBildungZahlungTS)
                .IsFixedLength();

            modelBuilder.Entity<KaInizio>()
                .Property(e => e.KaInizioTS)
                .IsFixedLength();

            modelBuilder.Entity<KaIntegBildung>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaIntegBildung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaIntegBildung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaIntegBildung>()
                .Property(e => e.KaIntegBildungTS)
                .IsFixedLength();

            modelBuilder.Entity<KaJobtimal>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<KaJobtimal>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaJobtimal>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaJobtimal>()
                .Property(e => e.KaJobtimalTS)
                .IsFixedLength();

            modelBuilder.Entity<KaJobtimalVertrag>()
                .Property(e => e.KaJobtimalVertragTS)
                .IsFixedLength();

            modelBuilder.Entity<KaKontaktartProzess>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaKontaktartProzess>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaKontaktartProzess>()
                .Property(e => e.KaKontaktartProzessTS)
                .IsFixedLength();

            modelBuilder.Entity<KaKur>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<KaKur>()
                .Property(e => e.KaKursTS)
                .IsFixedLength();

            modelBuilder.Entity<KaKur>()
                .HasMany(e => e.KaKurserfassungs)
                .WithRequired(e => e.KaKur)
                .HasForeignKey(e => e.KursID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KaKurserfassung>()
                .Property(e => e.KursNr)
                .IsUnicode(false);

            modelBuilder.Entity<KaKurserfassung>()
                .Property(e => e.KaKurserfassungTS)
                .IsFixedLength();

            modelBuilder.Entity<KaQEEPQ>()
                .Property(e => e.IntakeCodes)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEEPQ>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEEPQ>()
                .Property(e => e.IndivZieleRAV)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEEPQ>()
                .Property(e => e.IndivZieleRAVVerl)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEEPQ>()
                .Property(e => e.AustrittBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEEPQ>()
                .Property(e => e.muendAuffordBem1)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEEPQ>()
                .Property(e => e.muendAuffordBem2)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEEPQ>()
                .Property(e => e.KaQEEPQTS)
                .IsFixedLength();

            modelBuilder.Entity<KaQEEPQZielvereinb>()
                .Property(e => e.Feinziel)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEEPQZielvereinb>()
                .Property(e => e.ErreichenBis)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEEPQZielvereinb>()
                .Property(e => e.MessungZielerreichung)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEEPQZielvereinb>()
                .Property(e => e.Ergebnis)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEEPQZielvereinb>()
                .Property(e => e.KaQEEPQZielvereinbTS)
                .IsFixedLength();

            modelBuilder.Entity<KaQEEPQZielvereinbVerl>()
                .Property(e => e.Feinziel)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEEPQZielvereinbVerl>()
                .Property(e => e.ErreichenBis)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEEPQZielvereinbVerl>()
                .Property(e => e.MessungZielerreichung)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEEPQZielvereinbVerl>()
                .Property(e => e.Ergebnis)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEEPQZielvereinbVerl>()
                .Property(e => e.KaQEEPQZielvereinbVerlTS)
                .IsFixedLength();

            modelBuilder.Entity<KaQEJobtimum>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEJobtimum>()
                .Property(e => e.Zusatzinfos)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEJobtimum>()
                .Property(e => e.muendAuffordBem1)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEJobtimum>()
                .Property(e => e.muendAuffordBem2)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEJobtimum>()
                .Property(e => e.AustrittBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaQEJobtimum>()
                .Property(e => e.KaQEJobtimumTS)
                .IsFixedLength();

            modelBuilder.Entity<KaQJBildung>()
                .Property(e => e.KursCustom1Text)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJBildung>()
                .Property(e => e.KursCustom2Text)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJBildung>()
                .Property(e => e.KursCustom3Text)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJBildung>()
                .Property(e => e.KursCustom4Text)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJBildung>()
                .Property(e => e.KursCustom5Text)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJBildung>()
                .Property(e => e.KursCustom6Text)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJBildung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJBildung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJBildung>()
                .Property(e => e.KaQJBildungTS)
                .IsFixedLength();

            modelBuilder.Entity<KaQJIntake>()
                .Property(e => e.Eintritt)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJIntake>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJIntake>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJIntake>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJIntake>()
                .Property(e => e.KaQJIntakeTS)
                .IsFixedLength();

            modelBuilder.Entity<KaQJIntake>()
                .HasMany(e => e.KaQJIntakeGespraeches)
                .WithRequired(e => e.KaQJIntake)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KaQJIntakeGespraech>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJIntakeGespraech>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJIntakeGespraech>()
                .Property(e => e.KaQJIntakeGespraechTS)
                .IsFixedLength();

            modelBuilder.Entity<KaQJProzess>()
                .Property(e => e.AndereStellen)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJProzess>()
                .Property(e => e.KaQJProzessTS)
                .IsFixedLength();

            modelBuilder.Entity<KaQJPZAssessment>()
                .Property(e => e.ProjGefaehrGrund)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJPZAssessment>()
                .Property(e => e.NichtAufgGrund)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJPZAssessment>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJPZAssessment>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJPZAssessment>()
                .Property(e => e.KaQJPZAssessmentTS)
                .IsFixedLength();

            modelBuilder.Entity<KaQJPZBericht>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJPZBericht>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJPZBericht>()
                .Property(e => e.KaQJPZBerichtTS)
                .IsFixedLength();

            modelBuilder.Entity<KaQJPZSchlussbericht>()
                .Property(e => e.BemKompetenz)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJPZSchlussbericht>()
                .Property(e => e.BemBildung)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJPZSchlussbericht>()
                .Property(e => e.BemZielvereinbarung)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJPZSchlussbericht>()
                .Property(e => e.BemAbsenzen)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJPZSchlussbericht>()
                .Property(e => e.BemEmpfehlung)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJPZSchlussbericht>()
                .Property(e => e.EingVermittelbar)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJPZSchlussbericht>()
                .Property(e => e.KaQJPZSchlussberichtTS)
                .IsFixedLength();

            modelBuilder.Entity<KaQJPZZielvereinbarung>()
                .Property(e => e.VereinbartesZiel)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJPZZielvereinbarung>()
                .Property(e => e.ErreichenBis)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJPZZielvereinbarung>()
                .Property(e => e.KriterienPruefen)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJPZZielvereinbarung>()
                .Property(e => e.KaQJPZZielvereinbarungTS)
                .IsFixedLength();

            modelBuilder.Entity<KaQJVereinbarung>()
                .Property(e => e.GrundZiel)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJVereinbarung>()
                .Property(e => e.Abmachungen)
                .IsUnicode(false);

            modelBuilder.Entity<KaQJVereinbarung>()
                .Property(e => e.KaQJVereinbarungTS)
                .IsFixedLength();

            modelBuilder.Entity<KaSequenzen>()
                .Property(e => e.KaSequenzenTS)
                .IsFixedLength();

            modelBuilder.Entity<KaTransfer>()
                .Property(e => e.AllgZiele)
                .IsUnicode(false);

            modelBuilder.Entity<KaTransfer>()
                .Property(e => e.Bewerbungsstrategie)
                .IsUnicode(false);

            modelBuilder.Entity<KaTransfer>()
                .Property(e => e.MuendAufforderungBem1)
                .IsUnicode(false);

            modelBuilder.Entity<KaTransfer>()
                .Property(e => e.MuendAufforderungBem2)
                .IsUnicode(false);

            modelBuilder.Entity<KaTransfer>()
                .Property(e => e.AustrittBem)
                .IsUnicode(false);

            modelBuilder.Entity<KaTransfer>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaTransfer>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaTransfer>()
                .Property(e => e.KaTransferTS)
                .IsFixedLength();

            modelBuilder.Entity<KaTransferZielvereinb>()
                .Property(e => e.Feinziel)
                .IsUnicode(false);

            modelBuilder.Entity<KaTransferZielvereinb>()
                .Property(e => e.ErreichenBis)
                .IsUnicode(false);

            modelBuilder.Entity<KaTransferZielvereinb>()
                .Property(e => e.ProzessAuftrag)
                .IsUnicode(false);

            modelBuilder.Entity<KaTransferZielvereinb>()
                .Property(e => e.Ergebnis)
                .IsUnicode(false);

            modelBuilder.Entity<KaTransferZielvereinb>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaTransferZielvereinb>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaTransferZielvereinb>()
                .Property(e => e.KaTransferZielvereinbTS)
                .IsFixedLength();

            modelBuilder.Entity<KaVerlauf>()
                .Property(e => e.Kontaktperson)
                .IsUnicode(false);

            modelBuilder.Entity<KaVerlauf>()
                .Property(e => e.Stichwort)
                .IsUnicode(false);

            modelBuilder.Entity<KaVerlauf>()
                .Property(e => e.KaAllgemThemaCodes)
                .IsUnicode(false);

            modelBuilder.Entity<KaVerlauf>()
                .Property(e => e.InhaltRTF)
                .IsUnicode(false);

            modelBuilder.Entity<KaVerlauf>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaVerlauf>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaVerlauf>()
                .Property(e => e.KaVerlaufTS)
                .IsFixedLength();

            modelBuilder.Entity<KaVermittlungBIBIP>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungBIBIP>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungBIBIP>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungBIBIP>()
                .Property(e => e.KaVermittlungBIBIPTS)
                .IsFixedLength();

            modelBuilder.Entity<KaVermittlungEinsatz>()
                .Property(e => e.ArbeitspensumErgaenzungen)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungEinsatz>()
                .Property(e => e.BIEAZBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungEinsatz>()
                .Property(e => e.BIBruttolohn)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KaVermittlungEinsatz>()
                .Property(e => e.BIBeteilungEAZ)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KaVermittlungEinsatz>()
                .Property(e => e.InizioAbschlussGrund)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungEinsatz>()
                .Property(e => e.InizioLoesung)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungEinsatz>()
                .Property(e => e.EinsatzBemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungEinsatz>()
                .Property(e => e.KaVermittlungEinsatzTS)
                .IsFixedLength();

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.AktuelleTaetigkeit)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.ArbeitsgebietBemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.ArbeitszeitenCodes)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.BesondereFaehigkeiten)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.BesondereWuensche)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.BrancheCodes)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.EinsatzbereichCodes)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.GesundheitBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.GesundheitEinschraenkungen)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.KaBetriebCodes)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.UnterstuetzungInizioCodes)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.EinschraenkungMO)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.EinschraenkungDI)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.EinschraenkungMI)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.EinschraenkungDO)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.EinschraenkungFR)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.EinschraenkungSA)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.EinschraenkungSO)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.VermittelbarkeitBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungProfil>()
                .Property(e => e.KaVermittlungProfilTS)
                .IsFixedLength();

            modelBuilder.Entity<KaVermittlungSI>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungSI>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungSI>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungSI>()
                .Property(e => e.KaVermittlungSITS)
                .IsFixedLength();

            modelBuilder.Entity<KaVermittlungSIZwischenbericht>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungSIZwischenbericht>()
                .Property(e => e.KaVermittlungSIZwischenberichtTS)
                .IsFixedLength();

            modelBuilder.Entity<KaVermittlungVorschlag>()
                .Property(e => e.VorschlagBemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<KaVermittlungVorschlag>()
                .Property(e => e.KaVermittlungVorschlagTS)
                .IsFixedLength();

            modelBuilder.Entity<KaZuteilFachbereich>()
                .Property(e => e.KaZuteilFachbereichTS)
                .IsFixedLength();

            modelBuilder.Entity<KbBelegKrei>()
                .Property(e => e.KontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<KbBelegKrei>()
                .Property(e => e.KbBelegKreisTS)
                .IsFixedLength();

            modelBuilder.Entity<KbBelegKrei>()
                .HasMany(e => e.KbFreieBelegNummers)
                .WithRequired(e => e.KbBelegKrei)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.Extern)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.ReferenzNummer)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.AggregateInfo)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.FibuFehlermeldung)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.KbBuchungTS)
                .IsFixedLength();

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.SollKtoNr)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.HabenKtoNr)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.PCKontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.BankKontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.IBAN)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.BankBCN)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.BankName)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.BankStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.BankPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.BankOrt)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.Zahlungsgrund)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.MitteilungZeile1)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.MitteilungZeile2)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.MitteilungZeile3)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.MitteilungZeile4)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.BeguenstigtName)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.BeguenstigtName2)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.BeguenstigtStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.BeguenstigtHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.BeguenstigtPostfach)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.BeguenstigtPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .Property(e => e.BeguenstigtOrt)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchung>()
                .HasMany(e => e.IkBetreibungAusgleiches)
                .WithRequired(e => e.KbBuchung)
                .HasForeignKey(e => e.AusgleichBuchungID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbBuchung>()
                .HasMany(e => e.KbBuchung1)
                .WithOptional(e => e.KbBuchung2)
                .HasForeignKey(e => e.NeubuchungVonKbBuchungID);

            modelBuilder.Entity<KbBuchung>()
                .HasMany(e => e.KbBuchung11)
                .WithOptional(e => e.KbBuchung3)
                .HasForeignKey(e => e.StorniertKbBuchungID);

            modelBuilder.Entity<KbBuchung>()
                .HasMany(e => e.KbForderungAuszahlungs)
                .WithRequired(e => e.KbBuchung)
                .HasForeignKey(e => e.KbBuchungID_Auszahlung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbBuchung>()
                .HasMany(e => e.KbForderungAuszahlungs1)
                .WithRequired(e => e.KbBuchung1)
                .HasForeignKey(e => e.KbBuchungID_Forderung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbBuchung>()
                .HasMany(e => e.KbOpAusgleiches)
                .WithRequired(e => e.KbBuchung)
                .HasForeignKey(e => e.OpBuchungID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbBuchung>()
                .HasMany(e => e.KbOpAusgleiches1)
                .WithRequired(e => e.KbBuchung1)
                .HasForeignKey(e => e.AusgleichBuchungID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbBuchung>()
                .HasMany(e => e.KbTransfers)
                .WithRequired(e => e.KbBuchung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbBuchungKostenart>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KbBuchungKostenart>()
                .Property(e => e.KbBuchungKostenartTS)
                .IsFixedLength();

            modelBuilder.Entity<KbBuchungKostenart>()
                .Property(e => e.KontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchungKostenart>()
                .Property(e => e.Buchungstext)
                .IsUnicode(false);

            modelBuilder.Entity<KbBuchungKostenart>()
                .HasMany(e => e.KbWVEinzelpostens)
                .WithRequired(e => e.KbBuchungKostenart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbBuchungKostenart>()
                .HasMany(e => e.KbWVEinzelpostenFehlers)
                .WithRequired(e => e.KbBuchungKostenart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbForderungAuszahlung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KbForderungAuszahlung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KbForderungAuszahlung>()
                .Property(e => e.KbForderungAuszahlungTS)
                .IsFixedLength();

            modelBuilder.Entity<KbFreieBelegNummer>()
                .Property(e => e.KbFreieBelegNummerTS)
                .IsFixedLength();

            modelBuilder.Entity<KbKonto>()
                .Property(e => e.KbKontoartCodes)
                .IsUnicode(false);

            modelBuilder.Entity<KbKonto>()
                .Property(e => e.KontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<KbKonto>()
                .Property(e => e.KontoName)
                .IsUnicode(false);

            modelBuilder.Entity<KbKonto>()
                .Property(e => e.Vorsaldo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KbKonto>()
                .Property(e => e.SaldoGruppeName)
                .IsUnicode(false);

            modelBuilder.Entity<KbKonto>()
                .Property(e => e.KbKontoTS)
                .IsFixedLength();

            modelBuilder.Entity<KbKonto>()
                .HasMany(e => e.KbKonto1)
                .WithOptional(e => e.KbKonto2)
                .HasForeignKey(e => e.GruppeKontoID);

            modelBuilder.Entity<KbKostenstelle>()
                .Property(e => e.Nr)
                .IsUnicode(false);

            modelBuilder.Entity<KbKostenstelle>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<KbKostenstelle>()
                .Property(e => e.Vorsaldo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KbKostenstelle>()
                .Property(e => e.KbKostenstelleTS)
                .IsFixedLength();

            modelBuilder.Entity<KbKostenstelle>()
                .HasMany(e => e.BgFinanzplan_BaPerson)
                .WithOptional(e => e.KbKostenstelle)
                .HasForeignKey(e => e.KbKostenstelleID);

            modelBuilder.Entity<KbKostenstelle>()
                .HasMany(e => e.BgFinanzplan_BaPerson1)
                .WithOptional(e => e.KbKostenstelle1)
                .HasForeignKey(e => e.KbKostenstelleID_KVG);

            modelBuilder.Entity<KbKostenstelle>()
                .HasMany(e => e.KbBuchungKostenarts)
                .WithRequired(e => e.KbKostenstelle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbKostenstelle>()
                .HasMany(e => e.KbWVEinzelpostens)
                .WithRequired(e => e.KbKostenstelle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbKostenstelle_BaPerson>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KbKostenstelle_BaPerson>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KbKostenstelle_BaPerson>()
                .Property(e => e.KbKostenstelle_BaPersonTS)
                .IsFixedLength();

            modelBuilder.Entity<KbMandant>()
                .Property(e => e.Mandant)
                .IsUnicode(false);

            modelBuilder.Entity<KbMandant>()
                .Property(e => e.KbMandantTS)
                .IsFixedLength();

            modelBuilder.Entity<KbMandant>()
                .HasMany(e => e.KbPeriodes)
                .WithRequired(e => e.KbMandant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbOpAusgleich>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KbOpAusgleich>()
                .Property(e => e.KbOpAusgleichTS)
                .IsFixedLength();

            modelBuilder.Entity<KbPeriode>()
                .Property(e => e.KbPeriodeTS)
                .IsFixedLength();

            modelBuilder.Entity<KbPeriode>()
                .HasMany(e => e.KbBelegKreis)
                .WithRequired(e => e.KbPeriode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbPeriode>()
                .HasMany(e => e.KbBuchungs)
                .WithRequired(e => e.KbPeriode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbPeriode>()
                .HasMany(e => e.KbWVLaufs)
                .WithRequired(e => e.KbPeriode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbPeriode_User>()
                .Property(e => e.KbPeriode_UserTS)
                .IsFixedLength();

            modelBuilder.Entity<KbTransfer>()
                .Property(e => e.KbTransferTS)
                .IsFixedLength();

            modelBuilder.Entity<KbWVEinzelposten>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KbWVEinzelposten>()
                .Property(e => e.Buchungstext)
                .IsUnicode(false);

            modelBuilder.Entity<KbWVEinzelposten>()
                .Property(e => e.HeimatkantonNr)
                .IsUnicode(false);

            modelBuilder.Entity<KbWVEinzelposten>()
                .Property(e => e.WohnKantonNr)
                .IsUnicode(false);

            modelBuilder.Entity<KbWVEinzelposten>()
                .Property(e => e.KantonKuerzel)
                .IsUnicode(false);

            modelBuilder.Entity<KbWVEinzelposten>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<KbWVEinzelposten>()
                .Property(e => e.KbWVEinzelpositionTS)
                .IsFixedLength();

            modelBuilder.Entity<KbWVEinzelposten>()
                .HasMany(e => e.KbWVEinzelposten1)
                .WithOptional(e => e.KbWVEinzelposten2)
                .HasForeignKey(e => e.StorniertKbWVEinzelpostenID);

            modelBuilder.Entity<KbWVEinzelpostenFehler>()
                .Property(e => e.WVFehlermeldung)
                .IsUnicode(false);

            modelBuilder.Entity<KbWVEinzelpostenFehler>()
                .Property(e => e.KbWVEinzelpostenFehlerTS)
                .IsFixedLength();

            modelBuilder.Entity<KbWVLauf>()
                .Property(e => e.KbWVLaufTS)
                .IsFixedLength();

            modelBuilder.Entity<KbWVLauf>()
                .HasMany(e => e.KbWVEinzelpostens)
                .WithRequired(e => e.KbWVLauf)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbWVLauf>()
                .HasMany(e => e.KbWVEinzelpostenFehlers)
                .WithRequired(e => e.KbWVLauf)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbZahlungseingang>()
                .Property(e => e.Debitor)
                .IsUnicode(false);

            modelBuilder.Entity<KbZahlungseingang>()
                .Property(e => e.KontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<KbZahlungseingang>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KbZahlungseingang>()
                .Property(e => e.Mitteilung1)
                .IsUnicode(false);

            modelBuilder.Entity<KbZahlungseingang>()
                .Property(e => e.Mitteilung2)
                .IsUnicode(false);

            modelBuilder.Entity<KbZahlungseingang>()
                .Property(e => e.Mitteilung3)
                .IsUnicode(false);

            modelBuilder.Entity<KbZahlungseingang>()
                .Property(e => e.Mitteilung4)
                .IsUnicode(false);

            modelBuilder.Entity<KbZahlungseingang>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KbZahlungseingang>()
                .Property(e => e.KbZahlungseingangTS)
                .IsFixedLength();

            modelBuilder.Entity<KbZahlungskonto>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<KbZahlungskonto>()
                .Property(e => e.VertragNr)
                .IsUnicode(false);

            modelBuilder.Entity<KbZahlungskonto>()
                .Property(e => e.KontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<KbZahlungskonto>()
                .Property(e => e.KbDTAZugangTS)
                .IsFixedLength();

            modelBuilder.Entity<KbZahlungskonto>()
                .HasMany(e => e.KbZahlungslaufs)
                .WithRequired(e => e.KbZahlungskonto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbZahlungskonto_XOrgUnit>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KbZahlungskonto_XOrgUnit>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KbZahlungskonto_XOrgUnit>()
                .Property(e => e.KbZahlungskonto_XOrgUnitTS)
                .IsFixedLength();

            modelBuilder.Entity<KbZahlungslauf>()
                .Property(e => e.PaymentMessageID)
                .IsUnicode(false);

            modelBuilder.Entity<KbZahlungslauf>()
                .Property(e => e.FilePath)
                .IsUnicode(false);

            modelBuilder.Entity<KbZahlungslauf>()
                .Property(e => e.TotalBetrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KbZahlungslauf>()
                .Property(e => e.Zahlungsdaten)
                .IsUnicode(false);

            modelBuilder.Entity<KbZahlungslauf>()
                .Property(e => e.KbZahlungslaufTS)
                .IsFixedLength();

            modelBuilder.Entity<KbZahlungslauf>()
                .HasMany(e => e.KbTransfers)
                .WithRequired(e => e.KbZahlungslauf)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KbZahlungslaufValuta>()
                .Property(e => e.KbZahlungslaufValutaTS)
                .IsFixedLength();

            modelBuilder.Entity<KesArtikel>()
                .Property(e => e.CodeKokes)
                .IsUnicode(false);

            modelBuilder.Entity<KesArtikel>()
                .Property(e => e.Artikel)
                .IsUnicode(false);

            modelBuilder.Entity<KesArtikel>()
                .Property(e => e.Absatz)
                .IsUnicode(false);

            modelBuilder.Entity<KesArtikel>()
                .Property(e => e.Ziffer)
                .IsUnicode(false);

            modelBuilder.Entity<KesArtikel>()
                .Property(e => e.Gesetz)
                .IsUnicode(false);

            modelBuilder.Entity<KesArtikel>()
                .Property(e => e.Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<KesArtikel>()
                .Property(e => e.BezeichnungKurz)
                .IsUnicode(false);

            modelBuilder.Entity<KesArtikel>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KesArtikel>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KesArtikel>()
                .Property(e => e.KesArtikelTS)
                .IsFixedLength();

            modelBuilder.Entity<KesArtikel>()
                .HasMany(e => e.KesMassnahme_KesArtikel)
                .WithRequired(e => e.KesArtikel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KesArtikel>()
                .HasMany(e => e.KesMassnahmeBSSes)
                .WithOptional(e => e.KesArtikel)
                .HasForeignKey(e => e.KesArtikelID_MassnahmegebundeneGeschaefte);

            modelBuilder.Entity<KesArtikel>()
                .HasMany(e => e.KesMassnahmeBSSes1)
                .WithOptional(e => e.KesArtikel1)
                .HasForeignKey(e => e.KesArtikelID_NichtMassnahmegebundeneGeschaefte);

            modelBuilder.Entity<KesAuftrag>()
                .Property(e => e.Anlass)
                .IsUnicode(false);

            modelBuilder.Entity<KesAuftrag>()
                .Property(e => e.Auftrag)
                .IsUnicode(false);

            modelBuilder.Entity<KesAuftrag>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KesAuftrag>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KesAuftrag>()
                .Property(e => e.KesAuftragTS)
                .IsFixedLength();

            modelBuilder.Entity<KesAuftrag>()
                .HasMany(e => e.KesAuftrag_BaPerson)
                .WithRequired(e => e.KesAuftrag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KesAuftrag_BaPerson>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KesAuftrag_BaPerson>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KesAuftrag_BaPerson>()
                .Property(e => e.KesAuftrag_BaPersonTS)
                .IsFixedLength();

            modelBuilder.Entity<KesBehoerde>()
                .Property(e => e.KESBID)
                .IsUnicode(false);

            modelBuilder.Entity<KesBehoerde>()
                .Property(e => e.Kanton)
                .IsUnicode(false);

            modelBuilder.Entity<KesBehoerde>()
                .Property(e => e.KESBName)
                .IsUnicode(false);

            modelBuilder.Entity<KesBehoerde>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KesBehoerde>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KesBehoerde>()
                .Property(e => e.KesBehoerdeTS)
                .IsFixedLength();

            modelBuilder.Entity<KesBehoerde>()
                .HasMany(e => e.KesMassnahmes)
                .WithOptional(e => e.KesBehoerde)
                .HasForeignKey(e => e.UebernahmeVon_KesBehoerdeID);

            modelBuilder.Entity<KesBehoerde>()
                .HasMany(e => e.KesMassnahmes1)
                .WithOptional(e => e.KesBehoerde1)
                .HasForeignKey(e => e.UebertragungAn_KesBehoerdeID);

            modelBuilder.Entity<KesBehoerde>()
                .HasMany(e => e.KesMassnahmes2)
                .WithOptional(e => e.KesBehoerde2)
                .HasForeignKey(e => e.Zustaendig_KesBehoerdeID);

            modelBuilder.Entity<KesDokument>()
                .Property(e => e.Stichwort)
                .IsUnicode(false);

            modelBuilder.Entity<KesDokument>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KesDokument>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KesDokument>()
                .Property(e => e.KesDokumentTS)
                .IsFixedLength();

            modelBuilder.Entity<KesMandatsfuehrendePerson>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KesMandatsfuehrendePerson>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KesMandatsfuehrendePerson>()
                .Property(e => e.KesMandatsfuehrendePersonTS)
                .IsFixedLength();

            modelBuilder.Entity<KesMassnahme>()
                .Property(e => e.KesAufgabenbereichCodes)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahme>()
                .Property(e => e.KesIndikationCodes)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahme>()
                .Property(e => e.Auftragstext)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahme>()
                .Property(e => e.UebernahmeVon_PLZ)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahme>()
                .Property(e => e.UebernahmeVon_Ort)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahme>()
                .Property(e => e.UebernahmeVon_Kanton)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahme>()
                .Property(e => e.UebertragungAn_PLZ)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahme>()
                .Property(e => e.UebertragungAn_Ort)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahme>()
                .Property(e => e.UebertragungAn_Kanton)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahme>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahme>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahme>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahme>()
                .Property(e => e.KesMassnahmeTS)
                .IsFixedLength();

            modelBuilder.Entity<KesMassnahme>()
                .HasMany(e => e.KesMandatsfuehrendePersons)
                .WithRequired(e => e.KesMassnahme)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KesMassnahme>()
                .HasMany(e => e.KesMassnahme_KesArtikel)
                .WithRequired(e => e.KesMassnahme)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KesMassnahme>()
                .HasMany(e => e.KesMassnahmeAuftrags)
                .WithRequired(e => e.KesMassnahme)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KesMassnahme>()
                .HasMany(e => e.KesMassnahmeBerichts)
                .WithRequired(e => e.KesMassnahme)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KesMassnahme_KesArtikel>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahme_KesArtikel>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahme_KesArtikel>()
                .Property(e => e.KesMassnahme_KesArtikelTS)
                .IsFixedLength();

            modelBuilder.Entity<KesMassnahmeAuftrag>()
                .Property(e => e.Auftrag)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahmeAuftrag>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahmeAuftrag>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahmeAuftrag>()
                .Property(e => e.KesMassnahmeAuftragTS)
                .IsFixedLength();

            modelBuilder.Entity<KesMassnahmeBericht>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahmeBericht>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahmeBericht>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahmeBericht>()
                .Property(e => e.KesMassnahmeBerichtTS)
                .IsFixedLength();

            modelBuilder.Entity<KesMassnahmeBSS>()
                .Property(e => e.KesAufgabenbereichCodes)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahmeBSS>()
                .Property(e => e.KesIndikationCodes)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahmeBSS>()
                .Property(e => e.PLZ)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahmeBSS>()
                .Property(e => e.Ort)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahmeBSS>()
                .Property(e => e.Kanton)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahmeBSS>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahmeBSS>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahmeBSS>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KesMassnahmeBSS>()
                .Property(e => e.KesMassnahmeBSSTS)
                .IsFixedLength();

            modelBuilder.Entity<KesPflegekinderaufsicht>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KesPflegekinderaufsicht>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KesPflegekinderaufsicht>()
                .Property(e => e.KesPflegekinderaufsichtTS)
                .IsFixedLength();

            modelBuilder.Entity<KesPraevention>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<KesPraevention>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KesPraevention>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KesPraevention>()
                .Property(e => e.KesPraeventionTS)
                .IsFixedLength();

            modelBuilder.Entity<KesVerlauf>()
                .Property(e => e.Stichwort)
                .IsUnicode(false);

            modelBuilder.Entity<KesVerlauf>()
                .Property(e => e.Inhalt)
                .IsUnicode(false);

            modelBuilder.Entity<KesVerlauf>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<KesVerlauf>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<KesVerlauf>()
                .Property(e => e.KesVerlaufTS)
                .IsFixedLength();

            modelBuilder.Entity<MigAssignment>()
                .Property(e => e.Lookup)
                .IsUnicode(false);

            modelBuilder.Entity<MigAssignment>()
                .Property(e => e.OldValue)
                .IsUnicode(false);

            modelBuilder.Entity<MigAssignment>()
                .Property(e => e.NewValue)
                .IsUnicode(false);

            modelBuilder.Entity<MigAssignment>()
                .Property(e => e.MigAssignmentTS)
                .IsFixedLength();

            modelBuilder.Entity<MigLog>()
                .Property(e => e.Function)
                .IsUnicode(false);

            modelBuilder.Entity<MigLog>()
                .Property(e => e.Table)
                .IsUnicode(false);

            modelBuilder.Entity<MigLog>()
                .Property(e => e.Column)
                .IsUnicode(false);

            modelBuilder.Entity<MigLog>()
                .Property(e => e.Time)
                .IsUnicode(false);

            modelBuilder.Entity<MigLog>()
                .Property(e => e.Prms)
                .IsUnicode(false);

            modelBuilder.Entity<MigLog>()
                .Property(e => e.Error)
                .IsUnicode(false);

            modelBuilder.Entity<MigLog>()
                .Property(e => e.MigLogTS)
                .IsFixedLength();

            modelBuilder.Entity<MigLookup>()
                .Property(e => e.Lookup)
                .IsUnicode(false);

            modelBuilder.Entity<MigLookup>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<MigLookup>()
                .Property(e => e.MigLookupTS)
                .IsFixedLength();

            modelBuilder.Entity<NewodPerson>()
                .Property(e => e.Vorname)
                .IsUnicode(false);

            modelBuilder.Entity<NewodPerson>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<NewodPerson>()
                .Property(e => e.AHVNummer)
                .IsUnicode(false);

            modelBuilder.Entity<NewodPerson>()
                .Property(e => e.Versichertennummer)
                .IsUnicode(false);

            modelBuilder.Entity<NewodPerson>()
                .Property(e => e.GeburtsdatumString)
                .IsUnicode(false);

            modelBuilder.Entity<NewodPerson>()
                .Property(e => e.Strasse)
                .IsUnicode(false);

            modelBuilder.Entity<NewodPerson>()
                .Property(e => e.HausNr)
                .IsUnicode(false);

            modelBuilder.Entity<NewodPerson>()
                .Property(e => e.HausNrZusatz)
                .IsUnicode(false);

            modelBuilder.Entity<NewodPerson>()
                .Property(e => e.PLZ)
                .IsUnicode(false);

            modelBuilder.Entity<NewodPerson>()
                .Property(e => e.Ort)
                .IsUnicode(false);

            modelBuilder.Entity<ShEinzelzahlung>()
                .Property(e => e.NameEinzelzahlung)
                .IsUnicode(false);

            modelBuilder.Entity<ShEinzelzahlung>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ShEinzelzahlung>()
                .Property(e => e.BetragAnfrage)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ShEinzelzahlung>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<ShEinzelzahlung>()
                .Property(e => e.ShEinzelzahlungTS)
                .IsFixedLength();

            modelBuilder.Entity<SstASVSExport>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<SstASVSExport>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<SstASVSExport>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<SstASVSExport>()
                .Property(e => e.Modified)
                .IsUnicode(false);

            modelBuilder.Entity<SstASVSExport>()
                .Property(e => e.SstASVSExportTS)
                .IsFixedLength();

            modelBuilder.Entity<SstASVSExport>()
                .HasMany(e => e.SstASVSExport_Eintrag)
                .WithRequired(e => e.SstASVSExport)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SstASVSExport_Eintrag>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<SstASVSExport_Eintrag>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<SstASVSExport_Eintrag>()
                .Property(e => e.Modified)
                .IsUnicode(false);

            modelBuilder.Entity<SstASVSExport_Eintrag>()
                .Property(e => e.SstASVSExport_EintragTS)
                .IsFixedLength();

            modelBuilder.Entity<SstNewodMutation>()
                .Property(e => e.Data)
                .IsUnicode(false);

            modelBuilder.Entity<SstNewodMutation>()
                .Property(e => e.Mutationsart)
                .IsUnicode(false);

            modelBuilder.Entity<VmAHVMindestbeitrag>()
                .Property(e => e.BeitragsRechnungsJahr)
                .IsUnicode(false);

            modelBuilder.Entity<VmAHVMindestbeitrag>()
                .Property(e => e.Bruttolohn)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VmAHVMindestbeitrag>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<VmAHVMindestbeitrag>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmAHVMindestbeitrag>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmAHVMindestbeitrag>()
                .Property(e => e.VmAHVMindestbeitragTS)
                .IsFixedLength();

            modelBuilder.Entity<VmAntragEKSK>()
                .Property(e => e.Antrag)
                .IsUnicode(false);

            modelBuilder.Entity<VmAntragEKSK>()
                .Property(e => e.Begruendung)
                .IsUnicode(false);

            modelBuilder.Entity<VmAntragEKSK>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<VmAntragEKSK>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmAntragEKSK>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmAntragEKSK>()
                .Property(e => e.VmAntragEKSKTS)
                .IsFixedLength();

            modelBuilder.Entity<VmBericht>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<VmBericht>()
                .Property(e => e.VmBerichtTS)
                .IsFixedLength();

            modelBuilder.Entity<VmBericht>()
                .Property(e => e.Entschaedigung)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VmBeschwerdeAnfrage>()
                .Property(e => e.Absender)
                .IsUnicode(false);

            modelBuilder.Entity<VmBeschwerdeAnfrage>()
                .Property(e => e.Stichworte)
                .IsUnicode(false);

            modelBuilder.Entity<VmBeschwerdeAnfrage>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmBeschwerdeAnfrage>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmBeschwerdeAnfrage>()
                .Property(e => e.VmBeschwerdeAnfrageTS)
                .IsFixedLength();

            modelBuilder.Entity<VmBewertung>()
                .Property(e => e.VmKriterienCodes)
                .IsUnicode(false);

            modelBuilder.Entity<VmBewertung>()
                .Property(e => e.VmKriterienListe)
                .IsUnicode(false);

            modelBuilder.Entity<VmBewertung>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<VmBewertung>()
                .Property(e => e.VmBewertungTS)
                .IsFixedLength();

            modelBuilder.Entity<VmBudget>()
                .Property(e => e.Stichworte)
                .IsUnicode(false);

            modelBuilder.Entity<VmBudget>()
                .Property(e => e.Grund)
                .IsUnicode(false);

            modelBuilder.Entity<VmBudget>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmBudget>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmBudget>()
                .Property(e => e.VmBudgetTS)
                .IsFixedLength();

            modelBuilder.Entity<VmELKrankheitskosten>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VmELKrankheitskosten>()
                .Property(e => e.VerfuegungLeistung)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VmELKrankheitskosten>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<VmELKrankheitskosten>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmELKrankheitskosten>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmELKrankheitskosten>()
                .Property(e => e.VmELKrankheitskostenTS)
                .IsFixedLength();

            modelBuilder.Entity<VmELKrankheitskosten>()
                .HasOptional(e => e.VmELKrankheitskosten1)
                .WithRequired(e => e.VmELKrankheitskosten2);

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.Geburtsdatum)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.Anrede)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.FamilienNamen)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.Vornamen)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.Zusatz)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.Strasse)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.Ort)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.Land)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.Ergaenzung)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.KontaktAdresse)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.TestamentEroeffnungStatus)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.TestamentEroeffnungVersandart)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.ErbCodierung)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.VmErbeTS)
                .IsFixedLength();

            modelBuilder.Entity<VmErbe>()
                .Property(e => e.Titel2)
                .IsUnicode(false);

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.TodesDatumText)
                .IsUnicode(false);

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.TodesOrt)
                .IsUnicode(false);

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.AHVNummer)
                .IsUnicode(false);

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.Anrede)
                .IsUnicode(false);

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.FamilienNamen)
                .IsUnicode(false);

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.LedigName)
                .IsUnicode(false);

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.Vornamen)
                .IsUnicode(false);

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.Elternnamen)
                .IsUnicode(false);

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.Zivilstand)
                .IsUnicode(false);

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.Geburtsdatum)
                .IsUnicode(false);

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.Heimatorte)
                .IsUnicode(false);

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.Strasse)
                .IsUnicode(false);

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.Ort)
                .IsUnicode(false);

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.Aufenthalt)
                .IsUnicode(false);

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.VmErblasserTS)
                .IsFixedLength();

            modelBuilder.Entity<VmErblasser>()
                .Property(e => e.Versichertennummer)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbschaftsdienst>()
                .Property(e => e.MassnahmenCodes)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbschaftsdienst>()
                .Property(e => e.KopieAnCodes)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbschaftsdienst>()
                .Property(e => e.Massnahme)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbschaftsdienst>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<VmErbschaftsdienst>()
                .Property(e => e.VmErbschaftsdienstTS)
                .IsFixedLength();

            modelBuilder.Entity<VmErnennung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmErnennung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmErnennung>()
                .Property(e => e.VmErnennungTS)
                .IsFixedLength();

            modelBuilder.Entity<VmGefaehrdungsMeldung>()
                .Property(e => e.VmGefaehrdungNSBCodes)
                .IsUnicode(false);

            modelBuilder.Entity<VmGefaehrdungsMeldung>()
                .Property(e => e.FaThemaCodes)
                .IsUnicode(false);

            modelBuilder.Entity<VmGefaehrdungsMeldung>()
                .Property(e => e.Ausgangslage)
                .IsUnicode(false);

            modelBuilder.Entity<VmGefaehrdungsMeldung>()
                .Property(e => e.Auflagen)
                .IsUnicode(false);

            modelBuilder.Entity<VmGefaehrdungsMeldung>()
                .Property(e => e.Ueberpruefung)
                .IsUnicode(false);

            modelBuilder.Entity<VmGefaehrdungsMeldung>()
                .Property(e => e.Konsequenzen)
                .IsUnicode(false);

            modelBuilder.Entity<VmGefaehrdungsMeldung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmGefaehrdungsMeldung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmGefaehrdungsMeldung>()
                .Property(e => e.VmGefaehrdungsMeldungTS)
                .IsFixedLength();

            modelBuilder.Entity<VmInventar>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<VmInventar>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmInventar>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmInventar>()
                .Property(e => e.VmInventarTS)
                .IsFixedLength();

            modelBuilder.Entity<VmKlientenbudget>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmKlientenbudget>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmKlientenbudget>()
                .Property(e => e.VmKlientenbudgetTS)
                .IsFixedLength();

            modelBuilder.Entity<VmKlientenbudget>()
                .HasMany(e => e.VmPositions)
                .WithRequired(e => e.VmKlientenbudget)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VmMandant>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandant>()
                .Property(e => e.Vorname)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandant>()
                .Property(e => e.Beruf)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandant>()
                .Property(e => e.WertschriftenDepot)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandant>()
                .Property(e => e.AHVNummer)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandant>()
                .Property(e => e.Versichertennummer)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandant>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandant>()
                .Property(e => e.VmMandantTS)
                .IsFixedLength();

            modelBuilder.Entity<VmMandant>()
                .HasMany(e => e.BaAdresses)
                .WithOptional(e => e.VmMandant)
                .WillCascadeOnDelete();

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.GrundMassnahmeText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.AuftragZielsetzungText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.Begruendung)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.NeueZieleText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.WohnenText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.GesundheitText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.VerhaltenText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.TaetigkeitText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.FamSituationText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.SozialeKompetenzenText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.FreizeitText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.BesondereRessourcenText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.HandlungenText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.BesondereSchwierigkeitenText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.KlientText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.DritteText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.InstitutionenText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.BelastungMandatText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.BelastungAdminText)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.VmEinnahmenAngabenCodes)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.VmBerichtVersicherungenCodes)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.VmBerichtBesondereAngabenCodes)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.EinnahmenBemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.VersicherungenBemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.BesondereAngabenBemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.PassationBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.AntragBegruendung)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmMandBericht>()
                .Property(e => e.VmMandBerichtTS)
                .IsFixedLength();

            modelBuilder.Entity<VmMassnahme>()
                .Property(e => e.ZGBCodes)
                .IsUnicode(false);

            modelBuilder.Entity<VmMassnahme>()
                .Property(e => e.WeitereZGB)
                .IsUnicode(false);

            modelBuilder.Entity<VmMassnahme>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<VmMassnahme>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmMassnahme>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmMassnahme>()
                .Property(e => e.VmMassnahmeTS)
                .IsFixedLength();

            modelBuilder.Entity<VmMassnahme>()
                .HasMany(e => e.VmErnennungs)
                .WithRequired(e => e.VmMassnahme)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VmPosition>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<VmPosition>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<VmPosition>()
                .Property(e => e.Saldo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VmPosition>()
                .Property(e => e.BetragMonatlich)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VmPosition>()
                .Property(e => e.BetragJaehrlich)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VmPosition>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmPosition>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmPosition>()
                .Property(e => e.VmPositionTS)
                .IsFixedLength();

            modelBuilder.Entity<VmPositionsart>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<VmPositionsart>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmPositionsart>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmPositionsart>()
                .Property(e => e.VmPositionsartTS)
                .IsFixedLength();

            modelBuilder.Entity<VmPositionsart>()
                .HasMany(e => e.VmPositions)
                .WithRequired(e => e.VmPositionsart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VmPriMa>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<VmPriMa>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<VmPriMa>()
                .Property(e => e.Vorname)
                .IsUnicode(false);

            modelBuilder.Entity<VmPriMa>()
                .Property(e => e.Telefon_P)
                .IsUnicode(false);

            modelBuilder.Entity<VmPriMa>()
                .Property(e => e.Telefon_G)
                .IsUnicode(false);

            modelBuilder.Entity<VmPriMa>()
                .Property(e => e.MobilTel)
                .IsUnicode(false);

            modelBuilder.Entity<VmPriMa>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<VmPriMa>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<VmPriMa>()
                .Property(e => e.Beruf)
                .IsUnicode(false);

            modelBuilder.Entity<VmPriMa>()
                .Property(e => e.BankName)
                .IsUnicode(false);

            modelBuilder.Entity<VmPriMa>()
                .Property(e => e.BankKontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<VmPriMa>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<VmPriMa>()
                .Property(e => e.VmPriMaTS)
                .IsFixedLength();

            modelBuilder.Entity<VmPriMa>()
                .Property(e => e.AHVNummer)
                .IsUnicode(false);

            modelBuilder.Entity<VmPriMa>()
                .Property(e => e.Versichertennummer)
                .IsUnicode(false);

            modelBuilder.Entity<VmPriMa>()
                .HasMany(e => e.BaAdresses)
                .WithOptional(e => e.VmPriMa)
                .WillCascadeOnDelete();

            modelBuilder.Entity<VmPriMa>()
                .HasMany(e => e.FaDokumentes)
                .WithOptional(e => e.VmPriMa)
                .HasForeignKey(e => e.VmPriMaID_Adressat);

            modelBuilder.Entity<VmPriMa>()
                .HasMany(e => e.VmSozialversicherungs)
                .WithOptional(e => e.VmPriMa)
                .HasForeignKey(e => e.VmPriMaID_Adressat);

            modelBuilder.Entity<VmSachversicherung>()
                .Property(e => e.Policenummer)
                .IsUnicode(false);

            modelBuilder.Entity<VmSachversicherung>()
                .Property(e => e.Selbstbehalt)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VmSachversicherung>()
                .Property(e => e.Grundpraemie)
                .IsUnicode(false);

            modelBuilder.Entity<VmSachversicherung>()
                .Property(e => e.Person)
                .IsUnicode(false);

            modelBuilder.Entity<VmSachversicherung>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<VmSachversicherung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmSachversicherung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmSachversicherung>()
                .Property(e => e.VmSachversicherungTS)
                .IsFixedLength();

            modelBuilder.Entity<VmSchulden>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VmSchulden>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<VmSchulden>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmSchulden>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmSchulden>()
                .Property(e => e.VmSchuldenTS)
                .IsFixedLength();

            modelBuilder.Entity<VmSiegelung>()
                .Property(e => e.KopieAndere)
                .IsUnicode(false);

            modelBuilder.Entity<VmSiegelung>()
                .Property(e => e.PliQuittung)
                .IsUnicode(false);

            modelBuilder.Entity<VmSiegelung>()
                .Property(e => e.MassaVerwalter)
                .IsUnicode(false);

            modelBuilder.Entity<VmSiegelung>()
                .Property(e => e.RechnungsNr)
                .IsUnicode(false);

            modelBuilder.Entity<VmSiegelung>()
                .Property(e => e.RechnungsBetrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VmSiegelung>()
                .Property(e => e.RechnungAn)
                .IsUnicode(false);

            modelBuilder.Entity<VmSiegelung>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<VmSiegelung>()
                .Property(e => e.VmSiegelungTS)
                .IsFixedLength();

            modelBuilder.Entity<VmSituationsBericht>()
                .Property(e => e.FaThemaCodes)
                .IsUnicode(false);

            modelBuilder.Entity<VmSituationsBericht>()
                .Property(e => e.BerichtFinanzen)
                .IsUnicode(false);

            modelBuilder.Entity<VmSituationsBericht>()
                .Property(e => e.ZielPrognose)
                .IsUnicode(false);

            modelBuilder.Entity<VmSituationsBericht>()
                .Property(e => e.AntragText)
                .IsUnicode(false);

            modelBuilder.Entity<VmSituationsBericht>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmSituationsBericht>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmSituationsBericht>()
                .Property(e => e.VmSituationsBerichtTS)
                .IsFixedLength();

            modelBuilder.Entity<VmSozialversicherung>()
                .Property(e => e.Grund)
                .IsUnicode(false);

            modelBuilder.Entity<VmSozialversicherung>()
                .Property(e => e.Berechnungsgrundlage)
                .IsUnicode(false);

            modelBuilder.Entity<VmSozialversicherung>()
                .Property(e => e.Verfuegungsbetrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VmSozialversicherung>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<VmSozialversicherung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmSozialversicherung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmSozialversicherung>()
                .Property(e => e.VmSozialversicherungTS)
                .IsFixedLength();

            modelBuilder.Entity<VmSteuern>()
                .Property(e => e.ErledigungDurch)
                .IsUnicode(false);

            modelBuilder.Entity<VmSteuern>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<VmSteuern>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmSteuern>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmSteuern>()
                .Property(e => e.VmSteuernTS)
                .IsFixedLength();

            modelBuilder.Entity<VmTestament>()
                .Property(e => e.KopieAnCodes)
                .IsUnicode(false);

            modelBuilder.Entity<VmTestament>()
                .Property(e => e.ZeugnisseCodes)
                .IsUnicode(false);

            modelBuilder.Entity<VmTestament>()
                .Property(e => e.EroeffnungsRechnungBetrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VmTestament>()
                .Property(e => e.EroeffnungsRechnungSAPNr)
                .IsUnicode(false);

            modelBuilder.Entity<VmTestament>()
                .Property(e => e.ZusatzRechnungBetrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VmTestament>()
                .Property(e => e.ZusatzRechnungSAPNr)
                .IsUnicode(false);

            modelBuilder.Entity<VmTestament>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<VmTestament>()
                .Property(e => e.VmTestamentTS)
                .IsFixedLength();

            modelBuilder.Entity<VmTestamentBescheinigung>()
                .Property(e => e.BescheinigungText)
                .IsUnicode(false);

            modelBuilder.Entity<VmTestamentBescheinigung>()
                .Property(e => e.Gebuehr)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VmTestamentBescheinigung>()
                .Property(e => e.SAPNr)
                .IsUnicode(false);

            modelBuilder.Entity<VmTestamentBescheinigung>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<VmTestamentBescheinigung>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<VmTestamentBescheinigung>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<VmTestamentBescheinigung>()
                .Property(e => e.VmTestamentBescheinigungTS)
                .IsFixedLength();

            modelBuilder.Entity<VmTestamentVerfuegung>()
                .Property(e => e.VerfuegungText)
                .IsUnicode(false);

            modelBuilder.Entity<VmTestamentVerfuegung>()
                .Property(e => e.ABOvorherText)
                .IsUnicode(false);

            modelBuilder.Entity<VmTestamentVerfuegung>()
                .Property(e => e.ABOnachherText)
                .IsUnicode(false);

            modelBuilder.Entity<VmTestamentVerfuegung>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<VmTestamentVerfuegung>()
                .Property(e => e.VmTestamentVerfuegungTS)
                .IsFixedLength();

            modelBuilder.Entity<VmVaterschaft>()
                .Property(e => e.ZGBCodes)
                .IsUnicode(false);

            modelBuilder.Entity<VmVaterschaft>()
                .Property(e => e.AnerkennungOrt)
                .IsUnicode(false);

            modelBuilder.Entity<VmVaterschaft>()
                .Property(e => e.UHVBetrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VmVaterschaft>()
                .Property(e => e.VUrteilBetrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VmVaterschaft>()
                .Property(e => e.UnterhaltsurteilBetrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VmVaterschaft>()
                .Property(e => e.GeburtsmitteilungOrt)
                .IsUnicode(false);

            modelBuilder.Entity<VmVaterschaft>()
                .Property(e => e.PendenzText)
                .IsUnicode(false);

            modelBuilder.Entity<VmVaterschaft>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<VmVaterschaft>()
                .Property(e => e.VmVaterschaftTS)
                .IsFixedLength();

            modelBuilder.Entity<WhASVSEintrag>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<WhASVSEintrag>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<WhASVSEintrag>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<WhASVSEintrag>()
                .Property(e => e.Modified)
                .IsUnicode(false);

            modelBuilder.Entity<WhASVSEintrag>()
                .Property(e => e.WhASVSEintragTS)
                .IsFixedLength();

            modelBuilder.Entity<WhASVSEintrag>()
                .HasMany(e => e.SstASVSExport_Eintrag)
                .WithRequired(e => e.WhASVSEintrag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WhGefKategorie>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<WhGefKategorie>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<WhGefKategorie>()
                .Property(e => e.WhGefKategorieTS)
                .IsFixedLength();

            modelBuilder.Entity<WhGefKategorie>()
                .HasMany(e => e.BgKostenart_WhGefKategorie)
                .WithRequired(e => e.WhGefKategorie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XArchive>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<XArchive>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<XArchive>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<XArchive>()
                .Property(e => e.XArchiveTS)
                .IsFixedLength();

            modelBuilder.Entity<XArchive>()
                .HasMany(e => e.FaLeistungArchivs)
                .WithRequired(e => e.XArchive)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XBookmark>()
                .Property(e => e.BookmarkName)
                .IsUnicode(false);

            modelBuilder.Entity<XBookmark>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<XBookmark>()
                .Property(e => e.SQL)
                .IsUnicode(false);

            modelBuilder.Entity<XBookmark>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XBookmark>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<XBookmark>()
                .Property(e => e.XBookmarkTS)
                .IsFixedLength();

            modelBuilder.Entity<XClass>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<XClass>()
                .Property(e => e.ClassNameViewModel)
                .IsUnicode(false);

            modelBuilder.Entity<XClass>()
                .Property(e => e.MaskName)
                .IsUnicode(false);

            modelBuilder.Entity<XClass>()
                .Property(e => e.BaseType)
                .IsUnicode(false);

            modelBuilder.Entity<XClass>()
                .Property(e => e.PropertiesXML)
                .IsUnicode(false);

            modelBuilder.Entity<XClass>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XClass>()
                .Property(e => e.CodeGenerated)
                .IsUnicode(false);

            modelBuilder.Entity<XClass>()
                .Property(e => e.Branch)
                .IsUnicode(false);

            modelBuilder.Entity<XClass>()
                .Property(e => e.NamespaceExtension)
                .IsUnicode(false);

            modelBuilder.Entity<XClass>()
                .Property(e => e.XClassTS)
                .IsFixedLength();

            modelBuilder.Entity<XClass>()
                .HasMany(e => e.XUserGroup_Right)
                .WithOptional(e => e.XClass)
                .WillCascadeOnDelete();

            modelBuilder.Entity<XClassComponent>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<XClassComponent>()
                .Property(e => e.ComponentName)
                .IsUnicode(false);

            modelBuilder.Entity<XClassComponent>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<XClassComponent>()
                .Property(e => e.SelectStatement)
                .IsUnicode(false);

            modelBuilder.Entity<XClassComponent>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<XClassComponent>()
                .Property(e => e.PropertiesXML)
                .IsUnicode(false);

            modelBuilder.Entity<XClassComponent>()
                .Property(e => e.XClassComponentTS)
                .IsFixedLength();

            modelBuilder.Entity<XClassComponent>()
                .HasMany(e => e.XClassRules)
                .WithOptional(e => e.XClassComponent)
                .HasForeignKey(e => new { e.ClassName, e.ComponentName });

            modelBuilder.Entity<XClassControl>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<XClassControl>()
                .Property(e => e.ControlName)
                .IsUnicode(false);

            modelBuilder.Entity<XClassControl>()
                .Property(e => e.ParentControl)
                .IsUnicode(false);

            modelBuilder.Entity<XClassControl>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<XClassControl>()
                .Property(e => e.DataMember)
                .IsUnicode(false);

            modelBuilder.Entity<XClassControl>()
                .Property(e => e.DataSource)
                .IsUnicode(false);

            modelBuilder.Entity<XClassControl>()
                .Property(e => e.LOVName)
                .IsUnicode(false);

            modelBuilder.Entity<XClassControl>()
                .Property(e => e.PropertiesXML)
                .IsUnicode(false);

            modelBuilder.Entity<XClassControl>()
                .Property(e => e.XClassControlTS)
                .IsFixedLength();

            modelBuilder.Entity<XClassControl>()
                .HasMany(e => e.XClassRules)
                .WithOptional(e => e.XClassControl)
                .HasForeignKey(e => new { e.ClassName, e.ControlName });

            modelBuilder.Entity<XClassReference>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<XClassReference>()
                .Property(e => e.ClassName_Ref)
                .IsUnicode(false);

            modelBuilder.Entity<XClassReference>()
                .Property(e => e.XClassReferenceTS)
                .IsFixedLength();

            modelBuilder.Entity<XClassRule>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<XClassRule>()
                .Property(e => e.ControlName)
                .IsUnicode(false);

            modelBuilder.Entity<XClassRule>()
                .Property(e => e.ComponentName)
                .IsUnicode(false);

            modelBuilder.Entity<XClassRule>()
                .Property(e => e.XClassRuleTS)
                .IsFixedLength();

            modelBuilder.Entity<XConfig>()
                .Property(e => e.KeyPath)
                .IsUnicode(false);

            modelBuilder.Entity<XConfig>()
                .Property(e => e.LOVName)
                .IsUnicode(false);

            modelBuilder.Entity<XConfig>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XConfig>()
                .Property(e => e.ValueDecimal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XConfig>()
                .Property(e => e.OriginalValueDecimal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XConfig>()
                .Property(e => e.ValueMoney)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XConfig>()
                .Property(e => e.OriginalValueMoney)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XConfig>()
                .Property(e => e.ValueVarchar)
                .IsUnicode(false);

            modelBuilder.Entity<XConfig>()
                .Property(e => e.OriginalValueVarchar)
                .IsUnicode(false);

            modelBuilder.Entity<XConfig>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XConfig>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XConfig>()
                .Property(e => e.XConfigTS)
                .IsFixedLength();

            modelBuilder.Entity<XDBServerVersion>()
                .Property(e => e.ServerVersion)
                .IsUnicode(false);

            modelBuilder.Entity<XDBServerVersion>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XDBServerVersion>()
                .Property(e => e.XDBServerVersionTS)
                .IsFixedLength();

            modelBuilder.Entity<XDBVersion>()
                .Property(e => e.SQLServerVersionInfo)
                .IsUnicode(false);

            modelBuilder.Entity<XDBVersion>()
                .Property(e => e.ChangesSinceLastVersion)
                .IsUnicode(false);

            modelBuilder.Entity<XDBVersion>()
                .Property(e => e.BackwardCompatibleDownToClientVersion)
                .IsUnicode(false);

            modelBuilder.Entity<XDBVersion>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XDBVersion>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XDBVersion>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XDBVersion>()
                .Property(e => e.XDBVersionTS)
                .IsFixedLength();

            modelBuilder.Entity<XDeleteRule>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<XDeleteRule>()
                .Property(e => e.ColumnName)
                .IsUnicode(false);

            modelBuilder.Entity<XDeleteRule>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XDeleteRule>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XDeleteRule>()
                .Property(e => e.XDeleteRuleTS)
                .IsFixedLength();

            modelBuilder.Entity<XDocContext>()
                .Property(e => e.DocContextName)
                .IsUnicode(false);

            modelBuilder.Entity<XDocContext>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XDocContext>()
                .Property(e => e.XDocContextTS)
                .IsFixedLength();

            modelBuilder.Entity<XDocContext>()
                .HasMany(e => e.XDocContext_Template)
                .WithOptional(e => e.XDocContext)
                .WillCascadeOnDelete();

            modelBuilder.Entity<XDocContext_Template>()
                .Property(e => e.FolderName)
                .IsUnicode(false);

            modelBuilder.Entity<XDocContext_Template>()
                .Property(e => e.XDocContext_TemplateTS)
                .IsFixedLength();

            modelBuilder.Entity<XDocContext_Template>()
                .HasMany(e => e.XDocContext_Template1)
                .WithOptional(e => e.XDocContext_Template2)
                .HasForeignKey(e => e.ParentID);

            modelBuilder.Entity<XDocContextType>()
                .Property(e => e.NameDocContextType)
                .IsUnicode(false);

            modelBuilder.Entity<XDocContextType>()
                .Property(e => e.TemplateFolder)
                .IsUnicode(false);

            modelBuilder.Entity<XDocContextType>()
                .Property(e => e.DocumentFolder)
                .IsUnicode(false);

            modelBuilder.Entity<XDocContextType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XDocContextType>()
                .Property(e => e.XDocContextTypeTS)
                .IsFixedLength();

            modelBuilder.Entity<XDocTemplate>()
                .Property(e => e.DocTemplateName)
                .IsUnicode(false);

            modelBuilder.Entity<XDocTemplate>()
                .Property(e => e.FileExtension)
                .IsUnicode(false);

            modelBuilder.Entity<XDocTemplate>()
                .Property(e => e.CheckOut_Filename)
                .IsUnicode(false);

            modelBuilder.Entity<XDocTemplate>()
                .Property(e => e.CheckOut_Machine)
                .IsUnicode(false);

            modelBuilder.Entity<XDocTemplate>()
                .Property(e => e.DocTemplateTS)
                .IsFixedLength();

            modelBuilder.Entity<XDocTemplate>()
                .HasMany(e => e.XOrgUnit_XDocTemplate)
                .WithRequired(e => e.XDocTemplate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XDocument>()
                .Property(e => e.FileExtension)
                .IsUnicode(false);

            modelBuilder.Entity<XDocument>()
                .Property(e => e.XDocumentTS)
                .IsFixedLength();

            modelBuilder.Entity<XDocument>()
                .Property(e => e.DocTemplateName)
                .IsUnicode(false);

            modelBuilder.Entity<XDocument>()
                .Property(e => e.CheckOut_Filename)
                .IsUnicode(false);

            modelBuilder.Entity<XDocument>()
                .Property(e => e.CheckOut_Machine)
                .IsUnicode(false);

            modelBuilder.Entity<XHyperlink>()
                .Property(e => e.Hyperlink)
                .IsUnicode(false);

            modelBuilder.Entity<XHyperlink>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<XHyperlink>()
                .Property(e => e.XHyperlinkTS)
                .IsFixedLength();

            modelBuilder.Entity<XHyperlinkContext>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<XHyperlinkContext>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XHyperlinkContext>()
                .Property(e => e.XHyperlinkContextTS)
                .IsFixedLength();

            modelBuilder.Entity<XHyperlinkContext>()
                .HasMany(e => e.XHyperlinkContext_Hyperlink)
                .WithRequired(e => e.XHyperlinkContext)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XHyperlinkContext_Hyperlink>()
                .Property(e => e.FolderName)
                .IsUnicode(false);

            modelBuilder.Entity<XHyperlinkContext_Hyperlink>()
                .Property(e => e.XHyperlinkContext_HyperlinkTS)
                .IsFixedLength();

            modelBuilder.Entity<XHyperlinkContext_Hyperlink>()
                .HasMany(e => e.XHyperlinkContext_Hyperlink1)
                .WithOptional(e => e.XHyperlinkContext_Hyperlink2)
                .HasForeignKey(e => e.ParentID);

            modelBuilder.Entity<XIcon>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<XIcon>()
                .Property(e => e.XIconTS)
                .IsFixedLength();

            modelBuilder.Entity<XIcon>()
                .HasMany(e => e.XModulTrees)
                .WithRequired(e => e.XIcon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XLangText>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<XLangText>()
                .Property(e => e.LargeText)
                .IsUnicode(false);

            modelBuilder.Entity<XLangText>()
                .Property(e => e.XLangTextTS)
                .IsFixedLength();

            modelBuilder.Entity<XLog>()
                .Property(e => e.Source)
                .IsUnicode(false);

            modelBuilder.Entity<XLog>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<XLog>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<XLog>()
                .Property(e => e.ReferenceTable)
                .IsUnicode(false);

            modelBuilder.Entity<XLog>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XLog>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XLog>()
                .Property(e => e.XLogTS)
                .IsFixedLength();

            modelBuilder.Entity<XLOV>()
                .Property(e => e.LOVName)
                .IsUnicode(false);

            modelBuilder.Entity<XLOV>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XLOV>()
                .Property(e => e.NameValue1)
                .IsUnicode(false);

            modelBuilder.Entity<XLOV>()
                .Property(e => e.NameValue2)
                .IsUnicode(false);

            modelBuilder.Entity<XLOV>()
                .Property(e => e.NameValue3)
                .IsUnicode(false);

            modelBuilder.Entity<XLOV>()
                .Property(e => e.XLOVTS)
                .IsFixedLength();

            modelBuilder.Entity<XLOV>()
                .HasMany(e => e.XLOVCodes)
                .WithRequired(e => e.XLOV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XLOVCode>()
                .Property(e => e.LOVName)
                .IsUnicode(false);

            modelBuilder.Entity<XLOVCode>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<XLOVCode>()
                .Property(e => e.ShortText)
                .IsUnicode(false);

            modelBuilder.Entity<XLOVCode>()
                .Property(e => e.Value1)
                .IsUnicode(false);

            modelBuilder.Entity<XLOVCode>()
                .Property(e => e.Value2)
                .IsUnicode(false);

            modelBuilder.Entity<XLOVCode>()
                .Property(e => e.Value3)
                .IsUnicode(false);

            modelBuilder.Entity<XLOVCode>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XLOVCode>()
                .Property(e => e.LOVCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<XLOVCode>()
                .Property(e => e.XLOVCodeTS)
                .IsFixedLength();

            modelBuilder.Entity<XMenuItem>()
                .Property(e => e.ControlName)
                .IsUnicode(false);

            modelBuilder.Entity<XMenuItem>()
                .Property(e => e.Caption)
                .IsUnicode(false);

            modelBuilder.Entity<XMenuItem>()
                .Property(e => e.ItemShortcutKey)
                .IsUnicode(false);

            modelBuilder.Entity<XMenuItem>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<XMenuItem>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XMenuItem>()
                .Property(e => e.XMenuItemTS)
                .IsFixedLength();

            modelBuilder.Entity<XMenuItem>()
                .HasMany(e => e.XMenuItem1)
                .WithOptional(e => e.XMenuItem2)
                .HasForeignKey(e => e.ParentMenuItemID);

            modelBuilder.Entity<XMessage>()
                .Property(e => e.MaskName)
                .IsUnicode(false);

            modelBuilder.Entity<XMessage>()
                .Property(e => e.MessageName)
                .IsUnicode(false);

            modelBuilder.Entity<XMessage>()
                .Property(e => e.Context)
                .IsUnicode(false);

            modelBuilder.Entity<XMessage>()
                .Property(e => e.XMessageTS)
                .IsFixedLength();

            modelBuilder.Entity<XModul>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<XModul>()
                .Property(e => e.ShortName)
                .IsUnicode(false);

            modelBuilder.Entity<XModul>()
                .Property(e => e.NameSpace)
                .IsUnicode(false);

            modelBuilder.Entity<XModul>()
                .Property(e => e.DB_Prefix)
                .IsUnicode(false);

            modelBuilder.Entity<XModul>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XModul>()
                .Property(e => e.XModulTS)
                .IsFixedLength();

            modelBuilder.Entity<XModul>()
                .HasMany(e => e.BgKostenarts)
                .WithRequired(e => e.XModul)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XModul>()
                .HasMany(e => e.BgPositionsarts)
                .WithRequired(e => e.XModul)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XModul>()
                .HasMany(e => e.DynaMasks)
                .WithRequired(e => e.XModul)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XModul>()
                .HasMany(e => e.FaLeistungs)
                .WithRequired(e => e.XModul)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XModul>()
                .HasMany(e => e.XClasses)
                .WithRequired(e => e.XModul)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XModulTree>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<XModulTree>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<XModulTree>()
                .Property(e => e.MaskName)
                .IsUnicode(false);

            modelBuilder.Entity<XModulTree>()
                .Property(e => e.sqlPreExecute)
                .IsUnicode(false);

            modelBuilder.Entity<XModulTree>()
                .Property(e => e.sqlInsertTreeItem)
                .IsUnicode(false);

            modelBuilder.Entity<XModulTree>()
                .Property(e => e.XModulTreeTS)
                .IsFixedLength();

            modelBuilder.Entity<XNamespaceExtension>()
                .Property(e => e.NamespaceExtension)
                .IsUnicode(false);

            modelBuilder.Entity<XNamespaceExtension>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XNamespaceExtension>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XNamespaceExtension>()
                .Property(e => e.XNamespaceExtensionTS)
                .IsFixedLength();

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.ItemName)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.PCKonto)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.AD_Abteilung)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.Adressat)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.AdresseKGS)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.AdresseAbteilung)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.AdresseStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.Postfach)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.AdresseHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.AdressePLZ)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.AdresseOrt)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.WWW)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.Internet)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.Text1)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.Text2)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.Text3)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.Text4)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit>()
                .Property(e => e.XOrgUnitTS)
                .IsFixedLength();

            modelBuilder.Entity<XOrgUnit>()
                .HasMany(e => e.BgBewilligungs)
                .WithOptional(e => e.XOrgUnit)
                .HasForeignKey(e => e.OrgUnitID_ChefZustaendig);

            modelBuilder.Entity<XOrgUnit>()
                .HasMany(e => e.FaKategorisierungEksProdukts)
                .WithRequired(e => e.XOrgUnit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XOrgUnit>()
                .HasMany(e => e.GvFonds_XOrgUnit)
                .WithRequired(e => e.XOrgUnit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XOrgUnit>()
                .HasMany(e => e.XOrgUnit_User)
                .WithRequired(e => e.XOrgUnit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XOrgUnit>()
                .HasMany(e => e.XOrgUnit_XDocTemplate)
                .WithRequired(e => e.XOrgUnit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XOrgUnit>()
                .HasMany(e => e.XOrgUnit1)
                .WithOptional(e => e.XOrgUnit2)
                .HasForeignKey(e => e.ParentID);

            modelBuilder.Entity<XOrgUnit_User>()
                .Property(e => e.XOrgUnit_UserTS)
                .IsFixedLength();

            modelBuilder.Entity<XOrgUnit_XDocTemplate>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit_XDocTemplate>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XOrgUnit_XDocTemplate>()
                .Property(e => e.XOrgUnit_XDocTemplateTS)
                .IsFixedLength();

            modelBuilder.Entity<XPermissionGroup>()
                .Property(e => e.PermissionGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<XPermissionGroup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XPermissionGroup>()
                .Property(e => e.XPermissionGroupTS)
                .IsFixedLength();

            modelBuilder.Entity<XPermissionGroup>()
                .HasMany(e => e.XUsers)
                .WithOptional(e => e.XPermissionGroup)
                .HasForeignKey(e => e.GrantPermGroupID);

            modelBuilder.Entity<XPermissionGroup>()
                .HasMany(e => e.XUsers1)
                .WithOptional(e => e.XPermissionGroup1)
                .HasForeignKey(e => e.PermissionGroupID);

            modelBuilder.Entity<XPermissionValue>()
                .Property(e => e.XPermissionValueTS)
                .IsFixedLength();

            modelBuilder.Entity<XProfile>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<XProfile>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XProfile>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XProfile>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XProfile>()
                .Property(e => e.XProfileTS)
                .IsFixedLength();

            modelBuilder.Entity<XProfile>()
                .HasMany(e => e.XProfile_XProfileTag)
                .WithRequired(e => e.XProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XProfile_XProfileTag>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XProfile_XProfileTag>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XProfile_XProfileTag>()
                .Property(e => e.XProfile_XProfileTagTS)
                .IsFixedLength();

            modelBuilder.Entity<XProfileTag>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<XProfileTag>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XProfileTag>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XProfileTag>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XProfileTag>()
                .Property(e => e.XProfileTagTS)
                .IsFixedLength();

            modelBuilder.Entity<XProfileTag>()
                .HasMany(e => e.XProfile_XProfileTag)
                .WithRequired(e => e.XProfileTag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XQuery>()
                .Property(e => e.QueryName)
                .IsUnicode(false);

            modelBuilder.Entity<XQuery>()
                .Property(e => e.ParentReportName)
                .IsUnicode(false);

            modelBuilder.Entity<XQuery>()
                .Property(e => e.UserText)
                .IsUnicode(false);

            modelBuilder.Entity<XQuery>()
                .Property(e => e.LayoutXML)
                .IsUnicode(false);

            modelBuilder.Entity<XQuery>()
                .Property(e => e.ParameterXML)
                .IsUnicode(false);

            modelBuilder.Entity<XQuery>()
                .Property(e => e.SQLquery)
                .IsUnicode(false);

            modelBuilder.Entity<XQuery>()
                .Property(e => e.ContextForms)
                .IsUnicode(false);

            modelBuilder.Entity<XQuery>()
                .Property(e => e.RelationColumnName)
                .IsUnicode(false);

            modelBuilder.Entity<XQuery>()
                .Property(e => e.XQueryTS)
                .IsFixedLength();

            modelBuilder.Entity<XQuery>()
                .HasMany(e => e.XUserGroup_Right)
                .WithOptional(e => e.XQuery)
                .WillCascadeOnDelete();

            modelBuilder.Entity<XRight>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<XRight>()
                .Property(e => e.RightName)
                .IsUnicode(false);

            modelBuilder.Entity<XRight>()
                .Property(e => e.UserText)
                .IsUnicode(false);

            modelBuilder.Entity<XRight>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XRight>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XRight>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XRight>()
                .Property(e => e.XRightTS)
                .IsFixedLength();

            modelBuilder.Entity<XRule>()
                .Property(e => e.RuleName)
                .IsUnicode(false);

            modelBuilder.Entity<XRule>()
                .Property(e => e.RuleDescription)
                .IsUnicode(false);

            modelBuilder.Entity<XRule>()
                .Property(e => e.csCode)
                .IsUnicode(false);

            modelBuilder.Entity<XRule>()
                .Property(e => e.XRuleTS)
                .IsFixedLength();

            modelBuilder.Entity<XRule>()
                .HasMany(e => e.XClassRules)
                .WithRequired(e => e.XRule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XSearchControlTemplate>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<XSearchControlTemplate>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<XSearchControlTemplate>()
                .Property(e => e.ColLayout)
                .IsUnicode(false);

            modelBuilder.Entity<XSearchControlTemplate>()
                .HasMany(e => e.XSearchControlTemplate1)
                .WithOptional(e => e.XSearchControlTemplate2)
                .HasForeignKey(e => e.ParentXSearchControlTemplateID);

            modelBuilder.Entity<XSearchControlTemplate>()
                .HasMany(e => e.XSearchControlTemplateFields)
                .WithRequired(e => e.XSearchControlTemplate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XSearchControlTemplateField>()
                .Property(e => e.ControlName)
                .IsUnicode(false);

            modelBuilder.Entity<XSearchControlTemplateField>()
                .Property(e => e.ControlType)
                .IsUnicode(false);

            modelBuilder.Entity<XSearchControlTemplateField>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<XTable>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<XTable>()
                .Property(e => e.Alias)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<XTable>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<XTable>()
                .Property(e => e.XTableTS)
                .IsFixedLength();

            modelBuilder.Entity<XTableColumn>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<XTableColumn>()
                .Property(e => e.ColumnName)
                .IsUnicode(false);

            modelBuilder.Entity<XTableColumn>()
                .Property(e => e.DisplayText)
                .IsUnicode(false);

            modelBuilder.Entity<XTableColumn>()
                .Property(e => e.LOVName)
                .IsUnicode(false);

            modelBuilder.Entity<XTableColumn>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<XTableColumn>()
                .Property(e => e.XTableColumnTS)
                .IsFixedLength();

            modelBuilder.Entity<XTask>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<XTask>()
                .Property(e => e.TaskDescription)
                .IsUnicode(false);

            modelBuilder.Entity<XTask>()
                .Property(e => e.ResponseText)
                .IsUnicode(false);

            modelBuilder.Entity<XTask>()
                .Property(e => e.JumpToPath)
                .IsUnicode(false);

            modelBuilder.Entity<XTask>()
                .Property(e => e.XTaskTS)
                .IsFixedLength();

            modelBuilder.Entity<XTask>()
                .HasMany(e => e.FaWeisungs)
                .WithOptional(e => e.XTask)
                .HasForeignKey(e => e.XTaskID_SAR);

            modelBuilder.Entity<XTask>()
                .HasMany(e => e.XTaskAutoGenerateds)
                .WithRequired(e => e.XTask)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XTaskAutoGenerated>()
                .Property(e => e.ReferenceTable)
                .IsUnicode(false);

            modelBuilder.Entity<XTaskAutoGenerated>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XTaskAutoGenerated>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XTaskAutoGenerated>()
                .Property(e => e.XTaskAutoGeneratedTS)
                .IsFixedLength();

            modelBuilder.Entity<XTaskTemplate>()
                .Property(e => e.TaskSubject)
                .IsUnicode(false);

            modelBuilder.Entity<XTaskTemplate>()
                .Property(e => e.TaskDescription)
                .IsUnicode(false);

            modelBuilder.Entity<XTaskTemplate>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XTaskTemplate>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XTaskTemplate>()
                .Property(e => e.XTaskTemplateTS)
                .IsFixedLength();

            modelBuilder.Entity<XTaskTemplate>()
                .HasMany(e => e.FaWeisungWorkflows)
                .WithOptional(e => e.XTaskTemplate)
                .HasForeignKey(e => e.XTaskTemplateID_RD);

            modelBuilder.Entity<XTaskTemplate>()
                .HasMany(e => e.FaWeisungWorkflows1)
                .WithOptional(e => e.XTaskTemplate1)
                .HasForeignKey(e => e.XTaskTemplateID_SAR);

            modelBuilder.Entity<XTaskTypeAction>()
                .Property(e => e.Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<XTaskTypeAction>()
                .Property(e => e.Betreff)
                .IsUnicode(false);

            modelBuilder.Entity<XTaskTypeAction>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<XTaskTypeAction>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XTaskTypeAction>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XTaskTypeAction>()
                .Property(e => e.XTaskTypeActionTS)
                .IsFixedLength();

            modelBuilder.Entity<XTranslateColumn>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<XTranslateColumn>()
                .Property(e => e.ColumnName)
                .IsUnicode(false);

            modelBuilder.Entity<XTranslateColumn>()
                .Property(e => e.TIDColumnName)
                .IsUnicode(false);

            modelBuilder.Entity<XTranslateColumn>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XTranslateColumn>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XTranslateColumn>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XTranslateColumn>()
                .Property(e => e.XTranslateColumnTS)
                .IsFixedLength();

            modelBuilder.Entity<XTypeConfig>()
                .Property(e => e.LookupTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<XTypeConfig>()
                .Property(e => e.LookupTypeNamespace)
                .IsUnicode(false);

            modelBuilder.Entity<XTypeConfig>()
                .Property(e => e.LookupTypeAssemblyName)
                .IsUnicode(false);

            modelBuilder.Entity<XTypeConfig>()
                .Property(e => e.ConcreteStandardTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<XTypeConfig>()
                .Property(e => e.ConcreteStandardTypeNamespace)
                .IsUnicode(false);

            modelBuilder.Entity<XTypeConfig>()
                .Property(e => e.ConcreteStandardTypeAssemblyName)
                .IsUnicode(false);

            modelBuilder.Entity<XTypeConfig>()
                .Property(e => e.ConcreteCustomTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<XTypeConfig>()
                .Property(e => e.ConcreteCustomTypeNamespace)
                .IsUnicode(false);

            modelBuilder.Entity<XTypeConfig>()
                .Property(e => e.ConcreteCustomTypeAssemblyName)
                .IsUnicode(false);

            modelBuilder.Entity<XTypeConfig>()
                .Property(e => e.XTypeConfigTS)
                .IsFixedLength();

            modelBuilder.Entity<XUser>()
                .Property(e => e.MitarbeiterNr)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.LogonName)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.ShortName)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.PhoneMobile)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.PhoneOffice)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.PhoneIntern)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.PhonePrivat)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.Funktion)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.Text1)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.Text2)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.WeitereKostentraeger)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.MigHerkunft)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.MigMAKuerzel)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.visdat36Area)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.visdat36SourceFile)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.visdat36ID)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.visdat36Name)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XUser>()
                .Property(e => e.XUserTS)
                .IsFixedLength();

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.BaAdresses)
                .WithOptional(e => e.XUser)
                .WillCascadeOnDelete();

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.BaInstitutionDokuments)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.BDEAusbezahlteUeberstunden_XUser)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.BDEFerienanspruch_XUser)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.BDEFerienkuerzungen_XUser)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.BDELeistungs)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.BDEPensum_XUser)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.BDESollProTag_XUser)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.BDESollStundenProJahr_XUser)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.BDEZeitrechners)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.BgBewilligungs)
                .WithRequired(e => e.XUser)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.BgBewilligungs1)
                .WithOptional(e => e.XUser1)
                .HasForeignKey(e => e.UserID_An);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.BgBewilligungs2)
                .WithOptional(e => e.XUser2)
                .HasForeignKey(e => e.UserID_Zustaendig);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.BgPositions)
                .WithOptional(e => e.XUser)
                .HasForeignKey(e => e.ErstelltUserID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.BgPositions1)
                .WithOptional(e => e.XUser1)
                .HasForeignKey(e => e.MutiertUserID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FaDokumentAblages)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FaDokumentes)
                .WithOptional(e => e.XUser)
                .HasForeignKey(e => e.UserID_Absender);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FaDokumentes1)
                .WithOptional(e => e.XUser1)
                .HasForeignKey(e => e.UserID_EkVisumUser);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FaDokumentes2)
                .WithOptional(e => e.XUser2)
                .HasForeignKey(e => e.UserID_VisiertDurch);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FaDokumentes3)
                .WithOptional(e => e.XUser3)
                .HasForeignKey(e => e.UserID_VisumBeantragtBei);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FaDokumentes4)
                .WithOptional(e => e.XUser4)
                .HasForeignKey(e => e.UserID_VisumBeantragtDurch);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FaKategorisierungs)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FaLeistungs)
                .WithOptional(e => e.XUser)
                .HasForeignKey(e => e.SachbearbeiterID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FaLeistungs1)
                .WithRequired(e => e.XUser1)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FaLeistungArchivs)
                .WithRequired(e => e.XUser)
                .HasForeignKey(e => e.CheckInUserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FaLeistungArchivs1)
                .WithOptional(e => e.XUser1)
                .HasForeignKey(e => e.CheckOutUserID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FaLeistungUserHists)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FaWeisungs)
                .WithRequired(e => e.XUser)
                .HasForeignKey(e => e.UserID_Creator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FaWeisungs1)
                .WithOptional(e => e.XUser1)
                .HasForeignKey(e => e.UserID_VerantwortlichRD);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FaWeisungs2)
                .WithOptional(e => e.XUser2)
                .HasForeignKey(e => e.UserID_VerantwortlichSAR);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FbBarauszahlungAuftrags)
                .WithRequired(e => e.XUser)
                .HasForeignKey(e => e.UserID_Creator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FbBarauszahlungAuftrags1)
                .WithRequired(e => e.XUser1)
                .HasForeignKey(e => e.UserID_Modifier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FbBarauszahlungAusbezahlts)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FbBelegNrs)
                .WithOptional(e => e.XUser)
                .WillCascadeOnDelete();

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FbBuchungCodes)
                .WithOptional(e => e.XUser)
                .WillCascadeOnDelete();

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FbDTAJournals)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.FsReduktionMitarbeiters)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.GvBewilligungs)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.GvDocuments)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.GvGesuches)
                .WithOptional(e => e.XUser)
                .HasForeignKey(e => e.AbgeschlossenesGesuchdurchIKS_UserID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.GvGesuches1)
                .WithOptional(e => e.XUser1)
                .HasForeignKey(e => e.ErfasstesGesuchgeprueftdurchIKS_UserID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.GvGesuches2)
                .WithRequired(e => e.XUser2)
                .HasForeignKey(e => e.XUserID_Autor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.IkAbklaerungs)
                .WithOptional(e => e.XUser)
                .WillCascadeOnDelete();

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.KaBetriebBesprechungs)
                .WithOptional(e => e.XUser)
                .HasForeignKey(e => e.AutorID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.KbBuchungs)
                .WithOptional(e => e.XUser)
                .HasForeignKey(e => e.BarbelegUserID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.KbBuchungs1)
                .WithRequired(e => e.XUser1)
                .HasForeignKey(e => e.ErstelltUserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.KbBuchungs2)
                .WithOptional(e => e.XUser2)
                .HasForeignKey(e => e.MutiertUserID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.KbWVLaufs)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.KbZahlungseingangs)
                .WithOptional(e => e.XUser)
                .HasForeignKey(e => e.ErstelltUserID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.KbZahlungseingangs1)
                .WithOptional(e => e.XUser1)
                .HasForeignKey(e => e.MutiertUserID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.KbZahlungseingangs2)
                .WithOptional(e => e.XUser2)
                .HasForeignKey(e => e.ZugeteiltUserID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.KbZahlungslaufs)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.VmKlientenbudgets)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.XDocTemplates)
                .WithOptional(e => e.XUser)
                .HasForeignKey(e => e.CheckOut_UserID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.XOrgUnits)
                .WithOptional(e => e.XUser)
                .HasForeignKey(e => e.ChiefID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.XOrgUnits1)
                .WithOptional(e => e.XUser1)
                .HasForeignKey(e => e.RechtsdienstUserID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.XOrgUnits2)
                .WithOptional(e => e.XUser2)
                .HasForeignKey(e => e.RepresentativeID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.XSearchControlTemplates)
                .WithRequired(e => e.XUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.XTasks)
                .WithOptional(e => e.XUser)
                .HasForeignKey(e => e.UserID_InBearbeitung);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.XTasks1)
                .WithOptional(e => e.XUser1)
                .HasForeignKey(e => e.UserID_Erledigt);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.XUser1)
                .WithOptional(e => e.XUser2)
                .HasForeignKey(e => e.ChiefID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.XUser11)
                .WithOptional(e => e.XUser3)
                .HasForeignKey(e => e.PrimaryUserID);

            modelBuilder.Entity<XUser>()
                .HasMany(e => e.XUser12)
                .WithOptional(e => e.XUser4)
                .HasForeignKey(e => e.SachbearbeiterID);

            modelBuilder.Entity<XUser_Archive>()
                .Property(e => e.XUser_ArchiveTS)
                .IsFixedLength();

            modelBuilder.Entity<XUser_BDEUserGroup>()
                .Property(e => e.XUser_BDEUserGroupTS)
                .IsFixedLength();

            modelBuilder.Entity<XUser_UserGroup>()
                .Property(e => e.XUser_UserGroupTS)
                .IsFixedLength();

            modelBuilder.Entity<XUser_XDocTemplate>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XUser_XDocTemplate>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XUser_XDocTemplate>()
                .Property(e => e.XUser_XDocTemplateTS)
                .IsFixedLength();

            modelBuilder.Entity<XUserGroup>()
                .Property(e => e.UserGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<XUserGroup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<XUserGroup>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XUserGroup>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XUserGroup>()
                .Property(e => e.XUserGroupTS)
                .IsFixedLength();

            modelBuilder.Entity<XUserGroup>()
                .HasMany(e => e.XUser_UserGroup)
                .WithRequired(e => e.XUserGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<XUserGroup_Right>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<XUserGroup_Right>()
                .Property(e => e.QueryName)
                .IsUnicode(false);

            modelBuilder.Entity<XUserGroup_Right>()
                .Property(e => e.MaskName)
                .IsUnicode(false);

            modelBuilder.Entity<XUserGroup_Right>()
                .Property(e => e.XUserGroup_RightTS)
                .IsFixedLength();

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart2)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart3)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart4)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart5)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart6)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart7)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart8)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart9)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart10)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart11)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart12)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart13)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart14)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart15)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart16)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart17)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart18)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart19)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Lohnart20)
                .HasPrecision(19, 4);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<XUserStundenansatz>()
                .Property(e => e.XUserStundenansatzTS)
                .IsFixedLength();

            modelBuilder.Entity<dtproperty>()
                .Property(e => e.property)
                .IsUnicode(false);

            modelBuilder.Entity<dtproperty>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<MigXClassFrmToCtl>()
                .Property(e => e.FormName)
                .IsUnicode(false);

            modelBuilder.Entity<MigXClassFrmToCtl>()
                .Property(e => e.ControlName)
                .IsUnicode(false);

            modelBuilder.Entity<XPlausiFehler>()
                .Property(e => e.VarName)
                .IsUnicode(false);

            modelBuilder.Entity<XPlausiFehler>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<XPlausiFehler>()
                .Property(e => e.XPlausiFehlerTS)
                .IsFixedLength();

            // Views
            modelBuilder.Entity<AyKostenart>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AyKostenart>()
                .Property(e => e.KontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<AyKostenart>()
                .Property(e => e.BgKostenartTS)
                .IsFixedLength();

            modelBuilder.Entity<AyPositionsart>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AyPositionsart>()
                .Property(e => e.HilfeText)
                .IsUnicode(false);

            modelBuilder.Entity<AyPositionsart>()
                .Property(e => e.sqlRichtlinie)
                .IsUnicode(false);

            modelBuilder.Entity<AyPositionsart>()
                .Property(e => e.VarName)
                .IsUnicode(false);

            modelBuilder.Entity<AyPositionsart>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<AyPositionsart>()
                .Property(e => e.BgPositionsartTS)
                .IsFixedLength();

            modelBuilder.Entity<viewDauerauftrag>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<viewDauerauftrag>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<viewDauerauftrag>()
                .Property(e => e.ReferenzNummer)
                .IsUnicode(false);

            modelBuilder.Entity<viewDauerauftrag>()
                .Property(e => e.Zahlungsgrund)
                .IsUnicode(false);

            modelBuilder.Entity<viewDauerauftrag>()
                .Property(e => e.FbDauerauftragTS)
                .IsFixedLength();

            modelBuilder.Entity<viewDauerauftrag>()
                .Property(e => e.AuftragStatus)
                .IsUnicode(false);

            modelBuilder.Entity<viewDauerauftrag>()
                .Property(e => e.AuftragPeriodizitaet)
                .IsUnicode(false);

            modelBuilder.Entity<viewDauerauftrag>()
                .Property(e => e.Mandant)
                .IsUnicode(false);

            modelBuilder.Entity<viewDauerauftrag>()
                .Property(e => e.HabenKtoName)
                .IsUnicode(false);

            modelBuilder.Entity<viewDauerauftrag>()
                .Property(e => e.SollKtoName)
                .IsUnicode(false);

            modelBuilder.Entity<viewDauerauftrag>()
                .Property(e => e.PlzOrt)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.BelegNr)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.IBAN)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.VertragNr)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.Mandant)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.KontoName)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.DTAKontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.DTAZugang)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.Kreditor)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.KreditorName)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.KreditorStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.KreditorZusatz)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.KreditorPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.KreditorOrt)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.Zahlungsgrund)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.PCKontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.BankKontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.BankName)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.BankStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.BankPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.BankOrt)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.ClearingNr)
                .IsUnicode(false);

            modelBuilder.Entity<viewDTAFbBuchungen>()
                .Property(e => e.StatusText)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungCode>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungCode>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<viewFbBuchungCode>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungCode>()
                .Property(e => e.FbBuchungCodeTS)
                .IsFixedLength();

            modelBuilder.Entity<viewFbBuchungCode>()
                .Property(e => e.SollKtoName)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungCode>()
                .Property(e => e.HabenKtoName)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungCode>()
                .Property(e => e.Mandant)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungCode>()
                .Property(e => e.PlzOrt)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungCode>()
                .Property(e => e.MTLogon)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungCode>()
                .Property(e => e.MTName)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.BelegNr)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.PCKontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.BankKontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.IBAN)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.ReferenzNummer)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.Zahlungsgrund)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.Zusatz)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.Strasse)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.PLZ)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.Ort)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.FbBuchungTS)
                .IsFixedLength();

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.SollKtoName)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.HabenKtoName)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.Mandant)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.PlzOrt)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.MTLogon)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.MTName)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.ErfLogon)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.ErfName)
                .IsUnicode(false);

            modelBuilder.Entity<viewFbBuchungen>()
                .Property(e => e.StatusText)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaAdressate>()
                .Property(e => e.Typ)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaAdressate>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaAdressate>()
                .Property(e => e.Strasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaAdressate>()
                .Property(e => e.Ort)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaZahlungsweg>()
                .Property(e => e.BankKontoNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaZahlungsweg>()
                .Property(e => e.IBANNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaZahlungsweg>()
                .Property(e => e.PostKontoNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaZahlungsweg>()
                .Property(e => e.ReferenzNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaZahlungsweg>()
                .Property(e => e.AdresseName)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaZahlungsweg>()
                .Property(e => e.AdresseName2)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaZahlungsweg>()
                .Property(e => e.AdresseStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaZahlungsweg>()
                .Property(e => e.AdresseHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaZahlungsweg>()
                .Property(e => e.AdressePostfach)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaZahlungsweg>()
                .Property(e => e.AdressePLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaZahlungsweg>()
                .Property(e => e.AdresseOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaZahlungsweg>()
                .Property(e => e.BaZahlwegModulStdCodes)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaZahlungsweg>()
                .Property(e => e.BaZahlungswegTS)
                .IsFixedLength();

            modelBuilder.Entity<vwBaZahlungsweg>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaZahlungsweg>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<vwBaZahlungsweg>()
                .Property(e => e.Empfaenger)
                .IsUnicode(false);

            modelBuilder.Entity<vwBgPosition>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwBgPosition>()
                .Property(e => e.Reduktion)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwBgPosition>()
                .Property(e => e.Abzug)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwBgPosition>()
                .Property(e => e.BetragEff)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwBgPosition>()
                .Property(e => e.MaxBeitragSD)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwBgPosition>()
                .Property(e => e.Buchungstext)
                .IsUnicode(false);

            modelBuilder.Entity<vwBgPosition>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<vwBgPosition>()
                .Property(e => e.BgPositionTS)
                .IsFixedLength();

            modelBuilder.Entity<vwBgPosition>()
                .Property(e => e.BetragFinanzplan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwBgPosition>()
                .Property(e => e.BetragBudget)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwBgPosition>()
                .Property(e => e.BetragRechnung)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwBgPositionFinanzplan>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwBgPositionFinanzplan>()
                .Property(e => e.Reduktion)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwBgPositionFinanzplan>()
                .Property(e => e.Abzug)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.InstitutionNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Anrede)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Briefanrede)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Vorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Telefon2)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Telefon3)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Homepage)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.BaInstitutionTS)
                .IsFixedLength();

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.NameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.AdresseMehrzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.OrtStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Zusatz)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.AdressZusatz)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Strasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.HausNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.StrasseHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Postfach)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.PostfachTextD)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.PLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Ort)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.PLZOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Bezirk)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Kanton)
                .IsUnicode(false);

            modelBuilder.Entity<vwInstitution>()
                .Property(e => e.Land)
                .IsUnicode(false);

            modelBuilder.Entity<vwIxBDELeistung_BDELeistungsart_AuswDLCode>()
                .Property(e => e.DauerSUM)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.BankKontoNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.IBANNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.PostKontoNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.ReferenzNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.BankName)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.BankZusatz)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.BankStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.BankPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.BankOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.BankClearingNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.BankPCKontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.InstitutionName)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.InstitutionAdresse)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.InstitutionOrtStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.InstitutionAdressZusatz)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.InstitutionStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.InstitutionHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.InstitutionStrasseHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.InstitutionPostfach)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.InstitutionPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.InstitutionOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.InstitutionPLZOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.InstitutionKanton)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.InstitutionLand)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.PersonName)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.PersonVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.PersonNameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.PersonAdresse)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.PersonAdressZusatz)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.PersonStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.PersonHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.PersonStrasseHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.PersonPostfach)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.PersonPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.PersonOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.PersonPLZOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.PersonKanton)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.PersonLand)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.Kreditor)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.KreditorMehrZeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.KreditorEinzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.Zahlungsweg)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.ZahlungswegMehrZeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.PCKontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.ZusatzInfo)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.BeguenstigtName)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.BeguenstigtName2)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.BeguenstigtStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.BeguenstigtPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwKreditor>()
                .Property(e => e.BeguenstigtOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.FruehererName)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.Vorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.Vorname2)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.AHVNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.Versichertennummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.HaushaltVersicherungsNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.NNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.ZEMISNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.BFFNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.HeimatgemeindeCodes)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.Telefon_P)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.Telefon_G)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.MobilTel)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.NavigatorZusatz)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.BaPersonTS)
                .IsFixedLength();

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.ZuzugKtPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.ZuzugKtOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.ZuzugKtKanton)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.ZuzugGdePLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.ZuzugGdeOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.ZuzugGdeKanton)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.UntWohnsitzPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.UntWohnsitzOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.UntWohnsitzKanton)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.WegzugPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.WegzugOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.WegzugKanton)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.Modifier)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.NameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.VornameName)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.Nationalitaet)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.NationalitaetFR)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.NationalitaetIT)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.Heimatort)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.Wohnsitz)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.WohnsitzMehrzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.WohnsitzAdressZusatz)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.WohnsitzStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.WohnsitzHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.WohnsitzStrasseHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.WohnsitzPostfach)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.WohnsitzPostfachD)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.WohnsitzPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.WohnsitzOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.WohnsitzPLZOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.WohnsitzKanton)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.WohnsitzLand)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.WohnsitzBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.Aufenthalt)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.AufenthaltMehrzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.AufenthaltAdressZusatz)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.AufenthaltStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.AufenthaltHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.AufenthaltStrasseHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.AufenthaltPostfach)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.AufenthaltPostfachD)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.AufenthaltPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.AufenthaltOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.AufenthaltPLZOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.AufenthaltKanton)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.AufenthaltLand)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.AufenthaltBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.AufenthaltInstitutionName)
                .IsUnicode(false);

            modelBuilder.Entity<vwPerson>()
                .Property(e => e.Anrede)
                .IsUnicode(false);

            modelBuilder.Entity<vwPersonSimple>()
                .Property(e => e.NameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwPersonSimple>()
                .Property(e => e.Versichertennummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwShMassendruckPapierverfuegung>()
                .Property(e => e.SAR)
                .IsUnicode(false);

            modelBuilder.Entity<vwShMassendruckPapierverfuegung>()
                .Property(e => e.Klient)
                .IsUnicode(false);

            modelBuilder.Entity<vwShMassendruckPapierverfuegung>()
                .Property(e => e.BudgetMonat)
                .IsUnicode(false);

            modelBuilder.Entity<vwShMassendruckPapierverfuegung>()
                .Property(e => e.Intern)
                .IsUnicode(false);

            modelBuilder.Entity<vwShMassendruckPapierverfuegung>()
                .Property(e => e.Betrag)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwTmAbklPhasen>()
                .Property(e => e.Fragestellungen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAbklPhasen>()
                .Property(e => e.GrundDossier)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAbklPhasen>()
                .Property(e => e.IntegBeurteilung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAbklPhasen>()
                .Property(e => e.KursDatumBis)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAbklPhasen>()
                .Property(e => e.KursDatumVon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAbklPhasen>()
                .Property(e => e.Phase)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAbklPhasen>()
                .Property(e => e.PhaseDatum)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAbklPhasen>()
                .Property(e => e.Rueckfragen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAbklPhasen>()
                .Property(e => e.Kursnummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAbklPhasen>()
                .Property(e => e.EinsatzIn)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAdressat>()
                .Property(e => e.GeehrteFrauHerr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAdressat>()
                .Property(e => e.ErsteZeile)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAdressat>()
                .Property(e => e.AdresseMehrzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAdressat>()
                .Property(e => e.Ort)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAdressat>()
                .Property(e => e.PLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAdressat>()
                .Property(e => e.PLZOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAdressat>()
                .Property(e => e.Strasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAdressat>()
                .Property(e => e.Zusatzzeile)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAdressat>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAllgemein>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAllgemein>()
                .Property(e => e.Kursabschluss)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAllgemein>()
                .Property(e => e.Kursaustritt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAllgemein>()
                .Property(e => e.Kurseintritt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmAllgemein>()
                .Property(e => e.Kursname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.AHVNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.DerDes)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.DerDesBesch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.DieDer)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.DieDerBesch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.Todesdatum)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.TodesdatumBesch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.TodesdatumOderBereich)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.Todesort)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserAdresseEinzeln)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserAdresseEinzelnBesch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserAnrede)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserAnredeBesch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserElternnamen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserElternnamenBesch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserFamilienNamen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserFamilienNamenBesch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserGeburtsdatum)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserGeburtsdatumBesch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserHeimatorte)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserHeimatorteBesch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserVornamen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserVornamenBesch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserZivilstand)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserZivilstandBesch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.lasserLasserin)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserInfo1)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserInfo2)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserInfo3)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmErblasser>()
                .Property(e => e.ErblasserInfo4)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.Datum)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.Dauer)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.Kontaktart)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.GespraechsStatus)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.Gespraechstyp)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.Kontaktpartner)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.AlimentenstelleTyp)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.Stichwort)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.InhaltMitFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.InhaltOhneFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.Themen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.Vertraulich)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.BesprechungThema1)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.BesprechungThema2)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.BesprechungThema3)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.BesprechungThema4)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.BesprechungThemaText1)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.BesprechungThemaText2)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.BesprechungThemaText3)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.BesprechungThemaText4)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.BesprechungZiel1)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.BesprechungZiel2)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.BesprechungZiel3)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.BesprechungZiel4)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.BesprechungZielGrad1)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.BesprechungZielGrad2)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.BesprechungZielGrad3)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.BesprechungZielGrad4)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.Pendenz1)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.Pendenz2)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.Pendenz3)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.Pendenz4)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.PendenzErledigt1)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.PendenzErledigt2)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.PendenzErledigt3)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.PendenzErledigt4)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.UserLogin)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.UserNachname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.UserVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.UserKuerzel)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.UserNameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.UserNameVornameOhneKomma)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmFaAktennotizen>()
                .Property(e => e.UserVornameName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.Gesuchsgrund)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.BetragBewilligt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.BegruendungMitFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.BegruendungOhneFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.BewilligungBetragKS1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.BewilligungBemerkungKS1)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.BewilligungBetragKS2)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.BewilligungBemerkungKS2)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.BewilligtVonName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.BewilligtVonVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.BewilligtVonAbteilung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.AbschlussgrundD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.AbschlussgrundF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.AbschlussgrundI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.BetragBeantragt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.BetragEigenleistung)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.TotalAusFLBFond)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.Mitarbeiter)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.KGS)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.Kostenstelle)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.Klient)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.FondsNameKurz)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.FondsNameLang)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.FondsBemerkungD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.FondsBemerkungF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.FondsBemerkungI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.FondsTypD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.FondsTypF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.FondsTypI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.Verteiler)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmGvGesuch>()
                .Property(e => e.VerteilerMehrzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.InstitutionNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.Vorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.NameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.Homepage)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.CareOf)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.AdressZusatz)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.ZuhandenVon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.Strasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.HausNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.Postfach)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.PostfachTextD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.PLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.Ort)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.Kanton)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.Bezirk)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.StrasseHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.OrtStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.PLZOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.LandD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.LandF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.LandI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.LandE)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.AdresseEinzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.AdresseEinzOhneName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.AdresseMehrzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmInstitution>()
                .Property(e => e.AdresseMehrzOhneName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.AdressZusatz)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.AdresseMehrzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.Land)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.TeilbetriebVon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.Internet)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.Charakter)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.DokStichworte)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.DokAbsenderVornameName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.DokAdressatAnrede)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.DokAdressatSehrGeehrte)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.DokAdressatLieberLiebe)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.DokAdressatName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.DokAdressatVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.DokAdressatVornameName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.DokAdressatTel)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.DokAdressatMobil)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetrieb>()
                .Property(e => e.DokAdressatAdresseMehrz)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetriebVerlauf>()
                .Property(e => e.Kontaktperson)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetriebVerlauf>()
                .Property(e => e.Autor)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaBetriebVerlauf>()
                .Property(e => e.Stichwort)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEafSozioberuflicheBilanz>()
                .Property(e => e.AnwTeilzeit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEafSozioberuflicheBilanz>()
                .Property(e => e.Schwerpunkte)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEafSozioberuflicheBilanz>()
                .Property(e => e.BemAbschluss)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEafSozioberuflicheBilanz>()
                .Property(e => e.ZielRav)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEafSozioberuflicheBilanz>()
                .Property(e => e.Ergebnisse)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEafSpezifischeErmittlung>()
                .Property(e => e.AnwTeilzeit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEafSpezifischeErmittlung>()
                .Property(e => e.Zielsetzungen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEafSpezifischeErmittlung>()
                .Property(e => e.BemAbschluss)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.Aktiv)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.Branche)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.Betrieb)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.BetriebAdresse)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.Stellenbeschreibung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.KAProgramm)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.ZustaendigKA)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.Lehrberuf)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.TypAusbildung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.NeuGeschLehrstelle)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.unbefristet)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.aufteilbar)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.PensumUnbestimmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.Fuehrerausweis)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.FuehrerausweisKat)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.PCKenntnisse)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.Geschlecht)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.WeitereAnforderungen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.DeutschMuendlich)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.DeutschSchriftlich)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.Ausbildung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.Kontaktperson)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.KontaktFunktion)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.KontaktBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.KontaktTelefon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.KontaktTelefonMobil)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.KontaktFax)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaEinsatzplatz>()
                .Property(e => e.KontaktEMail)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaQJFallfuehrung>()
                .Property(e => e.Vorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaQJFallfuehrung>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaQJFallfuehrung>()
                .Property(e => e.Adressat)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaQJFallfuehrung>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaQJFallfuehrung>()
                .Property(e => e.Briefanrede)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaQJFallfuehrung>()
                .Property(e => e.Anrede)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaQJFallfuehrung>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaQJFallfuehrung>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaQJFallfuehrung>()
                .Property(e => e.Institution)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaTransfer>()
                .Property(e => e.AllgZiele)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaTransfer>()
                .Property(e => e.Bewerbungsstrategie)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaTransfer>()
                .Property(e => e.MuendAufforderungBem1)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaTransfer>()
                .Property(e => e.MuendAufforderungBem2)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaTransfer>()
                .Property(e => e.AustrittBem)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaVerlauf>()
                .Property(e => e.Autor)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaVerlauf>()
                .Property(e => e.Kontaktart)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaVerlauf>()
                .Property(e => e.Kontaktperson)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaVerlauf>()
                .Property(e => e.Stichwort)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaVerlauf>()
                .Property(e => e.Thema)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaVerlauf>()
                .Property(e => e.InhaltRTF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaVerlauf>()
                .Property(e => e.InhaltNORTF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaVermittlung>()
                .Property(e => e.SIZuweiserVornameName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaVermittlung>()
                .Property(e => e.SIZuweiserAnrede)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaVermittlung>()
                .Property(e => e.SIZuweiserSektion)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaVermittlung>()
                .Property(e => e.BIBIPZuweiserVornameName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaVermittlung>()
                .Property(e => e.BIBIPZuweiserAnrede)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaVermittlung>()
                .Property(e => e.BIBIPZuweiserSektion)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaVermittlungBIBIP>()
                .Property(e => e.ZustaendigKA)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKaVermittlungSI>()
                .Property(e => e.ZustaendigKA)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesAuftrag>()
                .Property(e => e.AbklaerungDurch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesAuftrag>()
                .Property(e => e.MeldungDurchD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesAuftrag>()
                .Property(e => e.MeldungDurchF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesAuftrag>()
                .Property(e => e.MeldungDurchI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesAuftrag>()
                .Property(e => e.AuftragDurchD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesAuftrag>()
                .Property(e => e.AuftragDurchF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesAuftrag>()
                .Property(e => e.AuftragDurchI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesAuftrag>()
                .Property(e => e.AbklaerungsartDE)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesAuftrag>()
                .Property(e => e.AbklaerungsartFR)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesAuftrag>()
                .Property(e => e.AbklaerungsartIT)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesAuftrag>()
                .Property(e => e.Anlass)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesAuftrag>()
                .Property(e => e.Auftrag)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesAuftrag>()
                .Property(e => e.AbschlussgrundD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesAuftrag>()
                .Property(e => e.AbschlussgrundF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesAuftrag>()
                .Property(e => e.AbschlussgrundI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.VerfasserFrauHerr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.VerfasserFrauHerrn)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.VerfasserNameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.VerfasserNameVornameOhneKomma)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.VerfasserVornameName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.VerfasserAbteilungEMail)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.VerfasserAbteilungFax)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.VerfasserAbteilungName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.VerfasserAbteilungTelefon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.VerfasserNachname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.VerfasserVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.VerfasserKuerzel)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.VerfasserTelephon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.VerfasserEMail)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.Stichwort)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.ResultatD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.ResultatF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.ResultatI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.ArtDE)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.ArtFR)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesDokument>()
                .Property(e => e.ArtIT)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.MFPNameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.MFPNmVrnmOhnKmma)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.MFPVornameName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.MFPAdrssEinzeilg)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.MFPAdrssMhrzeilg)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.SARFrauHerr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.SARFrauHerrn)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.SARNameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.SARNamVrnmOhnKma)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.SARVornameName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.SARAbteilungEMai)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.SARAbteilungFax)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.SARAbteilungName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.SARAbteilungTel)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.SARNachname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.SARVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.SARKuerzel)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.SARTelephon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.SAREMail)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.ElterlicheSorgeD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.ElterlicheSorgeF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.ElterlicheSorgeI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.MassAuftragstext)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.BrchtArtDsBrchtD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.BrchtArtDsBrchtF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.BrchtArtDsBrchtI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.AuftragAuftrag)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.AuftrgrtGschftsD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.AuftrgrtGschftsF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesMassnahmeBericht>()
                .Property(e => e.AuftrgrtGschftsI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.KontaktartDE)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.KontaktartFR)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.KontaktartIT)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.DienstleistungD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.DienstleistungF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.DienstleistungI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.Stichwort)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.VerfasserFrauHerr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.VerfasserFrauHerrn)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.VerfasserNameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.VerfasserNameVornameOhneKomma)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.VerfasserVornameName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.VerfasserAbteilungEMail)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.VerfasserAbteilungFax)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.VerfasserAbteilungName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.VerfasserAbteilungTelefon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.VerfasserNachname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.VerfasserVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.VerfasserKuerzel)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.VerfasserTelephon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.VerfasserEMail)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.DauerD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.DauerF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.DauerI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmKesVerlauf>()
                .Property(e => e.Inhalt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Anrede)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.FrühererName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Vorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.VornameName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Vorname2)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.NameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.NameVornameOhneKomma)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.NameGB)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.NameGBVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.NameGBVornameOhneKomma)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Nationalitaet)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Geschlecht)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Geburtsdatum)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.GeburtsdatumAmerikanisch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.GestorbenAm)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AHVNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Versichertennummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.VersichertennummerSonstAHVNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.BemerkungOhneFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.BemerkungMitFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.NNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.BFFNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.HaushaltVersicherungsNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Konfession)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Heimatort)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.HeimatortNationalitaet)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.HeimatortNationalitaetD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.HeimatortNationalitaetF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.HeimatortNationalitaetI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.PLZHeimatort)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Sprache)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.SpracheVertsaendigung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Permis)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.PermisBis)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.PermisSeit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltGueltigBis)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.InCHseit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EndeZustaendigkeit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.TelefonP)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.TelefonG)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.TelefonMobil)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Navigatorzusatz)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.WegzugOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.WegzugPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Zivilstand)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.ZivilstandD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.ZivilstandF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.ZivilstandI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.ZivilstandSeit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.ZuzugOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.ZuzugPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.ZEMISNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.ErSie)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.ErSieGross)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.HerrFrau)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.HerrFrauName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.GeehrterHerrFrau)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.GeehrterHerrFrauName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.HerrnFrau)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.HerrnFrauName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.FrauHerrVornameName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.IhmIhr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.LieberLiebe)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.SeinIhr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.SeineIhre)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.SeinerIhrer)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.ProjektteilnehmerIn)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.TeilnehmerIn)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltsortAdresseEinzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltsortAdresseEinzOhneName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltsortAdresseMehrzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltsortAdresseMehrzOhneName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltsortStrasseNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltsortPLZOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltWohnortAdrEinzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltWohnortAdrEinzOhneName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltWohnortAdrMehrzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltWohnortAdrMehrzOhneName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltWohnsitzStrasseNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltWohnsitzPLZOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltWohnsitzPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltWohnsitzOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltPostfachD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltPostfachF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltPostfachI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AufenthaltInstitutionName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.WohnsitzAdresseEinzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.WohnsitzAdresseEinzeiligGB)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.WohnsitzAdresseEinzOhneName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.WohnsitzAdresseMehrzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.WohnsitzAdresseMehrzOhneName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.WohnsitzStrasseNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.WohnsitzPLZOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.WohnsitzOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.WohnsitzPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.WohnsitzPostfachD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.WohnsitzPostfachF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.WohnsitzPostfachI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Wohnsituation)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Wohnungsgroesse)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.ArbeitslosSeit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.AusgesteuertSeit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Beruf)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.ErlernterBeruf)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Schulbildung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.VermieterName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.VermieterAdresseEinzOhneName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.VermieterAdresseMehrzOhneName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.VermieterAdresseStrasseNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.VermieterAdressePLZOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.VermieterAdressePLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.VermieterAdresseOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.KVGName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.KVGMitgliedNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.KVGAdresseEinzOhneName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.VVGName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.VVGMitgliedNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.VVGAdresseEinzOhneName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerNachname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerVorname2)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerNachnameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerNNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerBFFNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerInCHseit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerNationalitaet)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerZivilstand)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerBeruf)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerEndeZustaendigkeit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerErteilungVA)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerGeschlecht)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerPermis)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerGebDatum)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerAHVNummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerVersichertennummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerAnrede)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerPLZOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerStrasseNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.EhepartnerStrassePLZOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmPerson>()
                .Property(e => e.Kostenstelle)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.Nachname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.Vorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.Kuerzel)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.Telephon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.ErSieGross)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.FrauHerr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.FrauHerrn)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.Briefanrede)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.NameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.NameVornameOhneKomma)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.VornameName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.Text1MitFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.Text1OhneFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.Text2MitFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.Text2OhneFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AbteilungEMail)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AbteilungFax)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AbteilungName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AbteilungTelefon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AbteilungTelFaxWWW)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AbteilungText1MitFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AbteilungText1OhneFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AbteilungText2MitFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AbteilungText2OhneFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AbteilungText3MitFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AbteilungText3OhneFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AbteilungText4MitFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AbteilungText4OhneFmt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AbteilungWWW)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.CareOf)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AdressZusatz)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.ZuhandenVon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.Strasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.HausNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.Postfach)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.PostfachTextD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.PLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.Ort)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.Kanton)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.Bezirk)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.StrasseHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.OrtStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.PLZOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.LandD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.LandF)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.LandI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.LandE)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AdresseEinzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AdresseEinzOhneName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AdresseMehrzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AdresseMehrzOhneName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmUser>()
                .Property(e => e.AbteilungLeitungInitialen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.BIBruttolohn)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.ZustKANachname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.ZustKAVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.ZustKAKuerzel)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.ZustKATelephon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.ZustKAEMail)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.ZustKANameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.ZustKANameVornameOhneKomma)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.ZustKAVornameName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.Einsatzplatz)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.EPBranche)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.EPKaProgramm)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.EPLehrberuf)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.EPBerufsausbildung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.Betrieb)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.BetriebAdressZusatz)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.BetriebStrasse)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.BetriebHausNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.BetriebPostfach)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.BetriebPLZ)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.BetriebOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.BetriebKanton)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.BetriebLand)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.BetriebAdresseMehrzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.KontaktTitel)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.KontaktName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.KontaktVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.KontaktGeschlecht)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.KontaktTelefon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.KontaktTelefonMobil)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.KontaktFax)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.KontaktEmail)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.KontaktNameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.KontaktVornameName)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungEinsatz>()
                .Property(e => e.KontaktLieberLiebe)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Branchen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Betriebe)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Einsatzbereiche)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Lehrberuf)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.DeutschMuendlich)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.DeutschSchriftlich)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Sprachstandermittlung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.VermittelbarkeitBIBIP)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.VermittelbarkeitSI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.VermittelbarkeitBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Sucht)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Suchtart)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Gesundheit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.GesundheitEinschraenkungen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.GesundheitKoerperlich)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.EinschraenkungenKoerperlich)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.GesundheitBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.GesundheitPsychisch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Therapie)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Zuverlaessigkeit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.MotivationInizio)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.MotivationBIBIPSI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.AeussereErscheinungBIBIP)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.AeussereErscheinungSI)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Kinderbetreuung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.BesondereWuensche)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.BesondereFaehigkeiten)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Fuehrerausweis)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.FuehrerausweisKategorie)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.PCKenntnisse)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Ausbildung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Arbeitszeiten)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Unterstützung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.SIGespraechfuehrerin)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Ausbildungswunsch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Berufswunsch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.ArbeitsgebietBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Schweizerdeutsch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.LohnabtretungSD)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.LaufendeBetreibungen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.AktuelleTaetigkeit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Verfuegbarkeit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.EinschraenkungMontag)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.EinschraenkungDienstag)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.EinschraenkungMittwoch)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.EinschraenkungDonnerstag)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.EinschraenkungFreitag)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.EinschraenkungSamstag)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.EinschraenkungSonntag)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVermittlungProfil>()
                .Property(e => e.Nachtarbeit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmAntragEKSK>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmAntragEKSK>()
                .Property(e => e.Begruendung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmAntragEKSK>()
                .Property(e => e.DatumAntrag)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmAntragEKSK>()
                .Property(e => e.Antrag)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmAntragEKSK>()
                .Property(e => e.GenehmigtEKSK)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmAntragEKSK>()
                .Property(e => e.Autor)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmGefaehrdungsMeldung>()
                .Property(e => e.DatumEingang)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmGefaehrdungsMeldung>()
                .Property(e => e.Kontaktveranlasser)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmGefaehrdungsMeldung>()
                .Property(e => e.GefaehrdungNSB)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmGefaehrdungsMeldung>()
                .Property(e => e.Themen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmGefaehrdungsMeldung>()
                .Property(e => e.Ausgangslage)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmGefaehrdungsMeldung>()
                .Property(e => e.Auflagen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmGefaehrdungsMeldung>()
                .Property(e => e.Ueberpruefung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmGefaehrdungsMeldung>()
                .Property(e => e.Konsequenzen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmGefaehrdungsMeldung>()
                .Property(e => e.AuflageDatum)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.GrundMassnahme)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.Berichtstitel)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.BerichtDatumVon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.BerichtDatumBis)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.GrundMassnahmeText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.AuftragZielsetzungText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.ZielErreicht)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.VeraenderungInPeriodCBText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.Begruendung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.NeueZieleText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.Wohnen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.Gesundheit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.Verhalten)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.Taetigkeit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.FamiliaereSituationCBText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.SozialeKompetenzenCBText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.FreizeitCBText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.ResourcenCBText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.WohnenText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.GesundheitText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.VerhaltenText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.TaetigkeitText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.FamSituationText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.SozialeKompetenzenText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.FreizeitText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.BesondereRessourcenText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.HandlungenText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.BesSchwierigkeitenText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.KlientCBText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.DritteCBText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.InstitutionenCBText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.KlientText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.DritteText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.InstitutionenText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.MCSCMandat)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.BerichtBelastAngMCSCAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.BelastungMandatText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.BelastungAdminText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.EinnahmenAngaben)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.EA)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.BerichtVersicherungen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.BV)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.BerichtBesondereAngaben)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.BBA)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.EinnahmenBemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.VersicherungenBemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.BesondereAngabenBem)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.AbrechnungUnterschrieben)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.PassationTeilnahmeCBText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.PassationBemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.AntragBericht)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.AntragBegruendung)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.ErstellungDatum)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.BerichtBeilagen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.BsDatum)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.BelegeZurueckRevision)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.ZurueckVomBS)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.Berichtsart)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmMandBericht>()
                .Property(e => e.Autor)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSachversicherung>()
                .Property(e => e.VerArt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSachversicherung>()
                .Property(e => e.Policenummer)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSachversicherung>()
                .Property(e => e.Selbstbehalt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSachversicherung>()
                .Property(e => e.Grundpraemie)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSachversicherung>()
                .Property(e => e.Zahlungsturnus)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSachversicherung>()
                .Property(e => e.LaufzeitVon)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSachversicherung>()
                .Property(e => e.LaufzeitBis)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSachversicherung>()
                .Property(e => e.VersichertSeit)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSachversicherung>()
                .Property(e => e.Person)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSachversicherung>()
                .Property(e => e.Bemerkungen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSachversicherung>()
                .Property(e => e.Adressat_NameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSachversicherung>()
                .Property(e => e.Adressat_StrasseNr)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSachversicherung>()
                .Property(e => e.Adressat_PLZOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSachversicherung>()
                .Property(e => e.Adressat_AdrMehrzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSachversicherung>()
                .Property(e => e.Adressat_AdrEinzeilig)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSituationsBericht>()
                .Property(e => e.AntragDatum)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSituationsBericht>()
                .Property(e => e.TypSHAntrag)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSituationsBericht>()
                .Property(e => e.Themen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSituationsBericht>()
                .Property(e => e.BerichtFinanzen)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSituationsBericht>()
                .Property(e => e.ZielPrognose)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSituationsBericht>()
                .Property(e => e.AntragText)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmSituationsBericht>()
                .Property(e => e.Autor)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmVaterschaft>()
                .Property(e => e.AnerkennungDat)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmVaterschaft>()
                .Property(e => e.AnerkennungOrt)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmVaterschaft>()
                .Property(e => e.UHVDat)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmVaterschaft>()
                .Property(e => e.SgeVDat)
                .IsUnicode(false);

            modelBuilder.Entity<vwTmVmVaterschaft>()
                .Property(e => e.GenehmDat)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.LogonName)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.ShortName)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.Text1)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.Text2)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.XUserTS)
                .IsFixedLength();

            modelBuilder.Entity<vwUser>()
                .Property(e => e.NameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.NameVornameOhneKomma)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.VornameName)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.LogonNameVornameOrgUnit)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.OrgEinheitName)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.OrgUnit)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.OrgEinheitEmail)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.OrgEinheitFax)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.OrgEinheitWWW)
                .IsUnicode(false);

            modelBuilder.Entity<vwUser>()
                .Property(e => e.DisplayText)
                .IsUnicode(false);

            modelBuilder.Entity<vwUserSimple>()
                .Property(e => e.LogonName)
                .IsUnicode(false);

            modelBuilder.Entity<vwUserSimple>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<vwUserSimple>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<vwUserSimple>()
                .Property(e => e.NameVorname)
                .IsUnicode(false);

            modelBuilder.Entity<vwUserSimple>()
                .Property(e => e.DisplayText)
                .IsUnicode(false);

            modelBuilder.Entity<vwXConfig_public>()
                .Property(e => e.KeyPath)
                .IsUnicode(false);

            modelBuilder.Entity<vwXConfig_public>()
                .Property(e => e.LOVName)
                .IsUnicode(false);

            modelBuilder.Entity<vwXConfig_public>()
                .Property(e => e.ValueDecimal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwXConfig_public>()
                .Property(e => e.OriginalValueDecimal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwXConfig_public>()
                .Property(e => e.ValueMoney)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwXConfig_public>()
                .Property(e => e.OriginalValueMoney)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vwXConfig_public>()
                .Property(e => e.ValueVarchar)
                .IsUnicode(false);

            modelBuilder.Entity<vwXConfig_public>()
                .Property(e => e.OriginalValueVarchar)
                .IsUnicode(false);

            modelBuilder.Entity<WhKostenart>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<WhKostenart>()
                .Property(e => e.KontoNr)
                .IsUnicode(false);

            modelBuilder.Entity<WhKostenart>()
                .Property(e => e.BgKostenartTS)
                .IsFixedLength();

            modelBuilder.Entity<WhPositionsart>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<WhPositionsart>()
                .Property(e => e.Hilfetext)
                .IsUnicode(false);

            modelBuilder.Entity<WhPositionsart>()
                .Property(e => e.sqlRichtlinie)
                .IsUnicode(false);

            modelBuilder.Entity<WhPositionsart>()
                .Property(e => e.BgPositionsartTS)
                .IsFixedLength();

            modelBuilder.Entity<WhPositionsart>()
                .Property(e => e.VarName)
                .IsUnicode(false);

            modelBuilder.Entity<WhPositionsart>()
                .Property(e => e.Bemerkung)
                .IsUnicode(false);

            modelBuilder.Entity<WhPositionsart>()
                .Property(e => e.KontoNrName)
                .IsUnicode(false);

            modelBuilder.Entity<XViewForeignKey>()
                .Property(e => e.PKColumns)
                .IsUnicode(false);

            modelBuilder.Entity<XViewForeignKey>()
                .Property(e => e.FKColumns)
                .IsUnicode(false);

            modelBuilder.Entity<XViewIndex>()
                .Property(e => e.Keys)
                .IsUnicode(false);
        }
    }
}
