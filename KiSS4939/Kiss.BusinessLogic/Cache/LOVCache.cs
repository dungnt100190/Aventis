using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.DbContext;

namespace Kiss.BusinessLogic.Cache
{
    /// <summary>
    /// Manages caching for XLOVCode values
    /// </summary>
    public sealed class LOVCache
    {
        /// <summary>
        /// Dictionary with the cached XLOVCode items
        /// </summary>
        private readonly IDictionary<string, IList<XLOVCode>> _mapXLOVCodeItems;

        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        public LOVCache(bool loadAllXLov = false)
        {
            _mapXLOVCodeItems = new Dictionary<string, IList<XLOVCode>>();
            if (loadAllXLov)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Adds or updates XLOVCode-list in cache
        /// </summary>
        /// <param name="key">Name of XLOV</param>
        /// <param name="value">List of XLOVCodes</param>
        public void AddOrUpdateLovInCache(string key, IList<XLOVCode> value)
        {
            if (_mapXLOVCodeItems.ContainsKey(key))
            {
                _mapXLOVCodeItems.Remove(key);
            }
            _mapXLOVCodeItems.Add(key, value);
        }

        /// <summary>
        /// Clears the cache
        /// </summary>
        public void ClearCache()
        {
            _mapXLOVCodeItems.Clear();
        }

        /// <summary>
        /// Query if the cache is empty
        /// </summary>
        /// <returns>True when cache contains the XLOVCodes for this lovname, false when cache doesn't contain the XLOVCodes for this lovname</returns>
        public bool IsCached(string lovname)
        {
            return _mapXLOVCodeItems.ContainsKey(lovname);
        }

        /// <summary>
        /// Get map with XLOVCode items
        /// </summary>
        /// <param name="lovname">Name of the XLOV</param>
        /// <returns>Filtered map with XLOV items</returns>
        internal IList<XLOVCode> GetLovCodeByLovName(string lovname)
        {
            return _mapXLOVCodeItems
                   .Single(kvp => kvp.Key.Equals(lovname))
                   .Value;
        }
    }
}