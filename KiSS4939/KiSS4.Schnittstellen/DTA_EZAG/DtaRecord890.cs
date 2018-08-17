using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Summary description for DtaRecord890.
    /// </summary>
    public class DtaRecord890
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly String _datenfileAbsenderIdentifikation;
        private readonly Int32 _eingabeSequenzNummer;
        private readonly DtaHeader _recordHeader;

        /// <summary>
        /// Verguetungsbetrag
        /// Die Darstellung des Betrages erfolgt nach den S.W.I.F.T.-Normen.
        /// Es müssen immer alle drei Teilfelder in folgender Reihenfolge angegeben werden:
        /// • Betrag  16x (max. Länge inkl. obligatorisches Komma; max. 3 Dezimalstellen).
        /// Beispiel : bbbbbbCHF9,5
        /// Length : 16x
        /// Obligatorisch : ja
        /// </summary>
        private readonly Decimal _verguetungsbetrag;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DtaRecord890"/> class.
        /// </summary>
        /// <param name="datenfileAbsenderIdentifikation">The datenfile absender identifikation.</param>
        /// <param name="verguetungsbetrag">The verguetungsbetrag.</param>
        /// <param name="eingabeSequenzNummer">The eingabe sequenz nummer.</param>
        public DtaRecord890(
            String datenfileAbsenderIdentifikation,
            Decimal verguetungsbetrag,
            Int32 eingabeSequenzNummer)
        {
            _recordHeader = new DtaHeader("");
            _eingabeSequenzNummer = eingabeSequenzNummer;
            _datenfileAbsenderIdentifikation = datenfileAbsenderIdentifikation;
            int length = verguetungsbetrag.ToString("0.00", CultureInfo.InvariantCulture).Length;
            int index = verguetungsbetrag.ToString("0.00", CultureInfo.InvariantCulture).LastIndexOf(".");

            if (length > 16)
            {
                throw new Exception("Total betrag > 16 Positionen");
            }

            if (length - index > 3 && index != -1)
            {
                throw new Exception("Maximal 3 Dezimalstellen");
            }

            _verguetungsbetrag = verguetungsbetrag;
        }

        #endregion

        #region Properties

        public string VerguetungsbetragToDTA
        {
            get
            {
                string temp = _verguetungsbetrag.ToString("0.00");
                if (temp.IndexOf(".") != -1 && temp.IndexOf(".") == temp.Length - 2)
                {
                    temp += "0";
                }
                else if (temp.IndexOf(".") == -1)
                {
                    temp += ".00";
                }

                return Utilities.FillBlanks(temp, 16, " ", true).Replace(".", ",");
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void WriteToDTAFile(FileInfo fileInfo)
        {
            var sw = new StreamWriter(fileInfo.FullName, true, Encoding.Default, 131072);

            //1 EintragTyp
            sw.Write("01");
            //2 Verarbeitungstag
            sw.Write(Utilities.FillBlanks("", 6, "0", true));
            //3 BankClearingNummer
            sw.Write(Utilities.FillBlanks("", 12, " ", true));
            //4 AusgabeSequenzNummer
            sw.Write(_recordHeader.AusgabeSequenzNummer);
            //5 ErstellungsDatum
            sw.Write(Utilities.DateTimeToDTAString(DateTime.Now));
            //6 BankClearingNummerAuftragsgebber
            sw.Write(Utilities.FillBlanks("", 7, " ", true));

            //7 DatenfileAbsenderIdentifikation
            sw.Write(Utilities.FillBlanks(_datenfileAbsenderIdentifikation, 5, "0", true));
            //8 EingabeSequenzNummer
            sw.Write(Utilities.FillBlanks(_eingabeSequenzNummer.ToString(), 5, "0", false));
            //9 TransaktionsArt
            sw.Write("890");
            //10 ZahlungsArt
            sw.Write(Convert.ToInt32(_recordHeader.ZahlungsArt).ToString());
            //11 BearbeitungsFlag
            sw.Write(Convert.ToInt32(_recordHeader.BearbeitungsFlag).ToString());
            //14 Verguetungsbetrag
            sw.Write(VerguetungsbetragToDTA);
            // Reserve blanks
            sw.Write(Utilities.FillBlanks("", 59, " ", true));

            sw.Flush();
            sw.Close();
        }

        #endregion

        #endregion
    }
}