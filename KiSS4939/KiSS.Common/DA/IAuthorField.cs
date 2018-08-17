using System;

namespace KiSS.Common.DA
{
    /// <summary>
    /// Interface conataining the properties Creator, Created, Modifier, Modified for objects that map to tables conatining these fields
    /// </summary>
    public interface IAuthorField
    {
        #region Properties

        /// <summary>
        /// Creation date
        /// </summary>
        DateTime Created
        {
            get;
            set;
        }

        /// <summary>
        /// Creator name
        /// </summary>
        string Creator
        {
            get;
            set;
        }

        /// <summary>
        /// Date of the last modification
        /// </summary>
        DateTime Modified
        {
            get;
            set;
        }

        /// <summary>
        /// Modifier name
        /// </summary>
        string Modifier
        {
            get;
            set;
        }

        #endregion
    }
}