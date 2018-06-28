using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class GvFonds
    {
        public GvFonds()
        {
            GvFondsXorgUnit = new HashSet<GvFondsXorgUnit>();
            GvGesuch = new HashSet<GvGesuch>();
        }

        public int GvFondsId { get; set; }
        public int? KbZahlungskontoId { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public string NameKurz { get; set; }
        public string NameLang { get; set; }
        public string Bemerkung { get; set; }
        public int? BemerkungTid { get; set; }
        public int GvFondsTypCode { get; set; }
        public bool IstCh { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] GvFondsTs { get; set; }

        public KbZahlungskonto KbZahlungskonto { get; set; }
        public ICollection<GvFondsXorgUnit> GvFondsXorgUnit { get; set; }
        public ICollection<GvGesuch> GvGesuch { get; set; }
    }
}
