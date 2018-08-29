namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class XDocContext_Template
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XDocContext_Template()
        {
            XDocContext_Template1 = new HashSet<XDocContext_Template>();
        }

        public int XDocContext_TemplateID { get; set; }

        public int? ParentID { get; set; }

        public int? ParentPosition { get; set; }

        [StringLength(100)]
        public string FolderName { get; set; }

        public int? DocContextID { get; set; }

        public int? DocTemplateID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XDocContext_TemplateTS { get; set; }

        public int? ModulID { get; set; }

        public virtual XDocContext XDocContext { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XDocContext_Template> XDocContext_Template1 { get; set; }

        public virtual XDocContext_Template XDocContext_Template2 { get; set; }

        public virtual XDocTemplate XDocTemplate { get; set; }

        public virtual XModul XModul { get; set; }
    }
}
