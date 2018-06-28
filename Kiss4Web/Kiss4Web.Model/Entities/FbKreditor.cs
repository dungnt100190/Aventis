using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FbKreditor
    {
        public FbKreditor()
        {
            FbZahlungsweg = new HashSet<FbZahlungsweg>();
        }

        public int FbKreditorId { get; set; }
        public string Name { get; set; }
        public string KurzName { get; set; }
        public string Zusatz { get; set; }
        public string Strasse { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
        public bool? Aktiv { get; set; }
        public int? AufwandKonto { get; set; }
        public int? BaLandId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FbKreditorTs { get; set; }

        public BaLand BaLand { get; set; }
        public ICollection<FbZahlungsweg> FbZahlungsweg { get; set; }
    }
}
