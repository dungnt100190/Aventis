using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaLeistungArchiv
    {
        public int FaLeistungArchivId { get; set; }
        public int ArchiveId { get; set; }
        public int FaLeistungId { get; set; }
        public string ArchivNr { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int CheckInUserId { get; set; }
        public int? CheckOutUserId { get; set; }
        public byte[] FaLeistungArchivTs { get; set; }

        public Xarchive Archive { get; set; }
        public XUser CheckInUser { get; set; }
        public XUser CheckOutUser { get; set; }
        public FaLeistung FaLeistung { get; set; }
    }
}
