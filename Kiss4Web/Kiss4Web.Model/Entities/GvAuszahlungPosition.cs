using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class GvAuszahlungPosition
    {
        public GvAuszahlungPosition()
        {
            GvAuszahlungPositionValuta = new HashSet<GvAuszahlungPositionValuta>();
            KbBuchungKostenart = new HashSet<KbBuchungKostenart>();
        }

        public int GvAuszahlungPositionId { get; set; }
        public int GvGesuchId { get; set; }
        public int GvPositionsartId { get; set; }
        public int BaZahlungswegId { get; set; }
        public decimal Betrag { get; set; }
        public DateTime? ValutaDatum { get; set; }
        public string ReferenzNummer { get; set; }
        public string Zahlungsinstruktion { get; set; }
        public int GvAuszahlungTerminArtCode { get; set; }
        public int GvAuszahlungArtCode { get; set; }
        public int GvAuszahlungPositionStatusCode { get; set; }
        public string MitteilungZeile1 { get; set; }
        public string MitteilungZeile2 { get; set; }
        public string MitteilungZeile3 { get; set; }
        public string MitteilungZeile4 { get; set; }
        public string BuchungsText { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] GvAuszahlungPositionTs { get; set; }

        public BaZahlungsweg BaZahlungsweg { get; set; }
        public GvGesuch GvGesuch { get; set; }
        public GvPositionsart GvPositionsart { get; set; }
        public ICollection<GvAuszahlungPositionValuta> GvAuszahlungPositionValuta { get; set; }
        public ICollection<KbBuchungKostenart> KbBuchungKostenart { get; set; }
    }
}
