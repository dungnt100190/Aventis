using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiSS4.Gui;

namespace Kiss.Integration
{
    public static class Shutdown
    {
        public static bool Run(bool isClosing)
        {
            return ShutdownHelper.SavePersistentObjects(isClosing);
        }
    }
}
