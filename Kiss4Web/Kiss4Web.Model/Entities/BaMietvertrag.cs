using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaMietvertrag
    {
        public int BaMietvertragId { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public decimal? Mietkosten { get; set; }
        public decimal? Nebenkosten { get; set; }
        public decimal? KostenanteilUe { get; set; }
        public decimal? Mietdepot { get; set; }
        public int? BaInstitutionId { get; set; }
        public string Bemerkung { get; set; }
        public byte[] BaMietvertragTs { get; set; }
        public int? BaPersonId { get; set; }
        public DateTime? GarantieBis { get; set; }
        public bool? MieteAbgetreten { get; set; }
        public decimal? Mietzinsgarantie { get; set; }

        public BaInstitution BaInstitution { get; set; }
        public BaPerson BaPerson { get; set; }
    }
}
