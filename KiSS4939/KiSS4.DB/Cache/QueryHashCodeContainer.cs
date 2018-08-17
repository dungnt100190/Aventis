using System;
using System.Text;

namespace KiSS4.DB.Cache
{
    /// <summary>
    /// Container with instance of SqlQuery and checksum string used for validation
    /// </summary>
    internal class QueryHashCodeContainer
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryHashCodeContainer"/> class.
        /// </summary>
        /// <param name="qry"></param>
        /// <param name="hashCode"></param>
        /// <exception cref="ArgumentNullException">Thrown if parameters are null or invalid</exception>
        public QueryHashCodeContainer(SqlQuery qry, string hashCode)
        {
            // validate
            if (qry == null)
            {
                throw new ArgumentNullException("qry", "Query is empty, cannot create new instance.");
            }

            if (string.IsNullOrEmpty(hashCode))
            {
                throw new ArgumentNullException("hashCode", "Invalid hash code, cannot create new instance.");
            }

            // apply members
            SqlQuery = qry;
            HashCode = hashCode;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the assigned hash code for given SqlQuery instance
        /// </summary>
        public string HashCode
        {
            private set;
            get;
        }

        /// <summary>
        /// Get the assigned SqlQuery instance
        /// </summary>
        public SqlQuery SqlQuery
        {
            private set;
            get;
        }

        #endregion
    }
}