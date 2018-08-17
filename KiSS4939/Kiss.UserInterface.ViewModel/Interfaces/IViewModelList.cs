using System.Windows.Data;
using Kiss.UserInterface.ViewModel.Commanding;

namespace Kiss.UserInterface.ViewModel.Interfaces
{
    public interface IViewModelList : IViewModel
    {
        #region Properties

        /// <summary>
        /// The list containing entities.
        /// </summary>
        CollectionView EntityListView { get; }

        IDelegateCommand GoToFirstItem { get; }
        IDelegateCommand GoToPreviousItem { get; }
        IDelegateCommand GoToNextItem { get; }
        IDelegateCommand GoToLastItem { get; }

        #endregion
    }
}
