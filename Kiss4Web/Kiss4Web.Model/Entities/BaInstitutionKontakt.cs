using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaInstitutionKontakt
    {
        public BaInstitutionKontakt()
        {
            BaPersonBaInstitution = new HashSet<BaPersonBaInstitution>();
        }

        public int BaInstitutionKontaktId { get; set; }
        public int BaInstitutionId { get; set; }
        public bool Aktiv { get; set; }
        public bool ManuelleAnrede { get; set; }
        public string Anrede { get; set; }
        public string Briefanrede { get; set; }
        public string Titel { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public int? GeschlechtCode { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? SprachCode { get; set; }
        public string Bemerkung { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BaInstitutionKontaktTs { get; set; }

        public BaInstitution BaInstitution { get; set; }
        public ICollection<BaPersonBaInstitution> BaPersonBaInstitution { get; set; }
    }
}
