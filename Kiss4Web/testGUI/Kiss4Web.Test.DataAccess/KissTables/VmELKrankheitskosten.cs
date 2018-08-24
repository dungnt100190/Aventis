namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmELKrankheitskosten")]
    public partial class VmELKrankheitskosten
    {
        public int VmELKrankheitskostenID { get; set; }

        public int FaLeistungID { get; set; }

        public int? DocumentID { get; set; }

        public DateTime? Eingereicht { get; set; }

        public DateTime? AbrechnungenVom { get; set; }

        public DateTime? VerfuegungVom { get; set; }

        [Column(TypeName = "money")]
        public decimal? Betrag { get; set; }

        public DateTime? AbrechnungenBis { get; set; }

        [Column(TypeName = "money")]
        public decimal? VerfuegungLeistung { get; set; }

        public string Bemerkungen { get; set; }

        public bool IsDeleted { get; set; }

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
        public byte[] VmELKrankheitskostenTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual VmELKrankheitskosten VmELKrankheitskosten1 { get; set; }

        public virtual VmELKrankheitskosten VmELKrankheitskosten2 { get; set; }
    }
}
