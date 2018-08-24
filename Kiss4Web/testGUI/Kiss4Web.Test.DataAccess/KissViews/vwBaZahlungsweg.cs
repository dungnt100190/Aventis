namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwBaZahlungsweg")]
    public partial class vwBaZahlungsweg
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaZahlungswegID { get; set; }

        public int? BaPersonID { get; set; }

        public int? BaInstitutionID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int? EinzahlungsscheinCode { get; set; }

        public int? BaBankID { get; set; }

        [StringLength(50)]
        public string BankKontoNummer { get; set; }

        [StringLength(50)]
        public string IBANNummer { get; set; }

        [StringLength(20)]
        public string PostKontoNummer { get; set; }

        [StringLength(50)]
        public string ReferenzNummer { get; set; }

        [StringLength(35)]
        public string AdresseName { get; set; }

        [StringLength(35)]
        public string AdresseName2 { get; set; }

        [StringLength(35)]
        public string AdresseStrasse { get; set; }

        [StringLength(35)]
        public string AdresseHausNr { get; set; }

        [StringLength(35)]
        public string AdressePostfach { get; set; }

        [StringLength(10)]
        public string AdressePLZ { get; set; }

        [StringLength(25)]
        public string AdresseOrt { get; set; }

        public int? AdresseLandCode { get; set; }

        [StringLength(20)]
        public string BaZahlwegModulStdCodes { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaZahlungswegTS { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(633)]
        public string Adresse { get; set; }

        [StringLength(1135)]
        public string Empfaenger { get; set; }
    }
}
