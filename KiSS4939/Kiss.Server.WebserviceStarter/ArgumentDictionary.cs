using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kiss.Server.WebserviceStarter
{
    public class ArgumentDictionary : IDictionary<string, string>
    {
        /// <summary>
        /// The underlying dictionary that contains all parameters.
        /// </summary>
        private readonly IDictionary<string, string> _dictionary;

        public ArgumentDictionary(char startCharacter, params string[] args)
            : this(new[] { startCharacter }, args)
        {
        }

        /// <summary>
        /// Creates a new instance of the ArgumentDictionary class from application arguments.
        /// </summary>
        /// <param name="startCharacters">Character that define the start of a new parameter.</param>
        /// <param name="args">An array of application arguments.</param>
        public ArgumentDictionary(char[] startCharacters, params string[] args)
        {
            _dictionary = new Dictionary<string, string>();

            StartChars = startCharacters;

            ProcessArguments(args);
        }

        public int Count
        {
            get { return _dictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public ICollection<string> Keys
        {
            get { return _dictionary.Keys; }
        }

        /// <summary>
        /// A character that defines the start of a new parameter.
        /// </summary>
        public char[] StartChars { get; set; }

        public ICollection<string> Values
        {
            get { return _dictionary.Values; }
        }

        public string this[string key]
        {
            get { return _dictionary.ContainsKey(key.ToLower()) ? _dictionary[key.ToLower()] : null; }
            set { _dictionary[key.ToLower()] = value; }
        }

        public void Add(string key, string value)
        {
            throw new NotSupportedException();
        }

        public void Add(KeyValuePair<string, string> item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return _dictionary.Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return _dictionary.ContainsKey(key.ToLower());
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            var en = _dictionary.GetEnumerator();

            for (int i = arrayIndex; i < array.Length && !en.MoveNext(); i++)
            {
                array[i] = en.Current;
            }
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(string key)
        {
            throw new NotSupportedException();
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            throw new NotSupportedException();
        }

        public bool TryGetValue(string key, out string value)
        {
            if (ContainsKey(key.ToLower()))
            {
                value = this[key.ToLower()];
                return true;
            }

            value = null;
            return false;
        }

        private void ProcessArguments(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (string.IsNullOrEmpty(args[i]))
                {
                    continue;
                }

                var name = args[i].ToLower();

                foreach (var startChar in StartChars)
                {
                    name = name.TrimStart(startChar);
                }

                if (!string.IsNullOrEmpty(args[i]) && StartChars.Contains(args[i][0]))
                {
                    _dictionary.Add(name, string.Empty);
                }

                if (i < (args.Length - 1) && !string.IsNullOrEmpty(args[i + 1]) && !StartChars.Contains(args[i + 1][0]))
                {
                    _dictionary[name] = args[++i];
                }
            }
        }
    }
}