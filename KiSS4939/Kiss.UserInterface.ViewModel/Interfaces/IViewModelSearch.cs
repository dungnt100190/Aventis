using Kiss.Interfaces.BL;
using Kiss.UserInterface.ViewModel.Commanding;

namespace Kiss.UserInterface.ViewModel.Interfaces
{
    public interface IViewModelSearch
    {
        #region Properties

        IDelegateCommand RefreshCommand { get; }

        IDelegateCommand ResetCommand { get; }

        /// <summary>
        /// True, if the container (i.e. panel) with the search parameters on in is visible (i.e. maximized) or not (i.e. minimized
        /// This is on the VM since it influences how the VM reacts on the search command:
        /// - If the container is visible a search is performed
        /// - If not, SearchParametersVisible is set to true and the view should open the container
        /// </summary>
        bool SearchParametersVisible { get; }

        /// <summary>
        /// Performs a search asynchronously
        /// </summary>
        /// <returns>True, if the search was successfully performed, false otherwise, i.e. there were search parameter validation errors.</returns>
        ICancellableAsyncTask SearchTask { get; }

        /// <summary>
        /// Contains errors detected in search parameters
        /// </summary>
        IServiceResult SearchValidationResult { get; }

        #endregion
    }
}