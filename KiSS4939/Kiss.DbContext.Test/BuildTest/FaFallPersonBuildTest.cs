namespace Kiss.DbContext.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="FaLeistung"/> entity at build time.
    /// </summary>
    internal class FaFallPersonBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new FaFallPerson()
            {
                BaPerson = new BaPerson(),
                FaFall = new FaFall(),
            };
        }
    }
}