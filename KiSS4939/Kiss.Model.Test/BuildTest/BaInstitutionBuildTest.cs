namespace Kiss.Model.Test.BuildTest
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
            var entity = new BaInstitution();
            entity.BaGesundheit_IsKvgOf = new TrackableCollection<BaGesundheit>();
            entity.BaGesundheit_IsVvgOf = new TrackableCollection<BaGesundheit>();
            entity.BaGesundheit_IsZahnarztOf = new TrackableCollection<BaGesundheit>();
        }
        
    }
}
