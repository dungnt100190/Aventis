
namespace Kiss.Interfaces.UI
{
    /// <summary>
    /// Definiert eine Methode um den EditMode zu setzen.
    /// </summary>
    public interface IKissEditable
    {
        /// <summary>
        /// Liest oder setzt den EditMode
        /// </summary>
        EditModeType EditMode { get; set; }
    }
}
