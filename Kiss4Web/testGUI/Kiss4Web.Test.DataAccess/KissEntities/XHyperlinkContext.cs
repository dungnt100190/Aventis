namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XHyperlinkContext")]
    public partial class XHyperlinkContext
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XHyperlinkContext()
        {
            XHyperlinkContext_Hyperlink = new HashSet<XHyperlinkContext_Hyperlink>();
        }

        public int XHyperlinkContextID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool System { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XHyperlinkContextTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XHyperlinkContext_Hyperlink> XHyperlinkContext_Hyperlink { get; set; }
    }
}
