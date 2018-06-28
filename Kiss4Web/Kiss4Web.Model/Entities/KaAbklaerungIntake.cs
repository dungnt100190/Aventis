using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaAbklaerungIntake
    {
        public int KaAbklaerungIntakeId { get; set; }
        public int FaLeistungId { get; set; }
        public DateTime? Datum { get; set; }
        public int? KaAbklaerungPhaseIntakeCode { get; set; }
        public int? KaAbklaerungStatusDossierCode { get; set; }
        public string AsdFragen { get; set; }
        public DateTime? Gespraechstermin { get; set; }
        public int? KaAbklaerungPraesenzCode { get; set; }
        public string Bemerkung { get; set; }
        public DateTime? DatumIntegration { get; set; }
        public int? KaAbklaerungIntegrBeurCode { get; set; }
        public int? KaAbklaerungGrundDossCode { get; set; }
        public bool SichtbarSdflag { get; set; }
        public int? DocumentIdIntegration { get; set; }
        public int? DocumentIdFormularAsD { get; set; }
        public int? DocumentIdZusammenfassungEg { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaAbklaerungIntakeTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
