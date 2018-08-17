namespace KiSS4.DB.Cache
{
    /// <summary>
    /// Class for managing cache used in session
    /// </summary>
    public class CacheManager
    {
        #region Fields

        #region Private Fields

        /// <summary>
        /// Store all translations for classes within cache
        /// </summary>
        private ClassTranslation _classTranslation = null;

        /// <summary>
        /// Store all config values within cache
        /// </summary>
        private ConfigValue _configValue = null;

        /// <summary>
        /// Store all multilanguage texts within cache
        /// </summary>
        private LanguageText _languageText = null;

        /// <summary>
        /// Store all lov queries within cache
        /// </summary>
        private LOVQuery _lovQuery = null;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, create new instance of class
        /// </summary>
        public CacheManager()
        {
            // init fields to start caching of values
            _configValue = new ConfigValue();
            _languageText = new LanguageText();
            _classTranslation = new ClassTranslation();
            _lovQuery = new LOVQuery();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the cached <see cref="ClassTranslation"/>
        /// </summary>
        public ClassTranslation ClassTranslation
        {
            get { return _classTranslation; }
        }

        /// <summary>
        /// Gets the cached <see cref="ConfigValue"/>
        /// </summary>
        public ConfigValue ConfigValue
        {
            get { return _configValue; }
        }

        /// <summary>
        /// Gets the cached <see cref="LanguageText"/>
        /// </summary>
        public LanguageText LanguageText
        {
            get { return _languageText; }
        }

        /// <summary>
        /// Gets the cached <see cref="LOVQuery"/>
        /// </summary>
        public LOVQuery LOVQuery
        {
            get { return _lovQuery; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Clear cache completely
        /// </summary>
        public void ClearCache()
        {
            // clear all field-caches
            _configValue.Clear();
            ClearLanguageCache();
            XLog.ClearCachedValues();
        }

        /// <summary>
        /// Clear all multilanguage specific caches
        /// </summary>
        public void ClearLanguageCache()
        {
            // clear all ml caches
            _languageText.Clear();
            _classTranslation.Clear();
            _lovQuery.Clear();
        }

        #endregion

        #endregion
    }
}