using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Bdeleistungsart
    {
        public Bdeleistungsart()
        {
            Bdeleistung = new HashSet<Bdeleistung>();
            BdeuserGroupBdeleistungsart = new HashSet<BdeuserGroupBdeleistungsart>();
            FsReduktion = new HashSet<FsReduktion>();
        }

        public int BdeleistungsartId { get; set; }
        public string Bezeichnung { get; set; }
        public int? BezeichnungTid { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int? SortKey { get; set; }
        public int? KlientErfassungCode { get; set; }
        public int? AnzahlCode { get; set; }
        public string ArtikelNr { get; set; }
        public int LeistungsartTypCode { get; set; }
        public int? KostenartCode { get; set; }
        public string Ktrstandard { get; set; }
        public string Ktriv { get; set; }
        public string Ktrahv { get; set; }
        public string Ktrnichtberechtigte { get; set; }
        public string Beschreibung { get; set; }
        public int? AuswDienstleistungCode { get; set; }
        public int? AuswFakturaCode { get; set; }
        public int? AuswProduktCode { get; set; }
        public int? AuswPiauftragCode { get; set; }
        public byte[] BdeleistungsartTs { get; set; }
        public int? VerId { get; set; }

        public ICollection<Bdeleistung> Bdeleistung { get; set; }
        public ICollection<BdeuserGroupBdeleistungsart> BdeuserGroupBdeleistungsart { get; set; }
        public ICollection<FsReduktion> FsReduktion { get; set; }
    }
}
