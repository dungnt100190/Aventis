namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class XOrgUnit_XDocTemplate
    {
        public int XOrgUnit_XDocTemplateID { get; set; }

        public int OrgUnitID { get; set; }

        public int DocTemplateID { get; set; }

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
        public byte[] XOrgUnit_XDocTemplateTS { get; set; }

        public virtual XDocTemplate XDocTemplate { get; set; }

        public virtual XOrgUnit XOrgUnit { get; set; }
    }
}
