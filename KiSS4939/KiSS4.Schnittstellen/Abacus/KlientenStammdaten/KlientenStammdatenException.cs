using System;
using System.Runtime.Serialization;

namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten
{
    /// <summary>
    /// Defines the exception that can occur when zipping data.
    /// </summary>
    public class KlientenStammdatenException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KlientenStammdatenException"/> class.
        /// </summary>
        public KlientenStammdatenException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KlientenStammdatenException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public KlientenStammdatenException(String message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KlientenStammdatenException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public KlientenStammdatenException(String message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KlientenStammdatenException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0). </exception>
        /// <exception cref="T:System.ArgumentNullException">The info parameter is null. </exception>
        private KlientenStammdatenException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion
    }
}