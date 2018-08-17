using System;
using System.Diagnostics;

using KiSS4.DB;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Manages the SWOX transmission.
    /// </summary>
    internal class Swox
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Sends files trough Swox.
        /// </summary>
        /// <param name="jobCode">Ezag or DTA</param>
        /// <param name="fileName">Path to the local file to send</param>
        /// <param name="swoxId">Swox Security ID to allow batch call, Set Under Swox->Options</param>
        public void SwoxSend(
            String jobCode,
            String fileName,
            String swoxId)
        {
            try
            {
                var startInfo = new ProcessStartInfo("Swox.exe");

                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;

                startInfo.Arguments = "/JOB=" + jobCode + " " + fileName + " " + swoxId;

                Process test = Process.Start(startInfo);

                int exitCode = test.ExitCode;

                if (exitCode != 0)
                {
                    KissMsg.ShowInfo(
                        "CtlFibuDTAZahlungsLauf",
                        "FehlerUebermittlung",
                        "Fehler bei der Übermittlung des Zahlungsauftrags. => Swox starten und die Fehlerliste anschauen");
                }
            }
            catch (Exception e)
            {
                KissMsg.ShowError(
                    "CtlFibuDTAZahlungsLauf",
                    "FehlerUebermittlungAuftrag",
                    "Fehler bei der Übermittlung des Zahlungsauftrags",
                    e.Message,
                    e);
            }
        }

        #endregion

        #endregion
    }
}