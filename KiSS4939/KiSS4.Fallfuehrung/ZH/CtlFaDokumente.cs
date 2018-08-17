using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung.ZH
{
    public partial class CtlFaDokumente : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string QUERY_FADOKUMENTE = @"
            SELECT
              [Selected] = CONVERT(BIT, 0),
              [FaDokumenteID] = DOC.FaDokumenteID,
              [FaLeistungID] = DOC.FaLeistungID,
              [Vertraulich] = DOC.Vertraulich,
              [DatumErstellung] = DOC.DatumErstellung,
              [FaDokStatusCode] = DOC.FaDokStatusCode,
              [StatusLetztUserID] = DOC.StatusLetztUserID,
              [StatusLetztDatum] = DOC.StatusLetztDatum,
              [Absender] = DOC.Absender,
              [Absender_Freitext] = DOC.Absender_Freitext,
              [Adressat] = DOC.Adressat,
              [Adressat_Freitext] = DOC.Adressat_Freitext,
              [Stichwort] = DOC.Stichwort,
              [FaDokVerwendungCode] = DOC.FaDokVerwendungCode,
              [DocumentID] = DOC.DocumentID,
              [FaDokThemaCode] = DOC.FaDokThemaCode,
              [BaPersonID] = DOC.BaPersonID,
              [VisumXTaskID] = DOC.VisumXTaskID,
              [FaDokVisumStatusCode] = DOC.FaDokVisumStatusCode,
              [VisumStatusDatum] = DOC.VisumStatusDatum,
              [VisumStatusUserID] = DOC.VisumStatusUserID,
              [Bemerkung] = DOC.Bemerkung,
              [NichtKlibuRelevant] = CONVERT(BIT, DOC.NichtKlibuRelevant),
              [ErstelltUserID] = DOC.ErstelltUserID,
              [ErstelltDatum] = DOC.ErstelltDatum,
              [MutiertUserID] = CASE WHEN XDC.DateLastSave > DOC.MutiertDatum THEN XDC.UserID_LastSave ELSE DOC.MutiertUserID END,
              [MutiertDatum]  = dbo.fnMax(DOC.MutiertDatum, XDC.DateLastSave),
              [FaDokumenteTS] = DOC.FaDokumenteTS,
              [MigHerkunftCode] = DOC.MigHerkunftCode,
              [AbsenderName] = COALESCE(AUS.DisplayText, APR.NameVorname, AIN.Name),
              [AdressatName] = COALESCE(EUS.DisplayText, EPR.NameVorname, EIN.Name),
              [VisumStatusUserText] = VXU.DisplayText,
              [StatusLetztUserText] = DSU.DisplayText,
              [AllowChangeStatus] = CONVERT(BIT, CASE
                                                   WHEN DOC.ErstelltUserID = {2}    THEN 1
                                                   WHEN FLE.UserID = {2}            THEN 1
                                                   WHEN FLE.SachbearbeiterID = {2}  THEN 1
                                                   WHEN EXISTS (
                                                     SELECT L.FaLeistungID
                                                     FROM dbo.FaLeistung L WITH(READUNCOMMITTED)
                                                     WHERE L.FaFallID = FLE.FaFallID
                                                       AND ISNULL(L.FaProzessCode, 0) <> 201
                                                       AND FLE.FaProzessCode <> 201 -- Fallführung Alim
                                                       AND (L.UserID = {2} OR L.SachbearbeiterID = {2})) THEN 1
                                                   ELSE 0
                                                 END),
              [Ersteller] = USR.DisplayText,
              [ErstellerOrgUnit] = ORG.ItemName,
              [FaProzessCode] = FLE.FaProzessCode
            FROM dbo.FaDokumente            DOC WITH(READUNCOMMITTED)
              LEFT  JOIN dbo.FaLeistung     FLE WITH(READUNCOMMITTED) ON FLE.FaLeistungID = DOC.FaLeistungID

              LEFT  JOIN dbo.vwUserSimple   VXU WITH(READUNCOMMITTED) ON VXU.UserID = DOC.VisumStatusUserID
              LEFT  JOIN dbo.vwUserSimple   DSU WITH(READUNCOMMITTED) ON DSU.UserID = DOC.StatusLetztUserID

              LEFT  JOIN dbo.vwUserSimple   AUS WITH(READUNCOMMITTED) ON AUS.UserID = -DOC.Absender
              LEFT  JOIN dbo.vwPerson       APR WITH(READUNCOMMITTED) ON APR.BaPersonID = DOC.Absender
              LEFT  JOIN dbo.BaInstitution  AIN WITH(READUNCOMMITTED) ON AIN.BaInstitutionID = DOC.Absender

              LEFT  JOIN dbo.vwUserSimple   EUS WITH(READUNCOMMITTED) ON EUS.UserID = -DOC.Adressat
              LEFT  JOIN dbo.vwPersonSimple EPR WITH(READUNCOMMITTED) ON EPR.BaPersonID = DOC.Adressat
              LEFT  JOIN dbo.BaInstitution  EIN WITH(READUNCOMMITTED) ON EIN.BaInstitutionID = DOC.Adressat

              LEFT  JOIN dbo.vwUserSimple   USR WITH(READUNCOMMITTED) ON USR.UserID = DOC.ErstelltUserID
              LEFT JOIN dbo.XOrgUnit_User   OUU WITH(READUNCOMMITTED) ON OUU.UserID = USR.UserID
                                                                     AND OUU.OrgUnitMemberCode = 2
              LEFT JOIN dbo.XOrgUnit        ORG WITH(READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID

              LEFT  JOIN dbo.XDocument      XDC ON XDC.DocumentID = DOC.DocumentID
            WHERE FLE.FaFallID = {4} AND FLE.FaProzessCode <> 201  -- Fallführung Alimentenstelle ausschliessen
              AND DOC.Vertraulich = {1}
              AND (DOC.Vertraulich = 0 OR DOC.ErstelltUserID = {2} OR dbo.fnUserHasRight({2}, 'CtlFaDokumente_Visieren') = 1)
              AND ({3} = 0 OR DOC.NichtKlibuRelevant = 0)
            --- AND DOC.DatumErstellung >= {edtSucheDatumVon}
            --- AND DOC.DatumErstellung <= {edtSucheDatumBis}

            --- AND (AUS.DisplayText LIKE '%' + {edtSucheAbsender} + '%' OR APR.NameVorname LIKE '%' + {edtSucheAbsender} + '%' OR AIN.Name LIKE '%' + {edtSucheAbsender} + '%')
            --- AND (EUS.DisplayText LIKE '%' + {edtSucheAdressat} + '%' OR EPR.NameVorname LIKE '%' + {edtSucheAdressat} + '%' OR EIN.Name LIKE '%' + {edtSucheAdressat} + '%')

            --- AND DOC.Stichwort LIKE '%' + {edtSucheStichwort} + '%'
            --- AND DOC.FaDokThemaCode = {edtSucheFaDokThemaCode}
            --- AND DOC.Bemerkung LIKE '%' + {edtSucheBemerkung} + '%'

            --- AND DOC.FaDokVisumStatusCode = {edtSucheFaDokVisumStatusCode}
            --- AND DOC.FaDokStatusCode = {edtSucheFaDokStatusCode}
            --- AND DOC.FaDokVerwendungCode = {edtSucheFaDokVerwendungCode}
            --- AND DOC.BaPersonID = {edtSucheBaPersonID}

            --- AND ((DOC.NichtKlibuRelevant = 1 AND {edtSucheNichtKlibuRelevant} = 1)
            ---  OR (DOC.NichtKlibuRelevant = 0 AND {edtSucheKlibuRelevant} = 1))
            ";

        private const string QUERY_IKAUSZUG = @"
            SELECT
              [Selected] = CONVERT(BIT, 0),
              [FaDokumenteID] = -1,
              [FaLeistungID] = LEI.FaLeistungID,
              [Vertraulich] = 0, -- Nicht vertraulich
              [DatumErstellung] = IKA.ImportDatum,
              [FaDokStatusCode] = 2, -- FaDokStatusCode aktuell
              [StatusLetztUserID] = NULL,
              [StatusLetztDatum] = NULL,
              [Absender] = (SELECT TOP 1 BaInstitutionID FROM BaInstitution WHERE Name = 'SVA Zürich'),
              [Absender_Freitext] = NULL,
              [Adressat] = NULL,
              [Adressat_Freitext] = NULL,
              [Stichwort] = 'SVA: IK-Auszug von ' + CONVERT(VARCHAR, IKA.JahrVon) + ' bis ' + CONVERT(VARCHAR, IKA.JahrBis) + ' für ' + PER.NameVorname,  -- Stichwort
              [FaDokVerwendungCode] = 1, -- FaDokVerwendung	Eingang
              [DocumentID] = IKA.DocumentID,
              [FaDokThemaCode] = 5, -- 5 Versicherungen und Ersatzeinkommen
              [BaPersonID] = PER.BaPersonID,
              [VisumXTaskID] = NULL,
              [FaDokVisumStatusCode] = NULL,
              [VisumStatusDatum] = NULL,
              [VisumStatusUserID] = NULL,
              [Bemerkung] = CASE
                              WHEN IKA.SstIkAuszugAnforderungCode = 1 THEN 'Automatisch angeforderter IK-Auszug (Grund: Genehmigung 1.Finanzplan)'
                              WHEN IKA.SstIkAuszugAnforderungCode = 2 THEN 'Automatisch angeforderter IK-Auszug (Grund: WSH seit 2 Jahren)'
                              WHEN IKA.SstIkAuszugAnforderungCode = 3 THEN 'Automatisch angeforderter IK-Auszug (Grund: WSH seit 5 Jahren)'
                              WHEN IKA.SstIkAuszugAnforderungCode = 4 THEN 'Manuell angeforderter IK-Auszug' + ISNULL(' durch ' + USR.DisplayText, '')
                              ELSE ''
                            END,
              [NichtKlibuRelevant] = 0,
              [ErstelltUserID] = NULL,
              [ErstelltDatum] = NULL,
              [MutiertUserID] = NULL,
              [MutiertDatum] = XDC.DateLastSave,
              [FaDokumenteTS] = CONVERT(BINARY, NULL),
              [MigHerkunftCode] = NULL,
              [AbsenderName] =  AIN.Name,
              [AdressatName] = NULL,
              [VisumStatusUserText] = NULL,
              [StatusLetztUserText] = NULL,
              [AllowChangeStatus] = CONVERT(BIT, CASE
                                                   WHEN LEI.UserID = {2}            THEN 1
                                                   WHEN LEI.SachbearbeiterID = {2}  THEN 1
                                                   WHEN EXISTS (
                                                       SELECT L.FaLeistungID
                                                       FROM dbo.FaLeistung L WITH(READUNCOMMITTED)
                                                       WHERE L.FaFallID = LEI.FaFallID
                                                         AND IsNull(L.FaProzessCode, 0) <> 201
                                                         AND LEI.FaProzessCode <> 201 -- Fallführung Alim
                                                         AND (L.UserID = {2} OR L.SachbearbeiterID = {2})) THEN 1
                                                   ELSE 0
                                                 END),
              [Ersteller] = NULL,
              [ErstellerOrgUnit] = NULL,
              [FaProzessCode] = LEI.FaProzessCode
            FROM   dbo.SstIKAuszug         IKA WITH (READUNCOMMITTED)
              INNER JOIN  dbo.FaFallPerson   FAP WITH (READUNCOMMITTED) ON FAP.BaPersonID = IKA.BaPersonID
              LEFT  JOIN  dbo.vwUserSimple   USR WITH (READUNCOMMITTED) ON USR.UserID = IKA.AnforderungUserID
              INNER JOIN  dbo.FaLeistung     LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = (SELECT TOP 1 FaLeistungID FROM FaLeistung WHERE FaFallID = FAP.FaFallID AND FaProzessCode = 200 ORDER BY DatumVon DESC)	-- Aktuellste aktive Fallführung
              INNER JOIN  dbo.vwPersonSimple PER WITH (READUNCOMMITTED) ON PER.BaPersonID = IKA.BaPersonID

              LEFT  JOIN dbo.XDocument       XDC WITH(READUNCOMMITTED) ON XDC.DocumentID = IKA.DocumentID
              LEFT  JOIN dbo.BaInstitution   AIN WITH(READUNCOMMITTED) ON AIN.BaInstitutionID = (SELECT TOP 1 BaInstitutionID FROM BaInstitution WHERE Name = 'SVA Zürich')

            WHERE (LEI.FaLeistungID = {0} OR ({5} = 0 AND LEI.FaFallID = {4} AND LEI.FaProzessCode IN (210, 301, 302, 304)))  -- Zeige alle Dokumente dieser Leistung an, oder falls dies keine FA-Leistung ist, zeige auch V- und WIK-Dokumente mit an
              AND 0 = {1}   -- vertraulich
              AND IKA.DocumentID IS NOT NULL AND IKA.Deaktiviert = 0 -- IK-Auszüge ohne Dokumente werden nicht angezeigt
            --- AND IKA.ImportDatum >= {edtSucheDatumVon}
            --- AND IKA.ImportDatum <= {edtSucheDatumBis}

            --- AND (AIN.Name LIKE '%' + {edtSucheAbsender} + '%')
            --- AND (NULL LIKE '%' + {edtSucheAdressat} + '%') --soll keine Resultate liefern, wenn dieses Suchfeld ausgefüllt ist.

            --- AND ('SVA: IK-Auszug von ' + CONVERT(varchar, IKA.JahrVon) + ' bis ' + CONVERT(varchar, IKA.JahrBis) + ' für ' + PER.NameVorname) LIKE '%' + {edtSucheStichwort} + '%'
            --- AND 5 = {edtSucheFaDokThemaCode}
            --- AND CASE WHEN IKA.SstIkAuszugAnforderungCode = 1 THEN 'Automatisch angeforderter IK-Auszug (Grund: Genehmigung 1.Finanzplan)' WHEN IKA.SstIkAuszugAnforderungCode = 2 THEN 'Automatisch angeforderter IK-Auszug (Grund: WSH seit 2 Jahren)'	WHEN IKA.SstIkAuszugAnforderungCode = 3 THEN 'Automatisch angeforderter IK-Auszug (Grund: WSH seit 5 Jahren)' WHEN IKA.SstIkAuszugAnforderungCode = 4 THEN 'Manuell angeforderter IK-Auszug' + ISNULL(' durch ' + USR.DisplayText, '') ELSE ''	END LIKE '%' + {edtSucheBemerkung} + '%'

            --- AND NULL = {edtSucheFaDokVisumStatusCode}
            --- AND 2 = {edtSucheFaDokStatusCode}
            --- AND 1 = {edtSucheFaDokVerwendungCode}
            --- AND PER.BaPersonID = {edtSucheBaPersonID}
            ";

        private const string QUERY_TEMPLATE_BOTH = @"
            {0}
            UNION ALL
            {1}
            ORDER BY DatumErstellung, FaDokumenteID
            ";

        private const string QUERY_TEMPLATE_SINGLE = @"
            {0}
            ORDER BY DatumErstellung, FaDokumenteID
            ";

        private readonly bool _nurFinanzrelevante;

        #endregion

        #region Private Fields

        private int _faFallID = -1;
        private int _faLeistungID = -1;
        private bool _istAlim;
        private bool _istVertraulich;

        #endregion

        #endregion

        #region Constructors

        public CtlFaDokumente()
        {
            InitializeComponent();

            // TODO:
            // LOV FaThema oder FaDokumentThema löschen

            // Auswahllisten erstellen:
            colFaDokThemaCode.ColumnEdit = grdFaDokumente.GetLOVLookUpEdit("FaDokThema"); // ohne Filter

            colFaDokVisumStatusCode.ColumnEdit = grdFaDokumente.GetLOVLookUpEdit((SqlQuery)edtFaDokVisumStatusCode.Properties.DataSource, "Code", "ShortText");
            colFaDokStatusCode.ColumnEdit = grdFaDokumente.GetLOVLookUpEdit((SqlQuery)edtFaDokStatusCode.Properties.DataSource, "Code", "ShortText");
            colFaDokVerwendungCode.ColumnEdit = grdFaDokumente.GetLOVLookUpEdit((SqlQuery)edtFaDokVerwendungCode.Properties.DataSource, "Code", "Text");

            colTaskStatusCode.ColumnEdit = grdXTask.GetLOVLookUpEdit("TaskStatus");
            colTaskResponseCode.ColumnEdit = grdXTask.GetLOVLookUpEdit("TaskResponse");
            colFaDokVisumStatusCode_Task.ColumnEdit = grdXTask.GetLOVLookUpEdit((SqlQuery)edtFaDokVisumStatusCode.Properties.DataSource, "Code", "ShortText");
            btnAntworten.Enabled = DBUtil.UserHasRight("CtlFaDokumente_Visieren");

            _nurFinanzrelevante = DBUtil.UserHasRight("CtlFaDokumente_NurFinanzrelevante") && !Session.User.IsUserAdmin;
            if (_nurFinanzrelevante)
            {
                edtSucheKlibuRelevant.Visible = false;
                edtSucheNichtKlibuRelevant.Visible = false;

                chkNichtKlibuRelevant.EditMode = EditModeType.ReadOnly;
            }
        }

        #endregion

        #region Properties

        public bool AlwaysOpen
        {
            get { return true; }
        }

        #endregion

        #region EventHandlers

        private void btnAktuell_Click(object sender, EventArgs e)
        {
            qryFaDokumente.Post();

            bool hasRightStatusReset = DBUtil.UserHasRight("CtlFaDokumente_StatusReset");

            // Hole alle selektierten Rows. Falls keine selektiert ist, wird nur die aktuell hervorgehobene Zeile zurückgegeben
            bool nothingSelected;

            List<DataRow> rows = GetAllSelectedRows(out nothingSelected);

            if (rows.Count == 0)
            {
                // Keine Zeile selektiert, raus hier
                KissMsg.ShowInfo("Bitte selektieren Sie eines oder mehrere Dokumente und versuchen Sie es nochmals.");
                return;
            }

            // Prüfe, ob alle Dokumente als Aktuell gesetzt werden können
            string noStatusChangeAllowed = "";
            string noDocument = "";

            foreach (DataRow row in rows)
            {
                // Stelle sicher, dass entweder der Benutzer die generelle Berechtigung für Status-Änderungen hat, oder die selektierten Dokumente Ihrerseits den Statuswechsel zulassen
                bool rowAllowChangeStatus = hasRightStatusReset || (bool)row["AllowChangeStatus"];   // Entweder hat der Benutzer die generelle Berechtigung für Status-Änderungen, oder aber er ist direkt involviert mit dem aktuellen Dokument

                if (!rowAllowChangeStatus)
                {
                    // Dieses Dokument kann nicht updated werden, wir merken uns hier den Dokument-Namen
                    noStatusChangeAllowed = noStatusChangeAllowed + string.Format("\r\n{0} {1}", ((DateTime)row["DatumErstellung"]).ToString("dd.MM.yyyy"), row["Stichwort"]);
                }

                // Stelle sicher, dass effektiv ein Dokument angehängt ist
                if (DBUtil.IsEmpty(row["DocumentID"]))
                {
                    // Es ist kein Dokument angehängt
                    noDocument = noDocument + string.Format("\r\n{0} {1}", ((DateTime)row["DatumErstellung"]).ToString("dd.MM.yyyy"), row["Stichwort"]);
                }
            }

            if (noStatusChangeAllowed != "")
            {
                // Mind. ein Dokument erlaubt kein Status-Änderung
                KissMsg.ShowError(string.Format("Die selektierten Dokumente können nicht auf Aktuell gesetzt werden, da die folgenden Dokumente keinen Status-Änderung erlauben: {0}", noStatusChangeAllowed));
                return;
            }

            if (noDocument != "")
            {
                // Mind. ein Dokument erlaubt kein Status-Änderung
                KissMsg.ShowError(string.Format("Die selektierten Dokumente können nicht auf Aktuell gesetzt werden, da die folgenden Dokumente keine Dokument-Datei angehängt haben: {0}", noDocument));
                return;
            }

            if (rows.Count > 1)
            {
                if (!KissMsg.ShowQuestion("Sind Sie sicher, dass Sie die " + rows.Count + " selektierten Dokumente auf Aktuell setzen möchten?"))
                {
                    return;
                }
            }

            // Ok, wenn wir hierhin kommen, können wir alle selektierten Dokumente auf Aktuell setzen
            Session.BeginTransaction();
            try
            {
                ChangeDokumentStatus(rows, 2, nothingSelected);  // 2 = Aktuell
            }
            catch (Exception ex)
            {
                Session.Rollback();

                // Mind. ein Dokument erlaubt kein Status-Änderung
                KissMsg.ShowError("Ein unerwarteter Fehler ist aufgetreten beim auf Aktuell setzen der selektierten Dokumente.", ex);
            }
            finally
            {
                rows.Clear();
            }
        }

        private void btnAlle_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in qryFaDokumente.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["FaDokumenteID"]) && (int)row["FaDokumenteID"] != -1)
                {
                    // Gültiges FA-Dokument, das selektiert werden kann
                    row["Selected"] = true;
                }
            }
        }

        private void btnAnfrage_Click(object sender, EventArgs e)
        {
            if (qryFaDokumente["FaDokumenteID"] is int)
            {
                if (!(qryFaDokumente["DocumentID"] is int))
                {
                    KissMsg.ShowInfo("Damit Sie ein neues Visum anfragen können, muss ein Dokument vorhanden sein.");
                    return;
                }
                // show dialog
                DlgVisumAnfragen dlg = new DlgVisumAnfragen((int)qryFaDokumente["FaDokumenteID"], (int)qryFaDokumente["FaLeistungID"]);
                switch (dlg.ShowDialog())
                {
                    case DialogResult.OK:
                        DBUtil.ExecSQL(@"
                            UPDATE dbo.FaDokumente
                              SET FaDokStatusCode = 2,
                                StatusLetztUserID = {1},
                                StatusLetztDatum  = GetDate()
                            WHERE FaDokumenteID = {0} AND FaDokStatusCode = 1

                            UPDATE dbo.FaDokumente
                              SET FaDokVisumStatusCode = 1,
                                VisumStatusDatum = GetDate(),
                                VisumStatusUserID = {1},
                                VisumXTaskID = {2}
                            WHERE FaDokumenteID = {0}",
                             qryFaDokumente["FaDokumenteID"],
                             Session.User.UserID,
                             dlg.NewXTaskID);
                        break;

                    default:
                        return;
                }

                // refresh data to get changes
                qryFaDokumente.Refresh();

                System.Collections.Specialized.HybridDictionary dic = FormController.GetMessage("FrmFall", false, "Action", "GetJumpToPath") as System.Collections.Specialized.HybridDictionary;
                if (dic != null)
                {
                    dic["XTaskID"] = dlg.NewXTaskID;

                    DBUtil.ExecSQL("UPDATE dbo.XTask SET JumpToPath = {1} WHERE XTaskID = {0}",
                         dic["XTaskID"], FormController.ConvertToString(dic));
                }
            }
        }

        private void btnAntworten_Click(object sender, EventArgs e)
        {
            if (qryXTask["XTaskID"] is int)
            {
                int faDokVisumStatusCode;

                DlgVisieren dlg = new DlgVisieren((int)qryXTask["XTaskID"]);
                switch (dlg.ShowDialog())
                {
                    case DialogResult.OK:
                    case DialogResult.Yes:
                        faDokVisumStatusCode = 4;
                        break;

                    case DialogResult.No:
                        faDokVisumStatusCode = 3;
                        break;

                    default:
                        return;
                }

                DBUtil.ExecSQL(@"
                    UPDATE dbo.XTask
                      SET TaskStatusCode = 4 -- verfallten
                    WHERE FaDokumenteID = {0}
                      AND TaskStatusCode < 3
                      AND TaskTypeCode = 2

                    UPDATE dbo.FaDokumente
                      SET FaDokVisumStatusCode = {1},
                        VisumStatusDatum = GetDate(),
                        VisumStatusUserID = {2},
                        VisumXTaskID = {3}
                    WHERE FaDokumenteID = {0}",
                     qryFaDokumente["FaDokumenteID"],
                     faDokVisumStatusCode,
                     Session.User.UserID,
                     qryXTask["XTaskID"]);

                qryFaDokumente.Refresh();
            }
        }

        private void btnBearbeiten_Click(object sender, EventArgs e)
        {
            qryFaDokumente.Post();

            bool hasRightStatusReset = DBUtil.UserHasRight("CtlFaDokumente_StatusReset");

            // Hole alle selektierten Rows. Falls keine selektiert ist, wird nur die aktuell hervorgehobene Zeile zurückgegeben
            bool nothingSelected;

            List<DataRow> rows = GetAllSelectedRows(out nothingSelected);

            if (rows.Count == 0)
            {
                // Keine Zeile selektiert, raus hier
                KissMsg.ShowInfo("Bitte selektieren Sie eines oder mehrere Dokumente und versuchen Sie es nochmals.");
                return;
            }

            // Prüfe, ob alle Dokumente auf In Bearbeitung gesetzt werden können
            string historisierteDokumente = "";
            string visierteDokumente = "";
            string noStatusChangeAllowed = "";

            foreach (DataRow row in rows)
            {
                // Stelle sicher, dass entweder der Benutzer die generelle Berechtigung für Status-Änderungen hat, oder die selektierten Dokumente Ihrerseits den Statuswechsel zulassen
                bool rowAllowChangeStatus = hasRightStatusReset || (bool)row["AllowChangeStatus"];   // Entweder hat der Benutzer die generelle Berechtigung für Status-Änderungen, oder aber er ist direkt involviert mit dem aktuellen Dokument

                if (!rowAllowChangeStatus)
                {
                    // Dieses Dokument kann nicht updated werden, wir merken uns hier den Dokument-Namen
                    noStatusChangeAllowed = noStatusChangeAllowed + string.Format("\r\n{0} {1}", ((DateTime)row["DatumErstellung"]).ToString("dd.MM.yyyy"), row["Stichwort"]);
                }

                // Stelle sicher, dass kein Dokument auf Status Historisiert steht, da historisierte Dokumente nicht direkt in Status "i.B." überführt werden können
                int faDokStatusCode = Utils.ConvertToInt(row["FaDokStatusCode"]);
                if (faDokStatusCode == 3)
                {
                    // Dieses Dokument ist historisiert
                    historisierteDokumente = historisierteDokumente + string.Format("\r\n{0} {1}", ((DateTime)row["DatumErstellung"]).ToString("dd.MM.yyyy"), row["Stichwort"]);
                }

                // Prüfe, ob ein Dokument bereits visiert ist
                if (!DBUtil.IsEmpty(row["FaDokVisumStatusCode"]) && (int)row["FaDokVisumStatusCode"] == 4)
                {
                    // Dieses Dokument ist visiert
                    visierteDokumente = visierteDokumente + string.Format("\r\n{0} {1}", ((DateTime)row["DatumErstellung"]).ToString("dd.MM.yyyy"), row["Stichwort"]);
                }
            }

            if (noStatusChangeAllowed != "")
            {
                // Mind. ein Dokument erlaubt kein Status-Änderung
                KissMsg.ShowError(string.Format("Die selektierten Dokumente können nicht auf in Bearbeitung gesetzt werden, da die folgenden Dokumente keinen Status-Änderung erlauben: {0}", noStatusChangeAllowed));
                return;
            }

            if (historisierteDokumente != "")
            {
                // Mind. ein Dokument ist historisiert
                KissMsg.ShowError(string.Format("Die selektierten Dokumente können nicht auf in Bearbeitung gesetzt werden, da die folgenden Dokumente historisiert sind. Diese Dokumente müssen zuerst auf Aktuell gesetzt werden: {0}", historisierteDokumente));
                return;
            }

            if (visierteDokumente != "")
            {
                // Mind. ein Dokument ist visiert
                KissMsg.ShowError(string.Format("Die selektierten Dokumente können nicht auf in Bearbeitung gesetzt werden, da die folgenden Dokumente visiert sind: {0}", visierteDokumente));
                return;
            }

            if (rows.Count > 1)
            {
                if (!KissMsg.ShowQuestion("Sind Sie sicher, dass Sie die " + rows.Count + " selektierten Dokumente auf in Bearbeitung setzen möchten?"))
                {
                    return;
                }
            }

            // Ok, wenn wir hierhin kommen, können wir alle selektierten Dokumente auf in Bearbeitung setzen
            Session.BeginTransaction();
            try
            {
                ChangeDokumentStatus(rows, 1, nothingSelected);  // 1 = in Bearbeitung
            }
            catch (Exception ex)
            {
                Session.Rollback();

                // Mind. ein Dokument erlaubt kein Status-Änderung
                KissMsg.ShowError("Ein unerwarteter Fehler ist aufgetreten beim auf In Bearbeitung setzen der selektierten Dokumente.", ex);
            }
            finally
            {
                rows.Clear();
            }
        }

        private void btnHistorisieren_Click(object sender, EventArgs e)
        {
            qryFaDokumente.Post();

            bool hasRightStatusReset = DBUtil.UserHasRight("CtlFaDokumente_StatusReset");

            // Hole alle selektierten Rows. Falls keine selektiert ist, wird nur die aktuell hervorgehobene Zeile zurückgegeben
            bool nothingSelected;

            List<DataRow> rows = GetAllSelectedRows(out nothingSelected);

            if (rows.Count == 0)
            {
                // Keine Zeile selektiert, raus hier
                KissMsg.ShowInfo("Bitte selektieren Sie eines oder mehrere Dokumente und versuchen Sie es nochmals.");
                return;
            }

            // Prüfe, ob alle Dokumente Historisiert werden können
            string noStatusChangeAllowed = "";
            string visierteDokumente = "";
            int anzahlVisierteDokumente = 0;
            string noDocument = "";

            foreach (DataRow row in rows)
            {
                // Stelle sicher, dass entweder der Benutzer die generelle Berechtigung für Status-Änderungen hat, oder die selektierten Dokumente Ihrerseits den Statuswechsel zulassen
                bool rowAllowChangeStatus = hasRightStatusReset || (bool)row["AllowChangeStatus"];   // Entweder hat der Benutzer die generelle Berechtigung für Status-Änderungen, oder aber er ist direkt involviert mit dem aktuellen Dokument

                if (!rowAllowChangeStatus)
                {
                    // Dieses Dokument kann nicht updated werden, wir merken uns hier den Dokument-Namen
                    noStatusChangeAllowed = noStatusChangeAllowed + string.Format("\r\n{0} {1}", ((DateTime)row["DatumErstellung"]).ToString("dd.MM.yyyy"), row["Stichwort"]);
                }

                // Prüfe, ob ein Dokument bereits visiert ist
                if (!DBUtil.IsEmpty(row["FaDokVisumStatusCode"]) && (int)row["FaDokVisumStatusCode"] == 4)
                {
                    // Dieses Dokument ist visiert
                    visierteDokumente = visierteDokumente + string.Format("\r\n{0} {1}", ((DateTime)row["DatumErstellung"]).ToString("dd.MM.yyyy"), row["Stichwort"]);
                    anzahlVisierteDokumente++;
                }

                // Stelle sicher, dass effektiv ein Dokument angehängt ist
                if (DBUtil.IsEmpty(row["DocumentID"]))
                {
                    // Es ist kein Dokument angehängt
                    noDocument = noDocument + string.Format("\r\n{0} {1}", ((DateTime)row["DatumErstellung"]).ToString("dd.MM.yyyy"), row["Stichwort"]);
                }
            }

            if (noStatusChangeAllowed != "")
            {
                // Mind. ein Dokument erlaubt kein Status-Änderung
                KissMsg.ShowError(string.Format("Die selektierten Dokumente können nicht historisiert werden, da die folgenden Dokumente keinen Status-Änderung erlauben: {0}", noStatusChangeAllowed));
                return;
            }

            if (noDocument != "")
            {
                // Mind. ein Dokument erlaubt kein Status-Änderung
                KissMsg.ShowError(string.Format("Die selektierten Dokumente können nicht historisiert werden, da die folgenden Dokumente keine Dokument-Datei angehängt haben: {0}", noDocument));
                return;
            }

            if (visierteDokumente != "")
            {
                // Mind. ein Dokument ist bereits visiert
                if (!KissMsg.ShowQuestion(string.Format("Sind Sie sicher, dass sie die selektierten {0} Dokumente inkl. den folgenden {1} bereits visierten Dokumenten historisieren wollen? {2}", rows.Count, anzahlVisierteDokumente, visierteDokumente)))
                {
                    // Der Benutzer hat sich für Nein entschieden
                    return;
                }
            }
            else if (rows.Count > 1)
            {
                if (!KissMsg.ShowQuestion("Sind Sie sicher, dass Sie die " + rows.Count + " selektierten Dokumente historisieren möchten?"))
                {
                    return;
                }
            }

            // Ok, wenn wir hierhin kommen, können wir alle selektierten Dokumente historisieren
            Session.BeginTransaction();
            try
            {
                ChangeDokumentStatus(rows, 3, nothingSelected);  // 3 = Historisiert
            }
            catch (Exception ex)
            {
                Session.Rollback();

                // Mind. ein Dokument erlaubt kein Status-Änderung
                KissMsg.ShowError("Ein unerwarteter Fehler ist aufgetreten beim historisieren der selektierten Dokumente.", ex);
            }
            finally
            {
                rows.Clear();
            }
        }

        private void btnKeine_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in qryFaDokumente.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["FaDokumenteID"]) && (int)row["FaDokumenteID"] != -1)
                {
                    // Gültiges FA-Dokument, das deselektiert werden kann
                    row["Selected"] = false;
                }
            }
        }

        private void btnWiederrufen_Click(object sender, EventArgs e)
        {
            qryXTask.Post();

            DBUtil.ExecSQL(@"
                UPDATE dbo.XTask
                  SET TaskStatusCode = 4
                WHERE FaDokumenteID = {0}
                  AND TaskStatusCode < 3
                  AND TaskTypeCode = 2

                UPDATE dbo.FaDokumente
                  SET FaDokVisumStatusCode = NULL,
                    StatusLetztUserID = {1},
                    StatusLetztDatum  = GetDate()
                WHERE FaDokumenteID = {0}
                  AND FaDokVisumStatusCode = 1 -- Anfrage",
                 qryXTask["FaDokumenteID"],
                 Session.User.UserID);

            qryFaDokumente.Refresh();
        }

        private void chkNichtKlibuRelevant_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkNichtKlibuRelevant_CheckStateChanged(object sender, EventArgs e)
        {
        }

        private void chkNichtKlibuRelevant_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void chkNichtKlibuRelevant_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
        }

        private void CtlFaDokumente_Load(object sender, EventArgs e)
        {
            NewSearch();
            SetSqlForQryFaDokumente();

            tabControlSearch.SelectedTabIndex = 0;
            tabDocument.SelectedTabIndex = 0;
        }

        private void docDokument_DocumentOpening(object sender, CancelEventArgs e)
        {
            if (!DBUtil.IsEmpty(qryFaDokumente["DocumentID"]) && _istVertraulich
                 && !Session.User.UserID.Equals(qryFaDokumente["ErstelltUserID"]))
            {
                DBUtil.ExecSQL(@"
                    INSERT INTO dbo.FaZugriff (UserID, WinLogonName, FaFallID, FaLeistungID, FaZugriffActivityCode, FaZugriffItemCode, FaZugriffItemID)
                      VALUES ({0}, {1}, {2}, {3}, 1, 1, {4})",
                     Session.User.UserID, Session.User.WinDomainLogonName,
                     _faFallID, _faLeistungID, qryFaDokumente["FaDokumenteID"]);
            }
        }

        private void docDokument_DocumentSaved(object sender, EventArgs e)
        {
            qryFaDokumente["MutiertDatum"] = DateTime.Now;
            qryFaDokumente["MutiertUserID"] = Session.User.UserID;
            ctlErfassungMutation.ShowInfo();
        }

        private void edtAbsender_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            SetAdressatAbsender(edtAbsender, "Absender", "AbsenderName", e);
        }

        private void edtAdressat_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            SetAdressatAbsender(edtAdressat, "Adressat", "AdressatName", e);
        }

        private void qryFaDokumente_AfterFill(object sender, EventArgs e)
        {
            if (qryFaDokumente.Count > 0)
            {
                qryFaDokumente.Last();
            }
        }

        private void qryFaDokumente_AfterInsert(object sender, EventArgs e)
        {
            qryFaDokumente["FaLeistungID"] = _faLeistungID;
            qryFaDokumente["Vertraulich"] = _istVertraulich;

            qryFaDokumente["DatumErstellung"] = DateTime.Today;
            qryFaDokumente["FaDokVerwendungCode"] = 2; // Ausgang

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT
                  USR.OrgUnit,
                  USRS.DisplayText
                FROM dbo.vwUser USR
                  INNER JOIN dbo.vwUserSimple USRS ON USRS.UserID = USR.UserID
                WHERE USR.UserID = {0};",
                Session.User.UserID);
            qryFaDokumente["Ersteller"] = qry["DisplayText"];
            qryFaDokumente["ErstellerOrgUnit"] = qry["OrgUnit"];

            qryFaDokumente["FaDokStatusCode"] = 1; // in Bearbeitung
            qryFaDokumente["StatusLetztUserID"] = Session.User.UserID;
            qryFaDokumente["StatusLetztUserText"] = qry["DisplayText"];
            qryFaDokumente["StatusLetztDatum"] = DateTime.Now;

            qry = DBUtil.OpenSQL(@"
                SELECT Absender = -USR.UserID, AbsenderName = USR.DisplayText, FaProzessCode = FLE.FaProzessCode
                FROM dbo.FaLeistung           FLE
                  INNER JOIN dbo.vwUserSimple USR ON USR.UserID = FLE.UserID
                WHERE FLE.FaLeistungID = {0}", _faLeistungID);
            qryFaDokumente["Absender"] = qry["Absender"];
            qryFaDokumente["AbsenderName"] = qry["AbsenderName"];
            qryFaDokumente["FaProzessCode"] = 200;      // Alle Dokumente, die in dieser Maske erstellt werden, sind Fall-Dokumente, daher ist der Prozesscode = 200 (= Fallführung)

            qryFaDokumente["AllowChangeStatus"] = true;

            tabDocument.SelectTab(tpgDocument);

            edtStichwort.Focus();
        }

        private void qryFaDokumente_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if ((int)qryFaDokumente["FaProzessCode"] == 210)
            {
                // VM-Dokumente, die in den VM-Leistungen verwaltet werden, müssen daher hier Readonly sein
                KissMsg.ShowInfo("Berichts-Dokumente von M-Leistungen können nicht gelöscht werden.");
                throw new KissCancelException("Berichts-Dokumente von M-Leistungen können nicht gelöscht werden.");
            }
        }

        private void qryFaDokumente_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDatumErstellung, lblDatumErstellung.Text);

            DBUtil.CheckNotNullField(edtFaDokThemaCode, lblFaDokThemaCode.Text);

            DBUtil.CheckNotNullField(edtFaDokVerwendungCode, lblFaDokVerwendungCode.Text);

            DBUtil.CheckNotNullField(edtStichwort, lblStichwort.Text);

            // TODO: Checken, dass Erfassungsdatum grösser als Abschlussdatum der Leistung ist?

            System.Diagnostics.Debug.WriteLine("qryFaDokumente.SqlQuery_BeforePost ... Mutation erfolgt");
            ctlErfassungMutation.SetFields();
        }

        private void qryFaDokumente_PositionChanged(object sender, EventArgs e)
        {
            // TODO: Wass soll gemäss XTask noch erstellt werden?

            // Felder einstellen:
            if (qryFaDokumente.Count == 0 || !qryFaDokumente.CanUpdate ||
                (qryFaDokumente.Row.RowState != DataRowState.Added && !DBUtil.IsEmpty(qryFaDokumente["FaDokumenteID"]) && (int)qryFaDokumente["FaDokumenteID"] == -1))
            {
                // Keine Dokumente vorhanden resp. kein Update-Recht, resp. das Dokument ist ein fiktives FaDokument, das via View hineinprojeziert wurde
                btnAktuell.Enabled = false;
                btnBearbeiten.Enabled = false;
                btnHistorisieren.Enabled = false;
                btnAlle.Enabled = false;
                btnKeine.Enabled = false;
                colSelected.OptionsColumn.ReadOnly = true;

                qryFaDokumente.EnableBoundFields(false);

                edtAbsender.EditMode = EditModeType.ReadOnly;
                edtAdressat.EditMode = EditModeType.ReadOnly;
                docDokument.EditMode = EditModeType.ReadOnly;

                ctlErfassungMutation.ShowInfo();

                return;
            }

            if (Utils.ConvertToInt(qryFaDokumente["FaDokVisumStatusCode"]) == 4)
            {
                docDokument.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                docDokument.EditMode = EditModeType.Normal;
            }

            btnAktuell.Enabled = true;
            btnBearbeiten.Enabled = true;
            btnHistorisieren.Enabled = true;
            btnAlle.Enabled = true;
            btnKeine.Enabled = true;
            colSelected.OptionsColumn.ReadOnly = false;

            edtAbsender.EditMode = EditModeType.Normal;
            edtAdressat.EditMode = EditModeType.Normal;

            qryFaDokumente.EnableBoundFields();

            ctlErfassungMutation.ShowInfo();

            if (tabDocument.SelectedTab == tpgVisum)
            {
                qryXTask.Fill(qryFaDokumente["FaDokumenteID"]);
            }

            int faDokStatusCode = Utils.ConvertToInt(qryFaDokumente["FaDokStatusCode"]);
            bool allowChangeStatus = DBUtil.IsEmpty(qryFaDokumente["AllowChangeStatus"]) || (bool)qryFaDokumente["AllowChangeStatus"];

            bool hasRightStatusReset = DBUtil.UserHasRight("CtlFaDokumente_StatusReset");
            bool hasRightVisieren = DBUtil.UserHasRight("CtlFaDokumente_Visieren");
            bool hasRightLoeschen = DBUtil.UserHasRight("CtlFaDokumente_Loeschen");

            // Set default values for Document creation / deletion
            docDokument.CanDeleteDocument = false;
            docDokument.CanCreateDocument = true;
            docDokument.CanImportDocument = true;

            switch (faDokStatusCode)
            {
                case 0:
                case 1: // in Bearbeitung
                    qryFaDokumente.CanDelete = allowChangeStatus || hasRightLoeschen;
                    docDokument.CanDeleteDocument = allowChangeStatus;
                    break;

                case 2: // Aktuell
                case 3: // Historisiert
                    qryFaDokumente.CanDelete = false;
                    break;
            }

            docDokument.EditMode = EditModeType.Normal;
            qryFaDokumente.EnableBoundFields(qryFaDokumente.Count > 0 && qryFaDokumente.CanUpdate);

            if (faDokStatusCode == 3) // Historisiert
            {
                qryFaDokumente.CanDelete = false;
                ((IKissBindableEdit)edtDatumErstellung).AllowEdit(false);

                ((IKissBindableEdit)edtAbsender).AllowEdit(false);
                ((IKissBindableEdit)edtAbsenderFreitext).AllowEdit(false);

                ((IKissBindableEdit)edtAdressat).AllowEdit(false);
                ((IKissBindableEdit)edtAdressatFreitext).AllowEdit(false);

                docDokument.EditMode = EditModeType.ReadOnly;
            }
            else if (DBUtil.IsEmpty(qryFaDokumente["FaDokVisumStatusCode"])) // Noch kein Visum
            {
            }
            else if ((int)qryFaDokumente["FaDokVisumStatusCode"] == 1) // Visum Angefragt
            {
                qryFaDokumente.CanDelete = false;

                if (!hasRightVisieren)
                {
                    qryFaDokumente.EnableBoundFields(false);
                    docDokument.EditMode = EditModeType.ReadOnly;
                }
                else
                {
                    ((IKissBindableEdit)edtDatumErstellung).AllowEdit(false);

                    ((IKissBindableEdit)edtAbsender).AllowEdit(false);
                    ((IKissBindableEdit)edtAbsenderFreitext).AllowEdit(false);

                    ((IKissBindableEdit)edtAdressat).AllowEdit(false);
                    ((IKissBindableEdit)edtAdressatFreitext).AllowEdit(false);

                    ((IKissBindableEdit)edtBaPersonID).AllowEdit(false);
                }
            }
            else if ((int)qryFaDokumente["FaDokVisumStatusCode"] == 3) // Visum Abgelehnt
            {
                qryFaDokumente.CanDelete = false;

                ((IKissBindableEdit)edtDatumErstellung).AllowEdit(false);
            }
            else if ((int)qryFaDokumente["FaDokVisumStatusCode"] == 4) // Visum Erteilt
            {
                qryFaDokumente.CanDelete = false;
                qryFaDokumente.EnableBoundFields(false);
                docDokument.EditMode = EditModeType.ReadOnly;

                if (qryFaDokumente.CanUpdate)
                    edtBemerkung.EditMode = EditModeType.Normal;
            }

            if ((int)qryFaDokumente["FaProzessCode"] == 210)
            {
                // VM-Dokumente, die in den VM-Leistungen verwaltet werden. Dokument kann nur editiert werden, aber nur solange die V-Leistung aktiv ist
                docDokument.CanCreateDocument = false;
                docDokument.CanDeleteDocument = false;
                docDokument.CanImportDocument = false;

                bool inaktiv = (bool)DBUtil.ExecuteScalarSQL(@"SELECT CONVERT(bit, CASE WHEN DatumBis IS NULL THEN 0 ELSE 1 END) FROM FaLeistung WHERE FaLeistungID = {0}", qryFaDokumente["FaLeistungID"]);

                if (inaktiv)
                {
                    // V-Leistung ist inaktiv => Dokument ist readonly
                    qryFaDokumente.EnableBoundFields(false);
                    docDokument.EditMode = EditModeType.ReadOnly;
                }

                // Weitere Einschränkungen für Vermögensabrechnungen
                if (!DBUtil.IsEmpty(qryFaDokumente["DocumentID"]))
                {
                    SqlQuery qry = DBUtil.OpenSQL(
                        @"SELECT VmBerichtID, DatumGenehmigung1 FROM VmBericht WHERE VermoegensabrechnungDocumentID = {0}",
                           new[] { qryFaDokumente["DocumentID"] });
                    if (qry.Count > 0 && (!DBUtil.IsEmpty(qry["DatumGenehmigung1"]) ||
                        !DBUtil.UserHasRight("CtlVISMassnahme_Vermoegensabrechnung")))
                    {
                        // Vermögensabrechnungen dürfen nur verändert werden, falls der Benutzer das Spezialrecht besitzt und
                        // falls die Genehmigung noch nicht vorliegt.
                        qryFaDokumente.EnableBoundFields(false);
                        docDokument.EditMode = EditModeType.ReadOnly;
                    }
                }
            }

            qryFaDokumente.ApplyUserRights();
            if (!(allowChangeStatus || hasRightStatusReset || hasRightVisieren) ||
                 (_istVertraulich && !DBUtil.IsEmpty(qryFaDokumente["ErstelltUserID"]) && !Session.User.UserID.Equals(qryFaDokumente["ErstelltUserID"])))
            {
                qryFaDokumente.EnableBoundFields(false);
                docDokument.EditMode = EditModeType.ReadOnly;
            }
        }

        private void qryXTask_AfterFill(object sender, EventArgs e)
        {
            if (qryXTask.Count == 0)
            {
                int faDokVisumStatusCode = Utils.ConvertToInt(qryFaDokumente["FaDokVisumStatusCode"]);
                bool allowChangeStatus = DBUtil.IsEmpty(qryFaDokumente["AllowChangeStatus"]) || (bool)qryFaDokumente["AllowChangeStatus"];

                btnAnfrage.Enabled = (DBUtil.UserHasRight("CtlFaDokumente_Visieren") || allowChangeStatus) && faDokVisumStatusCode != 4;
                btnWiederrufen.Visible = false;
                btnAntworten.Enabled = false;
                return;
            }

            btnWiederrufen.Visible = true;
            qryXTask.Find(string.Format("ReceiverID = {0} AND TaskStatusCode IN (1, 2)", Session.User.UserID));
        }

        private void qryXTask_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                btnWiederrufen.Enabled = false;
                btnAntworten.Enabled = false;

                if ((int)qryXTask["TaskSenderCode"] == 1 && (int)qryXTask["SenderID"] == Session.User.UserID)
                {
                    btnWiederrufen.Enabled = (int)qryFaDokumente["FaDokVisumStatusCode"] == 1 && (int)qryXTask["TaskStatusCode"] == 1;
                }

                if (DBUtil.UserHasRight("CtlFaDokumente_Visieren"))
                {
                    btnAntworten.Enabled = (int)qryFaDokumente["FaDokVisumStatusCode"] == 1;
                }

                if (!DBUtil.IsEmpty(qryXTask["TaskStatusCode"]))
                {
                    // pendent oder in Bearbeitung
                    if ((int)qryXTask["TaskStatusCode"] == 3)
                    {
                        rgpAnfrage.EditValue = 1;
                        rgpAnfrage.SelectedIndex = 1;
                    }
                    // abgelehnt oder erteilt
                    else
                    {
                        rgpAnfrage.EditValue = 0;
                        rgpAnfrage.SelectedIndex = 0;
                    }
                }
            }
            catch
            {
                btnAntworten.Enabled = false;
            }

            int faDokVisumStatusCode = Utils.ConvertToInt(qryFaDokumente["FaDokVisumStatusCode"]);
            bool allowChangeStatus = DBUtil.IsEmpty(qryFaDokumente["AllowChangeStatus"]) || (bool)qryFaDokumente["AllowChangeStatus"];

            btnAnfrage.Enabled = (DBUtil.UserHasRight("CtlFaDokumente_Visieren") || allowChangeStatus) && faDokVisumStatusCode != 4;
        }

        private void rgpAnfrage_EditValueChanged(object sender, EventArgs e)
        {
            if ((int)rgpAnfrage.EditValue == 0)
            {
                memBemerkungAnfrage.Visible = true;
                memBemerkungAntwort.Visible = false;
            }
            else
            {
                memBemerkungAnfrage.Visible = false;
                memBemerkungAntwort.Visible = true;
            }
        }

        private void SetAdressatAbsender(KissButtonEdit edt, string columnNameID, string columnNameName, UserModifiedFldEventArgs e)
        {
            if (edt.EditMode == EditModeType.ReadOnly)
            {
                return;
            }

            string searchString = edt.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                // Wenn der Suchstring leer ist:
                if (e.ButtonClicked)
                {
                    // und auf den Button geklickt wurde, dann soll nach allen gesucht werden:
                    searchString = "%";
                }
                else
                {
                    // sonst soll der Eintrag gelöscht werden:
                    qryFaDokumente[columnNameID] = DBNull.Value;
                    qryFaDokumente[columnNameName] = DBNull.Value;
                    return;
                }
            }

            string sql;

            if (searchString == ".")
            {
                // Wenn nur ein Punkt eingegeben wurde,
                // dann soll nur in den FallPersonen und involvierten Institutionen gesucht werden:
                sql = @"
                    SELECT
                      ID$     = PRS.BaPersonID,
                      Typ     = 'Person',
                      Name    = PRS.VornameName,
                      Strasse = PRS.WohnsitzStrasseHausNr,
                      Ort     = PRS.WohnsitzPLZOrt
                    FROM dbo.FaFallPerson     FPR
                      INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = FPR.BaPersonID
                    WHERE FPR.FaFallID = {1}

                    UNION
                    SELECT
                      ID$     = INS.BaInstitutionID,
                      Typ     = 'Institution',
                      Name    = INS.Name + ISNULL(' (' + INS.AdressZusatz + ')',''),
                      Strasse = INS.StrasseHausNr,
                      Ort     = INS.PLZOrt
                    FROM dbo.FaInvolvierteInstitution INV
                      INNER JOIN dbo.vwInstitution INS ON INS.BaInstitutionID = INV.BaInstitutionID
                    WHERE INV.FaFallID = {1}

                    UNION
                    SELECT
                      ID$     = -USR.UserID,
                      Typ     = 'Mitarbeiter',
                      Name    = USR.DisplayText,
                      Strasse = NULL,
                      Ort     = NULL
                    FROM dbo.vwUserSimple  USR
                    WHERE EXISTS (SELECT FaLeistungID
                                  FROM dbo.FaLeistung
                                  WHERE FaLeistungID = {2} AND (UserID = USR.UserID OR SachbearbeiterID = USR.UserID))
                       OR EXISTS (SELECT FaLeistungserbringerID
                                  FROM dbo.FaTeilLeistungserbringer
                                  WHERE FaLeistungID = {2} AND UserID = USR.UserID)

                    ORDER BY Name";
            }
            else
            {
                sql = @"
                    SELECT
                      ID$     = PRS.BaPersonID,
                      Typ     = 'Person',
                      Name    = PRS.VornameName,
                      Strasse = PRS.WohnsitzStrasseHausNr,
                      Ort     = PRS.WohnsitzPLZOrt
                    FROM dbo.vwPerson PRS
                    WHERE PRS.NameVorname LIKE '%' + {0} + '%'

                    UNION
                    SELECT
                      ID$     = INS.BaInstitutionID,
                      Typ     = 'Institution',
                      Name    = INS.Name + IsNull(' (' + INS.AdressZusatz + ')',''),
                      Strasse = INS.StrasseHausNr,
                      Ort     = INS.PLZOrt
                    FROM dbo.vwInstitution INS
                    WHERE INS.Name LIKE '%' + {0} + '%' OR INS.AdressZusatz LIKE '%' + {0} + '%'

                    UNION
                    SELECT
                      ID$     = -USR.UserID,
                      Typ     = 'Mitarbeiter',
                      Name    = USR.DisplayText,
                      Strasse = NULL,
                      Ort     = NULL
                    FROM dbo.vwUserSimple USR
                    WHERE USR.DisplayText LIKE '%' + {0} + '%'

                    ORDER BY Name";
            }

            // Dialog öffnen:
            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(sql, searchString, e.ButtonClicked, _faFallID, _faLeistungID);
            if (!e.Cancel)
            {
                qryFaDokumente[columnNameID] = dlg["ID$"];
                qryFaDokumente[columnNameName] = dlg["Name"];
            }
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            //Hinweis-Label nur anzeigen, wenn Suchresultat angezeigt wird
            lblHinweisDefaultSuche.Visible = tabControlSearch.SelectedTab == tpgListe;
        }

        private void tabControlSearch_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            if (tabControlSearch.SelectedTab == tpgSuchen)
            {
                SetSqlForQryFaDokumente();
            }
        }

        private void tabDocument_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (tabDocument.SelectedTab == tpgVisum) // Nach dem Wechsel auf die 2. Seite:
            {
                qryXTask.Fill(qryFaDokumente["FaDokumenteID"]);
            }
        }

        private void tabDocument_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            if (tabDocument.SelectedTabIndex == 0)
            {
                // Wenn zur 2. Seite gewechselt wird,
                // soll kontrolliert werden, ob alles gespeichert ist:
                e.Cancel = !qryFaDokumente.Post();

                /*    if (!e.Cancel) if (Utils.ConvertToInt(qryFaDokumente["StatusCode"]) != 2)
                     {
                        KissMsg.ShowInfo("Damit Sie ein neues Visum anfragen können, müssen Sie den Status 'zum Visum' setzen.");
                        e.Cancel = true;
                     }
                */
                if (!e.Cancel && DBUtil.IsEmpty(qryFaDokumente["DocumentID"]))
                {
                    KissMsg.ShowInfo("Damit Sie ein neues Visum anfragen können, muss ein Dokument vorhanden sein.");
                    e.Cancel = true;
                }
            }
            else
                if (tabDocument.SelectedTabIndex == 1)
                    // Wenn zur 2. Seite gewechselt wird
                    // soll kontrolliert werden, ob bei Visum alles gespeichert ist:
                    e.Cancel = !qryXTask.Post();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "ABSENDER": return Utils.ConvertToInt(qryFaDokumente["Absender"]);
                case "ADRESSAT": return Utils.ConvertToInt(qryFaDokumente["Adressat"]);
                case "USERID": return Session.User.UserID;
                case "BETRPERSONID": return qryFaDokumente["BaPersonID"];
                case "LEISTUNGID": return qryFaDokumente["FaLeistungID"];
                case "PROZESSCODE": return DBUtil.ExecuteScalarSQL(@"
                                    select FaProzessCode
                                    from   dbo.FaLeistung
                                    where  FaLeistungID = {0}",
                                             qryFaDokumente["FaLeistungID"]);
                case "FT": return DBUtil.ExecuteScalarSQL(@"
                                    select FAL.BaPersonID
                                    from   dbo.FaFall FAL
                                           inner join dbo.FaLeistung LEI on LEI.FaFallID = FAL.FaFallID
                                    where LEI.FaLeistungID = {0}",
                                 qryFaDokumente["FaLeistungID"]);
                case "FALLUSERID": return DBUtil.ExecuteScalarSQL(@"
                                    select FAL.UserID
                                    from   dbo.FaFall FAL
                                           inner join dbo.FaLeistung LEI on LEI.FaFallID = FAL.FaFallID
                                    where LEI.FaLeistungID = {0}",
                                            qryFaDokumente["FaLeistungID"]);
                case "LEISTUNGUSERID": return DBUtil.ExecuteScalarSQL(@"
                                    select UserID
                                    from   dbo.FaLeistung
                                    where  FaLeistungID = {0}",
                                             qryFaDokumente["FaLeistungID"]);
                case "FAFALLID": return _faFallID;
                case "POSTCODE": return Utils.ConvertToInt(qryFaDokumente["FaDokVerwendungCode"]);
            }
            return base.GetContextValue(fieldName);
        }

        public void Init(string name, Image titleImage, int faLeistungId, int faFallId, bool vertraulich, bool alim)
        {
            picTitel.Image = titleImage;
            lblTitel.Text = name;

            _faFallID = faFallId;
            _faLeistungID = faLeistungId;
            _istVertraulich = vertraulich;
            _istAlim = alim;

            //Personen des Klientensystems
            SqlQuery qry = DBUtil.OpenSQL(@"
                select Code = P.BaPersonID,
                  Text = IsNull(P.Vorname+ ' ','') + P.Name
                from dbo.FaFallPerson F
                left join dbo.BaPerson P on P.BaPersonID = F.BaPersonID
                where F.FaFallID = {0}
                union all
                select null,''
                order by 2",
                 _faFallID);
            edtBaPersonID.LoadQuery(qry);
            edtSucheBaPersonID.LoadQuery(qry);
            colBetrifftPerson.ColumnEdit = grdFaDokumente.GetLOVLookUpEdit(qry);

            if (_istAlim)
            {
                edtSucheFaDokThemaCode.LOVFilter = "FA";
                edtSucheKlibuRelevant.Visible = false;
                edtSucheNichtKlibuRelevant.Visible = false;

                chkNichtKlibuRelevant.Visible = false;
                edtFaDokThemaCode.LOVFilter = "FA";
                docDokument.Context = "FaDokumenteAlim";
            }

            if (_istVertraulich && 0 == (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.FaLeistung  LEI
                WHERE LEI.FaFallID = {0} AND LEI.UserID = {1}",
                 _faFallID, Session.User.UserID))
            {
                qryFaDokumente.CanInsert = false;
                qryFaDokumente.CanDelete = false;
            }

            kissSearch.SelectParameters = new object[] { faLeistungId, vertraulich, Session.User.UserID, _nurFinanzrelevante, _faFallID, _istAlim };
        }

        public override void OnSearch()
        {
            SetSqlForQryFaDokumente();
            base.OnSearch();
        }

        /// <summary>
        /// Handle messages from FormController
        /// </summary>
        /// <param name="param">Containing all necessary parameters as key/value pairs</param>
        /// <returns>True, if successfully handles message or nothing done, false if something went wrong</returns>
        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "JumpToPath":
                    bool ret = base.ReceiveMessage(param);
                    if (ret && param["XTaskID"] != null)
                    {
                        tabDocument.SelectTab(tpgVisum);
                        return qryXTask.Find(string.Format("XTaskID = {0}", param["XTaskID"]));
                    }
                    return ret;
            }

            // did not understand message
            return base.ReceiveMessage(param);
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            edtSucheDatumVon.EditValue = DateTime.Today.AddMonths(-12);
            edtSucheKlibuRelevant.EditValue = true;
            edtSucheNichtKlibuRelevant.EditValue = true;
            edtInklIKAAuszuege.EditValue = false;
        }

        protected override void RunSearch()
        {
            //Sicherstellen, dass mindestens eine der Checkboxes 'Klibu relevant', 'Nicht Klibu relevant' oder 'IK-Auszüge' selektiert ist,
            //sonst gibt es kein Resultat
            EnsureOneCheckboxIsChecked();

            base.RunSearch();
            qryFaDokumente.Last();
        }

        #endregion

        #region Private Methods

        private void ChangeDokumentStatus(List<DataRow> rows, int newStatus, bool nothingSelected)
        {
            List<int> selektierteIDsList = new List<int>();
            int updateBlockSize = 100;

            foreach (DataRow row in rows)
            {
                int id = (int)row["FaDokumenteID"];
                selektierteIDsList.Add(id);
            }

            if (selektierteIDsList.Count > 0)
            {
                // Ändere den Status aller selektierten Dokumente. Damit dies auch mit grossen Mengen von IDs klappt, machen wir das in Chunks (nicht alle miteinander, sondern in Blöcken)
                string selektierteIDs = "";

                for (int i = 0; i < selektierteIDsList.Count; i++)
                {
                    string idString = selektierteIDsList[i].ToString();
                    selektierteIDs = string.IsNullOrEmpty(selektierteIDs) ? idString : selektierteIDs + ", " + idString;

                    if ((i > 0 && (i % updateBlockSize) == 0) || i == selektierteIDsList.Count - 1)
                    {
                        // So, entweder ist wieder ein Chunk parat, oder wird sind am Ende der Liste

                        // Ändere den Status der Dokumente in der Liste
                        DBUtil.ExecSQLThrowingException(@"
                                 UPDATE dbo.FaDokumente
                                    SET FaDokStatusCode = {1},
                                      StatusLetztUserID = {0},
                                      StatusLetztDatum  = GetDate()
                                 WHERE FaDokumenteID IN (" + selektierteIDs + ")",
                              Session.User.UserID, newStatus);

                        selektierteIDs = "";
                    }
                }
            }
            Session.Commit();

            qryFaDokumente.Refresh();

            // Nun werden die selektierten Rows wieder selektiert (falls nötig)
            if (!nothingSelected)
            {
                // Es war etwas selektiert vorher, also selektiere diese Zeilen wieder
                foreach (DataRow row in qryFaDokumente.DataTable.Rows)
                {
                    if (selektierteIDsList.Contains((int)row["FaDokumenteID"]))
                    {
                        // Diese Row war selektiert, selektiere sie wieder
                        row["Selected"] = true;
                    }
                }
            }
        }

        private void EnsureOneCheckboxIsChecked()
        {
            if (!edtSucheKlibuRelevant.Checked && !edtSucheNichtKlibuRelevant.Checked && !edtInklIKAAuszuege.Checked)
            {
                string message = string.Format("Weder '{0}', '{1}' noch '{2}' wurde ausgewählt.\r\nBitte aktivieren Sie mindestens ein Häkchen.", edtSucheKlibuRelevant.Text, edtSucheNichtKlibuRelevant.Text, edtInklIKAAuszuege.Text);

                KissMsg.ShowInfo(message);
                throw new KissCancelException(message);
            }
        }

        private List<DataRow> GetAllSelectedRows(out bool nothingSelected)
        {
            List<DataRow> rows = new List<DataRow>();
            nothingSelected = false;

            foreach (DataRow row in qryFaDokumente.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Selected"]))
                {
                    if ((bool)row["Selected"])
                    {
                        // Zeile ist selektiert
                        rows.Add(row);
                    }
                }
            }

            if (rows.Count == 0)
            {
                // Es ist keine Zeile selektiert, d.h. nimm die aktuelle hervorgehobene Row
                if (qryFaDokumente.Row != null)
                {
                    rows.Add(qryFaDokumente.Row);
                }

                nothingSelected = true;    // Gibt true zurück, wenn keine Row selektiert war mit einem Häckchen
            }

            return rows;
        }

        private void SetSqlForQryFaDokumente()
        {
            var includeIkAuszuege = (bool?)edtInklIKAAuszuege.EditValue;

            if (includeIkAuszuege.HasValue && includeIkAuszuege.Value)
            {
                string sql = string.Format(QUERY_TEMPLATE_BOTH, QUERY_FADOKUMENTE, QUERY_IKAUSZUG);
                qryFaDokumente.SelectStatement = sql;
            }
            else
            {
                string sql = string.Format(QUERY_TEMPLATE_SINGLE, QUERY_FADOKUMENTE);
                qryFaDokumente.SelectStatement = sql;
            }

            kissSearch.SelectStatement = qryFaDokumente.SelectStatement;
        }

        #endregion

        #endregion
    }
}