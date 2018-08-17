using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

using KiSS.KliBu.BL.DTO;

using Common.Logging;

namespace KiSS.KliBu.BL.Parser
{
    /// <summary>
    /// Class to parse a <see cref="Stream"/> containing bank records. 
    /// Record definition: <see cref="http://www.six-interbank-clearing.com/de/dl_tkicch_bcbankenstamm.pdf"/>
    /// </summary>
    public class BankParser
    {
        #region Fields

        #region Private Static Fields

        private static readonly ILog logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Private Constant/Read-Only Fields

        private const int encodingCode = 1252; // Western European

        #endregion

        #region Private Fields

        private List<Bank> _bankList = new List<Bank>();
        private Stream _stream;

        #endregion

        #endregion

        #region Constructors

        #region Public Constructors

        /// <summary>
        /// Initialize the <see cref="BankParser"/>
        /// </summary>
        /// <param name="stream"><see cref="Stream"/> containing all the bank information</param>
        public BankParser(Stream stream)
        {
            _stream = stream;
        }

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Get the <see cref="List<Bank>"/>
        /// </summary>
        /// <returns>List of banks</returns>
        public List<Bank> GetBankList()
        {
            return _bankList;
        }

        /// <summary>
        /// Parse the stream to build the bank list.
        /// Invalid records are ignored
        /// </summary>
        public void Parse()
        {
            string line;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (HasRecord(out line))
            {
                try
                {
                    string bankInstitution = GetStringData(line, BankRecord.Name);
                    string clearingNr = GetStringData(line, BankRecord.ClearingNr);
                    int branchId = GetIntData(line, BankRecord.FilialeNr);
                    DateTime gueltigAb = GetDateTimeData(line, BankRecord.GueltigAb);
                    Bank bank = new Bank(bankInstitution, clearingNr, branchId, gueltigAb);

                    bank.Gruppe = GetIntData(line, BankRecord.Gruppe);
                    bank.ClearingNrNeu = GetStringData(line, BankRecord.ClearingNr_NEU, true);
                    bank.SicNr = GetIntData(line, BankRecord.SicNr);
                    bank.HauptsitzBCL = GetStringData(line, BankRecord.HauptsitzBCL, true);
                    bank.BcArt = GetIntData(line, BankRecord.BcArt);
                    bank.TeilnahmecodeCHF = GetIntData(line, BankRecord.TeilnahmecodeCHF);
                    bank.TeilnahmecodeEuro = GetIntData(line, BankRecord.TeilnahmecodeEuro);
                    bank.Sprachcode = GetIntData(line, BankRecord.Sprachcode);
                    bank.Kurzbezeichnung = GetStringData(line, BankRecord.Kurzbezeichnung);
                    bank.Strasse = GetStringData(line, BankRecord.Strasse);
                    bank.Postadresse = GetStringData(line, BankRecord.Postadresse);
                    bank.PLZ = GetStringData(line, BankRecord.PLZ);
                    bank.Ort = GetStringData(line, BankRecord.Ort);
                    bank.Telefon = GetStringData(line, BankRecord.Telefon);
                    bank.Fax = GetStringData(line, BankRecord.Fax);
                    bank.LandesVorwahl = GetStringData(line, BankRecord.LandesVorwahl);
                    bank.Landcode = GetStringData(line, BankRecord.Landcode);
                    if (bank.Landcode == "")
                    {
                        bank.Landcode = "CH";
                    }
                    string pcKonto = GetStringData(line, BankRecord.PCKontoNr);
                    if (pcKonto.StartsWith("*"))
                    {
                        bank.PCKontoNr = pcKonto.Substring(1);
                    }
                    else
                    {
                        bank.PCKontoNr = pcKonto;
                    }
                    bank.SwiftAdresse = GetStringData(line, BankRecord.SwiftAdresse);
                    bank.SicUpdated = true;

                    _bankList.Add(bank);

                }
                catch (BankRecordException ex)
                {
                    logger.Debug("BankRecord " + ex.Message + " Error at " + ex.StartPos + "-" + ex.Lenght + ": \"" + line + "\"");
                }
            }

            watch.Stop();
            logger.Debug(String.Format("Consumed time for parsing: {0}ms", watch.ElapsedMilliseconds));
        }

        #endregion

        #region Private Methods

        private bool CompleteRecord(out string line, string endLine)
        {
            byte[] buffer = new byte[BankRecord.Length - endLine.Length];
            int readByte = _stream.Read(buffer, 0, buffer.Length);
            bool hasRecord = false;
            // not enough data anymore for another bank record
            if (readByte < buffer.Length - 2)
            {
                line = "";
                return false;
            }
            line = endLine + Encoding.GetEncoding(encodingCode).GetString(buffer);

            int endLinePos = line.Substring(0, buffer.Length - 2).LastIndexOf("\r\n");
            // no "\r\n" occurse in the middle of the line
            if (endLinePos == -1)
            {
                hasRecord = true;
            }
            else
            {
                // if the line is shortter than a bank record, then complete the next record
                hasRecord = CompleteRecord(out line, line.Substring(endLinePos + 2));
            }

            // all records but last have to end with "\r\n"
            if (readByte > buffer.Length - 2)
            {
                if (line.Substring(line.Length - 2, 2) == "\r\n")
                {
                    hasRecord = true;
                }
                else
                {
                    hasRecord = CompleteRecord(out line, "");
                }
            }
            else
            {
                hasRecord = true;
            }

            return hasRecord;
        }

        private DateTime GetDateTimeData(string line, Record record)
        {
            string dateString = line.Substring(record.StartPosition, record.Length).Trim();
            DateTime dt = new DateTime();
            bool parsed = DateTime.TryParseExact(dateString, "yyyyMMdd", System.Threading.Thread.CurrentThread.CurrentCulture, System.Globalization.DateTimeStyles.None, out dt);
            if (!parsed)
            {
                throw new BankRecordException(record.StartPosition, record.Length, "DateTime");
            }
            return dt;
        }

        private int GetIntData(string line, Record record)
        {
            try
            {
                string data = line.Substring(record.StartPosition, record.Length).Trim();
                if (data == "")
                {
                    throw new BankRecordException(record.StartPosition, record.Length, "Is null");
                }
                return Convert.ToInt32(data);
            }
            catch (Exception)
            {
                throw new BankRecordException(record.StartPosition, record.Length, "Int");
            }
        }

        private int? GetNullableIntData(string line, Record record)
        {
            try
            {
                string data = line.Substring(record.StartPosition, record.Length).Trim();
                if (data == "")
                {
                    return null;
                }
                return Convert.ToInt32(data);
            }
            catch (Exception)
            {
                throw new BankRecordException(record.StartPosition, record.Length, "Nullable Int");
            }
        }

        private string GetStringData(string line, Record record, bool returnNullIfEmpty = false)
        {
            try
            {
                string data = line.Substring(record.StartPosition, record.Length).Trim();
                if (returnNullIfEmpty && data == "")
                {    
                    return null;
                }
                return data;
            }
            catch (Exception)
            {
                throw new BankRecordException(record.StartPosition, record.Length, "String");
            }
        }

        private bool HasRecord(out string line)
        {
            return CompleteRecord(out line, "");
        }

        #endregion

        #endregion
    }
}