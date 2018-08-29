namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KesMassnahmeBericht")]
    public partial class KesMassnahmeBericht
    {
        public int KesMassnahmeBerichtID { get; set; }

        public int KesMassnahmeID { get; set; }

        public int? KesMassnahmeBerichtsartCode { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public string Bemerkung { get; set; }

        public int? DocumentID_Bericht { get; set; }

        public int? DocumentID_Rechnung { get; set; }

        public int? DocumentID_Versand { get; set; }

        public int? DocumentID_VerfuegungKESB { get; set; }

        public DateTime? DatumVerfuegungKESB { get; set; }

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
        public byte[] KesMassnahmeBerichtTS { get; set; }

        public virtual KesMassnahme KesMassnahme { get; set; }
    }
}
