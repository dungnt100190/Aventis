using System.Collections.Specialized;

namespace Kiss.Interfaces.UI
{
    /// <summary>
    /// 
    /// </summary>
    public interface IViewMessaging
    {
        #region Methods

        /// <summary>
        /// Handle messages from ViewMessaging
        /// </summary>
        /// <param name="parameters">Specific messages as key/value pair for current form</param>
        /// <returns>True, if successfully handles message call, else false</returns>
        bool ReceiveMessage(HybridDictionary parameters);

        /// <summary>
        /// Handle messages from ViewMessaging
        /// </summary>
        /// <param name="parameters">Specific messages as key/value pair for current form</param>
        /// <returns>Specified object that has to be returned to sender</returns>
        object ReturnMessage(HybridDictionary parameters);

        #endregion
    }
}
