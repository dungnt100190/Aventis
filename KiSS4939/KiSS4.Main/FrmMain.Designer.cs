using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Main
{
    partial class FrmMain
    {
        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barMainMenu = new DevExpress.XtraBars.Bar();
            this.subDatei = new DevExpress.XtraBars.BarSubItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnmelden = new DevExpress.XtraBars.BarButtonItem();
            this.btnAbmelden = new DevExpress.XtraBars.BarButtonItem();
            this.btnPasswortAendern = new DevExpress.XtraBars.BarButtonItem();
            this.subSpracheWechseln = new DevExpress.XtraBars.BarSubItem();
            this.listSprachen = new DevExpress.XtraBars.BarListItem();
            this.btnBeenden = new DevExpress.XtraBars.BarButtonItem();
            this.subBearbeiten = new DevExpress.XtraBars.BarSubItem();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnFirst = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrevious = new DevExpress.XtraBars.BarButtonItem();
            this.btnNext = new DevExpress.XtraBars.BarButtonItem();
            this.btnLast = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnCut = new DevExpress.XtraBars.BarButtonItem();
            this.btnCopy = new DevExpress.XtraBars.BarButtonItem();
            this.btnPaste = new DevExpress.XtraBars.BarButtonItem();
            this.btnFind = new DevExpress.XtraBars.BarButtonItem();
            this.subAnwendung = new DevExpress.XtraBars.BarSubItem();
            this.btnFallNavigator = new DevExpress.XtraBars.BarButtonItem();
            this.subSystem = new DevExpress.XtraBars.BarSubItem();
            this.btnBenutzerverwaltung = new DevExpress.XtraBars.BarButtonItem();
            this.btnKonfiguration = new DevExpress.XtraBars.BarButtonItem();
            this.btnModulKonfiguration = new DevExpress.XtraBars.BarButtonItem();
            this.btnBusinessDesigner = new DevExpress.XtraBars.BarButtonItem();
            this.btnDataEditor = new DevExpress.XtraBars.BarButtonItem();
            this.subFavoriten = new DevExpress.XtraBars.BarSubItem();
            this.btnFavoriteSpeichern = new DevExpress.XtraBars.BarButtonItem();
            this.btnFavoriteSpeichernUnter = new DevExpress.XtraBars.BarButtonItem();
            this.btnFavoritenVerwaltung = new DevExpress.XtraBars.BarButtonItem();
            this.btnResetSuchkriterien = new DevExpress.XtraBars.BarButtonItem();
            this.subLinks = new DevExpress.XtraBars.BarSubItem();
            this.btnDummyLink = new DevExpress.XtraBars.BarButtonItem();
            this.subFenster = new DevExpress.XtraBars.BarSubItem();
            this.btnCloseAll = new DevExpress.XtraBars.BarButtonItem();
            this.btnStartlayoutfestlegen = new DevExpress.XtraBars.BarButtonItem();
            this.btnFensterEinstLoeschen = new DevExpress.XtraBars.BarButtonItem();
            this.itmMdiChildrenList = new KiSS4.Gui.KissBarMdiChildrenListItem();
            this.subHilfe = new DevExpress.XtraBars.BarSubItem();
            this.btnInhalt = new DevExpress.XtraBars.BarButtonItem();
            this.btnIndex = new DevExpress.XtraBars.BarButtonItem();
            this.btnTeamViewer = new KiSS4.Gui.KissHyperlinkBarButtonItem();
            this.btnJira = new KiSS4.Gui.KissHyperlinkBarButtonItem();
            this.btnAbout = new DevExpress.XtraBars.BarButtonItem();
            this.barApplikation = new DevExpress.XtraBars.Bar();
            this.barUmgebung = new DevExpress.XtraBars.Bar();
            this.edtUmgebung = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemPickImage1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imgUmgebung = new System.Windows.Forms.ImageList(this.components);
            this.barSearch = new DevExpress.XtraBars.Bar();
            this.barSearchEditItem = new DevExpress.XtraBars.BarEditItem();
            this.barItemSearchTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.imgToolbar = new System.Windows.Forms.ImageList(this.components);
            this.BarEditEnvironment = new DevExpress.XtraBars.BarEditItem();
            this.barControler = new DevExpress.XtraBars.DefaultBarAndDockingController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPickImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barItemSearchTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barControler.Controller)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.AllowCustomization = false;
            this.barManager.AllowQuickCustomization = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMainMenu,
            this.barApplikation,
            this.barUmgebung,
            this.barSearch});
            this.barManager.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("MainMenu", new System.Guid("61769853-87e6-453e-9e67-1c9208529091")),
            new DevExpress.XtraBars.BarManagerCategory("MenuBefehle", new System.Guid("50af31d0-eb73-4045-9cae-1dc53982b651")),
            new DevExpress.XtraBars.BarManagerCategory("Umgebung", new System.Guid("4c902fab-5049-4ec9-90d3-cb0fb56f3721")),
            new DevExpress.XtraBars.BarManagerCategory("DatenAktionen", new System.Guid("3c418ff5-f665-428c-8b80-4cc9eb2d0fab")),
            new DevExpress.XtraBars.BarManagerCategory("Applikation", new System.Guid("9ec11ee0-feae-4c61-873e-35b480457c67")),
            new DevExpress.XtraBars.BarManagerCategory("Stammdaten", new System.Guid("9d13ae48-315b-4ae0-87cc-9023269dc20c")),
            new DevExpress.XtraBars.BarManagerCategory("System", new System.Guid("742d14bb-513d-4702-a624-9d45c3304d2e")),
            new DevExpress.XtraBars.BarManagerCategory("Favoriten", new System.Guid("119bb9a4-692d-4205-a4b0-08111963aaaf"))});
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.DockControls.Add(this.barDockControl1);
            this.barManager.Form = this;
            this.barManager.Images = this.imgToolbar;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.subDatei,
            this.btnAnmelden,
            this.btnAbmelden,
            this.btnBeenden,
            this.subBearbeiten,
            this.subAnwendung,
            this.btnBenutzerverwaltung,
            this.subSystem,
            this.subFavoriten,
            this.btnFavoriteSpeichern,
            this.btnFavoriteSpeichernUnter,
            this.btnFavoritenVerwaltung,
            this.btnResetSuchkriterien,
            this.btnKonfiguration,
            this.subFenster,
            this.subHilfe,
            this.btnStartlayoutfestlegen,
            this.btnCloseAll,
            this.itmMdiChildrenList,
            this.btnNew,
            this.btnSave,
            this.btnUndo,
            this.btnDelete,
            this.btnCut,
            this.btnCopy,
            this.btnPaste,
            this.btnFind,
            this.btnPrint,
            this.edtUmgebung,
            this.btnFallNavigator,
            this.btnFirst,
            this.btnPrevious,
            this.btnNext,
            this.btnLast,
            this.btnRefresh,
            this.btnFensterEinstLoeschen,
            this.btnModulKonfiguration,
            this.btnTeamViewer,
            this.btnJira,
            this.btnBusinessDesigner,
            this.btnDataEditor,
            this.subSpracheWechseln,
            this.listSprachen,
            this.btnIndex,
            this.btnInhalt,
            this.btnAbout,
            this.subLinks,
            this.btnDummyLink,
            this.barSearchEditItem,
            this.btnPasswortAendern});
            this.barManager.MainMenu = this.barMainMenu;
            this.barManager.MaxItemId = 166;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.barItemSearchTextEdit});
            this.barManager.ShowFullMenus = true;
            // 
            // barMainMenu
            // 
            this.barMainMenu.BarName = "Hauptmenu";
            this.barMainMenu.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barMainMenu.DockCol = 0;
            this.barMainMenu.DockRow = 0;
            this.barMainMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMainMenu.FloatLocation = new System.Drawing.Point(319, 251);
            this.barMainMenu.FloatSize = new System.Drawing.Size(377, 25);
            this.barMainMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.subDatei),
            new DevExpress.XtraBars.LinkPersistInfo(this.subBearbeiten),
            new DevExpress.XtraBars.LinkPersistInfo(this.subAnwendung),
            new DevExpress.XtraBars.LinkPersistInfo(this.subSystem),
            new DevExpress.XtraBars.LinkPersistInfo(this.subFavoriten),
            new DevExpress.XtraBars.LinkPersistInfo(this.subLinks),
            new DevExpress.XtraBars.LinkPersistInfo(this.subFenster),
            new DevExpress.XtraBars.LinkPersistInfo(this.subHilfe)});
            this.barMainMenu.OptionsBar.AllowQuickCustomization = false;
            this.barMainMenu.OptionsBar.DisableClose = true;
            this.barMainMenu.OptionsBar.DisableCustomization = true;
            this.barMainMenu.OptionsBar.MultiLine = true;
            this.barMainMenu.OptionsBar.UseWholeRow = true;
            this.barMainMenu.Text = "Hauptmenu";
            // 
            // subDatei
            // 
            this.subDatei.Caption = "Datei";
            this.subDatei.CategoryGuid = new System.Guid("61769853-87e6-453e-9e67-1c9208529091");
            this.subDatei.Id = 0;
            this.subDatei.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAnmelden, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAbmelden),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPasswortAendern),
            new DevExpress.XtraBars.LinkPersistInfo(this.subSpracheWechseln),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBeenden, true)});
            this.subDatei.Name = "subDatei";
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "Drucken";
            this.btnPrint.CategoryGuid = new System.Guid("3c418ff5-f665-428c-8b80-4cc9eb2d0fab");
            this.btnPrint.Hint = "Drucken";
            this.btnPrint.Id = 41;
            this.btnPrint.ImageIndex = 24;
            this.btnPrint.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnAnmelden
            // 
            this.btnAnmelden.Caption = "Anmelden";
            this.btnAnmelden.CategoryGuid = new System.Guid("50af31d0-eb73-4045-9cae-1dc53982b651");
            this.btnAnmelden.Id = 2;
            this.btnAnmelden.Name = "btnAnmelden";
            this.btnAnmelden.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnmelden_ItemClick);
            // 
            // btnAbmelden
            // 
            this.btnAbmelden.Caption = "Abmelden";
            this.btnAbmelden.CategoryGuid = new System.Guid("50af31d0-eb73-4045-9cae-1dc53982b651");
            this.btnAbmelden.Id = 3;
            this.btnAbmelden.Name = "btnAbmelden";
            this.btnAbmelden.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAbmelden_ItemClick);
            // 
            // btnPasswortAendern
            // 
            this.btnPasswortAendern.Caption = "Passwort ändern";
            this.btnPasswortAendern.Id = 165;
            this.btnPasswortAendern.Name = "btnPasswortAendern";
            this.btnPasswortAendern.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPasswortAendern_ItemClick);
            // 
            // subSpracheWechseln
            // 
            this.subSpracheWechseln.Caption = "Sprache wechseln";
            this.subSpracheWechseln.CategoryGuid = new System.Guid("50af31d0-eb73-4045-9cae-1dc53982b651");
            this.subSpracheWechseln.Id = 119;
            this.subSpracheWechseln.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.listSprachen)});
            this.subSpracheWechseln.Name = "subSpracheWechseln";
            // 
            // listSprachen
            // 
            this.listSprachen.Caption = "alleSprachen";
            this.listSprachen.CategoryGuid = new System.Guid("50af31d0-eb73-4045-9cae-1dc53982b651");
            this.listSprachen.Id = 120;
            this.listSprachen.Name = "listSprachen";
            this.listSprachen.ShowChecks = true;
            this.listSprachen.ListItemClick += new DevExpress.XtraBars.ListItemClickEventHandler(this.listSprachen_ListItemClick);
            // 
            // btnBeenden
            // 
            this.btnBeenden.Caption = "Beenden";
            this.btnBeenden.CategoryGuid = new System.Guid("50af31d0-eb73-4045-9cae-1dc53982b651");
            this.btnBeenden.Id = 4;
            this.btnBeenden.Name = "btnBeenden";
            this.btnBeenden.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBeenden_ItemClick);
            // 
            // subBearbeiten
            // 
            this.subBearbeiten.Caption = "Bearbeiten";
            this.subBearbeiten.CategoryGuid = new System.Guid("61769853-87e6-453e-9e67-1c9208529091");
            this.subBearbeiten.Id = 45;
            this.subBearbeiten.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUndo),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFirst, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrevious),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNext),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLast),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCut, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCopy),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPaste),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFind, true)});
            this.subBearbeiten.Name = "subBearbeiten";
            // 
            // btnNew
            // 
            this.btnNew.Caption = "Neu";
            this.btnNew.CategoryGuid = new System.Guid("3c418ff5-f665-428c-8b80-4cc9eb2d0fab");
            this.btnNew.Hint = "Neu";
            this.btnNew.Id = 33;
            this.btnNew.ImageIndex = 1;
            this.btnNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnNew.Name = "btnNew";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Speichern";
            this.btnSave.CategoryGuid = new System.Guid("3c418ff5-f665-428c-8b80-4cc9eb2d0fab");
            this.btnSave.Hint = "Speichern";
            this.btnSave.Id = 34;
            this.btnSave.ImageIndex = 2;
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSave_ItemClick);
            // 
            // btnUndo
            // 
            this.btnUndo.Caption = "Rückgängig";
            this.btnUndo.CategoryGuid = new System.Guid("3c418ff5-f665-428c-8b80-4cc9eb2d0fab");
            this.btnUndo.Hint = "Rückgängig";
            this.btnUndo.Id = 35;
            this.btnUndo.ImageIndex = 3;
            this.btnUndo.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F6);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUndo_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Löschen";
            this.btnDelete.CategoryGuid = new System.Guid("3c418ff5-f665-428c-8b80-4cc9eb2d0fab");
            this.btnDelete.Hint = "Löschen";
            this.btnDelete.Id = 36;
            this.btnDelete.ImageIndex = 4;
            this.btnDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnFirst
            // 
            this.btnFirst.Caption = "Anfang";
            this.btnFirst.CategoryGuid = new System.Guid("3c418ff5-f665-428c-8b80-4cc9eb2d0fab");
            this.btnFirst.Hint = "Anfang";
            this.btnFirst.Id = 72;
            this.btnFirst.ImageIndex = 10;
            this.btnFirst.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Home));
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFirst_ItemClick);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Caption = "Vorheriger";
            this.btnPrevious.CategoryGuid = new System.Guid("3c418ff5-f665-428c-8b80-4cc9eb2d0fab");
            this.btnPrevious.Hint = "Vorheriger";
            this.btnPrevious.Id = 73;
            this.btnPrevious.ImageIndex = 11;
            this.btnPrevious.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up));
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrevious_ItemClick);
            // 
            // btnNext
            // 
            this.btnNext.Caption = "Nächster";
            this.btnNext.CategoryGuid = new System.Guid("3c418ff5-f665-428c-8b80-4cc9eb2d0fab");
            this.btnNext.Hint = "Nächster";
            this.btnNext.Id = 74;
            this.btnNext.ImageIndex = 13;
            this.btnNext.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down));
            this.btnNext.Name = "btnNext";
            this.btnNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNext_ItemClick);
            // 
            // btnLast
            // 
            this.btnLast.Caption = "Ende";
            this.btnLast.CategoryGuid = new System.Guid("3c418ff5-f665-428c-8b80-4cc9eb2d0fab");
            this.btnLast.Hint = "Ende";
            this.btnLast.Id = 75;
            this.btnLast.ImageIndex = 15;
            this.btnLast.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.End));
            this.btnLast.Name = "btnLast";
            this.btnLast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLast_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Aktualisieren";
            this.btnRefresh.CategoryGuid = new System.Guid("3c418ff5-f665-428c-8b80-4cc9eb2d0fab");
            this.btnRefresh.Hint = "Aktualisieren";
            this.btnRefresh.Id = 76;
            this.btnRefresh.ImageIndex = 22;
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnCut
            // 
            this.btnCut.Caption = "Ausschneiden   Ctrl+X";
            this.btnCut.CategoryGuid = new System.Guid("3c418ff5-f665-428c-8b80-4cc9eb2d0fab");
            this.btnCut.Hint = "Ausschneiden";
            this.btnCut.Id = 37;
            this.btnCut.ImageIndex = 18;
            this.btnCut.Name = "btnCut";
            this.btnCut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCut_ItemClick);
            // 
            // btnCopy
            // 
            this.btnCopy.Caption = "Kopieren           Ctrl+C";
            this.btnCopy.CategoryGuid = new System.Guid("3c418ff5-f665-428c-8b80-4cc9eb2d0fab");
            this.btnCopy.Hint = "Kopieren";
            this.btnCopy.Id = 38;
            this.btnCopy.ImageIndex = 19;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCopy_ItemClick);
            // 
            // btnPaste
            // 
            this.btnPaste.Caption = "Einfügen           Ctrl+V";
            this.btnPaste.CategoryGuid = new System.Guid("3c418ff5-f665-428c-8b80-4cc9eb2d0fab");
            this.btnPaste.Hint = "Einfügen";
            this.btnPaste.Id = 39;
            this.btnPaste.ImageIndex = 21;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPaste_ItemClick);
            // 
            // btnFind
            // 
            this.btnFind.Caption = "Suchen";
            this.btnFind.CategoryGuid = new System.Guid("3c418ff5-f665-428c-8b80-4cc9eb2d0fab");
            this.btnFind.Hint = "Suchen";
            this.btnFind.Id = 40;
            this.btnFind.ImageIndex = 23;
            this.btnFind.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.btnFind.Name = "btnFind";
            this.btnFind.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFinde_ItemClick);
            // 
            // subAnwendung
            // 
            this.subAnwendung.Caption = "Anwendung";
            this.subAnwendung.CategoryGuid = new System.Guid("61769853-87e6-453e-9e67-1c9208529091");
            this.subAnwendung.Id = 5;
            this.subAnwendung.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFallNavigator)});
            this.subAnwendung.Name = "subAnwendung";
            // 
            // btnFallNavigator
            // 
            this.btnFallNavigator.Caption = "Fall-Navigator";
            this.btnFallNavigator.CategoryGuid = new System.Guid("9ec11ee0-feae-4c61-873e-35b480457c67");
            this.btnFallNavigator.Hint = "Fall-Navigator";
            this.btnFallNavigator.Id = 62;
            this.btnFallNavigator.ImageIndex = 30;
            this.btnFallNavigator.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1));
            this.btnFallNavigator.Name = "btnFallNavigator";
            this.btnFallNavigator.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFallNavigator_ItemClick);
            // 
            // subSystem
            // 
            this.subSystem.Caption = "System";
            this.subSystem.CategoryGuid = new System.Guid("61769853-87e6-453e-9e67-1c9208529091");
            this.subSystem.Id = 12;
            this.subSystem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBenutzerverwaltung),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnKonfiguration, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnModulKonfiguration),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBusinessDesigner, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDataEditor)});
            this.subSystem.Name = "subSystem";
            // 
            // btnBenutzerverwaltung
            // 
            this.btnBenutzerverwaltung.Caption = "Benutzerverwaltung";
            this.btnBenutzerverwaltung.CategoryGuid = new System.Guid("742d14bb-513d-4702-a624-9d45c3304d2e");
            this.btnBenutzerverwaltung.Id = 14;
            this.btnBenutzerverwaltung.ImageIndex = 134;
            this.btnBenutzerverwaltung.Name = "btnBenutzerverwaltung";
            this.btnBenutzerverwaltung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBenutzerverwaltung_ItemClick);
            // 
            // btnKonfiguration
            // 
            this.btnKonfiguration.Caption = "Konfiguration";
            this.btnKonfiguration.CategoryGuid = new System.Guid("742d14bb-513d-4702-a624-9d45c3304d2e");
            this.btnKonfiguration.Id = 16;
            this.btnKonfiguration.Name = "btnKonfiguration";
            this.btnKonfiguration.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKonfiguration_ItemClick);
            // 
            // btnModulKonfiguration
            // 
            this.btnModulKonfiguration.Caption = "Modul Konfiguration";
            this.btnModulKonfiguration.CategoryGuid = new System.Guid("742d14bb-513d-4702-a624-9d45c3304d2e");
            this.btnModulKonfiguration.Id = 105;
            this.btnModulKonfiguration.Name = "btnModulKonfiguration";
            this.btnModulKonfiguration.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModulKonfiguration_ItemClick);
            // 
            // btnBusinessDesigner
            // 
            this.btnBusinessDesigner.Caption = "Business Designer";
            this.btnBusinessDesigner.CategoryGuid = new System.Guid("742d14bb-513d-4702-a624-9d45c3304d2e");
            this.btnBusinessDesigner.Id = 117;
            this.btnBusinessDesigner.Name = "btnBusinessDesigner";
            this.btnBusinessDesigner.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBusinessDesigner_ItemClick);
            // 
            // btnDataEditor
            // 
            this.btnDataEditor.Caption = "Dateneditor";
            this.btnDataEditor.CategoryGuid = new System.Guid("742d14bb-513d-4702-a624-9d45c3304d2e");
            this.btnDataEditor.Id = 80;
            this.btnDataEditor.ImageIndex = 91;
            this.btnDataEditor.Name = "btnDataEditor";
            this.btnDataEditor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDataEditor_ItemClick);
            // 
            // subFavoriten
            // 
            this.subFavoriten.Caption = "Favoriten";
            this.subFavoriten.CategoryGuid = new System.Guid("7dff5e51-d890-43fc-8084-a262dd078b2c");
            this.subFavoriten.Id = 1245;
            this.subFavoriten.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFavoriteSpeichern),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFavoriteSpeichernUnter),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFavoritenVerwaltung),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnResetSuchkriterien)});
            this.subFavoriten.Name = "subFavoriten";
            this.subFavoriten.Popup += new System.EventHandler(this.subFavoriten_Popup);
            // 
            // btnFavoriteSpeichern
            // 
            this.btnFavoriteSpeichern.Caption = "&Speichern";
            this.btnFavoriteSpeichern.CategoryGuid = new System.Guid("21775d6f-9c00-4284-97f6-f0d6314b05a8");
            this.btnFavoriteSpeichern.Id = 1285;
            this.btnFavoriteSpeichern.ImageIndex = 2;
            this.btnFavoriteSpeichern.Name = "btnFavoriteSpeichern";
            this.btnFavoriteSpeichern.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFavoriteSpeichern_ItemClick);
            // 
            // btnFavoriteSpeichernUnter
            // 
            this.btnFavoriteSpeichernUnter.Caption = "Speichere aktuelle Suche unter...";
            this.btnFavoriteSpeichernUnter.CategoryGuid = new System.Guid("206d5388-67a3-452c-bfcc-9fe0512a0604");
            this.btnFavoriteSpeichernUnter.Id = 1246;
            this.btnFavoriteSpeichernUnter.ImageIndex = 2;
            this.btnFavoriteSpeichernUnter.Name = "btnFavoriteSpeichernUnter";
            this.btnFavoriteSpeichernUnter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFavoriteSpeichernUnter_ItemClick);
            // 
            // btnFavoritenVerwaltung
            // 
            this.btnFavoritenVerwaltung.Caption = "&Favoritenverwaltung...";
            this.btnFavoritenVerwaltung.CategoryGuid = new System.Guid("206d5388-67a3-452c-bfcc-9fe0512a0604");
            this.btnFavoritenVerwaltung.Id = 1247;
            this.btnFavoritenVerwaltung.Name = "btnFavoritenVerwaltung";
            this.btnFavoritenVerwaltung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFavoritenVerwaltung_ItemClick);
            // 
            // btnResetSuchkriterien
            // 
            this.btnResetSuchkriterien.Caption = "&Reset Suckriterien/Kolonnen";
            this.btnResetSuchkriterien.CategoryGuid = new System.Guid("206d5388-67a3-452c-bfcc-9fe0512a0604");
            this.btnResetSuchkriterien.Id = 1248;
            this.btnResetSuchkriterien.Name = "btnResetSuchkriterien";
            this.btnResetSuchkriterien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnResetSuchkriterien_ItemClick);
            // 
            // subLinks
            // 
            this.subLinks.Caption = "Links";
            this.subLinks.Id = 153;
            this.subLinks.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDummyLink)});
            this.subLinks.Name = "subLinks";
            this.subLinks.Popup += new System.EventHandler(this.subLinks_Popup);
            // 
            // btnDummyLink
            // 
            this.btnDummyLink.Caption = "DummyLink";
            this.btnDummyLink.Id = 154;
            this.btnDummyLink.Name = "btnDummyLink";
            // 
            // subFenster
            // 
            this.subFenster.Caption = "Fenster";
            this.subFenster.CategoryGuid = new System.Guid("61769853-87e6-453e-9e67-1c9208529091");
            this.subFenster.Id = 17;
            this.subFenster.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCloseAll),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnStartlayoutfestlegen),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFensterEinstLoeschen),
            new DevExpress.XtraBars.LinkPersistInfo(this.itmMdiChildrenList, true)});
            this.subFenster.Name = "subFenster";
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.Caption = "&Alle schliessen";
            this.btnCloseAll.CategoryGuid = new System.Guid("50af31d0-eb73-4045-9cae-1dc53982b651");
            this.btnCloseAll.Id = 26;
            this.btnCloseAll.ImageIndex = 163;
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCloseAll_ItemClick);
            // 
            // btnStartlayoutfestlegen
            // 
            this.btnStartlayoutfestlegen.Caption = "Startlayout festlegen";
            this.btnStartlayoutfestlegen.CategoryGuid = new System.Guid("50af31d0-eb73-4045-9cae-1dc53982b651");
            this.btnStartlayoutfestlegen.Id = 18;
            this.btnStartlayoutfestlegen.ImageIndex = 184;
            this.btnStartlayoutfestlegen.Name = "btnStartlayoutfestlegen";
            this.btnStartlayoutfestlegen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStartlayoutfestlegen_ItemClick);
            // 
            // btnFensterEinstLoeschen
            // 
            this.btnFensterEinstLoeschen.Caption = "Alle Fenstereinstellungen löschen";
            this.btnFensterEinstLoeschen.CategoryGuid = new System.Guid("50af31d0-eb73-4045-9cae-1dc53982b651");
            this.btnFensterEinstLoeschen.Id = 98;
            this.btnFensterEinstLoeschen.ImageIndex = 209;
            this.btnFensterEinstLoeschen.Name = "btnFensterEinstLoeschen";
            this.btnFensterEinstLoeschen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFensterEinstLoeschen_ItemClick);
            // 
            // itmMdiChildrenList
            // 
            this.itmMdiChildrenList.Caption = "MdiList";
            this.itmMdiChildrenList.CategoryGuid = new System.Guid("50af31d0-eb73-4045-9cae-1dc53982b651");
            this.itmMdiChildrenList.Id = 25;
            this.itmMdiChildrenList.Name = "itmMdiChildrenList";
            // 
            // subHilfe
            // 
            this.subHilfe.Caption = "Hilfe";
            this.subHilfe.CategoryGuid = new System.Guid("61769853-87e6-453e-9e67-1c9208529091");
            this.subHilfe.Id = 19;
            this.subHilfe.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnInhalt),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnIndex),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnTeamViewer, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnJira),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAbout, true)});
            this.subHilfe.Name = "subHilfe";
            // 
            // btnInhalt
            // 
            this.btnInhalt.Caption = "Inhalt";
            this.btnInhalt.CategoryGuid = new System.Guid("50af31d0-eb73-4045-9cae-1dc53982b651");
            this.btnInhalt.Id = 20;
            this.btnInhalt.Name = "btnInhalt";
            this.btnInhalt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInhalt_ItemClick);
            // 
            // btnIndex
            // 
            this.btnIndex.Caption = "Index";
            this.btnIndex.CategoryGuid = new System.Guid("50af31d0-eb73-4045-9cae-1dc53982b651");
            this.btnIndex.Id = 21;
            this.btnIndex.Name = "btnIndex";
            this.btnIndex.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnIndex_ItemClick);
            // 
            // btnTeamViewer
            // 
            this.btnTeamViewer.Caption = "TeamViewer starten (Fernwartung)";
            this.btnTeamViewer.CategoryGuid = new System.Guid("50af31d0-eb73-4045-9cae-1dc53982b651");
            this.btnTeamViewer.ConfigKey = "System\\GUI\\Hilfe\\TeamViewer";
            this.btnTeamViewer.Id = 110;
            this.btnTeamViewer.ImageIndex = 33;
            this.btnTeamViewer.Name = "btnTeamViewer";
            this.btnTeamViewer.URL = "http://www.teamviewer.com/link/?url=505374&id=1197933998";
            this.btnTeamViewer.UseOwnFont = true;
            // 
            // btnJira
            // 
            this.btnJira.Caption = "JIRA starten (Wartungsprotokoll)";
            this.btnJira.CategoryGuid = new System.Guid("50af31d0-eb73-4045-9cae-1dc53982b651");
            this.btnJira.ConfigKey = "System\\GUI\\Hilfe\\Jira";
            this.btnJira.Id = 111;
            this.btnJira.ImageIndex = 32;
            this.btnJira.Name = "btnJira";
            this.btnJira.URL = "https://jira.bedag.ch/";
            this.btnJira.UseOwnFont = true;
            // 
            // btnAbout
            // 
            this.btnAbout.Caption = "Über";
            this.btnAbout.CategoryGuid = new System.Guid("50af31d0-eb73-4045-9cae-1dc53982b651");
            this.btnAbout.Id = 22;
            this.btnAbout.ImageIndex = 31;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAbout_ItemClick);
            // 
            // barApplikation
            // 
            this.barApplikation.BarName = "Applikation";
            this.barApplikation.DockCol = 0;
            this.barApplikation.DockRow = 1;
            this.barApplikation.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barApplikation.FloatLocation = new System.Drawing.Point(185, 253);
            this.barApplikation.FloatSize = new System.Drawing.Size(120, 24);
            this.barApplikation.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFallNavigator)});
            this.barApplikation.OptionsBar.AllowQuickCustomization = false;
            this.barApplikation.OptionsBar.DisableCustomization = true;
            this.barApplikation.Text = "Applikation";
            // 
            // barUmgebung
            // 
            this.barUmgebung.BarName = "Umgebung";
            this.barUmgebung.DockCol = 2;
            this.barUmgebung.DockRow = 1;
            this.barUmgebung.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barUmgebung.FloatLocation = new System.Drawing.Point(489, 209);
            this.barUmgebung.FloatSize = new System.Drawing.Size(186, 19);
            this.barUmgebung.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.edtUmgebung, "", false, true, true, 240)});
            this.barUmgebung.Offset = 733;
            this.barUmgebung.OptionsBar.AllowQuickCustomization = false;
            this.barUmgebung.Text = "Umgebung";
            // 
            // edtUmgebung
            // 
            this.edtUmgebung.Caption = "Umgebung";
            this.edtUmgebung.CategoryGuid = new System.Guid("4c902fab-5049-4ec9-90d3-cb0fb56f3721");
            this.edtUmgebung.Edit = this.repositoryItemPickImage1;
            this.edtUmgebung.Id = 60;
            this.edtUmgebung.Name = "edtUmgebung";
            this.edtUmgebung.Width = 180;
            // 
            // repositoryItemPickImage1
            // 
            this.repositoryItemPickImage1.AllowFocused = false;
            this.repositoryItemPickImage1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.repositoryItemPickImage1.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.repositoryItemPickImage1.Appearance.Options.UseBackColor = true;
            this.repositoryItemPickImage1.Appearance.Options.UseFont = true;
            this.repositoryItemPickImage1.AutoComplete = false;
            this.repositoryItemPickImage1.AutoHeight = false;
            this.repositoryItemPickImage1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemPickImage1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemPickImage1.Name = "repositoryItemPickImage1";
            this.repositoryItemPickImage1.ReadOnly = true;
            this.repositoryItemPickImage1.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.repositoryItemPickImage1.ShowPopupShadow = false;
            this.repositoryItemPickImage1.SmallImages = this.imgUmgebung;
            // 
            // imgUmgebung
            // 
            this.imgUmgebung.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgUmgebung.ImageStream")));
            this.imgUmgebung.TransparentColor = System.Drawing.Color.Transparent;
            this.imgUmgebung.Images.SetKeyName(0, "");
            this.imgUmgebung.Images.SetKeyName(1, "");
            this.imgUmgebung.Images.SetKeyName(2, "");
            this.imgUmgebung.Images.SetKeyName(3, "");
            // 
            // barSearch
            // 
            this.barSearch.BarName = "Suche";
            this.barSearch.DockCol = 1;
            this.barSearch.DockRow = 1;
            this.barSearch.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barSearch.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.barSearchEditItem, "", false, true, true, 121)});
            this.barSearch.Text = "Suche";
            this.barSearch.Visible = false;
            // 
            // barSearchEditItem
            // 
            this.barSearchEditItem.Caption = "Suche";
            this.barSearchEditItem.Edit = this.barItemSearchTextEdit;
            this.barSearchEditItem.Id = 164;
            this.barSearchEditItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F));
            this.barSearchEditItem.Name = "barSearchEditItem";
            this.barSearchEditItem.Width = 120;
            // 
            // barItemSearchTextEdit
            // 
            this.barItemSearchTextEdit.AutoHeight = false;
            this.barItemSearchTextEdit.Name = "barItemSearchTextEdit";
            this.barItemSearchTextEdit.NullText = "Suche";
            this.barItemSearchTextEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.barItemSearchTextEdit_KeyDown);
            this.barItemSearchTextEdit.Leave += new System.EventHandler(this.barItemSearchTextEdit_Leave);
            // 
            // imgToolbar
            // 
            this.imgToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgToolbar.ImageStream")));
            this.imgToolbar.TransparentColor = System.Drawing.Color.Transparent;
            this.imgToolbar.Images.SetKeyName(0, "");
            this.imgToolbar.Images.SetKeyName(1, "");
            this.imgToolbar.Images.SetKeyName(2, "");
            this.imgToolbar.Images.SetKeyName(3, "");
            this.imgToolbar.Images.SetKeyName(4, "");
            this.imgToolbar.Images.SetKeyName(5, "");
            this.imgToolbar.Images.SetKeyName(6, "");
            this.imgToolbar.Images.SetKeyName(7, "");
            this.imgToolbar.Images.SetKeyName(8, "");
            this.imgToolbar.Images.SetKeyName(9, "");
            this.imgToolbar.Images.SetKeyName(10, "");
            this.imgToolbar.Images.SetKeyName(11, "");
            this.imgToolbar.Images.SetKeyName(12, "");
            this.imgToolbar.Images.SetKeyName(13, "");
            this.imgToolbar.Images.SetKeyName(14, "");
            this.imgToolbar.Images.SetKeyName(15, "");
            this.imgToolbar.Images.SetKeyName(16, "");
            this.imgToolbar.Images.SetKeyName(17, "");
            this.imgToolbar.Images.SetKeyName(18, "");
            this.imgToolbar.Images.SetKeyName(19, "");
            this.imgToolbar.Images.SetKeyName(20, "");
            this.imgToolbar.Images.SetKeyName(21, "");
            this.imgToolbar.Images.SetKeyName(22, "");
            this.imgToolbar.Images.SetKeyName(23, "");
            this.imgToolbar.Images.SetKeyName(24, "");
            this.imgToolbar.Images.SetKeyName(25, "");
            this.imgToolbar.Images.SetKeyName(26, "");
            this.imgToolbar.Images.SetKeyName(27, "");
            this.imgToolbar.Images.SetKeyName(28, "");
            this.imgToolbar.Images.SetKeyName(29, "");
            this.imgToolbar.Images.SetKeyName(30, "");
            this.imgToolbar.Images.SetKeyName(31, "About.ico");
            this.imgToolbar.Images.SetKeyName(32, "Mantis.ico");
            this.imgToolbar.Images.SetKeyName(33, "ico_teamviewer.jpg");
            // 
            // BarEditEnvironment
            // 
            this.BarEditEnvironment.AutoFillWidth = true;
            this.BarEditEnvironment.Caption = "Umgebung";
            this.BarEditEnvironment.Edit = null;
            this.BarEditEnvironment.Id = 23;
            this.BarEditEnvironment.Name = "BarEditEnvironment";
            // 
            // barControler
            // 
            // 
            // 
            // 
            this.barControler.Controller.AppearancesBar.Bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.barControler.Controller.AppearancesBar.Bar.Options.UseBackColor = true;
            this.barControler.Controller.AppearancesBar.Dock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.barControler.Controller.AppearancesBar.Dock.Options.UseBackColor = true;
            this.barControler.Controller.AppearancesBar.MainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.barControler.Controller.AppearancesBar.MainMenu.Options.UseBackColor = true;
            this.barControler.Controller.AppearancesBar.StatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.barControler.Controller.AppearancesBar.StatusBar.Options.UseBackColor = true;
            this.barControler.Controller.AppearancesBar.SubMenu.Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.barControler.Controller.AppearancesBar.SubMenu.Menu.Options.UseBackColor = true;
            this.barControler.Controller.AppearancesBar.SubMenu.SideStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.barControler.Controller.AppearancesBar.SubMenu.SideStrip.Options.UseBackColor = true;
            this.barControler.Controller.AppearancesBar.SubMenu.SideStripNonRecent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.barControler.Controller.AppearancesBar.SubMenu.SideStripNonRecent.Options.UseBackColor = true;
            this.barControler.Controller.PaintStyleName = "OfficeXP";
            // 
            // FrmMain
            // 
            this.ClientSize = new System.Drawing.Size(1012, 734);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPickImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barItemSearchTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barControler.Controller)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Bar barMainMenu;
        private DevExpress.XtraBars.BarSubItem subDatei;
        private DevExpress.XtraBars.BarButtonItem btnAnmelden;
        private DevExpress.XtraBars.BarButtonItem btnBeenden;
        private DevExpress.XtraBars.BarSubItem subAnwendung;
        private DevExpress.XtraBars.BarSubItem subSystem;
        private DevExpress.XtraBars.BarSubItem subFavoriten;
        private DevExpress.XtraBars.BarButtonItem btnFavoriteSpeichernUnter;
        private DevExpress.XtraBars.BarButtonItem btnFavoriteSpeichern;
        private DevExpress.XtraBars.BarButtonItem btnFavoritenVerwaltung;
        private DevExpress.XtraBars.BarButtonItem btnResetSuchkriterien;
        private DevExpress.XtraBars.BarButtonItem btnKonfiguration;
        private DevExpress.XtraBars.BarSubItem subFenster;
        private DevExpress.XtraBars.BarButtonItem btnStartlayoutfestlegen;
        private DevExpress.XtraBars.BarSubItem subHilfe;
        private DevExpress.XtraBars.BarButtonItem btnInhalt;
        private DevExpress.XtraBars.BarButtonItem btnIndex;
        private DevExpress.XtraBars.BarEditItem BarEditEnvironment;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraBars.BarButtonItem btnCloseAll;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnCut;
        private DevExpress.XtraBars.BarButtonItem btnCopy;
        private DevExpress.XtraBars.BarButtonItem btnPaste;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemPickImage1;
        private DevExpress.XtraBars.BarSubItem subBearbeiten;
        private DevExpress.XtraBars.BarEditItem edtUmgebung;
        private DevExpress.XtraBars.Bar barApplikation;
        private DevExpress.XtraBars.BarButtonItem btnFallNavigator;
        private DevExpress.XtraBars.BarButtonItem btnFirst;
        private DevExpress.XtraBars.BarButtonItem btnPrevious;
        private DevExpress.XtraBars.BarButtonItem btnNext;
        private DevExpress.XtraBars.BarButtonItem btnLast;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.Bar barUmgebung;
        private DevExpress.XtraBars.BarButtonItem btnDataEditor;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnFind;
        private DevExpress.XtraBars.DefaultBarAndDockingController barControler;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarButtonItem btnModulKonfiguration;
        private KiSS4.Gui.KissHyperlinkBarButtonItem btnTeamViewer;
        private KiSS4.Gui.KissHyperlinkBarButtonItem btnJira;
        private DevExpress.XtraBars.BarButtonItem btnBenutzerverwaltung;
        private DevExpress.XtraBars.BarSubItem subSpracheWechseln;
        private DevExpress.XtraBars.BarListItem listSprachen;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarButtonItem btnFensterEinstLoeschen;
        private DevExpress.XtraBars.BarButtonItem btnAbout;
        private DevExpress.XtraBars.BarButtonItem btnAbmelden;
        private KiSS4.Gui.KissBarMdiChildrenListItem itmMdiChildrenList;
        private DevExpress.XtraBars.BarButtonItem btnBusinessDesigner;
        private System.Windows.Forms.ImageList imgUmgebung;
        private DevExpress.XtraBars.BarSubItem subLinks;
        private DevExpress.XtraBars.BarButtonItem btnDummyLink;
        private System.Windows.Forms.ImageList imgToolbar;
        private DevExpress.XtraBars.Bar barSearch;
        private DevExpress.XtraBars.BarEditItem barSearchEditItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit barItemSearchTextEdit;
        private DevExpress.XtraBars.BarButtonItem btnPasswortAendern;
    }
}
