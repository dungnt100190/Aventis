using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS.KliBu.BL.Parser
{
    /// <summary>
    /// Defines a bank record exception.
    /// </summary>
    class BankRecordException : Exception
    {
        #region Fields

        /// <summary>
        /// The length from the record data
        /// </summary>
        public int Lenght;

        /// <summary>
        /// The start position from the record data
        /// </summary>
        public int StartPos;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BankRecordException"/> class.
        /// </summary>
        public BankRecordException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankRecordException"/> class.
        /// </summary>
        /// <param name="startPos">The start position</param>
        /// <param name="length">The length</param>
        /// <param name="message">The message</param>
        public BankRecordException(int startPos, int length, string message)
            : base(message)
        {
            StartPos = startPos;
            Lenght = length;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankRecordException"/> class.
        /// </summary>
        /// <param name="startPos">The start position</param>
        /// <param name="length">The length</param>
        /// <param name="message">The message</param>
        /// <param name="innerException">The inner exception</param>
        public BankRecordException(int startPos, int length, string message, Exception innerException)
            : base(message)
        {
            StartPos = startPos;
            Lenght = length;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankRecordException"/> class.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="innerException">The inner exception</param>
        public BankRecordException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankRecordException"/> class.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="innerException">The inner exception</param>
        /// <param name="innerException">The inner exception</param>
        public BankRecordException(string message, Exception innerException)
            : base(message)
        {
        }

        #endregion
    }
}