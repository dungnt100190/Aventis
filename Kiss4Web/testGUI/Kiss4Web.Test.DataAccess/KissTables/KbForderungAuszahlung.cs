namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KbForderungAuszahlung")]
    public partial class KbForderungAuszahlung
    {
        public int KbForderungAuszahlungID { get; set; }

        public int KbBuchungID_Auszahlung { get; set; }

        public int KbBuchungID_Forderung { get; set; }

        public int? KbOpAusgleichID { get; set; }

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
        public byte[] KbForderungAuszahlungTS { get; set; }

        public virtual KbBuchung KbBuchung { get; set; }

        public virtual KbBuchung KbBuchung1 { get; set; }

        public virtual KbOpAusgleich KbOpAusgleich { get; set; }
    }
}
