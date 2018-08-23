namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XClass")]
    public partial class XClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XClass()
        {
            XRights = new HashSet<XRight>();
            XUserGroup_Right = new HashSet<XUserGroup_Right>();
        }

        public int XClassID { get; set; }

        [Required]
        [StringLength(255)]
        public string ClassName { get; set; }

        [StringLength(255)]
        public string ClassNameViewModel { get; set; }

        public int ModulID { get; set; }

        [StringLength(100)]
        public string MaskName { get; set; }

        [Required]
        [StringLength(500)]
        public string BaseType { get; set; }

        public int? ClassCode { get; set; }

        public int? ClassTID { get; set; }

        public string PropertiesXML { get; set; }

        public int Designer { get; set; }

        public string Description { get; set; }

        public string CodeGenerated { get; set; }

        [Column(TypeName = "image")]
        public byte[] Resource { get; set; }

        [Column(TypeName = "image")]
        public byte[] Assembly { get; set; }

        [StringLength(128)]
        public string Branch { get; set; }

        public int BuildNr { get; set; }

        public bool System { get; set; }

        public int? CheckOut_UserID { get; set; }

        public DateTime? CheckOut_Date { get; set; }

        [StringLength(50)]
        public string NamespaceExtension { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XClassTS { get; set; }

        public virtual XModul XModul { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XRight> XRights { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUserGroup_Right> XUserGroup_Right { get; set; }
    }
}
