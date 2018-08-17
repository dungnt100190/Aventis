using DevExpress.XtraNavBar;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using System;
using System.Data;
using System.Windows.Forms;

namespace KiSS4.Fibu
{
    public partial class CtlFibu : KissNavBarUserControl
    {
        private const string CLASSNAME = "CtlFibu";

        #region Fields

        #region Private Static Fields

        private static SqlQuery _qryFbTeamMitglied;

        #endregion

        #region Private Fields

        private CtlFibuBankPost _fibuBankPostControl;
        private CtlFibuBelegNr _fibuBelegNrControl;
        private CtlFibuBilanzErfolg _fibuBilanzErfolg;
        private CtlFibuBuchungCode _fibuBuchungCodeControl;
        private CtlFibuBuchung _fibuBuchungControl;
        private CtlFibuBuchungskreis _fibuBuchungskreisControl;
        private CtlFibuDauerauftrag _fibuDauerauftragControl;
        private CtlFibuDTAZahlungsLauf _fibuDtaJournalControl;
        private CtlFibuDTATransfer _fibuDtaTransferControl;
        private CtlFibuDTAZugang _fibuDtaZugangControl;
        private CtlFibuIbanGenerieren _fibuIbanGenerierenControl;
        private CtlFibuJournal _fibuJournalControl;
        private CtlFibuKontoblatt _fibuKontoblattControl;
        private CtlFibuKonto _fibuKontoControl;
        private CtlFibuKreditor _fibuKreditorControl;
        private CtlFibuPeriode _fibuPeriodeControl;
        private CtlFibuTeam _fibuTeamControl;
        private bool _firstTimeActivated = true;

        #endregion

        #endregion

        #region Constructors

        public CtlFibu()
        {
            InitializeComponent();

            navBarGroupBearbeiten.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarGroupBearbeitenCaption", "Bearbeiten");
            navBarItemBuchen.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemBuchenCaption", "Buchen");
            navBarItemKontenplan.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemKontenplanCaption", "Kontenplan");
            navBarItemPerioden.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemPeriodenCaption", "Perioden");

            navBarGroupAuswerten.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarGroupAuswertenCaption", "Auswerten");
            navBarItemKontoblatt.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemKontoblattCaption", "Kontoblatt");
            navBarItemJournal.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemJournalCaption", "Journal");
            navBarItemBilanzErfolg.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemBilanzErfolgCaption", "Bilanz / Erfolg");

            navBarGroupStammdaten.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarGroupStammdatenCaption", "Stammdaten");
            navBarItemBuchungCodes.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemBuchungCodesCaption", "Buchungscodes");
            navBarItemDauerauftraege.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemDauerauftraegeCaption", "Daueraufträge");
            navBarItemBuchungskreise.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemBuchungskreise", "Buchungskreise");
            navBarItemKreditoren.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemKreditorenCaption", "Kreditoren");
            navBarItemBankPost.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemBankPostCaption", "Banken / Post");
            navBarItemBelegNr.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemBelegNrCaption", "Belegnummern");
            navBarItemTeams.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemTeamsCaption", "Teams");
            navBarItemIbanGenerieren.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemIbanGenerierenCaption", "IBAN generien");

            navBarGroupEBanking.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarGroupEBankingCaption", "e-Banking");
            navBarItemDTAJournal.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemDTAJournalCaption", "e-Zahlungslauf");
            navBarItemDTATransfer.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemDTATransferCaption", "e-Journal");
            navBarItemDTAZugang.Caption = KissMsg.GetMLMessage(CLASSNAME, "navBarItemDTAZugangCaption", "e-Zugang");
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
                if (components != null)
                {
                    components.Dispose();
                }

                if (_fibuBankPostControl != null) _fibuBankPostControl.Dispose();
                if (_fibuBelegNrControl != null) _fibuBelegNrControl.Dispose();
                if (_fibuBilanzErfolg != null) _fibuBilanzErfolg.Dispose();
                if (_fibuBuchungControl != null) _fibuBuchungControl.Dispose();
                if (_fibuBuchungCodeControl != null) _fibuBuchungCodeControl.Dispose();
                if (_fibuDauerauftragControl != null) _fibuDauerauftragControl.Dispose();
                if (_fibuDtaTransferControl != null) _fibuDtaTransferControl.Dispose();
                if (_fibuDtaZugangControl != null) _fibuDtaZugangControl.Dispose();
                if (_fibuDtaJournalControl != null) _fibuDtaJournalControl.Dispose();
                if (_fibuJournalControl != null) _fibuJournalControl.Dispose();
                if (_fibuKontoControl != null) _fibuKontoControl.Dispose();
                if (_fibuKontoblattControl != null) _fibuKontoblattControl.Dispose();
                if (_fibuKreditorControl != null) _fibuKreditorControl.Dispose();
                if (_fibuPeriodeControl != null) _fibuPeriodeControl.Dispose();
                if (_fibuTeamControl != null) _fibuTeamControl.Dispose();
                if (_fibuBuchungskreisControl != null) _fibuBuchungskreisControl.Dispose();
                if (_fibuIbanGenerierenControl != null) _fibuIbanGenerierenControl.Dispose();
            }

            var parent = Parent as KissForm;
            if (parent == null)
            {
                OnParentClosing();
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Properties

        public CtlFibuBuchung FibuBuchungControl
        {
            get { return _fibuBuchungControl; }
        }

        public CtlFibuKreditor FibuKreditorControl
        {
            get { return _fibuKreditorControl ?? (_fibuKreditorControl = new CtlFibuKreditor()); }
        }

        #endregion

        #region EventHandlers

        private void CtlFibu_Load(object sender, EventArgs e)
        {
            /*
            this.Width = 1005;
            this.Height = 650;
            this.Left   = 5;
            this.Top    = 10;
            */

            //Teamlist + Bereiche
            SetQryFbTeamMitgleid();

            //Enable BarItems

            //Bearbeiten
            navBarItemBuchen.Enabled = DBUtil.UserHasRight("CtlFibuBuchung");
            navBarItemKontenplan.Enabled = DBUtil.UserHasRight("CtlFibuKonto");
            navBarItemPerioden.Enabled = DBUtil.UserHasRight("CtlFibuPeriode");
            ShowParentGroup(navBarGroupBearbeiten);

            //Auswerten
            navBarItemKontoblatt.Enabled = DBUtil.UserHasRight("CtlFibuKontoblatt");
            navBarItemJournal.Enabled = DBUtil.UserHasRight("CtlFibuJournal");
            navBarItemBilanzErfolg.Enabled = DBUtil.UserHasRight("CtlFibuBilanzErfolg");
            ShowParentGroup(navBarGroupAuswerten);

            //Stammdaten
            navBarItemBuchungCodes.Enabled = DBUtil.UserHasRight("CtlFibuBuchungCode");
            navBarItemDauerauftraege.Enabled = DBUtil.UserHasRight("CtlFibuDauerauftrag");
            navBarItemBuchungskreise.Enabled = DBUtil.UserHasRight("CtlFibuBuchungskreis");
            navBarItemKreditoren.Enabled = DBUtil.UserHasRight("CtlFibuKreditor");
            navBarItemBankPost.Enabled = DBUtil.UserHasRight("CtlFibuBankPost");
            navBarItemBelegNr.Enabled = DBUtil.UserHasRight("CtlFibuBelegNr");
            navBarItemTeams.Enabled = DBUtil.UserHasRight("CtlFibuTeam");
            navBarItemIbanGenerieren.Enabled = DBUtil.UserHasRight("CtlFibuIbanGenerieren");
            ShowParentGroup(navBarGroupStammdaten);

            //e-Banking
            navBarItemDTAJournal.Enabled = DBUtil.UserHasRight("CtlFibuDTAZahlungslauf");
            navBarItemDTATransfer.Enabled = DBUtil.UserHasRight("CtlFibuDTATransfer");
            navBarItemDTAZugang.Enabled = DBUtil.UserHasRight("CtlFibuDTAZugang");
            ShowParentGroup(navBarGroupEBanking);

            var parent = Parent as KissForm;
            if (parent == null)
            {
                OnParentActivated();
            }
        }

        private void CtlFibu_SaveData(object sender, EventArgs e)
        {
            if (ActiveControl is IKissDataNavigator)
            {
                ((IKissDataNavigator)ActiveControl).SaveData();
            }
        }

        private void navBarFibu_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ShowSubMask(e.Link);
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static bool DepotBereich(int fbTeamID)
        {
            if (Session.User.IsUserAdmin)
            {
                return true;
            }

            foreach (DataRow row in _qryFbTeamMitglied.DataTable.Rows)
            {
                if ((int)row["FbTeamID"] == fbTeamID)
                {
                    return (bool)row["DepotBereich"];
                }
            }

            return false;
        }

        public static string FbTeamIDList()
        {
            string list = "";
            foreach (DataRow row in _qryFbTeamMitglied.DataTable.Rows)
            {
                if (list != "")
                {
                    list += ",";
                }

                list += row["FbTeamID"].ToString();
            }

            return list;
        }

        public static object GetFbTeamIDOfUser()
        {
            if (_qryFbTeamMitglied.Count == 1)
            {
                return (int)_qryFbTeamMitglied.DataTable.Rows[0]["FbTeamID"];
            }

            return DBNull.Value;
        }

        public static bool StandardBereich(int fbTeamID)
        {
            if (Session.User.IsUserAdmin)
            {
                return true;
            }

            foreach (DataRow row in _qryFbTeamMitglied.DataTable.Rows)
            {
                if ((int)row["FbTeamID"] == fbTeamID)
                {
                    return (bool)row["StandardBereich"];
                }
            }

            return false;
        }

        public static bool UserIsMemberOfTeam(int fbTeamID)
        {
            foreach (DataRow row in _qryFbTeamMitglied.DataTable.Rows)
            {
                if ((int)row["FbTeamID"] == fbTeamID) return true;
            }

            return false;
        }

        #endregion

        #region Public Methods

        public static void SetQryFbTeamMitgleid()
        {
            _qryFbTeamMitglied = DBUtil.OpenSQL(@"SELECT TMI.*,
                                                         TEA.Name
                                                  FROM FbTeamMitglied TMI
                                                    INNER JOIN FbTeam TEA ON TEA.FbTeamID = TMI.FbTeamID
                                                  WHERE UserID = {0}", Session.User.UserID);
        }

        public override string GetContextName()
        {
            return "VmFibu";
        }

        public void OnParentActivated()
        {
            if (_firstTimeActivated)
            {
                _firstTimeActivated = false;
                ApplicationFacade.DoEvents();

                if (DBUtil.UserHasRight("CtlFibuBuchung"))
                {
                    ShowSubMask(navBarGroupBearbeiten.ItemLinks[0]); //Buchen
                }
                else if (DBUtil.UserHasRight("CtlFibuBilanzErfolg"))
                {
                    ShowSubMask(navBarGroupAuswerten.ItemLinks[2]); //Bilanz / Erfolg
                }
            }
        }

        public bool OnParentClosing()
        {
            //check pending changes in fibuBuchungControl
            //pending changes in other submasks already saved through KissForm/KissChildForm

            if (_fibuBuchungControl != null && DetailControl != _fibuBuchungControl)
            {
                SqlQuery qry = _fibuBuchungControl.ActiveSQLQuery;
                if (qry.Count > 0 && (qry.RowModified))
                {
                    //make CtlFibuBuchung visible
                    panDetail.Controls.Clear();
                    panDetail.Controls.Add(_fibuBuchungControl);
                    _fibuBuchungControl.Visible = true;

                    picTitle.Image = navBarGroupBearbeiten.ItemLinks[0].GetImage(); //Buchen
                    lblTitle.Text = navBarGroupBearbeiten.ItemLinks[0].Caption;

                    if (!qry.Post())
                    {
                        return !KissMsg.ShowQuestion("CtlFibu",
                                "FensterSchliessenOhneSpeichern",
                                "Fenster trotz der nicht gespeicherten Buchung schliessen ?");
                    }
                }
            }

            return false;
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary parameters)
        {
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (parameters["Action"] as string)
            {
                case "OpenItem":
                    ShowSubMask(parameters["SubMask"].ToString());
                    FormController.SendMessage(DetailControl, parameters);
                    return true;
            }

            return false;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Used to detect when F11 key comes from BelegLeser. Special Keys like F11 are only catched in KeyDownEvent
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.B && ActiveControl == _fibuBuchungControl)
            {
                _fibuBuchungControl.ChangeBuchungKreditorTab(0);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.K && ActiveControl == _fibuBuchungControl)
            {
                _fibuBuchungControl.ChangeBuchungKreditorTab(1);
                e.Handled = true;
            }

            base.OnKeyDown(e);
        }

        #endregion

        #region Private Methods

        private void ShowParentGroup(NavBarGroup group)
        {
            foreach (NavBarItemLink link in group.ItemLinks)
            {
                if (link.Enabled)
                {
                    group.Visible = true;
                    return;
                }
            }
            group.Visible = false;
        }

        private void ShowSubMask(string className)
        {
            NavBarItem item = null;

            switch (className)
            {
                case "CtlFibuBankPost":
                    item = navBarItemBankPost;
                    break;

                case "CtlFibuBelegNr":
                    item = navBarItemBelegNr;
                    break;

                case "CtlFibuBilanzErfolg":
                    item = navBarItemBilanzErfolg;
                    break;

                case "CtlFibuBuchung":
                    item = navBarItemBuchen;
                    break;

                case "CtlFibuBuchungCode":
                    item = navBarItemBuchungCodes;
                    break;

                case "CtlFibuBuchungskreis":
                    item = navBarItemBuchungskreise;
                    break;

                case "CtlFibuDauerauftrag":
                    item = navBarItemDauerauftraege;
                    break;

                case "CtlFibuDTAJournal":
                    item = navBarItemDTAJournal;
                    break;

                case "CtlFibuDTATransfer":
                    item = navBarItemDTATransfer;
                    break;

                case "CtlFibuDTAZugang":
                    item = navBarItemDTAZugang;
                    break;

                case "CtlFibuIbanGenerieren":
                    item = navBarItemIbanGenerieren;
                    break;

                case "CtlFibuJournal":
                    item = navBarItemJournal;
                    break;

                case "CtlFibuKonto":
                    item = navBarItemKontenplan;
                    break;

                case "CtlFibuKontoblatt":
                    item = navBarItemKontoblatt;
                    break;

                case "CtlFibuKreditor":
                    item = navBarItemKreditoren;
                    break;

                case "CtlFibuPeriode":
                    item = navBarItemPerioden;
                    break;

                case "CtlFibuTeam":
                    item = navBarItemTeams;
                    break;
            }

            if (item != null && item.Links.Count > 0)
            {
                ShowSubMask(item.Links[0]);
            }
        }

        private void ShowSubMask(NavBarItemLink link)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                KissUserControl newSubMask = null;

                picTitle.Image = link.GetImage();
                lblTitle.Text = link.Caption;

                picTitle.Visible = true;
                lblTitle.Visible = true;

                if (link.Item == navBarItemBankPost)
                {
                    if (_fibuBankPostControl == null)
                    {
                        _fibuBankPostControl = new CtlFibuBankPost();
                    }
                    newSubMask = _fibuBankPostControl;
                }
                else if (link.Item == navBarItemBilanzErfolg)
                {
                    if (_fibuBilanzErfolg == null)
                    {
                        _fibuBilanzErfolg = new CtlFibuBilanzErfolg();
                    }
                    else
                    {
                        if (DetailControl != _fibuBilanzErfolg)
                        {
                            _fibuBilanzErfolg.RefreshBilanzErfolg();
                        }
                    }

                    newSubMask = _fibuBilanzErfolg;
                }
                else if (link.Item == navBarItemBelegNr)
                {
                    if (_fibuBelegNrControl == null)
                    {
                        _fibuBelegNrControl = new CtlFibuBelegNr();
                    }

                    newSubMask = _fibuBelegNrControl;
                }
                else if (link.Item == navBarItemBuchen)
                {
                    if (_fibuBuchungControl == null)
                    {
                        _fibuBuchungControl = new CtlFibuBuchung();
                    }

                    newSubMask = _fibuBuchungControl;
                }
                else if (link.Item == navBarItemBuchungCodes)
                {
                    if (_fibuBuchungCodeControl == null)
                    {
                        _fibuBuchungCodeControl = new CtlFibuBuchungCode();
                    }

                    newSubMask = _fibuBuchungCodeControl;
                }
                else if (link.Item == navBarItemDauerauftraege)
                {
                    if (_fibuDauerauftragControl == null)
                    {
                        _fibuDauerauftragControl = new CtlFibuDauerauftrag();
                    }

                    newSubMask = _fibuDauerauftragControl;
                }
                else if (link.Item == navBarItemDTATransfer)
                {
                    if (_fibuDtaTransferControl == null)
                    {
                        _fibuDtaTransferControl = new CtlFibuDTATransfer();
                    }

                    newSubMask = _fibuDtaTransferControl;
                }
                else if (link.Item == navBarItemDTAZugang)
                {
                    if (_fibuDtaZugangControl == null)
                    {
                        _fibuDtaZugangControl = new CtlFibuDTAZugang();
                    }

                    newSubMask = _fibuDtaZugangControl;
                }
                else if (link.Item == navBarItemDTAJournal)
                {
                    if (_fibuDtaJournalControl == null)
                    {
                        _fibuDtaJournalControl = new CtlFibuDTAZahlungsLauf();
                    }

                    newSubMask = _fibuDtaJournalControl;
                }
                else if (link.Item == navBarItemJournal)
                {
                    if (_fibuJournalControl == null)
                    {
                        _fibuJournalControl = new CtlFibuJournal();
                    }

                    newSubMask = _fibuJournalControl;
                }
                else if (link.Item == navBarItemKontenplan)
                {
                    if (_fibuKontoControl == null)
                    {
                        _fibuKontoControl = new CtlFibuKonto();
                    }

                    newSubMask = _fibuKontoControl;
                }
                else if (link.Item == navBarItemKontoblatt)
                {
                    if (_fibuKontoblattControl == null)
                    {
                        _fibuKontoblattControl = new CtlFibuKontoblatt();
                    }

                    newSubMask = _fibuKontoblattControl;
                }
                else if (link.Item == navBarItemKreditoren)
                {
                    if (_fibuKreditorControl == null)
                    {
                        _fibuKreditorControl = new CtlFibuKreditor();
                    }

                    newSubMask = _fibuKreditorControl;
                }
                else if (link.Item == navBarItemPerioden)
                {
                    if (_fibuPeriodeControl == null)
                    {
                        _fibuPeriodeControl = new CtlFibuPeriode();
                    }

                    newSubMask = _fibuPeriodeControl;
                }
                else if (link.Item == navBarItemTeams)
                {
                    if (_fibuTeamControl == null)
                    {
                        _fibuTeamControl = new CtlFibuTeam();
                    }

                    newSubMask = _fibuTeamControl;
                }
                else if (link.Item == navBarItemBuchungskreise)
                {
                    if (_fibuBuchungskreisControl == null)
                    {
                        _fibuBuchungskreisControl = new CtlFibuBuchungskreis();
                    }

                    newSubMask = _fibuBuchungskreisControl;
                }
                else if (link.Item == navBarItemIbanGenerieren)
                {
                    if (_fibuIbanGenerierenControl == null)
                    {
                        _fibuIbanGenerierenControl = new CtlFibuIbanGenerieren();
                    }

                    newSubMask = _fibuIbanGenerierenControl;
                }

                ActivateUserControl(newSubMask, panDetail);
            }
            catch (Exception e)
            {
                KissMsg.ShowError(
                    "CtlFibu",
                    "FehlerMaskeWechseln",
                    "Ein Fehler ist beim Maske wechseln im Fibubereich auftreten",
                    e.Message, e);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        #endregion

        #endregion
    }
}