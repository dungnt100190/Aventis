using System;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Main
{
    public partial class DlgNeuerFall : KiSS4.Gui.KissDialog
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "DlgNeuerFall";

        #endregion

        #region Private Fields

        private ISuchePerson ctlSuchePerson;
        private int newBaPersonID;

        #endregion

        #endregion

        #region Constructors

        public DlgNeuerFall()
        {
            this.InitializeComponent();

            ctlSuchePerson = AssemblyLoader.CreateInstance("CtlSuchePerson") as ISuchePerson;
            Control ctlSuchePersonControl = ctlSuchePerson as Control;
            ctlSuchePersonControl.Dock = DockStyle.Fill;
            pnlFill.Controls.Add(ctlSuchePersonControl);
            this.ActiveControl = ctlSuchePersonControl;
        }

        #endregion

        #region Properties

        public int NewBaPersonID
        {
            get { return newBaPersonID; }
            set { newBaPersonID = value; }
        }

        #endregion

        #region EventHandlers

        private void btnNeuerFall_Click(object sender, EventArgs e)
        {
            editSAR.CheckPendingSearchValue();
            if (DBUtil.IsEmpty(editSAR.LookupID))
            {
                KissMsg.ShowInfo(CLASSNAME, "SARFallfuehrungLeer", "Das Feld 'SAR Fallführung' darf nicht leer bleiben!");
                editSAR.Focus();
                return;
            }

            if (DBUtil.IsEmpty(editGemeinde.EditValue))
            {
                KissMsg.ShowInfo(CLASSNAME, "ZustaendigeGemeindeLeer", "Das Feld 'zuständige Gemeinde' darf nicht leer bleiben!");
                editGemeinde.Focus();
                return;
            }

            int? baRelatedPersonIDNillable = null;
            try
            {
                Cursor = Cursors.WaitCursor;
                baRelatedPersonIDNillable = ctlSuchePerson.GetPersonIDCreateIfNecessary(false);
                if (!baRelatedPersonIDNillable.HasValue)
                {
                    //ctlSuchePerson notifiziert die Probleme bereits selber. Keine MsgBox nötig.
                    return;
                }
                this.newBaPersonID = baRelatedPersonIDNillable.Value;
            }
            catch
            {
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            try
            {
                if (ctlSuchePerson.SelectedTabIndex == 0)
                {
                    if (!Session.User.IsUserKA)
                    {
                        //Prüfen, ob schon eine aktive Fallführung besteht
                        int count = (int)DBUtil.ExecuteScalarSQL(@"
                        SELECT COUNT(*)
                        FROM FaLeistung
                        WHERE BaPersonID = {0} AND ModulID = 2 AND DatumBis IS NULL",
                            baRelatedPersonIDNillable.Value);

                        if (count > 0)
                            throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME, "BereitsAktiverFall", "Für diese Person gibt es bereits einen aktiven Fall!", KissMsgCode.MsgInfo));
                    }
                }
                this.newBaPersonID = baRelatedPersonIDNillable.Value;

                DBUtil.ExecSQL(@"EXEC dbo.spKbKostenstelleAnlegen {0}, {1}", this.newBaPersonID, Session.User.UserID);

                //neuen FaFall erzeugen
                qryFaLeistung.Fill("SELECT * FROM FaLeistung WHERE 1=2");

                if (KAllgemeinExist(this.newBaPersonID) && Session.User.IsUserKA)
                {
                    KissMsg.ShowInfo(CLASSNAME, "FallExistiertBereits", "Für diese Person gibt es bereits einen aktiven Fall!");
                }
                else
                {
                    qryFaLeistung.Insert();

                    qryFaLeistung["FaFallID"] = this.newBaPersonID;
                    qryFaLeistung["FaProzessCode"] = 200;
                    qryFaLeistung["BaPersonID"] = this.newBaPersonID;
                    qryFaLeistung["ModulID"] = 2;
                    qryFaLeistung["UserID"] = editSAR.LookupID;
                    qryFaLeistung["DatumVon"] = DateTime.Today;
                }

                if (Session.User.IsUserKA)
                {
                    if (!KAllgemeinExist(this.newBaPersonID))
                    {
                        qryFaLeistung["ModulID"] = 7;
                        qryFaLeistung["FaProzessCode"] = 700;
                    }
                    else
                    {
                        qryFaLeistung.Fill(@"
                            SELECT *
                            FROM FaLeistung FAL
                            WHERE FAL.ModulID = 7
                              AND FAL.FaProzessCode = 700
                              AND FAL.BaPersonID = {0} ",
                            this.newBaPersonID);
                    }
                }
                else
                {
                    qryFaLeistung["GemeindeCode"] = editGemeinde.EditValue;
                }

                if (!qryFaLeistung.Post())
                    return;

                //this.UserID = (int)editSAR.LookupID;

                // Jump to new Fall
                if (Session.User.IsUserKA)
                {
                    FormController.OpenForm("FrmFall", "Action", "ShowFall",
                        "BaPersonID", NewBaPersonID,
                        "ModulID", ModulID.K);
                }
                else
                {
                    FormController.OpenForm("FrmFall", "Action", "ShowFall",
                        "BaPersonID", NewBaPersonID,
                        "ModulID", ModulID.F);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                throw new KissErrorException(KissMsg.GetMLMessage("DlgErfassungPerson", "FehlerBeiAnlegenPerson", "Beim Anlegen der neuen Person ist ein Fehler aufgetreten.", KissMsgCode.MsgError), ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void DlgNeuerFall_Load(object sender, System.EventArgs e)
        {
            //Falls nur eine Gemeinde: diese Gemeinde vorschlagen
            SqlQuery qry = (SqlQuery)editGemeinde.Properties.DataSource;
            if (qry.Count == 2)
                editGemeinde.EditValue = qry.DataTable.Rows[1][0];  //1. Row, 1.Kolonne

            var defaultGemeinde = DBUtil.GetConfigValue(@"System\Allgemein\DefaultGemeindeNeuerFall", null, DateTime.Now) as int?;
            if (defaultGemeinde != null)
            {
                editGemeinde.EditValue = defaultGemeinde;
            }
            //eingeloggten User vorschlagen
            string UserName = Session.User.LastName;
            if (!DBUtil.IsEmpty(Session.User.FirstName))
                UserName += ", " + Session.User.FirstName;

            editSAR.EditValue = UserName;
            editSAR.LookupID = Session.User.UserID;
        }

        private void editSAR_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(editSAR.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                editSAR.EditValue = dlg["Name"];
                editSAR.LookupID = dlg["UserID"];
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private bool KAllgemeinExist(int BaPersID)
        {
            bool rslt = false;

            int cnt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT COUNT(*)
                    FROM FaLeistung FAL
                    WHERE FAL.ModulID = 7
                    AND FAL.FaProzessCode = 700
                    AND FAL.BaPersonID = {0} "
                , BaPersID));

            rslt = cnt > 0;

            return rslt;
        }

        #endregion

        #endregion
    }
}