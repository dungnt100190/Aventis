using System;
using System.Text.RegularExpressions;

using KiSS4.DB;

using KiSS.Common.BL.DTO;
using KiSS.Common.Validation;
using KiSS.KliBu.BL.Parser;

namespace KiSS.KliBu.BL.DTO
{
    /// <summary>
    /// Class to manage bank information comming from <see cref="http://www.six-interbank-clearing.com/de/dl_tkicch_bcbankenstamm.pdf"/>
    /// </summary>
    public class Bank : BOBase
    {
        #region Fields

        #region Private Fields

        private string _pcKontoNr;
        private string _pcKontoNrFormated;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Record"/> class
        /// </summary>
        public Bank()
        {
            SicUpdated = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bank"/> class
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="clearingNr">The clearing number</param>
        /// <param name="filialeNr">The branch number</param>
        /// <param name="gueltigAb">The validFrom date</param>  
        public Bank(string name, string clearingNr, int filialeNr, DateTime gueltigAb)
        {
            Name = name;
            ClearingNr = clearingNr;
            FilialeNr = filialeNr;
            GueltigAb = gueltigAb;
            SicUpdated = false;
            Creator = DBUtil.GetDBRowCreatorModifier();
            Created = DateTime.Now;
            Modifier = DBUtil.GetDBRowCreatorModifier();
            Modified = DateTime.Now;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Art der Clearing Nummer
        /// 1 = Hauptsitz
        /// 2 = Kopfstelle
        /// 3 = Filiale
        /// </summary>
        public int? BcArt
        {
            get;
            set;
        }

        /// <summary>
        /// Clearing Nummer
        /// </summary>
        public string ClearingNr
        {
            get;
            set;
        }

        /// <summary>
        /// Neue Clearing-Nummer
        /// </summary>
        public string ClearingNrNeu
        {
            get;
            set;
        }

        public DateTime Created
        {
            get; set;
        }

        public string Creator
        {
            get;
            set;
        }

        /// <summary>
        /// Faxnummer
        /// </summary>
        public string Fax
        {
            get;
            set;
        }

        /// <summary>
        /// Filiale Nummer
        /// </summary>
        public int FilialeNr
        {
            get;
            set;
        }

        /// <summary>
        /// Bankengruppe
        /// </summary>
        public int? Gruppe
        {
            get;
            set;
        }

        /// <summary>
        /// Datum seit welchem die Bank gültig ist
        /// </summary>
        public DateTime GueltigAb
        {
            get;
            set;
        }

        /// <summary>
        /// Clearing Nummer vom Hauptsitz
        /// </summary>
        public string HauptsitzBCL
        {
            get;
            set;
        }

        /// <summary>
        /// The primary key
        /// </summary>
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// Kurzbezeichnung der Bank
        /// </summary>
        public string Kurzbezeichnung
        {
            get;
            set;
        }

        /// <summary>
        /// alphabetischer Landcode
        /// </summary>
        public string Landcode
        {
            get;
            set;
        }

        /// <summary>
        /// Internationale Vorwahl für Telefon und Fax
        /// </summary>
        public string LandesVorwahl
        {
            get;
            set;
        }

        public DateTime Modified
        {
            get;
            set;
        }

        public string Modifier
        {
            get;
            set;
        }

        /// <summary>
        /// Name der Bank
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Ort
        /// </summary>
        public string Ort
        {
            get;
            set;
        }

        /// <summary>
        /// Postkonto-Nummer
        /// </summary>
        public string PCKontoNr
        {
            get { return _pcKontoNr; }

            set
            {
                _pcKontoNr = value;
                _pcKontoNrFormated = null;

            }
        }

        /// <summary>
        /// Formatierte Postkonto-Nummer (<see cref="PCKontoNr"/>). Z.B: 80-123456-02 = 8012345602, 80-2-10 = 8000000210. 
        /// Gibt die <see cref="PCKontoNr"/> zurück wenn die Postkonto-Nummer kein valides Format hat.
        /// </summary>
        public string PCKontoNrFormatiert
        {
            get
            {
                if (_pcKontoNrFormated == null)
                {
                    _pcKontoNrFormated = _pcKontoNr;
                    Regex rx = new Regex(Rgx.PCKontoNr);
                    if (_pcKontoNrFormated != null && rx.IsMatch(_pcKontoNrFormated))
                    {
                        string[] accountPart = _pcKontoNrFormated.Split(new char[] { '-' });
                        _pcKontoNrFormated = accountPart[0] + accountPart[1].PadLeft(6, '0') + accountPart[2];
                    }
                }
                return _pcKontoNrFormated;
            }
        }

        /// <summary>
        /// Postleitzahl
        /// </summary>
        public string PLZ
        {
            get;
            set;
        }

        /// <summary>
        /// Postiche Adresse
        /// </summary>
        public string Postadresse
        {
            get;
            set;
        }

        /// <summary>
        /// SIC definierte Nummer
        /// </summary>
        public int? SicNr
        {
            get;
            set;
        }

        /// <summary>
        /// von SIC aktualisiert
        /// </summary>
        public bool SicUpdated
        {
            get;
            set;
        }

        /// <summary>
        /// Sprachcode
        /// </summary>
        public int? Sprachcode
        {
            get;
            set;
        }

        /// <summary>
        /// Strasse
        /// </summary>
        public string Strasse
        {
            get;
            set;
        }

        /// <summary>
        /// Swift-Adresse
        /// </summary>
        public string SwiftAdresse
        {
            get;
            set;
        }

        /// <summary>
        /// Teilnahmecode für CHF an SIC
        /// </summary>
        public int? TeilnahmecodeCHF
        {
            get;
            set;
        }

        /// <summary>
        /// Teilnahmecode für Euro an SIC
        /// </summary>
        public int? TeilnahmecodeEuro
        {
            get;
            set;
        }

        /// <summary>
        /// Telefonnummer
        /// </summary>
        public string Telefon
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override string ToString()
        {
            return "Bank " + ClearingNr + "#" + FilialeNr;
        }

        public string ToStringLog()
        {
            return ID + "#" +
                   Name + "#" +
                   Strasse + "#" +
                   PLZ + "#" +
                   Ort + "#" +
                   ClearingNr + "#" +
                   FilialeNr + "#" +
                   HauptsitzBCL + "#" +
                   PCKontoNr + "#" +
                   string.Format("{0}-{1}-{2}", GueltigAb.Year, GueltigAb.Month, GueltigAb.Day) + "#" +
                   Landcode + "#" +
                   ClearingNrNeu;
        }

        #endregion

        #endregion
    }
}