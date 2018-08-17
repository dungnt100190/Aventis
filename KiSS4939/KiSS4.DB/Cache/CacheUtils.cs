using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace KiSS4.DB.Cache
{
    /// <summary>
    /// Offer some util methods for managing cache objects
    /// </summary>
    public class CacheUtils
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// Lock-object for multithreading safety
        /// </summary>
        private static object _lock = new object();

        // use input string to calculate MD5 hash
        private static MD5 _md5 = System.Security.Cryptography.MD5.Create();

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Calculate MD5 hash code for given string
        /// </summary>
        /// <param name="input">The input string used for creation of MD5 hash code</param>
        /// <returns>The MD5 hash code for given input string</returns>
        /// <remarks>See: http://en.csharp-online.net/Create_a_MD5_Hash_from_a_string</remarks>
        public static string CreateMD5Hash(string input)
        {
            // allow only one thread for following section
            lock (_lock)
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = _md5.ComputeHash(inputBytes);

                // convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    // upper case letters
                    sb.Append(hashBytes[i].ToString("X2"));

                    // to force the hex string to lower-case letters instead of
                    // upper-case, use he following line instead:
                    // sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Get a specific MD5 hash code for given SqlQuery instance
        /// </summary>
        /// <param name="qry">The instance of the SqlQuery used for creating hash code</param>
        /// <returns>The MD5 hash code for given SqlQuery</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="qry"/> is empty or invalid</exception>
        public static string GetMD5Hash(SqlQuery qry)
        {
            // validate
            if (qry == null || qry.DataSet == null)
            {
                throw new ArgumentNullException("qry", "Invalid query or dataset, cannot get hash code.");
            }

            // create and return hash
            return CreateMD5Hash(string.Format("{0}##{1}##{2}##{3}##{4}##{5}##{6}##{7}",
                                               qry.CanInsert,
                                               qry.CanUpdate,
                                               qry.CanDelete,
                                               qry.BatchUpdate,
                                               qry.FillTimeOut,
                                               qry.SelectStatement,
                                               qry.DataSet.GetXmlSchema(),
                                               qry.DataSet.GetXml()));
        }

        /// <summary>
        /// Check if query has changed using hash code comparison
        /// </summary>
        /// <param name="qry">The instance of the SqlQuery used for comparison</param>
        /// <param name="oldHashCode"></param>
        /// <returns><c>True</c> if query has not changed, otherwise <c>False</c></returns>
        /// <exception cref="ArgumentNullException">Thrown if parameter are empty or invalid</exception>
        public static bool HasQueryChanged(SqlQuery qry, string oldHashCode)
        {
            // validate
            if (string.IsNullOrEmpty(oldHashCode))
            {
                throw new ArgumentNullException("oldHashCode", "Empty or invalid hash code, cannot validate query.");
            }

            // compare old and current hash code
            return (oldHashCode != GetMD5Hash(qry));
        }

        #endregion

        #endregion
    }
}