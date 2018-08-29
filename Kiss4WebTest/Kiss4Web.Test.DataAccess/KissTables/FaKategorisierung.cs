namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FaKategorisierung")]
    public partial class FaKategorisierung
    {
        public int FaKategorisierungID { get; set; }

        public int BaPersonID { get; set; }

        public int? FaKategorisierungEksProduktID { get; set; }

        public int UserID { get; set; }

        public DateTime Datum { get; set; }

        public int? FaKategorisierungEksOptionCode { get; set; }

        public int? FaKategorisierungKiStatusCode { get; set; }

        public int? FaKategorisierungIntakeCode { get; set; }

        public int? FaKategorisierungKooperationCode { get; set; }

        public int? FaKategorisierungRessourcenCode { get; set; }

        public int? FaKategorisierungAbschlussgrundCode { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? FaKategorieCode { get; set; }

        public DateTime? Abschlussdatum { get; set; }

        public string Begruendung { get; set; }

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
        public byte[] FaKategorisierungTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual FaKategorisierungEksProdukt FaKategorisierungEksProdukt { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
