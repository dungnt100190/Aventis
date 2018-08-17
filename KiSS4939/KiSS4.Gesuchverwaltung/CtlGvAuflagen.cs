using System;
using System.Data;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Gesuchverwaltung
{
    public partial class CtlGvAuflagen : GvBaseControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string QRY_GV_AUFLAGE_BEREITS_ZURUECKBEZAHLT = "BereitsZurueckbezahlt";
        private const string QRY_GV_AUFLAGE_OFFENER_BETRAG = "OffenerBetrag";
        private readonly bool _canDelete;
        private readonly bool _canInsert;
        private readonly bool _canUpdate;

        #endregion

        #endregion

        #region Constructors

        public CtlGvAuflagen(SqlQuery qryGvGesuch, bool hasKompetenzstufe0, bool hasKompetenzstufe1, bool hasKompetenzstufe2)
            : base(qryGvGesuch, hasKompetenzstufe0, hasKompetenzstufe1, hasKompetenzstufe2)
        {
            InitializeComponent();

            SetupDataMembers();
            SetupFieldNames();

            _canDelete = qryGvAuflage.CanDelete;
            _canInsert = qryGvAuflage.CanInsert;
            _canUpdate = qryGvAuflage.CanUpdate;
        }

        #endregion

        #region Properties

        private bool IstRueckerstattung
        {
            get { return Utils.ConvertToInt(qryGvAuflage[DBO.GvAuflage.GvAuflageTypCode]) == (int)LOVsGenerated.GvAuflageTyp.Rueckerstattung; }
        }

        #endregion

        #region EventHandlers

        private void edtBetragRate_EditValueChanged(object sender, EventArgs e)
        {
            UpdateGuiRueckerstattung();
        }

        private void edtErlassen_EditValueChanged(object sender, EventArgs e)
        {
            UpdateGui();
        }

        private void edtSchriftlicheVerpflichtung_EditValueChanged(object sender, EventArgs e)
        {
            btnDokument.Enabled = edtSchriftlicheVerpflichtung.Checked;
        }

        private void edtTyp_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            // Kann nicht über EditValueChanged gemacht werden, da durch das Verändern eines Werts im Query der Eventhandler ein zweites Mal
            // aufgerufen wird, was schliesslich ein Ändern des Wertes verhindert.

            // Typ setzen, da er durch das Registrieren des UserModifiedFld-EventHandlers wieder gelöscht würde.
            qryGvAuflage[DBO.GvAuflage.GvAuflageTypCode] = edtTyp.EditValue;

            // Rückerstattungs-Felder löschen
            qryGvAuflage[DBO.GvAuflage.Betrag] = null;
            qryGvAuflage[DBO.GvAuflage.Erlassen] = false;
            qryGvAuflage[DBO.GvAuflage.Erlassungsgrund] = null;
            qryGvAuflage[DBO.GvAuflage.Rate1Betrag] = null;
            qryGvAuflage[DBO.GvAuflage.Rate2Betrag] = null;
            qryGvAuflage[DBO.GvAuflage.Rate3Betrag] = null;
            qryGvAuflage[DBO.GvAuflage.Rate4Betrag] = null;
            qryGvAuflage[DBO.GvAuflage.Rate5Betrag] = null;
            qryGvAuflage[DBO.GvAuflage.Rate6Betrag] = null;
            qryGvAuflage[DBO.GvAuflage.Rate7Betrag] = null;
            qryGvAuflage[DBO.GvAuflage.Rate8Betrag] = null;
            qryGvAuflage[DBO.GvAuflage.Rate1Datum] = null;
            qryGvAuflage[DBO.GvAuflage.Rate2Datum] = null;
            qryGvAuflage[DBO.GvAuflage.Rate3Datum] = null;
            qryGvAuflage[DBO.GvAuflage.Rate4Datum] = null;
            qryGvAuflage[DBO.GvAuflage.Rate5Datum] = null;
            qryGvAuflage[DBO.GvAuflage.Rate6Datum] = null;
            qryGvAuflage[DBO.GvAuflage.Rate7Datum] = null;
            qryGvAuflage[DBO.GvAuflage.Rate8Datum] = null;

            BetraegeBerechnen();
            UpdateGui();
        }

        private void qryGvAuflage_AfterInsert(object sender, EventArgs e)
        {
            qryGvAuflage[DBO.GvAuflage.GvGesuchID] = _gvGesuchId;
            qryGvAuflage[DBO.GvAuflage.Erfasst] = DateTime.Today;
            qryGvAuflage[DBO.GvAuflage.GvAuflageTypCode] = LOVsGenerated.GvAuflageTyp.Rueckerstattung;

            UpdateGui();
        }

        private void qryGvAuflage_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtErfasst, lblErfasst.Text);
            DBUtil.CheckNotNullField(edtGegenstand, lblGegenstand.Text);
            DBUtil.CheckNotNullField(edtTyp, lblTyp.Text);
            DBUtil.CheckNotNullField(edtFaellig, lblFaellig.Text);

            // Erlassungsgrund ist ein Mussfeld, wenn das Erlassen-Flag gesetzt ist
            if (Utils.ConvertToBool(qryGvAuflage[DBO.GvAuflage.Erlassen]))
            {
                DBUtil.CheckNotNullField(edtErlassungsgrund, lblErlassungsgrund.Text);
            }

            if (IstRueckerstattung)
            {
                DBUtil.CheckNotNullField(edtBetragRueckerstattung, lblBetragRueckerstattung.Text);

                // Beträge berechnen und Erledigt-Flag setzen, wenn offener Betrag <= 0
                BetraegeBerechnen();

                // Wenn Erledigt-Flag entfernt wird, darf es allerdings nicht wieder überschrieben werden
                var erledigtOriginal = qryGvAuflage.CurrentRowState == DataRowState.Modified &&
                                       Utils.ConvertToBool(qryGvAuflage[DBO.GvAuflage.Erledigt, DataRowVersion.Original]);
                var erledigtCurrent = Utils.ConvertToBool(qryGvAuflage[DBO.GvAuflage.Erledigt, DataRowVersion.Current]);

                if ((Utils.ConvertToDecimal(qryGvAuflage[QRY_GV_AUFLAGE_OFFENER_BETRAG]) <= 0m) && (erledigtOriginal == erledigtCurrent))
                {
                    qryGvAuflage[DBO.GvAuflage.Erledigt] = true;
                }
            }
        }

        private void qryGvAuflage_PositionChanged(object sender, EventArgs e)
        {
            UpdateGui();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void LoadData(bool refresh)
        {
            if (refresh)
            {
                qryGvAuflage.Fill(_gvGesuchId);
                qryGvAuflage.Last();
            }

            UpdateGui();
        }

        protected override void UpdateGui()
        {
            grvAuflagen.BestFitColumns();

            edtBetragRueckerstattung.EditMode = IstRueckerstattung ? EditModeType.Required : EditModeType.ReadOnly;

            var istErlassen = Utils.ConvertToBool(edtErlassen.EditValue);
            edtErlassungsgrund.EditMode = istErlassen ? EditModeType.Required : EditModeType.ReadOnly;

            UpdateGuiRueckerstattung();

            GesuchAbgeschlossen();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Berechnet die Felder 'BereitsZuruechbezahlt' und 'OffenerBetrag'.
        /// </summary>
        private void BetraegeBerechnen()
        {
            var rate1 = DBUtil.IsEmpty(qryGvAuflage[DBO.GvAuflage.Rate1Datum]) ? 0m : Utils.ConvertToDecimal(qryGvAuflage[DBO.GvAuflage.Rate1Betrag]);
            var rate2 = DBUtil.IsEmpty(qryGvAuflage[DBO.GvAuflage.Rate2Datum]) ? 0m : Utils.ConvertToDecimal(qryGvAuflage[DBO.GvAuflage.Rate2Betrag]);
            var rate3 = DBUtil.IsEmpty(qryGvAuflage[DBO.GvAuflage.Rate3Datum]) ? 0m : Utils.ConvertToDecimal(qryGvAuflage[DBO.GvAuflage.Rate3Betrag]);
            var rate4 = DBUtil.IsEmpty(qryGvAuflage[DBO.GvAuflage.Rate4Datum]) ? 0m : Utils.ConvertToDecimal(qryGvAuflage[DBO.GvAuflage.Rate4Betrag]);
            var rate5 = DBUtil.IsEmpty(qryGvAuflage[DBO.GvAuflage.Rate5Datum]) ? 0m : Utils.ConvertToDecimal(qryGvAuflage[DBO.GvAuflage.Rate5Betrag]);
            var rate6 = DBUtil.IsEmpty(qryGvAuflage[DBO.GvAuflage.Rate6Datum]) ? 0m : Utils.ConvertToDecimal(qryGvAuflage[DBO.GvAuflage.Rate6Betrag]);
            var rate7 = DBUtil.IsEmpty(qryGvAuflage[DBO.GvAuflage.Rate7Datum]) ? 0m : Utils.ConvertToDecimal(qryGvAuflage[DBO.GvAuflage.Rate7Betrag]);
            var rate8 = DBUtil.IsEmpty(qryGvAuflage[DBO.GvAuflage.Rate8Datum]) ? 0m : Utils.ConvertToDecimal(qryGvAuflage[DBO.GvAuflage.Rate8Betrag]);

            var bereitsZurueckbezahlt = rate1 + rate2 + rate3 + rate4 + rate5 + rate6 + rate7 + rate8;
            var offenerBetrag = Utils.ConvertToDecimal(qryGvAuflage[DBO.GvAuflage.Betrag]) - bereitsZurueckbezahlt;

            qryGvAuflage[QRY_GV_AUFLAGE_BEREITS_ZURUECKBEZAHLT] = bereitsZurueckbezahlt;
            qryGvAuflage[QRY_GV_AUFLAGE_OFFENER_BETRAG] = offenerBetrag;
        }

        private void GesuchAbgeschlossen()
        {
            if (Utils.ConvertToInt(_qryGvGesuch["GvStatusCode"]) == Convert.ToInt32(LOVsGenerated.GvStatus.Abgeschlossen))
            {
                qryGvAuflage.CanDelete = false;
                qryGvAuflage.CanInsert = false;
                qryGvAuflage.CanUpdate = false;
                qryGvAuflage.EnableBoundFields();
            }
            else
            {
                qryGvAuflage.CanDelete = _canDelete;
                qryGvAuflage.CanInsert = _canInsert;
                qryGvAuflage.CanUpdate = _canUpdate;
                qryGvAuflage.EnableBoundFields(!qryGvAuflage.IsEmpty);
            }
        }

        private void SetupDataMembers()
        {
            edtErfasst.DataMember = DBO.GvAuflage.Erfasst;
            edtGegenstand.DataMember = DBO.GvAuflage.Gegenstand;
            edtTyp.DataMember = DBO.GvAuflage.GvAuflageTypCode;
            edtBetragRueckerstattung.DataMember = DBO.GvAuflage.Betrag;
            edtFaellig.DataMember = DBO.GvAuflage.Faellig;
            edtSchriftlicheVerpflichtung.DataMember = DBO.GvAuflage.SchriftlicheVerpflichtung;
            edtErledigt.DataMember = DBO.GvAuflage.Erledigt;
            edtErlassen.DataMember = DBO.GvAuflage.Erlassen;
            edtBemerkung.DataMember = DBO.GvAuflage.Bemerkung;
            edtErlassungsgrund.DataMember = DBO.GvAuflage.Erlassungsgrund;

            // Rückerstattung
            edtBetragRate1.DataMember = DBO.GvAuflage.Rate1Betrag;
            edtBetragRate2.DataMember = DBO.GvAuflage.Rate2Betrag;
            edtBetragRate3.DataMember = DBO.GvAuflage.Rate3Betrag;
            edtBetragRate4.DataMember = DBO.GvAuflage.Rate4Betrag;
            edtBetragRate5.DataMember = DBO.GvAuflage.Rate5Betrag;
            edtBetragRate6.DataMember = DBO.GvAuflage.Rate6Betrag;
            edtBetragRate7.DataMember = DBO.GvAuflage.Rate7Betrag;
            edtBetragRate8.DataMember = DBO.GvAuflage.Rate8Betrag;
            edtDatumRate1.DataMember = DBO.GvAuflage.Rate1Datum;
            edtDatumRate2.DataMember = DBO.GvAuflage.Rate2Datum;
            edtDatumRate3.DataMember = DBO.GvAuflage.Rate3Datum;
            edtDatumRate4.DataMember = DBO.GvAuflage.Rate4Datum;
            edtDatumRate5.DataMember = DBO.GvAuflage.Rate5Datum;
            edtDatumRate6.DataMember = DBO.GvAuflage.Rate6Datum;
            edtDatumRate7.DataMember = DBO.GvAuflage.Rate7Datum;
            edtDatumRate8.DataMember = DBO.GvAuflage.Rate8Datum;

            edtBereitsZurueckbezahlt.DataMember = QRY_GV_AUFLAGE_BEREITS_ZURUECKBEZAHLT;
            edtOffenerBetrag.DataMember = QRY_GV_AUFLAGE_OFFENER_BETRAG;
        }

        private void SetupFieldNames()
        {
            colGvAuflageTyp.ColumnEdit = grdAuflagen.GetLOVLookUpEdit("GvAuflageTyp");

            colErfasst.FieldName = DBO.GvAuflage.Erfasst;
            colGvAuflageID.FieldName = DBO.GvAuflage.GvAuflageID;
            colGvAuflageTyp.FieldName = DBO.GvAuflage.GvAuflageTypCode;
            colGegenstand.FieldName = DBO.GvAuflage.Gegenstand;
            colSchriftlicheVerpflichtung.FieldName = DBO.GvAuflage.SchriftlicheVerpflichtung;
            colBetrag.FieldName = DBO.GvAuflage.Betrag;
            colBereitsZurueckbezahlt.FieldName = QRY_GV_AUFLAGE_BEREITS_ZURUECKBEZAHLT;
            colFaellig.FieldName = DBO.GvAuflage.Faellig;
            colErledigt.FieldName = DBO.GvAuflage.Erledigt;
            colErlassen.FieldName = DBO.GvAuflage.Erlassen;
            colBemerkung.FieldName = DBO.GvAuflage.Bemerkung;
        }

        /// <summary>
        /// Aktiviert/Deaktiviert die Rückerstattung-Controls.
        /// </summary>
        private void UpdateGuiRueckerstattung()
        {
            // Rückerstattungsraten nur aktivieren, wenn in vorheriger Rate ein Betrag steht
            var istRueckerstattung = IstRueckerstattung;
            edtBetragRate1.SetEditModeIfDifferent(istRueckerstattung ? EditModeType.Normal : EditModeType.ReadOnly);

            edtBetragRate2.SetEditModeIfDifferent(istRueckerstattung && !DBUtil.IsEmpty(edtBetragRate1.EditValue)
                                          ? EditModeType.Normal
                                          : EditModeType.ReadOnly);

            edtBetragRate3.SetEditModeIfDifferent(istRueckerstattung && !DBUtil.IsEmpty(edtBetragRate2.EditValue)
                                          ? EditModeType.Normal
                                          : EditModeType.ReadOnly);

            edtBetragRate4.SetEditModeIfDifferent(istRueckerstattung && !DBUtil.IsEmpty(edtBetragRate3.EditValue)
                                          ? EditModeType.Normal
                                          : EditModeType.ReadOnly);

            edtBetragRate5.SetEditModeIfDifferent(istRueckerstattung && !DBUtil.IsEmpty(edtBetragRate4.EditValue)
                                          ? EditModeType.Normal
                                          : EditModeType.ReadOnly);

            edtBetragRate6.SetEditModeIfDifferent(istRueckerstattung && !DBUtil.IsEmpty(edtBetragRate5.EditValue)
                                          ? EditModeType.Normal
                                          : EditModeType.ReadOnly);

            edtBetragRate7.SetEditModeIfDifferent(istRueckerstattung && !DBUtil.IsEmpty(edtBetragRate6.EditValue)
                                          ? EditModeType.Normal
                                          : EditModeType.ReadOnly);

            edtBetragRate8.SetEditModeIfDifferent(istRueckerstattung && !DBUtil.IsEmpty(edtBetragRate7.EditValue)
                                          ? EditModeType.Normal
                                          : EditModeType.ReadOnly);

            // Datumsfelder sollen gleichen EditMode haben wie Betragsfelder
            edtDatumRate1.EditMode = edtBetragRate1.EditMode;
            edtDatumRate2.EditMode = edtBetragRate2.EditMode;
            edtDatumRate3.EditMode = edtBetragRate3.EditMode;
            edtDatumRate4.EditMode = edtBetragRate4.EditMode;
            edtDatumRate5.EditMode = edtBetragRate5.EditMode;
            edtDatumRate6.EditMode = edtBetragRate6.EditMode;
            edtDatumRate7.EditMode = edtBetragRate7.EditMode;
            edtDatumRate8.EditMode = edtBetragRate8.EditMode;
        }

        #endregion

        #endregion
    }
}