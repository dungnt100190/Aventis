using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using Kiss.BusinessLogic.Sys;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.UI;
using Kiss.UI.View;
using Kiss.UI.View.Ad;
using Kiss.UserInterface.ViewModel.Commanding;
using KiSS.Context;
using KiSS4.Administration;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Favoriten.Controller;
using KiSS4.Favoriten.Interface;
using KiSS4.Favoriten.Model;
using KiSS4.Favoriten.UI;
using KiSS4.Gui;
using KiSS4.Gui.Layout;
using KiSS4.Main.Helper;
using KiSS4.Query;
using log4net;
using SharpLibrary.WinControls;
using Application = System.Windows.Forms.Application;
using ApplicationCommands = System.Windows.Input.ApplicationCommands;
using Cursors = System.Windows.Forms.Cursors;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

namespace KiSS4.Main
{
    /// <summary>
    /// Main application form.
    /// </summary>
    public partial class FrmMain : KissMainForm
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Arguments _commandLineArgs;
        private readonly Dictionary<Type, Action<Control, FavoriteControl>> _controlTypeActionForRestore;
        private readonly Dictionary<Type, Action<Control, Favorite>> _controlTypeActionForSave;
        private readonly object _lockLoadMenuItems = ""; // lock variable due to thread-safety call

        private BarItem _dynamicFavorite;
        private Favorite _lastSelectedFavorite;
        private KissControlLayout _startupLayout;
        private HybridDictionary _toolbarBarItems; // used to store barItems that are needed to show in toolbar
        private HybridDictionary _toolbarBarItemsIsNewGroup;

        /// <summary>
        /// Constructor for main
        /// </summary>
        /// <param name="args">Command line arguments</param>
        public FrmMain(Arguments args)
        {
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = Thread.CurrentThread.CurrentUICulture;
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = Thread.CurrentThread.CurrentUICulture;

            // Enable visual styles for Windows Forms Controls
            Application.EnableVisualStyles();

            // Required for Windows Form Designer support
            InitializeComponent();

            barManager.Images = KissImageList.SmallImageList;
            _commandLineArgs = args;

            _controlTypeActionForSave = new Dictionary<Type, Action<Control, Favorite>>();
            _controlTypeActionForRestore = new Dictionary<Type, Action<Control, FavoriteControl>>();

            // Create a WPF application
            // Set ShutDownMode due to a that closes the whole application if left on Default Value
            // http://codeka.com/blogs/index.php/2009/12/20/the-application-object-is-being-shut-down
            new App { ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown };

            // Register the window in the IoC container
            Kiss.Infrastructure.IoC.Container.RegisterInstance<IWin32Window>(this);
        }

        ///// <summary>
        ///// Default constructor with no parameters (used for NUnit-Tests)
        ///// </summary>
        //public FrmMain()
        //    : this(new Arguments())
        //{
        //    // just for nunit-tests
        //}

        /// <summary>
        /// Default constructor with no parameters (used for initialization from KiSS5)
        /// </summary>
        public FrmMain()
        {
            _controlTypeActionForSave = new Dictionary<Type, Action<Control, Favorite>>();
            _controlTypeActionForRestore = new Dictionary<Type, Action<Control, FavoriteControl>>();
        }

        [Obsolete("Use FormController instead")]
        public override void ContextPrint(IKissContext cp, string queryName)
        {
            DlgReportMenu dlg = new DlgReportMenu(cp);
            dlg.ShowDialog(this);
        }

        /// <summary>
        /// Get imagelist containing database icons
        /// </summary>
        /// <returns></returns>
        public ImageList GetDBImageList()
        {
            return imgUmgebung;
        }

        /// <summary>
        /// Check if className is type of FrmDataExplorer (inherited)
        /// </summary>
        /// <param name="className">The name of the class to check</param>
        /// <returns>True if baseclass or inherited from FrmDataExplorer, otherwise false</returns>
        public override bool IsClassTypeOfFrmDataExplorer(string className)
        {
            // validate first
            if (DBUtil.IsEmpty(className))
            {
                return false;
            }

            try
            {
                // check if classname is baseclass or inherited from FrmDataExplorer
                return typeof(FrmDataExplorer).IsAssignableFrom(AssemblyLoader.GetType(className));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check if className implements IContainerForm
        /// </summary>
        /// <param name="className">The name of the class to check</param>
        /// <returns>True if class implements IContainerForm, otherwise false</returns>
        public override bool IsClassTypeOfIContainerForm(string className)
        {
            // validate first
            if (DBUtil.IsEmpty(className))
            {
                return false;
            }

            try
            {
                // check if classname is baseclass or inherited from KissNavBarForm
                return typeof(IContainerForm).IsAssignableFrom(AssemblyLoader.GetType(className));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check if className is type of NavBarForm (inherited)
        /// </summary>
        /// <param name="className">The name of the class to check</param>
        /// <returns>True if baseclass or inherited from NavBarForm, otherwise false</returns>
        public override bool IsClassTypeOfNavBarForm(string className)
        {
            // validate first
            if (DBUtil.IsEmpty(className))
            {
                return false;
            }

            try
            {
                // check if classname is baseclass or inherited from KissNavBarForm
                return typeof(KissNavBarForm).IsAssignableFrom(AssemblyLoader.GetType(className));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Load and apply dynamic menu items from database (Anwendung, Stammdaten, System)
        /// Use this method to refresh dynamic menus on runtime
        /// </summary>
        public override void LoadMenuItems()
        {
            lock (_lockLoadMenuItems)
            {
                try
                {
                    // stop repainting (prevent "object reference not set" error
                    // at DevExpress.XtraBars.BarItemLink.get_Enabled() on mouse move while loading
                    barDockControlBottom.Enabled = false;
                    barDockControlBottom.BeginUpdate();

                    // due to SqlQuery, we can only load menus if we have an active session
                    if (Session.Active)
                    {
                        // clear dictionaries
                        _toolbarBarItems = new HybridDictionary();
                        _toolbarBarItemsIsNewGroup = new HybridDictionary();

                        // MENU
                        LoadTopLevelMenuItems(barMainMenu);

                        // update subSpracheWechseln
                        subSpracheWechseln.ClearLinks();
                        subSpracheWechseln.ItemLinks.Add(listSprachen);
                        SetSprachen();
                        subSpracheWechseln.Enabled = true;

                        // update subFenster (append window-list again)
                        subFenster.ItemLinks.Add(itmMdiChildrenList, true);

                        // TOOLBAR
                        // reload toolbar items
                        LoadDynamicToolbar(barApplikation);
                    }
                    else
                    {
                        // disable or hide toolbar
                        if (barApplikation.ItemLinks.Count > 0)
                        {
                            DisableToolbar(barApplikation);
                        }
                        else
                        {
                            barApplikation.Visible = false;
                        }

                        // disable root menus and dynamic created subItems
                        DisableTopLevelMenuItems(barMainMenu);
                    }
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError(typeof(FrmMain).Name, "ErrorLoadingDynamicMenuItems", "Fehler beim Laden der dynamischen Menus und Toolbars", ex);
                }
                finally
                {
                    // update again
                    barDockControlBottom.EndUpdate();
                    barDockControlBottom.Enabled = true;
                }
            }
        }

        public override void SaveLayout()
        {
            // do nothing; the layout only is saved in SaveStartupLayout()
        }

        [Obsolete("Use FormController instead")]
        public override bool ShowItem(ModulID modul, string context, int key)
        {
            KissModulTree modulTree = null;
            DevExpress.XtraTreeList.Nodes.TreeListNode node = null;
            try
            {
                if (context == "FAL")
                {
                    int baPersonID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                            SELECT BaPersonID
                            FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                            WHERE FaLeistungID = {0}", key));

                    if (modul == ModulID.None)
                    {
                        modul = (ModulID)DBUtil.ExecuteScalarSQL(@"
                                SELECT ModulID
                                FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                WHERE FaLeistungID = {0}", key);
                    }

                    if (!ShowFall(baPersonID, modul))
                    {
                        return base.ShowItem(modul, context, key);
                    }

                    modulTree = (KissModulTree)GetTreeFall();
                }

                switch (modul)
                {
                    case ModulID.F:
                        return true;

                    case ModulID.S:
                        if (context == "FAL" && modulTree != null)
                        {
                            node = DBUtil.FindNodeByValue(modulTree.KissTree.Nodes, "FAL" + key, "ID");
                        }
                        else if (context == "SFP")
                        {
                            int fal = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                                    SELECT FaLeistungID
                                    FROM dbo.BgFinanzplan WITH (READUNCOMMITTED)
                                    WHERE BgFinanzplanID = {0}", key));

                            if (ShowItem(modul, "FAL", fal))
                            {
                                modulTree = (KissModulTree)GetTreeFall();
                                node = DBUtil.FindNodeByValue(modulTree.KissTree.Nodes, "SFP" + key, "ID");
                            }
                        }
                        else if (context == "BBG")
                        {
                            int sfp = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                                    SELECT BgFinanzplanID
                                    FROM dbo.BgBudget WITH (READUNCOMMITTED)
                                    WHERE BgBudgetID = {0}", key));

                            if (ShowItem(modul, "SFP", sfp))
                            {
                                modulTree = (KissModulTree)GetTreeFall();
                                node = DBUtil.FindNodeByValue(modulTree.KissTree.Nodes, modulTree.FocusedNode.GetValue("ID") + "\\BBG" + key, "ID");
                            }
                        }
                        else if (context == "BPO")
                        {
                            int bbg = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                                    SELECT BgBudgetID
                                    FROM dbo.BgPosition WITH (READUNCOMMITTED)
                                    WHERE BgPositionID = {0}", key));

                            if (ShowItem(modul, "BBG", bbg))
                            {
                                modulTree = (KissModulTree)GetTreeFall();
                                AssemblyLoader.InvokeMethode(modulTree.DetailControl, "ShowPosition", key);
                                return true;
                            }
                        }
                        else if (context == "SEZ")
                        {
                            int bbg = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                                    SELECT BgBudgetID
                                    FROM dbo.BgPosition WITH (READUNCOMMITTED)
                                    WHERE BgPositionID = {0}", key));

                            if (ShowItem(modul, "BBG", bbg))
                            {
                                modulTree = (KissModulTree)GetTreeFall();
                                AssemblyLoader.InvokeMethode(modulTree.DetailControl, "ShowEinzelzahlung", key);
                                return true;
                            }
                        }
                        break;

                    case ModulID.A:
                        if (context == "FAL" && modulTree != null)
                        {
                            node = DBUtil.FindNodeByValue(modulTree.KissTree.Nodes, "FAL" + key, "ID");
                        }
                        else if (context == "AFP")
                        {
                            int fal = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                                    SELECT FaLeistungID
                                    FROM dbo.BgFinanzplan WITH (READUNCOMMITTED)
                                    WHERE BgFinanzplanID = {0}", key));

                            if (ShowItem(modul, "FAL", fal))
                            {
                                modulTree = (KissModulTree)GetTreeFall();
                                node = DBUtil.FindNodeByValue(modulTree.KissTree.Nodes, "SFP" + key, "ID");
                            }
                        }
                        else if (context == "BBG")
                        {
                            int sfp = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                                    SELECT BgFinanzplanID
                                    FROM dbo.BgBudget WITH (READUNCOMMITTED)
                                    WHERE BgBudgetID = {0}", key));

                            if (ShowItem(modul, "AFP", sfp))
                            {
                                modulTree = (KissModulTree)GetTreeFall();
                                node = DBUtil.FindNodeByValue(modulTree.KissTree.Nodes, modulTree.FocusedNode.GetValue("ID") + "\\BBG" + key, "ID");
                            }
                        }
                        else if (context == "BPO")
                        {
                            int bbg = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                                    SELECT BgBudgetID
                                    FROM dbo.BgPosition WITH (READUNCOMMITTED)
                                    WHERE BgPositionID = {0}", key));

                            if (ShowItem(modul, "BBG", bbg))
                            {
                                modulTree = (KissModulTree)GetTreeFall();
                                AssemblyLoader.InvokeMethode(modulTree.DetailControl, "ShowPosition", key);
                                return true;
                            }
                        }
                        else if (context == "AEZ")
                        {
                            int bbg = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                                    SELECT BgBudgetID
                                    FROM dbo.BgPosition WITH (READUNCOMMITTED)
                                    WHERE BgPositionID = {0}", key));

                            if (ShowItem(modul, "BBG", bbg))
                            {
                                modulTree = (KissModulTree)GetTreeFall();
                                AssemblyLoader.InvokeMethode(modulTree.DetailControl, "ShowEinzelzahlung", key);
                                return true;
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                _log.Debug(ex);
            }

            if (node != null)
            {
                modulTree.FocusedNode = node;
                return true;
            }

            return base.ShowItem(modul, context, key);
        }

        /// <summary>
        /// Open startup forms if session is active and there's a startup layout
        /// </summary>
        internal void OpenStartupLayoutForms()
        {
            if (_startupLayout == null)
                return;
            if (!Session.Active)
                return;
            if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                return;

            // set child form layouts
            foreach (KissControlLayout cl in _startupLayout.ControlLayouts)
            {
                Type type = AssemblyLoader.GetType(cl.Name, null);
                if (type != null && typeof(KissChildForm).IsAssignableFrom(type))
                {
                    try
                    {
                        KissChildForm frm = OpenChildForm(type);

                        LayoutErrorCollection errors;
                        frm.SetLayout(cl, out errors);
                    }
                    catch (Exception ex)
                    {
                        _log.Debug(ex);
                    }
                }
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    // Close the session if necessary
                    Abmelden();
                }
                catch (Exception ex)
                {
                    // Eintrag ins Log.
                    _log.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                    // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                    XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);
                }

                if (components != null)
                {
                    components.Dispose();
                }
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        protected override void OnGettingLayout(KissLayoutEventArgs e)
        {
            base.OnGettingLayout(e);

            // get child form and add to ContorlLayouts collection
            foreach (Form frm in MdiChildren)
            {
                var childForm = frm as KissChildForm;

                if (childForm != null && childForm.Visible)
                {
                    if (!childForm.RestoreOnLogin)
                    {
                        continue;
                    }

                    LayoutErrorCollection errors;
                    KissControlLayout cl = childForm.GetLayout(out errors);
                    e.Layout.ControlLayouts.Add(cl);

                    foreach (LayoutError error in errors)
                    {
                        e.Errors.Add(error);
                    }
                }
            }

            _startupLayout = e.Layout;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (GuiConfig.Theme != GuiConfig.KissTheme.None)
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.UseDefaultLookAndFeel = false;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.UseWindowsXPTheme = false;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = LookAndFeelStyle.Flat;

                barControler.Controller.AppearancesBar.Bar.BackColor = GuiConfig.colBack03;
                barControler.Controller.AppearancesBar.Dock.BackColor = GuiConfig.colBack03;
                barControler.Controller.AppearancesBar.MainMenu.BackColor = GuiConfig.colBack03;
                barControler.Controller.AppearancesBar.StatusBar.BackColor = GuiConfig.colBack03;
                barControler.Controller.AppearancesBar.SubMenu.Menu.BackColor = GuiConfig.colBack03;
                barControler.Controller.AppearancesBar.SubMenu.SideStrip.BackColor = GuiConfig.colBack02;
                barControler.Controller.AppearancesBar.SubMenu.SideStripNonRecent.BackColor = GuiConfig.colBack02;
                BackColor = GuiConfig.colBack03;
            }

            // HACK: rerestore layout as it will be lost somewhere
            RestoreLayout();
            SetbarMainMenuBackColor();
            Session.MainForm = this;

            SetText();
            UpdateMenus();

            TranslateMenuItems();

            base.OnLoad(e); // sets window's location and size

            foreach (Control ctl in Controls)
            {
                if (ctl is MdiClient)
                {
                    if (GuiConfig.Theme == GuiConfig.KissTheme.None)
                    {
                        ctl.BackColor = Color.Teal;
                    }
                    else
                    {
                        ctl.BackColor = GuiConfig.colBack04;
                    }
                    //var r = new Random();
                    //ctl.BackColor = Color.FromArgb(255, r.Next(0, 32), r.Next(112, 144), r.Next(112, 144));
                }
            }

            if ((ModifierKeys & Keys.Shift) != Keys.Shift) // try auto login with last user (only if not SHIFT is pressed)
            {
                Env env = Session.GetEnvironment(_commandLineArgs["Environment"] as string);

                if (env == null)
                {
                    env = Session.LastEnv;
                }
                else
                {
                    Session.UserAppDataRegistry.SetValue("LastEnvironment", env.Name);
                }

                if (env != null)
                {
                    // autologin if OS-username is equal to last used login within KiSS
                    if (Environment.UserName.Equals(Session.LastLogon, StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            // do single-sign-on
                            Session.Open(env, Environment.UserName, null, true);
                            AppContext.Init(Session.ConnectionString);
                            Utils.WarningIfIBANExpired(Session.Active);
                        }
                        catch (Exception ex)
                        {
                            _log.Debug(ex);
                        }
                    }
                }
            }

            // show login dialog
            Anmelden(Session.Active);

            Program.ProcessCommandLine(_commandLineArgs);

            // Init for Favoriten
            RegisterControlTypeActionsForSave();
            RegisterControlTypeActionsForRestore();

            // XConfig laden
            PreLoadConfigCache();
        }

        protected override void OnSettingLayout(KissLayoutEventArgs e)
        {
            base.OnSettingLayout(e); // set window's location and size

            // maximize if it is not in view
            if (WindowState != FormWindowState.Maximized &&
                 (Left >= Screen.PrimaryScreen.WorkingArea.Right ||
                 Right <= Screen.PrimaryScreen.WorkingArea.Left ||
                 Top >= Screen.PrimaryScreen.WorkingArea.Bottom ||
                 Bottom <= Screen.PrimaryScreen.WorkingArea.Top))
                WindowState = FormWindowState.Maximized;

            _startupLayout = e.Layout;
            OpenStartupLayoutForms();
        }

        private bool Abmelden()
        {
            if (!SavePersistentObjects(false))
                return false;

            //try to close all child windows
            CloseAllForms();

            // confirm leaving if any open form on active session exists
            if (MdiChildren.Length > 0 && Session.Active)
            {
                if (!KissMsg.ShowQuestion(
                    typeof(FrmMain).Name,
                    "ConfirmLeavingOnOpenForms_v02",
                    "Mindestens ein Fenster konnte nicht automatisch geschlossen werden.\r\nWollen Sie trotzdem abmelden?\r\n\r\n(nicht gespeicherte Daten gehen verloren, Neuanmeldung wird verhindert)",
                    false))
                {
                    // cancel closing on open forms if user clicks <no>
                    return false;
                }
            }

            Session.Close();
            AssemblyLoader.Clear();
            AppContext.CloseConnection();

            UpdateMenus();
            edtUmgebung.EditValue = null;
            repositoryItemPickImage1.Items.Clear();
            SetText();

            return true;
        }

        private FavoriteControl AddFavorite(Control control)
        {
            FavoriteControl favoriteControl = new FavoriteControl();
            favoriteControl.Name = control.Name;
            favoriteControl.Type = control.GetType().Name;

            return favoriteControl;
        }

        /// <summary>
        /// Helper method to add items to toolbar-arrays
        /// </summary>
        /// <param name="showInToolbar">True if item has to be in toolbar</param>
        /// <param name="toolbarSortKey">Sortkey for toolbar items (unique)</param>
        /// <param name="beginToolbarGroup">True if item has to start a new group</param>
        /// <param name="barItem">The item</param>
        private void AddItemToToolbarDictionaries(bool showInToolbar, object toolbarSortKey, bool beginToolbarGroup, BarItem barItem)
        {
            if (showInToolbar && !DBUtil.IsEmpty(toolbarSortKey) && barItem != null)
            {
                // add to dictionaries
                _toolbarBarItems.Add(Convert.ToInt32(toolbarSortKey), barItem);
                _toolbarBarItemsIsNewGroup.Add((int)toolbarSortKey, beginToolbarGroup);
            }
        }

        private void Anmelden(bool autoLogin)
        {
            Cursor = Cursors.WaitCursor;
            bool hasSessionAfterCanceledAbmelden = false;

            try
            {
                if (autoLogin)
                {
                    return;
                }

                var firstLogin = !Session.Active;

                if (!Abmelden())
                {
                    hasSessionAfterCanceledAbmelden = Session.Active;
                    return;
                }

                var frmLogin = new FrmLogin();

                if (firstLogin)
                {
                    frmLogin.FirstLogin = true;
                }

                frmLogin.ShowDialog(this);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(typeof(FrmMain).Name, "AnmeldenFehlgeschlagen", "Anmelden fehlgeschlagen.", ex);
            }
            finally
            {
                // if user canceled Abmelden() on open session, we just leave it the way it was
                if (!hasSessionAfterCanceledAbmelden)
                {
                    try
                    {
                        if (Session.Active)
                        {
                            // hide toolbar
                            barApplikation.Visible = false;

                            barManager.Images = null;
                            KissImageList.LoadImages();
                            barManager.Images = KissImageList.SmallImageList;
                            UpdateDBImageList();

                            // ENVIRONMENT
                            edtUmgebung.EditValue = null;
                            repositoryItemPickImage1.Items.Clear();

                            foreach (Env env1 in Session.Envs)
                            {
                                repositoryItemPickImage1.Items.Add(new ImageComboBoxItem(env1.Name, env1, (int)env1.EnvType));
                            }
                        }

                        // setup menus and toolbars
                        UpdateMenus();

                        edtUmgebung.EditValue = Session.Env;
                        SetText();

                        barSearchEditItem.Enabled = DBUtil.UserHasRight(typeof(KissSearchDialog).Name);
                        barSearch.Visible = DBUtil.UserHasRight(typeof(KissSearchDialog).Name);

                        // use our own GridLocalizer and EditorLocalizer due to multilanguage!
                        GridLocalizer.Active = new MyGridLocalizer();
                        Localizer.Active = new MyEditorLocalizer();

                        OpenStartupLayoutForms();
                    }
                    catch (Exception ex)
                    {
                        KissMsg.ShowError(typeof(FrmMain).Name, "FehlerBeiAnmelden", "Beim Anmelden ist ein Fehler aufgetreten.", ex);
                    }
                    finally
                    {
                        if (Session.Active)
                        {
                            // show toolbar
                            barApplikation.Visible = true;
                        }

                        // reset cursor
                        Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void barItemSearchTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var dlg = new KissSearchDialog(this);
                dlg.SearchKissData(((TextEdit)sender).Text);
            }
        }

        private void barItemSearchTextEdit_Leave(object sender, EventArgs e)
        {
            barSearchEditItem.EditValue = null;
        }

        private void barSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            var activeMdiChild = ActiveMdiChild as IKissDataNavigator;
            if (activeMdiChild != null)
            {
                (activeMdiChild).SaveData();
            }
            KissCommands.SaveItem.Execute(null, null);
        }

        private void btnAbmelden_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                Abmelden();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(typeof(FrmMain).Name, "AbmeldenFehlgeschlagen", DB.Properties.Resources.FrmMain_AbmeldenFehlgeschlagen, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            // create new dialog
            DlgAbout dlgAbout = new DlgAbout();

            // show it modal
            dlgAbout.ShowDialog(this);
        }

        private void btnAnmelden_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                Anmelden(false);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(typeof(FrmMain).Name, "AnmeldenFehlgeschlagen", DB.Properties.Resources.FrmMain_AnmeldenFehlgeschlagen, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnBeenden_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                Abmelden();
                Close();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(typeof(FrmMain).Name, "FehlerApplikationSchliessen", DB.Properties.Resources.FrmMain_FehlerApplikationSchliessen, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnBenutzerverwaltung_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormController.OpenForm(typeof(FrmUserManagement).Name);
        }

        private void btnBusinessDesigner_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenChildForm(typeof(DesignerHost.FrmDesigner));
        }

        private void btnCloseAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllForms();
        }

        private void btnCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            // WinForms
            SendKeys.Send("^C");
            // WPF
            ApplicationCommands.Copy.Execute(null, null);
        }

        private void btnCut_ItemClick(object sender, ItemClickEventArgs e)
        {
            // WinForms
            SendKeys.Send("^X");
            // WPF
            ApplicationCommands.Cut.Execute(null, null);
        }

        private void btnDataEditor_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenChildForm(AssemblyLoader.GetType(typeof(FrmDataEditor)));
        }

        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            var activeMdiChild = ActiveMdiChild as IKissDataNavigator;
            if (activeMdiChild != null)
            {
                (activeMdiChild).DeleteData();
            }
            KissCommands.DeleteItem.Execute(null, null);
        }

        private void btnFallNavigator_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormController.OpenForm(typeof(FrmFallNavigator).Name);
        }

        private void btnFavoritenVerwaltung_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFavoriteVerwaltung(null);
        }

        private void btnFavoriteSpeichern_ItemClick(object sender, ItemClickEventArgs e)
        {
            Control controlToSearch = FindKissSearchControl(GetFocusControl());

            if (controlToSearch != null)
            {
                // Uses the currently selected favorite, if available.
                Favorite favorite = null;

                if (_lastSelectedFavorite != null)
                {
                    // Copying existing object's values.
                    favorite = new Favorite(_lastSelectedFavorite);
                }

                favorite = SaveFavorite(controlToSearch, favorite, false);

                if (_lastSelectedFavorite != null)
                {
                    FavoriteController controller = new FavoriteController();
                    IResult result = controller.SaveExistingFavorite(favorite);

                    if (result.WasOperationSuccessful)
                    {
                        KissMsg.ShowInfo(typeof(FrmMain).Name, "SaveFavoriteSuccessfull", "Favorit '{0}' wurde gespeichert.", _lastSelectedFavorite.Name);
                    }
                    else
                    {
                        KissMsg.ShowError(typeof(FrmMain).Name, "SaveFavoriteFailed", "Favorit '{0}' wurde nicht gespeichert.", result.ErrorMessage, null, _lastSelectedFavorite.Name);
                    }
                }
                else
                {
                    // validate
                    if (favorite == null)
                    {
                        // favorite is invalid, no favorite can be saved for this control/form
                        KissMsg.ShowInfo(typeof(FrmMain).Name, "CannotSaveFavoriteInvalidClass", "Für die aktive Maske können zurzeit keine Favoriten gespeichert werden.");
                        return;
                    }

                    // let the user save the new favorite
                    OpenFavoriteVerwaltung(favorite);
                }
            }
        }

        private void btnFavoriteSpeichernUnter_ItemClick(object sender, ItemClickEventArgs e)
        {
            Control controlToSearch = FindKissSearchControl(GetFocusControl());

            if (controlToSearch != null)
            {
                Favorite favorite = SaveFavorite(controlToSearch, null, true);

                if (favorite != null)
                {
                    OpenFavoriteVerwaltung(favorite);
                }
            }
        }

        private void btnFensterEinstLoeschen_ItemClick(object sender, ItemClickEventArgs e)
        {
            // cloase all forms first to prevent saving layout after cleanup
            CloseAllForms();

            if (MdiChildren.Length > 0)
            {
                return;
            }

            // clear all layout entries from registry
            base.DeleteLayoutRegistry();
        }

        private void btnFinde_ItemClick(object sender, ItemClickEventArgs e)
        {
            var activeMdiChild = ActiveMdiChild as IKissDataNavigator;
            if (activeMdiChild != null)
            {
                activeMdiChild.Search();
            }
            KissCommands.Search.Execute(null, null);
        }

        private void btnFirst_ItemClick(object sender, ItemClickEventArgs e)
        {
            var activeMdiChild = ActiveMdiChild as IKissDataNavigator;
            if (activeMdiChild != null)
            {
                activeMdiChild.MoveFirst();
            }
            KissCommands.GoToFirstItem.Execute(null, null);
        }

        private void btnIndex_ItemClick(object sender, ItemClickEventArgs e)
        {
            // REMEMBER: Use Session.GetCultureText() to get multilanguage texts
        }

        private void btnInhalt_ItemClick(object sender, ItemClickEventArgs e)
        {
            // REMEMBER: Use Session.GetCultureText() to get multilanguage texts
        }

        private void btnKonfiguration_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenChildForm(AssemblyLoader.GetType(typeof(FrmConfig)));
        }

        private void btnLast_ItemClick(object sender, ItemClickEventArgs e)
        {
            var activeMdiChild = ActiveMdiChild as IKissDataNavigator;
            if (activeMdiChild != null)
            {
                (activeMdiChild).MoveLast();
            }
            KissCommands.GoToLastItem.Execute(null, null);
        }

        private void btnModulKonfiguration_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenChildForm(AssemblyLoader.GetType(typeof(CtlModulConfig)));
        }

        private void btnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            var activeMdiChild = ActiveMdiChild as IKissDataNavigator;
            if (activeMdiChild != null)
            {
                (activeMdiChild).AddData();
            }
            KissCommands.CreateNewItem.Execute(null, null);
        }

        private void btnNext_ItemClick(object sender, ItemClickEventArgs e)
        {
            var activeMdiChild = ActiveMdiChild as IKissDataNavigator;
            if (activeMdiChild != null)
            {
                (activeMdiChild).MoveNext();
            }
            KissCommands.GoToNextItem.Execute(null, null);
        }

        private void btnPasswortAendern_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewHelper.OpenModalWpfDialog(new AdPasswortAendernView(), e.Item.Caption, null, this);
        }

        private void btnPaste_ItemClick(object sender, ItemClickEventArgs e)
        {
            // WinForms
            SendKeys.Send("^V");
            // WPF
            ApplicationCommands.Paste.Execute(null, null);
        }

        private void btnPrevious_ItemClick(object sender, ItemClickEventArgs e)
        {
            var activeMdiChild = ActiveMdiChild as IKissDataNavigator;
            if (activeMdiChild != null)
            {
                (activeMdiChild).MovePrevious();
            }
            KissCommands.GoToPreviousItem.Execute(null, null);
        }

        private void btnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActiveMdiChild is IKissContext)
            {
                ((IKissContext)ActiveMdiChild).PrintReport();
                return;
            }

            FormController.ShowDialogOnMain(typeof(DlgReportMenu).Name, this);
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActiveMdiChild is IKissDataNavigator)
            {
                ((IKissDataNavigator)ActiveMdiChild).RefreshData();
            }
            KissCommands.Refresh.Execute(null, null);
        }

        private void btnResetSuchkriterien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Control controlToSearch = FindKissSearchControl(GetFocusControl());

            if (controlToSearch != null)
            {
                bool controlFound = false;

                foreach (Control tabControl in UtilsGui.AllControls(controlToSearch))
                {
                    // check if current control is the tabcontrol we search
                    if (tabControl.Name.ToUpper().Equals(@"TABCONTROLSEARCH") && tabControl is KissTabControlEx)
                    {
                        // get tabcontrol
                        KissTabControlEx tabControlEx = (KissTabControlEx)tabControl;

                        // loop all tabpages
                        foreach (TabPageEx tpgControl in tabControlEx.TabPages)
                        {
                            if (tpgControl.Name.ToUpper().Equals(@"TPGSUCHEN"))
                            {
                                // SEARCH TPG:
                                if (controlToSearch is KissSearchForm)
                                {
                                    ((KissSearchForm)controlToSearch.Controls.Owner).OnNewSearch();
                                }
                                else
                                {
                                    ((KissSearchUserControl)controlToSearch.Controls.Owner).OnNewSearch();
                                }

                                controlFound = true;
                            }
                            else
                            {
                                // ANY OTHER TPG, reset all grids
                                foreach (Control control in UtilsGui.AllControls(tpgControl))
                                {
                                    if (control.GetType() == typeof(KissGrid))
                                    {
                                        ((KissGrid)control).LookAndFeel.Reset();
                                    }
                                }
                            }
                        }

                        if (controlFound)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void btnStartlayoutfestlegen_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                base.SaveLayout();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(typeof(FrmMain).Name, "FehlerLayoutSpeichern", "Fehler beim Speichern des Startup-Layouts.", ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnUndo_ItemClick(object sender, ItemClickEventArgs e)
        {
            var activeMdiChild = ActiveMdiChild as IKissDataNavigator;
            if (activeMdiChild != null)
            {
                (activeMdiChild).UndoDataChanges();
            }
            KissCommands.UndoChangesOnItem.Execute(null, null);
        }

        /// <summary>
        /// Close all open forms within MDI
        /// </summary>
        private void CloseAllForms()
        {
            // loop all mdi child forms
            foreach (Form frm in MdiChildren)
            {
                // reset any applied lock on KissForms
                if (frm is KissForm)
                {
                    ((KissForm)frm).ResetLockCloseForm();
                }

                // close this form
                frm.Close();
            }
        }

        /// <summary>
        /// Disable menu items recursively
        /// </summary>
        /// <param name="subMenu">The BarSubItem where the sub menu items are</param>
        /// <param name="onlyDynamicCreatedItems">True will disable only dynamically created menu items (itm.Name is "")</param>
        private void DisableMenuItems(BarSubItem subMenu, bool onlyDynamicCreatedItems)
        {
            // check instance first
            if (subMenu == null)
            {
                //invalid, do not continue
                return;
            }

            // loop all items in current submenu
            foreach (BarItemLink itm in subMenu.ItemLinks)
            {
                // validate type
                if (itm.Item is BarSubItem || itm.Item is BarButtonItem)
                {
                    if (!onlyDynamicCreatedItems || DBUtil.IsEmpty(itm.Item.Name))
                    {
                        //is dynamically created menu item --> disable
                        itm.Item.Enabled = false;
                    }

                    // is submenu?
                    if (itm.Item is BarSubItem)
                    {
                        // do recursion for each subMenu
                        DisableMenuItems((BarSubItem)itm.Item, onlyDynamicCreatedItems);
                    }
                }
            }
        }

        /// <summary>
        /// Disable all itemlinks on toolbar
        /// </summary>
        /// <param name="toolBar">Toolbar to disable</param>
        private void DisableToolbar(Bar toolBar)
        {
            foreach (BarItemLink link in toolBar.ItemLinks)
            {
                // disable only items with no name --> these are dynamic generated items
                if (DBUtil.IsEmpty(link.Item.Name))
                {
                    link.Item.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Disable specific top level menu items on menubar
        /// </summary>
        /// <param name="menuBar">MenuBar to disable</param>
        private void DisableTopLevelMenuItems(Bar menuBar)
        {
            foreach (BarItemLink link in menuBar.ItemLinks)
            {
                // disable all menu items exept subDatei and subHilfe
                if (link.Item == subDatei)
                {
                    link.Item.Enabled = true;
                    DisableMenuItems(subDatei, true);
                }
                else if (link.Item == subHilfe)
                {
                    link.Item.Enabled = true;
                    DisableMenuItems(subHilfe, true);
                }
                else
                {
                    link.Item.Enabled = false;

                    // check if item is submenu
                    if (link.Item is BarSubItem)
                    {
                        // disable all menu items recursively
                        DisableMenuItems((BarSubItem)link.Item, false);
                    }
                }
            }
        }

        private void dynamicFavorite_ItemClick(object sender, ItemClickEventArgs e)
        {
            Control controlToSearch = FindKissSearchControl(GetFocusControl());

            if (controlToSearch != null)
            {
                // getting a reference to the related favorite.
                _lastSelectedFavorite = ((Favorite)e.Item.Tag);

                // gettings a reference to the "Liste" tab to switch to it if "SearchImmediately" is "true".
                TabPageEx tpgListe = null;
                TabPageEx tpgSuche = null;

                // loops through all controls.
                foreach (Control tabControl in UtilsGui.AllControls(controlToSearch))
                {
                    // check if current control is the tabcontrol we search
                    if (tabControl.Name.ToUpper().Equals(@"TABCONTROLSEARCH") && tabControl is KissTabControlEx)
                    {
                        // get tabcontrol
                        KissTabControlEx tabControlEx = (KissTabControlEx)tabControl;

                        // loop all tabpages
                        foreach (TabPageEx tpgControl in tabControlEx.TabPages)
                        {
                            if (tpgControl.Name.ToUpper().Equals(@"TPGSUCHEN"))
                            {
                                // SEARCH TPG:
                                // apply tpg and select tpg
                                tpgSuche = tpgControl;
                                tabControlEx.SelectTab(tpgSuche);

                                // handle search controls
                                foreach (Control control in UtilsGui.AllControls(tpgControl))
                                {
                                    foreach (FavoriteControl favoriteControl in _lastSelectedFavorite.FavoriteControls)
                                    {
                                        if (control.Name.ToUpper().Equals(favoriteControl.Name.ToUpper()))
                                        {
                                            var action = GetActionForRestoreForControlType(control.GetType());

                                            if (action != null)
                                            {
                                                action.Invoke(control, favoriteControl);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // ANY OTHER TPG:
                                // check if need to apply tpg
                                if (tpgControl.Name.ToUpper().Equals(@"TPGLISTE"))
                                {
                                    // set tpgListe
                                    tpgListe = tpgControl;
                                }

                                // TODO: GridLayout is at the moment saved in favorite XSearchControlTemplate.ColLayout
                                // (only one grid supported), change this to support multigrids
                                if (tpgControl.Name.ToUpper().Equals(@"TPGLISTE"))
                                {
                                    // loop all controls within tabpage
                                    foreach (Control control in UtilsGui.AllControls(tpgControl))
                                    {
                                        var action = GetActionForRestoreForControlType(control.GetType());

                                        if (action != null)
                                        {
                                            action.Invoke(control, null);
                                        }
                                    }
                                }
                            }
                        }

                        // select tabpage depending on settings
                        if (_lastSelectedFavorite.SearchImmediately)
                        {
                            if (tpgListe != null)
                            {
                                tabControlEx.SelectTab(tpgListe);
                            }
                        }
                        else
                        {
                            if (tpgSuche != null)
                            {
                                tabControlEx.SelectTab(tpgSuche);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ItemClick event for dynamic generated menu items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DynamicMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (sender is BarManager && e.Item is BarButtonItem)
                {
                    // get classname from tag of BarButtonItem
                    string className = e.Item.Tag.ToString();

                    if (!DBUtil.IsEmpty(className))
                    {
                        try
                        {
                            // get type of desired class
                            Type typ = AssemblyLoader.GetType(className);

                            if (typ == null)
                            {
                                throw new KissErrorException("Type for desired class not found, probably the necessary assembly does not exist.");
                            }

                            if (typeof(KissChildForm).IsAssignableFrom(typ))
                            {
                                FormController.OpenForm(className);
                            }
                            else if (typeof(KissDialog).IsAssignableFrom(typ))
                            {
                                FormController.ShowDialogOnMain(className);
                            }
                            else
                            {
                                throw new KissErrorException(string.Format("Type '{0}' is not supported, can only show types of 'KiSS4.Gui.KissDialog' or 'KiSS4.Gui.KissChildForm'.", typ.BaseType));
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new KissErrorException(string.Format("Cannot show class '{0}'.{1}{1}Exception:{1}{2}", className, Environment.NewLine, ex.Message), ex);
                        }
                    }
                    else
                    {
                        throw new KissErrorException("Invalid mask or dialog name for this item, cannot open desired user interface.");
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(typeof(FrmMain).Name, "ErrorInDynamicMenuItemClick", "Fehler beim Ausführen des Befehls.", ex);
            }
        }

        private void EnableParentMenu(BarSubItem menu)
        {
            if (menu != null)
            {
                if (menu.ItemLinks != null)
                {
                    foreach (BarItemLink link in menu.ItemLinks)
                    {
                        if (link.Enabled)
                        {
                            menu.Enabled = true;
                            return;
                        }
                    }
                }
                menu.Enabled = false;
            }
        }

        /// <summary>
        /// Get instance of BarItem depending on its property name
        /// </summary>
        /// <param name="barItemInstanceName">Name of BarItem to search</param>
        /// <returns>Instance if found, or null if not found or on exception</returns>
        private BarItem FindBarItemInstance(string barItemInstanceName)
        {
            try
            {
                if (!DBUtil.IsEmpty(barItemInstanceName))
                {
                    return AssemblyLoader.GetPropertyValue(this, barItemInstanceName) as BarItem;
                }

                //not found
                return null;
            }
            catch
            {
                return null;
            }
        }

        private Control FindKissSearchControl(Control leafControl)
        {
            if (leafControl == null)
            {
                return null;
            }

            do
            {
                if (leafControl is KissSearchUserControl || leafControl is KissSearchForm)
                {
                    return leafControl;
                }

                leafControl = leafControl.Parent;
            }
            while (leafControl != null);

            return null;
        }

        private Action<Control, FavoriteControl> GetActionForRestoreForControlType(Type type)
        {
            Action<Control, FavoriteControl> action;

            if (_controlTypeActionForRestore.TryGetValue(type, out action))
            {
                return action;
            }

            if (type.BaseType != typeof(object))
            {
                return GetActionForRestoreForControlType(type.BaseType);
            }

            return null;
        }

        private Action<Control, Favorite> GetActionForSaveForControlType(Type type)
        {
            Action<Control, Favorite> action;

            if (_controlTypeActionForSave.TryGetValue(type, out action))
            {
                return action;
            }

            if (type.BaseType != typeof(object))
            {
                return GetActionForSaveForControlType(type.BaseType);
            }

            return null;
        }

        /// <summary>
        /// Get shortcut for menu item depending on description string
        /// </summary>
        /// <param name="ctrlKey">True if using CTRL-key</param>
        /// <param name="shiftKey">True if using SHIFT-key</param>
        /// <param name="altKey">True if using ALT-key</param>
        /// <param name="shortcutKey">String of key to use (e.g. K, F4)</param>
        /// <returns>Null if no key or shortcut was found or the correspondend BarShortcut</returns>
        private BarShortcut GetShortcutForMenu(bool ctrlKey, bool shiftKey, bool altKey, string shortcutKey)
        {
            if (shortcutKey != null && !shortcutKey.Equals(""))
            {
                try
                {
                    // get shortcutKey
                    Keys key = (Keys)Enum.Parse(typeof(Keys), shortcutKey, true);

                    // define others
                    Keys ctrl = Keys.None;
                    Keys shift = Keys.None;
                    Keys alt = Keys.None;

                    if (ctrlKey)
                    {
                        ctrl = Keys.Control;
                    }
                    if (shiftKey)
                    {
                        shift = Keys.Shift;
                    }
                    if (altKey)
                    {
                        alt = Keys.Alt;
                    }

                    // create shortcut
                    return new BarShortcut(ctrl | shift | alt | key);
                }
                catch (Exception ex)
                {
                    _log.Debug(ex);
                }
            }

            return null;
        }

        private void listSprachen_ListItemClick(object sender, ListItemClickEventArgs e)
        {
            try
            {
                // check if item was unchecked only -> recheck it agin
                if (listSprachen.ItemIndex < 0)
                {
                    listSprachen.ItemIndex = e.Index;
                    return;
                }

                // clear cache for stored multilanguage items
                Session.CacheManager.ClearLanguageCache();
                var xlovService = Kiss.Infrastructure.IoC.Container.Resolve<XLovService>();
                xlovService.ClearCache();

                // get code of current language (multilanguage depending)
                object code = DBUtil.ExecuteScalarSQL(@"
                        SELECT TOP 1
                               LOV.Code
                        FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
                          LEFT JOIN dbo.XLangText LNG WITH (READUNCOMMITTED) ON LNG.TID = LOV.TextTID AND
                                                                                LNG.LanguageCode = {0}
                        WHERE LOV.LOVName = 'Sprache' AND
                              (ISNULL(LNG.Text, '') = {1} OR (LNG.Text IS NULL AND LOV.Text = {1}))", Session.User.LanguageCode, listSprachen.Strings[listSprachen.ItemIndex]);

                // apply new language code
                Session.User.LanguageCode = Convert.ToInt32(code);
                Session.SetThreadCulture(Session.User.LanguageCode);

                // reload menus
                LoadMenuItems();

                // retranslate all controls
                foreach (Form frm in MdiChildren)
                {
                    if (frm is KissForm)
                    {
                        ((KissForm)frm).Translation.Translate(Session.User.LanguageCode);
                    }

                    TranslateForms(frm.Controls);
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Load and apply static and dynamic menu items from database (recursive depending on parentid)
        /// </summary>
        /// <param name="subMenu">The BarSubItem where the sub menu items shall be applied to</param>
        /// <param name="parentMenuID">The id of the BarSubItem, used as ParentMenuID for children</param>
        private void LoadDynamicMenuItems(BarSubItem subMenu, Int32 parentMenuID)
        {
            // check instance first
            if (subMenu == null || parentMenuID < 0)
            {
                //invalid, do not continue
                return;
            }

            // get menuitems from db
            SqlQuery qry = DBUtil.OpenSQL(string.Format(@"
                SELECT MenuItemID, ControlName, Caption=ISNULL(TXT.Text, MNU.Caption),
                       BeginMenuGroup, Enabled, ItemShortcutCtrl, ItemShortcutShift,
                       ItemShortcutAlt, ItemShortcutKey, ImageIndex, ImageIndexDisabled,
                       ClassName, ShowInToolbar, BeginToolbarGroup, SortKey, ToolbarSortKey,
                       CountedSubItems = (SELECT COUNT(1)
                                          FROM dbo.XMenuItem SUB WITH (READUNCOMMITTED)
                                          WHERE SUB.ParentMenuItemID = MNU.MenuItemID),
                       HideLockedItems = (SELECT SUB.HideLockedItems
                                          FROM dbo.XMenuItem SUB WITH (READUNCOMMITTED)
                                          WHERE SUB.MenuItemID = 1)
                FROM dbo.XMenuItem AS MNU WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = MNU.MenuTID
                                                                    AND TXT.LanguageCode = {1}
                WHERE (MNU.ParentMenuItemID = {0} OR {0} = 0 AND MNU.ParentMenuItemID IS NULL) -- take only submenuentries for current id
                  AND MNU.Visible = 1                            -- show only visible entries
                  AND (MNU.OnlyBIAGAdminVisible = 0 OR {2} = 1)  -- show BIAGAdmin entries only for BIAGAdmins
                ORDER BY MNU.SortKey, MNU.MenuItemID;",
                parentMenuID,
                DBUtil.SqlLiteral(Session.User.LanguageCode),
                DBUtil.SqlLiteral(Session.User.IsUserBIAGAdmin)));

            // clear first in order to prevent multiple similar menu items
            subMenu.ClearLinks();

            // loop through menu items and add them to menu
            foreach (System.Data.DataRow row in qry.DataTable.Rows)
            {
                // check if we have a controlname
                string controlName = row["ControlName"] as string;

                if (!DBUtil.IsEmpty(controlName))
                {
                    // STATIC ITEM
                    // get instance of menuitem
                    BarItem barItem = FindBarItemInstance(controlName);
                    if (barItem != null)
                    {
                        // set vars
                        string className = row["ClassName"] as string;

                        bool hasChildren = barItem is BarSubItem;
                        bool isItemEnabled = Convert.ToBoolean(row["Enabled"]);
                        bool addThisItem = true;

                        // setup vars depending on states and rights
                        if (hasChildren || DBUtil.IsEmpty(className))
                        {
                            // has children or no classname
                            isItemEnabled = (isItemEnabled && Session.Active);
                        }
                        else
                        {
                            // has no children
                            if (isItemEnabled)
                            {
                                // get userright for defined class
                                bool userHasRight = DBUtil.UserHasRight(className);

                                // check if need to hide item if user has no rights for defined item
                                if (!userHasRight && Convert.ToBoolean(row["HideLockedItems"]))
                                {
                                    // user has no rights for this item
                                    addThisItem = false;
                                    isItemEnabled = false;
                                }
                                else if (!Session.Active || !userHasRight)
                                {
                                    // item is disabled
                                    isItemEnabled = false;
                                }
                            }
                        }

                        // setup item
                        if ((row["Caption"] as String) != null)
                        {
                            barItem.Caption = Convert.ToString(row["Caption"]);
                        }

                        barItem.Hint = barItem.Caption;
                        barItem.Enabled = isItemEnabled;
                        barItem.ImageIndex = KissImageList.GetImageIndex(Convert.ToInt32(row["ImageIndex"]));
                        barItem.ImageIndexDisabled = KissImageList.GetImageIndex(Convert.ToInt32(row["ImageIndexDisabled"]));

                        barItem.ItemShortcut = GetShortcutForMenu(
                            Convert.ToBoolean(row["ItemShortcutCtrl"]),
                            Convert.ToBoolean(row["ItemShortcutShift"]),
                            Convert.ToBoolean(row["ItemShortcutAlt"]),
                            Convert.ToString(row["ItemShortcutKey"]));

                        // add item to manager and menu
                        if (addThisItem)
                        {
                            barManager.Items.Add(barItem);
                            subMenu.ItemLinks.Add(barItem, Convert.ToBoolean(row["BeginMenuGroup"]));
                        }

                        // check if is submenu
                        if (hasChildren)
                        {
                            // do recursion
                            LoadDynamicMenuItems((BarSubItem)barItem, Convert.ToInt32(row["MenuItemID"]));
                            if (barItem.Enabled)
                            {
                                EnableParentMenu((BarSubItem)barItem);
                            }
                        }
                        else
                        {
                            // check if need to add this item to toolbar
                            if (addThisItem)
                            {
                                // add item to toolbar
                                AddItemToToolbarDictionaries(
                                    Convert.ToBoolean(row["ShowInToolbar"]),
                                    row["ToolbarSortKey"],
                                    Convert.ToBoolean(row["BeginToolbarGroup"]),
                                    barItem);
                            }
                        }
                    }
                }
                else
                {
                    // DYNAMIC ITEM
                    // check if menu has submenu items (children)
                    string className = row["ClassName"] as string;

                    bool hasChildren =
                        (Convert.ToInt32(row["CountedSubItems"])) > 0 &&
                        !IsClassTypeOfIContainerForm(className);

                    bool isItemEnabled = Convert.ToBoolean(row["Enabled"]);
                    bool addThisItem = true;

                    // create new BarItem depending on mode and classname
                    BarItem barItem;

                    if (hasChildren)
                    {
                        // has children
                        barItem = new BarSubItem();
                        isItemEnabled = (isItemEnabled && Session.Active);
                    }
                    else
                    {
                        // has no children
                        barItem = new BarButtonItem();

                        if (isItemEnabled)
                        {
                            // get userright for defined class
                            bool userHasRight = DBUtil.UserHasRight(className);

                            // check if need to hide item if user has no rights for defined class
                            if (!userHasRight && Convert.ToBoolean(row["HideLockedItems"]) && !DBUtil.IsEmpty(className))
                            {
                                // user has no rights for this class
                                addThisItem = false;
                                isItemEnabled = false;
                            }
                            else if (DBUtil.IsEmpty(className) || !Session.Active || !userHasRight)
                            {
                                // item is disabled
                                isItemEnabled = false;
                            }
                        }

                        if (isItemEnabled)
                        {
                            barItem.Tag = className; // --> store className in tag for using in eventhandler!
                            barItem.ItemClick += DynamicMenuItem_ItemClick;
                        }
                    }

                    // apply settings
                    barItem.Caption = row["Caption"] as string;
                    barItem.Hint = barItem.Caption;
                    barItem.Enabled = isItemEnabled;
                    barItem.ImageIndex = KissImageList.GetImageIndex(Convert.ToInt32(row["ImageIndex"]));
                    barItem.ImageIndexDisabled = KissImageList.GetImageIndex(Convert.ToInt32(row["ImageIndexDisabled"]));

                    barItem.ItemShortcut = GetShortcutForMenu(Convert.ToBoolean(row["ItemShortcutCtrl"]),
                                                                            Convert.ToBoolean(row["ItemShortcutShift"]),
                                                                            Convert.ToBoolean(row["ItemShortcutAlt"]),
                                                                            Convert.ToString(row["ItemShortcutKey"]));

                    // add item to manager and menu
                    if (addThisItem)
                    {
                        barManager.Items.Add(barItem);
                        subMenu.ItemLinks.Add(barItem, Convert.ToBoolean(row["BeginMenuGroup"]));
                    }

                    // check if menu has submenu items (children)
                    if (hasChildren)
                    {
                        // --> menus with subitems cannot have a mask to open
                        // do recursion
                        LoadDynamicMenuItems(barItem as BarSubItem, Convert.ToInt32(row["MenuItemID"]));

                        if (barItem.Enabled)
                        {
                            EnableParentMenu(barItem as BarSubItem);
                        }
                    }
                    else
                    {
                        // check if need to add this item to toolbar
                        if (addThisItem)
                        {
                            // add item to toolbar
                            AddItemToToolbarDictionaries(
                                Convert.ToBoolean(row["ShowInToolbar"]),
                                row["ToolbarSortKey"],
                                Convert.ToBoolean(row["BeginToolbarGroup"]),
                                barItem);
                        }
                    }
                } //[check if we have a controlname]
            } //[foreach in datatable]
        }

        /// <summary>
        /// Load and apply dynamic toolbar menu items from database
        /// </summary>
        /// <param name="toolbar">The toolbar where the menu items shall be applied to</param>
        private void LoadDynamicToolbar(Bar toolbar)
        {
            // check instance first
            if (toolbar == null ||
                _toolbarBarItems.Count < 1 ||
                _toolbarBarItemsIsNewGroup.Count < 1 ||
                _toolbarBarItems.Count != _toolbarBarItemsIsNewGroup.Count)
            {
                //invalid, do not continue
                return;
            }

            try
            {
                // clear toolbar first in order to prevent multiple similar entries, and show it
                toolbar.ClearLinks();
                toolbar.Visible = true;

                ApplicationFacade.DoEvents();

                // stop repainting
                toolbar.BeginUpdate();

                // create array to do sorting of toolbarsortkey
                var sortkeys = new List<int>(_toolbarBarItems.Count);

                // loop though each item in dictionary to get key
                foreach (DictionaryEntry entry in _toolbarBarItems)
                {
                    sortkeys.Add((int)entry.Key);
                }

                // sort array
                sortkeys.Sort();

                // loop through sorted keys
                foreach (int k in sortkeys)
                {
                    toolbar.ItemLinks.Add((BarItem)_toolbarBarItems[k], Convert.ToBoolean(_toolbarBarItemsIsNewGroup[k]));
                }

                barSearchEditItem.Edit.NullText = KissMsg.GetMLMessage(typeof(FrmMain).Name, "SearchBarCaption", "Suche");
                barSearchEditItem.Hint = KissMsg.GetMLMessage(typeof(FrmMain).Name, "SearchBarHint", "Suche");

                // TODO: autoresize toolbar??
            }
            finally
            {
                if (toolbar.ItemLinks.Count < 1)
                {
                    toolbar.Visible = false;
                }

                toolbar.EndUpdate();

                // remove dictionaries
                _toolbarBarItems = null;
                _toolbarBarItemsIsNewGroup = null;
            }
        }

        /// <summary>
        /// Load and apply static and dynamic toplevel menu items from database
        /// </summary>
        /// <param name="menuBar">The Bar where the sub menu items shall be applied to</param>
        private void LoadTopLevelMenuItems(Bar menuBar)
        {
            // check instance first
            if (menuBar == null)
            {
                //invalid, do not continue
                return;
            }

            // get menuitems from db
            SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT MenuItemID,
                           ControlName,
                           Caption = ISNULL(TXT.Text, MNU.Caption),
                           Enabled,
                           SortKey,
                           CountedSubItems = (SELECT COUNT(1)
                                              FROM dbo.XMenuItem SUB WITH (READUNCOMMITTED)
                                              WHERE SUB.ParentMenuItemID = MNU.MenuItemID),
                           HideLockedItems = (SELECT SUB.HideLockedItems
                                              FROM dbo.XMenuItem SUB WITH (READUNCOMMITTED)
                                              WHERE SUB.MenuItemID = 1)
                    FROM dbo.XMenuItem MNU WITH (READUNCOMMITTED)
                      LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = MNU.MenuTID AND
                                                                            TXT.LanguageCode = {0}
                    WHERE MNU.ParentMenuItemID = 1 AND                  -- take only top-level-menuentries
                          MNU.Visible = 1 AND                           -- show only visible entries
                          (MNU.OnlyBIAGAdminVisible = 0 OR {1} = 1)     -- show BIAGAdmin entries only for BIAGAdmins
                    ORDER BY MNU.SortKey, MNU.MenuItemID ", Session.User.LanguageCode, Session.User.IsUserBIAGAdmin);

            // clear first in order to prevent multiple similar menu items
            menuBar.ClearLinks();

            // loop through menu items and add them to menu
            foreach (System.Data.DataRow row in qry.DataTable.Rows)
            {
                // check if we have a controlname
                string controlName = row["ControlName"] as string;

                if (!DBUtil.IsEmpty(controlName))
                {
                    // STATIC ITEM
                    // get instance of menuitem
                    BarItem barItem = FindBarItemInstance(controlName);

                    if (barItem != null)
                    {
                        if ((row["Caption"] as string) != null)
                        {
                            barItem.Caption = row["Caption"] as string;
                        }

                        barItem.Hint = barItem.Caption;
                        barItem.Enabled = Convert.ToBoolean(row["Enabled"]);

                        // add item to manager and menu
                        barManager.Items.Add(barItem);
                        menuBar.ItemLinks.Add(barItem);

                        // check if is submenu
                        if (barItem is BarSubItem)
                        {
                            // do recursion
                            LoadDynamicMenuItems((BarSubItem)barItem, Convert.ToInt32(row["MenuItemID"]));
                            if (barItem.Enabled)
                            {
                                EnableParentMenu((BarSubItem)barItem);
                            }

                            // check if need to hide
                            if (Convert.ToBoolean(row["HideLockedItems"]) && !barItem.Enabled)
                            {
                                // hide item
                                barItem.Visibility = BarItemVisibility.Never;
                            }
                            else
                            {
                                // show item
                                barItem.Visibility = BarItemVisibility.Always;
                            }
                        }
                    }
                }
                else
                {
                    // DYNAMIC ITEM
                    // check if menu has submenu items (children)
                    bool hasChildren = (Convert.ToInt32(row["CountedSubItems"])) > 0;

                    // create new BarItem depending on mode
                    BarItem barItem = hasChildren ? (BarItem)new BarSubItem() : new BarButtonItem();

                    // apply settings
                    barItem.Caption = row["Caption"] as string;
                    barItem.Hint = barItem.Caption;
                    barItem.Enabled = Convert.ToBoolean(row["Enabled"]);

                    // add item to manager and menu
                    barManager.Items.Add(barItem);
                    menuBar.ItemLinks.Add(barItem);

                    // check if menu has submenu items (children)
                    if (hasChildren)
                    {
                        // --> menus with subitems cannot have a mask to open
                        // do recursion
                        LoadDynamicMenuItems(barItem as BarSubItem, Convert.ToInt32(row["MenuItemID"]));

                        if (barItem.Enabled)
                        {
                            EnableParentMenu(barItem as BarSubItem);
                        }

                        // check if need to hide
                        if (Convert.ToBoolean(row["HideLockedItems"]) && !barItem.Enabled)
                        {
                            barItem.Visibility = BarItemVisibility.Never;
                        }
                    }
                } //[check if we have a controlname]
            } //[foreach in datatable]
        }

        private void OpenFavoriteVerwaltung(Favorite favorite)
        {
            IDictionary<int, Favorite> favorites;
            FavoriteController controller = new FavoriteController();

            FavoritesView view = new FavoritesView();

            if (favorite != null)
            {
                view.DisplayAllFavorites = false;
                favorites = controller.GetFavoritesForClass(favorite.ClassName);
                favorites.Add(favorite.XSearchControlTemplateId, favorite);
            }
            else
            {
                view.DisplayAllFavorites = true;
                favorites = controller.GetAllFavorites();
            }

            view.Favorites = favorites;
            view.ShowDialog();
            view.Focus();
        }

        private async void PreLoadConfigCache()
        {
            if (Kiss.Infrastructure.IoC.Container.IsRegistered<IUnitOfWorkFactory>())
            {
                await Task.Run(() => Kiss.Infrastructure.IoC.Container.TryResolve<XConfigService>());
            }
        }

        private void RegisterControlTypeActionsForRestore()
        {
            _controlTypeActionForRestore.Clear();

            _controlTypeActionForRestore.Add(typeof(KissTextEdit), (c, fc) =>
            {
                if (c != null && fc != null)
                {
                    c.Text = fc.Value;
                }
            });

            _controlTypeActionForRestore.Add(typeof(KissCalcEdit), (c, fc) =>
            {
                if (c != null && fc != null)
                {
                    c.Text = fc.Value;
                }
            });

            _controlTypeActionForRestore.Add(typeof(KissCheckEdit), (c, fc) =>
            {
                if (c != null && fc != null)
                {
                    ((KissCheckEdit)c).Checked = Convert.ToBoolean(fc.Value);
                }
            });

            _controlTypeActionForRestore.Add(typeof(KissDateEdit), (c, fc) =>
            {
                if (c != null && fc != null)
                {
                    c.Text = fc.Value;
                }
            });

            _controlTypeActionForRestore.Add(typeof(KissLookUpEdit), (c, fc) =>
            {
                if (c != null && fc != null)
                {
                    ((KissLookUpEdit)c).ItemIndex = Convert.ToInt32(fc.Value);
                }
            });

            _controlTypeActionForRestore.Add(typeof(KissButtonEdit), (c, fc) =>
            {
                if (c != null && fc != null)
                {
                    // HACK: we need to set focus and move it in order to raise EditValue changed event.
                    //       setting the editvalue does not work as it somehow locks searching afterward
                    //       until the editvalue is again manually modified.
                    c.Focus();
                    c.Text = fc.Value;
                    c.SelectNextControl(c, true, true, true, true);
                }
            });

            _controlTypeActionForRestore.Add(typeof(KissCheckedLookupEdit), (c, fc) =>
            {
                if (c != null && fc != null)
                {
                    ((KissCheckedLookupEdit)c).EditValue = fc.Value;
                }
            });

            _controlTypeActionForRestore.Add(typeof(KissPickList), (c, fc) =>
            {
                if (c != null && fc != null)
                {
                    // TODO: this feature is not supported yet by KissPickList
                    //((KissPickList)c).EditValue = fc.Value;
                }
            });

            _controlTypeActionForRestore.Add(typeof(KissGrid), (c, fc) =>
            {
                if (c != null &&
                    _lastSelectedFavorite.ColLayout != null &&
                    _lastSelectedFavorite.ColLayout.Equals(string.Empty) == false)
                {
                    Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(_lastSelectedFavorite.ColLayout));
                    ((KissGrid)c).View.RestoreLayoutFromStream(stream, OptionsLayoutBase.FullLayout);
                    stream.Close();
                    stream.Dispose();
                }
            });
        }

        private void RegisterControlTypeActionsForSave()
        {
            _controlTypeActionForSave.Clear();

            _controlTypeActionForSave.Add(typeof(KissTextEdit), (c, f) =>
            {
                FavoriteControl favoriteControl = AddFavorite(c);
                favoriteControl.Value = c.Text;
                f.FavoriteControls.Add(favoriteControl);
            });

            _controlTypeActionForSave.Add(typeof(KissCalcEdit), (c, f) =>
            {
                FavoriteControl favoriteControl = AddFavorite(c);
                favoriteControl.Value = c.Text;
                f.FavoriteControls.Add(favoriteControl);
            });

            _controlTypeActionForSave.Add(typeof(KissCheckEdit), (c, f) =>
            {
                FavoriteControl favoriteControl = AddFavorite(c);
                favoriteControl.Value = ((KissCheckEdit)c).Checked.ToString();
                f.FavoriteControls.Add(favoriteControl);
            });

            _controlTypeActionForSave.Add(typeof(KissDateEdit), (c, f) =>
            {
                FavoriteControl favoriteControl = AddFavorite(c);
                favoriteControl.Value = c.Text;
                f.FavoriteControls.Add(favoriteControl);
            });

            _controlTypeActionForSave.Add(typeof(KissLookUpEdit), (c, f) =>
            {
                FavoriteControl favoriteControl = AddFavorite(c);
                favoriteControl.Value = ((KissLookUpEdit)c).ItemIndex.ToString();
                f.FavoriteControls.Add(favoriteControl);
            });

            _controlTypeActionForSave.Add(typeof(KissButtonEdit), (c, f) =>
            {
                FavoriteControl favoriteControl = AddFavorite(c);
                favoriteControl.Value = c.Text;
                f.FavoriteControls.Add(favoriteControl);
            });

            _controlTypeActionForSave.Add(typeof(KissCheckedLookupEdit), (c, f) =>
            {
                FavoriteControl favoriteControl = AddFavorite(c);
                favoriteControl.Value = ((KissCheckedLookupEdit)c).EditValue.ToString();
                f.FavoriteControls.Add(favoriteControl);
            });

            _controlTypeActionForSave.Add(typeof(KissPickList), (c, f) =>
            {
                FavoriteControl favoriteControl = AddFavorite(c);
                favoriteControl.Value = ((KissPickList)c).SelectedIds;
                f.FavoriteControls.Add(favoriteControl);
            });

            _controlTypeActionForSave.Add(typeof(KissGrid), (c, f) =>
            {
                Stream stream = new MemoryStream();
                ((KissGrid)c).View.SaveLayoutToStream(stream, OptionsLayoutBase.FullLayout);
                stream.Seek(0, SeekOrigin.Begin);

                string layout;

                using (StreamReader rdr = new StreamReader(stream))
                {
                    layout = rdr.ReadToEnd();
                }

                stream.Close();
                stream.Dispose();

                f.ColLayout = layout;
            });
        }

        private Favorite SaveFavorite(Control controlToSearch, Favorite favorite, bool saveAs)
        {
            bool controlsFound = false;

            // loops through all controls.
            foreach (Control tabControl in UtilsGui.AllControls(controlToSearch))
            {
                // check if current control is the tabcontrol we search
                if (tabControl.Name.ToUpper().Equals(@"TABCONTROLSEARCH") && tabControl is KissTabControlEx)
                {
                    // get tabcontrol
                    KissTabControlEx tabControlEx = (KissTabControlEx)tabControl;

                    // loop all tabpages
                    foreach (TabPageEx tpgControl in tabControlEx.TabPages)
                    {
                        if (tpgControl.Name.ToUpper().Equals(@"TPGSUCHEN"))
                        {
                            // SEARCH TPG:
                            // Since controls can be found on the "TpgSuchen" or "TpgListe",
                            // only one instance of the Favorite has to created.
                            if (controlsFound == false && (_lastSelectedFavorite == null || saveAs))
                            {
                                favorite = new Favorite();
                            }

                            if (_lastSelectedFavorite == null || saveAs)
                            {
                                if (favorite != null)
                                {
                                    favorite.ClassName = controlToSearch.Name;
                                    FavoriteController.SetClassUserText(favorite);
                                    favorite.ModulTreeName = controlToSearch.ProductName;
                                    favorite.UserId = Session.User.UserID;
                                    favorite.HasBeenModified = true;
                                    favorite.SetFocus = true;
                                }
                            }

                            controlsFound = true;

                            if (favorite != null)
                            {
                                foreach (Control control in UtilsGui.AllControls(tpgControl))
                                {
                                    // we do not support Grids (e.g. in KissPickList) in search tpg as it would mix up with Grids in other tpgs
                                    if (control is KissGrid)
                                    {
                                        continue;
                                    }

                                    var action = GetActionForSaveForControlType(control.GetType());

                                    if (action != null)
                                    {
                                        action.Invoke(control, favorite);
                                    }
                                }
                            }
                        }
                        else if (tpgControl.Name.ToUpper().Equals(@"TPGLISTE"))
                        {
                            // TODO: GridLayout is at the moment saved in favorite XSearchControlTemplate.ColLayout
                            // (only one grid supported), change this to support multigrids

                            // ANY OTHER TPG:
                            if (!controlsFound && (_lastSelectedFavorite == null || saveAs))
                            {
                                favorite = new Favorite();
                            }

                            controlsFound = true;

                            foreach (Control control in UtilsGui.AllControls(tpgControl))
                            {
                                // save only KissGrids at the moment
                                if (control.GetType() == typeof(KissGrid))
                                {
                                    var action = GetActionForSaveForControlType(control.GetType());

                                    if (action != null)
                                    {
                                        action.Invoke(control, favorite);
                                    }
                                }
                            }
                        }
                    }
                }

                if (controlsFound)
                {
                    break;
                }
            }

            return favorite;
        }

        /// <summary>
        /// Setup BackColor for barMainMenu
        /// </summary>
        private void SetbarMainMenuBackColor()
        {
            var menubalkenRotEinfaerben = DBUtil.GetConfigBool(@"System\GUI\MenubalkenRotEinfaerben", false);
            if (menubalkenRotEinfaerben)
            {
                barMainMenu.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// Setup menu items for language selection
        /// </summary>
        private void SetSprachen()
        {
            try
            {
                // clear current items
                listSprachen.Strings.Clear();

                // get languages from lov
                SqlDataReader dr = DBUtil.OpenSQLReader(
                    string.Format(@"
                        SELECT LOV.Code,
                               Text = ISNULL(TXT.Text, LOV.Text)
                        FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
                          LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = LOV.TextTID AND
                                                                                LanguageCode = {0}
                        WHERE LOVName = 'Sprache'
                        ORDER BY Code ASC", Session.User.LanguageCode));

                while (dr.Read())
                {
                    listSprachen.Strings.Add(dr["Text"].ToString());
                }

                dr.Close();

                // select language the user has
                if (Session.User.LanguageCode > 0)
                {
                    listSprachen.ItemIndex = listSprachen.Strings.IndexOf(DBUtil.GetLOVText("Sprache", Session.User.LanguageCode));
                }
                else
                {
                    listSprachen.ItemIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
        }

        /// <summary>
        /// Set text caption of frmMain depending on session and version
        /// </summary>
        private void SetText()
        {
            // apply text
            Text = string.Format("KiSS {0}", Utils.MainVersion);

            // check if session is active
            if (Session.Active)
            {
                // apply advanced default text
                Text = string.Format("{0} - {1} {2} ({3})", Text, Session.User.FirstName, Session.User.LastName, Session.User.LogonName);

                // special mark admin and biagadmin
                if (Session.User.IsUserBIAGAdmin)
                {
                    // biag admin
                    Text = string.Format("{0} - [{1}]", Text, KissMsg.GetMLMessage(typeof(FrmMain).Name, "UserIsBIAGAdmin", "BiagAdmin"));
                }
                else if (Session.User.IsUserAdmin)
                {
                    // admin
                    Text = string.Format("{0} - [{1}]", Text, KissMsg.GetMLMessage(typeof(FrmMain).Name, "UserIsAdmin", "Admin"));
                }
            }
        }

        private void subFavoriten_Popup(object sender, EventArgs e)
        {
            string className = string.Empty;

            Control control = FindKissSearchControl(GetFocusControl());

            if (control != null)
            {
                className = control.Name;
            }

            // Removes the previously dynamically added items.
            int count = 0;
            IList<BarButtonItemLink> itemsToRemove = new List<BarButtonItemLink>();

            foreach (BarButtonItemLink b in subFavoriten.ItemLinks)
            {
                if (count >= 4)
                {
                    itemsToRemove.Add(b);
                }

                count++;
            }

            foreach (BarButtonItemLink b in itemsToRemove)
            {
                subFavoriten.ItemLinks.Remove(b);
            }

            if (!string.IsNullOrEmpty(className))
            {
                // Removes the last selected favorite, if the selected view has changed.
                if (_lastSelectedFavorite != null && !_lastSelectedFavorite.ClassName.Equals(className))
                {
                    _lastSelectedFavorite = null;
                }

                FavoriteController favoriteController = new FavoriteController();
                IDictionary<int, Favorite> favorites = favoriteController.GetFavoritesForClass(className);

                // Adding the list of related favorites.
                bool startNewGroup = false;

                foreach (Favorite favorite in favorites.Values)
                {
                    if (favorite.ClassName != null &&
                        favorite.ClassName.ToUpper().Equals(className.ToUpper()) &&
                        favorite.FavoriteControls != null &&
                        favorite.FavoriteControls.Count > 0)
                    {
                        // Adding the favorite to the list.
                        _dynamicFavorite = new BarButtonItem();
                        _dynamicFavorite.Caption = favorite.Name;
                        _dynamicFavorite.Tag = favorite;

                        // set image
                        if (favorite.SearchImmediately)
                        {
                            // item with autosearch
                            _dynamicFavorite.ImageIndex = KissImageList.GetImageIndex(Favorite.ITEM_XICONID_AUTOSEARCH);
                        }
                        else
                        {
                            // item without autosearch
                            _dynamicFavorite.ImageIndex = KissImageList.GetImageIndex(Favorite.ITEM_XICONID);
                        }

                        _dynamicFavorite.ItemClick += dynamicFavorite_ItemClick;

                        subFavoriten.ItemLinks.Add(_dynamicFavorite, !startNewGroup);

                        if (startNewGroup == false)
                        {
                            startNewGroup = true;
                        }

                        _dynamicFavorite = null;
                    }
                }
            }
            else
            {
                _lastSelectedFavorite = null;
            }

            // Logic to enable/disable the favorite's buttons.
            btnFavoriteSpeichernUnter.Enabled = false;
            btnFavoriteSpeichern.Enabled = false;
            btnResetSuchkriterien.Enabled = false;

            if (control == null || !(control is KissSearchUserControl) && !(control is KissSearchForm))
            {
                string[] s = btnFavoriteSpeichern.Caption.Split(' ', '\'');
                btnFavoriteSpeichern.Caption = s[0];

                // Disables Favoriten buttons if the active form is not a "Suche" form.
                btnFavoriteSpeichernUnter.Enabled = false;
                btnFavoriteSpeichern.Enabled = false;
                btnResetSuchkriterien.Enabled = false;
            }
            else
            {
                if (_lastSelectedFavorite != null)
                {
                    StringBuilder sb = new StringBuilder();
                    string[] s = btnFavoriteSpeichern.Caption.Split(' ', '\'');
                    sb.Append(s[0]);
                    sb.Append(@" '");
                    sb.Append(_lastSelectedFavorite.Name);
                    sb.Append(@"'");

                    btnFavoriteSpeichern.Caption = sb.ToString();
                }
                else
                {
                    string[] s = btnFavoriteSpeichern.Caption.Split(' ', '\'');
                    btnFavoriteSpeichern.Caption = s[0];
                }

                // Enables Favoriten buttons if the active form is a "Suche" form.
                btnFavoriteSpeichernUnter.Enabled = true;
                btnFavoriteSpeichern.Enabled = true;
                btnResetSuchkriterien.Enabled = true;
            }
        }

        private void subLinks_Popup(object sender, EventArgs e)
        {
            // Remove old entries
            subLinks.ItemLinks.Clear();

            LinkHelper.PopulateDynamicLinkItems(subLinks);
        }

        private void TranslateForms(IEnumerable controls)
        {
            foreach (Control c in controls)
            {
                if (c is KissComplexControl)
                {
                    ((KissComplexControl)c).Translate();
                }
                else if (c is KissForm)
                {
                    ((KissForm)c).Translate();
                }

                TranslateForms(c.Controls);
            }
        }

        private void TranslateMenuItems()
        {
            // main menus
            subDatei.Caption = DB.Properties.Resources.FrmMain_subDatei;
            subBearbeiten.Caption = DB.Properties.Resources.FrmMain_subBearbeiten;
            subAnwendung.Caption = DB.Properties.Resources.FrmMain_subAnwendung;
            subSystem.Caption = DB.Properties.Resources.FrmMain_subSystem;
            subFavoriten.Caption = DB.Properties.Resources.FrmMain_subFavoriten;
            subFenster.Caption = DB.Properties.Resources.FrmMain_subFenster;
            subHilfe.Caption = DB.Properties.Resources.FrmMain_subHilfe;

            // subDatei
            btnPrint.Caption = DB.Properties.Resources.FrmMain_btnPrint;
            btnAnmelden.Caption = DB.Properties.Resources.FrmMain_btnAnmelden;
            btnAbmelden.Caption = DB.Properties.Resources.FrmMain_btnAbmelden;
            btnPasswortAendern.Caption = DB.Properties.Resources.FrmMain_btnPasswortAendern;
            subSpracheWechseln.Caption = DB.Properties.Resources.FrmMain_subSpracheWechseln;
            btnBeenden.Caption = DB.Properties.Resources.FrmMain_btnBeenden;

            // subHilfe
            btnInhalt.Caption = DB.Properties.Resources.FrmMain_btnInhalt;
            btnIndex.Caption = DB.Properties.Resources.FrmMain_btnIndex;
            btnTeamViewer.Caption = DB.Properties.Resources.FrmMain_btnTeamViewer;
            btnJira.Caption = DB.Properties.Resources.FrmMain_btnJira;
            btnAbout.Caption = DB.Properties.Resources.FrmMain_btnAbout;
        }

        /// <summary>
        /// Update db-imagelist with new icons from database
        /// </summary>
        private void UpdateDBImageList()
        {
            if (Session.Active)
            {
                imgUmgebung.Images.Clear();

                for (int i = 90; i < 100; i++)
                {
                    imgUmgebung.Images.Add(KissImageList.SmallImageList.Images[KissImageList.GetImageIndex(i)]);
                }
            }
        }

        /// <summary>
        /// Update menuitems: Set enabled mode on static items and load dynamic items and toolbar
        /// </summary>
        private void UpdateMenus()
        {
            // load static and dynamic menu items from database (before enable/disable)
            LoadMenuItems();

            // Datei
            subDatei.Enabled = true;
            btnPrint.Enabled = DBUtil.UserHasRight("FrmReportExplorer");
            btnAnmelden.Enabled = true;
            btnAbmelden.Enabled = true;
            btnPasswortAendern.Enabled = DBUtil.UserHasRight("Kiss.UI.View.Ad.AdPasswortAendernView.xaml");
            subSpracheWechseln.Enabled = Session.Active;
            btnBeenden.Enabled = true;

            // Bearbeiten
            btnNew.Enabled = Session.Active;
            btnSave.Enabled = Session.Active;
            btnUndo.Enabled = Session.Active;
            btnDelete.Enabled = Session.Active;
            btnFirst.Enabled = Session.Active;
            btnPrevious.Enabled = Session.Active;
            btnNext.Enabled = Session.Active;
            btnLast.Enabled = Session.Active;
            btnRefresh.Enabled = Session.Active;
            btnCut.Enabled = Session.Active;
            btnCopy.Enabled = Session.Active;
            btnPaste.Enabled = Session.Active;
            btnFind.Enabled = Session.Active;

            // Help
            btnAbout.Enabled = true;

            // Update MainMenuBackColor
            SetbarMainMenuBackColor();
        }
    }
}