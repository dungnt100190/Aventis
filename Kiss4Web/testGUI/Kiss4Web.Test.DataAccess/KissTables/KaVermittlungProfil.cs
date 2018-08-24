namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaVermittlungProfil")]
    public partial class KaVermittlungProfil
    {
        public int KaVermittlungProfilID { get; set; }

        public int? FaLeistungID { get; set; }

        public int? AeussereErscheinungCode { get; set; }

        [StringLength(1000)]
        public string AktuelleTaetigkeit { get; set; }

        [StringLength(1000)]
        public string ArbeitsgebietBemerkungen { get; set; }

        [StringLength(100)]
        public string ArbeitszeitenCodes { get; set; }

        public int? AusbildungCode { get; set; }

        public int? AusbildungstypWunschCode { get; set; }

        [StringLength(1000)]
        public string Bemerkungen { get; set; }

        [StringLength(1000)]
        public string BesondereFaehigkeiten { get; set; }

        [StringLength(1000)]
        public string BesondereWuensche { get; set; }

        [StringLength(100)]
        public string BrancheCodes { get; set; }

        public int? DeutschMuendlichCode { get; set; }

        public int? DeutschSchriftlichCode { get; set; }

        [StringLength(100)]
        public string EinsatzbereichCodes { get; set; }

        public int? Einsatzpensum { get; set; }

        public int? EinsatzpensumBis { get; set; }

        public int? EinsatzpensumVon { get; set; }

        public int? FuehrerausweisCode { get; set; }

        public int? FuehrerausweisKategorieCode { get; set; }

        public DateTime? GespraechDatum { get; set; }

        [StringLength(1000)]
        public string GesundheitBemerkung { get; set; }

        public int? GesundheitCode { get; set; }

        [StringLength(100)]
        public string GesundheitEinschraenkungen { get; set; }

        public int? GesundheitKoerperlichBewertung { get; set; }

        public int? GesundheitKoerperlichCode { get; set; }

        public int? GesundheitPsychischBewertung { get; set; }

        public int? GesundheitPsychischCode { get; set; }

        public bool InfoAnSDErfolgt { get; set; }

        public int? InizioErstgesprVerlaufDokID { get; set; }

        public DateTime? Interview { get; set; }

        public bool IstAngemeldet { get; set; }

        [StringLength(100)]
        public string KaBetriebCodes { get; set; }

        public int? KaLaufendeBetreibungenCode { get; set; }

        public int? KaLohnabtretungSDCode { get; set; }

        public int? KaNachtarbeitCode { get; set; }

        public bool KannSichAmTelVerstaendigen { get; set; }

        public int? KaSchweizerdeutschCode { get; set; }

        public int? KaVerfuegbarkeitCode { get; set; }

        public int? Kinderbetreuung { get; set; }

        public int? LehrberufCode { get; set; }

        public int? Lehrberuf2Code { get; set; }

        public int? Lehrberuf3Code { get; set; }

        public int? LehrberufWunschCode { get; set; }

        public bool MigrationKA { get; set; }

        public int? MotivationBIBIPSIBewertung { get; set; }

        public int? MotivationBIBIPSICode { get; set; }

        public int? MotivationInizioCode { get; set; }

        public int? PCKenntnisseCode { get; set; }

        public bool QJExtern { get; set; }

        public bool SichtbarSDFlag { get; set; }

        public DateTime? SIGespraech { get; set; }

        public int? SIGespraechfuehrerinID { get; set; }

        public int? Sprachstandermittlung { get; set; }

        public int? SuchtartCode { get; set; }

        public int? SuchtCode { get; set; }

        public int? TherpieCode { get; set; }

        [StringLength(100)]
        public string UnterstuetzungInizioCodes { get; set; }

        [StringLength(1000)]
        public string EinschraenkungMO { get; set; }

        [StringLength(1000)]
        public string EinschraenkungDI { get; set; }

        [StringLength(1000)]
        public string EinschraenkungMI { get; set; }

        [StringLength(1000)]
        public string EinschraenkungDO { get; set; }

        [StringLength(1000)]
        public string EinschraenkungFR { get; set; }

        [StringLength(1000)]
        public string EinschraenkungSA { get; set; }

        [StringLength(1000)]
        public string EinschraenkungSO { get; set; }

        [StringLength(100)]
        public string VermittelbarkeitBemerkung { get; set; }

        public int? VermittelbarkeitBIBIPCode { get; set; }

        public int? VermittelbarkeitSICode { get; set; }

        public int? VermittlungsgespraechDokID { get; set; }

        public int? ZuverlaessigkeitBewertung { get; set; }

        public int? ZuverlaessigkeitCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaVermittlungProfilTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
