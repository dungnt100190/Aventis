namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GvAbklaerendeStelle")]
    public partial class GvAbklaerendeStelle
    {
        public int GvAbklaerendeStelleID { get; set; }

        public int GvGesuchID { get; set; }

        public int? BaZahlungswegID { get; set; }

        [StringLength(200)]
        public string BeantragendeStelle { get; set; }

        [StringLength(200)]
        public string Kontaktperson { get; set; }

        [StringLength(200)]
        public string Strasse { get; set; }

        [StringLength(10)]
        public string HausNr { get; set; }

        [StringLength(200)]
        public string Zusatz { get; set; }

        [StringLength(10)]
        public string PLZ { get; set; }

        [StringLength(50)]
        public string Ort { get; set; }

        [StringLength(10)]
        public string Kanton { get; set; }

        [StringLength(100)]
        public string Postfach { get; set; }

        public bool PostfachOhneNr { get; set; }

        [StringLength(100)]
        public string Region { get; set; }

        [StringLength(20)]
        public string Telefon { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public string Bemerkungen { get; set; }

        [StringLength(35)]
        public string MitteilungZeile1 { get; set; }

        [StringLength(35)]
        public string MitteilungZeile2 { get; set; }

        [StringLength(35)]
        public string MitteilungZeile3 { get; set; }

        [StringLength(35)]
        public string MitteilungZeile4 { get; set; }

        public string Zahlungsinstruktion { get; set; }

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
        public byte[] GvAbklaerendeStelleTS { get; set; }

        public virtual BaZahlungsweg BaZahlungsweg { get; set; }

        public virtual GvGesuch GvGesuch { get; set; }
    }
}
