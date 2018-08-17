using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using KiSSSvc.BLL;
using KiSSSvc.DAL;
using KiSSSvc.Logging;
using KiSSSvc.SAP.Helpers;
using KiSSSvc.SAP.PSCD.BLL;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.KlientengelderSaldoLesen;

namespace KiSSSvc.SAP.PSCD.InfoFetcher
{
    public class KlientengelderSaldoFetcher
    {
        private MI_KLIENTEN_EINZAHL_KOPFService svc;

        public KlientengelderSaldoFetcher()
        {
            svc = WebServiceSource.GetKlientengelderSaldoHolenWS();
        }

        public void FetchKlientengelderSaldos(bool fetchFromTable)
        {
            try
            {
                _STZH_SOZ_FEBKO[] klientengelderSaldos;

                //Es wird auf eine Leichenverarbeitung verzichtet, der Parameter fetchFromTable ist unnötig!
                //if (fetchFromTable)
                //{
                //Log.Info(this.GetType(), "Hole Daten aus Tabelle PscdKlientengelderSaldoLog...");
                //klientengelderSaldos = GetKlientengelderSaldoArray(PscdKlientengelderSaldoLogBLL.GetAllKlientengelderSaldoLog());
                //Log.Info(this.GetType(), string.Format("{0} Einträge vorhanden", klientengelderSaldos.Length));
                //}
                //else
                //{
                klientengelderSaldos = new _STZH_SOZ_FEBKO[] { };
                Log.Info(this.GetType(), "Rufe MI_KLIENTEN_EINZAHL_KOPF auf...");
                svc.MI_KLIENTEN_EINZAHL_KOPF(ref klientengelderSaldos);
                Log.Info(this.GetType(), string.Format("Habe {0} KlientengelderSaldos erhalten", klientengelderSaldos.Length));
                //}
                KiSSDB.PscdKlientengelderSaldoLogDataTable saldi = new KiSSDB.PscdKlientengelderSaldoLogDataTable();
                int i = 0;
                foreach (_STZH_SOZ_FEBKO saldo in klientengelderSaldos)
                {
                    try
                    {
                        #region Logging

                        i++;
                        if (i < 0)
                        {
                            Log.Info(saldo.GetType(), string.Format("ABSND: {0}", saldo.ABSND));
                            Log.Info(saldo.GetType(), string.Format("AZDAT: {0}", saldo.AZDAT));
                            Log.Info(saldo.GetType(), string.Format("AZIDT: {0}", saldo.AZIDT));
                            Log.Info(saldo.GetType(), string.Format("EDATE: {0}", saldo.EDATE));
                            Log.Info(saldo.GetType(), string.Format("ESBTR: {0}", saldo.ESBTR));
                            Log.Info(saldo.GetType(), string.Format("ESBTRSpecified: {0}", saldo.ESBTRSpecified));
                            Log.Info(saldo.GetType(), string.Format("ESTYP: {0}", saldo.ESTYP));
                            Log.Info(saldo.GetType(), string.Format("ESVOZ: {0}", saldo.ESVOZ));
                            Log.Info(saldo.GetType(), string.Format("ETIME: {0}", saldo.ETIME));
                            Log.Info(saldo.GetType(), string.Format("EUSER: {0}", saldo.EUSER));
                            Log.Info(saldo.GetType(), string.Format("KUKEY: {0}", saldo.KUKEY));
                            Log.Info(saldo.GetType(), string.Format("MANDT: {0}", saldo.MANDT));
                            Log.Info(saldo.GetType(), string.Format("SIBAN: {0}", saldo.SIBAN));
                            Log.Info(saldo.GetType(), string.Format("SSBTR: {0}", saldo.SSBTR));
                            Log.Info(saldo.GetType(), string.Format("SSBTRSpecified: {0}", saldo.SSBTRSpecified));
                            Log.Info(saldo.GetType(), string.Format("SSTYP: {0}", saldo.SSTYP));
                            Log.Info(saldo.GetType(), string.Format("SSVOZ: {0}", saldo.SSVOZ));
                            Log.Info(saldo.GetType(), string.Format("STATUS: {0}", saldo.STATUS));
                            Log.Info(saldo.GetType(), string.Format("SUMHA: {0}", saldo.SUMHA));
                            Log.Info(saldo.GetType(), string.Format("SUMHASpecified: {0}", saldo.SUMHASpecified));
                            Log.Info(saldo.GetType(), string.Format("SUMSO: {0}", saldo.SUMSO));
                            Log.Info(saldo.GetType(), string.Format("SUMSOSpecified: {0}", saldo.SUMSOSpecified));
                            Log.Info(saldo.GetType(), string.Format("WAERS: {0}", saldo.WAERS));
                        }

                        #endregion

                        KiSSDB.PscdKlientengelderSaldoLogRow saldoLog = saldi.NewPscdKlientengelderSaldoLogRow();

                        #region FillFields

                        saldoLog.ABSND = saldo.ABSND;
                        saldoLog.AZDAT = saldo.AZDAT;
                        saldoLog.AZIDT = saldo.AZIDT;
                        saldoLog.EDATE = saldo.EDATE;
                        saldoLog.ESBTR = saldo.ESBTR;
                        saldoLog.ESBTRSpecified = saldo.ESBTRSpecified;
                        saldoLog.ESTYP = saldo.ESTYP;
                        saldoLog.ESVOZ = saldo.ESVOZ;
                        saldoLog.ETIME = saldo.ETIME;
                        saldoLog.EUSER = saldo.EUSER;
                        saldoLog.KUKEY = saldo.KUKEY;
                        saldoLog.MANDT = saldo.MANDT;
                        saldoLog.SIBAN = saldo.SIBAN;
                        saldoLog.SSBTR = saldo.SSBTR;
                        saldoLog.SSBTRSpecified = saldo.SSBTRSpecified;
                        saldoLog.SSTYP = saldo.SSTYP;
                        saldoLog.SSVOZ = saldo.SSVOZ;
                        saldoLog.STATUS = saldo.STATUS;
                        saldoLog.SUMHA = saldo.SUMHA;
                        saldoLog.SUMHASpecified = saldo.SUMHASpecified;
                        saldoLog.SUMSO = saldo.SUMSO;
                        saldoLog.SUMSOSpecified = saldo.SUMSOSpecified;
                        saldoLog.WAERS = saldo.WAERS;
                        saldoLog.ErstelltDatum = DateTime.Now;

                        #endregion

                        string strBaPersonID = "";
                        int count = 0;
                        try
                        {
                            int? baPersonID = KgBuchungBLL.GetBaPersonIDFromZkbKontoNr(saldo.ABSND);

                            if (baPersonID.HasValue)
                            {
                                saldoLog.BaPersonID = baPersonID.Value;
                                strBaPersonID = baPersonID.Value.ToString();
                            }

                            object saldoDatum = SapHelper.ParseDate(saldo.AZDAT);
                            DateTime saldoDatumNotNull = saldoDatum is DateTime ? (DateTime)saldoDatum : DateTime.Now;

                            var startSaldo = saldoLog.SSVOZ == "S" ? -saldoLog.SSBTR : saldoLog.SSBTR; //wenn vorzeichen "S" (statt: "H"), dann ist Saldo negativ!
                            var endSaldo = saldoLog.ESVOZ == "S" ? -saldoLog.ESBTR : saldoLog.ESBTR; //wenn vorzeichen "S" (statt: "H"), dann ist Saldo negativ!

                            SstMT940SaldoBLL.InsertIfNotExists(saldo.ABSND, saldo.AZIDT, baPersonID, saldoDatumNotNull, startSaldo, endSaldo);

                            count = (int)KgKontoBLL.UpdateKgKontoSaldo(endSaldo, saldoDatumNotNull, baPersonID, saldo.ABSND);
                        }
                        catch (Exception ex)
                        {
                            Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                        }

                        saldoLog.Verarbeitet = (count > 0);
                        saldi.AddPscdKlientengelderSaldoLogRow(saldoLog);

                        if (!saldoLog.Verarbeitet)
                            Log.Info(this.GetType(), string.Format("Saldo konnte nicht aktualisiert werden! (BaPersonID:{0}, KontoNr:{1}, Datum:{2})",
                                                                    strBaPersonID, saldoLog.ABSND, saldoLog.AZDAT));

                        //Log.Info(saldo.GetType(), saldoLog.PscdKlientengelderSaldoLogID.ToString());
                    }
                    catch (Exception ex)
                    {
                        Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                    }
                }
                PscdKlientengelderSaldoLogBLL.Update(saldi);
                //TODO: Update BaPersonID und nicht verarbeitete
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
            }
            finally
            {
                Log.Info(this.GetType(), "Aufruf von MI_KLIENTEN_EINZAHL_KOPF beendet");
            }
        }

        //Es wird auf eine Leichenverarbeitung verzichtet, der Parameter fetchFromTable ist unnötig!
        //private _STZH_SOZ_FEBKO[] GetKlientengelderSaldoArray(KiSSDB.PscdKlientengelderSaldoLogDataTable pscdKlientengelderSaldoLogDataTable)
        //{
        //    List<_STZH_SOZ_FEBKO> items = new List<_STZH_SOZ_FEBKO>();

        //    foreach (KiSSDB.PscdKlientengelderSaldoLogRow saldo in pscdKlientengelderSaldoLogDataTable)
        //    {
        //        _STZH_SOZ_FEBKO saldoLog = new _STZH_SOZ_FEBKO();

        //        saldoLog.ABSND = saldo.ABSND;
        //        saldoLog.AZDAT = saldo.AZDAT;
        //        saldoLog.AZIDT = saldo.AZIDT;
        //        saldoLog.EDATE = saldo.EDATE;
        //        saldoLog.ESBTR = saldo.ESBTR;
        //        saldoLog.ESBTRSpecified = saldo.ESBTRSpecified;
        //        saldoLog.ESTYP = saldo.ESTYP;
        //        saldoLog.ESVOZ = saldo.ESVOZ;
        //        saldoLog.ETIME = saldo.ETIME;
        //        saldoLog.EUSER = saldo.EUSER;
        //        saldoLog.KUKEY = saldo.KUKEY;
        //        saldoLog.MANDT = saldo.MANDT;
        //        saldoLog.SIBAN = saldo.SIBAN;
        //        saldoLog.SSBTR = saldo.SSBTR;
        //        saldoLog.SSBTRSpecified = saldo.SSBTRSpecified;
        //        saldoLog.SSTYP = saldo.SSTYP;
        //        saldoLog.SSVOZ = saldo.SSVOZ;
        //        saldoLog.STATUS = saldo.STATUS;
        //        saldoLog.SUMHA = saldo.SUMHA;
        //        saldoLog.SUMHASpecified = saldo.SUMHASpecified;
        //        saldoLog.SUMSO = saldo.SUMSO;
        //        saldoLog.SUMSOSpecified = saldo.SUMSOSpecified;
        //        saldoLog.WAERS = saldo.WAERS;

        //        items.Add(saldoLog);
        //    }
        //    return items.ToArray();
        //}
    }
}