using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.UserSenden;
using KiSSSvc.SAP.PSCD.BLL;
using KiSSSvc.DAL;

namespace KiSSSvc.SAP.PSCD.InfoFetcher
{
	public class UserSenden
	{
		MI_KISS_ANSPER_UPDATEService svc;

		public UserSenden()
		{
			svc = WebServiceSource.GetUserSendenWS();
		}

        public string ConvertToHex(string asciiString)
        {
            if (asciiString == null) { return string.Empty;}
            if (asciiString == string.Empty) { return string.Empty; }
            string hex = "";
            foreach (char c in asciiString)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            return hex;
        } 


		public void SendUsers()
		{
			try
			{
				KiSSDB.vwUserDataTable users = vwUserBLL.GetAnsprechpartner();
				List<_STZH_SOZ_ANSPER> ansprechpartner = new List<_STZH_SOZ_ANSPER>();
				foreach (KiSSDB.vwUserRow user in users)
				{
					_STZH_SOZ_ANSPER item = new _STZH_SOZ_ANSPER();
					item.ANSPART_ID = user.Logon;
					item.EMAIL = user.EMail;
					item.FAX = user.OrgEinheitFax;
					item.KUERZEL = user.ShortName;
					item.VORNAME = user.FirstName;
					item.NACHNAME = user.LastName;
					item.TELEFON = user.Phone;
                    
                    item._STZH_SOZ_QT = user.OrgEinheitName;
                    item._STZH_SOZ_SZ = user.Sozialzentrum;

                    if (user.OrgEinheitAdresseFeld != null)
                    {
                        string[] oeAddresses = user.OrgEinheitAdresseFeld.Split(new string[] { "\n\r", "\n","\r" }, StringSplitOptions.RemoveEmptyEntries);

                        if (oeAddresses.Length > 0) { item._STZH_SOZ_LIN_01 = oeAddresses[0].Trim(); }
                        if (oeAddresses.Length > 1) { item._STZH_SOZ_LIN_02 = oeAddresses[1].Trim(); }
                        if (oeAddresses.Length > 2) { item._STZH_SOZ_LIN_03 = oeAddresses[2].Trim(); }
                        if (oeAddresses.Length > 3) { item._STZH_SOZ_LIN_04 = oeAddresses[3].Trim(); }
                        if (oeAddresses.Length > 4) { item._STZH_SOZ_LIN_05 = oeAddresses[4].Trim(); }
                        if (oeAddresses.Length > 5) { item._STZH_SOZ_LIN_06 = oeAddresses[5].Trim(); }
                        if (oeAddresses.Length > 6) { item._STZH_SOZ_LIN_07 = oeAddresses[6].Trim(); }
                        if (oeAddresses.Length > 7) { item._STZH_SOZ_LIN_08 = oeAddresses[7].Trim(); }
                        if (oeAddresses.Length > 8) { item._STZH_SOZ_LIN_09 = oeAddresses[8].Trim(); }
                        if (oeAddresses.Length > 9) { item._STZH_SOZ_LIN_10 = oeAddresses[9].Trim(); }
                    }
                    
                    #region DEBUGGING
                   /*
                    Logging.Log.Info(typeof(UserSenden), string.Format("/{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}/{8}/{9}/", 
                                                                        item._STZH_SOZ_LIN_01,
                                                                        item._STZH_SOZ_LIN_02,
                                                                        item._STZH_SOZ_LIN_03,
                                                                        item._STZH_SOZ_LIN_04,
                                                                        item._STZH_SOZ_LIN_05,
                                                                        item._STZH_SOZ_LIN_06,
                                                                        item._STZH_SOZ_LIN_07,
                                                                        item._STZH_SOZ_LIN_08,
                                                                        item._STZH_SOZ_LIN_09,
                                                                        item._STZH_SOZ_LIN_10));
                    Logging.Log.Info(typeof(UserSenden), string.Format("/{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}/{8}/{9}/",
                                                                        ConvertToHex(item._STZH_SOZ_LIN_01),
                                                                        ConvertToHex(item._STZH_SOZ_LIN_02),
                                                                        ConvertToHex(item._STZH_SOZ_LIN_03),
                                                                        ConvertToHex(item._STZH_SOZ_LIN_04),
                                                                        ConvertToHex(item._STZH_SOZ_LIN_05),
                                                                        ConvertToHex(item._STZH_SOZ_LIN_06),
                                                                        ConvertToHex(item._STZH_SOZ_LIN_07),
                                                                        ConvertToHex(item._STZH_SOZ_LIN_08),
                                                                        ConvertToHex(item._STZH_SOZ_LIN_09),
                                                                        ConvertToHex(item._STZH_SOZ_LIN_10)));
                     
                    Logging.Log.Info(typeof(UserSenden), item._STZH_SOZ_LIN_02);
                    Logging.Log.Info(typeof(UserSenden), item._STZH_SOZ_LIN_03);
                    Logging.Log.Info(typeof(UserSenden), item._STZH_SOZ_LIN_04);
                    Logging.Log.Info(typeof(UserSenden), item._STZH_SOZ_LIN_05);
                    Logging.Log.Info(typeof(UserSenden), item._STZH_SOZ_LIN_06);
                    Logging.Log.Info(typeof(UserSenden), item._STZH_SOZ_LIN_07);
                    Logging.Log.Info(typeof(UserSenden), item._STZH_SOZ_LIN_08);
                    Logging.Log.Info(typeof(UserSenden), item._STZH_SOZ_LIN_09);
                    Logging.Log.Info(typeof(UserSenden), item._STZH_SOZ_LIN_10);
                    */
                    #endregion

                    ansprechpartner.Add(item);
				}
				_STZH_SOZ_ANSPER[] array = ansprechpartner.ToArray();
				svc.MI_KISS_ANSPER_UPDATE(ref array);
			}
			catch (Exception ex)
			{
				Logging.Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
			}
		}
	}
}
