namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hist_BaPerson
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        public bool? EinwohnerregisterAktiv { get; set; }

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

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        public int? VerID_DELETED { get; set; }
    }
}
