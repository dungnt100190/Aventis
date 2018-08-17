using System;
using System.Collections.Specialized;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung
{
    /// <summary>
    /// Control, used for displaying case-tree
    /// </summary>
    public partial class CtlFaModulTree : KissModulTree
    {
        #region Fields

        #region Private Static Fields

        private static readonly SqlQuery _qryPhase = DBUtil.OpenSQL(@"
            SELECT *
            FROM dbo.XLOVCode WITH (READUNCOMMITTED)
            WHERE LOVName = {0}", "DynaPhase");

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly CtlFaSozialSystem _ctlFaSozialSystem;

        #endregion

        #region Private Fields

        private bool _themenUpdate;

        #endregion

        #endregion

        #region Constructors

        public CtlFaModulTree(int baPersonID, Panel panDetail)
            : base(baPersonID, panDetail, 2)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            _ctlFaSozialSystem = new CtlFaSozialSystem();
            _ctlFaSozialSystem.DisplayItemDoubleClick += CtlFaSozialSystem_DisplayItemDoubleClick;

            //Replace Captions for popup menu entries
            foreach (System.Data.DataRow row in _qryPhase.DataTable.Select("Value1 IS NOT NULL"))
            {
                switch ((int)row["Code"])
                {
                    case 1:
                        btnNewIntake.Caption = row["Value1"].ToString();
                        break;

                    case 2:
                        btnNewBeratungsphase.Caption = row["Value1"].ToString();
                        break;
                }
            }

            HideThemenFilter();
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                if (_ctlFaSozialSystem != null)
                    _ctlFaSozialSystem.Dispose();
            }
            base.Dispose(disposing);

            ActiveSQLQuery = null;
        }

        #endregion

        #region Properties

        public bool IsLogischesLoeschen
        {
            get
            {
                bool result = DBUtil.GetConfigBool(@"System\Fallfuehrung\LogischesLoeschen", false);
                return result;
            }
        }

        #endregion

        #region EventHandlers

        protected override void kissTree_AfterFocusNode(object sender, NodeEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // handle empty node
                if (e == null || e.Node == null)
                {
                    return;
                }

                var className = e.Node.GetValue("ClassName") as string;

                if (className != null)
                {
                    IKissView ctrl = null;
                    bool forceDispose = false;

                    string id = e.Node.GetValue("ID") as string;
                    string name = e.Node.GetValue("Name") as string;

                    object faFallID = e.Node.GetValue("FaFallID");
                    object faLeistungID = e.Node.GetValue("FaLeistungID");
                    object faPhaseID = e.Node.GetValue("FaPhaseID");
                    object baPersonID = e.Node.GetValue("BaPersonID");

                    // Neue WPF Masken (XAML)
                    var initParams = new InitParameters
                                         {
                                             BaPersonID = baPersonID as int?,
                                             FaLeistungID = faLeistungID as int?,
                                             Title = name,
                                             FaFallID = faFallID as int?,
                                         };
                    var xclassID = Kiss.Infrastructure.IoC.Container.Resolve<ViewFactory>().GetClassID(className);
                    if (xclassID.HasValue)
                    {
                        var view = new CtlWpfHost(xclassID.Value, initParams);
                        ShowDetail(view, true);
                        return;
                    }

                    var type = AssemblyLoader.GetType(className);
                    if (CtlWpfMask.IsWpfView(type))
                    {
                        ctrl = CtlWpfMask.CreateWpfView(type, initParams);
                        ShowDetail(ctrl, true); //Force dispose auf true, sonst gibt es ein Memory Leak.
                        return;
                    }

                    if (className == "CtlFaSozialSystem")
                    {
                        ctrl = _ctlFaSozialSystem;
                    }
                    else if (type != null)
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
                        case "CtlDynaMask":
                            string maskName = e.Node.GetValue("MaskName") as string;
                            //string appCode = e.Node.GetValue("AppCode") as string;
                            //object prozessCode = e.Node.GetValue("ProzessCode");
                            //object system = e.Node.GetValue("System");

                            string themenFilter = editThemenfilter.Checked ? editThemen.EditValue : "";

                            CtlDynaMask ctlDynaMask = (CtlDynaMask)ctrl;
                            ctlDynaMask.Init(name, GetIcon(e), (int)faLeistungID, DBUtil.IsEmpty(faPhaseID) ? 0 : (int)faPhaseID, maskName,
                                            editThemenfilter.Checked, themenFilter);

                            ShowDetail(ctlDynaMask, true);

                            ctlDynaMask.ResizeControls();
                            return;

                        case "CtlFaBeratungsperiode":
                        case "CtlFaZeitlichePlanung":
                            if (faLeistungID is Int32)
                            {
                                AssemblyLoader.InvokeMethode(ctrl, "Init", name, GetIcon(e), (int)faLeistungID);
                            }
                            forceDispose = true;
                            break;

                        case "CtlFaBeratungsphase":
                            if (faPhaseID is int)
                            {
                                AssemblyLoader.InvokeMethode(ctrl, "Init", name, GetIcon(e), (int)faPhaseID);
                            }
                            break;

                        case "CtlFaAktennotiz":
                        case "CtlFaDokumente":
                        case "CtlFaDokumentAblage":
                            forceDispose = true;
                            AssemblyLoader.InvokeMethode(ctrl, "Init", name, GetIcon(e), (int)baPersonID, (int)faLeistungID);
                            break;

                        case "CtlFaSozialSystem":
                            if (id == null)
                            {
                                break;
                            }

                            if (id.StartsWith("S"))
                            {
                                _ctlFaSozialSystem.PersonId = BaPersonID;
                                ShowDetail(_ctlFaSozialSystem);
                                ApplicationFacade.DoEvents();
                                try
                                {
                                    _ctlFaSozialSystem.FallId = -1; //select main person
                                }
                                catch { }
                            }
                            else if (id.StartsWith("F"))
                            {
                                // Fälle des Sozialsystems
                                ShowDetail(_ctlFaSozialSystem);
                                try
                                {
                                    // due to switch from FaFallID to FaLeistungID, we now have to use FaLeistungID
                                    _ctlFaSozialSystem.FallId = Convert.ToInt32(e.Node.GetValue("FaLeistungID"));
                                }
                                catch { }
                            }
                            break;

                        case "CtlFaWeisung":
                            if (faLeistungID is Int32)
                            {
                                AssemblyLoader.InvokeMethode(ctrl, "Init", name, GetIcon(e), (int)faLeistungID, (int)faFallID, (int)baPersonID);
                            }
                            forceDispose = true;
                            break;

                        case "CtlPendenzenVerwaltung":
                            string sqlFilter = e.Node.GetValue("SqlFilter") as string;
                            if (faFallID != null && faLeistungID != null)
                            {
                                AssemblyLoader.InvokeMethode(ctrl, "Init", null, faFallID as int?, faLeistungID as int?, AccessPendenzen.Leistung);
                                AssemblyLoader.InvokeMethode(ctrl, "CustomSearch", sqlFilter);
                            }

                            break;

                        default:
                            try
                            {
                                AssemblyLoader.InvokeMethode(ctrl, "Init", name, GetIcon(e));
                            }
                            catch { }
                            break;
                    }

                    ShowDetail(ctrl, forceDispose);
                }
                else
                {
                    ShowDetail(null);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void barManager_Tree_QueryShowPopupMenu(object sender, QueryShowPopupMenuEventArgs e)
        {
            // need to save data before showing menu (due to delete and new entry --> cannot leave node until saved) --> also see #5717
            if (DetailControl != null)
            {
                try
                {
                    if (!((IKissDataNavigator)DetailControl).SaveData())
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                catch
                {
                    e.Cancel = true;
                    return;
                }
            }

            foreach (BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                barItemLink.Item.Visibility = BarItemVisibility.Never;
            }

            if (DBUtil.UserHasRight("FaNavigNewIntake"))
            {
                btnNewIntake.Visibility = BarItemVisibility.Always;
            }

            if (DBUtil.UserHasRight("FaNavigNewPhase"))
            {
                btnNewBeratungsphase.Visibility = BarItemVisibility.Always;
            }

            bool isPeriode = kissTree.FocusedNode != null &&
                             kissTree.FocusedNode.GetValue("ClassName").ToString() == "CtlFaBeratungsperiode";

            bool isPhase = kissTree.FocusedNode != null &&
                           kissTree.FocusedNode.GetValue("ClassName").ToString() == "CtlFaBeratungsphase" &&
                           kissTree.FocusedNode.ParentNode != null &&
                           kissTree.FocusedNode.ParentNode.GetValue("ClassName").ToString() == "CtlFaBeratungsperiode";

            int owner = -1;

            if (isPeriode)
            {
                owner = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT UserID
                    FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                    WHERE FaLeistungID = {0}", kissTree.FocusedNode.GetValue("FaLeistungID")));
            }

            if (isPhase)
            {
                owner = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT UserID
                    FROM dbo.FaPhase WITH (READUNCOMMITTED)
                    WHERE FaPhaseID = {0}", kissTree.FocusedNode.GetValue("FaPhaseID")));
            }

            bool userIsOwner = owner == Session.User.UserID;

            if ((isPeriode || isPhase) && DBUtil.UserHasRight("FrmFallZugriff"))
            {
                btnFallZugriff.Visibility = BarItemVisibility.Always;
            }

            if ((isPeriode || isPhase) && DBUtil.UserHasRight("FrmFallInfo"))
            {
                btnFallInfo.Visibility = BarItemVisibility.Always;
            }

            if (isPeriode && userIsOwner && DBUtil.UserHasRight("FaNavigDeletePeriode"))
            {
                btnDelete.Visibility = BarItemVisibility.Always;
            }

            if (isPhase && userIsOwner && DBUtil.UserHasRight("FaNavigDeletePhase"))
            {
                btnDelete.Visibility = BarItemVisibility.Always;
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

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            // ---- Fallverlauf ----
            if (kissTree.FocusedNode != null &&
                kissTree.FocusedNode.GetValue("ClassName").ToString() == "CtlFaBeratungsperiode")
            {
                int faLeistungId = Convert.ToInt32(kissTree.FocusedNode.GetValue("FaLeistungID"));
                string name = kissTree.FocusedNode.GetDisplayText("Name");
                DateTime aufnahme = (DateTime)kissTree.FocusedNode.GetValue("Aufnahme");

                DeleteFallverlauf(faLeistungId, name, aufnahme);

                // done
                return;
            }

            // ---- Phase ----
            if (kissTree.FocusedNode != null &&
                kissTree.FocusedNode.GetValue("ClassName").ToString() == "CtlFaBeratungsphase" &&
                kissTree.FocusedNode.ParentNode != null &&
                kissTree.FocusedNode.ParentNode.GetValue("ClassName").ToString() == "CtlFaBeratungsperiode")
            {
                // Phase löschen
                int faPhaseId = Convert.ToInt32(kissTree.FocusedNode.GetValue("FaPhaseID"));
                string name = kissTree.FocusedNode.GetDisplayText("Name");
                DateTime aufnahme = (DateTime)kissTree.FocusedNode.GetValue("Aufnahme");

                DeletePhase(faPhaseId, name, aufnahme);
            }
        }

        private void btnNewBeratungsphase_ItemClick(object sender, ItemClickEventArgs e)
        {
            NeuePhase(2);
        }

        private void btnNewIntake_ItemClick(object sender, ItemClickEventArgs e)
        {
            NeuePhase(1);
        }

        private void btnThemen_Click(object sender, EventArgs e)
        {
            _themenUpdate = true;

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in editThemen.Items)
            {
                if (sender == btnAlleThemen)
                {
                    item.CheckState = CheckState.Checked;
                }

                if (sender == btnKeineThemen)
                {
                    item.CheckState = CheckState.Unchecked;
                }
            }

            _themenUpdate = false;
            ApplyThemenFilter();
        }

        private void CtlFaModulTree_DetailChanged(object sender, EventArgs e)
        {
            //Only display the 'Themenfilter', if there is a Dynamask holding any controls
            if (DetailControl is CtlDynaMask
                && DetailControl.Controls.Count != 0)
            {
                ShowThemenFilter();
            }
            else
            {
                HideThemenFilter();
            }
        }

        private void CtlFaModulTree_Load(object sender, EventArgs e)
        {
            DisplayTree(-1);

            //auf obersten Fallverlauf positionieren
            if (kissTree.Nodes.Count > 1)
            {
                kissTree.FocusedNode = kissTree.Nodes[1];
            }
            else
            {
                ShowDetail(_ctlFaSozialSystem);
            }

            DetailChanged += CtlFaModulTree_DetailChanged;
        }

        private void CtlFaSozialSystem_DisplayItemDoubleClick(object sender, DisplayItemDoubleClickEventArgs e)
        {
            if (e.Person == null)
            {
                return;
            }

            FormController.SendMessage("FrmFall", "Action", "ShowFall",
                "BaPersonID", e.Person.PersonId,
                "ModulID", Gui.ModulID.F);
        }

        private void editThemen_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (_themenUpdate)
            {
                return;
            }

            ApplyThemenFilter();
        }

        private void editThemenfilter_CheckedChanged(object sender, EventArgs e)
        {
            SetThemenLayout();
            ApplyThemenFilter();
        }

        private void editThemenfilter_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //Detaildaten müssen zuerst gespeichert werden, bevor Themenfilter ein/aus
            if (DetailControl is CtlDynaMask)
            {
                e.Cancel = !DetailControl.OnSaveData();
            }
        }

        private void kissTree_DoubleClick(object sender, EventArgs e)
        {
            if (kissTree.FocusedNode == null)
            {
                return;
            }

            // Fälle des Sozialsystems
            if (kissTree.FocusedNode != null && kissTree.FocusedNode.GetValue("ID").ToString().StartsWith("F"))
            {
                try
                {
                    Int32 faLeistungID = (Int32)kissTree.FocusedNode.GetValue("FaLeistungID");

                    SqlQuery qry = DBUtil.OpenSQL(@"
                            SELECT BaPersonID,
                                   ModulID
                            FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                            WHERE FaLeistungID = {0}", faLeistungID);

                    if (qry.Count > 0)
                    {
                        FormController.SendMessage("FrmFall", "Action", "ShowFall",
                            "BaPersonID", qry["BaPersonID"],
                            "ModulID", qry["ModulID"]);
                    }
                }
                catch { }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            switch (parameters[FormController.Param.ACTION] as string)
            {
                case FormController.Action.JUMP_TO_PATH:
                    // Wenn der TreeNodeID-Parameter leer ist, wird er mit dem Sprung auf CtlFaBeratungsperiode (Leistung) gefüllt
                    if (DBUtil.IsEmpty(parameters[FormController.Param.TREE_NODE_ID]) &&
                        !DBUtil.IsEmpty(parameters[FormController.Param.FA_LEISTUNG_ID]))
                    {
                        parameters[FormController.Param.TREE_NODE_ID] = typeof(CtlFaBeratungsperiode).Name + parameters[FormController.Param.FA_LEISTUNG_ID];
                    }
                    break;
            }

            return base.ReceiveMessage(parameters);
        }

        #endregion

        #region Private Methods

        private void ApplyThemenFilter()
        {
            if (DetailControl is CtlDynaMask)
            {
                ((CtlDynaMask)DetailControl).SetThemenFilter(editThemenfilter.Checked, editThemen.EditValue);
            }
        }

        private bool DeleteFallverlauf(int faLeistungId, string name, DateTime aufnahme)
        {
            // get data used to check various things first (e.g. Periode darf nicht abgeschlossen sein)
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT DatumBis,
                        CountPhase        = (SELECT COUNT(1)
                                            FROM dbo.FaPhase WITH (READUNCOMMITTED)
                                            WHERE FaLeistungID = FAL.FaLeistungID),
                        CountDatenErfasst = (SELECT COUNT(1)
                                            FROM dbo.FaWeisung WITH (READUNCOMMITTED)
                                            WHERE FaLeistungID = FAL.FaLeistungID)
                                            +
                                            (SELECT COUNT(1)
                                            FROM dbo.DynaValue WITH (READUNCOMMITTED)
                                            WHERE FaLeistungID = FAL.FaLeistungID)
                                            +
                                            (SELECT COUNT(1)
                                                FROM dbo.FaAktennotizen WITH (READUNCOMMITTED)
                                                WHERE FaLeistungID = FAL.FaLeistungID)
                                            +
                                            (SELECT COUNT(1)
                                                FROM dbo.FaDokumente WITH (READUNCOMMITTED)
                                                WHERE FaLeistungID = FAL.FaLeistungID),
                        HasOtherModul     = CASE
                                                WHEN (SELECT COUNT(DISTINCT ModulID)
                                                    FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                                    WHERE BaPersonID = FAL.BaPersonID
                                                        AND DatumBis IS NULL)
                                                    > 1 -- Anderen Modul als 'F'
                                                THEN 1
                                                ELSE 0
                                            END,
                        HasClosedModul    = CASE
                                                WHEN EXISTS(SELECT TOP 1 1
                                                            FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                                            WHERE BaPersonID = FAL.BaPersonID
                                                            AND DatumBis IS NOT NULL
                                                            AND ModulID <> 2)
                                                THEN 1
                                                ELSE 0
                                            END,
                        HasClosedF        = CASE
                                                WHEN EXISTS(SELECT TOP 1 1
                                                            FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                                            WHERE BaPersonID = FAL.BaPersonID
                                                            AND DatumBis IS NOT NULL
                                                            AND ModulID = 2)
                                                THEN 1
                                                ELSE 0
                                            END

                FROM dbo.FaLeistung FAL WITH (READUNCOMMITTED)
                WHERE FAL.FaLeistungID = {0};", faLeistungId);

            if (qry.IsEmpty)
            {
                return false;
            }

            if (!DBUtil.IsEmpty(qry["DatumBis"]))
            {
                KissMsg.ShowInfo(Name,
                                 "LoeschenNichtMoeglich_v01",
                                 "Dieser Fallverlauf kann nicht gelöscht werden, da dieser bereits geschlossen oder archiviert ist!");
                return false;
            }

            if (Convert.ToInt32(qry["CountPhase"]) > 0)
            {
                KissMsg.ShowInfo(Name,
                                 "PhasenVorhanden_v01",
                                 "Dieser Fallverlauf kann nicht gelöscht werden, da dieser noch {0} Phase(n) enthält!",
                                 qry["CountPhase"].ToString());
                return false;
            }

            if (Convert.ToInt32(qry["CountDatenErfasst"]) > 0)
            {
                KissMsg.ShowInfo(Name,
                                 "DatenErfasst_v01",
                                 "Dieser Fallverlauf kann nicht gelöscht werden, da bereits Daten erfasst worden sind!");
                return false;
            }

            if (Convert.ToBoolean(qry["HasOtherModul"]))
            {
                KissMsg.ShowInfo(Name,
                                 "HatAndereModul_v01",
                                 "Dieser Fallverlauf kann nicht gelöscht werden, da andere Module vorhanden sind!");
                return false;
            }

            if (Convert.ToBoolean(qry["HasClosedModul"]))
            {
                if (!Convert.ToBoolean(qry["HasClosedF"]))
                {
                    KissMsg.ShowInfo(Name,
                                     "HatAndereModul_v01",
                                     "Dieser Fallverlauf kann nicht gelöscht werden, da andere Module vorhanden sind!");
                    return false;
                }
            }

            bool successDelete = false;

            // confirm delete
            if (KissMsg.ShowQuestion(Name,
                                     "DatenFallverlaufLoeschen_v01",
                                     "Sollen alle Daten der {0} '{1}' gelöscht werden?",
                                     true,
                                     name,
                                     aufnahme.ToString("dd.MM.yyyy")))
            {
                Session.BeginTransaction();

                try
                {
                    DBUtil.ExecSQLThrowingException(@"
                        DELETE dbo.DynaValue
                        WHERE FaLeistungID = {0};", faLeistungId);

                    DBUtil.ExecSQLThrowingException(@"
                        DELETE dbo.XTask
                        WHERE FaLeistungID = {0};", faLeistungId);

                    DBUtil.ExecSQLThrowingException(@"
                        DELETE dbo.FaZeitlichePlanung
                        WHERE FaLeistungID = {0};", faLeistungId);

                    DBUtil.ExecSQLThrowingException(@"
                        DELETE dbo.FaLeistung
                        WHERE FaLeistungID = {0};", faLeistungId);

                    successDelete = true;
                    Session.Commit();
                }
                catch (Exception ex)
                {
                    Session.Rollback();
                    successDelete = false;

                    KissMsg.ShowError(Name,
                                      "ErrorDeleteFallverlauf_v01",
                                      "Es ist ein Fehler beim Löschen des Fallverlaufs aufgetreten.\r\n\r\nMöglicherweise sind noch abhängige Daten vorhanden, welche das Löschen verhindern.",
                                      ex);
                }
                finally
                {
                    FormController.SendMessage("FrmFallNavigator", "Action", "RefreshTree");
                    FormController.SendMessage("FrmFall", "Action", "CloseActiveFall");
                }
            }

            return successDelete;
        }

        private bool DeletePhase(int faPhaseId, string name, DateTime aufnahme)
        {
            bool successDelete = false;

            // confirm delete
            if (KissMsg.ShowQuestion(Name,
                                     "DatenPhaseLoeschen",
                                     "Sollen alle Daten der Phase '{0} {1}' gelöscht werden?",
                                     true,
                                     name,
                                     aufnahme.ToString("dd.MM.yyyy")))
            {
                Session.BeginTransaction();

                try
                {
                    DBUtil.ExecSQLThrowingException(@"
                        DELETE dbo.DynaValue
                        WHERE FaPhaseID = {0};", faPhaseId);

                    DBUtil.ExecSQLThrowingException(@"
                        DELETE dbo.FaPhase
                        WHERE FaPhaseID = {0};", faPhaseId);

                    kissTree.DeleteNode(kissTree.FocusedNode);

                    successDelete = true;
                    Session.Commit();
                }
                catch (Exception ex)
                {
                    Session.Rollback();
                    successDelete = false;

                    KissMsg.ShowError(Name,
                                      "ErrorDeletePhase",
                                      "Es ist ein Fehler beim Löschen der Phase aufgetreten.\r\n\r\nMöglicherweise sind noch abhängige Daten vorhanden, welche das Löschen verhindern.",
                                      ex);

                    // refresh tree because we removed node above
                    FormController.SendMessage("FrmFall", "Action", "RefreshTree");
                }
            }

            return successDelete;
        }

        private void DisplayTree(Int32 newFaPhaseID)
        {
            kissTree.DataSource = null; //sonst Exception: open DataReader!
            FillTree();

            // obersten Fallverlauf expandieren
            if (kissTree.Nodes.Count > 1)
            {
                kissTree.Nodes[1].Expanded = true; // Fallverlauf

                // Dokumentation und jüngste Phase in oberster Beratungsperiode expandieren
                if (kissTree.Nodes.Count > 1)
                {
                    if (kissTree.Nodes[1].Nodes.Count > 0)
                    {
                        kissTree.Nodes[1].Nodes[0].Expanded = true; // Dokumentation
                    }

                    if (kissTree.Nodes[1].Nodes.Count > 1)
                    {
                        kissTree.Nodes[1].Nodes[1].Expanded = true; // jüngste Phase
                    }
                }
            }

            //ev. Neupositionierung auf neuen Eintrag
            if (newFaPhaseID > 0)
            {
                TreeListNode node = DBUtil.FindNodeByValue(kissTree.Nodes, newFaPhaseID.ToString(), "FaPhaseID");
                if (node != null)
                {
                    kissTree.FocusedNode = node;
                    node.Expanded = true;
                }
            }
        }

        /// <summary>
        /// Versteckt den Themenfilter.
        /// </summary>
        private void HideThemenFilter()
        {
            panelThemen.Visible = false;
            panelThemenFilter.Visible = false;
        }

        private void NeuePhase(Int32 faPhaseCode)
        {
            // jüngsten FF-Fall suchen
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT TOP 1
                       FaLeistungID,
                       DatumBis
                FROM FaLeistung
                WHERE BaPersonID = {0} AND
                      ModulID = 2
                ORDER BY DatumVon DESC", BaPersonID);

            if (qry.Count == 0)
            {
                return;
            }

            if (!DBUtil.IsEmpty(qry["DatumBis"]))
            {
                KissMsg.ShowInfo(Name, "FallverlaufBereitsAbgeschlossen", "Der aktuellste Fallverlauf ist bereits abgeschlossen!");
                return;
            }

            //offene Intake und Beratungsphasen
            SqlQuery qry3 = DBUtil.OpenSQL(@"
                SELECT CountOpenIntake   = (SELECT COUNT(1)
                                            FROM dbo.FaPhase WITH (READUNCOMMITTED)
                                            WHERE FaLeistungID = {0} AND
                                                  FaPhaseCode = 1 AND
                                                  DatumBis IS NULL),
                       CountIntake       = (SELECT COUNT(1)
                                            FROM dbo.FaPhase WITH (READUNCOMMITTED)
                                            WHERE FaLeistungID = {0} AND
                                                  FaPhaseCode = 1),
                       CountOpenBeratung = (SELECT COUNT(1)
                                            FROM dbo.FaPhase WITH (READUNCOMMITTED)
                                            WHERE FaLeistungID = {0} AND
                                                  FaPhaseCode = 2 AND
                                                  DatumBis IS NULL),
                       CountBeratung     = (SELECT COUNT(1)
                                            FROM dbo.FaPhase WITH (READUNCOMMITTED)
                                            WHERE FaLeistungID = {0} AND
                                                  FaPhaseCode = 2)", qry["FaLeistungID"]);

            var countOpenIntake = (Int32)qry3["CountOpenIntake"];
            var countIntake = (Int32)qry3["CountIntake"];
            var countOpenBeratung = (Int32)qry3["CountOpenBeratung"];
            var countBeratung = (Int32)qry3["CountBeratung"];

            var configOffeneIntakePhasen = DBUtil.GetConfigInt(@"System\Fallfuehrung\OffeneIntakePhasen", 1);
            var configIntakeErstePhase = DBUtil.GetConfigBool(@"System\Fallfuehrung\IntakeErstePhase", false);
            var configTotalIntakePhasen = DBUtil.GetConfigInt(@"System\Fallfuehrung\TotalIntakePhasen", -1);
            var configTotalBeratungsphasen = DBUtil.GetConfigInt(@"System\Fallfuehrung\TotalBeratungsphasen", -1);

            if (countOpenBeratung > 0)
            {
                KissMsg.ShowInfo(Name, "NichtAbgeschlPhasenVorhanden", "Es gibt noch nicht abgeschlossene Beratungsphasen!");
                return;
            }

            if (faPhaseCode == 1)
            {
                //neue Intakephase

                //prüfe maximale Anzahl Intake-Phasen
                if (configTotalIntakePhasen > -1 && countIntake >= configTotalIntakePhasen)
                {
                    if (configTotalIntakePhasen == 0)
                    {
                        KissMsg.ShowInfo(Name, "KeineIntakePhaseErlaubt", "Es dürfen keine Intake-Phasen erstellt werden.");
                        return;
                    }

                    KissMsg.ShowInfo(Name, "MaximaleAnzahlIntakePhasenErreicht", "Es kann keine weitere Intake-Phase erstellt werden. Die maximale Anzahl Intake-Phasen ist erreicht.");
                    return;
                }

                //prüfe maximale Anzahl offener Intake-Phasen
                switch (countOpenIntake)
                {
                    case 0:
                        break;

                    case 1:
                        if (configOffeneIntakePhasen == 1)
                        {
                            KissMsg.ShowInfo(Name, "IntakePhaseVorhanden1", "Es gibt bereits eine offene Intake-Phase!");
                            return;
                        }
                        KissMsg.ShowInfo(Name, "IntakePhaseVorhanden2", "Achtung, es gibt bereits eine offene Intake-Phase!");
                        break;

                    case 2:
                        KissMsg.ShowInfo(Name, "2OffeneIntakePhasen", "Es gibt bereits 2 offene Intake-Phasen!");
                        return;

                    default:
                        return;
                }
            }
            else
            {
                //neue Beratungsphase

                //prüfe maximale Anzahl Beratungsphasen
                if (configTotalBeratungsphasen > -1 && countBeratung >= configTotalBeratungsphasen)
                {
                    if (configTotalBeratungsphasen == 0)
                    {
                        KissMsg.ShowInfo(Name, "KeineBeratungsphaseErlaubt", "Es dürfen keine Beratungsphasen erstellt werden.");
                        return;
                    }
                    KissMsg.ShowInfo(Name, "MaximaleAnzahlBeratungsphasenErreicht", "Es kann keine weitere Beratungsphase erstellt werden. Die maximale Anzahl Beratungsphasen ist erreicht.");
                    return;
                }

                if (configIntakeErstePhase && countIntake == 0)
                {
                    KissMsg.ShowInfo(Name, "ErstePhaseMussIntakeSein", "Die erste Phase muss eine Intake-Phase sein.");
                    return;
                }

                if (countOpenIntake > 0)
                {
                    KissMsg.ShowInfo(Name, "IntakePhaseNichtAbgeschlossen", "Es gibt noch nicht abgeschlossene Intake-Phasen!");
                    return;
                }
            }

            //Neues DatumVon bestimmen: heute bzw. DatumBis der letzten Phase + 1
            DateTime newDate = (DateTime)DBUtil.ExecuteScalarSQL(@"
                SELECT ISNULL(MAX(DATEADD(d, 1, DatumBis)), GETDATE())
                FROM dbo.FaPhase WITH (READUNCOMMITTED)
                WHERE FaLeistungID = {0}", qry["FaLeistungID"]);

            if (newDate < DateTime.Today)
            {
                newDate = DateTime.Today;
            }

            //einfügen einer neuen Phase
            SqlQuery qry2 = DBUtil.OpenSQL(@"
                INSERT dbo.FaPhase (FaLeistungID, FaPhaseCode, DatumVon, UserID, Creator, Created, Modifier, Modified)
                VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {4}, {5})
                SELECT ID = @@IDENTITY",
                qry["FaLeistungID"],
                faPhaseCode,
                newDate,
                Session.User.UserID,
                Session.User.CreatorModifier,
                DateTime.Now
            );

            //zuständigen User für Fallführung updaten
            Boolean transfer = true;
            try
            {
                transfer = ((Int32)DBUtil.GetConfigValue(@"System\Fallfuehrung\TransferPhaseUserToFall", 1)) != 1;
            }
            catch { }

            if (transfer)
            {
                DBUtil.ExecSQL(@"
                    UPDATE dbo.FaLeistung
                    SET UserID = {0}, Modifier = {1}, Modified = GetDate()
                    WHERE FaLeistungID = {2}", Session.User.UserID, DBUtil.GetDBRowCreatorModifier(), qry["FaLeistungID"]);
            }

            //neue FaPhaseID holen
            Decimal identity = -1;
            if (qry2.Count > 0)
            {
                identity = (Decimal)qry2["ID"];

                //Transfer Dialog für das interaktive Kopieren von Daten aus der Vorphase, fall Beratungsphase
                if (faPhaseCode == 2)
                {
                    DlgFaTransferPhase dlg = new DlgFaTransferPhase(Convert.ToInt32(identity));

                    if (!dlg.NoData)
                    {
                        dlg.ShowDialog();
                    }
                }
            }

            //Refresh Tree
            DisplayTree((Int32)identity);
        }

        private void SetThemenLayout()
        {
            if (editThemenfilter.Checked)
            {
                panelThemen.Visible = true;
                panelThemen.Height = 40 + editThemen.Items.Count * 20;
            }
            else
            {
                panelThemen.Height = 0;
            }
        }

        /// <summary>
        /// Zeigt den Themenfilter.
        /// </summary>
        private void ShowThemenFilter()
        {
            panelThemen.Visible = editThemenfilter.Checked;
            panelThemenFilter.Visible = true;
        }

        #endregion

        #endregion
    }
}