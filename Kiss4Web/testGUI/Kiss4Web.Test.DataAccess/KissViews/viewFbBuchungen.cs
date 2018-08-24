namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewFbBuchungen")]
    public partial class viewFbBuchungen
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FbBuchungID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FbPeriodeID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BuchungTypCode { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(15)]
        public string BelegNr { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BelegNrPos { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime BuchungsDatum { get; set; }

        public int? SollKtoNr { get; set; }

        public int? HabenKtoNr { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "money")]
        public decimal Betrag { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(200)]
        public string Text { get; set; }

        public DateTime? ValutaDatum { get; set; }

        public int? Zahlungsfrist { get; set; }

        public int? BuchungStatusCode { get; set; }

        public int? FbDauerauftragID { get; set; }

        public DateTime? ErfassungsDatum { get; set; }

        public int? UserID { get; set; }

        public int? FbZahlungswegID { get; set; }

        [StringLength(50)]
        public string PCKontoNr { get; set; }

        [StringLength(50)]
        public string BankKontoNr { get; set; }

        [StringLength(50)]
        public string IBAN { get; set; }

        public int? ZahlungsArtCode { get; set; }

        [StringLength(50)]
        public string ReferenzNummer { get; set; }

        [StringLength(200)]
        public string Zahlungsgrund { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Zusatz { get; set; }

        [StringLength(200)]
        public string Strasse { get; set; }

        [StringLength(8)]
        public string PLZ { get; set; }

        [StringLength(50)]
        public string Ort { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string Creator { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime Created { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(50)]
        public string Modifier { get; set; }

        [Key]
        [Column(Order = 11)]
        public DateTime Modified { get; set; }

        [Key]
        [Column(Order = 12, TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FbBuchungTS { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(100)]
        public string SollKtoName { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(100)]
        public string HabenKtoName { get; set; }

        [Key]
        [Column(Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SollKontoTypCode { get; set; }

        [Key]
        [Column(Order = 16)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HabenKontoTypCode { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(202)]
        public string Mandant { get; set; }

        [Key]
        [Column(Order = 18)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaPersonID { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(61)]
        public string PlzOrt { get; set; }

        [StringLength(200)]
        public string MTLogon { get; set; }

        [Key]
        [Column(Order = 20)]
        [StringLength(402)]
        public string MTName { get; set; }

        [StringLength(200)]
        public string ErfLogon { get; set; }

        [Key]
        [Column(Order = 21)]
        [StringLength(402)]
        public string ErfName { get; set; }

        public int? Status { get; set; }

        [StringLength(200)]
        public string StatusText { get; set; }

        [Key]
        [Column(Order = 22)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PeriodeStatusCode { get; set; }

        public int? FbTeamID { get; set; }
    }
}
