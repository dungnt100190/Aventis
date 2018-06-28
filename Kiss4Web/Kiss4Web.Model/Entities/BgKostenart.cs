using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BgKostenart
    {
        public BgKostenart()
        {
            BgKostenartWhGefKategorie = new HashSet<BgKostenartWhGefKategorie>();
            BgPositionsart = new HashSet<BgPositionsart>();
            BgSpezkonto = new HashSet<BgSpezkonto>();
            GvPositionsart = new HashSet<GvPositionsart>();
            IkForderungBgKostenartBgKostenartIdAuszahlungNavigation = new HashSet<IkForderungBgKostenart>();
            IkForderungBgKostenartBgKostenartIdForderungNavigation = new HashSet<IkForderungBgKostenart>();
            IkForderungBgKostenartHist = new HashSet<IkForderungBgKostenartHist>();
            KbBuchungKostenart = new HashSet<KbBuchungKostenart>();
            KbWveinzelposten = new HashSet<KbWveinzelposten>();
        }

        public int BgKostenartId { get; set; }
        public int ModulId { get; set; }
        public string KontoNr { get; set; }
        public string Name { get; set; }
        public int? NameTid { get; set; }
        public bool Quoting { get; set; }
        public int? BgSplittingArtCode { get; set; }
        public int? BaWvzeileCode { get; set; }
        public byte[] BgKostenartTs { get; set; }

        public XModul Modul { get; set; }
        public ICollection<BgKostenartWhGefKategorie> BgKostenartWhGefKategorie { get; set; }
        public ICollection<BgPositionsart> BgPositionsart { get; set; }
        public ICollection<BgSpezkonto> BgSpezkonto { get; set; }
        public ICollection<GvPositionsart> GvPositionsart { get; set; }
        public ICollection<IkForderungBgKostenart> IkForderungBgKostenartBgKostenartIdAuszahlungNavigation { get; set; }
        public ICollection<IkForderungBgKostenart> IkForderungBgKostenartBgKostenartIdForderungNavigation { get; set; }
        public ICollection<IkForderungBgKostenartHist> IkForderungBgKostenartHist { get; set; }
        public ICollection<KbBuchungKostenart> KbBuchungKostenart { get; set; }
        public ICollection<KbWveinzelposten> KbWveinzelposten { get; set; }
    }
}
