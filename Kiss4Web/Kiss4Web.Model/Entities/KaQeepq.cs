using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaQeepq
    {
        public int KaQeepqid { get; set; }
        public int FaLeistungId { get; set; }
        public int? XdocumentIdStandortbestimmung1 { get; set; }
        public int? XdocumentIdStandortbestimmung2 { get; set; }
        public int? XdocumentIdVorstellungsgespraech { get; set; }
        public bool SichtbarSdflag { get; set; }
        public DateTime? StaoDat { get; set; }
        public int? TaetigProgrammDokId { get; set; }
        public int? PersonalblattDokId { get; set; }
        public int? ZwBericht1DokId { get; set; }
        public int? ZwBericht2DokId { get; set; }
        public bool VerlaengerungFlag { get; set; }
        public DateTime? VerlaengerungDat { get; set; }
        public int? Schlussbericht1DokId { get; set; }
        public int? Schlussbericht2DokId { get; set; }
        public int? ArbeitszeugnisDokId { get; set; }
        public int? ZwischenzeugnisDokId { get; set; }
        public DateTime? EinladungDat1 { get; set; }
        public DateTime? EinladungDat2 { get; set; }
        public int? Einladung1DokId { get; set; }
        public int? Einladung2DokId { get; set; }
        public string IntakeCodes { get; set; }
        public bool? ProgBeginn { get; set; }
        public int? RueckanwortDokId { get; set; }
        public int? EinladungProgBeginn1DokId { get; set; }
        public int? EinladungProgBeginn2DokId { get; set; }
        public string Bemerkung { get; set; }
        public string IndivZieleRav { get; set; }
        public int? IndivZieleRavdokId { get; set; }
        public string IndivZieleRavverl { get; set; }
        public int? IndivZieleRavverlDokId { get; set; }
        public DateTime? AustrittDatum { get; set; }
        public int? AustrittGrund { get; set; }
        public int? AustrittCode { get; set; }
        public string AustrittBemerkung { get; set; }
        public DateTime? MuendAuffordDat1 { get; set; }
        public DateTime? MuendAuffordDat2 { get; set; }
        public string MuendAuffordBem1 { get; set; }
        public string MuendAuffordBem2 { get; set; }
        public int? Aufforderung1DokId { get; set; }
        public int? Aufforderung2DokId { get; set; }
        public int? Aufforderung3DokId { get; set; }
        public int? Vereinbarung1DokId { get; set; }
        public int? Vereinbarung2DokId { get; set; }
        public int? ProgAbbruchDokId { get; set; }
        public int? VerlaengerungDokId { get; set; }
        public int? VerwRegelverstossDokId { get; set; }
        public int? VerwNichterscheinenDokId { get; set; }
        public byte[] KaQeepqts { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
