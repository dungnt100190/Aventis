using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class GvPositionsart
    {
        public GvPositionsart()
        {
            GvAuszahlungPosition = new HashSet<GvAuszahlungPosition>();
            InverseGvPositionsartIdCopyOfNavigation = new HashSet<GvPositionsart>();
        }

        public int GvPositionsartId { get; set; }
        public int? GvPositionsartIdCopyOf { get; set; }
        public int BgKostenartId { get; set; }
        public string Bezeichnung { get; set; }
        public int? BezeichnungTid { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public bool Hsonly { get; set; }
        public bool IsFlb { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] GvPositionsartTs { get; set; }

        public BgKostenart BgKostenart { get; set; }
        public GvPositionsart GvPositionsartIdCopyOfNavigation { get; set; }
        public GvPositionsart GvPositionsartNavigation { get; set; }
        public GvPositionsart InverseGvPositionsartNavigation { get; set; }
        public ICollection<GvAuszahlungPosition> GvAuszahlungPosition { get; set; }
        public ICollection<GvPositionsart> InverseGvPositionsartIdCopyOfNavigation { get; set; }
    }
}
