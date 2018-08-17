using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Collections;
using System.Web;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using KiSSSvc.DAL;
using KiSSSvc.BLL;
using KiSSSvc.Logging;
using System.Xml;

namespace KiSSSvc.SAP.Helpers
{
    public static class SapHelper
    {
        //const string countryLOVName = "BaLand";
        const string countryLOVName_table = "BaLand_table";
        const string languageLOVName = "BaPersonSprache";
        const string prozessCodeLOVName = "FaProzess";
        const string wvCodeLOVName = "BaWVCode";
        const string bankCacheName = "BaBank";
        const string gemeindeCacheName = "BaGemeinde";
        const string einzahlungsscheinCacheName = "BgEinzahlungsschein";
        const string auszahlungsartCacheName = "KbAuszahlungsArt";
        public const int FirstInstitutionID = 500000;

        public static void ClearCache()
        {
            HttpRuntime.Cache.Remove(countryLOVName_table);
            HttpRuntime.Cache.Remove(languageLOVName);
            HttpRuntime.Cache.Remove(prozessCodeLOVName);
            HttpRuntime.Cache.Remove(bankCacheName);
            HttpRuntime.Cache.Remove(gemeindeCacheName);
            HttpRuntime.Cache.Remove(einzahlungsscheinCacheName);
            HttpRuntime.Cache.Remove(auszahlungsartCacheName);
            HttpRuntime.Cache.Remove(wvCodeLOVName);
        }

        /// <summary>
        /// A formatting function to convert a int-based enum to a string.
        /// It checks for the CodeFormat Attribute. 
        /// </summary>
        /// <param name="obj">the enum value to be formatted</param>
        /// <returns></returns>
        public static string EnumToCode(object obj)
        {
            int value = (int)obj;
            Type type = obj.GetType();

            object[] attrs = type.GetCustomAttributes(typeof(CodeFormatTextAttribute), false);
            if (attrs != null && attrs.Length > 0)
            {
                return obj.ToString();
            }
            return EnumToCode(value, type);
        }
        public static string EnumToCode(int value, Type type)
        {
            object[] attrs = type.GetCustomAttributes(typeof(CodeFormatAttribute), false);
            if (attrs != null && attrs.Length > 0)
            {
                return value.ToString(((CodeFormatAttribute)attrs[0]).FormattingString);
            }
            else
            {
                return value.ToString();
            }
        }

        /// <summary>
        /// Convert Sex-Code from KiSS to SAP
        /// </summary>
        /// <param name="kissSex">SexCode in KiSS</param>
        /// <returns>SexCode in SAP</returns>
        public static string ConvertSex(object kissSex)
        {
            int? code = kissSex as int?;
            if (code.HasValue)
            {
                switch (code.Value)
                {
                    // männlich
                    case 1: { return "2"; }

                    // weiblich
                    case 2: { return "1"; }
                }
            }
            return "";
        }

        #region Date

        public static string ConvertDateObject(object date)
        {
            if (date is DateTime)
            {
                return ConvertDate((DateTime)date);
            }
            return null;
        }

        public static string ConvertDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
            //return string.Format("{0}-{1}-{2}", date.Year, date.);
        }

        public static string ConvertDateStartFrom(DateTime date)
        {
            return date.Date.ToString("yyyyMMddHHmmss");
            //return string.Format("{0}-{1}-{2}", date.Year, date.);
        }
        public static string ConvertDateEndAt(DateTime date)
        {
            return date.ToString("yyyyMMdd") + "235959";
            //return string.Format("{0}-{1}-{2}", date.Year, date.);
        }


        public static string ConvertDateToEndObject(object date)
        {
            if (date is DateTime)
            {
                return ConvertDate((DateTime)date);
            }
            else
            {
                return ConvertDate(new DateTime(9999, 12, 31));
            }
        }

        public static object ParseDate(string dateString)
        {
            try
            {
                return DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.CurrentCulture);
            }
            catch
            {
                return System.DBNull.Value;
            }
        }

        #endregion

        #region Numbers

        public static string GetBusinessPartnerNumber(int bpNumber)
        {
            return bpNumber.ToString("0000000000");
        }

        public static string GetContractAccountNumber(int bpNumber)
        {
            return bpNumber.ToString("000000000000");
        }

        public static string GetPsObjectNumber(long vgNumber)
        {
            return vgNumber.ToString("00000000000000000000");
        }

        public static string GetDocumentNumber(long documentNumber)
        {
            return documentNumber.ToString("000000000000");
        }

        public static string GetDocumentNumberInclPosition(long documentNumber, int positionImBeleg)
        {
            return string.Format("{0}{1}", documentNumber.ToString("000000000000"), positionImBeleg.ToString("0000"));
        }

        public static string GetTransactionID(long transactionID)
        {
            return transactionID.ToString("00000000000000000000");
        }

        public static string GetESR(string refNr)
        {
            //return refNr == null ? "" : refNr.PadLeft(27, '0');
            return refNr;
        }

        #endregion

        #region DB Helper

        public static string GetSapCountryCode(object kissCountryCode)
        {
            int? code = kissCountryCode as int?;
            if (code.HasValue)
            {
                IDictionary<int, string> dict = GetHashtableSapCountryFromBaLand();
                string sapCountryCode;
                if (dict.TryGetValue(code.Value, out sapCountryCode))
                    return sapCountryCode;
                return string.Empty;
            }
            return "CH";
        }

        public static string GetSapLanguageCode(object kissLanguageCode)
        {
            int? code = kissLanguageCode as int?;
            if (code.HasValue)
            {
                Hashtable ht = LOV.GetHashtableKissToPscd(languageLOVName);
                return ht[code.Value] as string;
            }
            return null;
        }

        public static string GetWVShortText(object kissWvCode)
        {
            int? code = kissWvCode as int?;
            if (code.HasValue)
            {
                Hashtable ht = LOV.GetHashtableCodeToShortText(wvCodeLOVName);
                return ht[code.Value] as string;
            }
            return null;
        }

        public static string LookupProzessCode(object faProzessCode)
        {
            int? code = faProzessCode as int?;
            if (code.HasValue)
            {
                Hashtable ht = LOV.GetHashtableKissToPscd(prozessCodeLOVName);
                string s = ht[code.Value] as string;
                if (string.IsNullOrEmpty(s))
                    return "WSH1"; // ToDo: Remove
                return s;
            }
            return "WSH1"; // ToDo: Remove
        }

        public static string LookupAuszahlungsArtCode(object kbAuszahlungsartCode)
        {
            int? code = kbAuszahlungsartCode as int?;
            if (code.HasValue)
            {
                Hashtable ht = LOV.GetHashtableKissToPscd(auszahlungsartCacheName);
                string s = ht[code.Value] as string;
                if (!string.IsNullOrEmpty(s))
                    return s;
            }
            return null;
        }

        public static string LookupEinzahlungsscheinCode(object bgEinzahlungsscheinCode)
        {
            int? code = bgEinzahlungsscheinCode as int?;
            if (code.HasValue)
            {
                Hashtable ht = LOV.GetHashtableKissToPscd(einzahlungsscheinCacheName);
                string s = ht[code.Value] as string;
                if (!string.IsNullOrEmpty(s))
                    return s;
            }
            return null;
        }

        public static string GetClearingNrFromBaBankID(object baBankID, out string sapLandCode, bool isPost, string iban)
        {
            sapLandCode = null;
            int? code = baBankID as int?;
            Dictionary<int, Bank> dict = GetHashtableBclFromBankID();
            if (code.HasValue)
            {
                Bank bank;
                if (dict.TryGetValue(code.Value, out bank))
                {
                    sapLandCode = SapHelper.GetSapCountryCode(bank.LandCode);
                    //return string.Format("{0}{1}", bank.ClearingNr, bank.FilialNr.ToString("0000")); // Langer Bankenstamm
                    return bank.ClearingNr; // Kurzer Bankenstamm
                }
            }
            if (isPost)
            {
                sapLandCode = "CH";
                return "9000"; //Post
            }

            iban = RemoveBlanks(iban);

            string bcl = "";
            bcl = (!string.IsNullOrEmpty(iban) && iban.StartsWith("CH") && iban.Length == 21) ? iban.Substring(4, 5) : "";

            if (string.IsNullOrEmpty(bcl))
            {
                foreach (Bank bank in dict.Values)
                {
                    if (bank.ClearingNr == bcl)
                    {
                        sapLandCode = SapHelper.GetSapCountryCode(bank.LandCode);
                        return bank.ClearingNr; // Kurzer Bankenstamm
                    }
                }
            }
            if (!code.HasValue)
                throw new Exception(string.Format("Für den Zahlungsweg wurde keine Bank ausgewählt. Auch für Auslandzahlungen über IBAN muss eine Bank ausgewählt werden."));

            throw new Exception(string.Format("Keine Bank für BaBankID {0} gefunden.", baBankID));
        }


        public static string GetClearingNrFromBaBankID(object baBankID, bool isPost)
        {
            string sapLandCode;
            return GetClearingNrFromBaBankID(baBankID, out sapLandCode, isPost, null);
        }

        struct Bank
        {
            public Bank(string clearingNr, int filialNr, int landCode)
            {
                this.ClearingNr = clearingNr;
                this.FilialNr = filialNr;
                this.LandCode = landCode;
            }
            public string ClearingNr;
            public int FilialNr;
            public int LandCode;
        }

        private static Dictionary<int, Bank> GetHashtableBclFromBankID()
        {
            Dictionary<int, Bank> dict = HttpRuntime.Cache[bankCacheName] as Dictionary<int, Bank>;
            if (dict != null)
                return dict;

            BaBankTableAdapter bankAdapter = new BaBankTableAdapter();
            bankAdapter.InitializeKiSSAdapter(null);

            KiSSDB.BaBankDataTable bankTable = bankAdapter.GetBanks();
            dict = new Dictionary<int, Bank>();
            foreach (KiSSDB.BaBankRow bankRow in bankTable)
            {
                try
                {
                    dict.Add(bankRow.BaBankID, new Bank(bankRow.ClearingNr, bankRow.IsFilialeNrNull() ? 0 : bankRow.FilialeNr, bankRow.LandCode));
                }
                catch { }
            }
            HttpRuntime.Cache.Add(bankCacheName, dict, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0), System.Web.Caching.CacheItemPriority.Normal, null);
            return dict;
        }

        private static IDictionary<int, string> GetHashtableSapCountryFromBaLand()
        {
            IDictionary<int, string> dict = HttpRuntime.Cache[countryLOVName_table] as Dictionary<int, string>;
            if (dict != null)
                return dict;

            BaLandTableAdapter landAdapter = new BaLandTableAdapter();
            landAdapter.InitializeKiSSAdapter(null);

            KiSSDB.BaLandDataTable landTable = landAdapter.GetCountries();
            dict = new Dictionary<int, string>();
            foreach (KiSSDB.BaLandRow landRow in landTable)
            {
                try
                {
                    dict.Add(landRow.BaLandID, landRow.SAPCode);
                }
                catch { }
            }
            HttpRuntime.Cache.Add(countryLOVName_table, dict, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0), System.Web.Caching.CacheItemPriority.Normal, null);
            return dict;
        }

        //private static Dictionary<int, string> GetHashtableGemeinde()
        //{
        //   Dictionary<int, string> dict = HttpRuntime.Cache[gemeindeCacheName] as Dictionary<int, string>;
        //   if (dict != null)
        //      return dict;

        //   BaBankTableAdapter bankAdapter = new BaBankTableAdapter();
        //   bankAdapter.ReplacePwd();

        //   KiSSDB.BaBankDataTable bankTable = bankAdapter.GetBanks();
        //   dict = new Dictionary<int, string>();
        //   foreach (KiSSDB.BaBankRow bankRow in bankTable)
        //   {
        //      try
        //      {
        //         dict.Add(bankRow.BaBankID, new Bank(bankRow.ClearingNr, bankRow.FilialeNr, bankRow.LandCode));
        //      }
        //      catch { }
        //   }
        //   HttpRuntime.Cache.Add(gemeindeCacheName, dict, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0), System.Web.Caching.CacheItemPriority.Normal, null);
        //   Log.Info(typeof(LOV), string.Format("BaBank fetched, {0} rows", dict.Count));
        //   return dict;
        //}

        #endregion

        public static string GetGrouping(int bgBudgetID, bool umbuchung)
        {
            return string.Format("{0}{1}", umbuchung ? "U" : "", bgBudgetID);
        }

        public static bool IsAbgetreten(int hauptvorgang)
        {
            // 4360: abgetreten
            return hauptvorgang >= 4000 && hauptvorgang < 5000;
        }

        public static string GetBudgetID(int bgBudgetID, DateTime budgetDate)
        {
            return string.Format("{0}-{1} {2}", budgetDate.Year, budgetDate.Month.ToString("00"), bgBudgetID);
        }

        public static string GetAbstimmschluessel()
        {
            return "";// string.Format("{0}", DateTime.Now.ToString("dd-MM-yyyy"));
        }


        public static string ConvertZkbKtoNrFromUserToDTA()
        {
            return "";
        }


        public static string RemoveBlanks(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return str.Replace(" ", "");
        }


        public static string GetAuthorizationGroup()
        {
            return "ZSOD";
        }

        public static string GetFehlermeldung(Exception ex)
        {
            return TruncateFehlermeldung(ex.Message);
        }

        /// <summary>
        /// Fügt das aktuelle Datum/Zeit an und reduziert die Fehlermeldung von rechts her auf 500 Zeichen. 
        /// Stellt sicher, dass das Datum links immer sichtbar bleibt
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string TruncateFehlermeldung(string msg)
        {
            if (string.IsNullOrEmpty(msg))
                return null;

            string datum = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + ": ";
            int maxLength = 500 - datum.Length;
            int length = msg.Length;
            // don't ask - somtimes it just throws an exception with the first version...
            try
            {
                return datum + msg.Substring(Math.Max(0, length - maxLength), Math.Min(length, maxLength));
            }
            catch
            {
                return datum + msg.Substring(Math.Max(0, length - maxLength), Math.Min(length, maxLength) - 1);
            }
        }

        public static string ProcessSoapException(System.Web.Services.Protocols.SoapException ex)
        {
            // probieren wir den java-Stacktrace auseinanderzunehmen
            XmlNode textNode = ex.Detail.SelectSingleNode("//text");
            if (textNode != null && textNode.ChildNodes.Count > 0 && textNode.ChildNodes[0].NodeType == XmlNodeType.CDATA)
            {
                string text = textNode.ChildNodes[0].Value;
                if (!string.IsNullOrEmpty(text))
                {
                    if (text.IndexOf("either no channelID specified or no channel found for the specified party, service, and channel name") > -1)
                    {
                        return "Der KiSS-Server hat XI erreicht, XI kann aber nichts mit der URL anfangen. Ist die URL korrekt konfiguriert?";
                    }
                    else if (text.IndexOf("RFC_ERROR_COMMUNICATION: Connect to SAP gateway failed") > -1)
                    {
                        return "XI konnte keine Verbindung zu PSCD aufnehmen (RFC_ERROR_COMMUNICATION: Connect to SAP gateway failed). Versuchen Sie diesen Aufruf später nochmals.";
                    }
                    else if (text.IndexOf("XIServer:CLIENT_RECEIVE_FAILED") > -1)
                    {
                        return "XI meldet einen internen Fehler (CLIENT_RECEIVE_FAILED). Versuchen Sie diesen Aufruf später nochmals.";
                    }
                    else if (text.IndexOf("XIServer:RESOURCE_EXCEPTION") > -1)
                    {
                        return "XI meldet RESOURCE_EXCEPTION! Dies kann zu inkonsistenten Daten zwischen KiSS und PSCD führen.";
                    }
                    else if (text.IndexOf("RFC_ERROR_LOGON_FAILURE: Name oder Kennwort ist nicht korrekt (Wiederholen Sie die Anmeldung)") > -1)
                    {
                        return "XI meldet RFC_ERROR_LOGON_FAILURE. Die in KiSS hinterlegten Angaben für XI-Logon/Passwort stimmen nicht.";
                    }
                    else if (text.IndexOf("XIServer:JCO_SYSTEM_FAILURE") > -1)
                    {
                        return "XI meldet JCO_SYSTEM_FAILURE.";
                    }
                    else if (text.IndexOf("XIAdapterFramework:GENERAL:com.sap.aii.af.ra.ms.api.DeliveryException: Object not found in lookup of RfcAFBean") > -1)
                    {
                        return "XI meldet 'Object not found in lookup of RfcAFBean'.";
                    }
                    else if (text.IndexOf("XIServer:HTTP_RESP_STATUS_CODE_NOT_OK") > -1)
                    {
                        return "XI meldet HTTP_RESP_STATUS_CODE_NOT_OK.";
                    }

                }
            }
            return ex.Message;
        }


        public static string ToUpperCase(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return str.ToUpper();
        }

        public static string Truncate(string str, int length)
        {
            if (string.IsNullOrEmpty(str))
                return null;

            return str.Substring(0, Math.Min(str.Length, length));
        }

        public static string GetKissCallerID()
        {
            return "K00";
        }

        public static string GetKissModulKCallerID()
        {
            return "V00";
        }
    }

}
