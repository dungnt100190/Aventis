namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FbBarauszahlungAusbezahlt")]
    public partial class FbBarauszahlungAusbezahlt
    {
        public int FbBarauszahlungAusbezahltID { get; set; }

        public int FbBarauszahlungZyklusID { get; set; }

        public int FbBuchungID { get; set; }

        public int UserID { get; set; }

        public DateTime Datum { get; set; }

        public DateTime Stichtag { get; set; }

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
        public byte[] FbBarauszahlungAusbezahltTS { get; set; }

        public virtual FbBarauszahlungZyklu FbBarauszahlungZyklu { get; set; }

        public virtual FbBuchung FbBuchung { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
