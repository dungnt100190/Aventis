using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Kiss.UserInterface.ViewModel.Async
{
    public class TaskObserver : INotifyPropertyChanged
    {
        readonly List<Task> _observedTasks = new List<Task>();
        public void AddObservation(Task taskToObserve)
        {
            _observedTasks.Add(taskToObserve);
            Observe(taskToObserve);
        }

        private async void Observe(Task taskToObserve)
        {
            try
            {
                Waiting = _observedTasks.Any(tsk => !tsk.IsCompleted);
                await taskToObserve;
            }
            finally
            {
                _observedTasks.Remove(taskToObserve);
            }
            Waiting = _observedTasks.Any(tsk => !tsk.IsCompleted);
        }

        private bool _waiting;

        /// <summary>
        /// true, falls mindestens ein überwachter Task noch nicht beendet ist
        /// </summary>
        public bool Waiting
        {
            get { return _waiting; }
            private set
            {
                // ToDo: Helper von Lucas verwenden
                if (_waiting == value)
                {
                    return;
                }
                _waiting = value;
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs("Waiting"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
