using System;
using System.Diagnostics;
using System.IO;
using System.Text;

using KiSS4.DB;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Summary description for Dta.
    /// </summary>
    public class DtaRecord827 : DtaRecord
    {
        #region Fields

        #region Private Fields

        /// <summary>
        /// Adresse des Auftraggebers(keine Kontonummer).
        /// Beispiel : MUSTER AG 8049 ZÜRICH
        /// Length : 4•20x
        /// Obligatorisch : ja
        /// </summary>
        private String _auftraggeber1 = "";
        private String _auftraggeber2 = "";
        private String _auftraggeber3 = "";
        private String _auftraggeber4 = "";
        private String _beguenstigterAdresse1 = "";
        private String _beguenstigterAdresse2 = "";
        private String _beguenstigterAdresse3 = "";
        private String _beguenstigterAdresse4 = "";

        /// <summary>
        /// Die ESR-Teilnehmernummer des Begünstigten kann dem Feld "Konto" des Verarbeitungsbeleges
        /// entnommen werden (siehe Anhang C 13). Die Angaben sind in die 1. Zeile (24 Positionen)
        /// nach "/C/" in die Positionen 4–12 rechtsbündig mit führenden Nullen einzusetzen. Die restlichen
        /// 12 Positionen sind mit "blanks" aufzufüllen. Es wird empfohlen, die Prüfziffer nachzurechnen und
        /// zu vergleichen (siehe Anhang C 13). 
        /// Bei 9-stelligen Teilnehmernummern sind die Bindestriche wegzulassen.
        /// Der Name und die Adresse sind fakultativ, sie werden nicht an die Postfinance weitergeleitet.
        /// Beispiel : 5-stellige Teilnehmernummer : /C/000010304
        ///            9-stellige Teilnehmernummer : /C/012127029
        /// Length :   24 x + 4·20 x
        /// Obligatorisch : ja
        /// </summary>
        private String _beguenstigterKonto;

        /// <summary>
        /// Dieses Feld nimmt die übrigenAngaben der ESR-Codierzeile auf (siehe Muster Anhang C 13).
        /// 1. Zeile
        /// • ESR-Referenznummer 
        ///   bei 5-stelliger Teilnehmernummer
        ///   15-stellige Referenznummer (Pos. 34–48 ESR-Beleg)
        ///   bei 9-stelliger Teilnehmernummer
        ///   27-stellige Referenznummer (Pos. 18–44 ESR-Beleg)	
        ///   oder 16-stellige Referenznummer (Pos. 29–44 ESR-Beleg)
        /// • restliche Stellen "blanks"
        /// Es wird empfohlen, die Prüfziffer(P) bei 9-stelliger Teilnehmernummer nachzurechnen und zu
        /// vergleichen.
        /// 2. Zeile
        /// • ESR-Prüfziffer 
        ///   2-stellig(Pos. 17–18 ESR-Beleg)
        /// Ist nur anzugeben für ESR mit 5-stelliger Teilnehmernummer. 16 ESR-Beleg = "/&lt;"),
        /// sonst "blank". Es wird empfohlen, die über die ganze Codierzeile errechnete Prüfziffer nachzurechnen
        /// und zu vergleichen.
        /// • restliche Stellen "blanks"
        /// Beispiel : 70:999999999999999(= 1 Zeile), 70:99999999999999999999999999P (= 1 Zeile)
        ///            70:00000000000999999999999999P(= 1 Zeile)
        /// Length : 4·35 x
        /// Obligatorisch : nein
        /// </summary>
        private String _zahlungsgrund1 = "";
        private String _zahlungsgrund2 = "";
        private String _zahlungsgrund3 = "";
        private String _zahlungsgrund4 = "";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// GT827 CHF-Zahlungen im Inland (Bank-/Postkontozahlungen und
        /// Postmandate/Zahlungsanweisungen)
        /// </summary>
        public DtaRecord827(
            String bankClearingNummerBeguenstigten,
            String zubelastendendesKonto,
            Decimal verguetungsbetragParam,
            String auftraggeber1Param,
            String auftraggeber2Param,
            String auftraggeber3Param,
            String auftraggeber4Param,
            String beguenstigterKontoParam,
            String beguenstigterAdresse1Param,
            String beguenstigterAdresse2Param,
            String beguenstigterAdresse3Param,
            String beguenstigterAdresse4Param,
            String zahlungsgrundZeile1Param,
            String zahlungsgrundZeile2Param,
            String zahlungsgrundZeile3Param,
            String zahlungsgrundZeile4Param,
            DateTime valutaDatum)
            : base(bankClearingNummerBeguenstigten,
                zubelastendendesKonto,
                verguetungsbetragParam,
                valutaDatum)
        {
            Verguetungsbetrag = verguetungsbetragParam;

            Auftraggeber1 = auftraggeber1Param;
            Auftraggeber2 = auftraggeber2Param;
            Auftraggeber3 = auftraggeber3Param;
            Auftraggeber4 = auftraggeber4Param;

            // --- Beguenstigter
            BeguenstigterKonto = beguenstigterKontoParam;

            BeguenstigterAdresse1 = beguenstigterAdresse1Param;
            BeguenstigterAdresse2 = beguenstigterAdresse2Param;
            BeguenstigterAdresse3 = beguenstigterAdresse3Param;
            BeguenstigterAdresse4 = beguenstigterAdresse4Param;

            // --- Zahlungsgrund
            _zahlungsgrund1 = zahlungsgrundZeile1Param;
            _zahlungsgrund2 = zahlungsgrundZeile2Param;
            _zahlungsgrund3 = zahlungsgrundZeile3Param;
            _zahlungsgrund4 = zahlungsgrundZeile4Param;
        }

        #endregion

        #region Properties

        public string Auftraggeber1
        {
            set
            {
                if (value.Length > 24)
                {
                    _auftraggeber1 = value.Substring(0, 24);
                    Auftraggeber2 = value.Substring(24, value.Length - 24);
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
                if (value.Length > 24)
                {
                    _auftraggeber2 = value.Substring(0, 24);
                    Auftraggeber3 = value.Substring(24, value.Length - 24);
                }
                else
                {
                    _auftraggeber2 = value;
                }
            }
        }

        public string Auftraggeber3
        {
            set
            {
                if (value.Length > 24)
                {
                    _auftraggeber3 = value.Substring(0, 24);
                    Auftraggeber4 = value.Substring(24, value.Length - 24);
                }
                else
                {
                    _auftraggeber3 = value;
                }
            }
        }

        public string Auftraggeber4
        {
            set
            {
                if (value.Length > 24)
                {
                    _auftraggeber4 = value.Substring(0, 24);
                    ErrorMessage +=
                        KissMsg.GetMLMessage("DtaRecord827", "AuftraggeberMax96", "Der Auftraggeber wurde gekurzt, er darf max. 96 Zeichen lang sein") +
                        Environment.NewLine;
                }
                else
                {
                    _auftraggeber4 = value;
                }
            }
        }

        public string AuftraggeberToDTA
        {
            get
            {
                return
                    Utilities.FillBlanks(Utilities.StringToDTAString(_auftraggeber1), 24, " ", true) +
                    Utilities.FillBlanks(Utilities.StringToDTAString(_auftraggeber2), 24, " ", true) +
                    Utilities.FillBlanks(Utilities.StringToDTAString(_auftraggeber3), 24, " ", true) +
                    Utilities.FillBlanks(Utilities.StringToDTAString(_auftraggeber4), 24, " ", true);
            }
        }

        public string BeguenstigterAdresse1
        {
            set
            {
                if (value.Length > 24)
                {
                    _beguenstigterAdresse1 = value.Substring(0, 24);
                    BeguenstigterAdresse2 = value.Substring(24, value.Length - 24);
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
                if (value.Length > 24)
                {
                    _beguenstigterAdresse2 = value.Substring(0, 24);
                    BeguenstigterAdresse3 = value.Substring(24, value.Length - 24);
                }
                else
                {
                    _beguenstigterAdresse2 = value;
                }
            }
        }

        public string BeguenstigterAdresse3
        {
            set
            {
                if (value.Length > 24)
                {
                    _beguenstigterAdresse3 = value.Substring(0, 24);
                    BeguenstigterAdresse4 = value.Substring(24, value.Length - 24);
                }
                else
                {
                    _beguenstigterAdresse3 = value;
                }
            }
        }

        public string BeguenstigterAdresse4
        {
            set
            {
                if (value.Length > 24)
                {
                    _beguenstigterAdresse4 = value.Substring(0, 24);
                    ErrorMessage +=
                        KissMsg.GetMLMessage(
                            "DtaRecord827", "AuftraggeberMax96", "Die Adresse des Begünstigten wurde gekürzt, sie darf max. 96 Zeichen lang sein") +
                        Environment.NewLine;
                }
                else
                {
                    _beguenstigterAdresse4 = value;
                }
            }
        }

        public string BeguenstigterKonto
        {
            set
            {
                if (value.Length > 27)
                {
                    throw new Exception("Das Konto des Begünstigten ist länger als 27 Zeichen !");
                }
                _beguenstigterKonto = value;
            }
        }

        public string BeguenstigterToDTA
        {
            get
            {
                return "/C/" + Utilities.FillBlanks(_beguenstigterKonto, 27, " ", true)
                       + Utilities.FillBlanks(Utilities.StringToDTAString(_beguenstigterAdresse1), 24, " ", true)
                       + Utilities.FillBlanks(Utilities.StringToDTAString(_beguenstigterAdresse2), 24, " ", true)
                       + Utilities.FillBlanks(Utilities.StringToDTAString(_beguenstigterAdresse3), 24, " ", true)
                       + Utilities.FillBlanks(Utilities.StringToDTAString(_beguenstigterAdresse4), 24, " ", true);
            }
        }

        public string Zahlungsgrund1
        {
            get { return _zahlungsgrund1; }
            set { _zahlungsgrund1 = value; }
        }

        public string Zahlungsgrund2
        {
            get { return _zahlungsgrund2; }
            set { _zahlungsgrund2 = value; }
        }

        public string Zahlungsgrund3
        {
            get { return _zahlungsgrund3; }
            set { _zahlungsgrund3 = value; }
        }

        public string Zahlungsgrund4
        {
            get { return _zahlungsgrund4; }
            set { _zahlungsgrund4 = value; }
        }

        // optional
        public string ZahlungsgrundToDTA
        {
            get
            {
                return
                    Utilities.FillBlanks(Utilities.StringToDTAString(_zahlungsgrund1), 28, " ", true) +
                    Utilities.FillBlanks(Utilities.StringToDTAString(_zahlungsgrund2), 28, " ", true) +
                    Utilities.FillBlanks(Utilities.StringToDTAString(_zahlungsgrund3), 28, " ", true) +
                    Utilities.FillBlanks(Utilities.StringToDTAString(_zahlungsgrund4), 28, " ", true);
            }
        }

        public string ZubelastendesKontoToDTA
        {
            get { return Utilities.FillBlanks(ZubelastendesKonto, 24, " ", true); }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Writes to DTA file.
        /// </summary>
        /// <param name="fileInfo">The file info.</param>
        public override void WriteToDTAFile(FileInfo fileInfo)
        {
            var sw = new StreamWriter(fileInfo.FullName, true, Encoding.Default);

            try
            {
                //1 Header
                sw.Write("01");
                //2 Verarbeitungstag
                sw.Write(Utilities.DateTimeToDTAString(ValutaDatum));
                //3 BankClearingNummer
                sw.Write(RecordHeader.BankClearingNummerBeguenstigtenToDTA);
                //4 AusgabeSequenzNummer
                sw.Write(RecordHeader.AusgabeSequenzNummer);
                //5 ErstellungsDatum
                sw.Write(ErstellungsDatumToDTA);
                //6 BankClearingNummerAuftragsgebber
                sw.Write(BankClearingNummerAuftragsgebberToDTA);
                //7 DatenfileAbsenderIdentifikation
                sw.Write(DatenfileAbsenderIdentifikationToDTA);
                //8 EingabeSequenzNummer
                sw.Write(EingabeSequenzNummerToDTA);
                //9 TransaktionsArt
                sw.Write("827");
                //10 ZahlungsArt
                sw.Write(ZahlungsArtToDTA);
                //11 BearbeitungsFlag
                sw.Write(BearbeitungsFlagToDTA);
                //12 Referenznummer
                sw.Write(ReferenznummerToDTA);
                //13 ZubelastendesKonto
                sw.Write(ZubelastendesKontoToDTA);
                //14 Verguetungsbetrag
                sw.Write(VerguetungsbetragToDTA);

                // Reserve blanks
                sw.Write(Utilities.FillBlanks("", 14, " ", true));

                // Enregistrement 2
                sw.Write("02");

                //15 Auftraggeber
                sw.Write(AuftraggeberToDTA);

                // Reserve blanks
                sw.Write(Utilities.FillBlanks("", 30, " ", true));
                //sw.Write("                              ") ;

                // Enregistrement 3
                sw.Write("03");

                //16 Beguenstigter
                sw.Write(BeguenstigterToDTA);

                // Enregistrement 4 optional
                if (_zahlungsgrund1 != "" || _zahlungsgrund2 != "" || _zahlungsgrund3 != "" || _zahlungsgrund4 != "")
                {
                    sw.Write("04");

                    //17 Zahlungsgrund optional
                    sw.Write(ZahlungsgrundToDTA);
                    sw.Write(Utilities.FillBlanks("", 14, " ", true));
                }

                //
                sw.Flush();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            finally
            {
                sw.Close();
            }
        }

        #endregion

        #endregion
    }
}