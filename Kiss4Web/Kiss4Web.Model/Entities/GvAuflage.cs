using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class GvAuflage
    {
        public int GvAuflageId { get; set; }
        public int GvGesuchId { get; set; }
        public int GvAuflageTypCode { get; set; }
        public DateTime Erfasst { get; set; }
        public string Gegenstand { get; set; }
        public decimal? Betrag { get; set; }
        public DateTime Faellig { get; set; }
        public bool SchriftlicheVerpflichtung { get; set; }
        public bool Erledigt { get; set; }
        public bool Erlassen { get; set; }
        public string Bemerkung { get; set; }
        public string Erlassungsgrund { get; set; }
        public decimal? Rate1Betrag { get; set; }
        public DateTime? Rate1Datum { get; set; }
        public decimal? Rate2Betrag { get; set; }
        public DateTime? Rate2Datum { get; set; }
        public decimal? Rate3Betrag { get; set; }
        public DateTime? Rate3Datum { get; set; }
        public decimal? Rate4Betrag { get; set; }
        public DateTime? Rate4Datum { get; set; }
        public decimal? Rate5Betrag { get; set; }
        public DateTime? Rate5Datum { get; set; }
        public decimal? Rate6Betrag { get; set; }
        public DateTime? Rate6Datum { get; set; }
        public decimal? Rate7Betrag { get; set; }
        public DateTime? Rate7Datum { get; set; }
        public decimal? Rate8Betrag { get; set; }
        public DateTime? Rate8Datum { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] GvAuflageTs { get; set; }

        public GvGesuch GvGesuch { get; set; }
    }
}
