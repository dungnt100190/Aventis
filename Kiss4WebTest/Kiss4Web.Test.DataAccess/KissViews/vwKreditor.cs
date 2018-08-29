namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwKreditor")]
    public partial class vwKreditor
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaZahlungswegID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime ZahlungswegDatumVon { get; set; }

        public DateTime? ZahlungswegDatumBis { get; set; }

        public int? EinzahlungsscheinCode { get; set; }

        [StringLength(50)]
        public string BankKontoNummer { get; set; }

        [StringLength(50)]
        public string IBANNummer { get; set; }

        [StringLength(20)]
        public string PostKontoNummer { get; set; }

        [StringLength(50)]
        public string ReferenzNummer { get; set; }

        public int? BaBankID { get; set; }

        [StringLength(70)]
        public string BankName { get; set; }

        [StringLength(50)]
        public string BankZusatz { get; set; }

        [StringLength(50)]
        public string BankStrasse { get; set; }

        [StringLength(10)]
        public string BankPLZ { get; set; }

        [StringLength(50)]
        public string BankOrt { get; set; }

        [StringLength(15)]
        public string BankClearingNr { get; set; }

        [StringLength(50)]
        public string BankPCKontoNr { get; set; }

        public DateTime? BankGueltigAb { get; set; }

        public int? BankLandCode { get; set; }

        public int? BaInstitutionID { get; set; }

        [StringLength(500)]
        public string InstitutionName { get; set; }

        public int? BaFreigabeStatusCode { get; set; }

        [StringLength(633)]
        public string InstitutionAdresse { get; set; }

        [StringLength(163)]
        public string InstitutionOrtStrasse { get; set; }

        [StringLength(200)]
        public string InstitutionAdressZusatz { get; set; }

        [StringLength(100)]
        public string InstitutionStrasse { get; set; }

        [StringLength(10)]
        public string InstitutionHausNr { get; set; }

        [StringLength(111)]
        public string InstitutionStrasseHausNr { get; set; }

        [StringLength(100)]
        public string InstitutionPostfach { get; set; }

        [StringLength(10)]
        public string InstitutionPLZ { get; set; }

        [StringLength(50)]
        public string InstitutionOrt { get; set; }

        [StringLength(61)]
        public string InstitutionPLZOrt { get; set; }

        [StringLength(10)]
        public string InstitutionKanton { get; set; }

        [StringLength(200)]
        public string InstitutionLand { get; set; }

        public int? InstitutionBaLandID { get; set; }

        public int? BaPersonID { get; set; }

        [StringLength(100)]
        public string PersonName { get; set; }

        [StringLength(100)]
        public string PersonVorname { get; set; }

        [StringLength(202)]
        public string PersonNameVorname { get; set; }

        [StringLength(633)]
        public string PersonAdresse { get; set; }

        [StringLength(200)]
        public string PersonAdressZusatz { get; set; }

        [StringLength(100)]
        public string PersonStrasse { get; set; }

        [StringLength(10)]
        public string PersonHausNr { get; set; }

        [StringLength(111)]
        public string PersonStrasseHausNr { get; set; }

        [StringLength(100)]
        public string PersonPostfach { get; set; }

        [StringLength(10)]
        public string PersonPLZ { get; set; }

        [StringLength(50)]
        public string PersonOrt { get; set; }

        [StringLength(61)]
        public string PersonPLZOrt { get; set; }

        [StringLength(10)]
        public string PersonKanton { get; set; }

        [StringLength(200)]
        public string PersonLand { get; set; }

        public int? PersonBaLandID { get; set; }

        [StringLength(500)]
        public string Kreditor { get; set; }

        [StringLength(1135)]
        public string KreditorMehrZeilig { get; set; }

        [StringLength(1135)]
        public string KreditorEinzeilig { get; set; }

        [StringLength(209)]
        public string Zahlungsweg { get; set; }

        [StringLength(354)]
        public string ZahlungswegMehrZeilig { get; set; }

        [StringLength(11)]
        public string PCKontoNr { get; set; }

        [StringLength(850)]
        public string ZusatzInfo { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(35)]
        public string BeguenstigtName { get; set; }

        [StringLength(35)]
        public string BeguenstigtName2 { get; set; }

        [StringLength(35)]
        public string BeguenstigtStrasse { get; set; }

        [StringLength(10)]
        public string BeguenstigtPLZ { get; set; }

        [StringLength(25)]
        public string BeguenstigtOrt { get; set; }
    }
}
