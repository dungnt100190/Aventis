using System;
using System.Collections.Generic;
using Kiss4Web.Model.Basis;
using Kiss4Web.Model.Entities;

namespace Kiss4Web.Model
{
    public partial class BaPerson : IEntity, IAuditableEntity
    {
        public BaPerson()
        {
            BaAdresse = new HashSet<BaAdresse>();
            BaEinwohnerregisterPersonAnAbmeldung = new HashSet<BaEinwohnerregisterPersonAnAbmeldung>();
            BaEinwohnerregisterPersonStatus = new HashSet<BaEinwohnerregisterPersonStatus>();
            BaGesundheit = new HashSet<BaGesundheit>();
            BaInstitutionDokument = new HashSet<BaInstitutionDokument>();
            BaKopfquote = new HashSet<BaKopfquote>();
            BaMietvertrag = new HashSet<BaMietvertrag>();
            BaPersonBaInstitution = new HashSet<BaPersonBaInstitution>();
            BaPersonKantonalerZuschuss = new HashSet<BaPersonKantonalerZuschuss>();
            BaPersonRelationBaPersonId1Navigation = new HashSet<BaPersonRelation>();
            BaPersonRelationBaPersonId2Navigation = new HashSet<BaPersonRelation>();
            BaPraemienverbilligung = new HashSet<BaPraemienverbilligung>();
            BaWvcode = new HashSet<BaWvcode>();
            BaZahlungsweg = new HashSet<BaZahlungsweg>();
            Bdeleistung = new HashSet<Bdeleistung>();
            BfsdossierPerson = new HashSet<BfsdossierPerson>();
            BgAuszahlungPerson = new HashSet<BgAuszahlungPerson>();
            BgFinanzplanBaPerson = new HashSet<BgFinanzplanBaPerson>();
            BgPositionBaPerson = new HashSet<BgPosition>();
            BgPositionDebitorBaPerson = new HashSet<BgPosition>();
            BgSpezkonto = new HashSet<BgSpezkonto>();
            FaDokumentAblage = new HashSet<FaDokumentAblage>();
            FaDokumentAblageBaPerson = new HashSet<FaDokumentAblageBaPerson>();
            FaDokumenteBaPersonIdAdressatNavigation = new HashSet<FaDokumente>();
            FaDokumenteBaPersonIdLtNavigation = new HashSet<FaDokumente>();
            FaKategorisierung = new HashSet<FaKategorisierung>();
            FaLeistungBaPerson = new HashSet<FaLeistung>();
            FaLeistungSchuldnerBaPerson = new HashSet<FaLeistung>();
            FaWeisungBaPerson = new HashSet<FaWeisungBaPerson>();
            FbBelegNr = new HashSet<FbBelegNr>();
            FbBuchungCode = new HashSet<FbBuchungCode>();
            FbBuchungskreis = new HashSet<FbBuchungskreis>();
            FbDauerauftrag = new HashSet<FbDauerauftrag>();
            FbPeriode = new HashSet<FbPeriode>();
            GvDocument = new HashSet<GvDocument>();
            GvGesuch = new HashSet<GvGesuch>();
            IkEinkommen = new HashSet<IkEinkommen>();
            IkForderung = new HashSet<IkForderung>();
            IkGlaeubigerBaPerson = new HashSet<IkGlaeubiger>();
            IkGlaeubigerBaPersonIdAntragStellendePersonNavigation = new HashSet<IkGlaeubiger>();
            IkPosition = new HashSet<IkPosition>();
            IkRechtstitel = new HashSet<IkRechtstitel>();
            IkVerrechnungskonto = new HashSet<IkVerrechnungskonto>();
            InverseBaPersonIdDossiertraegerNavigation = new HashSet<BaPerson>();
            KaAmmBesch = new HashSet<KaAmmBesch>();
            KaArbeitsrapport = new HashSet<KaArbeitsrapport>();
            KaEinsatz = new HashSet<KaEinsatz>();
            KaExterneBildung = new HashSet<KaExterneBildung>();
            KaIntegBildung = new HashSet<KaIntegBildung>();
            KaSequenzen = new HashSet<KaSequenzen>();
            KaZuteilFachbereich = new HashSet<KaZuteilFachbereich>();
            KbBuchung = new HashSet<KbBuchung>();
            KbBuchungKostenart = new HashSet<KbBuchungKostenart>();
            KbKostenstelleBaPerson = new HashSet<KbKostenstelleBaPerson>();
            KbWveinzelposten = new HashSet<KbWveinzelposten>();
            KbWveinzelpostenFehler = new HashSet<KbWveinzelpostenFehler>();
            KbZahlungseingang = new HashSet<KbZahlungseingang>();
            KesAuftragBaPerson = new HashSet<KesAuftragBaPerson>();
            KesDokument = new HashSet<KesDokument>();
            KesVerlauf = new HashSet<KesVerlauf>();
            ServiceProcessError = new HashSet<ServiceProcessError>();
            ShEinzelzahlung = new HashSet<ShEinzelzahlung>();
            VmMandant = new HashSet<VmMandant>();
            VmSachversicherung = new HashSet<VmSachversicherung>();
            VmSozialversicherung = new HashSet<VmSozialversicherung>();
            WhAsvseintrag = new HashSet<WhAsvseintrag>();
            Xtask = new HashSet<Xtask>();
        }

        public int BaPersonId { get; set; }
        public int? StatusPersonCode { get; set; }
        public string Titel { get; set; }
        public string Name { get; set; }
        public string FruehererName { get; set; }
        public string Vorname { get; set; }
        public string Vorname2 { get; set; }
        public DateTime? Geburtsdatum { get; set; }
        public DateTime? Sterbedatum { get; set; }
        public string Ahvnummer { get; set; }
        public string Versichertennummer { get; set; }
        public string HaushaltVersicherungsNummer { get; set; }
        public string Nnummer { get; set; }
        public string Bffnummer { get; set; }
        public string Zarnummer { get; set; }
        public int? Zipnr { get; set; }
        public string KantonaleReferenznummer { get; set; }
        public Geschlecht? GeschlechtCode { get; set; }
        public int? ZivilstandCode { get; set; }
        public DateTime? ZivilstandDatum { get; set; }
        public int? HeimatgemeindeCode { get; set; }
        public string HeimatgemeindeCodes { get; set; }
        public int? NationalitaetCode { get; set; }
        public int? ReligionCode { get; set; }
        public int? AuslaenderStatusCode { get; set; }
        public DateTime? AuslaenderStatusGueltigBis { get; set; }
        public string TelefonP { get; set; }
        public string TelefonG { get; set; }
        public string MobilTel1 { get; set; }
        public string MobilTel2 { get; set; }
        public string Email { get; set; }
        public int? SprachCode { get; set; }
        public bool? Unterstuetzt { get; set; }
        public bool Fiktiv { get; set; }
        public string Bemerkung { get; set; }
        public bool EinwohnerregisterAktiv { get; set; }
        public string EinwohnerregisterId { get; set; }
        public int? DeutschVerstehenCode { get; set; }
        public int? WichtigerHinweisCode { get; set; }
        public string ZuzugKtPlz { get; set; }
        public int? ZuzugKtOrtCode { get; set; }
        public string ZuzugKtOrt { get; set; }
        public string ZuzugKtKanton { get; set; }
        public int? ZuzugKtLandCode { get; set; }
        public DateTime? ZuzugKtDatum { get; set; }
        public bool? ZuzugKtSeitGeburt { get; set; }
        public string ZuzugGdePlz { get; set; }
        public int? ZuzugGdeOrtCode { get; set; }
        public string ZuzugGdeOrt { get; set; }
        public string ZuzugGdeKanton { get; set; }
        public int? ZuzugGdeLandCode { get; set; }
        public DateTime? ZuzugGdeDatum { get; set; }
        public bool? ZuzugGdeSeitGeburt { get; set; }
        public string UntWohnsitzPlz { get; set; }
        public string UntWohnsitzOrt { get; set; }
        public string UntWohnsitzKanton { get; set; }
        public int? UntWohnsitzLandCode { get; set; }
        public string WegzugPlz { get; set; }
        public int? WegzugOrtCode { get; set; }
        public string WegzugOrt { get; set; }
        public string WegzugKanton { get; set; }
        public int? WegzugLandCode { get; set; }
        public DateTime? WegzugDatum { get; set; }
        public int? WohnsitzWieBaPersonId { get; set; }
        public int? AufenthaltWieBaInstitutionId { get; set; }
        public int? ErwerbssituationCode { get; set; }
        public int? GrundTeilzeitarbeit1Code { get; set; }
        public int? GrundTeilzeitarbeit2Code { get; set; }
        public int? BaGrundNichtErwerbstaetigCode { get; set; }
        public int? ErwerbsBrancheCode { get; set; }
        public int? ErlernterBerufCode { get; set; }
        public int? BerufCode { get; set; }
        public int? HoechsteAusbildungCode { get; set; }
        public int? AbgebrocheneAusbildungCode { get; set; }
        public string ArbeitSpezFaehigkeiten { get; set; }
        public int? KbKostenstelleId { get; set; }
        public DateTime? InChseit { get; set; }
        public bool InChseitGeburt { get; set; }
        public int? PuanzahlVerlustscheine { get; set; }
        public string Pukrankenkasse { get; set; }
        public DateTime? PraemienuebernahmeVon { get; set; }
        public DateTime? PraemienuebernahmeBis { get; set; }
        public bool PersonOhneLeistung { get; set; }
        public bool Hcmcfluechtling { get; set; }
        public int? StellensuchendCode { get; set; }
        public int? ResoNr { get; set; }
        public DateTime? Neanmeldung { get; set; }
        public int? HeimatgemeindeBaGemeindeId { get; set; }
        public bool? AktiveKopfQuote { get; set; }
        public bool Alk { get; set; }
        public string AndereSvleistungen { get; set; }
        public string Anrede { get; set; }
        public int? AusbildungCode { get; set; }
        public int? Behinderungsart2Code { get; set; }
        public string BemerkungenAdresse { get; set; }
        public string BemerkungenSv { get; set; }
        public bool BeruflicheMassnahmeIv { get; set; }
        public string Briefanrede { get; set; }
        public int? BsvbehinderungsartCode { get; set; }
        public bool Bvgrente { get; set; }
        public DateTime? CausweisDatum { get; set; }
        public int? KlientenkontoNr { get; set; }
        public int? DebitorNr { get; set; }
        public DateTime? DebitorUpdate { get; set; }
        public bool EigenerMietvertrag { get; set; }
        public decimal? Einrichtpauschale { get; set; }
        public int? EinrichtungspauschaleCode { get; set; }
        public bool ErgaenzungsLeistungen { get; set; }
        public bool Assistenzbeitrag { get; set; }
        public DateTime? DatumAssistenzbeitrag { get; set; }
        public int? IvVerfuegteAssistenzberatung { get; set; }
        public DateTime? DatumIvVerfuegung { get; set; }
        public DateTime? ErteilungVa { get; set; }
        public bool IstFamiliennachzug { get; set; }
        public string Fax { get; set; }
        public int? HauptBehinderungsartCode { get; set; }
        public bool HelbkeinAntrag { get; set; }
        public DateTime? Helbab { get; set; }
        public DateTime? Helbanmeldung { get; set; }
        public DateTime? Helbentscheid { get; set; }
        public int? HelbentscheidCode { get; set; }
        public int? HilfslosenEntschaedigungCode { get; set; }
        public DateTime? ImKantonSeit { get; set; }
        public bool ImKantonSeitGeburt { get; set; }
        public DateTime? InGemeindeSeit { get; set; }
        public int? IntensivPflegeZuschlagCode { get; set; }
        public int? IvberechtigungAnfangsStatusCode { get; set; }
        public DateTime? IvberechtigungErsterEntscheidAb { get; set; }
        public int? IvberechtigungErsterEntscheidCode { get; set; }
        public DateTime? IvberechtigungZweiterEntscheidAb { get; set; }
        public int? IvberechtigungZweiterEntscheidCode { get; set; }
        public int? Ivgrad { get; set; }
        public bool Ivhilfsmittel { get; set; }
        public bool Ivtaggeld { get; set; }
        public bool KeinSerienbrief { get; set; }
        public int? KonfessionCode { get; set; }
        public bool KontoFuehrung { get; set; }
        public int? BaPersonIdDossiertraeger { get; set; }
        public int? KopfquoteBaInstitutionId { get; set; }
        public DateTime? KopfquoteAbDatum { get; set; }
        public DateTime? KopfquoteBisDatum { get; set; }
        public int? KorrespondenzSpracheCode { get; set; }
        public bool Ktg { get; set; }
        public bool LaufendeVollmachtErlaubnis { get; set; }
        public bool ManuelleAnrede { get; set; }
        public bool MedizinischeMassnahmeIv { get; set; }
        public bool Mehrfachbehinderung { get; set; }
        public bool MietdepotPi { get; set; }
        public int? MigrationKa { get; set; }
        public string MobilTel { get; set; }
        public string NavigatorZusatz { get; set; }
        public bool? PassiveKopfQuote { get; set; }
        public DateTime? PauschaleAktualDatum { get; set; }
        public bool? PersonSichtbarSdflag { get; set; }
        public int? ProjNr { get; set; }
        public int? RentenstufeCode { get; set; }
        public bool SichtbarSdflag { get; set; }
        public bool Sozialhilfe { get; set; }
        public decimal? Sprachpauschale { get; set; }
        public bool Testperson { get; set; }
        public int? UntWohnsitzOrtCode { get; set; }
        public bool Uvgrente { get; set; }
        public bool Uvgtaggeld { get; set; }
        public int? VerstaendigungSprachCode { get; set; }
        public string Visdat36Area { get; set; }
        public string Visdat36Id { get; set; }
        public int? VormundMassnahmenCode { get; set; }
        public bool VormundPi { get; set; }
        public string WichtigerHinweis { get; set; }
        public bool WittwenWittwerWaisenrente { get; set; }
        public int? WohnstatusCode { get; set; }
        public bool? ZeigeDetails { get; set; }
        public bool ZeigeTelGeschaeft { get; set; }
        public bool ZeigeTelMobil { get; set; }
        public bool? ZeigeTelPrivat { get; set; }
        public string Zemisnummer { get; set; }
        public bool IstBerechnungsperson { get; set; }
        public DateTime? DatumAsylgesuch { get; set; }
        public DateTime? DatumEinbezugFaz { get; set; }
        public int? VerId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BaPersonTs { get; set; }

        public BaPerson BaPersonIdDossiertraegerNavigation { get; set; }
        public BaGemeinde HeimatgemeindeBaGemeinde { get; set; }
        public BaGemeinde HeimatgemeindeCodeNavigation { get; set; }
        public BaInstitution KopfquoteBaInstitution { get; set; }
        public BaLand NationalitaetCodeNavigation { get; set; }
        public BaLand UntWohnsitzLandCodeNavigation { get; set; }
        public BaLand WegzugLandCodeNavigation { get; set; }
        public BaGemeinde WegzugOrtCodeNavigation { get; set; }
        public BaLand ZuzugGdeLandCodeNavigation { get; set; }
        public BaGemeinde ZuzugGdeOrtCodeNavigation { get; set; }
        public BaLand ZuzugKtLandCodeNavigation { get; set; }
        public BaArbeitAusbildung BaArbeitAusbildung { get; set; }
        public GvDokumenteInformation GvDokumenteInformation { get; set; }
        public ICollection<BaAdresse> BaAdresse { get; set; }
        public ICollection<BaEinwohnerregisterPersonAnAbmeldung> BaEinwohnerregisterPersonAnAbmeldung { get; set; }
        public ICollection<BaEinwohnerregisterPersonStatus> BaEinwohnerregisterPersonStatus { get; set; }
        public ICollection<BaGesundheit> BaGesundheit { get; set; }
        public ICollection<BaInstitutionDokument> BaInstitutionDokument { get; set; }
        public ICollection<BaKopfquote> BaKopfquote { get; set; }
        public ICollection<BaMietvertrag> BaMietvertrag { get; set; }
        public ICollection<BaPersonBaInstitution> BaPersonBaInstitution { get; set; }
        public ICollection<BaPersonKantonalerZuschuss> BaPersonKantonalerZuschuss { get; set; }
        public ICollection<BaPersonRelation> BaPersonRelationBaPersonId1Navigation { get; set; }
        public ICollection<BaPersonRelation> BaPersonRelationBaPersonId2Navigation { get; set; }
        public ICollection<BaPraemienverbilligung> BaPraemienverbilligung { get; set; }
        public ICollection<BaWvcode> BaWvcode { get; set; }
        public ICollection<BaZahlungsweg> BaZahlungsweg { get; set; }
        public ICollection<Bdeleistung> Bdeleistung { get; set; }
        public ICollection<BfsdossierPerson> BfsdossierPerson { get; set; }
        public ICollection<BgAuszahlungPerson> BgAuszahlungPerson { get; set; }
        public ICollection<BgFinanzplanBaPerson> BgFinanzplanBaPerson { get; set; }
        public ICollection<BgPosition> BgPositionBaPerson { get; set; }
        public ICollection<BgPosition> BgPositionDebitorBaPerson { get; set; }
        public ICollection<BgSpezkonto> BgSpezkonto { get; set; }
        public ICollection<FaDokumentAblage> FaDokumentAblage { get; set; }
        public ICollection<FaDokumentAblageBaPerson> FaDokumentAblageBaPerson { get; set; }
        public ICollection<FaDokumente> FaDokumenteBaPersonIdAdressatNavigation { get; set; }
        public ICollection<FaDokumente> FaDokumenteBaPersonIdLtNavigation { get; set; }
        public ICollection<FaKategorisierung> FaKategorisierung { get; set; }
        public ICollection<FaLeistung> FaLeistungBaPerson { get; set; }
        public ICollection<FaLeistung> FaLeistungSchuldnerBaPerson { get; set; }
        public ICollection<FaWeisungBaPerson> FaWeisungBaPerson { get; set; }
        public ICollection<FbBelegNr> FbBelegNr { get; set; }
        public ICollection<FbBuchungCode> FbBuchungCode { get; set; }
        public ICollection<FbBuchungskreis> FbBuchungskreis { get; set; }
        public ICollection<FbDauerauftrag> FbDauerauftrag { get; set; }
        public ICollection<FbPeriode> FbPeriode { get; set; }
        public ICollection<GvDocument> GvDocument { get; set; }
        public ICollection<GvGesuch> GvGesuch { get; set; }
        public ICollection<IkEinkommen> IkEinkommen { get; set; }
        public ICollection<IkForderung> IkForderung { get; set; }
        public ICollection<IkGlaeubiger> IkGlaeubigerBaPerson { get; set; }
        public ICollection<IkGlaeubiger> IkGlaeubigerBaPersonIdAntragStellendePersonNavigation { get; set; }
        public ICollection<IkPosition> IkPosition { get; set; }
        public ICollection<IkRechtstitel> IkRechtstitel { get; set; }
        public ICollection<IkVerrechnungskonto> IkVerrechnungskonto { get; set; }
        public ICollection<BaPerson> InverseBaPersonIdDossiertraegerNavigation { get; set; }
        public ICollection<KaAmmBesch> KaAmmBesch { get; set; }
        public ICollection<KaArbeitsrapport> KaArbeitsrapport { get; set; }
        public ICollection<KaEinsatz> KaEinsatz { get; set; }
        public ICollection<KaExterneBildung> KaExterneBildung { get; set; }
        public ICollection<KaIntegBildung> KaIntegBildung { get; set; }
        public ICollection<KaSequenzen> KaSequenzen { get; set; }
        public ICollection<KaZuteilFachbereich> KaZuteilFachbereich { get; set; }
        public ICollection<KbBuchung> KbBuchung { get; set; }
        public ICollection<KbBuchungKostenart> KbBuchungKostenart { get; set; }
        public ICollection<KbKostenstelleBaPerson> KbKostenstelleBaPerson { get; set; }
        public ICollection<KbWveinzelposten> KbWveinzelposten { get; set; }
        public ICollection<KbWveinzelpostenFehler> KbWveinzelpostenFehler { get; set; }
        public ICollection<KbZahlungseingang> KbZahlungseingang { get; set; }
        public ICollection<KesAuftragBaPerson> KesAuftragBaPerson { get; set; }
        public ICollection<KesDokument> KesDokument { get; set; }
        public ICollection<KesVerlauf> KesVerlauf { get; set; }
        public ICollection<ServiceProcessError> ServiceProcessError { get; set; }
        public ICollection<ShEinzelzahlung> ShEinzelzahlung { get; set; }
        public ICollection<VmMandant> VmMandant { get; set; }
        public ICollection<VmSachversicherung> VmSachversicherung { get; set; }
        public ICollection<VmSozialversicherung> VmSozialversicherung { get; set; }
        public ICollection<WhAsvseintrag> WhAsvseintrag { get; set; }
        public ICollection<Xtask> Xtask { get; set; }
        public int Id => BaPersonId;
        public byte[] RowVersion => BaPersonTs;
    }
}