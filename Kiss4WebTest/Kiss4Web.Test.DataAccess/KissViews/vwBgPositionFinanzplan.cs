namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwBgPositionFinanzplan")]
    public partial class vwBgPositionFinanzplan
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BgFinanzplanID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BgBudgetID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BgPositionID { get; set; }

        public int? BgPositionsartID { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "money")]
        public decimal Betrag { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "money")]
        public decimal Reduktion { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "money")]
        public decimal Abzug { get; set; }

        public int? BaPersonID { get; set; }

        public int? BaInstitutionID { get; set; }
    }
}
