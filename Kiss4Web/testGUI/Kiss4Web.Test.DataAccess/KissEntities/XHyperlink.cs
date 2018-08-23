namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XHyperlink")]
    public partial class XHyperlink
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XHyperlink()
        {
            XHyperlinkContext_Hyperlink = new HashSet<XHyperlinkContext_Hyperlink>();
        }

        public int XHyperlinkID { get; set; }

        [Required]
        [StringLength(8000)]
        public string Hyperlink { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XHyperlinkTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XHyperlinkContext_Hyperlink> XHyperlinkContext_Hyperlink { get; set; }
    }
}
