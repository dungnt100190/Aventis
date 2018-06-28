using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaQjpzassessment
    {
        public int KaQjpzassessmentId { get; set; }
        public int FaLeistungId { get; set; }
        public DateTime? DatumAssessment { get; set; }
        public bool AufgA { get; set; }
        public bool AufgB { get; set; }
        public bool AufgC { get; set; }
        public bool AufgD { get; set; }
        public bool? KandDokIn { get; set; }
        public bool ProjGefaehrFlag { get; set; }
        public string ProjGefaehrGrund { get; set; }
        public bool NichtAufgFlag { get; set; }
        public string NichtAufgGrund { get; set; }
        public bool SichtbarSdflag { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaQjpzassessmentTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
