using System;
using System.Drawing;
using System.Globalization;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

using DevExpress.XtraGrid.Views.Base;

namespace KiSS4.Inkasso
{
    public partial class CtlIkMonatszahlenEinmalig : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string QIPO_BETRAG_AUSGEGLICHEN = "BetragAusgeglichen";

        #endregion

        #region Private Fields

        private int _faLeistungID;
        private int _ikRechtstitelID;
        private bool _startedFromRechtstitel;

        #endregion

        #endregion

        #region Constructors

        public CtlIkMonatszahlenEinmalig()
        {
            InitializeComponent();

            SetupFieldNames();
            SetupDataMembers();
        }

        #endregion

        #region EventHandlers

        private void CtlIkMonatszahlenEinmalig_Load(object sender, EventArgs e)
        {
            colIkForderungCode.ColumnEdit = grdIkPosition.GetLOVLookUpEdit("IkForderungEinmalig");
        }

        private void grvIkPosition_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            e.Handled = false;
            if (grvIkPosition.FocusedRowHandle == e.RowHandle)
            {
                return;
            }

            bool erledigt = (grvIkPosition.GetRowCellValue(e.RowHandle, grvIkPosition.Columns[DBO.IkPosition.ErledigterMonat]) as bool?) ?? false;

            if (erledigt)
            {
                e.Appearance.BackColor = Color.LightSalmon;
            }
            else
            {
                e.Appearance.BackColor = Color.Bisque;
            }
        }

        private void qryIkPosition_AfterFill(object sender, EventArgs e)
        {
            if (qryIkPosition.IsEmpty)
            {
                qryIkPosition_PositionChanged(sender, e);
            }
        }

        private void qryIkPosition_AfterInsert(object sender, EventArgs e)
        {
            if (_startedFromRechtstitel)
            {
                qryIkPosition[DBO.IkPosition.IkRechtstitelID] = _ikRechtstitelID;
            }
            else
            {
                qryIkPosition[DBO.IkPosition.FaLeistungID] = _faLeistungID;
            }

            qryIkPosition[DBO.IkPosition.Unterstuetzungsfall] = 0;
            qryIkPosition[DBO.IkPosition.ErledigterMonat] = 0;
            qryIkPosition[DBO.IkPosition.Einmalig] = 1;

            edtBaPersonID.Focus();
        }

        private void qryIkPosition_AfterPost(object sender, EventArgs e)
        {
            qryPerson.Find(string.Format("BaPersonID = {0}", qryIkPosition[DBO.IkPosition.BaPersonID]));
            qryIkPosition[DBO.vwPerson.NameVorname] = qryPerson[DBO.vwPerson.NameVorname]; //Ticket 2951
        }

        private void qryIkPosition_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtBaPersonID, lblBaPersonID.Text);
            DBUtil.CheckNotNullField(edtIkForderungEinmaligCode, lblIkForderungEinmaligCode.Text);
            DBUtil.CheckNotNullField(edtDatum, lblDatum.Text);
            DBUtil.CheckNotNullField(edtBetragEinmalig, lblBetragEinmalig.Text);

            if (Utils.ConvertToDecimal(qryIkPosition[DBO.IkPosition.BetragEinmalig]) < 0)
            {
                KissMsg.ShowInfo(Name, "BetragNotNegativ", "Der Betrag darf nicht kleiner als 0 sein.");
                throw new KissCancelException();
            }

            qryIkPosition[DBO.IkPosition.TotalAliment] = DBNull.Value;
            qryIkPosition[DBO.IkPosition.BetragALBV] = DBNull.Value;
            qryIkPosition[DBO.IkPosition.BetragKiZulage] = DBNull.Value;
            qryIkPosition[DBO.IkPosition.BetragALBVverrechnung] = DBNull.Value;

            qryIkPosition[DBO.IkPosition.Monat] = ((DateTime)qryIkPosition[DBO.IkPosition.Datum]).Month;
            qryIkPosition[DBO.IkPosition.Jahr] = ((DateTime)qryIkPosition[DBO.IkPosition.Datum]).Year;

            if (_startedFromRechtstitel)
            {
                qryIkPosition[DBO.vwPerson.NameVorname] = edtBaPersonID.GetDisplayText(edtBaPersonID.EditValue);
            }

            qryIkPosition[DBO.IkPosition.Unterstuetzungsfall] = IstUnterstuetzungsfall((int)qryIkPosition[DBO.IkPosition.IkForderungCode]);

            if (IstBevorschussung((int)qryIkPosition[DBO.IkPosition.IkForderungCode]) && !(bool)qryIkPosition[DBO.IkPosition.BetragIstNegativ])
            {
                qryIkPosition[DBO.IkPosition.BetragAuszahlung] = qryIkPosition[DBO.IkPosition.BetragEinmalig];
                qryIkPosition[DBO.IkPosition.ALBVBerechtigt] = true;
            }
            else
            {
                qryIkPosition[DBO.IkPosition.BetragAuszahlung] = DBNull.Value;
                qryIkPosition[DBO.IkPosition.ALBVBerechtigt] = false;
            }
        }

        private void qryIkPosition_PositionChanged(object sender, EventArgs e)
        {
            bool canEdit = (
                               qryIkPosition.CanUpdate &&
                               !qryIkPosition.IsEmpty &&
                               (_ikRechtstitelID > 0 || _faLeistungID > 0)
                           );

            qryIkPosition.EnableBoundFields(canEdit);

            canEdit = canEdit && (!(bool)qryIkPosition[DBO.IkPosition.ErledigterMonat]);

            if (canEdit)
            {
                edtBaPersonID.EditMode = EditModeType.Required;
                edtIkForderungEinmaligCode.EditMode = EditModeType.Required;
                edtDatum.EditMode = EditModeType.Required;
                edtBetragEinmalig.EditMode = EditModeType.Required;
                edtBetragIstNegativ.EditMode = EditModeType.Normal;
            }
            else
            {
                edtBaPersonID.EditMode = EditModeType.ReadOnly;
                edtIkForderungEinmaligCode.EditMode = EditModeType.ReadOnly;
                edtDatum.EditMode = EditModeType.ReadOnly;
                edtBetragEinmalig.EditMode = EditModeType.ReadOnly;
                edtBetragIstNegativ.EditMode = EditModeType.ReadOnly;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Activate()
        {
            edtBaPersonID.Focus();
        }

        public void Init(int rechtstitelID, int leistungID, int fallID, bool canEdit, bool fromRechtstitel)
        {
            _ikRechtstitelID = rechtstitelID;
            _faLeistungID = leistungID;
            _startedFromRechtstitel = fromRechtstitel;
            string faProzessCode;
            if (_startedFromRechtstitel)
            {
                // Das Fenster wurde vom Ast "Rechsttitel", Unterast Monatszahlen aufgerufen:
                qryPerson.Fill(_ikRechtstitelID, DBNull.Value);
                edtBaPersonID.Properties.DataSource = qryPerson;
                faProzessCode = GetFaProzessCodeByRechtstitel().ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                // Das Fenster wurde vom Ast "Rückforderung ALBV" aufgerufen:
                qryPerson.Fill(DBNull.Value, _faLeistungID);
                edtBaPersonID.Properties.DataSource = qryPerson;
                faProzessCode = GetFaProzessCodeByFaLeistungID().ToString(CultureInfo.InvariantCulture);
            }

            //We have to apply the FaProzessCode to the LookupEdit before qryIkPosition is filled (because qryIkPosition.Fill(...) triggers qryIkPosition.PositionChanged event)
            edtIkForderungEinmaligCode.LOVFilter = faProzessCode;
            edtIkForderungEinmaligCode.LOVFilterWhereAppend = false; //if LOVFilter contains a FaProzessCode, LOVFilterWhereAppend must be set to false

            //after setting the FaProzessCode, the lookupEdit has to read the LOV again
            edtIkForderungEinmaligCode.ReadLOV();

            qryIkPosition.Fill(_ikRechtstitelID, _faLeistungID, _startedFromRechtstitel);
        }

        private int GetFaProzessCodeByFaLeistungID()
        {
            return (int)
                   DBUtil.ExecuteScalarSQL(
                       @"
                    SELECT FaProzessCode 
                    FROM dbo.FaLeistung WITH (READUNCOMMITTED) 
                    WHERE FaLeistungID = {0}",
                       _faLeistungID);
        }

        private int GetFaProzessCodeByRechtstitel()
        {
            return (int)
                   DBUtil.ExecuteScalarSQL(
                       @"
                    SELECT LST.FaProzessCode
                    FROM dbo.IkRechtstitel      RTT WITH (READUNCOMMITTED)
                      INNER JOIN dbo.FaLeistung LST WITH (READUNCOMMITTED) ON LST.FaLeistungID = RTT.FaLeistungID
                    WHERE IkRechtstitelID = {0};",
                       _ikRechtstitelID);
        }

        #endregion

        #region Private Static Methods

        private static bool IstBevorschussung(int ikForderungEinmaligCode)
        {
            return ikForderungEinmaligCode == 2; // Kinderalimente (Bevorschussung)
        }

        /// <summary>
        /// Zum wissen ob eine einmalige Forderung ein Unterstützungsfall ist oder nicht.
        /// </summary>
        /// <param name="ikForderungEinmaligCode"></param>
        /// <returns>true wenn es Unterstützungsfall ist</returns>
        private static bool IstUnterstuetzungsfall(int ikForderungEinmaligCode)
        {
            return ikForderungEinmaligCode == 1 ||  // Kinderalimente (Unterstützungsfall)
                   ikForderungEinmaligCode == 5 ||  // Erwachsenenalimente (Unterstützungsfall)
                   ikForderungEinmaligCode == 7 ||  // Kinderzulagen (Unterstützungsfall)
                   ikForderungEinmaligCode == 14 || // Inkassokosten (Unterstützungsfall)
                   ikForderungEinmaligCode == 16;   // Zins (Unterstützung)
        }

        #endregion

        #region Private Methods

        private void SetupDataMembers()
        {
            edtBaPersonID.DataMember = DBO.IkPosition.BaPersonID;
            edtBemerkung.DataMember = DBO.IkPosition.Bemerkung;
            edtBetragAusgeglichen.DataMember = QIPO_BETRAG_AUSGEGLICHEN;
            edtBetragEinmalig.DataMember = DBO.IkPosition.BetragEinmalig;
            edtBetragIstNegativ.DataMember = DBO.IkPosition.BetragIstNegativ;
            edtDatum.DataMember = DBO.IkPosition.Datum;
            edtIkForderungEinmaligCode.DataMember = DBO.IkPosition.IkForderungCode;
            edtVerbucht.DataMember = DBO.IkPosition.ErledigterMonat;
        }

        private void SetupFieldNames()
        {
            colBetrag.FieldName = DBO.IkPosition.BetragEinmalig;
            colBetragAusgeglichen.FieldName = QIPO_BETRAG_AUSGEGLICHEN;
            colDatum.FieldName = DBO.IkPosition.Datum;
            colNegativ.FieldName = DBO.IkPosition.BetragIstNegativ;
            colPerson.FieldName = DBO.vwPerson.NameVorname;
            colIkForderungCode.FieldName = DBO.IkPosition.IkForderungCode;
            colVerbucht.FieldName = DBO.IkPosition.ErledigterMonat;
        }

        #endregion

        #endregion
    }
}