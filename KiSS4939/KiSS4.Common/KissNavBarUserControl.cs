using System;
using System.Collections.Specialized;
using System.Data;

using DevExpress.XtraNavBar;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    public partial class KissNavBarUserControl : KissUserControl
    {
        protected KissNavBarUserControl()
        {
            InitializeComponent();

            // set imagelist
            navBar.SmallImages = KissImageList.SmallImageList;
        }

        public static IMessagePresenter MessagePresenter
        {
            get;
            set;
        }

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
                            navBar_LinkClicked(this, new NavBarLinkEventArgs(link));
                            return true;
                        }
                    }

                    return false;

                default:
                    return base.ReceiveMessage(parameters);
            }
        }

        protected virtual void OnLinkClicked(NavBarItemLink link)
        {
            // check if link has a type
            var kissNavBarItem = link.Item as KissNavBarItem;
            if (kissNavBarItem != null)
            {
                if ((kissNavBarItem).Type == null)
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
        /// <param name="link">The link to use for showing control</param>
        protected void ShowSubMask(NavBarItemLink link)
        {
            if (MessagePresenter != null)
            {
                MessagePresenter.ClearMessage();
            }

            // set kiss link
            var kissItem = link.Item as KissNavBarItem;

            // apply image and caption to title of new instance
            if (kissItem != null)
            {
                // set medium image as downscaling is better than upscaling of small icon
                picTitle.Image = kissItem.GetMediumImage();
            }
            else
            {
                // apply current (small) image
                picTitle.Image = link.GetImage();
            }

            // set title
            lblTitle.Text = link.Caption;

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

        private void ApplyDefaultStyle()
        {
            if (GuiConfig.Theme == GuiConfig.KissTheme.KissBlue)
            {
                navBar.Appearance.Background.BackColor = GuiConfig.NavBarBackground;
                navBar.Appearance.Background.BackColor2 = GuiConfig.NavBarBackground;

                navBar.Appearance.GroupHeader.BackColor = GuiConfig.NavBarGroupHeaderBackColor;
                navBar.Appearance.GroupHeader.BackColor2 = GuiConfig.NavBarGroupHeaderBackColor;
                navBar.Appearance.GroupHeaderHotTracked.Font = navBar.Appearance.GroupHeader.Font;

                navBar.Appearance.GroupBackground.BackColor = GuiConfig.NavBarGroupBackColor;
                navBar.Appearance.GroupBackground.BackColor2 = GuiConfig.NavBarGroupBackColor;
            }
        }

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
                    return AssemblyLoader.GetPropertyValue(this, navBarItemInstanceName) as NavBarItem;
                }

                //not found
                return null;
            }
            catch
            {
                return null;
            }
        }

        private void KissNavBarUserControl_Load(object sender, EventArgs e)
        {
            // check if not in design mode
            if (DesignMode)
            {
                return;
            }
            ApplyDefaultStyle();

            // load dynamic created items (if any)
            LoadDynamicNavBarItems();

            foreach (NavBarGroup item in navBar.Groups)
            {
                item.SmallImageIndex = KissImageList.GetImageIndex(item.SmallImageIndex);
                item.LargeImageIndex = KissImageList.GetImageIndex(item.LargeImageIndex);

                // do not allow dragNdrop of items within groups
                item.DragDropFlags = NavBarDragDrop.None;
            }

            foreach (NavBarItem item in navBar.Items)
            {
                item.SmallImageIndex = KissImageList.GetImageIndex(item.SmallImageIndex);
                item.LargeImageIndex = KissImageList.GetImageIndex(item.LargeImageIndex);
            }

            ApplicationFacade.DoEvents();

            // Show First Item (if any)
            if (navBar.Groups.Count > 0 && navBar.Groups[0].ItemLinks.Count > 0)
            {
                navBar_LinkClicked(this, new NavBarLinkEventArgs(navBar.Groups[0].ItemLinks[0]));
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
                string className;

                var navBarForm = Parent as IContainerForm; // für KiSS4
                if (navBarForm != null)
                {
                    className = navBarForm.GetType().Name;
                }
                else
                {
                    className = GetType().Name;
                }

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
                    navBar.Items.Clear();
                    navBar.Groups.Clear();

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
                                    NavBarItem item = FindNavBarItemInstance(controlName);

                                    if (item != null && DBUtil.UserHasRight(((KissNavBarItem)item).Type.Name)) // Double check for items without class name
                                    {
                                        // modify item
                                        item.Caption = rowItem["Text"] as string;
                                        item.SmallImageIndex = Convert.ToInt32(rowItem[DBO.XMenuItem.ImageIndex]);
                                        item.Enabled = Convert.ToBoolean(rowItem[DBO.XMenuItem.Enabled]);

                                        // add item to group
                                        navBar.Items.Add(item);
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
                                        navBar.Items.Add(item);
                                        group.ItemLinks.Add(item);
                                    }
                                }
                            } // [loop through items in group]

                            // check if any items in group
                            if (group.ItemLinks.Count > 0)
                            {
                                // add group to navbar
                                navBar.Groups.Add(group);
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

        private void navBar_LinkClicked(object sender, NavBarLinkEventArgs e)
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
    }
}