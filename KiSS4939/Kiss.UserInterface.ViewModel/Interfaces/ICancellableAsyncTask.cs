using Kiss.UserInterface.ViewModel.Commanding;

namespace Kiss.UserInterface.ViewModel.Interfaces
{
    public interface ICancellableAsyncTask : IAsyncTask
    {
        /// <summary>
        /// Bricht eine laufende asynchrone Operation ab
        /// </summary>
        BaseCommand CancelCommand { get; }
    }
}
