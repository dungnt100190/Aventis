using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaInstitutionBaInstitutionTyp
    {
        public int BaInstitutionBaInstitutionTypId { get; set; }
        public int BaInstitutionId { get; set; }
        public int BaInstitutionTypId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BaInstitutionBaInstitutionTypTs { get; set; }

        public BaInstitution BaInstitution { get; set; }
        public BaInstitutionTyp BaInstitutionTyp { get; set; }
    }
}
