using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.Services.Protocols;

using Kiss.BL;
using Kiss.BL.Sst;
using Kiss.Interfaces.BL;
using Container = Kiss.Interfaces.IoC.Container;
using Kiss.Model;
using Kiss.Server.PSCD.Helper;
using Kiss.Server.PSCD.WS.ZahlungseingaengeAbholenProxy;
using System.ServiceModel;


namespace Kiss.Server.PSCD
{
    //http://msdn.microsoft.com/en-us/magazine/cc163412.aspx
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class SstZahlungseingaengeAbholenWebService : WebServiceBase, ISstZahlungseingaengeAbholenWebService
    {
        #region Fields

        #region Private Static Fields

        private static volatile bool _isProcessRunning;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public KissServiceResult ZahlungseingaengeAbholen(string dbName, SerializableUser authenticatedUser, string timestampFrom)
        {
            _log.InfoFormat("SstZahlungseingaengeAbholenWebService.ZahlungseingaengeAbholen aufgerufen, Serverversion {0}", ServerVersion);
            var result = KissServiceResult.Ok();

            try
            {
                // Validation
                if (authenticatedUser == null)
                {
                    result += new KissServiceResult(KissServiceResult.ResultType.Error, "Interner Fehler: Dem Server wurde kein User mitgegeben");
                    _log.Error(result);
                    return result;
                }

                if (_isProcessRunning)
                {
                    result += new KissServiceResult(KissServiceResult.ResultType.Error, "Es läuft bereits ein Abholvorgang");
                    _log.Error(result);
                    return result;
                }

                _log.InfoFormat("Start Zahlungseingänge abholen: Client-DB: '{0}', User: '{1}', Timestamp '{2}'", dbName, authenticatedUser.UserID, timestampFrom);

                _isProcessRunning = true;

                InitDBConnection(authenticatedUser);

                var session = Container.Resolve<ISessionService>();

                if (dbName == null || session.DatabaseName != dbName)
                {
                    result += new KissServiceResult(
                        KissServiceResult.ResultType.Error,
                        string.Format(
                            "Fehler in der Konfiguration: Der Client wurde für die Datenbank '{0}' konfiguriert, der Server für '{1}'",
                            dbName,
                            session.DatabaseName));
                    _log.Error(result);
                    _isProcessRunning = false;
                    return result;
                }

                // Do the work
                result += StartProcess(timestampFrom);
            }
            catch (Exception ex)
            {
                result += new KissServiceResult(ex);
                _log.Error(result);
            }

            _isProcessRunning = false;

            return result;
        }

        #endregion

        #region Private Static Methods

        private static MI_SD02_CREATE_WSService GetPscdClient()
        {
            return KiSSSvc.SAP.PSCD.WebServiceHelper.Settings.WebServiceSource.GetZahlungseingaengeAbholenWS();
        }

        private static KissServiceResult StartProcess(string timestampFrom)
        {
            var result = KissServiceResult.Ok();

            using (var ts = new TransactionScope())
            {
                var unitOfWork = UnitOfWork.GetNew;
                var sstZeLaufService = Container.Resolve<SstZahlungseingangLaufService>();
                var zahlungseingangLauf = new SstZahlungseingangLauf();
                var zahlungseingangListe = new List<SstZahlungseingang>();

                try
                {
                    if (string.IsNullOrWhiteSpace(timestampFrom))
                    {
                        // Letzten erfolgreichen Lauf holen
                        timestampFrom = sstZeLaufService.GetMaxTimestampErhalten(unitOfWork) ?? "20000101000000";                   
                    }

                    // Infos setzen
                    zahlungseingangLauf.Start = DateTime.Now;
                    zahlungseingangLauf.TimestampGesendet = timestampFrom;

                    // Anfrage an PSCD schicken
                    var client = GetPscdClient();
                    var wsResultList = new _STZH_SOZ_PAYLOT_GET[]{};
                    var wsResult = client.MI_SD02_CREATE_WS("KISS", timestampFrom, null, ref wsResultList);

                    // Infos setzen
                    zahlungseingangLauf.Ende = DateTime.Now;
                    if (!string.IsNullOrEmpty(wsResult.MESSAGE_V3))
                    {
                        zahlungseingangLauf.TimestampErhalten = wsResult.MESSAGE_V3;
                    }
                    else
                    {
                        //Leider sendet das PSCD nicht immer einen timestamp erhalten mit. In dem Fall nehmen wir den Timestamp Gesendet.
                        zahlungseingangLauf.TimestampErhalten = zahlungseingangLauf.TimestampGesendet;
                    }
                    _log.InfoFormat("Zahlungseingänge abgeholt: Anzahl {0}, gesendeter Timestamp {1}, erhaltener Timestamp {2}", wsResultList.Length, timestampFrom, zahlungseingangLauf.TimestampErhalten);

                    // Liste von Zahlungseingängen abfüllen
                    zahlungseingangListe.AddRange(
                        wsResultList.Select(
                            eingang => new SstZahlungseingang
                            {
                                AMOUNT_LOC_CURR = eingang.AMOUNT_LOC_CURRSpecified ? (decimal?)eingang.AMOUNT_LOC_CURR : null,
                                BANK_ACCOUNT = eingang.BANK_ACCOUNT,
                                PAY_DATE_ESR = PscdHelper.ConvertDate(eingang.PAY_DATE_ESR),
                                PAYMENT_LOT = eingang.PAYMENT_LOT,
                                PAYMENT_LOT_POS = eingang.PAYMENT_LOT_POS,
                                PAYMENT_TEXT = eingang.PAYMENT_TEXT,
                                POST_DATE = PscdHelper.ConvertDate(eingang.POST_DATE)
                            }));

                    // Bisher alles OK..
                    zahlungseingangLauf.AbholungErfolgreich = true;
                }
                catch (SoapException ex)
                {
                    _log.ErrorFormat("Abholen von Zahlungseingängen: {0}\n{1}", PscdHelper.ProcessSoapException(ex), ex);
                    result += new KissServiceResult(ex);
                }
                catch (Exception ex)
                {
                    _log.ErrorFormat("Abholen von Zahlungseingängen: {0}", ex);

                    // HTML-Seite 'parsen' um eine anständige Timeout-Fehlermeldung zu erhalten
                    if (!string.IsNullOrEmpty(ex.Message) && ex.Message.IndexOf(@"<H2>500 Connection timed out</H2>") > -1)
                    {
                        string errorMsg = string.Format("Fehler beim Abholen der Zahlungseingänge: Zwischen XI und PSCD gab es ein Timeout");
                        _log.Error(errorMsg);
                    }

                    result += new KissServiceResult(ex);
                }

                //Fehlermeldung im Lauf festhalten.
                if (!result.IsOk)
                {
                    zahlungseingangLauf.Meldung = result.ToString();
                }

                //In KiSS-DB speichern
                //Noch hier kommentiert gelassen, falls ZahlungseingangLaufSpeichernUndVerarbeiten nicht funktioniert.
                //Kann man dann entfernen. Diese Methode füllt nur Schnittstellentabellen und überträgt nicht in KbuZahlungseingang.
                //result += sstZeLaufService.SaveZahlungseingangLauf(unitOfWork, zahlungseingangLauf, zahlungseingangListe);

                //Speichern und Übertragen in KbuZahlungseingang
                result += sstZeLaufService.ZahlungseingangLaufSpeichernUndVerarbeiten(unitOfWork, zahlungseingangLauf, zahlungseingangListe);

                ts.Complete();
            }

            if (!result)
            {
                _log.DebugFormat("Abholen von Zahlungseingängen: {0}", result);
            }
            else
            {
                _log.InfoFormat("Zahlungseingänge erfolgreich in KiSS-DB gespeichert");
            }
            return result;
        }

        #endregion

        #endregion
    }
}
