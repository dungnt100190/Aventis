using System;
using System.Drawing;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public partial class CtlKaEafSpezifischeErmittlung : KissUserControl
    {
        private const string DOCCONTEXT_INTERVENTION_AUFFORDERUNG_NAME = "KaEafSpezifischeErmittlung_Inter_Aufforderung";
        private const string DOCCONTEXT_INTERVENTION_PROGRAMMABBRUCH_NAME = "KaEafSpezifischeErmittlung_Inter_Programmabbruch";
        private const string DOCCONTEXT_INTERVENTION_VEREINBARUNG_NAME = "KaEafSpezifischeErmittlung_Inter_Vereinbarung";
        private const string DOCCONTEXT_INTERVENTION_VERWARNUNG_NAME = "KaEafSpezifischeErmittlung_Inter_Verwarnung";
        private const string DOCCONTEXT_PROZESS_ABSCHLUSS_NAME = "KaEafSpezifischeErmittlung_Prozess_Abschluss";
        private const string DOCCONTEXT_PROZESS_EINTRITT_NAME = "KaEafSpezifischeErmittlung_Prozess_Eintritt";

        private int _baPersonId;
        private int _faLeistungId;

        public CtlKaEafSpezifischeErmittlung()
        {
            InitializeComponent();
            SetUpDataMembers();
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return _baPersonId;
                case "FALEISTUNGID":
                    return _faLeistungId;
                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL("SELECT UserID FROM dbo.FaLeistung WHERE FaLeistungID = {0};", _faLeistungId);
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int faLeistungId, int baPersonId)
        {
            lblTitle.Text = titleName;
            imageTitle.Image = titleImage;

            _faLeistungId = faLeistungId;
            _baPersonId = baPersonId;

            ctlKaEafAustritt.FaLeistungId = faLeistungId;

            tabSpezifischeErmittlung.SelectTab(tpgProzessuebersicht);

            var sichtbarSdFlag = KaUtil.GetSichtbarSDFlag(baPersonId);

            bool mayUpd, unused;
            DBUtil.GetFallRights(faLeistungId, out unused, out unused, out mayUpd, out unused, out unused, out unused);
            qryKaEafSpezifischeErmittlung.CanUpdate = qryKaEafSpezifischeErmittlung.CanUpdate && mayUpd && sichtbarSdFlag == 0;

            qryEinsatz.Fill(faLeistungId, sichtbarSdFlag);
            qryKaEafSpezifischeErmittlung.Fill(faLeistungId);

            if (qryKaEafSpezifischeErmittlung.IsEmpty && qryKaEafSpezifischeErmittlung.CanUpdate)
            {
                qryKaEafSpezifischeErmittlung.Insert(DBO.KaEafSpezifischeErmittlung.DBOName);
                qryKaEafSpezifischeErmittlung[DBO.KaEafSpezifischeErmittlung.FaLeistungID] = faLeistungId;
                qryKaEafSpezifischeErmittlung.Post();
            }

            ctlKaEafAustritt.UpdateEditmode();
        }

        private void qryKaEafSpezifischeErmittlung_AfterPost(object sender, EventArgs e)
        {
            try
            {
                KaUtil.UpdateKaArbeitsRapportRecords(_faLeistungId);

                Session.Commit();
            }
            catch (Exception exc)
            {
                Session.Rollback();
                KissMsg.ShowInfo(exc.Message);
                throw new KissCancelException();
            }
        }

        private void qryKaEafSpezifischeErmittlung_BeforePost(object sender, EventArgs e)
        {
            Session.BeginTransaction();
        }

        private void SetUpDataMembers()
        {
            edtAnwesendTeilzeit.DataMember = DBO.KaEafSpezifischeErmittlung.AnwesendTeilzeit;
            edtZielsetzungen.DataMember = DBO.KaEafSpezifischeErmittlung.Zielsetzungen;

            // Prozessübersicht
            edtProzessEinladungErfolgt.DataMember = DBO.KaEafSpezifischeErmittlung.ProzessEinladungErfolgt;
            edtProzessVereinbarung.DataMember = DBO.KaEafSpezifischeErmittlung.ProzessVereinbarung;
            edtprozessDatumVereinbarung.DataMember = DBO.KaEafSpezifischeErmittlung.ProzessDatumVereinbarung;
            docProzessVereinbarung.DataMember = DBO.KaEafSpezifischeErmittlung.DocumentID_ProzessVereinbarung;

            edtProzessAustauschgespraech1.DataMember = DBO.KaEafSpezifischeErmittlung.ProzessAustauschgespraech1;
            edtProzessAustauschgespraech2.DataMember = DBO.KaEafSpezifischeErmittlung.ProzessAustauschgespraech2;
            edtProzessAustauschgespraech3.DataMember = DBO.KaEafSpezifischeErmittlung.ProzessAustauschgespraech3;
            edtProzessDatumAustauschgespraech1.DataMember = DBO.KaEafSpezifischeErmittlung.ProzessDatumAustauschgespraech1;
            edtProzessDatumAustauschgespraech2.DataMember = DBO.KaEafSpezifischeErmittlung.ProzessDatumAustauschgespraech2;
            edtProzessDatumAustauschgespraech3.DataMember = DBO.KaEafSpezifischeErmittlung.ProzessDatumAustauschgespraech3;

            edtProzessAbschlussgespraechErfolgt.DataMember = DBO.KaEafSpezifischeErmittlung.ProzessAbschlussgespraechErfolgt;
            edtProzessSchlussbericht.DataMember = DBO.KaEafSpezifischeErmittlung.ProzessSchlussbericht;
            docProzessSchlussbericht.DataMember = DBO.KaEafSpezifischeErmittlung.DocumentID_ProzessSchlussbericht;
            edtProzessAustrittsbefragungErfolgt.DataMember = DBO.KaEafSpezifischeErmittlung.ProzessAustrittsbefragungErfolgt;
            edtProzessBemerkungenAbschluss.DataMember = DBO.KaEafSpezifischeErmittlung.ProzessBemerkungenAbschluss;

            // Interventionen
            edtInterventionDatumAufforderung1.DataMember = DBO.KaEafSpezifischeErmittlung.InterventionenDatumAufforderung1;
            edtInterventionDatumAufforderung2.DataMember = DBO.KaEafSpezifischeErmittlung.InterventionenDatumAufforderung2;
            edtInterventionAufforderung1.DataMember = DBO.KaEafSpezifischeErmittlung.InterventionenAufforderung1;
            edtInterventionAufforderung2.DataMember = DBO.KaEafSpezifischeErmittlung.InterventionenAufforderung2;
            docInterventionAufforderung1.DataMember = DBO.KaEafSpezifischeErmittlung.DocumentID_InterventionenAufforderung1;
            docInterventionAufforderung2.DataMember = DBO.KaEafSpezifischeErmittlung.DocumentID_InterventionenAufforderung2;
            docInterventionAufforderung3.DataMember = DBO.KaEafSpezifischeErmittlung.DocumentID_InterventionenAufforderung3;
            docInterventionVereinbarung1.DataMember = DBO.KaEafSpezifischeErmittlung.DocumentID_InterventionenVereinbarung1;
            docInterventionVereinbarung2.DataMember = DBO.KaEafSpezifischeErmittlung.DocumentID_InterventionenVereinbarung2;
            docInterventionVerwarnung1.DataMember = DBO.KaEafSpezifischeErmittlung.DocumentID_InterventionenVerwarnung1;
            docInterventionVerwarnung2.DataMember = DBO.KaEafSpezifischeErmittlung.DocumentID_InterventionenVerwarnung2;
            docInterventionProgrammabbruch.DataMember = DBO.KaEafSpezifischeErmittlung.DocumentID_InterventionenProgrammabbruch;

            // Austritt
            ctlKaEafAustritt.DataMemberAbbruch = DBO.KaEafSpezifischeErmittlung.KaEafAustrittsgrundAbbruchAnbieterCode;
            ctlKaEafAustritt.DataMemberAustrittsgrund = DBO.KaEafSpezifischeErmittlung.KaEafAustrittsgrundCode;
            ctlKaEafAustritt.DataMemberDatum = DBO.KaEafSpezifischeErmittlung.AustrittDatum;
            ctlKaEafAustritt.DataMemberMassnahmeBeendet = DBO.KaEafSpezifischeErmittlung.KaEafAustrittsgrundMassnahmeBeendetCode;

            // DocContext
            docProzessVereinbarung.Context = DOCCONTEXT_PROZESS_EINTRITT_NAME;
            docProzessSchlussbericht.Context = DOCCONTEXT_PROZESS_ABSCHLUSS_NAME;
            docInterventionAufforderung1.Context = DOCCONTEXT_INTERVENTION_AUFFORDERUNG_NAME;
            docInterventionAufforderung2.Context = DOCCONTEXT_INTERVENTION_AUFFORDERUNG_NAME;
            docInterventionAufforderung3.Context = DOCCONTEXT_INTERVENTION_AUFFORDERUNG_NAME;
            docInterventionVereinbarung1.Context = DOCCONTEXT_INTERVENTION_VEREINBARUNG_NAME;
            docInterventionVereinbarung2.Context = DOCCONTEXT_INTERVENTION_VEREINBARUNG_NAME;
            docInterventionVerwarnung1.Context = DOCCONTEXT_INTERVENTION_VERWARNUNG_NAME;
            docInterventionVerwarnung2.Context = DOCCONTEXT_INTERVENTION_VERWARNUNG_NAME;
            docInterventionProgrammabbruch.Context = DOCCONTEXT_INTERVENTION_PROGRAMMABBRUCH_NAME;
        }
    }
}