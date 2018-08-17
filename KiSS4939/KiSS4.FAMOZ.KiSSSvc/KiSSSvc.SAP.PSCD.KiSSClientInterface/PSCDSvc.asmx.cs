using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.SAP.PSCD.BudgetData;
using System.Reflection;

namespace KiSSSvc.SAP.PSCD.KiSSClientInterface
{
    /// <summary>
    /// Summary description for PSCDSvc
    /// </summary>
    [WebService(Namespace = "http://www.born.ch/KiSS/FAMOZ/PSCD/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]

    [ToolboxItem(false)]
    public class PSCDSvc : System.Web.Services.WebService
    {
        #region Stammdaten

        [WebMethod]
        public ReturnMsg CreateAndSubmitBusinessPartnerPersonData(string dbName, int userIDSender, string userWinLogonName, int baPersonID)
        {
            ReturnMsg msg = new ReturnMsg();
            string warningMsg = "";
            try
            {
                Stammdaten svc = new Stammdaten();
                WebServiceHelperMethods.CheckDBName(dbName);
                msg.Result = svc.CreateAndSubmitBusinessPartnerPerson(baPersonID, new UserInfo(userIDSender, userWinLogonName), ref warningMsg);
                if (!string.IsNullOrEmpty(warningMsg))
                    msg.WarningMessage = warningMsg;
            }
            catch (Exception ex)
            {
                msg.Result = CreateObjectResult.ExceptionOccured;
                msg.ExceptionMessage = ex.Message;
            }
            return msg;
        }

        [WebMethod]
        public ReturnMsg CreateAndSubmitBusinessPartnerInstitutionData(string dbName, int userIDSender, string userWinLogonName, int baInstitutionID)
        {
            ReturnMsg msg = new ReturnMsg();
            string warningMsg = "";
            try
            {
                WebServiceHelperMethods.CheckDBName(dbName);
                Stammdaten svc = new Stammdaten();
                msg.Result = svc.CreateAndSubmitBusinessPartnerInstitution(baInstitutionID, new UserInfo(userIDSender, userWinLogonName), ref warningMsg);
                if (!string.IsNullOrEmpty(warningMsg))
                    msg.WarningMessage = warningMsg;
            }
            catch (Exception ex)
            {
                msg.Result = CreateObjectResult.ExceptionOccured;
                msg.ExceptionMessage = ex.Message;
            }
            return msg;
        }

        #endregion

        #region Wh Buchungsstoff

        //[WebMethod(MessageName = "SubmitWhBelegeByIDs_NEW", Description = "mit Buchungsdatum")]
        [WebMethod]
        public ReturnMsg SubmitWhBelegeByIDs2(string dbName, int userIDSender, string userWinLogonName, int[] kbBuchungIDs, int[] kbBuchungBruttoIDs, DateTime valutaDatum)
        {
            ReturnMsg msg = new ReturnMsg();
            try
            {
                WebServiceHelperMethods.CheckDBName(dbName);
                Buchungsstoff svc = new Buchungsstoff();
                string warningMsg = "";
                msg.Result = svc.SubmitWhBelegeByKbBuchungIDs(kbBuchungIDs, kbBuchungBruttoIDs, valutaDatum, new UserInfo(userIDSender, userWinLogonName), ref warningMsg);
                if (!string.IsNullOrEmpty(warningMsg))
                    msg.WarningMessage = warningMsg;
            }
            catch (Exception ex)
            {
                msg.Result = CreateObjectResult.ExceptionOccured;
                msg.ExceptionMessage = ex.Message;
                Logging.Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
            }
            return msg;
        }

        //[WebMethod(MessageName = "SubmitWhBelegeByIDs_OLD", Description = "ohne Buchungsdatum")]
        [WebMethod]
        public ReturnMsg SubmitWhBelegeByIDs(string dbName, int userIDSender, string userWinLogonName, int[] kbBuchungIDs, int[] kbBuchungBruttoIDs)
        {
            return SubmitWhBelegeByIDs2(dbName, userIDSender, userWinLogonName, kbBuchungIDs, kbBuchungBruttoIDs, DateTime.MinValue);
        }


        #region Storno

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="userIDSender"></param>
        /// <param name="userWinLogonName"></param>
        /// <param name="KbBuchungIDs"></param>
        /// <returns></returns>
        [WebMethod]
        public ReturnMsg StornoNettoBelege2(string dbName, int userIDSender, string userWinLogonName, int[] KbBuchungIDs, DateTime stornoDatum)
        {
            ReturnMsg msg = new ReturnMsg();
            try
            {
                WebServiceHelperMethods.CheckDBName(dbName);
                BuchungsstoffStornieren svc = new BuchungsstoffStornieren();
                string warningMsg = "";
                msg.Result = svc.StornoNettoBelegeByIDs(KbBuchungIDs, new UserInfo(userIDSender, userWinLogonName), stornoDatum, ref warningMsg);
                if (!string.IsNullOrEmpty(warningMsg))
                    msg.WarningMessage = warningMsg;
            }
            catch (Exception ex)
            {
                msg.Result = CreateObjectResult.ExceptionOccured;
                msg.ExceptionMessage = ex.Message;
                Logging.Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
            }
            return msg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="userIDSender"></param>
        /// <param name="userWinLogonName"></param>
        /// <param name="KbBuchungIDs"></param>
        /// <param name="test">depreciated: Dieser Parameter wird nicht mehr verwendet, es wird neu innerhalb der Methode zuerst getestet und erst bei Erfolgreichem Test ausgeführt.</param>
        /// <returns></returns>
        [WebMethod]
        public ReturnMsg StornoNettoBelege(string dbName, int userIDSender, string userWinLogonName, int[] KbBuchungIDs, bool test)
        {
            ReturnMsg msg = new ReturnMsg();
            msg.WarningMessage = "StornoBruttoBelege: Diese Methode ist nicht implementiert. Es gibt eine neue Methode StornoNettoBelege2(), ohne Parameter 'bool test', dafür mit 'DateTime stornoDatum'.";
            return msg;

            //ReturnMsg msg = new ReturnMsg();
            //try
            //{
            //    WebServiceHelperMethods.CheckDBName(dbName);
            //    BuchungsstoffStornieren svc = new BuchungsstoffStornieren();
            //    string warningMsg = "";
            //    msg.Result = svc.StornoNettoBelegeByIDs(KbBuchungIDs, new UserInfo(userIDSender, userWinLogonName), ref warningMsg);
            //    if (!string.IsNullOrEmpty(warningMsg))
            //        msg.WarningMessage = warningMsg;
            //}
            //catch (Exception ex)
            //{
            //    msg.Result = CreateObjectResult.ExceptionOccured;
            //    msg.ExceptionMessage = ex.Message;
            //    Logging.Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
            //}
            //return msg;
        }

        [WebMethod]
        public ReturnMsg StornoBruttoBelege(string dbName, int userIDSender, string userWinLogonName, int[] kbBuchungBruttoIDs, bool test, DateTime stornoDatum)
        {
            ReturnMsg msg = new ReturnMsg();
            try
            {
                WebServiceHelperMethods.CheckDBName(dbName);
                BuchungsstoffStornieren svc = new BuchungsstoffStornieren();
                string warningMsg = "";
                msg.Result = svc.StornoBruttoBelegeByIDs(kbBuchungBruttoIDs, new UserInfo(userIDSender, userWinLogonName), test, stornoDatum, ref warningMsg);
                if (!string.IsNullOrEmpty(warningMsg))
                    msg.WarningMessage = warningMsg;
            }
            catch (Exception ex)
            {
                msg.Result = CreateObjectResult.ExceptionOccured;
                msg.ExceptionMessage = ex.Message;
                Logging.Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
            }
            return msg;
        }

        #endregion

        #endregion

        #region Alim Buchungsstoff

        //[WebMethod(MessageName = "SubmitAlimBelegeByIDs_NEW", Description = "mit Buchungsdatum")]
        [WebMethod]
        public ReturnMsg SubmitAlimBelegeByIDs2(string dbName, int userIDSender, string userWinLogonName, int[] kbBuchungIDs, DateTime valutaDatum)
        {
            ReturnMsg msg = new ReturnMsg();
            try
            {
                WebServiceHelperMethods.CheckDBName(dbName);
                Buchungsstoff svc = new Buchungsstoff();
                string warningMsg = "";
                msg.Result = svc.SubmitAlimBelegeByKbBuchungIDs(kbBuchungIDs, valutaDatum, new UserInfo(userIDSender, userWinLogonName), ref warningMsg);
                if (!string.IsNullOrEmpty(warningMsg))
                    msg.WarningMessage = warningMsg;
            }
            catch (Exception ex)
            {
                msg.Result = CreateObjectResult.ExceptionOccured;
                msg.ExceptionMessage = ex.Message;
            }
            return msg;
        }

        //[WebMethod(MessageName = "SubmitAlimBelegeByIDs_OLD", Description = "ohne Buchungsdatum")]
        [WebMethod]
        public ReturnMsg SubmitAlimBelegeByIDs(string dbName, int userIDSender, string userWinLogonName, int[] kbBuchungIDs)
        {
            return SubmitAlimBelegeByIDs2(dbName, userIDSender, userWinLogonName, kbBuchungIDs, DateTime.MinValue);
        }

        #endregion

        #region Kg Buchungsstoff

        [WebMethod]
        public ReturnMsg SubmitKgBelege(string dbName, int userIDSender, string userWinLogonName, int[] kgBuchungIDs)
        {
            ReturnMsg msg = new ReturnMsg();
            try
            {
                WebServiceHelperMethods.CheckDBName(dbName);
                Buchungsstoff svc = new Buchungsstoff();
                string warningMsg = "";
                msg.Result = svc.SubmitKgBelege(kgBuchungIDs, new UserInfo(userIDSender, userWinLogonName), ref warningMsg);
                if (!string.IsNullOrEmpty(warningMsg))
                    msg.WarningMessage = warningMsg;
            }
            catch (Exception ex)
            {
                msg.Result = CreateObjectResult.ExceptionOccured;
                msg.ExceptionMessage = ex.Message;
            }
            return msg;
        }

        [WebMethod]
        public ReturnMsg StornoKgBelege(string dbName, int userIDSender, string userWinLogonName, int[] kgBuchungIDs, bool test)
        {
            ReturnMsg msg = new ReturnMsg();
            try
            {
                WebServiceHelperMethods.CheckDBName(dbName);
                BuchungsstoffStornieren svc = new BuchungsstoffStornieren();
                msg.Result = svc.StornoKgBelege(kgBuchungIDs, new UserInfo(userIDSender, userWinLogonName), test);
            }
            catch (Exception ex)
            {
                msg.Result = CreateObjectResult.ExceptionOccured;
                msg.ExceptionMessage = ex.Message;
            }
            return msg;
        }

        #endregion

        #region Weiterverrechnung

        [WebMethod]
        public ReturnMsg SubmitWVEinzelpostenByIDs(string dbName, int userIDSender, string userWinLogonName, int[] kbWVEinzelpostenIDs)
        {
            ReturnMsg msg = new ReturnMsg();
            try
            {
                WebServiceHelperMethods.CheckDBName(dbName);
                Buchungsstoff svc = new Buchungsstoff();
                string warningMsg = "";
                msg.Result = svc.SubmitWVEinzelpostenByIDs(kbWVEinzelpostenIDs, new UserInfo(userIDSender, userWinLogonName), ref warningMsg);
                if (!string.IsNullOrEmpty(warningMsg))
                    msg.WarningMessage = warningMsg;
            }
            catch (Exception ex)
            {
                msg.Result = CreateObjectResult.ExceptionOccured;
                msg.ExceptionMessage = ex.Message;
                Logging.Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
            }
            return msg;
        }
        #endregion

        [WebMethod]
        public void ClearCache()
        {
            WebServiceHelperMethods.ResetSettings();
            KiSSSvc.SAP.Helpers.SapHelper.ClearCache();
        }

        [WebMethod]
        public string GetServerVersion()
        {
            // Returns a String like "2.24.3902.29937, DB SOZM9500\SOZ_KISS_D\KiSS4_MASTER_ZH"
            string version = string.Format("{0} , DB {1}\\{2}", Assembly.GetExecutingAssembly().GetName().Version.ToString(), KiSSSvc.DAL.KiSSDB.GetDBServerName(), KiSSSvc.DAL.KiSSDB.GetDBName());
            return version;
        }


        // NEVER publish this!!!!!!!!!
        //[WebMethod]
        //public string dcr(string str)
        //{
        //    KiSSSvc.DAL.Scrambler sc = new KiSSSvc.DAL.Scrambler("KiSS4");
        //    return sc.DecryptString(str);
        //}


        [WebMethod]
        public ReturnMsg TestFamoz2Beleg(string dbName, int userIDSender, string userWinLogonName, int kgBuchungID, bool withTimeout)
        {
            ReturnMsg msg = new ReturnMsg();
            try
            {
                WebServiceHelperMethods.CheckDBName(dbName);
                KiSSSvc.SAP.PSCD.BudgetData.FAMOZ.BuchungsstoffTest svc = new KiSSSvc.SAP.PSCD.BudgetData.FAMOZ.BuchungsstoffTest();
                string warningMsg = "";
                msg.Result = svc.SubmitKgBelege(new int[] { kgBuchungID }, new UserInfo(userIDSender, userWinLogonName), ref warningMsg, withTimeout);
                if (!string.IsNullOrEmpty(warningMsg))
                    msg.WarningMessage = warningMsg;
            }
            catch (Exception ex)
            {
                msg.Result = CreateObjectResult.ExceptionOccured;
                msg.ExceptionMessage = ex.Message;
            }
            return msg;
        }

        [WebMethod]
        public ReturnMsg TestFamoz2Belege(string dbName, int userIDSender, string userWinLogonName, int anzahlBuchungen, bool withTimeout)
        {
            ReturnMsg msg = new ReturnMsg();
            try
            {
                WebServiceHelperMethods.CheckDBName(dbName);
                KiSSSvc.SAP.PSCD.BudgetData.FAMOZ.BuchungsstoffTest svc = new KiSSSvc.SAP.PSCD.BudgetData.FAMOZ.BuchungsstoffTest();
                string warningMsg = "";
                msg.Result = svc.SubmitKgBelege(anzahlBuchungen, new UserInfo(userIDSender, userWinLogonName), ref warningMsg, withTimeout);
                if (!string.IsNullOrEmpty(warningMsg))
                    msg.WarningMessage = warningMsg;
            }
            catch (Exception ex)
            {
                msg.Result = CreateObjectResult.ExceptionOccured;
                msg.ExceptionMessage = ex.Message;
            }
            return msg;
        }

    }
}
