using System.Linq;

using Kiss.BL.Ba;
using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

namespace Kiss.UI.ViewModel.Ba
{
    public class BaAdresseVM : ViewModelCRUDListBase<BaAdresse>
    {
        #region Constructors

        public BaAdresseVM(TrackableCollection<BaAdresse> baAdressen)
            : base(Container.Resolve<BaAdresseService>())
        {
            EntityList = baAdressen;

            InitProperties();
        }

        public BaAdresseVM(int baPersonID)
            : base(Container.Resolve<BaAdresseService>())
        {
            // TODO: Get Adressen aufgrund der BaPersonID

            InitProperties();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Abgeleitetes Property, das als Readonly-Binding-Property zur Verfügung gestellt wird hier, inkl. NotifyPropertyChanged, wenn sich in der Collection was ändert
        /// </summary>
        public int AnzahlAdressen
        {
            get { return EntityList.Count(); }
        }

        public BaAdresseService BaAdresseService
        {
            get { return ServiceCRUD as BaAdresseService; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void LoadData(IUnitOfWork unitOfWork)
        {
            // do nothing
        }

        #endregion

        #region Private Methods

        private void InitProperties()
        {
            EntityList.CollectionChanged += (s, e) => NotifyPropertyChanged.RaisePropertyChanged(() => AnzahlAdressen);
        }

        #endregion

        #endregion
    }
}