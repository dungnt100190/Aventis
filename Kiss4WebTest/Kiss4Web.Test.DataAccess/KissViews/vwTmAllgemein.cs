namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmAllgemein")]
    public partial class vwTmAllgemein
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KaIntegBildungID { get; set; }

        public string Bemerkungen { get; set; }

        [StringLength(200)]
        public string Kursabschluss { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Kursaustritt { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string Kurseintritt { get; set; }

        [StringLength(100)]
        public string Kursname { get; set; }
    }
}
