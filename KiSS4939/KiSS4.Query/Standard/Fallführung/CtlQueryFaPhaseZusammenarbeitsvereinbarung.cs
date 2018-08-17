using System;

using KiSS4.Common;
using KiSS4.DB;

using DevExpress.XtraEditors.Controls;

namespace KiSS4.Query
{
    public partial class CtlQueryFaPhaseZusammenarbeitsvereinbarung : KissQueryControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly string _code = "Code";
        private readonly string _text = "Text";

        #endregion

        #region Private Fields

        private int? _sektionOrgIdBenutzer;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryFaPhaseZusammenarbeitsvereinbarung()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlQueryFaPhaseZusammenarbeitsvereinbarung_Load(object sender, EventArgs e)
        {
            FillSektionAuswahl();
            SetSektionOrganisationBenutzer();
            NewSearch();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            chkAbgeschlosseneAusblenden.Checked = true;
            chkFMitOffenemS.Checked = true;
            chkNurAktiveF.Checked = true;
            if (_sektionOrgIdBenutzer.HasValue)
            {
                edtSektion.EditValue = _sektionOrgIdBenutzer;
            }

            base.NewSearch();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sektionsauswahl füllen
        /// </summary>
        private void FillSektionAuswahl()
        {
            /* edtSektion füllen mit den Werten der ersten Hierarchiestufe */
            var qrySektion =
                DBUtil.OpenSQL(@"
                    SELECT Code = ORG2.OrgUnitID, Text = ORG2.ItemName
                    FROM XOrgUnit ORG2 WITH(READUNCOMMITTED)
                        INNER JOIN XOrgUnit ORG1 ON ORG1.OrgUnitID = ORG2.ParentID
                    ORDER BY ORG2.ItemName
                    ");
            var newRow = qrySektion.DataTable.NewRow();
            newRow[_text] = "";
            qrySektion.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtSektion.Properties.Columns.Clear();
            edtSektion.Properties.Columns.AddRange(
                new[]
                    {
                        new LookUpColumnInfo(
                            _text, "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                    });
            edtSektion.Properties.ShowFooter = false;
            edtSektion.Properties.ShowHeader = false;
            edtSektion.Properties.DisplayMember = _text;
            edtSektion.Properties.ValueMember = _code;
            edtSektion.Properties.DropDownRows = Math.Min(qrySektion.Count, 7);
            edtSektion.Properties.DataSource = qrySektion;
        }

        /// <summary>
        /// Sektion des Benutzers abfragen und zwischenspeichern
        /// </summary>
        private void SetSektionOrganisationBenutzer()
        {
            if (!Session.User.OrgUnitID.HasValue)
            {
                _sektionOrgIdBenutzer = null;
                return;
            }

            _sektionOrgIdBenutzer = DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT ORG.OrgUnitID
                FROM dbo.fnXOrgUnitsOfUser({0}) ORGS
                  INNER JOIN dbo.XOrgUnit      ORG  WITH (READUNCOMMITTED) ON ORG.OrgUnitID = ORGS.OrgUnitID
                  INNER JOIN dbo.XOrgUnit      ORG1 WITH (READUNCOMMITTED) ON ORG1.OrgUnitID = ORG.ParentID
                                                                          AND ORG1.ParentID IS NULL;", Session.User.UserID) as int?;
        }

        #endregion

        #endregion
    }
}