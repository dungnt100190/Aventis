using System;
using System.IO;
using System.Reflection;

namespace KiSS4.Main.Helper
{
    /// <summary>
    /// Class for available assemblies, used for about-information
    /// </summary>
    internal class AvailableAssembly
    {
        #region Fields

        #region Private Fields

        /// <summary>
        /// Store the company name of the producer of the module
        /// </summary>
        private string _companyName = string.Empty;

        /// <summary>
        /// Stroe the build date of the assembly, calculated from version
        /// </summary>
        private DateTime _dateBuilded = DateTime.MinValue;

        /// <summary>
        /// Store the date where the file of the assembly was created
        /// </summary>
        private DateTime _dateCreated = DateTime.MinValue;

        /// <summary>
        /// Store the date where the file of the assembly was modified
        /// </summary>
        private DateTime _dateModified = DateTime.MinValue;

        /// <summary>
        /// Store the description of the module
        /// </summary>
        private string _description = string.Empty;

        /// <summary>
        /// Store the location to the assembly
        /// </summary>
        private string _location = string.Empty;

        /// <summary>
        /// Store the name of the assembly
        /// </summary>
        private string _name = string.Empty;

        /// <summary>
        /// Store the ImageRuntimeVersion of the assembly
        /// </summary>
        private string _runtimeVersion = string.Empty;

        /// <summary>
        /// Store the version of the assembly
        /// </summary>
        private System.Version _version = null;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, used to create a new instance of <see cref="AvailableAssembly"/>
        /// </summary>
        /// <param name="fileInfo">The file information of the assembly to read information from</param>
        public AvailableAssembly(FileInfo fileInfo)
        {
            // validate
            if (fileInfo == null || String.IsNullOrEmpty(fileInfo.FullName))
            {
                // error, do not continue
                throw new ArgumentNullException("fileInfo", "Invalid file information, cannot load assembly data.");
            }

            try
            {
                // try to get information from given file
                Assembly asm = Assembly.LoadFrom(fileInfo.FullName);

                // apply fields
                this._name = asm.GetName().Name;
                this._version = asm.GetName().Version;

                try
                {
                    this._companyName = ((AssemblyCompanyAttribute)AssemblyCompanyAttribute.GetCustomAttribute(asm, typeof(AssemblyCompanyAttribute))).Company;
                }
                catch { }

                try
                {
                    this._description = ((AssemblyDescriptionAttribute)AssemblyDescriptionAttribute.GetCustomAttribute(asm, typeof(AssemblyDescriptionAttribute))).Description;
                }
                catch { }

                this._runtimeVersion = asm.ImageRuntimeVersion;
                this._dateCreated = fileInfo.CreationTime;
                this._dateModified = fileInfo.LastWriteTime;
                this._dateBuilded = this.BuildDateTime(this._version);
                this._location = asm.Location;
            }
            catch (BadImageFormatException ex)
            {
                // assembly is not .NET
                throw new BadImageFormatException(String.Format("'{0}' is not a valid .NET assembly.", fileInfo.FullName), ex);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the company name of the assembly
        /// </summary>
        public string CompanyName
        {
            get { return this._companyName; }
        }

        /// <summary>
        /// Get the possible build date of the assembly
        /// </summary>
        public string DateBuilded
        {
            get
            {
                // check if we have a valid date
                if (this._dateBuilded.Equals(new DateTime(2000, 1, 1)))
                {
                    // default date, no valid value
                    return String.Empty;
                }

                // valid date, return date or date with time
                if (this._dateBuilded.Equals(this._dateBuilded.Date))
                {
                    // we only have a date, return date without time information
                    return this._dateBuilded.Date.ToString();
                }

                // return date with time
                return this._dateBuilded.ToString();
            }
        }

        /// <summary>
        /// Get the date where the assembly file was created
        /// </summary>
        public DateTime DateCreated
        {
            get { return this._dateCreated; }
        }

        /// <summary>
        /// Get the date where the assembly file was modified
        /// </summary>
        public DateTime DateModified
        {
            get { return this._dateModified; }
        }

        /// <summary>
        /// Get the description of the assembly
        /// </summary>
        public string Description
        {
            get { return this._description; }
        }

        /// <summary>
        /// Get the location of the assembly
        /// </summary>
        public string Location
        {
            get { return this._location; }
        }

        /// <summary>
        /// Get the name of the assembly
        /// </summary>
        public string Name
        {
            get { return this._name; }
        }

        /// <summary>
        /// Get the runtime version of the assembly
        /// </summary>
        public string RuntimeVersion
        {
            get { return this._runtimeVersion; }
        }

        /// <summary>
        /// Get the version of the assembly
        /// </summary>
        public System.Version Version
        {
            get { return this._version; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Returns a System.String that represents an available assembly instance
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // create own ToString with given properties
            return string.Format("Name='{0}'; Version='{1}'; CompanyName='{2}'; Description='{3}'; RuntimeVersion='{4}'; DateCreated='{5}'; DateModified='{6}'; DateBuilded='{7}'; Location='{8}'",
                                  this.Name, this.Version, this.CompanyName, this.Description, this.RuntimeVersion, this.DateCreated, this.DateModified, this.DateBuilded, this.Location);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns build date/time, assuming Version was specified as AssemblyVersion("1.0.*")
        /// (or any other major.minor) 
        /// </summary>
        /// <param name="version">A Version instance, with build date/time info in build.revision fields</param> 
        /// <remarks>Date/time does not honor daylight savings time</remarks>
        private DateTime BuildDateTime(System.Version version)
        {
            // create date from version
            DateTime dateTime = new DateTime(2000, 1, 1).AddDays(version.Build).AddSeconds(version.Revision * 2);

            // do some daylight saving time handling
            if (TimeZone.IsDaylightSavingTime(dateTime, TimeZone.CurrentTimeZone.GetDaylightChanges(dateTime.Year)))
            {
                dateTime = dateTime.AddHours(1);
            }

            // return date
            return dateTime;
        }

        #endregion

        #endregion
    }
}