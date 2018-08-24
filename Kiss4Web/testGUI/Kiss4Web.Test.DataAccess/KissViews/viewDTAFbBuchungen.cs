namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewDTAFbBuchungen")]
    public partial class viewDTAFbBuchungen
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FbBuchungID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Buchungsdatum { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FbKontoId { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FbDTAZugangID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KbFinanzInstitutCode { get; set; }

        public DateTime? ValutaDatum { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(15)]
        public string BelegNr { get; set; }

        [StringLength(50)]
        public string IBAN { get; set; }

        public int? DTABankId { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(20)]
        public string VertragNr { get; set; }

        public int? ZahlungsArtCode { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(201)]
        public string Mandant { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KontoNr { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(100)]
        public string KontoName { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(50)]
        public string DTAKontoNr { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(50)]
        public string DTAZugang { get; set; }

        [Key]
        [Column(Order = 12, TypeName = "money")]
        public decimal Betrag { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(342)]
        public string Kreditor { get; set; }

        [StringLength(100)]
        public string KreditorName { get; set; }

        [StringLength(200)]
        public string KreditorStrasse { get; set; }

        [StringLength(50)]
        public string KreditorZusatz { get; set; }

        [StringLength(8)]
        public string KreditorPLZ { get; set; }

        [StringLength(50)]
        public string KreditorOrt { get; set; }

        [StringLength(200)]
        public string Zahlungsgrund { get; set; }

        [StringLength(50)]
        public string PCKontoNr { get; set; }

        [StringLength(50)]
        public string BankKontoNr { get; set; }

        [StringLength(70)]
        public string BankName { get; set; }

        [StringLength(50)]
        public string BankStrasse { get; set; }

        [StringLength(10)]
        public string BankPLZ { get; set; }

        [StringLength(50)]
        public string BankOrt { get; set; }

        [StringLength(15)]
        public string ClearingNr { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(200)]
        public string StatusText { get; set; }

        public int? Status { get; set; }

        public int? FbDTAJournalID { get; set; }

        [Key]
        [Column(Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DTAStatusEdit { get; set; }
    }
}
