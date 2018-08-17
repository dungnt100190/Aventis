using System;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration.ZH
{
    public partial class CtlKgKontoBuchungstext : KissUserControl
    {
        #region Constructors

        public CtlKgKontoBuchungstext()
        {
            InitializeComponent();
            SetupDataSource();
            SetupDataMembers();
            SetupFieldNames();
            SetupTags();
        }

        #endregion

        #region EventHandlers

        private void CtlKgKontoBuchungstext_Load(object sender, EventArgs e)
        {
            RunQuery();
        }

        private void edtKontoNr_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = "%" + KissLookupDialog.PrepareSearchString(edtKontoNr.Text) + "%";

            var dlg = new KissLookupDialog();

            e.Cancel = !dlg.SearchData(@"
                SELECT [Konto-Nr] = KontoNr,
                       [Name]     = KontoName
                FROM dbo.KgKonto WITH (READUNCOMMITTED)
                WHERE KgPeriodeID IS NULL
                  AND KontoNr LIKE {0}
                ORDER BY KontoNr;",
                searchString,
                e.ButtonClicked);

            if (!e.Cancel)
            {
                qryKgKontoBuchungstext["KontoNr"] = dlg[0];
            }
            // Man kann trotzdem Speichern, auch wenn es keinen Teffer gibt.
            else
            {
                qryKgKontoBuchungstext["KontoNr"] = edtKontoNr.Text;
            }
        }

        /// <summary>
        /// Validierungen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qryKgKontoBuchungstext_BeforePost(object sender, EventArgs e)
        {
            //Prüfen, ob es bereits schon ein default Wert für das Konto gibt.
            //Pro Konto darf nur ein default Wert definiert sein.
            if (!DBUtil.IsEmpty(qryKgKontoBuchungstext["IsDefault"]) && ((bool)qryKgKontoBuchungstext["IsDefault"]))
            {
                var count = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(1)
                    FROM KgKontoBuchungstext WITH (READUNCOMMITTED)
                    WHERE KontoNr = {1}
                      AND IsDefault = 1
                      AND KgKontoBuchungstextID <> {0};",
                    qryKgKontoBuchungstext["KgKontoBuchungstextID"],
                    qryKgKontoBuchungstext["KontoNr"]);

                if (count > 0)
                {
                    KissMsg.ShowInfo(GetType().Name, "DefaultExistiertBereits", "Es gibt bereits einen Standard-Textbaustein für dieses Konto!");
                    throw new KissCancelException();
                }
            }

            //Prüfen, ob es Konto gibt (standard kontenplan)
            var kontoNummerCount = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(1)
                FROM dbo.KgKonto WITH(READUNCOMMITTED)
                WHERE KgPeriodeID IS NULL
                  AND KontoNr = {0};",
                qryKgKontoBuchungstext["KontoNr"]);

            if (kontoNummerCount == 0)
            {
                KissMsg.ShowInfo(
                    GetType().Name,
                    "KontoNrUngueltig",
                    "Die Kontonummer {0} existiert nicht, Daten werden aber trotzdem gespeichert.",
                    qryKgKontoBuchungstext["KontoNr"]);
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void RunQuery()
        {
            qryKgKontoBuchungstext.Fill();
        }

        private void SetupDataMembers()
        {
            edtKontoNr.DataMember = "KontoNr";
            edtText.DataMember = "Buchungstext";
            edtDefault.DataMember = "IsDefault";
        }

        private void SetupDataSource()
        {
            edtKontoNr.DataSource = qryKgKontoBuchungstext;
            edtText.DataSource = qryKgKontoBuchungstext;
            edtDefault.DataSource = qryKgKontoBuchungstext;
        }

        private void SetupFieldNames()
        {
            colKontoNr.FieldName = "KontoNr";
            colBuchungstext.FieldName = "Buchungstext";
            colDefault.FieldName = "IsDefault";
        }

        private void SetupTags()
        {
            edtKontoNr.Tag = lblKontoNr.Text;
            edtText.Tag = lblText.Text;
        }

        #endregion

        #endregion
    }
}