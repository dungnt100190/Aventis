using System.Threading.Tasks;

namespace Kiss.Interfaces.ViewModel
{
    public interface IDataCrudOperatorAsync
    {
        /// <summary>
        /// Save pending changes and add new row
        /// </summary>
        /// <returns>succeeded</returns>
        Task<bool> AddData();

        /// <summary>
        /// Save pending changes
        /// </summary>
        /// <returns>succeeded</returns>
        Task<bool> SaveData();

        /// <summary>
        /// Delete current row
        /// </summary>
        /// <returns>succseeded</returns>
        Task<bool> DeleteData();

        /// <summary>
        /// Restore logical deleted row.
        /// See boolean column IsDeleted
        /// </summary>
        /// <returns></returns>
        Task<bool> RestoreData();

        /// <summary>
        /// Discard pending changes
        /// </summary>
        Task UndoDataChanges();

        /// <summary>
        /// Save pending changes and reload data
        /// </summary>
        Task RefreshData();
    }
}