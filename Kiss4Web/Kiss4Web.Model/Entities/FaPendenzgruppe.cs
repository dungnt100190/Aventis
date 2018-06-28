using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaPendenzgruppe
    {
        public FaPendenzgruppe()
        {
            FaPendenzgruppeUser = new HashSet<FaPendenzgruppeUser>();
        }

        public int FaPendenzgruppeId { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public byte[] FaPendenzgruppeTs { get; set; }

        public ICollection<FaPendenzgruppeUser> FaPendenzgruppeUser { get; set; }
    }
}
