using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaDokumentAblage
    {
        public FaDokumentAblage()
        {
            FaDokumentAblageBaPerson = new HashSet<FaDokumentAblageBaPerson>();
        }

        public int FaDokumentAblageId { get; set; }
        public int FaLeistungId { get; set; }
        public int UserId { get; set; }
        public int? BaPersonIdAdressat { get; set; }
        public int? BaInstitutionIdAdressat { get; set; }
        public int? FaDokumentAblageInhaltCode { get; set; }
        public string FaThemaDokAblageCodes { get; set; }
        public DateTime? DatumErstellung { get; set; }
        public DateTime? DatumGueltigVon { get; set; }
        public DateTime? DatumGueltigBis { get; set; }
        public string Stichwort { get; set; }
        public string Bemerkung { get; set; }
        public int? DocumentId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FaDokumentAblageTs { get; set; }

        public BaInstitution BaInstitutionIdAdressatNavigation { get; set; }
        public BaPerson BaPersonIdAdressatNavigation { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
        public ICollection<FaDokumentAblageBaPerson> FaDokumentAblageBaPerson { get; set; }
    }
}
