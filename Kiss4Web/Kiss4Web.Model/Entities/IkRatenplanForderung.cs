using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkRatenplanForderung
    {
        public int IkRatenplanForderungId { get; set; }
        public int? IkRatenplanId { get; set; }
        public int? IkRechtstitelId { get; set; }
        public int? IkPositionId { get; set; }
        public int? IkForderungId { get; set; }
        public byte[] IkRatenplanForderungTs { get; set; }

        public IkForderung IkForderung { get; set; }
        public IkPosition IkPosition { get; set; }
        public IkRatenplan IkRatenplan { get; set; }
        public IkRechtstitel IkRechtstitel { get; set; }
    }
}
