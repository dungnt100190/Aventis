using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkForderungPosition
    {
        public int IkForderungPositionId { get; set; }
        public int IkForderungId { get; set; }
        public int IkPositionId { get; set; }
        public byte[] IkForderungPositionTs { get; set; }

        public IkForderung IkForderung { get; set; }
        public IkPosition IkPosition { get; set; }
    }
}
