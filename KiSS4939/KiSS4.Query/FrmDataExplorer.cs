using System;
using System.Collections.Specialized;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.View;
using Kiss.UserInterface.ViewModel;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using log4net;

namespace KiSS4.Query
{
    /// <summary>
    /// Summary description for frmDataExplorer.
    /// </summary>
    public partial class FrmDataExplorer : KissChildForm, IContainerForm
    {
        #region Fields

        #region Private Static Fields

        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        /// <summary>
        /// Store status for loading class in order to prevent event execution
        /// </summary>
        private bool _isLoading;

        #endregion

        #endregion

        #region Constructors

        public FrmDataExplorer()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            // setup controls
            kissDataNavigator.PrefereDetailControl = true;

            treDataExplorer.SelectImageList = KissImageList.SmallImageList;
            tabTree.SelectedTabIndex = 0;
        }

        #endregion

        #region EventHandlers

        private void btnCollapseAll_Click(object sender, EventArgs e)
        {
            treDataExplorer.CollapseAll();
            treDataExplorer.Focus();
        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            treDataExplorer.ExpandAll();
            treDataExplorer.Focus();
        }

        private void frmDataExplorer_Load(object sender, EventArgs e)
        {
            try
            {
                // start loading
                _isLoading = true;

                // FAVORITES:
                //TODO: Favoriten-Funktionalität
                tabFavorites.HideTab = true;

                // QUERIES:
                // remove datasource from tree
                treDataExplorer.DataSource = null;

                // create and fill query
                SqlQuery qryXMenuItem = DBUtil.OpenSQL("EXEC spGetDataExplorerItems {0}", Session.User.LanguageCode);

                // update query
                qryXMenuItem.CanDelete = true;
                qryXMenuItem.CanUpdate = true;
                qryXMenuItem.CanInsert = true;
                qryXMenuItem.BatchUpdate = true;
                qryXMenuItem.DeleteQuestion = null;

                // if any, prepare query entries (setup icons, hide denied classes, ...)
                if (qryXMenuItem.Count > 0)
                {
                    do
                    {
                        // convert icon-id
                        if (!DBUtil.IsEmpty(qryXMenuItem["IconID"]))
                        {
                            qryXMenuItem["IconID"] = KissImageList.GetImageIndex(Convert.ToInt32(qryXMenuItem["IconID"]));
                        }
                    } while (qryXMenuItem.Next());
                }

                // no longer loading, allow loading first mask in tree (if any)
                _isLoading = false;

                // setup tree
                treDataExplorer.DataSource = qryXMenuItem;
                RemoveUnusedNodes(treDataExplorer.Nodes);

                // show all nodes
                treDataExplorer.ExpandAll();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("FrmDataExplorer", "ErrorLoadingDataExplorer", "Fehler beim Laden des Fensters.", ex);
            }
            finally
            {
                // no longer loading
                _isLoading = false;
            }
        }

        private void treDataExplorer_AfterFocusNode(object sender, NodeEventArgs e)
        {
            try
            {
                // validate first
                if (_isLoading || e == null || e.Node == null)
                {
                    return;
                }

                // setup cursor
                Cursor = Cursors.WaitCursor;

                // setup title and image with new values
                try
                {
                    picTitle.Image = ((ImageList)treDataExplorer.SelectImageList).Images[int.Parse(e.Node.GetValue("IconID").ToString())];
                }
                catch { picTitle.Image = null; }

                lblTitle.Visible = true;

                try
                {
                    lblTitle.Text = e.Node.GetDisplayText(treDataExplorer.Columns[0]);
                }
                catch { lblTitle.Text = ""; }

                // check if node contains children
                if (e.Node.HasChildren)
                {
                    // reset detailcontrol
                    ActivateUserControl(null, panDetail, true);
                    return;
                }

                // SHOW CONTROL
                string caption = e.Node.GetValue("Caption") as string;
                string className = e.Node.GetValue("ClassName") as string;

                // validate classname
                if (DBUtil.IsEmpty(className))
                {
                    KissMsg.ShowError("FrmDataExplorer", "EmptyClassName", "Die Abfrage '{0}' kann nicht geladen werden, da keine Klasse für dieses Element definiert wurde (muss vom Administrator eingerichtet werden)", null, null, 0, 0, caption);
                    return;
                }
                // validate rights (again)
                if (!DBUtil.UserHasRight(className))
                {
                    KissMsg.ShowError("FrmDataExplorer", "NoRightsForClassName", "Die Abfrage '{0}' kann nicht angezeigt werden, da Sie die dazu benötigten Rechte nicht besitzen.", null, null, 0, 0, caption);
                    return;
                }
                // validate type (again)
                if (!IsClassTypeOfQueryControl(className))
                {
                    KissMsg.ShowError("FrmDataExplorer", "InvalidTypeOfClassName", "Die Abfrage '{0}' kann nicht angezeigt werden, da Sie nicht der definierten Basisklasse angehört.", null, null, 0, 0, caption);
                    return;
                }

                // Neue WPF Masken (XAML)
                var xclassID = Kiss.Infrastructure.IoC.Container.Resolve<ViewFactory>().GetClassID(className);
                if (xclassID.HasValue)
                {
                    var view = new CtlWpfHost(xclassID.Value);
                    ActivateUserControl(view, panDetail, true);
                    return;
                }

                // show detail control
                ActivateUserControl((KissUserControl)AssemblyLoader.CreateInstance(className), panDetail, true);

                // activate usercontrol within panel if valid
                /*
                 * TODO: Does not yet work due to internal OnMouseUp on KissTree, which grabs focus again
                if (panDetail.Controls.Count == 1 && panDetail.Controls[0] != null && panDetail.Controls[0] is KissUserControl)
                {
                    ((KissUserControl)panDetail.Controls[0]).Focus();
                }
                */
            }
            catch (Exception ex)
            {
                // Eintrag ins Log.
                _log.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

                throw;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void treDataExplorer_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e)
        {
            if (DetailControl != null)
            {
                try
                {
                    e.CanFocus = ((IKissDataNavigator)DetailControl).SaveData();
                }
                catch
                {
                    e.CanFocus = false;
                }
            }
        }

        private void treDataExplorer_SizeChanged(object sender, EventArgs e)
        {
            // resize column width to fit it properly with tree including a scrollbar
            colItemName.Width = treDataExplorer.Size.Width - 24;
            colFavorites.Width = colItemName.Width;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnPrint()
        {
            try
            {
                if (DetailControl != null)
                    ((IKissContext)DetailControl).PrintReport();
                else
                    base.OnPrint();
            }
            catch (Exception ex)
            {
                _log.Debug(ex);
            }
        }

        /// <summary>
        /// Handle messages from FormController
        /// </summary>
        /// <param name="parameters">Containing all necessary parameters as key/value pairs</param>
        /// <returns>True, if successfully handles message or nothing done, false if something went wrong</returns>
        public override bool ReceiveMessage(HybridDictionary parameters)
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
                    RefreshQueryTree();
                    return true;

                case "ShowQueryItem":
                    return ShowQueryItem(parameters["ClassName"] as string);
            }

            return base.ReceiveMessage(parameters);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Check if className is type of KissQueryControl (inherited) or WPF
        /// </summary>
        /// <param name="className">The name of the class to check</param>
        /// <returns>True if baseclass or inherited from KissQueryControl, otherwise false</returns>
        private bool IsClassTypeOfQueryControl(string className)
        {
            // validate first
            if (DBUtil.IsEmpty(className))
            {
                return false;
            }

            try
            {
                // check if classname is baseclass or inherited from KissQueryControl
                var type = AssemblyLoader.GetType(className);

                return typeof(KissQueryControl).IsAssignableFrom(type) || typeof(KissView).IsAssignableFrom(type);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Refresh current tree view for dataexplorer
        /// </summary>
        private void RefreshQueryTree()
        {
            treDataExplorer.SaveState();
            frmDataExplorer_Load(this, EventArgs.Empty);
            treDataExplorer.LoadState();
        }

        /// <summary>
        /// Remove unused or locked nodes from treDataExplorer
        /// </summary>
        /// <param name="nodes">The nodes of the current node (recursive call)</param>
        private void RemoveUnusedNodes(TreeListNodes nodes)
        {
            // remove entries that are invalid or the user does not have access to it
            //   (cannot have a foreach loop due to collection changed if deleting node)
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                // get current node
                TreeListNode node = nodes[i];

                // recursive call
                RemoveUnusedNodes(node.Nodes);

                // get classname of current node
                string className = node.GetValue("ClassName") as string;

                if (className == "CtlQueryKontiOhneBgKostenart")
                {
                    System.Console.WriteLine("");
                }

                // check if class is defined and user is allowed to access class and class is proper type
                //   (empty classname = folder, otherwise already removed in storeprocedure)
                if (DBUtil.IsEmpty(className) && node.Nodes.Count < 1)
                {
                    // remove node due to empty classname and no children (=empty folder with no children)
                    treDataExplorer.DeleteNode(node);
                }
                else if (!DBUtil.IsEmpty(className) && (!DBUtil.UserHasRight(className) || !IsClassTypeOfQueryControl(className)))
                {
                    // remove node due to no rights to access this class or invalid type
                    treDataExplorer.DeleteNode(node);
                }
            }
        }

        /// <summary>
        /// Show specific query-classname from tree
        /// </summary>
        /// <param name="className">The classname of the query-class-item</param>
        /// <returns>True if successfully jumped to class, otherwise false</returns>
        private bool ShowQueryItem(string className)
        {
            // validate
            if (DBUtil.IsEmpty(className))
            {
                return false;
            }

            // search classname in treeitems
            TreeListNode node = treDataExplorer.FindNodeByFieldValue("ClassName", className);

            // show node if valid
            if (node != null)
            {
                treDataExplorer.FocusedNode = node;
                return true;
            }

            // if we are here, the node could not be found and applied
            return false;
        }

        #endregion

        #endregion
    }
}