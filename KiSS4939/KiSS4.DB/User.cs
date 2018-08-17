using System;
using System.Data;
using System.Globalization;

using Kiss.Interfaces.BL;

namespace KiSS4.DB
{
    /// <summary>
    /// Represents a user in the XUser table.
    /// </summary>
    public class User : IAuthenticatedUser
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly bool _isUserAdmin;
        private readonly DataRow _row;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="row">The data row containing all required data to create a new instance.</param>
        internal User(DataRow row)
        {
            // validate
            if (row == null)
            {
                throw new ArgumentNullException("row", "The datarow is required as it contains the data to create a new instance of the User class.");
            }

            // apply row
            _row = row;

            // user members
            UserID = ConvertInt("UserID", -1);
            _isUserAdmin = ConvertBoolean("IsUserAdmin", false);
            IsUserBIAGAdmin = ConvertBoolean("IsUserBIAGAdmin", false);
            LogonName = ConvertString("LogonName", string.Empty);
            FirstName = ConvertString("FirstName", string.Empty);
            LastName = ConvertString("LastName", string.Empty);
            ShortName = ConvertString("ShortName", string.Empty);
            LanguageCode = ConvertInt("lang", 1);  // default is 1=german
            ChiefID = ConvertInt("OrgChiefID", -1);
            Phone = ConvertString("Phone", string.Empty);
            EMail = ConvertString("EMail", string.Empty);
            RechtsdienstUserID = ConvertInt("RechtsdienstUserID", -1);
            OrgUnitID = _row["OrgUnitID"] as int?;
            OrgUnitIDParent = _row["OrgUnitID_Parent"] as int?;

            // try to get modul id
            try
            {
                ModulID = ConvertInt("ModulID", 0);
            }
            catch
            {
                ModulID = 0;
            }

            // try to get Windows domain and logon name
            try
            {
                WinDomainLogonName = string.Format(@"{0}\{1}", Environment.UserDomainName, Environment.UserName);
            }
            catch
            {
                WinDomainLogonName = string.Empty;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the ChefID of the user.
        /// </summary>
        public int ChiefID
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a Creator/Modifier string.
        /// </summary>
        public string CreatorModifier
        {
            get { return DBUtil.GetDBRowCreatorModifier(); }
        }

        /// <summary>
        /// Gets and set the current culture of the user
        /// </summary>
        public CultureInfo CurrentCulture
        {
            get;
            set;
        }

        /// <summary>
        /// Get the email address of the user
        /// </summary>
        public string EMail
        {
            get;
            private set;
        }

        /// <summary>
        /// Get the firstname of the user
        /// </summary>
        public string FirstName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether this user is an administrator of KiSS.
        /// </summary>
        public bool IsUserAdmin
        {
            get
            {
                // user is admin if: admin or biag-admin (even more admin than normal admin)
                return _isUserAdmin || IsUserBIAGAdmin;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this user is a BIAG super administrator of KiSS (even more admin than normal admin).
        /// </summary>
        public bool IsUserBIAGAdmin
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether this user is a KA user.
        /// </summary>
        public bool IsUserKA
        {
            get { return ModulID == 7; }
        }

        /// <summary>
        /// Gets and set the current language code of the user
        /// </summary>
        public int LanguageCode
        {
            get;
            set;
        }

        public string LastFirstName
        {
            get
            {
                if (string.IsNullOrEmpty(FirstName))
                {
                    return LastName;
                }

                return string.Format("{0}, {1}", LastName, FirstName);
            }
        }

        /// <summary>
        /// Gets the lastname of the user.
        /// </summary>
        public string LastName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the logon name of the user.
        /// </summary>
        public string LogonName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the current modul id of the user.
        /// </summary>
        public int ModulID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the OrgUnitID of the user.
        /// </summary>
        public int? OrgUnitID
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the OrgUnitID_Parent of the user.
        /// </summary>
        public int? OrgUnitIDParent
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the phone number of the user.
        /// </summary>
        public string Phone
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the RechtsdienstUserID of the user.
        /// </summary>
        public int RechtsdienstUserID
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the short name of the user.
        /// </summary>
        public string ShortName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the database ID of the user.
        /// </summary>
        public int UserID
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the Windows logon name of the user.
        /// </summary>
        public string WinDomainLogonName
        {
            get;
            private set;
        }

        #endregion

        #region Indexers

        /// <summary>
        /// XUser Record of the current User
        /// </summary>
        /// <param name="columnName">The name of the column to get data for.</param>
        /// <returns>An object that contains the data.</returns>
        public object this[string columnName]
        {
            get { return _row[columnName]; }
        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// Converts a value in the current datarow to boolean.
        /// </summary>
        /// <param name="columnName">The name of the column to get the value from.</param>
        /// <param name="defaultValue">The default value if the value in the row is empty.</param>
        /// <returns>If set returns the value in current datarow, otherwise the default value.</returns>
        private bool ConvertBoolean(string columnName, bool defaultValue)
        {
            // check if value is not empty
            if (DBUtil.IsEmpty(_row[columnName]))
            {
                // empty value, return default
                return defaultValue;
            }

            // return current value
            return Convert.ToBoolean(_row[columnName]);
        }

        /// <summary>
        /// Converts a value in current datarow to Int32.
        /// </summary>
        /// <param name="columnName">The name of the column to get the value from.</param>
        /// <param name="defaultValue">The default value if the value in the row is empty.</param>
        /// <returns>If set returns the value in current datarow, otherwise the default value</returns>
        private int ConvertInt(string columnName, int defaultValue)
        {
            // check if value is not empty
            if (DBUtil.IsEmpty(_row[columnName]))
            {
                // empty value, return default
                return defaultValue;
            }

            // return current value
            return Convert.ToInt32(_row[columnName]);
        }

        /// <summary>
        /// Convert value in current datarow to string
        /// </summary>
        /// <param name="columnName">The name of the column to get value from</param>
        /// <param name="defaultValue">The default value if value in row is empty</param>
        /// <returns>If set returns the value in current datarow, otherwise the default value</returns>
        private string ConvertString(string columnName, string defaultValue)
        {
            // check if value is not empty
            if (DBUtil.IsEmpty(_row[columnName]))
            {
                // empty value, return default
                return defaultValue;
            }

            // return current value
            return Convert.ToString(_row[columnName]);
        }

        #endregion

        #endregion
    }
}