using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class DynaValue
    {
        public int DynaValueId { get; set; }
        public int? FaPhaseId { get; set; }
        public int? FaLeistungId { get; set; }
        public int DynaFieldId { get; set; }
        public string ValueText { get; set; }
        public int GridRowId { get; set; }
        public DateTime CreationDate { get; set; }
        public byte[] DynaValueTs { get; set; }

        public DynaField DynaField { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public FaPhase FaPhase { get; set; }
    }
}
