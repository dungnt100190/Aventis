using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class GvDocument
    {
        public int GvDocumentId { get; set; }
        public int GvGesuchId { get; set; }
        public int UserId { get; set; }
        public int? BaPersonId { get; set; }
        public int? BaInstitutionId { get; set; }
        public int? DocumentId { get; set; }
        public string Stichworte { get; set; }
        public string Bemerkungen { get; set; }
        public DateTime Datum { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] GvDocumentTs { get; set; }

        public BaInstitution BaInstitution { get; set; }
        public BaPerson BaPerson { get; set; }
        public GvGesuch GvGesuch { get; set; }
        public XUser User { get; set; }
    }
}
