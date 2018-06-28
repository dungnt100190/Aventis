using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaExterneBildung
    {
        public KaExterneBildung()
        {
            KaExterneBildungZahlung = new HashSet<KaExterneBildungZahlung>();
        }

        public int KaExterneBildungId { get; set; }
        public int BaPersonId { get; set; }
        public int? FaLeistungId { get; set; }
        public int? Kurstyp { get; set; }
        public string Bezeichnung { get; set; }
        public string Kursort { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int? AnzahlKurstage { get; set; }
        public bool Kursbestaetigung { get; set; }
        public decimal? AnteilKa { get; set; }
        public decimal? AnteilDritte { get; set; }
        public int? KaProgrammCode { get; set; }
        public bool SichtbarSdflag { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaExterneBildungTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public ICollection<KaExterneBildungZahlung> KaExterneBildungZahlung { get; set; }
    }
}
