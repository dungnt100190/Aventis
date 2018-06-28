using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class WhGefKategorie
    {
        public WhGefKategorie()
        {
            BgKostenartWhGefKategorie = new HashSet<BgKostenartWhGefKategorie>();
        }

        public int WhGefKategorieId { get; set; }
        public int WhGefKategorieCode { get; set; }
        public int WhGefKategorieTypCode { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] WhGefKategorieTs { get; set; }

        public ICollection<BgKostenartWhGefKategorie> BgKostenartWhGefKategorie { get; set; }
    }
}
