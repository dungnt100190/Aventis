using System;
using System.ComponentModel;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    [Designer(typeof(Gui.Designer.KissControlDesigner))]
    public partial class CtlKGSKostenstelleSAR : KissComplexControl, IKissEditable
    {
        #region Fields

        #region Private Fields

        private EditModeType _editMode = EditModeType.Normal;
        private int _kostenstelleUser;
        private int _mandantennummerUser;
        private bool _setupControls = true;
        private bool _spezialrechtAuswahlKgsUneingeschraenkt;
        private bool _spezialrechtAuswahlKstUneingeschraenkt;
        private bool _spezialrechtAuswahlSarUneingeschraenkt;

        #endregion

        #endregion

        #region Constructors

        public CtlKGSKostenstelleSAR()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        [Browsable(true),
        DefaultValue("KGS")]
        public string DataMemberKGS
        {
            get { return EdtSucheKGS.DataMember; }
            set { EdtSucheKGS.DataMember = value; }
        }

        [Browsable(true),
        DefaultValue("Kostenstelle")]
        public string DataMemberKostenstelle
        {
            get { return EdtSucheKostenstelle.DataMember; }
            set { EdtSucheKostenstelle.DataMember = value; }
        }

        [Browsable(true),
        DefaultValue("Mitarbeiter")]
        public string DataMemberMitarbeiter
        {
            get { return EdtSucheMitarbeiter.DataMember; }
            set { EdtSucheMitarbeiter.DataMember = value; }
        }

        [Browsable(true)]
        [DefaultValue(null)]
        public SqlQuery DataSource
        {
            get { return EdtSucheKGS.DataSource; }
            set
            {
                EdtSucheKGS.DataSource = value;
                EdtSucheKostenstelle.DataSource = value;
                EdtSucheMitarbeiter.DataSource = value;
            }
        }

        [Browsable(true)]
        [DefaultValue(EditModeType.Normal)]
        public EditModeType EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;

                SetEditMode(EdtSucheKGS, _editMode);
                SetEditMode(EdtSucheKostenstelle, _editMode);
                SetEditMode(EdtSucheMitarbeiter, _editMode);
            }
        }

        #endregion

        #region EventHandlers

        private void CtlKGSKostenstelleSAR_Load(object sender, EventArgs e)
        {
            SetupControls();
        }

        private void EdtSucheKGS_EditValueChanged(object sender, EventArgs e)
        {
            // fill other lookupedits depending on mandantennummer
            if (DBUtil.IsEmpty(EdtSucheKGS.EditValue))
            {
                SetEditMode(EdtSucheKostenstelle, EditModeType.ReadOnly);
                EdtSucheKostenstelle.EditValue = null;
                return;
            }

            SetEditMode(EdtSucheKostenstelle, EditModeType.Normal);
            SetupEdtSucheKostenstelle(EdtSucheKGS.EditValue);
        }

        private void EdtSucheKostenstelle_EditValueChanged(object sender, EventArgs e)
        {
            SetupEdtSucheSar(EdtSucheKostenstelle.EditValue, EdtSucheKGS.EditValue);
        }

        private void SetupControls()
        {
            if (DesignMode)
            {
                return;
            }

            if (!_setupControls)
            {
                return;
            }

            // get users member orgunit
            var qryOrgUnit = DBUtil.OpenSQL(@"
                SELECT
                  Mandantennummer = ISNULL(ORG.Mandantennummer, ORGP.Mandantennummer),
                  ORG.Kostenstelle
                FROM dbo.XOrgUnit         ORG  WITH (READUNCOMMITTED)
                  LEFT  JOIN dbo.XOrgUnit ORGP WITH (READUNCOMMITTED) ON ORGP.OrgUnitID = ORG.ParentID
                WHERE ORG.OrgUnitID = dbo.fnOrgUnitOfUser({0}, 1);",
                Session.User.UserID);

            if (qryOrgUnit.Count == 1)
            {
                _kostenstelleUser = Utils.ConvertToInt(qryOrgUnit[DBO.XOrgUnit.Kostenstelle]);
                _mandantennummerUser = Utils.ConvertToInt(qryOrgUnit[DBO.XOrgUnit.Mandantennummer]);
            }

            // RIGHTS:
            _spezialrechtAuswahlKgsUneingeschraenkt = DBUtil.UserHasRight("AuswahlKGSUneingeschraenkt");
            _spezialrechtAuswahlKstUneingeschraenkt = DBUtil.UserHasRight("AuswahlKSTUneingeschraenkt");
            _spezialrechtAuswahlSarUneingeschraenkt = DBUtil.UserHasRight("AuswahlSARUneingeschraenkt");

            SetupEdtSucheKGS();

            EdtSucheKGS.EditValueChanged += EdtSucheKGS_EditValueChanged;
            EdtSucheKostenstelle.EditValueChanged += EdtSucheKostenstelle_EditValueChanged;

            if (!_spezialrechtAuswahlKgsUneingeschraenkt)
            {
                EdtSucheKGS.EditMode = EditModeType.ReadOnly;
            }

            if (!_spezialrechtAuswahlKstUneingeschraenkt)
            {
                EdtSucheKostenstelle.EditMode = EditModeType.ReadOnly;
            }

            if (!_spezialrechtAuswahlSarUneingeschraenkt)
            {
                EdtSucheMitarbeiter.EditMode = EditModeType.ReadOnly;
            }

            _setupControls = false;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Clear()
        {
            EdtSucheKGS.EditValue = null;
            EdtSucheKostenstelle.EditValue = null;
            EdtSucheMitarbeiter.EditValue = null;
        }

        public void InitControlForNewSearch(bool setKgs = true, bool setKostenstelle = true, bool setMitarbeiter = true)
        {
            SetupControls();

            //initial alle Felder leeren
            Clear();

            if (setKgs)
            {
                EdtSucheKGS.EditValue = _mandantennummerUser;
                if (setKostenstelle)
                {
                    EdtSucheKostenstelle.EditValue = _kostenstelleUser;
                    if (setMitarbeiter)
                    {
                        EdtSucheMitarbeiter.EditValue = Session.User.UserID;
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        private void SetEditMode(IKissEditable edt, EditModeType editMode)
        {
            var hasRight = false;
            if (edt == EdtSucheKGS)
            {
                hasRight = _spezialrechtAuswahlKgsUneingeschraenkt;
            }
            else if (edt == EdtSucheKostenstelle)
            {
                hasRight = _spezialrechtAuswahlKstUneingeschraenkt;
            }
            else if (edt == EdtSucheMitarbeiter)
            {
                hasRight = _spezialrechtAuswahlSarUneingeschraenkt;
            }

            edt.EditMode = hasRight ? editMode : EditModeType.ReadOnly;
        }

        private void SetupEdtSucheKGS()
        {
            // all mandanten the user can see
            SqlQuery qryMandanten =
                DBUtil.OpenSQL(
                    @"
                    SELECT [Code] = NULL,
                           [Text] = ''
                    WHERE 1 = ISNULL({0}, 0)
                      AND 0 = ISNULL({1}, 1)

                    UNION ALL

                    SELECT [Code] = ORG.Mandantennummer,
                           [Text] = CONVERT(VARCHAR(10), ISNULL(ORG.Mandantennummer, -1)) + '   ' + ORG.ItemName
                    FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
                    WHERE ORG.Mandantennummer IS NOT NULL
                      AND (1 = ISNULL({0}, 0) OR ORG.Mandantennummer = dbo.fnOrgUnitOfUserMandantenNr({2})) -- only special can select all
                    ORDER BY [Code], [Text];",
                    _spezialrechtAuswahlKgsUneingeschraenkt,
                    false, // allow NULL
                    Session.User.UserID);

            // setup edtSucheKGS
            SetEditMode(EdtSucheKGS, EditModeType.Normal);

            EdtSucheKGS.LoadQuery(qryMandanten);
        }

        /// <summary>
        /// Sucht für das Feld Kostenstelle alle Kostenstelle eines Geschäftsbereichs (Mandanten)
        /// und stellt diese zur Auswahl.
        /// </summary>
        /// <param name="mandantenNr">Die Mandantennummer, auch als Geschäftsbereich bekannt</param>
        private void SetupEdtSucheKostenstelle(object mandantenNr)
        {
            // all kostenstellen within mandantennummer
            SqlQuery qryKostenstellen =
                DBUtil.OpenSQL(
                    @"
                    SELECT [Code] = NULL,
                           [Text] = ''
                    UNION
                    SELECT [Code] = ISNULL(ORG.Kostenstelle, -1),
                           [Text] = CONVERT(VARCHAR(10), ISNULL(ORG.Kostenstelle, -1)) + '   ' + ORG.ItemName
                    FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
                    WHERE ISNULL({0}, -1) < 0 OR ORG.OrgUnitID IN (SELECT OrgUnitID
                                                                   FROM dbo.fnGetMandantOrgUnits({0}))
                    ORDER BY [Text], [Code];",
                    mandantenNr);

            // setup edtSucheKostenstelle
            EdtSucheKostenstelle.Properties.DataSource = null;
            EdtSucheKostenstelle.Properties.DropDownRows = Math.Min(qryKostenstellen.Count, 14);
            EdtSucheKostenstelle.Properties.DataSource = qryKostenstellen;
            EdtSucheKostenstelle.EditValue = null;

            if (EdtSucheMitarbeiter.EditMode != EditModeType.ReadOnly)
            {
                SetupEdtSucheSar(EdtSucheKostenstelle.EditValue, mandantenNr);
            }
        }

        /// <summary>
        /// Sucht für das Feld SAR alle Benutzer einer Kostenstelle
        /// und stellt dieses zur Auswahl.
        /// </summary>
        /// <param name="kostenstelle">Nummer der kostenstelle (int) oder DbNull</param>
        /// <param name="mandantenNr">Nummer des Mandants (int) oder DbNull</param>
        private void SetupEdtSucheSar(object kostenstelle, object mandantenNr)
        {
            SqlQuery qryUsers =
                DBUtil.OpenSQL(
                    @"
                    SELECT [Code] = NULL,
                           [Text] = ''
                    UNION
                    SELECT [Code] = USR.UserID,
                           [Text] = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) + ISNULL(' (' + USR.LogonName + ')', '')
                    FROM dbo.XUser                 USR WITH (READUNCOMMITTED)
                      INNER JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID
                                                                             AND OUU.OrgUnitMemberCode = 2
                      INNER JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
                    WHERE ({0} IS NOT NULL AND ORG.Kostenstelle = {0})
                      OR ({0} IS NULL AND {1} IS NOT NULL AND ORG.OrgUnitID IN (SELECT OrgUnitID
                                                                                FROM dbo.fnGetMandantOrgUnits({1})))
                    ORDER BY [Text], [Code];",
                    kostenstelle,
                    mandantenNr);
            EdtSucheMitarbeiter.LoadQuery(qryUsers);
            EdtSucheMitarbeiter.EditValue = null;
        }

        #endregion

        #endregion
    }
}