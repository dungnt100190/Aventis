using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbPeriodeUser
    {
        public int KbPeriodeId { get; set; }
        public int UserId { get; set; }
        public byte[] KbPeriodeUserTs { get; set; }

        public KbPeriode KbPeriode { get; set; }
        public XUser User { get; set; }
    }
}
