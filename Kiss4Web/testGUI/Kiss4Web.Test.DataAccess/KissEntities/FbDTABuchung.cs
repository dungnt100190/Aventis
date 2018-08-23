namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FbDTABuchung")]
    public partial class FbDTABuchung
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FbBuchungID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FbDTAJournalID { get; set; }

        public int Status { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FbDTABuchungTS { get; set; }

        public virtual FbBuchung FbBuchung { get; set; }

        public virtual FbDTAJournal FbDTAJournal { get; set; }
    }
}
