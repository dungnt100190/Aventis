using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BgSpezkontoAbschluss
    {
        public int BgSpezkontoAbschlussId { get; set; }
        public int BgSpezkontoId { get; set; }
        public decimal Betrag { get; set; }
        public string Text { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BgSpezkontoAbschlussTs { get; set; }

        public BgSpezkonto BgSpezkonto { get; set; }
    }
}
