using System;
using System.IO;

using KiSS4.Common;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Summary description for UzagHeader.
    /// </summary>
    public class EzagHeader
    {
        #region Enumerations

        public enum TransaktionsArt
        {
            Post22,
            Mandat24,
            Bank27,
            Bsr28,
            Total97,
            Control00
        }

        #endregion

        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly TransaktionsArt _transaktionsart;

        #endregion

        #region Private Fields

        private DateTime _faelligkeitsdatum = DateTime.MinValue;
        private string _gebuehrenkontonummer = "";
        private string _lastkontonummer = "";
        private string fileIdentifikation = "036";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EzagHeader"/> class.
        /// </summary>
        /// <param name="faelligkeitsdatumParamValue">The faelligkeitsdatum param value.</param>
        /// <param name="lastKontoNummerParamValue">The last konto nummer param value.</param>
        /// <param name="gebuehrenkontonummerParamValue">The gebuehrenkontonummer param value.</param>
        /// <param name="transaktionsArtValue">The transaktions art value.</param>
        public EzagHeader(
            DateTime faelligkeitsdatumParamValue,
            string lastKontoNummerParamValue,
            string gebuehrenkontonummerParamValue,
            TransaktionsArt transaktionsArtValue)
        {
            Faelligskeitsdatum = faelligkeitsdatumParamValue;
            Lastkontonummer = lastKontoNummerParamValue;
            Gebuehrenkontonummer = gebuehrenkontonummerParamValue;
            _transaktionsart = transaktionsArtValue;
        }

        #endregion

        #region Properties

        public int Auftragsnummer
        {
            get; set;
        }

        public DateTime Faelligskeitsdatum
        {
            get { return _faelligkeitsdatum; }
            set { _faelligkeitsdatum = value; }
        }

        public string FaelligskeitsdatumToDTA
        {
            get { return Utilities.DateTimeToDTAString(_faelligkeitsdatum); }
        }

        public string Gebuehrenkontonummer
        {
            get { return _gebuehrenkontonummer; }
            set
            {
                if (!Utils.CheckMod10Nummer(Utils.FormatPCKontoNummerToDBFormat(value)))
                {
                    throw new PaymentFatalException("Falsch Gebuehrenkontonummer eingegeben");
                }
                _gebuehrenkontonummer = Utils.FormatPCKontoNummerToDBFormat(value);
            }
        }

        public string Lastkontonummer
        {
            get { return _lastkontonummer; }
            set
            {
                if (!Utils.CheckMod10Nummer(Utils.FormatPCKontoNummerToDBFormat(value)))
                {
                    throw new PaymentFatalException("Falsch Belastkontonummer eingegeben");
                }
                _lastkontonummer = Utils.FormatPCKontoNummerToDBFormat(value);
            }
        }

        public string TransaktionsartToDta
        {
            get
            {
                switch (_transaktionsart)
                {
                    case TransaktionsArt.Bank27:
                        return "27";
                    case TransaktionsArt.Bsr28:
                        return "28";
                    case TransaktionsArt.Post22:
                        return "22";
                    case TransaktionsArt.Mandat24:
                        return "24";
                    case TransaktionsArt.Total97:
                        return "97";
                    case TransaktionsArt.Control00:
                        return "00";
                    default:
                        throw new PaymentFatalException("Transaktionart ungültig");
                }
            }
        }

        public int Transaktionslaufnummer
        {
            get; set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void WriteHeaderToUzag(StreamWriter sw)
        {
            try
            {
                //FileIdentifikation
                sw.Write(fileIdentifikation);

                //Faelligskeitsdatum
                sw.Write(FaelligskeitsdatumToDTA);

                //Reserve
                sw.Write(Utilities.FillBlanks("", 5, "0", true));

                //Steuerungsmerkmal
                sw.Write("1");

                //Lastkontonummer
                sw.Write(Utilities.FillBlanks(Lastkontonummer, 9, "0", false));

                //Gebührenkontonummer
                sw.Write(Utilities.FillBlanks(Gebuehrenkontonummer, 9, "0", false));

                //Auftragsnummer
                sw.Write(Utilities.FillBlanks(Auftragsnummer.ToString(), 2, "0", false));

                //Transaktionsart
                sw.Write(TransaktionsartToDta);

                //Transaktionslaufnummer
                sw.Write(Utilities.FillBlanks(Transaktionslaufnummer.ToString(), 6, "0", false));

                //Reserve
                sw.Write(Utilities.FillBlanks("", 6, "0", true));

                //Zahlungsart
                if (_transaktionsart == TransaktionsArt.Bank27)
                {
                    sw.Write("0");
                }
                else
                {
                    sw.Write("0");
                }

                //Header Reserve
                if (_transaktionsart == TransaktionsArt.Control00)
                {
                    sw.Write(Utilities.FillBlanks("", 650, " ", true));
                }

                if (_transaktionsart == TransaktionsArt.Control00)
                {
                    sw.Write(Environment.NewLine);
                }
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