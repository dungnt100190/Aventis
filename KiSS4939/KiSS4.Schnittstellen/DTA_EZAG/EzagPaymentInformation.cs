using KiSS4.Common;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    public class EzagPaymentInformation : PaymentInformation
    {
        #region Constructors

        /// <summary>
        /// Erstellt eine neue Instanz von DtaPaymentInformation.
        /// </summary>
        /// <param name="einzahlungsscheinCode">Definiert die Art der Zahlung.</param>
        /// <param name="beguenstigtIban">Die IBAN des Begünstigten.</param>
        /// <param name="beguenstigtBankBcn">Die ClearingNr der Bank des Begünstigten.</param>
        /// <param name="bankName">Der Name der Bank des Begünstigten.</param>
        /// <param name="bankStrasse">Die Strasse der Bank des Begünstigten.</param>
        /// <param name="bankPlz">Die PLZ der Bank des Begünstigten.</param>
        /// <param name="bankOrt">Der Ort der Bank des Begünstigten.</param>
        /// <param name="betrag">Der Zahlungsbetrag.</param>
        /// <param name="beguenstigtName">Der Name des Begünstigten.</param>
        /// <param name="beguenstigtName2">Der Name2 des Begünstigten.</param>
        /// <param name="beguenstigtZusatz">Der Zusatz des Begünstigten.</param>
        /// <param name="beguenstigtStrasse">Die Strasse des Begünstigten.</param>
        /// <param name="beguenstigtHausNr">Die HausNr des Begünstigten.</param>
        /// <param name="beguenstigtPlz">Die PLZ des Begünstigten.</param>
        /// <param name="beguenstigtOrt">Der Ort des Begünstigten.</param>
        /// <param name="mitteilungZeile1">Die Mitteilungszeile1.</param>
        /// <param name="mitteilungZeile2">Die Mitteilungszeile2.</param>
        /// <param name="mitteilungZeile3">Die Mitteilungszeile3.</param>
        /// <param name="mitteilungZeile4">Die Mitteilungszeile4.</param>
        /// <param name="pcKontoNr">Die PC Konto Nummer.</param>
        /// <param name="bankKontoNr">Die Bank Konto Nummer.</param>
        /// <param name="buchungID">Die BuchungsID.</param>
        /// <param name="sollKtoNr">Die SollKtoNr.</param>
        /// <param name="habenKtoNr">Die HabenKtoNr.</param>
        /// <param name="referenzNummer">Die ReferenzNummer.</param>
        public EzagPaymentInformation(Einzahlungsschein einzahlungsscheinCode, object beguenstigtIban, object beguenstigtBankBcn, object bankName, object bankStrasse,
            object bankPlz, object bankOrt, object betrag, object beguenstigtName, object beguenstigtName2, object beguenstigtZusatz,
            object beguenstigtStrasse, object beguenstigtHausNr, object beguenstigtPlz, object beguenstigtOrt, object mitteilungZeile1, object mitteilungZeile2,
            object mitteilungZeile3, object mitteilungZeile4, object pcKontoNr, object bankKontoNr, object buchungID, object sollKtoNr,
            object habenKtoNr, object referenzNummer)
            : base(einzahlungsscheinCode, beguenstigtIban, beguenstigtBankBcn, betrag, beguenstigtName, beguenstigtStrasse, beguenstigtHausNr, beguenstigtPlz, beguenstigtOrt, mitteilungZeile1, mitteilungZeile2, mitteilungZeile3, mitteilungZeile4, pcKontoNr, bankKontoNr, buchungID, sollKtoNr, habenKtoNr, referenzNummer)
        {
            SetValues(bankName, bankStrasse, bankPlz, bankOrt, beguenstigtName2, beguenstigtZusatz);
        }

        /// <summary>
        /// Erstellt eine neue Instanz von DtaPaymentInformation.
        /// </summary>
        /// <param name="zahlungsArtCode">Definiert die Art der Zahlung.</param>
        /// <param name="beguenstigtIban">Die IBAN des Begünstigten.</param>
        /// <param name="beguenstigtBankBcn">Die ClearingNr der Bank des Begünstigten.</param>
        /// <param name="bankName">Der Name der Bank des Begünstigten.</param>
        /// <param name="bankStrasse">Die Strasse der Bank des Begünstigten.</param>
        /// <param name="bankPlz">Die PLZ der Bank des Begünstigten.</param>
        /// <param name="bankOrt">Der Ort der Bank des Begünstigten.</param>
        /// <param name="betrag">Der Zahlungsbetrag.</param>
        /// <param name="beguenstigtName">Der Name des Begünstigten.</param>
        /// <param name="beguenstigtName2">Der Name2 des Begünstigten.</param>
        /// <param name="beguenstigtZusatz">Der Zusatz des Begünstigten.</param>
        /// <param name="beguenstigtStrasse">Die Strasse des Begünstigten.</param>
        /// <param name="beguenstigtHausNr">Die Hausnr des Begünstigten.</param>
        /// <param name="beguenstigtPlz">Die PLZ des Begünstigten.</param>
        /// <param name="beguenstigtOrt">Der Ort des Begünstigten.</param>
        /// <param name="mitteilungZeile1">Die Mitteilungszeile1.</param>
        /// <param name="mitteilungZeile2">Die Mitteilungszeile2.</param>
        /// <param name="mitteilungZeile3">Die Mitteilungszeile3.</param>
        /// <param name="mitteilungZeile4">Die Mitteilungszeile4.</param>
        /// <param name="pcKontoNr">Die PC Konto Nummer.</param>
        /// <param name="bankKontoNr">Die Bank Konto Nummer.</param>
        /// <param name="buchungID">Die BuchungsID.</param>
        /// <param name="sollKtoNr">Die SollKtoNr.</param>
        /// <param name="habenKtoNr">Die HabenKtoNr.</param>
        /// <param name="referenzNummer">Die ReferenzNummer.</param>
        public EzagPaymentInformation(ZahlungsArt zahlungsArtCode, object beguenstigtIban, object beguenstigtBankBcn, object bankName, object bankStrasse, object bankPlz,
            object bankOrt, object betrag, object beguenstigtName, object beguenstigtName2, object beguenstigtZusatz, object beguenstigtStrasse, object beguenstigtHausNr, object beguenstigtPlz,
            object beguenstigtOrt, object mitteilungZeile1, object mitteilungZeile2, object mitteilungZeile3, object mitteilungZeile4, object pcKontoNr,
            object bankKontoNr, object buchungID, object sollKtoNr, object habenKtoNr, object referenzNummer)
            : base(zahlungsArtCode, beguenstigtIban, beguenstigtBankBcn, betrag, beguenstigtName, beguenstigtStrasse, beguenstigtHausNr, beguenstigtPlz, beguenstigtOrt, mitteilungZeile1, mitteilungZeile2, mitteilungZeile3, mitteilungZeile4, pcKontoNr, bankKontoNr, buchungID, sollKtoNr, habenKtoNr, referenzNummer)
        {
            SetValues(bankName, bankStrasse, bankPlz, bankOrt, beguenstigtName2, beguenstigtZusatz);
        }

        #endregion

        #region Properties

        public string BankName
        {
            get;
            private set;
        }

        public string BankOrt
        {
            get;
            private set;
        }

        public string BankPLZ
        {
            get;
            private set;
        }

        public string BankStrasse
        {
            get;
            private set;
        }

        public string BeguenstigtName2
        {
            get;
            private set;
        }

        public string BeguenstigtZusatz
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        #region Private Methods

        private void SetValues(object bankName, object bankStrasse, object bankPlz, object bankOrt, object beguenstigtName2, object beguenstigtZusatz)
        {
            BankName = Utils.ConvertToString(bankName);
            BankStrasse = Utils.ConvertToString(bankStrasse);
            BankPLZ = Utils.ConvertToString(bankPlz);
            BankOrt = Utils.ConvertToString(bankOrt);

            BeguenstigtName2 = Utils.ConvertToString(beguenstigtName2);
            BeguenstigtZusatz = Utils.ConvertToString(beguenstigtZusatz);
        }

        #endregion

        #endregion
    }
}