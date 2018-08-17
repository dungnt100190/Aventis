using System;

namespace KiSS4.Schnittstellen.Abacus.Mitarbeiter
{
    public class TypeHelper
    {
        public Boolean CompareDates(DateTime? dateA, Object dateK)
        {
            Boolean ret = false;

            if (!dateA.HasValue && KAConUtil.IsDBNull(dateK))
            {
                return true;
            }

            if (dateA.HasValue && dateK != null)
            {
                if (!KAConUtil.IsDBNull(dateK))
                {
                    if (Convert.ToDateTime(dateK) == dateA.Value)
                    {
                        ret = true;
                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// Auf der Datenbank sind unsere Float-Teile
        /// als MONEY abgelegt :(
        /// Nix von Gleitkomma.
        /// In der Hoffnung, es gibt keinen Overflow.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public Boolean CompareDoubles(float a, Object k)
        {
            long a1 = (long)(a * 10000);

            if (KAConUtil.IsDBNull(k))
            {
                return false;
            }

            long k1 = (long)(this.GetDouble(k) * 10000);

            return a1 == k1;
        }

        /// <summary>
        /// Compare two objects as string
        /// </summary>
        /// <param name="a">The first value</param>
        /// <param name="k">The second value</param>
        /// <param name="doTrim">True does compare with Trim(), false without Trim()</param>
        /// <returns>True if objects as string are equal, otherwise false</returns>
        public Boolean CompareStrings(string a, Object k, Boolean doTrim)
        {
            Boolean ret = false;

            if (a == null)
                a = "";

            // check mode
            if (doTrim)
            {
                // compare using trim
                ret = a.Trim().Equals(this.GetString(k).Trim());
            }
            else
            {
                // compare without trim
                ret = a.Equals(this.GetString(k));
            }

            return ret;
        }

        /// <summary>
        /// Create double from object
        /// </summary>
        /// <param name="o">The object to get double from</param>
        /// <returns>The double of the object</returns>
        public Double GetDouble(Object o)
        {
            return Convert.ToDouble(o);
        }

        /// <summary>
        /// Create int32 from object
        /// </summary>
        /// <param name="o">The object to get int32 from</param>
        /// <returns>The int32 of the object</returns>
        public Int32 GetInt32(Object o)
        {
            return Convert.ToInt32(o);
        }

        /// <summary>
        /// Create string from object
        /// </summary>
        /// <param name="o">The object to get string from</param>
        /// <returns>The string of the object</returns>
        public String GetString(Object o)
        {
            return Convert.ToString(o);
        }
    }
}