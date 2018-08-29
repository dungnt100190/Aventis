namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IkEinkomman
    {
        [Key]
        public int IkEinkommenID { get; set; }

        public int IkRechtstitelID { get; set; }

        public int BaPersonID { get; set; }

        public int IkEinkommenTypCode { get; set; }

        public DateTime GueltigVon { get; set; }

        public DateTime? GueltigBis { get; set; }

        [Column(TypeName = "money")]
        public decimal Betrag { get; set; }

        public string Bemerkung { get; set; }

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
        public byte[] IkEinkommenTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual IkRechtstitel IkRechtstitel { get; set; }
    }
}
