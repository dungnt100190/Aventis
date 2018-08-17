using System;
using System.Data;

using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.XtraGrid;
using DevExpress.XtraTreeList.Nodes;

namespace KiSS4.Administration
{
    /// <summary>
    /// Mask to create and modify hyperlink contexts
    /// </summary>
    public partial class CtlHyperlinkContext : KissUserControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlHyperlinkContext"/> class
        /// </summary>
        public CtlHyperlinkContext()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Does some initialization stuff
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e"></param>
        private void CtlUser_Load(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repItem = treZugeteilt.GetLOVLookUpEdit("UserProfile");
            repItem.EditValueChanged += repItem_EditValueChanged;
            colUserProfileCode.ColumnEdit = repItem;

            treZugeteilt.OptionsBehavior.Editable = true;

            qryHyperlinkContext.Fill(@"
                SELECT XHyperlinkContextID,
                       Name,
                       Description
                FROM dbo.XHyperlinkContext WITH(READUNCOMMITTED)
                ORDER BY Name;");

            qryZugeteilt.DeleteQuestion = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (sender == btnAdd && (qryHyperlinkContext.Count == 0 || qryVerfuegbar.Count == 0)) return;
            if (qryHyperlinkContext.Row.RowState == DataRowState.Added && !qryHyperlinkContext.Post()) return;

            string newFolderName = null;

            if (sender == btnAddFolder)
            {
                if (DBUtil.IsEmpty(edtFolderName.Text))
                {
                    KissMsg.ShowInfo(
                        typeof(CtlHyperlinkContext).Name,
                        "NameNeuerOrdnerLeer",
                        "Der Name des neuen Ordners muss zuerst im Feld 'Ordnername' eingeben werden!");
                    return;
                }

                newFolderName = edtFolderName.Text;
            }

            object newParentID = DBNull.Value;
            int newPosition = 1;
            object newDocumentID = null;

            if (sender == btnAdd)
            {
                newDocumentID = qryVerfuegbar["XHyperlinkID"];
            }

            if (qryZugeteilt.Count > 0)
            {
                if (edtInsertAtSameLevel.Checked || DBUtil.IsEmpty(qryZugeteilt["FolderName"]))
                {
                    newParentID = qryZugeteilt["ParentID"];
                }
                else
                {
                    newParentID = (int)qryZugeteilt["XHyperlinkContext_HyperlinkID"];
                }

                newPosition = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT ISNULL(MAX(SortKey) + 1, 1)
                    FROM dbo.XHyperlinkContext_Hyperlink WITH(READUNCOMMITTED)
                    WHERE XHyperlinkContextID = {0}
                      AND ISNULL(ParentID, 0) = ISNULL({1}, 0)",
                    qryHyperlinkContext["XHyperlinkContextID"],
                    newParentID);
            }

            SqlQuery qry = DBUtil.OpenSQL(@"
                INSERT dbo.XHyperlinkContext_Hyperlink (XHyperlinkContextID, XHyperlinkID, FolderName, ParentID, SortKey)
                  VALUES ({0},{1},{2},{3},{4});
                SELECT @@IDENTITY XHyperlinkContext_HyperlinkID;",
                qryHyperlinkContext["XHyperlinkContextID"],
                newDocumentID,
                newFolderName,
                newParentID,
                newPosition);

            int newRowHandle = grdVerfuegbar.View.GetNextVisibleRow(grdVerfuegbar.View.FocusedRowHandle);

            if (newRowHandle == GridControl.InvalidRowHandle)
            {
                DisplayVerfuegbar(null);
            }
            else
            {
                DisplayVerfuegbar(grdVerfuegbar.View.GetRowCellValue(newRowHandle, grdVerfuegbar.View.Columns["XHyperlinkID"]));
            }

            DisplayZugeteilt(qry.Count > 0 ? qry["XHyperlinkContext_HyperlinkID"] : null);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            btnUp.Enabled = false;
            btnDown.Enabled = false;

            if (qryZugeteilt.Count <= 1) return;
            if (!qryZugeteilt.Post()) return;

            //Nachfolger bestimmen
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT TOP 1 *
                FROM dbo.XHyperlinkContext_Hyperlink WITH(READUNCOMMITTED)
                WHERE ISNULL(ParentID, 0) = ISNULL({0}, 0)
                  AND SortKey > {1}
                ORDER BY SortKey;",
                qryZugeteilt["ParentID"],
                qryZugeteilt["SortKey"]);

            if (qry.Count == 0)
            {
                btnUp.Enabled = true;
                btnDown.Enabled = true;
                return;
            }

            //Position tauschen
            DBUtil.ExecSQL(@"
                UPDATE dbo.XHyperlinkContext_Hyperlink
                SET SortKey = {0}
                WHERE XHyperlinkContext_HyperlinkID = {1};",
                qry["SortKey"],
                qryZugeteilt["XHyperlinkContext_HyperlinkID"]);

            DBUtil.ExecSQL(@"
                UPDATE dbo.XHyperlinkContext_Hyperlink
                SET SortKey = {0}
                WHERE XHyperlinkContext_HyperlinkID = {1};",
                qryZugeteilt["SortKey"],
                qry["XHyperlinkContext_HyperlinkID"]);

            DisplayZugeteilt(qryZugeteilt["XHyperlinkContext_HyperlinkID"]);
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (qryHyperlinkContext.Count == 0 || qryZugeteilt.Count == 0)
            {
                return;
            }

            if (qryHyperlinkContext.Row.RowState == DataRowState.Added)
            {
                return;
            }

            if (!KissMsg.ShowQuestion(typeof(CtlHyperlinkContext).Name, "ZugeteilteVorlagenEntfernen", "Alle zugeteilten Vorlagen entfernen?"))
            {
                return;
            }

            DBUtil.ExecSQL(@"
                DELETE FROM dbo.XHyperlinkContext_Hyperlink
                WHERE XHyperlinkContextID = {0};",
                qryHyperlinkContext["XHyperlinkContextID"]);

            DisplayZugeteilt(null);
            DisplayVerfuegbar(null);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (qryHyperlinkContext.Count == 0 || qryZugeteilt.Count == 0) return;
            if (qryHyperlinkContext.Row.RowState == DataRowState.Added) return;

            if (!DBUtil.IsEmpty(qryZugeteilt["FolderName"]))
            {
                int count = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(*)
                    FROM XHyperlinkContext_Hyperlink WITH(READUNCOMMITTED)
                    WHERE XHyperlinkContextID = {0}
                      AND ParentID = {1};",
                    qryHyperlinkContext["XHyperlinkContextID"],
                    qryZugeteilt["XHyperlinkContext_HyperlinkID"]);

                if (count > 0)
                {
                    KissMsg.ShowInfo(
                        typeof(CtlHyperlinkContext).Name,
                        "OrdnerEntfernenNichtMoeglich",
                        "Dieser Ordner kann nicht entfernt werden, da er noch Vorlagen oder Ordner enthält.");
                    return;
                }
            }

            object documentID = qryZugeteilt["XHyperlinkID"];
            qryZugeteilt.Delete();

            if (!DBUtil.IsEmpty(documentID))
                DisplayVerfuegbar(documentID);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            btnUp.Enabled = false;
            btnDown.Enabled = false;

            if (qryZugeteilt.Count <= 1) return;
            if (!qryZugeteilt.Post()) return;

            //Vorgänger bestimmen
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT TOP 1 *
                FROM dbo.XHyperlinkContext_Hyperlink WITH(READUNCOMMITTED)
                WHERE ISNULL(ParentID, 0) = ISNULL({0}, 0)
                  AND SortKey < {1}
                ORDER BY SortKey DESC;",
                qryZugeteilt["ParentID"],
                qryZugeteilt["SortKey"]);

            if (qry.Count == 0)
            {
                btnUp.Enabled = true;
                btnDown.Enabled = true;
                return;
            }

            //Position tauschen
            DBUtil.ExecSQL(@"
                UPDATE dbo.XHyperlinkContext_Hyperlink
                SET SortKey = {0}
                WHERE XHyperlinkContext_HyperlinkID = {1};",
                qry["SortKey"],
                qryZugeteilt["XHyperlinkContext_HyperlinkID"]);

            DBUtil.ExecSQL(@"
                UPDATE dbo.XHyperlinkContext_Hyperlink
                SET SortKey = {0}
                WHERE XHyperlinkContext_HyperlinkID = {1};",
                qryZugeteilt["SortKey"],
                qry["XHyperlinkContext_HyperlinkID"]);

            DisplayZugeteilt(qryZugeteilt["XHyperlinkContext_HyperlinkID"]);
        }

        private void qryHyperlinkContext_AfterInsert(object sender, EventArgs e)
        {
            edtName.Focus();
        }

        private void qryHyperlinkContext_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            //prüfen, ob noch zugeteilte Vorlagen/Ordner existieren
            int count = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.XHyperlinkContext_Hyperlink WITH(READUNCOMMITTED)
                WHERE XHyperlinkContextID = {0};",
                qryHyperlinkContext["XHyperlinkContextID"]);

            if (count > 0)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        typeof(CtlHyperlinkContext).Name,
                        "KontextNichtGeloeschtOrdnerVorhanden",
                        "Der Kontext '{0}' kann nicht gelöscht werden, solange noch zugeteilte Vorlagen/Ordner existieren!",
                        KissMsgCode.MsgInfo,
                        qryHyperlinkContext["Name"].ToString()));
            }
        }

        private void qryHyperlinkContext_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtName, lblName.Text);
            DBUtil.CheckNotNullField(edtDescription, lblDescription.Text);
        }

        private void qryHyperlinkContext_PositionChanged(object sender, EventArgs e)
        {
            DisplayZugeteilt(null);
            DisplayVerfuegbar(null);
            edtFolderName.EditMode = EditModeType.Normal;
        }

        private void repItem_EditValueChanged(object sender, EventArgs e)
        {
            treZugeteilt.CloseEditor();
            //save pending changes
            qryZugeteilt.Post();
        }

        #endregion

        #region Methods

        #region Private Methods

        private void DisplayVerfuegbar(object relocateID)
        {
            qryVerfuegbar.Fill(@"
                SELECT HYP.XHyperlinkID,
                       HYP.Name,
                       HYP.Hyperlink
                FROM dbo.XHyperlink                         HYP WITH(READUNCOMMITTED)
                  LEFT JOIN dbo.XHyperlinkContext_Hyperlink HYH WITH(READUNCOMMITTED) ON HYH.XHyperlinkID = HYP.XHyperlinkID
                                                                                     AND HYH.XHyperlinkContextID = {0}
                WHERE HYH.XHyperlinkContextID IS NULL
                ORDER BY HYP.Name;",
                qryHyperlinkContext["XHyperlinkContextID"]);

            if (relocateID != null)
            {
                int rowHandle = grdVerfuegbar.View.LocateByValue(0, grdVerfuegbar.View.Columns["XHyperlinkID"], (int)relocateID);

                if (rowHandle != GridControl.InvalidRowHandle)
                {
                    grdVerfuegbar.View.FocusedRowHandle = rowHandle;
                }
            }
        }

        private void DisplayZugeteilt(object relocateID)
        {
            qryZugeteilt.Fill(qryHyperlinkContext["XHyperlinkContextID"]);

            treZugeteilt.ExpandAll();

            if (relocateID != null)
            {
                //relocate to ID
                TreeListNode node = DBUtil.FindNodeByValue(treZugeteilt.Nodes, relocateID.ToString(), "XHyperlinkContext_HyperlinkID");

                if (node != null)
                {
                    treZugeteilt.FocusedNode = node;
                }
            }

            btnUp.Enabled = true;
            btnDown.Enabled = true;
        }

        #endregion

        #endregion
    }
}