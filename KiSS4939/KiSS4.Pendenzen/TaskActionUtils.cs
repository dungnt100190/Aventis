using System;
using System.Data;
using System.Net.Mail;
using System.Text;

using Kiss.Infrastructure.Constant;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Pendenzen
{
    public static class TaskActionUtils
    {
        public enum PerformActionResult
        {
            Fehler = 0,
            Nichtunterstuetzt = -1,
            Ok = 1
        }

        private const string CLASSNAME = "TaskActionUtils";

        public static bool CreateAnfangsZustand(int? year, int? faLeistungID, int? baPersonID, int? modulID, bool showQuestion)
        {
            if (!showQuestion || KissMsg.ShowQuestion(
                    CLASSNAME,
                    "ConfirmCreateBeginningState",
                    "Es wird ein Anfangzustand angelegt, wollen Sie fortfahren?"))
            {
                SqlQuery qryTmp = DBUtil.OpenSQL(
                    "exec dbo.spBFSGetImportDossiers {0}, NULL, {1}, NULL, NULL",
                    year,
                    baPersonID);

                Session.BeginTransaction();
                try
                {
                    // Iteriere über alle importierten Anfangszustands-Dossiers. Normalerweise ist dies nur eines,
                    // potentiell könnte aber der Sozi die Pendenz mehrere Monate zu spät abgearbeitet haben, so dass in der zwischenzeit schon ein 6-Monate-Unterbruch möglich wäre
                    foreach (DataRow row in qryTmp.DataTable.Rows)
                    {
                        var datVon = row["DatumVon"] as DateTime?;
                        var laufNr = row["LaufNr"];

                        if (!year.HasValue
                            //wenn wir nicht wissen, für welches Jahr wir das Anf.Zustand-Dossier zu erstellen haben, machen wir eh alle
                            || (datVon.HasValue && datVon.Value.Year >= year.Value))
                        //wenn die Pendenz aus dem Jahr 2014 stammt, erstellen wir nur fürs 2014 oder später ein Anf.Zustand-Dossier. Fürs 2013 wird kein Anf.Zustand-Dossier erstellt, auch wenn das Stichtagsdossier ggf noch einmal abgeliefert werden muss.
                        {
                            DBUtil.ExecSQLThrowingException(
                                @"EXEC dbo.spBFSDossier_Create {0}, {1}, {2}, {3}, {4}, {4}, 0, {5}",
                                // // DatumBis = DatumVon, 0 = Anfangszustand
                                year,
                                faLeistungID,
                                baPersonID,
                                modulID,
                                datVon,
                                laufNr);
                        }
                    }

                    Session.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    Session.Rollback();
                    KissMsg.ShowError(
                        CLASSNAME,
                        "CouldNotCreateBeginningState",
                        "Der Anfangszustand konnte nicht erstellt werden.",
                        ex);
                }
            }

            return false;
        }

        public static PerformActionResult PerformAction(TaskAction action)
        {
            var isResultPerformActionSuccess = true;

            switch (action.XTaskTypeActionType)
            {
                case LOVsGenerated.XTaskTypeActionType.Bewilligen:
                    if (action.TaskType == LOVsGenerated.TaskType.BefristetesGastrechtErteilen
                        || action.TaskType == LOVsGenerated.TaskType.UnbefristetesGastrechtErteilen)
                    {
                        if (action.FaLeistungId == null || action.SenderUserID == null)
                        {
                            throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME, "UngueltigeParameter", "Parameter sind ungültig : FaLeistungID oder ReceiverUserID is leer", KissMsgCode.MsgError));
                        }

                        isResultPerformActionSuccess = GastrechtErteilen(
                                        (int)action.FaLeistungId,
                                        (int)action.SenderUserID,
                                        (action.TaskType == LOVsGenerated.TaskType.UnbefristetesGastrechtErteilen));
                    }
                    else
                    {
                        return PerformActionResult.Nichtunterstuetzt;
                    }
                    break;

                case LOVsGenerated.XTaskTypeActionType.Ablehnen:
                    if (action.TaskType == LOVsGenerated.TaskType.BefristetesGastrechtErteilen
                        || action.TaskType == LOVsGenerated.TaskType.UnbefristetesGastrechtErteilen)
                    {
                        isResultPerformActionSuccess = GastrechtAblehnen();
                    }
                    else
                    {
                        return PerformActionResult.Nichtunterstuetzt;
                    }

                    break;

                case LOVsGenerated.XTaskTypeActionType.AnfangszustandErstellen:
                    if (action.TaskType == LOVsGenerated.TaskType.KontrolleAnfangszustandBfs)
                    {
                        isResultPerformActionSuccess = CreateAnfangsZustand(action.CreateDate.Year, action.FaLeistungId, action.BaPersonId, action.ModulId, action.AktionBestaetigen);
                    }
                    else
                    {
                        return PerformActionResult.Nichtunterstuetzt;
                    }
                    break;
            }

            // Benachrichtigung verschicken
            if (isResultPerformActionSuccess && action.BenachrichtigungAktiv)
            {
                action.Betreff = ReplaceParameters(action.Betreff, action);
                action.Text = ReplaceParameters(action.Text, action);
                SendMail(Session.User.EMail, action.SenderEmail, action.Betreff, action.Text);
            }

            return isResultPerformActionSuccess ? PerformActionResult.Ok : PerformActionResult.Fehler;
        }

        public static bool SendMail(string from, string to, string subject, string messageText)
        {
            if (string.IsNullOrEmpty(from))
            {
                KissMsg.ShowInfo(CLASSNAME, "SendMailParameterFromLeer", "Die Mailadresse des Empfängers ist leer. Die Benachrichtigung konnte nicht verschickt werden.");
                return false;
            }
            if (string.IsNullOrEmpty(to))
            {
                KissMsg.ShowInfo(CLASSNAME, "SendMailParameterToLeer", "Das Mailadresse des Senders ist leer. Die Benachrichtigung konnte nicht verschickt werden.");
                return false;
            }

            const string keypath = @"System\Mail\SMTP-Relay";
            var host = DBUtil.GetConfigString(keypath, string.Empty);
            if (string.IsNullOrEmpty(host))
            {
                KissMsg.ShowInfo(CLASSNAME, "SendMailParameterHostLeer", "Die Adresse des Mailservers ist nicht konfiguriert. Die Benachrichtigung konnte nicht verschickt werden. Bitte konfigurieren Sie die Adresse des Mailservers im Wert {0}.", keypath);
                return false;
            }

            var useDefaultCredentials = DBUtil.GetConfigBool(@"System\Mail\UseWindowsCredentials", false);

            try
            {
                var message = new MailMessage(from, to);
                message.BodyEncoding = Encoding.UTF8;
                message.Subject = subject;
                message.Body = messageText;

                var smtpClient = new SmtpClient();
                smtpClient.Host = host;

                smtpClient.UseDefaultCredentials = useDefaultCredentials;
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(
                    CLASSNAME,
                    "ErrorSendMail",
                    "Es ist ein Fehler beim Senden der eMail aufgetreten.",
                    ex);
                return false;
            }

            KissMsg.ShowInfo(CLASSNAME, "SendMailOk", "Eine eMail wurde an {0} geschickt.", to);
            return true;
        }

        private static bool FaLeistungZugriffUpdate(int faLeistungID, int userID, DateTime datumVon, DateTime? datumBis)
        {
            const int darfMutieren = 0;

            //überschneidung mit schon bestehende?
            SqlQuery qryFaLeistungZugriff = DBUtil.OpenSQL(
                @"
                            SELECT FaLeistungZugriffID
                            FROM dbo.FaLeistungZugriff
                            WHERE 1=1
                            AND FaLeistungID = {0}
                            AND UserID = {1}
                            AND ISNULL(dbo.fnDateOf(DatumBis),'99991231') > dbo.fnDateOf({2})
                            AND dbo.fnDateOf(DatumVon) < dbo.fnDateOf(ISNULL({3},'99991231'));",
                faLeistungID,
                userID,
                datumVon,
                datumBis);
            if (qryFaLeistungZugriff.HasRow)
            {
                //Update schon bestehende Periode DatumVon/DatumBis

                if (qryFaLeistungZugriff.Count > 1)
                {
                    //Überschneidung mit mehr als eine Periode --> Fehlermeldung
                    KissMsg.ShowInfo(CLASSNAME, "TaskActionUtilsPeriodeUeberschneidung", "Es gibt Überschneidungen mit mehr als einer Periode. Bitte passen Sie den Gastrechtzugriff für diesen Benutzer manuell an.");
                    return false;
                }

                DBUtil.ExecSQL(@"
                UPDATE dbo.FaLeistungZugriff
                SET DatumVon = dbo.fnDateOf({0})
                WHERE 1=1
                AND FaLeistungZugriffID = {1}
                AND dbo.fnDateOf(DatumVon) > dbo.fnDateOf({0}) ", datumVon, qryFaLeistungZugriff["FaLeistungZugriffID"]);

                DBUtil.ExecSQL(
                    @"
                UPDATE dbo.FaLeistungZugriff
                SET DatumBis = dbo.fnDateOf({0})
                WHERE 1=1
                AND FaLeistungZugriffID = {1}
                AND dbo.fnDateOf(ISNULL(DatumBis,'99991231')) < dbo.fnDateOf(ISNULL({0},'99991231'))",
                    datumBis,
                    qryFaLeistungZugriff["FaLeistungZugriffID"]);
            }
            else
            {
                // Insert neue Periode
                DBUtil.ExecSQL(
                    @"
                INSERT INTO dbo.FaLeistungZugriff
                    (FaLeistungID,
                     UserID,
                     DarfMutieren,
                     DatumVon,
                     DatumBis)
                VALUES  ({0}, -- FaLeistungID - int
                         {1}, -- UserID - int
                         {2}, -- DarfMutieren - bit
                         {3}, -- DatumVon - datetime
                         {4} -- DatumBis - datetime
                         ) ",
                    faLeistungID,
                    userID,
                    darfMutieren,
                    datumVon,
                    datumBis);

                //cascadate insert nicht nötig weil  für (FaLeistung K-EAF) kein Gastrecht-Anfrage nötig ist
            }

            return true;
        }

        private static bool GastrechtAblehnen()
        {
            return KissMsg.ShowQuestion(
                CLASSNAME,
                "GastrechtAblehnenBestaetigen",
                "Es wird ein Gastrecht abgelehnt, wollen Sie fortfahren?");
        }

        private static bool GastrechtErteilen(int faLeistungID, int userID, bool isUnbefristet)
        {
            if (!KissMsg.ShowQuestion(
                CLASSNAME,
                "GastrechtErteilenBestaetigen",
                "Es wird ein Gastrecht erteilt, wollen Sie fortfahren?"))
            {
                return false;
            }

            DateTime datumVon = FallUtil.GetFaLeistungZugriffNewDatumVon();
            DateTime? datumBis = (isUnbefristet) ? (DateTime?)null : FallUtil.GetFaLeistungZugriffNewDatumBis();

            bool result = FaLeistungZugriffUpdate(faLeistungID, userID, datumVon, datumBis);

            if (result)
            {
                KissMsg.ShowInfo(CLASSNAME, "GastrechtErteilenErfolg", "Das Gastrecht wurde erfolgreich erteilt.");
            }
            else
            {
                KissMsg.ShowError(CLASSNAME, "GastrechtErteilenFehler", "Das Gastrecht konnte nicht erteilt werden.");
            }

            return result;
        }

        private static string ReplaceParameters(string stringWithParameters, TaskAction action)
        {
            var anzahlMonate = DBUtil.GetConfigValue(@"System\Allgemein\GastrechtAnzahlMonate", 6).ToString();
            if (stringWithParameters != null)
            {
                return stringWithParameters.Replace("{FT}", action.PersonFT)
                            .Replace("{BP}", action.PersonBP)
                            .Replace("{MODUL}", action.Modul)
                            .Replace("{MONATE}", anzahlMonate)
                            .Replace("{ANTWORT}", action.Antwort)
                            .Replace("{USER}", string.Format("{0} ({1})", Session.User.LastFirstName, Session.User.LogonName)
                            );
            }
            return null;
        }
    }
}