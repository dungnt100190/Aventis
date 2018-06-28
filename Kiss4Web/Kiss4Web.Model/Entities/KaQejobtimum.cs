using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaQejobtimum
    {
        public int KaQejobtimumId { get; set; }
        public int FaLeistungId { get; set; }
        public DateTime? ZielDat1 { get; set; }
        public DateTime? ZielDat2 { get; set; }
        public DateTime? ZielDat3 { get; set; }
        public DateTime? ZielDat4 { get; set; }
        public int? ZielCode1 { get; set; }
        public int? ZielCode2 { get; set; }
        public int? ZielCode3 { get; set; }
        public int? ZielCode4 { get; set; }
        public int? Ziel1DokId { get; set; }
        public int? Ziel2DokId { get; set; }
        public int? Ziel3DokId { get; set; }
        public int? Ziel4DokId { get; set; }
        public int? ZwischenberichtDokId { get; set; }
        public int? SchlussberichtDokId { get; set; }
        public int? Schlussbericht1DokId { get; set; }
        public int? TeilnahmebestDokId { get; set; }
        public DateTime? EinladungDat1 { get; set; }
        public DateTime? EinladungDat2 { get; set; }
        public int? Einladung1DokId { get; set; }
        public int? Einladung2DokId { get; set; }
        public bool Einladung1Flag { get; set; }
        public bool Einladung2Flag { get; set; }
        public bool? ProgBeginnOld { get; set; }
        public int? ProgBeginnCodeOld { get; set; }
        public bool ChecklisteFlag { get; set; }
        public bool HausordnungFlag { get; set; }
        public bool HausrundgangFlag { get; set; }
        public bool UnterlagenFlag { get; set; }
        public string Bemerkung { get; set; }
        public DateTime? TerminDat { get; set; }
        public string Zusatzinfos { get; set; }
        public DateTime? MuendAuffordDat1 { get; set; }
        public DateTime? MuendAuffordDat2 { get; set; }
        public string MuendAuffordBem1 { get; set; }
        public string MuendAuffordBem2 { get; set; }
        public int? Verwarnung1DokId { get; set; }
        public int? Verwarnung2DokId { get; set; }
        public int? Verwarnung1aDokId { get; set; }
        public int? Verwarnung2aDokId { get; set; }
        public int? ProgAbbruchDokId { get; set; }
        public DateTime? AustrittDatum { get; set; }
        public int? AustrittGrund { get; set; }
        public int? AustrittCode { get; set; }
        public string AustrittBemerkung { get; set; }
        public bool SichtbarSdflag { get; set; }
        public byte[] KaQejobtimumTs { get; set; }
        public int? ProgAbbruch2DokId { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
