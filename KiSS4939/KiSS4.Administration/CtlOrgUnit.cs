using System;
using System.Data;
using DevExpress.XtraTreeList;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Dokument.Utilities;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    /// <summary>
    /// Control, used for managing orgunits
    /// </summary>
    public partial class CtlOrgUnit : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlOrgUnit";

        #endregion

        #region Private Fields

        private bool _firstLoop = true;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlOrgUnit"/> class.
        /// </summary>
        public CtlOrgUnit()
        {
            InitializeComponent();

            // load data
            qryOrgUnit.Fill(@"
                SELECT ORG.*,
                       OrgUnitTyp     = dbo.fnGetLOVMLText('OrganisationsEinheitTyp', ORG.OEItemTypCode, {0}),
                       Leitung        = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName),
                       Stellvertreter = dbo.fnGetLastFirstName(NULL, USR2.LastName, USR2.FirstName),
                       Rechtsdienst   = dbo.fnGetLastFirstName(NULL, RD.LastName, RD.FirstName)
                FROM dbo.XOrgUnit     ORG  WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XUser USR  WITH (READUNCOMMITTED) ON USR.UserID = ORG.ChiefID
                  LEFT JOIN dbo.XUser USR2 WITH (READUNCOMMITTED) ON USR2.UserID = ORG.RepresentativeID
                  LEFT JOIN dbo.XUser RD   WITH (READUNCOMMITTED) ON RD.UserID = ORG.RechtsdienstUserID
                ORDER BY ParentID, ParentPosition",
                Session.User.LanguageCode);

            // Laden der DropDown Box mit den Profilen.
            SqlQuery qry = GuiUtilities.GetSqlQueryXProfilesUserOrOrgUnit();

            edtUserProfile.LoadQuery(qry);
            edtUserProfile.Properties.DropDownRows = Math.Min(qry.Count, 14);
        }

        #endregion

        #region EventHandlers

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (qryOrgUnit.Count == 0 || qryKandidaten.Count == 0)
            {
                return;
            }

            if (!qryOrgUnit.Post(false))
            {
                return; // PerformEndEditControls
            }

            DBUtil.NewHistoryVersion();

            qryZugeteilt.Insert();
            qryZugeteilt["OrgUnitID"] = qryOrgUnit["OrgUnitID"];
            qryZugeteilt["UserID"] = qryKandidaten["UserID"];

            //Default: als Mitglied eintragen, oder als Gast, wenn der Benutzer bereits Mitglied in einer anderen Abteilung
            var memberCount = (int)DBUtil.ExecuteScalarSQL("SELECT COUNT(*) FROM dbo.XOrgUnit_User WITH (READUNCOMMITTED) WHERE UserID = {0}", qryKandidaten["UserID"]);

            if (memberCount == 0)
            {
                qryZugeteilt["OrgUnitMemberCode"] = 2; //Mitglied
            }
            else
            {
                qryZugeteilt["OrgUnitMemberCode"] = 3; //Gast
            }

            qryZugeteilt.Post();
            qryOrgUnit.RowModified = false; //important!
            qryOrgUnit.Row.AcceptChanges();

            DisplayMembers();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (qryZugeteilt.Count == 0)
            {
                return;
            }

            DBUtil.NewHistoryVersion();
            qryZugeteilt.Delete();
            DisplayMembers();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (qryOrgUnit.Count == 0 || !qryOrgUnit.Post())
            {
                return;
            }

            DBUtil.NewHistoryVersion();
            DBUtil.ExecSQL("DELETE FROM dbo.XOrgUnit_User WHERE OrgUnitID = {0}", qryOrgUnit["OrgUnitID"]);

            DisplayMembers();
        }

        private void CtlOrgUnit_Load(object sender, EventArgs e)
        {
            tabOrgUnit.SelectedTabIndex = 0;

            qryZugeteilt.DeleteQuestion = "";

            colModulID.ColumnEdit = grdZugeteilt.GetLOVLookUpEdit((SqlQuery)edtModulID.Properties.DataSource);

            grdZugeteilt.View.Columns["OrgUnitMemberCode"].ColumnEdit = grdZugeteilt.GetLOVLookUpEdit(
                DBUtil.GetLOVQuery("OrgUnitMember", false, "AND Code IN (2, 3)"));

            treOrgUnit.ExpandAll();
        }

        private void edtFilter_EditValueChanged(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(edtFilter.EditValue))
            {
                qryKandidaten.DataTable.DefaultView.RowFilter = null;
            }
            else
            {
                qryKandidaten.DataTable.DefaultView.RowFilter = string.Format("UserName LIKE '%{0}%'", edtFilter.Text);
            }
        }

        private void edtLeitung_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtLeitung.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryOrgUnit["Leitung"] = dlg["Name"];
                qryOrgUnit["ChiefID"] = dlg["UserID"];
            }
        }

        private void edtRechtsdienst_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtRechtsdienst.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryOrgUnit["Rechtsdienst"] = dlg["Name"];
                qryOrgUnit["RechtsdienstUserID"] = dlg["UserID"];
            }
        }

        private void edtStellvertreter_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtStellvertreter.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryOrgUnit["Stellvertreter"] = dlg["Name"];
                qryOrgUnit["RepresentativeID"] = dlg["UserID"];
            }
        }

        private void grdVerfuegbar_DoubleClick(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                btnAdd.PerformClick();
            }
        }

        private void qryOrgUnit_AfterPost(object sender, EventArgs e)
        {
            // set values to non dbdata fields
            qryOrgUnit["OrgUnitTyp"] = edtOrgUnit.Text;

            DisplayMembers();
        }

        private void qryOrgUnit_BeforeDelete(object sender, EventArgs e)
        {
            if ((int)DBUtil.ExecuteScalarSQL("SELECT COUNT(*) FROM dbo.XOrgUnit WITH (READUNCOMMITTED) WHERE ParentID = {0}", qryOrgUnit["OrgUnitID"]) > 0)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASSNAME,
                        "UnterabteilungenBestehen",
                        "Abteilung kann nicht gelöscht werden, solange Unterabteilungen bestehen!",
                        KissMsgCode.MsgInfo));
            }

            // Einträge in XOrgUnit_User löschen
            DBUtil.ExecSQL(@"
                DELETE FROM dbo.XOrgUnit_User
                WHERE OrgUnitID = {0}",
                qryOrgUnit["OrgUnitID"]);
        }

        private void qryOrgUnit_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtItemName, lblItemName.Text);

            //check duplicate ItemName
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT TOP 1 1
                FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                WHERE ItemName = {0}
                  AND OrgUnitID <> {1}",
                qryOrgUnit["ItemName"],
                qryOrgUnit["OrgUnitID"]);

            if (qry.Count > 0)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASSNAME,
                        "AbteilungsnameBereitsVerwendet",
                        "Dieser Abteilungsname wird bereits verwendet!",
                        KissMsgCode.MsgInfo));
            }

            //save pending changes
            qryZugeteilt.Post();

            //Wenn in der DropDown keine Auswahl getroffen worden ist, dann ist der Code -1.
            //In diesem Falle speichern wir null.
            if (Utils.ConvertToInt(qryOrgUnit["XProfileID"]) == -1)
            {
                qryOrgUnit["XProfileID"] = null;
            }

            if (qryOrgUnit.RowModified)
            {
                // Modifier/Modified
                qryOrgUnit.SetModifierModified();

                DBUtil.NewHistoryVersion();
            }
        }

        private void qryOrgUnit_PositionChanged(object sender, EventArgs e)
        {
            DisplayMembers();
        }

        private void qryZugeteilt_BeforePost(object sender, EventArgs e)
        {
            //Neue Einträge werden unter btnAdd_Click automatisch erzeugt
            if (qryZugeteilt.Row.RowState == DataRowState.Added)
            {
                return;
            }

            //bei Änderung durch Benutzer: prüfen, ob keine Mehrfachmitgliedschaft ensteht
            if ((int)qryZugeteilt["OrgUnitMemberCode"] == 2)
            {
                var memberCount = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT	COUNT(*)
                    FROM dbo.XOrgUnit_User WITH (READUNCOMMITTED)
                    WHERE UserID = {0}
                      AND OrgUnitMemberCode = 2
                      AND OrgUnitID <> {1}",
                    qryZugeteilt["UserID"],
                    qryOrgUnit["OrgUnitID"]);

                if (memberCount == 1)
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            CLASSNAME,
                            "UnterabteilungenBestehen",
                            "{0} ist bereits Mitglied in einer anderen Abteilung!",
                            KissMsgCode.MsgInfo,
                            qryZugeteilt["UserName"]));
                }
            }

            // HistoryVersion
            if (qryZugeteilt.RowModified)
            {
                DBUtil.NewHistoryVersion();
            }
        }

        private void qryZugeteilt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            qryOrgUnit.RowModified = true;
        }

        private void treOrgUnit_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e)
        {
            if (_firstLoop)
            {
                _firstLoop = false;
                e.CanFocus = qryOrgUnit.Post();
                _firstLoop = true;
            }
        }

        private void treOrgUnit_GetSelectImage(object sender, GetSelectImageEventArgs e)
        {
            e.NodeImageIndex = Math.Min(e.Node.Level, 3);
        }

        private void UpDown_Click(object sender, EventArgs e)
        {
            if (qryOrgUnit.Count == 0 || !qryOrgUnit.Post())
            {
                return;
            }

            SqlQuery qry;
            Session.BeginTransaction();
            try
            {
                if (sender == btnUp)
                {
                    // Vorgänger bestimmen
                    // Muss innerhalb einer Transkation sein,
                    // da sonst in der Zwischeinzeit ein anderer User etwas verschieben kann
                    qry = DBUtil.OpenSQL(@"
                        SELECT TOP 1
                          OrgUnitID,
                          ParentPosition
                        FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                        WHERE ISNULL(ParentID, -1) = ISNULL({0}, -1)
                          AND ParentPosition < {1}
                        ORDER BY ParentPosition DESC",
                        qryOrgUnit["ParentID"],
                        qryOrgUnit["ParentPosition"]);
                }
                else
                {
                    // Nachfolger bestimmen
                    // Muss innerhalb einer Transkation sein,
                    // da sonst in der Zwischeinzeit ein anderer User etwas verschieben kann
                    qry = DBUtil.OpenSQL(@"
                        SELECT TOP 1
                          OrgUnitID,
                          ParentPosition
                        FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                        WHERE ISNULL(ParentID, -1) = ISNULL({0}, -1)
                          AND ParentPosition > {1}
                        ORDER BY ParentPosition ASC",
                        qryOrgUnit["ParentID"],
                        qryOrgUnit["ParentPosition"]);
                }

                // es muss zuerst eine Position bestimmt werden, welche noch nicht existiert.
                // Ansonsten wird "UK_XOrgUnit_ParentID_ParentPosition" verletzt.
                // Dazu nehmen wir einfach das MAX und erhöhen um 1.
                // Transkaktion ist deshalb zwingend erforderlich.
                SqlQuery qryMax = DBUtil.OpenSQL(@"SELECT maxPos = MAX(ParentPosition) FROM dbo.XOrgUnit WITH (READUNCOMMITTED)");
                int maxPos = Utils.ConvertToInt(qryMax["maxPos"]);
                maxPos = maxPos + 1;

                if (qry.Count > 0)
                {
                    DBUtil.NewHistoryVersion();

                    // Positionen tauschen
                    // zuerst auf eine temporäre Position setzen (maxPos)
                    DBUtil.ExecSQLThrowingException(
                        "UPDATE dbo.XOrgUnit SET ParentPosition = {0} WHERE OrgUnitID = {1}",
                        maxPos,
                        qryOrgUnit["OrgUnitID"]);
                    // dann den ersten Eintrag ändern
                    DBUtil.ExecSQLThrowingException(
                        "UPDATE dbo.XOrgUnit SET ParentPosition = {0} WHERE OrgUnitID = {1}",
                        qryOrgUnit["ParentPosition"],
                        qry["OrgUnitID"]);
                    // dann zweiten Eintrag ändern, welcher momentan auf der temporären Position ist (maxPos)
                    DBUtil.ExecSQLThrowingException(
                        "UPDATE dbo.XOrgUnit SET ParentPosition = {0} WHERE OrgUnitID = {1}",
                        qry["ParentPosition"],
                        qryOrgUnit["OrgUnitID"]);
                    Session.Commit();
                }
                else
                {
                    // Eintrag ist bereits zuoberst oder zuunterst,
                    // also muss nichts gemacht werden
                    Session.Rollback();
                }
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(
                    CLASSNAME,
                    "ErrorMoveOrgUnit",
                    "Beim Verschieben der Abteilung ist ein unbekannter Fehler aufgetreten.",
                    ex
                    );
            }

            // Neue Position im Tree anzeigen
            RefreshTree(qryOrgUnit["ItemName"].ToString());
        }

        #endregion

        #region Methods

        #region Public Methods

        // EndRule
        public override bool OnAddData()
        {
            if (!qryOrgUnit.CanInsert || qryOrgUnit.Count > 0 && !qryOrgUnit.Post())
            {
                return false;
            }

            string newName = GetNewAbteilungName();

            int newPos = 1;

            if (qryOrgUnit.Count > 0)
            {
                newPos = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT ISNULL(MAX(ParentPosition) + 1, 1)
                    FROM dbo.XOrgUnit WITH (READUNCOMMITTED)
                    WHERE ParentID = {0};",
                    qryOrgUnit["OrgUnitID"]);
            }

            // make new history version
            DBUtil.NewHistoryVersion();

            // create new entry
            DBUtil.ExecSQL(@"
                INSERT INTO dbo.XOrgUnit (ParentID, ParentPosition, ItemName, Creator, Modifier)
                VALUES ({0}, {1}, {2}, {3}, {4});",
                qryOrgUnit.Count == 0 ? DBNull.Value : qryOrgUnit["OrgUnitID"],
                newPos,
                newName,
                DBUtil.GetDBRowCreatorModifier(),
                DBUtil.GetDBRowCreatorModifier());

            RefreshTree(newName);

            return true;
        }

        #endregion

        #region Private Methods

        private void DisplayMembers()
        {
            // unassigned users
            qryKandidaten.Fill(@"
                SELECT USR.UserID,
                       UserName = dbo.fnGetLastFirstName(NULL, USR.Lastname, Firstname) + ' (' + LogonName + ')'
                FROM dbo.XUser USR WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID AND OUU.OrgUnitID = {0}
                WHERE OUU.OrgUnitID IS NULL
                ORDER BY UserName",
                qryOrgUnit["OrgUnitID"]);

            // assigend users
            qryZugeteilt.Fill(@"
                SELECT OUU.*,
                       UserName = dbo.fnGetLastFirstName(NULL, USR.Lastname, Firstname) + ' (' + LogonName + ')'
                FROM dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED)
                  INNER JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = OUU.UserID
                WHERE OUU.OrgUnitID = {0}
                  AND OUU.OrgUnitMemberCode IN (2, 3)
                ORDER BY OUU.OrgUnitMemberCode, UserName",
                qryOrgUnit["OrgUnitID"]);
        }

        private string GetNewAbteilungName()
        {
            int idx = 0;
            string name;
            SqlQuery qry;
            var abteilungMl = KissMsg.GetMLMessage(CLASSNAME, "NameNeueAbteilung", "Abteilung");

            do
            {
                idx++;
                name = abteilungMl + idx;
                qry = DBUtil.OpenSQL("SELECT 1 FROM dbo.XOrgUnit WITH (READUNCOMMITTED) WHERE ItemName = {0}", name);
            }
            while (qry.Count > 0);

            return name;
        }

        private void RefreshTree(string name)
        {
            treOrgUnit.DataSource = null;
            qryOrgUnit.Refresh();
            treOrgUnit.DataSource = qryOrgUnit;

            treOrgUnit.ExpandAll();

            //locate new Abteilung
            var node = DBUtil.FindNodeByValue(treOrgUnit.Nodes, name, "ItemName");

            if (node != null)
            {
                treOrgUnit.FocusedNode = node;
            }
        }

        #endregion

        #endregion
    }
}