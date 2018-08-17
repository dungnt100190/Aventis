namespace Kiss.DbContext.Test.BuildTest
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
            var entity = new XTask
            {
                XUser_Bearbeitung = new XUser(),
                XUser_Erledigt = new XUser(),
                XUser_Receiver = new XUser(),
                FaPendenzgruppe_Receiver = new FaPendenzgruppe()
            };
        }
    }
}
