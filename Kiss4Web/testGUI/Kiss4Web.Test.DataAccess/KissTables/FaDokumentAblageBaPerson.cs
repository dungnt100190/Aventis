namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FaDokumentAblageBaPerson
    {
        public int FaDokumentAblageBaPersonID { get; set; }

        public int BaPersonID { get; set; }

        public int FaDokumentAblageID { get; set; }

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
        public byte[] FaDokumentAblageBaPersonTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual FaDokumentAblage FaDokumentAblage { get; set; }
    }
}
