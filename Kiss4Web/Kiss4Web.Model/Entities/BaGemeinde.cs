using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaGemeinde
    {
        public BaGemeinde()
        {
            BaPersonHeimatgemeindeBaGemeinde = new HashSet<BaPerson>();
            BaPersonHeimatgemeindeCodeNavigation = new HashSet<BaPerson>();
            BaPersonWegzugOrtCodeNavigation = new HashSet<BaPerson>();
            BaPersonZuzugGdeOrtCodeNavigation = new HashSet<BaPerson>();
            BgFinanzplanBaPerson = new HashSet<BgFinanzplanBaPerson>();
            VmMandant = new HashSet<VmMandant>();
        }

        public int BaGemeindeId { get; set; }
        public int? Bfscode { get; set; }
        public int? Plz { get; set; }
        public string Name { get; set; }
        public string NameLang { get; set; }
        public int? NameTid { get; set; }
        public int? GemeindeEintragArt { get; set; }
        public int? GemeindeStatus { get; set; }
        public int? GemeindeAufnahmeNummer { get; set; }
        public int? GemeindeAufnahmeModus { get; set; }
        public DateTime? GemeindeAufnahmeDatum { get; set; }
        public int? GemeindeAufhebungNummer { get; set; }
        public int? GemeindeAufhebungModus { get; set; }
        public DateTime? GemeindeAufhebungDatum { get; set; }
        public DateTime? GemeindeAenderungDatum { get; set; }
        public int? GemeindeHistorisierungId { get; set; }
        public int? BezirkCode { get; set; }
        public string BezirkName { get; set; }
        public string BezirkNameLang { get; set; }
        public int? BezirkNameTid { get; set; }
        public int? BezirkEintragArt { get; set; }
        public int? BezirkAufnahmeNummer { get; set; }
        public int? BezirkAufnahmeModus { get; set; }
        public DateTime? BezirkAufnahmeDatum { get; set; }
        public int? BezirkAufhebungNummer { get; set; }
        public int? BezirkAufhebungModus { get; set; }
        public DateTime? BezirkAufhebungDatum { get; set; }
        public DateTime? BezirkAenderungDatum { get; set; }
        public int? KantonId { get; set; }
        public string Kanton { get; set; }
        public string KantonNameLang { get; set; }
        public bool? Bfsdelivered { get; set; }
        public byte[] BaGemeindeTs { get; set; }

        public ICollection<BaPerson> BaPersonHeimatgemeindeBaGemeinde { get; set; }
        public ICollection<BaPerson> BaPersonHeimatgemeindeCodeNavigation { get; set; }
        public ICollection<BaPerson> BaPersonWegzugOrtCodeNavigation { get; set; }
        public ICollection<BaPerson> BaPersonZuzugGdeOrtCodeNavigation { get; set; }
        public ICollection<BgFinanzplanBaPerson> BgFinanzplanBaPerson { get; set; }
        public ICollection<VmMandant> VmMandant { get; set; }
    }
}
