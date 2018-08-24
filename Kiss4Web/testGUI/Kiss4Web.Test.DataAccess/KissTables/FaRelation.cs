namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FaRelation")]
    public partial class FaRelation
    {
        public int FaRelationID { get; set; }

        public int FaLeistungID1 { get; set; }

        public int FaLeistungID2 { get; set; }

        public int FaRelationTypCode { get; set; }

        public bool CascadeUpdate { get; set; }

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
        public byte[] FaRelationTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual FaLeistung FaLeistung1 { get; set; }
    }
}
