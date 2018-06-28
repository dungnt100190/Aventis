using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class HistBdeleistung
    {
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
        public int VerId { get; set; }
        public int? VerIdDeleted { get; set; }
        public bool Fakturiert { get; set; }
        public int BdeleistungId { get; set; }
    }
}
