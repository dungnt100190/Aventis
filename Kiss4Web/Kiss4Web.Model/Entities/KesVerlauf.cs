using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KesVerlauf
    {
        public int KesVerlaufId { get; set; }
        public int FaLeistungId { get; set; }
        public int KesVerlaufTypCode { get; set; }
        public int? UserId { get; set; }
        public int? BaPersonIdAdressat { get; set; }
        public int? BaInstitutionIdAdressat { get; set; }
        public int? DocumentId { get; set; }
        public DateTime? Datum { get; set; }
        public int? KesKontaktartCode { get; set; }
        public int? KesDienstleistungCode { get; set; }
        public string Stichwort { get; set; }
        public int? FaDauerCode { get; set; }
        public string Inhalt { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KesVerlaufTs { get; set; }

        public BaInstitution BaInstitutionIdAdressatNavigation { get; set; }
        public BaPerson BaPersonIdAdressatNavigation { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
    }
}
