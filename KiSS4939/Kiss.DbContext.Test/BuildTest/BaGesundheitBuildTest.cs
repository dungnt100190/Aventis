namespace Kiss.DbContext.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="BaGesundheit"/> entity at build time.
    /// </summary>
    class BaGesundheitBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new BaGesundheit
            {
                BaInstitution_Kvg = new BaInstitution(),
                BaInstitution_Vvg = new BaInstitution(),
                BaInstitution_Zahnarzt = new BaInstitution()
            };
        }

    }
}
