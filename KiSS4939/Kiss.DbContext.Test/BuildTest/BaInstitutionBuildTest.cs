namespace Kiss.DbContext.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="BaInstitution"/> entity at build time.
    /// </summary>
    class BaInstitutionBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new BaInstitution
            {
                BaGesundheit_IsKvgOf = new BaGesundheit[] {},
                BaGesundheit_IsVvgOf = new BaGesundheit[] {},
                BaGesundheit_IsZahnarztOf = new BaGesundheit[] {}
            };
        }

    }
}
