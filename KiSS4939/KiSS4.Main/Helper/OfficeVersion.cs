using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace KiSS4.Main.Helper
{
    /// <summary>
    /// Class to retrieve version of installed office products
    /// </summary>
    internal class OfficeVersion
    {
        #region Enumerations

        /// <summary>
        /// Each office product has its value
        /// </summary>
        public enum OfficeComponent
        {
            Word,
            Excel,
            PowerPoint,
            Outlook
        }

        #endregion

        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The main registry key to the office files
        /// </summary>
        private static string RegKey = @"Software\Microsoft\Windows\CurrentVersion\App Paths";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, used to create a new instance of <see cref="OfficeVersion"/>.
        /// Not for public usage.
        /// </summary>
        private OfficeVersion()
        {
            // nothing to do
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the version information of Microsoft Office Excel
        /// </summary>
        public static string ExcelVersion
        {
            get
            {
                // get version information
                string excelVersion = OfficeVersion.GetProductVersion(OfficeVersion.GetComponentPath(OfficeComponent.Excel));

                // validate
                if (string.IsNullOrEmpty(excelVersion))
                {
                    // no excel or error occured on retrieving
                    return "-";
                }
                else
                {
                    // return version found
                    return excelVersion;
                }
            }
        }

        /// <summary>
        /// Get the version information of Microsoft Office Outlook
        /// </summary>
        public static string OutlookVersion
        {
            get
            {
                // get version information
                string outlookVersion = OfficeVersion.GetProductVersion(OfficeVersion.GetComponentPath(OfficeComponent.Outlook));

                // validate
                if (string.IsNullOrEmpty(outlookVersion))
                {
                    // no excel or error occured on retrieving
                    return "-";
                }
                else
                {
                    // return version found
                    return outlookVersion;
                }
            }
        }

        /// <summary>
        /// Get the version information of Microsoft Office PowerPoint
        /// </summary>
        public static string PowerPointVersion
        {
            get
            {
                // get version information
                string powerPointVersion = OfficeVersion.GetProductVersion(OfficeVersion.GetComponentPath(OfficeComponent.PowerPoint));

                // validate
                if (string.IsNullOrEmpty(powerPointVersion))
                {
                    // no excel or error occured on retrieving
                    return "-";
                }
                else
                {
                    // return version found
                    return powerPointVersion;
                }
            }
        }

        /// <summary>
        /// Get the version information of Microsoft Office Word
        /// </summary>
        public static string WordVersion
        {
            get
            {
                // get version information
                string wordVersion = OfficeVersion.GetProductVersion(OfficeVersion.GetComponentPath(OfficeComponent.Word));

                // validate
                if (string.IsNullOrEmpty(wordVersion))
                {
                    // no word or error occured on retrieving
                    return "-";
                }
                else
                {
                    // return version found
                    return wordVersion;
                }
            }
        }

        #endregion

        #region Methods

        #region Private Static Methods

        /// <summary>
        /// Gets the component's path from the registry. If it can't find it - retuns an empty string
        /// </summary>
        /// <param name="component">The office component <see cref="OfficeComponent"/> to get path to</param>
        /// <returns>Registry key to get path from for searched office component</returns>
        private static string GetComponentPath(OfficeComponent component)
        {
            // init vars
            String returnValue = string.Empty;
            String regKey = string.Empty;

            // set subkey depending on product
            switch (component)
            {
                case OfficeComponent.Word:
                    regKey = "winword.exe";
                    break;

                case OfficeComponent.Excel:
                    regKey = "excel.exe";
                    break;

                case OfficeComponent.PowerPoint:
                    regKey = "powerpnt.exe";
                    break;

                case OfficeComponent.Outlook:
                    regKey = "outlook.exe";
                    break;

                default:
                    regKey = "----";
                    break;
            }

            // looks inside CURRENT_USER:
            RegistryKey mainKey = Registry.CurrentUser;

            try
            {
                mainKey = mainKey.OpenSubKey(RegKey + "\\" + regKey, false);

                if (mainKey != null)
                {
                    returnValue = mainKey.GetValue(string.Empty).ToString();
                }
            }
            catch { }

            // if not found, looks inside LOCAL_MACHINE:
            mainKey = Registry.LocalMachine;

            if (string.IsNullOrEmpty(returnValue))
            {
                try
                {
                    mainKey = mainKey.OpenSubKey(RegKey + "\\" + regKey, false);

                    if (mainKey != null)
                    {
                        returnValue = mainKey.GetValue(string.Empty).ToString();
                    }
                }
                catch { }
            }

            // closing the handle:
            if (mainKey != null)
            {
                mainKey.Close();
            }

            // return value (if any found)
            return returnValue;
        }

        /// <summary>
        /// Gets the file version of the office component exe file or String.Empty if no file found or exception occured
        /// </summary>
        private static string GetProductVersion(string filePath)
        {
            // init var
            string versionInfo = string.Empty;

            // if file exists, try to get version information
            if (File.Exists(filePath))
            {
                try
                {
                    // get file-version
                    versionInfo = FileVersionInfo.GetVersionInfo(filePath).FileVersion;
                }
                catch { }
            }

            // return value (if any found)
            return versionInfo;
        }

        #endregion

        #endregion
    }
}