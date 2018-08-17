using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Kiss.Interfaces.ViewModel
{
    public interface IAsyncCommand : ICommand, INotifyPropertyChanged
    {
        #region Events

        event EventHandler Executed;

        #endregion

        #region Properties

        ICommand CancelCommand
        {
            get;
        }

        bool IsExecuteEnabled
        {
            get; set;
        }

        bool IsExecuting
        {
            get;
        }

        #endregion
    }
}