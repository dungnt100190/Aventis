namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmKaBetrieb")]
    public partial class vwTmKaBetrieb
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KaBetriebID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string AdressZusatz { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(431)]
        public string AdresseMehrzeilig { get; set; }

        [StringLength(200)]
        public string Land { get; set; }

        [StringLength(100)]
        public string TeilbetriebVon { get; set; }

        [StringLength(100)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        [StringLength(100)]
        public string Internet { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool Akt { get; set; }

        public bool? AuVe { get; set; }

        [StringLength(200)]
        public string Charakter { get; set; }

        public int? KaBetriebDokumentID { get; set; }

        public DateTime? DokDatum { get; set; }

        [StringLength(100)]
        public string DokStichworte { get; set; }

        [StringLength(401)]
        public string DokAbsenderVornameName { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(9)]
        public string DokAdressatAnrede { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(225)]
        public string DokAdressatSehrGeehrte { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(14)]
        public string DokAdressatLieberLiebe { get; set; }

        [StringLength(200)]
        public string DokAdressatName { get; set; }

        [StringLength(200)]
        public string DokAdressatVorname { get; set; }

        [StringLength(401)]
        public string DokAdressatVornameName { get; set; }

        [StringLength(100)]
        public string DokAdressatTel { get; set; }

        [StringLength(100)]
        public string DokAdressatMobil { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(633)]
        public string DokAdressatAdresseMehrz { get; set; }
    }
}
