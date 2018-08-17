
namespace KiSS4.DB
{
    /// <summary>
    /// Interface for KISS data binding
    /// </summary>
    public interface IKissBindableEdit
    {
        /// <summary>
        /// Binding SqlQuery
        /// </summary>
        SqlQuery DataSource { get; set; }

        /// <summary>
        /// Binding DataMember.
        /// </summary>
        string DataMember { get; set; }

        /// <summary>
        /// Gets the name of the bindable property.
        /// </summary>
        string GetBindablePropertyName();

        /// <summary>
        /// Gets a value indicating whether editing is allowed.
        /// </summary>
        void AllowEdit(bool value);
    }
}
