using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BusinessLogic.Sys;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Fa;
using Kiss.Infrastructure.IoC;

namespace Kiss.BusinessLogic.Fa
{
    public class FaZeitachseService : Service
    {
        #region Constructors

        private FaZeitachseService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public IEnumerable<FaZeitachseDTO> GetZeitachse(int baPersonId)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                var fallfuehrungen = unitOfWork.FaLeistung.GetFallfuehrungen(baPersonId);
                var faLeistungIDs = fallfuehrungen.Select(lei => lei.FaLeistungID).ToArray();
                if (faLeistungIDs.Length == 0)
                {
                    // Keine Fallführung
                    return null;
                }

                // Hauptachse: Korrespondenz, Besprechungen, Pendenzen
                var korrespondenz = GetKorrespondenz(unitOfWork, faLeistungIDs, baPersonId);
                var besprechungen = GetBesprechungen(unitOfWork, faLeistungIDs, baPersonId);
                var pendenzen = GetPendenzen(unitOfWork, baPersonId);
                var kategorien = GetKategorien(unitOfWork, faLeistungIDs.First(), baPersonId);
                var falluebergabe = GetFalluebergaben(unitOfWork, fallfuehrungen.ToArray());

                // Nebenachse: Weisungen
                var weisungen = GetWeisungen(unitOfWork, faLeistungIDs, baPersonId);

                return new List<FaZeitachseDTO>(korrespondenz
                                                .Concat(besprechungen)
                                                .Concat(pendenzen)
                                                .Concat(weisungen)
                                                .Concat(falluebergabe)
                                                .Concat(kategorien));
            }
        }

        #endregion

        #region Private Static Methods

        private static IEnumerable<FaZeitachseDTO> GetBesprechungen(IKissUnitOfWork unitOfWork, int[] faLeistungIDs, int baPersonID)
        {
            var xLovService = Container.Resolve<XLovService>();

            // Besprechungen
            var besprechungenAnonym = unitOfWork.FaAktennotizen.GetAktennotizen(faLeistungIDs);

            var besprechungen = besprechungenAnonym
                                .Select(tmp => new FaZeitachseEventDTO
                                                   {
                                                       StartDate = tmp.Datum ?? DateTime.MinValue,
                                                       Title = tmp.Stichwort,
                                                       Type = FaZeitachseDTOType.Besprechungen,
                                                       DocFormatCode = null,
                                                       SARName = GetUserDisplayName(tmp.XUser),
                                                       Empfaenger = tmp.Kontaktpartner,
                                                       ThemaCodes = xLovService.GetLovCodes("FaThema", tmp.FaThemaCodes),
                                                       JumpToPath =  // ToDo: Auslagern
                                                       string.Format(
                                                           @"ClassName=FrmFall;Action=JumpToPath;ModulID=2;BaPersonID={0};TreeNodeID=CtlFaBeratungsperiode{1}/20003/CtlFaAktennotiz;ActiveSQLQuery.Find=FaAktennotizID = {2};",
                                                           baPersonID,
                                                           tmp.FaLeistungID,
                                                           tmp.FaAktennotizID)
                                                   });
            return besprechungen;
        }

        private static IEnumerable<FaZeitachseDTO> GetFalluebergaben(IKissUnitOfWork unitOfWork, FaLeistung[] leistungen)
        {
            //Falluebergabe
            var historySARList = unitOfWork.FaLeistungUserHist.GetFalluebergaben(leistungen.Select(lei => lei.FaLeistungID).ToArray());
            foreach (var leistung in leistungen)
            {
                historySARList.Insert(0, new FaLeistungUserHist
                                             {
                                                 DatumVon = leistung.DatumVon,
                                                 XUser = leistung.XUser ?? unitOfWork.XUser.GetById(leistung.UserID)
                                             });
            }

            var falluebergaben = new List<FaZeitachseEventDTO>();

            FaLeistungUserHist currentEntry = null;
            foreach (var previousEntry in historySARList)
            {
                if (currentEntry != null)
                {
                    var temp = new FaZeitachseEventDTO
                    {
                        Title = string.Format("SAR alt: {0}, SAR neu: {1}", previousEntry.XUser.LastNameFirstName, currentEntry.XUser.LastNameFirstName), // ToDo: Multilanguage
                        ShortText = currentEntry.XUser.LogonName ?? currentEntry.XUser.ShortName,
                        StartDate = currentEntry.DatumVon,
                        Type = FaZeitachseDTOType.Falluebergabe
                    };
                    falluebergaben.Add(temp);
                }
                currentEntry = previousEntry;
            }

            return falluebergaben;
        }

        private static IEnumerable<FaZeitachsePeriodDTO> GetKategorien(IKissUnitOfWork unitOfWork, int currentFaLeistungID, int baPersonID)
        {
            return unitOfWork
                   .FaKategorisierung
                   .GetByBaPersonId(baPersonID)
                   .Select(kat => new FaZeitachsePeriodDTO
                                      {
                                          StartDate = kat.Datum,
                                          EndDate = kat.Abschlussdatum,
                                          KategorieCode = kat.FaKategorieCode,
                                          Type = FaZeitachseDTOType.Kategorie,
                                          JumpToPath = string.Format( // ToDo: Auslagern
                                              "ClassName=FrmFall;Action=JumpToPath;ModulID=2;BaPersonID={0};TreeNodeID=CtlFaBeratungsperiode{1}/Kiss.UserInterface.View.Fa.FaKategorisierungView,Kiss.UserInterface.View;FindEntity=\"FaKategorisierung.FaKategorisierungID={2}\"",
                                              kat.BaPersonID,
                                              currentFaLeistungID,
                                              kat.FaKategorisierungID)
                                      });
        }

        private static IEnumerable<FaZeitachseDTO> GetKorrespondenz(IKissUnitOfWork unitOfWork, int[] faLeistungIDs, int baPersonID)
        {
            var xLovService = Container.Resolve<XLovService>();

            return unitOfWork
                   .FaDokument
                   .GetDTOByFaLeistungID(faLeistungIDs)
                   .Select(dok => new FaZeitachseEventDTO
                                      {
                                          StartDate = dok.DatumErstellung,
                                          Title = dok.Stichwort,
                                          Type = FaZeitachseDTOType.Korrespondenz,
                                          DocFormatCode = dok.DocFormatCode,
                                          ThemaCodes = xLovService.GetLovCodes("FaThema", dok.FaThemaCodes),
                                          SARName = GetUserDisplayName(dok.Absender),
                                          Empfaenger = dok.Adressat == null ? null : dok.Adressat.LastNameFirstName,
                                          JumpToPath =  // ToDo: auslagern
                                              string.Format(
                                                  @"ClassName=FrmFall;Action=JumpToPath;ModulID=2;BaPersonID={0};TreeNodeID=CtlFaBeratungsperiode{1}/20003/CtlFaDokumente;ActiveSQLQuery.Find=FaDokumenteID = {2};",
                                                  baPersonID,
                                                  dok.FaLeistungID,
                                                  dok.FaDokumentID)
                                      });
        }

        private static IEnumerable<FaZeitachseDTO> GetPendenzen(IKissUnitOfWork unitOfWork, int baPersonID)
        {
            var xLovService = Container.Resolve<XLovService>();

            return unitOfWork
                   .XTask
                   .GetByBaPersonID(baPersonID)
                   .Select(tsk => new FaZeitachsePeriodDTO
                                      {
                                          StartDate = tsk.CreateDate,
                                          EndDate = tsk.DoneDate,
                                          Title = tsk.Subject,
                                          Type = tsk.TaskStatusCode == 3 ? FaZeitachseDTOType.PendenzenErledigt : FaZeitachseDTOType.PendenzenOffen, // ToDo: MagicNumber 3 durch enum ersetzen (EF5)
                                          SARName = tsk.TaskReceiverCode == 1 ? GetUserDisplayName(tsk.XUser_Receiver) : string.Empty, //ToDo: MagicNumber ersetzen
                                          Empfaenger = tsk.TaskReceiverCode == 1 ? GetUserDisplayName(tsk.XUser_Receiver) : tsk.TaskReceiverCode == 2 ? tsk.FaPendenzgruppe_Receiver.Name : string.Empty,//ToDo: MagicNumber ersetzen
                                          PendenzStatus = xLovService.GetSingleLovCode("TaskStatus", tsk.TaskStatusCode).Text, // ToDo: string durch referenz ersetzen //ToDo: Lookup nicht besser erst auf VM?
                                          JumpToPath =  //ToDo: auslagern
                                              string.Format(
                                                  @"ClassName=FrmFall;Action=JumpToPath;ModulID=2;BaPersonID={0};TreeNodeID=CtlPendenzenVerwaltung;ActiveSQLQuery.Find=XTaskID = {1};",
                                                  baPersonID,
                                                  tsk.XTaskID)
                                      });
        }

        private static string GetUserDisplayName(XUser user)
        {
            return user == null ? null : user.LastNameFirstName;
        }

        #endregion

        #region Private Methods

        private IEnumerable<FaZeitachseDTO> GetWeisungen(IKissUnitOfWork unitOfWork, int[] faLeistungIDs, int baPersonID)
        {
            // Weisung
            var weisungen = unitOfWork
                            .FaWeisung
                            .GetByFaLeistungIDs(faLeistungIDs);

            var weisungZeitachseDTO = weisungen
                                      .Select(wei => new FaZeitachsePeriodDTO
                                                         {
                                                             StartDate = wei.DatumVon,
                                                             EndDate = wei.DatumBis,
                                                             Title = wei.Betreff,
                                                             Type = FaZeitachseDTOType.Weisungen,
                                                             SARName = GetUserDisplayName(wei.VerantwortlichSar),
                                                             Empfaenger = string.Join(", ", wei.Empfaenger.Select(prs => prs.ToString())),
                                                             Documents = wei.Dokumente
                                                                         .Where(dok => dok != null)
                                                                         .Select(dok => new FaZeitachseEventDTO
                                                                                            {
                                                                                                StartDate = dok.Datum,
                                                                                                Title = dok.Typ.ToString(), //ToDo: enum ausdeutschen
                                                                                                DocFormat = dok.Format,
                                                                                                Empfaenger = string.Join(", ", wei.Empfaenger.Select(prs => prs.ToString()))
                                                                                            }).ToList(),
                                                             DateLabels = wei.DatumBis.HasValue
                                                                           ? new List<FaZeitachseEventDTO>(0)
                                                                           : wei.Protokolle
                                                                                .Select(pkt => new FaZeitachseEventDTO
                                                                                                   {
                                                                                                       StartDate = pkt.Termin ?? pkt.Created,
                                                                                                       Title = pkt.Aktion,
                                                                                                       Empfaenger = string.Join(", ", wei.Empfaenger.Select(prs => prs.ToString()))
                                                                                                   }).ToList(),
                                                             // ToDo: Generierung auslagern
                                                             JumpToPath =
                                                                 string.Format(
                                                                     "ClassName=FrmFall;Action=JumpToPath;BaPersonID={0};ModulID=2;TreeNodeID=CtlFaBeratungsperiode{1}/20003/CtlFaWeisung;FaWeisungID={2};ActiveSQLQuery.Find=FaWeisungID = {2};",
                                                                     baPersonID,
                                                                     wei.FaLeistungID,
                                                                     wei.FaWeisungID)
                                                         })
                                      .ToList();

            // Set jump path for documents
            foreach (var dto in weisungZeitachseDTO)
            {
                foreach (var document in dto.Documents)
                {
                    document.JumpToPath = dto.JumpToPath;
                }
            }

            return weisungZeitachseDTO;
        }

        #endregion

        #endregion
    }
}