using System;
using KiSS4.Common;
using StringExtensions = Kiss.Infrastructure.Utils.StringExtensions;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    public class DtaPaymentInformation : PaymentInformation
    {
        #region Constructors

        /// <summary>
        /// Erstellt eine neue Instanz von DtaPaymentInformation.
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
        /// <param name="buchungID">Die BuchungsID.</param>
        /// <param name="sollKtoNr">Die SollKtoNr.</param>
        /// <param name="habenKtoNr">Die HabenKtoNr.</param>
        /// <param name="referenzNummer">Die ReferenzNummer.</param>
        /// <param name="dtaKontoNr">Die KontoNr des DTA Zugangs.</param>
        /// <param name="valutaDatum">Das ValutaDatum.</param>
        public DtaPaymentInformation(Einzahlungsschein einzahlungsscheinCode, object beguenstigtIban, object beguenstigtBankBcn, object betrag, object beguenstigtName, object beguenstigtStrasse, object beguenstigtHausNr, object beguenstigtPlz, object beguenstigtOrt, object mitteilungZeile1, object mitteilungZeile2, object mitteilungZeile3, object mitteilungZeile4, object pcKontoNr, object bankKontoNr, object buchungID, object sollKtoNr, object habenKtoNr, object referenzNummer, object dtaKontoNr, object valutaDatum)
            : base(einzahlungsscheinCode, beguenstigtIban, beguenstigtBankBcn, betrag, beguenstigtName, beguenstigtStrasse, beguenstigtHausNr, beguenstigtPlz, beguenstigtOrt, mitteilungZeile1, mitteilungZeile2, mitteilungZeile3, mitteilungZeile4, pcKontoNr, bankKontoNr, buchungID, sollKtoNr, habenKtoNr, referenzNummer)
        {
            SetValues(dtaKontoNr, valutaDatum);
        }

        /// <summary>
        /// Erstellt eine neue Instanz von DtaPaymentInformation.
        /// </summary>
        /// <param name="zahlungsArtCode">Definiert die Art der Zahlung.</param>
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
        /// <param name="sollKtoNr">Die SollKtoNr.</param>
        /// <param name="habenKtoNr">Die HabenKtoNr.</param>
        /// <param name="referenzNummer">Die ReferenzNummer.</param>
        /// <param name="dtaKontoNr">Die KontoNr des DTA Zugangs.</param>
        /// <param name="valutaDatum">Das ValutaDatum.</param>
        public DtaPaymentInformation(ZahlungsArt zahlungsArtCode, object beguenstigtIban, object beguenstigtBankBcn, object betrag, object beguenstigtName, object beguenstigtStrasse, object beguenstigtHausNr, object beguenstigtPlz, object beguenstigtOrt, object mitteilungZeile1, object mitteilungZeile2, object mitteilungZeile3, object mitteilungZeile4, object pcKontoNr, object bankKontoNr, object buchungID, object sollKtoNr, object habenKtoNr, object referenzNummer, object dtaKontoNr, object valutaDatum)
            : base(zahlungsArtCode, beguenstigtIban, beguenstigtBankBcn, betrag, beguenstigtName, beguenstigtStrasse, beguenstigtHausNr, beguenstigtPlz, beguenstigtOrt, mitteilungZeile1, mitteilungZeile2, mitteilungZeile3, mitteilungZeile4, pcKontoNr, bankKontoNr, buchungID, sollKtoNr, habenKtoNr, referenzNummer)
        {
            SetValues(dtaKontoNr, valutaDatum);
        }

        #endregion

        #region Properties

        public string DtaKontoNr
        {
            get;
            private set;
        }

        public DateTime ValutaDatum
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        #region Private Methods

        private void SetValues(object dtaKontoNr, object valutaDatum)
        {
            DtaKontoNr = StringExtensions.RemoveWhitespaces(Utils.ConvertToString(dtaKontoNr));
            ValutaDatum = Utils.ConvertToDateTime(valutaDatum);
        }

        #endregion

        #endregion
    }
}