using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Kiss.BL.Ba.DTO;
using Kiss.BusinessLogic.Ba.Parser;
using Kiss.BusinessLogic.LocalResources.Ba;
using Kiss.BusinessLogic.Sys;
using Kiss.BusinessLogic.Sys.NodeEnumeration;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IO;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Ba
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class BaLandService : ServiceCRUD<BaLand>
    {
        #region Constructors

        private BaLandService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public IDictionary<int, string> GetLookupSapCodeToBaLandID()
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.BaLand.GetLookupSapCodeToBaLandID();
            }
        }

        /// <summary>
        /// Die Hauptmethode fürs Updaten der Tabelle BaLand. Standardmässig nimmt er die urlZip.
        /// Wenn ein Wert unter System\Basis\Landstamm\URL_BFS gefunden wird, wird die urlZip überschrieben.
        /// </summary>
        /// <param name="urlZip"></param>
        public IServiceResult UpdateLand(string urlZip = null)
        {
            try
            {
                // WebRequest, Zip and Parse
                if (string.IsNullOrEmpty(urlZip))
                {
                    var xConfigService = Container.Resolve<XConfigService>();
                    urlZip = xConfigService.GetConfigValue(ConfigNodes.System_Basis_Landstamm_URL_BFS);
                }

                /* schauen obs eine URL ist (dann WebRequest verwenden) oder eine Pfadangabe (dann vom Pfad herunterladen) */
                Zip zip = null;

                if (Uri.IsWellFormedUriString(urlZip, UriKind.Absolute))
                {
                    var zipStream = WebRequest.GetStream(urlZip);
                    zip = new Zip(zipStream);
                }
                else
                {
                    if (File.Exists(urlZip))
                    {
                        zip = new Zip(urlZip);
                    }
                }

                if (zip == null)
                {
                    return new ServiceResult(ServiceResultType.Error, BaServiceRes.LandUrlIsEmpty, ConfigNodes.System_Basis_Landstamm_URL_BFS.KeyPath);
                }

                var fileStream = zip.GetStreamEndsWith(".xml");
                var laenderDelivered = new BaLandParser().Parse(fileStream);

                return Landabgleich(laenderDelivered.ToArray());
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }

        #endregion

        #region Private Methods

        private IServiceResult Landabgleich(BaLandDTO[] laenderDelivered)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                var laenderCurrent = unitOfWork.BaLand.GetAllEntities();

                // alle Länder update = false setzen damit man danach vergleichen kann welche upgedatet wurden
                foreach (var baLand in laenderCurrent.Where(baLand => baLand.BFSDelivered))
                {
                    baLand.BFSDelivered = false;
                }

                // Abgleich
                foreach (var landDelivered in laenderDelivered)
                {
                    var updated = false;
                    var landCurrent = laenderCurrent.SingleOrDefault(lnd => lnd.BFSCode == landDelivered.BfsCode);
                    if (landCurrent != null && landCurrent.DatumBis == null)
                    {
                        if (!landCurrent.Text.Equals(landDelivered.ShortNameDe))
                        {
                            landCurrent.Text = landDelivered.ShortNameDe;
                            updated = true;
                        }
                        if (!landCurrent.TextFR.Equals(landDelivered.ShortNameFr))
                        {
                            landCurrent.TextFR = landDelivered.ShortNameFr;
                            updated = true;
                        }
                        if (!landCurrent.TextIT.Equals(landDelivered.ShortNameIt))
                        {
                            landCurrent.TextIT = landDelivered.ShortNameIt;
                            updated = true;
                        }
                        if (!landCurrent.TextEN.Equals(landDelivered.ShortNameEn))
                        {
                            landCurrent.TextEN = landDelivered.ShortNameEn;
                            updated = true;
                        }
                        if (landCurrent.Iso2Code != landDelivered.Iso2Id)
                        {
                            landCurrent.Iso2Code = landDelivered.Iso2Id;
                            updated = true;
                        }
                        if (landCurrent.Iso3Code != landDelivered.Iso3Id)
                        {
                            landCurrent.Iso3Code = landDelivered.Iso3Id;
                            updated = true;
                        }
                        if (landCurrent.BFSDelivered == false)
                        {
                            landCurrent.BFSDelivered = true;
                            updated = true;
                        }
                        if (!landCurrent.DatumVon.Equals(landDelivered.DateOfChange))
                        /* hier speichern wir jetzt neu das DateOfChange */
                        {
                            landCurrent.DatumVon = landDelivered.DateOfChange;
                            updated = true;
                        }
                        /* Info: Der SAPCode wird ignoriert, da uns diese Daten nicht
                         * zur Verfügung stehen und sie nicht gebraucht werden. */

                        /*markieren, dass das Land von BFS geliefert wurde */
                        if (updated)
                        {
                            unitOfWork.BaLand.InsertOrUpdateEntity(landCurrent);
                        }
                    }
                    else
                    {
                        /* neues Land speichern */
                        unitOfWork.BaLand.InsertOrUpdateEntity(new BaLand
                                                                   {
                                                                       Text = landDelivered.ShortNameDe,
                                                                       TextFR = landDelivered.ShortNameFr,
                                                                       TextIT = landDelivered.ShortNameIt,
                                                                       TextEN = landDelivered.ShortNameEn,
                                                                       Iso2Code = landDelivered.Iso2Id,
                                                                       Iso3Code = landDelivered.Iso3Id,
                                                                       BFSCode = landDelivered.BfsCode,
                                                                       DatumVon = landDelivered.DateOfChange,
                                                                       BFSDelivered = true
                                                                   });
                    }
                }

                /* zu guter letzt: wenn das Land (BfsCode) nicht mehr in der Liste landList existiert, es nicht ein 'unbekannt' ist, ein DatumBis eintragen */
                var currentButNotDeliveredLaender = laenderCurrent.Where(cur => !laenderDelivered.Any(del => del.BfsCode == cur.BFSCode) &&
                                                                                cur.SortKey != 9999 && !cur.DatumBis.HasValue);

                foreach (var baLand in currentButNotDeliveredLaender)
                {
                    baLand.DatumBis = DateTime.Today;
                    unitOfWork.BaLand.InsertOrUpdateEntity(baLand);
                }

                unitOfWork.SaveChanges();
                return ServiceResult.Ok();
            }
        }

        #endregion

        #endregion
    }
}