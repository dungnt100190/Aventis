using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmVaterschaft
    {
        public int VmVaterschaftId { get; set; }
        public int FaLeistungId { get; set; }
        public string Zgbcodes { get; set; }
        public DateTime? AnerkennungDatum { get; set; }
        public string AnerkennungOrt { get; set; }
        public DateTime? Uhvdatum { get; set; }
        public decimal? Uhvbetrag { get; set; }
        public int? UhvabschlussGrundCode { get; set; }
        public DateTime? SorgerechtVereinbDatum { get; set; }
        public DateTime? Vanfechtungsurteil { get; set; }
        public DateTime? VurteilDatum { get; set; }
        public decimal? VurteilBetrag { get; set; }
        public DateTime? UnterhaltsurteilDatum { get; set; }
        public decimal? UnterhaltsurteilBetrag { get; set; }
        public DateTime? SchlussberichtAnKommission { get; set; }
        public DateTime? SchlussberichtGenehmigung { get; set; }
        public DateTime? GeburtsmitteilungDatum { get; set; }
        public string GeburtsmitteilungOrt { get; set; }
        public DateTime? GebuehrDatum { get; set; }
        public bool? GebuehrErlass { get; set; }
        public string PendenzText { get; set; }
        public DateTime? PendenzFrist { get; set; }
        public string Bemerkung { get; set; }
        public byte[] VmVaterschaftTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
