using System;
using System.Collections.Generic;
using System.Xml;

using Kiss.Infrastructure.Constant;

namespace Kiss.Server.PSCD.Helper
{
    public class PscdHelper
    {
        #region Methods

        #region Internal Static Methods

        /// <summary>
        /// Konvertiert ein string in ein DateTime?. (Für object-initializer).
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        internal static DateTime? ConvertDate(string dateString)
        {
            DateTime d;

            if (DateTime.TryParse(dateString, out d))
            {
                return d;
            }

            return null;
        }

        /// <summary>
        /// Konvertiert DateTime in das SAP-Datumsformat
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        internal static string ConvertDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Bestimmt den vorzeichenbehafteten, PSCD-konformen Betrag einer Belegposition
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        internal static decimal GetBetragBruttoWithSign(Model.KbuBelegPosition pos)
        {
            return pos.SollHaben == "S" ? -pos.BetragBrutto : pos.BetragBrutto;
        }

        /// <summary>
        /// Berechnet die ESR-Prüfziffer
        /// </summary>
        /// <param name="refNr"></param>
        /// <returns></returns>
        internal static string GetReceiverEsrCheckdigit(string refNr)
        {
            if (!string.IsNullOrEmpty(refNr) && refNr.Length >= 27)
            {
                return refNr[refNr.Length - 1].ToString();
            }
            return null;
        }

        /// <summary>
        /// Umsetzung von BaLandID zum entsprechenden SAP-Landcode
        /// SAP-Landcode entspricht weitgehend dem Iso2Code, jedoch nicht immer
        /// </summary>
        /// <param name="baLandID"></param>
        /// <param name="countryLookup"></param>
        /// <returns></returns>
        internal static string GetSapCountryCode(int? baLandID, IDictionary<int, string> countryLookup)
        {
            string sapCountryCode;
            if (baLandID.HasValue && countryLookup.TryGetValue(baLandID.Value, out sapCountryCode))
            {
                return sapCountryCode;
            }
            return null;
        }

        /// <summary>
        /// Bestimmt den PSCD-TransactionType aufgrund von Belegposition und Belegkopf
        /// </summary>
        /// <param name="position"></param>
        /// <param name="beleg"></param>
        /// <returns></returns>
        internal static string GetTransactionType(Model.KbuBelegPosition position, Model.KbuBeleg beleg)
        {
            if (beleg.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Auszahlung)
            {
                if (position.SollHaben == "S")
                {
                    return "A"; // Ausgabe
                }
                return "N"; // Nicht abgetretene Einnahme
            }
            if (beleg.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Einzahlung)
            {
                return "E"; // Einzahlung
            }
            return null;
        }

        /// <summary>
        /// Formatiert die Postkontonummer, z.B. 123456789 zu 12-345678-9
        /// </summary>
        /// <param name="pcNummer"></param>
        /// <returns></returns>
        internal static string MakePcNr(string pcNummer)
        {
            if (string.IsNullOrEmpty(pcNummer) || pcNummer.IndexOf('-') > 0 || pcNummer.Length != 9)
                return pcNummer;

            return string.Format("{0}-{1}-{2}", pcNummer.Substring(0, 2), pcNummer.Substring(2, 6).TrimStart('0'), pcNummer[8]);
        }

        /// <summary>
        /// Formatiert eine Technische Exception (Timeout, technische Fehler von XI) in einen String
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        internal static string ProcessSoapException(System.Web.Services.Protocols.SoapException ex)
        {
            // probieren wir den java-Stacktrace auseinanderzunehmen
            var textNode = ex.Detail.SelectSingleNode("//text");
            if (textNode != null && textNode.ChildNodes.Count > 0 && textNode.ChildNodes[0].NodeType == XmlNodeType.CDATA)
            {
                var text = textNode.ChildNodes[0].Value;
                if (!string.IsNullOrEmpty(text))
                {
                    if (text.IndexOf("either no channelID specified or no channel found for the specified party, service, and channel name") > -1)
                    {
                        return "Der KiSS-Server hat XI erreicht, XI kann aber nichts mit der URL anfangen. Ist die URL korrekt konfiguriert?";
                    }
                    if (text.IndexOf("RFC_ERROR_COMMUNICATION: Connect to SAP gateway failed") > -1)
                    {
                        return "XI konnte keine Verbindung zu PSCD aufnehmen (RFC_ERROR_COMMUNICATION: Connect to SAP gateway failed). Versuchen Sie diesen Aufruf später nochmals.";
                    }
                    if (text.IndexOf("XIServer:CLIENT_RECEIVE_FAILED") > -1)
                    {
                        return "XI meldet einen internen Fehler (CLIENT_RECEIVE_FAILED). Versuchen Sie diesen Aufruf später nochmals.";
                    }
                    if (text.IndexOf("XIServer:RESOURCE_EXCEPTION") > -1)
                    {
                        return "XI meldet RESOURCE_EXCEPTION! Dies kann zu inkonsistenten Daten zwischen KiSS und PSCD führen.";
                    }
                    if (text.IndexOf("RFC_ERROR_LOGON_FAILURE: Name oder Kennwort ist nicht korrekt (Wiederholen Sie die Anmeldung)") > -1)
                    {
                        return "XI meldet RFC_ERROR_LOGON_FAILURE. Die in KiSS hinterlegten Angaben für XI-Logon/Passwort stimmen nicht.";
                    }
                    if (text.IndexOf("XIServer:JCO_SYSTEM_FAILURE") > -1)
                    {
                        return "XI meldet JCO_SYSTEM_FAILURE.";
                    }
                    if (text.IndexOf("XIAdapterFramework:GENERAL:com.sap.aii.af.ra.ms.api.DeliveryException: Object not found in lookup of RfcAFBean") > -1)
                    {
                        return "XI meldet 'Object not found in lookup of RfcAFBean'.";
                    }
                    if (text.IndexOf("XIServer:HTTP_RESP_STATUS_CODE_NOT_OK") > -1)
                    {
                        return "XI meldet HTTP_RESP_STATUS_CODE_NOT_OK.";
                    }
                }
            }
            return ex.Message;
        }

        /// <summary>
        /// Schneidet einen String nach einer bestimmten Länge ab
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        internal static string Truncate(string text, int length)
        {
            if (text == null)
            {
                return null;
            }
            var textLength = text.Length;
            return text.Substring(0, Math.Min(textLength, length));
        }

        #endregion

        #endregion

        internal static string PadZerosLeft(string str, int totalWidth)
        {
            return str == null ? null : str.PadLeft(totalWidth, '0');
        }
    }
}