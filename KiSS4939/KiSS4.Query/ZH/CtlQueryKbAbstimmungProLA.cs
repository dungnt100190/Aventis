using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.ZH
{
    public partial class CtlQueryKbAbstimmungProLA : KissQueryControl
    {
        #region Constructors

        public CtlQueryKbAbstimmungProLA()
        {
            InitializeComponent();

            ttpSuchkriterienInfo.SetToolTip(lblSuchkriterienInfoBelege, string.Empty);

            InitPklSucheLeistungsarten();

            _suchKriteriumCtrItems = new List<KeyValuePair<string, BaseEdit>>
            {
                new KeyValuePair<string, BaseEdit>(lblBerichtsperiodeVon.Text, edtDatumVon),
                new KeyValuePair<string, BaseEdit>(lblBerichtsperiodeBis.Text, edtDatumBis),
            };
        }

        private void InitPklSucheLeistungsarten()
        {
            qrySucheLeistungsartenVerfuegbar.Fill();
            qrySucheLeistungsartenZugeteilt.Fill();

            pklSucheLeistungsarten.ButtonSelectAll.Visible = true;
            pklSucheLeistungsarten.ButtonRemoveAll.Visible = true;

            pklSucheLeistungsarten.ColumnsByFieldNameAndCaptionForSourceGrid = new Dictionary<string, string> { { "Name", "Verfügbare Leistungsart" } };
            pklSucheLeistungsarten.ColumnsByFieldNameAndCaptionForTargetGrid = new Dictionary<string, string> { { "Name", "Ausgewählte Leistungsart" } };

            pklSucheLeistungsarten.DataSourceOfSourceGrid = qrySucheLeistungsartenVerfuegbar;
            pklSucheLeistungsarten.DataSourceOfTargetGrid = qrySucheLeistungsartenZugeteilt;
        }

        #endregion Constructors

        #region EventHandlers

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            SetupDataSourceAndGridColumns(grdBelege, qryQuery.DataSet.Tables[1]);
        }

        #endregion EventHandlers

        #region Methods

        #region Public Methods

        public override void OnRefreshData()
        {
            if (tabControlSearch.IsTabSelected(tpgSuchen))
            {
                return;
            }

            qryQuery.Refresh();
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            var year = DateTime.Today.Year;
            edtDatumVon.EditValue = new DateTime(year, 1, 1);
            edtDatumBis.EditValue = DateTime.Today;

            base.NewSearch();
        }

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtDatumVon, lblBerichtsperiodeVon.Text);
            DBUtil.CheckNotNullField(edtDatumBis, lblBerichtsperiodeBis.Text);

            if (DBUtil.IsEmpty(pklSucheLeistungsarten.SelectedIds))
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name, "MindestensEineLAauswaehlen",
                    "Bitte wählen Sie mindestens eine Leistungsart aus."));
            }

            base.RunSearch();
        }

        protected override string SetSearchedParams()
        {
            var paramsString = base.SetSearchedParams();
            paramsString += !string.IsNullOrEmpty(paramsString) ? ", " : "";

            var selectedValues = pklSucheLeistungsarten.SelectedValues;
            if (selectedValues != null)
            {
                paramsString += string.Format("{0}: {1}", lblLeistungsarten.Text, selectedValues);
            }

            if (!string.IsNullOrEmpty(paramsString))
            {
                lblSuchkriterienInfoBelege.Visible = true;

                lblSuchkriterienInfoBelege.Text = paramsString;
                ttpSuchkriterienInfo.SetToolTip(lblSuchkriterienInfoBelege, paramsString);
            }
            else
            {
                lblSuchkriterienInfoBelege.Visible = false;
            }
            return paramsString;
        }

        #endregion Protected Methods

        private void CtlQueryKbAbstimmungProLA_Load(object sender, EventArgs e)
        {
            this.tpgListe.Title = "Total";
            this.tpgBelege.Title = "Belege";
        }

        #endregion Methods
    }
}