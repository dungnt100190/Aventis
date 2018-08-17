using System;
using System.Data;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaQJIntake.
    /// </summary>
    partial class CtlKaQJIntake : KissUserControl
    {
        private int _baPersonID;
        private int _faLeistungID;
        private bool _mayClose;
        private bool _mayDel;
        private bool _mayIns;
        private bool _mayRead;
        private bool _mayReopen;
        private bool _mayUpd;
        private bool _userDel;
        private bool _userIns;
        private bool _userUpd;

        public CtlKaQJIntake()
        {
            InitializeComponent();
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return _baPersonID;

                case "FALEISTUNGID":
                    return _faLeistungID;
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int faLeistungID, int baPersonID)
        {
            lblTitel.Text = titleName;
            picTitle.Image = titleImage;
            _baPersonID = baPersonID;
            _faLeistungID = faLeistungID;

            colPraesenz.ColumnEdit = grdIntakegespraeche.GetLOVLookUpEdit("KaQjIntakePraesenz");
            colEntscheid.ColumnEdit = grdIntakegespraeche.GetLOVLookUpEdit("KaQjIntakeEntscheid");
        }

        public override void OnRefreshData()
        {
            qryIntake.Refresh();
            base.OnRefreshData();
        }

        public override bool OnSaveData()
        {
            qryIntake.Post();
            return base.OnSaveData();
        }

        private void CtlKaQJIntake_Load(object sender, EventArgs e)
        {
            SetRights();
            qryIntake.Fill(_faLeistungID, Session.User.IsUserKA ? 0 : 1);

            // Insert Intake if it does not already exist
            if (qryIntake.IsEmpty && !IntakeExists() && (_userUpd && _userIns) && (_mayUpd || _mayIns))
            {
                qryIntake.Insert(DBO.KaQJIntake.DBOName);
                qryIntake[DBO.KaQJIntake.FaLeistungID] = _faLeistungID;
                qryIntake[DBO.KaQJIntake.SichtbarSDFlag] = KaUtil.IsVisibleSD(_baPersonID);
                qryIntake[DBO.KaAbklaerungIntake.FaLeistungID] = _faLeistungID;
            }

            qryIntakegespraech.Fill(qryIntake[DBO.KaQJIntake.KaQJIntakeID]);
            SetEditMode();
            SetupDataMembers();

            UpdateZuweiserInfo();
        }

        private void dlgZuweiser_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            if (dlg.ZuweiserSuchen(edtZuweiser.Text, e.ButtonClicked))
            {
                qryIntake["Zuweiser"] = dlg["FullName"];
                qryIntake["ZuweiserID"] = dlg["BeratID"];
                qryIntake["ZuweiserName"] = dlg["Name"];
                qryIntake["ZuweiserVorname"] = dlg["Vorname"];

                edtZuweiser.EditValue = dlg["FullName"];
                edtZuweiser.LookupID = dlg["BeratID"];

                UpdateZuweiserInfo();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private bool IntakeExists()
        {
            var exists = DBUtil.ExecuteScalarSQL(@"
                IF EXISTS(SELECT TOP 1 1
                          FROM dbo.KaQJIntake WITH (READUNCOMMITTED)
                          WHERE FaLeistungID = {0})
                BEGIN
                  SELECT CONVERT(BIT, 1);
                END
                ELSE
                BEGIN
                  SELECT CONVERT(BIT, 0);
                END;",
                _faLeistungID) as bool? ?? false;

            return exists;
        }

        private void qryIntake_AfterPost(object sender, EventArgs e)
        {
            try
            {
                if (DBUtil.IsEmpty(qryIntakegespraech[DBO.KaQJIntakeGespraech.KaQJIntakeID]))
                {
                    qryIntakegespraech[DBO.KaQJIntakeGespraech.KaQJIntakeID] = qryIntake[DBO.KaQJIntake.KaQJIntakeID];
                }

                if (!qryIntakegespraech.Post())
                {
                    throw new KissCancelException();
                }

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                throw new KissCancelException();
            }
        }

        private void qryIntake_BeforePost(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(rgrAbgemeldetALV.EditValue))
            {
                qryIntake[DBO.KaQJIntake.AbgemeldetALVFlag] = rgrAbgemeldetALV.EditValue.ToString().Equals("1");
            }

            if (!DBUtil.IsEmpty(rgrNichtErschienen.EditValue))
            {
                qryIntake[DBO.KaQJIntake.NichtErschFlag] = rgrNichtErschienen.EditValue.ToString().Equals("1");
            }

            if (!DBUtil.IsEmpty(rgrGespraechStattgef.EditValue))
            {
                qryIntake[DBO.KaQJIntake.GesprStattgefFlag] = rgrGespraechStattgef.EditValue.ToString().Equals("1");
            }

            Session.BeginTransaction();
        }

        private void qryIntakegespraech_AfterInsert(object sender, EventArgs e)
        {
            qryIntakegespraech[DBO.KaQJIntakeGespraech.KaQJIntakeID] = qryIntake[DBO.KaQJIntake.KaQJIntakeID];
            edtDatum.Focus();
        }

        private void qryIntakegespraech_BeforeInsert(object sender, EventArgs e)
        {
            qryIntake.Post();
        }

        private void qryIntakegespraech_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            if (qryIntakegespraech.RowModified)
            {
                qryIntake.RowModified = true;
            }
        }

        private void qryIntakegespraech_PositionChanging(object sender, EventArgs e)
        {
            if (qryIntakegespraech.RowModified)
            {
                qryIntake.RowModified = true;
            }
        }

        private void SetEditMode()
        {
            qryIntake.CanInsert = false;
            qryIntake.CanUpdate = _mayUpd && _userUpd;
            qryIntakegespraech.CanUpdate = _mayUpd && _userUpd;
            qryIntakegespraech.CanInsert = _mayIns && _userIns;
            qryIntakegespraech.CanDelete = _mayDel && _userDel;

            rgrAbgemeldetALV.EditMode = _mayUpd && _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            rgrNichtErschienen.EditMode = _mayUpd && _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            rgrGespraechStattgef.EditMode = _mayUpd && _userUpd ? EditModeType.Normal : EditModeType.ReadOnly;

            qryIntake.EnableBoundFields();
            qryIntakegespraech.Last();
        }

        private void SetRights()
        {
            _userUpd = DBUtil.UserHasRight(typeof(CtlKaQJIntake).Name, "U");
            _userIns = DBUtil.UserHasRight(typeof(CtlKaQJIntake).Name, "I");
            _userDel = DBUtil.UserHasRight(typeof(CtlKaQJIntake).Name, "D");

            DBUtil.GetFallRights(_faLeistungID, out _mayRead, out _mayIns, out _mayUpd, out _mayDel, out _mayClose, out _mayReopen);
        }

        private void SetupDataMembers()
        {
            colPraesenz.FieldName = DBO.KaQJIntakeGespraech.KaQjIntakePraesenzCode;
            colEntscheid.FieldName = DBO.KaQJIntakeGespraech.KaQjIntakeEntscheidCode;
        }

        private void UpdateZuweiserInfo()
        {
            if (qryIntake.IsEmpty)
            {
                return;
            }

            qryZuweiser.Fill(qryIntake["ZuweiserID"]);
        }
    }
}