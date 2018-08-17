using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.DB.Designer;

using DevExpress.XtraEditors.Controls;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissRadioGroup.
    /// </summary>
    public class KissRadioGroup : DevExpress.XtraEditors.RadioGroup, IKissBindableEdit, IKissEditable, ISupportInitialize
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly ArrayList _codeList = new ArrayList();

        private const string DEFAULT_DISPLAY_MEMBER = "Text";
        private const string DEFAULT_VALUE_MEMBER = "Code";

        #endregion

        #region Private Fields

        private string _displayMember;
        private EditModeType _editMode = EditModeType.Normal;
        private bool _inInit;
        private string _lookupSql;
        private string _lovFilter;
        private string _lovName;
        private int _shortedTextMaxLength;
        private SortOrder _sortOrder = SortOrder.None;
        private string _valueMember;
        private Container components;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public KissRadioGroup()
        {
            DataMember = string.Empty;
            //
            // Required for Windows.Forms Class Composition Designer support
            //
            InitializeComponent();
            SetLayout();

            DisplayMember = DEFAULT_DISPLAY_MEMBER;
            ValueMember = DEFAULT_VALUE_MEMBER;
        }

        /// <summary>
        /// Constructor with the container to add control into
        /// </summary>
        /// <param name="container">The container to add the control into</param>
        public KissRadioGroup(IContainer container)
            : this()
        {
            //
            // Required for Windows.Forms Class Composition Designer support
            //
            container.Add(this);
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion

        #region Dispose

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Properties

        [DefaultValue("")]
        public string DataMember
        {
            get;
            set;
        }

        [DefaultValue(null)]
        public SqlQuery DataSource
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the display member.
        /// </summary>
        [DefaultValue(DEFAULT_DISPLAY_MEMBER)]
        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                _displayMember = value;
                ReadLookup();
            }
        }

        /// <summary>
        /// Liest oder setzt den EditMode
        /// </summary>
        /// <value></value>
        [DefaultValue(EditModeType.Normal)]
        public EditModeType EditMode
        {
            get { return _editMode; }
            set { _editMode = value; GuiConfig.SetEditMode(this, _editMode); }
        }

        /// <summary>
        /// Gets or sets the edit value.
        /// </summary>
        /// <value>The edit value.</value>
        [DefaultValue(-1)]
        public new object EditValue
        {
            get
            {
                if (_codeList.Count == 0)
                {
                    return base.EditValue;
                }

                if (SelectedIndex == -1)
                    return null;

                return _codeList[SelectedIndex];
            }
            set
            {
                if (_codeList.Count == 0)
                {
                    base.EditValue = value;
                }
                else
                {
                    //try to find the specified code in _codeList to determine the index
                    if (_codeList.Contains(value))
                    {
                        SelectedIndex = _codeList.IndexOf(value);
                    }
                    else
                    {
                        ResetSelectedIndex();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the LOV filter.
        /// </summary>
        /// <value>The LOV filter.</value>
        [DefaultValue("")]
        public string LOVFilter
        {
            get { return _lovFilter; }
            set
            {
                _lovFilter = value;
                ReadLookup();
            }
        }

        /// <summary>
        /// Gets or sets the name of the LOV.
        /// </summary>
        /// <value>The name of the LOV.</value>
        [DefaultValue("")]
        public string LOVName
        {
            get { return _lovName; }
            set
            {
                _lovName = value;
                if (!DesignMode && !_inInit)
                {
                    ReadLookup();
                }
            }
        }

        /// <summary>
        /// Gets or sets the lookup SQL.
        /// </summary>
        /// <value>The lookup SQL.</value>
        [DefaultValue("")]
        [Editor(typeof(SqlStatementEditor), typeof(UITypeEditor))]
        public string LookupSQL
        {
            get { return _lookupSql; }
            set
            {
                _lookupSql = value;
                ReadLookup();
            }
        }

        /// <summary>
        /// Get and set the max text length of a single checkboxitem. 
        /// If the text is longer than the given amount, the text will be shorted and "..." will be added.
        /// The default is 0 which means no shortening.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(0)]
        [Description("Get and set the max text length of a single checkboxitem. If the text is longer than the given amount, the text will be shorted and \"...\" will be added. The default is 0 which means no shortening.")]
        public int ShortedTextMaxLength
        {
            get { return _shortedTextMaxLength; }
            set
            {
                _shortedTextMaxLength = value < 0 ? 0 : value;
            }
        }

        /// <summary>
        /// Get and set the text to display within the items. The items are separated with "||".
        /// </summary>
        /// <example>Yes||No||Partially</example>
        [Browsable(false)]
        [Description("Get and set the text to display within the items. The items are separated with '||'.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text
        {
            get
            {
                // define vars
                string text = null;
                RadioGroupItemCollection itemCollection = Properties.Items;

                // validate
                if (itemCollection == null || itemCollection.Count < 1)
                {
                    // no items defined
                    return null;
                }

                // loop items and get description
                foreach (RadioGroupItem item in itemCollection)
                {
                    // append each item description to output text
                    text = string.Format("{0}{1}{2}", text, text == null ? "" : "||", item.Description);
                }

                // return output if any defined
                return DBUtil.IsEmpty(text) ? null : text;
            }

            set
            {
                // define vars
                string text = value;
                RadioGroupItemCollection itemCollection = Properties.Items;

                // validate
                if (itemCollection == null || itemCollection.Count < 1)
                {
                    // no items defined
                    return;
                }

                // split text to item texts
                string[] itemTexts = text.Split(new[] { "||" }, StringSplitOptions.None);
                int index = 0;

                // loop items and set description
                foreach (RadioGroupItem item in itemCollection)
                {
                    // check if index is valid
                    if (itemTexts.Length > index)
                    {
                        // set text to item if possible
                        item.Description = DBUtil.IsEmpty(itemTexts[index]) ? "" : itemTexts[index];
                    }
                    else
                    {
                        // set no text if none is defined
                        item.Description = "";
                    }

                    // count up indexer
                    index++;
                }
            }
        }

        /// <summary>
        /// Gets or sets the value member.
        /// </summary>
        [DefaultValue(DEFAULT_VALUE_MEMBER)]
        public string ValueMember
        {
            get { return _valueMember; }
            set
            {
                _valueMember = value;
                ReadLookup();
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
                    GuiConfig.SetEditMode(this, _editMode);
                else
                    GuiConfig.SetEditMode(this, EditModeType.ReadOnly);
            }
        }

        string IKissBindableEdit.GetBindablePropertyName()
        {
            return "EditValue";
        }

        /// <summary>
        /// Signals the object that initialization is starting.
        /// </summary>
        void ISupportInitialize.BeginInit()
        {
            _inInit = true;
        }

        /// <summary>
        /// Signals the object that initialization is complete.
        /// </summary>
        void ISupportInitialize.EndInit()
        {
            _inInit = false;
            if (Properties.Items.Count == 0)
            {
                ReadLookup();
            }
        }

        /// <summary>
        /// Sets the lookup data source.
        /// </summary>
        /// <param name="qry">The qry.</param>
        /// <param name="valueMember">The value member.</param>
        /// <param name="displayMember">The display member.</param>
        public void SetLookupDataSource(SqlQuery qry, string valueMember, string displayMember)
        {
            // apply sorting if necessary
            switch (_sortOrder)
            {
                case SortOrder.Ascending:
                    qry.DataTable.DefaultView.Sort = string.Format("[{0}] ASC", displayMember);
                    break;

                case SortOrder.Descending:
                    qry.DataTable.DefaultView.Sort = string.Format("[{0}] DESC", displayMember);
                    break;
            }

            Properties.Items.Clear();
            _codeList.Clear();

            foreach (var row in
                qry.DataTable.DefaultView.Cast<DataRowView>()
                .Where(row => !DBUtil.IsEmpty(row[displayMember])))
            {
                RadioGroupItem radioButton;
                var displayTextObj = row[displayMember];

                if (displayTextObj is string)
                {
                    var displayTextDefault = Convert.ToString(row[displayMember]);
                    var displayTextCheckBox = GetRadioButtonText(displayTextDefault);
                    radioButton = new RadioGroupItem(displayTextCheckBox, displayTextDefault);
                }
                else
                {
                    radioButton = new RadioGroupItem(displayTextObj, string.Empty);
                }

                Properties.Items.Add(radioButton);
                _codeList.Add(row[valueMember]);
            }

            // do not select any item by default
            ResetSelectedIndex();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// After the form is loaded, the default KiSS layout will be set
        /// </summary>
        protected override void OnLoaded()
        {
            base.OnLoaded();
            SetLayout();
        }

        /// <summary>
        /// Reads the lookup.
        /// </summary>
        protected void ReadLookup()
        {
            if (IsDesignMode || Session.User == null)
            {
                return;
            }

            ReadLookup(Session.User.LanguageCode);
        }

        /// <summary>
        /// Reads the lookup.
        /// </summary>
        /// <param name="languageCode">The language code.</param>
        protected void ReadLookup(int languageCode)
        {
            _codeList.Clear();
            Properties.Items.Clear();

            if (DBUtil.IsEmpty(_lovName) && DBUtil.IsEmpty(_lookupSql))
            {
                return;
            }

            SqlQuery qry;

            if (DBUtil.IsEmpty(_lookupSql))
            {
                ////qry = DBUtil.GetLOVQuery(_lovName, languageCode, false);

                if (DBUtil.IsEmpty(LOVFilter))
                {
                    qry = DBUtil.GetLOVQuery(_lovName, languageCode, false);
                }
                else
                {
                    qry = DBUtil.GetLOVQuery(
                        _lovName,
                        languageCode,
                        false
                        ,
                        string.Format("AND ',' + ISNULL(Value3, '') + ',' LIKE '%,' + {0} + ',%'", DBUtil.SqlLiteral(LOVFilter)));
                }
            }
            else
            {
                qry = DBUtil.OpenSQL(_lookupSql);
            }

            // apply LOV
            SetLookupDataSource(qry, ValueMember, DisplayMember);
        }

        #endregion

        #region Private Methods

        private string GetRadioButtonText(string textValue)
        {
            if (ShortedTextMaxLength < 1 || string.IsNullOrEmpty(textValue))
            {
                return textValue;
            }

            if (ShortedTextMaxLength < 4)
            {
                return "...";
            }

            // remove new-lines as those cannot be displayed properly
            textValue = textValue.Replace(Environment.NewLine, " ").Trim();

            if ((textValue.Length + 3) > ShortedTextMaxLength)
            {
                // shorted
                return string.Format("{0}...", textValue.Substring(0, ShortedTextMaxLength - 3).Trim());
            }

            // default without newlines
            return textValue;
        }

        /// <summary>
        /// Resets the index of the selected.
        /// </summary>
        private void ResetSelectedIndex()
        {
            try
            {
                SelectedIndex = -1;
            }
            catch
            {
            }
        }

        /// <summary>
        /// Setup default layout
        /// </summary>
        private void SetLayout()
        {
            // use transparent backcolor by default
            Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            Properties.Appearance.Options.UseBackColor = true;

            Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            Properties.AppearanceDisabled.Options.UseBackColor = true;
        }

        #endregion

        #endregion
    }
}