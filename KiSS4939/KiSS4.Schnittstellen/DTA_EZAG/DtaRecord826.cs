using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using KiSS4.Common;
using KiSS4.DB;
using log4net;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Summary description for DtaRecord826.
    /// </summary>
    public class DtaRecord826 : DtaRecord
    {
        #region Fields

        #region Private Static Fields

        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        /// <summary>
        /// Adresse des Auftraggebers(keine Kontonummer). Beispiel : MUSTER AG 8049 ZÜRICH Length :
        /// 4•20x Obligatorisch : ja
        /// </summary>
        private String _auftraggeber1;

        private String _auftraggeber2;
        private String _auftraggeber3;
        private String _auftraggeber4;
        private String _beguenstigterAdresse1 = "";
        private String _beguenstigterAdresse2 = "";
        private String _beguenstigterAdresse3 = "";
        private String _beguenstigterAdresse4 = "";
        private String _controlKey;

        /// <summary>
        /// Die ESR-Teilnehmernummer des Begünstigten kann dem Feld "Konto" des Verarbeitungsbeleges
        /// entnommen werden (siehe Anhang C 13). Die Angaben sind in die 1. Zeile (24 Positionen)
        /// nach "/C/" in die Positionen 4–12 rechtsbündig mit führenden Nullen einzusetzen. Die
        /// restlichen 12 Positionen sind mit "blanks" aufzufüllen. Es wird empfohlen, die
        /// Prüfziffer nachzurechnen und zu vergleichen (siehe Anhang C 13). Bei 9-stelligen
        /// Teilnehmernummern sind die Bindestriche wegzulassen. Der Name und die Adresse sind
        /// fakultativ, sie werden nicht an die Postfinance weitergeleitet. Beispiel : 5-stellige
        /// Teilnehmernummer : /C/000010304 9-stellige Teilnehmernummer : /C/012127029 Length : 24 x
        /// + 4·20 x Obligatorisch : ja
        /// </summary>
        private String _eSrBeguenstigterTeilnehmernummer;

        private String _eSrReferenznummer;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// GT826 ESR CHF-Zahlungen im Inland
        /// </summary>
        public DtaRecord826(
            String zubelastendendesKonto,
            Decimal verguetungsbetragParam,
            String auftraggeber1Param,
            String auftraggeber2Param,
            String auftraggeber3Param,
            String auftraggeber4Param,
            String esrBeguenstigterTeilnehmernummerParam,
            String beguenstigterAdresse1Param,
            String beguenstigterAdresse2Param,
            String beguenstigterAdresse3Param,
            String beguenstigterAdresse4Param,
            String bvrReferenceNummerParam,
            DateTime valutaDatum)
            : base("", zubelastendendesKonto, verguetungsbetragParam, valutaDatum)
        {
            Auftraggeber1 = auftraggeber1Param;
            Auftraggeber2 = auftraggeber2Param;
            Auftraggeber3 = auftraggeber3Param;
            Auftraggeber4 = auftraggeber4Param;

            ESRBeguenstigterTeilnehmernummer = esrBeguenstigterTeilnehmernummerParam;

            BeguenstigterAdresse1 = beguenstigterAdresse1Param;
            BeguenstigterAdresse2 = beguenstigterAdresse2Param;
            BeguenstigterAdresse3 = beguenstigterAdresse3Param;
            BeguenstigterAdresse4 = beguenstigterAdresse4Param;

            BVRReferenceNummer = bvrReferenceNummerParam;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sets the auftraggeber1.
        /// </summary>
        /// <value>The auftraggeber1.</value>
        public string Auftraggeber1
        {
            set
            {
                if (value.Length > 20)
                {
                    _auftraggeber1 = value.Substring(0, 20);
                    Auftraggeber2 = value.Substring(20, value.Length - 20);
                }
                else
                {
                    _auftraggeber1 = value;
                }
            }
        }

        /// <summary>
        /// Sets the auftraggeber2.
        /// </summary>
        /// <value>The auftraggeber2.</value>
        public string Auftraggeber2
        {
            set
            {
                if (value.Length > 20)
                {
                    _auftraggeber2 = value.Substring(0, 20);
                    Auftraggeber3 = value.Substring(20, value.Length - 20);
                }
                else
                {
                    _auftraggeber2 = value;
                }
            }
        }

        /// <summary>
        /// Sets the auftraggeber3.
        /// </summary>
        /// <value>The auftraggeber3.</value>
        public string Auftraggeber3
        {
            set
            {
                if (value.Length > 20)
                {
                    _auftraggeber3 = value.Substring(0, 20);
                    Auftraggeber4 = value.Substring(20, value.Length - 20);
                }
                else
                {
                    _auftraggeber3 = value;
                }
            }
        }

        /// <summary>
        /// Sets the auftraggeber4.
        /// </summary>
        /// <value>The auftraggeber4.</value>
        public string Auftraggeber4
        {
            set
            {
                if (value.Length > 20)
                {
                    _auftraggeber4 = value.Substring(0, 20);
                    ErrorMessage +=
                        KissMsg.GetMLMessage("DtaRecord826", "AuftraggeberMax80", "Der Auftraggeber wurde gekürzt, er darf max. 80 Zeichen lang sein") +
                        Environment.NewLine;
                }
                else
                {
                    _auftraggeber4 = value;
                }
            }
        }

        /// <summary>
        /// Converts the auftraggeber to DTA.
        /// </summary>
        /// <value>The auftraggeber to DTA.</value>
        public string AuftraggeberToDTA
        {
            get
            {
                return
                    Utilities.FillBlanks(Utilities.StringToDTAString(_auftraggeber1), 20, " ", true) +
                    Utilities.FillBlanks(Utilities.StringToDTAString(_auftraggeber2), 20, " ", true) +
                    Utilities.FillBlanks(Utilities.StringToDTAString(_auftraggeber3), 20, " ", true) +
                    Utilities.FillBlanks(Utilities.StringToDTAString(_auftraggeber4), 20, " ", true);
            }
        }

        /// <summary>
        /// Sets the beguenstigter adresse1.
        /// </summary>
        /// <value>The beguenstigter adresse1.</value>
        public string BeguenstigterAdresse1
        {
            set
            {
                if (value.Length > 20)
                {
                    _beguenstigterAdresse1 = value.Substring(0, 20);
                    BeguenstigterAdresse2 = value.Substring(20, value.Length - 20);
                }
                else
                {
                    _beguenstigterAdresse1 = value;
                }
            }
        }

        /// <summary>
        /// Sets the beguenstigter adresse2.
        /// </summary>
        /// <value>The beguenstigter adresse2.</value>
        public string BeguenstigterAdresse2
        {
            set
            {
                if (value.Length > 20)
                {
                    _beguenstigterAdresse2 = value.Substring(0, 20);
                    BeguenstigterAdresse3 = value.Substring(20, value.Length - 20);
                }
                else
                {
                    _beguenstigterAdresse2 = value;
                }
            }
        }

        /// <summary>
        /// Sets the beguenstigter adresse3.
        /// </summary>
        /// <value>The beguenstigter adresse3.</value>
        public string BeguenstigterAdresse3
        {
            set
            {
                if (value.Length > 20)
                {
                    _beguenstigterAdresse3 = value.Substring(0, 20);
                    BeguenstigterAdresse4 = value.Substring(20, value.Length - 20);
                }
                else
                {
                    _beguenstigterAdresse3 = value;
                }
            }
        }

        /// <summary>
        /// Sets the beguenstigter adresse4.
        /// </summary>
        /// <value>The beguenstigter adresse4.</value>
        public string BeguenstigterAdresse4
        {
            set
            {
                if (value.Length > 20)
                {
                    _beguenstigterAdresse4 = value.Substring(0, 20);
                    ErrorMessage +=
                        KissMsg.GetMLMessage(
                            "DtaRecord826",
                            "AdresseBeguenstigterMax80",
                            "Die Adresse des Begünstigten wurde gekürzt, sie darf max. 80 Zeichen lang sein") + Environment.NewLine;
                }
                else
                {
                    _beguenstigterAdresse4 = value;
                }
            }
        }

        /// <summary>
        /// Gets the beguenstigter to DTA.
        /// </summary>
        /// <value>The beguenstigter to DTA.</value>
        public string BeguenstigterToDTA
        {
            get
            {
                return "/C/" + Utilities.FillBlanks(_eSrBeguenstigterTeilnehmernummer, 9, "0", false)
                       + Utilities.FillBlanks(Utilities.StringToDTAString(_beguenstigterAdresse1), 20, " ", true)
                       + Utilities.FillBlanks(Utilities.StringToDTAString(_beguenstigterAdresse2), 20, " ", true)
                       + Utilities.FillBlanks(Utilities.StringToDTAString(_beguenstigterAdresse3), 20, " ", true)
                       + Utilities.FillBlanks(Utilities.StringToDTAString(_beguenstigterAdresse4), 20, " ", true);
            }
        }

        /// <summary>
        /// Sets the BVR reference nummer.
        /// </summary>
        /// <value>The BVR reference nummer.</value>
        public string BVRReferenceNummer
        {
            set
            {
                if (_eSrBeguenstigterTeilnehmernummer == null)
                {
                    throw new Exception("ESRBeguenstigterTeilnehmer nummer must erst gesetzt sein");
                }
                value = value.Replace(" ", "");

                if (_eSrBeguenstigterTeilnehmernummer.Length == 5)
                {
                    if (value.Length != 15)
                    {
                        throw new Exception("BVR Reference Nummer muss 15 Characters sein");
                    }
                    _eSrReferenznummer = value;
                }
                else
                {
                    if (value.Length != 16 && value.Length != 27)
                    {
                        throw new Exception("BVR Reference Nummer muss 16 oder 27 Characters sein");
                    }

                    if (!Utils.CheckMod10Nummer(value))
                    {
                        throw new Exception("Invalid BVR Reference Nummer");
                    }
                    _eSrReferenznummer = value;
                }
                // set ControlKey
                string temp = Verguetungsbetrag.ToString(CultureInfo.InvariantCulture).Replace(".", "");
                string codeLinie = "0001" + Utilities.FillBlanks(temp, 9, "0", false);
                codeLinie += _eSrReferenznummer;
                codeLinie += _eSrBeguenstigterTeilnehmernummer;
                _controlKey = Utilities.CalculateCodeLinieMod11(codeLinie);
            }
        }

        /// <summary>
        /// Gets the BVR reference nummer to DTA.
        /// </summary>
        /// <value>The BVR reference nummer to DTA.</value>
        public string BVRReferenceNummerToDTA
        {
            get { return Utilities.FillBlanks(_eSrReferenznummer, 27, " ", true); }
        }

        /// <summary>
        /// Gets the control key to DTA.
        /// </summary>
        /// <value>The control key to DTA.</value>
        public string ControlKeyToDTA
        {
            get
            {
                if (_eSrReferenznummer.Length > 5)
                {
                    return "  ";
                }
                return _controlKey;
            }
        }

        /// <summary>
        /// Sets the ESR beguenstigter teilnehmernummer.
        /// </summary>
        /// <value>The ESR beguenstigter teilnehmernummer.</value>
        public string ESRBeguenstigterTeilnehmernummer
        {
            set
            {
                if (!Utils.CheckMod10Nummer(Utils.FormatPCKontoNummerToDBFormat(value)))
                {
                    throw new Exception("Invalid Beguenstigter ESR Teilnehmer Nummer");
                }
                _eSrBeguenstigterTeilnehmernummer = Utils.FormatPCKontoNummerToDBFormat(value);
            }
        }

        /// <summary>
        /// Gets the zubelastendes konto to DTA.
        /// </summary>
        /// <value>The zubelastendes konto to DTA.</value>
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
            var sw = new StreamWriter(fileInfo.FullName, true, Encoding.Default, 131072);

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
                sw.Write("826");
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
                sw.Write(Utilities.FillBlanks("", 46, " ", true));

                // Enregistrement 3
                sw.Write("03");

                //16 Beguenstigter
                sw.Write(BeguenstigterToDTA);

                //17 BVRZahlungsReference
                sw.Write(BVRReferenceNummerToDTA);

                sw.Write(ControlKeyToDTA);

                sw.Write(Utilities.FillBlanks("", 5, " ", true));

                sw.Flush();
            }
            catch (Exception ex)
            {
                // Eintrag ins Log.
                LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

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