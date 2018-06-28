using System;
using System.Collections.Generic;
using Kiss4Web.Model.Entities;

namespace Kiss4Web.Model
{
    public partial class XUser : IEntity, IAuditableEntity
    {
        public XUser()
        {
            BaAdresse = new HashSet<BaAdresse>();
            BaInstitutionDokument = new HashSet<BaInstitutionDokument>();
            BdeausbezahlteUeberstundenXuser = new HashSet<BdeausbezahlteUeberstundenXuser>();
            BdeferienanspruchXuser = new HashSet<BdeferienanspruchXuser>();
            BdeferienkuerzungenXuser = new HashSet<BdeferienkuerzungenXuser>();
            Bdeleistung = new HashSet<Bdeleistung>();
            BdepensumXuser = new HashSet<BdepensumXuser>();
            BdesollProTagXuser = new HashSet<BdesollProTagXuser>();
            BdesollStundenProJahrXuser = new HashSet<BdesollStundenProJahrXuser>();
            Bdezeitrechner = new HashSet<Bdezeitrechner>();
            Bfsdossier = new HashSet<Bfsdossier>();
            BgBewilligungUser = new HashSet<BgBewilligung>();
            BgBewilligungUserIdAnNavigation = new HashSet<BgBewilligung>();
            BgBewilligungUserIdZustaendigNavigation = new HashSet<BgBewilligung>();
            BgPositionErstelltUser = new HashSet<BgPosition>();
            BgPositionMutiertUser = new HashSet<BgPosition>();
            FaAktennotizen = new HashSet<FaAktennotizen>();
            FaDokumentAblage = new HashSet<FaDokumentAblage>();
            FaDokumenteUserIdAbsenderNavigation = new HashSet<FaDokumente>();
            FaDokumenteUserIdEkVisumUserNavigation = new HashSet<FaDokumente>();
            FaDokumenteUserIdVisiertDurchNavigation = new HashSet<FaDokumente>();
            FaDokumenteUserIdVisumBeantragtBeiNavigation = new HashSet<FaDokumente>();
            FaDokumenteUserIdVisumBeantragtDurchNavigation = new HashSet<FaDokumente>();
            FaKategorisierung = new HashSet<FaKategorisierung>();
            FaLeistungArchivCheckInUser = new HashSet<FaLeistungArchiv>();
            FaLeistungArchivCheckOutUser = new HashSet<FaLeistungArchiv>();
            FaLeistungBewertung = new HashSet<FaLeistungBewertung>();
            FaLeistungSachbearbeiter = new HashSet<FaLeistung>();
            FaLeistungUser = new HashSet<FaLeistung>();
            FaLeistungUserHist = new HashSet<FaLeistungUserHist>();
            FaLeistungZugriff = new HashSet<FaLeistungZugriff>();
            FaPendenzgruppeUser = new HashSet<FaPendenzgruppeUser>();
            FaPhase = new HashSet<FaPhase>();
            FaWeisungUserIdCreatorNavigation = new HashSet<FaWeisung>();
            FaWeisungUserIdVerantwortlichRdNavigation = new HashSet<FaWeisung>();
            FaWeisungUserIdVerantwortlichSarNavigation = new HashSet<FaWeisung>();
            FbBarauszahlungAuftragUserIdCreatorNavigation = new HashSet<FbBarauszahlungAuftrag>();
            FbBarauszahlungAuftragUserIdModifierNavigation = new HashSet<FbBarauszahlungAuftrag>();
            FbBarauszahlungAusbezahlt = new HashSet<FbBarauszahlungAusbezahlt>();
            FbBelegNr = new HashSet<FbBelegNr>();
            FbBuchung = new HashSet<FbBuchung>();
            FbBuchungCode = new HashSet<FbBuchungCode>();
            FbDtajournal = new HashSet<FbDtajournal>();
            FbTeamMitglied = new HashSet<FbTeamMitglied>();
            FsReduktionMitarbeiter = new HashSet<FsReduktionMitarbeiter>();
            GvBewilligung = new HashSet<GvBewilligung>();
            GvDocument = new HashSet<GvDocument>();
            GvGesuchAbgeschlossenesGesuchdurchIksUser = new HashSet<GvGesuch>();
            GvGesuchErfasstesGesuchgeprueftdurchIksUser = new HashSet<GvGesuch>();
            GvGesuchXuserIdAutorNavigation = new HashSet<GvGesuch>();
            IkAbklaerung = new HashSet<IkAbklaerung>();
            InverseChief = new HashSet<XUser>();
            InversePrimaryUser = new HashSet<XUser>();
            InverseSachbearbeiter = new HashSet<XUser>();
            KaBetriebBesprechung = new HashSet<KaBetriebBesprechung>();
            KaVerlauf = new HashSet<KaVerlauf>();
            KbBuchungBarbelegUser = new HashSet<KbBuchung>();
            KbBuchungErstelltUser = new HashSet<KbBuchung>();
            KbBuchungMutiertUser = new HashSet<KbBuchung>();
            KbPeriodeUser = new HashSet<KbPeriodeUser>();
            KbWvlauf = new HashSet<KbWvlauf>();
            KbZahlungseingangErstelltUser = new HashSet<KbZahlungseingang>();
            KbZahlungseingangMutiertUser = new HashSet<KbZahlungseingang>();
            KbZahlungseingangZugeteiltUser = new HashSet<KbZahlungseingang>();
            KbZahlungslauf = new HashSet<KbZahlungslauf>();
            KesAuftrag = new HashSet<KesAuftrag>();
            KesDokument = new HashSet<KesDokument>();
            KesMandatsfuehrendePerson = new HashSet<KesMandatsfuehrendePerson>();
            KesMassnahmeBss = new HashSet<KesMassnahmeBss>();
            KesPflegekinderaufsicht = new HashSet<KesPflegekinderaufsicht>();
            KesPraevention = new HashSet<KesPraevention>();
            KesVerlauf = new HashSet<KesVerlauf>();
            ServiceCall = new HashSet<ServiceCall>();
            ServiceProcessError = new HashSet<ServiceProcessError>();
            UserSession = new HashSet<UserSession>();
            VmAntragEksk = new HashSet<VmAntragEksk>();
            VmBewertung = new HashSet<VmBewertung>();
            VmBudget = new HashSet<VmBudget>();
            VmErbschaftsdienst = new HashSet<VmErbschaftsdienst>();
            VmErnennung = new HashSet<VmErnennung>();
            VmInventar = new HashSet<VmInventar>();
            VmKlientenbudget = new HashSet<VmKlientenbudget>();
            VmMandBericht = new HashSet<VmMandBericht>();
            VmMandant = new HashSet<VmMandant>();
            VmSiegelung = new HashSet<VmSiegelung>();
            VmSituationsBericht = new HashSet<VmSituationsBericht>();
            VmTestament = new HashSet<VmTestament>();
            XdocTemplate = new HashSet<XDocTemplate>();
            XorgUnitChief = new HashSet<XOrgUnit>();
            XorgUnitRechtsdienstUser = new HashSet<XOrgUnit>();
            XorgUnitRepresentative = new HashSet<XOrgUnit>();
            XorgUnitUser = new HashSet<XOrgUnit_User>();
            XsearchControlTemplate = new HashSet<XsearchControlTemplate>();
            XtaskUserIdErledigtNavigation = new HashSet<Xtask>();
            XtaskUserIdInBearbeitungNavigation = new HashSet<Xtask>();
            XuserArchive = new HashSet<XuserArchive>();
            XuserBdeuserGroup = new HashSet<XuserBdeuserGroup>();
            XuserStundenansatz = new HashSet<XuserStundenansatz>();
            XuserUserGroup = new HashSet<XUserUserGroup>();
            XuserXdocTemplate = new HashSet<XuserXdocTemplate>();
        }

        public int UserId { get; set; }
        public int? ChiefId { get; set; }
        public int? PrimaryUserId { get; set; }
        public int? PermissionGroupId { get; set; }
        public int? GrantPermGroupId { get; set; }
        public int? XprofileId { get; set; }
        public int? ModulId { get; set; }
        public int? SachbearbeiterId { get; set; }
        public string MitarbeiterNr { get; set; }
        public string LogonName { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public bool IsLocked { get; set; }
        public bool IsUserAdmin { get; set; }
        public bool IsUserBiagadmin { get; set; }
        public bool IsMandatsTraeger { get; set; }
        public int? GenderCode { get; set; }
        public DateTime? Geburtstag { get; set; }
        public int? LanguageCode { get; set; }
        public string Phone { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneOffice { get; set; }
        public string PhoneIntern { get; set; }
        public string PhonePrivat { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? UserProfileCode { get; set; }
        public string Funktion { get; set; }
        public int? RoleTitleCode { get; set; }
        public int? QualificationTitleCode { get; set; }
        public string Bemerkungen { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public double? JobPercentage { get; set; }
        public int? HoursPerYearForCaseMgmt { get; set; }
        public DateTime? Eintrittsdatum { get; set; }
        public DateTime? Austrittsdatum { get; set; }
        public int? LohntypCode { get; set; }
        public int? Kostentraeger { get; set; }
        public string WeitereKostentraeger { get; set; }
        public int? Kostenart { get; set; }
        public bool KeinBdeexport { get; set; }
        public string MigHerkunft { get; set; }
        public string MigMakuerzel { get; set; }
        public bool MigUserFix { get; set; }
        public string Visdat36Area { get; set; }
        public string Visdat36SourceFile { get; set; }
        public string Visdat36Id { get; set; }
        public string Visdat36Name { get; set; }
        public int? VerId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XUserTs { get; set; }

        public XUser Chief { get; set; }
        public XpermissionGroup GrantPermGroup { get; set; }
        public XModul Modul { get; set; }
        public XpermissionGroup PermissionGroup { get; set; }
        public XUser PrimaryUser { get; set; }
        public XUser Sachbearbeiter { get; set; }
        public Xprofile Xprofile { get; set; }
        public ICollection<BaAdresse> BaAdresse { get; set; }
        public ICollection<BaInstitutionDokument> BaInstitutionDokument { get; set; }
        public ICollection<BdeausbezahlteUeberstundenXuser> BdeausbezahlteUeberstundenXuser { get; set; }
        public ICollection<BdeferienanspruchXuser> BdeferienanspruchXuser { get; set; }
        public ICollection<BdeferienkuerzungenXuser> BdeferienkuerzungenXuser { get; set; }
        public ICollection<Bdeleistung> Bdeleistung { get; set; }
        public ICollection<BdepensumXuser> BdepensumXuser { get; set; }
        public ICollection<BdesollProTagXuser> BdesollProTagXuser { get; set; }
        public ICollection<BdesollStundenProJahrXuser> BdesollStundenProJahrXuser { get; set; }
        public ICollection<Bdezeitrechner> Bdezeitrechner { get; set; }
        public ICollection<Bfsdossier> Bfsdossier { get; set; }
        public ICollection<BgBewilligung> BgBewilligungUser { get; set; }
        public ICollection<BgBewilligung> BgBewilligungUserIdAnNavigation { get; set; }
        public ICollection<BgBewilligung> BgBewilligungUserIdZustaendigNavigation { get; set; }
        public ICollection<BgPosition> BgPositionErstelltUser { get; set; }
        public ICollection<BgPosition> BgPositionMutiertUser { get; set; }
        public ICollection<FaAktennotizen> FaAktennotizen { get; set; }
        public ICollection<FaDokumentAblage> FaDokumentAblage { get; set; }
        public ICollection<FaDokumente> FaDokumenteUserIdAbsenderNavigation { get; set; }
        public ICollection<FaDokumente> FaDokumenteUserIdEkVisumUserNavigation { get; set; }
        public ICollection<FaDokumente> FaDokumenteUserIdVisiertDurchNavigation { get; set; }
        public ICollection<FaDokumente> FaDokumenteUserIdVisumBeantragtBeiNavigation { get; set; }
        public ICollection<FaDokumente> FaDokumenteUserIdVisumBeantragtDurchNavigation { get; set; }
        public ICollection<FaKategorisierung> FaKategorisierung { get; set; }
        public ICollection<FaLeistungArchiv> FaLeistungArchivCheckInUser { get; set; }
        public ICollection<FaLeistungArchiv> FaLeistungArchivCheckOutUser { get; set; }
        public ICollection<FaLeistungBewertung> FaLeistungBewertung { get; set; }
        public ICollection<FaLeistung> FaLeistungSachbearbeiter { get; set; }
        public ICollection<FaLeistung> FaLeistungUser { get; set; }
        public ICollection<FaLeistungUserHist> FaLeistungUserHist { get; set; }
        public ICollection<FaLeistungZugriff> FaLeistungZugriff { get; set; }
        public ICollection<FaPendenzgruppeUser> FaPendenzgruppeUser { get; set; }
        public ICollection<FaPhase> FaPhase { get; set; }
        public ICollection<FaWeisung> FaWeisungUserIdCreatorNavigation { get; set; }
        public ICollection<FaWeisung> FaWeisungUserIdVerantwortlichRdNavigation { get; set; }
        public ICollection<FaWeisung> FaWeisungUserIdVerantwortlichSarNavigation { get; set; }
        public ICollection<FbBarauszahlungAuftrag> FbBarauszahlungAuftragUserIdCreatorNavigation { get; set; }
        public ICollection<FbBarauszahlungAuftrag> FbBarauszahlungAuftragUserIdModifierNavigation { get; set; }
        public ICollection<FbBarauszahlungAusbezahlt> FbBarauszahlungAusbezahlt { get; set; }
        public ICollection<FbBelegNr> FbBelegNr { get; set; }
        public ICollection<FbBuchung> FbBuchung { get; set; }
        public ICollection<FbBuchungCode> FbBuchungCode { get; set; }
        public ICollection<FbDtajournal> FbDtajournal { get; set; }
        public ICollection<FbTeamMitglied> FbTeamMitglied { get; set; }
        public ICollection<FsReduktionMitarbeiter> FsReduktionMitarbeiter { get; set; }
        public ICollection<GvBewilligung> GvBewilligung { get; set; }
        public ICollection<GvDocument> GvDocument { get; set; }
        public ICollection<GvGesuch> GvGesuchAbgeschlossenesGesuchdurchIksUser { get; set; }
        public ICollection<GvGesuch> GvGesuchErfasstesGesuchgeprueftdurchIksUser { get; set; }
        public ICollection<GvGesuch> GvGesuchXuserIdAutorNavigation { get; set; }
        public ICollection<IkAbklaerung> IkAbklaerung { get; set; }
        public ICollection<XUser> InverseChief { get; set; }
        public ICollection<XUser> InversePrimaryUser { get; set; }
        public ICollection<XUser> InverseSachbearbeiter { get; set; }
        public ICollection<KaBetriebBesprechung> KaBetriebBesprechung { get; set; }
        public ICollection<KaVerlauf> KaVerlauf { get; set; }
        public ICollection<KbBuchung> KbBuchungBarbelegUser { get; set; }
        public ICollection<KbBuchung> KbBuchungErstelltUser { get; set; }
        public ICollection<KbBuchung> KbBuchungMutiertUser { get; set; }
        public ICollection<KbPeriodeUser> KbPeriodeUser { get; set; }
        public ICollection<KbWvlauf> KbWvlauf { get; set; }
        public ICollection<KbZahlungseingang> KbZahlungseingangErstelltUser { get; set; }
        public ICollection<KbZahlungseingang> KbZahlungseingangMutiertUser { get; set; }
        public ICollection<KbZahlungseingang> KbZahlungseingangZugeteiltUser { get; set; }
        public ICollection<KbZahlungslauf> KbZahlungslauf { get; set; }
        public ICollection<KesAuftrag> KesAuftrag { get; set; }
        public ICollection<KesDokument> KesDokument { get; set; }
        public ICollection<KesMandatsfuehrendePerson> KesMandatsfuehrendePerson { get; set; }
        public ICollection<KesMassnahmeBss> KesMassnahmeBss { get; set; }
        public ICollection<KesPflegekinderaufsicht> KesPflegekinderaufsicht { get; set; }
        public ICollection<KesPraevention> KesPraevention { get; set; }
        public ICollection<KesVerlauf> KesVerlauf { get; set; }
        public ICollection<ServiceCall> ServiceCall { get; set; }
        public ICollection<ServiceProcessError> ServiceProcessError { get; set; }
        public ICollection<UserSession> UserSession { get; set; }
        public ICollection<VmAntragEksk> VmAntragEksk { get; set; }
        public ICollection<VmBewertung> VmBewertung { get; set; }
        public ICollection<VmBudget> VmBudget { get; set; }
        public ICollection<VmErbschaftsdienst> VmErbschaftsdienst { get; set; }
        public ICollection<VmErnennung> VmErnennung { get; set; }
        public ICollection<VmInventar> VmInventar { get; set; }
        public ICollection<VmKlientenbudget> VmKlientenbudget { get; set; }
        public ICollection<VmMandBericht> VmMandBericht { get; set; }
        public ICollection<VmMandant> VmMandant { get; set; }
        public ICollection<VmSiegelung> VmSiegelung { get; set; }
        public ICollection<VmSituationsBericht> VmSituationsBericht { get; set; }
        public ICollection<VmTestament> VmTestament { get; set; }
        public ICollection<XDocTemplate> XdocTemplate { get; set; }
        public ICollection<XOrgUnit> XorgUnitChief { get; set; }
        public ICollection<XOrgUnit> XorgUnitRechtsdienstUser { get; set; }
        public ICollection<XOrgUnit> XorgUnitRepresentative { get; set; }
        public ICollection<XOrgUnit_User> XorgUnitUser { get; set; }
        public ICollection<XsearchControlTemplate> XsearchControlTemplate { get; set; }
        public ICollection<Xtask> XtaskUserIdErledigtNavigation { get; set; }
        public ICollection<Xtask> XtaskUserIdInBearbeitungNavigation { get; set; }
        public ICollection<XuserArchive> XuserArchive { get; set; }
        public ICollection<XuserBdeuserGroup> XuserBdeuserGroup { get; set; }
        public ICollection<XuserStundenansatz> XuserStundenansatz { get; set; }
        public ICollection<XUserUserGroup> XuserUserGroup { get; set; }
        public ICollection<XuserXdocTemplate> XuserXdocTemplate { get; set; }
        public int Id => UserId;
        public byte[] RowVersion => XUserTs;
    }
}