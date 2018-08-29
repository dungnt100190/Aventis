namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwPerson")]
    public partial class vwPerson
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaPersonID { get; set; }

        [StringLength(50)]
        public string Titel { get; set; }

        [Key]
        [Column(Order = 1)]
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
        public string ZEMISNummer { get; set; }

        [StringLength(20)]
        public string BFFNummer { get; set; }

        public DateTime? ErteilungVA { get; set; }

        public int? GeschlechtCode { get; set; }

        public int? KonfessionCode { get; set; }

        public int? ZivilstandCode { get; set; }

        public DateTime? ZivilstandDatum { get; set; }

        public int? HeimatgemeindeCode { get; set; }

        [StringLength(255)]
        public string HeimatgemeindeCodes { get; set; }

        public int? HeimatgemeindeBaGemeindeID { get; set; }

        public int? NationalitaetCode { get; set; }

        public int? AuslaenderStatusCode { get; set; }

        public DateTime? AuslaenderStatusGueltigBis { get; set; }

        public DateTime? InGemeindeSeit { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool InCHSeitGeburt { get; set; }

        public DateTime? ImKantonSeit { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool ImKantonSeitGeburt { get; set; }

        [StringLength(100)]
        public string Telefon_P { get; set; }

        [StringLength(100)]
        public string Telefon_G { get; set; }

        [StringLength(100)]
        public string MobilTel { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        public int? SprachCode { get; set; }

        public bool? Unterstuetzt { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool Fiktiv { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool Testperson { get; set; }

        [StringLength(30)]
        public string NavigatorZusatz { get; set; }

        public string Bemerkung { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaPersonTS { get; set; }

        public int? VerID { get; set; }

        [StringLength(10)]
        public string ZuzugKtPLZ { get; set; }

        [StringLength(50)]
        public string ZuzugKtOrt { get; set; }

        [StringLength(10)]
        public string ZuzugKtKanton { get; set; }

        public int? ZuzugKtOrtCode { get; set; }

        public int? ZuzugKtLandCode { get; set; }

        public DateTime? ZuzugKtDatum { get; set; }

        public bool? ZuzugKtSeitGeburt { get; set; }

        [StringLength(10)]
        public string ZuzugGdePLZ { get; set; }

        [StringLength(50)]
        public string ZuzugGdeOrt { get; set; }

        [StringLength(10)]
        public string ZuzugGdeKanton { get; set; }

        public int? ZuzugGdeOrtCode { get; set; }

        public int? ZuzugGdeLandCode { get; set; }

        public DateTime? ZuzugGdeDatum { get; set; }

        public bool? ZuzugGdeSeitGeburt { get; set; }

        [StringLength(10)]
        public string UntWohnsitzPLZ { get; set; }

        [StringLength(50)]
        public string UntWohnsitzOrt { get; set; }

        [StringLength(10)]
        public string UntWohnsitzKanton { get; set; }

        public int? UntWohnsitzOrtCode { get; set; }

        public int? UntWohnsitzLandCode { get; set; }

        [StringLength(10)]
        public string WegzugPLZ { get; set; }

        [StringLength(50)]
        public string WegzugOrt { get; set; }

        [StringLength(10)]
        public string WegzugKanton { get; set; }

        public int? WegzugOrtCode { get; set; }

        public int? WegzugLandCode { get; set; }

        public DateTime? WegzugDatum { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool KeinSerienbrief { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string Creator { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime Created { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(50)]
        public string Modifier { get; set; }

        [Key]
        [Column(Order = 11)]
        public DateTime Modified { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(202)]
        public string NameVorname { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(201)]
        public string VornameName { get; set; }

        public int? Alter { get; set; }

        public int? AlterMortal { get; set; }

        [StringLength(200)]
        public string Nationalitaet { get; set; }

        [StringLength(200)]
        public string NationalitaetFR { get; set; }

        [StringLength(200)]
        public string NationalitaetIT { get; set; }

        [StringLength(103)]
        public string Heimatort { get; set; }

        public int? WohnsitzBaAdresseID { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(633)]
        public string Wohnsitz { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(633)]
        public string WohnsitzMehrzeilig { get; set; }

        [StringLength(200)]
        public string WohnsitzAdressZusatz { get; set; }

        [StringLength(100)]
        public string WohnsitzStrasse { get; set; }

        [StringLength(10)]
        public string WohnsitzHausNr { get; set; }

        [StringLength(111)]
        public string WohnsitzStrasseHausNr { get; set; }

        [StringLength(100)]
        public string WohnsitzPostfach { get; set; }

        public bool? WohnsitzPostfachOhneNr { get; set; }

        [StringLength(255)]
        public string WohnsitzPostfachD { get; set; }

        [StringLength(10)]
        public string WohnsitzPLZ { get; set; }

        [StringLength(50)]
        public string WohnsitzOrt { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(61)]
        public string WohnsitzPLZOrt { get; set; }

        [StringLength(10)]
        public string WohnsitzKanton { get; set; }

        [StringLength(200)]
        public string WohnsitzLand { get; set; }

        public int? WohnsitzOrtschaftCode { get; set; }

        public int? WohnsitzBaLandID { get; set; }

        public string WohnsitzBemerkung { get; set; }

        public int? WohnsitzWohnStatusCode { get; set; }

        public int? WohnsitzWohnungsgroesseCode { get; set; }

        public int? AufenthaltBaAdresseID { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(835)]
        public string Aufenthalt { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(835)]
        public string AufenthaltMehrzeilig { get; set; }

        [StringLength(200)]
        public string AufenthaltAdressZusatz { get; set; }

        [StringLength(100)]
        public string AufenthaltStrasse { get; set; }

        [StringLength(10)]
        public string AufenthaltHausNr { get; set; }

        [StringLength(111)]
        public string AufenthaltStrasseHausNr { get; set; }

        [StringLength(100)]
        public string AufenthaltPostfach { get; set; }

        public bool? AufenthaltPostfachOhneNr { get; set; }

        [StringLength(255)]
        public string AufenthaltPostfachD { get; set; }

        [StringLength(10)]
        public string AufenthaltPLZ { get; set; }

        [StringLength(50)]
        public string AufenthaltOrt { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(61)]
        public string AufenthaltPLZOrt { get; set; }

        [StringLength(10)]
        public string AufenthaltKanton { get; set; }

        [StringLength(200)]
        public string AufenthaltLand { get; set; }

        public int? AufenthaltOrtschaftCode { get; set; }

        public int? AufenthaltBaLandID { get; set; }

        public string AufenthaltBemerkung { get; set; }

        public int? AufenthaltWohnStatusCode { get; set; }

        public int? AufenthaltWohnungsgroesseCode { get; set; }

        public int? AufenthaltBaInstitutionID { get; set; }

        [StringLength(200)]
        public string AufenthaltInstitutionName { get; set; }

        [Key]
        [Column(Order = 20)]
        public bool SichtbarSDFlag { get; set; }

        [Key]
        [Column(Order = 21)]
        public bool PersonSichtbarSDFlag { get; set; }

        public int? VerstaendigungSprachCode { get; set; }

        public DateTime? InCHseit { get; set; }

        public DateTime? CAusweisDatum { get; set; }

        [Key]
        [Column(Order = 22)]
        [StringLength(8)]
        public string Anrede { get; set; }
    }
}
