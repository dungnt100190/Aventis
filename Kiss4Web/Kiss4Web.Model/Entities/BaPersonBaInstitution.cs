using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaPersonBaInstitution
    {
        public int BaPersonBaInstitutionId { get; set; }
        public int BaPersonId { get; set; }
        public int BaInstitutionId { get; set; }
        public int? BaInstitutionKontaktId { get; set; }
        public int? BaInstitutionTypId { get; set; }
        public string Bemerkung { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BaPersonBaInstitutionTs { get; set; }

        public BaInstitution BaInstitution { get; set; }
        public BaInstitutionKontakt BaInstitutionKontakt { get; set; }
        public BaInstitutionTyp BaInstitutionTyp { get; set; }
        public BaPerson BaPerson { get; set; }
    }
}
