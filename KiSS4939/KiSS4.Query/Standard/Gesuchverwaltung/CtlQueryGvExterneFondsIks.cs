using System;
using System.Globalization;
using DevExpress.XtraBars.Docking.Helpers;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryGvExterneFondsIks : CtlQueryGvFondsBase
    {
        public CtlQueryGvExterneFondsIks()
        {
            InitializeComponent();

            HideAndEmptylblProzensatzgeprueft();

            // Tab Gesuch
            for (int i = 0; i < grvQuery1.Columns.Count; i++)
            {
                grvQuery1.Columns[i].Visible = false;
            }

            colGesuchGesuchsId.VisibleIndex = 0;
            colGesuchPersNr.VisibleIndex = 1;
            colGesuchName.VisibleIndex = 2;
            colGesuchVorname.VisibleIndex = 3;
            colGesuchPlz.VisibleIndex = 4;
            colGesuchOrt.VisibleIndex = 5;
            colGesuchGesuchsbezeichnung.VisibleIndex = 6;
            colErfasstesGesuchgeprueftam.VisibleIndex = 7;
            colErfasstesGesuchgeprueftdurchIKS_User.VisibleIndex = 8;
            colErfasstesGesuchBemerkung.VisibleIndex = 9;
            colErfasstesGesuchBesprechen.VisibleIndex = 10;
            colAbgeschlossenesGesuchgeprueftam.VisibleIndex = 11;
            colAbgeschlossenesGesuchdurchIKS_User.VisibleIndex = 12;
            colAbgeschlossenesGesuchBemerkung.VisibleIndex = 13;
            colAbgeschlossenesGesuchBesprechen.VisibleIndex = 14;
            colGesuchBeantragterBetrag.VisibleIndex = 15;
            colGesuchDatumGesuch.VisibleIndex = 16;
            colGesuchExternerFonds.VisibleIndex = 17;
            colGesuchStatus.VisibleIndex = 18;
            colGesuchBewilligterBetrag.VisibleIndex = 19;
            colGesuchEntscheiddatum.VisibleIndex = 20;
            colGesuchAbschlussdatum.VisibleIndex = 21;
            colGesuchAbschlussgrund.VisibleIndex = 22;
            colGesuchBemerkungen.VisibleIndex = 23;
            colGesuchSAR.VisibleIndex = 24;
            colGesuchKostenstelle.VisibleIndex = 25;
            colGesuchKgs.VisibleIndex = 26;

            kissSearch.SelectParameters = new object[]
            {
                true, // 1) ExternInterner Fonds (true = externe Fonds)
                Session.User.LanguageCode // 2) Sprachcode des Benutzers
            };

            Load += CtlQueryGvExterneFondsIks_Load;
        }

        protected override void grdQuery1_DoubleClick(object sender, EventArgs e)
        {
            base.grdQuery1_DoubleClick(sender, e);

            int gvGesuchID = Utils.ConvertToInt(qryQuery["Gesuchs-ID"], int.MinValue);

            if (gvGesuchID != int.MinValue)
            {
                FormController.OpenForm("FrmGvGesuchverwaltung",
                    "Action",
                    "JumpToGesuch",
                    "GvGesuchID",
                    gvGesuchID.ToString());
            }
        }

        /// <summary>
        /// Default-Einstellungen bei einer neuen Suche setzen.
        /// </summary>
        protected override void NewSearch()
        {
            base.NewSearch();
            ctlKGSKostenstelleSAR.EdtSucheKostenstelle.EditValue = null;
        }

        protected override void UpdateCountLabel(KissGrid grid)
        {
            base.UpdateCountLabel(grid);

            UpdatelblProzensatzgeprueft();
        }

        private void CtlQueryGvExterneFondsIks_Load(object sender, System.EventArgs e)
        {
            InitializeLookupFonds();
            HideTab(tpgFonds);
            HideTab(tpgKlient);
            HideTab(tpgKgs);
            HideTab(tpgMitarbeiter);
            HideTab(tpgKostenstelle);
        }

        private void HideAndEmptylblProzensatzgeprueft()
        {
            lblProzensantzgeprueftAnzahl.Text = "";
            lblProzensantzgeprueftAnzahl.Visible = false;
            lblProzensantzgeprueftText.Visible = false;
        }

        /// <summary>
        /// Dropdown Fonds initialisieren
        /// </summary>
        private void InitializeLookupFonds()
        {
            // all mandanten the user can see
            SqlQuery queryExterneFonds =
                DBUtil.OpenSQL(
                    @"
                    SELECT [Code] = NULL,
                           [Text] = ''
                    UNION ALL
                    SELECT [Code] = GvFondsID,
                           [Text] = NameKurz
                    FROM dbo.GvFonds WITH (READUNCOMMITTED)
                    WHERE GvFondsTypCode = 2
                    ORDER BY [Text];");
            edtSucheFonds.LoadQuery(queryExterneFonds);
        }

        private void UpdatelblProzensatzgeprueft()
        {
            // validate
            if (grdQuery1 == null || grdQuery1.View == null)
            {
                HideAndEmptylblProzensatzgeprueft();
                return;
            }

            int rowCount = AllowMultiselecting ? grdQuery1.View.RowCount : grdQuery1.View.DataRowCount;
            if (rowCount == 0)
            {
                HideAndEmptylblProzensatzgeprueft();
                return;
            }

            int anzahlGeprueft = 0;
            for (var i = 0; i < rowCount; i++)
            {
                if ((Utils.ConvertToDateTime(grdQuery1.View.GetRowCellValue(i, colErfasstesGesuchgeprueftam), DateTime.MinValue) != DateTime.MinValue)
                    || (Utils.ConvertToDateTime(grdQuery1.View.GetRowCellValue(i, colAbgeschlossenesGesuchgeprueftam), DateTime.MinValue) != DateTime.MinValue))
                {
                    anzahlGeprueft++;
                }
            }

            lblProzensantzgeprueftAnzahl.Text = Decimal.Round((decimal)anzahlGeprueft / rowCount * 100, 0).ToString(CultureInfo.InvariantCulture);
            lblProzensantzgeprueftAnzahl.Visible = true;
            lblProzensantzgeprueftText.Visible = true;
        }
    }
}