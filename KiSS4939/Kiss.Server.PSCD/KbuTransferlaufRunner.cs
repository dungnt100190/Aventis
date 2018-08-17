using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;
using Kiss.Server.PSCD.Helper;
using Kiss.BL.Kbu.Validation;
using Kiss.Interfaces.IoC;
using Kiss.Interfaces.BL;
using Kiss.BL;
using Kiss.Server.PSCD.WS.PscdWsProxy;
using Kiss.Model;
using Kiss.Infrastructure.Constant;
using Kiss.BL.Kbu;
using Kiss.BL.KissSystem;
using Kiss.BL.Ba;

namespace Kiss.Server.PSCD
{
    internal class KbuTransferlaufRunner : WebServiceBase
    {
        private static volatile KbuTransferlaufRunner _instance;
        public static KbuTransferlaufRunner Instance
        {
            get { return _instance ?? (_instance = new KbuTransferlaufRunner()); }
        }

        private KbuTransferlaufRunner()
        {
            _log.InfoFormat("KbuTransferlaufRunner instanzieren, Serverversion {0}", ServerVersion);

            _backgroundWorker = new System.ComponentModel.BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            _backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            _backgroundWorker.DoWork += backgroundWorker_StartProcess;

            _validator = Container.Resolve<KbuBelegTransferableValidator>();
        }

        public bool IsProcessRunning
        {
            get { return _backgroundWorker.IsBusy; }
        }

        #region Fields

        #region Private Fields

        private readonly KbuBelegTransferableValidator _validator;

        private KbuTransferlaufStateDTO _state;
        private readonly System.ComponentModel.BackgroundWorker _backgroundWorker;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public KissServiceResult CancelTransferlauf(string dbName, SerializableUser authenticatedUser, int kbuTransferlaufID)
        {
            if (_state != null && _state.KbuTransferlaufID != kbuTransferlaufID)
            {
                _log.InfoFormat("Transferlauf abbrechen: Transferlauf {0} soll abgebrochen werden, es läuft aber Transferlauf {1}", kbuTransferlaufID, _state.KbuTransferlaufID);
                return new KissServiceResult(KissServiceResult.ResultType.Error, string.Format("Der laufende Transferlauf hat nicht ID {0}", kbuTransferlaufID));
            }
            if (!IsProcessRunning)
            {
                _log.InfoFormat("Transferlauf abbrechen: Transferlauf {0} soll abgebrochen werden, es läuft aber gar kein Transferlauf", kbuTransferlaufID);
                return new KissServiceResult(KissServiceResult.ResultType.Error, "Transferlauf läuft nicht und kann daher nicht abgebrochen werden");
            }
            _backgroundWorker.CancelAsync();
            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Gibt den Status des aktuell laufenden bzw. des zuletzt gelaufenen Transferlaufs zurück
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="authenticatedUser"></param>
        /// <returns></returns>
        public KbuTransferlaufStateDTO GetTransferlaufProgress(string dbName, SerializableUser authenticatedUser)
        {
            if (_state != null)
            {
                lock (_state)
                {
                    return _state;
                }
            }
            return null;
        }

        public KissServiceResult StartTransferlauf(string dbName, SerializableUser authenticatedUser, int kbuTransferlaufID)
        {
            _log.InfoFormat("KbuTransferlaufRunner.StartTransferlauf aufgerufen, Serverversion {0}", ServerVersion);
            var result = KissServiceResult.Ok();

            try
            {
                if (authenticatedUser == null)
                {
                    result += new KissServiceResult(KissServiceResult.ResultType.Error, "Interner Fehler: Dem Server wurde kein User mitgegeben");
                    _log.Error(result);
                    return result;
                }

                if (IsProcessRunning)
                {
                    result += new KissServiceResult(KissServiceResult.ResultType.Error, "Es läuft bereits ein Transferlauf");
                    _log.Error(result);
                    return result;
                }

                _log.InfoFormat("Start Zahlungseingänge abholen: Client-DB: '{0}', User: '{1}', KbuTransferlaufID '{2}'", dbName, authenticatedUser.UserID, kbuTransferlaufID);

                InitDBConnection(authenticatedUser);

                var session = Container.Resolve<ISessionService>();
                if (dbName == null || session.DatabaseName != dbName)
                {
                    result += new KissServiceResult(KissServiceResult.ResultType.Error, string.Format("Fehler in der Konfiguration: Der Client wurde für die Datenbank '{0}' konfiguriert, der Server für '{1}'", dbName, session.DatabaseName));
                    _log.Error(result);
                    return result;
                }

                var unitOfWork = UnitOfWork.GetNew;
                var transferlaufService = Container.Resolve<KbuTransferlaufService>();
                var transferlauf = transferlaufService.GetById(unitOfWork, kbuTransferlaufID);

                if (transferlauf.KbuTransferlaufStatusCode != (int)LOVsGenerated.KbuTransferlaufStatus.Created)
                {
                    result += new KissServiceResult(KissServiceResult.ResultType.Error, string.Format("Der Transferlauf (ID {0}) ist nicht im Status 'erstellt'", kbuTransferlaufID));
                    _log.Error(result);
                    return result;
                }

                _state = null;

                transferlauf.Start = DateTime.Now;
                transferlauf.KbuTransferlaufStatusCode = (int)LOVsGenerated.KbuTransferlaufStatus.Running;
                transferlaufService.SaveData(unitOfWork, transferlauf);

                _backgroundWorker.RunWorkerAsync(kbuTransferlaufID);
            }
            catch (Exception ex)
            {
                result += new KissServiceResult(ex);

                try
                {
                    var transferlaufService = Container.Resolve<KbuTransferlaufService>();
                    var transferlauf = transferlaufService.GetById(null, kbuTransferlaufID);
                    transferlauf.KbuTransferlaufStatusCode = (int)LOVsGenerated.KbuTransferlaufStatus.Cancelled;
                    transferlauf.Ende = DateTime.Now;
                    transferlaufService.SaveData(null, transferlauf);
                }
                catch (Exception exDB)
                {
                    result += new KissServiceResult(exDB);
                }
                _log.Error(result);
            }

            return result;
        }

        #endregion

        #region Private Static Methods

        private static MI_SD01_CREATE_WSService GetPscdClient()
        {
            return KiSSSvc.SAP.PSCD.WebServiceHelper.Settings.WebServiceSource.GetBelegAnlegenWS();
        }

        #endregion

        #region Private Methods

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            _state = e.UserState as KbuTransferlaufStateDTO;
        }

        private void backgroundWorker_StartProcess(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var worker = (System.ComponentModel.BackgroundWorker)sender;
            var kbuTransferlaufID = (int)e.Argument;

            var workerState = new KbuTransferlaufStateDTO
            {
                StartTime = DateTime.Now,
                KbuTransferlaufID = kbuTransferlaufID,
                Result = KissServiceResult.Ok(),
                CurrentTime = DateTime.Now,
                PercentProgress = 0,
                KbuTransferlaufStatusCode = (int)LOVsGenerated.KbuTransferlaufStatus.Created
            };
            var transferlaufService = Container.Resolve<KbuTransferlaufService>();

            try
            {
                var unitOfWork = UnitOfWork.GetNew;
                var transferlaufBelegService = Container.Resolve<KbuTransferlaufKbuBelegService>();
                var belegService = Container.Resolve<KbuBelegService>();
                var pscdProxy = GetPscdClient();
                var lovService = Container.Resolve<XLovService>();
                var landService = Container.Resolve<BaLandService>();

                var lovBelegKreis = lovService.GetLovCodeByLovName(unitOfWork, "KbuBelegKreis");
                var lovEinzahlungsschein = lovService.GetLovCodeByLovName(unitOfWork, "BgEinzahlungsschein");
                //var lovEinzahlungsschein = lovService.GetLovCodeByLovName(unitOfWork, "BgEinzahlungsschein");
                var transferlauf = transferlaufService.GetById(unitOfWork, kbuTransferlaufID);
                var idList = transferlaufBelegService.GetBelegIDsOfTransferlauf(unitOfWork, kbuTransferlaufID);
                var belege = belegService.GetByIdsForPscdTransfer(unitOfWork, idList);

                var lookupCountry = landService.GetSapCodeByBaLandIDHashtable(unitOfWork);

                workerState.BelegCountTotal = belege.Count();
                workerState.CurrentTime = DateTime.Now;
                workerState.KbuTransferlaufStatusCode = (int)LOVsGenerated.KbuTransferlaufStatus.Running;

                ReportProgress(workerState, worker);

                foreach (var beleg in belege)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    string errorMsg;
                    KissServiceResult validationResult;
                    if (beleg.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Auszahlung || beleg.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Einzahlung)
                    {
                        validationResult = new KissServiceResult(_validator.Validate(beleg));
                    }
                    else
                    {
                        validationResult = new KissServiceResult(KissServiceResult.ResultType.Error, "In der aktuellen Version kann der KSS-Server nur Auszahlungen und Einzahlungen übertragen");
                    }

                    if (!validationResult)
                    {
                        errorMsg = validationResult.ToString();
                    }
                    else
                    {
                        errorMsg = TransferBeleg(beleg, pscdProxy, lovBelegKreis, lookupCountry, lovEinzahlungsschein);
                    }

                    if (errorMsg != null)
                    {
                        workerState.Result += new KissServiceResult(KissServiceResult.ResultType.Error, errorMsg);
                        workerState.BelegCountFehlerhaft++;
                        errorMsg = errorMsg.Substring(0, Math.Min(200, errorMsg.Length));
                    }
                    else
                    {
                        workerState.BelegCountTransferiert++;
                    }

                    // Report für Client
                    ReportProgress(workerState, worker);

                    // Daten in DB ablegen
                    beleg.Fehlermeldung = errorMsg;
                    belegService.SaveData(unitOfWork, beleg);

                    transferlaufBelegService.SaveTransferResult(unitOfWork, kbuTransferlaufID, beleg.KbuBelegID, errorMsg);
                }

                transferlauf.KbuTransferlaufStatusCode = e.Cancel ? (int)LOVsGenerated.KbuTransferlaufStatus.Cancelled
                                                                  : (int)LOVsGenerated.KbuTransferlaufStatus.Done;
                var doneTime = DateTime.Now;
                transferlauf.Ende = doneTime;
                transferlaufService.SaveData(unitOfWork, transferlauf);

                workerState.KbuTransferlaufStatusCode = transferlauf.KbuTransferlaufStatusCode;
                workerState.DoneTime = doneTime;
                ReportProgress(workerState, worker);

                _log.InfoFormat("Transferlauf {0} wurde {1}, {2} von {3} Belegen wurden erfolgreich übertragen", kbuTransferlaufID, e.Cancel ? "abgebrochen" : "durchgeführt", workerState.BelegCountTransferiert, workerState.BelegCountTotal);
            }

            catch (Exception ex)
            {
                workerState.Result += new KissServiceResult(ex);
                var doneTime = DateTime.Now;
                try
                {
                    var transferlauf = transferlaufService.GetById(null, kbuTransferlaufID);
                    transferlauf.KbuTransferlaufStatusCode = (int)LOVsGenerated.KbuTransferlaufStatus.Cancelled;
                    transferlauf.Ende = doneTime;
                    transferlaufService.SaveData(null, transferlauf);
                }
                catch (Exception exDB)
                {
                    workerState.Result += new KissServiceResult(exDB);
                }
                workerState.KbuTransferlaufStatusCode = (int)LOVsGenerated.KbuTransferlaufStatus.Cancelled;
                workerState.DoneTime = doneTime;
                ReportProgress(workerState, worker);
                _log.Error(workerState.Result);
            }

            e.Result = workerState;
        }

        private void ReportProgress(KbuTransferlaufStateDTO workerState, System.ComponentModel.BackgroundWorker worker)
        {
            int percentProgress = 100 * (workerState.BelegCountFehlerhaft + workerState.BelegCountTransferiert) / workerState.BelegCountTotal;
            workerState.PercentProgress = percentProgress;
            workerState.CurrentTime = DateTime.Now;
            worker.ReportProgress(percentProgress, workerState.Clone());
        }

        private string TransferBeleg(KbuBeleg beleg, MI_SD01_CREATE_WSService pscdProxy, List<XLOVCode> lovBelegKreis, IDictionary<int, string> countryLookup, List<XLOVCode> lovEinzahlungsschein)
        {
            string errorMsg = null;
            var belegKreisShortText = lovBelegKreis.Single(code => code.Code == beleg.KbuBelegKreisCode).ShortText;
            var header = new _STZH_SOZ_CD_F2_BAPIDFKKKO
            {
                DOC_NO = beleg.BelegNr.Value.ToString("000000000000"),
                DOC_DATE = PscdHelper.ConvertDate(beleg.BelegDatum),
                DOC_TYPE = belegKreisShortText,
                NET_DATE = PscdHelper.ConvertDate(beleg.ValutaDatum.Value),
                POST_DATE = PscdHelper.ConvertDate(beleg.BelegDatum)
            };

            // Bei Zahlungseingangsverbuchungen: Referenz auf Zahlstapel setzen
            if( beleg.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Einzahlung && 
                beleg.KbuZahlungseingang != null &&
                beleg.KbuZahlungseingang.SstZahlungseingangSingleItem != null)
            {
                header.PAYMENT_LOT = beleg.KbuZahlungseingang.SstZahlungseingangSingleItem.PAYMENT_LOT;
                header.PAYMENT_LOT_POS = beleg.KbuZahlungseingang.SstZahlungseingangSingleItem.PAYMENT_LOT_POS;
            }

            _STZH_SOZ_CD_F2_BAPI_PAYMENT paymentInfo = null;
            bool belegIstAuszahlung = beleg.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Auszahlung;
            if (beleg.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Auszahlung)
            {
                var kreditor = beleg.KbuBelegKreditor.Single();
                var einzahlungsscheinCode = kreditor.BgEinzahlungsscheinCode.Value;
                var einzahlungsscheinShortText = lovEinzahlungsschein.Single(code => code.Code == einzahlungsscheinCode).Value1;

                var refNr = kreditor.ReferenzNummer;
                paymentInfo = new _STZH_SOZ_CD_F2_BAPI_PAYMENT
                {
                    PAYMENT_TYPE = einzahlungsscheinShortText,
                    RECEIVER_BANK_COUNTRY = PscdHelper.GetSapCountryCode(kreditor.BaLandID_Bank, countryLookup),
                    RECEIVER_BANK_KEY = kreditor.BankBCN,
                    RECEIVER_BANK_ACCOUNT = kreditor.BankKontoNr ?? kreditor.PCKontoNr,
                    // ToDo: abhängig von BgEinzahlungsscheinCode
                    RECEIVER_BANK_IBAN = kreditor.IBAN,
                    RECEIVER_NAME1 = kreditor.BeguenstigtName,
                    RECEIVER_NAME2 = kreditor.Beguenstigtname2,
                    RECEIVER_STREET = kreditor.BeguenstigtStrasse,
                    RECEIVER_HOUSE_NO = kreditor.BeguenstigtHausNr,
                    RECEIVER_POST_CODE = kreditor.BeguenstigtPLZ,
                    RECEIVER_CITY = kreditor.BeguenstigtOrt,
                    RECEIVER_COUNTRY = PscdHelper.GetSapCountryCode(kreditor.BaLandID_Beguenstigt, countryLookup) ?? "CH",
                    //ToDo: Nach BaAdresse-Konsolidierung Fallback auf CH entfernen
                    RECEIVER_TXT1 = kreditor.MitteilungZeile1,
                    RECEIVER_TXT2 = kreditor.MitteilungZeile2,
                    RECEIVER_TXT3 = kreditor.MitteilungZeile3
                };

                if (einzahlungsscheinCode == 1) //ESR
                {
                    paymentInfo.RECEIVER_ESR_ACCOUNT = PscdHelper.MakePcNr(kreditor.PCKontoNr);
                    paymentInfo.RECEIVER_ESR_REFERENCE = kreditor.ReferenzNummer;
                    // Prüfziffer
                    paymentInfo.RECEIVER_ESR_CHECKDIGIT = PscdHelper.GetReceiverEsrCheckdigit(refNr);
                }
            }
            var positions = beleg.KbuBelegPosition
                                 .Where(pos => pos.PositionImBeleg > 0)  // Hauptposition bei Auszahlungen ausschliessen (wegen technischer Restriktion im PSCD)
                                 .Select(pos => new _STZH_SOZ_CD_F2_BAPIDFKKOP
                                 {
                                     ITEM = pos.PositionImBeleg.ToString(),
                                     AMOUNT_LOC_CURR = PscdHelper.GetBetragBruttoWithSign(pos),
                                     AMOUNT_LOC_CURRSpecified = true,
                                     COST_CENTER = pos.Kostenstelle,
                                     TRANSACTION_TYPE = PscdHelper.GetTransactionType(pos, beleg),
                                     TEXT = PscdHelper.Truncate(pos.Text, 50),
                                     TRANSACTION_CODE = pos.KbuKonto.KontoNr,
                                     GL_ACCOUNT = PscdHelper.PadZerosLeft(pos.SstPscdBelegPosition.Single().Sachkonto, 10),
                                     ORDER_ID = PscdHelper.PadZerosLeft(pos.SstPscdBelegPosition.Single().Innenauftrag, 12)
                                 }).ToArray();

            BAPIRET2 returnMsg;
            //PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_BUCHSTOFF001", svcBuchungsstoff.Url, belegRow.BelegNr, user);
            try
            {

                var docNrReturn = pscdProxy.MI_SD01_CREATE_WS("KISS", header, paymentInfo, ref positions, out returnMsg);
                long returnNr;
                if (long.TryParse(docNrReturn, out returnNr) && returnNr == beleg.BelegNr.Value &&
                    (returnMsg == null || returnMsg.TYPE != "E"))
                {
                    beleg.TransferDatum = DateTime.Now;
                }
                else
                {
                    errorMsg = returnMsg.MESSAGE;
                }
            }
            catch (SoapException ex)
            {
                //log.StopWatch();
                //Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Anlegen von Bruttobelegen", ex);
                //log.ExceptionMsg = SapHelper.ProcessSoapException(ex);
                errorMsg = PscdHelper.ProcessSoapException(ex);
                //beleg.Fehlermeldung = string.Format(
                //    "Fehlermeldung von PSCD beim Anlegen des Belegs mit ID {0}/BelegNr {1}: {2}", beleg.KbuBelegID, errorMsg);
                _log.Error(errorMsg);
            }
            catch (Exception ex)
            {
                //log.StopWatch();
                //Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Anlegen von Bruttobelegen", ex);
                errorMsg = ex.Message;
                // HTML-Seite 'parsen' um eine anständige Timeout-Fehlermeldung zu erhalten
                if (!string.IsNullOrEmpty(ex.Message) && ex.Message.IndexOf(@"<H2>500 Connection timed out</H2>") > -1)
                {
                    errorMsg = string.Format(
                        "Fehler beim Anlegen des Kombibelegs mit ID {0}: Zwischen XI und PSCD gab es ein Timeout", beleg.KbuBelegID);
                }
                //beleg.Fehlermeldung = string.Format(
                //    "Fehlermeldung von PSCD beim Anlegen des Belegs mit ID {0} / BelegNr {1}: {1}", beleg.KbuBelegID, errorMsg);
                //log.ExceptionMsg = msg;
                _log.Error(errorMsg);
            }
            finally
            {
                //log.WriteToDB();
            }
            return errorMsg;
        }

        #endregion

        #endregion
    }
}
