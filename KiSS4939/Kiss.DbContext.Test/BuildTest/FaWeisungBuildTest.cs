namespace Kiss.DbContext.Test.BuildTest
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
            var entity = new FaWeisung
            {
                XUser_Creator = new XUser(),
                XUser_VerantwortlichRd = new XUser(),
                XUser_VerantwortlichSar = new XUser(),
                XDocument_Weisung = new XDocument(),
                XDocument_Mahnung1 = new XDocument(),
                XDocument_Mahnung2 = new XDocument(),
                XDocument_Mahnung3 = new XDocument(),
                XDocument_Verfuegung = new XDocument()
            };
        }
    }
}
