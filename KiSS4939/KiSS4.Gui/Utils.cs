using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KiSS4.Gui
{
    /// <summary>
    /// Class contains common used helper methods for graphical user interface handling
    /// </summary>
    class Utils
    {
        /// <summary>
        /// Recursive loop used to get all child-controls of parent-control
        /// </summary>
        /// <param name="arr">The arraylist to add controls to</param>
        /// <param name="ParentControl">The control to get child-controls from</param>
        private static void AddControls(ArrayList arr, Control ParentControl)
        {
            foreach (Control C in ParentControl.Controls)
            {
                arr.Add(C);
                AddControls(arr, C);
            }
        }

        /// <summary>
        /// Get all controls including controls of child-controls (recursive)
        /// </summary>
        /// <param name="ParentControl">The control to get child-controls from</param>
        /// <returns>All controls found within the ParentControl</returns>
        public static ArrayList AllControls(Control ParentControl)
        {
            ArrayList arr = new ArrayList();
            AddControls(arr, ParentControl);
            return arr;
        }
    }
}
