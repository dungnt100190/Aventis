namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaQEEPQ")]
    public partial class KaQEEPQ
    {
        public int KaQEEPQID { get; set; }

        public int FaLeistungID { get; set; }

        public int? XDocumentID_Standortbestimmung1 { get; set; }

        public int? XDocumentID_Standortbestimmung2 { get; set; }

        public int? XDocumentID_Vorstellungsgespraech { get; set; }

        public bool SichtbarSDFlag { get; set; }

        public DateTime? StaoDat { get; set; }

        public int? TaetigProgrammDokID { get; set; }

        public int? PersonalblattDokID { get; set; }

        public int? ZwBericht1DokID { get; set; }

        public int? ZwBericht2DokID { get; set; }

        public bool VerlaengerungFlag { get; set; }

        public DateTime? VerlaengerungDat { get; set; }

        public int? Schlussbericht1DokID { get; set; }

        public int? Schlussbericht2DokID { get; set; }

        public int? ArbeitszeugnisDokID { get; set; }

        public int? ZwischenzeugnisDokID { get; set; }

        public DateTime? EinladungDat1 { get; set; }

        public DateTime? EinladungDat2 { get; set; }

        public int? Einladung1DokID { get; set; }

        public int? Einladung2DokID { get; set; }

        [StringLength(255)]
        public string IntakeCodes { get; set; }

        public bool? ProgBeginn { get; set; }

        public int? RueckanwortDokID { get; set; }

        public int? EinladungProgBeginn1DokID { get; set; }

        public int? EinladungProgBeginn2DokID { get; set; }

        public string Bemerkung { get; set; }

        public string IndivZieleRAV { get; set; }

        public int? IndivZieleRAVDokID { get; set; }

        public string IndivZieleRAVVerl { get; set; }

        public int? IndivZieleRAVVerlDokID { get; set; }

        public DateTime? AustrittDatum { get; set; }

        public int? AustrittGrund { get; set; }

        public int? AustrittCode { get; set; }

        public string AustrittBemerkung { get; set; }

        public DateTime? muendAuffordDat1 { get; set; }

        public DateTime? muendAuffordDat2 { get; set; }

        public string muendAuffordBem1 { get; set; }

        public string muendAuffordBem2 { get; set; }

        public int? Aufforderung1DokID { get; set; }

        public int? Aufforderung2DokID { get; set; }

        public int? Aufforderung3DokID { get; set; }

        public int? Vereinbarung1DokID { get; set; }

        public int? Vereinbarung2DokID { get; set; }

        public int? ProgAbbruchDokID { get; set; }

        public int? VerlaengerungDokID { get; set; }

        public int? VerwRegelverstossDokID { get; set; }

        public int? VerwNichterscheinenDokID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaQEEPQTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
