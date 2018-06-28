using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbMandant
    {
        public KbMandant()
        {
            KbPeriode = new HashSet<KbPeriode>();
        }

        public int KbMandantId { get; set; }
        public string Mandant { get; set; }
        public int? MandantTid { get; set; }
        public byte[] KbMandantTs { get; set; }

        public ICollection<KbPeriode> KbPeriode { get; set; }
    }
}
