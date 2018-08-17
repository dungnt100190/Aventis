namespace KiSS4.Main
{
    /// <summary>
    /// This utility class contains functions to configure the Log4Net logging
    /// environment.
    /// </summary>
    internal class LogConfigurator
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Initialize the log4net logger.
        /// </summary>
        public static void Init()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        #endregion

        #endregion
    }
}