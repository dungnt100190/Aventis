using System;

namespace KiSS4.Messages
{
    /// <summary>
    /// Exception is thrown when the user cancelled the action.
    /// </summary>
    public class CancelledByUserException : SystemException
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelledByUserException"/> class.
        /// </summary>
        public CancelledByUserException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelledByUserException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public CancelledByUserException(string message)
            : base(message)
        {
        }

        #endregion
    }
}