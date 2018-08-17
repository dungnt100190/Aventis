using System.Windows.Forms;

namespace Kiss.Interfaces.UI
{
    /// <summary>
    /// Interface for general DataNavigation
    /// </summary>
    public interface IKissDataNavigator
    {
        /// <summary>
        /// Save pending changes and add new Row
        /// </summary>
        /// <returns>succseeded</returns>
        bool AddData();

        /// <summary>
        /// Save pending changes
        /// </summary>
        /// <returns>succseeded</returns>
        bool SaveData();

        /// <summary>
        /// Delete current Row
        /// </summary>
        /// <returns>succseeded</returns>
        bool DeleteData();

        /// <summary>
        /// To handel the KeyDown event in child-controls
        /// </summary>
        /// <param name="keyEvent">the <see cref="KeyEventArgs"/> that the user has pressed</param>
        /// <returns>true if the key could be handeld, else false</returns>
        bool KeyDownKiss(KeyEventArgs keyEvent);

        /// <summary>
        /// Restore logical deleted row.
        /// See bollean column IsDeleted
        /// </summary>
        /// <returns></returns>
        bool RestoreData();

        /// <summary>
        /// Discarde pending changes
        /// </summary>
        void UndoDataChanges();

        /// <summary>
        /// Save pending changes and reload Data
        /// </summary>
        void RefreshData();

        /// <summary>
        /// Move to first Row
        /// </summary>
        void MoveFirst();
        /// <summary>
        /// Move to next Row
        /// </summary>
        void MoveNext();
        /// <summary>
        /// Move to previous Row
        /// </summary>
        void MovePrevious();
        /// <summary>
        /// Move to last Row
        /// </summary>
        void MoveLast();

        /// <summary>
        /// Toggle search Tabcontrol
        /// </summary>
        void Search();
    }
}
