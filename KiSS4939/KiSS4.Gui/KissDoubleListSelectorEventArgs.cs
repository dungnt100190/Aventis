using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KiSS4.Gui
{

    public delegate void KissDoubleListSelectorEventHandler(Object sender, KissDoubleListSelectorEventArgs e);


    /// <summary>
    /// Event for KissDoubleList.
    /// </summary>
    public class KissDoubleListSelectorEventArgs : EventArgs
    {
        /// <summary>
        /// The DataRow that was selected or unselected in
        /// the picklist.
        /// </summary>
        public DataRow ItemRow { get; set; }
       
    }
}
