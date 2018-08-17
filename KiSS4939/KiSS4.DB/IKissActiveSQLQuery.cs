using System.Windows.Forms;

namespace KiSS4.DB
{
    /// <summary>
    /// Summary description for IKissActiveSQLQuery.
    /// </summary>
    public interface IKissActiveSQLQuery
    {
        /// <summary>
        /// Gets the active control on the container control.
        /// </summary>
        Control ActiveControl { get; }

        /// <summary>
        /// Gets the active SQL query.
        /// </summary>
        /// <value>The active SQL query.</value>
        SqlQuery ActiveSQLQuery { get; }

        /// <summary>
        /// Current <see cref="IKissUserControl" />
        /// </summary>
        IKissUserControl DetailControl { get; }

        /// <summary>
        /// Gets the name of the control.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the parent container of the control.
        /// </summary>
        Control Parent { get; }
    }
}