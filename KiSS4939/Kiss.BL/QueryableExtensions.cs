using System;
using System.Linq;
using System.Linq.Expressions;

namespace Kiss.BL
{
    public static class QueryableExtensions
    {
        #region Methods

        #region Public Static Methods

        public static IQueryable<TSource> WhereIf<TSource>(
            this IQueryable<TSource> source,
            bool condition,
            Expression<Func<TSource, bool>> predicate)
        {
            if (condition)
            {
                return source.Where(predicate);
            }

            return source;
        }

        #endregion

        #endregion
    }
}