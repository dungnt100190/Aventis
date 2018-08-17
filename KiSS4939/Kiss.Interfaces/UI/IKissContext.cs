namespace Kiss.Interfaces.UI
{
    /// <summary>
    /// Interface for Printing and Contextvalue resolve
    /// </summary>
    public interface IKissContext
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetContextName();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        object GetContextValue(string fieldName);

        /// <summary>
        /// 
        /// </summary>
        void PrintReport();

        #endregion
    }
}