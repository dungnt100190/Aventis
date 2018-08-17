using System;
using System.ComponentModel;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    [Designer(typeof(Gui.Designer.KissControlDesigner))]
    public partial class KissHeimatortEdit : KissComplexControl, IKissEditable, IKissBindableEdit
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "KissHeimatortEdit";
        private const string HEIMATORT = "Heimatort";

        #endregion

        #region Private Fields

        private EditModeType _editMode = EditModeType.Normal;
        private object _editValue;

        #endregion

        #endregion

        #region Constructors

        public KissHeimatortEdit()
        {
            DataMember = string.Empty;
            InitializeComponent();
            // init control
            SetupDataMembers();
            SetupControl();
        }

        #endregion

        #region Events

        public event EventHandler EditValueChanged;

        #endregion

        #region Properties

        [Browsable(true),
        DefaultValue("")]
        public string DataMember
        {
            get;
            set;
        }

        [Browsable(true),
        DefaultValue(DBO.BaPerson.HeimatgemeindeBaGemeindeID)]
        public string DataMemberHeimatgemeindeBaGemeindeID
        {
            get;
            set;
        }

        [Browsable(true),
        DefaultValue(DBO.BaPerson.HeimatgemeindeCodes)]
        public string DataMemberHeimatgemeindeCodes
        {
            get;
            set;
        }

        [Browsable(true),
        DefaultValue(HEIMATORT)]
        public string DataMemberHeimatort
        {
            get { return edtHeimatort.DataMember; }
            set { edtHeimatort.DataMember = value; }
        }

        [Browsable(true)]
        [DefaultValue(null)]
        public SqlQuery DataSource
        {
            get { return edtHeimatort.DataSource; }
            set
            {
                edtHeimatort.DataSource = value;
                SetupControl();
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

                edtHeimatort.EditMode = _editMode;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object EditValue
        {
            get { return _editValue; }
            set
            {
                _editValue = value;

                if (EditValueChanged != null)
                {
                    EditValueChanged(this, EventArgs.Empty);
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UserModified
        {
            get
            {
                return edtHeimatort.UserModified;
            }
        }

        #endregion

        #region EventHandlers

        private void btnHeimatorte_Click(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(DataSource[DataMemberHeimatgemeindeCodes]))
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineZusätzlicheHeimatorte", "Es existieren keine zusätzlichen Heimatorte.");
                return;
            }

            using (var dlg = new KissLookupDialog())
            {
                var strCodes = DataSource[DataMemberHeimatgemeindeCodes].ToString();
                var strSQL = string.Format(@"
                    SELECT
                      ErstesHeimatort$ = CASE WHEN BaGemeindeID = {{1}} THEN 0 ELSE 1 END,
                      ID$ = BaGemeindeID,
                      GemeindeKanton$ = Name + ISNULL(' ' + Kanton, ''),
                      Ort = Name,
                      Kanton
                    FROM dbo.BaGemeinde WITH(READUNCOMMITTED)
                    WHERE BaGemeindeID IN ({0})
                      OR  BaGemeindeID = {{1}}
                    ORDER BY 1, Name;",
                    strCodes);

                if (dlg.SearchData(strSQL, "%", true, DataSource[DataMemberHeimatgemeindeBaGemeindeID]))
                {
                    DataSource[DataMemberHeimatgemeindeBaGemeindeID] = dlg["ID$"];
                    DataSource[DataMemberHeimatort] = dlg["GemeindeKanton$"];
                }
            }
        }

        private void edtHeimatort_EditValueChanged(object sender, EventArgs e)
        {
            SetHeimatorteEnabled();
        }

        private void edtHeimatort_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();

            if (dlg.HeimatortSuchen(edtHeimatort.Text, e.ButtonClicked))
            {
                DataSource[DataMemberHeimatort] = dlg["Heimatort"];
                DataSource[DataMemberHeimatgemeindeBaGemeindeID] = dlg["Code"];
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        void IKissBindableEdit.AllowEdit(bool value)
        {
            if (_editMode != EditModeType.ReadOnly)
            {
                if (value)
                {
                    EditMode = _editMode;
                }
                else
                {
                    GuiConfig.SetEditMode(edtHeimatort, EditModeType.ReadOnly);
                }
            }
        }

        string IKissBindableEdit.GetBindablePropertyName()
        {
            return "EditValue";
        }

        #endregion

        #region Private Methods

        private void SetHeimatorteEnabled()
        {
            var heimatorte = DataSource[DBO.BaPerson.HeimatgemeindeCodes] as string;
            btnHeimatorte.Enabled = !string.IsNullOrEmpty(heimatorte) && heimatorte.IndexOf(',') > 0;
        }

        private void SetupControl()
        {
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;

            if (DataSource != null)
            {
                SetHeimatorteEnabled();
            }
        }

        private void SetupDataMembers()
        {
            DataMemberHeimatgemeindeCodes = DBO.BaPerson.HeimatgemeindeCodes;
            DataMemberHeimatgemeindeBaGemeindeID = DBO.BaPerson.HeimatgemeindeBaGemeindeID;
            DataMemberHeimatort = HEIMATORT;
        }

        #endregion

        #endregion
    }
}