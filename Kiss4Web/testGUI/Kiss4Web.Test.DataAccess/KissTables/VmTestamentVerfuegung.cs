namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmTestamentVerfuegung")]
    public partial class VmTestamentVerfuegung
    {
        public int VmTestamentVerfuegungID { get; set; }

        public int VmTestamentID { get; set; }

        public DateTime EingangsDatum { get; set; }

        public DateTime? VerfuegungsDatum { get; set; }

        public DateTime? EroeffnungsDatum { get; set; }

        public string VerfuegungText { get; set; }

        public bool? Verschlossen { get; set; }

        public int? TestamentsformCode { get; set; }

        public int? AnzSeiten { get; set; }

        public int? AufbewahrungsOrt { get; set; }

        public int? ABOvorherCode { get; set; }

        [StringLength(100)]
        public string ABOvorherText { get; set; }

        public int? ABOnachherCode { get; set; }

        [StringLength(100)]
        public string ABOnachherText { get; set; }

        public int? InventarCode { get; set; }

        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] VmTestamentVerfuegungTS { get; set; }

        public virtual VmTestament VmTestament { get; set; }
    }
}
