using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KiSS4.DB;
using log4net;

namespace KiSS4.Gui
{
    public static class ShutdownHelper
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static bool SavePersistentObjects(bool isClosing)
        {

                        // if no persistent object exists, we can leave here
            if (!HasPersistentObjects())
            {
                return true;
            }

            string msgInfo = KissMsg.GetMLMessage("KissMainForm",
                                                  "KissClosingWithOpenedDocumentsStart",
                                                  "Es sind noch folgenden Dateien offen:");

            string msgObjects = GetPersistentObjectsNames();

            string msgInfo2 = KissMsg.GetMLMessage("KissMainForm",
                                                   "KissClosingWithOpenedDocumentsInfo",
                                                   "Bitte schliessen Sie alle diese Dateien, bevor Sie KiSS beenden resp. sich neu anmelden.");

            string msgQuestion = isClosing ?
                // user is closing KISS
                KissMsg.GetMLMessage("KissMainForm", "DoYouWantToCloseKiss", "Wollen Sie KiSS trotzdem schliessen?") :
                // user is loging in or loging out
                KissMsg.GetMLMessage("KissMainForm", "DoYouWantToLogout", "Wollen Sie sich trotzdem abmelden oder neu anmelden?");

            string msgHint = KissMsg.GetMLMessage("KissMainForm",
                                                  "HintDocumentsWillGetUnlocked_v06",
                                                  "Hinweis:\r\nNicht gespeicherte Änderungen gehen möglicherweise verloren. Die geöffneten Dokumente werden in KiSS zur Bearbeitung durch andere Benutzer freigegeben.");

            if (!KissMsg.ShowQuestion(msgInfo + "\r\n\r\n" + msgObjects + "\r\n" + msgInfo2 + "\r\n\r\n" + msgHint + "\r\n\r\n" + msgQuestion))
            {
                //"Bitte alle KiSS-Dokumente vor dem Verlassen schliessen. " +
                //"Falls Sie nach dem Beenden von KiSS Dokumente weiter bearbeiten, werden diese Änderungen nicht in KiSS gespeichert!\r\n\r\n" +
                //"KiSS trotzdem schliessen?", 520, 210))
                // the user will not close, thus we let him do further work
                return false;
            }

            _log.Debug(string.Format("Der Benututzer {0}, obwohl noch offene Dokumente vorhanden sind.", isClosing ? "beendet KiSS" : "meldet sich ab"));

            // the user wants to close (KISS or Session), thus we delete all existing document watchers
            // take care: if not, XDocFilehandler will try to save old documents with a new Session and on old DB
            // alternativ solution: include the session in XDocFileHandler,
            // and refact saving of documents for different sessions (down to SqlQuery?  ... good luck)
            // simplest solution : destroy the XDocFileHandler now, files will not be saved back to DB:
            bool objectDisposed = true;

            try
            {
                int maxCount = Session.PersistentObjects.Count - 1;

                for (int idx = maxCount; idx >= 0; idx--)
                {
                    object tmpObj = Session.PersistentObjects[idx];

                    if (tmpObj is IKissPersistentObject)
                    {
                        // see XDocFileHandler.ObjectDisposed
                        // stop the watcher, delete the file and unlock
                        objectDisposed = (tmpObj as IKissPersistentObject).ObjectDisposed;

                        // TODO
                        // refactor when closing KISS should be stopped
                        // introduce value FALSE, too (e.g. for errors)
                        // see also XDocFileHandler.ObjectDisposed
                    }
                }
            }
            catch (Exception ex)
            {
                // see also XDocFileHandler.ObjectDisposed
                // do not translate, should never occur
                // if not, first debug the error
                // TODO : probably occurred when simulating conflicts with 2 users
                // TODO : or eventually opening password protected word files without knowing the password
                // TODO : has to be tested furthermore
                KissMsg.ShowError("Fehler in KissMainForm.SavePersistentObjects:\r\n" +
                                  "Beim Schliessen der Dateiüberwachung ist ein unbekannter Fehler aufgetreten:\r\n" +
                                  ex.Message + "\r\n\r\n" +
                                  "Starten Sie KISS neu.", ex);
            }

            return true;
        }

        /// <summary>
        /// Searches for persistent objects.
        /// </summary>
        /// <returns></returns>
        private static bool HasPersistentObjects()
        {
            // search for persistent object
            foreach (object o in Session.PersistentObjects)
            {
                if (!(o is IKissPersistentObject) || (o is IKissPersistentObject && ((IKissPersistentObject)o).PendingChanges))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Get the names of the persistent objects, each one on one line.
        /// </summary>
        private static string GetPersistentObjectsNames()
        {
            string persistentObjectsNames = "";
            int maxCount = Session.PersistentObjects.Count;

            for (int idx = 0; idx < maxCount; idx++)
            {
                object tmpObj = Session.PersistentObjects[idx];

                if (tmpObj is IKissPersistentObject)
                {
                    // collect some info about the watchers
                    persistentObjectsNames = persistentObjectsNames + (tmpObj as IKissPersistentObject).ObjectName + "\r\n";
                }
            }

            return persistentObjectsNames;
        }

    }
}
