using System;
using System.Linq;
using System.Linq.Expressions;

namespace Kiss4Web.Infrastructure.DataAccess
{
    public static class QueryableExtensions
    {
        public static IQueryable<TSource> TakeIf<TSource>(
            this IQueryable<TSource> source,
            int? count)
        {
            return count.HasValue ? source.Take(count.Value) : source;
        }

        public static IQueryable<TSource> TakeIf<TSource>(
                    this IQueryable<TSource> source,
            bool condition,
            int count)
        {
            return condition ? source.Take(count) : source;
        }

        public static IQueryable<TSource> WhereIf<TSource>(
            this IQueryable<TSource> source,
            bool condition,
            Expression<Func<TSource, bool>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }
    }
}