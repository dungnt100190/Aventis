namespace Kiss.Model.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="XTask"/> entity at build time.
    /// </summary>
    class XTaskBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new XTask();
            entity.XUser_Bearbeitung = new XUser();
            entity.XUser_Erledigt = new XUser();
        }
    }
}
