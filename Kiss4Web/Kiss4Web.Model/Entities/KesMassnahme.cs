using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KesMassnahme
    {
        public KesMassnahme()
        {
            KesMandatsfuehrendePerson = new HashSet<KesMandatsfuehrendePerson>();
            KesMassnahmeAuftrag = new HashSet<KesMassnahmeAuftrag>();
            KesMassnahmeBericht = new HashSet<KesMassnahmeBericht>();
            KesMassnahmeKesArtikel = new HashSet<KesMassnahmeKesArtikel>();
        }

        public int KesMassnahmeId { get; set; }
        public int FaLeistungId { get; set; }
        public bool IsKs { get; set; }
        public int? DocumentIdErrichtungsbeschluss { get; set; }
        public int? DocumentIdAufhebungsbeschluss { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public string KesAufgabenbereichCodes { get; set; }
        public string KesIndikationCodes { get; set; }
        public string Auftragstext { get; set; }
        public int? KesElterlicheSorgeObhutCodeElterlicheSorge { get; set; }
        public int? KesElterlicheSorgeObhutCodeObhut { get; set; }
        public DateTime? UebernahmeVonDatum { get; set; }
        public int? UebernahmeVonOrtschaftCode { get; set; }
        public string UebernahmeVonPlz { get; set; }
        public string UebernahmeVonOrt { get; set; }
        public string UebernahmeVonKanton { get; set; }
        public int? UebernahmeVonKesBehoerdeId { get; set; }
        public DateTime? AenderungVomDatum { get; set; }
        public int? KesAenderungsgrundCode { get; set; }
        public DateTime? UebertragungAnDatum { get; set; }
        public int? UebertragungAnOrtschaftCode { get; set; }
        public string UebertragungAnPlz { get; set; }
        public string UebertragungAnOrt { get; set; }
        public string UebertragungAnKanton { get; set; }
        public int? UebertragungAnKesBehoerdeId { get; set; }
        public int? KesAufhebungsgrundCode { get; set; }
        public string Bemerkung { get; set; }
        public int? ZustaendigKesBehoerdeId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KesMassnahmeTs { get; set; }
        public bool IsDeleted { get; set; }
        public bool FuersorgerischeUnterbringung { get; set; }
        public int? PlatzierungBaInstitutionId { get; set; }
        public int? KesGrundlageCode { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public BaInstitution PlatzierungBaInstitution { get; set; }
        public KesBehoerde UebernahmeVonKesBehoerde { get; set; }
        public KesBehoerde UebertragungAnKesBehoerde { get; set; }
        public KesBehoerde ZustaendigKesBehoerde { get; set; }
        public ICollection<KesMandatsfuehrendePerson> KesMandatsfuehrendePerson { get; set; }
        public ICollection<KesMassnahmeAuftrag> KesMassnahmeAuftrag { get; set; }
        public ICollection<KesMassnahmeBericht> KesMassnahmeBericht { get; set; }
        public ICollection<KesMassnahmeKesArtikel> KesMassnahmeKesArtikel { get; set; }
    }
}
