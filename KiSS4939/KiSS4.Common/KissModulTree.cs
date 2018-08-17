using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;
using log4net;

namespace KiSS4.Common
{
    /// <summary>
    /// The tree used in each CtlFall for showing and accessing the module data
    /// </summary>
    public partial class KissModulTree : KissUserControl
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        public readonly int BaPersonID;
        public readonly int FaFallID = -1;
        public readonly int ModulID;

        #endregion

        #region Protected Constant/Read-Only Fields

        protected readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Protected Fields

        protected UtilShowDetail _showDetail;

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly string _spTree;

        #endregion

        #region Private Fields

        private int _expandedIndex = -1;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissModulTree"/> class.
        /// </summary>
        public KissModulTree()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            kissDataNavigator.PrefereDetailControl = true;

            // Add any initialization after the InitializeComponent call
            kissTree.BeforeFocusNode += kissTree_BeforeFocusNode;
            kissTree.AfterFocusNode += kissTree_AfterFocusNode;

            barManager_Tree.SetPopupContextMenu(kissTree, popup_Tree);

            kissTree.DataSource = null;

            // prevent sorting by default for modul trees
            kissTree.AllowSortTree = false;
        }

        public KissModulTree(int baPersonID, int faFallID, Panel panDetail, int modulID)
            : this()
        {
            BaPersonID = baPersonID;
            FaFallID = faFallID;

            kissTree.ImageIndexFieldName = "ImageIndex";
            _showDetail = new UtilShowDetail(panDetail);
            ModulID = modulID;

            kissTree.SelectImageList = KissImageList.SmallImageList;
            barManager_Tree.Images = KissImageList.SmallImageList;
        }

        [Obsolete]
        public KissModulTree(int baPersonID, Panel panDetail, ModulID modul)
            : this(baPersonID, -1, panDetail, (int)modul)
        {
        }

        [Obsolete]
        public KissModulTree(int baPersonID, Panel panDetail, int modulID)
            : this(baPersonID, -1, panDetail, modulID)
        {
        }

        [Obsolete]
        public KissModulTree(int baPersonID, Panel panDetail, string spTree)
            : this()
        {
            BaPersonID = baPersonID;

            _showDetail = new UtilShowDetail(panDetail);
            _spTree = spTree;
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                if (_showDetail != null)
                {
                    ShowDetail(null);
                    _showDetail.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Events

        public event EventHandler DetailChanged
        {
            add { _showDetail.DetailChanged += value; }
            remove { _showDetail.DetailChanged -= value; }
        }

        #endregion

        #region Properties

        [Browsable(false)]
        [DefaultValue(null)]
        public override KissUserControl DetailControl
        {
            get { return _showDetail == null ? null : _showDetail.DetailControl as KissUserControl; }
        }

        /// <summary>
        /// Gets or sets the focused node
        /// </summary>
        public TreeListNode FocusedNode
        {
            get { return kissTree.FocusedNode; }
            set { kissTree.FocusedNode = value; }
        }

        /// <summary>
        /// Gets the <see cref="KissTree"/> instance of this ModulTree.
        /// </summary>
        public KissTree KissTree
        {
            get { return kissTree; }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Calls the BeforeCloseView methode of the detailControl if it's set.
        /// </summary>
        /// <returns><c>true</c> if the detailControl is not set or the result of detailControl.</returns>
        public override bool BeforeCloseView()
        {
            var detailControl = _showDetail == null ? null : _showDetail.DetailControl;

            if (detailControl == null)
            {
                return true;
            }

            return detailControl.BeforeCloseView();
        }

        // TODO: Kein AfterFocusNode wenn der Fokus durch schliessen eines Nodes verändert wird
        protected virtual void kissTree_AfterFocusNode(object sender, NodeEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual void kissTree_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e)
        {
            if (e.OldNode != null)
            {
                e.CanFocus = BeforeCloseView();
                if (e.CanFocus == false)
                {
                    return;
                }
            }

            if (DetailControl != null)
            {
                try
                {
                    var detailControl = (IKissDataNavigator)DetailControl;
                    var saveSuccesful = detailControl.SaveData();
                    if (!saveSuccesful &&
                        KissMsg.ShowQuestion("KissModulTree", "MaskeSchliessenOhneSpeichern", "Maske trotz der nicht gespeicherten Daten schliessen?"))
                    {
                        detailControl.UndoDataChanges();
                        saveSuccesful = detailControl.SaveData();
                    }

                    e.CanFocus = saveSuccesful;
                }
                catch
                {
                    e.CanFocus = false;
                }
            }
        }

        private void btnFallInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            int faLeistungID = 0;

            if (kissTree.FocusedNode != null)
            {
                var val = kissTree.FocusedNode.GetValue("FaLeistungID");

                if (val is int)
                {
                    faLeistungID = (int)val;
                }
            }

            FrmFallInfo frm = new FrmFallInfo(faLeistungID);
            frm.ShowDialog(GetKissMainForm());
        }

        private void btnFallZugriff_ItemClick(object sender, ItemClickEventArgs e)
        {
            int faLeistungID = 0;

            if (kissTree.FocusedNode != null)
            {
                var val = kissTree.FocusedNode.GetValue("FaLeistungID");

                if (val is int)
                {
                    faLeistungID = (int)val;
                }
            }

            FrmFallZugriff frm = new FrmFallZugriff(faLeistungID);
            frm.ShowDialog(GetKissMainForm());
        }

        private void KissModulTree_Load(object sender, EventArgs e)
        {
            if (barManager_Tree.Images == KissImageList.SmallImageList)
            {
                foreach (BarItem item in barManager_Tree.Items)
                {
                    item.ImageIndex = KissImageList.GetImageIndex(item.ImageIndex);
                    item.ImageIndexDisabled = KissImageList.GetImageIndex(item.ImageIndexDisabled);
                }
            }

            if (_expandedIndex < 0 || DesignMode)
            {
                return;
            }

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (kissTree.Nodes.Count > _expandedIndex)
                {
                    kissTree.Nodes[_expandedIndex].Expanded = true;
                    foreach (TreeListNode node in kissTree.Nodes[_expandedIndex].Nodes)
                    {
                        node.Expanded = true;
                    }
                }
            }
            finally
            {
                Cursor.Current = currentCursor;
            }
        }

        private void sqlQueryTree_AfterFill(object sender, EventArgs e)
        {
            if (kissTree.SelectImageList == KissImageList.SmallImageList)
            {
                if (!qryModulTree.DataTable.Columns.Contains("ImageIndex"))
                {
                    qryModulTree.DataTable.Columns.Add("ImageIndex", typeof(int));
                }

                foreach (DataRow row in qryModulTree.DataTable.Rows)
                {
                    if (!DBUtil.IsEmpty(row["IconID"]))
                    {
                        row["ImageIndex"] = KissImageList.GetImageIndex((int)row["IconID"]);
                        row.AcceptChanges();
                    }
                }

                qryModulTree.RowModified = false;
            }

            kissTree.DataSource = sender;

            // prevent sorting by default for modul trees (redo here as we have now some columns!)
            kissTree.AllowSortTree = false;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Apply the Edit mode to the sqlQuery.
        /// </summary>
        /// <param name="qry"></param>
        /// <remarks>
        /// Add '((Common.KissModulTree)this.GetKissMainForm().GetTreeFall()).ApplyEditMaskToSqlQuery(SqlQuery);' to Apply an SqlQuery;
        ///  </remarks>
        public void ApplyEditMaskToSqlQuery(SqlQuery qry)
        {
            if (qry == null)
                return;

            if (FocusedNode != null)
            {
                var val = FocusedNode.GetValue("EditMask");

                if (val is string)
                {
                    var editMask = (string)val;

                    if (editMask.IndexOf('I') == -1)
                    {
                        qry.CanInsert = false;
                    }
                    if (editMask.IndexOf('U') == -1)
                    {
                        qry.CanUpdate = false;
                    }
                    if (editMask.IndexOf('D') == -1)
                    {
                        qry.CanDelete = false;
                    }

                    qry.EnableBoundFields();
                }
            }
        }

        public override void OnPrint()
        {
            try
            {
                if (DetailControl != null)
                {
                    ((IKissContext)DetailControl).PrintReport();
                }
                else
                {
                    base.OnPrint();
                }
            }
            catch (Exception ex)
            {
                _log.Debug(ex);
            }
        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            var action = parameters[FormController.Param.ACTION] as string;

            // Refresh
            if (action == FormController.Action.REFRESH_TREE)
            {
                Refresh();
                return true;
            }

            // Jump to path
            if (action == FormController.Action.JUMP_TO_PATH)
            {
                TreeListNode node = null;

                // Try to perform the jump
                if (parameters.Contains(FormController.Param.TREE_NODE_ID))
                {
                    node = kissTree.FindNodeByKeyID(parameters[FormController.Param.TREE_NODE_ID]);

                    if (node != null)
                    {
                        kissTree.FocusedNode = node;
                    }
                }

                // Fallback to FaLeistungID
                if (node == null && parameters.Contains(FormController.Param.FA_LEISTUNG_ID))
                {
                    var nodeLeistung = kissTree.FindNodeByFieldValue(FormController.Param.FA_LEISTUNG_ID, parameters[FormController.Param.FA_LEISTUNG_ID]);

                    if (nodeLeistung != null)
                    {
                        kissTree.FocusedNode = nodeLeistung;
                    }
                }

                if (kissTree.FocusedNode != null)
                {
                    kissTree.FocusedNode.Expanded = true;
                }

                if (DetailControl != null)
                {
                    FormController.SendMessage(DetailControl, parameters);
                }
                else if (_showDetail.DetailControl is CtlWpfHost)
                {
                    ((CtlWpfHost)_showDetail.DetailControl).JumpToPath(parameters);
                }

                return true;
            }

            return base.ReceiveMessage(parameters);
        }

        public override void Refresh()
        {
            object saveFocusedNode = null;
            object saveFocusedNodeParent = null;

            // Save FocusedNode
            if (kissTree.FocusedNode != null)
            {
                saveFocusedNode = kissTree.FocusedNode.GetValue(kissTree.KeyFieldName);

                if (null != kissTree.FocusedNode.ParentNode)
                {
                    saveFocusedNodeParent = kissTree.FocusedNode.ParentNode.GetValue(kissTree.KeyFieldName);
                }
            }

            // Refresh Data
            kissTree.BeforeFocusNode -= kissTree_BeforeFocusNode;
            kissTree.AfterFocusNode -= kissTree_AfterFocusNode;

            kissTree.SaveState();
            kissTree.DataSource = null;
            qryModulTree.Refresh();
            kissTree.LoadState();

            kissTree.BeforeFocusNode += kissTree_BeforeFocusNode;
            kissTree.AfterFocusNode += kissTree_AfterFocusNode;

            // Force Event if last FocusedNode doesn't exist
            //   Changed: FocusedNode was sometimes null --> new check added
            if (kissTree.Nodes.Count == 0)
            {
                ShowDetail(null);
            }
            else if (saveFocusedNode == null)
            {
                kissTree.MoveFirst();
            }
            else if (kissTree.FocusedNode == null || !saveFocusedNode.Equals(kissTree.FocusedNode.GetValue(kissTree.KeyFieldName)))
            {
                kissTree.FocusedNode = null;
                kissTree.MoveFirst();

                // Set Position to Parent if it is possible
                kissTree.FocusedNode = kissTree.FindNodeByKeyID(saveFocusedNodeParent);
            }
        }

        public override object ReturnMessage(HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return null;
            }

            // action depending
            switch (parameters[FormController.Param.ACTION] as string)
            {
                case FormController.Action.GET_JUMP_TO_PATH:
                    HybridDictionary dic = base.ReturnMessage(parameters) as HybridDictionary ?? new HybridDictionary();

                    dic[FormController.Param.BA_PERSON_ID] = BaPersonID;

                    if (FaFallID != -1)
                    {
                        dic[FormController.Param.FA_FALL_ID] = FaFallID;
                    }

                    dic[FormController.Param.MODUL_ID] = ModulID;

                    if (kissTree.FocusedNode != null)
                    {
                        dic[FormController.Param.TREE_NODE_ID] = kissTree.FocusedNode.GetValue(kissTree.KeyFieldName);

                        if (!DBUtil.IsEmpty(kissTree.FocusedNode.GetValue(FormController.Param.FA_LEISTUNG_ID)))
                        {
                            dic[FormController.Param.FA_LEISTUNG_ID] = kissTree.FocusedNode.GetValue(FormController.Param.FA_LEISTUNG_ID);
                        }
                    }

                    return dic;
            }

            return base.ReturnMessage(parameters);
        }

        public void ShowDetail()
        {
            _showDetail.ShowDetail();
        }

        #endregion

        #region Protected Methods

        protected void FillTree()
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // Assigning null to DataSource prevents "Error: There is already an open DataReader
                // associated with this Connection which must be closed first."
                kissTree.DataSource = null;

                if (ModulID == 0)
                {
                    qryModulTree.Fill("EXECUTE " + _spTree + " {0}, {1}", Session.User.UserID, BaPersonID);
                }
                else
                {
                    qryModulTree.Fill(
                        "EXECUTE dbo.spXGetModulTree {0}, {1}, {2}, {3}, {4}",
                        Session.User.UserID,
                        BaPersonID,
                        FaFallID == -1 ? (object)null : (object)FaFallID,
                        ModulID,
                        Session.User.LanguageCode);
                }

                kissTree.DataSource = qryModulTree;
            }
            finally
            {
                Cursor.Current = currentCursor;
            }
        }

        protected void FillTree(int expandedIndex)
        {
            _expandedIndex = expandedIndex;
            FillTree();
        }

        protected Image GetIcon(NodeEventArgs e)
        {
            try
            {
                int iconID;

                if (kissTree.SelectImageList == KissImageList.SmallImageList)
                {
                    iconID = (int)e.Node.GetValue("ImageIndex");
                }
                else
                {
                    iconID = (int)e.Node.GetValue("IconID");
                }

                return ((ImageList)kissTree.SelectImageList).Images[iconID];
            }
            catch (Exception ex)
            {
                _log.Debug(ex);
            }

            return null;
        }

        protected bool ShowDetail(IKissView newDetailControl, bool forceDispose)
        {
            return _showDetail.ShowDetail(newDetailControl, forceDispose);
        }

        protected bool ShowDetail(IKissView newDetailControl)
        {
            return ShowDetail(newDetailControl, false);
        }

        #endregion

        #endregion
    }
}