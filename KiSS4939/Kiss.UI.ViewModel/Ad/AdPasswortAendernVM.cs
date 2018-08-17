using System.Linq;

using Kiss.BL;
using Kiss.BL.KissSystem;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.UI.ViewModel.Ad
{
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class AdPasswortAendernVM : ViewModelCRUDSingleEntityBase<XUser>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AdPasswortAendernVM"/> class.
        /// </summary>
        public AdPasswortAendernVM()
            : base(Container.Resolve<XUserService>())
        {
        }

        #endregion

        #region Properties

        public override bool HasMaskRight
        {
            get
            {
                return Maskenrecht != null;
            }
        }

        private XUserService Service
        {
            get { return (XUserService)ServiceCRUD; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init()
        {
            LoadData(null);
        }

        public override void LoadData(IUnitOfWork unitOfWork)
        {
            Entity = Service.GetCurrentUser(unitOfWork);
        }

        public KissServiceResult SaveNewPassword(string passwordOld, string passwordNew, string passwordRetype)
        {
            var xUserService = Container.Resolve<XUserService>();
            return xUserService.SaveNewPassword(null, passwordOld, passwordNew, passwordRetype);
        }

        #endregion

        #endregion
    }
}