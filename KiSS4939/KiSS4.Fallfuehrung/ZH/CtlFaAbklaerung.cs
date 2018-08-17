using System;
using System.Drawing;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung.ZH
{
    partial class CtlFaAbklaerung : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _faFallID = -1;
        private int _faLeistungID = -1;

        #endregion

        #endregion

        #region Constructors

        public CtlFaAbklaerung()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void edtCoUserID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            SetUser(e, edtCoUserID, "CoUserID", "CoLogonName");
        }

        private void edtUserID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            SetUser(e, edtUserID, "UserID", "LogonName");
        }

        private void qryAbklaerung_AfterInsert(object sender, EventArgs e)
        {
            qryAbklaerung["FaLeistungID"] = _faLeistungID;
            qryAbklaerung["UserID"] = Session.User.UserID;
            qryAbklaerung["LogonName"] = Session.User.LogonName;

            edtAusloeserCode.Focus();
        }

        private void qryAbklaerung_AfterPost(object sender, EventArgs e)
        {
            FormController.SendMessage(FormController.Forms.FALL, FormController.Param.ACTION, FormController.Action.REFRESH_TREE);

            if (!DBUtil.IsEmpty(qryAbklaerung["AbklaerungsberichtBeendetDatum"]))
            {
                //Eintrag ins Fallverlaufsprotokoll
                DBUtil.ExecSQL(@"
                    INSERT dbo.FaJournal (FaFallID, FaLeistungID, BaPersonID, UserID, Text, OrgUnitID)
                      VALUES ({0},{1},{2},{3},{4}, {5});",
                    _faFallID,
                    _faLeistungID,
                    qryAbklaerung["BaPersonID"],
                    Session.User.UserID,
                    "Abklärungsauftrag beendet",
                    Session.User["OrgUnitID"]);
            }

            SetEditMode();
        }

        private void qryAbklaerung_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtAuftragDatum, lblAuftragDatum.Text);
            DBUtil.CheckNotNullField(edtUserID, lblUserID.Text);

            // die erste Abklärung wird in CtlFaModulTree mit AusloeserCode = -1 erstellt
            if (Utils.ConvertToInt(qryAbklaerung["AusloeserCode"], -1) == -1)
            {
                qryAbklaerung["AusloeserCode"] = DBNull.Value;
            }

            DBUtil.CheckNotNullField(edtAusloeserCode, lblAusloeserCode.Text);

            //Abklärungsbericht beendet darf nicht früher als Datum Auftrag sein
            DateTime auftragDatum = ((DateTime)edtAuftragDatum.EditValue).Date;
            DateTime? beendetDatum = edtAbklaerungsberichtBeendetDatum.EditValue as DateTime?;
            if(beendetDatum.HasValue && beendetDatum.Value < auftragDatum)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(Name, 
                                                                 "FeldAbklaerungsberichtBeendetVorDatumAuftrag",
                                                                 "Das Datum 'Abklärungsbericht beendet' liegt vor 'Datum Auftrag'.",
                                                                 KissMsgCode.MsgInfo),
                                            edtAbklaerungsberichtBeendetDatum);
            }
        }

        private void qryAbklaerung_PositionChanged(object sender, EventArgs e)
        {
            qryAbklaerung.EnableBoundFields(CanEditDataRow());
            SetEditMode();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "USERID":
                    return Session.User.UserID;
                case "FAABKLAERUNGID":
                    return qryAbklaerung["FaAbklaerungID"];
                case "BETRPERSONID":
                    return Utils.ConvertToInt(qryAbklaerung["BaPersonID"]);
                case "FAFALLID":
                    return _faFallID;
                case "ABSENDER":
                    return 0;
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string name, Image titleImage, int leistungID, int fallID)
        {
            lblTitel.Text = name;
            picTitel.Image = titleImage;
            _faFallID = fallID;
            _faLeistungID = leistungID;

            // alle Personen aller Klientensysteme von BaPersonID
            qryPerson.Fill(_faFallID);

            // Anzeige im Gitter:
            colAusloeser.ColumnEdit = grdAbklaerung.GetLOVLookUpEdit("FaAbklaerungAusloeser");

            // Daten öffnen:
            qryAbklaerung.Fill(_faLeistungID);
            if (qryAbklaerung.IsEmpty)
            {
                qryAbklaerung.Insert();
            }

            SetEditMode();
        }

        #endregion

        #region Private Methods

        private bool CanEditDataRow()
        {
            return (qryAbklaerung.Count > 0 && qryAbklaerung.CanUpdate);
        }

        private void SetEditMode()
        {
            EditModeType editMode = EditModeType.ReadOnly;
            qryAbklaerung.CanDelete = false;
            if (DBUtil.IsEmpty(qryAbklaerung["AbklaerungsberichtBeendetDatum"]))
            {
                editMode = EditModeType.Normal;
                qryAbklaerung.CanDelete = true;
            }

            edtAuftragDatum.EditMode = editMode;
            edtAusloeserCode.EditMode = editMode;
            edtBaPersonID.EditMode = editMode;
            edtUserID.EditMode = editMode;
            edtCoUserID.EditMode = editMode;
            edtAbklaerungsberichtBeendetDatum.EditMode = editMode;
        }

        private void SetUser(UserModifiedFldEventArgs e, KissButtonEdit edtUser, string userIdString, string logonNameString)
        {
            string searchString = edtUser.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryAbklaerung[userIdString] = DBNull.Value;
                    qryAbklaerung[logonNameString] = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT
                  ID$              = U.UserID,
                  [Kürzel]         = U.LogonName,
                  [Mitarbeiter/in] = U.LastName + ISNULL(', ' + U.FirstName,''),
                  [Org.Einheit]    = XOU.ItemName
                FROM dbo.XUser U
                  LEFT JOIN XOrgUnit_User OUU ON OUU.UserID = U.UserID
                                             AND OUU.OrgUnitMemberCode = 2
                  LEFT JOIN XOrgUnit      XOU ON XOU.OrgUnitID = OUU.OrgUnitID
                WHERE U.LogonName LIKE '%' + {0} + '%'
                  AND U.IsLocked = 0
                ORDER BY U.LogonName;",
                searchString,
                e.ButtonClicked,
                null,
                null,
                null);

            if (!e.Cancel)
            {
                qryAbklaerung[userIdString] = dlg[0];
                qryAbklaerung[logonNameString] = dlg[1];
            }

            SetEditMode();
        }

        #endregion

        #endregion
    }
}