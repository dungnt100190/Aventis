using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaDokumentAblageBaPerson
    {
        public int FaDokumentAblageBaPersonId { get; set; }
        public int BaPersonId { get; set; }
        public int FaDokumentAblageId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FaDokumentAblageBaPersonTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public FaDokumentAblage FaDokumentAblage { get; set; }
    }
}
