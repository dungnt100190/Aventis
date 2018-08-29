using System;
using System.Collections.Generic;

namespace Kiss4Web.Test.TestInfrastructure
{
    internal static class DictionaryExtensionMethods
    {
        public static TValue Lookup<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, Func<TValue> fallbackValue)
        {
            return source.TryGetValue(key, out var value) ? value : fallbackValue();
        }

        public static TValue Lookup<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue fallbackValue)
        {
            return Lookup(source, key, () => fallbackValue);
        }

        public static TValue Lookup<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key)
        {
            return Lookup(source, key, default(TValue));
        }

        public static TValue LookupAddIfMissing<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, Func<TValue> factoryMethod)
        {
            if (!source.TryGetValue(key, out var value))
            {
                value = factoryMethod();
                lock (source)
                {
                    if (!source.ContainsKey(key))
                    {
                        source.Add(key, value);
                    }
                }
            }
            return value;
        }
    }
}
