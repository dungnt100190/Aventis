using System;
using System.Collections.Generic;
using System.Text;

namespace KiSSSvc.SAP.PSCD.WebServiceHelper
{
	public enum CreateObjectResult
	{
		Success = 0,
		Warning = 1,
		ExceptionOccured = 2
	}


	public class ReturnMsg
	{
		public ReturnMsg()
		{}

		public ReturnMsg(CreateObjectResult result)
			: this(result, null)
		{ }

		public ReturnMsg(CreateObjectResult result, string exceptionMessage)
		{
			this.Result = result;
			this.ExceptionMessage = exceptionMessage;
		}

		public CreateObjectResult Result;
		public string ExceptionMessage = null;
		public string WarningMessage = null;
		public int ErrorCode;
	}
}
