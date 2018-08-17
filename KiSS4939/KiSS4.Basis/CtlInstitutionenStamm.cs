using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Gui;
using SharpLibrary.WinControls;

namespace KiSS4.Basis
{
    public partial class CtlInstitutionenStamm : KissSearchUserControl
    {
        #region Enumerations

        private enum BaInstitutionArt
        {
            Institution = 1,
            Fachperson = 2
        }

        #endregion

        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// The document context for showing datasheet of institution
        /// </summary>
        private const string DOCCONTEXT_BA_INSTITUTIONFACHPERSON = "BA_InstitutionFachperson";

        private const string QRY_DOK_ADRESSAT = "Adressat";
        private const string QRY_DOK_VERFASSER = "Verfasser";
        private const string QRY_INST_LAND = "Land";
        private const string QRY_INST_PLZORT = "PLZOrt";
        private const string QRY_INST_STRASSENR = "StrasseNr";
        private const string QRY_INST_TYP_NAME_ML = "TypName";
        private readonly int _showBaInstitutionId;
        private bool _showDokumente;

        #endregion

        #endregion

        #region Constructors

        public CtlInstitutionenStamm(int showBaInstitutionId)
            : this()
        {
            _showBaInstitutionId = showBaInstitutionId;
        }

        public CtlInstitutionenStamm()
        {
            InitializeComponent();

            // set fill-timeout higher due to huge amount of data
            qryBaInstitution.FillTimeOut = 120; // 2min

            // go on
            SetDocumentContextOnInstitutionDatasheetDocButton(btnDatenblatt);

            tabInstitution.SelectedTabChanged += tabInstitution_SelectedTabChanged;
            tabInstitution.SelectedTabChanging += tabInstitution_SelectedTabChanging;
        }

        #endregion

        #region EventHandlers

        private void chkKontaktManuelleAnrede_CheckedChanged(object sender, EventArgs e)
        {
            ToggleManuelleAnrede(chkKontaktManuelleAnrede.Checked, edtKontaktAnrede, edtKontaktBriefanrede, edtKontaktGeschlecht);
        }

        private void chkManuelleAnrede_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManuelleAnrede.Visible)
            {
                ToggleManuelleAnrede(chkManuelleAnrede.Checked, edtAnrede, edtBriefanrede, edtGeschlecht);
            }
        }

        private void chkPostfachOhneNr_CheckedChanged(object sender, EventArgs e)
        {
            UtilsGui.TogglePostfachOhneNrEdit(chkPostfachOhneNr, edtPostfach, qryBaAdresse.CanUpdate);
        }

        private void CtlInstitutionenStamm_Load(object sender, EventArgs e)
        {
            SetupDataSource();
            SetupDataMember();
            SetupFieldName();
            SetupRequiredFields();
            SetupEntryTypeRadioButtonList();
            SetupOrgUnitLookupEdit();
            SetupRights();
            SetupTypenPickList();

            colArt.ColumnEdit = grdBaInstitution.GetLOVLookUpEdit("BaInstitutionArt");
            colDokumenteDienstleistung.ColumnEdit = grdBaInstitution.GetLOVLookUpEdit("BaInstitutionDokumentDienstleistung");
            colDokumenteKontaktart.ColumnEdit = grdBaInstitution.GetLOVLookUpEdit("BaInstitutionDokumentKontaktart");
            colDokumenteAufwand.ColumnEdit = grdBaInstitution.GetLOVLookUpEdit("FaDauer");

            qryBaAdresse.DeleteQuestion = "";

            qryBaInstitution.EnableBoundFields(false);
            qryBaAdresse.EnableBoundFields(false);

            if (_showBaInstitutionId != 0)
            {
                ShowInstitution(_showBaInstitutionId);
            }
            else
            {
                // start with search tpg
                NewSearch();
            }

            if (!_showDokumente)
            {
                tabInstitution.TabPages.Remove(tbpDokumente);
            }

            tabInstitution.SelectedTabIndex = 0;
            ctlZahlungsweg.IsZahlwegForInstitution = true;
            ctlZahlungsweg.BaInstitutionID = 0;
        }

        private void edtGeschlecht_EditValueChanged(object sender, EventArgs e)
        {
            ToggleManuelleAnrede(chkManuelleAnrede.Checked, edtAnrede, edtBriefanrede, edtGeschlecht);
        }

        private void edtKontaktGeschlecht_EditValueChanged(object sender, EventArgs e)
        {
            ToggleManuelleAnrede(chkKontaktManuelleAnrede.Checked, edtKontaktAnrede, edtKontaktBriefanrede, edtKontaktGeschlecht);
        }

        private void qryBaAdresse_AfterFill(object sender, EventArgs e)
        {
            InsertEmptyAddress();
        }

        private void qryBaAdresse_AfterInsert(object sender, EventArgs e)
        {
            qryBaAdresse[DBO.BaAdresse.DatumVon] = DateTime.Today;
            qryBaAdresse[DBO.BaAdresse.BaInstitutionID] = qryBaInstitution[DBO.BaInstitution.BaInstitutionID];
            qryBaAdresse.SetCreator();
        }

        private void qryBaAdresse_BeforePost(object sender, EventArgs e)
        {
            edtPLZOrt.DoValidate();
            ValidateAndSetBaInstitutionIdIfEmpty(qryBaAdresse, DBO.BaAdresse.BaInstitutionID);

            DBUtil.NewHistoryVersion();
            qryBaAdresse.SetModifierModified();
        }

        private void qryBaInstitution_AfterDelete(object sender, EventArgs e)
        {
            try
            {
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message, ex);
            }
        }

        private void qryBaInstitution_AfterFill(object sender, EventArgs e)
        {
            qryBaInstitution_PositionChanged(sender, null);
            lblRowCount.Text = qryBaInstitution.Count.ToString();
        }

        private void qryBaInstitution_AfterInsert(object sender, EventArgs e)
        {
            qryBaInstitution[DBO.BaInstitution.BaInstitutionArtCode] = Convert.ToInt32(BaInstitutionArt.Institution);
            qryBaInstitution.SetCreator();

            if (tabInstitution.SelectedTab == tbpInstitution)
            {
                edtInstName.Focus();
            }
        }

        private void qryBaInstitution_AfterPost(object sender, EventArgs e)
        {
            try
            {
                if (!qryBaAdresse.Post())
                {
                    throw new KissCancelException();
                }

                SaveInstititutionsTypen();

                if (!qryBaInstitutionKontakt.Post())
                {
                    throw new KissCancelException();
                }

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(Name, "ErrorAfterPostInstitutions_v01", "Es ist ein Fehler beim Speichern der Institution oder der abhängigen Daten aufgetreten. Die Änderungen wurden nicht gespeichert.\r\n\r\nMöglicherweise müssen Sie die Daten zuerst aktualisieren, bevor Sie weitere Änderungen durchführen.", ex);
            }
        }

        private void qryBaInstitution_BeforeDelete(object sender, EventArgs e)
        {
            Session.BeginTransaction();

            try
            {
                DBUtil.NewHistoryVersion();

                // delete all depending data first
                DBUtil.ExecSQLThrowingException(@"
                    DELETE dbo.BaAdresse
                    WHERE BaInstitutionID = {0};

                    DELETE dbo.BaInstitution_BaInstitutionTyp
                    WHERE BaInstitutionID = {0};

                    DELETE dbo.BaInstitutionKontakt
                    WHERE BaInstitutionID = {0};

                    DELETE dbo.BaZahlungsweg
                    WHERE BaInstitutionID = {0};", qryBaInstitution[DBO.BaInstitution.BaInstitutionID]);
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message, ex);
                throw new KissCancelException();
            }
        }

        private void qryBaInstitution_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            // check if entry is not in use already
            int countUsageIns = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT COUNT(1)
                FROM dbo.BaPerson_BaInstitution WITH (READUNCOMMITTED)
                WHERE BaInstitutionID = {0};", qryBaInstitution[DBO.BaInstitution.BaInstitutionID]));

            if (countUsageIns > 0)
            {
                // entry cannot be deleted because of usage
                KissMsg.ShowInfo(Name, "CannotDeleteInsEntry", "Diese Institution/Fachperson wird zurzeit verwendet und kann daher nicht gelöscht werden.\r\n\r\nVerwendung bei Personen: {0} Einträge.", 0, 0, countUsageIns);

                // cancel
                throw new KissCancelException();
            }
        }

        private void qryBaInstitution_BeforePost(object sender, EventArgs e)
        {
            CheckRequiredFieldsInCollection(panDetails.Controls);

            if (InstitutionWithSameAttributesAlreadyExists())
            {
                KissMsg.ShowInfo(Name, "InstitutionAlreadyExists", "Eine Institution mit den gewählten Angaben existiert bereits.");
                throw new KissCancelException();
            }

            // remove CRLF for Fachpersonen
            if (GetCurrentEntryType() == BaInstitutionArt.Fachperson &&
                !DBUtil.IsEmpty(qryBaInstitution[DBO.BaInstitution.Name]))
            {
                qryBaInstitution[DBO.BaInstitution.Name] = Convert.ToString(qryBaInstitution[DBO.BaInstitution.Name]).Replace(Environment.NewLine, " ").Trim();
            }

            qryBaInstitution.SetModifierModified();
            edtPLZOrt.DoValidate();

            // Warnung ausgeben, wenn Institution mit aktiven Kontaktpersonen deaktiviert wird
            if (qryBaInstitution.ColumnModified(DBO.BaInstitution.Aktiv) && !Utils.ConvertToBool(qryBaInstitution[DBO.BaInstitution.Aktiv]))
            {
                var anzahlAktiveKontakte = Utils.ConvertToInt(
                    DBUtil.ExecuteScalarSQL(@"
                        SELECT COUNT(1)
                        FROM dbo.BaInstitutionKontakt INK WITH (READUNCOMMITTED)
                        WHERE INK.BaInstitutionID = {0}
                          AND INK.Aktiv = 1;", qryBaInstitution[DBO.BaInstitution.BaInstitutionID]));

                if (anzahlAktiveKontakte > 0)
                {
                    KissMsg.ShowInfo(Name, "WarningActiveContacts", "Achtung: Es existieren noch aktive Kontaktpersonen.");
                }
            }

            // nothing more to do after BeginTransaction > no Try Catch required
            Session.BeginTransaction();
        }

        private void qryBaInstitution_PositionChanged(object sender, EventArgs e)
        {
            if (qryBaInstitution.Count == 0)
            {
                qryBaInstitutionKontakt.Fill(DBNull.Value, 0);
                qryBaAdresse.Fill(DBNull.Value);
            }
            else
            {
                ctlZahlungsweg.ActiveSQLQuery.Post();

                qryBaInstitutionKontakt.Fill(qryBaInstitution[DBO.BaInstitution.BaInstitutionID], chkSucheNurAktive.Checked);

                RefreshInstitutionsTypen();

                qryBaAdresse.Fill(qryBaInstitution[DBO.BaInstitution.BaInstitutionID]);

                if (qryBaInstitution[DBO.BaInstitution.BaInstitutionID] is int)
                {
                    ctlZahlungsweg.BaInstitutionID = Convert.ToInt32(qryBaInstitution[DBO.BaInstitution.BaInstitutionID]);
                }
                else
                {
                    ctlZahlungsweg.BaInstitutionID = 0;
                }

                if (_showDokumente)
                {
                    qryDokumente.Fill(qryBaInstitution[DBO.BaInstitution.BaInstitutionID]);
                }
            }

            tabInstitution.ShowIconUpdate();
        }

        private void qryBaInstitution_PositionChanging(object sender, EventArgs e)
        {
            // #4964: Datensatz nicht wechseln wenn nicht gespeichert werden kann
            if (!OnSaveData())
            {
                throw new KissCancelException();
            }
        }

        private void qryBaInstitution_PostCompleted(object sender, EventArgs e)
        {
            // apply changed texts to showonly columns
            qryBaInstitution[DBO.BaAdresse.Zusatz] = edtAdressZusatz.Text;
            qryBaInstitution[DBO.BaAdresse.Postfach] = PostfachText();
            qryBaInstitution[QRY_INST_STRASSENR] = (Utils.ConvertToString(edtStrasse.Text, "") + " " + Utils.ConvertToString(edtHausNr.Text, "")).Trim();
            qryBaInstitution[QRY_INST_PLZORT] = (Utils.ConvertToString(edtPLZOrt.PLZ, "") + " " + Utils.ConvertToString(edtPLZOrt.Ort, "")).Trim();
            qryBaInstitution[DBO.BaAdresse.PLZ] = edtPLZOrt.PLZ;
            qryBaInstitution[DBO.BaAdresse.Ort] = edtPLZOrt.Ort;
            qryBaInstitution[QRY_INST_LAND] = edtPLZOrt.EdtLand.Text;
            qryBaInstitution[DBO.XOrgUnit.ItemName] = edtAbteilung.Text;

            // prevent data changed (we did save data already)
            if (qryBaInstitution.Row != null)
            {
                qryBaInstitution.Row.AcceptChanges();
                qryBaInstitution.RowModified = false;
                qryBaInstitution.RefreshDisplay();
            }

            InsertEmptyAddress();
        }

        private void qryBaInstitutionKontakt_AfterInsert(object sender, EventArgs e)
        {
            qryBaInstitutionKontakt[DBO.BaInstitutionKontakt.BaInstitutionID] = qryBaInstitution[DBO.BaInstitution.BaInstitutionID];
            qryBaInstitutionKontakt[DBO.BaInstitutionKontakt.Aktiv] = true;

            qryBaInstitutionKontakt.SetCreator();

            edtKontaktName.Focus();
        }

        private void qryBaInstitutionKontakt_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            // check if entry is not in use already
            int countUsagePersonInstitution = 0;
            bool canDeleteKp = CanDeleteContactPerson(Convert.ToInt32(qryBaInstitutionKontakt[DBO.BaInstitutionKontakt.BaInstitutionKontaktID]),
                                                      ref countUsagePersonInstitution);

            if (!canDeleteKp)
            {
                // entry cannot be deleted because of usage
                KissMsg.ShowInfo(Name,
                                 "CannotDeleteKPEntry_v01",
                                 "Diese Kontaktperson wird zurzeit verwendet und kann daher nicht gelöscht werden.\r\n\r\nVerwendung bei Personen-Beziehungen: {0} Einträge.", 0, 0, countUsagePersonInstitution);

                // cancel
                throw new KissCancelException();
            }
        }

        private void qryBaInstitutionKontakt_BeforePost(object sender, EventArgs e)
        {
            ValidateAndSetBaInstitutionIdIfEmpty(qryBaInstitutionKontakt, DBO.BaInstitutionKontakt.BaInstitutionID);

            CheckRequiredFieldsInCollection(tbpKontakt.Controls);
            qryBaInstitutionKontakt.SetModifierModified();
        }

        private void qryDokumente_AfterFill(object sender, EventArgs e)
        {
            grvDokumente.BestFitColumns();
        }

        private void qryDokumente_AfterInsert(object sender, EventArgs e)
        {
            qryDokumente[DBO.BaInstitutionDokument.BaInstitutionID] = qryBaInstitution[DBO.BaInstitution.BaInstitutionID];
            edtDokumentDatum.Focus();
        }

        private void qryDokumente_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDokumentVerfasser, lblDokumentVerfasser.Text);
            ValidateAndSetBaInstitutionIdIfEmpty(qryDokumente, DBO.BaInstitutionDokument.BaInstitutionID);
        }

        private void qryZugeordneteInstTypen_AfterInsert(object sender, EventArgs e)
        {
            qryZugeordneteInstTypen[DBO.BaInstitution_BaInstitutionTyp.BaInstitutionID] = qryBaInstitution[DBO.BaInstitution.BaInstitutionID];
            qryZugeordneteInstTypen.SetCreator();
        }

        private void qryZugeordneteInstTypen_BeforePost(object sender, EventArgs e)
        {
            ValidateAndSetBaInstitutionIdIfEmpty(qryZugeordneteInstTypen, DBO.BaInstitution_BaInstitutionTyp.BaInstitutionID);
            qryZugeordneteInstTypen.SetModifierModified();
        }

        private void rgrItemTyp_EditValueChanged(object sender, EventArgs e)
        {
            SwitchBetweenDataEntryTypes();
        }

        private void tabControlSearch_SizeChanged(object sender, EventArgs e)
        {
            PositionLabelAnzahlEintraege();
        }

        private void tabInstitution_SelectedTabChanged(TabPageEx page)
        {
            if (page == tbpZahlweg)
            {
                if (qryBaInstitution[DBO.BaInstitution.BaInstitutionID] is int)
                {
                    ctlZahlungsweg.BaInstitutionID = Convert.ToInt32(qryBaInstitution[DBO.BaInstitution.BaInstitutionID]);
                }
                else
                {
                    ctlZahlungsweg.BaInstitutionID = 0;
                }
            }
        }

        private void tabInstitution_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            if (!OnSaveData())
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Checks if contact person can be deleted
        /// </summary>
        /// <param name="baInstitutionKontaktId">The id of the contact person to check</param>
        /// <returns><c>True</c> if contact person can be deleted, otherwise <c>False</c></returns>
        public static bool CanDeleteContactPerson(int baInstitutionKontaktId)
        {
            int countUsagePersonInstitution = 0;
            return CanDeleteContactPerson(baInstitutionKontaktId, ref countUsagePersonInstitution);
        }

        /// <summary>
        /// Checks if contact person can be deleted
        /// </summary>
        /// <param name="baInstitutionKontaktId">The id of the contact person to check</param>
        /// <param name="countUsagePersonInstitution">Returns usage count in person-institution relations</param>
        /// <returns><c>True</c> if contact person can be deleted, otherwise <c>False</c></returns>
        public static bool CanDeleteContactPerson(int baInstitutionKontaktId, ref int countUsagePersonInstitution)
        {
            // check if entry is not in use already
            countUsagePersonInstitution = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT COUNT(1)
                FROM dbo.BaPerson_BaInstitution WITH (READUNCOMMITTED)
                WHERE BaInstitutionKontaktID = {0};", baInstitutionKontaktId));

            return (countUsagePersonInstitution < 1);
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///  Diese Funktion ist für die Dokumentgeneriereung;
        ///  Eruieren von Kontextwerten.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public override object GetContextValue(string fieldName)
        {
            object res; //Einfacher zum debuggen, darum eigene lokale Variable.
            if ("INSTITUTIONID".Equals(fieldName.ToUpper()))
            {
                res = qryBaInstitution[DBO.BaInstitution.BaInstitutionID];
            }
            else
            {
                res = base.GetContextValue(fieldName);
            }
            return res;
        }

        public override bool OnAddData()
        {
            // check active tpg, can only add data if on Liste-tpg
            if (tabControlSearch.IsTabSelected(tpgSuchen))
            {
                return false;
            }

            // if user is on Typisierung tpg, we switch to institution
            // as we cannot assign any type to a new institution without saving first
            if (tabInstitution.IsTabSelected(tbpTypisierung))
            {
                tabInstitution.SelectTab(tbpInstitution);
            }

            bool result;

            try
            {
                ActiveSQLQuery = GetRelevantSqlQueryForCurrentTab();
                result = base.OnAddData();
            }
            finally
            {
                ActiveSQLQuery = qryBaInstitution;
            }

            return result;
        }

        public override bool OnDeleteData()
        {
            bool result;

            try
            {
                ActiveSQLQuery = GetRelevantSqlQueryForCurrentTab();
                result = base.OnDeleteData();
            }
            finally
            {
                ActiveSQLQuery = qryBaInstitution;
            }

            return result;
        }

        public override void OnRefreshData()
        {
            if (!OnSaveData())
            {
                return;
            }

            try
            {
                ActiveSQLQuery = GetRelevantSqlQueryForCurrentTab();
                base.OnRefreshData();
            }
            finally
            {
                ActiveSQLQuery = qryBaInstitution;
            }
        }

        public override bool OnSaveData()
        {
            // check current tpg to prevent message before changing tpg to list
            if (tabControlSearch.IsTabSelected(tpgSuchen))
            {
                SqlQuery qry = GetRelevantSqlQueryForCurrentTab();

                if (qry != null && qry.Row != null)
                {
                    // discard changes (such as trim data)
                    qry.RowModified = false;
                    qry.Row.AcceptChanges();
                }

                // no changes
                return true;
            }

            bool result;

            try
            {
                ActiveSQLQuery = GetRelevantSqlQueryForCurrentTab();

                if (ActiveSQLQuery == qryBaInstitution)
                {
                    // end edit on qryBaInstitution and qryBaAdresse to have data saved even if not moved focus
                    qryBaInstitution.EndCurrentEdit();
                    qryBaAdresse.EndCurrentEdit();

                    if (qryBaAdresse.RowModified)
                    {
                        // set row modified in qryBaInstitution to have address saved (see qryBaInstitution_AfterPost)
                        qryBaInstitution.RowModified = true;
                    }
                }

                result = base.OnSaveData();
            }
            finally
            {
                ActiveSQLQuery = qryBaInstitution;
            }

            return result;
        }

        public override void OnUndoDataChanges()
        {
            try
            {
                ActiveSQLQuery = GetRelevantSqlQueryForCurrentTab();
                base.OnUndoDataChanges();
            }
            finally
            {
                ActiveSQLQuery = qryBaInstitution;
            }
        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (parameters["Action"] as string)
            {
                case "ShowInstitution":
                case "JumpToPath":
                    // either no id is given (just open form) or show was successfull
                    return DBUtil.IsEmpty(parameters["BaInstitutionID"]) || ShowInstitution(Convert.ToInt32(parameters["BaInstitutionID"]));

                case "ShowInstitutionKa":
                    OnNewSearch(); // HACK: required because NewSearch won't reset other search controls
                    NewSearch();

                    edtInstitutionNrX.EditValue = parameters["InstitutionNr"].ToString();

                    tabControlSearch.SelectTab(tpgListe);
                    return true;
            }

            // did not understand message
            return false;
        }

        public override object ReturnMessage(HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters.Count < 1)
            {
                // by default, nothing to do
                return null;
            }

            // action depending
            switch (parameters["Action"] as string)
            {
                case "GetJumpToPath":
                    var dic = new HybridDictionary();
                    dic["ClassName"] = "FrmInstitutionenStamm";
                    dic["BaInstitutionID"] = qryBaInstitution["BaInstitutionID"];
                    return dic;
            }

            // did not understand message
            return base.ReturnMessage(parameters);
        }

        public void SetFocusNewSearch()
        {
            // set focus to search4name control as this probably is the most used one
            edtNameX.Focus();
        }

        /// <summary>
        /// Search and show institution with given ID (active or inactive doesn't matter) if possible
        /// </summary>
        /// <param name="baInstitutionId">The id of the institution</param>
        /// <returns><c>True</c> if institution could be searched, otherwise <c>False</c></returns>
        public bool ShowInstitution(int baInstitutionId)
        {
            // save changes first
            if (!OnSaveData())
            {
                return false;
            }

            // reset and start a new search
            OnNewSearch(); // HACK: required because NewSearch won't reset other search controls
            NewSearch();

            // apply id to search and show institution even if inactive
            edtSucheBaInstitutionId.EditValue = baInstitutionId;
            chkSucheNurAktive.Checked = false;

            tabControlSearch.SelectTab(tpgListe);

            return true;
        }

        public override void Translate()
        {
            base.Translate();

            string typName = Utils.GetOrgUnitTypNameForInstitutionsTypen();

            if (!string.IsNullOrEmpty(typName))
            {
                lblAbteilung.Text = typName;
                lblSucheOrgEinheit.Text = typName;
                colAbteilung.Caption = typName;
            }
        }

        #endregion

        #region Internal Static Methods

        /// <summary>
        /// Set context name for institution-datasheet document button
        /// </summary>
        /// <param name="btnDatasheet">The button which has to get the context</param>
        internal static void SetDocumentContextOnInstitutionDatasheetDocButton(KissDocumentButton btnDatasheet)
        {
            btnDatasheet.Context = DOCCONTEXT_BA_INSTITUTIONFACHPERSON;
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            pklSucheInstTypen.UnselectAll();
            chkSucheNurAktive.Checked = true;

            SetFocusNewSearch();
        }

        protected override void RunSearch()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                qryBaInstitution.Fill(Session.User.UserID, Session.User.LanguageCode);
                lblRowCount.Text = qryBaInstitution.Count.ToString();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #region Private Static Methods

        private static void CheckRequiredFieldsInCollection(ICollection controls)
        {
            foreach (Control control in controls)
            {
                var kissEditable = control as IKissEditable;

                if (control.Visible && kissEditable != null && kissEditable.EditMode == EditModeType.Required)
                {
                    var bindableEdit = control as IKissBindableEdit;

                    if (bindableEdit != null)
                    {
                        string editText = control.Tag != null ? control.Tag.ToString() : bindableEdit.DataMember;
                        DBUtil.CheckNotNullField(bindableEdit, editText);
                    }
                }
            }
        }

        private static BaInstitutionArt GetEntryType(int? selectedIndex)
        {
            if (!selectedIndex.HasValue)
            {
                return BaInstitutionArt.Institution;
            }

            return (BaInstitutionArt)selectedIndex.Value;
        }

        #endregion

        #region Private Methods

        private BaInstitutionArt GetCurrentEntryType()
        {
            return GetEntryType(rgrItemTyp.EditValue as int?);
        }

        private SqlQuery GetRelevantSqlQueryForCurrentTab()
        {
            SqlQuery relevantQuery = null;

            TabPageEx page = tabInstitution.SelectedTab;

            if (page == tbpKontakt)
            {
                relevantQuery = qryBaInstitutionKontakt;
            }
            else if (page == tbpZahlweg)
            {
                // set focus to zahlweg control to apply action there (but leave default query)
                ctlZahlungsweg.Focus();
            }
            else if (page == tbpDokumente)
            {
                relevantQuery = qryDokumente;
            }

            // apply default query if not changed above
            return relevantQuery ?? qryBaInstitution;
        }

        private SqlQuery InitAndReturnQuerySucheSelectedInstTypen()
        {
            DataTable selectedTypesTable = qrySucheSelectedInstTypen.DataSet.Tables[0];
            selectedTypesTable.Columns.Add(DBO.BaInstitutionTyp.BaInstitutionTypID, typeof(int));
            selectedTypesTable.Columns.Add(QRY_INST_TYP_NAME_ML, typeof(string));

            return qrySucheSelectedInstTypen;
        }

        private void InsertEmptyAddress()
        {
            if (qryBaAdresse.CanUpdate && qryBaAdresse.Count == 0)
            {
                qryBaAdresse.Insert(qryBaAdresse.TableName);
            }
        }

        private bool InstitutionWithSameAttributesAlreadyExists()
        {
            var whereClause = new StringBuilder();
            var currentInstId = qryBaInstitution[DBO.BaInstitution.BaInstitutionID] as int?;

            if (!currentInstId.HasValue)
            {
                currentInstId = -1;
            }

            whereClause.AppendFormat("INS.BaInstitutionID <> {0} ", DBUtil.SqlLiteral(currentInstId.Value));
            whereClause.AppendLine();

            if (Convert.ToInt32(rgrItemTyp.EditValue) == Convert.ToInt32(BaInstitutionArt.Fachperson))
            {
                whereClause.AppendFormat("AND INS.Vorname = {0} ", DBUtil.SqlLiteral(edtVorname.Text));
                whereClause.AppendLine();
                whereClause.AppendFormat("AND INS.Name = {0} ", DBUtil.SqlLiteral(edtPersonName.Text));
                whereClause.AppendLine();
            }
            else
            {
                whereClause.AppendFormat("AND INS.Name = {0} ", DBUtil.SqlLiteral(edtInstName.Text));
                whereClause.AppendLine();
            }

            whereClause.AppendFormat("AND ISNULL(ADR.Zusatz, '') = {0} ", DBUtil.SqlLiteral(edtAdressZusatz.Text));
            whereClause.AppendLine();

            whereClause.AppendFormat("AND ISNULL(ADR.Strasse, '') = {0} ", DBUtil.SqlLiteral(edtStrasse.Text));
            whereClause.AppendLine();

            whereClause.AppendFormat("AND ISNULL(ADR.HausNr, '') = {0} ", DBUtil.SqlLiteral(edtHausNr.Text));
            whereClause.AppendLine();

            whereClause.AppendFormat("AND ISNULL(ADR.PLZ, '') = {0} ", DBUtil.SqlLiteral(edtPLZOrt.PLZ));
            whereClause.AppendLine();

            // OrgUnit-Filter (if any defined > only main)
            int orgUnitTypCode = DBUtil.GetConfigInt(@"System\Basis\OrgEinheitTypFuerInstTypen", -1);

            if (orgUnitTypCode > -1 && !DBUtil.IsEmpty(edtAbteilung.EditValue))
            {
                // if orgunit-filter is defined and orgunit is assigned, check is only active for given orgunit
                whereClause.AppendFormat("AND ISNULL(INS.OrgUnitID, -99) = {0} ", DBUtil.SqlLiteral(edtAbteilung.EditValue));
                whereClause.AppendLine();
            }

            var existsInstitution = DBUtil.ExecuteScalarSQL(string.Format(@"
                --SQLCHECK_IGNORE--
                SELECT ISNULL((SELECT TOP 1 1
                               FROM dbo.BaInstitution INS
                                 INNER JOIN BaAdresse ADR ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaInstitutionID', INS.BaInstitutionID, 1, NULL)
                               WHERE {0}), 0);", whereClause)) as int?;

            return existsInstitution.HasValue ? Convert.ToBoolean(existsInstitution.Value) : false;
        }

        private void PositionLabelAnzahlEintraege()
        {
            lblAnzDatensaetze.Location = new Point(tabControlSearch.Location.X + tabControlSearch.Width - (lblAnzDatensaetze.Width + lblRowCount.Width + lblRowCount.Margin.Right), tabControlSearch.Location.Y + tabControlSearch.Height - (lblAnzDatensaetze.Height + lblAnzDatensaetze.Margin.Bottom));
            lblRowCount.Location = new Point(tabControlSearch.Location.X + tabControlSearch.Width - (lblRowCount.Width + lblRowCount.Margin.Right), tabControlSearch.Location.Y + tabControlSearch.Height - (lblRowCount.Height + lblRowCount.Margin.Bottom));
        }

        private string PostfachText()
        {
            if (string.IsNullOrEmpty(edtPostfach.Text) && !chkPostfachOhneNr.Checked)
            {
                return null;
            }

            return chkPostfachOhneNr.Checked ? lblPostfach.Text : string.Format("{0} {1}", lblPostfach.Text, edtPostfach.Text);
        }

        private void RefreshInstitutionsTypen()
        {
            // PickList code
            qryZugeordneteInstTypen.Fill(Session.User.UserID, Session.User.LanguageCode, qryBaInstitution[DBO.BaInstitution.BaInstitutionID]);
            pklInstTypen.Refresh();
            //-- PickList code End --
        }

        private void SaveInstititutionsTypen()
        {
            DBUtil.ExecSQLThrowingException(@"
                DECLARE @BaInstitutionID INT;
                DECLARE @CreatorModifier VARCHAR(50);
                DECLARE @IdsString VARCHAR(255);
                DECLARE @UserID INT;

                SET @BaInstitutionID = {0};
                SET @CreatorModifier = {1};
                SET @IdsString = {2};
                SET @UserID = {3};

                -- delete only the assigned types the user is allowed to see
                DELETE IIT
                FROM dbo.BaInstitution_BaInstitutionTyp IIT
                  INNER JOIN dbo.BaInstitutionTyp       ITY ON ITY.BaInstitutionTypID = IIT.BaInstitutionTypID
                                                           AND (ITY.OrgUnitID IS NULL OR ITY.OrgUnitID IN (SELECT ORG.OrgUnitID
                                                                                                           FROM dbo.fnGetInstStammUserORGList(@UserID) ORG)) -- only types the user is allowed to see
                WHERE IIT.BaInstitutionID = @BaInstitutionID;

                -- insert only the types the user can see in UI
                INSERT INTO dbo.BaInstitution_BaInstitutionTyp (BaInstitutionID, BaInstitutionTypID, Creator, Modifier)
                  SELECT BaInstitutionID    = @BaInstitutionID,
                         BaInstitutionTypID = CONVERT(INT, FNC.SplitValue),
                         Creator            = @CreatorModifier,
                         Modifier           = @CreatorModifier
                  FROM dbo.fnSplitStringToValues(@IdsString, ',', 1) FNC;", qryBaInstitution[DBO.BaInstitution.BaInstitutionID],
                                                                            DBUtil.GetDBRowCreatorModifier(),
                                                                            pklInstTypen.SelectedIds,
                                                                            Session.User.UserID);
        }

        private void SetFieldVisibilityForDetails(bool isInstitution)
        {
            lblVorname.Visible = !isInstitution;
            edtPersonName.Visible = !isInstitution;
            edtVorname.Visible = !isInstitution;
            lblAnrede.Visible = !isInstitution;
            edtAnrede.Visible = !isInstitution;
            lblTitel.Visible = !isInstitution;
            edtTitel.Visible = !isInstitution;
            lblBriefanrede.Visible = !isInstitution;
            edtBriefanrede.Visible = !isInstitution;
            lblGeschlecht.Visible = !isInstitution;
            edtGeschlecht.Visible = !isInstitution;
            chkManuelleAnrede.Visible = !isInstitution;
            lblGeburtsdatum.Visible = !isInstitution;
            edtGeburtsdatum.Visible = !isInstitution;
            lblVersichertennummer.Visible = !isInstitution;
            edtVersichertennummer.Visible = !isInstitution;

            edtInstName.Visible = isInstitution;
        }

        private void SetupDataMember()
        {
            rgrItemTyp.DataMember = DBO.BaInstitution.BaInstitutionArtCode;

            chkPostfachOhneNr.DataMember = DBO.BaAdresse.PostfachOhneNr;
            edtAdressZusatz.DataMember = DBO.BaAdresse.Zusatz;
            edtPLZOrt.DataMemberBezirk = DBO.BaAdresse.Bezirk;
            edtHausNr.DataMember = DBO.BaAdresse.HausNr;
            edtPLZOrt.DataMemberKanton = DBO.BaAdresse.Kanton;
            edtPLZOrt.DataMemberLand = DBO.BaAdresse.BaLandID;
            edtPLZOrt.DataMemberOrt = DBO.BaAdresse.Ort;
            edtPLZOrt.DataMemberPLZ = DBO.BaAdresse.PLZ;
            edtPLZOrt.DataMember = DBO.BaAdresse.OrtschaftCode;
            edtPostfach.DataMember = DBO.BaAdresse.Postfach;
            edtStrasse.DataMember = DBO.BaAdresse.Strasse;

            chkManuelleAnrede.DataMember = DBO.BaInstitution.ManuelleAnrede;
            chkKeinSerienbrief.DataMember = DBO.BaInstitution.KeinSerienbrief;
            edtAbteilung.DataMember = DBO.BaInstitution.OrgUnitID;
            edtAktiv.DataMember = DBO.BaInstitution.Aktiv;
            edtAnrede.DataMember = DBO.BaInstitution.Anrede;
            edtBemerkung.DataMember = DBO.BaInstitution.Bemerkung;
            edtBriefanrede.DataMember = DBO.BaInstitution.Briefanrede;
            edtDebitor.DataMember = DBO.BaInstitution.Debitor;
            edtEMail.DataMember = DBO.BaInstitution.EMail;
            edtFax.DataMember = DBO.BaInstitution.Fax;
            edtGeschlecht.DataMember = DBO.BaInstitution.GeschlechtCode;
            edtHomepage.DataMember = DBO.BaInstitution.Homepage;
            edtInstitutionNr.DataMember = DBO.BaInstitution.InstitutionNr;
            edtInstName.DataMember = DBO.BaInstitution.Name;
            edtKreditor.DataMember = DBO.BaInstitution.Kreditor;
            edtPersonName.DataMember = DBO.BaInstitution.Name;
            edtSprachCode.DataMember = DBO.BaInstitution.SprachCode;
            edtTelefon1.DataMember = DBO.BaInstitution.Telefon;
            edtTelefon2.DataMember = DBO.BaInstitution.Telefon2;
            edtTelefon3.DataMember = DBO.BaInstitution.Telefon3;
            edtTitel.DataMember = DBO.BaInstitution.Titel;
            edtVorname.DataMember = DBO.BaInstitution.Vorname;
            edtGeburtsdatum.DataMember = DBO.BaInstitution.Geburtsdatum;
            edtVersichertennummer.DataMember = DBO.BaInstitution.Versichertennummer;

            chkKontaktAktiv.DataMember = DBO.BaInstitutionKontakt.Aktiv;
            chkKontaktManuelleAnrede.DataMember = DBO.BaInstitutionKontakt.ManuelleAnrede;
            edtKontaktAnrede.DataMember = DBO.BaInstitutionKontakt.Anrede;
            edtKontaktBemerkung.DataMember = DBO.BaInstitutionKontakt.Bemerkung;
            edtKontaktBriefanrede.DataMember = DBO.BaInstitutionKontakt.Briefanrede;
            edtKontaktEMail.DataMember = DBO.BaInstitutionKontakt.EMail;
            edtKontaktFax.DataMember = DBO.BaInstitutionKontakt.Fax;
            edtKontaktGeschlecht.DataMember = DBO.BaInstitutionKontakt.GeschlechtCode;
            edtKontaktName.DataMember = DBO.BaInstitutionKontakt.Name;
            edtKontaktSprachCode.DataMember = DBO.BaInstitutionKontakt.SprachCode;
            edtKontaktTelefon.DataMember = DBO.BaInstitutionKontakt.Telefon;
            edtKontaktTitel.DataMember = DBO.BaInstitutionKontakt.Titel;
            edtKontaktVorname.DataMember = DBO.BaInstitutionKontakt.Vorname;

            edtDokumentAdressat.DataMember = QRY_DOK_ADRESSAT;
            edtDokumentAdressat.DataMemberBaInstitution = DBO.BaInstitutionDokument.BaInstitutionID_Adressat;
            edtDokumentAdressat.DataMemberBaPerson = DBO.BaInstitutionDokument.BaPersonID_Adressat;
            edtDokumentDatum.DataMember = DBO.BaInstitutionDokument.Datum;
            edtDokumentDauer.DataMember = DBO.BaInstitutionDokument.FaDauerCode;
            edtDokumentDienstleistung.DataMember = DBO.BaInstitutionDokument.BaInstitutionDokumentDienstleistungCode;
            edtDokumentInhalt.DataMember = DBO.BaInstitutionDokument.Inhalt;
            edtDokumentKontaktart.DataMember = DBO.BaInstitutionDokument.BaInstitutionDokumentKontaktartCode;
            edtDokumentStichwort.DataMember = DBO.BaInstitutionDokument.Stichwort;
            edtDokumentVerfasser.DataMember = QRY_DOK_VERFASSER;
            edtDokumentVerfasser.DataMemberUserId = DBO.BaInstitutionDokument.UserID;
            docDokument.DataMember = DBO.BaInstitutionDokument.DocumentID;
        }

        private void SetupDataSource()
        {
            rgrItemTyp.DataSource = qryBaInstitution;

            chkPostfachOhneNr.DataSource = qryBaAdresse;
            edtAdressZusatz.DataSource = qryBaAdresse;
            edtPLZOrt.DataSource = qryBaAdresse;
            edtHausNr.DataSource = qryBaAdresse;
            edtPostfach.DataSource = qryBaAdresse;
            edtStrasse.DataSource = qryBaAdresse;

            chkManuelleAnrede.DataSource = qryBaInstitution;
            chkKeinSerienbrief.DataSource = qryBaInstitution;
            edtAbteilung.DataSource = qryBaInstitution;
            edtAktiv.DataSource = qryBaInstitution;
            edtAnrede.DataSource = qryBaInstitution;
            edtBemerkung.DataSource = qryBaInstitution;
            edtBriefanrede.DataSource = qryBaInstitution;
            edtDebitor.DataSource = qryBaInstitution;
            edtEMail.DataSource = qryBaInstitution;
            edtFax.DataSource = qryBaInstitution;
            edtGeschlecht.DataSource = qryBaInstitution;
            edtHomepage.DataSource = qryBaInstitution;
            edtInstitutionNr.DataSource = qryBaInstitution;
            edtInstName.DataSource = qryBaInstitution;
            edtKreditor.DataSource = qryBaInstitution;
            edtPersonName.DataSource = qryBaInstitution;
            edtSprachCode.DataSource = qryBaInstitution;
            edtTelefon1.DataSource = qryBaInstitution;
            edtTelefon2.DataSource = qryBaInstitution;
            edtTelefon3.DataSource = qryBaInstitution;
            edtTitel.DataSource = qryBaInstitution;
            edtVorname.DataSource = qryBaInstitution;
            edtGeburtsdatum.DataSource = qryBaInstitution;
            edtVersichertennummer.DataSource = qryBaInstitution;

            chkKontaktAktiv.DataSource = qryBaInstitutionKontakt;
            chkKontaktManuelleAnrede.DataSource = qryBaInstitutionKontakt;
            edtKontaktAnrede.DataSource = qryBaInstitutionKontakt;
            edtKontaktBemerkung.DataSource = qryBaInstitutionKontakt;
            edtKontaktBriefanrede.DataSource = qryBaInstitutionKontakt;
            edtKontaktEMail.DataSource = qryBaInstitutionKontakt;
            edtKontaktFax.DataSource = qryBaInstitutionKontakt;
            edtKontaktGeschlecht.DataSource = qryBaInstitutionKontakt;
            edtKontaktName.DataSource = qryBaInstitutionKontakt;
            edtKontaktSprachCode.DataSource = qryBaInstitutionKontakt;
            edtKontaktTelefon.DataSource = qryBaInstitutionKontakt;
            edtKontaktTitel.DataSource = qryBaInstitutionKontakt;
            edtKontaktVorname.DataSource = qryBaInstitutionKontakt;

            edtDokumentAdressat.DataSource = qryDokumente;
            edtDokumentDatum.DataSource = qryDokumente;
            edtDokumentDauer.DataSource = qryDokumente;
            edtDokumentDienstleistung.DataSource = qryDokumente;
            edtDokumentInhalt.DataSource = qryDokumente;
            edtDokumentKontaktart.DataSource = qryDokumente;
            edtDokumentStichwort.DataSource = qryDokumente;
            edtDokumentVerfasser.DataSource = qryDokumente;
            docDokument.DataSource = qryDokumente;
        }

        private void SetupEntryTypeRadioButtonList()
        {
            SqlQuery qryLov = DBUtil.GetLOVQuery("BaInstitutionArt", false);

            foreach (DataRow row in qryLov.DataSet.Tables[0].Rows)
            {
                rgrItemTyp.Properties.Items.Add(new RadioGroupItem(row["Code"], row["Text"].ToString()));
            }

            rgrItemTyp.EditValue = Convert.ToInt32(BaInstitutionArt.Institution);
        }

        private void SetupFieldName()
        {
            colKontaktEMail.FieldName = DBO.BaInstitutionKontakt.EMail;
            colKontaktName.FieldName = DBO.BaInstitutionKontakt.Name;
            colKontaktTelefon.FieldName = DBO.BaInstitutionKontakt.Telefon;
            colKontaktVorname.FieldName = DBO.BaInstitutionKontakt.Vorname;

            colAbteilung.FieldName = DBO.XOrgUnit.ItemName;
            colAktiv.FieldName = DBO.BaInstitution.Aktiv;
            colBemerkungen.FieldName = DBO.BaInstitution.Bemerkung;
            colEMail.FieldName = DBO.BaInstitution.EMail;
            colFax.FieldName = DBO.BaInstitution.Fax;
            colLand.FieldName = QRY_INST_LAND;
            colName.FieldName = DBO.BaInstitution.Name;
            colInstitutionVorname.FieldName = DBO.BaInstitution.Vorname;
            colNr.FieldName = DBO.BaInstitution.BaInstitutionID;
            colOrt.FieldName = DBO.BaAdresse.Ort;
            colPLZ.FieldName = DBO.BaAdresse.PLZ;
            colPostfach.FieldName = DBO.BaAdresse.Postfach;
            colStrasse.FieldName = QRY_INST_STRASSENR;
            colTelefon.FieldName = DBO.BaInstitution.Telefon;
            colTitel.FieldName = DBO.BaInstitution.Titel;
            colTyp.FieldName = "Typen";
            colZusatz.FieldName = DBO.BaAdresse.Zusatz;
            colArt.FieldName = DBO.BaInstitution.BaInstitutionArtCode;

            colDokumenteAdressat.FieldName = QRY_DOK_ADRESSAT;
            colDokumenteAufwand.FieldName = DBO.BaInstitutionDokument.FaDauerCode;
            colDokumenteDatum.FieldName = DBO.BaInstitutionDokument.Datum;
            colDokumenteDienstleistung.FieldName = DBO.BaInstitutionDokument.BaInstitutionDokumentDienstleistungCode;
            colDokumenteKontaktart.FieldName = DBO.BaInstitutionDokument.BaInstitutionDokumentKontaktartCode;
            colDokumenteStichwort.FieldName = DBO.BaInstitutionDokument.Stichwort;
            colDokumenteVerfasser.FieldName = QRY_DOK_VERFASSER;
        }

        private void SetupOrgUnitLookupEdit()
        {
            SqlQuery qryOrgUnit = DBUtil.OpenSQL(@"
                SELECT [Code] = NULL,
                       [Text] = ''

                UNION

                SELECT [Code] = OrgUnitID,
                       [Text] = ItemName
                FROM dbo.fnGetInstStammUserORGList({0})
                ORDER BY [Text];", Session.User.UserID);

            edtAbteilung.LoadQuery(qryOrgUnit);
            edtSucheOrgEinheit.LoadQuery(qryOrgUnit);
        }

        private void SetupRequiredFields()
        {
            // Institutionen/Fachpersonen
            UtilsGui.SetRequiredIfCanUpdate(edtPersonName);
            edtPersonName.Tag = lblName.Text;

            UtilsGui.SetRequiredIfCanUpdate(edtGeschlecht);
            edtGeschlecht.Tag = lblGeschlecht.Text;

            UtilsGui.SetRequiredIfCanUpdate(edtInstName);
            edtInstName.Tag = lblName.Text;

            edtAnrede.Tag = lblAnrede.Text;
            edtBriefanrede.Tag = lblBriefanrede.Text;

            if (DBUtil.GetConfigBool(@"System\Basis\AbteilungAufInstAlsMussfeld", false))
            {
                UtilsGui.SetRequiredIfCanUpdate(edtAbteilung);
                edtAbteilung.Tag = lblAbteilung.Text;
            }

            // Kontaktpersonen
            UtilsGui.SetRequiredIfCanUpdate(edtKontaktName);
            edtKontaktName.Tag = lblKontaktPersonName.Text;

            UtilsGui.SetRequiredIfCanUpdate(edtKontaktGeschlecht);
            edtKontaktGeschlecht.Tag = lblKontaktGeschlecht.Text;

            edtKontaktAnrede.Tag = lblKontaktAnrede.Text;
            edtKontaktBriefanrede.Tag = lblKontaktBriefanrede.Text;
        }

        private void SetupRights()
        {
            bool canRead;
            bool canInsert;
            bool canUpdate;
            bool canDelete;

            Session.GetUserRight(Name, out canRead, out canInsert, out canUpdate, out canDelete);

            qryZugeordneteInstTypen.CanInsert = canInsert;
            qryZugeordneteInstTypen.CanUpdate = canUpdate;
            qryZugeordneteInstTypen.CanDelete = canDelete;

            qryDokumente.CanInsert = canInsert;
            qryDokumente.CanUpdate = canUpdate;
            qryDokumente.CanDelete = canDelete;

            _showDokumente = DBUtil.UserHasRight("BAInstitutionDokumente");
        }

        private void SetupTypenPickList()
        {
            // Suche PickList
            qrySucheInstTypen.Fill(Session.User.UserID, Session.User.LanguageCode);
            pklSucheInstTypen.ColumnIDName = DBO.BaInstitutionTyp.BaInstitutionTypID;
            pklSucheInstTypen.FilterColumnName = QRY_INST_TYP_NAME_ML;
            pklSucheInstTypen.ColumnsByFieldNameAndCaptionForSourceGrid = new Dictionary<string, string> { { QRY_INST_TYP_NAME_ML, KissMsg.GetMLMessage(Name, "InstTypenAuswahlHeaderSuche", "Typen") } };
            pklSucheInstTypen.DataSourceOfSourceGrid = qrySucheInstTypen;
            pklSucheInstTypen.ColumnsByFieldNameAndCaptionForTargetGrid = new Dictionary<string, string> { { QRY_INST_TYP_NAME_ML, KissMsg.GetMLMessage(Name, "InstTypenAusgewaehltHeaderSuche", "Ausgewählte Typen") } };
            pklSucheInstTypen.DataSourceOfTargetGrid = InitAndReturnQuerySucheSelectedInstTypen(); //qrySucheSelectedInstTypen;

            // Typen PickList
            qryInstTypen.Fill(Session.User.UserID, Session.User.LanguageCode);
            pklInstTypen.ColumnIDName = DBO.BaInstitutionTyp.BaInstitutionTypID;
            pklInstTypen.FilterColumnName = QRY_INST_TYP_NAME_ML;
            pklInstTypen.ColumnsByFieldNameAndCaptionForSourceGrid = new Dictionary<string, string> { { QRY_INST_TYP_NAME_ML, KissMsg.GetMLMessage(Name, "InstTypenAuswahlHeader", "Typen-Auswahl") } };
            pklInstTypen.DataSourceOfSourceGrid = qryInstTypen;
            pklInstTypen.ColumnsByFieldNameAndCaptionForTargetGrid = new Dictionary<string, string> { { QRY_INST_TYP_NAME_ML, KissMsg.GetMLMessage(Name, "InstTypenAusgewaehltHeader", "Ausgewählte Typen") } };
            pklInstTypen.DataSourceOfTargetGrid = qryZugeordneteInstTypen;
        }

        private void SwitchBetweenDataEntryTypes()
        {
            int entryType = Convert.ToInt32(GetCurrentEntryType());

            switch (entryType)
            {
                case 1: // Institution
                    SetFieldVisibilityForDetails(true);
                    break;

                case 2: // Fachperson
                    SetFieldVisibilityForDetails(false);
                    ToggleManuelleAnrede(chkManuelleAnrede.Checked, edtAnrede, edtBriefanrede, edtGeschlecht);
                    break;
            }
        }

        private void ToggleManuelleAnrede(bool isManuelleAnrede, KissTextEdit anredeEdit, KissTextEdit briefanredeEdit, KissLookUpEdit geschlechtEdit)
        {
            var geschlechtCode = geschlechtEdit.EditValue as int?;

            UtilsGui.ToggleManuelleAnredeTextFields(
                isManuelleAnrede,
                anredeEdit,
                briefanredeEdit,
                null,
                geschlechtCode.HasValue ? geschlechtCode.Value : 0);
        }

        /// <summary>
        /// Check if reference BaInstitutionID is set. If not, validate and apply BaInstitutionID, otherwise leave it.
        /// </summary>
        /// <param name="qryToApply">The query to apply the BaInstitutionID</param>
        /// <param name="columnName">The column name of the query to use for BaInstitutionID</param>
        /// <exception cref="KissCancelException">Thrown in case of invalid BaInsitutionID on <see cref="qryBaInstitution"/> if reference is empty</exception>
        private void ValidateAndSetBaInstitutionIdIfEmpty(SqlQuery qryToApply, string columnName)
        {
            // check if we need to set an institution-id
            if (DBUtil.IsEmpty(qryToApply[columnName]))
            {
                // validate BaInstitutionID
                if (DBUtil.IsEmpty(qryBaInstitution[DBO.BaInstitution.BaInstitutionID]))
                {
                    throw new KissCancelException(KissMsg.GetMLMessage(Name,
                                                                       "EmptyReferenceBaInstID",
                                                                       "Die benötigte Referenz-ID der Institution ist leer. Die Daten können nicht gespeichert werden."));
                }

                // apply BaInstitutionID
                qryToApply[columnName] = qryBaInstitution[DBO.BaInstitution.BaInstitutionID];
            }
        }

        #endregion

        #endregion
    }
}