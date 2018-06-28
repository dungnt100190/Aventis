using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkLandesindexWert
    {
        public int IkLandesindexWertId { get; set; }
        public int IkLandesindexId { get; set; }
        public int Jahr { get; set; }
        public int Monat { get; set; }
        public decimal? Wert { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] IkLandesindexWertTs { get; set; }

        public IkLandesindex IkLandesindex { get; set; }
    }
}
