namespace Kiss.DbContext.Test.BuildTest
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
            var entity = new FsDienstleistungspaket
            {
                FaPhase_Bedarf = new FaPhase[] { },
                FaPhase_Zugewiesen = new FaPhase[] { }
            };
        }
    }
}
