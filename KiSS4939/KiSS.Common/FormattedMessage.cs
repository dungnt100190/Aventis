using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Common.Logging;

namespace KiSS.Common
{
    /// <summary>
    /// Class to format a message. Replaces placeholders, Syntax: {ValueToReplace}.
    /// Provides a fluent interface
    /// </summary>
    /// <remarks>part of ther implementation is taken from the FluentValidator framework</remarks>
    public class FormattedMessage
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        public const string PropertyName = "PropertyName";

        #endregion

        #region Private Static Fields

        private static readonly ILog logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Private Constant/Read-Only Fields

        readonly Dictionary<string, object> _placeholderValues = new Dictionary<string, object>();

        #endregion

        #region Private Fields

        string _msg;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constrcts a ForatatedMesaage from a string
        /// </summary>
        /// <param name="msg">the message</param>
        public FormattedMessage(string msg)
        {
            _msg = msg;
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Implicit cast to string
        /// </summary>
        /// <param name="msg">the object to cast to string</param>
        /// <returns>string value</returns>
        public static implicit operator string(FormattedMessage msg)
        {
            return msg.ToString();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Replace a placeholder with an value
        /// </summary>
        /// <param name="placeholder">placeholder key to replace</param>
        /// <param name="value">the value</param>
        /// <returns>the current instance</returns>
        public FormattedMessage Replace(string placeholder, object value)
        {
            if (string.IsNullOrEmpty(placeholder))
                throw new ArgumentException("placeholder");

            string key;
            if(placeholder.StartsWith("{") && placeholder.EndsWith("}"))
                key = placeholder.Substring(1, placeholder.Length - 2);
            else
                key = placeholder;

            _placeholderValues.Add(key, value);

            return this;    // fluent interface
        }

        /// <summary>
        /// Replace the {PropertyName} placeholder.
        /// </summary>
        /// <param name="name">the value</param>
        /// <returns>the current instance</returns>
        public FormattedMessage SetPropertyName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("name");

            _placeholderValues.Add(PropertyName, name);

            return this;    // fluent interface
        }

        /// <summary>
        /// Returns the formatted message
        /// </summary>
        /// <returns>the formatted message</returns>
        public override string ToString()
        {
            string result = _msg;
            foreach (var pair in _placeholderValues)
            {
                result = ReplacePlaceholderWithValue(result, pair.Key, pair.Value);
            }
            return result;
        }

        #endregion

        #region Private Static Methods

        private static string ReplacePlaceholderWithValue(string text, string key, object value)
        {
            string placeholder = "{" + key + "}";
            string result = text.Replace(placeholder, value == null ? null : value.ToString());
            if (text == result)
                logger.WarnFormat("Placeholder \"{0}\" not found in message \"{1}\"", key, text);

            return result;
        }

        #endregion

        #endregion
    }
}