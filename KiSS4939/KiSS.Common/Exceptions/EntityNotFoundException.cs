using System;

namespace KiSS.Common.Exceptions
{
    /// <summary>
    /// Occures when there was no entity found where one was expected (e.g. result is null)
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class
        /// </summary>
        public EntityNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class
        /// </summary>
        /// <param name="message">The exception message</param>
        public EntityNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="inner">The inner exception</param>
        public EntityNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        #endregion
    }
}