using System;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sostat
{
    public partial class CtlBfsDossier : KissUserControl
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        public const string DISPLAY_FORMAT_BFS_DOSSIER_NR = @"##########\.####\.##\.##\.#";

        #endregion

        #region Private Fields

        private int _bfsDossierID = -1; // store dossier id of current dossier to show
        private bool _dataHasChanged = false; // store if data has changed to refresh tree in CtlBfsDossiers (per init() call)
        private bool _recalculatePersonIndex;

        #endregion

        #endregion

        #region Constructors

        public CtlBfsDossier()
        {
            InitializeComponent();

            edtBFSDossierNr.Properties.DisplayFormat.FormatString = DISPLAY_FORMAT_BFS_DOSSIER_NR;
            edtBFSDossierNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            edtBFSDossierNr.Properties.EditFormat.FormatString = DISPLAY_FORMAT_BFS_DOSSIER_NR;
            edtBFSDossierNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            edtBFSDossierNr.Properties.EditMask = "D20";    // when focused: do not show any "." --> copy paste will be easier
            edtBFSDossierNr.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            // set default image
            picTitle.Image = KissImageList.GetSmallImage(2111);

            // setup lookup sql
            edtUserID.LookupSQL = @"
                ----
                SELECT Text = LastName + ISNULL(', ' + FirstName, ''), Code = UserID
                FROM dbo.XUser WITH (READUNCOMMITTED)
                WHERE UserID = {0}";

            // setup columnedit
            colBFSPersonCode.ColumnEdit = grdPersonen.GetLOVLookUpEdit(DBUtil.OpenSQL(@"
                SELECT Code, Text
                FROM dbo.BFSLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'BFSPerson'
                ORDER BY SortKey"));

            // init control with no data
            Init(-1);
            //Init(23489);	// debug only

            var qry = DBUtil.OpenSQL(@"
                SELECT Code, Text, *
                FROM dbo.BFSLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'BFSLeistungsart';");

            edtBFSLeistungsArtCode.LoadQuery(qry);

            qry = DBUtil.OpenSQL(@"
                SELECT Code, Text
                FROM dbo.BFSLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'BFSGemeindeSozialdienst';");

            edtZustaendigeGemeinde.LoadQuery(qry);
        }

        #endregion

        #region Properties

        public bool DataHasChanged
        {
            get { return _dataHasChanged; }
            set { _dataHasChanged = value; }
        }

        public SqlQuery SQLQuery
        {
            get { return ActiveSQLQuery; }
        }

        #endregion

        #region EventHandlers

        private void edtUserID_UserModifiedFld(object sender, Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();

            if (dlg.MitarbeiterSuchen(edtUserID.Text, e.ButtonClicked))
            {
                edtUserID.EditValue = (int)dlg["UserID"];
                edtUserID.Text = dlg["Name"] as string;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void qryBFSDossier_AfterPost(object sender, EventArgs e)
        {
            // set flag
            _dataHasChanged = true;
        }

        private void qryBFSDossierPerson_AfterInsert(object sender, EventArgs e)
        {
            // setup default values
            qryBFSDossierPerson["BFSDossierID"] = _bfsDossierID;
        }

        private void qryBFSDossierPerson_AfterPost(object sender, EventArgs e)
        {
            if (_recalculatePersonIndex)
            {
                DBUtil.ExecSQLThrowingException(@"
                    WITH RowCTE AS
                    (
                        SELECT
                        BFSDossierPersonID,
                        PersonIndex = ROW_NUMBER() OVER(PARTITION BY BFSPersonCode ORDER BY PersonIndex)
                        FROM dbo.BFSDossierPerson
                        WHERE BFSDossierID = {0}
                        AND BFSPersonCode <> 1
                    )
                    UPDATE DOP SET DOP.PersonIndex = CTE.PersonIndex
                    --SELECT *
                    FROM dbo.BFSDossierPerson DOP WITH (READUNCOMMITTED)
                        INNER JOIN RowCTE       CTE ON CTE.BFSDossierPersonID = DOP.BFSDossierPersonID;", qryBFSDossierPerson["BFSDossierID"]);
                _recalculatePersonIndex = false;
            }

            Session.Commit();

            // set flag
            _dataHasChanged = true;
        }

        private void qryBFSDossierPerson_BeforePost(object sender, EventArgs e)
        {
            Session.BeginTransaction();

            if ((int)qryBFSDossierPerson["BFSPersonCode"] == 1)
            {
                qryBFSDossierPerson["PersonIndex"] = DBNull.Value;
            }

            if (qryBFSDossierPerson.ColumnModified("BFSPersonCode"))
            {
                var newIndex = DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT COUNT(1) + 1
                    FROM dbo.BFSDossierPerson WITH (READUNCOMMITTED)
                    WHERE BFSDossierID = {0}
                      AND BFSPersonCode = {1};", qryBFSDossierPerson["BFSDossierID"], qryBFSDossierPerson["BFSPersonCode"]);
                qryBFSDossierPerson["PersonIndex"] = newIndex;
                _recalculatePersonIndex = true;
            }

            if (qryBFSDossierPerson.DataTable.Select(string.Format("BFSDossierID = {0} AND BFSPersonCode = 1", qryBFSDossierPerson["BFSDossierID"])).Length <= 0)
            {
                throw new KissInfoException(KissMsg.GetMLMessage("CtlBfsDossier", "KeinAntragsteller", "Es wurde kein Antragsteller erfasst!", KissMsgCode.MsgInfo));
            }

            if (qryBFSDossierPerson.DataTable.Select(string.Format("BFSDossierID = {0} AND BFSPersonCode = 1", qryBFSDossierPerson["BFSDossierID"])).Length > 1)
            {
                throw new KissInfoException(KissMsg.GetMLMessage("CtlBfsDossier", "MehrereAntragsteller", "Es wurden mehrere Antragsteller erfasst!", KissMsgCode.MsgInfo));
            }

            if (qryBFSDossierPerson.DataTable.Select(string.Format("BFSDossierID = {0} AND PersonName = '{1}'", qryBFSDossierPerson["BFSDossierID"], qryBFSDossierPerson["PersonName"])).Length > 1)
            {
                throw new KissInfoException(KissMsg.GetMLMessage("CtlBfsDossier", "DoppeltePerson", "Es wurden mehrere Personen mit gleichem Namen erfasst!", KissMsgCode.MsgInfo));
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(int bfsDossierID)
        {
            // store id
            _bfsDossierID = bfsDossierID;

            // set if user can edit fields
            var importDate = DBUtil.ExecuteScalarSQL(@"
                SELECT DOS.ImportDatum
                FROM dbo.BFSDossier DOS WITH (READUNCOMMITTED)
                WHERE DOS.BFSDossierID = {0};", bfsDossierID);

            qryBFSDossier.CanUpdate = DBUtil.IsEmpty(importDate);

            // load data for dossier
            qryBFSDossier.Fill(@"
                SELECT DOS.*,
                       BFSDossierNr = (SELECT dbo.fnBFSConcatDossierNr(SDOP.BaPersonID, DOS.ZustaendigeGemeinde, DOS.LaufNr, DOS.BFSLeistungsartCode, DOS.Stichtag)
                                       FROM dbo.BFSDossierPerson SDOP WITH (READUNCOMMITTED)
                                       WHERE SDOP.BFSDossierID = DOS.BFSDossierID
                                         AND SDOP.BFSPersonCode = 1)
                FROM dbo.BFSDossier DOS WITH (READUNCOMMITTED)
                WHERE DOS.BFSDossierID = {0};", bfsDossierID);

            // load data for persons
            qryBFSDossierPerson.Fill(@"
                SELECT BaPersonID$ = BaPersonID, *
                FROM dbo.BFSDossierPerson WITH (READUNCOMMITTED)
                WHERE BFSDossierID = {0}
                ORDER BY BFSPersonCode, PersonIndex;", bfsDossierID);

            // setup flags
            _dataHasChanged = false;
        }

        public override bool OnDeleteData()
        {
            // set flag
            _dataHasChanged = true;

            return base.OnDeleteData();
        }

        public bool SaveChangedData()
        {
            //perform "import" if manually created Dossier
            if (DBUtil.IsEmpty(qryBFSDossier["ImportDatum"]) && DBUtil.IsEmpty(qryBFSDossier["FaLeistungID"]))
            {
                DBUtil.ExecSQL(@"EXECUTE dbo.spBFSPerformImport {0};", _bfsDossierID);
                qryBFSDossier["ImportDatum"] = DateTime.Now;
            }

            // and save data on both queries
            return qryBFSDossier.Post() && qryBFSDossierPerson.Post();
        }

        #endregion

        #endregion
    }
}