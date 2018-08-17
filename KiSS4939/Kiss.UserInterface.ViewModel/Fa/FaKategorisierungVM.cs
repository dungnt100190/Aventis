using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kiss.BusinessLogic;
using Kiss.BusinessLogic.Fa;
using Kiss.BusinessLogic.Sys;
using Kiss.BusinessLogic.Sys.NodeEnumeration;
using Kiss.DbContext;
using Kiss.DbContext.DTO.KissSystem;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;

namespace Kiss.UserInterface.ViewModel.Fa
{
    /// <summary>
    /// The ViewModel of the FaKategorisierung entity.
    /// </summary>
    public class FaKategorisierungVM : ViewModelSearchListCRUD<FaKategorisierung, FaKategorisierung, int, int>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string FAKATEGORIE = "FaKategorie";

        // ToDo: replace with enum (e.g. FaListOfValues)
        private const string FAKATEGORISIERUNGABSCHLUSSGRUND = "FaKategorisierungAbschlussgrund";

        private const string FAKATEGORISIERUNGEKSOPTION = "FaKategorisierungEksOption";
        private const string FAKATEGORISIERUNGINTAKE = "FaKategorisierungIntake";
        private const string FAKATEGORISIERUNGKISTATUS = "FaKategorisierungKiStatus";
        private const string FAKATEGORISIERUNGKOOPERATION = "FaKategorisierungKooperation";
        private const string FAKATEGORISIERUNGRESSOURCEN = "FaKategorisierungRessourcen";

        #endregion

        #region Private Fields

        private IList<XLOVCode> _fadategorisierungintake;
        private IList<XLOVCode> _fakategorie;
        private IList<XLOVCode> _faKategorisierungabschlussgrund;
        private IList<XLOVCode> _faKategorisierungEksOption;
        private IList<FaKategorisierungEksProdukt> _faKategorisierungEksProdukt;
        private IList<XLOVCode> _fakategorisierungkistatus;
        private IList<XLOVCode> _fakategorisierungkooperation;
        private IList<XLOVCode> _fakategorisierungressourcen;
        private bool _isUserFallfuehrer;
        private bool _nurFallfuehrerDarfMutieren;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FaKategorisierungVM"/> class.
        /// </summary>
        public FaKategorisierungVM()
            : base(Container.Resolve<FaKategorisierungService>())
        {
            RequiredParameters = InitParameterValue.BaPersonID;
        }

        #endregion

        #region Properties

        /// <summary>
        /// List of all available "FaKategorisierungRessourcen".
        /// </summary>
        public IList<XLOVCode> FaKategorie
        {
            get { return _fakategorie; }
            private set { SetProperty(ref _fakategorie, value, () => FaKategorie); }
        }

        /// <summary>
        /// List of all available "FaKategorisierungAbschlussgrund".
        /// </summary>
        public IList<XLOVCode> FaKategorisierungAbschlussgrund
        {
            get { return _faKategorisierungabschlussgrund; }
            private set { SetProperty(ref _faKategorisierungabschlussgrund, value, () => FaKategorisierungAbschlussgrund); }
        }

        /// <summary>
        /// List of all available "FaKategorisierungEksOption".
        /// </summary>
        public IList<XLOVCode> FaKategorisierungEksOption
        {
            get { return _faKategorisierungEksOption; }
            private set { SetProperty(ref _faKategorisierungEksOption, value, () => FaKategorisierungEksOption); }
        }

        /// <summary>
        /// List of all available "FaKategorisierungEksProdukt".
        /// </summary>
        public IList<FaKategorisierungEksProdukt> FaKategorisierungEksProdukt
        {
            get { return _faKategorisierungEksProdukt; }
            private set { SetProperty(ref _faKategorisierungEksProdukt, value, () => FaKategorisierungEksProdukt); }
        }

        /// <summary>
        /// List of all available "FaKategorisierungIntake".
        /// </summary>
        public IList<XLOVCode> FaKategorisierungIntake
        {
            get { return _fadategorisierungintake; }
            private set { SetProperty(ref _fadategorisierungintake, value, () => FaKategorisierungIntake); }
        }

        /// <summary>
        /// List of all available "FaKategorisierungKiStatus".
        /// </summary>
        public IList<XLOVCode> FaKategorisierungKiStatus
        {
            get { return _fakategorisierungkistatus; }
            private set { SetProperty(ref _fakategorisierungkistatus, value, () => FaKategorisierungKiStatus); }
        }

        /// <summary>
        /// List of all available "FaKategorisierungKooperation".
        /// </summary>
        public IList<XLOVCode> FaKategorisierungKooperation
        {
            get { return _fakategorisierungkooperation; }
            private set { SetProperty(ref _fakategorisierungkooperation, value, () => FaKategorisierungKooperation); }
        }

        /// <summary>
        /// List of all available "FaKategorisierungRessourcen".
        /// </summary>
        public IList<XLOVCode> FaKategorisierungRessourcen
        {
            get { return _fakategorisierungressourcen; }
            private set { SetProperty(ref _fakategorisierungressourcen, value, () => FaKategorisierungRessourcen); }
        }

        public override bool HasMaskRight
        {
            get { return base.HasMaskRight && (!_nurFallfuehrerDarfMutieren || _isUserFallfuehrer); }
        }

        /// <summary>
        /// For better understanding only
        /// </summary>
        private int BaPersonID
        {
            get { return SearchParameters; }
            set { SearchParameters = value; }
        }

        private FaKategorisierungService Service
        {
            get { return (FaKategorisierungService)ServiceCRUD; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        protected override async Task InitAsync(InitParameters? initParameters = null)
        {
            BaPersonID = initParameters.Value.BaPersonID.Value;

            var xlovService = Container.Resolve<XLovService>();
            FaKategorisierungAbschlussgrund = xlovService.GetLovCodesByLovName(FAKATEGORISIERUNGABSCHLUSSGRUND, true);
            FaKategorisierungRessourcen = xlovService.GetLovCodesByLovName(FAKATEGORISIERUNGRESSOURCEN, true);
            FaKategorisierungKooperation = xlovService.GetLovCodesByLovName(FAKATEGORISIERUNGKOOPERATION, true);
            FaKategorisierungIntake = xlovService.GetLovCodesByLovName(FAKATEGORISIERUNGINTAKE, true);
            FaKategorisierungKiStatus = xlovService.GetLovCodesByLovName(FAKATEGORISIERUNGKISTATUS, true);
            FaKategorisierungEksOption = xlovService.GetLovCodesByLovName(FAKATEGORISIERUNGEKSOPTION, true);
            FaKategorie = xlovService.GetLovCodesByLovName(FAKATEGORIE, true);

            var faKategorisierungEksProduktService = Container.Resolve<FaKategorisierungEksProduktService>();
            FaKategorisierungEksProdukt = faKategorisierungEksProduktService.GetProdukteForCurrentUser(true);

            SearchTask.StartCommand.Execute();

            RefreshAfterSave = true;
        }

        protected override void InitNewEntity(FaKategorisierung entity)
        {
            entity.BaPersonID = BaPersonID;
            entity.UserID = Container.Resolve<ISessionService>().AuthenticatedUser.UserID;
            entity.Datum = DateTime.Today;
        }

        protected override IServiceResult<IEnumerable<FaKategorisierung>> SearchInBackground(int searchParameters, System.Threading.CancellationToken cancellationToken)
        {
            return new ServiceResult<IEnumerable<FaKategorisierung>>(Service.GetByBaPersonId(searchParameters));
        }

        #endregion

        #region Protected Methods

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            base.OnSelectedEntityPropertyChanged(propertyName);

            if (SelectedEntity == null)
            {
                return;
            }

            var kat = SelectedEntity;

            if (propertyName == PropertyName.GetPropertyName(() => kat.FaKategorisierungEksProduktID) && kat.FaKategorisierungEksProduktID != null)
            {
                kat.FaKategorisierungIntakeCode = null;
                kat.FaKategorisierungKiStatusCode = null;
                kat.FaKategorisierungKooperationCode = null;
                kat.FaKategorisierungRessourcenCode = null;
            }
            else if (propertyName == PropertyName.GetPropertyName(() => kat.FaKategorisierungEksOptionCode) && kat.FaKategorisierungEksOptionCode != null)
            {
                kat.FaKategorisierungKiStatusCode = null;
                kat.FaKategorisierungIntakeCode = null;
                kat.FaKategorisierungKooperationCode = null;
                kat.FaKategorisierungRessourcenCode = null;
            }
            else if (propertyName == PropertyName.GetPropertyName(() => kat.FaKategorisierungKiStatusCode) && kat.FaKategorisierungKiStatusCode != null)
            {
                kat.FaKategorisierungEksProduktID = null;
                kat.FaKategorisierungEksOptionCode = null;
                kat.FaKategorisierungIntakeCode = null;
                kat.FaKategorisierungKooperationCode = null;
                kat.FaKategorisierungRessourcenCode = null;
            }
            else if (propertyName == PropertyName.GetPropertyName(() => kat.FaKategorisierungIntakeCode) && kat.FaKategorisierungIntakeCode != null)
            {
                kat.FaKategorisierungEksProduktID = null;
                kat.FaKategorisierungEksOptionCode = null;
                kat.FaKategorisierungKiStatusCode = null;
                kat.FaKategorisierungKooperationCode = null;
                kat.FaKategorisierungRessourcenCode = null;
            }
            else if ((propertyName == PropertyName.GetPropertyName(() => kat.FaKategorisierungKooperationCode) && kat.FaKategorisierungKooperationCode != null) ||
                     (propertyName == PropertyName.GetPropertyName(() => kat.FaKategorisierungRessourcenCode) && kat.FaKategorisierungRessourcenCode != null))
            {
                kat.FaKategorisierungEksProduktID = null;
                kat.FaKategorisierungEksOptionCode = null;
                kat.FaKategorisierungKiStatusCode = null;
                kat.FaKategorisierungIntakeCode = null;
            }
        }

        #endregion

        #region Private Methods

        protected override MaskenRechtDTO OverrideMaskenrecht(MaskenRechtDTO maskenRecht)
        {
            _isUserFallfuehrer = false;
            var sessionService = Container.Resolve<ISessionService>();
            if (sessionService.AuthenticatedUser != null)
            {
                var userId = sessionService.AuthenticatedUser.UserID;
                var leistungService = Container.Resolve<FaLeistungService>();
                _isUserFallfuehrer = leistungService.IsUserFallfuehrer(userId, BaPersonID);
            }

            var configService = Container.Resolve<XConfigService>();
            _nurFallfuehrerDarfMutieren = configService.GetConfigValue(ConfigNodes.System_Fallfuehrung_Kategorisierung_NurFallfuehrerDarfMutieren);

            if (_nurFallfuehrerDarfMutieren && !_isUserFallfuehrer)
            {
                maskenRecht.CanInsert = false;
                maskenRecht.CanUpdate = false;
                maskenRecht.CanDelete = false;
            }
            return maskenRecht;
        }

        #endregion

        #endregion
    }
}