using System;

namespace Kiss.Infrastructure.IO
{
    /// <summary>
    /// Defines a web request exception.
    /// </summary>
    public class WebRequestException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebRequestException"/> class.
        /// </summary>
        public WebRequestException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebRequestException"/> class.
        /// </summary>
        /// <param name="message">The message</param>
        public WebRequestException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebRequestException"/> class.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="innerException">The inner exception</param>
        public WebRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}