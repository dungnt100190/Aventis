using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Bfswert
    {
        public int BfswertId { get; set; }
        public int BfsdossierId { get; set; }
        public int? BfsdossierPersonId { get; set; }
        public int BfsfrageId { get; set; }
        public string PlausiFehler { get; set; }
        public byte[] BfswertTs { get; set; }

        public Bfsdossier Bfsdossier { get; set; }
        public BfsdossierPerson BfsdossierPerson { get; set; }
        public Bfsfrage Bfsfrage { get; set; }
    }
}
