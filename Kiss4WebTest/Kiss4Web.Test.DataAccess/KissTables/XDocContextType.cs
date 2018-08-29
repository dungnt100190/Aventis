namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XDocContextType")]
    public partial class XDocContextType
    {
        [Key]
        public int DocContextTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string NameDocContextType { get; set; }

        [Required]
        [StringLength(255)]
        public string TemplateFolder { get; set; }

        [StringLength(255)]
        public string DocumentFolder { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XDocContextTypeTS { get; set; }
    }
}
