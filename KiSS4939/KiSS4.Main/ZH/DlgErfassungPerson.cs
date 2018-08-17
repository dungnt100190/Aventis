using System;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.FAMOZ.VIS;

namespace KiSS4.Main.ZH
{
    public partial class DlgErfassungPerson : Gui.KissDialog
    {
        private int baPersonID;
        private int baRelatedPersonID;

        public DlgErfassungPerson(int baPersonID)
            : this()
        {
            this.baPersonID = baPersonID;
        }

        public DlgErfassungPerson()
        {
            InitializeComponent();
            Activated += this_Activated;
        }

        public int BaPersonID
        {
            get { return baPersonID; }
            set { baPersonID = value; }
        }

        public int BaRelatedPersonID
        {
            get { return baRelatedPersonID; }
            set { baRelatedPersonID = value; }
        }

        public static void InsertRelation(int relationID, int falltraegerID, int baRelatedPersonID, string selectedVisFallNr, DlgErfassungPerson dlgErfassungPerson)
        {
            try
            {
                if (dlgErfassungPerson != null)
                {
                    dlgErfassungPerson.DialogResult = DialogResult.OK;
                }

                var qryAktuellerFall = DBUtil.OpenSQL(@"
                    SELECT TOP 1 FaFallID, DatumBis
                    FROM FaFall
                    WHERE BaPersonID = {0}
                    ORDER BY DatumVon DESC", falltraegerID);

                //Prüfen, ob die neue Person die Fallträgerin selbst ist
                if (baRelatedPersonID == falltraegerID)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("DlgErfassungPerson", "PersonIstFalltraeger", "Diese Person ist der/die Fallträger/-in!", KissMsgCode.MsgInfo));
                }

                //Prüfen, ob diese Person bereits im Klientensystem besteht
                var count = (int)DBUtil.ExecuteScalarSQL(@"
                        SELECT COUNT(*)
                        FROM FaFallPerson
                        WHERE FaFallID = {0} AND BaPersonID = {1}",
                    qryAktuellerFall["FaFallID"], baRelatedPersonID);

                if (count > 0)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("DlgErfassungPerson", "PersonImKlientensystem", "Diese Person gehört bereits zum Klientensystem", KissMsgCode.MsgInfo));
                }

                // Falls VIV-Fall => Lasse Benutzer noch die Massnahme selektieren (inkl. Prüfung, ob Massnahme nicht schon im KiSS geführt wird)
                DlgVISNeueMassnahme dlgVisNeueMassnahme = null;
                if (!DBUtil.IsEmpty(selectedVisFallNr))
                {
                    //neue Leistungseinheit (Vormundschaftliches Mandat)
                    dlgVisNeueMassnahme = new DlgVISNeueMassnahme((int)qryAktuellerFall["FaFallID"], int.Parse(selectedVisFallNr), baRelatedPersonID, false);
                    dlgVisNeueMassnahme.ShowDialog();

                    if (dlgVisNeueMassnahme.DialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                Session.BeginTransaction();

                //neue Person im Klientensystem erzeugen
                //"Richtung" der Beziehung prüfen
                object baPersonID1;
                object baPersonID2;
                int baPersonRelationID;

                if (relationID < 100)
                {
                    baPersonID1 = baRelatedPersonID;
                    baPersonID2 = falltraegerID;
                    baPersonRelationID = relationID;
                }
                else
                {
                    baPersonID1 = falltraegerID;
                    baPersonID2 = baRelatedPersonID;
                    baPersonRelationID = relationID - 100;
                }

                DBUtil.ExecSQLThrowingException(@"
                    IF NOT EXISTS (SELECT * FROM BaPerson_Relation WHERE BaPersonID_1 = {0} AND BaPersonID_2 = {1})
                      AND NOT EXISTS (SELECT * FROM BaPerson_Relation WHERE BaPersonID_1 = {1} AND BaPersonID_2 = {0})
                    BEGIN
                      INSERT INTO BaPerson_Relation (BaPersonID_1, BaPersonID_2, BaRelationID)
                        VALUES ({0}, {1}, {2})
                    END",
                    baPersonID1, baPersonID2, baPersonRelationID);

                if (DBUtil.IsEmpty(qryAktuellerFall["DatumBis"]))
                {
                    // Der letzte Fall ist offen, Person diesem dazufügen
                    DBUtil.ExecSQLThrowingException(@"
                        INSERT INTO FaFallPerson (FaFallID, BaPersonID)
                          VALUES ({0}, {1})",
                        qryAktuellerFall["FaFallID"], baRelatedPersonID);

                    //Eintrag ins Fallverlaufsprotokoll
                    DBUtil.ExecSQL(@"
                        INSERT FaJournal (FaFallID, BaPersonID, UserID, Text, OrgUnitID)
                                  VALUES ({0}, {1}, {2}, {3}, {4})",
                                    qryAktuellerFall["FaFallID"], baRelatedPersonID, Session.User.UserID, "Aufnahme ins Klientensystem", Session.User["OrgUnitID"]);
                }
                else
                {
                    throw new KissCancelException("Der aktuelle Fall des Fallträgers ist abgeschlossen, deshalb kann die Person nicht dem Fall hinzugefügt werden");
                }

                if (dlgErfassungPerson != null)
                {
                    dlgErfassungPerson.DialogResult = DialogResult.OK;
                }
                Session.Commit();

                // Erstelle noch die V-Leistung, falls nötig
                if (dlgVisNeueMassnahme != null)
                {
                    dlgVisNeueMassnahme.CreateVLeistung();
                }
            }
            catch (KissCancelException exp)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }
                KissMsg.ShowInfo(exp.Message);

                if (dlgErfassungPerson != null)
                {
                    dlgErfassungPerson.DialogResult = DialogResult.Cancel;
                }
            }
            catch (Exception exp)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }
                throw new KissErrorException(KissMsg.GetMLMessage("DlgErfassungPerson", "FehlerBeiAnlegenPerson", "Beim Anlegen der neuen Person ist ein Fehler aufgetreten.", KissMsgCode.MsgError), exp);
            }
        }

        private void btnNeuePerson_Click(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(edtBaRelationID.EditValue))
            {
                KissMsg.ShowInfo("DlgErfassungPerson", "BeziehungZuFalltraegerLeer", "Das Feld 'Beziehung zu Fallträger/-in' darf nicht leer bleiben!");
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                int? baRelatedPersonIDNillable = ctlSuchePerson.GetPersonIDCreateIfNecessary(false);
                if (!baRelatedPersonIDNillable.HasValue)
                {
                    // Fehler in CtlSuchePerson, keine Person selektiert
                    KissMsg.ShowInfo("DlgErfassungPerson", "KeinePersonAusgewaehlt", "Es ist keine Person ausgewählt.");
                    return;
                }

                InsertRelation((int)edtBaRelationID.EditValue, baPersonID, baRelatedPersonIDNillable.Value, (string)ctlSuchePerson.SelectedVISFallNr, this);
            }
            catch (KissInfoException ex)
            {
                ex.ShowMessage();
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("DlgNeuerFall", "FehlerGetPerson", "Die Person konnte nicht eingefügt werden.", ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void DlgErfassungPerson_Load(object sender, EventArgs e)
        {
            edtBaRelationID.Properties.DataSource = DBUtil.OpenSQL(@"
                select Code = BaRelationID, Text = NameGenerisch1, SortKey from BaRelation WHERE AusblendenBeiFallaufnahme = 0
                union all
                select Code = BaRelationID + 100, Text = NameGenerisch2, SortKey from BaRelation
                where symmetrisch = 0 AND AusblendenBeiFallaufnahme = 0 --NameGenerisch1 <> NameGenerisch2
                ORDER BY 3 asc, 1 desc");
        }

        private void this_Activated(object sender, EventArgs e)
        {
            ctlSuchePerson.Activate();
        }
    }
}