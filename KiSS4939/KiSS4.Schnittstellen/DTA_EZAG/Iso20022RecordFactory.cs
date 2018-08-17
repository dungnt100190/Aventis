using System;
using System.IO;
using Kiss.Infrastructure.Utils;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Provides simple means to create appropriate DTARecords.
    /// </summary>
    public static class Iso20022RecordFactory
    {
        public static CreditTransferTransactionInformation10CH CreateTransferTransactionRecord(SozialDienst sozialDienst, Iso20022PaymentInformation paymentInformation, BuchhaltungsTyp buchhaltungstyp)
        {
            switch (buchhaltungstyp)
            {
                case BuchhaltungsTyp.Klientenbuchhaltung:
                    return CreateTransferTransactionRecordForKlientenbuchhaltung(sozialDienst, paymentInformation);

                case BuchhaltungsTyp.Mandatsbuchhaltung:
                    return CreateTransferTransactionRecordForMandatbuchhaltung(sozialDienst, paymentInformation);

                default:
                    return null;
            }
        }

        private static CreditTransferTransactionInformation10CH Create_1_ESR_Zahlung(SozialDienst sozialDienst, Iso20022PaymentInformation paymentInformation)
        {
            //Validierung:
            //- Betrag > 0.00
            //- BegünstigtName Mussfeld
            //- PCKontoNr Mussfeld
            //- ReferenzNummer Mussfeld
            if (paymentInformation.Betrag <= 0.00m)
            {
                throw new InvalidDataException(KissMsg.GetMLMessage("Iso20022RecordFactory", "Fehler_Betrag_groesser_0", "Fehlerhafte Buchungsdaten. Betrag muss > 0.00 sein."));
            }

            if (string.IsNullOrEmpty(paymentInformation.BeguenstigtName))
            {
                throw new InvalidDataException(KissMsg.GetMLMessage("Iso20022RecordFactory", "Fehler_Name_Beguenstigter_fehlt", "Fehlerhafte Buchungsdaten. Name des Begünstigten fehlt."));
            }

            if (string.IsNullOrEmpty(paymentInformation.PCKontoNr))
            {
                throw new InvalidDataException(KissMsg.GetMLMessage("Iso20022RecordFactory", "Fehler_PC_Nummer_fehlt", "Fehlerhafte Buchungsdaten. Bei dieser Zahlungsart ist die PC-Nummer zwingend."));
            }

            if (string.IsNullOrEmpty(paymentInformation.ReferenzNummer))
            {
                throw new InvalidDataException(KissMsg.GetMLMessage("Iso20022RecordFactory", "Fehler_Referenznummer_fehlt", "Fehlerhafte Buchungsdaten. Bei dieser Zahlungsart ist die Referenznummer zwingend."));
            }

            //Werte abfüllen:
            var creditTransferTransactionInformation = new CreditTransferTransactionInformation10CH
            {
                PmtId = new PaymentIdentification1
                {
                    InstrId = paymentInformation.BuchungID,
                    EndToEndId = paymentInformation.BuchungID,
                },

                //Bei Zahlarten: 1, 2.1, 2.2, 3 auf C-Level (hier)
                PmtTpInf = new PaymentTypeInformation19CH
                {
                    LclInstrm = new LocalInstrument2Choice
                    {
                        //1 (ESR): CH01
                        //2.1 (ES 1-stufig, Post): CH02
                        //2.2 (ES 2-stufig, Bank): CH03
                        //5 (Ausland, SEPA): kein Wert in LclInstrm, stattdessen SvcLvl mit SEPA
                        Item = "CH01",
                        ItemElementName = ItemChoiceType5.Prtry,
                    },
                },

                Amt = new AmountType3Choice
                {
                    Item = new ActiveOrHistoricCurrencyAndAmount
                    {
                        Ccy = "CHF",
                        Value = paymentInformation.Betrag,
                    },
                },
                Cdtr = new PartyIdentification32CH_Name
                {
                    Nm = paymentInformation.BeguenstigtName,
                    PstlAdr = new PostalAddress6CH
                    {
                        StrtNm = paymentInformation.BeguenstigtStrasse,
                        BldgNb = paymentInformation.BeguenstigtHausNr,
                        PstCd = paymentInformation.BeguenstigtPLZ,
                        TwnNm = paymentInformation.BeguenstigtOrt,
                    }
                },
                CdtrAcct = new CashAccount16CH_Id
                {
                    Id = new AccountIdentification4ChoiceCH
                    {
                        Item = new GenericAccountIdentification1CH
                        {
                            Id = paymentInformation.PCKontoNr,
                        },
                    }
                },
                RmtInf = new RemittanceInformation5CH
                {
                    Strd = new StructuredRemittanceInformation7
                    {
                        CdtrRefInf = new CreditorReferenceInformation2
                        {
                            Ref = paymentInformation.ReferenzNummer?.RemoveWhitespaces(),
                        },
                    },
                },
            };

            return creditTransferTransactionInformation;
        }

        private static CreditTransferTransactionInformation10CH Create_2_1_ES_1_stufig(SozialDienst sozialDienst, Iso20022PaymentInformation paymentInformation)
        {
            //Validierung:
            //- Betrag > 0.00
            //- BegünstigtName Mussfeld
            //- PCKontoNr Mussfeld
            if (paymentInformation.Betrag <= 0.00m)
            {
                throw new InvalidDataException(KissMsg.GetMLMessage("Iso20022RecordFactory", "Fehler_Betrag_groesser_0", "Fehlerhafte Buchungsdaten. Betrag muss > 0.00 sein."));
            }

            if (string.IsNullOrEmpty(paymentInformation.BeguenstigtName))
            {
                throw new InvalidDataException(KissMsg.GetMLMessage("Iso20022RecordFactory", "Fehler_Name_Beguenstigter_fehlt", "Fehlerhafte Buchungsdaten. Name des Begünstigten fehlt."));
            }

            if (string.IsNullOrEmpty(paymentInformation.PCKontoNr))
            {
                throw new InvalidDataException(KissMsg.GetMLMessage("Iso20022RecordFactory", "Fehler_PC_Nummer_fehlt", "Fehlerhafte Buchungsdaten. Bei dieser Zahlungsart ist die PC-Nummer zwingend."));
            }

            //Werte abfüllen:
            var creditTransferTransactionInformation = new CreditTransferTransactionInformation10CH
            {
                PmtId = new PaymentIdentification1
                {
                    InstrId = paymentInformation.BuchungID,
                    EndToEndId = paymentInformation.BuchungID,
                },

                //Bei Zahlarten: 1, 2.1, 2.2, 3 auf C-Level (hier)
                PmtTpInf = new PaymentTypeInformation19CH
                {
                    LclInstrm = new LocalInstrument2Choice
                    {
                        //1 (ESR): CH01
                        //2.1 (ES 1-stufig, Post): CH02
                        //2.2 (ES 2-stufig, Bank): CH03
                        //5 (Ausland, SEPA): kein Wert in LclInstrm, stattdessen SvcLvl mit SEPA
                        Item = "CH02",
                        ItemElementName = ItemChoiceType5.Prtry,
                    },
                },

                Amt = new AmountType3Choice
                {
                    Item = new ActiveOrHistoricCurrencyAndAmount
                    {
                        Ccy = "CHF",
                        Value = paymentInformation.Betrag,
                    },
                },
                Cdtr = new PartyIdentification32CH_Name
                {
                    Nm = paymentInformation.BeguenstigtName,
                    PstlAdr = new PostalAddress6CH
                    {
                        StrtNm = paymentInformation.BeguenstigtStrasse,
                        BldgNb = paymentInformation.BeguenstigtHausNr,
                        PstCd = paymentInformation.BeguenstigtPLZ,
                        TwnNm = paymentInformation.BeguenstigtOrt,
                    }
                },
                CdtrAcct = new CashAccount16CH_Id
                {
                    Id = new AccountIdentification4ChoiceCH
                    {
                        //string -> wird in Feld IBAN serialisiert
                        //GenericAccountIdentification1CH -> wenn ein PC-Konto, wird in Feld Othr serialisiert
                        Item = new GenericAccountIdentification1CH
                        {
                            Id = paymentInformation.PCKontoNr,
                        },
                    }
                },
                RmtInf = new RemittanceInformation5CH
                {
                    Ustrd = paymentInformation.Mitteilung1_4,
                },
            };

            return creditTransferTransactionInformation;
        }

        private static CreditTransferTransactionInformation10CH Create_2_2_ES_2_stufig(SozialDienst sozialDienst, Iso20022PaymentInformation paymentInformation)
        {
            //Validierung:
            //- Betrag > 0.00
            //- BegünstigtBankName Mussfeld
            //- PCKontoNr Mussfeld
            //- BegünstigtName Mussfeld
            //- BegünstigtIBAN Mussfeld

            if (paymentInformation.Betrag <= 0.00m)
            {
                throw new InvalidDataException(KissMsg.GetMLMessage("Iso20022RecordFactory", "Fehler_Betrag_groesser_0", "Fehlerhafte Buchungsdaten. Betrag muss > 0.00 sein."));
            }

            if (string.IsNullOrEmpty(paymentInformation.BeguenstigtBankName))
            {
                throw new InvalidDataException(KissMsg.GetMLMessage("Iso20022RecordFactory", "Fehler_Name_Bank_fehlt", "Fehlerhafte Buchungsdaten. Bei dieser Zahlungsart ist der Name der Bank des Begünstigten zwingend."));
            }

            if (string.IsNullOrEmpty(paymentInformation.PCKontoNr))
            {
                throw new InvalidDataException(KissMsg.GetMLMessage("Iso20022RecordFactory", "Fehler_PC_Nummer_fehlt", "Fehlerhafte Buchungsdaten. Bei dieser Zahlungsart ist die PC-Nummer zwingend."));
            }

            if (string.IsNullOrEmpty(paymentInformation.BeguenstigtName))
            {
                throw new InvalidDataException(KissMsg.GetMLMessage("Iso20022RecordFactory", "Fehler_Name_Beguenstigter_fehlt", "Fehlerhafte Buchungsdaten. Name des Begünstigten fehlt."));
            }

            if (string.IsNullOrEmpty(paymentInformation.BeguenstigtIban))
            {
                throw new InvalidDataException(KissMsg.GetMLMessage("Iso20022RecordFactory", "Fehler_IBAN_Beguenstigter_fehlt", "Fehlerhafte Buchungsdaten. Bei dieser Zahlungsart ist die IBAN des Begünstigten zwingend."));
            }

            //Werte abfüllen:
            var creditTransferTransactionInformation = new CreditTransferTransactionInformation10CH
            {
                PmtId = new PaymentIdentification1
                {
                    InstrId = paymentInformation.BuchungID,
                    EndToEndId = paymentInformation.BuchungID,
                },

                //Bei Zahlarten: 1, 2.1, 2.2, 3 auf C-Level (hier)
                PmtTpInf = new PaymentTypeInformation19CH
                {
                    LclInstrm = new LocalInstrument2Choice
                    {
                        //1 (ESR): CH01
                        //2.1 (ES 1-stufig, Post): CH02
                        //2.2 (ES 2-stufig, Bank): CH03
                        //5 (Ausland, SEPA): kein Wert in LclInstrm, stattdessen SvcLvl mit SEPA
                        Item = "CH03",
                        ItemElementName = ItemChoiceType5.Prtry,
                    },
                },

                Amt = new AmountType3Choice
                {
                    Item = new ActiveOrHistoricCurrencyAndAmount
                    {
                        Ccy = "CHF",
                        Value = paymentInformation.Betrag,
                    },
                },
                CdtrAgt = new BranchAndFinancialInstitutionIdentification4CH
                {
                    FinInstnId = new FinancialInstitutionIdentification7CH
                    {
                        Nm = paymentInformation.BeguenstigtBankName,
                        Othr = new GenericFinancialIdentification1CH
                        {
                            Id = paymentInformation.PCKontoNr,
                        },
                    },
                },
                Cdtr = new PartyIdentification32CH_Name
                {
                    Nm = paymentInformation.BeguenstigtName,
                    PstlAdr = new PostalAddress6CH
                    {
                        StrtNm = paymentInformation.BeguenstigtStrasse,
                        BldgNb = paymentInformation.BeguenstigtHausNr,
                        PstCd = paymentInformation.BeguenstigtPLZ,
                        TwnNm = paymentInformation.BeguenstigtOrt,
                    }
                },
                CdtrAcct = new CashAccount16CH_Id
                {
                    Id = new AccountIdentification4ChoiceCH
                    {
                        //string -> wird in Feld IBAN serialisiert
                        //GenericAccountIdentification1CH -> wenn ein PC-Konto, wird in Feld Othr serialisiert
                        Item = paymentInformation.BeguenstigtIban,
                    },
                },
                RmtInf = new RemittanceInformation5CH
                {
                    Ustrd = paymentInformation.Mitteilung1_3,
                },
            };

            return creditTransferTransactionInformation;
        }

        private static CreditTransferTransactionInformation10CH Create_3_Bankzahlung_Schweiz(SozialDienst sozialDienst, Iso20022PaymentInformation paymentInformation)
        {
            //Validierung:
            //- Betrag > 0.00
            //- BegünstigtBankName Mussfeld
            //- PCKontoNr Mussfeld
            //- BegünstigtName Mussfeld
            //- BegünstigtIBAN Mussfeld

            if (paymentInformation.Betrag <= 0.00m)
            {
                throw new InvalidDataException(KissMsg.GetMLMessage("Iso20022RecordFactory", "Fehler_Betrag_groesser_0", "Fehlerhafte Buchungsdaten. Betrag muss > 0.00 sein."));
            }

            if (string.IsNullOrEmpty(paymentInformation.BeguenstigtBankBCN))
            {
                throw new InvalidDataException(KissMsg.GetMLMessage("Iso20022RecordFactory", "Fehler_ClearingNr_fehlt", "Fehlerhafte Buchungsdaten. Bei dieser Zahlungsart ist die Clearing-Nr der Bank des Begünstigten zwingend."));
            }

            if (string.IsNullOrEmpty(paymentInformation.BeguenstigtName))
            {
                throw new InvalidDataException(KissMsg.GetMLMessage("Iso20022RecordFactory", "Fehler_Name_Beguenstigter_fehlt", "Fehlerhafte Buchungsdaten. Name des Begünstigten fehlt."));
            }

            if (string.IsNullOrEmpty(paymentInformation.BeguenstigtIban))
            {
                throw new InvalidDataException(KissMsg.GetMLMessage("Iso20022RecordFactory", "Fehler_IBAN_Beguenstigter_fehlt", "Fehlerhafte Buchungsdaten. Bei dieser Zahlungsart ist die IBAN des Begünstigten zwingend."));
            }

            var creditTransferTransactionInformation = new CreditTransferTransactionInformation10CH
            {
                PmtId = new PaymentIdentification1
                {
                    //TBD
                    InstrId = paymentInformation.BuchungID,
                    EndToEndId = paymentInformation.BuchungID,
                },

                Amt = new AmountType3Choice
                {
                    Item = new ActiveOrHistoricCurrencyAndAmount
                    {
                        Ccy = "CHF",
                        Value = paymentInformation.Betrag,
                    },
                },
                CdtrAgt = new BranchAndFinancialInstitutionIdentification4CH
                {
                    FinInstnId = new FinancialInstitutionIdentification7CH
                    {
                        ClrSysMmbId = new ClearingSystemMemberIdentification2
                        {
                            ClrSysId = new ClearingSystemIdentification2Choice
                            {
                                Item = "CHBCC",
                                ItemElementName = ItemChoiceType2.Cd,
                            },
                            MmbId = paymentInformation.BeguenstigtBankBCN,
                        },
                    },
                },
                Cdtr = new PartyIdentification32CH_Name
                {
                    Nm = paymentInformation.BeguenstigtName,
                    PstlAdr = new PostalAddress6CH
                    {
                        StrtNm = paymentInformation.BeguenstigtStrasse,
                        BldgNb = paymentInformation.BeguenstigtHausNr,
                        PstCd = paymentInformation.BeguenstigtPLZ,
                        TwnNm = paymentInformation.BeguenstigtOrt,
                    }
                },
                CdtrAcct = new CashAccount16CH_Id
                {
                    Id = new AccountIdentification4ChoiceCH
                    {
                        //string -> wird in Feld IBAN serialisiert
                        //GenericAccountIdentification1CH -> wenn ein PC-Konto, wird in Feld Othr serialisiert
                        Item = paymentInformation.BeguenstigtIban,
                    },
                },
                RmtInf = new RemittanceInformation5CH
                {
                    Ustrd = paymentInformation.Mitteilung1_4,
                },
            };

            return creditTransferTransactionInformation;
        }

        private static CreditTransferTransactionInformation10CH Create_6_Ausland(SozialDienst sozialDienst, Iso20022PaymentInformation paymentInformation)
        {
            throw new NotImplementedException();
        }

        private static CreditTransferTransactionInformation10CH CreateTransferTransactionRecordForKlientenbuchhaltung(SozialDienst sozialDienst, Iso20022PaymentInformation paymentInformation)
        {
            CreditTransferTransactionInformation10CH record;

            bool hasIBAN = !string.IsNullOrEmpty(paymentInformation.BeguenstigtIban);

            switch (paymentInformation.EinzahlungsscheinCode)
            {
                case Einzahlungsschein.OrangerEinzahlungsschein:
                    //Zahlungsart 1: ESR-Zahlung
                    record = Create_1_ESR_Zahlung(sozialDienst, paymentInformation);
                    break;

                case Einzahlungsschein.RoterEinzahlungsscheinPost:
                    //Zahlungsart 2.1 ES 1-stufig
                    record = Create_2_1_ES_1_stufig(sozialDienst, paymentInformation);
                    break;

                case Einzahlungsschein.BankzahlungSchweiz:
                    //Zahlungsart 3 Bankzahlung Schweiz
                    record = Create_3_Bankzahlung_Schweiz(sozialDienst, paymentInformation);
                    break;

                case Einzahlungsschein.BankzahlungAusland:
                    //Zahlungsart 6 Ausland (nicht SEPA), da Währung CHF und nicht EUR
                    record = Create_6_Ausland(sozialDienst, paymentInformation);
                    break;

                case Einzahlungsschein.RoterEinzahlungsscheinBank:
                    //Zahlungsart 2.2 ES 2-stufig
                    record = Create_2_2_ES_2_stufig(sozialDienst, paymentInformation);
                    break;

                case Einzahlungsschein.Postmandat:
                    throw new NotSupportedException("Die Zahlungsart Postmandat wird im Zahlungsformat ISO 20022 nicht mehr unterstützt.");

                default:
                    throw new ArgumentOutOfRangeException("EinzahlungsscheinCode");
            }

            return record;
        }

        /// <summary>
        /// Creates an appropriate DTARecord.
        /// </summary>
        /// <param name="sozialDienst">The sozial dienst.</param>
        /// <param name="paymentInformation">The payment information.</param>
        /// <returns></returns>
        private static CreditTransferTransactionInformation10CH CreateTransferTransactionRecordForMandatbuchhaltung(SozialDienst sozialDienst, Iso20022PaymentInformation paymentInformation)
        {
            CreditTransferTransactionInformation10CH record;

            bool hasIBAN = !string.IsNullOrEmpty(paymentInformation.BeguenstigtIban);

            switch (paymentInformation.ZahlungsArtCode)
            {
                case ZahlungsArt.OrangerEinzahlungsschein:
                    //Zahlungsart 1: ESR-Zahlung
                    record = Create_1_ESR_Zahlung(sozialDienst, paymentInformation);
                    break;

                case ZahlungsArt.Blau_Orange_ESR_ueber_Bank:
                    throw new NotSupportedException("Die Zahlungsart Blau/Orange ESR über Bank wird im Zahlungsformat ISO 20022 nicht mehr unterstützt.");

                case ZahlungsArt.RoterEinzahlungsscheinPost:
                    //Zahlungsart 2.1 ES 1-stufig
                    record = Create_2_1_ES_1_stufig(sozialDienst, paymentInformation);
                    break;

                case ZahlungsArt.BankzahlungSchweiz:
                    //Zahlungsart 3 Bankzahlung Schweiz
                    record = Create_3_Bankzahlung_Schweiz(sozialDienst, paymentInformation);
                    break;

                case ZahlungsArt.BankUeberweisung:
                    throw new NotSupportedException("Die Zahlungsart Banküberweisung wird im Zahlungsformat ISO 20022 nicht mehr unterstützt.");

                case ZahlungsArt.Postmandat:
                    throw new NotSupportedException("Die Zahlungsart Postmandat wird im Zahlungsformat ISO 20022 nicht mehr unterstützt.");

                default:
                    throw new ArgumentOutOfRangeException("ZahlungsArtCode");
            }

            return record;
        }
    }
}