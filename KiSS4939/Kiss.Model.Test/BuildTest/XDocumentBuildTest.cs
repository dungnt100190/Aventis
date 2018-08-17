namespace Kiss.Model.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="XDocument"/> entity at build time.
    /// </summary>
    class XDocumentBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new XDocument();
            entity.FaDokumente = new TrackableCollection<FaDokumente>();
            entity.FaWeisung = new TrackableCollection<FaWeisung>();
            entity.FaWeisung_Mahnung1 = new TrackableCollection<FaWeisung>();
            entity.FaWeisung_Mahnung2 = new TrackableCollection<FaWeisung>();
            entity.FaWeisung_Mahnung3 = new TrackableCollection<FaWeisung>();
            entity.FaWeisung_Verfuegung = new TrackableCollection<FaWeisung>();
        }
    }
}
