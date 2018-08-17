using System;
using System.IO;

using KiSS4.Common;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Summary description for Ezag27
    /// </summary>
    public class Ezag27 : EzagNoBsrRecord
    {
        #region Fields

        #region Private Fields

        private string _clearingNummer;

        #endregion

        #endregion

        #region Constructors

        //Wie Ezag 22
        /// <summary>
        /// Initializes a new instance of the <see cref="Ezag27"/> class.
        /// </summary>
        /// <param name="aufgabebetragParam">The aufgabebetrag param.</param>
        /// <param name="clearingNummerParam">The clearing nummer param.</param>
        /// <param name="endBeguenstigterkontoNummerParam">The end beguenstigterkonto nummer param.</param>
        /// <param name="empfaengersNameVornameParam">The empfaengers name vorname param.</param>
        /// <param name="empfaengersZusaetlicheBezeichnungParam">The empfaengers zusaetliche bezeichnung param.</param>
        /// <param name="empfaengersStrasseParam">The empfaengers strasse param.</param>
        /// <param name="empfaengersPostleitzahlParam">The empfaengers postleitzahl param.</param>
        /// <param name="empfaengersOrtParam">The empfaengers ort param.</param>
        /// <param name="endBeguenstigtenNameVornameParam">The end beguenstigten name vorname param.</param>
        /// <param name="endBeguenstigtenZusaetlicheBezeichnungParam">The end beguenstigten zusaetliche bezeichnung param.</param>
        /// <param name="endBeguenstigtenStrasseParam">The end beguenstigten strasse param.</param>
        /// <param name="endBeguenstigtenPostleitzahlParam">The end beguenstigten postleitzahl param.</param>
        /// <param name="endBeguenstigtenOrtParam">The end beguenstigten ort param.</param>
        /// <param name="mitteilungen1Param">The mitteilungen1 param.</param>
        /// <param name="mitteilungen2Param">The mitteilungen2 param.</param>
        /// <param name="mitteilungen3Param">The mitteilungen3 param.</param>
        /// <param name="mitteilungen4Param">The mitteilungen4 param.</param>
        /// <param name="auftraggeberNameVornameParam">The auftraggeber name vorname param.</param>
        /// <param name="auftraggeberZusaetlicheBezeichnungParam">The auftraggeber zusaetliche bezeichnung param.</param>
        /// <param name="auftraggeberStrasseParam">The auftraggeber strasse param.</param>
        /// <param name="auftraggeberPostleitzahlParam">The auftraggeber postleitzahl param.</param>
        /// <param name="auftraggeberOrtParam">The auftraggeber ort param.</param>
        public Ezag27(
            decimal aufgabebetragParam,
            string clearingNummerParam,
            string endBeguenstigterkontoNummerParam,
            string empfaengersNameVornameParam,
            string empfaengersZusaetlicheBezeichnungParam,
            string empfaengersStrasseParam,
            string empfaengersPostleitzahlParam,
            string empfaengersOrtParam,
            string endBeguenstigtenNameVornameParam,
            string endBeguenstigtenZusaetlicheBezeichnungParam,
            string endBeguenstigtenStrasseParam,
            string endBeguenstigtenPostleitzahlParam,
            string endBeguenstigtenOrtParam,
            string mitteilungen1Param,
            string mitteilungen2Param,
            string mitteilungen3Param,
            string mitteilungen4Param,
            string auftraggeberNameVornameParam,
            string auftraggeberZusaetlicheBezeichnungParam,
            string auftraggeberStrasseParam,
            string auftraggeberPostleitzahlParam,
            string auftraggeberOrtParam)
            : base(EzagHeader.TransaktionsArt.Bank27,
                aufgabebetragParam,
                empfaengersNameVornameParam,
                empfaengersZusaetlicheBezeichnungParam,
                empfaengersStrasseParam,
                empfaengersPostleitzahlParam,
                empfaengersOrtParam,
                endBeguenstigterkontoNummerParam,
                endBeguenstigtenNameVornameParam,
                endBeguenstigtenZusaetlicheBezeichnungParam,
                endBeguenstigtenStrasseParam,
                endBeguenstigtenPostleitzahlParam,
                endBeguenstigtenOrtParam,
                mitteilungen1Param,
                mitteilungen2Param,
                mitteilungen3Param,
                mitteilungen4Param,
                auftraggeberNameVornameParam,
                auftraggeberZusaetlicheBezeichnungParam,
                auftraggeberStrasseParam,
                auftraggeberPostleitzahlParam,
                auftraggeberOrtParam)
        {
            ClearingNummer = clearingNummerParam;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Pos 1+2 = 08 or 07
        /// Pos 3-7 = ClearingNummer
        /// Pos 8 Key Number Mod 10 ClearingNummer
        /// Pos 9 Key Numer Overall
        /// </summary>
        public string ClearingNummer
        {
            get { return _clearingNummer; }
            set
            {
                if (value.Length == 0)
                {
                    throw new PaymentFatalException("ClearingNummer ist obligatorisch");
                }
                    // no bank abreviation
                if (value.Length <= 6)
                {
                    _clearingNummer = "  " + Utilities.FillBlanks(value, 6, "0", true) + " ";
                }
                    // bank abreviation
                else if (value.IndexOf("08") != -1 || value.IndexOf("07") != -1)
                {
                    if (value.Length == 8)
                    {
                        _clearingNummer = Utilities.FillBlanks(value, 9, " ", true);
                    }
                    else if (value.Length == 9)
                    {
                        _clearingNummer = value;
                    }
                }
                else
                {
                    string temp = Utilities.FillBlanks(value.Substring(0, value.Length - 2), 7, "0", true) + value.Substring(value.Length - 2, 2);
                    if (!Utils.CheckMod10Nummer(temp))
                    {
                        throw new PaymentFatalException("ClearingNummer Error");
                    }
                    _clearingNummer = value;
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Writes to UZAG file.
        /// </summary>
        /// <param name="sw">The sw.</param>
        public override void WriteToUzagFile(StreamWriter sw)
        {
            base.WriteToUzagFile(sw);

            try
            {
                //Nummer Gelbes Konto des Empfängers
                sw.Write(ClearingNummer);

                //Reserve
                sw.Write(Utilities.FillBlanks("", 6, " ", true));

                //Bankkonto-Nr. des Endbegünstigten
                sw.Write(EndBeguenstigtenBankkontoNummerToDTA);

                //Name/Vorname des Empfängers
                sw.Write(EmpfaengersNameVornameToDTA);

                //Zusätzliche Bezeichnung des Empfängers
                sw.Write(EmpfaengersZusaetlicheBezeichnungToDTA);

                //Strasse des Empfängers
                sw.Write(EmpfaengersStrasseToDTA);

                //Postleitzahl des Empfängers
                sw.Write(EmpfaengersPostleitzahlToDTA);

                //Ort des Empfängers
                sw.Write(EmpfaengersOrtToDTA);

                //Name/Vorname des Endbegünstigten
                sw.Write(Utilities.FillBlanks(Utilities.RemoveNewLines(EndBeguenstigtenNameVorname), 35, " ", true));

                //Zusätzliche Bezeichnung des Endbegünstigten
                sw.Write(Utilities.FillBlanks(EndBeguenstigtenZusaetlicheBezeichnung, 35, " ", true));

                //Strasse des Endbegünstigten
                sw.Write(Utilities.FillBlanks(EndBeguenstigtenStrasse, 35, " ", true));

                //Postleitzahl des Endbegünstigten
                sw.Write(Utilities.FillBlanks(EndBeguenstigtenPostleitzahl, 10, " ", true));

                //Ort des Endbegünstigten
                sw.Write(Utilities.FillBlanks(EndBeguenstigtenOrt, 25, " ", true));

                //Mitteilungen Block 1
                sw.Write(Mitteilungen1ToDTA);

                //Mitteilungen Block 2
                sw.Write(Mitteilungen2ToDTA);

                //Mitteilungen Block 3
                sw.Write(Mitteilungen3ToDTA);

                //Mitteilungen Block 4
                sw.Write(Mitteilungen4ToDTA);

                //Reserve
                sw.Write(Utilities.FillBlanks("", 4, " ", true));

                //Name/Vorname des Auftraggebers
                sw.Write(AuftraggeberNameVornameToDTA);

                //Zusätzliche Bezeichnung des Auftraggebers
                sw.Write(AuftraggeberZusaetlicheBezeichnungToDTA);

                //Strasse des Auftraggebers
                sw.Write(AuftraggeberStrasseToDTA);

                //Postleitzahl des Auftraggebers
                sw.Write(AuftraggeberPostleitzahlToDTA);

                //Ort des Auftraggebers
                sw.Write(AuftraggeberOrtToDTA);

                //Reserver
                sw.Write(Utilities.FillBlanks("", 14, " ", true));
            }
            catch (Exception e)
            {
                throw new PaymentFatalException(e.Message);
            }
        }

        #endregion

        #endregion
    }
}