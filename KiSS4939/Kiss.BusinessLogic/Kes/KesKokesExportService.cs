using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

using BIAG.AssemblyInfo;

using Kiss.BusinessLogic.LocalResources.Kes;
using Kiss.BusinessLogic.Sys;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Kes;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

using XDocument = System.Xml.Linq.XDocument;

namespace Kiss.BusinessLogic.Kes
{
    public class KesKokesExportService : Service
    {
        public static readonly XNamespace XmlNamespace = "http://www.kokes.ch/schemas/KOKES_Statistik_2013_Transfer_v1.4.xsd";
        private const string XML_GENERATOR = "KiSS";
        private readonly XLovService _xLovService;
        private IList<XLOVCode> _kesAufhebungsgrundES;
        private IList<XLOVCode> _kesAufhebungsgrundKS;
        private IList<XLOVCode> _kesBeistandsartList;

        private KesKokesExportService()
        {
            _xLovService = Container.Resolve<XLovService>();
        }

        public IServiceResult<KesKokesExportDTO> GetExportDto(KesKokesExportSearchParamDTO searchParameters)
        {
            if (searchParameters.KesBehoerde == null)
            {
                return new ServiceResult<KesKokesExportDTO>(ServiceResultType.Error, KesKokesExportServiceRes.Error_SucheKesBehoerde);
            }

            if (searchParameters.Jahr <= 0)
            {
                return new ServiceResult<KesKokesExportDTO>(ServiceResultType.Error, KesKokesExportServiceRes.Error_SucheJahr);
            }

            var jahr = searchParameters.Jahr;
            var kesBehoerdeId = searchParameters.KesBehoerde.KesBehoerdeID;
            var userId = searchParameters.XUser != null ? searchParameters.XUser.UserID : (int?)null;
            var baPersonId = searchParameters.BaPerson != null ? searchParameters.BaPerson.BaPersonID : (int?)null;

            try
            {
                using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
                {
                    var list = unitOfWork.FaLeistung.GetKesKokesExportDto(jahr, kesBehoerdeId, userId, baPersonId);
                    return new ServiceResult<KesKokesExportDTO>(list);
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult<KesKokesExportDTO>(ex, null, KesKokesExportServiceRes.Error_Allgemein);
            }
        }

        public IServiceResult<XDocument> GetExportXmlDocument(KesKokesExportDTO exportDto, int jahr)
        {
            try
            {
                _kesBeistandsartList = _xLovService.GetLovCodesByLovName("KesBeistandsart");
                _kesAufhebungsgrundES = _xLovService.GetLovCodesByLovName("KesAufhebungsgrundES");
                _kesAufhebungsgrundKS = _xLovService.GetLovCodesByLovName("KesAufhebungsgrundKS");

                // Root
                var document = GetDocumentRoot(jahr);

                // Behörden
                foreach (var behoerdeDto in exportDto.BehoerdeDTOs)
                {
                    var behoerdeElement = GetBehoerdeElement(behoerdeDto.KesBehoerde.KESBID);
                    document.Root.Add(behoerdeElement);

                    // Personen
                    foreach (var personDto in behoerdeDto.PersonDtoList)
                    {
                        var baPerson = personDto.BaPerson;
                        var kesMassnahmen = personDto.KesMassnahmen;
                        var personElement = GetPersonElement(baPerson, kesMassnahmen, exportDto, jahr);
                        behoerdeElement.Add(personElement);
                    }
                }

                if (exportDto.KesMassnahmeDTOs.Any(x => x.Fehler != null))
                {
                    return new ServiceResult<XDocument>(ServiceResultType.Error, KesKokesExportServiceRes.Error_Validierung);
                }

                return new ServiceResult<XDocument>(document);
            }
            catch (Exception ex)
            {
                return new ServiceResult<XDocument>(ex, KesKokesExportServiceRes.Error_Allgemein);
            }
        }

        public IServiceResult PerformExport(KesKokesExportDTO exportDto, int jahr, string fileName)
        {
            var result = GetExportXmlDocument(exportDto, jahr);

            if (!result.IsOk)
            {
                return result;
            }

            var document = result.Result;

            // XSD validation
            var schemaSet = new XmlSchemaSet();
            schemaSet.Add(XmlNamespace.NamespaceName, XmlReader.Create(new StringReader(KesKokesExportServiceRes.KOKES_Statistik_Xsd)));

            document.Validate(schemaSet, (s, e) => result.Add(new ServiceResult(e.Exception, null, KesKokesExportServiceRes.Error_XmlValidierung, e.Message)));

            try
            {
                result.Result.Save(fileName);
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex, null, KesKokesExportServiceRes.Error_Allgemein);
            }

            return result;
        }

        private void AddAttributeDateTimeIfNotNull(XElement element, string name, DateTime? dateTime)
        {
            if (dateTime != null)
            {
                var value = dateTime.Value.ToString("yyyy-MM-dd");
                AddAttributeIfValueIsNotNull(element, name, value);
            }
        }

        private void AddAttributeIfValueIsNotNull(XElement element, string name, object value)
        {
            if (value != null)
            {
                element.Add(new XAttribute(name, value));
            }
        }

        private XElement CreateMassnahmeElement(
            string name,
            KesKokesExportMassnahmeDTO kesMassnahmeDto,
            KesArtikel kesArtikel,
            string kesBeistandsart = null)
        {
            var kesMassnahme = kesMassnahmeDto.KesMassnahme;

            var massnahmeElement = new XElement(XmlNamespace + name, new XAttribute("MassnahmeArt", kesArtikel.CodeKokes));

            AddAttributeDateTimeIfNotNull(massnahmeElement, "Errichtung", kesMassnahme.DatumVon);

            if (kesMassnahme.IsKS)
            {
                // Urteil ist nicht im KiSS erfasst
                //massnahmeElement.Add(new XAttribute("Urteil", ""));

                // Mandatsträger
                if (!string.IsNullOrEmpty(kesBeistandsart))
                {
                    massnahmeElement.Add(new XElement(XmlNamespace + "Mandatstraeger", kesBeistandsart));
                }

                // HauptIndikation: ist im KiSS nicht erfasst. Abmachung: wenn nur 1 Ind., dann diese als Hauptind., sonst alle als Nebenind.
                var indikationen = _xLovService.GetLovCodes("KesIndikationKS", kesMassnahme.KesIndikationCodes);

                if (indikationen.Length == 1)
                {
                    massnahmeElement.Add(new XElement(XmlNamespace + "HauptIndikation", indikationen[0].Value1));
                }
                else
                {
                    // NebenIndikation
                    foreach (var xlovCode in indikationen)
                    {
                        massnahmeElement.Add(new XElement(XmlNamespace + "NebenIndikation", xlovCode.Value1));
                    }
                }
            }
            else
            {
                // Aufgabenbereich
                var aufgabenbereiche = _xLovService.GetLovCodes("KesAufgabenbereichES", kesMassnahme.KesAufgabenbereichCodes);
                if (aufgabenbereiche.Length > 0)
                {
                    foreach (var xlovCode in aufgabenbereiche)
                    {
                        //für den Aufgabenbereich ist der Mandatsträger obligatorisch
                        massnahmeElement.Add(
                            new XElement(
                                XmlNamespace + "Aufgabenbereich",
                                new XAttribute("Mandatstraeger", kesBeistandsart),
                                xlovCode.Value1));
                    }
                }
                else
                {
                    // Mandatsträger hier als Element optional
                    if (!string.IsNullOrEmpty(kesBeistandsart))
                    {
                        massnahmeElement.Add(new XElement(XmlNamespace + "Mandatstraeger", kesBeistandsart));
                    }
                }

                // Indikationen: siehe oben bei KS
                var indikationen = _xLovService.GetLovCodes("KesIndikationES", kesMassnahme.KesIndikationCodes);

                if (indikationen.Length == 1)
                {
                    massnahmeElement.Add(new XElement(XmlNamespace + "HauptIndikation", indikationen[0].Value1));
                }
                else
                {
                    foreach (var xlovCode in indikationen)
                    {
                        massnahmeElement.Add(new XElement(XmlNamespace + "NebenIndikation", xlovCode.Value1));
                    }
                }
            }

            // Gefährdungsmeldung
            var gefaehrdungsmeldungCode = kesMassnahmeDto.GefaehrdungsmeldungCode;
            if (gefaehrdungsmeldungCode != null)
            {
                massnahmeElement.Add(new XElement(XmlNamespace + "Gefaehrdungsmeldung", gefaehrdungsmeldungCode));
            }

            return massnahmeElement;
        }

        private XElement GetBehoerdeElement(string kesbId)
        {
            var behoerdeElement = new XElement(
                XmlNamespace + "Behoerde",
                new XAttribute("BehoerdeId", kesbId),
                new XAttribute("Generator", XML_GENERATOR),
                new XAttribute("GeneratorVersion", GlobalAssemblyInfo.AssemblyVersion));
            return behoerdeElement;
        }

        private XDocument GetDocumentRoot(int jahr)
        {
            var document = new XDocument();
            var root = new XElement(XmlNamespace + "Kokes", new XAttribute("StatistikJahr", jahr));
            AddAttributeDateTimeIfNotNull(root, "Erstellt", DateTime.Today);
            document.Add(root);
            return document;
        }

        private XElement GetPersonElement(BaPerson baPerson, List<KesKokesExportMassnahmeDTO> kesMassnahmen, KesKokesExportDTO exportDto, int jahr)
        {
            // Person
            var erfassung = kesMassnahmen.Min(dto => dto.KesMassnahme.DatumVon);
            var abschluss = kesMassnahmen.Max(dto => dto.KesMassnahme.DatumBis);
            var personElement = new XElement(
                XmlNamespace + "Person",
                new XAttribute("Geschlecht", baPerson.GeschlechtCode == 1 ? "M" : "F"),
                new XAttribute("Jahrgang", baPerson.Geburtsdatum.HasValue ? baPerson.Geburtsdatum.Value.Year.ToString() : ""));

            AddAttributeDateTimeIfNotNull(personElement, "Erfassung", erfassung);
            AddAttributeDateTimeIfNotNull(personElement, "Abschluss", abschluss);

            // Listen erstellen, damit XSD-Validierung eingehalten wird, da dort xsd:sequence und nicht xsd:all verwendet wird
            var exportElements = new KesKokesExportElementsDTO();

            foreach (var kesMassnahmeDto in kesMassnahmen)
            {
                var kesMassnahme = kesMassnahmeDto.KesMassnahme;
                var massnahmeListDto = exportDto.KesMassnahmeDTOs.First(dto => dto.KesMassnahme.KesMassnahmeID == kesMassnahme.KesMassnahmeID);
                massnahmeListDto.Fehler = null;

                // Validation
                if (baPerson.GeschlechtCode == null)
                {
                    massnahmeListDto.Fehler = KesKokesExportServiceRes.Error_Geschlecht;
                    break;
                }
                if (baPerson.Geburtsdatum == null)
                {
                    massnahmeListDto.Fehler = KesKokesExportServiceRes.Error_Geburtsdatum;
                    break;
                }
                if (kesMassnahme.DatumVon == null)
                {
                    massnahmeListDto.Fehler = KesKokesExportServiceRes.Error_DatumVon;
                    continue;
                }

                // Letzte im Jahr erfasste Mandatsführende Person holen falls eine gibt
                var kesMandatsfuehrendePerson = kesMassnahme.KesMandatsfuehrendePerson
                    .Where(kmp => (kmp.DatumMandatVon ?? DateTime.MinValue).Year <= jahr)
                    .OrderByDescending(kmp => (kmp.DatumMandatVon ?? DateTime.MinValue))
                    .FirstOrDefault();

                XLOVCode kesBeistandsart = null;
                if (kesMandatsfuehrendePerson != null)
                {
                    kesBeistandsart = _kesBeistandsartList.FirstOrDefault(lov => lov.Code == kesMandatsfuehrendePerson.KesBeistandsartCode);
                    if (kesBeistandsart == null)
                    {
                        massnahmeListDto.Fehler = KesKokesExportServiceRes.Error_Beistandsart;
                        continue;
                    }
                }

                foreach (var kesMassnahmeKesArtikel in kesMassnahme.KesMassnahme_KesArtikel)
                {
                    var kesArtikel = kesMassnahmeKesArtikel.KesArtikel;
                    var aufgabenbereiche = _xLovService.GetLovCodes("KesAufgabenbereichES", kesMassnahme.KesAufgabenbereichCodes);

                    // TODO: Flag oder Code für altrechtliche Artikel auf KesArtikel einführen!
                    if (kesArtikel.CodeKokes != null && kesArtikel.CodeKokes.ToLower().StartsWith("maa"))
                    {
                        // aZGB-Artikel werden nur bei bestehenden am Ende des Jahres ausgewiesen
                        if (kesMassnahme.DatumVon.Value.Year <= jahr &&
                            (kesMassnahme.DatumBis == null || kesMassnahme.DatumBis.Value.Year >= jahr) &&
                            (kesMassnahme.UebernahmeVon_Datum == null || kesMassnahme.UebernahmeVon_Datum.Value.Year <= jahr) &&
                            (kesMassnahme.UebertragungAn_Datum == null || kesMassnahme.UebertragungAn_Datum.Value.Year > jahr)
                            )
                        {
                            XElement bestehendeAlt;
                            if (kesBeistandsart != null)
                            {
                                bestehendeAlt = new XElement(
                                    XmlNamespace + "BestehendeErwachseneAlt_31.12.xxxx",
                                    new XAttribute("MassnahmeArt", kesArtikel.CodeKokes),
                                    new XAttribute("Mandatstraeger", kesBeistandsart.Value1));
                            }
                            else
                            {
                                bestehendeAlt = new XElement(
                                    XmlNamespace + "BestehendeErwachseneAlt_31.12.xxxx",
                                    new XAttribute("MassnahmeArt", kesArtikel.CodeKokes));
                            }

                            AddAttributeDateTimeIfNotNull(bestehendeAlt, "Errichtung", kesMassnahme.DatumVon);
                            exportElements.Bestehende3112ErwachseneAlt.Add(bestehendeAlt);
                        }
                        continue;
                    }

                    if (!kesArtikel.IsMassnahmeGebunden)
                    {
                        // Nicht Massnahmengebundene Geschäfte
                        var name = kesMassnahme.IsKS ? "NichtMassnahmengebundenesGeschaeftKinder" : "NichtMassnahmengebundenesGeschaeftErwachsene";
                        var nichtMassnahmeGebunden = new XElement(XmlNamespace + name, kesArtikel.CodeKokes);

                        AddAttributeDateTimeIfNotNull(nichtMassnahmeGebunden, "Beschluss", kesMassnahme.DatumVon);

                        if (kesMassnahme.IsKS)
                        {
                            exportElements.NichtMassnahmengebundeneGeschaefteKinder.Add(nichtMassnahmeGebunden);
                        }
                        else
                        {
                            exportElements.NichtMassnahmengebundeneGeschaefteErwachsene.Add(nichtMassnahmeGebunden);
                        }
                        continue;
                    }

                    if (kesMassnahme.DatumVon.Value.Year < jahr &&
                          (kesMassnahme.UebernahmeVon_Datum == null || kesMassnahme.UebernahmeVon_Datum.Value.Year < jahr) &&
                          (kesMassnahme.UebertragungAn_Datum == null || kesMassnahme.UebertragungAn_Datum.Value.Year >= jahr)
                        )
                    {
                        // Bestehende 01.01.

                        //falls Aufgabenbereich dann ist MandatsführendePerson ein Muss
                        if (kesBeistandsart == null && aufgabenbereiche.Length > 0)
                        {
                            massnahmeListDto.Fehler = KesKokesExportServiceRes.Error_KeineMandatsführendePerson;
                            continue;
                        }

                        var name = kesMassnahme.IsKS ? "BestehendeKinder_01.01.xxxx" : "BestehendeErwachsene_01.01.xxxx";
                        var bestehend = CreateMassnahmeElement(name,
                                                            kesMassnahmeDto,
                                                            kesArtikel,
                                                            (kesBeistandsart != null) ? kesBeistandsart.Value1 : null);

                        AddAttributeDateTimeIfNotNull(bestehend, "LetzteAenderung", kesMassnahme.AenderungVom_Datum);

                        if (kesMassnahme.IsKS)
                        {
                            exportElements.Bestehende0101Kinder.Add(bestehend);
                        }
                        else
                        {
                            exportElements.Bestehende0101Erwachsene.Add(bestehend);
                        }
                    }
                    else if (kesMassnahme.UebernahmeVon_Datum != null && kesMassnahme.UebernahmeVon_Datum.Value.Year == jahr)
                    {
                        // Übernahme
                        if (kesMassnahme.UebernahmeVon_KesBehoerde == null)
                        {
                            massnahmeListDto.Fehler = KesKokesExportServiceRes.Error_UebernahmeKesb;
                            continue;
                        }
                        //falls Aufgabenbereich dann ist MandatsführendePerson ein Muss
                        if (kesBeistandsart == null && aufgabenbereiche.Length > 0)
                        {
                            massnahmeListDto.Fehler = KesKokesExportServiceRes.Error_KeineMandatsführendePerson;
                            continue;
                        }

                        var name = kesMassnahme.IsKS ? "UebernahmeKinder" : "UebernahmeErwachsene";
                        var uebernahme = CreateMassnahmeElement(
                                                            name,
                                                            kesMassnahmeDto,
                                                            kesArtikel,
                                                            (kesBeistandsart != null) ? kesBeistandsart.Value1 : null);
                        AddAttributeDateTimeIfNotNull(uebernahme, "Uebernahme", kesMassnahme.UebernahmeVon_Datum);
                        uebernahme.Add(new XAttribute("VonKESB", kesMassnahme.UebernahmeVon_KesBehoerde.KESBID));

                        if (kesMassnahme.IsKS)
                        {
                            exportElements.UebernahmeKinder.Add(uebernahme);
                        }
                        else
                        {
                            exportElements.UebernahmeErwachsene.Add(uebernahme);
                        }
                    }
                    else if (kesMassnahme.DatumVon.Value.Year == jahr)
                    {
                        // Errichtung
                        //falls Aufgabenbereich dann ist MandatsführendePerson ein Muss
                        if (kesBeistandsart == null && aufgabenbereiche.Length > 0)
                        {
                            massnahmeListDto.Fehler = KesKokesExportServiceRes.Error_KeineMandatsführendePerson;
                            continue;
                        }

                        var name = kesMassnahme.IsKS ? "ErrichtungKinder" : "ErrichtungErwachsene";
                        var errichtung = CreateMassnahmeElement(
                                                            name,
                                                            kesMassnahmeDto,
                                                            kesArtikel,
                                                            (kesBeistandsart != null) ? kesBeistandsart.Value1 : null);

                        if (kesMassnahme.IsKS)
                        {
                            exportElements.ErrichtungKinder.Add(errichtung);
                        }
                        else
                        {
                            exportElements.ErrichtungErwachsene.Add(errichtung);
                        }
                    }

                    if (kesMassnahme.UebertragungAn_Datum != null && kesMassnahme.UebertragungAn_Datum.Value.Year == jahr)
                    {
                        // Übertragung
                        if (kesMassnahme.UebertragungAn_KesBehoerde == null)
                        {
                            massnahmeListDto.Fehler = KesKokesExportServiceRes.Error_UebertragungKesb;
                            continue;
                        }
                        //falls Aufgabenbereich dann ist MandatsführendePerson ein Muss
                        if (kesBeistandsart == null && aufgabenbereiche.Length > 0)
                        {
                            massnahmeListDto.Fehler = KesKokesExportServiceRes.Error_KeineMandatsführendePerson;
                            continue;
                        }

                        var name = kesMassnahme.IsKS ? "UebertragungKinder" : "UebertragungErwachsene";
                        var uebertragung = CreateMassnahmeElement(
                                                        name,
                                                        kesMassnahmeDto,
                                                        kesArtikel,
                                                        (kesBeistandsart != null) ? kesBeistandsart.Value1 : null);
                        AddAttributeDateTimeIfNotNull(uebertragung, "Uebertragung", kesMassnahme.UebertragungAn_Datum);
                        uebertragung.Add(new XAttribute("AnKESB", kesMassnahme.UebertragungAn_KesBehoerde.KESBID));

                        if (kesMassnahme.IsKS)
                        {
                            exportElements.UebertragungKinder.Add(uebertragung);
                        }
                        else
                        {
                            exportElements.UebertragungErwachsene.Add(uebertragung);
                        }
                    }
                    else if (kesMassnahme.DatumVon.Value.Year <= jahr &&
                            (kesMassnahme.DatumBis == null || kesMassnahme.DatumBis.Value.Year > jahr) &&
                            (kesMassnahme.UebernahmeVon_Datum == null || kesMassnahme.UebernahmeVon_Datum.Value.Year <= jahr) &&
                            (kesMassnahme.UebertragungAn_Datum == null || kesMassnahme.UebertragungAn_Datum.Value.Year > jahr))
                    {
                        // Bestehende 31.12.
                        //falls Aufgabenbereich dann ist MandatsführendePerson ein Muss
                        if (kesBeistandsart == null && aufgabenbereiche.Length > 0)
                        {
                            massnahmeListDto.Fehler = KesKokesExportServiceRes.Error_KeineMandatsführendePerson;
                            continue;
                        }
                        var name = kesMassnahme.IsKS ? "BestehendeKinder_31.12.xxxx" : "BestehendeErwachsene_31.12.xxxx";
                        var bestehend = CreateMassnahmeElement(
                                                        name,
                                                        kesMassnahmeDto,
                                                        kesArtikel,
                                                        (kesBeistandsart != null) ? kesBeistandsart.Value1 : null);

                        if (kesMassnahme.IsKS)
                        {
                            exportElements.Bestehende3112Kinder.Add(bestehend);
                        }
                        else
                        {
                            exportElements.Bestehende3112Erwachsene.Add(bestehend);
                        }
                    }

                    if (kesMassnahme.DatumBis != null && kesMassnahme.DatumBis.Value.Year == jahr)
                    {
                        //falls Aufgabenbereich dann ist MandatsführendePerson ein Muss
                        if (kesBeistandsart == null && aufgabenbereiche.Length > 0)
                        {
                            massnahmeListDto.Fehler = KesKokesExportServiceRes.Error_KeineMandatsführendePerson;
                            continue;
                        }
                        var name = kesMassnahme.IsKS ? "AufhebungKinder" : "AufhebungErwachsene";
                        var aufhebung = CreateMassnahmeElement(
                                                        name,
                                                        kesMassnahmeDto,
                                                        kesArtikel,
                                                        (kesBeistandsart != null) ? kesBeistandsart.Value1 : null);
                        AddAttributeDateTimeIfNotNull(aufhebung, "Aufhebung", kesMassnahme.DatumBis);

                        if (kesMassnahme.IsKS)
                        {
                            var aufhebungsgrund = _kesAufhebungsgrundKS.First(lov => lov.Code == kesMassnahme.KesAufhebungsgrundCode);
                            aufhebung.Add(new XAttribute("Grund", aufhebungsgrund.Value1));
                            exportElements.AufhebungKinder.Add(aufhebung);
                        }
                        else
                        {
                            var aufhebungsgrund = _kesAufhebungsgrundES.First(lov => lov.Code == kesMassnahme.KesAufhebungsgrundCode);
                            aufhebung.Add(new XAttribute("Grund", aufhebungsgrund.Value1));
                            exportElements.AufhebungErwachsene.Add(aufhebung);
                        }
                    }

                    // Änderung
                    var mandatsführendAenderung = kesMassnahme
                        .KesMandatsfuehrendePerson
                        .Where(kmp => kmp.DatumMandatVon.HasValue && kmp.DatumMandatVon.Value.Year == jahr)
                        .ToList();

                    foreach (var mandatsfuehrendePerson in mandatsführendAenderung)
                    {
                        var name = kesMassnahme.IsKS ? "AenderungKinder" : "AenderungErwachsene";
                        var aenderung = new XElement(
                            XmlNamespace + name,
                            new XAttribute("MassnahmeArt", kesArtikel.CodeKokes));
                        AddAttributeDateTimeIfNotNull(aenderung, "Aenderung", mandatsfuehrendePerson.DatumMandatVon);
                        var beistandsart = _kesBeistandsartList.FirstOrDefault(lov => lov.Code == mandatsfuehrendePerson.KesBeistandsartCode);
                        if (beistandsart == null)
                        {
                            massnahmeListDto.Fehler = KesKokesExportServiceRes.Error_Beistandsart;
                            continue;
                        }

                        var aenderungMandatstraeger = new XElement(XmlNamespace + "Mandatstraeger", beistandsart.Value1);
                        aenderung.Add(aenderungMandatstraeger);

                        if (kesMassnahme.IsKS)
                        {
                            exportElements.AenderungKinder.Add(aenderung);
                        }
                        else
                        {
                            exportElements.AenderungErwachsene.Add(aenderung);
                        }
                    }
                }
            }

            // die Elemente der Person anhängen
            exportElements.AddElementsToPerson(personElement);
            return personElement;
        }
    }
}