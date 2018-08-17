using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

using log4net;

using Microsoft.Win32;

using Kiss.Interfaces.DocumentHandling;

namespace KiSS4.Dokument.Utilities
{
    public static class RegistryUtilities
    {
        #region Fields

        #region Private Static Fields

        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly Regex _rxLocation = new Regex(@"^Location(\d+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        #endregion

        #region Private Constant/Read-Only Fields

        private const string ALLOW_SUB_FOLDERS_NAME = "AllowSubFolders";
        private const string DESCRIPTION_NAME = "Description";
        private const string DESCRIPTION_VALUE = "KiSS Temp Folder";
        private const string PATH_NAME = "Path";

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        public static void AddTrustedLocation(DokFormat format, string location)
        {
            try
            {
                var officeKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Office\12.0");

                // if office 2010 is not installed we do not need to continue
                if (officeKey == null)
                {
                    return;
                }

                var subKeyFormat = @"{0}\Security\Trusted Locations";

                RegistryKey trustedLocations = null;

                if (format == DokFormat.Word)
                {
                    trustedLocations = officeKey.OpenSubKey(string.Format(subKeyFormat, "Word"),
                                                            RegistryKeyPermissionCheck.ReadWriteSubTree);
                }
                else if (format == DokFormat.Excel)
                {
                    trustedLocations = officeKey.OpenSubKey(string.Format(subKeyFormat, "Excel"),
                                                            RegistryKeyPermissionCheck.ReadWriteSubTree);
                }

                if (trustedLocations != null)
                {
                    if (CheckIfAlreadyInstalled(trustedLocations))
                    {
                        return;
                    }

                    // get the previous subkey ("Location<X>")
                    var list = new List<string>(trustedLocations.GetSubKeyNames());
                    list.Sort();

                    var previous = list.LastOrDefault(key => _rxLocation.IsMatch(key));

                    if (previous != null)
                    {
                        var match = _rxLocation.Match(previous);
                        int num;

                        // the regex has two groups, the first is the whole match, the second is the number
                        if (int.TryParse(match.Groups[1].Value, out num))
                        {
                            var newLocation = "Location" + (num + 1);

                            // create the new trusted location and its values
                            var newLocationKey = trustedLocations.CreateSubKey(newLocation, RegistryKeyPermissionCheck.ReadWriteSubTree);

                            if (newLocationKey != null)
                            {
                                newLocationKey.SetValue(ALLOW_SUB_FOLDERS_NAME, 1, RegistryValueKind.DWord);
                                newLocationKey.SetValue(DESCRIPTION_NAME, DESCRIPTION_VALUE, RegistryValueKind.String);
                                newLocationKey.SetValue(PATH_NAME, location, RegistryValueKind.String);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Checks if the temp location for KiSS has already been installed.
        /// </summary>
        /// <param name="trustedLocations"></param>
        /// <returns></returns>
        private static bool CheckIfAlreadyInstalled(RegistryKey trustedLocations)
        {
            try
            {
                var query = from subKeyName in trustedLocations.GetSubKeyNames()
                            select trustedLocations.OpenSubKey(subKeyName, RegistryKeyPermissionCheck.ReadSubTree)
                                into subKey
                                where subKey != null
                                select subKey.GetValue(DESCRIPTION_NAME) as string;

                if (query.Any(description => description == DESCRIPTION_VALUE))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                _log.Warn(ex);

                // Bei einer Exception soll nicht weiter gefahren werden..
                return true;
            }

            return false;
        }

        #endregion

        #endregion
    }
}