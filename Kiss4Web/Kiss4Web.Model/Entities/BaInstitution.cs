using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaInstitution
    {
        public BaInstitution()
        {
            BaAdresseBaInstitution = new HashSet<BaAdresse>();
            BaAdressePlatzierungInst = new HashSet<BaAdresse>();
            BaArbeit = new HashSet<BaArbeit>();
            BaArbeitAusbildung = new HashSet<BaArbeitAusbildung>();
            BaGesundheitKvgorganisation = new HashSet<BaGesundheit>();
            BaGesundheitVvgorganisation = new HashSet<BaGesundheit>();
            BaGesundheitZahnarztBaInstitution = new HashSet<BaGesundheit>();
            BaInstitutionBaInstitutionTyp = new HashSet<BaInstitutionBaInstitutionTyp>();
            BaInstitutionDokumentBaInstitution = new HashSet<BaInstitutionDokument>();
            BaInstitutionDokumentBaInstitutionIdAdressatNavigation = new HashSet<BaInstitutionDokument>();
            BaInstitutionKontakt = new HashSet<BaInstitutionKontakt>();
            BaMietvertrag = new HashSet<BaMietvertrag>();
            BaPerson = new HashSet<BaPerson>();
            BaPersonBaInstitution = new HashSet<BaPersonBaInstitution>();
            BaZahlungsweg = new HashSet<BaZahlungsweg>();
            BgPosition = new HashSet<BgPosition>();
            BgSpezkonto = new HashSet<BgSpezkonto>();
            FaDokumentAblage = new HashSet<FaDokumentAblage>();
            FaDokumente = new HashSet<FaDokumente>();
            GvDocument = new HashSet<GvDocument>();
            KbBuchung = new HashSet<KbBuchung>();
            KbZahlungseingang = new HashSet<KbZahlungseingang>();
            KesDokument = new HashSet<KesDokument>();
            KesMandatsfuehrendePerson = new HashSet<KesMandatsfuehrendePerson>();
            KesMassnahme = new HashSet<KesMassnahme>();
            KesMassnahmeBssBaInstitution = new HashSet<KesMassnahmeBss>();
            KesMassnahmeBssPlatzierungBaInstitution = new HashSet<KesMassnahmeBss>();
            KesPflegekinderaufsicht = new HashSet<KesPflegekinderaufsicht>();
            KesVerlauf = new HashSet<KesVerlauf>();
            VmErbschaftsdienst = new HashSet<VmErbschaftsdienst>();
            VmSachversicherung = new HashSet<VmSachversicherung>();
            VmSiegelung = new HashSet<VmSiegelung>();
            VmSozialversicherung = new HashSet<VmSozialversicherung>();
            VmTestament = new HashSet<VmTestament>();
        }

        public int BaInstitutionId { get; set; }
        public int? OrgUnitId { get; set; }
        public string InstitutionNr { get; set; }
        public int? BaInstitutionArtCode { get; set; }
        public bool? Aktiv { get; set; }
        public bool Debitor { get; set; }
        public bool Kreditor { get; set; }
        public bool KeinSerienbrief { get; set; }
        public bool ManuelleAnrede { get; set; }
        public string Anrede { get; set; }
        public string Briefanrede { get; set; }
        public string Titel { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public int? GeschlechtCode { get; set; }
        public DateTime? Geburtsdatum { get; set; }
        public string Versichertennummer { get; set; }
        public string Telefon { get; set; }
        public string Telefon2 { get; set; }
        public string Telefon3 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Homepage { get; set; }
        public int? SprachCode { get; set; }
        public string Bemerkung { get; set; }
        public string InstitutionName { get; set; }
        public int? InstitutionTypCode { get; set; }
        public int? BaFreigabeStatusCode { get; set; }
        public int? DefinitivUserId { get; set; }
        public DateTime? DefinitivDatum { get; set; }
        public int? ErstelltUserId { get; set; }
        public DateTime? ErstelltDatum { get; set; }
        public int? MutiertUserId { get; set; }
        public DateTime? MutiertDatum { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BaInstitutionTs { get; set; }

        public XOrgUnit OrgUnit { get; set; }
        public ICollection<BaAdresse> BaAdresseBaInstitution { get; set; }
        public ICollection<BaAdresse> BaAdressePlatzierungInst { get; set; }
        public ICollection<BaArbeit> BaArbeit { get; set; }
        public ICollection<BaArbeitAusbildung> BaArbeitAusbildung { get; set; }
        public ICollection<BaGesundheit> BaGesundheitKvgorganisation { get; set; }
        public ICollection<BaGesundheit> BaGesundheitVvgorganisation { get; set; }
        public ICollection<BaGesundheit> BaGesundheitZahnarztBaInstitution { get; set; }
        public ICollection<BaInstitutionBaInstitutionTyp> BaInstitutionBaInstitutionTyp { get; set; }
        public ICollection<BaInstitutionDokument> BaInstitutionDokumentBaInstitution { get; set; }
        public ICollection<BaInstitutionDokument> BaInstitutionDokumentBaInstitutionIdAdressatNavigation { get; set; }
        public ICollection<BaInstitutionKontakt> BaInstitutionKontakt { get; set; }
        public ICollection<BaMietvertrag> BaMietvertrag { get; set; }
        public ICollection<BaPerson> BaPerson { get; set; }
        public ICollection<BaPersonBaInstitution> BaPersonBaInstitution { get; set; }
        public ICollection<BaZahlungsweg> BaZahlungsweg { get; set; }
        public ICollection<BgPosition> BgPosition { get; set; }
        public ICollection<BgSpezkonto> BgSpezkonto { get; set; }
        public ICollection<FaDokumentAblage> FaDokumentAblage { get; set; }
        public ICollection<FaDokumente> FaDokumente { get; set; }
        public ICollection<GvDocument> GvDocument { get; set; }
        public ICollection<KbBuchung> KbBuchung { get; set; }
        public ICollection<KbZahlungseingang> KbZahlungseingang { get; set; }
        public ICollection<KesDokument> KesDokument { get; set; }
        public ICollection<KesMandatsfuehrendePerson> KesMandatsfuehrendePerson { get; set; }
        public ICollection<KesMassnahme> KesMassnahme { get; set; }
        public ICollection<KesMassnahmeBss> KesMassnahmeBssBaInstitution { get; set; }
        public ICollection<KesMassnahmeBss> KesMassnahmeBssPlatzierungBaInstitution { get; set; }
        public ICollection<KesPflegekinderaufsicht> KesPflegekinderaufsicht { get; set; }
        public ICollection<KesVerlauf> KesVerlauf { get; set; }
        public ICollection<VmErbschaftsdienst> VmErbschaftsdienst { get; set; }
        public ICollection<VmSachversicherung> VmSachversicherung { get; set; }
        public ICollection<VmSiegelung> VmSiegelung { get; set; }
        public ICollection<VmSozialversicherung> VmSozialversicherung { get; set; }
        public ICollection<VmTestament> VmTestament { get; set; }
    }
}
