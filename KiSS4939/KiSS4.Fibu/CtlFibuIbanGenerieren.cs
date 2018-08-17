using System;
using System.Data;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Control, used to generate missing iban numbers
    /// </summary>
    public partial class CtlFibuIbanGenerieren : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        // qryMessage fields
        private const string MSG_BCL = "BCL";

        private const string MSG_FB_KREDITOR_ID = "FbKreditorID";
        private const string MSG_FB_ZAHLUNGSWEG_ID = "FbZahlungswegID";
        private const string MSG_KONTO_NR = "KontoNr";
        private const string MSG_MESSAGE = "Message";
        private const string MSG_NAME = "Name";

        // qryIBAN fields
        private const string ZAL_BANK_KONTO_NR = "BankKontoNr";

        private const string ZAL_CLEARING_NR = "ClearingNr";
        private const string ZAL_FB_KREDITOR_ID = "FbKreditorID";
        private const string ZAL_FB_ZAHLUNGSWEG_ID = "FbZahlungswegID";
        private const string ZAL_NAME = "Name";
        private const string ZAL_PC_KONTO_NUMMER = "PCKontoNr";
        private const string ZAL_ZAHLUNGSART_CODE = "ZahlungsArtCode";

        #endregion

        #region Private Fields

        private bool _cancel;
        private bool _isLoading;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFibuIbanGenerieren"/> class.
        /// </summary>
        public CtlFibuIbanGenerieren()
        {
            // set flag
            _isLoading = true;

            InitializeComponent();

            InitGui();
        }

        #endregion

        #region EventHandlers

        private void CtlIbanGenerieren_Load(object sender, EventArgs e)
        {
            try
            {
                qryMessages.DataTable.Columns.Clear();
                qryMessages.DataTable.Columns.Add(MSG_BCL, typeof(string));
                qryMessages.DataTable.Columns.Add(MSG_KONTO_NR, typeof(string));
                qryMessages.DataTable.Columns.Add(MSG_MESSAGE, typeof(string));
                qryMessages.DataTable.Columns.Add(MSG_NAME, typeof(string));
                qryMessages.DataTable.Columns.Add(MSG_FB_KREDITOR_ID, typeof(int));
                qryMessages.DataTable.Columns.Add(MSG_FB_ZAHLUNGSWEG_ID, typeof(int));
            }
            finally
            {
                // reset flag
                _isLoading = false;
            }

            // update labels
            UpdateCount();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancel = true;
        }

        private void btnGotoKreditor_Click(object sender, EventArgs e)
        {
            FormController.OpenForm(
                "FrmFibu",
                "Action", "OpenItem",
                "SubMask", "CtlFibuKreditor",
                "FbKreditorID", qryFbZahlungsweg[DBO.FbZahlungsweg.FbKreditorID],
                "FbZahlungswegID", qryFbZahlungsweg[DBO.FbZahlungsweg.FbZahlungswegID]);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _cancel = false;
            btnCancel.Enabled = true;

            qryMessages.PositionChanged -= qryMessages_PositionChanged;

            // validate to do
            try
            {
                DBUtil.CheckNotNullField(edtTodo, lblTodo.Text);
            }
            catch (KissInfoException ex)
            {
                ex.ShowMessage();
                return;
            }

            // init vars
            int count = 0;
            int errors = 0;
            int success = 0;
            int zahlungsArtCode = 0;
            int todo = Convert.ToInt32(edtTodo.Value);

            // check amount
            if (todo < 1)
            {
                return;
            }

            try
            {
                // set cursor
                Cursor.Current = Cursors.WaitCursor;

                // get data
                qryIban.Fill(string.Format(@"
                    SELECT DISTINCT TOP {0}
                           ZAL.FbZahlungswegID,
                           ZAL.ZahlungsArtCode,
                           ZAL.PCKontoNr,
                           ZAL.BankKontoNr,
                           ZAL.IBAN,
                           BNK.ClearingNr,
                           KRE.Name,
                           ZAL.FbKreditorID
                    FROM dbo.FbZahlungsweg     ZAL
                      LEFT JOIN dbo.BaBank     BNK ON BNK.BaBankID   = ZAL.BaBankID
                      LEFT JOIN dbo.FbKreditor KRE ON KRE.FbKreditorID = ZAL.FbKreditorID
                    WHERE ZAL.IBAN IS NULL
                      AND ZAL.IsActive = 1
                      AND ZAL.ZahlungsArtCode IN (3, 4);",
                    todo));

                // init and show progressbar
                pgbGenerate.Minimum = 0;
                pgbGenerate.Maximum = todo;
                pgbGenerate.Value = 0;
                pgbGenerate.Visible = true;

                // clear output table
                qryMessages.DataTable.Rows.Clear();

                // loop entries
                foreach (DataRow row in qryIban.DataTable.Rows)
                {
                    if (_cancel)
                    {
                        break;
                    }

                    try
                    {
                        // count up
                        count++;

                        // set progress
                        pgbGenerate.Value = count;
                        ApplicationFacade.DoEvents();

                        // get ezcode value
                        zahlungsArtCode = Convert.ToInt32(row[ZAL_ZAHLUNGSART_CODE]);

                        // handle code
                        string iban;

                        switch (zahlungsArtCode)
                        {
                            case 3: // Post
                                {
                                    iban = Belegleser.IBANConvert(row[ZAL_PC_KONTO_NUMMER] as string, "9000");

                                    DBUtil.ExecSQL(@"
                                        UPDATE dbo.FbZahlungsweg
                                        SET IBAN = {0}
                                        WHERE FbZahlungswegID = {1};", iban, Convert.ToInt32(row[ZAL_FB_ZAHLUNGSWEG_ID]));

                                    success++;
                                }
                                break;

                            case 4: // Bank
                                {
                                    iban = Belegleser.IBANConvert(row[ZAL_BANK_KONTO_NR] as string, row[ZAL_CLEARING_NR].ToString());

                                    DBUtil.ExecSQL(@"
                                        UPDATE dbo.FbZahlungsweg
                                        SET IBAN = {0}
                                        WHERE FbZahlungswegID = {1};", iban, Convert.ToInt32(row[ZAL_FB_ZAHLUNGSWEG_ID]));

                                    success++;
                                }
                                break;

                            default:
                                continue;
                        }

                        UpdateCount(success, errors);
                    }
                    catch (Exception ex)
                    {
                        errors++;

                        bool post = (zahlungsArtCode == 3);
                        string bcl = post ? "9000" : (row[ZAL_CLEARING_NR] is int ? row[ZAL_CLEARING_NR].ToString() : "");
                        string konto = post ? row[ZAL_PC_KONTO_NUMMER] as string : row[ZAL_BANK_KONTO_NR] as string;

                        AddErrorRow(bcl, konto, ex.Message, row[ZAL_NAME] as string, row[ZAL_FB_KREDITOR_ID], (int)row[ZAL_FB_ZAHLUNGSWEG_ID]);
                    }
                } // [foreach]
            }
            finally
            {
                UpdateCount(success, errors);

                // hide progressbar again
                pgbGenerate.Visible = false;

                // reset cursor
                Cursor.Current = Cursors.Default;

                btnCancel.Enabled = false;

                qryMessages.PositionChanged += qryMessages_PositionChanged;
                qryMessages.First();
            }
        }

        private void edtBank_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            FibuUtilities.BankSuchen(edtBank.Text, e.ButtonClicked, qryFbZahlungsweg);
        }

        private void qryMessages_PositionChanged(object sender, EventArgs e)
        {
            var id = Utils.ConvertToInt(qryMessages[MSG_FB_ZAHLUNGSWEG_ID]);

            qryFbZahlungsweg.Fill(id);
        }

        #endregion

        #region Methods

        #region Private Methods

        private void AddErrorRow(string bcl, string konto, string fehler, string name, object fbKreditorId, int fbZahlungswegId)
        {
            DataRow row = qryMessages.DataTable.NewRow();

            row[MSG_BCL] = bcl;
            row[MSG_KONTO_NR] = konto;
            row[MSG_MESSAGE] = fehler;
            row[MSG_NAME] = name;
            row[MSG_FB_KREDITOR_ID] = fbKreditorId;
            row[MSG_FB_ZAHLUNGSWEG_ID] = fbZahlungswegId;
            qryMessages.DataTable.Rows.Add(row);
        }

        /// <summary>
        /// Init gui for its default mode
        /// </summary>
        private void InitGui()
        {
            pgbGenerate.Visible = false;
        }

        private void UpdateCount(int success = 0, int errors = 0)
        {
            if (success > 0 || errors > 0)
            {
                lblSuccess.Text = success.ToString();
                lblFail.Text = errors.ToString();
            }

            // validate
            if (_isLoading)
            {
                // do nothing
                return;
            }

            // get count value
            int total = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(1)
                FROM dbo.FbZahlungsweg ZAL
                WHERE ZAL.IBAN IS NULL
                  AND ZAL.IsActive = 1
                  AND ZAL.ZahlungsArtCode IN (3, 4);"));

            lblTotal.Text = total.ToString();
            edtTodo.Value = total;

            ApplicationFacade.DoEvents();
        }

        #endregion

        #endregion
    }
}