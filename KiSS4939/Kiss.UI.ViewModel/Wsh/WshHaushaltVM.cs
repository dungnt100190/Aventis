using System;
using System.Collections.ObjectModel;

using Kiss.BL.Ba;
using Kiss.BL.Fa;
using Kiss.BL.KissSystem;
using Kiss.BL.Wsh;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;

namespace Kiss.UI.ViewModel.Wsh
{
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class WshHaushaltVM : ViewModelCRUDListBase<WshHaushaltPerson>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly BaKlientensystemService _klientensystemService;
        private readonly FaLeistungService _leistungService;
        private readonly XLovService _xlovService;

        #endregion

        #region Private Fields

        private ObservableCollection<XLOVCode> _baGeschlechtLOV;
        private FaLeistung _faLeistung;
        private ObservableCollection<BaPerson> _klientensystemPersonen;
        private bool _nurAktuelleHaushaltPersonen = true;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshHaushaltVM"/> class.
        /// </summary>
        public WshHaushaltVM()
            : base(Container.Resolve<WshHaushaltPersonService>())
        {
            _klientensystemService = Container.Resolve<BaKlientensystemService>();
            _leistungService = Container.Resolve<FaLeistungService>();
            _xlovService = Container.Resolve<XLovService>();
        }

        #endregion

        #region Properties

        public ObservableCollection<XLOVCode> BaGeschlechtLOV
        {
            get { return _baGeschlechtLOV; }
            private set
            {
                if (_baGeschlechtLOV == value)
                {
                    return;
                }

                _baGeschlechtLOV = value;

                NotifyPropertyChanged.RaisePropertyChanged(() => BaGeschlechtLOV);
            }
        }

        public int FaFallID
        {
            get;
            set;
        }

        public ObservableCollection<BaPerson> KlientensystemPersonen
        {
            get { return _klientensystemPersonen; }

            protected set
            {
                if (_klientensystemPersonen == value)
                {
                    return;
                }

                _klientensystemPersonen = value;

                NotifyPropertyChanged.RaisePropertyChanged(() => KlientensystemPersonen);
            }
        }

        public bool NurAktuelleHaushaltPersonen
        {
            get { return _nurAktuelleHaushaltPersonen; }
            set
            {
                if (_nurAktuelleHaushaltPersonen == value)
                {
                    return;
                }

                _nurAktuelleHaushaltPersonen = value;

                NotifyPropertyChanged.RaisePropertyChanged(() => NurAktuelleHaushaltPersonen);

                LadeHaushalt();
            }
        }

        private WshHaushaltPersonService Service
        {
            get { return (WshHaushaltPersonService)ServiceCRUD; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init()
        {
        }

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init(int leistungId)
        {
            _faLeistung = _leistungService.GetById(null, leistungId);

            LadeHaushalt();

            KlientensystemPersonen = new ObservableCollection<BaPerson>(
                _klientensystemService.GetKlientensystemByFaFallId(null, _faLeistung.FaFallID));
            BaGeschlechtLOV = new ObservableCollection<XLOVCode>(_xlovService.GetLovCodeByLovName(null, "BaGeschlecht"));
        }

        public override void LoadData(IUnitOfWork unitOfWork)
        {
            // do nothing
        }

        public override KissServiceResult NewData()
        {
            var result = base.NewData();

            //We have to assign the FaLeistungID automatically
            SelectedEntity.FaLeistung = _faLeistung;

            return result;
        }

        #endregion

        #region Protected Methods

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            base.OnSelectedEntityPropertyChanged(propertyName);
            if (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.BaPerson))
            {
                var person = SelectedEntity.BaPerson;
                if (person != null)
                {
                    //ZH: Das Feld "Unterstützt" muss aus den Basis-Daten (person.PersonOhneLeistung) initialisiert werden
                    SelectedEntity.Unterstuetzt = !person.PersonOhneLeistung;
                }
            }
        }

        #endregion

        #region Private Methods

        private void LadeHaushalt()
        {
            if (_nurAktuelleHaushaltPersonen)
            {
                //Stichtag = DateTime.Today oder Enddatum der Leistung
                DateTime referenzDatum = _faLeistung.DatumBis ?? DateTime.Today;
                if (referenzDatum > DateTime.Today)
                {
                    referenzDatum = DateTime.Today;
                }

                EntityList = new ObservableCollection<WshHaushaltPerson>(Service.GetHaushaltPersonen(null, _faLeistung.FaLeistungID, referenzDatum));
            }
            else
            {
                //Alle
                EntityList = new ObservableCollection<WshHaushaltPerson>(Service.GetHaushaltPersonen(null, _faLeistung.FaLeistungID));
            }
        }

        #endregion

        #endregion
    }
}