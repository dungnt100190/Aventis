using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KesDokument
    {
        public int KesDokumentId { get; set; }
        public int? KesAuftragId { get; set; }
        public int? FaLeistungId { get; set; }
        public int? UserId { get; set; }
        public int? BaPersonIdAdressat { get; set; }
        public int? BaInstitutionIdAdressat { get; set; }
        public string Stichwort { get; set; }
        public int? KesDokumentResultatCode { get; set; }
        public int? KesDokumentArtCode { get; set; }
        public int? XdocumentIdDokument { get; set; }
        public int? XdocumentIdVersand { get; set; }
        public int KesDokumentTypCode { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KesDokumentTs { get; set; }
        public bool IsDeleted { get; set; }

        public BaInstitution BaInstitutionIdAdressatNavigation { get; set; }
        public BaPerson BaPersonIdAdressatNavigation { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public KesAuftrag KesAuftrag { get; set; }
        public XUser User { get; set; }
    }
}
