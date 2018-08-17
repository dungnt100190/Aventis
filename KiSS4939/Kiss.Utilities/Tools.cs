using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Kiss.Utilities
{
    public class Tools
    {
        /// <summary>
        /// Since System.Windows.Forms.ApplicationFacade.DoEvents() doesn't exist in WPF-Applications,
        /// we have to create our own version of DoEvents().
        /// </summary>
        public static void DoEvents()
        {
            if (Application.Current != null)
                Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, new System.Threading.ThreadStart(delegate { }));
        }
    }
}
