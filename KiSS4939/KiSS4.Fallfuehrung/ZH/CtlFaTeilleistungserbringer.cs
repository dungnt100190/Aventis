using System;
using System.Data;
using System.Drawing;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung.ZH
{
    partial class CtlFaTeilleistungserbringer : KissUserControl
    {
        private const string CtlFaTeilleistungserbringerBearbeiten = "CtlFaTeilleistungserbringer_Bearbeiten";
        private int _faLeistungID = -1;

        public CtlFaTeilleistungserbringer()
        {
            InitializeComponent();
        }

        public void Init(string name, Image titleImage, int leistungID)
        {
            lblTitel.Text = name;
            picTitel.Image = titleImage;
            _faLeistungID = leistungID;

            // Daten anzeigen:
            qryFaTeilLeistungserbringer.Fill(_faLeistungID);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetEditMode();
        }

        private void edtUser_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtUser.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryFaTeilLeistungserbringer["UserID"] = DBNull.Value;
                    qryFaTeilLeistungserbringer["UserLogon"] = DBNull.Value;
                    qryFaTeilLeistungserbringer["UserOrgUnit"] = DBNull.Value;
                    qryFaTeilLeistungserbringer["UserName"] = DBNull.Value;
                    qryFaTeilLeistungserbringer["UserPhone"] = DBNull.Value;
                    qryFaTeilLeistungserbringer["UserEMail"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$              = USR.UserID,
                     [Kürzel]         = LogonName,
                     [Mitarbeiter/in] = LastName + isNull(', ' + FirstName,''),
                     [Phone$]         = USR.Phone,
                     [EMail$]         = USR.EMail,
                     [Org.Einheit]    = XOU.ItemName
              FROM   XUser USR
                 LEFT JOIN XOrgUnit_User OUU ON OUU.UserID = USR.UserID AND OUU.OrgUnitMemberCode = 2
                 LEFT JOIN XOrgUnit      XOU ON XOU.OrgUnitID = OUU.OrgUnitID
              WHERE USR.LogonName LIKE '%' + {0} + '%' ORDER BY [Kürzel]",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryFaTeilLeistungserbringer["UserID"] = dlg["ID$"];
                qryFaTeilLeistungserbringer["UserLogon"] = dlg["Kürzel"];
                qryFaTeilLeistungserbringer["UserOrgUnit"] = dlg["Org.Einheit"];
                qryFaTeilLeistungserbringer["UserName"] = dlg["Mitarbeiter/in"];
                qryFaTeilLeistungserbringer["UserPhone"] = dlg["Phone$"];
                qryFaTeilLeistungserbringer["UserEMail"] = dlg["EMail$"];
            }
        }

        private void qryFaTeilLeistungserbringer_AfterInsert(object sender, EventArgs e)
        {
            qryFaTeilLeistungserbringer["FaLeistungID"] = _faLeistungID;
            edtDatumVon.Focus();
        }

        private void qryFaTeilLeistungserbringer_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtUser, lblUser.Text);

            if (!DBUtil.IsEmpty(edtDatumVon.EditValue) && !DBUtil.IsEmpty(edtDatumBis.EditValue))
            {
                if (Utils.ConvertToDateTime(edtDatumVon.EditValue) >= Utils.ConvertToDateTime(edtDatumBis.EditValue))
                {
                    KissMsg.ShowInfo(
                        "CtlFaTeilLeistungserbringer",
                        "DatumVonGroesserAlsDatumBis",
                        "Das Von-Datum darf nicht grösser als das Bis-Datum\r\n" +
                        "und auch nicht gleich wie das Bis-Datum sein."
                    );
                    throw new KissCancelException();
                }
            }

            // bei Änderung des Teilleistungserbringer und einem Bis Datum in der Vergangenheit kein automatisches Gastrecht erteilen
            if (DBUtil.IsEmpty(qryFaTeilLeistungserbringer["DatumBis"]))
            {
                int faFallId = FallUtil.GetFallIdFromLeistungId(_faLeistungID);

                FallUtil.GastrechteHinzufuegen(
                    (int)qryFaTeilLeistungserbringer["UserID"],
                    faFallId,
                    true, //DarfMutieren
                    null, //DatumVon
                    null,//DatumBis
                    true); //isWithCheckExistsFaLeistungIDUserID - nötig weil die Tabelle nicht geschützt ist
            }

            if (!DBUtil.IsEmpty(qryFaTeilLeistungserbringer["DatumBis"]))
            {
                if (Utils.ConvertToDateTime(qryFaTeilLeistungserbringer["DatumBis"]) >= DateTime.Today)
                {
                    var answer = KissMsg.ShowQuestion(
                        "CtlFaTeilLeistungserbringer",
                        "AbschlussdatumEnfernungGastrecht",
                        "Mit dem Setzen des Abschlussdatums wird das Gastrecht\r\nmit sofortiger Wirkung entfernt." +
                        "\r\nWollen Sie den Eintrag abschliessen?");

                    if (answer)
                    {
                        int faFallId = FallUtil.GetFallIdFromLeistungId(_faLeistungID);
                        FallUtil.GastrechteEntfernen((int)qryFaTeilLeistungserbringer["UserID"], faFallId);
                    }
                    else
                    {
                        edtDatumBis.Text = string.Empty;
                        edtDatumBis.Focus();
                        throw new KissCancelException();
                    }
                }
                else
                {
                    KissMsg.ShowInfo(
                        "CtlFaTeilLeistungserbringer",
                        "DatumBisKleinerAlsHeute",
                        "Das Abschlussdatum kann nur per heutigem Datum\r\n" +
                        "oder in die Zukunft gesetzt werden."
                    );

                    edtDatumBis.Text = string.Empty;
                    edtDatumBis.Focus();
                    throw new KissCancelException();
                }
            }
        }

        private void qryFaTeilLeistungserbringer_PositionChanged(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void SetEditMode()
        {
            if (qryFaTeilLeistungserbringer.CanUpdate && qryFaTeilLeistungserbringer.Count > 0
                && qryFaTeilLeistungserbringer.Row.RowState != DataRowState.Added
                && !DBUtil.UserHasRight(CtlFaTeilleistungserbringerBearbeiten))
            {
                qryFaTeilLeistungserbringer.EnableBoundFields(false);
                ((IKissBindableEdit)edtDatumBis).AllowEdit(true);
                ((IKissBindableEdit)edtBemerkung).AllowEdit(true);
            }
        }
    }
}