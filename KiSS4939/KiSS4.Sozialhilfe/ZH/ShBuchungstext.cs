using System;
using System.Data;

using DevExpress.XtraEditors.Controls;

using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Sozialhilfe.ZH
{
    /// <summary>
    /// Class to manage the booking text that are availlable for a given BgPositionsartID
    /// </summary>
    public class ShBuchungstext
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly KissComboBox _edtBuchungstext;
        private readonly SqlQuery _qryBgPosition;
        private readonly SqlQuery _qryBgPositionsartBuchungstext;
        private readonly EditorButton _button;

        #endregion

        #endregion

        #region Constructors

        public ShBuchungstext(KissComboBox edt, SqlQuery qryBgPosition)
        {
            _edtBuchungstext = edt;
            _qryBgPosition = qryBgPosition;

            _button = _edtBuchungstext.Properties.Buttons[0];

            _qryBgPositionsartBuchungstext = new SqlQuery
            {
                SelectStatement = @"
                    SELECT
                      PAT1.BgPositionsartID,
                      PAT1.BgPositionsartID_UseText,
                      Buchungstext = REPLACE(ISNULL(PAT1.Buchungstext + ISNULL(PAT2.Buchungstext, ''), PAT2.Buchungstext), '{space}', ' '),
                      Standardwert = COALESCE(NULLIF(PAT1.Standardwert, CONVERT(BIT,0)), PAT2.Standardwert, CONVERT(BIT,0))
                    FROM dbo.BgPositionsartBuchungstext        PAT1 WITH (READUNCOMMITTED)
                      LEFT JOIN dbo.BgPositionsartBuchungstext PAT2 WITH (READUNCOMMITTED)
                                                                    ON PAT2.BgPositionsartID = PAT1.BgPositionsartID_UseText
                    WHERE PAT1.BgPositionsartID = {0}
                    ORDER BY 3;"
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
                if(item.ToString().StartsWith(startWith))
                {
                    _edtBuchungstext.EditValue = item.ToString();
                    break;
                }
            }
        }

        /// <summary>
        /// Lade die Buchungstexten (in edtBuchungstext) aus <paramref name="positionsartID"/> wenn es einen Wert hat.
        /// </summary>
        /// <param name="positionsartID">ID der Positionsart</param>
        /// <param name="setBuchungstext">Zum definieren ob der Buchungstext auf der Position gesetzt werden muss</param>
        public void LoadBuchungstext(int? positionsartID, bool setBuchungstext)
        {
            if (!positionsartID.HasValue)
            {
                _qryBgPositionsartBuchungstext.Fill(DBNull.Value);
                _edtBuchungstext.Properties.Buttons.Clear();
                _edtBuchungstext.Properties.Items.Clear();
                return;
            }

            _qryBgPositionsartBuchungstext.Fill(positionsartID.Value);

            if(_qryBgPositionsartBuchungstext.Count > 1)
            {
                _edtBuchungstext.Properties.Buttons.Add(_button);
            }
            else
            {
                _edtBuchungstext.Properties.Buttons.Clear();
            }

            if (setBuchungstext)
            {
                // vorgeschalgenen Buchungstext setzen
                if (_qryBgPositionsartBuchungstext.Count == 1)
                {
                    // die Positionsart hat nur einen Buchungstext
                    _qryBgPosition.SetValue("Buchungstext", _qryBgPositionsartBuchungstext[DBO.BgPositionsartBuchungstext.Buchungstext], false);
                    _qryBgPositionsartBuchungstext.Fill(DBNull.Value);
                }
                else if (_qryBgPositionsartBuchungstext.Find(string.Format("{0} = 1", DBO.BgPositionsartBuchungstext.Standardwert)))
                {
                    // die Positionsart hat ein Standardwert definiert
                    _qryBgPosition.SetValue("Buchungstext", _qryBgPositionsartBuchungstext[DBO.BgPositionsartBuchungstext.Buchungstext], false);
                }
            }

            PopulateBuchungstext();
        }

        /// <summary>
        /// Lade die Buchungstexten (in edtBuchungstext) aus <paramref name="positionsartID"/> wenn es einen Wert hat 
        /// oder suche die Texten von der Ausgabenpositionsart der gegebene <paramref name="kostenartID"/>
        /// </summary>
        /// <param name="positionsartID">ID der Positionsart</param>
        /// <param name="kostenartID">ID der Kostenart</param>
        public void LoadBuchungstextForSpezkonto(int? positionsartID, int? kostenartID)
        {
            if (!positionsartID.HasValue && kostenartID.HasValue)
            {
                // Suche der Ausgabenpositionsart
                var qry = DBUtil.OpenSQL(@"
                    SELECT TOP 1 POA.BgPositionsartID
                    FROM dbo.BgPositionsart POA WITH (READUNCOMMITTED)
                        INNER JOIN dbo.BgPositionsartBuchungstext PAB ON PAB.BgPositionsartID = POA.BgPositionsartID
                    WHERE POA.BgKostenartID = {0}
                        AND POA.BgKategorieCode = 2",
                    kostenartID);

                LoadBuchungstext(qry["BgPositionsartID"] as int?, true);
            }
            else
            {
                LoadBuchungstext(positionsartID, true);
            }
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
            foreach (DataRow row in _qryBgPositionsartBuchungstext.DataTable.Rows)
            {
                _edtBuchungstext.Properties.Items.Add(row[DBO.BgPositionsartBuchungstext.Buchungstext]);
            }
        }

        #endregion

        #endregion
    }
}