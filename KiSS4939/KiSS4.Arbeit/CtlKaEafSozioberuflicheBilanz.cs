using System;
using System.Drawing;
using KiSS.DBScheme;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public partial class CtlKaEafSozioberuflicheBilanz : KissUserControl
    {
        private const string DOCCONTEXT_INTERVENTION_PROGRAMMABBRUCH_NAME = "KaEafSozioberuflicheBilanz_Inter_Programmabbruch";
        private const string DOCCONTEXT_INTERVENTION_VEREINBARUNG_NAME = "KaEafSozioberuflicheBilanz_Inter_Vereinbarung";
        private const string DOCCONTEXT_INTERVENTION_VERWARNUNG_NAME = "KaEafSozioberuflicheBilanz_Inter_Verwarnung";
        private const string DOCCONTEXT_PROZESS_ABSCHLUSS_NAME = "KaEafSozioberuflicheBilanz_Prozess_Abschluss";
        private const string DOCCONTEXT_PROZESS_BEWERBUNGSKOMPETENZ = "KaEafSozioberuflicheBilanz_Prozess_Bewerbungskomp";
        private const string DOCCONTEXT_PROZESS_EINTRITT_NAME = "KaEafSozioberuflicheBilanz_Prozess_Eintritt";
        private const string DOCCONTEXT_PROZESS_ERMITTLUNG_NAME = "KaEafSozioberuflicheBilanz_Prozess_Ermittlung";
        private const string DOCCONTEXT_PROZESS_FAEHIGKEITSANALYSE = "KaEafSozioberuflicheBilanz_Prozess_Faehigkeitsan";
        private int _baPersonId;
        private int _faLeistungId;

        public CtlKaEafSozioberuflicheBilanz()
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

            tabSozioberuflicheBilanz.SelectTab(tpgProzessuebersicht);

            var sichtbarSdFlag = KaUtil.GetSichtbarSDFlag(baPersonId);

            bool mayUpd, unused;
            DBUtil.GetFallRights(faLeistungId, out unused, out unused, out mayUpd, out unused, out unused, out unused);

            qryLeistung.Fill(faLeistungId);

            // 9474: Falls wiederholteSpezifischeErmittlungEAF = true, dann ist das ganze Control ReadOnly
            var wiederholteSpezifischeErmittlungEaf = Utils.ConvertToBool(qryLeistung[DBO.FaLeistung.WiederholteSpezifischeErmittlungEAF]);

            qryKaEafSozioberuflicheBilanz.CanUpdate = qryKaEafSozioberuflicheBilanz.CanUpdate && mayUpd && sichtbarSdFlag == 0 && !wiederholteSpezifischeErmittlungEaf;
            qryKaEafSozioberuflicheBilanz.CanInsert = !wiederholteSpezifischeErmittlungEaf;
            qryKaEafSozioberuflicheBilanz.Fill(faLeistungId);

            qryEinsatz.CanUpdate = !wiederholteSpezifischeErmittlungEaf;
            qryEinsatz.CanInsert = !wiederholteSpezifischeErmittlungEaf;
            qryEinsatz.Fill(faLeistungId, sichtbarSdFlag);

            if (qryKaEafSozioberuflicheBilanz.IsEmpty && qryKaEafSozioberuflicheBilanz.CanUpdate)
            {
                qryKaEafSozioberuflicheBilanz.Insert(DBO.KaEafSozioberuflicheBilanz.DBOName);
                qryKaEafSozioberuflicheBilanz[DBO.KaEafSozioberuflicheBilanz.FaLeistungID] = faLeistungId;
                qryKaEafSozioberuflicheBilanz.Post();
            }

            ctlKaEafAustritt.UpdateEditmode();
        }

        private void qryKaEafSozioberuflicheBilanz_AfterPost(object sender, EventArgs e)
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

        private void qryKaEafSozioberuflicheBilanz_BeforePost(object sender, EventArgs e)
        {
            Session.BeginTransaction();
        }

        private void SetUpDataMembers()
        {
            edtAnwesendTeilzeit.DataMember = DBO.KaEafSozioberuflicheBilanz.AnwesendTeilzeit;
            edtSchwerpunkte.DataMember = DBO.KaEafSozioberuflicheBilanz.Schwerpunkte;

            // Prozessübersicht
            edtProzessAbschlussgespraechErfolgt.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessAbschlussgespraechErfolgt;
            edtProzessAufnahmeverfahrenErfolgt.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessAufnahmeverfahrenErfolgt;
            edtProzessAustrittsbefragungErfolgt.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessAustrittsbefragungErfolgt;
            edtProzessBemerkungenAbschluss.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessBemerkungenAbschluss;
            edtProzessDatumVerzahnungsgespraech1.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessDatumVerzahnungsgespraech1;
            edtProzessDatumVerzahnungsgespraech2.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessDatumVerzahnungsgespraech2;
            edtProzessDatumVerzahnungsgespraech3.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessDatumVerzahnungsgespraech3;
            edtProzessDatumZwischengespraech.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessDatumZwischengespraech;
            edtProzessEinladungErfolgt.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessEinladungErfolgt;
            edtProzessErmittlungsprogrammErstellt.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessErmittlungsprogrammErstellt;
            edtProzessFaehigkeitsprofilMelba.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessFaehigkeitsprofilMelba;
            edtProzessFaehigkeitsanalyse.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessFaehigkeitsAnalyse;
            edtProzessBewerbungskompetenz.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessBewerbungskompetenz;
            edtProzessSchlussbericht.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessSchlussbericht;
            edtProzessVerzahnungsgespraech1.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessVerzahnungsgespraech1;
            edtProzessVerzahnungsgespraech2.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessVerzahnungsgespraech2;
            edtProzessVerzahnungsgespraech3.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessVerzahnungsgespraech3;
            edtProzessZwischengespraech.DataMember = DBO.KaEafSozioberuflicheBilanz.ProzessZwischengespraech;

            docProzessErmittlungsprogramm.DataMember = DBO.KaEafSozioberuflicheBilanz.DocumentID_ProzessErmittlungsprogramm;
            docProzessFaehigkeitsprofilMelba.DataMember = DBO.KaEafSozioberuflicheBilanz.DocumentID_ProzessFaehigkeitsprofilMelba;
            docProzessFaehigkeitsanalyse.DataMember = DBO.KaEafSozioberuflicheBilanz.DocumentID_ProzessFaehigkeitsAnalyse;
            docProzessBewerbungskompetenz.DataMember = DBO.KaEafSozioberuflicheBilanz.DocumentID_ProzessBewerbungskompetenz;
            docProzessSchlussbericht.DataMember = DBO.KaEafSozioberuflicheBilanz.DocumentID_ProzessSchlussbericht;

            // Interventionen
            edtInterventionenDatumAufforderung.DataMember = DBO.KaEafSozioberuflicheBilanz.InterventionenDatumAufforderung;
            edtInterventionenAufforderung.DataMember = DBO.KaEafSozioberuflicheBilanz.InterventionenAufforderung;

            docInterventionVereinbarung.DataMember = DBO.KaEafSozioberuflicheBilanz.DocumentID_InterventionenVereinbarung;
            docInterventionVerwarnung1.DataMember = DBO.KaEafSozioberuflicheBilanz.DocumentID_InterventionenVerwarnung1;
            docInterventionVerwarnung2.DataMember = DBO.KaEafSozioberuflicheBilanz.DocumentID_InterventionenVerwarnung2;
            docInterventionProgrammabbruch.DataMember = DBO.KaEafSozioberuflicheBilanz.DocumentID_InterventionenProgrammabbruch;

            // Austritt
            ctlKaEafAustritt.DataMemberAbbruch = DBO.KaEafSozioberuflicheBilanz.KaEafAustrittsgrundAbbruchAnbieterCode;
            ctlKaEafAustritt.DataMemberAustrittsgrund = DBO.KaEafSozioberuflicheBilanz.KaEafAustrittsgrundCode;
            ctlKaEafAustritt.DataMemberDatum = DBO.KaEafSozioberuflicheBilanz.AustrittDatum;
            ctlKaEafAustritt.DataMemberMassnahmeBeendet = DBO.KaEafSozioberuflicheBilanz.KaEafAustrittsgrundMassnahmeBeendetCode;

            // DocContext
            docProzessErmittlungsprogramm.Context = DOCCONTEXT_PROZESS_EINTRITT_NAME;
            docProzessFaehigkeitsprofilMelba.Context = DOCCONTEXT_PROZESS_ERMITTLUNG_NAME;
            docProzessSchlussbericht.Context = DOCCONTEXT_PROZESS_ABSCHLUSS_NAME;
            docProzessFaehigkeitsanalyse.Context = DOCCONTEXT_PROZESS_FAEHIGKEITSANALYSE;
            docProzessBewerbungskompetenz.Context = DOCCONTEXT_PROZESS_BEWERBUNGSKOMPETENZ;

            docInterventionVereinbarung.Context = DOCCONTEXT_INTERVENTION_VEREINBARUNG_NAME;
            docInterventionVerwarnung1.Context = DOCCONTEXT_INTERVENTION_VERWARNUNG_NAME;
            docInterventionVerwarnung2.Context = DOCCONTEXT_INTERVENTION_VERWARNUNG_NAME;
            docInterventionProgrammabbruch.Context = DOCCONTEXT_INTERVENTION_PROGRAMMABBRUCH_NAME;
        }
    }
}