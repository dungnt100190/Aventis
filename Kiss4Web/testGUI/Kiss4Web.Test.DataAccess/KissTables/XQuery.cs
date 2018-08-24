namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XQuery")]
    public partial class XQuery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XQuery()
        {
            XUserGroup_Right = new HashSet<XUserGroup_Right>();
        }

        [Key]
        [StringLength(100)]
        public string QueryName { get; set; }

        [StringLength(100)]
        public string ParentReportName { get; set; }

        public int QueryCode { get; set; }

        [StringLength(100)]
        public string UserText { get; set; }

        public string LayoutXML { get; set; }

        public string ParameterXML { get; set; }

        public string SQLquery { get; set; }

        [StringLength(200)]
        public string ContextForms { get; set; }

        public int? ReportSortKey { get; set; }

        [StringLength(100)]
        public string RelationColumnName { get; set; }

        public bool System { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XQueryTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUserGroup_Right> XUserGroup_Right { get; set; }
    }
}
