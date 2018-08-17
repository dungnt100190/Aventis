using System;
using System.Data;
using System.Drawing;
using System.Security;
using DevExpress.XtraGrid.Views.Base;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung.PI
{
    public partial class CtlMyKiSS : KissUserControl
    {
        private string CLASSNAME = "CtlMyKiSS";

        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private int _userID = -1; // store userID of showing-user

        #endregion

        #endregion

        #region Constructors

        public CtlMyKiSS()
        {
            InitializeComponent();

            // logging
            _logger.Debug("enter");

            // setup rights
            SetupRights();

            // init with given userid
            Init(Session.User.UserID);

            // logging
            _logger.Debug("done");

            Utils.SetStatusImageRepository(repStatusImage, "GvStatus", Session.User.LanguageCode);
        }

        #endregion

        #region EventHandlers

        private void btnApplyUserID_Click(object sender, EventArgs e)
        {
            // check if button can be used
            if (!btnApplyUserID.Enabled)
            {
                // do nothing
                return;
            }

            // check if any user was selected
            if (DBUtil.IsEmpty(edtUserID.LookupID))
            {
                // set focus
                edtUserID.Focus();

                // show message
                KissMsg.ShowInfo(CLASSNAME, "NoUserIDToApply", "Bitte zuerst einen Benutzer angeben.");

                // cancel
                return;
            }

            // everything ok, init gui for desired userid
            Init(Convert.ToInt32(edtUserID.LookupID));
        }

        private void grvAbmachungen_CustomDrawCell(Object sender, RowCellCustomDrawEventArgs e)
        {
            try
            {
                // get value
                var objDateTermin = grvAbmachungen.GetRowCellValue(e.RowHandle, grvAbmachungen.Columns["Termin"]);

                // check value (if empty or expired, draw row red)
                if (!DBUtil.IsEmpty(objDateTermin) && Convert.ToDateTime(objDateTermin) < DateTime.Today)
                {
                    // row font is red
                    e.Appearance.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                // logging
                _logger.DebugFormat("Error: {0}", ex.Message);
            }
        }

        private void grvUnerledigteAuflagen_CustomDrawCell(Object sender, RowCellCustomDrawEventArgs e)
        {
            try
            {
                // get value
                var objDateFrist = grvUnerledigteAuflagen.GetRowCellValue(e.RowHandle, /*grvUnerledigteAuflagen.Columns["Frist"]*/ "Frist");

                // check value (if empty or expired, draw row red)
                if (!DBUtil.IsEmpty(objDateFrist) && Convert.ToDateTime(objDateFrist) < DateTime.Today)
                {
                    // row font is red
                    e.Appearance.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                // logging
                _logger.DebugFormat("Error: {0}", ex.Message);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnRefreshData()
        {
            // logging
            _logger.Debug("enter");

            // let base do stuff
            base.OnRefreshData();

            // refresh all queries
            qryAbmachungen.Refresh();
            qryZielvereinbarungen.Refresh();
            qryVollmachten.Refresh();
            qryGesuchverwaltung.Refresh();
            qryUnerledigteAuflagen.Refresh();

            // logging
            _logger.Debug("done");
        }

        public override void Translate()
        {
            // logging
            _logger.Debug("enter");

            // apply translation
            base.Translate();

            // reset title due to translation
            SetupTitle(_userID);

            // setup groupbox-titles
            SetupGroupBoxTitles();

            // logging
            _logger.Debug("done");
        }

        #endregion

        #region Private Static Methods

        private static void FillSqlQuery(SqlQuery qry, int userID, string resultTable)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("userID='{0}', resultTable='{1}'", userID, resultTable);

            // fill data with given userid and result table
            if (!qry.Fill(@"EXEC dbo.spFaGetMyKiSSData {0}, {1}, NULL, {2}", userID, Session.User.LanguageCode, resultTable))
            {
                // fill did not successfully finish
                throw new DataException(string.Format("Error loading data for given parameters (userID='{0}', resultTable='{1}')", userID, resultTable));
            }

            // logging
            _logger.Debug("done");
        }

        #endregion

        #region Private Methods

        private void Init(int userID)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("userID='{0}'", userID);

            try
            {
                // store userID
                _userID = userID;

                // setup title
                SetupTitle(userID);

                // load data
                LoadData(userID);

                // setup groupbox-titles
                SetupGroupBoxTitles();
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(CLASSNAME, "ErrorInitWithUserID", "Es ist ein Fehler beim Laden der Daten aufgetreten (UserID='{0}'). Die Anzeige ist möglicherweise nicht korrekt.", null, ex, 0, 0, userID);
            }

            // logging
            _logger.Debug("done");
        }

        private void LoadData(int userID)
        {
            // logging
            _logger.Debug("enter");

            // load data for given user
            FillSqlQuery(qryAbmachungen, userID, "abmachungen");
            FillSqlQuery(qryZielvereinbarungen, userID, "zielvereinbarungen");
            FillSqlQuery(qryVollmachten, userID, "vollmachten");
            FillSqlQuery(qryGesuchverwaltung, userID, "gesuchverwaltung");
            FillSqlQuery(qryUnerledigteAuflagen, userID, "unerledigteAuflagen");

            // logging
            _logger.Debug("done");
        }

        private void SetupGroupBoxTitles()
        {
            // logging
            _logger.Debug("enter");

            // setup groupbox-titles
            grpAbmachungen.Text = KissMsg.GetMLMessage(CLASSNAME, "GroupAbmachungen", "Nicht erledigte Abmachungen ({0})", KissMsgCode.Text, qryAbmachungen.Count);
            grpZielvereinbarungen.Text = KissMsg.GetMLMessage(CLASSNAME, "GroupZielvereinbarungen", "Nicht evaluierte Zielvereinbarungen ({0})", KissMsgCode.Text, qryZielvereinbarungen.Count);
            grpVollmachten.Text = KissMsg.GetMLMessage(CLASSNAME, "GroupVollmachten", "Laufende Vollmachten ({0})", KissMsgCode.Text, qryVollmachten.Count);
            grpGesuchverwaltung.Text = KissMsg.GetMLMessage(CLASSNAME, "GroupGesuchverwaltung", "Gesuchverwaltung ({0})", KissMsgCode.Text, qryGesuchverwaltung.Count);
            grpUnerledigteAuflagen.Text = KissMsg.GetMLMessage(CLASSNAME, "GroupUnerledigteAuflagen", "Unerledigte Auflagen ({0})", KissMsgCode.Text, qryUnerledigteAuflagen.Count);

            // logging
            _logger.Debug("done");
        }

        private void SetupRights()
        {
            // logging
            _logger.Debug("enter");

            // VARS
            bool isAdmin = Session.User.IsUserAdmin;
            bool canReadData, canUserInsert, canUserUpdate, canUserDelete;

            // set values
            Session.GetUserRight(CLASSNAME, out canReadData, out canUserInsert, out canUserUpdate, out canUserDelete);

            // check rights to access control
            if (!canReadData)
            {
                // no rights to view this control
                throw new SecurityException("No rights to view details of this control.");
            }

            // logging
            _logger.DebugFormat("isAdmin='{0}', canReadData='{1}', canUserInsert='{2}', canUserUpdate='{3}', canUserDelete='{4}'", isAdmin, canReadData, canUserInsert, canUserUpdate, canUserDelete);

            // QUERIES:
            // abmachungen
            qryAbmachungen.CanInsert = false;
            qryAbmachungen.CanUpdate = false;
            qryAbmachungen.CanDelete = false;

            // zielvereinbarungen
            qryZielvereinbarungen.CanInsert = false;
            qryZielvereinbarungen.CanUpdate = false;
            qryZielvereinbarungen.CanDelete = false;

            // vollmachten
            qryVollmachten.CanInsert = false;
            qryVollmachten.CanUpdate = false;
            qryVollmachten.CanDelete = false;

            // gesuchverwaltung
            qryGesuchverwaltung.CanInsert = false;
            qryGesuchverwaltung.CanUpdate = false;
            qryGesuchverwaltung.CanDelete = false;

            // unerledigteAuflagen
            qryUnerledigteAuflagen.CanInsert = false;
            qryUnerledigteAuflagen.CanUpdate = false;
            qryUnerledigteAuflagen.CanDelete = false;

            // show/hide panel depending on current state
            panUserID.Visible = isAdmin;
            edtUserID.EditMode = isAdmin ? EditModeType.Normal : EditModeType.ReadOnly;
            btnApplyUserID.Enabled = isAdmin;

            // setup grpUnerledigteAuflagen
            grpUnerledigteAuflagen.MinimumSize = new Size(0, 80);
            grpUnerledigteAuflagen.Height = isAdmin ? grpUnerledigteAuflagen.Height : grpUnerledigteAuflagen.Height + panUserID.Height - 3;

            // logging
            _logger.Debug("done");
        }

        private void SetupTitle(int userID)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("userID='{0}'", userID);

            // get user-id values
            var userFirstName = Session.User.FirstName;
            var userLastName = Session.User.LastName;
            var userUserID = Session.User.UserID;

            // check if different user
            if (userID != userUserID)
            {
                // logging
                _logger.DebugFormat("other userid ('{0}')", userID);

                // user is not current logged-in user
                var qryUser = DBUtil.OpenSQL(@"
                    SELECT USR.FirstName,
                            USR.LastName
                    FROM dbo.XUser USR WITH (READUNCOMMITTED)
                    WHERE USR.UserID = {0}", userID);

                // check if user was found
                if (qryUser == null || qryUser.Count < 1)
                {
                    // invalid or user not found
                    throw new ArgumentException(string.Format("The given userID ('{0}') was not found.", userID), "userID");
                }

                // apply values
                userFirstName = Convert.ToString(qryUser["FirstName"]);
                userLastName = Convert.ToString(qryUser["LastName"]);
                userUserID = userID;
            }

            // setup info-label
            Text = KissMsg.GetMLMessage(CLASSNAME, "MyKiSSInfo_v02", "My KiSS - Benutzer/in: {0} {1} ({2}) am {3:D}", KissMsgCode.Text, userFirstName, userLastName, userUserID, DateTime.Now);

            // logging
            _logger.Debug("done");
        }

        #endregion

        #endregion
    }
}