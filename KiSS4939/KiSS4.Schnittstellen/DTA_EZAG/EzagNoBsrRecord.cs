using System;

using KiSS4.DB;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Diese Klasse implementiert einen EZAG Record ohne BSR. Sie dient als
    /// Basisklasse.
    /// </summary>
    public class EzagNoBsrRecord : EzagRecord
    {
        #region Fields

        #region Private Fields

        private string _auftraggeberNameVorname = "";
        private string _auftraggeberOrt = "";
        private string _auftraggeberPostleitzahl = "";
        private string _auftraggeberStrasse = "";
        private string _auftraggeberZusaetlicheBezeichnung = "";
        private string _empfaengersNameVorname;
        private string _empfaengersOrt = "";
        private string _empfaengersPostleitzahl = "";
        private string _empfaengersStrasse = "";
        private string _empfaengersZusaetlicheBezeichnung = "";
        private string _endBeguenstigtenBankkontoNummer;
        private string _endBeguenstigtenNameVorname;
        private string _endBeguenstigtenOrt = "";
        private string _endBeguenstigtenPostleitzahl = "";
        private string _endBeguenstigtenStrasse = "";
        private string _endBeguenstigtenZusaetlicheBezeichnung = "";
        private string _mitteilungen1 = "";
        private string _mitteilungen2 = "";
        private string _mitteilungen3 = "";
        private string _mitteilungen4 = "";

        #endregion

        #endregion

        #region Constructors

        public EzagNoBsrRecord(
            EzagHeader.TransaktionsArt transaktionsArt,
            decimal aufgabebetragParam,
            string empfaengersNameVornameParam,
            string empfaengersZusaetlicheBezeichnungParam,
            string empfaengersStrasseParam,
            string empfaengersPostleitzahlParam,
            string empfaengersOrtParam,
            string endBeguenstigterkontoNummerParam,
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
            : base(aufgabebetragParam, transaktionsArt)
        {
            EmpfaengersNameVorname = empfaengersNameVornameParam;
            EmpfaengersZusaetlicheBezeichnung = empfaengersZusaetlicheBezeichnungParam;
            EmpfaengersStrasse = empfaengersStrasseParam;
            EmpfaengersPostleitzahl = empfaengersPostleitzahlParam;
            EmpfaengersOrt = empfaengersOrtParam;
            EndBeguenstigtenBankkontoNummer = endBeguenstigterkontoNummerParam;
            EndBeguenstigtenNameVorname = endBeguenstigtenNameVornameParam;
            EndBeguenstigtenZusaetlicheBezeichnung = endBeguenstigtenZusaetlicheBezeichnungParam;
            EndBeguenstigtenStrasse = endBeguenstigtenStrasseParam;
            EndBeguenstigtenPostleitzahl = endBeguenstigtenPostleitzahlParam;
            EndBeguenstigtenOrt = endBeguenstigtenOrtParam;
            Mitteilungen1 = mitteilungen1Param;
            Mitteilungen2 = mitteilungen2Param;
            Mitteilungen3 = mitteilungen3Param;
            Mitteilungen4 = mitteilungen4Param;
            AuftraggeberNameVorname = auftraggeberNameVornameParam;
            AuftraggeberZusaetlicheBezeichnung = auftraggeberZusaetlicheBezeichnungParam;
            AuftraggeberStrasse = auftraggeberStrasseParam;
            AuftraggeberPostleitzahl = auftraggeberPostleitzahlParam;
            AuftraggeberOrt = auftraggeberOrtParam;
        }

        #endregion

        #region Properties

        public string AuftraggeberNameVorname
        {
            get { return _auftraggeberNameVorname; }
            set
            {
                if (value.Length > 35)
                {
                    _auftraggeberNameVorname = value.Substring(0, 35);
                    ErrorMessage +=
                        KissMsg.GetMLMessage(
                            "EzagNoBsr",
                            "AuftraggeberNameVornameMax35",
                            "Auftraggeber Name + Vorname wurden gekürzt, sie dürfen darf max. 35 Zeichen lang sein") + Environment.NewLine;
                }
                else
                {
                    _auftraggeberNameVorname = value;
                }
            }
        }

        public string AuftraggeberNameVornameToDTA
        {
            get { return Utilities.FillBlanks(AuftraggeberNameVorname, 35, " ", true); }
        }

        public string AuftraggeberOrt
        {
            get { return _auftraggeberOrt; }
            set
            {
                if (value.Length > 25)
                {
                    _auftraggeberOrt = value.Substring(0, 25);
                    ErrorMessage +=
                        KissMsg.GetMLMessage("EzagNoBsr", "AuftraggeberOrtMax35", "Auftraggeber Ort wurde gekürzt, er darf max. 25 Zeichen lang sein") +
                        Environment.NewLine;
                }
                else
                {
                    _auftraggeberOrt = value;
                }
            }
        }

        public string AuftraggeberOrtToDTA
        {
            get { return Utilities.FillBlanks(AuftraggeberOrt, 25, " ", true); }
        }

        /// <summary>
        /// Setz oder liest die PLZ des Auftraggebers.
        /// </summary>
        /// <value>Die PLZ des Auftraggebers.</value>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string AuftraggeberPostleitzahl
        {
            get { return _auftraggeberPostleitzahl; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    value = String.Empty;
                }
                else
                {
                    value = value.Trim();
                }

                int result = Utilities.CheckPostLeitzahl(value);

                switch (result)
                {
                    case 1:
                        _auftraggeberPostleitzahl = value;
                        break;
                    case 2:
                        throw new ArgumentOutOfRangeException(
                            "value",
                            "Postleitzahl ist zu lang");
                    case 3:
                        throw new ArgumentOutOfRangeException(
                            "value",
                            "Auftraggeber Postleitzahl muss numerisch sein");
                }
            }
        }

        /// <summary>
        /// Gets the auftraggeber postleitzahl to DTA.
        /// </summary>
        /// <value>The auftraggeber postleitzahl to DTA.</value>
        public string AuftraggeberPostleitzahlToDTA
        {
            get { return Utilities.FillBlanks(AuftraggeberPostleitzahl, 10, " ", true); }
        }

        public string AuftraggeberStrasse
        {
            get { return _auftraggeberStrasse; }
            set
            {
                if (value.Length > 35)
                {
                    _auftraggeberStrasse = value.Substring(0, 35);
                    ErrorMessage +=
                        KissMsg.GetMLMessage(
                            "EzagNoBsr", "AuftraggeberStrasseMax35", "Auftraggeber Strasse  wurde gekürzt, sie darf max. 35 Zeichen lang sein") +
                        Environment.NewLine;
                }
                else
                {
                    _auftraggeberStrasse = value;
                }
            }
        }

        public string AuftraggeberStrasseToDTA
        {
            get { return Utilities.FillBlanks(AuftraggeberStrasse, 35, " ", true); }
        }

        public string AuftraggeberZusaetlicheBezeichnung
        {
            get { return _auftraggeberZusaetlicheBezeichnung; }
            set
            {
                if (value.Length > 35)
                {
                    _auftraggeberZusaetlicheBezeichnung = value.Substring(0, 35);
                    ErrorMessage +=
                        KissMsg.GetMLMessage(
                            "EzagNoBsr",
                            "AuftraggeberZusBezeichnMax35",
                            "Auftraggeber Zusätzliche Bezeichnung wurde gekürzt, sie darf max. 35 Zeichen lang sein") + Environment.NewLine;
                }
                else
                {
                    _auftraggeberZusaetlicheBezeichnung = value;
                }
            }
        }

        public string AuftraggeberZusaetlicheBezeichnungToDTA
        {
            get { return Utilities.FillBlanks(AuftraggeberZusaetlicheBezeichnung, 35, " ", true); }
        }

        public string EmpfaengersNameVorname
        {
            get { return _empfaengersNameVorname; }
            set
            {
                value = Utilities.RemoveNewLines(value);
                if (value.Length > 35)
                {
                    _empfaengersNameVorname = value.Substring(0, 35);
                    ErrorMessage +=
                        KissMsg.GetMLMessage(
                            "EzagNoBsr", "EmpfaengerNameVornameMax35", "EmpfängersNameVorname wurde gekürzt, er darf max. 35 Zeichen lang sein") +
                        Environment.NewLine;
                }
                else
                {
                    _empfaengersNameVorname = value;
                }
            }
        }

        public string EmpfaengersNameVornameToDTA
        {
            get { return Utilities.FillBlanks(Utilities.RemoveNewLines(EmpfaengersNameVorname), 35, " ", true); }
        }

        public string EmpfaengersOrt
        {
            get { return _empfaengersOrt; }
            set
            {
                if (value.Length > 25)
                {
                    _empfaengersOrt = value.Substring(0, 25);
                    ErrorMessage +=
                        KissMsg.GetMLMessage("EzagNoBsr", "EmpfaengerOrtMax25", "Empfängers Ort wurde gekürzt, er darf max. 25 Zeichen lang sein") +
                        Environment.NewLine;
                }
                else
                {
                    _empfaengersOrt = value;
                }
            }
        }

        public string EmpfaengersOrtToDTA
        {
            get { return Utilities.FillBlanks(EmpfaengersOrt, 25, " ", true); }
        }

        public String EmpfaengersPostleitzahl
        {
            get { return _empfaengersPostleitzahl; }
            set
            {
                value = value.Trim();
                int result = Utilities.CheckPostLeitzahl(value);

                switch (result)
                {
                    case 1:
                    case 4:
                        _empfaengersPostleitzahl = value;
                        break;
                    case 2:
                        throw new PaymentFatalException(
                            "Postleitzahl ist zu lang");
                    case 3:
                        throw new PaymentFatalException(
                            "Postleitzahl muss numerisch sein");
                }
            }
        }

        public string EmpfaengersPostleitzahlToDTA
        {
            get { return Utilities.FillBlanks(EmpfaengersPostleitzahl, 10, " ", true); }
        }

        /// <summary>
        /// Gets or sets the 'empfaengersStrasse'.
        /// </summary>
        /// <value>The empfaengers strasse.</value>
        public string EmpfaengersStrasse
        {
            get { return _empfaengersStrasse; }
            set
            {
                if (value.Length > 35)
                {
                    _empfaengersStrasse = value.Substring(0, 35);
                    ErrorMessage +=
                        KissMsg.GetMLMessage(
                            "EzagNoBsr", "EmpfaengerStrasseMax35", "Empfängers Strasse wurde gekürzt, sie darf max. 35 Zeichen lang sein") +
                        Environment.NewLine;
                }
                else
                {
                    _empfaengersStrasse = value;
                }
            }
        }

        public string EmpfaengersStrasseToDTA
        {
            get { return Utilities.FillBlanks(EmpfaengersStrasse, 35, " ", true); }
        }

        public string EmpfaengersZusaetlicheBezeichnung
        {
            get { return _empfaengersZusaetlicheBezeichnung; }
            set
            {
                if (value.Length > 35)
                {
                    _empfaengersZusaetlicheBezeichnung = value.Substring(0, 35);
                    ErrorMessage +=
                        KissMsg.GetMLMessage(
                            "EzagNoBsr",
                            "EmpfaengerZusaetzlicheBezMax35",
                            "Empfängers zusätzliche Bezeichnung wurde gekürzt, sie darf max. 35 Zeichen lang sein") + Environment.NewLine;
                }
                else
                {
                    _empfaengersZusaetlicheBezeichnung = value;
                }
            }
        }

        public string EmpfaengersZusaetlicheBezeichnungToDTA
        {
            get { return Utilities.FillBlanks(EmpfaengersZusaetlicheBezeichnung, 35, " ", true); }
        }

        public string EndBeguenstigtenBankkontoNummer
        {
            get { return _endBeguenstigtenBankkontoNummer; }
            set
            {
                if (value.Length > 27)
                {
                    _endBeguenstigtenBankkontoNummer = value.Substring(0, 27);
                    ErrorMessage +=
                        KissMsg.GetMLMessage(
                            "EzagNoBsr",
                            "EndbeguenstBankKontoMax27",
                            "Endbegünstigten BankKontoNummer wurde gekürzt, sie darf max. 27 Zeichen lang sein") + Environment.NewLine;
                }
                else
                {
                    _endBeguenstigtenBankkontoNummer = value;
                }
            }
        }

        public string EndBeguenstigtenBankkontoNummerToDTA
        {
            get
            {
                return _endBeguenstigtenBankkontoNummer.PadRight(35);
                //return Utilities.FillBlanks(this.endBeguenstigtenBankkontoNummer, 35, " ", true);
            }
        }

        public string EndBeguenstigtenNameVorname
        {
            get { return _endBeguenstigtenNameVorname; }
            set
            {
                value = Utilities.RemoveNewLines(value);
                // By default truncate value
                if (value.Length > 35)
                {
                    _endBeguenstigtenNameVorname = value.Substring(0, 35);
                    EndBeguenstigtenZusaetlicheBezeichnung = value.Substring(34, value.Length - 35);
                }
                else
                {
                    _endBeguenstigtenNameVorname = value;
                }
            }
        }

        public string EndBeguenstigtenOrt
        {
            get { return _endBeguenstigtenOrt; }
            set
            {
                if (value.Length > 25)
                {
                    _endBeguenstigtenOrt = value.Substring(0, 25);
                    ErrorMessage +=
                        KissMsg.GetMLMessage(
                            "EzagNoBsr", "EndbeguenstOrtMax25", "Endbegünstigten Ort wurde gekürzt, er darf max. 25 Zeichen lang sein") +
                        Environment.NewLine;
                }
                else
                {
                    _endBeguenstigtenOrt = value;
                }
            }
        }

        public string EndBeguenstigtenPostleitzahl
        {
            get { return _endBeguenstigtenPostleitzahl; }
            set
            {
                if (value != "")
                {
                    value = value.Trim();
                    int result = Utilities.CheckPostLeitzahl(value);

                    switch (result)
                    {
                        case 1:
                            _endBeguenstigtenPostleitzahl = value;
                            break;
                        case 2:
                            throw new PaymentFatalException("Postleitzahl ist zu lang");
                        case 3:
                            throw new PaymentFatalException("Endbeguenstigsten Postleitzahl muss numerisch sein");
                        case 4:
                            throw new PaymentFatalException("PLZ muss eingegeben sein");
                    }
                }
                else
                {
                    _endBeguenstigtenPostleitzahl = "";
                }
            }
        }

        public string EndBeguenstigtenStrasse
        {
            get { return _endBeguenstigtenStrasse; }
            set
            {
                if (value.Length > 35)
                {
                    _endBeguenstigtenStrasse = value.Substring(0, 35);
                    ErrorMessage +=
                        KissMsg.GetMLMessage(
                            "EzagNoBsr", "EndbeguenstStrasseMax35", "Endbegünstigten Strasse wurde gekürzt, sie darf max. 35 Zeichen lang sein") +
                        Environment.NewLine;
                }
                else
                {
                    _endBeguenstigtenStrasse = value;
                }
            }
        }

        public string EndBeguenstigtenZusaetlicheBezeichnung
        {
            get { return _endBeguenstigtenZusaetlicheBezeichnung; }
            set
            {
                if (value.Length > 35)
                {
                    _endBeguenstigtenZusaetlicheBezeichnung = value.Substring(0, 35);
                    ErrorMessage +=
                        KissMsg.GetMLMessage(
                            "EzagNoBsr",
                            "EndbeguenstZusatzBezeichnMax35",
                            "Endbegünstigten Zusätzliche Bezeichnung wurde gekürzt, sie darf max. 35 Zeichen lang sein") + Environment.NewLine;
                }
                else
                {
                    _endBeguenstigtenZusaetlicheBezeichnung = value;
                }
            }
        }

        public string Mitteilungen1
        {
            get { return _mitteilungen1; }
            set
            {
                value = value.Replace(Environment.NewLine, " ");

                if (value.Length > 35)
                {
                    _mitteilungen1 = value.Substring(0, 35);
                    Mitteilungen2 = value.Substring(35, value.Length - 35);
                }
                else
                {
                    _mitteilungen1 = value;
                }
            }
        }

        public string Mitteilungen1ToDTA
        {
            get { return Utilities.FillBlanks(Mitteilungen1, 35, " ", true); }
        }

        public string Mitteilungen2
        {
            get { return _mitteilungen2; }
            set
            {
                if (value.Length > 35)
                {
                    _mitteilungen2 = value.Substring(0, 35);
                    Mitteilungen3 = value.Substring(35, value.Length - 35);
                }
                else
                {
                    _mitteilungen2 = value;
                }
            }
        }

        public string Mitteilungen2ToDTA
        {
            get { return Utilities.FillBlanks(Mitteilungen2, 35, " ", true); }
        }

        public string Mitteilungen3
        {
            get { return _mitteilungen3; }
            set
            {
                if (value.Length > 35)
                {
                    _mitteilungen3 = value.Substring(0, 35);
                    Mitteilungen4 = value.Substring(35, value.Length - 35);
                }
                else
                {
                    _mitteilungen3 = value;
                }
            }
        }

        public string Mitteilungen3ToDTA
        {
            get
            {
                return Mitteilungen3.PadLeft(35);
                //return Utilities.FillBlanks(this.Mitteilungen3, 35, " ", true);
            }
        }

        public string Mitteilungen4
        {
            get { return _mitteilungen4; }
            set
            {
                if (value.Length > 35)
                {
                    Mitteilungen4 = value.Substring(35, value.Length - 35);
                    ErrorMessage +=
                        KissMsg.GetMLMessage("EzagNoBsr", "MitteilungenMax140", "Mitteilungen wurden  gekürzt, sie düfen max. 140 Zeichen lang sein") +
                        Environment.NewLine;
                }
                else
                {
                    _mitteilungen4 = value;
                }
            }
        }

        public string Mitteilungen4ToDTA
        {
            get { return Utilities.FillBlanks(Mitteilungen4, 35, " ", true); }
        }

        #endregion
    }
}