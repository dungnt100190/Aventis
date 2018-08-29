namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KbZahlungskonto_XOrgUnit
    {
        public int KbZahlungskonto_XOrgUnitID { get; set; }

        public int KbZahlungskontoID { get; set; }

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
        public byte[] KbZahlungskonto_XOrgUnitTS { get; set; }

        public virtual KbZahlungskonto KbZahlungskonto { get; set; }

        public virtual XOrgUnit XOrgUnit { get; set; }
    }
}
