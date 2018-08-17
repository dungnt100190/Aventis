using Kiss.Interfaces.BL;

namespace Kiss.Interfaces.ViewModel
{
    /// <summary>
    /// View model specialized for "CRUD" operations.
    /// </summary>
    public interface IViewModelCRUD : IViewModel
    {
        #region Methods

        /// <summary>
        /// Deletes the current entity or entities.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        KissServiceResult DeleteData(IUnitOfWork unitOfWork);

        /// <summary>
        /// Loads data from the database.
        /// </summary>
        /// <param name="unitOfWork"></param>
        void LoadData(IUnitOfWork unitOfWork);

        /// <summary>
        /// Creates a new entity. The entiy is not stored in the database yet.
        /// </summary>
        /// <returns></returns>
        KissServiceResult NewData();

        /// <summary>
        /// Saves the current entity or entities to the database.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        KissServiceResult SaveData(IUnitOfWork unitOfWork);

        /// <summary>
        /// Performs an undo operation.
        /// </summary>
        /// <returns>Return true if the undo was successfull</returns>
        bool UndoDataChanges();

        #endregion
    }
}