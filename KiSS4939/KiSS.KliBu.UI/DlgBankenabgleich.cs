using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

using KiSS.Common;
using KiSS.Common.BL;

using KiSS.Context;
using KiSS.KliBu.BL;
using KiSS.KliBu.BL.DTO;
using KiSS.KliBu.BL.Parser;
using KiSS.Lookup.BL;
using Kiss.Infrastructure.IO;


namespace KiSS.KliBu.UI
{
    public partial class DlgBankenabgleich : KissDialog
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        // qryBaBank fields
        private const string BNK_BA_BANK_ID = "BaBankID";
        private const string BNK_CLEARING_NR = "ClearingNr";
        private const string BNK_CLEARING_NR_NEU = "ClearingNrNeu";
        private const string BNK_DATUM = "Datum";
        private const string BNK_FILIALE_NR = "FilialeNr";
        private const string BNK_GUELTIG_AB = "GueltigAb";
        private const string BNK_HAUPTSITZ_BCL = "HauptsitzBCL";
        private const string BNK_LAND = "Land";
        private const string BNK_NAME = "Name";
        private const string BNK_ORT = "Ort";
        private const string BNK_PC_KONTO_NR = "PCKontoNr";
        private const string BNK_PLZ = "PLZ";
        private const string BNK_STRASSE = "Strasse";

        // Message to write in the XLog Table for BaBank update-history
        private const string XLOG_MESSAGE = "updated bank infos";

        #endregion

        #region Private Fields

        private bool _updateBank;

        #endregion

        #endregion

        #region Constructors

        public DlgBankenabgleich()
        {
            InitializeComponent();
        }

        public DlgBankenabgleich(bool updateBank)
        {
            InitializeComponent();
            _updateBank = updateBank;
        }

        #endregion

        #region EventHandlers

        private void DlgBankenabgleich_Load(object sender, EventArgs e)
        {
            SettupFieldName();
            if (_updateBank)
            {
                _updateBank = false;
                UpdateBankenstamm();
            }
            LoadUpdatedBankList();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.userCancel = false;
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateBankenstamm();
            LoadUpdatedBankList();
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static DateTime GetLastUpdateDate()
        {
            BankenabgleichService svc = new BankenabgleichService(AppContext.Container);
            return DlgBankenabgleich.GetLastUpdateDate(svc.GetType().FullName.ToString(), "updated");
        }

        public static DateTime GetLastUpdateDate(string source, string message)
        {
            SqlQuery qryLastUpdate = DBUtil.OpenSQL(@"
                SELECT TOP 1
                       Created = CONVERT(VARCHAR, XLG.Created, 104) + ' ' + CONVERT(VARCHAR, XLG.Created, 108)
                FROM dbo.XLog XLG WITH (READUNCOMMITTED)
                WHERE XLG.Source = {0}
                  AND XLG.Message = {1}
                ORDER BY XLG.Created DESC;", source, message);

            return Convert.ToDateTime(qryLastUpdate["Created"]);
        }

        #endregion

        #region Private Methods

        private void GetLastUpdate()
        {
            lblLastUpdate.Text = "letzte Aktualisierung am " + DlgBankenabgleich.GetLastUpdateDate().ToString();
        }

        private void LoadUpdatedBankList()
        {
            qryBaBank.Fill(new object[] { this.GetType().FullName, XLOG_MESSAGE });
            GetLastUpdate();
        }

        private void SettupFieldName()
        {
            colClearingNr.FieldName = BNK_CLEARING_NR;
            colClearingNrNeu.FieldName = BNK_CLEARING_NR_NEU;
            colDatum.FieldName = BNK_DATUM;
            colFilialeNr.FieldName = BNK_FILIALE_NR;
            colGueltigAb.FieldName = BNK_GUELTIG_AB;
            colHauptsitzBCL.FieldName = BNK_HAUPTSITZ_BCL;
            colLandCode.FieldName = BNK_LAND;
            colName.FieldName = BNK_NAME;
            colOrt.FieldName = BNK_ORT;
            colPcKontoNr.FieldName = BNK_PC_KONTO_NR;
            colPLZ.FieldName = BNK_PLZ;
            colStrasse.FieldName = BNK_STRASSE;
        }

        private void UpdateBankenstamm()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            string outputMessage;

            // WebRequest, Zip and Parse
            Stream zipStream;
            string url = DBUtil.GetConfigString(@"System\Basis\Bankenstamm\URL", "http://www.six-interbank-clearing.com/dam/downloads/bc-bank-master/bcbankenstamm.zip");
            zipStream = WebRequest.GetStream(url);
            Zip zip = new Zip(zipStream);
            Stream fileStream = zip.GetStream("bcbankenstamm");
            BankParser bankParser = new BankParser(fileStream);
            bankParser.Parse();
            List<Bank> bankList = bankParser.GetBankList();

            // Bankenabgleich
            using (BankenabgleichService svc = AppContext.Container.Resolve<BankenabgleichService>())
            {
                List<Bank> updatedBankList;
                ServiceResult serviceResult = svc.Sync(bankList, out updatedBankList);
                if (serviceResult.Success)
                {
                    outputMessage = string.Format("{0} Banken wurden aktualisiert.", updatedBankList.Count);
                    using (LogService svcLog = AppContext.Container.Resolve<LogService>())
                    {
                        foreach (Bank bank in updatedBankList)
                        {
                            // Add an entry in the XLog table
                            KiSS.Lookup.BL.DTO.Log log = new KiSS.Lookup.BL.DTO.Log(
                                this.GetType().FullName,
                                KiSS.Lookup.BL.DTO.LogLevel.INFO,
                                XLOG_MESSAGE,
                                DBUtil.GetDBRowCreatorModifier(),
                                true);
                            log.Comment = bank.ToStringLog();
                            log.ReferenceTable = "BaBank";
                            log.ReferenceID = bank.ID;
                            svcLog.Add(log);
                        }
                    }
                }
                else
                {
                    outputMessage = "Validierungsproblem:";
                    foreach (var error in serviceResult.Errors)
                    {
                        outputMessage += System.Environment.NewLine + error;
                    }
                }
            }

            KissMsg.ShowInfo(outputMessage);
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        #endregion

        #endregion
    }
}