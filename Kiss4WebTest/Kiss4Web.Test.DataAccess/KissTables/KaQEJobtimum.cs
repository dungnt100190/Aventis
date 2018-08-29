namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaQEJobtimum")]
    public partial class KaQEJobtimum
    {
        public int KaQEJobtimumID { get; set; }

        public int FaLeistungID { get; set; }

        public DateTime? ZielDat1 { get; set; }

        public DateTime? ZielDat2 { get; set; }

        public DateTime? ZielDat3 { get; set; }

        public DateTime? ZielDat4 { get; set; }

        public int? ZielCode1 { get; set; }

        public int? ZielCode2 { get; set; }

        public int? ZielCode3 { get; set; }

        public int? ZielCode4 { get; set; }

        public int? Ziel1DokID { get; set; }

        public int? Ziel2DokID { get; set; }

        public int? Ziel3DokID { get; set; }

        public int? Ziel4DokID { get; set; }

        public int? ZwischenberichtDokID { get; set; }

        public int? SchlussberichtDokID { get; set; }

        public int? Schlussbericht1DokID { get; set; }

        public int? TeilnahmebestDokID { get; set; }

        public DateTime? EinladungDat1 { get; set; }

        public DateTime? EinladungDat2 { get; set; }

        public int? Einladung1DokID { get; set; }

        public int? Einladung2DokID { get; set; }

        public bool Einladung1Flag { get; set; }

        public bool Einladung2Flag { get; set; }

        public bool? ProgBeginnOLD { get; set; }

        public int? ProgBeginnCodeOLD { get; set; }

        public bool ChecklisteFlag { get; set; }

        public bool HausordnungFlag { get; set; }

        public bool HausrundgangFlag { get; set; }

        public bool UnterlagenFlag { get; set; }

        public string Bemerkung { get; set; }

        public DateTime? TerminDat { get; set; }

        public string Zusatzinfos { get; set; }

        public DateTime? muendAuffordDat1 { get; set; }

        public DateTime? muendAuffordDat2 { get; set; }

        public string muendAuffordBem1 { get; set; }

        public string muendAuffordBem2 { get; set; }

        public int? Verwarnung1DokID { get; set; }

        public int? Verwarnung2DokID { get; set; }

        public int? Verwarnung1aDokID { get; set; }

        public int? Verwarnung2aDokID { get; set; }

        public int? ProgAbbruchDokID { get; set; }

        public DateTime? AustrittDatum { get; set; }

        public int? AustrittGrund { get; set; }

        public int? AustrittCode { get; set; }

        public string AustrittBemerkung { get; set; }

        public bool SichtbarSDFlag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaQEJobtimumTS { get; set; }

        public int? ProgAbbruch2DokID { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
