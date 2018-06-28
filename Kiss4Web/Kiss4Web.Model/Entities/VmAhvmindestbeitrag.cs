using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmAhvmindestbeitrag
    {
        public int VmAhvmindestbeitragId { get; set; }
        public int FaLeistungId { get; set; }
        public int? DocumentIdIkauszug { get; set; }
        public int? DocumentIdNeutral { get; set; }
        public int? DocumentIdNeanmeldung { get; set; }
        public DateTime? IkauszugDatum { get; set; }
        public string BeitragsRechnungsJahr { get; set; }
        public decimal? Bruttolohn { get; set; }
        public DateTime? NeanmeldungDatum { get; set; }
        public int? VmQuartalCode { get; set; }
        public string Bemerkungen { get; set; }
        public bool IsDeleted { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmAhvmindestbeitragTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
