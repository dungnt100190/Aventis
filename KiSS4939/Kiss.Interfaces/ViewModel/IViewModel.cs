using System.Collections.Specialized;
using System.Threading.Tasks;

using Kiss.Interfaces.BL;
using Kiss.Interfaces.UI;

namespace Kiss.Interfaces.ViewModel
{
    public interface IViewModel : IKissContext
    {
        #region Properties

        /// <summary>
        /// If there are some validation errors,
        /// this property will have the value true.
        /// </summary>
        bool HasErrors { get; }

        bool HasMaskRight { get; }

        //string MaskName { get; set; }

        bool IsBusy { get; set; } // ToDo: rename to IsCompletelyBusy

        KissServiceResult ValidationResult { get; }

        #endregion

        #region Methods

        Task Init(InitParameters? initParameters = null);

        bool JumpToPath(HybridDictionary parameters); // ToDo: remove

        #endregion
    }
}