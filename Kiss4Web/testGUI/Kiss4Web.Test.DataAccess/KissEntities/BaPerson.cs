namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaPerson")]
    public partial class BaPerson : IEntity, IAuditableEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaPerson()
        {
            BaAdresses = new HashSet<BaAdresse>();
            BaEinwohnerregisterPersonStatus = new HashSet<BaEinwohnerregisterPersonStatu>();
            BaGesundheits = new HashSet<BaGesundheit>();
            BaInstitutionDokuments = new HashSet<BaInstitutionDokument>();
            BaKopfquotes = new HashSet<BaKopfquote>();
            BaMietvertrags = new HashSet<BaMietvertrag>();
            BaPerson_BaInstitution = new HashSet<BaPersonBaInstitution>();
            BaPerson1 = new HashSet<BaPerson>();
            BaPerson_KantonalerZuschuss = new HashSet<BaPerson_KantonalerZuschuss>();
            BaPerson_NewodPerson = new HashSet<BaPerson_NewodPerson>();
            BaPerson_Relation = new HashSet<BaPerson_Relation>();
            BaPerson_Relation1 = new HashSet<BaPerson_Relation>();
            BaPraemienverbilligungs = new HashSet<BaPraemienverbilligung>();
            BaWVCodes = new HashSet<BaWVCode>();
            BaZahlungswegs = new HashSet<BaZahlungsweg>();
            BDELeistungs = new HashSet<BDELeistung>();
            BFSDossierPersons = new HashSet<BFSDossierPerson>();
            BgAuszahlungPersons = new HashSet<BgAuszahlungPerson>();
            BgFinanzplan_BaPerson = new HashSet<BgFinanzplan_BaPerson>();
            BgPositions = new HashSet<BgPosition>();
            BgPositions1 = new HashSet<BgPosition>();
            BgSpezkontoes = new HashSet<BgSpezkonto>();
            FaDokumentAblages = new HashSet<FaDokumentAblage>();
            FaDokumentAblage_BaPerson = new HashSet<FaDokumentAblageBaPerson>();
            FaDokumentes = new HashSet<FaDokumente>();
            FaDokumentes1 = new HashSet<FaDokumente>();
            FaKategorisierungs = new HashSet<FaKategorisierung>();
            FaLeistungs = new HashSet<FaLeistung>();
            FaLeistungs1 = new HashSet<FaLeistung>();
            FaWeisung_BaPerson = new HashSet<FaWeisung_BaPerson>();
            FbBelegNrs = new HashSet<FbBelegNr>();
            FbBuchungCodes = new HashSet<FbBuchungCode>();
            FbBuchungskreis = new HashSet<FbBuchungskrei>();
            FbDauerauftrags = new HashSet<FbDauerauftrag>();
            FbPeriodes = new HashSet<FbPeriode>();
            GvDocuments = new HashSet<GvDocument>();
            GvDokumenteInformations = new HashSet<GvDokumenteInformation>();
            GvGesuches = new HashSet<GvGesuch>();
            IkEinkommen = new HashSet<IkEinkomman>();
            IkForderungs = new HashSet<IkForderung>();
            IkGlaeubigers = new HashSet<IkGlaeubiger>();
            IkGlaeubigers1 = new HashSet<IkGlaeubiger>();
            IkPositions = new HashSet<IkPosition>();
            IkRechtstitels = new HashSet<IkRechtstitel>();
            IkVerrechnungskontoes = new HashSet<IkVerrechnungskonto>();
            KaAmmBesches = new HashSet<KaAmmBesch>();
            KaArbeitsrapports = new HashSet<KaArbeitsrapport>();
            KaEinsatzs = new HashSet<KaEinsatz>();
            KaExterneBildungs = new HashSet<KaExterneBildung>();
            KaIntegBildungs = new HashSet<KaIntegBildung>();
            KaSequenzens = new HashSet<KaSequenzen>();
            KaZuteilFachbereiches = new HashSet<KaZuteilFachbereich>();
            KbBuchungs = new HashSet<KbBuchung>();
            KbBuchungKostenarts = new HashSet<KbBuchungKostenart>();
            KbKostenstelle_BaPerson = new HashSet<KbKostenstelle_BaPerson>();
            KbWVEinzelpostens = new HashSet<KbWVEinzelposten>();
            KbWVEinzelpostenFehlers = new HashSet<KbWVEinzelpostenFehler>();
            KbZahlungseingangs = new HashSet<KbZahlungseingang>();
            KesAuftrag_BaPerson = new HashSet<KesAuftrag_BaPerson>();
            KesDokuments = new HashSet<KesDokument>();
            KesVerlaufs = new HashSet<KesVerlauf>();
            ShEinzelzahlungs = new HashSet<ShEinzelzahlung>();
            VmMandants = new HashSet<VmMandant>();
            VmSachversicherungs = new HashSet<VmSachversicherung>();
            VmSozialversicherungs = new HashSet<VmSozialversicherung>();
            WhASVSEintrags = new HashSet<WhASVSEintrag>();
            XTasks = new HashSet<XTask>();
        }

        public int BaPersonID { get; set; }

        public int? StatusPersonCode { get; set; }

        [StringLength(50)]
        public string Titel { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string FruehererName { get; set; }

        [StringLength(100)]
        public string Vorname { get; set; }

        [StringLength(100)]
        public string Vorname2 { get; set; }

        public DateTime? Geburtsdatum { get; set; }

        public DateTime? Sterbedatum { get; set; }

        [StringLength(16)]
        public string AHVNummer { get; set; }

        [StringLength(18)]
        public string Versichertennummer { get; set; }

        [StringLength(18)]
        public string HaushaltVersicherungsNummer { get; set; }

        [StringLength(20)]
        public string NNummer { get; set; }

        [StringLength(20)]
        public string BFFNummer { get; set; }

        [StringLength(20)]
        public string ZARNummer { get; set; }

        public int? ZIPNr { get; set; }

        [StringLength(50)]
        public string KantonaleReferenznummer { get; set; }

        public int? GeschlechtCode { get; set; }

        public int? ZivilstandCode { get; set; }

        public DateTime? ZivilstandDatum { get; set; }

        public int? HeimatgemeindeCode { get; set; }

        [StringLength(255)]
        public string HeimatgemeindeCodes { get; set; }

        public int? NationalitaetCode { get; set; }

        public int? ReligionCode { get; set; }

        public int? AuslaenderStatusCode { get; set; }

        public DateTime? AuslaenderStatusGueltigBis { get; set; }

        [StringLength(100)]
        public string Telefon_P { get; set; }

        [StringLength(100)]
        public string Telefon_G { get; set; }

        [StringLength(100)]
        public string MobilTel1 { get; set; }

        [StringLength(100)]
        public string MobilTel2 { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        public int? SprachCode { get; set; }

        public bool? Unterstuetzt { get; set; }

        public bool Fiktiv { get; set; }

        public string Bemerkung { get; set; }

        public bool EinwohnerregisterAktiv { get; set; }

        [StringLength(50)]
        public string EinwohnerregisterID { get; set; }

        public int? DeutschVerstehenCode { get; set; }

        public int? WichtigerHinweisCode { get; set; }

        [StringLength(10)]
        public string ZuzugKtPLZ { get; set; }

        public int? ZuzugKtOrtCode { get; set; }

        [StringLength(50)]
        public string ZuzugKtOrt { get; set; }

        [StringLength(10)]
        public string ZuzugKtKanton { get; set; }

        public int? ZuzugKtLandCode { get; set; }

        public DateTime? ZuzugKtDatum { get; set; }

        public bool? ZuzugKtSeitGeburt { get; set; }

        [StringLength(10)]
        public string ZuzugGdePLZ { get; set; }

        public int? ZuzugGdeOrtCode { get; set; }

        [StringLength(50)]
        public string ZuzugGdeOrt { get; set; }

        [StringLength(10)]
        public string ZuzugGdeKanton { get; set; }

        public int? ZuzugGdeLandCode { get; set; }

        public DateTime? ZuzugGdeDatum { get; set; }

        public bool? ZuzugGdeSeitGeburt { get; set; }

        [StringLength(10)]
        public string UntWohnsitzPLZ { get; set; }

        [StringLength(50)]
        public string UntWohnsitzOrt { get; set; }

        [StringLength(10)]
        public string UntWohnsitzKanton { get; set; }

        public int? UntWohnsitzLandCode { get; set; }

        [StringLength(10)]
        public string WegzugPLZ { get; set; }

        public int? WegzugOrtCode { get; set; }

        [StringLength(50)]
        public string WegzugOrt { get; set; }

        [StringLength(10)]
        public string WegzugKanton { get; set; }

        public int? WegzugLandCode { get; set; }

        public DateTime? WegzugDatum { get; set; }

        public int? WohnsitzWieBaPersonID { get; set; }

        public int? AufenthaltWieBaInstitutionID { get; set; }

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

        public int? KbKostenstelleID { get; set; }

        public DateTime? InCHSeit { get; set; }

        public bool InCHSeitGeburt { get; set; }

        public int? PUAnzahlVerlustscheine { get; set; }

        [StringLength(50)]
        public string PUKrankenkasse { get; set; }

        public DateTime? PraemienuebernahmeVon { get; set; }

        public DateTime? PraemienuebernahmeBis { get; set; }

        public bool PersonOhneLeistung { get; set; }

        public bool HCMCFluechtling { get; set; }

        public int? StellensuchendCode { get; set; }

        public int? ResoNr { get; set; }

        public DateTime? NEAnmeldung { get; set; }

        public int? HeimatgemeindeBaGemeindeID { get; set; }

        public bool? AktiveKopfQuote { get; set; }

        public bool ALK { get; set; }

        public string AndereSVLeistungen { get; set; }

        [StringLength(100)]
        public string Anrede { get; set; }

        public int? AusbildungCode { get; set; }

        public int? Behinderungsart2Code { get; set; }

        public string BemerkungenAdresse { get; set; }

        public string BemerkungenSV { get; set; }

        public bool BeruflicheMassnahmeIV { get; set; }

        [StringLength(100)]
        public string Briefanrede { get; set; }

        public int? BSVBehinderungsartCode { get; set; }

        public bool BVGRente { get; set; }

        public DateTime? CAusweisDatum { get; set; }

        public int? KlientenkontoNr { get; set; }

        public int? DebitorNr { get; set; }

        public DateTime? DebitorUpdate { get; set; }

        public bool EigenerMietvertrag { get; set; }

        [Column(TypeName = "money")]
        public decimal? Einrichtpauschale { get; set; }

        public int? EinrichtungspauschaleCode { get; set; }

        public bool ErgaenzungsLeistungen { get; set; }

        public bool Assistenzbeitrag { get; set; }

        public DateTime? DatumAssistenzbeitrag { get; set; }

        public int? IvVerfuegteAssistenzberatung { get; set; }

        public DateTime? DatumIvVerfuegung { get; set; }

        public DateTime? ErteilungVA { get; set; }

        public bool IstFamiliennachzug { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        public int? HauptBehinderungsartCode { get; set; }

        public bool HELBKeinAntrag { get; set; }

        public DateTime? HELBAb { get; set; }

        public DateTime? HELBAnmeldung { get; set; }

        public DateTime? HELBEntscheid { get; set; }

        public int? HELBEntscheidCode { get; set; }

        public int? HilfslosenEntschaedigungCode { get; set; }

        public DateTime? ImKantonSeit { get; set; }

        public bool ImKantonSeitGeburt { get; set; }

        public DateTime? InGemeindeSeit { get; set; }

        public int? IntensivPflegeZuschlagCode { get; set; }

        public int? IVBerechtigungAnfangsStatusCode { get; set; }

        public DateTime? IVBerechtigungErsterEntscheidAb { get; set; }

        public int? IVBerechtigungErsterEntscheidCode { get; set; }

        public DateTime? IVBerechtigungZweiterEntscheidAb { get; set; }

        public int? IVBerechtigungZweiterEntscheidCode { get; set; }

        public int? IVGrad { get; set; }

        public bool IVHilfsmittel { get; set; }

        public bool IVTaggeld { get; set; }

        public bool KeinSerienbrief { get; set; }

        public int? KonfessionCode { get; set; }

        public bool KontoFuehrung { get; set; }

        public int? BaPersonID_Dossiertraeger { get; set; }

        public int? Kopfquote_BaInstitutionID { get; set; }

        public DateTime? KopfquoteAbDatum { get; set; }

        public DateTime? KopfquoteBisDatum { get; set; }

        public int? KorrespondenzSpracheCode { get; set; }

        public bool KTG { get; set; }

        public bool LaufendeVollmachtErlaubnis { get; set; }

        public bool ManuelleAnrede { get; set; }

        public bool MedizinischeMassnahmeIV { get; set; }

        public bool Mehrfachbehinderung { get; set; }

        public bool MietdepotPI { get; set; }

        public int? MigrationKA { get; set; }

        [StringLength(100)]
        public string MobilTel { get; set; }

        [StringLength(30)]
        public string NavigatorZusatz { get; set; }

        public bool? PassiveKopfQuote { get; set; }

        public DateTime? PauschaleAktualDatum { get; set; }

        public bool PersonSichtbarSDFlag { get; set; }

        public int? ProjNr { get; set; }

        public int? RentenstufeCode { get; set; }

        public bool SichtbarSDFlag { get; set; }

        public bool Sozialhilfe { get; set; }

        [Column(TypeName = "money")]
        public decimal? Sprachpauschale { get; set; }

        public bool Testperson { get; set; }

        public int? UntWohnsitzOrtCode { get; set; }

        public bool UVGRente { get; set; }

        public bool UVGTaggeld { get; set; }

        public int? VerstaendigungSprachCode { get; set; }

        [StringLength(255)]
        public string visdat36Area { get; set; }

        [StringLength(6)]
        public string visdat36ID { get; set; }

        public int? VormundMassnahmenCode { get; set; }

        public bool VormundPI { get; set; }

        [StringLength(1000)]
        public string WichtigerHinweis { get; set; }

        public bool WittwenWittwerWaisenrente { get; set; }

        public int? WohnstatusCode { get; set; }

        public bool ZeigeDetails { get; set; }

        public bool ZeigeTelGeschaeft { get; set; }

        public bool ZeigeTelMobil { get; set; }

        public bool ZeigeTelPrivat { get; set; }

        [StringLength(20)]
        public string ZEMISNummer { get; set; }

        public bool IstBerechnungsperson { get; set; }

        public DateTime? DatumAsylgesuch { get; set; }

        public DateTime? DatumEinbezugFaz { get; set; }

        public int? VerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaPersonTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaAdresse> BaAdresses { get; set; }

        public virtual BaArbeitAusbildung BaArbeitAusbildung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaEinwohnerregisterPersonStatu> BaEinwohnerregisterPersonStatus { get; set; }

        public virtual BaGemeinde BaGemeinde { get; set; }

        public virtual BaGemeinde BaGemeinde1 { get; set; }

        public virtual BaGemeinde BaGemeinde2 { get; set; }

        public virtual BaGemeinde BaGemeinde3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaGesundheit> BaGesundheits { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaInstitutionDokument> BaInstitutionDokuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaKopfquote> BaKopfquotes { get; set; }

        public virtual BaLand BaLand { get; set; }

        public virtual BaLand BaLand1 { get; set; }

        public virtual BaLand BaLand2 { get; set; }

        public virtual BaLand BaLand3 { get; set; }

        public virtual BaLand BaLand4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaMietvertrag> BaMietvertrags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPersonBaInstitution> BaPerson_BaInstitution { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson> BaPerson1 { get; set; }

        public virtual BaPerson BaPerson2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson_KantonalerZuschuss> BaPerson_KantonalerZuschuss { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson_NewodPerson> BaPerson_NewodPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson_Relation> BaPerson_Relation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson_Relation> BaPerson_Relation1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPraemienverbilligung> BaPraemienverbilligungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaWVCode> BaWVCodes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaZahlungsweg> BaZahlungswegs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDELeistung> BDELeistungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BFSDossierPerson> BFSDossierPersons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgAuszahlungPerson> BgAuszahlungPersons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgFinanzplan_BaPerson> BgFinanzplan_BaPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgPosition> BgPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgPosition> BgPositions1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgSpezkonto> BgSpezkontoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaDokumentAblage> FaDokumentAblages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaDokumentAblageBaPerson> FaDokumentAblage_BaPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaDokumente> FaDokumentes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaDokumente> FaDokumentes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaKategorisierung> FaKategorisierungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaLeistung> FaLeistungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaLeistung> FaLeistungs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaWeisung_BaPerson> FaWeisung_BaPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbBelegNr> FbBelegNrs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbBuchungCode> FbBuchungCodes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbBuchungskrei> FbBuchungskreis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbDauerauftrag> FbDauerauftrags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbPeriode> FbPeriodes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvDocument> GvDocuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvDokumenteInformation> GvDokumenteInformations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvGesuch> GvGesuches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkEinkomman> IkEinkommen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkForderung> IkForderungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkGlaeubiger> IkGlaeubigers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkGlaeubiger> IkGlaeubigers1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkPosition> IkPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkRechtstitel> IkRechtstitels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkVerrechnungskonto> IkVerrechnungskontoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaAmmBesch> KaAmmBesches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaArbeitsrapport> KaArbeitsrapports { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaEinsatz> KaEinsatzs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaExterneBildung> KaExterneBildungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaIntegBildung> KaIntegBildungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaSequenzen> KaSequenzens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaZuteilFachbereich> KaZuteilFachbereiches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchungKostenart> KbBuchungKostenarts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbKostenstelle_BaPerson> KbKostenstelle_BaPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbWVEinzelposten> KbWVEinzelpostens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbWVEinzelpostenFehler> KbWVEinzelpostenFehlers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbZahlungseingang> KbZahlungseingangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesAuftrag_BaPerson> KesAuftrag_BaPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesDokument> KesDokuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesVerlauf> KesVerlaufs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShEinzelzahlung> ShEinzelzahlungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmMandant> VmMandants { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmSachversicherung> VmSachversicherungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmSozialversicherung> VmSozialversicherungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WhASVSEintrag> WhASVSEintrags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XTask> XTasks { get; set; }

        public int Id => BaPersonID;

        public byte[] RowVersion => BaPersonTS;
    }
}
