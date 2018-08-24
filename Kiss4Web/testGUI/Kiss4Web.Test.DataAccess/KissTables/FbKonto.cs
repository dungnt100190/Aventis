namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FbKonto")]
    public partial class FbKonto
    {
        public int FbKontoID { get; set; }

        public int? FbPeriodeID { get; set; }

        public int KontoKlasseCode { get; set; }

        public int KontoTypCode { get; set; }

        public int KontoNr { get; set; }

        [Required]
        [StringLength(100)]
        public string KontoName { get; set; }

        [Column(TypeName = "money")]
        public decimal EroeffnungsSaldo { get; set; }

        [StringLength(20)]
        public string SaldoGruppeName { get; set; }

        public int? FbDTAZugangID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FbKontoTS { get; set; }

        [StringLength(20)]
        public string FbDepotNr { get; set; }

        [StringLength(50)]
        public string EroeffnungsSaldoModifier { get; set; }

        public DateTime? EroeffnungsSaldoModified { get; set; }

        [StringLength(50)]
        public string EroeffnungsSaldoCreator { get; set; }

        public DateTime? EroeffnungsSaldoCreated { get; set; }

        [Column(TypeName = "money")]
        public decimal? EroeffnungsSaldo_AtCreation { get; set; }

        public virtual FbDTAZugang FbDTAZugang { get; set; }

        public virtual FbPeriode FbPeriode { get; set; }
    }
}
