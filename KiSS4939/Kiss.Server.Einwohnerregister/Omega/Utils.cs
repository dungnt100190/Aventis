using System;
using System.Linq;

using Kiss.BusinessLogic.Sys;
using Kiss.Infrastructure.IoC;
using Kiss.Server.Einwohnerregister.OmegaAnfrageSimpleService;

namespace Kiss.Server.Einwohnerregister.Omega
{
    public static class Utils
    {
        public const string SCHWEIZ_ISO2 = "CH";
        public const string STAATENLOS_ID = "100000";
        public const string STAATENLOS_ISO2 = "XX";
        public const string UNBEKANNT_ID = "1";
        public const string UNBEKANNT_ISO2 = "Z1";

        public static string ConvertToAhvNr(string ahv)
        {
            if (ahv == null || ahv.Length != 11)
            {
                return ahv;
            }

            return String.Format("{0}.{1}.{2}.{3}", ahv.Substring(0, 3), ahv.Substring(3, 2), ahv.Substring(5, 3), ahv.Substring(8, 3));
        }

        public static string ConvertToVersichertennummer(string versNr)
        {
            if (versNr == null || versNr.Length != 13)
            {
                return versNr;
            }

            return String.Format("{0}.{1}.{2}.{3}", versNr.Substring(0, 3), versNr.Substring(3, 4), versNr.Substring(7, 4), versNr.Substring(11, 2));
        }

        public static DateTime? GetDate(datePartiallyKnownType datePartiallyKnown)
        {
            if (datePartiallyKnown.Item != null)
            {
                int year;

                switch (datePartiallyKnown.ItemElementName)
                {
                    case ItemChoiceType.year: // YYYY
                        if (Int32.TryParse(datePartiallyKnown.Item as string, out year))
                        {
                            return new DateTime(year, 1, 1);
                        }
                        break;

                    case ItemChoiceType.yearMonth: // YYYY-MM
                        int month;
                        var str = datePartiallyKnown.Item as string;
                        if (str != null &&
                            str.Length == 7 &&
                            Int32.TryParse(str.Substring(0, 4), out year) &&
                            Int32.TryParse(str.Substring(5, 2), out month))
                        {
                            return new DateTime(year, month, 1);
                        }
                        break;

                    case ItemChoiceType.yearMonthDay:
                        return datePartiallyKnown.Item as DateTime?;
                }
            }

            return null;
        }

        /// <summary>
        /// Holt den Code des Werts mit dem angegebenen Value2.
        /// Dies passiert hier im Server, weil sich die LOVs bei den Kunden unterscheiden und der
        /// Kiss.BusinessLogic.Ba.BaEinwohnerregisterService keine kundenspezifischen Elemente beinhalten sollte.
        /// </summary>
        public static int? GetLovCodeByEchValue2(string lovName, string value2)
        {
            var xLovService = Container.Resolve<XLovService>();
            var lovCode = xLovService.GetLovCodesByLovName(lovName).FirstOrDefault(x => x.Value2 == value2);
            return lovCode != null ? lovCode.Code : (int?)null;
        }

        public static string GetOtherPersonId(namedPersonIdType[] otherPersonIds, string name)
        {
            name = name.ToUpper();
            var id = otherPersonIds.FirstOrDefault(x => x.personIdCategory.ToUpper() == name);
            return id != null ? id.personId : null;
        }

        public static string JoinAdresseZusatz(string zusatz1, string zusatz2)
        {
            if (string.IsNullOrEmpty(zusatz2))
            {
                return zusatz1;
            }

            if (string.IsNullOrEmpty(zusatz1))
            {
                return zusatz2;
            }

            return string.Format("{0} - {1}", zusatz1, zusatz2);
        }

        public static DateTime? ProcessValidDate(DateTime date)
        {
            // HACK: Omega liefert kein Nullable DateTime, weil sie das WSDL nicht mehr anpassen wollen. Ein leeres Datum wird als 9999-12-31 geliefert.
            return date.Year < 9999 ? date : (DateTime?)null;
        }
    }
}