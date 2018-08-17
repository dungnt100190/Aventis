namespace Kiss.Model.Test.BuildTest
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
            var entity = new BaGesundheit();
            entity.BaInstitution_Kvg = new BaInstitution();
            entity.BaInstitution_Vvg = new BaInstitution();
            entity.BaInstitution_Zahnarzt = new BaInstitution();
        }
        
    }
}
