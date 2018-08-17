namespace Kiss.DbContext.Test.BuildTest
{
    internal class FaDokumentAblageBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new FaDokumentAblage
            {
                XDocument = new XDocument()
            };
        }
    }
}