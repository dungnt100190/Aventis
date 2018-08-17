using System;
using System.Data;
using System.Drawing;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis.ZH
{
    public partial class CtlBaWohnsituation : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlBaWohnsituation";

        #endregion

        #region Private Fields

        private int _baPersonID;

        #endregion

        #endregion

        #region Constructors

        public CtlBaWohnsituation()
        {
            InitializeComponent();

            colWohnsituation.ColumnEdit = grdBaWohnsituation.GetLOVLookUpEdit("BaWohnstatus");
        }

        #endregion

        #region EventHandlers

        private void edtVermieter_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtVermieter.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBaWohnsituation["BaInstitutionID"] = DBNull.Value;
                    qryBaWohnsituation["Name"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT
                    ID$           = INS.BaInstitutionID,
                    Institution   = INS.Name,
                    Adresse       = INS.Adresse,
                    Typ           = INS.Typ
                FROM dbo.vwInstitution INS
                WHERE INS.BaFreigabeStatusCode = 2
                  AND INS.Name LIKE '%' + {0} + '%'
                  AND InstitutionTypCode = 16  --Vermieter
                ORDER BY INS.Name",
                searchString,
                e.ButtonClicked,
                null,
                null,
                null);

            if (!e.Cancel)
            {
                qryBaWohnsituation["BaInstitutionID"] = dlg[0];
                qryBaWohnsituation["Name"] = dlg[1];
            }
        }

        private void qryBaWohnsituationPerson_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            // Damit sp�ter gespeichert wird
            qryBaWohnsituation.RowModified = true;
        }

        private void qryBaWohnsituation_AfterDelete(object sender, EventArgs e)
        {
            // L�schen mit Transaktion
            try
            {
                // Transaktion abschliessen, welche in BeforeDelete gestartet wurde:
                Session.Commit();
            }
            catch
            {
                // Transaktion r�ckg�ngig machen, es wurde nichts gel�scht
                Session.Rollback();
                // TODO : bessere Meldung
                KissMsg.ShowInfo("Beim L�schen ist ein unbekannter Fehler aufgetreten.");
            }
        }

        private void qryBaWohnsituation_AfterFill(object sender, EventArgs e)
        {
            // Wenn keine Daten vorhanden sind, dann wird das Ereignis PositionChanged nicht ausgel�st!!!
            // Deshalb m�ssen wir das Ereignis PositionChanged hier ausl�sen,
            // damit das Fenster korrekt angezeigt wird, z.B. Sperren der Felder usw.:
            // Also bitte n�chste Zeile nicht entfernen!!!!
            if (qryBaWohnsituation.Count == 0)
            {
                qryBaWohnsituation_PositionChanged(sender, e);
            }
        }

        private void qryBaWohnsituation_AfterPost(object sender, EventArgs e)
        {
            // Jetzt muss noch Tab. BaWohnsituationPerson gef�llt werden:
            try
            {
                foreach (DataRow row in qryBaWohnsituationPerson.DataTable.Rows)
                {
                    if ((bool)row["IstInWohnung"])
                    {
                        // Person ist in Wohnung, also einf�gen fall notwendig:
                        DBUtil.ExecSQL(@"
                            IF NOT EXISTS(
                                SELECT BaPersonID
                                FROM dbo.BaWohnsituationPerson
                                WHERE BaWohnsituationID = {0}
                                  AND BaPersonID = {1})
                            BEGIN
                              INSERT BaWohnsituationPerson (BaWohnsituationID, BaPersonID)
                              VALUES ( {0}, {1} )
                            END",
                            (int)qryBaWohnsituation["BaWohnsituationID"],
                            (int)row["BaPersonID"]);
                    }
                    else
                    {
                        // Person ist nicht in Wohnung, also l�schen:
                        DBUtil.ExecSQL(@"
                            DELETE dbo.BaWohnsituationPerson
                            WHERE BaWohnsituationID = {0}
                              AND BaPersonID = {1} ",
                            (int)qryBaWohnsituation["BaWohnsituationID"],
                            (int)row["BaPersonID"]
                            );
                    }
                }

                // Transaktion abschliessen:
                Session.Commit();
            }
            catch
            {
                // Transaktion r�ckg�ngig machen, es wurde nichts gespeichert:
                Session.Rollback();
                // TODO : bessere Meldung
                KissMsg.ShowInfo("Beim Speichern ist ein unbekannter Fehler aufgetreten.");
            }

            // Daten neu anzeigen:
            qryBaWohnsituationPerson.Fill(qryBaWohnsituation["BaWohnsituationID"], _baPersonID);
        }

        private void qryBaWohnsituation_BeforeDelete(object sender, EventArgs e)
        {
            // Hier Transaktion starten:
            Session.BeginTransaction();

            // Alle Personen in Wohnsitution l�schen:
            DBUtil.ExecSQL(@"
                DELETE dbo.BaWohnsituationPerson
                WHERE BaWohnsituationID = {0} ",
                (int)qryBaWohnsituation["BaWohnsituationID"]);
        }

        private void qryBaWohnsituation_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            // Damit wird sichergestellt, dass die Anzahl und die Namen korrekt sind:
            // Also n�chste Zeile bitte nicht entfernen:
            qryBaWohnsituationPerson.Post();

            // Zuerst alle Personennamen zusammenstellen:
            string personenNamen = "";
            int anzPersonen = 0;
            foreach (DataRow row in qryBaWohnsituationPerson.DataTable.Rows)
            {
                if ((bool)row["IstInWohnung"])
                {
                    personenNamen += Utils.ConvertToString(row["PersonName"]) + "\r\n";
                    anzPersonen = 1;
                }
            }

            string tmpMsg;
            if (anzPersonen == 0)
            {
                // Wenn kein Namen vorhanden, dann gew�hnliche Abfrage:
                tmpMsg = "Wollen Sie diese Wohnsituation wirklich l�schen?";
            }
            else
            {
                // Wenn kein Namen vorhanden, dann gew�hnliche Abfrage:
                if (anzPersonen == 1)
                {
                    tmpMsg = "In dieser Wohnsitution ist noch eine Person vorhanden:\r\n\r\n";
                }
                else
                {
                    tmpMsg = string.Format(
                        "In dieser Wohnsitution sind noch {0} Personen vorhanden:\r\n\r\n",
                        anzPersonen
                        );
                }

                tmpMsg += personenNamen + "\r\n";
                tmpMsg += "Wollen Sie diese Wohnsituation trotzdem l�schen?";
            }

            qryBaWohnsituation.DeleteQuestion = tmpMsg;
        }

        private void qryBaWohnsituation_BeforePost(object sender, EventArgs e)
        {
            qryBaWohnsituationPerson.EndCurrentEdit();

            // Auf leere Felder pr�fen
            DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);
            DBUtil.CheckNotNullField(edtWohnsituation, lblWohnsituation.Text);

            // Kontrollieren, dass DatumVon kleiner als DatumBis ist
            if (!DBUtil.IsEmpty(edtDatumVon.EditValue) && !DBUtil.IsEmpty(edtDatumBis.EditValue))
            {
                if (Utils.ConvertToDateTime(edtDatumVon.EditValue) >= Utils.ConvertToDateTime(edtDatumBis.EditValue))
                {
                    KissMsg.ShowInfo(
                        CLASSNAME,
                        "DatumVonGroesserAlsDatumBis",
                        "Das Von-Datum darf nicht gr�sser als das Bis-Datum\r\n" +
                        "und auch nicht gleich wie das Bis-Datum sein."
                        );
                    throw new KissCancelException();
                }
            }

            // Es muss mindestens 1 Person gew�hlt sein, sonst kann nicht gespeichert werden!!
            // Wenn nicht, dann w�rden in der DB Dates�tze von BaWohnsituation zur�ckbleiben,
            // welche nie mehr erreicht werden!
            int anzMitbewohner = 0;
            foreach (DataRow row in qryBaWohnsituationPerson.DataTable.Rows)
            {
                if ((bool)row["IstInWohnung"])
                {
                    anzMitbewohner += 1;
                }
            }

            if (anzMitbewohner == 0)
            {
                grdBaWohnsituationPerson.Focus();
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "KeineMitbewohner",
                    "Mindestens eine Person im Haushalt muss erfasst sein."
                    );
                throw new KissCancelException();
            }

            // Hier Transaktion starten:
            Session.BeginTransaction();
        }

        private void qryBaWohnsituation_DeleteError(object sender, UnhandledExceptionEventArgs e)
        {
            // Wenn ein Fehler beim L�schen auftritt,
            // muss die begonnene Transaktion abgebrochen werden:
            // Transaktion r�ckg�ngig machen, es wurde nichts gespeichert:
            Session.Rollback();

            // TODO: bessere Meldung?
            KissMsg.ShowInfo(
                CLASSNAME,
                "DeleteFehler",
                "Beim L�schen ist ein unbekannter Fehler aufgetreten."
                );
        }

        private void qryBaWohnsituation_PositionChanged(object sender, EventArgs e)
        {
            if (qryBaWohnsituation.Count == 0)
            {
                // Wenn keine Wohnsituation vorhanden ist,
                // dann sollen im Gitter der Personen keine Daten angezeigt werden!
                // Deshalb �ffnen wir hier mit "BaPersonID = 0" :
                qryBaWohnsituationPerson.Fill(0, 0);
                qryBaWohnsituation.EnableBoundFields(false);
            }
            else
            {
                qryBaWohnsituationPerson.Fill(qryBaWohnsituation["BaWohnsituationID"], _baPersonID);
                qryBaWohnsituation.EnableBoundFields(true);

                // Falls soeben eine neue Wohnsitution eingef�gt wurde,
                // soll der aktuelle Klient automatisch eingef�gt werden:
                if (qryBaWohnsituation.Row.RowState == DataRowState.Added)
                {
                    foreach (DataRow row in qryBaWohnsituationPerson.DataTable.Rows)
                    {
                        if ((int)row["BaPersonID"] == _baPersonID)
                        {
                            row["IstInWohnung"] = true;
                            qryBaWohnsituation.RowModified = false;
                        }
                    }

                    qryBaWohnsituationPerson.First();
                }
            }

            if (qryBaWohnsituation.CanUpdate && qryBaWohnsituation.Count > 0
                && qryBaWohnsituation.Row.RowState != DataRowState.Added
                && !DBUtil.UserHasRight("CtlBaWohnsituation_Bearbeiten"))
            {
                qryBaWohnsituation.EnableBoundFields(false);
                ((IKissBindableEdit)edtDatumBis).AllowEdit(true);
            }
        }

        private void qryBaWohnsituation_PostError(object sender, UnhandledExceptionEventArgs e)
        {
            // Wenn ein Fehler beim Posten auftritt,
            // muss die begonnene Transaktion abgebrochen werden:
            // Transaktion r�ckg�ngig machen, es wurde nichts gespeichert:
            Session.Rollback();

            // TODO: bessere Meldung?
            KissMsg.ShowInfo(
                CLASSNAME,
                "PostFehler",
                "Beim Speichern ist ein unbekannter Fehler aufgetreten."
                );
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Activate()
        {
            edtVermieter.Focus();
        }

        public void Init(string titleName, Image titleImage, int baPersID)
        {
            // Maske einstellen
            picTitel.Image = titleImage;
            lblTitel.Text = titleName;
            _baPersonID = baPersID;

            // Daten f�llen
            qryBaWohnsituation.Fill(_baPersonID);
            if (qryBaWohnsituation.CanInsert && qryBaWohnsituation.Count == 0)
            {
                qryBaWohnsituation.Insert();
            }
        }

        #endregion

        #endregion
    }
}