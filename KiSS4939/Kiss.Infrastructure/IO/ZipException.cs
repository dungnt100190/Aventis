using System;

namespace Kiss.Infrastructure.IO
{
    /// <summary>
    /// Defines a zip exception.
    /// </summary>
    public class ZipException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZipException"/> class.
        /// </summary>
        public ZipException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipException"/> class.
        /// </summary>
        /// <param name="message">The message</param>
        public ZipException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipException"/> class.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="innerException">The inner exception</param>
        public ZipException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}