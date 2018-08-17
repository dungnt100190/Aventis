using System.ComponentModel;
using Kiss.UserInterface.ViewModel.Commanding;

namespace Kiss.UserInterface.ViewModel.Interfaces
{
    public interface IAsyncTask : INotifyPropertyChanged
    {
        /// <summary>
        /// Startet die asynchrone Operation
        /// </summary>
        /// <remarks>BaseCommand (statt ICommand) wird verwendet, um Statusänderungen an IsEnabled per INotifyPropertyChanged zu erhalten</remarks>
        BaseCommand StartCommand { get; }

        /// <summary>
        /// Gibt an, ob die asynchrone Operation gerade ausgeführt wird
        /// </summary>
        bool IsExecuting { get; }

        ///// <summary>
        ///// Die asynchrone Operation, kann mit await abgewartet werden
        ///// </summary>
        //Task Task { get; }
    }
}
