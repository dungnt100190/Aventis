using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class ShEinzelzahlung
    {
        public int ShEinzelzahlungId { get; set; }
        public int BgBudgetId { get; set; }
        public int? BaPersonId { get; set; }
        public int ShBelegId { get; set; }
        public int? FlKostenartId { get; set; }
        public int? BgSpezkontoId { get; set; }
        public int? BgPositionsartId { get; set; }
        public DateTime? RechnungDatum { get; set; }
        public string NameEinzelzahlung { get; set; }
        public decimal Betrag { get; set; }
        public decimal? BetragAnfrage { get; set; }
        public int ShStatusEinzelzahlungCode { get; set; }
        public string Bemerkung { get; set; }
        public byte[] ShEinzelzahlungTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public BgBudget BgBudget { get; set; }
        public BgPositionsart BgPositionsart { get; set; }
        public BgSpezkonto BgSpezkonto { get; set; }
    }
}
