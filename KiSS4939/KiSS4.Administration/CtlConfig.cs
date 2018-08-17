using System;
using System.Data;
using System.Windows.Forms;

using DevExpress.XtraGrid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    /// <summary>
    /// Maintains values in table XConfig. It cannot add or delete records in XConfig, it just displays
    /// existing ones as a tree and allows controlled editing of the values.
    /// <p></p>
    /// A KeyPath has the form "System\FibuLink\Abacus\MandatenNr". No leading and no trailing separator,
    /// which is consistent with Windows registry keys.
    /// </summary>
    public partial class CtlConfig : KissUserControl
    {
        /// <summary>
        /// Special filter criteria for namespace extension
        /// </summary>
        private enum NSESpecialFilter
        {
            /// <summary>
            /// Show all entries, do not filter by nse
            /// </summary>
            ShowAll = -1,

            /// <summary>
            /// Show only those entries without nse assigned
            /// </summary>
            ShowWithoutNSE = -2
        }

        private const string CLASSNAME = "CtlConfig";

        private const char SEPARATOR = '\\';

        private readonly string _disabledText;

        private readonly string _enabledText;

        private readonly int _panBottomFilterHeight;

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlConfig"/> class.
        /// </summary>
        public CtlConfig()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // init texts
            _enabledText = KissMsg.GetMLMessage(CLASSNAME, "EnabledValue", "aktiviert");
            _disabledText = KissMsg.GetMLMessage(CLASSNAME, "DisabledValue", "deaktiviert");

            // TODO: still this way??
            // In Node.Data we store a boolean; true means the data is valid, false means it is not. This
            // does NOT come from the DB, but is validated at runtime. Invalid values are shown in errorColor.
            // To switch back we have to remember the defaultForeColor of a control.
            /* this.defaultForeColor = edtValueTextEdit.ForeColor; */

            // park all input fields in the same position of kissTextEditValue.
            edtValueCheckEdit.Location = edtValueTextEdit.Location;
            edtValueCheckEdit.Top = edtValueCheckEdit.Top + 2;
            edtValueMemoEdit.Location = edtValueTextEdit.Location;
            edtValueDateEdit.Location = edtValueTextEdit.Location;
            edtValueCalcEdit.Location = edtValueTextEdit.Location;
            edtValueCheckedLookupEdit.Location = edtValueTextEdit.Location;
            edtValueMemoEdit.Height = panDetails.Height - edtValueMemoEdit.Top - 9;
            edtValueMemoEdit.Anchor = edtValueMemoEdit.Anchor | AnchorStyles.Bottom;

            edtKeyPath.EditMode = Session.User.IsUserAdmin ? EditModeType.Normal : EditModeType.ReadOnly;
            edtDescription.EditMode = Session.User.IsUserAdmin ? EditModeType.Normal : EditModeType.ReadOnly;

            // init filter
            _panBottomFilterHeight = panBottomFilter.Height;
            chkShowFilter.Checked = false;
            ShowHideFilter();
            ResetAllFilter();
        }

        // store the default height for panBottomFilter (shown height)
        public override void OnRefreshData()
        {
            base.OnRefreshData();

            var currentKeyPath = GetCurrentKeyPath();
            LoadTreeData();
            var node = treConfigTree.FindNodeByFieldValue("colKeyPath", currentKeyPath);
            treConfigTree.SetFocusedNode(node);
        }

        private static string Object2String(object obj)
        {
            if (obj == DBNull.Value || obj == null)
            {
                return "";
            }

            return Convert.ToString(obj);
        }

        /// <summary>
        /// Apply defined filter critera to tree-nodes-filter
        /// </summary>
        private void ApplyFilter()
        {
            // validate save first
            if (qryValue.CanUpdate && !qryValue.Post())
            {
                // do not filter anything
                ResetAllFilter();

                // cancel
                return;
            }

            // clear display
            treConfigTree.FocusedNode = null;
            ResetDetailDisplay();

            // setup tree
            treConfigTree.OptionsBehavior.EnableFiltering = true;
            treConfigTree.FilterConditions.Clear();

            // check if need to filter key
            if (!string.IsNullOrEmpty(edtFilterKey.Text))
            {
                // apply new key filter
                treConfigTree.FilterConditions.Add(
                    new FilterCondition(
                        FormatConditionEnum.Equal,
                        colDisplayPath,
                        edtFilterKey.Text,
                        null,
                        true));
                treConfigTree.FilterConditions.Add(
                    new FilterCondition(
                        FormatConditionEnum.Equal,
                        colKeyPath,
                        edtFilterKey.Text,
                        null,
                        true));
            }

            // check if need to filter namespace extension
            if (!DBUtil.IsEmpty(edtFilterNamespaceExtension.EditValue))
            {
                // apply new nse filter
                treConfigTree.FilterConditions.Add(
                    new FilterCondition(
                        FormatConditionEnum.Equal,
                        colFilterNSEID,
                        Convert.ToInt32(edtFilterNamespaceExtension.EditValue),
                        null,
                        true));
            }
        }

        private void btnCollapseAll_Click(object sender, EventArgs e)
        {
            // get root node
            treConfigTree.CollapseAll();

            if (treConfigTree.FocusedNode != null)
            {
                // expand it
                treConfigTree.FocusedNode.Expanded = true;
            }

            // focus
            treConfigTree.Focus();
        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            // show all items
            treConfigTree.ExpandAll();

            // focus
            treConfigTree.Focus();
        }

        private void btnResetKeyFilter_Click(object sender, EventArgs e)
        {
            // reset
            ResetKeyFilter();

            // set focus
            edtFilterKey.Focus();
        }

        private void btnResetNamespaceFilter_Click(object sender, EventArgs e)
        {
            // reset
            ResetNamespaceFilter();

            // set focus
            edtFilterNamespaceExtension.Focus();
        }

        private void chkShowFilter_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideFilter();
        }

        private void edtFilterKey_EditValueChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void edtFilterNamespaceExtension_EditValueChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private TreeListNode FindNodeInTreeListNodes(TreeListNodes tln, string key)
        {
            foreach (TreeListNode node in tln)
            {
                if (Convert.ToString(node.GetValue("colKey")) == key)
                {
                    return node;
                }
            }

            return null;
        }

        private void CtlConfig_Load(object sender, EventArgs e)
        {
            // load namespace extensions
            var qryNSE = DBUtil.OpenSQL(@"
                SELECT Code = NULL,
                       Text = ''

                UNION

                SELECT Code = XNamespaceExtensionID,
                       Text = NamespaceExtension
                FROM dbo.XNamespaceExtension
                ORDER BY Text, Code;");

            var qryNSEFilter = DBUtil.OpenSQL(@"
                SELECT Code = {0},
                       Text = {1}   -- show all

                UNION

                SELECT Code = {2},
                       Text = {3}   -- show only without nse

                UNION

                SELECT Code = XNamespaceExtensionID,
                       Text = NamespaceExtension
                FROM dbo.XNamespaceExtension
                ORDER BY Text, Code;",
                Convert.ToInt32(NSESpecialFilter.ShowAll),
                KissMsg.GetMLMessage(CLASSNAME, "NSEFilterShowAll", "(alle)"),
                Convert.ToInt32(NSESpecialFilter.ShowWithoutNSE),
                KissMsg.GetMLMessage(CLASSNAME, "NSEFilterShowWithout_v01", "(ohne Namespace)"));

            // set dropdown
            edtNamespaceExtension.LoadQuery(qryNSE);
            edtFilterNamespaceExtension.LoadQuery(qryNSEFilter);

            LoadTreeData();
        }

        private string GetCurrentKeyPath()
        {
            return Convert.ToString(qryValue[DBO.XConfig.KeyPath]);
        }

        private string GetDisplayValue(string keyPath)
        {
            return Convert.ToString(DBUtil.ExecuteScalarSQL(@"
                --SQLCHECK_IGNORE--
                SELECT Wert = CASE
                                WHEN ValueCode = 2 THEN CONVERT(VARCHAR, ValueInt)
                                WHEN ValueCode = 3 THEN CONVERT(VARCHAR, ValueDecimal)
                                WHEN ValueCode = 4 THEN CONVERT(VARCHAR, ValueMoney)
                                WHEN ValueCode = 5 THEN CASE ValueBit
                                                          WHEN 1 THEN {1}
                                                          ELSE {2}
                                                        END
                                WHEN ValueCode = 6 THEN CONVERT(VARCHAR, ValueDateTime, 104)
                                ELSE ValueVarchar
                              END
                FROM dbo.XConfig WITH (READUNCOMMITTED)
                WHERE KeyPath = {0}
                  AND DatumVon <= GETDATE()
                ORDER BY DatumVon DESC;", keyPath, _enabledText, _disabledText));
        }

        /// <summary>
        /// Get value from given node
        /// </summary>
        /// <param name="node">The node to get value from</param>
        /// <param name="columnName">The column name to get value</param>
        /// <param name="returnIfEmpty">The return value if node does not have a valid value</param>
        /// <returns>The node value for given column or <paramref name="returnIfEmpty"/> if empty</returns>
        private string GetNodeValue(TreeListNode node, string columnName, string returnIfEmpty)
        {
            // validate
            if (node.GetValue(columnName) == null || !(node.GetValue(columnName) is string))
            {
                // empty
                return returnIfEmpty;
            }

            // return value
            return Convert.ToString(node.GetValue(columnName));
        }

        /// <summary>
        /// Get value from given node
        /// </summary>
        /// <param name="node">The node to get value from</param>
        /// <param name="columnName">The column name to get value</param>
        /// <param name="returnIfEmpty">The return value if node does not have a valid value</param>
        /// <returns>The node value for given column or <paramref name="returnIfEmpty"/> if empty</returns>
        private int GetNodeValue(TreeListNode node, string columnName, int returnIfEmpty)
        {
            // validate
            if (node.GetValue(columnName) == null || !(node.GetValue(columnName) is int))
            {
                // empty
                return returnIfEmpty;
            }

            // return value
            return Convert.ToInt32(node.GetValue(columnName));
        }

        private void LoadTreeData()
        {
            qryConfigTree.Fill(Session.User.IsUserBIAGAdmin, Session.User.LanguageCode);
        }

        /// <summary>
        /// Show (visible=true) all parent items up to root
        /// </summary>
        /// <param name="node">The node to make visible with its parent nodes</param>
        private void MakeParentItemsVisible(TreeListNode node)
        {
            // validate
            if (node == null)
            {
                // done
                return;
            }

            // check
            if (!node.Visible)
            {
                // show node
                node.Visible = true;
            }

            // recursive
            MakeParentItemsVisible(node.ParentNode);
        }

        private void qryConfigTree_AfterFill(object sender, EventArgs e)
        {
            // Load tree from qryConfigTree.
            treConfigTree.BeginUnboundLoad();
            treConfigTree.Nodes.Clear();

            try
            {
                foreach (DataRow row in qryConfigTree.DataTable.Rows)
                {
                    TreeListNodes currentLevelNodes = treConfigTree.Nodes;
                    TreeListNode currentParent = null;
                    string displayPath = Convert.ToString(row["DisplayPath"]);
                    string keyPath = Convert.ToString(row["KeyPath"]);
                    int filterNseId = Convert.ToInt32(row["FilterNSEID"]);
                    string amount = Convert.ToString(row["Amount"]);
                    string[] segs = displayPath.Split(SEPARATOR);

                    // level in tree is equal to index in segs array
                    for (int level = 0; level < segs.Length; level++)
                    {
                        TreeListNode node = FindNodeInTreeListNodes(currentLevelNodes, segs[level]);

                        if (null == node)
                        {
                            string tmpValue = "";
                            string tmpDisplayPath = "";
                            string tmpKeyPath = "";
                            string tmpAmount = "";

                            if (level + 1 == segs.Length)
                            {
                                // only leafs get data in the columns
                                tmpValue = GetDisplayValue(displayPath);
                                tmpDisplayPath = displayPath;
                                tmpKeyPath = keyPath;
                                tmpAmount = amount;
                            }

                            // node does not yet exist, so we insert it (WARNING: see column order in designer of tree!)
                            node = treConfigTree.AppendNode(new object[] { segs[level], tmpValue, tmpAmount, tmpKeyPath, tmpDisplayPath, filterNseId }, currentParent);

                            if (null != currentParent)
                            {
                                currentParent.HasChildren = true;
                            }

                            node.Tag = true; // means data OK, display in normal color
                        }

                        currentParent = node;
                        currentLevelNodes = currentParent.Nodes;
                    }
                } // [foreach]
            }
            finally
            {
                treConfigTree.EndUnboundLoad();

                if (treConfigTree.Nodes.Count > 0)
                {
                    treConfigTree.Nodes[0].Expanded = true;
                }
            }
        }

        private void qryValue_AfterDelete(object sender, EventArgs e)
        {
            // required to refresh the new value in the colValue column in the tree list.
            treConfigTree.FocusedNode["colValue"] = GetDisplayValue(GetCurrentKeyPath());

            // update session-storage of memory
            RemoveConfigFromMemory();

            // refresh data in query and select last entry (refresh will not reposition)
            RefreshValueQuery();
            qryValue.Last();
        }

        private void qryValue_AfterFill(object sender, EventArgs e)
        {
            edtKeyPath.ToolTip = qryValue[DBO.XConfig.KeyPath] as string;
        }

        private void qryValue_AfterPost(object sender, EventArgs e)
        {
            // required to refresh the new value in the colValue column in the tree list.
            treConfigTree.FocusedNode["colValue"] = GetDisplayValue(GetCurrentKeyPath());

            // update session-storage of memory
            RemoveConfigFromMemory();

            if (!DBUtil.IsEmpty(qryValue[DBO.XConfig.KeyPathTID]))
            {
                // gleiche TID für alle Werte setzen
                DBUtil.ExecSQL(@"
                    UPDATE dbo.XConfig
                    SET KeyPathTID = {0}
                    WHERE KeyPath = {1}", qryValue[DBO.XConfig.KeyPathTID], qryValue[DBO.XConfig.KeyPath]);
            }
        }

        private void qryValue_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if (qryValue.Count == 1)
            {
                // reset date, so we do not allow to delete complete entry
                qryValue[DBO.XConfig.DatumVon] = null;

                // cancel
                throw new KissCancelException();
            }
        }

        private void qryValue_BeforePost(object sender, EventArgs e)
        {
            int valueCode = Convert.ToInt32(qryValue[DBO.XConfig.ValueCode]);

            switch (valueCode)
            {
                case 1: // varchar
                case 2: // int
                case 3: // decimal
                case 4: // money
                case 5: // bit
                case 6: // datetime
                case 7: // varchar (multiline)
                    break;

                case 8: // UNCpath
                case 9: // UNCfile
                    int res = ValidateURI(Object2String(qryValue[DBO.XConfig.ValueVarchar]), valueCode);

                    if (res != 0)
                    {
                        string msg = "";

                        switch (res)
                        {
                            case -1:
                                msg = KissMsg.GetMLMessage(CLASSNAME, "InvalidSpelling", "Ungültige Schreibweise.");
                                break;

                            case -2:
                                msg = KissMsg.GetMLMessage(CLASSNAME, "PathIsNotReadable", "Pfad zeigt nicht auf ein lesbares Verzeichnis.");
                                break;

                            case -3:
                                msg = KissMsg.GetMLMessage(CLASSNAME, "FileIsNotReadable", "Pfad zeigt nicht auf eine lesbare Datei.");
                                break;
                        }

                        treConfigTree.FocusedNode.Tag = false;

                        throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME, "UngueltigeUNC", "Ungültige UNC Angabe. {0}", KissMsgCode.MsgInfo, msg));
                    }

                    treConfigTree.FocusedNode.Tag = true;
                    break;

                case 10: // XMLdoc
                case 11: // CSV
                    break;

                default:
                    throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME, "UnbekannterDatentyp", "Unbekannter Datentyp in XConfig.ValueCode: {0}", KissMsgCode.MsgInfo, qryValue.Row["ValueCode"]));
            }

            // check if need to copy entry (only if date has changed)
            if (qryValue.ColumnModified(DBO.XConfig.DatumVon) &&
                !DBUtil.IsEmpty(qryValue[DBO.XConfig.DatumVon]) &&
                !DBUtil.IsEmpty(qryValue[DBO.XConfig.DatumVon, DataRowVersion.Original]))
            {
                var qry = DBUtil.OpenSQL(@"
                    SELECT
                      XConfigID,
                      XNamespaceExtensionID,
                      KeyPath,
                      KeyPathTID,
                      System,
                      DatumVon,
                      ValueCode,
                      LOVName,
                      Description,
                      ValueBit,
                      OriginalValueBit,
                      ValueDateTime,
                      OriginalValueDateTime,
                      ValueDecimal,
                      OriginalValueDecimal,
                      ValueInt,
                      OriginalValueInt,
                      ValueMoney,
                      OriginalValueMoney,
                      ValueVarchar,
                      OriginalValueVarchar,
                      Creator,
                      Created,
                      Modifier,
                      Modified,
                      XConfigTS
                    FROM dbo.XConfig WITH (READUNCOMMITTED)
                    WHERE 1 = 0;");

                qry.Insert(DBODef.XConfig.TableDef.Name);

                foreach (DataColumn col in qry.DataTable.Columns)
                {
                    if (col.ColumnName != DBO.XConfig.XConfigID &&
                        col.ColumnName != DBO.XConfig.XConfigTS &&
                        col.ColumnName != DBO.XConfig.Creator &&
                        col.ColumnName != DBO.XConfig.Created &&
                        col.ColumnName != DBO.XConfig.Modifier &&
                        col.ColumnName != DBO.XConfig.Modified)
                    {
                        qry[col.ColumnName] = qryValue[col.ColumnName];
                    }
                }

                qry.Post(DBODef.XConfig.TableDef.Name);

                foreach (DataColumn col in qry.DataTable.Columns)
                {
                    if (col.ColumnName == DBO.XConfig.XConfigID ||
                        col.ColumnName == DBO.XConfig.XConfigTS ||
                        col.ColumnName == DBO.XConfig.Creator ||
                        col.ColumnName == DBO.XConfig.Created ||
                        col.ColumnName == DBO.XConfig.Modifier ||
                        col.ColumnName == DBO.XConfig.Modified)
                    {
                        qryValue[col.ColumnName] = qry[col.ColumnName];
                    }
                }

                qryValue.Row.AcceptChanges();
            }
        }

        private void qryValue_PostCompleted(object sender, EventArgs e)
        {
            // do refresh query to update values
            RefreshValueQuery();
        }

        /// <summary>
        /// Refresh data in value query
        /// </summary>
        private void RefreshValueQuery()
        {
            // refresh query to update shown values
            qryValue.Refresh();

            // set value for amount in tree
            treConfigTree.FocusedNode.SetValue(colTreeAmount.FieldName, qryValue.Count);
        }

        /// <summary>
        /// Remove given config value from cache
        /// </summary>
        private void RemoveConfigFromMemory()
        {
            Session.CacheManager.ConfigValue.RemoveKeyFromMemory(GetCurrentKeyPath());
        }

        /// <summary>
        /// Reset all filters and show complete content in tree
        /// </summary>
        private void ResetAllFilter()
        {
            ResetKeyFilter();
            ResetNamespaceFilter();
        }

        private void ResetDetailDisplay()
        {
            // reset controls
            SetVisibleInputField(null);

            // reset query
            qryValue.DataSet.Clear();
        }

        /// <summary>
        /// Reset key filter
        /// </summary>
        private void ResetKeyFilter()
        {
            edtFilterKey.Text = string.Empty;
        }

        /// <summary>
        /// Reset namespace extension filter
        /// </summary>
        private void ResetNamespaceFilter()
        {
            edtFilterNamespaceExtension.EditValue = Convert.ToInt32(NSESpecialFilter.ShowAll);
        }

        private void SetVisibleInputField(Control ctl)
        {
            edtValueTextEdit.Visible = ctl == edtValueTextEdit;
            edtValueCheckEdit.Visible = ctl == edtValueCheckEdit;
            edtValueMemoEdit.Visible = ctl == edtValueMemoEdit;
            edtValueDateEdit.Visible = ctl == edtValueDateEdit;
            edtValueCalcEdit.Visible = ctl == edtValueCalcEdit;
            edtValueCheckedLookupEdit.Visible = ctl == edtValueCheckedLookupEdit;
            lblValue.Visible = (null != ctl);
        }

        /// <summary>
        /// Show or hide filter panel for tree-filter
        /// </summary>
        private void ShowHideFilter()
        {
            if (chkShowFilter.Checked)
            {
                // show filter
                panBottomTree.Height = panBottomButtons.Height + _panBottomFilterHeight;

                // set focus
                edtFilterKey.Focus();
            }
            else
            {
                // hide filter
                panBottomTree.Height = panBottomButtons.Height;

                // reset filter
                ResetAllFilter();
            }
        }

        private void treConfigTree_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e)
        {
            e.CanFocus = ActiveSQLQuery.Post();
        }

        private void treConfigTree_FilterNode(object sender, FilterNodeEventArgs e)
        {
            // check if filter is active
            if (treConfigTree.FilterConditions.Count > 0)
            {
                // init flag
                bool showNode;
                bool hasFilterKeyPath = false;
                bool hasFilterNSE = false;
                bool showNodeFilterKeyPath = false;
                bool showNodeFilterNSE = false;

                // get current node's values
                string displayPath = GetNodeValue(e.Node, "colDisplayPath", string.Empty);
                string keyPath = GetNodeValue(e.Node, "colKeyPath", string.Empty);
                int namespaceExtensionID = GetNodeValue(e.Node, "FilterNSEID", -1);

                // loop filter criteria
                foreach (FilterCondition filter in treConfigTree.FilterConditions)
                {
                    #region Filter KeyPath

                    // check filters for keyPath
                    if (filter.Column == colKeyPath || filter.Column == colDisplayPath)
                    {
                        // set flag for active filter
                        hasFilterKeyPath = true;

                        var value = Convert.ToString(filter.Value1).ToLower();

                        if (keyPath.ToLower().Contains(value) || displayPath.ToLower().Contains(value))
                        {
                            // show this node for this filter
                            showNodeFilterKeyPath = true;
                        }
                    }

                    #endregion

                    #region Filter NSE

                    // check filter for namespaceExtensionID
                    if (filter.Column == colFilterNSEID)
                    {
                        // set flag for active filter
                        hasFilterNSE = true;

                        // get filter value
                        int filterValue = Convert.ToInt32(filter.Value1);

                        // check filter
                        if (filterValue == Convert.ToInt32(NSESpecialFilter.ShowAll))
                        {
                            // show node anyway
                            showNodeFilterNSE = true;
                        }
                        else if (filterValue == Convert.ToInt32(NSESpecialFilter.ShowWithoutNSE) &&
                                 namespaceExtensionID < 1)
                        {
                            // show node only if no nse is assigned
                            showNodeFilterNSE = true;
                        }
                        else if (filterValue > 0 && namespaceExtensionID == filterValue)
                        {
                            // show node only if nse does exactly match
                            showNodeFilterNSE = true;
                        }
                    }

                    #endregion
                }

                #region Apply FilterFlag

                // set flag
                if (hasFilterKeyPath && hasFilterNSE)
                {
                    // both filter are active
                    showNode = showNodeFilterKeyPath && showNodeFilterNSE;
                }
                else if (hasFilterKeyPath && !hasFilterNSE)
                {
                    // only keypath filter is active
                    showNode = showNodeFilterKeyPath;
                }
                else if (!hasFilterKeyPath && hasFilterNSE)
                {
                    // only nse filter is active
                    showNode = showNodeFilterNSE;
                }
                else
                {
                    // no filter is active, show node anyway
                    showNode = true;
                }

                #endregion

                // apply filter
                e.Node.Visible = showNode;

                if (showNode)
                {
                    // show parent nodes to ensure node is shown, too
                    MakeParentItemsVisible(e.Node.ParentNode);
                }
            }
            else
            {
                // no filter is active
                e.Node.Visible = true;
            }

            // done
            e.Handled = true;
        }

        private void treConfigTree_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            // clear DataBindings of all controls.
            edtValueTextEdit.DataBindings.Clear();
            edtValueCheckEdit.DataBindings.Clear();
            edtValueMemoEdit.DataBindings.Clear();
            edtValueDateEdit.DataBindings.Clear();
            edtValueCalcEdit.DataBindings.Clear();
            edtValueCheckedLookupEdit.DataBindings.Clear();

            // check if focused node exists
            if (treConfigTree.FocusedNode == null)
            {
                // no focused node, show nothing
                ResetDetailDisplay();

                // done
                return;
            }

            // get current selected path
            string keyPath = GetNodeValue(treConfigTree.FocusedNode, "colKeyPath", string.Empty);

            // used LEFT JOIN to have more robust behaviour when XLOV entries are missing.
            qryValue.Fill(qryValue.SelectStatement, keyPath, Session.User.LanguageCode, _enabledText, _disabledText);
            qryValue.Last();

            // validate
            if (qryValue.Row == null)
            {
                // No rows found means this is not an editable field.
                SetVisibleInputField(null);

                // done
                return;
            }

            Control theControl;
            string dbField;

            switch (Convert.ToInt32(qryValue.Row[DBO.XConfig.ValueCode]))
            {
                case 1: // varchar
                    theControl = edtValueTextEdit;
                    dbField = DBO.XConfig.ValueVarchar;
                    break;

                case 2: // int
                    edtValueCalcEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    edtValueCalcEdit.Properties.DisplayFormat.FormatString = "############################"; // looks like max length for CalcEdit
                    edtValueCalcEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    edtValueCalcEdit.Properties.EditFormat.FormatString = "############################"; // looks like max length for CalcEdit
                    theControl = edtValueCalcEdit;
                    dbField = DBO.XConfig.ValueInt;
                    break;

                case 3: // decimal
                    edtValueCalcEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
                    edtValueCalcEdit.Properties.DisplayFormat.FormatString = null;
                    edtValueCalcEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.None;
                    edtValueCalcEdit.Properties.EditFormat.FormatString = null;
                    theControl = edtValueCalcEdit;
                    dbField = DBO.XConfig.ValueDecimal;
                    break;

                case 4: // money
                    // Sequence matters: FormatType MUST be set before FormatString (this is NOT like the code is generated)
                    edtValueCalcEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    edtValueCalcEdit.Properties.DisplayFormat.FormatString = "C";
                    edtValueCalcEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    edtValueCalcEdit.Properties.EditFormat.FormatString = "C";
                    theControl = edtValueCalcEdit;
                    dbField = DBO.XConfig.ValueMoney;
                    break;

                case 5: // bit
                    theControl = edtValueCheckEdit;
                    dbField = DBO.XConfig.ValueBit;
                    break;

                case 6: // datetime
                    theControl = edtValueDateEdit;
                    dbField = DBO.XConfig.ValueDateTime;
                    break;

                case 7: // varchar (multiline)
                    theControl = edtValueMemoEdit;
                    dbField = DBO.XConfig.ValueVarchar;
                    break;

                case 8: // UNCpath
                    treConfigTree.FocusedNode.Tag = ValidateURI(Object2String(qryValue.Row[DBO.XConfig.ValueVarchar]), 8) == 0;
                    goto case 1;

                case 9: // UNCfile
                    treConfigTree.FocusedNode.Tag = ValidateURI(Object2String(qryValue.Row[DBO.XConfig.ValueVarchar]), 9) == 0;
                    goto case 1;

                case 10: // XMLdoc
                    goto case 7;

                case 11:
                    theControl = edtValueCheckedLookupEdit;
                    edtValueCheckedLookupEdit.LOVName = qryValue.Row[DBO.XConfig.LOVName].ToString();
                    dbField = DBO.XConfig.ValueVarchar;
                    break;

                default:
                    throw new Exception(
                        KissMsg.GetMLMessage(
                            CLASSNAME,
                            "UnknownDataTypeInXConfigValueCode",
                            "Unbekannter Datentyp in XConfig.ValueCode: {0}",
                            KissMsgCode.MsgError,
                            qryValue.Row[DBO.XConfig.ValueCode]));
            }

            SetVisibleInputField(theControl);

            string bindingProperty = ((IKissBindableEdit)theControl).GetBindablePropertyName();
            theControl.DataBindings.Add(bindingProperty, qryValue, dbField);

            // refresh databinding in order to apply changes made to datasources
            qryValue.BindControls();
            qryValue.RefreshDisplay();

            if (theControl == edtValueCheckEdit &&
                edtValueCheckEdit.EditValue != null &&
                edtValueCheckEdit.EditValue != DBNull.Value &&
                Convert.ToBoolean(Convert.ToInt32(edtValueCheckEdit.EditValue)) != edtValueCheckEdit.Checked &&
                qryValue.CanUpdate)
            {
                // HACK: display does not match with editvalue
                edtValueCheckEdit.Checked = Convert.ToBoolean(edtValueCheckEdit.EditValue);
            }
        }

        /// <summary>
        /// Verify if a string contains a valid URI. Furthermore if the URI is a file
        /// specification check wether the file or directory are actually accessible.
        /// </summary>
        /// <param name="stringUri">String with URI to be validated</param>
        /// <param name="valueCode">8 for path, 9 for file, other values are ignored and 0 is returned</param>
        /// <returns>0: valid URI (or valueCode not 8 or 9)</returns>
        /// <returns>-1: invalid syntax for URI</returns>
        /// <returns>-2: valid file syntax but specified directory not accessible</returns>
        /// <returns>-3: valid file syntax but specified file not accessible</returns>
        private int ValidateURI(string stringUri, int valueCode)
        {
            // TODO: Method is slow, temporarily disabled by this assignment
            return 0;

            /*
            // Consider empty stringUri OK
            if (string.IsNullOrEmpty(stringUri))
            {
                return 0;
            }

            if (valueCode == 8 || valueCode == 9) // 8: UNCpath, 9: UNCfile
            {
                try
                {
                    // Constructing a URI from input string provides basic syntax check.
                    System.Uri uri = new System.Uri(stringUri);

                    // If it is a file-spec we can test further if the file or directory exists.
                    if (uri.IsFile)
                    {
                        if (valueCode == 8) // UNCpath
                        {
                            if (!System.IO.Directory.Exists(stringUri))
                            {
                                return -2; // Not a readable directory
                            }
                        }
                        else if (valueCode == 9) // UNCfile
                        {
                            if (!System.IO.File.Exists(stringUri))
                            {
                                return -3; // Not a readable file
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return -1; // Invalid syntax
                }
            }

            return 0;
            */
        }
    }
}