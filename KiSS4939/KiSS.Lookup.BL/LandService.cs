using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KiSS.Common.BL;
using KiSS.Common.DA;
using KiSS.Lookup.BL.DTO;
using KiSS.Lookup.BL.Extension;
using KiSS.Lookup.DA;

using Autofac;

namespace KiSS.Lookup.BL
{
    public class LandService : ServiceBase
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        public const string lovName = "BaLand";

        #endregion

        #region Private Fields

        private IRepository<BaLand> _landRepository;
        private IUnitOfWork _unitOfWork;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LandService"/> class.
        /// </summary>
        public LandService(IContainer container)
            : base(container)
        {
            _unitOfWork = Context.Resolve<IUnitOfWork>();
            _landRepository = Context.Resolve<IRepository<BaLand>>();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Gets a country from the ISO alpha-2 code
        /// </summary>
        /// <param name="alpha2Code">The ISO alpha-2 code from the land</param>
        /// <returns>A <see cref="Land"/></returns>
        public Land GetByAlpha2(string alpha2Code)
        {
            return _landRepository
                .Where(l => l.Iso2Code == alpha2Code)
                .First()
                .ToLand();
        }

        /// <summary>
        /// Gets a country from the ISO alpha-3 code
        /// </summary>
        /// <param name="alpha3Code">The ISO alpha-3 code from the land</param>
        /// <returns>A <see cref="Land"/></returns>
        public Land GetByAlpha3(string alpha3Code)
        {
            return _landRepository
                .Where(l => l.Iso3Code == alpha3Code)
                .First()
                .ToLand();
        }

        /// <summary>
        /// Gets a country from the BFS code
        /// </summary>
        /// <param name="bfsCode">The BFS code from the land</param>
        /// <returns>A <see cref="Land"/></returns>
        public Land GetByBFSCode(int bfsCode)
        {
            return _landRepository
                .Where(l => l.BFSCode == bfsCode)
                .First()
                .ToLand();
        }

        /// <summary>
        /// Retrieves all country from the <see cref="LookupRepository"/>
        /// </summary>
        /// <returns>A <see cref="List<Postleitzahl>"/></returns>
        public List<Land> RetrieveAll()
        {
            var query = from l in _landRepository
                        select l;

            return query.ToLandList();
        }

        #endregion

        #endregion
    }
}