using System;
using System.Globalization;

using KiSS4.DB;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    #region Enumerations

    /// <summary>
    /// Enumeration for transaction types.
    /// </summary>
    public enum TransaktionsArt
    {
        /// <summary>
        /// ESR-Zahlungen (ESR = Oranger Einzahlungsschein mit Referenznummer).
        /// </summary>
        GT826,

        /// <summary>
        /// CHF-Zahlungen im Inland (Bank-/Postkontozahlungen und Postmandate)
        /// (Postmandate werden nicht von allen Banken akzeptiert)
        /// siehe DTA - Standards und Formate Kapitel 2.2.4)
        /// </summary>
        GT827Post,

        /// <summary>
        /// CHF-Zahlungen im Inland (Bank-/Postkontozahlungen und Postmandate)
        /// (Postmandate werden nicht von allen Banken akzeptiert)
        /// siehe DTA - Standards und Formate Kapitel 2.2.4)
        /// </summary>
        GT827Bank,

        /// <summary>
        /// Zahlungen an Finanzinstitute im Ausland in CHF und Fremdwährungen (FW)
        /// sowie Fremdwährungs-Zahlungen im Inland.
        /// </summary>
        GT830,

        /// <summary>
        /// Bankchecks in CHF und Fremdwährungen (FW) (Diese Transaktionsart wird
        /// nicht von allen Banken akzeptiert)
        /// siehe DTA - Standards und Formate Kapitel 2.2.4)
        /// </summary>
        GT832,

        /// <summary>
        /// Totalrecord.
        /// </summary>
        GT890
    }

    #endregion

    /// <summary>
    /// Summary description for Header.
    /// </summary>
    public class DtaHeader
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DtaHeader"/> class.
        /// </summary>
        /// <param name="bankClearingNummerBeguenstigten">The bank clearing nummer beguenstigten.</param>
        public DtaHeader(
            String bankClearingNummerBeguenstigten)
        {
            EingabeSequenznummer = 1;

            // AusgabeSequenzNummer
            AusgabeSequenzNummer = "00000";

            // Verarbeitungstag
            TimeSpan timeSpan = new TimeSpan(60, 0, 0, 0);

            if (Transaktionsart == TransaktionsArt.GT827Post ||
                Transaktionsart == TransaktionsArt.GT827Bank ||
                Transaktionsart == TransaktionsArt.GT826)
            {
                if ((VerarbeitungsTag - DateTime.Now) > timeSpan)
                    throw new Exception("max. = 60 Kalendertage als Einlesedatum im Rechnung Zentrum");
                else
                    VerarbeitungsTag = VerarbeitungsTag;
            }
            else
                VerarbeitungsTag = DateTime.MinValue;

            // TODO : Check Transaktionsart
            /*  Trasaktionsart ist nicht korrekt gesetzt!
                 muss in der neuen Version korrekt gelöst werden.

                        //BankClearingNummerBeguenstigten
                        if(this.transaktionsart == TransaktionsArt.GT827Bank ||
                            this.transaktionsart == TransaktionsArt.GT826)
                        {
                            if(BankClearingNummerBeguenstigten == "")
                                throw new Exception("Die Clearingnummer der Bank darf nicht leer bleiben für CHF-Bankzahlungen im Inland") ;
                            else
                                this.bankClearingNummerBeguenstigten = BankClearingNummerBeguenstigten;
                        }
                        else
                        {
                            if(BankClearingNummerBeguenstigten != "")
                                    throw new Exception("Die Clearingnummer der Bank muss leer bleiben:" + this.transaktionsart.ToString()) ;
                            else
                                this.bankClearingNummerBeguenstigten = "" ;
                        }
            */

            BankClearingNummerBeguenstigten = bankClearingNummerBeguenstigten;

            // ErstellungsDatum
            ErstellungsDatum = DateTime.Now;

            //BankClearingNummerAuftragsgebber
            if (Transaktionsart != TransaktionsArt.GT890)
            {
                if (BankClearingNummerAuftragsgeber == "")
                    throw new Exception("BankClearingNummer von dem Auftragsgebber muss eingegeben sein");
                else
                    BankClearingNummerAuftragsgeber = BankClearingNummerAuftragsgeber;
            }

            //ZahlungsArt
            //TODO : Check Keine Lohnzahlungen aus dem Kiss deshalb auf "0" gesetzt
            ZahlungsArt = false;

            //BearbeitungsFlag
            BearbeitungsFlag = false;

            //DatenfileAbsenderIdentifikation
            DatenfileAbsenderIdentifikation = DatenfileAbsenderIdentifikation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DtaHeader"/> class.
        /// </summary>
        /// <param name="transaktionsArt">The transaktions art.</param>
        /// <param name="bankClearingNummerBeguenstigten">The bank clearing nummer beguenstigten.</param>
        public DtaHeader(
            TransaktionsArt transaktionsArt,
            String bankClearingNummerBeguenstigten)
        {
            EingabeSequenznummer = 1;
            // AusgabeSequenzNummer
            AusgabeSequenzNummer = "00000";

            Transaktionsart = transaktionsArt;

            //BankClearingNummerBeguenstigten
            if (Transaktionsart == TransaktionsArt.GT827Bank ||
                Transaktionsart == TransaktionsArt.GT826)
            {
                if (bankClearingNummerBeguenstigten == "")
                    throw new Exception("Die Clearingnummer der Bank darf nicht leer bleiben für CHF-Bankzahlungen im Inland");
                else
                    BankClearingNummerBeguenstigten = bankClearingNummerBeguenstigten;
            }
            else
            {
                if (bankClearingNummerBeguenstigten != "")
                    throw new Exception(KissMsg.GetMLMessage("DataHeader", "ClearingNumberNotEmpty", "Die Clearingnummer der Bank muss leer bleiben: {0}", KissMsgCode.MsgError, Transaktionsart.ToString()));
                else
                    BankClearingNummerBeguenstigten = "";
            }
            DatenfileAbsenderIdentifikation = DatenfileAbsenderIdentifikation;

            //ZahlungsArt
            ZahlungsArt = false;

            //BearbeitungsFlag
            BearbeitungsFlag = false;

            // ErstellungsDatum
            ErstellungsDatum = DateTime.Now;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Liest die Ausgabesequenznummer.
        /// </summary>
        /// <value>The ausgabe sequenz nummer.</value>
        public string AusgabeSequenzNummer
        {
            get; private set;
        }

        /// <summary>
        /// Liest die BankClearingNummer des Auftraggebers.
        /// </summary>
        public string BankClearingNummerAuftragsgeber
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the bank clearing nummer beguenstigten.
        /// </summary>
        /// <value>The bank clearing nummer beguenstigten.</value>
        public string BankClearingNummerBeguenstigten
        {
            get; set;
        }

        /// <summary>
        /// Liest die BankClearingNummer des Begünstigten formatiert für DTA.
        /// </summary>
        public string BankClearingNummerBeguenstigtenToDTA
        {
            get
            {
                return BankClearingNummerBeguenstigten.ToString(CultureInfo.InvariantCulture).PadRight(12);
            }
        }

        /// <summary>
        /// Liest das Bearbeitungs flag.
        /// </summary>
        public bool BearbeitungsFlag
        {
            get; private set;
        }

        /// <summary>
        /// Liest die Identifikation des Absenders des Datenfiles.
        /// </summary>
        public string DatenfileAbsenderIdentifikation
        {
            get; set;
        }

        /// <summary>
        /// Liest die Eingabesequenznummer.
        /// </summary>
        public int EingabeSequenznummer
        {
            get; set;
        }

        /// <summary>
        /// Liest oder setzt das Erstellungsdatum.
        /// </summary>
        /// <value>The erstellungs datum.</value>
        public DateTime ErstellungsDatum
        {
            get; set;
        }

        /// <summary>
        /// Liest die Transaktionsart.
        /// </summary>
        public TransaktionsArt Transaktionsart
        {
            get; private set;
        }

        /// <summary>
        /// Liest oder setzt den Verarbeitungstermin.
        /// </summary>
        /// <value>The verarbeitungs tag.</value>
        public DateTime VerarbeitungsTag
        {
            get; set;
        }

        /// <summary>
        /// Liest den Verarbeitungstag formatiert für DTA.
        /// </summary>
        public string VerarbeitungsTagToDTA
        {
            get { return Utilities.DateTimeToDTAString(VerarbeitungsTag); }
        }

        /// <summary>
        /// Liest die ZahlungsArt.
        /// </summary>
        public bool ZahlungsArt
        {
            get; set;
        }

        #endregion
    }
}