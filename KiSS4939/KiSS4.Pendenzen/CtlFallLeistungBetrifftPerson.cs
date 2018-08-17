using System;
using System.ComponentModel;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Pendenzen
{
    public partial class CtlFallLeistungBetrifftPerson : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// SQL, wenn der Dialog bei einer Person geöffnet wird,
        /// welche nur Bezugsperson ist.
        /// </summary>
        private const string SQL_BEZUGSPERSON = @"
            SELECT
              BaPersonID  = PRS.BaPersonID,
              NameVorname = PRS.NameVorname
            FROM dbo.vwPerson PRS
            WHERE PRS.BaPersonID = {0}

            UNION ALL

            SELECT BaPersonID = NULL, NameVorname = ''
            ORDER BY 2;";

        /// <summary>
        /// SQL, wenn der Dialog bei einer Person geöffnet wird,
        /// welche auch Fallträger ist.
        /// </summary>
        private const string SQL_BEZUGSPERSONEN_FALLTRAEGER = @"
            SELECT
              PRS.BaPersonID,
              PRS.NameVorname
            FROM dbo.FaFallPerson     FAP
              INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = FAP.BaPersonID
            WHERE FAP.FaFallID = {0}

            UNION ALL

            SELECT NULL, ''
            ORDER BY 2;";

        #endregion

        #region Private Fields

        private SqlQuery _dataSource;
        private bool _showFaFallDropDown;
        private bool _showSAR;

        #endregion

        #endregion

        #region Constructors

        public CtlFallLeistungBetrifftPerson()
        {
            InitializeComponent();

            //apply default values
            DataMemberBaPersonID = "BaPersonID";
            DataMemberFaFall = "FaFall";
            DataMemberFaFallID = "FaFallID";
            DataMemberFaLeistungID = "FaLeistungID";
            DataMemberSAR = "SAR";
            DataMemberJumpToPath = "JumpToPath";

            //apply layout (visibility of controls)
            SetupControl();
        }

        #endregion

        #region Properties

        [Browsable(true)]
        [DefaultValue("BaPersonID")]
        public string DataMemberBaPersonID
        {
            get
            {
                return edtBaPersonID.DataMember;
            }

            set
            {
                edtBaPersonID.DataMember = value;
            }
        }

        [Browsable(true)]
        [DefaultValue("FaFall")]
        public string DataMemberFaFall
        {
            get
            {
                return edtFaFall.DataMember;
            }

            set
            {
                edtFaFall.DataMember = value;
            }
        }

        [Browsable(true),
        DefaultValue("FaFallID")]
        public string DataMemberFaFallID
        {
            get;
            set;
        }

        [Browsable(true)]
        [DefaultValue("FaLeistungID")]
        public string DataMemberFaLeistungID
        {
            get
            {
                return edtFaLeistungID.DataMember;
            }

            set
            {
                edtFaLeistungID.DataMember = value;
            }
        }

        [Browsable(true)]
        [DefaultValue("JumpToPath")]
        public string DataMemberJumpToPath
        {
            get;
            set;
        }

        [Browsable(true)]
        [DefaultValue("SAR")]
        public string DataMemberSAR
        {
            get
            {
                return edtSAR.DataMember;
            }

            set
            {
                edtSAR.DataMember = value;
            }
        }

        public SqlQuery DataSource
        {
            get { return _dataSource; }
            set
            {
                if (ActiveSQLQuery == _dataSource)
                {
                    //if ActiveSQLQuery is not set in the designer, we assign it here
                    ActiveSQLQuery = value;
                }

                _dataSource = value;

                edtBaPersonID.DataSource = _dataSource;
                edtFaFall.DataSource = _dataSource;
                edtFaLeistungID.DataSource = _dataSource;
                edtSAR.DataSource = _dataSource;
            }
        }

        [Browsable(true)]
        [DefaultValue(false)]
        public bool ShowFaFallDropDown
        {
            get { return _showFaFallDropDown; }
            set
            {
                _showFaFallDropDown = value;
                SetupControl();
            }
        }

        [Browsable(true)]
        [DefaultValue(false)]
        public bool ShowSAR
        {
            get { return _showSAR; }
            set
            {
                _showSAR = value;
                SetupControl();
            }
        }

        #endregion

        #region EventHandlers

        private void edtFaFallIdDropDown_EditValueChanged(object sender, EventArgs e)
        {
            qryFaLeistung.Fill(edtFaFallIdDropDown.EditValue, Session.User.LanguageCode);
        }

        /// <summary>
        /// Handles the UserModifiedFld event of the edtFaFall control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KiSS4.Gui.UserModifiedFldEventArgs"/> instance containing the event data.</param>
        private void edtFaFall_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            // create a new dialog and show it
            using (var dlg = new DlgAuswahl())
            {
                e.Cancel = !dlg.PendenzFallSuchen(edtFaFall.Text, false, e.ButtonClicked);

                // if not canceled, apply values
                if (!e.Cancel)
                {
                    DataSource[DataMemberFaFall] = dlg["NameVorname$"];

                    DataSource[DataMemberBaPersonID] = null;
                    DataSource[DataMemberFaLeistungID] = null;
                    DataSource[DataMemberJumpToPath] = null;

                    Init(dlg["FaFallID$"] as int?, null);
                }
            }
        }

        private void edtFaLeistungID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            DataSource[DataMemberFaLeistungID] = edtFaLeistungID.EditValue;

            if (!ShowSAR)
            {
                return;
            }

            var sar = DBUtil.ExecuteScalarSQL(@"
                SELECT NULLIF(USR.DisplayText, '')
                FROM dbo.vwUser USR
                  INNER JOIN dbo.FaLeistung LEI ON LEI.UserID = USR.UserID
                WHERE LEI.FaLeistungID = {0};",
                edtFaLeistungID.EditValue);

            edtSAR.EditValue = sar;
            DataSource[DataMemberSAR] = sar;
        }

        private void qryFaFallPerson_AfterFill(Object sender, EventArgs e)
        {
            edtBaPersonID.LoadQuery(qryFaFallPerson, "BaPersonID", "NameVorname");
        }

        private void qryFaFalltraeger_AfterFill(object sender, EventArgs e)
        {
            //LEI.BaPersonID, PRS.NameVorname
            edtFaFallIdDropDown.LoadQuery(qryFaFalltraeger, "FaFallID", "NameVorname");
        }

        private void qryFaLeistung_AfterFill(object sender, EventArgs e)
        {
            edtFaLeistungID.LoadQuery(qryFaLeistung);
        }

        #endregion

        #region Methods

        #region Public Methods

        public void CheckNotNullFields()
        {
            if (!DBUtil.IsEmpty(DataSource[DataMemberFaFallID]))
            {
                DBUtil.CheckNotNullField(edtFaLeistungID, lblFaLeistungID.Text);
            }
        }

        public void Init(int? faFallId, int? baPersonID)
        {
            //only apply new value if it is necessary
            int? oldFaFallID = DataSource[DataMemberFaFallID] as int?;
            if (oldFaFallID != faFallId)
            {
                DataSource[DataMemberFaFallID] = faFallId;
            }

            if (faFallId.HasValue)
            {
                qryFaLeistung.Fill(faFallId, Session.User.LanguageCode);
                qryFaFallPerson.Fill(SQL_BEZUGSPERSONEN_FALLTRAEGER, faFallId.Value);
            }
            else if (baPersonID.HasValue)
            {
                qryFaLeistung.DataTable.Clear();
                qryFaFallPerson.Fill(SQL_BEZUGSPERSON, baPersonID.Value);
            }
            else
            {
                //qryFaFallLeistung und qryFaFallPerson leeren
                qryFaLeistung.DataTable.Clear();
                qryFaFallPerson.DataTable.Clear();

            }
        }

        public void InitFalltraegerDropDown(int? baPersonId)
        {
            qryFaFalltraeger.Fill(baPersonId);
        }

        public void SelectFalltraegerDropDown()
        {
            if (qryFaFalltraeger.Count == 2)
            {
                edtFaFallIdDropDown.ItemIndex = 1;
            }
        }

        /// <summary>
        /// Setzt die aktive Fallführung als Leistung
        /// </summary>
        public void SetFaLeistungFallfuehrung()
        {
            DataSource[DataMemberFaLeistungID] = DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT TOP 1 LEI.FaLeistungID
                FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                WHERE LEI.FaFallID = {0}
                  AND LEI.ModulID = 2 -- Fallführung
                ORDER BY LEI.DatumVon DESC;",
                DataSource[DataMemberFaFallID]);
        }

        #endregion

        #region Private Methods

        private void SetupControl()
        {
            // ShowSAR
            lblSAR.Visible = _showSAR;
            edtSAR.Visible = _showSAR;

            if (ShowSAR)
            {
                lblBaPersonID.Top = lblSAR.Top + 30;
                edtBaPersonID.Top = edtSAR.Top + 30;
            }
            else
            {
                lblBaPersonID.Top = lblSAR.Top;
                edtBaPersonID.Top = edtSAR.Top;
            }

            Height = edtBaPersonID.Top + edtBaPersonID.Height;

            // ShowFaFallDropDown
            edtFaFall.Visible = !_showFaFallDropDown;
            edtFaFallIdDropDown.Visible = _showFaFallDropDown;

            if (ShowFaFallDropDown)
            {
                edtFaFallIdDropDown.Width = edtFaLeistungID.Width;
            }
            else
            {
                edtFaFall.Width = edtFaLeistungID.Width;
            }
        }

        #endregion

        #endregion
    }
}