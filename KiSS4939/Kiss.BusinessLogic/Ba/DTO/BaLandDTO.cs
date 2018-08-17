using System;

namespace Kiss.BL.Ba.DTO
{
    class BaLandDTO
    {
        public int BfsCode { get; set; }
        public int UnID { get; set; }
        public string Iso2Id { get; set; }
        public string Iso3Id { get; set; }
        public string ShortNameDe { get; set; }
        public string ShortNameFr { get; set; }
        public string ShortNameIt { get; set; }
        public string ShortNameEn { get; set; }
        public string OfficialNameDe { get; set; }
        public string OfficialNameFr { get; set; }
        public string OfficialNameIt { get; set; }
        public int Continent { get; set; }
        public int Region { get; set; }
        public bool State { get; set; }
        public bool UnMember { get; set; }
        public DateTime UnEntryDate { get; set; }
        public bool RecognizedCh { get; set; }
        public bool EntryValid { get; set; }
        public DateTime DateOfChange { get; set; }
    }
}
