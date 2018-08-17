using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Common.Logging;

namespace KiSS.Common.DA.Extension
{
    public static class QueryExtensions
    {
        #region Methods

        #region Public Static Methods

        public static List<T> ToList<T>(this IQueryable<T> query, ILog logger)
        {
            MethodInfo mi = query.GetType().GetMethod("ToTraceString");
            if (mi != null)
            {
                string sql = (string) mi.Invoke(query, null);
                logger.Debug(sql);
            }
            return query.ToList();
        }

        #endregion

        #endregion
    }
}