using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmSozialversicherung
    {
        public int VmSozialversicherungId { get; set; }
        public int? FaLeistungId { get; set; }
        public int? BaPersonIdAdressat { get; set; }
        public int? BaInstitutionIdAdressat { get; set; }
        public int? VmPriMaIdAdressat { get; set; }
        public int? DocumentIdKorrespondenz { get; set; }
        public int? VmSozialversicherungenBezeichnungenCode { get; set; }
        public string Grund { get; set; }
        public DateTime? Eingereicht { get; set; }
        public DateTime? VerfuegungVom { get; set; }
        public string Berechnungsgrundlage { get; set; }
        public decimal? Verfuegungsbetrag { get; set; }
        public string Bemerkungen { get; set; }
        public bool IsDeleted { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmSozialversicherungTs { get; set; }

        public BaInstitution BaInstitutionIdAdressatNavigation { get; set; }
        public BaPerson BaPersonIdAdressatNavigation { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public VmPriMa VmPriMaIdAdressatNavigation { get; set; }
    }
}
