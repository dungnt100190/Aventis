namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmVermittlungEinsatz")]
    public partial class vwTmVermittlungEinsatz
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KaVermittlungEinsatzID { get; set; }

        public int? KaVermittlungVorschlagID { get; set; }

        public int? KaEinsatzplatzID { get; set; }

        public int? FaLeistungID { get; set; }

        public DateTime? EinsatzVon { get; set; }

        public DateTime? EinsatzBis { get; set; }

        public bool? Verlaengerung { get; set; }

        public int? Arbeitspensum { get; set; }

        public DateTime? BIEAZDatumVon { get; set; }

        public DateTime? BIEAZDatumBis { get; set; }

        public bool? BIEAZVerl { get; set; }

        [Column(TypeName = "money")]
        public decimal? BIBruttolohn { get; set; }

        public int? BIEAZFinanzierungsgrad { get; set; }

        public DateTime? Abschluss { get; set; }

        [StringLength(200)]
        public string ZustKANachname { get; set; }

        [StringLength(200)]
        public string ZustKAVorname { get; set; }

        [StringLength(10)]
        public string ZustKAKuerzel { get; set; }

        [StringLength(100)]
        public string ZustKATelephon { get; set; }

        [StringLength(100)]
        public string ZustKAEMail { get; set; }

        [StringLength(402)]
        public string ZustKANameVorname { get; set; }

        [StringLength(401)]
        public string ZustKANameVornameOhneKomma { get; set; }

        [StringLength(401)]
        public string ZustKAVornameName { get; set; }

        [StringLength(200)]
        public string Einsatzplatz { get; set; }

        [StringLength(200)]
        public string EPBranche { get; set; }

        [StringLength(200)]
        public string EPKaProgramm { get; set; }

        [StringLength(200)]
        public string EPLehrberuf { get; set; }

        [StringLength(200)]
        public string EPBerufsausbildung { get; set; }

        [StringLength(100)]
        public string Betrieb { get; set; }

        [StringLength(200)]
        public string BetriebAdressZusatz { get; set; }

        [StringLength(100)]
        public string BetriebStrasse { get; set; }

        [StringLength(10)]
        public string BetriebHausNr { get; set; }

        [StringLength(100)]
        public string BetriebPostfach { get; set; }

        [StringLength(10)]
        public string BetriebPLZ { get; set; }

        [StringLength(50)]
        public string BetriebOrt { get; set; }

        [StringLength(10)]
        public string BetriebKanton { get; set; }

        [StringLength(200)]
        public string BetriebLand { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(478)]
        public string BetriebAdresseMehrzeilig { get; set; }

        [StringLength(50)]
        public string KontaktTitel { get; set; }

        [StringLength(100)]
        public string KontaktName { get; set; }

        [StringLength(100)]
        public string KontaktVorname { get; set; }

        [StringLength(200)]
        public string KontaktGeschlecht { get; set; }

        [StringLength(100)]
        public string KontaktTelefon { get; set; }

        [StringLength(100)]
        public string KontaktTelefonMobil { get; set; }

        [StringLength(100)]
        public string KontaktFax { get; set; }

        [StringLength(100)]
        public string KontaktEmail { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(202)]
        public string KontaktNameVorname { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(201)]
        public string KontaktVornameName { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(14)]
        public string KontaktLieberLiebe { get; set; }
    }
}
