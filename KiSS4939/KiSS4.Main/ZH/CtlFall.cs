using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using SharpLibrary.WinControls;

namespace KiSS4.Main.ZH
{
    /// <summary>
    /// Container to use for single person's modultree and detail controls, used in <see cref="FrmFall"/>.
    /// </summary>
    public class CtlFall : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        public readonly int BaPersonID = -1;
        public readonly int FaFallID = -1;

        #endregion

        #region Private Constant/Read-Only Fields

        private const string CtlFaSozialSystem = "KiSS4.Fallfuehrung.CtlFaSozialSystem";

        #endregion

        #region Private Fields

        private int curModulID = -1;
        private SharpLibrary.WinControls.ImageListEx imgModulIcons;
        private bool initTabIndex = true;
        private bool isSwitchingTabShowModule = false;
        private System.Windows.Forms.Label lblPersonName;
        private System.Windows.Forms.Panel panDetailControl;
        private System.Windows.Forms.Panel panPersonName;
        private System.Windows.Forms.Panel panTree;
        private System.Windows.Forms.PictureBox picIcon;
        private KiSS4.Gui.KissSplitterCollapsible splitterTreeControl;
        private KiSS4.Gui.KissTabControlEx tabModulTree;
        private SharpLibrary.WinControls.TabPageEx tpgTemplate;

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
            this.BaPersonID = baPersonID;
            this.FaFallID = faFallID;

            this.RefreshFallIcons();
        }

        public CtlFall()
        {
            this.InitializeComponent();

            // hide template tab
            this.tpgTemplate.HideTab = true;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFall));
            this.panTree = new System.Windows.Forms.Panel();
            this.tabModulTree = new KiSS4.Gui.KissTabControlEx();
            this.tpgTemplate = new SharpLibrary.WinControls.TabPageEx();
            this.splitterTreeControl = new KiSS4.Gui.KissSplitterCollapsible();
            this.panPersonName = new System.Windows.Forms.Panel();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.panDetailControl = new System.Windows.Forms.Panel();
            this.imgModulIcons = new SharpLibrary.WinControls.ImageListEx();
            this.panTree.SuspendLayout();
            this.tabModulTree.SuspendLayout();
            this.panPersonName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            //
            // panTree
            //
            this.panTree.Controls.Add(this.tabModulTree);
            this.panTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.panTree.Location = new System.Drawing.Point(0, 0);
            this.panTree.Name = "panTree";
            this.panTree.Size = new System.Drawing.Size(271, 496);
            this.panTree.TabIndex = 0;
            //
            // tabModulTree
            //
            this.tabModulTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tabModulTree.Controls.Add(this.tpgTemplate);
            this.tabModulTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabModulTree.FirstTabMargin = 3;
            this.tabModulTree.ImageList = this.imgModulIcons;
            this.tabModulTree.Location = new System.Drawing.Point(0, 0);
            this.tabModulTree.Name = "tabModulTree";
            this.tabModulTree.ShowFixedWidthTooltip = true;
            this.tabModulTree.ShowOnlySelectedTabText = true;
            this.tabModulTree.Size = new System.Drawing.Size(271, 496);
            this.tabModulTree.TabBaseColor = System.Drawing.Color.Transparent;
            this.tabModulTree.TabControlStyle = KiSS4.Gui.TabControlStyleType.ModulTree;
            this.tabModulTree.TabIndex = 1;
            this.tabModulTree.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
                        this.tpgTemplate});
            this.tabModulTree.TabsAreaBackColor = System.Drawing.Color.Transparent;
            this.tabModulTree.TabsLineColor = System.Drawing.Color.Black;
            this.tabModulTree.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabModulTree.TabsStyle = SharpLibrary.WinControls.TabsStyle.CustomImages;
            this.tabModulTree.VerticalMargin = 5;
            this.tabModulTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabModulTree_MouseUp);
            this.tabModulTree.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabModulTree_SelectedTabChanged);
            this.tabModulTree.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabModulTree_SelectedTabChanging);
            //
            // tpgTemplate
            //
            this.tpgTemplate.Location = new System.Drawing.Point(6, 34);
            this.tpgTemplate.Name = "tpgTemplate";
            this.tpgTemplate.Size = new System.Drawing.Size(259, 456);
            this.tpgTemplate.TabIndex = 0;
            this.tpgTemplate.Title = "B    ";
            this.tpgTemplate.Visible = false;
            //
            // splitterTreeControl
            //
            this.splitterTreeControl.AnimationDelay = 20;
            this.splitterTreeControl.AnimationStep = 20;
            this.splitterTreeControl.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitterTreeControl.ControlToHide = this.panTree;
            this.splitterTreeControl.ExpandParentForm = false;
            this.splitterTreeControl.Location = new System.Drawing.Point(271, 0);
            this.splitterTreeControl.Name = "splitterTreeControl";
            this.splitterTreeControl.TabIndex = 1;
            this.splitterTreeControl.TabStop = false;
            this.splitterTreeControl.UseAnimations = false;
            this.splitterTreeControl.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            //
            // panPersonName
            //
            this.panPersonName.BackColor = System.Drawing.Color.Wheat;
            this.panPersonName.Controls.Add(this.picIcon);
            this.panPersonName.Controls.Add(this.lblPersonName);
            this.panPersonName.Dock = System.Windows.Forms.DockStyle.Top;
            this.panPersonName.Location = new System.Drawing.Point(279, 0);
            this.panPersonName.Name = "panPersonName";
            this.panPersonName.Size = new System.Drawing.Size(606, 34);
            this.panPersonName.TabIndex = 2;
            //
            // lblPersonName
            //
            this.lblPersonName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonName.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblPersonName.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblPersonName.Location = new System.Drawing.Point(42, 5);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.Size = new System.Drawing.Size(561, 25);
            this.lblPersonName.TabIndex = 0;
            this.lblPersonName.Text = "Person Name";
            this.lblPersonName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPersonName.UseCompatibleTextRendering = true;
            this.lblPersonName.Visible = false;
            this.lblPersonName.DoubleClick += new EventHandler(lblPersonName_DoubleClick);
            //
            // picIcon
            //
            this.picIcon.Image = ((System.Drawing.Image)(resources.GetObject("picIcon.Image")));
            this.picIcon.Location = new System.Drawing.Point(13, 4);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(30, 24);
            this.picIcon.TabIndex = 2;
            this.picIcon.TabStop = false;
            //
            // panDetailControl
            //
            this.panDetailControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetailControl.Location = new System.Drawing.Point(279, 34);
            this.panDetailControl.Name = "panDetailControl";
            this.panDetailControl.Size = new System.Drawing.Size(606, 462);
            this.panDetailControl.TabIndex = 3;
            this.panDetailControl.Resize += new System.EventHandler(this.panDetailControl_Resize);
            //
            // CtlFall
            //
            this.Controls.Add(this.panDetailControl);
            this.Controls.Add(this.panPersonName);
            this.Controls.Add(this.splitterTreeControl);
            this.Controls.Add(this.panTree);
            this.Name = "CtlFall";
            this.Size = new System.Drawing.Size(885, 496);
            this.panTree.ResumeLayout(false);
            this.tabModulTree.ResumeLayout(false);
            this.panPersonName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
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
                foreach (TabPageEx page in this.tabModulTree.TabPages)
                {
                    KissModulTree ctl = this.GetKissModulTree(page);
                    if (ctl != null)
                    {
                        ctl.OnSaveData();
                        ctl.Dispose();
                    }
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Properties

        public int CurrentBaPersonID
        {
            get { return this.BaPersonID; }
        }

        /// <summary>
        /// Get the instance of the current detail control
        /// </summary>
        public KissUserControl CurrentDetailControl
        {
            get
            {
                // get current modul tree
                KissModulTree tree = this.CurrentModulTree;

                // validate
                if (tree != null)
                {
                    return tree.DetailControl;
                }

                // not found
                return null;
            }
        }

        public ModulID CurrentModul
        {
            get { return (ModulID)this.curModulID; }
        }

        public int CurrentModulID
        {
            get { return this.curModulID; }
        }

        /// <summary>
        /// Get the instance of the current modultree
        /// </summary>
        public KissModulTree CurrentModulTree
        {
            get { return GetKissModulTree(this.tabModulTree.SelectedTab); }
        }

        #endregion

        #region EventHandlers

        private void lblPersonName_DoubleClick(object sender, EventArgs e)
        {
            // copy information to clipboard
            KiSS4.Main.CtlFall.CopyPersonTitleToClipboard(lblPersonName.Text, BaPersonID);
        }

        /// <summary>
        /// The Resize event, used to resize detail control depending on available space
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void panDetailControl_Resize(object sender, System.EventArgs e)
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

        /// <summary>
        /// The SelectedTabChanged event on tabcontrol, used to show module of current tab page
        /// </summary>
        /// <param name="page">The page changed to</param>
        private void tabModulTree_SelectedTabChanged(TabPageEx page)
        {
            if (initTabIndex)
            {
                return;
            }

            // we do not have to use index-1 due to hidden tab page that has the index=0
            // int modulID = tabModulTree.SelectedTabIndex; // Falsch! Wenn ein Modul ausgeblendet wird, hat das dahinterliegende eine andere ModulID als Index
            int modulID = (int)tabModulTree.SelectedTab.Tag;
            ShowModule(modulID);
        }

        // Letzte Bearbeitung
        // 18.10.2007 : sozheo : tabModulTree_SelectedTabChanging neu, damit Wechsel verhindert wird,
        //                       wenn aktuelle Maske nicht gespeichert werden kann
        // --------------------------------------------------------------------------------------------------------
        private void tabModulTree_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            try
            {
                // get modultree
                KissModulTree ctl = this.GetKissModulTree(tabModulTree.SelectedTab);
                if (ctl != null)
                {
                    // save pending changes
                    e.Cancel = !ctl.OnSaveData();
                    ctl.Focus();
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlFall", "ErrorSavingDataOnTabSwitch",
                  "Fehler beim Speichern der Daten, das Register kann nicht gewechselt werden.", ex);
                e.Cancel = true;
            }
        }

        #endregion

        #region Methods

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
                initTabIndex = true;

                SqlQuery qry = DBUtil.OpenSQL("EXECUTE spFaGetModulIcon {0}, {1}, 1",
                this.BaPersonID, this.FaFallID == -1 ? null : (object)this.FaFallID);

                while (qry.Count > 0)
                {
                    TabPageEx page = this.GetTabPage((int)qry["ModulID"]);
                    if (page == null)
                    {
                        page = new TabPageEx();
                        page.Name = string.Format("tpgModul_{0}", qry["ModulID"]);
                        page.Size = this.tpgTemplate.Size;
                        page.BackColor = GuiConfig.Theme == GuiConfig.KissTheme.None ? tpgTemplate.BackColor : GuiConfig.colBack04;
                        page.TabIndex = qry.Position;
                        page.Title = "";
                        page.Tag = qry["ModulID"];

                        this.tabModulTree.TabPages.Add(page);
                    }

                    // setup icon
                    Image modulIcon = KissImageList.GetSmallImage((int)qry["IconID"]);
                    if (this.imgModulIcons != null)
                    {
                        if (this.imgModulIcons.Images.Contains(modulIcon))
                        {
                            page.ImageIndex = this.imgModulIcons.Images.IndexOf(modulIcon);
                        }
                        else
                        {
                            this.imgModulIcons.Images.Add(modulIcon);
                            page.ImageIndex = this.imgModulIcons.Images.IndexOf(modulIcon);
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
                initTabIndex = false;
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
                        dic["FaFallID"] = DBUtil.ExecuteScalarSQL(@"
                            SELECT TOP 1 FaFallID
                            FROM FaFall
                            WHERE BaPersonID = {0}
                            ORDER BY DatumVon DESC", dic["BaPersonID"]);
                    }
                    return dic;
            }

            return base.ReturnMessage(param);
        }

        /// <summary>
        /// Setup person name to show in label
        /// </summary>
        /// <param name="PersonName">The name to show</param>
        public void SetPersonName(string PersonName)
        {
            lblPersonName.Text = PersonName;
            lblPersonName.Visible = true;
        }

        /// <summary>
        /// Show the specified module of the current person
        /// </summary>
        /// <param name="modulID">The id of the module to show</param>
        /// <returns>True if successfully switched to the desired module</returns>
        public bool ShowModule(int modulID)
        {
            // apply fields
            this.curModulID = modulID;

            // get module tree
            TabPageEx page = this.GetTabPage(modulID);
            KissModulTree kissModulTree = this.GetKissModulTree(page);

            // check if we already have a module tree for this module
            if (kissModulTree == null)
            {
                // tree not found, create a new one for the module
                kissModulTree = AssemblyLoader.GetKissModulTree(modulID, this.BaPersonID, this.FaFallID, this.panDetailControl) as KissModulTree;

                // validate
                if (kissModulTree == null)
                {
                    // no modul tree instance created, cannot proceed
                    return false;
                }

                // add and config tree
                page.Controls.Add(kissModulTree);

                kissModulTree.Location = new System.Drawing.Point(0, 0);
                kissModulTree.Dock = System.Windows.Forms.DockStyle.Fill;

                // apply label
                string PersonName = (string)DBUtil.ExecuteScalarSQL(@"
                    SELECT 	top 1
                        Name + isNull(', ' + Vorname,'') + '  (' +
                        'Fall ' + convert(varchar, FAL.FaFallID) + ' - ' +
                        USR.LogonName + ')'
                    FROM	FaFall FAL
                        INNER JOIN FaLeistung LEI ON LEI.FaFallID = FAL.FaFallID AND
                                              LEI.FaProzessCode in (200,201)
                        INNER JOIN BaPerson PRS ON PRS.BaPersonID = FAL.BaPersonID
                        INNER JOIN XUser    USR ON USR.UserID = FAL.UserID
                    WHERE FAL.BaPersonID = {0} AND FAL.FaFallID = IsNull({1}, FAL.FaFallID)
                    ORDER BY CASE WHEN LEI.DatumBis IS NULL THEN 0 ELSE 1 END, LEI.DatumVon desc",
                    this.BaPersonID,
                    this.FaFallID == -1 ? null : (object)this.FaFallID);
                SetPersonName(PersonName); //bisher: SetPersonName(kissModulTree.NamePersonPlusGeburtTod);
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
                    this.isSwitchingTabShowModule = true;
                }

                if (kissModulTree != null && !this.isSwitchingTabShowModule)
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
                this.isSwitchingTabShowModule = false;
            }

            // if we are here, an error occured
            return false;
        }

        /// <summary>
        /// Get the instance of the modultree with the provided modulid
        /// Returns null if the modultree is not created
        /// </summary>
        public KissModulTree GetModulTree(ModulID modul)
        {
            return GetKissModulTree(this.GetTabPage((int)modul));
        }

        #endregion

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
            foreach (TabPageEx page in this.tabModulTree.TabPages)
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