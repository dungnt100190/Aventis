using KiSS4.Common;

using Utils = KiSS4.Common.Utils;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Datencontainer für EZAG und DTA Recorderstellung.
    /// </summary>
    public abstract class PaymentInformation
    {
        #region Constructors

        /// <summary>
        /// Erstellt eine neue Instanz von PaymentInformation.
        /// </summary>
        /// <param name="einzahlungsscheinCode">Definiert die Art der Zahlung.</param>
        /// <param name="beguenstigtIban">Die IBAN des Begünstigten.</param>
        /// <param name="beguenstigtBankBcn">Die ClearingNr der Bank des Begünstigten.</param>
        /// <param name="betrag">Der Zahlungsbetrag.</param>
        /// <param name="beguenstigtName">Der Name des Begünstigten.</param>
        /// <param name="beguenstigtStrasse">Die Strasse des Begünstigten.</param>
        /// <param name="beguenstigtPlz">Die PLZ des Begünstigten.</param>
        /// <param name="beguenstigtOrt">Der Ort des Begünstigten.</param>
        /// <param name="mitteilungZeile1">Die Mitteilungszeile Nr. 1.</param>
        /// <param name="mitteilungZeile2">Die Mitteilungszeile Nr. 2.</param>
        /// <param name="mitteilungZeile3">Die Mitteilungszeile Nr. 3.</param>
        /// <param name="mitteilungZeile4">Die Mitteilungszeile Nr. 4.</param>
        /// <param name="pcKontoNr">Die PC Konto Nummer.</param>
        /// <param name="bankKontoNr">Die Bank Konto Nummer.</param>
        /// <param name="kbBuchungID">Die BuchungsID.</param>
        /// <param name="sollKtoNr">Die SollKtoNr.</param>
        /// <param name="habenKtoNr">Die HabenKtoNr.</param>
        /// <param name="referenzNummer">Die ReferenzNummer.</param>
        protected PaymentInformation(Einzahlungsschein einzahlungsscheinCode, object beguenstigtIban, object beguenstigtBankBcn, object betrag, object beguenstigtName, object beguenstigtStrasse, object beguenstigtHausNr, object beguenstigtPlz, object beguenstigtOrt, object mitteilungZeile1, object mitteilungZeile2, object mitteilungZeile3, object mitteilungZeile4, object pcKontoNr, object bankKontoNr, object kbBuchungID, object sollKtoNr, object habenKtoNr, object referenzNummer)
        {
            EinzahlungsscheinCode = einzahlungsscheinCode;
            SetValues(beguenstigtIban, beguenstigtBankBcn, betrag, beguenstigtName, beguenstigtStrasse, beguenstigtHausNr, beguenstigtPlz, beguenstigtOrt, mitteilungZeile1, mitteilungZeile2, mitteilungZeile3, mitteilungZeile4, pcKontoNr, bankKontoNr, kbBuchungID, sollKtoNr, habenKtoNr, referenzNummer);
        }

        /// <summary>
        /// Erstellt eine neue Instanz von PaymentInformation.
        /// </summary>
        /// <param name="zahlungsArtCode">Definiert die Art der Zahlung.</param>
        /// <param name="beguenstigtIban">Die IBAN des Begünstigten.</param>
        /// <param name="beguenstigtBankBcn">Die ClearingNr der Bank des Begünstigten.</param>
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
        /// <param name="sollKtoNr">Die SollKtoNr.</param>
        /// <param name="habenKtoNr">Die HabenKtoNr.</param>
        /// <param name="referenzNummer">Die ReferenzNummer.</param>
        protected PaymentInformation(ZahlungsArt zahlungsArtCode, object beguenstigtIban, object beguenstigtBankBcn, object betrag, object beguenstigtName, object beguenstigtStrasse, object beguenstigtHausNr, object beguenstigtPlz, object beguenstigtOrt, object mitteilungZeile1, object mitteilungZeile2, object mitteilungZeile3, object mitteilungZeile4, object pcKontoNr, object bankKontoNr, object buchungID, object sollKtoNr, object habenKtoNr, object referenzNummer)
        {
            ZahlungsArtCode = zahlungsArtCode;
            SetValues(
                beguenstigtIban,
                beguenstigtBankBcn,
                betrag,
                beguenstigtName,
                beguenstigtStrasse,
                beguenstigtHausNr,
                beguenstigtPlz,
                beguenstigtOrt,
                mitteilungZeile1,
                mitteilungZeile2,
                mitteilungZeile3,
                mitteilungZeile4,
                pcKontoNr,
                bankKontoNr,
                buchungID,
                sollKtoNr,
                habenKtoNr,
                referenzNummer);
        }

        #endregion

        #region Properties

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

        public int BuchungID
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
            get;
            private set;
        }

        public string SollKtoNr
        {
            get;
            private set;
        }

        public ZahlungsArt ZahlungsArtCode
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        #region Private Methods

        private void SetValues(object beguenstigtIban, object beguenstigtBankBcn, object betrag, object beguenstigtName, object beguenstigtStrasse, object beguenstigtHausNr, object beguenstigtPlz, object beguenstigtOrt, object mitteilungZeile1, object mitteilungZeile2, object mitteilungZeile3, object mitteilungZeile4, object pcKontoNr, object bankKontoNr, object buchungID, object sollKtoNr, object habenKtoNr, object referenzNummer)
        {
            BeguenstigtIban = Utils.ConvertToString(beguenstigtIban);
            BeguenstigtBankBCN = Utils.ConvertToString(beguenstigtBankBcn);
            Betrag = Utils.ConvertToDecimal(betrag);
            BeguenstigtName = Utils.ConvertToString(beguenstigtName);
            BeguenstigtStrasse = Utils.ConvertToString(beguenstigtStrasse);
            BeguenstigtHausNr = Utils.ConvertToString(beguenstigtHausNr);
            BeguenstigtPLZ = Utils.ConvertToString(beguenstigtPlz);
            BeguenstigtOrt = Utils.ConvertToString(beguenstigtOrt);
            MitteilungZeile1 = Utils.ConvertToString(mitteilungZeile1);
            MitteilungZeile2 = Utils.ConvertToString(mitteilungZeile2);
            MitteilungZeile3 = Utils.ConvertToString(mitteilungZeile3);
            MitteilungZeile4 = Utils.ConvertToString(mitteilungZeile4);
            PCKontoNr = Utils.ConvertToString(pcKontoNr);
            BankKontoNr = Utils.ConvertToString(bankKontoNr);
            BuchungID = Utils.ConvertToInt(buchungID);
            SollKtoNr = Utils.ConvertToString(sollKtoNr);
            HabenKtoNr = Utils.ConvertToString(habenKtoNr);
            ReferenzNummer = Utils.ConvertToString(referenzNummer);

            EndbeguenstigterKonto = !string.IsNullOrEmpty(this.BeguenstigtIban) ? this.BeguenstigtIban : this.BankKontoNr;
        }

        #endregion

        #endregion
    }
}