using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkAbklaerung
    {
        public int IkAbklaerungId { get; set; }
        public int FaLeistungId { get; set; }
        public int? UserId { get; set; }
        public int? IkAbklaerungArtCode { get; set; }
        public int? IkAbklaerungAuswertungCode { get; set; }
        public DateTime? DatumAbklaerung { get; set; }
        public DateTime? DatumAuswertung { get; set; }
        public string Bemerkung { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] IkAbklaerungTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
    }
}
