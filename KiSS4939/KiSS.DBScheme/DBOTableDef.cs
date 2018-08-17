using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS.DBScheme
{
    /// <summary>
    /// Baseclass for generated objects describing a table.
    /// </summary>
    public class DBOTableDef
    {
        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the full name including the DBO-prefix.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName { get; private set; }

        /// <summary>
        /// Gets or sets the default alias for this table (e.g. BUC for KbBuchung).
        /// </summary>
        /// <value>The default alias.</value>
        public string DefaultAlias { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this table is under version control.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this table is under version control; otherwise, <c>false</c>.
        /// </value>
        public bool IsUnderVersionControl { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBOTableDef"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="defaultAlias">The default alias.</param>
        public DBOTableDef(string name, string defaultAlias, bool isUnderVersionControl)
        {
            this.Name = name;
            this.FullName = string.Format("DBO.{0}", name);
            this.DefaultAlias = defaultAlias;
            this.IsUnderVersionControl = IsUnderVersionControl;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
