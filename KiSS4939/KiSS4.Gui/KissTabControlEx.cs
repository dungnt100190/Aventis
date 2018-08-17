using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.DB;
using SharpLibrary.WinControls;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissTextEdit.
    /// </summary>
    public class KissTabControlEx : TabControlEx
    {
        #region Fields

        #region Private Static Fields

        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "KissTabControlEx";

        #endregion

        #region Private Fields

        /// <summary>
        /// Icon index in XIcon used to show the image for the non-selected tab in popup menu
        /// </summary>
        private int _iconIndexPopupNonSelected = 132;

        /// <summary>
        /// Icon index in XIcon used to show the image for the selected tab in popup menu
        /// </summary>
        private int _iconIndexPopupSelected = 5005;

        /// <summary>
        /// The rectangle to draw the close button if KissTabControlStyle is Buttons
        /// </summary>
        private Rectangle buttonClose;

        /// <summary>
        /// The rectangle to draw the next button if KissTabControlStyle is Buttons
        /// </summary>
        private Rectangle buttonNext;

        /// <summary>
        /// The rectangle to draw the previous button if KissTabControlStyle is Buttons
        /// </summary>
        private Rectangle buttonPrevious;

        /// <summary>
        /// A rectangle used to override mouseover on glyph arrows from tabcontrol
        /// </summary>
        private Rectangle glyphsArrows;

        /// <summary>
        /// Icon index in XIcon used to show an icon on tab if ShowIconOnContainingData is true
        /// Flag: <see cref="ShowIconOnContainingData"/>
        /// </summary>
        private int iconIndexOnContainingData = 81;

        /// <summary>
        /// Icon index in XIcon used to show an icon on selected tab if KissTabControlStyle is Buttons
        /// Flag: <see cref="IconIndexSelectedTab"/>
        /// </summary>
        private int iconIndexSelectedTab = 165;

        /// <summary>
        /// Icon index in XIcon used to show an icon on unselected tab if KissTabControlStyle is Buttons
        /// Flag: <see cref="IconIndexUnselectedTab"/>
        /// </summary>
        private int iconIndexUnselectedTab = 166;

        private SharpLibrary.WinControls.ImageListEx imgListButtons;
        private SharpLibrary.WinControls.ImageListEx imgListModulTree;
        private SharpLibrary.WinControls.ImageListEx imgListSelectedUnselectedIcon;

        /// <summary>
        /// The flag if the close button is actually hovered by the mouse
        /// </summary>
        private bool isButtonCloseHover;

        /// <summary>
        /// The flag if the next button is actually hovered by the mouse
        /// </summary>
        private bool isButtonNextHover;

        /// <summary>
        /// The flag if the previous button is actually hovered by the mouse
        /// </summary>
        private bool isButtonPreviousHover;

        /// <summary>
        /// Used to set wheather to show an icon on tab if any of the controls of the tab contains data
        /// </summary>
        private bool showIconOnContainingData;

        /// <summary>
        /// Used to set wheather to check only bindable controls for containing data if flag showIconOnContainingData is true
        /// </summary>
        private bool showIconOnlyBindableControls = true;

        /// <summary>
        /// The style to use for the tabcontrol
        /// </summary>
        private TabControlStyleType tabControlStyle = TabControlStyleType.Standard;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissTabControlEx"/> class.
        /// </summary>
        public KissTabControlEx()
        {
            // init stuff
            InitializeComponent();

            tabControlStyle = TabControlStyleType.Standard;
            SetAppearance(false);
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KissTabControlEx));
            this.imgListModulTree = new SharpLibrary.WinControls.ImageListEx();
            this.imgListButtons = new SharpLibrary.WinControls.ImageListEx();
            this.imgListSelectedUnselectedIcon = new SharpLibrary.WinControls.ImageListEx();
            this.SuspendLayout();
            //
            // imgListModulTree
            //
            this.imgListModulTree.Image = ((System.Drawing.Bitmap)(resources.GetObject("imgListModulTree.Image")));
            this.imgListModulTree.ImageSize = new System.Drawing.Size(15, 25);
            this.imgListModulTree.TransparentColor = System.Drawing.Color.Blue;
            //
            // imgListButtons
            //
            this.imgListButtons.Image = ((System.Drawing.Bitmap)(resources.GetObject("imgListButtons.Image")));
            this.imgListButtons.ImageSize = new System.Drawing.Size(14, 30);
            this.imgListButtons.TransparentColor = System.Drawing.Color.Blue;
            //
            // imgListSelectedUnselectedIcon
            //
            this.imgListSelectedUnselectedIcon.TransparentColor = System.Drawing.Color.Blue;
            //
            // KissTabControlEx
            //
            this.VisibleChanged += new System.EventHandler(this.KissTabControlEx_VisibleChanged);
            this.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.KissTabControlEx_SelectedTabChanged);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.KissTabControlEx_ControlRemoved);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.KissTabControlEx_ControlAdded);
            this.ResumeLayout(false);
        }

        #endregion

        #region Events

        /// <summary>
        /// Event is fired when the mouse up event occures on TabControlStyle.Buttons
        /// </summary>
        public event MouseEventHandler MouseUpButtonStyle;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value>The border style.</value>
        [Browsable(true)]
        [DefaultValue(SharpLibrary.WinControls.BorderStyleEx.FixedSingle)]
        public override SharpLibrary.WinControls.BorderStyleEx BorderStyleEx
        {
            get { return base.BorderStyleEx; }
            set { base.BorderStyleEx = value; }
        }

        /// <summary>
        /// Gets or sets the first tab margin.
        /// </summary>
        /// <value>The first tab margin.</value>
        [Browsable(true)]
        [DefaultValue(0)]
        public new int FirstTabMargin
        {
            get { return base.FirstTabMargin; }
            set { base.FirstTabMargin = value; }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value></value>
        /// <returns>The <see cref="T:System.Drawing.Font"></see> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont"></see> property.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        [Browsable(true)]
        public override System.Drawing.Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        /// <summary>
        /// Icon index in XIcon used to show an icon on tab if ShowIconOnContainingData is true
        /// </summary>
        [Browsable(true)]
        [DefaultValue(81)]
        [Description("Icon index in XIcon used to show an icon on tab if ShowIconOnContainingData is true")]
        [TypeConverter(typeof(Designer.KissImageListConverter)),
        Editor(typeof(Designer.KissImageListEditor), typeof(UITypeEditor))]
        public int IconIndexOnContainingData
        {
            get { return iconIndexOnContainingData; }
            set
            {
                // apply value
                iconIndexOnContainingData = value;

                // update icons
                ShowIconUpdate();
            }
        }

        /// <summary>
        /// Icon index in XIcon used to show the image for the non-selected tab in popup menu
        /// </summary>
        [Browsable(true)]
        [DefaultValue(132)]
        [Description("Icon index in XIcon used to show the image for the non-selected tab in popup menu (only if KissTabControlStyle is Buttons)")]
        [TypeConverter(typeof(Designer.KissImageListConverter)),
        Editor(typeof(Designer.KissImageListEditor), typeof(UITypeEditor))]
        public int IconIndexPopupNonSelected
        {
            get { return _iconIndexPopupNonSelected; }
            set { _iconIndexPopupNonSelected = value; }
        }

        /// <summary>
        /// Icon index in XIcon used to show the image for the selected tab in popup menu
        /// </summary>
        [Browsable(true)]
        [DefaultValue(5005)]
        [Description("Icon index in XIcon used to show the image for the selected tab in popup menu (only if KissTabControlStyle is Buttons)")]
        [TypeConverter(typeof(Designer.KissImageListConverter)),
        Editor(typeof(Designer.KissImageListEditor), typeof(UITypeEditor))]
        public int IconIndexPopupSelected
        {
            get { return _iconIndexPopupSelected; }
            set { _iconIndexPopupSelected = value; }
        }

        /// <summary>
        /// Icon index in XIcon used to show an icon on selected tab if KissTabControlStyle is Buttons
        /// </summary>
        [Browsable(true)]
        [DefaultValue(165)]
        [Description("Icon index in XIcon used to show an icon on selected tab if KissTabControlStyle is Buttons")]
        [TypeConverter(typeof(Designer.KissImageListConverter)),
        Editor(typeof(Designer.KissImageListEditor), typeof(UITypeEditor))]
        public int IconIndexSelectedTab
        {
            get { return iconIndexSelectedTab; }
            set
            {
                // apply value
                iconIndexSelectedTab = value;

                // update icons
                UpdateSelectedUnselectedIconList(true);
            }
        }

        /// <summary>
        /// Icon index in XIcon used to show an icon on unselected tab if KissTabControlStyle is Buttons
        /// </summary>
        [Browsable(true)]
        [DefaultValue(166)]
        [Description("Icon index in XIcon used to show an icon on unselected tab if KissTabControlStyle is Buttons")]
        [TypeConverter(typeof(Designer.KissImageListConverter)),
        Editor(typeof(Designer.KissImageListEditor), typeof(UITypeEditor))]
        public int IconIndexUnselectedTab
        {
            get { return iconIndexUnselectedTab; }
            set
            {
                // apply value
                iconIndexUnselectedTab = value;

                // update icons
                UpdateSelectedUnselectedIconList(true);
            }
        }

        /// <summary>
        /// Used to set wheather to show an icon on tab if any of the controls of the tab contains data
        /// </summary>
        [Browsable(true)]
        [DefaultValue(false)]
        [Description("Used to set wheather to show an icon on tab if any of the controls of the tab contains data. Setup IconIndexOnContainingData to change default icon.")]
        public bool ShowIconOnContainingData
        {
            get { return showIconOnContainingData; }
            set
            {
                // apply value
                showIconOnContainingData = value;

                // handling design mode
                if (DesignMode)
                {
                    return;
                }

                // need to show icons?
                if (this.showIconOnContainingData)
                {
                    // setup tabcontrol to display icons
                    this.ShowIcon = true;
                    this.ImageList = new SharpLibrary.WinControls.ImageListEx(KissImageList.SmallImageList);
                }

                // update icons
                ShowIconUpdate();
            }
        }

        /// <summary>
        /// Used to set wheather to check only bindable controls for containing data if flag showIconOnContainingData is true
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [Description("Used to set wheather to check only bindable controls for containing data if flag ShowIconOnContainingData is true")]
        public bool ShowIconOnlyBindableControls
        {
            get { return showIconOnlyBindableControls; }
            set
            {
                // apply value
                showIconOnlyBindableControls = value;

                // update icons
                ShowIconUpdate();
            }
        }

        /// <summary>
        /// The KiSS specific style of the TabControl. This will change some other properties if set.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(TabControlStyleType.Standard)]
        [Description("The KiSS specific style of the TabControl. This will change some other properties if set.")]
        public TabControlStyleType TabControlStyle
        {
            get { return this.tabControlStyle; }
            set
            {
                // check if user changed style from one to another
                bool changedFromOtherStyle = value != this.tabControlStyle;

                tabControlStyle = value;
                SetAppearance(changedFromOtherStyle);
            }
        }

        /// <summary>
        /// Gets or sets the backcolor of the tabs.
        /// </summary>
        /// <value>The color.</value>
        [Browsable(true)]
        public new Color TabsAreaBackColor
        {
            get { return base.TabsAreaBackColor; }
            set { base.TabsAreaBackColor = value; }
        }

        /// <summary>
        /// Gets or sets the tabs fitting.
        /// </summary>
        /// <value>The tabs fitting.</value>
        [Browsable(true)]
        [DefaultValue(SharpLibrary.WinControls.TabsFitting.ShrinkTabs)]
        public new SharpLibrary.WinControls.TabsFitting TabsFitting
        {
            get { return base.TabsFitting; }
            set { base.TabsFitting = value; }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Event when a new control was added, used to update icons
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void KissTabControlEx_ControlAdded(object sender, ControlEventArgs e)
        {
            ShowIconUpdate();
        }

        /// <summary>
        /// Event when a control was removed, used to update icons
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void KissTabControlEx_ControlRemoved(object sender, ControlEventArgs e)
        {
            ShowIconUpdate();
        }

        /// <summary>
        /// Event when selected tab changed, used to update icons
        /// </summary>
        /// <param name="page">The page to which the user changed</param>
        private void KissTabControlEx_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            ShowIconUpdate();
        }

        /// <summary>
        /// Event when the tabcontrol changes its visible property.
        /// Used to update icons without changing the selected tab first after loading.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void KissTabControlEx_VisibleChanged(object sender, EventArgs e)
        {
            ShowIconUpdate();
        }

        /// <summary>
        /// Eventhandler if a new tab page was added or an existing tab page was removed
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void TabPages_CollectionChanged(object sender, EventArgs e)
        {
            // update icons on tabs depending on style
            UpdateSelectedUnselectedIconsOnTabs(false);

            // update spaces
            this.UpdateTabsTitle(false);
        }

        /// <summary>
        /// Eventhandler if popup menu item for selecting special tabpage was clicked
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void popupMenuItem_Click(object sender, EventArgs e)
        {
            // validate sender
            if (!(sender is ToolStripMenuItem))
            {
                // invalid sender
                return;
            }

            // get instance
            ToolStripMenuItem itm = ((ToolStripMenuItem)sender);

            // validate tag
            if (itm.Tag == null || !(itm.Tag is int))
            {
                // invalid tag content
                return;
            }

            // get tabindex stored in tag
            int tabIndex = Convert.ToInt32(itm.Tag);

            // validate index
            if (tabIndex < 0 || tabIndex > this.TabPages.Count - 1)
            {
                // invalid index
                return;
            }

            // select desired tab if different
            if (this.SelectedTabIndex != tabIndex)
            {
                // try to select tabindex
                this.SelectedTabIndex = tabIndex;

                // check if selection succeeded
                if (this.SelectedTabIndex != tabIndex)
                {
                    // did not work, this is because the selected tab is behind visible tabs, make it first visible and try again
                    this.MakePageVisible(tabIndex);

                    // first let it flow
                    ApplicationFacade.DoEvents();

                    // reselect
                    this.SelectedTabIndex = tabIndex;

                    // recheck
                    if (this.SelectedTabIndex != tabIndex)
                    {
                        KissMsg.ShowError(CLASSNAME, "FailedSelectingTabFromPopup", "Der gewünschte Eintrag konnte nicht ausgewählt werden.");
                    }
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Closes the active tab
        /// </summary>
        public void CloseActiveTab()
        {
            // save current cursor
            Cursor currentCursor = this.Cursor;

            try
            {
                // set cursor
                this.Cursor = Cursors.WaitCursor;

                // this button will only work if valid tab is available
                if (IsTabSelected())
                {
                    // Check if saving is possible
                    if (this.SelectedTab != null
                        && this.SelectedTab.Controls != null
                        && SelectedTab.Controls.Count > 0
                        && this.SelectedTab.Controls[0] is KissUserControl)
                    {
                        if (!((KissUserControl)this.SelectedTab.Controls[0]).OnSaveData())
                        {
                            return;
                        }
                    }

                    // close tab
                    this.OnCloseButtonClicked();

                    // recheck
                    if (!IsTabSelected())
                    {
                        // update button
                        this.isButtonCloseHover = false;
                        this.Invalidate();

                        // check if we have other tabs to show (otherwise, possibly no tab would be shown even if we have some tabs available)
                        if (this.TabPages != null && this.TabPages.Count > 0)
                        {
                            // select first tab (using keys to ensure proper working)
                            this.SelectTab(this.TabPages[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(CLASSNAME, "ErrorClosingTab", "Fehler beim Schliessen aufgetreten.", ex);
            }
            finally
            {
                // reset cursor
                this.Cursor = currentCursor;
            }
        }

        /// <summary>
        /// Check if a valid tab is selected
        /// </summary>
        /// <returns>True if a tab is selected, otherwise false</returns>
        public bool IsTabSelected()
        {
            // check if a tab exists and is selected
            return this.TabPages != null && this.SelectedTabIndex > -1 && this.TabPages.Count > this.SelectedTabIndex;
        }

        /// <summary>
        /// Check if specific tab is selected
        /// </summary>
        /// <param name="page">The tab page to check if it is selected</param>
        /// <returns>True if this specific tab page is selected, otherwise false</returns>
        public bool IsTabSelected(TabPageEx page)
        {
            // compare with selected tab
            return this.SelectedTab == page;
        }

        /// <summary>
        /// Remove the icons from all tabs.
        /// This can be used to clear when changing ShowIconOnContainingData property to false after it was true
        /// </summary>
        public void RemoveIconsOnTabs()
        {
            // do we have any tabpages to update
            if (this.TabPages.Count > 0)
            {
                // loop tab pages
                foreach (SharpLibrary.WinControls.TabPageEx tab in this.TabPages)
                {
                    // remove icon from tab
                    tab.ImageIndex = -1;
                }
            }
        }

        /// <summary>
        /// Select the desired tab page on tabcontrol
        /// </summary>
        /// <param name="page">The page to select</param>
        /// <returns>True if tab was selected, otherwise false</returns>
        public bool SelectTab(TabPageEx page)
        {
            // validate first
            if (page == null || this.TabPages == null || this.TabPages.Count < 1 || this.TabPages.IndexOf(page) < 0)
            {
                return false;
            }

            // select tab
            this.SelectedTabIndex = this.TabPages.IndexOf(page);

            // ensure visible
            if (this.SelectedTabIndex != this.TabPages.IndexOf(page))
            {
                // force showing tab page (not the best way!!)
                this.MakePageVisible(page);
                ApplicationFacade.DoEvents();
                this.SelectedTabIndex = this.TabPages.IndexOf(page);
            }

            // ok
            return true;
        }

        /// <summary>
        /// Select a Tab specified by its name
        /// </summary>
        /// <param name="tabPageName"></param>
        public void SelectTab(string tabPageName)
        {
            TabPageEx tabPageToSelect = null;
            foreach (TabPageEx tabPage in TabPages)
            {
                if (tabPage.Name == tabPageName)
                {
                    tabPageToSelect = tabPage;
                    break;
                }
            }

            if (tabPageToSelect != null)
            {
                SelectTab(tabPageToSelect);
            }
        }

        /// <summary>
        /// Update tabPages and any icons on it depending if a control contains data from datasource
        /// </summary>
        public void ShowIconUpdate()
        {
            try
            {
                // do we have any tabpages to update
                if (this.showIconOnContainingData && !DesignMode && this.TabPages != null && this.TabPages.Count > 0)
                {
                    // loop tab pages
                    foreach (SharpLibrary.WinControls.TabPageEx tab in this.TabPages)
                    {
                        // do not show any icon by default
                        tab.ImageIndex = -1;
                        bool showIcon = false;

                        // check if tab page has any controls
                        if (tab.Controls.Count > 0)
                        {
                            // loop controls
                            foreach (Control ctl in UtilsGui.AllControls(tab))
                            {
                                // check if only validate BindableEdit
                                if (this.ShowIconOnlyBindableControls)
                                {
                                    // IKissBindableEdit-Controls
                                    if (ctl != null && typeof(IKissBindableEdit).IsAssignableFrom(ctl.GetType()))
                                    {
                                        // convert to use databinding
                                        IKissBindableEdit ctlBindable = ctl as IKissBindableEdit;

                                        // check if control contains any data using its datasource and datamember
                                        if (ctlBindable.DataSource != null && !DBUtil.IsEmpty(ctlBindable.DataMember) && !DBUtil.IsEmpty(ctlBindable.DataSource[ctlBindable.DataMember]))
                                        {
                                            // do not evaluate checkboxes due to unknown state from mostly set default value on database
                                            if (IsControlCheckBox(ctl))
                                            {
                                                // go on with next control
                                                continue;
                                            }

                                            // continue with next tab
                                            showIcon = true;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    // Controls
                                    if (ctl != null)
                                    {
                                        // do not evaluate checkboxes due to unknown state from mostly set default value on database
                                        if (IsControlCheckBox(ctl))
                                        {
                                            // go on with next control
                                            continue;
                                        }

                                        if (typeof(DevExpress.XtraEditors.BaseEdit).IsAssignableFrom(ctl.GetType()))
                                        {
                                            // DevExpress.XtraEditors.BaseEdit-Controls (KissCalcEdit, KissTextEdit, ...)
                                            if (!DBUtil.IsEmpty((ctl as DevExpress.XtraEditors.BaseEdit).EditValue))
                                            {
                                                // continue with next tab
                                                showIcon = true;
                                                break;
                                            }
                                        }
                                        else if (typeof(RichTextBox).IsAssignableFrom(ctl.GetType()))
                                        {
                                            // any RichTextBox-Control
                                            if (!DBUtil.IsEmpty((ctl as RichTextBox).Text))
                                            {
                                                // continue with next tab
                                                showIcon = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            } // [foreach control in tab]
                        } // [tab.Controls.Count > 0]

                        // need to show an icon on this tab?
                        if (showIcon)
                        {
                            tab.ImageIndex = KissImageList.GetImageIndex(this.IconIndexOnContainingData);
                        }
                    } // [foreach tab]
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                // do nothing unless is debugger
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                }
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:FontChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnFontChanged(System.EventArgs e)
        {
            SetAppearance(false);
            base.OnFontChanged(e);
        }

        /// <summary>
        /// The MouseDown event, used to catch the button clicks
        /// </summary>
        /// <param name="e">The event arguements</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // handle button
            if (!this.DesignMode && this.TabControlStyle == TabControlStyleType.Buttons)
            {
                #region Popup Menu

                // handle popup menu
                if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None)
                {
                    // POPUP MENU
                    // **********
                    try
                    {
                        // check if needed to show menu (only more than one tab)
                        if (this.TabPages.Count < 2)
                        {
                            // do not show any menu
                            return;
                        }

                        // create required menu instances
                        ContextMenuStrip popupMenu = new ContextMenuStrip();
                        Image img = KissImageList.GetSmallImage(IconIndexPopupNonSelected);

                        // add tabs as items to popup menu
                        foreach (TabPageEx tab in this.TabPages)
                        {
                            ToolStripMenuItem itm = new ToolStripMenuItem();
                            itm.Text = tab.Title;
                            itm.Image = img;
                            itm.Tag = tab.TabIndex;
                            itm.Click += new EventHandler(popupMenuItem_Click);

                            if (this.IsTabSelected(tab))
                            {
                                itm.Image = KissImageList.GetSmallImage(IconIndexPopupSelected);
                                itm.Font = new Font(itm.Font, FontStyle.Bold);
                            }

                            popupMenu.Items.Add(itm);
                        }

                        // show menu
                        popupMenu.Show(this, e.Location);
                    }
                    catch (Exception ex)
                    {
                        KissMsg.ShowError(CLASSNAME, "ErrorShowPopupMenu", "Es ist ein Fehler beim Anzeigen des Popup-Menus aufgetreten.", ex);
                    }

                    // done
                    return;
                }

                #endregion

                #region Previous Button

                // handle own drawn buttons
                if (this.isButtonPreviousHover && !this.isButtonNextHover && !this.isButtonCloseHover)
                {
                    // BUTTON PREVIOUS CLICK
                    // *********************
                    try
                    {
                        // validate first
                        if (!IsFirstTabSelected())
                        {
                            // get current active tab
                            int currentSelectedIndex = this.SelectedTabIndex;

                            // select previous tab (use key shortcuts due to a lot of problems if we do it otherway round)
                            base.OnKeyDown(new KeyEventArgs(Keys.Left));

                            // check if button did its job
                            if (currentSelectedIndex == this.SelectedTabIndex)
                            {
                                // button did not work, this is because the selected tab is behind visible tabs, make it first visible and try again
                                this.MakePageVisible(this.SelectedTab);
                                ApplicationFacade.DoEvents();
                                base.OnKeyDown(new KeyEventArgs(Keys.Left));
                            }

                            // recheck
                            if (IsFirstTabSelected())
                            {
                                // update button
                                this.isButtonPreviousHover = false;
                                this.Invalidate();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        KissMsg.ShowError(CLASSNAME, "ErrorSwitchTab", "Fehler beim Wechseln aufgetreten.", ex);
                    }

                    // done
                    return;
                }

                #endregion

                #region Next Button

                if (!this.isButtonPreviousHover && this.isButtonNextHover && !this.isButtonCloseHover)
                {
                    // BUTTON NEXT CLICK
                    // *****************
                    try
                    {
                        // validate first
                        if (!IsLastTabSelected())
                        {
                            // get current active tab
                            int currentSelectedIndex = this.SelectedTabIndex;

                            // select next tab (use key shortcuts due to a lot of problems if we do it otherway round)
                            base.OnKeyDown(new KeyEventArgs(Keys.Right));

                            // check if button did its job
                            if (currentSelectedIndex == this.SelectedTabIndex)
                            {
                                // button did not work, this is because the selected tab is behind visible tabs, make it first visible and try again
                                this.MakePageVisible(this.SelectedTab);
                                ApplicationFacade.DoEvents();
                                base.OnKeyDown(new KeyEventArgs(Keys.Right));
                            }

                            // recheck
                            if (IsLastTabSelected())
                            {
                                // update button
                                this.isButtonNextHover = false;
                                this.Invalidate();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        KissMsg.ShowError(CLASSNAME, "ErrorSwitchTab", "Fehler beim Wechseln aufgetreten.", ex);
                    }

                    // done
                    return;
                }

                #endregion

                #region Close Button

                if (!this.isButtonPreviousHover && !this.isButtonNextHover && this.isButtonCloseHover)
                {
                    // BUTTON CLOSE CLICK
                    // ******************
                    // validate first if user is allowed to close tpg
                    if (!CanCloseActiveTpg())
                    {
                        // show message and cancel
                        KissMsg.ShowInfo(CLASSNAME, "CannotCloseTpgFormLocked", "Bitte warten Sie mit dem Schliessen, bis alle Daten fertig geladen sind.");

                        return;
                    }

                    // close tpg
                    CloseActiveTab();

                    // done
                    return;
                }

                #endregion

                #region Disabled buttons

                // check if disabled button
                if (IsMouseOverButtonPrevious(e) || IsMouseOverButtonNext(e) || IsMouseOverButtonClose(e))
                {
                    // do not allow click if button is disabled and not yet catched
                    return;
                }

                #endregion
            }

            // let base do stuff if not clicked a button
            base.OnMouseDown(e);
        }

        /// <summary>
        /// The MoseLeave event, used to catch when the mouse leaves the control to reset button
        /// </summary>
        /// <param name="e">The event arguements</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            try
            {
                // let base do stuff
                base.OnMouseLeave(e);
            }
            catch (ArgumentException ex)
            {
                // Siehe #6225
                // Ein Fehler in SharpLibrary.WinControls.TabControlEx.OnMouseLeave beim Erstellen von Bitmaps
                // führt zu übertriebenen Fehlermeldungen (Standard-Fehlermeldung in Program.cs fordert zum Neustart von KiSS auf ).
                // Für den Moment: Nur den Fehler loggen.
                // TODO: Evt. neue Version von SharpLibrary?
                LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);
                XLog.Create(GetType().FullName, LogLevel.WARN, ex.Message);
            }

            // setup button
            if (this.TabControlStyle == TabControlStyleType.Buttons)
            {
                // ensure that the mouse hover states are removed
                this.isButtonPreviousHover = false;
                this.isButtonNextHover = false;
                this.isButtonCloseHover = false;
                this.Invalidate();
            }
        }

        /// <summary>
        /// The MoseMove event, used to catch when user is over the button
        /// </summary>
        /// <param name="e">The event arguements</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // check if need base to handle mousemove
            if (this.TabControlStyle == TabControlStyleType.Buttons)
            {
                // check to see if mouse is over glyphs
                if (!(e.X >= glyphsArrows.X && e.X <= glyphsArrows.X + glyphsArrows.Width && e.Y >= glyphsArrows.Y && e.Y <= glyphsArrows.Y + glyphsArrows.Height))
                {
                    // let base do stuff, mouse is not over glyphs buttons
                    base.OnMouseMove(e);
                }
            }
            else
            {
                // let base do stuff
                base.OnMouseMove(e);
            }

            // setup button
            if (this.TabControlStyle == TabControlStyleType.Buttons)
            {
                // BUTTON PREVIOUS
                // check to see if the mouse cursor position is within the bounds of our control
                if (IsMouseOverButtonPrevious(e))
                {
                    // mouse is over previous button, change button if not yet done (only if more than one tabs and not first tab)
                    if (!this.isButtonPreviousHover && !IsFirstTabSelected())
                    {
                        this.isButtonPreviousHover = true;
                        this.Invalidate();
                    }
                }
                else
                {
                    // mouse is not over previous button, change button if not yet done
                    if (this.isButtonPreviousHover)
                    {
                        this.isButtonPreviousHover = false;
                        this.Invalidate();
                    }
                }

                // BUTTON NEXT
                // check to see if the mouse cursor position is within the bounds of our control
                if (IsMouseOverButtonNext(e))
                {
                    // mouse is over next button, change button if not yet done (only if more than one tabs and not last tab)
                    if (!this.isButtonNextHover && !this.IsLastTabSelected())
                    {
                        this.isButtonNextHover = true;
                        this.Invalidate();
                    }
                }
                else
                {
                    // mouse is not over next button, change button if not yet done
                    if (this.isButtonNextHover)
                    {
                        this.isButtonNextHover = false;
                        this.Invalidate();
                    }
                }

                // BUTTON CLOSE
                // check to see if the mouse cursor position is within the bounds of our control
                if (IsMouseOverButtonClose(e))
                {
                    // mouse is over close button, change button if not yet done
                    if (!this.isButtonCloseHover)
                    {
                        this.isButtonCloseHover = true;
                        this.Invalidate();
                    }
                }
                else
                {
                    // mouse is not over close button, change button if not yet done
                    if (this.isButtonCloseHover)
                    {
                        this.isButtonCloseHover = false;
                        this.Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// The MouseUp event, used to prevent strange behaviour
        /// </summary>
        /// <param name="e">The event arguements</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            // do nothing due to strange behaviour if style is Buttons
            if (this.TabControlStyle == TabControlStyleType.Buttons)
            {
                // fire own event
                this.OnMouseUpButtonStyle(this, e);
            }
            else
            {
                // normal case
                base.OnMouseUp(e);
            }
        }

        /// <summary>
        /// The Paint event, used to draw a button to close the selected tab
        /// </summary>
        /// <param name="pe">The event arguments</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            try
            {
                // paint it
                base.OnPaint(pe);

                // draw button if Buttons style
                if (this.TabControlStyle == TabControlStyleType.Buttons)
                {
                    // get rectangle of control
                    Rectangle client = this.ClientRectangle;

                    // draw line to overpaint the default bright line between tabs and container
                    pe.Graphics.DrawLine(new Pen(this.BackColor), client.X, client.Y + 35, client.X + client.Width, client.Y + 35);

                    // get and fill rectangle of glyph arrows (catch mouseover event)
                    glyphsArrows = new Rectangle(client.X + client.Width - 54, client.Y + 11, 54, 16);
                    pe.Graphics.FillRectangle(new SolidBrush(this.BackColor), glyphsArrows.X, glyphsArrows.Y, glyphsArrows.Width - 4, glyphsArrows.Height);

                    // validate first
                    if (!IsTabSelected())
                    {
                        // do not paint buttons if no tab selected or available
                        return;
                    }

                    // get rectangles for the buttons
                    buttonClose = new Rectangle(client.X + client.Width - 20, client.Y + 11, 15, 15);
                    buttonNext = new Rectangle(buttonClose.Left - 19, client.Y + 11, 15, 15);
                    buttonPrevious = new Rectangle(buttonNext.Left - 15, client.Y + 11, 15, 15);

                    // create pen and colors
                    Color ColorHover = GuiConfig.Theme == GuiConfig.KissTheme.None ? Color.FromArgb(247, 239, 231) : GuiConfig.colBack04;
                    Pen pen = new Pen(Color.Black);
                    Color arrowPrevious = IsFirstTabSelected() ? this.BackColor : ColorHover;
                    Color arrowNext = IsLastTabSelected() ? this.BackColor : ColorHover;

                    // const for the "X" on the button
                    const int crossDeltaX = 4;

                    // const for the space for the arrow
                    const int arrowSpace = 4;

                    // draw button previous
                    pe.Graphics.FillRectangle(new SolidBrush(this.isButtonPreviousHover ? ColorHover : this.BackColor), buttonPrevious);
                    pe.Graphics.DrawRectangle(pen, buttonPrevious);
                    System.Drawing.Drawing2D.GraphicsPath previousPath = new System.Drawing.Drawing2D.GraphicsPath();
                    previousPath.AddPolygon(new Point[] { new Point(buttonPrevious.X + arrowSpace, buttonPrevious.Y + 7),
                                                          new Point(buttonPrevious.X + buttonPrevious.Width - arrowSpace, buttonPrevious.Y + arrowSpace),
                                                          new Point(buttonPrevious.X + buttonPrevious.Width - arrowSpace, buttonPrevious.Y + buttonPrevious.Height - arrowSpace),
                                                          new Point(buttonPrevious.X + arrowSpace, buttonPrevious.Y + 8)});
                    pe.Graphics.FillPath(new SolidBrush(this.isButtonPreviousHover ? Color.White : arrowPrevious), previousPath);
                    pe.Graphics.DrawPath(pen, previousPath);

                    // draw button next
                    pe.Graphics.FillRectangle(new SolidBrush(this.isButtonNextHover ? ColorHover : this.BackColor), buttonNext);
                    pe.Graphics.DrawRectangle(pen, buttonNext);
                    System.Drawing.Drawing2D.GraphicsPath nextPath = new System.Drawing.Drawing2D.GraphicsPath();
                    nextPath.AddPolygon(new Point[] { new Point(buttonNext.X + buttonNext.Width - arrowSpace, buttonPrevious.Y + 7),
                                                      new Point(buttonNext.X + arrowSpace, buttonNext.Y + arrowSpace),
                                                      new Point(buttonNext.X + arrowSpace, buttonNext.Y + buttonNext.Height - arrowSpace),
                                                      new Point(buttonNext.X + buttonNext.Width - arrowSpace, buttonPrevious.Y + 8)});
                    pe.Graphics.FillPath(new SolidBrush(this.isButtonNextHover ? Color.White : arrowNext), nextPath);
                    pe.Graphics.DrawPath(pen, nextPath);

                    // draw button close
                    pe.Graphics.FillRectangle(new SolidBrush(this.isButtonCloseHover ? ColorHover : this.BackColor), buttonClose);
                    pe.Graphics.DrawRectangle(pen, buttonClose);
                    pe.Graphics.DrawLine(pen, buttonClose.X + crossDeltaX, buttonClose.Y + crossDeltaX, buttonClose.X + buttonClose.Width - crossDeltaX, buttonClose.Y + buttonClose.Height - crossDeltaX);
                    pe.Graphics.DrawLine(pen, buttonClose.X + buttonClose.Width - crossDeltaX, buttonClose.Y + crossDeltaX, buttonClose.X + crossDeltaX, buttonClose.Y + buttonClose.Height - crossDeltaX);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                }
            }
        }

        /// <summary>
        /// The SelectedTabChanged event, used to redraw the button to close the selected tab
        /// </summary>
        /// <param name="page">The event arguements</param>
        protected override void OnSelectedTabChanged(TabPageEx page)
        {
            // let base do stuff
            base.OnSelectedTabChanged(page);

            // repaint button if necessary (if more tabs than we have space, the button will not be painted on tab changed)
            if (this.TabControlStyle == TabControlStyleType.Buttons)
            {
                this.Invalidate();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Return flag if active tpg can be closed depending on parent form locked state
        /// </summary>
        /// <returns><c>True</c> if tpg can be closed, otherwise <c>False</c></returns>
        private bool CanCloseActiveTpg()
        {
            // validate first if we have a parent control
            if (this.Parent != null)
            {
                // get parent form
                Form frm = this.Parent.FindForm();

                // check parent form
                if (frm != null && frm is KissForm)
                {
                    // closing is allowed if parent KissForm is not locked
                    return !((KissForm)frm).IsClosingLocked;
                }
            }

            // closing is allowed
            return true;
        }

        /// <summary>
        /// Check if control is type of CheckBox or KissCheckEdit
        /// </summary>
        /// <param name="ctl">The control to validate</param>
        /// <returns>True if control is a checkbox, false if not</returns>
        private bool IsControlCheckBox(Control ctl)
        {
            // check if control is CheckBox or KissCheckEdit
            return (typeof(CheckBox).IsAssignableFrom(ctl.GetType()) ||
                      typeof(KissCheckEdit).IsAssignableFrom(ctl.GetType()));
        }

        /// <summary>
        /// Check if first tab is selected
        /// </summary>
        /// <returns>True if first tab is selected</returns>
        private bool IsFirstTabSelected()
        {
            return this.TabPages != null && this.TabPages.Count > 0 && this.SelectedTabIndex == 0;
        }

        /// <summary>
        /// Check if last tab is selected
        /// </summary>
        /// <returns>True if last tab is selected</returns>
        private bool IsLastTabSelected()
        {
            return this.TabPages != null && this.TabPages.Count > 0 && this.TabPages.Count - 1 == this.SelectedTabIndex;
        }

        /// <summary>
        /// Check if mouse is over close button
        /// </summary>
        /// <param name="e">The mouse event arguments</param>
        /// <returns>True if over close button, else false</returns>
        private bool IsMouseOverButtonClose(MouseEventArgs e)
        {
            return e.X >= buttonClose.X && e.X <= buttonClose.X + buttonClose.Width && e.Y >= buttonClose.Y && e.Y <= buttonClose.Y + buttonClose.Height;
        }

        /// <summary>
        /// Check if mouse is over next button
        /// </summary>
        /// <param name="e">The mouse event arguments</param>
        /// <returns>True if over next button, else false</returns>
        private bool IsMouseOverButtonNext(MouseEventArgs e)
        {
            return e.X > buttonNext.X && e.X <= buttonNext.X + buttonNext.Width && e.Y >= buttonNext.Y && e.Y <= buttonNext.Y + buttonNext.Height;
        }

        /// <summary>
        /// Check if mouse is over previous button
        /// </summary>
        /// <param name="e">The mouse event arguments</param>
        /// <returns>True if over previous button, else false</returns>
        private bool IsMouseOverButtonPrevious(MouseEventArgs e)
        {
            return e.X >= buttonPrevious.X && e.X < buttonPrevious.X + buttonPrevious.Width && e.Y >= buttonPrevious.Y && e.Y <= buttonPrevious.Y + buttonPrevious.Height;
        }

        /// <summary>
        /// The event handling method <see cref="MouseUpButtonStyle"/>
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The mouse event arguments</param>
        private void OnMouseUpButtonStyle(object sender, MouseEventArgs e)
        {
            // check if any registered target has to be notified
            if (this.MouseUpButtonStyle != null)
            {
                // fire event
                this.MouseUpButtonStyle(sender, e);
            }
        }

        /// <summary>
        /// Update appearance of tabcontrol depending on style
        /// </summary>
        /// <param name="removeOtherStyleSettings">Remove some settings from other styles</param>
        private void SetAppearance(bool removeOtherStyleSettings)
        {
            // remove update event
            this.TabPages.CollectionChanged -= new EventHandler(TabPages_CollectionChanged);

            // setup style depending
            switch (this.TabControlStyle)
            {
                case TabControlStyleType.Standard:
                    // setup tabcontrol for default style
                    this.BorderStyleEx = SharpLibrary.WinControls.BorderStyleEx.FixedSingle;
                    this.FirstTabMargin = 0;
                    this.Font = new Font(GuiConfig.TabFontName, GuiConfig.TabFontSize, GuiConfig.TabFontStyle, GuiConfig.TabFontGraphicUnit);
                    this.TabsAreaBackColor = System.Drawing.Color.Empty;
                    this.TabsFitting = SharpLibrary.WinControls.TabsFitting.ShrinkTabs;
                    this.TabsLineColor = System.Drawing.Color.Black;
                    this.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;

                    // set some properties if user changed from other style to this
                    if (removeOtherStyleSettings)
                    {
                        this.BackColor = Color.Empty;
                        this.VerticalMargin = 4;
                        this.TabsImageList = null;
                        this.ShowSelectedTextBold = false;
                        this.ShowOnlySelectedTabText = false;
                        this.ImageList = null;
                        this.SelectedImageList = null;

                        // remove icons
                        UpdateSelectedUnselectedIconsOnTabs(false);

                        // remove spaces
                        this.UpdateTabsTitle(true);
                    }

                    // update painting
                    this.Invalidate();
                    break;

                case TabControlStyleType.Buttons:
                    // setup tabcontrol for button style
                    this.TabsImageList = this.imgListButtons;
                    this.TabsStyle = GuiConfig.Theme == GuiConfig.KissTheme.None ? TabsStyle.CustomImages : TabsStyle.Flat;
                    this.BackColor = GuiConfig.Theme == GuiConfig.KissTheme.None ? Color.FromArgb(230, 216, 174) : GuiConfig.PanelColor;
                    this.TabBaseColor = Color.Transparent;
                    this.TabsAreaBackColor = Color.Transparent;

                    // optional defaults
                    this.BorderStyleEx = SharpLibrary.WinControls.BorderStyleEx.FixedSingle;
                    this.Font = new Font(GuiConfig.TabFontName, GuiConfig.TabFontSize, GuiConfig.TabFontStyle, GuiConfig.TabFontGraphicUnit);
                    this.FirstTabMargin = 4;
                    this.VerticalMargin = 9;
                    this.ShowClose = false;
                    this.AlwaysUseFixedWidth = false;
                    this.FixedWidth = 500;  // smaller tabs will be resized, others not
                    this.TabsFitting = SharpLibrary.WinControls.TabsFitting.FixedWidth;
                    this.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
                    this.ShowSelectedTextBold = true;
                    this.ShowIcon = true;
                    this.ShowIconOnContainingData = false;
                    this.ShowOnlySelectedTabText = false;
                    this.ImageList = this.imgListSelectedUnselectedIcon;
                    this.SelectedImageList = this.imgListSelectedUnselectedIcon;

                    // load icons if neccessary
                    this.UpdateSelectedUnselectedIconList(false);

                    // update all tabs with new icons
                    this.UpdateSelectedUnselectedIconsOnTabs(false);

                    // remove spaces
                    this.UpdateTabsTitle(true);

                    // attach update event
                    this.TabPages.CollectionChanged += new EventHandler(TabPages_CollectionChanged);

                    // update painting
                    this.Invalidate();
                    break;

                case TabControlStyleType.ModulTree:
                    // setup tabcontrol for button style
                    this.TabsImageList = this.imgListModulTree;
                    this.TabsStyle = GuiConfig.Theme == GuiConfig.KissTheme.None ? TabsStyle.CustomImages : TabsStyle.Flat;
                    this.BackColor = GuiConfig.Theme == GuiConfig.KissTheme.None ? Color.FromArgb(247, 239, 231) : GuiConfig.PanelColor;
                    this.TabBaseColor = Color.Transparent;
                    this.TabsAreaBackColor = Color.Transparent;

                    // optional defaults
                    this.BorderStyleEx = SharpLibrary.WinControls.BorderStyleEx.FixedSingle;
                    this.Font = new Font(GuiConfig.TabFontName, GuiConfig.TabFontSize, GuiConfig.TabFontStyle, GuiConfig.TabFontGraphicUnit);
                    this.FirstTabMargin = 3;
                    this.VerticalMargin = 5;
                    this.TabsFitting = SharpLibrary.WinControls.TabsFitting.ShrinkTabs;
                    this.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
                    this.ShowSelectedTextBold = false;
                    this.ShowIcon = true;
                    this.ShowIconOnContainingData = false;
                    this.ShowOnlySelectedTabText = true;
                    this.SelectedImageList = null;

                    // update all tabs with new title
                    this.UpdateTabsTitle(false);

                    // attach update event
                    this.TabPages.CollectionChanged += new EventHandler(TabPages_CollectionChanged);

                    // update painting
                    this.Invalidate();
                    break;
            }
        }

        private bool ShouldSerializeFont()
        {
            return (tabControlStyle == TabControlStyleType.Custom);
        }

        private bool ShouldSerializeTabsAreaBackColor()
        {
            return (base.TabsAreaBackColor != System.Drawing.Color.Empty);
        }

        /// <summary>
        /// Update icons in imgListSelectedUnselectedIcon if neccessary
        /// </summary>
        /// <param name="forced">Icon list will be updated anyway</param>
        private void UpdateSelectedUnselectedIconList(bool forced)
        {
            // load icons if neccessary
            if (forced || this.imgListSelectedUnselectedIcon == null || this.imgListSelectedUnselectedIcon.Images.Count != 2)
            {
                // create new imagelist
                if (imgListSelectedUnselectedIcon == null)
                {
                    this.imgListSelectedUnselectedIcon = new SharpLibrary.WinControls.ImageListEx();
                }
                else
                {
                    this.imgListSelectedUnselectedIcon.Images.Clear();
                }

                // closed folder icon used for unselected tab
                imgListSelectedUnselectedIcon.Images.Add(KissImageList.GetSmallImage(this.IconIndexUnselectedTab));

                // open folder icon used for selected tab
                imgListSelectedUnselectedIcon.Images.Add(KissImageList.GetSmallImage(this.IconIndexSelectedTab));

                // invalidate tabs
                this.Invalidate();
            }
        }

        /// <summary>
        /// Setup icons on tabs if TabControlStyle is Buttons
        /// </summary>
        /// <param name="forcedRemove">Set if image indexes has to be removed</param>
        private void UpdateSelectedUnselectedIconsOnTabs(bool forcedRemove)
        {
            if (this.TabPages != null && (forcedRemove || this.TabControlStyle == TabControlStyleType.Buttons))
            {
                foreach (SharpLibrary.WinControls.TabPageEx tab in this.TabPages)
                {
                    if (forcedRemove)
                    {
                        // remove values
                        tab.ImageIndex = -1;
                        tab.SelectedImageIndex = -1;
                    }
                    else
                    {
                        // apply icons
                        tab.ImageIndex = 0;             // closed folder icon
                        tab.SelectedImageIndex = 1;     // open folder icon

                        // set backcolor
                        tab.BackColor = GuiConfig.Theme == GuiConfig.KissTheme.None ? Color.FromArgb(247, 239, 231) : GuiConfig.PanelColor;
                    }
                }
            }
        }

        /// <summary>
        /// Setup tab titles with empty spaces if TabControlStyle is ModulTree
        /// </summary>
        /// <param name="forcedRemove">Set if title spaces have to be removed</param>
        private void UpdateTabsTitle(bool forcedRemove)
        {
            if (this.TabPages != null && (forcedRemove || this.TabControlStyle == TabControlStyleType.ModulTree))
            {
                foreach (SharpLibrary.WinControls.TabPageEx tab in this.TabPages)
                {
                    if (forcedRemove)
                    {
                        // remove empty spaces
                        tab.Title = tab.Title.Trim();
                    }
                    else
                    {
                        // append empty spaces (do not loose current texts!!)
                        tab.Title = tab.Title.Trim();
                        tab.Title = string.Format("{0}    ", tab.Title);
                    }
                }
            }
        }

        #endregion

        #endregion
    }
}