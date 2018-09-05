using System;
using System.Linq;
using System.Linq.Expressions;

namespace Kiss4Web.TestInfrastructure
{
    internal static class LinqExtensionMethods
    {
        public static IQueryable<T> OrderByField<T>(this IQueryable<T> queryable, string sortField, bool isAscending)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, sortField);
            var exp = Expression.Lambda(prop, param);
            string method = isAscending ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { queryable.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, queryable.Expression, exp);
            return queryable.Provider.CreateQuery<T>(mce);
        }
    }
}
