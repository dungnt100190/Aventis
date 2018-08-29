namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmPerson")]
    public partial class vwTmPerson
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaPersonID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonenNr { get; set; }

        [StringLength(50)]
        public string Anrede { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string FrühererName { get; set; }

        [StringLength(100)]
        public string Vorname { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(201)]
        public string VornameName { get; set; }

        [StringLength(100)]
        public string Vorname2 { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(202)]
        public string NameVorname { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(201)]
        public string NameVornameOhneKomma { get; set; }

        [StringLength(100)]
        public string NameGB { get; set; }

        [StringLength(202)]
        public string NameGBVorname { get; set; }

        [StringLength(201)]
        public string NameGBVornameOhneKomma { get; set; }

        [StringLength(200)]
        public string Nationalitaet { get; set; }

        public int? GeschlechtCode { get; set; }

        [StringLength(200)]
        public string Geschlecht { get; set; }

        [StringLength(30)]
        public string Geburtsdatum { get; set; }

        [StringLength(30)]
        public string GeburtsdatumAmerikanisch { get; set; }

        [StringLength(30)]
        public string GestorbenAm { get; set; }

        [StringLength(16)]
        public string AHVNummer { get; set; }

        [StringLength(18)]
        public string Versichertennummer { get; set; }

        [StringLength(18)]
        public string VersichertennummerSonstAHVNr { get; set; }

        public string BemerkungOhneFmt { get; set; }

        public string BemerkungMitFmt { get; set; }

        [StringLength(20)]
        public string NNummer { get; set; }

        [StringLength(20)]
        public string BFFNummer { get; set; }

        [StringLength(18)]
        public string HaushaltVersicherungsNummer { get; set; }

        [StringLength(200)]
        public string Konfession { get; set; }

        [StringLength(103)]
        public string Heimatort { get; set; }

        [StringLength(200)]
        public string HeimatortNationalitaet { get; set; }

        [StringLength(200)]
        public string HeimatortNationalitaetD { get; set; }

        [StringLength(200)]
        public string HeimatortNationalitaetF { get; set; }

        [StringLength(200)]
        public string HeimatortNationalitaetI { get; set; }

        [StringLength(131)]
        public string PLZHeimatort { get; set; }

        [StringLength(200)]
        public string Sprache { get; set; }

        [StringLength(200)]
        public string SpracheVertsaendigung { get; set; }

        [StringLength(200)]
        public string Permis { get; set; }

        [StringLength(30)]
        public string PermisBis { get; set; }

        [StringLength(30)]
        public string PermisSeit { get; set; }

        [StringLength(30)]
        public string AufenthaltGueltigBis { get; set; }

        [StringLength(30)]
        public string InCHseit { get; set; }

        [StringLength(30)]
        public string EndeZustaendigkeit { get; set; }

        [StringLength(100)]
        public string TelefonP { get; set; }

        [StringLength(100)]
        public string TelefonG { get; set; }

        [StringLength(100)]
        public string TelefonMobil { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(30)]
        public string Navigatorzusatz { get; set; }

        public DateTime? WegzugDatum { get; set; }

        [StringLength(50)]
        public string WegzugOrt { get; set; }

        [StringLength(10)]
        public string WegzugPLZ { get; set; }

        [StringLength(200)]
        public string Zivilstand { get; set; }

        [StringLength(2000)]
        public string ZivilstandD { get; set; }

        [StringLength(2000)]
        public string ZivilstandF { get; set; }

        [StringLength(2000)]
        public string ZivilstandI { get; set; }

        [StringLength(30)]
        public string ZivilstandSeit { get; set; }

        public DateTime? ZuzugDatum { get; set; }

        [StringLength(50)]
        public string ZuzugOrt { get; set; }

        [StringLength(10)]
        public string ZuzugPLZ { get; set; }

        [StringLength(20)]
        public string ZEMISNummer { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(8)]
        public string ErSie { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(8)]
        public string ErSieGross { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(4)]
        public string HerrFrau { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(105)]
        public string HerrFrauName { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(25)]
        public string GeehrterHerrFrau { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(126)]
        public string GeehrterHerrFrauName { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(5)]
        public string HerrnFrau { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(106)]
        public string HerrnFrauName { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(206)]
        public string FrauHerrVornameName { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(9)]
        public string IhmIhr { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(14)]
        public string LieberLiebe { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(10)]
        public string SeinIhr { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(12)]
        public string SeineIhre { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(14)]
        public string SeinerIhrer { get; set; }

        [Key]
        [Column(Order = 20)]
        [StringLength(34)]
        public string ProjektteilnehmerIn { get; set; }

        [Key]
        [Column(Order = 21)]
        [StringLength(33)]
        public string TeilnehmerIn { get; set; }

        [StringLength(836)]
        public string AufenthaltsortAdresseEinzeilig { get; set; }

        [Key]
        [Column(Order = 22)]
        [StringLength(633)]
        public string AufenthaltsortAdresseEinzOhneName { get; set; }

        [StringLength(836)]
        public string AufenthaltsortAdresseMehrzeilig { get; set; }

        [Key]
        [Column(Order = 23)]
        [StringLength(633)]
        public string AufenthaltsortAdresseMehrzOhneName { get; set; }

        [StringLength(111)]
        public string AufenthaltsortStrasseNr { get; set; }

        [Key]
        [Column(Order = 24)]
        [StringLength(61)]
        public string AufenthaltsortPLZOrt { get; set; }

        [StringLength(836)]
        public string AufenthaltWohnortAdrEinzeilig { get; set; }

        [Key]
        [Column(Order = 25)]
        [StringLength(633)]
        public string AufenthaltWohnortAdrEinzOhneName { get; set; }

        [StringLength(836)]
        public string AufenthaltWohnortAdrMehrzeilig { get; set; }

        [Key]
        [Column(Order = 26)]
        [StringLength(633)]
        public string AufenthaltWohnortAdrMehrzOhneName { get; set; }

        [StringLength(111)]
        public string AufenthaltWohnsitzStrasseNr { get; set; }

        [Key]
        [Column(Order = 27)]
        [StringLength(61)]
        public string AufenthaltWohnsitzPLZOrt { get; set; }

        [StringLength(10)]
        public string AufenthaltWohnsitzPLZ { get; set; }

        [StringLength(50)]
        public string AufenthaltWohnsitzOrt { get; set; }

        [StringLength(255)]
        public string AufenthaltPostfachD { get; set; }

        [StringLength(255)]
        public string AufenthaltPostfachF { get; set; }

        [StringLength(255)]
        public string AufenthaltPostfachI { get; set; }

        [StringLength(200)]
        public string AufenthaltInstitutionName { get; set; }

        [StringLength(836)]
        public string WohnsitzAdresseEinzeilig { get; set; }

        [StringLength(836)]
        public string WohnsitzAdresseEinzeiligGB { get; set; }

        [Key]
        [Column(Order = 28)]
        [StringLength(633)]
        public string WohnsitzAdresseEinzOhneName { get; set; }

        [StringLength(836)]
        public string WohnsitzAdresseMehrzeilig { get; set; }

        [Key]
        [Column(Order = 29)]
        [StringLength(633)]
        public string WohnsitzAdresseMehrzOhneName { get; set; }

        [StringLength(111)]
        public string WohnsitzStrasseNr { get; set; }

        [Key]
        [Column(Order = 30)]
        [StringLength(61)]
        public string WohnsitzPLZOrt { get; set; }

        [StringLength(50)]
        public string WohnsitzOrt { get; set; }

        [StringLength(10)]
        public string WohnsitzPLZ { get; set; }

        [StringLength(255)]
        public string WohnsitzPostfachD { get; set; }

        [StringLength(255)]
        public string WohnsitzPostfachF { get; set; }

        [StringLength(255)]
        public string WohnsitzPostfachI { get; set; }

        [StringLength(200)]
        public string Wohnsituation { get; set; }

        [StringLength(200)]
        public string Wohnungsgroesse { get; set; }

        [StringLength(30)]
        public string ArbeitslosSeit { get; set; }

        [StringLength(30)]
        public string AusgesteuertSeit { get; set; }

        [StringLength(200)]
        public string Beruf { get; set; }

        [StringLength(200)]
        public string ErlernterBeruf { get; set; }

        [StringLength(200)]
        public string Schulbildung { get; set; }

        [StringLength(500)]
        public string VermieterName { get; set; }

        [Key]
        [Column(Order = 31)]
        [StringLength(376)]
        public string VermieterAdresseEinzOhneName { get; set; }

        [Key]
        [Column(Order = 32)]
        [StringLength(376)]
        public string VermieterAdresseMehrzOhneName { get; set; }

        [StringLength(111)]
        public string VermieterAdresseStrasseNr { get; set; }

        [Key]
        [Column(Order = 33)]
        [StringLength(61)]
        public string VermieterAdressePLZOrt { get; set; }

        [StringLength(10)]
        public string VermieterAdressePLZ { get; set; }

        [StringLength(50)]
        public string VermieterAdresseOrt { get; set; }

        [StringLength(500)]
        public string KVGName { get; set; }

        [StringLength(50)]
        public string KVGMitgliedNr { get; set; }

        [Key]
        [Column(Order = 34)]
        [StringLength(376)]
        public string KVGAdresseEinzOhneName { get; set; }

        [StringLength(500)]
        public string VVGName { get; set; }

        [StringLength(50)]
        public string VVGMitgliedNr { get; set; }

        [Key]
        [Column(Order = 35)]
        [StringLength(376)]
        public string VVGAdresseEinzOhneName { get; set; }

        [StringLength(100)]
        public string EhepartnerNachname { get; set; }

        [StringLength(100)]
        public string EhepartnerVorname { get; set; }

        [StringLength(100)]
        public string EhepartnerVorname2 { get; set; }

        [StringLength(201)]
        public string EhepartnerNachnameVorname { get; set; }

        [StringLength(20)]
        public string EhepartnerNNummer { get; set; }

        [StringLength(20)]
        public string EhepartnerBFFNummer { get; set; }

        [StringLength(30)]
        public string EhepartnerInCHseit { get; set; }

        [StringLength(200)]
        public string EhepartnerNationalitaet { get; set; }

        [StringLength(200)]
        public string EhepartnerZivilstand { get; set; }

        [StringLength(200)]
        public string EhepartnerBeruf { get; set; }

        [StringLength(30)]
        public string EhepartnerEndeZustaendigkeit { get; set; }

        [StringLength(30)]
        public string EhepartnerErteilungVA { get; set; }

        [StringLength(200)]
        public string EhepartnerGeschlecht { get; set; }

        [StringLength(200)]
        public string EhepartnerPermis { get; set; }

        public int? EhepartnerPersonenNummer { get; set; }

        [StringLength(30)]
        public string EhepartnerGebDatum { get; set; }

        [StringLength(16)]
        public string EhepartnerAHVNummer { get; set; }

        [StringLength(18)]
        public string EhepartnerVersichertennummer { get; set; }

        [StringLength(50)]
        public string EhepartnerAnrede { get; set; }

        [Key]
        [Column(Order = 36)]
        [StringLength(61)]
        public string EhepartnerPLZOrt { get; set; }

        [StringLength(111)]
        public string EhepartnerStrasseNr { get; set; }

        [Key]
        [Column(Order = 37)]
        [StringLength(174)]
        public string EhepartnerStrassePLZOrt { get; set; }

        [StringLength(100)]
        public string Kostenstelle { get; set; }
    }
}
