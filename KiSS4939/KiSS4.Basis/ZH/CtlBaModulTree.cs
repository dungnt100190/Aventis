using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Gui.Layout;
using KiSS4.Main.ZH;

namespace KiSS4.Basis.ZH
{
    partial class CtlBaModulTree : KissModulTree
    {
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private bool isFallTraeger;
        private bool treeLoading = true;

        public CtlBaModulTree(int baPersonID, int faFallID, Panel panelDetail)
            : base(baPersonID, faFallID, panelDetail, 1)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            popup_Tree.LinksPersistInfo.AddRange(new[] {
                new LinkPersistInfo(btnNeuePerson),
                new LinkPersistInfo(btnNeueBerechnungsperson),
                new LinkPersistInfo(btnPersonEntfernen),
                new LinkPersistInfo(btnFallZuteilung, true)});

            FillTree();
            kissTree.ExpandAll();
        }

        public CtlBaModulTree()
        {
            InitializeComponent();
        }

        private bool ShowInactivePersons
        {
            set
            {
                var nodeKlientensystem = kissTree.FindNodeByKeyID("CtlBaKlientensystem");
                if (nodeKlientensystem == null)
                {
                    return;
                }

                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in nodeKlientensystem.Nodes)
                {
                    if ("CtlBaPerson".Equals(node.GetValue("ClassName")) && // Person (inaktiv oder aktiv)
                        (bool)node.GetValue("Aktiv") == false)              // nur inaktive Personen
                    {
                        node.Visible = value;
                    }
                }
            }
        }

        public override void Refresh()
        {
            base.Refresh();

            ShowInactivePersons = edtShowInactivePersons.Checked;
            kissTree.ExpandAll();
        }

        public void ShowPerson(int baPersonID)
        {
            var node = DBUtil.FindNodeByID(kissTree.Nodes, string.Format("P{0}", baPersonID));
            if (node != null)
            {
                kissTree.FocusedNode = node;
                node.Expanded = true;
            }
        }

        protected override void kissTree_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e == null || e.Node == null)
            {
                ShowDetail(null);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                IKissView ctl = null;

                if (!Created || treeLoading)
                {
                    return;
                }

                try
                {
                    var personID = (int)kissTree.FocusedNode.GetValue("BaPersonID");
                    var title = kissTree.FocusedNode.GetValue("Name").ToString();

                    isFallTraeger = (personID == BaPersonID);

                    ctl = _showDetail.GetDetailControl(AssemblyLoader.GetType(e.Node.GetValue("ClassName") as string), true);
                    if (ctl == null)
                    {
                        ShowDetail(null);
                        return;
                    }

                    switch (e.Node.GetValue("ClassName") as string)
                    {
                        case "CtlBaPerson":
                            AssemblyLoader.InvokeMethode(ctl, "Init", title, GetIcon(e), personID, BaPersonID, isFallTraeger);
                            ctl.Focus();
                            break;

                        case "CtlBaUebersicht":
                        case "CtlBaKlientensystem":
                        case "CtlBaInvolviertePerson":
                        case "CtlBaInvolvierteStelle":
                        case "CtlBaWohnsituation":
                            AssemblyLoader.InvokeMethode(ctl, "Init", title, GetIcon(e), BaPersonID);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Eintrag ins Log.
                    LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                    // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                    XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

                    ShowDetail(null);
                }
                ShowDetail(ctl, true);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        protected override void OnGettingLayout(KissLayoutEventArgs e)
        {
            base.OnGettingLayout(e);
            KissControlLayout.SaveSimpleProperty(e, edtShowInactivePersons, "Checked");
        }

        protected override void OnSettingLayout(KissLayoutEventArgs e)
        {
            base.OnSettingLayout(e);
            KissControlLayout.ReadSimpleProperty(e, edtShowInactivePersons, "Checked");
        }

        private void barManager_Tree_QueryShowPopupMenu(object sender, QueryShowPopupMenuEventArgs e)
        {
            foreach (BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                barItemLink.Item.Visibility = BarItemVisibility.Never;
            }

            btnFallZuteilung.Visibility = BarItemVisibility.Always;

            if (DBUtil.UserHasRight("DlgErfassungPerson"))
            {
                btnNeuePerson.Visibility = BarItemVisibility.Always;
                btnNeueBerechnungsperson.Visibility = BarItemVisibility.Always;
            }

            if (kissTree.FocusedNode != null &&
                "CtlBaPerson".Equals(kissTree.FocusedNode.GetValue("ClassName")) &&
                !DBUtil.IsEmpty(kissTree.FocusedNode.GetValue("FaFallID_B")) &&
                !(bool)kissTree.FocusedNode.GetValue("IsFallTraeger") &&
                DBUtil.UserHasRight("CtlBaModulTree_PersonEntfernen"))
            {
                btnPersonEntfernen.Caption = string.Format("Person '{0}' entfernen", kissTree.FocusedNode.GetDisplayText("Name"));
                btnPersonEntfernen.Visibility = BarItemVisibility.Always;
            }

            if (e.Menu.ItemLinks.Cast<BarItemLink>().Any(barItemLink => barItemLink.Item.Visibility != BarItemVisibility.Never))
            {
                return;
            }

            e.Cancel = true;
        }

        private void btnFallZuteilung_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormController.ShowDialogOnMain("DlgFallZuteilung", BaPersonID);
        }

        private void btnNeueBerechnungsperson_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new DlgAuswahl
            {
                ShowFilter = true,
                FilterColumnName = "Berechnungsperson"
            };

            if (dlg.BerechnungspersonenSuchen())
            {
                var berechnungsPerson = dlg["BaPersonID"];
                if (berechnungsPerson != null)
                {
                    var berechnungsPersonID = Convert.ToInt32(berechnungsPerson);
                    DlgErfassungPerson.InsertRelation(41 /*Berechnungsperson*/, BaPersonID, berechnungsPersonID, null, null);

                    dlg.Dispose();

                    //refresh Navigator und Neupositionierung auf neue Person
                    Refresh();
                    ShowPerson(berechnungsPersonID);
                }
            }
        }

        private void btnNeuePerson_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new DlgErfassungPerson(BaPersonID);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var baRelatedPersonID = dlg.BaRelatedPersonID;
                dlg.Dispose();

                //refresh Navigator und Neupositionierung auf neue Person
                Refresh();
                ShowPerson(baRelatedPersonID);
            }
        }

        private void btnPersonEntfernen_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM BgFinanzPlan_BaPerson  BPP
                  INNER JOIN BgFinanzPlan   BFP ON BFP.BgFinanzPlanID = BPP.BgFinanzPlanID
                  INNER JOIN FaLeistung     LST ON LST.FaLeistungID = BFP.FaLeistungID
                WHERE BPP.BaPersonID = {0} AND LST.FaFallID = {1}
                  AND IsNull(BFP.DatumBis, BFP.GeplantBis) >= GetDate()",
                kissTree.FocusedNode.GetValue("BaPersonID"),
                kissTree.FocusedNode.GetValue("FaFallID_B")) > 0)
            {
                KissMsg.ShowInfo("CtlBaModulTree", "LoeschenNichtMoeglich", "{0} kann nicht gelöscht werden, da diese Person Haushaltsmitglied in einem aktuellen Finanzplan des Fallträgers ist.", 0, 0, kissTree.FocusedNode.GetDisplayText("Name"));
                return;
            }

            if (!KissMsg.ShowQuestion("CtlBaModulTree", "BeziehungLoeschen",
              "Soll '{0}' entfernt werden ?\r\n\r\n" +
              "(Die Personendaten werden dadurch nicht gelöscht, sondern nur die Beziehung zur Fallträgerin.)",
              0, 0, true, kissTree.FocusedNode.GetDisplayText("Name")))
            {
                return;
            }

            var hasErrors = true;
            try
            {
                Session.BeginTransaction();

                if (DBUtil.ExecSQL(@"
                    --DELETE BaPerson_Relation
                    --WHERE (BaPersonID_1 = {0} AND BaPersonID_2 = {1}) OR
                    --      (BaPersonID_1 = {1} AND BaPersonID_2 = {0})

                    DELETE FROM FaFallPerson WHERE BaPersonID = {1} AND FaFallID = {2}",
                    BaPersonID,
                    kissTree.FocusedNode.GetValue("BaPersonID"),
                    kissTree.FocusedNode.GetValue("FaFallID_B")) > 0)
                {
                    Session.Commit();
                    hasErrors = false;
                }
                else
                    Session.Rollback();
            }
            catch
            {
                Session.Rollback();
            }

            if (!hasErrors)
            {
                InsertFVProtokoll();
                kissTree.DeleteNode(kissTree.FocusedNode);
            }
            else
            {
                KissMsg.ShowInfo("Die Person konnte nicht gelöscht werden.");
            }
        }

        private void CtlBaModulTree_Load(object sender, EventArgs e)
        {
            if (kissTree.Nodes.Count > 1)
            {
                treeLoading = false;
                ShowInactivePersons = edtShowInactivePersons.Checked;
                ShowPerson(BaPersonID);
            }
        }

        private void edtShowInactivePersons_EditValueChanged(object sender, EventArgs e)
        {
            ShowInactivePersons = edtShowInactivePersons.Checked;
            // Speichere die Layout-Einstellungen des Trees. Dies ruft die Methode OnGettingLayout() auf, wobei der Checkbox-Status gespeichert wird
            SaveLayout();
        }

        private void InsertFVProtokoll()
        {
            // Einen neuen Eintrag im Fallverlaufsprotokoll einfügen
            // -----------------------------------------------------
            // Parameter:     {0}=FaFallID, {1}=FaLeistungID, {2}=BaPersonID, {3}=UserID, {4}=FaJournalCode, {5}=Text
            // Info:          FaFallID und BaPersonID können NULL sein, wenn FaLeistungID gegeben ist.
            // Rückgabewert:  Eingefügte FaJournalID des neuen Eintrags
            DBUtil.ExecuteScalarSQL(@"
                EXEC spFaInsertFVProtokoll {0}, {1}, {2}, {3}, {4}, {5}",
                    kissTree.FocusedNode.GetValue("FaFallID_B"), 	// FaFallID
                    DBNull.Value,									// FaLeistungID
                    kissTree.FocusedNode.GetValue("BaPersonID"),	// BaPersonID
                    Session.User.UserID,							// UserID
                    1, 												// FaJournalCode (default = 1)
                    "Entfernung aus Klientensystem"					// Text
                );
        }
    }
}