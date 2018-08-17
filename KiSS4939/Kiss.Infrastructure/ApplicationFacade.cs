using System.Windows.Forms;

namespace Kiss.Infrastructure
{
    public static class ApplicationFacade
    {
        static ApplicationFacade()
        {
            SuppressDoEvents = false;
        }

        public static bool SuppressDoEvents { get; set; }

        public static void DoEvents()
        {
            if (!SuppressDoEvents)
            {
                Application.DoEvents();
            }
        }
    }
}