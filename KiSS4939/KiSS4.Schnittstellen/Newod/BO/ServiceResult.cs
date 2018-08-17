using System;
using System.Collections.Generic;
using System.Text;

namespace KiSS4.Schnittstellen.Newod.BO
{
    /// <summary>
    /// Class to manage the result of an opreation
    /// </summary>
    public class ServiceResult
    {
        #region Fields

        private List<string> _errorList = new List<string>();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a <see cref="ServiceResult"/> object
        /// </summary>
        public ServiceResult()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Contains the validation errors
        /// </summary>
        public List<string> Errors
        {
            get
            {
                return _errorList;
            }
        }

        /// <summary>
        /// Indicates whether the validation has secceeded or not
        /// </summary>
        public bool Success
        {
            get { return Errors.Count == 0; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Appends an error to the <see cref="Errors"/>
        /// </summary>
        /// <param name="error">The error to add</param>
        public void AppendError(string error)
        {
            _errorList.Add(error);
        }


        #endregion
    }
}