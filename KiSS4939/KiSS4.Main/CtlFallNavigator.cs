using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraBars;

using DevExpress.XtraEditors.Controls;

using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Gui.Layout;

namespace KiSS4.Main
{
    public partial class CtlFallNavigator : KissUserControl
    {
        #region Fields

        #region Private Fields

        private const string CLASSNAME = "CtlFallNavigator";

        ///<Summary>
        /// The tree lock ensures that only one instance of a tab is created.
        /// While the solution is an ugly hack it actually works :-)
        ///</Summary>
        private bool _treeLock;

        private string KEY_PATH_KATEGORISIERUNG = @"System\Fallfuehrung\Kategorisierung";

        #endregion

        #endregion

        #region Constructors

        public CtlFallNavigator()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void barManager_Tree_QueryShowPopupMenu(object sender, QueryShowPopupMenuEventArgs e)
        {
            foreach (BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                barItemLink.Item.Visibility = BarItemVisibility.Never;
            }

            if (treeFallNavigator.FocusedNode != null && treeFallNavigator.FocusedNode.GetValue("Type").Equals("P") && DBUtil.UserHasRight("FrmFallInfo"))
            {
                btnFallInfo.Visibility = BarItemVisibility.Always;
            }

            foreach (BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                if (barItemLink.Item.Visibility != BarItemVisibility.Never)
                {
                    return;
                }
            }

            e.Cancel = true;
        }

        private void btnFall_Click(object sender, EventArgs e)
        {
            OpenPersonModule();
        }

        private void btnFallInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            int baPersonID = 0;

            try
            {
                baPersonID = (int)treeFallNavigator.FocusedNode.GetValue("BaPersonID");
            }
            catch
            {
            }

            FormController.ShowDialogOnMain("FrmFallInfo", baPersonID, true);
        }

        private void btnNeuerFall_Click(object sender, EventArgs e)
        {
            NeuerFall();
        }

        private void CtlFallNavigator_Load(object sender, EventArgs e)
        {
            ShowHideKategorie();

            barManager_Tree.SetPopupContextMenu(treeFallNavigator, popup_Tree);

            treeFallNavigator.SelectImageList = KissImageList.SmallImageList;
            repItemModulIcon.SmallImages = KissImageList.SmallImageList;

            qryModul.Fill();

            while (qryModul.Count > 0)
            {
                TreeListColumn col = treeFallNavigator.Columns.AddField(qryModul["ShortName"] as string);
                col.ColumnEdit = repItemModulIcon;
                col.Caption = col.FieldName;
                col.VisibleIndex = qryModul.Position + 1;
                if (col.Caption.Length == 3)
                {
                    col.Width = 36;
                }
                else
                {
                    col.Width = 24;
                }

                for (int i = (int)qryModul["IconID"]; i % 100 < 10; i++)
                {
                    repItemModulIcon.Items.Add(new ImageComboBoxItem("", i, KissImageList.GetImageIndex(i)));
                }

                if (!qryModul.Next())
                {
                    break;
                }
            }

            barManager_Tree.Images = KissImageList.SmallImageList;

            PopulateTreeView("E" + Session.User.UserID.ToString(), "ID");
        }

        private void edtAHVNummer_CheckedChanged(object sender, EventArgs e)
        {
            if (edtAHVNummer.Checked)
            {
                colAHVNummer.VisibleIndex = qryModul.Count + 1;
            }
            else
            {
                colAHVNummer.VisibleIndex = -1;
            }
        }

        private void edtCheckbox_Click(object sender, EventArgs e)
        {
            PopulateTreeView("E" + Session.User.UserID.ToString(), "ID");
        }

        private void edtGemeinde_CheckedChanged(object sender, EventArgs e)
        {
            if (edtGemeinde.Checked)
            {
                colGemeinde.VisibleIndex = qryModul.Count + 4;
            }
            else
            {
                colGemeinde.VisibleIndex = -1;
            }
        }

        private void edtKategorie_CheckedChanged(object sender, EventArgs e)
        {
            if (edtKategorie.Checked)
            {
                colKategorie.VisibleIndex = qryModul.Count + 6;
            }
            else
            {
                colKategorie.VisibleIndex = -1;
            }
        }

        private void edtNNummer_CheckedChanged(object sender, EventArgs e)
        {
            if (edtNNummer.Checked)
            {
                colNNummer.VisibleIndex = qryModul.Count + 2;
            }
            else
            {
                colNNummer.VisibleIndex = -1;
            }
        }

        private void edtPendenzen_CheckedChanged(object sender, EventArgs e)
        {
            if (edtPendenzen.Checked)
            {
                colPendenzen.VisibleIndex = qryModul.Count + 7;
            }
            else
            {
                colPendenzen.VisibleIndex = -1;
            }
        }

        private void edtVersNr_CheckedChanged(object sender, EventArgs e)
        {
            if (edtVersNr.Checked)
            {
                colVersNr.VisibleIndex = qryModul.Count + 5;
            }
            else
            {
                colVersNr.VisibleIndex = -1;
            }
        }

        private void edtZusatz_CheckedChanged(object sender, EventArgs e)
        {
            if (edtZusatz.Checked)
            {
                colZusatz.VisibleIndex = qryModul.Count + 3;
            }
            else
            {
                colZusatz.VisibleIndex = -1;
            }
        }

        private void FrmFallNavigator_RefreshData(object sender, EventArgs e)
        {
            treeFallNavigator.SaveState();
            PopulateTreeView("E" + Session.User.UserID.ToString(), "ID");
            treeFallNavigator.LoadState();
        }

        private void treeFallNavigator_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.Column == colKategorie)
            {
                if (e.Node[colFarbe].ToString() != String.Empty)
                {
                    try
                    {
                        e.Appearance.BackColor =
                            Color.FromArgb(int.Parse("FF" + e.Node[colFarbe].ToString().Substring(2), NumberStyles.HexNumber));
                        e.Appearance.ForeColor = Color.Black;
                        e.Column.ColumnEdit.Appearance.ForeColor = Color.Black;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void treeFallNavigator_DoubleClick(object sender, EventArgs e)
        {
            OpenPersonModule();
        }

        private void treeFallNavigator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt && treeFallNavigator.FocusedNode.GetValue("Type").Equals("P"))
            {
                SqlQuery qryTree = treeFallNavigator.DataSource as SqlQuery;

                if (qryTree != null && qryTree.DataTable.Columns.Contains(e.KeyCode.ToString()))
                {
                    e.Handled = true;

                    // check if icon is marked as disabled to open Fall
                    object val = treeFallNavigator.FocusedNode.GetValue(e.KeyCode.ToString());

                    if (val is int && (int)val % 10 > 0)
                    {
                        FormController.OpenForm("FrmFall", "Action", "ShowFall",
                            "BaPersonID", (int)treeFallNavigator.FocusedNode.GetValue("BaPersonID"),
                            "ModulID", ((int)val - 1000) / 100);
                    }
                }
            }
        }

        private void treeFallNavigator_MouseMove(object sender, MouseEventArgs e)
        {
            if (_treeLock)
            {
                // do nothing
                return;
            }

            // get information about point where mouse was clicked
            TreeListHitInfo hi = treeFallNavigator.CalcHitInfo(new Point(e.X, e.Y));

            // check if mouse was clicked above cell
            if (hi == null ||
                hi.HitInfoType != HitInfoType.Cell ||
                hi.Node == null ||
                hi.Column == null ||
                hi.Column.ColumnEdit == null)
            {
                // default cursor
                treeFallNavigator.Cursor = Cursors.Default;
                return;
            }

            // get hitinfo values
            object nodeType = hi.Node.GetValue("Type");

            // check if mouse was clicked above modul-icon
            if (nodeType != null && nodeType.Equals("P") && (hi.Column.ColumnEdit == repItemModulIcon || hi.Column.ColumnEdit == repositoryItemTextEdit1))
            {
                // check if icon is marked as disabled to open item
                object nodeValue = hi.Node.GetValue(hi.Column);

                if ((nodeValue is int && Convert.ToInt32(nodeValue) % 10 > 0) || hi.Column.Caption.Equals(colKategorie.Caption))
                {
                    // over modul icon
                    treeFallNavigator.Cursor = Cursors.Hand;
                    return;
                }
            }

            // default cursor
            treeFallNavigator.Cursor = Cursors.Default;
        }

        private void treeFallNavigator_MouseUp(object sender, MouseEventArgs e)
        {
            // --- Bail out if not left mouse button
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            try
            {
                // --- check if tree is locked
                if (_treeLock)
                {
                    return;
                }
                else
                {
                    _treeLock = true;
                }

                TreeListHitInfo hi = treeFallNavigator.CalcHitInfo(new Point(e.X, e.Y));

                if (hi.HitInfoType != HitInfoType.Cell)
                {
                    return;
                }

                if (treeFallNavigator.FocusedNode.GetValue("Type").Equals("P")
                    && (hi.Column.ColumnEdit == repItemModulIcon || hi.Column.ColumnEdit == repositoryItemTextEdit1))
                {
                    if (treeFallNavigator.FocusedColumn.Caption.Equals(colKategorie.Caption))
                    {
                        var key = treeFallNavigator.FocusedNode.GetValue("FaLeistungID");
                        FormController.OpenForm("FrmFall", "Action", "JumpToPath",
                             "BaPersonID", treeFallNavigator.FocusedNode.GetValue("BaPersonID"),
                             "ModulID", 2,
                             "TreeNodeID", string.Format("CtlFaBeratungsperiode{0}/Kiss.UserInterface.View.Fa.FaKategorisierungView,Kiss.UserInterface.View", key));
                    }
                    else
                    {
                        // check if icon is marked as disabled to open Fall
                        object val = treeFallNavigator.FocusedNode.GetValue(treeFallNavigator.FocusedColumn);

                        if (val is int && Convert.ToInt32(val) % 10 > 0)
                        {
                            FormController.OpenForm(
                                "FrmFall",
                                "Action",
                                "ShowFall",
                                "BaPersonID",
                                Convert.ToInt32(treeFallNavigator.FocusedNode.GetValue("BaPersonID")),
                                "ModulID",
                                (Convert.ToInt32(val) - 1000) / 100);
                        }
                    }
                }
                if (treeFallNavigator.FocusedNode.GetValue("Type").Equals("P") && treeFallNavigator.FocusedColumn.Caption.Equals(colPendenzen.Caption))
                {
                    if (treeFallNavigator.FocusedNode.GetValue("FallTaskCount").ToString() != string.Empty)
                    {
                        FormController.OpenForm(
                            "FrmFall",
                            "Action",
                            "JumpToPath",
                            "BaPersonID", Convert.ToInt32(treeFallNavigator.FocusedNode.GetValue("BaPersonID")),
                            "ModulID", ModulID.F,
                            "TreeNodeID", "CtlPendenzenVerwaltung/CtlPendenzenVerwaltungFaellige");
                    }
                }
            }
            finally
            {
                _treeLock = false;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            switch (parameters["Action"] as string)
            {
                case "RefreshTree":
                    PopulateTreeView("E" + Session.User.UserID.ToString(), "ID");
                    return true;
            }
            return base.ReceiveMessage(parameters);
        }

        public override object ReturnMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param.Count < 1)
            {
                // by default, nothing to do
                return null;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "GetJumpToPath":
                    try
                    {
                        System.Collections.Specialized.HybridDictionary dic = new System.Collections.Specialized.HybridDictionary();

                        dic["ClassName"] = "FrmFall";
                        dic["FaFallID"] = -1;           // reset and ignore
                        dic["BaPersonID"] = treeFallNavigator.FocusedNode.GetValue("BaPersonID");

                        return dic;
                    }
                    catch { }
                    return null;
            }

            // did not understand message
            return base.ReturnMessage(param);
        }

        #endregion

        #region Protected Methods

        protected virtual void NeuerFall()
        {
            DlgNeuerFall dlg = new DlgNeuerFall();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int baPersonID = dlg.NewBaPersonID;

                PopulateTreeView(baPersonID.ToString(), "BaPersonID");

                //Refresh tree
                FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            }
        }

        protected override void OnGettingLayout(KissLayoutEventArgs e)
        {
            base.OnGettingLayout(e);

            KissControlLayout.SaveSimpleProperty(e, colName.Name, colName, "Width");

            KissControlLayout.SaveSimpleProperty(e, edtAktive, "Checked");
            KissControlLayout.SaveSimpleProperty(e, edtAbgeschlossene, "Checked");
            KissControlLayout.SaveSimpleProperty(e, edtArchivierte, "Checked");

            KissControlLayout.SaveSimpleProperty(e, edtGruppe, "Checked");
            KissControlLayout.SaveSimpleProperty(e, edtGastrecht, "Checked");

            KissControlLayout.SaveSimpleProperty(e, edtAHVNummer, "Checked");
            KissControlLayout.SaveSimpleProperty(e, edtNNummer, "Checked");
            KissControlLayout.SaveSimpleProperty(e, edtZusatz, "Checked");
            KissControlLayout.SaveSimpleProperty(e, edtGemeinde, "Checked");
            KissControlLayout.SaveSimpleProperty(e, edtVersNr, "Checked");
            KissControlLayout.SaveSimpleProperty(e, edtKategorie, "Checked");

            KissControlLayout.SaveSimpleProperty(e, colAHVNummer.Name, colAHVNummer, "Width");
            KissControlLayout.SaveSimpleProperty(e, colNNummer.Name, colNNummer, "Width");
            KissControlLayout.SaveSimpleProperty(e, colZusatz.Name, colZusatz, "Width");
            KissControlLayout.SaveSimpleProperty(e, colGemeinde.Name, colGemeinde, "Width");
            KissControlLayout.SaveSimpleProperty(e, colVersNr.Name, colVersNr, "Width");
            KissControlLayout.SaveSimpleProperty(e, colKategorie.Name, colKategorie, "Width");
            KissControlLayout.SaveSimpleProperty(e, colPendenzen.Name, colPendenzen, "Width");
        }

        protected override void OnSettingLayout(KissLayoutEventArgs e)
        {
            base.OnSettingLayout(e);

            KissControlLayout.ReadSimpleProperty(e, colName.Name, colName, "Width");

            KissControlLayout.ReadSimpleProperty(e, edtAktive, "Checked");
            KissControlLayout.ReadSimpleProperty(e, edtAbgeschlossene, "Checked");
            KissControlLayout.ReadSimpleProperty(e, edtArchivierte, "Checked");

            KissControlLayout.ReadSimpleProperty(e, edtGruppe, "Checked");
            KissControlLayout.ReadSimpleProperty(e, edtGastrecht, "Checked");

            KissControlLayout.ReadSimpleProperty(e, edtAHVNummer, "Checked");
            KissControlLayout.ReadSimpleProperty(e, edtNNummer, "Checked");
            KissControlLayout.ReadSimpleProperty(e, edtZusatz, "Checked");
            KissControlLayout.ReadSimpleProperty(e, edtGemeinde, "Checked");
            KissControlLayout.ReadSimpleProperty(e, edtVersNr, "Checked");
            KissControlLayout.ReadSimpleProperty(e, edtKategorie, "Checked");

            KissControlLayout.ReadSimpleProperty(e, colAHVNummer.Name, colAHVNummer, "Width");
            KissControlLayout.ReadSimpleProperty(e, colNNummer.Name, colNNummer, "Width");
            KissControlLayout.ReadSimpleProperty(e, colZusatz.Name, colZusatz, "Width");
            KissControlLayout.ReadSimpleProperty(e, colGemeinde.Name, colGemeinde, "Width");
            KissControlLayout.ReadSimpleProperty(e, colVersNr.Name, colVersNr, "Width");
            KissControlLayout.ReadSimpleProperty(e, colKategorie.Name, colKategorie, "Width");
        }

        protected void PopulateTreeView(string searchValue, string searchFieldName)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            treeFallNavigator.DataSource = null;

            SqlQuery qry = DBUtil.OpenSQL(
                "EXECUTE spFaGetTreeFallNavigator {0}, {1}, {2}, {3}, {4}, {5}, {6}",
                Session.User.UserID,
                edtAktive.Checked,
                edtAbgeschlossene.Checked,
                edtArchivierte.Checked,
                edtGruppe.Checked,
                edtGastrecht.Checked,
                edtPendenzen.Checked);

            foreach (System.Data.DataRow row in qry.DataTable.Rows)
                row["IconID"] = KissImageList.GetImageIndex((int)row["IconID"]);

            treeFallNavigator.DataSource = qry;
            treeFallNavigator.CollapseAll();

            //refresh Navigator und Neupositionierung auf neuen Fall
            if (!DBUtil.IsEmpty(searchValue) && !DBUtil.IsEmpty(searchFieldName))
            {
                TreeListNode node = DBUtil.FindNodeByValue(treeFallNavigator.Nodes, searchValue, searchFieldName);

                if (node != null)
                {
                    treeFallNavigator.FocusedNode = node;
                    node.Expanded = true;
                }
            }
            else
            {
                treeFallNavigator.MoveFirst();
            }

            RefreshAnzahlLabels();

            treeFallNavigator.BeginSort();
            treeFallNavigator.EndSort();

            Cursor.Current = currentCursor;
        }

        #endregion

        #region Private Methods

        public override void Translate()
        {
            base.Translate();
            RefreshAnzahlLabels();
        }

        private void OpenPersonModule()
        {
            if (treeFallNavigator.FocusedNode != null
                && treeFallNavigator.FocusedNode.GetValue("Type").Equals("P"))
            {
                FormController.OpenForm("FrmFall", "Action", "ShowFall",
                                        "BaPersonID", Convert.ToInt32(treeFallNavigator.FocusedNode.GetValue("BaPersonID")),
                                        "ModulID", ModulID.B);
            }
        }

        private void RefreshAnzahlLabels()
        {
            var qry = (SqlQuery)treeFallNavigator.DataSource;

            lblAnzahlPersonen.Text = KissMsg.GetMLMessage(CLASSNAME, "AnzahlPersonen", "Anzahl Personen: {0}", KissMsgCode.Text, qry.Count == 0 ? "0" : qry["PersonCount"].ToString());
            lblAnzahlPendenzen.Text = KissMsg.GetMLMessage(CLASSNAME, "AnzahlPendenzen", "Sie haben {0} fällige Pendenzen.", KissMsgCode.Text, qry.Count == 0 ? "0" : qry["TaskCount"].ToString());
        }

        private void ShowHideKategorie()
        {
            edtKategorie.Visible = DBUtil.GetConfigBool(KEY_PATH_KATEGORISIERUNG, false);

            //sicherstellen, dass wenn edtKategorie nicht sichtbar ist, dass die Spalte auch zwingend nicht sichtbar ist
            if (!edtKategorie.Visible)
            {
                edtKategorie.Checked = false;
            }
        }

        #endregion

        private void btnGotoPendenzen_Click(object sender, EventArgs e)
        {
            FormController.OpenForm(
                "FrmPendenzenVerwaltung",
                "Action",
                "OpenLink",
                "LinkName",
                "itmMeineFaellig");
        }

        #endregion
    }
}