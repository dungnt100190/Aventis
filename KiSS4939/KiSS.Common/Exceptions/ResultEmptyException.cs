using System;

namespace KiSS.Common.Exceptions
{
    /// <summary>
    /// Occures when a result has an instance but is not expected to be empty (e.g. no entities in result list)
    /// </summary>
    public class ResultEmptyException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultEmptyException"/> class
        /// </summary>
        public ResultEmptyException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultEmptyException"/> class
        /// </summary>
        /// <param name="message">The exception message</param>
        public ResultEmptyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultEmptyException"/> class
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="inner">The inner exception</param>
        public ResultEmptyException(string message, Exception inner)
            : base(message, inner)
        {
        }

        #endregion
    }
}