using System;
using System.Diagnostics;
using System.IO;

using Microsoft.Win32;

namespace Kiss.BL.Ba.Helper
{
    /// <summary>
    /// Class to retrieve version of installed office products
    /// </summary>
    class OfficeVersionHelper
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

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// The main registry key to the office files
        /// </summary>
        private const string REG_KEY = @"Software\Microsoft\Windows\CurrentVersion\App Paths";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, used to create a new instance of <see cref="OfficeVersionHelper"/>.
        /// Not for public usage.
        /// </summary>
        private OfficeVersionHelper()
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
                var excelVersion = GetProductVersion(GetComponentPath(OfficeComponent.Excel));

                // validate
                return string.IsNullOrEmpty(excelVersion) ? "-" : excelVersion;
                // return version found
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
                string outlookVersion = GetProductVersion(GetComponentPath(OfficeComponent.Outlook));

                // validate
                if (string.IsNullOrEmpty(outlookVersion))
                {
                    // no excel or error occured on retrieving
                    return "-";
                }
                // return version found
                return outlookVersion;
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
                string powerPointVersion = GetProductVersion(GetComponentPath(OfficeComponent.PowerPoint));

                // validate
                return string.IsNullOrEmpty(powerPointVersion) ? "-" : powerPointVersion;
                // return version found
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
                var wordVersion = GetProductVersion(GetComponentPath(OfficeComponent.Word));

                // validate
                if (string.IsNullOrEmpty(wordVersion))
                {
                    // no word or error occured on retrieving
                    return "-";
                }
                // return version found
                return wordVersion;
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
            var returnValue = string.Empty;
            String regKey;

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
            var mainKey = Registry.CurrentUser;

            try
            {
                mainKey = mainKey.OpenSubKey(REG_KEY + "\\" + regKey, false);

                if (mainKey != null)
                {
                    returnValue = mainKey.GetValue(string.Empty).ToString();
                }
            }
            catch
            { }

            // if not found, looks inside LOCAL_MACHINE:
            mainKey = Registry.LocalMachine;

            if (string.IsNullOrEmpty(returnValue))
            {
                try
                {
                    mainKey = mainKey.OpenSubKey(REG_KEY + "\\" + regKey, false);

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
            var versionInfo = string.Empty;

            // if file exists, try to get version information
            if (File.Exists(filePath))
            {
                try
                {
                    // get file-version
                    versionInfo = FileVersionInfo.GetVersionInfo(filePath).FileVersion;
                }
                catch
                { }
            }

            // return value (if any found)
            return versionInfo;
        }

        #endregion

        #endregion
    }
}