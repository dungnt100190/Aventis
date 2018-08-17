using System;
using System.Windows.Forms;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Gesuchverwaltung
{
    public partial class CtlGvBewilligung : GvBaseControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASS_NAME = "CtlGvBewilligung";

        #endregion

        #region Private Fields

        private decimal _kompetenzstufe1MaxBetrag;

        #endregion

        #endregion

        #region Constructors

        public CtlGvBewilligung(SqlQuery qryGvGesuch, bool hasKompetenzstufe0, bool hasKompetenzstufe1, bool hasKompetenzstufe2)
            : base(qryGvGesuch, hasKompetenzstufe0, hasKompetenzstufe1, hasKompetenzstufe2)
        {
            InitializeComponent();

            qryGvAuflage.CanInsert = false;
            qryGvAuflage.CanUpdate = false;
        }

        #endregion

        #region EventHandlers

        private void AbschlussAufheben_Click(object sender, EventArgs e)
        {
            try
            {
                Session.BeginTransaction();

                // wird von KGS und CH-Buttons aufgerufen
                ZahlungenPruefen();

                StatusWechsel(LOVsGenerated.GvStatus.InPruefung, LOVsGenerated.GvBewilligung.AbschlussAufheben);
                // Bewilligte Beträge entfernen
                ResetBewilligtBetragDatumUndUser();
                ResetBewilligtBetragUndDatumKompetenzstufe1();
                ResetBewilligtBetragUndDatumKompetenzstufe2();

                _qryGvGesuch.Post();

                Session.Commit();

                _qryGvGesuch.Refresh();

                UpdateGui();
            }
            catch (Exception ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                if (ex is KissCancelException)
                {
                    KissMsg.ShowInfo(ex.Message);
                }
                else
                {
                    throw;
                }
            }
        }

        private void btnPruefungCHAbschliessen_Click(object sender, EventArgs e)
        {
            PruefungAbschliessenCH();
        }

        private void btnPruefungCHGesuchAblehnen_Click(object sender, EventArgs e)
        {
            _qryGvGesuch[DBO.GvGesuch.BetragBewilligtKompetenzstufe2] = 0.0;
            PruefungAbschliessenCH();
        }

        private void btnPruefungCHGesuchZurueckweisen_Click(object sender, EventArgs e)
        {
            ResetBewilligtBetragDatumUndUser();
            StatusWechsel(LOVsGenerated.GvStatus.InBearbeitung, LOVsGenerated.GvBewilligung.GesuchZurueckweisen);
        }

        private void btnPruefungGesuchAblehnen_Click(object sender, EventArgs e)
        {
            _qryGvGesuch[DBO.GvGesuch.BetragBewilligtKompetenzstufe1] = 0.0;
            SetBewilligtAm(edtBewilligungAm.DataMember, edtBewilligungBetragBewilligt);
            PruefungAbschliessen();
        }

        private void btnPruefungGesuchWeiterleitenCH_Click(object sender, EventArgs e)
        {
            StatusWechsel(LOVsGenerated.GvStatus.InPruefungCh, LOVsGenerated.GvBewilligung.GesuchWeiterleitenCh);
        }

        private void btnPruefungGesuchZurueckweisen_Click(object sender, EventArgs e)
        {
            ResetBewilligtBetragDatumUndUser();
            StatusWechsel(LOVsGenerated.GvStatus.InBearbeitung, LOVsGenerated.GvBewilligung.GesuchZurueckweisen);
        }

        private void btnPruefungPruefungAbschliessen_Click(object sender, EventArgs e)
        {
            PruefungAbschliessen();
        }

        private void CtlGvBewilligung_Load(object sender, EventArgs e)
        {
            // Config
            _kompetenzstufe1MaxBetrag = (decimal)DBUtil.GetConfigValue(@"System\Gesuchverwaltung\Kompetenzstufe1Betrag", 10000m);

            SetupDataMembers();

            LoadData();
        }

        private void edtBewilligungBetragBewilligt_EditValueChanged(object sender, EventArgs e)
        {
            KuerzungBerechnen(edtBewilligungBetragBeantragt, edtBewilligungBetragBewilligt, edtBewilligungKuerzung);

            edtBewilligungBetragBewilligt.EditValueChanged -= edtBewilligungBetragBewilligt_EditValueChanged;
            SetBewilligtAm(edtBewilligungAm.DataMember, edtBewilligungBetragBewilligt);
            edtBewilligungBetragBewilligt.EditValueChanged += edtBewilligungBetragBewilligt_EditValueChanged;
        }

        private void edtBewilligungCHBetragBewilligt_EditValueChanged(object sender, EventArgs e)
        {
            KuerzungBerechnen(edtBewilligungCHBetragBeantragt, edtBewilligungCHBetragBewilligt, edtBewilligungCHKuerzung);

            edtBewilligungCHBetragBewilligt.EditValueChanged -= edtBewilligungCHBetragBewilligt_EditValueChanged;
            SetBewilligtAm(edtBewilligungCHAm.DataMember, edtBewilligungCHBetragBewilligt);
            edtBewilligungCHBetragBewilligt.EditValueChanged += edtBewilligungCHBetragBewilligt_EditValueChanged;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool OnAddData()
        {
            return true;
        }

        public override bool OnDeleteData()
        {
            return true;
        }

        public override void OnRefreshData()
        {
            qryGvAuflage.Refresh();
        }

        #endregion

        #region Protected Methods

        protected override void LoadData(bool refresh)
        {
            qryGvAuflage.Fill(_qryGvGesuch[DBO.GvGesuch.BaPersonID]);
            qryGvAuflage.Last();

            UpdateGui();
        }

        protected override void UpdateGui()
        {
            EnableDisableButtons();
            SetEditMode();

            KuerzungBerechnen(edtBewilligungBetragBeantragt, edtBewilligungBetragBewilligt, edtBewilligungKuerzung);
            KuerzungBerechnen(edtBewilligungCHBetragBeantragt, edtBewilligungCHBetragBewilligt, edtBewilligungCHKuerzung);
        }

        #endregion

        #region Private Static Methods

        private static void CheckNotNegativField(IKissBindableEdit ctl, string userColName)
        {
            if (ctl.DataSource[ctl.DataMember] as decimal? < 0)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(CLASS_NAME,
                                                                 "FeldXYNegatif",
                                                                 "Das Feld '{0}' darf nicht negativ sein!",
                                                                 KissMsgCode.MsgInfo,
                                                                 userColName),
                                            (Control)ctl);
            }
        }

        private static void KuerzungBerechnen(KissCalcEdit edtBeantragt, KissCalcEdit edtBewilligt, KissCalcEdit edtKuerzung)
        {
            var beantragt = Utils.ConvertToDecimal(edtBeantragt.EditValue);
            var bewilligt = Utils.ConvertToDecimal(edtBewilligt.EditValue);
            edtKuerzung.EditValue = Math.Max(0, beantragt - bewilligt);
        }

        #endregion

        #region Private Methods

        private void DisableAllButtons()
        {
            //Prüfungbuttons
            btnPruefungAbschlussAufheben.Enabled = false;
            btnPruefungGesuchWeiterleitenCH.Enabled = false;
            btnPruefungGesuchZurueckweisen.Enabled = false;
            btnPruefungPruefungAbschliessen.Enabled = false;
            btnPruefungGesuchAblehnen.Enabled = false;
            //CHbuttons
            btnPruefungCHAbschliessen.Enabled = false;
            btnPruefungCHAbschlussAufheben.Enabled = false;
            btnPruefungCHGesuchZurueckweisen.Enabled = false;
            btnPruefungCHGesuchAblehnen.Enabled = false;
            //Dokumentbuttons
            btnBewilligungCHDokument.Enabled = false;
            btnBewilligungDokument.Enabled = false;
        }

        private void EnableDisableButtons()
        {
            // Alle Buttons deaktivieren
            DisableAllButtons();

            // Buttons je nach Status und Spezialrecht aktivieren
            switch (_gvStatusCode)
            {
                case LOVsGenerated.GvStatus.InErfassung:
                    //nicht relevant hier
                    break;

                case LOVsGenerated.GvStatus.InBearbeitung:
                    //nicht relevant hier
                    break;

                case LOVsGenerated.GvStatus.InPruefung:
                    btnPruefungGesuchZurueckweisen.Enabled = HasKompetenzstufe1;
                    btnPruefungPruefungAbschliessen.Enabled = HasKompetenzstufe1;
                    btnPruefungGesuchAblehnen.Enabled = HasKompetenzstufe1;
                    btnPruefungGesuchWeiterleitenCH.Enabled = (HasKompetenzstufe0 || HasKompetenzstufe1);
                    //Dokumentbutton
                    btnBewilligungDokument.Enabled = HasKompetenzstufe1;
                    break;

                case LOVsGenerated.GvStatus.InPruefungCh:
                    btnPruefungCHAbschliessen.Enabled = HasKompetenzstufe2;
                    btnPruefungCHGesuchAblehnen.Enabled = HasKompetenzstufe2;
                    btnPruefungCHGesuchZurueckweisen.Enabled = HasKompetenzstufe2;
                    //Dokumentbutton
                    btnBewilligungCHDokument.Enabled = HasKompetenzstufe2;
                    break;

                case LOVsGenerated.GvStatus.Beurteilt:
                    btnPruefungCHAbschlussAufheben.Enabled = HasKompetenzstufe2;
                    btnPruefungCHGesuchZurueckweisen.Enabled = HasKompetenzstufe2;
                    btnPruefungAbschlussAufheben.Enabled = HasKompetenzstufe1;
                    //Dokumentbuttons
                    btnBewilligungDokument.Enabled = HasKompetenzstufe1;
                    btnBewilligungCHDokument.Enabled = HasKompetenzstufe2;
                    break;

                case LOVsGenerated.GvStatus.Abgeschlossen:
                    //alle deaktivieren
                    break;
            }
        }

        private bool KompetenzPruefen()
        {
            var sum = Utils.ConvertToDecimal(_qryGvGesuch[CtlGvGesuchverwaltung.QRY_GVGESUCH_TOTAL_FONDS_BEWILLIGT]);

            if (Utils.ConvertToBool(_qryGvGesuch[CtlGvGesuchverwaltung.QRY_GVGESUCH_IST_FONDS_FLB]))
            {
                sum += Utils.ConvertToDecimal(_qryGvGesuch[DBO.GvGesuch.BetragBewilligtKompetenzstufe1]);

                if (sum > _kompetenzstufe1MaxBetrag)
                {
                    KissMsg.ShowInfo(
                        CLASS_NAME,
                        "PrüfungAbschliessen_KompetenzÜberschritten",
                        "Die Summe der Beträge überschreitet Ihre Kompetenz. Leiten Sie das Gesuch an die CH-Stelle weiter.");
                    return false;
                }
            }
            return true;
        }

        private void PruefungAbschliessen()
        {
            try
            {
                DBUtil.CheckNotNullField(edtBewilligungBetragBewilligt, lblBewilligungBetragBewilligt.Text);
                DBUtil.CheckNotNullField(edtBewilligungAm, lblBewilligungAm.Text);
                CheckNotNegativField(edtBewilligungBetragBewilligt, lblBewilligungBetragBewilligt.Text);
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
                return;
            }

            if (!KompetenzPruefen())
            {
                return;
            }

            try
            {
                Session.BeginTransaction();

                StatusWechsel(LOVsGenerated.GvStatus.Beurteilt, LOVsGenerated.GvBewilligung.PruefungAbschliessen);
                _qryGvGesuch[DBO.GvGesuch.BetragBewilligt] = _qryGvGesuch[DBO.GvGesuch.BetragBewilligtKompetenzstufe1];
                _qryGvGesuch[DBO.GvGesuch.BewilligtAm] = _qryGvGesuch[DBO.GvGesuch.DatumBewilligtKompetenzstufe1];
                _qryGvGesuch[DBO.GvGesuch.UserIDBewilligt] = Session.User.UserID;
                ResetBewilligtBetragUndDatumKompetenzstufe2();

                _qryGvGesuch.Post();

                Session.Commit();

                _qryGvGesuch.Refresh();

                UpdateGui();
            }
            catch
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                throw;
            }
        }

        private void PruefungAbschliessenCH()
        {
            try
            {
                DBUtil.CheckNotNullField(edtBewilligungCHBetragBewilligt, lblBewilligungCHBetragBewilligt.Text);
                DBUtil.CheckNotNullField(edtBewilligungCHAm, lblBewilligungCHAm.Text);
                CheckNotNegativField(edtBewilligungCHBetragBewilligt, lblBewilligungCHBetragBewilligt.Text);
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
                return;
            }

            try
            {
                Session.BeginTransaction();

                StatusWechsel(LOVsGenerated.GvStatus.Beurteilt, LOVsGenerated.GvBewilligung.PruefungAbschliessen);
                _qryGvGesuch[DBO.GvGesuch.BetragBewilligt] = _qryGvGesuch[DBO.GvGesuch.BetragBewilligtKompetenzstufe2];
                _qryGvGesuch[DBO.GvGesuch.BewilligtAm] = _qryGvGesuch[DBO.GvGesuch.DatumBewilligtKompetenzstufe2];
                _qryGvGesuch[DBO.GvGesuch.UserIDBewilligt] = Session.User.UserID;
                _qryGvGesuch.Post();

                Session.Commit();

                _qryGvGesuch.Refresh();

                UpdateGui();
            }
            catch
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                throw;
            }
        }

        private void ResetBewilligtBetragDatumUndUser()
        {
            _qryGvGesuch[DBO.GvGesuch.BetragBewilligt] = null;
            _qryGvGesuch[DBO.GvGesuch.BewilligtAm] = null;
            _qryGvGesuch[DBO.GvGesuch.UserIDBewilligt] = null;
        }

        private void ResetBewilligtBetragUndDatumKompetenzstufe1()
        {
            _qryGvGesuch[DBO.GvGesuch.BetragBewilligtKompetenzstufe1] = null;
            _qryGvGesuch[DBO.GvGesuch.DatumBewilligtKompetenzstufe1] = null;
        }

        private void ResetBewilligtBetragUndDatumKompetenzstufe2()
        {
            _qryGvGesuch[DBO.GvGesuch.BetragBewilligtKompetenzstufe2] = null;
            _qryGvGesuch[DBO.GvGesuch.DatumBewilligtKompetenzstufe2] = null;
        }

        private void SetBewilligtAm(string columnDatum, KissCalcEdit edtBetrag)
        {
            if (DBUtil.IsEmpty(edtBetrag.EditValue))
            {
                _qryGvGesuch[columnDatum] = null;
                // The above call updates the bindings of the sqlquery and thus resets the value
                _qryGvGesuch[edtBetrag.DataMember] = null;
                return;
            }

            if (DBUtil.IsEmpty(_qryGvGesuch[columnDatum]))
            {
                _qryGvGesuch[columnDatum] = DateTime.Today;
            }
        }

        private void SetEditMode()
        {
            // Bewilligung KGS

            var enableKgsControls = (_gvStatusCode == LOVsGenerated.GvStatus.InPruefung ||
                                     _gvStatusCode == LOVsGenerated.GvStatus.InBearbeitung) &&
                                     (HasKompetenzstufe0 || HasKompetenzstufe1);
            edtBewilligungBetragBewilligt.EditMode = enableKgsControls ? EditModeType.Required : EditModeType.ReadOnly;
            edtBewilligungAm.EditMode = enableKgsControls ? EditModeType.Required : EditModeType.ReadOnly;
            if (_gvStatusCode == LOVsGenerated.GvStatus.InErfassung ||
                _gvStatusCode == LOVsGenerated.GvStatus.InBearbeitung ||
                _gvStatusCode == LOVsGenerated.GvStatus.InPruefung ||
                _gvStatusCode == LOVsGenerated.GvStatus.InPruefungCh)
            {
                edtBewilligungBemerkung.EditMode = EditModeType.Normal;
            }
            else
            {
                edtBewilligungBemerkung.EditMode = EditModeType.ReadOnly;
            }

            // Bewilligung CH
            var enableChControls = (_gvStatusCode == LOVsGenerated.GvStatus.InPruefungCh ||
                                    _gvStatusCode == LOVsGenerated.GvStatus.InBearbeitung) &&
                                    HasKompetenzstufe2;
            edtBewilligungCHBetragBewilligt.EditMode = enableChControls ? EditModeType.Required : EditModeType.ReadOnly;
            edtBewilligungCHAm.EditMode = enableChControls ? EditModeType.Required : EditModeType.ReadOnly;
            edtBewilligungCHBemerkung.EditMode = _gvStatusCode == LOVsGenerated.GvStatus.InPruefungCh ? EditModeType.Normal : EditModeType.ReadOnly;
        }

        private void SetupDataMembers()
        {
            ActiveSQLQuery = _qryGvGesuch;

            colTyp.ColumnEdit = grdGvAuflagen.GetLOVLookUpEdit("GvAuflageTyp");

            colBemerkung.FieldName = DBO.GvAuflage.Bemerkung;
            colBetrag.FieldName = DBO.GvAuflage.Betrag;
            colErfasst.FieldName = DBO.GvAuflage.Erfasst;
            colErledigt.FieldName = DBO.GvAuflage.Erledigt;
            colFonds.FieldName = DBO.GvFonds.NameKurz;
            colFrist.FieldName = DBO.GvAuflage.Faellig;
            colGegenstand.FieldName = DBO.GvAuflage.Gegenstand;
            colSchriftlich.FieldName = DBO.GvAuflage.SchriftlicheVerpflichtung;
            colTyp.FieldName = DBO.GvAuflage.GvAuflageTypCode;

            chkKompetenzKanton.DataMember = DBO.GvGesuch.IstKompetenzKanton;
            chkKompetenzKanton.DataSource = _qryGvGesuch;

            edtTotalBewilligt.DataMember = CtlGvGesuchverwaltung.QRY_GVGESUCH_TOTAL_FONDS_BEWILLIGT;
            edtTotalBewilligt.DataSource = _qryGvGesuch;

            edtAusbezahltFLBTotal.DataMember = CtlGvGesuchverwaltung.QRY_GVGESUCH_TOTAL_FONDS_AUSBEZAHLT;
            edtAusbezahltFLBTotal.DataSource = _qryGvGesuch;

            edtBewilligungAm.DataMember = DBO.GvGesuch.DatumBewilligtKompetenzstufe1;
            edtBewilligungAm.DataSource = _qryGvGesuch;
            edtBewilligungBemerkung.DataMember = DBO.GvGesuch.BemerkungBewilligungKompetenzstufe1;
            edtBewilligungBemerkung.DataSource = _qryGvGesuch;
            edtBewilligungBetragBeantragt.DataMember = CtlGvGesuchverwaltung.QRY_GVGESUCH_BETRAG_BEANTRAGT;
            edtBewilligungBetragBeantragt.DataSource = _qryGvGesuch;
            edtBewilligungBetragBewilligt.DataMember = DBO.GvGesuch.BetragBewilligtKompetenzstufe1;
            edtBewilligungBetragBewilligt.DataSource = _qryGvGesuch;

            edtBewilligungCHAm.DataMember = DBO.GvGesuch.DatumBewilligtKompetenzstufe2;
            edtBewilligungCHAm.DataSource = _qryGvGesuch;
            edtBewilligungCHBemerkung.DataMember = DBO.GvGesuch.BemerkungBewilligungKompetenzstufe2;
            edtBewilligungCHBemerkung.DataSource = _qryGvGesuch;
            edtBewilligungCHBetragBeantragt.DataMember = CtlGvGesuchverwaltung.QRY_GVGESUCH_BETRAG_BEANTRAGT;
            edtBewilligungCHBetragBeantragt.DataSource = _qryGvGesuch;
            edtBewilligungCHBetragBewilligt.DataMember = DBO.GvGesuch.BetragBewilligtKompetenzstufe2;
            edtBewilligungCHBetragBewilligt.DataSource = _qryGvGesuch;

            BindControls();
        }

        private void ZahlungenPruefen()
        {
            const string sqlStatement = @"
                IF EXISTS(SELECT TOP 1 1
                          FROM dbo.GvAuszahlungPosition
                          WHERE GvGesuchID = {0}
                            AND GvAuszahlungPositionStatusCode = {1})
                BEGIN
                  SELECT CONVERT(BIT, 1);
                END
                ELSE
                BEGIN
                  SELECT CONVERT(BIT, 0);
                END;";

            /* Prüfen ob importierte Zahlungen vorhanden sind */
            var auszahlungenVorhanden = DBUtil.ExecuteScalarSQLThrowingException(sqlStatement,
                _qryGvGesuch[DBO.GvGesuch.GvGesuchID],
                LOVsGenerated.GvAuszahlungPositionStatus.Importiert) as bool? ?? false;

            if (auszahlungenVorhanden)
            {
                throw new KissCancelException(
                    KissMsg.GetMLMessage(
                        CLASS_NAME,
                        "AbschlussAufheben_ZahlungenGeleistet",
                        "Für dieses Gesuch sind schon Zahlungen geleistet worden. Es lässt sich nicht mehr verändern."));
            }

            /* Prüfen ob bewilligte Zahlungen vorhanden sind */
            var grueneZahlungenVorhanden = DBUtil.ExecuteScalarSQLThrowingException(sqlStatement,
                _qryGvGesuch[DBO.GvGesuch.GvGesuchID],
                LOVsGenerated.GvAuszahlungPositionStatus.BewilligungErteilt) as bool? ?? false;

            if (grueneZahlungenVorhanden)
            {
                throw new KissCancelException(
                    KissMsg.GetMLMessage(
                        CLASS_NAME,
                        "AbschlussAufheben_BewilligteZahlungenVorhanden",
                        "Es sind bewilligte Zahlungen vorhanden. Setzen Sie diese auf Grau."));
            }
        }

        #endregion

        #endregion
    }
}