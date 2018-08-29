namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwBgPosition")]
    public partial class vwBgPosition
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BgPositionID { get; set; }

        public int? BgPositionID_Parent { get; set; }

        public int? BgPositionID_CopyOf { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BgBudgetID { get; set; }

        public int? BaPersonID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BgKategorieCode { get; set; }

        public int? BgPositionsartID { get; set; }

        public int? ShBelegID { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "money")]
        public decimal Betrag { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "money")]
        public decimal Reduktion { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "money")]
        public decimal Abzug { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragEff { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "money")]
        public decimal MaxBeitragSD { get; set; }

        [StringLength(100)]
        public string Buchungstext { get; set; }

        public int? BgSpezkontoID { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool VerwaltungSD { get; set; }

        public string Bemerkung { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int? BaInstitutionID { get; set; }

        public int? DebitorBaPersonID { get; set; }

        public DateTime? VerwPeriodeVon { get; set; }

        public DateTime? VerwPeriodeBis { get; set; }

        public DateTime? FaelligAm { get; set; }

        public DateTime? RechnungDatum { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BgBewilligungStatusCode { get; set; }

        public int? ErstelltUserID { get; set; }

        public DateTime? ErstelltDatum { get; set; }

        public int? MutiertUserID { get; set; }

        public DateTime? MutiertDatum { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BgPositionTS { get; set; }

        public int? BgPositionID_AutoForderung { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragFinanzplan { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragBudget { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragRechnung { get; set; }
    }
}
