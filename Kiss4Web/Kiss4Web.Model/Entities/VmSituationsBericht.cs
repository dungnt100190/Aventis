using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmSituationsBericht
    {
        public int VmSituationsBerichtId { get; set; }
        public int FaLeistungId { get; set; }
        public int? UserId { get; set; }
        public DateTime? AntragDatum { get; set; }
        public int? VmtypShantragCode { get; set; }
        public string FaThemaCodes { get; set; }
        public string BerichtFinanzen { get; set; }
        public string ZielPrognose { get; set; }
        public string AntragText { get; set; }
        public int? DocumentId { get; set; }
        public bool IsDeleted { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmSituationsBerichtTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
    }
}
