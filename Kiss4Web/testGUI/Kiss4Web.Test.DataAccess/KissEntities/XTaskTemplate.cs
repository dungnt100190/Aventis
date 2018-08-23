namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XTaskTemplate")]
    public partial class XTaskTemplate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XTaskTemplate()
        {
            FaWeisungWorkflows = new HashSet<FaWeisungWorkflow>();
            FaWeisungWorkflows1 = new HashSet<FaWeisungWorkflow>();
        }

        public int XTaskTemplateID { get; set; }

        public int TaskTypeCode { get; set; }

        public int TaskStatusCode { get; set; }

        [Required]
        [StringLength(100)]
        public string TaskSubject { get; set; }

        public int? TaskSubjectTID { get; set; }

        [Required]
        [StringLength(2500)]
        public string TaskDescription { get; set; }

        public int? TaskDescriptionTID { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XTaskTemplateTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaWeisungWorkflow> FaWeisungWorkflows { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaWeisungWorkflow> FaWeisungWorkflows1 { get; set; }
    }
}
