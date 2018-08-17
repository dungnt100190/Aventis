using Kiss.Interfaces.BL;

namespace Kiss.Interfaces.ViewModel
{
    public interface IViewModelSearch
    {
        #region Properties

        bool ReadyForNewSearch
        {
            get;
        }

        IAsyncCommand SearchCommand
        {
            get;
        }

        KissServiceResult SearchValidationResult
        {
            get;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Performs a search.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns>True, if the search was successfully performed, false otherwise, i.e. there were search parameter validation errors.</returns>
        KissServiceResult Search(IUnitOfWork unitOfWork);

        #endregion
    }
}