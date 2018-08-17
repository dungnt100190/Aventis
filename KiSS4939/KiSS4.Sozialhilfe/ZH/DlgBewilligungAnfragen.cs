using System;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe.ZH
{
    public partial class DlgBewilligungAnfragen : KissDialog
    {
        #region Fields

        #region Protected Fields

        protected string _nameVornameDefault;
        protected string _nameVornameLV;
        protected int _userIdDefault;
        protected int _userIdLV;
        protected int _userIdSelected;

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly bool _openTransaction;

        #endregion

        #endregion

        #region Constructors

        protected DlgBewilligungAnfragen()
        {
            InitializeComponent();
        }

        protected DlgBewilligungAnfragen(bool openTransaction)
        {
            InitializeComponent();

            _openTransaction = openTransaction;
        }

        #endregion

        #region EventHandlers

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            CancelBewilligung();
        }

        private void btnAnfragen_Click(object sender, EventArgs e)
        {
            PostBewilligungRecord();
        }

        private void edtUserID_An_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtUserID_An.EditValue.ToString();
            var buttonClicked = e.ButtonClicked;

            if (DBUtil.IsEmpty(searchString))
            {
                if (buttonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    //Benutzer hat keinen User ausgewählt, select defaultUser
                    SelectUser(_userIdDefault, _nameVornameDefault);
                    return;
                }
            }

            //Suche nach User mit searchString durchführen
            KissLookupDialog dlg = new KissLookupDialog();
            var sachbearbeiterGruppeId = WhUtil.GetSachbearbeiterGruppeID();
            bool cancel = !dlg.SearchData(WhUtil.SELECT_USERS_FOR_BEWILLIGUNG_OR_SAME_QT_OR_SZ, KissLookupDialog.PrepareSearchString(searchString + "%"), buttonClicked, Session.User.UserID, false, _userIdLV, false, false, sachbearbeiterGruppeId);

            if (!cancel)
            {
                SelectUser(Utils.ConvertToInt(dlg["UserID$"]), Utils.ConvertToString(dlg["Name"]));
            }
            else
            {
                //Benutzer hat keinen User ausgewählt, select Leistungsverantwortlicher as default
                SelectUser(_userIdDefault, _nameVornameDefault);
            }
        }

        private void qryBgBewilligung_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtUserID_An, "Anzufragender Stellenleiter/Stv.");
            SetValuesInBewilligungQuery(qryBgBewilligung);
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected virtual void CancelBewilligung()
        {
            userCancel = true;

            qryBgBewilligung.RowModified = false;
            qryBgBewilligung.DataSet.AcceptChanges();
        }

        protected virtual void DetermineDefaultUser(out int userID, out string nameVorname)
        {
            var qryDefaultUser = WhUtil.GetSqlQueryUsersForBewilligung(null, Session.User.UserID, true, _userIdLV, false, false);
            var stufeAnfrager = Utils.ConvertToInt(qryDefaultUser.DataSet.Tables[1].Rows[0]["Stufe_Anfrager"]);

            // SL oder ZL
            if (stufeAnfrager >= 2)
            {
                userID = 0;
                nameVorname = "";
                return;
            }

            if (qryDefaultUser.IsEmpty)
            {
                userID = 0;
                nameVorname = "";
                return;
            }

            userID = Utils.ConvertToInt(qryDefaultUser["UserID$"]);
            nameVorname = Utils.ConvertToString(qryDefaultUser["Name"]);
        }

        protected virtual void DetermineLeistungUndLeistungsverantwortlicher(out int userID, out string nameVorname)
        {
            userID = -1;
            nameVorname = null;
        }

        protected virtual bool HasUserKompetenz(int userID)
        {
            return false;
        }

        protected override void OnLoad(EventArgs e)
        {
            //only perform the following tasks if we are not in DesignMode (this property only exists on
            if (edtUserID_An.IsDesignMode)
            {
                return;
            }

            string tableName;
            PrepareBewilligungQuery(qryBgBewilligung, out tableName);
            qryBgBewilligung.TableName = tableName;

            DetermineLeistungUndLeistungsverantwortlicher(out _userIdLV, out _nameVornameLV);
            DetermineDefaultUser(out _userIdDefault, out _nameVornameDefault);
            SelectUser(_userIdDefault, _nameVornameDefault);
        }

        protected virtual void PostBewilligungRecord()
        {
            userCancel = false;

            qryBgBewilligung.RowModified = true;
            try
            {
                if (_openTransaction)
                {
                    Session.BeginTransaction();
                }

                qryBgBewilligung.Post(qryBgBewilligung.TableName);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                KissMsg.ShowError(ex.Message);
                CancelBewilligung();
            }

            //Wenn _openTransaction auf true gesetzt wurde, muss Commit/Rollback-Code in aufrufender Maske z.B. CtlWhFinanzplan liegen
        }

        protected virtual void PrepareBewilligungQuery(SqlQuery query, out string tableName)
        {
            tableName = null;
        }

        protected virtual void SelectUser(int userID, string nameVorname)
        {
            edtUserID_An.LookupID = userID;
            edtUserID_An.EditValue = nameVorname;

            _userIdSelected = userID;

            var userHasKompetenz = HasUserKompetenz(userID);
            btnAnfragen.Enabled = userHasKompetenz;
            lblUserHatUngenuegendeKompetenz.Visible = userID != 0 && !userHasKompetenz;
        }

        protected virtual void SetValuesInBewilligungQuery(SqlQuery query)
        {
        }

        #endregion

        #endregion
    }
}