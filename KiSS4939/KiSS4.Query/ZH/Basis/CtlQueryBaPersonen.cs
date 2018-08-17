using System;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.Common.ZH;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.ZH
{
    public partial class CtlQueryBaPersonen : KissQueryControl
    {
        #region Fields

        #region Private Fields

        private bool _firstOnPositionChangedAfterFill;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryBaPersonen()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnFallzuteilung_Click(object sender, EventArgs e)
        {
            FormController.ShowDialogOnMain("DlgFallZuteilung", qryBaPerson["BaPersonID"]);
        }

        private void qryBaPerson_AfterFill(object sender, EventArgs e)
        {
            // #5322: Reset des GOTO-Balkens
            ctlGotoFallZH.BaPersonID = 0;
            ctlGotoFallZH.FaFallID = 0;
        }

        private void qryBaPerson_PositionChanged(object sender, EventArgs e)
        {
            ctlGotoFallZH.BaPersonID = (int)qryBaPerson["BaPersonID"];
            ctlGotoFallZH.FaFallID = (int)qryBaPerson["FaFallID"];
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            _firstOnPositionChangedAfterFill = true;

            // #5322: Rufe noch PositionChanged explizit auf, das löscht das Klientensystem im Fall, dass die Suche Leer verlaufen ist
            qryQuery_PositionChanged(sender, e);
        }

        private void qryQuery_PositionChanged(object sender, EventArgs e)
        {
            if (_firstOnPositionChangedAfterFill)
            {
                // Begrenze die Kollonnen-Breite von Name, Vorname und FallNr (wir müssen das hier machen, da die Kollonen nach dem AfterFill nochmals automatisch maximiert werden)
                if (colName1.Width > 73) colName1.Width = 73;
                if (colVorname1.Width > 73) colVorname1.Width = 73;
                if (colFallNr.Width > 52) colFallNr.Width = 52;

                _firstOnPositionChangedAfterFill = false;
            }

            try
            {
                DBUtil.ThrowExceptionOnOpenTransaction();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }

            qryBaPerson.SelectStatement = @"
                declare @Person table
                (
                    FallPersonID     int,
                    FaFallID         int,
                    DatumVon         datetime,
                    DatumBis         datetime,
                    AktiverFall      bit,
                    FallTraeger      bit,
                    LeistungsTraeger bit
                )

                insert @Person
                select distinct FAL.BaPersonID, FAL.FaFallID, FAL.DatumVon, FAL.DatumBis,
                        CONVERT(bit, CASE WHEN FAL.DatumBis IS NULL THEN 1 ELSE 0 END),
                        CONVERT(bit, CASE WHEN (SELECT COUNT(FaLeistungID) FROM FaLeistung WHERE FaFallID = FAL.FaFallID AND LEI.BaPersonID = {0}) > 0 THEN 1 ELSE 0 END),
                        CONVERT(bit, CASE WHEN FAL.BaPersonID = {0} THEN 1 ELSE 0 END)
                from   FaFallPerson FAP
                         inner join FaFall   FAL on FAL.FaFallID = FAP.FaFallID
                        left join FaLeistung LEI ON LEI.FaFallID = FAL.FaFallID and LEI.BaPersonID = {0}
                where  FAP.BaPersonID = {0}

                select
                    FallTraeger = P.FallTraeger,
                    LeistungsTraeger = P.LeistungsTraeger,
                    FaFallID = P.FaFallID,
                    BaPersonID = P.FallPersonID,
                    Name = PRS.Name,
                    Vorname = PRS.Vorname,
                    DatumVon = P.DatumVon,
                    DatumBis = P.DatumBis
                from   @Person P
                         inner join vwPerson PRS on PRS.BaPersonID = P.FallPersonID
                order by P.AktiverFall desc, P.FallTraeger desc, P.LeistungsTraeger desc, IsNull(P.DatumBis, P.DatumVon) desc	-- Für Reihenfolge siehe Ticket #4720
            ";

            qryBaPerson.Fill(qryQuery["PersonID"]);
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnSearch()
        {
            if (tabControlSearch.SelectedTab == tpgSuchen)
            {
                foreach (Control ctl in UtilsGui.AllControls(tpgSuchen))
                {
                    if (ctl is KissButtonEdit)
                    {
                        KissButtonEdit edt = (KissButtonEdit)ctl;
                        edt.CheckPendingSearchValue();
                    }

                    if (ctl is CtlOrgUnitTeamUser)
                    {
                        ((CtlOrgUnitTeamUser)ctl).CheckPendingSearchValue();
                    }
                }
            }

            // Workaround um F3 weiter zu reichen, da das FrameWork das OrgUnitTeamUser UserControl nicht kennt
            try
            {
                if (((ContainerControl)ActiveControl).ActiveControl.Equals(ctlOrgUnitTeamUser))
                {
                    edtSucheName.Focus();
                }
            }
            catch
            {
            }

            qryBaPerson.SelectStatement = "";
            base.OnSearch();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            ctlOrgUnitTeamUser.NewSearch();

            edtSucheName.Focus();
        }

        protected override void RunSearch()
        {
            if (!AllowSearch())
            {
                KissMsg.ShowInfo(typeof(CtlQueryBaPersonen).Name, "OnSearch_DoNotAllow", "Bitte geben Sie mindestens ein Suchkriterium ein.");
                throw new KissCancelException();
            }

            // Clear sql statement (otherwise this query gets executed without parameters which causes exceptions)
            qryBaPerson.SelectStatement = "";

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private bool AllowSearch()
        {
            var empty = DBUtil.IsEmpty(edtSucheAHV.EditValue) &&
                DBUtil.IsEmpty(edtSucheAlteFallNr.EditValue) &&
                DBUtil.IsEmpty(edtSucheAltePNr.EditValue) &&
                DBUtil.IsEmpty(edtSucheBaPersonID.EditValue) &&
                DBUtil.IsEmpty(edtSucheFaFallID.EditValue) &&
                DBUtil.IsEmpty(edtSucheGeburt.EditValue) &&
                DBUtil.IsEmpty(edtSucheGruppe.EditValue) &&
                DBUtil.IsEmpty(edtSucheName.EditValue) &&
                DBUtil.IsEmpty(edtSucheOrt.EditValue) &&
                DBUtil.IsEmpty(edtSuchePLZ.EditValue) &&
                DBUtil.IsEmpty(edtSucheResoNr.EditValue) &&
                DBUtil.IsEmpty(edtSucheStrasse.EditValue) &&
                DBUtil.IsEmpty(edtSucheTeam.EditValue) &&
                DBUtil.IsEmpty(edtSucheVersichertenNr.EditValue) &&
                DBUtil.IsEmpty(edtSucheVorname.EditValue) &&
                DBUtil.IsEmpty(edtSucheEinwohnerregisterId.EditValue) &&
                DBUtil.IsEmpty(ctlOrgUnitTeamUser.SucheGruppe.EditValue) &&
                DBUtil.IsEmpty(ctlOrgUnitTeamUser.SucheTeam.EditValue) &&
                DBUtil.IsEmpty(ctlOrgUnitTeamUser.SucheUserID.EditValue);

            return !empty;
        }

        #endregion

        #endregion
    }
}