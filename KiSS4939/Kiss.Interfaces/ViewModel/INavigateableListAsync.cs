using System.Threading.Tasks;

namespace Kiss.Interfaces.ViewModel
{
    public interface INavigateableListAsync
    {
        /// <summary>
        /// Move to first Row
        /// </summary>
        Task MoveFirst();

        /// <summary>
        /// Move to next Row
        /// </summary>
        Task MoveNext();

        /// <summary>
        /// Move to previous Row
        /// </summary>
        Task MovePrevious();

        /// <summary>
        /// Move to last Row
        /// </summary>
        Task MoveLast();
    }
}