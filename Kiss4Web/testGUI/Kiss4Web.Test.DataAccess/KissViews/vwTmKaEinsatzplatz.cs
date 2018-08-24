namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmKaEinsatzplatz")]
    public partial class vwTmKaEinsatzplatz
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KaEinsatzplatzID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        public string Aktiv { get; set; }

        [StringLength(200)]
        public string Bezeichnung { get; set; }

        [StringLength(200)]
        public string Branche { get; set; }

        [StringLength(100)]
        public string Betrieb { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(174)]
        public string BetriebAdresse { get; set; }

        [StringLength(2000)]
        public string Stellenbeschreibung { get; set; }

        [StringLength(200)]
        public string KAProgramm { get; set; }

        [StringLength(402)]
        public string ZustaendigKA { get; set; }

        [StringLength(200)]
        public string Lehrberuf { get; set; }

        [StringLength(200)]
        public string TypAusbildung { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(4)]
        public string NeuGeschLehrstelle { get; set; }

        public DateTime? ErfasstAm { get; set; }

        public DateTime? EinsatzAb { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(4)]
        public string unbefristet { get; set; }

        public int? Gesamtpensum { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(4)]
        public string aufteilbar { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(4)]
        public string PensumUnbestimmt { get; set; }

        public int? EinzelpensumVon { get; set; }

        public int? EinzelpensumBis { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(4)]
        public string Fuehrerausweis { get; set; }

        [StringLength(200)]
        public string FuehrerausweisKat { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(4)]
        public string PCKenntnisse { get; set; }

        [StringLength(200)]
        public string Geschlecht { get; set; }

        [StringLength(2000)]
        public string WeitereAnforderungen { get; set; }

        [StringLength(200)]
        public string DeutschMuendlich { get; set; }

        [StringLength(200)]
        public string DeutschSchriftlich { get; set; }

        [StringLength(200)]
        public string Ausbildung { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(202)]
        public string Kontaktperson { get; set; }

        [StringLength(200)]
        public string KontaktFunktion { get; set; }

        [StringLength(2000)]
        public string KontaktBemerkung { get; set; }

        [StringLength(100)]
        public string KontaktTelefon { get; set; }

        [StringLength(100)]
        public string KontaktTelefonMobil { get; set; }

        [StringLength(100)]
        public string KontaktFax { get; set; }

        [StringLength(100)]
        public string KontaktEMail { get; set; }
    }
}
