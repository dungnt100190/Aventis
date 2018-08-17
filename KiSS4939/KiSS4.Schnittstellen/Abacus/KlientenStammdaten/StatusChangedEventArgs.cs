using System;

namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten
{
    public class StatusChangedEventArgs : EventArgs
    {
        #region Enumerations

        public enum StatusMessageEvents
        {
            GeneralExport = 0,
            AddressExport = 1,
            AccountExport = 2
        }

        #endregion

        #region Fields

        private Boolean isFromAsyncCall = false;
        private String statusMessage;
        private StatusMessageEvents statusMessageEvent;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, set status message to send
        /// </summary>
        /// <param name="newStatusMessage">The message that has to be sent with EventHandler</param>
        /// <param name="newStatusMessageEvent">The event where the message occured</param>
        /// <param name="newIsFromAsyncCall">Flag if the event is called from other thread than UI thread</param>
        public StatusChangedEventArgs(String newStatusMessage, StatusMessageEvents newStatusMessageEvent, Boolean newIsFromAsyncCall)
        {
            // validate parameters
            if (newStatusMessage == null)
            {
                throw new ArgumentNullException("newStatusMessage", "The message for the new status cannot be empty.");
            }

            // apply fields
            this.statusMessage = newStatusMessage;
            this.statusMessageEvent = newStatusMessageEvent;
            this.isFromAsyncCall = newIsFromAsyncCall;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Get the flag if the event is called from other thread than UI thread
        /// </summary>
        public Boolean IsFromAsyncCall
        {
            get { return this.isFromAsyncCall; }
        }

        /// <summary>
        /// Get the status message from the event arguments
        /// </summary>
        public String StatusMessage
        {
            get { return this.statusMessage; }
        }

        /// <summary>
        /// Get the event where the message of the event arguments occured
        /// </summary>
        public StatusMessageEvents StatusMessageEvent
        {
            get { return this.statusMessageEvent; }
        }

        #endregion
    }
}