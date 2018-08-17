using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kiss.UserInterface.ViewModel.Commanding
{
    /// <summary>
    /// Führt eine asynchrone Operation und kann diese abbrechen
    /// Hilfsklasse für AsyncTask; TaskExcution fasst die Ausführung und den CancellationToken zusammen
    /// </summary>
    internal class TaskExecution
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly Func<object, CancellationToken, Task> _execute;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Erstellt einen neuen Ausführungs-Wrapper um eine asynchrone Methode
        /// </summary>
        /// <param name="execute"></param>
        internal TaskExecution(Func<object, CancellationToken, Task> execute)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _execute = execute;
        }

        #endregion

        #region Properties

        /// <summary>
        /// ID des ausgeführten Tasks oder null, falls die Ausführung noch nicht gestartet wurde
        /// </summary>
        internal int? TaskID { get; private set; }

        /// <summary>
        /// Prüft, ob die Methode abgebrochen werden kann
        /// true, falls die Ausführung schon/noch läuft
        /// </summary>
        internal bool IsRunning { get; private set; }

        #endregion

        #region Methods

        #region Internal Methods

        /// <summary>
        /// Meldet der Methode, dass sie ihre Ausführung abbrechen soll
        /// </summary>
        /// <remarks>Die Methode muss den <see cref="CancellationToken"/> prüfen und selbst abbrechen. Die Ausführung würgt die Methode nicht ab</remarks>
        internal void Cancel()
        {
            _cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// Führt die Methode aus
        /// </summary>
        /// <param name="parameter">Parameter für Methode</param>
        /// <returns></returns>
        internal async Task Start(object parameter = null)
        {
            IsRunning = true;
            try
            {
                var task = _execute(parameter, _cancellationTokenSource.Token);
                if (task != null)
                {
                    TaskID = task.Id;
                    await task;
                }
            }
            finally
            {
                IsRunning = false;
                _cancellationTokenSource.Dispose();
            }
        }

        #endregion

        #endregion
    }
}