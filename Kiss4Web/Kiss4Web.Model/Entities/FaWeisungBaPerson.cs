using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaWeisungBaPerson
    {
        public int FaWeisungBaPersonId { get; set; }
        public int FaWeisungId { get; set; }
        public int BaPersonId { get; set; }
        public byte[] FaWeisungBaPersonTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public FaWeisung FaWeisung { get; set; }
    }
}
