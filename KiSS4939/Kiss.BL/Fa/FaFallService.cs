using System;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.BL.Fa
{
    /// <summary>
    /// Service for FaFall.
    /// </summary>
    public class FaFallService : ServiceBase
    {
        #region Constructors

        private FaFallService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Hohlt die aktuelle FaFallId. 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="baPersonId"></param>
        /// <returns>Die aktuelle Fallid</returns>
        public int? GetAktuelleFaFallId(IUnitOfWork unitOfWork, int baPersonId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            DateTime today = DateTime.Today;
            IRepository<FaFall> repository = UnitOfWork.GetRepository<FaFall>(unitOfWork);
            IQueryable<int> query = repository
                .Where(x => x.BaPersonID == baPersonId)
                .Where(x => x.DatumVon <= today || x.DatumVon == null)
                .Where(x => x.DatumBis >= today || x.DatumBis == null)
                .Select(x => x.FaFallID);
            int? result = query.FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Liefert das String "F[FaFallID] [FallträgerName], [FallträgerVorname]"
        /// </summary>
        /// <param name="unitOfWork">Die unitOfWork</param>
        /// <param name="faLeistungId">ID der Leistung</param>
        /// <returns>FallID, Name und Vorname des Fallträgers</returns>
        public string GetFallIdNameVornameByFaLeistungId(IUnitOfWork unitOfWork, int faLeistungId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);
            var fallInfo = repository
                .Where(lei => lei.FaLeistungID == faLeistungId)
                .Select(
                    lei => new
                    {
                        lei.FaFall.FaFallID,
                        lei.FaFall.BaPerson.Name,
                        lei.FaFall.BaPerson.Vorname,
                    })
                .SingleOrDefault();

            if (fallInfo == null)
            {
                return string.Empty;
            }

            return string.Format("F{0} {1}, {2}", fallInfo.FaFallID, fallInfo.Name, fallInfo.Vorname);
        }

        #endregion

        #endregion
    }
}