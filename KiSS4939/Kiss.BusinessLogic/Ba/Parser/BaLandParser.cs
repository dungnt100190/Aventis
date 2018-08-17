using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

using XDocument = System.Xml.Linq.XDocument;

using Kiss.BL.Ba.DTO;

namespace Kiss.BusinessLogic.Ba.Parser
{
    class BaLandParser : XmlParser<BaLandDTO>
    {
        #region Methods

        #region Protected Methods

        protected override IEnumerable<BaLandDTO> OnParse(XDocument xmlDoc)
        {
            return xmlDoc
                   .Elements()
                   .Elements("country")
                   .Where(country =>
                                     {
                                         var xElement = country.Element("entryValid");
                                         return xElement != null && Convert.ToBoolean(xElement.Value);
                                     })
                   .Select(country => new BaLandDTO
                                          {
                                              BfsCode = Convert.ToInt32(TryGetString(country, "id", "0")),
                                              UnID = Convert.ToInt32(TryGetString(country, "unId", "0")),
                                              Iso2Id = TryGetString(country, "iso2Id"),
                                              Iso3Id = TryGetString(country, "iso3Id"),
                                              ShortNameDe = TryGetString(country, "shortNameDe"),
                                              ShortNameFr = TryGetString(country, "shortNameFr"),
                                              ShortNameIt = TryGetString(country, "shortNameIt"),
                                              ShortNameEn = TryGetString(country, "shortNameEn"),
                                              OfficialNameDe = TryGetString(country, "officialNameDe"),
                                              OfficialNameFr = TryGetString(country, "officialNameFr"),
                                              OfficialNameIt = TryGetString(country, "officialNameIt"),
                                              Continent = Convert.ToInt32(TryGetString(country, "continent", "0")),
                                              Region = Convert.ToInt32(TryGetString(country, "region", "0")),
                                              State = Convert.ToBoolean(TryGetString(country, "state", "0")),
                                              UnMember = Convert.ToBoolean(TryGetString(country, "unMember", "0")),
                                              UnEntryDate = Convert.ToDateTime(TryGetString(country, "unEntryDate")),
                                              RecognizedCh = Convert.ToBoolean(TryGetString(country, "recognizedCh", "0")),
                                              EntryValid = Convert.ToBoolean(TryGetString(country, "entryValid", "0")),
                                              DateOfChange = Convert.ToDateTime(TryGetString(country, "dateOfChange"))
                                          });

        }

        #endregion

        #endregion
    }
}