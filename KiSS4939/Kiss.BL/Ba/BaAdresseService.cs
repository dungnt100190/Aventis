using System;
using System.Linq;

using Kiss.BL.Ba.Validation;
using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Ba
{
    public class BaAdresseService : ServiceCRUDBase<BaAdresse>
    {
        #region Constructors

        private BaAdresseService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Hohlt die aktuelle Adresse einer Institution. Falls es mehrere gibt,
        /// wird der erste Treffer zurückgegeben.
        /// Wenn es keine gültige Adresse gibt, dann wird null zurückgegeben.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="baInstitutionId"></param>
        /// <param name="date">Datum. Kann nicht null sein.</param>
        /// <returns>Die Adresse. Null wenn es keien aktuelle Adresse gibt.</returns>
        public BaAdresse GetByBaInstitutionId(IUnitOfWork unitOfWork, int baInstitutionId, DateTime date)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<BaAdresse>(unitOfWork);

            var adressenDaten = repository
                .Where(adresse => adresse.BaInstitutionID == baInstitutionId)
                .Where(adresse => adresse.DatumVon == null || adresse.DatumVon <= date)
                .Where(adresse => adresse.DatumBis == null || adresse.DatumBis >= date)
                .OrderBy(adresse => adresse.DatumVon)
                .OrderByDescending(adresse => adresse.DatumBis)
                .Select(x => new
                        {
                            x.BaAdresseID,
                            x.Strasse,
                            x.HausNr,
                            x.Postfach,
                            x.PLZ,
                            x.Ort,
                            //x.BaLandID,
                            x.BaPersonID,
                            x.BaInstitutionID,
                            x.DatumVon,
                            x.DatumBis,
                            x.AdresseCode,
                            x.BaAdresseTS
                        })
                .FirstOrDefault(); //HACK: BaAdresse nicht konsolidiert.

            if (adressenDaten != null)
            {
                BaAdresse adresse = new BaAdresse
                {
                    BaAdresseID = adressenDaten.BaAdresseID,
                    Strasse = adressenDaten.Strasse,
                    HausNr = adressenDaten.HausNr,
                    Postfach = adressenDaten.Postfach,
                    PLZ = adressenDaten.PLZ,
                    Ort = adressenDaten.Ort,
                    //BaLandID = adressenDaten.BaLandID,
                    BaPersonID = adressenDaten.BaPersonID,
                    BaInstitutionID = adressenDaten.BaInstitutionID,
                    DatumVon = adressenDaten.DatumVon,
                    DatumBis = adressenDaten.DatumBis,
                    AdresseCode = adressenDaten.AdresseCode,
                    BaAdresseTS = adressenDaten.BaAdresseTS
                };

                SetEntityValidator(adresse);
                unitOfWork.StartTrackingAndMarkAsUnchangedAll();
                return adresse;
            }

            return null;
        }

        /// <summary>
        /// Hohlt die aktuelle Adresse einer Person. Falls es mehrere gibt,
        /// wird der erste Treffer zurückgegeben.
        /// Wenn es keine gültige Adresse gibt, dann wird null zurückgegeben.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="baPersonId"></param>
        /// <param name="date">Datum. Kann nicht null sein.</param>
        /// <returns>Die Adresse. Null wenn es keien aktuelle Adresse gibt.</returns>
        public BaAdresse GetByBaPersonId(IUnitOfWork unitOfWork, int baPersonId, DateTime date)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<BaAdresse>(unitOfWork);

            var returnValue = repository
                .Where(adresse => adresse.BaPersonID == baPersonId)
                .Where(adresse => adresse.DatumVon == null || adresse.DatumVon <= date)
                .Where(adresse => adresse.DatumBis == null || adresse.DatumBis >= date)
                .OrderBy(adresse => adresse.DatumVon)
                .OrderByDescending(adresse => adresse.DatumBis)
                .FirstOrDefault();

            if (returnValue != null)
            {
                SetEntityValidator(returnValue);
                unitOfWork.StartTrackingAndMarkAsUnchangedAll();
            }

            return returnValue;
        }

        /// <summary>
        /// Hohlt die aktuelle Wohnsitz-Adresse einer Person. Falls es mehrere gibt,
        /// wird der erste Treffer zurückgegeben.
        /// Wenn es keine gültige Adresse gibt, dann wird null zurückgegeben.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="baPersonId"></param>
        /// <param name="date">Datum. Kann nicht null sein.</param>
        /// <returns>Die Adresse. Null wenn es keien aktuelle Adresse gibt.</returns>
        public BaAdresse GetByBaPersonIdAndHome(IUnitOfWork unitOfWork, int baPersonId, DateTime date)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<BaAdresse>(unitOfWork);

            var adressDaten = repository
                .Where(adresse => adresse.BaPersonID == baPersonId)
                .Where(adresse => adresse.AdresseCode == 1)
                .Where(adresse => adresse.DatumVon == null || adresse.DatumVon <= date)
                .Where(adresse => adresse.DatumBis == null || adresse.DatumBis >= date)
                .OrderBy(adresse => adresse.DatumVon)
                .OrderByDescending(adresse => adresse.DatumBis)
                .Select(x => new
                {
                    x.BaAdresseID,
                    x.Strasse,
                    x.HausNr,
                    x.Postfach,
                    x.PLZ,
                    x.Ort,
                    //x.BaLandID,
                    x.BaPersonID,
                    x.BaInstitutionID,
                    x.DatumVon,
                    x.DatumBis,
                    x.AdresseCode,
                    x.BaAdresseTS
                })
                .FirstOrDefault(); //HACK: BaAdresse nicht konsolidiert.

            if (adressDaten != null)
            {
                BaAdresse adresse = new BaAdresse
                {
                    BaAdresseID = adressDaten.BaAdresseID,
                    Strasse = adressDaten.Strasse,
                    HausNr = adressDaten.HausNr,
                    Postfach = adressDaten.Postfach,
                    PLZ = adressDaten.PLZ,
                    Ort = adressDaten.Ort,
                    //BaLandID = adressDaten.BaLandID,
                    BaPersonID = adressDaten.BaPersonID,
                    BaInstitutionID = adressDaten.BaInstitutionID,
                    DatumVon = adressDaten.DatumVon,
                    DatumBis = adressDaten.DatumBis,
                    AdresseCode = adressDaten.AdresseCode,
                    BaAdresseTS = adressDaten.BaAdresseTS
                };

                SetEntityValidator(adresse);
                unitOfWork.StartTrackingAndMarkAsUnchangedAll();
                return adresse;
            }

            return null;
        }

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="id">Die ID des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public override BaAdresse GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<BaAdresse>(unitOfWork);

            var returnValue = repository
                .Where(adresse => adresse.BaAdresseID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'BaAdresse' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        public override void InitData(BaAdresse newData)
        {
            base.InitData(newData);

            // Setze Defaultvalues hier:
            newData.Ort = "Bern";
        }

        /// <summary>
        /// Überprüft, ob die beiden Adressen denselben Haushalt darstellen.
        /// </summary>
        /// <param name="adresse1"></param>
        /// <param name="adresse2"></param>
        /// <returns></returns>
        public bool IsSameAddress(BaAdresse adresse1, BaAdresse adresse2)
        {
            if (adresse1 == null && adresse2 == null)
            {
                return true;
            }
            if (adresse1 == null || adresse2 == null)
            {
                return false;
            }

            if (adresse1.BaLandID != adresse2.BaLandID)
            {
                return false;
            }
            if (adresse1.AdresseCode != adresse2.AdresseCode)
            {
                return false;
            }
            if (adresse1.Zusatz != adresse2.Zusatz)
            {
                return false;
            }
            if (adresse1.Strasse != adresse2.Strasse)
            {
                return false;
            }
            if (adresse1.HausNr != adresse2.HausNr)
            {
                return false;
            }
            if (adresse1.Postfach != adresse2.Postfach)
            {
                return false;
            }
            if (adresse1.PostfachOhneNr != adresse2.PostfachOhneNr)
            {
                return false;
            }
            if (adresse1.PLZ != adresse2.PLZ)
            {
                return false;
            }
            if (adresse1.Ort != adresse2.Ort)
            {
                return false;
            }
            if (adresse1.OrtschaftCode != adresse2.OrtschaftCode)
            {
                return false;
            }
            if (adresse1.Kanton != adresse2.Kanton)
            {
                return false;
            }
            if (adresse1.Bezirk != adresse2.Bezirk)
            {
                return false;
            }
            return true;
        }

        public override KissServiceResult ValidateInMemory(BaAdresse dataToValidate)
        {
            // Validation: Check if Entity is consistent in itself
            var serviceResult = BaAdresseValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion
    }
}