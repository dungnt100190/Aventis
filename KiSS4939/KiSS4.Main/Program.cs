using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using Kiss.Infrastructure.IO;
using Kiss.Update;
using Kiss.UserInterface.View;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Main.Properties;
using log4net;
using Microsoft.VisualBasic.ApplicationServices;

namespace KiSS4.Main
{
    internal class Program
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static bool _updateInProgress;

        #endregion

        #endregion

        #region Methods

        #region Internal Static Methods

        /// <summary>
        /// Processes the command line.
        /// </summary>
        /// <param name="args">The args.</param>
        internal static void ProcessCommandLine(string[] args)
        {
            ProcessCommandLine(new Arguments(args));
        }

        /// <summary>
        /// Processes the command line.
        /// </summary>
        /// <param name="args">The args.</param>
        internal static void ProcessCommandLine(Arguments args)
        {
            string className = null;

            if (args.HybridDictionary.Contains("form"))
            {
                className = args["form"] as string;
            }

            if (args.HybridDictionary.Contains("classname"))
            {
                className = args["classname"] as string;
            }

            if (className != null)
            {
                try
                {
                    // Convert Datatypes
                    HybridDictionary dic = args.HybridDictionary;

                    foreach (object key in dic.Keys)
                    {
                        if (dic[key] is string)
                        {
                            string val = (string)dic[key];

                            if (val == string.Empty)
                            {
                                dic[key] = null;
                            }
                            else
                            {
                                int i;
                                if (int.TryParse(val, out i))
                                {
                                    dic[key] = i;
                                }
                                else
                                {
                                    bool b;
                                    if (bool.TryParse(val, out b))
                                    {
                                        dic[key] = b;
                                    }
                                    else
                                    {
                                        DateTime d;
                                        if (DateTime.TryParse(val, out d))
                                        {
                                            dic[key] = d;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    FormController.OpenForm(className, dic);
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError("FrmMain", "OpenFormFailed", "Die Form '{0}' konnte nicht geöffnet werden", null, ex, 0, 0, className);
                }
            }
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Methode um das KiSS zu updaten.
        /// Auf dem Server :
        /// Kiss_Update.zip (Application Package : enthält alle die Files der Applikation)
        /// Kiss_Update_exe.zip (Update Package : enthält die Files für das Update)
        /// </summary>
        /// <param name="asr"></param>
        private static void CheckForUpdates(AppSettingsReader asr)
        {
            try
            {
                // Read Settings form App.config
                string updateSource = TryGetSettingsValue(asr, "UpdateSource", null);

                if (!string.IsNullOrWhiteSpace(updateSource))
                {
                    // Check if valid path
                    if (!Directory.Exists(updateSource))
                    {
                        MessageBox.Show(
                            string.Format(Resources.UpdatePfadUngueltig, updateSource),
                            Resources.Warnung,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    string updateFile = TryGetSettingsValue(asr, "UpdateFile", "Kiss_Update.zip");

                    //check if there is an Application ZIP package on the server ?
                    var zipFileApplication = new FileInfo(Path.Combine(updateSource, updateFile));
                    if (zipFileApplication.Exists)
                    {
                        var zipTimeStamp = zipFileApplication.LastWriteTimeUtc;
                        var updateService = new UpdateService();

                        // Read last update time stamp
                        var localTimeStamp = updateService.ReadLocalUpdateTimeStamp();

                        //Check TimeStamp
                        if (localTimeStamp == null || localTimeStamp.Value < zipTimeStamp)
                        {
                            string tempFolder;

                            //check if Kiss_Update_exe.zip exists on the server ?
                            string updateExeFile = TryGetSettingsValue(asr, "UpdateExeFile", "Kiss_Update_Exe.zip");
                            string zipFileUpdateExecLocation = Path.Combine(updateSource, updateExeFile);
                            var zipFileUpdateExec = new FileInfo(zipFileUpdateExecLocation);
                            if (zipFileUpdateExec.Exists)
                            {
                                //das Update-Package auf dem Server vorhanden: Auf Temp Update-Package laden, Update im neuen Prozess ausführen, sich selbst schliessen
                                //Create Temp Folder
                                tempFolder = Path.Combine(Path.GetTempPath(), "KiSS");
                                Directory.CreateDirectory(tempFolder);

                                //Zip Extract to Temp
                                Zip zipFile = new Zip(zipFileUpdateExec.FullName);
                                zipFile.ExtractAll(tempFolder, true);
                            }
                            else
                            {
                                //check if Update local
                                if (!File.Exists(Constants.UPDATE_APPLICATION))
                                {
                                    // kein Update Package vorhanden : starten lassen
                                    return;
                                }

                                //das Update-Package nur lokal vorhanden : Auf Temp Update-Package laden, Update im neuen Prozess ausführen, sich selbst schliessen
                                var updateFiles = Constants.UpdateFiles;
                                tempFolder = Path.Combine(Path.GetTempPath(), "KiSS");
                                Directory.CreateDirectory(tempFolder);
                                foreach (var file in updateFiles)
                                {
                                    string newFileLocation = Path.Combine(tempFolder, file);
                                    if (File.Exists(newFileLocation))
                                    {
                                        File.SetAttributes(newFileLocation, FileAttributes.Normal);
                                        File.Delete(newFileLocation);
                                    }

                                    File.Copy(file, newFileLocation, true);
                                    File.SetAttributes(newFileLocation, FileAttributes.Normal);
                                }
                            }

                            //Update ausführen
                            // letztes Zeichen von AppDomain.CurrentDomain.BaseDirectory abschneiden
                            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
                            currentDir = currentDir.Remove(currentDir.Length - 1);

                            //Update Args vorbereiten
                            var updateArgs = string.Format("\"{0}\" \"{1}\"", zipFileApplication.FullName, currentDir);

                            //Setze _updateInProgress-Flag
                            _updateInProgress = true;

                            //Update Starten
                            var startInfo = new ProcessStartInfo(Path.Combine(tempFolder, Constants.UPDATE_APPLICATION), updateArgs);

                            // Schreibrechte prüfen
                            if (!UserHasDirectoryWriteRights(currentDir))
                            {
                                startInfo.UseShellExecute = true;
                                startInfo.Verb = "runas";
                            }

                            Process.Start(startInfo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Debug(ex);
            }
        }

        private static void HandleThreadException(object sender, ThreadExceptionEventArgs args)
        {
            if (args.Exception.StackTrace.IndexOf("DevExpress.XtraEditors.ScrollBarBase.DelayedUpdate()") > 0)
            {
                // Dies ist ein bekannter Fehler von DevExpress und wird ignoriert (ohne Meldung). Siehe auch http://www.devexpress.com/Support/Center/p/CB63896.aspx
                _logger.Error("Bekannter Fehler von DevExpress (DevExpress Ticket CB63896) abgefangen und ignoriert: " + args.Exception);
                return;
            }

            _logger.Error(args.Exception);
            KissMsg.ShowError(Resources.FehlerKissNeuStarten, args.Exception);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            // Ensure that Thread.CurrentPrincipal will be set
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

            if (args.Length == 1 && !args[0].StartsWith("/"))
            {
                string pwScrambeled = Session.ScramblePassword(args[0]);
                Clipboard.SetDataObject(pwScrambeled, true, 2, 100);
                MessageBox.Show(string.Format("Die Verschlüsselung von \"{0}\" ist \"{1}\". Der Wert wurde in die Zwischenablage kopiert.", args[0], pwScrambeled));
                return;
            }

            Arguments arguments = new Arguments(args);

            if (arguments["username"] != null)
            {
                var username = arguments["username"].ToString();
                string usrScrambeled = Session.ScrambleUser(username);
                Clipboard.SetDataObject(usrScrambeled, true, 2, 100);
                MessageBox.Show(string.Format("Die Userverschlüsselung von \"{0}\" ist \"{1}\". Der Wert wurde in die Zwischenablage kopiert.", username, usrScrambeled));
                return;
            }

            if (arguments["?"] != null || arguments["h"] != null || arguments["help"] != null)
            {
                FileInfo myExeFile = new FileInfo(Application.ExecutablePath);

                MessageBox.Show(string.Format("KiSS 4\tVersion: {1}\r\n\r\n" +
                                              "{0} Password\t\tErzeugt Passworthash für {0}.config\r\n" +
                                              "{0} /Environment:<Name>\tStandart KiSS-Umgebung festlegen\r\n" +
                                              "{0} /Form:<ClassName>\tFormController Aufruf\r\n" +
                                              "\t[<Key>:<Value>]\tweitere Argumente für den FormController\r\n" +
                                              "{0} /Username:<Name>\tErzeugt Userhash für Konfig-Wert",
                    myExeFile.Name, Common.Utils.MainVersion));

                return;
            }

            LogConfigurator.Init();
            _logger.Info("Application started");

            AppSettingsReader asr = new AppSettingsReader();

            if (arguments["noupdate"] == null)
            {
                CheckForUpdates(asr);
            }

            if (!_updateInProgress)
            {
                bool singleInstance = true;

                try
                {
                    singleInstance = (bool)asr.GetValue("SingleInstance", typeof(bool));
                }
                catch (Exception ex)
                {
                    _logger.Info(ex);
                }

                if (singleInstance)
                {
                    SingleInstanceApplication.Run(new FrmMain(arguments), StartupNextInstanceHandler);
                }
                else
                {
                    try
                    {
                        // Add the event handler for handling UI thread exceptions to the event.
                        Application.ThreadException += HandleThreadException;
                        ViewBootstrapper.RegisterTypes();
                        Application.Run(new FrmMain(arguments));
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex);
                        KissMsg.ShowError(
                            "KiSS",
                            "KiSSFatalError",
                            "Es ist ein schwerwiegender Fehler aufgetreten. KiSS musste beendet werden.",
                            ex.Message,
                            ex,
                            0,
                            0);
                        throw;
                    }
                }
            }

            _logger.Info("Application stopped");
        }

        private static void StartupNextInstanceHandler(object sender, StartupNextInstanceEventArgs e)
        {
            if (e.CommandLine.Count > 1)
            {
                // Seperate the arguments from the programm call
                string[] args = new string[e.CommandLine.Count - 1];
                for (int i = 0; i < args.Length; i++)
                {
                    args[i] = e.CommandLine[i + 1];
                }

                ProcessCommandLine(args);
            }
        }

        private static string TryGetSettingsValue(AppSettingsReader asr, string key, string defaultValue)
        {
            try
            {
                return (string)asr.GetValue(key, typeof(string));
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Checks if the current user has rights for a folder.
        /// </summary>
        private static bool UserHasDirectoryWriteRights(string path)
        {
            try
            {
                var testFilePath = Path.Combine(path, ".access");

                var fs = File.Create(testFilePath);
                fs.Close(); //make sure, the file is not locked anymore

                File.Delete(testFilePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #endregion
    }
}