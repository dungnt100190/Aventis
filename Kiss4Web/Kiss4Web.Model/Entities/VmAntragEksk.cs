using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmAntragEksk
    {
        public int VmAntragEkskid { get; set; }
        public int FaLeistungId { get; set; }
        public int? UserId { get; set; }
        public int? DocumentId { get; set; }
        public string Antrag { get; set; }
        public string Begruendung { get; set; }
        public DateTime? DatumAntrag { get; set; }
        public DateTime? DatumGenehmigtEksk { get; set; }
        public bool IsDeleted { get; set; }
        public string Titel { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmAntragEkskts { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
    }
}
