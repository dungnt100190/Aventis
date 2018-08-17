using System.Collections.ObjectModel;

using Kiss.BL.Bde;
using Kiss.BL.Fs;
using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;
using Kiss.Model;
using Kiss.BL.KissSystem;

namespace Kiss.UI.ViewModel.Fs
{
    /// <summary>
    /// The ViewModel of the FsReduktion entity
    /// </summary>
    public class FsReduktionVM : ViewModelCRUDListBase<FsReduktion>
    {
        #region Fields

        #region Private Fields

        private ObservableCollection<BDELeistungsart> _leistungsarten;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FsReduktionVM"/> class.
        /// </summary>
        public FsReduktionVM()
            : base(Container.Resolve<FsReduktionService>())
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// List of all available "Leistungsarten".
        /// </summary>
        public ObservableCollection<BDELeistungsart> Leistungsarten
        {
            get
            {
                return _leistungsarten;
            }
            private set
            {
                _leistungsarten = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Leistungsarten);
            }
        }

        private FsReduktionService Service
        {
            get { return (FsReduktionService)ServiceCRUD; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Initializes the ViewModel
        /// </summary>
        public void Init()
        {
            BdeLeistungsartService leistungsartService = Container.Resolve<BdeLeistungsartService>();
            Leistungsarten = leistungsartService.GetData(null);

            BDELeistungsart noSelection = new BDELeistungsart
            {
                Bezeichnung = "",
                BDELeistungsartID = 0
            };
            Leistungsarten.Insert(0, noSelection);

            LoadData(null);
        }

        /// <summary>
        /// Gets the data from service
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use (can be null)</param>
        public override void LoadData(IUnitOfWork unitOfWork)
        {
            EntityList = Service.GetData(unitOfWork);
        }

        #endregion

        #endregion
    }
}