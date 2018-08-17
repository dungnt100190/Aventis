using System;

namespace KiSS.Common
{
    /// <summary>
    /// Defines a general application exception.
    /// </summary>
    public class AppException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AppException"/> class.
        /// </summary>
        public AppException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public AppException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public AppException(string message, Exception inner)
            : base(message, inner)
        {
        }

        #endregion

        #region Other

        /*
        /// <summary>
        /// Initializes a new instance of the <see cref="AppException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see>
        /// that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see>
        /// that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is
        /// null or <see cref="P:System.Exception.HResult"></see> is zero (0). </exception>
        /// <exception cref="T:System.ArgumentNullException">The info parameter is null. </exception>
        private AppException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
         * */

        #endregion
    }
}