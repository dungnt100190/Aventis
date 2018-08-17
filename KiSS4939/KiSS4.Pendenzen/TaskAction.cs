using System;

using Kiss.Infrastructure.Constant;

namespace KiSS4.Pendenzen
{
    public class TaskAction
    {
        public TaskAction()
        {
            AktionBestaetigen = true;
        }

        public bool AktionBestaetigen { get; set; }

        public string Antwort { get; set; }

        public int? BaPersonId { get; set; }

        public bool BenachrichtigungAktiv { get; set; }

        public string Betreff { get; set; }

        public string Bezeichnung { get; set; }

        public DateTime CreateDate { get; set; }

        public bool ErstellerDarfAusfuehren { get; set; }

        public int? FaLeistungId { get; set; }

        public string Modul { get; set; }

        public int? ModulId { get; set; }

        public string PersonBP { get; set; }

        public string PersonFT { get; set; }

        public string ReceiverEmail { get; set; }

        public string SenderEmail { get; set; }

        public int? SenderUserID { get; set; }

        public LOVsGenerated.TaskType TaskType { get; set; }

        public string Text { get; set; }

        public int XTaskId { get; set; }

        public int XTaskTypeActionId { get; set; }

        public LOVsGenerated.XTaskTypeActionType XTaskTypeActionType { get; set; }
    }
}