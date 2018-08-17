using System;
using System.Data;
using System.Windows.Forms;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe
{
    /// <summary>
    /// Form, used for handling single payments
    /// </summary>
    public partial class CtlWhAuszahlungen : KissSearchUserControl, IBelegleser
    {
        #region Enumerations

        /// <summary>
        /// Required entries from LOV: KbAuszahlungsArt
        /// </summary>
        public enum KbAuszahlungsArt
        {
            /// <summary>
            /// 101: Elektronische Auszahlung: only available if having Klibu system
            /// </summary>
            ElAuszahlung = 101,

            /// <summary>
            /// 102: Papierverfuegung: only available if having no Klibu system
            /// </summary>
            Papierverfuegung = 102,

            /// <summary>
            /// 106: SIL-Antrag: always available
            /// </summary>
            SILAntrag = 106
        }

        #endregion

        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlWhAuszahlungen";
        private const string KEINKLIBUSYS = "kein";

        private readonly BgEditMask _bgEditMask = new BgEditMask();
        private readonly int _ezStandardAuszahlungsart = DBUtil.GetConfigInt(@"System\Sozialhilfe\EZStandardAuszahlungsart", Convert.ToInt32(KbAuszahlungsArt.ElAuszahlung)); // default auszahlungsart (101=El.Ausz.||106=Papierverf.; 106=SIL-Antrag)
        private readonly bool _userRightWhEinzelzahlungKreditor = DBUtil.UserHasRight("FrmWhEinzelzahlungen_KreditorAuswahl");

        #endregion

        #region Private Fields

        private int _bgPositionIDBewilligen = -1;
        private bool _insertNewBewilligungHistoryErteilt; // used to store if a new history entry in BgBewilligung has to be inserted for new ZL
        private bool _isFilling;
        private int _newBgKategorieCode;
        private object _oldBgSpezkontoID; // store the old editvalue of edtBgSpezkonto

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlWhAuszahlungen"/> class.
        /// </summary>
        public CtlWhAuszahlungen()
        {
            // init controls
            InitializeComponent();

            // falls user recht zur auswahl kreditoren besitzt, kann El.Auszahlung gewählt werden, sonst nur SIL-Antrag
            // El.Auszahlung||Papierverfuegung and SIL-Antrag are possible to display
            edtAuszahlungsart.LOVFilterWhereAppend = true;
            edtAuszahlungsart.LOVFilter = string.Format("Code IN ({0}, {1})", _ezStandardAuszahlungsart,
                                                                              Convert.ToInt32(KbAuszahlungsArt.SILAntrag));

            ////// fix default ausz.art
            ////if (_ezStandardAuszahlungsart == Convert.ToInt32(KbAuszahlungsArt.ElAuszahlung) ||
            ////    _ezStandardAuszahlungsart == Convert.ToInt32(KbAuszahlungsArt.Papierverfuegung))
            ////{
            ////    // setup depending on having klibu
            ////    _ezStandardAuszahlungsart = GetAuszArtElAuszOrPaperInt();
            ////}

            // setup rights for specific controls
            SetupRights();

            // setup controls for multilanguage handling
            SetupControlsML();

            // setup max length for the text edits
            SetupMaxLength();
        }

        #endregion

        #region EventHandlers

        private void btnEinzelzahlung_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post() || !qryBgPosition.CanInsert)
            {
                return;
            }

            _newBgKategorieCode = Convert.ToInt32(LOV.BgKategorieCode.Einzelzahlungen);
            qryBgPosition.Insert();
        }

        private void btnFreigeben_Click(object sender, EventArgs e)
        {
            // set cursor
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // do it
                ReleasePosition();

                // refresh query
                qryBgPosition.Refresh();
            }
            catch (KissInfoException ex)
            {
                // show info message
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(Name, "ErrorBtnFreigeben", "Es ist ein Fehler beim Freigeben der Auszahlung aufgetreten.", ex);
            }
            finally
            {
                // handle button freigeben
                EnableBtnFreigeben();

                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnGraustellen_Click(object sender, EventArgs e)
        {
            // set cursor
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // do it
                ResetPosition();

                // refresh query
                qryBgPosition.Refresh();
            }
            catch (KissInfoException ex)
            {
                // show info message
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(Name, "ErrorBtnGraustellen", "Es ist ein Fehler beim Graustellen der Auszahlung aufgetreten.", ex);
            }
            finally
            {
                // handle button freigeben
                EnableBtnGraustellen();

                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnMonatsbudget_Click(object sender, EventArgs e)
        {
            if (qryBgBudget.Count == 0)
            {
                return;
            }

            string budgetPath = string.Format(@"CtlWhFinanzplan{0}\BBG{1}", qryBgBudget["BgFinanzplanID"], qryBgBudget["BgBudgetID"]);

            FormController.OpenForm("FrmFall",
                                    "Action", "JumpToNodeByFieldValue",
                                    "BaPersonID", qryBgBudget["FallBaPersonID"],
                                    "ModulID", 3,
                                    "FieldValue", budgetPath);
        }

        private void btnPositionBewilligung_Click(object sender, EventArgs e)
        {
            // validate first
            if (!CanGrantPosition())
            {
                // button cannot be used
                EnableBtnBewilligen();
                return;
            }

            if (!qryBgPosition.Post() || !btnPositionBewilligung.Enabled)
            {
                return;
            }

            try
            {
                // check concurrency
                CheckConcurrency();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name,
                                  "ErrorConcurrencyBewilligung",
                                  "Es ist ein Fehler beim Validieren der Daten aufgetreten.\r\n\r\nDie zugehörigen Daten wurden vermutlich bereits verändert. Bitte aktualisieren Sie die Ansicht zuerst.", ex);
                return;
            }

            try
            {
                _bgPositionIDBewilligen = Convert.ToInt32(qryBgPosition[DBO.BgPosition.BgPositionID]);
                BgBewilligungStatus bewilligungStatus = (BgBewilligungStatus)qryBgPosition[DBO.BgPosition.BgBewilligungStatusCode];

                if (bewilligungStatus == BgBewilligungStatus.InVorbereitung && GetUserPermissionZL())
                {
                    InsertGrantingHistory(_bgPositionIDBewilligen, BgBewilligungStatus.InVorbereitung, BgBewilligungStatus.Erteilt);
                    ApplyAction(BewilligungAktion.Bewilligen);
                }
                else
                {
                    DlgBewilligung dlg = new DlgBewilligung(BewilligungTyp.Einzelzahlung, _bgPositionIDBewilligen, bewilligungStatus, GetUserPermissionZL);
                    dlg.ShowDialog(this);

                    if (!dlg.UserCancel)
                    {
                        ApplyAction(dlg);
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorGrantingPosition", "Es ist ein Fehler beim Bewilligen der Position(en) aufgetreten.", ex);
            }
            finally
            {
                // handle button Bewilligen
                EnableBtnBewilligen();
            }
        }

        private void btnWeitereKOA_Click(object sender, EventArgs e)
        {
            if (qryBgPosition.Count == 0 || !qryBgPosition.Post())
            {
                return;
            }

            try
            {
                // check concurrency
                CheckConcurrency();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name,
                                  "ErrorConcurrencyWeitereKOA_v02",
                                  "Es ist ein Fehler beim Validieren der Daten aufgetreten.\r\n\r\nDie zugehörigen Daten wurden vermutlich bereits verändert. Bitte aktualisieren Sie die Ansicht zuerst.", ex);
                return;
            }

            try
            {
                DlgWhWeitereKOA dlg = new DlgWhWeitereKOA(Convert.ToInt32(qryBgPosition["BgPositionID"]),
                                                          Convert.ToDecimal(qryBgPosition["BetragSpezial"]));

                if (dlg.ShowDialog(this) == DialogResult.OK || dlg.UsedGranting)
                {
                    qryBgPosition.Refresh();

                    if (ShUtil.GetCode(qryBgPosition["Status"]) != Convert.ToInt32(KbBuchungsStatus.Bewilligt))
                    {
                        //if we have multiple Kostenarten, we have to make sure, Auszahlungsart is SIL-Antrag, otherwise it could get 'verbucht' automatically
                        SetAuszahlungsArtToSILAntrag();
                    }
                }
            }
            finally
            {
                // update enabled states of controls
                UpdateControlsAndStates();
            }
        }

        private void btnZusatzleistung_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post() || !qryBgPosition.CanInsert)
            {
                return;
            }

            _newBgKategorieCode = Convert.ToInt32(LOV.BgKategorieCode.Zusaetzliche_Leistungen);
            qryBgPosition.Insert();
        }

        private void CtlWhAuszahlungen_Load(object sender, EventArgs e)
        {
            // Buchungsstatus laden
            repStatusImg.SmallImages = KissImageList.SmallImageList;

            SqlQuery qryStatus = DBUtil.OpenSQL(@"
                SELECT Code   = LOC.Code,
                       Text   = dbo.fnLOVMLText(LOC.LOVName, LOC.Code, {0}),
                       Value1 = LOC.Value1
                FROM dbo.XLOVCode LOC WITH (READUNCOMMITTED)
                WHERE LOC.LOVName = 'KbBuchungsStatus'
                ORDER BY SortKey", Session.User.LanguageCode);

            foreach (DataRow row in qryStatus.DataTable.Rows)
            {
                repStatusImg.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    row["Text"].ToString(), Convert.ToInt32(row["Code"]), KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            grdBgBudget.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {repStatusImg});
            colStatus.ColumnEdit = repStatusImg;

            // Dasselbe für edtSucheStatus
            edtSucheStatus.Properties.SmallImages = KissImageList.SmallImageList;
            edtSucheStatus.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", null, -1));

            foreach (DevExpress.XtraEditors.Controls.ImageComboBoxItem item in repStatusImg.Items)
            {
                edtSucheStatus.Properties.Items.Add(item);
            }

            edtBgSplittingCode.LoadQuery(DBUtil.OpenSQL(@"
                SELECT *
                FROM dbo.XLOVCode LOC WITH (READUNCOMMITTED)
                WHERE LOC.LOVName = 'BgSplittingart';"), "Code", "ShortText");

            colKat.ColumnEdit = grdEinzelzahlung.GetLOVLookUpEdit(DBUtil.OpenSQL(@"
                SELECT Code = LOC.Code,
                       Text = SUBSTRING(LOC.Text, 1, 1)
                FROM dbo.XLOVCode LOC WITH (READUNCOMMITTED)
                WHERE LOC.LOVName = 'BgKategorie';"));

            colDocTyp.ColumnEdit = grdBgDokumente.GetLOVLookUpEdit("BgDokumentTyp");
            colBgBewilligungCode.ColumnEdit = grdBgBewilligung.GetLOVLookUpEdit("BgBewilligung");

            edtBetrag.Properties.DisplayFormat.FormatString = "N2";
            edtBetrag.Properties.EditFormat.FormatString = "N2";

            qryBgPosition.PostCompleted += qryBgPosition_PostCompleted;

            // init tabpages
            tabBgPosition.SelectedTabIndex = 0;
            tabControlSearch.SelectedTabIndex = 1;

            PresetSearchFields();
            OnSearch();
        }

        private void edtAuszahlungsart_EditValueChanged(object sender, EventArgs e)
        {
            // enable/disable fields
            SetEditMode();
        }

        private void edtBgSpezkontoID_EditValueChanged(object sender, EventArgs e)
        {
            if (qryBgPosition.IsFilling || !edtBgSpezkontoID.Focused)
            {
                return;
            }

            qryBgPosition["BgSpezKontoID"] = edtBgSpezkontoID.EditValue;

            SetSpezialkonto();
            SetEditMode();
        }

        private void edtBgSpezkontoID_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            // apply old value
            _oldBgSpezkontoID = e.OldValue;
        }

        private void edtBuchungstext_Enter(object sender, EventArgs e)
        {
            edtBuchungstext.SelectAll();
        }

        private void edtDocument_DocumentDeleted(object sender, EventArgs e)
        {
            // update information about document
            UpdateDocumentInfo();
        }

        private void edtKlient_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKlient.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgPosition["Klient"] = null;
                    qryBgPosition["KlientID"] = null;
                    qryBgPosition["Adresse"] = null;
                    qryBgBudget.DataTable.Rows.Clear();
                    LoadSpezialkonto(-1);
                    return;
                }
            }

            int searchNr;

            if (!int.TryParse(searchString, out searchNr))
            {
                searchNr = 0;
            }

            string sql = @"
                SELECT DISTINCT
                       [BaPersonID$]    = PRS.BaPersonID,
                       [Pers.-Nr.]      = PRS.BaPersonID,
                       [Name]           = PRS.NameVorname +
                                          ' (' + ISNULL(CONVERT(VARCHAR, PRS.AlterMortal), '-') +
                                          ISNULL(',' + GES.ShortText,'') + ')',
                       [Adresse]        = PRS.Wohnsitz,
                       [Fall-Nr]        = LEI.FaFallID,
                       [MB grau]        = (SELECT COUNT(1)
                                           FROM dbo.BgBudget             B
                                             INNER JOIN dbo.BgFinanzplan F ON F.BgFinanzplanID = B.BgFinanzplanID
                                             INNER JOIN dbo.FaLeistung   L ON L.FaLeistungID = F.FaLeistungID
                                           WHERE L.FaFallID = LEI.FaFallID
                                             AND L.BaPersonID = PRS.BaPersonID
                                             AND B.Masterbudget = 0
                                             AND B.BgBewilligungStatusCode = 1),
                       [MB grün]        = (SELECT COUNT(1)
                                           FROM dbo.BgBudget             B
                                             INNER JOIN dbo.BgFinanzplan F ON F.BgFinanzplanID = B.BgFinanzplanID
                                             INNER JOIN dbo.FaLeistung   L ON L.FaLeistungID = F.FaLeistungID
                                           WHERE L.FaFallID = LEI.FaFallID
                                             AND L.BaPersonID = LEI.BaPersonID
                                             AND B.Masterbudget = 0
                                             AND B.BgBewilligungStatusCode = 5),
                       [MB rot]         = (SELECT COUNT(1)
                                           FROM dbo.BgBudget             B
                                             INNER JOIN dbo.BgFinanzplan F ON F.BgFinanzplanID = B.BgFinanzplanID
                                             INNER JOIN dbo.FaLeistung   L ON L.FaLeistungID = F.FaLeistungID
                                           WHERE L.FaFallID = LEI.FaFallID
                                             AND L.BaPersonID = LEI.BaPersonID
                                             AND B.Masterbudget = 0
                                             AND B.BgBewilligungStatusCode = 9),
                       [Name$]          = PRS.NameVorname
                FROM dbo.vwPerson           PRS WITH (READUNCOMMITTED)
                  INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = PRS.BaPersonID
                                                                      AND LEI.FaProzessCode = 300
                  LEFT  JOIN dbo.XLOVCode   GES WITH (READUNCOMMITTED) ON GES.LOVName = 'BaGeschlecht'
                                                                      AND GES.Code = PRS.GeschlechtCode ";

            if (searchNr > 0)
            {
                sql += @"WHERE PRS.BaPersonID = {0} OR LEI.FaFallID = {0}
                         ORDER BY Name;";
            }
            else
            {
                sql += @"WHERE PRS.NameVorname LIKE '%' + {0} + '%'
                         ORDER BY Name;";
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(sql, searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                // apply values
                qryBgPosition["Klient"] = dlg["Name$"];
                qryBgPosition["KlientID"] = dlg["BaPersonID$"];
                qryBgPosition["Adresse"] = dlg["Adresse"];

                // check if need to reset some fields
                if (!DBUtil.IsEmpty(qryBgPosition[DBO.BgPosition.BgKategorieCode]) &&
                    ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgKategorieCode]) != Convert.ToInt32(LOV.BgKategorieCode.Zusaetzliche_Leistungen))
                {
                    // reset some fields for security reason for EZ
                    edtBgSpezkontoID.EditValue = null;
                    edtKostenart.LookupID = null;
                    edtKostenart.EditValue = null;

                    qryBgPosition[DBO.BgPosition.BgPositionsartID] = DBNull.Value;
                    qryBgPosition["Kostenart"] = DBNull.Value;
                }

                _isFilling = true;

                try
                {
                    qryBgBudget.Fill(qryBgPosition["KlientID"], null);

                    while (Convert.ToInt32(qryBgBudget["Jahr"]) != DateTime.Now.Year ||
                           Convert.ToInt32(qryBgBudget["Monat"]) != DateTime.Now.Month)
                    {
                        if (!qryBgBudget.Next())
                        {
                            break;
                        }
                    }
                }
                finally
                {
                    _isFilling = false;

                    SetVerwendungsPeriode();
                    LoadSpezialkonto(null);
                    LoadPerson();
                }
            }
        }

        private void edtKostenart_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKostenart.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgPosition[DBO.BgPosition.BgPositionsartID] = DBNull.Value;
                    qryBgPosition["Kostenart"] = DBNull.Value;
                    return;
                }
            }

            if (_bgEditMask.GruppeFilter && e.ButtonClicked)
            {
                searchString = "%";
            }

            // Gültigkeit
            int jahr = DBUtil.IsEmpty(qryBgBudget["Jahr"]) ? DateTime.Now.Year : (int)qryBgBudget["Jahr"];
            int monat = DBUtil.IsEmpty(qryBgBudget["Monat"]) ? DateTime.Now.Month : (int)qryBgBudget["Monat"];

            DateTime gueltigVon = new DateTime(jahr, monat, 1);
            DateTime gueltigBis = new DateTime(jahr, monat, 1).AddMonths(1).AddDays(-1);    // Ende des Monats ist ein Tag vor dem Anfang des nächsten Monats

            KissLookupDialog dlg = new KissLookupDialog();

            string sql = string.Format(@"
                SELECT KOA                     = BKA.KontoNr,
                       Positionsart            = BPA.Name,
                       Gruppe                  = GRP.Text,
                       BgPositionsartID$       = BPA.BgPositionsartID,
                       BgKostenartID$          = BPA.BgKostenartID,
                       ProPerson$              = BPA.ProPerson,
                       ProUE$                  = BPA.ProUE,
                       KOAPositionsart$        = ISNULL(BKA.KontoNr, '') + ISNULL(' ' + BPA.Name, ''),
                       Name$                   = BPA.Name,
                       BgSplittingArtCode$     = BKA.BgSplittingArtCode,
                       sqlRichtlinie$          = BPA.sqlRichtlinie,
                       GruppeFilter$           = CONVERT(VARCHAR(50), GRP.Value3),
                       KreditorEingeschraenkt$ = BPA.KreditorEingeschraenkt
                FROM dbo.WhPositionsart      BPA WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BgKostenart BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = BPA.BgKostenartID
                  LEFT  JOIN dbo.XLOVCode    GRP WITH (READUNCOMMITTED) ON GRP.LOVName = 'BgGruppe'
                                                                       AND GRP.Code = BPA.BgGruppeCode
                WHERE BgKategorieCode = {0}
                  AND (BPA.Name LIKE '%' + {1} + '%' OR BKA.KontoNr LIKE {1} + '%')
                  AND ISNULL(BPA.DatumVon, '19000101') <= {3} AND ISNULL(BPA.DatumBis, '99991231') >= {4}
                  --- AND CONVERT(VARCHAR(50), GRP.Value3) = '{2}'
                ORDER BY KOA, Positionsart;", qryBgPosition[DBO.BgPosition.BgKategorieCode], "{0}", qryBgPosition["GruppeFilter"], "{1}", "{2}");

            if (_bgEditMask.GruppeFilter)
            {
                // replace tag if group filter is active
                sql = sql.Replace("---", "");
            }

            e.Cancel = !dlg.SearchData(sql, searchString, e.ButtonClicked, gueltigVon, gueltigBis, null);

            if (!e.Cancel)
            {
                qryBgPosition[DBO.BgPosition.BgPositionsartID] = dlg["BgPositionsartID$"];
                qryBgPosition["Kostenart"] = dlg["KOAPositionsart$"];
                qryBgPosition["Buchungstext"] = dlg["Name$"];
                qryBgPosition["BgSplittingArtCode"] = dlg["BgSplittingArtCode$"];
                qryBgPosition["ProPerson"] = dlg["ProPerson$"];
                qryBgPosition["ProUE"] = dlg["ProUE$"];
                qryBgPosition["GruppeFilter"] = dlg["GruppeFilter$"];
                qryBgPosition["KreditorEingeschraenkt"] = dlg["KreditorEingeschraenkt$"];

                bool proPerson = Convert.ToBoolean(qryBgPosition["ProPerson"]);
                bool proUE = Convert.ToBoolean(qryBgPosition["ProUE"]);

                if (proUE && !proPerson)
                {
                    qryBgPosition["BaPersonID"] = null;
                }

                SetVerwendungsPeriode();
                SetEditMode();
            }
        }

        private void edtKreditor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (DBUtil.IsEmpty(qryBgPosition["KlientID"]))
            {
                KissMsg.ShowInfo(Name, "KreditorKeinKlientErfasst", "Es ist noch kein/e Klient/in erfasst.");
                edtKreditor.EditValue = DBNull.Value;
                edtKlient.Focus();

                // cancel
                e.Cancel = true;
            }
            else
            {
                e.Cancel = AuswahlKreditor(edtKreditor.EditValue.ToString(), e.ButtonClicked);

                // apply editvalue as it won't be updated in every case directly (e.g. when pressing F2 after changing value without moving focus)
                edtKreditor.EditValue = qryBgPosition[edtKreditor.DataMember];
            }
        }

        private void edtSucheErfassungMA_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            DlgSucheMA(edtSucheErfassungMA, ref e);
        }

        private void edtSucheMutationMA_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            DlgSucheMA(edtSucheMutationMA, ref e);
        }

        private void qryBgBudget_PositionChanged(object sender, EventArgs e)
        {
            if (_isFilling)
            {
                return;
            }

            qryBgPosition.RowModified = true;

            int kategorie = ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgKategorieCode]);

            if (kategorie == Convert.ToInt32(LOV.BgKategorieCode.Einzelzahlungen))
            {
                LoadSpezialkonto(null);
            }

            SetVerwendungsPeriode();
            LoadPerson();
        }

        private void qryBgDokumente_AfterInsert(object sender, EventArgs e)
        {
            qryBgDokumente["BgDokumentTypCode"] = 1;
            qryBgDokumente["Stichwort"] = qryBgPosition["Kostenart"];

            edtDokumentTyp.Focus();
        }

        private void qryBgDokumente_BeforePost(object sender, EventArgs e)
        {
            qryBgDokumente["BgPositionID"] = DBNull.Value;
            qryBgDokumente["BgBudgetID"] = DBNull.Value;
            qryBgDokumente["BgFinanzplanID"] = DBNull.Value;

            switch (Convert.ToInt32(qryBgDokumente["BgDokumentTypCode"]))
            {
                case 1:
                    // validate
                    if (DBUtil.IsEmpty(qryBgPosition["BgPositionID"]))
                    {
                        KissMsg.ShowError(Name, "SaveDocInvalidBgPositionID", "Dokument kann nicht gespeichert werden, die BgPositionID ist ungültig.");
                        throw new KissCancelException();
                    }

                    qryBgDokumente["BgPositionID"] = qryBgPosition["BgPositionID"];
                    break;

                case 2:
                    // validate
                    if (DBUtil.IsEmpty(qryBgBudget["BgBudgetID"]))
                    {
                        KissMsg.ShowError(Name, "SaveDocInvalidBgBudgetID", "Dokument kann nicht gespeichert werden, die BgBudgetID ist ungültig.");
                        throw new KissCancelException();
                    }

                    qryBgDokumente["BgBudgetID"] = qryBgBudget["BgBudgetID"];
                    break;

                case 3:
                    // validate
                    if (DBUtil.IsEmpty(qryBgBudget["BgFinanzplanID"]))
                    {
                        KissMsg.ShowError(Name, "SaveDocInvalidBgFinanzplanID", "Dokument kann nicht gespeichert werden, die BgFinanzplanID ist ungültig.");
                        throw new KissCancelException();
                    }

                    qryBgDokumente["BgFinanzplanID"] = qryBgBudget["BgFinanzplanID"];
                    break;
            }

            if (DBUtil.IsEmpty(qryBgDokumente["Stichwort"]))
            {
                qryBgDokumente["Stichwort"] = "-";
            }

            // update information in grid
            UpdateDocumentInfo();
        }

        private void qryBgDokumente_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            qryBgPosition.RowModified = true;
        }

        private void qryBgPosition_AfterInsert(object sender, EventArgs e)
        {
            // setup default values
            qryBgPosition[DBO.BgPosition.BgKategorieCode] = _newBgKategorieCode;
            qryBgPosition["Doc"] = 0;
            qryBgPosition["Status"] = 1; //grau
            qryBgPosition["ProPerson"] = false;
            qryBgPosition["ProUE"] = true;

            if (_newBgKategorieCode == Convert.ToInt32(LOV.BgKategorieCode.Zusaetzliche_Leistungen))
            {
                qryBgPosition["BgAuszahlungsTerminCode"] = 4; // Valuta
            }
            else if (_newBgKategorieCode == Convert.ToInt32(LOV.BgKategorieCode.Einzelzahlungen))
            {
                qryBgPosition["BgAuszahlungsTerminCode"] = 4; // Valuta
                LoadSpezialkonto(-1); // keine Auswahl, solange kein Klient ausgewählt ist
            }

            // check rights
            if (!_userRightWhEinzelzahlungKreditor)
            {
                // only SIL-Antrag is possible
                qryBgPosition["KbAuszahlungsArtCode"] = Convert.ToInt32(KbAuszahlungsArt.SILAntrag);
            }
            else
            {
                // apply default setting for Auszahlungsart
                qryBgPosition["KbAuszahlungsArtCode"] = _ezStandardAuszahlungsart;
            }

            // init control for new data
            ctlErfassungMutation.ShowInfo();
            _newBgKategorieCode = 0;
            tabBgPosition.SelectedTabIndex = 0;

            // update enabled states of controls
            UpdateControlsAndStates();

            // set focus Kiss5 will send additional key up event
            if (Session.IsKiss5Mode)
            {
                edtKategorie.Focus();
            }
            else
            {
                edtKlient.Focus();
            }
        }

        private void qryBgPosition_AfterPost(object sender, EventArgs e)
        {
            // check if we have an open transaction
            if (Session.Transaction == null)
            {
                // something is wrong, this case should never occure
                throw new KissErrorException("No open transaction in AfterPost event, cannot continue handling data changes.");
            }

            try
            {
                bool hauptPos = !DBUtil.IsEmpty(qryBgPosition["HauptPos"]);

                // check if new entry in BgBewilligung has to be inserted
                if (_insertNewBewilligungHistoryErteilt)
                {
                    // create log-entry into Bewilligungs-History: Bewilligt
                    InsertGrantingHistory(Convert.ToInt32(qryBgPosition["BgPositionID"]),
                                             BgBewilligungStatus.InVorbereitung,
                                             BgBewilligungStatus.Erteilt);

                    // reset flag
                    _insertNewBewilligungHistoryErteilt = false;
                }

                // Valuta-Termine speichern
                // Löschen der alten Daten und neuer Datensatz in BgAuszahlungPerson und BgAuszahlungPersonTermin
                DBUtil.ExecSQLThrowingException(@"
                    DELETE TRM
                    FROM dbo.BgAuszahlungPersonTermin TRM
                      INNER JOIN dbo.BgAuszahlungPerson AUS ON AUS.BgAuszahlungPersonID = TRM.BgAuszahlungPersonID
                    WHERE AUS.BgPositionID = {0};

                    DELETE FROM dbo.BgAuszahlungPerson
                    WHERE BgPositionID = {0};

                    INSERT INTO dbo.BgAuszahlungPerson (BgPositionID, BaPersonID, KbAuszahlungsArtCode, BgAuszahlungsTerminCode,
                                                        BgWochentagCodes, BaZahlungswegID, ReferenzNummer, MitteilungZeile1,
                                                        MitteilungZeile2, MitteilungZeile3, MitteilungZeile4)
                    VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10});

                    INSERT INTO dbo.BgAuszahlungPersonTermin (BgAuszahlungPersonID, Datum)
                    VALUES (@@identity, {11});", qryBgPosition["BgPositionID"],
                                                 null,
                                                 qryBgPosition["KbAuszahlungsArtCode"],
                                                 qryBgPosition["BgAuszahlungsTerminCode"],
                                                 qryBgPosition["BgWochentagCodes"],
                                                 qryBgPosition["BaZahlungswegID"],
                                                 qryBgPosition["ReferenzNummer"],
                                                 qryBgPosition["MitteilungZeile1"],
                                                 qryBgPosition["MitteilungZeile2"],
                                                 qryBgPosition["MitteilungZeile3"],
                                                 qryBgPosition["MitteilungZeile4"],
                                                 qryBgPosition["ValutaDatum"]);

                if (hauptPos)
                {
                    // Update alle DetailPos inkl. Auszahlinfo
                    DBUtil.ExecSQLThrowingException(@"
                        DECLARE @HauptBgPositionID INT;
                        DECLARE @MainBgAuszahlungPersonID INT;
                        DECLARE @DetailBgPositionID INT;
                        DECLARE @WhereClause VARCHAR(200);

                        SET @HauptBgPositionID = {0};

                        UPDATE dbo.BgPosition
                        SET BgBudgetID = {1},
                            Bemerkung  = {2}
                        WHERE BgPositionID_Parent = @HauptBgPositionID;

                        -- alte Auszahlinfo löschen
                        DELETE BAP
                        FROM dbo.BgAuszahlungPerson BAP
                          INNER JOIN dbo.BgPosition BPO ON BPO.BgPositionID = BAP.BgPositionID
                        WHERE BPO.BgPositionID_Parent = @HauptBgPositionID;

                        DECLARE cDetailPos CURSOR STATIC FOR
                          SELECT BgPositionID
                          FROM dbo.BgPosition
                          WHERE BgPositionID_Parent = @HauptBgPositionID;

                        OPEN cDetailPos
                        FETCH NEXT FROM cDetailPos INTO @DetailBgPositionID
                        WHILE @@fetch_status = 0 BEGIN
                          SELECT @MainBgAuszahlungPersonID = BgAuszahlungPersonID
                          FROM dbo.BgAuszahlungPerson
                          WHERE BgPositionID = @HauptBgPositionID;

                          -- BgAuszahlungPerson
                          SET @WhereClause = 'BgAuszahlungPersonID = ' + CONVERT(VARCHAR, @MainBgAuszahlungPersonID);
                          EXEC dbo.spDuplicateRows 'BgAuszahlungPerson', @WhereClause, 'BgPositionID', @DetailBgPositionID;

                          -- BgAuszahlungPersonTermin
                          SET @WhereClause = 'BgAuszahlungPersonID = ' + CONVERT(VARCHAR, @MainBgAuszahlungPersonID);
                          EXEC dbo.spDuplicateRows 'BgAuszahlungPersonTermin', @WhereClause,'BgAuszahlungPersonID', @@identity;

                          FETCH NEXT FROM cDetailPos INTO @DetailBgPositionID;
                        END;

                        CLOSE cDetailPos;
                        DEALLOCATE cDetailPos;", qryBgPosition["BgPositionID"], qryBgPosition["BgBudgetID"], qryBgPosition["Bemerkung"]);
                }

                if (!qryBgDokumente.Post())
                {
                    tabBgPosition.SelectedTabIndex = 1;
                    throw new KissCancelException();
                }

                // successfully done
                Session.Commit();
            }
            catch (Exception ex)
            {
                // do rollback any changes
                Session.Rollback();

                // throw exception further on
                throw ex;
            }
            finally
            {
                // update enabled states of controls
                UpdateControlsAndStates();
            }
        }

        private void qryBgPosition_BeforeDelete(object sender, EventArgs e)
        {
            // (re)check concurrency
            CheckConcurrency();

            // do it
            DBUtil.ExecSQLThrowingException(@"
                DELETE TRM
                FROM dbo.BgAuszahlungPersonTermin TRM
                  INNER JOIN dbo.BgAuszahlungPerson AUS ON AUS.BgAuszahlungPersonID = TRM.BgAuszahlungPersonID
                WHERE AUS.BgPositionID = {0};

                DELETE FROM dbo.BgAuszahlungPerson
                WHERE BgPositionID = {0};

                DELETE FROM dbo.BgDokument
                WHERE BgPositionID = {0};

                DELETE dbo.BgBewilligung
                WHERE BgPositionID = {0}", qryBgPosition["BgPositionID"]);

            if (!DBUtil.IsEmpty(qryBgPosition["HauptPos"]))
            {
                DBUtil.ExecSQLThrowingException(@"
                    DELETE FROM dbo.BgPosition
                    WHERE BgPositionID_Parent = {0};", qryBgPosition["BgPositionID"]);
            }
        }

        private void qryBgPosition_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            // check if deleting is possible
            CheckCanDeletePosition(ref qryBgPosition);

            // check concurrency
            CheckConcurrency();
        }

        private void qryBgPosition_BeforeInsert(object sender, EventArgs e)
        {
            if (_newBgKategorieCode != 0)
            {
                return;
            }

            _newBgKategorieCode = DlgInsertNewKoA();
        }

        private void qryBgPosition_BeforePost(object sender, EventArgs e)
        {
            // check if BelegNr has changed (security, this should never occure)
            if (qryBgPosition.Row.RowState == DataRowState.Modified && qryBgPosition.ColumnModified(DBO.KbBuchung.BelegNr))
            {
                // logging
                XLog.Create(GetType().FullName, LogLevel.ERROR, "Modified BelegNr, property should be readonly.");

                // cancel post
                throw new KissErrorException(KissMsg.GetMLMessage(Name,
                                                                  "BeforePostCannotChangeBelegNr",
                                                                  "Die Beleg-Nr. darf nicht verändert werden, bitte Änderungen rückgängig machen."));
            }

            // get vars
            int positionStatus = ShUtil.GetCode(qryBgPosition["Status"]);
            int kategorie = ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgKategorieCode]);
            bool hauptPos = !DBUtil.IsEmpty(qryBgPosition["HauptPos"]);

            // check must fields
            DBUtil.CheckNotNullField(edtKlient, lblKlient.Text);
            DBUtil.CheckNotNullField(edtKostenart, lblKostenart.Text);
            DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext.Text);
            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);
            DBUtil.CheckNotNullField(edtAuszahlungsart, lblAuszahlungsart.Text);

            // validate BetragSpezial
            ValidateBetrag(ref qryBgPosition, ref edtBetrag, "BetragSpezial");

            if (!hauptPos)
            {
                qryBgPosition["Betrag"] = qryBgPosition["BetragSpezial"];
            }

            // validate Betrifft Person
            ValidateBetrifftPerson(ref qryBgPosition, ref edtBaPersonID);

            // Valutadatum
            DBUtil.CheckNotNullField(edtValutaDatum, lblValutaDatum.Text);
            qryBgPosition["ValutaDatum"] = edtValutaDatum.EditValue; // get pending edit changes

            // Falls user recht zur auswahl kreditoren besitzt, muss einer gewählt werden bei allen anderen als SIL-Antrag
            if (_userRightWhEinzelzahlungKreditor &&
                ShUtil.GetCode(qryBgPosition["KbAuszahlungsArtCode"]) != Convert.ToInt32(KbAuszahlungsArt.SILAntrag))
            {
                // Kreditor
                DBUtil.CheckNotNullField(edtKreditor, lblKreditor.Text);
            }

            // Referenznummer
            if (edtReferenzNummer.EditMode != EditModeType.ReadOnly)
            {
                DBUtil.CheckNotNullField(edtReferenzNummer, lblReferenzNummer.Text);

                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT PostKontoNummer
                    FROM dbo.BaZahlungsweg
                    WHERE BaZahlungswegID = {0};", qryBgPosition["BaZahlungswegID"]);

                if (qry.Count == 1 && !edtReferenzNummer.ValidateReferenzNummer(qry["PostKontoNummer"].ToString()))
                {
                    edtReferenzNummer.Focus();
                    throw new KissCancelException();
                }
            }

            // validate budget
            ValidateBudget(ref qryBgBudget);

            // validate VerwPeriode
            ValidateAndHandleVerwPeriode(ref qryBgPosition, ref edtVerwPeriodeVon, ref edtVerwPeriodeBis);

            // validate EZ
            ValidateAndHandleEinzelzahlung(ref qryBgPosition,
                                           ref edtBgSpezkontoID,
                                           ref lblBgSpezkontoID,
                                           ref edtBetrag,
                                           ShUtil.GetCode(qryBgBudget["FaLeistungID"]));

            // Check if the selected PositionArt is actually valid in the period of the selected Budget
            int? positionsartId = qryBgPosition[DBO.BgPosition.BgPositionsartID] as int?;
            if (positionsartId.HasValue)
            {
                int jahr = DBUtil.IsEmpty(qryBgBudget["Jahr"]) ? DateTime.Now.Year : (int)qryBgBudget["Jahr"];
                int monat = DBUtil.IsEmpty(qryBgBudget["Monat"]) ? DateTime.Now.Month : (int)qryBgBudget["Monat"];

                DateTime gueltigVon = new DateTime(jahr, monat, 1);
                DateTime gueltigBis = new DateTime(jahr, monat, 1).AddMonths(1).AddDays(-1);    // Ende des Monats ist ein Tag vor dem Anfang des nächsten Monats

                int count = (int)DBUtil.ExecuteScalarSQL(@"
                                SELECT COUNT(BgPositionsArtID)
                                FROM BgPositionsArt
                                WHERE BgPositionsArtID = {0}
                                  AND ISNULL(DatumVon, '19000101') <= {1} AND ISNULL(DatumBis, '99991231') >= {2}",
                                        positionsartId.Value, gueltigVon, gueltigBis);

                if (count == 0)
                {
                    edtKostenart.Focus();
                    throw new KissInfoException(string.Format("Die Positionsart {0} ist im ausgewählten Budget-Monat {1} {2} nicht durchgehend gültig. Bitte wählen Sie eine andere Positionsart.", edtKostenart.EditValue, monat, jahr));
                }
            }

            // apply further data
            qryBgPosition["BgBudgetID"] = qryBgBudget["BgBudgetID"];
            qryBgPosition["MA"] = Session.User.LogonName;

            // handle create/update-information
            ctlErfassungMutation.SetFields();

            // check concurrency (just before opening the transaction)
            CheckConcurrency();

            // do this in a transaction
            Session.BeginTransaction();

            try
            {
                // permission handling ZL >> will possibly create entries in BgBewilligung table
                ValidateAndHandleZLPermission(ref qryBgPosition, ref qryBgBudget, false, false, true);

                // check if need to insert new entry in history of BgBewilligung
                if (qryBgPosition.Row.RowState == DataRowState.Added &&
                    ((BgBewilligungStatus)Convert.ToInt32(qryBgPosition[DBO.BgPosition.BgBewilligungStatusCode])) == BgBewilligungStatus.Erteilt)
                {
                    // do insert new entry
                    _insertNewBewilligungHistoryErteilt = true;
                }
                else
                {
                    // do not insert new entry
                    _insertNewBewilligungHistoryErteilt = false;
                }
            }
            catch
            {
                // do rollback any changes already made
                Session.Rollback();

                // throw exception further on
                throw;
            }
        }

        private void qryBgPosition_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                // get current vars
                int status = ShUtil.GetCode(qryBgPosition["Status"]);
                int kategorie = ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgKategorieCode]);

                // set flag
                _isFilling = true;

                try
                {
                    switch (status)
                    {
                        case 0:
                            qryBgBudget.Fill(qryBgPosition["KlientID"], null);

                            try
                            {
                                while (Convert.ToInt32(qryBgBudget["Jahr"]) != DateTime.Now.Year ||
                                       Convert.ToInt32(qryBgBudget["Monat"]) != DateTime.Now.Month)
                                {
                                    if (!qryBgBudget.Next())
                                    {
                                        break;
                                    }
                                }
                            }
                            catch { }
                            break;

                        case 1:
                        case 12:
                        case 15:
                            qryBgBudget.Fill(qryBgPosition["KlientID"], null);

                            try
                            {
                                while (Convert.ToInt32(qryBgPosition["BgBudgetID"]) != Convert.ToInt32(qryBgBudget["BgBudgetID"]))
                                {
                                    if (!qryBgBudget.Next())
                                    {
                                        break;
                                    }
                                }
                            }
                            catch { }
                            break;

                        default:
                            qryBgBudget.Fill(qryBgPosition["KlientID"], qryBgPosition["BgBudgetID"]);
                            break;
                    }
                }
                finally
                {
                    _isFilling = false;
                }

                // update control
                ctlErfassungMutation.ShowInfo();

                // load pending data
                qryBgDokumente.Fill(qryBgPosition["BgPositionID"]);
                LoadBgBewilligung();

                if (kategorie == Convert.ToInt32(LOV.BgKategorieCode.Einzelzahlungen))
                {
                    LoadSpezialkonto(null);
                }

                LoadPerson();
            }
            finally
            {
                // update enabled states of controls
                UpdateControlsAndStates();
            }
        }

        private void qryBgPosition_PostCompleted(object sender, EventArgs e)
        {
            // init flag
            bool showGrantingDialog = false;
            bool auszahlungsArtUpdated = false;

            try
            {
                // get current id
                int bgPositionID = ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgPositionID]);

                // refresh view
                qryBgPosition.Refresh();

                // validate circumstances after refresh
                if (bgPositionID > 0 &&
                    !qryBgPosition.IsEmpty &&
                    ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgPositionID]) == bgPositionID)
                {
                    // same entry after refresh, perform check if we need to show granting dialog
                    if (ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgKategorieCode]) == Convert.ToInt32(LOV.BgKategorieCode.Zusaetzliche_Leistungen) &&
                        ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgBewilligungStatusCode]) == Convert.ToInt32(BgBewilligungStatus.InVorbereitung))
                    {
                        // we have saved a ZL with permission state "In Vorbereitung" >> automatically show permission-dialog
                        showGrantingDialog = true;

                        // #5478 (comment#26841): If the position requires permission, we have to set Auszahlungsart to "SIL-Antrag",
                        // otherwise it gets the state "Freigegeben" automatically once somebody gives the permission out of the Monatsbudget.
                        // But, the "Freigegeben" state has to be assigned manually to ensure it gets a correct Belegnummer.

                        // Caution: this method-call may cause another qryBgPosition.Post()!
                        auszahlungsArtUpdated = SetAuszahlungsArtToSILAntrag();
                    }
                }
            }
            finally
            {
                // refresh controls
                UpdateControlsAndStates();
            }

            // show granting dialog. We have to check whether the auszahlungsArt was updated to prevent the Bewilligung dialog from showing up twice
            if (showGrantingDialog && !auszahlungsArtUpdated)
            {
                try
                {
                    btnPositionBewilligung_Click(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError(Name, "ErrorDonePostShowGranting", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
                }
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Check if position can be deleted. If not, the corresponding message within a KissInfoException will be thrown.
        /// </summary>
        /// <param name="qryBgPosition">The reference of the query of BgPosition data</param>
        /// <exception cref="KissInfoException">Thrown with the message if position cannot be deleted</exception>
        public static void CheckCanDeletePosition(ref SqlQuery qryBgPosition)
        {
            int status = ShUtil.GetCode(qryBgPosition["Status"]);

            if (status != 1 && status != 12 && status != 14 && status != 15)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                 "OnlyGrayBluePosCanBeDeleted",
                                                                 "Nur graue/hellblaue Positionen können gelöscht werden!"));
            }

            // check if there are any corrsponding positions in klibu
            if (Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT COUNT(1)
                FROM dbo.KbBuchungKostenart BKA
                WHERE BKA.BgPositionID IN (SELECT POS.BgPositionID
                                           FROM dbo.BgPosition POS
                                           WHERE POS.BgPositionID = {0}
                                              OR POS.BgPositionID_Parent = {0});", qryBgPosition[DBO.BgPosition.BgPositionID])) > 0)
            {
                // cannot delete - there are already corresponding entries in KbBuchung
                throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                 "CannotDeleteFromKbBuchung_v01",
                                                                 "Das Löschen ist nicht möglich: Für diese Position gibt es bereits Einträge in der Klientenbuchhaltung."));
            }
        }

        /// <summary>
        /// Show dialog where user can select new cost category
        /// </summary>
        /// <returns>The code for the selected and confirmed cost category</returns>
        /// <exception cref="KissCancelException">Occures when user cancels selection</exception>
        public static int DlgInsertNewKoA()
        {
            KissLookupDialog dlg = new KissLookupDialog
            {
                Height = 250
            };

            if (!dlg.SearchData(string.Format(@"
                SELECT Code$  = 100,
                       Aktion = '{0} '  -- new ZL
                UNION
                SELECT Code$  = 101,
                       Aktion = '{1} '; -- new EZ", KissMsg.GetMLMessage(CLASSNAME, "DlgNeueZL", "Neue zusätzliche Leistung"),
                                                    KissMsg.GetMLMessage(CLASSNAME, "DlgNeueEZ", "Neue Einzelzahlung")),
                                                    "", true, null, null, null))
            {
                // cancel inserting new entry
                throw new KissCancelException();
            }

            // return code
            return Convert.ToInt32(dlg["Code$"]);
        }

        /// <summary>
        /// Get Auszahlungsart depending on current KlibuSystem:
        /// - Keine:  Papierverfuegung
        /// - !Keine: El.Auszahlung
        /// </summary>
        /// <returns>The KbAuszahlungsArt value depending on current KlibuSystem</returns>
        public static KbAuszahlungsArt GetAuszArtElAuszOrPaper()
        {
            if (HasKlibu())
            {
                return KbAuszahlungsArt.ElAuszahlung;
            }

            // no klibu
            return KbAuszahlungsArt.Papierverfuegung;
        }

        /// <summary>
        /// Get integer value of Auszahlungsart depending on current KlibuSystem:
        /// - Keine:  Papierverfuegung
        /// - !Keine: El.Auszahlung
        /// </summary>
        /// <returns>The KbAuszahlungsArt value depending on current KlibuSystem</returns>
        public static int GetAuszArtElAuszOrPaperInt()
        {
            return Convert.ToInt32(GetAuszArtElAuszOrPaper());
        }

        /// <summary>
        /// Get specific field value from datasource of special account control
        /// </summary>
        /// <param name="edtBgSpezkontoID">The control containing the datasource for accessing data of special account</param>
        /// <param name="bgSpezkontoID">The id of the special account</param>
        /// <param name="fieldName">The field name within the datasource of the control special account</param>
        /// <returns>The value for the given fieldname or null if nothing could be found</returns>
        public static object GetFieldFromSpezkonto(ref KissLookUpEdit edtBgSpezkontoID, object bgSpezkontoID, string fieldName)
        {
            SqlQuery qry;
            DataRow[] rows;
            qry = (SqlQuery)edtBgSpezkontoID.Properties.DataSource;

            if (DBUtil.IsEmpty(bgSpezkontoID))
            {
                rows = qry.DataTable.Select("Code IS NULL"); // Grundbedarf
            }
            else
            {
                rows = qry.DataTable.Select(string.Format("Code = {0}", bgSpezkontoID)); // Spezkonto
            }

            if (rows.Length == 1)
            {
                return rows[0][fieldName];
            }

            return null;
        }

        /// <summary>
        /// Evaluate Buchungstext after changed SpezKonto value
        /// </summary>
        /// <param name="oldEdtBuchungstext">The original text from control</param>
        /// <param name="oldSpezkontoBuchungstext">The original text from old, previous selected spezkonto</param>
        /// <param name="newSpezkontoBuchungstext">The original text from new, current selected spezkonto</param>
        /// <returns>The new text to apply to control</returns>
        public static string GetSpezKontoBuchungstext(
            string oldEdtBuchungstext,
            string oldSpezkontoBuchungstext,
            string newSpezkontoBuchungstext)
        {
            // if old-edt-buchungstext is same as buchungstext given from old spezkonto, we can overwrite it with new
            if (string.IsNullOrEmpty(oldEdtBuchungstext))
            {
                // just set new
                return newSpezkontoBuchungstext;
            }

            if (string.IsNullOrEmpty(oldSpezkontoBuchungstext))
            {
                // we cannot decide if changed due to spezkonto-changes, just return old
                return oldEdtBuchungstext;
            }

            if (oldEdtBuchungstext == oldSpezkontoBuchungstext)
            {
                // same as from old spezkonto, apply new text
                return newSpezkontoBuchungstext;
            }

            // changed text, return old
            return oldEdtBuchungstext;
        }

        /// <summary>
        /// Check if environment is setup to use Klibu or not
        /// </summary>
        /// <returns><c>True</c> if using klibu, otherwise <c>False</c></returns>
        public static bool HasKlibu()
        {
            string klibuSystem = DBUtil.GetConfigString(@"System\KliBu\KliBuSys", KEINKLIBUSYS);

            // validate value
            if (string.IsNullOrEmpty(klibuSystem) || klibuSystem.ToLower() == KEINKLIBUSYS)
            {
                // has no klibu
                return false;
            }

            // has klibu
            return true;
        }

        /// <summary>
        /// Insert new entry in BgBewilligung depending on given states
        /// </summary>
        /// <param name="bgPositionID">The id of the existing entry in BgPosition</param>
        /// <param name="currentStatus">The current state of the BgPosition entry</param>
        /// <param name="newStatus">The new state of the BgPosition entry</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown in case of unsupported state changing or wrong id</exception>
        public static void InsertGrantingHistory(int bgPositionID, BgBewilligungStatus currentStatus, BgBewilligungStatus newStatus)
        {
            // handle specific state changes
            if (currentStatus == newStatus)
            {
                // nothing to do
                return;
            }

            if (bgPositionID < 1)
            {
                // throw error
                throw new ArgumentOutOfRangeException("bgPositionID", "Invalid BgPositionID, cannot create new history entry in BgBewilligung.");
            }

            // init vars
            int bgBewilligungCode;
            bool zurueckgewiesen = false;

            // state depending entry
            if (currentStatus == BgBewilligungStatus.InVorbereitung && newStatus == BgBewilligungStatus.Angefragt)
            {
                // 1 >> 12
                bgBewilligungCode = 1; // Anfrage zur Bewilligung
            }
            else if (currentStatus == BgBewilligungStatus.InVorbereitung && newStatus == BgBewilligungStatus.Erteilt)
            {
                // 1 >> 14
                bgBewilligungCode = 2; // Bewilligung erteilt
            }
            else if (currentStatus == BgBewilligungStatus.Angefragt && newStatus == BgBewilligungStatus.Erteilt)
            {
                // 12 >> 14
                bgBewilligungCode = 2; // Bewilligung erteilt
            }
            else if (currentStatus == BgBewilligungStatus.Angefragt && newStatus == BgBewilligungStatus.Abgelehnt)
            {
                // 12 >> 15
                bgBewilligungCode = 3;  // Bewilligung abgelehnt
                zurueckgewiesen = true; // rejected
            }
            else if (currentStatus == BgBewilligungStatus.Angefragt && newStatus == BgBewilligungStatus.Gesperrt)
            {
                // 12 >> 9
                bgBewilligungCode = 3;  // Bewilligung abgelehnt
                zurueckgewiesen = true; // rejected
            }
            else if (currentStatus == BgBewilligungStatus.Angefragt && newStatus == BgBewilligungStatus.InVorbereitung)
            {
                // 12 >> 1
                bgBewilligungCode = 3;  // Bewilligung abgelehnt
                zurueckgewiesen = true; // rejected
            }
            else if (currentStatus == BgBewilligungStatus.Erteilt && newStatus == BgBewilligungStatus.InVorbereitung)
            {
                // 14 >> 1
                bgBewilligungCode = 4; // Bewilligung aufgehoben
            }
            else if (currentStatus == BgBewilligungStatus.Abgelehnt && newStatus == BgBewilligungStatus.Erteilt)
            {
                // 15 >> 14 (e.g. when amount was changed)
                bgBewilligungCode = 2; // Bewilligung erteilt
            }
            else if (currentStatus == BgBewilligungStatus.Gesperrt && newStatus == BgBewilligungStatus.Erteilt)
            {
                // 9 >> 14 (e.g. when amount was changed)
                bgBewilligungCode = 2; // Bewilligung erteilt
            }
            else
            {
                // throw error
                throw new ArgumentOutOfRangeException("currentStatus", "Permission history error: The given state values as parameters are not supported at the moment.");
            }

            // do insert entry into history
            DBUtil.ExecSQLThrowingException(@"
                INSERT INTO dbo.BgBewilligung (BgPositionID, UserID, Datum, BgBewilligungCode, Zurueckgewiesen)
                VALUES ({0}, {1}, GETDATE(), {2}, {3})", bgPositionID, Session.User.UserID, bgBewilligungCode, zurueckgewiesen);
        }

        /// <summary>
        /// Load data for special account and setup control
        /// </summary>
        /// <param name="edtBgSpezkontoID">The reference of the control for special account</param>
        /// <param name="qryBgPosition">The reference to the sql query used for BgPosition</param>
        /// <param name="qryBgBudget">The reference to thw sql query used for BgBudget</param>
        /// <param name="bgKostenartID">The value for BgKostenartID (if any)</param>
        /// <param name="baPersonID">The value for BaPersonID (if any)</param>
        public static void LoadSpezialkonto(
            ref KissLookUpEdit edtBgSpezkontoID,
            ref SqlQuery qryBgPosition,
            ref SqlQuery qryBgBudget,
            object bgKostenartID,
            object baPersonID)
        {
            edtBgSpezkontoID.Properties.ShowHeader = true;
            edtBgSpezkontoID.Properties.DropDownRows = 7;

            edtBgSpezkontoID.Properties.DataSource = DBUtil.OpenSQL(@"
                -- init vars
                DECLARE @FaLeistungID INT;
                DECLARE @WhGrundbedarfTypCode INT;
                DECLARE @BgBudgetID INT;
                DECLARE @BgKategorieCode INT;
                DECLARE @BgPositionID INT;
                DECLARE @BgKostenartID INT;
                DECLARE @BaPersonID INT;
                DECLARE @BgBudget_Jahr INT;
                DECLARE @BgBudget_Monat INT;
                DECLARE @BgSpezkontoID INT;

                -- fill vars with value from c#
                SET @FaLeistungID         = {0};
                SET @WhGrundbedarfTypCode = {1};
                SET @BgBudgetID           = {2};
                SET @BgKategorieCode      = {3};
                SET @BgPositionID         = {4};
                SET @BgKostenartID        = {5};
                SET @BaPersonID           = {6};
                SET @BgBudget_Jahr        = {7};
                SET @BgBudget_Monat       = {8};
                SET @BgSpezkontoID        = {9};

                SELECT *
                FROM
                (SELECT Code                = SPK.BgSpezkontoID,
                        TypCode             = SPK.BgSpezkontoTypCode,
                        Typ                 = TYP.ShortText,
                        KOA_S               = BKA.KontoNr,
                        KOA_H               = BPKA.KontoNr,
                        Text                = SPK.NameSpezkonto,
                        Saldo               = CASE
                                                WHEN @BgKategorieCode = 101 THEN dbo.fnBgSpezkonto(SPK.BgSpezkontoID, 4, @BgBudgetID, @BgPositionID)  -- Deckung
                                                ELSE dbo.fnBgSpezkonto(SPK.BgSpezkontoID, 3, @BgBudgetID, @BgPositionID)  -- Saldo
                                              END,
                        SortKey             = TYP.Sortkey,
                        KOAName             = BKA.KontoNr + ' ' + BKA.Name,
                        BaPersonID          = SPK.BaPersonID,
                        BgPositionsartID    = SPK.BgPositionsartID,
                        KOAPositionsart     = ISNULL(BPKA.KontoNr, BKA.KontoNr) + ' ' + ISNULL(BPA.Name, GBL.Name),
                        BgSplittingArtCode  = BKA.BgSplittingArtCode,
                        ProPerson           = BPA.ProPerson,
                        ProUE               = BPA.ProUE,
                        BaInstitutionID     = SPK.BaInstitutionID,
                        KreditorEingeschraenkt = BPA.KreditorEingeschraenkt
                 FROM dbo.BgSpezkonto            SPK
                   INNER JOIN dbo.XLOVCode       TYP  ON TYP.LOVName = 'BgSpezkontoTyp'
                                                     AND TYP.Code = SPK.BgSpezkontoTypCode
                   LEFT  JOIN dbo.BgPositionsart BPA  ON BPA.BgPositionsartID = SPK.BgPositionsartID
                   LEFT  JOIN dbo.BgPositionsart GBL  ON GBL.BgPositionsartID = @WhGrundbedarfTypCode
                   LEFT  JOIN dbo.BgKostenart    BKA  ON BKA.BgKostenartID = ISNULL(SPK.BgKostenartID, GBL.BgKostenartID)
                   LEFT  JOIN dbo.BgKostenart    BPKA ON BPKA.BgKostenartID = BPA.BgKostenartID
                 WHERE SPK.FaLeistungID = @FaLeistungID
                   AND ((@BgKategorieCode IN (2, 100)
                         AND (SPK.BgSpezkontoTypCode = 1
                         AND SPK.BgKostenartID = @BgKostenartID
                         AND COALESCE(SPK.BaPersonID, @BaPersonID, 0) = ISNULL(@BaPersonID, 0)))
                        OR (@BgKategorieCode IN (6) AND SPK.BgSpezkontoTypCode = 2)
                        OR (@BgKategorieCode IN (3) AND SPK.BgSpezkontoTypCode = 3)
                        OR (@BgKategorieCode IN (101) AND (SPK.BgSpezkontoTypCode <> 3 OR SPK.OhneEinzelzahlung = 0)))
                   AND (dbo.fnDateSerial(@BgBudget_Jahr,  @BgBudget_Monat ,1) <= IsNull(SPK.DatumBis, '99990101'))
                   AND SPK.AbschlussgrundCode IS NULL

                 UNION ALL

                 SELECT Code                = NULL,
                        TypCode             = NULL,
                        Typ                 = NULL,
                        KOA_S               = NULL,
                        KOA_H               = NULL,
                        Text                = NULL,
                        Saldo               = NULL,
                        SortKey             = 0,
                        KOAName             = BKA.KontoNr + ' ' + BKA.Name,
                        BaPersonID          = NULL,
                        BgPositionsartID    = BPA.BgPositionsartID,
                        KOAPositionsart     = BKA.KontoNr + ' ' + BPA.Name,
                        BgSplittingArtCode  = BKA.BgSplittingArtCode,
                        ProPerson           = BPA.ProPerson,
                        ProUE               = BPA.ProUE,
                        BaInstitutionID     = NULL,
                        KreditorEingeschraenkt = 0
                 FROM dbo.BgKostenart            BKA
                   INNER JOIN dbo.BgPositionsart BPA ON BPA.BgKostenartID = BKA.BgKostenartID
                 WHERE BPA.BgPositionsartID = @WhGrundbedarfTypCode
                ) QRY
                WHERE QRY.Saldo IS NULL
                   OR QRY.Saldo > 0.0
                   OR QRY.Code = @BgSpezkontoID
                ORDER BY QRY.SortKey, QRY.Text;", qryBgBudget["FaLeistungID"],          // {0}
                                                  qryBgBudget["WhGrundbedarfTypCode"],  // {1}
                                                  qryBgPosition["BgBudgetID"],          // {2}
                                                  qryBgPosition[DBO.BgPosition.BgKategorieCode],     // {3}
                                                  qryBgPosition["BgPositionID"],        // {4}
                                                  bgKostenartID,                        // {5}
                                                  baPersonID,                           // {6}
                                                  qryBgBudget["Jahr"],                  // {7}
                                                  qryBgBudget["Monat"],                 // {8}
                                                  qryBgPosition["BgSpezKontoID"]);      // {9}
        }

        /// <summary>
        /// Set Verwendungsperiode depending on current values
        /// </summary>
        /// <param name="qryBgPosition">The reference of the sql query of BgPosition</param>
        /// <param name="qryBgBudget">The reference of the sql query of BgBudget</param>
        /// <returns><c>True</c> if Verwendungsperiode was applied successfully, otherwise <c>False</c></returns>
        public static bool SetVerwendungsPeriode(ref SqlQuery qryBgPosition, ref SqlQuery qryBgBudget)
        {
            try
            {
                int bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);

                switch (bgSplittingArtCode)
                {
                    case 1: //Taggenau
                    case 2: //Monat
                        DateTime firstDate = new DateTime(Convert.ToInt32(qryBgBudget["Jahr"]), Convert.ToInt32(qryBgBudget["Monat"]), 1);
                        qryBgPosition["VerwPeriodeVon"] = firstDate;
                        qryBgPosition["VerwPeriodeBis"] = firstDate.AddMonths(1).AddDays(-1);
                        break;

                    case 3: //Valuta
                    case 4: //Entscheid
                        qryBgPosition["VerwPeriodeVon"] = DBNull.Value;
                        qryBgPosition["VerwPeriodeBis"] = DBNull.Value;
                        break;
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(CLASSNAME,
                                  "ErrorSettingVerwPeriode",
                                  "Es ist ein Fehler in der Verarbeitung der Verwendungsperiode aufgetreten.", ex);

                // failure
                return false;
            }

            // success
            return true;
        }

        /// <summary>
        /// Validate data for EZ and handle status if neccessary. Throws an exception if data is invalid.
        /// </summary>
        /// <param name="qryBgPosition">The reference to the sql query used for BgPosition</param>
        /// <param name="edtBgSpezkontoID">The reference to the control of special account</param>
        /// <param name="lblBgSpezkontoID">The reference to the label for the control of special account</param>
        /// <param name="edtBetrag">The reference for the control of amount</param>
        /// <param name="budgetFaLeistungID">The id within the table FaLeistung for current budget</param>
        /// <exception cref="KissInfoException">Thrown if a required value is empty</exception>
        public static void ValidateAndHandleEinzelzahlung(
            ref SqlQuery qryBgPosition,
            ref KissLookUpEdit edtBgSpezkontoID,
            ref KissLabel lblBgSpezkontoID,
            ref KissCalcEdit edtBetrag,
            int budgetFaLeistungID)
        {
            // check if EZ
            if (ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgKategorieCode]) != Convert.ToInt32(LOV.BgKategorieCode.Einzelzahlungen))
            {
                // no EZ, do not continue
                return;
            }

            // ONLY EZ:
            // SpezialKonto and > 0.00
            DBUtil.CheckNotNullField(edtBgSpezkontoID, lblBgSpezkontoID.Text);

            // reicht Saldo?
            decimal saldo = Convert.ToDecimal(GetFieldFromSpezkonto(ref edtBgSpezkontoID, qryBgPosition["BgSpezkontoID"], "Saldo"));
            decimal amount = Convert.ToDecimal(qryBgPosition["Betrag"]);

            if (amount > saldo)
            {
                edtBetrag.Focus();
                throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                 "NotEnoughMoneyOnSpecialAccount_v01",
                                                                 "Die Einzelzahlung kann nicht von diesem Spezialkonto abgebucht werden, da die Deckung des Spezialkontos (CHF {0:0.00}) nicht ausreicht.",
                                                                 saldo));
            }

            // saldo and amount are ok, get type of account
            int bgSpezkontoTypCode = Convert.ToInt32(GetFieldFromSpezkonto(ref edtBgSpezkontoID, qryBgPosition["BgSpezkontoID"], "TypCode"));

            // #6432: Gemäss Aussage von Conny Stucki ist dieser Check unerwünscht

            //////// check permissions on Vorabzugskonto
            //////if (bgSpezkontoTypCode == Convert.ToInt32(BgSpezkontoTyp.Vorabzugkonto))
            //////{
            //////    // validate
            //////    ValidateVorabzugskonto(amount, budgetFaLeistungID);
            //////}

            // set bewilligt status
            qryBgPosition["BgBewilligungStatusCode"] = Convert.ToInt32(BgBewilligungStatus.Erteilt);
            qryBgPosition["Status"] = 14;
        }

        /// <summary>
        /// Validate the Verwendungsperiode for the given data and apply "VerwPeriodeVon" for Valuta from "ValutaDatum".
        /// Throws an exception if data is invalid.
        /// </summary>
        /// <param name="qryBgPosition">The reference to the sql query used for BgPosition</param>
        /// <param name="edtVerwPeriodeVon">The reference to the control of VerwPeriodeVon</param>
        /// <param name="edtVerwPeriodeBis">The reference to the control of VerwPeriodeBis</param>
        /// <exception cref="KissInfoException">Thrown if a required value is empty</exception>
        public static void ValidateAndHandleVerwPeriode(
            ref SqlQuery qryBgPosition,
            ref KissDateEdit edtVerwPeriodeVon,
            ref KissDateEdit edtVerwPeriodeBis)
        {
            // Verwendungsperiode
            int bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);

            switch (bgSplittingArtCode)
            {
                case 1: // Taggenau
                case 2: // Monat
                    DBUtil.CheckNotNullField(edtVerwPeriodeVon, KissMsg.GetMLMessage(CLASSNAME,
                                                                                     "VerwPeriodeVon",
                                                                                     "Verwendungsperiode von"));
                    DBUtil.CheckNotNullField(edtVerwPeriodeBis, KissMsg.GetMLMessage(CLASSNAME,
                                                                                     "VerwPeriodeBis",
                                                                                     "Verwendungsperiode bis"));

                    if (Convert.ToDateTime(edtVerwPeriodeVon.EditValue) > Convert.ToDateTime(edtVerwPeriodeBis.EditValue))
                    {
                        edtVerwPeriodeVon.Focus();
                        throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                         "VerwPeriodeVonBisInvalid",
                                                                         "Das Datum 'Verwendungsperiode von' muss kleiner sein als 'Verwendungsperiode bis'!"));
                    }

                    break;

                case 3: // Valuta
                    qryBgPosition["VerwPeriodeVon"] = qryBgPosition["ValutaDatum"];
                    qryBgPosition["VerwPeriodeBis"] = qryBgPosition["ValutaDatum"];
                    break;

                case 4: // Entscheid
                    DBUtil.CheckNotNullField(edtVerwPeriodeVon, "Verwendungsperiode von");
                    break;
            }
        }

        /// <summary>
        /// Validate permissions for Zusaetzliche Leistungen and optionally handle status flags and logging
        /// </summary>
        /// <param name="qryBgPosition">The reference of the sqlquery for BgPosition</param>
        /// <param name="qryBgBudget">The reference of the sqlquery for BgBudget</param>
        /// <param name="checkWithoutModify">
        ///     <c>True</c> if no status or other data will be modified,
        ///     <c>False</c> if status will be set depending on current conditions
        /// </param>
        /// <param name="doNotUpdateQueryButDatabase">
        ///     Not important if <paramref name="checkWithoutModify"/> is set to <c>True</c>.
        ///     <c>True</c> if instead of modifications on sqlquery, the database content will be updated (do this only in a transaction!)
        ///     <c>False</c> if the sqlquery content will be updated, no direct modifications on database
        /// </param>
        /// <param name="doWriteHistoryEntries">
        ///     Not important if <paramref name="checkWithoutModify"/> is set to <c>True</c>.
        ///     <c>True</c> log changes on granting within table BaBewilligung
        ///     <c>False</c> changes on granting will not be logged
        /// </param>
        /// <exception cref="KissInfoException">Will be thrown if conditions are not valid and <paramref name="checkWithoutModify"/> is <c>False</c></exception>
        public static bool ValidateAndHandleZLPermission(
            ref SqlQuery qryBgPosition,
            ref SqlQuery qryBgBudget,
            bool checkWithoutModify,
            bool doNotUpdateQueryButDatabase,
            bool doWriteHistoryEntries)
        {
            #region Validation

            // validate positions
            if (qryBgPosition == null || qryBgPosition.IsEmpty)
            {
                if (checkWithoutModify)
                {
                    // only checking, so return without error
                    return false;
                }

                // is required, therefore error
                throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                 "ValidateZLPermissionNoPosition",
                                                                 "Die Kompetenzen können nicht validiert werden, es ist keine Position vorhanden."));
            }

            // validate budget
            if (qryBgBudget == null || qryBgBudget.IsEmpty)
            {
                if (checkWithoutModify)
                {
                    // only checking, so return without error
                    return false;
                }

                // is required, therefore error
                throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                 "ValidateZLPermissionNoBudget",
                                                                 "Die Kompetenzen können nicht validiert werden, es ist kein Budget vorhanden."));
            }

            #endregion

            #region Preparations for Permissionhandling

            // setup vars
            int status = ShUtil.GetCode(qryBgPosition["Status"]);
            int bgPositionID = ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgPositionID]);
            int bgPositionIDParent = ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgPositionID_Parent]);
            int bgPositionsartID = ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgPositionsartID]);
            int faLeistungID = Convert.ToInt32(qryBgBudget[DBO.FaLeistung.FaLeistungID]);

            // check kategorie
            if (ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgKategorieCode]) != Convert.ToInt32(LOV.BgKategorieCode.Zusaetzliche_Leistungen))
            {
                // no permission required here (SHAuszahlung and WeitereKoA: only ZL need permission)
                return true;
            }

            // get current amount from database
            decimal betragSumPositions = Convert.ToDecimal(DBUtil.ExecuteScalarSQLThrowingException(@"
                -- init vars
                DECLARE @Sum MONEY;
                DECLARE @BgPositionID INT;
                DECLARE @BgPositionIDParent INT;
                DECLARE @BgPositionsartID INT;

                -- setup vars from outer values
                SET @BgPositionID       = {0};
                SET @BgPositionIDParent = {1};
                SET @BgPositionsartID   = {2};

                -- validate
                SET @BgPositionID = ISNULL(@BgPositionID, -1);
                SET @BgPositionIDParent = ISNULL(@BgPositionIDParent, @BgPositionID);

                -- get sum
                SELECT @Sum = SUM(POS.Betrag)
                FROM dbo.BgPosition POS
                WHERE POS.BgPositionID <> @BgPositionID         -- do not handle current position as it might have changed
                  AND POS.BgPositionsartID = @BgPositionsartID  -- sum up only positions with same BgPositionartID
                  AND ((POS.BgPositionID_Parent IS NULL AND POS.BgPositionID = @BgPositionIDParent)   -- get main entry
                    OR (POS.BgPositionID_Parent = @BgPositionIDParent));                              -- get all child entries

                -- return value (at least 0.0 CHF)
                SELECT ISNULL(@Sum, 0.0);", bgPositionID, bgPositionIDParent, bgPositionsartID));

            // add amount of current row (maybe different to database value)
            betragSumPositions += Convert.ToDecimal(qryBgPosition[DBO.BgPosition.Betrag]);

            // init current bewilligungstatus
            BgBewilligungStatus currentBgBewilligungStatus;

            switch (status)
            {
                case 1:
                    currentBgBewilligungStatus = BgBewilligungStatus.InVorbereitung;
                    break;

                case 9:
                    currentBgBewilligungStatus = BgBewilligungStatus.Gesperrt;
                    break;

                case 12:
                    currentBgBewilligungStatus = BgBewilligungStatus.Angefragt;
                    break;

                case 14:
                    currentBgBewilligungStatus = BgBewilligungStatus.Erteilt;
                    break;

                case 15:
                    currentBgBewilligungStatus = BgBewilligungStatus.Abgelehnt;
                    break;

                default:
                    throw new InvalidOperationException("Status cannot be mapped to BgBewilligungsStatus, therefore cannot continue with validation.");
            }

            #endregion

            #region Permission

            // get permission
            bool userHasPermission = (betragSumPositions <= Convert.ToDecimal(DBUtil.GetUserSilPermission(bgPositionsartID, faLeistungID)));

            bool changeRequiresNewGrant = RequiresNewGrant(qryBgPosition);

            // check current mode (handle only existing entries!)
            if (qryBgPosition.Row.RowState != DataRowState.Added)
            {
                // current row should have a status
                if (status < 1)
                {
                    if (checkWithoutModify)
                    {
                        // invalid condition, do not continue
                        return false;
                    }

                    // is required, therefore error
                    throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                     "ValidateZLPermissionNoStatus",
                                                                     "Die Kompetenzen können nicht validiert werden, der Status der Position ist ungültig."));
                }

                // check if need to insert new log-entry
                // (user has no permission for existing entry, reset to vorbereitet if not having this state already)
                if (!checkWithoutModify &&
                    !userHasPermission &&
                    status != 1 &&
                    doWriteHistoryEntries &&
                    changeRequiresNewGrant)
                {
                    // create log-entry into Bewilligungs-History: "Zurückgewiesen" >> restart with "Vorbereitet"
                    InsertGrantingHistory(bgPositionID, currentBgBewilligungStatus, BgBewilligungStatus.InVorbereitung);
                }
            }

            // set new status vars
            int newStatus = userHasPermission ? 14 : 1;     // permission=14 (bewilligt), no permission=1 (vorbereitet)
            int bewilligungsStatusCode = userHasPermission ? Convert.ToInt32(BgBewilligungStatus.Erteilt) : Convert.ToInt32(BgBewilligungStatus.InVorbereitung);

            // check if need to insert new log-entry
            // (status has changed for existing entry or is new entry and bewilligt)
            if (!checkWithoutModify &&
                status != newStatus &&
                newStatus == 14 &&
                bgPositionID > 0 &&
                doWriteHistoryEntries &&
                changeRequiresNewGrant)
            {
                // create log-entry into Bewilligungs-History: Bewilligt
                InsertGrantingHistory(bgPositionID, currentBgBewilligungStatus, BgBewilligungStatus.Erteilt);
            }

            // apply new status if not only checking
            if (!checkWithoutModify)
            {
                #region Apply Modifications (DB or Query)

                // check mode
                if (doNotUpdateQueryButDatabase)
                {
                    // validate position
                    if (bgPositionID < 1)
                    {
                        // is required, therefore error
                        throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                         "ValidateZLPermissionUpdateDBNoID",
                                                                         "Die Kompetenzen können nicht angepasst werden, die Position hat keine gültige ID."));
                    }

                    // update data on database without modifications on sqlquery
                    DBUtil.ExecSQLThrowingException(@"
                        UPDATE POS
                        SET POS.BgBewilligungStatusCode = {1}
                        FROM dbo.BgPosition POS
                        WHERE POS.BgPositionID = {0};", bgPositionID, bewilligungsStatusCode);
                }
                else if (changeRequiresNewGrant)
                {
                    // apply values
                    qryBgPosition[DBO.BgPosition.BgBewilligungStatusCode] = bewilligungsStatusCode;
                    qryBgPosition["Status"] = newStatus;
                }

                #endregion
            }

            // return permission value
            return userHasPermission;

            #endregion
        }

        /// <summary>
        /// Validate amount. Throws an exception if amount is invalid.
        /// </summary>
        /// <param name="qryBgPosition">The reference of the sql query for BgPosition</param>
        /// <param name="edtBetrag">The reference of the control for the amount</param>
        /// <param name="fieldName">The name of the column to validate within the sql query for BgPosition</param>
        /// <exception cref="KissInfoException">Thrown if amount is invalid</exception>
        public static void ValidateBetrag(ref SqlQuery qryBgPosition, ref KissCalcEdit edtBetrag, string fieldName)
        {
            if (Convert.ToDecimal(qryBgPosition[fieldName]) <= Decimal.Zero)
            {
                edtBetrag.Focus();
                throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                 "AmountCannotBeZeroOrNegative",
                                                                 "Der Betrag darf nicht 0.00 oder negativ sein!"));
            }
        }

        /// <summary>
        /// Validate the BetrifftPerson for given data, throws an exception if data is invalid.
        /// </summary>
        /// <param name="qryBgPosition">The reference to the sql query used for BgPosition</param>
        /// <param name="edtBaPersonID">The reference to the control of selected person</param>
        /// <exception cref="KissInfoException">Thrown if a required value is empty</exception>
        public static void ValidateBetrifftPerson(ref SqlQuery qryBgPosition, ref KissLookUpEdit edtBaPersonID)
        {
            // validate Betrifft Person
            if (!DBUtil.IsEmpty(qryBgPosition["ProPerson"]) && !DBUtil.IsEmpty(qryBgPosition["ProUE"]))
            {
                bool proPerson = Convert.ToBoolean(qryBgPosition["ProPerson"]);
                bool proUE = Convert.ToBoolean(qryBgPosition["ProUE"]);

                if (proPerson && !proUE && DBUtil.IsEmpty(qryBgPosition["BaPersonID"]))
                {
                    edtBaPersonID.Focus();
                    throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                     "BetrifftPersonCannotBeEmptyForKoa_v01",
                                                                     "Das Feld 'Betrifft Person' darf für diese Kostenart nicht leer bleiben!"));
                }
            }
        }

        /// <summary>
        /// Validate the budget for given data, throws an exception if data is invalid.
        /// </summary>
        /// <param name="qryBgBudget">The reference to the sql query used for BgBudget</param>
        /// <exception cref="KissInfoException">Thrown if a required value is empty</exception>
        public static void ValidateBudget(ref SqlQuery qryBgBudget)
        {
            // Budgets are required
            if (qryBgBudget.Count == 0)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                 "NoAvailableBudgetForMandant",
                                                                 "Es gibt keine verfügbaren Budgets für diesen Mandanten!"));
            }

            // Budget has to be green
            if (ShUtil.GetCode(qryBgBudget["BgBewilligungStatusCode"]) != Convert.ToInt32(BgBewilligungStatus.Erteilt))
            {
                throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                 "BudgetHasToBeGreen",
                                                                 "Es können nur Auszahlungen in grüne Budgets erfasst werden!"));
            }
        }

        #endregion

        #region Public Methods

        void IBelegleser.ProcessBelegleser(Belegleser beleg)
        {
            if (qryBgPosition.Count == 0)
            {
                return;
            }

            int status = ShUtil.GetCode(qryBgPosition["Status"]);

            if (status != 1 && status != 12 && status != 14)
            {
                KissMsg.ShowInfo(Name,
                                 "NewDataFromReaderLocked",
                                 "Neue Daten vom Belegleser: Der Status der Position erlaubt keine Änderung der erfassten Daten");
                return;
            }

            DlgAuswahlBaZahlungsweg dlg = new DlgAuswahlBaZahlungsweg();
            ApplicationFacade.DoEvents();

            bool transfer = false;
            dlg.SucheBaZahlungsweg(beleg);

            switch (dlg.Count)
            {
                case 0:
                    KissMsg.ShowInfo(Name,
                                     "NoMatchingCreditorInInstitutions",
                                     "Keine zutreffenden Kreditor-Einträge im Institutionenstamm gefunden!");

                    if (beleg.Betrag > 0)
                    {
                        qryBgPosition["BetragSpezial"] = beleg.Betrag;
                    }

                    qryBgPosition["ReferenzNummer"] = beleg.ReferenzNummer;
                    break;

                case 1:
                    transfer = true;
                    break;

                default:
                    transfer = dlg.ShowDialog(this) == DialogResult.OK;
                    break;
            }

            if (transfer)
            {
                qryBgPosition["BaZahlungswegID"] = dlg["BaZahlungswegID"];
                qryBgPosition["Kreditor"] = dlg["Kreditor"];
                qryBgPosition["ZusatzInfo"] = dlg["ZusatzInfo"];

                if (beleg.Betrag > 0)
                {
                    qryBgPosition["BetragSpezial"] = beleg.Betrag;
                }

                qryBgPosition["ReferenzNummer"] = beleg.ReferenzNummer;
                qryBgPosition["EinzahlungsscheinCode"] = dlg["EinzahlungsscheinCode"];

                if (ShUtil.GetCode(qryBgPosition["KbAuszahlungsartCode"]) == Convert.ToInt32(KbAuszahlungsArt.SILAntrag))
                {
                    qryBgPosition["KbAuszahlungsartCode"] = _ezStandardAuszahlungsart;
                }
            }

            qryBgPosition.RefreshDisplay();
            SetEditMode();
        }

        public override bool OnAddData()
        {
            if (tabBgPosition.SelectedTab == tpgDokumente)
            {
                qryBgDokumente.Insert();
            }
            else
            {
                qryBgPosition.Insert();
            }

            return true;
        }

        public override bool OnDeleteData()
        {
            if (tabBgPosition.SelectedTab == tpgDokumente)
            {
                return qryBgDokumente.Delete();
            }

            return qryBgPosition.Delete();
        }

        public override bool OnSaveData()
        {
            if (tabBgPosition.SelectedTab == tpgDokumente)
            {
                return qryBgDokumente.Post();
            }
            else
            {
                return qryBgPosition.Post();
            }
        }

        /// <summary>
        /// Translates the components of the instance
        /// </summary>
        public override void Translate()
        {
            // first, let base do stuff
            base.Translate();

            // setup controls for multilanguage handling
            SetupControlsML();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            PresetSearchFields();

            edtSucheErfassungMA.Focus();
        }

        protected override void RunSearch()
        {
            base.RunSearch();

            if (qryBgPosition.Count == 0)
            {
                qryBgPosition_PositionChanged(null, null);
            }
            else
            {
                qryBgPosition.Last();
            }
        }

        #endregion

        #region Private Static Methods

        private static void DlgSucheMA(KissButtonEdit edt, ref UserModifiedFldEventArgs e)
        {
            string searchString = edt.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edt.EditValue = DBNull.Value;
                    edt.LookupID = DBNull.Value;
                    edt.ToolTip = "";
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();

            e.Cancel = !dlg.SearchData(@"
                SELECT [ID$]            = UserID,
                       [Kürzel]         = LogonName,
                       [Mitarbeiter/in] = NameVorname,
                       [Org.Einheit]    = OrgUnit,
                       [DisplayText$]   = DisplayText
                FROM dbo.vwUser WITH (READUNCOMMITTED)
                WHERE DisplayText LIKE '%' + {0} + '%'
                ORDER BY NameVorname;", searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edt.EditValue = dlg["Kürzel"];
                edt.LookupID = dlg["ID$"];
                edt.ToolTip = dlg["DisplayText$"].ToString();
            }
        }

        private static bool RequiresNewGrant(SqlQuery qryBgPosition)
        {
            //we need to grant the changes if a substantial change occurred: KoA or Betrag changed
            if (qryBgPosition.ColumnModified("Betrag") || qryBgPosition.ColumnModified("Kostenart"))
                return true;

            return false;
        }

        /// <summary>
        /// Validate permission for given amount for Vorabzugskonto.
        /// If validation failes, an exception will be thrown.
        /// </summary>
        /// <param name="amount">The amount to check</param>
        /// <param name="faLeistungID">The id in FaLeistung to use for getting the permission</param>
        /// <exception cref="KissInfoException">Thrown if validation failes</exception>
        private static void ValidateVorabzugskonto(decimal amount, int faLeistungID)
        {
            // get and validate permission
            object vorabzugskontoEz = DBUtil.GetUserPermission(Permission.Sh_StartsaldoVorabzugskonto, faLeistungID, null);

            if (vorabzugskontoEz == null)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                 "KompetenzNichtEingerichtet",
                                                                 "Die Kompetenz 'Sozialhilfe: Monatsbudget - max. Startsaldo eines Vorabzugskontos' muss zuerst für Sie eingerichtet werden.",
                                                                 KissMsgCode.MsgInfo));
            }

            decimal maxStartSaldo = Convert.ToDecimal(vorabzugskontoEz);

            if (amount > maxStartSaldo)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                 "KeineKompetenzStartsaldo",
                                                                 "Sie haben nicht die Kompetenz, einen Betrag von {0:n2} einzugeben.\r\nIhre Kompetenz liegt bei {1:n2}.",
                                                                 KissMsgCode.MsgInfo,
                                                                 amount,
                                                                 maxStartSaldo));
            }
        }

        #endregion

        #region Private Methods

        private void ApplyAction(BewilligungAktion aktion)
        {
            ApplyAction(null, aktion);
        }

        private void ApplyAction(DlgBewilligung dlg)
        {
            ApplyAction(dlg, dlg.Aktion);
        }

        private void ApplyAction(DlgBewilligung dlg, BewilligungAktion aktion)
        {
            Session.BeginTransaction();

            try
            {
                if (dlg != null && !dlg.ActiveSQLQuery.Post())
                {
                    throw new KissCancelException();
                }

                // Statusupdate auf BgPosition inkl Detailpositionen
                ShUtil.SetBewilligungStatusFromPosition(_bgPositionIDBewilligen,
                                                        DlgBewilligung.GetNextBewilligungStatus(aktion),
                                                        false);

                qryBgPosition.Refresh();

                Session.Commit();
            }
            catch (Exception ex)
            {
                // rollback changes
                Session.Rollback();

                // show error message
                KissMsg.ShowError(Name, "ErrorPositionBewilligen", "Es ist ein Fehler beim Bewilligen der Position(en) aufgetreten.", ex);

                // refresh
                qryBgPosition_PositionChanged(null, null);
                qryBgPosition.RefreshDisplay();
            }
        }

        private bool AuswahlKreditor(string searchString, bool buttonClicked)
        {
            bool cancel = false;
            searchString = searchString.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (buttonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgPosition["Kreditor"] = DBNull.Value;
                    qryBgPosition["ZusatzInfo"] = DBNull.Value;
                    qryBgPosition["BaZahlungswegID"] = DBNull.Value;
                    qryBgPosition["EinzahlungsscheinCode"] = DBNull.Value;
                    qryBgPosition["ReferenzNummer"] = DBNull.Value;

                    qryBgPosition.RefreshDisplay();
                    SetEditMode();
                    return false;
                }
            }

            int kategorie = Convert.ToInt32(qryBgPosition[DBO.BgPosition.BgKategorieCode]);
            bool kreditorEingeschraenkt = Utils.ConvertToBool(qryBgPosition["KreditorEingeschraenkt"]);

            if (searchString == "." || kreditorEingeschraenkt)
            {
                // Auszahlung an
                // Klientensystem            - FaFallPerson
                // Involvierte Institutionen - FaFallPerson / BaPerson_Institution
                // Institution aus SpezKonto
                DlgAuswahl dlg = new DlgAuswahl();

                int fallID = Utils.ConvertToInt(qryBgBudget["FaFallID"]);
                int? spezKontoID = qryBgPosition["BgSpezkontoID"] as int?;

                cancel = !dlg.SearchKreditor(fallID, spezKontoID, searchString, buttonClicked);

                if (!cancel)
                {
                    qryBgPosition["Kreditor"] = dlg["Kreditor$"];
                    qryBgPosition["ZusatzInfo"] = dlg["ZusatzInfo$"];
                    qryBgPosition["BaZahlungswegID"] = dlg["ID$"];
                    qryBgPosition["EinzahlungsscheinCode"] = dlg["ESCode$"];

                    if (kategorie == Convert.ToInt32(LOV.BgKategorieCode.Zusaetzliche_Leistungen) ||
                        kategorie == Convert.ToInt32(LOV.BgKategorieCode.Ausgaben))
                    {
                        qryBgPosition["BgSpezkontoID"] = DBNull.Value;
                    }

                    if (Convert.ToInt32(qryBgPosition["EinzahlungsscheinCode"]) != Convert.ToInt32(Einzahlungsschein.OrangerEinzahlungsschein))
                    {
                        qryBgPosition["ReferenzNummer"] = DBNull.Value;
                    }
                    else
                    {
                        qryBgPosition["ReferenzNummer"] = dlg["Referenznummer$"];
                        qryBgPosition["MitteilungZeile1"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile2"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile3"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile4"] = DBNull.Value;
                    }

                    qryBgPosition.RefreshDisplay();
                    SetEditMode();
                    return false;
                }
            }
            else // Auszahlung Dritte
            {
                if (!_userRightWhEinzelzahlungKreditor)
                {
                    return false;
                }

                DlgAuswahlBaZahlungsweg dlg2 = new DlgAuswahlBaZahlungsweg();
                ApplicationFacade.DoEvents();

                bool transfer = false;
                dlg2.SucheBaZahlungsweg(searchString);

                switch (dlg2.Count)
                {
                    case 0:
                        KissMsg.ShowInfo(Name,
                                         "NoMatchingCreditorInInstitutions",
                                         "Keine zutreffenden Kreditor-Einträge im Institutionenstamm gefunden!");
                        break;

                    case 1:
                        transfer = true;
                        break;

                    default:
                        transfer = dlg2.ShowDialog(this) == DialogResult.OK;
                        break;
                }

                if (transfer)
                {
                    SqlQuery qry2 = DBUtil.OpenSQL(@"
                        SELECT VornameName,
                               WohnsitzStrasseHausNr,
                               WohnsitzPLZOrt
                        FROM dbo.vwPerson WITH (READUNCOMMITTED)
                        WHERE BaPersonID = {0}", qryBgPosition["LeistungBaPersonID"]);

                    qryBgPosition["BaZahlungswegID"] = dlg2["BaZahlungswegID"];
                    qryBgPosition["Kreditor"] = dlg2["Kreditor"];
                    qryBgPosition["ZusatzInfo"] = dlg2["ZusatzInfo"];
                    qryBgPosition["EinzahlungsscheinCode"] = dlg2["EinzahlungsscheinCode"];
                    qryBgPosition["MitteilungZeile1"] = Utils.TruncateString(qry2["VornameName"], 35);

                    if (kategorie == Convert.ToInt32(LOV.BgKategorieCode.Zusaetzliche_Leistungen) ||
                        kategorie == Convert.ToInt32(LOV.BgKategorieCode.Ausgaben))
                    {
                        qryBgPosition["BgSpezkontoID"] = DBNull.Value;
                    }

                    if (Convert.ToInt32(qryBgPosition["EinzahlungsscheinCode"]) != Convert.ToInt32(Einzahlungsschein.OrangerEinzahlungsschein))
                    {
                        qryBgPosition["ReferenzNummer"] = DBNull.Value;
                    }
                    else
                    {
                        qryBgPosition["ReferenzNummer"] = dlg2["Referenznummer"];
                        qryBgPosition["MitteilungZeile1"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile2"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile3"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile4"] = DBNull.Value;
                    }
                }

                qryBgPosition.RefreshDisplay();
                SetEditMode();
            }

            return cancel;
        }

        /// <summary>
        /// Check if position can be granted by button "Bewilligen"
        /// </summary>
        /// <returns><c>True</c> if position can be granted, otherwise <c>False</c></returns>
        private bool CanGrantPosition()
        {
            // validate count and query state
            if (qryBgPosition.IsEmpty ||
                qryBgPosition.Row.RowState == DataRowState.Added ||
                DBUtil.IsEmpty(qryBgPosition[edtPositionID.DataMember]))
            {
                // no data
                return false;
            }

            // get some values
            int kategorie = ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgKategorieCode]);
            int status = ShUtil.GetCode(qryBgPosition["Status"]);
            int countChildPos = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT COUNT(1)
                FROM dbo.BgPosition
                WHERE BgPositionID_Parent = {0}", qryBgPosition[edtPositionID.DataMember]));

            // check if grant is possible
            if (kategorie != Convert.ToInt32(LOV.BgKategorieCode.Zusaetzliche_Leistungen) ||     // only ZL can be granted
                (status != 1 && status != 12 && status != 14 && status != 15) ||      // only some positions can be granted (vorbereitet, angefragt, bewilligt, zurueckgewiesen)
                countChildPos > 0)                                                    // positions with children can not be granted in this form
            {
                return false;
            }

            // if we are here, the position can be granted
            return true;
        }

        /// <summary>
        /// Check if position can be released by button "Freigeben"
        /// </summary>
        /// <returns><c>True</c> if position can be released, otherwise <c>False</c></returns>
        /// <remarks>See qryBgPosition_BeforePost(...) for further details!</remarks>
        private bool CanReleasePosition()
        {
            // validate count
            if (qryBgPosition.IsEmpty)
            {
                // no data
                return false;
            }

            // get some values
            int kategorie = ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgKategorieCode]);
            int bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);
            int status = ShUtil.GetCode(qryBgPosition["Status"]);

            // requires all required data to be given
            if (DBUtil.IsEmpty(qryBgPosition[edtAuszahlungsart.DataMember]) ||
                Convert.ToInt32(qryBgPosition[edtAuszahlungsart.DataMember]) == Convert.ToInt32(KbAuszahlungsArt.SILAntrag) ||

                DBUtil.IsEmpty(qryBgPosition[edtKlient.DataMember]) ||
                DBUtil.IsEmpty(qryBgPosition[edtKostenart.DataMember]) ||
                DBUtil.IsEmpty(qryBgPosition[edtBuchungstext.DataMember]) ||
                DBUtil.IsEmpty(qryBgPosition[edtBetrag.DataMember]) ||
                DBUtil.IsEmpty(qryBgPosition[edtValutaDatum.DataMember]) ||
                DBUtil.IsEmpty(qryBgPosition[edtKreditor.DataMember]) ||

                (edtReferenzNummer.EditMode != EditModeType.ReadOnly && DBUtil.IsEmpty(qryBgPosition[edtReferenzNummer.DataMember])) ||
                qryBgBudget.IsEmpty ||
                (kategorie == Convert.ToInt32(LOV.BgKategorieCode.Einzelzahlungen) && DBUtil.IsEmpty(qryBgPosition[edtBgSpezkontoID.DataMember])) ||
                (bgSplittingArtCode == 1 && (DBUtil.IsEmpty(qryBgPosition[edtVerwPeriodeVon.DataMember]) ||
                                             DBUtil.IsEmpty(qryBgPosition[edtVerwPeriodeBis.DataMember]))) ||
                (bgSplittingArtCode == 4 && DBUtil.IsEmpty(qryBgPosition[edtVerwPeriodeVon.DataMember])))
            {
                // we are missing some data
                return false;
            }

            // check current state (BelegID has to be given for security reason, Status == 14 (Bewilligt > LOV:KbBuchungsStatus) and no BelegNr is set yet)
            if (DBUtil.IsEmpty(qryBgPosition[edtPositionID.DataMember]) ||
                status != 14 ||
                !DBUtil.IsEmpty(qryBgPosition[edtBelegNr.DataMember]))
            {
                // wrong conditions
                return false;
            }

            // if we are here, the position can be released
            return true;
        }

        /// <summary>
        /// Check if position can be reset by button "Graustellen"
        /// </summary>
        /// <returns><c>True</c> if position can be reset, otherwise <c>False</c></returns>
        /// <remarks>See qryBgPosition_BeforePost(...) for further details!</remarks>
        private bool CanResetPosition()
        {
            // validate count
            if (qryBgPosition.IsEmpty)
            {
                // no data
                return false;
            }

            // get some values
            int status = ShUtil.GetCode(qryBgPosition["Status"]);
            int budgetBewilligung = ShUtil.GetCode(qryBgBudget[DBO.BgBudget.BgBewilligungStatusCode]);

            // check current state (Status = freigegeben or ZahlauftragFehlerhaft and budget is red or green)
            if (status != 2 && status != 5 ||
                budgetBewilligung != 5 && budgetBewilligung != 9)
            {
                return false;
            }

            // if we are here, the position can be reset
            return true;
        }

        /// <summary>
        /// Check concurrency for datamodifications by other users
        /// </summary>
        /// <exception cref="DBConcurrencyException">Thrown if concurrency problems were detected</exception>
        private void CheckConcurrency()
        {
            if (!CheckConcurrencyTS())
            {
                // logging
                XLog.Create(GetType().FullName, LogLevel.INFO, "Concurrency error prevented, throwing error to user.");

                // throw error
                throw new DBConcurrencyException(KissMsg.GetMLMessage(Name,
                                                                      "CheckConcurrencyError",
                                                                      "Es ist eine Parallelitätsverletzung aufgetreten. Wahrscheinlich wurden die Daten inzwischen bereits verändert oder gelöscht. Bitte aktualisieren Sie die Ansicht zuerst."));
            }
        }

        /// <summary>
        /// Check concurrency for datamodifications by other users validating various TS columns
        /// </summary>
        /// <returns><c>True</c> if data seems to be valid, otherwise <c>False</c></returns>
        private bool CheckConcurrencyTS()
        {
            // validate
            if (qryBgPosition.IsEmpty || qryBgPosition.Row.RowState == DataRowState.Added)
            {
                // no data or new entry, do not check concurrency
                return true;
            }

            // check BgPositionTS (only if not new entry!)
            if (!CheckConcurrencyTS(DBO.BgPosition.DBOName, DBO.BgPosition.BgPositionTS, false))
            {
                // invalid
                return false;
            }

            // check BgBudgetTS
            if (!CheckConcurrencyTS(DBO.BgBudget.DBOName, DBO.BgBudget.BgBudgetTS, false))
            {
                // invalid
                return false;
            }

            // BgFinanzplanTS
            if (!CheckConcurrencyTS(DBO.BgFinanzplan.DBOName, DBO.BgFinanzplan.BgFinanzplanTS, false))
            {
                // invalid
                return false;
            }

            // FaLeistungTS
            if (!CheckConcurrencyTS(DBO.FaLeistung.DBOName, DBO.FaLeistung.FaLeistungTS, false))
            {
                // invalid
                return false;
            }

            // KbBuchungTS
            if (!CheckConcurrencyTS(DBO.KbBuchung.DBOName, DBO.KbBuchung.KbBuchungTS, true))
            {
                // invalid
                return false;
            }

            // if we are here, everything is ok
            return true;
        }

        private bool CheckConcurrencyTS(string tableName, string columnName, bool allowNoTimestamp)
        {
            if (!DBUtil.IsEmpty(qryBgPosition[columnName]))
            {
                byte[] ts = qryBgPosition[columnName] as byte[];

                // no timestamp is allowed
                if (allowNoTimestamp && ts != null && ts.Length == 0)
                {
                    return true;
                }

                // check if timestamp within table still exists (unique within database)
                return Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                    IF (EXISTS (SELECT TOP 1 1
                                FROM dbo." + tableName + @" WITH (READUNCOMMITTED)
                                WHERE " + columnName + @" = {0}))
                    BEGIN
                      SELECT 1;  -- valid;
                    END
                    ELSE
                    BEGIN
                      SELECT 0;  -- invalid
                    END;", qryBgPosition[columnName]));
            }

            // no timestamp, expected value for given row!
            return false;
        }

        /// <summary>
        /// Enable or disable button bewilligen depending on current states
        /// </summary>
        private void EnableBtnBewilligen()
        {
            btnPositionBewilligung.Enabled = CanGrantPosition();
        }

        /// <summary>
        /// Enable or disable button freigeben depending on current states
        /// </summary>
        private void EnableBtnFreigeben()
        {
            // handle button Freigeben
            btnFreigeben.Enabled = CanReleasePosition();
        }

        /// <summary>
        /// Enable or disable button Graustellen depending on current states
        /// </summary>
        private void EnableBtnGraustellen()
        {
            // handle button Graustellen
            btnGraustellen.Enabled = CanResetPosition();
        }

        /// <summary>
        /// Enable or disable button WeitereKoA depending on current states
        /// </summary>
        private void EnableBtnWeitereKoA()
        {
            int status = ShUtil.GetCode(qryBgPosition["Status"]);
            bool hauptPos = !DBUtil.IsEmpty(qryBgPosition["HauptPos"]);
            bool editable = (status <= 1 || status == 12 || status == 14 || status == 15);

            // handle button WeitereKoA
            btnWeitereKOA.Enabled = qryBgPosition.Count > 0 &&
                                    qryBgPosition.Row.RowState != DataRowState.Added &&
                                    (editable || hauptPos);
        }

        /// <summary>
        /// Enable or disable tabpage of documents depending on current states
        /// </summary>
        private void EnableTpgDocuments()
        {
            // BgPositionID and entry in BgBudget is required
            bool canHandleDocs = !DBUtil.IsEmpty(qryBgPosition["BgPositionID"]) && qryBgBudget.Count > 0;

            // setup tpg
            tpgDokumente.Enabled = canHandleDocs;
        }

        /// <summary>
        /// Get specific field value from datasource of special account control
        /// </summary>
        /// <param name="bgSpezkontoID">The id of the special account</param>
        /// <param name="fieldName">The field name within the datasource of the control special account</param>
        /// <returns>The value for the given fieldname or null if nothing could be found</returns>
        private object GetFieldFromSpezkonto(object bgSpezkontoID, string fieldName)
        {
            return GetFieldFromSpezkonto(ref edtBgSpezkontoID, bgSpezkontoID, fieldName);
        }

        private bool GetUserPermissionZL()
        {
            return ValidateAndHandleZLPermission(ref qryBgPosition, ref qryBgBudget, true, false, false);
        }

        private void LoadBgBewilligung()
        {
            // fill query
            qryBgBewilligung.Fill(qryBgPosition["BgPositionID"]);

            // clear grouping
            grvBgBewilligung.ClearGrouping();

            // do grouping
            colBbwGrouper.Group();

            // expand all groups
            grvBgBewilligung.ExpandAllGroups();
        }

        private void LoadPerson()
        {
            edtBaPersonID.LoadQuery(DBUtil.OpenSQL(@"
                SELECT Code = FPP.BaPersonID,
                       Text = PRS.NameVorname +
                              ' (' + ISNULL(CONVERT(VARCHAR, PRS.AlterMortal), '-') +
                              ISNULL(',' + GES.ShortText,'') + ')'
                FROM dbo.BgFinanzPlan_BaPerson FPP
                  INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = FPP.BaPersonID
                  LEFT  JOIN dbo.XLOVCode GES ON GES.LOVName = 'BaGeschlecht'
                                             AND GES.Code = PRS.GeschlechtCode
                WHERE BgFinanzplanID = {0}
                  AND IstUnterstuetzt = 1
                ORDER BY PRS.NameVorname;", qryBgBudget["BgFinanzplanID"]));
        }

        private void LoadSpezialkonto(object bgKostenartID)
        {
            LoadSpezialkonto(bgKostenartID, qryBgPosition["baPersonID"]);
        }

        /// <summary>
        /// Load data for special account and setup control
        /// </summary>
        /// <param name="bgKostenartID">The value for BgKostenartID (if any)</param>
        /// <param name="baPersonID">The value for BaPersonID (if any)</param>
        private void LoadSpezialkonto(object bgKostenartID, object baPersonID)
        {
            LoadSpezialkonto(ref edtBgSpezkontoID, ref qryBgPosition, ref qryBgBudget, bgKostenartID, baPersonID);
        }

        private void PresetSearchFields()
        {
            edtSucheErfassungMA.EditValue = Session.User.LogonName;
            edtSucheErfassungMA.LookupID = Session.User.UserID;
            edtSucheSelectTop.EditValue = 100; // max 100 entries
        }

        /// <summary>
        /// Release current selected position (Auszahlung freigeben)
        /// </summary>
        private void ReleasePosition()
        {
            // validate first
            if (!CanReleasePosition())
            {
                throw new KissInfoException(KissMsg.GetMLMessage(Name,
                                                                 "CannotReleasePositionPreRequirements",
                                                                 "Die Position kann nicht freigegeben werden, da nicht alle Daten und Vorbedingungen erfüllt sind."));
            }

            // save data on query to ensure proper state
            if (!qryBgPosition.Post())
            {
                throw new KissInfoException(KissMsg.GetMLMessage(Name,
                                                                 "CannotReleasePositionSaveChanges_v01",
                                                                 "Die Position kann nicht freigegeben werden, da die Änderungen der aktuellen Position nicht gespeichert werden können."));
            }

            // do release item, get required values
            int positionBewilligung = ShUtil.GetCode(qryBgPosition["BgBewilligungStatusCode"]);
            int budgetBewilligung = ShUtil.GetCode(qryBgBudget["BgBewilligungStatusCode"]);
            int kategorie = ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgKategorieCode]);

            // im grünen Monatsbudget: bewilligte, graue Zusatzleistung oder Einzelzahlung auf grün stellen
            if (budgetBewilligung == Convert.ToInt32(BgBewilligungStatus.Erteilt) &&
                ((kategorie == Convert.ToInt32(LOV.BgKategorieCode.Zusaetzliche_Leistungen) &&
                  positionBewilligung == Convert.ToInt32(BgBewilligungStatus.Erteilt)) ||
                 kategorie == Convert.ToInt32(LOV.BgKategorieCode.Einzelzahlungen)))
            {
                // do it in transaction
                Session.BeginTransaction();

                try
                {
                    // check concurrency
                    CheckConcurrency();

                    // init required vars
                    int bgPositionID = ShUtil.GetCode(qryBgPosition["BgPositionID"]);
                    int bgBudgetID = ShUtil.GetCode(qryBgBudget["BgBudgetID"]);

                    // insert into klibu
                    DBUtil.ExecSQLThrowingException(@"
                        EXEC dbo.spWhBudget_CreateKbBuchung {0}, {1}, 0, NULL, {2};", bgBudgetID, Session.User.UserID, bgPositionID);

                    int? newBelegNr = null;
                    int? kbBelegKreisId = null;

                    if (_ezStandardAuszahlungsart != (int)KbAuszahlungsArt.Papierverfuegung)
                    {
                        newBelegNr = ShUtil.GetNewBelegNr(bgBudgetID, bgPositionID, out kbBelegKreisId);
                    }

                    // update BelegNr on KbBuchung depending on BgPositionID and new number
                    int rowCountBuc = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                        UPDATE dbo.KbBuchung
                        SET BelegNr = {0},
                            KbBelegKreisID = {2}
                        WHERE BelegNr IS NULL           -- security (do never overwrite an existing BelegNr)
                          AND KbBuchungStatusCode = 2   -- Freigegeben
                          AND KbBuchungID IN (SELECT KbBuchungID
                                              FROM dbo.KbBuchungKostenart
                                              WHERE BgPositionID = {1});

                        SELECT @@ROWCOUNT;", newBelegNr, bgPositionID, kbBelegKreisId));

                    // validate
                    if (rowCountBuc < 1)
                    {
                        throw new KissInfoException(KissMsg.GetMLMessage(Name,
                                                                         "ReleaseNoEntryUpdated",
                                                                         "Es wurde keine Buchung zum Freigeben gefunden."));
                    }

                    // finally, update display
                    qryBgPosition["Status"] = 2; // freigegeben
                    qryBgPosition[edtBelegNr.DataMember] = newBelegNr;

                    // accept changes
                    qryBgPosition.Row.AcceptChanges();
                    qryBgPosition.RowModified = false;

                    // do commit
                    Session.Commit();

                    SetEditMode();
                    qryBgPosition.RefreshDisplay();
                }
                catch (Exception ex)
                {
                    if (Session.Transaction != null)
                    {
                        // rollback changes
                        Session.Rollback();
                    }

                    // undo changes on current row!
                    qryBgPosition.Row.RejectChanges();
                    qryBgPosition.RefreshDisplay();

                    // create new message
                    throw new KissInfoException(KissMsg.GetMLMessage(Name,
                                                                     "ErrorInGreeningPosition",
                                                                     "Es ist ein Fehler beim Grünstellen der Position aufgetreten:\r\n\r\n{0}", ex.Message), ex);
                }
            }
            else
            {
                // prevent changing state to released in this case
                throw new KissInfoException(KissMsg.GetMLMessage(Name,
                                                                 "CannotReleasePositionStatus",
                                                                 "Die Position kann nicht freigegeben werden, da der Bewilligungstatus der Position und/oder des Budgets im Zusammenhang mit der Kategorie dies verhindern."));
            }
        }

        private void ResetPosition()
        {
            // validate first
            if (!CanResetPosition())
            {
                throw new KissInfoException(KissMsg.GetMLMessage(Name,
                                                                 "CannotResetPositionPreRequirements",
                                                                 "Die Position kann nicht grau gestellt werden, da nicht alle Daten und Vorbedingungen erfüllt sind."));
            }

            // do it in transaction
            Session.BeginTransaction();

            try
            {
                // check concurrency
                CheckConcurrency();

                // init required vars
                int bgPositionID = ShUtil.GetCode(qryBgPosition["BgPositionID"]);
                int? belegNr = qryBgPosition["BelegNr"] as int?;
                int? kbPeriodeID = DBUtil.ExecuteScalarSQLThrowingException(@"
                        SELECT KbPeriodeID, *
                        FROM KbBuchung
                        WHERE KbBuchungID = (SELECT TOP 1 KbBuchungID
                                             FROM KbBuchungKostenart
                                             WHERE BgPositionID = {0});",
                    bgPositionID
                ) as int?;

                // validate PeriodeID
                if (!kbPeriodeID.HasValue)
                {
                    throw new KissCancelException(KissMsg.GetMLMessage(CLASSNAME,
                                                                       "CouldNotGetPeriodeIDForPosition",
                                                                       "Es konnte keine gültige KbPeriodeID anhand des gewählte Position gefunden werden."));
                }

                // Recycle BelegNr
                if (belegNr.HasValue)
                {
                    DBUtil.ExecSQLThrowingException(@"
                            EXEC spKbRecycleBelegNr {0}, 4, NULL, {1};",
                        kbPeriodeID.Value,
                        belegNr
                    );
                }

                // Position graustellen
                DBUtil.ExecSQLThrowingException(@"
                        DECLARE @KbBuchungIDList TABLE (KbBuchungID INT);

                        INSERT @KbBuchungIDList
                        SELECT distinct BKO.KbBuchungID
                        FROM dbo.KbBuchungKostenart BKO WITH (READUNCOMMITTED)
                          INNER JOIN KbBuchung BUC ON BUC.KbBuchungID = BKO.KbBuchungID
                        WHERE BKO.BgPositionID = {0}
                          AND BUC.KbBuchungStatusCode IN (2,5);

                        DELETE dbo.KbBuchungKostenart
                        WHERE KbBuchungID IN (SELECT KbBuchungID FROM @KbBuchungIDList);

                        DELETE dbo.KbBuchung
                        WHERE KbBuchungID IN (SELECT KbBuchungID FROM @KbBuchungIDList);",
                    bgPositionID
                );

                // finally, update display
                qryBgPosition["Status"] = 14; // bewilligt
                qryBgPosition[edtBelegNr.DataMember] = null;

                // accept changes
                qryBgPosition.Row.AcceptChanges();
                qryBgPosition.RowModified = false;

                // do commit
                Session.Commit();

                SetEditMode();
                qryBgPosition.RefreshDisplay();
            }
            catch (Exception ex)
            {
                if (Session.Transaction != null)
                {
                    // rollback changes
                    Session.Rollback();
                }

                // undo changes on current row!
                qryBgPosition.Row.RejectChanges();
                qryBgPosition.RefreshDisplay();

                // create new message
                throw new KissInfoException(KissMsg.GetMLMessage(Name,
                                                                 "ErrorInGraustellenPosition",
                                                                 "Es ist ein Fehler beim Graustellen der Position aufgetreten:\r\n\r\n{0}", ex.Message), ex);
            }
        }

        private bool SetAuszahlungsArtToSILAntrag()
        {
            bool auszahlungsArtUpdated = false;
            //only update the record if it's not already set to SILAntrag
            if (ShUtil.GetCode(qryBgPosition["KbAuszahlungsArtCode"]) != Convert.ToInt32(KbAuszahlungsArt.SILAntrag))
            {
                KissMsg.ShowInfo("CtlWhAuszahlungen", "BewilligungspflichtigSILAntrag", string.Format("Die Auszahlung ist bewilligungspflichtig. Auszahlungsart wird auf 'SIL-Antrag' gesetzt."));
                qryBgPosition["KbAuszahlungsArtCode"] = KbAuszahlungsArt.SILAntrag;
                qryBgPosition.Post();
                auszahlungsArtUpdated = true;
            }
            return auszahlungsArtUpdated;
        }

        private void SetEditMode()
        {
            int kategorie = ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgKategorieCode]);
            int status = ShUtil.GetCode(qryBgPosition["Status"]);
            int esCode = ShUtil.GetCode(qryBgPosition["EinzahlungsscheinCode"]);
            int auszahlungsTermin = ShUtil.GetCode(qryBgPosition["BgAuszahlungsTerminCode"]);
            int bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);
            bool hauptPos = !DBUtil.IsEmpty(qryBgPosition["HauptPos"]);
            bool editable = (status <= 1 || status == 12 || status == 14 || status == 15);

            qryBgPosition.EnableBoundFields(editable);

            // Verwendungsperiode + Splitting
            switch (bgSplittingArtCode)
            {
                case 1: //Taggenau
                case 2: //monat
                    edtVerwPeriodeVon.EditMode = editable && !hauptPos ? EditModeType.Normal : EditModeType.ReadOnly;
                    edtVerwPeriodeBis.EditMode = editable && !hauptPos ? EditModeType.Normal : EditModeType.ReadOnly;
                    break;

                case 4: //Entscheid
                    edtVerwPeriodeVon.EditMode = editable && !hauptPos ? EditModeType.Normal : EditModeType.ReadOnly;
                    edtVerwPeriodeBis.EditMode = EditModeType.ReadOnly;
                    break;

                default:
                    edtVerwPeriodeVon.EditMode = EditModeType.ReadOnly;
                    edtVerwPeriodeBis.EditMode = EditModeType.ReadOnly;
                    break;
            }

            edtKostenart.EditMode = editable && !hauptPos && (kategorie == Convert.ToInt32(LOV.BgKategorieCode.Zusaetzliche_Leistungen)) ? EditModeType.Required : EditModeType.ReadOnly;
            edtBuchungstext.EditMode = editable && !hauptPos ? EditModeType.Required : EditModeType.ReadOnly;
            edtBetrag.EditMode = editable && !hauptPos ? EditModeType.Required : EditModeType.ReadOnly;
            edtBgSpezkontoID.EditMode = editable && !hauptPos && (kategorie == Convert.ToInt32(LOV.BgKategorieCode.Einzelzahlungen)) ? EditModeType.Required : EditModeType.ReadOnly;

            edtKreditor.EditMode = editable ? EditModeType.Required : EditModeType.ReadOnly;
            edtReferenzNummer.EditMode = (esCode == 1) && editable ? EditModeType.Normal : EditModeType.ReadOnly;
            edtMitteilungZeile1.EditMode = ((esCode == 2) || (esCode == 3) || (esCode == 5)) && editable ? EditModeType.Normal : EditModeType.ReadOnly;
            edtMitteilungZeile2.EditMode = edtMitteilungZeile1.EditMode;
            edtMitteilungZeile3.EditMode = edtMitteilungZeile1.EditMode;

            if (!DBUtil.IsEmpty(qryBgPosition["ProPerson"]) && !DBUtil.IsEmpty(qryBgPosition["ProUE"]))
            {
                bool proPerson = Convert.ToBoolean(qryBgPosition["ProPerson"]);
                bool proUE = Convert.ToBoolean(qryBgPosition["ProUE"]);

                edtBaPersonID.EditMode = editable && !hauptPos && (proPerson || !proUE) ? EditModeType.Normal : EditModeType.ReadOnly;
            }
            else
            {
                edtBaPersonID.EditMode = EditModeType.ReadOnly;
            }
        }

        private void SetSpezialkonto()
        {
            object bgSpezKontoID = qryBgPosition["BgSpezKontoID"];
            object baPersonID;
            int kategorie = Convert.ToInt32(qryBgPosition[DBO.BgPosition.BgKategorieCode]);

            switch (kategorie)
            {
                case (int)LOV.BgKategorieCode.Einzelzahlungen:  //Einzelzahlung
                    baPersonID = GetFieldFromSpezkonto(bgSpezKontoID, "BaPersonID");

                    qryBgPosition[DBO.BgPosition.BgPositionsartID] = GetFieldFromSpezkonto(bgSpezKontoID, "BgPositionsartID");
                    qryBgPosition["Kostenart"] = GetFieldFromSpezkonto(bgSpezKontoID, "KOAPositionsart");
                    qryBgPosition["BgSplittingArtCode"] = GetFieldFromSpezkonto(bgSpezKontoID, "BgSplittingArtCode");
                    qryBgPosition["ProPerson"] = GetFieldFromSpezkonto(bgSpezKontoID, "ProPerson");
                    qryBgPosition["ProUE"] = GetFieldFromSpezkonto(bgSpezKontoID, "ProUE");
                    qryBgPosition["KreditorEingeschraenkt"] = GetFieldFromSpezkonto(bgSpezKontoID, "KreditorEingeschraenkt");

                    // set Buchungstext
                    qryBgPosition["Buchungstext"] = GetSpezKontoBuchungstext(Convert.ToString(qryBgPosition["Buchungstext"]),
                                                                             Convert.ToString(GetFieldFromSpezkonto(_oldBgSpezkontoID, "Text")),
                                                                             Convert.ToString(GetFieldFromSpezkonto(bgSpezKontoID, "Text")));

                    // go on...
                    SetVerwendungsPeriode();

                    if (!DBUtil.IsEmpty(baPersonID))
                    {
                        qryBgPosition["BaPersonID"] = baPersonID;
                    }

                    // falls Spezialkonto an eine Institution gebunden ist: Zahlweg einrichten
                    object baInstitutionID = GetFieldFromSpezkonto(bgSpezKontoID, "BaInstitutionID");

                    if (!DBUtil.IsEmpty(baInstitutionID))
                    {
                        qryBgPosition["ReferenzNummer"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile1"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile2"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile3"] = DBNull.Value;

                        SqlQuery qry = DBUtil.OpenSQL(@"
                            SELECT *
                            FROM dbo.vwKreditor
                            WHERE BaInstitutionID = {0};", baInstitutionID);

                        if (qry.Count == 1)
                        {
                            qryBgPosition["Kreditor"] = qry["Kreditor"];
                            qryBgPosition["ZusatzInfo"] = qry["ZusatzInfo"];
                            qryBgPosition["BaZahlungswegID"] = qry["BaZahlungswegID"];
                            qryBgPosition["EinzahlungsscheinCode"] = qry["EinzahlungsscheinCode"];

                            if (Convert.ToInt32(qryBgPosition["EinzahlungsscheinCode"]) != Convert.ToInt32(Einzahlungsschein.OrangerEinzahlungsschein))
                            {
                                SqlQuery qryPerson = DBUtil.OpenSQL(@"
                                    SELECT VornameName,
                                           WohnsitzStrasseHausNr,
                                           WohnsitzPLZOrt
                                    FROM dbo.vwPerson
                                    WHERE BaPersonID = {0};", qryBgBudget["LeistungBaPersonID"]);

                                qryBgPosition["MitteilungZeile1"] = Utils.TruncateString(qryPerson["VornameName"], 35);
                            }
                        }
                        else
                        {
                            qryBgPosition["Kreditor"] = DBNull.Value;
                            qryBgPosition["ZusatzInfo"] = DBNull.Value;
                            qryBgPosition["BaZahlungswegID"] = DBNull.Value;
                            qryBgPosition["EinzahlungsscheinCode"] = DBNull.Value;
                        }
                    }

                    break;
            }

            qryBgPosition.RefreshDisplay();
        }

        /// <summary>
        /// Setup controls for multilanguage handling
        /// </summary>
        private void SetupControlsML()
        {
            // setup buttons texts (no text allowed)
            btnEinzelzahlung.Text = "";
            btnZusatzleistung.Text = "";
            btnPositionBewilligung.Text = "";
            btnFreigeben.Text = "";
            btnGraustellen.Text = "";

            // setup button icons
            btnFreigeben.Image = KissImageList.GetSmallImage("BuchungStatus_2_freigegeben");
            btnGraustellen.Image = KissImageList.GetSmallImage("BuchungStatus_1_vorbereitet");

            // Tooltips setzen
            ttpControls = new ToolTip();
            ttpControls.SetToolTip(btnEinzelzahlung, KissMsg.GetMLMessage(Name, "TtpNeueEZ", "Neue Einzelzahlung"));
            ttpControls.SetToolTip(btnZusatzleistung, KissMsg.GetMLMessage(Name, "TtpNeueZL", "Neue zusätzliche Leistung"));
            ttpControls.SetToolTip(btnPositionBewilligung, KissMsg.GetMLMessage(Name, "TtpBewilligungBgPos", "Bewilligung der Budgetposition"));
            ttpControls.SetToolTip(btnFreigeben, KissMsg.GetMLMessage(Name, "TtpBtnFreigeben", "Position freigeben"));
            ttpControls.SetToolTip(btnGraustellen, KissMsg.GetMLMessage(Name, "TtpBtnGraustellen", "Position graustellen"));
        }

        private void SetupMaxLength()
        {
            edtMitteilungZeile1.Properties.MaxLength = DBODef.BgAuszahlungPerson.MitteilungZeile1.Length;
            edtMitteilungZeile2.Properties.MaxLength = DBODef.BgAuszahlungPerson.MitteilungZeile2.Length;
            edtMitteilungZeile3.Properties.MaxLength = DBODef.BgAuszahlungPerson.MitteilungZeile3.Length;
            edtBuchungstext.Properties.MaxLength = DBODef.BgPosition.Buchungstext.Length;
        }

        private void SetupRights()
        {
            edtAuszahlungsart.EditMode = _userRightWhEinzelzahlungKreditor ? EditModeType.Required : EditModeType.ReadOnly;
        }

        private void SetVerwendungsPeriode()
        {
            if (!DBUtil.IsEmpty(qryBgPosition["HauptPos"]))
            {
                return;
            }

            SetVerwendungsPeriode(ref qryBgPosition, ref qryBgBudget);
        }

        private void UpdateControlsAndStates()
        {
            // setup edit mode
            SetEditMode();

            // handle button Bewilligen
            EnableBtnBewilligen();

            // handle button WeitereKoA
            EnableBtnWeitereKoA();

            // handle button Freigeben
            EnableBtnFreigeben();

            // handle button Graustellen
            EnableBtnGraustellen();

            // handle documents tpg
            EnableTpgDocuments();
        }

        private void UpdateDocumentInfo()
        {
            // update document information
            if (DBUtil.IsEmpty(edtDocument.DocumentID))
            {
                // no document, reset display
                qryBgDokumente["DateCreation"] = null;
                qryBgDokumente["DateLastSave"] = null;
            }
            else
            {
                // show information about document
                qryBgDokumente["DateCreation"] = edtDocument["DateCreation"];
                qryBgDokumente["DateLastSave"] = edtDocument["DateLastSave"];
            }
        }

        #endregion

        #endregion
    }
}