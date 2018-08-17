using System;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraNavBar;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    /// <summary>
    /// Summary description for KissNavBarForm.
    /// </summary>
    [Obsolete("This class is obsolete, please use KissNavBarUserControl instead.")]
    public class KissNavBarForm : KiSS4.Gui.KissChildForm, IContainerForm
    {
        #region Fields

        #region Protected Fields

        /// <summary>
        /// The title label
        /// </summary>
        protected System.Windows.Forms.Label lblTitle;

        /// <summary>
        /// The navigation bar
        /// </summary>
        protected DevExpress.XtraNavBar.NavBarControl navBar;

        /// <summary>
        /// The detail, control panel
        /// </summary>
        protected System.Windows.Forms.Panel panDetail;

        /// <summary>
        /// The title panel
        /// </summary>
        protected System.Windows.Forms.Panel panTitle;

        /// <summary>
        /// The title picture
        /// </summary>
        protected System.Windows.Forms.PictureBox picTitle;

        /// <summary>
        /// The splitter used for separating list and control
        /// </summary>
        protected KissSplitter splitterNavControl;

        #endregion

        #region Private Static Fields

        private static System.Text.RegularExpressions.Regex regExClassName = new System.Text.RegularExpressions.Regex(@".*\.");

        #endregion

        #region Private Fields

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, used to create new instance of form
        /// </summary>
        public KissNavBarForm()
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            // init belegleser
            new Belegleser(this);
            this.kissDataNavigator.PrefereDetailControl = true;

            // set imagelist
            this.navBar.SmallImages = KissImageList.SmallImageList;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.navBar = new DevExpress.XtraNavBar.NavBarControl();
            this.splitterNavControl = new KiSS4.Gui.KissSplitter();
            this.panDetail = new System.Windows.Forms.Panel();
            this.panTitle = new System.Windows.Forms.Panel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).BeginInit();
            this.panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.SuspendLayout();
            //
            // navBar
            //
            this.navBar.ActiveGroup = null;
            this.navBar.Appearance.Background.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.navBar.Appearance.Background.Options.UseBackColor = true;
            this.navBar.Appearance.GroupBackground.BackColor = System.Drawing.Color.Lavender;
            this.navBar.Appearance.GroupBackground.Options.UseBackColor = true;
            this.navBar.Appearance.GroupHeaderActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navBar.Appearance.GroupHeaderActive.Options.UseFont = true;
            this.navBar.Appearance.GroupHeaderActive.Options.UseTextOptions = true;
            this.navBar.Appearance.GroupHeaderActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.navBar.Appearance.GroupHeaderHotTracked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navBar.Appearance.GroupHeaderHotTracked.Options.UseFont = true;
            this.navBar.Appearance.GroupHeaderHotTracked.Options.UseTextOptions = true;
            this.navBar.Appearance.GroupHeaderHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.navBar.Appearance.GroupHeaderPressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navBar.Appearance.GroupHeaderPressed.Options.UseFont = true;
            this.navBar.Appearance.ItemDisabled.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Appearance.ItemHotTracked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
            this.navBar.Appearance.ItemHotTracked.Options.UseFont = true;
            this.navBar.Appearance.ItemHotTracked.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemHotTracked.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Appearance.ItemPressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
            this.navBar.Appearance.ItemPressed.Options.UseFont = true;
            this.navBar.Appearance.ItemPressed.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemPressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemPressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBar.Location = new System.Drawing.Point(0, 0);
            this.navBar.Name = "navBar";
            this.navBar.Size = new System.Drawing.Size(170, 522);
            this.navBar.TabIndex = 1;
            this.navBar.View = new DevExpress.XtraNavBar.ViewInfo.AdvExplorerBarViewInfoRegistrator();
            this.navBar.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBar_LinkClicked);
            //
            // splitterNavControl
            //
            this.splitterNavControl.Location = new System.Drawing.Point(170, 0);
            this.splitterNavControl.Name = "splitterNavControl";
            this.splitterNavControl.Size = new System.Drawing.Size(3, 522);
            this.splitterNavControl.TabIndex = 2;
            this.splitterNavControl.TabStop = false;
            //
            // panDetail
            //
            this.panDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetail.Location = new System.Drawing.Point(173, 29);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(627, 493);
            this.panDetail.TabIndex = 11;
            //
            // panelTitel
            //
            this.panTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTitle.Controls.Add(this.picTitle);
            this.panTitle.Controls.Add(this.lblTitle);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(173, 0);
            this.panTitle.Name = "panelTitel";
            this.panTitle.Size = new System.Drawing.Size(627, 29);
            this.panTitle.TabIndex = 10;
            //
            // picTitle
            //
            this.picTitle.Location = new System.Drawing.Point(10, 2);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(24, 24);
            this.picTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTitle.TabIndex = 0;
            this.picTitle.TabStop = false;
            //
            // lblTitle
            //
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(42, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(524, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Titel";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Visible = false;
            //
            // KissNavBarForm
            //
            this.ClientSize = new System.Drawing.Size(800, 522);
            this.Controls.Add(this.panDetail);
            this.Controls.Add(this.panTitle);
            this.Controls.Add(this.splitterNavControl);
            this.Controls.Add(this.navBar);
            this.Name = "KissNavBarForm";
            this.Text = "KissNavBarForm";
            this.Load += new System.EventHandler(this.KissNavBarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).EndInit();
            this.panTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.ResumeLayout(false);
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
            }
            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        private void KissNavBarForm_Load(object sender, System.EventArgs e)
        {
            // check if not in design mode
            if (DesignMode)
            {
                return;
            }

            // load dynamic created items (if any)
            this.LoadDynamicNavBarItems();

            foreach (NavBarGroup item in this.navBar.Groups)
            {
                item.SmallImageIndex = KissImageList.GetImageIndex(item.SmallImageIndex);
                item.LargeImageIndex = KissImageList.GetImageIndex(item.LargeImageIndex);

                // do not allow dragNdrop of items within groups
                item.DragDropFlags = NavBarDragDrop.None;
            }

            foreach (NavBarItem item in this.navBar.Items)
            {
                item.SmallImageIndex = KissImageList.GetImageIndex(item.SmallImageIndex);
                item.LargeImageIndex = KissImageList.GetImageIndex(item.LargeImageIndex);
            }

            ApplicationFacade.DoEvents();

            // Show First Item (if any)
            if (this.navBar.Groups.Count > 0 && this.navBar.Groups[0].ItemLinks.Count > 0)
            {
                navBar_LinkClicked(this, new DevExpress.XtraNavBar.NavBarLinkEventArgs(this.navBar.Groups[0].ItemLinks[0]));
            }
        }

        private void navBar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                OnLinkClicked(e.Link);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("KissNavBarForm", "ErrorLoadingLinkMask", "Fehler beim Laden der Maske", ex);
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (parameters["Action"] as string)
            {
                case "OpenLink":
                    if (!parameters.Contains("LinkName") || parameters["LinkName"] == null)
                        return false;

                    var linkName = parameters["LinkName"] as string;
                    foreach (NavBarItem item in navBar.Items)
                    {
                        if (item.Name.Equals(linkName))
                        {
                            var link = item.Links[0];
                            navBar.SelectedLink = link;
                            navBar_LinkClicked(this, new DevExpress.XtraNavBar.NavBarLinkEventArgs(link));
                            return true;
                        }
                    }

                    return false;

                default:
                    return base.ReceiveMessage(parameters);
            }
        }

        protected virtual void OnLinkClicked(DevExpress.XtraNavBar.NavBarItemLink link)
        {
            // check if link has a type
            if (link.Item is KissNavBarItem)
            {
                if (((KissNavBarItem)link.Item).Type == null)
                {
                    throw new KissErrorException("Type is empty, cannot create an instance without a given type. Please check if the dynamic created link has a valid class defined.");
                }
            }

            // check if enabled
            if (link.Enabled)
            {
                // show mask
                ShowSubMask(link);
            }
        }

        /// <summary>
        /// Show control of given NavBarItemLink
        /// </summary>
        /// <param name="Link">The link to use for showing control</param>
        protected void ShowSubMask(DevExpress.XtraNavBar.NavBarItemLink Link)
        {
            // set kiss link
            var kissItem = Link.Item as KissNavBarItem;

            // apply image and caption to title of new instance
            if (kissItem != null)
            {
                // set medium image as downscaling is better than upscaling of small icon
                picTitle.Image = kissItem.GetMediumImage();
            }
            else
            {
                // apply current (small) image
                picTitle.Image = Link.GetImage();
            }

            // set title
            lblTitle.Text = Link.Caption;

            // show controls
            picTitle.Visible = true;
            lblTitle.Visible = true;

            // check if any other link to load control
            if (kissItem != null)
            {
                // Create instance and try to show it.
                // KissUserControl newSubMask = kissItem.CreateInstance();
                IKissView newSubMask;

                // HACK: für WPF-Control
                // Damit hier ein WPF-Control geladen werden kann,
                // muss hier zwischen den alten KissUserControls und WPF-Controls unterschieden werden.
                // Wir benutzen hierzu den Klassennamen aus XClass (z.B. "Kiss.UI.View.Fs.FsDienstleistungen.xaml").
                if (kissItem.XClassID.HasValue) // TODO: etwas besser um Architektur alt-neu und neu zu unterscheiden
                {
                    newSubMask = new CtlWpfHost(kissItem.XClassID.Value);
                }
                else if (CtlWpfMask.IsWpfView(kissItem.Type))
                {
                    newSubMask = CtlWpfMask.CreateWpfView(kissItem.Type);
                }
                else
                {
                    newSubMask = kissItem.CreateInstance();
                }

                if (!ActivateUserControl(newSubMask, panDetail, true))
                {
                    picTitle.Visible = false;
                    lblTitle.Visible = false;
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get instance of NavBarItem depending on its property name
        /// </summary>
        /// <param name="navBarItemInstanceName">Name of NavBarItem to search</param>
        /// <returns>Instance if found, or null if not found or on exception</returns>
        private NavBarItem FindNavBarItemInstance(string navBarItemInstanceName)
        {
            try
            {
                if (!DBUtil.IsEmpty(navBarItemInstanceName))
                {
                    return (object)AssemblyLoader.GetPropertyValue(this, navBarItemInstanceName) as NavBarItem;
                }

                //not found
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Load dynamic created navbar-groups and items from table XMenuItem
        /// </summary>
        private void LoadDynamicNavBarItems()
        {
            try
            {
                // get typename
                string className = this.GetType().ToString();

                // get className from full type
                System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(@".*\.");
                className = regExClassName.Replace(className, "");

                // validate
                if (DBUtil.IsEmpty(className))
                {
                    // do nothing due to invalid classname
                    return;
                }

                // get dynamic created groups
                SqlQuery qryGroups = DBUtil.OpenSQL(@"
                    SELECT MNU.*,
                           Text = ISNULL(TXT.Text, MNU.Caption)
                    FROM dbo.XMenuItem MNU WITH (READUNCOMMITTED)
                      LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = MNU.MenuTID AND
                                                                            TXT.LanguageCode = {0}
                      LEFT JOIN dbo.XMenuItem PAR WITH (READUNCOMMITTED) ON PAR.MenuItemID = MNU.ParentMenuItemID
                    WHERE PAR.ClassName = {1} AND
                          MNU.Visible = 1
                    ORDER BY MNU.SortKey, MNU.MenuItemID", Session.User.LanguageCode, className);

                // check if we have any dynamic items for this classname
                if (qryGroups.Count > 0)
                {
                    // clear first --> in case of any dynamic item, all items have to be declared as dynamic (even the static ones)
                    this.navBar.Items.Clear();
                    this.navBar.Groups.Clear();

                    // loop through groups
                    foreach (DataRow rowGroup in qryGroups.DataTable.Rows)
                    {
                        // get navbar items of this group
                        SqlQuery qryItems = DBUtil.OpenSQL(@"
                            SELECT MNU.*,
                                   XClassID = CASE WHEN CLS.ClassNameViewModel IS NOT NULL THEN CLS.XClassID ELSE NULL END, -- TODO: etwas besser um Architektur alt-neu und neu zu unterscheiden
                                   Text = ISNULL(TXT.Text, MNU.Caption)
                            FROM dbo.XMenuItem MNU WITH (READUNCOMMITTED)
                              LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = MNU.MenuTID AND
                                                                                    TXT.LanguageCode={0}
                              LEFT JOIN dbo.XClass CLS WITH (READUNCOMMITTED) ON CLS.ClassName = MNU.ClassName
                            WHERE MNU.ParentMenuItemID = {1} AND
                                  MNU.Visible = 1
                                  AND dbo.fnUserHasRight({2}, MNU.ClassName) = 1
                            ORDER BY MNU.SortKey, MNU.MenuItemID",
                                             Session.User.LanguageCode,
                                             Convert.ToInt32(rowGroup[DBO.XMenuItem.MenuItemID]),
                                             Session.User.UserID);

                        // check if we have any items in group
                        if (qryItems.Count > 0)
                        {
                            // create new group
                            NavBarGroup group = new NavBarGroup(rowGroup["Text"] as string);
                            group.GroupCaptionUseImage = NavBarImage.Small;
                            group.GroupStyle = NavBarGroupStyle.SmallIconsText;
                            group.SmallImageIndex = (int)rowGroup[DBO.XMenuItem.ImageIndex];
                            group.Expanded = true;

                            // loop through items in group
                            foreach (DataRow rowItem in qryItems.DataTable.Rows)
                            {
                                // check if we have a controlname
                                string controlName = rowItem[DBO.XMenuItem.ControlName] as string;

                                if (!DBUtil.IsEmpty(controlName))
                                {
                                    // STATIC ITEM
                                    // get instance of menuitem
                                    NavBarItem item = this.FindNavBarItemInstance(controlName);

                                    if (item != null && DBUtil.UserHasRight(((KissNavBarItem)item).Type.Name)) // Double check for items without class name
                                    {
                                        // modify item
                                        item.Caption = rowItem["Text"] as string;
                                        item.SmallImageIndex = Convert.ToInt32(rowItem[DBO.XMenuItem.ImageIndex]);
                                        item.Enabled = Convert.ToBoolean(rowItem[DBO.XMenuItem.Enabled]);

                                        // add item to group
                                        this.navBar.Items.Add(item);
                                        group.ItemLinks.Add(item);
                                    }
                                }
                                else
                                {
                                    // DYNAMIC ITEM
                                    if (!DBUtil.IsEmpty(rowItem[DBO.XMenuItem.ClassName] as string) && DBUtil.UserHasRight(rowItem[DBO.XMenuItem.ClassName] as string))
                                    {
                                        // create new item
                                        KissNavBarItem item = new KissNavBarItem(rowItem["Text"] as string, (int)rowItem[DBO.XMenuItem.ImageIndex], rowItem[DBO.XMenuItem.ClassName] as string, new object[] { });
                                        item.Enabled = (bool)rowItem[DBO.XMenuItem.Enabled];
                                        item.Visible = (bool)rowItem[DBO.XMenuItem.Visible];
                                        item.XClassID = rowItem["XClassID"] as int?;
                                        // add item to group
                                        this.navBar.Items.Add(item);
                                        group.ItemLinks.Add(item);
                                    }
                                }
                            } // [loop through items in group]

                            // check if any items in group
                            if (group.ItemLinks.Count > 0)
                            {
                                // add group to navbar
                                this.navBar.Groups.Add(group);
                            }
                        } // [qryItems.Count > 0]
                    } // [loop through groups]
                } // [qryGroups.Count > 0]
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("KissNavBarForm", "ErrorLoadingDynamicNavBarItems_v01", "Es ist ein Fehler beim Laden der dynamisch generierten Navigationselemente aufgetreten.", ex);
            }
        }

        #endregion

        #endregion
    }
}