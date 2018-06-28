using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaEinwohnerregisterEmpfangeneEreignisseRohdaten
    {
        public BaEinwohnerregisterEmpfangeneEreignisseRohdaten()
        {
            BaEinwohnerregisterEmpfangeneEreignisse = new HashSet<BaEinwohnerregisterEmpfangeneEreignisse>();
        }

        public int BaEinwohnerregisterEmpfangeneEreignisseRohdatenId { get; set; }
        public string Xml { get; set; }
        public int BaEinwohnerregisterEmpfangeneEreignisseRohdatenStatusCode { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BaEinwohnerregisterEmpfangeneEreignisseRohdatenTs { get; set; }

        public ICollection<BaEinwohnerregisterEmpfangeneEreignisse> BaEinwohnerregisterEmpfangeneEreignisse { get; set; }
    }
}
