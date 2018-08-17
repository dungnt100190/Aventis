using System;
using System.Data;
using System.Windows.Forms;

using log4net;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.BDE
{
    public partial class DlgUserBDEDetails : KissDialog
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private Int32 _ferienKuerzungenOriginalJahr = -1; // store original year of existing datarow for FerienKuerzungen
        private Int32 _sollProJahrOriginalJahr = -1; // store original year of existing datarow for SollProJahr
        private Int32 _userID = -1; // store the userid to show (>0 are valid)

        #endregion

        #endregion

        #region Constructors

        public DlgUserBDEDetails()
        {
            InitializeComponent();

            // load warning image
            picWarningIcon.Image = KissImageList.GetLargeImage(84);

            // setup rights (do before init!)
            SetupRights();

            // load default data
            Init(-1, false, "<lastName>", "<firstName>");

            // DebugOnly:
            // Init(2, false, "Jäggi", "Christoph");
        }

        #endregion

        #region EventHandlers

        private void btnCloseDialog_Click(object sender, EventArgs e)
        {
            // save pending changes
            if (!SavePendingChanges())
            {
                // cannot close dialog
                return;
            }

            // logging
            _logger.Debug("close dialog");

            // close dialog
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnTotalAufMonateVerteilen_Click(object sender, EventArgs e)
        {
            if (qryBDESollStundenProJahr_XUser.Position >= 0)
            {
                var total = Utils.ConvertToDecimal(qryBDESollStundenProJahr_XUser[DBO.BDESollStundenProJahr_XUser.TotalStd]);
                var stdProMonat = total / 12;

                qryBDESollStundenProJahr_XUser[DBO.BDESollStundenProJahr_XUser.JanuarStd] = stdProMonat;
                qryBDESollStundenProJahr_XUser[DBO.BDESollStundenProJahr_XUser.FebruarStd] = stdProMonat;
                qryBDESollStundenProJahr_XUser[DBO.BDESollStundenProJahr_XUser.MaerzStd] = stdProMonat;
                qryBDESollStundenProJahr_XUser[DBO.BDESollStundenProJahr_XUser.AprilStd] = stdProMonat;
                qryBDESollStundenProJahr_XUser[DBO.BDESollStundenProJahr_XUser.MaiStd] = stdProMonat;
                qryBDESollStundenProJahr_XUser[DBO.BDESollStundenProJahr_XUser.JuniStd] = stdProMonat;
                qryBDESollStundenProJahr_XUser[DBO.BDESollStundenProJahr_XUser.JuliStd] = stdProMonat;
                qryBDESollStundenProJahr_XUser[DBO.BDESollStundenProJahr_XUser.AugustStd] = stdProMonat;
                qryBDESollStundenProJahr_XUser[DBO.BDESollStundenProJahr_XUser.SeptemberStd] = stdProMonat;
                qryBDESollStundenProJahr_XUser[DBO.BDESollStundenProJahr_XUser.OktoberStd] = stdProMonat;
                qryBDESollStundenProJahr_XUser[DBO.BDESollStundenProJahr_XUser.NovemberStd] = stdProMonat;
                qryBDESollStundenProJahr_XUser[DBO.BDESollStundenProJahr_XUser.DezemberStd] = stdProMonat;

                qryBDESollStundenProJahr_XUser.RefreshDisplay();
            }
        }

        private void qryBDEAusbezahlteUeberstunden_XUser_BeforePost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("current userid={0}", _userID));

            // VALIDATE
            // validate userid
            ValidateUserID();

            // validate must fields
            DBUtil.CheckNotNullField(edtAusbezahlteUeberstundenJahr, lblAusbezahlteUeberstundenJahr.Text);
            DBUtil.CheckNotNullField(edtAusbezahlteUeberstundenDatumVon, lblAusbezahlteUeberstundenDatumVon.Text);
            DBUtil.CheckNotNullField(edtAusbezahlteUeberstundenAusbezahlteStd, lblAusbezahlteUeberstundenAusbezahlteStd.Text);

            // validate Jahr
            ValidateYearValue(qryBDEAusbezahlteUeberstunden_XUser["Jahr"], edtAusbezahlteUeberstundenJahr, lblAusbezahlteUeberstundenJahr);
            ValidateYearFromYearAndDates(qryBDEAusbezahlteUeberstunden_XUser["Jahr"], qryBDEAusbezahlteUeberstunden_XUser["DatumVon"], qryBDEAusbezahlteUeberstunden_XUser["DatumBis"], edtAusbezahlteUeberstundenJahr);

            // validate ausbezahlteStd
            Decimal ausbezahlteStd = Convert.ToDecimal(qryBDEAusbezahlteUeberstunden_XUser["AusbezahlteStd"]);

            if (ausbezahlteStd < 0.0m) // no negative
            {
                edtAusbezahlteUeberstundenAusbezahlteStd.Focus();
                KissMsg.ShowError("DlgUserBDEDetails", "InvalidAusbezahlteStdValue", "Das Feld 'Ausbezahlte Stunden' darf nicht negativ sein.");
                throw new KissCancelException();
            }

            // validate dates
            if (!IsDateRangeValid(edtAusbezahlteUeberstundenDatumVon, edtAusbezahlteUeberstundenDatumBis, lblAusbezahlteUeberstundenDatumVon, lblAusbezahlteUeberstundenDatumBis))
            {
                // date order is invalid, cannot continue (message already shown)
                throw new KissCancelException();
            }

            // validate with other existing data in db depending on mode
            //   no entry is allowed within same year where DatumVon is between DatumVon..DatumBis of existing (other) entry
            //   no entry is allowed within same year where DatumBis is between DatumVon..DatumBis of existing (other) entry
            if (Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                    DECLARE @UserID INT
                    DECLARE @Jahr INT
                    DECLARE @BDEAusbezahlteUeberstunden_XUserID DATETIME
                    DECLARE @DatumVon DATETIME
                    DECLARE @DatumBis DATETIME

                    SET @UserID = ISNULL({0}, -1)
                    SET @Jahr = ISNULL({1}, -1)
                    SET @BDEAusbezahlteUeberstunden_XUserID = ISNULL({2}, -1)
                    SET @DatumVon = {3}
                    SET @DatumBis = ISNULL({4}, '9999-12-31') -- far far away...

                    SELECT COUNT(1)
                    FROM dbo.BDEAusbezahlteUeberstunden_XUser AUJ WITH(READUNCOMMITTED)
                    WHERE AUJ.UserID = @UserID AND
                          AUJ.Jahr = @Jahr AND
                          AUJ.BDEAusbezahlteUeberstunden_XUserID <> @BDEAusbezahlteUeberstunden_XUserID AND -- filter by ID of existing row to identify current row
                          ((AUJ.DatumVon <= @DatumVon AND ISNULL(AUJ.DatumBis, '9999-12-31') >= @DatumVon) OR
                           (AUJ.DatumVon <= @DatumBis AND ISNULL(AUJ.DatumBis, '9999-12-31') >= @DatumBis) OR
                           (AUJ.DatumVon >= @DatumVon AND ISNULL(AUJ.DatumBis, '9999-12-31') <= @DatumBis))
                    ", _userID, qryBDEAusbezahlteUeberstunden_XUser["Jahr"], qryBDEAusbezahlteUeberstunden_XUser["BDEAusbezahlteUeberstunden_XUserID"], qryBDEAusbezahlteUeberstunden_XUser["DatumVon"], qryBDEAusbezahlteUeberstunden_XUser["DatumBis"])) > 0)
            {
                // invalid range of datarows for DatumVon/DatumBis
                edtAusbezahlteUeberstundenDatumVon.Focus();
                KissMsg.ShowError("DlgUserBDEDetails", "InvalidAusbezahlteUeberstundenDatumVonBis", "Ungültige Datumsangabe, die Werte dürfen sich nicht mit bestehenden Einträgen im selben Jahr überschneiden.");
                throw new KissCancelException();
            }

            // SETUP FINALY DATA
            // apply userid if not yet set
            if (DBUtil.IsEmpty(qryBDEAusbezahlteUeberstunden_XUser["UserID"]))
            {
                // apply userid only if not yet set - to prevent changing userid in case of unknown bug...
                qryBDEAusbezahlteUeberstunden_XUser["UserID"] = _userID;
            }

            // set flag for manual edit
            qryBDEAusbezahlteUeberstunden_XUser["ManualEdit"] = 1;

            // logging
            _logger.Debug("done");
        }

        private void qryBDEFerienAnspruch_XUser_BeforePost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("current userid={0}", _userID));

            // VALIDATE
            // validate userid
            ValidateUserID();

            // validate must fields
            DBUtil.CheckNotNullField(edtFerienAnspruchJahr, lblFerienAnspruchJahr.Text);
            DBUtil.CheckNotNullField(edtFerienAnspruchDatumVon, lblFerienAnspruchDatumVon.Text);
            DBUtil.CheckNotNullField(edtFerienAnspruchFerienAnspruchStdProJahr, lblFerienAnspruchFerienAnspruchStdProJahr.Text);

            // validate Jahr
            ValidateYearValue(qryBDEFerienAnspruch_XUser["Jahr"], edtFerienAnspruchJahr, lblFerienAnspruchJahr);
            ValidateYearFromYearAndDates(qryBDEFerienAnspruch_XUser["Jahr"], qryBDEFerienAnspruch_XUser["DatumVon"], qryBDEFerienAnspruch_XUser["DatumBis"], edtFerienAnspruchJahr);

            // validate ferienAnspruch
            Decimal ferienAnspruch = Convert.ToDecimal(qryBDEFerienAnspruch_XUser["FerienanspruchStdProJahr"]);

            if (ferienAnspruch < 0.0m || ferienAnspruch > 8784.0m) // no negative and <= (366d*24h)
            {
                edtFerienAnspruchFerienAnspruchStdProJahr.Focus();
                KissMsg.ShowError("DlgUserBDEDetails", "InvalidFerienAnspruchValue", "Das Feld 'Ferienanspruch pro Jahr' verlangt einen Wert zwischen 0.0h und 8784.0h.");
                throw new KissCancelException();
            }

            // validate dates
            if (!IsDateRangeValid(edtFerienAnspruchDatumVon, edtFerienAnspruchDatumBis, lblFerienAnspruchDatumVon, lblFerienAnspruchDatumBis))
            {
                // date order is invalid, cannot continue (message already shown)
                throw new KissCancelException();
            }

            // validate with other existing data in db depending on mode
            //   no entry is allowed within same year where DatumVon is between DatumVon..DatumBis of existing (other) entry
            //   no entry is allowed within same year where DatumBis is between DatumVon..DatumBis of existing (other) entry
            if (Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                    DECLARE @UserID INT
                    DECLARE @Jahr INT
                    DECLARE @BDEFerienanspruch_XUserID INT
                    DECLARE @DatumVon DATETIME
                    DECLARE @DatumBis DATETIME

                    SET @UserID = ISNULL({0}, -1)
                    SET @Jahr = ISNULL({1}, -1)
                    SET @BDEFerienanspruch_XUserID = ISNULL({2}, -1)
                    SET @DatumVon = {3}
                    SET @DatumBis = ISNULL({4}, '9999-12-31') -- far far away...

                    SELECT COUNT(1)
                    FROM dbo.BDEFerienanspruch_XUser FAJ WITH(READUNCOMMITTED)
                    WHERE FAJ.UserID = @UserID AND
                          FAJ.Jahr = @Jahr AND
                          FAJ.BDEFerienanspruch_XUserID <> @BDEFerienanspruch_XUserID AND -- filter by ID of existing row to identify current row
                          ((FAJ.DatumVon <= @DatumVon AND ISNULL(FAJ.DatumBis, '9999-12-31') >= @DatumVon) OR
                           (FAJ.DatumVon <= @DatumBis AND ISNULL(FAJ.DatumBis, '9999-12-31') >= @DatumBis) OR
                           (FAJ.DatumVon >= @DatumVon AND ISNULL(FAJ.DatumBis, '9999-12-31') <= @DatumBis))
                    ", _userID, qryBDEFerienAnspruch_XUser["Jahr"], qryBDEFerienAnspruch_XUser["BDEFerienanspruch_XUserID"], qryBDEFerienAnspruch_XUser["DatumVon"], qryBDEFerienAnspruch_XUser["DatumBis"])) > 0)
            {
                // invalid range of datarows for DatumVon/DatumBis
                edtFerienAnspruchDatumVon.Focus();
                KissMsg.ShowError("DlgUserBDEDetails", "InvalidFerienAnspruchDatumVonBis", "Ungültige Datumsangabe, die Werte dürfen sich nicht mit bestehenden Einträgen im selben Jahr überschneiden.");
                throw new KissCancelException();
            }

            // SETUP FINALY DATA
            // apply userid if not yet set
            if (DBUtil.IsEmpty(qryBDEFerienAnspruch_XUser["UserID"]))
            {
                // apply userid only if not yet set - to prevent changing userid in case of unknown bug...
                qryBDEFerienAnspruch_XUser["UserID"] = _userID;
            }

            // set flag for manual edit
            qryBDEFerienAnspruch_XUser["ManualEdit"] = 1;

            // logging
            _logger.Debug("done");
        }

        private void qryBDEFerienKuerzungen_XUser_AfterPost(object sender, EventArgs e)
        {
            // redo position changed event
            qryBDEFerienKuerzungen_XUser_PositionChanged(this, EventArgs.Empty);
        }

        private void qryBDEFerienKuerzungen_XUser_BeforePost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("current userid={0}", _userID));

            // VALIDATE
            // validate userid
            ValidateUserID();

            // validate must fields
            DBUtil.CheckNotNullField(edtFerienKuerzungenJahr, lblFerienKuerzungenJahr.Text);
            DBUtil.CheckNotNullField(edtFerienKuerzungenFerienkuerzungStd, lblFerienKuerzungenFerienkuerzungStd.Text);

            // validate Jahr
            ValidateYearValue(qryBDEFerienKuerzungen_XUser["Jahr"], edtFerienKuerzungenJahr, lblFerienKuerzungenJahr);

            // validate with other existing data in db depending on mode
            //   only one entry per year and user is allowed
            if (qryBDEFerienKuerzungen_XUser.Row.RowState == DataRowState.Added || _ferienKuerzungenOriginalJahr != Convert.ToInt32(qryBDEFerienKuerzungen_XUser["Jahr"]))
            {
                // new datarow or changed year, this year is not allowed yet in database
                if (Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                        DECLARE @UserID INT
                        DECLARE @Jahr INT

                        SET @UserID = ISNULL({0}, -1)
                        SET @Jahr = ISNULL({1}, -1)

                        SELECT COUNT(1)
                        FROM dbo.BDEFerienkuerzungen_XUser FKJ WITH(READUNCOMMITTED)
                        WHERE FKJ.UserID = @UserID AND
                              FKJ.Jahr = @Jahr", _userID, qryBDEFerienKuerzungen_XUser["Jahr"])) > 0) // no row expected
                {
                    // invalid year
                    edtFerienKuerzungenJahr.Focus();
                    KissMsg.ShowError("DlgUserBDEDetails", "InvalidFerienKuerzungenJahrNew", "Ungültige Jahresangabe, pro Benutzer und Jahr ist nur ein Datensatz erlaubt.");
                    throw new KissCancelException();
                }
            }
            else
            {
                // existing datarow with unchanged year, year is only once allowed
                if (Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                        DECLARE @UserID INT
                        DECLARE @Jahr INT

                        SET @UserID = ISNULL({0}, -1)
                        SET @Jahr = ISNULL({1}, -1)

                        SELECT COUNT(1)
                        FROM dbo.BDEFerienkuerzungen_XUser FKJ WITH(READUNCOMMITTED)
                        WHERE FKJ.UserID = @UserID AND
                              FKJ.Jahr = @Jahr", _userID, qryBDEFerienKuerzungen_XUser["Jahr"])) > 1) // just one row expected
                {
                    // invalid year
                    edtFerienKuerzungenJahr.Focus();
                    KissMsg.ShowError("DlgUserBDEDetails", "InvalidFerienKuerzungenJahrOld", "Ungültige Jahresangabe, pro Benutzer und Jahr ist nur ein Datensatz erlaubt.");
                    throw new KissCancelException();
                }
            }

            // SETUP FINALY DATA
            // apply userid if not yet set
            if (DBUtil.IsEmpty(qryBDEFerienKuerzungen_XUser["UserID"]))
            {
                // apply userid only if not yet set - to prevent changing userid in case of unknown bug...
                qryBDEFerienKuerzungen_XUser["UserID"] = _userID;
            }

            // set flag for manual edit
            qryBDEFerienKuerzungen_XUser["ManualEdit"] = 1;

            // HISTORY
            // new history entry
            if (qryBDEFerienKuerzungen_XUser.RowModified)
            {
                DBUtil.NewHistoryVersion();
            }

            // logging
            _logger.Debug("done");
        }

        private void qryBDEFerienKuerzungen_XUser_PositionChanged(object sender, EventArgs e)
        {
            // store original year of current datarow
            _ferienKuerzungenOriginalJahr = DBUtil.IsEmpty(qryBDEFerienKuerzungen_XUser["Jahr"]) ? -1 : Convert.ToInt32(qryBDEFerienKuerzungen_XUser["Jahr"]);
        }

        private void qryBDEPensum_XUser_BeforePost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("current userid={0}", _userID));

            // VALIDATE
            // validate userid
            ValidateUserID();

            // validate must fields
            DBUtil.CheckNotNullField(edtPensumDatumVon, lblPensumDatumVon.Text);
            DBUtil.CheckNotNullField(edtPensumPensumProzent, lblPensumPensumProzent.Text);

            // validate PensumPercent
            Int32 pensum = Convert.ToInt32(qryBDEPensum_XUser["PensumProzent"]);

            if (pensum < 0 || pensum > 100)
            {
                edtPensumPensumProzent.Focus();
                KissMsg.ShowError("DlgUserBDEDetails", "InvalidPensumValue", "Das Feld 'Beschäftigungsgrad' verlangt einen Wert zwischen 0% und 100%.");
                throw new KissCancelException();
            }

            // validate dates
            if (!IsDateRangeValid(edtPensumDatumVon, edtPensumDatumBis, lblPensumDatumVon, lblPensumDatumBis))
            {
                // date order is invalid, cannot continue (message already shown)
                throw new KissCancelException();
            }

            // validate with other existing data in db depending on mode
            //   no entry is allowed where DatumVon is between DatumVon..DatumBis of existing (other) entry
            //   no entry is allowed where DatumBis is between DatumVon..DatumBis of existing (other) entry
            if (Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                    DECLARE @UserID INT
                    DECLARE @BDEPensum_XUserID INT
                    DECLARE @DatumVon DATETIME
                    DECLARE @DatumBis DATETIME

                    SET @UserID = ISNULL({0}, -1)
                    SET @BDEPensum_XUserID = ISNULL({1}, -1)
                    SET @DatumVon = {2}
                    SET @DatumBis = ISNULL({3}, '9999-12-31') -- far far away...

                    SELECT COUNT(1)
                    FROM dbo.BDEPensum_XUser PEN WITH(READUNCOMMITTED)
                    WHERE PEN.UserID = @UserID AND
                          PEN.BDEPensum_XUserID <> @BDEPensum_XUserID AND
                          ((PEN.DatumVon <= @DatumVon AND ISNULL(PEN.DatumBis, '9999-12-31') >= @DatumVon) OR
                           (PEN.DatumVon <= @DatumBis AND ISNULL(PEN.DatumBis, '9999-12-31') >= @DatumBis) OR
                           (PEN.DatumVon >= @DatumVon AND ISNULL(PEN.DatumBis, '9999-12-31') <= @DatumBis))
                    ", _userID, qryBDEPensum_XUser["BDEPensum_XUserID"], qryBDEPensum_XUser["DatumVon"], qryBDEPensum_XUser["DatumBis"])) > 0)
            {
                // invalid range of datarows for DatumVon/DatumBis
                edtPensumDatumVon.Focus();
                KissMsg.ShowError("DlgUserBDEDetails", "InvalidPensumDatumVonBis", "Ungültige Datumsangabe, die Werte dürfen sich nicht mit bestehenden Einträgen überschneiden.");
                throw new KissCancelException();
            }

            // SETUP FINALY DATA
            // apply userid if not yet set
            if (DBUtil.IsEmpty(qryBDEPensum_XUser["UserID"]))
            {
                // apply userid only if not yet set - to prevent changing userid in case of unknown bug...
                qryBDEPensum_XUser["UserID"] = _userID;
            }

            // set flag for manual edit
            qryBDEPensum_XUser["ManualEdit"] = 1;

            // logging
            _logger.Debug("done");
        }

        private void qryBDESollProTag_XUser_BeforePost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("current userid={0}", _userID));

            // VALIDATE
            // validate userid
            ValidateUserID();

            // validate must fields
            DBUtil.CheckNotNullField(edtSollProTagDatumVon, lblSollProTagDatumVon.Text);
            DBUtil.CheckNotNullField(edtSollProTagSollStundenProTag, lblSollProTagSollStundenProTag.Text);

            // validate SollStundenProTag
            Decimal sollStundenProTag = Convert.ToDecimal(qryBDESollProTag_XUser["SollStundenProTag"]);

            if (sollStundenProTag < 0.0m || sollStundenProTag > 24.0m)
            {
                edtSollProTagSollStundenProTag.Focus();
                KissMsg.ShowError("DlgUserBDEDetails", "InvalidSollProTagValue", "Das Feld 'Soll Stunden pro Tag' verlangt einen Wert zwischen 0.0h und 24.0h.");
                throw new KissCancelException();
            }

            // validate dates
            if (!IsDateRangeValid(edtSollProTagDatumVon, edtSollProTagDatumBis, lblSollProTagDatumVon, lblSollProTagDatumBis))
            {
                // date order is invalid, cannot continue (message already shown)
                throw new KissCancelException();
            }

            // validate with other existing data in db depending on mode
            //   no entry is allowed where DatumVon is between DatumVon..DatumBis of existing (other) entry
            //   no entry is allowed where DatumBis is between DatumVon..DatumBis of existing (other) entry
            if (Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                    DECLARE @UserID INT
                    DECLARE @BDESollProTag_XUserID INT
                    DECLARE @DatumVon DATETIME
                    DECLARE @DatumBis DATETIME

                    SET @UserID = ISNULL({0}, -1)
                    SET @BDESollProTag_XUserID = ISNULL({1}, -1)
                    SET @DatumVon = {2}
                    SET @DatumBis = ISNULL({3}, '9999-12-31') -- far far away...

                    SELECT COUNT(1)
                    FROM dbo.BDESollProTag_XUser SPT WITH(READUNCOMMITTED)
                    WHERE SPT.UserID = @UserID AND
                          SPT.BDESollProTag_XUserID <> @BDESollProTag_XUserID AND
                          ((SPT.DatumVon <= @DatumVon AND ISNULL(SPT.DatumBis, '9999-12-31') >= @DatumVon) OR
                           (SPT.DatumVon <= @DatumBis AND ISNULL(SPT.DatumBis, '9999-12-31') >= @DatumBis) OR
                           (SPT.DatumVon >= @DatumVon AND ISNULL(SPT.DatumBis, '9999-12-31') <= @DatumBis))
                    ", _userID, qryBDESollProTag_XUser["BDESollProTag_XUserID"], qryBDESollProTag_XUser["DatumVon"], qryBDESollProTag_XUser["DatumBis"])) > 0)
            {
                // invalid range of datarows for DatumVon/DatumBis
                edtSollProTagDatumVon.Focus();
                KissMsg.ShowError("DlgUserBDEDetails", "InvalidSollProTagDatumVonBis", "Ungültige Datumsangabe, die Werte dürfen sich nicht mit bestehenden Einträgen überschneiden.");
                throw new KissCancelException();
            }

            // SETUP FINALY DATA
            // apply userid if not yet set
            if (DBUtil.IsEmpty(qryBDESollProTag_XUser["UserID"]))
            {
                // apply userid only if not yet set - to prevent changing userid in case of unknown bug...
                qryBDESollProTag_XUser["UserID"] = _userID;
            }

            // set flag for manual edit
            qryBDESollProTag_XUser["ManualEdit"] = 1;

            // logging
            _logger.Debug("done");
        }

        private void qryBDESollStundenProJahr_XUser_AfterPost(object sender, EventArgs e)
        {
            // redo position changed event
            qryBDESollStundenProJahr_XUser_PositionChanged(this, EventArgs.Empty);
        }

        private void qryBDESollStundenProJahr_XUser_BeforePost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("current userid={0}", _userID));

            // VALIDATE
            // validate userid
            ValidateUserID();

            // validate must fields
            DBUtil.CheckNotNullField(edtSollProJahrJahr, lblSollProJahrJahr.Text);
            DBUtil.CheckNotNullField(edtSollProJahrJanuarStd, lblSollProJahrJanuarStd.Text);
            DBUtil.CheckNotNullField(edtSollProJahrFebruarStd, lblSollProJahrFebruarStd.Text);
            DBUtil.CheckNotNullField(edtSollProJahrMaerzStd, lblSollProJahrMaerzStd.Text);
            DBUtil.CheckNotNullField(edtSollProJahrAprilStd, lblSollProJahrAprilStd.Text);
            DBUtil.CheckNotNullField(edtSollProJahrMaiStd, lblSollProJahrMaiStd.Text);
            DBUtil.CheckNotNullField(edtSollProJahrJuniStd, lblSollProJahrJuniStd.Text);
            DBUtil.CheckNotNullField(edtSollProJahrJuliStd, lblSollProJahrJuliStd.Text);
            DBUtil.CheckNotNullField(edtSollProJahrAugustStd, lblSollProJahrAugustStd.Text);
            DBUtil.CheckNotNullField(edtSollProJahrSeptemberStd, lblSollProJahrSeptemberStd.Text);
            DBUtil.CheckNotNullField(edtSollProJahrOktoberStd, lblSollProJahrOktoberStd.Text);
            DBUtil.CheckNotNullField(edtSollProJahrNovemberStd, lblSollProJahrNovemberStd.Text);
            DBUtil.CheckNotNullField(edtSollProJahrDezemberStd, lblSollProJahrDezemberStd.Text);

            // validate Jahr
            ValidateYearValue(qryBDESollStundenProJahr_XUser["Jahr"], edtSollProJahrJahr, lblSollProJahrJahr);

            // validate JanStd..DezStd
            Decimal janStd = Convert.ToDecimal(qryBDESollStundenProJahr_XUser["JanuarStd"]);
            Decimal febStd = Convert.ToDecimal(qryBDESollStundenProJahr_XUser["FebruarStd"]);
            Decimal mrzStd = Convert.ToDecimal(qryBDESollStundenProJahr_XUser["MaerzStd"]);
            Decimal aprStd = Convert.ToDecimal(qryBDESollStundenProJahr_XUser["AprilStd"]);
            Decimal maiStd = Convert.ToDecimal(qryBDESollStundenProJahr_XUser["MaiStd"]);
            Decimal junStd = Convert.ToDecimal(qryBDESollStundenProJahr_XUser["JuniStd"]);
            Decimal julStd = Convert.ToDecimal(qryBDESollStundenProJahr_XUser["JuliStd"]);
            Decimal augStd = Convert.ToDecimal(qryBDESollStundenProJahr_XUser["AugustStd"]);
            Decimal sepStd = Convert.ToDecimal(qryBDESollStundenProJahr_XUser["SeptemberStd"]);
            Decimal oktStd = Convert.ToDecimal(qryBDESollStundenProJahr_XUser["OktoberStd"]);
            Decimal novStd = Convert.ToDecimal(qryBDESollStundenProJahr_XUser["NovemberStd"]);
            Decimal dezStd = Convert.ToDecimal(qryBDESollStundenProJahr_XUser["DezemberStd"]);

            ValidateSollStdProMonat(janStd, 31, edtSollProJahrJanuarStd, lblSollProJahrJanuarStd.Text);
            ValidateSollStdProMonat(febStd, 29, edtSollProJahrFebruarStd, lblSollProJahrFebruarStd.Text);
            ValidateSollStdProMonat(mrzStd, 31, edtSollProJahrMaerzStd, lblSollProJahrMaerzStd.Text);
            ValidateSollStdProMonat(aprStd, 30, edtSollProJahrAprilStd, lblSollProJahrAprilStd.Text);
            ValidateSollStdProMonat(maiStd, 31, edtSollProJahrMaiStd, lblSollProJahrMaiStd.Text);
            ValidateSollStdProMonat(junStd, 30, edtSollProJahrJuniStd, lblSollProJahrJuniStd.Text);
            ValidateSollStdProMonat(julStd, 31, edtSollProJahrJuliStd, lblSollProJahrJuliStd.Text);
            ValidateSollStdProMonat(augStd, 31, edtSollProJahrAugustStd, lblSollProJahrAugustStd.Text);
            ValidateSollStdProMonat(sepStd, 30, edtSollProJahrSeptemberStd, lblSollProJahrSeptemberStd.Text);
            ValidateSollStdProMonat(oktStd, 31, edtSollProJahrOktoberStd, lblSollProJahrOktoberStd.Text);
            ValidateSollStdProMonat(novStd, 30, edtSollProJahrNovemberStd, lblSollProJahrNovemberStd.Text);
            ValidateSollStdProMonat(dezStd, 31, edtSollProJahrDezemberStd, lblSollProJahrDezemberStd.Text);

            // validate with other existing data in db depending on mode
            //   only one entry per year and user is allowed
            if (qryBDESollStundenProJahr_XUser.Row.RowState == DataRowState.Added || _sollProJahrOriginalJahr != Convert.ToInt32(qryBDESollStundenProJahr_XUser["Jahr"]))
            {
                // new datarow or changed year, this year is not allowed yet in database
                if (Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                        DECLARE @UserID INT
                        DECLARE @Jahr INT

                        SET @UserID = ISNULL({0}, -1)
                        SET @Jahr = ISNULL({1}, -1)

                        SELECT COUNT(1)
                        FROM dbo.BDESollStundenProJahr_XUser SPJ WITH(READUNCOMMITTED)
                        WHERE SPJ.UserID = @UserID AND
                              SPJ.Jahr = @Jahr", _userID, qryBDESollStundenProJahr_XUser["Jahr"])) > 0) // no row expected
                {
                    // invalid year
                    edtSollProJahrJahr.Focus();
                    KissMsg.ShowError("DlgUserBDEDetails", "InvalidSollProTagJahrNew", "Ungültige Jahresangabe, pro Benutzer und Jahr ist nur ein Datensatz erlaubt.");
                    throw new KissCancelException();
                }
            }
            else
            {
                // existing datarow with unchanged year, year is only once allowed
                if (Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                        DECLARE @UserID INT
                        DECLARE @Jahr INT

                        SET @UserID = ISNULL({0}, -1)
                        SET @Jahr = ISNULL({1}, -1)

                        SELECT COUNT(1)
                        FROM dbo.BDESollStundenProJahr_XUser SPJ WITH(READUNCOMMITTED)
                        WHERE SPJ.UserID = @UserID AND
                              SPJ.Jahr = @Jahr", _userID, qryBDESollStundenProJahr_XUser["Jahr"])) > 1) // just one row expected
                {
                    // invalid year
                    edtSollProJahrJahr.Focus();
                    KissMsg.ShowError("DlgUserBDEDetails", "InvalidSollProTagJahrOld", "Ungültige Jahresangabe, pro Benutzer und Jahr ist nur ein Datensatz erlaubt.");
                    throw new KissCancelException();
                }
            }

            // SETUP FINALY DATA
            // apply userid if not yet set
            if (DBUtil.IsEmpty(qryBDESollStundenProJahr_XUser["UserID"]))
            {
                // apply userid only if not yet set - to prevent changing userid in case of unknown bug...
                qryBDESollStundenProJahr_XUser["UserID"] = _userID;
            }

            // calc total amount
            qryBDESollStundenProJahr_XUser["TotalStd"] = janStd + febStd + mrzStd + aprStd + maiStd + junStd + julStd + augStd + sepStd + oktStd + novStd + dezStd;

            // set flag for manual edit
            qryBDESollStundenProJahr_XUser["ManualEdit"] = 1;

            // HISTORY
            // new history entry
            if (qryBDESollStundenProJahr_XUser.RowModified)
            {
                DBUtil.NewHistoryVersion();
            }

            // logging
            _logger.Debug("done");
        }

        private void qryBDESollStundenProJahr_XUser_PositionChanged(object sender, EventArgs e)
        {
            // store original year of current datarow
            _sollProJahrOriginalJahr = DBUtil.IsEmpty(qryBDESollStundenProJahr_XUser["Jahr"]) ? -1 : Convert.ToInt32(qryBDESollStundenProJahr_XUser["Jahr"]);

            //
        }

        private void tabUserBDEDetails_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("current userid={0}", _userID));

            // logging
            _logger.Debug(String.Format("tabUserBDEDetails.SelectedTabIndex={0}", tabUserBDEDetails.SelectedTabIndex));

            // reset active sqlquery to prevent having wrong query
            ActiveSQLQuery = null;

            // tabpage depending action
            switch (tabUserBDEDetails.SelectedTabIndex)
            {
                case 0:
                    // pensum

                    // logging
                    _logger.Debug("Pensum");

                    // set query as active and setup fields
                    ActiveSQLQuery = qryBDEPensum_XUser;
                    qryBDEPensum_XUser.EnableBoundFields();
                    break;

                case 1:
                    // soll pro tag

                    // logging
                    _logger.Debug("SollProTag");

                    // set query as active
                    ActiveSQLQuery = qryBDESollProTag_XUser;
                    qryBDESollProTag_XUser.EnableBoundFields();
                    break;

                case 2:
                    // soll pro jahr

                    // logging
                    _logger.Debug("SollProJahr");

                    // set query as active
                    ActiveSQLQuery = qryBDESollStundenProJahr_XUser;
                    qryBDESollStundenProJahr_XUser.EnableBoundFields();
                    break;

                case 3:
                    // ferienanspruch

                    // logging
                    _logger.Debug("FerienAnspruch");

                    // set query as active
                    ActiveSQLQuery = qryBDEFerienAnspruch_XUser;
                    qryBDEFerienAnspruch_XUser.EnableBoundFields();
                    break;

                case 4:
                    // ferien zugaben/kuerzungen

                    // logging
                    _logger.Debug("FerienZugabenKuerzungen");

                    // set query as active
                    ActiveSQLQuery = qryBDEFerienKuerzungen_XUser;
                    qryBDEFerienKuerzungen_XUser.EnableBoundFields();
                    break;

                case 5:
                    // ausbezahlte ueberstunden

                    // logging
                    _logger.Debug("AusbezahlteUeberstunden");

                    // set query as active
                    ActiveSQLQuery = qryBDEAusbezahlteUeberstunden_XUser;
                    qryBDEAusbezahlteUeberstunden_XUser.EnableBoundFields();
                    break;

                default:
                    // invalid tabpage, do not set an active sqlquery

                    // logging
                    _logger.Warn("Invalid tabPage selected, case should not occure!");

                    // set query as active
                    ActiveSQLQuery = null;
                    break;
            }

            // logging
            _logger.Debug(String.Format("DlgUserBDEDetails.ActiveSQLQuery={0}", ActiveSQLQuery));
            _logger.Debug("done");
        }

        private void tabUserBDEDetails_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("current userid={0}", _userID));

            // save changes and allow to switch tab only if ok
            e.Cancel = !SavePendingChanges();

            // logging
            _logger.Debug("done");
        }

        #endregion

        #region Methods

        #region Public Methods

        public bool Init(Int32 userID)
        {
            var manualEdit = DBUtil.GetConfigBool(@"System\Benutzerverwaltung\Benutzer\ManuelleBearbeitung", false);

            var qryUser = DBUtil.OpenSQL(@"
                SELECT FirstName, LastName
                FROM dbo.XUser WITH (READUNCOMMITTED)
                WHERE UserID = {0}",
                userID);

            var firstName = qryUser[DBO.XUser.FirstName].ToString();
            var lastName = qryUser[DBO.XUser.LastName].ToString();

            return Init(userID, manualEdit, firstName, lastName);
        }

        public bool Init(Int32 userID, Boolean manualEdit, String firstName, String lastName)
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("userID={0}, manualEdit={1}, firstName={2}, lastName={3}", userID, manualEdit, firstName, lastName));

            // INIT
            // apply fields
            _userID = userID;

            // apply username
            lblUserName.Text = String.Format("{0}, {1} (Nr. {2})", lastName, firstName, userID);

            // show/hide top-panel-warning depending on edit-mode
            panTopWarning.Visible = !manualEdit;

            // LOAD DATA
            // pensum
            qryBDEPensum_XUser.Fill(@"
                    SELECT PEN.*
                    FROM dbo.BDEPensum_XUser PEN WITH(READUNCOMMITTED)
                    WHERE PEN.UserID={0}
                    ORDER BY PEN.DatumVon, PEN.DatumBis, PEN.BDEPensum_XUserID", userID);

            // soll pro tag
            qryBDESollProTag_XUser.Fill(@"
                    SELECT SPT.*
                    FROM dbo.BDESollProTag_XUser SPT WITH(READUNCOMMITTED)
                    WHERE SPT.UserID={0}
                    ORDER BY SPT.DatumVon, SPT.DatumBis, SPT.BDESollProTag_XUserID", userID);

            // soll pro jahr
            qryBDESollStundenProJahr_XUser.Fill(@"
                    SELECT SPJ.*
                    FROM dbo.BDESollStundenProJahr_XUser SPJ WITH(READUNCOMMITTED)
                    WHERE SPJ.UserID={0}
                    ORDER BY SPJ.Jahr, SPJ.JanuarStd, SPJ.DezemberStd", userID);

            // ferienanspruch
            qryBDEFerienAnspruch_XUser.Fill(@"
                    SELECT FAJ.*
                    FROM dbo.BDEFerienanspruch_XUser FAJ WITH(READUNCOMMITTED)
                    WHERE FAJ.UserID={0}
                    ORDER BY FAJ.Jahr, FAJ.DatumVon, FAJ.DatumBis, FAJ.BDEFerienanspruch_XUserID", userID);

            // ferien zugaben/kuerzungen
            qryBDEFerienKuerzungen_XUser.Fill(@"
                    SELECT FKJ.*
                    FROM dbo.BDEFerienkuerzungen_XUser FKJ WITH(READUNCOMMITTED)
                    WHERE FKJ.UserID={0}
                    ORDER BY FKJ.Jahr, FKJ.FerienkuerzungStd", userID);

            // ausbezahlte ueberstunden
            qryBDEAusbezahlteUeberstunden_XUser.Fill(@"
                    SELECT AUJ.*
                    FROM dbo.BDEAusbezahlteUeberstunden_XUser AUJ WITH(READUNCOMMITTED)
                    WHERE AUJ.UserID={0}
                    ORDER BY AUJ.Jahr, AUJ.DatumVon, AUJ.DatumBis, AUJ.BDEAusbezahlteUeberstunden_XUserID", userID);

            // switch to first tab and init query
            tabUserBDEDetails.SelectTab(tpgPensum);
            tabUserBDEDetails_SelectedTabChanged(tabUserBDEDetails.SelectedTab);

            // logging
            _logger.Debug("done");

            // good
            return true;
        }

        public override bool OnAddData()
        {
            // first, let base do stuff
            Boolean retValue = base.OnAddData();

            // depending on result, do select the first control on tabPage
            if (retValue)
            {
                switch (tabUserBDEDetails.SelectedTabIndex)
                {
                    case 0:
                        // pensum
                        edtPensumDatumVon.Focus();
                        break;

                    case 1:
                        // soll pro tag
                        edtSollProTagDatumVon.Focus();
                        break;

                    case 2:
                        // soll pro jahr
                        edtSollProJahrJahr.Focus();
                        break;

                    case 3:
                        // ferienanspruch
                        edtFerienAnspruchJahr.Focus();
                        break;

                    case 4:
                        // ferien zugaben/kuerzungen
                        edtFerienKuerzungenJahr.Focus();
                        break;

                    case 5:
                        // ausbezahlte ueberstunden
                        edtAusbezahlteUeberstundenJahr.Focus();
                        break;

                    default:
                        // invalid tabpage, do not set an active sqlquery

                        // logging
                        _logger.Warn("Invalid tabPage selected, case should not occure!");
                        break;
                }
            }

            // return result from base call
            return retValue;
        }

        #endregion

        #region Private Methods

        private bool IsDateRangeValid(KissDateEdit edtDateFrom, KissDateEdit edtDateTo, KissLabel lblDateFrom, KissLabel lblDateTo)
        {
            // validate controls
            if (edtDateFrom == null || edtDateTo == null || lblDateFrom == null || lblDateTo == null)
            {
                // invalid controls
                KissMsg.ShowError("DlgUserBDEDetails", "InvalidControlsToCheck", "Ungültige Controls, es müssen alle Controls instanziert sein.");
                return false;
            }

            // validate values
            //   1.) if only datefrom is given (infinit dateto)
            if (!DBUtil.IsEmpty(edtDateFrom.EditValue) && DBUtil.IsEmpty(edtDateTo.EditValue))
            {
                // only datefrom is given and set, we do not need to check any other values
                return true;
            }

            //   2.) if both dates are given
            if (DBUtil.IsEmpty(edtDateFrom.EditValue) || DBUtil.IsEmpty(edtDateTo.EditValue) || DBUtil.IsEmpty(lblDateFrom.Text) || DBUtil.IsEmpty(lblDateTo.Text))
            {
                // invalid controls
                KissMsg.ShowError("DlgUserBDEDetails", "EmptyControlsToCheck", "Keinen Wert vorhanden, es muss für alle Controls einen Wert vorhanden sein.");
                return false;
            }

            // check if date-range is valid
            if (Convert.ToDateTime(edtDateFrom.EditValue) > Convert.ToDateTime(edtDateTo.EditValue))
            {
                // invalid range
                KissMsg.ShowError("DlgUserBDEDetails", "InvalidDateRange", "Das Datum '{0}' ist ungültig - es darf nicht kleiner als das Datum '{1}' sein.", null, null, 0, 0, lblDateFrom.Text, lblDateTo.Text);
                return false;
            }

            // if we are here, everything is ok
            return true;
        }

        private bool SavePendingChanges()
        {
            // check if we have an active sqlquery set
            if (ActiveSQLQuery != null)
            {
                // we have one, try to save data
                return ActiveSQLQuery.Post();
            }

            // no problem if no query
            return true;
        }

        private void SetupRights()
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("current userid={0}", _userID));

            // VARS
            bool isAdmin = Session.User.IsUserAdmin;

            bool canReadData;
            bool canUserInsert;
            bool canUserUpdate;
            bool canUserDelete;

            // set values
            Session.GetUserRight(Name, out canReadData, out canUserInsert, out canUserUpdate, out canUserDelete);
            if (!canReadData)
            {
                // no rights to view this control
                throw new Exception("No rights to view details of this control.");
            }

            // logger
            _logger.Debug(String.Format("isAdmin={0}, canReadData={1}, canUserInsert={2}, canUserUpdate={3}, canUserDelete={4}",
                         isAdmin, canReadData, canUserInsert, canUserUpdate, canUserDelete));

            // PENSUM
            qryBDEPensum_XUser.CanInsert = isAdmin || canUserInsert;
            qryBDEPensum_XUser.CanUpdate = isAdmin || canUserUpdate;
            qryBDEPensum_XUser.CanDelete = isAdmin || canUserDelete;

            // SOLL PRO TAG
            qryBDESollProTag_XUser.CanInsert = isAdmin || canUserInsert;
            qryBDESollProTag_XUser.CanUpdate = isAdmin || canUserUpdate;
            qryBDESollProTag_XUser.CanDelete = isAdmin || canUserDelete;

            // SOLL PRO JAHR
            qryBDESollStundenProJahr_XUser.CanInsert = isAdmin || canUserInsert;
            qryBDESollStundenProJahr_XUser.CanUpdate = isAdmin || canUserUpdate;
            qryBDESollStundenProJahr_XUser.CanDelete = isAdmin || canUserDelete;

            // FERIENANSPRUCH
            qryBDEFerienAnspruch_XUser.CanInsert = isAdmin || canUserInsert;
            qryBDEFerienAnspruch_XUser.CanUpdate = isAdmin || canUserUpdate;
            qryBDEFerienAnspruch_XUser.CanDelete = isAdmin || canUserDelete;

            // FERIEN ZUGABEN/KUERZUNGEN
            qryBDEFerienKuerzungen_XUser.CanInsert = isAdmin || canUserInsert;
            qryBDEFerienKuerzungen_XUser.CanUpdate = isAdmin || canUserUpdate;
            qryBDEFerienKuerzungen_XUser.CanDelete = isAdmin || canUserDelete;

            // AUSBEZAHLTE UEBERSTUNDEN
            qryBDEAusbezahlteUeberstunden_XUser.CanInsert = isAdmin || canUserInsert;
            qryBDEAusbezahlteUeberstunden_XUser.CanUpdate = isAdmin || canUserUpdate;
            qryBDEAusbezahlteUeberstunden_XUser.CanDelete = isAdmin || canUserDelete;

            // FIELDS
            qryBDEPensum_XUser.EnableBoundFields();
            qryBDESollProTag_XUser.EnableBoundFields();
            qryBDESollStundenProJahr_XUser.EnableBoundFields();
            qryBDEFerienAnspruch_XUser.EnableBoundFields();
            qryBDEFerienKuerzungen_XUser.EnableBoundFields();
            qryBDEAusbezahlteUeberstunden_XUser.EnableBoundFields();

            // logging
            _logger.Debug("done");
        }

        private void ValidateSollStdProMonat(decimal sollStd, int amountOfDays, KissCalcEdit edtSollStd, string fieldName)
        {
            // maximal hours per month
            Decimal hoursMax = 744.0m; // default: 31d (31d*24h=744h)

            switch (amountOfDays)
            {
                case 29:
                    hoursMax = 696.0m; // feb: maxium 29d
                    break;

                case 30:
                    hoursMax = 720.0m; // 30d
                    break;
            }

            // validate hours
            if (sollStd < 0.0m || sollStd > hoursMax)
            {
                // check if we have any field to focus
                if (edtSollStd != null)
                {
                    edtSollStd.Focus();
                }

                // show error and throw cancel
                KissMsg.ShowError("DlgUserBDEDetails", "InvalidSollProJahrStd", "Das Feld '{0}' verlangt einen Wert zwischen 0.0h und {1}h.", null, null, 0, 0, fieldName, hoursMax);
                throw new KissCancelException();
            }

            // everything ok
            return;
        }

        private void ValidateUserID()
        {
            // check if we have a valid userid set
            if (_userID < 1)
            {
                // cannot save data to this id
                KissMsg.ShowError("DlgUserBDEDetails", "ValidationOnPostInvalidUserID", "Die angegebene UserID ist ungültig, es können keine Daten gespeichert werden.");
                throw new KissCancelException();
            }
        }

        private void ValidateYearFromYearAndDates(object columnYear, object columnDateFrom, object columnDateTo, KissCalcEdit edtYear)
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("columnYear={0}, columnDateFrom={1}, columnDateTo={2}", columnYear, columnDateFrom, columnDateTo));

            // validate values if empty and valid type
            if (DBUtil.IsEmpty(columnYear) || DBUtil.IsEmpty(columnDateFrom) ||
                !(columnYear is Int32) || !(columnDateFrom is DateTime) ||
                (!DBUtil.IsEmpty(columnDateTo) && !(columnDateTo is DateTime)))
            {
                // logging
                _logger.Debug("empty year-values");

                // show message
                KissMsg.ShowError("DlgUserBDEDetails", "ValidationYearFromDatesEmpty", "Für die Jahresüberprüfung sind nicht alle Mussfelder richtig ausgefüllt.");

                // set focus if possible
                if (edtYear != null)
                {
                    edtYear.Focus();
                }

                // cancel here
                throw new KissCancelException();
            }

            // get values
            Int32 yearValue = Convert.ToInt32(columnYear);
            Int32 yearDateTo = Convert.ToDateTime(columnDateFrom).Year;

            // validate
            if (yearValue != yearDateTo || (!DBUtil.IsEmpty(columnDateTo) && yearValue != Convert.ToDateTime(columnDateTo).Year))
            {
                // logging
                _logger.Debug("invalid years");

                // show message
                KissMsg.ShowError("DlgUserBDEDetails", "ValidationYearFromDatesInvalid", "Die Jahreszahlen müssen übereinstimmen.");

                // set focus if possible
                if (edtYear != null)
                {
                    edtYear.Focus();
                }

                // cancel here
                throw new KissCancelException();
            }

            // logging
            _logger.Debug("done");
        }

        private void ValidateYearValue(object columnYearValue, KissCalcEdit edtYear, KissLabel lblYear)
        {
            // setup vars
            String yearLabel = lblYear == null ? "<Year>" : lblYear.Text;

            // validate if empty
            if (DBUtil.IsEmpty(columnYearValue) || !(columnYearValue is Int32))
            {
                // show message
                KissMsg.ShowError("DlgUserBDEDetails", "ValidationYearEmpty", "Das Feld '{0}' verlangt eine numerische Eingabe.", null, null, 0, 0, yearLabel);

                // set focus if possible
                if (edtYear != null)
                {
                    edtYear.Focus();
                }

                // cancel here
                throw new KissCancelException();
            }

            // validate value
            if (Convert.ToInt32(columnYearValue) < 2000 || Convert.ToInt32(columnYearValue) > 2099)
            {
                // show message
                KissMsg.ShowError("DlgUserBDEDetails", "ValidationYearValueInvalid", "Das Feld '{0}' verlangt einen Wert im 21. Jahrhundert.", null, null, 0, 0, yearLabel);

                // set focus if possible
                if (edtYear != null)
                {
                    edtYear.Focus();
                }

                // cancel here
                throw new KissCancelException();
            }
        }

        #endregion

        #endregion
    }
}