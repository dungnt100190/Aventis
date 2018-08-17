using System;
using System.Collections.Generic;
using System.Text;

namespace KiSSSvc.SAP.PSCD.WebServiceHelper
{
	public class UserInfo
	{
		public UserInfo(int userID, string userWinLogonName)
		{
			UserID = userID;
			UserWinLogonName = userWinLogonName;
		}
		public int UserID = 0;
		public string UserWinLogonName;
	}
}
