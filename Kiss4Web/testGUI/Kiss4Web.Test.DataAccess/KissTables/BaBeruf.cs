namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaBeruf")]
    public partial class BaBeruf
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaBerufID { get; set; }

        [Required]
        [StringLength(200)]
        public string Beruf { get; set; }

        [StringLength(200)]
        public string BezeichnungM { get; set; }

        [StringLength(200)]
        public string BezeichnungW { get; set; }

        public int SortKey { get; set; }

        public int BFSCode { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaBerufTS { get; set; }
    }
}
