using System;
using System.ComponentModel;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    [Designer(typeof(Gui.Designer.KissControlDesigner))]
    public partial class KissPLZOrt : KissComplexControl, IKissEditable, IKissBindableEdit
    {
        public Func<DateTime?> GetDatum;

        private EditModeType _editMode = EditModeType.Normal;
        private object _editValue;
        private bool _inUserModifiedFld;
        private KissTextEdit _modifiedFldBeforeValidate;
        private bool _showBezirk;
        private bool _showKanton = true;
        private bool _showLand = true;

        public KissPLZOrt()
        {
            DataMember = string.Empty;
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // init control
            SetupDataMembers();
            SetupControl();
        }

        public event EventHandler EditValueChanged;

        [Browsable(true), DefaultValue("")]
        public string DataMember
        {
            get;
            set;
        }

        [Browsable(true)]
        public string DataMemberBaGemeindeID
        {
            get;
            set;
        }

        [Browsable(true),
        DefaultValue(DBO.BaAdresse.Bezirk)]
        public string DataMemberBezirk
        {
            get { return EdtBezirk.DataMember; }
            set { EdtBezirk.DataMember = value; }
        }

        [Browsable(true),
        DefaultValue(DBO.BaAdresse.Kanton)]
        public string DataMemberKanton
        {
            get { return EdtKanton.DataMember; }
            set { EdtKanton.DataMember = value; }
        }

        [Browsable(true),
        DefaultValue(DBO.BaAdresse.BaLandID)]
        public string DataMemberLand
        {
            get { return EdtLand.DataMember; }
            set { EdtLand.DataMember = value; }
        }

        [Browsable(true),
        DefaultValue(DBO.BaAdresse.Ort)]
        public string DataMemberOrt
        {
            get { return EdtOrt.DataMember; }
            set { EdtOrt.DataMember = value; }
        }

        [Browsable(true),
        DefaultValue(DBO.BaAdresse.PLZ)]
        public string DataMemberPLZ
        {
            get { return EdtPLZ.DataMember; }
            set { EdtPLZ.DataMember = value; }
        }

        [Browsable(true)]
        [DefaultValue(null)]
        public SqlQuery DataSource
        {
            get { return EdtOrt.DataSource; }
            set
            {
                EdtPLZ.DataSource = value;
                EdtOrt.DataSource = value;

                EdtKanton.DataSource = ShowKanton ? value : null;
                EdtBezirk.DataSource = ShowBezirk ? value : null;
                EdtLand.DataSource = ShowLand ? value : null;
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

                EdtPLZ.EditMode = _editMode;
                EdtOrt.EditMode = _editMode;
                EdtLand.EditMode = _editMode;
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

        [DefaultValue("")]
        public string Ort
        {
            get { return string.Format("{0}", EdtOrt.EditValue); }
            set { EdtOrt.Text = value; }
        }

        [DefaultValue("")]
        public string PLZ
        {
            get { return string.Format("{0}", EdtPLZ.EditValue); }
            set { EdtPLZ.Text = value; }
        }

        [Browsable(true)]
        [DefaultValue(false)]
        public bool ShowBezirk
        {
            get { return _showBezirk; }
            set
            {
                _showBezirk = value;
                SetupControl();
            }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        public bool ShowKanton
        {
            get { return _showKanton; }
            set
            {
                _showKanton = value;
                SetupControl();
            }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        public bool ShowLand
        {
            get { return _showLand; }
            set
            {
                _showLand = value;
                SetupControl();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UserModified
        {
            get
            {
                return EdtPLZ.UserModified ||
                       EdtOrt.UserModified ||
                       EdtLand.UserModified;
            }
        }

        public void DoValidate()
        {
            if (_modifiedFldBeforeValidate != null) // Werte wurden geändert
            {
                // Event auslösen welcher das Feld auf die Korrektheit der Eingabe überprüft
                var args = new UserModifiedFldEventArgs(true);
                edt_UserModifiedFld(_modifiedFldBeforeValidate, args);

                if (args.Cancel)
                {
                    throw new KissCancelException(_modifiedFldBeforeValidate);
                }

                _modifiedFldBeforeValidate = null;
            }
        }

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
                    GuiConfig.SetEditMode(EdtPLZ, EditModeType.ReadOnly);
                    GuiConfig.SetEditMode(EdtOrt, EditModeType.ReadOnly);
                    GuiConfig.SetEditMode(EdtLand, EditModeType.ReadOnly);
                }
            }
        }

        string IKissBindableEdit.GetBindablePropertyName()
        {
            return "EditValue";
        }

        private void edt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (ShouldIgnoreKey(e.KeyCode))
                return;

            _modifiedFldBeforeValidate = (KissTextEdit)sender;
        }

        private void edt_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (_inUserModifiedFld || _modifiedFldBeforeValidate == null)
            {
                if (!((IKissUserModified)sender).UserModified)
                {
                    return;
                }
            }

            _inUserModifiedFld = true;

            try
            {
                DevExpress.XtraEditors.BaseEdit edt = (DevExpress.XtraEditors.BaseEdit)sender;
                IKissBindableEdit bindEdit = (IKissBindableEdit)sender;
                SqlQuery qry = bindEdit.DataSource;

                if (edt == EdtLand)
                {
                    qry[bindEdit.DataMember] = EdtLand.EditValue;

                    if (!Utils.isSchweiz(EdtLand.EditValue))
                    {
                        SetValue(EdtPLZ, DBNull.Value);
                        SetValue(EdtOrt, DBNull.Value);
                        SetValue(EdtKanton, DBNull.Value);
                        SetValue(EdtBezirk, DBNull.Value);
                    }
                    else
                    {
                        _inUserModifiedFld = false;

                        if (!string.IsNullOrEmpty(EdtPLZ.Text))
                        {
                            EdtPLZ.UserModified = true;
                            edt_UserModifiedFld(EdtPLZ, e);
                        }
                        else
                        {
                            EdtOrt.UserModified = true;
                            edt_UserModifiedFld(EdtOrt, e);
                        }
                    }
                }
                else
                {
                    if (_showLand && qry != null && !Utils.isSchweiz(qry[EdtLand.DataMember]))
                    {
                        qry[bindEdit.DataMember] = edt.Text;
                        return;
                    }

                    if (DBUtil.IsEmpty(edt.Text))
                    {
                        SetValue(EdtPLZ, DBNull.Value);
                        SetValue(EdtOrt, DBNull.Value);

                        if (ShowKanton)
                        {
                            SetValue(EdtKanton, DBNull.Value);
                        }

                        if (ShowBezirk)
                        {
                            SetValue(EdtBezirk, DBNull.Value);
                        }

                        if (DataSource != null && !DBUtil.IsEmpty(DataMember))
                        {
                            DataSource[DataMember] = DBNull.Value;
                        }
                        else
                        {
                            EditValue = DBNull.Value;
                        }

                        if (DataSource != null)
                        {
                            if (!DBUtil.IsEmpty(DataMemberBaGemeindeID))
                            {
                                DataSource[DataMemberBaGemeindeID] = DBNull.Value;
                            }

                            DataSource.RefreshDisplay();
                        }

                        return;
                    }

                    DlgAuswahl dlg = new DlgAuswahl();

                    if (edt == EdtPLZ)
                    {
                        var datum = (GetDatum != null) ? GetDatum().GetValueOrDefault(DateTime.Today) : DateTime.Today;
                        e.Cancel = !dlg.PLZSearch(edt.Text, datum);
                    }
                    else
                    {
                        var datum = (GetDatum != null) ? GetDatum().GetValueOrDefault(DateTime.Today) : DateTime.Today;
                        e.Cancel = !dlg.OrtSearch(edt.Text, datum);
                    }

                    if (!e.Cancel)
                    {
                        if (_showLand)
                        {
                            SetValue(EdtLand, Session.BaLandCodeSchweiz);
                        }

                        SetValue(EdtPLZ, dlg["Value1"]);
                        SetValue(EdtOrt, dlg["Text"]);

                        if (ShowKanton)
                        {
                            SetValue(EdtKanton, dlg["Value2"]);
                        }

                        if (ShowBezirk)
                        {
                            SetValue(EdtBezirk, dlg["Value3"]);
                        }

                        if (qry != null && !DBUtil.IsEmpty(DataMemberBaGemeindeID))
                        {
                            qry[DataMemberBaGemeindeID] = dlg[DBO.BaGemeinde.BaGemeindeID];
                        }

                        if (qry != null && !DBUtil.IsEmpty(DataMember))
                        {
                            qry[DataMember] = dlg["Code"];
                        }
                        else
                        {
                            EditValue = dlg["Code"];
                        }
                    }
                    else if (qry != null)
                    {
                        qry[bindEdit.DataMember] = edt.OldEditValue;
                    }
                }
            }
            finally
            {
                if (_modifiedFldBeforeValidate != null)
                {
                    _modifiedFldBeforeValidate.DoValidate();
                    _modifiedFldBeforeValidate = null;
                }

                _inUserModifiedFld = false;
            }
        }

        private void SetupControl()
        {
            // handle ShowKanton
            EdtKanton.Visible = ShowKanton;
            EdtKanton.DataSource = ShowKanton ? DataSource : null;
            EdtKanton.TabStop = ShowKanton;
            EdtOrt.Width = Width - (EdtPLZ.Width + (ShowKanton ? EdtKanton.Width - 2 : -1));

            // handle ShowLand
            EdtLand.Visible = ShowLand;
            EdtLand.DataSource = ShowLand ? DataSource : null;
            EdtLand.TabStop = ShowLand;
            Height = ShowLand ? 47 : 24;

            // handle ShowBezirk
            EdtBezirk.Visible = ShowBezirk;
            EdtBezirk.DataSource = ShowBezirk ? DataSource : null;
            EdtBezirk.TabStop = ShowBezirk;

            // setup control
            if (ShowBezirk && ShowLand)
            {
                Height = 70;

                EdtBezirk.Top = EdtPLZ.Top + EdtPLZ.Height - 1;
                EdtLand.Top = EdtBezirk.Top + EdtBezirk.Height - 1;
            }
            else if (ShowBezirk || ShowLand)
            {
                Height = 47;

                if (ShowBezirk)
                {
                    EdtBezirk.Top = EdtPLZ.Top + EdtPLZ.Height - 1;
                }
                else
                {
                    EdtLand.Top = EdtPLZ.Top + EdtPLZ.Height - 1;
                }
            }
            else
            {
                Height = 24;
            }
        }

        private void SetupDataMembers()
        {
            DataMemberPLZ = DBO.BaAdresse.PLZ;
            DataMemberOrt = DBO.BaAdresse.Ort;
            DataMemberKanton = DBO.BaAdresse.Kanton;
            DataMemberBezirk = DBO.BaAdresse.Bezirk;
            DataMemberLand = DBO.BaAdresse.BaLandID;
        }

        private void SetValue(KissTextEdit edt, object value)
        {
            if (edt.DataSource != null && !DBUtil.IsEmpty(edt.DataMember))
            {
                edt.EditValue = value;
                edt.DataSource[edt.DataMember] = value;
            }
            else
            {
                edt.EditValue = value;
            }
        }

        private void SetValue(KissLookUpEdit edt, object value)
        {
            if (edt.DataSource != null && !DBUtil.IsEmpty(edt.DataMember))
            {
                edt.DataSource[edt.DataMember] = value;
            }
            else
            {
                edt.EditValue = value;
            }
        }

        private bool ShouldIgnoreKey(Keys keyCode)
        {
            if (keyCode == Keys.F1
                || keyCode == Keys.F2
                || keyCode == Keys.F3
                || keyCode == Keys.F4
                || keyCode == Keys.F5
                || keyCode == Keys.F6
                || keyCode == Keys.F7
                || keyCode == Keys.F8
                || keyCode == Keys.F9
                || keyCode == Keys.F10
                || keyCode == Keys.F11
                || keyCode == Keys.F12
                || keyCode == Keys.Enter
                || keyCode == Keys.Tab
                || keyCode == Keys.Home
                || keyCode == Keys.End
                || keyCode == Keys.Shift
                || keyCode == Keys.ShiftKey
                || keyCode == Keys.LShiftKey
                || keyCode == Keys.RShiftKey)
            {
                return true;
            }

            return false;
        }
    }
}