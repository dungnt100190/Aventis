using System;
using System.Diagnostics;
using System.Reflection;

namespace KiSS4.Main.Helper
{
    /// <summary>
    /// Class for available assemblies, used for about-information
    /// </summary>
    internal class LoadedModule
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// Store the company name of the producer of the module
        /// </summary>
        private readonly string _companyName = string.Empty;

        /// <summary>
        /// Store the description of the module
        /// </summary>
        private readonly string _description = string.Empty;

        /// <summary>
        /// Store the filename including path of the module
        /// </summary>
        private readonly string _fileName = string.Empty;

        /// <summary>
        /// Store the initial memory size of the module
        /// </summary>
        private readonly string _memorySize = string.Empty;

        /// <summary>
        /// Store the name of the module
        /// </summary>
        private readonly string _name = string.Empty;

        /// <summary>
        /// Store the ImageRuntimeVersion of the assembly
        /// </summary>
        private readonly string _runtimeVersion = string.Empty;

        /// <summary>
        /// Store the type of the entry (M=module, A=assembly)
        /// </summary>
        private readonly char _type;

        /// <summary>
        /// Store the version of the assembly of the module
        /// </summary>
        private readonly string _version = string.Empty;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, used to create a new instance of <see cref="LoadedModule"/>
        /// </summary>
        /// <param name="module">The current process module</param>
        public LoadedModule(ProcessModule module)
        {
            // validate
            if (module == null)
            {
                // error, do not continue
                throw new ArgumentNullException("module", "Invalid module information, cannot get module data.");
            }

            // try to get assembly version
            try
            {
                // HACK: load assembly (anyone a better idea to get real assembly access??)
                Assembly asm = Assembly.LoadFile(module.FileName);

                _version = asm.GetName().Version.ToString();
                _runtimeVersion = asm.ImageRuntimeVersion;
            }
            catch
            {
                _version = module.FileVersionInfo.FileVersion;
                _runtimeVersion = String.Empty;
            }

            // apply other fields
            _type = 'M'; // module
            _name = module.ModuleName;
            _companyName = module.FileVersionInfo.CompanyName;
            _description = module.FileVersionInfo.FileDescription;
            _memorySize = DlgAbout.ConvertLongToByteInfo(module.ModuleMemorySize);
            _fileName = module.FileName;
        }

        /// <summary>
        /// Constructor, used to create a new instance of <see cref="LoadedModule"/>
        /// </summary>
        /// <param name="asm">The current assembly</param>
        public LoadedModule(Assembly asm)
        {
            // validate
            if (asm == null || string.IsNullOrEmpty(asm.FullName))
            {
                // error, do not continue
                throw new ArgumentNullException("asm", "Invalid assembly information, cannot get assembly data.");
            }

            // apply other fields
            _type = 'A'; // assembly
            _name = asm.GetName().Name;
            _version = asm.GetName().Version.ToString();

            try
            {
                _companyName = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyCompanyAttribute))).Company;
            }
            catch (Exception ex)
            {
                _logger.Debug("Error getting asm.Company", ex);
            }

            try
            {
                _description = ((AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyDescriptionAttribute))).Description;
            }
            catch (Exception ex)
            {
                _logger.Debug("Error getting asm.Description", ex);
            }

            _runtimeVersion = asm.ImageRuntimeVersion;
            _memorySize = "";
            _fileName = asm.IsDynamic ? "(dynamic)" : asm.Location;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the company name of the module
        /// </summary>
        public string CompanyName
        {
            get { return _companyName; }
        }

        /// <summary>
        /// Get the description of the module
        /// </summary>
        public string Description
        {
            get { return _description; }
        }

        /// <summary>
        /// Get the file name including path of the module
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
        }

        /// <summary>
        /// Get the initial memory size of the module
        /// </summary>
        public string MemorySize
        {
            get { return _memorySize; }
        }

        /// <summary>
        /// Get the name of the module
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Get the runtime version of the assembly
        /// </summary>
        public string RuntimeVersion
        {
            get { return _runtimeVersion; }
        }

        /// <summary>
        /// Get the type of this instance
        /// M=Module, A=Assembly
        /// </summary>
        public char Type
        {
            get { return _type; }
        }

        /// <summary>
        /// Get the version of the module
        /// </summary>
        public string Version
        {
            get { return _version; }
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
            return string.Format("Name='{0}'; Type='{1}'; Version='{2}'; CompanyName='{3}'; Description='{4}'; RuntimeVersion='{5}'; MemorySize='{6}'; FileName='{7}'",
                                 Name, Type, Version, CompanyName, Description, RuntimeVersion, MemorySize, FileName);
        }

        #endregion

        #endregion
    }
}