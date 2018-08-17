using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Kiss.BusinessLogic.Sys;
using Kiss.Infrastructure.IoC;

using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Beleg Typ.
    /// </summary>
    public enum BelegTyp
    {
        /// <summary>
        /// Unbekannt.
        /// </summary>
        Unbekannt = 0,

        /// <summary>
        /// ESR.
        /// </summary>
        ESR = 1,

        /// <summary>
        /// Post.
        /// </summary>
        Post = 2,

        /// <summary>
        /// Bank.
        /// </summary>
        Bank = 5
    }

    /// <summary>
    /// Interface für Belegleser.
    /// </summary>
    public interface IBelegleser
    {
        /// <summary>
        /// Execute the reader.
        /// </summary>
        /// <param name="beleg">The beleg.</param>
        void ProcessBelegleser(Belegleser beleg);
    }

    /// <summary>
    /// Summary description for Belegleser.
    /// </summary>
    public class Belegleser
    {
        /// <summary>
        /// Typ des belegs.
        /// </summary>
        protected BelegTyp _belegTyp;

        /// <summary>
        /// Der Betrag.
        /// </summary>
        protected decimal _betrag = 0;

        /// <summary>
        /// The Bank Clearingnummer.
        /// </summary>
        protected string _clearingNummer;

        /// <summary>
        /// Die Kontonummer.
        /// </summary>
        protected string _kontoNummer;

        /// <summary>
        /// Die Referenznummer.
        /// </summary>
        protected string _referenzNummer;

        private const string CLASSNAME = "Belegleser";

        private static readonly Regex _regexBank = new Regex(@"^\s*(?<RefNr>\d{27})\+\s*\d{2}(?<Clearing>\d{5})\d{2}\>\s*$");

        private static readonly Regex _regexEsr5 = new Regex(@"^\s*\<\d{6}(?<Fr>\d{7})(?<Rp>\d{2})\>\s*(?<RefNr>\d{15})\+\s*(?<Konto>\d{5})\>\s*$");

        private static readonly Regex _regexEsr5Plus = new Regex(@"^\s*(?<RefNr>\d{15})\+\s*(?<Konto>\d{5})\>\s*$");

        private static readonly Regex _regexEsr9 = new Regex(@"^\s*\d{2}(?<Fr>\d{8})(?<Rp>\d{2})\d\>(?<RefNr>\d{16}|\d{27})\+\s*(?<Konto>\d{9})\>\s*$");

        private static readonly Regex _regexEsr9Plus = new Regex(@"^\s*\d{3}\>(?<RefNr>\d{16}|\d{27})\+\s*(?<Konto>\d{9})\>\s*$");

        /// <summary>
        /// Regulärer Ausdruck für Postkonto.
        /// </summary>
        private static readonly Regex _regexPost = new Regex(@"^\s*(?<Konto>\d{9})\>\s*$");

        private readonly Control _control;

        private StringBuilder _belegLeserString = new StringBuilder();

        private IBelegleser _iBelegleser;

        /// <summary>
        /// Initializes a new instance of the <see cref="Belegleser"/> class.
        /// </summary>
        /// <param name="control">The FRM.</param>
        public Belegleser(Control control)
        {
            _control = control;

            if (!Session.IsKiss5Mode)
            {
                var form = control as Form;
                if (form != null)
                {
                    form.KeyPreview = true;
                }
                control.KeyDown += OnKeyDown;
                control.KeyPress += OnKeyPress;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="belegLeserString"></param>
        public Belegleser(string belegLeserString)
        {
            // ESR/ESR+ 9-stellige Teilnehmernummer, 16/27 stellige Referenznummer
            Match m = _regexEsr9.Match(belegLeserString);

            if (m.Success)
            {
                _betrag = decimal.Parse(m.Groups["Fr"].Value + "." + m.Groups["Rp"].Value);
            }
            else
            {
                m = _regexEsr9Plus.Match(belegLeserString);
            }

            if (m.Success)
            {
                _belegTyp = BelegTyp.ESR;
                _referenzNummer = m.Groups["RefNr"].Value;
                _kontoNummer = m.Groups["Konto"].Value;
            }
            else
            {
                // ESR/ESR+ 5-stellige Teilnehmernummer, 15 stellige Referenznummer
                m = _regexEsr5.Match(belegLeserString);

                if (m.Success)
                {
                    _betrag = decimal.Parse(m.Groups["Fr"].Value + "." + m.Groups["Rp"].Value);
                }
                else
                {
                    m = _regexEsr5Plus.Match(belegLeserString);
                }

                if (m.Success)
                {
                    _belegTyp = BelegTyp.ESR;
                    _referenzNummer = m.Groups["RefNr"].Value;
                    _kontoNummer = m.Groups["Konto"].Value;
                }
                else
                {
                    // Postkonto
                    m = _regexPost.Match(belegLeserString);
                    if (m.Success)
                    {
                        _belegTyp = BelegTyp.Post;
                        _kontoNummer = m.Groups["Konto"].Value;
                    }
                    else
                    {
                        // Bankkonto
                        m = _regexBank.Match(belegLeserString);
                        if (m.Success)
                        {
                            _belegTyp = BelegTyp.Bank;
                            _referenzNummer = m.Groups["RefNr"].Value;
                            _kontoNummer = _referenzNummer.Substring(10, 16);
                            _clearingNummer = RemoveZeros(m.Groups["Clearing"].Value, false);
                        }
                        else
                        {
                            throw new Exception(KissMsg.GetMLMessage(CLASSNAME, "UnknownCodeLineOrWrongRead", "Codierzeile unbekannt oder falsch gelesen\r\n\r\n{0}", belegLeserString));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Belegleser"/> class.
        /// </summary>
        /// <param name="beleg">The beleg.</param>
        protected Belegleser(Belegleser beleg)
        {
            _belegTyp = beleg._belegTyp;
            _clearingNummer = beleg._clearingNummer;
            _kontoNummer = beleg._kontoNummer;
            _referenzNummer = beleg._referenzNummer;
            _betrag = beleg._betrag;
        }

        /// <summary>
        /// Liest den BelegTyp.
        /// </summary>
        public BelegTyp BelegTyp
        {
            get { return _belegTyp; }
        }

        /// <summary>
        /// Betrag
        /// </summary>
        public decimal Betrag
        {
            get { return _betrag; }
        }

        /// <summary>
        /// Gets the clearing nummer.
        /// </summary>
        public string ClearingNummer
        {
            get { return _clearingNummer; }
        }

        /// <summary>
        /// IBAN-Nummer
        /// </summary>
        public string IBANNummer
        {
            get
            {
                try
                {
                    switch (BelegTyp)
                    {
                        case BelegTyp.Post:
                            return IBANConvert(KontoNummer, "9000");

                        case BelegTyp.Bank:
                            return IBANConvert(_referenzNummer, _clearingNummer);
                    }
                }
                catch { }
                return null;
            }
        }

        /// <summary>
        /// Post- oder Bankkontonummer
        /// </summary>
        public string KontoNummer
        {
            get { return _kontoNummer; }
        }

        /// <summary>
        /// ESR-Referenznummer
        /// </summary>
        public string ReferenzNummer
        {
            get { return _referenzNummer; }
        }

        /// <summary>
        /// Reads the Expiration date from the IBANKernel DLL
        /// </summary>
        /// <returns>The expiration date or null if it could not be read</returns>
        public static DateTime? GetIBANExpirationDate()
        {
            DateTime? dateResult = null;
            int major = 0;
            int minor = 0;
            StringBuilder validThru = new StringBuilder(32);
            int result = IT_IBANVersion(ref major, ref minor, validThru, validThru.Capacity);
            if (result == 1)
            {
                dateResult = Convert.ToDateTime(validThru.ToString().Insert(4, "-").Insert(7, "-"));
            }

            return dateResult;
        }

        /// <summary>
        /// Berechne die IBAN aus der Konto- und der Clearing Nummer.
        /// </summary>
        /// <param name="accountNumber">Bankkontonummer</param>
        /// <param name="clearingNumber">Bank Clearingnummer</param>
        /// <returns></returns>
        public static string IBANConvert(string accountNumber, string clearingNumber)
        {
            var iban = new StringBuilder(64);
            var bc = new StringBuilder(32);
            var pc = new StringBuilder(32);
            var reserved = new StringBuilder(32);

            var nResult = IT_IBANConvert(
                accountNumber, // propr. Kontonummer
                clearingNumber, // Clearing-Nummer

                iban, // Buffer für IBAN
                iban.Capacity, // Länge des Buffers

                bc, // Buffer für BC neu
                bc.Capacity, // Länge des Buffers

                pc, // Buffer für PC
                pc.Capacity, // Länge des Buffers

                reserved, // for later usage
                reserved.Capacity);

            // wenn DLL abgelaufen ist mittels Webservice versuchen
            if (nResult == 31)
            {
                bool fallbackViaWeb = DBUtil.GetConfigBool(@"System\Iban\Web", false);

                if (fallbackViaWeb)
                {
                    var converterService = Container.Resolve<IbanConverterService>();
                    var result = converterService.ConvertToIbanWeb(accountNumber, clearingNumber);

                    if (result.IsOk)
                    {
                        return result.Result;
                    }

                    if (!int.TryParse(result.Result, out nResult))
                    {
                        throw new Exception(result.ToString());
                    }

                    return ProcessIbanResult(null, nResult);
                }
            }

            return ProcessIbanResult(iban.ToString(), nResult);
        }

        /// <summary>
        /// Shows the IBAN version.
        /// </summary>
        public static void ShowIBANVersion()
        {
            int major = 0;
            int minor = 0;
            StringBuilder validThru = new StringBuilder(32);
            int result = IT_IBANVersion(ref major, ref minor, validThru, validThru.Capacity);

            KissMsg.ShowInfo(CLASSNAME, "ShowIBANVersion", "IBAN-Version:\r\n\r\nMajor='{0}', Minor='{1}', Gültig bis='{2}'", major, minor, validThru.ToString().Insert(4, "-").Insert(7, "-"));
        }

        /// <summary>
        /// Handles the KeyDown event of the control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Handled)
            {
                return;
            }

            // handle F11 for Belegleser
            if (e.KeyCode == Keys.F11)
            {
                IBelegleser ctl = FindIBelegleser();

                if (ctl == null)
                {
                    _iBelegleser = null;
                }
                else if (ctl == _iBelegleser)
                {
                    try
                    {
                        _iBelegleser.ProcessBelegleser(new Belegleser(_belegLeserString.ToString()));
                    }
                    catch (KissCancelException ex)
                    {
                        ex.ShowMessage();
                    }
                    catch (Exception ex)
                    {
                        KissMsg.ShowError(CLASSNAME, "FehlerEinlesenBeleg_v2", "Fehler beim Einlesen des Belegs.", ex);
                    }

                    _iBelegleser = null;
                    e.Handled = true;
                }
                else
                {
                    _belegLeserString = new StringBuilder();
                    _iBelegleser = ctl;
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Handles the KeyPress event of the control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyPressEventArgs"/> instance containing the event data.</param>
        public void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled)
            {
                return;
            }

            if (_iBelegleser != null)
            {
                if (_iBelegleser == FindIBelegleser())
                {
                    _belegLeserString.Append(e.KeyChar);
                    e.Handled = true;
                }
                else
                {
                    _iBelegleser = null;
                }
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            return KissMsg.GetMLMessage(CLASSNAME,
                                        "BelegLeserToString",
                                        "KontoTyp: {0}\r\nClearing: {1}\r\nKonto: {2}\r\nReferenznummer: {3}\r\nBetrag: {4:n2}",
                                        _belegTyp,
                                        _clearingNummer,
                                        _kontoNummer,
                                        _referenzNummer,
                                        _betrag);
        }

        /// <summary>
        /// Wrapper für Libs\IBANKernel.dll!IT_IBANConvert().
        /// http://www.currency-iso.org/DE/dl_ibantool_fi_swh.pdf
        /// </summary>
        /// <param name="konto">The konto.</param>
        /// <param name="PCBC">The PCBC.</param>
        /// <param name="IBAN">The IBAN.</param>
        /// <param name="IBANLen">The IBAN len.</param>
        /// <param name="BC">The BC.</param>
        /// <param name="BCLen">The BC len.</param>
        /// <param name="PC">The PC.</param>
        /// <param name="PCLen">The PC len.</param>
        /// <param name="reserved">The reserved.</param>
        /// <param name="reservedLen">The reserved len.</param>
        /// <returns></returns>
        [DllImport(@"IBANKernel.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int IT_IBANConvert(
            string konto,
            string PCBC,
            StringBuilder IBAN,
            int IBANLen,
            StringBuilder BC,
            int BCLen,
            StringBuilder PC,
            int PCLen,
            StringBuilder reserved,
            int reservedLen);

        /// <summary>
        /// Wrapper für Libs\IBANKernel.dll!IT_IBANVersion()
        /// http://www.currency-iso.org/DE/dl_ibantool_fi_swh.pdf
        /// </summary>
        /// <param name="major">The major.</param>
        /// <param name="minor">The minor.</param>
        /// <param name="validThru">The valid thru.</param>
        /// <param name="validThruLen">The valid thru len.</param>
        /// <returns></returns>
        /// <remarks>http://www.currency-iso.org/DE/dl_ibantool_fi_swh.pdf</remarks>
        [DllImport(@"IBANKernel.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int IT_IBANVersion(
            ref int major,
            ref int minor,
            StringBuilder validThru,
            int validThruLen);

        private static string ProcessIbanResult(string iban, int result)
        {
            if (result >= 1 && result <= 9)
            {
                return iban;
            }

            switch (result)
            {
                case 10:
                    throw new Exception(KissMsg.GetMLMessage(CLASSNAME, "InvalidDataInBCPCNrSWIFTBIC", "Ungültige Daten in Feld \"BC/PC-Nr. / SWIFT-BIC\""));

                case 11:
                    throw new Exception(KissMsg.GetMLMessage(CLASSNAME, "NoIBANCalcForBCPCNr", "Für die Bank mit dieser BC-/Postkonto-Nummer ist kein IBAN-Berechnungs-Algorithmus hinterlegt"));

                case 12:
                    throw new Exception(KissMsg.GetMLMessage(CLASSNAME, "UnknownBCNr", "BC-Nummer unbekannt"));

                case 13:
                    throw new Exception(KissMsg.GetMLMessage(CLASSNAME, "ChecksumWrongInBCNr", "Prüfziffer falsch in BC-Nummer"));

                case 20:
                    throw new Exception(KissMsg.GetMLMessage(CLASSNAME, "InvalidDataInAccountNr", "Ungültige Daten im Feld \"Proprietäre Kontonummer\""));

                case 21:
                    throw new Exception(KissMsg.GetMLMessage(CLASSNAME, "WrongCHLIIBANStructureInInput", "Falsche CH-/LI-IBAN Struktur in Input-Record"));

                case 22:
                    throw new Exception(KissMsg.GetMLMessage(CLASSNAME, "WrongAccountNrOrESCode", "Proprietäre Kontonummer oder ES-Codierzeile Fehlerhaft (Prüfziffer-Fehler)"));

                case 23:
                    throw new Exception(KissMsg.GetMLMessage(CLASSNAME, "InputUnsaveAlgorithm", "Inputdaten gemäss Algorithmus unsicher"));

                case 24:
                    throw new Exception(KissMsg.GetMLMessage(CLASSNAME, "InvalidInputdata", "Fehlerhafte Inputdaten"));

                case 25:
                    throw new Exception(KissMsg.GetMLMessage(CLASSNAME, "ConversionPropAccountNrZEFI", "Konversion proprietäre Kontonummer durch ZE-FI ausgeschlossen"));

                case 26:
                    throw new Exception(KissMsg.GetMLMessage(CLASSNAME, "IBANWrongChecksumOrOldID", "IBAN ist fehlerhaft (Prüfziffer-Fehler) oder ist wegen alter ID nicht mehr gültig"));

                case 27:
                    throw new Exception(KissMsg.GetMLMessage(CLASSNAME, "DataBCPCNrSWIFTIIDNotMatching", "Daten aus Feld \"BC-/PC-Nr. / SWIFT-BIC\" und IID in eingelesener IBAN gehören nicht zusammen"));

                case 29:
                    throw new Exception(KissMsg.GetMLMessage(CLASSNAME, "FormatInvalidInInputRec", "Formatfehler in Input-Record"));

                case 31:
                    throw new Exception(KissMsg.GetMLMessage(CLASSNAME, "IBANOutOfDate", "IBAN-Tool abgelaufen -> Keine Konversion mehr möglich / vorgängiger Download neuer IBAN-Tool-Release erforderlich"));

                default:
                    throw new Exception(KissMsg.GetMLMessage(CLASSNAME, "FailedToConvert", "Status '{0}' konnte nicht identifiziert und konvertiert werden", result));
            }
        }

        /// <summary>
        /// Removes the zeros.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="atEnd">if set to <c>true</c> [at end].</param>
        /// <returns></returns>
        private static string RemoveZeros(string value, bool atEnd)
        {
            string temp = "";
            int index = 0;

            //remove 0 from beginning
            while (value[index] == '0' && index <= value.Length - 1)
            {
                index += 1;
            }

            temp = value.Substring(index, value.Length - index);

            if (atEnd == true)
            {
                //then remove '0' from end

                index = temp.Length - 1;

                while (temp[index] == '0' && index >= 0)
                {
                    index -= 1;
                }

                temp = temp.Substring(0, index + 1);
            }
            return temp;
        }

        /// <summary>
        /// Find the IBelegleser.
        /// </summary>
        /// <returns></returns>
        private IBelegleser FindIBelegleser()
        {
            if (_control is IBelegleser)
            {
                return (IBelegleser)_control;
            }

            var kissForm = _control as KissForm;
            if (kissForm != null && kissForm.DetailControl != null)
            {
                foreach (Control ctl in UtilsGui.AllControls(kissForm.DetailControl))
                {
                    if (ctl is IBelegleser)
                    {
                        return (IBelegleser)ctl;
                    }
                }
            }

            foreach (Control ctl in UtilsGui.AllControls(_control))
            {
                if (ctl is IBelegleser)
                {
                    return (IBelegleser)ctl;
                }
            }

            return null;
        }
    }
}