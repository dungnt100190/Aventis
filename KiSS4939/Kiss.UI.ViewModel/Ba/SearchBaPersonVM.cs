using Kiss.BL.Ba;
using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

namespace Kiss.UI.ViewModel.Ba
{
    public class SearchBaPersonVM : ViewModelCRUDListBase<BaPerson>
    {
        #region Constructors

        public SearchBaPersonVM()
            : base(Container.Resolve<BaPersonService>())
        {
        }

        #endregion

        #region Properties

        public BaPersonService BaPersonService
        {
            get { return ServiceCRUD as BaPersonService; }
        }

        public string SearchName
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void LoadData(IUnitOfWork unitOfWork)
        {
            EntityList = BaPersonService.Search(unitOfWork, SearchName);
        }

        #endregion

        #endregion
    }
}