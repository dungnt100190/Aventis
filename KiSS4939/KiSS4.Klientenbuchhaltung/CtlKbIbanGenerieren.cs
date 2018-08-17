using System;
using System.Data;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung
{
    /// <summary>
    /// Control, used to generate missing iban numbers
    /// </summary>
    public partial class CtlKbIbanGenerieren : KissUserControl
    {
        #region Enumerations

        /// <summary>
        /// Filter only specified entries
        /// </summary>
        private enum FilterInstitutionPerson
        {
            /// <summary>
            /// Handle all entries
            /// </summary>
            All = 0,

            /// <summary>
            /// Handle only institutions
            /// </summary>
            OnlyInstitutions = 1,

            /// <summary>
            /// Handle only persons
            /// </summary>
            OnlyPersons = 2
        }

        #endregion

        #region Fields

        #region Private Constant/Read-Only Fields

        // qryMessage fields
        private const string MSG_BA_INSTITUTION_ID = "BaInstitutionID";

        private const string MSG_BA_PERSON_ID = "BaPersonID";
        private const string MSG_BA_ZAHLUNGSWEG_ID = "BaZahlungswegID";
        private const string MSG_BCL = "BCL";
        private const string MSG_KONTO_NR = "KontoNr";
        private const string MSG_MESSAGE = "Message";
        private const string MSG_NAME = "Name";

        // qryIBAN fields
        private const string ZAL_BANK_KONTO_NUMMER = "BankKontoNummer";

        private const string ZAL_BA_INSTITUTION_ID = "BaInstitutionID";
        private const string ZAL_BA_PERSON_ID = "BaPersonID";
        private const string ZAL_BA_ZAHLUNGSWEG_ID = "BaZahlungswegID";
        private const string ZAL_CLEARING_NR = "ClearingNr";
        private const string ZAL_EINZAHLUNGSSCHEIN_CODE = "EinzahlungsscheinCode";
        private const string ZAL_NAME = "Name";
        private const string ZAL_POST_KONTO_NUMMER = "PostKontoNummer";

        #endregion

        #region Private Fields

        private bool _isLoading;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlKbIbanGenerieren"/> class.
        /// </summary>
        public CtlKbIbanGenerieren()
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
                qryMessages.DataTable.Columns.Add(MSG_BA_INSTITUTION_ID, typeof(int));
                qryMessages.DataTable.Columns.Add(MSG_BA_PERSON_ID, typeof(int));
                qryMessages.DataTable.Columns.Add(MSG_BA_ZAHLUNGSWEG_ID, typeof(int));

                // init filter selection field
                edtAuswahl.LoadQuery(DBUtil.OpenSQL(@"
                    SELECT Code = {0},
                           Text = {1}

                    UNION

                    SELECT Code = {2},
                           Text = {3}

                    UNION

                    SELECT Code = {4},
                           Text = {5}",
                    Convert.ToInt32(FilterInstitutionPerson.All),
                    KissMsg.GetMLMessage(Name, "SelectAll", "Alle"),
                    Convert.ToInt32(FilterInstitutionPerson.OnlyInstitutions),
                    KissMsg.GetMLMessage(Name, "SelectOnlyInstitutions", "Nur Institutionen"),
                    Convert.ToInt32(FilterInstitutionPerson.OnlyPersons),
                    KissMsg.GetMLMessage(Name, "SelectOnlyPersons", "Nur Personen")));

                // select all by default
                edtAuswahl.EditValue = Convert.ToInt32(FilterInstitutionPerson.All);
            }
            finally
            {
                // reset flag
                _isLoading = false;
            }

            // update labels
            UpdateCount();
            UpdateAmount();
        }

        private void btnGotoKreditor_Click(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryMessages["BaInstitutionID"]))
            {
                FormController.OpenForm("FrmKbKlientenbuchhaltung",
                                        "Action", "OpenItem",
                                        "SubMask", "CtlKbKreditor",
                                        MSG_BA_INSTITUTION_ID,
                                        qryMessages[MSG_BA_INSTITUTION_ID],
                                        MSG_BA_ZAHLUNGSWEG_ID,
                                        qryMessages[MSG_BA_ZAHLUNGSWEG_ID]);
            }
            else if (!DBUtil.IsEmpty(qryMessages["BaPersonID"]))
            {
                FormController.OpenForm("FrmKbKlientenbuchhaltung",
                                        "Action", "OpenItem",
                                        "SubMask", "CtlKbKreditor",
                                        MSG_BA_PERSON_ID,
                                        qryMessages[MSG_BA_PERSON_ID],
                                        MSG_BA_ZAHLUNGSWEG_ID,
                                        qryMessages[MSG_BA_ZAHLUNGSWEG_ID]);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            qryMessages.PositionChanged -= qryMessages_PositionChanged;

            // validate todo
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
            int ezCode = 0;
            int todo = Convert.ToInt32(edtTodo.Value);

            // check amount
            if (todo < 1)
            {
                return;
            }

            // get data
            qryIBAN.Fill(string.Format(@"
                SELECT DISTINCT TOP {0}
                       ZAL.BaZahlungswegID,
                       ZAL.EinzahlungsscheinCode,
                       ZAL.PostKontoNummer,
                       ZAL.BankKontoNummer,
                       ZAL.IBANNummer,
                       BNK.ClearingNr,
                       [Name] = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
                       ZAL.BaInstitutionID,
                       ZAL.BaPersonID
                FROM dbo.vwBaZahlungsweg ZAL
                  LEFT JOIN dbo.BaBank   BNK ON BNK.BaBankID   = ZAL.BaBankID
                  LEFT JOIN dbo.BaPerson PRS ON PRS.BaPersonID = ZAL.BaPersonID
                WHERE ZAL.IBANNummer IS NULL
                  AND ZAL.EinzahlungsscheinCode IN (2, 3, 5)" + GetIbanSqlFilterStmt(),
                todo));

            // set cursor
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // init and show progressbar
                pgbGenerate.Minimum = 0;
                pgbGenerate.Maximum = todo;
                pgbGenerate.Value = 0;
                pgbGenerate.Visible = true;

                // clear output table
                qryMessages.DataTable.Rows.Clear();
                UpdateAmount();

                // loop entries
                foreach (DataRow row in qryIBAN.DataTable.Rows)
                {
                    try
                    {
                        // count up
                        count++;

                        // set progress
                        pgbGenerate.Value = count;
                        ApplicationFacade.DoEvents();

                        // get ezcode value
                        ezCode = Convert.ToInt32(row[ZAL_EINZAHLUNGSSCHEIN_CODE]);

                        // handle code
                        string iban;
                        switch (ezCode)
                        {
                            case 1: // OrangerEinzahlungsschein
                                {
                                    // Für ESR braucht es keine IBAN
                                    continue;
                                }
                            case 2: // Post
                                {
                                    iban = Belegleser.IBANConvert(row[ZAL_POST_KONTO_NUMMER] as string, "9000");

                                    DBUtil.ExecSQL(@"
                                        UPDATE dbo.BaZahlungsweg
                                        SET IBANNummer = {0}
                                        WHERE BaZahlungswegID = {1}", iban, Convert.ToInt32(row[ZAL_BA_ZAHLUNGSWEG_ID]));

                                    success++;
                                }
                                break;

                            case 3:
                            case 5: // Bank
                                {
                                    iban = Belegleser.IBANConvert(row[ZAL_BANK_KONTO_NUMMER] as string, row[ZAL_CLEARING_NR].ToString());

                                    DBUtil.ExecSQL(@"
                                        UPDATE dbo.BaZahlungsweg
                                        SET IBANNummer = {0}
                                        WHERE BaZahlungswegID = {1}", iban, Convert.ToInt32(row[ZAL_BA_ZAHLUNGSWEG_ID]));

                                    success++;
                                }
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        errors++;

                        bool post = (ezCode == 2);
                        string bcl = post ? "9000" : (row[ZAL_CLEARING_NR] is int ? row[ZAL_CLEARING_NR].ToString() : "");
                        string konto = post ? row[ZAL_POST_KONTO_NUMMER] as string : row[ZAL_BANK_KONTO_NUMMER] as string;

                        AddErrorRow(bcl, konto, ex.Message, row[ZAL_NAME] as string, row[ZAL_BA_INSTITUTION_ID], row[ZAL_BA_PERSON_ID], (int)row[ZAL_BA_ZAHLUNGSWEG_ID]);
                    }
                } // [foreach]
                lblSuccess.Text = success.ToString();
                lblFail.Text = errors.ToString();

                UpdateCount();
            }
            finally
            {
                // hide progressbar again
                pgbGenerate.Visible = false;

                // reset cursor
                Cursor.Current = Cursors.Default;

                qryMessages.PositionChanged += qryMessages_PositionChanged;
                qryMessages.First();
            }
        }

        private void edtAuswahl_EditValueChanged(object sender, EventArgs e)
        {
            UpdateCount();
        }

        private void qryMessages_PositionChanged(object sender, EventArgs e)
        {
            if (qryMessages[MSG_BA_PERSON_ID] is int)
            {
                ctlBaZahlungsweg.BaPersonID = (int)qryMessages[MSG_BA_PERSON_ID];
            }
            else if (qryMessages[MSG_BA_INSTITUTION_ID] is int)
            {
                ctlBaZahlungsweg.BaInstitutionID = (int)qryMessages[MSG_BA_INSTITUTION_ID];
            }

            FormController.SendMessage(ctlBaZahlungsweg, MSG_BA_ZAHLUNGSWEG_ID, (int)qryMessages[MSG_BA_ZAHLUNGSWEG_ID]);
        }

        #endregion

        #region Methods

        #region Private Methods

        private void AddErrorRow(
            string bcl,
            string konto,
            string fehler,
            string name,
            object baInstitutionID,
            object baPersonID,
            int baZahlungswegID)
        {
            DataRow row = qryMessages.DataTable.NewRow();

            row[MSG_BCL] = bcl;
            row[MSG_KONTO_NR] = konto;
            row[MSG_MESSAGE] = fehler;
            row[MSG_NAME] = name;
            row[MSG_BA_INSTITUTION_ID] = baInstitutionID;
            row[MSG_BA_PERSON_ID] = baPersonID;
            row[MSG_BA_ZAHLUNGSWEG_ID] = baZahlungswegID;
            qryMessages.DataTable.Rows.Add(row);

            btnGotoKreditor.Enabled = true;

            UpdateAmount();
        }

        private string GetIbanSqlFilterStmt()
        {
            string filter = @"";

            if (!DBUtil.IsEmpty(edtAuswahl.EditValue))
            {
                int code = Convert.ToInt32(edtAuswahl.EditValue);

                if (code == Convert.ToInt32(FilterInstitutionPerson.All))
                {
                    filter += " AND (ZAL.BaInstitutionID IS NOT NULL OR ZAL.BaPersonID IS NOT NULL)";
                }
                else if (code == Convert.ToInt32(FilterInstitutionPerson.OnlyInstitutions))
                {
                    filter += " AND ZAL.BaInstitutionID IS NOT NULL";
                }
                else if (code == Convert.ToInt32(FilterInstitutionPerson.OnlyPersons))
                {
                    filter += " AND ZAL.BaPersonID IS NOT NULL";
                }
            }

            return filter;
        }

        /// <summary>
        /// Init gui for its default mode
        /// </summary>
        private void InitGui()
        {
            btnGotoKreditor.Enabled = false;
            pgbGenerate.Visible = false;
        }

        private void UpdateAmount()
        {
            lblMessageCount.Text = string.Format("{0}: {1}", KissMsg.GetMLMessage(Name, "MessageCount", "Anzahl Einträge"), qryMessages.Count);
            ApplicationFacade.DoEvents();
        }

        private void UpdateCount()
        {
            // validate
            if (_isLoading)
            {
                // do nothing
                return;
            }

            // get count value
            int total = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
              SELECT COUNT(DISTINCT ZAL.BaZahlungswegID)
              FROM dbo.vwBaZahlungsweg ZAL
                LEFT JOIN dbo.BaBank BNK ON BNK.BaBankID = ZAL.BaBankID
              WHERE ZAL.IBANNummer IS NULL
                AND ZAL.EinzahlungsscheinCode IN (2, 3, 5)" + GetIbanSqlFilterStmt()));

            lblTotal.Text = total.ToString();
            edtTodo.Value = total;

            ApplicationFacade.DoEvents();
        }

        #endregion

        #endregion
    }
}