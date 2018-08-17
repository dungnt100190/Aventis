using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace KiSS4.Main
{
    /// <summary>
    /// Arguments class
    /// </summary>
    public class Arguments
    {
        #region Fields

        #region Private Static Fields

        private static readonly Regex _rxRemover = new Regex(@"^['""]?(.*?)['""]?$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex _rxSpliter = new Regex(@"^-{1,2}|^/|=|:", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly HybridDictionary _parameters = new HybridDictionary(true);

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the Arguments class.
        /// </summary>
        public Arguments()
        {
        }

        /// <summary>
        /// Creates a new instance of the Arguments class.
        /// </summary>
        /// <param name="args">An array of command line arguments.</param>
        public Arguments(string[] args)
        {
            string parameter = null;
            string[] parts;

            // Valid parameters forms:
            // {-,/,--}param{ ,=,:}((",')value(",'))
            // Examples:
            // -param1 value1 --param2 /param3:"Test-:-work"
            //   /param4=happy -param5 '--=nice=--'
            foreach (string arg in args)
            {
                // Look for new parameters (-,/ or --) and a
                // possible enclosed value (=,:)
                parts = _rxSpliter.Split(arg, 3);

                switch (parts.Length)
                {
                    // Found a value (for the last parameter
                    // found (space separator))
                    case 1:
                        if (parameter != null)
                        {
                            if (!_parameters.Contains(parameter))
                            {
                                parts[0] = _rxRemover.Replace(parts[0], "$1");
                                _parameters.Add(parameter, parts[0]);
                            }
                            parameter = null;
                        }
                        // else Error: no parameter waiting for a value (skipped)
                        break;

                    // Found just a parameter
                    case 2:
                        // The last parameter is still waiting.
                        // With no value, set it to true.
                        if (parameter != null)
                        {
                            if (!_parameters.Contains(parameter))
                                _parameters.Add(parameter, true);
                        }
                        parameter = parts[1];
                        break;

                    // Parameter with enclosed value
                    case 3:
                        // The last parameter is still waiting.
                        // With no value, set it to true.
                        if (parameter != null)
                        {
                            if (!_parameters.Contains(parameter))
                                _parameters.Add(parameter, true);
                        }

                        parameter = parts[1];

                        // Remove possible enclosing characters (",')
                        if (!_parameters.Contains(parameter))
                        {
                            parts[2] = _rxRemover.Replace(parts[2], "$1");
                            _parameters.Add(parameter, parts[2]);
                        }

                        parameter = null;
                        break;
                }
            }
            // In case a parameter is still waiting
            if (parameter != null)
            {
                if (!_parameters.Contains(parameter))
                    _parameters.Add(parameter, true);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of key/value pairs contained in the System.Collections.Specialized.HybridDictionary.
        /// </summary>
        /// <value>The number of key/value pairs contained in the System.Collections.Specialized.HybridDictionary.Retrieving
        /// the value of this property is an O(1) operation.</value>
        public int Count
        {
            get { return _parameters.Count; }
        }

        /// <summary>
        /// Get the command line parameters.
        /// </summary>
        public HybridDictionary HybridDictionary
        {
            get { return _parameters; }
        }

        #endregion

        #region Indexers

        // Retrieve a parameter value if it exists
        // (overriding C# indexer property)
        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get or set.</param>
        /// <returns>The value associated with the specified key. If the specified key is not
        /// found, attempting to get it returns null, and attempting to set it creates
        /// a new entry using the specified key.</returns>
        public object this[string key]
        {
            get { return _parameters[key]; }
        }

        #endregion
    }
}