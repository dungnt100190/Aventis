using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Gui.Layout;

namespace KiSS4.Main.PI
{
    public partial class CtlFallNavigator : KissUserControl
    {
        #region Fields

        #region Private Fields

        private bool _isLoading = true;

        #endregion

        #endregion

        #region Constructors

        public CtlFallNavigator()
        {
            InitializeComponent();

            // create intances
            barDockControlTop = new BarDockControl();
            barDockControlBottom = new BarDockControl();
            barDockControlLeft = new BarDockControl();
            barDockControlRight = new BarDockControl();
            barManager_Tree = new BarManager(components);
            popup_Tree = new PopupMenu(components);

            // begin Init
            ((System.ComponentModel.ISupportInitialize)(barManager_Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(popup_Tree)).BeginInit();

            //
            // barManager_Tree
            //
            barManager_Tree.DockControls.Add(barDockControlTop);
            barManager_Tree.DockControls.Add(barDockControlBottom);
            barManager_Tree.DockControls.Add(barDockControlLeft);
            barManager_Tree.DockControls.Add(barDockControlRight);
            barManager_Tree.Form = this;
            barManager_Tree.Items.AddRange(new BarItem[] { btnFallInfo });
            barManager_Tree.MaxItemId = 2;
            barManager_Tree.QueryShowPopupMenu += barManager_Tree_QueryShowPopupMenu;
            //
            // popup_Tree
            //
            popup_Tree.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new LinkPersistInfo(btnFallInfo) });
            popup_Tree.Manager = barManager_Tree;
            popup_Tree.Name = "popup_Tree";
            //
            // btnFallInfo
            //
            btnFallInfo.Id = 1;
            btnFallInfo.ImageIndex = KissImageList.GetImageIndex(162); // set here the KiSS-IconID

            // end Init
            ((System.ComponentModel.ISupportInitialize)(barManager_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(popup_Tree)).EndInit();

            // setup image lists
            treFallNavigator.SelectImageList = KissImageList.SmallImageList;
            repModulIcon.SmallImages = KissImageList.SmallImageList;
            barManager_Tree.Images = KissImageList.SmallImageList;

            // convert and add icons
            qryModul.Fill(@"
                SELECT IconID = 100 * ModulID + 1000,
                       ShortName
                FROM dbo.XModul WITH (READUNCOMMITTED)
                WHERE ModulTree = 1
                  AND ShortName IS NOT NULL;");

            // convert all icons
            while (qryModul.Count > 0)
            {
                for (int i = (int)qryModul["IconID"]; i % 100 < 10; i++)
                {
                    repModulIcon.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", i, KissImageList.GetImageIndex(i)));
                }

                if (!qryModul.Next())
                {
                    break;
                }
            }

            // setup picXY
            picFV.Image = KissImageList.GetSmallImage(1201);
            picSB.Image = KissImageList.GetSmallImage(1301);
            picCM.Image = KissImageList.GetSmallImage(1401);
            picBW.Image = KissImageList.GetSmallImage(1501);
            picED.Image = KissImageList.GetSmallImage(1601);
            picIN.Image = KissImageList.GetSmallImage(1701);
            picAB.Image = KissImageList.GetSmallImage(1801);
            picWD.Image = KissImageList.GetSmallImage(4101);

            // append menu to tree
            treFallNavigator.MenuManager = barManager_Tree;
            barManager_Tree.SetPopupContextMenu(treFallNavigator, popup_Tree);
        }

        #endregion

        #region EventHandlers

        private void barManager_Tree_QueryShowPopupMenu(object sender, QueryShowPopupMenuEventArgs e)
        {
            // loop and set all items to invisible
            foreach (BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                barItemLink.Item.Visibility = BarItemVisibility.Never;
            }

            // FallInfo - set only visible if certain circumstances are granted
            if (treFallNavigator.FocusedNode != null && treFallNavigator.FocusedNode.GetValue("Type").Equals("P") &&
                DBUtil.UserHasRight("DlgFallInfo"))
            {
                // case information
                btnFallInfo.Visibility = BarItemVisibility.Always;
            }

            // loop all items and check if any item is visible
            foreach (BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                if (barItemLink.Item.Visibility != BarItemVisibility.Never)
                {
                    // at least one item is visible, so let the menu pop up
                    return;
                }
            }

            // otherwise, cancel pop up
            e.Cancel = true;
        }

        private void btnFall_Click(object sender, EventArgs e)
        {
            OpenPersonModule();
        }

        private void btnFallInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // try to get id of person
                int baPersonID = Convert.ToInt32(treFallNavigator.FocusedNode.GetValue("BaPersonID"));

                // validate id
                if (baPersonID < 1)
                {
                    // invalid id, prevent showing dialog
                    throw new ArgumentOutOfRangeException("baPersonID", "Invalid BaPersonID, cannot show case information for this id.");
                }

                // open dialog if possible
                FormController.ShowDialogOnMain("DlgFallInfo", baPersonID);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorShowingCaseInformation", "Es ist ein Fehler beim Anzeigen der Fall-Informationen aufgetreten.", ex);
            }
        }

        private void btnNeuerFall_Click(object sender, EventArgs e)
        {
            // create new dialog
            DlgNeuerFall dlg = new DlgNeuerFall();

            // fill default values for new search
            if (treFallNavigator.DataSource != null && treFallNavigator.FocusedNode != null && !DBUtil.IsEmpty(treFallNavigator.FocusedNode.GetValue("BaPersonID")))
            {
                // request data
                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT Name, Vorname, WohnsitzPLZ, WohnsitzOrt
                    FROM dbo.vwPerson WITH (READUNCOMMITTED)
                    WHERE BaPersonID = {0};",
                    treFallNavigator.FocusedNode.GetValue("BaPersonID"));

                // fill data
                if (qry.Count > 0)
                {
                    // get values
                    String lastName = Convert.ToString(qry["Name"]);
                    String firstName = Convert.ToString(qry["Vorname"]);
                    String plzWohnsitz = Convert.ToString(qry["WohnsitzPLZ"]);
                    String ortWohnsitz = Convert.ToString(qry["WohnsitzOrt"]);

                    // init first search
                    dlg.SetupSearch(lastName, firstName, plzWohnsitz, ortWohnsitz);
                }
            }

            // show dialog
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // get new id
                Int32 baPersonID = dlg.NewBaPersonID;

                // create treeview
                PopulateTreeView(baPersonID.ToString(), "BaPersonID");

                // refresh tree
                FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            }
        }

        private void Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            // refresh tree with new settings
            PopulateTreeView("E" + Session.User.UserID, "ID");
        }

        private void CtlFallNavigator_Load(object sender, EventArgs e)
        {
            // set finished loading
            _isLoading = false;

            // load data from database
            PopulateTreeView("E" + Session.User.UserID, "ID");
        }

        private void CtlFallNavigator_RefreshData(object sender, EventArgs e)
        {
            // get current state
            treFallNavigator.SaveState();

            // refresh data
            PopulateTreeView("E" + Session.User.UserID, "ID");

            // reapply current state
            treFallNavigator.LoadState();
        }

        private void treFallNavigator_DoubleClick(object sender, EventArgs e)
        {
            OpenPersonModule();
        }

        private void treFallNavigator_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isLoading)
            {
                // do nothing
                return;
            }

            // get information about point where mouse was clicked
            TreeListHitInfo hi = treFallNavigator.CalcHitInfo(new Point(e.X, e.Y));

            // check if mouse was clicked above cell
            if (hi == null ||
                hi.HitInfoType != HitInfoType.Cell ||
                hi.Node == null ||
                hi.Column == null ||
                hi.Column.ColumnEdit == null)
            {
                // default cursor
                treFallNavigator.Cursor = Cursors.Default;
                return;
            }

            // get hitinfo values
            object nodeType = hi.Node.GetValue("Type");

            // check if mouse was clicked above modul-icon
            if (nodeType != null && nodeType.Equals("P") && hi.Column.ColumnEdit == repModulIcon)
            {
                // check if icon is marked as disabled to open item
                object nodeValue = hi.Node.GetValue(hi.Column);

                if (nodeValue is int && Convert.ToInt32(nodeValue) % 10 > 0)
                {
                    // over modul icon
                    treFallNavigator.Cursor = Cursors.Hand;
                    return;
                }
            }

            // default cursor
            treFallNavigator.Cursor = Cursors.Default;
        }

        private void treFallNavigator_MouseUp(object sender, MouseEventArgs e)
        {
            // check if left button was clicked
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            // get information about point where mouse was clicked
            TreeListHitInfo hi = treFallNavigator.CalcHitInfo(new Point(e.X, e.Y));

            // check if mouse was clicked above cell
            if (hi.HitInfoType != HitInfoType.Cell)
            {
                return;
            }

            // check if mouse was clicked above modul-icon
            if (treFallNavigator.FocusedNode.GetValue("Type").Equals("P") && hi.Column.ColumnEdit == repModulIcon)
            {
                // check if icon is marked as disabled to open item
                object val = treFallNavigator.FocusedNode.GetValue(treFallNavigator.FocusedColumn);

                if (val is int && Convert.ToInt32(val) % 10 > 0)
                {
                    FormController.OpenForm(
                        "FrmFall",
                        "Action",
                        "ShowFall",
                        "BaPersonID",
                        Convert.ToInt32(treFallNavigator.FocusedNode.GetValue("BaPersonID")),
                        "ModulID",
                        (Convert.ToInt32(val) - 1000) / 100);
                }
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void OnGettingLayout(KissLayoutEventArgs e)
        {
            base.OnGettingLayout(e);

            KissControlLayout clAbgeschlossene = new KissControlLayout(chkAbgeschlossene.Name);
            KissControlLayout clGruppe = new KissControlLayout(chkGruppe.Name);
            KissControlLayout clGastrecht = new KissControlLayout(chkGastrecht.Name);

            e.Layout.ControlLayouts.Add(clAbgeschlossene);
            e.Layout.ControlLayouts.Add(clGruppe);
            e.Layout.ControlLayouts.Add(clGastrecht);

            SimpleProperty sipAbgeschlossene = new SimpleProperty("Checked", chkAbgeschlossene.Checked);
            SimpleProperty sipGruppe = new SimpleProperty("Checked", chkGruppe.Checked);
            SimpleProperty sipGastrecht = new SimpleProperty("Checked", chkGastrecht.Checked);

            try
            {
                clAbgeschlossene.Properties.Add(sipAbgeschlossene);
            }
            catch (Exception ex)
            {
                e.Errors.Add(new LayoutError(sipAbgeschlossene, ex));
            }
            try
            {
                clGruppe.Properties.Add(sipGruppe);
            }
            catch (Exception ex)
            {
                e.Errors.Add(new LayoutError(sipGruppe, ex));
            }
            try
            {
                clGastrecht.Properties.Add(sipGastrecht);
            }
            catch (Exception ex)
            {
                e.Errors.Add(new LayoutError(sipGastrecht, ex));
            }
        }

        protected override void OnSettingLayout(KissLayoutEventArgs e)
        {
            base.OnSettingLayout(e);

            KissControlLayout cl2;
            KissControlLayout cl4;
            KissControlLayout cl5;

            try
            {
                cl2 = e.Layout.ControlLayouts[chkAbgeschlossene.Name];
            }
            catch
            {
                cl2 = null;
            }
            try
            {
                cl4 = e.Layout.ControlLayouts[chkGruppe.Name];
            }
            catch
            {
                cl4 = null;
            }
            try
            {
                cl5 = e.Layout.ControlLayouts[chkGastrecht.Name];
            }
            catch
            {
                cl5 = null;
            }

            if (cl2 != null)
            {
                try
                {
                    SimpleProperty p2 = (SimpleProperty)cl2.Properties["Checked"];
                    try
                    {
                        chkAbgeschlossene.Checked = (bool)p2.Value;
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

            if (cl4 != null)
            {
                try
                {
                    SimpleProperty p4 = (SimpleProperty)cl4.Properties["Checked"];
                    try
                    {
                        chkGruppe.Checked = (bool)p4.Value;
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
                        chkGastrecht.Checked = (bool)p5.Value;
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
        }

        #endregion

        #region Private Methods

        private void OpenPersonModule()
        {
            if (treFallNavigator.FocusedNode != null && treFallNavigator.FocusedNode.GetValue("Type").Equals("P"))
            {
                // show Fallbearbeitung with Person-Module
                FormController.OpenForm(
                    "FrmFall",
                    "Action",
                    "ShowFall",
                    "BaPersonID",
                    Convert.ToInt32(treFallNavigator.FocusedNode.GetValue("BaPersonID")),
                    "ModulID",
                    1);
            }
        }

        private void PopulateTreeView(string searchValue, string searchFieldName)
        {
            // store current cursor
            Cursor currentCursor = Cursor.Current;

            try
            {
                // check if currently loading class and settings
                if (_isLoading)
                {
                    return;
                }

                // wait cursor
                Cursor.Current = Cursors.WaitCursor;

                // reset datasource
                treFallNavigator.DataSource = null;

                // load data from database
                SqlQuery qry = DBUtil.OpenSQL(
                    @"EXECUTE dbo.spFaGetTreeFallNavigator {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11};",
                    Session.User.UserID,
                    chkFV.Checked,
                    chkSB.Checked,
                    chkCM.Checked,
                    chkBW.Checked,
                    chkED.Checked,
                    chkIN.Checked,
                    chkAB.Checked,
                    chkWD.Checked,
                    chkAbgeschlossene.Checked,
                    chkGruppe.Checked,
                    chkGastrecht.Checked);

                // change imageindex for iconid
                foreach (System.Data.DataRow row in qry.DataTable.Rows)
                {
                    if (!DBUtil.IsEmpty(row["IconID"]))
                    {
                        row["IconID"] = KissImageList.GetImageIndex((int)row["IconID"]);
                    }
                }

                // set datasource and collapse all tree-items
                treFallNavigator.DataSource = qry;
                treFallNavigator.CollapseAll();

                // refresh Navigator und Neupositionierung auf neuen Fall
                if (!DBUtil.IsEmpty(searchValue) && !DBUtil.IsEmpty(searchFieldName))
                {
                    TreeListNode node = DBUtil.FindNodeByValue(treFallNavigator.Nodes, searchValue, searchFieldName);

                    if (node != null)
                    {
                        treFallNavigator.FocusedNode = node;
                        node.Expanded = true;
                    }
                }
                else
                {
                    // select first entry
                    treFallNavigator.MoveFirst();
                }

                // setup label for counting persons
                lblAnzahlPersonen.Text = KissMsg.GetMLMessage(
                    Name, "AnzahlPersonen", "Anzahl Personen: {0}", KissMsgCode.Text, qry.Count == 0 ? "0" : qry["PersonCount"].ToString());

                // sort treeview
                treFallNavigator.BeginSort();
                treFallNavigator.EndSort();
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError(Name, "ErrorPopuplateTreeView", "Es ist ein Fehler beim Laden der Daten aufgetreten.", ex);
            }
            finally
            {
                Cursor.Current = currentCursor;
            }
        }

        #endregion

        #endregion
    }
}