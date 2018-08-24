namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AyPositionsart")]
    public partial class AyPositionsart
    {
        [Key]
        [Column(Order = 0)]
        public int BgPositionsartID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModulID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BgKategorieCode { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BgGruppeCode { get; set; }

        public int? BgPositionsartCode { get; set; }

        public int? BgPositionsartID_CopyOf { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        public string Name { get; set; }

        public string HilfeText { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SortKey { get; set; }

        public int? BgKostenartID { get; set; }

        public int? NrmKontoCode { get; set; }

        public bool? VerwaltungSD_Default { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool Spezkonto { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool ProPerson { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool ProUE { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Masterbudget_EditMask { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Monatsbudget_EditMask { get; set; }

        [StringLength(3000)]
        public string sqlRichtlinie { get; set; }

        [StringLength(50)]
        public string VarName { get; set; }

        [Key]
        [Column(Order = 11)]
        public bool Verrechenbar { get; set; }

        public string Bemerkung { get; set; }

        public int? NameTID { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        [Key]
        [Column(Order = 12)]
        public bool System { get; set; }

        [Key]
        [Column(Order = 13, TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BgPositionsartTS { get; set; }
    }
}
