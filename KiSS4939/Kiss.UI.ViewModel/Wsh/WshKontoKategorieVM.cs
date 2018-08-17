using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Kiss.BL.Wsh;
using Kiss.Infrastructure.Enumeration;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;
using Kiss.BL.KissSystem;

namespace Kiss.UI.ViewModel.Wsh
{
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class WshKontoKategorieVM : ViewModelCRUDListBase<WshKategorieKontoDTO>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly Dictionary<WshKategorieKbuKontoVerfuegbar, string> _kategorieKontoZuordnung;
        private readonly WshKategorieService _kategorieSvc = Container.Resolve<WshKategorieService>();

        #endregion

        #region Private Fields

        private WshKategorieKontoDTOService _kategorieKtoSvc = Container.Resolve<WshKategorieKontoDTOService>();
        private List<WshKategorie> _kategories;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshKontoKategorieVM"/> class.
        /// </summary>
        public WshKontoKategorieVM()
            : base(Container.Resolve<WshKategorieKontoDTOService>())
        {
            Kategorien = _kategorieSvc.GetKategorien(null);

            _kategorieKontoZuordnung = new Dictionary<WshKategorieKbuKontoVerfuegbar, string>{
                                            {WshKategorieKbuKontoVerfuegbar.Nein, ""},
                                            {WshKategorieKbuKontoVerfuegbar.Ja, "x"},
                                            {WshKategorieKbuKontoVerfuegbar.JaMitSpezialrecht, "s"}};
        }

        #endregion

        #region Properties

        public Dictionary<WshKategorieKbuKontoVerfuegbar, string> KategorieKontoZuordnung
        {
            get
            {
                return _kategorieKontoZuordnung;
            }
        }

        public List<WshKategorie> Kategorien
        {
            get { return _kategories; }
            set
            {
                _kategories = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Kategorien);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override KissServiceResult DeleteData(IUnitOfWork unitOfWork)
        {
            return KissServiceResult.Error(new Exception("Sie können hier keine Kontos löschen."));
        }

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init()
        {
            LoadData(null);
        }

        public override void LoadData(IUnitOfWork unitOfWork)
        {
            EntityList = ServiceCRUD.GetData(unitOfWork);
        }

        public override KissServiceResult NewData()
        {
            return KissServiceResult.Error(new Exception("Sie können hier keine neuen Kontos erfassen."));
        }

        public override bool UndoDataChanges()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}