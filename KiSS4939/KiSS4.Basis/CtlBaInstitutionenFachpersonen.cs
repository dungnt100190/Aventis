using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis
{
    public partial class CtlBaInstitutionenFachpersonen : KissUserControl
    {
        #region Fields

        #region Private Static Fields

        private static readonly string _btnDlgAbbrechen = KissMsg.GetMLMessage(CLASSNAME, "BtnAbbrechen", "&Abbrechen");
        private static readonly string _btnDlgInstFachperson = KissMsg.GetMLMessage(CLASSNAME, "BtnInstFachperson", "&Institution, Fachperson");
        private static readonly string _btnDlgKontaktperson = KissMsg.GetMLMessage(CLASSNAME, "BtnKontaktperson", "&Kontaktperson");

        #endregion

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlBaInstitutionenFachpersonen";
        private const string DELETEKPTAG = "deletekp";
        private const string DIALOGINSTITUTIONNAMECONFIG = @"System\Basis\InstitutionFachpersonDialogSucheVariante";
        private const string INSERTKPTAG = "insertkp";

        #endregion

        #region Private Fields

        private int _baPersonID = -1;
        private bool _preventSavingChanges;

        #endregion

        #endregion

        #region Constructors

        public CtlBaInstitutionenFachpersonen()
        {
            InitializeComponent();

            // Translate string from designer code
            qryBaInstitutionKontakt.DeleteQuestion = KissMsg.GetMLMessage(CLASSNAME, "KontaktpersonLoeschenFrage", "Soll die gewählte Kontaktperson gelöscht werden?");

            // setup context
            CtlInstitutionenStamm.SetDocumentContextOnInstitutionDatasheetDocButton(btnDatenblatt);

            // setup button-tags for later handling
            if (edtKontaktperson.Properties.Buttons.Count > 2)
            {
                edtKontaktperson.Properties.Buttons[1].Tag = INSERTKPTAG;
                edtKontaktperson.Properties.Buttons[2].Tag = DELETEKPTAG;
            }

            // init with default values
            Init(null, null, -1);
        }

        #endregion

        #region EventHandlers

        private void btnGotoInsitution_Click(object sender, EventArgs e)
        {
            // validate
            if (qryBaPersonInstitution.IsEmpty)
            {
                return;
            }

            // open Institutionenstamm and select current institution
            FormController.OpenForm("FrmInstitutionenStamm",
                                    "Action", "ShowInstitution",
                                    "BaInstitutionID", qryBaPersonInstitution[DBO.BaPerson_BaInstitution.BaInstitutionID]);
        }

        private void chkKontaktManuelleAnrede_CheckedChanged(object sender, EventArgs e)
        {
            var geschlechtCode = edtKontaktGeschlecht.EditValue as int?;
            UtilsGui.ToggleManuelleAnredeTextFields(chkKontaktManuelleAnrede.Checked, edtKontaktAnrede, edtKontaktBriefanrede, null, geschlechtCode);
        }

        private void CtlBaInstitutionenFachpersonen_Load(object sender, EventArgs e)
        {
            // select last row
            qryBaPersonInstitution.Last();

            // select first tab
            tabInstitution.SelectTab(tpgAdresse);
        }

        private void CtlBaInstitutionenFachpersonen_VisibleChanged(object sender, EventArgs e)
        {
            // HACK: due to an unknown bug, the gridview will only change if visible...
            SetupGridViews();
        }

        private void edtBetrifftPerson_EditValueChanged(object sender, EventArgs e)
        {
            // check if user can modify data
            if (qryBaPersonInstitution.CanUpdate)
            {
                // check if user selected any person to enable/disable relation field
                edtBeziehungZuPerson.EditMode = DBUtil.IsEmpty(edtBetrifftPerson.EditValue) ? EditModeType.ReadOnly : EditModeType.Normal;
            }
        }

        private void edtInstitutionName_EditValueChanged(object sender, EventArgs e)
        {
            // set data has changed (needed for validation)
        }

        private void edtInstitutionName_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogInstitutionName(sender, e);
        }

        private void edtKontaktGeschlecht_EditValueChanged(object sender, EventArgs e)
        {
            UtilsGui.ToggleManuelleAnredeTextFields(chkKontaktManuelleAnrede.Checked, edtKontaktAnrede, edtKontaktBriefanrede, null, edtKontaktGeschlecht.EditValue as int?);
        }

        private void edtKontaktperson_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            // validate
            if (e == null || e.Button == null)
            {
                // do nothing
                return;
            }

            string buttonTag = Convert.ToString(e.Button.Tag);

            // check tag to identify action
            if (buttonTag == INSERTKPTAG)
            {
                AddNewContactPerson();
            }
            else if (buttonTag == DELETEKPTAG)
            {
                // prevalidate and confirm
                if ((!DBUtil.IsEmpty(edtKontaktperson.EditValue) || IsAddingNewContactPerson()) &&
                    KissMsg.ShowQuestion(qryBaInstitutionKontakt.DeleteQuestion, true))
                {
                    DeleteContactPerson();
                }
            }
        }

        private void edtKontaktperson_EditValueChanged(object sender, EventArgs e)
        {
            int? baInstitutionKontaktId = edtKontaktperson.EditValue as int?;

            if (baInstitutionKontaktId.HasValue)
            {
                FillKontaktpersonData(baInstitutionKontaktId.Value);
                UtilsGui.ToggleManuelleAnredeTextFields(chkKontaktManuelleAnrede.Checked, edtKontaktAnrede, edtKontaktBriefanrede, null, edtKontaktGeschlecht.EditValue as int?);
            }
            else
            {
                FillKontaktpersonData(-1);
            }
        }

        private void edtKontaktperson_EditValueChanging(object sender, ChangingEventArgs e)
        {
            // prevent saving on inserting new row in query!
            if (PreventSavingChanges() || PreventCheckingAndSavingOnInserts())
            {
                // do nothing
                return;
            }

            // check if need to save changes first
            if ((!DBUtil.IsEmpty(edtKontaktperson.EditValue) || (IsAddingNewContactPerson() && qryBaInstitutionKontakt.RowModified)) &&
                !OnSaveData())
            {
                // prevent changing entry if not saved properly
                e.Cancel = true;
            }
        }

        private void qryBaInstitutionKontakt_AfterInsert(object sender, EventArgs e)
        {
            // validate and apply current BaInstitutionID
            var baInstitutionId = GetCurrentBaInstitutionID();

            if (!baInstitutionId.HasValue || baInstitutionId.Value < 1)
            {
                throw new KissErrorException("Error: No institution selected, cannot create new contact person.");
            }

            qryBaInstitutionKontakt[DBO.BaInstitutionKontakt.BaInstitutionID] = baInstitutionId.Value;
            qryBaInstitutionKontakt[DBO.BaInstitutionKontakt.Aktiv] = true;
            qryBaInstitutionKontakt.SetCreator();
        }

        private void qryBaInstitutionKontakt_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            // check if entry is not in use already
            var countUsagePersonInstitution = 0;
            var canDeleteKp = CtlInstitutionenStamm.CanDeleteContactPerson(Convert.ToInt32(qryBaInstitutionKontakt[DBO.BaInstitutionKontakt.BaInstitutionKontaktID]),
                                                                            ref countUsagePersonInstitution);

            if (!canDeleteKp)
            {
                // entry cannot be deleted because of usage
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "CannotDeleteKPEntry_v01",
                    "Diese Kontaktperson wird zurzeit verwendet und kann daher nicht gelöscht werden.\r\n\r\nVerwendung bei Personen-Beziehungen: {0} Einträge.",
                    0, 0, countUsagePersonInstitution);

                // cancel
                throw new KissCancelException();
            }
        }

        private void qryBaInstitutionKontakt_BeforePost(object sender, EventArgs e)
        {
            CheckRequiredFieldsInCollection(UtilsGui.AllControls(tpgKontakt));
            qryBaInstitutionKontakt.SetModifierModified();
        }

        private void qryBaInstitutionKontakt_PostCompleted(object sender, EventArgs e)
        {
            UpdateInstitutionDataAndContactPersons();

            // set editvalue to activate new created person
            if (DBUtil.IsEmpty(edtKontaktperson.EditValue))
            {
                edtKontaktperson.EditValue = qryBaInstitutionKontakt[DBO.BaInstitutionKontakt.BaInstitutionKontaktID];
            }
        }

        private void qryBaPersonInstitution_AfterInsert(object sender, EventArgs e)
        {
            // default values
            qryBaPersonInstitution[DBO.BaPerson_BaInstitution.BaPersonID] = _baPersonID;
            qryBaPersonInstitution.SetCreator();

            // focus
            edtInstitutionName.Focus();
        }

        private void qryBaPersonInstitution_AfterPost(object sender, EventArgs e)
        {
            try
            {
                if (!qryBaInstitutionKontakt.Post())
                {
                    throw new KissCancelException();
                }

                Session.Commit();

                // apply fields
                qryBaPersonInstitution["BetrifftBaPerson"] = edtBetrifftPerson.Text;
                qryBaPersonInstitution["BeziehungZuPerson"] = edtBeziehungZuPerson.Text;
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message, ex);
            }
        }

        private void qryBaPersonInstitution_BeforePost(object sender, EventArgs e)
        {
            // validate must fields
            DBUtil.CheckNotNullField(edtInstitutionName, lblInstitutionFachperson.Text);
            DBUtil.CheckNotNullField(edtBetrifftPerson, lblBetrifftPerson.Text);

            qryBaPersonInstitution.SetModifierModified();
            Session.BeginTransaction();
            try
            {
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message, ex);
                throw new KissCancelException();
            }
        }

        private void qryBaPersonInstitution_PositionChanged(object sender, EventArgs e)
        {
            UpdateInstitutionDataAndContactPersons();
            SetupGridViews();
        }

        private void qryBaPersonInstitution_PositionChanging(object sender, EventArgs e)
        {
            // cannot change row if not saved successfully
            if (!OnSaveData())
            {
                throw new KissCancelException();
            }
        }

        private void tabInstitution_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // HACK: due to an unknown bug, the gridview will only change if visible...
            SetupGridViews();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        ///  Diese Funktion ist für die Dokumentgeneriereung;
        ///  Eruieren von Kontextwerden.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public override object GetContextValue(string fieldName)
        {
            object res; //Einfacher zum debuggen, darum eigene lokale Variable.
            if ("OWNERUSERID".Equals(fieldName.ToUpper()))
            {
                res = DBUtil.ExecuteScalarSQL(@"
                    SELECT  TOP 1 UserID
                    FROM dbo.FaLeistung LEI
                    WHERE
                        LEI.BaPersonID = {0}
                        AND LEI.ModulID = 2 -- F Leistung
                        AND LEI.DatumVon <= GETDATE()
                        AND (LEI.DatumBis IS NULL OR LEI.DatumBis >= GETDATE())
                    ORDER BY LEI.DatumVon DESC	", _baPersonID);
            }
            else if ("INSTITUTIONID".Equals(fieldName.ToUpper()))
            {
                res = qryInstitution[DBO.BaInstitution.BaInstitutionID];
            }
            else
            {
                res = base.GetContextValue(fieldName);
            }
            return res;
        }

        public void Init(string titleName, Image titleImage, int baPersonID)
        {
            // handle rights
            SetupRights();

            // validate
            if (baPersonID < 1)
            {
                // do not continue
                qryBaPersonInstitution.CanInsert = false;
                qryBaPersonInstitution.CanUpdate = false;
                qryBaPersonInstitution.CanDelete = false;

                qryBaInstitutionKontakt.CanInsert = false;
                qryBaInstitutionKontakt.CanUpdate = false;
                qryBaInstitutionKontakt.CanDelete = false;

                // handle editmode of controls
                qryBaPersonInstitution.EnableBoundFields(qryBaPersonInstitution.CanUpdate);
                qryBaInstitutionKontakt.EnableBoundFields(qryBaInstitutionKontakt.CanUpdate);
                return;
            }

            // apply values
            picTitel.Image = titleImage;
            lblTitel.Text = titleName;
            _baPersonID = baPersonID;

            SetupDataMember();
            SetupDataSource();
            SetupFieldNames();

            SetupRequiredFields();

            //alle Personen im Klientensystem von BaPersonID
            SqlQuery qryPersonen = DBUtil.OpenSQL(string.Format(@"
                SELECT Code = BaPersonID_2,
                       Text = PRS.Name + ISNULL(', ' + PRS.Vorname, '')
                FROM dbo.BaPerson_Relation BRE WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = BRE.BaPersonID_2
                WHERE BRE.BaPersonID_1 = {0}

                UNION

                SELECT Code = BaPersonID_1,
                       Text = PRS.Name + ISNULL(', ' + PRS.Vorname, '')
                FROM dbo.BaPerson_Relation BRE WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = BRE.BaPersonID_1
                WHERE BRE.BaPersonID_2 = {0}

                UNION

                SELECT Code = BaPersonID,
                       Text = PRS.Name + ISNULL(', ' + PRS.Vorname, '')
                FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
                WHERE PRS.BaPersonID = {0}
                ORDER BY 2;", baPersonID));

            // fill dropdown for persons
            edtBetrifftPerson.Properties.DataSource = qryPersonen;

            SqlQuery qryBeziehungTyp = DBUtil.OpenSQL(string.Format(@"
                DECLARE @LanguageCode INT;
                SET @LanguageCode = {0};

                SELECT [Code] = NULL,
                       [Text] = ''

                UNION ALL

                SELECT [Code] = ITY.BaInstitutionTypID,
                       [Text] = dbo.fnGetMLTextByDefault(ITY.NameTID, @LanguageCode, ITY.Name)
                FROM dbo.BaInstitutionTyp ITY
                WHERE ITY.OrgUnitID IS NULL    -- show only global entries
                ORDER BY [Text], [Code];
                ", Session.User.LanguageCode));

            edtBeziehungZuPerson.LoadQuery(qryBeziehungTyp);

            // fill data
            qryBaPersonInstitution.Fill(@"
                DECLARE @BaPersonID INT;
                DECLARE @LanguageCode INT;

                SET @BaPersonID = {0};
                SET @LanguageCode = {1};

                SELECT BPI.*,
                       --
                       INS.NameVorname,
                       PLZOrtStrasseNr   = ISNULL(INS.PLZOrt, '') + ISNULL(', ' + INS.StrasseHausNr, ''),
                       BetrifftBaPerson  = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
                       BeziehungZuPerson = dbo.fnGetMLTextByDefault(ITY.NameTID, @LanguageCode, ITY.Name)
                FROM dbo.BaPerson_BaInstitution   BPI WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BaPerson         PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = BPI.BaPersonID
                  INNER JOIN dbo.vwInstitution    INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = BPI.BaInstitutionID
                  LEFT  JOIN dbo.BaInstitutionTyp ITY WITH (READUNCOMMITTED) ON ITY.BaInstitutionTypID = BPI.BaInstitutionTypID
                WHERE BPI.BaPersonID IN
                    (SELECT REL.BaPersonID_2
                    FROM dbo.BaPerson_Relation REL WITH (READUNCOMMITTED)
                    WHERE REL.BaPersonID_1 = @BaPersonID

                    UNION

                    SELECT REL.BaPersonID_1
                    FROM dbo.BaPerson_Relation REL WITH (READUNCOMMITTED)
                    WHERE REL.BaPersonID_2 = @BaPersonID

                    UNION

                    SELECT @BaPersonID)
                ORDER BY INS.Name ASC;", baPersonID, Session.User.LanguageCode);

            // select last row
            qryBaPersonInstitution.Last();

            // insert new entry if not yet any entry found
            if (qryBaPersonInstitution.CanInsert && qryBaPersonInstitution.Count < 1)
            {
                ////qryBaPersonInstitution.Insert(null);
            }

            // update fields
            qryBaPersonInstitution.EnableBoundFields();
            qryBaInstitutionKontakt.EnableBoundFields();
        }

        public override bool OnAddData()
        {
            // depending on current tpg, we add data on main query or ask the user for the action
            if (tabInstitution.IsTabSelected(tpgKontakt) &&
                qryBaInstitutionKontakt.CanInsert &&
                HasValidInstitutionForAddingContactPerson())
            {
                string[] buttonList = { _btnDlgInstFachperson, _btnDlgKontaktperson, _btnDlgAbbrechen };

                string msgQuestion = KissMsg.GetMLMessage(
                    CLASSNAME,
                    "QuestionAddNew",
                    "Wollen Sie eine neue Beziehung zu einer Institution, Fachperson oder eine neue Kontaktperson hinzufügen?");

                int indexDlgBtn = KissMsg.ShowButtonDlg(msgQuestion, buttonList, Messages.DlgButtonPositionModes.dpmAutomatic, 0);

                switch (indexDlgBtn)
                {
                    case 1:
                        // add new contact person
                        return AddNewContactPerson();

                    case 2:
                        // cancel
                        throw new KissCancelException();
                }
            }

            // insert on main query > person-institution
            return base.OnAddData();
        }

        public override bool OnDeleteData()
        {
            // flag to prevent double delete question
            bool confirmedDelete = false;

            // depending on current tpg, we delete data on main query or ask the user for the action
            if (tabInstitution.IsTabSelected(tpgKontakt) &&
                qryBaInstitutionKontakt.CanDelete &&
                (!DBUtil.IsEmpty(qryBaInstitutionKontakt[DBO.BaPerson_BaInstitution.BaInstitutionKontaktID]) || IsAddingNewContactPerson()))
            {
                string[] buttonList = { _btnDlgInstFachperson, _btnDlgKontaktperson, _btnDlgAbbrechen };

                string msgQuestion = KissMsg.GetMLMessage(
                    CLASSNAME,
                    "QuestionDeleteEntry",
                    "Wollen Sie die Beziehung zu einer Institution, Fachperson oder die zugewiesene Kontaktperson löschen?");

                int indexDlgBtn = KissMsg.ShowButtonDlg(msgQuestion, buttonList, Messages.DlgButtonPositionModes.dpmAutomatic, 0);
                confirmedDelete = true;

                switch (indexDlgBtn)
                {
                    case 1:
                        // delete assigned contact person
                        return DeleteContactPerson();

                    case 2:
                        // cancel
                        throw new KissCancelException();
                }
            }

            bool successDelete;
            var deleteQuestionOfQuery = ActiveSQLQuery.DeleteQuestion;

            try
            {
                // save contact person first
                if (!qryBaInstitutionKontakt.Post())
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            CLASSNAME,
                            "DeleteFailedSaveContactPerson_v02",
                            "Löschen fehlgeschlagen: Die Änderungen der Kontaktperson konnten nicht gespeichert werden.\r\n\r\nKorrigieren Sie zuerst die Kontaktperson vor dem Löschen des Eintrags."));
                }

                // prevent double question
                if (confirmedDelete)
                {
                    ActiveSQLQuery.DeleteQuestion = null;
                }

                // delete on main query
                successDelete = base.OnDeleteData();

                // refresh institution details and contact persons
                if (successDelete)
                {
                    UpdateInstitutionDataAndContactPersons();
                }
            }
            finally
            {
                // reapply delete question
                ActiveSQLQuery.DeleteQuestion = deleteQuestionOfQuery;
            }

            return successDelete;
        }

        public override void OnRefreshData()
        {
            base.OnRefreshData();
            UpdateInstitutionDataAndContactPersons();
        }

        public override bool OnSaveData()
        {
            if (PreventSavingChanges())
            {
                return true;
            }

            bool result = true;

            // save contact person, too if query can be saved
            if (!qryBaInstitutionKontakt.IsEmpty && qryBaInstitutionKontakt.CanUpdate)
            {
                result = qryBaInstitutionKontakt.Post();
            }

            return (result && base.OnSaveData());
        }

        public override void OnUndoDataChanges()
        {
            // depending on current tpg, we undo  changes on main query or ask the user for the action
            if (tabInstitution.IsTabSelected(tpgKontakt) &&
                qryBaInstitutionKontakt.CanUpdate &&
                !DBUtil.IsEmpty(qryBaInstitutionKontakt[DBO.BaPerson_BaInstitution.BaInstitutionKontaktID]))
            {
                string[] buttonList = { _btnDlgInstFachperson, _btnDlgKontaktperson, _btnDlgAbbrechen };

                string msgQuestion = KissMsg.GetMLMessage(
                    CLASSNAME,
                    "QuestionUndoEntry_02",
                    "Wollen Sie die Änderungen an der Beziehung zu einer Institution, Fachperson oder{0}der zugewiesenen Kontaktperson rückgängig machen?",
                    Environment.NewLine);

                int indexDlgBtn = KissMsg.ShowButtonDlg(msgQuestion, buttonList, Messages.DlgButtonPositionModes.dpmAutomatic, 0);

                switch (indexDlgBtn)
                {
                    case 1:
                        // undo assigned contact person
                        qryBaInstitutionKontakt.Cancel();
                        return;

                    case 2:
                        // cancel
                        throw new KissCancelException();
                }
            }

            // undo on main query
            base.OnUndoDataChanges();
        }

        #endregion

        #region Private Static Methods

        private static void CheckRequiredFieldsInCollection(ICollection controls)
        {
            foreach (Control control in controls)
            {
                IKissEditable kissEditable = control as IKissEditable;

                if (kissEditable != null && kissEditable.EditMode == EditModeType.Required)
                {
                    IKissBindableEdit bindableEdit = control as IKissBindableEdit;

                    if (bindableEdit != null)
                    {
                        string editText = control.Tag != null ? control.Tag.ToString() : bindableEdit.DataMember;
                        DBUtil.CheckNotNullField(bindableEdit, editText);
                    }
                }
            }
        }

        private static string DialogInstitutionNameSqlStatement(string searchString)
        {
            // Depending on config-value, we show either the PI-Mode-data or the default-data (see #7977)
            if (DBUtil.GetConfigInt(DIALOGINSTITUTIONNAMECONFIG, 0) == 1)
            {
                // PI-Mode
                return string.Format(@"
                    DECLARE @Delimiter VARCHAR(2);
                    DECLARE @SearchValue VARCHAR(255);
                    DECLARE @UserID INT;
                    DECLARE @LanguageCode INT;

                    SET @Delimiter = '; ';
                    SET @SearchValue = {0};
                    SET @UserID = {1};
                    SET @LanguageCode = {2};

                    --Suche im ganzen Institutionenstamm
                    SET @SearchValue = REPLACE(@SearchValue, ' ', '%');
                    SET @SearchValue = REPLACE(@SearchValue, ',', '%');

                    -- Institutions:
                    SELECT [ID$]             = INS.BaInstitutionID,
                           [Text$]           = ISNULL(INS.NameVorname, '') + ISNULL(', ' + INS.Zusatz, '') + ISNULL(', ' + INS.Ort, ''),
                           --
                           [Inst.-ID]        = INS.BaInstitutionID,
                           [Institution]     = INS.NameVorname,
                           [Zusatz]          = INS.Zusatz,
                           [Strasse]         = INS.StrasseHausNr,
                           [Ort]             = INS.PLZOrt,
                           [Kontaktpersonen] = (STUFF((SELECT CONVERT(VARCHAR(MAX), SUB.[Name])
                                                       FROM (SELECT [Name] = @Delimiter + dbo.fnGetLastFirstName(NULL, SINK.Name, SINK.Vorname)
                                                             FROM dbo.BaInstitutionKontakt SINK WITH (READUNCOMMITTED)
                                                             WHERE SINK.BaInstitutionID = INS.BaInstitutionID
                                                               AND SINK.Aktiv = 1) AS SUB   -- only active ones
                                                       ORDER BY SUB.[Name]
                                                       FOR XML PATH('')), 1, LEN(@Delimiter), ''))
                    FROM dbo.vwInstitution   INS WITH (READUNCOMMITTED)
                      LEFT JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = INS.OrgUnitID
                    WHERE ISNULL(INS.Aktiv, 0) = 1         -- only active ones
                        AND (INS.OrgUnitID IS NULL OR INS.OrgUnitID IN (SELECT ORG.OrgUnitID
                                                                        FROM dbo.fnGetInstStammUserORGList(@UserID) ORG)) -- only institutions the user is allowed to see
                        AND ((ISNULL(INS.NameVorname, '') + ISNULL(', ' + INS.Ort, '')) LIKE '%' + @SearchValue + '%'
                          OR (CONVERT(VARCHAR(50), INS.BaInstitutionID) = @SearchValue))
                        AND dbo.fnGetLastFirstName(NULL, INS.NameVorname, INS.Zusatz) <> ''
                    ORDER BY Institution, ID$;", DBUtil.SqlLiteral(searchString), Session.User.UserID, Session.User.LanguageCode);
            }

            // default mode
            var orgUnitColName = GetOrgUnitTypesTextByDefault("Abteilung").Replace("]", "");   // remove possible "]" to prevent error

            return string.Format(@"
                DECLARE @SearchValue VARCHAR(255);
                DECLARE @UserID INT;
                DECLARE @LanguageCode INT;

                SET @SearchValue = {0};
                SET @UserID = {1};
                SET @LanguageCode = {2};

                --Suche im ganzen Institutionenstamm
                SET @SearchValue = REPLACE(@SearchValue, ' ', '%');
                SET @SearchValue = REPLACE(@SearchValue, ',', '%');

                -- Institutions:
                SELECT ID$          = INS.BaInstitutionID,
                       Text$        = ISNULL(INS.NameVorname, '') + ISNULL(', ' + INS.Zusatz, '') + ISNULL(', ' + INS.Ort, ''),
                       [" + orgUnitColName + @"] = ORG.ItemName,
                       Institution  = INS.NameVorname,
                       Strasse      = INS.StrasseHausNr,
                       Ort          = INS.PLZOrt,
                       Typen        = dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 0, '; ', @UserID, @LanguageCode)
                FROM dbo.vwInstitution   INS WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = INS.OrgUnitID
                WHERE ISNULL(INS.Aktiv, 0) = 1          -- only active ones
                    AND (INS.OrgUnitID IS NULL OR INS.OrgUnitID IN (SELECT ORG.OrgUnitID
                                                                    FROM dbo.fnGetInstStammUserORGList(@UserID) ORG)) -- only institutions the user is allowed to see
                    AND ((ISNULL(INS.NameVorname, '') + ISNULL(', ' + INS.Ort, '')) LIKE '%' + @SearchValue + '%'
                          OR (CONVERT(VARCHAR(50), INS.BaInstitutionID) = @SearchValue))
                    AND dbo.fnGetLastFirstName(NULL, INS.NameVorname, INS.Zusatz) <> ''
                ORDER BY Institution, ID$;", DBUtil.SqlLiteral(searchString), Session.User.UserID, Session.User.LanguageCode);
        }

        private static string GetOrgUnitTypesTextByDefault(string defaultText)
        {
            var orgEinheitName = Utils.GetOrgUnitTypNameForInstitutionsTypen();
            return string.IsNullOrEmpty(orgEinheitName) ? defaultText : orgEinheitName;
        }

        #endregion

        #region Private Methods

        private bool AddNewContactPerson()
        {
            // check if add is possible
            if (!qryBaInstitutionKontakt.CanInsert ||
                !OnSaveData() ||
                !HasValidInstitutionForAddingContactPerson())
            {
                return false;
            }

            // handle and do insert
            edtKontaktperson.EditValue = null;
            tabInstitution.SelectTab(tpgKontakt);

            if (!OnSaveData())
            {
                return false;
            }

            qryBaInstitutionKontakt.Insert(null);
            edtKontaktName.Focus();

            // check if add was successfull
            if (qryBaInstitutionKontakt.Row != null && qryBaInstitutionKontakt.Row.RowState == DataRowState.Added)
            {
                return true;
            }

            return false;
        }

        private bool DeleteContactPerson()
        {
            // check if delete is possible
            if (!qryBaInstitutionKontakt.CanDelete ||
                DBUtil.IsEmpty(qryBaPersonInstitution[DBO.BaPerson_BaInstitution.BaPerson_BaInstitutionID]))
            {
                return false;
            }

            if (qryBaInstitutionKontakt.Row == null ||
                (qryBaInstitutionKontakt.Row.RowState != DataRowState.Added && (DBUtil.IsEmpty(edtKontaktperson.EditValue) || !OnSaveData())))
            {
                return false;
            }

            // handle and perform delete
            bool successDelete;
            bool isNewEntry = (qryBaInstitutionKontakt.Row.RowState == DataRowState.Added);
            bool startedTransaction = false;
            string deleteQuestion = qryBaInstitutionKontakt.DeleteQuestion;

            // on new entries, we do not need to use transaction
            if (!isNewEntry)
            {
                Session.BeginTransaction();
                startedTransaction = true;
            }

            try
            {
                if (!isNewEntry)
                {
                    // no new entry, remove current relationship (required to prevent "in use" error)
                    DBUtil.ExecSQLThrowingException(@"
                        UPDATE PIN
                        SET PIN.BaInstitutionKontaktID = NULL
                        FROM dbo.BaPerson_BaInstitution PIN
                        WHERE PIN.BaPerson_BaInstitutionID = {0};", qryBaPersonInstitution[DBO.BaPerson_BaInstitution.BaPerson_BaInstitutionID]);
                }

                // delete contact person
                qryBaInstitutionKontakt.DeleteQuestion = null;
                successDelete = qryBaInstitutionKontakt.Delete();

                if (startedTransaction)
                {
                    if (successDelete)
                    {
                        Session.Commit();
                    }
                    else
                    {
                        Session.Rollback();
                    }
                }
            }
            catch (KissCancelException)
            {
                if (startedTransaction)
                {
                    Session.Rollback();
                }

                successDelete = false;
            }
            catch (Exception ex)
            {
                if (startedTransaction)
                {
                    Session.Rollback();
                }

                successDelete = false;

                KissMsg.ShowError(CLASSNAME, "ErrorDeleteContactPerson", "Es ist ein Fehler beim Löschen der Kontaktperson aufgetreten.", ex);
            }
            finally
            {
                // reapply delete question
                qryBaInstitutionKontakt.DeleteQuestion = deleteQuestion;
            }

            // reset assigned value and save
            if (successDelete)
            {
                qryBaPersonInstitution.Refresh();
                edtKontaktperson.EditValue = null;
                OnSaveData();
            }

            edtKontaktperson.Focus();

            return successDelete;
        }

        private bool DialogInstitutionName(object sender, UserModifiedFldEventArgs e)
        {
            try
            {
                // convert control
                var edit = (KissButtonEdit)sender;

                // check if data can be altered (we also need to save changes on contact person first!)
                if (!qryBaPersonInstitution.CanUpdate ||
                    qryBaPersonInstitution.Count < 1 ||
                    edit.EditMode == EditModeType.ReadOnly ||
                    !qryBaInstitutionKontakt.Post())
                {
                    // do nothing
                    return true;
                }

                // prepare search string
                var searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edit.EditValue))
                {
                    // prepare for database search
                    searchString = edit.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        try
                        {
                            // set flag to prevent event loops
                            _preventSavingChanges = true;

                            // reset current values
                            qryBaPersonInstitution[DBO.BaPerson_BaInstitution.BaInstitutionID] = DBNull.Value;
                            qryBaPersonInstitution[DBO.vwInstitution.NameVorname] = DBNull.Value;
                            qryBaPersonInstitution["PLZOrtStrasseNr"] = DBNull.Value;
                            qryBaPersonInstitution[DBO.BaPerson_BaInstitution.BaInstitutionKontaktID] = DBNull.Value;
                            edtKontaktperson.EditValue = null;

                            // reset data
                            UpdateInstitutionDataAndContactPersons();
                            return true;
                        }
                        finally
                        {
                            // reset flag again
                            _preventSavingChanges = false;
                        }
                    }
                }

                var dlg = new DlgAuswahl();
                e.Cancel = !dlg.SearchData(DialogInstitutionNameSqlStatement(searchString), searchString, e.ButtonClicked);

                if (!e.Cancel)
                {
                    try
                    {
                        // set flag to prevent event loops
                        _preventSavingChanges = true;

                        // apply new value
                        qryBaPersonInstitution[DBO.BaPerson_BaInstitution.BaInstitutionID] = dlg["ID$"];
                        qryBaPersonInstitution[DBO.vwInstitution.NameVorname] = dlg["Institution"];
                        qryBaPersonInstitution["PLZOrtStrasseNr"] = string.Format("{0}, {1}",
                                                                                  dlg[DBO.vwInstitution.Ort],
                                                                                  dlg[DBO.vwInstitution.Strasse]);
                        qryBaPersonInstitution[DBO.BaPerson_BaInstitution.BaInstitutionKontaktID] = DBNull.Value;
                        edtKontaktperson.EditValue = null;

                        // fill other data
                        UpdateInstitutionDataAndContactPersons();

                        // success
                        return true;
                    }
                    finally
                    {
                        // reset flag again
                        _preventSavingChanges = false;
                    }
                }

                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(
                    CLASSNAME,
                    "ErrorDialogInstitutionName",
                    "Es ist ein Fehler beim Auswählen der Institution, Fachperson aufgetreten.",
                    ex);
                return false;
            }
        }

        private void FillInstitutionData(int baInstitutionID)
        {
            qryInstitution.Fill(@"
                DECLARE @BaInstitutionID INT;
                DECLARE @LanguageCode INT;

                SET @BaInstitutionID = {0};
                SET @LanguageCode = {1};

                SELECT INS.*,
                       --
                       Telefon      = ISNULL(INS.Telefon, '') + ISNULL('; ' + INS.Telefon2, '') + ISNULL('; ' + INS.Telefon3, ''),
                       PostfachText = dbo.fnBaGetPostfachText(NULL, INS.Postfach, INS.PostfachOhneNr, @LanguageCode),
                       Land         = dbo.fnLandMLText(INS.BaLandID, @LanguageCode),
                       Sprache      = dbo.fnGetLOVMLText('BaSprache', INS.SprachCode, @LanguageCode),
                       Abteilung    = ORG.ItemName
                FROM dbo.vwInstitution   INS WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = INS.OrgUnitID
                WHERE INS.BaInstitutionID = @BaInstitutionID;", baInstitutionID, Session.User.LanguageCode);

            qryInstTypen.Fill(@"
                DECLARE @BaInstitutionID INT;
                DECLARE @LanguageCode INT;

                SET @BaInstitutionID = {0};
                SET @LanguageCode = {1};

                SELECT [Name] = dbo.fnGetMLTextByDefault(ITY.NameTID, @LanguageCode, ITY.Name)
                FROM dbo.BaInstitution_BaInstitutionTyp BTY WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BaInstitutionTyp       ITY WITH (READUNCOMMITTED) ON ITY.BaInstitutionTypID = BTY.BaInstitutionTypID
                                                                                  AND ITY.Aktiv = 1 -- only active types!
                WHERE BTY.BaInstitutionID = @BaInstitutionID
                ORDER BY [Name];", baInstitutionID, Session.User.LanguageCode);
        }

        private void FillKontaktpersonData(int baInstitutionKontaktId)
        {
            qryBaInstitutionKontakt.Fill(@"
                SELECT KTP.[BaInstitutionKontaktID],
                       KTP.[BaInstitutionID],
                       KTP.[Aktiv],
                       KTP.[ManuelleAnrede],
                       KTP.[Anrede],
                       KTP.[Briefanrede],
                       KTP.[Titel],
                       KTP.[Name],
                       KTP.[Vorname],
                       KTP.[GeschlechtCode],
                       KTP.[Telefon],
                       KTP.[Fax],
                       KTP.[EMail],
                       KTP.[SprachCode],
                       KTP.[Bemerkung],
                       KTP.[Creator],
                       KTP.[Created],
                       KTP.[Modifier],
                       KTP.[Modified],
                       KTP.[BaInstitutionKontaktTS]
                FROM dbo.BaInstitutionKontakt KTP WITH (READUNCOMMITTED)
                WHERE KTP.[BaInstitutionKontaktID] = {0}
                ORDER BY KTP.[Name],KTP.[Vorname];", baInstitutionKontaktId);

            qryBaInstitutionKontakt.EnableBoundFields();
        }

        private void FillKontaktpersonDropdown(int baInstitutionId)
        {
            // handle current assigned contact person, too (show even if inactive)
            int baInstitutionKontaktID = -1;
            string inactive = KissMsg.GetMLMessage(CLASSNAME, "InactiveContactPerson", "inaktiv");

            if (baInstitutionId > 0 &&
                !qryBaPersonInstitution.IsEmpty &&
                !DBUtil.IsEmpty(qryBaPersonInstitution[DBO.BaPerson_BaInstitution.BaInstitutionKontaktID]))
            {
                baInstitutionKontaktID = Convert.ToInt32(qryBaPersonInstitution[DBO.BaPerson_BaInstitution.BaInstitutionKontaktID]);
            }

            // get all required active contact persons including an empty entry and the one who is selected and inactive
            SqlQuery qryKontaktpersonen = DBUtil.OpenSQL(@"
                SELECT
                  [Code] = NULL,
                  [Text] = ''

                UNION ALL

                SELECT
                  [Code] = KTP.[BaInstitutionKontaktID],
                  [Text] = dbo.fnGetLastFirstName(NULL, KTP.[Name], KTP.[Vorname])
                FROM dbo.BaInstitutionKontakt KTP
                WHERE KTP.[BaInstitutionID] = {0}
                  AND KTP.Aktiv = 1                 -- only active contact persons

                UNION ALL

                SELECT
                  [Code] = KTP.[BaInstitutionKontaktID],
                  [Text] = dbo.fnGetLastFirstName(NULL, KTP.[Name], KTP.[Vorname]) + ' (' + {2} + ')'
                FROM dbo.BaInstitutionKontakt KTP
                WHERE KTP.[BaInstitutionID] = {0}
                  AND KTP.Aktiv = 0                 -- only assigned inactive contact person
                  AND KTP.BaInstitutionKontaktID = {1}
                ORDER BY [Text];", baInstitutionId, baInstitutionKontaktID, inactive);

            edtKontaktperson.LoadQuery(qryKontaktpersonen);
        }

        private int? GetCurrentBaInstitutionID()
        {
            return qryBaPersonInstitution[DBO.BaPerson_BaInstitution.BaInstitutionID] as int?;
        }

        private EditorButton GetKontaktpersonButtonIndexByTag(string tagValue)
        {
            return edtKontaktperson.Properties.Buttons.Cast<EditorButton>()
                .FirstOrDefault(btn => btn.Tag != null && btn.Tag is string && Convert.ToString(btn.Tag) == tagValue);
        }

        private bool HasValidInstitutionForAddingContactPerson()
        {
            return (!qryBaPersonInstitution.IsEmpty && !DBUtil.IsEmpty(qryBaPersonInstitution[DBO.BaPerson_BaInstitution.BaInstitutionID]));
        }

        private bool IsAddingNewContactPerson()
        {
            return (qryBaInstitutionKontakt.Row != null && qryBaInstitutionKontakt.Row.RowState == DataRowState.Added);
        }

        private bool PreventCheckingAndSavingOnInserts()
        {
            return (qryBaPersonInstitution.IsInserting || qryBaInstitutionKontakt.IsInserting);
        }

        private bool PreventSavingChanges()
        {
            return _preventSavingChanges;
        }

        private void SetupDataMember()
        {
            edtBeziehungZuPerson.DataMember = DBO.BaPerson_BaInstitution.BaInstitutionTypID;
            edtKontaktperson.DataMember = DBO.BaPerson_BaInstitution.BaInstitutionKontaktID;
            edtInstitutionName.DataMember = DBO.vwInstitution.NameVorname;

            edtAnsprechPersonMail.DataMember = DBO.BaInstitutionKontakt.EMail;
            edtAnsprechPersonTel.DataMember = DBO.BaInstitutionKontakt.Telefon;

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

            edtAdresseAbteilung.DataMember = "Abteilung";
            edtAdresseBemerkung.DataMember = DBO.BaAdresse.Bemerkung;
            edtAdresseEmail.DataMember = DBO.BaInstitution.EMail;
            edtAdresseFax.DataMember = DBO.BaInstitution.Fax;
            edtAdresseHausNr.DataMember = DBO.BaAdresse.HausNr;
            edtAdresseInternet.DataMember = DBO.BaInstitution.Homepage;
            edtAdresseName.DataMember = DBO.BaInstitution.Name;
            edtAdressePostfach.DataMember = "PostfachText";
            edtAdresseSprache.DataMember = "Sprache";
            edtAdresseStrasse.DataMember = DBO.BaAdresse.Strasse;
            edtAdresseTelefon.DataMember = DBO.BaInstitution.Telefon;
            edtAdresseTitel.DataMember = DBO.BaInstitution.Titel;
            edtAdresseZusatz.DataMember = DBO.BaAdresse.Zusatz;
        }

        private void SetupDataSource()
        {
            grdInstitutionenFachpersonen.DataSource = qryBaPersonInstitution;
            grdInstTypen.DataSource = qryInstTypen;

            edtBeziehungZuPerson.DataSource = qryBaPersonInstitution;
            edtKontaktperson.DataSource = qryBaPersonInstitution;
            edtInstitutionName.DataSource = qryBaPersonInstitution;

            edtAnsprechPersonMail.DataSource = qryBaInstitutionKontakt;
            edtAnsprechPersonTel.DataSource = qryBaInstitutionKontakt;

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

            edtAdresseAbteilung.DataSource = qryInstitution;
            edtAdresseBemerkung.DataSource = qryInstitution;
            edtAdresseEmail.DataSource = qryInstitution;
            edtAdresseFax.DataSource = qryInstitution;
            edtAdresseHausNr.DataSource = qryInstitution;
            edtAdresseInternet.DataSource = qryInstitution;
            edtAdressePLZOrtKtBezirkLand.DataSource = qryInstitution;
            edtAdresseName.DataSource = qryInstitution;
            edtAdressePostfach.DataSource = qryInstitution;
            edtAdresseSprache.DataSource = qryInstitution;
            edtAdresseStrasse.DataSource = qryInstitution;
            edtAdresseTelefon.DataSource = qryInstitution;
            edtAdresseTitel.DataSource = qryInstitution;
            edtAdresseZusatz.DataSource = qryInstitution;
        }

        private void SetupFieldNames()
        {
            colName.FieldName = DBO.vwInstitution.NameVorname;
            colAdresse.FieldName = "PLZOrtStrasseNr";
            colBeziehung.FieldName = "BeziehungZuPerson";
            colBetrifft.FieldName = "BetrifftBaPerson";
            colInstTyp.FieldName = "Name";
        }

        private void SetupGridViews()
        {
            grvInstTypen.OptionsView.ColumnAutoWidth = true;
            grvInstitutionenFachpersonen.OptionsView.ColumnAutoWidth = true;
        }

        private void SetupRequiredFields()
        {
            UtilsGui.SetRequiredIfCanUpdate(edtInstitutionName);
            UtilsGui.SetRequiredIfCanUpdate(edtBetrifftPerson);

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
            // mask
            bool canUserReadMaskData;
            bool canUserInsertMaskData;
            bool canUserUpdateMaskData;
            bool canUserDeleteMaskData;

            // contact person
            bool canUserReadContactPerson;
            bool canUserInsertContactPerson;
            bool canUserUpdateContactPerson;
            bool canUserDeleteContactPerson;

            // PERSON-INSTITUTION
            // get values for mask
            Session.GetUserRight(Name,
                                 out canUserReadMaskData,
                                 out canUserInsertMaskData,
                                 out canUserUpdateMaskData,
                                 out canUserDeleteMaskData);

            if (!canUserReadMaskData)
            {
                // no rights to view this control
                throw new Exception("No rights to view details of this control.");
            }

            // handle EML
            qryBaPersonInstitution.CanInsert = canUserInsertMaskData;
            qryBaPersonInstitution.CanUpdate = canUserUpdateMaskData;
            qryBaPersonInstitution.CanDelete = canUserDeleteMaskData;

            // KONTAKTPERSON:
            // get values for contact persons
            Session.GetUserRight("BAInstitutionFachpersonKontaktpersonEML",
                                 out canUserReadContactPerson,
                                 out canUserInsertContactPerson,
                                 out canUserUpdateContactPerson,
                                 out canUserDeleteContactPerson);

            // handle EML (read is not required to handle)
            qryBaInstitutionKontakt.CanInsert = canUserInsertContactPerson && canUserInsertMaskData;
            qryBaInstitutionKontakt.CanUpdate = canUserUpdateContactPerson && canUserUpdateMaskData;
            qryBaInstitutionKontakt.CanDelete = canUserDeleteContactPerson && canUserDeleteMaskData;

            // setup controls depending on rights
            // -- insert
            var btnInsert = GetKontaktpersonButtonIndexByTag(INSERTKPTAG);

            if (btnInsert != null)
            {
                btnInsert.Visible = qryBaInstitutionKontakt.CanInsert;
                btnInsert.Caption = KissMsg.GetMLMessage(CLASSNAME, "BtnInsertKPCaption", "Neue Kontaktperson hinzufügen");
            }

            // -- delete
            var btnDelete = GetKontaktpersonButtonIndexByTag(DELETEKPTAG);

            if (btnDelete != null)
            {
                btnDelete.Visible = qryBaInstitutionKontakt.CanDelete;
                btnDelete.Caption = KissMsg.GetMLMessage(Name, "BtnDeleteKPCaption", "Gewählte Kontaktperson löschen");
            }
        }

        private void UpdateInstitutionDataAndContactPersons()
        {
            var baInstitutionId = GetCurrentBaInstitutionID();

            if (baInstitutionId.HasValue)
            {
                FillInstitutionData(baInstitutionId.Value);
                FillKontaktpersonDropdown(baInstitutionId.Value);
            }
            else
            {
                FillInstitutionData(-1);
                FillKontaktpersonDropdown(-1);
            }
        }

        #endregion

        #endregion
    }
}