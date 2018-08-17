using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

using Kiss.BL.Ba;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO;
using Kiss.Model.DTO.Kbu;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Kbu
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class KbuBelegVerbuchungService : ServiceBase
    {
        #region Constructors

        private KbuBelegVerbuchungService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Verbucht die Belege.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="listeBelegIds"></param>
        /// <param name="valutaDatum"></param>
        /// <param name="progress">Hier wird der Fortschirt hineingeschrieben. Kann nicht null sein.</param>
        /// <returns></returns>
        public KissServiceResult BelegeVerbuchen(IUnitOfWork unitOfWork, IList<int> listeBelegIds, DateTime valutaDatum, ref VerarbeitungsProgressDTO progress)
        {
            //Selektion ist leer.
            if (listeBelegIds.Count == 0)
            {
                return KissServiceResult.Error(new Exception("Die Selektion ist leer."));
            }

            //Prüfung Datum.
            if (valutaDatum < DateTime.Today.AddDays(1) || valutaDatum.DayOfWeek == DayOfWeek.Saturday || valutaDatum.DayOfWeek == DayOfWeek.Sunday)
            {
                return KissServiceResult.Error(new Exception("Das Valutadatum darf nicht kleiner als das morgige Datum und darf kein Samstag oder Sonntag sein."));
            }

            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            //Progress initialisieren.
            progress.NumTotal = listeBelegIds.Count;
            progress.NumHandled = 0;
            progress.NumErrors = 0;

            //Über alle Belege iterieren.
            foreach (int belegId in listeBelegIds)
            {
                try
                {
                    if (BelegVerbuchen(unitOfWork, belegId, valutaDatum) == false)
                    {
                        progress.NumErrors++;
                    }
                    progress.NumHandled++;
                }
                catch (Exception ex)
                {
                    progress.NumHandled = progress.NumTotal;
                    return KissServiceResult.Error(ex);
                }

            }

            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Verbucht die Belege.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="listeBelegIds"></param>
        /// <param name="valutaDatum"></param>
        /// <returns></returns>
        public KissServiceResult BelegeVerbuchen(IUnitOfWork unitOfWork, IList<int> listeBelegIds, DateTime valutaDatum)
        {
            VerarbeitungsProgressDTO progressDTO = new VerarbeitungsProgressDTO();
            return BelegeVerbuchen(unitOfWork, listeBelegIds, valutaDatum, ref progressDTO);
        }

        /// <summary>
        /// Holt alle freigegebenen Belege, die das ValutaDatum vor dem Suchdatum haben.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="datumSuchen"></param>
        /// <param name="showOnlyErrors">True wenn nur Belege mit Fehlern angezeigt werden sollen</param>
        /// <returns></returns>
        public List<KbuBelegLaufDTO> GetFreigegebeneBelege(IUnitOfWork unitOfWork, DateTime datumSuchen, bool showOnlyErrors)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repositoryBeleg = UnitOfWork.GetRepository<KbuBeleg>(unitOfWork);
            DateTime? today = DateTime.Today;
            int kbuBelegStatusFreigegeben = (int)LOVsGenerated.KbuBelegstatus.Freigegeben;

            var belege = from kbuBeleg in repositoryBeleg
                         where kbuBeleg.KbuBelegstatusCode == kbuBelegStatusFreigegeben &&
                               kbuBeleg.ValutaDatum.HasValue &&
                               kbuBeleg.ValutaDatum.Value <= datumSuchen.Date &&
                               (kbuBeleg.Fehlermeldung != null || !showOnlyErrors)
                         let erstePosition = kbuBeleg.KbuBelegPosition.Where(pos => pos.HauptPosition == false).FirstOrDefault() //Fir Sprint 6 zeigen wir die Infos von der 1. Belegposition.
                         let wshPosition = erstePosition.WshPosition
                         let leistungErstePosition = erstePosition != null ? erstePosition.FaLeistung : null
                         let personErstePosition = leistungErstePosition != null ? leistungErstePosition.BaPerson : null
                         where (kbuBeleg.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Auszahlung && wshPosition.KbuAuszahlungArtCode == (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung ||
                                kbuBeleg.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Einzahlung)
                         select new KbuBelegLaufDTO
                         {
                             KbuBelegID = kbuBeleg.KbuBelegID,
                             ValutaDatum = kbuBeleg.ValutaDatum,
                             Betrag = kbuBeleg.KbuBelegPosition.Where(x => x.HauptPosition == true).FirstOrDefault().BetragBrutto,
                             Selected = true,
                             Text = kbuBeleg.Text,
                             ErrorMessage = string.IsNullOrEmpty(kbuBeleg.Fehlermeldung) ? "" : kbuBeleg.Fehlermeldung,
                             FaFallID = leistungErstePosition != null ? leistungErstePosition.FaFallID : 0,
                             Klient = personErstePosition != null ? personErstePosition.Name : ""
                         };

            var belegList = belege.ToList();

            return belegList;
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Konvertiert das KissServiceResult zu einem String.
        /// Nur sinnvoll für Validierungsfehler.
        /// Trimmt auf 200 Zeichen (Länge des DB VARCHAR Feldes).
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static string ConvertKissServiceResultToString(KissServiceResult result)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var entry in result.KissServiceResultEntries)
            {
                sb.Append(entry.Message);
                sb.Append(" ");
            }

            if (sb.Length >= 200)
            {
                return sb.ToString(0, 200);
            }
            return sb.ToString();
        }

        private static BaBank GetPostfinance(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<BaBank>(unitOfWork);

            var postfinance = repository
                              .First(bank => bank.ClearingNr == "9000");

            return postfinance;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Verbucht ein Beleg.
        /// </summary>       
        private bool BelegVerbuchen(IUnitOfWork unitOfWork, int belegId, DateTime valutaDatum)
        {
            var servBeleg = Container.Resolve<KbuBelegService>();
            var servBelegKreis = Container.Resolve<KbuBelegKreisService>();
            var verbuchenPlugin = Container.TryResolve<IKbuBelegVerbuchenPlugin>();

            using (TransactionScope ts = new TransactionScope())
            {
                KbuBeleg beleg = servBeleg.GetById(unitOfWork, belegId);

                //Beleg validieren
                KissServiceResult result = ValidateBeleg(unitOfWork, beleg, valutaDatum);
                if (verbuchenPlugin != null)
                {
                    result += verbuchenPlugin.ValidateBeleg(unitOfWork, beleg, valutaDatum);
                }

                //Validierung ist OK
                if (result.IsOk)
                {
                    //Status auf verbucht setzen.
                    beleg.KbuBelegstatusCode = (int)LOVsGenerated.KbuBelegstatus.Verbucht;

                    //Zahlungsinformationen kopieren.
                    if (beleg.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Auszahlung)
                    {
                        CopyZahlungsdatenIntoKreditor(unitOfWork, beleg, valutaDatum);
                    }
                    else if (beleg.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Einzahlung)
                    {
                        CopyEinzahlerdatenIntoDebitor(unitOfWork, beleg, valutaDatum);
                    }

                    //ValutaDatum wird überschrieben mit effektiven Valudatatum.
                    beleg.ValutaDatum = valutaDatum;

                    //Fehlermeldung auf null setzen.
                    beleg.Fehlermeldung = null;

                    //z.B. zusätzliche Infos für externe Systeme anreichern
                    if (verbuchenPlugin != null)
                    {
                        verbuchenPlugin.VerbucheBeleg(unitOfWork, beleg, valutaDatum);
                    }

                    //BelegkreisCode bestimmen
                    var belegKreisCode = MapToBelegKreis(beleg.KbuBelegartCode);
                    beleg.KbuBelegKreisCode = (int)belegKreisCode;

                    //BelegNummernLösen
                    beleg.BelegNr = servBelegKreis.GetNextSequence(unitOfWork, belegKreisCode, 1);
                }

                //Validierung ist NOK.
                else
                {
                    beleg.Fehlermeldung = ConvertKissServiceResultToString(result);
                }

                servBeleg.SaveData(unitOfWork, beleg);
                ts.Complete();
                if (beleg.Fehlermeldung != null)
                {
                    return false; //Beleg konnte nicht verbucht werden
                }
                return true; //Beleg konnte verbucht werden.
            }
        }

        /// <summary>
        /// Überträgt die Zahlungsinformationen in das Objekt 
        /// KbuBelegDebitor. Damit ist sichergestellt, dass die Debitorinformationen 
        /// zum Zeitpunkt ab Verbuchens unverändert bleiben.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="beleg"></param>
        /// <param name="valutaDatum"></param>
        private void CopyEinzahlerdatenIntoDebitor(IUnitOfWork unitOfWork, KbuBeleg beleg, DateTime valutaDatum)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            //Service instanzieren
            var serviceDebitor = Container.Resolve<KbuBelegDebitorService>();

            // Debitor holen
            var belegDebitor = serviceDebitor.GetByKbuBelegIdOrCreate(unitOfWork, beleg.KbuBelegID);

            var zahlungseingang = beleg.KbuZahlungseingang;
            if (zahlungseingang == null && beleg.KbuZahlungseingangID.HasValue)
            {
                var serviceZahlungseingang = Container.Resolve<KbuZahlungseingangService>();
                zahlungseingang = serviceZahlungseingang.GetById(unitOfWork, beleg.KbuZahlungseingangID.Value);
            }

            if (zahlungseingang == null)
            {
                throw new Exception(string.Format("Der freigegebene Einzahlungsbeleg mit ID {0} hat keinen Verweis auf einen KbuZahlungseingang", beleg.KbuBelegID));
            }

            belegDebitor.BaInstitutionID = zahlungseingang.BaInstitutionID_Debitor;
            belegDebitor.BaPersonID = zahlungseingang.BaPersonID_Debitor;

            //Debitorendaten speichern.
            serviceDebitor.SaveData(unitOfWork, belegDebitor);
        }

        /// <summary>
        /// Überträgt die Zahlungsinformationen in das Objekt 
        /// KbuBelegKreditor. Damit ist sichergestellt, dass die Zahlungsinformationen 
        /// zum Zeitpunkt ab Verbuchens unverändert bleiben.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="beleg"></param>
        /// <param name="valutaDatum"></param>
        private void CopyZahlungsdatenIntoKreditor(IUnitOfWork unitOfWork, KbuBeleg beleg, DateTime valutaDatum)
        {
            //Services instanzieren
            BaAdresseService servAdr = Container.Resolve<BaAdresseService>();
            KbuBelegKreditorService servKred = Container.Resolve<KbuBelegKreditorService>();

            // Kreditor holen. Der Zahlungsweg wird eager geladen.
            var belegKreditor = servKred.GetByKbuBelegId(unitOfWork, beleg.KbuBelegID);

            //Zahlungsweg verweist entweder auf eine Person oder eine Institution.
            BaAdresse adresse = null;
            belegKreditor.BgEinzahlungsscheinCode = belegKreditor.BaZahlungsweg.EinzahlungsscheinCode;
            if (belegKreditor.BaZahlungsweg.BaPersonID.HasValue)
            {
                BaPersonService servPerson = Container.Resolve<BaPersonService>();
                BaPerson person = servPerson.GetById(unitOfWork, belegKreditor.BaZahlungsweg.BaPersonID.Value);
                adresse = servAdr.GetByBaPersonIdAndHome(unitOfWork, belegKreditor.BaZahlungsweg.BaPersonID.Value, valutaDatum);
                belegKreditor.BeguenstigtName = person.NameVorname;
            }
            else if (belegKreditor.BaZahlungsweg.BaInstitutionID.HasValue)
            {
                BaInstitutionService servInst = Container.Resolve<BaInstitutionService>();
                BaInstitution inst = servInst.GetById(unitOfWork, belegKreditor.BaZahlungsweg.BaInstitutionID.Value);
                adresse = servAdr.GetByBaInstitutionId(unitOfWork, belegKreditor.BaZahlungsweg.BaInstitutionID.Value, valutaDatum);
                belegKreditor.BeguenstigtName = inst.InstitutionName ?? inst.Name;
                belegKreditor.Beguenstigtname2 = adresse.Zusatz;
            }

            //Adressdaten kopieren
            if (adresse != null)
            {
                belegKreditor.BeguenstigtStrasse = adresse.Strasse;
                belegKreditor.BeguenstigtHausNr = adresse.HausNr;
                belegKreditor.BeguenstigtPLZ = adresse.PLZ;
                belegKreditor.BeguenstigtOrt = adresse.Ort;
                belegKreditor.BeguenstigtPostfach = adresse.Postfach;
                belegKreditor.IBAN = belegKreditor.BaZahlungsweg.IBANNummer;
                belegKreditor.ReferenzNummer = belegKreditor.BaZahlungsweg.ReferenzNummer;
                belegKreditor.BaLandID_Beguenstigt = adresse.BaLandID;
            }

            //Bankdaten kopieren
            var bank = belegKreditor.BaZahlungsweg.BaBank;
            if (bank == null &&
                belegKreditor.BaZahlungsweg.EinzahlungsscheinCode.HasValue &&
                belegKreditor.BaZahlungsweg.EinzahlungsscheinCode.Value == 2 /*Postkonto*/)
            {
                bank = GetPostfinance(unitOfWork);
            }

            if (bank != null)
            {
                belegKreditor.BaBankID = bank.BaBankID;
                belegKreditor.BaLandID_Bank = bank.LandCode;
                belegKreditor.BankBCN = bank.ClearingNr;
                belegKreditor.BankKontoNr = bank.PCKontoNr;
                belegKreditor.BankName = bank.Name;
                belegKreditor.BankStrasse = bank.Strasse;
                belegKreditor.BankPLZ = bank.PLZ;
                belegKreditor.BankOrt = bank.Ort;
            }

            //Kreditor Daten speichern.
            servKred.SaveData(unitOfWork, belegKreditor);
        }

        /// <summary>
        /// Mappt KbuBelegart zu KbuBelegKreis.
        /// </summary>
        /// <param name="belegArt"></param>
        /// <returns></returns>
        private LOVsGenerated.KbuBelegKreis MapToBelegKreis(int belegArtCode)
        {
            return (LOVsGenerated.KbuBelegKreis)belegArtCode;
        }

        /// <summary>
        /// Validiert den Beleg (keine Datenbankmutationen in dieser Methode).
        /// </summary>
        /// <param name="beleg"></param>
        /// <returns></returns>
        private KissServiceResult ValidateBeleg(IUnitOfWork unitOfWork, KbuBeleg beleg, DateTime valutaDatum)
        {
            var result = KissServiceResult.Ok();
            if (beleg.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Auszahlung)
            {
                //Services instanzieren
                BaAdresseService servAdr = Container.Resolve<BaAdresseService>();
                KbuBelegKreditorService servKred = Container.Resolve<KbuBelegKreditorService>();

                //Überprüfen, ob es einen Kreditor gibt. Kreditor ist obligatorisch zum verbuchen.
                KbuBelegKreditor belKred = null;
                try
                {
                    // BaZahlungsweg zum Kreditor wird eager geladen.
                    belKred = servKred.GetByKbuBelegId(unitOfWork, beleg.KbuBelegID);
                }
                catch (EntityNotFoundException)
                {
                    return new KissServiceResult(KissServiceResult.ResultType.Error, "Es existiert kein Kreditor");
                }

                //Prüfen, ob es einen Zahlungsweg git. Zahlungsweg ist obligatorisch.
                if (!belKred.BaZahlungswegID.HasValue)
                {
                    return new KissServiceResult(KissServiceResult.ResultType.Error, "Zahlweg ist nicht definiert");
                }

                //Prüfen, ob der Zahlweg am Valuta-Datum gültig ist
                if (belKred.BaZahlungsweg.DatumVon > valutaDatum ||
                    belKred.BaZahlungsweg.DatumBis.HasValue && belKred.BaZahlungsweg.DatumBis < valutaDatum)
                {
                    return new KissServiceResult(
                        KissServiceResult.ResultType.Error,
                        string.Format("Der Zahlweg ist am {0} nicht gültig", valutaDatum.ToString(Constant.DATETIME_FORMAT_DDMMYYYY))
                        );
                }

                //Zahlungsweg verweist entweder auf eine Person oder eine Institution.
                BaAdresse adresse = null;
                if (belKred.BaZahlungsweg.BaPersonID.HasValue)
                {
                    BaPersonService servPerson = Container.Resolve<BaPersonService>();
                    BaPerson person = servPerson.GetById(unitOfWork, belKred.BaZahlungsweg.BaPersonID.Value);

                    if (string.IsNullOrEmpty(person.Name))
                    {
                        return new KissServiceResult(KissServiceResult.ResultType.Error, "Der Name der begünstigten Person ist nicht definiert");
                    }

                    adresse = servAdr.GetByBaPersonIdAndHome(unitOfWork, belKred.BaZahlungsweg.BaPersonID.Value, valutaDatum);
                    if (adresse == null)
                    {
                        string oneError = string.Format(
                            "BaPersonId: {0}, Name: {1}, Vorname: {2}, ValutaDatum: {3}; gültige Adresse fehlt.",
                            person.BaPersonID,
                            person.Name,
                            person.Vorname,
                            valutaDatum.ToString(Constant.DATETIME_FORMAT_DDMMYYYY)
                            );
                        return new KissServiceResult(KissServiceResult.ResultType.Error, oneError);
                    }
                }
                else if (belKred.BaZahlungsweg.BaInstitutionID.HasValue)
                {
                    BaInstitutionService servInst = Container.Resolve<BaInstitutionService>();
                    BaInstitution inst = servInst.GetById(unitOfWork, belKred.BaZahlungsweg.BaInstitutionID.Value);

                    string name = inst.InstitutionName ?? inst.Name;
                    if (string.IsNullOrEmpty(name))
                    {
                        return new KissServiceResult(KissServiceResult.ResultType.Error, "Der Name der begünstigten Institution ist nicht definiert");
                    }

                    adresse = servAdr.GetByBaInstitutionId(unitOfWork, belKred.BaZahlungsweg.BaInstitutionID.Value, valutaDatum);
                    if (adresse == null)
                    {
                        string oneError = string.Format(
                            "Gültige Adresse für Institution {0} und Valutadatum {1} fehlt",
                            belKred.BaZahlungsweg.BaInstitutionID.Value,
                            valutaDatum.ToString(Constant.DATETIME_FORMAT_DDMMYYYY)
                            );
                        return new KissServiceResult(KissServiceResult.ResultType.Error, oneError);
                    }
                }
                else
                {
                    return new KissServiceResult(
                        KissServiceResult.ResultType.Error,
                        string.Format("BaPerson und BaInstitution fehlt im Zahlungsweg mit Id {0}", belKred.BaZahlungswegID)
                        );
                }

                if (string.IsNullOrEmpty(adresse.Strasse) || string.IsNullOrEmpty(adresse.PLZ) || string.IsNullOrEmpty(adresse.Ort))
                {
                    return new KissServiceResult(
                        KissServiceResult.ResultType.Error,
                        "Strasse, PLZ oder Ort des Begünstigten sind nicht definiert"
                        );
                }
            }
            else if (beleg.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Einzahlung)
            {
                //Services instanzieren
                var serviceDebitor = Container.Resolve<KbuBelegDebitorService>();

                //Überprüfen, ob es einen Kreditor gibt. Kreditor ist obligatorisch zum verbuchen.
                KbuBelegDebitor belegDebitor = null;
                try
                {
                    // BaZahlungsweg zum Kreditor wird eager geladen.
                    belegDebitor = serviceDebitor.GetByKbuBelegId(unitOfWork, beleg.KbuBelegID);
                }
                catch (EntityNotFoundException)
                {
                    return new KissServiceResult(KissServiceResult.ResultType.Error, "Es existiert kein Kreditor");
                }

                //Prüfen, ob ein Debitor gesetzt ist
                if (!belegDebitor.BaInstitutionID.HasValue && !belegDebitor.BaPersonID.HasValue)
                {
                    result += new KissServiceResult(KissServiceResult.ResultType.Error, "Kein Debitor gesetzt");
                }
            }
            else
            {
                result += new KissServiceResult(
                        KissServiceResult.ResultType.Error,
                        "In der aktuellen Version können nur elektronische Auszahlungen und Einzahlungen verbucht werden"
                        );
            }

            return result;
        }

        #endregion

        #endregion
    }
}