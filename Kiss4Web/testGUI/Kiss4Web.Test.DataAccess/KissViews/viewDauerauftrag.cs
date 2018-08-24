namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewDauerauftrag")]
    public partial class viewDauerauftrag
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FbDauerauftragID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string Text { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaPersonID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SollKtoNr { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HabenKtoNr { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "money")]
        public decimal Betrag { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FbZahlungswegID { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime DatumVon { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PeriodizitaetCode { get; set; }

        public int? WochentagCode { get; set; }

        public int? Monatstag1 { get; set; }

        public int? Monatstag2 { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool VorWochenende { get; set; }

        public DateTime? DatumBis { get; set; }

        [StringLength(50)]
        public string ReferenzNummer { get; set; }

        [StringLength(50)]
        public string Zahlungsgrund { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Status { get; set; }

        [Key]
        [Column(Order = 11, TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FbDauerauftragTS { get; set; }

        public int? DauerauftragDokID { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(200)]
        public string AuftragStatus { get; set; }

        public DateTime? LetzteAusfuehrung { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(200)]
        public string AuftragPeriodizitaet { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(202)]
        public string Mandant { get; set; }

        [StringLength(100)]
        public string HabenKtoName { get; set; }

        [StringLength(100)]
        public string SollKtoName { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(61)]
        public string PlzOrt { get; set; }

        public int? FbTeamID { get; set; }
    }
}
