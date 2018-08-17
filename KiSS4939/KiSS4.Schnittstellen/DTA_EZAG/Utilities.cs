using System;
using System.Collections;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Text;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Utility class for EZAG an DTA.
    /// </summary>
    public static class Utilities
    {
        public enum KbFinanzInstitutCode
        {
            Ezag = 0,
            Dta = 1,
            Iso20022 = 2,
        }

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Calculates the code lines mod11.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static String CalculateCodeLinieMod11(
            String value)
        {
            var array = new[] { 4, 3, 2, 7, 6, 5 };
            int result = 0;
            int j = 0;
            var arrayList = new ArrayList();

            for (int i = 0; i < value.Length; i++)
            {
                arrayList.Add(Convert.ToInt32(Convert.ToString(value[i])) * array[j]);
                j += 1;
                if (j == 6)
                {
                    j = 0;
                }
            }

            for (int i = 0; i < arrayList.Count; i++)
            {
                result += (int)arrayList[i];
            }

            result = (result % 11);
            result = 11 - result;

            return FillBlanks(result.ToString(CultureInfo.InvariantCulture), 2, "0", false);
        }

        /// <summary>
        /// Überprüft die Postleitzahl auf ihre syntaktische Korrekheit. 1 = Ok, 2 = too long, 3 =
        /// invalid, 4 = empty
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns>1 = Ok, 2 = too long, 3 = invalid, 4 = empty</returns>
        /// <remarks>"4149" obwohl syntaktisch korrekt, ist diese PLZ ungültig.</remarks>
        public static Int32 CheckPostLeitzahl(
            String zipCode)
        {
            var containsNumber =
                new Regex("[0-9]");

            if (String.IsNullOrEmpty(zipCode))
            {
                return 4;
            }

            if (zipCode.Length > 10)
            {
                return 2;
            }

            if (!containsNumber.IsMatch(zipCode))
            {
                return 3;
            }

            return 1;
        }

        /// <summary>
        /// Converts the specified DateTime into a a DTA string.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static String DateTimeToDTAString(
            DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return "000000";
            }
            return date.ToString("yyMMdd");
        }

        public static string EnsureLatinCharacterSet(string text, int? maxLength = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            //Ungültige Zeichen entfernen
            Regex regex = new Regex(@"[^a-zA-Z0-9\.,;:'\+\-/\(\)?\*\[\]\{\}\\`´~ !""#%&<>÷=@_$£àáâäçèéêëìíîïñòóôöùúûüýßÀÁÂÄÇÈÉÊËÌÍÎÏÒÓÔÖÙÚÛÜÑ]");
            text = regex.Replace(text, "");

            //MaxLength sicherstellen
            if (maxLength.HasValue && text.Length > maxLength.Value)
            {
                text = text.Substring(0, maxLength.Value);
            }

            return text;
        }

        public static string EnsureSWIFTCharacterSet(string text, int? maxLength = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            //ÄÖÜäöü durch AE, OE, UE, ae, oe, ue
            text = text
                .Replace("ä", "ae")
                .Replace("ö", "oe")
                .Replace("ü", "ue")
                .Replace("Ä", "AE")
                .Replace("Ö", "OE")
                .Replace("Ü", "UE");

            //Akzente entfernen (é --> e)
            text = RemoveAccents(text);

            //ungültige Zeichen entfernen
            Regex regex = new Regex(@"[^A-Za-z0-9+\?/\-:\(\)\.,'\p{Zs}]");
            text = regex.Replace(text, "");

            //MaxLength sicherstellen
            if (maxLength.HasValue && text.Length > maxLength.Value)
            {
                text = text.Substring(0, maxLength.Value);
            }

            return text;
        }

        /// <summary>
        /// Adds padding characters to a given string.
        /// </summary>
        /// <param name="input">the input string.</param>
        /// <param name="requiredLength">The length of the output string.</param>
        /// <param name="paddingCharacter">The character.</param>
        /// <param name="atEnd">if set to <c>true</c> padding is added at the end of the string.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static String FillBlanks(
            String input,
            Int32 requiredLength,
            String paddingCharacter,
            Boolean atEnd)
        {
            // --- check input parameters
            if (String.IsNullOrEmpty(paddingCharacter))
            {
                throw new ArgumentOutOfRangeException("paddingCharacter");
            }

            if (requiredLength < 0)
            {
                throw new ArgumentOutOfRangeException("requiredLength");
            }

            if (String.IsNullOrEmpty(input))
            {
                input = String.Empty;
            }

            // --- if string is too short, add padding character either at the end or at the beginning.
            while (input.Length < requiredLength)
            {
                if (atEnd)
                {
                    input = input + paddingCharacter;
                }
                else
                {
                    input = paddingCharacter + input;
                }
            }

            // --- if resulting string is too long truncate it
            if (input.Length > requiredLength)
            {
                input = input.Substring(0, requiredLength);
            }

            return input;
        }

        /// <summary>
        /// Converts the specifed decimal to a DTA money string.
        /// </summary>
        /// <param name="nummer">The nummer.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static string FormatDecimalToDTAMoney(
            string nummer,
            int length)
        {
            int nummerLength = nummer.Length;
            nummer = nummer.Substring(0, nummerLength - 2);
            nummer = nummer.Replace(".", "");
            return FillBlanks(nummer, length, "0", false);
        }

        /// <summary>
        /// Gets the DTA directory.
        /// </summary>
        /// <returns></returns>
        public static String GetDirectory(KbFinanzInstitutCode code)
        {
            string path = null;
            if (code == KbFinanzInstitutCode.Dta)
            {
                path = Convert.ToString(DBUtil.GetConfigValue(@"System\KliBu\DTA\Verzeichnis", ""));
            }
            else if (code == KbFinanzInstitutCode.Iso20022)
            {
                path = Convert.ToString(DBUtil.GetConfigValue(@"System\KliBu\Iso20022\Verzeichnis", ""));
            }

            if (String.IsNullOrEmpty(path))
            {
                return null;
            }

            // --- patch path if necessary
            if (!path.EndsWith(@"\"))
            {
                path += @"\";
            }

            return path;
        }

        /// <summary>
        /// Liefert die Zahlungsmethode für die Mandatsbuchhaltung.
        /// </summary>
        /// <param name="paymentInformation">The payment information.</param>
        /// <returns></returns>
        public static ZahlungsArt GetPaymentMethod(
            object paymentInformation)
        {
            var paymentType =
                (ZahlungsArt)Enum.Parse(typeof(ZahlungsArt), Utils.ConvertToString(paymentInformation), true);
            return paymentType;
        }

        /// <summary>
        /// Liefert die Zahlungsmethode für die Klientenbuchhaltung.
        /// </summary>
        /// <param name="paymentInformation">The payment information.</param>
        /// <returns></returns>
        public static Einzahlungsschein GetPaymentMethodKlientenbuchhaltung(
            object paymentInformation)
        {
            var paymentType = (Einzahlungsschein)(Utils.ConvertToInt(paymentInformation));

            //Einzahlungsschein paymentType =
            //	(Einzahlungsschein)Enum.Parse(typeof(Einzahlungsschein), Utils.ConvertToString(paymentInformation), true);
            return paymentType;
        }

        /// <summary>
        /// Liefert die Zahlungsmethode für die Klientenbuchhaltung.
        /// </summary>
        /// <param name="paymentInformation">The payment information.</param>
        /// <returns></returns>
        public static ZahlungsArt GetPaymentMethodMandatsbuchhaltung(
            object paymentInformation)
        {
            var paymentType = (ZahlungsArt)(Utils.ConvertToInt(paymentInformation));

            //ZahlungsArt paymentType =
            //	(ZahlungsArt)Enum.Parse(typeof(ZahlungsArt), Utils.ConvertToString(paymentInformation), true);
            return paymentType;
        }

        public static string RemoveAccents(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Converts the specified string into a DTA string.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        public static String RemoveNewLines(string str)
        {
            if (str == null)
            {
                return "";
            }
            return str.Replace('\n', ' ').Replace('\r', ' ');
        }

        /// <summary>
        /// Converts the specified string into a DTA string.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        public static String StringToDTAString(
            String str)
        {
            if (str == null)
            {
                return "";
            }
            return str.ToUpper().Replace('Ä', 'A').Replace('Ö', 'O').Replace('Ü', 'U');
        }

        #endregion

        #endregion
    }
}