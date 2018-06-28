using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KesMandatsfuehrendePerson
    {
        public int KesMandatsfuehrendePersonId { get; set; }
        public int KesMassnahmeId { get; set; }
        public DateTime? DatumMandatVon { get; set; }
        public DateTime? DatumMandatBis { get; set; }
        public int? DocumentIdErnennungsurkunde { get; set; }
        public int? UserId { get; set; }
        public int? BaInstitutionId { get; set; }
        public int? KesBeistandsartCode { get; set; }
        public DateTime? DatumVorgeschlagenAm { get; set; }
        public DateTime? DatumRechnungsfuehrungVon { get; set; }
        public DateTime? DatumRechnungsfuehrungBis { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KesMandatsfuehrendePersonTs { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DatumErnennungsurkunde { get; set; }

        public BaInstitution BaInstitution { get; set; }
        public KesMassnahme KesMassnahme { get; set; }
        public XUser User { get; set; }
    }
}
