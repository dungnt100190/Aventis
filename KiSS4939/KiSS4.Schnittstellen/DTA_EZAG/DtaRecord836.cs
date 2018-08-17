using System;
using System.Diagnostics;
using System.IO;
using System.Text;

using KiSS4.DB;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Setzt das Schweizer DTA Format "TA 836 Zahlungen mit IBAN im In- und Ausland, in allen Währungen" um.
    /// 
    /// Wichtige Hinweise: 
    /// 57D - Es wird davon ausgegangen, dass eine CH- oder LI-IBAN übergeben wird.
    /// 70U - Der Verwendungszweck wird als Unstrukturierter, freier Text übergeben.
    /// 71A - Spesenregelung ist auf "0=OUR=Alle Spesen zu Lasten Auftraggeber" gesetzt. 
    /// </summary>
    public class DtaRecord836 : DtaRecord
    {
        #region Fields

        #region Private Fields

        private string _auftraggeber1;
        private string _auftraggeber2;
        private string _auftraggeber3;
        private string _beguenstigterAdresse1;
        private string _beguenstigterAdresse2;
        private string _beguenstigterAdresse3;
        private string _iban;
        private string _verwendungszweck;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a DTA Record
        /// </summary>
        /// <param name="bankClearingNummerBeguenstigten">Bank BCN</param>
        /// <param name="zubelastendendesKonto">Zahlungskonto des Sozialdienstes</param>
        /// <param name="verguetungsbetragParam">Betrag der Zahlung</param>
        /// <param name="auftraggeber1Param">Sozialdienst Name</param>
        /// <param name="auftraggeber2Param">Sozialdienst Adresse</param>
        /// <param name="auftraggeber3Param">Sozialdienst PLZ Ort</param>
        /// <param name="beguenstigterIbanParam">IBAN des Begünstigten</param>
        /// <param name="beguenstigterAdresse1Param">Name des Begünstigten</param>
        /// <param name="beguenstigterAdresse2Param">Strasse des Begünstigten</param>
        /// <param name="beguenstigterAdresse3Param">PLZ Ort des Begünstigten</param>
        /// <param name="verwendungszweckReferenznummerParam">Verwendungszweck: Variante Referenznummer</param>
        /// <param name="valutaDatum">Valuta Datum</param>
        public DtaRecord836(string bankClearingNummerBeguenstigten,
            string zubelastendendesKonto,
            Decimal verguetungsbetragParam,
            string auftraggeber1Param,
            string auftraggeber2Param,
            string auftraggeber3Param,
            string beguenstigterIbanParam,
            string beguenstigterAdresse1Param,
            string beguenstigterAdresse2Param,
            string beguenstigterAdresse3Param,
            string verwendungszweckReferenznummerParam,
            DateTime valutaDatum)
            : base(bankClearingNummerBeguenstigten,
                zubelastendendesKonto,
                verguetungsbetragParam,
                valutaDatum)
        {
            Auftraggeber1 = auftraggeber1Param;
            Auftraggeber2 = auftraggeber2Param;
            Auftraggeber3 = auftraggeber3Param;

            Iban = beguenstigterIbanParam;

            BeguenstigterAdresse1 = beguenstigterAdresse1Param;
            BeguenstigterAdresse2 = beguenstigterAdresse2Param;
            BeguenstigterAdresse3 = beguenstigterAdresse3Param;

            SetVerwendungszweck(verwendungszweckReferenznummerParam);
        }

        /// <summary>
        /// Creates a DTA Record
        /// </summary>
        /// <param name="bankClearingNummerBeguenstigten">Bank BCN</param>
        /// <param name="zubelastendendesKonto">Zahlungskonto des Sozialdienstes</param>
        /// <param name="verguetungsbetragParam">Betrag der Zahlung</param>
        /// <param name="auftraggeber1Param">Sozialdienst Name</param>
        /// <param name="auftraggeber2Param">Sozialdienst Adresse</param>
        /// <param name="auftraggeber3Param">Sozialdienst PLZ Ort</param>
        /// <param name="beguenstigterIbanParam">IBAN des Begünstigten</param>
        /// <param name="beguenstigterAdresse1Param">Name des Begünstigten</param>
        /// <param name="beguenstigterAdresse2Param">Strasse des Begünstigten</param>
        /// <param name="beguenstigterAdresse3Param">PLZ Ort des Begünstigten</param>
        /// <param name="verwendungszweckZeile1Param">Verwendungszweck: Variante freier Text. Zeile1</param>
        /// <param name="verwendungszweckZeile2Param">Verwendungszweck: Variante freier Text. Zeile2</param>
        /// <param name="verwendungszweckZeile3Param">Verwendungszweck: Variante freier Text. Zeile3</param>
        /// <param name="valutaDatum">Valuta Datum</param>
        public DtaRecord836(string bankClearingNummerBeguenstigten,
            string zubelastendendesKonto,
            Decimal verguetungsbetragParam,
            string auftraggeber1Param,
            string auftraggeber2Param,
            string auftraggeber3Param,
            string beguenstigterIbanParam,
            string beguenstigterAdresse1Param,
            string beguenstigterAdresse2Param,
            string beguenstigterAdresse3Param,
            string verwendungszweckZeile1Param,
            string verwendungszweckZeile2Param,
            string verwendungszweckZeile3Param,
            DateTime valutaDatum)
            : base(bankClearingNummerBeguenstigten,
                zubelastendendesKonto,
                verguetungsbetragParam,
                valutaDatum)
        {
            Auftraggeber1 = auftraggeber1Param;
            Auftraggeber2 = auftraggeber2Param;
            Auftraggeber3 = auftraggeber3Param;

            Iban = beguenstigterIbanParam;

            BeguenstigterAdresse1 = beguenstigterAdresse1Param;
            BeguenstigterAdresse2 = beguenstigterAdresse2Param;
            BeguenstigterAdresse3 = beguenstigterAdresse3Param;

            SetVerwendungszweck(verwendungszweckZeile1Param, verwendungszweckZeile2Param, verwendungszweckZeile3Param);
        }

        #endregion

        #region Properties

        public string Auftraggeber1
        {
            set
            {
                if (value.Length > 35)
                {
                    _auftraggeber1 = value.Substring(0, 35);
                    Auftraggeber2 = " " + value.Substring(35, value.Length - 35);
                }
                else
                {
                    _auftraggeber1 = value;
                }
            }
        }

        public string Auftraggeber2
        {
            set
            {
                string newValue = _auftraggeber2 + value;
                if (newValue.Length > 35)
                {
                    _auftraggeber2 = newValue.Substring(0, 35);
                    Auftraggeber3 = " " + newValue.Substring(35, newValue.Length - 35);
                }
                else
                {
                    _auftraggeber2 = newValue;
                }
            }
        }

        public string Auftraggeber3
        {
            set
            {
                string newValue = _auftraggeber3 + value;
                if (newValue.Length > 35)
                {
                    _auftraggeber3 = newValue.Substring(0, 35);
                    ErrorMessage +=
                        KissMsg.GetMLMessage(
                            "DtaRecord836", "AuftraggeberMax105", "Der Auftraggeber wurde gekürzt, er darf max. 105 Zeichen lang sein") +
                        Environment.NewLine;
                }
                else
                {
                    _auftraggeber3 = newValue;
                }
            }
        }

        //50 Auftraggeber
        public string AuftraggeberToDTA
        {
            get
            {
                return
                    Utilities.FillBlanks(Utilities.StringToDTAString(_auftraggeber1), 35, " ", true) +
                    Utilities.FillBlanks(Utilities.StringToDTAString(_auftraggeber2), 35, " ", true) +
                    Utilities.FillBlanks(Utilities.StringToDTAString(_auftraggeber3), 35, " ", true);
            }
        }

        public string BeguenstigterAdresse1
        {
            set
            {
                if (value.Length > 35)
                {
                    _beguenstigterAdresse1 = value.Substring(0, 35);
                    BeguenstigterAdresse2 = " " + value.Substring(35, value.Length - 35);
                }
                else
                {
                    _beguenstigterAdresse1 = value;
                }
            }
        }

        public string BeguenstigterAdresse2
        {
            set
            {
                string newValue = _beguenstigterAdresse2 + value;
                if (newValue.Length > 35)
                {
                    _beguenstigterAdresse2 = newValue.Substring(0, 35);
                    BeguenstigterAdresse3 = " " + newValue.Substring(35, newValue.Length - 35);
                }
                else
                {
                    _beguenstigterAdresse2 = newValue;
                }
            }
        }

        public string BeguenstigterAdresse3
        {
            set
            {
                string newValue = _beguenstigterAdresse3 + " " + value;
                if (newValue.Length > 35)
                {
                    _beguenstigterAdresse3 = newValue.Substring(0, 35);
                    ErrorMessage +=
                        KissMsg.GetMLMessage(
                            "DtaRecord836", "BeguenstigterMax105", "Die Adresse des Begünstigten wurde gekürzt, sie darf max. 105 Zeichen enthalten.") +
                        Environment.NewLine;
                }
                else
                {
                    _beguenstigterAdresse3 = newValue;
                }
            }
        }

        //57D Beguenstigtes Institut
        public string BeguenstigtesInstitutToDTA
        {
            get { return Utilities.FillBlanks(string.Empty, 2*35, " ", true); }
        }

        //58 IBAN
        public string IBANToDTA
        {
            get { return Utilities.FillBlanks(_iban, 34, " ", true); }
        }

        public string Iban
        {
            set
            {
                if (value.Length > 34)
                {
                    throw new Exception("Die IBAN des Begünstigten ist länger als 34 Zeichen !");
                }

                _iban = value;
            }
        }

        //25 ZubelastendesKonto
        public string ZubelastendesKontoToDTA
        {
            get { return Utilities.FillBlanks(ZubelastendesKonto, 24, " ", true); }
        }

        //59 Beguenstigter
        protected string BeguenstigterToDTA
        {
            get
            {
                return
                    Utilities.FillBlanks(Utilities.StringToDTAString(_beguenstigterAdresse1), 35, " ", true) +
                    Utilities.FillBlanks(Utilities.StringToDTAString(_beguenstigterAdresse2), 35, " ", true) +
                    Utilities.FillBlanks(Utilities.StringToDTAString(_beguenstigterAdresse3), 35, " ", true);
            }
        }

        //70 Verwendungszweck
        protected string VerwendungszweckToDTA
        {
            get { return Utilities.FillBlanks(_verwendungszweck, 3*35, " ", true); }
        }

        #endregion

        #region Methods

        #region Public Methods

        public string CreateDTAString()
        {
            var dtaString = new StringBuilder();

            // Segment 01
            dtaString.Append("01");
            // --- HEADER --------------------------------------
            // Verarbeitungstag (nur bei TA826 und TA827)
            dtaString.Append(Utilities.FillBlanks(string.Empty, 6, "0", true));
            // BankClearingNummer : Blanks for TA836
            dtaString.Append(Utilities.FillBlanks(string.Empty, 12, " ", true));
            // AusgabeSequenzNummer
            dtaString.Append(RecordHeader.AusgabeSequenzNummer);
            // ErstellungsDatum
            dtaString.Append(ErstellungsDatumToDTA);
            // BankClearingNummerAuftragsgebber
            dtaString.Append(BankClearingNummerAuftragsgebberToDTA);
            // DatenfileAbsenderIdentifikation
            dtaString.Append(DatenfileAbsenderIdentifikationToDTA);
            // EingabeSequenzNummer
            dtaString.Append(EingabeSequenzNummerToDTA);
            // TransaktionsArt
            dtaString.Append("836");
            // ZahlungsArt
            dtaString.Append(ZahlungsArtToDTA);
            // BearbeitungsFlag
            dtaString.Append(BearbeitungsFlagToDTA);
            // --- END HEADER -----------------------------------

            //20 Referenznummer
            dtaString.Append(ReferenznummerToDTA);
            //25 ZubelastendesKonto
            dtaString.Append(ZubelastendesKontoToDTA);
            //32A Verguetungsbetrag
            dtaString.Append(VerguetungsbetragToDTA);
            // Reserve blanks
            dtaString.Append(Utilities.FillBlanks(string.Empty, 11, " ", true));

            // Segment 02
            dtaString.Append("02");
            //36 Umrechungskurs (fakultativ)
            dtaString.Append(Utilities.FillBlanks(string.Empty, 12, " ", true));
            //50 Auftraggeber
            dtaString.Append(AuftraggeberToDTA);
            // Reserve blanks
            dtaString.Append(Utilities.FillBlanks(string.Empty, 9, " ", true));

            // Segment 03
            dtaString.Append("03");
            // Identifikation Bankadresse
            dtaString.Append("D");
            //57D Beguenstigtes Institut
            dtaString.Append(BeguenstigtesInstitutToDTA);
            //58 IBAN
            dtaString.Append(IBANToDTA);
            // Reserve blanks
            dtaString.Append(Utilities.FillBlanks(string.Empty, 21, " ", true));

            // Segment 04
            dtaString.Append("04");
            //59 Beguenstigter
            dtaString.Append(BeguenstigterToDTA);
            // Reserve blanks
            dtaString.Append(Utilities.FillBlanks(string.Empty, 21, " ", true));

            // Segment 05
            dtaString.Append("05");
            // Identifikation Verwendungszweck
            dtaString.Append("U");
            //70 Verwendungszweck
            dtaString.Append(VerwendungszweckToDTA);
            //71A Spesenregelung
            dtaString.Append("0"); // INFO Bankspesenregelung TA836
            // Reserve blanks
            dtaString.Append(Utilities.FillBlanks(string.Empty, 19, " ", true));

            return dtaString.ToString();
        }

        public override void WriteToDTAFile(FileInfo fileInfo)
        {
            var file = new StreamWriter(fileInfo.FullName, true, Encoding.Default);

            try
            {
                string dtaString = CreateDTAString();
                file.Write(dtaString);
                file.Flush();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            finally
            {
                file.Close();
            }
        }

        #endregion

        #region Protected Methods

        protected void SetVerwendungszweck(string referenzNummer)
        {
            _verwendungszweck = referenzNummer;
        }

        protected void SetVerwendungszweck(string zeile1, string zeile2, string zeile3)
        {
            _verwendungszweck =
                Utilities.FillBlanks(Utilities.StringToDTAString(zeile1), 35, " ", true) +
                Utilities.FillBlanks(Utilities.StringToDTAString(zeile2), 35, " ", true) +
                Utilities.FillBlanks(Utilities.StringToDTAString(zeile3), 35, " ", true);
            ;
        }

        #endregion

        #endregion
    }
}