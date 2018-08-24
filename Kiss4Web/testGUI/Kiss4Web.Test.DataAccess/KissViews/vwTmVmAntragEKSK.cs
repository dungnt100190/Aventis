namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmVmAntragEKSK")]
    public partial class vwTmVmAntragEKSK
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VmAntragEKSKID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaLeistungID { get; set; }

        [StringLength(255)]
        public string Titel { get; set; }

        public string Begruendung { get; set; }

        [StringLength(10)]
        public string DatumAntrag { get; set; }

        public string Antrag { get; set; }

        [StringLength(10)]
        public string GenehmigtEKSK { get; set; }

        [StringLength(401)]
        public string Autor { get; set; }
    }
}
