namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FbDTAZugang")]
    public partial class FbDTAZugang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FbDTAZugang()
        {
            FbDTAJournals = new HashSet<FbDTAJournal>();
            FbKontoes = new HashSet<FbKonto>();
        }

        public int FbDTAZugangID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string VertragNr { get; set; }

        [Required]
        [StringLength(50)]
        public string KontoNr { get; set; }

        public int? BaBankID { get; set; }

        public int? FbTeamID { get; set; }

        public int KbFinanzInstitutCode { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FbDTAZugangTS { get; set; }

        public virtual BaBank BaBank { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbDTAJournal> FbDTAJournals { get; set; }

        public virtual FbTeam FbTeam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbKonto> FbKontoes { get; set; }
    }
}
