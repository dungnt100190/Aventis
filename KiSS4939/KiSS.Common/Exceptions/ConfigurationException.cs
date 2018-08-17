using System;

namespace KiSS.Common.Exceptions
{
    /// <summary>
    /// Diese Exception wird bei fehlerhafter KissKonfiguration geworfen.
    /// </summary>
    public class ConfigurationException : Exception
    {
        #region Constructors

        public ConfigurationException(string message)
            : base(message)
        {
        }

        #endregion
    }
}