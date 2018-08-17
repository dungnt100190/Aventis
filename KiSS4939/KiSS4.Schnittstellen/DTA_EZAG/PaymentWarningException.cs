using System;
using System.Runtime.Serialization;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Represents warnings that can occur during payment execution.
    /// </summary>
    [Serializable]
    public sealed class PaymentWarningException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentWarningException"/> class.
        /// </summary>
        public PaymentWarningException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentWarningException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public PaymentWarningException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentWarningException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public PaymentWarningException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentWarningException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0). </exception>
        /// <exception cref="T:System.ArgumentNullException">The info parameter is null. </exception>
        private PaymentWarningException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion
    }
}