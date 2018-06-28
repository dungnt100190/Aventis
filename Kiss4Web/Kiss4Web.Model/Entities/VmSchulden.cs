using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmSchulden
    {
        public int VmSchuldenId { get; set; }
        public int FaLeistungId { get; set; }
        public int? VmSchuldtitelCode { get; set; }
        public DateTime? Datum { get; set; }
        public decimal? Betrag { get; set; }
        public DateTime? TilgungDatum { get; set; }
        public int? DocumentId { get; set; }
        public string Bemerkungen { get; set; }
        public bool IsDeleted { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmSchuldenTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
