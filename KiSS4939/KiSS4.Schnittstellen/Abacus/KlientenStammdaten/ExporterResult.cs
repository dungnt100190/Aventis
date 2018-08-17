using System;

namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten
{
    public class ExporterResult
    {
        #region Fields

        private Exception exportException;
        private String exportMessage;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, set successfull message to instance
        /// </summary>
        /// <param name="successMessage">The message that means a successfull result</param>
        public ExporterResult(String successMessage)
        {
            // validate parameters
            if (successMessage == null)
            {
                throw new ArgumentNullException("successMessage", "The message for the success cannot be empty.");
            }

            // apply fields
            this.exportMessage = successMessage;
        }

        /// <summary>
        /// Constructor, set failure message to instance
        /// </summary>
        /// <param name="failureMessage">The message that means a failed result</param>
        /// <param name="failureException">The exception that occured on failure</param>
        public ExporterResult(String failureMessage, Exception failureException)
        {
            // validate parameters
            if (failureMessage == null)
            {
                throw new ArgumentNullException("failureMessage", "The message for the failure cannot be empty.");
            }
            if (failureException == null)
            {
                throw new ArgumentNullException("failureException", "The exception for the failure cannot be empty.");
            }

            // apply fields
            this.exportMessage = failureMessage;
            this.exportException = failureException;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Get the exception that occured on export (non-clients-exceptions)
        /// </summary>
        public Exception ExportException
        {
            get { return this.exportException; }
        }

        /// <summary>
        /// Get the message text of the ExporterResult
        /// </summary>
        public String ExportMessage
        {
            get { return this.exportMessage; }
        }

        /// <summary>
        /// Get the flag if export failed or finished successfully
        /// </summary>
        public Boolean IsExportFailed
        {
            get
            {
                // if exception == null, not failed, else failed
                return !(this.exportException == null);
            }
        }

        #endregion
    }
}