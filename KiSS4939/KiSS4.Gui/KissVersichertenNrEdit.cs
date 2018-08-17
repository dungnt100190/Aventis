using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Control used to enter and validate VersichertenNummer
    /// </summary>
    public partial class KissVersichertenNrEdit : KissCalcEdit
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
        private static readonly Regex VALIDVERSNR = new Regex(@"[0-9]{3}\.[0-9]{4}\.[0-9]{4}\.[0-9]{2}");

        #endregion

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// The default mask used for VersichertenNummer
        /// </summary>
        private const string MASK = @"000\.0000\.0000\.00";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissVersichertenNrEdit"/> class.
        /// </summary>
        public KissVersichertenNrEdit()
        {
            // init control
            InitializeComponent();

            // init as KissVersichertenNrEdit
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

        /// <summary>
        /// Occurs when the user clicks into the control. If the EditValue is empty, select all so the input starts at the first char
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnMaskBox_Click(object sender, EventArgs e)
        {
            base.OnMaskBox_Click(sender, e);
            if(string.IsNullOrEmpty(Convert.ToString(this.EditValue)))
            {
                this.SelectAll();
            }
        }

        private void KissVersichertenNrEdit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
        /// <param name="versNr">The VersichertenNr to validate</param>
        /// <param name="showMessageIfInvalid">Flag if specific message has to be shown on invalid number</param>
        /// <param name="isRequired">Flag if VersichertenNummer is required and cannot be empty</param>
        /// <returns><c>True</c> if value is valid, otherwise <c>False</c></returns>
        public static bool IsVersNrValid(string versNr, bool showMessageIfInvalid, bool isRequired)
        {
            #region First Validation

            // check if any value is set
            if (string.IsNullOrEmpty(versNr))
            {
                // no number, check if we have to show message
                if (isRequired && showMessageIfInvalid)
                {
                    // number is required, show message
                    KissMsg.ShowInfo("KissVersichertenNrEdit", "RequiredVersNrIsEmpty", "Die Versichertennummer darf nicht leer bleiben!");
                }

                // return value depending on required state (if required: false, if not required=true)
                return !isRequired;
            }

            // prepare given number and remove all invalid chars
            string versNrChars = INVALIDCHARS.Replace(versNr, "");

            // validate length
            if (versNrChars.Length != 13)
            {
                // check if need to show message
                if (showMessageIfInvalid)
                {
                    // number is invalid, show message
                    KissMsg.ShowInfo("KissVersichertenNrEdit", "VersNrHasInvalidLength", "Die Versichertennummer muss genau 13 Ziffern beinhalten!");
                }

                // invalid length
                return false;
            }

            // additionaly check if we have exactly one match for a valid VersNr
            if (versNr.Length != 16 || !string.IsNullOrEmpty(VALIDVERSNR.Replace(versNr, "")))
            {
                // check if need to show message
                if (showMessageIfInvalid)
                {
                    // content is invalid, show message
                    KissMsg.ShowInfo("KissVersichertenNrEdit", "VersNrHasInvalidContent", "Die Versichertennummer entspricht nicht dem erwarteten Format!");
                }

                // invalid content
                return false;
            }

            #endregion

            #region Kontrollzifferpruefung (as defined from EDI)

            // init additional vars
            int sum = 0;                                    // store the sum of all multiplied values
            bool isEvenNumber = false;                      // flag if current entry is a even position (true = digit 2, 4, 6, 8, 10, 12 from right hand, started with 2nd digit)
            char[] numbers = versNrChars.ToCharArray();     // split current validated value of versNr to single chars for parsing
            int checkNumber = -1;                           // store the calculated checknumber used for comparison

            // loop char-array and calculate sum (start with 2nd digit from right hand)
            for (int i = (numbers.Length - 2); i >= 0; i--)
            {
                // get current digit (first convert to string to get char from char-code)
                int digit = Convert.ToInt32(Convert.ToString(numbers[i]));

                // sum up depending on current even/odd flag
                sum += isEvenNumber ? digit : (digit * 3);

                // switch flag for next digit
                isEvenNumber = !isEvenNumber;
            }

            // calculate checknumber as defined
            checkNumber = (10 - (sum % 10)) % 10;

            // compare with current last digit
            if (Convert.ToInt32(Convert.ToString(numbers[12])) != checkNumber)
            {
                // check if need to show message
                if (showMessageIfInvalid)
                {
                    // number is invalid, show message
                    KissMsg.ShowInfo("KissVersichertenNrEdit", "VersNrHasInvalidCheckNumber_v01", "Die angegebene Versichertennummer ist ungültig!");
                }

                // invalid checknumber
                return false;
            }

            // number is valid! :)
            return true;

            #endregion
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Init control for usage as KissVersichertenNrEdit
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
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(KissVersichertenNrEdit_KeyDown);

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
        public bool ValidateVersNr(bool showMessageIfInvalid, bool isRequired)
        {
            // validate number
            return IsVersNrValid(Convert.ToString(this.EditValue), showMessageIfInvalid, isRequired);
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