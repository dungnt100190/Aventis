using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

using Kiss.BL.Kbu;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Sst
{
    /// <summary>
    /// Service to manage a SstZahlungseingangLauf.
    /// </summary>
    public class SstZahlungseingangLaufService : ServiceCRUDBase<SstZahlungseingangLauf>
    {
        #region Constructors

        private SstZahlungseingangLaufService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Holt einen Zahlungseingang-Lauf mittels ID.
        /// Die zugehörigen Zahlungseingänge werden auch zurückgeliefert.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public override SstZahlungseingangLauf GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var repository = UnitOfWork.GetRepository<SstZahlungseingangLauf>(unitOfWork);

            var result = repository.Include(x => x.SstZahlungseingang).SingleOrDefault(x => x.SstZahlungseingangLaufID == id);

            if (result == null)
            {
                throw new EntityNotFoundException("No entity of type 'SstZahlungseingangLauf' found with id: " + id);
            }

            SetEntityValidator(result);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return result;
        }

        /// <summary>
        /// Gibt den letzten erfolgreichen ZahlungseingangLauf zurück.
        /// Wenn es keinen gibt, null.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public SstZahlungseingangLauf GetLastValid(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var repository = UnitOfWork.GetRepository<SstZahlungseingangLauf>(unitOfWork);

            var result = repository
                .OrderByDescending(x => x.SstZahlungseingangLaufID)
                .FirstOrDefault(x => x.AbholungErfolgreich);

            return result;
        }

        /// <summary>
        /// Holt grösster Wert im Feld TimestampErhalten der Entität SstZahlungseingangLauf.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public string GetMaxTimestampErhalten(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<SstZahlungseingangLauf>(unitOfWork);

            var result = repository.Max(x => x.TimestampErhalten);
            return result;
        }

        /// <summary>
        /// Erstellt einen Zahlungseingang-Lauf bestehend aus den mitgegebenen Zahlungseingängen.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="lauf"></param>
        /// <param name="zahlungseingangListe"></param>
        /// <returns></returns>
        public KissServiceResult SaveZahlungseingangLauf(
            IUnitOfWork unitOfWork,
            SstZahlungseingangLauf lauf,
            List<SstZahlungseingang> zahlungseingangListe)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var result = KissServiceResult.Ok();

            var zahlungseingangService = Container.Resolve<SstZahlungseingangService>();

            using (var ts = new TransactionScope())
            {
                InitData(lauf);

                // Datensatz anlegen
                result += SaveData(unitOfWork, lauf);

                // Bereits erhaltene Datensätze entfernen.
                BereitsAbgeholtePositionenEntfernen(unitOfWork, zahlungseingangListe, lauf);

                if (!result)
                {
                    return result;
                }

                // Einträge speichern, falls Abholung OK
                if (lauf.AbholungErfolgreich)
                {
                    foreach (var zahlungseingang in zahlungseingangListe)
                    {
                        // Set CCMM
                        zahlungseingangService.SetCreator(zahlungseingang);
                        zahlungseingangService.SetModifier(zahlungseingang);

                        // Set ZahlungseingangLauf
                        zahlungseingang.SstZahlungseingangLauf = lauf;

                        try
                        {
                            // Save
                            result = zahlungseingangService.SaveData(unitOfWork, zahlungseingang);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("UK_SstZahlungseingang_PAYMENT_LOT_PAYMENT_LOT_POS"))
                            {
                                result += new KissServiceResult(
                                    KissServiceResult.ResultType.Error,
                                    "SstZahlungseingangLaufService_BereitsImportiert",
                                    "Zahlungseingang wurde bereits importiert: Zahlstapel: {0}, Position: {1}",
                                    zahlungseingang.PAYMENT_LOT,
                                    zahlungseingang.PAYMENT_LOT_POS);

                            }
                            result += new KissServiceResult(ex);

                            //Exception wird protokolliert.
                            lauf.EinfuegenErfolgreich = false;
                            if(lauf.MeldungEinfuegen.Length > 0)
                            {
                                lauf.MeldungEinfuegen = lauf.MeldungEinfuegen + " " + ex.Message;
                            }
                            lauf.MeldungEinfuegen = ex.Message;
                            break;
                        }

                        if (!result)
                        {
                            break;
                        }
                    }
                }

                SaveData(unitOfWork, lauf);

                ts.Complete();
            }

            return result;
        }

        /// <summary>
        /// Überträgt die Daten von den Schnittstellen-Tabellen in KbuZahlungseingang.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="sstZahlungseinganLaufID"></param>
        /// <returns></returns>
        public KissServiceResult TransferZahlungseingaengeToKiss(IUnitOfWork unitOfWork, int sstZahlungseinganLaufID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            //Suchen nach den Zahlungseingängen in den Schnittstellentabelle, welche noch nicht
            //in die KiSS Tabellen übertragen worden sind.
            var repositorySstZahlungseingang = UnitOfWork.GetRepository<SstZahlungseingang>(unitOfWork);
            var query = from x in repositorySstZahlungseingang
                        where x.SstZahlungseingangLaufID == sstZahlungseinganLaufID
                        where x.KbuZahlungseingangID == null
                        select x;

            //Über die Zahlungseingänge aus Schnittstellentabelle iterieren.
            foreach (var sstZahlungseingang in query.ToList())
            {
                TransferZahlungseingangToKiss(unitOfWork, sstZahlungseingang);
            }

            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Speichert die vom PSCD erhaltene Liste von Zahlungseingänge in die 
        /// Schnittstellentabellen und Überträgt die Daten im Anschluss
        /// in die KbuZahlungseingang Tabelle.        
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="lauf"></param>
        /// <param name="zahlungseingangListe"></param>
        /// <returns></returns>
        public KissServiceResult ZahlungseingangLaufSpeichernUndVerarbeiten(
            IUnitOfWork unitOfWork,
            SstZahlungseingangLauf lauf,
            List<SstZahlungseingang> zahlungseingangListe)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            KissServiceResult result = SaveZahlungseingangLauf(unitOfWork, lauf, zahlungseingangListe);

            result += TransferZahlungseingaengeToKiss(unitOfWork, lauf.SstZahlungseingangLaufID);

            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Entfernt bereits abgeholte Positionen (zahlungseingangListe).
        /// In der Eigenschaft "Meldung" der Entität SstZahlungseingangLauf 
        /// wird festgehalten, um welche Positionen es sich handelt.
        /// 
        /// Eine Position wird durch PAYMENT_LOT und PAYMENT_LOT_POS identifiziert,
        /// ob sie schon abgeholt wurde.       
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="zahlungseingangListe"></param>
        /// <param name="zahlungseingangLauf"></param>
        private void BereitsAbgeholtePositionenEntfernen(IUnitOfWork unitOfWork, List<SstZahlungseingang> zahlungseingangListe, SstZahlungseingangLauf zahlungseingangLauf)
        {
            //Liste von den in der Liste (erhalten vom PSCD) vorhandenen Zahlstapel erstellen
            //Ein Zahlstapel wird durch PAYMENT_LOT identifiziert.
            //In der Regel sollte es 1 Eintrag in diese Liste geben.
            HashSet<String> zahlStapelList = new HashSet<string>();
            foreach (var sstZahlungseingang in zahlungseingangListe)
            {
                zahlStapelList.Add(sstZahlungseingang.PAYMENT_LOT);
            }

            //Holen aller Positionen in dem Zahlstapel (oder den Zahlstapel), die wir bereits abgeholt haben.
            var repositoryZahlungseingang = UnitOfWork.GetRepository<SstZahlungseingang>(unitOfWork);
            var listOnDB = from x in repositoryZahlungseingang
                           where zahlStapelList.Contains(x.PAYMENT_LOT)
                           select new ZahllaufPosKey
                           {
                             PAYMENT_LOT = x.PAYMENT_LOT,
                             PAYMENT_LOT_POS = x.PAYMENT_LOT_POS
                           };

            HashSet<ZahllaufPosKey> keyListOnDB =  new HashSet<ZahllaufPosKey>(listOnDB.ToList());

            StringBuilder sb = new StringBuilder();

            //Über die vom PSCD erhaltene Liste iterieren und Positionen entfernen,
            //welche wir bereits erhalten haben.
            foreach (var sstZahlungseingang in zahlungseingangListe.ToList())
            {
                ZahllaufPosKey key = new ZahllaufPosKey{
                    PAYMENT_LOT = sstZahlungseingang.PAYMENT_LOT,
                    PAYMENT_LOT_POS = sstZahlungseingang.PAYMENT_LOT_POS,
                };

                if(keyListOnDB.Contains(key))
                {
                    //Eintrag entfernen, da er schon auf der Datenbank ist (gleicher Zahlstapel und Position in Zahlstapel).
                    zahlungseingangListe.Remove(sstZahlungseingang);
                    sb.Append(string.Format("PAYMENT_LOT: {0}, PAYMENT_LOT_POS: {1}; ", key.PAYMENT_LOT, key.PAYMENT_LOT_POS));
                }
            }

            //MeldungEinfügen, wenn ein Datensatz nicht eingefügt werden konnte.
            if (sb.Length > 0)
            {
                zahlungseingangLauf.MeldungEinfuegen = "Zahlstapel-Positionen, die bereits abgeholt wurden: " + sb;
                zahlungseingangLauf.EinfuegenErfolgreich = false;
            }
        }

        /// <summary>
        /// Transferiert einen einzelnen Zahlungseingang von den Schnittstellentabellen in KbuZahlungseingang.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="sstZahlungseingang"></param>
        private void TransferZahlungseingangToKiss(IUnitOfWork unitOfWork, SstZahlungseingang sstZahlungseingang)
        {
            //Eventuell TransactionscopeOption = RequiresNew verwenden.
            using (var ts = new TransactionScope())
            {

                //1. Eintrag erstellen
                KbuZahlungseingangService service = Container.Resolve<KbuZahlungseingangService>();

                KbuZahlungseingang zahlungseingang;
                service.NewData(out zahlungseingang);

                //BaPersonDebitor,   wird später in der Maske Zahlungseingangs-Verarbeitung gesetzt.
                //BaInstitutionID,   wird später in der Maske Zahlungseingangs-Verarbeitung gesetzt.
                //Nicht nötig, aber besser für das Verständnis.
                zahlungseingang.BaPersonDebitor = null;
                zahlungseingang.BaPersonID_Debitor = null;

                zahlungseingang.BaInstitutionDebitor = null;
                zahlungseingang.BaInstitutionID_Debitor = null;

                //KbuKontoID, mit Alex Stratz Regelwerk ausarbeiten. Eventuell von BANK_ACCOUNT und Prefix von PAYMENT_LOT

                //DatumZahlungseingang,  POSTDATE
                zahlungseingang.DatumZahlungseingang = sstZahlungseingang.POST_DATE;

                //Betrag, AMOUNT_LOC_CURR
                zahlungseingang.Betrag = sstZahlungseingang.AMOUNT_LOC_CURR;

                //KbuZahlungseingangTeamCode, leer lassen
                zahlungseingang.KbuZahlungseingangTeamCode = null;

                //Mitteilung, PAYMENT_TEXT
                zahlungseingang.Mitteilung = sstZahlungseingang.PAYMENT_TEXT;

                //Ausgeglichen, wird hier immer auf false. Wird später berechnet.
                zahlungseingang.Ausgeglichen = false;

                //Datensatzanlegen, wenn möglich. Sonst Validierungsfehler abspeichern.
                KissServiceResult result = service.SaveData(unitOfWork, zahlungseingang);
                if (!result.IsOk)
                {
                    string message = result.ToString();
                    if (message.Length > 1000)
                    {
                        message = message.Substring(1, 1000);
                    }
                    sstZahlungseingang.ValidierungsFehler = message;
                }

                //2. Sst Eintrag updaten
                sstZahlungseingang.KbuZahlungseingangID = zahlungseingang.KbuZahlungseingangID;

                SstZahlungseingangService zahlungseingangService = Container.Resolve<SstZahlungseingangService>();
                zahlungseingangService.SaveData(unitOfWork, sstZahlungseingang);

                ts.Complete();
            }
        }

        #endregion

        #endregion
    }
}