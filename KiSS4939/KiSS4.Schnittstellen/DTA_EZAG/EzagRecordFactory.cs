using System;

using KiSS4.Common;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    public static class EzagRecordFactory
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Erstellt einen EZAG record.
        /// </summary>
        /// <param name="sozialDienst">The sozial dienst.</param>
        /// <param name="paymentInformation">the payment information.</param>
        /// <param name="buchhaltungstyp">The buchhaltungstyp.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static EzagRecord CreateEzagRecord(SozialDienst sozialDienst, EzagPaymentInformation paymentInformation, BuchhaltungsTyp buchhaltungstyp)
        {
            switch (buchhaltungstyp)
            {
                case BuchhaltungsTyp.Klientenbuchhaltung:
                    return CreateEzagRecordForKlientenbuchhaltung(
                        sozialDienst,
                        paymentInformation);

                case BuchhaltungsTyp.Mandatsbuchhaltung:
                    return CreateEzagRecordMandatsbuchaltung(
                        sozialDienst,
                        paymentInformation);

                default:
                    throw new ArgumentOutOfRangeException("buchhaltungstyp", "Der Typ der Buchhaltung ist ungültig.");
            }
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Creates the ezag22 record (via bank).
        /// </summary>
        /// <param name="sozialDienst">The sozial dienst.</param>
        /// <param name="paymentInformation">the payment information.</param>
        /// <returns></returns>
        private static EzagRecord CreateBankEzag22Record(SozialDienst sozialDienst, EzagPaymentInformation paymentInformation)
        {
            Ezag22 record = new Ezag22(
                paymentInformation.Betrag,              //["Betrag"]),
                paymentInformation.PCKontoNr,           //dr["PCKontoNr"]),
                paymentInformation.BankName,            //dr["BankName"]),
                "",
                paymentInformation.BankStrasse,         //dr["BankStrasse"]),
                paymentInformation.BankPLZ,             //dr["BankPlz"]),
                paymentInformation.BankOrt,             //dr["BankOrt"]),
                string.IsNullOrWhiteSpace(paymentInformation.BeguenstigtIban) ?
                    paymentInformation.EndbeguenstigterKonto :
                    paymentInformation.BeguenstigtIban, //kbBuchung.EndbeguenstigterKonto,
                paymentInformation.BeguenstigtName + " " + paymentInformation.BeguenstigtName2, //dr["BeguenstigtName"]) + " " + dr["BeguenstigtName2"]
                paymentInformation.BeguenstigtZusatz,
                paymentInformation.BeguenstigtStrasse,  //dr["BeguenstigtStrasse"]),
                paymentInformation.BeguenstigtPLZ,      //dr["BeguenstigtPLZ"]),
                paymentInformation.BeguenstigtOrt,      //dr["BeguenstigtOrt"]),
                paymentInformation.MitteilungZeile1,    //dr["MitteilungZeile1"]),
                paymentInformation.MitteilungZeile2,    //dr["MitteilungZeile2"]),
                paymentInformation.MitteilungZeile3,    //dr["MitteilungZeile3"]),
                paymentInformation.MitteilungZeile4,    //dr["MitteilungZeile4"]),
                sozialDienst.Name,
                "",
                sozialDienst.Adresse,
                sozialDienst.PLZ,
                sozialDienst.Ort);

            return record;
        }

        /// <summary>
        /// Creates the direct ezag22 record.
        /// </summary>
        /// <param name="sozialDienst">The sozial dienst.</param>
        /// <param name="paymentInformation">the payment information.</param>
        /// <returns></returns>
        private static EzagRecord CreateDirectEzag22Record(SozialDienst sozialDienst, EzagPaymentInformation paymentInformation)
        {
            Ezag22 record = new Ezag22(
                paymentInformation.Betrag,          //dr["Betrag"]),
                paymentInformation.PCKontoNr,       //dr["PCKontoNr"]),
                paymentInformation.BeguenstigtName + " " + paymentInformation.BeguenstigtName2, //dr["BeguenstigtName"]) + " " + dr["BeguenstigtName2"]),
                paymentInformation.BeguenstigtZusatz,
                paymentInformation.BeguenstigtStrasse,  //dr["BeguenstigtStrasse"]),
                paymentInformation.BeguenstigtPLZ,      //dr["BeguenstigtPLZ"]),
                paymentInformation.BeguenstigtOrt,      //dr["BeguenstigtOrt"]),
                paymentInformation.BeguenstigtIban,
                paymentInformation.BeguenstigtName + " " + paymentInformation.BeguenstigtName2, //dr["BeguenstigtName"]) + " " + dr["BeguenstigtName2"]),
                paymentInformation.BeguenstigtZusatz,
                "",
                "",
                "",
                paymentInformation.MitteilungZeile1,    //dr["MitteilungZeile1"]),
                paymentInformation.MitteilungZeile2,    //dr["MitteilungZeile2"]),
                paymentInformation.MitteilungZeile3,    //dr["MitteilungZeile3"]),
                paymentInformation.MitteilungZeile4,    //dr["MitteilungZeile4"]),
                sozialDienst.Name,
                "",
                sozialDienst.Adresse,
                sozialDienst.PLZ,
                sozialDienst.Ort);
            return record;
        }

        /// <summary>
        /// Creates the ezag24 record.
        /// </summary>
        /// <param name="sozialDienst">The sozial dienst.</param>
        /// <param name="paymentInformation">the payment information.</param>
        /// <returns></returns>
        private static EzagRecord CreateEzag24Record(SozialDienst sozialDienst, EzagPaymentInformation paymentInformation)
        {
            Ezag24 temp = new Ezag24(
                paymentInformation.Betrag, //dr["Betrag"]),
                false,
                paymentInformation.BeguenstigtName + " " + paymentInformation.BeguenstigtName2, //dr["BeguenstigtName"]) + " " + dr["BeguenstigtName2"]
                paymentInformation.BeguenstigtZusatz,
                paymentInformation.BeguenstigtStrasse, //dr["BeguenstigtStrasse"]),
                paymentInformation.BeguenstigtPLZ, //dr["BeguenstigtPLZ"]),
                paymentInformation.BeguenstigtOrt, //dr["BeguenstigtOrt"]),
                "", //EndbeguenstigtName
                "", //EndbeguenstigtZusatz
                "", //EndbeguenstigtStrasse
                "", //EndbeguenstigtPLZ
                "", //EndbeguenstigtOrt
                paymentInformation.MitteilungZeile1, //dr["MitteilungZeile1"]),
                paymentInformation.MitteilungZeile2, //dr["MitteilungZeile2"]),
                paymentInformation.MitteilungZeile3, //dr["MitteilungZeile3"]),
                paymentInformation.MitteilungZeile4, //dr["MitteilungZeile4"]),
                sozialDienst.Name,
                "",
                sozialDienst.Adresse,
                sozialDienst.PLZ,
                sozialDienst.Ort);

            return temp;
        }

        /// <summary>
        /// Creates the ezag27 record.
        /// </summary>
        /// <param name="sozialDienst">The sozial dienst.</param>
        /// <param name="paymentInformation">the payment information.</param>
        /// <returns></returns>
        private static EzagRecord CreateEzag27Record(SozialDienst sozialDienst, EzagPaymentInformation paymentInformation)
        {
            Ezag27 temp = new Ezag27(
                paymentInformation.Betrag, //dr["Betrag"]),
                paymentInformation.BeguenstigtBankBCN, //dr["BankBCN"]),
                string.IsNullOrWhiteSpace(paymentInformation.BeguenstigtIban) ?
                    paymentInformation.EndbeguenstigterKonto :
                    paymentInformation.BeguenstigtIban,        //kbBuchung.EndbeguenstigterKonto,
                paymentInformation.BankName, //dr["BankName"]),
                "",
                paymentInformation.BankStrasse, //dr["BankStrasse"]),
                paymentInformation.BankPLZ, //dr["BankPlz"]),
                paymentInformation.BankOrt, //dr["BankOrt"]),
                paymentInformation.BeguenstigtName + " " + paymentInformation.BeguenstigtName2, //dr["BeguenstigtName"]) + " " + dr["BeguenstigtName2"]
                paymentInformation.BeguenstigtZusatz,
                paymentInformation.BeguenstigtStrasse, //dr["BeguenstigtStrasse"]),
                paymentInformation.BeguenstigtPLZ, //dr["BeguenstigtPLZ"]),
                paymentInformation.BeguenstigtOrt, //dr["BeguenstigtOrt"]),
                paymentInformation.MitteilungZeile1, //dr["MitteilungZeile1"]),
                paymentInformation.MitteilungZeile2, //dr["MitteilungZeile2"]),
                paymentInformation.MitteilungZeile3, //dr["MitteilungZeile3"]),
                paymentInformation.MitteilungZeile4, //dr["MitteilungZeile4"]),
                sozialDienst.Name,
                "",
                sozialDienst.Adresse,
                sozialDienst.PLZ,
                sozialDienst.Ort);

            return temp;
        }

        /// <summary>
        /// Creates the ezag28 record.
        /// </summary>
        /// <param name="sozialDienst">The sozial dienst.</param>
        /// <param name="paymentInformation">the payment information.</param>
        /// <returns></returns>
        private static EzagRecord CreateEzag28Record(SozialDienst sozialDienst, EzagPaymentInformation paymentInformation)
        {
            Ezag28 record = new Ezag28(
                paymentInformation.Betrag,          //dr["Betrag"]),
                "",
                paymentInformation.PCKontoNr,       //dr["PCKontoNr"]),
                paymentInformation.ReferenzNummer,  //dr["ReferenzNummer"]),
                sozialDienst.Name);

            return record;
        }

        /// <summary>
        /// Erstellt einen EZAG record.
        /// </summary>
        /// <param name="sozialDienst">The sozial dienst.</param>
        /// <param name="paymentInformation">The payment information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static EzagRecord CreateEzagRecordForKlientenbuchhaltung(
            SozialDienst sozialDienst,
            EzagPaymentInformation paymentInformation)
        {
            EzagRecord record;

            switch (paymentInformation.EinzahlungsscheinCode)
            {
                case Einzahlungsschein.OrangerEinzahlungsschein:
                    record = CreateEzag28Record(sozialDienst, paymentInformation);
                    break;

                case Einzahlungsschein.RoterEinzahlungsscheinPost:
                    record = CreateDirectEzag22Record(sozialDienst, paymentInformation);
                    break;

                case Einzahlungsschein.BankzahlungSchweiz:
                    record = CreateEzag27Record(sozialDienst, paymentInformation);
                    break;

                case Einzahlungsschein.BankzahlungAusland:
                    throw new InvalidOperationException("Bankzahlung-Ausland wird nicht unberstützt bei EZAG");

                case Einzahlungsschein.RoterEinzahlungsscheinBank:
                    record = CreateEzag27Record(sozialDienst, paymentInformation);
                    break;

                case Einzahlungsschein.Postmandat:
                    record = CreateEzag24Record(sozialDienst, paymentInformation);
                    break;

                default:
                    throw new InvalidOperationException("Der Zahlungstyp ist ungültig.");
            }

            record.BuchungId = paymentInformation.BuchungID;
            record.SollKtoNr = paymentInformation.SollKtoNr;
            record.HabenKtoNr = paymentInformation.HabenKtoNr;
            record.Betrag = paymentInformation.Betrag;

            return record;
        }

        /// <summary>
        /// Erstellt einen EZAG record.
        /// </summary>
        /// <param name="sozialDienst">Der verantwortliche Sozialdienst.</param>
        /// <param name="paymentInformation">The payment information.</param>
        /// <returns></returns>
        private static EzagRecord CreateEzagRecordMandatsbuchaltung(
            SozialDienst sozialDienst,
            EzagPaymentInformation paymentInformation)
        {
            EzagRecord record;

            switch (paymentInformation.ZahlungsArtCode)
            {
                case ZahlungsArt.OrangerEinzahlungsschein:
                case ZahlungsArt.Blau_Orange_ESR_ueber_Bank:
                    record = CreateEzag28Record(sozialDienst, paymentInformation);
                    break;

                case ZahlungsArt.RoterEinzahlungsscheinPost:
                    record = CreateDirectEzag22Record(sozialDienst, paymentInformation);
                    break;

                case ZahlungsArt.BankzahlungSchweiz:
                    record = CreateBankEzag22Record(sozialDienst, paymentInformation);
                    break;

                case ZahlungsArt.BankUeberweisung:
                    record = CreateEzag27Record(sozialDienst, paymentInformation);
                    break;

                case ZahlungsArt.Postmandat:
                    record = CreateEzag24Record(sozialDienst, paymentInformation);
                    break;

                default:
                    throw new Exception("ZahlungsArt -> EZAG nicht implementiert");
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