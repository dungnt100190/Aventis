using System;
using System.Drawing;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using SharpLibrary.WinControls;

namespace KiSS4.Main.PI
{
    /// <summary>
    /// Container to use for single person's modultree and detail controls, used in <see cref="FrmFall"/>.
    /// </summary>
    public partial class CtlFall : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly ToolTip _ttpPicPerson = new ToolTip();

        #endregion

        #region Private Fields

        private int _baPersonID = -1;
        private int _currentModulID = -1;
        private bool _initTabIndex = true;
        private bool _isFromSelectedTabChanged;
        private bool _isSwitchingTabShowModule;
        private int _tempSavedModulID = -1;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFall"/> class.
        /// </summary>
        public CtlFall()
        {
            InitializeComponent();

            // hide template tab
            tpgTemplate.HideTab = true;

            // setup class
            tabModulTree.BorderStyleEx = BorderStyleEx.None;

            // setup picture box and tooltip
            _ttpPicPerson.ToolTipTitle = KissMsg.GetMLMessage(Name, "ToolTipTitlePicPerson", "Wichtiger Hinweis");
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
                foreach (TabPageEx page in tabModulTree.TabPages)
                {
                    KissModulTree ctl = GetKissModulTree(page);

                    if (ctl != null)
                    {
                        ctl.OnSaveData();
                        ctl.Dispose();
                    }
                }

                if ((components != null))
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the instance of the current detail control
        /// </summary>
        public KissUserControl CurrentDetailControl
        {
            get
            {
                // get current modul tree
                KissModulTree tree = CurrentModulTree;

                // validate
                if (tree != null)
                {
                    return tree.DetailControl;
                }

                // not found
                return null;
            }
        }

        /// <summary>
        /// Get the instance of the current modultree
        /// </summary>
        public KissModulTree CurrentModulTree
        {
            get { return GetKissModulTree(tabModulTree.SelectedTab); }
        }

        #endregion

        #region EventHandlers

        private void lblPersonName_DoubleClick(object sender, EventArgs e)
        {
            Main.CtlFall.CopyPersonTitleToClipboard(lblPersonName.Text, _baPersonID);
        }

        /// <summary>
        /// The Resize event, used to resize detail control depending on available space
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void panDetailControl_Resize(object sender, EventArgs e)
        {
            // check if we have any controls
            if (panDetailControl.Controls.Count > 0)
            {
                // apply size of current detail control
                panDetailControl.Controls[0].Size = panDetailControl.Size;
            }
        }

        /// <summary>
        /// The MouseUp event on tabcontrol, used to set focus to detail control if user changed the module tab
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void tabModulTree_MouseUp(object sender, MouseEventArgs e)
        {
            // set focus to control if any available
            KissUserControl ctrl = CurrentDetailControl;

            if (ctrl != null)
            {
                ctrl.Focus();
            }
        }

        private void tabModulTree_SelectedTabChanged(TabPageEx page)
        {
            try
            {
                if (_initTabIndex)
                {
                    return;
                }

                // setup flag
                _isFromSelectedTabChanged = true;

                // we do not have to use index-1 due to hidden tab page that has the index=0
                ShowModule(tabModulTree.SelectedTabIndex);
            }
            finally
            {
                // setup flag
                _isFromSelectedTabChanged = false;
            }
        }

        private void tabModulTree_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // try to save data to prevent switching tab without saved correctly
            try
            {
                // get modultree
                KissModulTree ctl = GetKissModulTree(tabModulTree.SelectedTab);

                if (ctl != null)
                {
                    // save pending changes
                    e.Cancel = !ctl.OnSaveData();
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorSavingDataOnTabSwitch", "Fehler beim Speichern der Daten, das Register kann nicht gewechselt werden.", ex);
                e.Cancel = true;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void GotoModul(KissModulTree tree, int modulID, int baPersonID)
        {
            if (tree == null)
            {
                return;
            }

            switch (modulID)
            {
                case 1:
                    // select person node
                    var personNode = tree.KissTree.FindNodeByKeyID("P" + baPersonID);

                    if (personNode != null)
                    {
                        tree.FocusedNode = personNode;
                    }
                    return;

                case 2:
                    modulID = 20011;
                    break;

                default:
                    modulID = modulID * 10000;
                    break;
            }

            var node = DBUtil.FindNodeByValue(tree.KissTree.Nodes, modulID.ToString(), "ModulTreeID");

            if (node != null)
            {
                node.Expanded = true;
                tree.FocusedNode = node;
                ApplicationFacade.DoEvents();
            }
        }

        public void RefreshDLIcons()
        {
            ctlGotoFall.BaPersonID = _baPersonID;
        }

        /// <summary>
        /// Refresh the icons of the current fall on tab pages
        /// </summary>
        public void RefreshFallIcons()
        {
            try
            {
                _initTabIndex = true;

                SqlQuery qry = DBUtil.OpenSQL("EXECUTE dbo.spFaGetModulIcon {0}, NULL, 1", _baPersonID);

                while (qry.Count > 0)
                {
                    // only module 1 and 2 are important
                    if (Convert.ToInt32(qry["ModulID"]) > 2)
                    {
                        if (!qry.Next())
                        {
                            break;
                        }

                        continue;
                    }

                    TabPageEx page = GetTabPage(Convert.ToInt32(qry["ModulID"]));

                    if (page == null)
                    {
                        page = new TabPageEx();
                        page.Name = string.Format("tpgModul_{0}", qry["ModulID"]);
                        page.Size = tpgTemplate.Size;
                        page.BorderStyle = tpgTemplate.BorderStyle;
                        page.BackColor = tpgTemplate.BackColor;
                        page.TabIndex = qry.Position;
                        page.Title = "";

                        tabModulTree.TabPages.Add(page);
                    }

                    // setup icon
                    Image modulIcon = KissImageList.GetSmallImage(Convert.ToInt32(qry["IconID"]));

                    if (imgModulIcons != null)
                    {
                        if (imgModulIcons.Images.Contains(modulIcon))
                        {
                            page.ImageIndex = imgModulIcons.Images.IndexOf(modulIcon);
                        }
                        else
                        {
                            imgModulIcons.Images.Add(modulIcon);
                            page.ImageIndex = imgModulIcons.Images.IndexOf(modulIcon);
                        }
                    }

                    if (!qry.Next())
                    {
                        break;
                    }
                }

                // update icons goto fall
                RefreshDLIcons();
            }
            catch { }
            finally
            {
                _initTabIndex = false;
            }
        }

        /// <summary>
        /// Apply person information title content
        /// </summary>
        public void SetPersonInfoTitel()
        {
            // apply person information title content
            PersonInfoTitel.SetPersonInfoTitel(lblPersonName, picIcon, _ttpPicPerson, _baPersonID);
        }

        /// <summary>
        /// Show the specified module of the current person
        /// </summary>
        /// <param name="modulID">The id of the module to show</param>
        /// <returns>True if successfully switched to the desired module</returns>
        public bool ShowModule(int modulID)
        {
            return ShowModule(_baPersonID, modulID);
        }

        /// <summary>
        /// Show the specified module of the specified person
        /// </summary>
        /// <param name="baPersonID">The id of the person to show</param>
        /// <param name="modulID">The id of the module to show</param>
        /// <returns>True if successfully switched to the desired module</returns>
        public bool ShowModule(int baPersonID, int modulID)
        {
            try
            {
                // if the user has no rights to display this user, we show an exception
                if (!Common.PI.FaUtils.UserMayShowPersonDossier(baPersonID))
                {
                    lblPersonName.Text = KissMsg.GetMLMessage("CtlFall", "AccessDeniedLabel", "Keine Rechte für dieses Dossier!");
                    KissMsg.ShowError(Name, "AccessDeniedToPerson", "Sie besitzen keine Rechte, das Dossier dieser Person anzuzeigen.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorShowModule", "Fehler bei der Verarbeitung. Die Person kann nicht angezeigt werden.", ex);
                return false;
            }

            if (_baPersonID != baPersonID)
            {
                _baPersonID = baPersonID;
                RefreshFallIcons();
            }

            // setup module for dienstleistung
            _currentModulID = modulID;

            switch (modulID)
            {
                case 1:
                    // P - Person
                    modulID = 1;
                    break;

                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 31:
                    // AKV - Fallfuehrung
                    modulID = 2;
                    break;

                default:
                    return false;
            }

            // get module tree
            TabPageEx page = GetTabPage(modulID);
            KissModulTree kissModulTree = GetKissModulTree(page);

            // check if we found tree
            if (kissModulTree == null)
            {
                // tree not found, get new modul tree depending on module itself
                kissModulTree = AssemblyLoader.GetKissModulTree(modulID, _baPersonID, panDetailControl) as KissModulTree;

                // validate
                if (kissModulTree == null)
                {
                    // no modul tree instance created, cannot proceed
                    return false;
                }

                // add and setup new tree
                page.Controls.Add(kissModulTree);
                page.Location = new Point(0, 30);

                kissModulTree.Dock = DockStyle.Fill;

                // set text and image, refresh icons
                SetPersonInfoTitel();
                RefreshDLIcons();

                // if new modultree and request to show AKV, jump to first FV-entry (at least one should exist, we create one on each new client)
                if (_currentModulID == 2)
                {
                    // show first FV entry, the tree does not show a detailcontrol otherwise
                    GotoModul(kissModulTree, 2, baPersonID); // show first FV
                }
            }

            ApplicationFacade.DoEvents();

            try
            {
                // check if need to switch tab page
                if (tabModulTree.SelectedTab != page)
                {
                    // save current modul id to temp var (in order to prevent overwriting it on selectedtab_changed event to call this method again)
                    _tempSavedModulID = _currentModulID;

                    // select the desired tab page
                    tabModulTree.SelectTab(page);

                    // set flag to prevent rechanging detailcontrol due to switching bug if other module is clicked in FrmFallNavigator
                    _isSwitchingTabShowModule = true;
                }

                if (!_isSwitchingTabShowModule)
                {
                    // reapply modulid (only if we have a temp var)
                    if (_tempSavedModulID > 0)
                    {
                        // reapply id and reset temp var
                        _currentModulID = _tempSavedModulID;
                        _tempSavedModulID = -1;

                        // jump to node
                        GotoModul(kissModulTree, _currentModulID, baPersonID);
                    }

                    // show the detail control on the modul tree
                    kissModulTree.ShowDetail();

                    // check if need to jump to node (only if not from selectedtab_changed event)
                    if (!_isFromSelectedTabChanged)
                    {
                        GotoModul(kissModulTree, _currentModulID, baPersonID);
                    }
                }

                // successfully finished
                return true;
            }
            catch { }
            finally
            {
                // reset flag again
                _isSwitchingTabShowModule = false;
            }

            // if we are here, an error occured
            return false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get the modul tree of the corresponding tab page
        /// </summary>
        /// <param name="page">The page to get tree from</param>
        /// <returns></returns>
        private KissModulTree GetKissModulTree(TabPageEx page)
        {
            // validate
            if (page == null)
            {
                return null;
            }

            foreach (Control ctl in page.Controls)
            {
                if (ctl is KissModulTree)
                {
                    return (KissModulTree)ctl;
                }
            }

            return null;
        }

        /// <summary>
        /// Get the tab page for the desired module
        /// </summary>
        /// <param name="modulID">The id of the modul to get tab page</param>
        /// <returns>The tab page of the modul or null if none was found</returns>
        private TabPageEx GetTabPage(int modulID)
        {
            // search the tab page depending on the name of the tab
            foreach (TabPageEx page in tabModulTree.TabPages)
            {
                if (page.Name == string.Format("tpgModul_{0}", modulID))
                {
                    // tab page found
                    return page;
                }
            }

            // no tab page found
            return null;
        }

        #endregion

        #endregion
    }
}