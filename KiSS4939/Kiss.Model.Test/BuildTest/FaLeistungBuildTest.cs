namespace Kiss.Model.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="FaLeistung"/> entity at build time.
    /// </summary>
    class FaLeistungBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new FaLeistung();
            entity.BaPerson = new BaPerson();
            entity.SchuldnerBaPerson = new BaPerson();
            entity.XUser_Sachbearbeiter = new XUser();
        }
    }
}
