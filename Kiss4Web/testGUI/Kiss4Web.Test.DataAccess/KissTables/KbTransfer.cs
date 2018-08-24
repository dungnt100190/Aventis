namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KbTransfer")]
    public partial class KbTransfer
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KbBuchungID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KbZahlungslaufID { get; set; }

        public int KbTransferStatusCode { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KbTransferTS { get; set; }

        public virtual KbBuchung KbBuchung { get; set; }

        public virtual KbZahlungslauf KbZahlungslauf { get; set; }
    }
}
