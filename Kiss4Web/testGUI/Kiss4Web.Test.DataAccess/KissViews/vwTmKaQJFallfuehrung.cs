namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmKaQJFallfuehrung")]
    public partial class vwTmKaQJFallfuehrung
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KaQJProzessID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaLeistungID { get; set; }

        [StringLength(200)]
        public string Vorname { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(401)]
        public string Adressat { get; set; }

        [StringLength(1538)]
        public string Adresse { get; set; }

        [StringLength(2000)]
        public string Briefanrede { get; set; }

        [StringLength(2000)]
        public string Anrede { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        [StringLength(100)]
        public string Telefon { get; set; }

        [StringLength(500)]
        public string Institution { get; set; }
    }
}
