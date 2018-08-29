namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XRule")]
    public partial class XRule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XRule()
        {
            XClassRules = new HashSet<XClassRule>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int XRuleID { get; set; }

        public int RuleCode { get; set; }

        [StringLength(200)]
        public string RuleName { get; set; }

        [StringLength(7000)]
        public string RuleDescription { get; set; }

        public string csCode { get; set; }

        public bool PublicRule { get; set; }

        public bool TemplateRule { get; set; }

        public int? ModulID { get; set; }

        public int? DefaultSortKey { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XRuleTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XClassRule> XClassRules { get; set; }

        public virtual XModul XModul { get; set; }
    }
}
