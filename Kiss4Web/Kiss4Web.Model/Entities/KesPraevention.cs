using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KesPraevention
    {
        public int KesPraeventionId { get; set; }
        public int FaLeistungId { get; set; }
        public int? UserId { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int? KesPraeventionsartCode { get; set; }
        public int? KesPraeventionsabschlussCode { get; set; }
        public string Bemerkung { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KesPraeventionTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
    }
}
