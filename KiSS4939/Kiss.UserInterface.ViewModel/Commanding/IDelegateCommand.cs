using System;
using System.Windows.Input;

namespace Kiss.UserInterface.ViewModel.Commanding
{
    public interface IDelegateCommand : ICommand
    {
        /// <summary>
        /// Advises command sources to requery CanExecute()
        /// </summary>
        void RaiseCanExecuteChanged();
    }
}