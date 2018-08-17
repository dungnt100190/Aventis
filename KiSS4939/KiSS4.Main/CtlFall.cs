using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using SharpLibrary.WinControls;

namespace KiSS4.Main
{
    /// <summary>
    /// Container to use for single person's modultree and detail controls, used in <see cref="FrmFall"/>.
    /// </summary>
    public partial class CtlFall : KissUserControl
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        public const string TAB_PAGE_NAME_PATTERN = "tpgModul_{0}";
        public readonly int BaPersonID = -1;
        public readonly int FaFallID = -1;

        #endregion

        #region Private Constant/Read-Only Fields

        private const string CLASS_NAME = "KiSS4.Fallfuehrung.CtlFaSozialSystem";
        private const string CLASS_NAME_ZEITACHSE = "FrmFaZeitachse";
        private const string KEY_PATH_ZEITACHSE = @"System\Fallfuehrung\Zeitachse";
        private readonly ToolTip _ttpPicPerson = new ToolTip();

        #endregion

        #region Private Fields

        private bool _initTabIndex = true;
        private bool _isSwitchingTabShowModule;

        #endregion

        #endregion

        #region Constructors

        public CtlFall(int baPersonID)
            : this(baPersonID, -1)
        {
        }

        public CtlFall(int baPersonID, int faFallID)
            : this()
        {
            BaPersonID = baPersonID;
            FaFallID = faFallID;

            RefreshFallIcons();
        }

        /// <summary>
        /// Default constructor to init control
        /// </summary>
        private CtlFall()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // hide template tab
            tpgTemplate.HideTab = true;

            ShowHideZeitachseButton();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (GuiConfig.Theme != GuiConfig.KissTheme.None)
            {
                panPersonName.BackColor = GuiConfig.colBack06;
                lblPersonName.BackColor = GuiConfig.colBack06;
                picIcon.BackColor = GuiConfig.colBack06;
                panTree.BackColor = GuiConfig.PanelColor;
                tabModulTree.BackColor = GuiConfig.PanelColor;
                tabModulTree.TabsStyle = TabsStyle.Flat;
                tabModulTree.FlatStyleSelectedTabColor = GuiConfig.colBack05;
                tabModulTree.FlatStyleSelectedTabBorderColor = Color.Black;

                panDetailControl.BackColor = GuiConfig.PanelColor;
            }
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

        private void btnZeitachse_Click(object sender, EventArgs e)
        {
            // Prüfen ob eine F-Leistung vorhanden ist
            var hasFLeistung = DBUtil.ExecuteScalarSQLThrowingException(@"
                IF EXISTS(SELECT TOP 1 1
                          FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                          WHERE BaPersonID = {0}
                            AND ModulID = 2)
                BEGIN
                  SELECT CONVERT(BIT, 1);
                END
                ELSE
                BEGIN
                  SELECT CONVERT(BIT, 0);
                END;",
                BaPersonID) as bool? ?? false;

            if (!hasFLeistung)
            {
                KissMsg.ShowInfo(
                    KissMsg.GetMLMessage(
                        CLASS_NAME,
                        "FallfuehrungNichtVorhanden",
                        "Die Zeitachse kann nicht dargestellt werden da keine Fallführung vorhanden ist.",
                        KissMsgCode.MsgInfo));
                return;
            }

            // Zeitachse öffnen
            var dic = new HybridDictionary();
            dic.Add("BaPersonID", BaPersonID);

            dic.Add("ShowOldVersion", false);
            FormController.OpenForm("FrmFaZeitachse", dic);
        }

        /// <summary>
        /// The DetailChanged event, used to show or hide zoom buttons for CtlFaSozialSystem
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void kissModulTree_DetailChanged(object sender, EventArgs e)
        {
            if (CurrentDetailControl != null && CurrentDetailControl.GetType().FullName == CLASS_NAME)
            {
                pbZoomIn.Visible = true;
                pbZoomOut.Visible = true;
            }
            else
            {
                pbZoomIn.Visible = false;
                pbZoomOut.Visible = false;
            }
        }

        private void lblPersonName_DoubleClick(object sender, EventArgs e)
        {
            CopyPersonTitleToClipboard(lblPersonName.Text, BaPersonID);
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

        private void pbZoomIn_Click(object sender, EventArgs e)
        {
            if (CurrentModulTree.DetailControl.GetType().FullName == CLASS_NAME)
            {
                AssemblyLoader.InvokeMethode(AssemblyLoader.GetPropertyValue(CurrentModulTree.DetailControl, "GD"), "ZoomBy", 1.25f);
            }
        }

        private void pbZoomOut_Click(object sender, EventArgs e)
        {
            if (CurrentModulTree.DetailControl.GetType().FullName == CLASS_NAME)
            {
                AssemblyLoader.InvokeMethode(AssemblyLoader.GetPropertyValue(CurrentModulTree.DetailControl, "GD"), "ZoomBy", 0.8f);
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
            KissUserControl ctl = CurrentDetailControl;
            if (ctl != null)
            {
                ctl.Focus();
            }
        }

        /// <summary>
        /// The SelectedTabChanged event on tabcontrol, used to show module of current tab page
        /// </summary>
        /// <param name="page">The page changed to</param>
        private void tabModulTree_SelectedTabChanged(TabPageEx page)
        {
            if (_initTabIndex)
            {
                return;
            }

            // Tag wird in RefreshFallIcons() gefüllt
            int modulID = Convert.ToInt32(page.Tag);
            ShowModule(modulID);
        }

        /// <summary>
        /// The SelectedTabChanging event on tabcontrol, used to save pending changes and prevent tabswitch on error/failure
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The CancelEventArgs, used to allow or deny tabswitch</param>
        private void tabModulTree_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                // get modultree
                KissModulTree ctl = GetKissModulTree(tabModulTree.SelectedTab);

                if (ctl != null)
                {
                    e.Cancel = !ctl.BeforeCloseView();

                    if (!e.Cancel)
                    {
                        // save pending changes
                        e.Cancel = !ctl.OnSaveData();
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlFall", "ErrorSavingDataOnTabSwitch", "Fehler beim Speichern der Daten, das Register kann nicht gewechselt werden.", ex);
                e.Cancel = true;
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Copy given title string to  clipboard. If shift key is pressed, only the id will be copied to clipboard.
        /// </summary>
        /// <param name="title">The string of the whole title to copy</param>
        /// <param name="id">The id of the instance (BaPersonID) to copy</param>
        public static void CopyPersonTitleToClipboard(string title, int id)
        {
            if (string.IsNullOrEmpty(title))
            {
                // do nothing
                return;
            }

            // clear clipboard
            Clipboard.Clear();

            // check mode
            if (id > 0 && ModifierKeys == Keys.Shift)
            {
                // shift is pressed > copy id to clipboard
                Clipboard.SetText(Convert.ToString(id));

                // show info
                KissMsg.ShowInfo("CtlFall", "SuccessfullyCopiedId_v03", "Die ID wurde in den Zwischenspeicher kopiert (ID={0}).", id);
            }
            else
            {
                // copy information to clipboard
                Clipboard.SetText(title);

                // show info
                KissMsg.ShowInfo("CtlFall", "SuccessfullyCopiedTitle", "Die Angaben wurden in den Zwischenspeicher kopiert.");
            }
        }

        #endregion

        #region Public Methods

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

            // action depending
            switch (param["Action"] as string)
            {
                case "JumpToPath":
                    return FormController.SendMessage(CurrentModulTree, param);
            }

            // did not understand message
            return base.ReceiveMessage(param);
        }

        /// <summary>
        /// Refresh the icons of the current fall on tab pages
        /// </summary>
        public void RefreshFallIcons()
        {
            try
            {
                _initTabIndex = true;
                SqlQuery qry = DBUtil.OpenSQL("EXECUTE dbo.spFaGetModulIcon {0}, {1}, 1", BaPersonID, FaFallID == -1 ? null : (object)FaFallID);

                while (qry.Count > 0)
                {
                    TabPageEx page = GetTabPage((int)qry["ModulID"]);
                    if (page == null)
                    {
                        page = new TabPageEx();
                        page.Name = string.Format(TAB_PAGE_NAME_PATTERN, qry["ModulID"]);
                        page.Size = tpgTemplate.Size;
                        page.BackColor = GuiConfig.Theme == GuiConfig.KissTheme.None ? tpgTemplate.BackColor : GuiConfig.colBack04;
                        page.TabIndex = qry.Position;
                        page.Title = "";

                        // Wird beim Aufruf von ShowModule in tabModulTree_SelectedTabChanged benötigt
                        page.Tag = qry["ModulID"].ToString();

                        tabModulTree.TabPages.Add(page);
                    }

                    // setup icon
                    Image modulIcon = KissImageList.GetSmallImage((int)qry["IconID"]);

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
            }
            catch { }
            finally
            {
                _initTabIndex = false;
            }
        }

        /// <summary>
        /// Handle messages from FormController
        /// </summary>
        /// <param name="param">Specific messages as key/value pair for current form</param>
        /// <returns>Specified object that has to be returned to sender</returns>
        public override object ReturnMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return null;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "GetJumpToPath":
                    System.Collections.Specialized.HybridDictionary dic = (System.Collections.Specialized.HybridDictionary)FormController.GetMessage(CurrentModulTree, param);

                    if (!dic.Contains("FaFallID") && dic.Contains("BaPersonID"))
                    {
                        // set BaPersonID as FaFallID (FaFall is no longer used, FaFallID = BaPersonID)
                        dic["FaFallID"] = dic["BaPersonID"];
                    }

                    // apply ClassName
                    dic["ClassName"] = "FrmFall";

                    // return dictionary
                    return dic;
            }

            var result = base.ReturnMessage(param);
            if (result != null)
            {
                return result;
            }

            //ask the DetailControl
            if (CurrentDetailControl != null)
            {
                return CurrentDetailControl.ReturnMessage(param);
            }

            return null;
        }

        /// <summary>
        /// Apply person information title content
        /// </summary>
        public void SetPersonInfoTitel()
        {
            // apply person information title content
            PersonInfoTitel.SetPersonInfoTitel(lblPersonName, picIcon, _ttpPicPerson, BaPersonID);
        }

        /// <summary>
        /// Show the specified module of the current person
        /// </summary>
        /// <param name="modulID">The id of the module to show</param>
        /// <returns>True if successfully switched to the desired module</returns>
        public bool ShowModule(int modulID)
        {
            // get module tree
            TabPageEx page = GetTabPage(modulID);
            if (modulID == (int)ModulID.V && page == null)
            {
                page = GetTabPage((int)ModulID.Kes);
            }

            KissModulTree kissModulTree = GetKissModulTree(page);

            // check if we already have a module tree for this module
            if (kissModulTree == null)
            {
                // tree not found, create a new one for the module
                kissModulTree = AssemblyLoader.GetKissModulTree(modulID, BaPersonID, FaFallID, panDetailControl) as KissModulTree;

                // validate
                if (kissModulTree == null)
                {
                    // no modul tree instance created, cannot proceed
                    return false;
                }

                // add and config tree
                page.Controls.Add(kissModulTree);

                kissModulTree.DetailChanged += kissModulTree_DetailChanged;
                kissModulTree.Location = new Point(0, 0);
                kissModulTree.Dock = DockStyle.Fill;

                // apply fall information content
                SetPersonInfoTitel();
            }

            ApplicationFacade.DoEvents();

            try
            {
                // check if need to switch tab page
                if (tabModulTree.SelectedTab != page)
                {
                    // select the desired tab page
                    tabModulTree.SelectTab(page);

                    // set flag to prevent rechanging detailcontrol due to switching bug if other module is clicked in FrmFallNavigator
                    _isSwitchingTabShowModule = true;
                }

                if (!_isSwitchingTabShowModule)
                {
                    // show the detail control on the modul tree
                    kissModulTree.ShowDetail();
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
                if (page.Name == string.Format(TAB_PAGE_NAME_PATTERN, modulID))
                {
                    // tab page found
                    return page;
                }
            }

            // no tab page found
            return null;
        }

        private void ShowHideZeitachseButton()
        {
            btnZeitachse.Visible = DBUtil.GetConfigBool(KEY_PATH_ZEITACHSE, false);

            if (btnZeitachse.Visible)
            {
                btnZeitachse.Image = Kiss.Infrastructure.Properties.Resources.Kiss_FaZeitachse_16;
                btnZeitachse.Enabled = DBUtil.UserHasRight(CLASS_NAME_ZEITACHSE);
            }
        }

        #endregion

        #endregion
    }
}