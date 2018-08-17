namespace Kiss.Model.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="FsDienstleistungspaket"/> entity at build time.
    /// </summary>
    class FsDienstleistungspaketBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new FsDienstleistungspaket();
            entity.FaPhase_Bedarf = new TrackableCollection<FaPhase>();
            entity.FaPhase_Zugewiesen = new TrackableCollection<FaPhase>();
        }
    }
}
