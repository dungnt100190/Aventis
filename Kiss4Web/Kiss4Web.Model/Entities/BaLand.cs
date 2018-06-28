using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaLand
    {
        public BaLand()
        {
            BaAdresse = new HashSet<BaAdresse>();
            BaBank = new HashSet<BaBank>();
            BaPersonNationalitaetCodeNavigation = new HashSet<BaPerson>();
            BaPersonUntWohnsitzLandCodeNavigation = new HashSet<BaPerson>();
            BaPersonWegzugLandCodeNavigation = new HashSet<BaPerson>();
            BaPersonZuzugGdeLandCodeNavigation = new HashSet<BaPerson>();
            BaPersonZuzugKtLandCodeNavigation = new HashSet<BaPerson>();
            BaZahlungsweg = new HashSet<BaZahlungsweg>();
            FbKreditor = new HashSet<FbKreditor>();
            KbBuchung = new HashSet<KbBuchung>();
        }

        public int BaLandId { get; set; }
        public string Text { get; set; }
        public string TextFr { get; set; }
        public string TextIt { get; set; }
        public string TextEn { get; set; }
        public string Iso2Code { get; set; }
        public string Iso3Code { get; set; }
        public int? Bfscode { get; set; }
        public int? SortKey { get; set; }
        public string Sapcode { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public bool Bfsdelivered { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BaLandTs { get; set; }

        public ICollection<BaAdresse> BaAdresse { get; set; }
        public ICollection<BaBank> BaBank { get; set; }
        public ICollection<BaPerson> BaPersonNationalitaetCodeNavigation { get; set; }
        public ICollection<BaPerson> BaPersonUntWohnsitzLandCodeNavigation { get; set; }
        public ICollection<BaPerson> BaPersonWegzugLandCodeNavigation { get; set; }
        public ICollection<BaPerson> BaPersonZuzugGdeLandCodeNavigation { get; set; }
        public ICollection<BaPerson> BaPersonZuzugKtLandCodeNavigation { get; set; }
        public ICollection<BaZahlungsweg> BaZahlungsweg { get; set; }
        public ICollection<FbKreditor> FbKreditor { get; set; }
        public ICollection<KbBuchung> KbBuchung { get; set; }
    }
}
