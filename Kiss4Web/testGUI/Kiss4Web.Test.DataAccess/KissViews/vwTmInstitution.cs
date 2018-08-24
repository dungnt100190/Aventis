namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmInstitution")]
    public partial class vwTmInstitution
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaInstitutionID { get; set; }

        [StringLength(20)]
        public string InstitutionNr { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Vorname { get; set; }

        [StringLength(500)]
        public string NameVorname { get; set; }

        [StringLength(100)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        [StringLength(100)]
        public string Homepage { get; set; }

        [StringLength(200)]
        public string CareOf { get; set; }

        [StringLength(200)]
        public string AdressZusatz { get; set; }

        [StringLength(200)]
        public string ZuhandenVon { get; set; }

        [StringLength(100)]
        public string Strasse { get; set; }

        [StringLength(10)]
        public string HausNr { get; set; }

        [StringLength(100)]
        public string Postfach { get; set; }

        public bool? PostfachOhneNr { get; set; }

        [StringLength(255)]
        public string PostfachTextD { get; set; }

        [StringLength(10)]
        public string PLZ { get; set; }

        [StringLength(50)]
        public string Ort { get; set; }

        public int? OrtschaftCode { get; set; }

        [StringLength(10)]
        public string Kanton { get; set; }

        [StringLength(100)]
        public string Bezirk { get; set; }

        [StringLength(111)]
        public string StrasseHausNr { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(163)]
        public string OrtStrasse { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(61)]
        public string PLZOrt { get; set; }

        [StringLength(200)]
        public string LandD { get; set; }

        [StringLength(200)]
        public string LandF { get; set; }

        [StringLength(200)]
        public string LandI { get; set; }

        [StringLength(200)]
        public string LandE { get; set; }

        [StringLength(1135)]
        public string AdresseEinzeilig { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(633)]
        public string AdresseEinzOhneName { get; set; }

        [StringLength(1135)]
        public string AdresseMehrzeilig { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(633)]
        public string AdresseMehrzOhneName { get; set; }
    }
}
