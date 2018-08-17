using System;
using System.IO;

using KiSS4.Common;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Implementiert einen EZAG22 Record.
    /// </summary>
    /// <remarks>
    /// Bei Überweisung auf ein Gelbes Konto einer Bank erforderlich.
    /// </remarks>
    public class Ezag22 : EzagNoBsrRecord
    {
        #region Fields

        #region Private Fields

        private string _empfaengerGelbeskontoNummer;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Ezag22"/> class.
        /// </summary>
        /// <param name="aufgabebetrag">Der Aufgabebetrag.</param>
        /// <param name="empfaengerGelbeskontoNummerParam">The empfaenger gelbeskonto nummer param.</param>
        /// <param name="empfaengersNameVornameParam">The empfaengers name vorname param.</param>
        /// <param name="empfaengersZusaetlicheBezeichnungParam">The empfaengers zusaetliche bezeichnung param.</param>
        /// <param name="empfaengersStrasseParam">The empfaengers strasse param.</param>
        /// <param name="empfaengersPostleitzahlParam">The empfaengers postleitzahl param.</param>
        /// <param name="empfaengersOrtParam">The empfaengers ort param.</param>
        /// <param name="endBeguenstigterkontoNummerParam">The end beguenstigterkonto nummer param.</param>
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
        public Ezag22(
            Decimal aufgabebetrag,
            String empfaengerGelbeskontoNummerParam,
            String empfaengersNameVornameParam,
            String empfaengersZusaetlicheBezeichnungParam,
            String empfaengersStrasseParam,
            String empfaengersPostleitzahlParam,
            String empfaengersOrtParam,
            String endBeguenstigterkontoNummerParam,
            String endBeguenstigtenNameVornameParam,
            String endBeguenstigtenZusaetlicheBezeichnungParam,
            String endBeguenstigtenStrasseParam,
            String endBeguenstigtenPostleitzahlParam,
            String endBeguenstigtenOrtParam,
            String mitteilungen1Param,
            String mitteilungen2Param,
            String mitteilungen3Param,
            String mitteilungen4Param,
            String auftraggeberNameVornameParam,
            String auftraggeberZusaetlicheBezeichnungParam,
            String auftraggeberStrasseParam,
            String auftraggeberPostleitzahlParam,
            String auftraggeberOrtParam)
            : base(EzagHeader.TransaktionsArt.Post22,
                aufgabebetrag,
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
            EmpfaengerGelbeskontoNummer = empfaengerGelbeskontoNummerParam;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the empfaenger gelbeskonto nummer.
        /// </summary>
        /// <value>The empfaenger gelbeskonto nummer.</value>
        public string EmpfaengerGelbeskontoNummer
        {
            get { return _empfaengerGelbeskontoNummer; }
            set
            {
                if (!Utils.CheckMod10Nummer(Utils.FormatPCKontoNummerToDBFormat(value)))
                {
                    throw new PaymentFatalException("Kontonummer (gelbes Konto) ist ungültig : " + value);
                }
                _empfaengerGelbeskontoNummer = Utils.FormatPCKontoNummerToDBFormat(value);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Schreibt den Record in den angegebenen Stream.
        /// </summary>
        /// <param name="sw">The stream</param>
        public override void WriteToUzagFile(StreamWriter sw)
        {
            base.WriteToUzagFile(sw);

            try
            {
                //Nummer Gelbes Konto des Empfängers
                sw.Write(Utilities.FillBlanks(EmpfaengerGelbeskontoNummer, 9, "0", false));

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