namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XSearchControlTemplate")]
    public partial class XSearchControlTemplate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XSearchControlTemplate()
        {
            XSearchControlTemplate1 = new HashSet<XSearchControlTemplate>();
            XSearchControlTemplateFields = new HashSet<XSearchControlTemplateField>();
        }

        public int XSearchControlTemplateID { get; set; }

        [StringLength(255)]
        public string ClassName { get; set; }

        public int UserID { get; set; }

        public int? ModulTreeID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int? ParentXSearchControlTemplateID { get; set; }

        public int SortKey { get; set; }

        public string ColLayout { get; set; }

        public bool SearchImmediately { get; set; }

        public virtual XModulTree XModulTree { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XSearchControlTemplate> XSearchControlTemplate1 { get; set; }

        public virtual XSearchControlTemplate XSearchControlTemplate2 { get; set; }

        public virtual XUser XUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XSearchControlTemplateField> XSearchControlTemplateFields { get; set; }
    }
}
