namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KesMassnahmeAuftrag")]
    public partial class KesMassnahmeAuftrag
    {
        public int KesMassnahmeAuftragID { get; set; }

        public int KesMassnahmeID { get; set; }

        public int? DocumentID_Beschluss { get; set; }

        public DateTime? BeschlussVom { get; set; }

        public DateTime? ErledigungBis { get; set; }

        public string Auftrag { get; set; }

        public int? KesMassnahmeGeschaeftsartCode { get; set; }

        public int? DocumentID_Bericht { get; set; }

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
        public byte[] KesMassnahmeAuftragTS { get; set; }

        public virtual KesMassnahme KesMassnahme { get; set; }
    }
}
