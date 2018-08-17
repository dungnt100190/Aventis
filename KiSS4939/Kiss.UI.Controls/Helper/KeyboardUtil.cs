using System.Windows.Input;

namespace Kiss.UI.Controls.Helper
{
    public class KeyboardUtil
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Gets a value that indicates whether an Alt key is pressed.
        /// </summary>
        /// <returns></returns>
        public static bool IsAnyAltKeyPressed()
        {
            return IsModifierKeyPressed(ModifierKeys.Alt);
        }

        /// <summary>
        /// Get flag if left or right CTRL key is pressed
        /// </summary>
        /// <returns><c>True</c> if any CTRL key is pressed, else <c>False</c></returns>
        public static bool IsAnyControlKeyPressed()
        {
            return IsModifierKeyPressed(ModifierKeys.Control);
        }

        /// <summary>
        /// Gets a value that indicates whether a Shift key is pressed.
        /// </summary>
        /// <returns></returns>
        public static bool IsAnyShiftKeyPressed()
        {
            return IsModifierKeyPressed(ModifierKeys.Shift);
        }

        /// <summary>
        /// Gets a value that indicates whether the specified modifier key is pressed.
        /// </summary>
        /// <param name="modifier"></param>
        /// <returns></returns>
        public static bool IsModifierKeyPressed(ModifierKeys modifier)
        {
            return (Keyboard.Modifiers & modifier) == modifier;
        }

        /// <summary>
        /// Get flag if any modifier key is pressed
        /// </summary>
        /// <returns><c>True</c> if any modifier key is pressed, else <c>False</c></returns>
        public static bool IsModifierKeyPressed()
        {
            return IsAnyControlKeyPressed() ||
                   IsAnyAltKeyPressed() ||
                   IsAnyShiftKeyPressed() ||
                   Keyboard.IsKeyDown(Key.LWin) ||
                   Keyboard.IsKeyDown(Key.RWin);
        }

        #endregion

        #endregion
    }
}