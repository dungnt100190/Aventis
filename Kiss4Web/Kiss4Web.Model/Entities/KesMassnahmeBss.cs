using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KesMassnahmeBss
    {
        public int KesMassnahmeBssid { get; set; }
        public int FaLeistungId { get; set; }
        public int? UserId { get; set; }
        public int? VmPriMaId { get; set; }
        public int? BaInstitutionId { get; set; }
        public int? KesArtikelIdMassnahmegebundeneGeschaefte { get; set; }
        public int? KesArtikelIdNichtMassnahmegebundeneGeschaefte { get; set; }
        public int? PlatzierungBaInstitutionId { get; set; }
        public int KesMassnahmeTypCode { get; set; }
        public int? KesBeistandsartCode { get; set; }
        public int? KesGefaehrdungsmeldungDurchCode { get; set; }
        public int? KesAenderungsgrundCode { get; set; }
        public int? KesAufhebungsgrundCode { get; set; }
        public int? KesbdocumentId { get; set; }
        public int? DocumentIdUrkunde { get; set; }
        public DateTime? ErrichtungVom { get; set; }
        public DateTime? AenderungVom { get; set; }
        public DateTime? UebernahmeVom { get; set; }
        public DateTime? BerichtsgenehmigungVom { get; set; }
        public DateTime? Beistandswechsel { get; set; }
        public DateTime? UebertragungVom { get; set; }
        public DateTime? AufhebungVom { get; set; }
        public string KesAufgabenbereichCodes { get; set; }
        public int? KesGrundlageCode { get; set; }
        public string KesIndikationCodes { get; set; }
        public int? KesElterlicheSorgeObhutCodeElterlicheSorge { get; set; }
        public int? KesElterlicheSorgeObhutCodeObhut { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
        public int? OrtschaftCode { get; set; }
        public string Kanton { get; set; }
        public bool FuersorgerischeUnterbringung { get; set; }
        public string Bemerkung { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] KesMassnahmeBssts { get; set; }

        public BaInstitution BaInstitution { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public KesArtikel KesArtikelIdMassnahmegebundeneGeschaefteNavigation { get; set; }
        public KesArtikel KesArtikelIdNichtMassnahmegebundeneGeschaefteNavigation { get; set; }
        public BaInstitution PlatzierungBaInstitution { get; set; }
        public XUser User { get; set; }
        public VmPriMa VmPriMa { get; set; }
    }
}
