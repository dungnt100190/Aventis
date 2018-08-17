using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

using Kiss.Infrastructure.Utils;

using KiSS4.DB;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// DtaOrder is a collection of DTA records.
    /// </summary>
    public sealed class Iso20022Order : IOrder
    {
        public static readonly string JobTypeISO20022 = "ISO 20022";
        public readonly DateTime VerarbeitungsDatum;
        private readonly Document _document;

        private Dictionary<string, PaymentInstructionInformation3CH> _paymentInstructions;

        private Dictionary<PaymentInstructionInformation3CH, ICollection<CreditTransferTransactionInformation10CH>>
            _transactionDictionary;

        public Iso20022Order(
            string vertragNr,
            string zugangId,
            DateTime verarbeitungsDatum)
        {
            VertragNr = vertragNr;
            DatenfileAbsenderIdentifikation = vertragNr;
            AccessId = zugangId;
            VerarbeitungsDatum = verarbeitungsDatum;
            PaymentMessageId = Guid.NewGuid().ToString("N");

            _document = GenerateDocument();

            _paymentInstructions = new Dictionary<string, PaymentInstructionInformation3CH>();
            _transactionDictionary = new Dictionary<PaymentInstructionInformation3CH, ICollection<CreditTransferTransactionInformation10CH>>();

            Errors = new Dictionary<int, string>();
        }

        /// <summary>
        /// Gets the access id. (aka ZugangsId)
        /// </summary>
        /// <value>The access id.</value>
        public Object AccessId
        {
            get;
            set;
        }

        public string DatenfileAbsenderIdentifikation { get; set; }

        public Dictionary<int, string> Errors { get; set; }

        /// <summary>
        /// Gets the type of the job.
        /// </summary>
        /// <value>"DTA", "EZAG" or "ISO 20022"</value>
        public string JobType
        {
            get { return JobTypeISO20022; }
        }

        public int JournalId { get; set; }

        /// <summary>
        /// Gets the "PaymentMessageID", an ID used to identify a payment in the ISO 20022 format.
        /// </summary>
        /// <value>The payment message id.</value>
        public string PaymentMessageId { get; private set; }

        public int RecordCount
        {
            get { return _transactionDictionary.Values.Sum(c => c.Count); }
        }

        /// <summary>
        /// Gets the "TotalBetrag".
        /// </summary>
        /// <value>The total amount.</value>
        public Decimal TotalBetrag
        {
            get
            {
                decimal total = 0;
                _transactionDictionary
                    .Values
                    .ToList()
                    .ForEach(c => total += c.Sum(ctti => GetAmount(ctti)));
                return total;
            }
        }

        public string VertragNr { get; set; }

        /// <summary>
        /// Adds the specified dta record.
        /// </summary>
        /// <param name="transferTransaction">The TransferTransaction.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(PaymentInstructionInformation3CH paymentInformation, CreditTransferTransactionInformation10CH transferTransaction)
        {
            if (paymentInformation == null)
            {
                throw new ArgumentNullException("paymentInformation");
            }

            if (transferTransaction == null)
            {
                throw new ArgumentNullException("transferTransaction");
            }

            ICollection<CreditTransferTransactionInformation10CH> transactions;
            if (!_transactionDictionary.TryGetValue(paymentInformation, out transactions))
            {
                transactions = new List<CreditTransferTransactionInformation10CH>();
                _transactionDictionary.Add(paymentInformation, transactions);
            }

            transactions.Add(transferTransaction);
        }

        public string CreateUniqueIso20022FileName(string directory)
        {
            string filename = String.Empty;

            for (int i = 1; i < 1000; i++)
            {
                filename = string.Format("{0}ISO20022_{1}_{2:dd.MM.yyyy}_{3}.{4}",
                    directory,
                    DatenfileAbsenderIdentifikation.Trim(),
                    DateTime.Today,
                    i,
                    "xml");

                if (!File.Exists(filename))
                {
                    break;
                }
            }

            return filename;
        }

        /// <summary>
        /// Generates the appropriate file.
        /// </summary>
        /// <param name="fileInfo">The file info.</param>
        public void GenerateFile(FileInfo fileInfo)
        {
            //Total-Informationen aktualisieren (Totalbetrag + Anzahl Transaktionen)
            _document.CstmrCdtTrfInitn.GrpHdr.CtrlSum = TotalBetrag;
            _document.CstmrCdtTrfInitn.GrpHdr.CtrlSumSpecified = true;
            _document.CstmrCdtTrfInitn.GrpHdr.NbOfTxs = RecordCount.ToString();

            _transactionDictionary.Keys.ToList().ForEach(pi => pi.CdtTrfTxInf = _transactionDictionary[pi].ToArray());

            _document.CstmrCdtTrfInitn.PmtInf = _transactionDictionary.Keys.ToArray();

            var serializer = new XmlSerializer(typeof(Document));
            var writer = new StreamWriter(fileInfo.FullName);
            serializer.Serialize(writer, _document);
            writer.Close();
        }

        public PaymentInstructionInformation3CH GetOrCreatePaymentInstruction(string auftraggeberKontoNr, string auftraggeberClearingNr)
        {
            auftraggeberKontoNr = IsIban(auftraggeberKontoNr) ? auftraggeberKontoNr.RemoveWhitespaces() : Utilities.EnsureLatinCharacterSet(auftraggeberKontoNr, 34);

            PaymentInstructionInformation3CH paymentInstruction = null;
            if (!_paymentInstructions.TryGetValue(auftraggeberKontoNr, out paymentInstruction))
            {
                paymentInstruction = new PaymentInstructionInformation3CH
                {
                    PmtInfId = Guid.NewGuid().ToString("N"),
                    PmtMtd = PaymentMethod3Code.TRF, //TRF oder TRA, hat in der Schweiz keine Auswirkung
                    BtchBookg = true, //Sammelbuchung ja/nein. Default ist true (Sammelbuchung)
                    BtchBookgSpecified = true,
                    ReqdExctnDt = VerarbeitungsDatum,

                    Dbtr = new PartyIdentification32CH(),
                    DbtrAcct = new CashAccount16CH_IdTpCcy
                    {
                        Id = GetAccountIdentification(auftraggeberKontoNr),
                    },
                    DbtrAgt = new BranchAndFinancialInstitutionIdentification4CH_BicOrClrId
                    {
                        FinInstnId = new FinancialInstitutionIdentification7CH_BicOrClrId
                        {
                            ClrSysMmbId = new ClearingSystemMemberIdentification2
                            {
                                ClrSysId = new ClearingSystemIdentification2Choice
                                {
                                    Item = "CHBCC",
                                    ItemElementName = ItemChoiceType2.Cd,
                                },
                                MmbId = auftraggeberClearingNr
                            }
                        },
                    }
                };

                _paymentInstructions.Add(auftraggeberKontoNr, paymentInstruction);
            }

            return paymentInstruction;
        }

        public IEnumerable<CreditTransferTransactionInformation10CH> GetPaymentInstructions()
        {
            return _transactionDictionary.Values.SelectMany(x => x).AsEnumerable();
        }

        private static bool IsIban(string auftraggeberKontoNr)
        {
            return Regex.IsMatch(auftraggeberKontoNr, @"^CH\d{7}[0-9A-Z]{12}$");
        }

        private Document GenerateDocument()
        {
            var assembly = Assembly.GetEntryAssembly();
            if (assembly == null)
            {
                assembly = Assembly.GetCallingAssembly();
            }

            var assemblyCompany = assembly.GetCustomAttribute(typeof(AssemblyCompanyAttribute)) as AssemblyCompanyAttribute;
            var assemblyProduct = assembly.GetCustomAttribute(typeof(AssemblyProductAttribute)) as AssemblyProductAttribute;
            var assemblyFileVersion = assembly.GetCustomAttribute(typeof(AssemblyFileVersionAttribute)) as AssemblyFileVersionAttribute;

            var document = new Document();
            document.CstmrCdtTrfInitn = new CustomerCreditTransferInitiationV03CH
            {
                GrpHdr = new GroupHeader32CH
                {
                    CreDtTm = DateTime.Now,
                    InitgPty = new PartyIdentification32CH_NameAndId
                    {
                        Nm = assemblyCompany != null ? assemblyCompany.Company : "",
                        CtctDtls = new ContactDetails2CH
                        {
                            Nm = assemblyProduct != null ? assemblyProduct.Product : "",
                            Othr = assemblyFileVersion != null ? assemblyFileVersion.Version : "",
                        },
                    },
                    MsgId = PaymentMessageId,
                }
            };

            return document;
        }

        private AccountIdentification4ChoiceCH GetAccountIdentification(string auftraggeberKontoNr)
        {
            //Wenn IBAN -> as String
            if (IsIban(auftraggeberKontoNr))
            {
                return new AccountIdentification4ChoiceCH
                {
                    Item = auftraggeberKontoNr,
                };
            }

            //sonst: als GenericAccountIdentification1CH-Struktur
            return new AccountIdentification4ChoiceCH
            {
                Item = new GenericAccountIdentification1CH
                {
                    Id = auftraggeberKontoNr,
                }
            };
        }

        private decimal GetAmount(CreditTransferTransactionInformation10CH transferTransaction)
        {
            ActiveOrHistoricCurrencyAndAmount amountStructure = transferTransaction.Amt.Item as ActiveOrHistoricCurrencyAndAmount;
            if (amountStructure != null)
            {
                return amountStructure.Value;
            }

            return 0;
        }
    }
}