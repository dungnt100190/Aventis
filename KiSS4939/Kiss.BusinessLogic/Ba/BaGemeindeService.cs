using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using HtmlAgilityPack;

using Kiss.BusinessLogic.Ba.Parser;
using Kiss.BusinessLogic.Sys;
using Kiss.BusinessLogic.Sys.NodeEnumeration;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IO;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using WebRequest = Kiss.Infrastructure.IO.WebRequest;

namespace Kiss.BusinessLogic.Ba
{
    /// <summary>
    /// Service to manage a BaGemeinde.
    /// </summary>
    public class BaGemeindeService : ServiceCRUD<BaGemeinde>
    {
        private BaGemeindeService()
        {
        }

        /// <summary>
        /// Holt nur zum Zeitpunkt <paramref name="validAt"/> gültige Gemeinden.
        /// </summary>
        /// <param name="validAt">Stichzeitpunkt</param>
        public BaGemeinde[] GetGemeindenValidAt(DateTime validAt)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.BaGemeinde.GetGemeindenValidAt(validAt);
            }
        }

        public IServiceResult UpdateBaGemeinde(Stream contentStream)
        {
            return UpdateBaGemeindeInternal(contentStream);
        }

        public IServiceResult UpdateBaGemeinde()
        {
            // File aus web holen
            try
            {
                var configService = Container.Resolve<XConfigService>();
                var configUrl = configService.GetConfigValue(ConfigNodes.System_Basis_Gemeindenstamm_URL_BFS, DateTime.Now);
                var xPathStatement = configService.GetConfigValue(ConfigNodes.System_Basis_Gemeindenstamm_XPath, DateTime.Now);
                using (var client = new WebClient())
                {
                    var websiteContent = client.DownloadString(configUrl);
                    var document = new HtmlDocument();
                    document.LoadHtml(websiteContent);
                    var searchedNode = document.DocumentNode.SelectSingleNode(xPathStatement);
                    var urlPart2 = searchedNode.GetAttributeValue("href", null);
                    var downloadFrom = new Uri(new Uri(configUrl), urlPart2);
                    using (var zipStream = WebRequest.GetStream(downloadFrom.ToString()))
                    {
                        var zip = new Zip(zipStream);
                        using (var contentstream = zip.GetStreamEndsWith(".xml"))
                        {
                            return UpdateBaGemeindeInternal(contentstream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Download fehlgeschlagen, User muss Datei vom Filesystem auswählen
                return KissServiceResult.Error(ex);
            }
        }

        internal Stream GetXmlStream(string uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }
            if (uri.EndsWith(".zip"))
            {
                var zip = new Zip(uri);
                return zip.GetStreamEndsWith(".xml");
            }

            return new FileStream(uri, FileMode.Open);
        }

        internal IServiceResult UpdateBaGemeindeInternal(Stream xmlStream)
        {
            try
            {
                // Stream parse
                var gemeindenDelivered = new BaGemeindeParser()
                    .Parse(xmlStream)
                    .Where(gem => gem.BFSCode.HasValue)
                    .ToList();
                //.ToDictionary(gem => gem.BFSCode.Value,
                //              gem => gem);
                using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
                {
                    // Vorhandene Daten aus DB holen
                    var gemeindenCurrent = unitOfWork.BaGemeinde.GetAllEntities().ToList();

                    var modifiedGemeinden = new List<BaGemeinde>();

                    // Abgleich
                    foreach (var gemeindeCurrent in gemeindenCurrent.Where(gem => gem.BFSCode.HasValue))
                    {
                        var gemeindeDelivered =
                            gemeindenDelivered.FirstOrDefault(x => x.BFSCode == gemeindeCurrent.BFSCode &&
                                                                   (x.GemeindeHistorisierungID ==
                                                                    gemeindeCurrent.GemeindeHistorisierungID ||
                                                                    gemeindeCurrent.GemeindeHistorisierungID == null));
                        if (gemeindeDelivered == null)
                        {
                            // Gemeinde in KiSS wurde nicht mehr geliefert
                            gemeindeCurrent.BFSDelivered = false;

                            // Nicht existierende Gemeinden mit Aufhebungsdatum versehen
                            // Gemeinde "nicht festgestellt" nicht terminieren
                            if (gemeindeCurrent.BFSCode != -1 && !gemeindeCurrent.GemeindeAufhebungDatum.HasValue)
                            {
                                gemeindeCurrent.GemeindeAufhebungDatum = DateTime.Today;
                                modifiedGemeinden.Add(gemeindeCurrent);
                            }
                        }
                        else
                        {
                            gemeindeCurrent.BFSDelivered = true;

                            if (!gemeindeCurrent.ArePropertiesSame(gemeindeDelivered))
                            {
                                // existierende Gemeinde, aber neu gelieferte hat unterschiedliche Daten
                                // Daten aktualisieren
                                gemeindeCurrent.BezirkAenderungDatum = gemeindeDelivered.BezirkAenderungDatum;
                                gemeindeCurrent.BezirkAufhebungDatum = gemeindeDelivered.BezirkAufhebungDatum;
                                gemeindeCurrent.BezirkAufhebungModus = gemeindeDelivered.BezirkAufhebungModus;
                                gemeindeCurrent.BezirkAufhebungNummer = gemeindeDelivered.BezirkAufhebungNummer;
                                gemeindeCurrent.BezirkAufnahmeDatum = gemeindeDelivered.BezirkAufnahmeDatum;
                                gemeindeCurrent.BezirkAufnahmeModus = gemeindeDelivered.BezirkAufnahmeModus;
                                gemeindeCurrent.BezirkAufnahmeNummer = gemeindeDelivered.BezirkAufnahmeNummer;
                                gemeindeCurrent.BezirkCode = gemeindeDelivered.BezirkCode;
                                gemeindeCurrent.BezirkEintragArt = gemeindeDelivered.BezirkEintragArt;
                                gemeindeCurrent.BezirkName = gemeindeDelivered.BezirkName;
                                gemeindeCurrent.BezirkNameLang = gemeindeDelivered.BezirkNameLang;
                                gemeindeCurrent.GemeindeAenderungDatum = gemeindeDelivered.GemeindeAenderungDatum;
                                gemeindeCurrent.GemeindeAufhebungDatum = gemeindeDelivered.GemeindeAufhebungDatum;
                                gemeindeCurrent.GemeindeAufhebungModus = gemeindeDelivered.GemeindeAufhebungModus;
                                gemeindeCurrent.GemeindeAufhebungNummer = gemeindeDelivered.GemeindeAufhebungNummer;
                                gemeindeCurrent.GemeindeAufnahmeDatum = gemeindeDelivered.GemeindeAufnahmeDatum;
                                gemeindeCurrent.GemeindeAufnahmeModus = gemeindeDelivered.GemeindeAufnahmeModus;
                                gemeindeCurrent.GemeindeAufnahmeNummer = gemeindeDelivered.GemeindeAufnahmeNummer;
                                gemeindeCurrent.GemeindeEintragArt = gemeindeDelivered.GemeindeEintragArt;
                                gemeindeCurrent.GemeindeHistorisierungID = gemeindeDelivered.GemeindeHistorisierungID;
                                gemeindeCurrent.GemeindeStatus = gemeindeDelivered.GemeindeStatus;
                                gemeindeCurrent.Kanton = gemeindeDelivered.Kanton;
                                gemeindeCurrent.KantonID = gemeindeDelivered.KantonID;
                                gemeindeCurrent.KantonNameLang = gemeindeDelivered.KantonNameLang;
                                gemeindeCurrent.Name = gemeindeDelivered.Name;
                                gemeindeCurrent.NameLang = gemeindeDelivered.NameLang;

                                //gemeindenDelivered.Remove(gemeindeDelivered.BFSCode.Value);
                                modifiedGemeinden.Add(gemeindeCurrent);
                            }

                            // Gemeinde ist bereits in KiSS, muss nicht mehr neu angelegt werden
                            gemeindenDelivered.Remove(gemeindeDelivered);
                        }
                    }

                    // Geänderte Daten updaten.
                    // Ist in einer Schlaufe weil nach einer Minute die Transaktion den Vorgang abbricht.
                    unitOfWork.BaGemeinde.InsertOrUpdateEntitiesWithoutCheckIfChanged(modifiedGemeinden);

                    // Alle die vom File kommen auf true setzen damit diese die nicht entfernt werden und somit neu sind, das Flag true haben.
                    foreach (var gemeindeDelivered in gemeindenDelivered)
                    {
                        gemeindeDelivered.BFSDelivered = true;
                        gemeindeDelivered.BaGemeindeID = 0; // Added
                    }

                    // Nicht vorhandene Daten speichern.
                    unitOfWork.BaGemeinde.InsertOrUpdateEntitiesWithoutCheckIfChanged(gemeindenDelivered);

                    unitOfWork.SaveChanges();

                    return ServiceResult.Ok();
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }
    }
}