using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BgKostenartWhGefKategorie
    {
        public int BgKostenartWhGefKategorieId { get; set; }
        public int BgKostenartId { get; set; }
        public int WhGefKategorieId { get; set; }
        public bool IsInkassoprovision { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BgKostenartWhGefKategorieTs { get; set; }

        public BgKostenart BgKostenart { get; set; }
        public WhGefKategorie WhGefKategorie { get; set; }
    }
}
