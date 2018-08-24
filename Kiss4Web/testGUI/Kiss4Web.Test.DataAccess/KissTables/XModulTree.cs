namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XModulTree")]
    public partial class XModulTree
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XModulTree()
        {
            XSearchControlTemplates = new HashSet<XSearchControlTemplate>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModulTreeID { get; set; }

        public int? ModulTreeID_Parent { get; set; }

        public int ModulID { get; set; }

        public int SortKey { get; set; }

        public int XIconID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? NameTID { get; set; }

        [StringLength(255)]
        public string ClassName { get; set; }

        [StringLength(100)]
        public string MaskName { get; set; }

        [StringLength(2000)]
        public string sqlPreExecute { get; set; }

        public int ModulTreeCode { get; set; }

        [StringLength(4000)]
        public string sqlInsertTreeItem { get; set; }

        public bool Active { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XModulTreeTS { get; set; }

        public virtual DynaMask DynaMask { get; set; }

        public virtual XIcon XIcon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XSearchControlTemplate> XSearchControlTemplates { get; set; }
    }
}
