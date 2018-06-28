using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmTestamentVerfuegung
    {
        public int VmTestamentVerfuegungId { get; set; }
        public int VmTestamentId { get; set; }
        public DateTime EingangsDatum { get; set; }
        public DateTime? VerfuegungsDatum { get; set; }
        public DateTime? EroeffnungsDatum { get; set; }
        public string VerfuegungText { get; set; }
        public bool? Verschlossen { get; set; }
        public int? TestamentsformCode { get; set; }
        public int? AnzSeiten { get; set; }
        public int? AufbewahrungsOrt { get; set; }
        public int? AbovorherCode { get; set; }
        public string AbovorherText { get; set; }
        public int? AbonachherCode { get; set; }
        public string AbonachherText { get; set; }
        public int? InventarCode { get; set; }
        public string Bemerkung { get; set; }
        public byte[] VmTestamentVerfuegungTs { get; set; }

        public VmTestament VmTestament { get; set; }
    }
}
