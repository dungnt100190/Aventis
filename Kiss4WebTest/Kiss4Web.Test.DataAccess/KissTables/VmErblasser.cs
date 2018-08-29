namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmErblasser")]
    public partial class VmErblasser
    {
        public int VmErblasserID { get; set; }

        public int FaLeistungID { get; set; }

        public DateTime? TodesDatum { get; set; }

        [StringLength(50)]
        public string TodesDatumText { get; set; }

        [StringLength(50)]
        public string TodesOrt { get; set; }

        [StringLength(16)]
        public string AHVNummer { get; set; }

        [StringLength(10)]
        public string Anrede { get; set; }

        [Required]
        [StringLength(100)]
        public string FamilienNamen { get; set; }

        [StringLength(50)]
        public string LedigName { get; set; }

        [Required]
        [StringLength(100)]
        public string Vornamen { get; set; }

        [StringLength(100)]
        public string Elternnamen { get; set; }

        [StringLength(100)]
        public string Zivilstand { get; set; }

        public int? ZivilstandCode { get; set; }

        [StringLength(20)]
        public string Geburtsdatum { get; set; }

        [StringLength(150)]
        public string Heimatorte { get; set; }

        [StringLength(100)]
        public string Strasse { get; set; }

        [StringLength(80)]
        public string Ort { get; set; }

        [StringLength(100)]
        public string Aufenthalt { get; set; }

        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] VmErblasserTS { get; set; }

        [StringLength(18)]
        public string Versichertennummer { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
