namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XTypeConfig")]
    public partial class XTypeConfig
    {
        public int XTypeConfigID { get; set; }

        [Required]
        [StringLength(100)]
        public string LookupTypeName { get; set; }

        [Required]
        [StringLength(200)]
        public string LookupTypeNamespace { get; set; }

        [Required]
        [StringLength(200)]
        public string LookupTypeAssemblyName { get; set; }

        [Required]
        [StringLength(100)]
        public string ConcreteStandardTypeName { get; set; }

        [Required]
        [StringLength(200)]
        public string ConcreteStandardTypeNamespace { get; set; }

        [Required]
        [StringLength(200)]
        public string ConcreteStandardTypeAssemblyName { get; set; }

        [StringLength(100)]
        public string ConcreteCustomTypeName { get; set; }

        [StringLength(200)]
        public string ConcreteCustomTypeNamespace { get; set; }

        [StringLength(200)]
        public string ConcreteCustomTypeAssemblyName { get; set; }

        public int InstanceScopeCode { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XTypeConfigTS { get; set; }
    }
}
