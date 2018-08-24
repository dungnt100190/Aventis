namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmErbe")]
    public partial class VmErbe
    {
        public int VmErbeID { get; set; }

        public int? VmSiegelungID { get; set; }

        public int? VmTestamentID { get; set; }

        public int? VmErbschaftsdienstID { get; set; }

        public int Position { get; set; }

        public int Level { get; set; }

        [StringLength(500)]
        public string Titel { get; set; }

        [StringLength(40)]
        public string Geburtsdatum { get; set; }

        [StringLength(100)]
        public string Anrede { get; set; }

        [StringLength(100)]
        public string FamilienNamen { get; set; }

        [StringLength(100)]
        public string Vornamen { get; set; }

        [StringLength(100)]
        public string Zusatz { get; set; }

        [StringLength(100)]
        public string Strasse { get; set; }

        [StringLength(80)]
        public string Ort { get; set; }

        [StringLength(50)]
        public string Land { get; set; }

        [StringLength(4000)]
        public string Ergaenzung { get; set; }

        [StringLength(500)]
        public string KontaktAdresse { get; set; }

        public bool? KontaktHinzufuegen { get; set; }

        [StringLength(10)]
        public string TestamentEroeffnungStatus { get; set; }

        public int? TestamentEroeffnungNr { get; set; }

        [StringLength(5)]
        public string TestamentEroeffnungVersandart { get; set; }

        public DateTime? TestamentEroeffnungVersandDatum { get; set; }

        [StringLength(20)]
        public string ErbCodierung { get; set; }

        public int? ErbanteilDividend { get; set; }

        public int? ErbanteilDivisor { get; set; }

        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] VmErbeTS { get; set; }

        [StringLength(500)]
        public string Titel2 { get; set; }

        public virtual VmErbschaftsdienst VmErbschaftsdienst { get; set; }

        public virtual VmSiegelung VmSiegelung { get; set; }

        public virtual VmTestament VmTestament { get; set; }
    }
}
