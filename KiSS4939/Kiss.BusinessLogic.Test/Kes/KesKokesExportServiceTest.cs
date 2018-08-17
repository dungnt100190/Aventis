using System;
using System.Collections.Generic;
using System.Xml.Linq;

using Kiss.BusinessLogic.Kes;
using Kiss.BusinessLogic.LocalResources.Kes;
using Kiss.DataAccess.Sys;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Kes;
using Kiss.Infrastructure.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using XDocument = System.Xml.Linq.XDocument;

namespace Kiss.BusinessLogic.Test.Kes
{
    [TestClass]
    public class KesKokesExportServiceTest
    {
        private readonly KesKokesExportService _service;
        private BaPerson _baPerson;
        private FaLeistung _faLeistung;
        private KesArtikel _kesArtikel;
        private KesBehoerde _kesBehoerde;
        private KesMandatsfuehrendePerson _kesMandatsfuehrendePerson;
        private KesMassnahme _kesMassnahme;
        private KesMassnahme_KesArtikel _kesMassnahmeKesArtikel;

        public KesKokesExportServiceTest()
        {
            _service = Container.Resolve<KesKokesExportService>();
        }

        [TestMethod]
        public void GetExportXmlDocument__Nok()
        {
            var exportDto = GetExportDtoWithSingleMassnahme();
            _kesMassnahme.UebertragungAn_Datum = new DateTime(DateTime.Today.Year, 3, 1);

            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            Assert.IsFalse(result.IsOk, result.GetTechnicalDetails());
            Assert.AreEqual(KesKokesExportServiceRes.Error_UebertragungKesb, exportDto.KesMassnahmeDTOs[0].Fehler);
        }

        [TestMethod]
        public void GetExportXmlDocument_AenderungImErhebungsjahr_Ok()
        {
            // Arrange
            var exportDto = GetExportDtoWithSingleMassnahme();
            var mandatsfuehrendePerson = new KesMandatsfuehrendePerson
            {
                KesMandatsfuehrendePersonID = 2,
                DatumMandatVon = new DateTime(DateTime.Today.Year, 7, 1),
                KesMassnahme = _kesMassnahme,
                KesBeistandsartCode = 2
            };
            _kesMassnahme.KesMandatsfuehrendePerson.Add(mandatsfuehrendePerson);

            // Ace
            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            // Assert
            Assert.IsTrue(result.IsOk, result.GetTechnicalDetails());
            Assert.IsNotNull(result.Result);
            var nodes = GetPersonElement(result.Result).Elements(KesKokesExportService.XmlNamespace + "AenderungErwachsene");

            var aenderungPerson1 = false;
            var aenderungPerson2 = false;
            foreach (var xElement in nodes)
            {
                var aenderung = xElement.Attribute("Aenderung").Value;
                if (aenderung == _kesMandatsfuehrendePerson.DatumMandatVon.Value.ToString("yyyy-MM-dd"))
                {
                    aenderungPerson1 = true;
                }
                if (aenderung == mandatsfuehrendePerson.DatumMandatVon.Value.ToString("yyyy-MM-dd"))
                {
                    aenderungPerson2 = true;
                }
            }
            Assert.IsTrue(aenderungPerson1, "Die erste Änderung wurde nicht ausgewiesen");
            Assert.IsTrue(aenderungPerson2, "Die zweite Änderung wurde nicht ausgewiesen");
        }

        [TestMethod]
        public void GetExportXmlDocument_AenderungVorErhebungsjahr_Ok()
        {
            // Arrange
            var exportDto = GetExportDtoWithSingleMassnahme();
            var mandatsfuehrendePerson = new KesMandatsfuehrendePerson
            {
                KesMandatsfuehrendePersonID = 2,
                DatumMandatVon = new DateTime(DateTime.Today.Year - 1, 7, 1),
                KesMassnahme = _kesMassnahme,
                KesBeistandsartCode = 2
            };
            _kesMassnahme.KesMandatsfuehrendePerson.Add(mandatsfuehrendePerson);

            // Ace
            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            // Assert
            Assert.IsTrue(result.IsOk, result.GetTechnicalDetails());
            Assert.IsNotNull(result.Result);
            var nodes = GetPersonElement(result.Result).Elements(KesKokesExportService.XmlNamespace + "AenderungErwachsene");

            var aenderungPerson1 = false;
            var aenderungPerson2 = false;
            foreach (var xElement in nodes)
            {
                var aenderung = xElement.Attribute("Aenderung").Value;
                if (aenderung == _kesMandatsfuehrendePerson.DatumMandatVon.Value.ToString("yyyy-MM-dd"))
                {
                    aenderungPerson1 = true;
                }
                if (aenderung == mandatsfuehrendePerson.DatumMandatVon.Value.ToString("yyyy-MM-dd"))
                {
                    aenderungPerson2 = true;
                }
            }
            Assert.IsTrue(aenderungPerson1, "Die Änderung im Erhebungsjahr wurde nicht ausgewiesen");
            Assert.IsFalse(aenderungPerson2, "Die Änderung vor dem Erhebungsjahr wurde ausgewiesen");
        }

        [TestMethod]
        public void GetExportXmlDocument_Aufhebung_Ok()
        {
            // Arrange
            var exportDto = GetExportDtoWithSingleMassnahme();
            _kesMassnahme.DatumBis = new DateTime(DateTime.Today.Year, 7, 1);
            _kesMassnahme.KesAufhebungsgrundCode = 1;

            // Ace
            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            // Assert
            Assert.IsTrue(result.IsOk, result.GetTechnicalDetails());
            Assert.IsNotNull(result.Result, "Das Dokument wurde nicht erstellt");
            var massnahmeElement = GetPersonElement(result.Result).Element(KesKokesExportService.XmlNamespace + "AufhebungErwachsene");
            Assert.IsNotNull(massnahmeElement, "Massnahme konnte nicht gefunden werden");
        }

        [TestMethod]
        public void GetExportXmlDocument_Bestehend0101_Ok()
        {
            // Arrange
            var exportDto = GetExportDtoWithSingleMassnahme();
            _kesMassnahme.DatumVon = new DateTime(DateTime.Now.Year - 1, 1, 1);

            // Ace
            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            // Assert
            Assert.IsTrue(result.IsOk, result.GetTechnicalDetails());
            Assert.IsNotNull(result.Result, "Das Dokument wurde nicht erstellt");
            var massnahmeElement = GetPersonElement(result.Result).Element(KesKokesExportService.XmlNamespace + "BestehendeErwachsene_01.01.xxxx");
            Assert.IsNotNull(massnahmeElement, "Keine Massnahme gefunden");
            Assert.AreEqual(_kesMassnahme.DatumVon.Value.ToString("yyyy-MM-dd"), massnahmeElement.Attribute("Errichtung").Value);
        }

        [TestMethod]
        public void GetExportXmlDocument_Bestehend1231_Ok()
        {
            // Arrange
            var exportDto = GetExportDtoWithSingleMassnahme();

            // Ace
            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            // Assert
            Assert.IsTrue(result.IsOk, result.GetTechnicalDetails());
            Assert.IsNotNull(result.Result, "Das Dokument wurde nicht erstellt");
            var massnahmeElement = GetPersonElement(result.Result).Element(KesKokesExportService.XmlNamespace + "BestehendeErwachsene_31.12.xxxx");
            Assert.IsNotNull(massnahmeElement, "Keine Massnahme gefunden");
            Assert.AreEqual(_kesMassnahme.DatumVon.Value.ToString("yyyy-MM-dd"), massnahmeElement.Attribute("Errichtung").Value);
        }

        [TestMethod]
        public void GetExportXmlDocument_Errichtung_Ok()
        {
            // Arrange
            var exportDto = GetExportDtoWithSingleMassnahme();

            // Ace
            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            // Assert
            Assert.IsTrue(result.IsOk, result.GetTechnicalDetails());
            Assert.IsNotNull(result.Result);
            var errichtungNode = GetPersonElement(result.Result).Element(KesKokesExportService.XmlNamespace + "ErrichtungErwachsene");
            Assert.IsNotNull(errichtungNode);
            Assert.AreEqual(_kesMassnahme.DatumVon.Value.ToString("yyyy-MM-dd"), errichtungNode.Attribute("Errichtung").Value);
            Assert.AreEqual(_kesArtikel.CodeKokes, errichtungNode.Attribute("MassnahmeArt").Value);
        }

        [TestMethod]
        public void GetExportXmlDocument_KeinDatumVon_Nok()
        {
            var exportDto = GetExportDtoWithSingleMassnahme();
            _kesMassnahme.DatumVon = null;

            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            Assert.IsFalse(result.IsOk, result.GetTechnicalDetails());
            Assert.AreEqual(KesKokesExportServiceRes.Error_DatumVon, exportDto.KesMassnahmeDTOs[0].Fehler);
        }

        [TestMethod]
        public void GetExportXmlDocument_KeinGeburtsdatum_Nok()
        {
            var exportDto = GetExportDtoWithSingleMassnahme();
            _baPerson.Geburtsdatum = null;

            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            Assert.IsFalse(result.IsOk, result.GetTechnicalDetails());
            Assert.AreEqual(KesKokesExportServiceRes.Error_Geburtsdatum, exportDto.KesMassnahmeDTOs[0].Fehler);
        }

        [TestMethod]
        public void GetExportXmlDocument_KeinGeschlecht_Nok()
        {
            var exportDto = GetExportDtoWithSingleMassnahme();
            _baPerson.GeschlechtCode = null;

            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            Assert.IsFalse(result.IsOk, result.GetTechnicalDetails());
            Assert.AreEqual(KesKokesExportServiceRes.Error_Geschlecht, exportDto.KesMassnahmeDTOs[0].Fehler);
        }

        [TestMethod]
        public void GetExportXmlDocument_KeinMandatstraeger_Nok()
        {
            var exportDto = GetExportDtoWithSingleMassnahme();
            _kesMassnahme.KesMandatsfuehrendePerson.Clear();

            //mit Aufgabenbereich ist Mandatsführende Person obligatorisch
            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            Assert.IsFalse(result.IsOk, "Validierungsfehler erwartet");
            Assert.AreEqual(KesKokesExportServiceRes.Error_KeineMandatsführendePerson, exportDto.KesMassnahmeDTOs[0].Fehler);

            //ohne Aufgabenbreich ist Mandatsführende Person optional
            _kesMassnahme.KesAufgabenbereichCodes = string.Empty;

            result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);
            Assert.IsTrue(result.IsOk, "Keine Fehler erwartet");
        }

        [TestMethod]
        public void GetExportXmlDocument_KeinMandatstraegerTyp_Nok()
        {
            var exportDto = GetExportDtoWithSingleMassnahme();
            _kesMandatsfuehrendePerson.KesBeistandsartCode = null;

            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            Assert.IsFalse(result.IsOk, "Validierungsfehler erwartet");
            Assert.AreEqual(KesKokesExportServiceRes.Error_Beistandsart, exportDto.KesMassnahmeDTOs[0].Fehler);
        }

        [TestMethod]
        public void GetExportXmlDocument_NichtBestehend1231_Ok()
        {
            // Arrange
            var exportDto = GetExportDtoWithSingleMassnahme();
            _kesMassnahme.DatumBis = new DateTime(DateTime.Today.Year, 7, 1);
            _kesMassnahme.KesAufhebungsgrundCode = 1;

            // Ace
            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            // Assert
            Assert.IsTrue(result.IsOk, result.GetTechnicalDetails());
            Assert.IsNotNull(result.Result, "Das Dokument wurde nicht erstellt");
            var massnahmeElement = GetPersonElement(result.Result).Element(KesKokesExportService.XmlNamespace + "BestehendeErwachsene_31.12.xxxx");
            Assert.IsNull(massnahmeElement, "Massnahme sollte nicht gefunden werden");
        }

        [TestMethod]
        public void GetExportXmlDocument_Uebernahme_KesbFehlt_Nok()
        {
            var exportDto = GetExportDtoWithSingleMassnahme();
            _kesMassnahme.UebernahmeVon_Datum = new DateTime(DateTime.Today.Year, 3, 1);

            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            Assert.IsFalse(result.IsOk, result.GetTechnicalDetails());
            Assert.AreEqual(KesKokesExportServiceRes.Error_UebernahmeKesb, exportDto.KesMassnahmeDTOs[0].Fehler);
        }

        [TestMethod]
        public void GetExportXmlDocument_Uebernahme_Ok()
        {
            var exportDto = GetExportDtoWithSingleMassnahme();
            _kesMassnahme.UebernahmeVon_Datum = new DateTime(DateTime.Today.Year, 3, 1);
            _kesMassnahme.UebernahmeVon_KesBehoerde = _kesBehoerde;

            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            Assert.IsTrue(result.IsOk, result.GetTechnicalDetails());
            Assert.IsNotNull(result.Result);
            var massnahmeNode = GetPersonElement(result.Result).Element(KesKokesExportService.XmlNamespace + "UebernahmeErwachsene");
            Assert.IsNotNull(massnahmeNode);
            Assert.AreEqual(_kesBehoerde.KESBID, massnahmeNode.Attribute("VonKESB").Value);
            Assert.AreEqual(_kesMassnahme.UebernahmeVon_Datum.Value.ToString("yyyy-MM-dd"), massnahmeNode.Attribute("Uebernahme").Value);
        }

        [TestMethod]
        public void GetExportXmlDocument_Uebertragung_KesbFehlt_Nok()
        {
            var exportDto = GetExportDtoWithSingleMassnahme();
            _kesMassnahme.UebertragungAn_Datum = new DateTime(DateTime.Today.Year, 3, 1);

            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            Assert.IsFalse(result.IsOk, result.GetTechnicalDetails());
            Assert.AreEqual(KesKokesExportServiceRes.Error_UebertragungKesb, exportDto.KesMassnahmeDTOs[0].Fehler);
        }

        [TestMethod]
        public void GetExportXmlDocument_Uebertragung_Ok()
        {
            var exportDto = GetExportDtoWithSingleMassnahme();
            _kesMassnahme.UebertragungAn_Datum = new DateTime(DateTime.Today.Year, 3, 1);
            _kesMassnahme.UebertragungAn_KesBehoerde = _kesBehoerde;

            var result = _service.GetExportXmlDocument(exportDto, DateTime.Today.Year);

            Assert.IsTrue(result.IsOk, result.GetTechnicalDetails());
            Assert.IsNotNull(result.Result);
            var massnahmeNode = GetPersonElement(result.Result).Element(KesKokesExportService.XmlNamespace + "UebertragungErwachsene");
            Assert.IsNotNull(massnahmeNode);
            Assert.AreEqual(_kesBehoerde.KESBID, massnahmeNode.Attribute("AnKESB").Value);
            Assert.AreEqual(_kesMassnahme.UebertragungAn_Datum.Value.ToString("yyyy-MM-dd"), massnahmeNode.Attribute("Uebertragung").Value);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            var uowMock = new UnitOfWorkMock();
            var xLovCodeRepository = new Mock<XLovCodeRepository>();
            xLovCodeRepository.Setup(moq => moq.GetLovCodeByLovName(It.Is<string>(x => x == "KesBeistandsart"), It.IsAny<int>()))
                .Returns(
                    new List<XLOVCode>
                    {
                        new XLOVCode
                        {
                            LOVName = "KesBeistandsart",
                            Code = 1,
                            Text = "Privatperson",
                            Value1 = "M010"
                        },
                        new XLOVCode
                        {
                            LOVName = "KesBeistandsart",
                            Code = 2,
                            Text = "Berufsbeistand",
                            Value1 = "M030"
                        },
                        new XLOVCode
                        {
                            LOVName = "KesBeistandsart",
                            Code = 3,
                            Text = "Fachbeistand",
                            Value1 = "M020"
                        },
                    });
            xLovCodeRepository.Setup(moq => moq.GetLovCodeByLovName(It.Is<string>(x => x.StartsWith("KesAufhebungsgrund")), It.IsAny<int>()))
                .Returns(
                    new List<XLOVCode>
                    {
                        new XLOVCode
                        {
                            LOVName = "KesAufhebungsgrundES",
                            Code = 1,
                            Text = "Wegfall Errichtungsgrund",
                            Value1 = "AHGE010"
                        }
                    });
            xLovCodeRepository.Setup(moq => moq.GetLovCodeByLovName(It.Is<string>(x => x.StartsWith("KesAufgabenbereich")), It.IsAny<int>()))
                .Returns(
                    new List<XLOVCode>
                    {
                        new XLOVCode
                        {
                            LOVName = "KesAufgabenbereichES",
                            Code = 1,
                            Text = "Wohnen",
                            Value1 = "AB010"
                        },
                        new XLOVCode
                        {
                            LOVName = "KesAufgabenbereichES",
                            Code = 2,
                            Text = "Gesundheit",
                            Value1 = "AB020"
                        }
                    });
            uowMock.RegisterRepository(uow => uow.XLovCode, xLovCodeRepository.Object);
        }

        private KesKokesExportDTO GetExportDtoWithSingleMassnahme()
        {
            _kesBehoerde = new KesBehoerde
            {
                KesBehoerdeID = 1,
                KESBID = "AG-01",
                Kanton = "AG",
                KESBName = "Bezirksgericht Aarau, Abteilung Familiengericht",
                IsActive = true,
            };
            _baPerson = new BaPerson
            {
                BaPersonID = 1,
                Geburtsdatum = new DateTime(2000, 1, 1),
                GeschlechtCode = 1
            };
            _faLeistung = new FaLeistung
            {
                FaLeistungID = 1,
                ModulID = 29,
                BaPerson = _baPerson
            };
            _kesMassnahme = new KesMassnahme
            {
                KesMassnahmeID = 1,
                DatumVon = new DateTime(DateTime.Today.Year, 1, 1),
                Zustaendig_KesBehoerde = _kesBehoerde,
                FaLeistung = _faLeistung,
                KesAufgabenbereichCodes = "1,2"
            };
            _kesArtikel = new KesArtikel
            {
                KesArtikelID = 1,
                CodeKokes = "MAE010",
                IsMassnahmeGebunden = true
            };
            _kesMassnahmeKesArtikel = new KesMassnahme_KesArtikel
            {
                KesMassnahme = _kesMassnahme,
                KesArtikel = _kesArtikel
            };
            _kesMassnahme.KesMassnahme_KesArtikel.Add(_kesMassnahmeKesArtikel);
            _kesMandatsfuehrendePerson = new KesMandatsfuehrendePerson
            {
                KesMandatsfuehrendePersonID = 1,
                KesMassnahme = _kesMassnahme,
                DatumMandatVon = new DateTime(DateTime.Today.Year, 1, 1),
                KesBeistandsartCode = 1
            };
            _kesMassnahme.KesMandatsfuehrendePerson.Add(_kesMandatsfuehrendePerson);

            return new KesKokesExportDTO
            {
                BehoerdeDTOs = new List<KesKokesExportBehoerdeDTO>
                {
                    new KesKokesExportBehoerdeDTO
                    {
                        KesBehoerde = _kesBehoerde,
                        PersonDtoList = new List<KesKokesExportPersonDTO>
                        {
                            new KesKokesExportPersonDTO
                            {
                                BaPerson = _baPerson,
                                KesMassnahmen = new List<KesKokesExportMassnahmeDTO>
                                {
                                    new KesKokesExportMassnahmeDTO
                                    {
                                        KesMassnahme = _kesMassnahme
                                    }
                                }
                            }
                        }
                    }
                },
                KesMassnahmeDTOs = new List<KesKokesExportMassnahmeListDTO>
                {
                    new KesKokesExportMassnahmeListDTO
                    {
                        KesMassnahme = _kesMassnahme
                    }
                }
            };
        }

        private XElement GetPersonElement(XDocument document)
        {
            var ns = KesKokesExportService.XmlNamespace;
            return document.Root.Element(ns + "Behoerde").Element(ns + "Person");
        }
    }
}