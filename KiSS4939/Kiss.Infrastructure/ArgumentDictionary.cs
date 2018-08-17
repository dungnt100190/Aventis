using System;
using System.Collections;
using System.Collections.Generic;

namespace Kiss.Infrastructure
{
    /// <summary>
    /// A dictionary class for application parameter parsing. The dictionary cannot be modified after creation.
    /// </summary>
    public sealed class ArgumentDictionary : IDictionary<string, string>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// The underlying dictionary that contains all parameters.
        /// </summary>
        private readonly IDictionary<string, string> _dictionary;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the ArgumentDictionary class from application arguments.
        /// </summary>
        /// <param name="startCharacter">A character that defines the start of a new parameter.</param>
        /// <param name="args">An array of application arguments.</param>
        public ArgumentDictionary(char startCharacter, params string[] args)
        {
            _dictionary = new Dictionary<string, string>();

            StartChar = startCharacter;

            ProcessArguments(args);
        }

        #endregion

        #region Properties

        /// <summary>
        /// The number of key-value pairs.
        /// </summary>
        public int Count
        {
            get { return _dictionary.Count; }
        }

        /// <summary>
        /// Always true.
        /// </summary>
        public bool IsReadOnly
        {
            get { return true; }
        }

        /// <summary>
        /// The keys of the dictionary.
        /// </summary>
        public ICollection<string> Keys
        {
            get { return _dictionary.Keys; }
        }

        /// <summary>
        /// A character that defines the start of a new parameter.
        /// </summary>
        public char StartChar
        {
            get;
            set;
        }

        /// <summary>
        /// The values of the dictionary.
        /// </summary>
        public ICollection<string> Values
        {
            get { return _dictionary.Values; }
        }

        #endregion

        #region Indexers

        public string this[string key]
        {
            get
            {
                return _dictionary[key.ToLower()];
            }
            set
            {
                _dictionary[key.ToLower()] = value;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, string value)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <param name="item"></param>
        public void Add(KeyValuePair<string, string> item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        public void Clear()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Checks if an item is in the dictionary.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(KeyValuePair<string, string> item)
        {
            return _dictionary.Contains(item);
        }

        /// <summary>
        /// Checks if the dictionary contains the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            return _dictionary.ContainsKey(key.ToLower());
        }

        /// <summary>
        /// Copies the items in the dictionary into the specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
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

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<string, string> item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Tries to get a value for the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
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

        #endregion

        #region Private Methods

        private void ProcessArguments(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (string.IsNullOrEmpty(args[i]))
                {
                    continue;
                }

                var name = args[i].TrimStart(StartChar).ToLower();

                if (!string.IsNullOrEmpty(args[i]) && args[i][0] == StartChar)
                {
                    _dictionary.Add(name, string.Empty);
                }

                if (i < (args.Length - 1) && !string.IsNullOrEmpty(args[i + 1]) && args[i + 1][0] != StartChar)
                {
                    _dictionary[name] = args[++i];
                }
            }
        }

        #endregion

        #endregion
    }
}