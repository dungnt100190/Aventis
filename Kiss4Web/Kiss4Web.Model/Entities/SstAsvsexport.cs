using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class SstAsvsexport
    {
        public SstAsvsexport()
        {
            SstAsvsexportEintrag = new HashSet<SstAsvsexportEintrag>();
        }

        public int SstAsvsexportId { get; set; }
        public DateTime? DatumExport { get; set; }
        public string Bemerkung { get; set; }
        public int? DocumentId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public string Modified { get; set; }
        public byte[] SstAsvsexportTs { get; set; }

        public ICollection<SstAsvsexportEintrag> SstAsvsexportEintrag { get; set; }
    }
}
