namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BgFinanzplan")]
    public partial class BgFinanzplan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BgFinanzplan()
        {
            BgBewilligungs = new HashSet<BgBewilligung>();
            BgBudgets = new HashSet<BgBudget>();
            BgDokuments = new HashSet<BgDokument>();
            BgFinanzplan_BaPerson = new HashSet<BgFinanzplan_BaPerson>();
        }

        public int BgFinanzplanID { get; set; }

        public int FaLeistungID { get; set; }

        public int BgBewilligungStatusCode { get; set; }

        public int? BgGrundEroeffnenCode { get; set; }

        public int? BgGrundAbschlussCode { get; set; }

        public int? WhHilfeTypCode { get; set; }

        public DateTime GeplantVon { get; set; }

        public DateTime? GeplantBis { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BgFinanzplanTS { get; set; }

        public int? WhGrundbedarfTypCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgBewilligung> BgBewilligungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgBudget> BgBudgets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgDokument> BgDokuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgFinanzplan_BaPerson> BgFinanzplan_BaPerson { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
