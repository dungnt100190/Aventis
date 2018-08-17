using System;

namespace Kiss.Update
{
    #region Delegates

    public delegate void ProcessCompletedEventHandler(object sender, ProcessCompletedEventArgs e);

    #endregion

    public class ProcessCompletedEventArgs : EventArgs
    {
        #region Constructors

        public ProcessCompletedEventArgs(Exception error, bool wasCanceled)
        {
            Error = error;
            WasCanceled = wasCanceled;
        }

        #endregion

        #region Properties

        public Exception Error
        {
            get;
            private set;
        }

        public bool WasCanceled
        {
            get;
            private set;
        }

        #endregion
    }
}