using System.Threading.Tasks;

namespace Kiss.Interfaces.ViewModel
{
    public interface ISearchableAsync
    {
        /// <summary>
        /// Toggle search Tabcontrol
        /// </summary>
        Task Search();
    }
}