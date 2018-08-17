using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList.Nodes;
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Inkasso
{
    public partial class CtlIkModulTree : KissModulTree
    {
        private const string CLASSNAME = "CtlIkModulTree";

        #region Fields

        #region Private Fields

        private IKissView _ctlDetail;

        #endregion

        #endregion

        #region Constructors

        public CtlIkModulTree(int baPersonID, int faFallID, Panel panelDetail)
            : base(baPersonID, faFallID, panelDetail, (int)Gui.ModulID.I)
        {
            InitializeComponent();

            popup_Tree.LinksPersistInfo.Clear();
            popup_Tree.LinksPersistInfo.AddRange(new[] {
                new LinkPersistInfo(btnNeueAbklaerung), //BSS only
                new LinkPersistInfo(btnNeuesAlimentinkasso),
                new LinkPersistInfo(btnNeuerElternbeitrag),
                new LinkPersistInfo(btnNeueRueckerstattung),
                new LinkPersistInfo(btnNeueRueckerstattungPOM), //BSS only
                new LinkPersistInfo(btnNeuerVerwandtenbeitrag),
                new LinkPersistInfo(btnNeuerNachlass),
                new LinkPersistInfo(btnNeuerRechtstitel, true),
                new LinkPersistInfo(btnLoeschen, true),
                new LinkPersistInfo(btnFallZuteilung, true),
                new LinkPersistInfo(btnFallZugriff),
                new LinkPersistInfo(btnFallInfo)
            });
        }

        public CtlIkModulTree()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        protected override void kissTree_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            // handle empty node
            if (e == null || e.Node == null)
            {
                return;
            }

            Cursor currentCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string className = e.Node.GetValue("ClassName") as string;
                if (className != null)
                {
                    _ctlDetail = null;
                    IKissView ctrl = null;
                    object baPersonID = e.Node.GetValue("BaPersonID");
                    object faLeistungID = e.Node.GetValue(colFaLeistungID);
                    object faFallID = e.Node.GetValue("FaFallID");
                    object faProzessCode = e.Node.GetValue("FaProzessCode");
                    string titel = e.Node.GetValue(colName) as string;
                    System.Drawing.Image imgIcon = GetIcon(e);

                    int intPerson = Utils.ConvertToInt(baPersonID);
                    int intFall = Utils.ConvertToInt(faFallID);
                    int intLeistg = Utils.ConvertToInt(faLeistungID);
                    int intProzessCode = Utils.ConvertToInt(faProzessCode);
                    bool inkassoGesperrt = DBUtil.IsEmpty(e.Node.GetValue("InkassoGesperrt")) ? true : (bool)e.Node.GetValue("InkassoGesperrt");
                    int intRechtstitel = Utils.ConvertToInt(e.Node.GetValue("RechtstitelID"));
                    string id = e.Node.GetValue("ID") as string;
                    string name = e.Node.GetValue("Name") as string;

                    // Neue WPF Masken (XAML)
                    var initParams = new InitParameters
                    {
                        BaPersonID = baPersonID as int?,
                        FaLeistungID = faLeistungID as int?,
                        Title = titel,
                    };
                    var xclassID = Kiss.Infrastructure.IoC.Container.Resolve<ViewFactory>().GetClassID(className);
                    if (xclassID.HasValue)
                    {
                        var view = new CtlWpfHost(xclassID.Value, initParams);
                        ShowDetail(view, true);
                        return;
                    }

                    Type type = AssemblyLoader.GetType(className);
                    if (type != null)
                    {
                        ctrl = _showDetail.GetDetailControl(type, true);
                        ctrl.Name = name;
                    }
                    if (ctrl == null || id != null && id.StartsWith("X"))
                    {
                        ShowDetail(ctrl);
                        return;
                    }
                    switch (className)
                    {
                        case "CtlIkAbklaerungen":
                            _ctlDetail = (KissUserControl)AssemblyLoader.CreateInstance(type, imgIcon, titel, intLeistg);
                            break;

                        case "CtlIkLeistung":
                            _ctlDetail = (KissUserControl)AssemblyLoader.CreateInstance(type, imgIcon, titel, intLeistg);
                            break;

                        case "CtlAmAnspruchsberechnung":
                            _ctlDetail = (KissUserControl)AssemblyLoader.CreateInstance(type, intLeistg, imgIcon);
                            break;

                        case "CtlIkRechtstitel":
                            _ctlDetail = (KissUserControl)AssemblyLoader.CreateInstance(type, intLeistg, intFall, imgIcon, inkassoGesperrt, intRechtstitel);
                            break;

                        case "CtlIkMonatszahlen":
                            _ctlDetail = (KissUserControl)AssemblyLoader.CreateInstance(
                                type, intLeistg, intFall, imgIcon, intRechtstitel, intPerson, intProzessCode);
                            break;

                        case "CtlIkForderungen":
                            _ctlDetail = (KissUserControl)AssemblyLoader.CreateInstance(type);
                            AssemblyLoader.InvokeMethode(_ctlDetail, "Init", titel, imgIcon, intLeistg, intProzessCode);
                            break;

                        case "CtlIkRechtlicheMassnahmenInkassofall":
                            _ctlDetail = (KissUserControl)AssemblyLoader.CreateInstance(className, imgIcon, titel, (int)e.Node.GetValue("FaLeistungID"));
                            break;

                        case "CtlIkRechtlicheMassnahmenSchuldner":
                            _ctlDetail = (KissUserControl)AssemblyLoader.CreateInstance(className, imgIcon, titel, (int)e.Node.GetValue("BaPersonID"));
                            break;

                        case "CtlIkKontoauszug":
                            _ctlDetail = (KissUserControl)AssemblyLoader.CreateInstance(type);
                            AssemblyLoader.InvokeMethode(_ctlDetail, "Init", titel, imgIcon, (int)e.Node.GetValue("BaPersonID"), e.Node.GetValue("FaLeistungID"), intProzessCode);
                            break;

                        case "CtlIkBetreibungenVerlustscheine":
                            _ctlDetail = (KissUserControl)AssemblyLoader.CreateInstance(className, imgIcon, titel, intLeistg);
                            break;

                        case "CtlIkGlaeubiger":
                            _ctlDetail = (KissUserControl)AssemblyLoader.CreateInstance(type);
                            AssemblyLoader.InvokeMethode(_ctlDetail, "Init", titel, imgIcon, intLeistg, intFall, intProzessCode);
                            break;

                        case "CtlDynaMask":
                            string maskName = e.Node.GetValue("MaskName") as string;

                            CtlDynaMask ctlDynaMask = (CtlDynaMask)ctrl;

                            ctlDynaMask.Init(name, GetIcon(e), intLeistg, 0, maskName, false, null);

                            ShowDetail(ctlDynaMask, true);

                            foreach (Control ctl in UtilsGui.AllControls(ctlDynaMask))
                            {
                                if (ctl is KissGrid)
                                    ((KissGrid)ctl).PerformLoad();
                                else
                                {
                                    if ((ctl.Anchor & AnchorStyles.Right) == AnchorStyles.Right)
                                        ctl.Width = ctlDynaMask.Width - ctl.Left - 5;

                                    if ((ctl.Anchor & AnchorStyles.Bottom) == AnchorStyles.Bottom)
                                        ctl.Height = ctlDynaMask.Height - ctl.Top - 5;
                                }
                            }
                            return;

                        case "CtlKbBelegImportIK":
                        case "CtlKbZahlungseingang":
                            _ctlDetail = (KissUserControl)AssemblyLoader.CreateInstance(className, intPerson);
                            break;

                        default:
                            _ctlDetail = _showDetail.GetDetailControl(type, true);
                            if (_ctlDetail != null)
                            {
                                try
                                {
                                    AssemblyLoader.InvokeMethode(_ctlDetail, "Init", titel, GetIcon(e));
                                }
                                catch { }
                            }
                            break;
                    }

                    if (_ctlDetail != null)
                    {
                        _ctlDetail.Name = titel;
                        if (_ctlDetail is KissUserControl)
                        {
                            ApplyEditMaskToSqlQuery(((KissUserControl)_ctlDetail).ActiveSQLQuery);
                        }

                        ShowDetail(_ctlDetail, true);
                    }
                }
            }
            catch (Exception f)
            {
                KissMsg.ShowError("CtlIkModulTreeDynaPrepare", "EintragAnzeigenNichtMoeglich", "Der gewünschte Eintrag kann nicht angezeigt werden", f);
            }
            finally
            {
                Cursor.Current = currentCursor;
            }
        }

        private void barManager_Tree_QueryShowPopupMenu(object sender, QueryShowPopupMenuEventArgs e)
        {
            foreach (BarItemLink barItemLink in e.Menu.ItemLinks)
                barItemLink.Item.Visibility = BarItemVisibility.Never;

            if (DBUtil.UserHasRight("CtlIkModulTree_IkNeueAbklaerung"))
                btnNeueAbklaerung.Visibility = BarItemVisibility.Always;
            if (DBUtil.UserHasRight("CtlIkModulTree_IkNeuesAlimentInkasso"))
                btnNeuesAlimentinkasso.Visibility = BarItemVisibility.Always;
            if (DBUtil.UserHasRight("CtlIkModulTree_IkNeuerElternbeitrag"))
                btnNeuerElternbeitrag.Visibility = BarItemVisibility.Always;
            if (DBUtil.UserHasRight("CtlIkModulTree_IkNeueRueckerstattung"))
                btnNeueRueckerstattung.Visibility = BarItemVisibility.Always;
            if (DBUtil.UserHasRight("CtlIkModulTree_IkNeueRueckerstattungPOM"))
                btnNeueRueckerstattungPOM.Visibility = BarItemVisibility.Always;
            if (DBUtil.UserHasRight("CtlIkModulTree_IkNeuerVerwandtenbeitrag"))
                btnNeuerVerwandtenbeitrag.Visibility = BarItemVisibility.Always;
            if (DBUtil.UserHasRight("CtlIkModulTree_IkNeuerNachlass"))
                btnNeuerNachlass.Visibility = BarItemVisibility.Always;

            if (kissTree.FocusedNode != null)
            {
                if (DBUtil.UserHasRight("FrmFallZugriff"))
                    btnFallZugriff.Visibility = BarItemVisibility.Always;
                if (DBUtil.UserHasRight("FrmFallInfo"))
                    btnFallInfo.Visibility = BarItemVisibility.Always;

                btnLoeschen.Caption = string.Format(KissMsg.GetMLMessage(CLASSNAME, "btnLoeschenCaptionSuffix", "{0} löschen"), kissTree.FocusedNode.GetDisplayText("Name"));

                switch (kissTree.FocusedNode.GetValue("ClassName") as string)
                {
                    case "CtlIkLeistung":
                        if (DBUtil.UserHasRight("CtlIkModulTree_IkNeuerRechtstitel"))
                            if (kissTree.FocusedNode.GetValue("FaProzessCode") is int)
                            {
                                int faProzessCode = Utils.ConvertToInt(kissTree.FocusedNode.GetValue("FaProzessCode"));

                                if (faProzessCode == 400 && DBUtil.UserHasRight("CtlIkModulTree_IkAbklaerungLoeschen"))
                                    btnLoeschen.Visibility = BarItemVisibility.Always;
                                if (faProzessCode == 401) // Nur Alim kann Rechstitel haben
                                    btnNeuerRechtstitel.Visibility = BarItemVisibility.Always;
                                if (faProzessCode == 401 && DBUtil.UserHasRight("CtlIkModulTree_IkAlimentLoeschen"))
                                    btnLoeschen.Visibility = BarItemVisibility.Always;
                                if (faProzessCode == 402 && DBUtil.UserHasRight("CtlIkModulTree_IkElternbeitragLoeschen"))
                                    btnLoeschen.Visibility = BarItemVisibility.Always;
                                if (faProzessCode == 403 && DBUtil.UserHasRight("CtlIkModulTree_IkRueckerstattungLoeschen"))
                                    btnLoeschen.Visibility = BarItemVisibility.Always;
                                if (faProzessCode == 404 && DBUtil.UserHasRight("CtlIkModulTree_IkVerwandtenbeitragLoeschen"))
                                    btnLoeschen.Visibility = BarItemVisibility.Always;
                                if (faProzessCode == 405 && DBUtil.UserHasRight("CtlIkModulTree_IkTagesheimLoeschen"))
                                    btnLoeschen.Visibility = BarItemVisibility.Always;
                                if (faProzessCode == 406 && DBUtil.UserHasRight("CtlIkModulTree_IkNachlassLoeschen"))
                                    btnLoeschen.Visibility = BarItemVisibility.Always;
                                if (faProzessCode == 407 && DBUtil.UserHasRight("CtlIkModulTree_IkRueckerstattungPOMLoeschen"))
                                    btnLoeschen.Visibility = BarItemVisibility.Always;
                            }

                        break;

                    case "CtlIkRechtstitel":
                        if (DBUtil.UserHasRight("CtlIkModulTree_RechtstitelLoeschen"))
                            btnLoeschen.Visibility = BarItemVisibility.Always;
                        break;

                    case "CtlIkRechtlicheMassnahmenSchuldner":
                    case "CtlIkKontoauszug":
                        break;

                    default:
                        break;
                }
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

        private void btnFallZuteilung_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormController.ShowDialogOnMain("DlgFallZuteilung", BaPersonID);
        }

        private void btnLoeschen_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Utils.ConvertToString(kissTree.FocusedNode.GetValue("ClassName")).Equals("CtlIkRechtstitel"))
            {
                int cntForderungen = (int)DBUtil.ExecuteScalarSQL(@"
                              SELECT COUNT(*) FROM dbo.IkForderung WITH (READUNCOMMITTED)
                              WHERE  IkRechtstitelID = {0}",
                                Utils.ConvertToInt(kissTree.FocusedNode.GetValue("RechtstitelID")));

                if (cntForderungen > 0)
                {
                    KissMsg.ShowInfo("Rechtstitel wurde nicht gelöscht! Es existieren noch Forderungen.");
                }
                else
                {
                    if (KissMsg.ShowQuestion("CtlIkModulTree", "RechtstitelLoeschen", "Soll der Rechtstitel gelöscht werden?", true))
                    {
                        DBUtil.ExecSQL(@"DELETE FROM IkRechtstitel WHERE IkRechtstitelID = {0}",
                            Utils.ConvertToInt(kissTree.FocusedNode.GetValue("RechtstitelID")));
                    }
                }
            }
            else if (Utils.ConvertToString(kissTree.FocusedNode.GetValue("ClassName")).Equals("CtlAmAnspruchsberechnung"))
            {
                if (KissMsg.ShowQuestion("CtlIkModulTree", "AnspruchLoeschen", "Soll der {0} gelöscht werden?", 0, 0, true, Utils.ConvertToString(kissTree.FocusedNode.GetValue("Name"))))
                {
                    DBUtil.ExecSQL(@"DELETE FROM IkRechtstitel WHERE FaLeistungID = {0}",
                        Utils.ConvertToInt(kissTree.FocusedNode.GetValue("FaLeistungID")));

                    DBUtil.ExecSQL(@"DELETE FROM FaLeistung WHERE FaLeistungID = {0}",
                        Utils.ConvertToInt(kissTree.FocusedNode.GetValue("FaLeistungID")));
                }
            }
            else
            {
                int count = (int)DBUtil.ExecuteScalarSQL(@"
                              SELECT COUNT(*) FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                              WHERE  FaLeistungID = {0}
                              AND    FaProzessCode = 403",
                                (int)kissTree.FocusedNode.GetValue("FaLeistungID"));

                // Delete entry in IkGlaeubiger if deleting "Rückerstattung"!!
                if (count > 0)
                {
                    DBUtil.ExecSQL(@"DELETE FROM IkGlaeubiger WHERE FaLeistungID = {0}", (int)kissTree.FocusedNode.GetValue("FaLeistungID"));
                }

                DBUtil.ExecuteScalarSQL("DELETE FROM FaLeistung WHERE FaLeistungID = {0}", (int)kissTree.FocusedNode.GetValue("FaLeistungID"));
                FormController.SendMessage("FrmFallNavigator", "Action", "RefreshTree");
            }
            //little "hack" to avoid update conflict
            if (DetailControl is KissUserControl)
            {
                ((KissUserControl)DetailControl).ActiveSQLQuery.Row.AcceptChanges();
                ((KissUserControl)DetailControl).ActiveSQLQuery.RowModified = false;
                FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            }
        }

        private void btnNeueAbklaerung_ItemClick(object sender, ItemClickEventArgs e)
        {
            InsertLeistungsart(400);
        }

        private void btnNeuerElternbeitrag_ItemClick(object sender, ItemClickEventArgs e)
        {
            InsertLeistungsart(402);
        }

        private void btnNeuerNachlass_ItemClick(object sender, ItemClickEventArgs e)
        {
            InsertLeistungsart(406);
        }

        private void btnNeuerRechtstitel_ItemClick(object sender, ItemClickEventArgs e)
        {
            DBUtil.ExecuteScalarSQL(@"
            INSERT INTO IkRechtstitel(FaLeistungID, SchuldnerMahnen, IkRechtstitelGueltigVon)
            VALUES ({0}, 0, GetDate())",
            Utils.ConvertToInt(kissTree.FocusedNode.GetValue("FaLeistungID")));

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void btnNeueRueckerstattung_ItemClick(object sender, ItemClickEventArgs e)
        {
            InsertLeistungsart(403);
        }

        private void btnNeueRueckerstattungPOM_ItemClick(object sender, ItemClickEventArgs e)
        {
            InsertLeistungsart(407);
        }

        private void btnNeuerVerwandtenbeitrag_ItemClick(object sender, ItemClickEventArgs e)
        {
            InsertLeistungsart(404);
        }

        private void btnNeuesAlimentinkasso_ItemClick(object sender, ItemClickEventArgs e)
        {
            InsertLeistungsart(401);
        }

        private void CtlIkModulTree_Load(object sender, EventArgs e)
        {
            FillTree();

            //expand top 3 levels
            foreach (TreeListNode node1 in kissTree.Nodes)
            {
                node1.Expanded = true;
                foreach (TreeListNode node2 in node1.Nodes)
                {
                    node2.Expanded = true;
                    foreach (TreeListNode node3 in node2.Nodes)
                    {
                        node3.Expanded = true;
                    }
                }
            }

            // Park on first green [I]
            kissTree.FocusedNode = KissTree.FindNode(
                kissTree.Nodes,
                new object[] { colClassName, "CtlIkLeistung" },
                CompareNodeString);

            kissTree.TopVisibleNodeIndex = 0; // bring first row into visible area
        }

        #endregion

        #region Methods

        #region Public Methods

        public bool CompareNodeString(TreeListNode nodeInTree, object[] searchValue)
        {
            object valueInTree = nodeInTree.GetValue(searchValue[0]);

            if (DBNull.Value == valueInTree || null == valueInTree)
            {
                return false;
            }

            if ((string)valueInTree == (string)searchValue[1])
            {
                return true;
            }

            return false;
        }

        public override string GetContextName()
        {
            return "Ik";
        }

        #endregion

        #region Private Methods

        private void InsertLeistungsart(int prozessCode)
        {
            //neues Inkasso nur möglich, falls bereits eine Fallführung existiert
            int faFallID = -1;
            int leiID;

            object tmp = DBUtil.ExecuteScalarSQL(
                    "SELECT FaFallID FROM FaLeistung WHERE BaPersonID = {0} AND ModulID = 2 AND DatumBis IS NULL",
                    BaPersonID);
            if (tmp != null && tmp != DBNull.Value)
            {
                int.TryParse(tmp.ToString(), out faFallID);
            }

            if (faFallID <= 0)
            {
                KissMsg.ShowInfo("CltIkModulTree", "InkassoNichtMoeglich", "Ohne aktive Fallführung kann kein neues Inkasso erzeugt werden.");
                return;
            }
            kissTree.SaveState();

            int.TryParse(DBUtil.ExecuteScalarSQL(@"
            INSERT INTO FaLeistung (FaFallID, ModulID, FaProzessCode, BaPersonID, UserID, DatumVon, SchuldnerBaPersonID, Creator, Created, Modifier, Modified)
            VALUES ({0}, 4, {1}, {2}, {3}, dbo.fnDateOf(GETDATE()), {2}, {4}, GetDate(), {4}, GetDate())
            Select SCOPE_IDENTITY()",
                faFallID, prozessCode, BaPersonID, Session.User.UserID, DBUtil.GetDBRowCreatorModifier()).ToString(), out leiID);

            if (leiID <= 0)
            {
                KissMsg.ShowInfo("CltIkModulTree", "LeistungNichtMoeglich", "Beim Einfügen der Leistung ist ein Fehler aufgetreten.");
                return;
            }

            // Gläubiger einfügen für Rückerstattung (403), Rückerstattung POM (407), Nachlass (406)
            if (prozessCode == 403 || prozessCode == 407 || prozessCode == 406)
            {
                CtlIkGlaeubiger.GlaeubigerEinfuegen(leiID);
            }

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            FormController.SendMessage("FrmFallNavigator", "Action", "RefreshTree");

            TreeListNode node = DBUtil.FindNodeByValue(kissTree.Nodes, leiID.ToString(), "FaLeistungID");
            if (node != null)
            {
                kissTree.FocusedNode = node;
                node.Expanded = true;
            }
        }

        #endregion

        #endregion
    }
}