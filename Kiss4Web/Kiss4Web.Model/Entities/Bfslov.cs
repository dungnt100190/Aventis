using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Bfslov
    {
        public Bfslov()
        {
            Bfslovcode = new HashSet<Bfslovcode>();
        }

        public string Lovname { get; set; }
        public byte[] Bfslovts { get; set; }

        public ICollection<Bfslovcode> Bfslovcode { get; set; }
    }
}
