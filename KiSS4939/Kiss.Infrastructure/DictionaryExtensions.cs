using System.Collections.Generic;

namespace Kiss.Infrastructure
{
    public static class DictionaryExtensionss
    {
        public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        {
            var result = default(TValue);
            if (dict.ContainsKey(key))
            {
                result = dict[key];
            }
            return result;
        }

        public static void SetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = value;
            }
            else
            {
                dict.Add(key, value);
            }
        }
    }
}
