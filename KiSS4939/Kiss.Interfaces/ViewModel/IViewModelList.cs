using System.Collections;

namespace Kiss.Interfaces.ViewModel
{
    public interface IViewModelList : IViewModel
    {
        #region Properties

        bool AllowSelectionChanging
        {
            get;
            set;
        }

        /// <summary>
        /// The list containing entities.
        /// </summary>
        IEnumerable EntityList
        {
            get;
        }

        /// <summary>
        /// The currently selected entity.
        /// </summary>
        object SelectedEntity
        {
            get;
            set;
        }

        #endregion
    }
}