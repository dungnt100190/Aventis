using System;

namespace KiSSSvc.SAP.Helpers.DataObjects
{
	public class Response
	{
		public BAPIRET2[] RETURN_MESSAGES;
		public BAPIBUS1006_BANKDETAILS[] STEP2_T_BANKDETAILDATA;
		public ZSTEP3_IBAN[] STEP3_T_IBAN;
	}
}
