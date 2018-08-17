using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Kiss.UI.Controls.Helper
{
    public class TextBoxMaskBehavior : Behavior<TextBox>
    {
        #region Fields

        #region Public Static Fields

        /// <summary>
        /// The default of this property is false.
        /// To allow the empty string, set this value to true.
        /// This property must not be changed at runtime.
        /// TODO: We might be able to determine if the source is int or int?
        /// </summary>
        public static readonly DependencyProperty AllowsNullProperty =
            DependencyProperty.Register("AllowsNull", typeof(bool), typeof(TextBoxMaskBehavior));

        // Using a DependencyProperty as the backing store for Mask.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaskProperty =
            DependencyProperty.Register("Mask", typeof(TextBoxMaskType), typeof(TextBoxMaskBehavior), new UIPropertyMetadata(MaskChangedCallback));

        // Using a DependencyProperty as the backing store for MaximumValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumValueProperty =
            DependencyProperty.Register("MaximumValue", typeof(decimal), typeof(TextBoxMaskBehavior), new UIPropertyMetadata(decimal.MaxValue, MaximumValueChangedCallback));

        // Using a DependencyProperty as the backing store for MinimumValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumValueProperty =
            DependencyProperty.Register("MinimumValue", typeof(decimal), typeof(TextBoxMaskBehavior), new UIPropertyMetadata(decimal.MinValue, MinimumValueChangedCallback));

        #endregion

        #region Private Fields

        private bool _pendingNegativeSign;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// The default of this property is false.
        /// To allow the empty string, set this value to true.
        /// This property must not be changed at runtime.
        /// TODO: We might be able to determine if the source is int or int?
        /// </summary>
        public bool AllowsNull
        {
            get { return (bool)GetValue(AllowsNullProperty); }
            set { SetValue(AllowsNullProperty, value); }
        }

        public TextBoxMaskType Mask
        {
            get { return (TextBoxMaskType)GetValue(MaskProperty); }
            set { SetValue(MaskProperty, value); }
        }

        public decimal MaximumValue
        {
            get { return (decimal)GetValue(MaximumValueProperty); }
            set { SetValue(MaximumValueProperty, value); }
        }

        public decimal MinimumValue
        {
            get { return (decimal)GetValue(MinimumValueProperty); }
            set { SetValue(MinimumValueProperty, value); }
        }

        #endregion

        #region EventHandlers

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.IsReadOnly)
            {
                return;
            }
            var isValid = IsSymbolValid(Mask, e.Text);
            e.Handled = !isValid;

            if (!isValid)
            {
                return;
            }

            int caret = textBox.CaretIndex;
            string text = textBox.Text;
            bool textInserted = false;
            int selectionLength = 0;
            bool wholeTextSelected = textBox.SelectedText == textBox.Text;

            if (textBox.SelectionLength > 0)
            {
                text = text.Substring(0, textBox.SelectionStart) +
                       text.Substring(textBox.SelectionStart + textBox.SelectionLength);
                caret = textBox.SelectionStart;
            }

            if (e.Text == NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
            {
                while (true)
                {
                    var ind = text.IndexOf(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);

                    if (ind == -1)
                    {
                        break;
                    }

                    text = text.Substring(0, ind) + text.Substring(ind + 1);

                    if (caret > ind)
                    {
                        caret--;
                    }
                }

                if (caret == 0)
                {
                    text = "0" + text;
                    caret++;
                }
                else
                {
                    if (caret == 1 && string.Empty + text[0] == NumberFormatInfo.CurrentInfo.NegativeSign)
                    {
                        text = NumberFormatInfo.CurrentInfo.NegativeSign + "0" + text.Substring(1);
                        caret++;
                    }
                }

                if (caret == text.Length)
                {
                    selectionLength = 1;
                    textInserted = true;
                    text = text + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0";
                    caret++;
                }
            }
            else if (e.Text == NumberFormatInfo.CurrentInfo.NegativeSign)
            {
                textInserted = true;

                if (string.IsNullOrEmpty(textBox.Text) || wholeTextSelected)
                {
                    // Wenn die ganze Zahl selektiert ist und der User '-' drückt, wird der Text gelöscht
                    // denn der User will wohl eine negative Zahl eingeben (sonst hätte er nicht die ganze Zahl selektiert)
                    if (wholeTextSelected)
                    {
                        text = string.Empty;
                    }
                    // leere TextBox -> Vorzeichen trotzdem wechseln (bei der nächsten Eingabe, nicht beim Pasten)
                    _pendingNegativeSign = !_pendingNegativeSign;
                }
                else
                {
                    if (textBox.Text.Contains(NumberFormatInfo.CurrentInfo.NegativeSign))
                    {
                        text = text.Replace(NumberFormatInfo.CurrentInfo.NegativeSign, string.Empty);

                        if (caret != 0)
                        {
                            caret--;
                        }
                    }
                    else
                    {
                        text = NumberFormatInfo.CurrentInfo.NegativeSign + textBox.Text;
                        caret++;
                    }
                }
            }

            if (!textInserted)
            {
                text = text.Substring(0, caret) + e.Text +
                       ((caret < textBox.Text.Length) ? text.Substring(caret) : string.Empty);

                caret++;
            }

            if (!string.IsNullOrEmpty(text))
            {
                decimal val;

                if (decimal.TryParse(text, out val))
                {
                    var valWithPendingSign = val;

                    if (_pendingNegativeSign)
                    {
                        if (valWithPendingSign > 0)
                        {
                            valWithPendingSign = -valWithPendingSign;
                        }

                        _pendingNegativeSign = false;
                    }

                    if (val == 0)
                    {
                        if (!text.Contains(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator))
                        {
                            text = "0";
                        }
                    }
                }
                else
                {
                    text = "0";
                }
            }

            while (!string.IsNullOrEmpty(text) &&
                   text.Length > 1 &&
                   text[0] == '0' &&
                   string.Empty + text[1] != NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
            {
                text = text.Substring(1);

                if (caret > 0)
                {
                    caret--;
                }
            }

            while (!string.IsNullOrEmpty(text) &&
                   text.Length > 2 &&
                   string.Empty + text[0] == NumberFormatInfo.CurrentInfo.NegativeSign && text[1] == '0' &&
                   string.Empty + text[2] != NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
            {
                text = NumberFormatInfo.CurrentInfo.NegativeSign + text.Substring(2);

                if (caret > 1)
                {
                    caret--;
                }
            }

            if (!string.IsNullOrEmpty(text) && caret > text.Length)
            {
                caret = text.Length;
            }

            textBox.Text = text;
            textBox.CaretIndex = caret;
            textBox.SelectionStart = caret;
            textBox.SelectionLength = selectionLength;
            e.Handled = true;
        }

        /// <summary>
        /// Text within the textbox has been modified.    
        /// Prefents the empty string in case NULL
        /// values are disabled. See property
        /// AllowsNull.    
        /// </summary>
        /// <param name="sender">The text box</param>
        /// <param name="e">TextChangedEventArgs</param>
        private void TextBox__TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AllowsNull)
            {
                return;
            }

            //We try not to allow the empty string.
            var textBox = (TextBox)sender;
            var text = textBox.Text;

            if (string.IsNullOrEmpty(text))
            {
                textBox.Text = "0";
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void OnAttached()
        {
            AttachToTextBox(AssociatedObject);
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            DetachFromTextBox(AssociatedObject);
            base.OnDetaching();
        }

        #endregion

        #region Private Static Methods

        private static bool IsSymbolValid(TextBoxMaskType mask, string str)
        {
            switch (mask)
            {
                case TextBoxMaskType.Integer:
                    if (str == NumberFormatInfo.CurrentInfo.NegativeSign)
                    {
                        return true;
                    }
                    break;

                case TextBoxMaskType.Decimal:
                    if (str == NumberFormatInfo.CurrentInfo.NumberDecimalSeparator || str == NumberFormatInfo.CurrentInfo.NegativeSign)
                    {
                        return true;
                    }
                    break;
            }

            if (mask.Equals(TextBoxMaskType.Integer) || mask.Equals(TextBoxMaskType.Decimal))
            {
                return str.All(Char.IsDigit);
            }

            return false;
        }

        private static void MaskChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (TextBoxMaskBehavior)d;
            instance.ValidateTextBox();
        }

        private static void MaximumValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (TextBoxMaskBehavior)d;
            instance.ValidateTextBox();
        }

        private static void MinimumValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (TextBoxMaskBehavior)d;
            instance.ValidateTextBox();
        }

        private static decimal ValidateLimits(decimal min, decimal max, decimal value)
        {
            if (value < min)
            {
                return min;
            }

            return value > max ? max : value;
        }

        private static string ValidateValue(TextBoxMaskType mask, string value, decimal min, decimal max)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            value = value.Trim();

            switch (mask)
            {
                case TextBoxMaskType.Integer:
                    {
                        int val;

                        if (int.TryParse(value, out val))
                        {
                            val = Convert.ToInt32(ValidateLimits(min, max, val));
                            return val.ToString();
                        }

                        return string.Empty;
                    }
                case TextBoxMaskType.Decimal:
                    {
                        decimal val;

                        if (decimal.TryParse(value, out val))
                        {
                            val = ValidateLimits(min, max, val);
                            return val.ToString();
                        }

                        return string.Empty;
                    }
            }

            return value;
        }

        #endregion

        #region Private Methods

        private void AttachToTextBox(TextBox textBox)
        {
            if (textBox == null)
            {
                return;
            }

            textBox.PreviewTextInput += TextBox_PreviewTextInput;
            textBox.TextChanged += TextBox__TextChanged;
            DataObject.AddPastingHandler(textBox, TextBoxPastingEventHandler);
        }

        private void DetachFromTextBox(TextBox textBox)
        {
            if (textBox == null)
            {
                return;
            }

            textBox.PreviewTextInput -= TextBox_PreviewTextInput;
            DataObject.RemovePastingHandler(textBox, TextBoxPastingEventHandler);
        }

        private void TextBoxPastingEventHandler(object sender, DataObjectPastingEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.IsReadOnly)
            {
                return;
            }
            var clipboard = e.DataObject.GetData(typeof(string)) as string;
            clipboard = ValidateValue(Mask, clipboard, MinimumValue, MaximumValue);

            if (!string.IsNullOrEmpty(clipboard))
            {
                textBox.Text = clipboard;
            }

            e.CancelCommand();
            e.Handled = true;
        }

        private void ValidateTextBox()
        {
            if (AssociatedObject != null)
            {
                AssociatedObject.Text = ValidateValue(Mask, AssociatedObject.Text, MinimumValue, MaximumValue);
            }
        }

        #endregion

        #endregion
    }
}