using System;
using System.Net;
using System.Net.Mail;
using System.Text;

using Kiss.Server.WebserviceStarter.Properties;

using log4net;

namespace Kiss.Server.WebserviceStarter
{
    public enum EmailNotificationLevel
    {
        Never = 0,
        Failure = 1,
        Always = 2
    }

    public class EmailNotificationService
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(EmailNotificationService));

        private string _from;
        private EmailNotificationLevel? _level;
        private string _recipients;
        private string _smtpHost;
        private string _smtpPassword;
        private int? _smtpPort;
        private string _smtpUsername;

        public EmailNotificationService()
        {
        }

        public EmailNotificationService(ArgumentDictionary arguments)
        {
            From = arguments[ParameterNames.EmailFrom];
            Recipients = arguments[ParameterNames.EmailRecipients];
            SmtpHost = arguments[ParameterNames.EmailSmtpHost];
            SmtpPassword = arguments[ParameterNames.EmailSmtpPassword];
            SmtpUsername = arguments[ParameterNames.EmailSmtpUsername];

            EmailNotificationLevel level;
            if (Enum.TryParse(arguments[ParameterNames.EmailNotificationLevel], out level))
            {
                Level = level;
            }

            int port;
            if (int.TryParse(arguments[ParameterNames.EmailSmtpPort], out port))
            {
                SmtpPort = port;
            }
        }

        public string From
        {
            get { return _from ?? (_from = Settings.Default.EmailFrom); }
            set { _from = value; }
        }

        public EmailNotificationLevel Level
        {
            get { return (_level ?? (_level = Settings.Default.EmailNotificationLevel)).Value; }
            set { _level = value; }
        }

        public string Recipients
        {
            get { return _recipients ?? (_recipients = Settings.Default.EmailRecipients); }
            set { _recipients = value; }
        }

        public string SmtpHost
        {
            get { return _smtpHost ?? (_smtpHost = Settings.Default.EmailSmtpHost); }
            set { _smtpHost = value; }
        }

        public string SmtpPassword
        {
            get { return _smtpPassword ?? (_smtpPassword = Settings.Default.EmailSmtpPassword); }
            set { _smtpPassword = value; }
        }

        public int SmtpPort
        {
            get { return (_smtpPort ?? (_smtpPort = Settings.Default.EmailSmtpPort)).Value; }
            set { _smtpPort = value; }
        }

        public string SmtpUsername
        {
            get { return _smtpUsername ?? (_smtpUsername = Settings.Default.EmailSmtpUsername); }
            set { _smtpUsername = value; }
        }

        public bool NotifyFailure(string methodDescription, string errorMessage)
        {
            if (Level == EmailNotificationLevel.Never)
            {
                _log.DebugFormat("Error ({0}) - EmailNotificationLevel is set to '{1}', no message will be sent. The error was: {2}", methodDescription, Level, errorMessage);
                return true;
            }

            var subject = Settings.Default.EmailSubject_Failure.Replace("{method}", methodDescription);
            var body = Settings.Default.EmailBody_Failure
                .Replace("{method}", methodDescription)
                .Replace("{message}", errorMessage)
                .Replace("{newline}", Environment.NewLine);
            return SendMail(subject, body);
        }

        public bool NotifySuccess(string methodDescription)
        {
            if (Level != EmailNotificationLevel.Always)
            {
                _log.DebugFormat("Success ({0}) - EmailNotificationLevel is set to '{1}', no message will be sent.", methodDescription, Level);
                return true;
            }

            var subject = Settings.Default.EmailSubject_Success.Replace("{method}", methodDescription);
            var body = Settings.Default.EmailBody_Success
                .Replace("{method}", methodDescription)
                .Replace("{newline}", Environment.NewLine);
            return SendMail(subject, body);
        }

        private bool SendMail(string subject, string body)
        {
            try
            {
                using (var mailMessage = new MailMessage())
                using (var smtpClient = new SmtpClient(SmtpHost, SmtpPort))
                {
                    mailMessage.Subject = subject;
                    mailMessage.SubjectEncoding = Encoding.UTF8;
                    mailMessage.Body = body;
                    mailMessage.BodyEncoding = Encoding.UTF8;
                    mailMessage.From = new MailAddress(From);
                    mailMessage.To.Add(Recipients);

                    if (!string.IsNullOrEmpty(SmtpUsername))
                    {
                        smtpClient.Credentials = new NetworkCredential(SmtpUsername, SmtpPassword);
                    }
                    else
                    {
                        smtpClient.UseDefaultCredentials = true;
                    }

                    smtpClient.Send(mailMessage);
                    _log.DebugFormat("Email successfully sent. From: {0} To: {1} Host: {2}:{3}", From, Recipients, SmtpHost, SmtpPort);
                }

                return true;
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Email could not be sent. From: {0} To: {1} Host: {2}:{3}, Error: {4}", From, Recipients, SmtpHost, SmtpPort, ex);
                return false;
            }
        }
    }
}