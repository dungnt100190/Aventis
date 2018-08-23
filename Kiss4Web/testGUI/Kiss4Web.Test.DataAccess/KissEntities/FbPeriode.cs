namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FbPeriode")]
    public partial class FbPeriode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FbPeriode()
        {
            FbBuchungs = new HashSet<FbBuchung>();
            FbKontoes = new HashSet<FbKonto>();
        }

        public int FbPeriodeID { get; set; }

        public int BaPersonID { get; set; }

        public DateTime PeriodeVon { get; set; }

        public DateTime PeriodeBis { get; set; }

        public int PeriodeStatusCode { get; set; }

        public int? FbTeamID { get; set; }

        public int? JournalablageortCode { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FbPeriodeTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbBuchung> FbBuchungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbKonto> FbKontoes { get; set; }

        public virtual FbTeam FbTeam { get; set; }
    }
}
