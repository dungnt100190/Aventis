namespace Kiss.Model
{
    public partial class WshAbzug
    {
        #region Properties

        public bool IstAbgeschlossen
        {
            get { return AbschlussDatum != null; }
        }

        #endregion
    }
}