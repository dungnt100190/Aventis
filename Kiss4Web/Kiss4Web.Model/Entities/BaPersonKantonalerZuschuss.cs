using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaPersonKantonalerZuschuss
    {
        public int BaPersonKantonalerZuschussId { get; set; }
        public int BaPersonId { get; set; }
        public int BaKantonalerZuschussId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public byte[] BaPersonKantonalerZuschussTs { get; set; }

        public BaKantonalerZuschuss BaKantonalerZuschuss { get; set; }
        public BaPerson BaPerson { get; set; }
    }
}
