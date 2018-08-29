namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class XHyperlinkContext_Hyperlink
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XHyperlinkContext_Hyperlink()
        {
            XHyperlinkContext_Hyperlink1 = new HashSet<XHyperlinkContext_Hyperlink>();
        }

        public int XHyperlinkContext_HyperlinkID { get; set; }

        public int? ParentID { get; set; }

        public int? SortKey { get; set; }

        [StringLength(100)]
        public string FolderName { get; set; }

        public int XHyperlinkContextID { get; set; }

        public int? XHyperlinkID { get; set; }

        public int? UserProfileCode { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XHyperlinkContext_HyperlinkTS { get; set; }

        public virtual XHyperlink XHyperlink { get; set; }

        public virtual XHyperlinkContext XHyperlinkContext { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XHyperlinkContext_Hyperlink> XHyperlinkContext_Hyperlink1 { get; set; }

        public virtual XHyperlinkContext_Hyperlink XHyperlinkContext_Hyperlink2 { get; set; }
    }
}
