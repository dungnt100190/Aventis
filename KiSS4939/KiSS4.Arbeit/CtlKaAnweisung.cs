using System;
using System.Data;
using System.Drawing;
using System.Reflection;

using log4net;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaAnweisung.
    /// </summary>
    public partial class CtlKaAnweisung : KissUserControl
    {
        #region Fields

        #region Private Static Fields

        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly string _defaultDeleteQuestion;

        #endregion

        #region Private Fields

        private int _baPersonID;
        private int _faLeistungID;
        private bool _mayIns;
        private bool _mayUpd;
        private bool _userIns;
        private bool _userUpd;

        #endregion

        #endregion

        #region Constructors

        public CtlKaAnweisung()
        {
            InitializeComponent();

            _defaultDeleteQuestion = qryEinsatz.DeleteQuestion;
        }

        #endregion

        #region Properties

        private bool IsEinsatzOhneAnweisung
        {
            get { return Utils.ConvertToInt(edtAnweisungstyp.EditValue) == (int)LOV.KaAnweisung.EinsatzOhneAnweisung; }
        }

        #endregion

        #region EventHandlers

        private void CtlKaAnweisung_Load(object sender, EventArgs e)
        {
            SetupRights();
            SetEditMode();

            qryEinsatz.EnableBoundFields();
        }

        private void LookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (qryEinsatz.IsFilling)
            {
                return;
            }

            SetEditMode();
        }

        private void btnALKasse_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DBUtil.IsEmpty(qryEinsatz[DBO.KaEinsatz.ALKasseID]))
                {
                    //((KissMainForm)Session.MainForm).ShowOrganisation(qryAnweisung["InstNr"].ToString().Replace(" ", ""));
                    FormController.OpenForm(
                        "FrmInstitutionenStamm", "Action", "ShowInstitutionKa", "InstitutionNr", qryEinsatz["InstNr"].ToString().Replace(" ", ""));
                }
            }
            catch (Exception ex)
            {
                _log.Debug(ex);
            }
        }

        private void btnZuweiserDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DBUtil.IsEmpty(qryEinsatz["ZuweiserName"]) && !DBUtil.IsEmpty(qryEinsatz["ZuweiserVorname"]))
                {
                    if (Convert.ToInt32(qryEinsatz[DBO.KaEinsatz.ZuweiserID]) < 0)
                    {
                        KissMsg.ShowInfo(
                            "CtlKaAnweisung",
                            "AnsichtDetailNichtErlaubt",
                            "Detail anschauen nicht erlaubt!\r\n\r\n(Benutzerverwaltung)");
                        //((KissMainForm)Session.MainForm).ShowBenutzer(Convert.ToInt32(qryAnweisung["ZuweiserID"]));
                    }
                    else
                    {
                        //((KissMainForm)Session.MainForm).ShowExterneBerater(qryAnweisung["ZuweiserName"].ToString(), qryAnweisung["ZuweiserVorname"].ToString());
                        FormController.OpenForm(
                            "FrmRavBerater",
                            "Action",
                            "ShowExterneBerater",
                            "ZuweiserName",
                            qryEinsatz["ZuweiserName"].ToString(),
                            "ZuweiserVorname",
                            qryEinsatz["ZuweiserVorname"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Debug(ex);
            }
        }

        private void dlgArbeitslosenkasse_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            using (var dlg = new DlgAuswahl())
            {
                if (dlg.ALKasseSuchen(edtArbeitslosenkasse.Text, e.ButtonClicked))
                {
                    qryEinsatz["ALKasse"] = dlg["InstitutionNr"] + ", " + dlg["Name"];
                    qryEinsatz[DBO.KaEinsatz.ALKasseID] = dlg["BaInstitutionID"];
                    edtArbeitslosenkasse.EditValue = dlg["InstitutionNr"] + ", " + dlg["Name"];
                    edtArbeitslosenkasse.LookupID = dlg["BaInstitutionID"];

                    // #5897: prevent direct posting as this can cause an error on F2 press
                    qryEinsatz.RowModified = true;
                    ////qryAnweisung.Post();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void dlgZuweiser_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            using (var dlg = new DlgAuswahl())
            {
                if (dlg.ZuweiserSuchen(edtZuweiser.Text, e.ButtonClicked))
                {
                    qryEinsatz["Zuweiser"] = dlg["FullName"];
                    qryEinsatz[DBO.KaEinsatz.ZuweiserID] = dlg["BeratID"];
                    qryEinsatz["ZuweiserName"] = dlg["Name"];
                    qryEinsatz["ZuweiserVorname"] = dlg["Vorname"];
                    edtZuweiser.EditValue = dlg["FullName"];
                    edtZuweiser.LookupID = dlg["BeratID"];

                    // #5897: prevent direct posting as this can cause an error on F2 press
                    qryEinsatz.RowModified = true;
                    ////qryAnweisung.Post();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void edtAnweisungstyp_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            qryEinsatz[DBO.KaEinsatz.AnweisungCode] = edtAnweisungstyp.EditValue;

            if (!IsEinsatzOhneAnweisung)
            {
                qryEinsatz[DBO.KaEinsatz.SamstagAktiv] = false;
                qryEinsatz[DBO.KaEinsatz.SonntagAktiv] = false;
            }
        }

        private void qryAnweisung_AfterDelete(object sender, EventArgs e)
        {
            try
            {
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void qryEinsatz_AfterInsert(object sender, EventArgs e)
        {
            qryEinsatz[DBO.KaEinsatz.BaPersonID] = _baPersonID;
            qryEinsatz[DBO.KaEinsatz.SichtbarSDFlag] = KaUtil.IsVisibleSD(_baPersonID);
        }

        private void qryEinsatz_AfterPost(object sender, EventArgs e)
        {
            // Used for resetting to the previous row after refilling the query
            var kaEinsatzId = qryEinsatz[DBO.KaEinsatz.KaEinsatzID];

            try
            {
                // When it is a "Zuweisung" do not fill KaArbeitsrapport
                if (Convert.ToInt32(edtAnweisungstyp.EditValue) != (int)LOV.KaAnweisung.Zuweisung)
                {
                    KaUtil.UpdateKaArbeitsRapportRecords((int)qryEinsatz["FaLeistungID"]);
                }

                FillAnweisung();
                Session.Commit();
            }
            catch (Exception exc)
            {
                Session.Rollback();
                KissMsg.ShowInfo(exc.Message);
                throw new KissCancelException();
            }

            qryEinsatz.Find(string.Format("{0}={1}", DBO.KaEinsatz.KaEinsatzID, kaEinsatzId));
        }

        private void qryEinsatz_BeforeDelete(object sender, EventArgs e)
        {
            Session.BeginTransaction();

            try
            {
                DBUtil.ExecSQLThrowingException(@"
                    DELETE
                    FROM dbo.KaArbeitsrapport
                    WHERE BaPersonID = {0}
                      AND KaEinsatzID = {1};", qryEinsatz[DBO.KaEinsatz.BaPersonID], qryEinsatz[DBO.KaEinsatz.KaEinsatzID]);

                DBUtil.ExecSQLThrowingException(@"
                    DELETE
                    FROM dbo.KaAmmBesch
                    WHERE KaEinsatzID = {0};", qryEinsatz[DBO.KaEinsatz.KaEinsatzID]);
            }
            catch (Exception ex)
            {
                Session.Rollback();

                // Eintrag ins Log.
                _log.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);
            }
        }

        private void qryEinsatz_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            qryEinsatz.DeleteQuestion = _defaultDeleteQuestion;

            // wurde die AMM-Bescheinigung bereits gedruckt?
            var istAmmGedruckt = DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT CASE WHEN EXISTS (SELECT TOP 1 1
                                         FROM dbo.KaAmmBesch AMM WITH (READUNCOMMITTED)
                                         WHERE AMM.KaEinsatzID = {0}
                                           AND AMM.gedrucktFlag = 1)
                              THEN CONVERT(BIT, 1)
                            ELSE CONVERT(BIT, 0)
                       END;", qryEinsatz[DBO.KaEinsatz.KaEinsatzID]) as bool? ?? false;

            if (istAmmGedruckt)
            {
                if (DBUtil.UserHasRight("CtlKaAnweisung_LoeschenTrotzAmmGedruckt"))
                {
                    // mit Spezialrecht kann die Anweisung trotzdem gelöscht werden
                    qryEinsatz.DeleteQuestion = KissMsg.GetMLMessage(
                        Name,
                        "qryAnweisung.DeleteQuestion_v1",
                        string.Format(
                            "Für diese Anweisung wurde bereits eine AMM-Bescheinigung gedruckt.{0}Soll sie trotzdem gelöscht werden?",
                            Environment.NewLine));
                }
                else
                {
                    // ohne Spezialrecht können Anweisungen die AMM-Gedruckt sind nicht gelöscht werden
                    KissMsg.ShowInfo(
                        Name,
                        "AnweisungTrotzAmmGedrucktNichtLoeschen_v1",
                        "Anweisungen, für die bereits eine AMM-Bescheinigung gedruckt wurde, können nicht gelöscht werden.");
                    throw new KissCancelException();
                }
            }
        }

        private void qryEinsatz_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtAnweisungstyp, lblAnweisungstyp.Text);
            DBUtil.CheckNotNullField(edtLeistung, lblLeistung.Text);
            DBUtil.CheckNotNullField(edtDatumVon, "Datum von");
            DBUtil.CheckNotNullField(edtDatumBis, "Datum bis");
            DBUtil.CheckNotNullField(edtBeschGrad, lblBeschGrad.Text);
            DBUtil.CheckNotNullField(edtAPVNr, lblAPVNr.Text);
            DBUtil.CheckNotNullField(edtZusatz, lblZusatz.Text);

            if (Convert.ToDateTime(edtDatumVon.EditValue) > Convert.ToDateTime(edtDatumBis.EditValue))
            {
                edtDatumBis.Focus();
                throw new KissInfoException("'Datum bis' darf nicht vor 'Datum von' liegen!");
            }

            var beschGrad = Convert.ToInt32(edtBeschGrad.EditValue);

            if (beschGrad > 100)
            {
                edtBeschGrad.Focus();
                throw new KissInfoException("Beschäftigungsgrad darf nicht grösser als 100% sein!");
            }

            if (qryEinsatz.Row.RowState == DataRowState.Added)
            {
                if (!InsertAllowed(Convert.ToDateTime(edtDatumVon.EditValue), Convert.ToDateTime(edtDatumBis.EditValue), -1))
                {
                    edtDatumVon.Focus();
                    throw new KissInfoException("Es existiert bereits eine An-/Zuweisung für dieses Datum!");
                }
            }
            else
            {
                if (
                    !InsertAllowed(
                        Convert.ToDateTime(edtDatumVon.EditValue),
                        Convert.ToDateTime(edtDatumBis.EditValue),
                        Convert.ToInt32(qryEinsatz["KaEinsatzID"])))
                {
                    edtDatumVon.Focus();
                    throw new KissInfoException("Es existiert bereits eine An-/Zuweisung für dieses Datum!");
                }

                // prüfen ob KaArbeitsrapport-Einträge vor dem neuen Datum vorhanden sind
                var datumVon = (DateTime)qryEinsatz["DatumVon"];
                var datumBis = (DateTime)qryEinsatz["DatumBis"];
                var hatArbeitsrapport = !DBUtil.IsEmpty(qryEinsatz["KaEinsatzID"]) &&
                                        KaUtil.WouldKaArbeitsRapportRecordsBeDeleted((int)qryEinsatz["KaEinsatzID"], datumVon, datumBis);

                // wenn ja, fragen ob die Daten gelöscht werden können
                if (hatArbeitsrapport)
                {
                    var answer = KissMsg.ShowQuestion(
                        Name,
                        "FrageZeiterfassungLoeschen",
                        "Es sind bereits Daten für die Präsenzzeiterfassung vor dem {0} oder nach dem {1} vorhanden." + Environment.NewLine +
                        "Wollen Sie diese Daten löschen?",
                        true,
                        datumVon.ToShortDateString(),
                        datumBis.ToShortDateString());

                    if (!answer)
                    {
                        throw new KissCancelException();
                    }
                }

                // prüfen ob KaArbeitsrapport-Einträge am Samstag oder Sonntag bestehen (welche bei deaktivieren des Samstags oder Sonntags gelöscht würden)
                hatArbeitsrapport = !DBUtil.IsEmpty(qryEinsatz["KaEinsatzID"]) &&
                                        KaUtil.WouldKaArbeitsRapportRecordsBeDeleted((int)qryEinsatz["KaEinsatzID"], chkSamstagAktiv.Checked, chkSonntagAktiv.Checked);
                // wenn ja, fragen ob die Daten gelöscht werden können
                if (hatArbeitsrapport)
                {
                    var answer = KissMsg.ShowQuestion(
                        Name,
                        "FrageSamstagSonntagZeiterfassungLoeschen",
                        "Es sind bereits Daten am Samstag oder Sonntag vorhanden." + Environment.NewLine +
                        "Wollen Sie diese Daten löschen?",
                        true);

                    if (!answer)
                    {
                        throw new KissCancelException();
                    }
                }
            }

            Session.BeginTransaction();
        }

        private void qryEinsatz_PositionChanged(object sender, EventArgs e)
        {
            FillLookupEditQueries();
            SetEditMode();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return _baPersonID;

                case "FALEISTUNGID":
                    return _faLeistungID;

                case "KAEINSATZID":
                    return qryEinsatz[DBO.KaEinsatz.KaEinsatzID];

            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int baPersonID, int faLeistungID)
        {
            lblTitel.Text = titleName;
            picTitle.Image = titleImage;
            _baPersonID = baPersonID;
            _faLeistungID = faLeistungID;

            FillAnweisung();

            FillLookupEditQueries();

            colZusatz.ColumnEdit = grdAnweisung.GetLOVLookUpEdit("KaApvZusatz");
            colAnweisungTyp.ColumnEdit = grdAnweisung.GetLOVLookUpEdit("KaAnweisung");
        }

        #endregion

        #region Private Methods

        private void FillAnweisung()
        {
            qryEinsatz.Fill(_baPersonID, Session.User.IsUserKA ? 0 : 1);
        }

        private void FillLookupEditQueries()
        {
            qryApvNr.Fill(qryEinsatz[DBO.KaEinsatz.KaEinsatzplatzID]);
            edtAPVNr.LoadQuery(qryApvNr);

            qryLeistung.Fill(qryEinsatz[DBO.KaEinsatz.FaLeistungID], _baPersonID);
            edtLeistung.LoadQuery(qryLeistung);
        }

        private bool InsertAllowed(DateTime dateFrom, DateTime dateTo, int einsatzID)
        {
            bool rslt;

            if (einsatzID == -1)
            {
                rslt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(1)
                    FROM dbo.KaEinsatz                                       KAE WITH (READUNCOMMITTED)
                      OUTER APPLY dbo.fnKaGetAustrittDatumCode(KAE.FaLeistungID, KAE.KaEinsatzID) FCN
                    WHERE KAE.BaPersonID = {0}
                      AND KAE.DatumVon <= {2}
                      AND CASE
                            WHEN FCN.AustrittDatum IS NULL THEN KAE.DatumBis
                            ELSE FCN.AustrittDatum
                          END > {1};", _baPersonID, dateFrom, dateTo)) == 0;
            }
            else
            {
                rslt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(1)
                    FROM dbo.KaEinsatz                                       KAE WITH (READUNCOMMITTED)
                      OUTER APPLY dbo.fnKaGetAustrittDatumCode(KAE.FaLeistungID, KAE.KaEinsatzID) FCN
                    WHERE KAE.BaPersonID = {0}
                      AND KAE.DatumVon <= {2}
                      AND CASE
                            WHEN FCN.AustrittDatum IS NULL THEN KAE.DatumBis
                            ELSE FCN.AustrittDatum
                          END > {1}
                      AND KAE.KaEinsatzID <> {3};", _baPersonID, dateFrom, dateTo, einsatzID)) == 0;
            }

            return rslt;
        }

        private void SetEditMode()
        {
            var editModeNormal = _userUpd && _mayUpd ? EditModeType.Normal : EditModeType.ReadOnly;
            var editModeRequired = _userUpd && _mayUpd ? EditModeType.Required : EditModeType.ReadOnly;

            // Leistung
            edtLeistung.EditMode = editModeRequired;

            // Zusatz
            var isZusatzSd = Utils.ConvertToInt(edtZusatz.EditValue) == 3; // SD
            edtRahmenfristBis.EditMode = isZusatzSd ? EditModeType.ReadOnly : editModeNormal;
            edtArbeitslosenkasse.EditMode = isZusatzSd ? EditModeType.ReadOnly : editModeNormal;

            //Checkboxen Sa + So nur editierbar für Anweisungstyp Einsatz ohne Anweisung
            chkSamstagAktiv.EditMode = IsEinsatzOhneAnweisung ? EditModeType.Normal : EditModeType.ReadOnly;
            chkSonntagAktiv.EditMode = chkSamstagAktiv.EditMode;

            edtAnweisungstyp.EditMode = editModeRequired;
            edtAPVNr.EditMode = editModeRequired;
            edtBeschGrad.EditMode = editModeRequired;
            edtDatumBis.EditMode = editModeRequired;
            edtDatumVon.EditMode = editModeRequired;
            edtPersonenNr.EditMode = editModeNormal;
            edtZusatz.EditMode = editModeRequired;
            edtZuweiser.EditMode = editModeNormal;
        }

        private void SetupRights()
        {
            _userUpd = DBUtil.UserHasRight("CtlKaAnweisung", "U");
            _userIns = DBUtil.UserHasRight("CtlKaAnweisung", "I");
            //_userDel = DBUtil.UserHasRight("CtlKaAnweisung", "D");

            bool unused;
            bool mayInsert;
            bool mayUpdate;

            DBUtil.GetFallRights(_faLeistungID, out unused, out mayInsert, out mayUpdate, out unused, out unused, out unused);

            _mayIns = mayInsert;
            _mayUpd = mayUpdate;

            // enable disable
            qryEinsatz.CanUpdate = _userUpd && _mayUpd;
            qryEinsatz.CanInsert = _userIns && _mayIns;

            qryEinsatz.EnableBoundFields();
        }

        #endregion

        #endregion
    }
}