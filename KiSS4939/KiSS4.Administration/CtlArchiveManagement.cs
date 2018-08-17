using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using SharpLibrary.WinControls;

namespace KiSS4.Administration
{
    /// <summary>
    /// Summary description for CtlArchiveManagement.
    /// </summary>
    public partial class CtlArchiveManagement : KissUserControl
    {
        private const string CLASSNAME = "CtlArchiveManagement";

        #region Fields

        #region Private Fields

        private bool _mayAdd;

        #endregion

        #endregion

        #region Constructors

        public CtlArchiveManagement()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            bool isNEWODActive = DBUtil.GetConfigBool(@"System\Schnittstelle\NEWOD\NEWODAktiv", false);
            colNEWOD.Visible = isNEWODActive;
            colNEWOD.OptionsColumn.ShowInCustomizationForm = isNEWODActive; //so dass es im Spaltenwähler auch sichtbar/unsichtbar ist
        }

        #endregion

        #region EventHandlers

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (qryArchive.Count == 0 || qryKandidaten.Count == 0)
            {
                return;
            }

            if (!qryArchive.Post())
            {
                return;
            }

            int[] rowHandles = gridVerfuegbar.View.GetSelectedRows();

            if (rowHandles == null)
            {
                return;
            }

            foreach (int rowHandle in rowHandles)
            {
                qryZugeteilt.Insert();
                qryZugeteilt["ArchiveID"] = qryArchive["ArchiveID"];
                qryZugeteilt["UserID"] = gridVerfuegbar.View.GetRowCellValue(rowHandle, gridVerfuegbar.View.Columns["UserID"]);
                qryZugeteilt.Post();
            }

            DisplayUsers(true, true);
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            if (qryArchive.Count == 0)
            {
                return;
            }

            if (!qryArchive.Post())
            {
                return;
            }

            // add only not yet assigned XUsers
            DBUtil.ExecSQL(@"
                INSERT INTO dbo.XUser_Archive (ArchiveID, UserID)
                    SELECT ArchiveID = {0},
                           UserID    = USR.UserID
                    FROM dbo.XUser USR WITH (READUNCOMMITTED)
                      LEFT JOIN dbo.XUser_Archive UAR WITH (READUNCOMMITTED) ON UAR.UserID = USR.UserID
                                                                            AND UAR.ArchiveID = {0}
                    WHERE USR.IsLocked = 0      -- only active users
                      AND UAR.UserID IS NULL;", qryArchive["ArchiveID"]);

            DisplayUsers(true, true);
        }

        private void btnArchivieren_Click(object sender, EventArgs e)
        {
            //Mantis#6575: Wir müssen sicherstellen, dass die Leistung wirklich abgeschlossen ist. (DatumBis wirklich gesetzt ist).
            //Andernfalls kann die Leistung nicht mehr zurückgeholt werden.
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT TOP 1 1
                FROM dbo.FaLeistung  WITH (READUNCOMMITTED)
                WHERE FaLeistungTS = {0};", qryFaLeistung[DBO.FaLeistung.FaLeistungTS]);

            if (qry.IsEmpty)
            {
                KissMsg.ShowInfo(string.Format(qry.TimestampMessage, string.Empty));
                return;
            }

            if (DBUtil.IsEmpty(editArchivStandort.EditValue))
            {
                KissMsg.ShowInfo(CLASSNAME, "NeuerStandortLeer", "Das Feld 'neuer Standort' darf nicht leer bleiben!");
                return;
            }

            if (!KissMsg.ShowQuestion(CLASSNAME, "FallArchivieren", "Soll dieser Fall archiviert werden ?"))
            {
                return;
            }

            Session.BeginTransaction();
            try
            {
                var faLeistungId = Convert.ToInt32(qryFaLeistung["FaLeistungID"]);
                InsertFaLeistungArchiv(faLeistungId);
                InsertFaLeistungArchiv(FindRelatedFaRelationId(faLeistungId));

                Session.Commit();
            }
            catch (Exception)
            {
                Session.Rollback();
                throw;
            }

            qryFaLeistung["A"] = true;
            qryFaLeistung["Standort"] = editArchivStandort.Text;
            qryFaLeistung["ArchivNr"] = editArchivNr.Text;
            qryFaLeistung["MayRemove"] = true;
            qryFaLeistung.Row.AcceptChanges();

            DisplayHistory();
            qryFaLeistung.Refresh();
        }

        private void btnArchivWechsel_Click(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(editArchivStandort.EditValue))
            {
                KissMsg.ShowInfo(CLASSNAME, "NeuerStandortLeer", "Das Feld 'neuer Standort' darf nicht leer bleiben!");
                return;
            }

            if (editArchivStandort.EditValue.Equals(qryFaLeistung["ArchiveID"]))
            {
                KissMsg.ShowInfo(CLASSNAME, "StandortNeuBishIdentisch", "Im Feld 'neuer Standort' ist der bisherige Standort erfasst!");
                return;
            }

            if (!KissMsg.ShowQuestion(CLASSNAME, "InAnderesArchivVerschieben", "Soll dieser Fall in ein anderes Archiv verschoben werden ?"))
            {
                return;
            }

            SqlQuery qry = DBUtil.OpenSQL(@"
                select FaLeistungArchivID, ArchivNr
                from dbo.FaLeistungArchiv  WITH (READUNCOMMITTED)
                where FaLeistungID = {0} and
                        CheckOut is null",
                qryFaLeistung["FaLeistungID"]);

            if (qry.Count == 0)
                return;

            DBUtil.ExecSQL(@"
                update FaLeistungArchiv
                set    CheckOut = getdate(), CheckOutUserID = {0}
                where  FaLeistungArchivID = {1}",
                Session.User.UserID,
                qry["FaLeistungArchivID"]);

            int relatedFaleistungID = FindRelatedFaRelationId((int)qryFaLeistung["FaLeistungID"]);
            if (relatedFaleistungID != 0)
            {
                DBUtil.ExecSQL(
                    @"
                update FaLeistungArchiv
                set    CheckOut = getdate(), CheckOutUserID = {0}
                where  FaLeistungArchivID = (SELECT MAX(FaLeistungArchivID) FROM FaLeistungArchiv
                                                                           WHERE FaLeistungID = {1}
                                                                             AND CheckOut IS NULL
                                                                             AND CheckOutUserID IS NULL)",
                    Session.User.UserID,
                    relatedFaleistungID);
            }

            DBUtil.ExecSQL(
                "insert FaLeistungArchiv (ArchiveID, ArchivNr, FaLeistungID, CheckIn, CheckInUserID) " +
                "values ({0},{1},{2},getdate(),{3})",
                editArchivStandort.EditValue,
                editArchivNr.EditValue,
                qryFaLeistung["FaLeistungID"],
                Session.User.UserID);

            if (relatedFaleistungID != 0)
            {
                DBUtil.ExecSQL(
                    "insert FaLeistungArchiv (ArchiveID, ArchivNr, FaLeistungID, CheckIn, CheckInUserID) " +
                    "values ({0},{1},{2},getdate(),{3})",
                    editArchivStandort.EditValue,
                    editArchivNr.EditValue,
                    relatedFaleistungID,
                    Session.User.UserID);
            }

            qryFaLeistung["A"] = true;
            qryFaLeistung["Standort"] = editArchivStandort.Text;
            qryFaLeistung["ArchivNr"] = editArchivNr.Text;

            qryFaLeistung.RowModified = false;
            qryFaLeistung.Row.AcceptChanges();

            DisplayHistory();
            qryFaLeistung.Refresh();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (qryZugeteilt.Count == 0)
            {
                return;
            }

            qryZugeteilt.Delete();
            DisplayUsers(true, false);
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (qryArchive.Count == 0)
            {
                return;
            }

            if (!qryArchive.Post())
            {
                return;
            }

            DBUtil.ExecSQL(@"
                DELETE
                FROM dbo.XUser_Archive
                WHERE ArchiveID = {0};", qryArchive["ArchiveID"]);

            DisplayUsers(true, true);
        }

        private void btnZurueckholen_Click(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(editSAR.LookupID))
            {
                KissMsg.ShowInfo(CLASSNAME, "NeuerSARLeer", "Das Feld 'Neuer SAR' darf nicht leer bleiben");
                return;
            }

            if (!KissMsg.ShowQuestion(CLASSNAME, "AusArchivHolen", "Soll dieser Fall aus dem Archiv zurückgeholt werden ?"))
            {
                return;
            }

            Session.BeginTransaction();
            var faLeistungId = Convert.ToInt32(qryFaLeistung["FaLeistungID"]);
            UpdateFaLeistungFaLeistungArchivForCheckout(faLeistungId);
            UpdateFaLeistungFaLeistungArchivForCheckout(FindRelatedFaRelationId(faLeistungId));
            Session.Commit();

            qryFaLeistung["A"] = false;
            qryFaLeistung["Standort"] = DBNull.Value;
            qryFaLeistung["SAR"] = editSAR.EditValue;
            qryFaLeistung.RowModified = false;
            qryFaLeistung.Row.AcceptChanges();

            DisplayHistory();
            qryFaLeistung.Refresh();
        }

        private void CtlArchiveManagement_Load(object sender, EventArgs e)
        {
            tabArchiv.SelectedTabChanged += tabArchiv_SelectedTabChanged;

            qryArchive.Fill("select * from XArchive order by SortKey");
            qryZugeteilt.DeleteQuestion = null;

            tabArchiv.SelectedTabIndex = 0;
            ActiveSQLQuery = qryFaLeistung;

            grdFaLeistung.MainView.BorderStyle = BorderStyles.NoBorder;

            //			tabControl1.SelectedTabIndex = 1;

            editModulX.Properties.DataSource = DBUtil.OpenSQL(@"
                ;WITH ModulCte AS
                    (
                      SELECT Code     = MOD.ModulID,
                             Text     = MOD.Name,
                             SortKey1 = ISNULL(MOD.SortKey, 0),
                             SortKey2 = NULL
                      FROM dbo.XModul MOD  WITH (READUNCOMMITTED)
                      WHERE MOD.ModulTree = 1
                    )

                    SELECT Code,
                           Text,
                           SortKey1,
                           SortKey2
                    FROM ModulCte

                    UNION ALL
                    SELECT Code = -PRC.Code,
                           Text = COALESCE(PRC.ShortText, PRC.Text),
                           SortKey1 = CTE.SortKey1,
                           SortKey2 = PRC.SortKey
                    FROM ModulCte              CTE
                      INNER JOIN dbo.XLOVCode  PRC WITH (READUNCOMMITTED) ON PRC.LOVName = 'FaProzess'
                                                                         AND PRC.Code / 100 = CTE.Code
                                                                         AND PRC.Code % 100 <> 0
                                                                         AND PRC.IsActive = 1
                    WHERE EXISTS(SELECT TOP 1 1
                                 FROM dbo.XLOVCode LOC WITH (READUNCOMMITTED)
                                 WHERE LOC.LOVName = PRC.LOVName
                                   AND LOC.Code <> PRC.Code
                                   AND LOC.IsActive = 1)

                    UNION ALL
                    SELECT NULL, '', -1, -1
                    ORDER BY SortKey1, SortKey2;
                    ");

            editStatusX.Properties.DataSource = DBUtil.OpenSQL(@"
                select Code = convert(int,null),Text = convert(varchar,null)
                union all
                select 1, dbo.fnGetMLTextFromName({0}, 'geschlossen', {1})
                union all
                select 2, dbo.fnGetMLTextFromName({0}, 'archiviert', {1})
                order by Code",
                CLASSNAME,
                Session.User.LanguageCode);

            SqlQuery qry = DBUtil.OpenSQL(@"
                select  distinct Code = ARC.ArchiveID, Text = ARC.Name
                from	dbo.XArchive ARC  WITH (READUNCOMMITTED)
                        inner join XUser_Archive UAR on UAR.UserID = {0} and
                                                        UAR.ArchiveID = ARC.ArchiveID
                union
                select null,null
                order by Text",
                Session.User.UserID);

            _mayAdd = qry.Count > 1;
            editArchivStandort.Properties.DataSource = qry;

            editStandortX.Properties.DataSource = DBUtil.OpenSQL(@"
                select  Code = ArchiveID, Text = Name
                from	dbo.XArchive  WITH (READUNCOMMITTED)
                order by SortKey");

            //Archivstandorte verwalten nur für Admins
            qryArchive.CanDelete = Session.User.IsUserAdmin;
            qryArchive.CanInsert = Session.User.IsUserAdmin;
            qryArchive.CanUpdate = Session.User.IsUserAdmin;
            btnAdd.Enabled = Session.User.IsUserAdmin;
            btnAddAll.Enabled = Session.User.IsUserAdmin;
            btnRemove.Enabled = Session.User.IsUserAdmin;
            btnRemoveAll.Enabled = Session.User.IsUserAdmin;
        }

        private void CtlArchiveManagement_Search(object sender, EventArgs e)
        {
            if (tabArchiv.SelectedTabIndex != 0)
                return;

            if (tabControl1.SelectedTabIndex == 0)
            {
                if (qryFaLeistung.Post())
                {
                    tabControl1.SelectedTabIndex = 1;
                    NeueSuche();
                    editPersonX.Focus();
                }
            }
            else
            {
                Suchen();
            }
        }

        private void editSAR_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(editSAR.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                editSAR.EditValue = dlg["Name"];
                editSAR.LookupID = dlg["UserID"];
            }
        }

        private void editSARX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(editSARX.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                editSARX.EditValue = dlg["Name"];
                editSARX.LookupID = dlg["UserID"];
            }
        }

        private void edtFilterKandidaten_EditValueChanged(object sender, EventArgs e)
        {
            var searchString = "";

            if (!DBUtil.IsEmpty(edtFilterKandidaten.EditValue))
            {
                searchString = edtFilterKandidaten.EditValue.ToString();
            }

            qryKandidaten.DataTable.DefaultView.RowFilter = "UserName LIKE '%" + (searchString).Replace("'", "''") + "%'";
        }

        private void qryArchive_AfterInsert(object sender, EventArgs e)
        {
            edtName.Focus();
        }

        private void qryArchive_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtName, lblName.Text);
            DBUtil.CheckNotNullField(edtSortKey, lblSortKey.Text);
        }

        private void qryArchive_PositionChanged(object sender, EventArgs e)
        {
            DisplayUsers(true, true);
        }

        private void qryFaLeistung_PositionChanged(object sender, EventArgs e)
        {
            DisplayHistory();
        }

        private void tabArchiv_SelectedTabChanged(TabPageEx page)
        {
            ActiveSQLQuery = tabArchiv.SelectedTabIndex == 0 ? qryFaLeistung : qryArchive;
        }

        private void tabControl1_SelectedTabChanged(TabPageEx page)
        {
            ctlGotoFall.Visible = tabControl1.SelectedTabIndex == 0;
        }

        #endregion

        #region Methods

        #region Private Static Methods

        /// <summary>
        /// Findet den dazugehörigen FaRelation-Eintrag in der gleichnamigen Tabelle.
        /// </summary>
        /// <param name="faLeistungID">Die FaLeistungId zu welcher man den Eintrag holen will</param>
        /// <returns>FaLeistungId, wenn kein Eintrag gefunden wird, wird 0 zurückgegeben</returns>
        private static int FindRelatedFaRelationId(int faLeistungID)
        {
            var cascadeUpdateFaLeistung = Convert.ToBoolean(DBUtil.ExecuteScalarSQL(
                                                @"SELECT CascadeUpdate
                                                    FROM dbo.FaRelation WITH(READUNCOMMITTED)
                                                    WHERE FaLeistungID1 = {0}
                                                        OR FaLeistungID2 = {0}",
                                                faLeistungID));
            if (cascadeUpdateFaLeistung)
            {
                // andere FaLeistung holen
                var faLeistungId2 = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT FaLeistungID = CASE
                                                                                                      WHEN FaLeistungID1 = {0} THEN FaLeistungID2
                                                                                                      ELSE FaLeistungID1
                                                                                                    END
                                                                              FROM dbo.FaRelation WITH (READUNCOMMITTED)
                                                                              WHERE FaLeistungID1 = {0}
                                                                              OR FaLeistungID2 = {0};",
                                                                              faLeistungID));
                if (faLeistungId2 != 0)
                {
                    return faLeistungId2;
                }
            }

            return 0;
        }

        #endregion

        #region Private Methods

        private void DisplayHistory()
        {
            qryHistory.Fill(@"
                SELECT FAA.*,
                       --
                       Standort         = ARC.Name,
                       CheckInUserName  = dbo.fnGetLastFirstName(NULL, USR1.Lastname, USR1.Firstname) + ' (' + USR1.LogonName + ')',
                       CheckOutUserName = dbo.fnGetLastFirstName(NULL, USR2.Lastname, USR2.Firstname) + ' (' + USR2.LogonName + ')'
                FROM dbo.FaLeistungArchiv FAA  WITH (READUNCOMMITTED)
                  INNER JOIN dbo.XUser    USR1 WITH (READUNCOMMITTED) ON USR1.UserID = FAA.CheckInUserID
                  LEFT  JOIN dbo.XUser    USR2 WITH (READUNCOMMITTED) ON USR2.UserID = FAA.CheckOutUserID
                  LEFT  JOIN dbo.XArchive ARC  WITH (READUNCOMMITTED) ON ARC.ArchiveID = FAA.ArchiveID
                WHERE FAA.FaLeistungID = {0}
                ORDER BY CheckIn;", qryFaLeistung["FaLeistungID"]);

            // reset Add/Remove Fields
            btnArchivieren.Enabled = false;
            btnArchivWechsel.Enabled = false;
            btnZurueckholen.Enabled = false;
            editArchivNr.EditMode = EditModeType.ReadOnly;
            editArchivStandort.EditMode = EditModeType.ReadOnly;
            editSAR.EditMode = EditModeType.ReadOnly;

            editArchivStandort.EditValue = null;
            editArchivNr.EditValue = null;
            editSAR.EditValue = null;
            editSAR.LookupID = null;

            // enable Archiv-Buttons
            if ((bool)qryFaLeistung["A"] && (bool)qryFaLeistung["MayRemove"])
            {
                btnArchivWechsel.Enabled = true;
                editArchivStandort.EditMode = EditModeType.Normal;

                editArchivNr.EditValue = qryFaLeistung["ArchivNr"];
                editArchivNr.EditMode = EditModeType.Normal;

                btnZurueckholen.Enabled = true;
                editSAR.EditMode = EditModeType.Normal;
            }

            if (!(bool)qryFaLeistung["A"] && !DBUtil.IsEmpty(qryFaLeistung["DatumBis"]) && _mayAdd)
            {
                btnArchivieren.Enabled = true;
                editArchivNr.EditMode = EditModeType.Normal;
                editArchivStandort.EditMode = EditModeType.Normal;
            }
        }

        private void DisplayUsers(bool refreshKandidaten, bool refreshZugeteilt)
        {
            if (refreshZugeteilt)
            {
                qryZugeteilt.Fill(@"
                    SELECT UAR.*,
                           --
                           UserName = dbo.fnGetLastFirstName(NULL, USR.Lastname, USR.Firstname) + ' (' + USR.LogonName + ')'
                    FROM dbo.XUser_Archive UAR WITH (READUNCOMMITTED)
                      INNER JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = UAR.UserID
                    WHERE UAR.ArchiveID = {0}
                    ORDER BY UserName;", qryArchive["ArchiveID"]);
            }

            if (refreshKandidaten)
            {
                qryKandidaten.Fill(@"
                    SELECT UserID   = USR.UserID,
                           UserName = dbo.fnGetLastFirstName(NULL, USR.Lastname, USR.Firstname) + ' (' + USR.LogonName + ')'
                    FROM dbo.XUser                USR WITH (READUNCOMMITTED)
                      LEFT JOIN dbo.XUser_Archive UAR WITH (READUNCOMMITTED) ON UAR.UserID = USR.UserID
                                                                            AND UAR.ArchiveID = {0}
                    WHERE UAR.ArchiveID IS NULL
                      AND USR.IsLocked = 0      -- show only active users
                    ORDER BY UserName;", qryArchive["ArchiveID"]);
            }
        }

        private void InsertFaLeistungArchiv(int faLeistungId)
        {
            if (faLeistungId != 0)
            {
                DBUtil.ExecSQL(
                    @"INSERT FaLeistungArchiv (ArchiveID, ArchivNr, FaLeistungID, CheckIn, CheckInUserID)
                      VALUES ({0}, {1}, {2}, GETDATE(),{3})",
                    editArchivStandort.EditValue,
                    editArchivNr.EditValue,
                    faLeistungId,
                    Session.User.UserID);

                // Nie gültig gewesene löschen
                DBUtil.ExecSQL(@"Delete FaLeistungZugriff WHERE DatumVon > dbo.fnDateSerial(YEAR(GETDATE()),MONTH(GETDATE()),DAY(GETDATE())) AND faLeistungID = {0}",
                                 faLeistungId);
                // Gültige abschliessen
                DBUtil.ExecSQL(@"UPDATE FaLeistungZugriff SET DatumBis = dbo.fnDateSerial(YEAR(GETDATE()),MONTH(GETDATE()),DAY(GETDATE()))
                                 WHERE FaLeistungID = {0} AND ISNULL(DatumBis, '99991231') > dbo.fnDateSerial(YEAR(GETDATE()),MONTH(GETDATE()),DAY(GETDATE()))", faLeistungId);
            }
        }

        private void NeueSuche()
        {
            foreach (BaseEdit ctl in panel1.Controls.OfType<BaseEdit>())
            {
                (ctl).EditValue = null;
            }

            editSARX.EditValue = null;

            editPersonX.Focus();
        }

        private void Suchen()
        {
            if (DBUtil.IsEmpty(editPersonX.EditValue) &&
                DBUtil.IsEmpty(editAHVNr.EditValue) &&
                DBUtil.IsEmpty(editVersNrX.EditValue) &&
                DBUtil.IsEmpty(editNNummerX.EditValue) &&
                DBUtil.IsEmpty(editModulX.EditValue) &&
                DBUtil.IsEmpty(editSARX.EditValue) &&
                DBUtil.IsEmpty(editArchivNrX.EditValue) &&
                DBUtil.IsEmpty(editStandortX.EditValue) &&
                DBUtil.IsEmpty(editStatusX.EditValue))
            {
                KissMsg.ShowInfo(CLASSNAME, "Min1Suchfeld", "Mindestens ein Suchfeld muss ausgefüllt sein");
                return;
            }

            string sql = string.Format(@"
                SELECT FAL.*,
                       Person             = PRS.Name + ISNULL(', ' + PRS.Vorname,''),
                       AHVNummer          = PRS.AHVNummer,
                       Versichertennummer = PRS.Versichertennummer,
                       NNummer            = PRS.NNummer,
                       Modul              = COALESCE(PRZ.ShortText, PRZ.Text, MOD.Name),
                       SAR                = USR.LastName + isNull(', ' + USR.FirstName,''),
                       SARKuerzel         = USR.LogonName,
                       A                  = CONVERT(BIT, CASE WHEN FAR.FaLeistungID IS NULL THEN 0 ELSE 1 END),
                       MayRemove          = CONVERT(BIT, CASE WHEN UAR.ArchiveID IS NULL THEN 0 ELSE 1 END),
                       ArchivNr           = FAR.ArchivNr,
                       ArchiveID          = ARC.ArchiveID,
                       Standort           = ARC.Name,
                       NEWOD              = CASE WHEN BAN.BaPersonID IS NOT NULL THEN CONVERT(BIT, 1) ELSE CONVERT(BIT, 0) END
                FROM dbo.FaLeistung               FAL WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BaPerson         PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID
                  INNER JOIN dbo.XUser            USR WITH (READUNCOMMITTED) ON USR.UserID = FAL.UserID
                  INNER JOIN dbo.XModul           MOD WITH (READUNCOMMITTED) ON MOD.ModulID = FAL.ModulID
                  LEFT  JOIN dbo.XLOVCode         PRZ WITH (READUNCOMMITTED) ON PRZ.LOVName = 'FaProzess' AND PRZ.Code = FAL.FaProzessCode AND PRZ.Code % 100 <> 0
                  LEFT  JOIN dbo.FaLeistungArchiv FAR WITH (READUNCOMMITTED) ON FAR.FaLeistungID = FAL.FaLeistungID
                                                                            AND FAR.CheckOut IS NULL
                  LEFT  JOIN dbo.XArchive      ARC WITH (READUNCOMMITTED) ON ARC.ArchiveID = FAR.ArchiveID
                  LEFT  JOIN dbo.XUser_Archive UAR WITH (READUNCOMMITTED) ON UAR.ArchiveID = FAR.ArchiveID
                                                                         AND UAR.UserID = {0}
                  LEFT  JOIN dbo.BaPerson_NewodPerson BAN ON BAN.BaPersonID = PRS.BaPersonID
                WHERE 1 = 1 ", Session.User.UserID);

            if (!DBUtil.IsEmpty(editPersonX.Text))
            {
                string suchbegriff = editPersonX.Text;
                suchbegriff = suchbegriff.Replace("*", "%");
                suchbegriff = suchbegriff.Replace(" ", "%");
                sql += " AND PRS.Name + ISNULL(', ' + Vorname,'') LIKE " + DBUtil.SqlLiteral(suchbegriff + "%");
            }

            if (!DBUtil.IsEmpty(editAHVNr.Text))
            {
                string suchbegriff = editAHVNr.Text.Replace("*", "%");
                sql += " AND PRS.AHVNummer LIKE " + DBUtil.SqlLiteral(suchbegriff + "%");
            }

            if (!DBUtil.IsEmpty(editVersNrX.Text))
            {
                string suchbegriff = editVersNrX.Text.Replace("*", "%");
                sql += " AND PRS.Versichertennummer LIKE " + DBUtil.SqlLiteral(suchbegriff + "%");
            }

            if (!DBUtil.IsEmpty(editNNummerX.Text))
            {
                string suchbegriff = editNNummerX.Text.Replace("*", "%");
                sql += " AND PRS.NNummer LIKE " + DBUtil.SqlLiteral(suchbegriff + "%");
            }

            if (!DBUtil.IsEmpty(editModulX.EditValue))
                if ((int)editModulX.EditValue >= 0)
                {
                    sql += " AND FAL.ModulID = " + DBUtil.SqlLiteral(editModulX.EditValue);
                }
                else
                {
                    sql += " AND FAL.FaProzessCode = " + DBUtil.SqlLiteral(-(int)editModulX.EditValue);
                }

            if (!DBUtil.IsEmpty(editSARX.LookupID))
            {
                sql += " AND USR.UserID = " + DBUtil.SqlLiteral(editSARX.LookupID);
            }

            if (!DBUtil.IsEmpty(editStandortX.EditValue))
            {
                sql += " AND FAR.ArchiveID = " + DBUtil.SqlLiteral(editStandortX.EditValue);
            }

            if (!DBUtil.IsEmpty(editArchivNrX.Text))
            {
                string suchbegriff = editArchivNrX.Text.Replace("*", "%").Replace(" ", "%");
                sql += " AND FAL.FaLeistungID IN (SELECT FaLeistungID FROM FaLeistungArchiv WHERE ArchivNr LIKE " + DBUtil.SqlLiteral(suchbegriff + "%") + ") ";
            }

            if (!DBUtil.IsEmpty(editStatusX.EditValue))
            {
                if ((int)editStatusX.EditValue == 1)
                {
                    sql += " AND FAL.DatumBis IS NOT NULL AND FAR.FaLeistungID IS NULL "; //geschlossen
                }
                else
                {
                    sql += " AND FAR.FaLeistungID IS NOT NULL "; //archiviert
                }
            }

            sql += "\r\n ORDER BY Person ";

            Cursor.Current = Cursors.WaitCursor;
            qryFaLeistung.Fill(sql);
            Cursor.Current = Cursors.Default;
            lblRowCount.Text = qryFaLeistung.Count.ToString();
            tabControl1.SelectedTabIndex = 0;
        }

        private void UpdateFaLeistungFaLeistungArchivForCheckout(int faLeistungID)
        {
            if (faLeistungID != 0)
            {
                DBUtil.ExecSQL(@"
                UPDATE FaLeistungArchiv
                  SET CheckOut = GETDATE(), CheckOutUserID = {0}
                WHERE FaLeistungArchivID =
                      (SELECT FaLeistungArchivID FROM dbo.FaLeistungArchiv  WITH (READUNCOMMITTED) WHERE FaLeistungID = {1} AND CheckOut IS NULL)",
                    Session.User.UserID,
                    faLeistungID);

                DBUtil.ExecSQL(@"
                UPDATE FaLeistung
                SET UserID = {0}, Modifier = {1}, Modified = GETDATE()
                WHERE FaLeistungID = {2}",
                    editSAR.LookupID,
                    DBUtil.GetDBRowCreatorModifier(),
                    faLeistungID);
            }
        }

        #endregion

        #endregion
    }
}