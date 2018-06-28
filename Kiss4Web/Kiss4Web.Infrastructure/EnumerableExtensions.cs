using System;
using System.Collections.Generic;
using System.Linq;

namespace Kiss4Web.Infrastructure
{
    public static class EnumerableExtensions
    {
        //public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T value)
        //{
        //    if (source != null)
        //    {
        //        foreach (var item in source)
        //        {
        //            yield return item;
        //        }
        //    }
        //    if (value == null)
        //    {
        //        yield break;
        //    }
        //    yield return value;
        //}

        public static IEnumerable<Type> DerivedOfType<TDerived>(this IEnumerable<Type> source)
        {
            return source.Where(type => typeof(TDerived).IsAssignableFrom(type))
                         .Where(type => type != typeof(TDerived));
        }

        public static void DoForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var obj in source)
            {
                action(obj);
            }
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var obj in source)
            {
                action(obj);
                yield return obj;
            }
        }

        public static int IndexOf<T>(this IEnumerable<T> source, T element)
        {
            var i = 0;
            foreach (var item in source)
            {
                if (Equals(item, element))
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        public static TSource MaxOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            if (!source.Any())
            {
                return default(TSource);
            }

            return source.Max();
        }

        public static TResult MaxOrDefault<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (!source.Any())
            {
                return default(TResult);
            }

            return source.Max(selector);
        }

        public static IEnumerable<T> OrderAsHierarchy<T, TIdProperty>(
            this IEnumerable<T> source,
            Func<T, TIdProperty> idPropertySelector,
            Func<T, TIdProperty> parentIdPropertySelector,
            Func<IEnumerable<T>, IOrderedEnumerable<T>> orderFunc = null)
            where T : class
        {
            var hierarchy = CreateHierarchy(source, null, idPropertySelector, parentIdPropertySelector, orderFunc, 0);
            return SelectDeep(hierarchy, x => x.Children).Select(x => x.Entity);
        }

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T value)
        {
            yield return value;
            foreach (var item in source)
            {
                yield return item;
            }
        }

        public static IEnumerable<T> SelectDeep<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> selector)
        {
            foreach (var item in source)
            {
                yield return item;
                foreach (var subItem in SelectDeep(selector(item), selector))
                {
                    yield return subItem;
                }
            }
        }

        public static IEnumerable<KeyValuePair<T, TValue>> ToLookup<T, TKey, TValue>(this IEnumerable<T> source,
                                                                                          IDictionary<TKey, TValue> lookup,
                                                                                          Func<T, TKey> keySelector)
        {
            foreach (var item in source)
            {
                if (lookup.TryGetValue(keySelector(item), out var lookedUpItem))
                {
                    yield return new KeyValuePair<T, TValue>(item, lookedUpItem);
                }
            }
        }

        //public static IDictionary<int, string> ToLookupDictionary<T>(this IEnumerable<T> source, Func<T, int> keySelector, Func<T, string> elementSelector, int? nullValue = null)
        //{
        //    var result = source.ToDictionary(keySelector, elementSelector);

        //    if (nullValue != null)
        //    {
        //        return result.Prepend(new KeyValuePair<int, string>(nullValue.Value, string.Empty)).ToDictionary(x => x.Key, x => x.Value);
        //    }

        //    return result;
        //}

        private static IEnumerable<HierarchyNode<T>> CreateHierarchy<T, TProperty>(
           IEnumerable<T> items,
           T parentItem,
           Func<T, TProperty> idProperty,
           Func<T, TProperty> parentIdProperty,
           Func<IEnumerable<T>, IOrderedEnumerable<T>> orderFunc,
           int depth)
           where T : class
        {
            IEnumerable<T> children;

            if (parentItem == null)
            {
                children = items.Where(x => Equals(parentIdProperty(x), default(TProperty)));
            }
            else
            {
                children = items.Where(x => Equals(parentIdProperty(x), idProperty(parentItem)));
            }

            if (children.Any())
            {
                if (orderFunc != null)
                {
                    children = orderFunc(children);
                }

                depth++;
                foreach (var child in children)
                {
                    var node = new HierarchyNode<T> { Entity = child, Depth = depth };
                    if (!Equals(idProperty(child), parentIdProperty(child)))
                    {
                        node.Children = CreateHierarchy(items, child, idProperty, parentIdProperty, orderFunc, depth);
                    }
                    else
                    {
                        node.Children = new HierarchyNode<T>[0];
                    }
                    yield return node;
                }
            }
        }

        private class HierarchyNode<T> where T : class
        {
            public IEnumerable<HierarchyNode<T>> Children { get; set; }

            public int Depth { get; set; }

            public T Entity { get; set; }
        }
    }
}