using System;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Summary description for CtlFibuDauerauftrag.
    /// </summary>
    public partial class CtlFibuDauerauftrag : KissSearchUserControl
    {
        #region Enumerations

        /// <summary>
        /// LOV ZahlungsPeriode
        /// </summary>
        public enum Periodizitaet
        {
            Unbekannt = 0,
            Monatlich = 1,
            Zweimonatlich = 2,
            Vierteljaehrlich = 3,
            Halbjaehrlich = 4,
            Jaehrlich = 5,
            Zweiwoechentlich = 6,
            Woechentlich = 7
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFibuDauerauftrag"/> class.
        /// </summary>
        public CtlFibuDauerauftrag()
        {
            InitializeComponent();

            // HACK: Tabulator springt nicht aus einem KissLookUpEdit, wenn es nicht das letzte seiner Art ist..
            tabDauerauftrag.Controls.Add(new KissLookUpEdit { TabIndex = 999, TabStop = false, Visible = false });
        }

        #endregion

        #region EventHandlers

        private void btnDaAusfuehren_Click(object sender, EventArgs e)
        {
            if (qryFbDauerauftrag.Post())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    int eingefuegtenBuchungen = Convert.ToInt32(DBUtil.ExecuteScalarSQL("EXECUTE dbo.spFbDauerAuftragBuchungen {0}", Session.User.UserID));
                    qryFbDauerauftrag.Refresh();
                    Cursor = Cursors.Default;
                    KissMsg.ShowInfo("CtlFibuDauerauftrag", "EingefuegteBuchung", "Eingefügte Buchungen : {0}", 0, 0, eingefuegtenBuchungen);
                }
                catch (Exception g)
                {
                    KissMsg.ShowError("CtlFibuDauerauftrag", "FehlerStoredProcedure", "ein Fehler ist in stored procedure \"spFbDauerAuftragBuchungen\" aufgetreten", g.Message, g);
                }
            }
        }

        private void cboPeriodizitaet_EditValueChanged(object sender, EventArgs e)
        {
            Periodizitaet temp;

            if (edtPeriodizitaetCode.EditValue == DBNull.Value)
            {
                temp = Periodizitaet.Unbekannt;
            }
            else
            {
                temp = (Periodizitaet)Enum.Parse(typeof(Periodizitaet), edtPeriodizitaetCode.EditValue.ToString(), true);
            }

            SelectPeriodizitaetFields(temp);
        }

        private void CtlFibuDauerauftrag_Enter(object sender, EventArgs e)
        {
            qryFbDauerauftrag_PositionChanged(sender, e);
        }

        private void CtlFibuDauerauftrag_Load(object sender, EventArgs e)
        {
            SqlQuery qry = DBUtil.OpenSQL("SELECT Code = FbTeamID, Text = Name FROM FbTeam UNION SELECT NULL, NULL ORDER BY Text");
            edtTeamX.Properties.DataSource = qry;
            edtTeamX.Properties.DropDownRows = Math.Min(qry.Count, 7);

            colListeTeam.ColumnEdit = grdFbDauerauftrag.GetLOVLookUpEdit(qry);

            ctlFibuZahlungsWeg.DataSource = qryFbDauerauftrag;

            btnDaAusfuehren.Enabled = DBUtil.UserHasRight("FbAdministrator");
        }

        private void edtHabenKontoNr_UserModifiedFld(Object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();

            e.Cancel = !dlg.PeriodenKontoSuchen(
                edtHabenKontoNr.Text,
                lblMandantNr.Text,
                DateTime.Now,
                e.ButtonClicked);

            if (!e.Cancel)
            {
                qryFbDauerauftrag["HabenKtoNr"] = dlg["KontoNr"];
                qryFbDauerauftrag["HabenKtoName"] = dlg["KontoName"];
            }
        }

        private void edtMandant_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (String.IsNullOrEmpty(edtMandant.Text))
            {
                edtMandant.EditValue = null;
                edtMandant.LookupID = null;
                return;
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MandantSuchenB(edtMandant.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                qryFbDauerauftrag["BaPersonID"] = dlg["BaPersonID"];
                qryFbDauerauftrag["Mandant"] = dlg["Mandant"];
                qryFbDauerauftrag["PLZOrt"] = dlg["PLZOrt"];

                edtMandant.EditValue = dlg["Mandant"].ToString();
                edtMandant.LookupID = (int)dlg["BaPersonID"];
            }

            if (String.IsNullOrEmpty(edtMandant.Text))
            {
                edtSollKontoNr.EditMode = EditModeType.ReadOnly;
                edtSollKontoNr.Text = String.Empty;

                edtHabenKontoNr.EditMode = EditModeType.ReadOnly;
                edtHabenKontoNr.Text = String.Empty;
            }
            else
            {
                edtSollKontoNr.EditMode = EditModeType.Normal;
                edtSollKontoNr.Focus();
                edtHabenKontoNr.EditMode = EditModeType.Normal;
            }
        }

        private void edtMandantX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (String.IsNullOrEmpty(edtMandantX.Text))
            {
                //e.Cancel = true;
                edtMandantX.EditValue = null;
                edtMandantX.LookupID = null;
                return;
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MandantSuchenB(edtMandantX.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                edtMandantX.EditValue = dlg["Mandant"].ToString();
                edtMandantX.LookupID = (int)dlg["BaPersonID"];
            }
        }

        private void edtSollKontoNr_UserModifiedFld(Object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();

            //e.Cancel = !dlg.StandardKontoSuchen(edtSollKontoNr.Text, e.ButtonClicked, (int)KontoKlasse.Unbekannt);
            e.Cancel = !dlg.PeriodenKontoSuchen(
                edtSollKontoNr.Text,
                lblMandantNr.Text,
                DateTime.Now,
                e.ButtonClicked);

            if (!e.Cancel)
            {
                qryFbDauerauftrag["SollKtoNr"] = dlg["KontoNr"];
                qryFbDauerauftrag["SollKtoName"] = dlg["KontoName"];
            }
        }

        private void qryFbDauerauftrag_AfterInsert(Object sender, EventArgs e)
        {
            edtPeriodizitaetCode.EditMode = EditModeType.Normal;
            edtMonatstag1.EditMode = EditModeType.Normal;
            edtMonatstag2.EditMode = EditModeType.Normal;

            edtHabenKontoNr.EditMode = EditModeType.ReadOnly;
            edtSollKontoNr.EditMode = EditModeType.ReadOnly;

            qryFbDauerauftrag[DBO.FbDauerauftrag.VorWochenende] = true;

            edtMandant.Focus();
        }

        private void qryFbDauerauftrag_AfterPost(object sender, EventArgs e)
        {
            qryFbDauerauftrag["AuftragPeriodizitaet"] = edtPeriodizitaetCode.Text;
            qryFbDauerauftrag.Row.AcceptChanges();
        }

        private void qryFbDauerauftrag_BeforePost(Object sender, EventArgs e)
        {
            // returns a Exception if datas are not valid. If an Exception has been thrown, highlight XTabIndex 1 and threw Exception further

            DBUtil.CheckNotNullField(edtSollKontoNr, lblSoll.Text);
            DBUtil.CheckNotNullField(edtHabenKontoNr, lblHaben.Text);
            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);
            DBUtil.CheckNotNullField(edtText, lblText.Text);
            DBUtil.CheckNotNullField(edtDatumVon, lblGueltigVon.Text);
            DBUtil.CheckNotNullField(edtPeriodizitaetCode, lblPeriodizitaet.Text);

            //Monatstag1 nur prüfen, wenn nicht PeriodizitaetCode ungleich wöchentlich
            if ((Periodizitaet)Enum.Parse(typeof(Periodizitaet), qryFbDauerauftrag["PeriodizitaetCode"].ToString()) != Periodizitaet.Woechentlich)
            {
                DBUtil.CheckNotNullField(edtMonatstag1, lblMonatstag.Text);

                if (Convert.ToInt32(qryFbDauerauftrag["MonatsTag1"]) > 28)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuDauerauftrag", "MaxErsterMonatstag", "Der erste Monatstag darf höchstens der 28. sein", KissMsgCode.MsgInfo));
                }
            }

            DBUtil.CheckNotNullField(edtMandant, lblMandant.Text);

            if (!Utils.IsNatural(edtSollKontoNr.Text))
            {
                throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuDauerauftrag", "SollKtNumerisch", "SollKtoNr muss numerisch sein"));
            }

            if (!Utils.IsNatural(edtHabenKontoNr.Text))
            {
                throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuDauerauftrag", "HabenKtNumerisch", "HabenKtoNr muss numerisch sein"));
            }

            if (qryFbDauerauftrag["DatumBis"] != DBNull.Value)
            {
                if (Convert.ToDateTime(qryFbDauerauftrag["DatumBis"]) < Convert.ToDateTime(qryFbDauerauftrag["DatumVon"]))
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuDauerauftrag", "BisDatNachVonDat", "Gültig bis Datum muss nach dem Gültig von Datum liegen"));
                }
            }

            if ((Periodizitaet)Enum.Parse(typeof(Periodizitaet), qryFbDauerauftrag["PeriodizitaetCode"].ToString()) == Periodizitaet.Zweiwoechentlich)
            {
                if (DBUtil.IsEmpty(qryFbDauerauftrag["MonatsTag2"]))
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuDauerauftrag", "ZweiteMonatstagFehlt", "Der zweite Monatstag fehlt", KissMsgCode.MsgInfo));
                }

                if (Convert.ToInt32(qryFbDauerauftrag["MonatsTag2"]) > 28)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuDauerauftrag", "MaxZweiterMonatstag", "der zweite Monatstag darf höchstens der 28. sein", KissMsgCode.MsgInfo));
                }

                if (Convert.ToInt32(qryFbDauerauftrag["MonatsTag1"]) >= Convert.ToInt32(qryFbDauerauftrag["MonatsTag2"]))
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuDauerauftrag", "ErstMonatstagGroesserZweitMonatstag", "Der erste Monatstag darf nicht grösser als der zweite Monatstag sein", KissMsgCode.MsgInfo));
                }
            }
            else if ((Periodizitaet)Enum.Parse(typeof(Periodizitaet), qryFbDauerauftrag["PeriodizitaetCode"].ToString()) == Periodizitaet.Woechentlich)
            {
                qryFbDauerauftrag["MonatsTag1"] = DBNull.Value;
                qryFbDauerauftrag["MonatsTag2"] = DBNull.Value;
                if (DBUtil.IsEmpty(qryFbDauerauftrag["WochentagCode"]))
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuDauerauftrag", "WochentagFehlt", "Bei Periodizität 'wöchentlich' muss ein Wochentag gewählt werden", KissMsgCode.MsgInfo));
                }
            }
            else
            {
                qryFbDauerauftrag["MonatsTag2"] = DBNull.Value;
            }

            // Wochentag löschen wenn die Periodizität nicht wöchentlich ist
            if ((Periodizitaet)Enum.Parse(typeof(Periodizitaet), qryFbDauerauftrag["PeriodizitaetCode"].ToString()) != Periodizitaet.Woechentlich)
            {
                qryFbDauerauftrag[DBO.FbDauerauftrag.WochentagCode] = DBNull.Value;
            }

            // Set Default Status (Default Value on SqlServer Table doesn't work)
            qryFbDauerauftrag["Status"] = 1;
            qryFbDauerauftrag["AuftragStatus"] = "ok";

            try
            {
                ctlFibuZahlungsWeg.SaveNewKreditorAndZahlungsWeg();
            }
            catch (KissCancelException)
            {
                throw;
            }
            catch (Exception ex)
            {
                xTabControl2.SelectedTabIndex = 1;
                throw new KissErrorException(KissMsg.GetMLMessage(Name, "KreditorZahlungswegError", "Fehler beim Speichern des Zahlungswegs."), ex);
            }

            if (qryFbDauerauftrag["FbZahlungswegID"] == DBNull.Value)
            {
                throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuDauerauftrag", "ZahlungswegLeer_V02", "Der Zahlungsweg darf nicht leer bleiben !"));
            }
        }

        private void qryFbDauerauftrag_PositionChanged(object sender, EventArgs e)
        {
            if (qryFbDauerauftrag.IsFilling) return;

            if (!DBUtil.IsEmpty(qryFbDauerauftrag["FbDauerAuftragID"]))
            {
                edtPeriodizitaetCode.EditMode = EditModeType.ReadOnly;
                edtMonatstag1.EditMode = EditModeType.ReadOnly;
                edtMonatstag2.EditMode = EditModeType.ReadOnly;
                edtWochentag.EditMode = EditModeType.ReadOnly;
                chkVorWochenende.EditMode = EditModeType.ReadOnly;
            }

            ctlFibuZahlungsWeg.FbDauerAuftragId = qryFbDauerauftrag["FbDauerAuftragID"];
            ctlFibuZahlungsWeg.FbZahlungsWegId = qryFbDauerauftrag["FbZahlungswegID"];

            if (qryFbDauerauftrag.CanUpdate)
            {
                ctlFibuZahlungsWeg.UnlockControl();
            }
            else
            {
                ctlFibuZahlungsWeg.LockControl();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override string GetContextName()
        {
            return "VmFibu";
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    if (qryFbDauerauftrag.Count > 0)
                    {
                        return qryFbDauerauftrag["BaPersonID"];
                    }

                    return DBNull.Value;
            }
            return base.GetContextValue(fieldName);
        }

        #endregion

        #region Private Methods

        private void ResetEditModePeriodizitaet()
        {
            edtMonatstag1.EditMode = EditModeType.Normal;
            edtMonatstag2.EditMode = EditModeType.Normal;
            edtWochentag.EditMode = EditModeType.Normal;
            edtDatumBis.EditMode = EditModeType.Normal;
            chkVorWochenende.EditMode = EditModeType.Normal;
        }

        private void SelectPeriodizitaetFields(Periodizitaet periodizitaet)
        {
            ResetEditModePeriodizitaet();

            switch (periodizitaet)
            {
                case Periodizitaet.Jaehrlich:
                case Periodizitaet.Halbjaehrlich:
                case Periodizitaet.Vierteljaehrlich:
                case Periodizitaet.Zweimonatlich:
                case Periodizitaet.Monatlich:
                    panMonatstag.Visible = true;
                    panWochentagListe.Visible = false;
                    edtMonatstag1.EditMode = EditModeType.Required;
                    edtMonatstag2.EditMode = EditModeType.ReadOnly;
                    break;

                case Periodizitaet.Zweiwoechentlich:
                    panMonatstag.Visible = true;
                    panWochentagListe.Visible = false;
                    edtMonatstag1.EditMode = EditModeType.Required;
                    edtMonatstag2.EditMode = EditModeType.Required;
                    break;

                case Periodizitaet.Woechentlich:
                    panMonatstag.Visible = false;
                    panWochentagListe.Visible = true;
                    chkVorWochenende.EditMode = EditModeType.ReadOnly;
                    chkVorWochenende.Checked = false;
                    break;
            }
        }

        #endregion

        #endregion
    }
}