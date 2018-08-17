using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Gui.Layout;

namespace KiSS4.Main.ZH
{
    public partial class CtlFallNavigator : KissUserControl
    {
        private bool _doubleClickProtectionActive;

        #region Constructors

        public CtlFallNavigator()
        {
            InitializeComponent();

            btnFallInfo.ImageIndex = KissImageList.GetImageIndex(212); //Index = 212;

            repItemModulIcon.Buttons.Clear();

            treeFallNavigator.SelectImageList = KissImageList.SmallImageList;
            repItemModulIcon.SmallImages = KissImageList.SmallImageList;

            qryModul =
                DBUtil.OpenSQL(
                    @"SELECT IconID = 100 * ModulID + 1000, ShortName FROM XModul WHERE ModulTree = 1 AND ShortName IS NOT NULL ORDER BY SortKey");

            while (qryModul.Count > 0)
            {
                TreeListColumn col = treeFallNavigator.Columns.AddField(qryModul["ShortName"] as string);
                col.ColumnEdit = repItemModulIcon;
                col.OptionsColumn.AllowEdit = false;
                col.Caption = col.FieldName;
                col.VisibleIndex = qryModul.Position + 1;
                col.Width = 24;

                for (int i = (int)qryModul["IconID"]; i % 100 < 10; i++)
                {
                    repItemModulIcon.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", i, KissImageList.GetImageIndex(i)));
                }

                if (!qryModul.Next())
                {
                    break;
                }
            }

            barManager_Tree.Images = KissImageList.SmallImageList;

            colZusatz.VisibleIndex = 100;
            colTeilleistungserbringer.VisibleIndex = 101;

            // append menu to tree
            treeFallNavigator.MenuManager = barManager_Tree;
            barManager_Tree.SetPopupContextMenu(treeFallNavigator, popup_Tree);

            btnNeuerFall.Enabled = DBUtil.UserHasRight("DlgNeuerFall");
        }

        #endregion

        #region EventHandlers

        private void barManager_Tree_QueryShowPopupMenu(object sender, QueryShowPopupMenuEventArgs e)
        {
            foreach (BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                barItemLink.Item.Visibility = BarItemVisibility.Never;
            }

            if (treeFallNavigator.FocusedNode != null && treeFallNavigator.FocusedNode.GetValue("Type").Equals("P") &&
                DBUtil.UserHasRight("DlgFallZuteilung"))
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
            if (treeFallNavigator.FocusedNode != null && treeFallNavigator.FocusedNode.GetValue("Type").Equals("P"))
            {
                try
                {
                    DBUtil.ThrowExceptionOnOpenTransaction();
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError(ex.Message);
                }

                FormController.OpenForm(
                    "FrmFall",
                    @"Action",
                    "ShowFall",
                    "BaPersonID",
                    (int)treeFallNavigator.FocusedNode.GetValue("BaPersonID"),
                    //		"FaFallID", (int)treeFallNavigator.FocusedNode.GetValue("FaFallID"),
                    "ModulCode",
                    ModulID.B);
            }
        }

        private void btnFallInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int baPersonID = (int)treeFallNavigator.FocusedNode.GetValue("BaPersonID");
                FormController.ShowDialogOnMain("DlgFallZuteilung", baPersonID);
            }
            catch
            {
            }
        }

        private void btnNeuerFall_Click(object sender, EventArgs e)
        {
            try
            {
                DBUtil.ThrowExceptionOnOpenTransaction();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }

            DlgNeuerFall dlg = new DlgNeuerFall();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int baPersonID = dlg.BaPersonID;

                PopulateTreeView(baPersonID.ToString(), "BaPersonID");

                // refresh tree
                FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            }
        }

        private void CtlFallNavigator_Load(object sender, EventArgs e)
        {
            try
            {
                DBUtil.ThrowExceptionOnOpenTransaction();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }

            PopulateTreeView("E" + Session.User.UserID.ToString(), "ID");
        }

        private void CtlFallNavigator_RefreshData(object sender, EventArgs e)
        {
            treeFallNavigator.SaveState();
            PopulateTreeView("E" + Session.User.UserID.ToString(), "ID");
            treeFallNavigator.LoadState();
        }

        private void editCheckbox_Click(object sender, EventArgs e)
        {
            PopulateTreeView("E" + Session.User.UserID.ToString(), "ID");
        }

        private void treeFallNavigator_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.Column == colZusatz)
            {
                if (e.CellText != null && e.CellText.EndsWith("x"))
                {
                    e.Appearance.ForeColor = Color.Gray;
                }
            }
        }

        private void treeFallNavigator_KeyDown(object sender, KeyEventArgs e)
        {
            //DB-Lock Prävention!!
            try
            {
                DBUtil.ThrowExceptionOnOpenTransaction();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }

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
                        FormController.OpenForm(
                            "FrmFall",
                            @"Action",
                            "ShowFall",
                            "BaPersonID",
                            (int)treeFallNavigator.FocusedNode.GetValue("BaPersonID"),
                            //					"FaFallID", (int)treeFallNavigator.FocusedNode.GetValue("FaFallID"),
                            "ModulID",
                            ((int)val - 1000) / 100);
                    }
                }
            }
        }

        private void treeFallNavigator_MouseUp(object sender, MouseEventArgs e)
        {
            if (_doubleClickProtectionActive)
            {
                //prevent double click
                return;
            }

            try
            {
                _doubleClickProtectionActive = true;

                try
                {
                    DBUtil.ThrowExceptionOnOpenTransaction();
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError(ex.Message);
                }

                if (e.Button != MouseButtons.Left)
                    return;
                TreeListHitInfo hi = treeFallNavigator.CalcHitInfo(new Point(e.X, e.Y));
                if (hi.HitInfoType != HitInfoType.Cell)
                    return;

                if (treeFallNavigator.FocusedNode.GetValue("Type").Equals("P")
                    && hi.Column.ColumnEdit == repItemModulIcon)
                {
                    // check if icon is marked as disabled to open Fall
                    object val = treeFallNavigator.FocusedNode.GetValue(treeFallNavigator.FocusedColumn);

                    if (val is int && (int)val % 10 > 0)
                    {
                        FormController.OpenForm(
                            "FrmFall",
                            @"Action",
                            "ShowFall",
                            "BaPersonID",
                            (int)treeFallNavigator.FocusedNode.GetValue("BaPersonID"),
                            //				"FaFallID", (int)treeFallNavigator.FocusedNode.GetValue("FaFallID"),
                            "ModulID",
                            ((int)val - 1000) / 100);
                    }
                }
            }
            finally
            {
                _doubleClickProtectionActive = false;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

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
                case "RefreshTree":
                    CtlFallNavigator_RefreshData(null, null);

                    return true;
            }
            // did not understand message
            return ReceiveMessage(param);
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
                        dic["FaFallID"] = treeFallNavigator.FocusedNode.GetValue("FaFallID");
                        dic["BaPersonID"] = treeFallNavigator.FocusedNode.GetValue("BaPersonID");
                        return dic;
                    }
                    catch
                    {
                    }
                    return null;

                /*
            // Bis jetzt brauchen  wir keine Rückmeldungen:
                case "CurrentModulTree":
                    // get current modul tree
                    return GetCurrentModulTree();

            */
            }

            // did not understand message
            return base.ReturnMessage(param);
        }

        #endregion

        #region Protected Methods

        protected override void OnGettingLayout(KissLayoutEventArgs e)
        {
            base.OnGettingLayout(e);

            KissControlLayout.SaveSimpleProperty(e, editAktive, "Checked");
            KissControlLayout.SaveSimpleProperty(e, editAbgeschlossene, "Checked");
            KissControlLayout.SaveSimpleProperty(e, editArchivierte, "Checked");

            KissControlLayout.SaveSimpleProperty(e, editGruppe, "Checked");
            KissControlLayout.SaveSimpleProperty(e, editGastrecht, "Checked");

            KissControlLayout cl12 = new KissControlLayout(colZusatz.Name);
            e.Layout.ControlLayouts.Add(cl12);
            SimpleProperty p12 = new SimpleProperty("Width", colZusatz.Width);
            try
            {
                cl12.Properties.Add(p12);
            }
            catch (Exception ex)
            {
                e.Errors.Add(new LayoutError(p12, ex));
            }
        }

        protected override void OnSettingLayout(KissLayoutEventArgs e)
        {
            base.OnSettingLayout(e);

            KissControlLayout cl1;
            KissControlLayout cl2;
            KissControlLayout cl3;
            KissControlLayout cl4;
            KissControlLayout cl5;
            KissControlLayout cl12;

            try
            {
                cl1 = e.Layout.ControlLayouts[editAktive.Name];
            }
            catch
            {
                cl1 = null;
            }
            try
            {
                cl2 = e.Layout.ControlLayouts[editAbgeschlossene.Name];
            }
            catch
            {
                cl2 = null;
            }
            try
            {
                cl3 = e.Layout.ControlLayouts[editArchivierte.Name];
            }
            catch
            {
                cl3 = null;
            }
            try
            {
                cl4 = e.Layout.ControlLayouts[editGruppe.Name];
            }
            catch
            {
                cl4 = null;
            }
            try
            {
                cl5 = e.Layout.ControlLayouts[editGastrecht.Name];
            }
            catch
            {
                cl5 = null;
            }
            try
            {
                cl12 = e.Layout.ControlLayouts[colZusatz.Name];
            }
            catch
            {
                cl12 = null;
            }

            if (cl1 != null)
            {
                try
                {
                    SimpleProperty p1 = (SimpleProperty)cl1.Properties["Checked"];
                    try
                    {
                        editAktive.Checked = (bool)p1.Value;
                    }
                    catch (Exception ex)
                    {
                        e.Errors.Add(new LayoutError(p1, ex));
                    }
                }
                catch
                {
                }
            }

            if (cl2 != null)
            {
                try
                {
                    SimpleProperty p2 = (SimpleProperty)cl2.Properties["Checked"];
                    try
                    {
                        editAbgeschlossene.Checked = (bool)p2.Value;
                    }
                    catch (Exception ex)
                    {
                        e.Errors.Add(new LayoutError(p2, ex));
                    }
                }
                catch
                {
                }
            }

            if (cl3 != null)
            {
                try
                {
                    SimpleProperty p3 = (SimpleProperty)cl3.Properties["Checked"];
                    try
                    {
                        editArchivierte.Checked = (bool)p3.Value;
                    }
                    catch (Exception ex)
                    {
                        e.Errors.Add(new LayoutError(p3, ex));
                    }
                }
                catch
                {
                }
            }

            if (cl4 != null)
            {
                try
                {
                    SimpleProperty p4 = (SimpleProperty)cl4.Properties["Checked"];
                    try
                    {
                        editGruppe.Checked = (bool)p4.Value;
                    }
                    catch (Exception ex)
                    {
                        e.Errors.Add(new LayoutError(p4, ex));
                    }
                }
                catch
                {
                }
            }

            if (cl5 != null)
            {
                try
                {
                    SimpleProperty p5 = (SimpleProperty)cl5.Properties["Checked"];
                    try
                    {
                        editGastrecht.Checked = (bool)p5.Value;
                    }
                    catch (Exception ex)
                    {
                        e.Errors.Add(new LayoutError(p5, ex));
                    }
                }
                catch
                {
                }
            }

            if (cl12 != null)
            {
                try
                {
                    SimpleProperty p12 = (SimpleProperty)cl12.Properties["Width"];
                    try
                    {
                        colZusatz.Width = (int)p12.Value;
                    }
                    catch (Exception ex)
                    {
                        e.Errors.Add(new LayoutError(p12, ex));
                    }
                }
                catch
                {
                }
            }
        }

        #endregion

        #region Private Methods

        private void PopulateTreeView(string searchValue, string searchFieldName)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            treeFallNavigator.DataSource = null;

            SqlQuery qry = DBUtil.OpenSQL(
                "EXECUTE spFaGetTreeFallNavigator {0}, {1}, {2}, {3}, {4}, {5}",
                Session.User.UserID,
                editAktive.Checked,
                editAbgeschlossene.Checked,
                editArchivierte.Checked,
                editGruppe.Checked,
                editGastrecht.Checked);

            foreach (System.Data.DataRow row in qry.DataTable.Rows)
            {
                row["IconID"] = KissImageList.GetImageIndex((int)row["IconID"]);
            }

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

            lblAnzahlPersonen.Text = KissMsg.GetMLMessage(
                "FrmFallNavigator", "AnzahlPersonen", "Anzahl Personen: {0}", KissMsgCode.Text, qry.Count == 0 ? "0" : qry["PersonCount"].ToString());

            treeFallNavigator.BeginSort();
            treeFallNavigator.EndSort();

            repItemModulIcon.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;

            Cursor.Current = currentCursor;
        }

        #endregion

        #endregion
    }
}