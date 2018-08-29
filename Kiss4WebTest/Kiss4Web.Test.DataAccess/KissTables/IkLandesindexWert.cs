namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IkLandesindexWert")]
    public partial class IkLandesindexWert
    {
        public int IkLandesindexWertID { get; set; }

        public int IkLandesindexID { get; set; }

        public int Jahr { get; set; }

        public int Monat { get; set; }

        [Column(TypeName = "money")]
        public decimal? Wert { get; set; }

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
        public byte[] IkLandesindexWertTS { get; set; }

        public virtual IkLandesindex IkLandesindex { get; set; }
    }
}
