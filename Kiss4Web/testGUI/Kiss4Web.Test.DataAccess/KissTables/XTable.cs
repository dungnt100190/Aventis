namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XTable")]
    public partial class XTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XTable()
        {
            XTableColumns = new HashSet<XTableColumn>();
        }

        [Key]
        [StringLength(255)]
        public string TableName { get; set; }

        [StringLength(3)]
        public string Alias { get; set; }

        public bool System { get; set; }

        public int? ModulID { get; set; }

        public bool DataWareHouse { get; set; }

        [StringLength(2000)]
        public string Comment { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XTableTS { get; set; }

        public virtual XModul XModul { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XTableColumn> XTableColumns { get; set; }
    }
}
