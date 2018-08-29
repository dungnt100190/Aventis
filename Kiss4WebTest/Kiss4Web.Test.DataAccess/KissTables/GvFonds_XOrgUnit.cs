namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GvFonds_XOrgUnit
    {
        public int GvFonds_XOrgUnitID { get; set; }

        public int GvFondsID { get; set; }

        public int OrgUnitID { get; set; }

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
        public byte[] GvFonds_XOrgUnitTS { get; set; }

        public virtual GvFond GvFond { get; set; }

        public virtual XOrgUnit XOrgUnit { get; set; }
    }
}
