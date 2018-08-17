using System;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    public partial class CtlAdInstitutionsTypen : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string QRY_INST_TYPEN_NAME_ML = "BezeichungML";
        private const string QRY_INST_TYPEN_ORG_UNIT_NAME = "OrgUnitName";
        private readonly int _oeItemTypCode = DBUtil.GetConfigInt(@"System\Basis\OrgEinheitTypFuerInstTypen", -1);
        private readonly int _oeItemTypCodeSek = DBUtil.GetConfigInt(@"System\Basis\OrgEinheitTypFuerInstTypenSek", -1);

        #endregion

        #endregion

        #region Constructors

        public CtlAdInstitutionsTypen()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnMigration_Click(object sender, EventArgs e)
        {
            // security
            if (!btnMigration.Enabled || !OnSaveData())
            {
                return;
            }

            try
            {
                // validate
                DBUtil.CheckNotNullField(edtMigrationID, lblMigrationID.Text);

                // get target and source id
                int targetID = Convert.ToInt32(edtMigrationID.EditValue);
                int sourceID = Convert.ToInt32(qryInstTypen[DBO.BaInstitutionTyp.BaInstitutionTypID]);

                if (targetID == sourceID)
                {
                    edtMigrationID.Focus();
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "MigrationIDSourceTargetSame",
                                                                     "Die Ziel-ID entspricht der ID des gewählten Typs, die Daten können nicht zusammengeführt werden."));
                }

                // get values for id
                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT Name = dbo.fnGetMLTextByDefault(ITY.NameTID, {1}, ITY.Name)
                    FROM dbo.BaInstitutionTyp ITY WITH (READUNCOMMITTED)
                    WHERE ITY.BaInstitutionTypID = {0};", targetID, Session.User.LanguageCode);

                if (qry.IsEmpty)
                {
                    edtMigrationID.Focus();
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                     "MigrationTypeIDNotFound",
                                                                     "Die gewünschte Ziel-ID wurde nicht gefunden. Bitte überprüfen Sie Ihre Angabe."));
                }

                // confirm
                if (KissMsg.ShowQuestion(this.Name,
                                         "ConfirmMigration_v01",
                                         "Wollen Sie alle abhängigen Daten des gewählten Typs '{0}' (ID: {1}) zum Typ '{2}' (ID: {3}) migrieren?",
                                         false,
                                         qryInstTypen[DBO.BaInstitutionTyp.Name],
                                         sourceID,
                                         qry[DBO.BaInstitutionTyp.Name],
                                         targetID))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Session.BeginTransaction();

                    try
                    {
                        // update pending data
                        DBUtil.ExecSQLThrowingException(@"
                            EXEC dbo.spXRowMerge {0}, {1}, {2}, 0, 0;", DBO.BaInstitutionTyp.DBOName, targetID, sourceID);

                        // save changes
                        Session.Commit();
                    }
                    catch
                    {
                        // do rollback and trow exception further on
                        Session.Rollback();
                        throw;
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }

                    // success
                    KissMsg.ShowInfo(this.Name,
                                     "SuccessMigrate",
                                     "Die Daten wurden erfolgreich migriert. Der Typ '{0}' (ID: {1}) wird nun nicht mehr verwendet und kann gelöscht werden.",
                                     qryInstTypen[DBO.BaInstitutionTyp.Name],
                                     sourceID);
                }
            }
            catch (Exception ex)
            {
                // show message depending on type
                if (ex is KissInfoException)
                {
                    ((KissInfoException)ex).ShowMessage();
                }
                else
                {
                    KissMsg.ShowError(this.Name, "ErrorMigrationID", "Es ist ein Fehler beim Zusammenführen der Typen aufgetreten.", ex);
                }
            }
        }

        private void CtlAdInstitutionsTypen_Load(object sender, EventArgs e)
        {
            SetupOrgUnitLookupEdits();
            SetupRequiredFields();
            SetupDataSource();
            SetupDataMembers();
            SetupRights();

            // run search
            this.NewSearch();
            tabControlSearch.SelectTab(tpgListe);
        }

        private void qryInstTypen_AfterInsert(object sender, EventArgs e)
        {
            qryInstTypen[DBO.BaInstitutionTyp.Aktiv] = 1;
            qryInstTypen.SetCreator();

            edtBezeichung.Focus();
        }

        private void qryInstTypen_AfterPost(object sender, EventArgs e)
        {
            qryInstTypen[QRY_INST_TYPEN_NAME_ML] = edtBezeichung.Text;
            qryInstTypen[QRY_INST_TYPEN_ORG_UNIT_NAME] = edtOrgUnit.Text;
        }

        private void qryInstTypen_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            // check if entry is not in use already
            int countUsageInst = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT COUNT(1)
                FROM dbo.BaInstitution_BaInstitutionTyp WITH (READUNCOMMITTED)
                WHERE BaInstitutionTypID = {0};", qryInstTypen[DBO.BaInstitutionTyp.BaInstitutionTypID]));

            int countUsagePersInst = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT COUNT(1)
                FROM dbo.BaPerson_BaInstitution WITH (READUNCOMMITTED)
                WHERE BaInstitutionTypID = {0};", qryInstTypen[DBO.BaInstitutionTyp.BaInstitutionTypID]));

            if (countUsageInst > 0 || countUsagePersInst > 0)
            {
                // entry cannot be deleted because of usage
                KissMsg.ShowInfo(this.Name, "CannotDeleteEntry_v01", "Dieser Eintrag wird zurzeit verwendet und kann daher nicht gelöscht werden.\r\n\r\nVerwendung bei Institutionen: {0} Einträge, Personen: {1} Einträge.", 0, 0, countUsageInst, countUsagePersInst);

                // cancel
                throw new KissCancelException();
            }
        }

        private void qryInstTypen_BeforePost(object sender, EventArgs e)
        {
            CheckRequiredFields();

            // set modifier/modified
            qryInstTypen.SetModifierModified();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void Translate()
        {
            base.Translate();

            string typeName = Utils.GetOrgUnitTypNameForInstitutionsTypen();

            if (!string.IsNullOrEmpty(typeName))
            {
                // apply name to column and label
                colOrgUnit.Caption = typeName;
                lblOrgUnit.Text = typeName;
            }
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            // focus
            edtSuchenBezeichnung.Focus();
        }

        protected override void RunSearch()
        {
            object[] parameters = new object[] { Session.User.LanguageCode };
            this.kissSearch.SelectParameters = parameters;

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void CheckRequiredFields()
        {
            foreach (Control control in panEditFields.Controls)
            {
                if (control is IKissEditable && ((IKissEditable)control).EditMode == EditModeType.Required)
                {
                    DBUtil.CheckNotNullField((IKissBindableEdit)control, control.Tag.ToString());
                }
            }
        }

        private void SetupDataMembers()
        {
            edtBezeichung.DataMember = null;
            edtBezeichung.DataMemberDefaultText = DBO.BaInstitutionTyp.Name;
            edtBezeichung.DataMemberTID = DBO.BaInstitutionTyp.NameTID;
            edtOrgUnit.DataMember = DBO.BaInstitutionTyp.OrgUnitID;
            chkAktiv.DataMember = DBO.BaInstitutionTyp.Aktiv;
            edtBemerkung.DataMember = DBO.BaInstitutionTyp.Bemerkung;

            colID.FieldName = DBO.BaInstitutionTyp.BaInstitutionTypID;
            colBezeichnung.FieldName = QRY_INST_TYPEN_NAME_ML;
            colOrgUnit.FieldName = QRY_INST_TYPEN_ORG_UNIT_NAME;
            colAktiv.FieldName = DBO.BaInstitutionTyp.Aktiv;
        }

        private void SetupDataSource()
        {
            edtBezeichung.DataSource = qryInstTypen;
            edtOrgUnit.DataSource = qryInstTypen;
            chkAktiv.DataSource = qryInstTypen;
            edtBemerkung.DataSource = qryInstTypen;

            grdInstTypen.DataSource = qryInstTypen;
        }

        private void SetupOrgUnitLookupEdits()
        {
            edtOrgUnit.Properties.DataSource = null;
            edtSuchenOrgUnit.Properties.DataSource = null;

            SqlQuery qryOrgUnit = DBUtil.OpenSQL(@"
                    DECLARE @OEItemTypCode INT;
                    DECLARE @OEItemTypCodeSek INT;

                    SET @OEItemTypCode    = ISNULL({0}, -1);
                    SET @OEItemTypCodeSek = ISNULL({1}, -1);

                    SELECT [Code]    = NULL,
                           [Text]    = ''

                    UNION

                    SELECT [Code]    = ORG.OrgUnitID,
                           [Text]    = ORG.ItemName
                    FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
                    WHERE @OEItemTypCode < 0
                       OR ISNULL(ORG.OEItemTypCode, -99) IN (@OEItemTypCode, @OEItemTypCodeSek) -- (optional filter OrganisationsEinheitTyp)
                    ORDER BY [Text], [Code];", _oeItemTypCode, _oeItemTypCodeSek);

            edtOrgUnit.LoadQuery(qryOrgUnit);
            edtOrgUnit.Properties.DropDownRows = Math.Min(qryOrgUnit.Count, 7);

            edtSuchenOrgUnit.LoadQuery(qryOrgUnit);
            edtSuchenOrgUnit.Properties.DropDownRows = Math.Min(qryOrgUnit.Count, 7);
        }

        private void SetupRequiredFields()
        {
            edtBezeichung.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            edtBezeichung.Tag = lblBezeichung.Text;
        }

        private void SetupRights()
        {
            bool isAdmin = Session.User.IsUserAdmin || Session.User.IsUserBIAGAdmin;
            bool canReadData = false;
            bool canInsert = false;
            bool canUpdate = false;
            bool canDelete = false;

            Session.GetUserRight(this.Name, out canReadData, out canInsert, out canUpdate, out canDelete);

            if (!canReadData)
            {
                throw new Exception(KissMsg.GetMLMessage(Name, "NoReadRight", "Sie besitzen nicht die Berechtigung, dese Maske anzuzeigen."));
            }

            qryInstTypen.CanInsert = isAdmin || canInsert;
            qryInstTypen.CanUpdate = isAdmin || canUpdate;
            qryInstTypen.CanDelete = isAdmin || canDelete;

            // fields
            qryInstTypen.EnableBoundFields();

            // migration
            colID.Visible = isAdmin;
            grpMigration.Visible = isAdmin;
            btnMigration.Enabled = isAdmin;
        }

        #endregion

        #endregion
    }
}