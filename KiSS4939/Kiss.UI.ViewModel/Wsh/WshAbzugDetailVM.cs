using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Kiss.BL.Kbu;
using Kiss.BL.KissSystem;
using Kiss.BL.Wsh;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Kbu;
using Kiss.Model.DTO.Wsh;

namespace Kiss.UI.ViewModel.Wsh
{
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class WshAbzugDetailVM : ViewModelCRUDListBase<WshAbzugDetailDTO>
    {
        #region Fields

        #region Private Fields

        private LOVsGenerated.SysEditMode _editModeBetrifftPerson;
        private Dictionary<string, bool> _isFieldReadonly;
        private ObservableCollection<BaPerson> _personenHaushalt;
        private ObservableCollection<BaPerson> _personenHaushaltAlle;
        private List<BaPerson> _personenHaushaltDefault;
        private ObservableCollection<XLOVCode> _splittingart;
        private WshAbzugDTO _wshAbzugDto;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshAbzugDetailVM"/> class.
        /// </summary>
        public WshAbzugDetailVM()
            : base(Container.Resolve<WshAbzugDetailDTOService>())
        {
        }

        #endregion

        #region Properties

        public int FaLeistungId
        {
            get;
            private set;
        }

        public Dictionary<string, bool> IsFieldReadonly
        {
            get { return _isFieldReadonly; }
            set
            {
                _isFieldReadonly = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => IsFieldReadonly);
            }
        }

        public SearchForStringEventHandler KontoSearchEventHandler
        {
            get { return SearchGBLZulageKonto; }
        }

        public ObservableCollection<BaPerson> PersonenHaushalt
        {
            get { return _personenHaushalt; }
            set
            {
                _personenHaushalt = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => PersonenHaushalt);
            }
        }

        /// <summary>
        /// Personen welche zu irgendeinem Zeitpunkt im Haushalt unterstützt wurden.
        /// </summary>
        public ObservableCollection<BaPerson> PersonenHaushaltAlle
        {
            get { return _personenHaushaltAlle; }
            set
            {
                _personenHaushaltAlle = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => PersonenHaushaltAlle);
            }
        }

        public ObservableCollection<XLOVCode> Splittingart
        {
            get { return _splittingart; }
            set
            {
                if (_splittingart != value)
                {
                    _splittingart = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => Splittingart);
                }
            }
        }

        public WshAbzugDTO WshAbzugDto
        {
            get { return _wshAbzugDto; }
        }

        protected DateTime? Stichtag
        {
            get;
            private set;
        }

        private WshAbzugDetailDTOService Service
        {
            get { return (WshAbzugDetailDTOService)ServiceCRUD; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init(WshAbzugDTO wshAbzugDTO, ObservableCollection<XLOVCode> splittingArt, int faLeistungId, DateTime? stichtag)
        {
            _wshAbzugDto = wshAbzugDTO;
            Splittingart = splittingArt;
            FaLeistungId = faLeistungId;
            Stichtag = stichtag;

            InitPersonenImHaushalt();

            EntityList = _wshAbzugDto.WshAbzugDetailDto;
        }

        public override void LoadData(IUnitOfWork unitOfWork)
        {
            EntityList = Service.GetByWshAbzugId(unitOfWork, _wshAbzugDto.WshAbzug.WshAbzugID);
        }

        public override KissServiceResult NewData()
        {
            if (EntityList == null)
            {
                return new KissServiceResult(KissServiceResult.ResultType.Error, "ViewModelCRUDListBase_NoEntityListYet", "Programmierfehler: Einfügen nicht möglich, da noch keine Liste erzeugt wurde.");
            }
            WshAbzugDetailDTO newEntity;
            KissServiceResult retValue = Service.NewData(_wshAbzugDto.WshAbzug, out newEntity);

            if (retValue)
            {
                EntityList.Add(newEntity);

                SelectedEntity = newEntity;
            }

            ValidationResult = retValue;
            return retValue;
        }

        #endregion

        #region Protected Methods

        protected override void OnSelectedEntityChanged(WshAbzugDetailDTO selectedEntity, WshAbzugDetailDTO deselectedEntity)
        {
            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);

            UpdateHaushaltPersonen(Stichtag);
            UpdateIsFieldReadonly(null, SelectedEntity);
        }

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            base.OnSelectedEntityPropertyChanged(propertyName);

            var wshAbzugDetailString = PropertyName.GetPropertyName(() => SelectedEntity.WshAbzugDetail) + ".";
            var betragString = wshAbzugDetailString + PropertyName.GetPropertyName(() => SelectedEntity.WshAbzugDetail.Betrag);
            var kontoIdString = wshAbzugDetailString + PropertyName.GetPropertyName(() => SelectedEntity.WshAbzugDetail.KbuKontoID);

            if (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.GblAbzugProzent))
            {
                //GblAbzugProzent wurde aktualisiert, berechne Betrag
                Service.SetDetailAbzugBetrag(null, SelectedEntity);
            }
            else if (propertyName == betragString)
            {
                //betrag wurde aktualisiert, berechne GblAbzugProzent
                Service.SetGblAbzugProzent(null, SelectedEntity);
            }
            else if (propertyName == kontoIdString)
            {
                UpdateHaushaltPersonen(Stichtag);

                // erste Person oder UE auswählen wenn es nur eine in der Liste gibt
                if (PersonenHaushalt.Count() == 1 && SelectedEntity != null)
                {
                    SelectedEntity.WshAbzugDetail.BaPerson = PersonenHaushalt[0];
                }

                UpdateIsFieldReadonly(null, SelectedEntity);
                Service.SetGblAbzugProzent(null, SelectedEntity);
            }
        }

        #endregion

        #region Private Methods

        private void InitPersonenImHaushalt()
        {
            //Personen im Haushalt (für Grid).
            var haushaltPersonService = Container.Resolve<WshHaushaltPersonService>();
            PersonenHaushaltAlle = haushaltPersonService.GetPersonenHaushaltAlle(null, FaLeistungId);

            if(Stichtag.HasValue)
            {
                var haushaltPersonen = haushaltPersonService.GetHaushaltPersonen(null, FaLeistungId, Stichtag.Value);
                _personenHaushaltDefault = new List<BaPerson>();
                haushaltPersonen.ForEach(hp => _personenHaushaltDefault.Add(hp.BaPerson));
            }
            else
            {
                var haushaltPersonen = haushaltPersonService.GetHaushaltPersonen(null, FaLeistungId);
                _personenHaushaltDefault = new List<BaPerson>();
                haushaltPersonen.ForEach(hp => _personenHaushaltDefault.Add(hp.BaPerson));
            }

            //Personen im Haushalt (für DetailPanel)
            UpdateHaushaltPersonen(null);
        }

        /// <summary>
        /// Suche nach einem Konto.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        private List<object> SearchGBLZulageKonto(string searchString)
        {
            var list = new List<object>();
            var kontoService = Container.Resolve<WshKbuKontoService>();

            var kontoSearchParam = new KbuKontoSearchDTO
            {
                SearchString = searchString,
                WshKategorie = LOVsGenerated.WshKategorie.Ausgabe,
                Datum = DateTime.Today,
                ZulageOderGBL = true,
            };
            var result = kontoService.SearchKonto(null, kontoSearchParam).ToList();
            result.ForEach(list.Add);

            return list;
        }

        private void UpdateHaushaltPersonen(DateTime? stichtag)
        {
            if (SelectedEntity != null)
            {
                _editModeBetrifftPerson = Service.GetSysEditModePersonBetrifft(
                    SelectedEntity.WshAbzugDetail.KbuKontoID,
                    SelectedEntity.WshAbzugDetail.WshAbzug.WshGrundbudgetPosition.DatumVon,
                    SelectedEntity.WshAbzugDetail.WshAbzug.WshGrundbudgetPosition.DatumBis);
            }
            else
            {
                _editModeBetrifftPerson = LOVsGenerated.SysEditMode.ReadOnly;
            }

            PersonenHaushalt = new ObservableCollection<BaPerson>();

            if (_editModeBetrifftPerson == LOVsGenerated.SysEditMode.Normal
                || _editModeBetrifftPerson == LOVsGenerated.SysEditMode.ReadOnly)
            {
                PersonenHaushalt.Add(
                new BaPerson
                {
                    BaPersonID = -1,
                    Name = "UE",
                    Vorname = null
                });
            }

            if (_editModeBetrifftPerson == LOVsGenerated.SysEditMode.Normal
                || _editModeBetrifftPerson == LOVsGenerated.SysEditMode.Required)
            {
                _personenHaushaltDefault.ForEach(PersonenHaushalt.Add);
            }
        }

        private void UpdateIsFieldReadonly(IUnitOfWork unitOfWork, WshAbzugDetailDTO dto)
        {
            if (dto == null)
            {
                return;
            }

            //Enthält pro Feld ein bool. Wenn true => Feld ist readonly.
            var dict = new Dictionary<string, bool>();

            var istAbgeschlossen = dto.WshAbzugDetail.WshAbzug.IstAbgeschlossen;

            //ist aktuell ausgewähltes Konto ein GBL-Konto?
            var kontoService = Container.Resolve<KbuKontoService>();
            var gblKontoIds = kontoService.GetAllGblKontoIds(unitOfWork);
            bool isGblKonto = dto.WshAbzugDetail != null && gblKontoIds.Contains(dto.WshAbzugDetail.KbuKontoID);

            var onlyOnePersonAvailable = (PersonenHaushalt.Count == 1 && PersonenHaushalt.FirstOrDefault().BaPersonID == -1);
            var betrifftPersonIsMandatoryOrOptional = _editModeBetrifftPerson == LOVsGenerated.SysEditMode.Normal
                                                        || _editModeBetrifftPerson == LOVsGenerated.SysEditMode.Required;

            dict.Add("Kostenart", istAbgeschlossen);
            dict.Add("Betrifft", istAbgeschlossen || onlyOnePersonAvailable || !betrifftPersonIsMandatoryOrOptional);
            dict.Add("Betrag", istAbgeschlossen);
            dict.Add("GblAktuell", true);
            dict.Add("GblAbzugProzent", istAbgeschlossen || !isGblKonto);

            IsFieldReadonly = dict;
        }

        #endregion

        #endregion

        #region Other

        /*
        /// <summary>
        /// Gets the data from service.
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use (can be null)</param>
        public override void Search(IUnitOfWork unitOfWork)
        {
            EntityList = Service.GetData(unitOfWork);
        }
        */

        #endregion
    }
}