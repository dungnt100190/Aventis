using System;

using KiSS4.Common;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Provides simple means to create appropriate DTARecords.
    /// </summary>
    public static class DTARecordFactory
    {
        #region Methods

        #region Public Static Methods

        public static DtaRecord CreateDTARecord(SozialDienst sozialDienst, DtaPaymentInformation paymentInformation, BuchhaltungsTyp buchhaltungstyp)
        {
            switch (buchhaltungstyp)
            {
                case BuchhaltungsTyp.Klientenbuchhaltung:
                    return CreateDTARecordForKlientenbuchhaltung(sozialDienst, paymentInformation);

                case BuchhaltungsTyp.Mandatsbuchhaltung:
                    return CreateDTARecordForMandatbuchhaltung(sozialDienst, paymentInformation);

                default:
                    return null;
            }
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Creates the DTARecord826.
        /// </summary>
        /// <param name="sozialDienst">The sozial dienst.</param>
        /// <param name="paymentInformation">The payment informtion.</param>
        /// <returns></returns>
        private static DtaRecord826 CreateDTARecord826(SozialDienst sozialDienst, DtaPaymentInformation paymentInformation)
        {
            var record = new DtaRecord826(
                paymentInformation.DtaKontoNr,                                              //[QRY_COL_DTA_KONTO_NR]),
                paymentInformation.Betrag,                                                  //[QRY_COL_BETRAG]),
                sozialDienst.Name.PadRight(40).Substring(0, 20),
                sozialDienst.Name.PadRight(40).Substring(20, 20),
                sozialDienst.Adresse,
                sozialDienst.PLZ + " " + sozialDienst.Ort,
                paymentInformation.PCKontoNr,                                               //[QRY_COL_PC_KONTO_NR]),
                Utilities.RemoveNewLines(paymentInformation.BeguenstigtName),               //[QRY_COL_BEGUENSTIGT_NAME])),
                "",
                paymentInformation.BeguenstigtStrasse,                                      //[QRY_COL_BEGUENSTIGT_STRASSE]),
                paymentInformation.BeguenstigtPLZ + " " + paymentInformation.BeguenstigtOrt,//[QRY_COL_BEGUENSTIGT_PLZ] + " " + [QRY_COL_BEGUENSTIGT_ORT]
                paymentInformation.ReferenzNummer,                                          //[QRY_COL_REFERENZ_NR]),
                paymentInformation.ValutaDatum);                                            //[QRY_COL_VALUTA_DATUM]));
            return record;
        }

        /// <summary>
        /// Creates the DtaRecord827.
        /// </summary>
        /// <param name="sozialDienst">The sozial dienst.</param>
        /// <param name="paymentInformation">The row.</param>
        /// <param name="isBank">Indicates whether this record is for a bank account.</param>
        /// <returns></returns>
        private static DtaRecord827 CreateDtaRecord827(SozialDienst sozialDienst, DtaPaymentInformation paymentInformation, Boolean isBank)
        {
            string kontoNr = isBank ? paymentInformation.BankKontoNr : paymentInformation.PCKontoNr; //QRY_COL_BANK_KONTO_NR : QRY_COL_PC_KONTO_NR;

            var record = new DtaRecord827(
                paymentInformation.BeguenstigtBankBCN,                                 //[QRY_COL_BANK_BCN]),
                paymentInformation.DtaKontoNr,                              //[QRY_COL_DTA_KONTO_NR]),
                paymentInformation.Betrag,                                  //[QRY_COL_BETRAG]),
                sozialDienst.Name.PadRight(48).Substring(0, 24),
                sozialDienst.Name.PadRight(48).Substring(24, 24),
                sozialDienst.Adresse,
                sozialDienst.PLZ + " " + sozialDienst.Ort,

                // --- this one is different for PC and Bank
                kontoNr,

                Utilities.RemoveNewLines(paymentInformation.BeguenstigtName),//[QRY_COL_BEGUENSTIGT_NAME])),
                "",
                paymentInformation.BeguenstigtStrasse,                       //[QRY_COL_BEGUENSTIGT_STRASSE]),
                paymentInformation.BeguenstigtPLZ + " " + paymentInformation.BeguenstigtOrt, //[QRY_COL_BEGUENSTIGT_PLZ]) + " " + [QRY_COL_BEGUENSTIGT_ORT]
                paymentInformation.MitteilungZeile1,                         //[QRY_COL_MITTELIUNG_ZEILE1]),
                paymentInformation.MitteilungZeile2,                         //[QRY_COL_MITTELIUNG_ZEILE2]),
                paymentInformation.MitteilungZeile3,                         //[QRY_COL_MITTELIUNG_ZEILE3]),
                paymentInformation.MitteilungZeile4,                         //[QRY_COL_MITTELIUNG_ZEILE4]),
                paymentInformation.ValutaDatum);                             //[QRY_COL_VALUTA_DATUM]));
            return record;
        }

        private static DtaRecord836 CreateDtaRecord836(SozialDienst sozialDienst, DtaPaymentInformation paymentInformation)
        {
            var record836 = new DtaRecord836(
                paymentInformation.BeguenstigtBankBCN,                                                 //[QRY_COL_BANK_BCN]),
                paymentInformation.DtaKontoNr,                                              //[QRY_COL_DTA_KONTO_NR]),
                paymentInformation.Betrag,                                                  //[QRY_COL_BETRAG]),
                sozialDienst.Name.PadRight(48).Substring(0, 24),
                sozialDienst.Adresse,
                sozialDienst.PLZ + " " + sozialDienst.Ort,
                paymentInformation.BeguenstigtIban.Replace(" ", ""),                                   //[QRY_COL_IBAN]),
                Utilities.RemoveNewLines(paymentInformation.BeguenstigtName),               //[QRY_COL_BEGUENSTIGT_NAME])),
                paymentInformation.BeguenstigtStrasse,                                      //[QRY_COL_BEGUENSTIGT_STRASSE]),
                paymentInformation.BeguenstigtPLZ + " " + paymentInformation.BeguenstigtOrt,//[QRY_COL_BEGUENSTIGT_PLZ]) + " " [QRY_COL_BEGUENSTIGT_ORT]
                paymentInformation.MitteilungZeile1,                                        //[QRY_COL_MITTELIUNG_ZEILE1]),
                paymentInformation.MitteilungZeile2,                                        //[QRY_COL_MITTELIUNG_ZEILE2]),
                paymentInformation.MitteilungZeile3,                                        //[QRY_COL_MITTELIUNG_ZEILE3]),
                paymentInformation.ValutaDatum);                                            //[QRY_COL_VALUTA_DATUM]));

            return record836;
        }

        /// <summary>
        /// Creates an appropriate DTARecord.
        /// </summary>
        /// <param name="sozialDienst">The sozial dienst.</param>
        /// <param name="paymentInformation">The payment information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static DtaRecord CreateDTARecordForKlientenbuchhaltung(SozialDienst sozialDienst, DtaPaymentInformation paymentInformation)
        {
            DtaRecord record;

            bool hasIBAN = !string.IsNullOrEmpty(paymentInformation.BeguenstigtIban);

            switch (paymentInformation.EinzahlungsscheinCode)
            {
                case Einzahlungsschein.OrangerEinzahlungsschein:
                    record = CreateDTARecord826(sozialDienst, paymentInformation);
                    break;

                case Einzahlungsschein.RoterEinzahlungsscheinPost:
                    if (hasIBAN)
                    {
                        record = CreateDtaRecord836(sozialDienst, paymentInformation);
                    }
                    else
                    {
                        record = CreateDtaRecord827(sozialDienst, paymentInformation, false);
                    }
                    break;

                case Einzahlungsschein.BankzahlungSchweiz:
                case Einzahlungsschein.BankzahlungAusland:
                case Einzahlungsschein.RoterEinzahlungsscheinBank:
                case Einzahlungsschein.Postmandat:
                    if (hasIBAN)
                    {
                        record = CreateDtaRecord836(sozialDienst, paymentInformation);
                    }
                    else
                    {
                        record = CreateDtaRecord827(sozialDienst, paymentInformation, true);
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException("EinzahlungsscheinCode");
            }

            record.BuchungId = paymentInformation.BuchungID;
            record.SollKtoNr = paymentInformation.SollKtoNr;
            record.HabenKtoNr = paymentInformation.HabenKtoNr;
            record.Betrag = paymentInformation.Betrag;

            return record;
        }

        /// <summary>
        /// Creates an appropriate DTARecord.
        /// </summary>
        /// <param name="sozialDienst">The sozial dienst.</param>
        /// <param name="paymentInformation">The payment information.</param>
        /// <returns></returns>
        private static DtaRecord CreateDTARecordForMandatbuchhaltung(SozialDienst sozialDienst, DtaPaymentInformation paymentInformation)
        {
            DtaRecord record;

            bool hasIBAN = !string.IsNullOrEmpty(paymentInformation.BeguenstigtIban);

            switch (paymentInformation.ZahlungsArtCode)
            {
                case ZahlungsArt.OrangerEinzahlungsschein:
                case ZahlungsArt.Blau_Orange_ESR_ueber_Bank:
                    record = CreateDTARecord826(sozialDienst, paymentInformation);
                    break;

                case ZahlungsArt.RoterEinzahlungsscheinPost:
                    if (hasIBAN)
                    {
                        record = CreateDtaRecord836(sozialDienst, paymentInformation);
                    }
                    else
                    {
                        record = CreateDtaRecord827(sozialDienst, paymentInformation, false);
                    }
                    break;

                case ZahlungsArt.BankzahlungSchweiz:
                case ZahlungsArt.BankUeberweisung:
                case ZahlungsArt.Postmandat:
                    if (hasIBAN)
                    {
                        record = CreateDtaRecord836(sozialDienst, paymentInformation);
                    }
                    else
                    {
                        record = CreateDtaRecord827(sozialDienst, paymentInformation, true);
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException("ZahlungsArtCode");
            }

            record.BuchungId = paymentInformation.BuchungID;
            record.SollKtoNr = paymentInformation.SollKtoNr;
            record.HabenKtoNr = paymentInformation.HabenKtoNr;
            record.Betrag = paymentInformation.Betrag;

            return record;
        }

        #endregion

        #endregion
    }
}