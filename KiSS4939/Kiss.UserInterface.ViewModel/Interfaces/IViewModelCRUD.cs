using System.Windows.Input;
using Kiss.UserInterface.ViewModel.Commanding;

namespace Kiss.UserInterface.ViewModel.Interfaces
{
    /// <summary>
    /// View model specialized for "CRUD" operations.
    /// </summary>
    public interface IViewModelCRUD
    {
        /// <summary>
        /// Deletes the current entity or entities.
        /// </summary>
        /// <returns></returns>
        IDelegateCommand DeleteDataCommand { get; }

        /// <summary>
        /// Creates a new entity. The entiy is not stored in the database yet.
        /// </summary>
        /// <returns></returns>
        IDelegateCommand NewDataCommand { get; }

        /// <summary>
        ///
        /// </summary>
        IDelegateCommand RefreshCommand { get; }

        /// <summary>
        /// Saves the current entity or entities to the database.
        /// </summary>
        /// <returns></returns>
        IDelegateCommand SaveDataCommand { get; }

        /// <summary>
        /// Performs an undo operation.
        /// </summary>
        /// <returns>Return true if the undo was successfull</returns>
        IDelegateCommand UndoDataChangesCommand { get; }
    }
}