using System;

namespace Kiss4Web.Model.QueryTypes
{
	public class PendenzenItem
    {
		public int XTaskID { get; set; }
		public int? FaFallID { get; set; }
		public int? FaLeistungID { get; set; }
		public int? BaPersonID { get; set; }
		public int? TaskTypeCode { get; set; }
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
		public int? TaskSenderCode { get; set; }
		public int? ReceiverID { get; set; }
		public int? TaskReceiverCode { get; set; }
		public string ResponseText { get; set; }
		public int? TaskResponseCode { get; set; }
		public string JumpToPath { get; set; }
		public Byte[] XTaskTS { get; set; }

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
		public string LeistungModul { get; set; }
		public int? OrgUnitID { get; set; }
		public bool? Auswahl { get; set; }
		public int? DatumVon { get; set; }
		public string SenderEMail { get; set; }
		public string ReceiverEMail { get; set; }
    }
}
