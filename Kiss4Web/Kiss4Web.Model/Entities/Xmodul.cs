using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XModul
    {
        public XModul()
        {
            BgKostenart = new HashSet<BgKostenart>();
            BgPositionsart = new HashSet<BgPositionsart>();
            DynaMask = new HashSet<DynaMask>();
            FaLeistung = new HashSet<FaLeistung>();
            KbKostenstelle = new HashSet<KbKostenstelle>();
            Xbookmark = new HashSet<Xbookmark>();
            Xclass = new HashSet<XClass>();
            XdocContextTemplate = new HashSet<XdocContextTemplate>();
            Xlov = new HashSet<Xlov>();
            XorgUnit = new HashSet<XOrgUnit>();
            Xrule = new HashSet<Xrule>();
            Xtable = new HashSet<Xtable>();
            Xuser = new HashSet<XUser>();
        }

        public int ModulId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int? SortKey { get; set; }
        public string NameSpace { get; set; }
        public string DbPrefix { get; set; }
        public bool? ModulTree { get; set; }
        public string Description { get; set; }
        public bool System { get; set; }
        public byte[] XmodulTs { get; set; }
        public bool Licensed { get; set; }

        public ICollection<BgKostenart> BgKostenart { get; set; }
        public ICollection<BgPositionsart> BgPositionsart { get; set; }
        public ICollection<DynaMask> DynaMask { get; set; }
        public ICollection<FaLeistung> FaLeistung { get; set; }
        public ICollection<KbKostenstelle> KbKostenstelle { get; set; }
        public ICollection<Xbookmark> Xbookmark { get; set; }
        public ICollection<XClass> Xclass { get; set; }
        public ICollection<XdocContextTemplate> XdocContextTemplate { get; set; }
        public ICollection<Xlov> Xlov { get; set; }
        public ICollection<XOrgUnit> XorgUnit { get; set; }
        public ICollection<Xrule> Xrule { get; set; }
        public ICollection<Xtable> Xtable { get; set; }
        public ICollection<XUser> Xuser { get; set; }
    }
}
