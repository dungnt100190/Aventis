using System.Collections.Generic;

namespace Kiss.DbContext.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="FaLeistung"/> entity at build time.
    /// </summary>
    internal class FaFallBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new FaFall()
            {
                BaPerson = new BaPerson(),
                FaLeistung = new List<FaLeistung>(),
                XUser = new XUser(),
                FaFallPerson = new List<FaFallPerson>(),
            };
        }
    }
}