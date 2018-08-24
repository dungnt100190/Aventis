namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmKaVermittlung")]
    public partial class vwTmKaVermittlung
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaPersonID { get; set; }

        [StringLength(401)]
        public string SIZuweiserVornameName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string SIZuweiserAnrede { get; set; }

        [StringLength(100)]
        public string SIZuweiserSektion { get; set; }

        [StringLength(401)]
        public string BIBIPZuweiserVornameName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string BIBIPZuweiserAnrede { get; set; }

        [StringLength(100)]
        public string BIBIPZuweiserSektion { get; set; }
    }
}
