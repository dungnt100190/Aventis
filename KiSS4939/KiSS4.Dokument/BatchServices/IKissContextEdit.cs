using Kiss.Interfaces.UI;

namespace KiSS4.Dokument.BatchServices
{
    /// <summary>
    /// Interface for KissContextEdit
    /// </summary>
    public interface IKissContextEdit : IKissContext
    {
        #region Methods

        /// <summary>
        /// Adds the context value.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="value">The value for the specified parameter.</param>
        void AddContextValue(string parameter, string value);

        #endregion
    }
}