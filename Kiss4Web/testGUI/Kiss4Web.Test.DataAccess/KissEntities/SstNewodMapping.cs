namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SstNewodMapping")]
    public partial class SstNewodMapping
    {
        [Key]
        public int NewodMappingID { get; set; }

        [Required]
        [StringLength(50)]
        public string Attribut { get; set; }

        [Required]
        [StringLength(50)]
        public string KissWert { get; set; }

        [Required]
        [StringLength(50)]
        public string NewodWert { get; set; }

        public string KissBedeutung { get; set; }

        public string NewodBedeutung { get; set; }

        [StringLength(50)]
        public string NewodAttribut { get; set; }
    }
}
