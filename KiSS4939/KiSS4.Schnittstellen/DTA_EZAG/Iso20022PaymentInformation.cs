using System;
using System.Text;
using KiSS4.Common;
using StringExtensions = Kiss.Infrastructure.Utils.StringExtensions;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    public class Iso20022PaymentInformation
    {
        private string _referenzNummer;

        /// <summary>
        /// Erstellt eine neue Instanz von Iso20022PaymentInformation.
        /// </summary>
        /// <param name="einzahlungsscheinCode">Definiert die Art der Zahlung.</param>
        /// <param name="beguenstigtIban">Die IBAN des Begünstigten.</param>
        /// <param name="beguenstigtBankBcn">Die ClearingNr der Bank des Begünstigten.</param>
        /// <param name="betrag">Der Zahlungsbetrag.</param>
        /// <param name="beguenstigtName">Der Name des Begünstigten.</param>
        /// <param name="beguenstigtStrasse">Die Strasse des Begünstigten.</param>
        /// <param name="beguenstigtHausNr"></param>
        /// <param name="beguenstigtPlz">Die PLZ des Begünstigten.</param>
        /// <param name="beguenstigtOrt">Der Ort des Begünstigten.</param>
        /// <param name="mitteilungZeile1">Die Mitteilungszeile Nr. 1.</param>
        /// <param name="mitteilungZeile2">Die Mitteilungszeile Nr. 2.</param>
        /// <param name="mitteilungZeile3">Die Mitteilungszeile Nr. 3.</param>
        /// <param name="mitteilungZeile4">Die Mitteilungszeile Nr. 4.</param>
        /// <param name="pcKontoNr">Die PC Konto Nummer.</param>
        /// <param name="bankKontoNr">Die Bank Konto Nummer.</param>
        /// <param name="buchungID">Die BuchungsID.</param>
        /// <param name="referenzNummer">Die ReferenzNummer.</param>
        /// <param name="dtaKontoNr">Die KontoNr des DTA Zugangs.</param>
        /// <param name="valutaDatum">Das ValutaDatum.</param>
        public Iso20022PaymentInformation(Einzahlungsschein einzahlungsscheinCode, object beguenstigtIban, object beguenstigtBankBcn, object beguenstigtBankName, object betrag, object beguenstigtName, object beguenstigtStrasse, object beguenstigtHausNr, object beguenstigtPlz, object beguenstigtOrt, object mitteilungZeile1, object mitteilungZeile2, object mitteilungZeile3, object mitteilungZeile4, object pcKontoNr, object bankKontoNr, object buchungID, object referenzNummer, object dtaKontoNr, object valutaDatum)
        {
            EinzahlungsscheinCode = einzahlungsscheinCode;
            SetValues(beguenstigtIban, beguenstigtBankBcn, beguenstigtBankName, betrag, beguenstigtName, beguenstigtStrasse, beguenstigtHausNr, beguenstigtPlz, beguenstigtOrt, mitteilungZeile1, mitteilungZeile2, mitteilungZeile3, mitteilungZeile4, pcKontoNr, bankKontoNr, buchungID, referenzNummer, dtaKontoNr, valutaDatum);
        }

        /// <summary>
        /// Erstellt eine neue Instanz von Iso20022PaymentInformation.
        /// </summary>
        /// <param name="zahlungsArtCode">Definiert die Art der Zahlung.</param>
        /// <param name="beguenstigtIban">Die IBAN des Begünstigten.</param>
        /// <param name="beguenstigtBankBcn">Die ClearingNr der Bank des Begünstigten.</param>
        /// <param name="beguenstigtBankName"></param>
        /// <param name="betrag">Der Zahlungsbetrag.</param>
        /// <param name="beguenstigtName">Der Name des Begünstigten.</param>
        /// <param name="beguenstigtStrasse">Die Strasse des Begünstigten.</param>
        /// <param name="beguenstigtHausNr">Die HausNr des Begünstigten.</param>
        /// <param name="beguenstigtPlz">Die PLZ des Begünstigten.</param>
        /// <param name="beguenstigtOrt">Der Ort des Begünstigten.</param>
        /// <param name="mitteilungZeile1">Die Mitteilungszeile Nr. 1.</param>
        /// <param name="mitteilungZeile2">Die Mitteilungszeile Nr. 2.</param>
        /// <param name="mitteilungZeile3">Die Mitteilungszeile Nr. 3.</param>
        /// <param name="mitteilungZeile4">Die Mitteilungszeile Nr. 4.</param>
        /// <param name="pcKontoNr">Die PC Konto Nummer.</param>
        /// <param name="bankKontoNr">Die Bank Konto Nummer.</param>
        /// <param name="buchungID">Die BuchungsID.</param>
        /// <param name="referenzNummer">Die ReferenzNummer.</param>
        /// <param name="dtaKontoNr">Die KontoNr des DTA Zugangs.</param>
        /// <param name="valutaDatum">Das ValutaDatum.</param>
        public Iso20022PaymentInformation(ZahlungsArt zahlungsArtCode, object beguenstigtIban, object beguenstigtBankBcn, object beguenstigtBankName, object betrag, object beguenstigtName, object beguenstigtStrasse, object beguenstigtHausNr, object beguenstigtPlz, object beguenstigtOrt, object mitteilungZeile1, object mitteilungZeile2, object mitteilungZeile3, object mitteilungZeile4, object pcKontoNr, object bankKontoNr, object buchungID, object referenzNummer, object dtaKontoNr, object valutaDatum)
        {
            ZahlungsArtCode = zahlungsArtCode;
            SetValues(beguenstigtIban, beguenstigtBankBcn, beguenstigtBankName, betrag, beguenstigtName, beguenstigtStrasse, beguenstigtHausNr, beguenstigtPlz, beguenstigtOrt, mitteilungZeile1, mitteilungZeile2, mitteilungZeile3, mitteilungZeile4, pcKontoNr, bankKontoNr, buchungID, referenzNummer, dtaKontoNr, valutaDatum);
        }

        public string BankKontoNr
        {
            get;
            private set;
        }

        public string BeguenstigtBankBCN
        {
            get;
            private set;
        }

        public string BeguenstigtBankName
        {
            get;
            private set;
        }

        public string BeguenstigtHausNr
        {
            get;
            private set;
        }

        public string BeguenstigtIban
        {
            get;
            private set;
        }

        public string BeguenstigtName
        {
            get;
            private set;
        }

        public string BeguenstigtOrt
        {
            get;
            private set;
        }

        public string BeguenstigtPLZ
        {
            get;
            private set;
        }

        public string BeguenstigtStrasse
        {
            get;
            private set;
        }

        public decimal Betrag
        {
            get;
            private set;
        }

        public string BuchungID
        {
            get;
            private set;
        }

        public string DtaKontoNr
        {
            get;
            private set;
        }

        public Einzahlungsschein EinzahlungsscheinCode
        {
            get;
            private set;
        }

        public string EndbeguenstigterKonto
        {
            get;
            private set;
        }

        public string HabenKtoNr
        {
            get;
            private set;
        }

        public string Mitteilung1_3
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(MitteilungZeile1))
                {
                    sb.Append(MitteilungZeile1);
                    sb.Append(' ');
                }

                if (!string.IsNullOrEmpty(MitteilungZeile2))
                {
                    sb.Append(MitteilungZeile2);
                    sb.Append(' ');
                }

                if (!string.IsNullOrEmpty(MitteilungZeile3))
                {
                    sb.Append(MitteilungZeile3);
                }

                var result = sb.ToString().Trim();

                result = Utilities.EnsureLatinCharacterSet(result, 140);

                return !string.IsNullOrEmpty(result) ? result : null;
            }
        }

        public string Mitteilung1_4
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(MitteilungZeile1))
                {
                    sb.Append(MitteilungZeile1);
                    sb.Append(' ');
                }

                if (!string.IsNullOrEmpty(MitteilungZeile2))
                {
                    sb.Append(MitteilungZeile2);
                    sb.Append(' ');
                }

                if (!string.IsNullOrEmpty(MitteilungZeile3))
                {
                    sb.Append(MitteilungZeile3);
                    sb.Append(' ');
                }

                if (!string.IsNullOrEmpty(MitteilungZeile4))
                {
                    sb.Append(MitteilungZeile4);
                }

                var result = sb.ToString().Trim();

                result = Utilities.EnsureLatinCharacterSet(result, 140);

                return !string.IsNullOrEmpty(result) ? result : null;
            }
        }

        public string MitteilungZeile1
        {
            get;
            private set;
        }

        public string MitteilungZeile2
        {
            get;
            private set;
        }

        public string MitteilungZeile3
        {
            get;
            private set;
        }

        public string MitteilungZeile4
        {
            get;
            private set;
        }

        public string PCKontoNr
        {
            get;
            private set;
        }

        public string ReferenzNummer
        {
            get { return _referenzNummer; }
            private set
            {
                if (value == null)
                {
                    _referenzNummer = null;
                    return;
                }

                _referenzNummer = value.Trim().PadLeft(27, '0');
            }
        }

        public string SollKtoNr
        {
            get;
            private set;
        }

        public DateTime ValutaDatum
        {
            get;
            private set;
        }

        public ZahlungsArt ZahlungsArtCode
        {
            get;
            private set;
        }

        private void SetValues(object beguenstigtIban, object beguenstigtBankBcn, object beguenstigtBankName, object betrag, object beguenstigtName, object beguenstigtStrasse, object beguenstigtHausNr, object beguenstigtPlz, object beguenstigtOrt, object mitteilungZeile1, object mitteilungZeile2, object mitteilungZeile3, object mitteilungZeile4, object pcKontoNr, object bankKontoNr, object buchungID, object referenzNummer, object dtaKontoNr, object valutaDatum)
        {
            BeguenstigtIban = StringExtensions.RemoveWhitespaces(Utils.ConvertToString(beguenstigtIban, null));
            BeguenstigtBankBCN = Utils.ConvertToString(beguenstigtBankBcn, null);
            BeguenstigtBankName = Utilities.EnsureLatinCharacterSet(Utils.ConvertToString(beguenstigtBankName, null), 70);
            Betrag = Math.Round(Utils.ConvertToDecimal(betrag), 2); //damit Betrag mit 2 und nicht mit 4 Kommastellen serialisiert wird
            BeguenstigtName = Utilities.EnsureLatinCharacterSet(StringExtensions.RemoveNewLines(Utils.ConvertToString(beguenstigtName)), 70);
            BeguenstigtStrasse = Utilities.EnsureLatinCharacterSet(Utils.ConvertToString(beguenstigtStrasse, null), 70);
            BeguenstigtHausNr = Utilities.EnsureLatinCharacterSet(Utils.ConvertToString(beguenstigtHausNr, null), 16);
            BeguenstigtPLZ = Utilities.EnsureLatinCharacterSet(Utils.ConvertToString(beguenstigtPlz, null), 16);
            BeguenstigtOrt = Utilities.EnsureLatinCharacterSet(Utils.ConvertToString(beguenstigtOrt, null), 35);
            MitteilungZeile1 = Utils.ConvertToString(mitteilungZeile1, null);
            MitteilungZeile2 = Utils.ConvertToString(mitteilungZeile2, null);
            MitteilungZeile3 = Utils.ConvertToString(mitteilungZeile3, null);
            MitteilungZeile4 = Utils.ConvertToString(mitteilungZeile4, null);

            var pcKontoNrTemp = Utils.ConvertToString(pcKontoNr, null);
            if (pcKontoNrTemp != null && !pcKontoNrTemp.Contains("-"))
            {
                pcKontoNrTemp = Utils.FromTnToPc(pcKontoNrTemp);
            }
            PCKontoNr = pcKontoNrTemp;
            BankKontoNr = Utils.ConvertToString(bankKontoNr, null);
            BuchungID = Convert.ToString(buchungID);
            ReferenzNummer = Utilities.EnsureLatinCharacterSet(Utils.ConvertToString(referenzNummer, null), 35);

            EndbeguenstigterKonto = !string.IsNullOrEmpty(this.BeguenstigtIban) ? this.BeguenstigtIban : this.BankKontoNr;

            DtaKontoNr = StringExtensions.RemoveWhitespaces(Utils.ConvertToString(dtaKontoNr));
            ValutaDatum = Utils.ConvertToDateTime(valutaDatum);

            if (BeguenstigtStrasse != null && BeguenstigtStrasse.Equals(string.Empty))
            {
                BeguenstigtStrasse = null;
            }
        }
    }
}