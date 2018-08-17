using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentValidation;
using FluentValidation.Results;

namespace KiSS.Common.BL
{
    /// <summary>
    /// A class containing a List of Error Messages and Information Messages 
    /// </summary>
    public class ServiceResult
    {
        #region Fields

        #region Private Fields

        private List<ErrorItem> _errorList = new List<ErrorItem>();
        private List<string> _infoList = new List<string>();

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a <see cref="ServiceResult"/> object
        /// </summary>
        public ServiceResult()
        {
        }

        /// <summary>
        /// Initializes a <see cref="ServiceResult"/> object
        /// </summary>
        /// <param name="validationResult"><see cref="ValidationResult"/></param>
        public ServiceResult(ValidationResult validationResult)
        {
            Set(validationResult);
        }

        #endregion

        #region Properties

        /// <summary>
        /// A List containg the error <see cref="ErrorItem"/>
        /// </summary>
        public List<ErrorItem> Errors
        {
            get
            {
                return _errorList;
            }
        }

        /// <summary>
        /// A List containg the Info Messages 
        /// </summary>
        public List<string> Infos
        {
            get
            {
                return _infoList;
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

        #region Methods

        #region Public Methods

        /// <summary>
        /// Appends an error message to the <see cref="Errors"/>
        /// </summary>
        /// <param name="error">The error to add</param>
        public void AppendError(string error)
        {
            _errorList.Add(new ErrorItem() { ErrorMessage = error });
        }

        /// <summary>
        /// Sets the <see cref="ServiceResult"/> with a <see cref="ValidationResult"/> object
        /// </summary>
        /// <param name="validationResult">The <see cref="ValidationResult"/> to set</param>
        public void Set(ValidationResult validationResult)
        {
            _errorList.AddRange(
                validationResult.Errors.Select(
                e => new ErrorItem() {
                    ErrorMessage = e.ErrorMessage,
                    PropertyName = e.PropertyName
                }).ToList());
        }

        #endregion

        #endregion

        #region Nested Types

        public class ErrorItem
        {
            #region Properties

            public string ErrorMessage
            {
                get; internal set;
            }

            public string PropertyName
            {
                get; internal set;
            }

            #endregion

            #region Methods

            #region Public Methods

            public override string ToString()
            {
                return ErrorMessage;
            }

            #endregion

            #endregion
        }

        #endregion
    }
}