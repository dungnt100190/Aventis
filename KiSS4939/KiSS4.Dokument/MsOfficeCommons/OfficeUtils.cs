using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using BIAG.AssemblyInfo;

using Interop.Excel;

using KiSS4.DB;
using KiSS4.Dokument.ExcelAutomation;

namespace KiSS4.Dokument.MsOfficeCommons
{
    public class OfficeUtils
    {
        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Check if the office application.Version is Office 2013 Or More
        /// </summary>
        /// <returns></returns>
        public static bool CheckIsVersionOffice2013OrMore(string version)
        {
            //versionNumber = "15.0" ist Word 2013
            //versionNumber = "14.0" ist Word 2010
            float versionNumberFloat;
            //Unkown number gives 0
            Single.TryParse(version, out versionNumberFloat);
            return (versionNumberFloat >= 15);
        }

        public static string CreateAddinWorkingCopy(string version, bool setTitleVersionString, string addinfileNameOffice2010AndBefore, string addinfileExtensionOffice2010AndBefore, string addinfileNameOffice2013, string addinfileExtensionOffice2013)
        {
            string addinfileName;
            string addinfileExt;
            string addinfileFullName;

            if (CheckIsVersionOffice2013OrMore(version))
            {
                addinfileFullName = addinfileNameOffice2013 + addinfileExtensionOffice2013;
                addinfileName = addinfileNameOffice2013;
                addinfileExt = addinfileExtensionOffice2013;
            }
            else
            {
                addinfileFullName = addinfileNameOffice2010AndBefore + addinfileExtensionOffice2010AndBefore;
                addinfileName = addinfileNameOffice2010AndBefore;
                addinfileExt = addinfileExtensionOffice2010AndBefore;
            }

            var addinPath = Path.GetDirectoryName(typeof(OfficeUtils).Assembly.Location) ?? Session.ApplicationStartupPath;

            string originalFilePath = Path.Combine(addinPath, addinfileFullName);

            var kissAppData = Session.GetKissAppDataFolder();
            var workingCopy = Path.Combine(
                kissAppData.FullName,
                string.Format("{0}_{1}{2}", addinfileName, GlobalAssemblyInfo.AssemblyVersion.Replace(".", ""), addinfileExt));

            // copy original to working copy
            try
            {
                _logger.Debug("Copy from " + originalFilePath + " to " + workingCopy);

                // create a copy of the original addin which we can modify for current build
                File.Copy(originalFilePath, workingCopy, true);

                if (setTitleVersionString)
                {
                    // Set the title including the appversion
                    // The addin is prepared for easy string replacement
                    SetTitleVersionString(workingCopy);
                }
            }
            catch (Exception ex)
            {
                _logger.Debug(ex);
            }

            return workingCopy;
        }

        /// <summary>
        /// Sets / replaces the prepared addin title of the bookmark addin.
        /// </summary>
        /// <param name="workingCopy"></param>
        public static void SetTitleVersionString(string workingCopy)
        {
            _logger.Debug("enter in SetTitleVersionString()");

            const string prefix = "KiSS Textmarken AddIn R";

            int index;
            using (var reader = new StreamReader(workingCopy, Encoding.ASCII)) //use Encoding.ASCII, so every character is 1 byte
            {
                var content = reader.ReadToEnd();
                index = content.IndexOf(prefix, StringComparison.Ordinal);
            }

            File.SetAttributes(workingCopy, FileAttributes.Normal);

            //to be sure, we only change what we want to replace, we seek to the position and binary replace the version-string
            using (Stream stream = File.Open(workingCopy, FileMode.Open))
            {
                //seek to previously found position
                stream.Position = index;

                //convert string to bytes
                var data = Encoding.ASCII.GetBytes(string.Format($"{prefix}{GlobalAssemblyInfo.AssemblyVersion.Replace(".", "")}"));

                //binary replace these bytes
                stream.Write(data, 0, data.Length);
            }
        }
    }
}