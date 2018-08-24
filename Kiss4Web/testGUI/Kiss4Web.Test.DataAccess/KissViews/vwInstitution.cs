namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwInstitution")]
    public partial class vwInstitution
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaInstitutionID { get; set; }

        public int? OrgUnitID { get; set; }

        [StringLength(20)]
        public string InstitutionNr { get; set; }

        public int? BaInstitutionArtCode { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Aktiv { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Debitor { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool Kreditor { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool KeinSerienbrief { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool ManuelleAnrede { get; set; }

        [StringLength(100)]
        public string Anrede { get; set; }

        [StringLength(100)]
        public string Briefanrede { get; set; }

        [StringLength(100)]
        public string Titel { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Vorname { get; set; }

        public int? GeschlechtCode { get; set; }

        [StringLength(100)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string Telefon2 { get; set; }

        [StringLength(100)]
        public string Telefon3 { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        [StringLength(100)]
        public string Homepage { get; set; }

        public int? SprachCode { get; set; }

        public string Bemerkung { get; set; }

        [StringLength(50)]
        public string Creator { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime Created { get; set; }

        [StringLength(50)]
        public string Modifier { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime Modified { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaInstitutionTS { get; set; }

        [StringLength(500)]
        public string NameVorname { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(633)]
        public string Adresse { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(633)]
        public string AdresseMehrzeilig { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(163)]
        public string OrtStrasse { get; set; }

        [StringLength(200)]
        public string Zusatz { get; set; }

        [StringLength(200)]
        public string AdressZusatz { get; set; }

        [StringLength(100)]
        public string Strasse { get; set; }

        [StringLength(10)]
        public string HausNr { get; set; }

        [StringLength(111)]
        public string StrasseHausNr { get; set; }

        [StringLength(100)]
        public string Postfach { get; set; }

        public bool? PostfachOhneNr { get; set; }

        [StringLength(255)]
        public string PostfachTextD { get; set; }

        [StringLength(10)]
        public string PLZ { get; set; }

        [StringLength(50)]
        public string Ort { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(61)]
        public string PLZOrt { get; set; }

        [StringLength(100)]
        public string Bezirk { get; set; }

        [StringLength(10)]
        public string Kanton { get; set; }

        [StringLength(200)]
        public string Land { get; set; }

        public int? OrtschaftCode { get; set; }

        public int? BaLandID { get; set; }

        [Key]
        [Column(Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaFreigabeStatusCode { get; set; }
    }
}
