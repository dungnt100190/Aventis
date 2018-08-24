namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmVermittlungProfil")]
    public partial class vwTmVermittlungProfil
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KaVermittlungProfilID { get; set; }

        public int? LeistungID { get; set; }

        [StringLength(8000)]
        public string Branchen { get; set; }

        [StringLength(8000)]
        public string Betriebe { get; set; }

        [StringLength(8000)]
        public string Einsatzbereiche { get; set; }

        [StringLength(200)]
        public string Lehrberuf { get; set; }

        [StringLength(200)]
        public string DeutschMuendlich { get; set; }

        [StringLength(200)]
        public string DeutschSchriftlich { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool AmTelVerst { get; set; }

        [StringLength(200)]
        public string Sprachstandermittlung { get; set; }

        [StringLength(200)]
        public string VermittelbarkeitBIBIP { get; set; }

        [StringLength(200)]
        public string VermittelbarkeitSI { get; set; }

        [StringLength(100)]
        public string VermittelbarkeitBemerkung { get; set; }

        [StringLength(200)]
        public string Sucht { get; set; }

        [StringLength(200)]
        public string Suchtart { get; set; }

        [StringLength(200)]
        public string Gesundheit { get; set; }

        [StringLength(100)]
        public string GesundheitEinschraenkungen { get; set; }

        [StringLength(200)]
        public string GesundheitKoerperlich { get; set; }

        [StringLength(1000)]
        public string EinschraenkungenKoerperlich { get; set; }

        [StringLength(1000)]
        public string GesundheitBemerkung { get; set; }

        [StringLength(200)]
        public string GesundheitPsychisch { get; set; }

        [StringLength(200)]
        public string Therapie { get; set; }

        [StringLength(200)]
        public string Zuverlaessigkeit { get; set; }

        [StringLength(200)]
        public string MotivationInizio { get; set; }

        [StringLength(200)]
        public string MotivationBIBIPSI { get; set; }

        [StringLength(200)]
        public string AeussereErscheinungBIBIP { get; set; }

        [StringLength(200)]
        public string AeussereErscheinungSI { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool InfoAnSDErfolgt { get; set; }

        [StringLength(200)]
        public string Kinderbetreuung { get; set; }

        public int? Einsatzpensum { get; set; }

        public int? EinsatzpensumVon { get; set; }

        public int? EinsatzpensumBis { get; set; }

        [StringLength(1000)]
        public string BesondereWuensche { get; set; }

        [StringLength(1000)]
        public string BesondereFaehigkeiten { get; set; }

        [StringLength(200)]
        public string Fuehrerausweis { get; set; }

        [StringLength(200)]
        public string FuehrerausweisKategorie { get; set; }

        [StringLength(200)]
        public string PCKenntnisse { get; set; }

        [StringLength(200)]
        public string Ausbildung { get; set; }

        [StringLength(8000)]
        public string Arbeitszeiten { get; set; }

        [StringLength(8000)]
        public string Unterstützung { get; set; }

        public DateTime? SIGespraech { get; set; }

        [StringLength(402)]
        public string SIGespraechfuehrerin { get; set; }

        public DateTime? GespraechInizio { get; set; }

        [StringLength(200)]
        public string Ausbildungswunsch { get; set; }

        [StringLength(200)]
        public string Berufswunsch { get; set; }

        [StringLength(1000)]
        public string Bemerkungen { get; set; }

        [StringLength(1000)]
        public string ArbeitsgebietBemerkung { get; set; }

        public int? GesundheitKoerperlichBewertung { get; set; }

        public int? GesundheitPsychischBewertung { get; set; }

        public int? ZuverlaessigkeitBewertung { get; set; }

        public int? MotivationBIBIPSIBewertung { get; set; }

        [StringLength(200)]
        public string Schweizerdeutsch { get; set; }

        [StringLength(200)]
        public string LohnabtretungSD { get; set; }

        [StringLength(200)]
        public string LaufendeBetreibungen { get; set; }

        [StringLength(1000)]
        public string AktuelleTaetigkeit { get; set; }

        [StringLength(200)]
        public string Verfuegbarkeit { get; set; }

        [StringLength(1000)]
        public string EinschraenkungMontag { get; set; }

        [StringLength(1000)]
        public string EinschraenkungDienstag { get; set; }

        [StringLength(1000)]
        public string EinschraenkungMittwoch { get; set; }

        [StringLength(1000)]
        public string EinschraenkungDonnerstag { get; set; }

        [StringLength(1000)]
        public string EinschraenkungFreitag { get; set; }

        [StringLength(1000)]
        public string EinschraenkungSamstag { get; set; }

        [StringLength(1000)]
        public string EinschraenkungSonntag { get; set; }

        [StringLength(200)]
        public string Nachtarbeit { get; set; }
    }
}
