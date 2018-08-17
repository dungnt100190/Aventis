namespace Kiss.Model.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="FaWeisung"/> entity at build time.
    /// </summary>
    class FaWeisungBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new FaWeisung();
            entity.XUser_Creator = new XUser();
            entity.XUser_VerantwortlichRd = new XUser();
            entity.XUser_VerantwortlichSar = new XUser();
            entity.XDocument_Weisung = new XDocument();
            entity.XDocument_Mahnung1 = new XDocument();
            entity.XDocument_Mahnung2 = new XDocument();
            entity.XDocument_Mahnung3= new XDocument();
            entity.XDocument_Verfuegung = new XDocument();
        }
    }
}
