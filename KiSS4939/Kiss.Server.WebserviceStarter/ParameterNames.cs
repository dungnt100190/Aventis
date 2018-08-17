using System.ComponentModel;

namespace Kiss.Server.WebserviceStarter
{
    public static class ParameterNames
    {
#if DISABLE_CODEMAID_REORGANIZING
#endif

        [Description("<string> Der Name des aufzurufenden Services. Siehe weiter unten für die möglichen Werte.")]
        public const string ServiceName = "ServiceName";

        [Description("<string> Der Name der aufzurufenden Service-Methode. Siehe weiter unten für die möglichen Werte.")]
        public const string MethodName = "MethodName";

        [Description("<string> Wird verwendet, damit ein Befehl nicht auf der falschen DB ausgeführt wird. Muss übereinstimmen mit der im Webservice (Web.config) konfigurierten DB.")]
        public const string DbName = "DbName";

        [Description("<string> Absender-Adresse für Email-Benachrichtigungen.")]
        public const string EmailFrom = "EmailFrom";

        [Description("<string> Gibt an, wann eine E-Mail verschickt wird. Mögliche Werte sind: Always, Failure, Never")]
        public const string EmailNotificationLevel = "EmailNotificationLevel";

        [Description("<string> Eine kommaseparierte Liste mit E-Mail-Adressen, an welche die generierten Mails verschickt werden.")]
        public const string EmailRecipients = "EmailRecipients";

        [Description("<string> Server-Name/URL des SMTP-Servers, über welchen die Mails verschickt werden.")]
        public const string EmailSmtpHost = "EmailSmtpHost";

        [Description("<int> Port des SMTP-Servers.")]
        public const string EmailSmtpPort = "EmailSmtpPort";

        [Description("<string> Benutzername, mit welchem die Verbindung zum SMTP-Server hergestellt wird. Wenn dies leer gelassen wird, werden die Credentials des ausführenden Benutzers verwendet.")]
        public const string EmailSmtpUsername = "EmailSmtpUsername";

        [Description("<string> Passwort, mit welchem die Verbindung zum SMTP-Server hergestellt wird. Wird nur verwendet, wenn EmailSmtpUsername angegeben ist.")]
        public const string EmailSmtpPassword = "EmailSmtpPassword";

        [Description("<int> Die Clearing-Nummer für den Test des Iban-Services.")]
        public const string IbanClearingNr = "IbanClearingNr";

        [Description("<string> Die Konto-Nummer für den Test des Iban-Services.")]
        public const string IbanKontoNr = "IbanKontoNr";

        [Description("<int> Die Anzahl Dateien, die bei der Verarbeitung der Omega-Ereignisse auf ein Mal verarbeitet werden.")]
        public const string EventPacketSize = "EventPacketSize";

        [Description("Gibt an, ob bei der Verarbeitung der Omega-Ereignisse vorher als fehlerhaft markierte Ereignisse nochmals verarbeitet werden sollen.")]
        public const string IncludeFailedEvents = "IncludeFailedEvents";

        [Description("<int> Die minimale Grösse, die ein PDF-Dokument haben muss, um importiert zu werden (Anzahl Bytes).")]
        public const string ZkbDokumenteImportMinSize = "ZkbDokumenteImportMinSize";

        [Description("<int> Die UserID, die zu Loggin-Zwecken bei dem Import der ZKB-Dokumente bzw. der Generierung der IK-Auszüge verwendet wird.")]
        public const string WorkerProcessUserId = "WorkerProcessUserId";
    }
}