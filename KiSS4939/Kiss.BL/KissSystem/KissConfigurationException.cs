using System;

namespace Kiss.BL.KissSystem
{
    /// <summary>
    /// Exception in case KiSS is wrongly configured.
    /// </summary>
    public class KissConfigurationException : Exception
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public KissConfigurationException()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="key">The configuration key that has a problem.</param>
        public KissConfigurationException(string key)
        {
            Key = key;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="key">The configuration key that has a problem.</param>
        /// <param name="message">Message</param>
        public KissConfigurationException(string key, string message)
            : base(message)
        {
            Key = key;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Configuration key that is wrong.
        /// </summary>
        public string Key { get; set; }

        #endregion
    }
}