namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmGvGesuch")]
    public partial class vwTmGvGesuch
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GvGesuchID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaPersonID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime GesuchsDatum { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(40)]
        public string Gesuchsgrund { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragBewilligt { get; set; }

        public DateTime? BewilligtAm { get; set; }

        public string BegruendungMitFmt { get; set; }

        public string BegruendungOhneFmt { get; set; }

        [StringLength(2000)]
        public string Bemerkung { get; set; }

        [Column(TypeName = "money")]
        public decimal? BewilligungBetragKS1 { get; set; }

        public DateTime? BewilligungDatumKS1 { get; set; }

        public string BewilligungBemerkungKS1 { get; set; }

        [Column(TypeName = "money")]
        public decimal? BewilligungBetragKS2 { get; set; }

        public DateTime? BewilligungDatumKS2 { get; set; }

        public string BewilligungBemerkungKS2 { get; set; }

        [StringLength(200)]
        public string BewilligtVonName { get; set; }

        [StringLength(200)]
        public string BewilligtVonVorname { get; set; }

        [StringLength(100)]
        public string BewilligtVonAbteilung { get; set; }

        public DateTime? AbschlussDatum { get; set; }

        [StringLength(2000)]
        public string AbschlussgrundD { get; set; }

        [StringLength(2000)]
        public string AbschlussgrundF { get; set; }

        [StringLength(2000)]
        public string AbschlussgrundI { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragBeantragt { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "money")]
        public decimal BetragEigenleistung { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "money")]
        public decimal TotalAusFLBFond { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(402)]
        public string Mitarbeiter { get; set; }

        [StringLength(100)]
        public string KGS { get; set; }

        [StringLength(100)]
        public string Kostenstelle { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(202)]
        public string Klient { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(200)]
        public string FondsNameKurz { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(500)]
        public string FondsNameLang { get; set; }

        [StringLength(2000)]
        public string FondsBemerkungD { get; set; }

        [StringLength(2000)]
        public string FondsBemerkungF { get; set; }

        [StringLength(2000)]
        public string FondsBemerkungI { get; set; }

        [StringLength(2000)]
        public string FondsTypD { get; set; }

        [StringLength(2000)]
        public string FondsTypF { get; set; }

        [StringLength(2000)]
        public string FondsTypI { get; set; }

        [StringLength(517)]
        public string Verteiler { get; set; }

        [StringLength(1189)]
        public string VerteilerMehrzeilig { get; set; }
    }
}
