namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DynaMask")]
    public partial class DynaMask
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DynaMask()
        {
            DynaFields = new HashSet<DynaField>();
            XModulTrees = new HashSet<XModulTree>();
            XUserGroup_Right = new HashSet<XUserGroup_Right>();
        }

        [Key]
        [StringLength(100)]
        public string MaskName { get; set; }

        [StringLength(100)]
        public string ParentMaskName { get; set; }

        public int? ParentPosition { get; set; }

        public int ModulID { get; set; }

        public int? FaModulCode { get; set; }

        public int? FaPhaseCode { get; set; }

        public int? VmProzessCode { get; set; }

        [Required]
        [StringLength(100)]
        public string DisplayText { get; set; }

        public int? IconID { get; set; }

        [StringLength(500)]
        public string TabNames { get; set; }

        public int? GridHeight { get; set; }

        public bool System { get; set; }

        public bool Active { get; set; }

        [StringLength(200)]
        public string AppCode { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] DynaMaskTS { get; set; }

        public int? KaProzessCode { get; set; }

        public int? DisplayTextTID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DynaField> DynaFields { get; set; }

        public virtual XModul XModul { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XModulTree> XModulTrees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUserGroup_Right> XUserGroup_Right { get; set; }
    }
}
