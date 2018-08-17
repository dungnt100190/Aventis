using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS.DBScheme
{
    /// <summary>
    /// Baseclass for generated objects describing the column of a table.
    /// </summary>
    public class DBOColumnDef
    {
        /// <summary>
        /// Gets or sets the table this column belongs to.
        /// </summary>
        /// <value>The table.</value>
        public DBOTableDef Table { get; private set; }

        /// <summary>
        /// Gets or sets the name of this column.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the full name including the table's FullName.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName { get; private set; }

        /// <summary>
        /// Gets or sets the CLR type of this column.
        /// </summary>
        /// <value>The type.</value>
        public Type Type { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is identity col.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is identity col; otherwise, <c>false</c>.
        /// </value>
        public bool IsIdentityCol { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is foreign key.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is foreign key; otherwise, <c>false</c>.
        /// </value>
        public bool IsForeignKey { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is primary key.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is primary key; otherwise, <c>false</c>.
        /// </value>
        public bool IsPrimaryKey { get; private set; }

        /// <summary>
        /// Gets or sets the length of this column.
        /// </summary>
        /// <value>The length.</value>
        public int Length { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this column allows Null-values.
        /// </summary>
        /// <value><c>true</c> if [allow nulls]; otherwise, <c>false</c>.</value>
        public bool AllowNulls { get; private set; }

        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        /// <value>The default value.</value>
        public object DefaultValue { get; private set; }

        /// <summary>
        /// Gets or sets the namespace extension.
        /// </summary>
        /// <value>The namespace extension.</value>
        public string NamespaceExtension { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="DBOColumnDef"/> class.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <param name="isIdentityCol">if set to <c>true</c> [is identity col].</param>
        /// <param name="isForeignKey">if set to <c>true</c> [is foreign key].</param>
        /// <param name="isPrimaryKey">if set to <c>true</c> [is primary key].</param>
        /// <param name="length">The length.</param>
        /// <param name="allowNulls">if set to <c>true</c> [allow nulls].</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="namespaceExtension">The namespace extension.</param>
        public DBOColumnDef(DBOTableDef table, string name, Type type, bool isIdentityCol,
            bool isForeignKey, bool isPrimaryKey, int length, bool allowNulls,
            object defaultValue, string namespaceExtension)
        {
            this.Table = table;
            this.Name = name;
            this.FullName = string.Format("{0}.{1}", table.FullName, name);
            this.Type = type;
            this.IsIdentityCol = isIdentityCol;
            this.IsForeignKey = isForeignKey;
            this.IsPrimaryKey = isPrimaryKey;
            this.Length = length;
            this.AllowNulls = allowNulls;
            this.DefaultValue = defaultValue;
            this.NamespaceExtension = namespaceExtension;
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
