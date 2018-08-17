using System;

namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten
{
    public class WebServiceHelper
    {
        #region Public Methods

        /// <summary>
        /// Get the current millisecs as long from the System time 
        /// </summary>
        /// <returns>The current miliseconds from system time</returns>
        public static long GetCurrentMilliseconds()
        {
            return (((System.DateTime.Now.Hour * 3600) + (System.DateTime.Now.Minute * 60) + System.DateTime.Now.Second) * 1000) + System.DateTime.Now.Millisecond;
        }

        /// <summary>
        /// Shorten the given string to a given maximum length
        /// </summary>
        /// <param name="stringValue">The string to shorten</param>
        /// <param name="maxLength">The maximum length the string shall have</param>
        /// <returns>Null if string is null or maxLength smaller than 0, else string with maximum length</returns>
        public static String ShortenStringToMaxLength(String stringValue, Int32 maxLength)
        {
            // negative max length or null-string = no string
            if (maxLength < 0 || stringValue == null)
            {
                return null;
            }

            // if string is shorter than max return string
            if (stringValue.Length <= maxLength)
            {
                return stringValue;
            }

            // after here, we shorten text and add ".." to it, therefore, the maxLength has to be >= 2
            if (maxLength < 2)
            {
                // return only shorter string without ".."
                return stringValue.Substring(0, maxLength);
            }
            else
            {
                // shorten string and ad ".." to it
                return String.Format("{0}..", stringValue.Substring(0, maxLength - 2));
            }
        }

        #endregion
    }
}