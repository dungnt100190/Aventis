namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmVmGefaehrdungsMeldung")]
    public partial class vwTmVmGefaehrdungsMeldung
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VmGefaehrdungsMeldungID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaLeistungID { get; set; }

        [StringLength(10)]
        public string DatumEingang { get; set; }

        [StringLength(200)]
        public string Kontaktveranlasser { get; set; }

        [StringLength(1000)]
        public string GefaehrdungNSB { get; set; }

        [StringLength(1000)]
        public string Themen { get; set; }

        public string Ausgangslage { get; set; }

        public string Auflagen { get; set; }

        public string Ueberpruefung { get; set; }

        public string Konsequenzen { get; set; }

        [StringLength(10)]
        public string AuflageDatum { get; set; }
    }
}
