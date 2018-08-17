using System;
using System.Windows.Forms;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis.IBE
{
    partial class CtlBaModulTree : KissModulTree
    {
        private bool isFallTraeger;

        public CtlBaModulTree(int baPersonID, Panel panDetail)
            : base(baPersonID, panDetail, Gui.ModulID.B)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Popup-Menu erstellen:
            popup_Tree.LinksPersistInfo.Clear();
            popup_Tree.LinksPersistInfo.AddRange(new[] {
                // Personen hinzufügen / löschen :
				new DevExpress.XtraBars.LinkPersistInfo(btnNeuePerson),
				new DevExpress.XtraBars.LinkPersistInfo(btnPersonEntfernen, true)
				});

            FillTree();
        }

        public CtlBaModulTree()
        {
            InitializeComponent();
        }

        public override void Refresh()
        {
            base.Refresh();

            if (kissTree.Nodes.Count > 1)
            {
                kissTree.Nodes[1].Expanded = true;
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
                var className = e.Node.GetValue("ClassName") as string;

                var personID = (int)e.Node.GetValue("BaPersonID");
                isFallTraeger = (personID == BaPersonID);

                var titel = e.Node.GetValue("Name") as string;

                // Neue WPF Masken (XAML)
                var initParams = new InitParameters
                {
                    BaPersonID = personID as int?,
                    Title = titel,
                };
                var xclassID = Kiss.Infrastructure.IoC.Container.Resolve<ViewFactory>().GetClassID(className);
                if (xclassID.HasValue)
                {
                    var view = new CtlWpfHost(xclassID.Value, initParams);
                    ShowDetail(view, true);
                    return;
                }

                var ctl = _showDetail.GetDetailControl(AssemblyLoader.GetType(className), true);

                if (ctl == null)
                {
                    ShowDetail(ctl);
                    return;
                }

                switch (className)
                {
                    case "CtlBaHaushalt":
                        AssemblyLoader.InvokeMethode(ctl, "Init", "", GetIcon(e), personID, this, isFallTraeger);
                        break;

                    case "CtlBaPerson":
                        AssemblyLoader.InvokeMethode(ctl, "Init", "", GetIcon(e), personID, BaPersonID, isFallTraeger);
                        break;

                    case "CtlFinanzen":
                    case "CtlBaGesundheit":
                    case "CtlMassnahmen":
                    case "CtlSozialhilfe":
                        AssemblyLoader.InvokeMethode(ctl, "Init", "", GetIcon(e), personID, isFallTraeger);
                        break;

                    case "CtlBaArbeit":
                        AssemblyLoader.InvokeMethode(ctl, "Init", "", GetIcon(e), personID);
                        break;

                    case "CtlBaInstitutionenFachpersonen":
                        AssemblyLoader.InvokeMethode(ctl, "Init", titel, GetIcon(e), personID);
                        break;
                }

                ShowDetail(ctl);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnNeuePerson_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new Main.DlgErfassungPerson(BaPersonID);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int baPersonID = dlg.NewBaPersonID;
                dlg.Dispose();

                //refresh Navigator und Neupositionierung auf neuen Fall
                kissTree.DataSource = null; //sonst Exception: open DataReader!
                FillTree();
                var node = DBUtil.FindNodeByValue(kissTree.Nodes, baPersonID.ToString(), "BaPersonID");
                if (node != null)
                {
                    kissTree.FocusedNode = node;
                    node.Expanded = true;
                }
            }
        }

        private void btnPersonEntfernen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ((int)DBUtil.ExecuteScalarSQL(@"
				SELECT COUNT(*)
				FROM BgFinanzPlan_BaPerson  BPP
				  INNER JOIN BgFinanzPlan   BFP ON BFP.BgFinanzPlanID = BPP.BgFinanzPlanID
				  INNER JOIN FaLeistung     LST ON LST.FaLeistungID = BFP.FaLeistungID
				WHERE BPP.BaPersonID = {0} AND LST.BaPersonID = {1}
				  AND IsNull(BFP.DatumBis, BFP.GeplantBis) >= GetDate()"
                , kissTree.FocusedNode.GetValue("BaPersonID"), BaPersonID) > 0)
            {
                KissMsg.ShowInfo("CtlBaModulTree", "LoeschenNichtMoeglich", "{0} kann nicht gelöscht werden, da diese Person Haushaltsmitglied in einem aktuellen Finanzplan des Fallträgers ist.", 0, 0, kissTree.FocusedNode.GetDisplayText("Name"));
                return;
            }

            if (!KissMsg.ShowQuestion("CtlBaModulTree", "BeziehungLoeschen", "Soll '{0}' entfernt werden ?\r\n\r\n(Die Personendaten werden dadurch nicht gelöscht, sondern nur die Beziehung zur Fallträgerin.)", 0, 0, true, kissTree.FocusedNode.GetDisplayText("Name")))
                return;

            var hasErrors = true;
            try
            {
                Session.BeginTransaction();

                if (DBUtil.ExecSQL(@"
					DELETE BaPerson_Relation
					WHERE (BaPersonID_1 = {0} AND BaPersonID_2 = {1}) OR
					      (BaPersonID_1 = {1} AND BaPersonID_2 = {0})

			--		DELETE FROM FaFallPerson WHERE BaPersonID = {1}", // ZH- only
                    BaPersonID,
                    kissTree.FocusedNode.GetValue("BaPersonID")) > 0)
                {
                    Session.Commit();
                    hasErrors = false;
                }
            }
            catch
            {
                Session.Rollback();
            }

            if (!hasErrors)
            {
                kissTree.DeleteNode(kissTree.FocusedNode);
            }
            else
            {
                KissMsg.ShowInfo("Die Person konnte nicht gelöscht werden.");
            }
        }

        private void CtlBaModulTree_Load(object sender, EventArgs e)
        {
            //Expand Fallträger
            if (kissTree.Nodes.Count > 1)
            {
                kissTree.Nodes[1].Expanded = true;
            }
        }

        private void popup_Tree_BeforePopup(object sender, EventArgs e)
        {
            var caseID = Utils.ConvertToInt(kissTree.FocusedNode.GetValue("FaFallID"));
            var leistgID = Utils.ConvertToInt(kissTree.FocusedNode.GetValue("FaLeistungID"));
            var persID = Utils.ConvertToInt(kissTree.FocusedNode.GetValue("BaPersonID"));
            var className = Utils.ConvertToString(kissTree.FocusedNode.GetValue("ClassName"));
            var persName = Utils.ConvertToString(kissTree.FocusedNode.GetValue("Name"));

            var qry = DBUtil.OpenSQL(@"
				Select
				  CaseIsClosed = case when F.DatumBis is Null then 0 else 1 end,
				  IstAlim = IsNull((Select top 1 1 from FaLeistung
				    where FaLeistungID={1} and FaProzessCode=201), 0),
				  HatF = IsNull((select top 1 1 from FaLeistung L1
				    where L1.FaFallID=F.FaFallID and L1.ModulID=2 and L1.FaProzessCode=200), 0),
				  HatFAlim = IsNull((select top 1 1 from FaLeistung L2
				    where L2.FaFallID=F.FaFallID and L2.ModulID=2 and L2.FaProzessCode=201), 0)
				from FaFall F
				where F.FaFallID={0} ",
                caseID,
                leistgID);

            var caseIsClosed = (Utils.ConvertToInt(qry["CaseIsClosed"]) == 1);
            var istAlim = (Utils.ConvertToInt(qry["IstAlim"]) == 1);
            var hatF = (Utils.ConvertToInt(qry["HatF"]) == 1);
            var hatFAlim = (Utils.ConvertToInt(qry["HatFAlim"]) == 1);

            var isVisible = (!caseIsClosed && persID > 0 && !isFallTraeger && DBUtil.UserHasRight("DlgNeuePerson")
                              && className == "CtlBaPerson"
                             );
            if (isVisible)
            {
                btnPersonEntfernen.Caption = "Person '" + persName + "' löschen.";
            }

            SetPopupMenuVisibility(btnPersonEntfernen, isVisible);
        }

        private void SetPopupMenuVisibility(DevExpress.XtraBars.BarButtonItem btn, bool isVisible)
        {
            btn.Visibility = isVisible ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
        }
    }
}