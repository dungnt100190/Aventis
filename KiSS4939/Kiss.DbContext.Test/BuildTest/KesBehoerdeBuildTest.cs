namespace Kiss.DbContext.Test.BuildTest
{
    internal class KesBehoerdeBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new KesBehoerde
            {
                KesMassnahme_UebernahmeVon = new KesMassnahme[0],
                KesMassnahme_UebertragungAn = new KesMassnahme[0],
            };
        }
    }
}