using Kiss.DataAccess.Ba;
using Kiss.DataAccess.Fa;
using Kiss.DataAccess.Fs;
using Kiss.DataAccess.Interfaces;
using Kiss.DataAccess.Kes;
using Kiss.DataAccess.Log;
using Kiss.DataAccess.Sys;
using Kiss.DataAccess.Vm;
using Kiss.DbContext;

namespace Kiss.DataAccess
{
    // ToDo: generate with template
    public class KissUnitOfWork : UnitOfWork, IKissUnitOfWork
    {
        /// <summary>
        /// Erstellt eine neue (typisierte) UnitOfWork
        /// Als ConnectionString wird "KissContext" aus dem app.config verwendet
        /// -> für UnitTests verwenden
        /// </summary>
        public KissUnitOfWork()
            : base(new KissContext())
        {
        }

        /// <summary>
        /// Erstellt eine neue (typisierte) UnitOfWork
        /// ConnectionString (oder dessen Name im app.config) kann übergeben werden
        /// -> für Applikation mit auswählbarer DB verwenden
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public KissUnitOfWork(string nameOrConnectionString)
            : base(new KissContext(nameOrConnectionString))
        {
        }

        public virtual BaAdresseRepository BaAdresse
        {
            get { return (BaAdresseRepository)Repository<BaAdresse>(); }
        }

        public virtual BaEinwohnerregisterEmpfangeneEreignisseRepository BaEinwohnerregisterEmpfangeneEreignisse
        {
            get { return (BaEinwohnerregisterEmpfangeneEreignisseRepository)Repository<BaEinwohnerregisterEmpfangeneEreignisse>(); }
        }

        public virtual BaEinwohnerregisterEmpfangeneEreignisseRohdatenRepository BaEinwohnerregisterEmpfangeneEreignisseRohdaten
        {
            get { return (BaEinwohnerregisterEmpfangeneEreignisseRohdatenRepository)Repository<BaEinwohnerregisterEmpfangeneEreignisseRohdaten>(); }
        }

        public BaEinwohnerregisterPersonAnAbmeldungRepository BaEinwohnerregisterPersonAnAbmeldung
        {
            get { return (BaEinwohnerregisterPersonAnAbmeldungRepository)Repository<BaEinwohnerregisterPersonAnAbmeldung>(); }
        }

        public BaEinwohnerregisterPersonStatusRepository BaEinwohnerregisterPersonStatus
        {
            get { return (BaEinwohnerregisterPersonStatusRepository)Repository<BaEinwohnerregisterPersonStatus>(); }
        }

        public BaGemeindeRepository BaGemeinde
        {
            get { return (BaGemeindeRepository)Repository<BaGemeinde>(); }
        }

        public virtual BaGesundheitRepository BaGesundheit
        {
            get { return (BaGesundheitRepository)Repository<BaGesundheit>(); }
        }

        public virtual BaInstitutionRepository BaInstitution
        {
            get { return (BaInstitutionRepository)Repository<BaInstitution>(); }
        }

        public BaLandRepository BaLand
        {
            get { return (BaLandRepository)Repository<BaLand>(); }
        }

        public virtual BaPersonRepository BaPerson
        {
            get { return (BaPersonRepository)Repository<BaPerson>(); }
        }

        public BaPlzRepository BaPlz
        {
            get { return (BaPlzRepository)Repository<BaPLZ>(); }
        }

        public virtual BaPraemienverbilligungRepository BaPraemienverbilligung
        {
            get { return (BaPraemienverbilligungRepository)Repository<BaPraemienverbilligung>(); }
        }

        public IDbContext Context
        {
            get { return _context; }
        }

        public FaAktennotizenRepository FaAktennotizen
        {
            get { return (FaAktennotizenRepository)Repository<FaAktennotizen>(); }
        }

        public FaDokumentRepository FaDokument
        {
            get { return (FaDokumentRepository)Repository<FaDokumente>(); }
        }

        public FaDokumentAblageRepository FaDokumentAblage
        {
            get { return (FaDokumentAblageRepository)Repository<FaDokumentAblage>(); }
        }

        public FaFallRepository FaFall
        {
            get { return (FaFallRepository)Repository<FaFall>(); }
        }

        public FaFallPersonRepository FaFallPerson
        {
            get { return (FaFallPersonRepository)Repository<FaFallPerson>(); }
        }

        public virtual FaKategorisierungRepository FaKategorisierung
        {
            get { return (FaKategorisierungRepository)Repository<FaKategorisierung>(); }
        }

        public FaKategorisierungEksProduktRepository FaKategorisierungEksProdukt
        {
            get { return (FaKategorisierungEksProduktRepository)Repository<FaKategorisierungEksProdukt>(); }
        }

        public FaLeistungRepository FaLeistung
        {
            get { return (FaLeistungRepository)Repository<FaLeistung>(); }
        }

        public FaLeistungArchivRepository FaLeistungArchiv
        {
            get { return (FaLeistungArchivRepository)Repository<FaLeistungArchiv>(); }
        }

        public FaLeistungUserHistRepository FaLeistungUserHist
        {
            get { return (FaLeistungUserHistRepository)Repository<FaLeistungUserHist>(); }
        }

        public FaLeistungZugriffRepository FaLeistungZugriff
        {
            get { return (FaLeistungZugriffRepository)Repository<FaLeistungZugriff>(); }
        }

        public FaPendenzgruppeRepository FaPendenzgruppe
        {
            get { return (FaPendenzgruppeRepository)Repository<FaPendenzgruppe>(); }
        }

        public virtual FaPhaseRepository FaPhase
        {
            get { return (FaPhaseRepository)Repository<FaPhase>(); }
        }

        public FaWeisungRepository FaWeisung
        {
            get { return (FaWeisungRepository)Repository<FaWeisung>(); }
        }

        public virtual FbBuchungRepository FbBuchung
        {
            get { return (FbBuchungRepository)Repository<FbBuchung>(); }
        }

        public virtual FbKontoRepository FbKonto
        {
            get { return (FbKontoRepository)Repository<FbKonto>(); }
        }

        public virtual FbPeriodeRepository FbPeriode
        {
            get { return (FbPeriodeRepository)Repository<FbPeriode>(); }
        }

        public virtual FsDienstleistungspaketRepository FsDienstleistungspaket
        {
            get { return (FsDienstleistungspaketRepository)Repository<FsDienstleistungspaket>(); }
        }

        public KesArtikelRepository KesArtikel
        {
            get { return (KesArtikelRepository)Repository<KesArtikel>(); }
        }

        public KesAuftragRepository KesAuftrag
        {
            get { return (KesAuftragRepository)Repository<KesAuftrag>(); }
        }

        public KesBehoerdeRepository KesBehoerde
        {
            get
            {
                return (KesBehoerdeRepository)Repository<KesBehoerde>();
            }
        }

        public KesDokumentRepository KesDokument
        {
            get { return (KesDokumentRepository)Repository<KesDokument>(); }
        }

        public KesMandatsfuehrendePersonRepository KesMandatsfuehrendePerson
        {
            get { return (KesMandatsfuehrendePersonRepository)Repository<KesMandatsfuehrendePerson>(); }
        }

        public KesMassnahmeRepository KesMassnahme
        {
            get { return (KesMassnahmeRepository)Repository<KesMassnahme>(); }
        }

        public KesMassnahmeArtikelRepository KesMassnahmeArtikel
        {
            get { return (KesMassnahmeArtikelRepository)Repository<KesMassnahme_KesArtikel>(); }
        }

        public KesMassnahmeAuftragRepository KesMassnahmeAuftrag
        {
            get { return (KesMassnahmeAuftragRepository)Repository<KesMassnahmeAuftrag>(); }
        }

        public KesMassnahmeBerichtRepository KesMassnahmeBericht
        {
            get { return (KesMassnahmeBerichtRepository)Repository<KesMassnahmeBericht>(); }
        }

        public KesPflegekinderaufsichtRepository KesPflegekinderaufsicht
        {
            get { return (KesPflegekinderaufsichtRepository)Repository<KesPflegekinderaufsicht>(); }
        }

        public virtual KesPraeventionRepository KesPraevention
        {
            get { return (KesPraeventionRepository)Repository<KesPraevention>(); }
        }

        public KesVerlaufRepository KesVerlauf
        {
            get { return (KesVerlaufRepository)Repository<KesVerlauf>(); }
        }

        public ServiceCallRepository ServiceCall
        {
            get { return (ServiceCallRepository)Repository<ServiceCall>(); }
        }

        public ServiceProcessErrorRepository ServiceProcessError
        {
            get { return (ServiceProcessErrorRepository)Repository<ServiceProcessError>(); }
        }

        public ServiceProcessErrorMessageRepository ServiceProcessErrorMessage
        {
            get { return (ServiceProcessErrorMessageRepository)Repository<ServiceProcessErrorMessage>(); }
        }

        public UserSessionRepository UserSession
        {
            get { return (UserSessionRepository)Repository<UserSession>(); }
        }

        public VmKlientenbudgetRepository VmKlientenbudget
        {
            get { return (VmKlientenbudgetRepository)Repository<VmKlientenbudget>(); }
        }

        public virtual VmPositionRepository VmPosition
        {
            get { return (VmPositionRepository)Repository<VmPosition>(); }
        }

        public VmPositionsartRepository VmPositionsart
        {
            get { return (VmPositionsartRepository)Repository<VmPositionsart>(); }
        }

        public XClassRepository XClass
        {
            get { return (XClassRepository)Repository<XClass>(); }
        }

        public XConfigRepository XConfig
        {
            get { return (XConfigRepository)Repository<XConfig>(); }
        }

        public XDocumentRepository XDocument
        {
            get { return (XDocumentRepository)Repository<XDocument>(); }
        }

        public virtual XIconRepository XIcon
        {
            get { return (XIconRepository)Repository<XIcon>(); }
        }

        public virtual XLangTextRepository XLangText
        {
            get { return (XLangTextRepository)Repository<XLangText>(); }
        }

        public virtual XLovCodeRepository XLovCode
        {
            get { return (XLovCodeRepository)Repository<XLOVCode>(); }
        }

        public virtual XModulRepository XModul
        {
            get { return (XModulRepository)Repository<XModul>(); }
        }

        public XOrgUnitRepository XOrgUnit
        {
            get { return (XOrgUnitRepository)Repository<XOrgUnit>(); }
        }

        public XOrgUnit_UserRepository XOrgUnit_User
        {
            get { return (XOrgUnit_UserRepository)Repository<XOrgUnit_User>(); }
        }

        public XTaskRepository XTask
        {
            get { return (XTaskRepository)Repository<XTask>(); }
        }

        public XTaskAutoGeneratedRepository XTaskAutoGenerated
        {
            get { return (XTaskAutoGeneratedRepository)Repository<XTaskAutoGenerated>(); }
        }

        public virtual XUserRepository XUser
        {
            get { return (XUserRepository)Repository<XUser>(); }
        }

        public virtual XUserGroup_RightRepository XUserGroup_Right
        {
            get { return (XUserGroup_RightRepository)Repository<XUserGroup_Right>(); }
        }
    }
}