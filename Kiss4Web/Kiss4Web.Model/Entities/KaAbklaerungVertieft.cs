using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaAbklaerungVertieft
    {
        public KaAbklaerungVertieft()
        {
            KaAbklaerungVertieftProbeeinsatz = new HashSet<KaAbklaerungVertieftProbeeinsatz>();
        }

        public int KaAbklaerungVertieftId { get; set; }
        public int FaLeistungId { get; set; }
        public int? KaKurserfassungId { get; set; }
        public DateTime? Datum { get; set; }
        public int? KaAbklaerungPhaseVertiefteAbklaerungenCode { get; set; }
        public int? KaAbklaerungStatusDossierCode { get; set; }
        public DateTime? DatumKursAbbruch { get; set; }
        public int? KaAbklaerungPraesenzCode { get; set; }
        public int? KaAbklaerungProbeeinsatzInCode { get; set; }
        public DateTime? EinsatzVon { get; set; }
        public DateTime? EinsatzBis { get; set; }
        public string Bemerkung { get; set; }
        public DateTime? DatumIntegration { get; set; }
        public int? KaAbklaerungIntegrBeurCode { get; set; }
        public int? DocumentIdIntegration { get; set; }
        public int? KaAbklaerungGrundDossCode { get; set; }
        public DateTime? DatumAustritt { get; set; }
        public int? DocumentIdSchlussbericht { get; set; }
        public bool SichtbarSdflag { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaAbklaerungVertieftTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public KaKurserfassung KaKurserfassung { get; set; }
        public ICollection<KaAbklaerungVertieftProbeeinsatz> KaAbklaerungVertieftProbeeinsatz { get; set; }
    }
}
