using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Kiss.BusinessLogic;
using Kiss.BusinessLogic.Fs;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;

namespace Kiss.UserInterface.ViewModel.Fs
{
    /// <summary>
    /// The ViewModel of the FsReduktion entity
    /// </summary>
    public class FsReduktionVM : ViewModelSearchListCRUD<FsReduktion, FsReduktion, object, int>
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
            get { return _leistungsarten; }
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
        protected override async Task InitAsync(InitParameters? initParameters = null)
        {
            var leistungsartService = Container.Resolve<ServiceCRUD<BDELeistungsart>>();
            Leistungsarten = new ObservableCollection<BDELeistungsart>(leistungsartService.GetAllEntities());

            var noSelection = new BDELeistungsart
            {
                Bezeichnung = string.Empty,
                BDELeistungsartID = 0
            };
            Leistungsarten.Insert(0, noSelection);

            SearchParametersVisible = true;
            SearchTask.StartCommand.Execute();
            await Task.Delay(1000);
        }

        #endregion

        #region Protected Methods

        protected override IServiceResult<IEnumerable<FsReduktion>> SearchInBackground(object searchParameters, CancellationToken cancellationToken)
        {
            Thread.Sleep(1500);
            var result = new ServiceResult<IEnumerable<FsReduktion>>(Service.GetAllEntities());
            return result;
        }

        #endregion

        #endregion
    }
}