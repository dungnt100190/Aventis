using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BL.KissSystem;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;
using Kiss.Model.DTO.BA;

namespace Kiss.BL.Ba
{
    /// <summary>
    /// Service für eine Zahlungswegsuche.
    /// </summary>
    public class BaZahlungswegSearchService : ServiceBase
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string LOV_EINZAHLUNGSSCHEIN = "BgEinzahlungsschein";

        #endregion

        #endregion

        #region Constructors

        private BaZahlungswegSearchService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Hohlt den ZahlungswegDTO anhand der ZahlungswegId.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="baZahlungswegId"></param>
        /// <returns></returns>
        public BaZahlungswegDTO GetBaZahlungswegDTO(IUnitOfWork unitOfWork, int baZahlungswegId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            IRepository<BaZahlungsweg> zahlungswegRepository = UnitOfWork.GetRepository<BaZahlungsweg>(unitOfWork);

            var query = from x in zahlungswegRepository
                        where x.BaZahlungswegID == baZahlungswegId
                        let adressePerson =
                            x.BaPerson.BaAdresse.Where(
                                a => a.DatumVon <= DateTime.Today && (a.DatumBis == null || a.DatumBis >= DateTime.Today && a.AdresseCode == 1)).
                            FirstOrDefault()
                        let adresseInstitution =
                            x.BaInstitution.BaAdresse.Where(
                                a => a.DatumVon <= DateTime.Today && (a.DatumBis == null || a.DatumBis >= DateTime.Today && a.AdresseCode == 1)).
                            FirstOrDefault()
                        select new
                        {
                            Zahlungsweg = x,
                            //Person Stuff
                            PersonNachName = x.BaPerson.Name,
                            PersonVorname = x.BaPerson.Vorname,
                            PersonAdresseStrasse = adressePerson.Strasse,
                            PersonAdresseOrt = adressePerson.Ort,
                            PersonAdressePLZ = adressePerson.PLZ,
                            PersonAdresseHausNummer = adressePerson.HausNr,
                            //Institution Stuff
                            InstitutionName = x.BaInstitution.Name ?? x.BaInstitution.InstitutionName,
                            InstitutionAdresseStrasse = adresseInstitution.Strasse,
                            InstitutionAdresseOrt = adresseInstitution.Ort,
                            InstitutionAdressePLZ = adresseInstitution.PLZ,
                            InstitutionAdresseHausNummer = adresseInstitution.HausNr,
                            //BankStuff
                            BankName = x.BaBank.Name,
                            BankPCKontoNr = x.BaBank.PCKontoNr
                        };
            var first = query.FirstOrDefault();

            if (first == null)
            {
                return null;
            }

            //Übertragen der Daten
            var result = new BaZahlungswegDTO();

            //Bankdaten.
            result.BaZahlungswegID = first.Zahlungsweg.BaZahlungswegID;
            result.IBANNummer = first.Zahlungsweg.IBANNummer;
            result.PostKontoNummer = first.Zahlungsweg.PostKontoNummer;
            result.BankKontoNummer = first.Zahlungsweg.BankKontoNummer;
            result.BgEinzahlungsscheinCode = first.Zahlungsweg.EinzahlungsscheinCode;
            if (first.Zahlungsweg.EinzahlungsscheinCode.HasValue)
            {
                var lovService = Container.Resolve<XLovService>();
                XLOVCode code = lovService.GetLovCode(unitOfWork, first.Zahlungsweg.EinzahlungsscheinCode.Value, LOV_EINZAHLUNGSSCHEIN);
                result.BgEinzahlungsscheinCodeShortText = code.ShortText;
            }
            result.BankName = first.BankName;
            result.BankPCKontoNr = first.BankPCKontoNr;

            //Persondaten und Adresse der Person
            if (!string.IsNullOrEmpty(first.PersonNachName))
            {
                result.Type = KreditorType.Person;
                result.BaPersonId = first.Zahlungsweg.BaPersonID;
                result.Nachname = first.PersonNachName;
                result.Vorname = first.PersonVorname;
                result.PLZ = first.PersonAdressePLZ;
                result.Ort = first.PersonAdresseOrt;
                result.HausNr = first.PersonAdresseHausNummer;
                result.Strasse = first.PersonAdresseStrasse;
            }

            //Institution und Adresse der Institution
            if (!string.IsNullOrEmpty(first.InstitutionName))
            {
                result.Type = KreditorType.Institution;
                result.BaInstitutionId = first.Zahlungsweg.BaInstitutionID;
                result.NameInstitution = first.InstitutionName;
                result.PLZ = first.InstitutionAdressePLZ;
                result.Ort = first.InstitutionAdresseOrt;
                result.HausNr = first.InstitutionAdresseHausNummer;
                result.Strasse = first.InstitutionAdresseStrasse;
            }
            return result;
        }

        /// <summary>
        /// Hohl den standardzahlweg einer Leistung.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faLeistungID"></param>
        /// <param name="moduleID"></param>
        /// <returns></returns>
        public BaZahlungswegDTO GetStandardZahlungsweg(IUnitOfWork unitOfWork, int faLeistungID, int moduleID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            IRepository<BaZahlungsweg> zahlungswegRepository = UnitOfWork.GetRepository<BaZahlungsweg>(unitOfWork);
            string moduleIDString = moduleID.ToString();

            var query = from baZahlungsweg in zahlungswegRepository
                        where baZahlungsweg.BaPerson.FaLeistung.Any(l => l.FaLeistungID == faLeistungID)
                        where baZahlungsweg.DatumVon <= DateTime.Today
                        where baZahlungsweg.DatumBis == null || baZahlungsweg.DatumBis > DateTime.Today
                        select baZahlungsweg;

            int? baZahlungswegId = null;
            if (query.Count() > 0)
            {
                foreach (var zahlungsweg in query)
                {
                    if (zahlungsweg.BaZahlwegModulStdCodes != null && zahlungsweg.BaZahlwegModulStdCodes.Contains(moduleIDString))
                    {
                        baZahlungswegId = zahlungsweg.BaZahlungswegID;
                        break;
                    }

                }

                if (!baZahlungswegId.HasValue)
                {
                    baZahlungswegId = query.First().BaZahlungswegID;
                }

                return GetBaZahlungswegDTO(unitOfWork, baZahlungswegId.Value);
            }

            return null;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Überträgt den TextShort von der LOV BgEinzahlungsschein in das DTO.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="list">Liste von DTO</param>
        private void ApplyBgEinzahlungsscheinCodeTextShort(IUnitOfWork unitOfWork, List<BaZahlungswegDTO> list)
        {
            var lovService = Container.Resolve<XLovService>();
            List<XLOVCode> lovs = lovService.GetLovCodeByLovName(unitOfWork, LOV_EINZAHLUNGSSCHEIN);
            IDictionary<int, XLOVCode> map = new Dictionary<int, XLOVCode>();
            lovs.ForEach(x => map.Add(x.Code, x));
            foreach (BaZahlungswegDTO dto in list)
            {
                int? code = dto.BgEinzahlungsscheinCode;
                if (code.HasValue)
                {
                    XLOVCode lovCode = map[code.Value];
                    dto.BgEinzahlungsscheinCodeShortText = lovCode.ShortText;
                }
            }
        }

        /// <summary>
        /// Part2, Suche nach Instututionen
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        private IQueryable<BaZahlungswegDTO> QueryBaInstitutionen(IUnitOfWork unitOfWork, string searchString)
        {
            IRepository<BaZahlungsweg> zahlungswegRepository = UnitOfWork.GetRepository<BaZahlungsweg>(unitOfWork);

            IQueryable<BaZahlungswegDTO> query = from zw in zahlungswegRepository
                                                 let adresse =
                                                     zw.BaInstitution.BaAdresse.Where(
                                                         x =>
                                                         x.DatumVon <= DateTime.Today &&
                                                         (x.DatumBis == null || x.DatumBis >= DateTime.Today && x.AdresseCode == 1)).FirstOrDefault()
                                                 where zw.BaInstitution == adresse.BaInstitution
                                                 //Force inner join
                                                 where zw.BaInstitution.Name.ToUpper().Contains(searchString) //Für Standard
                                                       || zw.BaInstitution.InstitutionName.ToUpper().Contains(searchString)
                                                 //Für ZH
                                                 select new BaZahlungswegDTO
                                                 {
                                                     BaZahlungswegID = zw.BaZahlungswegID,
                                                     TypeInt = (int)KreditorType.Institution,
                                                     NameInstitution = zw.BaInstitution.Name ?? zw.BaInstitution.InstitutionName,
                                                     //Für Standard und ZH
                                                     IBANNummer = zw.IBANNummer,
                                                     PostKontoNummer = zw.PostKontoNummer,
                                                     BaPersonId = zw.BaPersonID,
                                                     BaInstitutionId = zw.BaInstitutionID,
                                                     DatumVon = zw.DatumVon,
                                                     DatumBis = zw.DatumBis,
                                                     PLZ = adresse.PLZ,
                                                     Ort = adresse.Ort,
                                                     Strasse = adresse.Strasse,
                                                     HausNr = adresse.HausNr,
                                                     BankName = zw.BaBank.Name,
                                                     BankPCKontoNr = zw.BaBank.PCKontoNr,
                                                     BgEinzahlungsscheinCode = zw.EinzahlungsscheinCode
                                                 };

            return query;
        }

        /// <summary>
        /// Part1, Suche nach Personen.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="vorname"></param>
        /// <param name="nachname"></param>
        /// <returns></returns>
        private IQueryable<BaZahlungswegDTO> QueryBaPersonen(IUnitOfWork unitOfWork, string vorname, string nachname)
        {
            IRepository<BaZahlungsweg> zahlungswegRepository = UnitOfWork.GetRepository<BaZahlungsweg>(unitOfWork);
            IQueryable<BaZahlungswegDTO> query = from zw in zahlungswegRepository
                                                 where zw.BaPerson.Name.ToUpper().Contains(nachname)
                                                       && zw.BaPerson.Vorname.ToUpper().Contains(vorname)
                                                 let adresse =
                                                     zw.BaPerson.BaAdresse.Where(
                                                         x =>
                                                         x.DatumVon <= DateTime.Today &&
                                                         (x.DatumBis == null || x.DatumBis >= DateTime.Today && x.AdresseCode == 1)).FirstOrDefault()
                                                 where zw.BaPerson == adresse.BaPerson
                                                 //Force inner join
                                                 select new BaZahlungswegDTO
                                                 {
                                                     BaZahlungswegID = zw.BaZahlungswegID,
                                                     TypeInt = (int)KreditorType.Person,
                                                     Nachname = zw.BaPerson.Name,
                                                     Vorname = zw.BaPerson.Vorname,
                                                     IBANNummer = string.IsNullOrEmpty(zw.IBANNummer) ? "" : zw.IBANNummer,
                                                     PostKontoNummer = string.IsNullOrEmpty(zw.PostKontoNummer) ? "" : zw.PostKontoNummer,
                                                     BaPersonId = zw.BaPersonID,
                                                     BaInstitutionId = zw.BaInstitutionID,
                                                     DatumVon = zw.DatumVon,
                                                     DatumBis = zw.DatumBis,
                                                     PLZ = adresse.PLZ,
                                                     Ort = adresse.Ort,
                                                     Strasse = adresse.Strasse,
                                                     HausNr = adresse.HausNr,
                                                     BankName = zw.BaBank.Name,
                                                     BankPCKontoNr = zw.BaBank.PCKontoNr,
                                                     BgEinzahlungsscheinCode = zw.EinzahlungsscheinCode
                                                 };

            return query;
        }

        #endregion

        #endregion

        #region Other

        /////// <summary>
        /////// Sucht nach Zahlungswegen.
        /////// </summary>
        /////// <param name="unitOfWork"></param>
        /////// <param name="searchString">
        /////// TODO: ausführlich Semantik beschreiben.      
        /////// </param>
        /////// <param name="faLeistungId"></param>
        /////// <returns></returns>
        ////public List<BaZahlungswegDTO> SearchZahlungsweg(IUnitOfWork unitOfWork, string searchString, int faLeistungId)
        ////{
        ////    searchString = searchString.ToUpper();
        ////    unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
        ////    var result = new List<BaZahlungswegDTO>();
        ////    if ("." == searchString)
        ////    {
        ////        IQueryable<BaZahlungswegDTO> queryHaushalt = QueryBaPersonenHausalt(unitOfWork, faLeistungId);
        ////        result.AddRange(queryHaushalt.ToList());
        ////    }
        ////    else
        ////    {
        ////        /* Personen werden nur bei . berücksichtigt, sonst werden nur Institutionen berücksichtigt. */
        ////        /*
        ////        string vorname = "";
        ////        string nachname = searchString;
        ////        string[] split = {", "};
        ////        string[] splitted = searchString.Split(split, StringSplitOptions.RemoveEmptyEntries);
        ////        if(splitted.Count() == 2)
        ////        {
        ////            nachname = splitted[0];
        ////            vorname = splitted[1];
        ////        }
        ////        var queryPersonen = QueryBaPersonen(unitOfWork, vorname, nachname);
        ////        */
        ////        if ("*" == searchString)
        ////        {
        ////            searchString = "";
        ////        }
        ////        IQueryable<BaZahlungswegDTO> queryInstitutionen = QueryBaInstitutionen(unitOfWork, searchString);
        ////        //result.AddRange(queryPersonen.ToList());
        ////        result.AddRange(queryInstitutionen.ToList());
        ////    }
        ////    //LOV auflösen
        ////    ApplyBgEinzahlungsscheinCodeTextShort(unitOfWork, result);
        ////    return result;
        ////}
        /////// <summary>
        /////// Part3, Suche nach Personen im Haushalt. 
        /////// </summary>
        /////// <param name="unitOfWork"></param>
        /////// <param name="faLeistungID"></param>
        /////// <returns></returns>
        ////private IQueryable<BaZahlungswegDTO> QueryBaPersonenHausalt(IUnitOfWork unitOfWork, int faLeistungID)
        ////{
        ////    IRepository<BaZahlungsweg> zahlungswegRepository = UnitOfWork.GetRepository<BaZahlungsweg>(unitOfWork);
        ////    IQueryable<BaZahlungswegDTO> query = from zw in zahlungswegRepository
        ////                                         where
        ////                                             zw.BaPerson.WshHaushaltPerson.Any(
        ////                                                 hh =>
        ////                                                 hh.FaLeistungID == faLeistungID &&
        ////                                                 ((hh.DatumVon ?? new DateTime(1753, 1, 1)) <= DateTime.Today) &&
        ////                                                 ((hh.DatumBis ?? DateTime.MaxValue) >= DateTime.Today))
        ////                                         let adresse =
        ////                                             zw.BaPerson.BaAdresse.Where(
        ////                                                 x =>
        ////                                                 x.DatumVon <= DateTime.Today &&
        ////                                                 (x.DatumBis == null || x.DatumBis >= DateTime.Today && x.AdresseCode == 1)).FirstOrDefault()
        ////                                         where zw.BaPerson == adresse.BaPerson
        ////                                         //Force inner join
        ////                                         select new BaZahlungswegDTO
        ////                                         {
        ////                                             BaZahlungswegID = zw.BaZahlungswegID,
        ////                                             TypeInt = (int)KreditorType.Person,
        ////                                             Nachname = zw.BaPerson.Name,
        ////                                             Vorname = zw.BaPerson.Vorname,
        ////                                             IBANNummer = string.IsNullOrEmpty(zw.IBANNummer) ? "" : zw.IBANNummer,
        ////                                             PostKontoNummer = string.IsNullOrEmpty(zw.PostKontoNummer) ? "" : zw.PostKontoNummer,
        ////                                             BaPersonId = zw.BaPersonID,
        ////                                             BaInstitutionId = zw.BaInstitutionID,
        ////                                             DatumVon = zw.DatumVon,
        ////                                             DatumBis = zw.DatumBis,
        ////                                             PLZ = adresse.PLZ,
        ////                                             Ort = adresse.Ort,
        ////                                             Strasse = adresse.Strasse,
        ////                                             HausNr = adresse.HausNr,
        ////                                             BankName = zw.BaBank.Name,
        ////                                             BankPCKontoNr = zw.BaBank.PCKontoNr,
        ////                                             BgEinzahlungsscheinCode = zw.EinzahlungsscheinCode
        ////                                         };
        ////    return query;
        ////}

        #endregion
    }
}