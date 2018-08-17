using Kiss.BL.Ba;
using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

namespace Kiss.UI.ViewModel.Ba
{
    public class BaPersonVM : ViewModelCRUDSingleEntityBase<BaPerson>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly int _baPersonId;

        #endregion

        #endregion

        #region Constructors

        public BaPersonVM(int baPersonId)
            : base(Container.Resolve<BaPersonService>())
        {
            _baPersonId = baPersonId;
        }

        #endregion

        #region Properties

        public BaPersonService BaPersonService
        {
            get { return ServiceCRUD as BaPersonService; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void LoadData(IUnitOfWork unitOfWork)
        {
            // Lese die Person mit der übergebenen ID
            Entity = BaPersonService.GetByIdWithBaAdresse(null, _baPersonId);
        }

        #endregion

        #endregion
    }
}