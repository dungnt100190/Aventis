using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BfsdossierPerson
    {
        public BfsdossierPerson()
        {
            Bfswert = new HashSet<Bfswert>();
        }

        public int BfsdossierPersonId { get; set; }
        public int BfsdossierId { get; set; }
        public int BfspersonCode { get; set; }
        public int PersonIndex { get; set; }
        public string PersonName { get; set; }
        public int? BaPersonId { get; set; }
        public byte[] BfsdossierPersonTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public Bfsdossier Bfsdossier { get; set; }
        public ICollection<Bfswert> Bfswert { get; set; }
    }
}
