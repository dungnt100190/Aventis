using System;
using System.IO;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Summary description for Ezag28.
    /// 
    /// </summary>
    public class Ezag28 : EzagRecord
    {
        #region Fields

        #region Private Fields

        private string _absenderReferenz;
        private string _eSrKundenNummer;
        private string _pruefzifferModulo11;
        private string _referenzNummer;

        #endregion

        #endregion

        #region Constructors

        public Ezag28(
            decimal aufgabebetragParam,
            string pruefzifferModullo11Param,
            string esrKundenNummerParam,
            string referenznummerParam,
            string absenderReferenzParam)
            : base(aufgabebetragParam, EzagHeader.TransaktionsArt.Bsr28)
        {
            PruefzifferModulo11 = pruefzifferModullo11Param;
            ESRKundenNummer = esrKundenNummerParam;
            ReferenzNummer = referenznummerParam;
            AbsenderReferenz = absenderReferenzParam;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Liest oder setzt die Absender Referenz.
        /// </summary>
        /// <value>The absender referenz.</value>
        public string AbsenderReferenz
        {
            get { return _absenderReferenz; }
            set
            {
                if (value.Length > 35)
                {
                    _absenderReferenz = value.Substring(0, 35);
                    ErrorMessage +=
                        KissMsg.GetMLMessage(
                            "Ezag28", "AbsenderReferenzMax35", "Die AbsenderReferenz wurde gekürzt, sie darf max. 35 Zeichen lang sein") +
                        Environment.NewLine;
                }
                else
                {
                    _absenderReferenz = value;
                }
            }
        }

        /// <summary>
        /// Liest oder setzt die ESR Kundennummer.
        /// </summary>
        /// <value>The ESR kunden nummer.</value>
        public string ESRKundenNummer
        {
            // Validierung
            get { return _eSrKundenNummer; }
            set
            {
                if (!Utils.CheckMod10Nummer(Utils.FormatPCKontoNummerToDBFormat(value)))
                {
                    throw new PaymentFatalException("Invalid ESRKundenNummer");
                }
                _eSrKundenNummer = Utils.FormatPCKontoNummerToDBFormat(value);
            }
        }

        /// <summary>
        /// Konvertiert die Kundennummer ins DTA Format.
        /// </summary>
        /// <value>The ESR kunden nummer to DTA.</value>
        public string ESRKundenNummerToDTA
        {
            get
            {
                return _eSrKundenNummer.PadLeft(9, '0');
            }
        }

        public string PruefzifferModulo11
        {
            get { return _pruefzifferModulo11; }
            set
            {
                //TODO: refactor this function
                if (!String.IsNullOrEmpty(value))
                {
                    int temp;
                    try
                    {
                        temp = Convert.ToInt32(value);
                    }
                    catch (Exception ex)
                    {
                        throw new PaymentFatalException("Pruefziffer Nummer muss numerisch sein", ex);
                    }
                    if (temp > 10)
                    {
                        throw new PaymentFatalException("Pruefziffer muss zwischen 1-10 sein");
                    }
                    _pruefzifferModulo11 = value;
                }
                else
                {
                    _pruefzifferModulo11 = String.Empty;
                }
            }
        }

        /// <summary>
        /// Liest oder setzt die Referenznummer.
        /// </summary>
        /// <value>The referenz nummer.</value>
        public string ReferenzNummer
        {
            get { return _referenzNummer; }
            set
            {
                value = value.Replace(" ", "");

                if (ESRKundenNummer.Length == 5)
                {
                    if (value.Length != 15)
                    {
                        throw new PaymentFatalException("ESR Reference Nummer muss 15 Characters sein");
                    }
                    _referenzNummer = value;
                }

                else
                {
                    if (value.Length != 16 && value.Length != 27)
                    {
                        throw new PaymentFatalException("ESR Reference Nummer muss 16 oder 27 Characters sein");
                    }
                    if (!Utils.CheckMod10Nummer(value))
                    {
                        throw new PaymentFatalException("Invalid ESR Reference Nummer");
                    }
                    _referenzNummer = value;
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void WriteToUzagFile(StreamWriter sw)
        {
            base.WriteToUzagFile(sw);

            try
            {
                // --- pruefziffer
                //sw.Write(Utilities.FillBlanks(this.pruefzifferModulo11, 2, " ", true));
                sw.Write(_pruefzifferModulo11.PadRight(2));

                // --- ESRKundenNummer
                sw.Write(ESRKundenNummerToDTA);

                //sw.Write(Utilities.FillBlanks(this.referenzNummer, 27, "0", false));
                sw.Write(_referenzNummer.PadLeft(27, '0'));

                //sw.Write(Utilities.FillBlanks(this.absenderReferenz, 35, " ", true));
                sw.Write(_absenderReferenz.PadRight(35));

                // --- reserver
                //sw.Write(Utilities.FillBlanks("", 555, " ", true));
                sw.Write(new String(' ', 555)); //Utilities.FillBlanks("", 555, " ", true));
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