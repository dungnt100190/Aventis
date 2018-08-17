using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Inkasso
{
    public partial class DlgLandesindexWertErfassen : KissDialog
    {
        #region Constructors

        public DlgLandesindexWertErfassen()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Das Jahr für die Wertegenerierung.
        /// </summary>
        public int Jahr
        {
            get
            {
                var val = (DateTime?)edtMonatJahr.EditValue;
                return val.HasValue ? val.Value.Year : -1;
            }
        }

        /// <summary>
        /// Der Monat für die Wertegenerierung.
        /// </summary>
        public int Monat
        {
            get
            {
                var val = (DateTime?)edtMonatJahr.EditValue;
                return val.HasValue ? val.Value.Month : -1;
            }
        }

        /// <summary>
        /// Die für jeden Landesindex erfassten Werte (IkLandesindexID, Wert).
        /// </summary>
        public Dictionary<int, decimal> Values
        {
            get;
            private set;
        }

        #endregion

        #region EventHandlers

        private void DlgLandesindexWertErfassen_Load(object sender, EventArgs e)
        {
            qryLandesindex.Fill();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Values = new Dictionary<int, decimal>();

            // Erfasste werte in Dictionary abfüllen
            foreach (DataRow row in qryLandesindex.DataTable.Rows)
            {
                var ikLandesindexId = Utils.ConvertToInt(row[DBO.IkLandesindex.IkLandesindexID]);
                var name = row[DBO.IkLandesindex.Name];

                if (ikLandesindexId <= 0)
                {
                    throw new KissErrorException("Fehler. Werte konnten nicht gespeichert werden!", "IkLandesindexID = 0: " + name, null);
                }

                decimal value;

                if (decimal.TryParse(row["Value"].ToString(), out value))
                {
                    Values.Add(ikLandesindexId, value);
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void qryLandesindex_BeforePost(object sender, EventArgs e)
        {
            qryLandesindex.Row.AcceptChanges();
        }

        #endregion
    }
}