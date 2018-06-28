using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Bdeleistung
    {
        public int BdeleistungId { get; set; }
        public int UserId { get; set; }
        public int BdeleistungsartId { get; set; }
        public int KostenstelleOrgUnitId { get; set; }
        public int? BaPersonId { get; set; }
        public DateTime Datum { get; set; }
        public decimal? Dauer { get; set; }
        public int? Anzahl { get; set; }
        public int? LohnartCode { get; set; }
        public string Bemerkung { get; set; }
        public bool KeinExport { get; set; }
        public int HistKostentraeger { get; set; }
        public int HistKostenstelle { get; set; }
        public int HistKostenart { get; set; }
        public int HistMandantNr { get; set; }
        public bool Freigegeben { get; set; }
        public bool Visiert { get; set; }
        public DateTime? Verbucht { get; set; }
        public DateTime? VerbuchtLd { get; set; }
        public int? VerId { get; set; }
        public byte[] BdeleistungTs { get; set; }
        public bool Fakturiert { get; set; }

        public BaPerson BaPerson { get; set; }
        public Bdeleistungsart Bdeleistungsart { get; set; }
        public XUser User { get; set; }
    }
}
