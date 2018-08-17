using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KiSS4.Gui
{
    /// <summary>
    /// Control used to enter and validate VersichertenNummer
    /// </summary>
    public partial class KissAHVNrEdit : KissCalcEdit
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// pattern to match invalid chars (only numbers are valid for CRC check)
        /// </summary>
        private static readonly Regex INVALIDCHARS = new Regex(@"[^0-9]");

        /// <summary>
        /// pattern of valid VersichertenNr
        /// </summary>
        private static readonly Regex VALIDAHVNR = new Regex(@"[0-9]{3}\.[0-9]{2}\.[0-9]{3}\.[0-9]{3}");

        #endregion

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// The default mask used for VersichertenNummer
        /// </summary>
        private const string MASK = @"000\.00\.000\.000";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissAHVNrEdit"/> class.
        /// </summary>
        public KissAHVNrEdit()
        {
            // init control
            InitializeComponent();

            // init as KissAHVNrEdit
            InitControl();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Do not use this property, it will throw exception as VersichertenNummer is never a decimal number
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public override decimal Value
        {
            get
            {
                throw new NotImplementedException("This property cannot be used.");
            }
        }

        #endregion

        #region EventHandlers

        private void KissAHVNrEdit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal))
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Validate given VersichertenNr as defined in Kontrollzifferpruefung
        /// </summary>
        /// <param name="ahvNr">The VersichertenNr to validate</param>
        /// <param name="showMessageIfInvalid">Flag if specific message has to be shown on invalid number</param>
        /// <param name="isRequired">Flag if VersichertenNummer is required and cannot be empty</param>
        /// <returns><c>True</c> if value is valid, otherwise <c>False</c></returns>
        public static bool IsAHVNrValid(string ahvNr, bool showMessageIfInvalid, bool isRequired)
        {
            throw new NotImplementedException("Validierung nicht implementiert");
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Init control for usage as KissAHVNrEdit
        /// </summary>
        public void InitControl()
        {
            // general settings
            this.Properties.Buttons.Clear();
            this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.Properties.MaxLength = 13;
            this.Properties.Precision = 0;
            this.ErrorText = string.Empty;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(KissAHVNrEdit_KeyDown);

            // mask properties
            this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.Properties.Mask.EditMask = MASK;
            this.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Properties.Mask.IgnoreMaskBlank = true;

            this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Properties.EditFormat.FormatString = MASK;

            this.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Properties.DisplayFormat.FormatString = MASK;
        }

        /// <summary>
        /// Validate current VersichertenNr as defined in Kontrollzifferpruefung
        /// </summary>
        /// <param name="showMessageIfInvalid">Flag if specific message has to be shown on invalid number</param>
        /// <param name="isRequired">Flag if VersichertenNummer is required and cannot be empty</param>
        /// <returns><c>True</c> if value is valid, otherwise <c>False</c></returns>
        public bool ValidateAHVNr(bool showMessageIfInvalid, bool isRequired)
        {
            // validate number
            return IsAHVNrValid(Convert.ToString(this.EditValue), showMessageIfInvalid, isRequired);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Called when [edit value changed].
        /// </summary>
        protected override void OnEditValueChanged()
        {
            // HACK: applied code from original devexpress base class as we cannot access base.base method
            base.UpdateViewInfoEditValue();
            base.OnTextChanged(EventArgs.Empty);

            if (!IsMaskBoxUpdate)
            {
                LayoutChanged();
            }

            RaiseEditValueChanged();
        }

        /// <summary>
        /// On validating current value
        /// </summary>
        /// <param name="e"></param>
        protected override void OnValidating(CancelEventArgs e)
        {
            // do nothing (prevent icon with error text on invalid value)
            // base.OnValidating(e);
        }

        #endregion

        #endregion
    }
}