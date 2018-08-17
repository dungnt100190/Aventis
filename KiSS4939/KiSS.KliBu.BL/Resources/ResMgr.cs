using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;

using KiSS.Common;

namespace KiSS.KliBu.BL.Resources
{
    public class ResMgr : ResourceManager
    {
        #region Fields

        #region Private Static Fields

        private static Func<ResourceManager> resourceManagerFunc = () => new ResMgr();

        #endregion

        #endregion

        #region Constructors

        public ResMgr()
            : base("KiSS.KliBu.BL.Resources.Messages", typeof(ResMgr).Assembly)
        {
        }

        #endregion

        #region Properties

        public static ResourceManager Current
        {
            get { return resourceManagerFunc(); }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Gets the message in the current language
        /// </summary>
        /// <param name="key">A ressource key referenced in the Messages.resx file.</param>
        /// <returns></returns>
        public static FormattedMessage GetMsg(string key)
        {
            string message = Current.GetString(key, CultureInfo.CurrentCulture);

            if (message == null)
            {
                // TODO
                throw new InvalidOperationException(string.Format("Could not find a resource key with the name '{0}'.", key));
            }
            return new FormattedMessage(message);
        }

        public static void SetResourceManagerProvider(Func<ResourceManager> resouceManagerProvider)
        {
            resourceManagerFunc = resouceManagerProvider;
        }

        #endregion

        #endregion
    }
}