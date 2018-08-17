using System;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.BL;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Fallfuehrung.PI;
using KiSS4.Gui;
using SharpLibrary.WinControls;

namespace KiSS4.Gesuchverwaltung
{
    public partial class CtlGvGesuchverwaltung : KissSearchUserControl
    {
        public const string QRY_GVGESUCH_ABGESCHLOSSENESGESUCHDURCHIKSE_USER = "AbgeschlossenesGesuchdurchIKS_User";
        public const string QRY_GVGESUCH_AUTOR = "Autor";
        public const string QRY_GVGESUCH_BETRAG_BEANTRAGT = "BetragBeantragt";
        public const string QRY_GVGESUCH_ERFASSTESGESUCHGEPRUEFTDURCHIKS_USER = "ErfasstesGesuchgeprueftdurchIKS_User";
        public const string QRY_GVGESUCH_FONDS_HINWEIS = "FondsHinweis";
        public const string QRY_GVGESUCH_IST_FONDS_EXTERN = "IstFondsExtern";
        public const string QRY_GVGESUCH_IST_FONDS_FLB = "IstFondsFLB";
        public const string QRY_GVGESUCH_KLIENT = "Klient";
        public const string QRY_GVGESUCH_TAGE = "Tage";
        public const string QRY_GVGESUCH_TOTAL_FONDS_AUSBEZAHLT = "TotalFondsAusbezahlt";
        public const string QRY_GVGESUCH_TOTAL_FONDS_BEWILLIGT = "TotalFondsBewilligt";
        public const string SPEZIALRECHT_AUSWAHLKGS_UNEINGESCHRAENKT = "CtlGvGesuchverwaltung_AuswahlKGSUneingeschraenkt";

        private const string CLASSNAME = "CtlGvGesuchverwaltung";

        private int? _baPersonId;
        private string _baPersonNameVorname;
        private CtlGvAbklaerendeStelle _ctlGvAbklaerendeStelle;
        private CtlGvAntrag _ctlGvAntrag;
        private CtlGvAuflagen _ctlGvAuflagen;
        private CtlGvAuszahlung _ctlGvAuszahlung;
        private CtlGvBegruendung _ctlGvBegruendung;
        private CtlGvBeilagenDokumente _ctlGvBeilagenDokumente;
        private CtlGvBewilligung _ctlGvBewilligung;
        private CtlGvGesuch _ctlGvGesuch;
        private bool _hasKompetenzstufe0;
        private bool _hasKompetenzstufe1;
        private bool _hasKompetenzstufe2;

        public CtlGvGesuchverwaltung()
        {
            InitializeComponent();
        }

        public int? GvGesuchId
        {
            get
            {
                var id = qryGvGesuch[DBO.GvGesuch.GvGesuchID];

                if (!DBUtil.IsEmpty(id))
                {
                    return (int)id;
                }

                return null;
            }
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return qryGvGesuch[DBO.GvGesuch.BaPersonID];

                case "GVGESUCHID":
                    return qryGvGesuch[DBO.GvGesuch.GvGesuchID];
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int? baPersonId)
        {
            picTitel.Image = titleImage;
            lblTitel.Text = titleName;
            _baPersonId = baPersonId;
        }

        public override bool OnSaveData()
        {
            if (base.OnSaveData())
            {
                UpdateTabs();
                UpdateNameLabel();
                return true;
            }

            return false;
        }

        public override bool ReceiveMessage(HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            if (param.Contains("ActiveSQLQuery.Find"))
            {
                NewSearch();

                // Suche initialisieren: Nur aktive und in Fallführungen des aktuellen Benutzers
                chkSucheAbgeschlosseneAusschliessen.Checked = true;
                ctlSucheKGSKostenstelleSAR.InitControlForNewSearch();

                OnSearch();

                return base.ReceiveMessage(param);
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "JumpToGesuch":

                    if (OnSaveData())
                    {
                        int gvGesuchId;
                        int.TryParse(param["GvGesuchID"].ToString(), out gvGesuchId);

                        if (gvGesuchId != int.MinValue)
                        {
                            return JumpToGesuch(gvGesuchId);
                        }
                    }

                    break;
            }

            // did not understand message
            return false;
        }

        public override void Translate()
        {
            // apply translation
            base.Translate();

            // setup titles
            tpgListe.Title = KissMsg.GetMLMessage(CLASSNAME, "TpgListeGesuch_v01", "Gesuch");
        }

        /// <summary>
        /// EditMode auf Child-Control zu setzen
        /// <remarks>wird in CtlFaModulTree verwendet></remarks>
        /// </summary>
        internal void SetEditMode()
        {
            if (_ctlGvGesuch != null)
            {
                _ctlGvGesuch.SetEditMode();
                EnableDisableButtons();
            }
        }

        protected void CalculateTotalAusbezahltAusFLBFonds(bool enforceCalculation)
        {
            var totalAusbezahlt = qryGvGesuch[QRY_GVGESUCH_TOTAL_FONDS_AUSBEZAHLT] as decimal?;

            //Wurde Betrag bereits berechnet?
            if (!totalAusbezahlt.HasValue || enforceCalculation)
            {
                totalAusbezahlt = (decimal)DBUtil.ExecuteScalarSQL(@"
                    SELECT ISNULL(
                       (SELECT SUM(BUC.Betrag)
                        FROM dbo.GvGesuch GGE WITH (READUNCOMMITTED)
                          INNER JOIN dbo.GvFonds GFD ON GFD.GvFondsID = GGE.GvFondsID
                          INNER JOIN dbo.GvAuszahlungPosition GAP ON GAP.GvGesuchID = GGE.GvGesuchID
                          INNER JOIN dbo.KbBuchungKostenart BKO ON BKO.GvAuszahlungPositionID = GAP.GvAuszahlungPositionID
                          INNER JOIN dbo.KbBuchung BUC ON BUC.KbBuchungID = BKO.KbBuchungID
                        WHERE GGE.BaPersonID = {0}
                          AND GFD.GvFondsTypCode = 1 --1: intern
                          AND GFD.KbZahlungskontoID IS NOT NULL --FLB
                          AND YEAR(BUC.BelegDatum) = YEAR(GETDATE())
                        )
                    ,0.0)", qryGvGesuch[DBO.GvGesuch.BaPersonID]);

                bool rowModifiedBefore = qryGvGesuch.RowModified;
                //Berechneter Wert im Query ablegen (als Cache)
                qryGvGesuch[QRY_GVGESUCH_TOTAL_FONDS_AUSBEZAHLT] = totalAusbezahlt;
                if (!rowModifiedBefore
                    && qryGvGesuch.Row != null
                    && qryGvGesuch.Row.RowState != DataRowState.Added)
                {
                    //das Query war vor dem Ablegen des Totalbetrags nicht modified -> AcceptChanges()
                    qryGvGesuch.RowModified = false;
                    qryGvGesuch.Row.AcceptChanges();
                }
            }
        }

        protected void CalculateTotalBewilligtAusFLBFonds(bool enforceCalculation)
        {
            var totalBewilligt = qryGvGesuch[QRY_GVGESUCH_TOTAL_FONDS_BEWILLIGT] as decimal?;

            //Wurde Betrag bereits berechnet?
            if (!totalBewilligt.HasValue || enforceCalculation)
            {
                totalBewilligt = (decimal)DBUtil.ExecuteScalarSQL(@"
                    SELECT ISNULL(
                      (SELECT SUM(GGE.BetragBewilligt)
                       FROM dbo.GvGesuch GGE WITH (READUNCOMMITTED)
                         INNER JOIN dbo.GvFonds GFD ON GFD.GvFondsID = GGE.GvFondsID
                       WHERE GGE.BaPersonID = {0}
                         AND GFD.GvFondsTypCode = 1 --1: intern
                         AND GFD.KbZahlungskontoID IS NOT NULL --FLB
                         AND YEAR(GGE.GesuchsDatum) = YEAR(GETDATE())
                      ), 0.0);", qryGvGesuch[DBO.GvGesuch.BaPersonID]);

                bool rowModifiedBefore = qryGvGesuch.RowModified;
                //Berechneter Wert im Query ablegen (als Cache)
                qryGvGesuch[QRY_GVGESUCH_TOTAL_FONDS_BEWILLIGT] = totalBewilligt;
                if (!rowModifiedBefore
                    && qryGvGesuch.Row != null
                    && qryGvGesuch.Row.RowState != DataRowState.Added)
                {
                    //das Query war vor dem Ablegen des Totalbetrags nicht modified -> AcceptChanges()
                    qryGvGesuch.RowModified = false;
                    qryGvGesuch.Row.AcceptChanges();
                }
            }
        }

        protected override void NewSearch()
        {
            // replace search parameters:
            // @LanguageCode = {0},
            var parameters = new object[]
            {
                Session.User.LanguageCode
            };
            kissSearch.SelectParameters = parameters;

            var initKgsKstSarFields = true;
            if (_baPersonId.HasValue)
            {
                edtSucheKlient.EditValue = _baPersonNameVorname;
                edtSucheKlient.LookupID = _baPersonId.Value;

                //Wenn BaPerson fixiert ist, sollen die KGS/KST/SAR Felder leer sein
                initKgsKstSarFields = false;
            }

            var setKgs = initKgsKstSarFields;
            var setKst = initKgsKstSarFields;
            var setUser = initKgsKstSarFields;

            if (_hasKompetenzstufe2)
            {
                setKgs = false;
                setKst = false;
                setUser = false;
            }
            else if (_hasKompetenzstufe1 || _hasKompetenzstufe0)
            {
                setKst = false;
                setUser = false;
            }

            ctlSucheKGSKostenstelleSAR.InitControlForNewSearch(setKgs, setKst, setUser);

            UpdateTabs(true);

            base.NewSearch();
        }

        private void _ctlGvAntrag_BeantragterBetragChanged(object sender, EventArgs e)
        {
            qryGvGesuch[QRY_GVGESUCH_BETRAG_BEANTRAGT] = _ctlGvAntrag.BeantragterBetrag;
        }

        private void _ctlGvGesuch_Search(object sender, EventArgs e)
        {
            OnNewSearch();
        }

        private void btnDokumenteGV_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(string.Format("{0}", qryGvGesuch[DBO.GvGesuch.BaPersonID])))
            {
                FormController.OpenForm(
                    "FrmFall",
                    "Action",
                    "JumpToPath",
                    "BaPersonID", qryGvGesuch[DBO.GvGesuch.BaPersonID],
                    "ModulID", 2,
                    "TreeNodeID", string.Format("{0}/{1}", typeof(CtlFaDokumentation).Name, typeof(CtlFaFinanzgesuche).Name));
            }
        }

        private void btnGesuchVerlauf_Click(object sender, EventArgs e)
        {
            var dlg = new DlgGvGesuchVerlauf(qryGvGesuch[DBO.GvGesuch.GvGesuchID] as int? ?? 0);
            dlg.ShowDialog(this);
        }

        private void btnPersonalien_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(string.Format("{0}", qryGvGesuch[DBO.GvGesuch.BaPersonID])))
            {
                FormController.OpenForm(
                    "FrmFall",
                    "Action",
                    "JumpToPath",
                    "BaPersonID", qryGvGesuch[DBO.GvGesuch.BaPersonID],
                    "ModulID", 1,
                    "TreeNodeID", string.Format("P{0}", qryGvGesuch[DBO.GvGesuch.BaPersonID]),
                    "Tab", "tpgPersonalien");
            }
        }

        private void CtlGvGesuchverwaltung_Load(object sender, EventArgs e)
        {
            SetTabAuthorisation();

            // Spezialrechte
            _hasKompetenzstufe0 = DBUtil.UserHasRight("CtlGvGesuchverwaltung_Kompetenzstufe0");
            _hasKompetenzstufe1 = DBUtil.UserHasRight("CtlGvGesuchverwaltung_Kompetenzstufe1");
            _hasKompetenzstufe2 = DBUtil.UserHasRight("CtlGvGesuchverwaltung_Kompetenzstufe2");

            // add CtlGvGesuch control
            _ctlGvGesuch = new CtlGvGesuch(qryGvGesuch, _hasKompetenzstufe0, _hasKompetenzstufe1, _hasKompetenzstufe2, _baPersonId);
            panGesuch.Controls.Add(_ctlGvGesuch);
            _ctlGvGesuch.Dock = DockStyle.Fill;
            SetActiveDataNavigator(_ctlGvGesuch);

            //Support F3 if Gesuch-Register is active (switch to Search-Mask)
            _ctlGvGesuch.Search += _ctlGvGesuch_Search;

            SetupFieldNames();

            if (_baPersonId.HasValue)
            {
                _baPersonNameVorname = BaPersonService.GetBaPersonNameVornameByBaPersonId(_baPersonId.Value);

                //Wenn _baPersonID gesetzt ist, dann macht eine Suche nach
                //Klient, KGS, Kostenstelle und SAR gar keinen Sinn mehr
                edtSucheKlient.EditMode = EditModeType.ReadOnly;
                ctlSucheKGSKostenstelleSAR.EditMode = EditModeType.ReadOnly;
            }

            EnableDisableButtons();

            //make sure, the search is initialized
            NewSearch();

            // Query für Grid (alle Fonds anzeigen)
            var qryGvFonds = DBUtil.OpenSQL(@"
                SELECT GvFondsID,
                       NameKurz
                FROM dbo.GvFonds WITH(READUNCOMMITTED);");
            colFonds.ColumnEdit = grdGesuch.GetLOVLookUpEdit(qryGvFonds, DBO.GvFonds.GvFondsID, DBO.GvFonds.NameKurz);

            //automatically run new search if person is set
            if (_baPersonId.HasValue)
            {
                tabControlSearch.SelectTab(tpgListe);
                qryGvGesuch.Last();

                // Hack fürs TotalSummary. Wird im _AfterFill wieder gesetzt
                grdGesuch.DataSource = null;
                grdGesuch.DataSource = qryGvGesuch;
            }
            else
            {
                // Hack fürs TotalSummary. Wird im _AfterFill wieder gesetzt
                grdGesuch.DataSource = null;
            }

            UpdateTabs();

            // Query für Suche (nur bestimmte Fonds anzeigen)
            var qrySearchGvFonds = DBUtil.OpenSQL(@"
                 -- UserId
                DECLARE @UserId INT;
                SET @UserId = {0};

                SELECT [GvFondsID] = NULL,
                       [NameKurz] = '',
                       [GvFondsTypCode] = NULL

                UNION

                SELECT DISTINCT
                  FND.GvFondsID,
                  FND.NameKurz,
                  FND.GvFondsTypCode
                FROM dbo.GvFonds                   FND    WITH (READUNCOMMITTED)
                  INNER JOIN dbo.GvFonds_XOrgUnit  FOU    WITH (READUNCOMMITTED) ON FOU.GvFondsID = FND.GvFondsID
                  -- Kantonale Geschäftsstellen
                  LEFT JOIN dbo.XOrgUnit           ORG_KG WITH (READUNCOMMITTED) ON ORG_KG.OrgUnitID = FOU.OrgUnitID
                  -- Fonds Schweiz (Hauptsitz)
                  LEFT JOIN dbo.XOrgUnit           ORG_CH WITH (READUNCOMMITTED) ON ORG_CH.OrgUnitID = FOU.OrgUnitId AND ORG_CH.OEItemTypCode = 1
                WHERE ORG_KG.Mandantennummer = dbo.fnOrgUnitOfUserMandantenNr(@UserId)
                   OR ORG_CH.OrgUnitID IS NOT NULL
                ORDER BY NameKurz;",
                Session.User.UserID);
            edtSucheFonds.LoadQuery(qrySearchGvFonds, DBO.GvFonds.GvFondsID, DBO.GvFonds.NameKurz);

            var qryGvPositionsart = DBUtil.OpenSQL(@"
                SELECT [GvPositionsartID] = NULL,
                       [Bezeichnung] = ''
                UNION
                SELECT GPA.GvPositionsartID,
                       [Bezeichnung] = KOA.KontoNr + ' ' + ISNULL(LAN.Text, GPA.Bezeichnung)
                FROM dbo.GvPositionsart      GPA WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BgKostenart KOA WITH (READUNCOMMITTED) ON KOA.BgKostenartID = GPA.BgKostenartID
                  LEFT  JOIN dbo.XLangText   LAN WITH (READUNCOMMITTED) ON LAN.TID = GPA.BezeichnungTID
                                                                       AND LAN.LanguageCode = {0}
                ORDER BY [Bezeichnung];", Session.User.LanguageCode);
            edtSucheKostenart.LoadQuery(qryGvPositionsart, DBO.GvPositionsart.GvPositionsartID, "Bezeichnung");

            Utils.SetStatusImageRepository(repStatusImg, "GvStatus", Session.User.LanguageCode);

            SetLookupEdit_Status();
        }

        private bool DialogKlient(object sender, UserModifiedFldEventArgs e, KissButtonEdit edt)
        {
            try
            {
                // check if data can be altered
                if (edt.EditMode == EditModeType.ReadOnly)
                {
                    // do nothing
                    return true;
                }

                // validate edt
                if (edt != edtSucheKlient)
                {
                    // do nothing
                    return false;
                }

                // prepare search string
                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edt.EditValue))
                {
                    // prepare for database search
                    searchString = edt.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        // user
                        edt.EditValue = null;
                        edt.LookupID = null;

                        // done
                        return true;
                    }
                }

                // search user (only within KGS and those who are not yet in use within this Einsatzvereinbarung)
                KissLookupDialog dlg = new KissLookupDialog();

                e.Cancel = !dlg.SearchData(String.Format(@"
                    SELECT PRS.*
                    FROM dbo.fnDlgPersonSuchenKGS({0}, 1, N'{1}') PRS
                    WHERE PRS.Name LIKE N'{1}%';", Session.User.UserID, searchString), searchString, e.ButtonClicked, null, null, null);

                if (!e.Cancel)
                {
                    // user
                    edt.EditValue = dlg["Name"];
                    edt.LookupID = dlg["BaPersonID$"];

                    // success
                    return true;
                }

                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(CLASSNAME, "ErrorIKissUserModified", "Fehler bei der Verarbeitung.", ex);
                return false;
            }
        }

        private void edtSucheKlient_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogKlient(sender, e, edtSucheKlient);
        }

        private void EnableDisableButtons()
        {
            var enableJumpButton = !qryGvGesuch.IsEmpty && (_hasKompetenzstufe0 || _hasKompetenzstufe1 || _hasKompetenzstufe2);
            btnPersonalien.Enabled = enableJumpButton;
            btnDokumenteGV.Enabled = enableJumpButton;
            btnGesuchVerlauf.Visible = !qryGvGesuch.IsEmpty && DBUtil.UserHasRight(typeof(DlgGvGesuchVerlauf).Name);
        }

        /// <summary>
        /// Jump to Gesuch given as a parameter
        /// </summary>
        /// <param name="gvGesuchId"></param>
        /// <returns>true if success</returns>
        private bool JumpToGesuch(int gvGesuchId)
        {
            NewSearch();

            //edtSucheKlient in NewSearch() schon initialisiert
            //ctlSucheKGSKostenstelleSAR.InitControlForNewSearch(false, false, false); in NewSearch() schon initialisiert
            edtSucheGesuchID.EditValue = null;
            edtSucheStatus.EditValue = null;
            edtSucheFonds.EditValue = null;
            edtSucheGesuchsDatumVon.EditValue = null;
            edtSucheGesuchsDatumBis.EditValue = null;
            edtSucheKostenart.EditValue = null;
            chkSucheAbgeschlosseneAusschliessen.Checked = false;
            chkSucheNurExterneGesuche.Checked = false;
            chkSucheKompetenzKanton.EditValue = false;
            chkSucheKompetenzBsl.EditValue = false;
            chkSucheGesuchAnExterneFonds.EditValue = false;

            RunSearch();
            tabControlSearch.SelectTab(tpgListe);
            return qryGvGesuch.Find(string.Format("GvGesuchID = {0}", gvGesuchId));
        }

        private void qryGvGesuch_AfterDelete(object sender, EventArgs e)
        {
            EnableDisableButtons();
        }

        private void qryGvGesuch_AfterFill(object sender, EventArgs e)
        {
            // Hack fürs TotalSummary. Wird im _AfterFill wieder gesetzt
            if (!_baPersonId.HasValue)
            {
                grdGesuch.DataSource = qryGvGesuch;
            }

            EnableDisableButtons();
            grvGesuch.BestFitColumns();
        }

        private void qryGvGesuch_AfterPost(object sender, EventArgs e)
        {
            EnableDisableButtons();
        }

        private void qryGvGesuch_BeforePost(object sender, EventArgs e)
        {
            bool isErfasstesGesuchgeprueftamNotEmpty = Utils.ConvertToDateTime(qryGvGesuch[DBO.GvGesuch.ErfasstesGesuchgeprueftam], DateTime.MinValue) != DateTime.MinValue;
            bool isAbgeschlossenesGesuchgeprueftamNotEmpty = Utils.ConvertToDateTime(qryGvGesuch[DBO.GvGesuch.AbgeschlossenesGesuchgeprueftam], DateTime.MinValue) != DateTime.MinValue;

            qryGvGesuch[DBO.GvGesuch.ErfasstesGesuchgeprueftdurchIKS_UserID] = isErfasstesGesuchgeprueftamNotEmpty ? (object)Session.User.UserID : DBNull.Value;
            qryGvGesuch[QRY_GVGESUCH_ERFASSTESGESUCHGEPRUEFTDURCHIKS_USER] = isErfasstesGesuchgeprueftamNotEmpty ? Session.User.LastFirstName : string.Empty;
            qryGvGesuch[DBO.GvGesuch.ErfasstesGesuchBesprechen] = isErfasstesGesuchgeprueftamNotEmpty ? qryGvGesuch[DBO.GvGesuch.ErfasstesGesuchBesprechen] : false;
            qryGvGesuch[DBO.GvGesuch.ErfasstesGesuchBemerkung] = isErfasstesGesuchgeprueftamNotEmpty ? qryGvGesuch[DBO.GvGesuch.ErfasstesGesuchBemerkung] : string.Empty;

            qryGvGesuch[DBO.GvGesuch.AbgeschlossenesGesuchdurchIKS_UserID] = isAbgeschlossenesGesuchgeprueftamNotEmpty ? (object)Session.User.UserID : DBNull.Value;
            qryGvGesuch[QRY_GVGESUCH_ABGESCHLOSSENESGESUCHDURCHIKSE_USER] = isAbgeschlossenesGesuchgeprueftamNotEmpty ? Session.User.LastFirstName : string.Empty;
            qryGvGesuch[DBO.GvGesuch.AbgeschlossenesGesuchBesprechen] = isAbgeschlossenesGesuchgeprueftamNotEmpty ? qryGvGesuch[DBO.GvGesuch.AbgeschlossenesGesuchBesprechen] : false;
            qryGvGesuch[DBO.GvGesuch.AbgeschlossenesGesuchBemerkung] = isAbgeschlossenesGesuchgeprueftamNotEmpty ? qryGvGesuch[DBO.GvGesuch.AbgeschlossenesGesuchBemerkung] : string.Empty;
        }

        private void qryGvGesuch_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == DBO.GvGesuch.BaPersonID)
            {
                //calculate TotalAusbezahlt
                CalculateTotalAusbezahltAusFLBFonds(true);
                //calculate TotalBewilligt
                CalculateTotalBewilligtAusFLBFonds(true);
            }
        }

        private void qryGvGesuch_PositionChanged(object sender, EventArgs e)
        {
            //calculate TotalAusbezahlt
            CalculateTotalAusbezahltAusFLBFonds(false);
            //calculate TotalBewilligt
            CalculateTotalBewilligtAusFLBFonds(false);

            _ctlGvGesuch.LoadData();

            UpdateTabs();
            UpdateNameLabel();
        }

        private void SetActiveDataNavigator(IKissDataNavigator navigator)
        {
            kissDataNavigator.ActiveIKissDataNavigator = navigator;
        }

        /// <summary>
        /// Sucht für das Feld Status alle Stati der Gesuchverwaltung und deren Bilder dazu.
        /// </summary>
        private void SetLookupEdit_Status()
        {
            repStatusImgText.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStatus = DBUtil.OpenSQL(@"
                SELECT
                  [Text] = ISNULL(TXT.Text, LOV.Text),
                  LOV.Code,
                  IconID = ISNULL(LOV.Value1, 0)
                FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = LOV.TextTID
                                                                    AND TXT.LanguageCode = {0}
                WHERE LOVName = 'GvStatus'
                  AND IsActive = 1
                ORDER BY SortKey;", Session.User.LanguageCode);

            foreach (DataRow row in qryStatus.DataTable.Rows)
            {
                repStatusImgText.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    Convert.ToString(row["Text"]),
                    Convert.ToInt32(row["Code"]),
                    KissImageList.GetImageIndex(Convert.ToInt32(row["IconID"]))));
            }

            edtSucheStatus.Properties.SmallImages = KissImageList.SmallImageList;
            edtSucheStatus.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", null, -1));

            foreach (DevExpress.XtraEditors.Controls.ImageComboBoxItem item in repStatusImgText.Items)
            {
                edtSucheStatus.Properties.Items.Add(item);
            }
        }

        /// <summary>
        /// Steuert anhand der Berechtigungen die Anzeige der Tabs
        /// Die Standard Tabs Gesuch (Liste) sowie Suche sind für alle Benutzer sichtbar, welche Zugriff
        /// auf die Gesuchverwaltung haben.
        /// </summary>
        private void SetTabAuthorisation()
        {
            tabControlSearch.SelectedTabChanged -= tabControlSearch_SelectedTabChanged;

            // Alle Tabs aus TabPages entfernen
            tabControlSearch.TabPages.Clear();

            // Tabs in richtiger Reihenfolge neu hinzufügen wenn der Benutzer Maskenrecht hat
            tabControlSearch.TabPages.Add(tpgListe);
            if (DBUtil.UserHasRight("CtlGvAntrag"))
            {
                tabControlSearch.TabPages.Add(tpgAntrag);
            }

            if (DBUtil.UserHasRight("CtlGvAbklaerendeStelle"))
            {
                tabControlSearch.TabPages.Add(tpgAbklaerendeStelle);
            }

            if (DBUtil.UserHasRight("CtlGvBegruendung"))
            {
                tabControlSearch.TabPages.Add(tpgBegruendung);
            }

            if (DBUtil.UserHasRight("CtlGvBeilagenDokumente"))
            {
                tabControlSearch.TabPages.Add(tpgBeilagenDokumente);
            }

            if (DBUtil.UserHasRight("CtlGvBewilligung"))
            {
                tabControlSearch.TabPages.Add(tpgBewilligung);
            }

            if (DBUtil.UserHasRight("CtlGvAuflagen"))
            {
                tabControlSearch.TabPages.Add(tpgAuflagen);
            }

            if (DBUtil.UserHasRight("CtlGvAuszahlung"))
            {
                tabControlSearch.TabPages.Add(tpgAuszahlung);
            }

            tabControlSearch.TabPages.Add(tpgSuchen);
            tabControlSearch.SelectTab(tpgListe);
            tabControlSearch.SelectedTabChanged += tabControlSearch_SelectedTabChanged;
        }

        private void SetupFieldNames()
        {
            colGvGesuchID.FieldName = DBO.GvGesuch.GvGesuchID;
            colGesuchsdatum.FieldName = DBO.GvGesuch.GesuchsDatum;
            colKlient.FieldName = QRY_GVGESUCH_KLIENT;
            colFonds.FieldName = DBO.GvGesuch.GvFondsID;
            colStatus.FieldName = DBO.GvGesuch.GvStatusCode;
            colBetragBeantragt.FieldName = QRY_GVGESUCH_BETRAG_BEANTRAGT;
            colBetragBewilligt.FieldName = DBO.GvGesuch.BetragBewilligt;
            colBetragBewilligt.SummaryItem.FieldName = DBO.GvGesuch.BetragBewilligt;
            colDatumBewilligt.FieldName = DBO.GvGesuch.BewilligtAm;
            colAutor.FieldName = QRY_GVGESUCH_AUTOR;
            colTage.FieldName = QRY_GVGESUCH_TAGE;
            colKompetenzKanton.FieldName = DBO.GvGesuch.IstKompetenzKanton;
            colKompetenzBsl.FieldName = DBO.GvGesuch.IstKompetenzBsl;
            colIstFondsExtern.FieldName = QRY_GVGESUCH_IST_FONDS_EXTERN;
        }

        private void tabControlSearch_SelectedTabChanged(TabPageEx page)
        {
            GvBaseControl gvBaseControl = null;

            if (page == tpgListe)
            {
                gvBaseControl = _ctlGvGesuch;
            }
            else if (page == tpgAntrag)
            {
                if (_ctlGvAntrag == null)
                {
                    _ctlGvAntrag = new CtlGvAntrag(qryGvGesuch, _hasKompetenzstufe0, _hasKompetenzstufe1, _hasKompetenzstufe2);
                    tpgAntrag.Controls.Add(_ctlGvAntrag);
                    _ctlGvAntrag.Dock = DockStyle.Fill;
                    _ctlGvAntrag.BeantragterBetragChanged += _ctlGvAntrag_BeantragterBetragChanged;
                }

                gvBaseControl = _ctlGvAntrag;
            }
            else if (page == tpgBegruendung)
            {
                if (_ctlGvBegruendung == null)
                {
                    _ctlGvBegruendung = new CtlGvBegruendung(qryGvGesuch, _hasKompetenzstufe0, _hasKompetenzstufe1, _hasKompetenzstufe2);
                    tpgBegruendung.Controls.Add(_ctlGvBegruendung);
                    _ctlGvBegruendung.Dock = DockStyle.Fill;
                }

                gvBaseControl = _ctlGvBegruendung;
            }
            else if (page == tpgBewilligung)
            {
                if (_ctlGvBewilligung == null)
                {
                    _ctlGvBewilligung = new CtlGvBewilligung(qryGvGesuch, _hasKompetenzstufe0, _hasKompetenzstufe1, _hasKompetenzstufe2);
                    tpgBewilligung.Controls.Add(_ctlGvBewilligung);
                    _ctlGvBewilligung.Dock = DockStyle.Fill;
                }

                gvBaseControl = _ctlGvBewilligung;
            }
            else if (page == tpgBeilagenDokumente)
            {
                if (_ctlGvBeilagenDokumente == null)
                {
                    _ctlGvBeilagenDokumente = new CtlGvBeilagenDokumente(qryGvGesuch, _hasKompetenzstufe0, _hasKompetenzstufe1, _hasKompetenzstufe2);
                    tpgBeilagenDokumente.Controls.Add(_ctlGvBeilagenDokumente);
                    _ctlGvBeilagenDokumente.Dock = DockStyle.Fill;
                }

                gvBaseControl = _ctlGvBeilagenDokumente;
            }
            else if (page == tpgAuflagen)
            {
                if (_ctlGvAuflagen == null)
                {
                    _ctlGvAuflagen = new CtlGvAuflagen(qryGvGesuch, _hasKompetenzstufe0, _hasKompetenzstufe1, _hasKompetenzstufe2);
                    tpgAuflagen.Controls.Add(_ctlGvAuflagen);
                    _ctlGvAuflagen.Dock = DockStyle.Fill;
                }

                gvBaseControl = _ctlGvAuflagen;
            }
            else if (page == tpgAuszahlung)
            {
                if (_ctlGvAuszahlung == null)
                {
                    _ctlGvAuszahlung = new CtlGvAuszahlung(qryGvGesuch, _hasKompetenzstufe0, _hasKompetenzstufe1, _hasKompetenzstufe2);
                    tpgAuszahlung.Controls.Add(_ctlGvAuszahlung);
                    _ctlGvAuszahlung.Dock = DockStyle.Fill;
                }

                gvBaseControl = _ctlGvAuszahlung;
            }
            else if (page == tpgAbklaerendeStelle)
            {
                if (_ctlGvAbklaerendeStelle == null)
                {
                    _ctlGvAbklaerendeStelle = new CtlGvAbklaerendeStelle(qryGvGesuch, _hasKompetenzstufe0, _hasKompetenzstufe1, _hasKompetenzstufe2);
                    tpgAbklaerendeStelle.Controls.Add(_ctlGvAbklaerendeStelle);
                    _ctlGvAbklaerendeStelle.Dock = DockStyle.Fill;
                }

                gvBaseControl = _ctlGvAbklaerendeStelle;
            }

            //just to be sure... ;-)
            if (gvBaseControl != null)
            {
                gvBaseControl.LoadData();
            }

            SetActiveDataNavigator(gvBaseControl);
        }

        private void UpdateNameLabel()
        {
            var baPersonId = Utils.ConvertToInt(qryGvGesuch[DBO.GvGesuch.BaPersonID]);
            var name = BaPersonService.GetBaPersonNameVornameByBaPersonId(baPersonId);
            var fondsName = (string)DBUtil.ExecuteScalarSQL(@"
                                            SELECT GFD.NameKurz FROM dbo.GvFonds GFD WITH (READUNCOMMITTED)
                                            WHERE GFD.GvFondsID = {0};",
                                            qryGvGesuch[DBO.GvGesuch.GvFondsID],
                                            Session.User.LanguageCode);

            lblTitelInfo.Text = KissMsg.GetMLMessage(CLASSNAME, "GV_Titel_Info_Label", "{0}; {1}; {2}", name, qryGvGesuch[DBO.GvGesuch.Gesuchsgrund], fondsName);
        }

        private void UpdateTabs(bool forceDisable = false)
        {
            // Tabs aktivieren/deaktivieren
            var gesuchSelektiert = GvGesuchId != null && !forceDisable;

            foreach (var page in tabControlSearch.TabPages.Cast<TabPageEx>().Where(page => page != tpgListe && page != tpgSuchen))
            {
                page.Enabled = gesuchSelektiert;
            }
        }
    }
}