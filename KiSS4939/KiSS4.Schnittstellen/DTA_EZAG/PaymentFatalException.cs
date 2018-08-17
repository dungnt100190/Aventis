using System;
using System.Runtime.Serialization;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Throw this Exception in Zahlungslauf to abort and to display a message
    /// at the end.
    /// </summary>
    [Serializable]
    public sealed class PaymentFatalException
        : Exception
    {
        private readonly Int32 _belegNummer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentFatalException"/> class.
        /// </summary>
        public PaymentFatalException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentFatalException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public PaymentFatalException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentFatalException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="belegNummer">Die belegnummer des fehlerhaften Belegs.</param>
        public PaymentFatalException(string message, Int32 belegNummer)
            : base(message)
        {
            _belegNummer = belegNummer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentFatalException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public PaymentFatalException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentFatalException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        /// <param name="belegNummer">The beleg nummer.</param>
        public PaymentFatalException(string message, Exception inner, Int32 belegNummer)
            : base(message, inner)
        {
            _belegNummer = belegNummer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentFatalException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0). </exception>
        /// <exception cref="T:System.ArgumentNullException">The info parameter is null. </exception>
        private PaymentFatalException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Falls ungleich 0 ist dies die Nummer des fehlerhaften Belegs.
        /// </summary>
        public Int32 BelegNummer
        {
            get { return _belegNummer; }
        }
    }
}