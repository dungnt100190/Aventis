using System;
using System.Data;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Fibu
{
    #region Enumerations

    /// <summary>
    /// Summary description for Utils.
    /// </summary>
    /// 
    public enum BuchungDTAStatus
    {
        Unbekannt,
        Generiert,
        Übermittelt,
        Bezahlt,
        Fehlerhaft
    }

    public enum KontoKlasse
    {
        Unbekannt,
        Aktiven,
        Passiven,
        Aufwand,
        Ertrag,
        Spezial
    }

    #endregion

    public class FibuUtilities
    {
        #region Methods

        #region Public Static Methods

        public static void BankSuchen(string input, bool open, SqlQuery qry)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            if (dlg.SearchBank(input, open))
            {
                qry["FinanzInstitut"] = dlg["Name"];
                qry["BaBankID"] = dlg["BaBankID"];
                qry["PCKontoNr"] = dlg["PCKontoNr"];
                qry["ClearingNr"] = dlg["ClearingNr"];
            }
            qry.RefreshDisplay();
            dlg.Dispose();
        }

        public static void BankSuchen(string input, bool open, Control ctl, ref int keyValue)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            if (dlg.SearchBank(input, open))
            {
                ctl.Text = Convert.ToString(dlg["Name"]);
                keyValue = Convert.ToInt32(dlg["BaBankID"]);
            }
            dlg.Dispose();
        }

        #endregion

        #region Internal Static Methods

        internal static string AndOrWhere(string Sql)
        {
            if (Sql.IndexOf("where") == -1)
                return " where ";
            else
                return " and ";
        }

        internal static void CheckPCKontoNr(DataRow r, ref string errorText, bool allowNull)
        {
            if (allowNull == false)
            {
                if (DBUtil.IsEmpty(r["PCKontoNr"]))
                    errorText += "PostKonto Nr fehlt" + Environment.NewLine;
            }

            if (!DBUtil.IsEmpty(r["PCKontoNr"]))
            {
                if (!Utils.CheckMod10Nummer(r["PCKontoNr"].ToString()))
                    errorText += "PostKonto falsch" + Environment.NewLine;
            }
        }

        internal static string CheckZahlungsWeg(DataRow buchung, object baBankID)
        {
            return CheckZahlungsWeg(buchung, null, baBankID);
        }

        internal static string CheckZahlungsWeg(DataRow fbZahlungsweg, DataRow fbKreditor, object baBankID)
        {
            string errorText = "";

            try
            {
                ZahlungsArt temp = ZahlungsArt.Unbekannt;

                if (fbZahlungsweg["ZahlungsArtCode"] != DBNull.Value)
                    temp = (ZahlungsArt)Enum.Parse(typeof(ZahlungsArt), fbZahlungsweg["ZahlungsArtCode"].ToString(), true);

                switch (temp)
                {
                    case ZahlungsArt.Unbekannt:
                        errorText += "ZahlungsArt fehlt" + Environment.NewLine;
                        break;
                    //Post Direkt
                    case ZahlungsArt.OrangerEinzahlungsschein:
                        {
                            CheckPCKontoNr(fbZahlungsweg, ref errorText, false);
                            break;
                        }
                    case ZahlungsArt.RoterEinzahlungsscheinPost:
                        {
                            if (fbKreditor == null)
                                CheckPLZOrt(fbZahlungsweg, ref errorText);
                            else
                                CheckPLZOrt(fbKreditor, ref errorText);

                            CheckPCKontoNr(fbZahlungsweg, ref errorText, false);
                            break;
                        }
                    case ZahlungsArt.Blau_Orange_ESR_ueber_Bank:
                        CheckPCKontoNr(fbZahlungsweg, ref errorText, false);
                        break;
                    case ZahlungsArt.BankzahlungSchweiz:
                        {
                            if (fbKreditor == null)
                                CheckPLZOrt(fbZahlungsweg, ref errorText);
                            else
                                CheckPLZOrt(fbKreditor, ref errorText);

                            CheckPCKontoNr(fbZahlungsweg, ref errorText, false);
                            CheckIban(fbZahlungsweg, ref errorText);
                            break;
                        }
                    case ZahlungsArt.BankUeberweisung:
                        {
                            if (fbKreditor == null)
                                CheckPLZOrt(fbZahlungsweg, ref errorText);
                            else
                                CheckPLZOrt(fbKreditor, ref errorText);

                            CheckBank(fbZahlungsweg, baBankID, ref errorText);
                            break;
                        }
                    case ZahlungsArt.Postmandat:
                        {
                            if (fbKreditor == null)
                            {
                                CheckStrasse(fbZahlungsweg, ref errorText);
                                CheckPLZOrt(fbZahlungsweg, ref errorText);
                            }
                            else
                            {
                                CheckStrasse(fbKreditor, ref errorText);
                                CheckPLZOrt(fbKreditor, ref errorText);
                            }

                            break;
                        }
                }
                return errorText;
            }
            catch (Exception e)
            {
                errorText = e.Message;
                return errorText;
            }
        }

        internal static bool IsValidPCKontoNr(string kontoNummer)
        {
            if (Utils.IsNatural(kontoNummer) && kontoNummer.Length > 5 && kontoNummer.Length < 10)
                return true;
            else
                return false;
        }

        #endregion

        #region Private Static Methods

        private static void CheckBank(DataRow r, object baBankID, ref string errorText)
        {
            if (DBUtil.IsEmpty(r["BankKontoNr"]))
                errorText += "Bankkonto Nr fehlt" + Environment.NewLine;

            if (baBankID == DBNull.Value)
                errorText += "Bank Fehlt" + Environment.NewLine;
        }

        private static void CheckIban(DataRow row, ref string errorText)
        {
            if (DBUtil.IsEmpty(row["IBAN"]))
            {
                errorText += "IBAN fehlt" + Environment.NewLine;
            }

            // TODO Validate IBAN
        }

        private static void CheckPLZOrt(DataRow r, ref string errorText)
        {
            if (r["PLZ"] == DBNull.Value)
                errorText += "Kreditor Postleitzahl fehlt " + Environment.NewLine;
            if (r["Ort"] == DBNull.Value)
                errorText += "Kreditor Ort fehlt " + Environment.NewLine;
        }

        private static void CheckStrasse(DataRow r, ref string errorText)
        {
            if (r["Strasse"] == DBNull.Value)
                errorText += "Kreditor Strasse fehlt " + Environment.NewLine;
        }

        #endregion

        #endregion
    }
}