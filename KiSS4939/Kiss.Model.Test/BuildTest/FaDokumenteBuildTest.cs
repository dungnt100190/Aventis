namespace Kiss.Model.Test.BuildTest
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
            var entity = new FaDokumente();
            entity.BaPerson_Adressat = new BaPerson();
            entity.BaPerson_LT = new BaPerson();
            entity.XUser_Absender = new XUser();
            entity.XUser_EkVisum = new XUser();
            entity.XUser_VisiertDurch = new XUser();
            entity.XUser_VisumBeantragtBei = new XUser();
            entity.XUser_VisumBeantragtDurch = new XUser();
            entity.XDocument = new XDocument();
            entity.XDocument_Merkblatt = new XDocument();
        }
    }
}