using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Inkasso
{
    public partial class CtlIkRechtstitelForderung : KissUserControl
    {
        public DateTime RechtstitelDatum;
        public int RechtstitelIndexCode;

        private const string COL_ALTER = "Alter";
        private const string COL_ALV = "ALV";

        private List<Control> _fields;
        private int _ikRechtstitelID;

        public CtlIkRechtstitelForderung()
        {
            InitializeComponent();

            colUnterhaltsanspruch.ColumnEdit = grdForderungen.GetLOVLookUpEdit("IkForderungPeriodisch");
            colAnpassungsGrund.ColumnEdit = grdForderungen.GetLOVLookUpEdit("IkAnpassungsGrund");
            colBerechnungsArt.ColumnEdit = grdForderungen.GetLOVLookUpEdit("IkAnpassungsRegel");

            SetupTag();
            SetupFieldList();
        }

        public void Init(int rechtstitelID, int fallID, bool canEdit)
        {
            _ikRechtstitelID = rechtstitelID;

            // Auswahl LOV holen, damit Indexberechnung ein- und ausgeschaltet werden kann
            // Value1 = 1, dann ist Indexberechnung eingeschaltet
            // Value1 = 0, dann ist Indexberechnung ausgeschaltet
            qryLOVListe.Fill();

            // Auswahl Adresse aus FallPersonen:
            qryPerson.Fill(_ikRechtstitelID);

            qryIkForderung.CanUpdate = qryIkForderung.CanUpdate && canEdit;
            qryIkForderung.CanInsert = qryIkForderung.CanInsert && canEdit;
            qryIkForderung.CanDelete = qryIkForderung.CanDelete && canEdit;

            edtBaPersonID.Properties.DataSource = qryPerson;

            // Daten neu anzeigen:
            ForderungenOeffnen();

            var faProzessCode = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT LEI.FaProzessCode
                FROM dbo.FaLeistung            LEI WITH (READUNCOMMITTED)
                  INNER JOIN dbo.IkRechtstitel RTT WITH (READUNCOMMITTED) ON RTT.FaLeistungID = LEI.FaLeistungID
                WHERE RTT.IkRechtstitelID = {0};", _ikRechtstitelID));

            edtIkForderungPeriodisch.LOVFilter = faProzessCode.ToString();
        }

        public void PersonenOeffnen()
        {
            qryPerson.Fill(_ikRechtstitelID);
        }

        public override bool ReceiveMessage(HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                return true;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "Refresh":
                    qryIkForderung.Refresh();
                    return true;

                case "RefreshPerson":
                    qryPerson.Refresh();
                    return true;
            }

            // did not understand message
            return false;
        }

        private void CheckNotNullFields()
        {
            _fields.Where(x => IsEditableBindable(x) && ((IKissEditable)x).EditMode == EditModeType.Required).ToList()
                   .ForEach(x => DBUtil.CheckNotNullField((IKissBindableEdit)x, x.Tag.ToString()));
        }

        private void DatumIndexSetzen()
        {
            int anpassungsregelCode = Utils.ConvertToInt(qryIkForderung[DBO.IkForderung.IkAnpassungsRegelCode]);

            if (!HasIndex() ||
                DBUtil.IsEmpty(qryIkForderung[DBO.IkForderung.DatumAnpassenAb]) ||
                anpassungsregelCode == 0 || // Code ist nicht in der LOV
                anpassungsregelCode == 7) // Keine Indexierung
            {
                // Bei diesemn gibt es keine Indexierung
                qryIkForderung[DBO.IkForderung.IndexStandDatum] = DBNull.Value;
                qryIkForderung.RefreshDisplay();
                return;
            }

            // TODO warum alle diese Prüfungen, monat ist ja immer = 11?
            int monat = 11;

            if (monat < 1 || monat > 12)
            {
                monat = 11;
            }

            int aYear = edtAnpassenAb.DateTime.Year;

            // 30.10.2008 : sozheo : bei Dezemberindex
            if (monat == 12)
            {
                var datGrenze = Convert.ToDateTime("01.02." + aYear);
                aYear -= 1;

                if (edtAnpassenAb.DateTime < datGrenze)
                {
                    aYear -= 1;
                }
            }
            else
            {
                aYear -= 1;
            }

            qryIkForderung[DBO.IkForderung.IndexStandDatum] = Convert.ToDateTime("01." + monat + "." + aYear);
            qryIkForderung.RefreshDisplay();
        }

        private void edtALBVBerechtigt_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtALBVBerechtigt.Checked)
            {
                edtTeilALBV.Checked = false;
                edtTeilALBVBetrag.EditValue = null;
            }
            SetEditMode();
        }

        private void edtAnpassenAb_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtAnpassenAb.UserModified)
            {
                return;
            }

            if (DBUtil.IsEmpty(edtAnpassenAb.EditValue))
            {
                return;
            }

            qryIkForderung[DBO.IkForderung.DatumAnpassenAb] = edtAnpassenAb.DateTime;
            DatumIndexSetzen();
            IndexPunkteSetzen();
        }

        private void edtBaPersonID_CloseUp(object sender, CloseUpEventArgs e)
        {
            e.AcceptValue = true;

            if (!e.CloseMode.Equals(PopupCloseMode.Normal))
            {
                return;
            }

            qryIkForderung["Person"] = edtBaPersonID.GetDisplayText(e.Value);

            if (qryPerson.Find("BaPersonID=" + (Utils.ConvertToInt(e.Value))))
            {
                qryIkForderung[COL_ALTER] = qryPerson[COL_ALTER];
            }
        }

        private void edtDatumIndexStand_CloseUp(object sender, CloseUpEventArgs e)
        {
            e.AcceptValue = true;

            if (!e.CloseMode.Equals(PopupCloseMode.Normal))
            {
                return;
            }

            // Indexstand neu holen:
            qryIkForderung[DBO.IkForderung.IndexStandBeiBerechnung] = GetIndexPunkte(RechtstitelIndexCode, e.Value);
        }

        private void edtIkAnpassungsRegelCode_EditValueChanged(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void edtIkForderungPeriodisch_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtIkForderungPeriodisch.UserModified)
            {
                return;
            }

            // Neuer Wert setzen
            qryIkForderung[DBO.IkForderung.IkForderungPeriodischCode] = Utils.ConvertToInt(edtIkForderungPeriodisch.EditValue);

            // Editieren einstellen
            SetEditMode();

            // Einstellen je nachdem, ob die Forderung index hat oder nicht:
            if (HasIndex())
            {
                DatumIndexSetzen();
                IndexPunkteSetzen();
            }
            else
            {
                // Alles mit Index kann gelöscht werden:
                qryIkForderung[DBO.IkForderung.IkAnpassungsGrundCode] = DBNull.Value;
                qryIkForderung[DBO.IkForderung.IkAnpassungsRegelCode] = DBNull.Value;
                qryIkForderung[DBO.IkForderung.IndexStandDatum] = DBNull.Value;
                qryIkForderung[DBO.IkForderung.IndexStandBeiBerechnung] = DBNull.Value;
                qryIkForderung.RefreshDisplay();
            }

            if (IstAliment())
            {
                // Betrag aus dem Rechtstitel holen
                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT RTT.BasisKinderalimente,
                           RTT.BasisEhegattenalimente
                    FROM dbo.IkRechtstitel RTT WITH (READUNCOMMITTED)
                    WHERE RTT.IkRechtstitelID = {0};", _ikRechtstitelID);

                if (IstKinderAliment())
                {
                    qryIkForderung[DBO.IkForderung.Betrag] = qry[DBO.IkRechtstitel.BasisKinderalimente];
                }
                else
                {
                    qryIkForderung[DBO.IkForderung.Betrag] = qry[DBO.IkRechtstitel.BasisEhegattenalimente];
                }

                qryIkForderung.RefreshDisplay();
            }
        }

        private void edtIndexStandDatum_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtIndexStandDatum.UserModified)
            {
                return;
            }

            if (DBUtil.IsEmpty(edtIndexStandDatum.EditValue))
            {
                return;
            }

            qryIkForderung[DBO.IkForderung.IndexStandDatum] = edtIndexStandDatum.DateTime;
            IndexPunkteSetzen();
        }

        private void edtTeilALBV_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtTeilALBV.Checked)
            {
                edtTeilALBVBetrag.EditValue = null;
            }

            SetEditMode();
        }

        private void ForderungenOeffnen()
        {
            qryIkForderung.Fill(_ikRechtstitelID);
        }

        private object GetIndexPunkte(object objCode, object objDatum)
        {
            if (DBUtil.IsEmpty(edtIkAnpassungsRegelCode.EditValue))
            {
                return DBNull.Value;
            }

            if (DBUtil.IsEmpty(objCode))
            {
                return DBNull.Value;
            }

            if (DBUtil.IsEmpty(objDatum))
            {
                return DBNull.Value;
            }

            if (!(objDatum is DateTime))
            {
                return DBNull.Value;
            }

            var datum = (DateTime)objDatum;
            var anpassungsRedelCode = (int)edtIkAnpassungsRegelCode.EditValue;

            if (anpassungsRedelCode == 7) //"Keine Indexierung"
            {
                return DBNull.Value;
            }

            if (anpassungsRedelCode == 4) // Dezemberindex, Basisbetrag Anpassung auf 1. Februar
            {
                datum = datum.AddMonths(1);
            }

            var code = Utils.ConvertToInt(objCode);
            var jahr = int.Parse(datum.ToString("yyyy"));
            var monat = int.Parse(datum.ToString("MM"));

            return IkUtils.GetLandesIndexWert(code, jahr, monat);
        }

        /// <summary>
        /// Liefert TRUE zurück, wenn dieser Typ eine Indexierung verlangt und gewählt wurde
        /// Diese Information ist in der LOV-Liste unter Value1 gespeichert
        /// </summary>
        /// <returns></returns>
        private bool HasIndex()
        {
            if (qryLOVListe.Find("Code=" + Utils.ConvertToInt(qryIkForderung[DBO.IkForderung.IkForderungPeriodischCode])))
            {
                return (Utils.ConvertToString(qryLOVListe[DBO.XLOVCode.Value1]) == "1");
            }

            return false;
        }

        private void IndexPunkteSetzen()
        {
            int anpassungsregelCode = Utils.ConvertToInt(qryIkForderung[DBO.IkForderung.IkAnpassungsRegelCode]);

            if (!HasIndex() ||
                DBUtil.IsEmpty(qryIkForderung[DBO.IkForderung.IndexStandDatum]) ||
                anpassungsregelCode == 0 || // Code ist nicht in der LOV
                anpassungsregelCode == 7) // Keine Indexierung
            {
                // Bei diesen gibt es kein index
                qryIkForderung[DBO.IkForderung.IndexStandBeiBerechnung] = DBNull.Value;
                return;
            }

            qryIkForderung[DBO.IkForderung.IndexStandBeiBerechnung] = GetIndexPunkte(
                RechtstitelIndexCode, qryIkForderung[DBO.IkForderung.IndexStandDatum]);
        }

        private bool IsEditableBindable(Control ctl)
        {
            return ctl is IKissEditable && ctl is IKissBindableEdit;
        }

        private bool IstAliment()
        {
            return (Utils.ConvertToInt(qryIkForderung[DBO.IkForderung.IkForderungPeriodischCode]) == 1 || // Kinderalimente
                    Utils.ConvertToInt(qryIkForderung[DBO.IkForderung.IkForderungPeriodischCode]) == 2); // Erwachsenenalimente
        }

        private bool IstKinderAliment()
        {
            return (Utils.ConvertToInt(qryIkForderung[DBO.IkForderung.IkForderungPeriodischCode]) == 1); // Kinderalimente
        }

        private bool IstTeilALBV()
        {
            return edtTeilALBV.Checked;
        }

        private void qryIkForderung_AfterFill(object sender, EventArgs e)
        {
            if (qryIkForderung.Count == 0)
            {
                qryIkForderung_PositionChanged(sender, e);
            }
        }

        private void qryIkForderung_AfterInsert(object sender, EventArgs e)
        {
            qryIkForderung[DBO.IkForderung.IkRechtstitelID] = _ikRechtstitelID;
            edtBaPersonID.Focus();
        }

        private void qryIkForderung_AfterPost(object sender, EventArgs e)
        {
            try
            {
                DBUtil.ExecSQLThrowingException("EXEC dbo.spIkMonatszahlen_DetailAll NULL, {0}, 1;", _ikRechtstitelID);
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }

            UpdateALV();
        }

        private void qryIkForderung_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            var baPersonID = Convert.ToInt32(qryIkForderung[DBO.IkForderung.BaPersonID]);
            var datumVon = qryIkForderung[DBO.IkForderung.DatumAnpassenAb] as DateTime? ?? DateTime.MinValue;
            var datumBis = qryIkForderung[DBO.IkForderung.DatumGueltigBis] as DateTime? ?? new DateTime(9999, 1, 1);

            if (IkUtils.HavingBookedPositions(_ikRechtstitelID, baPersonID, datumVon, datumBis))
            {
                KissMsg.ShowInfo(Name, "CannotDeleteIkFordExistingBookedPos", "Die Forderung kann nicht gelöscht werden, da bereits erledigte Monate vorhanden sind.");
                throw new KissCancelException();
            }
        }

        private void qryIkForderung_BeforePost(object sender, EventArgs e)
        {
            CheckNotNullFields();

            if (0 < (int)DBUtil.ExecuteScalarSQL(@"
                  SELECT COUNT(1)
                  FROM dbo.FaLeistung            LST WITH (READUNCOMMITTED)
                    INNER JOIN dbo.IkRechtstitel RTT WITH (READUNCOMMITTED) ON RTT.FaLeistungID = LST.FaLeistungID
                  WHERE RTT.IkRechtstitelID = {0}
                    AND dbo.fnDateOf(LST.DatumVon) > {1};", _ikRechtstitelID, edtAnpassenAb.EditValue))
            {
                edtAnpassenAb.Focus();
                throw new KissInfoException(
                    KissMsg.GetMLMessage(Name,
                                         "GueltigAbVorAufnahmedatum",
                                         "Datum 'Betrag gültig ab' ist ungültig:\r\n\r\nEs liegt vor dem Aufnahmedatum der Leistung",
                                         KissMsgCode.MsgInfo));
            }

            //die folgende Prüfung soll nur gemacht werden, wenn das Flag 'ALBV berechtigt' verändert wurde (siehe #6943)
            if (qryIkForderung.ColumnModified(DBO.IkForderung.ALBVBerechtigt))
            {
                bool albvBerechtigt = qryIkForderung[DBO.IkForderung.ALBVBerechtigt] as bool? ?? false;

                int baPersonID = Convert.ToInt32(qryIkForderung[DBO.IkForderung.BaPersonID]);
                DateTime datumVon = qryIkForderung[DBO.IkForderung.DatumAnpassenAb] as DateTime? ?? DateTime.MinValue;
                DateTime datumBis = qryIkForderung[DBO.IkForderung.DatumGueltigBis] as DateTime? ?? new DateTime(9999, 1, 1);

                if (!albvBerechtigt && IkUtils.AlreadyHasAccountForGivenPerson(-1, baPersonID, _ikRechtstitelID, datumVon, datumBis))
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            Name,
                            "CannotDisableAlbvHasActivVerrechnungskonto",
                            "Die Forderung muss ALBV Berechtigt sein, da noch ein aktives Verrechnungskonto vorhanden ist.",
                            KissMsgCode.MsgInfo));
                }
            }

            // Indexstand neu holen:
            qryIkForderung[DBO.IkForderung.IndexStandBeiBerechnung] = GetIndexPunkte(
                RechtstitelIndexCode, qryIkForderung[DBO.IkForderung.IndexStandDatum]);

            qryIkForderung["Person"] = edtBaPersonID.GetDisplayText(edtBaPersonID.EditValue);
        }

        private void qryIkForderung_PositionChanged(object sender, EventArgs e)
        {
            bool canEdit = qryIkForderung.Count > 0 && qryIkForderung.CanUpdate;
            qryIkForderung.EnableBoundFields(canEdit);

            SetEditMode();
        }

        private void SetEditMode()
        {
            // editMode für Anpassungsgrund, -Regel und Indexstand-Datum
            var editMode = EditModeType.ReadOnly;

            if (qryIkForderung.Count > 0 && qryIkForderung.CanUpdate && HasIndex())
            {
                editMode = EditModeType.Normal;
            }

            edtIkAnpassungsGrundCode.EditMode = editMode;
            edtIkAnpassungsRegelCode.EditMode = editMode;
            edtIndexStandDatum.EditMode = editMode;

            // set Mussfelder
            if (editMode == EditModeType.Normal)
            {
                edtIkAnpassungsGrundCode.EditMode = EditModeType.Required;
                edtIkAnpassungsRegelCode.EditMode = EditModeType.Required;

                if (Utils.ConvertToInt(edtIkAnpassungsRegelCode.EditValue) != 7) // keine indexierung
                {
                    edtIndexStandDatum.EditMode = EditModeType.Required;
                }
            }

            // editMode für edtALBVBerechtigt
            editMode = EditModeType.ReadOnly;

            if (qryIkForderung.Count > 0 && qryIkForderung.CanUpdate && IstKinderAliment())
            {
                editMode = EditModeType.Normal;
            }

            edtALBVBerechtigt.EditMode = editMode;

            edtTeilALBV.EditMode = Utils.ConvertToBool(edtALBVBerechtigt.EditValue) ? EditModeType.Normal : EditModeType.ReadOnly;

            // editMode für Teil-ALBV
            if (qryIkForderung.HasRow && qryIkForderung.CanUpdate)
            {
                edtTeilALBVBetrag.EditMode = IstTeilALBV() ? EditModeType.Required : EditModeType.ReadOnly;
            }
        }

        private void SetupFieldList()
        {
            _fields = new List<Control>
            {
                edtBaPersonID,
                edtIkForderungPeriodisch,
                edtAnpassenAb,
                edtAnpassungsBetrag,
                edtIkAnpassungsGrundCode,
                edtIkAnpassungsRegelCode,
                edtIndexStandDatum,
                edtTeilALBVBetrag
            };
        }

        private void SetupTag()
        {
            edtBaPersonID.Tag = lblBaPersonID.Text;
            edtIkForderungPeriodisch.Tag = lblIkForderungPeriodisch.Text;
            edtAnpassenAb.Tag = lblAnpassenAb.Text;
            edtAnpassungsBetrag.Tag = lblAnpassungsBetrag.Text;
            edtIkAnpassungsGrundCode.Tag = lblIkAnpassungsGrundCode.Text;
            edtIkAnpassungsRegelCode.Tag = lblIkAnpassungsRegelCode.Text;
            edtIndexStandDatum.Tag = lblIndexStandDatum.Text;
            edtTeilALBVBetrag.Tag = lblTeilALBVBetrag.Text;
        }

        private void UpdateALV()
        {
            qryIkForderung[COL_ALV] = Utils.ConvertToDecimal(edtAnpassungsBetrag.EditValue) -
                                        Utils.ConvertToDecimal(edtTeilALBVBetrag.EditValue);
        }
    }
}