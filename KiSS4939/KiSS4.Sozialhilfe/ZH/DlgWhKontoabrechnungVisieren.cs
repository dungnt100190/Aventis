using System;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe.ZH
{
    public partial class DlgWhKontoabrechnungVisieren : KissDialog
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string QRY_DATUM_ANFRAGE = "DatumAnfrage";
        private const string QRY_DATUM_BIS = "DatumBis";
        private const string QRY_DATUM_VON = "DatumVon";
        private const string QRY_FA_FALL_ID = "FaFallID";
        private const string QRY_USERID_VISUM = "UserID_Visum";
        private const string QRY_USER_VON_NAME_VORNAME = "UserVon_NameVorname";
        private const string QRY_WH_ABRECHNUNG_ID = "WhAbrechnungID";
        private const string QRY_WH_ABRECHNUNG_VISUM_CODE = "WhAbrechnungVisumCode";

        #endregion

        #endregion

        #region Constructors

        public DlgWhKontoabrechnungVisieren(int whAbrechnungID)
            : this()
        {
            qryAnfrage.Fill(whAbrechnungID);
            edtSender.EditValue = qryAnfrage[QRY_USER_VON_NAME_VORNAME];
        }

        public DlgWhKontoabrechnungVisieren()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void DlgWhKontoabrechnungVisieren_Load(object sender, EventArgs e)
        {
            edtSender.Focus();
        }

        // Werte in die Datenbank in FaJournal einfügen
        private bool InsertFVProtokoll_AbrechnungVisieren()
        {
            // Einen neuen Eintrag im Fallverlaufsprotokoll einfügen
            // -----------------------------------------------------
            // Parameter der sp:  {0}=FaFallID, {1}=FaLeistungID, {2}=BaPersonID, {3}=UserID, {4}=FaJournalCode, {5}=Text
            // Info:              Wenn FaFallID NULL ist, wird versucht (1.) via FaLeistungID oder (2.) via BaPersonID die FaFallID zu setzen.
            //                    Wenn BaPersonID NULL ist, wird versucht (1.) via FaLeistungID oder (2.) via FaFallID die BaPersonID zu setzen.
            // Rückgabewert:      Eingefügte FaJournalID des neuen Eintrags - zum Ändern von zusätzlichen Werten verwendbar
            int faJournalID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                EXEC spFaInsertFVProtokoll {0}, {1}, {2}, {3}, {4}, {5}",
                qryAnfrage[QRY_FA_FALL_ID], //FaFallID,
                DBNull.Value, //FaLeistungID
                DBNull.Value, //BaPersonID,
                Session.User.UserID,
                1, //FaJournalCode
                string.Format("Die Abrechnung (#{0}) wurde visiert, {1:d} - {2:d}",
                    qryAnfrage[QRY_WH_ABRECHNUNG_ID],
                    qryAnfrage[QRY_DATUM_VON],
                    qryAnfrage[QRY_DATUM_BIS])));

            // return if valid new id (< 1 = invalid)
            return faJournalID > 0;
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            qryAnfrage.RowModified = false;
            qryAnfrage.DataSet.AcceptChanges();
        }

        private void btnAblehnen_Click(object sender, EventArgs e)
        {
            qryAnfrage[QRY_WH_ABRECHNUNG_VISUM_CODE] = 4; // abgelehnt
            qryAnfrage.Post();
            DialogResult = DialogResult.No;
        }

        private void btnVisieren_Click(object sender, EventArgs e)
        {
            qryAnfrage[QRY_WH_ABRECHNUNG_VISUM_CODE] = 3; // angefragt
            qryAnfrage.Post();

            // Visieren
            DialogResult = InsertFVProtokoll_AbrechnungVisieren() ? DialogResult.OK : DialogResult.Cancel;
        }

        private void qryAnfrage_BeforePost(object sender, EventArgs e)
        {
            int neuerStatus = (int)qryAnfrage[QRY_WH_ABRECHNUNG_VISUM_CODE];

            if (neuerStatus != 3 && neuerStatus != 4)
            {
                // Wir speichern nur, falls der Benutzer visiert oder abgelehnt hat
                throw new KissInfoException("Ungültiger Zustand, Änderungen werden nicht gespeichert.");
            }

            qryAnfrage[QRY_USERID_VISUM] = Session.User.UserID;
            qryAnfrage[QRY_DATUM_ANFRAGE] = DateTime.Now;
        }

        #endregion
    }
}