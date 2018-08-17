using System;
using System.ComponentModel;
using System.Reflection;
using System.Web.Services;
using KiSSSvc.Logging;
using KiSSSvc.SAP.PSCD.WebServiceHelper;

namespace KiSSSvc.WorkerProcess.KiSSClientInterfaceAsync
{
    /// <summary>
    /// Worker Process: Service for runnning asynchronous background Jobs.
    /// </summary>
    [WebService(Namespace = "http://www.bedag.ch/KiSS/FAMOZ/WorkerProcess/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class WorkerProcessSvc : WebService
    {
        [WebMethod]
        public string GetServerVersion()
        {
            Log.Init();
            Log.Info(MethodBase.GetCurrentMethod().ReflectedType, "WorkerProcessSvc.GetServerVersion wurde aufgerufen");

            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        #region IK-Auszug

        [WebMethod]
        public string IKAuszuegeGenerieren(string dbName, int userIDSender, string userWinLogonName)
        {
            try
            {
                Log.Init();
                Log.Info(MethodBase.GetCurrentMethod().ReflectedType, string.Format("WorkerProcessSvc.IKAuszuegeGenerieren wurde aufgerufen von {0} (UserID {1}) für DB {2}", userWinLogonName, userIDSender, dbName));
                WebServiceHelperMethods.CheckDBName(dbName);
                return SVA.IKAuszugHelper.GenerateIKAuszuege();
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return ex.ToString();
            }
        }

        #endregion

        #region ZKBDokumenteImportieren

        [WebMethod]
        public string ZKBDokumenteImportieren(string dbName, int userIDSender, string userWinLogonName, int? minSize = null)
        {
            try
            {
                Log.Init();
                Log.Info(MethodBase.GetCurrentMethod().ReflectedType, string.Format("WorkerProcessSvc.ZKBDokumenteImportieren wurde aufgerufen von {0} (UserID {1}) für DB {2}", userWinLogonName, userIDSender, dbName));

                WebServiceHelperMethods.CheckDBName(dbName);

                return ZKBDokumente.ZKBDokumente.ImportiereZKBDokumente(minSize);
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return ex.ToString();
            }
        }

        #endregion
    }
}