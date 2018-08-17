using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

using Kiss.DbContext;

using XDocument = System.Xml.Linq.XDocument;


namespace Kiss.BusinessLogic.Ba.Parser
{
    class BaGemeindeParser : XmlParser<BaGemeinde>
    {
        #region Methods

        #region Protected Methods

        protected override IEnumerable<BaGemeinde> OnParse(XDocument xmlDoc)
        {
            var cantons = xmlDoc.Elements().Elements("cantons").Elements();
            var districts = xmlDoc.Elements().Elements("districts").Elements();
            var municipalities = xmlDoc.Elements().Elements("municipalities").Elements();

            var gemeinden = from municipality in municipalities
                            let district = districts.FirstOrDefault(x => ElementValueEquals(x.Element("districtHistId"), municipality.Element("districtHistId")))
                            let canton = cantons.FirstOrDefault(x => ElementValueEquals(x.Element("cantonAbbreviation"), municipality.Element("cantonAbbreviation")))
                            select new BaGemeinde
                            {
                                BFSCode = TryGetInt(municipality, "municipalityId"),
                                Name = TryGetString(municipality, "municipalityShortName"),
                                NameLang = TryGetString(municipality, "municipalityLongName"),

                                KantonID = TryGetInt(canton, "cantonId"),
                                KantonNameLang = TryGetString(canton, "cantonLongName"),
                                Kanton = TryGetString(municipality, "cantonAbbreviation"),

                                GemeindeHistorisierungID = TryGetInt(municipality, "historyMunicipalityId"),
                                GemeindeEintragArt = TryGetInt(municipality, "municipalityEntryMode"),
                                GemeindeStatus = TryGetInt(municipality, "municipalityStatus"),

                                GemeindeAufnahmeNummer = TryGetInt(municipality, "municipalityAdmissionNumber"),
                                GemeindeAufnahmeModus = TryGetInt(municipality, "municipalityAdmissionMode"),
                                GemeindeAufnahmeDatum = TryGetDateTime(municipality, "municipalityAdmissionDate"),

                                GemeindeAufhebungNummer = TryGetInt(municipality, "municipalityAbolitionNumber"),
                                GemeindeAufhebungModus = TryGetInt(municipality, "municipalityAbolitionMode"),
                                GemeindeAufhebungDatum = TryGetDateTime(municipality, "municipalityAbolitionDate"),

                                GemeindeAenderungDatum = TryGetDateTime(municipality, "municipalityDateOfChange"),

                                BezirkCode = TryGetInt(district, "districtHistId"),
                                BezirkEintragArt = TryGetInt(district, "districtEntryMode"),
                                BezirkName = TryGetString(district, "districtShortName"),
                                BezirkNameLang = TryGetString(district, "districtLongName"),

                                BezirkAufnahmeNummer = TryGetInt(district, "districtAdmissionNumber"),
                                BezirkAufnahmeModus = TryGetInt(district, "districtAdmissionMode"),
                                BezirkAufnahmeDatum = TryGetDateTime(district, "districtAdmissionDate"),

                                BezirkAufhebungNummer = TryGetInt(district, "districtAbolitionNumber"),
                                BezirkAufhebungModus = TryGetInt(district, "districtAbolitionMode"),
                                BezirkAufhebungDatum = TryGetDateTime(district, "districtAbolitionDate"),

                                BezirkAenderungDatum = TryGetDateTime(district, "districtDateOfChange"),
                            };

            return gemeinden;
        }

        #endregion

        #endregion
    }
}