using System.Collections.Specialized;
using System.Threading.Tasks;

using Kiss.Interfaces.BL;
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;

namespace Kiss.UserInterface.ViewModel.Interfaces
{
    public interface IViewModel : IKissContext
    {
        /// <summary>
        /// If there are some validation errors,
        /// this property will have the value true.
        /// </summary>
        bool HasErrors { get; }

        bool HasMaskRight { get; }

        bool IsCompletelyBusy { get; }

        IServiceResult ValidationResult { get; }

        bool BeforeCloseView();

        Task Init(InitParameters? initParameters = null);

        bool JumpToPath(HybridDictionary parameters); // ToDo: remove
    }
}