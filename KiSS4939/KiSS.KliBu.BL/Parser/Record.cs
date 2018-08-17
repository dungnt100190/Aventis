using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS.KliBu.BL.Parser
{
    /// <summary>
    /// Class containins the <see cref="StartPosition"/> and the <see cref="Length"/> of a record
    /// </summary>
    internal class Record
    {
        #region Fields

        private int _length;
        private int _startPosition;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Record"/> class
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="length"></param>
        public Record(int startPosition, int length)
        {
            _startPosition = startPosition;
            _length = length;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the Length of a <see cref="Record"/>
        /// </summary>
        public int Length
        {
            get { return _length; }
        }

        /// <summary>
        /// Gets the start position of a <see cref="Record"/>
        /// </summary>
        public int StartPosition
        {
            get { return _startPosition; }
        }

        #endregion
    }
}