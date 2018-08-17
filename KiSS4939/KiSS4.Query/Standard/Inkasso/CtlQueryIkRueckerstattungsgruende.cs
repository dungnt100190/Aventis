using System;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryIkRueckerstattungsgruende : KissQueryControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly string _tpgListeTitle;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryIkRueckerstattungsgruende()
        {
            InitializeComponent();
            _tpgListeTitle = tpgListe.Title;
        }

        #endregion

        #region EventHandlers

        private void btnAbsprung_Click(object sender, EventArgs e)
        {
            var faLeistungId = qryQuery["FaLeistungID$"];
            var baPersonId = qryQuery["BaPersonID$"];
            var treeNodeId = string.Format("CtlIkLeistung{0}\\Schuldner", faLeistungId);

            var path = new[]
            {
                "Action", "JumpToPath",
                "ClassName", "FrmFall",
                "ModulID", 4,
                "BaPersonID", baPersonId,
                "FaLeistungID", faLeistungId,
                "TreeNodeID", treeNodeId
            };

            FormController.OpenForm("FrmFall", path);
        }

        private void CtlQueryIkRueckerstattungsgruende_Load(object sender, EventArgs e)
        {
            tpgListe.Title = _tpgListeTitle;
            edtInkassoTyp.ItemIndex = 0;
        }
        private void edtUserID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtUserID.EditValue = null;
                    edtUserID.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtUserID.EditValue = dlg["Name"];
                edtUserID.LookupID = dlg["UserID"];
            }
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            SetupDataSourceAndGridColumns(grdQuery2, qryQuery.DataSet.Tables[1]);
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void RunSearch()
        {
            if ((edtForderungenInZeitraum.Checked || edtZahlungenInZeitraum.Checked)
                && (edtZeitraumVon.EditValue == null && edtZeitraumBis.EditValue == null))
            {
                throw new KissInfoException("Wenn 'Forderungen in diesem Zeitraum' oder 'Zahlungen in diesem Zeitraum' ausgewählt wird, muss ein Zeitraum eingegeben werden",
                                            edtZeitraumVon);
            }

            if ((edtZeitraumVon.EditValue != null || edtZeitraumBis.EditValue != null)
                 && (!edtForderungenInZeitraum.Checked && !edtZahlungenInZeitraum.Checked))
            {
                throw new KissInfoException("Wenn ein Zeitraum eingegeben wird, muss mindestens eines der Häkchen 'Forderungen in diesem Zeitraum' oder 'Zahlungen in diesem Zeitraum' ausgewählt werden.",
                                            edtForderungenInZeitraum);
            }

            base.RunSearch();
        }

        #endregion

        #endregion
    }
}