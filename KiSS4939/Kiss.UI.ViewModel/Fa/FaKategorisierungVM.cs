using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BL.Fa;
using Kiss.BL.KissSystem;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Model;
using Kiss.Model.DTO.Fa;

namespace Kiss.UI.ViewModel.Fa
{
    /// <summary>
    /// The ViewModel of the FaKategorisierung entity.
    /// </summary>
    public class FaKategorisierungVM : ViewModelCRUDListBase<FaKategorisierungDTO>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string FAKATEGORISIERUNGABSCHLUSSGRUND = "FaKategorisierungAbschlussgrund";
        private const string FAKATEGORISIERUNGEKSOPTION = "FaKategorisierungEksOption";
        private const string FAKATEGORISIERUNGINTAKE = "FaKategorisierungIntake";
        private const string FAKATEGORISIERUNGKISTATUS = "FaKategorisierungKiStatus";
        private const string FAKATEGORISIERUNGKOOPERATION = "FaKategorisierungKooperation";
        private const string FAKATEGORISIERUNGRESSOURCEN = "FaKategorisierungRessourcen";

        #endregion

        #region Private Fields

        private int _baPersonId;
        private List<XLOVCode> _faKategorisierungEksOption;
        private List<FaKategorisierungEksProdukt> _faKategorisierungEksProdukt;
        private List<XLOVCode> _faKategorisierungabschlussgrund;
        private List<XLOVCode> _fadategorisierungintake;
        private List<XLOVCode> _fakategorisierungkistatus;
        private List<XLOVCode> _fakategorisierungkooperation;
        private List<XLOVCode> _fakategorisierungressourcen;
        private bool _isUserFallfuehrer;
        private bool _nurFallfuehrerDarfMutieren;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FaKategorisierungVM"/> class.
        /// </summary>
        public FaKategorisierungVM()
            : base(Container.Resolve<FaKategorisierungDTOService>())
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// List of all available "FaKategorisierungAbschlussgrund".
        /// </summary>
        public List<XLOVCode> FaKategorisierungAbschlussgrund
        {
            get { return _faKategorisierungabschlussgrund; }
            private set { SetProperty(ref _faKategorisierungabschlussgrund, value, () => FaKategorisierungAbschlussgrund); }
        }

        /// <summary>
        /// List of all available "FaKategorisierungEksOption".
        /// </summary>
        public List<XLOVCode> FaKategorisierungEksOption
        {
            get { return _faKategorisierungEksOption; }
            private set { SetProperty(ref _faKategorisierungEksOption, value, () => FaKategorisierungEksOption); }
        }

        /// <summary>
        /// List of all available "FaKategorisierungEksProdukt".
        /// </summary>
        public List<FaKategorisierungEksProdukt> FaKategorisierungEksProdukt
        {
            get { return _faKategorisierungEksProdukt; }
            private set { SetProperty(ref _faKategorisierungEksProdukt, value, () => FaKategorisierungEksProdukt); }
        }

        /// <summary>
        /// List of all available "FaKategorisierungIntake".
        /// </summary>
        public List<XLOVCode> FaKategorisierungIntake
        {
            get { return _fadategorisierungintake; }
            private set { SetProperty(ref _fadategorisierungintake, value, () => FaKategorisierungIntake); }
        }

        /// <summary>
        /// List of all available "FaKategorisierungKiStatus".
        /// </summary>
        public List<XLOVCode> FaKategorisierungKiStatus
        {
            get { return _fakategorisierungkistatus; }
            private set { SetProperty(ref _fakategorisierungkistatus, value, () => FaKategorisierungKiStatus); }
        }

        /// <summary>
        /// List of all available "FaKategorisierungKooperation".
        /// </summary>
        public List<XLOVCode> FaKategorisierungKooperation
        {
            get { return _fakategorisierungkooperation; }
            private set { SetProperty(ref _fakategorisierungkooperation, value, () => FaKategorisierungKooperation); }
        }

        /// <summary>
        /// List of all available "FaKategorisierungRessourcen".
        /// </summary>
        public List<XLOVCode> FaKategorisierungRessourcen
        {
            get { return _fakategorisierungressourcen; }
            private set { SetProperty(ref _fakategorisierungressourcen, value, () => FaKategorisierungRessourcen); }
        }

        public override bool HasMaskRight
        {
            get
            {
                return base.HasMaskRight && (!_nurFallfuehrerDarfMutieren || _isUserFallfuehrer);
            }
        }

        private FaKategorisierungDTOService Service
        {
            get { return (FaKategorisierungDTOService)ServiceCRUD; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init(int baPersonId)
        {
            _baPersonId = baPersonId;

            SetMaskenrecht();

            var xlovService = Container.Resolve<XLovService>();
            FaKategorisierungAbschlussgrund = xlovService.GetLovCodeByLovName(null, FAKATEGORISIERUNGABSCHLUSSGRUND, true);
            FaKategorisierungRessourcen = xlovService.GetLovCodeByLovName(null, FAKATEGORISIERUNGRESSOURCEN, true);
            FaKategorisierungKooperation = xlovService.GetLovCodeByLovName(null, FAKATEGORISIERUNGKOOPERATION, true);
            FaKategorisierungIntake = xlovService.GetLovCodeByLovName(null, FAKATEGORISIERUNGINTAKE, true);
            FaKategorisierungKiStatus = xlovService.GetLovCodeByLovName(null, FAKATEGORISIERUNGKISTATUS, true);
            FaKategorisierungEksOption = xlovService.GetLovCodeByLovName(null, FAKATEGORISIERUNGEKSOPTION, true);

            var faKategorisierungEksProduktService = Container.Resolve<FaKategorisierungEksProduktService>();
            FaKategorisierungEksProdukt = faKategorisierungEksProduktService.GetDataForCurrentUser(null, true);

            LoadData(null);
        }

        public override void LoadData(IUnitOfWork unitOfWork)
        {
            EntityList = Service.GetByBaPersonId(unitOfWork, _baPersonId);
        }

        public override KissServiceResult NewData()
        {
            var result = base.NewData();

            if (result)
            {
                SelectedEntity.FaKategorisierung.BaPersonID = _baPersonId;
                SelectedEntity.FaKategorisierung.Datum = DateTime.Today;
            }

            return result;
        }

        public override KissServiceResult SaveData(IUnitOfWork unitOfWork)
        {
            var selectedEntityIsNew = false;
            var dataToSave = SelectedEntity;

            if (SelectedEntity != null)
            {
                selectedEntityIsNew = SelectedEntity.ChangeTracker.State == ObjectState.Added;
            }

            var serviceResult = base.SaveData(unitOfWork);

            if (!serviceResult.IsOk)
            {
                return serviceResult;
            }

            if (selectedEntityIsNew)
            {
                var ohneAbschluss = EntityList.FirstOrDefault(
                    k => !k.FaKategorisierung.Abschlussdatum.HasValue
                         && SelectedEntity.FaKategorisierung.FaKategorisierungID != k.FaKategorisierung.FaKategorisierungID
                         && SelectedEntity.FaKategorisierung.BaPersonID == k.FaKategorisierung.BaPersonID);

                if (ohneAbschluss != null && ohneAbschluss.FaKategorisierung.Datum < SelectedEntity.FaKategorisierung.Datum)
                {
                    ohneAbschluss.FaKategorisierung.Abschlussdatum = SelectedEntity.FaKategorisierung.Datum.AddDays(-1);

                    SelectedEntity = ohneAbschluss;
                    serviceResult += base.SaveData(unitOfWork);
                    SelectedEntity = dataToSave;
                }
            }

            return serviceResult;
        }

        #endregion

        #region Protected Methods

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            base.OnSelectedEntityPropertyChanged(propertyName);

            if (SelectedEntity == null || SelectedEntity.FaKategorisierung == null)
            {
                return;
            }

            var kat = SelectedEntity.FaKategorisierung;
            var faKategorisierungProperty = propertyName.Replace(PropertyName.GetPropertyName(() => SelectedEntity.FaKategorisierung) + ".", "");

            if (faKategorisierungProperty == PropertyName.GetPropertyName(() => kat.FaKategorisierungEksProduktID) && kat.FaKategorisierungEksProduktID != null)
            {
                kat.FaKategorisierungIntakeCode = null;
                kat.FaKategorisierungKiStatusCode = null;
                kat.FaKategorisierungKooperationCode = null;
                kat.FaKategorisierungRessourcenCode = null;
                // Pendenz löschen wenn die Frist ändert und die Pendenz noch nicht nötig ist
                Service.UpdatePendenzenOfKategorisierung(null, SelectedEntity.FaKategorisierung.FaKategorisierungID, SelectedEntity.FaKategorisierung.Datum, SelectedEntity.FaKategorisierung.FaKategorisierungEksProduktID);
            }
            else if (faKategorisierungProperty == "Datum" && kat.FaKategorisierungEksProduktID != null)
            {
                // Pendenz löschen wenn die Frist ändert und die Pendenz noch nicht nötig ist
                Service.UpdatePendenzenOfKategorisierung(null, SelectedEntity.FaKategorisierung.FaKategorisierungID, SelectedEntity.FaKategorisierung.Datum, SelectedEntity.FaKategorisierung.FaKategorisierungEksProduktID);
            }
            else if (faKategorisierungProperty == PropertyName.GetPropertyName(() => kat.FaKategorisierungEksOptionCode) && kat.FaKategorisierungEksOptionCode != null)
            {
                kat.FaKategorisierungKiStatusCode = null;
                kat.FaKategorisierungIntakeCode = null;
                kat.FaKategorisierungKooperationCode = null;
                kat.FaKategorisierungRessourcenCode = null;
            }
            else if (faKategorisierungProperty == PropertyName.GetPropertyName(() => kat.FaKategorisierungKiStatusCode) && kat.FaKategorisierungKiStatusCode != null)
            {
                kat.FaKategorisierungEksProduktID = null;
                kat.FaKategorisierungEksOptionCode = null;
                kat.FaKategorisierungIntakeCode = null;
                kat.FaKategorisierungKooperationCode = null;
                kat.FaKategorisierungRessourcenCode = null;
            }
            else if (faKategorisierungProperty == PropertyName.GetPropertyName(() => kat.FaKategorisierungIntakeCode) && kat.FaKategorisierungIntakeCode != null)
            {
                kat.FaKategorisierungEksProduktID = null;
                kat.FaKategorisierungEksOptionCode = null;
                kat.FaKategorisierungKiStatusCode = null;
                kat.FaKategorisierungKooperationCode = null;
                kat.FaKategorisierungRessourcenCode = null;
            }
            else if ((faKategorisierungProperty == PropertyName.GetPropertyName(() => kat.FaKategorisierungKooperationCode) && kat.FaKategorisierungKooperationCode != null) ||
                     (faKategorisierungProperty == PropertyName.GetPropertyName(() => kat.FaKategorisierungRessourcenCode) && kat.FaKategorisierungRessourcenCode != null))
            {
                kat.FaKategorisierungEksProduktID = null;
                kat.FaKategorisierungEksOptionCode = null;
                kat.FaKategorisierungKiStatusCode = null;
                kat.FaKategorisierungIntakeCode = null;
            }
        }

        #endregion

        #region Private Methods

        private void SetMaskenrecht()
        {
            var configService = Container.Resolve<XConfigService>();
            _nurFallfuehrerDarfMutieren = configService.GetConfigValue(@"System\Fallfuehrung\Kategorisierung\NurFallfuehrerDarfMutieren", DateTime.Now, false);

            if (_nurFallfuehrerDarfMutieren)
            {
                var leistungService = Container.Resolve<FaLeistungService>();
                int userId = 0;
                var sessionService = Container.Resolve<ISessionService>();
                if (sessionService.AuthenticatedUser != null)
                {
                    userId = sessionService.AuthenticatedUser.UserID;
                }

                _isUserFallfuehrer = leistungService.IsUserFallfuehrer(null, userId, _baPersonId);

                if (!_isUserFallfuehrer)
                {
                    Maskenrecht.CanInsert = false;
                    Maskenrecht.CanUpdate = false;
                    Maskenrecht.CanDelete = false;
                }
            }
        }

        #endregion

        #endregion
    }
}