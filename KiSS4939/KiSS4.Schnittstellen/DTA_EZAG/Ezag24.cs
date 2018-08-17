using System;
using System.IO;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Record für Zahlungsanweisungen Inland (Mandats de paiement) 
    /// </summary>
    public class Ezag24 : EzagNoBsrRecord
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// Zeigt an ob der Einzahlungsschein eigenhändig ausgefüllt wurde.
        /// </summary>
        /// <remarks>Bei Überweisung auf ein Gelbes Konto einer Bank erforderlich</remarks>
        private readonly Boolean _eigenhaendig;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Ezag24"/> class.
        /// </summary>
        /// <param name="aufgabebetragParam">The aufgabebetrag param.</param>
        /// <param name="eigenhaendig">if set to <c>true</c> [eigenhaendig].</param>
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
        public Ezag24(decimal aufgabebetragParam,
            bool eigenhaendig,
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
            : base(EzagHeader.TransaktionsArt.Mandat24,
                aufgabebetragParam,
                empfaengersNameVornameParam,
                empfaengersZusaetlicheBezeichnungParam,
                empfaengersStrasseParam,
                empfaengersPostleitzahlParam,
                empfaengersOrtParam,
                "",
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
            _eigenhaendig = eigenhaendig;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gibt im DTA Format an ob der Einzahlungsschein eigenhändig ausgefüllt
        /// wurde.
        /// </summary>
        public string EigenhaendigToDTA
        {
            get
            {
                if (_eigenhaendig)
                {
                    return "1";
                }
                return " ";
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Schreibt den record in den angegebenen StreamWriter.
        /// </summary>
        /// <param name="sw">The sw.</param>
        /// <exception cref="PaymentFatalException"></exception>
        public override void WriteToUzagFile(StreamWriter sw)
        {
            base.WriteToUzagFile(sw);

            try
            {
                //Reserve
                sw.Write(Utilities.FillBlanks("", 49, " ", true));

                //Nummer Gelbes Konto des Empfängers
                sw.Write(EigenhaendigToDTA);

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

                sw.Flush();
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