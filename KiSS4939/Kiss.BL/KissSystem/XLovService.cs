using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.KissSystem
{
    /// <summary>
    /// Service to manage a person
    /// </summary>
    public class XLovService : ServiceBase
    {
        #region Constructors

        private XLovService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Gets the <see cref="XLOV"/> entity with the given <paramref name="lovName"/>
        /// </summary>
        /// <param name="unitOfWork">The <see cref="IUnitOfWork"/> to get the <see cref="IRepository{T}"/> from or create a new one if it's <c>null</c></param>
        /// <param name="lovName">LOV's name</param>
        /// <returns><see cref="XLOV"/> with the given <paramref name="lovName"/> or <c>null</c> if it doesn't exists</returns>
        public XLOV GetByLovName(IUnitOfWork unitOfWork, string lovName)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<XLOV>(unitOfWork);

            var returnValue = repository.SingleOrDefault(x => x.LOVName == lovName);

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Hohlt einen LovCode.
        /// TODO: UnitTest schreiben.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="code"></param>
        /// <param name="lovName"></param>
        /// <returns></returns>
        public XLOVCode GetLovCode(IUnitOfWork unitOfWork, int code, string lovName)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<XLOVCode>(unitOfWork);
            XLOVCode result = repository.FirstOrDefault(x => x.LOVName == lovName && x.Code == code);
            return result;
        }

        /// <summary>
        /// Gets all <see cref="XLOVCode"/> entities of a <see cref="XLOV"/> with the given <paramref name="lovName"/>
        /// </summary>
        /// <param name="unitOfWork">The <see cref="IUnitOfWork"/> to get the <see cref="IRepository{T}"/> from or create a new one if it's <c>null</c></param>
        /// <param name="lovName">LOV's name</param>
        /// <param name="includeNullValue">bool flag, whether a null value (code = -1, text = empty string) should be added as first element in the returnvalue.</param>
        /// <param name="onlyActive"> </param>
        /// <returns><see cref="List{XLOVCode}"/> with the given <paramref name="lovName"/> or <c>null</c> if it doesn't exists</returns>
        /// <exception cref="EntityNotFoundException">Thrown if no lov entity was found</exception>
        /// <exception cref="ResultEmptyException">Thrown if no lovCode entry was found</exception>
        public List<XLOVCode> GetLovCodeByLovName(IUnitOfWork unitOfWork, string lovName, bool includeNullValue = false, bool onlyActive = false)
        {
            if (lovName == null)
            {
                throw new ArgumentNullException("lovName");
            }

            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repoXLov = UnitOfWork.GetRepository<XLOV>(unitOfWork);

            if (repoXLov.All(x => x.LOVName != lovName))
            {
                throw new EntityNotFoundException(string.Format("No XLOV entity found with LOVName '{0}'", lovName));
            }

            var repoXLovCode = UnitOfWork.GetRepository<XLOVCode>(unitOfWork);

            var returnValue = repoXLovCode
                .Where(x => x.LOVName == lovName)
                .WhereIf(onlyActive, x => x.IsActive)
                .OrderBy(x => x.SortKey)
                .ToList();

            if (includeNullValue)
            {
                returnValue.Insert(0, new XLOVCode
                {
                    Code = -1,
                    LOVName = lovName,
                    LOVCodeName = string.Empty,
                    IsActive = true,
                });
            }

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Gets all <see cref="XLOVCode"/> entities of a <see cref="XLOV"/> with the given <paramref name="lovName"/>
        /// that contain the value of filter in property Value3.
        /// </summary>
        /// <param name="unitOfWork">The <see cref="IUnitOfWork"/> to get the <see cref="IRepository{T}"/> from or create a new one if it's <c>null</c></param>
        /// <param name="lovName">LOV's name</param>
        /// <param name="filter">List of filter Filters the LOV Code. The value of filter is contained in the property value of property Value3, the value can be separated with ','</param>
        /// <returns><see cref="List{XLOVCode}"/> with the given <paramref name="lovName"/> or <c>null</c> if it doesn't exists</returns>
        /// <exception cref="EntityNotFoundException">Thrown if no lov entity was found</exception>
        /// <exception cref="ResultEmptyException">Thrown if no lovCode entry was found</exception>
        public List<XLOVCode> GetLovCodeByLovName(IUnitOfWork unitOfWork, string lovName, params string[] filter)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<XLOVCode>(unitOfWork);

            // if no filter is given, use the default method to get data
            if (filter.Length == 0 || filter.Length == 1 && string.IsNullOrEmpty(filter[0]))
            {
                return GetLovCodeByLovName(unitOfWork, lovName);
            }

            //warun sind hier kommas? -> damit zwischen N und N2 unterschieden werden kann. Mit Contians würde beim Filter N
            //N beide berücksichtigt, N und N2.
            var returnValue = repository
                .Where(x => x.LOVName == lovName)
                .Where(x => filter.All(f => ("," + x.Value3 + ",").Contains("," + f + ",")))
                .ToList();

            if (returnValue == null)
            {
                throw new EntityNotFoundException(string.Format("No lov entity found with lovName '{0}'", lovName));
            }

            if (returnValue.Count < 1)
            {
                throw new ResultEmptyException(string.Format("No lovCode entry found for given lovName '{0}' and filter '{1}'", lovName, filter));
            }

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        public string GetStringFromLovCodes(IUnitOfWork unitOfWork, string separatedLovCodes, string lovName)
        {
            if (!string.IsNullOrEmpty(separatedLovCodes))
            {
                unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
                var list = GetLovCodeByLovName(unitOfWork, lovName, true);
                var codes = separatedLovCodes.Split(',').ToList().ConvertAll(Convert.ToInt32);

                return string.Join(", ", list.Where(t => codes.Contains(t.Code)).Select(c => c.Text));
            }
            return string.Empty;
        }

        #endregion

        #endregion
    }
}