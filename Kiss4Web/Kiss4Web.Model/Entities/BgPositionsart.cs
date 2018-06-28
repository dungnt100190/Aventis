using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BgPositionsart
    {
        public BgPositionsart()
        {
            BgPosition = new HashSet<BgPosition>();
            BgPositionsartBuchungstextBgPositionsart = new HashSet<BgPositionsartBuchungstext>();
            BgPositionsartBuchungstextBgPositionsartIdUseTextNavigation = new HashSet<BgPositionsartBuchungstext>();
            BgSpezkonto = new HashSet<BgSpezkonto>();
            ShEinzelzahlung = new HashSet<ShEinzelzahlung>();
            XpermissionValue = new HashSet<XpermissionValue>();
        }

        public int BgPositionsartId { get; set; }
        public int BgKategorieCode { get; set; }
        public int BgGruppeCode { get; set; }
        public string Name { get; set; }
        public string HilfeText { get; set; }
        public int SortKey { get; set; }
        public int? BgKostenartId { get; set; }
        public int? NrmKontoCode { get; set; }
        public bool? VerwaltungSdDefault { get; set; }
        public bool Spezkonto { get; set; }
        public bool ProPerson { get; set; }
        public bool ProUe { get; set; }
        public int MasterbudgetEditMask { get; set; }
        public int MonatsbudgetEditMask { get; set; }
        public int ModulId { get; set; }
        public string SqlRichtlinie { get; set; }
        public byte[] BgPositionsartTs { get; set; }
        public string VarName { get; set; }
        public bool? Verrechenbar { get; set; }
        public bool ErzeugtBfsDossier { get; set; }
        public string Bemerkung { get; set; }
        public int? NameTid { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int? BgPositionsartCode { get; set; }
        public int? BgPositionsartIdCopyOf { get; set; }
        public bool System { get; set; }
        public bool KreditorEingeschraenkt { get; set; }

        public BgKostenart BgKostenart { get; set; }
        public XModul Modul { get; set; }
        public ICollection<BgPosition> BgPosition { get; set; }
        public ICollection<BgPositionsartBuchungstext> BgPositionsartBuchungstextBgPositionsart { get; set; }
        public ICollection<BgPositionsartBuchungstext> BgPositionsartBuchungstextBgPositionsartIdUseTextNavigation { get; set; }
        public ICollection<BgSpezkonto> BgSpezkonto { get; set; }
        public ICollection<ShEinzelzahlung> ShEinzelzahlung { get; set; }
        public ICollection<XpermissionValue> XpermissionValue { get; set; }
    }
}
