
namespace KiSS4.Pendenzen.Monitor
{
    public class PendenzMonitor : Monitor
    {
        #region Fields and Properties

        #endregion

        #region Constructor

        public PendenzMonitor()
        {
            provider = new PendenzProvider();
        }

        public PendenzMonitor(IPendenzProvider provider)
        {
            this.provider = provider;
        }

        #endregion

        
        public override void LookUp() 
        {
            provider.LookUp();
            foreach (IPendenz pendenz in provider)
            {
                OnDetected();
            }  
        }
    }
}
