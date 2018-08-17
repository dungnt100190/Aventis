using System.Windows.Forms;
using System.Windows.Input;

namespace Kiss.UI.Controls.Helper
{
    internal class UIUtilities
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Convert new WPF input KeyEventArgs to old winforms KeyEventArgs
        /// </summary>
        /// <param name="inputKeyEventArgs">The WPF input KeyEventArgs to convert</param>
        /// <returns>The corresponding winforms KeyEventArgs</returns>
        /// <see cref="http://stackoverflow.com/questions/1153009/how-can-i-convert-system-windows-input-key-to-system-windows-forms-keys"/>
        /// <seealso cref="http://ho.runcode.us/q/how-can-i-convert-system-windows-input-key-to-system-windows-forms-keys"/>
        public static System.Windows.Forms.KeyEventArgs ConvertToFormsKeyEventArgs(System.Windows.Input.KeyEventArgs inputKeyEventArgs)
        {
            var wpfKey = inputKeyEventArgs.Key == Key.System ? inputKeyEventArgs.SystemKey : inputKeyEventArgs.Key;
            var formsKey = (Keys)KeyInterop.VirtualKeyFromKey(wpfKey);

            var formsKeyEventArgs = new System.Windows.Forms.KeyEventArgs(formsKey)
            {
                Handled = inputKeyEventArgs.Handled
            };

            return formsKeyEventArgs;
        }

        #endregion

        #endregion
    }
}