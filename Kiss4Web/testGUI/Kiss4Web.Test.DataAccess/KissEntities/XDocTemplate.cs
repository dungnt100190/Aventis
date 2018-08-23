namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XDocTemplate")]
    public partial class XDocTemplate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XDocTemplate()
        {
            XDocContext_Template = new HashSet<XDocContext_Template>();
            XOrgUnit_XDocTemplate = new HashSet<XOrgUnit_XDocTemplate>();
            XUser_XDocTemplate = new HashSet<XUser_XDocTemplate>();
        }

        [Key]
        public int DocTemplateID { get; set; }

        public int? CheckOut_UserID { get; set; }

        public int? XProfileID { get; set; }

        [StringLength(255)]
        public string DocTemplateName { get; set; }

        [StringLength(10)]
        public string FileExtension { get; set; }

        public DateTime DateCreation { get; set; }

        public DateTime DateLastSave { get; set; }

        [Column(TypeName = "image")]
        public byte[] FileBinary { get; set; }

        public int? DocFormatCode { get; set; }

        public DateTime? CheckOut_Date { get; set; }

        public string CheckOut_Filename { get; set; }

        public string CheckOut_Machine { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] DocTemplateTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XDocContext_Template> XDocContext_Template { get; set; }

        public virtual XProfile XProfile { get; set; }

        public virtual XUser XUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XOrgUnit_XDocTemplate> XOrgUnit_XDocTemplate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUser_XDocTemplate> XUser_XDocTemplate { get; set; }
    }
}
