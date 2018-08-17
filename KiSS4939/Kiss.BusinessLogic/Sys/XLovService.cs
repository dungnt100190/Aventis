using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BusinessLogic.Cache;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;
using Kiss.Infrastructure.Utils;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Sys
{
    /// <summary>
    /// Service to manage a person
    /// </summary>
    public class XLovService : Service
    {
        private readonly LOVCache _cache;
        private readonly ISessionService _sessionService;

        private XLovService()
        {
            _cache = Container.TryResolve<LOVCache>();

            _sessionService = Container.Resolve<ISessionService>();

            if (_cache == null)
            {
                var lovCache = new LOVCache();
                _cache = lovCache;
                Container.RegisterInstance(_cache);
            }
        }

        protected int LanguageCode
        {
            get
            {
                return _sessionService.AuthenticatedUser.LanguageCode;
            }
        }

        public void ClearCache()
        {
            _cache.ClearCache();
        }

        public IList<XLOVCode> FilterLovCodes(IEnumerable<XLOVCode> lovCodes, params object[] filter)
        {
            return lovCodes
                .WhereIf(filter.Length >= 0, loc => loc.Code == -1 || filter.All(flt => ("," + loc.Value3 + ",").Contains("," + flt + ",")))
                .ToList();
        }

        public XLOVCode[] GetLovCodes(string lovName, string separatedLovCodes)
        {
            if (!string.IsNullOrEmpty(separatedLovCodes))
            {
                var list = GetLovCodeByLovNameFromCacheOrRepository(lovName);

                var codes = separatedLovCodes
                            .Split(',')
                            .ToList()
                            .ConvertAll(Convert.ToInt32);

                return list
                       .Where(t => codes.Contains(t.Code))
                       .ToArray();
            }

            return new XLOVCode[0];
        }

        /// <summary>
        /// Gets all <see cref="XLOVCode"/> entities of a <see cref="XLOV"/> with the given <paramref name="lovName"/>
        /// </summary>
        /// <param name="lovName">LOV's name</param>
        /// <param name="includeNullValue">bool flag, whether a null value (code = -1, text = empty string) should be added as first element in the returnvalue.</param>
        /// <param name="onlyActive"> </param>
        /// <param name="filter">List of filter Filters the LOV Code. The value of filter is contained in the property value of property Value3, the value can be separated with ','</param>
        /// <returns><see cref="List{XLOVCode}"/> with the given <paramref name="lovName"/> or <c>null</c> if it doesn't exists</returns>
        public IList<XLOVCode> GetLovCodesByLovName(string lovName, bool includeNullValue = false, bool onlyActive = false, params object[] filter)
        {
            if (lovName == null)
            {
                throw new ArgumentNullException("lovName");
            }

            var codes = GetLovCodeByLovNameFromCacheOrRepository(lovName).WhereIf(onlyActive, loc => loc.IsActive).ToList();

            var list = FilterLovCodes(codes, filter).ToList();

            if (includeNullValue)
            {
                list.Insert(0, new XLOVCode
                                    {
                                        Code = -1,
                                        LOVName = lovName,
                                        LOVCodeName = string.Empty,
                                        IsActive = true,
                                    });
            }
            return list;
        }

        /// <summary>
        /// Holt einen LovCode.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="lovName"></param>
        /// <returns></returns>
        public XLOVCode GetSingleLovCode(string lovName, int code)
        {
            if (lovName == null)
            {
                throw new ArgumentNullException("lovName");
            }
            return GetLovCodeByLovNameFromCacheOrRepository(lovName)
                       .FirstOrDefault(loc => loc.Code == code);
        }

        public string GetStringFromLovCodes(string lovName, string separatedLovCodes, string delimiter = ", ")
        {
            return string.Join(delimiter, GetLovCodes(lovName, separatedLovCodes).Select(c => c.Text));
        }

        /// <summary>
        /// Gets a list of XLOVCodes by a given lovname, checks if the list is already cached,
        /// if not, list gets populated from repository and will be added to cache
        /// </summary>
        /// <param name="lovName">Name of XLOV</param>
        /// <returns>List of XLOVCodes</returns>
        private IList<XLOVCode> GetLovCodeByLovNameFromCacheOrRepository(string lovName)
        {
            IList<XLOVCode> codes;
            if (_cache.IsCached(lovName))
            {
                codes = _cache.GetLovCodeByLovName(lovName);
            }
            else
            {
                using (var uow = CreateNewUnitOfWork<IKissUnitOfWork>())
                {
                    codes = uow.XLovCode.GetLovCodeByLovName(lovName, LanguageCode);
                }
                //Cache aktualisieren
                _cache.AddOrUpdateLovInCache(lovName, codes);
            }
            return codes;
        }
    }
}