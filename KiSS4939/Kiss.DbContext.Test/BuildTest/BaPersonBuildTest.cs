namespace Kiss.DbContext.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="BaPerson"/> entity at build time.
    /// </summary>
    class BaPersonBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new BaPerson
            {
                FaLeistung = new FaLeistung[] {},
                FaLeistung_Schuldner = new FaLeistung[] {},
                FaDokumente_IsAdressatOf = new FaDokumente[] {},
                FaDokumente_IsLtOf = new FaDokumente[] {},
                BaGemeinde = new BaGemeinde()
            };
        }
    }
}