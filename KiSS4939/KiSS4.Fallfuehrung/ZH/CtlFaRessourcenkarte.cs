using System;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung.ZH
{
    partial class CtlFaRessourcenkarte : KissUserControl
    {
        private int faFallID = -1;
        private int faLeistungID = -1;

        public CtlFaRessourcenkarte()
        {
            InitializeComponent();
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "USERID":
                    return Session.User.UserID;
                case "BETRPERSONID":
                    return qryFaRessourcenkarte["BaPersonID"];
                case "FARESSOURCENKARTEID":
                    return qryFaRessourcenkarte["FaRessourcenkarteID"];
                case "FAFALLID":
                    return DBUtil.ExecuteScalarSQL(@"SELECT FaFallID
                                                     FROM FaLeistung
                                                     WHERE FaLeistungID = {0}",
                                                   qryFaRessourcenkarte["FaLeistungID"]);
                case "ABSENDER":
                    return 0;
                case "LEISTUNGUSERID":
                    return DBUtil.ExecuteScalarSQL(@"SELECT UserID
                                                     FROM FaLeistung
                                                     WHERE FaLeistungID = {0}",
                                                   qryFaRessourcenkarte["FaLeistungID"]);
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string name, Image titleImage, int leistungID, int fallID, int clientID)
        {
            lblTitel.Text = name;
            picTitel.Image = titleImage;
            baPersonID = clientID;
            faFallID = fallID;
            faLeistungID = leistungID;

            // alle Personen aller Klientensysteme von BaPersonID
            var qryPers = DBUtil.OpenSQL(@"SELECT Code = P.BaPersonID,
                                                  Text = P.Name + IsNull(' ' + P.Vorname,''),
                                                  Geburtsdatum$=P.Geburtsdatum
                                           FROM FaFallPerson F
                                             LEFT JOIN BaPerson P on P.BaPersonID = F.BaPersonID
                                           WHERE F.FaFallID = {0}

                                           UNION ALL

                                           SELECT NULL, '', NULL ORDER BY 2",
                                           faFallID);

            edtPerson.Properties.DataSource = qryPers;
            colPerson.ColumnEdit = grdRessourcenkarte.GetLOVLookUpEdit(qryPers);

            // Daten öffnen:
            qryFaRessourcenkarte.Fill(faLeistungID);
        }

        private void btnResCopy_Click(object sender, EventArgs e)
        {
            if (!qryFaRessourcenkarte.Post())
            {
                return;
            }

            // Neue Zeile einfügen
            string[] excludingFieldNames = {
              "StatusCode",
              "FaRessourcenkarteID",
              "ErstelltDatum",
              "ErstelltUserID",
              "MutiertDatum",
              "MutiertUserID",
              "UnterschriebenDatum"
            };

            DBUtil.CopyDataRow_ExcludingFields(qryFaRessourcenkarte, excludingFieldNames, false);
            HandleReadonlyDependingSignDate(qryFaRessourcenkarte["UnterschriebenDatum"]);
            ShowUser();
        }

        private void edtStatusCode_EditValueChanged(object sender, EventArgs e)
        {
            if (!((KissLookUpEdit)sender).UserModified)
            {
                return;
            }

            // Alter Code holen und vergleichen:
            var oldValue = 0;
            if (!DBUtil.IsEmpty(((KissLookUpEdit)sender).OldEditValue))
            {
                oldValue = (int)((KissLookUpEdit)sender).OldEditValue;
            }

            var newValue = 0;
            if (!DBUtil.IsEmpty(((KissLookUpEdit)sender).EditValue))
            {
                newValue = (int)((KissLookUpEdit)sender).EditValue;
            }

            if ((oldValue == 0) || (oldValue == newValue))
            {
                return;
            }

            if (QuestionFieldStatus(newValue))
            {
                qryFaRessourcenkarte["StatusCode"] = newValue;
                edtStatusCode.EditValue = newValue;
                HandleReadonlyDependingSignDate(null);
            }
            else
            {
                qryFaRessourcenkarte["StatusCode"] = oldValue;
                edtStatusCode.EditValue = oldValue;
            }
        }

        private void HandleReadonlyDependingSignDate(object signDate)
        {
            var datensatzEditMode = EditModeType.ReadOnly;
            var aktuellerStatus = DBUtil.IsEmpty(qryFaRessourcenkarte["StatusCode"]) ? 0 : (int)qryFaRessourcenkarte["StatusCode"];
            edtStatusCode.LOVFilter = "";

            if (DBUtil.IsEmpty(signDate) && aktuellerStatus != 0 && aktuellerStatus != 3)
            {
                // in Erstellung oder aktuell
                edtStatusCode.LOVFilter = "(Code = 1 OR Code = 2)";
                if (aktuellerStatus != 1 && aktuellerStatus != 2)
                {
                    edtStatusCode.EditValue = 2;
                }
                datensatzEditMode = EditModeType.Normal;
            }
            else if (!DBUtil.IsEmpty(signDate) && aktuellerStatus != 0)
            {
                // aktuell oder historisiert
                edtStatusCode.LOVFilter = "(Code = 2 OR Code = 3)";
                if (aktuellerStatus != 2 && aktuellerStatus != 3)
                {
                    edtStatusCode.EditValue = 2;
                }
            }
            edtStatusCode.ReadLOV();

            edtPerson.EditMode = datensatzEditMode;
            edtPersResKomp.EditMode = datensatzEditMode;
            edtSozResKomp.EditMode = datensatzEditMode;
            edtMatRes.EditMode = datensatzEditMode;
            edtInfraRes.EditMode = datensatzEditMode;
            edtDatumUnterschrift.EditMode = datensatzEditMode;

            edtStatusCode.EditMode = (aktuellerStatus != 0 && !(datensatzEditMode == EditModeType.ReadOnly && aktuellerStatus == 3)) ? EditModeType.Normal : EditModeType.ReadOnly;
            btnResCopy.Enabled = qryFaRessourcenkarte.CanInsert && qryFaRessourcenkarte.Count > 0;
        }

        private void qryFaRessourcenkarte_AfterFill(object sender, EventArgs e)
        {
            if (qryFaRessourcenkarte.Count == 0)
            {
                qryFaRessourcenkarte_PositionChanged(null, null);
            }

            qryFaRessourcenkarte.Last();
        }

        private void qryFaRessourcenkarte_AfterInsert(object sender, EventArgs e)
        {
            var qryDat = DBUtil.OpenSQL(@"SELECT dbo.fnOrgUnitOfUser({0}, 0) AS OrgUnit;",
                                        Session.User.UserID);

            qryFaRessourcenkarte["FaLeistungID"] = faLeistungID;
            qryFaRessourcenkarte["BaPersonID"] = baPersonID;
            SetGeburtsdatum();
            qryFaRessourcenkarte["StatusCode"] = 1;
            qryFaRessourcenkarte["LogonName"] = Session.User.LogonName;
            qryFaRessourcenkarte["OrgUnit"] = qryDat["OrgUnit"];
            qryFaRessourcenkarte["ErstelltDatum"] = DateTime.Now;
            qryFaRessourcenkarte.RefreshDisplay();

            edtPerson.Focus();
        }

        private void qryFaRessourcenkarte_AfterPost(object sender, EventArgs e)
        {
            HandleReadonlyDependingSignDate(qryFaRessourcenkarte["UnterschriebenDatum"]);
            ShowUser();
        }

        private void qryFaRessourcenkarte_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            var statusCode = DBUtil.IsEmpty(qryFaRessourcenkarte["StatusCode"]) ? 0 : (int)qryFaRessourcenkarte["StatusCode"];
            var canDelete = (qryFaRessourcenkarte.CanDelete && DBUtil.IsEmpty(qryFaRessourcenkarte["UnterschriebenDatum"])
                             && statusCode != 3);

            if (!canDelete)
            {
                KissMsg.ShowInfo(typeof(CtlFaRessourcenkarte).Name, "RessourcenkarteNichtLoeschen",
                  "Diese Karte kann nicht gelöscht werden, da sie bereits mit einem Unterschriftsdatum versehen ist.");
                throw new KissCancelException();
            }
        }

        private void qryFaRessourcenkarte_BeforePost(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(qryFaRessourcenkarte["baPersonID"]))
            {
                edtPerson.Focus();
                KissMsg.ShowInfo(typeof(CtlFaRessourcenkarte).Name, "PersonLeer", "Das Feld 'für Person' darf nicht leer sein.");
                throw new KissCancelException();
            }

            var answer = true;
            if (!DBUtil.IsEmpty(edtDatumUnterschrift.EditValue) && qryFaRessourcenkarte.ColumnModified("UnterschriebenDatum"))
            {
                answer = KissMsg.ShowQuestion(typeof(CtlFaRessourcenkarte).Name,
                                              "RessourcenkarteDatumTrotzdemSetzen",
                                              "Nach Setzen des 'unterschrieben am' Datum kann der Datensatz nicht mehr bearbeitet werden.\r\n" +
                                              "Wollen Sie das Datum trotzdem setzen?",
                                              true);
            }
            if (answer)
            {
                HandleReadonlyDependingSignDate(edtDatumUnterschrift.EditValue);
            }
            else
            {
                edtDatumUnterschrift.EditValue = null;
                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(qryFaRessourcenkarte["FaRessourcenkarteID"]))
            {
                qryFaRessourcenkarte["ErstelltUserID"] = Session.User.UserID;
                qryFaRessourcenkarte["ErstelltDatum"] = DateTime.Now;
            }

            // Bei mutierten Zeilen:
            // Muss auch bei neuen Zeilen gesetzt werden,
            // weil diese Felder DB-seitig Mussfelder sind:
            qryFaRessourcenkarte["MutiertUserID"] = Session.User.UserID;
            qryFaRessourcenkarte["MutiertDatum"] = DateTime.Now;

            SetGeburtsdatum();
        }

        private void qryFaRessourcenkarte_PositionChanged(object sender, EventArgs e)
        {
            HandleReadonlyDependingSignDate(qryFaRessourcenkarte["UnterschriebenDatum"]);
            ShowUser();
        }

        private bool QuestionFieldStatus(int? newValue)
        {
            var isStatusHistorisierung = qryFaRessourcenkarte.Count > 0 &&
                                         newValue == 3;
            var answer = true;

            DateTime datumUnterschrift;
            var hasUnterschrift = DateTime.TryParse(Convert.ToString(edtDatumUnterschrift.EditValue), out datumUnterschrift);

            if (isStatusHistorisierung && hasUnterschrift)
            {
                edtStatusCode.EditMode = EditModeType.ReadOnly;
                return true;
            }

            if (isStatusHistorisierung && !hasUnterschrift)
            {
                answer = KissMsg.ShowQuestion(typeof(CtlFaRessourcenkarte).Name,
                                              "RessourcenkarteHistDatumFehlt",
                                              "Das Datum 'unterschrieben am' fehlt.\r\n" +
                                              "Nach Setzen des Status auf 'historisiert' kann der Datensatz nicht mehr bearbeitet werden.\r\n" +
                                              "Wollen Sie den Status trotzdem anpassen?",
                                              true);
            }

            return answer;
        }

        private void SetGeburtsdatum()
        {
            var query = ((SqlQuery)edtPerson.Properties.DataSource);
            query.Find(string.Format("Code={0}", qryFaRessourcenkarte["BaPersonID"]));
            qryFaRessourcenkarte["Geburtsdatum"] = query["Geburtsdatum$"];
        }

        // User anzeigen:
        private void ShowUser()
        {
            lblUserErfasst.Text = string.Empty;
            if (!DBUtil.IsEmpty(qryFaRessourcenkarte["ErstelltUserID"]))
            {
                qryUser.Fill(qryFaRessourcenkarte["ErstelltUserID"]);
                lblUserErfasst.Text = qryUser["LogonName"] + ", " +
                  ((DateTime)qryFaRessourcenkarte["ErstelltDatum"]).ToString("dd.MM.yyyy");
            }

            lblUserMutiert.Text = "";
            if (!DBUtil.IsEmpty(qryFaRessourcenkarte["MutiertUserID"]))
            {
                qryUser.Fill(qryFaRessourcenkarte["MutiertUserID"]);
                lblUserMutiert.Text = qryUser["LogonName"] + ", " + ((DateTime)qryFaRessourcenkarte["MutiertDatum"]).ToString("dd.MM.yyyy");
            }
        }
    }
}