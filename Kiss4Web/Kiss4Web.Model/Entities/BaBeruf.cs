using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaBeruf
    {
        public int BaBerufId { get; set; }
        public string Beruf { get; set; }
        public string BezeichnungM { get; set; }
        public string BezeichnungW { get; set; }
        public int SortKey { get; set; }
        public int Bfscode { get; set; }
        public byte[] BaBerufTs { get; set; }
    }
}
