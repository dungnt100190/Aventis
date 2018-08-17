namespace Kiss.DbContext.Test.BuildTest
{
    /// <summary>
    /// Class to test the <see cref="XOrgUnit"/> entity at build time.
    /// </summary>
    class XOrgUnitBuildTest
    {
        /// <summary>
        /// Checks if the navigation properties which have been renamed are available
        /// </summary>
        private void HasNavigationProperties()
        {
            var entity = new XOrgUnit
            {
                XOrgUnit_IsParentOf = new XOrgUnit[]{},
                XOrgUnit_Parent = new XOrgUnit(),
                XUser_Chief = new XUser(),
                XUser_Rechtsdienst = new XUser(),
                XUser_Representative = new XUser()
            };
        }
    }
}
