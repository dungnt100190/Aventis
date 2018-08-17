using System;
using System.Globalization;
using System.IO;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Summary description for EzagRecord.
    /// </summary>
    public class EzagRecord : BuchungsRecord
    {
        #region Fields

        #region Private Fields

        private decimal _aufgabebetrag;
        private string _isoCodeVerguetungswaehrung;

        #endregion

        #endregion

        #region Constructors

        public EzagRecord(decimal aufgabebetragParam, EzagHeader.TransaktionsArt transaktionsArt)
        {
            Aufgabebetrag = aufgabebetragParam;
            ISOCodeAufgabewaehrung = "CHF";
            ISOCodeVerguetungswaehrung = "CHF";
            ISOCodeLand = "CH";
            TransaktionsArt = transaktionsArt;
        }

        #endregion

        #region Properties

        public decimal Aufgabebetrag
        {
            get { return _aufgabebetrag; }
            set
            {
                int valueLength = value.ToString().Length;
                if (value > 9999999999999)
                {
                    throw new PaymentFatalException("Betrag über 9'999'999'999'999");
                }

                if (value.ToString()[valueLength - 1] != '0' || value.ToString()[valueLength - 2] != '0')
                {
                    throw new PaymentFatalException("2 decimal Positionen max !");
                }
                _aufgabebetrag = value;
            }
        }

        public string AufgabetragToDTA
        {
            get { return Utilities.FormatDecimalToDTAMoney(Aufgabebetrag.ToString(CultureInfo.InvariantCulture), 13); }
        }

        public EzagHeader Header
        {
            get; set;
        }

        public string ISOCodeAufgabewaehrung
        {
            get; set;
        }

        public string ISOCodeLand
        {
            get; set;
        }

        public string ISOCodeVerguetungswaehrung
        {
            get { return _isoCodeVerguetungswaehrung; }
            set
            {
                if (value != ISOCodeAufgabewaehrung)
                {
                    throw new PaymentFatalException(
                        "Keine Drittwährung zugelassen: wenn die Aufgabewährung ungleich der Kontowährung ist, muss die Vergütungswährung der Aufgabewährung entsprechen");
                }
                _isoCodeVerguetungswaehrung = value;
            }
        }

        public EzagHeader.TransaktionsArt TransaktionsArt
        {
            get; private set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public virtual void WriteToUzagFile(StreamWriter sw)
        {
            Header.WriteHeaderToUzag(sw);

            try
            {
                //ISO-Code Aufgabewährung
                sw.Write(ISOCodeAufgabewaehrung);

                //Aufgabebetrag
                sw.Write(AufgabetragToDTA);

                //Reserve
                sw.Write(Utilities.FillBlanks("", 1, " ", true));

                //ISO-Code Vergütungswährung
                sw.Write(ISOCodeVerguetungswaehrung);

                //ISO-Code Land
                sw.Write(ISOCodeLand);
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