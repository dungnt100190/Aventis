namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KbKostenstelle_BaPerson
    {
        [Key]
        public int KbKostenstelleBaPersonID { get; set; }

        public int BaPersonID { get; set; }

        public int KbKostenstelleID { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

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
        public byte[] KbKostenstelle_BaPersonTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual KbKostenstelle KbKostenstelle { get; set; }
    }
}
