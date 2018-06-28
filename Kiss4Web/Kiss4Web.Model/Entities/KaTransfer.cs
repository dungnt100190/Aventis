using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaTransfer
    {
        public int KaTransferId { get; set; }
        public int FaLeistungId { get; set; }
        public bool SichtbarSdflag { get; set; }
        public DateTime? TelErstkontaktDat { get; set; }
        public int? RueckmeldungRavdokId { get; set; }
        public DateTime? DatumVg { get; set; }
        public int? SituationserfassungVgdokId { get; set; }
        public int? EntwicklungsverlaufDokId { get; set; }
        public int? PersonalblattDokId { get; set; }
        public int? FaehigkeitsprofilDokId { get; set; }
        public int? ArbeitsprobenDokId { get; set; }
        public int? SchlussberichtDokId { get; set; }
        public int? TeilnahmebestaetigungDokId { get; set; }
        public string AllgZiele { get; set; }
        public int? AllgZieleDokId { get; set; }
        public string Bewerbungsstrategie { get; set; }
        public DateTime? MuendAufforderungDat1 { get; set; }
        public DateTime? MuendAufforderungDat2 { get; set; }
        public string MuendAufforderungBem1 { get; set; }
        public string MuendAufforderungBem2 { get; set; }
        public int? Aufforderung1DokId { get; set; }
        public int? Aufforderung2DokId { get; set; }
        public int? Aufforderung3DokId { get; set; }
        public int? Vereinbarung1DokId { get; set; }
        public int? Vereinbarung2DokId { get; set; }
        public int? RegelverstossDokId { get; set; }
        public int? NichterscheinenDokId { get; set; }
        public int? ProgrammabbruchDokId { get; set; }
        public DateTime? AustrittDat { get; set; }
        public int? AustrittGrund { get; set; }
        public int? AustrittCode { get; set; }
        public string AustrittBem { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaTransferTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
