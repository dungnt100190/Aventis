using System;
using System.Data;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryIkIndexbrief : KissQueryControl
    {
        private int _filterUserID;
        private string _filterUserText = "";
        private DateTime _oldDate = DateTime.Today;
        private int _oldIndexArt = 2;
        private string _zeileXVonY;

        public CtlQueryIkIndexbrief()
        {
            InitializeComponent();
        }

        protected override void NewSearch()
        {
            // Alte Suchwerte speichern
            edtIndexart.EditValue = _oldIndexArt;
            edtDatumPer.EditValue = _oldDate;
            edtUser.LookupID = _filterUserID;
            edtUser.EditValue = _filterUserText;
            edtUser.ToolTip = _filterUserText;
            base.NewSearch();
        }

        protected override void RunSearch()
        {
            if (DBUtil.IsEmpty(edtDatumPer.EditValue))
            {
                KissMsg.ShowInfo(Name, "DatumNeueForderungPerIsEmpty", "Erfassen Sie zuerst das Datum 'Neue Forderung Per'.");
                throw new KissCancelException();
            }

            // Alte Suchwerte speichern
            _oldIndexArt = Utils.ConvertToInt(edtIndexart.EditValue);
            _oldDate = edtDatumPer.DateTime;
            _filterUserText = Utils.ConvertToString(edtUser.EditValue);
            lblCount.Text = "";

            // Fixe Parameter
            var parameters = new object[]
            {
                _oldDate,
                _oldIndexArt,
                _filterUserID,
                edtchkDelete.Checked
            };

            kissSearch.SelectParameters = parameters;
            base.RunSearch();

            // Alte Suchwerte speichern
            btnCreate.Visible = !edtchkDelete.Checked;
            btnCreate.Enabled = (_oldIndexArt == 1 || _oldIndexArt == 2);
            btnUndo.Visible = edtchkDelete.Checked;
            btnUndo.Enabled = (_oldIndexArt == 1 || _oldIndexArt == 2);
        }

        private static void AppendNewLineToStringIfNotEmpty(ref string message)
        {
            if (message != "")
            {
                message = message + "\r\n";
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var hasValueForEveryLandesindex = Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
              DECLARE @CountIkLandesindex INT;
              DECLARE @CountIkLandesindexWert INT;

              SELECT @CountIkLandesindex = COUNT(1)
              FROM dbo.IkLandesindex WITH (READUNCOMMITTED);

              SELECT @CountIkLandesindexWert = COUNT(1)
              FROM dbo.IkLandesindexWert WITH (READUNCOMMITTED)
              WHERE Jahr = {0}
                AND Monat = 11;

              SELECT CASE
                       WHEN @CountIkLandesindex <> @CountIkLandesindexWert THEN 0       -- not all indexes have a value for month and year
                       ELSE 1                                                           -- all indexes have a value for month and year
                     END;", edtDatumPer.DateTime.Year - 1));

            if (!hasValueForEveryLandesindex)
            {
                KissMsg.ShowInfo(Name,
                                 "NotAllIndexesHaveValueForNov",
                                 "Für den November {0} konnte nicht für alle Indextypen ein Index gefunden werden.\r\nErfassen Sie zuerst alle Indexzahlen.",
                                 edtDatumPer.DateTime.Year - 1);

                return;
            }

            var tmpMsg = "";
            var success = 0;
            var nullForderungen = 0;
            var forderungenDanach = 0;
            var forderungenBereitsErstellt = 0;
            var datumGueltigBisGesetzt = 0;
            var total = 0;
            var actNumber = 0;

            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                for (var i = 1; i < 11; i++)
                {
                    var fieldName = i.ToString();

                    if (fieldName.Length == 1)
                    {
                        fieldName = "0" + fieldName;
                    }

                    fieldName = "Glb" + fieldName + "_IkForderungID";

                    if (DBUtil.IsEmpty(row[fieldName]))
                    {
                        continue;
                    }

                    total += 1;
                    int result;

                    try
                    {
                        var qryExec = DBUtil.OpenSQL(@"
                            DECLARE @Res INT;
                            EXEC @Res = dbo.spIkForderung_Insert_Index {0}, {1};
                            SELECT Result = @Res;", row[fieldName], edtDatumPer.DateTime);

                        result = Utils.ConvertToInt(qryExec["Result"]);

                        switch (result)
                        {
                            case 1:
                                success += 1;
                                break;

                            case 2:
                                nullForderungen += 1;
                                break;

                            case 3:
                                forderungenDanach += 1;
                                break;

                            case 4:
                                forderungenBereitsErstellt += 1;
                                break;

                            case 5:
                                datumGueltigBisGesetzt += 1;
                                break;

                            case -1:
                                tmpMsg = KissMsg.GetMLMessage(
                                    Name,
                                    "IkForderungIDUngueltig",
                                    "Der Aufruf-Parameter @IkForderungID ist ungültig (IkForderungID = {0}).",
                                    Utils.ConvertToInt(row[fieldName]).ToString()
                                    );
                                break;

                            case -2:
                                tmpMsg = KissMsg.GetMLMessage(
                                    Name,
                                    "IndexKannNichtErmitteltWerden",
                                    "Der Index für die neue Forderung konnte nicht ermittelt werden (IkForderungID = {0}).",
                                    Utils.ConvertToInt(row[fieldName]).ToString());
                                break;

                            default:
                                tmpMsg = KissMsg.GetMLMessage(
                                    Name,
                                    "UnbekannterFehlerForderungKopieren",
                                    "Unbekannter Fehler beim Kopieren der Forderung (IkForderungID = {0}).",
                                    Utils.ConvertToInt(row[fieldName]).ToString());
                                break;
                        }

                        if (tmpMsg != "")
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        tmpMsg = ex.Message;
                        result = -1;
                        break;
                    }
                }

                // Monatszahlen neu generieren
                DBUtil.ExecSQL(@"EXEC dbo.spIkMonatszahlen_DetailAll NULL, {0}, 2;", row["IkRechtstitelID"]);

                actNumber += 1;
                lblCount.Text = string.Format(_zeileXVonY, actNumber, qryQuery.Count);
                lblCount.Refresh();

                if (tmpMsg != "")
                {
                    break;
                }
            }

            var msg = "";

            if (success > 0)
            {
                msg = KissMsg.GetMLMessage(Name, "AnzahlForderungErstellt", "Es wurde(n) {0} neue Forderung(en) erstellt (Total {1}).", success, total);
            }

            if (nullForderungen > 0)
            {
                AppendNewLineToStringIfNotEmpty(ref msg);
                msg = msg + KissMsg.GetMLMessage(
                    Name,
                    "AnzahlForderungUebersprungen",
                    "{0} Forderung(en) wurden übersprungen, weil eine Null-Forderung verarbeitet wurde.",
                    nullForderungen);
            }

            if (forderungenDanach > 0)
            {
                AppendNewLineToStringIfNotEmpty(ref msg);
                msg = msg + KissMsg.GetMLMessage(
                    Name,
                    "AnzahlForderungUebersprungenDanach",
                    "{0} Forderung(en) wurden übersprungen, weil eine Null-Forderung vor der neuen Forderung existiert.",
                    forderungenDanach);
            }

            if (forderungenBereitsErstellt > 0)
            {
                AppendNewLineToStringIfNotEmpty(ref msg);
                msg = msg + KissMsg.GetMLMessage(
                    Name,
                    "AnzahlForderungBereitsVorhanden",
                    "{0} bereits vorhandene Forderung(en) wurden übersprungen.",
                    forderungenBereitsErstellt);
            }

            if (datumGueltigBisGesetzt > 0)
            {
                AppendNewLineToStringIfNotEmpty(ref msg);
                msg = msg + KissMsg.GetMLMessage(
                    Name,
                    "AnzahlForderungUebersprungenDatumBis",
                    "{0} Forderung(en) wurden übersprungen, weil das Datum GültigBis vor dem neuen Anpassungsdatum liegt.",
                    datumGueltigBisGesetzt);
            }

            if (tmpMsg != "")
            {
                if (msg != "")
                {
                    msg = msg + "\r\n\r\n";
                }

                msg = msg + KissMsg.GetMLMessage(Name, "VerarbeitungAbgeschlossen", "Die Verarbeitung wurde abgebrochen: Letzte Fehlermeldung:\r\n");
                msg = msg + tmpMsg;
            }

            KissMsg.ShowInfo(msg);

            // Daten neu anzeigen
            qryQuery.Refresh();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            // Kontrollabfrage
            if (!KissMsg.ShowQuestion(
                Name,
                "FrageForderungLoeschen",
                "Es existieren {0} Forderungen, welche gelöscht werden.\r\nWollen Sie alle diese Forderungen wirklich löschen?",
                true,
                qryQuery.Count))
            {
                return;
            }

            // Löschen
            var deleted = 0;
            var errors = 0;
            var actNumber = 0;

            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                var qry = DBUtil.OpenSQL(@"EXEC dbo.spIkForderung_Delete_Check {0};", row["Frdrg_IkForderungID"]);
                var anzVerbucht = Utils.ConvertToInt(qry["AnzahlVerbucht"]);

                if (anzVerbucht == 0)
                {
                    DBUtil.ExecSQL(@"
                        DELETE dbo.IkForderung
                        WHERE IkForderungID = {0};", row["Frdrg_IkForderungID"]);

                    deleted += 1;
                }
                else
                {
                    errors += 1;
                }

                actNumber += 1;
                lblCount.Text = string.Format(_zeileXVonY, actNumber, qryQuery.Count);
                lblCount.Refresh();
            }

            // Rückmeldung ausgeben
            var msg = "";

            if (deleted > 0)
            {
                msg = KissMsg.GetMLMessage(Name, "AnzahlForderungGeloescht", "Es wurde(n) {0} Forderung(en) gelöscht.", deleted);
            }

            if (errors > 0)
            {
                AppendNewLineToStringIfNotEmpty(ref msg);
                msg = msg + KissMsg.GetMLMessage(Name, "AnzahlForderungBereitsVerbucht", "{0} Forderung(en) konnten nicht gelöscht werden (bereits verbucht).", errors);
            }

            KissMsg.ShowInfo(msg);

            // Daten neu anzeigen
            qryQuery.Refresh();
        }

        private void CtlQueryIkIndexbrief_Load(object sender, EventArgs e)
        {
            _filterUserID = Session.User.UserID;

            var qry = DBUtil.OpenSQL(@"
                SELECT DisplayText
                FROM dbo.vwUser WITH (READUNCOMMITTED)
                WHERE UserID = {0};", Session.User.UserID);

            edtIndexart.EditValue = 2;
            edtUser.LookupID = _filterUserID;
            edtUser.EditValue = Utils.ConvertToString(qry[DBO.vwUser.DisplayText]);
            edtDatumPer.EditValue = DateTime.Parse("01/01/" + DateTime.Today.AddYears(1).Year);
            tabControlSearch.SelectedTabIndex = 1;
            lblCount.Text = "";
            _zeileXVonY = KissMsg.GetMLMessage(Name, "ZeileXVonY", "Zeile {0} von {1}");
        }

        private void edtUser_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtUser.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "";
                }
                else
                {
                    _filterUserID = 0;
                    edtUser.LookupID = 0;
                    edtUser.EditValue = "";
                    edtUser.ToolTip = "";
                    return;
                }
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.SearchData(@"
                SELECT UserID$ = UserID,
                       DisplayText$ = DisplayText,
                       [Kürzel] = LogonName,
                       [Mitarbeiter/in] = NameVorname,
                       [Org.Einheit] = OrgUnit,
                       LogonNameVornameOrgUnit$ = LogonNameVornameOrgUnit
                FROM dbo.vwUser WITH (READUNCOMMITTED)
                WHERE (DisplayText LIKE '%' + {0} + '%' or {0} IS NULL)
                  AND UserID IN (SELECT DISTINCT UserID
                                 FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                 WHERE ModulID IN (3, 4))
                ORDER BY NameVorname;", searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                _filterUserID = Utils.ConvertToInt(dlg[0]);
                edtUser.LookupID = _filterUserID;
                edtUser.EditValue = Utils.ConvertToString(dlg[1]);
                edtUser.ToolTip = Utils.ConvertToString(dlg[1]);
            }
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            if (qryQuery.Count == 0)
            {
                btnCreate.Enabled = false;
                btnUndo.Enabled = false;
            }
        }
    }
}