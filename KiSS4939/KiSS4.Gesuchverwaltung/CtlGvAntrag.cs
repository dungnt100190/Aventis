using System;
using System.Data;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.DB;

namespace KiSS4.Gesuchverwaltung
{
    public partial class CtlGvAntrag : GvBaseControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlGvAntrag";
        private const string QRY_BEMERKUNG_FONDS_EXTERN = "Bemerkung_FondsExtern";
        private const string QRY_BETRAG_BEWILLIGT_FONDS_EXTERN = "BetragBewilligt_FondsExtern";
        private const string QRY_BEWILLIGT_AM_FONDS_EXTERN = "BewilligtAm_FondsExtern";
        private const string QRY_DISPLAY_BEZEICHNUNG = "DisplayBezeichnung";
        private const string QRY_DOCUMENT_ID_FONDS_EXTERN = "DocumentID_FondsExtern";
        private const string SPEZIALRECHT_KOMPETENZ_BSL = "CtlGvAntrag_Kompetenz_BSL";

        #endregion

        #region Private Fields

        private decimal _beantragterBetrag;
        private int _beantragterBetragSortKey;
        private int _eigenleistungSortKey;
        private int _finanzierungSortKey;
        private decimal _summe;

        #endregion

        #endregion

        #region Constructors

        public CtlGvAntrag(SqlQuery qryGvGesuch, bool hasKompetenzstufe0, bool hasKompetenzstufe1, bool hasKompetenzstufe2)
            : base(qryGvGesuch, hasKompetenzstufe0, hasKompetenzstufe1, hasKompetenzstufe2)
        {
            InitializeComponent();
            SetupDataSource();
            SetupDataMember();
            SetupFieldName();

            LoadQueries();
        }

        #endregion

        #region Events

        public event EventHandler BeantragterBetragChanged;

        #endregion

        #region Properties

        private bool? _allowEditExternenFondsIKSFelder = null;

        public decimal BeantragterBetrag
        {
            get { return _beantragterBetrag; }
            private set
            {
                if (_beantragterBetrag == value)
                {
                    return;
                }

                _beantragterBetrag = value;
                OnBeantragterBetragChanged(EventArgs.Empty);
            }
        }

        public int GvGesuchId
        {
            get { return (int)_qryGvGesuch[DBO.GvGesuch.GvGesuchID]; }
        }

        private bool AllowEdit
        {
            get
            {
                return _gvStatusCode == 0
                        || _gvStatusCode == LOVsGenerated.GvStatus.InErfassung
                        || (_gvStatusCode == LOVsGenerated.GvStatus.InBearbeitung && HasKompetenzstufe0);
            }
        }

        private bool AllowEditExternenFondsIKSFelder
        {
            get
            {
                if (_allowEditExternenFondsIKSFelder == null)
                {
                    _allowEditExternenFondsIKSFelder = DBUtil.UserHasRight("CtlGvGesuchverwaltung_Pruefung_IKS");
                }

                return _allowEditExternenFondsIKSFelder ?? false;
            }
        }

        #endregion

        #region EventHandlers

        private void btnExternerFondsAbschlussAufheben_Click(object sender, EventArgs e)
        {
            StatusWechsel(LOVsGenerated.GvStatus.InErfassung, LOVsGenerated.GvBewilligung.AbschlussAufheben);
        }

        private void btnExternerFondsGesuchAbschliessen_Click(object sender, EventArgs e)
        {
            try
            {
                DBUtil.CheckNotNullField(edtExternerFondsDatumAbschluss, lblExternerFondsDatumAbschluss.Text);
                DBUtil.CheckNotNullField(edtExternerFondsAbschlussgrund, lblExternerFondsAbschlussgrund.Text);
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
                return;
            }

            StatusWechsel(LOVsGenerated.GvStatus.Abgeschlossen, LOVsGenerated.GvBewilligung.GesuchAbschliessen);
        }

        private void CtlGvAntrag_AddData(object sender, EventArgs e)
        {
            // Kontrolle, ob eingefügt werden darf
            if (!qryGvKosten.CanInsert && !qryGvFinanzierung.CanInsert)
            {
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "NoRightsToAddData",
                    "Sie besitzen keine Berechtigung zum Erfassen neuer Positionen.");
                return;
            }

            string msg = KissMsg.GetMLMessage(
                CLASSNAME,
                "ChooseGvAntragPositionType",
                "Wollen Sie eine Kosten- oder eine Finanzierungsposition erfassen?");

            int resultButtonIndex = KissMsg.ShowButtonDlg(msg, GetButtonList());

            // Falls Cancel gedrückt wurde ist hier nichts zu tun.
            if (resultButtonIndex == 2)
            {
                return;
            }

            // beide Queries speichern
            if (!qryGvKosten.Post())
            {
                return;
            }

            if (!qryGvFinanzierung.Post())
            {
                return;
            }

            // Je nach Auswahl im Dialog wird das entsprechende Qry gepostet
            if (resultButtonIndex == 0)
            {
                qryGvKosten.Insert();
            }
            else if (resultButtonIndex == 1)
            {
                qryGvFinanzierung.Insert();
            }

            SetEditModeKosten();
            SetEditModeFinanzierung();
        }

        private void CtlGvAntrag_DeleteData(object sender, EventArgs e)
        {
            if (qryGvKosten.Count == 0)
            {
                // Wenn in zivilrechtlicher Wohnsitz nichts erfasst ist, dann löschen bei andere:
                DeleteFinanzierung();
            }
            else if (qryGvFinanzierung.Count == 0 ||
                     IsFinanzierungFromType(LOVsGenerated.GvAntragPositionTyp.BeantragterBetrag) ||
                     IsFinanzierungFromType(LOVsGenerated.GvAntragPositionTyp.Eigenleistung))
            {
                // Wenn bei anderen nichts erfasst ist, dann löschen bei Wohnsitz:
                DeleteKosten();
            }
            else
            {
                // confirm
                string msg = KissMsg.GetMLMessage(
                    CLASSNAME,
                    "ConfirmDeleteType",
                    "Wollen Sie die markierte Kostenposition oder die markierte Finanzierungsposition löschen?");

                int resultButtonIndex = KissMsg.ShowButtonDlg(msg, GetButtonList());

                if (resultButtonIndex == 0)
                {
                    DeleteKosten();
                }
                else if (resultButtonIndex == 1)
                {
                    DeleteFinanzierung();
                }
            }
        }

        private void CtlGvAntrag_Load(object sender, EventArgs e)
        {
            BindControls();

            _beantragterBetragSortKey = GetAntragPositionTypSortKey(LOVsGenerated.GvAntragPositionTyp.BeantragterBetrag);
            _eigenleistungSortKey = GetAntragPositionTypSortKey(LOVsGenerated.GvAntragPositionTyp.Eigenleistung);
            _finanzierungSortKey = GetAntragPositionTypSortKey(LOVsGenerated.GvAntragPositionTyp.Finanzierung);
        }

        private void CtlGvAntrag_MoveFirst(object sender, EventArgs e)
        {
            if (LeftSideHasFokus())
            {
                qryGvKosten.First();
            }

            if (RightSideHasFokus())
            {
                qryGvFinanzierung.First();
            }
        }

        private void CtlGvAntrag_MoveLast(object sender, EventArgs e)
        {
            if (LeftSideHasFokus())
            {
                qryGvKosten.Last();
            }

            if (RightSideHasFokus())
            {
                qryGvFinanzierung.Last();
            }
        }

        private void CtlGvAntrag_MoveNext(object sender, EventArgs e)
        {
            if (LeftSideHasFokus())
            {
                qryGvKosten.Next();
            }

            if (RightSideHasFokus())
            {
                qryGvFinanzierung.Next();
            }
        }

        private void CtlGvAntrag_MovePrevious(object sender, EventArgs e)
        {
            if (LeftSideHasFokus())
            {
                qryGvKosten.Previous();
            }

            if (RightSideHasFokus())
            {
                qryGvFinanzierung.Previous();
            }
        }

        private void CtlGvAntrag_RefreshData(object sender, EventArgs e)
        {
            SaveDataIntern();

            qryGvKosten.Refresh();
            qryGvFinanzierung.Refresh();

            UpdateEigenleistungBetrag();
        }

        private void CtlGvAntrag_SaveData(object sender, EventArgs e)
        {
            SaveDataIntern();
        }

        private void CtlGvAntrag_UndoDataChanges(object sender, EventArgs e)
        {
            qryGvKosten.Cancel();
            qryGvFinanzierung.Cancel();
            UpdateEigenleistungBetrag();
        }

        private void edtAbgeschlossenesGesuchgeprueftam_EditValueChanged(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(edtAbgeschlossenesGesuchgeprueftam.EditValue))
            {
                chkAbgeschlossenesGesuchBesprechen.EditMode = EditModeType.ReadOnly;
                kissRTFEditAbgeschlossenesBemerkung.EditMode = EditModeType.ReadOnly;

                chkAbgeschlossenesGesuchBesprechen.EditValue = false;
                kissRTFEditAbgeschlossenesBemerkung.EditValue = string.Empty;
                edtAbgeschlossenesGesuchDurchIKS.EditValue = null;
            }
            else
            {
                chkAbgeschlossenesGesuchBesprechen.EditMode = EditModeType.Normal;
                kissRTFEditAbgeschlossenesBemerkung.EditMode = EditModeType.Normal;
                edtAbgeschlossenesGesuchDurchIKS.EditValue = Session.User.LastFirstName;
            }
        }

        private void edtErfasstesGesuchgeprueftam_EditValueChanged(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(edtErfasstesGesuchgeprueftam.EditValue))
            {
                chkErfasstesGesuchBesprechen.EditMode = EditModeType.ReadOnly;
                kissRTFErfasstesGesuchBemerkung.EditMode = EditModeType.ReadOnly;

                chkErfasstesGesuchBesprechen.EditValue = false;
                kissRTFErfasstesGesuchBemerkung.EditValue = string.Empty;
                edtErfasstesGesuchgepreuftdurchIKS.EditValue = null;
            }
            else
            {
                chkErfasstesGesuchBesprechen.EditMode = EditModeType.Normal;
                kissRTFErfasstesGesuchBemerkung.EditMode = EditModeType.Normal;
                edtErfasstesGesuchgepreuftdurchIKS.EditValue = Session.User.LastFirstName;
            }
        }

        private void qryGvFinanzierung_AfterInsert(object sender, EventArgs e)
        {
            qryGvFinanzierung[DBO.GvAntragPosition.GvGesuchID] = GvGesuchId;
            qryGvFinanzierung[DBO.GvAntragPosition.GvAntragPositionTypCode] = LOVsGenerated.GvAntragPositionTyp.Finanzierung;
            qryGvFinanzierung[DBO.XLOVCode.SortKey] = _finanzierungSortKey;

            edtFinanzierungQuelle.Focus();
        }

        private void qryGvFinanzierung_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            // beantragter Betrag kann nicht gelöscht werden
            if (IsFinanzierungFromType(LOVsGenerated.GvAntragPositionTyp.BeantragterBetrag))
            {
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "CannotDeleteBeantragterBetrag",
                    "Der beantragte Betrag kann nicht gelöscht werden.");
                throw new KissCancelException();
            }

            // Eigenleistung kann nicht gelöscht werden
            if (IsFinanzierungFromType(LOVsGenerated.GvAntragPositionTyp.Eigenleistung))
            {
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "CannotDeleteEigenleistung",
                    "Die Eigenleistung kann nicht gelöscht werden.");
                throw new KissCancelException();
            }

            // Bestätigung um Finanzierung zu löschen
            string bezeichnung = qryGvFinanzierung[DBO.GvAntragPosition.Bezeichnung].ToString();
            decimal betrag = qryGvFinanzierung[DBO.GvAntragPosition.Betrag] as decimal? ?? 0;

            string fullMsg = KissMsg.GetMLMessage(
                CLASSNAME,
                "ConfirmDeleteFinanzierung",
                "Wollen Sie die Finanzierungsposition '{0}' mit Betrag {1} wirklich löschen?",
                KissMsgCode.MsgQuestion,
                bezeichnung,
                betrag.ToString("0.00"));

            qryGvFinanzierung.DeleteQuestion = fullMsg;
        }

        private void qryGvFinanzierung_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtFinanzierungQuelle, lblFinanzierungQuelle.Text);
            DBUtil.CheckNotNullField(edtFinanzierungBetrag, lblFinanzierungBetrag.Text);
            if ((int)qryGvFinanzierung[DBO.GvAntragPosition.GvAntragPositionTypCode] != (int)LOVsGenerated.GvAntragPositionTyp.BeantragterBetrag)
            {
                qryGvFinanzierung[QRY_DISPLAY_BEZEICHNUNG] = qryGvFinanzierung[DBO.GvAntragPosition.Bezeichnung];
            }
        }

        private void qryGvFinanzierung_PositionChanged(object sender, EventArgs e)
        {
            SetEditModeFinanzierung();
        }

        private void qryGvFinanzierung_PostCompleted(object sender, EventArgs e)
        {
            if (IsFinanzierungFromType(LOVsGenerated.GvAntragPositionTyp.BeantragterBetrag))
            {
                BeantragterBetrag = qryGvFinanzierung[DBO.GvAntragPosition.Betrag] as decimal? ?? 0;
            }

            UpdateEigenleistungBetrag();
        }

        private void qryGvKosten_AfterInsert(object sender, EventArgs e)
        {
            qryGvKosten[DBO.GvAntragPosition.GvGesuchID] = GvGesuchId;
            qryGvKosten[DBO.GvAntragPosition.GvAntragPositionTypCode] = LOVsGenerated.GvAntragPositionTyp.Kosten;

            edtKostenBezeichnung.Focus();
        }

        private void qryGvKosten_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            // Bestätigung um Kosten zu löschen
            string bezeichnung = qryGvKosten[DBO.GvAntragPosition.Bezeichnung].ToString();
            decimal betrag = qryGvKosten[DBO.GvAntragPosition.Betrag] as decimal? ?? 0;

            string fullMsg = KissMsg.GetMLMessage(
                CLASSNAME,
                "ConfirmDeleteKosten",
                "Wollen Sie die Kostenposition '{0}' mit Betrag {1} wirklich löschen?",
                KissMsgCode.MsgQuestion,
                bezeichnung,
                betrag.ToString("0.00"));

            qryGvKosten.DeleteQuestion = fullMsg;
        }

        private void qryGvKosten_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtKostenBezeichnung, lblKostenbezeichnung.Text);
            DBUtil.CheckNotNullField(edtKostenBetrag, lblKostenBetrag.Text);
        }

        private void qryGvKosten_PostCompleted(object sender, EventArgs e)
        {
            UpdateEigenleistungBetrag(false);
        }

        #endregion

        #region Methods

        #region Protected Methods

        /// <summary>
        /// Kosten- und Finanzierungsdaten neu laden
        /// </summary>
        protected override void LoadData(bool refresh)
        {
            if (refresh)
            {
                LoadQueries();

                SetRights();

                InsertUpdateBeantragterBetrag();
                UpdateEigenleistungBetrag();

                EnableDisableExternalFonds();

                InsertUpdateBeantragterBetrag();
                UpdateEigenleistungBetrag();

                SetEditModeFinanzierung();
                SetEditModeKosten();
                SetEditModeChkKompetenzBsl();

                EnableDisableButtons();
            }
        }

        protected override void UpdateGui()
        {
            SetRights();
            EnableDisableExternalFonds();
            SetEditModeFinanzierung();
            SetEditModeKosten();
            EnableDisableButtons();
        }

        #endregion

        #region Private Static Methods

        private static int GetAntragPositionTypSortKey(LOVsGenerated.GvAntragPositionTyp typ)
        {
            return DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT SortKey
                FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'GvAntragPositionTyp'
                  AND Code = {0}",
                (int)typ) as int? ?? 0;
        }

        /// <summary>
        /// Gibt eine Liste von Buttons zurück 0:Kosten, 1:Finanzierung, 2:Cancel
        /// </summary>
        /// <returns>Array von Buttons für Dialog</returns>
        private static string[] GetButtonList()
        {
            var btnKosten = KissMsg.GetMLMessage(CLASSNAME, "btnKosten", "&Kosten");
            var btnFinanzierung = KissMsg.GetMLMessage(CLASSNAME, "btnFinanzierung", "&Finanzierung");
            var btnCancel = KissMsg.GetMLMessage(CLASSNAME, "btnCancel", "A&bbrechen");

            string[] buttonList = { btnKosten, btnFinanzierung, btnCancel };

            return buttonList;
        }

        #endregion

        #region Private Methods

        private void CopyValuesFromVirtualColumnsToRealColumns()
        {
            _qryGvGesuch[DBO.GvGesuch.DocumentID] = _qryGvGesuch[QRY_DOCUMENT_ID_FONDS_EXTERN];

            if (_qryGvGesuch.ColumnModified(QRY_BEWILLIGT_AM_FONDS_EXTERN))
            {
                _qryGvGesuch[DBO.GvGesuch.BewilligtAm] = _qryGvGesuch[QRY_BEWILLIGT_AM_FONDS_EXTERN];
            }

            if (_qryGvGesuch.ColumnModified(QRY_BETRAG_BEWILLIGT_FONDS_EXTERN))
            {
                _qryGvGesuch[DBO.GvGesuch.BetragBewilligt] = _qryGvGesuch[QRY_BETRAG_BEWILLIGT_FONDS_EXTERN];
            }

            if (_qryGvGesuch.ColumnModified(QRY_BEMERKUNG_FONDS_EXTERN))
            {
                _qryGvGesuch[DBO.GvGesuch.Bemerkung] = _qryGvGesuch[QRY_BEMERKUNG_FONDS_EXTERN];
            }
        }

        private void DeleteFinanzierung()
        {
            qryGvFinanzierung.Delete();
            UpdateEigenleistungBetrag();
        }

        private void DeleteKosten()
        {
            qryGvKosten.Delete();
            UpdateEigenleistungBetrag(false);
        }

        private void EnableDisableButtons()
        {
            if (_gvStatusCode == LOVsGenerated.GvStatus.Abgeschlossen)
            {
                btnExternerFondsAbschlussAufheben.Visible = true;
                btnExternerFondsGesuchAbschliessen.Visible = false;
            }
            else
            {
                btnExternerFondsAbschlussAufheben.Visible = false;
                btnExternerFondsGesuchAbschliessen.Visible = true;
            }
        }

        private void EnableDisableExternalFonds()
        {
            if ((AllowEdit || AllowSpecialEdit) && IsExternerFonds)
            {
                edtExternerFondsBewilligterBetrag.EditMode = EditModeType.Normal;
                edtExternerFondsDatumEntscheid.EditMode = EditModeType.Normal;
                edtExternerFondsBemerkung.EditMode = EditModeType.Normal;
                edtExternerFondsDatumAbschluss.EditMode = EditModeType.Normal;
                edtExternerFondsAbschlussgrund.EditMode = EditModeType.Normal;
                edtExternerFondsGesuchsformular.EditMode = EditModeType.Normal;
                btnExternerFondsAbschlussAufheben.Enabled = true;
                btnExternerFondsGesuchAbschliessen.Enabled = FelderZumAbschliessenAusgefuellt();
            }
            else
            {
                edtExternerFondsBewilligterBetrag.EditMode = EditModeType.ReadOnly;
                edtExternerFondsDatumEntscheid.EditMode = EditModeType.ReadOnly;
                edtExternerFondsBemerkung.EditMode = EditModeType.ReadOnly;
                edtExternerFondsDatumAbschluss.EditMode = EditModeType.ReadOnly;
                edtExternerFondsAbschlussgrund.EditMode = EditModeType.ReadOnly;
                edtExternerFondsGesuchsformular.EditMode = EditModeType.ReadOnly;
                btnExternerFondsAbschlussAufheben.Enabled = false;
                btnExternerFondsGesuchAbschliessen.Enabled = false;

                //IKS Felder
                edtErfasstesGesuchgeprueftam.EditMode = EditModeType.ReadOnly;
                chkErfasstesGesuchBesprechen.EditMode = EditModeType.ReadOnly;
                kissRTFErfasstesGesuchBemerkung.EditMode = EditModeType.ReadOnly;
                edtAbgeschlossenesGesuchgeprueftam.EditMode = EditModeType.ReadOnly;
                chkAbgeschlossenesGesuchBesprechen.EditMode = EditModeType.ReadOnly;
                kissRTFEditAbgeschlossenesBemerkung.EditMode = EditModeType.ReadOnly;
            }

            if (IsExternerFonds)
            {
                //IKS Felder
                bool isErfasstesGesuchgeprueftamNotEmpty =
                    Common.Utils.ConvertToDateTime(_qryGvGesuch[DBO.GvGesuch.ErfasstesGesuchgeprueftam],
                        DateTime.MinValue) != DateTime.MinValue;
                edtErfasstesGesuchgeprueftam.EditMode = AllowEditExternenFondsIKSFelder
                    ? EditModeType.Normal
                    : EditModeType.ReadOnly;
                chkErfasstesGesuchBesprechen.EditMode = AllowEditExternenFondsIKSFelder &&
                                                        isErfasstesGesuchgeprueftamNotEmpty
                    ? EditModeType.Normal
                    : EditModeType.ReadOnly;
                kissRTFErfasstesGesuchBemerkung.EditMode = AllowEditExternenFondsIKSFelder &&
                                                           isErfasstesGesuchgeprueftamNotEmpty
                    ? EditModeType.Normal
                    : EditModeType.ReadOnly;

                bool isAbgeschlossenesGesuchgeprueftamNotEmpty =
                    Common.Utils.ConvertToDateTime(_qryGvGesuch[DBO.GvGesuch.AbgeschlossenesGesuchgeprueftam],
                        DateTime.MinValue) != DateTime.MinValue;
                edtAbgeschlossenesGesuchgeprueftam.EditMode = AllowEditExternenFondsIKSFelder
                    ? EditModeType.Normal
                    : EditModeType.ReadOnly;
                chkAbgeschlossenesGesuchBesprechen.EditMode = AllowEditExternenFondsIKSFelder &&
                                                              isAbgeschlossenesGesuchgeprueftamNotEmpty
                    ? EditModeType.Normal
                    : EditModeType.ReadOnly;
                kissRTFEditAbgeschlossenesBemerkung.EditMode = AllowEditExternenFondsIKSFelder &&
                                                               isAbgeschlossenesGesuchgeprueftamNotEmpty
                    ? EditModeType.Normal
                    : EditModeType.ReadOnly;
            }
        }

        private bool FelderZumAbschliessenAusgefuellt()
        {
            return !DBUtil.IsEmpty(edtExternerFondsAbschlussgrund.EditValue) &&
                   !DBUtil.IsEmpty(edtExternerFondsDatumAbschluss.EditValue) &&
                   !DBUtil.IsEmpty(edtExternerFondsDatumEntscheid.EditValue) &&
                   !DBUtil.IsEmpty(edtExternerFondsBewilligterBetrag.EditValue);
        }

        private bool FindFinanzierungOfType(LOVsGenerated.GvAntragPositionTyp antragPositionTyp)
        {
            return qryGvFinanzierung.Find(string.Format("{0} = {1}", DBO.GvAntragPosition.GvAntragPositionTypCode, (int)antragPositionTyp));
        }

        /// <summary>
        /// Beantragter Betrag auf der DB erstellen, falls er noch nicht vorhanden ist, oder die Bezeichnung anpassen, falls der Fonds gewechselt hat.
        /// </summary>
        private void InsertUpdateBeantragterBetrag()
        {
            bool doPost = false;
            var exists = FindFinanzierungOfType(LOVsGenerated.GvAntragPositionTyp.BeantragterBetrag);

            string fondsName = DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT FND.NameKurz
                FROM dbo.GvGesuch        GES WITH (READUNCOMMITTED)
                  INNER JOIN dbo.GvFonds FND WITH (READUNCOMMITTED) ON FND.GvFondsID = GES.GvFondsID
                WHERE GES.GvGesuchID = {0};",
                GvGesuchId,
                Session.User.LanguageCode).ToString();

            if (!exists)
            {
                qryGvFinanzierung.Insert(qryGvFinanzierung.TableName); //TableName übergeben, damit in jedem Fall (notfalls temporär) CanInsert=true gesetzt ist
                qryGvFinanzierung[DBO.GvAntragPosition.GvAntragPositionTypCode] = (int)LOVsGenerated.GvAntragPositionTyp.BeantragterBetrag;
                qryGvFinanzierung[DBO.GvAntragPosition.Betrag] = 0;
                qryGvFinanzierung[DBO.XLOVCode.SortKey] = _beantragterBetragSortKey;
                doPost = true;
            }
            else
            {
                // Update Bezeichnung
                if (qryGvFinanzierung.Find(DBO.GvAntragPosition.GvAntragPositionTypCode + "=" + (int)LOVsGenerated.GvAntragPositionTyp.BeantragterBetrag) &&
                    Common.Utils.ConvertToString(qryGvFinanzierung[DBO.GvAntragPosition.Bezeichnung]) != fondsName)
                {
                    qryGvFinanzierung[DBO.GvAntragPosition.Bezeichnung] = fondsName;
                    doPost = true;
                }
            }

            if (doPost)
            {
                qryGvFinanzierung[DBO.GvAntragPosition.Bezeichnung] = fondsName;
                qryGvFinanzierung[QRY_DISPLAY_BEZEICHNUNG] = fondsName + " " + KissMsg.GetMLMessage(
                    CLASSNAME,
                    "BeantragterBetragBezeichnung",
                    "(beantragter Betrag)",
                    KissMsgCode.Text);
                qryGvFinanzierung.Post(qryGvFinanzierung.TableName); // update erlauben, da methodenintern gesetzt, urspr. zustand merken
            }
        }

        private bool IsFinanzierungFromType(LOVsGenerated.GvAntragPositionTyp antragPositionTyp)
        {
            return Convert.ToInt32(qryGvFinanzierung[DBO.GvAntragPosition.GvAntragPositionTypCode]) == (int)antragPositionTyp;
        }

        /// <summary>
        /// Kosten hat den Focus
        /// </summary>
        /// <returns></returns>
        private bool LeftSideHasFokus()
        {
            return (grdKosten.Focused ||
                    edtKostenBezeichnung.Focused ||
                    edtKostenBetrag.Focused);
        }

        private void LoadQueries()
        {
            qryGvKosten.Fill(GvGesuchId);
            qryGvFinanzierung.Fill(GvGesuchId, Session.User.LanguageCode);
        }

        private void OnBeantragterBetragChanged(EventArgs e)
        {
            EventHandler handler = BeantragterBetragChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Finanzierung hat den Focus
        /// </summary>
        /// <returns></returns>
        private bool RightSideHasFokus()
        {
            return (grdFinanzierung.Focused ||
                    edtFinanzierungQuelle.Focused ||
                    edtFinanzierungBetrag.Focused);
        }

        private void SaveDataIntern()
        {
            if (!qryGvKosten.Post())
            {
                throw new KissCancelException();
            }

            if (!qryGvFinanzierung.Post())
            {
                throw new KissCancelException();
            }

            //Kopiere Werte aus virtuellen Spalten für interne Fonds in physisch existierende Spalten
            _qryGvGesuch.EndCurrentEdit();
            CopyValuesFromVirtualColumnsToRealColumns();

            if (!_qryGvGesuch.Post())
            {
                throw new KissCancelException();
            }

            EnableDisableExternalFonds();
            grdKosten.Refresh();
            grdFinanzierung.Refresh();
        }

        private void SetEditModeChkKompetenzBsl()
        {
            chkKompetenzBSL.EditMode = DBUtil.UserHasRight(SPEZIALRECHT_KOMPETENZ_BSL) ? EditModeType.Normal : EditModeType.ReadOnly;
        }

        private void SetEditModeFinanzierung()
        {
            if (!qryGvFinanzierung.CanUpdate || (!AllowEdit && !AllowSpecialEdit))
            {
                edtFinanzierungQuelle.EditMode = EditModeType.ReadOnly;
                edtFinanzierungBetrag.EditMode = EditModeType.ReadOnly;
                return;
            }

            if (IsFinanzierungFromType(LOVsGenerated.GvAntragPositionTyp.BeantragterBetrag))
            {
                edtFinanzierungQuelle.EditMode = EditModeType.ReadOnly;
                edtFinanzierungBetrag.EditMode = EditModeType.Required;
            }
            else if (IsFinanzierungFromType(LOVsGenerated.GvAntragPositionTyp.Eigenleistung))
            {
                edtFinanzierungQuelle.EditMode = EditModeType.ReadOnly;
                edtFinanzierungBetrag.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                edtFinanzierungQuelle.EditMode = EditModeType.Required;
                edtFinanzierungBetrag.EditMode = EditModeType.Required;
            }
        }

        private void SetEditModeKosten()
        {
            if (qryGvKosten.IsEmpty || !qryGvKosten.CanUpdate || (!AllowEdit && !AllowSpecialEdit))
            {
                edtKostenBezeichnung.EditMode = EditModeType.ReadOnly;
                edtKostenBetrag.EditMode = EditModeType.ReadOnly;
                return;
            }

            edtKostenBezeichnung.EditMode = EditModeType.Required;
            edtKostenBetrag.EditMode = EditModeType.Required;
        }

        private void SetRights()
        {
            qryGvKosten.CanInsert = true;
            qryGvKosten.CanUpdate = true;
            qryGvKosten.CanDelete = true;

            qryGvFinanzierung.CanInsert = true;
            qryGvFinanzierung.CanUpdate = true;
            qryGvFinanzierung.CanDelete = true;

            // apply rights
            qryGvKosten.ApplyUserRights();
            qryGvFinanzierung.ApplyUserRights();

            bool allowEdit = (AllowEdit || AllowSpecialEdit);

            qryGvKosten.CanInsert &= allowEdit;
            qryGvKosten.CanUpdate &= allowEdit;
            qryGvKosten.CanDelete &= allowEdit;

            qryGvFinanzierung.CanInsert &= allowEdit;
            qryGvFinanzierung.CanUpdate &= allowEdit;
            qryGvFinanzierung.CanDelete &= allowEdit;

            // setup controls
            qryGvKosten.EnableBoundFields();
            qryGvFinanzierung.EnableBoundFields();
        }

        private void SetupDataMember()
        {
            edtKostenBezeichnung.DataMember = DBO.GvAntragPosition.Bezeichnung;
            edtKostenBetrag.DataMember = DBO.GvAntragPosition.Betrag;
            edtFinanzierungQuelle.DataMember = DBO.GvAntragPosition.Bezeichnung;
            edtFinanzierungBetrag.DataMember = DBO.GvAntragPosition.Betrag;

            chkEigenkompetenz.DataMember = DBO.GvGesuch.IstEigenkompetenz;

            chkKompetenzBSL.DataMember = DBO.GvGesuch.IstKompetenzBsl;

            edtExternerFondsGesuchsformular.DataMember = QRY_DOCUMENT_ID_FONDS_EXTERN;
            edtExternerFondsBewilligterBetrag.DataMember = QRY_BETRAG_BEWILLIGT_FONDS_EXTERN;
            edtExternerFondsDatumEntscheid.DataMember = QRY_BEWILLIGT_AM_FONDS_EXTERN;
            edtExternerFondsBemerkung.DataMember = QRY_BEMERKUNG_FONDS_EXTERN;

            edtErfasstesGesuchgeprueftam.DataMember = DBO.GvGesuch.ErfasstesGesuchgeprueftam;
            edtErfasstesGesuchgepreuftdurchIKS.DataMember = CtlGvGesuchverwaltung.QRY_GVGESUCH_ERFASSTESGESUCHGEPRUEFTDURCHIKS_USER;
            chkErfasstesGesuchBesprechen.DataMember = DBO.GvGesuch.ErfasstesGesuchBesprechen;
            kissRTFErfasstesGesuchBemerkung.DataMember = DBO.GvGesuch.ErfasstesGesuchBemerkung;
            edtAbgeschlossenesGesuchgeprueftam.DataMember = DBO.GvGesuch.AbgeschlossenesGesuchgeprueftam;
            edtAbgeschlossenesGesuchDurchIKS.DataMember = CtlGvGesuchverwaltung.QRY_GVGESUCH_ABGESCHLOSSENESGESUCHDURCHIKSE_USER;
            chkAbgeschlossenesGesuchBesprechen.DataMember = DBO.GvGesuch.AbgeschlossenesGesuchBesprechen;
            kissRTFEditAbgeschlossenesBemerkung.DataMember = DBO.GvGesuch.AbgeschlossenesGesuchBemerkung;

            edtExternerFondsDatumAbschluss.DataMember = DBO.GvGesuch.AbschlussDatum;
            edtExternerFondsAbschlussgrund.DataMember = DBO.GvGesuch.GvAbschlussgrundCode;
        }

        private void SetupDataSource()
        {
            chkEigenkompetenz.DataSource = _qryGvGesuch;
            chkKompetenzBSL.DataSource = _qryGvGesuch;

            edtExternerFondsGesuchsformular.DataSource = _qryGvGesuch;
            edtExternerFondsBewilligterBetrag.DataSource = _qryGvGesuch;
            edtExternerFondsDatumEntscheid.DataSource = _qryGvGesuch;
            edtExternerFondsBemerkung.DataSource = _qryGvGesuch;
            edtExternerFondsDatumAbschluss.DataSource = _qryGvGesuch;
            edtExternerFondsAbschlussgrund.DataSource = _qryGvGesuch;

            edtErfasstesGesuchgeprueftam.DataSource = _qryGvGesuch;
            edtErfasstesGesuchgepreuftdurchIKS.DataSource = _qryGvGesuch;
            chkErfasstesGesuchBesprechen.DataSource = _qryGvGesuch;
            kissRTFErfasstesGesuchBemerkung.DataSource = _qryGvGesuch;
            edtAbgeschlossenesGesuchgeprueftam.DataSource = _qryGvGesuch;
            edtAbgeschlossenesGesuchDurchIKS.DataSource = _qryGvGesuch;
            chkAbgeschlossenesGesuchBesprechen.DataSource = _qryGvGesuch;
            kissRTFEditAbgeschlossenesBemerkung.DataSource = _qryGvGesuch;
        }

        private void SetupFieldName()
        {
            colKostenKostenbezeichnung.FieldName = DBO.GvAntragPosition.Bezeichnung;
            colKostenBetrag.FieldName = DBO.GvAntragPosition.Betrag;
            colKostenSortBezeichnung.FieldName = DBO.GvAntragPosition.Bezeichnung;

            colFinanzierungQuelle.FieldName = QRY_DISPLAY_BEZEICHNUNG;
            colFinanzierungBetrag.FieldName = DBO.GvAntragPosition.Betrag;
            colFinanzierungSortKey.FieldName = DBO.XLOVCode.SortKey;
        }

        private void UpdateEigenleistungBetrag(bool updateFinanzierung = true, bool updateKosten = true)
        {
            if (!updateFinanzierung && !updateKosten)
            {
                return;
            }

            // aktuelle Position im Grid speichern
            var position = qryGvFinanzierung.Position;

            var exists = FindFinanzierungOfType(LOVsGenerated.GvAntragPositionTyp.Eigenleistung);

            // Eigenleistung in Memory erstellen falls es noch nicht vorhaden ist
            if (!exists)
            {
                grdFinanzierung.DataSource = null; // muss auf null gesetzt werden wegen eines Problem beim Grid-Aktualysieren
                qryGvFinanzierung.Insert(qryGvFinanzierung.TableName); //TableName übergeben, damit in jedem Fall (notfalls temporär) CanInsert=true gesetzt ist
                qryGvFinanzierung[DBO.GvAntragPosition.GvAntragPositionTypCode] = (int)LOVsGenerated.GvAntragPositionTyp.Eigenleistung;
                qryGvFinanzierung[DBO.GvAntragPosition.Bezeichnung] = KissMsg.GetMLMessage(CLASSNAME, "EigenleistungBezeichnung", "Eigenleistung", KissMsgCode.Text);
                qryGvFinanzierung[QRY_DISPLAY_BEZEICHNUNG] = KissMsg.GetMLMessage(CLASSNAME, "EigenleistungBezeichnung", "Eigenleistung", KissMsgCode.Text);
                qryGvFinanzierung[DBO.XLOVCode.SortKey] = _eigenleistungSortKey;
            }

            // beantragter Betrag und Finanzierungen summieren
            if (updateFinanzierung)
            {
                _summe = 0;
                foreach (DataRow row in qryGvFinanzierung.DataTable.Rows)
                {
                    if (Convert.ToInt32(row[DBO.GvAntragPosition.GvAntragPositionTypCode]) == (int)LOVsGenerated.GvAntragPositionTyp.BeantragterBetrag ||
                        Convert.ToInt32(row[DBO.GvAntragPosition.GvAntragPositionTypCode]) == (int)LOVsGenerated.GvAntragPositionTyp.Finanzierung)
                    {
                        _summe += (decimal)row[DBO.GvAntragPosition.Betrag];
                    }
                }
            }

            //Problem: in KiSS 5 wird colKostenBetrag.SummaryItem.SummaryValue wurde zu diesem zeitpunkt (nach Suche, erster Wechsel auf Register Antrag) noch nicht berechnet.
            decimal summeKosten = 0;
            foreach (DataRow row in qryGvKosten.DataTable.Rows)
            {
                if (Convert.ToInt32(row[DBO.GvAntragPosition.GvAntragPositionTypCode]) == (int)LOVsGenerated.GvAntragPositionTyp.Kosten)
                {
                    summeKosten += (decimal)row[DBO.GvAntragPosition.Betrag];
                }
            }

            // Eigenleistung berechnen (Kosten - Sum(Finanzierung))
            qryGvFinanzierung[DBO.GvAntragPosition.Betrag] = summeKosten - _summe;
            qryGvFinanzierung.DataTable.AcceptChanges();
            qryGvFinanzierung.RowModified = false;

            if (!exists)
            {
                grdFinanzierung.DataSource = qryGvFinanzierung;  // muss am ende wieder gesetzt werden wegen eines Problem beim Grid-Aktualysieren
            }

            // alte Position im Grid selektieren
            qryGvFinanzierung.Position = position;
        }

        #endregion

        #endregion
    }
}