using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.Logging;
using System.Data;
using KiSSSvc.SAP.Helpers;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.WvStatusRueckmeldung;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.SAP.PSCD.BLL;
using KiSSSvc.DAL;
using System.Transactions;

namespace KiSSSvc.SAP.PSCD.InfoFetcher
{
	public class WvStatusFetcher
	{
		private MI_WV_FAKTURAService svcWvStatus;

        public WvStatusFetcher()
		{
			svcWvStatus = WebServiceSource.GetWvStatusHolenWS();
		}
		public void FetchWvStatus(bool fetchFromTable)
		{
			try
			{                
				if (fetchFromTable) //Leichen-Behandlung über Tabelle PscdWvStatusLog
				{
                    Ableit_STZH_WV_CHG_STA[] wvStatus;
					Log.Info(this.GetType(), "Hole Daten aus Tabelle PscdWvStatusLog");
                    wvStatus = GetWvStatusArray(PscdWvStatusLogBLL.GetAllWvStatusLog());
                    Log.Info(this.GetType(), string.Format("{0} Einträge vorhanden", wvStatus.Length));

                    foreach (Ableit_STZH_WV_CHG_STA status in wvStatus)
                    {
                        try
                        {
                            long opBelegNr = long.Parse(status.OPBEL);
                            KbWVEinzelpostenBLL.UpdateWvStatus(status.IdPscdWvStatusLogId, opBelegNr, status.WVSTAT, status.FUBANAME, status.TIMESTAMP, status.MANDT, status.OPUPK, status.OPUPW, status.OPUPZ);
                        }
                        catch (Exception ex)
                        {
                            Log.Error(this.GetType(), ex.Message);
                        }
                    }
                
                }
				else //normale Behandlung über Schnittstelle
				{
                    _STZH_WV_CHG_STA[] wvStatus;
                    wvStatus = new _STZH_WV_CHG_STA[] { };
                    Log.Info(this.GetType(), "Rufe MI_WV_FAKTURAService auf...");
                    svcWvStatus.MI_WV_FAKTURA(ref wvStatus);
                    Log.Info(this.GetType(), string.Format("Habe {0} WvStatus erhalten", wvStatus.Length));

                    foreach (_STZH_WV_CHG_STA status in wvStatus)
                    {
                        try
                        {
                            #region debugging
                            //Log.Info(status.GetType(), string.Format("OPBEL: {0}", status.OPBEL));
                            //Log.Info(status.GetType(), string.Format("FUBANAME: {0}", status.FUBANAME));
                            //Log.Info(status.GetType(), string.Format("AUGBL: {0}", status.MANDT));
                            //Log.Info(status.GetType(), string.Format("AUGBT: {0}", status.OPUPK));
                            //Log.Info(status.GetType(), string.Format("AUGDT: {0}", status.OPUPW));
                            //Log.Info(status.GetType(), string.Format("AUGDT: {0}", status.OPUPZ));
                            //Log.Info(status.GetType(), string.Format("AUGRD: {0}", status.STATUS));
                            //Log.Info(status.GetType(), string.Format("EZDAT: {0}", status.TIMESTAMP));
                            //Log.Info(status.GetType(), string.Format("VTREF: {0}", status.WVSTAT));

                            //int tmp;

                            //int? OPUPK = null;
                            //if (int.TryParse(status.OPUPK, out tmp))
                            //    OPUPK = tmp;

                            //int? OPUPW = null;
                            //if (int.TryParse(status.OPUPW, out tmp))
                            //    OPUPW = tmp;

                            //int? OPUPZ = null;
                            //if (int.TryParse(status.OPUPZ, out tmp))
                            //    OPUPZ = tmp;
                            #endregion

                            long opBelegNr = long.Parse(status.OPBEL);
                            KbWVEinzelpostenBLL.UpdateWvStatus(null, opBelegNr, status.WVSTAT, status.FUBANAME, status.TIMESTAMP, status.MANDT, status.OPUPK, status.OPUPW, status.OPUPZ);
                        }
                        catch (Exception ex)
                        {
                            Log.Error(this.GetType(), ex.Message);
                        }
                    }

                }
			}
			catch (Exception ex)
			{
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
			}
			finally
			{
                Log.Info(this.GetType(), "Aufruf von MI_WV_FAKTURAService beendet");
			}
		}


        public partial class Ableit_STZH_WV_CHG_STA : _STZH_WV_CHG_STA
        {
            private int idPscdWvStatusLogId;

            public int IdPscdWvStatusLogId
            {
                get { return idPscdWvStatusLogId; }
                set { idPscdWvStatusLogId = value; }
            }
        }

        private Ableit_STZH_WV_CHG_STA[] GetWvStatusArray(KiSSDB.PscdWvStatusLogDataTable pscdWvStatusLogDataTable)
		{
            List<Ableit_STZH_WV_CHG_STA> items = new List<Ableit_STZH_WV_CHG_STA>();

            foreach (KiSSDB.PscdWvStatusLogRow status in pscdWvStatusLogDataTable)
			{
                Ableit_STZH_WV_CHG_STA item = new Ableit_STZH_WV_CHG_STA();

                item.IdPscdWvStatusLogId = status.PscdWvStatusLogID;
                item.OPBEL = status.OPBEL;
                item.WVSTAT = status.WVSTATUS;
                item.FUBANAME = status.FUBANAME;
                item.TIMESTAMP = status.TIMESTAMP;
                item.MANDT = status.MANDT;
                item.OPUPK = status.OPUPK;
                item.OPUPW = status.OPUPW;
                item.OPUPZ = status.OPUPZ; 

                items.Add(item);            
			}
			return items.ToArray();
		}
	}
}



