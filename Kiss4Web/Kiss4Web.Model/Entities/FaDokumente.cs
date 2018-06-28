using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FaDokumente
    {
        public int FaDokumenteId { get; set; }
        public int FaLeistungId { get; set; }
        public int? BaPersonIdLt { get; set; }
        public int? BaPersonIdAdressat { get; set; }
        public int? BaInstitutionIdAdressat { get; set; }
        public int? VmPriMaIdAdressat { get; set; }
        public int? UserIdAbsender { get; set; }
        public int? UserIdVisumBeantragtDurch { get; set; }
        public int? UserIdVisumBeantragtBei { get; set; }
        public int? UserIdVisiertDurch { get; set; }
        public int? UserIdEkVisumUser { get; set; }
        public int? DocumentId { get; set; }
        public int? DocumentIdMerkblatt { get; set; }
        public string BaPersonIds { get; set; }
        public DateTime? DatumErstellung { get; set; }
        public int? StatusCode { get; set; }
        public DateTime? PendenzDatum { get; set; }
        public bool? PendenzErledigt { get; set; }
        public int? VmErbDienstCode { get; set; }
        public int? FaDauerCode { get; set; }
        public string Stichwort { get; set; }
        public int? EingangAusgang { get; set; }
        public int? ThemaCode { get; set; }
        public DateTime? VisumBeantragtDatum { get; set; }
        public DateTime? VisiertDatum { get; set; }
        public int? EkStatusCode { get; set; }
        public int? EkLaufNr { get; set; }
        public int? EkKw { get; set; }
        public int? EkJahr { get; set; }
        public DateTime? EkVisumDatum { get; set; }
        public string Bemerkung { get; set; }
        public string FaThemaCodes { get; set; }
        public bool Vertraulich { get; set; }
        public bool IsDeleted { get; set; }
        public bool IstBericht { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FaDokumenteTs { get; set; }

        public BaInstitution BaInstitutionIdAdressatNavigation { get; set; }
        public BaPerson BaPersonIdAdressatNavigation { get; set; }
        public BaPerson BaPersonIdLtNavigation { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public XUser UserIdAbsenderNavigation { get; set; }
        public XUser UserIdEkVisumUserNavigation { get; set; }
        public XUser UserIdVisiertDurchNavigation { get; set; }
        public XUser UserIdVisumBeantragtBeiNavigation { get; set; }
        public XUser UserIdVisumBeantragtDurchNavigation { get; set; }
        public VmPriMa VmPriMaIdAdressatNavigation { get; set; }
    }
}
