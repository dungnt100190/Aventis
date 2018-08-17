namespace Kiss.Model.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="FaPhase"/> entity at build time.
    /// </summary>
    class FaPhaseBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new FaPhase();
            entity.FsDienstleistungspaket_Bedarf = new FsDienstleistungspaket();
            entity.FsDienstleistungspaket_Zugewiesen = new FsDienstleistungspaket();
        }
    }
}
