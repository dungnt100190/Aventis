using System;
using System.Data;

using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.XtraEditors.Controls;

namespace KiSS4.Vormundschaft.ZH
{
    /// <summary>
    /// Class to manage the booking text that are availlable for a given BgPositionsartID
    /// </summary>
    public class KgBuchungstext
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly EditorButton _button;
        private readonly KissComboBox _edtBuchungstext;
        private readonly SqlQuery _qryKgKontoBuchungstext;
        private readonly SqlQuery _query;

        private const string KG_KONTO_BUCHUNGSTEXT_BUCHUNGSTEXT = "Buchungstext";
        private const string KG_KONTO_BUCHUNGSTEXT_IS_DEFAULT = "IsDefault";

        #endregion

        #endregion

        #region Constructors

        public KgBuchungstext(KissComboBox edt, SqlQuery query)
        {
            _edtBuchungstext = edt;
            _query = query;

            _button = _edtBuchungstext.Properties.Buttons[0];

            _qryKgKontoBuchungstext = new SqlQuery
            {
                SelectStatement = @"
                    SELECT KontoNr      = KKB.KontoNr,
                           Buchungstext = REPLACE(KKB.Buchungstext, '{space}', ' '),
                           IsDefault    = KKB.IsDefault
                    FROM dbo.KgKontoBuchungstext KKB WITH(READUNCOMMITTED)
                    WHERE KKB.KontoNr = {0}
                    ORDER BY 3 DESC, 1;"
            };
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Buchungstexten in edtBuchungstext filtern die mit <paramref name="startWith"/> anfangen. Erste Occurence auswählen.
        /// </summary>
        /// <param name="startWith">Filter</param>
        public void FilterBuchungstext(string startWith)
        {
            foreach (var item in _edtBuchungstext.Properties.Items)
            {
                if (item.ToString().StartsWith(startWith))
                {
                    _edtBuchungstext.EditValue = item.ToString();
                    break;
                }
            }
        }

        /// <summary>
        /// Lade die Buchungstexte (in edtBuchungstext) aus <paramref name="kontoNr"/>, wenn es einen Wert hat.
        /// </summary>
        /// <param name="kontoNr">Die ausgewählte Konto-Nr.</param>
        /// <param name="setBuchungstext">Definiert, ob der Buchungstext auf der Position gesetzt werden muss.</param>
        public void LoadBuchungstext(object kontoNr, bool setBuchungstext)
        {
            if (kontoNr == null)
            {
                _qryKgKontoBuchungstext.Fill(DBNull.Value);
                _edtBuchungstext.Properties.Buttons.Clear();
                _edtBuchungstext.Properties.Items.Clear();
                return;
            }

            _qryKgKontoBuchungstext.Fill(kontoNr);

            if (_qryKgKontoBuchungstext.Count > 1)
            {
                _edtBuchungstext.Properties.Buttons.Add(_button);
            }
            else
            {
                _edtBuchungstext.Properties.Buttons.Clear();
            }

            if (setBuchungstext)
            {
                var dataMember = _edtBuchungstext.DataMember;

                // vorgeschlagenen Buchungstext setzen
                if (_qryKgKontoBuchungstext.Count == 1)
                {
                    // die Positionsart hat nur einen Buchungstext
                    _query.SetValue(dataMember, _qryKgKontoBuchungstext[KG_KONTO_BUCHUNGSTEXT_BUCHUNGSTEXT], false);
                    _qryKgKontoBuchungstext.Fill(DBNull.Value);
                }
                else if (_qryKgKontoBuchungstext.Find(string.Format("{0} = 1", KG_KONTO_BUCHUNGSTEXT_IS_DEFAULT)))
                {
                    // die Positionsart hat ein Standardwert definiert
                    _query.SetValue(dataMember, _qryKgKontoBuchungstext[KG_KONTO_BUCHUNGSTEXT_BUCHUNGSTEXT], false);
                }
            }

            PopulateBuchungstext();
        }

        /// <summary>
        /// Buchungstext in edtBuchungstext markieren
        /// </summary>
        public void SelectAllText()
        {
            _edtBuchungstext.Focus();
            _edtBuchungstext.SelectAll();
        }

        #endregion

        #region Private Methods

        private void PopulateBuchungstext()
        {
            _edtBuchungstext.Properties.Items.Clear();
            foreach (DataRow row in _qryKgKontoBuchungstext.DataTable.Rows)
            {
                _edtBuchungstext.Properties.Items.Add(row[KG_KONTO_BUCHUNGSTEXT_BUCHUNGSTEXT]);
            }
        }

        #endregion

        #endregion
    }
}