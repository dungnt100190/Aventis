using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using KiSS4.DB;

namespace KiSS4.Klientenbuchhaltung.BL
{
    // http://www.patterndepot.com/put/8/Creational_Patterns.htm
    public class KlibuEnvironmentFactory
    {
        #region Fields

        #region Public Constant/Read-Only Fields
        private const string KLIBUSYS_CONFIG_STRING = @"System\KliBu\KliBuSys"; // config key to get the FibuSys from (Sozialhilfe)

        //public const string cnfFibuSysAsyl = @"System\FibuLinkAsyl\FibuSys"; // config key to get the FibuSys from (Asyl)
        //public const string CnfFibuLink = @"System\FibuLink"; // root key for all FibuLink entries (Sozialhilfe)
        //public const string CnfFibuLinkAsyl = @"System\FibuLinkAsyl"; // root key for all FibuLink entries (Asyl)
        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Factory method to create a KlibuEnvironment
        /// </summary>
        /// <returns>The corresponding KlibuEnvironment depending on the Config Value KLIBUSYS_CONFIG_STRING
        /// Possible Values: "Kein",  "Integriert"
        /// </returns>
        public static KlibuEnvironment CreateKlibuEnvironment()
        {
            string klibuSysConfig = null;
            klibuSysConfig = (string)DBUtil.GetConfigValue(KLIBUSYS_CONFIG_STRING, null);

            KlibuSystem sys;
            if (klibuSysConfig == null)
            {
                sys = KlibuSystem.Kein;
            }
            else
                try
                {
                    sys = (KlibuSystem)Enum.Parse(typeof(KlibuSystem), klibuSysConfig, true);
                }
                catch
                {
                    throw new ApplicationException("Unbekanntes KliBu-System \"" + klibuSysConfig + "\".");
                }

            KlibuEnvironment ret;

            switch (sys)
            {
                case KlibuSystem.Kein:
                    ret = new None.KlibuEnvironmentNone();
                    break;
                case KlibuSystem.Integriert: 
                    ret = new Internal.KlibuEnvironmentInternal();
                    break;
                default:
                    throw new ApplicationException("internal error");
            }
            return ret;
        }

        #endregion

        #endregion
    }
}