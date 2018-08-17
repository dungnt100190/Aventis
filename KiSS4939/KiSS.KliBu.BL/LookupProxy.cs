using System.Collections.Generic;
using System.Linq;

using KiSS.Common;
using KiSS.Common.BL;
using KiSS.KliBu.BL.Resources;
using KiSS.Lookup.BL;
using KiSS.Lookup.BL.DTO;

using Autofac;

namespace KiSS.KliBu.BL
{
    /// <summary>
    /// Class to get informations from the Lookup modul
    /// </summary>
    internal class LookupProxy
    {
        #region Fields

        #region Private Fields

        IContainer _container;
        List<Land> _landList;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a <see cref="LookupProxy"/> object.
        /// </summary>
        /// <param name="container">Container for all repositories and services</param>
        public LookupProxy(IContainer container)
        {
            _container = container;
        }

        #endregion

        #region Methods

        #region Public Methods

        public ServiceResult AddLog(Log log)
        {
            using (LogService svc = _container.Resolve<LogService>())
            {
                ServiceResult result = svc.Add(log);

                return result;
            }
        }

        /// <summary>
        /// Gets the land code from the two char ISO code.
        /// </summary>
        /// <param name="twoCharIsoCode">Two char ISO code</param>
        /// <returns>The land code</returns>
        public int? LandLookupCode(string twoCharIsoCode)
        {
            if (_landList == null)
            {
                using (LandService landService = _container.Resolve<LandService>())
                {
                    _landList = landService.RetrieveAll();
                }
            }
            IEnumerable<Land> selectedLand = _landList.Where(l => l.Iso2Code == twoCharIsoCode);
            if (selectedLand.Count() == 0 || twoCharIsoCode == null)
            {
                return null;
            }
            else if (selectedLand.Count() > 1)
            {
                throw new AppException(ResMgr.GetMsg(Error.IsNotUnique)
                    .SetPropertyName("Landcode")
                    .Replace("ID", twoCharIsoCode)
                    );
            }

            return selectedLand
                .First()
                .BaLandID;
        }

        /// <summary>
        /// Gets the two char ISO code from the land code.
        /// </summary>
        /// <param name="landCode">Land code</param>
        /// <returns>Two char ISO code</returns>
        public string LandLookupTwoCharIsoCode(int? landCode)
        {
            if (_landList == null)
            {
                using (LandService landService = _container.Resolve<LandService>())
                {
                    _landList = landService.RetrieveAll();
                }
            }
            IEnumerable<Land> selectedLand = _landList.Where(l => l.BaLandID == landCode);
            if (selectedLand.Count() == 0 || landCode == null)
            {
                return "";
            }
            else if (selectedLand.Count() > 1)
            {
                throw new AppException(ResMgr.GetMsg(Error.IsNotUnique)
                    .SetPropertyName("Landcode")
                    .Replace("ID", landCode)
                    );
            }

            return selectedLand
                .First()
                .Iso2Code;
        }

        #endregion

        #endregion
    }
}