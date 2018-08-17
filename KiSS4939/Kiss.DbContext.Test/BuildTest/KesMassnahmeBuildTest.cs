namespace Kiss.DbContext.Test.BuildTest
{
    internal class KesMassnahmeBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new KesMassnahme
            {
                UebernahmeVon_KesBehoerde = new KesBehoerde(),
                UebertragungAn_KesBehoerde = new KesBehoerde(),
            };
        }
    }
}