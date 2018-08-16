using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kiss4Web.Model.QueryTypes
{
    public class TablePendenzenItem
    {
        public int XTaskID { get; set; }
        public int? FaFallID { get; set; }
        public int? FaLeistungID { get; set; }
        public int? BaPersonID { get; set; }
        public int TaskTypeCode { get; set; }
        public int TaskStatusCode { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? StartDate { get; set; }
        public int? UserID_InBearbeitung { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? DoneDate { get; set; }
        public int? UserID_Erledigt { get; set; }
        public string Subject { get; set; }
        public string TaskDescription { get; set; }
        public int? SenderID { get; set; }
        public int TaskSenderCode { get; set; }
        public int ReceiverID { get; set; }
        public int TaskReceiverCode { get; set; }
        public string ResponseText { get; set; }
        public int? TaskResponseCode { get; set; }
        public string JumpToPath { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string FaFall { get; set; }
        public int? Fallnummer { get; set; }
        public int? UserID { get; set; }
        public string SAR { get; set; }
        public int? FAL_BaPersonID { get; set; }
        public string PersonFT { get; set; }
        public string PersonBP { get; set; }
        public int? ModulID { get; set; }
        public char? LeistungModul { get; set; }
        public int OrgUnitID { get; set; }
        public int Auswahl { get; set; }
        public int DatumVon { get; set; }
        public string SenderEMail { get; set; }
        public string ReceiverEMail { get; set; }

        [Timestamp]
        public byte[] XTaskTS { get; set; }

        //public DateTime Fallig { get; set; }
        //public string Betreff { get; set; }
        //public char Leistungsverantw { get; set; }
        //public string Falltrager { get; set; }
        //public long Fallnummer { get; set; }
        //public string Person { get; set; }
        //public string Ersteller { get; set; }
        //public string Empfanger { get; set; }
        //public string Status { get; set; }
        //public DateTime Erfasst { get; set; }
        //public DateTime Bearbeitung { get; set; }
        //public DateTime Erledigt { get; set; }
        //public string Antwort { get; set; }
    }
}
