using System;
using System.Collections.Generic;
using System.Linq;

using KiSS4.DB;
using KiSS4.Schnittstellen.Newod.Converter;
using KiSS4.Schnittstellen.Newod.DTO;

using KiSS.Newod;

using BIAG.Common.Helpers;
using BIAG.Common.Web;

namespace KiSS4.Schnittstellen.Newod.Service
{
    public class NewodService
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        readonly MI_CheckPersonOutService _checkPersonService = new MI_CheckPersonOutService();
        readonly MI_GetMutationenOutService _getMutationenService = new MI_GetMutationenOutService();
        readonly MI_GetPersonMulti_eChOutService _getPersonService = new MI_GetPersonMulti_eChOutService();
        readonly MI_MarkPersonOutService _markPersonService = new MI_MarkPersonOutService();
        readonly Dictionary<string, NewodPerson> _personCache = new Dictionary<string, NewodPerson>();

        // generated Service Clients
        readonly MI_SearchPerson_OutService _searchPersonService = new MI_SearchPerson_OutService();

        const string CHECK_PERSON_QUERY = @"?channel=:KISS:CC_SOAP_KISS_CP_SENDER&amp;version=3.0&amp;Sender.Service=KISS&amp;Interface=http%3A%2F%2Fsap.ch%2FXI%2Fcra%5EMI_CheckPersonOut";
        const string GET_MUTATIONEN_QUERY = @"?channel=:KISS:CC_SOAP_KISS_GM_SENDER&amp;version=3.0&amp;Sender.Service=KISS&amp;Interface=http%3A%2F%2Fsap.ch%2FeCH%5EMI_GetMutationenOut";
        const string GET_PERSON_QUERY = @"?channel=:KISS:CC_SOAP_KISS_GP_SENDER&amp;version=3.0&amp;Sender.Service=KISS&amp;Interface=http%3A%2F%2Fsap.ch%2FeCH%5EMI_GetPersonMulti_eChOut";
        const string MARK_PERSON_QUERY = @"?channel=:KISS:CC_SOAP_KISS_MP_SENDER&amp;version=3.0&amp;Sender.Service=KISS&amp;Interface=http%3A%2F%2Fsap.ch%2FXI%2Fcra%5EMI_MarkPersonOut";

        // URI Query parameters
        const string SEARCH_PERSON_QUERY = @"?channel=:KISS:CC_SOAP_KISS_SP_SENDER&amp;version=3.0&amp;Sender.Service=KISS&amp;Interface=http%3A%2F%2Fbern.ch%5EMI_SearchPerson_Out";
        const string SERVICE_PATH = @"XISOAPAdapter/MessageServlet";

        #endregion

        #endregion

        #region Constructors

        public NewodService(string uri, string username, string password, string proxy, int timeout)
        {
            var searchPersonQuery = DBUtil.GetConfigString(@"System\Schnittstelle\NEWOD\Server\QueryPersonenSuche", SEARCH_PERSON_QUERY);
            var getPersonQuery = DBUtil.GetConfigString(@"System\Schnittstelle\NEWOD\Server\QueryPersonImportieren", GET_PERSON_QUERY);
            var getMutationenQuery = DBUtil.GetConfigString(@"System\Schnittstelle\NEWOD\Server\QueryMutationenAbholen", GET_MUTATIONEN_QUERY);
            var markPersonQuery = DBUtil.GetConfigString(@"System\Schnittstelle\NEWOD\Server\QueryPersonMarkieren", MARK_PERSON_QUERY);
            var checkPersonQuery = DBUtil.GetConfigString(@"System\Schnittstelle\NEWOD\Server\QueryPersonenPruefen", CHECK_PERSON_QUERY);
            var servicePath = DBUtil.GetConfigString(@"System\Schnittstelle\NEWOD\Server\ServicePfad", SERVICE_PATH);

            var si = new ServiceInitializer(uri, servicePath, username, password, proxy, timeout);

            si.InitService(_searchPersonService, searchPersonQuery);
            si.InitService(_getPersonService, getPersonQuery);
            si.InitService(_getMutationenService, getMutationenQuery);
            si.InitService(_markPersonService, markPersonQuery);
            si.InitService(_checkPersonService, checkPersonQuery);
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Clear the local cache containing instances of <see cref="NewodPerson"/>
        /// </summary>
        public void ClearCache()
        {
            _personCache.Clear();
        }

        public List<NewodPerson> GetMultiplePerson(GetPersonRequest[] personRequests, int maxCount, bool noCache)
        {
            int blockSize = DBUtil.GetConfigInt(@"System\Schnittstelle\NEWOD\Services\GetPerson\PaketGroesse", 10);

            List<NewodPerson> lst = new List<NewodPerson>();

            GetPersonRequest[] requests = RetrievePersonsFromCache(personRequests, lst, maxCount);

            if (maxCount <= 0 || lst.Count < maxCount)
            {
                // split the array of id's to call several times GetMultiplePerson() - a single calls leads to timeouts
                ArraySlicer<GetPersonRequest> slicer = new ArraySlicer<GetPersonRequest>(requests, blockSize, maxCount - lst.Count);

                while (slicer.HasMoreItems)
                {
                    lst.AddRange(GetMultiplePersonFromSAP(slicer.GetNextBlock(), noCache));
                }
            }

            return lst;
        }

        /// <summary>
        /// Holt die NEWOD-Mutationen die seit dem Datum <paramref name="validFrom"/> erfolgten
        /// </summary>
        /// <param name="validFrom">Datum des letzten Mutationslauf</param>
        /// <param name="validTo">neuer Timestamp der bei uns gespeichert werden muss um nächstes Mal es senden</param>
        /// <returns>Array von <see cref="GetPersonRequest"/> die die Mutationen beinhaltet</returns>
        public GetPersonRequest[] GetMutationenAsRequest(string validFrom, out string validTo)
        {
            DT_GetMutationRequest request = new DT_GetMutationRequest { Receiver = "KISS", ValidFrom = validFrom };
            var result = _getMutationenService.MI_GetMutationenOut(request);
            validTo = result.ValidTo;
            return SAPConverter.ConvertFromSap(result.Bpartners);
        }

        /// <summary>
        /// Get the Person data by the Persons ID
        /// </summary>
        /// <param name="req"></param>
        /// <param name="noCache"></param>
        /// <returns></returns>
        public NewodPerson GetPerson(GetPersonRequest req, bool noCache)
        {
            if (req.ID == null)
            {
                throw new ArgumentNullException("req", "req.ID darf nicht null sein.");
            }

            // Request is copied because it could be changed!
            var personRequest = new GetPersonRequest
                              {
                                  ID = req.ID,
                                  Mutationsart = req.Mutationsart,
                                  ValidFrom = req.ValidFrom,
                                  ValidFromSpecified = req.ValidFromSpecified
                              };
            if (!noCache)
            {
                NewodPerson person = GetPersonFromCache(personRequest.ID);
                if (person != null)
                {
                    return person;
                }
            }

            var lst = GetMultiplePersonFromSAP(new List<GetPersonRequest> { personRequest }.ToArray(), false);
            if (lst.Any())
            {
                return lst.First();
            }

            throw new ArgumentException(string.Format("Es wurde keine Person mit der Newod-Nummer: {0} gefunden!", req.ID));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mark">a mark mask</param>
        public void Mark(string id, Markflags mark)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("Die übergebene Newod-Id ist nicht gültig!");
            }

            string personId = id.Trim();
            DT_RETURNCODE[] response = _markPersonService.MI_MarkPersonOut(
                SAPConverter.ConvertToSap(personId, mark));
            if (!response.Any())
            {
                throw new Exception(string.Format("Keine gültige Antwort bei Markierungslauf mit Newod-ID {0} erhalten!", id));
            }

            if (response.First().ReturnCode != "S")
            {
                throw new ApplicationException(response[0].ReturnMessage);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="kissOk">sets KiSS_OK = true</param>
        public void MarkKiss(string[] ids, Markflags kissOk)
        {
            /// TODO: Eigener Konfigwert
            int blockSize = DBUtil.GetConfigInt(@"System\Schnittstelle\NEWOD\Services\GetPerson\PaketGroesse", 10);

            if (ids == null)
            {
                throw new ArgumentNullException("ids");
            }

            // split the array of id's to call several times GetMultiplePerson() - a single calls leads to timeouts
            ArraySlicer<string> slicer = new ArraySlicer<string>(ids, blockSize);

            while (slicer.HasMoreItems)
            {
                DT_RETURNCODE[] response = _markPersonService.MI_MarkPersonOut(
                                SAPConverter.ConvertToSap(slicer.GetNextBlock(), kissOk));

                if (response[0].ReturnCode != "S")
                {
                    throw new ApplicationException(response[0].ReturnMessage);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria">The search criterias</param>
        /// <param name="maxCount">Max count of matches. Set 0 or a negativ value to return all matches</param>
        /// <param name="totalMatches">the total number of found matches</param>
        /// <returns>The result list.</returns>
        public List<NewodPerson> SearchPerson(PersonSearchCriteria criteria, int maxCount, out int totalMatches)
        {
            int criteriaCount;

            if (criteria == null)
            {
                throw new ArgumentNullException("criteria");
            }

            criteria.Trim();
            DT_SearchPerson_Request request = SAPConverter.ConvertToSap(criteria, out criteriaCount);

            // search using webservice
            string[] personIDs = _searchPersonService.MI_SearchPerson_Out(request);

            if (personIDs.Length > maxCount)
            {
                throw new ApplicationException(
                    String.Format("Die NEWOD Suche lieferte mehr als {0} Treffer. Bitte schränken Sie die Trefferliste ein", maxCount));
            }

            GetPersonRequest[] personRequests = SAPConverter.ConvertFromSap(personIDs);
            totalMatches = personIDs.Length;
            return GetMultiplePerson(personRequests, maxCount, false);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the multiple person from SAP.
        /// </summary>
        /// <param name="personRequests">The person requests.</param>
        /// <param name="noCache"></param>
        /// <returns></returns>
        private List<NewodPerson> GetMultiplePersonFromSAP(GetPersonRequest[] personRequests, bool noCache)
        {
            if (personRequests == null)
            {
                throw new ArgumentNullException("personRequests");
            }

            if (personRequests.Length == 0)
            {
                return new List<NewodPerson>();
            }

            var bpartners = new List<DT_GetPersonRequestBpartners>();
            foreach (GetPersonRequest item in personRequests)
            {
                if (string.IsNullOrWhiteSpace(item.ID))
                {
                    throw new ArgumentException("Keine gültige Newod-Nummer vorhanden!");
                }

                string personId = item.ID.Trim();
                var requestBpartner = new DT_GetPersonRequestBpartners { Bpartner = personId };
                if (item.Mutationsart != null)
                {
                    requestBpartner.MutArt = item.Mutationsart;
                }

                if (item.ValidFromSpecified)
                {
                    requestBpartner.ValidFrom = item.ValidFrom;
                    requestBpartner.ValidFromSpecified = true;
                }

                bpartners.Add(requestBpartner);
            }

            DT_eChRootPersonRoot[] result = _getPersonService.MI_GetPersonMulti_eChOut(new DT_GetPersonRequest { Bpartners = bpartners.ToArray() });
            var lst = new List<NewodPerson>();
            foreach (DT_eChRootPersonRoot p in result)
            {
                NewodPerson person = SAPConverter.ConvertFromSap(p);
                if (!noCache)
                {
                    _personCache.Add(person.ID, person);
                }

                lst.Add(person);
            }

            return lst;
        }

        private NewodPerson GetPersonFromCache(string id)
        {
            if (_personCache.ContainsKey(id))
            {
                return _personCache[id];
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personRequests">Person IDs</param>
        /// <param name="lst">the list to be filled</param>
        /// <param name="maxItems">max. number of items. Less or equal 0 : no limit</param>
        /// <returns>an array of Person IDs not found in the cache</returns>
        private GetPersonRequest[] RetrievePersonsFromCache(GetPersonRequest[] personRequests, List<NewodPerson> lst, int maxItems)
        {
            List<GetPersonRequest> listNotFoundRequests = new List<GetPersonRequest>();
            foreach (GetPersonRequest item in personRequests)
            {
                NewodPerson person = null;
                if (maxItems <= 0 || lst.Count < maxItems)
                {
                    person = GetPersonFromCache(item.ID);
                }

                if (person != null)
                {
                    lst.Add(person);
                }

                else
                {
                    listNotFoundRequests.Add(item);
                }
            }

            return listNotFoundRequests.ToArray();
        }

        #endregion

        #endregion
    }
}