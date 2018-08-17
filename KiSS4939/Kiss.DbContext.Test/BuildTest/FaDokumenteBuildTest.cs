namespace Kiss.DbContext.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="FaDokumente"/> entity at build time.
    /// </summary>
    class FaDokumenteBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new FaDokumente
            {
                BaPerson_Adressat = new BaPerson(),
                BaPerson_LT = new BaPerson(),
                XUser_Absender = new XUser(),
                XUser_EkVisum = new XUser(),
                XUser_VisiertDurch = new XUser(),
                XUser_VisumBeantragtBei = new XUser(),
                XUser_VisumBeantragtDurch = new XUser(),
                XDocument = new XDocument(),
                XDocument_Merkblatt = new XDocument()
            };
        }
    }
}