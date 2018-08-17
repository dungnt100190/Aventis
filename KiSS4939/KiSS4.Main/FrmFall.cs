using System;
using System.Collections;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using SharpLibrary.WinControls;

namespace KiSS4.Main
{
    /// <summary>
    /// Summary description for FrmFall.
    /// </summary>
    public partial class FrmFall : KissChildForm
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly Int32 MaxCases = 20; // set max-amout of open cases
        private readonly ArrayList _alCtlFall = new ArrayList();
        private readonly bool _inConstructor = true;

        #endregion

        #region Private Fields

        private Int32 _newTabNumber = 1; // store the number for the next tabpage (shown in title)

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor to init control
        /// </summary>
        public FrmFall()
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            tabFall.TabPages.Clear();
            new Belegleser(this);

            RestoreOnLogin = false;

            _inConstructor = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (GuiConfig.Theme != GuiConfig.KissTheme.None)
            {
                tabFall.BackColor = GuiConfig.colBack05;
                tpgFall.BackColor = GuiConfig.colBack05;
                this.BackColor = GuiConfig.PanelColor;
                tabFall.TabsStyle = TabsStyle.Flat;
                tabFall.FlatStyleSelectedTabColor = GuiConfig.colBack05;
                tabFall.FlatStyleSelectedTabBorderColor = GuiConfig.colBack06;
            }
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
                // Cleanup CtlFall
                foreach (object fall in _alCtlFall)
                {
                    ((CtlFall)((WeakReference)fall).Target).Dispose();
                }
            }

            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Properties

        public override KissUserControl DetailControl
        {
            get { return GetCurrentCtlFall(); }
        }

        #endregion

        #region EventHandlers

        private void FrmFall_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt && ctlFall != null)
            {
                // handle alt+modul-shortcut --> jump to current modul in tree
                switch (e.KeyCode)
                {
                    case Keys.B:
                        ctlFall.ShowModule((int)ModulID.B);
                        e.Handled = true;
                        break;

                    case Keys.F:
                        ctlFall.ShowModule((int)ModulID.F);
                        e.Handled = true;
                        break;

                    case Keys.S:
                        ctlFall.ShowModule((int)ModulID.S);
                        e.Handled = true;
                        break;

                    case Keys.I:
                        ctlFall.ShowModule((int)ModulID.I);
                        e.Handled = true;
                        break;

                    case Keys.V:
                        ctlFall.ShowModule((int)ModulID.V);
                        e.Handled = true;
                        break;

                    case Keys.A:
                        ctlFall.ShowModule((int)ModulID.A);
                        e.Handled = true;
                        break;

                    case Keys.K:
                        ctlFall.ShowModule((int)ModulID.K);
                        e.Handled = true;
                        break;
                }
            }
        }

        private void tabFall_MouseUpButtonStyle(object sender, MouseEventArgs e)
        {
            // focus modultree
            if (GetCurrentModulTree() != null)
            {
                GetCurrentModulTree().Focus();
            }
        }

        private void tabFall_SelectedTabChanged(TabPageEx page)
        {
            ctlFall = GetCurrentCtlFall();
        }

        private void tabFall_TabClosed(TabPageEx page)
        {
            // check if we are in constructor
            if (_inConstructor)
            {
                return;
            }

            // check if we have any tabs left
            if (tabFall.TabPages.Count == 0)
            {
                // close form, no more tabs left
                Close();
                return;
            }

            // check if page was last page
            if (page.Tag is FallTabTag && ((FallTabTag)page.Tag).TabNumber == (_newTabNumber - 1))
            {
                // the last tabpage was closed, we decrement number (min-value is 1)
                _newTabNumber = Math.Max(_newTabNumber - 1, 1);
            }

            // dispose CtlFall
            if (_alCtlFall.Count <= tabFall.TabPages.Count)
            {
                return;
            }

            // get all CtlFall on tabs
            ArrayList alTab = new ArrayList();
            foreach (TabPageEx tpg in tabFall.TabPages)
            {
                // get CtlFall
                alTab.Add(tpg.Controls[0]);
            }

            // dispose CtlFall that are no longer needed
            foreach (object wref in (ArrayList)_alCtlFall.Clone())
            {
                if (!((WeakReference)wref).IsAlive)
                {
                    _alCtlFall.Remove(wref);
                }
                else
                {
                    try
                    {
                        if (!alTab.Contains(((WeakReference)wref).Target))
                        {
                            ((CtlFall)((WeakReference)wref).Target).Dispose();
                            _alCtlFall.Remove(wref);
                        }
                    }
                    catch { }
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void DisplayModul(ModulID module)
        {
            if (tabFall.IsTabSelected())
            {
                if (tabFall.SelectedTab.Controls.Count > 0)
                {
                    ctlFall = GetCurrentCtlFall();
                    ctlFall.ShowModule((int)module);
                }
            }
        }

        /// <summary>
        /// Handle messages from FormController
        /// </summary>
        /// <param name="param">Containing all necessary parameters as key/value pairs</param>
        /// <returns>True, if successfully handles message or nothing done, false if something went wrong</returns>
        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            KissModulTree modulTree;

            // action depending
            switch (param["Action"] as string)
            {
                case "ShowFall":
                    // Show Fall with person, modulcode and optional personname
                    return ShowFall(param);

                case "RefreshControl":
                    // refresh detail control, get modulTree
                    modulTree = GetCurrentModulTree();

                    // validate
                    if (modulTree == null || modulTree.DetailControl == null)
                    {
                        // invalid state
                        return false;
                    }

                    // check if we have a filter for ControlName
                    if (param.Contains("ControlName") && modulTree.DetailControl.GetType().Name != Convert.ToString(param["ControlName"]))
                    {
                        // nothing more to do, control does not match
                        return true;
                    }

                    // get detail control
                    KissUserControl detailControl = modulTree.DetailControl;

                    // save pending changes first, to prevent loosing data
                    if (!detailControl.OnSaveData())
                    {
                        // data could not be saved
                        return false;
                    }

                    // refresh detailcontrol-data
                    detailControl.OnRefreshData();

                    // if we are here, everything is ok
                    return true;

                case "RefreshTree":
                    // Refresh tree of current, active Fall
                    modulTree = GetCurrentModulTree();
                    if (modulTree == null)
                    {
                        return false;
                    }

                    modulTree.Refresh();

                    CtlFall currentCtlFall = GetCurrentCtlFall();
                    if (currentCtlFall != null)
                    {
                        currentCtlFall.RefreshFallIcons();
                    }
                    return true;

                case "JumpToPath":
                    if (ShowFall(param))
                    {
                        KissModulTree moduleTree = GetCurrentModulTree();
                        if (moduleTree != null)
                        {
                            return FormController.SendMessage(moduleTree, param);
                        }
                        return true;
                    }
                    return false;

                case "JumpToNodeByFieldValue":
                    if (!param.Contains("FieldName"))
                        param["FieldName"] = "ID";

                    if (ShowFall(param))
                    {
                        KissModulTree moduleTree = GetCurrentModulTree();
                        if (moduleTree == null)
                            return false;

                        DevExpress.XtraTreeList.Nodes.TreeListNode node = moduleTree.KissTree.FindNodeByFieldValue(param["FieldName"] as string, param["FieldValue"]);
                        if (node == null)
                            return false;

                        moduleTree.FocusedNode = node;
                        //TODO: moduleTree.DetailControl.ReceiveMessage(param); //dann ist es gleich wie in ZH (wird für Grundbudget-Sprung aus WshFalluebersichtAbzugView benötigt)
                        return true;
                    }
                    return false;

                case "JumpToVermittlung":
                    if (!param.Contains("FieldName"))
                        param["FieldName"] = "ID";

                    if (ShowFall(param))
                    {
                        KissModulTree moduleTree = GetCurrentModulTree();
                        if (moduleTree == null)
                            return false;

                        DevExpress.XtraTreeList.Nodes.TreeListNode node = moduleTree.KissTree.FindNodeByFieldValue(param["FieldName"] as string, param["FieldValue"]);
                        if (node == null)
                            return false;

                        moduleTree.FocusedNode = node;

                        param["Action"] = "SelectRow";
                        FormController.SendMessage(((CtlFall)(DetailControl)).CurrentDetailControl, param);

                        return true;
                    }
                    return false;

                case "JumpFromPendenzen":
                    if (!param.Contains("FieldName"))
                    {
                        param["FieldName"] = "ID";
                    }
                    if (!param.Contains("DokumenteID"))
                    {
                        return false;
                    }
                    if (!param.Contains("XTaskID"))
                    {
                        return false;
                    }
                    if (ShowFall(param))
                    {
                        KissModulTree moduleTree = GetCurrentModulTree();
                        if (moduleTree != null)
                        {
                            moduleTree.FocusedNode = moduleTree.KissTree.FindNodeByFieldValue(param["FieldName"] as string, param["FieldValue"]);
                            moduleTree.DetailControl.ReceiveMessage(param);
                            return true;
                        }
                    }
                    return false;

                case "CloseFrmFall":
                    Close();
                    break;

                case "CloseActiveFall":
                    tabFall.CloseActiveTab();
                    if (tabFall.TabPages.Count < 1)
                    {
                        // Close() doesen't work here to close the window. Don't know why not.
                        Dispose();
                    }

                    break;
            }

            // did not understand message
            return base.ReceiveMessage(param);
        }

        /// <summary>
        /// Handle messages from FormController
        /// </summary>
        /// <param name="param">Specific messages as key/value pair for current form</param>
        /// <returns>Specified object that has to be returned to sender</returns>
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
                case "CurrentModulTree":
                    // get current modul tree
                    return GetCurrentModulTree();

                case "GetJumpToPath":
                    ctlFall = GetCurrentCtlFall();
                    return ctlFall.ReturnMessage(param);
            }

            // did not understand message, ask the DetailControl
            if (DetailControl != null)
            {
                return DetailControl.ReturnMessage(param);
            }

            return null;
        }

        /// <summary>
        /// Show fall control with person, name and modulId
        /// </summary>
        /// <param name="baPersonID">The id of the person to show</param>
        /// <param name="faFallID"></param>
        /// <param name="personName">The name of the person to show</param>
        /// <param name="modulID">The modulid to select</param>
        /// <returns>True if success, else false</returns>
        public Boolean ShowFall(Int32 baPersonID, Int32 faFallID, String personName, Int32 modulID)
        {
            try
            {
                // do not update form
                SuspendLayout();

                // Display existing tab if available
                foreach (TabPageEx tpg in tabFall.TabPages)
                {
                    if (tpg.Tag is FallTabTag && baPersonID == ((FallTabTag)tpg.Tag).BaPersonID)
                    {
                        // display Fall
                        tabFall.SelectTab(tpg);

                        // display Modul
                        if (tpg.Controls.Count > 0)
                        {
                            ctlFall = (CtlFall)tpg.Controls[0];
                            ctlFall.ShowModule(modulID);
                        }

                        // done
                        return true;
                    }
                }

                // abort if maximum number of cases are open.
                if (tabFall.TabPages.Count >= MaxCases)
                {
                    // logging
                    _logger.DebugFormat("Maximum number of displayed cases [{0}]", tabFall.TabPages.Count);

                    // show message
                    KissMsg.ShowInfo("FrmFall", "MaxCasesReached", "Es können keine weiteren Fälle geöffnet werden. Bitte schliessen Sie zuerst nicht benötigte Fälle.");

                    // done
                    return false;
                }

                // check if we already have a name
                if (DBUtil.IsEmpty(personName))
                {
                    try
                    {
                        personName = Convert.ToString(DBUtil.ExecuteScalarSQL(@"
                                SELECT PRS.Name + ISNULL(', ' + PRS.Vorname, '')
                                FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
                                WHERE PRS.BaPersonID = {0}", baPersonID));
                    }
                    catch { }

                    // no person name
                    if (personName == null)
                    {
                        personName = "???";
                    }
                }

                // define name to show on tab page
                string personNameOnTpg = personName;
                if (personNameOnTpg.Length > 28)
                {
                    personNameOnTpg = personNameOnTpg.Substring(0, 25) + "...";
                }

                // create new tab page
                TabPageEx newTabPage = new TabPageEx();

                // setup new page
                newTabPage.Title = String.Format("{0}. {1}", _newTabNumber, personNameOnTpg);
                newTabPage.Tag = new FallTabTag(baPersonID, _newTabNumber);                     // store information in tag of tabpage
                newTabPage.Margin = new Padding(0, 0, 4, 32);

                // create UserControl for Fall
                ctlFall = new CtlFall(baPersonID, faFallID);
                ctlFall.Parent = newTabPage;
                ctlFall.Dock = DockStyle.Fill;

                // Display new Fall
                tabFall.TabPages.Add(newTabPage);
                tabFall.SelectTab(newTabPage);

                // count up next number
                _newTabNumber++;

                // add ctlFall to array
                _alCtlFall.Add(new WeakReference(ctlFall));

                // continue
                ResumeLayout(true);
                ApplicationFacade.DoEvents();

                // display modul
                bool success = ctlFall.ShowModule(modulID);

                // check if we have any tabs left. In case the user clicked on Close while the Fall was still building, we end up empty here
                if (tabFall.TabPages.Count == 0)
                {
                    // close form, no more tabs left
                    ResetLockCloseForm();  // Ensure that we can actually close the form here
                    Close();
                    success = false;
                }

                return success;
            }
            catch (Exception ex)
            {
                // log error
                _logger.Error("Error in ShowFall() occured.", ex);

                // show exception to user
                KissMsg.ShowError("FrmFall", "ErrorShowingFall", "Es ist ein Fehler beim Anzeigen des Falls aufgetreten.", ex);

                // failed
                return false;
            }
            finally
            {
                // ensure layout is resumed anyway
                ResumeLayout();
            }
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Get current CtlFall from selected tab
        /// </summary>
        /// <returns>CtlFall or null if no tab is selected</returns>
        internal CtlFall GetCurrentCtlFall()
        {
            if (!tabFall.IsTabSelected())
            {
                return null;
            }

            return (CtlFall)tabFall.SelectedTab.Controls[0];
        }

        /// <summary>
        /// Get current modul tree from selected tab
        /// </summary>
        /// <returns>ModulTree or null if no tab is selected</returns>
        internal KissModulTree GetCurrentModulTree()
        {
            // validate if we have a tab
            if (!tabFall.IsTabSelected())
            {
                return null;
            }

            return ((CtlFall)tabFall.SelectedTab.Controls[0]).CurrentModulTree;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Show fall control with person, name and modulid
        /// </summary>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        private bool ShowFall(System.Collections.Specialized.HybridDictionary param)
        {
            if (!param.Contains("BaPersonID") || DBUtil.IsEmpty(param["BaPersonID"]))
            {
                return false;
            }

            if (!param.Contains("FaFallID") || DBUtil.IsEmpty(param["FaFallID"]))
            {
                param["FaFallID"] = -1;
            }

            if (!param.Contains("ModulID"))
            {
                param["ModulID"] = ModulID.F;
            }

            return ShowFall((int)param["BaPersonID"], (int)param["FaFallID"], param["PersonName"] as string, (int)param["ModulID"]);
        }

        #endregion

        #endregion
    }
}