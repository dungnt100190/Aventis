using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.BL.KissSystem;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Fa;

namespace Kiss.BL.Fa
{
    public class FaZeitachseService : ServiceBase
    {
        #region Constructors

        private FaZeitachseService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// TODO: Beschreibung
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns>key: Code vom Typ, Value: Text in Deutsch</returns>
        public List<KeyValuePair<int, string>> GetEreignisTypMapping(IUnitOfWork unitOfWork)
        {
            return
                    new List<KeyValuePair<int, string>>
                    {
                        new KeyValuePair<int, string>((int)FaZeitachseDTOType.Besprechungen, "Besprechungen"),
                        new KeyValuePair<int, string>((int)FaZeitachseDTOType.Korrespondenz, "Korrespondenz"),
                        new KeyValuePair<int, string>((int)FaZeitachseDTOType.Weisungen, "Weisungen"),
                        new KeyValuePair<int, string>((int)FaZeitachseDTOType.Vertraege, "Verträge"),
                        new KeyValuePair<int, string>((int)FaZeitachseDTOType.Ziele, "Ziele"),
                        new KeyValuePair<int, string>((int)FaZeitachseDTOType.AuswertungProzess, "Auswertung Prozess"),
                        new KeyValuePair<int, string>((int)FaZeitachseDTOType.Falluebergabe, "Fallübergabe"),
                        new KeyValuePair<int, string>((int)FaZeitachseDTOType.PendenzenErledigt, "erledigte Pendenzen"),
                        new KeyValuePair<int, string>((int)FaZeitachseDTOType.PendenzenOffen, "offene Pendenzen"),
                    };
        }

        public IEnumerable<FaZeitachseDTO> GetZeitachse(IUnitOfWork unitOfWork, int baPersonId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            //Hauptachse: Korrespondenz, Besprechungen, Pendenzen
            var korrespondenz = GetKorrespondenz(unitOfWork, baPersonId);
            var besprechungen = GetBesprechungen(unitOfWork, baPersonId);
            var pendenzen = GetPendenzen(unitOfWork, baPersonId);
            var kategorien = GetKategorien(unitOfWork, baPersonId);
            var falluebergabe = GetFalluebergaben(unitOfWork, baPersonId);

            //Nebenachse: Weisungen
            var weisungen = GetWeisungen(unitOfWork, baPersonId);

            var list = new List<FaZeitachseDTO>(korrespondenz.Concat(besprechungen).Concat(pendenzen).Concat(weisungen).Concat(falluebergabe));
            return list.Concat(kategorien);
        }

        #endregion

        #region Internal Methods

        internal IEnumerable<FaZeitachseDTO> GetBesprechungen(IUnitOfWork unitOfWork, int baPersonId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            XLovService xLovService = Container.Resolve<XLovService>();

            var faLeistungRepo = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);
            var fallfuehrung = from faLeistung in faLeistungRepo
                               where faLeistung.BaPersonID == baPersonId && faLeistung.ModulID == 2
                               select faLeistung;

            // Besprechungen
            var besprechungenAnonym = (from faAktennotiz in fallfuehrung.SelectMany(f => f.FaAktennotizen)
                                       where faAktennotiz.Datum != null && !faAktennotiz.IsDeleted
                                       select new
                                       {
                                           StartDate = faAktennotiz.Datum.Value,
                                           Title = faAktennotiz.Stichwort,
                                           faAktennotiz.FaLeistungID,
                                           faAktennotiz.FaAktennotizID,
                                           LastName = faAktennotiz.XUser == null ? null : faAktennotiz.XUser.LastName,
                                           FirstName = faAktennotiz.XUser == null ? null : faAktennotiz.XUser.FirstName,
                                           faAktennotiz.Kontaktpartner,
                                           faAktennotiz.FaThemaCodes,
                                       }).ToList();

            var besprechungen = from b in besprechungenAnonym
                                select new FaZeitachseEventDTO
                                {
                                    StartDate = b.StartDate,
                                    Title = b.Title,
                                    Type = FaZeitachseDTOType.Besprechungen,
                                    DocFormatCode = null,
                                    SARName = NameVornameHelper(b.LastName, b.FirstName),
                                    Empfaenger = b.Kontaktpartner,
                                    ThemaCodes = b.FaThemaCodes == null ? null : b.FaThemaCodes.Split(',').ToList().ConvertAll(Convert.ToInt32),
                                    Thema = xLovService.GetStringFromLovCodes(unitOfWork, b.FaThemaCodes, "FaThema"),
                                    JumpToPath =
                                    string.Format(
                                        @"ClassName=FrmFall;Action=JumpToPath;ModulID=2;BaPersonID={0};TreeNodeID=CtlFaBeratungsperiode{1}/20003/CtlFaAktennotiz;ActiveSQLQuery.Find=FaAktennotizID = {2};",
                                        baPersonId,
                                        b.FaLeistungID,
                                        b.FaAktennotizID)
                                };
            return besprechungen;
        }

        internal IEnumerable<FaZeitachseDTO> GetFalluebergaben(IUnitOfWork unitOfWork, int baPersonId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var faLeistungHistRepo = UnitOfWork.GetRepository<FaLeistungUserHist>(unitOfWork);
            var faLeistungRepo = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);
            try
            {
                //Falluebergabe
                var historySARList = (from hist in faLeistungHistRepo
                                      join leistung in faLeistungRepo on hist.FaLeistungID equals leistung.FaLeistungID
                                      where leistung.BaPersonID == baPersonId && leistung.ModulID == 2   //Nur F Fallübergabe
                                      orderby hist.DatumVon descending
                                      select new
                                      {
                                          SAR = hist.XUser.LastName + " " + hist.XUser.FirstName,
                                          DatumVon = hist.DatumVon,
                                          DatumBis = hist.DatumBis
                                      }).ToList();

                var leistungSAR = (from leistung in faLeistungRepo
                                   where leistung.BaPersonID == baPersonId && leistung.ModulID == 2    //Nur F Fallübergabe
                                   select new
                                   {
                                       SAR = leistung.XUser.LastName + " " + leistung.XUser.FirstName,
                                       DatumVon = leistung.Modified
                                   }).First();

                List<FaZeitachseEventDTO> retVal = new List<FaZeitachseEventDTO>();
                FaZeitachseEventDTO aktuellerSar = new FaZeitachseEventDTO();
                aktuellerSar.StartDate = leistungSAR.DatumVon;

                if (historySARList.Count > 0)
                {
                    aktuellerSar.Title = "SAR alt: " + historySARList[0].SAR + ", SAR neu: " + leistungSAR.SAR;
                    aktuellerSar.StartDate = leistungSAR.DatumVon;
                    aktuellerSar.Type = FaZeitachseDTOType.Falluebergabe;
                    retVal.Add(aktuellerSar);
                    for (int i = 1; i < historySARList.Count; i++)
                    {
                        FaZeitachseEventDTO temp = new FaZeitachseEventDTO();
                        temp.Title = "SAR alt: " + historySARList[i].SAR + ", SAR neu: " + historySARList[i - 1].SAR;
                        temp.StartDate = historySARList[i - 1].DatumVon;
                        temp.Type = FaZeitachseDTOType.Falluebergabe;
                        retVal.Add(temp);
                    }
                }

                return retVal;
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal IEnumerable<FaZeitachseDTO> GetKorrespondenz(IUnitOfWork unitOfWork, int baPersonId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            XLovService xLovService = Container.Resolve<XLovService>();

            var faLeistungRepo = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);
            var fallfuehrung = (from faLeistung in faLeistungRepo
                                where faLeistung.BaPersonID == baPersonId && faLeistung.ModulID == 2
                                select faLeistung)
                               .Include(lei => lei.FaDokumente.SubInclude(doc => doc.XUser_Absender))
                               .Include(lei => lei.FaDokumente.SubInclude(doc => doc.BaPerson_Adressat));

            // Korrespondenz
            var korrespondenzAnonym = (from faDokument in fallfuehrung.SelectMany(f => f.FaDokumente)
                                       where faDokument.DatumErstellung != null && !faDokument.IsDeleted
                                       select new
                                       {
                                           StartDate = faDokument.DatumErstellung.Value,
                                           Title = faDokument.Stichwort,
                                           DocFormatCode = faDokument.XDocument == null ? null : faDokument.XDocument.DocFormatCode,
                                           ThemaCodes = faDokument.FaThemaCodes,
                                           faDokument.FaLeistungID,
                                           faDokument.FaDokumenteID,
                                           LastName = faDokument.XUser_Absender == null ? null : faDokument.XUser_Absender.LastName,
                                           FirstName = faDokument.XUser_Absender == null ? null : faDokument.XUser_Absender.FirstName,
                                           Name = faDokument.BaPerson_Adressat == null ? null : faDokument.BaPerson_Adressat.Name,
                                           Vorname = faDokument.BaPerson_Adressat == null ? null : faDokument.BaPerson_Adressat.Vorname,
                                       }).ToList();

            var korrespondenz = from k in korrespondenzAnonym
                                select new FaZeitachseEventDTO
                                {
                                    StartDate = k.StartDate,
                                    Title = k.Title,
                                    Type = FaZeitachseDTOType.Korrespondenz,
                                    DocFormatCode = k.DocFormatCode,
                                    ThemaCodes = k.ThemaCodes == null ? null : k.ThemaCodes.Split(',').ToList().ConvertAll(Convert.ToInt32),
                                    Thema = xLovService.GetStringFromLovCodes(unitOfWork, k.ThemaCodes, "FaThema"),
                                    SARName = NameVornameHelper(k.LastName, k.FirstName),
                                    Empfaenger = NameVornameHelper(k.Name, k.Vorname),
                                    JumpToPath =
                                        string.Format(
                                            @"ClassName=FrmFall;Action=JumpToPath;ModulID=2;BaPersonID={0};TreeNodeID=CtlFaBeratungsperiode{1}/20003/CtlFaDokumente;ActiveSQLQuery.Find=FaDokumenteID = {2};",
                                            baPersonId,
                                            k.FaLeistungID,
                                            k.FaDokumenteID)
                                };

            return korrespondenz;
        }

        internal IEnumerable<FaZeitachseDTO> GetPendenzen(IUnitOfWork unitOfWork, int baPersonId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            XLovService xLovService = Container.Resolve<XLovService>();

            // Pendenzen
            var xTaskRepo = UnitOfWork.GetRepository<XTask>(unitOfWork);
            var userRepo = UnitOfWork.GetRepository<XUser>(unitOfWork);
            var groupRepo = UnitOfWork.GetRepository<FaPendenzgruppe>(unitOfWork);

            // die Leistung muss wie im ModulTree geholt werden (stimmt nicht unbedingt mit XTask.FaLeistungID überein)
            var leistungRepo = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);
            var faLeistungId = (from lei in leistungRepo
                                where lei.BaPersonID == baPersonId && lei.ModulID == 2
                                orderby lei.DatumVon
                                select lei.FaLeistungID).FirstOrDefault();

            var pendenzenAnonym = (from xTask in xTaskRepo
                                   where xTask.BaPersonID == baPersonId
                                   join empfaengerU in userRepo on xTask.ReceiverID equals empfaengerU.UserID into joinedEmpfUser
                                   from empfU in joinedEmpfUser.DefaultIfEmpty()
                                   join empfaengerG in groupRepo on xTask.ReceiverID equals empfaengerG.FaPendenzgruppeID into joinedEmpfGroup
                                   from empfG in joinedEmpfGroup.DefaultIfEmpty()
                                   select new
                                   {
                                       StartDate = xTask.CreateDate,
                                       EndDate = xTask.DoneDate,
                                       Title = xTask.Subject,
                                       FaLeistungID = faLeistungId,
                                       xTask.XTaskID,
                                       xTask.TaskReceiverCode,
                                       PendenzStatus = xTask.TaskStatusCode,
                                       UserVorname = empfU == null ? null : empfU.FirstName,
                                       UserNachname = empfU == null ? null : empfU.LastName,
                                       GroupName = empfG == null ? null : empfG.Name,
                                   }).ToList();

            var pendenzen = from t in pendenzenAnonym
                            select new FaZeitachsePeriodDTO
                            {
                                StartDate = t.StartDate,
                                EndDate = t.EndDate,
                                Title = t.Title,
                                Type = t.PendenzStatus == 3 ? FaZeitachseDTOType.PendenzenErledigt : FaZeitachseDTOType.PendenzenOffen,
                                SARName = t.TaskReceiverCode == 1 ? NameVornameHelper(t.UserNachname, t.UserVorname) : string.Empty,
                                Empfaenger = t.TaskReceiverCode == 1 ? NameVornameHelper(t.UserNachname, t.UserVorname) : (t.TaskReceiverCode == 2 ? t.GroupName : string.Empty),
                                PendenzStatus = xLovService.GetLovCode(unitOfWork, t.PendenzStatus, "TaskStatus").Text,
                                JumpToPath =
                                    string.Format(
                                        @"ClassName=FrmFall;Action=JumpToPath;ModulID=2;BaPersonID={0};TreeNodeID=CtlPendenzenVerwaltung;ActiveSQLQuery.Find=XTaskID = {1};",
                                        baPersonId,
                                        t.XTaskID)
                            };

            return pendenzen;
        }

        #endregion

        #region Private Methods

        private IEnumerable<FaZeitachsePeriodDTO> GetKategorien(IUnitOfWork unitOfWork, int baPersonId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var kategorieRepository = UnitOfWork.GetRepository<FaKategorisierung>(unitOfWork);
            var leistungRepository = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);

            var kategorie = (from k in kategorieRepository
                             where k.BaPersonID == baPersonId
                             select k).ToList();

            var faLeistungId = (from lei in leistungRepository
                                where lei.BaPersonID == baPersonId && lei.ModulID == 2
                                orderby lei.DatumVon
                                select lei.FaLeistungID).FirstOrDefault();

            return from kat in kategorie
                   select new FaZeitachsePeriodDTO
                   {
                       StartDate = kat.Datum,
                       EndDate = kat.Abschlussdatum,
                       KategorieCode = kat.FaKategorieCode,
                       Type = FaZeitachseDTOType.Kategorie,
                       JumpToPath = string.Format(
                           "ClassName=FrmFall;Action=JumpToPath;ModulID=2;BaPersonID={0};TreeNodeID=CtlFaBeratungsperiode{1}/Kiss.UI.View.Fa.FaKategorisierungView.xaml;FindEntity=\"FaKategorisierung.FaKategorisierungID={2}\"",
                           baPersonId,
                           faLeistungId,
                           kat.FaKategorisierungID)
                   };
        }

        private IEnumerable<FaZeitachseDTO> GetWeisungen(IUnitOfWork unitOfWork, int baPersonId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            // Weisung
            var faLeistungRepo = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);

            var faWeisung =
                (from weisung in faLeistungRepo.Where(lei => lei.BaPersonID == baPersonId && lei.ModulID == 2).SelectMany(lei => lei.FaWeisung)

                 let letztesProtokollAsList = weisung.FaWeisungProtokoll.OrderByDescending(wp => wp.Created).Take(1)
                 let letztesProtokoll = letztesProtokollAsList.FirstOrDefault()

                 select new
                 {
                     weisung.FaLeistungID,
                     weisung.FaWeisungID,
                     weisung.Created,
                     weisung.Betreff,
                     weisung.XDocumentID_Weisung,
                     weisung.TerminWeisung,
                     weisung.XDocumentID_Mahnung1,
                     weisung.TerminMahnung1,
                     weisung.XDocumentID_Mahnung2,
                     weisung.TerminMahnung2,
                     weisung.XDocumentID_Mahnung3,
                     weisung.TerminMahnung3,
                     weisung.XDocumentID_Verfuegung,
                     weisung.DatumVerfuegung,
                     weisung.XUser_VerantwortlichSar.LastName,
                     weisung.XUser_VerantwortlichSar.FirstName,
                     AbschlussDatum = weisung.StatusCode != (int)LOVsGenerated.FaWeisungStatus.Fertig
                                        ? (DateTime?)null
                                        : letztesProtokoll.Termin ?? letztesProtokoll.Created,
                     Documents = new List<XDocument>
                     {
                         weisung.XDocument_Weisung,
                         weisung.XDocument_Mahnung1,
                         weisung.XDocument_Mahnung2,
                         weisung.XDocument_Mahnung3,
                         weisung.XDocument_Verfuegung,
                     }.Where(d => d != null),
                     Empfaenger = weisung.FaWeisung_BaPerson.Select(x => String.IsNullOrEmpty(x.BaPerson.Vorname) ? x.BaPerson.Name : (x.BaPerson.Name + ", " + x.BaPerson.Vorname)),
                     DateLabels = letztesProtokollAsList,
                 }).ToList();

            var weisungZeitachseDTO = (from weisung in faWeisung
                                       select new FaZeitachsePeriodDTO()
                                       {
                                           StartDate = weisung.Created,
                                           EndDate = weisung.AbschlussDatum,
                                           Title = weisung.Betreff,
                                           Type = FaZeitachseDTOType.Weisungen,
                                           SARName = NameVornameHelper(weisung.LastName, weisung.FirstName),
                                           Empfaenger = string.Join(",", weisung.Empfaenger),
                                           Documents = (weisung.Documents.Where(d => d.DocumentID == weisung.XDocumentID_Weisung)
                                               .Select(
                                                   d => new FaZeitachseEventDTO
                                                   {
                                                       StartDate = weisung.TerminWeisung.HasValue ? weisung.TerminWeisung.Value : d.DateCreation,
                                                       Title = "Termin",
                                                       DocFormatCode = d.DocFormatCode,
                                                       Empfaenger = string.Join(",", weisung.Empfaenger),
                                                   })
                                               .Concat(
                                                   weisung.Documents.Where(d => d.DocumentID == weisung.XDocumentID_Mahnung1)
                                               .Select(
                                                   d => new FaZeitachseEventDTO
                                                   {
                                                       StartDate = weisung.TerminMahnung1.HasValue ? weisung.TerminMahnung1.Value : d.DateCreation,
                                                       Title = "1. Mahnung",
                                                       DocFormatCode = d.DocFormatCode,
                                                       Empfaenger = string.Join(",", weisung.Empfaenger),
                                                   }))
                                               .Concat(
                                                   weisung.Documents.Where(d => d.DocumentID == weisung.XDocumentID_Mahnung2)
                                               .Select(
                                                   d => new FaZeitachseEventDTO
                                                   {
                                                       StartDate = weisung.TerminMahnung2.HasValue ? weisung.TerminMahnung2.Value : d.DateCreation,
                                                       Title = "2. Mahnung",
                                                       DocFormatCode = d.DocFormatCode,
                                                       Empfaenger = string.Join(",", weisung.Empfaenger),
                                                   }))
                                               .Concat(
                                                   weisung.Documents.Where(d => d.DocumentID == weisung.XDocumentID_Mahnung3)
                                               .Select(
                                                   d => new FaZeitachseEventDTO
                                                   {
                                                       StartDate = weisung.TerminMahnung3.HasValue ? weisung.TerminMahnung3.Value : d.DateCreation,
                                                       Title = "3. Mahnung",
                                                       DocFormatCode = d.DocFormatCode,
                                                       Empfaenger = string.Join(",", weisung.Empfaenger),
                                                   }))
                                               .Concat(
                                                   weisung.Documents.Where(d => d.DocumentID == weisung.XDocumentID_Verfuegung)
                                               .Select(
                                                   d => new FaZeitachseEventDTO
                                                   {
                                                       StartDate = weisung.DatumVerfuegung.HasValue ? weisung.DatumVerfuegung.Value : d.DateCreation,
                                                       Title = "Verfügung",
                                                       DocFormatCode = d.DocFormatCode,
                                                       Empfaenger = string.Join(",", weisung.Empfaenger),
                                                   }))
                                                       ).ToList(),
                                           DateLabels = weisung.AbschlussDatum.HasValue
                                                         ? new List<FaZeitachseEventDTO>(0)
                                                         : weisung.DateLabels.Select(
                                                           dl => new FaZeitachseEventDTO
                                                           {
                                                               StartDate = dl.Termin ?? dl.Created,
                                                               Title = dl.Aktion,
                                                               Empfaenger = string.Join(",", weisung.Empfaenger),
                                                           }).ToList(),
                                           JumpToPath =
                                               string.Format(
                                                   "ClassName=FrmFall;Action=JumpToPath;BaPersonID={0};ModulID=2;TreeNodeID=CtlFaBeratungsperiode{1}/20003/CtlFaWeisung;FaWeisungID={2};ActiveSQLQuery.Find=FaWeisungID = {2};",
                                                   baPersonId,
                                                   weisung.FaLeistungID,
                                                   weisung.FaWeisungID)
                                       }).ToList();

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

        /// <summary>
        /// Konkateniert den Vornamen und den Nachnamen.
        /// Übernimmt das Handling mit dem Komma.
        /// Gibt nie null zurück, sondern der leere String.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vorname"></param>
        /// <returns>Nachname konkateniert mit dem Vornamen.</returns>
        private string NameVornameHelper(string name, string vorname)
        {
            var nameVorname = new StringBuilder(name);
            if (!string.IsNullOrEmpty(vorname))
            {
                nameVorname.Append(", ");
                nameVorname.Append(vorname);
            }
            return nameVorname.ToString();
        }

        #endregion

        #endregion
    }
}