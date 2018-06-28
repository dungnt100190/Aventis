using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkLandesindex
    {
        public IkLandesindex()
        {
            IkLandesindexWert = new HashSet<IkLandesindexWert>();
        }

        public int IkLandesindexId { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] IkLandesindexTs { get; set; }

        public ICollection<IkLandesindexWert> IkLandesindexWert { get; set; }
    }
}
