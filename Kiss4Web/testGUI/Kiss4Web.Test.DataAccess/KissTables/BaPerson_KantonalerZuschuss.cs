namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BaPerson_KantonalerZuschuss
    {
        public int BaPerson_KantonalerZuschussID { get; set; }

        public int BaPersonID { get; set; }

        public int BaKantonalerZuschussID { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaPerson_KantonalerZuschussTS { get; set; }

        public virtual BaKantonalerZuschuss BaKantonalerZuschuss { get; set; }

        public virtual BaPerson BaPerson { get; set; }
    }
}
