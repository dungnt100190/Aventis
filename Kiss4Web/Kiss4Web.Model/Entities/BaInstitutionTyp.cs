using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaInstitutionTyp
    {
        public BaInstitutionTyp()
        {
            BaInstitutionBaInstitutionTyp = new HashSet<BaInstitutionBaInstitutionTyp>();
            BaPersonBaInstitution = new HashSet<BaPersonBaInstitution>();
        }

        public int BaInstitutionTypId { get; set; }
        public int? OrgUnitId { get; set; }
        public string Name { get; set; }
        public int? NameTid { get; set; }
        public bool Aktiv { get; set; }
        public string Bemerkung { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BaInstitutionTypTs { get; set; }

        public XOrgUnit OrgUnit { get; set; }
        public ICollection<BaInstitutionBaInstitutionTyp> BaInstitutionBaInstitutionTyp { get; set; }
        public ICollection<BaPersonBaInstitution> BaPersonBaInstitution { get; set; }
    }
}
