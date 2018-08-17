using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

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
    public class BaPlzService : ServiceCRUD<BaPLZ>
    {
        #region Constructors

        private BaPlzService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Holt nur zum Zeitpunkt <paramref name="validAt"/> gültige PLZ.
        /// </summary>
        /// <param name="validAt"></param>
        public BaPLZ[] GetData(DateTime validAt)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.BaPlz.GetPlzValidAt(validAt);
            }
        }

        /// <summary>
        /// Wird zum update der PLZ nach Auswahl einer Datei vom Filesystem benutzt
        /// </summary>
        /// <param name="contentStream">Streamreader mit Inhalt der csv-Datei</param>
        /// <returns></returns>
        public IServiceResult UpdateBaPlz(StreamReader contentStream)
        {
            return UpdateBaPlzInternal(contentStream);
        }

        /// <summary>
        /// Wird zum update der PLZ nach Auswahl einer Datei vom Filesystem benutzt
        /// </summary>
        /// <param name="zippedFile">Inhalt der heruntergeladenen PLZ-Datei</param>
        /// <returns></returns>
        public IServiceResult UpdateBaPlz(Stream zippedFile)
        {
            return UpdateBaPlzInternal(ExtractContentFromZippedFile(zippedFile));
        }

        /// <summary>
        /// Wird zum update der PLZ direkt aus dem Web genutzt
        /// </summary>
        /// <returns></returns>
        public IServiceResult UpdateBaPlz()
        {
            // File vom FTP holen
            try
            {
                var configService = Container.Resolve<XConfigService>();
                var configURL = configService.GetConfigValue(ConfigNodes.System_Basis_PlzStamm_URL_FTP); // configURL ftp://ftpext.bedag.ch/_PLZ/KiSS_PLZ.zip
                var ftpUser = configService.GetConfigValue(ConfigNodes.System_Basis_PlzStamm_FTP_User);
                var ftpUserPassword = configService.GetConfigValue(ConfigNodes.System_Basis_PlzStamm_FTP_User_Password);

                FtpWebRequest request = (FtpWebRequest)System.Net.WebRequest.Create(configURL);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(ftpUser, ftpUserPassword);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                // zip herunterladen
                using (var responseStream = response.GetResponseStream())
                {
                    var memoryStream = new MemoryStream();
                    responseStream.CopyTo(memoryStream);
                    responseStream.Dispose();

                    memoryStream.Position = 0;
                    return UpdateBaPlzInternal(ExtractContentFromZippedFile(memoryStream));
                }
            }
            catch (Exception ex)
            {
                // Download fehlgeschlagen, User muss Datei vom Filesystem auswählen
                return ServiceResult.Error(ex);
            }
        }

        #endregion

        #region Internal Methods

        internal BaPLZ GetEntityFromFileString(string line)
        {
            var array = line.Split(';');
            // Beschreibung Datenstruktur: #KISS-387(PDF)

            if (array.Length != 16 && array[0] != "01") // REC_ART 01 ist NEW_PLZ1
            {
                return null;
            }

            var onrp = int.Parse(array[1]);
            var plz = int.Parse(array[4]);
            var suffix = int.Parse(array[5]);
            //var ort18 = array[4];
            var ort27 = array[8];
            var kanton = array[9];
            var bfsCode = int.Parse(array[2]);
            var datumVon = DateTime.ParseExact(array[13], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);

            return new BaPLZ
            {
                BFSCode = bfsCode,
                DatumVon = datumVon,
                Kanton = kanton,
                Name = ort27,
                PLZ = plz,
                PLZ6 = plz * 100 + suffix,
                PLZSuffix = suffix,
                ONRP = onrp,
                System = true
            };
        }

        private StreamReader ExtractContentFromZippedFile(Stream fileStream)
        {
            var zip = new Zip(fileStream);
            return new StreamReader(zip.GetStreamEndsWith(".csv"), Encoding.GetEncoding(1252) /*ANSI-Encoding*/);
        }

        private List<BaPLZ> ParsePlzFile(StreamReader reader)
        {
            // Entities aus Datei holen
            var plzFileEntityList = new List<BaPLZ>();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var entity = GetEntityFromFileString(line);

                if (entity != null)
                {
                    plzFileEntityList.Add(entity);
                }
            }
            return plzFileEntityList;
        }

        private IServiceResult UpdateBaPlzInternal(StreamReader reader)
        {
            try
            {
                using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
                {
                    // entities from file
                    var plzsDelivered = ParsePlzFile(reader);

                    // entities from db
                    var plzsCurrent = unitOfWork.BaPlz.GetAllEntities();
                    var plzsModified = new List<BaPLZ>();

                    foreach (var plzCurrent in plzsCurrent)
                    {
                        var plzDelivered = plzsDelivered.FirstOrDefault(plz => plz.ONRP == plzCurrent.ONRP);

                        if (plzDelivered != null)
                        {
                            var changed = !plzCurrent.ArePropertiesSame(plzDelivered);
                            if (changed || plzCurrent.System == false)
                            {
                                plzCurrent.System = true;

                                // Bestehende Daten aktualisieren
                                plzCurrent.BFSCode = plzDelivered.BFSCode;
                                plzCurrent.Name = plzDelivered.Name;
                                plzCurrent.PLZ = plzDelivered.PLZ;
                                plzCurrent.PLZ6 = plzDelivered.PLZ6;
                                plzCurrent.PLZSuffix = plzDelivered.PLZSuffix;
                                plzCurrent.DatumVon = plzDelivered.DatumVon;
                                plzCurrent.DatumBis = plzDelivered.DatumBis;
                                plzCurrent.Kanton = plzDelivered.Kanton;

                                plzsModified.Add(plzCurrent);
                            }
                            // Bearbeitete PLZ aus Liste entfernen
                            plzsDelivered.Remove(plzDelivered);
                        }
                        else if (plzCurrent.DatumBis == null)
                        {
                            plzCurrent.DatumBis = DateTime.Today.AddDays(-1); // PLZ auf gestern terminieren
                            plzsModified.Add(plzCurrent);
                        }
                    }

                    unitOfWork.BaPlz.InsertOrUpdateEntitiesWithoutCheckIfChanged(plzsModified);

                    // Verbleibende Einträge in plzFileEntityList in DB einfügen
                    var sortKey = plzsCurrent.Max(x => x.SortKey);

                    foreach (var plzNeu in plzsDelivered)
                    {
                        plzNeu.SortKey = ++sortKey;
                        plzNeu.System = true;
                    }

                    unitOfWork.BaPlz.InsertOrUpdateEntitiesWithoutCheckIfChanged(plzsDelivered);

                    unitOfWork.SaveChanges();
                    reader.Dispose();
                    return ServiceResult.Ok();
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }

        #endregion

        #endregion
    }
}