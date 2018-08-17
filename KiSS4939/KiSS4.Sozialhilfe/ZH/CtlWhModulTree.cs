using System;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Gui.Layout;

using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace KiSS4.Sozialhilfe.ZH
{
    public partial class CtlWhModulTree : KissModulTree
    {
        #region Fields

        #region Private Fields

        private bool _isLoading;

        #endregion

        #endregion

        #region Constructors

        public CtlWhModulTree(int baPersonID, int faFallID, Panel panelDetail)
            : base(baPersonID, faFallID, panelDetail, 3)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            popup_Tree.LinksPersistInfo.Clear();
            popup_Tree.LinksPersistInfo.AddRange(
                new[]
                {
                    new LinkPersistInfo(btnBgFinanzplan2),
                    new LinkPersistInfo(btnBgFinanzplan1),
                    //new LinkPersistInfo(btnBgFinanzplan3),
                    new LinkPersistInfo(btnBgFinanzplanDelete),
                    new LinkPersistInfo(btnFaLeistung300, true),
                    new LinkPersistInfo(btnFaLeistung301),
                    new LinkPersistInfo(btnFaLeistung302),
                    new LinkPersistInfo(btnFaLeistung304),
                    new LinkPersistInfo(btnFaLeistungDelete),
                    new LinkPersistInfo(btnBgBudget, true),
                    //new LinkPersistInfo(btnBgBudgetResetMaster),
                    new LinkPersistInfo(btnBgBudgetReset),
                    new LinkPersistInfo(btnBgBudgetDelete),
                    new LinkPersistInfo(btnFallZuteilung, true)
                });
        }

        public CtlWhModulTree()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        protected override void kissTree_AfterFocusNode(object sender, NodeEventArgs e)
        {
            if (_isLoading)
            {
                return;
            }

            if (e == null || e.Node == null)
            {
                ShowDetail(null);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                IKissView ctl = null;
                string className = e.Node.GetValue("ClassName") as string;
                Image imgIcon = GetIcon(e);
                string titel = e.Node.GetValue("Name").ToString();
                string treeID = Utils.ConvertToString(e.Node.GetValue("ID"));
                int faProzessCode = Utils.ConvertToInt(e.Node.GetValue("FaProzessCode"));

                object leistgGeschlossen = e.Node.GetValue("LeistungGeschlossen");
                bool leistungGeschlossen = !(leistgGeschlossen is bool) || (bool)leistgGeschlossen;

                switch (className)
                {
                    case "CtlWhKontoauszug":
                        if (ctlWhKontoauszug == null || ctlWhKontoauszug.IsDisposed || panelDetail == null)
                        {
                            ctlWhKontoauszug =
                                (KissUserControl)AssemblyLoader.CreateInstance(className, imgIcon, titel, (int)e.Node.GetValue("BaPersonID"));
                            ShowDetail(ctlWhKontoauszug); //, true
                            panelDetail = ctlWhKontoauszug.Parent;
                        }
                        else
                        {
                            ShowDetail(ctlWhKontoauszug);
                        }
                        return;

                    case "CtlWhKontoauszugWV":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(className, imgIcon, titel, (int)e.Node.GetValue("BaPersonID"));
                        break;

                    case "CtlWhKlientenKontoabrechnung":
                        ctl =
                            (KissUserControl)
                            AssemblyLoader.CreateInstance(
                                className,
                                imgIcon,
                                titel,
                                (int)e.Node.GetValue("BaPersonID"),
                                (int)e.Node.GetValue("FaFallID"));
                        break;
                    case "CtlWhWVEinheit":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(className, imgIcon, titel, (int)e.Node.GetValue("FaFallID"));
                        break;

                    case "CtlWhLeistung":
                    case "CtlWhVerfuegungen":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(
                            className,
                            imgIcon,
                            titel
                                                   ,
                            (int)e.Node.GetValue("FaLeistungID"));
                        break;

                    case "CtlWhFinanzplan":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(
                            className,
                            imgIcon,
                            titel
                                                   ,
                            (int)e.Node.GetValue("BgFinanzplanID")
                                                   ,
                            e.Node.GetValue("BgBudgetID"));
                        break;

                    case "CtlWhPersonen":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(
                            className,
                            imgIcon,
                            titel
                                                   ,
                            (int)e.Node.GetValue("BgFinanzplanID"),
                            (int)e.Node.GetValue("BaPersonID"));
                        break;

                    case "CtlWhNotfall":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(
                            className,
                            imgIcon,
                            titel
                                                   ,
                            (int)e.Node.GetValue("BgFinanzplanID"),
                            (int)e.Node.GetValue("BaPersonID"));
                        break;

                    case "CtlBgUebersicht":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(
                            className,
                            imgIcon,
                            titel
                                                   ,
                            (int)e.Node.GetValue("BgBudgetID"));
                        break;

                    case "CtlBgGrundbedarf":
                    case "CtlBgKrankenkasse":
                    case "CtlBgWohnkosten":
                    case "CtlBgFPZulagenEFB":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(
                            className,
                            imgIcon,
                            titel
                                                   ,
                            (int)e.Node.GetValue("BgBudgetID"));
                        break;

                    case "CtlBgFPEinnahmen":
                    case "CtlBgFPAusgaben":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(
                            className,
                            imgIcon,
                            titel,
                            (int)e.Node.GetValue("BgBudgetID"),
                            (int)e.Node.GetValue("BgGruppeCode"));
                        break;

                    case "CtlWhBudget":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(
                            className,
                            imgIcon,
                            titel
                                                   ,
                            (int)e.Node.GetValue("BgBudgetID"));
                        break;

                    case "CtlWhSpezialkonto":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(
                            className,
                            imgIcon,
                            titel
                                                   ,
                            (BgSpezkontoTyp)e.Node.GetValue("BgSpezkontoTypCode")
                                                   ,
                            (int)e.Node.GetValue("FaLeistungID"));
                        break;

                    case "CtlIkLeistungAlbv":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(
                            className,
                            imgIcon,
                            titel
                                                   ,
                            (int)e.Node.GetValue("FaLeistungID"),
                            faProzessCode);
                        break;

                    case "CtlIkForderungen":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(className);
                        AssemblyLoader.InvokeMethode(
                            ctl,
                            "Init",
                            titel,
                            imgIcon,
                            (int)e.Node.GetValue("FaFallID"),
                            (int)e.Node.GetValue("FaLeistungID"),
                            faProzessCode,
                            leistungGeschlossen);
                        break;

                    case "CtlIkRatenplan":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(className);
                        AssemblyLoader.InvokeMethode(
                            ctl,
                            "Init",
                            (int)e.Node.GetValue("FaLeistungID"),
                            (int)e.Node.GetValue("FaFallID"),
                            leistungGeschlossen);
                        break;

                    case "CtlIkKontoauszug":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(className);
                        AssemblyLoader.InvokeMethode(
                            ctl,
                            "Init",
                            titel,
                            imgIcon,
                            (int)e.Node.GetValue("FaFallID"),
                            (int)e.Node.GetValue("FaLeistungID"),
                            (int)e.Node.GetValue("BaPersonID"),
                            treeID,
                            faProzessCode,
                            leistungGeschlossen
                            );
                        break;

                    case null:
                        break;

                    default:
                        ctl = _showDetail.GetDetailControl(AssemblyLoader.GetType(className), true);
                        break;
                }
                //
                ShowDetail(ctl, true);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void CtlWhModulTree_Load(object sender, EventArgs e)
        {
            kissTree.DataSource = null; //sonst Exception: open DataReader!

            _isLoading = true;
            FillTree();
            _isLoading = false;
            bool treeFocused = false; // Call kissTree_AfterFocusNode only if wasn't called implicitly through setting the
            // focused node (for performance reasons, else the form will be loaded twice)

            foreach (TreeListNode node in kissTree.Nodes)
            {
                // oberste Unterstützungsperiode expandieren
                if ("CtlWhLeistung" == node.GetValue("ClassName") as string)
                {
                    node.Expanded = true; // Sozialhilfe
                    kissTree.FocusedNode = node;
                    treeFocused = true;

                    if (node.Nodes.Count > 0 && node.Nodes[0].Nodes.Count > 1)
                    {
                        node.Nodes[0].Expanded = true;
                        if (Utils.ConvertToInt(node.Nodes[0].GetValue("BgBewilligungStatusCode")) < 5)
                        {
                            node.Nodes[0].Nodes[1].Expanded = true; //Finanzplan
                        }
                    }

                    break;
                }
            }

            if (!treeFocused)
            {
                if (kissTree.Nodes.Count > 0)
                {
                    kissTree_AfterFocusNode(this, new NodeEventArgs(kissTree.FocusedNode));
                }
                else
                {
                    kissTree_AfterFocusNode(this, null);
                }
            }

            // Falls gewisse Nodes versteckt werden sollen, mach dies hier
            HideAbgeschlosseneW();
            HideBeendeteRegWH(kissTree.Nodes);
        }

        private void barManager_Tree_QueryShowPopupMenu(object sender, QueryShowPopupMenuEventArgs e)
        {
            foreach (BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                barItemLink.Item.Visibility = BarItemVisibility.Never;
            }

            string cName = Utils.ConvertToString(kissTree.FocusedNode.GetValue("ClassName"));
            string nName = Utils.ConvertToString(kissTree.FocusedNode.GetValue("Name"));

            if (DBUtil.UserHasRight("CtlIkLeistungAlbv", "I"))
            {
                btnFaLeistung301.Visibility = BarItemVisibility.Always;
                btnFaLeistung302.Visibility = BarItemVisibility.Always;
                btnFaLeistung304.Visibility = BarItemVisibility.Always;
            }

            if ((DBUtil.UserHasRight("CtlWhLeistung", "D") && cName == "CtlWhLeistung") ||
                (DBUtil.UserHasRight("CtlIkLeistungAlbv", "D") && cName == "CtlIkLeistungAlbv"))
            {
                btnFaLeistungDelete.Visibility = BarItemVisibility.Always;
                btnFaLeistungDelete.Caption = "'" + nName + "' löschen";
            }

            if (kissTree.FocusedNode == null)
            {
                if (DBUtil.UserHasRight("CtlWhLeistung", "I"))
                {
                    btnFaLeistung300.Visibility = BarItemVisibility.Always;
                }
            }
            else
            {
                switch (kissTree.FocusedNode.GetValue("ClassName") as string)
                {
                    case "CtlWhLeistung":
                        if (DBUtil.UserHasRight("CtlWhLeistung", "I"))
                        {
                            btnFaLeistung300.Visibility = BarItemVisibility.Always;
                        }

                        if (DBUtil.UserHasRight("CtlWhLeistung", "D"))
                        {
                            btnFaLeistungDelete.Visibility = BarItemVisibility.Always;
                        }

                        if (DBUtil.UserHasRight("CtlWhFinanzplan", "I"))
                        {
                            //btnBgFinanzplan1.Visibility = BarItemVisibility.Always;
                            btnBgFinanzplan2.Visibility = BarItemVisibility.Always;
                        }

                        if (DBUtil.UserHasRight("FrmFallZugriff"))
                        {
                            btnFallZugriff.Visibility = BarItemVisibility.Always;
                        }

                        if (DBUtil.UserHasRight("FrmFallInfo"))
                        {
                            btnFallInfo.Visibility = BarItemVisibility.Always;
                        }

                        break;

                    case "CtlWhFinanzplan":
                        if (DBUtil.UserHasRight("CtlWhFinanzplan", "D"))
                        {
                            btnBgFinanzplanDelete.Visibility = BarItemVisibility.Always;
                        }

                        if (DBUtil.UserHasRight("CtlWhBudget", "I")
                            && (int)kissTree.FocusedNode.GetValue("BgBewilligungStatusCode") == 5)
                        {
                            btnBgBudget.Visibility = BarItemVisibility.Always;
                        }

                        break;

                    case "CtlWhBudget":
                        if ((bool)kissTree.FocusedNode.GetValue("MasterBudget"))
                        {
                            if ((BgBewilligungStatus)kissTree.FocusedNode.GetValue("BgBewilligungStatusCode") == BgBewilligungStatus.Erteilt)
                            {
                                btnBgBudgetResetMaster.Visibility = BarItemVisibility.Always;

                                if (DBUtil.UserHasRight("CtlWhBudget", "I"))
                                {
                                    btnBgBudget.Visibility = BarItemVisibility.Always;
                                }
                            }
                        }
                        else
                        {
                            btnBgBudgetReset.Visibility = BarItemVisibility.Always;

                            if (DBUtil.UserHasRight("CtlWhBudget", "I"))
                            {
                                btnBgBudget.Visibility = BarItemVisibility.Always;
                            }

                            if (DBUtil.UserHasRight("CtlWhBudget", "D"))
                            {
                                btnBgBudgetDelete.Visibility = BarItemVisibility.Always;
                            }
                        }

                        break;

                    case "CtlWhWVEinheit":
                    case "CtlWhKontoauszug":
                    case "CtlWhKlientenabrechnung":
                        if (DBUtil.UserHasRight("CtlWhLeistung", "I"))
                        {
                            btnFaLeistung300.Visibility = BarItemVisibility.Always;
                        }

                        if (DBUtil.UserHasRight("FrmFallZugriff"))
                        {
                            btnFallZugriff.Visibility = BarItemVisibility.Always;
                        }

                        if (DBUtil.UserHasRight("FrmFallInfo"))
                        {
                            btnFallInfo.Visibility = BarItemVisibility.Always;
                        }

                        break;
                }

                SqlQuery qryFaLeistung = DBUtil.OpenSQL(@"
                    SELECT * FROM FaLeistung WHERE FaLeistungID = {0}",
                    kissTree.FocusedNode.GetValue("FaLeistungID"));

                ArrayList alBarItem = new ArrayList(
                    new BarItem[]
                    {
                        btnFaLeistung300, btnFaLeistung301, btnFaLeistung302, btnFaLeistung304,
                        btnFallZugriff, btnFallInfo, btnFallZuteilung, btnFaLeistungDelete
                    });

                foreach (BarItemLink barItemLink in e.Menu.ItemLinks)
                {
                    if (!alBarItem.Contains(barItemLink.Item))
                    {
                        barItemLink.Item.Enabled = DBUtil.IsEmpty(qryFaLeistung["DatumBis"]);
                    }
                }

                // migrierte W's sollen löschbar sein
                btnFaLeistungDelete.Enabled = DBUtil.IsEmpty(qryFaLeistung["DatumBis"]) || !DBUtil.IsEmpty(qryFaLeistung["MigAlteFallNr"]);
            }

            // Fallzugriff/Fallinfo/Fallzuteilung:
            btnFallZugriff.Visibility = BarItemVisibility.Never;
            btnFallInfo.Visibility = BarItemVisibility.Never;
            btnFallZuteilung.Visibility = BarItemVisibility.Always;

            foreach (BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                if (barItemLink.Item.Visibility != BarItemVisibility.Never)
                {
                    return;
                }
            }

            e.Cancel = true;
        }

        private void btnBgBudgetDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (DetailControl is CtlWhBudget)
            {
                try
                {
                    if (!(bool)kissTree.FocusedNode.GetValue("MasterBudget")
                        && (int)kissTree.FocusedNode.GetValue("BgBewilligungStatusCode") < (int)BgBewilligungStatus.Erteilt)
                    {
                        DBUtil.ExecSQLThrowingException(
                            @"
                            EXECUTE spWhBudget_Delete {0}
                            DELETE FROM BgBudget WHERE BgBudgetID = {0}"
                            ,
                            (int)kissTree.FocusedNode.GetValue("BgBudgetID"));

                        FormController.SendMessage("FrmFall", "Action", "RefreshTree");
                    }
                    else
                    {
                        throw new KissInfoException(
                            KissMsg.GetMLMessage(
                                "CtlWhModulTree",
                                "MonatsbudgetLoeschenNichtMoeglich",
                                "Es können nur Monatsbudget im Status 'In Vorbereitung' gelöscht werden",
                                KissMsgCode.MsgInfo));
                    }
                }
                catch (KissCancelException ex)
                {
                    ex.ShowMessage();
                }
            }
        }

        private void btnBgBudgetResetMaster_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (DetailControl is CtlWhBudget)
            {
                ((CtlWhBudget)DetailControl).ResetBudget();
            }
        }

        private void btnBgBudgetReset_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (DetailControl is CtlWhBudget)
            {
                ((CtlWhBudget)DetailControl).ResetBudget();
            }
        }

        private void btnBgBudget_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                object bgBudgetID = DBUtil.ExecuteScalarSQL(@"EXECUTE spWhBudget_Create {0}", (int)kissTree.FocusedNode.GetValue("BgFinanzplanID"));

                if (DBUtil.IsEmpty(bgBudgetID))
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            "CtlWhModulTree",
                            "EnthaeltAlleBudgets",
                            "Der Finanzplan enthält bereits sämtliche Monatsbudgets",
                            KissMsgCode.MsgInfo));
                }

                FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
        }

        private void btnBgFinanzplan1_ItemClick(object sender, ItemClickEventArgs e)
        {
            BgFinanzplanNeu(1);
        }

        private void btnBgFinanzplan2_ItemClick(object sender, ItemClickEventArgs e)
        {
            BgFinanzplanNeu(2);
        }

        private void btnBgFinanzplanDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int bgFinanzplanID = (int)kissTree.FocusedNode.GetValue("BgFinanzplanID");

                DBUtil.ExecSQLThrowingException("EXECUTE spWhFinanzPlan_Delete {0}", bgFinanzplanID);
                DBUtil.ExecSQL("DELETE FROM BgFinanzplan WHERE BgFinanzplanID = {0}", bgFinanzplanID);

                FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
        }

        private void btnFaLeistung300_ItemClick(object sender, ItemClickEventArgs e)
        {
            FaLeistungNeu(300);
        }

        private void btnFaLeistung301_ItemClick(object sender, ItemClickEventArgs e)
        {
            NeueLeistung(301);
        }

        private void btnFaLeistung302_ItemClick(object sender, ItemClickEventArgs e)
        {
            NeueLeistung(302);
        }

        private void btnFaLeistung304_ItemClick(object sender, ItemClickEventArgs e)
        {
            NeueLeistung(304);
        }

        private void btnFaLeistungDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (DetailControl is CtlWhLeistung)
            {
                ((IKissDataNavigator)DetailControl).DeleteData();
            }
        }

        private void btnFallZuteilung_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormController.ShowDialogOnMain("DlgFallZuteilung", BaPersonID);
        }

        private void edtHideAbgeschlosseneW_EditValueChanged(object sender, EventArgs e)
        {
            HideAbgeschlosseneW();
        }

        private void edtHideBeendeteRegWH_EditValueChanged(object sender, EventArgs e)
        {
            HideBeendeteRegWH(kissTree.Nodes);
        }

        #endregion

        #region Methods

        #region Public Methods

        public void DisplayTree(string treeID)
        {
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");

            //ev. Neupositionierung auf neuen Eintrag
            if (treeID != string.Empty)
            {
                TreeListNode node = DBUtil.FindNodeByValue(kissTree.Nodes, treeID, "ID");
                if (node != null)
                {
                    kissTree.FocusedNode = node;
                    node.Expanded = true;
                    kissTree_AfterFocusNode(null, new NodeEventArgs(node));
                }
            }
        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            bool result = base.ReceiveMessage(parameters);
            if (parameters != null && parameters.Count >= 1 && parameters["Action"].Equals("JumpToPath") && kissTree.FocusedNode == null)
            {
                // Nichts ist selektiert
                return false;
            }
            return result;
        }

        public override void Refresh()
        {
            base.Refresh();

            // Falls gewisse Nodes versteckt werden sollen, mach dies hier
            HideAbgeschlosseneW();
            HideBeendeteRegWH(kissTree.Nodes);
        }

        #endregion

        #region Protected Methods

        protected override void OnGettingLayout(KissLayoutEventArgs e)
        {
            base.OnGettingLayout(e);

            KissControlLayout.SaveSimpleProperty(e, edtHideAbgeschlosseneW, "Checked");
            KissControlLayout.SaveSimpleProperty(e, edtHideBeendeteRegWH, "Checked");
        }

        protected override void OnSettingLayout(KissLayoutEventArgs e)
        {
            base.OnSettingLayout(e);

            KissControlLayout.ReadSimpleProperty(e, edtHideAbgeschlosseneW, "Checked");
            KissControlLayout.ReadSimpleProperty(e, edtHideBeendeteRegWH, "Checked");
        }

        #endregion

        #region Private Methods

        private void BgFinanzplanNeu(int whHilfeTypCode)
        {
            // Falls der Benutzer das Spezialrecht für die Erstellung mehrerer grauer FPs nicht hat, muss hier geprüft werden, ob es schon einen grauen FP gibt
            if (!DBUtil.UserHasRight("CtlWhModulTree_ErstellenMehrererGrauerFPs"))
            {
                SqlQuery qryGraueFPs = DBUtil.OpenSQL(@"
                    SELECT AnzahlGraueFPs = COUNT(FPL.FaLeistungID) 
                    FROM dbo.BgFinanzplan FPL
                      INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = FPL.FaLeistungID
                    WHERE FPL.BgBewilligungstatusCode = 1 
                      AND LEI.DatumBis IS NULL 
                      AND FPL.FaLeistungID = {0}
                    GROUP BY FPL.FaLeistungID",
                        kissTree.FocusedNode.GetValue("FaLeistungID"));

                if (qryGraueFPs.Count > 0)
                {
                    // Wir erlauben nur einen grauen FP
                    KissMsg.ShowInfo("Es existiert bereits ein grauer Finanzplan.");
                    return;
                }
            }

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT *
                FROM (SELECT TOP 1
                        GeplantVon       = CASE WHEN EXISTS (SELECT * FROM BgBudget WHERE BgFinanzplanID = SFP.BgFinanzplanID AND MasterBudget = 1)
                                             THEN DateAdd(d, 1, dbo.fnLastDayOf(IsNull(SFP.DatumBis, SFP.GeplantBis)))
                                             ELSE IsNull(SFP.DatumVon, SFP.GeplantVon)
                                           END,
                        DefaultMonths    = CONVERT(int, XLC.Value1)
                      FROM BgFinanzplan      SFP
                        LEFT  JOIN XLOVCode  XLC ON XLC.LOVName = 'WhHilfeTyp' AND XLC.Code = {1}
                      WHERE SFP.FaLeistungID = {0}
                        AND EXISTS (SELECT * FROM BgBudget WHERE BgFinanzplanID = SFP.BgFinanzplanID AND MasterBudget = 1)
                      ORDER BY 1 DESC) TMP

                UNION ALL

                SELECT
                  GeplantVon       = dbo.fnFirstDayOf(CONVERT(datetime, dbo.fnMax(FAL.DatumVon, GetDate()))),
                  DefaultMonths    = CONVERT(int, XLC.Value1)
                FROM FaLeistung        FAL
                  LEFT  JOIN XLOVCode  XLC ON XLC.LOVName = 'WhHilfeTyp' AND XLC.Code = {1}
                WHERE FAL.FaLeistungID = {0}"
                    ,
                    kissTree.FocusedNode.GetValue("FaLeistungID"),
                    whHilfeTypCode);

            DBUtil.ExecSQL(
                "EXECUTE spWhFinanzplan_Create {0}, {1}, {2}, {3}",
                kissTree.FocusedNode.GetValue("FaLeistungID"),
                qry["GeplantVon"],
                ((DateTime)qry["GeplantVon"]).AddMonths((int)qry["DefaultMonths"]).AddDays(-1),
                whHilfeTypCode);

            DateTime geplantVon = (DateTime)qry["GeplantVon"];
            int anzahlLaufendeVerrechnungen = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT Count(*)
                FROM BgSpezkonto SSK
                WHERE SSK.FaLeistungID = {0}
                  AND SSK.BgSpezkontoTypCode = 3 /*Verrechnung*/
                  AND {1} BETWEEN SSK.DatumVon AND IsNull(SSK.DatumBis,'9999-12-31')
                  AND dbo.fnBgSpezkonto(SSK.BgSpezkontoID, 3, default, default) > 0
                  AND EXISTS (SELECT TOP 1 1   --Nur Verrechnungen auf aktiven Ausgabe-Positionsarten ausweisen
                              FROM BgPositionsart
                              WHERE BgKostenartID = SSK.BgKostenartID
                              AND BgKategorieCode IN (2, 3))",
                kissTree.FocusedNode.GetValue("FaLeistungID"),
                geplantVon);

            if (anzahlLaufendeVerrechnungen > 0)
            {
                string text = string.Format("Per geplantem Startdatum des neuen Finanzplans ({0}) besteht eine Verrechnung", geplantVon.ToShortDateString());
                if (anzahlLaufendeVerrechnungen > 1)
                {
                    text = string.Format(
                        "Per geplantem Startdatum des neuen Finanzplans ({0}) bestehen {1} Verrechnungen",
                        geplantVon.ToShortDateString(),
                        anzahlLaufendeVerrechnungen);
                }

                KissMsg.ShowInfo(text);
            }

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void FaLeistungNeu(int faProzessCode)
        {
            int leiBaPersonID = BaPersonID;

            // Prüfen, ob ein offener Fall vorhanden ist
            object obj = DBUtil.ExecuteScalarSQL("SELECT FaFallID FROM FaLeistung WHERE BaPersonID = {0} AND FaProzessCode = 200 AND DatumBis IS NULL", BaPersonID);

            if (obj == null)
            {
                KissMsg.ShowInfo("Ohne aktive Fallführung kann keine neue Wirtschaftliche Hilfe erzeugt werden.");
                return;
            }

            if (faProzessCode == 300)
            {
                DlgWhAuswahlLT300 dlg = new DlgWhAuswahlLT300(BaPersonID);
                dlg.ShowDialog(this);
                if (dlg.UserCancel)
                {
                    return;
                }

                leiBaPersonID = dlg.BaPersonID;
            }

            //sozksc : + Eintrag ins Fallverlaufsprotokoll
            DBUtil.ExecSQL(@"
                INSERT INTO FaLeistung (FaFallID, BaPersonID, ModulID, FaProzessCode, DatumVon, UserID, Creator, Created, Modifier, Modified)
                  SELECT TOP 1 FaFallID, {5}, 3, {2}, dbo.fnDateOf(GetDate()), {1}, {6}, GetDate(), {6}, GetDate()
                  FROM FaFall
                  WHERE BaPersonID = {0}
                  ORDER BY DatumBis, DatumVon DESC

                DECLARE @faLeistungID int
                SET @faLeistungID = SCOPE_IDENTITY()

                INSERT FaJournal (FaFallID, FaLeistungID, BaPersonID, UserID, Text, OrgUnitID)
                  SELECT TOP 1 FaFallID, @faLeistungID, {5}, {1}, {3}, {4}
                  FROM FaFall
                  WHERE BaPersonID = {0}
                  ORDER BY DatumBis, DatumVon DESC",
                BaPersonID,
                Session.User.UserID,
                faProzessCode,
                "Fallaufnahme",
                Session.User["OrgUnitID"],
                leiBaPersonID,
                DBUtil.GetDBRowCreatorModifier()
                );

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            kissTree.MoveFirst();
            kissTree.FocusedNode.Expanded = true;
        }

        private void HideAbgeschlosseneW()
        {
            foreach (TreeListNode node in kissTree.Nodes)
            {
                if ("CtlWhLeistung" == node.GetValue("ClassName") as string)
                {
                    if (Utils.ConvertToBool(node.GetValue("LeistungGeschlossen")) && edtHideAbgeschlosseneW.Checked)
                    {
                        // Verstecke diesen Node
                        node.Visible = false;
                    }
                    else
                    {
                        node.Visible = true;
                    }
                }
            }

            // Speichere die Layout-Einstellungen des Trees. Dies ruft die Methode OnGettingLayout() auf, wobei der Checkbox-Status gespeichert wird
            SaveLayout();
        }

        private void HideBeendeteRegWH(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                if ("CtlWhFinanzplan" == node.GetValue("ClassName") as string)
                {
                    if (Utils.ConvertToBool(node.GetValue("LeistungGeschlossen")) && edtHideBeendeteRegWH.Checked)
                    {
                        // Verstecke diesen Node
                        node.Visible = false;
                    }
                    else
                    {
                        node.Visible = true;
                    }
                }

                // rekursiver Aufruf => Gehe durch alle Leaves des Trees
                HideBeendeteRegWH(node.Nodes);
            }

            // Speichere die Layout-Einstellungen des Trees. Dies ruft die Methode OnGettingLayout() auf, wobei der Checkbox-Status gespeichert wird
            SaveLayout();
        }

        private void NeueLeistung(int prozessCode)
        {
            // FallID holen
            int faFallID;
            object obj = DBUtil.ExecuteScalarSQL("SELECT FaFallID FROM FaLeistung WHERE BaPersonID = {0} AND FaProzessCode = 200 AND DatumBis IS NULL", BaPersonID);

            if (obj == null)
            {
                KissMsg.ShowInfo("Es existiert keine aktive Fallführung oder der Fall ist abgeschlossen.");
                return;
            }

            int.TryParse(obj.ToString(), out faFallID);

            // Schuldner wählen, ausser bei Alimente UeBH und KKBB (kein Schuldner):
            KissLookupDialog dlg = new KissLookupDialog();
            dlg.Text = "Schuldner wählen";
            string sql = string.Format(@"
                SELECT
                  BaPersonID$ = PRS.BaPersonID,
                  Person = PRS.Name + IsNull(', ' + PRS.Vorname,''),
                  Geschlecht = dbo.FnLOVtext('BaGeschlecht', PRS.GeschlechtCode),
                  FT = Convert(bit, case when {1} = PRS.BaPersonID then 1 else 0 end),
                  Geburtsdatum = Convert(varchar, PRS.Geburtsdatum, 104),
                  [Alter] = dbo.FnGetAge(PRS.Geburtsdatum, GetDate()),
                  [Relation zum Fallträger] = IsNull(dbo.fnBaRelationClient({1}, PRS.BaPersonID, GetDate()), '[Fallträger/in]'),
                  [Anzahl Inkassi] = (
                    Select count(*) from FaLeistung L
                    where L.FaFallID = {0} and L.BaPersonID = PRS.BaPersonID and L.FaProzessCode in (405,406,407)),
                  [Anzahl Rückf.] = (
                    Select count(*) from FaLeistung L
                    where L.FaFallID = {0} and L.BaPersonID = PRS.BaPersonID and L.FaProzessCode in (408,409,410))
                FROM FaFallPerson FPR
                LEFT JOIN BaPerson PRS ON PRS.BaPersonID = FPR.BaPersonID
                WHERE FPR.FaFallID = {0}
                ORDER BY
                  CASE WHEN {1} = PRS.BaPersonID THEN 0 ELSE 1 END, [Alter] DESC",
                faFallID,
                BaPersonID);

            if (!dlg.SearchData(sql, null, true))
            {
                return;
            }

            int leiBaPersonID = Utils.ConvertToInt(dlg["BaPersonID$"]);

            if (leiBaPersonID == 0)
            {
                return;
            }

            SqlQuery qry = DBUtil.OpenSQL(@"
                DECLARE @Res INT
                EXEC @Res = dbo.spFaLeistung_Insert {0}, {1}, {2}, {3}, {4}
                SELECT RES = @Res",
                BaPersonID,
                prozessCode,
                Session.User.UserID,
                Session.User["OrgUnitID"],
                leiBaPersonID);
            int res = Utils.ConvertToInt(qry["Res"]);

            string msg = "";

            if (res <= 0)
            {
                msg = "Unbekannter Fehler in spFaLeistung_Insert.";
            }

            switch (res)
            {
                case -1:
                    msg = "Falsche Parameter.";
                    break;
                case -2:
                    msg = "Es existiert keine aktive Fallführung oder der Fall ist abgeschlossen.";
                    break;
                case -3:
                    msg = "Fehler beim Holen der PSCD-Gegenstandsnummer.";
                    break;
                case -4:
                    msg = "Unbekannter Fehler beim Einfügen einer Leistung.";
                    break;
            }

            if (msg == "")
            {
                // kein Fehler
                DisplayTree("CtlIkLeistungAlbv" + res.ToString());
            }
            else
            {
                // Fehlermeldung anzeigen
                KissMsg.ShowInfo(msg);
            }
        }

        #endregion

        #endregion
    }
}