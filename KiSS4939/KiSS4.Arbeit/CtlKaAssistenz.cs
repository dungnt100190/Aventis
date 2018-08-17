using System;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Arbeit
{
    public partial class CtlKaAssistenz : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _faLeistungID;

        #endregion

        #endregion

        #region Constructors

        public CtlKaAssistenz()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void qryKaAssistenz_AfterPost(object sender, EventArgs e)
        {
            try
            {
                KaUtil.UpdateKaArbeitsRapportRecords(_faLeistungID);

                Session.Commit();
            }
            catch (Exception exc)
            {
                Session.Rollback();
                KissMsg.ShowInfo(exc.Message);
                throw new KissCancelException();
            }
        }

        private void qryKaAssistenz_BeforePost(object sender, EventArgs e)
        {
            // prüfen ob KaArbeitsrapport-Einträge vor dem neuen Datum vorhanden sind
            DateTime? datumVon;
            DateTime? datumBis;
            var hatArbeitsrapport = KaUtil.WouldKaArbeitsRapportRecordsBeDeleted(_faLeistungID, qryKaAssistenz[DBO.KaAssistenz.Austrittsdatum] as DateTime?, out datumVon, out datumBis);

            // wenn ja, fragen ob die Daten gelöscht werden können
            if (hatArbeitsrapport && datumVon.HasValue && datumBis.HasValue)
            {
                var answer = KissMsg.ShowQuestion(
                    Name,
                    "FrageZeiterfassungLoeschen",
                    "Es sind bereits Daten für die Präsenzzeiterfassung vor dem {0} oder nach dem {1} vorhanden." + Environment.NewLine +
                    "Wollen Sie diese Daten löschen?",
                    true,
                    datumVon.Value.ToShortDateString(),
                    datumBis.Value.ToShortDateString());

                if (!answer)
                {
                    throw new KissCancelException();
                }
            }

            Session.BeginTransaction();
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string maskName, Image maskImage, int faLeistungID, int baPersonID)
        {
            lblTitle.Text = maskName;
            imageTitle.Image = maskImage;
            _faLeistungID = faLeistungID;

            SetupDataMember();

            SetupEditMode();
            FillQuery();
        }

        #endregion

        #region Private Methods

        private void FillQuery()
        {
            if (!RecordExists() && qryKaAssistenz.CanInsert && qryKaAssistenz.CanUpdate)
            {
                DBUtil.ExecSQL(@"
                  INSERT INTO KaAssistenz (FaLeistungID, Creator, Modifier)
                  VALUES ({0}, {1}, {1})",
                               _faLeistungID, DBUtil.GetDBRowCreatorModifier());
            }
            qryKaAssistenz.Fill(_faLeistungID, Session.User.IsUserKA ? 0 : 1); //EigeneMaske hatte P-Code: CheckSichtbarSD -> Daten nur anzeigen wenn User.IsUserKA || BaPerson.SichtbarSD
        }

        private bool RecordExists()
        {
            bool? exists = DBUtil.ExecuteScalarSQL(@"
                SELECT CONVERT(BIT, ISNULL((SELECT TOP 1 1
                FROM dbo.KaAssistenz
                WHERE FaLeistungID = {0}), 0))", _faLeistungID) as bool?;

            return exists.HasValue && exists.Value;
        }

        private void SetupDataMember()
        {
            chkAbgemeldetVonALV.DataMember = DBO.KaAssistenz.Abgemeldet;
            chkNichtErschienenOhneAbmeldung.DataMember = DBO.KaAssistenz.NichtErschienen;
            chkGespraechStattgefunden.DataMember = DBO.KaAssistenz.GespraechStattgefunden;
            chkProgrammBeginn.DataMember = DBO.KaAssistenz.Programmbeginn;

            edtEinsatzplatz.DataMember = DBO.KaAssistenz.Einsatzplatz;
            edtStufe.DataMember = DBO.KaAssistenz.Stufe;

            chkPersonalien.DataMember = DBO.KaAssistenz.Personalien;
            chkVereinbarung.DataMember = DBO.KaAssistenz.Vereinbarung;
            chkZielvereinbarung.DataMember = DBO.KaAssistenz.Zielvereinbarung;
            chkSchlussbericht.DataMember = DBO.KaAssistenz.Schlussbericht;
            chkTestat.DataMember = DBO.KaAssistenz.Testat;

            edtBemerkungen.DataMember = DBO.KaAssistenz.Bemerkungen;

            edtAustrittsgrund.DataMember = DBO.KaAssistenz.KaAssistenzprojektAustrittsgrundCode;
            edtAustrittsdatum.DataMember = DBO.KaAssistenz.Austrittsdatum;
        }

        private void SetupEditMode()
        {
            bool mayRead;
            bool mayIns;
            bool mayUpd;
            bool mayDel;
            bool mayClose;
            bool mayReopen;
            DBUtil.GetFallRights(_faLeistungID, out mayRead, out mayIns, out mayUpd, out mayDel, out mayClose, out mayReopen);
            qryKaAssistenz.CanUpdate = mayUpd && DBUtil.UserHasRight(Name, "U");
            qryKaAssistenz.CanInsert = mayIns && DBUtil.UserHasRight(Name, "I");
            qryKaAssistenz.EnableBoundFields();
        }

        #endregion

        #endregion
    }
}