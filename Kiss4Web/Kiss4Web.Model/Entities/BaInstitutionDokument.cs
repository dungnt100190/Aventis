using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaInstitutionDokument
    {
        public int BaInstitutionDokumentId { get; set; }
        public int BaInstitutionId { get; set; }
        public int UserId { get; set; }
        public int? BaPersonIdAdressat { get; set; }
        public int? BaInstitutionIdAdressat { get; set; }
        public int? DocumentId { get; set; }
        public int? BaInstitutionDokumentKontaktartCode { get; set; }
        public int? BaInstitutionDokumentDienstleistungCode { get; set; }
        public int? FaDauerCode { get; set; }
        public DateTime? Datum { get; set; }
        public string Stichwort { get; set; }
        public string Inhalt { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BaInstitutionDokumentTs { get; set; }

        public BaInstitution BaInstitution { get; set; }
        public BaInstitution BaInstitutionIdAdressatNavigation { get; set; }
        public BaPerson BaPersonIdAdressatNavigation { get; set; }
        public XUser User { get; set; }
    }
}
