using System;
using System.Collections;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Main.PI
{
    /// <summary>
    /// Class for Fallbearbeitung form
    /// </summary>
    public partial class FrmFall : KissChildForm
    {
        #region Fields

        #region Private Static Fields

        /// The Log4Net logger.
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly ArrayList _alCtlFall = new ArrayList();
        private readonly bool _inConstructor = true; // flag if code is in constructor
        private readonly int _maxCases = 20; // set max-amout of open cases

        #endregion

        #region Private Fields

        private CtlFall _ctlFall;
        private int _newTabNumber = 1; // store the number for the next tabpage (shown in title)

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmFall"/> class.
        /// </summary>
        public FrmFall()
        {
            InitializeComponent();

            RestoreOnLogin = false;

            // clear demo-tpgs
            tabFall.TabPages.Clear();

            // set flag
            _inConstructor = false;
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
                // Cleanup CtlFall
                foreach (object ctlFall in _alCtlFall)
                {
                    ((CtlFall)((WeakReference)ctlFall).Target).Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        private void FrmFall_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt && _ctlFall != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.P:
                        _ctlFall.ShowModule(1); // Person
                        e.Handled = true;
                        break;

                    case Keys.F:
                        _ctlFall.ShowModule(2); // Fallverlauf
                        e.Handled = true;
                        break;

                    case Keys.S:
                        _ctlFall.ShowModule(3); // SozialBeratung
                        e.Handled = true;
                        break;

                    case Keys.C:
                        _ctlFall.ShowModule(4); // CaseManagement
                        e.Handled = true;
                        break;

                    case Keys.B:
                        _ctlFall.ShowModule(5); // Begleitetes Wohnen
                        e.Handled = true;
                        break;

                    case Keys.E:
                        _ctlFall.ShowModule(6); // EntlastungsDienst
                        e.Handled = true;
                        break;

                    case Keys.I:
                        _ctlFall.ShowModule(7); // Intake
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

        private void tabFall_TabClosed(SharpLibrary.WinControls.TabPageEx page)
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

            foreach (SharpLibrary.WinControls.TabPageEx page2 in tabFall.TabPages)
            {
                // get CtlFall
                alTab.Add(page2.Controls[0]);
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
                    catch
                    {
                    }
                }
            } // [foreach]
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Display given module by id
        /// </summary>
        /// <param name="moduleID"></param>
        public void DisplayModul(int moduleID)
        {
            if (tabFall.IsTabSelected() && tabFall.SelectedTab.Tag is FallTabTag)
            {
                if (tabFall.SelectedTab.Controls.Count > 0)
                {
                    _ctlFall = GetCurrentCtlFall();
                    _ctlFall.ShowModule(((FallTabTag)tabFall.SelectedTab.Tag).BaPersonID, moduleID);
                }
            }
        }

        /// <summary>
        /// Handle messages	from FormController
        /// </summary>
        /// <param name="param">Containing all necessary parameters	as key/value pairs</param>
        /// <returns>True, if successfully handles message or nothing done,	false if something went	wrong</returns>
        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least	one	parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            KissModulTree modulTree;

            // action depending
            switch (Convert.ToString(param["Action"]))
            {
                case "ShowFall":
                    // Show Fall with person, modulid and optional personname
                    return ShowFall(
                        Convert.ToInt32(param["BaPersonID"]),
                        Convert.ToString(param["PersonName"]),
                        Convert.ToInt32(param["ModulID"]));

                case "DisplayModul":
                    // Show modul of current person
                    DisplayModul(Convert.ToInt32(param["ModulID"]));
                    return true;

                case "RefreshTree":
                    // Refresh tree	of current,	active Fall
                    modulTree = GetCurrentModulTree();

                    if (modulTree == null)
                    {
                        return false;
                    }

                    // logging
                    _logger.DebugFormat("before refresh: modulTree.FocusedNode='{0}'", modulTree.KissTree.FocusedNode);

                    // refresh tree
                    modulTree.Refresh();

                    // logging
                    _logger.DebugFormat("after refresh: modulTree.FocusedNode='{0}'", modulTree.KissTree.FocusedNode);

                    // do special action on	CltFaModulTree
                    FormController.SendMessage(modulTree, "Action", "ValidateClosedItems");
                    FormController.SendMessage(modulTree, "Action", "UpdateFVUserID");

                    // update icons
                    CtlFall ctlFall = GetCurrentCtlFall();

                    if (ctlFall != null)
                    {
                        ctlFall.RefreshFallIcons();
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

                case "JumpToNodeByID":
                    modulTree = GetCurrentModulTree();

                    if (modulTree == null)
                    {
                        return false;
                    }

                    modulTree.FocusedNode = modulTree.KissTree.FindNodeByID(Convert.ToInt32(param["NodeID"]));

                    return true;

                case "JumpToNodeByFieldValue":
                    // check if we have a FieldName
                    if (!param.Contains("FieldName"))
                    {
                        // take ID as default if none is given
                        param["FieldName"] = "ID";
                    }

                    // show fall first
                    if (ShowFall(param))
                    {
                        modulTree = GetCurrentModulTree();

                        if (modulTree != null)
                        {
                            // try to find a focused node by fieldname and its fieldvalue
                            modulTree.FocusedNode = modulTree.KissTree.FindNodeByFieldValue(Convert.ToString(param["FieldName"]), param["FieldValue"]);

                            // check if we have a focused node
                            if (modulTree.FocusedNode == null)
                            {
                                // node not found
                                return false;
                            }

                            // send message further on
                            modulTree.DetailControl.ReceiveMessage(param);
                            return true;
                        }
                    }

                    return false;

                case "RefreshPersonInfoTitle":
                    // Refresh name	of person shown	in CtlFall
                    modulTree = GetCurrentModulTree();

                    if (modulTree == null)
                    {
                        return false;
                    }

                    ctlFall = GetCurrentCtlFall();

                    if (ctlFall != null)
                    {
                        ctlFall.SetPersonInfoTitel();
                        return true;
                    }

                    return false;
            }

            // did not understand message
            return false;
        }

        /// <summary>
        /// Handle messages	from FormController
        /// </summary>
        /// <param name="param">Specific messages as key/value pair	for	current	form</param>
        /// <returns>Specified object that has to be returned to sender</returns>
        public override object ReturnMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least	one	parameter to know what to do
            if (param.Count < 1)
            {
                // by default, nothing to do
                return null;
            }

            // action depending
            switch (Convert.ToString(param["Action"]))
            {
                case "CurrentModulTree":
                    // get current modul tree
                    return GetCurrentModulTree();
            }

            // did not understand message
            return null;
        }

        /// <summary>
        /// Show fall control with person, name	and	modulid
        /// </summary>
        /// <param name="baPersonID">The id	of the person to show</param>
        /// <param name="personName">The name of the person	to show</param>
        /// <param name="modulID">The modulid to select</param>
        /// <returns>True if success, else false</returns>
        public bool ShowFall(int baPersonID, string personName, int modulID)
        {
            try
            {
                // do not update form
                SuspendLayout();

                // search if we	have the desired person	already	as a tab
                foreach (SharpLibrary.WinControls.TabPageEx page in tabFall.TabPages)
                {
                    if (page.Tag is FallTabTag && baPersonID == ((FallTabTag)page.Tag).BaPersonID)
                    {
                        // display Fall
                        tabFall.SelectTab(page);

                        // display Modul
                        if (page.Controls.Count > 0)
                        {
                            _ctlFall = (CtlFall)page.Controls[0];
                            _ctlFall.ShowModule(baPersonID, modulID);
                        }

                        // done
                        return true;
                    }
                }

                // abort if maximum number of cases are open.
                if (tabFall.TabPages.Count >= _maxCases)
                {
                    // logging
                    _logger.DebugFormat("Maximum number of displayed cases [{0}]", tabFall.TabPages.Count);

                    // show message
                    KissMsg.ShowInfo(
                        Name, "MaxCasesReached", "Es können keine weiteren Fälle geöffnet werden. Bitte schliessen Sie zuerst nicht benötigte Fälle.");

                    // done
                    return false;
                }

                // check if	we already have	a name
                if (DBUtil.IsEmpty(personName))
                {
                    try
                    {
                        personName =
                            Convert.ToString(
                                DBUtil.ExecuteScalarSQL(@"
                                    SELECT dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname)
                                    FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
                                    WHERE PRS.BaPersonID = {0}",
                                    baPersonID));
                    }
                    catch
                    {
                        // reset person name
                        personName = null;
                    }

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
                SharpLibrary.WinControls.TabPageEx newTabPage = new SharpLibrary.WinControls.TabPageEx();

                // setup new page
                newTabPage.Title = string.Format("{0}. {1}", _newTabNumber, personNameOnTpg);
                newTabPage.Tag = new FallTabTag(baPersonID, _newTabNumber); // store information in tag of tabpage
                newTabPage.Margin = new Padding(0, 0, 4, 32);

                // create UserControl for Fall
                _ctlFall = new CtlFall();
                _ctlFall.Parent = newTabPage;
                _ctlFall.Dock = DockStyle.Fill;

                // Display new Fall
                tabFall.TabPages.Add(newTabPage);
                tabFall.SelectTab(newTabPage);

                // count up next number
                _newTabNumber++;

                // add ctlFall to array
                _alCtlFall.Add(new WeakReference(_ctlFall));

                // continue
                ResumeLayout(true);
                ApplicationFacade.DoEvents();

                // display modul
                return _ctlFall.ShowModule(baPersonID, modulID);
            }
            catch (Exception ex)
            {
                // log error
                _logger.Error("Error in ShowFall() occured.", ex);

                // show exception to user
                KissMsg.ShowError(Name, "ErrorShowingFall", "Es ist ein Fehler beim Anzeigen des Falls aufgetreten.", ex);

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
            else
            {
                return (CtlFall)tabFall.SelectedTab.Controls[0];
            }
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
            else
            {
                return ((CtlFall)tabFall.SelectedTab.Controls[0]).CurrentModulTree;
            }
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
            // check if BaPersonID is valid
            if (!param.Contains("BaPersonID") || param["BaPersonID"] == null)
            {
                return false;
            }

            // check module
            if (!param.Contains("ModulID"))
            {
                param["ModulID"] = 1; // person by default
            }

            // call main method
            return ShowFall(Convert.ToInt32(param["BaPersonID"]), Convert.ToString(param["PersonName"]), Convert.ToInt32(param["ModulID"]));
        }

        #endregion

        #endregion
    }
}