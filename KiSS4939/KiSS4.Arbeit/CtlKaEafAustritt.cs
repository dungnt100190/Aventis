using System;
using DevExpress.XtraEditors.Controls;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public partial class CtlKaEafAustritt : KissComplexControl
    {
        private const string CLASSNAME = "CtlKaEafAustritt";

        private int _currentAustrittsgrund;

        public CtlKaEafAustritt()
        {
            InitializeComponent();
        }

        public override SqlQuery ActiveSQLQuery
        {
            get
            {
                return base.ActiveSQLQuery;
            }
            set
            {
                if (ActiveSQLQuery != null)
                {
                    ActiveSQLQuery.BeforePost -= ActiveSQLQuery_BeforePost;
                }

                base.ActiveSQLQuery = value;

                edtAustrittAbbruch.DataSource = value;
                edtAustrittAustrittsgrund.DataSource = value;
                edtAustrittDatum.DataSource = value;
                edtAustrittMassnahmeBeendet.DataSource = value;

                if (value != null)
                {
                    value.BeforePost += ActiveSQLQuery_BeforePost;
                }
            }
        }

        public string DataMemberAbbruch
        {
            get { return edtAustrittAbbruch.DataMember; }
            set { edtAustrittAbbruch.DataMember = value; }
        }

        public string DataMemberAustrittsgrund
        {
            get { return edtAustrittAustrittsgrund.DataMember; }
            set { edtAustrittAustrittsgrund.DataMember = value; }
        }

        public string DataMemberDatum
        {
            get { return edtAustrittDatum.DataMember; }
            set { edtAustrittDatum.DataMember = value; }
        }

        public string DataMemberMassnahmeBeendet
        {
            get { return edtAustrittMassnahmeBeendet.DataMember; }
            set { edtAustrittMassnahmeBeendet.DataMember = value; }
        }

        public int FaLeistungId
        {
            get;
            set;
        }

        public void UpdateEditmode()
        {
            _currentAustrittsgrund = Utils.ConvertToInt(edtAustrittAustrittsgrund.EditValue);
            btnAustrittZuruecksetzen.Enabled = false;

            if (!ActiveSQLQuery.CanUpdate)
            {
                return;
            }

            edtAustrittDatum.EditMode = EditModeType.Normal;
            edtAustrittAbbruch.EditMode = EditModeType.ReadOnly;
            edtAustrittAustrittsgrund.EditMode = EditModeType.ReadOnly;
            edtAustrittMassnahmeBeendet.EditMode = EditModeType.ReadOnly;

            if (!DBUtil.IsEmpty(edtAustrittDatum.EditValue))
            {
                btnAustrittZuruecksetzen.Enabled = true;
                edtAustrittDatum.EditMode = EditModeType.Required;
                edtAustrittAustrittsgrund.EditMode = EditModeType.Required;

                switch (_currentAustrittsgrund)
                {
                    case 1:
                        edtAustrittMassnahmeBeendet.EditMode = EditModeType.Required;
                        break;

                    case 2:
                    case 3:
                    case 4:
                        edtAustrittAbbruch.EditMode = EditModeType.Required;
                        break;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateEditmode();
        }

        private void ActiveSQLQuery_BeforePost(object sender, EventArgs e)
        {
            /* Prüfen ob das Abschlussdatum Teil eines Arbeitsrapports ist.
             * Wenn nicht, wird eine Meldung ausgegeben.
             * Es wird ignoriert wenns keinen Arbeitsrapport hat.*/
            if (KaUtil.IsDatePartOfAnArbeitsRapportRange(FaLeistungId, edtAustrittDatum.EditValue as DateTime?))
            {
                // prüfen ob KaArbeitsrapport-Einträge vor dem neuen Datum vorhanden sind
                DateTime? datumVon;
                DateTime? datumBis;
                var hatArbeitsrapport = KaUtil.WouldKaArbeitsRapportRecordsBeDeleted(
                    FaLeistungId,
                    edtAustrittDatum.EditValue as DateTime?,
                    out datumVon,
                    out datumBis);

                // wenn ja, fragen ob die Daten gelöscht werden können
                if (hatArbeitsrapport && datumVon.HasValue && datumBis.HasValue)
                {
                    var answer = KissMsg.ShowQuestion(
                        CLASSNAME,
                        "FrageZeiterfassungLoeschen",
                        "Es sind bereits Daten für die Präsenzzeiterfassung vor dem {0} oder nach dem {1} vorhanden." + Environment.NewLine +
                        "Wollen Sie diese Daten löschen?",
                        true,
                        datumVon.Value.ToShortDateString(),
                        datumBis.Value.ToShortDateString());

                    if (!answer)
                    {
                        throw new KissCancelException();
                    }
                }
            }
            else
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(CLASSNAME, "ErrorDatumNichtInnerhalbZeiterfassung_V2", "Das Austrittsdatum liegt nicht innerhalb einer Anweisung."));
            }

            if (!DBUtil.IsEmpty(edtAustrittDatum.EditValue))
            {
                DBUtil.CheckNotNullField(edtAustrittAustrittsgrund, lblAustrittAustrittsgrund.Text);
            }

            if (!DBUtil.IsEmpty(edtAustrittAustrittsgrund.EditValue))
            {
                DBUtil.CheckNotNullField(edtAustrittDatum, lblAustrittDatum.Text);

                switch (_currentAustrittsgrund)
                {
                    case 1:
                        DBUtil.CheckNotNullField(edtAustrittMassnahmeBeendet, "Massnahme beendet");
                        break;

                    case 2:
                    case 3:
                    case 4:
                        DBUtil.CheckNotNullField(edtAustrittAbbruch, "Abbruch");
                        break;
                }
            }
        }

        private void btnAustrittZuruecksetzen_Click(object sender, EventArgs e)
        {
            if (KissMsg.ShowQuestion(CLASSNAME, "WerteZuruecksetzen", "Folgende Werte zurücksetzen:\r\nDatum, Austrittsgrund (inkl. Auswahl)?"))
            {
                edtAustrittDatum.EditValue = null;
                edtAustrittAustrittsgrund.EditValue = null;
                edtAustrittMassnahmeBeendet.EditValue = null;
                edtAustrittAbbruch.EditValue = null;
                UpdateEditmode();
            }
        }

        private void edtAustrittAustrittsgrund_EditValueChanged(object sender, EventArgs e)
        {
            UpdateEditmode();
        }

        private void edtAustrittAustrittsgrund_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (ActiveSQLQuery.IsFilling || DBUtil.IsEmpty(e.NewValue))
            {
                return;
            }

            if (Utils.ConvertToInt(edtAustrittAustrittsgrund.EditValue) == 1)
            {
                if (!DBUtil.IsEmpty(edtAustrittAbbruch.EditValue))
                {
                    if (KissMsg.ShowQuestion(CLASSNAME, "WertAbbruchLoeschen", "Wert in Auswahl 'Abbruch' löschen?"))
                    {
                        edtAustrittAbbruch.EditValue = null;
                    }
                    else
                    {
                        // reset: e.Cancel = true funktioniert nicht richtig, daher EditValue erneut setzen
                        // e.NewValue / e.OldValue funktioniert bei LOVs auch nicht richtig, daher Member mit altem Wert verwenden
                        edtAustrittAustrittsgrund.EditValue = _currentAustrittsgrund;
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                if (!DBUtil.IsEmpty(edtAustrittMassnahmeBeendet.EditValue))
                {
                    if (KissMsg.ShowQuestion(CLASSNAME, "WertMassnahmeBeendetLoeschen", "Wert in Auswahl 'Massnahme beendet' löschen?", true))
                    {
                        edtAustrittMassnahmeBeendet.EditValue = null;
                    }
                    else
                    {
                        // reset
                        edtAustrittAustrittsgrund.EditValue = _currentAustrittsgrund;
                        e.Cancel = true;
                    }
                }
            }

            UpdateEditmode();
        }

        private void edtAustrittDatum_EditValueChanged(object sender, EventArgs e)
        {
            UpdateEditmode();
        }
    }
}