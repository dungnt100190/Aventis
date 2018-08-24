namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GvDokumenteInformation")]
    public partial class GvDokumenteInformation
    {
        public int GvDokumenteInformationID { get; set; }

        public int BaPersonID { get; set; }

        public string Information { get; set; }

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
        public byte[] GvDokumenteInformationTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }
    }
}
