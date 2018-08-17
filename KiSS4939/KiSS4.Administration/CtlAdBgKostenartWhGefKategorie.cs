using System;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Administration
{
    public partial class CtlAdBgKostenartWhGefKategorie : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string QRY_IS_ALBV = "IsALBV";
        private const string QRY_IS_ZUDE = "IsZuDe";
        private const string QRY_KOSTENART = "Kostenart";
        private const string QRY_WH_GEF_KATEGORIE = "WhGefKategorie";

        #endregion

        #endregion

        #region Constructors

        public CtlAdBgKostenartWhGefKategorie()
        {
            InitializeComponent();

            SetupDataMembers();
        }

        #endregion

        #region EventHandlers

        private void CtlAdBgKostenartWhGefKategorie_Load(object sender, EventArgs e)
        {
            kissSearch.SelectParameters = new object[] { Session.User.LanguageCode };
            NewSearch();
            tabControlSearch.SelectTab(tpgListe);
            qryBgKostenart_WhGefKategorie.Fill(0);
            grvQuery.BestFitColumns();
        }

        private void edtGefKategorieX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            using (var dlg = new DlgAuswahl())
            {
                e.Cancel = !dlg.WhGefKategorieSuchen(edtGefKategorieX.Text, e.ButtonClicked);

                if (!e.Cancel)
                {
                    edtGefKategorieX.EditValue = dlg["WhGefKategorie"];
                    edtGefKategorieX.LookupID = dlg[DBO.WhGefKategorie.WhGefKategorieID];
                }
            }
        }

        private void edtGefKategorie_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            using (var dlg = new DlgAuswahl())
            {
                e.Cancel = !dlg.WhGefKategorieSuchen(edtGefKategorie.Text, e.ButtonClicked);

                if (!e.Cancel)
                {
                    qryQuery[DBO.WhGefKategorie.WhGefKategorieID] = dlg[DBO.WhGefKategorie.WhGefKategorieID];
                    qryQuery[QRY_WH_GEF_KATEGORIE] = dlg["WhGefKategorie"];
                }
            }
        }

        private void edtInkassoprovision_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEditMode();
        }

        private void edtKostenartX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            using (var dlg = new DlgAuswahl())
            {
                e.Cancel = !dlg.BgKostenartSuchen(edtKostenartX.Text, e.ButtonClicked);

                if (!e.Cancel)
                {
                    edtKostenartX.EditValue = dlg[DBO.BgKostenart.Name];
                    edtKostenartX.LookupID = dlg[DBO.BgKostenart.BgKostenartID];
                }
            }
        }

        private void qryQuery_BeforePost(object sender, EventArgs e)
        {
            OnSaveData();
            UpdateEditMode();
        }

        private void qryQuery_PositionChanged(object sender, EventArgs e)
        {
            UpdateEditMode();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool OnSaveData()
        {
            if (qryQuery.RowModified)
            {
                if (edtGefKategorie.EditMode == EditModeType.Required)
                {
                    DBUtil.CheckNotNullField(edtGefKategorie, lblGefKategorie.Text);
                }

                if (!DBUtil.IsEmpty(qryQuery[DBO.BgKostenart_WhGefKategorie.WhGefKategorieID]))
                {
                    // KontoNr muss nicht ein ZuDe- oder ALVB-Konto sein
                    if ((bool)qryQuery[QRY_IS_ALBV])
                    {
                        KissMsg.ShowInfo(
                            Name,
                            "IstAlbvKontoFuerSozialhilferechnung",
                            "Dieses Konto ist bereits für den ALBV-Ritter in der Sozialhilferechnung zugeordnet." + Environment.NewLine +
                                @"Konfigurationswert: 'System\KliBu\Sozialhilferechnung\ALBVKonti'"
                        );

                        throw new KissCancelException();
                    }

                    if ((bool)qryQuery[QRY_IS_ZUDE])
                    {
                        KissMsg.ShowInfo(
                            Name,
                            "IstZuDeKontoFuerSozialhilferechnung",
                            "Dieses Konto ist bereits für die Zuschüsse-Rittern in der Sozialhilferechnung zugeordnet." + Environment.NewLine +
                                @"Konfigurationswert: 'System\KliBu\Sozialhilferechnung\ZuDeKonti'"
                        );

                        throw new KissCancelException();
                    }
                }

                SaveKostenartGefKategorie();
            }

            return base.OnSaveData();
        }

        #endregion

        #region Private Methods

        private bool DeleteKostenartGefKategorie(int bgKostenartWhGefKategorieId)
        {
            qryBgKostenart_WhGefKategorie.Fill(bgKostenartWhGefKategorieId);
            return qryBgKostenart_WhGefKategorie.Delete();
        }

        private bool InsertKostenartGefKategorie(int bgKostenartId, int whGefKategorieId, bool isInkassoprovision, out int bgKostenartWhGefKategorieId)
        {
            qryBgKostenart_WhGefKategorie.Insert();
            qryBgKostenart_WhGefKategorie[DBO.BgKostenart_WhGefKategorie.BgKostenartID] = bgKostenartId;
            qryBgKostenart_WhGefKategorie[DBO.BgKostenart_WhGefKategorie.WhGefKategorieID] = whGefKategorieId;
            qryBgKostenart_WhGefKategorie[DBO.BgKostenart_WhGefKategorie.IsInkassoprovision] = isInkassoprovision;
            qryBgKostenart_WhGefKategorie.SetCreator();
            qryBgKostenart_WhGefKategorie.SetModifierModified();

            if (qryBgKostenart_WhGefKategorie.Post())
            {
                bgKostenartWhGefKategorieId = (int)qryBgKostenart_WhGefKategorie[DBO.BgKostenart_WhGefKategorie.BgKostenart_WhGefKategorieID];
                return true;
            }

            bgKostenartWhGefKategorieId = -1;
            return false;
        }

        private void SaveKostenartGefKategorie()
        {
            var bgKostenartWhGefKategorieId = qryQuery[DBO.BgKostenart_WhGefKategorie.BgKostenart_WhGefKategorieID] as int?;
            var bgKostenartId = (int)qryQuery[DBO.BgKostenart_WhGefKategorie.BgKostenartID];
            var whGefKategorieId = qryQuery[DBO.BgKostenart_WhGefKategorie.WhGefKategorieID] as int?;
            var isInkassoprovision = (bool)qryQuery[DBO.BgKostenart_WhGefKategorie.IsInkassoprovision];

            bool saved = false;

            if (bgKostenartWhGefKategorieId.HasValue)
            {
                if (whGefKategorieId.HasValue)
                {
                    saved = UpdateKostenartGefKategorie(bgKostenartWhGefKategorieId.Value, bgKostenartId, whGefKategorieId.Value, isInkassoprovision);
                }
                else
                {
                    saved = DeleteKostenartGefKategorie(bgKostenartWhGefKategorieId.Value);
                }
            }
            else if (whGefKategorieId.HasValue)
            {
                int id;
                saved = InsertKostenartGefKategorie(bgKostenartId, whGefKategorieId.Value, isInkassoprovision, out id);
                qryQuery[DBO.BgKostenart_WhGefKategorie.BgKostenart_WhGefKategorieID] = id;
            }
            else
            {
                qryQuery.DataTable.RejectChanges();
                qryQuery.RowModified = false;
            }

            if (saved)
            {
                qryQuery.DataTable.AcceptChanges();
                qryQuery.RowModified = false;
            }
        }

        private void SetupDataMembers()
        {
            edtBgKostenartID.DataMember = DBO.BgKostenart.BgKostenartID;
            edtKostenart.DataMember = QRY_KOSTENART;
            edtGefKategorie.DataMember = QRY_WH_GEF_KATEGORIE;
            edtInkassoprovision.DataMember = DBO.BgKostenart_WhGefKategorie.IsInkassoprovision;
        }

        private void UpdateEditMode()
        {
            // ALBV/ZuDe-Konti read-only, ausser wenn schon eine Kategorie ausgewählt war (so kann sie gelöscht werden).
            var albvZude = ((bool)qryQuery[QRY_IS_ALBV] || (bool)qryQuery[QRY_IS_ZUDE]) &&
                DBUtil.IsEmpty(qryQuery[DBO.BgKostenart_WhGefKategorie.WhGefKategorieID]);

            if (albvZude)
            {
                edtInkassoprovision.EditMode = EditModeType.ReadOnly;
                edtGefKategorie.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                edtInkassoprovision.EditMode = EditModeType.Normal;
                edtGefKategorie.EditMode = edtInkassoprovision.Checked ? EditModeType.Required : EditModeType.Normal;
            }
        }

        private bool UpdateKostenartGefKategorie(int bgKostenartWhGefKategorieId, int bgKostenartId, int whGefKategorieId, bool isInkassoprovision)
        {
            qryBgKostenart_WhGefKategorie.Fill(bgKostenartWhGefKategorieId);
            qryBgKostenart_WhGefKategorie[DBO.BgKostenart_WhGefKategorie.BgKostenartID] = bgKostenartId;
            qryBgKostenart_WhGefKategorie[DBO.BgKostenart_WhGefKategorie.WhGefKategorieID] = whGefKategorieId;
            qryBgKostenart_WhGefKategorie[DBO.BgKostenart_WhGefKategorie.IsInkassoprovision] = isInkassoprovision;
            qryBgKostenart_WhGefKategorie.SetModifierModified();
            return qryBgKostenart_WhGefKategorie.Post();
        }

        #endregion

        #endregion
    }
}